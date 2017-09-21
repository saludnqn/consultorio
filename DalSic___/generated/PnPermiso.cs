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
	/// Strongly-typed collection for the PnPermiso class.
	/// </summary>
    [Serializable]
	public partial class PnPermisoCollection : ActiveList<PnPermiso, PnPermisoCollection>
	{	   
		public PnPermisoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPermisoCollection</returns>
		public PnPermisoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPermiso o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_permisos table.
	/// </summary>
	[Serializable]
	public partial class PnPermiso : ActiveRecord<PnPermiso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPermiso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPermiso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPermiso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPermiso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_permisos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPermiso = new TableSchema.TableColumn(schema);
				colvarIdPermiso.ColumnName = "id_permiso";
				colvarIdPermiso.DataType = DbType.Int32;
				colvarIdPermiso.MaxLength = 0;
				colvarIdPermiso.AutoIncrement = true;
				colvarIdPermiso.IsNullable = false;
				colvarIdPermiso.IsPrimaryKey = true;
				colvarIdPermiso.IsForeignKey = false;
				colvarIdPermiso.IsReadOnly = false;
				colvarIdPermiso.DefaultSetting = @"";
				colvarIdPermiso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPermiso);
				
				TableSchema.TableColumn colvarIdTipo = new TableSchema.TableColumn(schema);
				colvarIdTipo.ColumnName = "id_tipo";
				colvarIdTipo.DataType = DbType.Int32;
				colvarIdTipo.MaxLength = 0;
				colvarIdTipo.AutoIncrement = false;
				colvarIdTipo.IsNullable = false;
				colvarIdTipo.IsPrimaryKey = false;
				colvarIdTipo.IsForeignKey = true;
				colvarIdTipo.IsReadOnly = false;
				colvarIdTipo.DefaultSetting = @"";
				
					colvarIdTipo.ForeignKeyTableName = "PN_tipo_permiso";
				schema.Columns.Add(colvarIdTipo);
				
				TableSchema.TableColumn colvarUname = new TableSchema.TableColumn(schema);
				colvarUname.ColumnName = "uname";
				colvarUname.DataType = DbType.AnsiString;
				colvarUname.MaxLength = -1;
				colvarUname.AutoIncrement = false;
				colvarUname.IsNullable = true;
				colvarUname.IsPrimaryKey = false;
				colvarUname.IsForeignKey = false;
				colvarUname.IsReadOnly = false;
				colvarUname.DefaultSetting = @"";
				colvarUname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUname);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarDir = new TableSchema.TableColumn(schema);
				colvarDir.ColumnName = "dir";
				colvarDir.DataType = DbType.AnsiString;
				colvarDir.MaxLength = -1;
				colvarDir.AutoIncrement = false;
				colvarDir.IsNullable = true;
				colvarDir.IsPrimaryKey = false;
				colvarDir.IsForeignKey = false;
				colvarDir.IsReadOnly = false;
				colvarDir.DefaultSetting = @"";
				colvarDir.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDir);
				
				TableSchema.TableColumn colvarCreateUser = new TableSchema.TableColumn(schema);
				colvarCreateUser.ColumnName = "create_user";
				colvarCreateUser.DataType = DbType.AnsiString;
				colvarCreateUser.MaxLength = -1;
				colvarCreateUser.AutoIncrement = false;
				colvarCreateUser.IsNullable = true;
				colvarCreateUser.IsPrimaryKey = false;
				colvarCreateUser.IsForeignKey = false;
				colvarCreateUser.IsReadOnly = false;
				colvarCreateUser.DefaultSetting = @"";
				colvarCreateUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreateUser);
				
				TableSchema.TableColumn colvarModifUser = new TableSchema.TableColumn(schema);
				colvarModifUser.ColumnName = "modif_user";
				colvarModifUser.DataType = DbType.AnsiString;
				colvarModifUser.MaxLength = -1;
				colvarModifUser.AutoIncrement = false;
				colvarModifUser.IsNullable = true;
				colvarModifUser.IsPrimaryKey = false;
				colvarModifUser.IsForeignKey = false;
				colvarModifUser.IsReadOnly = false;
				colvarModifUser.DefaultSetting = @"";
				colvarModifUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifUser);
				
				TableSchema.TableColumn colvarCreateDate = new TableSchema.TableColumn(schema);
				colvarCreateDate.ColumnName = "create_date";
				colvarCreateDate.DataType = DbType.DateTime;
				colvarCreateDate.MaxLength = 0;
				colvarCreateDate.AutoIncrement = false;
				colvarCreateDate.IsNullable = true;
				colvarCreateDate.IsPrimaryKey = false;
				colvarCreateDate.IsForeignKey = false;
				colvarCreateDate.IsReadOnly = false;
				colvarCreateDate.DefaultSetting = @"";
				colvarCreateDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreateDate);
				
				TableSchema.TableColumn colvarModifDate = new TableSchema.TableColumn(schema);
				colvarModifDate.ColumnName = "modif_date";
				colvarModifDate.DataType = DbType.DateTime;
				colvarModifDate.MaxLength = 0;
				colvarModifDate.AutoIncrement = false;
				colvarModifDate.IsNullable = true;
				colvarModifDate.IsPrimaryKey = false;
				colvarModifDate.IsForeignKey = false;
				colvarModifDate.IsReadOnly = false;
				colvarModifDate.DefaultSetting = @"";
				colvarModifDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_permisos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPermiso")]
		[Bindable(true)]
		public int IdPermiso 
		{
			get { return GetColumnValue<int>(Columns.IdPermiso); }
			set { SetColumnValue(Columns.IdPermiso, value); }
		}
		  
		[XmlAttribute("IdTipo")]
		[Bindable(true)]
		public int IdTipo 
		{
			get { return GetColumnValue<int>(Columns.IdTipo); }
			set { SetColumnValue(Columns.IdTipo, value); }
		}
		  
		[XmlAttribute("Uname")]
		[Bindable(true)]
		public string Uname 
		{
			get { return GetColumnValue<string>(Columns.Uname); }
			set { SetColumnValue(Columns.Uname, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Dir")]
		[Bindable(true)]
		public string Dir 
		{
			get { return GetColumnValue<string>(Columns.Dir); }
			set { SetColumnValue(Columns.Dir, value); }
		}
		  
		[XmlAttribute("CreateUser")]
		[Bindable(true)]
		public string CreateUser 
		{
			get { return GetColumnValue<string>(Columns.CreateUser); }
			set { SetColumnValue(Columns.CreateUser, value); }
		}
		  
		[XmlAttribute("ModifUser")]
		[Bindable(true)]
		public string ModifUser 
		{
			get { return GetColumnValue<string>(Columns.ModifUser); }
			set { SetColumnValue(Columns.ModifUser, value); }
		}
		  
		[XmlAttribute("CreateDate")]
		[Bindable(true)]
		public DateTime? CreateDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreateDate); }
			set { SetColumnValue(Columns.CreateDate, value); }
		}
		  
		[XmlAttribute("ModifDate")]
		[Bindable(true)]
		public DateTime? ModifDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifDate); }
			set { SetColumnValue(Columns.ModifDate, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnPermisosGrupoCollection colPnPermisosGrupos;
		public DalSic.PnPermisosGrupoCollection PnPermisosGrupos
		{
			get
			{
				if(colPnPermisosGrupos == null)
				{
					colPnPermisosGrupos = new DalSic.PnPermisosGrupoCollection().Where(PnPermisosGrupo.Columns.IdPermiso, IdPermiso).Load();
					colPnPermisosGrupos.ListChanged += new ListChangedEventHandler(colPnPermisosGrupos_ListChanged);
				}
				return colPnPermisosGrupos;			
			}
			set 
			{ 
					colPnPermisosGrupos = value; 
					colPnPermisosGrupos.ListChanged += new ListChangedEventHandler(colPnPermisosGrupos_ListChanged);
			}
		}
		
		void colPnPermisosGrupos_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisosGrupos[e.NewIndex].IdPermiso = IdPermiso;
		    }
		}
				
		private DalSic.PnPermisosUsuarioCollection colPnPermisosUsuarios;
		public DalSic.PnPermisosUsuarioCollection PnPermisosUsuarios
		{
			get
			{
				if(colPnPermisosUsuarios == null)
				{
					colPnPermisosUsuarios = new DalSic.PnPermisosUsuarioCollection().Where(PnPermisosUsuario.Columns.IdPermiso, IdPermiso).Load();
					colPnPermisosUsuarios.ListChanged += new ListChangedEventHandler(colPnPermisosUsuarios_ListChanged);
				}
				return colPnPermisosUsuarios;			
			}
			set 
			{ 
					colPnPermisosUsuarios = value; 
					colPnPermisosUsuarios.ListChanged += new ListChangedEventHandler(colPnPermisosUsuarios_ListChanged);
			}
		}
		
		void colPnPermisosUsuarios_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisosUsuarios[e.NewIndex].IdPermiso = IdPermiso;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnTipoPermiso ActiveRecord object related to this PnPermiso
		/// 
		/// </summary>
		public DalSic.PnTipoPermiso PnTipoPermiso
		{
			get { return DalSic.PnTipoPermiso.FetchByID(this.IdTipo); }
			set { SetColumnValue("id_tipo", value.IdTipo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdTipo,string varUname,string varDescripcion,string varDir,string varCreateUser,string varModifUser,DateTime? varCreateDate,DateTime? varModifDate)
		{
			PnPermiso item = new PnPermiso();
			
			item.IdTipo = varIdTipo;
			
			item.Uname = varUname;
			
			item.Descripcion = varDescripcion;
			
			item.Dir = varDir;
			
			item.CreateUser = varCreateUser;
			
			item.ModifUser = varModifUser;
			
			item.CreateDate = varCreateDate;
			
			item.ModifDate = varModifDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPermiso,int varIdTipo,string varUname,string varDescripcion,string varDir,string varCreateUser,string varModifUser,DateTime? varCreateDate,DateTime? varModifDate)
		{
			PnPermiso item = new PnPermiso();
			
				item.IdPermiso = varIdPermiso;
			
				item.IdTipo = varIdTipo;
			
				item.Uname = varUname;
			
				item.Descripcion = varDescripcion;
			
				item.Dir = varDir;
			
				item.CreateUser = varCreateUser;
			
				item.ModifUser = varModifUser;
			
				item.CreateDate = varCreateDate;
			
				item.ModifDate = varModifDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPermisoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UnameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DirColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateUserColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifUserColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifDateColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPermiso = @"id_permiso";
			 public static string IdTipo = @"id_tipo";
			 public static string Uname = @"uname";
			 public static string Descripcion = @"descripcion";
			 public static string Dir = @"dir";
			 public static string CreateUser = @"create_user";
			 public static string ModifUser = @"modif_user";
			 public static string CreateDate = @"create_date";
			 public static string ModifDate = @"modif_date";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnPermisosGrupos != null)
                {
                    foreach (DalSic.PnPermisosGrupo item in colPnPermisosGrupos)
                    {
                        if (item.IdPermiso != IdPermiso)
                        {
                            item.IdPermiso = IdPermiso;
                        }
                    }
               }
		
                if (colPnPermisosUsuarios != null)
                {
                    foreach (DalSic.PnPermisosUsuario item in colPnPermisosUsuarios)
                    {
                        if (item.IdPermiso != IdPermiso)
                        {
                            item.IdPermiso = IdPermiso;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnPermisosGrupos != null)
                {
                    colPnPermisosGrupos.SaveAll();
               }
		
                if (colPnPermisosUsuarios != null)
                {
                    colPnPermisosUsuarios.SaveAll();
               }
		}
        #endregion
	}
}
