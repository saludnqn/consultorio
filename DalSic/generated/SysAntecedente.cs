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
	/// Strongly-typed collection for the SysAntecedente class.
	/// </summary>
    [Serializable]
	public partial class SysAntecedenteCollection : ActiveList<SysAntecedente, SysAntecedenteCollection>
	{	   
		public SysAntecedenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysAntecedenteCollection</returns>
		public SysAntecedenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysAntecedente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Antecedente table.
	/// </summary>
	[Serializable]
	public partial class SysAntecedente : ActiveRecord<SysAntecedente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysAntecedente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysAntecedente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysAntecedente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysAntecedente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Antecedente", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAntecedente = new TableSchema.TableColumn(schema);
				colvarIdAntecedente.ColumnName = "idAntecedente";
				colvarIdAntecedente.DataType = DbType.Int32;
				colvarIdAntecedente.MaxLength = 0;
				colvarIdAntecedente.AutoIncrement = true;
				colvarIdAntecedente.IsNullable = false;
				colvarIdAntecedente.IsPrimaryKey = true;
				colvarIdAntecedente.IsForeignKey = false;
				colvarIdAntecedente.IsReadOnly = false;
				colvarIdAntecedente.DefaultSetting = @"";
				colvarIdAntecedente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAntecedente);
				
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
				
				TableSchema.TableColumn colvarIdTipoAntecedente = new TableSchema.TableColumn(schema);
				colvarIdTipoAntecedente.ColumnName = "idTipoAntecedente";
				colvarIdTipoAntecedente.DataType = DbType.Int32;
				colvarIdTipoAntecedente.MaxLength = 0;
				colvarIdTipoAntecedente.AutoIncrement = false;
				colvarIdTipoAntecedente.IsNullable = true;
				colvarIdTipoAntecedente.IsPrimaryKey = false;
				colvarIdTipoAntecedente.IsForeignKey = true;
				colvarIdTipoAntecedente.IsReadOnly = false;
				colvarIdTipoAntecedente.DefaultSetting = @"";
				
					colvarIdTipoAntecedente.ForeignKeyTableName = "Sys_TipoAntecedente";
				schema.Columns.Add(colvarIdTipoAntecedente);
				
				TableSchema.TableColumn colvarGrupo = new TableSchema.TableColumn(schema);
				colvarGrupo.ColumnName = "grupo";
				colvarGrupo.DataType = DbType.Int32;
				colvarGrupo.MaxLength = 0;
				colvarGrupo.AutoIncrement = false;
				colvarGrupo.IsNullable = false;
				colvarGrupo.IsPrimaryKey = false;
				colvarGrupo.IsForeignKey = false;
				colvarGrupo.IsReadOnly = false;
				
						colvarGrupo.DefaultSetting = @"((0))";
				colvarGrupo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupo);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_Antecedente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAntecedente")]
		[Bindable(true)]
		public int IdAntecedente 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedente); }
			set { SetColumnValue(Columns.IdAntecedente, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdTipoAntecedente")]
		[Bindable(true)]
		public int? IdTipoAntecedente 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoAntecedente); }
			set { SetColumnValue(Columns.IdTipoAntecedente, value); }
		}
		  
		[XmlAttribute("Grupo")]
		[Bindable(true)]
		public int Grupo 
		{
			get { return GetColumnValue<int>(Columns.Grupo); }
			set { SetColumnValue(Columns.Grupo, value); }
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
        
				
		private DalSic.SysRelAntecedentePacienteCollection colSysRelAntecedentePacienteRecords;
		public DalSic.SysRelAntecedentePacienteCollection SysRelAntecedentePacienteRecords
		{
			get
			{
				if(colSysRelAntecedentePacienteRecords == null)
				{
					colSysRelAntecedentePacienteRecords = new DalSic.SysRelAntecedentePacienteCollection().Where(SysRelAntecedentePaciente.Columns.IdAntecedente, IdAntecedente).Load();
					colSysRelAntecedentePacienteRecords.ListChanged += new ListChangedEventHandler(colSysRelAntecedentePacienteRecords_ListChanged);
				}
				return colSysRelAntecedentePacienteRecords;			
			}
			set 
			{ 
					colSysRelAntecedentePacienteRecords = value; 
					colSysRelAntecedentePacienteRecords.ListChanged += new ListChangedEventHandler(colSysRelAntecedentePacienteRecords_ListChanged);
			}
		}
		
		void colSysRelAntecedentePacienteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelAntecedentePacienteRecords[e.NewIndex].IdAntecedente = IdAntecedente;
		    }
		}
				
		private DalSic.SysParentescoCollection colSysParentescoRecords;
		public DalSic.SysParentescoCollection SysParentescoRecords
		{
			get
			{
				if(colSysParentescoRecords == null)
				{
					colSysParentescoRecords = new DalSic.SysParentescoCollection().Where(SysParentesco.Columns.IdAntecedente, IdAntecedente).Load();
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
		        colSysParentescoRecords[e.NewIndex].IdAntecedente = IdAntecedente;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysTipoAntecedente ActiveRecord object related to this SysAntecedente
		/// 
		/// </summary>
		public DalSic.SysTipoAntecedente SysTipoAntecedente
		{
			get { return DalSic.SysTipoAntecedente.FetchByID(this.IdTipoAntecedente); }
			set { SetColumnValue("idTipoAntecedente", value.IdTipoAntecedente); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int? varIdTipoAntecedente,int varGrupo,bool varActivo)
		{
			SysAntecedente item = new SysAntecedente();
			
			item.Nombre = varNombre;
			
			item.IdTipoAntecedente = varIdTipoAntecedente;
			
			item.Grupo = varGrupo;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAntecedente,string varNombre,int? varIdTipoAntecedente,int varGrupo,bool varActivo)
		{
			SysAntecedente item = new SysAntecedente();
			
				item.IdAntecedente = varIdAntecedente;
			
				item.Nombre = varNombre;
			
				item.IdTipoAntecedente = varIdTipoAntecedente;
			
				item.Grupo = varGrupo;
			
				item.Activo = varActivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAntecedenteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoAntecedenteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoColumn
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
			 public static string IdAntecedente = @"idAntecedente";
			 public static string Nombre = @"nombre";
			 public static string IdTipoAntecedente = @"idTipoAntecedente";
			 public static string Grupo = @"grupo";
			 public static string Activo = @"activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysRelAntecedentePacienteRecords != null)
                {
                    foreach (DalSic.SysRelAntecedentePaciente item in colSysRelAntecedentePacienteRecords)
                    {
                        if (item.IdAntecedente != IdAntecedente)
                        {
                            item.IdAntecedente = IdAntecedente;
                        }
                    }
               }
		
                if (colSysParentescoRecords != null)
                {
                    foreach (DalSic.SysParentesco item in colSysParentescoRecords)
                    {
                        if (item.IdAntecedente != IdAntecedente)
                        {
                            item.IdAntecedente = IdAntecedente;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysRelAntecedentePacienteRecords != null)
                {
                    colSysRelAntecedentePacienteRecords.SaveAll();
               }
		
                if (colSysParentescoRecords != null)
                {
                    colSysParentescoRecords.SaveAll();
               }
		}
        #endregion
	}
}
