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
	/// Strongly-typed collection for the AprCondicionIngreso class.
	/// </summary>
    [Serializable]
	public partial class AprCondicionIngresoCollection : ActiveList<AprCondicionIngreso, AprCondicionIngresoCollection>
	{	   
		public AprCondicionIngresoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprCondicionIngresoCollection</returns>
		public AprCondicionIngresoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprCondicionIngreso o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_CondicionIngreso table.
	/// </summary>
	[Serializable]
	public partial class AprCondicionIngreso : ActiveRecord<AprCondicionIngreso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprCondicionIngreso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprCondicionIngreso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprCondicionIngreso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprCondicionIngreso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_CondicionIngreso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCondicionAlIngreso = new TableSchema.TableColumn(schema);
				colvarIdCondicionAlIngreso.ColumnName = "idCondicionAlIngreso";
				colvarIdCondicionAlIngreso.DataType = DbType.Int32;
				colvarIdCondicionAlIngreso.MaxLength = 0;
				colvarIdCondicionAlIngreso.AutoIncrement = true;
				colvarIdCondicionAlIngreso.IsNullable = false;
				colvarIdCondicionAlIngreso.IsPrimaryKey = true;
				colvarIdCondicionAlIngreso.IsForeignKey = false;
				colvarIdCondicionAlIngreso.IsReadOnly = false;
				colvarIdCondicionAlIngreso.DefaultSetting = @"";
				colvarIdCondicionAlIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCondicionAlIngreso);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_CondicionIngreso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCondicionAlIngreso")]
		[Bindable(true)]
		public int IdCondicionAlIngreso 
		{
			get { return GetColumnValue<int>(Columns.IdCondicionAlIngreso); }
			set { SetColumnValue(Columns.IdCondicionAlIngreso, value); }
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
        
				
		private DalSic.AprAbortoCollection colAprAbortoRecords;
		public DalSic.AprAbortoCollection AprAbortoRecords
		{
			get
			{
				if(colAprAbortoRecords == null)
				{
					colAprAbortoRecords = new DalSic.AprAbortoCollection().Where(AprAborto.Columns.IdCondicionAlIngreso, IdCondicionAlIngreso).Load();
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
				}
				return colAprAbortoRecords;			
			}
			set 
			{ 
					colAprAbortoRecords = value; 
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
			}
		}
		
		void colAprAbortoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAbortoRecords[e.NewIndex].IdCondicionAlIngreso = IdCondicionAlIngreso;
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
			AprCondicionIngreso item = new AprCondicionIngreso();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCondicionAlIngreso,string varNombre)
		{
			AprCondicionIngreso item = new AprCondicionIngreso();
			
				item.IdCondicionAlIngreso = varIdCondicionAlIngreso;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCondicionAlIngresoColumn
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
			 public static string IdCondicionAlIngreso = @"idCondicionAlIngreso";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprAbortoRecords != null)
                {
                    foreach (DalSic.AprAborto item in colAprAbortoRecords)
                    {
                        if (item.IdCondicionAlIngreso != IdCondicionAlIngreso)
                        {
                            item.IdCondicionAlIngreso = IdCondicionAlIngreso;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprAbortoRecords != null)
                {
                    colAprAbortoRecords.SaveAll();
               }
		}
        #endregion
	}
}
