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
	/// Strongly-typed collection for the AprIntervencionProfesional class.
	/// </summary>
    [Serializable]
	public partial class AprIntervencionProfesionalCollection : ActiveList<AprIntervencionProfesional, AprIntervencionProfesionalCollection>
	{	   
		public AprIntervencionProfesionalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprIntervencionProfesionalCollection</returns>
		public AprIntervencionProfesionalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprIntervencionProfesional o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_IntervencionProfesional table.
	/// </summary>
	[Serializable]
	public partial class AprIntervencionProfesional : ActiveRecord<AprIntervencionProfesional>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprIntervencionProfesional()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprIntervencionProfesional(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprIntervencionProfesional(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprIntervencionProfesional(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_IntervencionProfesional", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdIntervencionProfesional = new TableSchema.TableColumn(schema);
				colvarIdIntervencionProfesional.ColumnName = "idIntervencionProfesional";
				colvarIdIntervencionProfesional.DataType = DbType.Int32;
				colvarIdIntervencionProfesional.MaxLength = 0;
				colvarIdIntervencionProfesional.AutoIncrement = true;
				colvarIdIntervencionProfesional.IsNullable = false;
				colvarIdIntervencionProfesional.IsPrimaryKey = true;
				colvarIdIntervencionProfesional.IsForeignKey = false;
				colvarIdIntervencionProfesional.IsReadOnly = false;
				colvarIdIntervencionProfesional.DefaultSetting = @"";
				colvarIdIntervencionProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIntervencionProfesional);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarProfesional = new TableSchema.TableColumn(schema);
				colvarProfesional.ColumnName = "Profesional";
				colvarProfesional.DataType = DbType.AnsiString;
				colvarProfesional.MaxLength = 50;
				colvarProfesional.AutoIncrement = false;
				colvarProfesional.IsNullable = false;
				colvarProfesional.IsPrimaryKey = false;
				colvarProfesional.IsForeignKey = false;
				colvarProfesional.IsReadOnly = false;
				colvarProfesional.DefaultSetting = @"";
				colvarProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProfesional);
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = true;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = true;
				colvarIdEspecialidad.IsReadOnly = false;
				colvarIdEspecialidad.DefaultSetting = @"";
				
					colvarIdEspecialidad.ForeignKeyTableName = "Sys_Especialidad";
				schema.Columns.Add(colvarIdEspecialidad);
				
				TableSchema.TableColumn colvarIdActividad = new TableSchema.TableColumn(schema);
				colvarIdActividad.ColumnName = "idActividad";
				colvarIdActividad.DataType = DbType.Int32;
				colvarIdActividad.MaxLength = 0;
				colvarIdActividad.AutoIncrement = false;
				colvarIdActividad.IsNullable = true;
				colvarIdActividad.IsPrimaryKey = false;
				colvarIdActividad.IsForeignKey = true;
				colvarIdActividad.IsReadOnly = false;
				colvarIdActividad.DefaultSetting = @"";
				
					colvarIdActividad.ForeignKeyTableName = "APR_Actividad";
				schema.Columns.Add(colvarIdActividad);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "Observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 2147483647;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = true;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				colvarObservacion.DefaultSetting = @"";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "Fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_IntervencionProfesional",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdIntervencionProfesional")]
		[Bindable(true)]
		public int IdIntervencionProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdIntervencionProfesional); }
			set { SetColumnValue(Columns.IdIntervencionProfesional, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Profesional")]
		[Bindable(true)]
		public string Profesional 
		{
			get { return GetColumnValue<string>(Columns.Profesional); }
			set { SetColumnValue(Columns.Profesional, value); }
		}
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int? IdEspecialidad 
		{
			get { return GetColumnValue<int?>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("IdActividad")]
		[Bindable(true)]
		public int? IdActividad 
		{
			get { return GetColumnValue<int?>(Columns.IdActividad); }
			set { SetColumnValue(Columns.IdActividad, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
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
		/// Returns a SysEspecialidad ActiveRecord object related to this AprIntervencionProfesional
		/// 
		/// </summary>
		public DalSic.SysEspecialidad SysEspecialidad
		{
			get { return DalSic.SysEspecialidad.FetchByID(this.IdEspecialidad); }
			set { SetColumnValue("idEspecialidad", value.IdEspecialidad); }
		}
		
		
		/// <summary>
		/// Returns a AprActividad ActiveRecord object related to this AprIntervencionProfesional
		/// 
		/// </summary>
		public DalSic.AprActividad AprActividad
		{
			get { return DalSic.AprActividad.FetchByID(this.IdActividad); }
			set { SetColumnValue("idActividad", value.IdActividad); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,string varProfesional,int? varIdEspecialidad,int? varIdActividad,string varObservacion,DateTime? varFecha,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprIntervencionProfesional item = new AprIntervencionProfesional();
			
			item.IdPaciente = varIdPaciente;
			
			item.Profesional = varProfesional;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdActividad = varIdActividad;
			
			item.Observacion = varObservacion;
			
			item.Fecha = varFecha;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdIntervencionProfesional,int varIdPaciente,string varProfesional,int? varIdEspecialidad,int? varIdActividad,string varObservacion,DateTime? varFecha,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprIntervencionProfesional item = new AprIntervencionProfesional();
			
				item.IdIntervencionProfesional = varIdIntervencionProfesional;
			
				item.IdPaciente = varIdPaciente;
			
				item.Profesional = varProfesional;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdActividad = varIdActividad;
			
				item.Observacion = varObservacion;
			
				item.Fecha = varFecha;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdIntervencionProfesionalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProfesionalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdActividadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdIntervencionProfesional = @"idIntervencionProfesional";
			 public static string IdPaciente = @"idPaciente";
			 public static string Profesional = @"Profesional";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdActividad = @"idActividad";
			 public static string Observacion = @"Observacion";
			 public static string Fecha = @"Fecha";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
