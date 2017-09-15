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
    /// Strongly-typed collection for the ConTurnosDelDiaConAsistencium class.
    /// </summary>
    [Serializable]
    public partial class ConTurnosDelDiaConAsistenciumCollection : ReadOnlyList<ConTurnosDelDiaConAsistencium, ConTurnosDelDiaConAsistenciumCollection>
    {        
        public ConTurnosDelDiaConAsistenciumCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_TurnosDelDiaConAsistencia view.
    /// </summary>
    [Serializable]
    public partial class ConTurnosDelDiaConAsistencium : ReadOnlyRecord<ConTurnosDelDiaConAsistencium>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_TurnosDelDiaConAsistencia", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
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
                
                TableSchema.TableColumn colvarCantidadTurnos = new TableSchema.TableColumn(schema);
                colvarCantidadTurnos.ColumnName = "cantidadTurnos";
                colvarCantidadTurnos.DataType = DbType.Int32;
                colvarCantidadTurnos.MaxLength = 0;
                colvarCantidadTurnos.AutoIncrement = false;
                colvarCantidadTurnos.IsNullable = true;
                colvarCantidadTurnos.IsPrimaryKey = false;
                colvarCantidadTurnos.IsForeignKey = false;
                colvarCantidadTurnos.IsReadOnly = false;
                
                schema.Columns.Add(colvarCantidadTurnos);
                
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
                DataService.Providers["sicProvider"].AddSchema("CON_TurnosDelDiaConAsistencia",schema);
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
	    public ConTurnosDelDiaConAsistencium()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConTurnosDelDiaConAsistencium(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConTurnosDelDiaConAsistencium(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConTurnosDelDiaConAsistencium(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
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
	      
        [XmlAttribute("CantidadTurnos")]
        [Bindable(true)]
        public int? CantidadTurnos 
	    {
		    get
		    {
			    return GetColumnValue<int?>("cantidadTurnos");
		    }
            set 
		    {
			    SetColumnValue("cantidadTurnos", value);
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
		    
		    
            public static string Nombre = @"nombre";
            
            public static string CantidadTurnos = @"cantidadTurnos";
            
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
