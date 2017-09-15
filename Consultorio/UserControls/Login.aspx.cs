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


namespace Consultorio {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //lblPage.Text = ExtractFilePathFromURL(Request.Url.ToString());
            if (!Page.IsPostBack) {
                txtUsuario.Focus();
                txtContraseña.TabIndex = 1;
            }

            string url = Request.Url.AbsolutePath.ToString();
            string del = string.Empty;

            if (url.Contains("/")) {
                del = "/";
            }
    /*        string[] splitUrl = url.Split(del.ToCharArray());
            lblPage2.Text = splitUrl[1].ToString();
            Literal1.Text = "<br/>" + Request.ApplicationPath;
            
            string algo = string.Empty;
            if (HttpContext.Current.Request.ApplicationPath != "/")
                algo = HttpContext.Current.Request.FilePath.Replace(HttpContext.Current.Request.ApplicationPath, "");
            else
                algo = HttpContext.Current.Request.FilePath;

            Literal2.Text =string.Format("{0} - {1} - {2}",HttpContext.Current.Request.FilePath,HttpContext.Current.Request.ApplicationPath,algo);
            Literal3.Text = "FilePath: " + HttpContext.Current.Request.FilePath;
            Literal4.Text = "ApplicationPath: " + HttpContext.Current.Request.ApplicationPath;
            Literal5.Text = "AppRelativeCurrentExecutionFilePath: " + HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;
            Literal6.Text = "CurrentExecutionFilePath: " + HttpContext.Current.Request.CurrentExecutionFilePath;
            Literal7.Text = "Path: " + HttpContext.Current.Request.Path;

            */

        }

        public static string ExtractFilePathFromURL(string Url) {
            string[] parts = { HttpContext.Current.Request.ApplicationPath };

            //parts = HttpContext.Current.Request.Url.AbsoluteUri.Split(parts, StringSplitOptions.RemoveEmptyEntries);
            parts = HttpContext.Current.Request.Url.AbsolutePath.Split(parts, StringSplitOptions.RemoveEmptyEntries);
          
            string test= string.Empty;
            for (int i = 0; i < parts.Length; i++) {
                test += i.ToString() + "&nbsp;"+ parts[i].ToString() + "<br/> ";
            }
            return test;
        }




        protected void btnIngresar_Click(object sender, EventArgs e) {
            Utility ut = new Utility();
            //Chequeo de usuario y contraseña
            MySecurity.Usuario oUser = new MySecurity.Usuario();
            string perfil = oUser.GetPerfil(txtUsuario.Text, ut.Encrypt(txtContraseña.Text));
            int idUsuario = oUser.GetIdUsuario(txtUsuario.Text);
            if (perfil.Length > 0) // perfil vacio significa que no fue encontrado
			{
                Session["idUsuario"] = idUsuario;
                //Invoca a componente que se encarga del Cache de los datos
                //en este caso de las páginas a las que el perfil tiene acceso
                MySecurity.UserCache.AddPaginasToCache(perfil, MySecurity.Perfiles.GetPaginas(perfil), System.Web.HttpContext.Current);

                // Crea un ticket de Autenticacion de forma manual, 
                // donde guardaremos información que nos interesa
                FormsAuthenticationTicket authTicket =
                        new FormsAuthenticationTicket(2,  // version
                        txtUsuario.Text,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        false,
                        perfil, // guardo el perfil del usuario
                        FormsAuthentication.FormsCookiePath);
                // Encripto el Ticket.
                string crypTicket = FormsAuthentication.Encrypt(authTicket);

                // Creo la Cookie
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, crypTicket);

                Response.Cookies.Add(authCookie);

                // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
                // Para que se puedan usar las Cookies de los HttpModules
                //Response.Redirect( FormsAuthentication.GetRedirectUrl(txtUsuario.Text,false));

                //redirecciono al home
                Response.Redirect("Default.aspx");
                //Response.Write("<Script Language=JavaScript>window.open('Default.aspx','window','toolbar=no,location=no,menubar=0,status,scrollbars,resizable' );</script>");
            } else {
                lblMensaje.Text = "Las credenciales ingresadas no son validas";
            }
        }
    }
}
