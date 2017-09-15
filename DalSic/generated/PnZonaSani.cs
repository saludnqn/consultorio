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
	/// Strongly-typed collection for the PnZonaSani class.
	/// </summary>
    [Serializable]
	public partial class PnZonaSaniCollection : ActiveList<PnZonaSani, PnZonaSaniCollection>
	{	   
		public PnZonaSaniCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnZonaSaniCollection</returns>
		public PnZonaSaniCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnZonaSani o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_zona_sani table.
	/// </summary>
	[Serializable]
	public partial class PnZonaSani : ActiveRecord<PnZonaSani>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnZonaSani()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnZonaSani(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnZonaSani(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnZonaSani(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_zona_sani", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdZonaSani = new TableSchema.TableColumn(schema);
				colvarIdZonaSani.ColumnName = "id_zona_sani";
				colvarIdZonaSani.DataType = DbType.Int32;
				colvarIdZonaSani.MaxLength = 0;
				colvarIdZonaSani.AutoIncrement = true;
				colvarIdZonaSani.IsNullable = false;
				colvarIdZonaSani.IsPrimaryKey = true;
				colvarIdZonaSani.IsForeignKey = false;
				colvarIdZonaSani.IsReadOnly = false;
				colvarIdZonaSani.DefaultSetting = @"";
				colvarIdZonaSani.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdZonaSani);
				
				TableSchema.TableColumn colvarNombreZona = new TableSchema.TableColumn(schema);
				colvarNombreZona.ColumnName = "nombre_zona";
				colvarNombreZona.DataType = DbType.AnsiString;
				colvarNombreZona.MaxLength = -1;
				colvarNombreZona.AutoIncrement = false;
				colvarNombreZona.IsNullable = true;
				colvarNombreZona.IsPrimaryKey = false;
				colvarNombreZona.IsForeignKey = false;
				colvarNombreZona.IsReadOnly = false;
				colvarNombreZona.DefaultSetting = @"";
				colvarNombreZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreZona);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_zona_sani",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdZonaSani")]
		[Bindable(true)]
		public int IdZonaSani 
		{
			get { return GetColumnValue<int>(Columns.IdZonaSani); }
			set { SetColumnValue(Columns.IdZonaSani, value); }
		}
		  
		[XmlAttribute("NombreZona")]
		[Bindable(true)]
		public string NombreZona 
		{
			get { return GetColumnValue<string>(Columns.NombreZona); }
			set { SetColumnValue(Columns.NombreZona, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnEfeConvCollection colPnEfeConvRecords;
		public DalSic.PnEfeConvCollection PnEfeConvRecords
		{
			get
			{
				if(colPnEfeConvRecords == null)
				{
					colPnEfeConvRecords = new DalSic.PnEfeConvCollection().Where(PnEfeConv.Columns.IdZonaSani, IdZonaSani).Load();
					colPnEfeConvRecords.ListChanged += new ListChangedEventHandler(colPnEfeConvRecords_ListChanged);
				}
				return colPnEfeConvRecords;			
			}
			set 
			{ 
					colPnEfeConvRecords = value; 
					colPnEfeConvRecords.ListChanged += new ListChangedEventHandler(colPnEfeConvRecords_ListChanged);
			}
		}
		
		void colPnEfeConvRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnEfeConvRecords[e.NewIndex].IdZonaSani = IdZonaSani;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombreZona)
		{
			PnZonaSani item = new PnZonaSani();
			
			item.NombreZona = varNombreZona;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdZonaSani,string varNombreZona)
		{
			PnZonaSani item = new PnZonaSani();
			
				item.IdZonaSani = varIdZonaSani;
			
				item.NombreZona = varNombreZona;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdZonaSaniColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreZonaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdZonaSani = @"id_zona_sani";
			 public static string NombreZona = @"nombre_zona";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnEfeConvRecords != null)
                {
                    foreach (DalSic.PnEfeConv item in colPnEfeConvRecords)
                    {
                        if (item.IdZonaSani != IdZonaSani)
                        {
                            item.IdZonaSani = IdZonaSani;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnEfeConvRecords != null)
                {
                    colPnEfeConvRecords.SaveAll();
               }
		}
        #endregion
	}
}
