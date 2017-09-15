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
    /// Strongly-typed collection for the ConVistaAgenda class.
    /// </summary>
    [Serializable]
    public partial class ConVistaAgendaCollection : ReadOnlyList<ConVistaAgenda, ConVistaAgendaCollection>
    {        
        public ConVistaAgendaCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_VistaAgendas view.
    /// </summary>
    [Serializable]
    public partial class ConVistaAgenda : ReadOnlyRecord<ConVistaAgenda>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_VistaAgendas", TableType.View, DataService.GetInstance("sicProvider"));
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
                
                TableSchema.TableColumn colvarIdAgendaEstado = new TableSchema.TableColumn(schema);
                colvarIdAgendaEstado.ColumnName = "idAgendaEstado";
                colvarIdAgendaEstado.DataType = DbType.Int32;
                colvarIdAgendaEstado.MaxLength = 0;
                colvarIdAgendaEstado.AutoIncrement = false;
                colvarIdAgendaEstado.IsNullable = false;
                colvarIdAgendaEstado.IsPrimaryKey = false;
                colvarIdAgendaEstado.IsForeignKey = false;
                colvarIdAgendaEstado.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdAgendaEstado);
                
                TableSchema.TableColumn colvarIdConsultorio = new TableSchema.TableColumn(schema);
                colvarIdConsultorio.ColumnName = "idConsultorio";
                colvarIdConsultorio.DataType = DbType.Int32;
                colvarIdConsultorio.MaxLength = 0;
                colvarIdConsultorio.AutoIncrement = false;
                colvarIdConsultorio.IsNullable = false;
                colvarIdConsultorio.IsPrimaryKey = false;
                colvarIdConsultorio.IsForeignKey = false;
                colvarIdConsultorio.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdConsultorio);
                
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
                
                TableSchema.TableColumn colvarHoraInicio = new TableSchema.TableColumn(schema);
                colvarHoraInicio.ColumnName = "HoraInicio";
                colvarHoraInicio.DataType = DbType.DateTime;
                colvarHoraInicio.MaxLength = 0;
                colvarHoraInicio.AutoIncrement = false;
                colvarHoraInicio.IsNullable = true;
                colvarHoraInicio.IsPrimaryKey = false;
                colvarHoraInicio.IsForeignKey = false;
                colvarHoraInicio.IsReadOnly = false;
                
                schema.Columns.Add(colvarHoraInicio);
                
                TableSchema.TableColumn colvarHoraFin = new TableSchema.TableColumn(schema);
                colvarHoraFin.ColumnName = "HoraFin";
                colvarHoraFin.DataType = DbType.DateTime;
                colvarHoraFin.MaxLength = 0;
                colvarHoraFin.AutoIncrement = false;
                colvarHoraFin.IsNullable = true;
                colvarHoraFin.IsPrimaryKey = false;
                colvarHoraFin.IsForeignKey = false;
                colvarHoraFin.IsReadOnly = false;
                
                schema.Columns.Add(colvarHoraFin);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_VistaAgendas",schema);
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
	    public ConVistaAgenda()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConVistaAgenda(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConVistaAgenda(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConVistaAgenda(string columnName, object columnValue)
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
	      
        [XmlAttribute("IdAgendaEstado")]
        [Bindable(true)]
        public int IdAgendaEstado 
	    {
		    get
		    {
			    return GetColumnValue<int>("idAgendaEstado");
		    }
            set 
		    {
			    SetColumnValue("idAgendaEstado", value);
            }
        }
	      
        [XmlAttribute("IdConsultorio")]
        [Bindable(true)]
        public int IdConsultorio 
	    {
		    get
		    {
			    return GetColumnValue<int>("idConsultorio");
		    }
            set 
		    {
			    SetColumnValue("idConsultorio", value);
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
	      
        [XmlAttribute("HoraInicio")]
        [Bindable(true)]
        public DateTime? HoraInicio 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("HoraInicio");
		    }
            set 
		    {
			    SetColumnValue("HoraInicio", value);
            }
        }
	      
        [XmlAttribute("HoraFin")]
        [Bindable(true)]
        public DateTime? HoraFin 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("HoraFin");
		    }
            set 
		    {
			    SetColumnValue("HoraFin", value);
            }
        }
	      
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
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdAgenda = @"idAgenda";
            
            public static string IdAgendaEstado = @"idAgendaEstado";
            
            public static string IdConsultorio = @"idConsultorio";
            
            public static string Fecha = @"fecha";
            
            public static string HoraInicio = @"HoraInicio";
            
            public static string HoraFin = @"HoraFin";
            
            public static string IdEfector = @"idEfector";
            
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
