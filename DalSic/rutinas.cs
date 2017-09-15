using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace DalSic {
    public class Rutinas {

        #region " Manejo de fechas "
            public enum DateInterval {
                Day,
                DayOfYear,
                Hour,
                Minute,
                Month,
                Quarter,
                Second,
                Weekday,
                WeekOfYear,
                Year
            }

            public static long DateDiff(DateInterval interval, DateTime dt1, DateTime dt2) {
                /// devuelve diferencia entre dos fechas expresada en el tipo de intervalo solicitado con primer día de semana por sistema <<>>//
                return DateDiff(interval, dt1, dt2, System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
            }

            public static long DateDiff(DateInterval interval, DateTime dt1, DateTime dt2, DayOfWeek eFirstDayOfWeek) {
                /// devuelve diferencia entre dos fechas expresada en el tipo de intervalo solicitado con primer día de semana especificado <<>>//

                if (interval == DateInterval.Year)
                    return dt2.Year - dt1.Year;

                if (interval == DateInterval.Month)
                    return (dt2.Month - dt1.Month) + (12 * (dt2.Year - dt1.Year));

                TimeSpan ts = dt2 - dt1;

                if (interval == DateInterval.Day || interval == DateInterval.DayOfYear)
                    return Round(ts.TotalDays);

                if (interval == DateInterval.Hour)
                    return Round(ts.TotalHours);

                if (interval == DateInterval.Minute)
                    return Round(ts.TotalMinutes);

                if (interval == DateInterval.Second)
                    return Round(ts.TotalSeconds);

                if (interval == DateInterval.Weekday) {
                    return Round(ts.TotalDays / 7.0);
                }

                if (interval == DateInterval.WeekOfYear) {
                    while (dt2.DayOfWeek != eFirstDayOfWeek)
                        dt2 = dt2.AddDays(-1);
                    while (dt1.DayOfWeek != eFirstDayOfWeek)
                        dt1 = dt1.AddDays(-1);
                    ts = dt2 - dt1;
                    return Round(ts.TotalDays / 7.0);
                }

                if (interval == DateInterval.Quarter) {
                    double d1Quarter = GetQuarter(dt1.Month);
                    double d2Quarter = GetQuarter(dt2.Month);
                    double d1 = d2Quarter - d1Quarter;
                    double d2 = (4 * (dt2.Year - dt1.Year));
                    return Round(d1 + d2);
                }

                return 0;
            }

            private static int GetQuarter(int nMonth) {
                if (nMonth <= 3)
                    return 1;
                if (nMonth <= 6)
                    return 2;
                if (nMonth <= 9)
                    return 3;
                return 4;
            }

            private static long Round(double dVal) {
                if (dVal >= 0)
                    return (long)Math.Floor(dVal);
                return (long)Math.Ceiling(dVal);
            }

            public static int getNroDia(DateTime f) {
                // <<>> devuelve el nro. de día de semana de la fecha especificada <<>> //
                int dia = 0;
                switch (f.DayOfWeek) {
                    case DayOfWeek.Monday:
                        dia = 1;
                        break;
                    case DayOfWeek.Tuesday:
                        dia = 2;
                        break;
                    case DayOfWeek.Wednesday:
                        dia = 3;
                        break;
                    case DayOfWeek.Thursday:
                        dia = 4;
                        break;
                    case DayOfWeek.Friday:
                        dia = 5;
                        break;
                    case DayOfWeek.Saturday:
                        dia = 6;
                        break;
                    case DayOfWeek.Sunday:
                        dia = 7;
                        break;
                }
                return dia;
            }

            public static string getNombreDia(DateTime dateTime) {
                CultureInfo ci = new CultureInfo("es-AR");
                return ci.DateTimeFormat.GetDayName(dateTime.DayOfWeek).ToString();
            }
        #endregion

        #region " Manejo de datos "
            public static DataSet getDataSetOrdenado(DataSet dt, string campoOrden) {
                /// clono tabla desde un dataview ordenado a otra temporal y la asigno al Dataset que devuelvo <<>> //
                DataSet dtOrdenado = new DataSet();

                for (int tabla = 0; tabla < dt.Tables.Count -1 ; tabla++) {
                    DataView dv = dt.Tables[tabla].AsDataView();
                    DataTable dtTable = new DataTable();

                    dv.Sort = campoOrden;
                    dtTable = dt.Tables[tabla].Clone();
                    for (int i = 0; i < dv.Count - 1; i++) { dtTable.ImportRow(dv[i].Row); }
                    dtOrdenado.Tables.Add(dtTable);
                }
                return dtOrdenado;
            }

            public static DataTable getDataTableOrdenado(DataTable dTable, string campoOrden) {
                /// clono tabla desde un dataview ordenado a otra temporal y la asigno al datatable que devuelvo <<>> //
                DataTable dtImport = new DataTable();
                DataView dv = dTable.AsDataView();
                
                dv.Sort = campoOrden;
                dtImport = dTable.Clone();
                for (int i = 0; i < dv.Count; i++) { dtImport.ImportRow(dv[i].Row); }

                return dtImport;
            }
        #endregion

        #region  "Manejo de números"
            public static int porcentaje(int cantidad, int total) {
                int calculo = 0;
                if (total > 0 & cantidad > 0) { calculo = cantidad * 100 / total; }
                return calculo;
            }
        #endregion
        
        #region  "Manejo de Cadenas"
            public static string Capitalizar(string value) {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length == 0)
                    return value;

                System.Text.StringBuilder result = new System.Text.StringBuilder(value);
                result[0] = char.ToUpper(result[0]);
                for (int i = 1; i < result.Length; ++i) {
                    if (char.IsWhiteSpace(result[i - 1]))
                        result[i] = char.ToUpper(result[i]);
                    else
                        result[i] = char.ToLower(result[i]);
                }
                return result.ToString();
            }
        #endregion

        #region " Otros "
            public static void MessageBox(string input, Page page) {
                string strScript;
                strScript = @"<script language=javascript> ";
                strScript += "alert('" + input + "')";
                strScript += @"</script>";
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), "clientScript", strScript);
            }

            public static bool MessageConfirm(string input, Page page) { 
                string strScript;
                strScript = @"<script language='javascript' type=text/javascript> ";
                strScript += "var hdn1 = document.getElementsByName('ctl00$Main$hdn'); ";
                strScript += " var savresult=confirm('" + input + "'); ";
                strScript += " if(savresult==1) ; ";
                strScript += " { hdn1.value='1'; ";
                strScript += " alert(hdn1.value); }";
                strScript += " else ";
                strScript += " { hdn1.value='0'; ";
                strScript += " alert(hdn1.value); } ";
                strScript += @"</script>";
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Confirm", strScript);
                return true;
            }

        #endregion

            //public static string diadelaSemana(DateTime fecha)
            //{
            //    string dia = "";
            //    switch ((int) fecha.DayOfWeek)
            //    {
            //        case 0: dia = "Domingo"; break;
            //        case 1: dia = "Lunes"; break;
            //        case 2: dia = "Martes"; break;
            //        case 3: dia = "Miercoles"; break;
            //        case 4: dia = "Jueves"; break;
            //        case 5: dia = "Viernes"; break;
            //        case 6: dia = "Sabado"; break;

            //    }
            //    return dia;
            //}
    }
}
