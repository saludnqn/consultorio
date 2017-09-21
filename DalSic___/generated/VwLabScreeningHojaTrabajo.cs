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
    /// Strongly-typed collection for the VwLabScreeningHojaTrabajo class.
    /// </summary>
    [Serializable]
    public partial class VwLabScreeningHojaTrabajoCollection : ReadOnlyList<VwLabScreeningHojaTrabajo, VwLabScreeningHojaTrabajoCollection>
    {        
        public VwLabScreeningHojaTrabajoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vw_LAB_ScreeningHojaTrabajo view.
    /// </summary>
    [Serializable]
    public partial class VwLabScreeningHojaTrabajo : ReadOnlyRecord<VwLabScreeningHojaTrabajo>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vw_LAB_ScreeningHojaTrabajo", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
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
                
                TableSchema.TableColumn colvarIditem = new TableSchema.TableColumn(schema);
                colvarIditem.ColumnName = "iditem";
                colvarIditem.DataType = DbType.Int32;
                colvarIditem.MaxLength = 0;
                colvarIditem.AutoIncrement = false;
                colvarIditem.IsNullable = false;
                colvarIditem.IsPrimaryKey = false;
                colvarIditem.IsForeignKey = false;
                colvarIditem.IsReadOnly = false;
                
                schema.Columns.Add(colvarIditem);
                
                TableSchema.TableColumn colvarItem = new TableSchema.TableColumn(schema);
                colvarItem.ColumnName = "item";
                colvarItem.DataType = DbType.String;
                colvarItem.MaxLength = 50;
                colvarItem.AutoIncrement = false;
                colvarItem.IsNullable = false;
                colvarItem.IsPrimaryKey = false;
                colvarItem.IsForeignKey = false;
                colvarItem.IsReadOnly = false;
                
                schema.Columns.Add(colvarItem);
                
                TableSchema.TableColumn colvarResultado = new TableSchema.TableColumn(schema);
                colvarResultado.ColumnName = "resultado";
                colvarResultado.DataType = DbType.String;
                colvarResultado.MaxLength = 500;
                colvarResultado.AutoIncrement = false;
                colvarResultado.IsNullable = false;
                colvarResultado.IsPrimaryKey = false;
                colvarResultado.IsForeignKey = false;
                colvarResultado.IsReadOnly = false;
                
                schema.Columns.Add(colvarResultado);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("vw_LAB_ScreeningHojaTrabajo",schema);
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
	    public VwLabScreeningHojaTrabajo()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwLabScreeningHojaTrabajo(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwLabScreeningHojaTrabajo(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwLabScreeningHojaTrabajo(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
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
	      
        [XmlAttribute("Iditem")]
        [Bindable(true)]
        public int Iditem 
	    {
		    get
		    {
			    return GetColumnValue<int>("iditem");
		    }
            set 
		    {
			    SetColumnValue("iditem", value);
            }
        }
	      
        [XmlAttribute("Item")]
        [Bindable(true)]
        public string Item 
	    {
		    get
		    {
			    return GetColumnValue<string>("item");
		    }
            set 
		    {
			    SetColumnValue("item", value);
            }
        }
	      
        [XmlAttribute("Resultado")]
        [Bindable(true)]
        public string Resultado 
	    {
		    get
		    {
			    return GetColumnValue<string>("resultado");
		    }
            set 
		    {
			    SetColumnValue("resultado", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Numero = @"numero";
            
            public static string Iditem = @"iditem";
            
            public static string Item = @"item";
            
            public static string Resultado = @"resultado";
            
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
