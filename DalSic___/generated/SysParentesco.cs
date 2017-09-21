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
	/// Strongly-typed collection for the SysParentesco class.
	/// </summary>
    [Serializable]
	public partial class SysParentescoCollection : ActiveList<SysParentesco, SysParentescoCollection>
	{	   
		public SysParentescoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysParentescoCollection</returns>
		public SysParentescoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysParentesco o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Parentesco table.
	/// </summary>
	[Serializable]
	public partial class SysParentesco : ActiveRecord<SysParentesco>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysParentesco()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysParentesco(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysParentesco(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysParentesco(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Parentesco", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdParentesco = new TableSchema.TableColumn(schema);
				colvarIdParentesco.ColumnName = "idParentesco";
				colvarIdParentesco.DataType = DbType.Int32;
				colvarIdParentesco.MaxLength = 0;
				colvarIdParentesco.AutoIncrement = true;
				colvarIdParentesco.IsNullable = false;
				colvarIdParentesco.IsPrimaryKey = true;
				colvarIdParentesco.IsForeignKey = false;
				colvarIdParentesco.IsReadOnly = false;
				colvarIdParentesco.DefaultSetting = @"";
				colvarIdParentesco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdParentesco);
				
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
				
				TableSchema.TableColumn colvarIdTipoDocumento = new TableSchema.TableColumn(schema);
				colvarIdTipoDocumento.ColumnName = "idTipoDocumento";
				colvarIdTipoDocumento.DataType = DbType.Int32;
				colvarIdTipoDocumento.MaxLength = 0;
				colvarIdTipoDocumento.AutoIncrement = false;
				colvarIdTipoDocumento.IsNullable = false;
				colvarIdTipoDocumento.IsPrimaryKey = false;
				colvarIdTipoDocumento.IsForeignKey = true;
				colvarIdTipoDocumento.IsReadOnly = false;
				colvarIdTipoDocumento.DefaultSetting = @"";
				
					colvarIdTipoDocumento.ForeignKeyTableName = "Sys_TipoDocumento";
				schema.Columns.Add(colvarIdTipoDocumento);
				
				TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
				colvarNumeroDocumento.ColumnName = "numeroDocumento";
				colvarNumeroDocumento.DataType = DbType.Int32;
				colvarNumeroDocumento.MaxLength = 0;
				colvarNumeroDocumento.AutoIncrement = false;
				colvarNumeroDocumento.IsNullable = false;
				colvarNumeroDocumento.IsPrimaryKey = false;
				colvarNumeroDocumento.IsForeignKey = false;
				colvarNumeroDocumento.IsReadOnly = false;
				colvarNumeroDocumento.DefaultSetting = @"";
				colvarNumeroDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDocumento);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = false;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				
						colvarFechaNacimiento.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarIdProvincia = new TableSchema.TableColumn(schema);
				colvarIdProvincia.ColumnName = "idProvincia";
				colvarIdProvincia.DataType = DbType.Int32;
				colvarIdProvincia.MaxLength = 0;
				colvarIdProvincia.AutoIncrement = false;
				colvarIdProvincia.IsNullable = false;
				colvarIdProvincia.IsPrimaryKey = false;
				colvarIdProvincia.IsForeignKey = true;
				colvarIdProvincia.IsReadOnly = false;
				
						colvarIdProvincia.DefaultSetting = @"((0))";
				
					colvarIdProvincia.ForeignKeyTableName = "Sys_Provincia";
				schema.Columns.Add(colvarIdProvincia);
				
				TableSchema.TableColumn colvarIdPais = new TableSchema.TableColumn(schema);
				colvarIdPais.ColumnName = "idPais";
				colvarIdPais.DataType = DbType.Int32;
				colvarIdPais.MaxLength = 0;
				colvarIdPais.AutoIncrement = false;
				colvarIdPais.IsNullable = false;
				colvarIdPais.IsPrimaryKey = false;
				colvarIdPais.IsForeignKey = true;
				colvarIdPais.IsReadOnly = false;
				
						colvarIdPais.DefaultSetting = @"((0))";
				
					colvarIdPais.ForeignKeyTableName = "Sys_Pais";
				schema.Columns.Add(colvarIdPais);
				
				TableSchema.TableColumn colvarIdSituacionLaboral = new TableSchema.TableColumn(schema);
				colvarIdSituacionLaboral.ColumnName = "idSituacionLaboral";
				colvarIdSituacionLaboral.DataType = DbType.Int32;
				colvarIdSituacionLaboral.MaxLength = 0;
				colvarIdSituacionLaboral.AutoIncrement = false;
				colvarIdSituacionLaboral.IsNullable = false;
				colvarIdSituacionLaboral.IsPrimaryKey = false;
				colvarIdSituacionLaboral.IsForeignKey = true;
				colvarIdSituacionLaboral.IsReadOnly = false;
				
						colvarIdSituacionLaboral.DefaultSetting = @"((0))";
				
					colvarIdSituacionLaboral.ForeignKeyTableName = "Sys_SituacionLaboral";
				schema.Columns.Add(colvarIdSituacionLaboral);
				
				TableSchema.TableColumn colvarIdNivelInstruccion = new TableSchema.TableColumn(schema);
				colvarIdNivelInstruccion.ColumnName = "idNivelInstruccion";
				colvarIdNivelInstruccion.DataType = DbType.Int32;
				colvarIdNivelInstruccion.MaxLength = 0;
				colvarIdNivelInstruccion.AutoIncrement = false;
				colvarIdNivelInstruccion.IsNullable = false;
				colvarIdNivelInstruccion.IsPrimaryKey = false;
				colvarIdNivelInstruccion.IsForeignKey = true;
				colvarIdNivelInstruccion.IsReadOnly = false;
				
						colvarIdNivelInstruccion.DefaultSetting = @"((0))";
				
					colvarIdNivelInstruccion.ForeignKeyTableName = "Sys_NivelInstruccion";
				schema.Columns.Add(colvarIdNivelInstruccion);
				
				TableSchema.TableColumn colvarIdProfesion = new TableSchema.TableColumn(schema);
				colvarIdProfesion.ColumnName = "idProfesion";
				colvarIdProfesion.DataType = DbType.Int32;
				colvarIdProfesion.MaxLength = 0;
				colvarIdProfesion.AutoIncrement = false;
				colvarIdProfesion.IsNullable = false;
				colvarIdProfesion.IsPrimaryKey = false;
				colvarIdProfesion.IsForeignKey = true;
				colvarIdProfesion.IsReadOnly = false;
				
						colvarIdProfesion.DefaultSetting = @"((0))";
				
					colvarIdProfesion.ForeignKeyTableName = "Sys_Profesion";
				schema.Columns.Add(colvarIdProfesion);
				
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
				
				TableSchema.TableColumn colvarTipoParentesco = new TableSchema.TableColumn(schema);
				colvarTipoParentesco.ColumnName = "tipoParentesco";
				colvarTipoParentesco.DataType = DbType.String;
				colvarTipoParentesco.MaxLength = 50;
				colvarTipoParentesco.AutoIncrement = false;
				colvarTipoParentesco.IsNullable = false;
				colvarTipoParentesco.IsPrimaryKey = false;
				colvarTipoParentesco.IsForeignKey = false;
				colvarTipoParentesco.IsReadOnly = false;
				colvarTipoParentesco.DefaultSetting = @"";
				colvarTipoParentesco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoParentesco);
				
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
				
				TableSchema.TableColumn colvarIdAntecedente = new TableSchema.TableColumn(schema);
				colvarIdAntecedente.ColumnName = "idAntecedente";
				colvarIdAntecedente.DataType = DbType.Int32;
				colvarIdAntecedente.MaxLength = 0;
				colvarIdAntecedente.AutoIncrement = false;
				colvarIdAntecedente.IsNullable = false;
				colvarIdAntecedente.IsPrimaryKey = false;
				colvarIdAntecedente.IsForeignKey = true;
				colvarIdAntecedente.IsReadOnly = false;
				
						colvarIdAntecedente.DefaultSetting = @"((0))";
				
					colvarIdAntecedente.ForeignKeyTableName = "Sys_Antecedente";
				schema.Columns.Add(colvarIdAntecedente);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Parentesco",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdParentesco")]
		[Bindable(true)]
		public int IdParentesco 
		{
			get { return GetColumnValue<int>(Columns.IdParentesco); }
			set { SetColumnValue(Columns.IdParentesco, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("IdTipoDocumento")]
		[Bindable(true)]
		public int IdTipoDocumento 
		{
			get { return GetColumnValue<int>(Columns.IdTipoDocumento); }
			set { SetColumnValue(Columns.IdTipoDocumento, value); }
		}
		  
		[XmlAttribute("NumeroDocumento")]
		[Bindable(true)]
		public int NumeroDocumento 
		{
			get { return GetColumnValue<int>(Columns.NumeroDocumento); }
			set { SetColumnValue(Columns.NumeroDocumento, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime FechaNacimiento 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("IdProvincia")]
		[Bindable(true)]
		public int IdProvincia 
		{
			get { return GetColumnValue<int>(Columns.IdProvincia); }
			set { SetColumnValue(Columns.IdProvincia, value); }
		}
		  
		[XmlAttribute("IdPais")]
		[Bindable(true)]
		public int IdPais 
		{
			get { return GetColumnValue<int>(Columns.IdPais); }
			set { SetColumnValue(Columns.IdPais, value); }
		}
		  
		[XmlAttribute("IdSituacionLaboral")]
		[Bindable(true)]
		public int IdSituacionLaboral 
		{
			get { return GetColumnValue<int>(Columns.IdSituacionLaboral); }
			set { SetColumnValue(Columns.IdSituacionLaboral, value); }
		}
		  
		[XmlAttribute("IdNivelInstruccion")]
		[Bindable(true)]
		public int IdNivelInstruccion 
		{
			get { return GetColumnValue<int>(Columns.IdNivelInstruccion); }
			set { SetColumnValue(Columns.IdNivelInstruccion, value); }
		}
		  
		[XmlAttribute("IdProfesion")]
		[Bindable(true)]
		public int IdProfesion 
		{
			get { return GetColumnValue<int>(Columns.IdProfesion); }
			set { SetColumnValue(Columns.IdProfesion, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("TipoParentesco")]
		[Bindable(true)]
		public string TipoParentesco 
		{
			get { return GetColumnValue<string>(Columns.TipoParentesco); }
			set { SetColumnValue(Columns.TipoParentesco, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("IdAntecedente")]
		[Bindable(true)]
		public int IdAntecedente 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedente); }
			set { SetColumnValue(Columns.IdAntecedente, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysSituacionLaboral ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysSituacionLaboral SysSituacionLaboral
		{
			get { return DalSic.SysSituacionLaboral.FetchByID(this.IdSituacionLaboral); }
			set { SetColumnValue("idSituacionLaboral", value.IdSituacionLaboral); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesion ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysProfesion SysProfesion
		{
			get { return DalSic.SysProfesion.FetchByID(this.IdProfesion); }
			set { SetColumnValue("idProfesion", value.IdProfesion); }
		}
		
		
		/// <summary>
		/// Returns a SysAntecedente ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysAntecedente SysAntecedente
		{
			get { return DalSic.SysAntecedente.FetchByID(this.IdAntecedente); }
			set { SetColumnValue("idAntecedente", value.IdAntecedente); }
		}
		
		
		/// <summary>
		/// Returns a SysNivelInstruccion ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysNivelInstruccion SysNivelInstruccion
		{
			get { return DalSic.SysNivelInstruccion.FetchByID(this.IdNivelInstruccion); }
			set { SetColumnValue("idNivelInstruccion", value.IdNivelInstruccion); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysPai ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysPai SysPai
		{
			get { return DalSic.SysPai.FetchByID(this.IdPais); }
			set { SetColumnValue("idPais", value.IdPais); }
		}
		
		
		/// <summary>
		/// Returns a SysTipoDocumento ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysTipoDocumento SysTipoDocumento
		{
			get { return DalSic.SysTipoDocumento.FetchByID(this.IdTipoDocumento); }
			set { SetColumnValue("idTipoDocumento", value.IdTipoDocumento); }
		}
		
		
		/// <summary>
		/// Returns a SysProvincium ActiveRecord object related to this SysParentesco
		/// 
		/// </summary>
		public DalSic.SysProvincium SysProvincium
		{
			get { return DalSic.SysProvincium.FetchByID(this.IdProvincia); }
			set { SetColumnValue("idProvincia", value.IdProvincia); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varApellido,int varIdTipoDocumento,int varNumeroDocumento,DateTime varFechaNacimiento,int varIdProvincia,int varIdPais,int varIdSituacionLaboral,int varIdNivelInstruccion,int varIdProfesion,int varIdPaciente,string varTipoParentesco,int varIdUsuario,DateTime varFechaModificacion,int varIdAntecedente)
		{
			SysParentesco item = new SysParentesco();
			
			item.Nombre = varNombre;
			
			item.Apellido = varApellido;
			
			item.IdTipoDocumento = varIdTipoDocumento;
			
			item.NumeroDocumento = varNumeroDocumento;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.IdProvincia = varIdProvincia;
			
			item.IdPais = varIdPais;
			
			item.IdSituacionLaboral = varIdSituacionLaboral;
			
			item.IdNivelInstruccion = varIdNivelInstruccion;
			
			item.IdProfesion = varIdProfesion;
			
			item.IdPaciente = varIdPaciente;
			
			item.TipoParentesco = varTipoParentesco;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.IdAntecedente = varIdAntecedente;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdParentesco,string varNombre,string varApellido,int varIdTipoDocumento,int varNumeroDocumento,DateTime varFechaNacimiento,int varIdProvincia,int varIdPais,int varIdSituacionLaboral,int varIdNivelInstruccion,int varIdProfesion,int varIdPaciente,string varTipoParentesco,int varIdUsuario,DateTime varFechaModificacion,int varIdAntecedente)
		{
			SysParentesco item = new SysParentesco();
			
				item.IdParentesco = varIdParentesco;
			
				item.Nombre = varNombre;
			
				item.Apellido = varApellido;
			
				item.IdTipoDocumento = varIdTipoDocumento;
			
				item.NumeroDocumento = varNumeroDocumento;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.IdProvincia = varIdProvincia;
			
				item.IdPais = varIdPais;
			
				item.IdSituacionLaboral = varIdSituacionLaboral;
			
				item.IdNivelInstruccion = varIdNivelInstruccion;
			
				item.IdProfesion = varIdProfesion;
			
				item.IdPaciente = varIdPaciente;
			
				item.TipoParentesco = varTipoParentesco;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.IdAntecedente = varIdAntecedente;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdParentescoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoDocumentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocumentoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProvinciaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPaisColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSituacionLaboralColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNivelInstruccionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoParentescoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAntecedenteColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdParentesco = @"idParentesco";
			 public static string Nombre = @"nombre";
			 public static string Apellido = @"apellido";
			 public static string IdTipoDocumento = @"idTipoDocumento";
			 public static string NumeroDocumento = @"numeroDocumento";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string IdProvincia = @"idProvincia";
			 public static string IdPais = @"idPais";
			 public static string IdSituacionLaboral = @"idSituacionLaboral";
			 public static string IdNivelInstruccion = @"idNivelInstruccion";
			 public static string IdProfesion = @"idProfesion";
			 public static string IdPaciente = @"idPaciente";
			 public static string TipoParentesco = @"tipoParentesco";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaModificacion = @"fechaModificacion";
			 public static string IdAntecedente = @"idAntecedente";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
