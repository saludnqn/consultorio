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
	/// Strongly-typed collection for the ConAgendaGrupalOrganismo class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaGrupalOrganismoCollection : ActiveList<ConAgendaGrupalOrganismo, ConAgendaGrupalOrganismoCollection>
	{	   
		public ConAgendaGrupalOrganismoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaGrupalOrganismoCollection</returns>
		public ConAgendaGrupalOrganismoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaGrupalOrganismo o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaGrupalOrganismo table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaGrupalOrganismo : ActiveRecord<ConAgendaGrupalOrganismo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaGrupalOrganismo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaGrupalOrganismo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaGrupalOrganismo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaGrupalOrganismo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaGrupalOrganismo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgendaGrupalOrganismo = new TableSchema.TableColumn(schema);
				colvarIdAgendaGrupalOrganismo.ColumnName = "idAgendaGrupalOrganismo";
				colvarIdAgendaGrupalOrganismo.DataType = DbType.Int32;
				colvarIdAgendaGrupalOrganismo.MaxLength = 0;
				colvarIdAgendaGrupalOrganismo.AutoIncrement = true;
				colvarIdAgendaGrupalOrganismo.IsNullable = false;
				colvarIdAgendaGrupalOrganismo.IsPrimaryKey = true;
				colvarIdAgendaGrupalOrganismo.IsForeignKey = false;
				colvarIdAgendaGrupalOrganismo.IsReadOnly = false;
				colvarIdAgendaGrupalOrganismo.DefaultSetting = @"";
				colvarIdAgendaGrupalOrganismo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgendaGrupalOrganismo);
				
				TableSchema.TableColumn colvarIdAgendaGrupal = new TableSchema.TableColumn(schema);
				colvarIdAgendaGrupal.ColumnName = "idAgendaGrupal";
				colvarIdAgendaGrupal.DataType = DbType.Int32;
				colvarIdAgendaGrupal.MaxLength = 0;
				colvarIdAgendaGrupal.AutoIncrement = false;
				colvarIdAgendaGrupal.IsNullable = false;
				colvarIdAgendaGrupal.IsPrimaryKey = false;
				colvarIdAgendaGrupal.IsForeignKey = true;
				colvarIdAgendaGrupal.IsReadOnly = false;
				colvarIdAgendaGrupal.DefaultSetting = @"";
				
					colvarIdAgendaGrupal.ForeignKeyTableName = "CON_AgendaGrupal";
				schema.Columns.Add(colvarIdAgendaGrupal);
				
				TableSchema.TableColumn colvarIdOrganismo = new TableSchema.TableColumn(schema);
				colvarIdOrganismo.ColumnName = "idOrganismo";
				colvarIdOrganismo.DataType = DbType.Int32;
				colvarIdOrganismo.MaxLength = 0;
				colvarIdOrganismo.AutoIncrement = false;
				colvarIdOrganismo.IsNullable = false;
				colvarIdOrganismo.IsPrimaryKey = false;
				colvarIdOrganismo.IsForeignKey = true;
				colvarIdOrganismo.IsReadOnly = false;
				colvarIdOrganismo.DefaultSetting = @"";
				
					colvarIdOrganismo.ForeignKeyTableName = "Sys_Organismo";
				schema.Columns.Add(colvarIdOrganismo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaGrupalOrganismo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgendaGrupalOrganismo")]
		[Bindable(true)]
		public int IdAgendaGrupalOrganismo 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupalOrganismo); }
			set { SetColumnValue(Columns.IdAgendaGrupalOrganismo, value); }
		}
		  
		[XmlAttribute("IdAgendaGrupal")]
		[Bindable(true)]
		public int IdAgendaGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupal); }
			set { SetColumnValue(Columns.IdAgendaGrupal, value); }
		}
		  
		[XmlAttribute("IdOrganismo")]
		[Bindable(true)]
		public int IdOrganismo 
		{
			get { return GetColumnValue<int>(Columns.IdOrganismo); }
			set { SetColumnValue(Columns.IdOrganismo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConAgendaGrupal ActiveRecord object related to this ConAgendaGrupalOrganismo
		/// 
		/// </summary>
		public DalSic.ConAgendaGrupal ConAgendaGrupal
		{
			get { return DalSic.ConAgendaGrupal.FetchByID(this.IdAgendaGrupal); }
			set { SetColumnValue("idAgendaGrupal", value.IdAgendaGrupal); }
		}
		
		
		/// <summary>
		/// Returns a SysOrganismo ActiveRecord object related to this ConAgendaGrupalOrganismo
		/// 
		/// </summary>
		public DalSic.SysOrganismo SysOrganismo
		{
			get { return DalSic.SysOrganismo.FetchByID(this.IdOrganismo); }
			set { SetColumnValue("idOrganismo", value.IdOrganismo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgendaGrupal,int varIdOrganismo)
		{
			ConAgendaGrupalOrganismo item = new ConAgendaGrupalOrganismo();
			
			item.IdAgendaGrupal = varIdAgendaGrupal;
			
			item.IdOrganismo = varIdOrganismo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgendaGrupalOrganismo,int varIdAgendaGrupal,int varIdOrganismo)
		{
			ConAgendaGrupalOrganismo item = new ConAgendaGrupalOrganismo();
			
				item.IdAgendaGrupalOrganismo = varIdAgendaGrupalOrganismo;
			
				item.IdAgendaGrupal = varIdAgendaGrupal;
			
				item.IdOrganismo = varIdOrganismo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgendaGrupalOrganismoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaGrupalColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdOrganismoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgendaGrupalOrganismo = @"idAgendaGrupalOrganismo";
			 public static string IdAgendaGrupal = @"idAgendaGrupal";
			 public static string IdOrganismo = @"idOrganismo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
