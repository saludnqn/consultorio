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
using Salud.Security.SSO;

namespace Consultorio
{
    public partial class Principal : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["modulo"] = "Consultorio";

            SSOHelper.Authenticate();

            if (SSOHelper.CurrentIdentity == null)
            {
                SSOHelper.RedirectToSSOPage("Login.aspx", Request.Url.ToString());
            }
            else
            {

                SysEfector oEfector = new SysEfector(SSOHelper.CurrentIdentity.IdEfector);
                if (oEfector.IdTipoEfector < 4)///eFECTORES
                {
                    gvEspecialidad.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, 1).GetDataSet();
                    gvEspecialidad.DataBind();

                    gvPrestaciones.DataSource = SPs.SysGetEspecialidadByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet();
                    gvPrestaciones.DataBind();

                    pnlIndicadores.Visible = false;
                    pnlPrincipal.Visible = true;
                }
                else  //Zonas sanitarias y nivel central
                {
                    pnlIndicadores.Visible = true;
                    pnlPrincipal.Visible = false;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=nota tecnica gestion de turnos.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("nota tecnica gestion de turnos.pdf");
            Response.End();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=Procedimiento Solicitud y entrega de turnos para consulta ambulatoria en CS.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("Procedimiento Solicitud y entrega de turnos para consulta ambulatoria en CS.pdf");
            Response.End();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=Informe final de consultoria.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("Informe final de consultoria.pdf");
            Response.End();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=Manual del Usuario Agenda y Turno.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("Manual del Usuario Agenda y Turno.pdf");
            Response.End();

        }

        protected void lnkPlanillaConsultaAmbulatoria_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=ModeloPlanillaConsultorio.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("ModeloPlanillaConsultorio.pdf");
            Response.End();


        }

        protected void lnkPlanillaSaludMental_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=ModeloPlanillaSaludMental.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("ModeloPlanillaSaludMental.pdf");
            Response.End();
        }

        protected void lnkPlanillaOdontologia_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=ModeloPlanillaOdontologia.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("ModeloPlanillaOdontologia.pdf");
            Response.End();
        }
    }
}
