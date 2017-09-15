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
    /// Strongly-typed collection for the ConTurnoGrupoEtareoC2 class.
    /// </summary>
    [Serializable]
    public partial class ConTurnoGrupoEtareoC2Collection : ReadOnlyList<ConTurnoGrupoEtareoC2, ConTurnoGrupoEtareoC2Collection>
    {        
        public ConTurnoGrupoEtareoC2Collection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_TurnoGrupoEtareoC2 view.
    /// </summary>
    [Serializable]
    public partial class ConTurnoGrupoEtareoC2 : ReadOnlyRecord<ConTurnoGrupoEtareoC2>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_TurnoGrupoEtareoC2", TableType.View, DataService.GetInstance("sicProvider"));
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
                
                TableSchema.TableColumn colvar2A4 = new TableSchema.TableColumn(schema);
                colvar2A4.ColumnName = "2 a 4";
                colvar2A4.DataType = DbType.Int32;
                colvar2A4.MaxLength = 0;
                colvar2A4.AutoIncrement = false;
                colvar2A4.IsNullable = true;
                colvar2A4.IsPrimaryKey = false;
                colvar2A4.IsForeignKey = false;
                colvar2A4.IsReadOnly = false;
                
                schema.Columns.Add(colvar2A4);
                
                TableSchema.TableColumn colvar5A9 = new TableSchema.TableColumn(schema);
                colvar5A9.ColumnName = "5 a 9";
                colvar5A9.DataType = DbType.Int32;
                colvar5A9.MaxLength = 0;
                colvar5A9.AutoIncrement = false;
                colvar5A9.IsNullable = true;
                colvar5A9.IsPrimaryKey = false;
                colvar5A9.IsForeignKey = false;
                colvar5A9.IsReadOnly = false;
                
                schema.Columns.Add(colvar5A9);
                
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
                
                TableSchema.TableColumn colvar15A24 = new TableSchema.TableColumn(schema);
                colvar15A24.ColumnName = "15 a 24";
                colvar15A24.DataType = DbType.Int32;
                colvar15A24.MaxLength = 0;
                colvar15A24.AutoIncrement = false;
                colvar15A24.IsNullable = true;
                colvar15A24.IsPrimaryKey = false;
                colvar15A24.IsForeignKey = false;
                colvar15A24.IsReadOnly = false;
                
                schema.Columns.Add(colvar15A24);
                
                TableSchema.TableColumn colvar25A34 = new TableSchema.TableColumn(schema);
                colvar25A34.ColumnName = "25 a 34";
                colvar25A34.DataType = DbType.Int32;
                colvar25A34.MaxLength = 0;
                colvar25A34.AutoIncrement = false;
                colvar25A34.IsNullable = true;
                colvar25A34.IsPrimaryKey = false;
                colvar25A34.IsForeignKey = false;
                colvar25A34.IsReadOnly = false;
                
                schema.Columns.Add(colvar25A34);
                
                TableSchema.TableColumn colvar35A44 = new TableSchema.TableColumn(schema);
                colvar35A44.ColumnName = "35 a 44";
                colvar35A44.DataType = DbType.Int32;
                colvar35A44.MaxLength = 0;
                colvar35A44.AutoIncrement = false;
                colvar35A44.IsNullable = true;
                colvar35A44.IsPrimaryKey = false;
                colvar35A44.IsForeignKey = false;
                colvar35A44.IsReadOnly = false;
                
                schema.Columns.Add(colvar35A44);
                
                TableSchema.TableColumn colvar45A64 = new TableSchema.TableColumn(schema);
                colvar45A64.ColumnName = "45 a 64";
                colvar45A64.DataType = DbType.Int32;
                colvar45A64.MaxLength = 0;
                colvar45A64.AutoIncrement = false;
                colvar45A64.IsNullable = true;
                colvar45A64.IsPrimaryKey = false;
                colvar45A64.IsForeignKey = false;
                colvar45A64.IsReadOnly = false;
                
                schema.Columns.Add(colvar45A64);
                
                TableSchema.TableColumn colvar65Y = new TableSchema.TableColumn(schema);
                colvar65Y.ColumnName = "65 y +";
                colvar65Y.DataType = DbType.Int32;
                colvar65Y.MaxLength = 0;
                colvar65Y.AutoIncrement = false;
                colvar65Y.IsNullable = true;
                colvar65Y.IsPrimaryKey = false;
                colvar65Y.IsForeignKey = false;
                colvar65Y.IsReadOnly = false;
                
                schema.Columns.Add(colvar65Y);
                
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
                DataService.Providers["sicProvider"].AddSchema("CON_TurnoGrupoEtareoC2",schema);
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
	    public ConTurnoGrupoEtareoC2()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConTurnoGrupoEtareoC2(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConTurnoGrupoEtareoC2(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConTurnoGrupoEtareoC2(string columnName, object columnValue)
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
	      
        [XmlAttribute("2A4")]
        [Bindable(true)]
        public int? 2A4 
	    {
		    get
		    {
			    return GetColumnValue<int?>("2 a 4");
		    }
            set 
		    {
			    SetColumnValue("2 a 4", value);
            }
        }
	      
        [XmlAttribute("5A9")]
        [Bindable(true)]
        public int? 5A9 
	    {
		    get
		    {
			    return GetColumnValue<int?>("5 a 9");
		    }
            set 
		    {
			    SetColumnValue("5 a 9", value);
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
	      
        [XmlAttribute("15A24")]
        [Bindable(true)]
        public int? 15A24 
	    {
		    get
		    {
			    return GetColumnValue<int?>("15 a 24");
		    }
            set 
		    {
			    SetColumnValue("15 a 24", value);
            }
        }
	      
        [XmlAttribute("25A34")]
        [Bindable(true)]
        public int? 25A34 
	    {
		    get
		    {
			    return GetColumnValue<int?>("25 a 34");
		    }
            set 
		    {
			    SetColumnValue("25 a 34", value);
            }
        }
	      
        [XmlAttribute("35A44")]
        [Bindable(true)]
        public int? 35A44 
	    {
		    get
		    {
			    return GetColumnValue<int?>("35 a 44");
		    }
            set 
		    {
			    SetColumnValue("35 a 44", value);
            }
        }
	      
        [XmlAttribute("45A64")]
        [Bindable(true)]
        public int? 45A64 
	    {
		    get
		    {
			    return GetColumnValue<int?>("45 a 64");
		    }
            set 
		    {
			    SetColumnValue("45 a 64", value);
            }
        }
	      
        [XmlAttribute("65Y")]
        [Bindable(true)]
        public int? 65Y 
	    {
		    get
		    {
			    return GetColumnValue<int?>("65 y +");
		    }
            set 
		    {
			    SetColumnValue("65 y +", value);
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
            
            public static string 2A4 = @"2 a 4";
            
            public static string 5A9 = @"5 a 9";
            
            public static string 10A14 = @"10 a 14";
            
            public static string 15A24 = @"15 a 24";
            
            public static string 25A34 = @"25 a 34";
            
            public static string 35A44 = @"35 a 44";
            
            public static string 45A64 = @"45 a 64";
            
            public static string 65Y = @"65 y +";
            
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
