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
    /// Strongly-typed collection for the PnCantidadNin class.
    /// </summary>
    [Serializable]
    public partial class PnCantidadNinCollection : ReadOnlyList<PnCantidadNin, PnCantidadNinCollection>
    {        
        public PnCantidadNinCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the PN_CantidadNin view.
    /// </summary>
    [Serializable]
    public partial class PnCantidadNin : ReadOnlyRecord<PnCantidadNin>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("PN_CantidadNin", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarClave = new TableSchema.TableColumn(schema);
                colvarClave.ColumnName = "clave";
                colvarClave.DataType = DbType.AnsiString;
                colvarClave.MaxLength = -1;
                colvarClave.AutoIncrement = false;
                colvarClave.IsNullable = true;
                colvarClave.IsPrimaryKey = false;
                colvarClave.IsForeignKey = false;
                colvarClave.IsReadOnly = false;
                
                schema.Columns.Add(colvarClave);
                
                TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
                colvarCantidad.ColumnName = "cantidad";
                colvarCantidad.DataType = DbType.Int32;
                colvarCantidad.MaxLength = 0;
                colvarCantidad.AutoIncrement = false;
                colvarCantidad.IsNullable = true;
                colvarCantidad.IsPrimaryKey = false;
                colvarCantidad.IsForeignKey = false;
                colvarCantidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarCantidad);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("PN_CantidadNin",schema);
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
	    public PnCantidadNin()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public PnCantidadNin(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public PnCantidadNin(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public PnCantidadNin(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Clave")]
        [Bindable(true)]
        public string Clave 
	    {
		    get
		    {
			    return GetColumnValue<string>("clave");
		    }
            set 
		    {
			    SetColumnValue("clave", value);
            }
        }
	      
        [XmlAttribute("Cantidad")]
        [Bindable(true)]
        public int? Cantidad 
	    {
		    get
		    {
			    return GetColumnValue<int?>("cantidad");
		    }
            set 
		    {
			    SetColumnValue("cantidad", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Clave = @"clave";
            
            public static string Cantidad = @"cantidad";
            
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
