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
    /// Strongly-typed collection for the ConsultaInterconsulta class.
    /// </summary>
    [Serializable]
    public partial class ConsultaInterconsultaCollection : ReadOnlyList<ConsultaInterconsulta, ConsultaInterconsultaCollection>
    {        
        public ConsultaInterconsultaCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the ConsultaInterconsultas view.
    /// </summary>
    [Serializable]
    public partial class ConsultaInterconsulta : ReadOnlyRecord<ConsultaInterconsulta>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("ConsultaInterconsultas", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdInterconsulta = new TableSchema.TableColumn(schema);
                colvarIdInterconsulta.ColumnName = "idInterconsulta";
                colvarIdInterconsulta.DataType = DbType.Int32;
                colvarIdInterconsulta.MaxLength = 0;
                colvarIdInterconsulta.AutoIncrement = false;
                colvarIdInterconsulta.IsNullable = false;
                colvarIdInterconsulta.IsPrimaryKey = false;
                colvarIdInterconsulta.IsForeignKey = false;
                colvarIdInterconsulta.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdInterconsulta);
                
                TableSchema.TableColumn colvarFechaSolicitud = new TableSchema.TableColumn(schema);
                colvarFechaSolicitud.ColumnName = "fechaSolicitud";
                colvarFechaSolicitud.DataType = DbType.DateTime;
                colvarFechaSolicitud.MaxLength = 0;
                colvarFechaSolicitud.AutoIncrement = false;
                colvarFechaSolicitud.IsNullable = false;
                colvarFechaSolicitud.IsPrimaryKey = false;
                colvarFechaSolicitud.IsForeignKey = false;
                colvarFechaSolicitud.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaSolicitud);
                
                TableSchema.TableColumn colvarIdProfSolicitante = new TableSchema.TableColumn(schema);
                colvarIdProfSolicitante.ColumnName = "idProfSolicitante";
                colvarIdProfSolicitante.DataType = DbType.Int32;
                colvarIdProfSolicitante.MaxLength = 0;
                colvarIdProfSolicitante.AutoIncrement = false;
                colvarIdProfSolicitante.IsNullable = false;
                colvarIdProfSolicitante.IsPrimaryKey = false;
                colvarIdProfSolicitante.IsForeignKey = false;
                colvarIdProfSolicitante.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdProfSolicitante);
                
                TableSchema.TableColumn colvarNumeroDocumentoProfSolitante = new TableSchema.TableColumn(schema);
                colvarNumeroDocumentoProfSolitante.ColumnName = "numeroDocumentoProfSolitante";
                colvarNumeroDocumentoProfSolitante.DataType = DbType.Int32;
                colvarNumeroDocumentoProfSolitante.MaxLength = 0;
                colvarNumeroDocumentoProfSolitante.AutoIncrement = false;
                colvarNumeroDocumentoProfSolitante.IsNullable = false;
                colvarNumeroDocumentoProfSolitante.IsPrimaryKey = false;
                colvarNumeroDocumentoProfSolitante.IsForeignKey = false;
                colvarNumeroDocumentoProfSolitante.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumentoProfSolitante);
                
                TableSchema.TableColumn colvarNombreCompletoProfSolicitante = new TableSchema.TableColumn(schema);
                colvarNombreCompletoProfSolicitante.ColumnName = "nombreCompletoProfSolicitante";
                colvarNombreCompletoProfSolicitante.DataType = DbType.String;
                colvarNombreCompletoProfSolicitante.MaxLength = 102;
                colvarNombreCompletoProfSolicitante.AutoIncrement = false;
                colvarNombreCompletoProfSolicitante.IsNullable = false;
                colvarNombreCompletoProfSolicitante.IsPrimaryKey = false;
                colvarNombreCompletoProfSolicitante.IsForeignKey = false;
                colvarNombreCompletoProfSolicitante.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreCompletoProfSolicitante);
                
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
                
                TableSchema.TableColumn colvarNumeroDocumentoPaciente = new TableSchema.TableColumn(schema);
                colvarNumeroDocumentoPaciente.ColumnName = "numeroDocumentoPaciente";
                colvarNumeroDocumentoPaciente.DataType = DbType.Int32;
                colvarNumeroDocumentoPaciente.MaxLength = 0;
                colvarNumeroDocumentoPaciente.AutoIncrement = false;
                colvarNumeroDocumentoPaciente.IsNullable = false;
                colvarNumeroDocumentoPaciente.IsPrimaryKey = false;
                colvarNumeroDocumentoPaciente.IsForeignKey = false;
                colvarNumeroDocumentoPaciente.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumentoPaciente);
                
                TableSchema.TableColumn colvarApellidoPaciente = new TableSchema.TableColumn(schema);
                colvarApellidoPaciente.ColumnName = "apellidoPaciente";
                colvarApellidoPaciente.DataType = DbType.String;
                colvarApellidoPaciente.MaxLength = 100;
                colvarApellidoPaciente.AutoIncrement = false;
                colvarApellidoPaciente.IsNullable = false;
                colvarApellidoPaciente.IsPrimaryKey = false;
                colvarApellidoPaciente.IsForeignKey = false;
                colvarApellidoPaciente.IsReadOnly = false;
                
                schema.Columns.Add(colvarApellidoPaciente);
                
                TableSchema.TableColumn colvarNombrePaciente = new TableSchema.TableColumn(schema);
                colvarNombrePaciente.ColumnName = "nombrePaciente";
                colvarNombrePaciente.DataType = DbType.String;
                colvarNombrePaciente.MaxLength = 100;
                colvarNombrePaciente.AutoIncrement = false;
                colvarNombrePaciente.IsNullable = false;
                colvarNombrePaciente.IsPrimaryKey = false;
                colvarNombrePaciente.IsForeignKey = false;
                colvarNombrePaciente.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombrePaciente);
                
                TableSchema.TableColumn colvarIdDestinatariosInterconsulta = new TableSchema.TableColumn(schema);
                colvarIdDestinatariosInterconsulta.ColumnName = "idDestinatariosInterconsulta";
                colvarIdDestinatariosInterconsulta.DataType = DbType.Int32;
                colvarIdDestinatariosInterconsulta.MaxLength = 0;
                colvarIdDestinatariosInterconsulta.AutoIncrement = false;
                colvarIdDestinatariosInterconsulta.IsNullable = false;
                colvarIdDestinatariosInterconsulta.IsPrimaryKey = false;
                colvarIdDestinatariosInterconsulta.IsForeignKey = false;
                colvarIdDestinatariosInterconsulta.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdDestinatariosInterconsulta);
                
                TableSchema.TableColumn colvarIdProfDestinatario = new TableSchema.TableColumn(schema);
                colvarIdProfDestinatario.ColumnName = "idProfDestinatario";
                colvarIdProfDestinatario.DataType = DbType.Int32;
                colvarIdProfDestinatario.MaxLength = 0;
                colvarIdProfDestinatario.AutoIncrement = false;
                colvarIdProfDestinatario.IsNullable = false;
                colvarIdProfDestinatario.IsPrimaryKey = false;
                colvarIdProfDestinatario.IsForeignKey = false;
                colvarIdProfDestinatario.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdProfDestinatario);
                
                TableSchema.TableColumn colvarNumeroDocumentoProfDestinatario = new TableSchema.TableColumn(schema);
                colvarNumeroDocumentoProfDestinatario.ColumnName = "numeroDocumentoProfDestinatario";
                colvarNumeroDocumentoProfDestinatario.DataType = DbType.Int32;
                colvarNumeroDocumentoProfDestinatario.MaxLength = 0;
                colvarNumeroDocumentoProfDestinatario.AutoIncrement = false;
                colvarNumeroDocumentoProfDestinatario.IsNullable = true;
                colvarNumeroDocumentoProfDestinatario.IsPrimaryKey = false;
                colvarNumeroDocumentoProfDestinatario.IsForeignKey = false;
                colvarNumeroDocumentoProfDestinatario.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumentoProfDestinatario);
                
                TableSchema.TableColumn colvarNombreCompletoProfDestinatario = new TableSchema.TableColumn(schema);
                colvarNombreCompletoProfDestinatario.ColumnName = "nombreCompletoProfDestinatario";
                colvarNombreCompletoProfDestinatario.DataType = DbType.String;
                colvarNombreCompletoProfDestinatario.MaxLength = 102;
                colvarNombreCompletoProfDestinatario.AutoIncrement = false;
                colvarNombreCompletoProfDestinatario.IsNullable = true;
                colvarNombreCompletoProfDestinatario.IsPrimaryKey = false;
                colvarNombreCompletoProfDestinatario.IsForeignKey = false;
                colvarNombreCompletoProfDestinatario.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreCompletoProfDestinatario);
                
                TableSchema.TableColumn colvarIdEspDestinataria = new TableSchema.TableColumn(schema);
                colvarIdEspDestinataria.ColumnName = "idEspDestinataria";
                colvarIdEspDestinataria.DataType = DbType.Int32;
                colvarIdEspDestinataria.MaxLength = 0;
                colvarIdEspDestinataria.AutoIncrement = false;
                colvarIdEspDestinataria.IsNullable = false;
                colvarIdEspDestinataria.IsPrimaryKey = false;
                colvarIdEspDestinataria.IsForeignKey = false;
                colvarIdEspDestinataria.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdEspDestinataria);
                
                TableSchema.TableColumn colvarNombreEspDestinataria = new TableSchema.TableColumn(schema);
                colvarNombreEspDestinataria.ColumnName = "nombreEspDestinataria";
                colvarNombreEspDestinataria.DataType = DbType.String;
                colvarNombreEspDestinataria.MaxLength = 50;
                colvarNombreEspDestinataria.AutoIncrement = false;
                colvarNombreEspDestinataria.IsNullable = true;
                colvarNombreEspDestinataria.IsPrimaryKey = false;
                colvarNombreEspDestinataria.IsForeignKey = false;
                colvarNombreEspDestinataria.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreEspDestinataria);
                
                TableSchema.TableColumn colvarIdDialogoInterconsulta = new TableSchema.TableColumn(schema);
                colvarIdDialogoInterconsulta.ColumnName = "idDialogoInterconsulta";
                colvarIdDialogoInterconsulta.DataType = DbType.Int32;
                colvarIdDialogoInterconsulta.MaxLength = 0;
                colvarIdDialogoInterconsulta.AutoIncrement = false;
                colvarIdDialogoInterconsulta.IsNullable = true;
                colvarIdDialogoInterconsulta.IsPrimaryKey = false;
                colvarIdDialogoInterconsulta.IsForeignKey = false;
                colvarIdDialogoInterconsulta.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdDialogoInterconsulta);
                
                TableSchema.TableColumn colvarIdProfDialogo = new TableSchema.TableColumn(schema);
                colvarIdProfDialogo.ColumnName = "idProfDialogo";
                colvarIdProfDialogo.DataType = DbType.Int32;
                colvarIdProfDialogo.MaxLength = 0;
                colvarIdProfDialogo.AutoIncrement = false;
                colvarIdProfDialogo.IsNullable = true;
                colvarIdProfDialogo.IsPrimaryKey = false;
                colvarIdProfDialogo.IsForeignKey = false;
                colvarIdProfDialogo.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdProfDialogo);
                
                TableSchema.TableColumn colvarNumeroDocumentoProfDialogo = new TableSchema.TableColumn(schema);
                colvarNumeroDocumentoProfDialogo.ColumnName = "numeroDocumentoProfDialogo";
                colvarNumeroDocumentoProfDialogo.DataType = DbType.Int32;
                colvarNumeroDocumentoProfDialogo.MaxLength = 0;
                colvarNumeroDocumentoProfDialogo.AutoIncrement = false;
                colvarNumeroDocumentoProfDialogo.IsNullable = true;
                colvarNumeroDocumentoProfDialogo.IsPrimaryKey = false;
                colvarNumeroDocumentoProfDialogo.IsForeignKey = false;
                colvarNumeroDocumentoProfDialogo.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumentoProfDialogo);
                
                TableSchema.TableColumn colvarNombreCompletoProfDialogo = new TableSchema.TableColumn(schema);
                colvarNombreCompletoProfDialogo.ColumnName = "nombreCompletoProfDialogo";
                colvarNombreCompletoProfDialogo.DataType = DbType.String;
                colvarNombreCompletoProfDialogo.MaxLength = 102;
                colvarNombreCompletoProfDialogo.AutoIncrement = false;
                colvarNombreCompletoProfDialogo.IsNullable = true;
                colvarNombreCompletoProfDialogo.IsPrimaryKey = false;
                colvarNombreCompletoProfDialogo.IsForeignKey = false;
                colvarNombreCompletoProfDialogo.IsReadOnly = false;
                
                schema.Columns.Add(colvarNombreCompletoProfDialogo);
                
                TableSchema.TableColumn colvarDialogo = new TableSchema.TableColumn(schema);
                colvarDialogo.ColumnName = "dialogo";
                colvarDialogo.DataType = DbType.AnsiString;
                colvarDialogo.MaxLength = 6000;
                colvarDialogo.AutoIncrement = false;
                colvarDialogo.IsNullable = true;
                colvarDialogo.IsPrimaryKey = false;
                colvarDialogo.IsForeignKey = false;
                colvarDialogo.IsReadOnly = false;
                
                schema.Columns.Add(colvarDialogo);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("ConsultaInterconsultas",schema);
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
	    public ConsultaInterconsulta()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConsultaInterconsulta(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConsultaInterconsulta(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConsultaInterconsulta(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdInterconsulta")]
        [Bindable(true)]
        public int IdInterconsulta 
	    {
		    get
		    {
			    return GetColumnValue<int>("idInterconsulta");
		    }
            set 
		    {
			    SetColumnValue("idInterconsulta", value);
            }
        }
	      
        [XmlAttribute("FechaSolicitud")]
        [Bindable(true)]
        public DateTime FechaSolicitud 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("fechaSolicitud");
		    }
            set 
		    {
			    SetColumnValue("fechaSolicitud", value);
            }
        }
	      
        [XmlAttribute("IdProfSolicitante")]
        [Bindable(true)]
        public int IdProfSolicitante 
	    {
		    get
		    {
			    return GetColumnValue<int>("idProfSolicitante");
		    }
            set 
		    {
			    SetColumnValue("idProfSolicitante", value);
            }
        }
	      
        [XmlAttribute("NumeroDocumentoProfSolitante")]
        [Bindable(true)]
        public int NumeroDocumentoProfSolitante 
	    {
		    get
		    {
			    return GetColumnValue<int>("numeroDocumentoProfSolitante");
		    }
            set 
		    {
			    SetColumnValue("numeroDocumentoProfSolitante", value);
            }
        }
	      
        [XmlAttribute("NombreCompletoProfSolicitante")]
        [Bindable(true)]
        public string NombreCompletoProfSolicitante 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombreCompletoProfSolicitante");
		    }
            set 
		    {
			    SetColumnValue("nombreCompletoProfSolicitante", value);
            }
        }
	      
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
	      
        [XmlAttribute("NumeroDocumentoPaciente")]
        [Bindable(true)]
        public int NumeroDocumentoPaciente 
	    {
		    get
		    {
			    return GetColumnValue<int>("numeroDocumentoPaciente");
		    }
            set 
		    {
			    SetColumnValue("numeroDocumentoPaciente", value);
            }
        }
	      
        [XmlAttribute("ApellidoPaciente")]
        [Bindable(true)]
        public string ApellidoPaciente 
	    {
		    get
		    {
			    return GetColumnValue<string>("apellidoPaciente");
		    }
            set 
		    {
			    SetColumnValue("apellidoPaciente", value);
            }
        }
	      
        [XmlAttribute("NombrePaciente")]
        [Bindable(true)]
        public string NombrePaciente 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombrePaciente");
		    }
            set 
		    {
			    SetColumnValue("nombrePaciente", value);
            }
        }
	      
        [XmlAttribute("IdDestinatariosInterconsulta")]
        [Bindable(true)]
        public int IdDestinatariosInterconsulta 
	    {
		    get
		    {
			    return GetColumnValue<int>("idDestinatariosInterconsulta");
		    }
            set 
		    {
			    SetColumnValue("idDestinatariosInterconsulta", value);
            }
        }
	      
        [XmlAttribute("IdProfDestinatario")]
        [Bindable(true)]
        public int IdProfDestinatario 
	    {
		    get
		    {
			    return GetColumnValue<int>("idProfDestinatario");
		    }
            set 
		    {
			    SetColumnValue("idProfDestinatario", value);
            }
        }
	      
        [XmlAttribute("NumeroDocumentoProfDestinatario")]
        [Bindable(true)]
        public int? NumeroDocumentoProfDestinatario 
	    {
		    get
		    {
			    return GetColumnValue<int?>("numeroDocumentoProfDestinatario");
		    }
            set 
		    {
			    SetColumnValue("numeroDocumentoProfDestinatario", value);
            }
        }
	      
        [XmlAttribute("NombreCompletoProfDestinatario")]
        [Bindable(true)]
        public string NombreCompletoProfDestinatario 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombreCompletoProfDestinatario");
		    }
            set 
		    {
			    SetColumnValue("nombreCompletoProfDestinatario", value);
            }
        }
	      
        [XmlAttribute("IdEspDestinataria")]
        [Bindable(true)]
        public int IdEspDestinataria 
	    {
		    get
		    {
			    return GetColumnValue<int>("idEspDestinataria");
		    }
            set 
		    {
			    SetColumnValue("idEspDestinataria", value);
            }
        }
	      
        [XmlAttribute("NombreEspDestinataria")]
        [Bindable(true)]
        public string NombreEspDestinataria 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombreEspDestinataria");
		    }
            set 
		    {
			    SetColumnValue("nombreEspDestinataria", value);
            }
        }
	      
        [XmlAttribute("IdDialogoInterconsulta")]
        [Bindable(true)]
        public int? IdDialogoInterconsulta 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idDialogoInterconsulta");
		    }
            set 
		    {
			    SetColumnValue("idDialogoInterconsulta", value);
            }
        }
	      
        [XmlAttribute("IdProfDialogo")]
        [Bindable(true)]
        public int? IdProfDialogo 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idProfDialogo");
		    }
            set 
		    {
			    SetColumnValue("idProfDialogo", value);
            }
        }
	      
        [XmlAttribute("NumeroDocumentoProfDialogo")]
        [Bindable(true)]
        public int? NumeroDocumentoProfDialogo 
	    {
		    get
		    {
			    return GetColumnValue<int?>("numeroDocumentoProfDialogo");
		    }
            set 
		    {
			    SetColumnValue("numeroDocumentoProfDialogo", value);
            }
        }
	      
        [XmlAttribute("NombreCompletoProfDialogo")]
        [Bindable(true)]
        public string NombreCompletoProfDialogo 
	    {
		    get
		    {
			    return GetColumnValue<string>("nombreCompletoProfDialogo");
		    }
            set 
		    {
			    SetColumnValue("nombreCompletoProfDialogo", value);
            }
        }
	      
        [XmlAttribute("Dialogo")]
        [Bindable(true)]
        public string Dialogo 
	    {
		    get
		    {
			    return GetColumnValue<string>("dialogo");
		    }
            set 
		    {
			    SetColumnValue("dialogo", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdInterconsulta = @"idInterconsulta";
            
            public static string FechaSolicitud = @"fechaSolicitud";
            
            public static string IdProfSolicitante = @"idProfSolicitante";
            
            public static string NumeroDocumentoProfSolitante = @"numeroDocumentoProfSolitante";
            
            public static string NombreCompletoProfSolicitante = @"nombreCompletoProfSolicitante";
            
            public static string IdPaciente = @"idPaciente";
            
            public static string NumeroDocumentoPaciente = @"numeroDocumentoPaciente";
            
            public static string ApellidoPaciente = @"apellidoPaciente";
            
            public static string NombrePaciente = @"nombrePaciente";
            
            public static string IdDestinatariosInterconsulta = @"idDestinatariosInterconsulta";
            
            public static string IdProfDestinatario = @"idProfDestinatario";
            
            public static string NumeroDocumentoProfDestinatario = @"numeroDocumentoProfDestinatario";
            
            public static string NombreCompletoProfDestinatario = @"nombreCompletoProfDestinatario";
            
            public static string IdEspDestinataria = @"idEspDestinataria";
            
            public static string NombreEspDestinataria = @"nombreEspDestinataria";
            
            public static string IdDialogoInterconsulta = @"idDialogoInterconsulta";
            
            public static string IdProfDialogo = @"idProfDialogo";
            
            public static string NumeroDocumentoProfDialogo = @"numeroDocumentoProfDialogo";
            
            public static string NombreCompletoProfDialogo = @"nombreCompletoProfDialogo";
            
            public static string Dialogo = @"dialogo";
            
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
