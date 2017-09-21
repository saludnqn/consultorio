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
	/// Strongly-typed collection for the SysNivelInstruccion class.
	/// </summary>
    [Serializable]
	public partial class SysNivelInstruccionCollection : ActiveList<SysNivelInstruccion, SysNivelInstruccionCollection>
	{	   
		public SysNivelInstruccionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysNivelInstruccionCollection</returns>
		public SysNivelInstruccionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysNivelInstruccion o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_NivelInstruccion table.
	/// </summary>
	[Serializable]
	public partial class SysNivelInstruccion : ActiveRecord<SysNivelInstruccion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysNivelInstruccion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysNivelInstruccion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysNivelInstruccion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysNivelInstruccion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_NivelInstruccion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNivelInstruccion = new TableSchema.TableColumn(schema);
				colvarIdNivelInstruccion.ColumnName = "idNivelInstruccion";
				colvarIdNivelInstruccion.DataType = DbType.Int32;
				colvarIdNivelInstruccion.MaxLength = 0;
				colvarIdNivelInstruccion.AutoIncrement = true;
				colvarIdNivelInstruccion.IsNullable = false;
				colvarIdNivelInstruccion.IsPrimaryKey = true;
				colvarIdNivelInstruccion.IsForeignKey = false;
				colvarIdNivelInstruccion.IsReadOnly = false;
				colvarIdNivelInstruccion.DefaultSetting = @"";
				colvarIdNivelInstruccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNivelInstruccion);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_NivelInstruccion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNivelInstruccion")]
		[Bindable(true)]
		public int IdNivelInstruccion 
		{
			get { return GetColumnValue<int>(Columns.IdNivelInstruccion); }
			set { SetColumnValue(Columns.IdNivelInstruccion, value); }
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
        
				
		private DalSic.SysParentescoCollection colSysParentescoRecords;
		public DalSic.SysParentescoCollection SysParentescoRecords
		{
			get
			{
				if(colSysParentescoRecords == null)
				{
					colSysParentescoRecords = new DalSic.SysParentescoCollection().Where(SysParentesco.Columns.IdNivelInstruccion, IdNivelInstruccion).Load();
					colSysParentescoRecords.ListChanged += new ListChangedEventHandler(colSysParentescoRecords_ListChanged);
				}
				return colSysParentescoRecords;			
			}
			set 
			{ 
					colSysParentescoRecords = value; 
					colSysParentescoRecords.ListChanged += new ListChangedEventHandler(colSysParentescoRecords_ListChanged);
			}
		}
		
		void colSysParentescoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysParentescoRecords[e.NewIndex].IdNivelInstruccion = IdNivelInstruccion;
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
			SysNivelInstruccion item = new SysNivelInstruccion();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNivelInstruccion,string varNombre)
		{
			SysNivelInstruccion item = new SysNivelInstruccion();
			
				item.IdNivelInstruccion = varIdNivelInstruccion;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNivelInstruccionColumn
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
			 public static string IdNivelInstruccion = @"idNivelInstruccion";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysParentescoRecords != null)
                {
                    foreach (DalSic.SysParentesco item in colSysParentescoRecords)
                    {
                        if (item.IdNivelInstruccion != IdNivelInstruccion)
                        {
                            item.IdNivelInstruccion = IdNivelInstruccion;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysParentescoRecords != null)
                {
                    colSysParentescoRecords.SaveAll();
               }
		}
        #endregion
	}
}
