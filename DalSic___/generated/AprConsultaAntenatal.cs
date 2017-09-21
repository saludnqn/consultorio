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
	/// Strongly-typed collection for the AprConsultaAntenatal class.
	/// </summary>
    [Serializable]
	public partial class AprConsultaAntenatalCollection : ActiveList<AprConsultaAntenatal, AprConsultaAntenatalCollection>
	{	   
		public AprConsultaAntenatalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprConsultaAntenatalCollection</returns>
		public AprConsultaAntenatalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprConsultaAntenatal o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ConsultaAntenatal table.
	/// </summary>
	[Serializable]
	public partial class AprConsultaAntenatal : ActiveRecord<AprConsultaAntenatal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprConsultaAntenatal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprConsultaAntenatal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprConsultaAntenatal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprConsultaAntenatal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ConsultaAntenatal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdConsultaAntenatal = new TableSchema.TableColumn(schema);
				colvarIdConsultaAntenatal.ColumnName = "idConsultaAntenatal";
				colvarIdConsultaAntenatal.DataType = DbType.Int32;
				colvarIdConsultaAntenatal.MaxLength = 0;
				colvarIdConsultaAntenatal.AutoIncrement = true;
				colvarIdConsultaAntenatal.IsNullable = false;
				colvarIdConsultaAntenatal.IsPrimaryKey = true;
				colvarIdConsultaAntenatal.IsForeignKey = false;
				colvarIdConsultaAntenatal.IsReadOnly = false;
				colvarIdConsultaAntenatal.DefaultSetting = @"";
				colvarIdConsultaAntenatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsultaAntenatal);
				
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
				
				TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
				colvarIdConsulta.ColumnName = "idConsulta";
				colvarIdConsulta.DataType = DbType.Int32;
				colvarIdConsulta.MaxLength = 0;
				colvarIdConsulta.AutoIncrement = false;
				colvarIdConsulta.IsNullable = false;
				colvarIdConsulta.IsPrimaryKey = false;
				colvarIdConsulta.IsForeignKey = false;
				colvarIdConsulta.IsReadOnly = false;
				colvarIdConsulta.DefaultSetting = @"";
				colvarIdConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsulta);
				
				TableSchema.TableColumn colvarIdEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdEmbarazo.ColumnName = "idEmbarazo";
				colvarIdEmbarazo.DataType = DbType.Int32;
				colvarIdEmbarazo.MaxLength = 0;
				colvarIdEmbarazo.AutoIncrement = false;
				colvarIdEmbarazo.IsNullable = false;
				colvarIdEmbarazo.IsPrimaryKey = false;
				colvarIdEmbarazo.IsForeignKey = true;
				colvarIdEmbarazo.IsReadOnly = false;
				colvarIdEmbarazo.DefaultSetting = @"";
				
					colvarIdEmbarazo.ForeignKeyTableName = "APR_Embarazo";
				schema.Columns.Add(colvarIdEmbarazo);
				
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
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "Peso";
				colvarPeso.DataType = DbType.Double;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarPresionArterialBaja = new TableSchema.TableColumn(schema);
				colvarPresionArterialBaja.ColumnName = "PresionArterialBaja";
				colvarPresionArterialBaja.DataType = DbType.Int32;
				colvarPresionArterialBaja.MaxLength = 0;
				colvarPresionArterialBaja.AutoIncrement = false;
				colvarPresionArterialBaja.IsNullable = true;
				colvarPresionArterialBaja.IsPrimaryKey = false;
				colvarPresionArterialBaja.IsForeignKey = false;
				colvarPresionArterialBaja.IsReadOnly = false;
				colvarPresionArterialBaja.DefaultSetting = @"";
				colvarPresionArterialBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresionArterialBaja);
				
				TableSchema.TableColumn colvarPresionArterialAlta = new TableSchema.TableColumn(schema);
				colvarPresionArterialAlta.ColumnName = "PresionArterialAlta";
				colvarPresionArterialAlta.DataType = DbType.Int32;
				colvarPresionArterialAlta.MaxLength = 0;
				colvarPresionArterialAlta.AutoIncrement = false;
				colvarPresionArterialAlta.IsNullable = true;
				colvarPresionArterialAlta.IsPrimaryKey = false;
				colvarPresionArterialAlta.IsForeignKey = false;
				colvarPresionArterialAlta.IsReadOnly = false;
				colvarPresionArterialAlta.DefaultSetting = @"";
				colvarPresionArterialAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresionArterialAlta);
				
				TableSchema.TableColumn colvarAlturaUterina = new TableSchema.TableColumn(schema);
				colvarAlturaUterina.ColumnName = "AlturaUterina";
				colvarAlturaUterina.DataType = DbType.Int32;
				colvarAlturaUterina.MaxLength = 0;
				colvarAlturaUterina.AutoIncrement = false;
				colvarAlturaUterina.IsNullable = true;
				colvarAlturaUterina.IsPrimaryKey = false;
				colvarAlturaUterina.IsForeignKey = false;
				colvarAlturaUterina.IsReadOnly = false;
				colvarAlturaUterina.DefaultSetting = @"";
				colvarAlturaUterina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlturaUterina);
				
				TableSchema.TableColumn colvarIdPresentacionSituacional = new TableSchema.TableColumn(schema);
				colvarIdPresentacionSituacional.ColumnName = "idPresentacionSituacional";
				colvarIdPresentacionSituacional.DataType = DbType.Int32;
				colvarIdPresentacionSituacional.MaxLength = 0;
				colvarIdPresentacionSituacional.AutoIncrement = false;
				colvarIdPresentacionSituacional.IsNullable = true;
				colvarIdPresentacionSituacional.IsPrimaryKey = false;
				colvarIdPresentacionSituacional.IsForeignKey = false;
				colvarIdPresentacionSituacional.IsReadOnly = false;
				colvarIdPresentacionSituacional.DefaultSetting = @"";
				colvarIdPresentacionSituacional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPresentacionSituacional);
				
				TableSchema.TableColumn colvarFrecuenciaCardiacaFetal = new TableSchema.TableColumn(schema);
				colvarFrecuenciaCardiacaFetal.ColumnName = "FrecuenciaCardiacaFetal";
				colvarFrecuenciaCardiacaFetal.DataType = DbType.Int32;
				colvarFrecuenciaCardiacaFetal.MaxLength = 0;
				colvarFrecuenciaCardiacaFetal.AutoIncrement = false;
				colvarFrecuenciaCardiacaFetal.IsNullable = true;
				colvarFrecuenciaCardiacaFetal.IsPrimaryKey = false;
				colvarFrecuenciaCardiacaFetal.IsForeignKey = false;
				colvarFrecuenciaCardiacaFetal.IsReadOnly = false;
				colvarFrecuenciaCardiacaFetal.DefaultSetting = @"";
				colvarFrecuenciaCardiacaFetal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFrecuenciaCardiacaFetal);
				
				TableSchema.TableColumn colvarMovimientosFetales = new TableSchema.TableColumn(schema);
				colvarMovimientosFetales.ColumnName = "MovimientosFetales";
				colvarMovimientosFetales.DataType = DbType.Boolean;
				colvarMovimientosFetales.MaxLength = 0;
				colvarMovimientosFetales.AutoIncrement = false;
				colvarMovimientosFetales.IsNullable = true;
				colvarMovimientosFetales.IsPrimaryKey = false;
				colvarMovimientosFetales.IsForeignKey = false;
				colvarMovimientosFetales.IsReadOnly = false;
				colvarMovimientosFetales.DefaultSetting = @"";
				colvarMovimientosFetales.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMovimientosFetales);
				
				TableSchema.TableColumn colvarProteinuria = new TableSchema.TableColumn(schema);
				colvarProteinuria.ColumnName = "Proteinuria";
				colvarProteinuria.DataType = DbType.Boolean;
				colvarProteinuria.MaxLength = 0;
				colvarProteinuria.AutoIncrement = false;
				colvarProteinuria.IsNullable = true;
				colvarProteinuria.IsPrimaryKey = false;
				colvarProteinuria.IsForeignKey = false;
				colvarProteinuria.IsReadOnly = false;
				colvarProteinuria.DefaultSetting = @"";
				colvarProteinuria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProteinuria);
				
				TableSchema.TableColumn colvarObservacionesGenerales = new TableSchema.TableColumn(schema);
				colvarObservacionesGenerales.ColumnName = "ObservacionesGenerales";
				colvarObservacionesGenerales.DataType = DbType.AnsiString;
				colvarObservacionesGenerales.MaxLength = 2147483647;
				colvarObservacionesGenerales.AutoIncrement = false;
				colvarObservacionesGenerales.IsNullable = true;
				colvarObservacionesGenerales.IsPrimaryKey = false;
				colvarObservacionesGenerales.IsForeignKey = false;
				colvarObservacionesGenerales.IsReadOnly = false;
				colvarObservacionesGenerales.DefaultSetting = @"";
				colvarObservacionesGenerales.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionesGenerales);
				
				TableSchema.TableColumn colvarInicialesTecnico = new TableSchema.TableColumn(schema);
				colvarInicialesTecnico.ColumnName = "InicialesTecnico";
				colvarInicialesTecnico.DataType = DbType.AnsiString;
				colvarInicialesTecnico.MaxLength = 50;
				colvarInicialesTecnico.AutoIncrement = false;
				colvarInicialesTecnico.IsNullable = false;
				colvarInicialesTecnico.IsPrimaryKey = false;
				colvarInicialesTecnico.IsForeignKey = false;
				colvarInicialesTecnico.IsReadOnly = false;
				colvarInicialesTecnico.DefaultSetting = @"";
				colvarInicialesTecnico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInicialesTecnico);
				
				TableSchema.TableColumn colvarFechaProximaConsulta = new TableSchema.TableColumn(schema);
				colvarFechaProximaConsulta.ColumnName = "FechaProximaConsulta";
				colvarFechaProximaConsulta.DataType = DbType.DateTime;
				colvarFechaProximaConsulta.MaxLength = 0;
				colvarFechaProximaConsulta.AutoIncrement = false;
				colvarFechaProximaConsulta.IsNullable = false;
				colvarFechaProximaConsulta.IsPrimaryKey = false;
				colvarFechaProximaConsulta.IsForeignKey = false;
				colvarFechaProximaConsulta.IsReadOnly = false;
				colvarFechaProximaConsulta.DefaultSetting = @"";
				colvarFechaProximaConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaProximaConsulta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ConsultaAntenatal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdConsultaAntenatal")]
		[Bindable(true)]
		public int IdConsultaAntenatal 
		{
			get { return GetColumnValue<int>(Columns.IdConsultaAntenatal); }
			set { SetColumnValue(Columns.IdConsultaAntenatal, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int IdConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("IdEmbarazo")]
		[Bindable(true)]
		public int IdEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdEmbarazo); }
			set { SetColumnValue(Columns.IdEmbarazo, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public double? Peso 
		{
			get { return GetColumnValue<double?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("PresionArterialBaja")]
		[Bindable(true)]
		public int? PresionArterialBaja 
		{
			get { return GetColumnValue<int?>(Columns.PresionArterialBaja); }
			set { SetColumnValue(Columns.PresionArterialBaja, value); }
		}
		  
		[XmlAttribute("PresionArterialAlta")]
		[Bindable(true)]
		public int? PresionArterialAlta 
		{
			get { return GetColumnValue<int?>(Columns.PresionArterialAlta); }
			set { SetColumnValue(Columns.PresionArterialAlta, value); }
		}
		  
		[XmlAttribute("AlturaUterina")]
		[Bindable(true)]
		public int? AlturaUterina 
		{
			get { return GetColumnValue<int?>(Columns.AlturaUterina); }
			set { SetColumnValue(Columns.AlturaUterina, value); }
		}
		  
		[XmlAttribute("IdPresentacionSituacional")]
		[Bindable(true)]
		public int? IdPresentacionSituacional 
		{
			get { return GetColumnValue<int?>(Columns.IdPresentacionSituacional); }
			set { SetColumnValue(Columns.IdPresentacionSituacional, value); }
		}
		  
		[XmlAttribute("FrecuenciaCardiacaFetal")]
		[Bindable(true)]
		public int? FrecuenciaCardiacaFetal 
		{
			get { return GetColumnValue<int?>(Columns.FrecuenciaCardiacaFetal); }
			set { SetColumnValue(Columns.FrecuenciaCardiacaFetal, value); }
		}
		  
		[XmlAttribute("MovimientosFetales")]
		[Bindable(true)]
		public bool? MovimientosFetales 
		{
			get { return GetColumnValue<bool?>(Columns.MovimientosFetales); }
			set { SetColumnValue(Columns.MovimientosFetales, value); }
		}
		  
		[XmlAttribute("Proteinuria")]
		[Bindable(true)]
		public bool? Proteinuria 
		{
			get { return GetColumnValue<bool?>(Columns.Proteinuria); }
			set { SetColumnValue(Columns.Proteinuria, value); }
		}
		  
		[XmlAttribute("ObservacionesGenerales")]
		[Bindable(true)]
		public string ObservacionesGenerales 
		{
			get { return GetColumnValue<string>(Columns.ObservacionesGenerales); }
			set { SetColumnValue(Columns.ObservacionesGenerales, value); }
		}
		  
		[XmlAttribute("InicialesTecnico")]
		[Bindable(true)]
		public string InicialesTecnico 
		{
			get { return GetColumnValue<string>(Columns.InicialesTecnico); }
			set { SetColumnValue(Columns.InicialesTecnico, value); }
		}
		  
		[XmlAttribute("FechaProximaConsulta")]
		[Bindable(true)]
		public DateTime FechaProximaConsulta 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaProximaConsulta); }
			set { SetColumnValue(Columns.FechaProximaConsulta, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprEmbarazo ActiveRecord object related to this AprConsultaAntenatal
		/// 
		/// </summary>
		public DalSic.AprEmbarazo AprEmbarazo
		{
			get { return DalSic.AprEmbarazo.FetchByID(this.IdEmbarazo); }
			set { SetColumnValue("idEmbarazo", value.IdEmbarazo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdConsulta,int varIdEmbarazo,DateTime varFecha,double? varPeso,int? varPresionArterialBaja,int? varPresionArterialAlta,int? varAlturaUterina,int? varIdPresentacionSituacional,int? varFrecuenciaCardiacaFetal,bool? varMovimientosFetales,bool? varProteinuria,string varObservacionesGenerales,string varInicialesTecnico,DateTime varFechaProximaConsulta)
		{
			AprConsultaAntenatal item = new AprConsultaAntenatal();
			
			item.IdEfector = varIdEfector;
			
			item.IdConsulta = varIdConsulta;
			
			item.IdEmbarazo = varIdEmbarazo;
			
			item.Fecha = varFecha;
			
			item.Peso = varPeso;
			
			item.PresionArterialBaja = varPresionArterialBaja;
			
			item.PresionArterialAlta = varPresionArterialAlta;
			
			item.AlturaUterina = varAlturaUterina;
			
			item.IdPresentacionSituacional = varIdPresentacionSituacional;
			
			item.FrecuenciaCardiacaFetal = varFrecuenciaCardiacaFetal;
			
			item.MovimientosFetales = varMovimientosFetales;
			
			item.Proteinuria = varProteinuria;
			
			item.ObservacionesGenerales = varObservacionesGenerales;
			
			item.InicialesTecnico = varInicialesTecnico;
			
			item.FechaProximaConsulta = varFechaProximaConsulta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdConsultaAntenatal,int varIdEfector,int varIdConsulta,int varIdEmbarazo,DateTime varFecha,double? varPeso,int? varPresionArterialBaja,int? varPresionArterialAlta,int? varAlturaUterina,int? varIdPresentacionSituacional,int? varFrecuenciaCardiacaFetal,bool? varMovimientosFetales,bool? varProteinuria,string varObservacionesGenerales,string varInicialesTecnico,DateTime varFechaProximaConsulta)
		{
			AprConsultaAntenatal item = new AprConsultaAntenatal();
			
				item.IdConsultaAntenatal = varIdConsultaAntenatal;
			
				item.IdEfector = varIdEfector;
			
				item.IdConsulta = varIdConsulta;
			
				item.IdEmbarazo = varIdEmbarazo;
			
				item.Fecha = varFecha;
			
				item.Peso = varPeso;
			
				item.PresionArterialBaja = varPresionArterialBaja;
			
				item.PresionArterialAlta = varPresionArterialAlta;
			
				item.AlturaUterina = varAlturaUterina;
			
				item.IdPresentacionSituacional = varIdPresentacionSituacional;
			
				item.FrecuenciaCardiacaFetal = varFrecuenciaCardiacaFetal;
			
				item.MovimientosFetales = varMovimientosFetales;
			
				item.Proteinuria = varProteinuria;
			
				item.ObservacionesGenerales = varObservacionesGenerales;
			
				item.InicialesTecnico = varInicialesTecnico;
			
				item.FechaProximaConsulta = varFechaProximaConsulta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdConsultaAntenatalColumn
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
        
        
        
        public static TableSchema.TableColumn IdEmbarazoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PresionArterialBajaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PresionArterialAltaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn AlturaUterinaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPresentacionSituacionalColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FrecuenciaCardiacaFetalColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn MovimientosFetalesColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ProteinuriaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesGeneralesColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn InicialesTecnicoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaProximaConsultaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdConsultaAntenatal = @"idConsultaAntenatal";
			 public static string IdEfector = @"idEfector";
			 public static string IdConsulta = @"idConsulta";
			 public static string IdEmbarazo = @"idEmbarazo";
			 public static string Fecha = @"Fecha";
			 public static string Peso = @"Peso";
			 public static string PresionArterialBaja = @"PresionArterialBaja";
			 public static string PresionArterialAlta = @"PresionArterialAlta";
			 public static string AlturaUterina = @"AlturaUterina";
			 public static string IdPresentacionSituacional = @"idPresentacionSituacional";
			 public static string FrecuenciaCardiacaFetal = @"FrecuenciaCardiacaFetal";
			 public static string MovimientosFetales = @"MovimientosFetales";
			 public static string Proteinuria = @"Proteinuria";
			 public static string ObservacionesGenerales = @"ObservacionesGenerales";
			 public static string InicialesTecnico = @"InicialesTecnico";
			 public static string FechaProximaConsulta = @"FechaProximaConsulta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
