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
	/// Strongly-typed collection for the GuardiaRegistrosMedicosResponsable class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistrosMedicosResponsableCollection : ActiveList<GuardiaRegistrosMedicosResponsable, GuardiaRegistrosMedicosResponsableCollection>
	{	   
		public GuardiaRegistrosMedicosResponsableCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistrosMedicosResponsableCollection</returns>
		public GuardiaRegistrosMedicosResponsableCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistrosMedicosResponsable o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros_MedicosResponsables table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistrosMedicosResponsable : ActiveRecord<GuardiaRegistrosMedicosResponsable>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistrosMedicosResponsable()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistrosMedicosResponsable(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistrosMedicosResponsable(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistrosMedicosResponsable(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros_MedicosResponsables", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdRegistroGuardia = new TableSchema.TableColumn(schema);
				colvarIdRegistroGuardia.ColumnName = "idRegistroGuardia";
				colvarIdRegistroGuardia.DataType = DbType.Int32;
				colvarIdRegistroGuardia.MaxLength = 0;
				colvarIdRegistroGuardia.AutoIncrement = false;
				colvarIdRegistroGuardia.IsNullable = false;
				colvarIdRegistroGuardia.IsPrimaryKey = false;
				colvarIdRegistroGuardia.IsForeignKey = false;
				colvarIdRegistroGuardia.IsReadOnly = false;
				colvarIdRegistroGuardia.DefaultSetting = @"";
				colvarIdRegistroGuardia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRegistroGuardia);
				
				TableSchema.TableColumn colvarIdMedico = new TableSchema.TableColumn(schema);
				colvarIdMedico.ColumnName = "idMedico";
				colvarIdMedico.DataType = DbType.Int32;
				colvarIdMedico.MaxLength = 0;
				colvarIdMedico.AutoIncrement = false;
				colvarIdMedico.IsNullable = false;
				colvarIdMedico.IsPrimaryKey = false;
				colvarIdMedico.IsForeignKey = false;
				colvarIdMedico.IsReadOnly = false;
				colvarIdMedico.DefaultSetting = @"";
				colvarIdMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedico);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarAuditUser = new TableSchema.TableColumn(schema);
				colvarAuditUser.ColumnName = "audit_user";
				colvarAuditUser.DataType = DbType.Int32;
				colvarAuditUser.MaxLength = 0;
				colvarAuditUser.AutoIncrement = false;
				colvarAuditUser.IsNullable = false;
				colvarAuditUser.IsPrimaryKey = false;
				colvarAuditUser.IsForeignKey = false;
				colvarAuditUser.IsReadOnly = false;
				colvarAuditUser.DefaultSetting = @"";
				colvarAuditUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditUser);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros_MedicosResponsables",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdRegistroGuardia")]
		[Bindable(true)]
		public int IdRegistroGuardia 
		{
			get { return GetColumnValue<int>(Columns.IdRegistroGuardia); }
			set { SetColumnValue(Columns.IdRegistroGuardia, value); }
		}
		  
		[XmlAttribute("IdMedico")]
		[Bindable(true)]
		public int IdMedico 
		{
			get { return GetColumnValue<int>(Columns.IdMedico); }
			set { SetColumnValue(Columns.IdMedico, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("AuditUser")]
		[Bindable(true)]
		public int AuditUser 
		{
			get { return GetColumnValue<int>(Columns.AuditUser); }
			set { SetColumnValue(Columns.AuditUser, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdRegistroGuardia,int varIdMedico,DateTime varFecha,int varAuditUser)
		{
			GuardiaRegistrosMedicosResponsable item = new GuardiaRegistrosMedicosResponsable();
			
			item.IdRegistroGuardia = varIdRegistroGuardia;
			
			item.IdMedico = varIdMedico;
			
			item.Fecha = varFecha;
			
			item.AuditUser = varAuditUser;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varIdRegistroGuardia,int varIdMedico,DateTime varFecha,int varAuditUser)
		{
			GuardiaRegistrosMedicosResponsable item = new GuardiaRegistrosMedicosResponsable();
			
				item.Id = varId;
			
				item.IdRegistroGuardia = varIdRegistroGuardia;
			
				item.IdMedico = varIdMedico;
			
				item.Fecha = varFecha;
			
				item.AuditUser = varAuditUser;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdRegistroGuardiaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMedicoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdRegistroGuardia = @"idRegistroGuardia";
			 public static string IdMedico = @"idMedico";
			 public static string Fecha = @"fecha";
			 public static string AuditUser = @"audit_user";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
