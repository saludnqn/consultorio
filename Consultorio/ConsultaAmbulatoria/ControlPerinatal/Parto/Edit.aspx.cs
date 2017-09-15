using System;
using DalSic;
using Salud.Security.SSO;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;


namespace Consultorio.ConsultaAmbulatoria.ControlPerinatal.Parto
{
    public partial class Edit : System.Web.UI.Page
    {        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        private int idHistoriaClinicaPerinatal
        {
            get { return ViewState["idHistoriaClinicaPerinatal"] == null ? 0 : Convert.ToInt32(ViewState["idHistoriaClinicaPerinatal"]); }
            set { ViewState["idHistoriaClinicaPerinatal"] = value; }
        }

        private int idParto
        {
            get { return ViewState["idParto"] == null ? 0 : Convert.ToInt32(ViewState["idParto"]); }
            set { ViewState["idParto"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            CargarCombos();
            txtFechaNacimientoParto.Text = DateTime.Today.ToShortDateString();
            int idPacienteTemp, idHistoriaClinicaPerinatalTemp, idPartoTemp;
            getProfesionales(SSOHelper.CurrentIdentity.IdEfector);

            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPacienteTemp))
            {
                idPaciente = idPacienteTemp;
            }
            if (Int32.TryParse(Request.QueryString["idParto"], out idPartoTemp))
            {
                idParto = idPartoTemp;
                if (idParto > 0)
                    LoadParto(idParto);
            }
            if (Int32.TryParse(Request.QueryString["idHistoriaClinicaPerinatal"], out idHistoriaClinicaPerinatalTemp))
            {
                idHistoriaClinicaPerinatal = idHistoriaClinicaPerinatalTemp;
            }

            //Verifico si tiene alguna Historia perinatal
            AprHistoriaClinicaPerinatal oHistoria = new SubSonic.Select(new string[] { "idHistoriaClinicaPerinatal, idHistoriaClinicaPerinatal" })
           .From(AprHistoriaClinicaPerinatal.Schema)
           .Where(AprHistoriaClinicaPerinatal.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(idHistoriaClinicaPerinatal)
           .And(AprHistoriaClinicaPerinatal.Columns.Activa).IsEqualTo(true)
           .ExecuteSingle<AprHistoriaClinicaPerinatal>();

            //idHistoriaClinicaPerinatalTemp = oHistoria.IdHistoriaClinicaPerinatal;

            //Verifico si tiene datos de Parto y puerperio
            AprPartoProvisorio oParto = new SubSonic.Select()
             .From(AprPartoProvisorio.Schema)
             .Where(AprPartoProvisorio.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(idHistoriaClinicaPerinatal)
             .And(AprPartoProvisorio.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(idHistoriaClinicaPerinatalTemp)
             .ExecuteSingle<AprPartoProvisorio>();
            if (oParto != null)
            {
                LoadParto(oParto.IdParto);
            }
        }

        private void LoadParto(int idParto)
        {
            AprPartoProvisorio oParto = new AprPartoProvisorio(idParto);
            if (!oParto.IsNew)
            {
                LoadPartoProvisorio(oParto);
            }
        }

        private void LoadPartoProvisorio(AprPartoProvisorio oParto)
        {
            ckbParto.Checked = oParto.Parto.HasValue ? oParto.Parto.Value : false;
            ckbAlumbramiento.Checked = oParto.ManejoActivoAlumbramiento.HasValue ? oParto.ManejoActivoAlumbramiento.Value : false;
            txtFechaNacimientoParto.Text = oParto.FechaNacimiento.HasValue ? oParto.FechaNacimiento.Value.ToShortDateString() : "";
            ddlLugarNacimientoParto.SelectedValue = oParto.IdEfectorParto.ToString();
            ddlTerminacionParto.SelectedValue = oParto.IdTerminacionParto.ToString();
            txtEdadGestacional.Text = oParto.EdadGestacional.HasValue ? oParto.EdadGestacional.Value.ToString() : "";
            txtPesoAlNacer.Text = oParto.Peso.HasValue ? oParto.Peso.Value.ToString() : "";
            txtApgar1.Text = oParto.APGAR1.HasValue ? oParto.APGAR1.Value.ToString() : "";
            txtApgar5.Text = oParto.APGAR5.HasValue ? oParto.APGAR5.Value.ToString() : "";
            //datos del puerperio
            txtFecha1Control.Text = oParto.FechaPrimerControlPuerperio.HasValue ? oParto.FechaPrimerControlPuerperio.Value.ToShortDateString() : "";
            txtPrimerControl.Text = oParto.NotaPrimerControlPuerperio;

            txtFecha2Control.Text = oParto.FechaSegundoControlPuerperio.HasValue ? oParto.FechaSegundoControlPuerperio.Value.ToShortDateString() : "";
            txtSegundoControl.Text = oParto.NotaSegundoControlPuerperio;

            txtObservacionPuerperio.Text = oParto.Observaciones;
            ddlProfesional.SelectedValue = oParto.IdProfesional.ToString();
        }

        private void LoadParto(AprPartoProvisorio oParto)
        {
            if (oParto.IsNew) { Master.Message("No se encuentra el objeto a editar.", MessageStatus.alert); return; }

            LoadPartoProvisorio(oParto);
        }

        private void CargarCombos()
        {
            //cargo el combo del Lugar de Nacimiento
            SubSonic.Select ef = new SubSonic.Select(new string[] { "idEfector, nombre" });
            ef.From(SysEfector.Schema);
            //ef.Where(SysEfector.IdTipoEfectorColumn).IsEqualTo(2);
            ef.And(SysEfector.NombreColumn).StartsWith("H");
            ef.OrderAsc("nombre");
            ddlLugarNacimientoParto.DataSource = ef.ExecuteTypedList<SysEfector>();
            ddlLugarNacimientoParto.DataBind();
            ddlLugarNacimientoParto.Items.Insert(0, new ListItem("Seleccione", "0"));

            //cargo el combo de Tipo de Terminacion
            SubSonic.Select ter = new SubSonic.Select(new string[] { "idTerminacionParto, nombre" });
            ter.From(AprTerminacionParto.Schema);
            ter.And(AprTerminacionParto.LocalColumn).IsEqualTo(0);
            ddlTerminacionParto.DataSource = ter.ExecuteTypedList<AprTerminacionParto>();
            ddlTerminacionParto.DataBind();
        }

        private void getProfesionales(int idEfector)
        {
            //Obtengo los medicos de acuerdo al Efector del usuario logueado
            DataTable dt = SPs.SysGetProfesionalesByEfector(SSOHelper.CurrentIdentity.IdEfector, 0).GetDataSet().Tables[0];
            ddlProfesional.DataSource = dt;
            ddlProfesional.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idParto = SubSonic.Sugar.Web.QueryString<int>("idParto");
            int idHistoria;

            //Verifico si tiene alguna Historia perinatal abierta
            AprHistoriaClinicaPerinatal oHistoria = new SubSonic.Select(new string[] { "idHistoriaClinicaPerinatal, idHistoriaClinicaPerinatal" })
           .From(AprHistoriaClinicaPerinatal.Schema)
           .Where(AprHistoriaClinicaPerinatal.Columns.IdHistoriaClinicaPerinatal).IsEqualTo(idHistoriaClinicaPerinatal)
           .And(AprHistoriaClinicaPerinatal.Columns.Activa).IsEqualTo(true)
           .ExecuteSingle<AprHistoriaClinicaPerinatal>();

            idHistoria = oHistoria.IdHistoriaClinicaPerinatal;

            AprPartoProvisorio oParto = oHistoria.AprPartoProvisorioRecords.Count > 0 ? oHistoria.AprPartoProvisorioRecords[0] : new AprPartoProvisorio();

            oParto.IdPaciente = idPaciente;
            oParto.IdHistoriaClinicaPerinatal = idHistoria;

            if (ddlLugarNacimientoParto.SelectedValue != "0")
                oParto.IdEfectorParto = Convert.ToInt32(ddlLugarNacimientoParto.SelectedValue);
            else oParto.IdEfectorParto = 0;

            DateTime fechanacimientoparto;
            if (DateTime.TryParse(txtFechaNacimientoParto.Text, out fechanacimientoparto))
                oParto.FechaNacimiento = fechanacimientoparto;

            oParto.IdTerminacionParto = Convert.ToInt32(ddlTerminacionParto.SelectedValue);

            oParto.Parto = ckbParto.Checked;
            oParto.ManejoActivoAlumbramiento = ckbAlumbramiento.Checked;

            decimal edadgestacionalparto;
            int peso;
            if (Decimal.TryParse(txtEdadGestacional.Text, out edadgestacionalparto))
            {
                oParto.EdadGestacional = edadgestacionalparto;
            }

            CultureInfo ci = null;
            ci = CultureInfo.InvariantCulture;
            if (!string.IsNullOrEmpty(txtPesoAlNacer.Text))
            {
                //peso = decimal.Parse(txtPesoAlNacer.Text.Replace(",", "."), ci);
                peso = Convert.ToInt32(txtPesoAlNacer.Text);
                oParto.Peso = peso;
            }
            else oParto.Peso = 0;

            oParto.APGAR1 = Convert.ToInt32(txtApgar1.Text);
            oParto.APGAR5 = Convert.ToInt32(txtApgar5.Text);

            //datos del puerperio
            DateTime fechaprimercontrol;
            if (DateTime.TryParse(txtFecha1Control.Text, out fechaprimercontrol))
                oParto.FechaPrimerControlPuerperio = fechaprimercontrol;
            oParto.NotaPrimerControlPuerperio = txtPrimerControl.Text;

            DateTime fechasegundocontrol;
            if (DateTime.TryParse(txtFecha2Control.Text, out fechasegundocontrol))
                oParto.FechaSegundoControlPuerperio = fechasegundocontrol;
            oParto.NotaSegundoControlPuerperio = txtSegundoControl.Text;

            oParto.Observaciones = txtObservacionPuerperio.Text;
            oParto.IdProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);

            try
            {
                oParto.Save(SSOHelper.CurrentIdentity.Username);
                Response.Redirect(string.Format("Default.aspx?idHistoriaClinicaPerinatal={0}", oParto.IdHistoriaClinicaPerinatal), false);
            }
            catch (Exception Ex)
            {
                string exception = "";
                while (Ex != null)
                {
                    exception = Ex.Message + "<br>";
                    Ex = Ex.InnerException;
                }
                Master.Message(exception, MessageStatus.error);
            }
        }
    }
}