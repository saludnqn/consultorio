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
	/// Strongly-typed collection for the SysOrganismo class.
	/// </summary>
    [Serializable]
	public partial class SysOrganismoCollection : ActiveList<SysOrganismo, SysOrganismoCollection>
	{	   
		public SysOrganismoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysOrganismoCollection</returns>
		public SysOrganismoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysOrganismo o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Organismo table.
	/// </summary>
	[Serializable]
	public partial class SysOrganismo : ActiveRecord<SysOrganismo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysOrganismo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysOrganismo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysOrganismo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysOrganismo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Organismo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdOrganismo = new TableSchema.TableColumn(schema);
				colvarIdOrganismo.ColumnName = "idOrganismo";
				colvarIdOrganismo.DataType = DbType.Int32;
				colvarIdOrganismo.MaxLength = 0;
				colvarIdOrganismo.AutoIncrement = true;
				colvarIdOrganismo.IsNullable = false;
				colvarIdOrganismo.IsPrimaryKey = true;
				colvarIdOrganismo.IsForeignKey = false;
				colvarIdOrganismo.IsReadOnly = false;
				colvarIdOrganismo.DefaultSetting = @"";
				colvarIdOrganismo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdOrganismo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 100;
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
				DataService.Providers["sicProvider"].AddSchema("Sys_Organismo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdOrganismo")]
		[Bindable(true)]
		public int IdOrganismo 
		{
			get { return GetColumnValue<int>(Columns.IdOrganismo); }
			set { SetColumnValue(Columns.IdOrganismo, value); }
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
        
				
		private DalSic.ConAgendaGrupalOrganismoCollection colConAgendaGrupalOrganismoRecords;
		public DalSic.ConAgendaGrupalOrganismoCollection ConAgendaGrupalOrganismoRecords
		{
			get
			{
				if(colConAgendaGrupalOrganismoRecords == null)
				{
					colConAgendaGrupalOrganismoRecords = new DalSic.ConAgendaGrupalOrganismoCollection().Where(ConAgendaGrupalOrganismo.Columns.IdOrganismo, IdOrganismo).Load();
					colConAgendaGrupalOrganismoRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalOrganismoRecords_ListChanged);
				}
				return colConAgendaGrupalOrganismoRecords;			
			}
			set 
			{ 
					colConAgendaGrupalOrganismoRecords = value; 
					colConAgendaGrupalOrganismoRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalOrganismoRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalOrganismoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalOrganismoRecords[e.NewIndex].IdOrganismo = IdOrganismo;
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
			SysOrganismo item = new SysOrganismo();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdOrganismo,string varNombre)
		{
			SysOrganismo item = new SysOrganismo();
			
				item.IdOrganismo = varIdOrganismo;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdOrganismoColumn
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
			 public static string IdOrganismo = @"idOrganismo";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConAgendaGrupalOrganismoRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupalOrganismo item in colConAgendaGrupalOrganismoRecords)
                    {
                        if (item.IdOrganismo != IdOrganismo)
                        {
                            item.IdOrganismo = IdOrganismo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConAgendaGrupalOrganismoRecords != null)
                {
                    colConAgendaGrupalOrganismoRecords.SaveAll();
               }
		}
        #endregion
	}
}
