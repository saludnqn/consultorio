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
	/// Strongly-typed collection for the MamExamenFisico class.
	/// </summary>
    [Serializable]
	public partial class MamExamenFisicoCollection : ActiveList<MamExamenFisico, MamExamenFisicoCollection>
	{	   
		public MamExamenFisicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamExamenFisicoCollection</returns>
		public MamExamenFisicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamExamenFisico o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_ExamenFisico table.
	/// </summary>
	[Serializable]
	public partial class MamExamenFisico : ActiveRecord<MamExamenFisico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamExamenFisico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamExamenFisico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamExamenFisico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamExamenFisico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_ExamenFisico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdExamenFisico = new TableSchema.TableColumn(schema);
				colvarIdExamenFisico.ColumnName = "idExamenFisico";
				colvarIdExamenFisico.DataType = DbType.Int32;
				colvarIdExamenFisico.MaxLength = 0;
				colvarIdExamenFisico.AutoIncrement = true;
				colvarIdExamenFisico.IsNullable = false;
				colvarIdExamenFisico.IsPrimaryKey = true;
				colvarIdExamenFisico.IsForeignKey = false;
				colvarIdExamenFisico.IsReadOnly = false;
				colvarIdExamenFisico.DefaultSetting = @"";
				colvarIdExamenFisico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExamenFisico);
				
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
				
				TableSchema.TableColumn colvarEdadActual = new TableSchema.TableColumn(schema);
				colvarEdadActual.ColumnName = "edadActual";
				colvarEdadActual.DataType = DbType.Int32;
				colvarEdadActual.MaxLength = 0;
				colvarEdadActual.AutoIncrement = false;
				colvarEdadActual.IsNullable = false;
				colvarEdadActual.IsPrimaryKey = false;
				colvarEdadActual.IsForeignKey = false;
				colvarEdadActual.IsReadOnly = false;
				
						colvarEdadActual.DefaultSetting = @"((0))";
				colvarEdadActual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadActual);
				
				TableSchema.TableColumn colvarIdMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarIdMotivoConsulta.ColumnName = "idMotivoConsulta";
				colvarIdMotivoConsulta.DataType = DbType.Int32;
				colvarIdMotivoConsulta.MaxLength = 0;
				colvarIdMotivoConsulta.AutoIncrement = false;
				colvarIdMotivoConsulta.IsNullable = false;
				colvarIdMotivoConsulta.IsPrimaryKey = false;
				colvarIdMotivoConsulta.IsForeignKey = true;
				colvarIdMotivoConsulta.IsReadOnly = false;
				
						colvarIdMotivoConsulta.DefaultSetting = @"((0))";
				
					colvarIdMotivoConsulta.ForeignKeyTableName = "MAM_MotivoConsulta";
				schema.Columns.Add(colvarIdMotivoConsulta);
				
				TableSchema.TableColumn colvarIdResultadoExFisico = new TableSchema.TableColumn(schema);
				colvarIdResultadoExFisico.ColumnName = "idResultadoExFisico";
				colvarIdResultadoExFisico.DataType = DbType.Int32;
				colvarIdResultadoExFisico.MaxLength = 0;
				colvarIdResultadoExFisico.AutoIncrement = false;
				colvarIdResultadoExFisico.IsNullable = false;
				colvarIdResultadoExFisico.IsPrimaryKey = false;
				colvarIdResultadoExFisico.IsForeignKey = true;
				colvarIdResultadoExFisico.IsReadOnly = false;
				
						colvarIdResultadoExFisico.DefaultSetting = @"((0))";
				
					colvarIdResultadoExFisico.ForeignKeyTableName = "MAM_ResultadoExFisico";
				schema.Columns.Add(colvarIdResultadoExFisico);
				
				TableSchema.TableColumn colvarIdResponsableExamen = new TableSchema.TableColumn(schema);
				colvarIdResponsableExamen.ColumnName = "idResponsableExamen";
				colvarIdResponsableExamen.DataType = DbType.Int32;
				colvarIdResponsableExamen.MaxLength = 0;
				colvarIdResponsableExamen.AutoIncrement = false;
				colvarIdResponsableExamen.IsNullable = false;
				colvarIdResponsableExamen.IsPrimaryKey = false;
				colvarIdResponsableExamen.IsForeignKey = true;
				colvarIdResponsableExamen.IsReadOnly = false;
				
						colvarIdResponsableExamen.DefaultSetting = @"((0))";
				
					colvarIdResponsableExamen.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdResponsableExamen);
				
				TableSchema.TableColumn colvarIdCentroSalud = new TableSchema.TableColumn(schema);
				colvarIdCentroSalud.ColumnName = "idCentroSalud";
				colvarIdCentroSalud.DataType = DbType.Int32;
				colvarIdCentroSalud.MaxLength = 0;
				colvarIdCentroSalud.AutoIncrement = false;
				colvarIdCentroSalud.IsNullable = false;
				colvarIdCentroSalud.IsPrimaryKey = false;
				colvarIdCentroSalud.IsForeignKey = true;
				colvarIdCentroSalud.IsReadOnly = false;
				
						colvarIdCentroSalud.DefaultSetting = @"((0))";
				
					colvarIdCentroSalud.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdCentroSalud);
				
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
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"('')";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_ExamenFisico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdExamenFisico")]
		[Bindable(true)]
		public int IdExamenFisico 
		{
			get { return GetColumnValue<int>(Columns.IdExamenFisico); }
			set { SetColumnValue(Columns.IdExamenFisico, value); }
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
		  
		[XmlAttribute("EdadActual")]
		[Bindable(true)]
		public int EdadActual 
		{
			get { return GetColumnValue<int>(Columns.EdadActual); }
			set { SetColumnValue(Columns.EdadActual, value); }
		}
		  
		[XmlAttribute("IdMotivoConsulta")]
		[Bindable(true)]
		public int IdMotivoConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoConsulta); }
			set { SetColumnValue(Columns.IdMotivoConsulta, value); }
		}
		  
		[XmlAttribute("IdResultadoExFisico")]
		[Bindable(true)]
		public int IdResultadoExFisico 
		{
			get { return GetColumnValue<int>(Columns.IdResultadoExFisico); }
			set { SetColumnValue(Columns.IdResultadoExFisico, value); }
		}
		  
		[XmlAttribute("IdResponsableExamen")]
		[Bindable(true)]
		public int IdResponsableExamen 
		{
			get { return GetColumnValue<int>(Columns.IdResponsableExamen); }
			set { SetColumnValue(Columns.IdResponsableExamen, value); }
		}
		  
		[XmlAttribute("IdCentroSalud")]
		[Bindable(true)]
		public int IdCentroSalud 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSalud); }
			set { SetColumnValue(Columns.IdCentroSalud, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
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
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
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
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamExamenFisico
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSalud); }
			set { SetColumnValue("idCentroSalud", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a MamResultadoExFisico ActiveRecord object related to this MamExamenFisico
		/// 
		/// </summary>
		public DalSic.MamResultadoExFisico MamResultadoExFisico
		{
			get { return DalSic.MamResultadoExFisico.FetchByID(this.IdResultadoExFisico); }
			set { SetColumnValue("idResultadoExFisico", value.IdResultadoExFisico); }
		}
		
		
		/// <summary>
		/// Returns a MamMotivoConsultum ActiveRecord object related to this MamExamenFisico
		/// 
		/// </summary>
		public DalSic.MamMotivoConsultum MamMotivoConsultum
		{
			get { return DalSic.MamMotivoConsultum.FetchByID(this.IdMotivoConsulta); }
			set { SetColumnValue("idMotivoConsulta", value.IdMotivoConsulta); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamExamenFisico
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdResponsableExamen); }
			set { SetColumnValue("idResponsableExamen", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,DateTime varFecha,int varEdadActual,int varIdMotivoConsulta,int varIdResultadoExFisico,int varIdResponsableExamen,int varIdCentroSalud,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamExamenFisico item = new MamExamenFisico();
			
			item.IdPaciente = varIdPaciente;
			
			item.Fecha = varFecha;
			
			item.EdadActual = varEdadActual;
			
			item.IdMotivoConsulta = varIdMotivoConsulta;
			
			item.IdResultadoExFisico = varIdResultadoExFisico;
			
			item.IdResponsableExamen = varIdResponsableExamen;
			
			item.IdCentroSalud = varIdCentroSalud;
			
			item.Activo = varActivo;
			
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
		public static void Update(int varIdExamenFisico,int varIdPaciente,DateTime varFecha,int varEdadActual,int varIdMotivoConsulta,int varIdResultadoExFisico,int varIdResponsableExamen,int varIdCentroSalud,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamExamenFisico item = new MamExamenFisico();
			
				item.IdExamenFisico = varIdExamenFisico;
			
				item.IdPaciente = varIdPaciente;
			
				item.Fecha = varFecha;
			
				item.EdadActual = varEdadActual;
			
				item.IdMotivoConsulta = varIdMotivoConsulta;
			
				item.IdResultadoExFisico = varIdResultadoExFisico;
			
				item.IdResponsableExamen = varIdResponsableExamen;
			
				item.IdCentroSalud = varIdCentroSalud;
			
				item.Activo = varActivo;
			
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
        
        
        public static TableSchema.TableColumn IdExamenFisicoColumn
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
        
        
        
        public static TableSchema.TableColumn EdadActualColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoConsultaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResultadoExFisicoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResponsableExamenColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdExamenFisico = @"idExamenFisico";
			 public static string IdPaciente = @"idPaciente";
			 public static string Fecha = @"fecha";
			 public static string EdadActual = @"edadActual";
			 public static string IdMotivoConsulta = @"idMotivoConsulta";
			 public static string IdResultadoExFisico = @"idResultadoExFisico";
			 public static string IdResponsableExamen = @"idResponsableExamen";
			 public static string IdCentroSalud = @"idCentroSalud";
			 public static string Activo = @"activo";
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
