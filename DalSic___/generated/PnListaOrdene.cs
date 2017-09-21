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
    /// Strongly-typed collection for the PnListaOrdene class.
    /// </summary>
    [Serializable]
    public partial class PnListaOrdeneCollection : ReadOnlyList<PnListaOrdene, PnListaOrdeneCollection>
    {        
        public PnListaOrdeneCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the PN_ListaOrdenes view.
    /// </summary>
    [Serializable]
    public partial class PnListaOrdene : ReadOnlyRecord<PnListaOrdene>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("PN_ListaOrdenes", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
                colvarCuie.ColumnName = "cuie";
                colvarCuie.DataType = DbType.AnsiString;
                colvarCuie.MaxLength = -1;
                colvarCuie.AutoIncrement = false;
                colvarCuie.IsNullable = false;
                colvarCuie.IsPrimaryKey = false;
                colvarCuie.IsForeignKey = false;
                colvarCuie.IsReadOnly = false;
                
                schema.Columns.Add(colvarCuie);
                
                TableSchema.TableColumn colvarClavebeneficiario = new TableSchema.TableColumn(schema);
                colvarClavebeneficiario.ColumnName = "clavebeneficiario";
                colvarClavebeneficiario.DataType = DbType.AnsiString;
                colvarClavebeneficiario.MaxLength = 50;
                colvarClavebeneficiario.AutoIncrement = false;
                colvarClavebeneficiario.IsNullable = true;
                colvarClavebeneficiario.IsPrimaryKey = false;
                colvarClavebeneficiario.IsForeignKey = false;
                colvarClavebeneficiario.IsReadOnly = false;
                
                schema.Columns.Add(colvarClavebeneficiario);
                
                TableSchema.TableColumn colvarAfiapellido = new TableSchema.TableColumn(schema);
                colvarAfiapellido.ColumnName = "afiapellido";
                colvarAfiapellido.DataType = DbType.AnsiString;
                colvarAfiapellido.MaxLength = -1;
                colvarAfiapellido.AutoIncrement = false;
                colvarAfiapellido.IsNullable = true;
                colvarAfiapellido.IsPrimaryKey = false;
                colvarAfiapellido.IsForeignKey = false;
                colvarAfiapellido.IsReadOnly = false;
                
                schema.Columns.Add(colvarAfiapellido);
                
                TableSchema.TableColumn colvarAfinombre = new TableSchema.TableColumn(schema);
                colvarAfinombre.ColumnName = "afinombre";
                colvarAfinombre.DataType = DbType.AnsiString;
                colvarAfinombre.MaxLength = -1;
                colvarAfinombre.AutoIncrement = false;
                colvarAfinombre.IsNullable = true;
                colvarAfinombre.IsPrimaryKey = false;
                colvarAfinombre.IsForeignKey = false;
                colvarAfinombre.IsReadOnly = false;
                
                schema.Columns.Add(colvarAfinombre);
                
                TableSchema.TableColumn colvarIdComprobante = new TableSchema.TableColumn(schema);
                colvarIdComprobante.ColumnName = "id_comprobante";
                colvarIdComprobante.DataType = DbType.Int32;
                colvarIdComprobante.MaxLength = 0;
                colvarIdComprobante.AutoIncrement = false;
                colvarIdComprobante.IsNullable = false;
                colvarIdComprobante.IsPrimaryKey = false;
                colvarIdComprobante.IsForeignKey = false;
                colvarIdComprobante.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdComprobante);
                
                TableSchema.TableColumn colvarFechaComprobante = new TableSchema.TableColumn(schema);
                colvarFechaComprobante.ColumnName = "fecha_comprobante";
                colvarFechaComprobante.DataType = DbType.DateTime;
                colvarFechaComprobante.MaxLength = 0;
                colvarFechaComprobante.AutoIncrement = false;
                colvarFechaComprobante.IsNullable = true;
                colvarFechaComprobante.IsPrimaryKey = false;
                colvarFechaComprobante.IsForeignKey = false;
                colvarFechaComprobante.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaComprobante);
                
                TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
                colvarFechaCarga.ColumnName = "fecha_carga";
                colvarFechaCarga.DataType = DbType.DateTime;
                colvarFechaCarga.MaxLength = 0;
                colvarFechaCarga.AutoIncrement = false;
                colvarFechaCarga.IsNullable = true;
                colvarFechaCarga.IsPrimaryKey = false;
                colvarFechaCarga.IsForeignKey = false;
                colvarFechaCarga.IsReadOnly = false;
                
                schema.Columns.Add(colvarFechaCarga);
                
                TableSchema.TableColumn colvarPeriodo = new TableSchema.TableColumn(schema);
                colvarPeriodo.ColumnName = "periodo";
                colvarPeriodo.DataType = DbType.AnsiString;
                colvarPeriodo.MaxLength = -1;
                colvarPeriodo.AutoIncrement = false;
                colvarPeriodo.IsNullable = true;
                colvarPeriodo.IsPrimaryKey = false;
                colvarPeriodo.IsForeignKey = false;
                colvarPeriodo.IsReadOnly = false;
                
                schema.Columns.Add(colvarPeriodo);
                
                TableSchema.TableColumn colvarAfidni = new TableSchema.TableColumn(schema);
                colvarAfidni.ColumnName = "afidni";
                colvarAfidni.DataType = DbType.AnsiString;
                colvarAfidni.MaxLength = -1;
                colvarAfidni.AutoIncrement = false;
                colvarAfidni.IsNullable = true;
                colvarAfidni.IsPrimaryKey = false;
                colvarAfidni.IsForeignKey = false;
                colvarAfidni.IsReadOnly = false;
                
                schema.Columns.Add(colvarAfidni);
                
                TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
                colvarTipo.ColumnName = "tipo";
                colvarTipo.DataType = DbType.Int32;
                colvarTipo.MaxLength = 0;
                colvarTipo.AutoIncrement = false;
                colvarTipo.IsNullable = false;
                colvarTipo.IsPrimaryKey = false;
                colvarTipo.IsForeignKey = false;
                colvarTipo.IsReadOnly = false;
                
                schema.Columns.Add(colvarTipo);
                
                TableSchema.TableColumn colvarIdFactura = new TableSchema.TableColumn(schema);
                colvarIdFactura.ColumnName = "id_factura";
                colvarIdFactura.DataType = DbType.Int32;
                colvarIdFactura.MaxLength = 0;
                colvarIdFactura.AutoIncrement = false;
                colvarIdFactura.IsNullable = true;
                colvarIdFactura.IsPrimaryKey = false;
                colvarIdFactura.IsForeignKey = false;
                colvarIdFactura.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdFactura);
                
                TableSchema.TableColumn colvarMarca = new TableSchema.TableColumn(schema);
                colvarMarca.ColumnName = "marca";
                colvarMarca.DataType = DbType.Int32;
                colvarMarca.MaxLength = 0;
                colvarMarca.AutoIncrement = false;
                colvarMarca.IsNullable = true;
                colvarMarca.IsPrimaryKey = false;
                colvarMarca.IsForeignKey = false;
                colvarMarca.IsReadOnly = false;
                
                schema.Columns.Add(colvarMarca);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("PN_ListaOrdenes",schema);
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
	    public PnListaOrdene()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public PnListaOrdene(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public PnListaOrdene(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public PnListaOrdene(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Cuie")]
        [Bindable(true)]
        public string Cuie 
	    {
		    get
		    {
			    return GetColumnValue<string>("cuie");
		    }
            set 
		    {
			    SetColumnValue("cuie", value);
            }
        }
	      
        [XmlAttribute("Clavebeneficiario")]
        [Bindable(true)]
        public string Clavebeneficiario 
	    {
		    get
		    {
			    return GetColumnValue<string>("clavebeneficiario");
		    }
            set 
		    {
			    SetColumnValue("clavebeneficiario", value);
            }
        }
	      
        [XmlAttribute("Afiapellido")]
        [Bindable(true)]
        public string Afiapellido 
	    {
		    get
		    {
			    return GetColumnValue<string>("afiapellido");
		    }
            set 
		    {
			    SetColumnValue("afiapellido", value);
            }
        }
	      
        [XmlAttribute("Afinombre")]
        [Bindable(true)]
        public string Afinombre 
	    {
		    get
		    {
			    return GetColumnValue<string>("afinombre");
		    }
            set 
		    {
			    SetColumnValue("afinombre", value);
            }
        }
	      
        [XmlAttribute("IdComprobante")]
        [Bindable(true)]
        public int IdComprobante 
	    {
		    get
		    {
			    return GetColumnValue<int>("id_comprobante");
		    }
            set 
		    {
			    SetColumnValue("id_comprobante", value);
            }
        }
	      
        [XmlAttribute("FechaComprobante")]
        [Bindable(true)]
        public DateTime? FechaComprobante 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("fecha_comprobante");
		    }
            set 
		    {
			    SetColumnValue("fecha_comprobante", value);
            }
        }
	      
        [XmlAttribute("FechaCarga")]
        [Bindable(true)]
        public DateTime? FechaCarga 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("fecha_carga");
		    }
            set 
		    {
			    SetColumnValue("fecha_carga", value);
            }
        }
	      
        [XmlAttribute("Periodo")]
        [Bindable(true)]
        public string Periodo 
	    {
		    get
		    {
			    return GetColumnValue<string>("periodo");
		    }
            set 
		    {
			    SetColumnValue("periodo", value);
            }
        }
	      
        [XmlAttribute("Afidni")]
        [Bindable(true)]
        public string Afidni 
	    {
		    get
		    {
			    return GetColumnValue<string>("afidni");
		    }
            set 
		    {
			    SetColumnValue("afidni", value);
            }
        }
	      
        [XmlAttribute("Tipo")]
        [Bindable(true)]
        public int Tipo 
	    {
		    get
		    {
			    return GetColumnValue<int>("tipo");
		    }
            set 
		    {
			    SetColumnValue("tipo", value);
            }
        }
	      
        [XmlAttribute("IdFactura")]
        [Bindable(true)]
        public int? IdFactura 
	    {
		    get
		    {
			    return GetColumnValue<int?>("id_factura");
		    }
            set 
		    {
			    SetColumnValue("id_factura", value);
            }
        }
	      
        [XmlAttribute("Marca")]
        [Bindable(true)]
        public int? Marca 
	    {
		    get
		    {
			    return GetColumnValue<int?>("marca");
		    }
            set 
		    {
			    SetColumnValue("marca", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Cuie = @"cuie";
            
            public static string Clavebeneficiario = @"clavebeneficiario";
            
            public static string Afiapellido = @"afiapellido";
            
            public static string Afinombre = @"afinombre";
            
            public static string IdComprobante = @"id_comprobante";
            
            public static string FechaComprobante = @"fecha_comprobante";
            
            public static string FechaCarga = @"fecha_carga";
            
            public static string Periodo = @"periodo";
            
            public static string Afidni = @"afidni";
            
            public static string Tipo = @"tipo";
            
            public static string IdFactura = @"id_factura";
            
            public static string Marca = @"marca";
            
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
