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
	/// Strongly-typed collection for the SysModulo class.
	/// </summary>
    [Serializable]
	public partial class SysModuloCollection : ActiveList<SysModulo, SysModuloCollection>
	{	   
		public SysModuloCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysModuloCollection</returns>
		public SysModuloCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysModulo o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Modulo table.
	/// </summary>
	[Serializable]
	public partial class SysModulo : ActiveRecord<SysModulo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysModulo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysModulo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysModulo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysModulo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Modulo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdModulo = new TableSchema.TableColumn(schema);
				colvarIdModulo.ColumnName = "idModulo";
				colvarIdModulo.DataType = DbType.Int32;
				colvarIdModulo.MaxLength = 0;
				colvarIdModulo.AutoIncrement = true;
				colvarIdModulo.IsNullable = false;
				colvarIdModulo.IsPrimaryKey = true;
				colvarIdModulo.IsForeignKey = false;
				colvarIdModulo.IsReadOnly = false;
				colvarIdModulo.DefaultSetting = @"";
				colvarIdModulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdModulo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "url";
				colvarUrl.DataType = DbType.AnsiString;
				colvarUrl.MaxLength = 500;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = true;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				TableSchema.TableColumn colvarIcono = new TableSchema.TableColumn(schema);
				colvarIcono.ColumnName = "icono";
				colvarIcono.DataType = DbType.AnsiString;
				colvarIcono.MaxLength = 500;
				colvarIcono.AutoIncrement = false;
				colvarIcono.IsNullable = true;
				colvarIcono.IsPrimaryKey = false;
				colvarIcono.IsForeignKey = false;
				colvarIcono.IsReadOnly = false;
				colvarIcono.DefaultSetting = @"";
				colvarIcono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIcono);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarOrden = new TableSchema.TableColumn(schema);
				colvarOrden.ColumnName = "orden";
				colvarOrden.DataType = DbType.Int32;
				colvarOrden.MaxLength = 0;
				colvarOrden.AutoIncrement = false;
				colvarOrden.IsNullable = false;
				colvarOrden.IsPrimaryKey = false;
				colvarOrden.IsForeignKey = false;
				colvarOrden.IsReadOnly = false;
				
						colvarOrden.DefaultSetting = @"((0))";
				colvarOrden.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrden);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Modulo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdModulo")]
		[Bindable(true)]
		public int IdModulo 
		{
			get { return GetColumnValue<int>(Columns.IdModulo); }
			set { SetColumnValue(Columns.IdModulo, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("Icono")]
		[Bindable(true)]
		public string Icono 
		{
			get { return GetColumnValue<string>(Columns.Icono); }
			set { SetColumnValue(Columns.Icono, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Orden")]
		[Bindable(true)]
		public int Orden 
		{
			get { return GetColumnValue<int>(Columns.Orden); }
			set { SetColumnValue(Columns.Orden, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysMenuCollection colSysMenuRecords;
		public DalSic.SysMenuCollection SysMenuRecords
		{
			get
			{
				if(colSysMenuRecords == null)
				{
					colSysMenuRecords = new DalSic.SysMenuCollection().Where(SysMenu.Columns.IdModulo, IdModulo).Load();
					colSysMenuRecords.ListChanged += new ListChangedEventHandler(colSysMenuRecords_ListChanged);
				}
				return colSysMenuRecords;			
			}
			set 
			{ 
					colSysMenuRecords = value; 
					colSysMenuRecords.ListChanged += new ListChangedEventHandler(colSysMenuRecords_ListChanged);
			}
		}
		
		void colSysMenuRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysMenuRecords[e.NewIndex].IdModulo = IdModulo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varUrl,string varIcono,string varDescripcion,int varOrden)
		{
			SysModulo item = new SysModulo();
			
			item.Nombre = varNombre;
			
			item.Url = varUrl;
			
			item.Icono = varIcono;
			
			item.Descripcion = varDescripcion;
			
			item.Orden = varOrden;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdModulo,string varNombre,string varUrl,string varIcono,string varDescripcion,int varOrden)
		{
			SysModulo item = new SysModulo();
			
				item.IdModulo = varIdModulo;
			
				item.Nombre = varNombre;
			
				item.Url = varUrl;
			
				item.Icono = varIcono;
			
				item.Descripcion = varDescripcion;
			
				item.Orden = varOrden;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdModuloColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IconoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdenColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdModulo = @"idModulo";
			 public static string Nombre = @"nombre";
			 public static string Url = @"url";
			 public static string Icono = @"icono";
			 public static string Descripcion = @"descripcion";
			 public static string Orden = @"orden";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysMenuRecords != null)
                {
                    foreach (DalSic.SysMenu item in colSysMenuRecords)
                    {
                        if (item.IdModulo != IdModulo)
                        {
                            item.IdModulo = IdModulo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysMenuRecords != null)
                {
                    colSysMenuRecords.SaveAll();
               }
		}
        #endregion
	}
}
