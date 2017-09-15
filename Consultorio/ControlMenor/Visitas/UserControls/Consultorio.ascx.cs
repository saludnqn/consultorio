using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DalSic;
using SubSonic;

namespace SIPS.ControlMenor.Visitas.UserControls
{
    public partial class Consultorio : System.Web.UI.UserControl
    {
        // Identificador del paciente
        private int idPaciente
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        // Identificador de la consulta
        private int idConsulta
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idConsulta"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (idPaciente != 0 && idConsulta != 0)
            {
                ConConsultum oConsulta = new ConConsultum(idConsulta);
                ltFechaConsulta.Text = oConsulta.Fecha.HasValue ? oConsulta.Fecha.Value.ToShortDateString() : "";
                ltHoraConsulta.Text = oConsulta.Hora;
                if (oConsulta.IdProfesional != null)
                {
                    SysProfesional oProfesional = new SysProfesional(oConsulta.IdProfesional);
                    ltMedico.Text = oProfesional.Apellido + ", " + oProfesional.Nombre;
                }
                if (oConsulta.IdEspecialidad != null)
                {
                    SysEspecialidad oEspecialidad = new SysEspecialidad(oConsulta.IdEspecialidad);
                    ltEspecialidad.Text = oEspecialidad.Nombre;
                }
                ltMotivo.Text = oConsulta.MotivoConsulta;
                ltInforme.Text = oConsulta.InformeConsulta;

                // Diagnóstico principal
                SysCIE10 oDiagnosticoPrincipal = new Select()
                    .From(SysCIE10.Schema)
                    .InnerJoin(ConConsultaDiagnostico.CODCIE10Column, SysCIE10.IdColumn)
                    .Where(ConConsultaDiagnostico.IdConsultaColumn).IsEqualTo(oConsulta.IdConsulta)
                    .And(ConConsultaDiagnostico.PrincipalColumn).IsEqualTo(true)
                    .ExecuteSingle<SysCIE10>();
                ltDiagnosticoPrincipal.Text = oDiagnosticoPrincipal != null ? oDiagnosticoPrincipal.Codigo.ToString() + " - " + oDiagnosticoPrincipal.Nombre : "";

                // Diagnósticos secundarios
                rptDiagnosticosSecundarios.DataSource = new Select()
                    .From(SysCIE10.Schema)
                    .InnerJoin(ConConsultaDiagnostico.CODCIE10Column, SysCIE10.IdColumn)
                    .Where(ConConsultaDiagnostico.IdConsultaColumn).IsEqualTo(oConsulta.IdConsulta)
                    .And(ConConsultaDiagnostico.PrincipalColumn).IsEqualTo(false)
                    .ExecuteDataSet();
                rptDiagnosticosSecundarios.DataBind();

                // Medicamentos
                rptMedicamentos.DataSource = new Select()
                    .From(SysMedicamento.Schema)
                    .InnerJoin(ConConsultaMedicamento.IdMedicamentoColumn, SysMedicamento.IdMedicamentoColumn)
                    .Where(ConConsultaMedicamento.IdConsultaColumn).IsEqualTo(oConsulta.IdConsulta)
                    .ExecuteDataSet();
                rptMedicamentos.DataBind();
            }
        }
    }
}