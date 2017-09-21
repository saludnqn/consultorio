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
	/// Strongly-typed collection for the SysDefuncion class.
	/// </summary>
    [Serializable]
	public partial class SysDefuncionCollection : ActiveList<SysDefuncion, SysDefuncionCollection>
	{	   
		public SysDefuncionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysDefuncionCollection</returns>
		public SysDefuncionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysDefuncion o = this[i];
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
	/// This is an ActiveRecord class which wraps the sys_Defuncion table.
	/// </summary>
	[Serializable]
	public partial class SysDefuncion : ActiveRecord<SysDefuncion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysDefuncion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysDefuncion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysDefuncion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysDefuncion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("sys_Defuncion", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.AnsiString;
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
				colvarHora.DataType = DbType.AnsiString;
				colvarHora.MaxLength = 5;
				colvarHora.AutoIncrement = false;
				colvarHora.IsNullable = false;
				colvarHora.IsPrimaryKey = false;
				colvarHora.IsForeignKey = false;
				colvarHora.IsReadOnly = false;
				colvarHora.DefaultSetting = @"";
				colvarHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHora);
				
				TableSchema.TableColumn colvarCausaMuerte = new TableSchema.TableColumn(schema);
				colvarCausaMuerte.ColumnName = "CausaMuerte";
				colvarCausaMuerte.DataType = DbType.AnsiString;
				colvarCausaMuerte.MaxLength = -1;
				colvarCausaMuerte.AutoIncrement = false;
				colvarCausaMuerte.IsNullable = false;
				colvarCausaMuerte.IsPrimaryKey = false;
				colvarCausaMuerte.IsForeignKey = false;
				colvarCausaMuerte.IsReadOnly = false;
				colvarCausaMuerte.DefaultSetting = @"";
				colvarCausaMuerte.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCausaMuerte);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = false;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				colvarIdProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarIngresoMorguePersonal = new TableSchema.TableColumn(schema);
				colvarIngresoMorguePersonal.ColumnName = "ingresoMorguePersonal";
				colvarIngresoMorguePersonal.DataType = DbType.AnsiString;
				colvarIngresoMorguePersonal.MaxLength = -1;
				colvarIngresoMorguePersonal.AutoIncrement = false;
				colvarIngresoMorguePersonal.IsNullable = true;
				colvarIngresoMorguePersonal.IsPrimaryKey = false;
				colvarIngresoMorguePersonal.IsForeignKey = false;
				colvarIngresoMorguePersonal.IsReadOnly = false;
				colvarIngresoMorguePersonal.DefaultSetting = @"";
				colvarIngresoMorguePersonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngresoMorguePersonal);
				
				TableSchema.TableColumn colvarEgresoPersonal = new TableSchema.TableColumn(schema);
				colvarEgresoPersonal.ColumnName = "egresoPersonal";
				colvarEgresoPersonal.DataType = DbType.AnsiString;
				colvarEgresoPersonal.MaxLength = -1;
				colvarEgresoPersonal.AutoIncrement = false;
				colvarEgresoPersonal.IsNullable = true;
				colvarEgresoPersonal.IsPrimaryKey = false;
				colvarEgresoPersonal.IsForeignKey = false;
				colvarEgresoPersonal.IsReadOnly = false;
				colvarEgresoPersonal.DefaultSetting = @"";
				colvarEgresoPersonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoPersonal);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarIdSsoUserAlta = new TableSchema.TableColumn(schema);
				colvarIdSsoUserAlta.ColumnName = "idSsoUserAlta";
				colvarIdSsoUserAlta.DataType = DbType.Int32;
				colvarIdSsoUserAlta.MaxLength = 0;
				colvarIdSsoUserAlta.AutoIncrement = false;
				colvarIdSsoUserAlta.IsNullable = false;
				colvarIdSsoUserAlta.IsPrimaryKey = false;
				colvarIdSsoUserAlta.IsForeignKey = false;
				colvarIdSsoUserAlta.IsReadOnly = false;
				colvarIdSsoUserAlta.DefaultSetting = @"";
				colvarIdSsoUserAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSsoUserAlta);
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fechaAlta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = true;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				colvarFechaAlta.DefaultSetting = @"";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
				TableSchema.TableColumn colvarIdSsoUserModificacion = new TableSchema.TableColumn(schema);
				colvarIdSsoUserModificacion.ColumnName = "idSsoUserModificacion";
				colvarIdSsoUserModificacion.DataType = DbType.Int32;
				colvarIdSsoUserModificacion.MaxLength = 0;
				colvarIdSsoUserModificacion.AutoIncrement = false;
				colvarIdSsoUserModificacion.IsNullable = true;
				colvarIdSsoUserModificacion.IsPrimaryKey = false;
				colvarIdSsoUserModificacion.IsForeignKey = false;
				colvarIdSsoUserModificacion.IsReadOnly = false;
				colvarIdSsoUserModificacion.DefaultSetting = @"";
				colvarIdSsoUserModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSsoUserModificacion);
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "fechaModificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = true;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				colvarFechaModificacion.DefaultSetting = @"";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("sys_Defuncion",schema);
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
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public string Fecha 
		{
			get { return GetColumnValue<string>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Hora")]
		[Bindable(true)]
		public string Hora 
		{
			get { return GetColumnValue<string>(Columns.Hora); }
			set { SetColumnValue(Columns.Hora, value); }
		}
		  
		[XmlAttribute("CausaMuerte")]
		[Bindable(true)]
		public string CausaMuerte 
		{
			get { return GetColumnValue<string>(Columns.CausaMuerte); }
			set { SetColumnValue(Columns.CausaMuerte, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("IngresoMorguePersonal")]
		[Bindable(true)]
		public string IngresoMorguePersonal 
		{
			get { return GetColumnValue<string>(Columns.IngresoMorguePersonal); }
			set { SetColumnValue(Columns.IngresoMorguePersonal, value); }
		}
		  
		[XmlAttribute("EgresoPersonal")]
		[Bindable(true)]
		public string EgresoPersonal 
		{
			get { return GetColumnValue<string>(Columns.EgresoPersonal); }
			set { SetColumnValue(Columns.EgresoPersonal, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("IdSsoUserAlta")]
		[Bindable(true)]
		public int IdSsoUserAlta 
		{
			get { return GetColumnValue<int>(Columns.IdSsoUserAlta); }
			set { SetColumnValue(Columns.IdSsoUserAlta, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime? FechaAlta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		  
		[XmlAttribute("IdSsoUserModificacion")]
		[Bindable(true)]
		public int? IdSsoUserModificacion 
		{
			get { return GetColumnValue<int?>(Columns.IdSsoUserModificacion); }
			set { SetColumnValue(Columns.IdSsoUserModificacion, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime? FechaModificacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,string varFecha,string varHora,string varCausaMuerte,int varIdProfesional,string varIngresoMorguePersonal,string varEgresoPersonal,string varObservaciones,int varIdSsoUserAlta,DateTime? varFechaAlta,int? varIdSsoUserModificacion,DateTime? varFechaModificacion,bool varActivo)
		{
			SysDefuncion item = new SysDefuncion();
			
			item.IdPaciente = varIdPaciente;
			
			item.Fecha = varFecha;
			
			item.Hora = varHora;
			
			item.CausaMuerte = varCausaMuerte;
			
			item.IdProfesional = varIdProfesional;
			
			item.IngresoMorguePersonal = varIngresoMorguePersonal;
			
			item.EgresoPersonal = varEgresoPersonal;
			
			item.Observaciones = varObservaciones;
			
			item.IdSsoUserAlta = varIdSsoUserAlta;
			
			item.FechaAlta = varFechaAlta;
			
			item.IdSsoUserModificacion = varIdSsoUserModificacion;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varIdPaciente,string varFecha,string varHora,string varCausaMuerte,int varIdProfesional,string varIngresoMorguePersonal,string varEgresoPersonal,string varObservaciones,int varIdSsoUserAlta,DateTime? varFechaAlta,int? varIdSsoUserModificacion,DateTime? varFechaModificacion,bool varActivo)
		{
			SysDefuncion item = new SysDefuncion();
			
				item.Id = varId;
			
				item.IdPaciente = varIdPaciente;
			
				item.Fecha = varFecha;
			
				item.Hora = varHora;
			
				item.CausaMuerte = varCausaMuerte;
			
				item.IdProfesional = varIdProfesional;
			
				item.IngresoMorguePersonal = varIngresoMorguePersonal;
			
				item.EgresoPersonal = varEgresoPersonal;
			
				item.Observaciones = varObservaciones;
			
				item.IdSsoUserAlta = varIdSsoUserAlta;
			
				item.FechaAlta = varFechaAlta;
			
				item.IdSsoUserModificacion = varIdSsoUserModificacion;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.Activo = varActivo;
			
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
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CausaMuerteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoMorguePersonalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoPersonalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSsoUserAltaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSsoUserModificacionColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdPaciente = @"idPaciente";
			 public static string Fecha = @"fecha";
			 public static string Hora = @"hora";
			 public static string CausaMuerte = @"CausaMuerte";
			 public static string IdProfesional = @"idProfesional";
			 public static string IngresoMorguePersonal = @"ingresoMorguePersonal";
			 public static string EgresoPersonal = @"egresoPersonal";
			 public static string Observaciones = @"observaciones";
			 public static string IdSsoUserAlta = @"idSsoUserAlta";
			 public static string FechaAlta = @"fechaAlta";
			 public static string IdSsoUserModificacion = @"idSsoUserModificacion";
			 public static string FechaModificacion = @"fechaModificacion";
			 public static string Activo = @"activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
