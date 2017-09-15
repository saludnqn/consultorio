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
    /// Strongly-typed collection for the AprVwOtrosDato class.
    /// </summary>
    [Serializable]
    public partial class AprVwOtrosDatoCollection : ReadOnlyList<AprVwOtrosDato, AprVwOtrosDatoCollection>
    {        
        public AprVwOtrosDatoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the APR_VwOtrosDatos view.
    /// </summary>
    [Serializable]
    public partial class AprVwOtrosDato : ReadOnlyRecord<AprVwOtrosDato>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("APR_VwOtrosDatos", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdOtrosDatosPaternos = new TableSchema.TableColumn(schema);
                colvarIdOtrosDatosPaternos.ColumnName = "idOtrosDatosPaternos";
                colvarIdOtrosDatosPaternos.DataType = DbType.Int32;
                colvarIdOtrosDatosPaternos.MaxLength = 0;
                colvarIdOtrosDatosPaternos.AutoIncrement = false;
                colvarIdOtrosDatosPaternos.IsNullable = false;
                colvarIdOtrosDatosPaternos.IsPrimaryKey = false;
                colvarIdOtrosDatosPaternos.IsForeignKey = false;
                colvarIdOtrosDatosPaternos.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdOtrosDatosPaternos);
                
                TableSchema.TableColumn colvarTrabaja = new TableSchema.TableColumn(schema);
                colvarTrabaja.ColumnName = "Trabaja";
                colvarTrabaja.DataType = DbType.Boolean;
                colvarTrabaja.MaxLength = 0;
                colvarTrabaja.AutoIncrement = false;
                colvarTrabaja.IsNullable = true;
                colvarTrabaja.IsPrimaryKey = false;
                colvarTrabaja.IsForeignKey = false;
                colvarTrabaja.IsReadOnly = false;
                
                schema.Columns.Add(colvarTrabaja);
                
                TableSchema.TableColumn colvarCantidadHoras = new TableSchema.TableColumn(schema);
                colvarCantidadHoras.ColumnName = "CantidadHoras";
                colvarCantidadHoras.DataType = DbType.Int32;
                colvarCantidadHoras.MaxLength = 0;
                colvarCantidadHoras.AutoIncrement = false;
                colvarCantidadHoras.IsNullable = true;
                colvarCantidadHoras.IsPrimaryKey = false;
                colvarCantidadHoras.IsForeignKey = false;
                colvarCantidadHoras.IsReadOnly = false;
                
                schema.Columns.Add(colvarCantidadHoras);
                
                TableSchema.TableColumn colvarAsistenciaEconomica = new TableSchema.TableColumn(schema);
                colvarAsistenciaEconomica.ColumnName = "AsistenciaEconomica";
                colvarAsistenciaEconomica.DataType = DbType.Boolean;
                colvarAsistenciaEconomica.MaxLength = 0;
                colvarAsistenciaEconomica.AutoIncrement = false;
                colvarAsistenciaEconomica.IsNullable = true;
                colvarAsistenciaEconomica.IsPrimaryKey = false;
                colvarAsistenciaEconomica.IsForeignKey = false;
                colvarAsistenciaEconomica.IsReadOnly = false;
                
                schema.Columns.Add(colvarAsistenciaEconomica);
                
                TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
                colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
                colvarIdControlNiñoSano.DataType = DbType.Int32;
                colvarIdControlNiñoSano.MaxLength = 0;
                colvarIdControlNiñoSano.AutoIncrement = false;
                colvarIdControlNiñoSano.IsNullable = true;
                colvarIdControlNiñoSano.IsPrimaryKey = false;
                colvarIdControlNiñoSano.IsForeignKey = false;
                colvarIdControlNiñoSano.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdControlNiñoSano);
                
                TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
                colvarIdConsulta.ColumnName = "idConsulta";
                colvarIdConsulta.DataType = DbType.Int32;
                colvarIdConsulta.MaxLength = 0;
                colvarIdConsulta.AutoIncrement = false;
                colvarIdConsulta.IsNullable = false;
                colvarIdConsulta.IsPrimaryKey = false;
                colvarIdConsulta.IsForeignKey = false;
                colvarIdConsulta.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdConsulta);
                
                TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
                colvarIdPaciente.ColumnName = "idPaciente";
                colvarIdPaciente.DataType = DbType.Int32;
                colvarIdPaciente.MaxLength = 0;
                colvarIdPaciente.AutoIncrement = false;
                colvarIdPaciente.IsNullable = true;
                colvarIdPaciente.IsPrimaryKey = false;
                colvarIdPaciente.IsForeignKey = false;
                colvarIdPaciente.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdPaciente);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("APR_VwOtrosDatos",schema);
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
	    public AprVwOtrosDato()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public AprVwOtrosDato(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public AprVwOtrosDato(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public AprVwOtrosDato(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdOtrosDatosPaternos")]
        [Bindable(true)]
        public int IdOtrosDatosPaternos 
	    {
		    get
		    {
			    return GetColumnValue<int>("idOtrosDatosPaternos");
		    }
            set 
		    {
			    SetColumnValue("idOtrosDatosPaternos", value);
            }
        }
	      
        [XmlAttribute("Trabaja")]
        [Bindable(true)]
        public bool? Trabaja 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("Trabaja");
		    }
            set 
		    {
			    SetColumnValue("Trabaja", value);
            }
        }
	      
        [XmlAttribute("CantidadHoras")]
        [Bindable(true)]
        public int? CantidadHoras 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CantidadHoras");
		    }
            set 
		    {
			    SetColumnValue("CantidadHoras", value);
            }
        }
	      
        [XmlAttribute("AsistenciaEconomica")]
        [Bindable(true)]
        public bool? AsistenciaEconomica 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("AsistenciaEconomica");
		    }
            set 
		    {
			    SetColumnValue("AsistenciaEconomica", value);
            }
        }
	      
        [XmlAttribute("IdControlNiñoSano")]
        [Bindable(true)]
        public int? IdControlNiñoSano 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idControlNiñoSano");
		    }
            set 
		    {
			    SetColumnValue("idControlNiñoSano", value);
            }
        }
	      
        [XmlAttribute("IdConsulta")]
        [Bindable(true)]
        public int IdConsulta 
	    {
		    get
		    {
			    return GetColumnValue<int>("idConsulta");
		    }
            set 
		    {
			    SetColumnValue("idConsulta", value);
            }
        }
	      
        [XmlAttribute("IdPaciente")]
        [Bindable(true)]
        public int? IdPaciente 
	    {
		    get
		    {
			    return GetColumnValue<int?>("idPaciente");
		    }
            set 
		    {
			    SetColumnValue("idPaciente", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdOtrosDatosPaternos = @"idOtrosDatosPaternos";
            
            public static string Trabaja = @"Trabaja";
            
            public static string CantidadHoras = @"CantidadHoras";
            
            public static string AsistenciaEconomica = @"AsistenciaEconomica";
            
            public static string IdControlNiñoSano = @"idControlNiñoSano";
            
            public static string IdConsulta = @"idConsulta";
            
            public static string IdPaciente = @"idPaciente";
            
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
