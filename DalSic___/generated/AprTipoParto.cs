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
	/// Strongly-typed collection for the AprTipoParto class.
	/// </summary>
    [Serializable]
	public partial class AprTipoPartoCollection : ActiveList<AprTipoParto, AprTipoPartoCollection>
	{	   
		public AprTipoPartoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprTipoPartoCollection</returns>
		public AprTipoPartoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprTipoParto o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_TipoParto table.
	/// </summary>
	[Serializable]
	public partial class AprTipoParto : ActiveRecord<AprTipoParto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprTipoParto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprTipoParto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprTipoParto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprTipoParto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_TipoParto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoParto = new TableSchema.TableColumn(schema);
				colvarIdTipoParto.ColumnName = "idTipoParto";
				colvarIdTipoParto.DataType = DbType.Int32;
				colvarIdTipoParto.MaxLength = 0;
				colvarIdTipoParto.AutoIncrement = true;
				colvarIdTipoParto.IsNullable = false;
				colvarIdTipoParto.IsPrimaryKey = true;
				colvarIdTipoParto.IsForeignKey = false;
				colvarIdTipoParto.IsReadOnly = false;
				colvarIdTipoParto.DefaultSetting = @"";
				colvarIdTipoParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoParto);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_TipoParto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoParto")]
		[Bindable(true)]
		public int IdTipoParto 
		{
			get { return GetColumnValue<int>(Columns.IdTipoParto); }
			set { SetColumnValue(Columns.IdTipoParto, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprRecienNacidoCollection colAprRecienNacidoRecords;
		public DalSic.AprRecienNacidoCollection AprRecienNacidoRecords
		{
			get
			{
				if(colAprRecienNacidoRecords == null)
				{
					colAprRecienNacidoRecords = new DalSic.AprRecienNacidoCollection().Where(AprRecienNacido.Columns.IdTipoParto, IdTipoParto).Load();
					colAprRecienNacidoRecords.ListChanged += new ListChangedEventHandler(colAprRecienNacidoRecords_ListChanged);
				}
				return colAprRecienNacidoRecords;			
			}
			set 
			{ 
					colAprRecienNacidoRecords = value; 
					colAprRecienNacidoRecords.ListChanged += new ListChangedEventHandler(colAprRecienNacidoRecords_ListChanged);
			}
		}
		
		void colAprRecienNacidoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprRecienNacidoRecords[e.NewIndex].IdTipoParto = IdTipoParto;
		    }
		}
				
		private DalSic.AprPartoProvisorioCollection colAprPartoProvisorioRecords;
		public DalSic.AprPartoProvisorioCollection AprPartoProvisorioRecords
		{
			get
			{
				if(colAprPartoProvisorioRecords == null)
				{
					colAprPartoProvisorioRecords = new DalSic.AprPartoProvisorioCollection().Where(AprPartoProvisorio.Columns.IdTerminacionParto, IdTipoParto).Load();
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
		        colAprPartoProvisorioRecords[e.NewIndex].IdTerminacionParto = IdTipoParto;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			AprTipoParto item = new AprTipoParto();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoParto,string varNombre)
		{
			AprTipoParto item = new AprTipoParto();
			
				item.IdTipoParto = varIdTipoParto;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoPartoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoParto = @"idTipoParto";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprRecienNacidoRecords != null)
                {
                    foreach (DalSic.AprRecienNacido item in colAprRecienNacidoRecords)
                    {
                        if (item.IdTipoParto != IdTipoParto)
                        {
                            item.IdTipoParto = IdTipoParto;
                        }
                    }
               }
		
                if (colAprPartoProvisorioRecords != null)
                {
                    foreach (DalSic.AprPartoProvisorio item in colAprPartoProvisorioRecords)
                    {
                        if (item.IdTerminacionParto != IdTipoParto)
                        {
                            item.IdTerminacionParto = IdTipoParto;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprRecienNacidoRecords != null)
                {
                    colAprRecienNacidoRecords.SaveAll();
               }
		
                if (colAprPartoProvisorioRecords != null)
                {
                    colAprPartoProvisorioRecords.SaveAll();
               }
		}
        #endregion
	}
}
