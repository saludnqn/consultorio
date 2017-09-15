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
	/// Strongly-typed collection for the SysServicio class.
	/// </summary>
    [Serializable]
	public partial class SysServicioCollection : ActiveList<SysServicio, SysServicioCollection>
	{	   
		public SysServicioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysServicioCollection</returns>
		public SysServicioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysServicio o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Servicio table.
	/// </summary>
	[Serializable]
	public partial class SysServicio : ActiveRecord<SysServicio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysServicio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysServicio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysServicio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysServicio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Servicio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "idServicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = true;
				colvarIdServicio.IsNullable = false;
				colvarIdServicio.IsPrimaryKey = true;
				colvarIdServicio.IsForeignKey = false;
				colvarIdServicio.IsReadOnly = false;
				colvarIdServicio.DefaultSetting = @"";
				colvarIdServicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdServicio);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarUnidadOperativa = new TableSchema.TableColumn(schema);
				colvarUnidadOperativa.ColumnName = "unidadOperativa";
				colvarUnidadOperativa.DataType = DbType.String;
				colvarUnidadOperativa.MaxLength = 10;
				colvarUnidadOperativa.AutoIncrement = false;
				colvarUnidadOperativa.IsNullable = false;
				colvarUnidadOperativa.IsPrimaryKey = false;
				colvarUnidadOperativa.IsForeignKey = false;
				colvarUnidadOperativa.IsReadOnly = false;
				
						colvarUnidadOperativa.DefaultSetting = @"('')";
				colvarUnidadOperativa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadOperativa);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Servicio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int IdServicio 
		{
			get { return GetColumnValue<int>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("UnidadOperativa")]
		[Bindable(true)]
		public string UnidadOperativa 
		{
			get { return GetColumnValue<string>(Columns.UnidadOperativa); }
			set { SetColumnValue(Columns.UnidadOperativa, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysRelServicioEfectorCollection colSysRelServicioEfectorRecords;
		public DalSic.SysRelServicioEfectorCollection SysRelServicioEfectorRecords
		{
			get
			{
				if(colSysRelServicioEfectorRecords == null)
				{
					colSysRelServicioEfectorRecords = new DalSic.SysRelServicioEfectorCollection().Where(SysRelServicioEfector.Columns.IdServicio, IdServicio).Load();
					colSysRelServicioEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelServicioEfectorRecords_ListChanged);
				}
				return colSysRelServicioEfectorRecords;			
			}
			set 
			{ 
					colSysRelServicioEfectorRecords = value; 
					colSysRelServicioEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelServicioEfectorRecords_ListChanged);
			}
		}
		
		void colSysRelServicioEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelServicioEfectorRecords[e.NewIndex].IdServicio = IdServicio;
		    }
		}
				
		private DalSic.ConAgendaCollection colConAgendaRecords;
		public DalSic.ConAgendaCollection ConAgendaRecords
		{
			get
			{
				if(colConAgendaRecords == null)
				{
					colConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdServicio, IdServicio).Load();
					colConAgendaRecords.ListChanged += new ListChangedEventHandler(colConAgendaRecords_ListChanged);
				}
				return colConAgendaRecords;			
			}
			set 
			{ 
					colConAgendaRecords = value; 
					colConAgendaRecords.ListChanged += new ListChangedEventHandler(colConAgendaRecords_ListChanged);
			}
		}
		
		void colConAgendaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaRecords[e.NewIndex].IdServicio = IdServicio;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varUnidadOperativa,bool varActivo)
		{
			SysServicio item = new SysServicio();
			
			item.Nombre = varNombre;
			
			item.UnidadOperativa = varUnidadOperativa;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdServicio,string varNombre,string varUnidadOperativa,bool varActivo)
		{
			SysServicio item = new SysServicio();
			
				item.IdServicio = varIdServicio;
			
				item.Nombre = varNombre;
			
				item.UnidadOperativa = varUnidadOperativa;
			
				item.Activo = varActivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadOperativaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdServicio = @"idServicio";
			 public static string Nombre = @"nombre";
			 public static string UnidadOperativa = @"unidadOperativa";
			 public static string Activo = @"activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysRelServicioEfectorRecords != null)
                {
                    foreach (DalSic.SysRelServicioEfector item in colSysRelServicioEfectorRecords)
                    {
                        if (item.IdServicio != IdServicio)
                        {
                            item.IdServicio = IdServicio;
                        }
                    }
               }
		
                if (colConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colConAgendaRecords)
                    {
                        if (item.IdServicio != IdServicio)
                        {
                            item.IdServicio = IdServicio;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysRelServicioEfectorRecords != null)
                {
                    colSysRelServicioEfectorRecords.SaveAll();
               }
		
                if (colConAgendaRecords != null)
                {
                    colConAgendaRecords.SaveAll();
               }
		}
        #endregion
	}
}
