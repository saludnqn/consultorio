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
	/// Strongly-typed collection for the SysEstado class.
	/// </summary>
    [Serializable]
	public partial class SysEstadoCollection : ActiveList<SysEstado, SysEstadoCollection>
	{	   
		public SysEstadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysEstadoCollection</returns>
		public SysEstadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysEstado o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Estado table.
	/// </summary>
	[Serializable]
	public partial class SysEstado : ActiveRecord<SysEstado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysEstado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysEstado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysEstado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysEstado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Estado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstado = new TableSchema.TableColumn(schema);
				colvarIdEstado.ColumnName = "idEstado";
				colvarIdEstado.DataType = DbType.Int32;
				colvarIdEstado.MaxLength = 0;
				colvarIdEstado.AutoIncrement = true;
				colvarIdEstado.IsNullable = false;
				colvarIdEstado.IsPrimaryKey = true;
				colvarIdEstado.IsForeignKey = false;
				colvarIdEstado.IsReadOnly = false;
				colvarIdEstado.DefaultSetting = @"";
				colvarIdEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstado);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_Estado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstado")]
		[Bindable(true)]
		public int IdEstado 
		{
			get { return GetColumnValue<int>(Columns.IdEstado); }
			set { SetColumnValue(Columns.IdEstado, value); }
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
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdEstado, IdEstado).Load();
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
		        colSysPacienteRecords[e.NewIndex].IdEstado = IdEstado;
		    }
		}
				
		private DalSic.SysRelEstadoMotivoNICollection colSysRelEstadoMotivoNIRecords;
		public DalSic.SysRelEstadoMotivoNICollection SysRelEstadoMotivoNIRecords
		{
			get
			{
				if(colSysRelEstadoMotivoNIRecords == null)
				{
					colSysRelEstadoMotivoNIRecords = new DalSic.SysRelEstadoMotivoNICollection().Where(SysRelEstadoMotivoNI.Columns.IdEstado, IdEstado).Load();
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
		        colSysRelEstadoMotivoNIRecords[e.NewIndex].IdEstado = IdEstado;
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
			SysEstado item = new SysEstado();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstado,string varNombre)
		{
			SysEstado item = new SysEstado();
			
				item.IdEstado = varIdEstado;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstadoColumn
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
			 public static string IdEstado = @"idEstado";
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
                        if (item.IdEstado != IdEstado)
                        {
                            item.IdEstado = IdEstado;
                        }
                    }
               }
		
                if (colSysRelEstadoMotivoNIRecords != null)
                {
                    foreach (DalSic.SysRelEstadoMotivoNI item in colSysRelEstadoMotivoNIRecords)
                    {
                        if (item.IdEstado != IdEstado)
                        {
                            item.IdEstado = IdEstado;
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
