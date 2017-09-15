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
	/// Strongly-typed collection for the SysTipoProfesional class.
	/// </summary>
    [Serializable]
	public partial class SysTipoProfesionalCollection : ActiveList<SysTipoProfesional, SysTipoProfesionalCollection>
	{	   
		public SysTipoProfesionalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysTipoProfesionalCollection</returns>
		public SysTipoProfesionalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysTipoProfesional o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_TipoProfesional table.
	/// </summary>
	[Serializable]
	public partial class SysTipoProfesional : ActiveRecord<SysTipoProfesional>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysTipoProfesional()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysTipoProfesional(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysTipoProfesional(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysTipoProfesional(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_TipoProfesional", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoProfesional = new TableSchema.TableColumn(schema);
				colvarIdTipoProfesional.ColumnName = "idTipoProfesional";
				colvarIdTipoProfesional.DataType = DbType.Int32;
				colvarIdTipoProfesional.MaxLength = 0;
				colvarIdTipoProfesional.AutoIncrement = true;
				colvarIdTipoProfesional.IsNullable = false;
				colvarIdTipoProfesional.IsPrimaryKey = true;
				colvarIdTipoProfesional.IsForeignKey = false;
				colvarIdTipoProfesional.IsReadOnly = false;
				colvarIdTipoProfesional.DefaultSetting = @"";
				colvarIdTipoProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoProfesional);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_TipoProfesional",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoProfesional")]
		[Bindable(true)]
		public int IdTipoProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdTipoProfesional); }
			set { SetColumnValue(Columns.IdTipoProfesional, value); }
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
        
				
		private DalSic.SysProfesionalCollection colSysProfesionalRecords;
		public DalSic.SysProfesionalCollection SysProfesionalRecords
		{
			get
			{
				if(colSysProfesionalRecords == null)
				{
					colSysProfesionalRecords = new DalSic.SysProfesionalCollection().Where(SysProfesional.Columns.IdTipoProfesional, IdTipoProfesional).Load();
					colSysProfesionalRecords.ListChanged += new ListChangedEventHandler(colSysProfesionalRecords_ListChanged);
				}
				return colSysProfesionalRecords;			
			}
			set 
			{ 
					colSysProfesionalRecords = value; 
					colSysProfesionalRecords.ListChanged += new ListChangedEventHandler(colSysProfesionalRecords_ListChanged);
			}
		}
		
		void colSysProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysProfesionalRecords[e.NewIndex].IdTipoProfesional = IdTipoProfesional;
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
			SysTipoProfesional item = new SysTipoProfesional();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoProfesional,string varNombre)
		{
			SysTipoProfesional item = new SysTipoProfesional();
			
				item.IdTipoProfesional = varIdTipoProfesional;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoProfesionalColumn
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
			 public static string IdTipoProfesional = @"idTipoProfesional";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysProfesionalRecords != null)
                {
                    foreach (DalSic.SysProfesional item in colSysProfesionalRecords)
                    {
                        if (item.IdTipoProfesional != IdTipoProfesional)
                        {
                            item.IdTipoProfesional = IdTipoProfesional;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysProfesionalRecords != null)
                {
                    colSysProfesionalRecords.SaveAll();
               }
		}
        #endregion
	}
}
