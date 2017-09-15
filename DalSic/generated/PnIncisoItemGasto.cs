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
	/// Strongly-typed collection for the PnIncisoItemGasto class.
	/// </summary>
    [Serializable]
	public partial class PnIncisoItemGastoCollection : ActiveList<PnIncisoItemGasto, PnIncisoItemGastoCollection>
	{	   
		public PnIncisoItemGastoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnIncisoItemGastoCollection</returns>
		public PnIncisoItemGastoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnIncisoItemGasto o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_inciso_item_gasto table.
	/// </summary>
	[Serializable]
	public partial class PnIncisoItemGasto : ActiveRecord<PnIncisoItemGasto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnIncisoItemGasto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnIncisoItemGasto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnIncisoItemGasto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnIncisoItemGasto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_inciso_item_gasto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdIncisoItemGasto = new TableSchema.TableColumn(schema);
				colvarIdIncisoItemGasto.ColumnName = "id_inciso_item_gasto";
				colvarIdIncisoItemGasto.DataType = DbType.Int32;
				colvarIdIncisoItemGasto.MaxLength = 0;
				colvarIdIncisoItemGasto.AutoIncrement = true;
				colvarIdIncisoItemGasto.IsNullable = false;
				colvarIdIncisoItemGasto.IsPrimaryKey = true;
				colvarIdIncisoItemGasto.IsForeignKey = false;
				colvarIdIncisoItemGasto.IsReadOnly = false;
				colvarIdIncisoItemGasto.DefaultSetting = @"";
				colvarIdIncisoItemGasto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIncisoItemGasto);
				
				TableSchema.TableColumn colvarIdInciso = new TableSchema.TableColumn(schema);
				colvarIdInciso.ColumnName = "id_inciso";
				colvarIdInciso.DataType = DbType.Int32;
				colvarIdInciso.MaxLength = 0;
				colvarIdInciso.AutoIncrement = false;
				colvarIdInciso.IsNullable = false;
				colvarIdInciso.IsPrimaryKey = false;
				colvarIdInciso.IsForeignKey = true;
				colvarIdInciso.IsReadOnly = false;
				colvarIdInciso.DefaultSetting = @"";
				
					colvarIdInciso.ForeignKeyTableName = "PN_inciso";
				schema.Columns.Add(colvarIdInciso);
				
				TableSchema.TableColumn colvarIdItemGasto = new TableSchema.TableColumn(schema);
				colvarIdItemGasto.ColumnName = "id_item_gasto";
				colvarIdItemGasto.DataType = DbType.Int32;
				colvarIdItemGasto.MaxLength = 0;
				colvarIdItemGasto.AutoIncrement = false;
				colvarIdItemGasto.IsNullable = false;
				colvarIdItemGasto.IsPrimaryKey = false;
				colvarIdItemGasto.IsForeignKey = true;
				colvarIdItemGasto.IsReadOnly = false;
				colvarIdItemGasto.DefaultSetting = @"";
				
					colvarIdItemGasto.ForeignKeyTableName = "PN_item_gasto";
				schema.Columns.Add(colvarIdItemGasto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_inciso_item_gasto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdIncisoItemGasto")]
		[Bindable(true)]
		public int IdIncisoItemGasto 
		{
			get { return GetColumnValue<int>(Columns.IdIncisoItemGasto); }
			set { SetColumnValue(Columns.IdIncisoItemGasto, value); }
		}
		  
		[XmlAttribute("IdInciso")]
		[Bindable(true)]
		public int IdInciso 
		{
			get { return GetColumnValue<int>(Columns.IdInciso); }
			set { SetColumnValue(Columns.IdInciso, value); }
		}
		  
		[XmlAttribute("IdItemGasto")]
		[Bindable(true)]
		public int IdItemGasto 
		{
			get { return GetColumnValue<int>(Columns.IdItemGasto); }
			set { SetColumnValue(Columns.IdItemGasto, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnInciso ActiveRecord object related to this PnIncisoItemGasto
		/// 
		/// </summary>
		public DalSic.PnInciso PnInciso
		{
			get { return DalSic.PnInciso.FetchByID(this.IdInciso); }
			set { SetColumnValue("id_inciso", value.IdInciso); }
		}
		
		
		/// <summary>
		/// Returns a PnItemGasto ActiveRecord object related to this PnIncisoItemGasto
		/// 
		/// </summary>
		public DalSic.PnItemGasto PnItemGasto
		{
			get { return DalSic.PnItemGasto.FetchByID(this.IdItemGasto); }
			set { SetColumnValue("id_item_gasto", value.IdItemGasto); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInciso,int varIdItemGasto)
		{
			PnIncisoItemGasto item = new PnIncisoItemGasto();
			
			item.IdInciso = varIdInciso;
			
			item.IdItemGasto = varIdItemGasto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdIncisoItemGasto,int varIdInciso,int varIdItemGasto)
		{
			PnIncisoItemGasto item = new PnIncisoItemGasto();
			
				item.IdIncisoItemGasto = varIdIncisoItemGasto;
			
				item.IdInciso = varIdInciso;
			
				item.IdItemGasto = varIdItemGasto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdIncisoItemGastoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdIncisoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemGastoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdIncisoItemGasto = @"id_inciso_item_gasto";
			 public static string IdInciso = @"id_inciso";
			 public static string IdItemGasto = @"id_item_gasto";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
