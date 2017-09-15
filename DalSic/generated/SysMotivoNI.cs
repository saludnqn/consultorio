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
	/// Strongly-typed collection for the SysMotivoNI class.
	/// </summary>
    [Serializable]
	public partial class SysMotivoNICollection : ActiveList<SysMotivoNI, SysMotivoNICollection>
	{	   
		public SysMotivoNICollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysMotivoNICollection</returns>
		public SysMotivoNICollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysMotivoNI o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_MotivoNI table.
	/// </summary>
	[Serializable]
	public partial class SysMotivoNI : ActiveRecord<SysMotivoNI>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysMotivoNI()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysMotivoNI(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysMotivoNI(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysMotivoNI(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_MotivoNI", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMotivoNI = new TableSchema.TableColumn(schema);
				colvarIdMotivoNI.ColumnName = "idMotivoNI";
				colvarIdMotivoNI.DataType = DbType.Int32;
				colvarIdMotivoNI.MaxLength = 0;
				colvarIdMotivoNI.AutoIncrement = true;
				colvarIdMotivoNI.IsNullable = false;
				colvarIdMotivoNI.IsPrimaryKey = true;
				colvarIdMotivoNI.IsForeignKey = false;
				colvarIdMotivoNI.IsReadOnly = false;
				colvarIdMotivoNI.DefaultSetting = @"";
				colvarIdMotivoNI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoNI);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_MotivoNI",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMotivoNI")]
		[Bindable(true)]
		public int IdMotivoNI 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoNI); }
			set { SetColumnValue(Columns.IdMotivoNI, value); }
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
        
				
		private DalSic.SysPacienteCollection colSysPacienteRecords;
		public DalSic.SysPacienteCollection SysPacienteRecords
		{
			get
			{
				if(colSysPacienteRecords == null)
				{
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdMotivoNI, IdMotivoNI).Load();
					colSysPacienteRecords.ListChanged += new ListChangedEventHandler(colSysPacienteRecords_ListChanged);
				}
				return colSysPacienteRecords;			
			}
			set 
			{ 
					colSysPacienteRecords = value; 
					colSysPacienteRecords.ListChanged += new ListChangedEventHandler(colSysPacienteRecords_ListChanged);
			}
		}
		
		void colSysPacienteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysPacienteRecords[e.NewIndex].IdMotivoNI = IdMotivoNI;
		    }
		}
				
		private DalSic.SysRelEstadoMotivoNICollection colSysRelEstadoMotivoNIRecords;
		public DalSic.SysRelEstadoMotivoNICollection SysRelEstadoMotivoNIRecords
		{
			get
			{
				if(colSysRelEstadoMotivoNIRecords == null)
				{
					colSysRelEstadoMotivoNIRecords = new DalSic.SysRelEstadoMotivoNICollection().Where(SysRelEstadoMotivoNI.Columns.IdMotivoNI, IdMotivoNI).Load();
					colSysRelEstadoMotivoNIRecords.ListChanged += new ListChangedEventHandler(colSysRelEstadoMotivoNIRecords_ListChanged);
				}
				return colSysRelEstadoMotivoNIRecords;			
			}
			set 
			{ 
					colSysRelEstadoMotivoNIRecords = value; 
					colSysRelEstadoMotivoNIRecords.ListChanged += new ListChangedEventHandler(colSysRelEstadoMotivoNIRecords_ListChanged);
			}
		}
		
		void colSysRelEstadoMotivoNIRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelEstadoMotivoNIRecords[e.NewIndex].IdMotivoNI = IdMotivoNI;
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
			SysMotivoNI item = new SysMotivoNI();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMotivoNI,string varNombre)
		{
			SysMotivoNI item = new SysMotivoNI();
			
				item.IdMotivoNI = varIdMotivoNI;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMotivoNIColumn
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
			 public static string IdMotivoNI = @"idMotivoNI";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysPacienteRecords != null)
                {
                    foreach (DalSic.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdMotivoNI != IdMotivoNI)
                        {
                            item.IdMotivoNI = IdMotivoNI;
                        }
                    }
               }
		
                if (colSysRelEstadoMotivoNIRecords != null)
                {
                    foreach (DalSic.SysRelEstadoMotivoNI item in colSysRelEstadoMotivoNIRecords)
                    {
                        if (item.IdMotivoNI != IdMotivoNI)
                        {
                            item.IdMotivoNI = IdMotivoNI;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysPacienteRecords != null)
                {
                    colSysPacienteRecords.SaveAll();
               }
		
                if (colSysRelEstadoMotivoNIRecords != null)
                {
                    colSysRelEstadoMotivoNIRecords.SaveAll();
               }
		}
        #endregion
	}
}
