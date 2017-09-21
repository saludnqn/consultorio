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
	/// Strongly-typed collection for the ConAgendaAuditorium class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaAuditoriumCollection : ActiveList<ConAgendaAuditorium, ConAgendaAuditoriumCollection>
	{	   
		public ConAgendaAuditoriumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaAuditoriumCollection</returns>
		public ConAgendaAuditoriumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaAuditorium o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaAuditoria table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaAuditorium : ActiveRecord<ConAgendaAuditorium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaAuditorium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaAuditorium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaAuditorium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaAuditorium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaAuditoria", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAuditoria = new TableSchema.TableColumn(schema);
				colvarIdAuditoria.ColumnName = "idAuditoria";
				colvarIdAuditoria.DataType = DbType.Int32;
				colvarIdAuditoria.MaxLength = 0;
				colvarIdAuditoria.AutoIncrement = true;
				colvarIdAuditoria.IsNullable = false;
				colvarIdAuditoria.IsPrimaryKey = true;
				colvarIdAuditoria.IsForeignKey = false;
				colvarIdAuditoria.IsReadOnly = false;
				colvarIdAuditoria.DefaultSetting = @"";
				colvarIdAuditoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAuditoria);
				
				TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
				colvarIdAgenda.ColumnName = "idAgenda";
				colvarIdAgenda.DataType = DbType.Int32;
				colvarIdAgenda.MaxLength = 0;
				colvarIdAgenda.AutoIncrement = false;
				colvarIdAgenda.IsNullable = false;
				colvarIdAgenda.IsPrimaryKey = false;
				colvarIdAgenda.IsForeignKey = false;
				colvarIdAgenda.IsReadOnly = false;
				colvarIdAgenda.DefaultSetting = @"";
				colvarIdAgenda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgenda);
				
				TableSchema.TableColumn colvarIdAgendaEstado = new TableSchema.TableColumn(schema);
				colvarIdAgendaEstado.ColumnName = "idAgendaEstado";
				colvarIdAgendaEstado.DataType = DbType.Int32;
				colvarIdAgendaEstado.MaxLength = 0;
				colvarIdAgendaEstado.AutoIncrement = false;
				colvarIdAgendaEstado.IsNullable = false;
				colvarIdAgendaEstado.IsPrimaryKey = false;
				colvarIdAgendaEstado.IsForeignKey = true;
				colvarIdAgendaEstado.IsReadOnly = false;
				colvarIdAgendaEstado.DefaultSetting = @"";
				
					colvarIdAgendaEstado.ForeignKeyTableName = "CON_AgendaEstado";
				schema.Columns.Add(colvarIdAgendaEstado);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"((0))";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarHoraInicio = new TableSchema.TableColumn(schema);
				colvarHoraInicio.ColumnName = "horaInicio";
				colvarHoraInicio.DataType = DbType.AnsiStringFixedLength;
				colvarHoraInicio.MaxLength = 5;
				colvarHoraInicio.AutoIncrement = false;
				colvarHoraInicio.IsNullable = false;
				colvarHoraInicio.IsPrimaryKey = false;
				colvarHoraInicio.IsForeignKey = false;
				colvarHoraInicio.IsReadOnly = false;
				
						colvarHoraInicio.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarHoraInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraInicio);
				
				TableSchema.TableColumn colvarHoraFin = new TableSchema.TableColumn(schema);
				colvarHoraFin.ColumnName = "horaFin";
				colvarHoraFin.DataType = DbType.AnsiStringFixedLength;
				colvarHoraFin.MaxLength = 5;
				colvarHoraFin.AutoIncrement = false;
				colvarHoraFin.IsNullable = false;
				colvarHoraFin.IsPrimaryKey = false;
				colvarHoraFin.IsForeignKey = false;
				colvarHoraFin.IsReadOnly = false;
				
						colvarHoraFin.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarHoraFin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraFin);
				
				TableSchema.TableColumn colvarDuracion = new TableSchema.TableColumn(schema);
				colvarDuracion.ColumnName = "duracion";
				colvarDuracion.DataType = DbType.Int32;
				colvarDuracion.MaxLength = 0;
				colvarDuracion.AutoIncrement = false;
				colvarDuracion.IsNullable = false;
				colvarDuracion.IsPrimaryKey = false;
				colvarDuracion.IsForeignKey = false;
				colvarDuracion.IsReadOnly = false;
				
						colvarDuracion.DefaultSetting = @"((0))";
				colvarDuracion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDuracion);
				
				TableSchema.TableColumn colvarReservados = new TableSchema.TableColumn(schema);
				colvarReservados.ColumnName = "reservados";
				colvarReservados.DataType = DbType.Int32;
				colvarReservados.MaxLength = 0;
				colvarReservados.AutoIncrement = false;
				colvarReservados.IsNullable = false;
				colvarReservados.IsPrimaryKey = false;
				colvarReservados.IsForeignKey = false;
				colvarReservados.IsReadOnly = false;
				
						colvarReservados.DefaultSetting = @"((0))";
				colvarReservados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReservados);
				
				TableSchema.TableColumn colvarMaxSobreturnos = new TableSchema.TableColumn(schema);
				colvarMaxSobreturnos.ColumnName = "maxSobreturnos";
				colvarMaxSobreturnos.DataType = DbType.Int32;
				colvarMaxSobreturnos.MaxLength = 0;
				colvarMaxSobreturnos.AutoIncrement = false;
				colvarMaxSobreturnos.IsNullable = false;
				colvarMaxSobreturnos.IsPrimaryKey = false;
				colvarMaxSobreturnos.IsForeignKey = false;
				colvarMaxSobreturnos.IsReadOnly = false;
				colvarMaxSobreturnos.DefaultSetting = @"";
				colvarMaxSobreturnos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaxSobreturnos);
				
				TableSchema.TableColumn colvarCitarPorBloques = new TableSchema.TableColumn(schema);
				colvarCitarPorBloques.ColumnName = "citarPorBloques";
				colvarCitarPorBloques.DataType = DbType.Int32;
				colvarCitarPorBloques.MaxLength = 0;
				colvarCitarPorBloques.AutoIncrement = false;
				colvarCitarPorBloques.IsNullable = false;
				colvarCitarPorBloques.IsPrimaryKey = false;
				colvarCitarPorBloques.IsForeignKey = false;
				colvarCitarPorBloques.IsReadOnly = false;
				
						colvarCitarPorBloques.DefaultSetting = @"((0))";
				colvarCitarPorBloques.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCitarPorBloques);
				
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
				colvarHoraModificacion.IsNullable = true;
				colvarHoraModificacion.IsPrimaryKey = false;
				colvarHoraModificacion.IsForeignKey = false;
				colvarHoraModificacion.IsReadOnly = false;
				colvarHoraModificacion.DefaultSetting = @"";
				colvarHoraModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraModificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaAuditoria",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAuditoria")]
		[Bindable(true)]
		public int IdAuditoria 
		{
			get { return GetColumnValue<int>(Columns.IdAuditoria); }
			set { SetColumnValue(Columns.IdAuditoria, value); }
		}
		  
		[XmlAttribute("IdAgenda")]
		[Bindable(true)]
		public int IdAgenda 
		{
			get { return GetColumnValue<int>(Columns.IdAgenda); }
			set { SetColumnValue(Columns.IdAgenda, value); }
		}
		  
		[XmlAttribute("IdAgendaEstado")]
		[Bindable(true)]
		public int IdAgendaEstado 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaEstado); }
			set { SetColumnValue(Columns.IdAgendaEstado, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
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
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("HoraInicio")]
		[Bindable(true)]
		public string HoraInicio 
		{
			get { return GetColumnValue<string>(Columns.HoraInicio); }
			set { SetColumnValue(Columns.HoraInicio, value); }
		}
		  
		[XmlAttribute("HoraFin")]
		[Bindable(true)]
		public string HoraFin 
		{
			get { return GetColumnValue<string>(Columns.HoraFin); }
			set { SetColumnValue(Columns.HoraFin, value); }
		}
		  
		[XmlAttribute("Duracion")]
		[Bindable(true)]
		public int Duracion 
		{
			get { return GetColumnValue<int>(Columns.Duracion); }
			set { SetColumnValue(Columns.Duracion, value); }
		}
		  
		[XmlAttribute("Reservados")]
		[Bindable(true)]
		public int Reservados 
		{
			get { return GetColumnValue<int>(Columns.Reservados); }
			set { SetColumnValue(Columns.Reservados, value); }
		}
		  
		[XmlAttribute("MaxSobreturnos")]
		[Bindable(true)]
		public int MaxSobreturnos 
		{
			get { return GetColumnValue<int>(Columns.MaxSobreturnos); }
			set { SetColumnValue(Columns.MaxSobreturnos, value); }
		}
		  
		[XmlAttribute("CitarPorBloques")]
		[Bindable(true)]
		public int CitarPorBloques 
		{
			get { return GetColumnValue<int>(Columns.CitarPorBloques); }
			set { SetColumnValue(Columns.CitarPorBloques, value); }
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
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConAgendaEstado ActiveRecord object related to this ConAgendaAuditorium
		/// 
		/// </summary>
		public DalSic.ConAgendaEstado ConAgendaEstado
		{
			get { return DalSic.ConAgendaEstado.FetchByID(this.IdAgendaEstado); }
			set { SetColumnValue("idAgendaEstado", value.IdAgendaEstado); }
		}
		
		
		/// <summary>
		/// Returns a ConAgendaEstado ActiveRecord object related to this ConAgendaAuditorium
		/// 
		/// </summary>
		public DalSic.ConAgendaEstado ConAgendaEstadoToIdAgendaEstado
		{
			get { return DalSic.ConAgendaEstado.FetchByID(this.IdAgendaEstado); }
			set { SetColumnValue("idAgendaEstado", value.IdAgendaEstado); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgenda,int varIdAgendaEstado,int varIdEfector,int varIdServicio,int varIdProfesional,int varIdEspecialidad,int varIdConsultorio,int varIdUsuario,DateTime varFecha,string varHoraInicio,string varHoraFin,int varDuracion,int varReservados,int varMaxSobreturnos,int varCitarPorBloques,DateTime varFechaModificacion,string varHoraModificacion)
		{
			ConAgendaAuditorium item = new ConAgendaAuditorium();
			
			item.IdAgenda = varIdAgenda;
			
			item.IdAgendaEstado = varIdAgendaEstado;
			
			item.IdEfector = varIdEfector;
			
			item.IdServicio = varIdServicio;
			
			item.IdProfesional = varIdProfesional;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdConsultorio = varIdConsultorio;
			
			item.IdUsuario = varIdUsuario;
			
			item.Fecha = varFecha;
			
			item.HoraInicio = varHoraInicio;
			
			item.HoraFin = varHoraFin;
			
			item.Duracion = varDuracion;
			
			item.Reservados = varReservados;
			
			item.MaxSobreturnos = varMaxSobreturnos;
			
			item.CitarPorBloques = varCitarPorBloques;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.HoraModificacion = varHoraModificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAuditoria,int varIdAgenda,int varIdAgendaEstado,int varIdEfector,int varIdServicio,int varIdProfesional,int varIdEspecialidad,int varIdConsultorio,int varIdUsuario,DateTime varFecha,string varHoraInicio,string varHoraFin,int varDuracion,int varReservados,int varMaxSobreturnos,int varCitarPorBloques,DateTime varFechaModificacion,string varHoraModificacion)
		{
			ConAgendaAuditorium item = new ConAgendaAuditorium();
			
				item.IdAuditoria = varIdAuditoria;
			
				item.IdAgenda = varIdAgenda;
			
				item.IdAgendaEstado = varIdAgendaEstado;
			
				item.IdEfector = varIdEfector;
			
				item.IdServicio = varIdServicio;
			
				item.IdProfesional = varIdProfesional;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdConsultorio = varIdConsultorio;
			
				item.IdUsuario = varIdUsuario;
			
				item.Fecha = varFecha;
			
				item.HoraInicio = varHoraInicio;
			
				item.HoraFin = varHoraFin;
			
				item.Duracion = varDuracion;
			
				item.Reservados = varReservados;
			
				item.MaxSobreturnos = varMaxSobreturnos;
			
				item.CitarPorBloques = varCitarPorBloques;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.HoraModificacion = varHoraModificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAuditoriaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaEstadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
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
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraInicioColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraFinColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DuracionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ReservadosColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn MaxSobreturnosColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CitarPorBloquesColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraModificacionColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAuditoria = @"idAuditoria";
			 public static string IdAgenda = @"idAgenda";
			 public static string IdAgendaEstado = @"idAgendaEstado";
			 public static string IdEfector = @"idEfector";
			 public static string IdServicio = @"idServicio";
			 public static string IdProfesional = @"idProfesional";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdConsultorio = @"idConsultorio";
			 public static string IdUsuario = @"idUsuario";
			 public static string Fecha = @"fecha";
			 public static string HoraInicio = @"horaInicio";
			 public static string HoraFin = @"horaFin";
			 public static string Duracion = @"duracion";
			 public static string Reservados = @"reservados";
			 public static string MaxSobreturnos = @"maxSobreturnos";
			 public static string CitarPorBloques = @"citarPorBloques";
			 public static string FechaModificacion = @"fechaModificacion";
			 public static string HoraModificacion = @"horaModificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
