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
	/// Strongly-typed collection for the AprTipoActividadEmbarazo class.
	/// </summary>
    [Serializable]
	public partial class AprTipoActividadEmbarazoCollection : ActiveList<AprTipoActividadEmbarazo, AprTipoActividadEmbarazoCollection>
	{	   
		public AprTipoActividadEmbarazoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprTipoActividadEmbarazoCollection</returns>
		public AprTipoActividadEmbarazoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprTipoActividadEmbarazo o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_TipoActividadEmbarazo table.
	/// </summary>
	[Serializable]
	public partial class AprTipoActividadEmbarazo : ActiveRecord<AprTipoActividadEmbarazo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprTipoActividadEmbarazo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprTipoActividadEmbarazo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprTipoActividadEmbarazo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprTipoActividadEmbarazo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_TipoActividadEmbarazo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoActividadEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdTipoActividadEmbarazo.ColumnName = "idTipoActividadEmbarazo";
				colvarIdTipoActividadEmbarazo.DataType = DbType.Int32;
				colvarIdTipoActividadEmbarazo.MaxLength = 0;
				colvarIdTipoActividadEmbarazo.AutoIncrement = true;
				colvarIdTipoActividadEmbarazo.IsNullable = false;
				colvarIdTipoActividadEmbarazo.IsPrimaryKey = true;
				colvarIdTipoActividadEmbarazo.IsForeignKey = false;
				colvarIdTipoActividadEmbarazo.IsReadOnly = false;
				colvarIdTipoActividadEmbarazo.DefaultSetting = @"";
				colvarIdTipoActividadEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoActividadEmbarazo);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_TipoActividadEmbarazo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoActividadEmbarazo")]
		[Bindable(true)]
		public int IdTipoActividadEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdTipoActividadEmbarazo); }
			set { SetColumnValue(Columns.IdTipoActividadEmbarazo, value); }
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
        
				
		private DalSic.AprActividadEmbarazoCollection colAprActividadEmbarazoRecords;
		public DalSic.AprActividadEmbarazoCollection AprActividadEmbarazoRecords
		{
			get
			{
				if(colAprActividadEmbarazoRecords == null)
				{
					colAprActividadEmbarazoRecords = new DalSic.AprActividadEmbarazoCollection().Where(AprActividadEmbarazo.Columns.IdTipoActividadEmbarazo, IdTipoActividadEmbarazo).Load();
					colAprActividadEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprActividadEmbarazoRecords_ListChanged);
				}
				return colAprActividadEmbarazoRecords;			
			}
			set 
			{ 
					colAprActividadEmbarazoRecords = value; 
					colAprActividadEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprActividadEmbarazoRecords_ListChanged);
			}
		}
		
		void colAprActividadEmbarazoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprActividadEmbarazoRecords[e.NewIndex].IdTipoActividadEmbarazo = IdTipoActividadEmbarazo;
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
			AprTipoActividadEmbarazo item = new AprTipoActividadEmbarazo();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoActividadEmbarazo,string varNombre)
		{
			AprTipoActividadEmbarazo item = new AprTipoActividadEmbarazo();
			
				item.IdTipoActividadEmbarazo = varIdTipoActividadEmbarazo;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoActividadEmbarazoColumn
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
			 public static string IdTipoActividadEmbarazo = @"idTipoActividadEmbarazo";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprActividadEmbarazoRecords != null)
                {
                    foreach (DalSic.AprActividadEmbarazo item in colAprActividadEmbarazoRecords)
                    {
                        if (item.IdTipoActividadEmbarazo != IdTipoActividadEmbarazo)
                        {
                            item.IdTipoActividadEmbarazo = IdTipoActividadEmbarazo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprActividadEmbarazoRecords != null)
                {
                    colAprActividadEmbarazoRecords.SaveAll();
               }
		}
        #endregion
	}
}
