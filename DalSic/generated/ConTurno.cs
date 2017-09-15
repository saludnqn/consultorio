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
	/// Strongly-typed collection for the ConTurno class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoCollection : ActiveList<ConTurno, ConTurnoCollection>
	{	   
		public ConTurnoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoCollection</returns>
		public ConTurnoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurno o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_Turno table.
	/// </summary>
	[Serializable]
	public partial class ConTurno : ActiveRecord<ConTurno>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurno()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurno(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurno(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurno(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_Turno", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTurno = new TableSchema.TableColumn(schema);
				colvarIdTurno.ColumnName = "idTurno";
				colvarIdTurno.DataType = DbType.Int32;
				colvarIdTurno.MaxLength = 0;
				colvarIdTurno.AutoIncrement = true;
				colvarIdTurno.IsNullable = false;
				colvarIdTurno.IsPrimaryKey = true;
				colvarIdTurno.IsForeignKey = false;
				colvarIdTurno.IsReadOnly = false;
				colvarIdTurno.DefaultSetting = @"";
				colvarIdTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurno);
				
				TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
				colvarIdAgenda.ColumnName = "idAgenda";
				colvarIdAgenda.DataType = DbType.Int32;
				colvarIdAgenda.MaxLength = 0;
				colvarIdAgenda.AutoIncrement = false;
				colvarIdAgenda.IsNullable = false;
				colvarIdAgenda.IsPrimaryKey = false;
				colvarIdAgenda.IsForeignKey = true;
				colvarIdAgenda.IsReadOnly = false;
				colvarIdAgenda.DefaultSetting = @"";
				
					colvarIdAgenda.ForeignKeyTableName = "CON_Agenda";
				schema.Columns.Add(colvarIdAgenda);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarHora = new TableSchema.TableColumn(schema);
				colvarHora.ColumnName = "hora";
				colvarHora.DataType = DbType.AnsiStringFixedLength;
				colvarHora.MaxLength = 5;
				colvarHora.AutoIncrement = false;
				colvarHora.IsNullable = false;
				colvarHora.IsPrimaryKey = false;
				colvarHora.IsForeignKey = false;
				colvarHora.IsReadOnly = false;
				colvarHora.DefaultSetting = @"";
				colvarHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHora);
				
				TableSchema.TableColumn colvarSobreturno = new TableSchema.TableColumn(schema);
				colvarSobreturno.ColumnName = "sobreturno";
				colvarSobreturno.DataType = DbType.Boolean;
				colvarSobreturno.MaxLength = 0;
				colvarSobreturno.AutoIncrement = false;
				colvarSobreturno.IsNullable = false;
				colvarSobreturno.IsPrimaryKey = false;
				colvarSobreturno.IsForeignKey = false;
				colvarSobreturno.IsReadOnly = false;
				
						colvarSobreturno.DefaultSetting = @"((0))";
				colvarSobreturno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSobreturno);
				
				TableSchema.TableColumn colvarIdTipoTurno = new TableSchema.TableColumn(schema);
				colvarIdTipoTurno.ColumnName = "idTipoTurno";
				colvarIdTipoTurno.DataType = DbType.Int32;
				colvarIdTipoTurno.MaxLength = 0;
				colvarIdTipoTurno.AutoIncrement = false;
				colvarIdTipoTurno.IsNullable = false;
				colvarIdTipoTurno.IsPrimaryKey = false;
				colvarIdTipoTurno.IsForeignKey = false;
				colvarIdTipoTurno.IsReadOnly = false;
				
						colvarIdTipoTurno.DefaultSetting = @"((0))";
				colvarIdTipoTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoTurno);
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = false;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = false;
				colvarIdObraSocial.IsReadOnly = false;
				
						colvarIdObraSocial.DefaultSetting = @"((0))";
				colvarIdObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdObraSocial);
				
				TableSchema.TableColumn colvarIdTurnoAcompaniante = new TableSchema.TableColumn(schema);
				colvarIdTurnoAcompaniante.ColumnName = "idTurnoAcompaniante";
				colvarIdTurnoAcompaniante.DataType = DbType.Int32;
				colvarIdTurnoAcompaniante.MaxLength = 0;
				colvarIdTurnoAcompaniante.AutoIncrement = false;
				colvarIdTurnoAcompaniante.IsNullable = false;
				colvarIdTurnoAcompaniante.IsPrimaryKey = false;
				colvarIdTurnoAcompaniante.IsForeignKey = false;
				colvarIdTurnoAcompaniante.IsReadOnly = false;
				
						colvarIdTurnoAcompaniante.DefaultSetting = @"((0))";
				colvarIdTurnoAcompaniante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoAcompaniante);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_Turno",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTurno")]
		[Bindable(true)]
		public int IdTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTurno); }
			set { SetColumnValue(Columns.IdTurno, value); }
		}
		  
		[XmlAttribute("IdAgenda")]
		[Bindable(true)]
		public int IdAgenda 
		{
			get { return GetColumnValue<int>(Columns.IdAgenda); }
			set { SetColumnValue(Columns.IdAgenda, value); }
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
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
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
		  
		[XmlAttribute("Sobreturno")]
		[Bindable(true)]
		public bool Sobreturno 
		{
			get { return GetColumnValue<bool>(Columns.Sobreturno); }
			set { SetColumnValue(Columns.Sobreturno, value); }
		}
		  
		[XmlAttribute("IdTipoTurno")]
		[Bindable(true)]
		public int IdTipoTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTipoTurno); }
			set { SetColumnValue(Columns.IdTipoTurno, value); }
		}
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int IdObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("IdTurnoAcompaniante")]
		[Bindable(true)]
		public int IdTurnoAcompaniante 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoAcompaniante); }
			set { SetColumnValue(Columns.IdTurnoAcompaniante, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.ConTurnoAsistenciumCollection colConTurnoAsistencia;
		public DalSic.ConTurnoAsistenciumCollection ConTurnoAsistencia
		{
			get
			{
				if(colConTurnoAsistencia == null)
				{
					colConTurnoAsistencia = new DalSic.ConTurnoAsistenciumCollection().Where(ConTurnoAsistencium.Columns.IdTurno, IdTurno).Load();
					colConTurnoAsistencia.ListChanged += new ListChangedEventHandler(colConTurnoAsistencia_ListChanged);
				}
				return colConTurnoAsistencia;			
			}
			set 
			{ 
					colConTurnoAsistencia = value; 
					colConTurnoAsistencia.ListChanged += new ListChangedEventHandler(colConTurnoAsistencia_ListChanged);
			}
		}
		
		void colConTurnoAsistencia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoAsistencia[e.NewIndex].IdTurno = IdTurno;
		    }
		}
				
		private DalSic.ConTurnoAuditoriumCollection colConTurnoAuditoria;
		public DalSic.ConTurnoAuditoriumCollection ConTurnoAuditoria
		{
			get
			{
				if(colConTurnoAuditoria == null)
				{
					colConTurnoAuditoria = new DalSic.ConTurnoAuditoriumCollection().Where(ConTurnoAuditorium.Columns.IdTurno, IdTurno).Load();
					colConTurnoAuditoria.ListChanged += new ListChangedEventHandler(colConTurnoAuditoria_ListChanged);
				}
				return colConTurnoAuditoria;			
			}
			set 
			{ 
					colConTurnoAuditoria = value; 
					colConTurnoAuditoria.ListChanged += new ListChangedEventHandler(colConTurnoAuditoria_ListChanged);
			}
		}
		
		void colConTurnoAuditoria_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoAuditoria[e.NewIndex].IdTurno = IdTurno;
		    }
		}
				
		private DalSic.ConTurnoRecitumCollection colConTurnoRecita;
		public DalSic.ConTurnoRecitumCollection ConTurnoRecita
		{
			get
			{
				if(colConTurnoRecita == null)
				{
					colConTurnoRecita = new DalSic.ConTurnoRecitumCollection().Where(ConTurnoRecitum.Columns.IdTurnoAnterior, IdTurno).Load();
					colConTurnoRecita.ListChanged += new ListChangedEventHandler(colConTurnoRecita_ListChanged);
				}
				return colConTurnoRecita;			
			}
			set 
			{ 
					colConTurnoRecita = value; 
					colConTurnoRecita.ListChanged += new ListChangedEventHandler(colConTurnoRecita_ListChanged);
			}
		}
		
		void colConTurnoRecita_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoRecita[e.NewIndex].IdTurnoAnterior = IdTurno;
		    }
		}
				
		private DalSic.ConTurnoRecitumCollection colConTurnoRecitaFromConTurno;
		public DalSic.ConTurnoRecitumCollection ConTurnoRecitaFromConTurno
		{
			get
			{
				if(colConTurnoRecitaFromConTurno == null)
				{
					colConTurnoRecitaFromConTurno = new DalSic.ConTurnoRecitumCollection().Where(ConTurnoRecitum.Columns.IdTurnoActual, IdTurno).Load();
					colConTurnoRecitaFromConTurno.ListChanged += new ListChangedEventHandler(colConTurnoRecitaFromConTurno_ListChanged);
				}
				return colConTurnoRecitaFromConTurno;			
			}
			set 
			{ 
					colConTurnoRecitaFromConTurno = value; 
					colConTurnoRecitaFromConTurno.ListChanged += new ListChangedEventHandler(colConTurnoRecitaFromConTurno_ListChanged);
			}
		}
		
		void colConTurnoRecitaFromConTurno_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoRecitaFromConTurno[e.NewIndex].IdTurnoActual = IdTurno;
		    }
		}
				
		private DalSic.ConTurnoReservaCollection colConTurnoReservaRecords;
		public DalSic.ConTurnoReservaCollection ConTurnoReservaRecords
		{
			get
			{
				if(colConTurnoReservaRecords == null)
				{
					colConTurnoReservaRecords = new DalSic.ConTurnoReservaCollection().Where(ConTurnoReserva.Columns.IdTurno, IdTurno).Load();
					colConTurnoReservaRecords.ListChanged += new ListChangedEventHandler(colConTurnoReservaRecords_ListChanged);
				}
				return colConTurnoReservaRecords;			
			}
			set 
			{ 
					colConTurnoReservaRecords = value; 
					colConTurnoReservaRecords.ListChanged += new ListChangedEventHandler(colConTurnoReservaRecords_ListChanged);
			}
		}
		
		void colConTurnoReservaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoReservaRecords[e.NewIndex].IdTurno = IdTurno;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this ConTurno
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a ConAgenda ActiveRecord object related to this ConTurno
		/// 
		/// </summary>
		public DalSic.ConAgenda ConAgenda
		{
			get { return DalSic.ConAgenda.FetchByID(this.IdAgenda); }
			set { SetColumnValue("idAgenda", value.IdAgenda); }
		}
		
		
		/// <summary>
		/// Returns a ConTurnoEstado ActiveRecord object related to this ConTurno
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
		public static void Insert(int varIdAgenda,int varIdTurnoEstado,int varIdUsuario,int varIdPaciente,DateTime varFecha,string varHora,bool varSobreturno,int varIdTipoTurno,int varIdObraSocial,int varIdTurnoAcompaniante)
		{
			ConTurno item = new ConTurno();
			
			item.IdAgenda = varIdAgenda;
			
			item.IdTurnoEstado = varIdTurnoEstado;
			
			item.IdUsuario = varIdUsuario;
			
			item.IdPaciente = varIdPaciente;
			
			item.Fecha = varFecha;
			
			item.Hora = varHora;
			
			item.Sobreturno = varSobreturno;
			
			item.IdTipoTurno = varIdTipoTurno;
			
			item.IdObraSocial = varIdObraSocial;
			
			item.IdTurnoAcompaniante = varIdTurnoAcompaniante;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTurno,int varIdAgenda,int varIdTurnoEstado,int varIdUsuario,int varIdPaciente,DateTime varFecha,string varHora,bool varSobreturno,int varIdTipoTurno,int varIdObraSocial,int varIdTurnoAcompaniante)
		{
			ConTurno item = new ConTurno();
			
				item.IdTurno = varIdTurno;
			
				item.IdAgenda = varIdAgenda;
			
				item.IdTurnoEstado = varIdTurnoEstado;
			
				item.IdUsuario = varIdUsuario;
			
				item.IdPaciente = varIdPaciente;
			
				item.Fecha = varFecha;
			
				item.Hora = varHora;
			
				item.Sobreturno = varSobreturno;
			
				item.IdTipoTurno = varIdTipoTurno;
			
				item.IdObraSocial = varIdObraSocial;
			
				item.IdTurnoAcompaniante = varIdTurnoAcompaniante;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTurnoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaColumn
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
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SobreturnoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoTurnoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoAcompanianteColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTurno = @"idTurno";
			 public static string IdAgenda = @"idAgenda";
			 public static string IdTurnoEstado = @"idTurnoEstado";
			 public static string IdUsuario = @"idUsuario";
			 public static string IdPaciente = @"idPaciente";
			 public static string Fecha = @"fecha";
			 public static string Hora = @"hora";
			 public static string Sobreturno = @"sobreturno";
			 public static string IdTipoTurno = @"idTipoTurno";
			 public static string IdObraSocial = @"idObraSocial";
			 public static string IdTurnoAcompaniante = @"idTurnoAcompaniante";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConTurnoAsistencia != null)
                {
                    foreach (DalSic.ConTurnoAsistencium item in colConTurnoAsistencia)
                    {
                        if (item.IdTurno != IdTurno)
                        {
                            item.IdTurno = IdTurno;
                        }
                    }
               }
		
                if (colConTurnoAuditoria != null)
                {
                    foreach (DalSic.ConTurnoAuditorium item in colConTurnoAuditoria)
                    {
                        if (item.IdTurno != IdTurno)
                        {
                            item.IdTurno = IdTurno;
                        }
                    }
               }
		
                if (colConTurnoRecita != null)
                {
                    foreach (DalSic.ConTurnoRecitum item in colConTurnoRecita)
                    {
                        if (item.IdTurnoAnterior != IdTurno)
                        {
                            item.IdTurnoAnterior = IdTurno;
                        }
                    }
               }
		
                if (colConTurnoRecitaFromConTurno != null)
                {
                    foreach (DalSic.ConTurnoRecitum item in colConTurnoRecitaFromConTurno)
                    {
                        if (item.IdTurnoActual != IdTurno)
                        {
                            item.IdTurnoActual = IdTurno;
                        }
                    }
               }
		
                if (colConTurnoReservaRecords != null)
                {
                    foreach (DalSic.ConTurnoReserva item in colConTurnoReservaRecords)
                    {
                        if (item.IdTurno != IdTurno)
                        {
                            item.IdTurno = IdTurno;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConTurnoAsistencia != null)
                {
                    colConTurnoAsistencia.SaveAll();
               }
		
                if (colConTurnoAuditoria != null)
                {
                    colConTurnoAuditoria.SaveAll();
               }
		
                if (colConTurnoRecita != null)
                {
                    colConTurnoRecita.SaveAll();
               }
		
                if (colConTurnoRecitaFromConTurno != null)
                {
                    colConTurnoRecitaFromConTurno.SaveAll();
               }
		
                if (colConTurnoReservaRecords != null)
                {
                    colConTurnoReservaRecords.SaveAll();
               }
		}
        #endregion
	}
}
