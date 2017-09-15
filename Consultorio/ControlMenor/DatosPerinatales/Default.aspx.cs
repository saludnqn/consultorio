using System;
using System.Web.UI.WebControls;
using DalSic;
using SubSonic;
using System.Transactions;
using SIPS.Utilidades;
using System.Collections.Generic;

namespace SIPS.ControlMenor.DatosPerinatales
{
    public partial class Default : System.Web.UI.Page
    {
        private int idPaciente
        {
            get { int idTemp; return (Int32.TryParse(Request.QueryString["idPaciente"], out idTemp)) ? idTemp : 0; }
        }

        private bool PermitirGuardar
        {
            get { return ViewState["permitirGuardar"] == null ? false : Convert.ToBoolean(ViewState["permitirGuardar"]); }
            set { ViewState["permitirGuardar"] = value; }
        }

        private SysParentesco oMama;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            setPermitirGuardar(idPaciente);

            // Carga los datos perinatales
            AprRecienNacido Datos = new Select()
                .From(AprRecienNacido.Schema)
                .Where(AprRecienNacido.IdPacienteColumn).IsEqualTo(idPaciente)
                .ExecuteSingle<AprRecienNacido>();
            if (Datos == null)
            {
                Datos = new AprRecienNacido();
            }

            txtAPGAR1.Text = Datos.APGAR1.ToString();
            txtAPGAR5.Text = Datos.APGAR5.ToString();
            txtLongitud.Text = Datos.Longitud.ToString();
            txtPerimetroCefalico.Text = Datos.PerimetroCefalico.ToString();
            txtPeso.Text = Datos.Peso.ToString();
            //datos de EmbarazoNormal
            //if (Datos.EmbarazoNormal.HasValue) { rblEmbarazoNormal.SelectedValue = Datos.EmbarazoNormal.Value.ToString(); }
            if (Datos.EmbarazoNormal == true) rblEmbarazoNormal.SelectedValue = "1";
            else rblEmbarazoNormal.SelectedValue = "0";
            //datos del Tipo de Parto
            switch (Datos.IdTipoParto)
            {
                case 0: ddlTipoParto.SelectedValue = "0";
                    break;
                case 1: ddlTipoParto.SelectedValue = "1";
                    break;
                case 2: ddlTipoParto.SelectedValue = "2";
                    break;
                case 3: ddlTipoParto.SelectedValue = "3";
                    break;
                case 4: ddlTipoParto.SelectedValue = "4";
                    break;
            }
            if (Datos.Gemelar == true) rblGemelar.SelectedValue = "1";
            else rblGemelar.SelectedValue = "0";
            //datos de Pesquiza
            if (Datos.PesquizaNeonatal == true) rblPesquiza.SelectedValue = "1";
            else rblPesquiza.SelectedValue = "0";
            //datos del HB12
            if (Datos.Hb12meses.HasValue)
            {
                cblHb.Checked = Datos.Hb12meses.Value;
            }
            //datos del TA
            if (Datos.TA3.HasValue)
            {
                cbTa.Checked = Datos.TA3.Value;
            }
            txtNumeroGesta.Text = Datos.NroGesta.HasValue ? Datos.NroGesta.Value.ToString() : "";
            txtPesoAlAlta.Text = Datos.PesoAlAlta.HasValue ? Datos.PesoAlAlta.Value.ToString() : "";

            if (!String.IsNullOrEmpty(Datos.DiagnosticoNeonatalTemporal))
            {
                ddlDiagNeoNatalTemporal.SelectedValue = Datos.DiagnosticoNeonatalTemporal;
            }
            if (!String.IsNullOrEmpty(Datos.DiagnosticoNeonatalFisico))
            {
                ddlDiagNeoNatalFisico.SelectedValue = Datos.DiagnosticoNeonatalFisico;
            }
            if (!String.IsNullOrEmpty(Datos.OEARealizado))
            {
                ddlOEARealizado.SelectedValue = Datos.OEARealizado;
            }
            if (Datos.ScreeningRealizado == true) rblScreeningRealizado.SelectedValue = "1";
            else rblScreeningRealizado.SelectedValue = "0";
            if (Datos.ScreeningNormal == true) rblScreeningNormal.SelectedValue = "1";
            else rblScreeningNormal.SelectedValue = "0";
            /* Falta Levantar los diagnosticos del CIE10  */

            // Buscamos a la mamá, si existe.
            oMama = new Select()
                    .From(SysParentesco.Schema)
                    .Where(SysParentesco.Columns.IdPaciente).IsEqualTo(idPaciente)
                    .And(SysParentesco.Columns.TipoParentesco).IsEqualTo("Madre")
                    .ExecuteSingle<SysParentesco>();


            // Datasource para el repeater
            rptFactoresRiesgo.DataSource = new Select()
                .From(AprFactorRiesgo.Schema)
                .Where(AprFactorRiesgo.EstaticoColumn)
                .IsEqualTo(true)
                .ExecuteDataSet();
            rptFactoresRiesgo.DataBind();

        }

        private void setPermitirGuardar(int idPaciente)
        {
            SysPaciente oPaciente = new SysPaciente(idPaciente);
            if (oPaciente != null)
            {
                DateDifference oDateDifference = new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                PermitirGuardar = oDateDifference.Years <= 6;
            }
        }

        // Bindeo de los items del repeater. Tilda los checkboxes.
        protected void rptFactoresRiesgo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CheckBox cbFactor = e.Item.FindControl("cbFactor") as CheckBox;
            HiddenField hfFactorRiesgoId = e.Item.FindControl("hfIdFactor") as HiddenField;
            int idFactor;
            if (cbFactor != null && hfFactorRiesgoId != null && Int32.TryParse(hfFactorRiesgoId.Value, out idFactor))
            {
                cbFactor.Checked = (new Select()
                    .From(AprRelPersonaFactorRiesgoInicial.Schema)
                    .Where(AprRelPersonaFactorRiesgoInicial.IdFactorRiesgoColumn).IsEqualTo(idFactor)
                    .And(AprRelPersonaFactorRiesgoInicial.IdPersonaColumn).IsEqualTo(idPaciente)
                    .ExecuteSingle<AprRelPersonaFactorRiesgoInicial>() != null)
                    ||
                    (idFactor == 5 && oMama != null && new DateDifference(oMama.FechaNacimiento, new SysPaciente(idPaciente).FechaNacimiento).Years < 17);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!PermitirGuardar)
            {
                Master.Message("No se pueden Modificar los datos del paciente, el mismo es mayor de 6 años.", MessageStatus.alert);
                return;
            }

            // Validación
            string Errores = "";

            float Peso = -1;
            if (txtPeso.Text != "" && (!float.TryParse(txtPeso.Text, out Peso) || Peso < 400.0 || Peso > 10000.00))
            {
                Errores += "<li>El peso debe ser un valor numérico positivo entre 400 y 10.000.</li>";
            }

            float Longitud = -1;
            if (txtLongitud.Text != "" && (!float.TryParse(txtLongitud.Text, out Longitud) || Longitud < 45.0 || Longitud > 210.0))
            {
                Errores += "<li>La longitud debe ser un valor numérico positivo entre 45 y 210.</li>";
            }

            float Perimetro = -1;
            if (txtPerimetroCefalico.Text != "" && (!float.TryParse(txtPerimetroCefalico.Text, out Perimetro) || Perimetro < 30.0 || Perimetro > 60.0))
            {
                Errores += "<li>El perímetro cefálico debe ser un valor numérico positivo entre 30 y 60.</li>";
            }

            int APGAR1 = -1;
            if (txtAPGAR1.Text != "" && (!Int32.TryParse(txtAPGAR1.Text, out APGAR1) || APGAR1 < 0 || APGAR1 > 10))
            {
                Errores += "<li>APGAR 1' debe ser un valor entero entre 0 y 10.</li>";
            }

            int APGAR5 = -1;
            if (txtAPGAR5.Text != "" && (!Int32.TryParse(txtAPGAR5.Text, out APGAR5) || APGAR5 < 0 || APGAR5 > 10))
            {
                Errores += "<li>APGAR 5' debe ser un valor entero entre 0 y 10.</li>";
            }

            int NumeroGesta = -1;
            if (txtNumeroGesta.Text != "" && (!Int32.TryParse(txtNumeroGesta.Text, out NumeroGesta) || NumeroGesta < 1))
            {
                Errores += "<li>El numero de gesta debe ser un valor numérico positivo mayor o igual a 1.</li>";
            }

            float PesoAlAlta = -1;
            if (txtPesoAlAlta.Text != "" && (!float.TryParse(txtPesoAlAlta.Text, out PesoAlAlta) || PesoAlAlta < 400.0 || PesoAlAlta > 10000.0))
            {
                Errores += "<li>El peso al alta debe ser un valor numérico positivo entre 400 y 10.000.</li>";
            }

            if (Errores != "")
            {
                Master.Message("El formulario tiene los siguientes errores: <ul>" + Errores + "</ul>", MessageStatus.error);
            }
            else
            {
                // Carga los datos perinatales
                AprRecienNacido Datos = new Select()
                    .From(AprRecienNacido.Schema)
                    .Where(AprRecienNacido.IdPacienteColumn).IsEqualTo(idPaciente)
                    .ExecuteSingle<AprRecienNacido>();
                if (Datos == null) Datos = new AprRecienNacido();

                // Coloca los datos "automáticos"
                Datos.IdPaciente = idPaciente;
                //Datos.IdEfector = Master.Usuario.IdEfector;

                // Levanta los datos posteados
                Datos.Peso = (Peso != -1) ? (float?)Peso : null;
                Datos.Longitud = (Longitud != -1) ? (float?)Longitud : null;
                Datos.PerimetroCefalico = (Perimetro != -1) ? (float?)Perimetro : null;
                Datos.APGAR1 = (APGAR1 != -1) ? (int?)APGAR1 : null;
                Datos.APGAR5 = (APGAR5 != -1) ? (int?)APGAR5 : null;
                //bool Gemelar;
                //Datos.Gemelar = Boolean.TryParse(rblGemelar.SelectedValue, out Gemelar) ? (bool?)Gemelar : null; ;
                switch (rblGemelar.SelectedValue)
                {
                    case "0": Datos.Gemelar = false;
                        break;
                    case "1": Datos.Gemelar = true;
                        break;
                }
                Datos.PesoAlAlta = (PesoAlAlta != -1) ? (float?)PesoAlAlta : null;
                Datos.NroGesta = (NumeroGesta != -1) ? (int?)NumeroGesta : null;
                Datos.DiagnosticoNeonatalTemporal = ddlDiagNeoNatalTemporal.SelectedValue;
                Datos.DiagnosticoNeonatalFisico = ddlDiagNeoNatalFisico.SelectedValue;
                Datos.OEARealizado = ddlOEARealizado.SelectedValue;
                //otros datos agregados
                //Datos.EmbarazoNormal = Boolean.TryParse(rblEmbarazoNormal.SelectedValue, out EmbarazoNormal) ? (bool?)EmbarazoNormal : null; ;
                if (rblEmbarazoNormal.SelectedValue == "1") Datos.EmbarazoNormal = true;
                else Datos.EmbarazoNormal = false;
                Datos.IdTipoParto = Convert.ToInt32(ddlTipoParto.SelectedValue);
                switch (rblPesquiza.SelectedValue)
                {
                    case "0": Datos.PesquizaNeonatal = false;
                        break;
                    case "1": Datos.PesquizaNeonatal = true;
                        break;
                }
                Datos.Hb12meses = cblHb.Checked;
                Datos.TA3 = cbTa.Checked;
               //fin otros datos agregados
                if (rblScreeningRealizado.SelectedValue == "1") Datos.ScreeningRealizado = true;
                else Datos.ScreeningRealizado = false;
                if (rblScreeningNormal.SelectedValue == "1") Datos.ScreeningNormal = true;
                else Datos.ScreeningNormal = false;
                /* Otros Diagnosticos */
                string[] oDiagnosticos = DiagnosticoSecundario1.getDiagnosticos().Split(',');
                AprRelRecienNacidoEnfermedadCollection oOtrosDiagnosticos = new AprRelRecienNacidoEnfermedadCollection();
                /*Creo una nueva coleccion con los que estan en la pagina */
                foreach (string sDiagnosticoSecundario in oDiagnosticos)
                {
                    if (sDiagnosticoSecundario.Length > 0)
                    {
                        int idDiagnostico;
                        AprRelRecienNacidoEnfermedad oRelRecienNacido;
                        if (Int32.TryParse(sDiagnosticoSecundario, out idDiagnostico))
                        {
                            oRelRecienNacido = new AprRelRecienNacidoEnfermedad();
                            oRelRecienNacido.CODCIE10 = idDiagnostico;
                            oRelRecienNacido.IdEfector = 0;// Master.Usuario.IdEfector;
                            oRelRecienNacido.IdRecienNacido = Datos.IdRecienNacido;
                            oOtrosDiagnosticos.Add(oRelRecienNacido);
                        }
                        else
                        {
                            Errores += "<li>No se reconoce algun diagnostico.</li>";
                        }
                    }
                }

                // Levanta los riesgos posteados
                AprRelPersonaFactorRiesgoInicialCollection Riesgos = new AprRelPersonaFactorRiesgoInicialCollection();

                foreach (RepeaterItem fila in rptFactoresRiesgo.Items)
                {
                    CheckBox cbFactor = fila.FindControl("cbFactor") as CheckBox;
                    HiddenField hfIdFactor = fila.FindControl("hfIdFactor") as HiddenField;
                    int idFactor;
                    if (cbFactor != null && hfIdFactor != null
                        && cbFactor.Checked && Int32.TryParse(hfIdFactor.Value, out idFactor))
                    {
                        AprRelPersonaFactorRiesgoInicial oFactor = new AprRelPersonaFactorRiesgoInicial();
                        oFactor.IdFactorRiesgo = idFactor;
                        oFactor.IdPersona = idPaciente;
                        Riesgos.Add(oFactor);
                    }
                }                
                if (Errores != "")
                {
                    Master.Message("El formulario tiene los siguientes errores: <ul>" + Errores + "</ul>", MessageStatus.error);
                }
                else
                {
                    /*Elimino los que no estan en la nueva coleccion */
                    int count = Datos.AprRelRecienNacidoEnfermedadRecords.Count;
                    List<AprRelRecienNacidoEnfermedad> eliminar = new List<AprRelRecienNacidoEnfermedad>();
                    for (int i = 0; i < count; i++)
                    {
                        if (!oOtrosDiagnosticos.Contains(Datos.AprRelRecienNacidoEnfermedadRecords[i]))
                        {
                            eliminar.Add(Datos.AprRelRecienNacidoEnfermedadRecords[i]);
                        }
                    }
                    foreach (AprRelRecienNacidoEnfermedad pos in eliminar)
                    {
                        Datos.AprRelRecienNacidoEnfermedadRecords.Remove(pos);
                    }
                    /* agrego los nuevos elementos, que no estan ya*/
                    foreach (AprRelRecienNacidoEnfermedad oRelacion in oOtrosDiagnosticos)
                    {
                        if (!Datos.AprRelRecienNacidoEnfermedadRecords.Contains(oRelacion))
                        {
                            Datos.AprRelRecienNacidoEnfermedadRecords.Add(oRelacion);
                        }
                    }                   

                    // Comenzamos el guardado (transaccionalmente)
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                        {
                            try
                            {
                                Datos.Save(0);
                                Datos.AprRelRecienNacidoEnfermedadRecords.SaveAll(0);                                                                
                                Riesgos.SaveAll(0);
                                transaction.Complete();
                                Master.Message("Los datos se guardaron exitosamente.", MessageStatus.ok);

                                /*Rebindeo los diagnosticos, para que refleje los cambios */
                                DiagnosticoSecundario1.setDiagnosticosEnfermedad(Datos.AprRelRecienNacidoEnfermedadRecords);
                            }
                            catch (Exception ex)
                            {
                                // Algo explotó, mostramos el error.
                                transaction.Dispose();
                                string strerror = "";
                                while (ex != null)
                                {
                                    strerror += ex.Message + "<br>";
                                    ex = ex.InnerException;
                                }
                                Master.Message(strerror, MessageStatus.error);
                            }
                        }
                    }
                }
            }
        }
    }
}
