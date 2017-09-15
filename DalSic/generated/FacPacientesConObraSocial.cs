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
    /// Strongly-typed collection for the FacPacientesConObraSocial class.
    /// </summary>
    [Serializable]
    public partial class FacPacientesConObraSocialCollection : ReadOnlyList<FacPacientesConObraSocial, FacPacientesConObraSocialCollection>
    {        
        public FacPacientesConObraSocialCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the FAC_PacientesConObraSocial view.
    /// </summary>
    [Serializable]
    public partial class FacPacientesConObraSocial : ReadOnlyRecord<FacPacientesConObraSocial>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("FAC_PacientesConObraSocial", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
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
                
                TableSchema.TableColumn colvarIdSexo = new TableSchema.TableColumn(schema);
                colvarIdSexo.ColumnName = "idSexo";
                colvarIdSexo.DataType = DbType.Int32;
                colvarIdSexo.MaxLength = 0;
                colvarIdSexo.AutoIncrement = false;
                colvarIdSexo.IsNullable = false;
                colvarIdSexo.IsPrimaryKey = false;
                colvarIdSexo.IsForeignKey = false;
                colvarIdSexo.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdSexo);
                
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
                
                TableSchema.TableColumn colvarObraSocial = new TableSchema.TableColumn(schema);
                colvarObraSocial.ColumnName = "ObraSocial";
                colvarObraSocial.DataType = DbType.String;
                colvarObraSocial.MaxLength = 200;
                colvarObraSocial.AutoIncrement = false;
                colvarObraSocial.IsNullable = false;
                colvarObraSocial.IsPrimaryKey = false;
                colvarObraSocial.IsForeignKey = false;
                colvarObraSocial.IsReadOnly = false;
                
                schema.Columns.Add(colvarObraSocial);
                
                TableSchema.TableColumn colvarSigla = new TableSchema.TableColumn(schema);
                colvarSigla.ColumnName = "sigla";
                colvarSigla.DataType = DbType.String;
                colvarSigla.MaxLength = 50;
                colvarSigla.AutoIncrement = false;
                colvarSigla.IsNullable = false;
                colvarSigla.IsPrimaryKey = false;
                colvarSigla.IsForeignKey = false;
                colvarSigla.IsReadOnly = false;
                
                schema.Columns.Add(colvarSigla);
                
                TableSchema.TableColumn colvarNumeroAfiliado = new TableSchema.TableColumn(schema);
                colvarNumeroAfiliado.ColumnName = "numeroAfiliado";
                colvarNumeroAfiliado.DataType = DbType.AnsiString;
                colvarNumeroAfiliado.MaxLength = 50;
                colvarNumeroAfiliado.AutoIncrement = false;
                colvarNumeroAfiliado.IsNullable = false;
                colvarNumeroAfiliado.IsPrimaryKey = false;
                colvarNumeroAfiliado.IsForeignKey = false;
                colvarNumeroAfiliado.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroAfiliado);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("FAC_PacientesConObraSocial",schema);
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
	    public FacPacientesConObraSocial()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public FacPacientesConObraSocial(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public FacPacientesConObraSocial(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public FacPacientesConObraSocial(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
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
	      
        [XmlAttribute("IdSexo")]
        [Bindable(true)]
        public int IdSexo 
	    {
		    get
		    {
			    return GetColumnValue<int>("idSexo");
		    }
            set 
		    {
			    SetColumnValue("idSexo", value);
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
	      
        [XmlAttribute("ObraSocial")]
        [Bindable(true)]
        public string ObraSocial 
	    {
		    get
		    {
			    return GetColumnValue<string>("ObraSocial");
		    }
            set 
		    {
			    SetColumnValue("ObraSocial", value);
            }
        }
	      
        [XmlAttribute("Sigla")]
        [Bindable(true)]
        public string Sigla 
	    {
		    get
		    {
			    return GetColumnValue<string>("sigla");
		    }
            set 
		    {
			    SetColumnValue("sigla", value);
            }
        }
	      
        [XmlAttribute("NumeroAfiliado")]
        [Bindable(true)]
        public string NumeroAfiliado 
	    {
		    get
		    {
			    return GetColumnValue<string>("numeroAfiliado");
		    }
            set 
		    {
			    SetColumnValue("numeroAfiliado", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string NumeroDocumento = @"numeroDocumento";
            
            public static string Apellido = @"apellido";
            
            public static string Nombre = @"nombre";
            
            public static string IdSexo = @"idSexo";
            
            public static string FechaNacimiento = @"fechaNacimiento";
            
            public static string IdObraSocial = @"idObraSocial";
            
            public static string ObraSocial = @"ObraSocial";
            
            public static string Sigla = @"sigla";
            
            public static string NumeroAfiliado = @"numeroAfiliado";
            
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
