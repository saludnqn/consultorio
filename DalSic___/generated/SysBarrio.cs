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
	/// Strongly-typed collection for the SysBarrio class.
	/// </summary>
    [Serializable]
	public partial class SysBarrioCollection : ActiveList<SysBarrio, SysBarrioCollection>
	{	   
		public SysBarrioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysBarrioCollection</returns>
		public SysBarrioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysBarrio o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Barrio table.
	/// </summary>
	[Serializable]
	public partial class SysBarrio : ActiveRecord<SysBarrio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysBarrio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysBarrio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysBarrio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysBarrio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Barrio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdBarrio = new TableSchema.TableColumn(schema);
				colvarIdBarrio.ColumnName = "idBarrio";
				colvarIdBarrio.DataType = DbType.Int32;
				colvarIdBarrio.MaxLength = 0;
				colvarIdBarrio.AutoIncrement = true;
				colvarIdBarrio.IsNullable = false;
				colvarIdBarrio.IsPrimaryKey = true;
				colvarIdBarrio.IsForeignKey = false;
				colvarIdBarrio.IsReadOnly = false;
				colvarIdBarrio.DefaultSetting = @"";
				colvarIdBarrio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBarrio);
				
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
				
				TableSchema.TableColumn colvarIdLocalidad = new TableSchema.TableColumn(schema);
				colvarIdLocalidad.ColumnName = "idLocalidad";
				colvarIdLocalidad.DataType = DbType.Int32;
				colvarIdLocalidad.MaxLength = 0;
				colvarIdLocalidad.AutoIncrement = false;
				colvarIdLocalidad.IsNullable = true;
				colvarIdLocalidad.IsPrimaryKey = false;
				colvarIdLocalidad.IsForeignKey = true;
				colvarIdLocalidad.IsReadOnly = false;
				colvarIdLocalidad.DefaultSetting = @"";
				
					colvarIdLocalidad.ForeignKeyTableName = "Sys_Localidad";
				schema.Columns.Add(colvarIdLocalidad);
				
				TableSchema.TableColumn colvarCodigoIndec = new TableSchema.TableColumn(schema);
				colvarCodigoIndec.ColumnName = "codigoIndec";
				colvarCodigoIndec.DataType = DbType.AnsiString;
				colvarCodigoIndec.MaxLength = 100;
				colvarCodigoIndec.AutoIncrement = false;
				colvarCodigoIndec.IsNullable = true;
				colvarCodigoIndec.IsPrimaryKey = false;
				colvarCodigoIndec.IsForeignKey = false;
				colvarCodigoIndec.IsReadOnly = false;
				colvarCodigoIndec.DefaultSetting = @"";
				colvarCodigoIndec.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoIndec);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Barrio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdBarrio")]
		[Bindable(true)]
		public int IdBarrio 
		{
			get { return GetColumnValue<int>(Columns.IdBarrio); }
			set { SetColumnValue(Columns.IdBarrio, value); }
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
		public int? IdLocalidad 
		{
			get { return GetColumnValue<int?>(Columns.IdLocalidad); }
			set { SetColumnValue(Columns.IdLocalidad, value); }
		}
		  
		[XmlAttribute("CodigoIndec")]
		[Bindable(true)]
		public string CodigoIndec 
		{
			get { return GetColumnValue<string>(Columns.CodigoIndec); }
			set { SetColumnValue(Columns.CodigoIndec, value); }
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
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdBarrio, IdBarrio).Load();
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
		        colSysPacienteRecords[e.NewIndex].IdBarrio = IdBarrio;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysLocalidad ActiveRecord object related to this SysBarrio
		/// 
		/// </summary>
		public DalSic.SysLocalidad SysLocalidad
		{
			get { return DalSic.SysLocalidad.FetchByID(this.IdLocalidad); }
			set { SetColumnValue("idLocalidad", value.IdLocalidad); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int? varIdLocalidad,string varCodigoIndec)
		{
			SysBarrio item = new SysBarrio();
			
			item.Nombre = varNombre;
			
			item.IdLocalidad = varIdLocalidad;
			
			item.CodigoIndec = varCodigoIndec;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdBarrio,string varNombre,int? varIdLocalidad,string varCodigoIndec)
		{
			SysBarrio item = new SysBarrio();
			
				item.IdBarrio = varIdBarrio;
			
				item.Nombre = varNombre;
			
				item.IdLocalidad = varIdLocalidad;
			
				item.CodigoIndec = varCodigoIndec;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdBarrioColumn
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
        
        
        
        public static TableSchema.TableColumn CodigoIndecColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdBarrio = @"idBarrio";
			 public static string Nombre = @"nombre";
			 public static string IdLocalidad = @"idLocalidad";
			 public static string CodigoIndec = @"codigoIndec";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysPacienteRecords != null)
                {
                    foreach (DalSic.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdBarrio != IdBarrio)
                        {
                            item.IdBarrio = IdBarrio;
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
		}
        #endregion
	}
}
