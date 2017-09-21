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
	/// Strongly-typed collection for the JmCertificadoMedico class.
	/// </summary>
    [Serializable]
	public partial class JmCertificadoMedicoCollection : ActiveList<JmCertificadoMedico, JmCertificadoMedicoCollection>
	{	   
		public JmCertificadoMedicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>JmCertificadoMedicoCollection</returns>
		public JmCertificadoMedicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                JmCertificadoMedico o = this[i];
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
	/// This is an ActiveRecord class which wraps the JM_CertificadoMedico table.
	/// </summary>
	[Serializable]
	public partial class JmCertificadoMedico : ActiveRecord<JmCertificadoMedico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public JmCertificadoMedico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public JmCertificadoMedico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public JmCertificadoMedico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public JmCertificadoMedico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("JM_CertificadoMedico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCertificadoMedico = new TableSchema.TableColumn(schema);
				colvarIdCertificadoMedico.ColumnName = "idCertificadoMedico";
				colvarIdCertificadoMedico.DataType = DbType.Int32;
				colvarIdCertificadoMedico.MaxLength = 0;
				colvarIdCertificadoMedico.AutoIncrement = true;
				colvarIdCertificadoMedico.IsNullable = false;
				colvarIdCertificadoMedico.IsPrimaryKey = true;
				colvarIdCertificadoMedico.IsForeignKey = false;
				colvarIdCertificadoMedico.IsReadOnly = false;
				colvarIdCertificadoMedico.DefaultSetting = @"";
				colvarIdCertificadoMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCertificadoMedico);
				
				TableSchema.TableColumn colvarIdPersonal = new TableSchema.TableColumn(schema);
				colvarIdPersonal.ColumnName = "idPersonal";
				colvarIdPersonal.DataType = DbType.AnsiStringFixedLength;
				colvarIdPersonal.MaxLength = 10;
				colvarIdPersonal.AutoIncrement = false;
				colvarIdPersonal.IsNullable = true;
				colvarIdPersonal.IsPrimaryKey = false;
				colvarIdPersonal.IsForeignKey = false;
				colvarIdPersonal.IsReadOnly = false;
				colvarIdPersonal.DefaultSetting = @"";
				colvarIdPersonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPersonal);
				
				TableSchema.TableColumn colvarFechaCertificado = new TableSchema.TableColumn(schema);
				colvarFechaCertificado.ColumnName = "FechaCertificado";
				colvarFechaCertificado.DataType = DbType.DateTime;
				colvarFechaCertificado.MaxLength = 0;
				colvarFechaCertificado.AutoIncrement = false;
				colvarFechaCertificado.IsNullable = true;
				colvarFechaCertificado.IsPrimaryKey = false;
				colvarFechaCertificado.IsForeignKey = false;
				colvarFechaCertificado.IsReadOnly = false;
				colvarFechaCertificado.DefaultSetting = @"";
				colvarFechaCertificado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCertificado);
				
				TableSchema.TableColumn colvarFechaEntrega = new TableSchema.TableColumn(schema);
				colvarFechaEntrega.ColumnName = "FechaEntrega";
				colvarFechaEntrega.DataType = DbType.DateTime;
				colvarFechaEntrega.MaxLength = 0;
				colvarFechaEntrega.AutoIncrement = false;
				colvarFechaEntrega.IsNullable = true;
				colvarFechaEntrega.IsPrimaryKey = false;
				colvarFechaEntrega.IsForeignKey = false;
				colvarFechaEntrega.IsReadOnly = false;
				colvarFechaEntrega.DefaultSetting = @"";
				colvarFechaEntrega.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEntrega);
				
				TableSchema.TableColumn colvarFechaDesde = new TableSchema.TableColumn(schema);
				colvarFechaDesde.ColumnName = "FechaDesde";
				colvarFechaDesde.DataType = DbType.DateTime;
				colvarFechaDesde.MaxLength = 0;
				colvarFechaDesde.AutoIncrement = false;
				colvarFechaDesde.IsNullable = true;
				colvarFechaDesde.IsPrimaryKey = false;
				colvarFechaDesde.IsForeignKey = false;
				colvarFechaDesde.IsReadOnly = false;
				colvarFechaDesde.DefaultSetting = @"";
				colvarFechaDesde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDesde);
				
				TableSchema.TableColumn colvarFechaHasta = new TableSchema.TableColumn(schema);
				colvarFechaHasta.ColumnName = "FechaHasta";
				colvarFechaHasta.DataType = DbType.DateTime;
				colvarFechaHasta.MaxLength = 0;
				colvarFechaHasta.AutoIncrement = false;
				colvarFechaHasta.IsNullable = true;
				colvarFechaHasta.IsPrimaryKey = false;
				colvarFechaHasta.IsForeignKey = false;
				colvarFechaHasta.IsReadOnly = false;
				colvarFechaHasta.DefaultSetting = @"";
				colvarFechaHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHasta);
				
				TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
				colvarDiagnostico.ColumnName = "Diagnostico";
				colvarDiagnostico.DataType = DbType.String;
				colvarDiagnostico.MaxLength = 150;
				colvarDiagnostico.AutoIncrement = false;
				colvarDiagnostico.IsNullable = true;
				colvarDiagnostico.IsPrimaryKey = false;
				colvarDiagnostico.IsForeignKey = false;
				colvarDiagnostico.IsReadOnly = false;
				colvarDiagnostico.DefaultSetting = @"";
				colvarDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnostico);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "Observaciones";
				colvarObservaciones.DataType = DbType.String;
				colvarObservaciones.MaxLength = 150;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarMedicoCertificado = new TableSchema.TableColumn(schema);
				colvarMedicoCertificado.ColumnName = "MedicoCertificado";
				colvarMedicoCertificado.DataType = DbType.String;
				colvarMedicoCertificado.MaxLength = 100;
				colvarMedicoCertificado.AutoIncrement = false;
				colvarMedicoCertificado.IsNullable = true;
				colvarMedicoCertificado.IsPrimaryKey = false;
				colvarMedicoCertificado.IsForeignKey = false;
				colvarMedicoCertificado.IsReadOnly = false;
				colvarMedicoCertificado.DefaultSetting = @"";
				colvarMedicoCertificado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicoCertificado);
				
				TableSchema.TableColumn colvarIdUsuarioCarga = new TableSchema.TableColumn(schema);
				colvarIdUsuarioCarga.ColumnName = "idUsuarioCarga";
				colvarIdUsuarioCarga.DataType = DbType.Int32;
				colvarIdUsuarioCarga.MaxLength = 0;
				colvarIdUsuarioCarga.AutoIncrement = false;
				colvarIdUsuarioCarga.IsNullable = true;
				colvarIdUsuarioCarga.IsPrimaryKey = false;
				colvarIdUsuarioCarga.IsForeignKey = false;
				colvarIdUsuarioCarga.IsReadOnly = false;
				colvarIdUsuarioCarga.DefaultSetting = @"";
				colvarIdUsuarioCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioCarga);
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "FechaCarga";
				colvarFechaCarga.DataType = DbType.DateTime;
				colvarFechaCarga.MaxLength = 0;
				colvarFechaCarga.AutoIncrement = false;
				colvarFechaCarga.IsNullable = true;
				colvarFechaCarga.IsPrimaryKey = false;
				colvarFechaCarga.IsForeignKey = false;
				colvarFechaCarga.IsReadOnly = false;
				colvarFechaCarga.DefaultSetting = @"";
				colvarFechaCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCarga);
				
				TableSchema.TableColumn colvarIdMedicoAuditor = new TableSchema.TableColumn(schema);
				colvarIdMedicoAuditor.ColumnName = "idMedicoAuditor";
				colvarIdMedicoAuditor.DataType = DbType.Int32;
				colvarIdMedicoAuditor.MaxLength = 0;
				colvarIdMedicoAuditor.AutoIncrement = false;
				colvarIdMedicoAuditor.IsNullable = true;
				colvarIdMedicoAuditor.IsPrimaryKey = false;
				colvarIdMedicoAuditor.IsForeignKey = false;
				colvarIdMedicoAuditor.IsReadOnly = false;
				
						colvarIdMedicoAuditor.DefaultSetting = @"((-1))";
				colvarIdMedicoAuditor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedicoAuditor);
				
				TableSchema.TableColumn colvarFechaAuditoria = new TableSchema.TableColumn(schema);
				colvarFechaAuditoria.ColumnName = "FechaAuditoria";
				colvarFechaAuditoria.DataType = DbType.DateTime;
				colvarFechaAuditoria.MaxLength = 0;
				colvarFechaAuditoria.AutoIncrement = false;
				colvarFechaAuditoria.IsNullable = true;
				colvarFechaAuditoria.IsPrimaryKey = false;
				colvarFechaAuditoria.IsForeignKey = false;
				colvarFechaAuditoria.IsReadOnly = false;
				colvarFechaAuditoria.DefaultSetting = @"";
				colvarFechaAuditoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAuditoria);
				
				TableSchema.TableColumn colvarOmologado = new TableSchema.TableColumn(schema);
				colvarOmologado.ColumnName = "Omologado";
				colvarOmologado.DataType = DbType.String;
				colvarOmologado.MaxLength = 11;
				colvarOmologado.AutoIncrement = false;
				colvarOmologado.IsNullable = true;
				colvarOmologado.IsPrimaryKey = false;
				colvarOmologado.IsForeignKey = false;
				colvarOmologado.IsReadOnly = false;
				colvarOmologado.DefaultSetting = @"";
				colvarOmologado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOmologado);
				
				TableSchema.TableColumn colvarIdLPago = new TableSchema.TableColumn(schema);
				colvarIdLPago.ColumnName = "idLPago";
				colvarIdLPago.DataType = DbType.String;
				colvarIdLPago.MaxLength = 4;
				colvarIdLPago.AutoIncrement = false;
				colvarIdLPago.IsNullable = true;
				colvarIdLPago.IsPrimaryKey = false;
				colvarIdLPago.IsForeignKey = false;
				colvarIdLPago.IsReadOnly = false;
				colvarIdLPago.DefaultSetting = @"";
				colvarIdLPago.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLPago);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("JM_CertificadoMedico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCertificadoMedico")]
		[Bindable(true)]
		public int IdCertificadoMedico 
		{
			get { return GetColumnValue<int>(Columns.IdCertificadoMedico); }
			set { SetColumnValue(Columns.IdCertificadoMedico, value); }
		}
		  
		[XmlAttribute("IdPersonal")]
		[Bindable(true)]
		public string IdPersonal 
		{
			get { return GetColumnValue<string>(Columns.IdPersonal); }
			set { SetColumnValue(Columns.IdPersonal, value); }
		}
		  
		[XmlAttribute("FechaCertificado")]
		[Bindable(true)]
		public DateTime? FechaCertificado 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCertificado); }
			set { SetColumnValue(Columns.FechaCertificado, value); }
		}
		  
		[XmlAttribute("FechaEntrega")]
		[Bindable(true)]
		public DateTime? FechaEntrega 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEntrega); }
			set { SetColumnValue(Columns.FechaEntrega, value); }
		}
		  
		[XmlAttribute("FechaDesde")]
		[Bindable(true)]
		public DateTime? FechaDesde 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDesde); }
			set { SetColumnValue(Columns.FechaDesde, value); }
		}
		  
		[XmlAttribute("FechaHasta")]
		[Bindable(true)]
		public DateTime? FechaHasta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaHasta); }
			set { SetColumnValue(Columns.FechaHasta, value); }
		}
		  
		[XmlAttribute("Diagnostico")]
		[Bindable(true)]
		public string Diagnostico 
		{
			get { return GetColumnValue<string>(Columns.Diagnostico); }
			set { SetColumnValue(Columns.Diagnostico, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("MedicoCertificado")]
		[Bindable(true)]
		public string MedicoCertificado 
		{
			get { return GetColumnValue<string>(Columns.MedicoCertificado); }
			set { SetColumnValue(Columns.MedicoCertificado, value); }
		}
		  
		[XmlAttribute("IdUsuarioCarga")]
		[Bindable(true)]
		public int? IdUsuarioCarga 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuarioCarga); }
			set { SetColumnValue(Columns.IdUsuarioCarga, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("IdMedicoAuditor")]
		[Bindable(true)]
		public int? IdMedicoAuditor 
		{
			get { return GetColumnValue<int?>(Columns.IdMedicoAuditor); }
			set { SetColumnValue(Columns.IdMedicoAuditor, value); }
		}
		  
		[XmlAttribute("FechaAuditoria")]
		[Bindable(true)]
		public DateTime? FechaAuditoria 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAuditoria); }
			set { SetColumnValue(Columns.FechaAuditoria, value); }
		}
		  
		[XmlAttribute("Omologado")]
		[Bindable(true)]
		public string Omologado 
		{
			get { return GetColumnValue<string>(Columns.Omologado); }
			set { SetColumnValue(Columns.Omologado, value); }
		}
		  
		[XmlAttribute("IdLPago")]
		[Bindable(true)]
		public string IdLPago 
		{
			get { return GetColumnValue<string>(Columns.IdLPago); }
			set { SetColumnValue(Columns.IdLPago, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varIdPersonal,DateTime? varFechaCertificado,DateTime? varFechaEntrega,DateTime? varFechaDesde,DateTime? varFechaHasta,string varDiagnostico,string varObservaciones,string varMedicoCertificado,int? varIdUsuarioCarga,DateTime? varFechaCarga,int? varIdMedicoAuditor,DateTime? varFechaAuditoria,string varOmologado,string varIdLPago)
		{
			JmCertificadoMedico item = new JmCertificadoMedico();
			
			item.IdPersonal = varIdPersonal;
			
			item.FechaCertificado = varFechaCertificado;
			
			item.FechaEntrega = varFechaEntrega;
			
			item.FechaDesde = varFechaDesde;
			
			item.FechaHasta = varFechaHasta;
			
			item.Diagnostico = varDiagnostico;
			
			item.Observaciones = varObservaciones;
			
			item.MedicoCertificado = varMedicoCertificado;
			
			item.IdUsuarioCarga = varIdUsuarioCarga;
			
			item.FechaCarga = varFechaCarga;
			
			item.IdMedicoAuditor = varIdMedicoAuditor;
			
			item.FechaAuditoria = varFechaAuditoria;
			
			item.Omologado = varOmologado;
			
			item.IdLPago = varIdLPago;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCertificadoMedico,string varIdPersonal,DateTime? varFechaCertificado,DateTime? varFechaEntrega,DateTime? varFechaDesde,DateTime? varFechaHasta,string varDiagnostico,string varObservaciones,string varMedicoCertificado,int? varIdUsuarioCarga,DateTime? varFechaCarga,int? varIdMedicoAuditor,DateTime? varFechaAuditoria,string varOmologado,string varIdLPago)
		{
			JmCertificadoMedico item = new JmCertificadoMedico();
			
				item.IdCertificadoMedico = varIdCertificadoMedico;
			
				item.IdPersonal = varIdPersonal;
			
				item.FechaCertificado = varFechaCertificado;
			
				item.FechaEntrega = varFechaEntrega;
			
				item.FechaDesde = varFechaDesde;
			
				item.FechaHasta = varFechaHasta;
			
				item.Diagnostico = varDiagnostico;
			
				item.Observaciones = varObservaciones;
			
				item.MedicoCertificado = varMedicoCertificado;
			
				item.IdUsuarioCarga = varIdUsuarioCarga;
			
				item.FechaCarga = varFechaCarga;
			
				item.IdMedicoAuditor = varIdMedicoAuditor;
			
				item.FechaAuditoria = varFechaAuditoria;
			
				item.Omologado = varOmologado;
			
				item.IdLPago = varIdLPago;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCertificadoMedicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPersonalColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCertificadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEntregaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDesdeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHastaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoCertificadoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioCargaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMedicoAuditorColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAuditoriaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn OmologadoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLPagoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCertificadoMedico = @"idCertificadoMedico";
			 public static string IdPersonal = @"idPersonal";
			 public static string FechaCertificado = @"FechaCertificado";
			 public static string FechaEntrega = @"FechaEntrega";
			 public static string FechaDesde = @"FechaDesde";
			 public static string FechaHasta = @"FechaHasta";
			 public static string Diagnostico = @"Diagnostico";
			 public static string Observaciones = @"Observaciones";
			 public static string MedicoCertificado = @"MedicoCertificado";
			 public static string IdUsuarioCarga = @"idUsuarioCarga";
			 public static string FechaCarga = @"FechaCarga";
			 public static string IdMedicoAuditor = @"idMedicoAuditor";
			 public static string FechaAuditoria = @"FechaAuditoria";
			 public static string Omologado = @"Omologado";
			 public static string IdLPago = @"idLPago";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
