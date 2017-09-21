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
	/// Strongly-typed collection for the AprVisitaDomiciliarium class.
	/// </summary>
    [Serializable]
	public partial class AprVisitaDomiciliariumCollection : ActiveList<AprVisitaDomiciliarium, AprVisitaDomiciliariumCollection>
	{	   
		public AprVisitaDomiciliariumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprVisitaDomiciliariumCollection</returns>
		public AprVisitaDomiciliariumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprVisitaDomiciliarium o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_VisitaDomiciliaria table.
	/// </summary>
	[Serializable]
	public partial class AprVisitaDomiciliarium : ActiveRecord<AprVisitaDomiciliarium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprVisitaDomiciliarium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprVisitaDomiciliarium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprVisitaDomiciliarium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprVisitaDomiciliarium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_VisitaDomiciliaria", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdVisitaDomiciliaria = new TableSchema.TableColumn(schema);
				colvarIdVisitaDomiciliaria.ColumnName = "idVisitaDomiciliaria";
				colvarIdVisitaDomiciliaria.DataType = DbType.Int32;
				colvarIdVisitaDomiciliaria.MaxLength = 0;
				colvarIdVisitaDomiciliaria.AutoIncrement = true;
				colvarIdVisitaDomiciliaria.IsNullable = false;
				colvarIdVisitaDomiciliaria.IsPrimaryKey = true;
				colvarIdVisitaDomiciliaria.IsForeignKey = false;
				colvarIdVisitaDomiciliaria.IsReadOnly = false;
				colvarIdVisitaDomiciliaria.DefaultSetting = @"";
				colvarIdVisitaDomiciliaria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVisitaDomiciliaria);
				
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
				
				TableSchema.TableColumn colvarIdMotivoVisitaDomiciliaria = new TableSchema.TableColumn(schema);
				colvarIdMotivoVisitaDomiciliaria.ColumnName = "idMotivoVisitaDomiciliaria";
				colvarIdMotivoVisitaDomiciliaria.DataType = DbType.Int32;
				colvarIdMotivoVisitaDomiciliaria.MaxLength = 0;
				colvarIdMotivoVisitaDomiciliaria.AutoIncrement = false;
				colvarIdMotivoVisitaDomiciliaria.IsNullable = false;
				colvarIdMotivoVisitaDomiciliaria.IsPrimaryKey = false;
				colvarIdMotivoVisitaDomiciliaria.IsForeignKey = true;
				colvarIdMotivoVisitaDomiciliaria.IsReadOnly = false;
				colvarIdMotivoVisitaDomiciliaria.DefaultSetting = @"";
				
					colvarIdMotivoVisitaDomiciliaria.ForeignKeyTableName = "APR_MotivoVisitaDomiciliaria";
				schema.Columns.Add(colvarIdMotivoVisitaDomiciliaria);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "Fecha";
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
				
				TableSchema.TableColumn colvarOtroMotivo = new TableSchema.TableColumn(schema);
				colvarOtroMotivo.ColumnName = "OtroMotivo";
				colvarOtroMotivo.DataType = DbType.AnsiString;
				colvarOtroMotivo.MaxLength = 50;
				colvarOtroMotivo.AutoIncrement = false;
				colvarOtroMotivo.IsNullable = true;
				colvarOtroMotivo.IsPrimaryKey = false;
				colvarOtroMotivo.IsForeignKey = false;
				colvarOtroMotivo.IsReadOnly = false;
				colvarOtroMotivo.DefaultSetting = @"";
				colvarOtroMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtroMotivo);
				
				TableSchema.TableColumn colvarPersonal = new TableSchema.TableColumn(schema);
				colvarPersonal.ColumnName = "Personal";
				colvarPersonal.DataType = DbType.AnsiString;
				colvarPersonal.MaxLength = 50;
				colvarPersonal.AutoIncrement = false;
				colvarPersonal.IsNullable = false;
				colvarPersonal.IsPrimaryKey = false;
				colvarPersonal.IsForeignKey = false;
				colvarPersonal.IsReadOnly = false;
				colvarPersonal.DefaultSetting = @"";
				colvarPersonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPersonal);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "Observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 2147483647;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = true;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				colvarObservacion.DefaultSetting = @"";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_VisitaDomiciliaria",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdVisitaDomiciliaria")]
		[Bindable(true)]
		public int IdVisitaDomiciliaria 
		{
			get { return GetColumnValue<int>(Columns.IdVisitaDomiciliaria); }
			set { SetColumnValue(Columns.IdVisitaDomiciliaria, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdMotivoVisitaDomiciliaria")]
		[Bindable(true)]
		public int IdMotivoVisitaDomiciliaria 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoVisitaDomiciliaria); }
			set { SetColumnValue(Columns.IdMotivoVisitaDomiciliaria, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("OtroMotivo")]
		[Bindable(true)]
		public string OtroMotivo 
		{
			get { return GetColumnValue<string>(Columns.OtroMotivo); }
			set { SetColumnValue(Columns.OtroMotivo, value); }
		}
		  
		[XmlAttribute("Personal")]
		[Bindable(true)]
		public string Personal 
		{
			get { return GetColumnValue<string>(Columns.Personal); }
			set { SetColumnValue(Columns.Personal, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
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
		/// Returns a AprMotivoVisitaDomiciliarium ActiveRecord object related to this AprVisitaDomiciliarium
		/// 
		/// </summary>
		public DalSic.AprMotivoVisitaDomiciliarium AprMotivoVisitaDomiciliarium
		{
			get { return DalSic.AprMotivoVisitaDomiciliarium.FetchByID(this.IdMotivoVisitaDomiciliaria); }
			set { SetColumnValue("idMotivoVisitaDomiciliaria", value.IdMotivoVisitaDomiciliaria); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varIdMotivoVisitaDomiciliaria,DateTime varFecha,string varOtroMotivo,string varPersonal,string varObservacion,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprVisitaDomiciliarium item = new AprVisitaDomiciliarium();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdMotivoVisitaDomiciliaria = varIdMotivoVisitaDomiciliaria;
			
			item.Fecha = varFecha;
			
			item.OtroMotivo = varOtroMotivo;
			
			item.Personal = varPersonal;
			
			item.Observacion = varObservacion;
			
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
		public static void Update(int varIdVisitaDomiciliaria,int varIdPaciente,int varIdMotivoVisitaDomiciliaria,DateTime varFecha,string varOtroMotivo,string varPersonal,string varObservacion,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprVisitaDomiciliarium item = new AprVisitaDomiciliarium();
			
				item.IdVisitaDomiciliaria = varIdVisitaDomiciliaria;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdMotivoVisitaDomiciliaria = varIdMotivoVisitaDomiciliaria;
			
				item.Fecha = varFecha;
			
				item.OtroMotivo = varOtroMotivo;
			
				item.Personal = varPersonal;
			
				item.Observacion = varObservacion;
			
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
        
        
        public static TableSchema.TableColumn IdVisitaDomiciliariaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoVisitaDomiciliariaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn OtroMotivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PersonalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
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
			 public static string IdVisitaDomiciliaria = @"idVisitaDomiciliaria";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdMotivoVisitaDomiciliaria = @"idMotivoVisitaDomiciliaria";
			 public static string Fecha = @"Fecha";
			 public static string OtroMotivo = @"OtroMotivo";
			 public static string Personal = @"Personal";
			 public static string Observacion = @"Observacion";
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
