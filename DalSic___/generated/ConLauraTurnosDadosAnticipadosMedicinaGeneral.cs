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
    /// Strongly-typed collection for the ConLauraTurnosDadosAnticipadosMedicinaGeneral class.
    /// </summary>
    [Serializable]
    public partial class ConLauraTurnosDadosAnticipadosMedicinaGeneralCollection : ReadOnlyList<ConLauraTurnosDadosAnticipadosMedicinaGeneral, ConLauraTurnosDadosAnticipadosMedicinaGeneralCollection>
    {        
        public ConLauraTurnosDadosAnticipadosMedicinaGeneralCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_laura_turnosDadosAnticipadosMedicinaGeneral view.
    /// </summary>
    [Serializable]
    public partial class ConLauraTurnosDadosAnticipadosMedicinaGeneral : ReadOnlyRecord<ConLauraTurnosDadosAnticipadosMedicinaGeneral>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_laura_turnosDadosAnticipadosMedicinaGeneral", TableType.View, DataService.GetInstance("sicProvider"));
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
                DataService.Providers["sicProvider"].AddSchema("CON_laura_turnosDadosAnticipadosMedicinaGeneral",schema);
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
	    public ConLauraTurnosDadosAnticipadosMedicinaGeneral()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConLauraTurnosDadosAnticipadosMedicinaGeneral(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConLauraTurnosDadosAnticipadosMedicinaGeneral(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConLauraTurnosDadosAnticipadosMedicinaGeneral(string columnName, object columnValue)
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
		    
		    
            public static string Nombre = @"nombre";
            
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
