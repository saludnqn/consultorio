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
namespace DalSic
{
	/// <summary>
	/// Strongly-typed collection for the PnParto class.
	/// </summary>
    [Serializable]
	public partial class PnPartoCollection : ActiveList<PnParto, PnPartoCollection>
	{	   
		public PnPartoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPartoCollection</returns>
		public PnPartoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnParto o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the PN_partos table.
	/// </summary>
	[Serializable]
	public partial class PnParto : ActiveRecord<PnParto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnParto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnParto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnParto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnParto(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("PN_partos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPar = new TableSchema.TableColumn(schema);
				colvarIdPar.ColumnName = "id_par";
				colvarIdPar.DataType = DbType.Int32;
				colvarIdPar.MaxLength = 0;
				colvarIdPar.AutoIncrement = true;
				colvarIdPar.IsNullable = false;
				colvarIdPar.IsPrimaryKey = true;
				colvarIdPar.IsForeignKey = false;
				colvarIdPar.IsReadOnly = false;
				colvarIdPar.DefaultSetting = @"";
				colvarIdPar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPar);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = -1;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarClave = new TableSchema.TableColumn(schema);
				colvarClave.ColumnName = "clave";
				colvarClave.DataType = DbType.AnsiString;
				colvarClave.MaxLength = -1;
				colvarClave.AutoIncrement = false;
				colvarClave.IsNullable = true;
				colvarClave.IsPrimaryKey = false;
				colvarClave.IsForeignKey = false;
				colvarClave.IsReadOnly = false;
				colvarClave.DefaultSetting = @"";
				colvarClave.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClave);
				
				TableSchema.TableColumn colvarTipoDoc = new TableSchema.TableColumn(schema);
				colvarTipoDoc.ColumnName = "tipo_doc";
				colvarTipoDoc.DataType = DbType.AnsiString;
				colvarTipoDoc.MaxLength = -1;
				colvarTipoDoc.AutoIncrement = false;
				colvarTipoDoc.IsNullable = true;
				colvarTipoDoc.IsPrimaryKey = false;
				colvarTipoDoc.IsForeignKey = false;
				colvarTipoDoc.IsReadOnly = false;
				colvarTipoDoc.DefaultSetting = @"";
				colvarTipoDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDoc);
				
				TableSchema.TableColumn colvarNumDoc = new TableSchema.TableColumn(schema);
				colvarNumDoc.ColumnName = "num_doc";
				colvarNumDoc.DataType = DbType.Decimal;
				colvarNumDoc.MaxLength = 0;
				colvarNumDoc.AutoIncrement = false;
				colvarNumDoc.IsNullable = true;
				colvarNumDoc.IsPrimaryKey = false;
				colvarNumDoc.IsForeignKey = false;
				colvarNumDoc.IsReadOnly = false;
				colvarNumDoc.DefaultSetting = @"";
				colvarNumDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumDoc);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = -1;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarFechaParto = new TableSchema.TableColumn(schema);
				colvarFechaParto.ColumnName = "fecha_parto";
				colvarFechaParto.DataType = DbType.DateTime;
				colvarFechaParto.MaxLength = 0;
				colvarFechaParto.AutoIncrement = false;
				colvarFechaParto.IsNullable = true;
				colvarFechaParto.IsPrimaryKey = false;
				colvarFechaParto.IsForeignKey = false;
				colvarFechaParto.IsReadOnly = false;
				colvarFechaParto.DefaultSetting = @"";
				colvarFechaParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaParto);
				
				TableSchema.TableColumn colvarApgar = new TableSchema.TableColumn(schema);
				colvarApgar.ColumnName = "apgar";
				colvarApgar.DataType = DbType.Decimal;
				colvarApgar.MaxLength = 0;
				colvarApgar.AutoIncrement = false;
				colvarApgar.IsNullable = true;
				colvarApgar.IsPrimaryKey = false;
				colvarApgar.IsForeignKey = false;
				colvarApgar.IsReadOnly = false;
				colvarApgar.DefaultSetting = @"";
				colvarApgar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApgar);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarVdrl = new TableSchema.TableColumn(schema);
				colvarVdrl.ColumnName = "vdrl";
				colvarVdrl.DataType = DbType.AnsiString;
				colvarVdrl.MaxLength = -1;
				colvarVdrl.AutoIncrement = false;
				colvarVdrl.IsNullable = true;
				colvarVdrl.IsPrimaryKey = false;
				colvarVdrl.IsForeignKey = false;
				colvarVdrl.IsReadOnly = false;
				colvarVdrl.DefaultSetting = @"";
				colvarVdrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVdrl);
				
				TableSchema.TableColumn colvarAntitetanica = new TableSchema.TableColumn(schema);
				colvarAntitetanica.ColumnName = "antitetanica";
				colvarAntitetanica.DataType = DbType.AnsiString;
				colvarAntitetanica.MaxLength = -1;
				colvarAntitetanica.AutoIncrement = false;
				colvarAntitetanica.IsNullable = true;
				colvarAntitetanica.IsPrimaryKey = false;
				colvarAntitetanica.IsForeignKey = false;
				colvarAntitetanica.IsReadOnly = false;
				colvarAntitetanica.DefaultSetting = @"";
				colvarAntitetanica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntitetanica);
				
				TableSchema.TableColumn colvarFechaConserjeria = new TableSchema.TableColumn(schema);
				colvarFechaConserjeria.ColumnName = "fecha_conserjeria";
				colvarFechaConserjeria.DataType = DbType.DateTime;
				colvarFechaConserjeria.MaxLength = 0;
				colvarFechaConserjeria.AutoIncrement = false;
				colvarFechaConserjeria.IsNullable = true;
				colvarFechaConserjeria.IsPrimaryKey = false;
				colvarFechaConserjeria.IsForeignKey = false;
				colvarFechaConserjeria.IsReadOnly = false;
				colvarFechaConserjeria.DefaultSetting = @"";
				colvarFechaConserjeria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaConserjeria);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "fecha_carga";
				colvarFechaCarga.DataType = DbType.DateTime;
				colvarFechaCarga.MaxLength = 0;
				colvarFechaCarga.AutoIncrement = false;
				colvarFechaCarga.IsNullable = true;
				colvarFechaCarga.IsPrimaryKey = false;
				colvarFechaCarga.IsForeignKey = false;
				colvarFechaCarga.IsReadOnly = false;
				colvarFechaCarga.DefaultSetting = @"";
				colvarFechaCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCarga);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = -1;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_partos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPar")]
		[Bindable(true)]
		public int IdPar 
		{
			get { return GetColumnValue<int>(Columns.IdPar); }
			set { SetColumnValue(Columns.IdPar, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Clave")]
		[Bindable(true)]
		public string Clave 
		{
			get { return GetColumnValue<string>(Columns.Clave); }
			set { SetColumnValue(Columns.Clave, value); }
		}
		  
		[XmlAttribute("TipoDoc")]
		[Bindable(true)]
		public string TipoDoc 
		{
			get { return GetColumnValue<string>(Columns.TipoDoc); }
			set { SetColumnValue(Columns.TipoDoc, value); }
		}
		  
		[XmlAttribute("NumDoc")]
		[Bindable(true)]
		public decimal? NumDoc 
		{
			get { return GetColumnValue<decimal?>(Columns.NumDoc); }
			set { SetColumnValue(Columns.NumDoc, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("FechaParto")]
		[Bindable(true)]
		public DateTime? FechaParto 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaParto); }
			set { SetColumnValue(Columns.FechaParto, value); }
		}
		  
		[XmlAttribute("Apgar")]
		[Bindable(true)]
		public decimal? Apgar 
		{
			get { return GetColumnValue<decimal?>(Columns.Apgar); }
			set { SetColumnValue(Columns.Apgar, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal? Peso 
		{
			get { return GetColumnValue<decimal?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Vdrl")]
		[Bindable(true)]
		public string Vdrl 
		{
			get { return GetColumnValue<string>(Columns.Vdrl); }
			set { SetColumnValue(Columns.Vdrl, value); }
		}
		  
		[XmlAttribute("Antitetanica")]
		[Bindable(true)]
		public string Antitetanica 
		{
			get { return GetColumnValue<string>(Columns.Antitetanica); }
			set { SetColumnValue(Columns.Antitetanica, value); }
		}
		  
		[XmlAttribute("FechaConserjeria")]
		[Bindable(true)]
		public DateTime? FechaConserjeria 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaConserjeria); }
			set { SetColumnValue(Columns.FechaConserjeria, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varClave,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaParto,decimal? varApgar,decimal? varPeso,string varVdrl,string varAntitetanica,DateTime? varFechaConserjeria,string varObservaciones,DateTime? varFechaCarga,string varUsuario)
		{
			PnParto item = new PnParto();
			
			item.Cuie = varCuie;
			
			item.Clave = varClave;
			
			item.TipoDoc = varTipoDoc;
			
			item.NumDoc = varNumDoc;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.FechaParto = varFechaParto;
			
			item.Apgar = varApgar;
			
			item.Peso = varPeso;
			
			item.Vdrl = varVdrl;
			
			item.Antitetanica = varAntitetanica;
			
			item.FechaConserjeria = varFechaConserjeria;
			
			item.Observaciones = varObservaciones;
			
			item.FechaCarga = varFechaCarga;
			
			item.Usuario = varUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPar,string varCuie,string varClave,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaParto,decimal? varApgar,decimal? varPeso,string varVdrl,string varAntitetanica,DateTime? varFechaConserjeria,string varObservaciones,DateTime? varFechaCarga,string varUsuario)
		{
			PnParto item = new PnParto();
			
				item.IdPar = varIdPar;
			
				item.Cuie = varCuie;
			
				item.Clave = varClave;
			
				item.TipoDoc = varTipoDoc;
			
				item.NumDoc = varNumDoc;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.FechaParto = varFechaParto;
			
				item.Apgar = varApgar;
			
				item.Peso = varPeso;
			
				item.Vdrl = varVdrl;
			
				item.Antitetanica = varAntitetanica;
			
				item.FechaConserjeria = varFechaConserjeria;
			
				item.Observaciones = varObservaciones;
			
				item.FechaCarga = varFechaCarga;
			
				item.Usuario = varUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdParColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaveColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumDocColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPartoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ApgarColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn VdrlColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AntitetanicaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaConserjeriaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPar = @"id_par";
			 public static string Cuie = @"cuie";
			 public static string Clave = @"clave";
			 public static string TipoDoc = @"tipo_doc";
			 public static string NumDoc = @"num_doc";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string FechaParto = @"fecha_parto";
			 public static string Apgar = @"apgar";
			 public static string Peso = @"peso";
			 public static string Vdrl = @"vdrl";
			 public static string Antitetanica = @"antitetanica";
			 public static string FechaConserjeria = @"fecha_conserjeria";
			 public static string Observaciones = @"observaciones";
			 public static string FechaCarga = @"fecha_carga";
			 public static string Usuario = @"usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
