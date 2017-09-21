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
	/// Strongly-typed collection for the ConTurnoAuditorium class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoAuditoriumCollection : ActiveList<ConTurnoAuditorium, ConTurnoAuditoriumCollection>
	{	   
		public ConTurnoAuditoriumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoAuditoriumCollection</returns>
		public ConTurnoAuditoriumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoAuditorium o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoAuditoria table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoAuditorium : ActiveRecord<ConTurnoAuditorium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoAuditorium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoAuditorium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoAuditorium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoAuditorium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoAuditoria", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTurnoAuditoria = new TableSchema.TableColumn(schema);
				colvarIdTurnoAuditoria.ColumnName = "idTurnoAuditoria";
				colvarIdTurnoAuditoria.DataType = DbType.Int32;
				colvarIdTurnoAuditoria.MaxLength = 0;
				colvarIdTurnoAuditoria.AutoIncrement = true;
				colvarIdTurnoAuditoria.IsNullable = false;
				colvarIdTurnoAuditoria.IsPrimaryKey = true;
				colvarIdTurnoAuditoria.IsForeignKey = false;
				colvarIdTurnoAuditoria.IsReadOnly = false;
				colvarIdTurnoAuditoria.DefaultSetting = @"";
				colvarIdTurnoAuditoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoAuditoria);
				
				TableSchema.TableColumn colvarIdTurno = new TableSchema.TableColumn(schema);
				colvarIdTurno.ColumnName = "idTurno";
				colvarIdTurno.DataType = DbType.Int32;
				colvarIdTurno.MaxLength = 0;
				colvarIdTurno.AutoIncrement = false;
				colvarIdTurno.IsNullable = false;
				colvarIdTurno.IsPrimaryKey = false;
				colvarIdTurno.IsForeignKey = true;
				colvarIdTurno.IsReadOnly = false;
				colvarIdTurno.DefaultSetting = @"";
				
					colvarIdTurno.ForeignKeyTableName = "CON_Turno";
				schema.Columns.Add(colvarIdTurno);
				
				TableSchema.TableColumn colvarIdTurnoEstado = new TableSchema.TableColumn(schema);
				colvarIdTurnoEstado.ColumnName = "idTurnoEstado";
				colvarIdTurnoEstado.DataType = DbType.Int32;
				colvarIdTurnoEstado.MaxLength = 0;
				colvarIdTurnoEstado.AutoIncrement = false;
				colvarIdTurnoEstado.IsNullable = false;
				colvarIdTurnoEstado.IsPrimaryKey = false;
				colvarIdTurnoEstado.IsForeignKey = true;
				colvarIdTurnoEstado.IsReadOnly = false;
				colvarIdTurnoEstado.DefaultSetting = @"";
				
					colvarIdTurnoEstado.ForeignKeyTableName = "CON_TurnoEstado";
				schema.Columns.Add(colvarIdTurnoEstado);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "idServicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = false;
				colvarIdServicio.IsNullable = false;
				colvarIdServicio.IsPrimaryKey = false;
				colvarIdServicio.IsForeignKey = false;
				colvarIdServicio.IsReadOnly = false;
				
						colvarIdServicio.DefaultSetting = @"((0))";
				colvarIdServicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdServicio);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = false;
				colvarIdProfesional.IsReadOnly = false;
				
						colvarIdProfesional.DefaultSetting = @"((0))";
				colvarIdProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = false;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = false;
				colvarIdEspecialidad.IsReadOnly = false;
				
						colvarIdEspecialidad.DefaultSetting = @"((0))";
				colvarIdEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEspecialidad);
				
				TableSchema.TableColumn colvarIdConsultorio = new TableSchema.TableColumn(schema);
				colvarIdConsultorio.ColumnName = "idConsultorio";
				colvarIdConsultorio.DataType = DbType.Int32;
				colvarIdConsultorio.MaxLength = 0;
				colvarIdConsultorio.AutoIncrement = false;
				colvarIdConsultorio.IsNullable = false;
				colvarIdConsultorio.IsPrimaryKey = false;
				colvarIdConsultorio.IsForeignKey = false;
				colvarIdConsultorio.IsReadOnly = false;
				
						colvarIdConsultorio.DefaultSetting = @"((0))";
				colvarIdConsultorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsultorio);
				
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
				
				TableSchema.TableColumn colvarHora = new TableSchema.TableColumn(schema);
				colvarHora.ColumnName = "hora";
				colvarHora.DataType = DbType.AnsiStringFixedLength;
				colvarHora.MaxLength = 8;
				colvarHora.AutoIncrement = false;
				colvarHora.IsNullable = false;
				colvarHora.IsPrimaryKey = false;
				colvarHora.IsForeignKey = false;
				colvarHora.IsReadOnly = false;
				colvarHora.DefaultSetting = @"";
				colvarHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHora);
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "fechaModificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = false;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				colvarFechaModificacion.DefaultSetting = @"";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				TableSchema.TableColumn colvarHoraModificacion = new TableSchema.TableColumn(schema);
				colvarHoraModificacion.ColumnName = "horaModificacion";
				colvarHoraModificacion.DataType = DbType.AnsiStringFixedLength;
				colvarHoraModificacion.MaxLength = 5;
				colvarHoraModificacion.AutoIncrement = false;
				colvarHoraModificacion.IsNullable = false;
				colvarHoraModificacion.IsPrimaryKey = false;
				colvarHoraModificacion.IsForeignKey = false;
				colvarHoraModificacion.IsReadOnly = false;
				colvarHoraModificacion.DefaultSetting = @"";
				colvarHoraModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraModificacion);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoAuditoria",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTurnoAuditoria")]
		[Bindable(true)]
		public int IdTurnoAuditoria 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoAuditoria); }
			set { SetColumnValue(Columns.IdTurnoAuditoria, value); }
		}
		  
		[XmlAttribute("IdTurno")]
		[Bindable(true)]
		public int IdTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTurno); }
			set { SetColumnValue(Columns.IdTurno, value); }
		}
		  
		[XmlAttribute("IdTurnoEstado")]
		[Bindable(true)]
		public int IdTurnoEstado 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoEstado); }
			set { SetColumnValue(Columns.IdTurnoEstado, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int IdServicio 
		{
			get { return GetColumnValue<int>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int IdEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("IdConsultorio")]
		[Bindable(true)]
		public int IdConsultorio 
		{
			get { return GetColumnValue<int>(Columns.IdConsultorio); }
			set { SetColumnValue(Columns.IdConsultorio, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Hora")]
		[Bindable(true)]
		public string Hora 
		{
			get { return GetColumnValue<string>(Columns.Hora); }
			set { SetColumnValue(Columns.Hora, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("HoraModificacion")]
		[Bindable(true)]
		public string HoraModificacion 
		{
			get { return GetColumnValue<string>(Columns.HoraModificacion); }
			set { SetColumnValue(Columns.HoraModificacion, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConTurno ActiveRecord object related to this ConTurnoAuditorium
		/// 
		/// </summary>
		public DalSic.ConTurno ConTurno
		{
			get { return DalSic.ConTurno.FetchByID(this.IdTurno); }
			set { SetColumnValue("idTurno", value.IdTurno); }
		}
		
		
		/// <summary>
		/// Returns a ConTurnoEstado ActiveRecord object related to this ConTurnoAuditorium
		/// 
		/// </summary>
		public DalSic.ConTurnoEstado ConTurnoEstado
		{
			get { return DalSic.ConTurnoEstado.FetchByID(this.IdTurnoEstado); }
			set { SetColumnValue("idTurnoEstado", value.IdTurnoEstado); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdTurno,int varIdTurnoEstado,int varIdUsuario,int varIdServicio,int varIdProfesional,int varIdEspecialidad,int varIdConsultorio,DateTime varFecha,string varHora,DateTime varFechaModificacion,string varHoraModificacion,int varIdPaciente)
		{
			ConTurnoAuditorium item = new ConTurnoAuditorium();
			
			item.IdTurno = varIdTurno;
			
			item.IdTurnoEstado = varIdTurnoEstado;
			
			item.IdUsuario = varIdUsuario;
			
			item.IdServicio = varIdServicio;
			
			item.IdProfesional = varIdProfesional;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdConsultorio = varIdConsultorio;
			
			item.Fecha = varFecha;
			
			item.Hora = varHora;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.HoraModificacion = varHoraModificacion;
			
			item.IdPaciente = varIdPaciente;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTurnoAuditoria,int varIdTurno,int varIdTurnoEstado,int varIdUsuario,int varIdServicio,int varIdProfesional,int varIdEspecialidad,int varIdConsultorio,DateTime varFecha,string varHora,DateTime varFechaModificacion,string varHoraModificacion,int varIdPaciente)
		{
			ConTurnoAuditorium item = new ConTurnoAuditorium();
			
				item.IdTurnoAuditoria = varIdTurnoAuditoria;
			
				item.IdTurno = varIdTurno;
			
				item.IdTurnoEstado = varIdTurnoEstado;
			
				item.IdUsuario = varIdUsuario;
			
				item.IdServicio = varIdServicio;
			
				item.IdProfesional = varIdProfesional;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdConsultorio = varIdConsultorio;
			
				item.Fecha = varFecha;
			
				item.Hora = varHora;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.HoraModificacion = varHoraModificacion;
			
				item.IdPaciente = varIdPaciente;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTurnoAuditoriaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoEstadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultorioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraModificacionColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTurnoAuditoria = @"idTurnoAuditoria";
			 public static string IdTurno = @"idTurno";
			 public static string IdTurnoEstado = @"idTurnoEstado";
			 public static string IdUsuario = @"idUsuario";
			 public static string IdServicio = @"idServicio";
			 public static string IdProfesional = @"idProfesional";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdConsultorio = @"idConsultorio";
			 public static string Fecha = @"fecha";
			 public static string Hora = @"hora";
			 public static string FechaModificacion = @"fechaModificacion";
			 public static string HoraModificacion = @"horaModificacion";
			 public static string IdPaciente = @"idPaciente";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
