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
	/// Strongly-typed collection for the SysZona class.
	/// </summary>
    [Serializable]
	public partial class SysZonaCollection : ActiveList<SysZona, SysZonaCollection>
	{	   
		public SysZonaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysZonaCollection</returns>
		public SysZonaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysZona o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Zona table.
	/// </summary>
	[Serializable]
	public partial class SysZona : ActiveRecord<SysZona>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysZona()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysZona(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysZona(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysZona(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Zona", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdZona = new TableSchema.TableColumn(schema);
				colvarIdZona.ColumnName = "idZona";
				colvarIdZona.DataType = DbType.Int32;
				colvarIdZona.MaxLength = 0;
				colvarIdZona.AutoIncrement = true;
				colvarIdZona.IsNullable = false;
				colvarIdZona.IsPrimaryKey = true;
				colvarIdZona.IsForeignKey = false;
				colvarIdZona.IsReadOnly = false;
				colvarIdZona.DefaultSetting = @"";
				colvarIdZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdZona);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdLocalidad = new TableSchema.TableColumn(schema);
				colvarIdLocalidad.ColumnName = "idLocalidad";
				colvarIdLocalidad.DataType = DbType.Int32;
				colvarIdLocalidad.MaxLength = 0;
				colvarIdLocalidad.AutoIncrement = false;
				colvarIdLocalidad.IsNullable = false;
				colvarIdLocalidad.IsPrimaryKey = false;
				colvarIdLocalidad.IsForeignKey = false;
				colvarIdLocalidad.IsReadOnly = false;
				colvarIdLocalidad.DefaultSetting = @"";
				colvarIdLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLocalidad);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "responsable";
				colvarResponsable.DataType = DbType.String;
				colvarResponsable.MaxLength = 100;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = false;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				TableSchema.TableColumn colvarZona = new TableSchema.TableColumn(schema);
				colvarZona.ColumnName = "Zona";
				colvarZona.DataType = DbType.String;
				colvarZona.MaxLength = 3;
				colvarZona.AutoIncrement = false;
				colvarZona.IsNullable = true;
				colvarZona.IsPrimaryKey = false;
				colvarZona.IsForeignKey = false;
				colvarZona.IsReadOnly = false;
				colvarZona.DefaultSetting = @"";
				colvarZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarZona);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Zona",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdZona")]
		[Bindable(true)]
		public int IdZona 
		{
			get { return GetColumnValue<int>(Columns.IdZona); }
			set { SetColumnValue(Columns.IdZona, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdLocalidad")]
		[Bindable(true)]
		public int IdLocalidad 
		{
			get { return GetColumnValue<int>(Columns.IdLocalidad); }
			set { SetColumnValue(Columns.IdLocalidad, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		  
		[XmlAttribute("Zona")]
		[Bindable(true)]
		public string Zona 
		{
			get { return GetColumnValue<string>(Columns.Zona); }
			set { SetColumnValue(Columns.Zona, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysEfectorCollection colSysEfectorRecords;
		public DalSic.SysEfectorCollection SysEfectorRecords
		{
			get
			{
				if(colSysEfectorRecords == null)
				{
					colSysEfectorRecords = new DalSic.SysEfectorCollection().Where(SysEfector.Columns.IdZona, IdZona).Load();
					colSysEfectorRecords.ListChanged += new ListChangedEventHandler(colSysEfectorRecords_ListChanged);
				}
				return colSysEfectorRecords;			
			}
			set 
			{ 
					colSysEfectorRecords = value; 
					colSysEfectorRecords.ListChanged += new ListChangedEventHandler(colSysEfectorRecords_ListChanged);
			}
		}
		
		void colSysEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysEfectorRecords[e.NewIndex].IdZona = IdZona;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdLocalidad,string varResponsable,string varZona)
		{
			SysZona item = new SysZona();
			
			item.Nombre = varNombre;
			
			item.IdLocalidad = varIdLocalidad;
			
			item.Responsable = varResponsable;
			
			item.Zona = varZona;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdZona,string varNombre,int varIdLocalidad,string varResponsable,string varZona)
		{
			SysZona item = new SysZona();
			
				item.IdZona = varIdZona;
			
				item.Nombre = varNombre;
			
				item.IdLocalidad = varIdLocalidad;
			
				item.Responsable = varResponsable;
			
				item.Zona = varZona;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdZonaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLocalidadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ZonaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdZona = @"idZona";
			 public static string Nombre = @"nombre";
			 public static string IdLocalidad = @"idLocalidad";
			 public static string Responsable = @"responsable";
			 public static string Zona = @"Zona";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysEfectorRecords != null)
                {
                    foreach (DalSic.SysEfector item in colSysEfectorRecords)
                    {
                        if (item.IdZona != IdZona)
                        {
                            item.IdZona = IdZona;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysEfectorRecords != null)
                {
                    colSysEfectorRecords.SaveAll();
               }
		}
        #endregion
	}
}
