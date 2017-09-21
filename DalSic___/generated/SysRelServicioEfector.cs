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
	/// Strongly-typed collection for the SysRelServicioEfector class.
	/// </summary>
    [Serializable]
	public partial class SysRelServicioEfectorCollection : ActiveList<SysRelServicioEfector, SysRelServicioEfectorCollection>
	{	   
		public SysRelServicioEfectorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelServicioEfectorCollection</returns>
		public SysRelServicioEfectorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelServicioEfector o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelServicioEfector table.
	/// </summary>
	[Serializable]
	public partial class SysRelServicioEfector : ActiveRecord<SysRelServicioEfector>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelServicioEfector()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelServicioEfector(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelServicioEfector(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelServicioEfector(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelServicioEfector", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelServicioEfector = new TableSchema.TableColumn(schema);
				colvarIdRelServicioEfector.ColumnName = "idRelServicioEfector";
				colvarIdRelServicioEfector.DataType = DbType.Int32;
				colvarIdRelServicioEfector.MaxLength = 0;
				colvarIdRelServicioEfector.AutoIncrement = true;
				colvarIdRelServicioEfector.IsNullable = false;
				colvarIdRelServicioEfector.IsPrimaryKey = true;
				colvarIdRelServicioEfector.IsForeignKey = false;
				colvarIdRelServicioEfector.IsReadOnly = false;
				colvarIdRelServicioEfector.DefaultSetting = @"";
				colvarIdRelServicioEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelServicioEfector);
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "idServicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = false;
				colvarIdServicio.IsNullable = false;
				colvarIdServicio.IsPrimaryKey = false;
				colvarIdServicio.IsForeignKey = true;
				colvarIdServicio.IsReadOnly = false;
				
						colvarIdServicio.DefaultSetting = @"((0))";
				
					colvarIdServicio.ForeignKeyTableName = "Sys_Servicio";
				schema.Columns.Add(colvarIdServicio);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((0))";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelServicioEfector",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelServicioEfector")]
		[Bindable(true)]
		public int IdRelServicioEfector 
		{
			get { return GetColumnValue<int>(Columns.IdRelServicioEfector); }
			set { SetColumnValue(Columns.IdRelServicioEfector, value); }
		}
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int IdServicio 
		{
			get { return GetColumnValue<int>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysRelServicioEfector
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysServicio ActiveRecord object related to this SysRelServicioEfector
		/// 
		/// </summary>
		public DalSic.SysServicio SysServicio
		{
			get { return DalSic.SysServicio.FetchByID(this.IdServicio); }
			set { SetColumnValue("idServicio", value.IdServicio); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdServicio,int varIdEfector)
		{
			SysRelServicioEfector item = new SysRelServicioEfector();
			
			item.IdServicio = varIdServicio;
			
			item.IdEfector = varIdEfector;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelServicioEfector,int varIdServicio,int varIdEfector)
		{
			SysRelServicioEfector item = new SysRelServicioEfector();
			
				item.IdRelServicioEfector = varIdRelServicioEfector;
			
				item.IdServicio = varIdServicio;
			
				item.IdEfector = varIdEfector;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelServicioEfectorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelServicioEfector = @"idRelServicioEfector";
			 public static string IdServicio = @"idServicio";
			 public static string IdEfector = @"idEfector";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
