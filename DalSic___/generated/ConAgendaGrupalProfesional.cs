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
	/// Strongly-typed collection for the ConAgendaGrupalProfesional class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaGrupalProfesionalCollection : ActiveList<ConAgendaGrupalProfesional, ConAgendaGrupalProfesionalCollection>
	{	   
		public ConAgendaGrupalProfesionalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaGrupalProfesionalCollection</returns>
		public ConAgendaGrupalProfesionalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaGrupalProfesional o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaGrupalProfesional table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaGrupalProfesional : ActiveRecord<ConAgendaGrupalProfesional>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaGrupalProfesional()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaGrupalProfesional(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaGrupalProfesional(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaGrupalProfesional(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaGrupalProfesional", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgendaGrupalProfesional = new TableSchema.TableColumn(schema);
				colvarIdAgendaGrupalProfesional.ColumnName = "idAgendaGrupalProfesional";
				colvarIdAgendaGrupalProfesional.DataType = DbType.Int32;
				colvarIdAgendaGrupalProfesional.MaxLength = 0;
				colvarIdAgendaGrupalProfesional.AutoIncrement = true;
				colvarIdAgendaGrupalProfesional.IsNullable = false;
				colvarIdAgendaGrupalProfesional.IsPrimaryKey = true;
				colvarIdAgendaGrupalProfesional.IsForeignKey = false;
				colvarIdAgendaGrupalProfesional.IsReadOnly = false;
				colvarIdAgendaGrupalProfesional.DefaultSetting = @"";
				colvarIdAgendaGrupalProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgendaGrupalProfesional);
				
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
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaGrupalProfesional",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgendaGrupalProfesional")]
		[Bindable(true)]
		public int IdAgendaGrupalProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupalProfesional); }
			set { SetColumnValue(Columns.IdAgendaGrupalProfesional, value); }
		}
		  
		[XmlAttribute("IdAgendaGrupal")]
		[Bindable(true)]
		public int IdAgendaGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupal); }
			set { SetColumnValue(Columns.IdAgendaGrupal, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConAgendaGrupal ActiveRecord object related to this ConAgendaGrupalProfesional
		/// 
		/// </summary>
		public DalSic.ConAgendaGrupal ConAgendaGrupal
		{
			get { return DalSic.ConAgendaGrupal.FetchByID(this.IdAgendaGrupal); }
			set { SetColumnValue("idAgendaGrupal", value.IdAgendaGrupal); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this ConAgendaGrupalProfesional
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgendaGrupal,int varIdProfesional)
		{
			ConAgendaGrupalProfesional item = new ConAgendaGrupalProfesional();
			
			item.IdAgendaGrupal = varIdAgendaGrupal;
			
			item.IdProfesional = varIdProfesional;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgendaGrupalProfesional,int varIdAgendaGrupal,int varIdProfesional)
		{
			ConAgendaGrupalProfesional item = new ConAgendaGrupalProfesional();
			
				item.IdAgendaGrupalProfesional = varIdAgendaGrupalProfesional;
			
				item.IdAgendaGrupal = varIdAgendaGrupal;
			
				item.IdProfesional = varIdProfesional;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgendaGrupalProfesionalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaGrupalColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgendaGrupalProfesional = @"idAgendaGrupalProfesional";
			 public static string IdAgendaGrupal = @"idAgendaGrupal";
			 public static string IdProfesional = @"idProfesional";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
