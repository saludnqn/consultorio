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
	/// Strongly-typed collection for the AprAlturaUterina class.
	/// </summary>
    [Serializable]
	public partial class AprAlturaUterinaCollection : ActiveList<AprAlturaUterina, AprAlturaUterinaCollection>
	{	   
		public AprAlturaUterinaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAlturaUterinaCollection</returns>
		public AprAlturaUterinaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAlturaUterina o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AlturaUterina table.
	/// </summary>
	[Serializable]
	public partial class AprAlturaUterina : ActiveRecord<AprAlturaUterina>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAlturaUterina()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAlturaUterina(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAlturaUterina(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAlturaUterina(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AlturaUterina", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarSemanasGestacion = new TableSchema.TableColumn(schema);
				colvarSemanasGestacion.ColumnName = "SemanasGestacion";
				colvarSemanasGestacion.DataType = DbType.Decimal;
				colvarSemanasGestacion.MaxLength = 0;
				colvarSemanasGestacion.AutoIncrement = false;
				colvarSemanasGestacion.IsNullable = false;
				colvarSemanasGestacion.IsPrimaryKey = false;
				colvarSemanasGestacion.IsForeignKey = false;
				colvarSemanasGestacion.IsReadOnly = false;
				colvarSemanasGestacion.DefaultSetting = @"";
				colvarSemanasGestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSemanasGestacion);
				
				TableSchema.TableColumn colvarC10 = new TableSchema.TableColumn(schema);
				colvarC10.ColumnName = "C10";
				colvarC10.DataType = DbType.Decimal;
				colvarC10.MaxLength = 0;
				colvarC10.AutoIncrement = false;
				colvarC10.IsNullable = false;
				colvarC10.IsPrimaryKey = false;
				colvarC10.IsForeignKey = false;
				colvarC10.IsReadOnly = false;
				colvarC10.DefaultSetting = @"";
				colvarC10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarC10);
				
				TableSchema.TableColumn colvarC50 = new TableSchema.TableColumn(schema);
				colvarC50.ColumnName = "C50";
				colvarC50.DataType = DbType.Decimal;
				colvarC50.MaxLength = 0;
				colvarC50.AutoIncrement = false;
				colvarC50.IsNullable = false;
				colvarC50.IsPrimaryKey = false;
				colvarC50.IsForeignKey = false;
				colvarC50.IsReadOnly = false;
				colvarC50.DefaultSetting = @"";
				colvarC50.ForeignKeyTableName = "";
				schema.Columns.Add(colvarC50);
				
				TableSchema.TableColumn colvarC90 = new TableSchema.TableColumn(schema);
				colvarC90.ColumnName = "C90";
				colvarC90.DataType = DbType.Decimal;
				colvarC90.MaxLength = 0;
				colvarC90.AutoIncrement = false;
				colvarC90.IsNullable = false;
				colvarC90.IsPrimaryKey = false;
				colvarC90.IsForeignKey = false;
				colvarC90.IsReadOnly = false;
				colvarC90.DefaultSetting = @"";
				colvarC90.ForeignKeyTableName = "";
				schema.Columns.Add(colvarC90);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_AlturaUterina",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("SemanasGestacion")]
		[Bindable(true)]
		public decimal SemanasGestacion 
		{
			get { return GetColumnValue<decimal>(Columns.SemanasGestacion); }
			set { SetColumnValue(Columns.SemanasGestacion, value); }
		}
		  
		[XmlAttribute("C10")]
		[Bindable(true)]
		public decimal C10 
		{
			get { return GetColumnValue<decimal>(Columns.C10); }
			set { SetColumnValue(Columns.C10, value); }
		}
		  
		[XmlAttribute("C50")]
		[Bindable(true)]
		public decimal C50 
		{
			get { return GetColumnValue<decimal>(Columns.C50); }
			set { SetColumnValue(Columns.C50, value); }
		}
		  
		[XmlAttribute("C90")]
		[Bindable(true)]
		public decimal C90 
		{
			get { return GetColumnValue<decimal>(Columns.C90); }
			set { SetColumnValue(Columns.C90, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(decimal varSemanasGestacion,decimal varC10,decimal varC50,decimal varC90)
		{
			AprAlturaUterina item = new AprAlturaUterina();
			
			item.SemanasGestacion = varSemanasGestacion;
			
			item.C10 = varC10;
			
			item.C50 = varC50;
			
			item.C90 = varC90;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,decimal varSemanasGestacion,decimal varC10,decimal varC50,decimal varC90)
		{
			AprAlturaUterina item = new AprAlturaUterina();
			
				item.Id = varId;
			
				item.SemanasGestacion = varSemanasGestacion;
			
				item.C10 = varC10;
			
				item.C50 = varC50;
			
				item.C90 = varC90;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SemanasGestacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn C10Column
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn C50Column
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn C90Column
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string SemanasGestacion = @"SemanasGestacion";
			 public static string C10 = @"C10";
			 public static string C50 = @"C50";
			 public static string C90 = @"C90";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
