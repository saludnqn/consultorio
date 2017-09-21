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
    /// Strongly-typed collection for the ConTurnoGrupoEtareo class.
    /// </summary>
    [Serializable]
    public partial class ConTurnoGrupoEtareoCollection : ReadOnlyList<ConTurnoGrupoEtareo, ConTurnoGrupoEtareoCollection>
    {        
        public ConTurnoGrupoEtareoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the Con_TurnoGrupoEtareo view.
    /// </summary>
    [Serializable]
    public partial class ConTurnoGrupoEtareo : ReadOnlyRecord<ConTurnoGrupoEtareo>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("Con_TurnoGrupoEtareo", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdTurno = new TableSchema.TableColumn(schema);
                colvarIdTurno.ColumnName = "idTurno";
                colvarIdTurno.DataType = DbType.Int32;
                colvarIdTurno.MaxLength = 0;
                colvarIdTurno.AutoIncrement = false;
                colvarIdTurno.IsNullable = false;
                colvarIdTurno.IsPrimaryKey = false;
                colvarIdTurno.IsForeignKey = false;
                colvarIdTurno.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdTurno);
                
                TableSchema.TableColumn colvar1 = new TableSchema.TableColumn(schema);
                colvar1.ColumnName = "<1";
                colvar1.DataType = DbType.Int32;
                colvar1.MaxLength = 0;
                colvar1.AutoIncrement = false;
                colvar1.IsNullable = true;
                colvar1.IsPrimaryKey = false;
                colvar1.IsForeignKey = false;
                colvar1.IsReadOnly = false;
                
                schema.Columns.Add(colvar1);
                
                TableSchema.TableColumn colvar_1 = new TableSchema.TableColumn(schema);
                colvar_1.ColumnName = "1";
                colvar_1.DataType = DbType.Int32;
                colvar_1.MaxLength = 0;
                colvar_1.AutoIncrement = false;
                colvar_1.IsNullable = true;
                colvar_1.IsPrimaryKey = false;
                colvar_1.IsForeignKey = false;
                colvar_1.IsReadOnly = false;
                
                schema.Columns.Add(colvar_1);
                
                TableSchema.TableColumn colvar2A5 = new TableSchema.TableColumn(schema);
                colvar2A5.ColumnName = "2 a 5";
                colvar2A5.DataType = DbType.Int32;
                colvar2A5.MaxLength = 0;
                colvar2A5.AutoIncrement = false;
                colvar2A5.IsNullable = true;
                colvar2A5.IsPrimaryKey = false;
                colvar2A5.IsForeignKey = false;
                colvar2A5.IsReadOnly = false;
                
                schema.Columns.Add(colvar2A5);
                
                TableSchema.TableColumn colvar6A9 = new TableSchema.TableColumn(schema);
                colvar6A9.ColumnName = "6 a 9";
                colvar6A9.DataType = DbType.Int32;
                colvar6A9.MaxLength = 0;
                colvar6A9.AutoIncrement = false;
                colvar6A9.IsNullable = true;
                colvar6A9.IsPrimaryKey = false;
                colvar6A9.IsForeignKey = false;
                colvar6A9.IsReadOnly = false;
                
                schema.Columns.Add(colvar6A9);
                
                TableSchema.TableColumn colvar10A14 = new TableSchema.TableColumn(schema);
                colvar10A14.ColumnName = "10 a 14";
                colvar10A14.DataType = DbType.Int32;
                colvar10A14.MaxLength = 0;
                colvar10A14.AutoIncrement = false;
                colvar10A14.IsNullable = true;
                colvar10A14.IsPrimaryKey = false;
                colvar10A14.IsForeignKey = false;
                colvar10A14.IsReadOnly = false;
                
                schema.Columns.Add(colvar10A14);
                
                TableSchema.TableColumn colvar15A19 = new TableSchema.TableColumn(schema);
                colvar15A19.ColumnName = "15 a 19";
                colvar15A19.DataType = DbType.Int32;
                colvar15A19.MaxLength = 0;
                colvar15A19.AutoIncrement = false;
                colvar15A19.IsNullable = true;
                colvar15A19.IsPrimaryKey = false;
                colvar15A19.IsForeignKey = false;
                colvar15A19.IsReadOnly = false;
                
                schema.Columns.Add(colvar15A19);
                
                TableSchema.TableColumn colvar20A39 = new TableSchema.TableColumn(schema);
                colvar20A39.ColumnName = "20 a 39";
                colvar20A39.DataType = DbType.Int32;
                colvar20A39.MaxLength = 0;
                colvar20A39.AutoIncrement = false;
                colvar20A39.IsNullable = true;
                colvar20A39.IsPrimaryKey = false;
                colvar20A39.IsForeignKey = false;
                colvar20A39.IsReadOnly = false;
                
                schema.Columns.Add(colvar20A39);
                
                TableSchema.TableColumn colvar40A69 = new TableSchema.TableColumn(schema);
                colvar40A69.ColumnName = "40 a 69";
                colvar40A69.DataType = DbType.Int32;
                colvar40A69.MaxLength = 0;
                colvar40A69.AutoIncrement = false;
                colvar40A69.IsNullable = true;
                colvar40A69.IsPrimaryKey = false;
                colvar40A69.IsForeignKey = false;
                colvar40A69.IsReadOnly = false;
                
                schema.Columns.Add(colvar40A69);
                
                TableSchema.TableColumn colvar70Y = new TableSchema.TableColumn(schema);
                colvar70Y.ColumnName = "70 y +";
                colvar70Y.DataType = DbType.Int32;
                colvar70Y.MaxLength = 0;
                colvar70Y.AutoIncrement = false;
                colvar70Y.IsNullable = true;
                colvar70Y.IsPrimaryKey = false;
                colvar70Y.IsForeignKey = false;
                colvar70Y.IsReadOnly = false;
                
                schema.Columns.Add(colvar70Y);
                
                TableSchema.TableColumn colvarM = new TableSchema.TableColumn(schema);
                colvarM.ColumnName = "M";
                colvarM.DataType = DbType.Int32;
                colvarM.MaxLength = 0;
                colvarM.AutoIncrement = false;
                colvarM.IsNullable = true;
                colvarM.IsPrimaryKey = false;
                colvarM.IsForeignKey = false;
                colvarM.IsReadOnly = false;
                
                schema.Columns.Add(colvarM);
                
                TableSchema.TableColumn colvarF = new TableSchema.TableColumn(schema);
                colvarF.ColumnName = "F";
                colvarF.DataType = DbType.Int32;
                colvarF.MaxLength = 0;
                colvarF.AutoIncrement = false;
                colvarF.IsNullable = true;
                colvarF.IsPrimaryKey = false;
                colvarF.IsForeignKey = false;
                colvarF.IsReadOnly = false;
                
                schema.Columns.Add(colvarF);
                
                TableSchema.TableColumn colvarI = new TableSchema.TableColumn(schema);
                colvarI.ColumnName = "I";
                colvarI.DataType = DbType.Int32;
                colvarI.MaxLength = 0;
                colvarI.AutoIncrement = false;
                colvarI.IsNullable = true;
                colvarI.IsPrimaryKey = false;
                colvarI.IsForeignKey = false;
                colvarI.IsReadOnly = false;
                
                schema.Columns.Add(colvarI);
                
                TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
                colvarIdAgenda.ColumnName = "idAgenda";
                colvarIdAgenda.DataType = DbType.Int32;
                colvarIdAgenda.MaxLength = 0;
                colvarIdAgenda.AutoIncrement = false;
                colvarIdAgenda.IsNullable = false;
                colvarIdAgenda.IsPrimaryKey = false;
                colvarIdAgenda.IsForeignKey = false;
                colvarIdAgenda.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdAgenda);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("Con_TurnoGrupoEtareo",schema);
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
	    public ConTurnoGrupoEtareo()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConTurnoGrupoEtareo(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConTurnoGrupoEtareo(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConTurnoGrupoEtareo(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdTurno")]
        [Bindable(true)]
        public int IdTurno 
	    {
		    get
		    {
			    return GetColumnValue<int>("idTurno");
		    }
            set 
		    {
			    SetColumnValue("idTurno", value);
            }
        }
	      
        [XmlAttribute("1")]
        [Bindable(true)]
        public int? 1 
	    {
		    get
		    {
			    return GetColumnValue<int?>("<1");
		    }
            set 
		    {
			    SetColumnValue("<1", value);
            }
        }
	      
        [XmlAttribute("_1")]
        [Bindable(true)]
        public int? _1 
	    {
		    get
		    {
			    return GetColumnValue<int?>("1");
		    }
            set 
		    {
			    SetColumnValue("1", value);
            }
        }
	      
        [XmlAttribute("2A5")]
        [Bindable(true)]
        public int? 2A5 
	    {
		    get
		    {
			    return GetColumnValue<int?>("2 a 5");
		    }
            set 
		    {
			    SetColumnValue("2 a 5", value);
            }
        }
	      
        [XmlAttribute("6A9")]
        [Bindable(true)]
        public int? 6A9 
	    {
		    get
		    {
			    return GetColumnValue<int?>("6 a 9");
		    }
            set 
		    {
			    SetColumnValue("6 a 9", value);
            }
        }
	      
        [XmlAttribute("10A14")]
        [Bindable(true)]
        public int? 10A14 
	    {
		    get
		    {
			    return GetColumnValue<int?>("10 a 14");
		    }
            set 
		    {
			    SetColumnValue("10 a 14", value);
            }
        }
	      
        [XmlAttribute("15A19")]
        [Bindable(true)]
        public int? 15A19 
	    {
		    get
		    {
			    return GetColumnValue<int?>("15 a 19");
		    }
            set 
		    {
			    SetColumnValue("15 a 19", value);
            }
        }
	      
        [XmlAttribute("20A39")]
        [Bindable(true)]
        public int? 20A39 
	    {
		    get
		    {
			    return GetColumnValue<int?>("20 a 39");
		    }
            set 
		    {
			    SetColumnValue("20 a 39", value);
            }
        }
	      
        [XmlAttribute("40A69")]
        [Bindable(true)]
        public int? 40A69 
	    {
		    get
		    {
			    return GetColumnValue<int?>("40 a 69");
		    }
            set 
		    {
			    SetColumnValue("40 a 69", value);
            }
        }
	      
        [XmlAttribute("70Y")]
        [Bindable(true)]
        public int? 70Y 
	    {
		    get
		    {
			    return GetColumnValue<int?>("70 y +");
		    }
            set 
		    {
			    SetColumnValue("70 y +", value);
            }
        }
	      
        [XmlAttribute("M")]
        [Bindable(true)]
        public int? M 
	    {
		    get
		    {
			    return GetColumnValue<int?>("M");
		    }
            set 
		    {
			    SetColumnValue("M", value);
            }
        }
	      
        [XmlAttribute("F")]
        [Bindable(true)]
        public int? F 
	    {
		    get
		    {
			    return GetColumnValue<int?>("F");
		    }
            set 
		    {
			    SetColumnValue("F", value);
            }
        }
	      
        [XmlAttribute("I")]
        [Bindable(true)]
        public int? I 
	    {
		    get
		    {
			    return GetColumnValue<int?>("I");
		    }
            set 
		    {
			    SetColumnValue("I", value);
            }
        }
	      
        [XmlAttribute("IdAgenda")]
        [Bindable(true)]
        public int IdAgenda 
	    {
		    get
		    {
			    return GetColumnValue<int>("idAgenda");
		    }
            set 
		    {
			    SetColumnValue("idAgenda", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdTurno = @"idTurno";
            
            public static string 1 = @"<1";
            
            public static string _1 = @"1";
            
            public static string 2A5 = @"2 a 5";
            
            public static string 6A9 = @"6 a 9";
            
            public static string 10A14 = @"10 a 14";
            
            public static string 15A19 = @"15 a 19";
            
            public static string 20A39 = @"20 a 39";
            
            public static string 40A69 = @"40 a 69";
            
            public static string 70Y = @"70 y +";
            
            public static string M = @"M";
            
            public static string F = @"F";
            
            public static string I = @"I";
            
            public static string IdAgenda = @"idAgenda";
            
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
