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
	/// Strongly-typed collection for the PnTipoPermiso class.
	/// </summary>
    [Serializable]
	public partial class PnTipoPermisoCollection : ActiveList<PnTipoPermiso, PnTipoPermisoCollection>
	{	   
		public PnTipoPermisoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTipoPermisoCollection</returns>
		public PnTipoPermisoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTipoPermiso o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_tipo_permiso table.
	/// </summary>
	[Serializable]
	public partial class PnTipoPermiso : ActiveRecord<PnTipoPermiso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTipoPermiso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTipoPermiso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTipoPermiso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTipoPermiso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_tipo_permiso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipo = new TableSchema.TableColumn(schema);
				colvarIdTipo.ColumnName = "id_tipo";
				colvarIdTipo.DataType = DbType.Int32;
				colvarIdTipo.MaxLength = 0;
				colvarIdTipo.AutoIncrement = true;
				colvarIdTipo.IsNullable = false;
				colvarIdTipo.IsPrimaryKey = true;
				colvarIdTipo.IsForeignKey = false;
				colvarIdTipo.IsReadOnly = false;
				colvarIdTipo.DefaultSetting = @"";
				colvarIdTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipo);
				
				TableSchema.TableColumn colvarTipoNombre = new TableSchema.TableColumn(schema);
				colvarTipoNombre.ColumnName = "tipo_nombre";
				colvarTipoNombre.DataType = DbType.AnsiString;
				colvarTipoNombre.MaxLength = -1;
				colvarTipoNombre.AutoIncrement = false;
				colvarTipoNombre.IsNullable = true;
				colvarTipoNombre.IsPrimaryKey = false;
				colvarTipoNombre.IsForeignKey = false;
				colvarTipoNombre.IsReadOnly = false;
				colvarTipoNombre.DefaultSetting = @"";
				colvarTipoNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoNombre);
				
				TableSchema.TableColumn colvarImg1Src = new TableSchema.TableColumn(schema);
				colvarImg1Src.ColumnName = "img1_src";
				colvarImg1Src.DataType = DbType.AnsiString;
				colvarImg1Src.MaxLength = -1;
				colvarImg1Src.AutoIncrement = false;
				colvarImg1Src.IsNullable = true;
				colvarImg1Src.IsPrimaryKey = false;
				colvarImg1Src.IsForeignKey = false;
				colvarImg1Src.IsReadOnly = false;
				colvarImg1Src.DefaultSetting = @"";
				colvarImg1Src.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImg1Src);
				
				TableSchema.TableColumn colvarImg2Src = new TableSchema.TableColumn(schema);
				colvarImg2Src.ColumnName = "img2_src";
				colvarImg2Src.DataType = DbType.AnsiString;
				colvarImg2Src.MaxLength = -1;
				colvarImg2Src.AutoIncrement = false;
				colvarImg2Src.IsNullable = true;
				colvarImg2Src.IsPrimaryKey = false;
				colvarImg2Src.IsForeignKey = false;
				colvarImg2Src.IsReadOnly = false;
				colvarImg2Src.DefaultSetting = @"";
				colvarImg2Src.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImg2Src);
				
				TableSchema.TableColumn colvarImg3Src = new TableSchema.TableColumn(schema);
				colvarImg3Src.ColumnName = "img3_src";
				colvarImg3Src.DataType = DbType.AnsiString;
				colvarImg3Src.MaxLength = -1;
				colvarImg3Src.AutoIncrement = false;
				colvarImg3Src.IsNullable = true;
				colvarImg3Src.IsPrimaryKey = false;
				colvarImg3Src.IsForeignKey = false;
				colvarImg3Src.IsReadOnly = false;
				colvarImg3Src.DefaultSetting = @"";
				colvarImg3Src.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImg3Src);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_tipo_permiso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipo")]
		[Bindable(true)]
		public int IdTipo 
		{
			get { return GetColumnValue<int>(Columns.IdTipo); }
			set { SetColumnValue(Columns.IdTipo, value); }
		}
		  
		[XmlAttribute("TipoNombre")]
		[Bindable(true)]
		public string TipoNombre 
		{
			get { return GetColumnValue<string>(Columns.TipoNombre); }
			set { SetColumnValue(Columns.TipoNombre, value); }
		}
		  
		[XmlAttribute("Img1Src")]
		[Bindable(true)]
		public string Img1Src 
		{
			get { return GetColumnValue<string>(Columns.Img1Src); }
			set { SetColumnValue(Columns.Img1Src, value); }
		}
		  
		[XmlAttribute("Img2Src")]
		[Bindable(true)]
		public string Img2Src 
		{
			get { return GetColumnValue<string>(Columns.Img2Src); }
			set { SetColumnValue(Columns.Img2Src, value); }
		}
		  
		[XmlAttribute("Img3Src")]
		[Bindable(true)]
		public string Img3Src 
		{
			get { return GetColumnValue<string>(Columns.Img3Src); }
			set { SetColumnValue(Columns.Img3Src, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnPermisoCollection colPnPermisos;
		public DalSic.PnPermisoCollection PnPermisos
		{
			get
			{
				if(colPnPermisos == null)
				{
					colPnPermisos = new DalSic.PnPermisoCollection().Where(PnPermiso.Columns.IdTipo, IdTipo).Load();
					colPnPermisos.ListChanged += new ListChangedEventHandler(colPnPermisos_ListChanged);
				}
				return colPnPermisos;			
			}
			set 
			{ 
					colPnPermisos = value; 
					colPnPermisos.ListChanged += new ListChangedEventHandler(colPnPermisos_ListChanged);
			}
		}
		
		void colPnPermisos_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisos[e.NewIndex].IdTipo = IdTipo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTipoNombre,string varImg1Src,string varImg2Src,string varImg3Src)
		{
			PnTipoPermiso item = new PnTipoPermiso();
			
			item.TipoNombre = varTipoNombre;
			
			item.Img1Src = varImg1Src;
			
			item.Img2Src = varImg2Src;
			
			item.Img3Src = varImg3Src;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipo,string varTipoNombre,string varImg1Src,string varImg2Src,string varImg3Src)
		{
			PnTipoPermiso item = new PnTipoPermiso();
			
				item.IdTipo = varIdTipo;
			
				item.TipoNombre = varTipoNombre;
			
				item.Img1Src = varImg1Src;
			
				item.Img2Src = varImg2Src;
			
				item.Img3Src = varImg3Src;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoNombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn Img1SrcColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn Img2SrcColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn Img3SrcColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipo = @"id_tipo";
			 public static string TipoNombre = @"tipo_nombre";
			 public static string Img1Src = @"img1_src";
			 public static string Img2Src = @"img2_src";
			 public static string Img3Src = @"img3_src";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnPermisos != null)
                {
                    foreach (DalSic.PnPermiso item in colPnPermisos)
                    {
                        if (item.IdTipo != IdTipo)
                        {
                            item.IdTipo = IdTipo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnPermisos != null)
                {
                    colPnPermisos.SaveAll();
               }
		}
        #endregion
	}
}
