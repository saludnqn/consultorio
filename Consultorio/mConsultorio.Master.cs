using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DalSic;
using Salud.Security.SSO;
using System.Web;
using System.Configuration;

namespace Consultorio
{
    public partial class mConsultorio : System.Web.UI.MasterPage
    {
        public string strsips = SSOHelper.Configuration["Publicacion_Sips"] as string;
        public string strsso = SSOHelper.Configuration["Publicacion_SSO"] as string;

        protected void Page_Load(object sender, EventArgs e)
        {
            SSOHelper.Authenticate();

            if (SSOHelper.CurrentIdentity == null)
            {
                SSOHelper.RedirectToSSOPage("Login.aspx", Request.Url.ToString());
            }
            else
            {
                lblUsr.Text = string.Format(" {0}", SSOHelper.CurrentIdentity.Surname + " " + SSOHelper.CurrentIdentity.FirstName);
                lblEfector.Text = string.Format("{0}", SSOHelper.GetNombreEfectorRol(SSOHelper.CurrentIdentity.IdEfectorRol));

                List<SSOMenuItem> menu = SSOHelper.GetApplicationMenuByEfector();
                lvMenuSSO.DataSource = menu[0].items;
                lvMenuSSO.DataBind();

                lblUsr.Text = string.Format("{0}, {1}", SSOHelper.CurrentIdentity.Surname, SSOHelper.CurrentIdentity.FirstName);
                lblEfector.Text = string.Format("{0}", SSOHelper.GetNombreEfectorRol(SSOHelper.CurrentIdentity.IdEfectorRol));
                ImgHomeSystem.PostBackUrl = "~/../sips/default.aspx";

                ImgChangePass.PostBackUrl = "/" + strsso + "/Options.aspx";
                //ImgChangePass.PostBackUrl = "/sso/Options.aspx";

                string url = HttpContext.Current.Request.QueryString["url"];
                if (string.IsNullOrEmpty(url))
                    url = SSOHelper.Configuration["StartPage"] as string;

                ImgExit.PostBackUrl = "/" + strsso + "/Logout.aspx?relogin=1&url=" + url;// +"/" + strsips;
                //ImgExit.PostBackUrl = "/sso/Logout.aspx?relogin=1&url=" + url + "/sips";
            }
        }

        protected void lvMenuSSO_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListView lv = (ListView)e.Item.FindControl("lvSubMenuSSO");
                if (lv != null)
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    if (dataItem != null)
                    {
                        SSOMenuItem node = (SSOMenuItem)dataItem.DataItem;
                        List<SSOMenuItem> dv = node.items;
                        if (dv.Count > 0)
                        {
                            lv.DataSource = dv;
                            lv.DataBind();
                            HyperLink hl = (HyperLink)lv.Parent.FindControl("hlMenu2");
                            if (hl != null)
                                hl.Text = node.text;
                        }
                        else
                        {
                            lv.Visible = false;
                        }
                    }
                }
            }
        }

        protected void hkbSesion_Click(object sender, EventArgs e)
        {

            string strsso = SSOHelper.Configuration["Publicacion_SSO"] as string;


            //Response.Redirect("~/SSO/Logout.aspx");
            Response.Redirect("~/" + strsso + "/Logout.aspx");
        }
    }
}
