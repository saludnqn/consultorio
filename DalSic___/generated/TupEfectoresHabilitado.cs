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
	/// Strongly-typed collection for the TupEfectoresHabilitado class.
	/// </summary>
    [Serializable]
	public partial class TupEfectoresHabilitadoCollection : ActiveList<TupEfectoresHabilitado, TupEfectoresHabilitadoCollection>
	{	   
		public TupEfectoresHabilitadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TupEfectoresHabilitadoCollection</returns>
		public TupEfectoresHabilitadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TupEfectoresHabilitado o = this[i];
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
	/// This is an ActiveRecord class which wraps the TUP_EfectoresHabilitados table.
	/// </summary>
	[Serializable]
	public partial class TupEfectoresHabilitado : ActiveRecord<TupEfectoresHabilitado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TupEfectoresHabilitado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TupEfectoresHabilitado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TupEfectoresHabilitado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TupEfectoresHabilitado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TUP_EfectoresHabilitados", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEfectorHabilitado = new TableSchema.TableColumn(schema);
				colvarIdEfectorHabilitado.ColumnName = "idEfectorHabilitado";
				colvarIdEfectorHabilitado.DataType = DbType.Int32;
				colvarIdEfectorHabilitado.MaxLength = 0;
				colvarIdEfectorHabilitado.AutoIncrement = true;
				colvarIdEfectorHabilitado.IsNullable = false;
				colvarIdEfectorHabilitado.IsPrimaryKey = true;
				colvarIdEfectorHabilitado.IsForeignKey = false;
				colvarIdEfectorHabilitado.IsReadOnly = false;
				colvarIdEfectorHabilitado.DefaultSetting = @"";
				colvarIdEfectorHabilitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfectorHabilitado);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("TUP_EfectoresHabilitados",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEfectorHabilitado")]
		[Bindable(true)]
		public int IdEfectorHabilitado 
		{
			get { return GetColumnValue<int>(Columns.IdEfectorHabilitado); }
			set { SetColumnValue(Columns.IdEfectorHabilitado, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector)
		{
			TupEfectoresHabilitado item = new TupEfectoresHabilitado();
			
			item.IdEfector = varIdEfector;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEfectorHabilitado,int varIdEfector)
		{
			TupEfectoresHabilitado item = new TupEfectoresHabilitado();
			
				item.IdEfectorHabilitado = varIdEfectorHabilitado;
			
				item.IdEfector = varIdEfector;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEfectorHabilitadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEfectorHabilitado = @"idEfectorHabilitado";
			 public static string IdEfector = @"idEfector";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
