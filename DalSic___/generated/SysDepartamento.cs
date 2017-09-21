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
	/// Strongly-typed collection for the SysDepartamento class.
	/// </summary>
    [Serializable]
	public partial class SysDepartamentoCollection : ActiveList<SysDepartamento, SysDepartamentoCollection>
	{	   
		public SysDepartamentoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysDepartamentoCollection</returns>
		public SysDepartamentoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysDepartamento o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Departamento table.
	/// </summary>
	[Serializable]
	public partial class SysDepartamento : ActiveRecord<SysDepartamento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysDepartamento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysDepartamento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysDepartamento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysDepartamento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Departamento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDepartamento = new TableSchema.TableColumn(schema);
				colvarIdDepartamento.ColumnName = "idDepartamento";
				colvarIdDepartamento.DataType = DbType.Int32;
				colvarIdDepartamento.MaxLength = 0;
				colvarIdDepartamento.AutoIncrement = true;
				colvarIdDepartamento.IsNullable = false;
				colvarIdDepartamento.IsPrimaryKey = true;
				colvarIdDepartamento.IsForeignKey = false;
				colvarIdDepartamento.IsReadOnly = false;
				colvarIdDepartamento.DefaultSetting = @"";
				colvarIdDepartamento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDepartamento);
				
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
				
				TableSchema.TableColumn colvarIdProvincia = new TableSchema.TableColumn(schema);
				colvarIdProvincia.ColumnName = "idProvincia";
				colvarIdProvincia.DataType = DbType.Int32;
				colvarIdProvincia.MaxLength = 0;
				colvarIdProvincia.AutoIncrement = false;
				colvarIdProvincia.IsNullable = true;
				colvarIdProvincia.IsPrimaryKey = false;
				colvarIdProvincia.IsForeignKey = false;
				colvarIdProvincia.IsReadOnly = false;
				
						colvarIdProvincia.DefaultSetting = @"((0))";
				colvarIdProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProvincia);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_Departamento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDepartamento")]
		[Bindable(true)]
		public int IdDepartamento 
		{
			get { return GetColumnValue<int>(Columns.IdDepartamento); }
			set { SetColumnValue(Columns.IdDepartamento, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdProvincia")]
		[Bindable(true)]
		public int? IdProvincia 
		{
			get { return GetColumnValue<int?>(Columns.IdProvincia); }
			set { SetColumnValue(Columns.IdProvincia, value); }
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
        
				
		private DalSic.SysLocalidadCollection colSysLocalidadRecords;
		public DalSic.SysLocalidadCollection SysLocalidadRecords
		{
			get
			{
				if(colSysLocalidadRecords == null)
				{
					colSysLocalidadRecords = new DalSic.SysLocalidadCollection().Where(SysLocalidad.Columns.IdDepartamento, IdDepartamento).Load();
					colSysLocalidadRecords.ListChanged += new ListChangedEventHandler(colSysLocalidadRecords_ListChanged);
				}
				return colSysLocalidadRecords;			
			}
			set 
			{ 
					colSysLocalidadRecords = value; 
					colSysLocalidadRecords.ListChanged += new ListChangedEventHandler(colSysLocalidadRecords_ListChanged);
			}
		}
		
		void colSysLocalidadRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysLocalidadRecords[e.NewIndex].IdDepartamento = IdDepartamento;
		    }
		}
				
		private DalSic.SysPacienteCollection colSysPacienteRecords;
		public DalSic.SysPacienteCollection SysPacienteRecords
		{
			get
			{
				if(colSysPacienteRecords == null)
				{
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdDepartamento, IdDepartamento).Load();
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
		        colSysPacienteRecords[e.NewIndex].IdDepartamento = IdDepartamento;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int? varIdProvincia,string varCodigoINDEC)
		{
			SysDepartamento item = new SysDepartamento();
			
			item.Nombre = varNombre;
			
			item.IdProvincia = varIdProvincia;
			
			item.CodigoINDEC = varCodigoINDEC;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDepartamento,string varNombre,int? varIdProvincia,string varCodigoINDEC)
		{
			SysDepartamento item = new SysDepartamento();
			
				item.IdDepartamento = varIdDepartamento;
			
				item.Nombre = varNombre;
			
				item.IdProvincia = varIdProvincia;
			
				item.CodigoINDEC = varCodigoINDEC;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDepartamentoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProvinciaColumn
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
			 public static string IdDepartamento = @"idDepartamento";
			 public static string Nombre = @"nombre";
			 public static string IdProvincia = @"idProvincia";
			 public static string CodigoINDEC = @"codigoINDEC";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysLocalidadRecords != null)
                {
                    foreach (DalSic.SysLocalidad item in colSysLocalidadRecords)
                    {
                        if (item.IdDepartamento != IdDepartamento)
                        {
                            item.IdDepartamento = IdDepartamento;
                        }
                    }
               }
		
                if (colSysPacienteRecords != null)
                {
                    foreach (DalSic.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdDepartamento != IdDepartamento)
                        {
                            item.IdDepartamento = IdDepartamento;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysLocalidadRecords != null)
                {
                    colSysLocalidadRecords.SaveAll();
               }
		
                if (colSysPacienteRecords != null)
                {
                    colSysPacienteRecords.SaveAll();
               }
		}
        #endregion
	}
}
