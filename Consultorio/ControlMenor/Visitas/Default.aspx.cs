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

namespace SIPS.ControlMenor.Visitas
{
    public partial class Default : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (idPaciente > 0)
            {
                // Suponemos que sólo interesan los controles, no las consultas no asociadas con controles.
                rptControles.DataSource = new Select(
                        "idConsulta",
                        "idPaciente",
                        "Fecha",
                        "Hora",
                        "Peso",
                        "Talla",
                        AprControlNiñoSanoEnfermerium.Columns.PerimetroCefalico,
                        AprControlNiñoSano.Schema.TableName + ".IdControlNiñoSano",
                        AprEstadoNutricional.Schema.TableName + ".Nombre as EstadoNutricional",
                        AprTipoLactancium.Schema.TableName + ".Nombre as TipoLactancia",
                        "IdIntervencion",
                        SysProfesional.Schema.TableName + ".Apellido as ApellidosProfesional",
                        SysProfesional.Schema.TableName + ".Nombre as NombresProfesional",
                        SysCIE10.Schema.TableName + ".CODIGO as CodigoCIE10",
                        SysCIE10.Schema.TableName + ".Nombre as NombreDiagnostico"
                    )
                    .From(ConConsultum.Schema)
                    .LeftOuterJoin(ConConsultaDiagnostico.IdConsultaColumn, ConConsultum.IdConsultaColumn)
                    .LeftOuterJoin(SysCIE10.IdColumn, ConConsultaDiagnostico.CODCIE10Column)
                    .LeftOuterJoin(AprControlNiñoSano.IdConsultaColumn, ConConsultum.IdConsultaColumn)
                    .LeftOuterJoin(AprControlNiñoSanoConsultorio.IdControlNiñoSanoColumn, AprControlNiñoSano.IdControlNiñoSanoColumn)
                    .LeftOuterJoin(AprControlNiñoSanoEnfermerium.IdControlNiñoSanoColumn, AprControlNiñoSano.IdControlNiñoSanoColumn)
                    // Nombre del estado nutricional
                    .LeftOuterJoin(AprEstadoNutricional.IdEstadoNutricionalColumn, AprControlNiñoSanoEnfermerium.IdEstadoNutricionalColumn)
                    // Nombre del tipo de lactancia
                    .LeftOuterJoin(AprTipoLactancium.IdTipoLactanciaColumn, AprControlNiñoSanoConsultorio.IdTipoLactanciaColumn)
                    // Nombre del profesional
                    .LeftOuterJoin(SysProfesional.IdProfesionalColumn, ConConsultum.IdProfesionalColumn)
                    .Where(ConConsultum.Columns.IdPaciente).IsEqualTo(idPaciente)
                  // .And(ConConsultaDiagnostico.Columns.Principal).IsEqualTo(true)
                    .OrderDesc(ConConsultum.Columns.Fecha)
                    .ExecuteDataSet();
                rptControles.DataBind();

                CurvasCrecimiento1.graficarCurvas(idPaciente);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaAmbulatoria/SeleccionTurno.aspx?idPaciente=" + idPaciente.ToString());
        }
    }
}