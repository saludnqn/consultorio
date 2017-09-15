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
	/// Strongly-typed collection for the SysUsuario class.
	/// </summary>
    [Serializable]
	public partial class SysUsuarioCollection : ActiveList<SysUsuario, SysUsuarioCollection>
	{	   
		public SysUsuarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysUsuarioCollection</returns>
		public SysUsuarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysUsuario o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Usuario table.
	/// </summary>
	[Serializable]
	public partial class SysUsuario : ActiveRecord<SysUsuario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysUsuario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysUsuario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysUsuario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysUsuario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Usuario", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = true;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = true;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
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
				
				TableSchema.TableColumn colvarIdPerfil = new TableSchema.TableColumn(schema);
				colvarIdPerfil.ColumnName = "idPerfil";
				colvarIdPerfil.DataType = DbType.Int32;
				colvarIdPerfil.MaxLength = 0;
				colvarIdPerfil.AutoIncrement = false;
				colvarIdPerfil.IsNullable = false;
				colvarIdPerfil.IsPrimaryKey = false;
				colvarIdPerfil.IsForeignKey = true;
				colvarIdPerfil.IsReadOnly = false;
				
						colvarIdPerfil.DefaultSetting = @"((0))";
				
					colvarIdPerfil.ForeignKeyTableName = "Sys_Perfil";
				schema.Columns.Add(colvarIdPerfil);
				
				TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
				colvarDocumento.ColumnName = "documento";
				colvarDocumento.DataType = DbType.Int32;
				colvarDocumento.MaxLength = 0;
				colvarDocumento.AutoIncrement = false;
				colvarDocumento.IsNullable = false;
				colvarDocumento.IsPrimaryKey = false;
				colvarDocumento.IsForeignKey = false;
				colvarDocumento.IsReadOnly = false;
				
						colvarDocumento.DefaultSetting = @"((0))";
				colvarDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumento);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.String;
				colvarApellido.MaxLength = 50;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = false;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarLegajo = new TableSchema.TableColumn(schema);
				colvarLegajo.ColumnName = "legajo";
				colvarLegajo.DataType = DbType.String;
				colvarLegajo.MaxLength = 50;
				colvarLegajo.AutoIncrement = false;
				colvarLegajo.IsNullable = false;
				colvarLegajo.IsPrimaryKey = false;
				colvarLegajo.IsForeignKey = false;
				colvarLegajo.IsReadOnly = false;
				
						colvarLegajo.DefaultSetting = @"('')";
				colvarLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLegajo);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 100;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = false;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				
						colvarEmail.DefaultSetting = @"('')";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = 50;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = false;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				
						colvarTelefono.DefaultSetting = @"('')";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 500;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = false;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				
						colvarObservacion.DefaultSetting = @"('')";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
				colvarUsername.ColumnName = "username";
				colvarUsername.DataType = DbType.String;
				colvarUsername.MaxLength = 50;
				colvarUsername.AutoIncrement = false;
				colvarUsername.IsNullable = false;
				colvarUsername.IsPrimaryKey = false;
				colvarUsername.IsForeignKey = false;
				colvarUsername.IsReadOnly = false;
				colvarUsername.DefaultSetting = @"";
				colvarUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsername);
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "password";
				colvarPassword.DataType = DbType.String;
				colvarPassword.MaxLength = 50;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = false;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				colvarPassword.DefaultSetting = @"";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarIdUsuarioActualizacion = new TableSchema.TableColumn(schema);
				colvarIdUsuarioActualizacion.ColumnName = "idUsuarioActualizacion";
				colvarIdUsuarioActualizacion.DataType = DbType.Int32;
				colvarIdUsuarioActualizacion.MaxLength = 0;
				colvarIdUsuarioActualizacion.AutoIncrement = false;
				colvarIdUsuarioActualizacion.IsNullable = false;
				colvarIdUsuarioActualizacion.IsPrimaryKey = false;
				colvarIdUsuarioActualizacion.IsForeignKey = false;
				colvarIdUsuarioActualizacion.IsReadOnly = false;
				colvarIdUsuarioActualizacion.DefaultSetting = @"";
				colvarIdUsuarioActualizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioActualizacion);
				
				TableSchema.TableColumn colvarFechaActualizacion = new TableSchema.TableColumn(schema);
				colvarFechaActualizacion.ColumnName = "fechaActualizacion";
				colvarFechaActualizacion.DataType = DbType.DateTime;
				colvarFechaActualizacion.MaxLength = 0;
				colvarFechaActualizacion.AutoIncrement = false;
				colvarFechaActualizacion.IsNullable = false;
				colvarFechaActualizacion.IsPrimaryKey = false;
				colvarFechaActualizacion.IsForeignKey = false;
				colvarFechaActualizacion.IsReadOnly = false;
				colvarFechaActualizacion.DefaultSetting = @"";
				colvarFechaActualizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaActualizacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Usuario",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdPerfil")]
		[Bindable(true)]
		public int IdPerfil 
		{
			get { return GetColumnValue<int>(Columns.IdPerfil); }
			set { SetColumnValue(Columns.IdPerfil, value); }
		}
		  
		[XmlAttribute("Documento")]
		[Bindable(true)]
		public int Documento 
		{
			get { return GetColumnValue<int>(Columns.Documento); }
			set { SetColumnValue(Columns.Documento, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Legajo")]
		[Bindable(true)]
		public string Legajo 
		{
			get { return GetColumnValue<string>(Columns.Legajo); }
			set { SetColumnValue(Columns.Legajo, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("Username")]
		[Bindable(true)]
		public string Username 
		{
			get { return GetColumnValue<string>(Columns.Username); }
			set { SetColumnValue(Columns.Username, value); }
		}
		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }
			set { SetColumnValue(Columns.Password, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("IdUsuarioActualizacion")]
		[Bindable(true)]
		public int IdUsuarioActualizacion 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioActualizacion); }
			set { SetColumnValue(Columns.IdUsuarioActualizacion, value); }
		}
		  
		[XmlAttribute("FechaActualizacion")]
		[Bindable(true)]
		public DateTime FechaActualizacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaActualizacion); }
			set { SetColumnValue(Columns.FechaActualizacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.ConTurnoReservaCollection colConTurnoReservaRecords;
		public DalSic.ConTurnoReservaCollection ConTurnoReservaRecords
		{
			get
			{
				if(colConTurnoReservaRecords == null)
				{
					colConTurnoReservaRecords = new DalSic.ConTurnoReservaCollection().Where(ConTurnoReserva.Columns.IdUsuario, IdUsuario).Load();
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
		        colConTurnoReservaRecords[e.NewIndex].IdUsuario = IdUsuario;
		    }
		}
				
		private DalSic.RemFormularioCollection colRemFormularioRecords;
		public DalSic.RemFormularioCollection RemFormularioRecords
		{
			get
			{
				if(colRemFormularioRecords == null)
				{
					colRemFormularioRecords = new DalSic.RemFormularioCollection().Where(RemFormulario.Columns.ModifiedBy, IdUsuario).Load();
					colRemFormularioRecords.ListChanged += new ListChangedEventHandler(colRemFormularioRecords_ListChanged);
				}
				return colRemFormularioRecords;			
			}
			set 
			{ 
					colRemFormularioRecords = value; 
					colRemFormularioRecords.ListChanged += new ListChangedEventHandler(colRemFormularioRecords_ListChanged);
			}
		}
		
		void colRemFormularioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemFormularioRecords[e.NewIndex].ModifiedBy = IdUsuario;
		    }
		}
				
		private DalSic.RemFormularioCollection colRemFormularioRecordsFromSysUsuario;
		public DalSic.RemFormularioCollection RemFormularioRecordsFromSysUsuario
		{
			get
			{
				if(colRemFormularioRecordsFromSysUsuario == null)
				{
					colRemFormularioRecordsFromSysUsuario = new DalSic.RemFormularioCollection().Where(RemFormulario.Columns.CreatedBy, IdUsuario).Load();
					colRemFormularioRecordsFromSysUsuario.ListChanged += new ListChangedEventHandler(colRemFormularioRecordsFromSysUsuario_ListChanged);
				}
				return colRemFormularioRecordsFromSysUsuario;			
			}
			set 
			{ 
					colRemFormularioRecordsFromSysUsuario = value; 
					colRemFormularioRecordsFromSysUsuario.ListChanged += new ListChangedEventHandler(colRemFormularioRecordsFromSysUsuario_ListChanged);
			}
		}
		
		void colRemFormularioRecordsFromSysUsuario_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemFormularioRecordsFromSysUsuario[e.NewIndex].CreatedBy = IdUsuario;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysUsuario
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysPerfil ActiveRecord object related to this SysUsuario
		/// 
		/// </summary>
		public DalSic.SysPerfil SysPerfil
		{
			get { return DalSic.SysPerfil.FetchByID(this.IdPerfil); }
			set { SetColumnValue("idPerfil", value.IdPerfil); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPerfil,int varDocumento,string varApellido,string varNombre,string varLegajo,string varEmail,string varTelefono,string varObservacion,string varUsername,string varPassword,bool varActivo,int varIdUsuarioActualizacion,DateTime varFechaActualizacion)
		{
			SysUsuario item = new SysUsuario();
			
			item.IdEfector = varIdEfector;
			
			item.IdPerfil = varIdPerfil;
			
			item.Documento = varDocumento;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.Legajo = varLegajo;
			
			item.Email = varEmail;
			
			item.Telefono = varTelefono;
			
			item.Observacion = varObservacion;
			
			item.Username = varUsername;
			
			item.Password = varPassword;
			
			item.Activo = varActivo;
			
			item.IdUsuarioActualizacion = varIdUsuarioActualizacion;
			
			item.FechaActualizacion = varFechaActualizacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdUsuario,int varIdEfector,int varIdPerfil,int varDocumento,string varApellido,string varNombre,string varLegajo,string varEmail,string varTelefono,string varObservacion,string varUsername,string varPassword,bool varActivo,int varIdUsuarioActualizacion,DateTime varFechaActualizacion)
		{
			SysUsuario item = new SysUsuario();
			
				item.IdUsuario = varIdUsuario;
			
				item.IdEfector = varIdEfector;
			
				item.IdPerfil = varIdPerfil;
			
				item.Documento = varDocumento;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.Legajo = varLegajo;
			
				item.Email = varEmail;
			
				item.Telefono = varTelefono;
			
				item.Observacion = varObservacion;
			
				item.Username = varUsername;
			
				item.Password = varPassword;
			
				item.Activo = varActivo;
			
				item.IdUsuarioActualizacion = varIdUsuarioActualizacion;
			
				item.FechaActualizacion = varFechaActualizacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPerfilColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn LegajoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn UsernameColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioActualizacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaActualizacionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdUsuario = @"idUsuario";
			 public static string IdEfector = @"idEfector";
			 public static string IdPerfil = @"idPerfil";
			 public static string Documento = @"documento";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string Legajo = @"legajo";
			 public static string Email = @"email";
			 public static string Telefono = @"telefono";
			 public static string Observacion = @"observacion";
			 public static string Username = @"username";
			 public static string Password = @"password";
			 public static string Activo = @"activo";
			 public static string IdUsuarioActualizacion = @"idUsuarioActualizacion";
			 public static string FechaActualizacion = @"fechaActualizacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConTurnoReservaRecords != null)
                {
                    foreach (DalSic.ConTurnoReserva item in colConTurnoReservaRecords)
                    {
                        if (item.IdUsuario != IdUsuario)
                        {
                            item.IdUsuario = IdUsuario;
                        }
                    }
               }
		
                if (colRemFormularioRecords != null)
                {
                    foreach (DalSic.RemFormulario item in colRemFormularioRecords)
                    {
                        if (item.ModifiedBy != IdUsuario)
                        {
                            item.ModifiedBy = IdUsuario;
                        }
                    }
               }
		
                if (colRemFormularioRecordsFromSysUsuario != null)
                {
                    foreach (DalSic.RemFormulario item in colRemFormularioRecordsFromSysUsuario)
                    {
                        if (item.CreatedBy != IdUsuario)
                        {
                            item.CreatedBy = IdUsuario;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConTurnoReservaRecords != null)
                {
                    colConTurnoReservaRecords.SaveAll();
               }
		
                if (colRemFormularioRecords != null)
                {
                    colRemFormularioRecords.SaveAll();
               }
		
                if (colRemFormularioRecordsFromSysUsuario != null)
                {
                    colRemFormularioRecordsFromSysUsuario.SaveAll();
               }
		}
        #endregion
	}
}
