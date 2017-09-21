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
	/// Strongly-typed collection for the SysLocalidad class.
	/// </summary>
    [Serializable]
	public partial class SysLocalidadCollection : ActiveList<SysLocalidad, SysLocalidadCollection>
	{	   
		public SysLocalidadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysLocalidadCollection</returns>
		public SysLocalidadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysLocalidad o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Localidad table.
	/// </summary>
	[Serializable]
	public partial class SysLocalidad : ActiveRecord<SysLocalidad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysLocalidad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysLocalidad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysLocalidad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysLocalidad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Localidad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLocalidad = new TableSchema.TableColumn(schema);
				colvarIdLocalidad.ColumnName = "idLocalidad";
				colvarIdLocalidad.DataType = DbType.Int32;
				colvarIdLocalidad.MaxLength = 0;
				colvarIdLocalidad.AutoIncrement = true;
				colvarIdLocalidad.IsNullable = false;
				colvarIdLocalidad.IsPrimaryKey = true;
				colvarIdLocalidad.IsForeignKey = false;
				colvarIdLocalidad.IsReadOnly = false;
				colvarIdLocalidad.DefaultSetting = @"";
				colvarIdLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLocalidad);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarCodigoPostal = new TableSchema.TableColumn(schema);
				colvarCodigoPostal.ColumnName = "codigoPostal";
				colvarCodigoPostal.DataType = DbType.AnsiStringFixedLength;
				colvarCodigoPostal.MaxLength = 12;
				colvarCodigoPostal.AutoIncrement = false;
				colvarCodigoPostal.IsNullable = true;
				colvarCodigoPostal.IsPrimaryKey = false;
				colvarCodigoPostal.IsForeignKey = false;
				colvarCodigoPostal.IsReadOnly = false;
				
						colvarCodigoPostal.DefaultSetting = @"('')";
				colvarCodigoPostal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoPostal);
				
				TableSchema.TableColumn colvarIdDepartamento = new TableSchema.TableColumn(schema);
				colvarIdDepartamento.ColumnName = "idDepartamento";
				colvarIdDepartamento.DataType = DbType.Int32;
				colvarIdDepartamento.MaxLength = 0;
				colvarIdDepartamento.AutoIncrement = false;
				colvarIdDepartamento.IsNullable = true;
				colvarIdDepartamento.IsPrimaryKey = false;
				colvarIdDepartamento.IsForeignKey = true;
				colvarIdDepartamento.IsReadOnly = false;
				
						colvarIdDepartamento.DefaultSetting = @"((0))";
				
					colvarIdDepartamento.ForeignKeyTableName = "Sys_Departamento";
				schema.Columns.Add(colvarIdDepartamento);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_Localidad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLocalidad")]
		[Bindable(true)]
		public int IdLocalidad 
		{
			get { return GetColumnValue<int>(Columns.IdLocalidad); }
			set { SetColumnValue(Columns.IdLocalidad, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("CodigoPostal")]
		[Bindable(true)]
		public string CodigoPostal 
		{
			get { return GetColumnValue<string>(Columns.CodigoPostal); }
			set { SetColumnValue(Columns.CodigoPostal, value); }
		}
		  
		[XmlAttribute("IdDepartamento")]
		[Bindable(true)]
		public int? IdDepartamento 
		{
			get { return GetColumnValue<int?>(Columns.IdDepartamento); }
			set { SetColumnValue(Columns.IdDepartamento, value); }
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
        
				
		private DalSic.SysBarrioCollection colSysBarrioRecords;
		public DalSic.SysBarrioCollection SysBarrioRecords
		{
			get
			{
				if(colSysBarrioRecords == null)
				{
					colSysBarrioRecords = new DalSic.SysBarrioCollection().Where(SysBarrio.Columns.IdLocalidad, IdLocalidad).Load();
					colSysBarrioRecords.ListChanged += new ListChangedEventHandler(colSysBarrioRecords_ListChanged);
				}
				return colSysBarrioRecords;			
			}
			set 
			{ 
					colSysBarrioRecords = value; 
					colSysBarrioRecords.ListChanged += new ListChangedEventHandler(colSysBarrioRecords_ListChanged);
			}
		}
		
		void colSysBarrioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysBarrioRecords[e.NewIndex].IdLocalidad = IdLocalidad;
		    }
		}
				
		private DalSic.SysPacienteCollection colSysPacienteRecords;
		public DalSic.SysPacienteCollection SysPacienteRecords
		{
			get
			{
				if(colSysPacienteRecords == null)
				{
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdLocalidad, IdLocalidad).Load();
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
		        colSysPacienteRecords[e.NewIndex].IdLocalidad = IdLocalidad;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysDepartamento ActiveRecord object related to this SysLocalidad
		/// 
		/// </summary>
		public DalSic.SysDepartamento SysDepartamento
		{
			get { return DalSic.SysDepartamento.FetchByID(this.IdDepartamento); }
			set { SetColumnValue("idDepartamento", value.IdDepartamento); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varCodigoPostal,int? varIdDepartamento,string varCodigoINDEC)
		{
			SysLocalidad item = new SysLocalidad();
			
			item.Nombre = varNombre;
			
			item.CodigoPostal = varCodigoPostal;
			
			item.IdDepartamento = varIdDepartamento;
			
			item.CodigoINDEC = varCodigoINDEC;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLocalidad,string varNombre,string varCodigoPostal,int? varIdDepartamento,string varCodigoINDEC)
		{
			SysLocalidad item = new SysLocalidad();
			
				item.IdLocalidad = varIdLocalidad;
			
				item.Nombre = varNombre;
			
				item.CodigoPostal = varCodigoPostal;
			
				item.IdDepartamento = varIdDepartamento;
			
				item.CodigoINDEC = varCodigoINDEC;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLocalidadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoPostalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDepartamentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoINDECColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLocalidad = @"idLocalidad";
			 public static string Nombre = @"nombre";
			 public static string CodigoPostal = @"codigoPostal";
			 public static string IdDepartamento = @"idDepartamento";
			 public static string CodigoINDEC = @"codigoINDEC";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysBarrioRecords != null)
                {
                    foreach (DalSic.SysBarrio item in colSysBarrioRecords)
                    {
                        if (item.IdLocalidad != IdLocalidad)
                        {
                            item.IdLocalidad = IdLocalidad;
                        }
                    }
               }
		
                if (colSysPacienteRecords != null)
                {
                    foreach (DalSic.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdLocalidad != IdLocalidad)
                        {
                            item.IdLocalidad = IdLocalidad;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysBarrioRecords != null)
                {
                    colSysBarrioRecords.SaveAll();
               }
		
                if (colSysPacienteRecords != null)
                {
                    colSysPacienteRecords.SaveAll();
               }
		}
        #endregion
	}
}
