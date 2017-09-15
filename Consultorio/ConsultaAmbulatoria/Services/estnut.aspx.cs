using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalSic;
using fastJSON;
using Consultorio.Utilidades;

namespace ConsultaAmbulatoria.Services
{
    [Serializable()]
    public class estadonutricional
    {
        public string idEstadoNutricional { get; set; }
        public string nombre { get; set; }
        public string idTalla { get; set; }
        public string nombreTalla { get; set; }
        public string IMC { get; set; }
    }

    public partial class estnut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            estadonutricional oEstadoNutricional = new estadonutricional();
            int idPaciente;
            string tallaTemp = String.IsNullOrEmpty(Request.QueryString["talla"]) ? "" : Request.QueryString["talla"].Replace('.', ',');
            decimal talla, peso;
            decimal IMC;

            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPaciente) &&
                Decimal.TryParse(tallaTemp, out talla)
            && Decimal.TryParse(Request.QueryString["peso"], out peso))
            {
                if (peso > 0 && talla > 0)
                {

                    IMC = (peso) / ((talla / 100) * (talla / 100));
                    oEstadoNutricional.IMC = IMC.ToString();

                    SysPaciente oPaciente = new SysPaciente(idPaciente);
                    if (!oPaciente.IsNew)
                    {
                        DateDifference oEdad = new DateDifference(oPaciente.FechaNacimiento, DateTime.Now);
                        if (oEdad.Years < 2)
                        {
                            //Peso para la edad
                            AprPercentilesPesoEdad oPercentilPeso = new SubSonic.Select()
                                                .From(Schemas.AprPercentilesPesoEdad)
                                                .Where(AprPercentilesPesoEdad.Columns.Sexo).IsEqualTo(oPaciente.IdSexo)
                                                .And(AprPercentilesPesoEdad.Columns.Edad).IsLessThanOrEqualTo(oEdad.FullDays)
                                                .OrderDesc(AprPercentilesPesoEdad.Columns.Edad)
                                                .ExecuteSingle<AprPercentilesPesoEdad>();

                            if (oPercentilPeso != null)
                            {
                                if ((peso * 1000) > oPercentilPeso.P97)
                                {
                                    //Sobrepeso
                                    oEstadoNutricional.idEstadoNutricional = "2";
                                    oEstadoNutricional.nombre = "SOBREPESO";
                                }
                                else if ((peso * 1000) >= oPercentilPeso.P10)
                                {
                                    oEstadoNutricional.idEstadoNutricional = "1";
                                    oEstadoNutricional.nombre = "EUTROFICO";
                                }
                                else if ((peso * 1000) >= oPercentilPeso.P3)
                                {
                                    oEstadoNutricional.idEstadoNutricional = "3";
                                    oEstadoNutricional.nombre = "RIESGO NUTRICIONAL";
                                }
                                else
                                {
                                    oEstadoNutricional.idEstadoNutricional = "4";
                                    oEstadoNutricional.nombre = "BAJO PESO";
                                }
                            }
                            else
                            {
                                oEstadoNutricional.idEstadoNutricional = "-1";
                                oEstadoNutricional.nombre = "No se encontro el percentilo de peso.";
                            }
                        }
                        else
                        {
                            //Mayor de 2: Uso IMC
                            //IMC
                            //Busco en la tabla la fila inmediata anterior de acuerdo a la edad del paciente
                            AprPercentilesIMCEdad oPercentilIMC = new SubSonic.Select()
                            .From(Schemas.AprPercentilesIMCEdad)
                            .Where(AprPercentilesIMCEdad.Columns.Sexo).IsEqualTo(oPaciente.IdSexo)
                            .And(AprPercentilesIMCEdad.Columns.Edad).IsLessThanOrEqualTo(oEdad.FullDays)
                            .OrderDesc(AprPercentilesIMCEdad.Columns.Edad)
                            .ExecuteSingle<AprPercentilesIMCEdad>();

                            if (oPercentilIMC != null)
                            {
                                if (IMC > oPercentilIMC.P97)
                                {
                                    //Sobrepeso
                                    oEstadoNutricional.idEstadoNutricional = "7";
                                    oEstadoNutricional.nombre = "OBESIDAD";
                                }
                                else if (IMC > oPercentilIMC.P85)
                                {
                                    oEstadoNutricional.idEstadoNutricional = "6";
                                    oEstadoNutricional.nombre = "SOBREPESO";
                                }
                                else if (IMC >= oPercentilIMC.P15)
                                {
                                    oEstadoNutricional.idEstadoNutricional = "5";
                                    oEstadoNutricional.nombre = "NORMAL";
                                }
                                else if (IMC >= oPercentilIMC.P3)
                                {
                                    oEstadoNutricional.idEstadoNutricional = "8";
                                    oEstadoNutricional.nombre = "RIESGO NUTRICIONAL";
                                }
                                else
                                {
                                    oEstadoNutricional.idEstadoNutricional = "9";
                                    oEstadoNutricional.nombre = "EMACIACION";
                                }
                            }
                            else
                            {
                                oEstadoNutricional.nombreTalla = "No se encontro el percentilo IMC.";
                            }
                        }

                        //Talla para la edad
                        //Busco en la tabla la fila inmediata anterior de acuerdo a la edad del paciente
                        AprPercentilesLongitudEstaturaEdad oPercentilLongEstatura = new SubSonic.Select()
                        .From(Schemas.AprPercentilesLongitudEstaturaEdad)
                        .Where(AprPercentilesLongitudEstaturaEdad.Columns.Sexo).IsEqualTo(oPaciente.IdSexo)
                        .And(AprPercentilesLongitudEstaturaEdad.Columns.Edad).IsLessThanOrEqualTo(oEdad.FullDays)
                        .OrderDesc(AprPercentilesLongitudEstaturaEdad.Columns.Edad)
                        .ExecuteSingle<AprPercentilesLongitudEstaturaEdad>();
                        if (oPercentilLongEstatura != null)
                        {
                            if (talla > oPercentilLongEstatura.P97)
                            {
                                oEstadoNutricional.idTalla = "1";
                                oEstadoNutricional.nombreTalla = "TALLA ALTA";
                            }
                            else
                                if (talla >= oPercentilLongEstatura.P3)
                                {
                                    oEstadoNutricional.idTalla = "2";
                                    oEstadoNutricional.nombreTalla = "TALLA NORMAL";

                                }
                                else
                                {
                                    oEstadoNutricional.idTalla = "3";
                                    oEstadoNutricional.nombreTalla = "TALLA BAJA";
                                }
                        }
                        else
                        {
                            oEstadoNutricional.nombreTalla = "No se encontro el percentilo talla.";
                        }
                    }
                    else
                    {
                        oEstadoNutricional.idEstadoNutricional = "-1";
                        oEstadoNutricional.nombre = "No se encontro el paciente";
                        oEstadoNutricional.nombreTalla = "ERROR";
                    }
                }
                else
                {
                    oEstadoNutricional.idEstadoNutricional = "-1";
                    oEstadoNutricional.nombre = "Talla o Peso igual o menor a cero.";
                    oEstadoNutricional.nombreTalla = "ERROR";
                }
            }
            else
            {
                oEstadoNutricional.idEstadoNutricional = "-1";
                oEstadoNutricional.nombre = "Los parametros para el calculo no son validos.";
                oEstadoNutricional.nombreTalla = "ERROR";
            }

            Response.Clear();
            Response.Write(JSON.Instance.ToJSON(oEstadoNutricional));
            Response.Flush();
            Response.End();
        }
    }
}
