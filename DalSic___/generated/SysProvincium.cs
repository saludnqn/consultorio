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
	/// Strongly-typed collection for the SysProvincium class.
	/// </summary>
    [Serializable]
	public partial class SysProvinciumCollection : ActiveList<SysProvincium, SysProvinciumCollection>
	{	   
		public SysProvinciumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysProvinciumCollection</returns>
		public SysProvinciumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysProvincium o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Provincia table.
	/// </summary>
	[Serializable]
	public partial class SysProvincium : ActiveRecord<SysProvincium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysProvincium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysProvincium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysProvincium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysProvincium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Provincia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProvincia = new TableSchema.TableColumn(schema);
				colvarIdProvincia.ColumnName = "idProvincia";
				colvarIdProvincia.DataType = DbType.Int32;
				colvarIdProvincia.MaxLength = 0;
				colvarIdProvincia.AutoIncrement = true;
				colvarIdProvincia.IsNullable = false;
				colvarIdProvincia.IsPrimaryKey = true;
				colvarIdProvincia.IsForeignKey = false;
				colvarIdProvincia.IsReadOnly = false;
				colvarIdProvincia.DefaultSetting = @"";
				colvarIdProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProvincia);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdPais = new TableSchema.TableColumn(schema);
				colvarIdPais.ColumnName = "idPais";
				colvarIdPais.DataType = DbType.Int32;
				colvarIdPais.MaxLength = 0;
				colvarIdPais.AutoIncrement = false;
				colvarIdPais.IsNullable = false;
				colvarIdPais.IsPrimaryKey = false;
				colvarIdPais.IsForeignKey = false;
				colvarIdPais.IsReadOnly = false;
				colvarIdPais.DefaultSetting = @"";
				colvarIdPais.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPais);
				
				TableSchema.TableColumn colvarCodigoINDEC = new TableSchema.TableColumn(schema);
				colvarCodigoINDEC.ColumnName = "codigoINDEC";
				colvarCodigoINDEC.DataType = DbType.String;
				colvarCodigoINDEC.MaxLength = 100;
				colvarCodigoINDEC.AutoIncrement = false;
				colvarCodigoINDEC.IsNullable = true;
				colvarCodigoINDEC.IsPrimaryKey = false;
				colvarCodigoINDEC.IsForeignKey = false;
				colvarCodigoINDEC.IsReadOnly = false;
				colvarCodigoINDEC.DefaultSetting = @"";
				colvarCodigoINDEC.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoINDEC);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Provincia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProvincia")]
		[Bindable(true)]
		public int IdProvincia 
		{
			get { return GetColumnValue<int>(Columns.IdProvincia); }
			set { SetColumnValue(Columns.IdProvincia, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdPais")]
		[Bindable(true)]
		public int IdPais 
		{
			get { return GetColumnValue<int>(Columns.IdPais); }
			set { SetColumnValue(Columns.IdPais, value); }
		}
		  
		[XmlAttribute("CodigoINDEC")]
		[Bindable(true)]
		public string CodigoINDEC 
		{
			get { return GetColumnValue<string>(Columns.CodigoINDEC); }
			set { SetColumnValue(Columns.CodigoINDEC, value); }
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
					colSysParentescoRecords = new DalSic.SysParentescoCollection().Where(SysParentesco.Columns.IdProvincia, IdProvincia).Load();
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
		        colSysParentescoRecords[e.NewIndex].IdProvincia = IdProvincia;
		    }
		}
				
		private DalSic.SysPacienteCollection colSysPacienteRecords;
		public DalSic.SysPacienteCollection SysPacienteRecords
		{
			get
			{
				if(colSysPacienteRecords == null)
				{
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdProvincia, IdProvincia).Load();
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
		        colSysPacienteRecords[e.NewIndex].IdProvincia = IdProvincia;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdPais,string varCodigoINDEC)
		{
			SysProvincium item = new SysProvincium();
			
			item.Nombre = varNombre;
			
			item.IdPais = varIdPais;
			
			item.CodigoINDEC = varCodigoINDEC;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdProvincia,string varNombre,int varIdPais,string varCodigoINDEC)
		{
			SysProvincium item = new SysProvincium();
			
				item.IdProvincia = varIdProvincia;
			
				item.Nombre = varNombre;
			
				item.IdPais = varIdPais;
			
				item.CodigoINDEC = varCodigoINDEC;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProvinciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPaisColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoINDECColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProvincia = @"idProvincia";
			 public static string Nombre = @"nombre";
			 public static string IdPais = @"idPais";
			 public static string CodigoINDEC = @"codigoINDEC";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysParentescoRecords != null)
                {
                    foreach (DalSic.SysParentesco item in colSysParentescoRecords)
                    {
                        if (item.IdProvincia != IdProvincia)
                        {
                            item.IdProvincia = IdProvincia;
                        }
                    }
               }
		
                if (colSysPacienteRecords != null)
                {
                    foreach (DalSic.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdProvincia != IdProvincia)
                        {
                            item.IdProvincia = IdProvincia;
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
		
                if (colSysPacienteRecords != null)
                {
                    colSysPacienteRecords.SaveAll();
               }
		}
        #endregion
	}
}
