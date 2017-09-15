using System;
using System.Collections.Generic;
using DalSic;
using fastJSON;

namespace ConsultaAmbulatoria.Services
{
    [Serializable]
    public class odontohelper
    {
        public int id { get; set; }
        
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string clasificacion { get; set; }
        
       

    }

    public partial class odonto : System.Web.UI.Page
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
            
            OdoNomencladorCollection oCie10s = new SubSonic.Select()
            .From(Schemas.OdoNomenclador)
            .Where(OdoNomenclador.Columns.Descripcion).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            .Or(OdoNomenclador.Columns.Codigo).Like(String.Format(stringFormat, consulta.Replace('*', '%')))
            //.Or(SysCIE10.Columns.DescripCap).Like(String.Format(stringFormat, consulta.Replace('*', '%')))            
            //.And(SysCIE10.Columns.Cepsap).IsNotNull()
            .OrderAsc(OdoNomenclador.Columns.Descripcion)

            .ExecuteAsCollection<OdoNomencladorCollection>();


            List<odontohelper> codigos = new List<odontohelper>();

            foreach (OdoNomenclador oCie10 in oCie10s)
            {
                odontohelper cie = new odontohelper();
                cie.id = oCie10.IdNomenclador;
                cie.descripcion = oCie10.Descripcion;
                cie.codigo = oCie10.Codigo + " " + oCie10.Descripcion;
                cie.clasificacion = oCie10.Clasificacion;
             
                codigos.Add(cie);
            }
            if (codigos.Count == 0)
            {
                codigos.Add(new odontohelper() { id = -666, descripcion = "No hay resultados", codigo = "" });
            }
            Response.Clear();
            Response.Write(JSON.Instance.ToJSON(codigos));
            Response.Flush();
            Response.End();
        }
    }
}
