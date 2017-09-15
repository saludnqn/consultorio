using System;
using System.Collections.Generic;
using System.Linq;
using DalSic;
using System.Globalization;
using Salud.Security.SSO;
using SubSonic;


namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Control
{
    public partial class EditarControl : System.Web.UI.Page
    {
        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            int idHCPD = SubSonic.Sugar.Web.QueryString<int>("id");
            if (idHCPD > 0)
            {
                cargarDatosDetalle(idHCPD);
            }
        }

        private void cargarDatosDetalle(int idHCPD)
        {
            AprHistoriaClinicaPerinatalDetalle oDetalle = new SubSonic.Select().From(Schemas.AprHistoriaClinicaPerinatalDetalle)
                .Where(AprHistoriaClinicaPerinatalDetalle.Columns.IdHistoriaClinicaPerinatalDetalle).IsEqualTo(idHCPD)
                .And(AprHistoriaClinicaPerinatalDetalle.Columns.Activa).IsEqualTo(true)
                .ExecuteSingle<AprHistoriaClinicaPerinatalDetalle>();
            if (oDetalle != null)
            {
                txtDetalleFecha.Text = oDetalle.Fecha.HasValue ? oDetalle.Fecha.Value.ToShortDateString() : "";
                txtDetalleEdadGestacional.Text = oDetalle.EdadGestacional.HasValue ? oDetalle.EdadGestacional.Value.ToString() : "";
                txtDetallePeso.Text = oDetalle.Peso.HasValue ? oDetalle.Peso.Value.ToString() : "";
                if (!string.IsNullOrEmpty(oDetalle.Pa))
                {
                    string[] pa = oDetalle.Pa.Split('/');
                    if (pa.Count() == 2)
                    {
                        txtDetallePresionArterialSistolica.Text = pa[0];
                        txtDetallePresionArterialDistolica.Text = pa[1];
                    }
                }
                txtDetallePresentacion.Text = oDetalle.Presentacion;
                txtDetalleFrecuenciaCardiacaFetal.Text = oDetalle.Fcf.HasValue ? oDetalle.Fcf.Value.ToString() : "";
                txtDetalleMovimientosFetales.Text = oDetalle.MovimientosFetales;
                txtDetalleProteinuria.Text = oDetalle.Proteinuria;
                txtDetalleAlarmaExamenesTratamientos.Text = oDetalle.AlarmaExamenesTratamientos;
                txtDetallesInicialesTecnico.Text = oDetalle.InicialesTecnico;
                txtDetalleProximaCita.Text = oDetalle.ProximaCita.HasValue ? oDetalle.ProximaCita.Value.ToShortDateString() : "";
                txtDetalleIMC.Text = oDetalle.Imc.HasValue ? oDetalle.Imc.Value.ToString() : "";
                txtDetalleObservaciones.Text = oDetalle.Observaciones;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            List<string> mensaje = new List<string>();

            int idHCPD = SubSonic.Sugar.Web.QueryString<int>("id");
            AprHistoriaClinicaPerinatalDetalle d = new AprHistoriaClinicaPerinatalDetalle();
            if (idHCPD > 0)
            {
                // edito el detalle
                d = new AprHistoriaClinicaPerinatalDetalle(idHCPD);
            }
            // traigo los datos y guardo
            DateTime fechaProximaCita;
            if ((txtDetalleFecha.Text.Length > 0))
            {
                Decimal edadgestacional, peso, imc, alturauterina;
                int fcf;
                d.Fecha = Convert.ToDateTime(txtDetalleFecha.Text);
                if (Decimal.TryParse(txtDetalleEdadGestacional.Text, out edadgestacional))
                {
                    d.EdadGestacional = edadgestacional;
                }
                CultureInfo ci = null;
                ci = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(txtDetallePeso.Text))
                {
                    peso = decimal.Parse(txtDetallePeso.Text.Replace(",", "."), ci);
                    d.Peso = peso;
                }
                else txtDetallePeso.Text = "0";
                if (!string.IsNullOrEmpty(txtDetalleIMC.Text))
                {
                    imc = decimal.Parse(txtDetalleIMC.Text.Replace(",", "."), ci);
                    d.Imc = imc;
                }
                else txtDetalleIMC.Text = "0";
                if (txtDetallePresionArterialSistolica.Text.Length > 0 && txtDetallePresionArterialDistolica.Text.Length > 0)
                {
                    d.Pa = String.Format("{0}/{1}", txtDetallePresionArterialSistolica.Text, txtDetallePresionArterialDistolica.Text);
                }
                if (Decimal.TryParse(txtDetalleAlturaUterina.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out alturauterina))
                    d.AlturaUterina = alturauterina;
                else d.AlturaUterina = 0;

                d.Presentacion = txtDetallePresentacion.Text;
                if (Int32.TryParse(txtDetalleFrecuenciaCardiacaFetal.Text, out fcf))
                    d.Fcf = fcf;
                d.MovimientosFetales = txtDetalleMovimientosFetales.Text;
                d.Proteinuria = txtDetalleProteinuria.Text;
                d.AlarmaExamenesTratamientos = txtDetalleAlarmaExamenesTratamientos.Text;
                d.Observaciones = txtDetalleObservaciones.Text;
                d.InicialesTecnico = txtDetallesInicialesTecnico.Text;
                if (DateTime.TryParse(txtDetalleProximaCita.Text, out fechaProximaCita))
                    d.ProximaCita = fechaProximaCita;
                d.IdEfector = SSOHelper.CurrentIdentity.IdEfector;
                d.Save(SSOHelper.CurrentIdentity.Username);
                Master.Message(MessageStatus.ok, "Los cambios se guardaron con exito.", mensaje);
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            List<string> mensaje = new List<string>();

            int idHCPD = SubSonic.Sugar.Web.QueryString<int>("id");
            AprHistoriaClinicaPerinatalDetalle h = new AprHistoriaClinicaPerinatalDetalle(idHCPD);
            int idPaciente = h.AprHistoriaClinicaPerinatal.IdPaciente;
            //AprHistoriaClinicaPerinatalDetalle op = new AprHistoriaClinicaPerinatalDetalle(idHCPD);

            h.Activa = false;
            h.Save(SSOHelper.CurrentIdentity.Username);
            Response.Write("<script language='javascript'>{ self.close() }</script>");
            //Response.Redirect("~/ConsultaAmbulatoria/ControlPerinatal/Control/?idPaciente=" + idPaciente);
            //Response.Redirect("EditarControl.aspx?=idHistoriaClinicaPerinatal=" + idHCPD);
            //Master.Message(MessageStatus.ok, "Los cambios se guardaron con exito.", mensaje);
        }
    }
}