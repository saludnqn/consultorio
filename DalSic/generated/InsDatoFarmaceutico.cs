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
	/// Strongly-typed collection for the InsDatoFarmaceutico class.
	/// </summary>
    [Serializable]
	public partial class InsDatoFarmaceuticoCollection : ActiveList<InsDatoFarmaceutico, InsDatoFarmaceuticoCollection>
	{	   
		public InsDatoFarmaceuticoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsDatoFarmaceuticoCollection</returns>
		public InsDatoFarmaceuticoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsDatoFarmaceutico o = this[i];
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
	/// This is an ActiveRecord class which wraps the INS_DatoFarmaceutico table.
	/// </summary>
	[Serializable]
	public partial class InsDatoFarmaceutico : ActiveRecord<InsDatoFarmaceutico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsDatoFarmaceutico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsDatoFarmaceutico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsDatoFarmaceutico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsDatoFarmaceutico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("INS_DatoFarmaceutico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDatoFarmaceutico = new TableSchema.TableColumn(schema);
				colvarIdDatoFarmaceutico.ColumnName = "idDatoFarmaceutico";
				colvarIdDatoFarmaceutico.DataType = DbType.Int32;
				colvarIdDatoFarmaceutico.MaxLength = 0;
				colvarIdDatoFarmaceutico.AutoIncrement = true;
				colvarIdDatoFarmaceutico.IsNullable = false;
				colvarIdDatoFarmaceutico.IsPrimaryKey = true;
				colvarIdDatoFarmaceutico.IsForeignKey = false;
				colvarIdDatoFarmaceutico.IsReadOnly = false;
				colvarIdDatoFarmaceutico.DefaultSetting = @"";
				colvarIdDatoFarmaceutico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDatoFarmaceutico);
				
				TableSchema.TableColumn colvarIdInsumo = new TableSchema.TableColumn(schema);
				colvarIdInsumo.ColumnName = "idInsumo";
				colvarIdInsumo.DataType = DbType.Int32;
				colvarIdInsumo.MaxLength = 0;
				colvarIdInsumo.AutoIncrement = false;
				colvarIdInsumo.IsNullable = false;
				colvarIdInsumo.IsPrimaryKey = false;
				colvarIdInsumo.IsForeignKey = true;
				colvarIdInsumo.IsReadOnly = false;
				
						colvarIdInsumo.DefaultSetting = @"((0))";
				
					colvarIdInsumo.ForeignKeyTableName = "INS_Insumo";
				schema.Columns.Add(colvarIdInsumo);
				
				TableSchema.TableColumn colvarCodigoOMS = new TableSchema.TableColumn(schema);
				colvarCodigoOMS.ColumnName = "codigoOMS";
				colvarCodigoOMS.DataType = DbType.AnsiString;
				colvarCodigoOMS.MaxLength = 50;
				colvarCodigoOMS.AutoIncrement = false;
				colvarCodigoOMS.IsNullable = false;
				colvarCodigoOMS.IsPrimaryKey = false;
				colvarCodigoOMS.IsForeignKey = false;
				colvarCodigoOMS.IsReadOnly = false;
				
						colvarCodigoOMS.DefaultSetting = @"('')";
				colvarCodigoOMS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoOMS);
				
				TableSchema.TableColumn colvarNivelComplejidad = new TableSchema.TableColumn(schema);
				colvarNivelComplejidad.ColumnName = "nivelComplejidad";
				colvarNivelComplejidad.DataType = DbType.Int32;
				colvarNivelComplejidad.MaxLength = 0;
				colvarNivelComplejidad.AutoIncrement = false;
				colvarNivelComplejidad.IsNullable = false;
				colvarNivelComplejidad.IsPrimaryKey = false;
				colvarNivelComplejidad.IsForeignKey = false;
				colvarNivelComplejidad.IsReadOnly = false;
				
						colvarNivelComplejidad.DefaultSetting = @"((0))";
				colvarNivelComplejidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNivelComplejidad);
				
				TableSchema.TableColumn colvarComposicion = new TableSchema.TableColumn(schema);
				colvarComposicion.ColumnName = "composicion";
				colvarComposicion.DataType = DbType.AnsiString;
				colvarComposicion.MaxLength = 400;
				colvarComposicion.AutoIncrement = false;
				colvarComposicion.IsNullable = false;
				colvarComposicion.IsPrimaryKey = false;
				colvarComposicion.IsForeignKey = false;
				colvarComposicion.IsReadOnly = false;
				
						colvarComposicion.DefaultSetting = @"('')";
				colvarComposicion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComposicion);
				
				TableSchema.TableColumn colvarContraindicaciones = new TableSchema.TableColumn(schema);
				colvarContraindicaciones.ColumnName = "contraindicaciones";
				colvarContraindicaciones.DataType = DbType.AnsiString;
				colvarContraindicaciones.MaxLength = 300;
				colvarContraindicaciones.AutoIncrement = false;
				colvarContraindicaciones.IsNullable = false;
				colvarContraindicaciones.IsPrimaryKey = false;
				colvarContraindicaciones.IsForeignKey = false;
				colvarContraindicaciones.IsReadOnly = false;
				
						colvarContraindicaciones.DefaultSetting = @"('')";
				colvarContraindicaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContraindicaciones);
				
				TableSchema.TableColumn colvarAccionTerapeutica = new TableSchema.TableColumn(schema);
				colvarAccionTerapeutica.ColumnName = "accionTerapeutica";
				colvarAccionTerapeutica.DataType = DbType.AnsiString;
				colvarAccionTerapeutica.MaxLength = 200;
				colvarAccionTerapeutica.AutoIncrement = false;
				colvarAccionTerapeutica.IsNullable = false;
				colvarAccionTerapeutica.IsPrimaryKey = false;
				colvarAccionTerapeutica.IsForeignKey = false;
				colvarAccionTerapeutica.IsReadOnly = false;
				
						colvarAccionTerapeutica.DefaultSetting = @"('')";
				colvarAccionTerapeutica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccionTerapeutica);
				
				TableSchema.TableColumn colvarNecesitaReceta = new TableSchema.TableColumn(schema);
				colvarNecesitaReceta.ColumnName = "necesitaReceta";
				colvarNecesitaReceta.DataType = DbType.Boolean;
				colvarNecesitaReceta.MaxLength = 0;
				colvarNecesitaReceta.AutoIncrement = false;
				colvarNecesitaReceta.IsNullable = false;
				colvarNecesitaReceta.IsPrimaryKey = false;
				colvarNecesitaReceta.IsForeignKey = false;
				colvarNecesitaReceta.IsReadOnly = false;
				
						colvarNecesitaReceta.DefaultSetting = @"((1))";
				colvarNecesitaReceta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNecesitaReceta);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((0))";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = false;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				colvarBaja.DefaultSetting = @"";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"('')";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("INS_DatoFarmaceutico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDatoFarmaceutico")]
		[Bindable(true)]
		public int IdDatoFarmaceutico 
		{
			get { return GetColumnValue<int>(Columns.IdDatoFarmaceutico); }
			set { SetColumnValue(Columns.IdDatoFarmaceutico, value); }
		}
		  
		[XmlAttribute("IdInsumo")]
		[Bindable(true)]
		public int IdInsumo 
		{
			get { return GetColumnValue<int>(Columns.IdInsumo); }
			set { SetColumnValue(Columns.IdInsumo, value); }
		}
		  
		[XmlAttribute("CodigoOMS")]
		[Bindable(true)]
		public string CodigoOMS 
		{
			get { return GetColumnValue<string>(Columns.CodigoOMS); }
			set { SetColumnValue(Columns.CodigoOMS, value); }
		}
		  
		[XmlAttribute("NivelComplejidad")]
		[Bindable(true)]
		public int NivelComplejidad 
		{
			get { return GetColumnValue<int>(Columns.NivelComplejidad); }
			set { SetColumnValue(Columns.NivelComplejidad, value); }
		}
		  
		[XmlAttribute("Composicion")]
		[Bindable(true)]
		public string Composicion 
		{
			get { return GetColumnValue<string>(Columns.Composicion); }
			set { SetColumnValue(Columns.Composicion, value); }
		}
		  
		[XmlAttribute("Contraindicaciones")]
		[Bindable(true)]
		public string Contraindicaciones 
		{
			get { return GetColumnValue<string>(Columns.Contraindicaciones); }
			set { SetColumnValue(Columns.Contraindicaciones, value); }
		}
		  
		[XmlAttribute("AccionTerapeutica")]
		[Bindable(true)]
		public string AccionTerapeutica 
		{
			get { return GetColumnValue<string>(Columns.AccionTerapeutica); }
			set { SetColumnValue(Columns.AccionTerapeutica, value); }
		}
		  
		[XmlAttribute("NecesitaReceta")]
		[Bindable(true)]
		public bool NecesitaReceta 
		{
			get { return GetColumnValue<bool>(Columns.NecesitaReceta); }
			set { SetColumnValue(Columns.NecesitaReceta, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool Baja 
		{
			get { return GetColumnValue<bool>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
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
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
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
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInsumo,string varCodigoOMS,int varNivelComplejidad,string varComposicion,string varContraindicaciones,string varAccionTerapeutica,bool varNecesitaReceta,int varIdEfector,bool varBaja,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			InsDatoFarmaceutico item = new InsDatoFarmaceutico();
			
			item.IdInsumo = varIdInsumo;
			
			item.CodigoOMS = varCodigoOMS;
			
			item.NivelComplejidad = varNivelComplejidad;
			
			item.Composicion = varComposicion;
			
			item.Contraindicaciones = varContraindicaciones;
			
			item.AccionTerapeutica = varAccionTerapeutica;
			
			item.NecesitaReceta = varNecesitaReceta;
			
			item.IdEfector = varIdEfector;
			
			item.Baja = varBaja;
			
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
		public static void Update(int varIdDatoFarmaceutico,int varIdInsumo,string varCodigoOMS,int varNivelComplejidad,string varComposicion,string varContraindicaciones,string varAccionTerapeutica,bool varNecesitaReceta,int varIdEfector,bool varBaja,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			InsDatoFarmaceutico item = new InsDatoFarmaceutico();
			
				item.IdDatoFarmaceutico = varIdDatoFarmaceutico;
			
				item.IdInsumo = varIdInsumo;
			
				item.CodigoOMS = varCodigoOMS;
			
				item.NivelComplejidad = varNivelComplejidad;
			
				item.Composicion = varComposicion;
			
				item.Contraindicaciones = varContraindicaciones;
			
				item.AccionTerapeutica = varAccionTerapeutica;
			
				item.NecesitaReceta = varNecesitaReceta;
			
				item.IdEfector = varIdEfector;
			
				item.Baja = varBaja;
			
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
        
        
        public static TableSchema.TableColumn IdDatoFarmaceuticoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInsumoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoOMSColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NivelComplejidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ComposicionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ContraindicacionesColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AccionTerapeuticaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NecesitaRecetaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDatoFarmaceutico = @"idDatoFarmaceutico";
			 public static string IdInsumo = @"idInsumo";
			 public static string CodigoOMS = @"codigoOMS";
			 public static string NivelComplejidad = @"nivelComplejidad";
			 public static string Composicion = @"composicion";
			 public static string Contraindicaciones = @"contraindicaciones";
			 public static string AccionTerapeutica = @"accionTerapeutica";
			 public static string NecesitaReceta = @"necesitaReceta";
			 public static string IdEfector = @"idEfector";
			 public static string Baja = @"baja";
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
