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
    /// Strongly-typed collection for the AutFechaMaximaHistoricoPMP class.
    /// </summary>
    [Serializable]
    public partial class AutFechaMaximaHistoricoPMPCollection : ReadOnlyList<AutFechaMaximaHistoricoPMP, AutFechaMaximaHistoricoPMPCollection>
    {        
        public AutFechaMaximaHistoricoPMPCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the AUT_FechaMaximaHistoricoPMP view.
    /// </summary>
    [Serializable]
    public partial class AutFechaMaximaHistoricoPMP : ReadOnlyRecord<AutFechaMaximaHistoricoPMP>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("AUT_FechaMaximaHistoricoPMP", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdHistoricoVehiculoPMP = new TableSchema.TableColumn(schema);
                colvarIdHistoricoVehiculoPMP.ColumnName = "idHistoricoVehiculoPMP";
                colvarIdHistoricoVehiculoPMP.DataType = DbType.Int32;
                colvarIdHistoricoVehiculoPMP.MaxLength = 0;
                colvarIdHistoricoVehiculoPMP.AutoIncrement = false;
                colvarIdHistoricoVehiculoPMP.IsNullable = false;
                colvarIdHistoricoVehiculoPMP.IsPrimaryKey = false;
                colvarIdHistoricoVehiculoPMP.IsForeignKey = false;
                colvarIdHistoricoVehiculoPMP.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdHistoricoVehiculoPMP);
                
                TableSchema.TableColumn colvarIdVehiculoPMP = new TableSchema.TableColumn(schema);
                colvarIdVehiculoPMP.ColumnName = "idVehiculoPMP";
                colvarIdVehiculoPMP.DataType = DbType.Int32;
                colvarIdVehiculoPMP.MaxLength = 0;
                colvarIdVehiculoPMP.AutoIncrement = false;
                colvarIdVehiculoPMP.IsNullable = false;
                colvarIdVehiculoPMP.IsPrimaryKey = false;
                colvarIdVehiculoPMP.IsForeignKey = false;
                colvarIdVehiculoPMP.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdVehiculoPMP);
                
                TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
                colvarFecha.ColumnName = "fecha";
                colvarFecha.DataType = DbType.DateTime;
                colvarFecha.MaxLength = 0;
                colvarFecha.AutoIncrement = false;
                colvarFecha.IsNullable = false;
                colvarFecha.IsPrimaryKey = false;
                colvarFecha.IsForeignKey = false;
                colvarFecha.IsReadOnly = false;
                
                schema.Columns.Add(colvarFecha);
                
                TableSchema.TableColumn colvarKilometraje = new TableSchema.TableColumn(schema);
                colvarKilometraje.ColumnName = "kilometraje";
                colvarKilometraje.DataType = DbType.Int32;
                colvarKilometraje.MaxLength = 0;
                colvarKilometraje.AutoIncrement = false;
                colvarKilometraje.IsNullable = false;
                colvarKilometraje.IsPrimaryKey = false;
                colvarKilometraje.IsForeignKey = false;
                colvarKilometraje.IsReadOnly = false;
                
                schema.Columns.Add(colvarKilometraje);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("AUT_FechaMaximaHistoricoPMP",schema);
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
	    public AutFechaMaximaHistoricoPMP()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public AutFechaMaximaHistoricoPMP(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public AutFechaMaximaHistoricoPMP(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public AutFechaMaximaHistoricoPMP(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdHistoricoVehiculoPMP")]
        [Bindable(true)]
        public int IdHistoricoVehiculoPMP 
	    {
		    get
		    {
			    return GetColumnValue<int>("idHistoricoVehiculoPMP");
		    }
            set 
		    {
			    SetColumnValue("idHistoricoVehiculoPMP", value);
            }
        }
	      
        [XmlAttribute("IdVehiculoPMP")]
        [Bindable(true)]
        public int IdVehiculoPMP 
	    {
		    get
		    {
			    return GetColumnValue<int>("idVehiculoPMP");
		    }
            set 
		    {
			    SetColumnValue("idVehiculoPMP", value);
            }
        }
	      
        [XmlAttribute("Fecha")]
        [Bindable(true)]
        public DateTime Fecha 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fecha");
		    }
            set 
		    {
			    SetColumnValue("fecha", value);
            }
        }
	      
        [XmlAttribute("Kilometraje")]
        [Bindable(true)]
        public int Kilometraje 
	    {
		    get
		    {
			    return GetColumnValue<int>("kilometraje");
		    }
            set 
		    {
			    SetColumnValue("kilometraje", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdHistoricoVehiculoPMP = @"idHistoricoVehiculoPMP";
            
            public static string IdVehiculoPMP = @"idVehiculoPMP";
            
            public static string Fecha = @"fecha";
            
            public static string Kilometraje = @"kilometraje";
            
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
