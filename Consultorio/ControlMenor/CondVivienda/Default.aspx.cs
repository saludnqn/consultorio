using System;
using DalSic;
using SubSonic;
using SIPS.Utilidades;
using System.Transactions;
using Salud.Security.SSO;

namespace SIPS.ControlMenor.CondVivienda
{
    public partial class Default : System.Web.UI.Page
    {
        private int idCondicionesVivienda
        {
            get { return ViewState["idCondicionesVivienda"] == null ? 0 : Convert.ToInt32(ViewState["idCondicionesVivienda"]); }
            set { ViewState["idCondicionesVivienda"] = value; }
        }

        private int idPaciente
        {
            get { return ViewState["idPaciente"] == null ? 0 : Convert.ToInt32(ViewState["idPaciente"]); }
            set { ViewState["idPaciente"] = value; }
        }

        /*  private bool PermitirGuardar
          {
              get { return ViewState["permitirGuardar"] == null ? false : Convert.ToBoolean(ViewState["permitirGuardar"]); }
              set { ViewState["permitirGuardar"] = value; }
          } */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;           

            int idPacienteTemp;
            if (Int32.TryParse(Request.QueryString["idPaciente"], out idPacienteTemp))
            {
                idPaciente = idPacienteTemp;
                LoadCondiciones(idCondicionesVivienda);
            }
        }

        /*   private void setPermitirGuardar(int idPaciente)
           {
               SysPaciente oPaciente = new SysPaciente(idPaciente);
               if (oPaciente != null)
               {
                   DateDifference oDateDifference = new DateDifference(oPaciente.FechaNacimiento, DateTime.Today);
                   PermitirGuardar = oDateDifference.Years <= 6;
               }
           }  */

        private void LoadCondiciones(int idCondicionesViviendaTemp)
        {
            //cargo los otros datos
            SubSonic.Select s = new Select();
            s.From(AprCondicionesVivienda.Schema);
            s.Where("idPaciente").IsEqualTo(idPaciente);
            AprCondicionesVivienda o = s.ExecuteSingle<AprCondicionesVivienda>();

            if (o != null)
            {
                //levanto los datos existentes
                cblPisoT.Checked = o.PisoTierra.GetValueOrDefault(false);
                cblPisoM.Checked = o.PisoMaterial.GetValueOrDefault(false);
                //basura
                cblBasuraR.Checked = o.BRecoleccion.GetValueOrDefault(false);
                cblBasuraE.Checked = o.BEntierran.GetValueOrDefault(false);
                cblBasuraQ.Checked = o.BQueman.GetValueOrDefault(false);
                cblBasuraO.Checked = o.BOtra.GetValueOrDefault(false);
                //combustion
                cblRenglon1GN.Checked = o.FCGasNatural.GetValueOrDefault(false);
                cblRenglon1Ga.Checked = o.FCGarrafa.GetValueOrDefault(false);
                cblRenglon1L.Checked = o.FCCarbon.GetValueOrDefault(false);
                cblRenglon2K.Checked = o.FCKerosen.GetValueOrDefault(false);
                cblRenglon2E.Checked = o.FCElectricidad.GetValueOrDefault(false);
                cblRenglon2O.Checked = o.FCOtro.GetValueOrDefault(false);
                //combustion en el hogar
                cblHogar0.Checked = o.CRedAgua.GetValueOrDefault(false);
                cblHogar10.Checked = o.CRedExcretas.GetValueOrDefault(false);
                cblHogar1.Checked = o.NoCRedAgua.GetValueOrDefault(false);
                cblHogar11.Checked = o.NoCRedExcretas.GetValueOrDefault(false);
                cblHogar2.Checked = o.FHogarAgua.GetValueOrDefault(false);
                cblHogar12.Checked = o.FHogarExcretas.GetValueOrDefault(false);
                //contaminantes
                cblContaminantesH.Checked = o.PCHumo.GetValueOrDefault(false);
                cblContaminantesB.Checked = o.PCBasurales.GetValueOrDefault(false);
                cblContaminantesA.Checked = o.PCAgroquimicos.GetValueOrDefault(false);
                cblContaminantesV.Checked = o.PCVectores.GetValueOrDefault(false);
                cblContaminantesT.Checked = o.PCTerrInundados.GetValueOrDefault(false);
                cblContaminantesP.Checked = o.PCPetroquimicos.GetValueOrDefault(false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            /* if (!PermitirGuardar)
             {
                 Master.Message("No se pueden Modificar los datos del paciente, el mismo es mayor de 6 años.", MessageStatus.alert);
                 return;
             }*/
                       
                //id de la tabla Sys_Paciente
                int idPaciente = SubSonic.Sugar.Web.QueryString<int>("idPaciente");
                if (idPaciente != 0)
                {
                    AprCondicionesVivienda o = new AprCondicionesVivienda();
                    SubSonic.Select s = new Select();
                    s.From(AprCondicionesVivienda.Schema);
                    s.Where("idPaciente").IsEqualTo(idPaciente);
                    o = s.ExecuteSingle<AprCondicionesVivienda>();
                    //AprCondicionesVivienda o = new AprCondicionesVivienda();

                    if (o == null)
                    {
                        o = new AprCondicionesVivienda();
                    }

                    o.PisoTierra = cblPisoT.Checked;
                    o.PisoMaterial = cblPisoM.Checked;
                    o.BRecoleccion = cblBasuraR.Checked;
                    o.BEntierran = cblBasuraE.Checked;
                    o.BQueman = cblBasuraQ.Checked;
                    o.BOtra = cblBasuraO.Checked;
                    o.FCGasNatural = cblRenglon1GN.Checked;
                    o.FCGarrafa = cblRenglon1Ga.Checked;
                    o.FCCarbon = cblRenglon1L.Checked;
                    o.FCKerosen = cblRenglon2K.Checked;
                    o.FCElectricidad = cblRenglon2E.Checked;
                    o.FCOtro = cblRenglon2O.Checked;
                    //
                    o.CRedAgua = cblHogar0.Checked;
                    o.CRedExcretas = cblHogar10.Checked;
                    o.NoCRedAgua = cblHogar1.Checked;
                    o.NoCRedExcretas = cblHogar11.Checked;
                    o.FHogarAgua = cblHogar2.Checked;
                    o.FHogarExcretas = cblHogar12.Checked;
                    //
                    o.PCHumo = cblContaminantesH.Checked;
                    o.PCBasurales = cblContaminantesB.Checked;
                    o.PCAgroquimicos = cblContaminantesA.Checked;
                    o.PCVectores = cblContaminantesV.Checked;
                    o.PCTerrInundados = cblContaminantesT.Checked;
                    o.PCPetroquimicos = cblContaminantesP.Checked;
                    o.IdPaciente = idPaciente;

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
                    o.Save(SSOHelper.CurrentIdentity.Username);
                    Master.Message("Las Condiciones de Vivienda se guardaron exitosamente.", MessageStatus.ok);
                
            }
        }
    }
}
