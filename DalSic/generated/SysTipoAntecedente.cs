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
	/// Strongly-typed collection for the SysTipoAntecedente class.
	/// </summary>
    [Serializable]
	public partial class SysTipoAntecedenteCollection : ActiveList<SysTipoAntecedente, SysTipoAntecedenteCollection>
	{	   
		public SysTipoAntecedenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysTipoAntecedenteCollection</returns>
		public SysTipoAntecedenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysTipoAntecedente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_TipoAntecedente table.
	/// </summary>
	[Serializable]
	public partial class SysTipoAntecedente : ActiveRecord<SysTipoAntecedente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysTipoAntecedente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysTipoAntecedente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysTipoAntecedente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysTipoAntecedente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_TipoAntecedente", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoAntecedente = new TableSchema.TableColumn(schema);
				colvarIdTipoAntecedente.ColumnName = "idTipoAntecedente";
				colvarIdTipoAntecedente.DataType = DbType.Int32;
				colvarIdTipoAntecedente.MaxLength = 0;
				colvarIdTipoAntecedente.AutoIncrement = true;
				colvarIdTipoAntecedente.IsNullable = false;
				colvarIdTipoAntecedente.IsPrimaryKey = true;
				colvarIdTipoAntecedente.IsForeignKey = false;
				colvarIdTipoAntecedente.IsReadOnly = false;
				colvarIdTipoAntecedente.DefaultSetting = @"";
				colvarIdTipoAntecedente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoAntecedente);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
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
				DataService.Providers["sicProvider"].AddSchema("Sys_TipoAntecedente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoAntecedente")]
		[Bindable(true)]
		public int IdTipoAntecedente 
		{
			get { return GetColumnValue<int>(Columns.IdTipoAntecedente); }
			set { SetColumnValue(Columns.IdTipoAntecedente, value); }
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
        
				
		private DalSic.SysAntecedenteCollection colSysAntecedenteRecords;
		public DalSic.SysAntecedenteCollection SysAntecedenteRecords
		{
			get
			{
				if(colSysAntecedenteRecords == null)
				{
					colSysAntecedenteRecords = new DalSic.SysAntecedenteCollection().Where(SysAntecedente.Columns.IdTipoAntecedente, IdTipoAntecedente).Load();
					colSysAntecedenteRecords.ListChanged += new ListChangedEventHandler(colSysAntecedenteRecords_ListChanged);
				}
				return colSysAntecedenteRecords;			
			}
			set 
			{ 
					colSysAntecedenteRecords = value; 
					colSysAntecedenteRecords.ListChanged += new ListChangedEventHandler(colSysAntecedenteRecords_ListChanged);
			}
		}
		
		void colSysAntecedenteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysAntecedenteRecords[e.NewIndex].IdTipoAntecedente = IdTipoAntecedente;
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
			SysTipoAntecedente item = new SysTipoAntecedente();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoAntecedente,string varNombre)
		{
			SysTipoAntecedente item = new SysTipoAntecedente();
			
				item.IdTipoAntecedente = varIdTipoAntecedente;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoAntecedenteColumn
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
			 public static string IdTipoAntecedente = @"idTipoAntecedente";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysAntecedenteRecords != null)
                {
                    foreach (DalSic.SysAntecedente item in colSysAntecedenteRecords)
                    {
                        if (item.IdTipoAntecedente != IdTipoAntecedente)
                        {
                            item.IdTipoAntecedente = IdTipoAntecedente;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysAntecedenteRecords != null)
                {
                    colSysAntecedenteRecords.SaveAll();
               }
		}
        #endregion
	}
}
