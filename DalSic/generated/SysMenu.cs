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
	/// Strongly-typed collection for the SysMenu class.
	/// </summary>
    [Serializable]
	public partial class SysMenuCollection : ActiveList<SysMenu, SysMenuCollection>
	{	   
		public SysMenuCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysMenuCollection</returns>
		public SysMenuCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysMenu o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Menu table.
	/// </summary>
	[Serializable]
	public partial class SysMenu : ActiveRecord<SysMenu>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysMenu()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysMenu(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysMenu(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysMenu(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Menu", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMenu = new TableSchema.TableColumn(schema);
				colvarIdMenu.ColumnName = "idMenu";
				colvarIdMenu.DataType = DbType.Int32;
				colvarIdMenu.MaxLength = 0;
				colvarIdMenu.AutoIncrement = true;
				colvarIdMenu.IsNullable = false;
				colvarIdMenu.IsPrimaryKey = true;
				colvarIdMenu.IsForeignKey = false;
				colvarIdMenu.IsReadOnly = false;
				colvarIdMenu.DefaultSetting = @"";
				colvarIdMenu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMenu);
				
				TableSchema.TableColumn colvarObjeto = new TableSchema.TableColumn(schema);
				colvarObjeto.ColumnName = "objeto";
				colvarObjeto.DataType = DbType.String;
				colvarObjeto.MaxLength = 50;
				colvarObjeto.AutoIncrement = false;
				colvarObjeto.IsNullable = false;
				colvarObjeto.IsPrimaryKey = false;
				colvarObjeto.IsForeignKey = false;
				colvarObjeto.IsReadOnly = false;
				colvarObjeto.DefaultSetting = @"";
				colvarObjeto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObjeto);
				
				TableSchema.TableColumn colvarIdMenuSuperior = new TableSchema.TableColumn(schema);
				colvarIdMenuSuperior.ColumnName = "idMenuSuperior";
				colvarIdMenuSuperior.DataType = DbType.Int32;
				colvarIdMenuSuperior.MaxLength = 0;
				colvarIdMenuSuperior.AutoIncrement = false;
				colvarIdMenuSuperior.IsNullable = false;
				colvarIdMenuSuperior.IsPrimaryKey = false;
				colvarIdMenuSuperior.IsForeignKey = false;
				colvarIdMenuSuperior.IsReadOnly = false;
				
						colvarIdMenuSuperior.DefaultSetting = @"((0))";
				colvarIdMenuSuperior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMenuSuperior);
				
				TableSchema.TableColumn colvarPosicion = new TableSchema.TableColumn(schema);
				colvarPosicion.ColumnName = "posicion";
				colvarPosicion.DataType = DbType.Int32;
				colvarPosicion.MaxLength = 0;
				colvarPosicion.AutoIncrement = false;
				colvarPosicion.IsNullable = false;
				colvarPosicion.IsPrimaryKey = false;
				colvarPosicion.IsForeignKey = false;
				colvarPosicion.IsReadOnly = false;
				colvarPosicion.DefaultSetting = @"";
				colvarPosicion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPosicion);
				
				TableSchema.TableColumn colvarIcono = new TableSchema.TableColumn(schema);
				colvarIcono.ColumnName = "icono";
				colvarIcono.DataType = DbType.AnsiString;
				colvarIcono.MaxLength = 50;
				colvarIcono.AutoIncrement = false;
				colvarIcono.IsNullable = false;
				colvarIcono.IsPrimaryKey = false;
				colvarIcono.IsForeignKey = false;
				colvarIcono.IsReadOnly = false;
				
						colvarIcono.DefaultSetting = @"('')";
				colvarIcono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIcono);
				
				TableSchema.TableColumn colvarHabilitado = new TableSchema.TableColumn(schema);
				colvarHabilitado.ColumnName = "habilitado";
				colvarHabilitado.DataType = DbType.Boolean;
				colvarHabilitado.MaxLength = 0;
				colvarHabilitado.AutoIncrement = false;
				colvarHabilitado.IsNullable = false;
				colvarHabilitado.IsPrimaryKey = false;
				colvarHabilitado.IsForeignKey = false;
				colvarHabilitado.IsReadOnly = false;
				colvarHabilitado.DefaultSetting = @"";
				colvarHabilitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHabilitado);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "url";
				colvarUrl.DataType = DbType.AnsiString;
				colvarUrl.MaxLength = 200;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = false;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				
						colvarUrl.DefaultSetting = @"('')";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				TableSchema.TableColumn colvarFechaCreacion = new TableSchema.TableColumn(schema);
				colvarFechaCreacion.ColumnName = "fechaCreacion";
				colvarFechaCreacion.DataType = DbType.DateTime;
				colvarFechaCreacion.MaxLength = 0;
				colvarFechaCreacion.AutoIncrement = false;
				colvarFechaCreacion.IsNullable = false;
				colvarFechaCreacion.IsPrimaryKey = false;
				colvarFechaCreacion.IsForeignKey = false;
				colvarFechaCreacion.IsReadOnly = false;
				
						colvarFechaCreacion.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaCreacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCreacion);
				
				TableSchema.TableColumn colvarIdUsuarioCreacion = new TableSchema.TableColumn(schema);
				colvarIdUsuarioCreacion.ColumnName = "idUsuarioCreacion";
				colvarIdUsuarioCreacion.DataType = DbType.Int32;
				colvarIdUsuarioCreacion.MaxLength = 0;
				colvarIdUsuarioCreacion.AutoIncrement = false;
				colvarIdUsuarioCreacion.IsNullable = false;
				colvarIdUsuarioCreacion.IsPrimaryKey = false;
				colvarIdUsuarioCreacion.IsForeignKey = false;
				colvarIdUsuarioCreacion.IsReadOnly = false;
				
						colvarIdUsuarioCreacion.DefaultSetting = @"((0))";
				colvarIdUsuarioCreacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioCreacion);
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "fechaModificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = false;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				
						colvarFechaModificacion.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				TableSchema.TableColumn colvarIdUsuarioModificacion = new TableSchema.TableColumn(schema);
				colvarIdUsuarioModificacion.ColumnName = "idUsuarioModificacion";
				colvarIdUsuarioModificacion.DataType = DbType.Int32;
				colvarIdUsuarioModificacion.MaxLength = 0;
				colvarIdUsuarioModificacion.AutoIncrement = false;
				colvarIdUsuarioModificacion.IsNullable = false;
				colvarIdUsuarioModificacion.IsPrimaryKey = false;
				colvarIdUsuarioModificacion.IsForeignKey = false;
				colvarIdUsuarioModificacion.IsReadOnly = false;
				
						colvarIdUsuarioModificacion.DefaultSetting = @"((0))";
				colvarIdUsuarioModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioModificacion);
				
				TableSchema.TableColumn colvarIdModulo = new TableSchema.TableColumn(schema);
				colvarIdModulo.ColumnName = "idModulo";
				colvarIdModulo.DataType = DbType.Int32;
				colvarIdModulo.MaxLength = 0;
				colvarIdModulo.AutoIncrement = false;
				colvarIdModulo.IsNullable = false;
				colvarIdModulo.IsPrimaryKey = false;
				colvarIdModulo.IsForeignKey = true;
				colvarIdModulo.IsReadOnly = false;
				
						colvarIdModulo.DefaultSetting = @"((0))";
				
					colvarIdModulo.ForeignKeyTableName = "Sys_Modulo";
				schema.Columns.Add(colvarIdModulo);
				
				TableSchema.TableColumn colvarEsAccion = new TableSchema.TableColumn(schema);
				colvarEsAccion.ColumnName = "esAccion";
				colvarEsAccion.DataType = DbType.Boolean;
				colvarEsAccion.MaxLength = 0;
				colvarEsAccion.AutoIncrement = false;
				colvarEsAccion.IsNullable = true;
				colvarEsAccion.IsPrimaryKey = false;
				colvarEsAccion.IsForeignKey = false;
				colvarEsAccion.IsReadOnly = false;
				
						colvarEsAccion.DefaultSetting = @"((0))";
				colvarEsAccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEsAccion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Menu",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMenu")]
		[Bindable(true)]
		public int IdMenu 
		{
			get { return GetColumnValue<int>(Columns.IdMenu); }
			set { SetColumnValue(Columns.IdMenu, value); }
		}
		  
		[XmlAttribute("Objeto")]
		[Bindable(true)]
		public string Objeto 
		{
			get { return GetColumnValue<string>(Columns.Objeto); }
			set { SetColumnValue(Columns.Objeto, value); }
		}
		  
		[XmlAttribute("IdMenuSuperior")]
		[Bindable(true)]
		public int IdMenuSuperior 
		{
			get { return GetColumnValue<int>(Columns.IdMenuSuperior); }
			set { SetColumnValue(Columns.IdMenuSuperior, value); }
		}
		  
		[XmlAttribute("Posicion")]
		[Bindable(true)]
		public int Posicion 
		{
			get { return GetColumnValue<int>(Columns.Posicion); }
			set { SetColumnValue(Columns.Posicion, value); }
		}
		  
		[XmlAttribute("Icono")]
		[Bindable(true)]
		public string Icono 
		{
			get { return GetColumnValue<string>(Columns.Icono); }
			set { SetColumnValue(Columns.Icono, value); }
		}
		  
		[XmlAttribute("Habilitado")]
		[Bindable(true)]
		public bool Habilitado 
		{
			get { return GetColumnValue<bool>(Columns.Habilitado); }
			set { SetColumnValue(Columns.Habilitado, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("FechaCreacion")]
		[Bindable(true)]
		public DateTime FechaCreacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaCreacion); }
			set { SetColumnValue(Columns.FechaCreacion, value); }
		}
		  
		[XmlAttribute("IdUsuarioCreacion")]
		[Bindable(true)]
		public int IdUsuarioCreacion 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioCreacion); }
			set { SetColumnValue(Columns.IdUsuarioCreacion, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("IdUsuarioModificacion")]
		[Bindable(true)]
		public int IdUsuarioModificacion 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioModificacion); }
			set { SetColumnValue(Columns.IdUsuarioModificacion, value); }
		}
		  
		[XmlAttribute("IdModulo")]
		[Bindable(true)]
		public int IdModulo 
		{
			get { return GetColumnValue<int>(Columns.IdModulo); }
			set { SetColumnValue(Columns.IdModulo, value); }
		}
		  
		[XmlAttribute("EsAccion")]
		[Bindable(true)]
		public bool? EsAccion 
		{
			get { return GetColumnValue<bool?>(Columns.EsAccion); }
			set { SetColumnValue(Columns.EsAccion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysPermisoCollection colSysPermisoRecords;
		public DalSic.SysPermisoCollection SysPermisoRecords
		{
			get
			{
				if(colSysPermisoRecords == null)
				{
					colSysPermisoRecords = new DalSic.SysPermisoCollection().Where(SysPermiso.Columns.IdMenu, IdMenu).Load();
					colSysPermisoRecords.ListChanged += new ListChangedEventHandler(colSysPermisoRecords_ListChanged);
				}
				return colSysPermisoRecords;			
			}
			set 
			{ 
					colSysPermisoRecords = value; 
					colSysPermisoRecords.ListChanged += new ListChangedEventHandler(colSysPermisoRecords_ListChanged);
			}
		}
		
		void colSysPermisoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysPermisoRecords[e.NewIndex].IdMenu = IdMenu;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysModulo ActiveRecord object related to this SysMenu
		/// 
		/// </summary>
		public DalSic.SysModulo SysModulo
		{
			get { return DalSic.SysModulo.FetchByID(this.IdModulo); }
			set { SetColumnValue("idModulo", value.IdModulo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varObjeto,int varIdMenuSuperior,int varPosicion,string varIcono,bool varHabilitado,string varUrl,DateTime varFechaCreacion,int varIdUsuarioCreacion,DateTime varFechaModificacion,int varIdUsuarioModificacion,int varIdModulo,bool? varEsAccion)
		{
			SysMenu item = new SysMenu();
			
			item.Objeto = varObjeto;
			
			item.IdMenuSuperior = varIdMenuSuperior;
			
			item.Posicion = varPosicion;
			
			item.Icono = varIcono;
			
			item.Habilitado = varHabilitado;
			
			item.Url = varUrl;
			
			item.FechaCreacion = varFechaCreacion;
			
			item.IdUsuarioCreacion = varIdUsuarioCreacion;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.IdUsuarioModificacion = varIdUsuarioModificacion;
			
			item.IdModulo = varIdModulo;
			
			item.EsAccion = varEsAccion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMenu,string varObjeto,int varIdMenuSuperior,int varPosicion,string varIcono,bool varHabilitado,string varUrl,DateTime varFechaCreacion,int varIdUsuarioCreacion,DateTime varFechaModificacion,int varIdUsuarioModificacion,int varIdModulo,bool? varEsAccion)
		{
			SysMenu item = new SysMenu();
			
				item.IdMenu = varIdMenu;
			
				item.Objeto = varObjeto;
			
				item.IdMenuSuperior = varIdMenuSuperior;
			
				item.Posicion = varPosicion;
			
				item.Icono = varIcono;
			
				item.Habilitado = varHabilitado;
			
				item.Url = varUrl;
			
				item.FechaCreacion = varFechaCreacion;
			
				item.IdUsuarioCreacion = varIdUsuarioCreacion;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.IdUsuarioModificacion = varIdUsuarioModificacion;
			
				item.IdModulo = varIdModulo;
			
				item.EsAccion = varEsAccion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMenuColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ObjetoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMenuSuperiorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PosicionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IconoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn HabilitadoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCreacionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioCreacionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioModificacionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdModuloColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn EsAccionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMenu = @"idMenu";
			 public static string Objeto = @"objeto";
			 public static string IdMenuSuperior = @"idMenuSuperior";
			 public static string Posicion = @"posicion";
			 public static string Icono = @"icono";
			 public static string Habilitado = @"habilitado";
			 public static string Url = @"url";
			 public static string FechaCreacion = @"fechaCreacion";
			 public static string IdUsuarioCreacion = @"idUsuarioCreacion";
			 public static string FechaModificacion = @"fechaModificacion";
			 public static string IdUsuarioModificacion = @"idUsuarioModificacion";
			 public static string IdModulo = @"idModulo";
			 public static string EsAccion = @"esAccion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysPermisoRecords != null)
                {
                    foreach (DalSic.SysPermiso item in colSysPermisoRecords)
                    {
                        if (item.IdMenu != IdMenu)
                        {
                            item.IdMenu = IdMenu;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysPermisoRecords != null)
                {
                    colSysPermisoRecords.SaveAll();
               }
		}
        #endregion
	}
}
