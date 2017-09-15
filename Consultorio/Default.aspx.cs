using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DalSic;
using Salud.Security.SSO;
using System.Configuration;
using System.Security.Principal;
using System.Web;

namespace Consultorio
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Creo la variable apps
            //var apps = new List<SSOApplication>();
            
            //string strIdHospital = SSOHelper.Configuration["idHospital"] as string;

            //if (strIdHospital != "0") //Busca a nivel Hospitalario
            //{
            //    apps = SSOHelper.GetAllowedApplicationsHospital();     // busca las aplicaciones a  nivel hospital
            //    lvModulos.GroupItemCount = 3; // SE MUESTRAN LAS APLICACIONES ALIENADAS A LA IZQUIERDA
            //    btnSips.Visible = true; /// se muestra el acceso al sips
            //}
            //else //Busca a nivel Central
            //{
            //    apps = SSOHelper.GetAllowedApplications();
            //}
            
            //string strsips = SSOHelper.Configuration["Publicacion_Sips"] as string;

            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("id"));
            //dt.Columns.Add(new DataColumn("description"));
            //dt.Columns.Add(new DataColumn("urlPage"));
            //dt.Columns.Add(new DataColumn("Image"));
            //dt.Columns.Add(new DataColumn("colorMetro"));

            //foreach (var item in apps)
            //{
            //    DataRow Renglon;
            //    Renglon = dt.NewRow();
            //    Renglon[0] = item.Id;
            //    Renglon[1] = item.Description;
            //    Renglon[2] = item.UrlPage;
            //    Renglon[3] = item.Image;
            //    Renglon[4] = item.ColorMetro;
            //    dt.Rows.Add(Renglon);
            //}

            //lvModulos.DataSource = dt;
            //lvModulos.DataBind();
        }

        //protected void btnSips_Click(object sender, EventArgs e)
        //{

        //    ///////Simula Log In//////
        //    string sessionId = SSOHelper.CurrentIdentity.Id.ToString();

        //    HttpContext.Current.User = new GenericPrincipal(new Salud.Security.SSO.SSOIdentity(new HttpCookie("SSO_AUTH_COOKIE", sessionId)), null);
        //    Response.Redirect("https://www.saludnqn.gob.ar/sips", false);
        //    ////////////////////////////            
        //}


    }
}
