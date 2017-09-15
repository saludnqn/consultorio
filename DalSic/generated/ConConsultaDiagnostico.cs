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
	/// Strongly-typed collection for the ConConsultaDiagnostico class.
	/// </summary>
    [Serializable]
	public partial class ConConsultaDiagnosticoCollection : ActiveList<ConConsultaDiagnostico, ConConsultaDiagnosticoCollection>
	{	   
		public ConConsultaDiagnosticoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConConsultaDiagnosticoCollection</returns>
		public ConConsultaDiagnosticoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConConsultaDiagnostico o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_ConsultaDiagnostico table.
	/// </summary>
	[Serializable]
	public partial class ConConsultaDiagnostico : ActiveRecord<ConConsultaDiagnostico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConConsultaDiagnostico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConConsultaDiagnostico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConConsultaDiagnostico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConConsultaDiagnostico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_ConsultaDiagnostico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdConsultaDiagnostico = new TableSchema.TableColumn(schema);
				colvarIdConsultaDiagnostico.ColumnName = "idConsultaDiagnostico";
				colvarIdConsultaDiagnostico.DataType = DbType.Int32;
				colvarIdConsultaDiagnostico.MaxLength = 0;
				colvarIdConsultaDiagnostico.AutoIncrement = true;
				colvarIdConsultaDiagnostico.IsNullable = false;
				colvarIdConsultaDiagnostico.IsPrimaryKey = true;
				colvarIdConsultaDiagnostico.IsForeignKey = false;
				colvarIdConsultaDiagnostico.IsReadOnly = false;
				colvarIdConsultaDiagnostico.DefaultSetting = @"";
				colvarIdConsultaDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsultaDiagnostico);
				
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
				
				TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
				colvarIdConsulta.ColumnName = "idConsulta";
				colvarIdConsulta.DataType = DbType.Int32;
				colvarIdConsulta.MaxLength = 0;
				colvarIdConsulta.AutoIncrement = false;
				colvarIdConsulta.IsNullable = true;
				colvarIdConsulta.IsPrimaryKey = false;
				colvarIdConsulta.IsForeignKey = true;
				colvarIdConsulta.IsReadOnly = false;
				colvarIdConsulta.DefaultSetting = @"";
				
					colvarIdConsulta.ForeignKeyTableName = "CON_Consulta";
				schema.Columns.Add(colvarIdConsulta);
				
				TableSchema.TableColumn colvarPrincipal = new TableSchema.TableColumn(schema);
				colvarPrincipal.ColumnName = "principal";
				colvarPrincipal.DataType = DbType.Boolean;
				colvarPrincipal.MaxLength = 0;
				colvarPrincipal.AutoIncrement = false;
				colvarPrincipal.IsNullable = true;
				colvarPrincipal.IsPrimaryKey = false;
				colvarPrincipal.IsForeignKey = false;
				colvarPrincipal.IsReadOnly = false;
				colvarPrincipal.DefaultSetting = @"";
				colvarPrincipal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrincipal);
				
				TableSchema.TableColumn colvarCODCIE10 = new TableSchema.TableColumn(schema);
				colvarCODCIE10.ColumnName = "CODCIE10";
				colvarCODCIE10.DataType = DbType.Int32;
				colvarCODCIE10.MaxLength = 0;
				colvarCODCIE10.AutoIncrement = false;
				colvarCODCIE10.IsNullable = true;
				colvarCODCIE10.IsPrimaryKey = false;
				colvarCODCIE10.IsForeignKey = true;
				colvarCODCIE10.IsReadOnly = false;
				colvarCODCIE10.DefaultSetting = @"";
				
					colvarCODCIE10.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarCODCIE10);
				
				TableSchema.TableColumn colvarPrimerConsulta = new TableSchema.TableColumn(schema);
				colvarPrimerConsulta.ColumnName = "PrimerConsulta";
				colvarPrimerConsulta.DataType = DbType.Int32;
				colvarPrimerConsulta.MaxLength = 0;
				colvarPrimerConsulta.AutoIncrement = false;
				colvarPrimerConsulta.IsNullable = false;
				colvarPrimerConsulta.IsPrimaryKey = false;
				colvarPrimerConsulta.IsForeignKey = false;
				colvarPrimerConsulta.IsReadOnly = false;
				
						colvarPrimerConsulta.DefaultSetting = @"((0))";
				colvarPrimerConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimerConsulta);
				
				TableSchema.TableColumn colvarIdNivelDeAbordaje = new TableSchema.TableColumn(schema);
				colvarIdNivelDeAbordaje.ColumnName = "idNivelDeAbordaje";
				colvarIdNivelDeAbordaje.DataType = DbType.Int32;
				colvarIdNivelDeAbordaje.MaxLength = 0;
				colvarIdNivelDeAbordaje.AutoIncrement = false;
				colvarIdNivelDeAbordaje.IsNullable = true;
				colvarIdNivelDeAbordaje.IsPrimaryKey = false;
				colvarIdNivelDeAbordaje.IsForeignKey = false;
				colvarIdNivelDeAbordaje.IsReadOnly = false;
				colvarIdNivelDeAbordaje.DefaultSetting = @"";
				colvarIdNivelDeAbordaje.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNivelDeAbordaje);
				
				TableSchema.TableColumn colvarIdTipoPrestacionSaludMental = new TableSchema.TableColumn(schema);
				colvarIdTipoPrestacionSaludMental.ColumnName = "idTipoPrestacionSaludMental";
				colvarIdTipoPrestacionSaludMental.DataType = DbType.Int32;
				colvarIdTipoPrestacionSaludMental.MaxLength = 0;
				colvarIdTipoPrestacionSaludMental.AutoIncrement = false;
				colvarIdTipoPrestacionSaludMental.IsNullable = true;
				colvarIdTipoPrestacionSaludMental.IsPrimaryKey = false;
				colvarIdTipoPrestacionSaludMental.IsForeignKey = false;
				colvarIdTipoPrestacionSaludMental.IsReadOnly = false;
				colvarIdTipoPrestacionSaludMental.DefaultSetting = @"";
				colvarIdTipoPrestacionSaludMental.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoPrestacionSaludMental);
				
				TableSchema.TableColumn colvarIdTiempoInsumido = new TableSchema.TableColumn(schema);
				colvarIdTiempoInsumido.ColumnName = "idTiempoInsumido";
				colvarIdTiempoInsumido.DataType = DbType.Int32;
				colvarIdTiempoInsumido.MaxLength = 0;
				colvarIdTiempoInsumido.AutoIncrement = false;
				colvarIdTiempoInsumido.IsNullable = true;
				colvarIdTiempoInsumido.IsPrimaryKey = false;
				colvarIdTiempoInsumido.IsForeignKey = false;
				colvarIdTiempoInsumido.IsReadOnly = false;
				colvarIdTiempoInsumido.DefaultSetting = @"";
				colvarIdTiempoInsumido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTiempoInsumido);
				
				TableSchema.TableColumn colvarIdDemanda = new TableSchema.TableColumn(schema);
				colvarIdDemanda.ColumnName = "idDemanda";
				colvarIdDemanda.DataType = DbType.Int32;
				colvarIdDemanda.MaxLength = 0;
				colvarIdDemanda.AutoIncrement = false;
				colvarIdDemanda.IsNullable = true;
				colvarIdDemanda.IsPrimaryKey = false;
				colvarIdDemanda.IsForeignKey = false;
				colvarIdDemanda.IsReadOnly = false;
				colvarIdDemanda.DefaultSetting = @"";
				colvarIdDemanda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDemanda);
				
				TableSchema.TableColumn colvarRecursoHumano = new TableSchema.TableColumn(schema);
				colvarRecursoHumano.ColumnName = "RecursoHumano";
				colvarRecursoHumano.DataType = DbType.AnsiString;
				colvarRecursoHumano.MaxLength = 20;
				colvarRecursoHumano.AutoIncrement = false;
				colvarRecursoHumano.IsNullable = true;
				colvarRecursoHumano.IsPrimaryKey = false;
				colvarRecursoHumano.IsForeignKey = false;
				colvarRecursoHumano.IsReadOnly = false;
				colvarRecursoHumano.DefaultSetting = @"";
				colvarRecursoHumano.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecursoHumano);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_ConsultaDiagnostico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdConsultaDiagnostico")]
		[Bindable(true)]
		public int IdConsultaDiagnostico 
		{
			get { return GetColumnValue<int>(Columns.IdConsultaDiagnostico); }
			set { SetColumnValue(Columns.IdConsultaDiagnostico, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int? IdConsulta 
		{
			get { return GetColumnValue<int?>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("Principal")]
		[Bindable(true)]
		public bool? Principal 
		{
			get { return GetColumnValue<bool?>(Columns.Principal); }
			set { SetColumnValue(Columns.Principal, value); }
		}
		  
		[XmlAttribute("CODCIE10")]
		[Bindable(true)]
		public int? CODCIE10 
		{
			get { return GetColumnValue<int?>(Columns.CODCIE10); }
			set { SetColumnValue(Columns.CODCIE10, value); }
		}
		  
		[XmlAttribute("PrimerConsulta")]
		[Bindable(true)]
		public int PrimerConsulta 
		{
			get { return GetColumnValue<int>(Columns.PrimerConsulta); }
			set { SetColumnValue(Columns.PrimerConsulta, value); }
		}
		  
		[XmlAttribute("IdNivelDeAbordaje")]
		[Bindable(true)]
		public int? IdNivelDeAbordaje 
		{
			get { return GetColumnValue<int?>(Columns.IdNivelDeAbordaje); }
			set { SetColumnValue(Columns.IdNivelDeAbordaje, value); }
		}
		  
		[XmlAttribute("IdTipoPrestacionSaludMental")]
		[Bindable(true)]
		public int? IdTipoPrestacionSaludMental 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoPrestacionSaludMental); }
			set { SetColumnValue(Columns.IdTipoPrestacionSaludMental, value); }
		}
		  
		[XmlAttribute("IdTiempoInsumido")]
		[Bindable(true)]
		public int? IdTiempoInsumido 
		{
			get { return GetColumnValue<int?>(Columns.IdTiempoInsumido); }
			set { SetColumnValue(Columns.IdTiempoInsumido, value); }
		}
		  
		[XmlAttribute("IdDemanda")]
		[Bindable(true)]
		public int? IdDemanda 
		{
			get { return GetColumnValue<int?>(Columns.IdDemanda); }
			set { SetColumnValue(Columns.IdDemanda, value); }
		}
		  
		[XmlAttribute("RecursoHumano")]
		[Bindable(true)]
		public string RecursoHumano 
		{
			get { return GetColumnValue<string>(Columns.RecursoHumano); }
			set { SetColumnValue(Columns.RecursoHumano, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this ConConsultaDiagnostico
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.CODCIE10); }
			set { SetColumnValue("CODCIE10", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a ConConsultum ActiveRecord object related to this ConConsultaDiagnostico
		/// 
		/// </summary>
		public DalSic.ConConsultum ConConsultum
		{
			get { return DalSic.ConConsultum.FetchByID(this.IdConsulta); }
			set { SetColumnValue("idConsulta", value.IdConsulta); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfector,int? varIdConsulta,bool? varPrincipal,int? varCODCIE10,int varPrimerConsulta,int? varIdNivelDeAbordaje,int? varIdTipoPrestacionSaludMental,int? varIdTiempoInsumido,int? varIdDemanda,string varRecursoHumano)
		{
			ConConsultaDiagnostico item = new ConConsultaDiagnostico();
			
			item.IdEfector = varIdEfector;
			
			item.IdConsulta = varIdConsulta;
			
			item.Principal = varPrincipal;
			
			item.CODCIE10 = varCODCIE10;
			
			item.PrimerConsulta = varPrimerConsulta;
			
			item.IdNivelDeAbordaje = varIdNivelDeAbordaje;
			
			item.IdTipoPrestacionSaludMental = varIdTipoPrestacionSaludMental;
			
			item.IdTiempoInsumido = varIdTiempoInsumido;
			
			item.IdDemanda = varIdDemanda;
			
			item.RecursoHumano = varRecursoHumano;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdConsultaDiagnostico,int? varIdEfector,int? varIdConsulta,bool? varPrincipal,int? varCODCIE10,int varPrimerConsulta,int? varIdNivelDeAbordaje,int? varIdTipoPrestacionSaludMental,int? varIdTiempoInsumido,int? varIdDemanda,string varRecursoHumano)
		{
			ConConsultaDiagnostico item = new ConConsultaDiagnostico();
			
				item.IdConsultaDiagnostico = varIdConsultaDiagnostico;
			
				item.IdEfector = varIdEfector;
			
				item.IdConsulta = varIdConsulta;
			
				item.Principal = varPrincipal;
			
				item.CODCIE10 = varCODCIE10;
			
				item.PrimerConsulta = varPrimerConsulta;
			
				item.IdNivelDeAbordaje = varIdNivelDeAbordaje;
			
				item.IdTipoPrestacionSaludMental = varIdTipoPrestacionSaludMental;
			
				item.IdTiempoInsumido = varIdTiempoInsumido;
			
				item.IdDemanda = varIdDemanda;
			
				item.RecursoHumano = varRecursoHumano;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdConsultaDiagnosticoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PrincipalColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CODCIE10Column
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimerConsultaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNivelDeAbordajeColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPrestacionSaludMentalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTiempoInsumidoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDemandaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn RecursoHumanoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdConsultaDiagnostico = @"idConsultaDiagnostico";
			 public static string IdEfector = @"idEfector";
			 public static string IdConsulta = @"idConsulta";
			 public static string Principal = @"principal";
			 public static string CODCIE10 = @"CODCIE10";
			 public static string PrimerConsulta = @"PrimerConsulta";
			 public static string IdNivelDeAbordaje = @"idNivelDeAbordaje";
			 public static string IdTipoPrestacionSaludMental = @"idTipoPrestacionSaludMental";
			 public static string IdTiempoInsumido = @"idTiempoInsumido";
			 public static string IdDemanda = @"idDemanda";
			 public static string RecursoHumano = @"RecursoHumano";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
