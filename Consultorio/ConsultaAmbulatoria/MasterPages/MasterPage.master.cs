using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using DalSic;
using Salud.Security.SSO;
using System.Web;
using System.Web.UI;




    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string strsips = SSOHelper.Configuration["Publicacion_Sips"] as string;
        public string strsso = SSOHelper.Configuration["Publicacion_SSO"] as string;
        public string url = HttpContext.Current.Request.QueryString["url"];
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //Obtengo las variables almacenadas para verificar si tiene nuevos mensajes
                //Session["IdRol"] = SSOHelper.CurrentIdentity.StoredVariable["farmacia_rol"].SingleValue ?? 0;
                Page.Header.DataBind();
                
                string strIdHospital = SSOHelper.Configuration["idHospital"] as string;

                if (strIdHospital != "0")
                    lnkStyleSheet.Href = "styleHospital.css";
                else
                    lnkStyleSheet.Href = "style.css";
            }            


            //SysEfector efector = null;
            //efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
            //lblUsr.Text = string.Format(" {0}", SSOHelper.CurrentIdentity.Surname + " " + SSOHelper.CurrentIdentity.FirstName);
            //lblEfector.Text = string.Format("{0}", efector.Nombre);

            //ImgHomeSystem.PostBackUrl = "../" + strsips + "/default.aspx";
            //ImgChangePass.PostBackUrl = "/" + strsso + "/Options.aspx";

            lblUsr.Text = string.Format(" {0}", SSOHelper.CurrentIdentity.Surname + " " + SSOHelper.CurrentIdentity.FirstName);
            lblEfector.Text = string.Format("{0}", SSOHelper.GetNombreEfectorRol(SSOHelper.CurrentIdentity.IdEfectorRol));               
                        
            if (string.IsNullOrEmpty(url))
                url = SSOHelper.Configuration["StartPage"] as string;
          
            //Armo el menú de la Aplicación seleccionada para el efector seleccionado
            List<SSOMenuItem> menu = SSOHelper.GetApplicationMenuByEfector();
            lvMenuSSO.DataSource = menu[0].items;
            lvMenuSSO.DataBind();
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

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/" + strsips + "/default.aspx");
        }

        protected void lnkChangePass_Click(object sender, EventArgs e)
        {            
            Response.Redirect("/" + strsso + "/Options.aspx");
        }

        protected void lnkExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/" + strsso + "/Logout.aspx?relogin=1&url=" + url);
        }        
    }


