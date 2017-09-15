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
	/// Strongly-typed collection for the PnPrestacion class.
	/// </summary>
    [Serializable]
	public partial class PnPrestacionCollection : ActiveList<PnPrestacion, PnPrestacionCollection>
	{	   
		public PnPrestacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPrestacionCollection</returns>
		public PnPrestacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPrestacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_prestacion table.
	/// </summary>
	[Serializable]
	public partial class PnPrestacion : ActiveRecord<PnPrestacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPrestacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPrestacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPrestacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPrestacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_prestacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPrestacion = new TableSchema.TableColumn(schema);
				colvarIdPrestacion.ColumnName = "id_prestacion";
				colvarIdPrestacion.DataType = DbType.Int32;
				colvarIdPrestacion.MaxLength = 0;
				colvarIdPrestacion.AutoIncrement = true;
				colvarIdPrestacion.IsNullable = false;
				colvarIdPrestacion.IsPrimaryKey = true;
				colvarIdPrestacion.IsForeignKey = false;
				colvarIdPrestacion.IsReadOnly = false;
				colvarIdPrestacion.DefaultSetting = @"";
				colvarIdPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrestacion);
				
				TableSchema.TableColumn colvarIdComprobante = new TableSchema.TableColumn(schema);
				colvarIdComprobante.ColumnName = "id_comprobante";
				colvarIdComprobante.DataType = DbType.Int32;
				colvarIdComprobante.MaxLength = 0;
				colvarIdComprobante.AutoIncrement = false;
				colvarIdComprobante.IsNullable = false;
				colvarIdComprobante.IsPrimaryKey = false;
				colvarIdComprobante.IsForeignKey = true;
				colvarIdComprobante.IsReadOnly = false;
				colvarIdComprobante.DefaultSetting = @"";
				
					colvarIdComprobante.ForeignKeyTableName = "PN_comprobante";
				schema.Columns.Add(colvarIdComprobante);
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "id_nomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = false;
				colvarIdNomenclador.IsNullable = false;
				colvarIdNomenclador.IsPrimaryKey = false;
				colvarIdNomenclador.IsForeignKey = true;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				
					colvarIdNomenclador.ForeignKeyTableName = "PN_nomenclador";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
				colvarCantidad.ColumnName = "cantidad";
				colvarCantidad.DataType = DbType.Int32;
				colvarCantidad.MaxLength = 0;
				colvarCantidad.AutoIncrement = false;
				colvarCantidad.IsNullable = true;
				colvarCantidad.IsPrimaryKey = false;
				colvarCantidad.IsForeignKey = false;
				colvarCantidad.IsReadOnly = false;
				colvarCantidad.DefaultSetting = @"";
				colvarCantidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidad);
				
				TableSchema.TableColumn colvarPrecioPrestacion = new TableSchema.TableColumn(schema);
				colvarPrecioPrestacion.ColumnName = "precio_prestacion";
				colvarPrecioPrestacion.DataType = DbType.Decimal;
				colvarPrecioPrestacion.MaxLength = 0;
				colvarPrecioPrestacion.AutoIncrement = false;
				colvarPrecioPrestacion.IsNullable = true;
				colvarPrecioPrestacion.IsPrimaryKey = false;
				colvarPrecioPrestacion.IsForeignKey = false;
				colvarPrecioPrestacion.IsReadOnly = false;
				colvarPrecioPrestacion.DefaultSetting = @"";
				colvarPrecioPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrecioPrestacion);
				
				TableSchema.TableColumn colvarIdAnexo = new TableSchema.TableColumn(schema);
				colvarIdAnexo.ColumnName = "id_anexo";
				colvarIdAnexo.DataType = DbType.Int32;
				colvarIdAnexo.MaxLength = 0;
				colvarIdAnexo.AutoIncrement = false;
				colvarIdAnexo.IsNullable = true;
				colvarIdAnexo.IsPrimaryKey = false;
				colvarIdAnexo.IsForeignKey = false;
				colvarIdAnexo.IsReadOnly = false;
				colvarIdAnexo.DefaultSetting = @"";
				colvarIdAnexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAnexo);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTensionArterial = new TableSchema.TableColumn(schema);
				colvarTensionArterial.ColumnName = "tension_arterial";
				colvarTensionArterial.DataType = DbType.AnsiString;
				colvarTensionArterial.MaxLength = -1;
				colvarTensionArterial.AutoIncrement = false;
				colvarTensionArterial.IsNullable = true;
				colvarTensionArterial.IsPrimaryKey = false;
				colvarTensionArterial.IsForeignKey = false;
				colvarTensionArterial.IsReadOnly = false;
				colvarTensionArterial.DefaultSetting = @"";
				colvarTensionArterial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTensionArterial);
				
				TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
				colvarDiagnostico.ColumnName = "diagnostico";
				colvarDiagnostico.DataType = DbType.AnsiString;
				colvarDiagnostico.MaxLength = -1;
				colvarDiagnostico.AutoIncrement = false;
				colvarDiagnostico.IsNullable = true;
				colvarDiagnostico.IsPrimaryKey = false;
				colvarDiagnostico.IsForeignKey = false;
				colvarDiagnostico.IsReadOnly = false;
				colvarDiagnostico.DefaultSetting = @"";
				colvarDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnostico);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.AnsiString;
				colvarEdad.MaxLength = 2;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = true;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				colvarEdad.DefaultSetting = @"";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.AnsiString;
				colvarSexo.MaxLength = 2;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = true;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarCodigoComp = new TableSchema.TableColumn(schema);
				colvarCodigoComp.ColumnName = "codigo_comp";
				colvarCodigoComp.DataType = DbType.AnsiString;
				colvarCodigoComp.MaxLength = -1;
				colvarCodigoComp.AutoIncrement = false;
				colvarCodigoComp.IsNullable = true;
				colvarCodigoComp.IsPrimaryKey = false;
				colvarCodigoComp.IsForeignKey = false;
				colvarCodigoComp.IsReadOnly = false;
				colvarCodigoComp.DefaultSetting = @"";
				colvarCodigoComp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoComp);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fecha_nacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarFechaPrestacion = new TableSchema.TableColumn(schema);
				colvarFechaPrestacion.ColumnName = "fecha_prestacion";
				colvarFechaPrestacion.DataType = DbType.DateTime;
				colvarFechaPrestacion.MaxLength = 0;
				colvarFechaPrestacion.AutoIncrement = false;
				colvarFechaPrestacion.IsNullable = true;
				colvarFechaPrestacion.IsPrimaryKey = false;
				colvarFechaPrestacion.IsForeignKey = false;
				colvarFechaPrestacion.IsReadOnly = false;
				colvarFechaPrestacion.DefaultSetting = @"";
				colvarFechaPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPrestacion);
				
				TableSchema.TableColumn colvarAnio = new TableSchema.TableColumn(schema);
				colvarAnio.ColumnName = "anio";
				colvarAnio.DataType = DbType.Int32;
				colvarAnio.MaxLength = 0;
				colvarAnio.AutoIncrement = false;
				colvarAnio.IsNullable = true;
				colvarAnio.IsPrimaryKey = false;
				colvarAnio.IsForeignKey = false;
				colvarAnio.IsReadOnly = false;
				colvarAnio.DefaultSetting = @"";
				colvarAnio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnio);
				
				TableSchema.TableColumn colvarMes = new TableSchema.TableColumn(schema);
				colvarMes.ColumnName = "mes";
				colvarMes.DataType = DbType.Int32;
				colvarMes.MaxLength = 0;
				colvarMes.AutoIncrement = false;
				colvarMes.IsNullable = true;
				colvarMes.IsPrimaryKey = false;
				colvarMes.IsForeignKey = false;
				colvarMes.IsReadOnly = false;
				colvarMes.DefaultSetting = @"";
				colvarMes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMes);
				
				TableSchema.TableColumn colvarDia = new TableSchema.TableColumn(schema);
				colvarDia.ColumnName = "dia";
				colvarDia.DataType = DbType.Int32;
				colvarDia.MaxLength = 0;
				colvarDia.AutoIncrement = false;
				colvarDia.IsNullable = true;
				colvarDia.IsPrimaryKey = false;
				colvarDia.IsForeignKey = false;
				colvarDia.IsReadOnly = false;
				colvarDia.DefaultSetting = @"";
				colvarDia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDia);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "talla";
				colvarTalla.DataType = DbType.Int32;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = true;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarPerimetroCefalico = new TableSchema.TableColumn(schema);
				colvarPerimetroCefalico.ColumnName = "perimetro_cefalico";
				colvarPerimetroCefalico.DataType = DbType.String;
				colvarPerimetroCefalico.MaxLength = -1;
				colvarPerimetroCefalico.AutoIncrement = false;
				colvarPerimetroCefalico.IsNullable = true;
				colvarPerimetroCefalico.IsPrimaryKey = false;
				colvarPerimetroCefalico.IsForeignKey = false;
				colvarPerimetroCefalico.IsReadOnly = false;
				colvarPerimetroCefalico.DefaultSetting = @"";
				colvarPerimetroCefalico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerimetroCefalico);
				
				TableSchema.TableColumn colvarSemanasGestacion = new TableSchema.TableColumn(schema);
				colvarSemanasGestacion.ColumnName = "semanas_gestacion";
				colvarSemanasGestacion.DataType = DbType.Int32;
				colvarSemanasGestacion.MaxLength = 0;
				colvarSemanasGestacion.AutoIncrement = false;
				colvarSemanasGestacion.IsNullable = true;
				colvarSemanasGestacion.IsPrimaryKey = false;
				colvarSemanasGestacion.IsForeignKey = false;
				colvarSemanasGestacion.IsReadOnly = false;
				colvarSemanasGestacion.DefaultSetting = @"";
				colvarSemanasGestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSemanasGestacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_prestacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPrestacion")]
		[Bindable(true)]
		public int IdPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdPrestacion); }
			set { SetColumnValue(Columns.IdPrestacion, value); }
		}
		  
		[XmlAttribute("IdComprobante")]
		[Bindable(true)]
		public int IdComprobante 
		{
			get { return GetColumnValue<int>(Columns.IdComprobante); }
			set { SetColumnValue(Columns.IdComprobante, value); }
		}
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int IdNomenclador 
		{
			get { return GetColumnValue<int>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("Cantidad")]
		[Bindable(true)]
		public int? Cantidad 
		{
			get { return GetColumnValue<int?>(Columns.Cantidad); }
			set { SetColumnValue(Columns.Cantidad, value); }
		}
		  
		[XmlAttribute("PrecioPrestacion")]
		[Bindable(true)]
		public decimal? PrecioPrestacion 
		{
			get { return GetColumnValue<decimal?>(Columns.PrecioPrestacion); }
			set { SetColumnValue(Columns.PrecioPrestacion, value); }
		}
		  
		[XmlAttribute("IdAnexo")]
		[Bindable(true)]
		public int? IdAnexo 
		{
			get { return GetColumnValue<int?>(Columns.IdAnexo); }
			set { SetColumnValue(Columns.IdAnexo, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal? Peso 
		{
			get { return GetColumnValue<decimal?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("TensionArterial")]
		[Bindable(true)]
		public string TensionArterial 
		{
			get { return GetColumnValue<string>(Columns.TensionArterial); }
			set { SetColumnValue(Columns.TensionArterial, value); }
		}
		  
		[XmlAttribute("Diagnostico")]
		[Bindable(true)]
		public string Diagnostico 
		{
			get { return GetColumnValue<string>(Columns.Diagnostico); }
			set { SetColumnValue(Columns.Diagnostico, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public string Edad 
		{
			get { return GetColumnValue<string>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("CodigoComp")]
		[Bindable(true)]
		public string CodigoComp 
		{
			get { return GetColumnValue<string>(Columns.CodigoComp); }
			set { SetColumnValue(Columns.CodigoComp, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("FechaPrestacion")]
		[Bindable(true)]
		public DateTime? FechaPrestacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaPrestacion); }
			set { SetColumnValue(Columns.FechaPrestacion, value); }
		}
		  
		[XmlAttribute("Anio")]
		[Bindable(true)]
		public int? Anio 
		{
			get { return GetColumnValue<int?>(Columns.Anio); }
			set { SetColumnValue(Columns.Anio, value); }
		}
		  
		[XmlAttribute("Mes")]
		[Bindable(true)]
		public int? Mes 
		{
			get { return GetColumnValue<int?>(Columns.Mes); }
			set { SetColumnValue(Columns.Mes, value); }
		}
		  
		[XmlAttribute("Dia")]
		[Bindable(true)]
		public int? Dia 
		{
			get { return GetColumnValue<int?>(Columns.Dia); }
			set { SetColumnValue(Columns.Dia, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public int? Talla 
		{
			get { return GetColumnValue<int?>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("PerimetroCefalico")]
		[Bindable(true)]
		public string PerimetroCefalico 
		{
			get { return GetColumnValue<string>(Columns.PerimetroCefalico); }
			set { SetColumnValue(Columns.PerimetroCefalico, value); }
		}
		  
		[XmlAttribute("SemanasGestacion")]
		[Bindable(true)]
		public int? SemanasGestacion 
		{
			get { return GetColumnValue<int?>(Columns.SemanasGestacion); }
			set { SetColumnValue(Columns.SemanasGestacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnRelPrestacionXDatoReportableCollection colPnRelPrestacionXDatoReportableRecords;
		public DalSic.PnRelPrestacionXDatoReportableCollection PnRelPrestacionXDatoReportableRecords
		{
			get
			{
				if(colPnRelPrestacionXDatoReportableRecords == null)
				{
					colPnRelPrestacionXDatoReportableRecords = new DalSic.PnRelPrestacionXDatoReportableCollection().Where(PnRelPrestacionXDatoReportable.Columns.IdPrestacion, IdPrestacion).Load();
					colPnRelPrestacionXDatoReportableRecords.ListChanged += new ListChangedEventHandler(colPnRelPrestacionXDatoReportableRecords_ListChanged);
				}
				return colPnRelPrestacionXDatoReportableRecords;			
			}
			set 
			{ 
					colPnRelPrestacionXDatoReportableRecords = value; 
					colPnRelPrestacionXDatoReportableRecords.ListChanged += new ListChangedEventHandler(colPnRelPrestacionXDatoReportableRecords_ListChanged);
			}
		}
		
		void colPnRelPrestacionXDatoReportableRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnRelPrestacionXDatoReportableRecords[e.NewIndex].IdPrestacion = IdPrestacion;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnNomenclador ActiveRecord object related to this PnPrestacion
		/// 
		/// </summary>
		public DalSic.PnNomenclador PnNomenclador
		{
			get { return DalSic.PnNomenclador.FetchByID(this.IdNomenclador); }
			set { SetColumnValue("id_nomenclador", value.IdNomenclador); }
		}
		
		
		/// <summary>
		/// Returns a PnComprobante ActiveRecord object related to this PnPrestacion
		/// 
		/// </summary>
		public DalSic.PnComprobante PnComprobante
		{
			get { return DalSic.PnComprobante.FetchByID(this.IdComprobante); }
			set { SetColumnValue("id_comprobante", value.IdComprobante); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdComprobante,int varIdNomenclador,int? varCantidad,decimal? varPrecioPrestacion,int? varIdAnexo,decimal? varPeso,string varTensionArterial,string varDiagnostico,string varEdad,string varSexo,string varCodigoComp,DateTime? varFechaNacimiento,DateTime? varFechaPrestacion,int? varAnio,int? varMes,int? varDia,int? varTalla,string varPerimetroCefalico,int? varSemanasGestacion)
		{
			PnPrestacion item = new PnPrestacion();
			
			item.IdComprobante = varIdComprobante;
			
			item.IdNomenclador = varIdNomenclador;
			
			item.Cantidad = varCantidad;
			
			item.PrecioPrestacion = varPrecioPrestacion;
			
			item.IdAnexo = varIdAnexo;
			
			item.Peso = varPeso;
			
			item.TensionArterial = varTensionArterial;
			
			item.Diagnostico = varDiagnostico;
			
			item.Edad = varEdad;
			
			item.Sexo = varSexo;
			
			item.CodigoComp = varCodigoComp;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.FechaPrestacion = varFechaPrestacion;
			
			item.Anio = varAnio;
			
			item.Mes = varMes;
			
			item.Dia = varDia;
			
			item.Talla = varTalla;
			
			item.PerimetroCefalico = varPerimetroCefalico;
			
			item.SemanasGestacion = varSemanasGestacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPrestacion,int varIdComprobante,int varIdNomenclador,int? varCantidad,decimal? varPrecioPrestacion,int? varIdAnexo,decimal? varPeso,string varTensionArterial,string varDiagnostico,string varEdad,string varSexo,string varCodigoComp,DateTime? varFechaNacimiento,DateTime? varFechaPrestacion,int? varAnio,int? varMes,int? varDia,int? varTalla,string varPerimetroCefalico,int? varSemanasGestacion)
		{
			PnPrestacion item = new PnPrestacion();
			
				item.IdPrestacion = varIdPrestacion;
			
				item.IdComprobante = varIdComprobante;
			
				item.IdNomenclador = varIdNomenclador;
			
				item.Cantidad = varCantidad;
			
				item.PrecioPrestacion = varPrecioPrestacion;
			
				item.IdAnexo = varIdAnexo;
			
				item.Peso = varPeso;
			
				item.TensionArterial = varTensionArterial;
			
				item.Diagnostico = varDiagnostico;
			
				item.Edad = varEdad;
			
				item.Sexo = varSexo;
			
				item.CodigoComp = varCodigoComp;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.FechaPrestacion = varFechaPrestacion;
			
				item.Anio = varAnio;
			
				item.Mes = varMes;
			
				item.Dia = varDia;
			
				item.Talla = varTalla;
			
				item.PerimetroCefalico = varPerimetroCefalico;
			
				item.SemanasGestacion = varSemanasGestacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPrestacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdComprobanteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrecioPrestacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAnexoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TensionArterialColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoCompColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPrestacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MesColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn DiaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn PerimetroCefalicoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn SemanasGestacionColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPrestacion = @"id_prestacion";
			 public static string IdComprobante = @"id_comprobante";
			 public static string IdNomenclador = @"id_nomenclador";
			 public static string Cantidad = @"cantidad";
			 public static string PrecioPrestacion = @"precio_prestacion";
			 public static string IdAnexo = @"id_anexo";
			 public static string Peso = @"peso";
			 public static string TensionArterial = @"tension_arterial";
			 public static string Diagnostico = @"diagnostico";
			 public static string Edad = @"edad";
			 public static string Sexo = @"sexo";
			 public static string CodigoComp = @"codigo_comp";
			 public static string FechaNacimiento = @"fecha_nacimiento";
			 public static string FechaPrestacion = @"fecha_prestacion";
			 public static string Anio = @"anio";
			 public static string Mes = @"mes";
			 public static string Dia = @"dia";
			 public static string Talla = @"talla";
			 public static string PerimetroCefalico = @"perimetro_cefalico";
			 public static string SemanasGestacion = @"semanas_gestacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnRelPrestacionXDatoReportableRecords != null)
                {
                    foreach (DalSic.PnRelPrestacionXDatoReportable item in colPnRelPrestacionXDatoReportableRecords)
                    {
                        if (item.IdPrestacion != IdPrestacion)
                        {
                            item.IdPrestacion = IdPrestacion;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnRelPrestacionXDatoReportableRecords != null)
                {
                    colPnRelPrestacionXDatoReportableRecords.SaveAll();
               }
		}
        #endregion
	}
}
