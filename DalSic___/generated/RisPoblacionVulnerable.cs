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
	/// Strongly-typed collection for the RisPoblacionVulnerable class.
	/// </summary>
    [Serializable]
	public partial class RisPoblacionVulnerableCollection : ActiveList<RisPoblacionVulnerable, RisPoblacionVulnerableCollection>
	{	   
		public RisPoblacionVulnerableCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisPoblacionVulnerableCollection</returns>
		public RisPoblacionVulnerableCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisPoblacionVulnerable o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_PoblacionVulnerable table.
	/// </summary>
	[Serializable]
	public partial class RisPoblacionVulnerable : ActiveRecord<RisPoblacionVulnerable>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisPoblacionVulnerable()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisPoblacionVulnerable(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisPoblacionVulnerable(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisPoblacionVulnerable(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_PoblacionVulnerable", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPoblacionVulnerable = new TableSchema.TableColumn(schema);
				colvarIdPoblacionVulnerable.ColumnName = "idPoblacionVulnerable";
				colvarIdPoblacionVulnerable.DataType = DbType.Int32;
				colvarIdPoblacionVulnerable.MaxLength = 0;
				colvarIdPoblacionVulnerable.AutoIncrement = true;
				colvarIdPoblacionVulnerable.IsNullable = false;
				colvarIdPoblacionVulnerable.IsPrimaryKey = true;
				colvarIdPoblacionVulnerable.IsForeignKey = false;
				colvarIdPoblacionVulnerable.IsReadOnly = false;
				colvarIdPoblacionVulnerable.DefaultSetting = @"";
				colvarIdPoblacionVulnerable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPoblacionVulnerable);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_PoblacionVulnerable",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPoblacionVulnerable")]
		[Bindable(true)]
		public int IdPoblacionVulnerable 
		{
			get { return GetColumnValue<int>(Columns.IdPoblacionVulnerable); }
			set { SetColumnValue(Columns.IdPoblacionVulnerable, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion)
		{
			RisPoblacionVulnerable item = new RisPoblacionVulnerable();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPoblacionVulnerable,string varDescripcion)
		{
			RisPoblacionVulnerable item = new RisPoblacionVulnerable();
			
				item.IdPoblacionVulnerable = varIdPoblacionVulnerable;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPoblacionVulnerableColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPoblacionVulnerable = @"idPoblacionVulnerable";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
