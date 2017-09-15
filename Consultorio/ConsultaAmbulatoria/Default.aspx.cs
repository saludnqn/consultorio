using System;
using System.Collections.Generic;
using DalSic;
using System.Transactions;
using SubSonic;
using Salud.Security.SSO;


namespace Consultorio.ConsultaAmbulatoria
{
    public partial class Default : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }
        private int idConsulta
        {
            get { return ViewState["idConsulta"] == null ? 0 : Convert.ToInt32(ViewState["idConsulta"]); }
            set { ViewState["idConsulta"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            int idHCP, idPaciente;
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHCP))
            {
                AprHistoriaClinicaPerinatal oHCP = new AprHistoriaClinicaPerinatal(idHCP);
                idPaciente = oHCP.IdPaciente;
            
                int idTemp = idPaciente;
                int idConsultaTemp;

            
            
                idPaciente = idTemp;
                ConsultaAmbulatoria1.idPaciente = idTemp;
            
            if (Int32.TryParse(Request.QueryString["idConsulta"], out idConsultaTemp))
            {
                idConsulta = idConsultaTemp;
                ConsultaAmbulatoria1.idConsulta = idConsultaTemp;
            }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente={0}", idPaciente));
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Paciente/PacienteView.aspx?id={0}", idPaciente));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ConsultaAmbulatoria.UserControls.ResultadoConsulta oResultadoConsulta = ConsultaAmbulatoria1.getDatos();
            if (oResultadoConsulta.Estado == MessageStatus.ok)
            {
                //Guardo la consulta
                ConConsultum oConsulta;
                if (idConsulta == 0)
                {
                    oConsulta = new ConConsultum();
                    oConsulta.FechaRegistro = DateTime.Now;
                }
                else
                {
                    oConsulta = new ConConsultum(idConsulta);
                    // oConsulta.ConConsultaDiagnosticoRecords.Clear(); ??
                    oConsulta.ConConsultaMedicamentoRecords.Clear();
                }

                oConsulta.Fecha = oResultadoConsulta.fecha;
                if (oResultadoConsulta.hora.Length > 0)
                    oConsulta.Hora = oResultadoConsulta.hora;


                if (Request["idTurno"] != null)
                {
                    ///Carolina: Si viene de un turno setea el medico, especialidad, fecha y hora del turno
                    oConsulta.IdTurno = int.Parse(Request["idTurno"].ToString());
                }
                //               
                oConsulta.IdProfesional = oResultadoConsulta.profesional;
                oConsulta.IdEspecialidad = oResultadoConsulta.especialidad;
                oConsulta.IdTipoPrestacion = oResultadoConsulta.tprestacion;

                oConsulta.MotivoConsulta = oResultadoConsulta.motivo;
                oConsulta.InformeConsulta = oResultadoConsulta.informe;
                //oConsulta.ConConsultaDiagnosticoRecords = oResultadoConsulta.diagnosticos; ??
                oConsulta.ConConsultaMedicamentoRecords = oResultadoConsulta.medicamentos;
                //oConsulta.PrimerConsulta = oResultadoConsulta.primerconsulta;
                // Guardamos las cositas que faltaban.
                oConsulta.IdUsuarioRegistro = SSOHelper.CurrentIdentity.Id;
                oConsulta.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                oConsulta.IdPaciente = idPaciente;
                SysPaciente oPaciente = new SysPaciente(idPaciente);
                if (oPaciente != null)
                    oConsulta.IdObraSocial = oPaciente.IdObraSocial;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                    {
                        try
                        {
                            oConsulta.Save();
                            // oConsulta.ConConsultaDiagnosticoRecords.SaveAll(); ??
                            oConsulta.ConConsultaMedicamentoRecords.SaveAll();

                            ts.Complete();
                            Master.Message("La consulta se guardo con exito.", MessageStatus.ok);
                        }
                        catch (Exception ex)
                        {
                            ts.Dispose();
                            List<string> m = new List<string>();
                            while (ex != null)
                            {
                                m.Add(ex.Message);
                                ex = ex.InnerException;
                            }
                            Master.Message(MessageStatus.error, "Error al guardar", m);
                        }
                    }
                }
            }
            else
            {
                Master.Message(oResultadoConsulta.Estado, "Pestaña Consultorio", oResultadoConsulta.mensaje);
            }
        }
    }
}
