using System;
using System.Web.UI.WebControls;
using DalSic;
using Consultorio.Utilidades;
using System.Data;
using SubSonic;

namespace Consultorio.ConsultaAmbulatoria
{
    public partial class SeleccionTurno : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            int idTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp))
            {
                idPaciente = idTemp;
            }

            DataTable oTiposConsulta = new DataTable();
            oTiposConsulta.Columns.Add("Texto", typeof(string));
            oTiposConsulta.Columns.Add("Enabled", typeof(bool));
            oTiposConsulta.Columns.Add("CssClass", typeof(string));
            oTiposConsulta.Columns.Add("Url", typeof(string));

            //Deshabilito opciones de acuerdo al paciente
            SysPaciente oPaciente = new SysPaciente(idTemp);
            if (oPaciente != null)
            {
                //Agrego la consulta ambulatoria comun
               // oTiposConsulta.Rows.Add("Consulta Ambulatoria", true, "ui-button ui-widget ui-state-default ui-corner-all ",
                //    String.Format("~/ConsultaAmbulatoria/?idPaciente={0}", oPaciente.IdPaciente));

                DateDifference oEdad = new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                if (oEdad.Years <= 6)
                {
                    //De acuerdo al paciente, y si es un control
                    //Me fijo en el calendario cual le toca.
                    AprCalendarioVisita oVisitaAnterior =
                        new SubSonic.Select().From(AprCalendarioVisita.Schema)
                        .Where(AprCalendarioVisita.Columns.EdadSemanas)
                        .IsLessThanOrEqualTo(oEdad.Weeks)
                        .OrderDesc(AprCalendarioVisita.Columns.EdadSemanas)
                        .ExecuteSingle<AprCalendarioVisita>();
                    if (oVisitaAnterior != null)
                    {
                        //Reviso si la visita en esa fecha ya fue realizada
                        AprControlNiñoSano oControlAnterior = new SubSonic.Select()
                        .From(AprControlNiñoSano.Schema)
                        .Where(AprControlNiñoSano.Columns.IdCalendarioVisitas).IsEqualTo(oVisitaAnterior.IdCalendarioVisitas)
                        .ExecuteSingle<AprControlNiñoSano>();
                        if (oControlAnterior == null)
                        {
                            //No fue realizada la visita Anterior, Agrego la opcion de realizarla
                            oTiposConsulta.Rows.Add(String.Format("Control del Niño Sano: {0}", oVisitaAnterior.NombreEdad), true, "ui-button ui-widget ui-state-default ui-corner-all",
                                String.Format("~/ConsultaAmbulatoria/ControlMenor/?idPaciente={0}&visita={1}", oPaciente.IdPaciente, oVisitaAnterior.IdCalendarioVisitas));
                        }
                    }

                    AprCalendarioVisita oVisitaSiguiente =
                            new SubSonic.Select().Top("1").From(AprCalendarioVisita.Schema)
                            .Where(AprCalendarioVisita.Columns.EdadSemanas)
                            .IsGreaterThanOrEqualTo(oEdad.Weeks)
                            .OrderAsc(AprCalendarioVisita.Columns.EdadSemanas)
                            .ExecuteSingle<AprCalendarioVisita>();
                    if (oVisitaSiguiente != null)
                    {
                        oTiposConsulta.Rows.Add(String.Format("Control del Niño Sano: {0}", oVisitaSiguiente.NombreEdad), true, "ui-button ui-widget ui-state-default ui-corner-all",
                            String.Format("~/ConsultaAmbulatoria/ControlMenor/?idPaciente={0}&visita={1}", oPaciente.IdPaciente, oVisitaSiguiente.IdCalendarioVisitas));
                    }
                    //debo ingresar los controles de enfermeria
                    //AprControlNiñoSanoEnfermerium oEnfermeria = new SubSonic.Select().From(AprControlNiñoSanoEnfermerium.Schema)
                    //hlEnfermeria.Visible = true;
                    //hlEnfermeria.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlMenor/?idPaciente={0}&enfermeria=1", oPaciente.IdPaciente);
                }
                else
                {
                    //hlEnfermeria.Visible = false;
                    if (oPaciente.SysSexo.Nombre.ToLower() != "femenino")
                    {
                        oTiposConsulta.Rows.Add("Control Perinatal-Parto", false, "ui-button ui-widget ui-state-default ui-corner-all ui-state-disabled",
                            String.Format("~/ConsultaAmbulatoria/?idPaciente={0}", idPaciente));
                        // "");
                    }
                    else
                    {
                        oTiposConsulta.Rows.Add("Control Perinatal-Parto", true, "ui-button ui-widget ui-state-default ui-corner-all ",
                            String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Control/?idPaciente={0}", idPaciente));
                    }
                }
            }

            rptControles.DataSource = oTiposConsulta;
            rptControles.DataBind();

            // Obtengo las ultimas 10 visitas de los controles del menor
            SqlQuery ninio = new Select(
                     "idConsulta",
                     "idPaciente",
                     "Fecha",
                //  "Hora",
                //  "Peso",
                //  "Talla",
                //  AprControlNiñoSanoEnfermerium.Columns.PerimetroCefalico,
                     AprControlNiñoSano.Schema.TableName + ".IdControlNiñoSano",
                //   AprEstadoNutricional.Schema.TableName + ".Nombre as EstadoNutricional",
                //   AprTipoLactancium.Schema.TableName + ".Nombre as TipoLactancia",
                //   "IdIntervencion",
                     SysProfesional.Schema.TableName + ".Apellido as ApellidosProfesional",
                     SysProfesional.Schema.TableName + ".Nombre as NombresProfesional",
                     SysCIE10.Schema.TableName + ".CODIGO as CodigoCIE10",
                     SysCIE10.Schema.TableName + ".Nombre as NombreDiagnostico",
                     SysEfector.Schema.TableName + ".Nombre as Efector"
                 )
                 .Top("10")
                 .From(ConConsultum.Schema)
                 .InnerJoin(ConConsultaDiagnostico.IdConsultaColumn, ConConsultum.IdConsultaColumn)
                 .InnerJoin(SysCIE10.IdColumn, ConConsultaDiagnostico.CODCIE10Column)
                 .InnerJoin(SysEfector.IdEfectorColumn, ConConsultaDiagnostico.IdEfectorColumn)
                ////  .RightOuterJoin(AprHistoriaClinicaPerinatal.IdPacienteColumn, ConConsultum.IdPacienteColumn)
                 .LeftOuterJoin(AprControlNiñoSano.IdConsultaColumn, ConConsultum.IdConsultaColumn)
                 .LeftOuterJoin(AprControlNiñoSanoConsultorio.IdControlNiñoSanoColumn, AprControlNiñoSano.IdControlNiñoSanoColumn)
                 .LeftOuterJoin(AprControlNiñoSanoEnfermerium.IdControlNiñoSanoColumn, AprControlNiñoSano.IdControlNiñoSanoColumn)
                // Nombre del estado nutricional
                //  .LeftOuterJoin(AprEstadoNutricional.IdEstadoNutricionalColumn, AprControlNiñoSanoEnfermerium.IdEstadoNutricionalColumn)
                // Nombre del tipo de lactancia
                //  .LeftOuterJoin(AprTipoLactancium.IdTipoLactanciaColumn, AprControlNiñoSanoConsultorio.IdTipoLactanciaColumn)
                // Nombre del profesional
                 .LeftOuterJoin(SysProfesional.IdProfesionalColumn, ConConsultum.IdProfesionalColumn)
                 .Where(ConConsultum.Columns.IdPaciente).IsEqualTo(oPaciente.IdPaciente)
                 .And(ConConsultaDiagnostico.Columns.Principal).IsEqualTo(true)
                 .OrderDesc(ConConsultum.Columns.Fecha);

            rptVisitas.DataSource = ninio.ExecuteDataSet();
            rptVisitas.DataBind();

            //consulta que trae los datos de los controles de enfermeria
            DataTable dt = SPs.AprGetControlEnfermeria(idPaciente).GetDataSet().Tables[0];

           // rptEnfermeria.DataSource = dt;
           // rptEnfermeria.DataBind();
        }

        protected void rptControles_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "RealizarConsulta")
            {
                if (e.CommandArgument.ToString() == "")
                {
                    Master.Message("Hay un error al recuperar la ubicacion del comando.", MessageStatus.alert);
                }
                else
                {
                    Response.Redirect(e.CommandArgument.ToString());
                }
            }
            else
            {
                Master.Message("No se reconoce la accion que se quiere realizar", MessageStatus.alert);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Paciente/PacienteView.aspx?id={0}", idPaciente));
        }

        protected void rptVisitas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //De acuerdo al diagnostico, cambio el link de edicion
            DataRowView oRow = e.Item.DataItem as DataRowView;
            HyperLink hlEditar = e.Item.FindControl("hlEditar") as HyperLink;
            HyperLink hlVer = e.Item.FindControl("hlVer") as HyperLink;

            if (oRow != null && hlEditar != null && hlVer != null)
            {
                string idConsulta = oRow["idConsulta"].ToString();
                string idControlNiñoSano = oRow["idControlNiñoSano"].ToString();
                string codigo = oRow["CodigoCIE10"].ToString();
                switch (codigo)
                {
                    case "Z34.9"://Control de embarazo
                        hlVer.Visible = false;
                        hlEditar.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlPerinatal/Control/?idPaciente={0}&idConsulta={1}",
                            idPaciente, idConsulta);
                        break;
                    case "Z00.1"://Control de salud de rutina del niño
                        hlVer.NavigateUrl = String.Format("View.aspx?idPaciente={0}&idControl={1}&idConsulta={2}", idPaciente, idControlNiñoSano, idConsulta);
                        hlEditar.NavigateUrl = String.Format("~/ConsultaAmbulatoria/ControlMenor/?idPaciente={0}&idConsulta={1}",
                            idPaciente, idConsulta);
                        break;
                    default://Otras Consultas
                        hlVer.Visible = false;
                        hlEditar.NavigateUrl = String.Format("~/ConsultaAmbulatoria/?idPaciente={0}&idConsulta={1}",
                            idPaciente, idConsulta);
                        break;
                }
            }
        }
    }
}
