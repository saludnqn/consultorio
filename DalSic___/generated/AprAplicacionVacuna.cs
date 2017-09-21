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
	/// Strongly-typed collection for the AprAplicacionVacuna class.
	/// </summary>
    [Serializable]
	public partial class AprAplicacionVacunaCollection : ActiveList<AprAplicacionVacuna, AprAplicacionVacunaCollection>
	{	   
		public AprAplicacionVacunaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAplicacionVacunaCollection</returns>
		public AprAplicacionVacunaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAplicacionVacuna o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AplicacionVacuna table.
	/// </summary>
	[Serializable]
	public partial class AprAplicacionVacuna : ActiveRecord<AprAplicacionVacuna>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAplicacionVacuna()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAplicacionVacuna(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAplicacionVacuna(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAplicacionVacuna(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AplicacionVacuna", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAplicacionVacuna = new TableSchema.TableColumn(schema);
				colvarIdAplicacionVacuna.ColumnName = "idAplicacionVacuna";
				colvarIdAplicacionVacuna.DataType = DbType.Int32;
				colvarIdAplicacionVacuna.MaxLength = 0;
				colvarIdAplicacionVacuna.AutoIncrement = true;
				colvarIdAplicacionVacuna.IsNullable = false;
				colvarIdAplicacionVacuna.IsPrimaryKey = true;
				colvarIdAplicacionVacuna.IsForeignKey = false;
				colvarIdAplicacionVacuna.IsReadOnly = false;
				colvarIdAplicacionVacuna.DefaultSetting = @"";
				colvarIdAplicacionVacuna.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAplicacionVacuna);
				
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
				
				TableSchema.TableColumn colvarIdVacuna = new TableSchema.TableColumn(schema);
				colvarIdVacuna.ColumnName = "idVacuna";
				colvarIdVacuna.DataType = DbType.Int32;
				colvarIdVacuna.MaxLength = 0;
				colvarIdVacuna.AutoIncrement = false;
				colvarIdVacuna.IsNullable = false;
				colvarIdVacuna.IsPrimaryKey = false;
				colvarIdVacuna.IsForeignKey = true;
				colvarIdVacuna.IsReadOnly = false;
				colvarIdVacuna.DefaultSetting = @"";
				
					colvarIdVacuna.ForeignKeyTableName = "Sys_Medicamento";
				schema.Columns.Add(colvarIdVacuna);
				
				TableSchema.TableColumn colvarFechaAplicacion = new TableSchema.TableColumn(schema);
				colvarFechaAplicacion.ColumnName = "FechaAplicacion";
				colvarFechaAplicacion.DataType = DbType.DateTime;
				colvarFechaAplicacion.MaxLength = 0;
				colvarFechaAplicacion.AutoIncrement = false;
				colvarFechaAplicacion.IsNullable = false;
				colvarFechaAplicacion.IsPrimaryKey = false;
				colvarFechaAplicacion.IsForeignKey = false;
				colvarFechaAplicacion.IsReadOnly = false;
				colvarFechaAplicacion.DefaultSetting = @"";
				colvarFechaAplicacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAplicacion);
				
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
				
				TableSchema.TableColumn colvarIdNumeroDosis = new TableSchema.TableColumn(schema);
				colvarIdNumeroDosis.ColumnName = "idNumeroDosis";
				colvarIdNumeroDosis.DataType = DbType.Int32;
				colvarIdNumeroDosis.MaxLength = 0;
				colvarIdNumeroDosis.AutoIncrement = false;
				colvarIdNumeroDosis.IsNullable = true;
				colvarIdNumeroDosis.IsPrimaryKey = false;
				colvarIdNumeroDosis.IsForeignKey = false;
				colvarIdNumeroDosis.IsReadOnly = false;
				colvarIdNumeroDosis.DefaultSetting = @"";
				colvarIdNumeroDosis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNumeroDosis);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = true;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				
						colvarBaja.DefaultSetting = @"((0))";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_AplicacionVacuna",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAplicacionVacuna")]
		[Bindable(true)]
		public int IdAplicacionVacuna 
		{
			get { return GetColumnValue<int>(Columns.IdAplicacionVacuna); }
			set { SetColumnValue(Columns.IdAplicacionVacuna, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdVacuna")]
		[Bindable(true)]
		public int IdVacuna 
		{
			get { return GetColumnValue<int>(Columns.IdVacuna); }
			set { SetColumnValue(Columns.IdVacuna, value); }
		}
		  
		[XmlAttribute("FechaAplicacion")]
		[Bindable(true)]
		public DateTime FechaAplicacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAplicacion); }
			set { SetColumnValue(Columns.FechaAplicacion, value); }
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
		  
		[XmlAttribute("IdNumeroDosis")]
		[Bindable(true)]
		public int? IdNumeroDosis 
		{
			get { return GetColumnValue<int?>(Columns.IdNumeroDosis); }
			set { SetColumnValue(Columns.IdNumeroDosis, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool? Baja 
		{
			get { return GetColumnValue<bool?>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysMedicamento ActiveRecord object related to this AprAplicacionVacuna
		/// 
		/// </summary>
		public DalSic.SysMedicamento SysMedicamento
		{
			get { return DalSic.SysMedicamento.FetchByID(this.IdVacuna); }
			set { SetColumnValue("idVacuna", value.IdMedicamento); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varIdVacuna,DateTime varFechaAplicacion,string varObservacion,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdNumeroDosis,bool? varBaja)
		{
			AprAplicacionVacuna item = new AprAplicacionVacuna();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdVacuna = varIdVacuna;
			
			item.FechaAplicacion = varFechaAplicacion;
			
			item.Observacion = varObservacion;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IdNumeroDosis = varIdNumeroDosis;
			
			item.Baja = varBaja;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAplicacionVacuna,int varIdPaciente,int varIdVacuna,DateTime varFechaAplicacion,string varObservacion,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdNumeroDosis,bool? varBaja)
		{
			AprAplicacionVacuna item = new AprAplicacionVacuna();
			
				item.IdAplicacionVacuna = varIdAplicacionVacuna;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdVacuna = varIdVacuna;
			
				item.FechaAplicacion = varFechaAplicacion;
			
				item.Observacion = varObservacion;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.IdNumeroDosis = varIdNumeroDosis;
			
				item.Baja = varBaja;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAplicacionVacunaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVacunaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAplicacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNumeroDosisColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAplicacionVacuna = @"idAplicacionVacuna";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdVacuna = @"idVacuna";
			 public static string FechaAplicacion = @"FechaAplicacion";
			 public static string Observacion = @"Observacion";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IdNumeroDosis = @"idNumeroDosis";
			 public static string Baja = @"baja";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
