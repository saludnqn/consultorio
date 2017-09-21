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
	/// Strongly-typed collection for the ConDemandaRechazada class.
	/// </summary>
    [Serializable]
	public partial class ConDemandaRechazadaCollection : ActiveList<ConDemandaRechazada, ConDemandaRechazadaCollection>
	{	   
		public ConDemandaRechazadaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConDemandaRechazadaCollection</returns>
		public ConDemandaRechazadaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConDemandaRechazada o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_DemandaRechazada table.
	/// </summary>
	[Serializable]
	public partial class ConDemandaRechazada : ActiveRecord<ConDemandaRechazada>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConDemandaRechazada()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConDemandaRechazada(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConDemandaRechazada(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConDemandaRechazada(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_DemandaRechazada", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDemandaRechazada = new TableSchema.TableColumn(schema);
				colvarIdDemandaRechazada.ColumnName = "idDemandaRechazada";
				colvarIdDemandaRechazada.DataType = DbType.Int32;
				colvarIdDemandaRechazada.MaxLength = 0;
				colvarIdDemandaRechazada.AutoIncrement = true;
				colvarIdDemandaRechazada.IsNullable = false;
				colvarIdDemandaRechazada.IsPrimaryKey = true;
				colvarIdDemandaRechazada.IsForeignKey = false;
				colvarIdDemandaRechazada.IsReadOnly = false;
				colvarIdDemandaRechazada.DefaultSetting = @"";
				colvarIdDemandaRechazada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDemandaRechazada);
				
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
				
				TableSchema.TableColumn colvarIdMotivoRechazo = new TableSchema.TableColumn(schema);
				colvarIdMotivoRechazo.ColumnName = "idMotivoRechazo";
				colvarIdMotivoRechazo.DataType = DbType.Int32;
				colvarIdMotivoRechazo.MaxLength = 0;
				colvarIdMotivoRechazo.AutoIncrement = false;
				colvarIdMotivoRechazo.IsNullable = false;
				colvarIdMotivoRechazo.IsPrimaryKey = false;
				colvarIdMotivoRechazo.IsForeignKey = false;
				colvarIdMotivoRechazo.IsReadOnly = false;
				colvarIdMotivoRechazo.DefaultSetting = @"";
				colvarIdMotivoRechazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoRechazo);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 5000;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = false;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				
						colvarObservaciones.DefaultSetting = @"('')";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarIdTurnoResolucion = new TableSchema.TableColumn(schema);
				colvarIdTurnoResolucion.ColumnName = "idTurnoResolucion";
				colvarIdTurnoResolucion.DataType = DbType.Int32;
				colvarIdTurnoResolucion.MaxLength = 0;
				colvarIdTurnoResolucion.AutoIncrement = false;
				colvarIdTurnoResolucion.IsNullable = false;
				colvarIdTurnoResolucion.IsPrimaryKey = false;
				colvarIdTurnoResolucion.IsForeignKey = false;
				colvarIdTurnoResolucion.IsReadOnly = false;
				
						colvarIdTurnoResolucion.DefaultSetting = @"((0))";
				colvarIdTurnoResolucion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoResolucion);
				
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
				
				TableSchema.TableColumn colvarObservacionLLamada = new TableSchema.TableColumn(schema);
				colvarObservacionLLamada.ColumnName = "observacionLLamada";
				colvarObservacionLLamada.DataType = DbType.String;
				colvarObservacionLLamada.MaxLength = 255;
				colvarObservacionLLamada.AutoIncrement = false;
				colvarObservacionLLamada.IsNullable = true;
				colvarObservacionLLamada.IsPrimaryKey = false;
				colvarObservacionLLamada.IsForeignKey = false;
				colvarObservacionLLamada.IsReadOnly = false;
				colvarObservacionLLamada.DefaultSetting = @"";
				colvarObservacionLLamada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionLLamada);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_DemandaRechazada",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDemandaRechazada")]
		[Bindable(true)]
		public int IdDemandaRechazada 
		{
			get { return GetColumnValue<int>(Columns.IdDemandaRechazada); }
			set { SetColumnValue(Columns.IdDemandaRechazada, value); }
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
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int IdEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("IdMotivoRechazo")]
		[Bindable(true)]
		public int IdMotivoRechazo 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoRechazo); }
			set { SetColumnValue(Columns.IdMotivoRechazo, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("IdTurnoResolucion")]
		[Bindable(true)]
		public int IdTurnoResolucion 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoResolucion); }
			set { SetColumnValue(Columns.IdTurnoResolucion, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("ObservacionLLamada")]
		[Bindable(true)]
		public string ObservacionLLamada 
		{
			get { return GetColumnValue<string>(Columns.ObservacionLLamada); }
			set { SetColumnValue(Columns.ObservacionLLamada, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,int varIdEspecialidad,int varIdMotivoRechazo,string varObservaciones,int varIdTurnoResolucion,int varIdUsuario,DateTime varFechaRegistro,string varObservacionLLamada)
		{
			ConDemandaRechazada item = new ConDemandaRechazada();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdMotivoRechazo = varIdMotivoRechazo;
			
			item.Observaciones = varObservaciones;
			
			item.IdTurnoResolucion = varIdTurnoResolucion;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.ObservacionLLamada = varObservacionLLamada;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDemandaRechazada,int varIdEfector,int varIdPaciente,int varIdEspecialidad,int varIdMotivoRechazo,string varObservaciones,int varIdTurnoResolucion,int varIdUsuario,DateTime varFechaRegistro,string varObservacionLLamada)
		{
			ConDemandaRechazada item = new ConDemandaRechazada();
			
				item.IdDemandaRechazada = varIdDemandaRechazada;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdMotivoRechazo = varIdMotivoRechazo;
			
				item.Observaciones = varObservaciones;
			
				item.IdTurnoResolucion = varIdTurnoResolucion;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.ObservacionLLamada = varObservacionLLamada;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDemandaRechazadaColumn
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
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoRechazoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoResolucionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionLLamadaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDemandaRechazada = @"idDemandaRechazada";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdMotivoRechazo = @"idMotivoRechazo";
			 public static string Observaciones = @"observaciones";
			 public static string IdTurnoResolucion = @"idTurnoResolucion";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string ObservacionLLamada = @"observacionLLamada";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
