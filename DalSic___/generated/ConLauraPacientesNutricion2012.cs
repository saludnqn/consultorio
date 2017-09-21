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
    /// Strongly-typed collection for the ConLauraPacientesNutricion2012 class.
    /// </summary>
    [Serializable]
    public partial class ConLauraPacientesNutricion2012Collection : ReadOnlyList<ConLauraPacientesNutricion2012, ConLauraPacientesNutricion2012Collection>
    {        
        public ConLauraPacientesNutricion2012Collection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_laura_pacientesNutricion2012 view.
    /// </summary>
    [Serializable]
    public partial class ConLauraPacientesNutricion2012 : ReadOnlyRecord<ConLauraPacientesNutricion2012>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_laura_pacientesNutricion2012", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
                colvarIdPaciente.ColumnName = "idPaciente";
                colvarIdPaciente.DataType = DbType.Int32;
                colvarIdPaciente.MaxLength = 0;
                colvarIdPaciente.AutoIncrement = false;
                colvarIdPaciente.IsNullable = false;
                colvarIdPaciente.IsPrimaryKey = false;
                colvarIdPaciente.IsForeignKey = false;
                colvarIdPaciente.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdPaciente);
                
                TableSchema.TableColumn colvarDni = new TableSchema.TableColumn(schema);
                colvarDni.ColumnName = "dni";
                colvarDni.DataType = DbType.Int32;
                colvarDni.MaxLength = 0;
                colvarDni.AutoIncrement = false;
                colvarDni.IsNullable = false;
                colvarDni.IsPrimaryKey = false;
                colvarDni.IsForeignKey = false;
                colvarDni.IsReadOnly = false;
                
                schema.Columns.Add(colvarDni);
                
                TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
                colvarApellido.ColumnName = "apellido";
                colvarApellido.DataType = DbType.String;
                colvarApellido.MaxLength = 100;
                colvarApellido.AutoIncrement = false;
                colvarApellido.IsNullable = false;
                colvarApellido.IsPrimaryKey = false;
                colvarApellido.IsForeignKey = false;
                colvarApellido.IsReadOnly = false;
                
                schema.Columns.Add(colvarApellido);
                
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
                
                TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
                colvarSexo.ColumnName = "sexo";
                colvarSexo.DataType = DbType.String;
                colvarSexo.MaxLength = 50;
                colvarSexo.AutoIncrement = false;
                colvarSexo.IsNullable = false;
                colvarSexo.IsPrimaryKey = false;
                colvarSexo.IsForeignKey = false;
                colvarSexo.IsReadOnly = false;
                
                schema.Columns.Add(colvarSexo);
                
                TableSchema.TableColumn colvarFechanacimiento = new TableSchema.TableColumn(schema);
                colvarFechanacimiento.ColumnName = "fechanacimiento";
                colvarFechanacimiento.DataType = DbType.DateTime;
                colvarFechanacimiento.MaxLength = 0;
                colvarFechanacimiento.AutoIncrement = false;
                colvarFechanacimiento.IsNullable = false;
                colvarFechanacimiento.IsPrimaryKey = false;
                colvarFechanacimiento.IsForeignKey = false;
                colvarFechanacimiento.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechanacimiento);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_laura_pacientesNutricion2012",schema);
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
	    public ConLauraPacientesNutricion2012()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConLauraPacientesNutricion2012(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConLauraPacientesNutricion2012(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConLauraPacientesNutricion2012(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdPaciente")]
        [Bindable(true)]
        public int IdPaciente 
	    {
		    get
		    {
			    return GetColumnValue<int>("idPaciente");
		    }
            set 
		    {
			    SetColumnValue("idPaciente", value);
            }
        }
	      
        [XmlAttribute("Dni")]
        [Bindable(true)]
        public int Dni 
	    {
		    get
		    {
			    return GetColumnValue<int>("dni");
		    }
            set 
		    {
			    SetColumnValue("dni", value);
            }
        }
	      
        [XmlAttribute("Apellido")]
        [Bindable(true)]
        public string Apellido 
	    {
		    get
		    {
			    return GetColumnValue<string>("apellido");
		    }
            set 
		    {
			    SetColumnValue("apellido", value);
            }
        }
	      
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
	      
        [XmlAttribute("Sexo")]
        [Bindable(true)]
        public string Sexo 
	    {
		    get
		    {
			    return GetColumnValue<string>("sexo");
		    }
            set 
		    {
			    SetColumnValue("sexo", value);
            }
        }
	      
        [XmlAttribute("Fechanacimiento")]
        [Bindable(true)]
        public DateTime Fechanacimiento 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fechanacimiento");
		    }
            set 
		    {
			    SetColumnValue("fechanacimiento", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdPaciente = @"idPaciente";
            
            public static string Dni = @"dni";
            
            public static string Apellido = @"apellido";
            
            public static string Nombre = @"nombre";
            
            public static string Sexo = @"sexo";
            
            public static string Fechanacimiento = @"fechanacimiento";
            
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
