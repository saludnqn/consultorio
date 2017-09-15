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
	/// Strongly-typed collection for the ConConsultorioTipo class.
	/// </summary>
    [Serializable]
	public partial class ConConsultorioTipoCollection : ActiveList<ConConsultorioTipo, ConConsultorioTipoCollection>
	{	   
		public ConConsultorioTipoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConConsultorioTipoCollection</returns>
		public ConConsultorioTipoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConConsultorioTipo o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_ConsultorioTipo table.
	/// </summary>
	[Serializable]
	public partial class ConConsultorioTipo : ActiveRecord<ConConsultorioTipo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConConsultorioTipo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConConsultorioTipo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConConsultorioTipo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConConsultorioTipo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_ConsultorioTipo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoConsultorio = new TableSchema.TableColumn(schema);
				colvarIdTipoConsultorio.ColumnName = "idTipoConsultorio";
				colvarIdTipoConsultorio.DataType = DbType.Int32;
				colvarIdTipoConsultorio.MaxLength = 0;
				colvarIdTipoConsultorio.AutoIncrement = true;
				colvarIdTipoConsultorio.IsNullable = false;
				colvarIdTipoConsultorio.IsPrimaryKey = true;
				colvarIdTipoConsultorio.IsForeignKey = false;
				colvarIdTipoConsultorio.IsReadOnly = false;
				colvarIdTipoConsultorio.DefaultSetting = @"";
				colvarIdTipoConsultorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoConsultorio);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((3))";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_ConsultorioTipo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoConsultorio")]
		[Bindable(true)]
		public int IdTipoConsultorio 
		{
			get { return GetColumnValue<int>(Columns.IdTipoConsultorio); }
			set { SetColumnValue(Columns.IdTipoConsultorio, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
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
        
				
		private DalSic.ConConsultorioCollection colConConsultorioRecords;
		public DalSic.ConConsultorioCollection ConConsultorioRecords
		{
			get
			{
				if(colConConsultorioRecords == null)
				{
					colConConsultorioRecords = new DalSic.ConConsultorioCollection().Where(ConConsultorio.Columns.IdTipoConsultorio, IdTipoConsultorio).Load();
					colConConsultorioRecords.ListChanged += new ListChangedEventHandler(colConConsultorioRecords_ListChanged);
				}
				return colConConsultorioRecords;			
			}
			set 
			{ 
					colConConsultorioRecords = value; 
					colConConsultorioRecords.ListChanged += new ListChangedEventHandler(colConConsultorioRecords_ListChanged);
			}
		}
		
		void colConConsultorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsultorioRecords[e.NewIndex].IdTipoConsultorio = IdTipoConsultorio;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this ConConsultorioTipo
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,string varNombre)
		{
			ConConsultorioTipo item = new ConConsultorioTipo();
			
			item.IdEfector = varIdEfector;
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoConsultorio,int varIdEfector,string varNombre)
		{
			ConConsultorioTipo item = new ConConsultorioTipo();
			
				item.IdTipoConsultorio = varIdTipoConsultorio;
			
				item.IdEfector = varIdEfector;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoConsultorioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoConsultorio = @"idTipoConsultorio";
			 public static string IdEfector = @"idEfector";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConConsultorioRecords != null)
                {
                    foreach (DalSic.ConConsultorio item in colConConsultorioRecords)
                    {
                        if (item.IdTipoConsultorio != IdTipoConsultorio)
                        {
                            item.IdTipoConsultorio = IdTipoConsultorio;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConConsultorioRecords != null)
                {
                    colConConsultorioRecords.SaveAll();
               }
		}
        #endregion
	}
}
