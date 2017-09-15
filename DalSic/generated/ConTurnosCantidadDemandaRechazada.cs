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
    /// Strongly-typed collection for the ConTurnosCantidadDemandaRechazada class.
    /// </summary>
    [Serializable]
    public partial class ConTurnosCantidadDemandaRechazadaCollection : ReadOnlyList<ConTurnosCantidadDemandaRechazada, ConTurnosCantidadDemandaRechazadaCollection>
    {        
        public ConTurnosCantidadDemandaRechazadaCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_TurnosCantidadDemandaRechazada view.
    /// </summary>
    [Serializable]
    public partial class ConTurnosCantidadDemandaRechazada : ReadOnlyRecord<ConTurnosCantidadDemandaRechazada>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_TurnosCantidadDemandaRechazada", TableType.View, DataService.GetInstance("sicProvider"));
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
                
                TableSchema.TableColumn colvarCantidadDemanda = new TableSchema.TableColumn(schema);
                colvarCantidadDemanda.ColumnName = "cantidadDemanda";
                colvarCantidadDemanda.DataType = DbType.Int32;
                colvarCantidadDemanda.MaxLength = 0;
                colvarCantidadDemanda.AutoIncrement = false;
                colvarCantidadDemanda.IsNullable = true;
                colvarCantidadDemanda.IsPrimaryKey = false;
                colvarCantidadDemanda.IsForeignKey = false;
                colvarCantidadDemanda.IsReadOnly = false;
                
                schema.Columns.Add(colvarCantidadDemanda);
                
                TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
                colvarFechaRegistro.ColumnName = "fechaRegistro";
                colvarFechaRegistro.DataType = DbType.DateTime;
                colvarFechaRegistro.MaxLength = 0;
                colvarFechaRegistro.AutoIncrement = false;
                colvarFechaRegistro.IsNullable = false;
                colvarFechaRegistro.IsPrimaryKey = false;
                colvarFechaRegistro.IsForeignKey = false;
                colvarFechaRegistro.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaRegistro);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_TurnosCantidadDemandaRechazada",schema);
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
	    public ConTurnosCantidadDemandaRechazada()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConTurnosCantidadDemandaRechazada(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConTurnosCantidadDemandaRechazada(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConTurnosCantidadDemandaRechazada(string columnName, object columnValue)
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
	      
        [XmlAttribute("CantidadDemanda")]
        [Bindable(true)]
        public int? CantidadDemanda 
	    {
		    get
		    {
			    return GetColumnValue<int?>("cantidadDemanda");
		    }
            set 
		    {
			    SetColumnValue("cantidadDemanda", value);
            }
        }
	      
        [XmlAttribute("FechaRegistro")]
        [Bindable(true)]
        public DateTime FechaRegistro 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fechaRegistro");
		    }
            set 
		    {
			    SetColumnValue("fechaRegistro", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdEfector = @"idEfector";
            
            public static string CantidadDemanda = @"cantidadDemanda";
            
            public static string FechaRegistro = @"fechaRegistro";
            
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
