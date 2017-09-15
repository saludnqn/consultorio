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
	/// Strongly-typed collection for the RisEstudioCaracteristica class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioCaracteristicaCollection : ActiveList<RisEstudioCaracteristica, RisEstudioCaracteristicaCollection>
	{	   
		public RisEstudioCaracteristicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioCaracteristicaCollection</returns>
		public RisEstudioCaracteristicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioCaracteristica o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioCaracteristica table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioCaracteristica : ActiveRecord<RisEstudioCaracteristica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioCaracteristica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioCaracteristica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioCaracteristica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioCaracteristica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioCaracteristica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioCaracteristica = new TableSchema.TableColumn(schema);
				colvarIdEstudioCaracteristica.ColumnName = "idEstudioCaracteristica";
				colvarIdEstudioCaracteristica.DataType = DbType.Int32;
				colvarIdEstudioCaracteristica.MaxLength = 0;
				colvarIdEstudioCaracteristica.AutoIncrement = true;
				colvarIdEstudioCaracteristica.IsNullable = false;
				colvarIdEstudioCaracteristica.IsPrimaryKey = true;
				colvarIdEstudioCaracteristica.IsForeignKey = false;
				colvarIdEstudioCaracteristica.IsReadOnly = false;
				colvarIdEstudioCaracteristica.DefaultSetting = @"";
				colvarIdEstudioCaracteristica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioCaracteristica);
				
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
				
				TableSchema.TableColumn colvarIdCaracteristica = new TableSchema.TableColumn(schema);
				colvarIdCaracteristica.ColumnName = "idCaracteristica";
				colvarIdCaracteristica.DataType = DbType.Int32;
				colvarIdCaracteristica.MaxLength = 0;
				colvarIdCaracteristica.AutoIncrement = false;
				colvarIdCaracteristica.IsNullable = false;
				colvarIdCaracteristica.IsPrimaryKey = false;
				colvarIdCaracteristica.IsForeignKey = false;
				colvarIdCaracteristica.IsReadOnly = false;
				colvarIdCaracteristica.DefaultSetting = @"";
				colvarIdCaracteristica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCaracteristica);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioCaracteristica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioCaracteristica")]
		[Bindable(true)]
		public int IdEstudioCaracteristica 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioCaracteristica); }
			set { SetColumnValue(Columns.IdEstudioCaracteristica, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdCaracteristica")]
		[Bindable(true)]
		public int IdCaracteristica 
		{
			get { return GetColumnValue<int>(Columns.IdCaracteristica); }
			set { SetColumnValue(Columns.IdCaracteristica, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdCaracteristica)
		{
			RisEstudioCaracteristica item = new RisEstudioCaracteristica();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdCaracteristica = varIdCaracteristica;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioCaracteristica,int varIdEstudio,int varIdCaracteristica)
		{
			RisEstudioCaracteristica item = new RisEstudioCaracteristica();
			
				item.IdEstudioCaracteristica = varIdEstudioCaracteristica;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdCaracteristica = varIdCaracteristica;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioCaracteristicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCaracteristicaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioCaracteristica = @"idEstudioCaracteristica";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdCaracteristica = @"idCaracteristica";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
