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
	/// Strongly-typed collection for the SysTipoObraSocial class.
	/// </summary>
    [Serializable]
	public partial class SysTipoObraSocialCollection : ActiveList<SysTipoObraSocial, SysTipoObraSocialCollection>
	{	   
		public SysTipoObraSocialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysTipoObraSocialCollection</returns>
		public SysTipoObraSocialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysTipoObraSocial o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_TipoObraSocial table.
	/// </summary>
	[Serializable]
	public partial class SysTipoObraSocial : ActiveRecord<SysTipoObraSocial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysTipoObraSocial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysTipoObraSocial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysTipoObraSocial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysTipoObraSocial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_TipoObraSocial", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoObraSocial = new TableSchema.TableColumn(schema);
				colvarIdTipoObraSocial.ColumnName = "idTipoObraSocial";
				colvarIdTipoObraSocial.DataType = DbType.Int32;
				colvarIdTipoObraSocial.MaxLength = 0;
				colvarIdTipoObraSocial.AutoIncrement = true;
				colvarIdTipoObraSocial.IsNullable = false;
				colvarIdTipoObraSocial.IsPrimaryKey = true;
				colvarIdTipoObraSocial.IsForeignKey = false;
				colvarIdTipoObraSocial.IsReadOnly = false;
				colvarIdTipoObraSocial.DefaultSetting = @"";
				colvarIdTipoObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoObraSocial);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_TipoObraSocial",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoObraSocial")]
		[Bindable(true)]
		public int IdTipoObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdTipoObraSocial); }
			set { SetColumnValue(Columns.IdTipoObraSocial, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysObraSocialCollection colSysObraSocialRecords;
		public DalSic.SysObraSocialCollection SysObraSocialRecords
		{
			get
			{
				if(colSysObraSocialRecords == null)
				{
					colSysObraSocialRecords = new DalSic.SysObraSocialCollection().Where(SysObraSocial.Columns.IdTipoObraSocial, IdTipoObraSocial).Load();
					colSysObraSocialRecords.ListChanged += new ListChangedEventHandler(colSysObraSocialRecords_ListChanged);
				}
				return colSysObraSocialRecords;			
			}
			set 
			{ 
					colSysObraSocialRecords = value; 
					colSysObraSocialRecords.ListChanged += new ListChangedEventHandler(colSysObraSocialRecords_ListChanged);
			}
		}
		
		void colSysObraSocialRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysObraSocialRecords[e.NewIndex].IdTipoObraSocial = IdTipoObraSocial;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			SysTipoObraSocial item = new SysTipoObraSocial();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoObraSocial,string varNombre)
		{
			SysTipoObraSocial item = new SysTipoObraSocial();
			
				item.IdTipoObraSocial = varIdTipoObraSocial;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoObraSocialColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoObraSocial = @"idTipoObraSocial";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysObraSocialRecords != null)
                {
                    foreach (DalSic.SysObraSocial item in colSysObraSocialRecords)
                    {
                        if (item.IdTipoObraSocial != IdTipoObraSocial)
                        {
                            item.IdTipoObraSocial = IdTipoObraSocial;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysObraSocialRecords != null)
                {
                    colSysObraSocialRecords.SaveAll();
               }
		}
        #endregion
	}
}
