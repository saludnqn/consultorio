using DalSic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControls
{
    public partial class PacienteProvincial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

public class Persona
{

    //public string NumeroExtranjero  { get; set; }
    //public int Documento { get; set; }
    //public int Estado  { get; set; }
    //public int MotivoNI  { get; set; }
    //public string FechaNacimiento { get; set; }

    //public string Apellidos { get; set; }
    //public string Nombres { get; set; }
    //public string Sexo { get; set; }

    //public int idObraSocial { get; set; }
    //public string Observaciones { get; set; }
    //public int idPais { get; set; }
    //public int idLugarNacimiento { get; set; }  

    //public string  TelefonoFijo  { get; set; } 
    //public string  TelefonoCelular  { get; set; } 
    //public string  Email  { get; set; } 
       
    //public string  FechaDefuncion { get; set; }             
    //public string  DomicilioCalle  { get; set; } 
    //public string  DomicilioNumero  { get; set; } 
    //public string  DomicilioEdificio { get; set; } 
    //public string  DomicilioPiso { get; set; } 
                      
    //public string  DomicilioDepartamento { get; set; } 
    //public string  DomicilioManzana { get; set; } 
    //public string  idDomicilioBarrio { get; set; } 
    //public string  DomicilioLatitud { get; set; } 
    //public string  DomicilioLongitud { get; set; } 
    //public int  idProvincia { get; set; } 
    //public int  idDepartamento { get; set; } 
    //public int  idLocalidad { get; set; } 
    //public string  CodigoPostal { get; set; } 
           
    //public string  DomicilioOtroBarrio { get; set; }    
    //public string  DomicilioReferencia { get; set; }    
    //public string  DomicilioCamino { get; set; }    
    //public string  DomicilioCampo { get; set; }    
    //public string  DomicilioLote { get; set; }    
    //public string  DomicilioParcela { get; set; }                                               
    //public string  DomicilioUrbano { get; set; }          
    
    ///////Datos de la madre///
    //public string  DocumentoMadre { get; set; } 
    //public string  ApellidoMadre { get; set; } 
    //public string  NombreMadre { get; set; } 
    //public string FechaNacimientoMadre { get; set; } 
    //public int  idNacionalidadMadre { get; set; } 
    //public int  idLugarNacimientoMadre { get; set; } 

    ///////Datos de la padre///
    //public string  DocumentoPadre{ get; set; } 
    //public string  ApellidoPadre { get; set; } 
    //public string  NombrePadre { get; set; } 
    //public string FechaNacimientoPadre { get; set; } 
    //public int  idNacionalidadPadre { get; set; } 
    //public int  idLugarNacimientoPadre { get; set; }   

    public int Documento { get; set; }
    public string ApellidoYNombre { get; set; } // 72 caracteres
    public string LugarNacimiento { get; set; } // 25 caracteres
    public string FechaNacimiento { get; set; }
    public string Sexo { get; set; } // 1 caracter (F/M)
    public string DomicilioCalle { get; set; } // 100 caracteres
    public string DomicilioNumero { get; set; } // 100 caracteres
    public string DomicilioPiso { get; set; } // 100 caracteres
    public string DomicilioDepartamento { get; set; } // 100 caracteres
    public string DomicilioManzana { get; set; } // 100 caracteres
    public string Barrio { get; set; } // 50 caracteres
    public string Dependencia { get; set; } // 50 caracteres
    public string Localidad { get; set; } // 30 caracteres
    public string Provincia { get; set; } // 20 caracteres
    public string Nacionalidad { get; set; } // 3 caracteres
    public string CodigoPostal { get; set; } // 6 caracteres
    public string Telefono { get; set; } // 20 caracteres
    public string ObraSocial { get; set; } // 35 caracteres
    public string Observaciones { get; set; } // 300 caracteres
    public string Usuario { get; set; } // SSS - 20 caracteres
    public string Cuenta { get; set; } // 999 - 3 caracteres
    public string Subcue { get; set; } // 999 - 3 caracteres
    public bool Verificado { get; set; } // false
    public bool Activo { get; set; } // true
    public bool HC_Pasiva { get; set; } // false
    public string Apellidos { get; set; } // 50 caracteres
    public string Nombres { get; set; } // 50 caracteres


    ///datos adicionales para ser tomados con consultas al padron provincial
    public string NumeroExtranjero { get; set; } // 20 caracteres
    public int Estado { get; set; } // 
    public int MotivoNI { get; set; }
    public int idObraSocial { get; set; }

    public int idPais { get; set; }
    public int idLugarNacimiento { get; set; }
    public string TelefonoFijo { get; set; }// 20 caracteres
    public string TelefonoCelular { get; set; }// 20 caracteres
    public string Email { get; set; }// 50 caracteres

    public string FechaDefuncion { get; set; }

    public string DomicilioEdificio { get; set; }// 50 caracteres



    public int idDomicilioBarrio { get; set; }
    public string DomicilioLatitud { get; set; }// 20 caracteres
    public string DomicilioLongitud { get; set; }// 20 caracteres
    public int idProvincia { get; set; }
    public int idDepartamento { get; set; }
    public int idLocalidad { get; set; }

    public string DomicilioOtroBarrio { get; set; }// 150 caracteres
    public string DomicilioReferencia { get; set; }// 200 caracteres
    public string DomicilioCamino { get; set; }// 100 caracteres
    public string DomicilioCampo { get; set; }// 100 caracteres
    public string DomicilioLote { get; set; }// 10 caracteres
    public string DomicilioParcela { get; set; }// 10 caracteres
    public string DomicilioUrbano { get; set; } //bool

    /////Datos de la madre///
    public string DocumentoMadre { get; set; }
    public string ApellidoMadre { get; set; }
    public string NombreMadre { get; set; }
    public string FechaNacimientoMadre { get; set; }
    public int idNacionalidadMadre { get; set; }
    public int idLugarNacimientoMadre { get; set; }

    /////Datos de la padre///
    public string DocumentoPadre { get; set; }
    public string ApellidoPadre { get; set; }
    public string NombrePadre { get; set; }
    public string FechaNacimientoPadre { get; set; }
    public int idNacionalidadPadre { get; set; }
    public int idLugarNacimientoPadre { get; set; }   

}

public bool MostrarDatos(string p)
{

    bool dat = false;

    string s_urlWFC = ConfigurationManager.AppSettings["Padron_Provincial_WebService"].ToString();
    string s_url = s_urlWFC + "?dni=" + p;

    //string s_url="http://10.1.232.15/wspacientes/paciente.asmx/PacienteXDNI?dni=" + p;


    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s_url);
    HttpWebResponse ws1 = (HttpWebResponse)request.GetResponse();
    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
    Stream st = ws1.GetResponseStream();
    StreamReader sr = new StreamReader(st);
    string sPS = sr.ReadToEnd();





    int inicio = sPS.IndexOf("{");
    int fin = sPS.IndexOf("}") + 1;
    string aux = sPS.Substring(inicio, fin - inicio);
    //List<Persona> personitas = jsonSerializer.Deserialize<List<Persona>>(aux);
    aux = "[" + aux + "]";
    List<Persona> personitas = jsonSerializer.Deserialize<List<Persona>>(aux);

 //  var personitas = jsonSerializer.Deserialize<List<Persona>>(sPS);

    foreach (Persona pac in personitas)
    {
        if (pac.Documento != 0) 
        {
            dat = true;
            //&& ((pac.Estado == 3) || (pac.Estado == 1))
            pnlPaciente.Visible = true;
            pnlError.Visible = false;
            lblExtranjero.Text = pac.NumeroExtranjero.ToString();
            lblNumeroDoc.Text = pac.Documento.ToString();
            lblIdEstado.Text = pac.Estado.ToString();

            lblIdEstado.Text = pac.Estado.ToString();
            SysEstado oEstado = new SysEstado(pac.Estado);
            
            lblEstado.Text = oEstado.Nombre;
            if (pac.Estado == 3) /// Validado
                lblEstado.ForeColor = Color.Red;
            //else lblEstado.ForeColor = Color.Red;

            lblidMotivoNI.Text = pac.MotivoNI.ToString();
            SysMotivoNI oMotivo = new SysMotivoNI(pac.MotivoNI);
            lblMotivoNI.Text = pac.MotivoNI.ToString();


            lblFechaNac.Text = pac.FechaNacimiento;
            lblApellido.Text = pac.Apellidos;
            lblNombre.Text = pac.Nombres;
            

            switch (pac.Sexo)
            {
                case "": lblidSexo.Text = "1"; break;
                case "F": lblidSexo.Text = "2"; break;
                case "M": lblidSexo.Text = "3"; break;
            }

            switch (pac.Sexo)
            {
                case "": lblSexo.Text = "Indeterminado"; break;
                case "F": lblSexo.Text = "Femenimo"; break;
                case "M": lblSexo.Text = "Masculino"; break;
            }
         
            lblidSexo.Visible = false;

            SysObraSocial Osocial = new SysObraSocial(pac.idObraSocial);
            lblidOSocial.Text = pac.idObraSocial.ToString();
            lblidOSocial.Visible = false;
            lblOSocial.Text = Osocial.Nombre;

            lblContacto.Text = pac.Observaciones;

            SysPai oPais = new SysPai(pac.idPais);
            lblidNacionalidad.Text = pac.idPais.ToString();
            lblidNacionalidad.Visible = false;
            lblNacionalidad.Text = oPais.Nombre;

            //lugar de nacimiento
            SysProvincium oLugarNac = new SysProvincium(pac.idLugarNacimiento);
            lblidLugarNacimiento.Text = pac.idLugarNacimiento.ToString();
            lblidLugarNacimiento.Visible = false;
            lblLugarNacimiento.Text = oLugarNac.Nombre;

            lblTFijo.Text = pac.TelefonoFijo;
            lblTCelular.Text = pac.TelefonoCelular;
            lblEmail.Text = pac.Email;
            lblCalle.Text = pac.DomicilioCalle;
            lblNum.Text = pac.DomicilioNumero;
            lblEdificio.Text = pac.DomicilioEdificio; ;
            lblPiso.Text = pac.DomicilioPiso;
            lblDepartamento.Text = pac.DomicilioDepartamento;
            lblManzana.Text = pac.DomicilioManzana;
            lblLatitud.Text = pac.DomicilioLatitud;
            lblLongitud.Text = pac.DomicilioLongitud;

            SysProvincium oProvinciaDomicilio = new SysProvincium(pac.idProvincia);
            lblidProvincia.Text = pac.idProvincia.ToString();
            lblidProvincia.Visible = false;
            lblProvincia.Text = oProvinciaDomicilio.Nombre;

            SysDepartamento oDepartamentoDomicilio = new SysDepartamento(pac.idDepartamento);
            lblidDptoDomicilio.Text = pac.idDepartamento.ToString();
            lblidDptoDomicilio.Visible = false;
            lblDptoDomicilio.Text = oDepartamentoDomicilio.Nombre;

            SysLocalidad oLocalidadDomicilio = new SysLocalidad(pac.idLocalidad);
            lblidLocalidad.Text = pac.idLocalidad.ToString();
            lblidLocalidad.Visible = false;
            lblLocalidad.Text = oLocalidadDomicilio.Nombre;

            lblCPostal.Text = pac.CodigoPostal;

            SysBarrio oBarrio = new SysBarrio(pac.idDomicilioBarrio);
            lblidBarrio.Text = pac.idDomicilioBarrio.ToString();
            lblidBarrio.Visible = false;
            lblBarrio.Text = oBarrio.Nombre;

            lblOBarrio.Text = pac.DomicilioOtroBarrio;
            lblReferencia.Text = pac.DomicilioReferencia;

            if (pac.FechaDefuncion == "01/01/1900") lblDefuncion.Text = "";
            else lblDefuncion.Text = pac.FechaDefuncion;

            if (pac.DomicilioUrbano=="True")                lblUrbano.Text = "Urbano";
            else lblUrbano.Text = "Rural";

            lblCamino.Text = pac.DomicilioCamino;
            lblCampo.Text = pac.DomicilioCampo;
            lblLote.Text = pac.DomicilioLote;
            lblParcela.Text = pac.DomicilioParcela;


            lblTipoDocP.Text = "DU";
            lblDocP.Text = pac.DocumentoPadre;
            lblApellidoP.Text = pac.ApellidoPadre;
            lblNombreP.Text = pac.NombrePadre;
            lblFecNacP.Text = pac.FechaNacimientoPadre;

            SysPai oNacionalidadP = new SysPai(pac.idNacionalidadPadre);
            lblidNacionalidadP.Text = pac.idNacionalidadPadre.ToString();
            lblidLNacimientoP.Visible = false;
            lblNacionalidadP.Text = oNacionalidadP.Nombre;

            SysProvincium oLugarNacimientoP = new SysProvincium(pac.idLugarNacimientoPadre);
            lblidLNacimientoP.Text = pac.idLugarNacimientoPadre.ToString();
            lblidLNacimientoP.Visible = false;
            lblLNacimientoP.Text = oLugarNacimientoP.Nombre;



            lblTipoDocP0.Text = "DU";
            lblDocP0.Text = pac.DocumentoMadre;
            lblApellidoP0.Text = pac.ApellidoMadre;
            lblNombreP0.Text = pac.NombreMadre;

            lblFecNacP0.Text = pac.FechaNacimientoMadre;
            SysPai oNacionalidadM = new SysPai(pac.idNacionalidadMadre);
            lblidNacionalidadP0.Text = pac.idNacionalidadMadre.ToString();
            lblidNacionalidadP0.Visible = false;
            lblNacionalidadP0.Text = oNacionalidadM.Nombre;

            SysProvincium oLugarNacimientoM = new SysProvincium(pac.idLugarNacimientoMadre);
            lblidLNacimientoP0.Text = pac.idLugarNacimientoMadre.ToString();
            lblidLNacimientoP0.Visible = false;
            lblLNacimientoP0.Text = oLugarNacimientoM.Nombre;
            break;


        }
        else ///no se encontraron datos para el paciente
        {

            pnlPaciente.Visible = false;
            pnlError.Visible =true ;
            lblError.Text = "No se encontraron datos para el número ingresado";
            break;
        }
        //// SetearLinks(id);

    }
    return dat;
    }

internal string TraerDomicilio()
{
    return lblidProvincia.Text + ";" + lblidDptoDomicilio.Text + ";" + lblidLocalidad.Text + ";" + lblCPostal.Text + ";" + lblidBarrio.Text+";"+ lblOBarrio.Text+";"+
        lblCalle.Text + ";" + lblNum.Text + ";" + lblEdificio.Text + ";" + lblPiso.Text + ";" + lblDepartamento.Text + ";" + lblManzana.Text + ";" + lblReferencia.Text + ";" +
        lblUrbano.Text+";"+ lblLatitud.Text+";"+ lblLongitud.Text+";"+lblCampo.Text+";"+lblCamino.Text+";"+lblLote.Text+";"+lblParcela.Text;
}

internal string TraerDatosMadre()
{
    return lblDocP0.Text + ";" + lblApellidoP0.Text + ";" + lblNombreP0.Text+";"+lblFecNacP0.Text+";"+lblidNacionalidadP0.Text+";"+ lblidLNacimientoP0.Text;
}

internal string TraerDatosPadre()
{
    return lblDocP.Text + ";" + lblApellidoP.Text + ";" + lblNombreP.Text + ";" + lblFecNacP.Text + ";" + lblidNacionalidadP.Text + ";" + lblidLNacimientoP.Text; 
}

internal string TraerDatosPrincipales()
{



    return lblNumeroDoc.Text + ";" + lblApellido.Text + ";" + lblNombre.Text + ";" + lblidSexo.Text + ";" + lblFechaNac.Text + ";" + lblidNacionalidad.Text + ";" + lblidLugarNacimiento.Text +
        ";" + lblidOSocial.Text + ";" + lblTFijo.Text + ";" + lblTCelular.Text + ";" + lblEmail.Text + ";" + lblContacto.Text + ";" + lblDefuncion.Text + ";" + lblOSocial.Text;
}
    }
        
    }
