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
	/// Strongly-typed collection for the ConConsultorio class.
	/// </summary>
    [Serializable]
	public partial class ConConsultorioCollection : ActiveList<ConConsultorio, ConConsultorioCollection>
	{	   
		public ConConsultorioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConConsultorioCollection</returns>
		public ConConsultorioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConConsultorio o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_Consultorio table.
	/// </summary>
	[Serializable]
	public partial class ConConsultorio : ActiveRecord<ConConsultorio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConConsultorio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConConsultorio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConConsultorio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConConsultorio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_Consultorio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdConsultorio = new TableSchema.TableColumn(schema);
				colvarIdConsultorio.ColumnName = "idConsultorio";
				colvarIdConsultorio.DataType = DbType.Int32;
				colvarIdConsultorio.MaxLength = 0;
				colvarIdConsultorio.AutoIncrement = true;
				colvarIdConsultorio.IsNullable = false;
				colvarIdConsultorio.IsPrimaryKey = true;
				colvarIdConsultorio.IsForeignKey = false;
				colvarIdConsultorio.IsReadOnly = false;
				colvarIdConsultorio.DefaultSetting = @"";
				colvarIdConsultorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsultorio);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdTipoConsultorio = new TableSchema.TableColumn(schema);
				colvarIdTipoConsultorio.ColumnName = "idTipoConsultorio";
				colvarIdTipoConsultorio.DataType = DbType.Int32;
				colvarIdTipoConsultorio.MaxLength = 0;
				colvarIdTipoConsultorio.AutoIncrement = false;
				colvarIdTipoConsultorio.IsNullable = false;
				colvarIdTipoConsultorio.IsPrimaryKey = false;
				colvarIdTipoConsultorio.IsForeignKey = true;
				colvarIdTipoConsultorio.IsReadOnly = false;
				
						colvarIdTipoConsultorio.DefaultSetting = @"((0))";
				
					colvarIdTipoConsultorio.ForeignKeyTableName = "CON_ConsultorioTipo";
				schema.Columns.Add(colvarIdTipoConsultorio);
				
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
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "Activo";
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
				DataService.Providers["sicProvider"].AddSchema("CON_Consultorio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdConsultorio")]
		[Bindable(true)]
		public int IdConsultorio 
		{
			get { return GetColumnValue<int>(Columns.IdConsultorio); }
			set { SetColumnValue(Columns.IdConsultorio, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdTipoConsultorio")]
		[Bindable(true)]
		public int IdTipoConsultorio 
		{
			get { return GetColumnValue<int>(Columns.IdTipoConsultorio); }
			set { SetColumnValue(Columns.IdTipoConsultorio, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
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
        
				
		private DalSic.ConAgendaGrupalCollection colConAgendaGrupalRecords;
		public DalSic.ConAgendaGrupalCollection ConAgendaGrupalRecords
		{
			get
			{
				if(colConAgendaGrupalRecords == null)
				{
					colConAgendaGrupalRecords = new DalSic.ConAgendaGrupalCollection().Where(ConAgendaGrupal.Columns.IdConsultorio, IdConsultorio).Load();
					colConAgendaGrupalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalRecords_ListChanged);
				}
				return colConAgendaGrupalRecords;			
			}
			set 
			{ 
					colConAgendaGrupalRecords = value; 
					colConAgendaGrupalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalRecords[e.NewIndex].IdConsultorio = IdConsultorio;
		    }
		}
				
		private DalSic.ConAgendaCollection colConAgendaRecords;
		public DalSic.ConAgendaCollection ConAgendaRecords
		{
			get
			{
				if(colConAgendaRecords == null)
				{
					colConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdConsultorio, IdConsultorio).Load();
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
		        colConAgendaRecords[e.NewIndex].IdConsultorio = IdConsultorio;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConConsultorioTipo ActiveRecord object related to this ConConsultorio
		/// 
		/// </summary>
		public DalSic.ConConsultorioTipo ConConsultorioTipo
		{
			get { return DalSic.ConConsultorioTipo.FetchByID(this.IdTipoConsultorio); }
			set { SetColumnValue("idTipoConsultorio", value.IdTipoConsultorio); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdTipoConsultorio,string varNombre,bool varActivo)
		{
			ConConsultorio item = new ConConsultorio();
			
			item.IdEfector = varIdEfector;
			
			item.IdTipoConsultorio = varIdTipoConsultorio;
			
			item.Nombre = varNombre;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdConsultorio,int varIdEfector,int varIdTipoConsultorio,string varNombre,bool varActivo)
		{
			ConConsultorio item = new ConConsultorio();
			
				item.IdConsultorio = varIdConsultorio;
			
				item.IdEfector = varIdEfector;
			
				item.IdTipoConsultorio = varIdTipoConsultorio;
			
				item.Nombre = varNombre;
			
				item.Activo = varActivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdConsultorioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoConsultorioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdConsultorio = @"idConsultorio";
			 public static string IdEfector = @"idEfector";
			 public static string IdTipoConsultorio = @"idTipoConsultorio";
			 public static string Nombre = @"nombre";
			 public static string Activo = @"Activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConAgendaGrupalRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupal item in colConAgendaGrupalRecords)
                    {
                        if (item.IdConsultorio != IdConsultorio)
                        {
                            item.IdConsultorio = IdConsultorio;
                        }
                    }
               }
		
                if (colConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colConAgendaRecords)
                    {
                        if (item.IdConsultorio != IdConsultorio)
                        {
                            item.IdConsultorio = IdConsultorio;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConAgendaGrupalRecords != null)
                {
                    colConAgendaGrupalRecords.SaveAll();
               }
		
                if (colConAgendaRecords != null)
                {
                    colConAgendaRecords.SaveAll();
               }
		}
        #endregion
	}
}
