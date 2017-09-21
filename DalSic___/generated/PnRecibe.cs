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
	/// Strongly-typed collection for the PnRecibe class.
	/// </summary>
    [Serializable]
	public partial class PnRecibeCollection : ActiveList<PnRecibe, PnRecibeCollection>
	{	   
		public PnRecibeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnRecibeCollection</returns>
		public PnRecibeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnRecibe o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_recibe table.
	/// </summary>
	[Serializable]
	public partial class PnRecibe : ActiveRecord<PnRecibe>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnRecibe()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnRecibe(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnRecibe(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnRecibe(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_recibe", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRecibe = new TableSchema.TableColumn(schema);
				colvarIdRecibe.ColumnName = "id_recibe";
				colvarIdRecibe.DataType = DbType.Int32;
				colvarIdRecibe.MaxLength = 0;
				colvarIdRecibe.AutoIncrement = true;
				colvarIdRecibe.IsNullable = false;
				colvarIdRecibe.IsPrimaryKey = true;
				colvarIdRecibe.IsForeignKey = false;
				colvarIdRecibe.IsReadOnly = false;
				colvarIdRecibe.DefaultSetting = @"";
				colvarIdRecibe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRecibe);
				
				TableSchema.TableColumn colvarDescripcionRecibe = new TableSchema.TableColumn(schema);
				colvarDescripcionRecibe.ColumnName = "descripcion_recibe";
				colvarDescripcionRecibe.DataType = DbType.AnsiString;
				colvarDescripcionRecibe.MaxLength = -1;
				colvarDescripcionRecibe.AutoIncrement = false;
				colvarDescripcionRecibe.IsNullable = true;
				colvarDescripcionRecibe.IsPrimaryKey = false;
				colvarDescripcionRecibe.IsForeignKey = false;
				colvarDescripcionRecibe.IsReadOnly = false;
				colvarDescripcionRecibe.DefaultSetting = @"";
				colvarDescripcionRecibe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionRecibe);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_recibe",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRecibe")]
		[Bindable(true)]
		public int IdRecibe 
		{
			get { return GetColumnValue<int>(Columns.IdRecibe); }
			set { SetColumnValue(Columns.IdRecibe, value); }
		}
		  
		[XmlAttribute("DescripcionRecibe")]
		[Bindable(true)]
		public string DescripcionRecibe 
		{
			get { return GetColumnValue<string>(Columns.DescripcionRecibe); }
			set { SetColumnValue(Columns.DescripcionRecibe, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcionRecibe)
		{
			PnRecibe item = new PnRecibe();
			
			item.DescripcionRecibe = varDescripcionRecibe;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRecibe,string varDescripcionRecibe)
		{
			PnRecibe item = new PnRecibe();
			
				item.IdRecibe = varIdRecibe;
			
				item.DescripcionRecibe = varDescripcionRecibe;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRecibeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionRecibeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRecibe = @"id_recibe";
			 public static string DescripcionRecibe = @"descripcion_recibe";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
