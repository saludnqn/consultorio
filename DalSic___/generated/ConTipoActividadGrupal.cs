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
	/// Strongly-typed collection for the ConTipoActividadGrupal class.
	/// </summary>
    [Serializable]
	public partial class ConTipoActividadGrupalCollection : ActiveList<ConTipoActividadGrupal, ConTipoActividadGrupalCollection>
	{	   
		public ConTipoActividadGrupalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTipoActividadGrupalCollection</returns>
		public ConTipoActividadGrupalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTipoActividadGrupal o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TipoActividadGrupal table.
	/// </summary>
	[Serializable]
	public partial class ConTipoActividadGrupal : ActiveRecord<ConTipoActividadGrupal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTipoActividadGrupal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTipoActividadGrupal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTipoActividadGrupal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTipoActividadGrupal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TipoActividadGrupal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoActividadGrupal = new TableSchema.TableColumn(schema);
				colvarIdTipoActividadGrupal.ColumnName = "idTipoActividadGrupal";
				colvarIdTipoActividadGrupal.DataType = DbType.Int32;
				colvarIdTipoActividadGrupal.MaxLength = 0;
				colvarIdTipoActividadGrupal.AutoIncrement = true;
				colvarIdTipoActividadGrupal.IsNullable = false;
				colvarIdTipoActividadGrupal.IsPrimaryKey = true;
				colvarIdTipoActividadGrupal.IsForeignKey = false;
				colvarIdTipoActividadGrupal.IsReadOnly = false;
				colvarIdTipoActividadGrupal.DefaultSetting = @"";
				colvarIdTipoActividadGrupal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoActividadGrupal);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 150;
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
				DataService.Providers["sicProvider"].AddSchema("CON_TipoActividadGrupal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoActividadGrupal")]
		[Bindable(true)]
		public int IdTipoActividadGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdTipoActividadGrupal); }
			set { SetColumnValue(Columns.IdTipoActividadGrupal, value); }
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
        
				
		private DalSic.ConAgendaGrupalCollection colConAgendaGrupalRecords;
		public DalSic.ConAgendaGrupalCollection ConAgendaGrupalRecords
		{
			get
			{
				if(colConAgendaGrupalRecords == null)
				{
					colConAgendaGrupalRecords = new DalSic.ConAgendaGrupalCollection().Where(ConAgendaGrupal.Columns.IdTipoActividadGrupal, IdTipoActividadGrupal).Load();
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
		        colConAgendaGrupalRecords[e.NewIndex].IdTipoActividadGrupal = IdTipoActividadGrupal;
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
			ConTipoActividadGrupal item = new ConTipoActividadGrupal();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoActividadGrupal,string varNombre)
		{
			ConTipoActividadGrupal item = new ConTipoActividadGrupal();
			
				item.IdTipoActividadGrupal = varIdTipoActividadGrupal;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoActividadGrupalColumn
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
			 public static string IdTipoActividadGrupal = @"idTipoActividadGrupal";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConAgendaGrupalRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupal item in colConAgendaGrupalRecords)
                    {
                        if (item.IdTipoActividadGrupal != IdTipoActividadGrupal)
                        {
                            item.IdTipoActividadGrupal = IdTipoActividadGrupal;
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
		}
        #endregion
	}
}
