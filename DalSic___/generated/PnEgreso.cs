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
	/// Strongly-typed collection for the PnEgreso class.
	/// </summary>
    [Serializable]
	public partial class PnEgresoCollection : ActiveList<PnEgreso, PnEgresoCollection>
	{	   
		public PnEgresoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEgresoCollection</returns>
		public PnEgresoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEgreso o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_egreso table.
	/// </summary>
	[Serializable]
	public partial class PnEgreso : ActiveRecord<PnEgreso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEgreso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEgreso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEgreso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEgreso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_egreso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEgreso = new TableSchema.TableColumn(schema);
				colvarIdEgreso.ColumnName = "id_egreso";
				colvarIdEgreso.DataType = DbType.Int32;
				colvarIdEgreso.MaxLength = 0;
				colvarIdEgreso.AutoIncrement = true;
				colvarIdEgreso.IsNullable = false;
				colvarIdEgreso.IsPrimaryKey = true;
				colvarIdEgreso.IsForeignKey = false;
				colvarIdEgreso.IsReadOnly = false;
				colvarIdEgreso.DefaultSetting = @"";
				colvarIdEgreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEgreso);
				
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
				
				TableSchema.TableColumn colvarMontoEgreso = new TableSchema.TableColumn(schema);
				colvarMontoEgreso.ColumnName = "monto_egreso";
				colvarMontoEgreso.DataType = DbType.Decimal;
				colvarMontoEgreso.MaxLength = 0;
				colvarMontoEgreso.AutoIncrement = false;
				colvarMontoEgreso.IsNullable = true;
				colvarMontoEgreso.IsPrimaryKey = false;
				colvarMontoEgreso.IsForeignKey = false;
				colvarMontoEgreso.IsReadOnly = false;
				colvarMontoEgreso.DefaultSetting = @"";
				colvarMontoEgreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoEgreso);
				
				TableSchema.TableColumn colvarFechaEgreso = new TableSchema.TableColumn(schema);
				colvarFechaEgreso.ColumnName = "fecha_egreso";
				colvarFechaEgreso.DataType = DbType.DateTime;
				colvarFechaEgreso.MaxLength = 0;
				colvarFechaEgreso.AutoIncrement = false;
				colvarFechaEgreso.IsNullable = true;
				colvarFechaEgreso.IsPrimaryKey = false;
				colvarFechaEgreso.IsForeignKey = false;
				colvarFechaEgreso.IsReadOnly = false;
				colvarFechaEgreso.DefaultSetting = @"";
				colvarFechaEgreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEgreso);
				
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
				
				TableSchema.TableColumn colvarIdInciso = new TableSchema.TableColumn(schema);
				colvarIdInciso.ColumnName = "id_inciso";
				colvarIdInciso.DataType = DbType.Int32;
				colvarIdInciso.MaxLength = 0;
				colvarIdInciso.AutoIncrement = false;
				colvarIdInciso.IsNullable = true;
				colvarIdInciso.IsPrimaryKey = false;
				colvarIdInciso.IsForeignKey = false;
				colvarIdInciso.IsReadOnly = false;
				colvarIdInciso.DefaultSetting = @"";
				colvarIdInciso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInciso);
				
				TableSchema.TableColumn colvarMontoEgreComp = new TableSchema.TableColumn(schema);
				colvarMontoEgreComp.ColumnName = "monto_egre_comp";
				colvarMontoEgreComp.DataType = DbType.Decimal;
				colvarMontoEgreComp.MaxLength = 0;
				colvarMontoEgreComp.AutoIncrement = false;
				colvarMontoEgreComp.IsNullable = true;
				colvarMontoEgreComp.IsPrimaryKey = false;
				colvarMontoEgreComp.IsForeignKey = false;
				colvarMontoEgreComp.IsReadOnly = false;
				colvarMontoEgreComp.DefaultSetting = @"";
				colvarMontoEgreComp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoEgreComp);
				
				TableSchema.TableColumn colvarFechaEgreComp = new TableSchema.TableColumn(schema);
				colvarFechaEgreComp.ColumnName = "fecha_egre_comp";
				colvarFechaEgreComp.DataType = DbType.DateTime;
				colvarFechaEgreComp.MaxLength = 0;
				colvarFechaEgreComp.AutoIncrement = false;
				colvarFechaEgreComp.IsNullable = true;
				colvarFechaEgreComp.IsPrimaryKey = false;
				colvarFechaEgreComp.IsForeignKey = false;
				colvarFechaEgreComp.IsReadOnly = false;
				colvarFechaEgreComp.DefaultSetting = @"";
				colvarFechaEgreComp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEgreComp);
				
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
				
				TableSchema.TableColumn colvarIdItemGasto = new TableSchema.TableColumn(schema);
				colvarIdItemGasto.ColumnName = "id_item_gasto";
				colvarIdItemGasto.DataType = DbType.Int32;
				colvarIdItemGasto.MaxLength = 0;
				colvarIdItemGasto.AutoIncrement = false;
				colvarIdItemGasto.IsNullable = true;
				colvarIdItemGasto.IsPrimaryKey = false;
				colvarIdItemGasto.IsForeignKey = false;
				colvarIdItemGasto.IsReadOnly = false;
				
						colvarIdItemGasto.DefaultSetting = @"((0))";
				colvarIdItemGasto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItemGasto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_egreso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEgreso")]
		[Bindable(true)]
		public int IdEgreso 
		{
			get { return GetColumnValue<int>(Columns.IdEgreso); }
			set { SetColumnValue(Columns.IdEgreso, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("MontoEgreso")]
		[Bindable(true)]
		public decimal? MontoEgreso 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoEgreso); }
			set { SetColumnValue(Columns.MontoEgreso, value); }
		}
		  
		[XmlAttribute("FechaEgreso")]
		[Bindable(true)]
		public DateTime? FechaEgreso 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEgreso); }
			set { SetColumnValue(Columns.FechaEgreso, value); }
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
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int? IdServicio 
		{
			get { return GetColumnValue<int?>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("IdInciso")]
		[Bindable(true)]
		public int? IdInciso 
		{
			get { return GetColumnValue<int?>(Columns.IdInciso); }
			set { SetColumnValue(Columns.IdInciso, value); }
		}
		  
		[XmlAttribute("MontoEgreComp")]
		[Bindable(true)]
		public decimal? MontoEgreComp 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoEgreComp); }
			set { SetColumnValue(Columns.MontoEgreComp, value); }
		}
		  
		[XmlAttribute("FechaEgreComp")]
		[Bindable(true)]
		public DateTime? FechaEgreComp 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEgreComp); }
			set { SetColumnValue(Columns.FechaEgreComp, value); }
		}
		  
		[XmlAttribute("FechaDeposito")]
		[Bindable(true)]
		public DateTime? FechaDeposito 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDeposito); }
			set { SetColumnValue(Columns.FechaDeposito, value); }
		}
		  
		[XmlAttribute("IdItemGasto")]
		[Bindable(true)]
		public int? IdItemGasto 
		{
			get { return GetColumnValue<int?>(Columns.IdItemGasto); }
			set { SetColumnValue(Columns.IdItemGasto, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,decimal? varMontoEgreso,DateTime? varFechaEgreso,string varComentario,string varUsuario,DateTime? varFecha,int? varIdServicio,int? varIdInciso,decimal? varMontoEgreComp,DateTime? varFechaEgreComp,DateTime? varFechaDeposito,int? varIdItemGasto)
		{
			PnEgreso item = new PnEgreso();
			
			item.Cuie = varCuie;
			
			item.MontoEgreso = varMontoEgreso;
			
			item.FechaEgreso = varFechaEgreso;
			
			item.Comentario = varComentario;
			
			item.Usuario = varUsuario;
			
			item.Fecha = varFecha;
			
			item.IdServicio = varIdServicio;
			
			item.IdInciso = varIdInciso;
			
			item.MontoEgreComp = varMontoEgreComp;
			
			item.FechaEgreComp = varFechaEgreComp;
			
			item.FechaDeposito = varFechaDeposito;
			
			item.IdItemGasto = varIdItemGasto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEgreso,string varCuie,decimal? varMontoEgreso,DateTime? varFechaEgreso,string varComentario,string varUsuario,DateTime? varFecha,int? varIdServicio,int? varIdInciso,decimal? varMontoEgreComp,DateTime? varFechaEgreComp,DateTime? varFechaDeposito,int? varIdItemGasto)
		{
			PnEgreso item = new PnEgreso();
			
				item.IdEgreso = varIdEgreso;
			
				item.Cuie = varCuie;
			
				item.MontoEgreso = varMontoEgreso;
			
				item.FechaEgreso = varFechaEgreso;
			
				item.Comentario = varComentario;
			
				item.Usuario = varUsuario;
			
				item.Fecha = varFecha;
			
				item.IdServicio = varIdServicio;
			
				item.IdInciso = varIdInciso;
			
				item.MontoEgreComp = varMontoEgreComp;
			
				item.FechaEgreComp = varFechaEgreComp;
			
				item.FechaDeposito = varFechaDeposito;
			
				item.IdItemGasto = varIdItemGasto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEgresoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoEgresoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEgresoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdIncisoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoEgreCompColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEgreCompColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDepositoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemGastoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEgreso = @"id_egreso";
			 public static string Cuie = @"cuie";
			 public static string MontoEgreso = @"monto_egreso";
			 public static string FechaEgreso = @"fecha_egreso";
			 public static string Comentario = @"comentario";
			 public static string Usuario = @"usuario";
			 public static string Fecha = @"fecha";
			 public static string IdServicio = @"id_servicio";
			 public static string IdInciso = @"id_inciso";
			 public static string MontoEgreComp = @"monto_egre_comp";
			 public static string FechaEgreComp = @"fecha_egre_comp";
			 public static string FechaDeposito = @"fecha_deposito";
			 public static string IdItemGasto = @"id_item_gasto";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
