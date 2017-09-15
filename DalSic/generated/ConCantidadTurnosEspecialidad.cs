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
    /// Strongly-typed collection for the ConCantidadTurnosEspecialidad class.
    /// </summary>
    [Serializable]
    public partial class ConCantidadTurnosEspecialidadCollection : ReadOnlyList<ConCantidadTurnosEspecialidad, ConCantidadTurnosEspecialidadCollection>
    {        
        public ConCantidadTurnosEspecialidadCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_CantidadTurnosEspecialidad view.
    /// </summary>
    [Serializable]
    public partial class ConCantidadTurnosEspecialidad : ReadOnlyRecord<ConCantidadTurnosEspecialidad>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_CantidadTurnosEspecialidad", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
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
                
                TableSchema.TableColumn colvarPorcentajeTurnosDia = new TableSchema.TableColumn(schema);
                colvarPorcentajeTurnosDia.ColumnName = "porcentajeTurnosDia";
                colvarPorcentajeTurnosDia.DataType = DbType.Int32;
                colvarPorcentajeTurnosDia.MaxLength = 0;
                colvarPorcentajeTurnosDia.AutoIncrement = false;
                colvarPorcentajeTurnosDia.IsNullable = false;
                colvarPorcentajeTurnosDia.IsPrimaryKey = false;
                colvarPorcentajeTurnosDia.IsForeignKey = false;
                colvarPorcentajeTurnosDia.IsReadOnly = false;
                
                schema.Columns.Add(colvarPorcentajeTurnosDia);
                
                TableSchema.TableColumn colvarPorcentajeTurnosAnticipado = new TableSchema.TableColumn(schema);
                colvarPorcentajeTurnosAnticipado.ColumnName = "porcentajeTurnosAnticipado";
                colvarPorcentajeTurnosAnticipado.DataType = DbType.Int32;
                colvarPorcentajeTurnosAnticipado.MaxLength = 0;
                colvarPorcentajeTurnosAnticipado.AutoIncrement = false;
                colvarPorcentajeTurnosAnticipado.IsNullable = false;
                colvarPorcentajeTurnosAnticipado.IsPrimaryKey = false;
                colvarPorcentajeTurnosAnticipado.IsForeignKey = false;
                colvarPorcentajeTurnosAnticipado.IsReadOnly = false;
                
                schema.Columns.Add(colvarPorcentajeTurnosAnticipado);
                
                TableSchema.TableColumn colvarHoraInicio = new TableSchema.TableColumn(schema);
                colvarHoraInicio.ColumnName = "horaInicio";
                colvarHoraInicio.DataType = DbType.AnsiStringFixedLength;
                colvarHoraInicio.MaxLength = 5;
                colvarHoraInicio.AutoIncrement = false;
                colvarHoraInicio.IsNullable = false;
                colvarHoraInicio.IsPrimaryKey = false;
                colvarHoraInicio.IsForeignKey = false;
                colvarHoraInicio.IsReadOnly = false;
                
                schema.Columns.Add(colvarHoraInicio);
                
                TableSchema.TableColumn colvarHoraFin = new TableSchema.TableColumn(schema);
                colvarHoraFin.ColumnName = "horaFin";
                colvarHoraFin.DataType = DbType.AnsiStringFixedLength;
                colvarHoraFin.MaxLength = 5;
                colvarHoraFin.AutoIncrement = false;
                colvarHoraFin.IsNullable = false;
                colvarHoraFin.IsPrimaryKey = false;
                colvarHoraFin.IsForeignKey = false;
                colvarHoraFin.IsReadOnly = false;
                
                schema.Columns.Add(colvarHoraFin);
                
                TableSchema.TableColumn colvarDuracion = new TableSchema.TableColumn(schema);
                colvarDuracion.ColumnName = "duracion";
                colvarDuracion.DataType = DbType.Int32;
                colvarDuracion.MaxLength = 0;
                colvarDuracion.AutoIncrement = false;
                colvarDuracion.IsNullable = false;
                colvarDuracion.IsPrimaryKey = false;
                colvarDuracion.IsForeignKey = false;
                colvarDuracion.IsReadOnly = false;
                
                schema.Columns.Add(colvarDuracion);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_CantidadTurnosEspecialidad",schema);
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
	    public ConCantidadTurnosEspecialidad()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConCantidadTurnosEspecialidad(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConCantidadTurnosEspecialidad(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConCantidadTurnosEspecialidad(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
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
	      
        [XmlAttribute("PorcentajeTurnosDia")]
        [Bindable(true)]
        public int PorcentajeTurnosDia 
	    {
		    get
		    {
			    return GetColumnValue<int>("porcentajeTurnosDia");
		    }
            set 
		    {
			    SetColumnValue("porcentajeTurnosDia", value);
            }
        }
	      
        [XmlAttribute("PorcentajeTurnosAnticipado")]
        [Bindable(true)]
        public int PorcentajeTurnosAnticipado 
	    {
		    get
		    {
			    return GetColumnValue<int>("porcentajeTurnosAnticipado");
		    }
            set 
		    {
			    SetColumnValue("porcentajeTurnosAnticipado", value);
            }
        }
	      
        [XmlAttribute("HoraInicio")]
        [Bindable(true)]
        public string HoraInicio 
	    {
		    get
		    {
			    return GetColumnValue<string>("horaInicio");
		    }
            set 
		    {
			    SetColumnValue("horaInicio", value);
            }
        }
	      
        [XmlAttribute("HoraFin")]
        [Bindable(true)]
        public string HoraFin 
	    {
		    get
		    {
			    return GetColumnValue<string>("horaFin");
		    }
            set 
		    {
			    SetColumnValue("horaFin", value);
            }
        }
	      
        [XmlAttribute("Duracion")]
        [Bindable(true)]
        public int Duracion 
	    {
		    get
		    {
			    return GetColumnValue<int>("duracion");
		    }
            set 
		    {
			    SetColumnValue("duracion", value);
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
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdAgenda = @"idAgenda";
            
            public static string PorcentajeTurnosDia = @"porcentajeTurnosDia";
            
            public static string PorcentajeTurnosAnticipado = @"porcentajeTurnosAnticipado";
            
            public static string HoraInicio = @"horaInicio";
            
            public static string HoraFin = @"horaFin";
            
            public static string Duracion = @"duracion";
            
            public static string CantidadTurnos = @"cantidadTurnos";
            
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
