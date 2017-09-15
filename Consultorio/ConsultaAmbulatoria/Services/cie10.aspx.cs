using System;
using System.Collections.Generic;
using DalSic;
using fastJSON;

namespace ConsultaAmbulatoria.Services
{
    [Serializable]
    public class cie10helper
    {
        public int id { get; set; }
        public string causa { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string capitulo { get; set; }
        public int notificacion { get; set; }
       

    }

    public partial class cie10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string consulta = String.IsNullOrEmpty(Request.QueryString["term"]) ? "" : Request.QueryString["term"];


            string tipoBusqueda = Request["tipoBusqueda"].ToString();
            string stringFormat = "{0}%"; 
            if (tipoBusqueda == "1")///que comience con
                stringFormat = "{0}%";
            else /// que contenga
                stringFormat = "%{0}%";
            

            SysCIE10Collection oCie10s = new SubSonic.Select()
            .From(Schemas.SysCIE10)
            .Where(SysCIE10.Columns.Sinonimo).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            .Or(SysCIE10.Columns.Causa).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            .Or(SysCIE10.Columns.Codigo).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            //.Or(SysCIE10.Columns.DescripCap).Like(String.Format(stringFormat, consulta.Replace('*', '%')))            
            //.And(SysCIE10.Columns.Cepsap).IsNotNull()
            .OrderAsc(SysCIE10.Columns.Sinonimo)

            .ExecuteAsCollection<SysCIE10Collection>();
            
          
            List<cie10helper> codigos = new List<cie10helper>();
            
            foreach (SysCIE10 oCie10 in oCie10s)
            {
                cie10helper cie = new cie10helper();
                cie.id = oCie10.Id;
                cie.nombre = oCie10.Sinonimo;
                cie.causa = oCie10.Causa;
                cie.codigo = oCie10.Codigo+ " " + oCie10.Nombre;
                cie.capitulo = oCie10.DescripCap;
             
                codigos.Add(cie);
            }
            if (codigos.Count == 0)
            {
                codigos.Add(new cie10helper() { id = -666, nombre = "No hay resultados", codigo = "", capitulo = "" });
            }
            Response.Clear();
            Response.Write(JSON.Instance.ToJSON(codigos));
            Response.Flush();
            Response.End();
        }
    }
}
