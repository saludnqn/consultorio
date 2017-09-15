using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using SubSonic;

namespace SIPS.ControlMenor.Reportes.Visitas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            txtRango.Text = DateTime.Today.ToShortDateString();
            rptControles.DataSource = null;
            rptControles.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtRango.Text.Length > 0)
            {
                string rango = txtRango.Text;
                string inicio, fin;
                if (rango.IndexOf('-') > 0)
                {
                    //es un rango
                    inicio = rango.Split('-')[0].Trim();
                    fin = rango.Split('-')[1].Trim();
                }
                else
                {
                    inicio = rango.Trim();
                    fin = rango.Trim();
                }
                DateTime desde, hasta;
                if (DateTime.TryParse(inicio + " 00:00:00", out desde) && DateTime.TryParse(fin + " 23:59:59", out hasta))
                {
                    rptControles.DataSource = new Select(
                        "idConsulta",
                        "Fecha",
                        "Hora",
                        Schemas.SysPaciente + "." + SysPaciente.Columns.Apellido + " as ApellidosPaciente",
                        Schemas.SysPaciente + "." + SysPaciente.Columns.Nombre + " as NombresPaciente",
                        Schemas.SysPaciente + "." + SysPaciente.Columns.FechaNacimiento,
                        AprControlNiñoSanoEnfermerium.Columns.Peso,
                        AprControlNiñoSanoEnfermerium.Columns.Talla,
                        AprControlNiñoSanoEnfermerium.Columns.PerimetroCefalico,
                        SysProfesional.Schema.TableName + ".Apellido as ApellidosProfesional",
                        SysProfesional.Schema.TableName + ".Nombre as NombresProfesional"
                    )
                    .From(ConConsultum.Schema)
                    .InnerJoin(AprControlNiñoSano.IdConsultaColumn, ConConsultum.IdConsultaColumn)
                    .InnerJoin(SysPaciente.IdPacienteColumn, ConConsultum.IdPacienteColumn)
                    .LeftOuterJoin(AprControlNiñoSanoEnfermerium.IdControlNiñoSanoColumn, AprControlNiñoSano.IdControlNiñoSanoColumn)
                        // Nombre del profesional
                    .LeftOuterJoin(SysProfesional.IdProfesionalColumn, ConConsultum.IdProfesionalColumn)
                    .Where(ConConsultum.Columns.Fecha).IsGreaterThanOrEqualTo(desde)
                    .And(ConConsultum.Columns.Fecha).IsLessThanOrEqualTo(hasta)
                    .ExecuteDataSet();
                }
                else
                {
                    rptControles.DataSource = null;
                }
            }
            else
            {
                rptControles.DataSource = null;
            }
            rptControles.DataBind();
        }
    }
}
