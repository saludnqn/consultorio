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
	/// Strongly-typed collection for the AprHistoriaClinicaPerinatalDetalle class.
	/// </summary>
    [Serializable]
	public partial class AprHistoriaClinicaPerinatalDetalleCollection : ActiveList<AprHistoriaClinicaPerinatalDetalle, AprHistoriaClinicaPerinatalDetalleCollection>
	{	   
		public AprHistoriaClinicaPerinatalDetalleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprHistoriaClinicaPerinatalDetalleCollection</returns>
		public AprHistoriaClinicaPerinatalDetalleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprHistoriaClinicaPerinatalDetalle o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_HistoriaClinicaPerinatalDetalle table.
	/// </summary>
	[Serializable]
	public partial class AprHistoriaClinicaPerinatalDetalle : ActiveRecord<AprHistoriaClinicaPerinatalDetalle>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprHistoriaClinicaPerinatalDetalle()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprHistoriaClinicaPerinatalDetalle(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprHistoriaClinicaPerinatalDetalle(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprHistoriaClinicaPerinatalDetalle(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_HistoriaClinicaPerinatalDetalle", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHistoriaClinicaPerinatalDetalle = new TableSchema.TableColumn(schema);
				colvarIdHistoriaClinicaPerinatalDetalle.ColumnName = "idHistoriaClinicaPerinatalDetalle";
				colvarIdHistoriaClinicaPerinatalDetalle.DataType = DbType.Int32;
				colvarIdHistoriaClinicaPerinatalDetalle.MaxLength = 0;
				colvarIdHistoriaClinicaPerinatalDetalle.AutoIncrement = true;
				colvarIdHistoriaClinicaPerinatalDetalle.IsNullable = false;
				colvarIdHistoriaClinicaPerinatalDetalle.IsPrimaryKey = true;
				colvarIdHistoriaClinicaPerinatalDetalle.IsForeignKey = false;
				colvarIdHistoriaClinicaPerinatalDetalle.IsReadOnly = false;
				colvarIdHistoriaClinicaPerinatalDetalle.DefaultSetting = @"";
				colvarIdHistoriaClinicaPerinatalDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHistoriaClinicaPerinatalDetalle);
				
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
				
				TableSchema.TableColumn colvarIdHistoriaClinicaPerinatal = new TableSchema.TableColumn(schema);
				colvarIdHistoriaClinicaPerinatal.ColumnName = "idHistoriaClinicaPerinatal";
				colvarIdHistoriaClinicaPerinatal.DataType = DbType.Int32;
				colvarIdHistoriaClinicaPerinatal.MaxLength = 0;
				colvarIdHistoriaClinicaPerinatal.AutoIncrement = false;
				colvarIdHistoriaClinicaPerinatal.IsNullable = false;
				colvarIdHistoriaClinicaPerinatal.IsPrimaryKey = false;
				colvarIdHistoriaClinicaPerinatal.IsForeignKey = true;
				colvarIdHistoriaClinicaPerinatal.IsReadOnly = false;
				colvarIdHistoriaClinicaPerinatal.DefaultSetting = @"";
				
					colvarIdHistoriaClinicaPerinatal.ForeignKeyTableName = "APR_HistoriaClinicaPerinatal";
				schema.Columns.Add(colvarIdHistoriaClinicaPerinatal);
				
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
				
				TableSchema.TableColumn colvarEdadGestacional = new TableSchema.TableColumn(schema);
				colvarEdadGestacional.ColumnName = "EdadGestacional";
				colvarEdadGestacional.DataType = DbType.Decimal;
				colvarEdadGestacional.MaxLength = 0;
				colvarEdadGestacional.AutoIncrement = false;
				colvarEdadGestacional.IsNullable = true;
				colvarEdadGestacional.IsPrimaryKey = false;
				colvarEdadGestacional.IsForeignKey = false;
				colvarEdadGestacional.IsReadOnly = false;
				colvarEdadGestacional.DefaultSetting = @"";
				colvarEdadGestacional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadGestacional);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "Peso";
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
				
				TableSchema.TableColumn colvarImc = new TableSchema.TableColumn(schema);
				colvarImc.ColumnName = "IMC";
				colvarImc.DataType = DbType.Decimal;
				colvarImc.MaxLength = 0;
				colvarImc.AutoIncrement = false;
				colvarImc.IsNullable = true;
				colvarImc.IsPrimaryKey = false;
				colvarImc.IsForeignKey = false;
				colvarImc.IsReadOnly = false;
				colvarImc.DefaultSetting = @"";
				colvarImc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImc);
				
				TableSchema.TableColumn colvarPa = new TableSchema.TableColumn(schema);
				colvarPa.ColumnName = "PA";
				colvarPa.DataType = DbType.AnsiString;
				colvarPa.MaxLength = -1;
				colvarPa.AutoIncrement = false;
				colvarPa.IsNullable = true;
				colvarPa.IsPrimaryKey = false;
				colvarPa.IsForeignKey = false;
				colvarPa.IsReadOnly = false;
				colvarPa.DefaultSetting = @"";
				colvarPa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPa);
				
				TableSchema.TableColumn colvarAlturaUterina = new TableSchema.TableColumn(schema);
				colvarAlturaUterina.ColumnName = "AlturaUterina";
				colvarAlturaUterina.DataType = DbType.Decimal;
				colvarAlturaUterina.MaxLength = 0;
				colvarAlturaUterina.AutoIncrement = false;
				colvarAlturaUterina.IsNullable = true;
				colvarAlturaUterina.IsPrimaryKey = false;
				colvarAlturaUterina.IsForeignKey = false;
				colvarAlturaUterina.IsReadOnly = false;
				colvarAlturaUterina.DefaultSetting = @"";
				colvarAlturaUterina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlturaUterina);
				
				TableSchema.TableColumn colvarPresentacion = new TableSchema.TableColumn(schema);
				colvarPresentacion.ColumnName = "Presentacion";
				colvarPresentacion.DataType = DbType.AnsiString;
				colvarPresentacion.MaxLength = -1;
				colvarPresentacion.AutoIncrement = false;
				colvarPresentacion.IsNullable = true;
				colvarPresentacion.IsPrimaryKey = false;
				colvarPresentacion.IsForeignKey = false;
				colvarPresentacion.IsReadOnly = false;
				colvarPresentacion.DefaultSetting = @"";
				colvarPresentacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresentacion);
				
				TableSchema.TableColumn colvarFcf = new TableSchema.TableColumn(schema);
				colvarFcf.ColumnName = "FCF";
				colvarFcf.DataType = DbType.Int32;
				colvarFcf.MaxLength = 0;
				colvarFcf.AutoIncrement = false;
				colvarFcf.IsNullable = true;
				colvarFcf.IsPrimaryKey = false;
				colvarFcf.IsForeignKey = false;
				colvarFcf.IsReadOnly = false;
				colvarFcf.DefaultSetting = @"";
				colvarFcf.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFcf);
				
				TableSchema.TableColumn colvarMovimientosFetales = new TableSchema.TableColumn(schema);
				colvarMovimientosFetales.ColumnName = "MovimientosFetales";
				colvarMovimientosFetales.DataType = DbType.AnsiString;
				colvarMovimientosFetales.MaxLength = -1;
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
				colvarProteinuria.DataType = DbType.AnsiString;
				colvarProteinuria.MaxLength = -1;
				colvarProteinuria.AutoIncrement = false;
				colvarProteinuria.IsNullable = true;
				colvarProteinuria.IsPrimaryKey = false;
				colvarProteinuria.IsForeignKey = false;
				colvarProteinuria.IsReadOnly = false;
				colvarProteinuria.DefaultSetting = @"";
				colvarProteinuria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProteinuria);
				
				TableSchema.TableColumn colvarAlarmaExamenesTratamientos = new TableSchema.TableColumn(schema);
				colvarAlarmaExamenesTratamientos.ColumnName = "AlarmaExamenesTratamientos";
				colvarAlarmaExamenesTratamientos.DataType = DbType.AnsiString;
				colvarAlarmaExamenesTratamientos.MaxLength = -1;
				colvarAlarmaExamenesTratamientos.AutoIncrement = false;
				colvarAlarmaExamenesTratamientos.IsNullable = true;
				colvarAlarmaExamenesTratamientos.IsPrimaryKey = false;
				colvarAlarmaExamenesTratamientos.IsForeignKey = false;
				colvarAlarmaExamenesTratamientos.IsReadOnly = false;
				colvarAlarmaExamenesTratamientos.DefaultSetting = @"";
				colvarAlarmaExamenesTratamientos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlarmaExamenesTratamientos);
				
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
				
				TableSchema.TableColumn colvarInicialesTecnico = new TableSchema.TableColumn(schema);
				colvarInicialesTecnico.ColumnName = "InicialesTecnico";
				colvarInicialesTecnico.DataType = DbType.AnsiString;
				colvarInicialesTecnico.MaxLength = -1;
				colvarInicialesTecnico.AutoIncrement = false;
				colvarInicialesTecnico.IsNullable = true;
				colvarInicialesTecnico.IsPrimaryKey = false;
				colvarInicialesTecnico.IsForeignKey = false;
				colvarInicialesTecnico.IsReadOnly = false;
				colvarInicialesTecnico.DefaultSetting = @"";
				colvarInicialesTecnico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInicialesTecnico);
				
				TableSchema.TableColumn colvarProximaCita = new TableSchema.TableColumn(schema);
				colvarProximaCita.ColumnName = "ProximaCita";
				colvarProximaCita.DataType = DbType.DateTime;
				colvarProximaCita.MaxLength = 0;
				colvarProximaCita.AutoIncrement = false;
				colvarProximaCita.IsNullable = true;
				colvarProximaCita.IsPrimaryKey = false;
				colvarProximaCita.IsForeignKey = false;
				colvarProximaCita.IsReadOnly = false;
				colvarProximaCita.DefaultSetting = @"";
				colvarProximaCita.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProximaCita);
				
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
				
				TableSchema.TableColumn colvarActiva = new TableSchema.TableColumn(schema);
				colvarActiva.ColumnName = "activa";
				colvarActiva.DataType = DbType.Boolean;
				colvarActiva.MaxLength = 0;
				colvarActiva.AutoIncrement = false;
				colvarActiva.IsNullable = false;
				colvarActiva.IsPrimaryKey = false;
				colvarActiva.IsForeignKey = false;
				colvarActiva.IsReadOnly = false;
				
						colvarActiva.DefaultSetting = @"((1))";
				colvarActiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActiva);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_HistoriaClinicaPerinatalDetalle",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHistoriaClinicaPerinatalDetalle")]
		[Bindable(true)]
		public int IdHistoriaClinicaPerinatalDetalle 
		{
			get { return GetColumnValue<int>(Columns.IdHistoriaClinicaPerinatalDetalle); }
			set { SetColumnValue(Columns.IdHistoriaClinicaPerinatalDetalle, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdHistoriaClinicaPerinatal")]
		[Bindable(true)]
		public int IdHistoriaClinicaPerinatal 
		{
			get { return GetColumnValue<int>(Columns.IdHistoriaClinicaPerinatal); }
			set { SetColumnValue(Columns.IdHistoriaClinicaPerinatal, value); }
		}
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int? IdConsulta 
		{
			get { return GetColumnValue<int?>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("EdadGestacional")]
		[Bindable(true)]
		public decimal? EdadGestacional 
		{
			get { return GetColumnValue<decimal?>(Columns.EdadGestacional); }
			set { SetColumnValue(Columns.EdadGestacional, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal? Peso 
		{
			get { return GetColumnValue<decimal?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Imc")]
		[Bindable(true)]
		public decimal? Imc 
		{
			get { return GetColumnValue<decimal?>(Columns.Imc); }
			set { SetColumnValue(Columns.Imc, value); }
		}
		  
		[XmlAttribute("Pa")]
		[Bindable(true)]
		public string Pa 
		{
			get { return GetColumnValue<string>(Columns.Pa); }
			set { SetColumnValue(Columns.Pa, value); }
		}
		  
		[XmlAttribute("AlturaUterina")]
		[Bindable(true)]
		public decimal? AlturaUterina 
		{
			get { return GetColumnValue<decimal?>(Columns.AlturaUterina); }
			set { SetColumnValue(Columns.AlturaUterina, value); }
		}
		  
		[XmlAttribute("Presentacion")]
		[Bindable(true)]
		public string Presentacion 
		{
			get { return GetColumnValue<string>(Columns.Presentacion); }
			set { SetColumnValue(Columns.Presentacion, value); }
		}
		  
		[XmlAttribute("Fcf")]
		[Bindable(true)]
		public int? Fcf 
		{
			get { return GetColumnValue<int?>(Columns.Fcf); }
			set { SetColumnValue(Columns.Fcf, value); }
		}
		  
		[XmlAttribute("MovimientosFetales")]
		[Bindable(true)]
		public string MovimientosFetales 
		{
			get { return GetColumnValue<string>(Columns.MovimientosFetales); }
			set { SetColumnValue(Columns.MovimientosFetales, value); }
		}
		  
		[XmlAttribute("Proteinuria")]
		[Bindable(true)]
		public string Proteinuria 
		{
			get { return GetColumnValue<string>(Columns.Proteinuria); }
			set { SetColumnValue(Columns.Proteinuria, value); }
		}
		  
		[XmlAttribute("AlarmaExamenesTratamientos")]
		[Bindable(true)]
		public string AlarmaExamenesTratamientos 
		{
			get { return GetColumnValue<string>(Columns.AlarmaExamenesTratamientos); }
			set { SetColumnValue(Columns.AlarmaExamenesTratamientos, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("InicialesTecnico")]
		[Bindable(true)]
		public string InicialesTecnico 
		{
			get { return GetColumnValue<string>(Columns.InicialesTecnico); }
			set { SetColumnValue(Columns.InicialesTecnico, value); }
		}
		  
		[XmlAttribute("ProximaCita")]
		[Bindable(true)]
		public DateTime? ProximaCita 
		{
			get { return GetColumnValue<DateTime?>(Columns.ProximaCita); }
			set { SetColumnValue(Columns.ProximaCita, value); }
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
		  
		[XmlAttribute("Activa")]
		[Bindable(true)]
		public bool Activa 
		{
			get { return GetColumnValue<bool>(Columns.Activa); }
			set { SetColumnValue(Columns.Activa, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprHistoriaClinicaPerinatal ActiveRecord object related to this AprHistoriaClinicaPerinatalDetalle
		/// 
		/// </summary>
		public DalSic.AprHistoriaClinicaPerinatal AprHistoriaClinicaPerinatal
		{
			get { return DalSic.AprHistoriaClinicaPerinatal.FetchByID(this.IdHistoriaClinicaPerinatal); }
			set { SetColumnValue("idHistoriaClinicaPerinatal", value.IdHistoriaClinicaPerinatal); }
		}
		
		
		/// <summary>
		/// Returns a ConConsultum ActiveRecord object related to this AprHistoriaClinicaPerinatalDetalle
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
		public static void Insert(int varIdEfector,int varIdHistoriaClinicaPerinatal,int? varIdConsulta,DateTime? varFecha,decimal? varEdadGestacional,decimal? varPeso,decimal? varImc,string varPa,decimal? varAlturaUterina,string varPresentacion,int? varFcf,string varMovimientosFetales,string varProteinuria,string varAlarmaExamenesTratamientos,string varObservaciones,string varInicialesTecnico,DateTime? varProximaCita,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,bool varActiva)
		{
			AprHistoriaClinicaPerinatalDetalle item = new AprHistoriaClinicaPerinatalDetalle();
			
			item.IdEfector = varIdEfector;
			
			item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
			item.IdConsulta = varIdConsulta;
			
			item.Fecha = varFecha;
			
			item.EdadGestacional = varEdadGestacional;
			
			item.Peso = varPeso;
			
			item.Imc = varImc;
			
			item.Pa = varPa;
			
			item.AlturaUterina = varAlturaUterina;
			
			item.Presentacion = varPresentacion;
			
			item.Fcf = varFcf;
			
			item.MovimientosFetales = varMovimientosFetales;
			
			item.Proteinuria = varProteinuria;
			
			item.AlarmaExamenesTratamientos = varAlarmaExamenesTratamientos;
			
			item.Observaciones = varObservaciones;
			
			item.InicialesTecnico = varInicialesTecnico;
			
			item.ProximaCita = varProximaCita;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Activa = varActiva;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdHistoriaClinicaPerinatalDetalle,int varIdEfector,int varIdHistoriaClinicaPerinatal,int? varIdConsulta,DateTime? varFecha,decimal? varEdadGestacional,decimal? varPeso,decimal? varImc,string varPa,decimal? varAlturaUterina,string varPresentacion,int? varFcf,string varMovimientosFetales,string varProteinuria,string varAlarmaExamenesTratamientos,string varObservaciones,string varInicialesTecnico,DateTime? varProximaCita,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,bool varActiva)
		{
			AprHistoriaClinicaPerinatalDetalle item = new AprHistoriaClinicaPerinatalDetalle();
			
				item.IdHistoriaClinicaPerinatalDetalle = varIdHistoriaClinicaPerinatalDetalle;
			
				item.IdEfector = varIdEfector;
			
				item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
				item.IdConsulta = varIdConsulta;
			
				item.Fecha = varFecha;
			
				item.EdadGestacional = varEdadGestacional;
			
				item.Peso = varPeso;
			
				item.Imc = varImc;
			
				item.Pa = varPa;
			
				item.AlturaUterina = varAlturaUterina;
			
				item.Presentacion = varPresentacion;
			
				item.Fcf = varFcf;
			
				item.MovimientosFetales = varMovimientosFetales;
			
				item.Proteinuria = varProteinuria;
			
				item.AlarmaExamenesTratamientos = varAlarmaExamenesTratamientos;
			
				item.Observaciones = varObservaciones;
			
				item.InicialesTecnico = varInicialesTecnico;
			
				item.ProximaCita = varProximaCita;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Activa = varActiva;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHistoriaClinicaPerinatalDetalleColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdHistoriaClinicaPerinatalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadGestacionalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ImcColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AlturaUterinaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn PresentacionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FcfColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn MovimientosFetalesColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ProteinuriaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AlarmaExamenesTratamientosColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn InicialesTecnicoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ProximaCitaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivaColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHistoriaClinicaPerinatalDetalle = @"idHistoriaClinicaPerinatalDetalle";
			 public static string IdEfector = @"idEfector";
			 public static string IdHistoriaClinicaPerinatal = @"idHistoriaClinicaPerinatal";
			 public static string IdConsulta = @"idConsulta";
			 public static string Fecha = @"Fecha";
			 public static string EdadGestacional = @"EdadGestacional";
			 public static string Peso = @"Peso";
			 public static string Imc = @"IMC";
			 public static string Pa = @"PA";
			 public static string AlturaUterina = @"AlturaUterina";
			 public static string Presentacion = @"Presentacion";
			 public static string Fcf = @"FCF";
			 public static string MovimientosFetales = @"MovimientosFetales";
			 public static string Proteinuria = @"Proteinuria";
			 public static string AlarmaExamenesTratamientos = @"AlarmaExamenesTratamientos";
			 public static string Observaciones = @"Observaciones";
			 public static string InicialesTecnico = @"InicialesTecnico";
			 public static string ProximaCita = @"ProximaCita";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string Activa = @"activa";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
