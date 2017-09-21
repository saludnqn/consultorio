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
	/// Strongly-typed collection for the PnCurriculumReferencium class.
	/// </summary>
    [Serializable]
	public partial class PnCurriculumReferenciumCollection : ActiveList<PnCurriculumReferencium, PnCurriculumReferenciumCollection>
	{	   
		public PnCurriculumReferenciumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCurriculumReferenciumCollection</returns>
		public PnCurriculumReferenciumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCurriculumReferencium o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_curriculum_referencia table.
	/// </summary>
	[Serializable]
	public partial class PnCurriculumReferencium : ActiveRecord<PnCurriculumReferencium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCurriculumReferencium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCurriculumReferencium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCurriculumReferencium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCurriculumReferencium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_curriculum_referencia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCurriculumReferencia = new TableSchema.TableColumn(schema);
				colvarIdCurriculumReferencia.ColumnName = "id_curriculum_referencia";
				colvarIdCurriculumReferencia.DataType = DbType.Int32;
				colvarIdCurriculumReferencia.MaxLength = 0;
				colvarIdCurriculumReferencia.AutoIncrement = true;
				colvarIdCurriculumReferencia.IsNullable = false;
				colvarIdCurriculumReferencia.IsPrimaryKey = true;
				colvarIdCurriculumReferencia.IsForeignKey = false;
				colvarIdCurriculumReferencia.IsReadOnly = false;
				colvarIdCurriculumReferencia.DefaultSetting = @"";
				colvarIdCurriculumReferencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCurriculumReferencia);
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = false;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = false;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarEmpleador = new TableSchema.TableColumn(schema);
				colvarEmpleador.ColumnName = "empleador";
				colvarEmpleador.DataType = DbType.AnsiString;
				colvarEmpleador.MaxLength = -1;
				colvarEmpleador.AutoIncrement = false;
				colvarEmpleador.IsNullable = false;
				colvarEmpleador.IsPrimaryKey = false;
				colvarEmpleador.IsForeignKey = false;
				colvarEmpleador.IsReadOnly = false;
				colvarEmpleador.DefaultSetting = @"";
				colvarEmpleador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmpleador);
				
				TableSchema.TableColumn colvarDomicilioEmpresa = new TableSchema.TableColumn(schema);
				colvarDomicilioEmpresa.ColumnName = "domicilio_empresa";
				colvarDomicilioEmpresa.DataType = DbType.AnsiString;
				colvarDomicilioEmpresa.MaxLength = -1;
				colvarDomicilioEmpresa.AutoIncrement = false;
				colvarDomicilioEmpresa.IsNullable = true;
				colvarDomicilioEmpresa.IsPrimaryKey = false;
				colvarDomicilioEmpresa.IsForeignKey = false;
				colvarDomicilioEmpresa.IsReadOnly = false;
				colvarDomicilioEmpresa.DefaultSetting = @"";
				colvarDomicilioEmpresa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilioEmpresa);
				
				TableSchema.TableColumn colvarDesde = new TableSchema.TableColumn(schema);
				colvarDesde.ColumnName = "desde";
				colvarDesde.DataType = DbType.DateTime;
				colvarDesde.MaxLength = 0;
				colvarDesde.AutoIncrement = false;
				colvarDesde.IsNullable = true;
				colvarDesde.IsPrimaryKey = false;
				colvarDesde.IsForeignKey = false;
				colvarDesde.IsReadOnly = false;
				colvarDesde.DefaultSetting = @"";
				colvarDesde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDesde);
				
				TableSchema.TableColumn colvarHasta = new TableSchema.TableColumn(schema);
				colvarHasta.ColumnName = "hasta";
				colvarHasta.DataType = DbType.DateTime;
				colvarHasta.MaxLength = 0;
				colvarHasta.AutoIncrement = false;
				colvarHasta.IsNullable = true;
				colvarHasta.IsPrimaryKey = false;
				colvarHasta.IsForeignKey = false;
				colvarHasta.IsReadOnly = false;
				colvarHasta.DefaultSetting = @"";
				colvarHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHasta);
				
				TableSchema.TableColumn colvarTareas = new TableSchema.TableColumn(schema);
				colvarTareas.ColumnName = "tareas";
				colvarTareas.DataType = DbType.AnsiString;
				colvarTareas.MaxLength = -1;
				colvarTareas.AutoIncrement = false;
				colvarTareas.IsNullable = false;
				colvarTareas.IsPrimaryKey = false;
				colvarTareas.IsForeignKey = false;
				colvarTareas.IsReadOnly = false;
				colvarTareas.DefaultSetting = @"";
				colvarTareas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTareas);
				
				TableSchema.TableColumn colvarCertificado = new TableSchema.TableColumn(schema);
				colvarCertificado.ColumnName = "certificado";
				colvarCertificado.DataType = DbType.AnsiStringFixedLength;
				colvarCertificado.MaxLength = 1;
				colvarCertificado.AutoIncrement = false;
				colvarCertificado.IsNullable = false;
				colvarCertificado.IsPrimaryKey = false;
				colvarCertificado.IsForeignKey = false;
				colvarCertificado.IsReadOnly = false;
				colvarCertificado.DefaultSetting = @"";
				colvarCertificado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCertificado);
				
				TableSchema.TableColumn colvarReferencias = new TableSchema.TableColumn(schema);
				colvarReferencias.ColumnName = "referencias";
				colvarReferencias.DataType = DbType.AnsiString;
				colvarReferencias.MaxLength = -1;
				colvarReferencias.AutoIncrement = false;
				colvarReferencias.IsNullable = true;
				colvarReferencias.IsPrimaryKey = false;
				colvarReferencias.IsForeignKey = false;
				colvarReferencias.IsReadOnly = false;
				colvarReferencias.DefaultSetting = @"";
				colvarReferencias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferencias);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = -1;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = -1;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_curriculum_referencia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCurriculumReferencia")]
		[Bindable(true)]
		public int IdCurriculumReferencia 
		{
			get { return GetColumnValue<int>(Columns.IdCurriculumReferencia); }
			set { SetColumnValue(Columns.IdCurriculumReferencia, value); }
		}
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("Empleador")]
		[Bindable(true)]
		public string Empleador 
		{
			get { return GetColumnValue<string>(Columns.Empleador); }
			set { SetColumnValue(Columns.Empleador, value); }
		}
		  
		[XmlAttribute("DomicilioEmpresa")]
		[Bindable(true)]
		public string DomicilioEmpresa 
		{
			get { return GetColumnValue<string>(Columns.DomicilioEmpresa); }
			set { SetColumnValue(Columns.DomicilioEmpresa, value); }
		}
		  
		[XmlAttribute("Desde")]
		[Bindable(true)]
		public DateTime? Desde 
		{
			get { return GetColumnValue<DateTime?>(Columns.Desde); }
			set { SetColumnValue(Columns.Desde, value); }
		}
		  
		[XmlAttribute("Hasta")]
		[Bindable(true)]
		public DateTime? Hasta 
		{
			get { return GetColumnValue<DateTime?>(Columns.Hasta); }
			set { SetColumnValue(Columns.Hasta, value); }
		}
		  
		[XmlAttribute("Tareas")]
		[Bindable(true)]
		public string Tareas 
		{
			get { return GetColumnValue<string>(Columns.Tareas); }
			set { SetColumnValue(Columns.Tareas, value); }
		}
		  
		[XmlAttribute("Certificado")]
		[Bindable(true)]
		public string Certificado 
		{
			get { return GetColumnValue<string>(Columns.Certificado); }
			set { SetColumnValue(Columns.Certificado, value); }
		}
		  
		[XmlAttribute("Referencias")]
		[Bindable(true)]
		public string Referencias 
		{
			get { return GetColumnValue<string>(Columns.Referencias); }
			set { SetColumnValue(Columns.Referencias, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdLegajo,string varEmpleador,string varDomicilioEmpresa,DateTime? varDesde,DateTime? varHasta,string varTareas,string varCertificado,string varReferencias,string varDomicilio,string varTelefono)
		{
			PnCurriculumReferencium item = new PnCurriculumReferencium();
			
			item.IdLegajo = varIdLegajo;
			
			item.Empleador = varEmpleador;
			
			item.DomicilioEmpresa = varDomicilioEmpresa;
			
			item.Desde = varDesde;
			
			item.Hasta = varHasta;
			
			item.Tareas = varTareas;
			
			item.Certificado = varCertificado;
			
			item.Referencias = varReferencias;
			
			item.Domicilio = varDomicilio;
			
			item.Telefono = varTelefono;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCurriculumReferencia,int varIdLegajo,string varEmpleador,string varDomicilioEmpresa,DateTime? varDesde,DateTime? varHasta,string varTareas,string varCertificado,string varReferencias,string varDomicilio,string varTelefono)
		{
			PnCurriculumReferencium item = new PnCurriculumReferencium();
			
				item.IdCurriculumReferencia = varIdCurriculumReferencia;
			
				item.IdLegajo = varIdLegajo;
			
				item.Empleador = varEmpleador;
			
				item.DomicilioEmpresa = varDomicilioEmpresa;
			
				item.Desde = varDesde;
			
				item.Hasta = varHasta;
			
				item.Tareas = varTareas;
			
				item.Certificado = varCertificado;
			
				item.Referencias = varReferencias;
			
				item.Domicilio = varDomicilio;
			
				item.Telefono = varTelefono;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCurriculumReferenciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EmpleadorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioEmpresaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DesdeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn HastaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TareasColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CertificadoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ReferenciasColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCurriculumReferencia = @"id_curriculum_referencia";
			 public static string IdLegajo = @"id_legajo";
			 public static string Empleador = @"empleador";
			 public static string DomicilioEmpresa = @"domicilio_empresa";
			 public static string Desde = @"desde";
			 public static string Hasta = @"hasta";
			 public static string Tareas = @"tareas";
			 public static string Certificado = @"certificado";
			 public static string Referencias = @"referencias";
			 public static string Domicilio = @"domicilio";
			 public static string Telefono = @"telefono";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
