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
    /// Strongly-typed collection for the ConDiagPrincipalTurno class.
    /// </summary>
    [Serializable]
    public partial class ConDiagPrincipalTurnoCollection : ReadOnlyList<ConDiagPrincipalTurno, ConDiagPrincipalTurnoCollection>
    {        
        public ConDiagPrincipalTurnoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_DiagPrincipalTurnos view.
    /// </summary>
    [Serializable]
    public partial class ConDiagPrincipalTurno : ReadOnlyRecord<ConDiagPrincipalTurno>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_DiagPrincipalTurnos", TableType.View, DataService.GetInstance("sicProvider"));
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
                
                TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
                colvarNombre.ColumnName = "Nombre";
                colvarNombre.DataType = DbType.String;
                colvarNombre.MaxLength = 255;
                colvarNombre.AutoIncrement = false;
                colvarNombre.IsNullable = true;
                colvarNombre.IsPrimaryKey = false;
                colvarNombre.IsForeignKey = false;
                colvarNombre.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombre);
                
                TableSchema.TableColumn colvarPrincipal = new TableSchema.TableColumn(schema);
                colvarPrincipal.ColumnName = "principal";
                colvarPrincipal.DataType = DbType.Boolean;
                colvarPrincipal.MaxLength = 0;
                colvarPrincipal.AutoIncrement = false;
                colvarPrincipal.IsNullable = true;
                colvarPrincipal.IsPrimaryKey = false;
                colvarPrincipal.IsForeignKey = false;
                colvarPrincipal.IsReadOnly = false;
                
                schema.Columns.Add(colvarPrincipal);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_DiagPrincipalTurnos",schema);
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
	    public ConDiagPrincipalTurno()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConDiagPrincipalTurno(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConDiagPrincipalTurno(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConDiagPrincipalTurno(string columnName, object columnValue)
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
	      
        [XmlAttribute("Nombre")]
        [Bindable(true)]
        public string Nombre 
	    {
		    get
		    {
			    return GetColumnValue<string>("Nombre");
		    }
            set 
		    {
			    SetColumnValue("Nombre", value);
            }
        }
	      
        [XmlAttribute("Principal")]
        [Bindable(true)]
        public bool? Principal 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("principal");
		    }
            set 
		    {
			    SetColumnValue("principal", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdTurno = @"idTurno";
            
            public static string Nombre = @"Nombre";
            
            public static string Principal = @"principal";
            
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
