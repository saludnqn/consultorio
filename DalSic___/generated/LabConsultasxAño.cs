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
    /// Strongly-typed collection for the LabConsultasxAño class.
    /// </summary>
    [Serializable]
    public partial class LabConsultasxAñoCollection : ReadOnlyList<LabConsultasxAño, LabConsultasxAñoCollection>
    {        
        public LabConsultasxAñoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the LAB_ConsultasxAño view.
    /// </summary>
    [Serializable]
    public partial class LabConsultasxAño : ReadOnlyRecord<LabConsultasxAño>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("LAB_ConsultasxAño", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarMes = new TableSchema.TableColumn(schema);
                colvarMes.ColumnName = "mes";
                colvarMes.DataType = DbType.Int32;
                colvarMes.MaxLength = 0;
                colvarMes.AutoIncrement = false;
                colvarMes.IsNullable = true;
                colvarMes.IsPrimaryKey = false;
                colvarMes.IsForeignKey = false;
                colvarMes.IsReadOnly = false;
                
                schema.Columns.Add(colvarMes);
                
                TableSchema.TableColumn colvar_2011 = new TableSchema.TableColumn(schema);
                colvar_2011.ColumnName = "2011";
                colvar_2011.DataType = DbType.Int32;
                colvar_2011.MaxLength = 0;
                colvar_2011.AutoIncrement = false;
                colvar_2011.IsNullable = true;
                colvar_2011.IsPrimaryKey = false;
                colvar_2011.IsForeignKey = false;
                colvar_2011.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2011);
                
                TableSchema.TableColumn colvar_2012 = new TableSchema.TableColumn(schema);
                colvar_2012.ColumnName = "2012";
                colvar_2012.DataType = DbType.Int32;
                colvar_2012.MaxLength = 0;
                colvar_2012.AutoIncrement = false;
                colvar_2012.IsNullable = true;
                colvar_2012.IsPrimaryKey = false;
                colvar_2012.IsForeignKey = false;
                colvar_2012.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2012);
                
                TableSchema.TableColumn colvar_2013 = new TableSchema.TableColumn(schema);
                colvar_2013.ColumnName = "2013";
                colvar_2013.DataType = DbType.Int32;
                colvar_2013.MaxLength = 0;
                colvar_2013.AutoIncrement = false;
                colvar_2013.IsNullable = true;
                colvar_2013.IsPrimaryKey = false;
                colvar_2013.IsForeignKey = false;
                colvar_2013.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2013);
                
                TableSchema.TableColumn colvar_2014 = new TableSchema.TableColumn(schema);
                colvar_2014.ColumnName = "2014";
                colvar_2014.DataType = DbType.Int32;
                colvar_2014.MaxLength = 0;
                colvar_2014.AutoIncrement = false;
                colvar_2014.IsNullable = true;
                colvar_2014.IsPrimaryKey = false;
                colvar_2014.IsForeignKey = false;
                colvar_2014.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2014);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("LAB_ConsultasxAño",schema);
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
	    public LabConsultasxAño()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public LabConsultasxAño(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public LabConsultasxAño(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public LabConsultasxAño(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Mes")]
        [Bindable(true)]
        public int? Mes 
	    {
		    get
		    {
			    return GetColumnValue<int?>("mes");
		    }
            set 
		    {
			    SetColumnValue("mes", value);
            }
        }
	      
        [XmlAttribute("_2011")]
        [Bindable(true)]
        public int? _2011 
	    {
		    get
		    {
			    return GetColumnValue<int?>("2011");
		    }
            set 
		    {
			    SetColumnValue("2011", value);
            }
        }
	      
        [XmlAttribute("_2012")]
        [Bindable(true)]
        public int? _2012 
	    {
		    get
		    {
			    return GetColumnValue<int?>("2012");
		    }
            set 
		    {
			    SetColumnValue("2012", value);
            }
        }
	      
        [XmlAttribute("_2013")]
        [Bindable(true)]
        public int? _2013 
	    {
		    get
		    {
			    return GetColumnValue<int?>("2013");
		    }
            set 
		    {
			    SetColumnValue("2013", value);
            }
        }
	      
        [XmlAttribute("_2014")]
        [Bindable(true)]
        public int? _2014 
	    {
		    get
		    {
			    return GetColumnValue<int?>("2014");
		    }
            set 
		    {
			    SetColumnValue("2014", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Mes = @"mes";
            
            public static string _2011 = @"2011";
            
            public static string _2012 = @"2012";
            
            public static string _2013 = @"2013";
            
            public static string _2014 = @"2014";
            
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
