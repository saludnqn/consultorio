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
	/// Strongly-typed collection for the SysEspecialidad class.
	/// </summary>
    [Serializable]
	public partial class SysEspecialidadCollection : ActiveList<SysEspecialidad, SysEspecialidadCollection>
	{	   
		public SysEspecialidadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysEspecialidadCollection</returns>
		public SysEspecialidadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysEspecialidad o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Especialidad table.
	/// </summary>
	[Serializable]
	public partial class SysEspecialidad : ActiveRecord<SysEspecialidad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysEspecialidad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysEspecialidad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysEspecialidad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysEspecialidad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Especialidad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = true;
				colvarIdEspecialidad.IsNullable = false;
				colvarIdEspecialidad.IsPrimaryKey = true;
				colvarIdEspecialidad.IsForeignKey = false;
				colvarIdEspecialidad.IsReadOnly = false;
				colvarIdEspecialidad.DefaultSetting = @"";
				colvarIdEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEspecialidad);
				
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
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.Int32;
				colvarCodigo.MaxLength = 0;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				
						colvarCodigo.DefaultSetting = @"((0))";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarBackColor = new TableSchema.TableColumn(schema);
				colvarBackColor.ColumnName = "backColor";
				colvarBackColor.DataType = DbType.String;
				colvarBackColor.MaxLength = 50;
				colvarBackColor.AutoIncrement = false;
				colvarBackColor.IsNullable = false;
				colvarBackColor.IsPrimaryKey = false;
				colvarBackColor.IsForeignKey = false;
				colvarBackColor.IsReadOnly = false;
				
						colvarBackColor.DefaultSetting = @"('')";
				colvarBackColor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBackColor);
				
				TableSchema.TableColumn colvarForeColor = new TableSchema.TableColumn(schema);
				colvarForeColor.ColumnName = "foreColor";
				colvarForeColor.DataType = DbType.String;
				colvarForeColor.MaxLength = 50;
				colvarForeColor.AutoIncrement = false;
				colvarForeColor.IsNullable = false;
				colvarForeColor.IsPrimaryKey = false;
				colvarForeColor.IsForeignKey = false;
				colvarForeColor.IsReadOnly = false;
				
						colvarForeColor.DefaultSetting = @"('')";
				colvarForeColor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarForeColor);
				
				TableSchema.TableColumn colvarCodigoNacion = new TableSchema.TableColumn(schema);
				colvarCodigoNacion.ColumnName = "codigoNacion";
				colvarCodigoNacion.DataType = DbType.Int32;
				colvarCodigoNacion.MaxLength = 0;
				colvarCodigoNacion.AutoIncrement = false;
				colvarCodigoNacion.IsNullable = false;
				colvarCodigoNacion.IsPrimaryKey = false;
				colvarCodigoNacion.IsForeignKey = false;
				colvarCodigoNacion.IsReadOnly = false;
				
						colvarCodigoNacion.DefaultSetting = @"((0))";
				colvarCodigoNacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoNacion);
				
				TableSchema.TableColumn colvarUnidadOperativa = new TableSchema.TableColumn(schema);
				colvarUnidadOperativa.ColumnName = "unidadOperativa";
				colvarUnidadOperativa.DataType = DbType.AnsiString;
				colvarUnidadOperativa.MaxLength = 5;
				colvarUnidadOperativa.AutoIncrement = false;
				colvarUnidadOperativa.IsNullable = true;
				colvarUnidadOperativa.IsPrimaryKey = false;
				colvarUnidadOperativa.IsForeignKey = false;
				colvarUnidadOperativa.IsReadOnly = false;
				colvarUnidadOperativa.DefaultSetting = @"";
				colvarUnidadOperativa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadOperativa);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Especialidad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int IdEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public int Codigo 
		{
			get { return GetColumnValue<int>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("BackColor")]
		[Bindable(true)]
		public string BackColor 
		{
			get { return GetColumnValue<string>(Columns.BackColor); }
			set { SetColumnValue(Columns.BackColor, value); }
		}
		  
		[XmlAttribute("ForeColor")]
		[Bindable(true)]
		public string ForeColor 
		{
			get { return GetColumnValue<string>(Columns.ForeColor); }
			set { SetColumnValue(Columns.ForeColor, value); }
		}
		  
		[XmlAttribute("CodigoNacion")]
		[Bindable(true)]
		public int CodigoNacion 
		{
			get { return GetColumnValue<int>(Columns.CodigoNacion); }
			set { SetColumnValue(Columns.CodigoNacion, value); }
		}
		  
		[XmlAttribute("UnidadOperativa")]
		[Bindable(true)]
		public string UnidadOperativa 
		{
			get { return GetColumnValue<string>(Columns.UnidadOperativa); }
			set { SetColumnValue(Columns.UnidadOperativa, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprIntervencionProfesionalCollection colAprIntervencionProfesionalRecords;
		public DalSic.AprIntervencionProfesionalCollection AprIntervencionProfesionalRecords
		{
			get
			{
				if(colAprIntervencionProfesionalRecords == null)
				{
					colAprIntervencionProfesionalRecords = new DalSic.AprIntervencionProfesionalCollection().Where(AprIntervencionProfesional.Columns.IdEspecialidad, IdEspecialidad).Load();
					colAprIntervencionProfesionalRecords.ListChanged += new ListChangedEventHandler(colAprIntervencionProfesionalRecords_ListChanged);
				}
				return colAprIntervencionProfesionalRecords;			
			}
			set 
			{ 
					colAprIntervencionProfesionalRecords = value; 
					colAprIntervencionProfesionalRecords.ListChanged += new ListChangedEventHandler(colAprIntervencionProfesionalRecords_ListChanged);
			}
		}
		
		void colAprIntervencionProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprIntervencionProfesionalRecords[e.NewIndex].IdEspecialidad = IdEspecialidad;
		    }
		}
				
		private DalSic.SysRelEspecialidadEfectorCollection colSysRelEspecialidadEfectorRecords;
		public DalSic.SysRelEspecialidadEfectorCollection SysRelEspecialidadEfectorRecords
		{
			get
			{
				if(colSysRelEspecialidadEfectorRecords == null)
				{
					colSysRelEspecialidadEfectorRecords = new DalSic.SysRelEspecialidadEfectorCollection().Where(SysRelEspecialidadEfector.Columns.IdEspecialidad, IdEspecialidad).Load();
					colSysRelEspecialidadEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelEspecialidadEfectorRecords_ListChanged);
				}
				return colSysRelEspecialidadEfectorRecords;			
			}
			set 
			{ 
					colSysRelEspecialidadEfectorRecords = value; 
					colSysRelEspecialidadEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelEspecialidadEfectorRecords_ListChanged);
			}
		}
		
		void colSysRelEspecialidadEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelEspecialidadEfectorRecords[e.NewIndex].IdEspecialidad = IdEspecialidad;
		    }
		}
				
		private DalSic.ConConsultumCollection colConConsulta;
		public DalSic.ConConsultumCollection ConConsulta
		{
			get
			{
				if(colConConsulta == null)
				{
					colConConsulta = new DalSic.ConConsultumCollection().Where(ConConsultum.Columns.IdEspecialidad, IdEspecialidad).Load();
					colConConsulta.ListChanged += new ListChangedEventHandler(colConConsulta_ListChanged);
				}
				return colConConsulta;			
			}
			set 
			{ 
					colConConsulta = value; 
					colConConsulta.ListChanged += new ListChangedEventHandler(colConConsulta_ListChanged);
			}
		}
		
		void colConConsulta_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsulta[e.NewIndex].IdEspecialidad = IdEspecialidad;
		    }
		}
				
		private DalSic.ConAgendaCollection colConAgendaRecords;
		public DalSic.ConAgendaCollection ConAgendaRecords
		{
			get
			{
				if(colConAgendaRecords == null)
				{
					colConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdEspecialidad, IdEspecialidad).Load();
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
		        colConAgendaRecords[e.NewIndex].IdEspecialidad = IdEspecialidad;
		    }
		}
				
		private DalSic.ConAgendaProfesionalCollection colConAgendaProfesionalRecords;
		public DalSic.ConAgendaProfesionalCollection ConAgendaProfesionalRecords
		{
			get
			{
				if(colConAgendaProfesionalRecords == null)
				{
					colConAgendaProfesionalRecords = new DalSic.ConAgendaProfesionalCollection().Where(ConAgendaProfesional.Columns.IdEspecialidad, IdEspecialidad).Load();
					colConAgendaProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaProfesionalRecords_ListChanged);
				}
				return colConAgendaProfesionalRecords;			
			}
			set 
			{ 
					colConAgendaProfesionalRecords = value; 
					colConAgendaProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaProfesionalRecords_ListChanged);
			}
		}
		
		void colConAgendaProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaProfesionalRecords[e.NewIndex].IdEspecialidad = IdEspecialidad;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varCodigo,string varBackColor,string varForeColor,int varCodigoNacion,string varUnidadOperativa)
		{
			SysEspecialidad item = new SysEspecialidad();
			
			item.Nombre = varNombre;
			
			item.Codigo = varCodigo;
			
			item.BackColor = varBackColor;
			
			item.ForeColor = varForeColor;
			
			item.CodigoNacion = varCodigoNacion;
			
			item.UnidadOperativa = varUnidadOperativa;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEspecialidad,string varNombre,int varCodigo,string varBackColor,string varForeColor,int varCodigoNacion,string varUnidadOperativa)
		{
			SysEspecialidad item = new SysEspecialidad();
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.Nombre = varNombre;
			
				item.Codigo = varCodigo;
			
				item.BackColor = varBackColor;
			
				item.ForeColor = varForeColor;
			
				item.CodigoNacion = varCodigoNacion;
			
				item.UnidadOperativa = varUnidadOperativa;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BackColorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ForeColorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoNacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadOperativaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string Nombre = @"nombre";
			 public static string Codigo = @"codigo";
			 public static string BackColor = @"backColor";
			 public static string ForeColor = @"foreColor";
			 public static string CodigoNacion = @"codigoNacion";
			 public static string UnidadOperativa = @"unidadOperativa";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprIntervencionProfesionalRecords != null)
                {
                    foreach (DalSic.AprIntervencionProfesional item in colAprIntervencionProfesionalRecords)
                    {
                        if (item.IdEspecialidad != IdEspecialidad)
                        {
                            item.IdEspecialidad = IdEspecialidad;
                        }
                    }
               }
		
                if (colSysRelEspecialidadEfectorRecords != null)
                {
                    foreach (DalSic.SysRelEspecialidadEfector item in colSysRelEspecialidadEfectorRecords)
                    {
                        if (item.IdEspecialidad != IdEspecialidad)
                        {
                            item.IdEspecialidad = IdEspecialidad;
                        }
                    }
               }
		
                if (colConConsulta != null)
                {
                    foreach (DalSic.ConConsultum item in colConConsulta)
                    {
                        if (item.IdEspecialidad != IdEspecialidad)
                        {
                            item.IdEspecialidad = IdEspecialidad;
                        }
                    }
               }
		
                if (colConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colConAgendaRecords)
                    {
                        if (item.IdEspecialidad != IdEspecialidad)
                        {
                            item.IdEspecialidad = IdEspecialidad;
                        }
                    }
               }
		
                if (colConAgendaProfesionalRecords != null)
                {
                    foreach (DalSic.ConAgendaProfesional item in colConAgendaProfesionalRecords)
                    {
                        if (item.IdEspecialidad != IdEspecialidad)
                        {
                            item.IdEspecialidad = IdEspecialidad;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprIntervencionProfesionalRecords != null)
                {
                    colAprIntervencionProfesionalRecords.SaveAll();
               }
		
                if (colSysRelEspecialidadEfectorRecords != null)
                {
                    colSysRelEspecialidadEfectorRecords.SaveAll();
               }
		
                if (colConConsulta != null)
                {
                    colConConsulta.SaveAll();
               }
		
                if (colConAgendaRecords != null)
                {
                    colConAgendaRecords.SaveAll();
               }
		
                if (colConAgendaProfesionalRecords != null)
                {
                    colConAgendaProfesionalRecords.SaveAll();
               }
		}
        #endregion
	}
}
