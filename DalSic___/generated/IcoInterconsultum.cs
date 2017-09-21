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
	/// Strongly-typed collection for the IcoInterconsultum class.
	/// </summary>
    [Serializable]
	public partial class IcoInterconsultumCollection : ActiveList<IcoInterconsultum, IcoInterconsultumCollection>
	{	   
		public IcoInterconsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>IcoInterconsultumCollection</returns>
		public IcoInterconsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                IcoInterconsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the ICO_Interconsulta table.
	/// </summary>
	[Serializable]
	public partial class IcoInterconsultum : ActiveRecord<IcoInterconsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public IcoInterconsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public IcoInterconsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public IcoInterconsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public IcoInterconsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ICO_Interconsulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdInterconsulta = new TableSchema.TableColumn(schema);
				colvarIdInterconsulta.ColumnName = "idInterconsulta";
				colvarIdInterconsulta.DataType = DbType.Int32;
				colvarIdInterconsulta.MaxLength = 0;
				colvarIdInterconsulta.AutoIncrement = true;
				colvarIdInterconsulta.IsNullable = false;
				colvarIdInterconsulta.IsPrimaryKey = true;
				colvarIdInterconsulta.IsForeignKey = false;
				colvarIdInterconsulta.IsReadOnly = false;
				colvarIdInterconsulta.DefaultSetting = @"";
				colvarIdInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInterconsulta);
				
				TableSchema.TableColumn colvarFechaSolicitud = new TableSchema.TableColumn(schema);
				colvarFechaSolicitud.ColumnName = "fechaSolicitud";
				colvarFechaSolicitud.DataType = DbType.DateTime;
				colvarFechaSolicitud.MaxLength = 0;
				colvarFechaSolicitud.AutoIncrement = false;
				colvarFechaSolicitud.IsNullable = false;
				colvarFechaSolicitud.IsPrimaryKey = false;
				colvarFechaSolicitud.IsForeignKey = false;
				colvarFechaSolicitud.IsReadOnly = false;
				colvarFechaSolicitud.DefaultSetting = @"";
				colvarFechaSolicitud.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaSolicitud);
				
				TableSchema.TableColumn colvarFechaRecepcion = new TableSchema.TableColumn(schema);
				colvarFechaRecepcion.ColumnName = "fechaRecepcion";
				colvarFechaRecepcion.DataType = DbType.DateTime;
				colvarFechaRecepcion.MaxLength = 0;
				colvarFechaRecepcion.AutoIncrement = false;
				colvarFechaRecepcion.IsNullable = false;
				colvarFechaRecepcion.IsPrimaryKey = false;
				colvarFechaRecepcion.IsForeignKey = false;
				colvarFechaRecepcion.IsReadOnly = false;
				colvarFechaRecepcion.DefaultSetting = @"";
				colvarFechaRecepcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecepcion);
				
				TableSchema.TableColumn colvarViaRecepcion = new TableSchema.TableColumn(schema);
				colvarViaRecepcion.ColumnName = "viaRecepcion";
				colvarViaRecepcion.DataType = DbType.AnsiString;
				colvarViaRecepcion.MaxLength = 50;
				colvarViaRecepcion.AutoIncrement = false;
				colvarViaRecepcion.IsNullable = false;
				colvarViaRecepcion.IsPrimaryKey = false;
				colvarViaRecepcion.IsForeignKey = false;
				colvarViaRecepcion.IsReadOnly = false;
				colvarViaRecepcion.DefaultSetting = @"";
				colvarViaRecepcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViaRecepcion);
				
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
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = false;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = false;
				colvarIdEspecialidad.IsReadOnly = false;
				colvarIdEspecialidad.DefaultSetting = @"";
				colvarIdEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEspecialidad);
				
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
				
				TableSchema.TableColumn colvarIdZona = new TableSchema.TableColumn(schema);
				colvarIdZona.ColumnName = "idZona";
				colvarIdZona.DataType = DbType.Int32;
				colvarIdZona.MaxLength = 0;
				colvarIdZona.AutoIncrement = false;
				colvarIdZona.IsNullable = true;
				colvarIdZona.IsPrimaryKey = false;
				colvarIdZona.IsForeignKey = false;
				colvarIdZona.IsReadOnly = false;
				colvarIdZona.DefaultSetting = @"";
				colvarIdZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdZona);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarProblemaIdCIE10 = new TableSchema.TableColumn(schema);
				colvarProblemaIdCIE10.ColumnName = "problema_idCIE10";
				colvarProblemaIdCIE10.DataType = DbType.Int32;
				colvarProblemaIdCIE10.MaxLength = 0;
				colvarProblemaIdCIE10.AutoIncrement = false;
				colvarProblemaIdCIE10.IsNullable = false;
				colvarProblemaIdCIE10.IsPrimaryKey = false;
				colvarProblemaIdCIE10.IsForeignKey = false;
				colvarProblemaIdCIE10.IsReadOnly = false;
				colvarProblemaIdCIE10.DefaultSetting = @"";
				colvarProblemaIdCIE10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProblemaIdCIE10);
				
				TableSchema.TableColumn colvarMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarMotivoConsulta.ColumnName = "motivoConsulta";
				colvarMotivoConsulta.DataType = DbType.AnsiString;
				colvarMotivoConsulta.MaxLength = 8000;
				colvarMotivoConsulta.AutoIncrement = false;
				colvarMotivoConsulta.IsNullable = true;
				colvarMotivoConsulta.IsPrimaryKey = false;
				colvarMotivoConsulta.IsForeignKey = false;
				colvarMotivoConsulta.IsReadOnly = false;
				colvarMotivoConsulta.DefaultSetting = @"";
				colvarMotivoConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivoConsulta);
				
				TableSchema.TableColumn colvarResumenHistoriaClinica = new TableSchema.TableColumn(schema);
				colvarResumenHistoriaClinica.ColumnName = "resumenHistoriaClinica";
				colvarResumenHistoriaClinica.DataType = DbType.AnsiString;
				colvarResumenHistoriaClinica.MaxLength = 8000;
				colvarResumenHistoriaClinica.AutoIncrement = false;
				colvarResumenHistoriaClinica.IsNullable = true;
				colvarResumenHistoriaClinica.IsPrimaryKey = false;
				colvarResumenHistoriaClinica.IsForeignKey = false;
				colvarResumenHistoriaClinica.IsReadOnly = false;
				colvarResumenHistoriaClinica.DefaultSetting = @"";
				colvarResumenHistoriaClinica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResumenHistoriaClinica);
				
				TableSchema.TableColumn colvarCierreIdCIE10 = new TableSchema.TableColumn(schema);
				colvarCierreIdCIE10.ColumnName = "cierre_idCIE10";
				colvarCierreIdCIE10.DataType = DbType.Int32;
				colvarCierreIdCIE10.MaxLength = 0;
				colvarCierreIdCIE10.AutoIncrement = false;
				colvarCierreIdCIE10.IsNullable = false;
				colvarCierreIdCIE10.IsPrimaryKey = false;
				colvarCierreIdCIE10.IsForeignKey = false;
				colvarCierreIdCIE10.IsReadOnly = false;
				colvarCierreIdCIE10.DefaultSetting = @"";
				colvarCierreIdCIE10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCierreIdCIE10);
				
				TableSchema.TableColumn colvarInterconsultaOCADU = new TableSchema.TableColumn(schema);
				colvarInterconsultaOCADU.ColumnName = "interconsultaOCADU";
				colvarInterconsultaOCADU.DataType = DbType.AnsiString;
				colvarInterconsultaOCADU.MaxLength = 50;
				colvarInterconsultaOCADU.AutoIncrement = false;
				colvarInterconsultaOCADU.IsNullable = true;
				colvarInterconsultaOCADU.IsPrimaryKey = false;
				colvarInterconsultaOCADU.IsForeignKey = false;
				colvarInterconsultaOCADU.IsReadOnly = false;
				colvarInterconsultaOCADU.DefaultSetting = @"";
				colvarInterconsultaOCADU.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInterconsultaOCADU);
				
				TableSchema.TableColumn colvarEstadoInterconsulta = new TableSchema.TableColumn(schema);
				colvarEstadoInterconsulta.ColumnName = "estadoInterconsulta";
				colvarEstadoInterconsulta.DataType = DbType.AnsiString;
				colvarEstadoInterconsulta.MaxLength = 50;
				colvarEstadoInterconsulta.AutoIncrement = false;
				colvarEstadoInterconsulta.IsNullable = true;
				colvarEstadoInterconsulta.IsPrimaryKey = false;
				colvarEstadoInterconsulta.IsForeignKey = false;
				colvarEstadoInterconsulta.IsReadOnly = false;
				colvarEstadoInterconsulta.DefaultSetting = @"";
				colvarEstadoInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoInterconsulta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("ICO_Interconsulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdInterconsulta")]
		[Bindable(true)]
		public int IdInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdInterconsulta); }
			set { SetColumnValue(Columns.IdInterconsulta, value); }
		}
		  
		[XmlAttribute("FechaSolicitud")]
		[Bindable(true)]
		public DateTime FechaSolicitud 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaSolicitud); }
			set { SetColumnValue(Columns.FechaSolicitud, value); }
		}
		  
		[XmlAttribute("FechaRecepcion")]
		[Bindable(true)]
		public DateTime FechaRecepcion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRecepcion); }
			set { SetColumnValue(Columns.FechaRecepcion, value); }
		}
		  
		[XmlAttribute("ViaRecepcion")]
		[Bindable(true)]
		public string ViaRecepcion 
		{
			get { return GetColumnValue<string>(Columns.ViaRecepcion); }
			set { SetColumnValue(Columns.ViaRecepcion, value); }
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
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdZona")]
		[Bindable(true)]
		public int? IdZona 
		{
			get { return GetColumnValue<int?>(Columns.IdZona); }
			set { SetColumnValue(Columns.IdZona, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("ProblemaIdCIE10")]
		[Bindable(true)]
		public int ProblemaIdCIE10 
		{
			get { return GetColumnValue<int>(Columns.ProblemaIdCIE10); }
			set { SetColumnValue(Columns.ProblemaIdCIE10, value); }
		}
		  
		[XmlAttribute("MotivoConsulta")]
		[Bindable(true)]
		public string MotivoConsulta 
		{
			get { return GetColumnValue<string>(Columns.MotivoConsulta); }
			set { SetColumnValue(Columns.MotivoConsulta, value); }
		}
		  
		[XmlAttribute("ResumenHistoriaClinica")]
		[Bindable(true)]
		public string ResumenHistoriaClinica 
		{
			get { return GetColumnValue<string>(Columns.ResumenHistoriaClinica); }
			set { SetColumnValue(Columns.ResumenHistoriaClinica, value); }
		}
		  
		[XmlAttribute("CierreIdCIE10")]
		[Bindable(true)]
		public int CierreIdCIE10 
		{
			get { return GetColumnValue<int>(Columns.CierreIdCIE10); }
			set { SetColumnValue(Columns.CierreIdCIE10, value); }
		}
		  
		[XmlAttribute("InterconsultaOCADU")]
		[Bindable(true)]
		public string InterconsultaOCADU 
		{
			get { return GetColumnValue<string>(Columns.InterconsultaOCADU); }
			set { SetColumnValue(Columns.InterconsultaOCADU, value); }
		}
		  
		[XmlAttribute("EstadoInterconsulta")]
		[Bindable(true)]
		public string EstadoInterconsulta 
		{
			get { return GetColumnValue<string>(Columns.EstadoInterconsulta); }
			set { SetColumnValue(Columns.EstadoInterconsulta, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varFechaSolicitud,DateTime varFechaRecepcion,string varViaRecepcion,int varIdProfesional,int varIdEspecialidad,int varIdPaciente,int? varIdZona,int? varIdEfector,int varProblemaIdCIE10,string varMotivoConsulta,string varResumenHistoriaClinica,int varCierreIdCIE10,string varInterconsultaOCADU,string varEstadoInterconsulta)
		{
			IcoInterconsultum item = new IcoInterconsultum();
			
			item.FechaSolicitud = varFechaSolicitud;
			
			item.FechaRecepcion = varFechaRecepcion;
			
			item.ViaRecepcion = varViaRecepcion;
			
			item.IdProfesional = varIdProfesional;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdZona = varIdZona;
			
			item.IdEfector = varIdEfector;
			
			item.ProblemaIdCIE10 = varProblemaIdCIE10;
			
			item.MotivoConsulta = varMotivoConsulta;
			
			item.ResumenHistoriaClinica = varResumenHistoriaClinica;
			
			item.CierreIdCIE10 = varCierreIdCIE10;
			
			item.InterconsultaOCADU = varInterconsultaOCADU;
			
			item.EstadoInterconsulta = varEstadoInterconsulta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdInterconsulta,DateTime varFechaSolicitud,DateTime varFechaRecepcion,string varViaRecepcion,int varIdProfesional,int varIdEspecialidad,int varIdPaciente,int? varIdZona,int? varIdEfector,int varProblemaIdCIE10,string varMotivoConsulta,string varResumenHistoriaClinica,int varCierreIdCIE10,string varInterconsultaOCADU,string varEstadoInterconsulta)
		{
			IcoInterconsultum item = new IcoInterconsultum();
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.FechaSolicitud = varFechaSolicitud;
			
				item.FechaRecepcion = varFechaRecepcion;
			
				item.ViaRecepcion = varViaRecepcion;
			
				item.IdProfesional = varIdProfesional;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdZona = varIdZona;
			
				item.IdEfector = varIdEfector;
			
				item.ProblemaIdCIE10 = varProblemaIdCIE10;
			
				item.MotivoConsulta = varMotivoConsulta;
			
				item.ResumenHistoriaClinica = varResumenHistoriaClinica;
			
				item.CierreIdCIE10 = varCierreIdCIE10;
			
				item.InterconsultaOCADU = varInterconsultaOCADU;
			
				item.EstadoInterconsulta = varEstadoInterconsulta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaSolicitudColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecepcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ViaRecepcionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdZonaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ProblemaIdCIE10Column
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoConsultaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ResumenHistoriaClinicaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CierreIdCIE10Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn InterconsultaOCADUColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoInterconsultaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string FechaSolicitud = @"fechaSolicitud";
			 public static string FechaRecepcion = @"fechaRecepcion";
			 public static string ViaRecepcion = @"viaRecepcion";
			 public static string IdProfesional = @"idProfesional";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdZona = @"idZona";
			 public static string IdEfector = @"idEfector";
			 public static string ProblemaIdCIE10 = @"problema_idCIE10";
			 public static string MotivoConsulta = @"motivoConsulta";
			 public static string ResumenHistoriaClinica = @"resumenHistoriaClinica";
			 public static string CierreIdCIE10 = @"cierre_idCIE10";
			 public static string InterconsultaOCADU = @"interconsultaOCADU";
			 public static string EstadoInterconsulta = @"estadoInterconsulta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
