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
	/// Strongly-typed collection for the AprTerminacionParto class.
	/// </summary>
    [Serializable]
	public partial class AprTerminacionPartoCollection : ActiveList<AprTerminacionParto, AprTerminacionPartoCollection>
	{	   
		public AprTerminacionPartoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprTerminacionPartoCollection</returns>
		public AprTerminacionPartoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprTerminacionParto o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_TerminacionParto table.
	/// </summary>
	[Serializable]
	public partial class AprTerminacionParto : ActiveRecord<AprTerminacionParto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprTerminacionParto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprTerminacionParto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprTerminacionParto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprTerminacionParto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_TerminacionParto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTerminacionParto = new TableSchema.TableColumn(schema);
				colvarIdTerminacionParto.ColumnName = "idTerminacionParto";
				colvarIdTerminacionParto.DataType = DbType.Int32;
				colvarIdTerminacionParto.MaxLength = 0;
				colvarIdTerminacionParto.AutoIncrement = true;
				colvarIdTerminacionParto.IsNullable = false;
				colvarIdTerminacionParto.IsPrimaryKey = true;
				colvarIdTerminacionParto.IsForeignKey = false;
				colvarIdTerminacionParto.IsReadOnly = false;
				colvarIdTerminacionParto.DefaultSetting = @"";
				colvarIdTerminacionParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTerminacionParto);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarLocal = new TableSchema.TableColumn(schema);
				colvarLocal.ColumnName = "local";
				colvarLocal.DataType = DbType.Boolean;
				colvarLocal.MaxLength = 0;
				colvarLocal.AutoIncrement = false;
				colvarLocal.IsNullable = false;
				colvarLocal.IsPrimaryKey = false;
				colvarLocal.IsForeignKey = false;
				colvarLocal.IsReadOnly = false;
				
						colvarLocal.DefaultSetting = @"((1))";
				colvarLocal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocal);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_TerminacionParto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTerminacionParto")]
		[Bindable(true)]
		public int IdTerminacionParto 
		{
			get { return GetColumnValue<int>(Columns.IdTerminacionParto); }
			set { SetColumnValue(Columns.IdTerminacionParto, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Local")]
		[Bindable(true)]
		public bool Local 
		{
			get { return GetColumnValue<bool>(Columns.Local); }
			set { SetColumnValue(Columns.Local, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprPartoProvisorioCollection colAprPartoProvisorioRecords;
		public DalSic.AprPartoProvisorioCollection AprPartoProvisorioRecords
		{
			get
			{
				if(colAprPartoProvisorioRecords == null)
				{
					colAprPartoProvisorioRecords = new DalSic.AprPartoProvisorioCollection().Where(AprPartoProvisorio.Columns.IdTerminacionParto, IdTerminacionParto).Load();
					colAprPartoProvisorioRecords.ListChanged += new ListChangedEventHandler(colAprPartoProvisorioRecords_ListChanged);
				}
				return colAprPartoProvisorioRecords;			
			}
			set 
			{ 
					colAprPartoProvisorioRecords = value; 
					colAprPartoProvisorioRecords.ListChanged += new ListChangedEventHandler(colAprPartoProvisorioRecords_ListChanged);
			}
		}
		
		void colAprPartoProvisorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprPartoProvisorioRecords[e.NewIndex].IdTerminacionParto = IdTerminacionParto;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,bool varLocal)
		{
			AprTerminacionParto item = new AprTerminacionParto();
			
			item.Nombre = varNombre;
			
			item.Local = varLocal;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTerminacionParto,string varNombre,bool varLocal)
		{
			AprTerminacionParto item = new AprTerminacionParto();
			
				item.IdTerminacionParto = varIdTerminacionParto;
			
				item.Nombre = varNombre;
			
				item.Local = varLocal;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTerminacionPartoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTerminacionParto = @"idTerminacionParto";
			 public static string Nombre = @"nombre";
			 public static string Local = @"local";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprPartoProvisorioRecords != null)
                {
                    foreach (DalSic.AprPartoProvisorio item in colAprPartoProvisorioRecords)
                    {
                        if (item.IdTerminacionParto != IdTerminacionParto)
                        {
                            item.IdTerminacionParto = IdTerminacionParto;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprPartoProvisorioRecords != null)
                {
                    colAprPartoProvisorioRecords.SaveAll();
               }
		}
        #endregion
	}
}
