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
    /// Strongly-typed collection for the GuardiaUltimoTriage class.
    /// </summary>
    [Serializable]
    public partial class GuardiaUltimoTriageCollection : ReadOnlyList<GuardiaUltimoTriage, GuardiaUltimoTriageCollection>
    {        
        public GuardiaUltimoTriageCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the Guardia_Ultimo_Triage view.
    /// </summary>
    [Serializable]
    public partial class GuardiaUltimoTriage : ReadOnlyRecord<GuardiaUltimoTriage>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("Guardia_Ultimo_Triage", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "id";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
                colvarIdClasificacion.ColumnName = "idClasificacion";
                colvarIdClasificacion.DataType = DbType.Int32;
                colvarIdClasificacion.MaxLength = 0;
                colvarIdClasificacion.AutoIncrement = false;
                colvarIdClasificacion.IsNullable = true;
                colvarIdClasificacion.IsPrimaryKey = false;
                colvarIdClasificacion.IsForeignKey = false;
                colvarIdClasificacion.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdClasificacion);
                
                TableSchema.TableColumn colvarRegistroGuardia = new TableSchema.TableColumn(schema);
                colvarRegistroGuardia.ColumnName = "registroGuardia";
                colvarRegistroGuardia.DataType = DbType.Int32;
                colvarRegistroGuardia.MaxLength = 0;
                colvarRegistroGuardia.AutoIncrement = false;
                colvarRegistroGuardia.IsNullable = false;
                colvarRegistroGuardia.IsPrimaryKey = false;
                colvarRegistroGuardia.IsForeignKey = false;
                colvarRegistroGuardia.IsReadOnly = false;
                
                schema.Columns.Add(colvarRegistroGuardia);
                
                TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
                colvarFechaHora.ColumnName = "fechaHora";
                colvarFechaHora.DataType = DbType.DateTime;
                colvarFechaHora.MaxLength = 0;
                colvarFechaHora.AutoIncrement = false;
                colvarFechaHora.IsNullable = false;
                colvarFechaHora.IsPrimaryKey = false;
                colvarFechaHora.IsForeignKey = false;
                colvarFechaHora.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaHora);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("Guardia_Ultimo_Triage",schema);
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
	    public GuardiaUltimoTriage()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public GuardiaUltimoTriage(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public GuardiaUltimoTriage(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public GuardiaUltimoTriage(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public int Id 
	    {
		    get
		    {
			    return GetColumnValue<int>("id");
		    }
            set 
		    {
			    SetColumnValue("id", value);
            }
        }
	      
        [XmlAttribute("IdClasificacion")]
        [Bindable(true)]
        public int? IdClasificacion 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idClasificacion");
		    }
            set 
		    {
			    SetColumnValue("idClasificacion", value);
            }
        }
	      
        [XmlAttribute("RegistroGuardia")]
        [Bindable(true)]
        public int RegistroGuardia 
	    {
		    get
		    {
			    return GetColumnValue<int>("registroGuardia");
		    }
            set 
		    {
			    SetColumnValue("registroGuardia", value);
            }
        }
	      
        [XmlAttribute("FechaHora")]
        [Bindable(true)]
        public DateTime FechaHora 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fechaHora");
		    }
            set 
		    {
			    SetColumnValue("fechaHora", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"id";
            
            public static string IdClasificacion = @"idClasificacion";
            
            public static string RegistroGuardia = @"registroGuardia";
            
            public static string FechaHora = @"fechaHora";
            
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
