using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace DalSic{
    /// <summary>
    /// Strongly-typed collection for the RemClasificado class.
    /// </summary>
    [Serializable]
    public partial class RemClasificadoCollection : ReadOnlyList<RemClasificado, RemClasificadoCollection>
    {        
        public RemClasificadoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the REM_Clasificados view.
    /// </summary>
    [Serializable]
    public partial class RemClasificado : ReadOnlyRecord<RemClasificado>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("REM_Clasificados", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
                colvarApellido.ColumnName = "apellido";
                colvarApellido.DataType = DbType.String;
                colvarApellido.MaxLength = 100;
                colvarApellido.AutoIncrement = false;
                colvarApellido.IsNullable = false;
                colvarApellido.IsPrimaryKey = false;
                colvarApellido.IsForeignKey = false;
                colvarApellido.IsReadOnly = false;
                
                schema.Columns.Add(colvarApellido);
                
                TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
                colvarNombre.ColumnName = "nombre";
                colvarNombre.DataType = DbType.String;
                colvarNombre.MaxLength = 100;
                colvarNombre.AutoIncrement = false;
                colvarNombre.IsNullable = false;
                colvarNombre.IsPrimaryKey = false;
                colvarNombre.IsForeignKey = false;
                colvarNombre.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombre);
                
                TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
                colvarNumeroDocumento.ColumnName = "numeroDocumento";
                colvarNumeroDocumento.DataType = DbType.Int32;
                colvarNumeroDocumento.MaxLength = 0;
                colvarNumeroDocumento.AutoIncrement = false;
                colvarNumeroDocumento.IsNullable = false;
                colvarNumeroDocumento.IsPrimaryKey = false;
                colvarNumeroDocumento.IsForeignKey = false;
                colvarNumeroDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumento);
                
                TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
                colvarSexo.ColumnName = "Sexo";
                colvarSexo.DataType = DbType.String;
                colvarSexo.MaxLength = 50;
                colvarSexo.AutoIncrement = false;
                colvarSexo.IsNullable = false;
                colvarSexo.IsPrimaryKey = false;
                colvarSexo.IsForeignKey = false;
                colvarSexo.IsReadOnly = false;
                
                schema.Columns.Add(colvarSexo);
                
                TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
                colvarFechaNacimiento.ColumnName = "fechaNacimiento";
                colvarFechaNacimiento.DataType = DbType.DateTime;
                colvarFechaNacimiento.MaxLength = 0;
                colvarFechaNacimiento.AutoIncrement = false;
                colvarFechaNacimiento.IsNullable = false;
                colvarFechaNacimiento.IsPrimaryKey = false;
                colvarFechaNacimiento.IsForeignKey = false;
                colvarFechaNacimiento.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaNacimiento);
                
                TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
                colvarFechaControl.ColumnName = "fechaControl";
                colvarFechaControl.DataType = DbType.DateTime;
                colvarFechaControl.MaxLength = 0;
                colvarFechaControl.AutoIncrement = false;
                colvarFechaControl.IsNullable = false;
                colvarFechaControl.IsPrimaryKey = false;
                colvarFechaControl.IsForeignKey = false;
                colvarFechaControl.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaControl);
                
                TableSchema.TableColumn colvarCalle = new TableSchema.TableColumn(schema);
                colvarCalle.ColumnName = "calle";
                colvarCalle.DataType = DbType.String;
                colvarCalle.MaxLength = 50;
                colvarCalle.AutoIncrement = false;
                colvarCalle.IsNullable = false;
                colvarCalle.IsPrimaryKey = false;
                colvarCalle.IsForeignKey = false;
                colvarCalle.IsReadOnly = false;
                
                schema.Columns.Add(colvarCalle);
                
                TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
                colvarNumero.ColumnName = "numero";
                colvarNumero.DataType = DbType.Int32;
                colvarNumero.MaxLength = 0;
                colvarNumero.AutoIncrement = false;
                colvarNumero.IsNullable = false;
                colvarNumero.IsPrimaryKey = false;
                colvarNumero.IsForeignKey = false;
                colvarNumero.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumero);
                
                TableSchema.TableColumn colvarManzana = new TableSchema.TableColumn(schema);
                colvarManzana.ColumnName = "manzana";
                colvarManzana.DataType = DbType.String;
                colvarManzana.MaxLength = 50;
                colvarManzana.AutoIncrement = false;
                colvarManzana.IsNullable = false;
                colvarManzana.IsPrimaryKey = false;
                colvarManzana.IsForeignKey = false;
                colvarManzana.IsReadOnly = false;
                
                schema.Columns.Add(colvarManzana);
                
                TableSchema.TableColumn colvarPiso = new TableSchema.TableColumn(schema);
                colvarPiso.ColumnName = "piso";
                colvarPiso.DataType = DbType.String;
                colvarPiso.MaxLength = 10;
                colvarPiso.AutoIncrement = false;
                colvarPiso.IsNullable = false;
                colvarPiso.IsPrimaryKey = false;
                colvarPiso.IsForeignKey = false;
                colvarPiso.IsReadOnly = false;
                
                schema.Columns.Add(colvarPiso);
                
                TableSchema.TableColumn colvarDepartamento = new TableSchema.TableColumn(schema);
                colvarDepartamento.ColumnName = "departamento";
                colvarDepartamento.DataType = DbType.String;
                colvarDepartamento.MaxLength = 10;
                colvarDepartamento.AutoIncrement = false;
                colvarDepartamento.IsNullable = false;
                colvarDepartamento.IsPrimaryKey = false;
                colvarDepartamento.IsForeignKey = false;
                colvarDepartamento.IsReadOnly = false;
                
                schema.Columns.Add(colvarDepartamento);
                
                TableSchema.TableColumn colvarIdBarrio = new TableSchema.TableColumn(schema);
                colvarIdBarrio.ColumnName = "idBarrio";
                colvarIdBarrio.DataType = DbType.Int32;
                colvarIdBarrio.MaxLength = 0;
                colvarIdBarrio.AutoIncrement = false;
                colvarIdBarrio.IsNullable = false;
                colvarIdBarrio.IsPrimaryKey = false;
                colvarIdBarrio.IsForeignKey = false;
                colvarIdBarrio.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdBarrio);
                
                TableSchema.TableColumn colvarIdLocalidad = new TableSchema.TableColumn(schema);
                colvarIdLocalidad.ColumnName = "idLocalidad";
                colvarIdLocalidad.DataType = DbType.Int32;
                colvarIdLocalidad.MaxLength = 0;
                colvarIdLocalidad.AutoIncrement = false;
                colvarIdLocalidad.IsNullable = false;
                colvarIdLocalidad.IsPrimaryKey = false;
                colvarIdLocalidad.IsForeignKey = false;
                colvarIdLocalidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdLocalidad);
                
                TableSchema.TableColumn colvarIdProvinciaDomicilio = new TableSchema.TableColumn(schema);
                colvarIdProvinciaDomicilio.ColumnName = "idProvinciaDomicilio";
                colvarIdProvinciaDomicilio.DataType = DbType.Int32;
                colvarIdProvinciaDomicilio.MaxLength = 0;
                colvarIdProvinciaDomicilio.AutoIncrement = false;
                colvarIdProvinciaDomicilio.IsNullable = false;
                colvarIdProvinciaDomicilio.IsPrimaryKey = false;
                colvarIdProvinciaDomicilio.IsForeignKey = false;
                colvarIdProvinciaDomicilio.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdProvinciaDomicilio);
                
                TableSchema.TableColumn colvarInformacionContacto = new TableSchema.TableColumn(schema);
                colvarInformacionContacto.ColumnName = "informacionContacto";
                colvarInformacionContacto.DataType = DbType.String;
                colvarInformacionContacto.MaxLength = 800;
                colvarInformacionContacto.AutoIncrement = false;
                colvarInformacionContacto.IsNullable = false;
                colvarInformacionContacto.IsPrimaryKey = false;
                colvarInformacionContacto.IsForeignKey = false;
                colvarInformacionContacto.IsReadOnly = false;
                
                schema.Columns.Add(colvarInformacionContacto);
                
                TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
                colvarModifiedOn.ColumnName = "ModifiedOn";
                colvarModifiedOn.DataType = DbType.DateTime;
                colvarModifiedOn.MaxLength = 0;
                colvarModifiedOn.AutoIncrement = false;
                colvarModifiedOn.IsNullable = false;
                colvarModifiedOn.IsPrimaryKey = false;
                colvarModifiedOn.IsForeignKey = false;
                colvarModifiedOn.IsReadOnly = false;
                
                schema.Columns.Add(colvarModifiedOn);
                
                TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
                colvarIdObraSocial.ColumnName = "idObraSocial";
                colvarIdObraSocial.DataType = DbType.Int32;
                colvarIdObraSocial.MaxLength = 0;
                colvarIdObraSocial.AutoIncrement = false;
                colvarIdObraSocial.IsNullable = false;
                colvarIdObraSocial.IsPrimaryKey = false;
                colvarIdObraSocial.IsForeignKey = false;
                colvarIdObraSocial.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdObraSocial);
                
                TableSchema.TableColumn colvarAntecedente = new TableSchema.TableColumn(schema);
                colvarAntecedente.ColumnName = "Antecedente";
                colvarAntecedente.DataType = DbType.String;
                colvarAntecedente.MaxLength = 50;
                colvarAntecedente.AutoIncrement = false;
                colvarAntecedente.IsNullable = false;
                colvarAntecedente.IsPrimaryKey = false;
                colvarAntecedente.IsForeignKey = false;
                colvarAntecedente.IsReadOnly = false;
                
                schema.Columns.Add(colvarAntecedente);
                
                TableSchema.TableColumn colvarImc = new TableSchema.TableColumn(schema);
                colvarImc.ColumnName = "Imc";
                colvarImc.DataType = DbType.Decimal;
                colvarImc.MaxLength = 0;
                colvarImc.AutoIncrement = false;
                colvarImc.IsNullable = false;
                colvarImc.IsPrimaryKey = false;
                colvarImc.IsForeignKey = false;
                colvarImc.IsReadOnly = false;
                
                schema.Columns.Add(colvarImc);
                
                TableSchema.TableColumn colvarRiesgoCardiovascular = new TableSchema.TableColumn(schema);
                colvarRiesgoCardiovascular.ColumnName = "riesgoCardiovascular";
                colvarRiesgoCardiovascular.DataType = DbType.Int32;
                colvarRiesgoCardiovascular.MaxLength = 0;
                colvarRiesgoCardiovascular.AutoIncrement = false;
                colvarRiesgoCardiovascular.IsNullable = false;
                colvarRiesgoCardiovascular.IsPrimaryKey = false;
                colvarRiesgoCardiovascular.IsForeignKey = false;
                colvarRiesgoCardiovascular.IsReadOnly = false;
                
                schema.Columns.Add(colvarRiesgoCardiovascular);
                
                TableSchema.TableColumn colvarTAS = new TableSchema.TableColumn(schema);
                colvarTAS.ColumnName = "tAS";
                colvarTAS.DataType = DbType.Int32;
                colvarTAS.MaxLength = 0;
                colvarTAS.AutoIncrement = false;
                colvarTAS.IsNullable = false;
                colvarTAS.IsPrimaryKey = false;
                colvarTAS.IsForeignKey = false;
                colvarTAS.IsReadOnly = false;
                
                schema.Columns.Add(colvarTAS);
                
                TableSchema.TableColumn colvarTAD = new TableSchema.TableColumn(schema);
                colvarTAD.ColumnName = "tAD";
                colvarTAD.DataType = DbType.Int32;
                colvarTAD.MaxLength = 0;
                colvarTAD.AutoIncrement = false;
                colvarTAD.IsNullable = false;
                colvarTAD.IsPrimaryKey = false;
                colvarTAD.IsForeignKey = false;
                colvarTAD.IsReadOnly = false;
                
                schema.Columns.Add(colvarTAD);
                
                TableSchema.TableColumn colvarColesterolTotal = new TableSchema.TableColumn(schema);
                colvarColesterolTotal.ColumnName = "colesterolTotal";
                colvarColesterolTotal.DataType = DbType.Decimal;
                colvarColesterolTotal.MaxLength = 0;
                colvarColesterolTotal.AutoIncrement = false;
                colvarColesterolTotal.IsNullable = false;
                colvarColesterolTotal.IsPrimaryKey = false;
                colvarColesterolTotal.IsForeignKey = false;
                colvarColesterolTotal.IsReadOnly = false;
                
                schema.Columns.Add(colvarColesterolTotal);
                
                TableSchema.TableColumn colvarUnidadColTotal = new TableSchema.TableColumn(schema);
                colvarUnidadColTotal.ColumnName = "unidadColTotal";
                colvarUnidadColTotal.DataType = DbType.AnsiString;
                colvarUnidadColTotal.MaxLength = 10;
                colvarUnidadColTotal.AutoIncrement = false;
                colvarUnidadColTotal.IsNullable = false;
                colvarUnidadColTotal.IsPrimaryKey = false;
                colvarUnidadColTotal.IsForeignKey = false;
                colvarUnidadColTotal.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidadColTotal);
                
                TableSchema.TableColumn colvarHdl = new TableSchema.TableColumn(schema);
                colvarHdl.ColumnName = "HDL";
                colvarHdl.DataType = DbType.Decimal;
                colvarHdl.MaxLength = 0;
                colvarHdl.AutoIncrement = false;
                colvarHdl.IsNullable = false;
                colvarHdl.IsPrimaryKey = false;
                colvarHdl.IsForeignKey = false;
                colvarHdl.IsReadOnly = false;
                
                schema.Columns.Add(colvarHdl);
                
                TableSchema.TableColumn colvarUnidadHDL = new TableSchema.TableColumn(schema);
                colvarUnidadHDL.ColumnName = "unidadHDL";
                colvarUnidadHDL.DataType = DbType.AnsiString;
                colvarUnidadHDL.MaxLength = 10;
                colvarUnidadHDL.AutoIncrement = false;
                colvarUnidadHDL.IsNullable = false;
                colvarUnidadHDL.IsPrimaryKey = false;
                colvarUnidadHDL.IsForeignKey = false;
                colvarUnidadHDL.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidadHDL);
                
                TableSchema.TableColumn colvarLdl = new TableSchema.TableColumn(schema);
                colvarLdl.ColumnName = "LDL";
                colvarLdl.DataType = DbType.Decimal;
                colvarLdl.MaxLength = 0;
                colvarLdl.AutoIncrement = false;
                colvarLdl.IsNullable = false;
                colvarLdl.IsPrimaryKey = false;
                colvarLdl.IsForeignKey = false;
                colvarLdl.IsReadOnly = false;
                
                schema.Columns.Add(colvarLdl);
                
                TableSchema.TableColumn colvarUnidadLDL = new TableSchema.TableColumn(schema);
                colvarUnidadLDL.ColumnName = "unidadLDL";
                colvarUnidadLDL.DataType = DbType.AnsiString;
                colvarUnidadLDL.MaxLength = 10;
                colvarUnidadLDL.AutoIncrement = false;
                colvarUnidadLDL.IsNullable = false;
                colvarUnidadLDL.IsPrimaryKey = false;
                colvarUnidadLDL.IsForeignKey = false;
                colvarUnidadLDL.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidadLDL);
                
                TableSchema.TableColumn colvarTgl = new TableSchema.TableColumn(schema);
                colvarTgl.ColumnName = "TGL";
                colvarTgl.DataType = DbType.Decimal;
                colvarTgl.MaxLength = 0;
                colvarTgl.AutoIncrement = false;
                colvarTgl.IsNullable = false;
                colvarTgl.IsPrimaryKey = false;
                colvarTgl.IsForeignKey = false;
                colvarTgl.IsReadOnly = false;
                
                schema.Columns.Add(colvarTgl);
                
                TableSchema.TableColumn colvarUnidadTGL = new TableSchema.TableColumn(schema);
                colvarUnidadTGL.ColumnName = "unidadTGL";
                colvarUnidadTGL.DataType = DbType.AnsiString;
                colvarUnidadTGL.MaxLength = 10;
                colvarUnidadTGL.AutoIncrement = false;
                colvarUnidadTGL.IsNullable = false;
                colvarUnidadTGL.IsPrimaryKey = false;
                colvarUnidadTGL.IsForeignKey = false;
                colvarUnidadTGL.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidadTGL);
                
                TableSchema.TableColumn colvarGlucemia = new TableSchema.TableColumn(schema);
                colvarGlucemia.ColumnName = "glucemia";
                colvarGlucemia.DataType = DbType.Decimal;
                colvarGlucemia.MaxLength = 0;
                colvarGlucemia.AutoIncrement = false;
                colvarGlucemia.IsNullable = false;
                colvarGlucemia.IsPrimaryKey = false;
                colvarGlucemia.IsForeignKey = false;
                colvarGlucemia.IsReadOnly = false;
                
                schema.Columns.Add(colvarGlucemia);
                
                TableSchema.TableColumn colvarUnidadGlucemia = new TableSchema.TableColumn(schema);
                colvarUnidadGlucemia.ColumnName = "unidadGlucemia";
                colvarUnidadGlucemia.DataType = DbType.AnsiString;
                colvarUnidadGlucemia.MaxLength = 10;
                colvarUnidadGlucemia.AutoIncrement = false;
                colvarUnidadGlucemia.IsNullable = false;
                colvarUnidadGlucemia.IsPrimaryKey = false;
                colvarUnidadGlucemia.IsForeignKey = false;
                colvarUnidadGlucemia.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidadGlucemia);
                
                TableSchema.TableColumn colvarHbAc1 = new TableSchema.TableColumn(schema);
                colvarHbAc1.ColumnName = "HbAc1";
                colvarHbAc1.DataType = DbType.Decimal;
                colvarHbAc1.MaxLength = 0;
                colvarHbAc1.AutoIncrement = false;
                colvarHbAc1.IsNullable = false;
                colvarHbAc1.IsPrimaryKey = false;
                colvarHbAc1.IsForeignKey = false;
                colvarHbAc1.IsReadOnly = false;
                
                schema.Columns.Add(colvarHbAc1);
                
                TableSchema.TableColumn colvarDosis = new TableSchema.TableColumn(schema);
                colvarDosis.ColumnName = "dosis";
                colvarDosis.DataType = DbType.Double;
                colvarDosis.MaxLength = 0;
                colvarDosis.AutoIncrement = false;
                colvarDosis.IsNullable = false;
                colvarDosis.IsPrimaryKey = false;
                colvarDosis.IsForeignKey = false;
                colvarDosis.IsReadOnly = false;
                
                schema.Columns.Add(colvarDosis);
                
                TableSchema.TableColumn colvarMedicamentos = new TableSchema.TableColumn(schema);
                colvarMedicamentos.ColumnName = "Medicamentos";
                colvarMedicamentos.DataType = DbType.String;
                colvarMedicamentos.MaxLength = 255;
                colvarMedicamentos.AutoIncrement = false;
                colvarMedicamentos.IsNullable = true;
                colvarMedicamentos.IsPrimaryKey = false;
                colvarMedicamentos.IsForeignKey = false;
                colvarMedicamentos.IsReadOnly = false;
                
                schema.Columns.Add(colvarMedicamentos);
                
                TableSchema.TableColumn colvarNombreInsulina = new TableSchema.TableColumn(schema);
                colvarNombreInsulina.ColumnName = "nombreInsulina";
                colvarNombreInsulina.DataType = DbType.String;
                colvarNombreInsulina.MaxLength = 50;
                colvarNombreInsulina.AutoIncrement = false;
                colvarNombreInsulina.IsNullable = false;
                colvarNombreInsulina.IsPrimaryKey = false;
                colvarNombreInsulina.IsForeignKey = false;
                colvarNombreInsulina.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreInsulina);
                
                TableSchema.TableColumn colvarOtrasDrogas1 = new TableSchema.TableColumn(schema);
                colvarOtrasDrogas1.ColumnName = "otrasDrogas1";
                colvarOtrasDrogas1.DataType = DbType.AnsiString;
                colvarOtrasDrogas1.MaxLength = 200;
                colvarOtrasDrogas1.AutoIncrement = false;
                colvarOtrasDrogas1.IsNullable = false;
                colvarOtrasDrogas1.IsPrimaryKey = false;
                colvarOtrasDrogas1.IsForeignKey = false;
                colvarOtrasDrogas1.IsReadOnly = false;
                
                schema.Columns.Add(colvarOtrasDrogas1);
                
                TableSchema.TableColumn colvarDosisODrogas1 = new TableSchema.TableColumn(schema);
                colvarDosisODrogas1.ColumnName = "dosisODrogas1";
                colvarDosisODrogas1.DataType = DbType.Decimal;
                colvarDosisODrogas1.MaxLength = 0;
                colvarDosisODrogas1.AutoIncrement = false;
                colvarDosisODrogas1.IsNullable = false;
                colvarDosisODrogas1.IsPrimaryKey = false;
                colvarDosisODrogas1.IsForeignKey = false;
                colvarDosisODrogas1.IsReadOnly = false;
                
                schema.Columns.Add(colvarDosisODrogas1);
                
                TableSchema.TableColumn colvarOtrasDrogras2 = new TableSchema.TableColumn(schema);
                colvarOtrasDrogras2.ColumnName = "otrasDrogras2";
                colvarOtrasDrogras2.DataType = DbType.AnsiString;
                colvarOtrasDrogras2.MaxLength = 200;
                colvarOtrasDrogras2.AutoIncrement = false;
                colvarOtrasDrogras2.IsNullable = false;
                colvarOtrasDrogras2.IsPrimaryKey = false;
                colvarOtrasDrogras2.IsForeignKey = false;
                colvarOtrasDrogras2.IsReadOnly = false;
                
                schema.Columns.Add(colvarOtrasDrogras2);
                
                TableSchema.TableColumn colvarDosisODrogas2 = new TableSchema.TableColumn(schema);
                colvarDosisODrogas2.ColumnName = "dosisODrogas2";
                colvarDosisODrogas2.DataType = DbType.Decimal;
                colvarDosisODrogas2.MaxLength = 0;
                colvarDosisODrogas2.AutoIncrement = false;
                colvarDosisODrogas2.IsNullable = false;
                colvarDosisODrogas2.IsPrimaryKey = false;
                colvarDosisODrogas2.IsForeignKey = false;
                colvarDosisODrogas2.IsReadOnly = false;
                
                schema.Columns.Add(colvarDosisODrogas2);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("REM_Clasificados",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public RemClasificado()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public RemClasificado(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public RemClasificado(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public RemClasificado(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Apellido")]
        [Bindable(true)]
        public string Apellido 
	    {
		    get
		    {
			    return GetColumnValue<string>("apellido");
		    }
            set 
		    {
			    SetColumnValue("apellido", value);
            }
        }
	      
        [XmlAttribute("Nombre")]
        [Bindable(true)]
        public string Nombre 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombre");
		    }
            set 
		    {
			    SetColumnValue("nombre", value);
            }
        }
	      
        [XmlAttribute("NumeroDocumento")]
        [Bindable(true)]
        public int NumeroDocumento 
	    {
		    get
		    {
			    return GetColumnValue<int>("numeroDocumento");
		    }
            set 
		    {
			    SetColumnValue("numeroDocumento", value);
            }
        }
	      
        [XmlAttribute("Sexo")]
        [Bindable(true)]
        public string Sexo 
	    {
		    get
		    {
			    return GetColumnValue<string>("Sexo");
		    }
            set 
		    {
			    SetColumnValue("Sexo", value);
            }
        }
	      
        [XmlAttribute("FechaNacimiento")]
        [Bindable(true)]
        public DateTime FechaNacimiento 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fechaNacimiento");
		    }
            set 
		    {
			    SetColumnValue("fechaNacimiento", value);
            }
        }
	      
        [XmlAttribute("FechaControl")]
        [Bindable(true)]
        public DateTime FechaControl 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fechaControl");
		    }
            set 
		    {
			    SetColumnValue("fechaControl", value);
            }
        }
	      
        [XmlAttribute("Calle")]
        [Bindable(true)]
        public string Calle 
	    {
		    get
		    {
			    return GetColumnValue<string>("calle");
		    }
            set 
		    {
			    SetColumnValue("calle", value);
            }
        }
	      
        [XmlAttribute("Numero")]
        [Bindable(true)]
        public int Numero 
	    {
		    get
		    {
			    return GetColumnValue<int>("numero");
		    }
            set 
		    {
			    SetColumnValue("numero", value);
            }
        }
	      
        [XmlAttribute("Manzana")]
        [Bindable(true)]
        public string Manzana 
	    {
		    get
		    {
			    return GetColumnValue<string>("manzana");
		    }
            set 
		    {
			    SetColumnValue("manzana", value);
            }
        }
	      
        [XmlAttribute("Piso")]
        [Bindable(true)]
        public string Piso 
	    {
		    get
		    {
			    return GetColumnValue<string>("piso");
		    }
            set 
		    {
			    SetColumnValue("piso", value);
            }
        }
	      
        [XmlAttribute("Departamento")]
        [Bindable(true)]
        public string Departamento 
	    {
		    get
		    {
			    return GetColumnValue<string>("departamento");
		    }
            set 
		    {
			    SetColumnValue("departamento", value);
            }
        }
	      
        [XmlAttribute("IdBarrio")]
        [Bindable(true)]
        public int IdBarrio 
	    {
		    get
		    {
			    return GetColumnValue<int>("idBarrio");
		    }
            set 
		    {
			    SetColumnValue("idBarrio", value);
            }
        }
	      
        [XmlAttribute("IdLocalidad")]
        [Bindable(true)]
        public int IdLocalidad 
	    {
		    get
		    {
			    return GetColumnValue<int>("idLocalidad");
		    }
            set 
		    {
			    SetColumnValue("idLocalidad", value);
            }
        }
	      
        [XmlAttribute("IdProvinciaDomicilio")]
        [Bindable(true)]
        public int IdProvinciaDomicilio 
	    {
		    get
		    {
			    return GetColumnValue<int>("idProvinciaDomicilio");
		    }
            set 
		    {
			    SetColumnValue("idProvinciaDomicilio", value);
            }
        }
	      
        [XmlAttribute("InformacionContacto")]
        [Bindable(true)]
        public string InformacionContacto 
	    {
		    get
		    {
			    return GetColumnValue<string>("informacionContacto");
		    }
            set 
		    {
			    SetColumnValue("informacionContacto", value);
            }
        }
	      
        [XmlAttribute("ModifiedOn")]
        [Bindable(true)]
        public DateTime ModifiedOn 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("ModifiedOn");
		    }
            set 
		    {
			    SetColumnValue("ModifiedOn", value);
            }
        }
	      
        [XmlAttribute("IdObraSocial")]
        [Bindable(true)]
        public int IdObraSocial 
	    {
		    get
		    {
			    return GetColumnValue<int>("idObraSocial");
		    }
            set 
		    {
			    SetColumnValue("idObraSocial", value);
            }
        }
	      
        [XmlAttribute("Antecedente")]
        [Bindable(true)]
        public string Antecedente 
	    {
		    get
		    {
			    return GetColumnValue<string>("Antecedente");
		    }
            set 
		    {
			    SetColumnValue("Antecedente", value);
            }
        }
	      
        [XmlAttribute("Imc")]
        [Bindable(true)]
        public decimal Imc 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("Imc");
		    }
            set 
		    {
			    SetColumnValue("Imc", value);
            }
        }
	      
        [XmlAttribute("RiesgoCardiovascular")]
        [Bindable(true)]
        public int RiesgoCardiovascular 
	    {
		    get
		    {
			    return GetColumnValue<int>("riesgoCardiovascular");
		    }
            set 
		    {
			    SetColumnValue("riesgoCardiovascular", value);
            }
        }
	      
        [XmlAttribute("TAS")]
        [Bindable(true)]
        public int TAS 
	    {
		    get
		    {
			    return GetColumnValue<int>("tAS");
		    }
            set 
		    {
			    SetColumnValue("tAS", value);
            }
        }
	      
        [XmlAttribute("TAD")]
        [Bindable(true)]
        public int TAD 
	    {
		    get
		    {
			    return GetColumnValue<int>("tAD");
		    }
            set 
		    {
			    SetColumnValue("tAD", value);
            }
        }
	      
        [XmlAttribute("ColesterolTotal")]
        [Bindable(true)]
        public decimal ColesterolTotal 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("colesterolTotal");
		    }
            set 
		    {
			    SetColumnValue("colesterolTotal", value);
            }
        }
	      
        [XmlAttribute("UnidadColTotal")]
        [Bindable(true)]
        public string UnidadColTotal 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidadColTotal");
		    }
            set 
		    {
			    SetColumnValue("unidadColTotal", value);
            }
        }
	      
        [XmlAttribute("Hdl")]
        [Bindable(true)]
        public decimal Hdl 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("HDL");
		    }
            set 
		    {
			    SetColumnValue("HDL", value);
            }
        }
	      
        [XmlAttribute("UnidadHDL")]
        [Bindable(true)]
        public string UnidadHDL 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidadHDL");
		    }
            set 
		    {
			    SetColumnValue("unidadHDL", value);
            }
        }
	      
        [XmlAttribute("Ldl")]
        [Bindable(true)]
        public decimal Ldl 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("LDL");
		    }
            set 
		    {
			    SetColumnValue("LDL", value);
            }
        }
	      
        [XmlAttribute("UnidadLDL")]
        [Bindable(true)]
        public string UnidadLDL 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidadLDL");
		    }
            set 
		    {
			    SetColumnValue("unidadLDL", value);
            }
        }
	      
        [XmlAttribute("Tgl")]
        [Bindable(true)]
        public decimal Tgl 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("TGL");
		    }
            set 
		    {
			    SetColumnValue("TGL", value);
            }
        }
	      
        [XmlAttribute("UnidadTGL")]
        [Bindable(true)]
        public string UnidadTGL 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidadTGL");
		    }
            set 
		    {
			    SetColumnValue("unidadTGL", value);
            }
        }
	      
        [XmlAttribute("Glucemia")]
        [Bindable(true)]
        public decimal Glucemia 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("glucemia");
		    }
            set 
		    {
			    SetColumnValue("glucemia", value);
            }
        }
	      
        [XmlAttribute("UnidadGlucemia")]
        [Bindable(true)]
        public string UnidadGlucemia 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidadGlucemia");
		    }
            set 
		    {
			    SetColumnValue("unidadGlucemia", value);
            }
        }
	      
        [XmlAttribute("HbAc1")]
        [Bindable(true)]
        public decimal HbAc1 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("HbAc1");
		    }
            set 
		    {
			    SetColumnValue("HbAc1", value);
            }
        }
	      
        [XmlAttribute("Dosis")]
        [Bindable(true)]
        public double Dosis 
	    {
		    get
		    {
			    return GetColumnValue<double>("dosis");
		    }
            set 
		    {
			    SetColumnValue("dosis", value);
            }
        }
	      
        [XmlAttribute("Medicamentos")]
        [Bindable(true)]
        public string Medicamentos 
	    {
		    get
		    {
			    return GetColumnValue<string>("Medicamentos");
		    }
            set 
		    {
			    SetColumnValue("Medicamentos", value);
            }
        }
	      
        [XmlAttribute("NombreInsulina")]
        [Bindable(true)]
        public string NombreInsulina 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombreInsulina");
		    }
            set 
		    {
			    SetColumnValue("nombreInsulina", value);
            }
        }
	      
        [XmlAttribute("OtrasDrogas1")]
        [Bindable(true)]
        public string OtrasDrogas1 
	    {
		    get
		    {
			    return GetColumnValue<string>("otrasDrogas1");
		    }
            set 
		    {
			    SetColumnValue("otrasDrogas1", value);
            }
        }
	      
        [XmlAttribute("DosisODrogas1")]
        [Bindable(true)]
        public decimal DosisODrogas1 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("dosisODrogas1");
		    }
            set 
		    {
			    SetColumnValue("dosisODrogas1", value);
            }
        }
	      
        [XmlAttribute("OtrasDrogras2")]
        [Bindable(true)]
        public string OtrasDrogras2 
	    {
		    get
		    {
			    return GetColumnValue<string>("otrasDrogras2");
		    }
            set 
		    {
			    SetColumnValue("otrasDrogras2", value);
            }
        }
	      
        [XmlAttribute("DosisODrogas2")]
        [Bindable(true)]
        public decimal DosisODrogas2 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("dosisODrogas2");
		    }
            set 
		    {
			    SetColumnValue("dosisODrogas2", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Apellido = @"apellido";
            
            public static string Nombre = @"nombre";
            
            public static string NumeroDocumento = @"numeroDocumento";
            
            public static string Sexo = @"Sexo";
            
            public static string FechaNacimiento = @"fechaNacimiento";
            
            public static string FechaControl = @"fechaControl";
            
            public static string Calle = @"calle";
            
            public static string Numero = @"numero";
            
            public static string Manzana = @"manzana";
            
            public static string Piso = @"piso";
            
            public static string Departamento = @"departamento";
            
            public static string IdBarrio = @"idBarrio";
            
            public static string IdLocalidad = @"idLocalidad";
            
            public static string IdProvinciaDomicilio = @"idProvinciaDomicilio";
            
            public static string InformacionContacto = @"informacionContacto";
            
            public static string ModifiedOn = @"ModifiedOn";
            
            public static string IdObraSocial = @"idObraSocial";
            
            public static string Antecedente = @"Antecedente";
            
            public static string Imc = @"Imc";
            
            public static string RiesgoCardiovascular = @"riesgoCardiovascular";
            
            public static string TAS = @"tAS";
            
            public static string TAD = @"tAD";
            
            public static string ColesterolTotal = @"colesterolTotal";
            
            public static string UnidadColTotal = @"unidadColTotal";
            
            public static string Hdl = @"HDL";
            
            public static string UnidadHDL = @"unidadHDL";
            
            public static string Ldl = @"LDL";
            
            public static string UnidadLDL = @"unidadLDL";
            
            public static string Tgl = @"TGL";
            
            public static string UnidadTGL = @"unidadTGL";
            
            public static string Glucemia = @"glucemia";
            
            public static string UnidadGlucemia = @"unidadGlucemia";
            
            public static string HbAc1 = @"HbAc1";
            
            public static string Dosis = @"dosis";
            
            public static string Medicamentos = @"Medicamentos";
            
            public static string NombreInsulina = @"nombreInsulina";
            
            public static string OtrasDrogas1 = @"otrasDrogas1";
            
            public static string DosisODrogas1 = @"dosisODrogas1";
            
            public static string OtrasDrogras2 = @"otrasDrogras2";
            
            public static string DosisODrogas2 = @"dosisODrogas2";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
