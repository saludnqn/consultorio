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
	/// Strongly-typed collection for the SysPerfil class.
	/// </summary>
    [Serializable]
	public partial class SysPerfilCollection : ActiveList<SysPerfil, SysPerfilCollection>
	{	   
		public SysPerfilCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysPerfilCollection</returns>
		public SysPerfilCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysPerfil o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Perfil table.
	/// </summary>
	[Serializable]
	public partial class SysPerfil : ActiveRecord<SysPerfil>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysPerfil()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysPerfil(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysPerfil(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysPerfil(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Perfil", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPerfil = new TableSchema.TableColumn(schema);
				colvarIdPerfil.ColumnName = "idPerfil";
				colvarIdPerfil.DataType = DbType.Int32;
				colvarIdPerfil.MaxLength = 0;
				colvarIdPerfil.AutoIncrement = true;
				colvarIdPerfil.IsNullable = false;
				colvarIdPerfil.IsPrimaryKey = true;
				colvarIdPerfil.IsForeignKey = false;
				colvarIdPerfil.IsReadOnly = false;
				colvarIdPerfil.DefaultSetting = @"";
				colvarIdPerfil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPerfil);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				
						colvarIdUsuario.DefaultSetting = @"((0))";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarFechaActualizacion = new TableSchema.TableColumn(schema);
				colvarFechaActualizacion.ColumnName = "fechaActualizacion";
				colvarFechaActualizacion.DataType = DbType.DateTime;
				colvarFechaActualizacion.MaxLength = 0;
				colvarFechaActualizacion.AutoIncrement = false;
				colvarFechaActualizacion.IsNullable = false;
				colvarFechaActualizacion.IsPrimaryKey = false;
				colvarFechaActualizacion.IsForeignKey = false;
				colvarFechaActualizacion.IsReadOnly = false;
				
						colvarFechaActualizacion.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaActualizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaActualizacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Perfil",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPerfil")]
		[Bindable(true)]
		public int IdPerfil 
		{
			get { return GetColumnValue<int>(Columns.IdPerfil); }
			set { SetColumnValue(Columns.IdPerfil, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaActualizacion")]
		[Bindable(true)]
		public DateTime FechaActualizacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaActualizacion); }
			set { SetColumnValue(Columns.FechaActualizacion, value); }
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
					colSysPermisoRecords = new DalSic.SysPermisoCollection().Where(SysPermiso.Columns.IdPerfil, IdPerfil).Load();
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
		        colSysPermisoRecords[e.NewIndex].IdPerfil = IdPerfil;
		    }
		}
				
		private DalSic.SysUsuarioCollection colSysUsuarioRecords;
		public DalSic.SysUsuarioCollection SysUsuarioRecords
		{
			get
			{
				if(colSysUsuarioRecords == null)
				{
					colSysUsuarioRecords = new DalSic.SysUsuarioCollection().Where(SysUsuario.Columns.IdPerfil, IdPerfil).Load();
					colSysUsuarioRecords.ListChanged += new ListChangedEventHandler(colSysUsuarioRecords_ListChanged);
				}
				return colSysUsuarioRecords;			
			}
			set 
			{ 
					colSysUsuarioRecords = value; 
					colSysUsuarioRecords.ListChanged += new ListChangedEventHandler(colSysUsuarioRecords_ListChanged);
			}
		}
		
		void colSysUsuarioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysUsuarioRecords[e.NewIndex].IdPerfil = IdPerfil;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,string varNombre,bool varActivo,int varIdUsuario,DateTime varFechaActualizacion)
		{
			SysPerfil item = new SysPerfil();
			
			item.IdEfector = varIdEfector;
			
			item.Nombre = varNombre;
			
			item.Activo = varActivo;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaActualizacion = varFechaActualizacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPerfil,int varIdEfector,string varNombre,bool varActivo,int varIdUsuario,DateTime varFechaActualizacion)
		{
			SysPerfil item = new SysPerfil();
			
				item.IdPerfil = varIdPerfil;
			
				item.IdEfector = varIdEfector;
			
				item.Nombre = varNombre;
			
				item.Activo = varActivo;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaActualizacion = varFechaActualizacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPerfilColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaActualizacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPerfil = @"idPerfil";
			 public static string IdEfector = @"idEfector";
			 public static string Nombre = @"nombre";
			 public static string Activo = @"activo";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaActualizacion = @"fechaActualizacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysPermisoRecords != null)
                {
                    foreach (DalSic.SysPermiso item in colSysPermisoRecords)
                    {
                        if (item.IdPerfil != IdPerfil)
                        {
                            item.IdPerfil = IdPerfil;
                        }
                    }
               }
		
                if (colSysUsuarioRecords != null)
                {
                    foreach (DalSic.SysUsuario item in colSysUsuarioRecords)
                    {
                        if (item.IdPerfil != IdPerfil)
                        {
                            item.IdPerfil = IdPerfil;
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
		
                if (colSysUsuarioRecords != null)
                {
                    colSysUsuarioRecords.SaveAll();
               }
		}
        #endregion
	}
}
