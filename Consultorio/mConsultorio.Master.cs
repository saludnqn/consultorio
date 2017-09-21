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
        public string url = HttpContext.Current.Request.QueryString["url"];

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

                if (string.IsNullOrEmpty(url))
                    url = SSOHelper.Configuration["StartPage"] as string;

                List<SSOMenuItem> menu = SSOHelper.GetApplicationMenuByEfector();
                lvMenuSSO.DataSource = menu[0].items;
                lvMenuSSO.DataBind();
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
            Response.Redirect("~/"+strsso+"/Logout.aspx");
        }
    }
}
