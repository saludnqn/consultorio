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
	/// Strongly-typed collection for the SysRelHistoriaClinicaEfector class.
	/// </summary>
    [Serializable]
	public partial class SysRelHistoriaClinicaEfectorCollection : ActiveList<SysRelHistoriaClinicaEfector, SysRelHistoriaClinicaEfectorCollection>
	{	   
		public SysRelHistoriaClinicaEfectorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelHistoriaClinicaEfectorCollection</returns>
		public SysRelHistoriaClinicaEfectorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelHistoriaClinicaEfector o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelHistoriaClinicaEfector table.
	/// </summary>
	[Serializable]
	public partial class SysRelHistoriaClinicaEfector : ActiveRecord<SysRelHistoriaClinicaEfector>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelHistoriaClinicaEfector()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelHistoriaClinicaEfector(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelHistoriaClinicaEfector(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelHistoriaClinicaEfector(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelHistoriaClinicaEfector", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelHistoriaClinicaEfector = new TableSchema.TableColumn(schema);
				colvarIdRelHistoriaClinicaEfector.ColumnName = "idRelHistoriaClinicaEfector";
				colvarIdRelHistoriaClinicaEfector.DataType = DbType.Int32;
				colvarIdRelHistoriaClinicaEfector.MaxLength = 0;
				colvarIdRelHistoriaClinicaEfector.AutoIncrement = true;
				colvarIdRelHistoriaClinicaEfector.IsNullable = false;
				colvarIdRelHistoriaClinicaEfector.IsPrimaryKey = true;
				colvarIdRelHistoriaClinicaEfector.IsForeignKey = false;
				colvarIdRelHistoriaClinicaEfector.IsReadOnly = false;
				colvarIdRelHistoriaClinicaEfector.DefaultSetting = @"";
				colvarIdRelHistoriaClinicaEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelHistoriaClinicaEfector);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
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
				
				TableSchema.TableColumn colvarHistoriaClinica = new TableSchema.TableColumn(schema);
				colvarHistoriaClinica.ColumnName = "historiaClinica";
				colvarHistoriaClinica.DataType = DbType.Int32;
				colvarHistoriaClinica.MaxLength = 0;
				colvarHistoriaClinica.AutoIncrement = false;
				colvarHistoriaClinica.IsNullable = false;
				colvarHistoriaClinica.IsPrimaryKey = false;
				colvarHistoriaClinica.IsForeignKey = false;
				colvarHistoriaClinica.IsReadOnly = false;
				colvarHistoriaClinica.DefaultSetting = @"";
				colvarHistoriaClinica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHistoriaClinica);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.AnsiString;
				colvarIdUsuarioRegistro.MaxLength = 50;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = false;
				colvarIdUsuarioRegistro.IsPrimaryKey = false;
				colvarIdUsuarioRegistro.IsForeignKey = false;
				colvarIdUsuarioRegistro.IsReadOnly = false;
				colvarIdUsuarioRegistro.DefaultSetting = @"";
				colvarIdUsuarioRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRegistro);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				colvarFechaRegistro.DefaultSetting = @"";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelHistoriaClinicaEfector",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelHistoriaClinicaEfector")]
		[Bindable(true)]
		public int IdRelHistoriaClinicaEfector 
		{
			get { return GetColumnValue<int>(Columns.IdRelHistoriaClinicaEfector); }
			set { SetColumnValue(Columns.IdRelHistoriaClinicaEfector, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("HistoriaClinica")]
		[Bindable(true)]
		public int HistoriaClinica 
		{
			get { return GetColumnValue<int>(Columns.HistoriaClinica); }
			set { SetColumnValue(Columns.HistoriaClinica, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public string IdUsuarioRegistro 
		{
			get { return GetColumnValue<string>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysRelHistoriaClinicaEfector
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this SysRelHistoriaClinicaEfector
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
		public static void Insert(int varIdEfector,int varIdPaciente,int varHistoriaClinica,string varIdUsuarioRegistro,DateTime varFechaRegistro)
		{
			SysRelHistoriaClinicaEfector item = new SysRelHistoriaClinicaEfector();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.HistoriaClinica = varHistoriaClinica;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.FechaRegistro = varFechaRegistro;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelHistoriaClinicaEfector,int varIdEfector,int varIdPaciente,int varHistoriaClinica,string varIdUsuarioRegistro,DateTime varFechaRegistro)
		{
			SysRelHistoriaClinicaEfector item = new SysRelHistoriaClinicaEfector();
			
				item.IdRelHistoriaClinicaEfector = varIdRelHistoriaClinicaEfector;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.HistoriaClinica = varHistoriaClinica;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
				item.FechaRegistro = varFechaRegistro;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelHistoriaClinicaEfectorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HistoriaClinicaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelHistoriaClinicaEfector = @"idRelHistoriaClinicaEfector";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string HistoriaClinica = @"historiaClinica";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
			 public static string FechaRegistro = @"fechaRegistro";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
