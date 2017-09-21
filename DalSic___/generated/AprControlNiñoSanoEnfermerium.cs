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
	/// Strongly-typed collection for the AprControlNiñoSanoEnfermerium class.
	/// </summary>
    [Serializable]
	public partial class AprControlNiñoSanoEnfermeriumCollection : ActiveList<AprControlNiñoSanoEnfermerium, AprControlNiñoSanoEnfermeriumCollection>
	{	   
		public AprControlNiñoSanoEnfermeriumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprControlNiñoSanoEnfermeriumCollection</returns>
		public AprControlNiñoSanoEnfermeriumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprControlNiñoSanoEnfermerium o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ControlNiñoSanoEnfermeria table.
	/// </summary>
	[Serializable]
	public partial class AprControlNiñoSanoEnfermerium : ActiveRecord<AprControlNiñoSanoEnfermerium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprControlNiñoSanoEnfermerium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprControlNiñoSanoEnfermerium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprControlNiñoSanoEnfermerium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprControlNiñoSanoEnfermerium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ControlNiñoSanoEnfermeria", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdControlNiñoSanoEnfermeria = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSanoEnfermeria.ColumnName = "idControlNiñoSanoEnfermeria";
				colvarIdControlNiñoSanoEnfermeria.DataType = DbType.Int32;
				colvarIdControlNiñoSanoEnfermeria.MaxLength = 0;
				colvarIdControlNiñoSanoEnfermeria.AutoIncrement = true;
				colvarIdControlNiñoSanoEnfermeria.IsNullable = false;
				colvarIdControlNiñoSanoEnfermeria.IsPrimaryKey = true;
				colvarIdControlNiñoSanoEnfermeria.IsForeignKey = false;
				colvarIdControlNiñoSanoEnfermeria.IsReadOnly = false;
				colvarIdControlNiñoSanoEnfermeria.DefaultSetting = @"";
				colvarIdControlNiñoSanoEnfermeria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdControlNiñoSanoEnfermeria);
				
				TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
				colvarIdControlNiñoSano.DataType = DbType.Int32;
				colvarIdControlNiñoSano.MaxLength = 0;
				colvarIdControlNiñoSano.AutoIncrement = false;
				colvarIdControlNiñoSano.IsNullable = false;
				colvarIdControlNiñoSano.IsPrimaryKey = false;
				colvarIdControlNiñoSano.IsForeignKey = true;
				colvarIdControlNiñoSano.IsReadOnly = false;
				colvarIdControlNiñoSano.DefaultSetting = @"";
				
					colvarIdControlNiñoSano.ForeignKeyTableName = "APR_ControlNiñoSano";
				schema.Columns.Add(colvarIdControlNiñoSano);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "Peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = false;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "Talla";
				colvarTalla.DataType = DbType.Decimal;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = false;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarPerimetroCefalico = new TableSchema.TableColumn(schema);
				colvarPerimetroCefalico.ColumnName = "PerimetroCefalico";
				colvarPerimetroCefalico.DataType = DbType.Double;
				colvarPerimetroCefalico.MaxLength = 0;
				colvarPerimetroCefalico.AutoIncrement = false;
				colvarPerimetroCefalico.IsNullable = false;
				colvarPerimetroCefalico.IsPrimaryKey = false;
				colvarPerimetroCefalico.IsForeignKey = false;
				colvarPerimetroCefalico.IsReadOnly = false;
				colvarPerimetroCefalico.DefaultSetting = @"";
				colvarPerimetroCefalico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerimetroCefalico);
				
				TableSchema.TableColumn colvarIdEstadoNutricional = new TableSchema.TableColumn(schema);
				colvarIdEstadoNutricional.ColumnName = "idEstadoNutricional";
				colvarIdEstadoNutricional.DataType = DbType.Int32;
				colvarIdEstadoNutricional.MaxLength = 0;
				colvarIdEstadoNutricional.AutoIncrement = false;
				colvarIdEstadoNutricional.IsNullable = true;
				colvarIdEstadoNutricional.IsPrimaryKey = false;
				colvarIdEstadoNutricional.IsForeignKey = true;
				colvarIdEstadoNutricional.IsReadOnly = false;
				colvarIdEstadoNutricional.DefaultSetting = @"";
				
					colvarIdEstadoNutricional.ForeignKeyTableName = "APR_EstadoNutricional";
				schema.Columns.Add(colvarIdEstadoNutricional);
				
				TableSchema.TableColumn colvarIdTallaEdad = new TableSchema.TableColumn(schema);
				colvarIdTallaEdad.ColumnName = "idTallaEdad";
				colvarIdTallaEdad.DataType = DbType.Int32;
				colvarIdTallaEdad.MaxLength = 0;
				colvarIdTallaEdad.AutoIncrement = false;
				colvarIdTallaEdad.IsNullable = true;
				colvarIdTallaEdad.IsPrimaryKey = false;
				colvarIdTallaEdad.IsForeignKey = true;
				colvarIdTallaEdad.IsReadOnly = false;
				colvarIdTallaEdad.DefaultSetting = @"";
				
					colvarIdTallaEdad.ForeignKeyTableName = "APR_TallaEdad";
				schema.Columns.Add(colvarIdTallaEdad);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = true;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
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
				
				TableSchema.TableColumn colvarTa = new TableSchema.TableColumn(schema);
				colvarTa.ColumnName = "TA";
				colvarTa.DataType = DbType.AnsiString;
				colvarTa.MaxLength = 50;
				colvarTa.AutoIncrement = false;
				colvarTa.IsNullable = true;
				colvarTa.IsPrimaryKey = false;
				colvarTa.IsForeignKey = false;
				colvarTa.IsReadOnly = false;
				
						colvarTa.DefaultSetting = @"('')";
				colvarTa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTa);
				
				TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
				colvarFechaControl.ColumnName = "fechaControl";
				colvarFechaControl.DataType = DbType.DateTime;
				colvarFechaControl.MaxLength = 0;
				colvarFechaControl.AutoIncrement = false;
				colvarFechaControl.IsNullable = true;
				colvarFechaControl.IsPrimaryKey = false;
				colvarFechaControl.IsForeignKey = false;
				colvarFechaControl.IsReadOnly = false;
				
						colvarFechaControl.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaControl);
				
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
				
				TableSchema.TableColumn colvarIcm = new TableSchema.TableColumn(schema);
				colvarIcm.ColumnName = "ICM";
				colvarIcm.DataType = DbType.Decimal;
				colvarIcm.MaxLength = 0;
				colvarIcm.AutoIncrement = false;
				colvarIcm.IsNullable = true;
				colvarIcm.IsPrimaryKey = false;
				colvarIcm.IsForeignKey = false;
				colvarIcm.IsReadOnly = true;
				colvarIcm.DefaultSetting = @"";
				colvarIcm.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIcm);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ControlNiñoSanoEnfermeria",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdControlNiñoSanoEnfermeria")]
		[Bindable(true)]
		public int IdControlNiñoSanoEnfermeria 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSanoEnfermeria); }
			set { SetColumnValue(Columns.IdControlNiñoSanoEnfermeria, value); }
		}
		  
		[XmlAttribute("IdControlNiñoSano")]
		[Bindable(true)]
		public int IdControlNiñoSano 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSano); }
			set { SetColumnValue(Columns.IdControlNiñoSano, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal Peso 
		{
			get { return GetColumnValue<decimal>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public decimal Talla 
		{
			get { return GetColumnValue<decimal>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("PerimetroCefalico")]
		[Bindable(true)]
		public double PerimetroCefalico 
		{
			get { return GetColumnValue<double>(Columns.PerimetroCefalico); }
			set { SetColumnValue(Columns.PerimetroCefalico, value); }
		}
		  
		[XmlAttribute("IdEstadoNutricional")]
		[Bindable(true)]
		public int? IdEstadoNutricional 
		{
			get { return GetColumnValue<int?>(Columns.IdEstadoNutricional); }
			set { SetColumnValue(Columns.IdEstadoNutricional, value); }
		}
		  
		[XmlAttribute("IdTallaEdad")]
		[Bindable(true)]
		public int? IdTallaEdad 
		{
			get { return GetColumnValue<int?>(Columns.IdTallaEdad); }
			set { SetColumnValue(Columns.IdTallaEdad, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int? IdProfesional 
		{
			get { return GetColumnValue<int?>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("Ta")]
		[Bindable(true)]
		public string Ta 
		{
			get { return GetColumnValue<string>(Columns.Ta); }
			set { SetColumnValue(Columns.Ta, value); }
		}
		  
		[XmlAttribute("FechaControl")]
		[Bindable(true)]
		public DateTime? FechaControl 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaControl); }
			set { SetColumnValue(Columns.FechaControl, value); }
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
		  
		[XmlAttribute("Icm")]
		[Bindable(true)]
		public decimal? Icm 
		{
			get { return GetColumnValue<decimal?>(Columns.Icm); }
			set { SetColumnValue(Columns.Icm, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprTallaEdad ActiveRecord object related to this AprControlNiñoSanoEnfermerium
		/// 
		/// </summary>
		public DalSic.AprTallaEdad AprTallaEdad
		{
			get { return DalSic.AprTallaEdad.FetchByID(this.IdTallaEdad); }
			set { SetColumnValue("idTallaEdad", value.IdTallaEdad); }
		}
		
		
		/// <summary>
		/// Returns a AprControlNiñoSano ActiveRecord object related to this AprControlNiñoSanoEnfermerium
		/// 
		/// </summary>
		public DalSic.AprControlNiñoSano AprControlNiñoSano
		{
			get { return DalSic.AprControlNiñoSano.FetchByID(this.IdControlNiñoSano); }
			set { SetColumnValue("idControlNiñoSano", value.IdControlNiñoSano); }
		}
		
		
		/// <summary>
		/// Returns a AprEstadoNutricional ActiveRecord object related to this AprControlNiñoSanoEnfermerium
		/// 
		/// </summary>
		public DalSic.AprEstadoNutricional AprEstadoNutricional
		{
			get { return DalSic.AprEstadoNutricional.FetchByID(this.IdEstadoNutricional); }
			set { SetColumnValue("idEstadoNutricional", value.IdEstadoNutricional); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this AprControlNiñoSanoEnfermerium
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
		public static void Insert(int varIdControlNiñoSano,decimal varPeso,decimal varTalla,double varPerimetroCefalico,int? varIdEstadoNutricional,int? varIdTallaEdad,int? varIdPaciente,int? varIdProfesional,string varObservaciones,string varTa,DateTime? varFechaControl,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,decimal? varIcm)
		{
			AprControlNiñoSanoEnfermerium item = new AprControlNiñoSanoEnfermerium();
			
			item.IdControlNiñoSano = varIdControlNiñoSano;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.PerimetroCefalico = varPerimetroCefalico;
			
			item.IdEstadoNutricional = varIdEstadoNutricional;
			
			item.IdTallaEdad = varIdTallaEdad;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdProfesional = varIdProfesional;
			
			item.Observaciones = varObservaciones;
			
			item.Ta = varTa;
			
			item.FechaControl = varFechaControl;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Icm = varIcm;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdControlNiñoSanoEnfermeria,int varIdControlNiñoSano,decimal varPeso,decimal varTalla,double varPerimetroCefalico,int? varIdEstadoNutricional,int? varIdTallaEdad,int? varIdPaciente,int? varIdProfesional,string varObservaciones,string varTa,DateTime? varFechaControl,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,decimal? varIcm)
		{
			AprControlNiñoSanoEnfermerium item = new AprControlNiñoSanoEnfermerium();
			
				item.IdControlNiñoSanoEnfermeria = varIdControlNiñoSanoEnfermeria;
			
				item.IdControlNiñoSano = varIdControlNiñoSano;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.PerimetroCefalico = varPerimetroCefalico;
			
				item.IdEstadoNutricional = varIdEstadoNutricional;
			
				item.IdTallaEdad = varIdTallaEdad;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdProfesional = varIdProfesional;
			
				item.Observaciones = varObservaciones;
			
				item.Ta = varTa;
			
				item.FechaControl = varFechaControl;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Icm = varIcm;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoEnfermeriaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PerimetroCefalicoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoNutricionalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTallaEdadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IcmColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdControlNiñoSanoEnfermeria = @"idControlNiñoSanoEnfermeria";
			 public static string IdControlNiñoSano = @"idControlNiñoSano";
			 public static string Peso = @"Peso";
			 public static string Talla = @"Talla";
			 public static string PerimetroCefalico = @"PerimetroCefalico";
			 public static string IdEstadoNutricional = @"idEstadoNutricional";
			 public static string IdTallaEdad = @"idTallaEdad";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdProfesional = @"idProfesional";
			 public static string Observaciones = @"observaciones";
			 public static string Ta = @"TA";
			 public static string FechaControl = @"fechaControl";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string Icm = @"ICM";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
