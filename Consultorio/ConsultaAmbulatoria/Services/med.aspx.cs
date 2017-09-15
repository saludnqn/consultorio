using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using fastJSON;

namespace ConsultaAmbulatoria.Services
{
    [Serializable()]
    public class medicamento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string rubro { get; set; }
    }

    public partial class med : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string consulta = String.IsNullOrEmpty(Request.QueryString["term"]) ? "" : Request.QueryString["term"];

            SysMedicamentoCollection oMedicamentos = new SubSonic.Select().Top("20")
                .From(Schemas.SysMedicamento)
                .Where(SysMedicamento.Columns.Nombre)
                .Like(String.Format("%{0}%", consulta.Replace('*', '%')))
                .And(SysMedicamento.Columns.Nombre).Like("%Vacun%") //agregado
                .ExecuteAsCollection<SysMedicamentoCollection>();

            List<medicamento> meds = new List<medicamento>();

            foreach (SysMedicamento oMed in oMedicamentos)
            {
                medicamento med = new medicamento();
                med.id = oMed.IdMedicamento;
                med.nombre = oMed.Nombre;
                med.rubro = oMed.SysMedicamentoRubro != null ? oMed.SysMedicamentoRubro.Nombre : "-";
                meds.Add(med);
            }
            if (meds.Count == 0)
            {
                meds.Add(new medicamento() { id = -666, nombre = "No hay resultados", rubro = "" });
            }
            Response.Clear();
            Response.Write(JSON.Instance.ToJSON(meds));
            Response.Flush();
            Response.End();
        }
    }
}
