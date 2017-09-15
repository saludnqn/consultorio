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
	/// Strongly-typed collection for the PnFactura class.
	/// </summary>
    [Serializable]
	public partial class PnFacturaCollection : ActiveList<PnFactura, PnFacturaCollection>
	{	   
		public PnFacturaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnFacturaCollection</returns>
		public PnFacturaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnFactura o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_factura table.
	/// </summary>
	[Serializable]
	public partial class PnFactura : ActiveRecord<PnFactura>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnFactura()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnFactura(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnFactura(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnFactura(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_factura", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdFactura = new TableSchema.TableColumn(schema);
				colvarIdFactura.ColumnName = "id_factura";
				colvarIdFactura.DataType = DbType.Int32;
				colvarIdFactura.MaxLength = 0;
				colvarIdFactura.AutoIncrement = true;
				colvarIdFactura.IsNullable = false;
				colvarIdFactura.IsPrimaryKey = true;
				colvarIdFactura.IsForeignKey = false;
				colvarIdFactura.IsReadOnly = false;
				colvarIdFactura.DefaultSetting = @"";
				colvarIdFactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFactura);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = true;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarPeriodo = new TableSchema.TableColumn(schema);
				colvarPeriodo.ColumnName = "periodo";
				colvarPeriodo.DataType = DbType.AnsiString;
				colvarPeriodo.MaxLength = -1;
				colvarPeriodo.AutoIncrement = false;
				colvarPeriodo.IsNullable = true;
				colvarPeriodo.IsPrimaryKey = false;
				colvarPeriodo.IsForeignKey = false;
				colvarPeriodo.IsReadOnly = false;
				colvarPeriodo.DefaultSetting = @"";
				colvarPeriodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodo);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.AnsiString;
				colvarEstado.MaxLength = 10;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
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
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "fecha_carga";
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
				
				TableSchema.TableColumn colvarFechaFactura = new TableSchema.TableColumn(schema);
				colvarFechaFactura.ColumnName = "fecha_factura";
				colvarFechaFactura.DataType = DbType.DateTime;
				colvarFechaFactura.MaxLength = 0;
				colvarFechaFactura.AutoIncrement = false;
				colvarFechaFactura.IsNullable = true;
				colvarFechaFactura.IsPrimaryKey = false;
				colvarFechaFactura.IsForeignKey = false;
				colvarFechaFactura.IsReadOnly = false;
				colvarFechaFactura.DefaultSetting = @"";
				colvarFechaFactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFactura);
				
				TableSchema.TableColumn colvarMesFactDC = new TableSchema.TableColumn(schema);
				colvarMesFactDC.ColumnName = "mes_fact_d_c";
				colvarMesFactDC.DataType = DbType.AnsiString;
				colvarMesFactDC.MaxLength = -1;
				colvarMesFactDC.AutoIncrement = false;
				colvarMesFactDC.IsNullable = true;
				colvarMesFactDC.IsPrimaryKey = false;
				colvarMesFactDC.IsForeignKey = false;
				colvarMesFactDC.IsReadOnly = false;
				colvarMesFactDC.DefaultSetting = @"";
				colvarMesFactDC.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMesFactDC);
				
				TableSchema.TableColumn colvarMontoPrefactura = new TableSchema.TableColumn(schema);
				colvarMontoPrefactura.ColumnName = "monto_prefactura";
				colvarMontoPrefactura.DataType = DbType.Decimal;
				colvarMontoPrefactura.MaxLength = 0;
				colvarMontoPrefactura.AutoIncrement = false;
				colvarMontoPrefactura.IsNullable = true;
				colvarMontoPrefactura.IsPrimaryKey = false;
				colvarMontoPrefactura.IsForeignKey = false;
				colvarMontoPrefactura.IsReadOnly = false;
				colvarMontoPrefactura.DefaultSetting = @"";
				colvarMontoPrefactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMontoPrefactura);
				
				TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
				colvarFechaControl.ColumnName = "fecha_control";
				colvarFechaControl.DataType = DbType.DateTime;
				colvarFechaControl.MaxLength = 0;
				colvarFechaControl.AutoIncrement = false;
				colvarFechaControl.IsNullable = true;
				colvarFechaControl.IsPrimaryKey = false;
				colvarFechaControl.IsForeignKey = false;
				colvarFechaControl.IsReadOnly = false;
				colvarFechaControl.DefaultSetting = @"";
				colvarFechaControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaControl);
				
				TableSchema.TableColumn colvarNroExp = new TableSchema.TableColumn(schema);
				colvarNroExp.ColumnName = "nro_exp";
				colvarNroExp.DataType = DbType.AnsiString;
				colvarNroExp.MaxLength = -1;
				colvarNroExp.AutoIncrement = false;
				colvarNroExp.IsNullable = true;
				colvarNroExp.IsPrimaryKey = false;
				colvarNroExp.IsForeignKey = false;
				colvarNroExp.IsReadOnly = false;
				colvarNroExp.DefaultSetting = @"";
				colvarNroExp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroExp);
				
				TableSchema.TableColumn colvarTraba = new TableSchema.TableColumn(schema);
				colvarTraba.ColumnName = "traba";
				colvarTraba.DataType = DbType.AnsiString;
				colvarTraba.MaxLength = -1;
				colvarTraba.AutoIncrement = false;
				colvarTraba.IsNullable = true;
				colvarTraba.IsPrimaryKey = false;
				colvarTraba.IsForeignKey = false;
				colvarTraba.IsReadOnly = false;
				colvarTraba.DefaultSetting = @"";
				colvarTraba.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTraba);
				
				TableSchema.TableColumn colvarOnline = new TableSchema.TableColumn(schema);
				colvarOnline.ColumnName = "online";
				colvarOnline.DataType = DbType.AnsiStringFixedLength;
				colvarOnline.MaxLength = 2;
				colvarOnline.AutoIncrement = false;
				colvarOnline.IsNullable = true;
				colvarOnline.IsPrimaryKey = false;
				colvarOnline.IsForeignKey = false;
				colvarOnline.IsReadOnly = false;
				colvarOnline.DefaultSetting = @"";
				colvarOnline.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOnline);
				
				TableSchema.TableColumn colvarNroExpExt = new TableSchema.TableColumn(schema);
				colvarNroExpExt.ColumnName = "nro_exp_ext";
				colvarNroExpExt.DataType = DbType.AnsiString;
				colvarNroExpExt.MaxLength = -1;
				colvarNroExpExt.AutoIncrement = false;
				colvarNroExpExt.IsNullable = true;
				colvarNroExpExt.IsPrimaryKey = false;
				colvarNroExpExt.IsForeignKey = false;
				colvarNroExpExt.IsReadOnly = false;
				colvarNroExpExt.DefaultSetting = @"";
				colvarNroExpExt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroExpExt);
				
				TableSchema.TableColumn colvarFechaExpExt = new TableSchema.TableColumn(schema);
				colvarFechaExpExt.ColumnName = "fecha_exp_ext";
				colvarFechaExpExt.DataType = DbType.DateTime;
				colvarFechaExpExt.MaxLength = 0;
				colvarFechaExpExt.AutoIncrement = false;
				colvarFechaExpExt.IsNullable = true;
				colvarFechaExpExt.IsPrimaryKey = false;
				colvarFechaExpExt.IsForeignKey = false;
				colvarFechaExpExt.IsReadOnly = false;
				colvarFechaExpExt.DefaultSetting = @"";
				colvarFechaExpExt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaExpExt);
				
				TableSchema.TableColumn colvarPeriodoContable = new TableSchema.TableColumn(schema);
				colvarPeriodoContable.ColumnName = "periodo_contable";
				colvarPeriodoContable.DataType = DbType.AnsiString;
				colvarPeriodoContable.MaxLength = -1;
				colvarPeriodoContable.AutoIncrement = false;
				colvarPeriodoContable.IsNullable = true;
				colvarPeriodoContable.IsPrimaryKey = false;
				colvarPeriodoContable.IsForeignKey = false;
				colvarPeriodoContable.IsReadOnly = false;
				colvarPeriodoContable.DefaultSetting = @"";
				colvarPeriodoContable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodoContable);
				
				TableSchema.TableColumn colvarPeriodoActual = new TableSchema.TableColumn(schema);
				colvarPeriodoActual.ColumnName = "periodo_actual";
				colvarPeriodoActual.DataType = DbType.AnsiString;
				colvarPeriodoActual.MaxLength = -1;
				colvarPeriodoActual.AutoIncrement = false;
				colvarPeriodoActual.IsNullable = true;
				colvarPeriodoActual.IsPrimaryKey = false;
				colvarPeriodoActual.IsForeignKey = false;
				colvarPeriodoActual.IsReadOnly = false;
				colvarPeriodoActual.DefaultSetting = @"";
				colvarPeriodoActual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodoActual);
				
				TableSchema.TableColumn colvarEstadoExp = new TableSchema.TableColumn(schema);
				colvarEstadoExp.ColumnName = "estado_exp";
				colvarEstadoExp.DataType = DbType.Int32;
				colvarEstadoExp.MaxLength = 0;
				colvarEstadoExp.AutoIncrement = false;
				colvarEstadoExp.IsNullable = false;
				colvarEstadoExp.IsPrimaryKey = false;
				colvarEstadoExp.IsForeignKey = false;
				colvarEstadoExp.IsReadOnly = false;
				
						colvarEstadoExp.DefaultSetting = @"((0))";
				colvarEstadoExp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoExp);
				
				TableSchema.TableColumn colvarAltaComp = new TableSchema.TableColumn(schema);
				colvarAltaComp.ColumnName = "alta_comp";
				colvarAltaComp.DataType = DbType.AnsiString;
				colvarAltaComp.MaxLength = 2;
				colvarAltaComp.AutoIncrement = false;
				colvarAltaComp.IsNullable = true;
				colvarAltaComp.IsPrimaryKey = false;
				colvarAltaComp.IsForeignKey = false;
				colvarAltaComp.IsReadOnly = false;
				colvarAltaComp.DefaultSetting = @"";
				colvarAltaComp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAltaComp);
				
				TableSchema.TableColumn colvarIdTipoDePrestacion = new TableSchema.TableColumn(schema);
				colvarIdTipoDePrestacion.ColumnName = "idTipoDePrestacion";
				colvarIdTipoDePrestacion.DataType = DbType.Int32;
				colvarIdTipoDePrestacion.MaxLength = 0;
				colvarIdTipoDePrestacion.AutoIncrement = false;
				colvarIdTipoDePrestacion.IsNullable = true;
				colvarIdTipoDePrestacion.IsPrimaryKey = false;
				colvarIdTipoDePrestacion.IsForeignKey = true;
				colvarIdTipoDePrestacion.IsReadOnly = false;
				colvarIdTipoDePrestacion.DefaultSetting = @"";
				
					colvarIdTipoDePrestacion.ForeignKeyTableName = "PN_TipoDePrestacion";
				schema.Columns.Add(colvarIdTipoDePrestacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_factura",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdFactura")]
		[Bindable(true)]
		public int IdFactura 
		{
			get { return GetColumnValue<int>(Columns.IdFactura); }
			set { SetColumnValue(Columns.IdFactura, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Periodo")]
		[Bindable(true)]
		public string Periodo 
		{
			get { return GetColumnValue<string>(Columns.Periodo); }
			set { SetColumnValue(Columns.Periodo, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public string Estado 
		{
			get { return GetColumnValue<string>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("FechaFactura")]
		[Bindable(true)]
		public DateTime? FechaFactura 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaFactura); }
			set { SetColumnValue(Columns.FechaFactura, value); }
		}
		  
		[XmlAttribute("MesFactDC")]
		[Bindable(true)]
		public string MesFactDC 
		{
			get { return GetColumnValue<string>(Columns.MesFactDC); }
			set { SetColumnValue(Columns.MesFactDC, value); }
		}
		  
		[XmlAttribute("MontoPrefactura")]
		[Bindable(true)]
		public decimal? MontoPrefactura 
		{
			get { return GetColumnValue<decimal?>(Columns.MontoPrefactura); }
			set { SetColumnValue(Columns.MontoPrefactura, value); }
		}
		  
		[XmlAttribute("FechaControl")]
		[Bindable(true)]
		public DateTime? FechaControl 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaControl); }
			set { SetColumnValue(Columns.FechaControl, value); }
		}
		  
		[XmlAttribute("NroExp")]
		[Bindable(true)]
		public string NroExp 
		{
			get { return GetColumnValue<string>(Columns.NroExp); }
			set { SetColumnValue(Columns.NroExp, value); }
		}
		  
		[XmlAttribute("Traba")]
		[Bindable(true)]
		public string Traba 
		{
			get { return GetColumnValue<string>(Columns.Traba); }
			set { SetColumnValue(Columns.Traba, value); }
		}
		  
		[XmlAttribute("Online")]
		[Bindable(true)]
		public string Online 
		{
			get { return GetColumnValue<string>(Columns.Online); }
			set { SetColumnValue(Columns.Online, value); }
		}
		  
		[XmlAttribute("NroExpExt")]
		[Bindable(true)]
		public string NroExpExt 
		{
			get { return GetColumnValue<string>(Columns.NroExpExt); }
			set { SetColumnValue(Columns.NroExpExt, value); }
		}
		  
		[XmlAttribute("FechaExpExt")]
		[Bindable(true)]
		public DateTime? FechaExpExt 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaExpExt); }
			set { SetColumnValue(Columns.FechaExpExt, value); }
		}
		  
		[XmlAttribute("PeriodoContable")]
		[Bindable(true)]
		public string PeriodoContable 
		{
			get { return GetColumnValue<string>(Columns.PeriodoContable); }
			set { SetColumnValue(Columns.PeriodoContable, value); }
		}
		  
		[XmlAttribute("PeriodoActual")]
		[Bindable(true)]
		public string PeriodoActual 
		{
			get { return GetColumnValue<string>(Columns.PeriodoActual); }
			set { SetColumnValue(Columns.PeriodoActual, value); }
		}
		  
		[XmlAttribute("EstadoExp")]
		[Bindable(true)]
		public int EstadoExp 
		{
			get { return GetColumnValue<int>(Columns.EstadoExp); }
			set { SetColumnValue(Columns.EstadoExp, value); }
		}
		  
		[XmlAttribute("AltaComp")]
		[Bindable(true)]
		public string AltaComp 
		{
			get { return GetColumnValue<string>(Columns.AltaComp); }
			set { SetColumnValue(Columns.AltaComp, value); }
		}
		  
		[XmlAttribute("IdTipoDePrestacion")]
		[Bindable(true)]
		public int? IdTipoDePrestacion 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoDePrestacion); }
			set { SetColumnValue(Columns.IdTipoDePrestacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnComprobanteCollection colPnComprobanteRecords;
		public DalSic.PnComprobanteCollection PnComprobanteRecords
		{
			get
			{
				if(colPnComprobanteRecords == null)
				{
					colPnComprobanteRecords = new DalSic.PnComprobanteCollection().Where(PnComprobante.Columns.IdFactura, IdFactura).Load();
					colPnComprobanteRecords.ListChanged += new ListChangedEventHandler(colPnComprobanteRecords_ListChanged);
				}
				return colPnComprobanteRecords;			
			}
			set 
			{ 
					colPnComprobanteRecords = value; 
					colPnComprobanteRecords.ListChanged += new ListChangedEventHandler(colPnComprobanteRecords_ListChanged);
			}
		}
		
		void colPnComprobanteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnComprobanteRecords[e.NewIndex].IdFactura = IdFactura;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnTipoDePrestacion ActiveRecord object related to this PnFactura
		/// 
		/// </summary>
		public DalSic.PnTipoDePrestacion PnTipoDePrestacion
		{
			get { return DalSic.PnTipoDePrestacion.FetchByID(this.IdTipoDePrestacion); }
			set { SetColumnValue("idTipoDePrestacion", value.IdTipoDePrestacion); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varPeriodo,string varEstado,string varObservaciones,DateTime? varFechaCarga,DateTime? varFechaFactura,string varMesFactDC,decimal? varMontoPrefactura,DateTime? varFechaControl,string varNroExp,string varTraba,string varOnline,string varNroExpExt,DateTime? varFechaExpExt,string varPeriodoContable,string varPeriodoActual,int varEstadoExp,string varAltaComp,int? varIdTipoDePrestacion)
		{
			PnFactura item = new PnFactura();
			
			item.Cuie = varCuie;
			
			item.Periodo = varPeriodo;
			
			item.Estado = varEstado;
			
			item.Observaciones = varObservaciones;
			
			item.FechaCarga = varFechaCarga;
			
			item.FechaFactura = varFechaFactura;
			
			item.MesFactDC = varMesFactDC;
			
			item.MontoPrefactura = varMontoPrefactura;
			
			item.FechaControl = varFechaControl;
			
			item.NroExp = varNroExp;
			
			item.Traba = varTraba;
			
			item.Online = varOnline;
			
			item.NroExpExt = varNroExpExt;
			
			item.FechaExpExt = varFechaExpExt;
			
			item.PeriodoContable = varPeriodoContable;
			
			item.PeriodoActual = varPeriodoActual;
			
			item.EstadoExp = varEstadoExp;
			
			item.AltaComp = varAltaComp;
			
			item.IdTipoDePrestacion = varIdTipoDePrestacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdFactura,string varCuie,string varPeriodo,string varEstado,string varObservaciones,DateTime? varFechaCarga,DateTime? varFechaFactura,string varMesFactDC,decimal? varMontoPrefactura,DateTime? varFechaControl,string varNroExp,string varTraba,string varOnline,string varNroExpExt,DateTime? varFechaExpExt,string varPeriodoContable,string varPeriodoActual,int varEstadoExp,string varAltaComp,int? varIdTipoDePrestacion)
		{
			PnFactura item = new PnFactura();
			
				item.IdFactura = varIdFactura;
			
				item.Cuie = varCuie;
			
				item.Periodo = varPeriodo;
			
				item.Estado = varEstado;
			
				item.Observaciones = varObservaciones;
			
				item.FechaCarga = varFechaCarga;
			
				item.FechaFactura = varFechaFactura;
			
				item.MesFactDC = varMesFactDC;
			
				item.MontoPrefactura = varMontoPrefactura;
			
				item.FechaControl = varFechaControl;
			
				item.NroExp = varNroExp;
			
				item.Traba = varTraba;
			
				item.Online = varOnline;
			
				item.NroExpExt = varNroExpExt;
			
				item.FechaExpExt = varFechaExpExt;
			
				item.PeriodoContable = varPeriodoContable;
			
				item.PeriodoActual = varPeriodoActual;
			
				item.EstadoExp = varEstadoExp;
			
				item.AltaComp = varAltaComp;
			
				item.IdTipoDePrestacion = varIdTipoDePrestacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdFacturaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFacturaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn MesFactDCColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoPrefacturaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NroExpColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TrabaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn OnlineColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn NroExpExtColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaExpExtColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoContableColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoActualColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoExpColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn AltaCompColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoDePrestacionColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdFactura = @"id_factura";
			 public static string Cuie = @"cuie";
			 public static string Periodo = @"periodo";
			 public static string Estado = @"estado";
			 public static string Observaciones = @"observaciones";
			 public static string FechaCarga = @"fecha_carga";
			 public static string FechaFactura = @"fecha_factura";
			 public static string MesFactDC = @"mes_fact_d_c";
			 public static string MontoPrefactura = @"monto_prefactura";
			 public static string FechaControl = @"fecha_control";
			 public static string NroExp = @"nro_exp";
			 public static string Traba = @"traba";
			 public static string Online = @"online";
			 public static string NroExpExt = @"nro_exp_ext";
			 public static string FechaExpExt = @"fecha_exp_ext";
			 public static string PeriodoContable = @"periodo_contable";
			 public static string PeriodoActual = @"periodo_actual";
			 public static string EstadoExp = @"estado_exp";
			 public static string AltaComp = @"alta_comp";
			 public static string IdTipoDePrestacion = @"idTipoDePrestacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnComprobanteRecords != null)
                {
                    foreach (DalSic.PnComprobante item in colPnComprobanteRecords)
                    {
                        if (item.IdFactura != IdFactura)
                        {
                            item.IdFactura = IdFactura;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnComprobanteRecords != null)
                {
                    colPnComprobanteRecords.SaveAll();
               }
		}
        #endregion
	}
}
