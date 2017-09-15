using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DalSic;
using System.Web.UI;

namespace ConsultaAmbulatoria.Services
{

    public class cie10
    {
        public int id;
        public string codigo;
        public string nombre;
    }
    /// <summary>
    /// Summary description for Cie10
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Cie10 : System.Web.Services.WebService
    {

        [WebMethod]
        public cie10 getCie10(string codigo)
        {
            cie10 oCie10 = new cie10();
            
            /* Formato de Codigo incorrecto*/
            if (codigo.Length == 0)
            {
                oCie10.id = -1;
                oCie10.codigo = "";
                oCie10.nombre="El codigo no puede ser vacio.";
                return oCie10;
            }

            SysCIE10 oCodigo=new SysCIE10(SysCIE10.Columns.Codigo, codigo);
            /* Codigo no encontrado */
            if (oCodigo.IsNew)
            {
                oCie10.id = -1;
                oCie10.codigo = "";
                oCie10.nombre = "Codigo no encontrado";
                return oCie10;
            }
            oCie10.id = oCodigo.Id;
            oCie10.codigo = oCodigo.Codigo;
            oCie10.nombre = oCodigo.Nombre;

            return oCie10;
        }

        [WebMethod]
        public List<cie10> buscarCie10(string cadena)
        {
            List<cie10> oCodigos = new List<cie10>();
            
            SysCIE10Collection oColeccion = new SubSonic.Select().Top("10").From(SysCIE10.Schema.TableName)
                .Where(SysCIE10.Columns.Nombre).Like(cadena).ExecuteAsCollection<SysCIE10Collection>();
            foreach (SysCIE10 oCie10 in oColeccion)
            {
                cie10 temp = new cie10();
                temp.id = oCie10.Id;
                temp.codigo = oCie10.Codigo;
                temp.nombre = oCie10.Nombre;
                oCodigos.Add(temp);
            }
            return oCodigos;
        }
    }
}
