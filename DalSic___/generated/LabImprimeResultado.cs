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
    /// Strongly-typed collection for the LabImprimeResultado class.
    /// </summary>
    [Serializable]
    public partial class LabImprimeResultadoCollection : ReadOnlyList<LabImprimeResultado, LabImprimeResultadoCollection>
    {        
        public LabImprimeResultadoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the LAB_ImprimeResultado view.
    /// </summary>
    [Serializable]
    public partial class LabImprimeResultado : ReadOnlyRecord<LabImprimeResultado>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("LAB_ImprimeResultado", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdProtocolo = new TableSchema.TableColumn(schema);
                colvarIdProtocolo.ColumnName = "idProtocolo";
                colvarIdProtocolo.DataType = DbType.Int32;
                colvarIdProtocolo.MaxLength = 0;
                colvarIdProtocolo.AutoIncrement = false;
                colvarIdProtocolo.IsNullable = false;
                colvarIdProtocolo.IsPrimaryKey = false;
                colvarIdProtocolo.IsForeignKey = false;
                colvarIdProtocolo.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdProtocolo);
                
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
                
                TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
                colvarNumeroDocumento.ColumnName = "numeroDocumento";
                colvarNumeroDocumento.DataType = DbType.Int32;
                colvarNumeroDocumento.MaxLength = 0;
                colvarNumeroDocumento.AutoIncrement = false;
                colvarNumeroDocumento.IsNullable = false;
                colvarNumeroDocumento.IsPrimaryKey = false;
                colvarNumeroDocumento.IsForeignKey = false;
                colvarNumeroDocumento.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumeroDocumento);
                
                TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
                colvarFecha.ColumnName = "fecha";
                colvarFecha.DataType = DbType.AnsiString;
                colvarFecha.MaxLength = 10;
                colvarFecha.AutoIncrement = false;
                colvarFecha.IsNullable = true;
                colvarFecha.IsPrimaryKey = false;
                colvarFecha.IsForeignKey = false;
                colvarFecha.IsReadOnly = false;
                
                schema.Columns.Add(colvarFecha);
                
                TableSchema.TableColumn colvarPrioridad = new TableSchema.TableColumn(schema);
                colvarPrioridad.ColumnName = "prioridad";
                colvarPrioridad.DataType = DbType.String;
                colvarPrioridad.MaxLength = 50;
                colvarPrioridad.AutoIncrement = false;
                colvarPrioridad.IsNullable = false;
                colvarPrioridad.IsPrimaryKey = false;
                colvarPrioridad.IsForeignKey = false;
                colvarPrioridad.IsReadOnly = false;
                
                schema.Columns.Add(colvarPrioridad);
                
                TableSchema.TableColumn colvarOrigen = new TableSchema.TableColumn(schema);
                colvarOrigen.ColumnName = "origen";
                colvarOrigen.DataType = DbType.String;
                colvarOrigen.MaxLength = 50;
                colvarOrigen.AutoIncrement = false;
                colvarOrigen.IsNullable = false;
                colvarOrigen.IsPrimaryKey = false;
                colvarOrigen.IsForeignKey = false;
                colvarOrigen.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrigen);
                
                TableSchema.TableColumn colvarUnidadEdad = new TableSchema.TableColumn(schema);
                colvarUnidadEdad.ColumnName = "unidadEdad";
                colvarUnidadEdad.DataType = DbType.AnsiString;
                colvarUnidadEdad.MaxLength = 5;
                colvarUnidadEdad.AutoIncrement = false;
                colvarUnidadEdad.IsNullable = true;
                colvarUnidadEdad.IsPrimaryKey = false;
                colvarUnidadEdad.IsForeignKey = false;
                colvarUnidadEdad.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidadEdad);
                
                TableSchema.TableColumn colvarArea = new TableSchema.TableColumn(schema);
                colvarArea.ColumnName = "area";
                colvarArea.DataType = DbType.String;
                colvarArea.MaxLength = 50;
                colvarArea.AutoIncrement = false;
                colvarArea.IsNullable = false;
                colvarArea.IsPrimaryKey = false;
                colvarArea.IsForeignKey = false;
                colvarArea.IsReadOnly = false;
                
                schema.Columns.Add(colvarArea);
                
                TableSchema.TableColumn colvarGrupo = new TableSchema.TableColumn(schema);
                colvarGrupo.ColumnName = "grupo";
                colvarGrupo.DataType = DbType.String;
                colvarGrupo.MaxLength = 500;
                colvarGrupo.AutoIncrement = false;
                colvarGrupo.IsNullable = false;
                colvarGrupo.IsPrimaryKey = false;
                colvarGrupo.IsForeignKey = false;
                colvarGrupo.IsReadOnly = false;
                
                schema.Columns.Add(colvarGrupo);
                
                TableSchema.TableColumn colvarItem = new TableSchema.TableColumn(schema);
                colvarItem.ColumnName = "item";
                colvarItem.DataType = DbType.String;
                colvarItem.MaxLength = 500;
                colvarItem.AutoIncrement = false;
                colvarItem.IsNullable = false;
                colvarItem.IsPrimaryKey = false;
                colvarItem.IsForeignKey = false;
                colvarItem.IsReadOnly = false;
                
                schema.Columns.Add(colvarItem);
                
                TableSchema.TableColumn colvarEsTitulo = new TableSchema.TableColumn(schema);
                colvarEsTitulo.ColumnName = "esTitulo";
                colvarEsTitulo.DataType = DbType.AnsiString;
                colvarEsTitulo.MaxLength = 2;
                colvarEsTitulo.AutoIncrement = false;
                colvarEsTitulo.IsNullable = false;
                colvarEsTitulo.IsPrimaryKey = false;
                colvarEsTitulo.IsForeignKey = false;
                colvarEsTitulo.IsReadOnly = false;
                
                schema.Columns.Add(colvarEsTitulo);
                
                TableSchema.TableColumn colvarUnidad = new TableSchema.TableColumn(schema);
                colvarUnidad.ColumnName = "unidad";
                colvarUnidad.DataType = DbType.String;
                colvarUnidad.MaxLength = 100;
                colvarUnidad.AutoIncrement = false;
                colvarUnidad.IsNullable = false;
                colvarUnidad.IsPrimaryKey = false;
                colvarUnidad.IsForeignKey = false;
                colvarUnidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnidad);
                
                TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
                colvarNumero.ColumnName = "numero";
                colvarNumero.DataType = DbType.AnsiString;
                colvarNumero.MaxLength = 50;
                colvarNumero.AutoIncrement = false;
                colvarNumero.IsNullable = true;
                colvarNumero.IsPrimaryKey = false;
                colvarNumero.IsForeignKey = false;
                colvarNumero.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumero);
                
                TableSchema.TableColumn colvarMetodo = new TableSchema.TableColumn(schema);
                colvarMetodo.ColumnName = "metodo";
                colvarMetodo.DataType = DbType.String;
                colvarMetodo.MaxLength = 100;
                colvarMetodo.AutoIncrement = false;
                colvarMetodo.IsNullable = false;
                colvarMetodo.IsPrimaryKey = false;
                colvarMetodo.IsForeignKey = false;
                colvarMetodo.IsReadOnly = false;
                
                schema.Columns.Add(colvarMetodo);
                
                TableSchema.TableColumn colvarValorReferencia = new TableSchema.TableColumn(schema);
                colvarValorReferencia.ColumnName = "valorReferencia";
                colvarValorReferencia.DataType = DbType.String;
                colvarValorReferencia.MaxLength = 500;
                colvarValorReferencia.AutoIncrement = false;
                colvarValorReferencia.IsNullable = true;
                colvarValorReferencia.IsPrimaryKey = false;
                colvarValorReferencia.IsForeignKey = false;
                colvarValorReferencia.IsReadOnly = false;
                
                schema.Columns.Add(colvarValorReferencia);
                
                TableSchema.TableColumn colvarSolicitante = new TableSchema.TableColumn(schema);
                colvarSolicitante.ColumnName = "solicitante";
                colvarSolicitante.DataType = DbType.String;
                colvarSolicitante.MaxLength = 205;
                colvarSolicitante.AutoIncrement = false;
                colvarSolicitante.IsNullable = true;
                colvarSolicitante.IsPrimaryKey = false;
                colvarSolicitante.IsForeignKey = false;
                colvarSolicitante.IsReadOnly = false;
                
                schema.Columns.Add(colvarSolicitante);
                
                TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
                colvarEdad.ColumnName = "edad";
                colvarEdad.DataType = DbType.Int32;
                colvarEdad.MaxLength = 0;
                colvarEdad.AutoIncrement = false;
                colvarEdad.IsNullable = false;
                colvarEdad.IsPrimaryKey = false;
                colvarEdad.IsForeignKey = false;
                colvarEdad.IsReadOnly = false;
                
                schema.Columns.Add(colvarEdad);
                
                TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
                colvarSexo.ColumnName = "sexo";
                colvarSexo.DataType = DbType.String;
                colvarSexo.MaxLength = 1;
                colvarSexo.AutoIncrement = false;
                colvarSexo.IsNullable = false;
                colvarSexo.IsPrimaryKey = false;
                colvarSexo.IsForeignKey = false;
                colvarSexo.IsReadOnly = false;
                
                schema.Columns.Add(colvarSexo);
                
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
                
                TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
                colvarFechaNacimiento.ColumnName = "fechaNacimiento";
                colvarFechaNacimiento.DataType = DbType.AnsiString;
                colvarFechaNacimiento.MaxLength = 10;
                colvarFechaNacimiento.AutoIncrement = false;
                colvarFechaNacimiento.IsNullable = true;
                colvarFechaNacimiento.IsPrimaryKey = false;
                colvarFechaNacimiento.IsForeignKey = false;
                colvarFechaNacimiento.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaNacimiento);
                
                TableSchema.TableColumn colvarHc = new TableSchema.TableColumn(schema);
                colvarHc.ColumnName = "HC";
                colvarHc.DataType = DbType.Int32;
                colvarHc.MaxLength = 0;
                colvarHc.AutoIncrement = false;
                colvarHc.IsNullable = false;
                colvarHc.IsPrimaryKey = false;
                colvarHc.IsForeignKey = false;
                colvarHc.IsReadOnly = false;
                
                schema.Columns.Add(colvarHc);
                
                TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
                colvarDomicilio.ColumnName = "domicilio";
                colvarDomicilio.DataType = DbType.String;
                colvarDomicilio.MaxLength = 4000;
                colvarDomicilio.AutoIncrement = false;
                colvarDomicilio.IsNullable = true;
                colvarDomicilio.IsPrimaryKey = false;
                colvarDomicilio.IsForeignKey = false;
                colvarDomicilio.IsReadOnly = false;
                
                schema.Columns.Add(colvarDomicilio);
                
                TableSchema.TableColumn colvarSector = new TableSchema.TableColumn(schema);
                colvarSector.ColumnName = "sector";
                colvarSector.DataType = DbType.AnsiString;
                colvarSector.MaxLength = 50;
                colvarSector.AutoIncrement = false;
                colvarSector.IsNullable = false;
                colvarSector.IsPrimaryKey = false;
                colvarSector.IsForeignKey = false;
                colvarSector.IsReadOnly = false;
                
                schema.Columns.Add(colvarSector);
                
                TableSchema.TableColumn colvarHiv = new TableSchema.TableColumn(schema);
                colvarHiv.ColumnName = "hiv";
                colvarHiv.DataType = DbType.Boolean;
                colvarHiv.MaxLength = 0;
                colvarHiv.AutoIncrement = false;
                colvarHiv.IsNullable = true;
                colvarHiv.IsPrimaryKey = false;
                colvarHiv.IsForeignKey = false;
                colvarHiv.IsReadOnly = false;
                
                schema.Columns.Add(colvarHiv);
                
                TableSchema.TableColumn colvarSala = new TableSchema.TableColumn(schema);
                colvarSala.ColumnName = "sala";
                colvarSala.DataType = DbType.AnsiString;
                colvarSala.MaxLength = 50;
                colvarSala.AutoIncrement = false;
                colvarSala.IsNullable = false;
                colvarSala.IsPrimaryKey = false;
                colvarSala.IsForeignKey = false;
                colvarSala.IsReadOnly = false;
                
                schema.Columns.Add(colvarSala);
                
                TableSchema.TableColumn colvarCama = new TableSchema.TableColumn(schema);
                colvarCama.ColumnName = "cama";
                colvarCama.DataType = DbType.AnsiString;
                colvarCama.MaxLength = 50;
                colvarCama.AutoIncrement = false;
                colvarCama.IsNullable = false;
                colvarCama.IsPrimaryKey = false;
                colvarCama.IsForeignKey = false;
                colvarCama.IsReadOnly = false;
                
                schema.Columns.Add(colvarCama);
                
                TableSchema.TableColumn colvarEmbarazo = new TableSchema.TableColumn(schema);
                colvarEmbarazo.ColumnName = "embarazo";
                colvarEmbarazo.DataType = DbType.AnsiString;
                colvarEmbarazo.MaxLength = 1;
                colvarEmbarazo.AutoIncrement = false;
                colvarEmbarazo.IsNullable = false;
                colvarEmbarazo.IsPrimaryKey = false;
                colvarEmbarazo.IsForeignKey = false;
                colvarEmbarazo.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmbarazo);
                
                TableSchema.TableColumn colvarResultado = new TableSchema.TableColumn(schema);
                colvarResultado.ColumnName = "resultado";
                colvarResultado.DataType = DbType.String;
                colvarResultado.MaxLength = 4000;
                colvarResultado.AutoIncrement = false;
                colvarResultado.IsNullable = true;
                colvarResultado.IsPrimaryKey = false;
                colvarResultado.IsForeignKey = false;
                colvarResultado.IsReadOnly = false;
                
                schema.Columns.Add(colvarResultado);
                
                TableSchema.TableColumn colvarOrdenArea = new TableSchema.TableColumn(schema);
                colvarOrdenArea.ColumnName = "ordenArea";
                colvarOrdenArea.DataType = DbType.Int32;
                colvarOrdenArea.MaxLength = 0;
                colvarOrdenArea.AutoIncrement = false;
                colvarOrdenArea.IsNullable = false;
                colvarOrdenArea.IsPrimaryKey = false;
                colvarOrdenArea.IsForeignKey = false;
                colvarOrdenArea.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrdenArea);
                
                TableSchema.TableColumn colvarOrden = new TableSchema.TableColumn(schema);
                colvarOrden.ColumnName = "orden";
                colvarOrden.DataType = DbType.Int32;
                colvarOrden.MaxLength = 0;
                colvarOrden.AutoIncrement = false;
                colvarOrden.IsNullable = false;
                colvarOrden.IsPrimaryKey = false;
                colvarOrden.IsForeignKey = false;
                colvarOrden.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrden);
                
                TableSchema.TableColumn colvarEfector = new TableSchema.TableColumn(schema);
                colvarEfector.ColumnName = "Efector";
                colvarEfector.DataType = DbType.String;
                colvarEfector.MaxLength = 100;
                colvarEfector.AutoIncrement = false;
                colvarEfector.IsNullable = false;
                colvarEfector.IsPrimaryKey = false;
                colvarEfector.IsForeignKey = false;
                colvarEfector.IsReadOnly = false;
                
                schema.Columns.Add(colvarEfector);
                
                TableSchema.TableColumn colvarOrden1 = new TableSchema.TableColumn(schema);
                colvarOrden1.ColumnName = "orden1";
                colvarOrden1.DataType = DbType.Int32;
                colvarOrden1.MaxLength = 0;
                colvarOrden1.AutoIncrement = false;
                colvarOrden1.IsNullable = false;
                colvarOrden1.IsPrimaryKey = false;
                colvarOrden1.IsForeignKey = false;
                colvarOrden1.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrden1);
                
                TableSchema.TableColumn colvarProfesionalVal = new TableSchema.TableColumn(schema);
                colvarProfesionalVal.ColumnName = "profesional_val";
                colvarProfesionalVal.DataType = DbType.String;
                colvarProfesionalVal.MaxLength = 500;
                colvarProfesionalVal.AutoIncrement = false;
                colvarProfesionalVal.IsNullable = false;
                colvarProfesionalVal.IsPrimaryKey = false;
                colvarProfesionalVal.IsForeignKey = false;
                colvarProfesionalVal.IsReadOnly = false;
                
                schema.Columns.Add(colvarProfesionalVal);
                
                TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
                colvarObservaciones.ColumnName = "observaciones";
                colvarObservaciones.DataType = DbType.String;
                colvarObservaciones.MaxLength = 500;
                colvarObservaciones.AutoIncrement = false;
                colvarObservaciones.IsNullable = false;
                colvarObservaciones.IsPrimaryKey = false;
                colvarObservaciones.IsForeignKey = false;
                colvarObservaciones.IsReadOnly = false;
                
                schema.Columns.Add(colvarObservaciones);
                
                TableSchema.TableColumn colvarMuestra = new TableSchema.TableColumn(schema);
                colvarMuestra.ColumnName = "muestra";
                colvarMuestra.DataType = DbType.String;
                colvarMuestra.MaxLength = 500;
                colvarMuestra.AutoIncrement = false;
                colvarMuestra.IsNullable = true;
                colvarMuestra.IsPrimaryKey = false;
                colvarMuestra.IsForeignKey = false;
                colvarMuestra.IsReadOnly = false;
                
                schema.Columns.Add(colvarMuestra);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("LAB_ImprimeResultado",schema);
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
	    public LabImprimeResultado()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public LabImprimeResultado(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public LabImprimeResultado(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public LabImprimeResultado(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdProtocolo")]
        [Bindable(true)]
        public int IdProtocolo 
	    {
		    get
		    {
			    return GetColumnValue<int>("idProtocolo");
		    }
            set 
		    {
			    SetColumnValue("idProtocolo", value);
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
	      
        [XmlAttribute("NumeroDocumento")]
        [Bindable(true)]
        public int NumeroDocumento 
	    {
		    get
		    {
			    return GetColumnValue<int>("numeroDocumento");
		    }
            set 
		    {
			    SetColumnValue("numeroDocumento", value);
            }
        }
	      
        [XmlAttribute("Fecha")]
        [Bindable(true)]
        public string Fecha 
	    {
		    get
		    {
			    return GetColumnValue<string>("fecha");
		    }
            set 
		    {
			    SetColumnValue("fecha", value);
            }
        }
	      
        [XmlAttribute("Prioridad")]
        [Bindable(true)]
        public string Prioridad 
	    {
		    get
		    {
			    return GetColumnValue<string>("prioridad");
		    }
            set 
		    {
			    SetColumnValue("prioridad", value);
            }
        }
	      
        [XmlAttribute("Origen")]
        [Bindable(true)]
        public string Origen 
	    {
		    get
		    {
			    return GetColumnValue<string>("origen");
		    }
            set 
		    {
			    SetColumnValue("origen", value);
            }
        }
	      
        [XmlAttribute("UnidadEdad")]
        [Bindable(true)]
        public string UnidadEdad 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidadEdad");
		    }
            set 
		    {
			    SetColumnValue("unidadEdad", value);
            }
        }
	      
        [XmlAttribute("Area")]
        [Bindable(true)]
        public string Area 
	    {
		    get
		    {
			    return GetColumnValue<string>("area");
		    }
            set 
		    {
			    SetColumnValue("area", value);
            }
        }
	      
        [XmlAttribute("Grupo")]
        [Bindable(true)]
        public string Grupo 
	    {
		    get
		    {
			    return GetColumnValue<string>("grupo");
		    }
            set 
		    {
			    SetColumnValue("grupo", value);
            }
        }
	      
        [XmlAttribute("Item")]
        [Bindable(true)]
        public string Item 
	    {
		    get
		    {
			    return GetColumnValue<string>("item");
		    }
            set 
		    {
			    SetColumnValue("item", value);
            }
        }
	      
        [XmlAttribute("EsTitulo")]
        [Bindable(true)]
        public string EsTitulo 
	    {
		    get
		    {
			    return GetColumnValue<string>("esTitulo");
		    }
            set 
		    {
			    SetColumnValue("esTitulo", value);
            }
        }
	      
        [XmlAttribute("Unidad")]
        [Bindable(true)]
        public string Unidad 
	    {
		    get
		    {
			    return GetColumnValue<string>("unidad");
		    }
            set 
		    {
			    SetColumnValue("unidad", value);
            }
        }
	      
        [XmlAttribute("Numero")]
        [Bindable(true)]
        public string Numero 
	    {
		    get
		    {
			    return GetColumnValue<string>("numero");
		    }
            set 
		    {
			    SetColumnValue("numero", value);
            }
        }
	      
        [XmlAttribute("Metodo")]
        [Bindable(true)]
        public string Metodo 
	    {
		    get
		    {
			    return GetColumnValue<string>("metodo");
		    }
            set 
		    {
			    SetColumnValue("metodo", value);
            }
        }
	      
        [XmlAttribute("ValorReferencia")]
        [Bindable(true)]
        public string ValorReferencia 
	    {
		    get
		    {
			    return GetColumnValue<string>("valorReferencia");
		    }
            set 
		    {
			    SetColumnValue("valorReferencia", value);
            }
        }
	      
        [XmlAttribute("Solicitante")]
        [Bindable(true)]
        public string Solicitante 
	    {
		    get
		    {
			    return GetColumnValue<string>("solicitante");
		    }
            set 
		    {
			    SetColumnValue("solicitante", value);
            }
        }
	      
        [XmlAttribute("Edad")]
        [Bindable(true)]
        public int Edad 
	    {
		    get
		    {
			    return GetColumnValue<int>("edad");
		    }
            set 
		    {
			    SetColumnValue("edad", value);
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
	      
        [XmlAttribute("FechaNacimiento")]
        [Bindable(true)]
        public string FechaNacimiento 
	    {
		    get
		    {
			    return GetColumnValue<string>("fechaNacimiento");
		    }
            set 
		    {
			    SetColumnValue("fechaNacimiento", value);
            }
        }
	      
        [XmlAttribute("Hc")]
        [Bindable(true)]
        public int Hc 
	    {
		    get
		    {
			    return GetColumnValue<int>("HC");
		    }
            set 
		    {
			    SetColumnValue("HC", value);
            }
        }
	      
        [XmlAttribute("Domicilio")]
        [Bindable(true)]
        public string Domicilio 
	    {
		    get
		    {
			    return GetColumnValue<string>("domicilio");
		    }
            set 
		    {
			    SetColumnValue("domicilio", value);
            }
        }
	      
        [XmlAttribute("Sector")]
        [Bindable(true)]
        public string Sector 
	    {
		    get
		    {
			    return GetColumnValue<string>("sector");
		    }
            set 
		    {
			    SetColumnValue("sector", value);
            }
        }
	      
        [XmlAttribute("Hiv")]
        [Bindable(true)]
        public bool? Hiv 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("hiv");
		    }
            set 
		    {
			    SetColumnValue("hiv", value);
            }
        }
	      
        [XmlAttribute("Sala")]
        [Bindable(true)]
        public string Sala 
	    {
		    get
		    {
			    return GetColumnValue<string>("sala");
		    }
            set 
		    {
			    SetColumnValue("sala", value);
            }
        }
	      
        [XmlAttribute("Cama")]
        [Bindable(true)]
        public string Cama 
	    {
		    get
		    {
			    return GetColumnValue<string>("cama");
		    }
            set 
		    {
			    SetColumnValue("cama", value);
            }
        }
	      
        [XmlAttribute("Embarazo")]
        [Bindable(true)]
        public string Embarazo 
	    {
		    get
		    {
			    return GetColumnValue<string>("embarazo");
		    }
            set 
		    {
			    SetColumnValue("embarazo", value);
            }
        }
	      
        [XmlAttribute("Resultado")]
        [Bindable(true)]
        public string Resultado 
	    {
		    get
		    {
			    return GetColumnValue<string>("resultado");
		    }
            set 
		    {
			    SetColumnValue("resultado", value);
            }
        }
	      
        [XmlAttribute("OrdenArea")]
        [Bindable(true)]
        public int OrdenArea 
	    {
		    get
		    {
			    return GetColumnValue<int>("ordenArea");
		    }
            set 
		    {
			    SetColumnValue("ordenArea", value);
            }
        }
	      
        [XmlAttribute("Orden")]
        [Bindable(true)]
        public int Orden 
	    {
		    get
		    {
			    return GetColumnValue<int>("orden");
		    }
            set 
		    {
			    SetColumnValue("orden", value);
            }
        }
	      
        [XmlAttribute("Efector")]
        [Bindable(true)]
        public string Efector 
	    {
		    get
		    {
			    return GetColumnValue<string>("Efector");
		    }
            set 
		    {
			    SetColumnValue("Efector", value);
            }
        }
	      
        [XmlAttribute("Orden1")]
        [Bindable(true)]
        public int Orden1 
	    {
		    get
		    {
			    return GetColumnValue<int>("orden1");
		    }
            set 
		    {
			    SetColumnValue("orden1", value);
            }
        }
	      
        [XmlAttribute("ProfesionalVal")]
        [Bindable(true)]
        public string ProfesionalVal 
	    {
		    get
		    {
			    return GetColumnValue<string>("profesional_val");
		    }
            set 
		    {
			    SetColumnValue("profesional_val", value);
            }
        }
	      
        [XmlAttribute("Observaciones")]
        [Bindable(true)]
        public string Observaciones 
	    {
		    get
		    {
			    return GetColumnValue<string>("observaciones");
		    }
            set 
		    {
			    SetColumnValue("observaciones", value);
            }
        }
	      
        [XmlAttribute("Muestra")]
        [Bindable(true)]
        public string Muestra 
	    {
		    get
		    {
			    return GetColumnValue<string>("muestra");
		    }
            set 
		    {
			    SetColumnValue("muestra", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdProtocolo = @"idProtocolo";
            
            public static string IdEfector = @"idEfector";
            
            public static string Apellido = @"apellido";
            
            public static string NumeroDocumento = @"numeroDocumento";
            
            public static string Fecha = @"fecha";
            
            public static string Prioridad = @"prioridad";
            
            public static string Origen = @"origen";
            
            public static string UnidadEdad = @"unidadEdad";
            
            public static string Area = @"area";
            
            public static string Grupo = @"grupo";
            
            public static string Item = @"item";
            
            public static string EsTitulo = @"esTitulo";
            
            public static string Unidad = @"unidad";
            
            public static string Numero = @"numero";
            
            public static string Metodo = @"metodo";
            
            public static string ValorReferencia = @"valorReferencia";
            
            public static string Solicitante = @"solicitante";
            
            public static string Edad = @"edad";
            
            public static string Sexo = @"sexo";
            
            public static string Nombre = @"nombre";
            
            public static string FechaNacimiento = @"fechaNacimiento";
            
            public static string Hc = @"HC";
            
            public static string Domicilio = @"domicilio";
            
            public static string Sector = @"sector";
            
            public static string Hiv = @"hiv";
            
            public static string Sala = @"sala";
            
            public static string Cama = @"cama";
            
            public static string Embarazo = @"embarazo";
            
            public static string Resultado = @"resultado";
            
            public static string OrdenArea = @"ordenArea";
            
            public static string Orden = @"orden";
            
            public static string Efector = @"Efector";
            
            public static string Orden1 = @"orden1";
            
            public static string ProfesionalVal = @"profesional_val";
            
            public static string Observaciones = @"observaciones";
            
            public static string Muestra = @"muestra";
            
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
