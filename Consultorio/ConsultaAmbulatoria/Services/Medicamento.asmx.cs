using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DalSic;

namespace ConsultaAmbulatoria.Services
{


    /// <summary>
    /// Summary description for Medicamento
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Medicamento : System.Web.Services.WebService
    {

        [WebMethod]
        public medicamento getMedicamento(string nombre)
        {
            medicamento oMedicamento = new medicamento();

            /* Formato de Codigo incorrecto*/
            if (nombre.Length == 0)
            {
                oMedicamento.id = -1;
                oMedicamento.rubro = "";
                oMedicamento.nombre = "El codigo no puede ser vacio.";
                return oMedicamento;
            }

            SysMedicamentoCollection oSysMedicamentos = new SubSonic.Select().From(Schemas.SysMedicamento)
                .Where(SysMedicamento.Columns.Nombre).Like(String.Format("%{0}%", nombre)).ExecuteAsCollection<SysMedicamentoCollection>();
            /* Codigo no encontrado */
            if (oSysMedicamentos.Count == 0)
            {
                oMedicamento.id = -1;
                oMedicamento.rubro = "";
                oMedicamento.nombre = "Codigo no encontrado";
                return oMedicamento;
            }
            else
            {
                if (oSysMedicamentos.Count == 1)
                {
                    SysMedicamento oSysMedicamento = oSysMedicamentos.First<SysMedicamento>();
                    oMedicamento.id = oSysMedicamento.IdMedicamento;
                    oMedicamento.nombre = oSysMedicamento.Nombre;
                    oMedicamento.rubro = oSysMedicamento.SysMedicamentoRubro.Nombre;
                }
                else
                {
                    oMedicamento.id = -1;
                    oMedicamento.rubro = "";
                    oMedicamento.nombre = "Mas de un medicamento encontrado, sea mas especifico";
                    return oMedicamento;
                }
            }            

            return oMedicamento;
        }
    }
}
