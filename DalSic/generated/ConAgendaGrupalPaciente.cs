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
	/// Strongly-typed collection for the ConAgendaGrupalPaciente class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaGrupalPacienteCollection : ActiveList<ConAgendaGrupalPaciente, ConAgendaGrupalPacienteCollection>
	{	   
		public ConAgendaGrupalPacienteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaGrupalPacienteCollection</returns>
		public ConAgendaGrupalPacienteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaGrupalPaciente o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaGrupalPaciente table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaGrupalPaciente : ActiveRecord<ConAgendaGrupalPaciente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaGrupalPaciente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaGrupalPaciente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaGrupalPaciente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaGrupalPaciente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaGrupalPaciente", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgendaGrupalPaciente = new TableSchema.TableColumn(schema);
				colvarIdAgendaGrupalPaciente.ColumnName = "idAgendaGrupalPaciente";
				colvarIdAgendaGrupalPaciente.DataType = DbType.Int32;
				colvarIdAgendaGrupalPaciente.MaxLength = 0;
				colvarIdAgendaGrupalPaciente.AutoIncrement = true;
				colvarIdAgendaGrupalPaciente.IsNullable = false;
				colvarIdAgendaGrupalPaciente.IsPrimaryKey = true;
				colvarIdAgendaGrupalPaciente.IsForeignKey = false;
				colvarIdAgendaGrupalPaciente.IsReadOnly = false;
				colvarIdAgendaGrupalPaciente.DefaultSetting = @"";
				colvarIdAgendaGrupalPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgendaGrupalPaciente);
				
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
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarAsistio = new TableSchema.TableColumn(schema);
				colvarAsistio.ColumnName = "asistio";
				colvarAsistio.DataType = DbType.Boolean;
				colvarAsistio.MaxLength = 0;
				colvarAsistio.AutoIncrement = false;
				colvarAsistio.IsNullable = false;
				colvarAsistio.IsPrimaryKey = false;
				colvarAsistio.IsForeignKey = false;
				colvarAsistio.IsReadOnly = false;
				
						colvarAsistio.DefaultSetting = @"((0))";
				colvarAsistio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAsistio);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaGrupalPaciente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgendaGrupalPaciente")]
		[Bindable(true)]
		public int IdAgendaGrupalPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupalPaciente); }
			set { SetColumnValue(Columns.IdAgendaGrupalPaciente, value); }
		}
		  
		[XmlAttribute("IdAgendaGrupal")]
		[Bindable(true)]
		public int IdAgendaGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupal); }
			set { SetColumnValue(Columns.IdAgendaGrupal, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Asistio")]
		[Bindable(true)]
		public bool Asistio 
		{
			get { return GetColumnValue<bool>(Columns.Asistio); }
			set { SetColumnValue(Columns.Asistio, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConAgendaGrupal ActiveRecord object related to this ConAgendaGrupalPaciente
		/// 
		/// </summary>
		public DalSic.ConAgendaGrupal ConAgendaGrupal
		{
			get { return DalSic.ConAgendaGrupal.FetchByID(this.IdAgendaGrupal); }
			set { SetColumnValue("idAgendaGrupal", value.IdAgendaGrupal); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this ConAgendaGrupalPaciente
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgendaGrupal,int varIdPaciente,bool varAsistio,string varCreatedBy,string varModifiedBy,DateTime? varCreatedOn,DateTime? varModifiedOn)
		{
			ConAgendaGrupalPaciente item = new ConAgendaGrupalPaciente();
			
			item.IdAgendaGrupal = varIdAgendaGrupal;
			
			item.IdPaciente = varIdPaciente;
			
			item.Asistio = varAsistio;
			
			item.CreatedBy = varCreatedBy;
			
			item.ModifiedBy = varModifiedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgendaGrupalPaciente,int varIdAgendaGrupal,int varIdPaciente,bool varAsistio,string varCreatedBy,string varModifiedBy,DateTime? varCreatedOn,DateTime? varModifiedOn)
		{
			ConAgendaGrupalPaciente item = new ConAgendaGrupalPaciente();
			
				item.IdAgendaGrupalPaciente = varIdAgendaGrupalPaciente;
			
				item.IdAgendaGrupal = varIdAgendaGrupal;
			
				item.IdPaciente = varIdPaciente;
			
				item.Asistio = varAsistio;
			
				item.CreatedBy = varCreatedBy;
			
				item.ModifiedBy = varModifiedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgendaGrupalPacienteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaGrupalColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AsistioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgendaGrupalPaciente = @"idAgendaGrupalPaciente";
			 public static string IdAgendaGrupal = @"idAgendaGrupal";
			 public static string IdPaciente = @"idPaciente";
			 public static string Asistio = @"asistio";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
