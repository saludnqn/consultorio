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
	/// Strongly-typed collection for the ConLugarActividadGrupal class.
	/// </summary>
    [Serializable]
	public partial class ConLugarActividadGrupalCollection : ActiveList<ConLugarActividadGrupal, ConLugarActividadGrupalCollection>
	{	   
		public ConLugarActividadGrupalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConLugarActividadGrupalCollection</returns>
		public ConLugarActividadGrupalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConLugarActividadGrupal o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_LugarActividadGrupal table.
	/// </summary>
	[Serializable]
	public partial class ConLugarActividadGrupal : ActiveRecord<ConLugarActividadGrupal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConLugarActividadGrupal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConLugarActividadGrupal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConLugarActividadGrupal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConLugarActividadGrupal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_LugarActividadGrupal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLugarActividadGrupal = new TableSchema.TableColumn(schema);
				colvarIdLugarActividadGrupal.ColumnName = "idLugarActividadGrupal";
				colvarIdLugarActividadGrupal.DataType = DbType.Int32;
				colvarIdLugarActividadGrupal.MaxLength = 0;
				colvarIdLugarActividadGrupal.AutoIncrement = true;
				colvarIdLugarActividadGrupal.IsNullable = false;
				colvarIdLugarActividadGrupal.IsPrimaryKey = true;
				colvarIdLugarActividadGrupal.IsForeignKey = false;
				colvarIdLugarActividadGrupal.IsReadOnly = false;
				colvarIdLugarActividadGrupal.DefaultSetting = @"";
				colvarIdLugarActividadGrupal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLugarActividadGrupal);
				
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
				DataService.Providers["sicProvider"].AddSchema("CON_LugarActividadGrupal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLugarActividadGrupal")]
		[Bindable(true)]
		public int IdLugarActividadGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdLugarActividadGrupal); }
			set { SetColumnValue(Columns.IdLugarActividadGrupal, value); }
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
					colConAgendaGrupalRecords = new DalSic.ConAgendaGrupalCollection().Where(ConAgendaGrupal.Columns.IdLugarActividadGrupal, IdLugarActividadGrupal).Load();
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
		        colConAgendaGrupalRecords[e.NewIndex].IdLugarActividadGrupal = IdLugarActividadGrupal;
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
			ConLugarActividadGrupal item = new ConLugarActividadGrupal();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLugarActividadGrupal,string varNombre)
		{
			ConLugarActividadGrupal item = new ConLugarActividadGrupal();
			
				item.IdLugarActividadGrupal = varIdLugarActividadGrupal;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLugarActividadGrupalColumn
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
			 public static string IdLugarActividadGrupal = @"idLugarActividadGrupal";
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
                        if (item.IdLugarActividadGrupal != IdLugarActividadGrupal)
                        {
                            item.IdLugarActividadGrupal = IdLugarActividadGrupal;
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
