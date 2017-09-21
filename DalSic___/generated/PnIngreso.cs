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
	/// Strongly-typed collection for the PnIngreso class.
	/// </summary>
    [Serializable]
	public partial class PnIngresoCollection : ActiveList<PnIngreso, PnIngresoCollection>
	{	   
		public PnIngresoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnIngresoCollection</returns>
		public PnIngresoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnIngreso o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_ingreso table.
	/// </summary>
	[Serializable]
	public partial class PnIngreso : ActiveRecord<PnIngreso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnIngreso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnIngreso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnIngreso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnIngreso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_ingreso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdIngreso = new TableSchema.TableColumn(schema);
				colvarIdIngreso.ColumnName = "id_ingreso";
				colvarIdIngreso.DataType = DbType.Int32;
				colvarIdIngreso.MaxLength = 0;
				colvarIdIngreso.AutoIncrement = true;
				colvarIdIngreso.IsNullable = false;
				colvarIdIngreso.IsPrimaryKey = true;
				colvarIdIngreso.IsForeignKey = false;
				colvarIdIngreso.IsReadOnly = false;
				colvarIdIngreso.DefaultSetting = @"";
				colvarIdIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIngreso);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = true;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarMontoPrefactura = new TableSchema.TableColumn(schema);
				colvarMontoPrefactura.ColumnName = "monto_prefactura";
				colvarMontoPrefactura.DataType = DbType.Decimal;
				colvarMontoPrefactura.MaxLength = 0;
				colvarMontoPrefactura.AutoIncrement = false;
				colvarMontoPrefactura.IsNullable = true;
				colvarMontoPrefactura.IsPrimaryKey = false;
				colvarMontoPrefactura.IsForeignKey = false;
				colvarMontoPrefactura.IsReadOnly = false;
				colvarMontoPrefactura.DefaultSetting = @"";
				colvarMontoPrefactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoPrefactura);
				
				TableSchema.TableColumn colvarFechaPrefactura = new TableSchema.TableColumn(schema);
				colvarFechaPrefactura.ColumnName = "fecha_prefactura";
				colvarFechaPrefactura.DataType = DbType.DateTime;
				colvarFechaPrefactura.MaxLength = 0;
				colvarFechaPrefactura.AutoIncrement = false;
				colvarFechaPrefactura.IsNullable = true;
				colvarFechaPrefactura.IsPrimaryKey = false;
				colvarFechaPrefactura.IsForeignKey = false;
				colvarFechaPrefactura.IsReadOnly = false;
				colvarFechaPrefactura.DefaultSetting = @"";
				colvarFechaPrefactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPrefactura);
				
				TableSchema.TableColumn colvarMontoFactura = new TableSchema.TableColumn(schema);
				colvarMontoFactura.ColumnName = "monto_factura";
				colvarMontoFactura.DataType = DbType.Decimal;
				colvarMontoFactura.MaxLength = 0;
				colvarMontoFactura.AutoIncrement = false;
				colvarMontoFactura.IsNullable = true;
				colvarMontoFactura.IsPrimaryKey = false;
				colvarMontoFactura.IsForeignKey = false;
				colvarMontoFactura.IsReadOnly = false;
				colvarMontoFactura.DefaultSetting = @"";
				colvarMontoFactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoFactura);
				
				TableSchema.TableColumn colvarFechaFactura = new TableSchema.TableColumn(schema);
				colvarFechaFactura.ColumnName = "fecha_factura";
				colvarFechaFactura.DataType = DbType.DateTime;
				colvarFechaFactura.MaxLength = 0;
				colvarFechaFactura.AutoIncrement = false;
				colvarFechaFactura.IsNullable = true;
				colvarFechaFactura.IsPrimaryKey = false;
				colvarFechaFactura.IsForeignKey = false;
				colvarFechaFactura.IsReadOnly = false;
				colvarFechaFactura.DefaultSetting = @"";
				colvarFechaFactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFactura);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = -1;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarNumeroFactura = new TableSchema.TableColumn(schema);
				colvarNumeroFactura.ColumnName = "numero_factura";
				colvarNumeroFactura.DataType = DbType.Int32;
				colvarNumeroFactura.MaxLength = 0;
				colvarNumeroFactura.AutoIncrement = false;
				colvarNumeroFactura.IsNullable = true;
				colvarNumeroFactura.IsPrimaryKey = false;
				colvarNumeroFactura.IsForeignKey = false;
				colvarNumeroFactura.IsReadOnly = false;
				colvarNumeroFactura.DefaultSetting = @"";
				colvarNumeroFactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroFactura);
				
				TableSchema.TableColumn colvarFechaDeposito = new TableSchema.TableColumn(schema);
				colvarFechaDeposito.ColumnName = "fecha_deposito";
				colvarFechaDeposito.DataType = DbType.DateTime;
				colvarFechaDeposito.MaxLength = 0;
				colvarFechaDeposito.AutoIncrement = false;
				colvarFechaDeposito.IsNullable = true;
				colvarFechaDeposito.IsPrimaryKey = false;
				colvarFechaDeposito.IsForeignKey = false;
				colvarFechaDeposito.IsReadOnly = false;
				colvarFechaDeposito.DefaultSetting = @"";
				colvarFechaDeposito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDeposito);
				
				TableSchema.TableColumn colvarMontoDeposito = new TableSchema.TableColumn(schema);
				colvarMontoDeposito.ColumnName = "monto_deposito";
				colvarMontoDeposito.DataType = DbType.Decimal;
				colvarMontoDeposito.MaxLength = 0;
				colvarMontoDeposito.AutoIncrement = false;
				colvarMontoDeposito.IsNullable = true;
				colvarMontoDeposito.IsPrimaryKey = false;
				colvarMontoDeposito.IsForeignKey = false;
				colvarMontoDeposito.IsReadOnly = false;
				colvarMontoDeposito.DefaultSetting = @"";
				colvarMontoDeposito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoDeposito);
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "id_servicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = false;
				colvarIdServicio.IsNullable = true;
				colvarIdServicio.IsPrimaryKey = false;
				colvarIdServicio.IsForeignKey = false;
				colvarIdServicio.IsReadOnly = false;
				colvarIdServicio.DefaultSetting = @"";
				colvarIdServicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdServicio);
				
				TableSchema.TableColumn colvarFechaNotificacion = new TableSchema.TableColumn(schema);
				colvarFechaNotificacion.ColumnName = "fecha_notificacion";
				colvarFechaNotificacion.DataType = DbType.DateTime;
				colvarFechaNotificacion.MaxLength = 0;
				colvarFechaNotificacion.AutoIncrement = false;
				colvarFechaNotificacion.IsNullable = true;
				colvarFechaNotificacion.IsPrimaryKey = false;
				colvarFechaNotificacion.IsForeignKey = false;
				colvarFechaNotificacion.IsReadOnly = false;
				colvarFechaNotificacion.DefaultSetting = @"";
				colvarFechaNotificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNotificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_ingreso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdIngreso")]
		[Bindable(true)]
		public int IdIngreso 
		{
			get { return GetColumnValue<int>(Columns.IdIngreso); }
			set { SetColumnValue(Columns.IdIngreso, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("MontoPrefactura")]
		[Bindable(true)]
		public decimal? MontoPrefactura 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoPrefactura); }
			set { SetColumnValue(Columns.MontoPrefactura, value); }
		}
		  
		[XmlAttribute("FechaPrefactura")]
		[Bindable(true)]
		public DateTime? FechaPrefactura 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaPrefactura); }
			set { SetColumnValue(Columns.FechaPrefactura, value); }
		}
		  
		[XmlAttribute("MontoFactura")]
		[Bindable(true)]
		public decimal? MontoFactura 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoFactura); }
			set { SetColumnValue(Columns.MontoFactura, value); }
		}
		  
		[XmlAttribute("FechaFactura")]
		[Bindable(true)]
		public DateTime? FechaFactura 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaFactura); }
			set { SetColumnValue(Columns.FechaFactura, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("NumeroFactura")]
		[Bindable(true)]
		public int? NumeroFactura 
		{
			get { return GetColumnValue<int?>(Columns.NumeroFactura); }
			set { SetColumnValue(Columns.NumeroFactura, value); }
		}
		  
		[XmlAttribute("FechaDeposito")]
		[Bindable(true)]
		public DateTime? FechaDeposito 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDeposito); }
			set { SetColumnValue(Columns.FechaDeposito, value); }
		}
		  
		[XmlAttribute("MontoDeposito")]
		[Bindable(true)]
		public decimal? MontoDeposito 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoDeposito); }
			set { SetColumnValue(Columns.MontoDeposito, value); }
		}
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int? IdServicio 
		{
			get { return GetColumnValue<int?>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("FechaNotificacion")]
		[Bindable(true)]
		public DateTime? FechaNotificacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNotificacion); }
			set { SetColumnValue(Columns.FechaNotificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,decimal? varMontoPrefactura,DateTime? varFechaPrefactura,decimal? varMontoFactura,DateTime? varFechaFactura,string varComentario,string varUsuario,DateTime? varFecha,int? varNumeroFactura,DateTime? varFechaDeposito,decimal? varMontoDeposito,int? varIdServicio,DateTime? varFechaNotificacion)
		{
			PnIngreso item = new PnIngreso();
			
			item.Cuie = varCuie;
			
			item.MontoPrefactura = varMontoPrefactura;
			
			item.FechaPrefactura = varFechaPrefactura;
			
			item.MontoFactura = varMontoFactura;
			
			item.FechaFactura = varFechaFactura;
			
			item.Comentario = varComentario;
			
			item.Usuario = varUsuario;
			
			item.Fecha = varFecha;
			
			item.NumeroFactura = varNumeroFactura;
			
			item.FechaDeposito = varFechaDeposito;
			
			item.MontoDeposito = varMontoDeposito;
			
			item.IdServicio = varIdServicio;
			
			item.FechaNotificacion = varFechaNotificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdIngreso,string varCuie,decimal? varMontoPrefactura,DateTime? varFechaPrefactura,decimal? varMontoFactura,DateTime? varFechaFactura,string varComentario,string varUsuario,DateTime? varFecha,int? varNumeroFactura,DateTime? varFechaDeposito,decimal? varMontoDeposito,int? varIdServicio,DateTime? varFechaNotificacion)
		{
			PnIngreso item = new PnIngreso();
			
				item.IdIngreso = varIdIngreso;
			
				item.Cuie = varCuie;
			
				item.MontoPrefactura = varMontoPrefactura;
			
				item.FechaPrefactura = varFechaPrefactura;
			
				item.MontoFactura = varMontoFactura;
			
				item.FechaFactura = varFechaFactura;
			
				item.Comentario = varComentario;
			
				item.Usuario = varUsuario;
			
				item.Fecha = varFecha;
			
				item.NumeroFactura = varNumeroFactura;
			
				item.FechaDeposito = varFechaDeposito;
			
				item.MontoDeposito = varMontoDeposito;
			
				item.IdServicio = varIdServicio;
			
				item.FechaNotificacion = varFechaNotificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdIngresoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoPrefacturaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPrefacturaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoFacturaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFacturaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroFacturaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDepositoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoDepositoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNotificacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdIngreso = @"id_ingreso";
			 public static string Cuie = @"cuie";
			 public static string MontoPrefactura = @"monto_prefactura";
			 public static string FechaPrefactura = @"fecha_prefactura";
			 public static string MontoFactura = @"monto_factura";
			 public static string FechaFactura = @"fecha_factura";
			 public static string Comentario = @"comentario";
			 public static string Usuario = @"usuario";
			 public static string Fecha = @"fecha";
			 public static string NumeroFactura = @"numero_factura";
			 public static string FechaDeposito = @"fecha_deposito";
			 public static string MontoDeposito = @"monto_deposito";
			 public static string IdServicio = @"id_servicio";
			 public static string FechaNotificacion = @"fecha_notificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
