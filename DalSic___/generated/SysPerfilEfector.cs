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
    /// Strongly-typed collection for the SysPerfilEfector class.
    /// </summary>
    [Serializable]
    public partial class SysPerfilEfectorCollection : ReadOnlyList<SysPerfilEfector, SysPerfilEfectorCollection>
    {        
        public SysPerfilEfectorCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the SYS_PerfilEfector view.
    /// </summary>
    [Serializable]
    public partial class SysPerfilEfector : ReadOnlyRecord<SysPerfilEfector>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("SYS_PerfilEfector", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdPerfil = new TableSchema.TableColumn(schema);
                colvarIdPerfil.ColumnName = "idPerfil";
                colvarIdPerfil.DataType = DbType.Int32;
                colvarIdPerfil.MaxLength = 0;
                colvarIdPerfil.AutoIncrement = false;
                colvarIdPerfil.IsNullable = false;
                colvarIdPerfil.IsPrimaryKey = false;
                colvarIdPerfil.IsForeignKey = false;
                colvarIdPerfil.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdPerfil);
                
                TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
                colvarNombre.ColumnName = "nombre";
                colvarNombre.DataType = DbType.String;
                colvarNombre.MaxLength = 50;
                colvarNombre.AutoIncrement = false;
                colvarNombre.IsNullable = false;
                colvarNombre.IsPrimaryKey = false;
                colvarNombre.IsForeignKey = false;
                colvarNombre.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombre);
                
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
                colvarEfector.ColumnName = "efector";
                colvarEfector.DataType = DbType.String;
                colvarEfector.MaxLength = 100;
                colvarEfector.AutoIncrement = false;
                colvarEfector.IsNullable = false;
                colvarEfector.IsPrimaryKey = false;
                colvarEfector.IsForeignKey = false;
                colvarEfector.IsReadOnly = false;
                
                schema.Columns.Add(colvarEfector);
                
                TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
                colvarActivo.ColumnName = "activo";
                colvarActivo.DataType = DbType.Boolean;
                colvarActivo.MaxLength = 0;
                colvarActivo.AutoIncrement = false;
                colvarActivo.IsNullable = false;
                colvarActivo.IsPrimaryKey = false;
                colvarActivo.IsForeignKey = false;
                colvarActivo.IsReadOnly = false;
                
                schema.Columns.Add(colvarActivo);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("SYS_PerfilEfector",schema);
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
	    public SysPerfilEfector()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public SysPerfilEfector(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public SysPerfilEfector(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public SysPerfilEfector(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdPerfil")]
        [Bindable(true)]
        public int IdPerfil 
	    {
		    get
		    {
			    return GetColumnValue<int>("idPerfil");
		    }
            set 
		    {
			    SetColumnValue("idPerfil", value);
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
			    return GetColumnValue<string>("efector");
		    }
            set 
		    {
			    SetColumnValue("efector", value);
            }
        }
	      
        [XmlAttribute("Activo")]
        [Bindable(true)]
        public bool Activo 
	    {
		    get
		    {
			    return GetColumnValue<bool>("activo");
		    }
            set 
		    {
			    SetColumnValue("activo", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdPerfil = @"idPerfil";
            
            public static string Nombre = @"nombre";
            
            public static string IdEfector = @"idEfector";
            
            public static string Efector = @"efector";
            
            public static string Activo = @"activo";
            
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
