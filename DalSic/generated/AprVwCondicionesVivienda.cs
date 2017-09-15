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
    /// Strongly-typed collection for the AprVwCondicionesVivienda class.
    /// </summary>
    [Serializable]
    public partial class AprVwCondicionesViviendaCollection : ReadOnlyList<AprVwCondicionesVivienda, AprVwCondicionesViviendaCollection>
    {        
        public AprVwCondicionesViviendaCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the APR_VwCondicionesVivienda view.
    /// </summary>
    [Serializable]
    public partial class AprVwCondicionesVivienda : ReadOnlyRecord<AprVwCondicionesVivienda>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("APR_VwCondicionesVivienda", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdCondicionesVivienda = new TableSchema.TableColumn(schema);
                colvarIdCondicionesVivienda.ColumnName = "idCondicionesVivienda";
                colvarIdCondicionesVivienda.DataType = DbType.Int32;
                colvarIdCondicionesVivienda.MaxLength = 0;
                colvarIdCondicionesVivienda.AutoIncrement = false;
                colvarIdCondicionesVivienda.IsNullable = false;
                colvarIdCondicionesVivienda.IsPrimaryKey = false;
                colvarIdCondicionesVivienda.IsForeignKey = false;
                colvarIdCondicionesVivienda.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdCondicionesVivienda);
                
                TableSchema.TableColumn colvarPisoTierra = new TableSchema.TableColumn(schema);
                colvarPisoTierra.ColumnName = "PisoTierra";
                colvarPisoTierra.DataType = DbType.Boolean;
                colvarPisoTierra.MaxLength = 0;
                colvarPisoTierra.AutoIncrement = false;
                colvarPisoTierra.IsNullable = true;
                colvarPisoTierra.IsPrimaryKey = false;
                colvarPisoTierra.IsForeignKey = false;
                colvarPisoTierra.IsReadOnly = false;
                
                schema.Columns.Add(colvarPisoTierra);
                
                TableSchema.TableColumn colvarPisoMaterial = new TableSchema.TableColumn(schema);
                colvarPisoMaterial.ColumnName = "PisoMaterial";
                colvarPisoMaterial.DataType = DbType.Boolean;
                colvarPisoMaterial.MaxLength = 0;
                colvarPisoMaterial.AutoIncrement = false;
                colvarPisoMaterial.IsNullable = true;
                colvarPisoMaterial.IsPrimaryKey = false;
                colvarPisoMaterial.IsForeignKey = false;
                colvarPisoMaterial.IsReadOnly = false;
                
                schema.Columns.Add(colvarPisoMaterial);
                
                TableSchema.TableColumn colvarBRecoleccion = new TableSchema.TableColumn(schema);
                colvarBRecoleccion.ColumnName = "BRecoleccion";
                colvarBRecoleccion.DataType = DbType.Boolean;
                colvarBRecoleccion.MaxLength = 0;
                colvarBRecoleccion.AutoIncrement = false;
                colvarBRecoleccion.IsNullable = true;
                colvarBRecoleccion.IsPrimaryKey = false;
                colvarBRecoleccion.IsForeignKey = false;
                colvarBRecoleccion.IsReadOnly = false;
                
                schema.Columns.Add(colvarBRecoleccion);
                
                TableSchema.TableColumn colvarBEntierran = new TableSchema.TableColumn(schema);
                colvarBEntierran.ColumnName = "BEntierran";
                colvarBEntierran.DataType = DbType.Boolean;
                colvarBEntierran.MaxLength = 0;
                colvarBEntierran.AutoIncrement = false;
                colvarBEntierran.IsNullable = true;
                colvarBEntierran.IsPrimaryKey = false;
                colvarBEntierran.IsForeignKey = false;
                colvarBEntierran.IsReadOnly = false;
                
                schema.Columns.Add(colvarBEntierran);
                
                TableSchema.TableColumn colvarBQueman = new TableSchema.TableColumn(schema);
                colvarBQueman.ColumnName = "BQueman";
                colvarBQueman.DataType = DbType.Boolean;
                colvarBQueman.MaxLength = 0;
                colvarBQueman.AutoIncrement = false;
                colvarBQueman.IsNullable = true;
                colvarBQueman.IsPrimaryKey = false;
                colvarBQueman.IsForeignKey = false;
                colvarBQueman.IsReadOnly = false;
                
                schema.Columns.Add(colvarBQueman);
                
                TableSchema.TableColumn colvarBOtra = new TableSchema.TableColumn(schema);
                colvarBOtra.ColumnName = "BOtra";
                colvarBOtra.DataType = DbType.Boolean;
                colvarBOtra.MaxLength = 0;
                colvarBOtra.AutoIncrement = false;
                colvarBOtra.IsNullable = true;
                colvarBOtra.IsPrimaryKey = false;
                colvarBOtra.IsForeignKey = false;
                colvarBOtra.IsReadOnly = false;
                
                schema.Columns.Add(colvarBOtra);
                
                TableSchema.TableColumn colvarFCGasNatural = new TableSchema.TableColumn(schema);
                colvarFCGasNatural.ColumnName = "FCGasNatural";
                colvarFCGasNatural.DataType = DbType.Boolean;
                colvarFCGasNatural.MaxLength = 0;
                colvarFCGasNatural.AutoIncrement = false;
                colvarFCGasNatural.IsNullable = true;
                colvarFCGasNatural.IsPrimaryKey = false;
                colvarFCGasNatural.IsForeignKey = false;
                colvarFCGasNatural.IsReadOnly = false;
                
                schema.Columns.Add(colvarFCGasNatural);
                
                TableSchema.TableColumn colvarFCGarrafa = new TableSchema.TableColumn(schema);
                colvarFCGarrafa.ColumnName = "FCGarrafa";
                colvarFCGarrafa.DataType = DbType.Boolean;
                colvarFCGarrafa.MaxLength = 0;
                colvarFCGarrafa.AutoIncrement = false;
                colvarFCGarrafa.IsNullable = true;
                colvarFCGarrafa.IsPrimaryKey = false;
                colvarFCGarrafa.IsForeignKey = false;
                colvarFCGarrafa.IsReadOnly = false;
                
                schema.Columns.Add(colvarFCGarrafa);
                
                TableSchema.TableColumn colvarFCCarbon = new TableSchema.TableColumn(schema);
                colvarFCCarbon.ColumnName = "FCCarbon";
                colvarFCCarbon.DataType = DbType.Boolean;
                colvarFCCarbon.MaxLength = 0;
                colvarFCCarbon.AutoIncrement = false;
                colvarFCCarbon.IsNullable = true;
                colvarFCCarbon.IsPrimaryKey = false;
                colvarFCCarbon.IsForeignKey = false;
                colvarFCCarbon.IsReadOnly = false;
                
                schema.Columns.Add(colvarFCCarbon);
                
                TableSchema.TableColumn colvarFCKerosen = new TableSchema.TableColumn(schema);
                colvarFCKerosen.ColumnName = "FCKerosen";
                colvarFCKerosen.DataType = DbType.Boolean;
                colvarFCKerosen.MaxLength = 0;
                colvarFCKerosen.AutoIncrement = false;
                colvarFCKerosen.IsNullable = true;
                colvarFCKerosen.IsPrimaryKey = false;
                colvarFCKerosen.IsForeignKey = false;
                colvarFCKerosen.IsReadOnly = false;
                
                schema.Columns.Add(colvarFCKerosen);
                
                TableSchema.TableColumn colvarFCElectricidad = new TableSchema.TableColumn(schema);
                colvarFCElectricidad.ColumnName = "FCElectricidad";
                colvarFCElectricidad.DataType = DbType.Boolean;
                colvarFCElectricidad.MaxLength = 0;
                colvarFCElectricidad.AutoIncrement = false;
                colvarFCElectricidad.IsNullable = true;
                colvarFCElectricidad.IsPrimaryKey = false;
                colvarFCElectricidad.IsForeignKey = false;
                colvarFCElectricidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarFCElectricidad);
                
                TableSchema.TableColumn colvarFCOtro = new TableSchema.TableColumn(schema);
                colvarFCOtro.ColumnName = "FCOtro";
                colvarFCOtro.DataType = DbType.Boolean;
                colvarFCOtro.MaxLength = 0;
                colvarFCOtro.AutoIncrement = false;
                colvarFCOtro.IsNullable = true;
                colvarFCOtro.IsPrimaryKey = false;
                colvarFCOtro.IsForeignKey = false;
                colvarFCOtro.IsReadOnly = false;
                
                schema.Columns.Add(colvarFCOtro);
                
                TableSchema.TableColumn colvarPCHumo = new TableSchema.TableColumn(schema);
                colvarPCHumo.ColumnName = "PCHumo";
                colvarPCHumo.DataType = DbType.Boolean;
                colvarPCHumo.MaxLength = 0;
                colvarPCHumo.AutoIncrement = false;
                colvarPCHumo.IsNullable = true;
                colvarPCHumo.IsPrimaryKey = false;
                colvarPCHumo.IsForeignKey = false;
                colvarPCHumo.IsReadOnly = false;
                
                schema.Columns.Add(colvarPCHumo);
                
                TableSchema.TableColumn colvarPCBasurales = new TableSchema.TableColumn(schema);
                colvarPCBasurales.ColumnName = "PCBasurales";
                colvarPCBasurales.DataType = DbType.Boolean;
                colvarPCBasurales.MaxLength = 0;
                colvarPCBasurales.AutoIncrement = false;
                colvarPCBasurales.IsNullable = true;
                colvarPCBasurales.IsPrimaryKey = false;
                colvarPCBasurales.IsForeignKey = false;
                colvarPCBasurales.IsReadOnly = false;
                
                schema.Columns.Add(colvarPCBasurales);
                
                TableSchema.TableColumn colvarPCAgroquimicos = new TableSchema.TableColumn(schema);
                colvarPCAgroquimicos.ColumnName = "PCAgroquimicos";
                colvarPCAgroquimicos.DataType = DbType.Boolean;
                colvarPCAgroquimicos.MaxLength = 0;
                colvarPCAgroquimicos.AutoIncrement = false;
                colvarPCAgroquimicos.IsNullable = true;
                colvarPCAgroquimicos.IsPrimaryKey = false;
                colvarPCAgroquimicos.IsForeignKey = false;
                colvarPCAgroquimicos.IsReadOnly = false;
                
                schema.Columns.Add(colvarPCAgroquimicos);
                
                TableSchema.TableColumn colvarPCVectores = new TableSchema.TableColumn(schema);
                colvarPCVectores.ColumnName = "PCVectores";
                colvarPCVectores.DataType = DbType.Boolean;
                colvarPCVectores.MaxLength = 0;
                colvarPCVectores.AutoIncrement = false;
                colvarPCVectores.IsNullable = true;
                colvarPCVectores.IsPrimaryKey = false;
                colvarPCVectores.IsForeignKey = false;
                colvarPCVectores.IsReadOnly = false;
                
                schema.Columns.Add(colvarPCVectores);
                
                TableSchema.TableColumn colvarPCTerrInundados = new TableSchema.TableColumn(schema);
                colvarPCTerrInundados.ColumnName = "PCTerrInundados";
                colvarPCTerrInundados.DataType = DbType.Boolean;
                colvarPCTerrInundados.MaxLength = 0;
                colvarPCTerrInundados.AutoIncrement = false;
                colvarPCTerrInundados.IsNullable = true;
                colvarPCTerrInundados.IsPrimaryKey = false;
                colvarPCTerrInundados.IsForeignKey = false;
                colvarPCTerrInundados.IsReadOnly = false;
                
                schema.Columns.Add(colvarPCTerrInundados);
                
                TableSchema.TableColumn colvarPCPetroquimicos = new TableSchema.TableColumn(schema);
                colvarPCPetroquimicos.ColumnName = "PCPetroquimicos";
                colvarPCPetroquimicos.DataType = DbType.Boolean;
                colvarPCPetroquimicos.MaxLength = 0;
                colvarPCPetroquimicos.AutoIncrement = false;
                colvarPCPetroquimicos.IsNullable = true;
                colvarPCPetroquimicos.IsPrimaryKey = false;
                colvarPCPetroquimicos.IsForeignKey = false;
                colvarPCPetroquimicos.IsReadOnly = false;
                
                schema.Columns.Add(colvarPCPetroquimicos);
                
                TableSchema.TableColumn colvarCRedAgua = new TableSchema.TableColumn(schema);
                colvarCRedAgua.ColumnName = "CRedAgua";
                colvarCRedAgua.DataType = DbType.Boolean;
                colvarCRedAgua.MaxLength = 0;
                colvarCRedAgua.AutoIncrement = false;
                colvarCRedAgua.IsNullable = true;
                colvarCRedAgua.IsPrimaryKey = false;
                colvarCRedAgua.IsForeignKey = false;
                colvarCRedAgua.IsReadOnly = false;
                
                schema.Columns.Add(colvarCRedAgua);
                
                TableSchema.TableColumn colvarCRedExcretas = new TableSchema.TableColumn(schema);
                colvarCRedExcretas.ColumnName = "CRedExcretas";
                colvarCRedExcretas.DataType = DbType.Boolean;
                colvarCRedExcretas.MaxLength = 0;
                colvarCRedExcretas.AutoIncrement = false;
                colvarCRedExcretas.IsNullable = true;
                colvarCRedExcretas.IsPrimaryKey = false;
                colvarCRedExcretas.IsForeignKey = false;
                colvarCRedExcretas.IsReadOnly = false;
                
                schema.Columns.Add(colvarCRedExcretas);
                
                TableSchema.TableColumn colvarNoCRedAgua = new TableSchema.TableColumn(schema);
                colvarNoCRedAgua.ColumnName = "NoCRedAgua";
                colvarNoCRedAgua.DataType = DbType.Boolean;
                colvarNoCRedAgua.MaxLength = 0;
                colvarNoCRedAgua.AutoIncrement = false;
                colvarNoCRedAgua.IsNullable = true;
                colvarNoCRedAgua.IsPrimaryKey = false;
                colvarNoCRedAgua.IsForeignKey = false;
                colvarNoCRedAgua.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoCRedAgua);
                
                TableSchema.TableColumn colvarNoCRedExcretas = new TableSchema.TableColumn(schema);
                colvarNoCRedExcretas.ColumnName = "NoCRedExcretas";
                colvarNoCRedExcretas.DataType = DbType.Boolean;
                colvarNoCRedExcretas.MaxLength = 0;
                colvarNoCRedExcretas.AutoIncrement = false;
                colvarNoCRedExcretas.IsNullable = true;
                colvarNoCRedExcretas.IsPrimaryKey = false;
                colvarNoCRedExcretas.IsForeignKey = false;
                colvarNoCRedExcretas.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoCRedExcretas);
                
                TableSchema.TableColumn colvarFHogarAgua = new TableSchema.TableColumn(schema);
                colvarFHogarAgua.ColumnName = "FHogarAgua";
                colvarFHogarAgua.DataType = DbType.Boolean;
                colvarFHogarAgua.MaxLength = 0;
                colvarFHogarAgua.AutoIncrement = false;
                colvarFHogarAgua.IsNullable = true;
                colvarFHogarAgua.IsPrimaryKey = false;
                colvarFHogarAgua.IsForeignKey = false;
                colvarFHogarAgua.IsReadOnly = false;
                
                schema.Columns.Add(colvarFHogarAgua);
                
                TableSchema.TableColumn colvarFHogarExcretas = new TableSchema.TableColumn(schema);
                colvarFHogarExcretas.ColumnName = "FHogarExcretas";
                colvarFHogarExcretas.DataType = DbType.Boolean;
                colvarFHogarExcretas.MaxLength = 0;
                colvarFHogarExcretas.AutoIncrement = false;
                colvarFHogarExcretas.IsNullable = true;
                colvarFHogarExcretas.IsPrimaryKey = false;
                colvarFHogarExcretas.IsForeignKey = false;
                colvarFHogarExcretas.IsReadOnly = false;
                
                schema.Columns.Add(colvarFHogarExcretas);
                
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
                
                TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
                colvarCreatedBy.ColumnName = "CreatedBy";
                colvarCreatedBy.DataType = DbType.AnsiString;
                colvarCreatedBy.MaxLength = 50;
                colvarCreatedBy.AutoIncrement = false;
                colvarCreatedBy.IsNullable = true;
                colvarCreatedBy.IsPrimaryKey = false;
                colvarCreatedBy.IsForeignKey = false;
                colvarCreatedBy.IsReadOnly = false;
                
                schema.Columns.Add(colvarCreatedBy);
                
                TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
                colvarCreatedOn.ColumnName = "CreatedOn";
                colvarCreatedOn.DataType = DbType.DateTime;
                colvarCreatedOn.MaxLength = 0;
                colvarCreatedOn.AutoIncrement = false;
                colvarCreatedOn.IsNullable = true;
                colvarCreatedOn.IsPrimaryKey = false;
                colvarCreatedOn.IsForeignKey = false;
                colvarCreatedOn.IsReadOnly = false;
                
                schema.Columns.Add(colvarCreatedOn);
                
                TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
                colvarModifiedBy.ColumnName = "ModifiedBy";
                colvarModifiedBy.DataType = DbType.AnsiString;
                colvarModifiedBy.MaxLength = 50;
                colvarModifiedBy.AutoIncrement = false;
                colvarModifiedBy.IsNullable = true;
                colvarModifiedBy.IsPrimaryKey = false;
                colvarModifiedBy.IsForeignKey = false;
                colvarModifiedBy.IsReadOnly = false;
                
                schema.Columns.Add(colvarModifiedBy);
                
                TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
                colvarModifiedOn.ColumnName = "ModifiedOn";
                colvarModifiedOn.DataType = DbType.DateTime;
                colvarModifiedOn.MaxLength = 0;
                colvarModifiedOn.AutoIncrement = false;
                colvarModifiedOn.IsNullable = true;
                colvarModifiedOn.IsPrimaryKey = false;
                colvarModifiedOn.IsForeignKey = false;
                colvarModifiedOn.IsReadOnly = false;
                
                schema.Columns.Add(colvarModifiedOn);
                
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
                DataService.Providers["sicProvider"].AddSchema("APR_VwCondicionesVivienda",schema);
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
	    public AprVwCondicionesVivienda()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public AprVwCondicionesVivienda(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public AprVwCondicionesVivienda(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public AprVwCondicionesVivienda(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdCondicionesVivienda")]
        [Bindable(true)]
        public int IdCondicionesVivienda 
	    {
		    get
		    {
			    return GetColumnValue<int>("idCondicionesVivienda");
		    }
            set 
		    {
			    SetColumnValue("idCondicionesVivienda", value);
            }
        }
	      
        [XmlAttribute("PisoTierra")]
        [Bindable(true)]
        public bool? PisoTierra 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PisoTierra");
		    }
            set 
		    {
			    SetColumnValue("PisoTierra", value);
            }
        }
	      
        [XmlAttribute("PisoMaterial")]
        [Bindable(true)]
        public bool? PisoMaterial 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PisoMaterial");
		    }
            set 
		    {
			    SetColumnValue("PisoMaterial", value);
            }
        }
	      
        [XmlAttribute("BRecoleccion")]
        [Bindable(true)]
        public bool? BRecoleccion 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("BRecoleccion");
		    }
            set 
		    {
			    SetColumnValue("BRecoleccion", value);
            }
        }
	      
        [XmlAttribute("BEntierran")]
        [Bindable(true)]
        public bool? BEntierran 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("BEntierran");
		    }
            set 
		    {
			    SetColumnValue("BEntierran", value);
            }
        }
	      
        [XmlAttribute("BQueman")]
        [Bindable(true)]
        public bool? BQueman 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("BQueman");
		    }
            set 
		    {
			    SetColumnValue("BQueman", value);
            }
        }
	      
        [XmlAttribute("BOtra")]
        [Bindable(true)]
        public bool? BOtra 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("BOtra");
		    }
            set 
		    {
			    SetColumnValue("BOtra", value);
            }
        }
	      
        [XmlAttribute("FCGasNatural")]
        [Bindable(true)]
        public bool? FCGasNatural 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FCGasNatural");
		    }
            set 
		    {
			    SetColumnValue("FCGasNatural", value);
            }
        }
	      
        [XmlAttribute("FCGarrafa")]
        [Bindable(true)]
        public bool? FCGarrafa 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FCGarrafa");
		    }
            set 
		    {
			    SetColumnValue("FCGarrafa", value);
            }
        }
	      
        [XmlAttribute("FCCarbon")]
        [Bindable(true)]
        public bool? FCCarbon 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FCCarbon");
		    }
            set 
		    {
			    SetColumnValue("FCCarbon", value);
            }
        }
	      
        [XmlAttribute("FCKerosen")]
        [Bindable(true)]
        public bool? FCKerosen 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FCKerosen");
		    }
            set 
		    {
			    SetColumnValue("FCKerosen", value);
            }
        }
	      
        [XmlAttribute("FCElectricidad")]
        [Bindable(true)]
        public bool? FCElectricidad 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FCElectricidad");
		    }
            set 
		    {
			    SetColumnValue("FCElectricidad", value);
            }
        }
	      
        [XmlAttribute("FCOtro")]
        [Bindable(true)]
        public bool? FCOtro 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FCOtro");
		    }
            set 
		    {
			    SetColumnValue("FCOtro", value);
            }
        }
	      
        [XmlAttribute("PCHumo")]
        [Bindable(true)]
        public bool? PCHumo 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PCHumo");
		    }
            set 
		    {
			    SetColumnValue("PCHumo", value);
            }
        }
	      
        [XmlAttribute("PCBasurales")]
        [Bindable(true)]
        public bool? PCBasurales 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PCBasurales");
		    }
            set 
		    {
			    SetColumnValue("PCBasurales", value);
            }
        }
	      
        [XmlAttribute("PCAgroquimicos")]
        [Bindable(true)]
        public bool? PCAgroquimicos 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PCAgroquimicos");
		    }
            set 
		    {
			    SetColumnValue("PCAgroquimicos", value);
            }
        }
	      
        [XmlAttribute("PCVectores")]
        [Bindable(true)]
        public bool? PCVectores 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PCVectores");
		    }
            set 
		    {
			    SetColumnValue("PCVectores", value);
            }
        }
	      
        [XmlAttribute("PCTerrInundados")]
        [Bindable(true)]
        public bool? PCTerrInundados 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PCTerrInundados");
		    }
            set 
		    {
			    SetColumnValue("PCTerrInundados", value);
            }
        }
	      
        [XmlAttribute("PCPetroquimicos")]
        [Bindable(true)]
        public bool? PCPetroquimicos 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("PCPetroquimicos");
		    }
            set 
		    {
			    SetColumnValue("PCPetroquimicos", value);
            }
        }
	      
        [XmlAttribute("CRedAgua")]
        [Bindable(true)]
        public bool? CRedAgua 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("CRedAgua");
		    }
            set 
		    {
			    SetColumnValue("CRedAgua", value);
            }
        }
	      
        [XmlAttribute("CRedExcretas")]
        [Bindable(true)]
        public bool? CRedExcretas 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("CRedExcretas");
		    }
            set 
		    {
			    SetColumnValue("CRedExcretas", value);
            }
        }
	      
        [XmlAttribute("NoCRedAgua")]
        [Bindable(true)]
        public bool? NoCRedAgua 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("NoCRedAgua");
		    }
            set 
		    {
			    SetColumnValue("NoCRedAgua", value);
            }
        }
	      
        [XmlAttribute("NoCRedExcretas")]
        [Bindable(true)]
        public bool? NoCRedExcretas 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("NoCRedExcretas");
		    }
            set 
		    {
			    SetColumnValue("NoCRedExcretas", value);
            }
        }
	      
        [XmlAttribute("FHogarAgua")]
        [Bindable(true)]
        public bool? FHogarAgua 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FHogarAgua");
		    }
            set 
		    {
			    SetColumnValue("FHogarAgua", value);
            }
        }
	      
        [XmlAttribute("FHogarExcretas")]
        [Bindable(true)]
        public bool? FHogarExcretas 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("FHogarExcretas");
		    }
            set 
		    {
			    SetColumnValue("FHogarExcretas", value);
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
	      
        [XmlAttribute("CreatedBy")]
        [Bindable(true)]
        public string CreatedBy 
	    {
		    get
		    {
			    return GetColumnValue<string>("CreatedBy");
		    }
            set 
		    {
			    SetColumnValue("CreatedBy", value);
            }
        }
	      
        [XmlAttribute("CreatedOn")]
        [Bindable(true)]
        public DateTime? CreatedOn 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("CreatedOn");
		    }
            set 
		    {
			    SetColumnValue("CreatedOn", value);
            }
        }
	      
        [XmlAttribute("ModifiedBy")]
        [Bindable(true)]
        public string ModifiedBy 
	    {
		    get
		    {
			    return GetColumnValue<string>("ModifiedBy");
		    }
            set 
		    {
			    SetColumnValue("ModifiedBy", value);
            }
        }
	      
        [XmlAttribute("ModifiedOn")]
        [Bindable(true)]
        public DateTime? ModifiedOn 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("ModifiedOn");
		    }
            set 
		    {
			    SetColumnValue("ModifiedOn", value);
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
		    
		    
            public static string IdCondicionesVivienda = @"idCondicionesVivienda";
            
            public static string PisoTierra = @"PisoTierra";
            
            public static string PisoMaterial = @"PisoMaterial";
            
            public static string BRecoleccion = @"BRecoleccion";
            
            public static string BEntierran = @"BEntierran";
            
            public static string BQueman = @"BQueman";
            
            public static string BOtra = @"BOtra";
            
            public static string FCGasNatural = @"FCGasNatural";
            
            public static string FCGarrafa = @"FCGarrafa";
            
            public static string FCCarbon = @"FCCarbon";
            
            public static string FCKerosen = @"FCKerosen";
            
            public static string FCElectricidad = @"FCElectricidad";
            
            public static string FCOtro = @"FCOtro";
            
            public static string PCHumo = @"PCHumo";
            
            public static string PCBasurales = @"PCBasurales";
            
            public static string PCAgroquimicos = @"PCAgroquimicos";
            
            public static string PCVectores = @"PCVectores";
            
            public static string PCTerrInundados = @"PCTerrInundados";
            
            public static string PCPetroquimicos = @"PCPetroquimicos";
            
            public static string CRedAgua = @"CRedAgua";
            
            public static string CRedExcretas = @"CRedExcretas";
            
            public static string NoCRedAgua = @"NoCRedAgua";
            
            public static string NoCRedExcretas = @"NoCRedExcretas";
            
            public static string FHogarAgua = @"FHogarAgua";
            
            public static string FHogarExcretas = @"FHogarExcretas";
            
            public static string IdControlNiñoSano = @"idControlNiñoSano";
            
            public static string CreatedBy = @"CreatedBy";
            
            public static string CreatedOn = @"CreatedOn";
            
            public static string ModifiedBy = @"ModifiedBy";
            
            public static string ModifiedOn = @"ModifiedOn";
            
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
