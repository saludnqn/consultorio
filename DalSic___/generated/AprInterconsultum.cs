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
	/// Strongly-typed collection for the AprInterconsultum class.
	/// </summary>
    [Serializable]
	public partial class AprInterconsultumCollection : ActiveList<AprInterconsultum, AprInterconsultumCollection>
	{	   
		public AprInterconsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprInterconsultumCollection</returns>
		public AprInterconsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprInterconsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_Interconsulta table.
	/// </summary>
	[Serializable]
	public partial class AprInterconsultum : ActiveRecord<AprInterconsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprInterconsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprInterconsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprInterconsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprInterconsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_Interconsulta", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdHistoriaClinicaPerinatal = new TableSchema.TableColumn(schema);
				colvarIdHistoriaClinicaPerinatal.ColumnName = "idHistoriaClinicaPerinatal";
				colvarIdHistoriaClinicaPerinatal.DataType = DbType.Int32;
				colvarIdHistoriaClinicaPerinatal.MaxLength = 0;
				colvarIdHistoriaClinicaPerinatal.AutoIncrement = false;
				colvarIdHistoriaClinicaPerinatal.IsNullable = false;
				colvarIdHistoriaClinicaPerinatal.IsPrimaryKey = false;
				colvarIdHistoriaClinicaPerinatal.IsForeignKey = false;
				colvarIdHistoriaClinicaPerinatal.IsReadOnly = false;
				colvarIdHistoriaClinicaPerinatal.DefaultSetting = @"";
				colvarIdHistoriaClinicaPerinatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHistoriaClinicaPerinatal);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "Fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarMotivo = new TableSchema.TableColumn(schema);
				colvarMotivo.ColumnName = "Motivo";
				colvarMotivo.DataType = DbType.AnsiString;
				colvarMotivo.MaxLength = -1;
				colvarMotivo.AutoIncrement = false;
				colvarMotivo.IsNullable = true;
				colvarMotivo.IsPrimaryKey = false;
				colvarMotivo.IsForeignKey = false;
				colvarMotivo.IsReadOnly = false;
				colvarMotivo.DefaultSetting = @"";
				colvarMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivo);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "Observaciones";
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
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_Interconsulta",schema);
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
		  
		[XmlAttribute("IdHistoriaClinicaPerinatal")]
		[Bindable(true)]
		public int IdHistoriaClinicaPerinatal 
		{
			get { return GetColumnValue<int>(Columns.IdHistoriaClinicaPerinatal); }
			set { SetColumnValue(Columns.IdHistoriaClinicaPerinatal, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Motivo")]
		[Bindable(true)]
		public string Motivo 
		{
			get { return GetColumnValue<string>(Columns.Motivo); }
			set { SetColumnValue(Columns.Motivo, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
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
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
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
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this AprInterconsultum
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this AprInterconsultum
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
		public static void Insert(int varIdHistoriaClinicaPerinatal,int varIdEfector,DateTime? varFecha,string varMotivo,string varObservaciones,int varIdProfesional,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprInterconsultum item = new AprInterconsultum();
			
			item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
			item.IdEfector = varIdEfector;
			
			item.Fecha = varFecha;
			
			item.Motivo = varMotivo;
			
			item.Observaciones = varObservaciones;
			
			item.IdProfesional = varIdProfesional;
			
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
		public static void Update(int varIdInterconsulta,int varIdHistoriaClinicaPerinatal,int varIdEfector,DateTime? varFecha,string varMotivo,string varObservaciones,int varIdProfesional,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprInterconsultum item = new AprInterconsultum();
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
				item.IdEfector = varIdEfector;
			
				item.Fecha = varFecha;
			
				item.Motivo = varMotivo;
			
				item.Observaciones = varObservaciones;
			
				item.IdProfesional = varIdProfesional;
			
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
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdHistoriaClinicaPerinatalColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string IdHistoriaClinicaPerinatal = @"idHistoriaClinicaPerinatal";
			 public static string IdEfector = @"idEfector";
			 public static string Fecha = @"Fecha";
			 public static string Motivo = @"Motivo";
			 public static string Observaciones = @"Observaciones";
			 public static string IdProfesional = @"idProfesional";
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
