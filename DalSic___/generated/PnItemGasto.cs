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
	/// Strongly-typed collection for the PnItemGasto class.
	/// </summary>
    [Serializable]
	public partial class PnItemGastoCollection : ActiveList<PnItemGasto, PnItemGastoCollection>
	{	   
		public PnItemGastoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnItemGastoCollection</returns>
		public PnItemGastoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnItemGasto o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_item_gasto table.
	/// </summary>
	[Serializable]
	public partial class PnItemGasto : ActiveRecord<PnItemGasto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnItemGasto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnItemGasto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnItemGasto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnItemGasto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_item_gasto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdItemGasto = new TableSchema.TableColumn(schema);
				colvarIdItemGasto.ColumnName = "id_item_gasto";
				colvarIdItemGasto.DataType = DbType.Int32;
				colvarIdItemGasto.MaxLength = 0;
				colvarIdItemGasto.AutoIncrement = true;
				colvarIdItemGasto.IsNullable = false;
				colvarIdItemGasto.IsPrimaryKey = true;
				colvarIdItemGasto.IsForeignKey = false;
				colvarIdItemGasto.IsReadOnly = false;
				colvarIdItemGasto.DefaultSetting = @"";
				colvarIdItemGasto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItemGasto);
				
				TableSchema.TableColumn colvarItemNombre = new TableSchema.TableColumn(schema);
				colvarItemNombre.ColumnName = "item_nombre";
				colvarItemNombre.DataType = DbType.AnsiString;
				colvarItemNombre.MaxLength = 500;
				colvarItemNombre.AutoIncrement = false;
				colvarItemNombre.IsNullable = false;
				colvarItemNombre.IsPrimaryKey = false;
				colvarItemNombre.IsForeignKey = false;
				colvarItemNombre.IsReadOnly = false;
				colvarItemNombre.DefaultSetting = @"";
				colvarItemNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItemNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_item_gasto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdItemGasto")]
		[Bindable(true)]
		public int IdItemGasto 
		{
			get { return GetColumnValue<int>(Columns.IdItemGasto); }
			set { SetColumnValue(Columns.IdItemGasto, value); }
		}
		  
		[XmlAttribute("ItemNombre")]
		[Bindable(true)]
		public string ItemNombre 
		{
			get { return GetColumnValue<string>(Columns.ItemNombre); }
			set { SetColumnValue(Columns.ItemNombre, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnIncisoItemGastoCollection colPnIncisoItemGastoRecords;
		public DalSic.PnIncisoItemGastoCollection PnIncisoItemGastoRecords
		{
			get
			{
				if(colPnIncisoItemGastoRecords == null)
				{
					colPnIncisoItemGastoRecords = new DalSic.PnIncisoItemGastoCollection().Where(PnIncisoItemGasto.Columns.IdItemGasto, IdItemGasto).Load();
					colPnIncisoItemGastoRecords.ListChanged += new ListChangedEventHandler(colPnIncisoItemGastoRecords_ListChanged);
				}
				return colPnIncisoItemGastoRecords;			
			}
			set 
			{ 
					colPnIncisoItemGastoRecords = value; 
					colPnIncisoItemGastoRecords.ListChanged += new ListChangedEventHandler(colPnIncisoItemGastoRecords_ListChanged);
			}
		}
		
		void colPnIncisoItemGastoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnIncisoItemGastoRecords[e.NewIndex].IdItemGasto = IdItemGasto;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varItemNombre)
		{
			PnItemGasto item = new PnItemGasto();
			
			item.ItemNombre = varItemNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdItemGasto,string varItemNombre)
		{
			PnItemGasto item = new PnItemGasto();
			
				item.IdItemGasto = varIdItemGasto;
			
				item.ItemNombre = varItemNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdItemGastoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ItemNombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdItemGasto = @"id_item_gasto";
			 public static string ItemNombre = @"item_nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnIncisoItemGastoRecords != null)
                {
                    foreach (DalSic.PnIncisoItemGasto item in colPnIncisoItemGastoRecords)
                    {
                        if (item.IdItemGasto != IdItemGasto)
                        {
                            item.IdItemGasto = IdItemGasto;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnIncisoItemGastoRecords != null)
                {
                    colPnIncisoItemGastoRecords.SaveAll();
               }
		}
        #endregion
	}
}
