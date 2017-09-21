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
	/// Strongly-typed collection for the MamEstadioClinico class.
	/// </summary>
    [Serializable]
	public partial class MamEstadioClinicoCollection : ActiveList<MamEstadioClinico, MamEstadioClinicoCollection>
	{	   
		public MamEstadioClinicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamEstadioClinicoCollection</returns>
		public MamEstadioClinicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamEstadioClinico o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_EstadioClinico table.
	/// </summary>
	[Serializable]
	public partial class MamEstadioClinico : ActiveRecord<MamEstadioClinico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamEstadioClinico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamEstadioClinico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamEstadioClinico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamEstadioClinico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_EstadioClinico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstadioClinico = new TableSchema.TableColumn(schema);
				colvarIdEstadioClinico.ColumnName = "idEstadioClinico";
				colvarIdEstadioClinico.DataType = DbType.Int32;
				colvarIdEstadioClinico.MaxLength = 0;
				colvarIdEstadioClinico.AutoIncrement = true;
				colvarIdEstadioClinico.IsNullable = false;
				colvarIdEstadioClinico.IsPrimaryKey = true;
				colvarIdEstadioClinico.IsForeignKey = false;
				colvarIdEstadioClinico.IsReadOnly = false;
				colvarIdEstadioClinico.DefaultSetting = @"";
				colvarIdEstadioClinico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadioClinico);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
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
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = false;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				
						colvarEdad.DefaultSetting = @"((0))";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				
						colvarFechaRegistro.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				TableSchema.TableColumn colvarIdIndicadorT = new TableSchema.TableColumn(schema);
				colvarIdIndicadorT.ColumnName = "idIndicadorT";
				colvarIdIndicadorT.DataType = DbType.Int32;
				colvarIdIndicadorT.MaxLength = 0;
				colvarIdIndicadorT.AutoIncrement = false;
				colvarIdIndicadorT.IsNullable = false;
				colvarIdIndicadorT.IsPrimaryKey = false;
				colvarIdIndicadorT.IsForeignKey = false;
				colvarIdIndicadorT.IsReadOnly = false;
				
						colvarIdIndicadorT.DefaultSetting = @"((0))";
				colvarIdIndicadorT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIndicadorT);
				
				TableSchema.TableColumn colvarIdIndicadorN = new TableSchema.TableColumn(schema);
				colvarIdIndicadorN.ColumnName = "idIndicadorN";
				colvarIdIndicadorN.DataType = DbType.Int32;
				colvarIdIndicadorN.MaxLength = 0;
				colvarIdIndicadorN.AutoIncrement = false;
				colvarIdIndicadorN.IsNullable = false;
				colvarIdIndicadorN.IsPrimaryKey = false;
				colvarIdIndicadorN.IsForeignKey = false;
				colvarIdIndicadorN.IsReadOnly = false;
				
						colvarIdIndicadorN.DefaultSetting = @"((0))";
				colvarIdIndicadorN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIndicadorN);
				
				TableSchema.TableColumn colvarIdIndicadorM = new TableSchema.TableColumn(schema);
				colvarIdIndicadorM.ColumnName = "idIndicadorM";
				colvarIdIndicadorM.DataType = DbType.Int32;
				colvarIdIndicadorM.MaxLength = 0;
				colvarIdIndicadorM.AutoIncrement = false;
				colvarIdIndicadorM.IsNullable = false;
				colvarIdIndicadorM.IsPrimaryKey = false;
				colvarIdIndicadorM.IsForeignKey = false;
				colvarIdIndicadorM.IsReadOnly = false;
				
						colvarIdIndicadorM.DefaultSetting = @"((0))";
				colvarIdIndicadorM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIndicadorM);
				
				TableSchema.TableColumn colvarIdEstadio = new TableSchema.TableColumn(schema);
				colvarIdEstadio.ColumnName = "idEstadio";
				colvarIdEstadio.DataType = DbType.Int32;
				colvarIdEstadio.MaxLength = 0;
				colvarIdEstadio.AutoIncrement = false;
				colvarIdEstadio.IsNullable = false;
				colvarIdEstadio.IsPrimaryKey = false;
				colvarIdEstadio.IsForeignKey = false;
				colvarIdEstadio.IsReadOnly = false;
				
						colvarIdEstadio.DefaultSetting = @"((0))";
				colvarIdEstadio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadio);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				
						colvarIdProfesional.DefaultSetting = @"((0))";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
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
				DataService.Providers["sicProvider"].AddSchema("MAM_EstadioClinico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstadioClinico")]
		[Bindable(true)]
		public int IdEstadioClinico 
		{
			get { return GetColumnValue<int>(Columns.IdEstadioClinico); }
			set { SetColumnValue(Columns.IdEstadioClinico, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdCentroSalud")]
		[Bindable(true)]
		public int IdCentroSalud 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSalud); }
			set { SetColumnValue(Columns.IdCentroSalud, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("IdIndicadorT")]
		[Bindable(true)]
		public int IdIndicadorT 
		{
			get { return GetColumnValue<int>(Columns.IdIndicadorT); }
			set { SetColumnValue(Columns.IdIndicadorT, value); }
		}
		  
		[XmlAttribute("IdIndicadorN")]
		[Bindable(true)]
		public int IdIndicadorN 
		{
			get { return GetColumnValue<int>(Columns.IdIndicadorN); }
			set { SetColumnValue(Columns.IdIndicadorN, value); }
		}
		  
		[XmlAttribute("IdIndicadorM")]
		[Bindable(true)]
		public int IdIndicadorM 
		{
			get { return GetColumnValue<int>(Columns.IdIndicadorM); }
			set { SetColumnValue(Columns.IdIndicadorM, value); }
		}
		  
		[XmlAttribute("IdEstadio")]
		[Bindable(true)]
		public int IdEstadio 
		{
			get { return GetColumnValue<int>(Columns.IdEstadio); }
			set { SetColumnValue(Columns.IdEstadio, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
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
		/// Returns a SysEfector ActiveRecord object related to this MamEstadioClinico
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSalud); }
			set { SetColumnValue("idCentroSalud", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this MamEstadioClinico
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamEstadioClinico
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varIdCentroSalud,int varEdad,DateTime varFechaRegistro,int varIdIndicadorT,int varIdIndicadorN,int varIdIndicadorM,int varIdEstadio,int varIdProfesional,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamEstadioClinico item = new MamEstadioClinico();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdCentroSalud = varIdCentroSalud;
			
			item.Edad = varEdad;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.IdIndicadorT = varIdIndicadorT;
			
			item.IdIndicadorN = varIdIndicadorN;
			
			item.IdIndicadorM = varIdIndicadorM;
			
			item.IdEstadio = varIdEstadio;
			
			item.IdProfesional = varIdProfesional;
			
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
		public static void Update(int varIdEstadioClinico,int varIdPaciente,int varIdCentroSalud,int varEdad,DateTime varFechaRegistro,int varIdIndicadorT,int varIdIndicadorN,int varIdIndicadorM,int varIdEstadio,int varIdProfesional,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamEstadioClinico item = new MamEstadioClinico();
			
				item.IdEstadioClinico = varIdEstadioClinico;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdCentroSalud = varIdCentroSalud;
			
				item.Edad = varEdad;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.IdIndicadorT = varIdIndicadorT;
			
				item.IdIndicadorN = varIdIndicadorN;
			
				item.IdIndicadorM = varIdIndicadorM;
			
				item.IdEstadio = varIdEstadio;
			
				item.IdProfesional = varIdProfesional;
			
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
        
        
        public static TableSchema.TableColumn IdEstadioClinicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdIndicadorTColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdIndicadorNColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdIndicadorMColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstadioClinico = @"idEstadioClinico";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdCentroSalud = @"idCentroSalud";
			 public static string Edad = @"edad";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string IdIndicadorT = @"idIndicadorT";
			 public static string IdIndicadorN = @"idIndicadorN";
			 public static string IdIndicadorM = @"idIndicadorM";
			 public static string IdEstadio = @"idEstadio";
			 public static string IdProfesional = @"idProfesional";
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
