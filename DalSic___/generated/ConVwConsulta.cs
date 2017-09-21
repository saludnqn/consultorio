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
    /// Strongly-typed collection for the ConVwConsulta class.
    /// </summary>
    [Serializable]
    public partial class ConVwConsultaCollection : ReadOnlyList<ConVwConsulta, ConVwConsultaCollection>
    {        
        public ConVwConsultaCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_VwConsultas view.
    /// </summary>
    [Serializable]
    public partial class ConVwConsulta : ReadOnlyRecord<ConVwConsulta>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_VwConsultas", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
                colvarIdEfector.ColumnName = "idEfector";
                colvarIdEfector.DataType = DbType.Int32;
                colvarIdEfector.MaxLength = 0;
                colvarIdEfector.AutoIncrement = false;
                colvarIdEfector.IsNullable = false;
                colvarIdEfector.IsPrimaryKey = false;
                colvarIdEfector.IsForeignKey = false;
                colvarIdEfector.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdEfector);
                
                TableSchema.TableColumn colvarEfector = new TableSchema.TableColumn(schema);
                colvarEfector.ColumnName = "Efector";
                colvarEfector.DataType = DbType.String;
                colvarEfector.MaxLength = 100;
                colvarEfector.AutoIncrement = false;
                colvarEfector.IsNullable = false;
                colvarEfector.IsPrimaryKey = false;
                colvarEfector.IsForeignKey = false;
                colvarEfector.IsReadOnly = false;
                
                schema.Columns.Add(colvarEfector);
                
                TableSchema.TableColumn colvarEspecialidad = new TableSchema.TableColumn(schema);
                colvarEspecialidad.ColumnName = "Especialidad";
                colvarEspecialidad.DataType = DbType.String;
                colvarEspecialidad.MaxLength = 50;
                colvarEspecialidad.AutoIncrement = false;
                colvarEspecialidad.IsNullable = false;
                colvarEspecialidad.IsPrimaryKey = false;
                colvarEspecialidad.IsForeignKey = false;
                colvarEspecialidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarEspecialidad);
                
                TableSchema.TableColumn colvarProfesional = new TableSchema.TableColumn(schema);
                colvarProfesional.ColumnName = "Profesional";
                colvarProfesional.DataType = DbType.String;
                colvarProfesional.MaxLength = 102;
                colvarProfesional.AutoIncrement = false;
                colvarProfesional.IsNullable = true;
                colvarProfesional.IsPrimaryKey = false;
                colvarProfesional.IsForeignKey = false;
                colvarProfesional.IsReadOnly = false;
                
                schema.Columns.Add(colvarProfesional);
                
                TableSchema.TableColumn colvarIdTipoProfesional = new TableSchema.TableColumn(schema);
                colvarIdTipoProfesional.ColumnName = "idTipoProfesional";
                colvarIdTipoProfesional.DataType = DbType.Int32;
                colvarIdTipoProfesional.MaxLength = 0;
                colvarIdTipoProfesional.AutoIncrement = false;
                colvarIdTipoProfesional.IsNullable = true;
                colvarIdTipoProfesional.IsPrimaryKey = false;
                colvarIdTipoProfesional.IsForeignKey = false;
                colvarIdTipoProfesional.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdTipoProfesional);
                
                TableSchema.TableColumn colvarTipoProfesional = new TableSchema.TableColumn(schema);
                colvarTipoProfesional.ColumnName = "TipoProfesional";
                colvarTipoProfesional.DataType = DbType.AnsiString;
                colvarTipoProfesional.MaxLength = 50;
                colvarTipoProfesional.AutoIncrement = false;
                colvarTipoProfesional.IsNullable = true;
                colvarTipoProfesional.IsPrimaryKey = false;
                colvarTipoProfesional.IsForeignKey = false;
                colvarTipoProfesional.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipoProfesional);
                
                TableSchema.TableColumn colvarCODCIE10 = new TableSchema.TableColumn(schema);
                colvarCODCIE10.ColumnName = "CODCIE10";
                colvarCODCIE10.DataType = DbType.Int32;
                colvarCODCIE10.MaxLength = 0;
                colvarCODCIE10.AutoIncrement = false;
                colvarCODCIE10.IsNullable = true;
                colvarCODCIE10.IsPrimaryKey = false;
                colvarCODCIE10.IsForeignKey = false;
                colvarCODCIE10.IsReadOnly = false;
                
                schema.Columns.Add(colvarCODCIE10);
                
                TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
                colvarCodigo.ColumnName = "CODIGO";
                colvarCodigo.DataType = DbType.String;
                colvarCodigo.MaxLength = 255;
                colvarCodigo.AutoIncrement = false;
                colvarCodigo.IsNullable = true;
                colvarCodigo.IsPrimaryKey = false;
                colvarCodigo.IsForeignKey = false;
                colvarCodigo.IsReadOnly = false;
                
                schema.Columns.Add(colvarCodigo);
                
                TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
                colvarDiagnostico.ColumnName = "Diagnostico";
                colvarDiagnostico.DataType = DbType.String;
                colvarDiagnostico.MaxLength = 255;
                colvarDiagnostico.AutoIncrement = false;
                colvarDiagnostico.IsNullable = true;
                colvarDiagnostico.IsPrimaryKey = false;
                colvarDiagnostico.IsForeignKey = false;
                colvarDiagnostico.IsReadOnly = false;
                
                schema.Columns.Add(colvarDiagnostico);
                
                TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
                colvarIdConsulta.ColumnName = "idConsulta";
                colvarIdConsulta.DataType = DbType.Int32;
                colvarIdConsulta.MaxLength = 0;
                colvarIdConsulta.AutoIncrement = false;
                colvarIdConsulta.IsNullable = false;
                colvarIdConsulta.IsPrimaryKey = false;
                colvarIdConsulta.IsForeignKey = false;
                colvarIdConsulta.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdConsulta);
                
                TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
                colvarFecha.ColumnName = "fecha";
                colvarFecha.DataType = DbType.DateTime;
                colvarFecha.MaxLength = 0;
                colvarFecha.AutoIncrement = false;
                colvarFecha.IsNullable = true;
                colvarFecha.IsPrimaryKey = false;
                colvarFecha.IsForeignKey = false;
                colvarFecha.IsReadOnly = false;
                
                schema.Columns.Add(colvarFecha);
                
                TableSchema.TableColumn colvarHora = new TableSchema.TableColumn(schema);
                colvarHora.ColumnName = "hora";
                colvarHora.DataType = DbType.String;
                colvarHora.MaxLength = 10;
                colvarHora.AutoIncrement = false;
                colvarHora.IsNullable = true;
                colvarHora.IsPrimaryKey = false;
                colvarHora.IsForeignKey = false;
                colvarHora.IsReadOnly = false;
                
                schema.Columns.Add(colvarHora);
                
                TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
                colvarIdPaciente.ColumnName = "idPaciente";
                colvarIdPaciente.DataType = DbType.Int32;
                colvarIdPaciente.MaxLength = 0;
                colvarIdPaciente.AutoIncrement = false;
                colvarIdPaciente.IsNullable = true;
                colvarIdPaciente.IsPrimaryKey = false;
                colvarIdPaciente.IsForeignKey = false;
                colvarIdPaciente.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdPaciente);
                
                TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
                colvarIdEspecialidad.ColumnName = "idEspecialidad";
                colvarIdEspecialidad.DataType = DbType.Int32;
                colvarIdEspecialidad.MaxLength = 0;
                colvarIdEspecialidad.AutoIncrement = false;
                colvarIdEspecialidad.IsNullable = true;
                colvarIdEspecialidad.IsPrimaryKey = false;
                colvarIdEspecialidad.IsForeignKey = false;
                colvarIdEspecialidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdEspecialidad);
                
                TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
                colvarIdProfesional.ColumnName = "idProfesional";
                colvarIdProfesional.DataType = DbType.Int32;
                colvarIdProfesional.MaxLength = 0;
                colvarIdProfesional.AutoIncrement = false;
                colvarIdProfesional.IsNullable = true;
                colvarIdProfesional.IsPrimaryKey = false;
                colvarIdProfesional.IsForeignKey = false;
                colvarIdProfesional.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdProfesional);
                
                TableSchema.TableColumn colvarInformeConsulta = new TableSchema.TableColumn(schema);
                colvarInformeConsulta.ColumnName = "informeConsulta";
                colvarInformeConsulta.DataType = DbType.String;
                colvarInformeConsulta.MaxLength = -1;
                colvarInformeConsulta.AutoIncrement = false;
                colvarInformeConsulta.IsNullable = true;
                colvarInformeConsulta.IsPrimaryKey = false;
                colvarInformeConsulta.IsForeignKey = false;
                colvarInformeConsulta.IsReadOnly = false;
                
                schema.Columns.Add(colvarInformeConsulta);
                
                TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
                colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
                colvarIdUsuarioRegistro.DataType = DbType.Int32;
                colvarIdUsuarioRegistro.MaxLength = 0;
                colvarIdUsuarioRegistro.AutoIncrement = false;
                colvarIdUsuarioRegistro.IsNullable = true;
                colvarIdUsuarioRegistro.IsPrimaryKey = false;
                colvarIdUsuarioRegistro.IsForeignKey = false;
                colvarIdUsuarioRegistro.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdUsuarioRegistro);
                
                TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
                colvarFechaRegistro.ColumnName = "fechaRegistro";
                colvarFechaRegistro.DataType = DbType.DateTime;
                colvarFechaRegistro.MaxLength = 0;
                colvarFechaRegistro.AutoIncrement = false;
                colvarFechaRegistro.IsNullable = true;
                colvarFechaRegistro.IsPrimaryKey = false;
                colvarFechaRegistro.IsForeignKey = false;
                colvarFechaRegistro.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaRegistro);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_VwConsultas",schema);
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
	    public ConVwConsulta()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConVwConsulta(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConVwConsulta(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConVwConsulta(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdEfector")]
        [Bindable(true)]
        public int IdEfector 
	    {
		    get
		    {
			    return GetColumnValue<int>("idEfector");
		    }
            set 
		    {
			    SetColumnValue("idEfector", value);
            }
        }
	      
        [XmlAttribute("Efector")]
        [Bindable(true)]
        public string Efector 
	    {
		    get
		    {
			    return GetColumnValue<string>("Efector");
		    }
            set 
		    {
			    SetColumnValue("Efector", value);
            }
        }
	      
        [XmlAttribute("Especialidad")]
        [Bindable(true)]
        public string Especialidad 
	    {
		    get
		    {
			    return GetColumnValue<string>("Especialidad");
		    }
            set 
		    {
			    SetColumnValue("Especialidad", value);
            }
        }
	      
        [XmlAttribute("Profesional")]
        [Bindable(true)]
        public string Profesional 
	    {
		    get
		    {
			    return GetColumnValue<string>("Profesional");
		    }
            set 
		    {
			    SetColumnValue("Profesional", value);
            }
        }
	      
        [XmlAttribute("IdTipoProfesional")]
        [Bindable(true)]
        public int? IdTipoProfesional 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idTipoProfesional");
		    }
            set 
		    {
			    SetColumnValue("idTipoProfesional", value);
            }
        }
	      
        [XmlAttribute("TipoProfesional")]
        [Bindable(true)]
        public string TipoProfesional 
	    {
		    get
		    {
			    return GetColumnValue<string>("TipoProfesional");
		    }
            set 
		    {
			    SetColumnValue("TipoProfesional", value);
            }
        }
	      
        [XmlAttribute("CODCIE10")]
        [Bindable(true)]
        public int? CODCIE10 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CODCIE10");
		    }
            set 
		    {
			    SetColumnValue("CODCIE10", value);
            }
        }
	      
        [XmlAttribute("Codigo")]
        [Bindable(true)]
        public string Codigo 
	    {
		    get
		    {
			    return GetColumnValue<string>("CODIGO");
		    }
            set 
		    {
			    SetColumnValue("CODIGO", value);
            }
        }
	      
        [XmlAttribute("Diagnostico")]
        [Bindable(true)]
        public string Diagnostico 
	    {
		    get
		    {
			    return GetColumnValue<string>("Diagnostico");
		    }
            set 
		    {
			    SetColumnValue("Diagnostico", value);
            }
        }
	      
        [XmlAttribute("IdConsulta")]
        [Bindable(true)]
        public int IdConsulta 
	    {
		    get
		    {
			    return GetColumnValue<int>("idConsulta");
		    }
            set 
		    {
			    SetColumnValue("idConsulta", value);
            }
        }
	      
        [XmlAttribute("Fecha")]
        [Bindable(true)]
        public DateTime? Fecha 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("fecha");
		    }
            set 
		    {
			    SetColumnValue("fecha", value);
            }
        }
	      
        [XmlAttribute("Hora")]
        [Bindable(true)]
        public string Hora 
	    {
		    get
		    {
			    return GetColumnValue<string>("hora");
		    }
            set 
		    {
			    SetColumnValue("hora", value);
            }
        }
	      
        [XmlAttribute("IdPaciente")]
        [Bindable(true)]
        public int? IdPaciente 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idPaciente");
		    }
            set 
		    {
			    SetColumnValue("idPaciente", value);
            }
        }
	      
        [XmlAttribute("IdEspecialidad")]
        [Bindable(true)]
        public int? IdEspecialidad 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idEspecialidad");
		    }
            set 
		    {
			    SetColumnValue("idEspecialidad", value);
            }
        }
	      
        [XmlAttribute("IdProfesional")]
        [Bindable(true)]
        public int? IdProfesional 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idProfesional");
		    }
            set 
		    {
			    SetColumnValue("idProfesional", value);
            }
        }
	      
        [XmlAttribute("InformeConsulta")]
        [Bindable(true)]
        public string InformeConsulta 
	    {
		    get
		    {
			    return GetColumnValue<string>("informeConsulta");
		    }
            set 
		    {
			    SetColumnValue("informeConsulta", value);
            }
        }
	      
        [XmlAttribute("IdUsuarioRegistro")]
        [Bindable(true)]
        public int? IdUsuarioRegistro 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idUsuarioRegistro");
		    }
            set 
		    {
			    SetColumnValue("idUsuarioRegistro", value);
            }
        }
	      
        [XmlAttribute("FechaRegistro")]
        [Bindable(true)]
        public DateTime? FechaRegistro 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("fechaRegistro");
		    }
            set 
		    {
			    SetColumnValue("fechaRegistro", value);
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
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdEfector = @"idEfector";
            
            public static string Efector = @"Efector";
            
            public static string Especialidad = @"Especialidad";
            
            public static string Profesional = @"Profesional";
            
            public static string IdTipoProfesional = @"idTipoProfesional";
            
            public static string TipoProfesional = @"TipoProfesional";
            
            public static string CODCIE10 = @"CODCIE10";
            
            public static string Codigo = @"CODIGO";
            
            public static string Diagnostico = @"Diagnostico";
            
            public static string IdConsulta = @"idConsulta";
            
            public static string Fecha = @"fecha";
            
            public static string Hora = @"hora";
            
            public static string IdPaciente = @"idPaciente";
            
            public static string IdEspecialidad = @"idEspecialidad";
            
            public static string IdProfesional = @"idProfesional";
            
            public static string InformeConsulta = @"informeConsulta";
            
            public static string IdUsuarioRegistro = @"idUsuarioRegistro";
            
            public static string FechaRegistro = @"fechaRegistro";
            
            public static string NumeroDocumento = @"numeroDocumento";
            
            public static string Apellido = @"apellido";
            
            public static string Nombre = @"nombre";
            
            public static string FechaNacimiento = @"fechaNacimiento";
            
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
