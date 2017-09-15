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
	/// Strongly-typed collection for the RisEstudioPoblacionVulnerable class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioPoblacionVulnerableCollection : ActiveList<RisEstudioPoblacionVulnerable, RisEstudioPoblacionVulnerableCollection>
	{	   
		public RisEstudioPoblacionVulnerableCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioPoblacionVulnerableCollection</returns>
		public RisEstudioPoblacionVulnerableCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioPoblacionVulnerable o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioPoblacionVulnerable table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioPoblacionVulnerable : ActiveRecord<RisEstudioPoblacionVulnerable>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioPoblacionVulnerable()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioPoblacionVulnerable(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioPoblacionVulnerable(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioPoblacionVulnerable(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioPoblacionVulnerable", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioPoblacionVulnerable = new TableSchema.TableColumn(schema);
				colvarIdEstudioPoblacionVulnerable.ColumnName = "idEstudioPoblacionVulnerable";
				colvarIdEstudioPoblacionVulnerable.DataType = DbType.Int32;
				colvarIdEstudioPoblacionVulnerable.MaxLength = 0;
				colvarIdEstudioPoblacionVulnerable.AutoIncrement = true;
				colvarIdEstudioPoblacionVulnerable.IsNullable = false;
				colvarIdEstudioPoblacionVulnerable.IsPrimaryKey = true;
				colvarIdEstudioPoblacionVulnerable.IsForeignKey = false;
				colvarIdEstudioPoblacionVulnerable.IsReadOnly = false;
				colvarIdEstudioPoblacionVulnerable.DefaultSetting = @"";
				colvarIdEstudioPoblacionVulnerable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioPoblacionVulnerable);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarIdPoblacionVulnerable = new TableSchema.TableColumn(schema);
				colvarIdPoblacionVulnerable.ColumnName = "idPoblacionVulnerable";
				colvarIdPoblacionVulnerable.DataType = DbType.Int32;
				colvarIdPoblacionVulnerable.MaxLength = 0;
				colvarIdPoblacionVulnerable.AutoIncrement = false;
				colvarIdPoblacionVulnerable.IsNullable = false;
				colvarIdPoblacionVulnerable.IsPrimaryKey = false;
				colvarIdPoblacionVulnerable.IsForeignKey = false;
				colvarIdPoblacionVulnerable.IsReadOnly = false;
				colvarIdPoblacionVulnerable.DefaultSetting = @"";
				colvarIdPoblacionVulnerable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPoblacionVulnerable);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioPoblacionVulnerable",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioPoblacionVulnerable")]
		[Bindable(true)]
		public int IdEstudioPoblacionVulnerable 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioPoblacionVulnerable); }
			set { SetColumnValue(Columns.IdEstudioPoblacionVulnerable, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdPoblacionVulnerable")]
		[Bindable(true)]
		public int IdPoblacionVulnerable 
		{
			get { return GetColumnValue<int>(Columns.IdPoblacionVulnerable); }
			set { SetColumnValue(Columns.IdPoblacionVulnerable, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdPoblacionVulnerable)
		{
			RisEstudioPoblacionVulnerable item = new RisEstudioPoblacionVulnerable();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdPoblacionVulnerable = varIdPoblacionVulnerable;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioPoblacionVulnerable,int varIdEstudio,int varIdPoblacionVulnerable)
		{
			RisEstudioPoblacionVulnerable item = new RisEstudioPoblacionVulnerable();
			
				item.IdEstudioPoblacionVulnerable = varIdEstudioPoblacionVulnerable;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdPoblacionVulnerable = varIdPoblacionVulnerable;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioPoblacionVulnerableColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPoblacionVulnerableColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioPoblacionVulnerable = @"idEstudioPoblacionVulnerable";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdPoblacionVulnerable = @"idPoblacionVulnerable";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
