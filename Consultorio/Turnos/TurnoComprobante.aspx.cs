using System;
using System.Collections.Generic;
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

namespace Consultorio.Turnos
{
    public partial class TurnoComprobante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                setVistaComprobante(int.Parse(Request["idTurno"].ToString()));
        }

        private void setVistaComprobante(int idTurno)
        {
            ConTurno t = new ConTurno(idTurno);
            ConAgenda ag = new ConAgenda(t.IdAgenda);
            SysProfesional p = new SysProfesional(ag.IdProfesional);

            lblComprobante.Text = "Comprobante n° " + idTurno.ToString();
            lblPaciente.Text = t.SysPaciente.NumeroDocumento + " - " + t.SysPaciente.Apellido + " " + t.SysPaciente.Nombre;
            lblComprobanteFecha.Text = Rutinas.getNombreDia(t.Fecha) + " " + t.Fecha.ToString().Substring(0, 10) + " - Concurrir a las " + getHoraPorBloque(t) + " hs.";
            lblComprobanteConsultorio.Text = t.ConAgenda.ConConsultorio.Nombre;

            if (ag.Multiprofesional == true)
            {
                ConAgendaProfesionalCollection listaAgendaProfesional = new SubSonic.Select()
                        .From(Schemas.ConAgendaProfesional).InnerJoin(Schemas.SysProfesional)
                        .Where(ConAgendaProfesional.Columns.IdAgenda).IsEqualTo(ag.IdAgenda)
                        .ExecuteAsCollection<ConAgendaProfesionalCollection>();

                List<string> listaProfesionales = new List<string>();

                foreach (ConAgendaProfesional data in listaAgendaProfesional)
                {
                    listaProfesionales.Add(data.SysProfesional.NombreCompleto + "<br/>");
                }

                lstProfesionales.DataSource = listaProfesionales.ToList();
                lstProfesionales.DataBind();
            }
            else
                lblComprobanteProfesional.Text = p.ApellidoyNombre;            

            if (t.ConAgenda.IdEspecialidad > 0)
                lblComprobanteEspecialidad.Text = t.ConAgenda.SysEspecialidad.Nombre;
            else
                lblComprobanteEspecialidad.Text = t.ConAgenda.ConTipoPrestacion.Nombre;
        }


        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            ConTurno t = new ConTurno(int.Parse(Request["idTurno"].ToString()));

            Response.Redirect("TurnoNuevo.aspx?idPaciente=" + t.IdPaciente, false);
        }


        protected void btnTerminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TurnoNuevoDefault.aspx", false);
        }

        private string getHoraPorBloque(ConTurno t)
        {
            bool bloques = t.ConAgenda.CitarPorBloques;
            string hora = string.Empty;

            if (!bloques)
            {
                hora = t.Hora;
            }
            else
            {
                hora = t.Hora.Substring(0, 2) + ":00";
            }
            return hora;
        }
    }
}