using System;
using DalSic;
using SubSonic;
using SIPS.Utilidades;
using Salud.Security.SSO;

namespace SIPS.ControlMenor.DatosMadre
{
    public partial class Default : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        /*  private bool PermitirGuardar
          {
              get { return ViewState["permitirGuardar"] == null ? false : Convert.ToBoolean(ViewState["permitirGuardar"]); }
              set { ViewState["permitirGuardar"] = value; }
          } */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (idPaciente != 0)
                {
                    SysParentesco Madre = new Select()
                        .From(SysParentesco.Schema)
                        .Where(SysParentesco.Columns.IdPaciente).IsEqualTo(idPaciente)
                        .And(SysParentesco.Columns.TipoParentesco).IsEqualTo("Madre")
                        .ExecuteSingle<SysParentesco>();
                    if (Madre != null)
                    {
                        ltDocumento.Text = "DU: " + Madre.NumeroDocumento.ToString();
                        ltNombre.Text = Madre.Apellido + ", " + Madre.Nombre;
                        if (Madre.FechaNacimiento != Convert.ToDateTime("01/01/1900"))
                        {
                            ltEdad.Text = new DateDifference(DateTime.Today, Madre.FechaNacimiento).ToString();
                            ltFechaNacimiento.Text = Madre.FechaNacimiento.ToShortDateString();
                        }
                        else
                        {
                            ltEdad.Text = "--";
                            ltFechaNacimiento.Text = "--";
                        }

                        ltNacionalidad.Text = Madre.SysPai.Nombre;
                        ddlNivelInstruccion.SelectedValue = Madre.IdNivelInstruccion.ToString();
                        ddlSituacionLaboral.SelectedValue = Madre.IdSituacionLaboral.ToString();
                        ddlProfesion.SelectedValue = Madre.IdProfesion.ToString();
                        ltLugarNacimiento.Text = Madre.SysProvincium.Nombre;

                        //cargo los otros datos
                        SubSonic.Select s = new Select();
                        s.From(AprCMOtrosDato.Schema);
                        s.Where("idPaciente").IsEqualTo(idPaciente);
                        AprCMOtrosDato o = s.ExecuteSingle<AprCMOtrosDato>();

                        if (o != null)
                        {
                            if (o.Trabaja == true) rblTrabaja.SelectedValue = "1";
                            else rblTrabaja.SelectedValue = "0";
                            if (o.CantidadHoras == null) txtHoras.Text = "";
                            else txtHoras.Text = o.CantidadHoras.ToString();
                            if (o.AsistenciaEconomica == true) rblAsistencia.SelectedValue = "1";
                            else rblAsistencia.SelectedValue = "0";
                        }
                    }
                    else
                    {
                        setDatosComplementarios.Attributes["class"] += " ui-helper-hidden";
                        setDatosPersonales.Attributes["class"] += " ui-helper-hidden";
                        setOtrosDatos.Attributes["class"] += " ui-helper-hidden";
                        Master.Message("No se han registrado datos de la madre.", MessageStatus.alert);
                    }
                    SysPaciente oPaciente = new SysPaciente(idPaciente);
                    ltDomicilio.Text = oPaciente.Calle + " " + oPaciente.Numero + ", Piso: " + oPaciente.Piso + " Dpto: " + oPaciente.Departamento + " - " + oPaciente.SysLocalidad.Nombre;
                }
            }

            // setPermitirGuardar(idPaciente);
        }

        /*  private void setPermitirGuardar(int idPaciente)
          {
              SysPaciente oPaciente = new SysPaciente(idPaciente);
              if (oPaciente != null)
              {
                  DateDifference oDateDifference = new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                  PermitirGuardar = oDateDifference.Years <= 6;
              }
          } */

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Paciente/PacienteEdit.aspx?id={0}", idPaciente));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
                //id de la tabla Sys_Paciente
                int idPaciente = SubSonic.Sugar.Web.QueryString<int>("idPaciente");
                if (idPaciente != 0)
                {
                    AprCMOtrosDato o = new AprCMOtrosDato();
                    SubSonic.Select s = new Select();
                    s.From(AprCMOtrosDato.Schema);
                    s.Where("idPaciente").IsEqualTo(idPaciente);
                    o = s.ExecuteSingle<AprCMOtrosDato>();

                    if (o == null)
                    {
                        o = new AprCMOtrosDato();
                    }

                    if (rblTrabaja.SelectedValue == "1") o.Trabaja = true;
                    else o.Trabaja = false;
                    if (!string.IsNullOrEmpty(txtHoras.Text)) o.CantidadHoras = Convert.ToInt32(txtHoras.Text);
                    else o.CantidadHoras = 0;
                    if (rblAsistencia.SelectedValue == "1") o.AsistenciaEconomica = true;
                    else o.AsistenciaEconomica = false;
                    o.IdPaciente = idPaciente;
                    // aca debo guardar el id que no es facil saber cual es

                    if (o.IdControlNiñoSano == null)
                    { // nuevo
                        SubSonic.Select ss = new Select();
                        ss.From(AprControlNiñoSano.Schema)
                        .InnerJoin(ConConsultum.Schema)
                        .Where("IdPaciente").IsEqualTo(idPaciente);

                        AprControlNiñoSano cns = ss.ExecuteSingle<AprControlNiñoSano>();
                        if (cns != null)
                            o.IdControlNiñoSano = cns.IdControlNiñoSano;
                        else
                            o.IdControlNiñoSano = 0;
                    }
                    //debo guardar los datos extras de la madre
                    //traigo los datos del primer pariente que encuentra
                    SysPaciente pac = new SysPaciente(idPaciente);
                    if (pac.SysParentescoRecords.Count > 0)
                    {
                        SysParentesco par = pac.SysParentescoRecords[0];
                        par.IdNivelInstruccion = Convert.ToInt32(ddlNivelInstruccion.SelectedValue);
                        par.IdSituacionLaboral = Convert.ToInt32(ddlSituacionLaboral.SelectedValue);
                        par.IdProfesion = Convert.ToInt32(ddlProfesion.SelectedValue);
                        par.IdUsuario = SSOHelper.CurrentIdentity.Id;
                        par.FechaModificacion = DateTime.Now;
                        if ((ddlNivelInstruccion.SelectedValue != "") || (ddlSituacionLaboral.SelectedValue != "") || (ddlProfesion.SelectedValue != ""))
                        {
                            par.IdPaciente = idPaciente;
                            par.Save(SSOHelper.CurrentIdentity.Username);
                        }
                    }
                    o.Save(SSOHelper.CurrentIdentity.Username);
                    Master.Message("Los datos se guardaron exitosamente.", MessageStatus.ok);
                
            }
        }
    }
}


