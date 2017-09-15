using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DalSic;

namespace Consultorio.ConsultaAmbulatoria.UserControls
{
    public class ResultadoConsulta
    {
        public MessageStatus Estado = MessageStatus.ok;
        public List<string> mensaje = new List<string>();
        public DateTime? fecha = null;
        public String hora = "";
        public Int32? profesional = null;
        public Int32? especialidad = null;
        public Int32? tprestacion = null;
        public ConConsultaDiagnosticoCollection diagnosticos = new ConConsultaDiagnosticoCollection();
        public ConConsultaMedicamentoCollection medicamentos = new ConConsultaMedicamentoCollection();
        public string motivo = "";
        public string informe = "";
        public Int32? primerconsulta = null;
    }

    public partial class ConsultaAmbulatoria : System.Web.UI.UserControl
    {
        public int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        public int idConsulta
        {
            get { return ViewState["idConsulta"] == null ? 0 : Convert.ToInt32(ViewState["idConsulta"]); }
            set { ViewState["idConsulta"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            txtFechaConsulta.Text = DateTime.Today.ToShortDateString();
            txtHoraConsulta.Text = DateTime.Now.ToShortTimeString();
            if (idPaciente > 0)
            {
                MostrarPrimerConsulta(idPaciente);
                SysUsuario oUsuario = new SysUsuario(Session["idUsuario"]);
                if (oUsuario.IsNew) return;
                getMedicos(oUsuario.SysEfector);
                if (ddlMedico.SelectedValue.Length > 0) getEspecialidades();
                else Response.Redirect("~/ConsultaAmbulatoria/Mensaje.aspx");
                //getTPrestacion();
                CargarTPrestacion();
                if (idConsulta > 0)
                {
                    //Si tengo un id de consulta, cargo los datos para edicion
                    LoadConsulta(idConsulta);
                }

                if (Request["idTurno"] != null)
                {
                    ///Carolina: Si viene de un turno setea el medico, especialidad, fecha y hora del turno
                    ConTurno oTurno = new ConTurno(int.Parse(Request.QueryString["idTurno"]));
                    ConAgenda oAgenda = new ConAgenda(oTurno.IdAgenda);
                    ddlMedico.SelectedValue = oAgenda.IdProfesional.ToString();
                    ddlEspecialidad.SelectedValue = oAgenda.IdEspecialidad.ToString();
                    txtFechaConsulta.Text = oTurno.Fecha.ToShortDateString();
                    txtHoraConsulta.Text = oTurno.Hora;
                }
            }
        }

        private void CargarTPrestacion()
        {
            SubSonic.Select tp = new SubSonic.Select();
            tp.From(ConTipoPrestacion.Schema);
            ddlTPrestacion.DataSource = tp.ExecuteTypedList<ConTipoPrestacion>();
            ddlTPrestacion.DataBind();
        }

        private void LoadConsulta(int id)
        {
            ConConsultum oConsulta = new ConConsultum(id);
            if (!oConsulta.IsNew)
            {
                txtFechaConsulta.Text = oConsulta.Fecha.HasValue ? oConsulta.Fecha.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                txtHoraConsulta.Text = oConsulta.Hora;

                if (oConsulta.IdProfesional.HasValue)
                    ddlMedico.SelectedValue = oConsulta.IdProfesional.Value.ToString();
                if (oConsulta.IdEspecialidad.HasValue)
                    ddlEspecialidad.SelectedValue = oConsulta.IdEspecialidad.Value.ToString();
                //if (oConsulta.PrimerConsulta.HasValue)
                //    ddlPrimerConsulta.SelectedValue = oConsulta.PrimerConsulta.Value ? "true" : "false";
                if (oConsulta.IdTipoPrestacion.HasValue)
                    ddlTPrestacion.SelectedValue = oConsulta.IdTipoPrestacion.Value.ToString();

                ConConsultaDiagnosticoCollection tempDiagSec = new ConConsultaDiagnosticoCollection();
                foreach (ConConsultaDiagnostico oDiagnostico in oConsulta.ConConsultaDiagnosticoRecords)
                {
                    /* if (oDiagnostico.Principal.HasValue && oDiagnostico.Principal.Value)
                     {
                         DiagnosticoPrincipal1.setDiagnosticoPrincipal(oDiagnostico.CODCIE10.Value);
                         if (oDiagnostico.PrimerConsulta.HasValue)
                             ddlPrimerConsulta.SelectedValue = oDiagnostico.PrimerConsulta.Value ? "true" : "false";
                     }
                     else
                     {
                         tempDiagSec.Add(oDiagnostico);
                     } */
                }
                DiagnosticoSecundario1.setDiagnosticos(tempDiagSec);

                txtMotivo.Text = oConsulta.MotivoConsulta;
                txtInforme.Text = oConsulta.InformeConsulta;

            }
        }

        private void MostrarPrimerConsulta(int idPaciente)
        {
            //Se decidio mostrar siempre la opcion de elegir si es primer consulta
            trPrimerConsulta.Visible = true;

            /*ConConsultumCollection oConsultas = new SubSonic.Select()
            .From(Schemas.ConConsultum)
            .Where(ConConsultum.Columns.IdPaciente).IsEqualTo(idPaciente)
            .And(ConConsultum.Columns.Fecha).IsLessThanOrEqualTo(txtFechaConsulta.Text)
            .ExecuteAsCollection<ConConsultumCollection>();

            if (oConsultas.Count == 0)
            {
                trPrimerConsulta.Visible = true;
            }*/
        }

        private void getMedicos(SysEfector oEfector)
        {
            //Obtengo los medicos de acuerdo al hospital del usuario logueado
            ddlMedico.DataSource = SPs.SysGetProfesionalesByEfector(oEfector.IdEfector, 0).GetDataSet();
            ddlMedico.DataTextField = SysProfesional.Columns.NombreCompleto;
            ddlMedico.DataValueField = SysProfesional.Columns.IdProfesional;
            ddlMedico.DataBind();
        }

        private void getEspecialidades()
        {
            SysProfesional oProfesional = new SysProfesional(ddlMedico.SelectedValue);

            if (oProfesional == null) return;
            ddlEspecialidad.DataSource = new SysEspecialidadCollection().Load();
            ddlEspecialidad.DataTextField = SysEspecialidad.Columns.Nombre;
            ddlEspecialidad.DataValueField = SysEspecialidad.Columns.IdEspecialidad;
            ddlEspecialidad.DataBind();
        }

        /*  private void getTPrestacion()
          {
              ConTipoPrestacion oTPrestacion = new ConTipoPrestacion(ddlTPrestacion.SelectedValue);

              ddlTPrestacion.DataSource = new ConTipoPrestacionCollection().Load();
              ddlTPrestacion.DataTextField = ConTipoPrestacion.Columns.Nombre;
              ddlTPrestacion.DataValueField = ConTipoPrestacion.Columns.IdTipoPrestacion;
              ddlTPrestacion.DataBind();
          }*/

        public void SetDiagnosticoPrincipal(int idCIE10)
        {
            DiagnosticoPrincipal1.setDiagnosticoPrincipal(idCIE10);
        }

        public ResultadoConsulta getDatos()
        {
            ResultadoConsulta oResultado = new ResultadoConsulta();

            SysUsuario us = new SysUsuario(Session["idUsuario"]);
            if (us.IsNew)
            {
                oResultado.Estado = MessageStatus.error;
                oResultado.mensaje.Add("No se pudo recuperar el usuario");
                return oResultado;
            }
            if (DiagnosticoPrincipal1.getDiagnostico() > 0)
            {
                /* Fecha Consulta*/
                DateTime fechaConsulta;
                if (DateTime.TryParse(txtFechaConsulta.Text, out fechaConsulta))
                {
                    oResultado.fecha = fechaConsulta;
                }
                else
                {
                    oResultado.Estado = MessageStatus.error;
                    oResultado.mensaje.Add("El formato de la fecha es incorrecto.");
                }
                /* Hora Consulta*/
                if (txtHoraConsulta.Text.Length > 0)
                {
                    oResultado.hora = txtHoraConsulta.Text;
                }
                else
                {
                    oResultado.Estado = MessageStatus.error;
                    oResultado.mensaje.Add("La hora no puede ser vacia.");
                }
                /* Diagnostico principal */
                int idDiagnosticoPrincipal = DiagnosticoPrincipal1.getDiagnostico();
                if (idDiagnosticoPrincipal > 0)
                {
                    ConConsultaDiagnostico oDiagnosticoPrincipal = new ConConsultaDiagnostico();
                    oDiagnosticoPrincipal.CODCIE10 = idDiagnosticoPrincipal;
                    oDiagnosticoPrincipal.Principal = true;
                    oDiagnosticoPrincipal.IdEfector = us.IdEfector;
                    /* Primer Consulta */
                    /* bool primerconsulta = false;
                     if (trPrimerConsulta.Visible && Boolean.TryParse(ddlPrimerConsulta.SelectedValue, out primerconsulta))
                     {
                        oDiagnosticoPrincipal.PrimerConsulta = primerconsulta;
                     }*/
                    oResultado.diagnosticos.Add(oDiagnosticoPrincipal);
                }
                /* Diagnosticos Secundario */
                string[] oDiagnosticos = DiagnosticoSecundario1.getDiagnosticos().Split(',');
                foreach (string sDiagnosticoSecundario in oDiagnosticos)
                {
                    if (sDiagnosticoSecundario.Length > 0)
                    {
                        int idDiagnostico;
                        if (Int32.TryParse(sDiagnosticoSecundario, out idDiagnostico))
                        {
                            ConConsultaDiagnostico oDiagnosticoSecundario = new ConConsultaDiagnostico();
                            oDiagnosticoSecundario.Principal = false;
                            oDiagnosticoSecundario.CODCIE10 = idDiagnostico;
                            oDiagnosticoSecundario.IdEfector = us.IdEfector;
                            oResultado.diagnosticos.Add(oDiagnosticoSecundario);
                        }
                        else
                        {

                            oResultado.Estado = MessageStatus.error;
                            oResultado.mensaje.Add("Unos de los codigo de diagnostico secundario no se reconoce.");
                        }
                    }
                }
                /* Medicamentos */
                //string[] oMedicamentos = Medicamento1.getMedicamentos().Split(',');
                //foreach (string sMedicamentos in oMedicamentos)
                //{
                //    if (sMedicamentos.Length > 0)
                //    {
                //        int idMedicamento;
                //        if (Int32.TryParse(sMedicamentos, out idMedicamento))
                //        {
                //            ConConsultaMedicamento oMedicamento = new ConConsultaMedicamento();
                //            oMedicamento.IdMedicamento = idMedicamento;
                //            oMedicamento.IdEfector = us.IdEfector;
                //            oResultado.medicamentos.Add(oMedicamento);
                //        }
                //        else
                //        {

                //            oResultado.Estado = MessageStatus.error;
                //            oResultado.mensaje.Add("Unos de los codigo de medicamento no se reconoce.");
                //        }
                //    }
                //}
                /* Motivo */
                if (txtMotivo.Text.Length > 0)
                {
                    oResultado.motivo = txtMotivo.Text;
                }
                /* Informe */
                if (txtInforme.Text.Length > 0)
                {
                    oResultado.informe = txtInforme.Text;
                }

                int idProfesional, idEspecialidad, idTPrestacion;
                /* Profesional */
                if (Int32.TryParse(ddlMedico.SelectedValue, out idProfesional))
                {
                    oResultado.profesional = idProfesional;
                }
                /* Especialidad */
                if (Int32.TryParse(ddlEspecialidad.SelectedValue, out idEspecialidad))
                {
                    oResultado.especialidad = idEspecialidad;
                }
                /* Tipo Prestacion */
                if (Int32.TryParse(ddlTPrestacion.SelectedValue, out idTPrestacion))
                {
                    oResultado.tprestacion = idTPrestacion;
                }


                return oResultado;
            }
            else
            {
                //Error
                oResultado.Estado = MessageStatus.error;
                oResultado.mensaje.Add("Debe especificar el Diagnostico Principal");
                return oResultado;
            }
        }
    }
}