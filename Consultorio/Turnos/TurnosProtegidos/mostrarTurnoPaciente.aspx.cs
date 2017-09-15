using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultorio.Turnos.TurnosProtegidos
{
    public partial class mostrarTurnoPaciente : System.Web.UI.Page
    {

        // ---------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDatosPaciente.Text = Session["TurnosProtegidos_DatosPaciente"].ToString();
                lblTurnoOtrosDatos.Text = Session["TurnosProtegidos_Turno_OtrosDatos"].ToString();                
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TurnoNuevoDefault.aspx", false);
        }

        // ---------------------------------------------------------------------------------------------------------------------------
    }
}

                        