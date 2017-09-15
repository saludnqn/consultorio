using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using DalSic;
using Salud.Security.SSO;

namespace Consultorio
{
    public partial class Global : System.Web.UI.MasterPage
    {
        //public SSOHelper.CurrentIdentity.Username Usuario = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            SysEfector efector = null;
            efector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);

            lblUsr.Text = string.Format("{0}, {1}", SSOHelper.CurrentIdentity.Surname, SSOHelper.CurrentIdentity.FirstName);
            lblEfector.Text = string.Format("{0}", efector.Nombre);
            Img1.PostBackUrl = "/Sips/Default.aspx";
            Img2.PostBackUrl = "/SSO/Options.aspx";
            string url = HttpContext.Current.Request.QueryString["url"];
            if (string.IsNullOrEmpty(url))
                url = SSOHelper.Configuration["StartPage"] as string;
            Img3.PostBackUrl = "/SSO/Logout.aspx?relogin=1&url=" + url + "/sips";

            ////Armo el menú de la Aplicación seleccionada para el efector seleccionado
            //List<SSOMenuItem> menu = SSOHelper.GetApplicationMenuByEfector();
        //    lvMenuSSO.DataSource = menu[0].items;
        //    lvMenuSSO.DataBind();
        }

        //protected void lvMenuSSO_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListViewItemType.DataItem)
        //    {
        //        ListView lv = (ListView)e.Item.FindControl("lvSubMenuSSO");
        //        if (lv != null)
        //        {
        //            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
        //            if (dataItem != null)
        //            {
        //                SSOMenuItem node = (SSOMenuItem)dataItem.DataItem;
        //                List<SSOMenuItem> dv = node.items;
        //                if (dv.Count > 0)
        //                {
        //                    lv.DataSource = dv;
        //                    lv.DataBind();
        //                    HyperLink hl = (HyperLink)lv.Parent.FindControl("hlMenu2");
        //                    if (hl != null)
        //                        hl.Text = node.text;
        //                }
        //                else
        //                {
        //                    lv.Visible = false;
        //                }
        //            }
        //        }
        //    }
        //}

        protected void hkbSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SSO/Logout.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaAmbulatoria/BuscarPaciente.aspx");
        }

        protected void btnConsolidado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaAmbulatoria/ControlPerinatal/PanelControl/default.aspx");
        }
    }
}
