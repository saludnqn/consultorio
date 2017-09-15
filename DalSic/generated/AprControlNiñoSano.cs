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
	/// Strongly-typed collection for the AprControlNiñoSano class.
	/// </summary>
    [Serializable]
	public partial class AprControlNiñoSanoCollection : ActiveList<AprControlNiñoSano, AprControlNiñoSanoCollection>
	{	   
		public AprControlNiñoSanoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprControlNiñoSanoCollection</returns>
		public AprControlNiñoSanoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprControlNiñoSano o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ControlNiñoSano table.
	/// </summary>
	[Serializable]
	public partial class AprControlNiñoSano : ActiveRecord<AprControlNiñoSano>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprControlNiñoSano()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprControlNiñoSano(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprControlNiñoSano(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprControlNiñoSano(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ControlNiñoSano", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
				colvarIdControlNiñoSano.DataType = DbType.Int32;
				colvarIdControlNiñoSano.MaxLength = 0;
				colvarIdControlNiñoSano.AutoIncrement = true;
				colvarIdControlNiñoSano.IsNullable = false;
				colvarIdControlNiñoSano.IsPrimaryKey = true;
				colvarIdControlNiñoSano.IsForeignKey = false;
				colvarIdControlNiñoSano.IsReadOnly = false;
				colvarIdControlNiñoSano.DefaultSetting = @"";
				colvarIdControlNiñoSano.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdControlNiñoSano);
				
				TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
				colvarIdConsulta.ColumnName = "idConsulta";
				colvarIdConsulta.DataType = DbType.Int32;
				colvarIdConsulta.MaxLength = 0;
				colvarIdConsulta.AutoIncrement = false;
				colvarIdConsulta.IsNullable = false;
				colvarIdConsulta.IsPrimaryKey = false;
				colvarIdConsulta.IsForeignKey = true;
				colvarIdConsulta.IsReadOnly = false;
				colvarIdConsulta.DefaultSetting = @"";
				
					colvarIdConsulta.ForeignKeyTableName = "CON_Consulta";
				schema.Columns.Add(colvarIdConsulta);
				
				TableSchema.TableColumn colvarIdCalendarioVisitas = new TableSchema.TableColumn(schema);
				colvarIdCalendarioVisitas.ColumnName = "idCalendarioVisitas";
				colvarIdCalendarioVisitas.DataType = DbType.Int32;
				colvarIdCalendarioVisitas.MaxLength = 0;
				colvarIdCalendarioVisitas.AutoIncrement = false;
				colvarIdCalendarioVisitas.IsNullable = true;
				colvarIdCalendarioVisitas.IsPrimaryKey = false;
				colvarIdCalendarioVisitas.IsForeignKey = true;
				colvarIdCalendarioVisitas.IsReadOnly = false;
				colvarIdCalendarioVisitas.DefaultSetting = @"";
				
					colvarIdCalendarioVisitas.ForeignKeyTableName = "APR_CalendarioVisitas";
				schema.Columns.Add(colvarIdCalendarioVisitas);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "Edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = true;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				colvarEdad.DefaultSetting = @"";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ControlNiñoSano",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdControlNiñoSano")]
		[Bindable(true)]
		public int IdControlNiñoSano 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSano); }
			set { SetColumnValue(Columns.IdControlNiñoSano, value); }
		}
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int IdConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("IdCalendarioVisitas")]
		[Bindable(true)]
		public int? IdCalendarioVisitas 
		{
			get { return GetColumnValue<int?>(Columns.IdCalendarioVisitas); }
			set { SetColumnValue(Columns.IdCalendarioVisitas, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int? Edad 
		{
			get { return GetColumnValue<int?>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
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
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprCMOtrosDatoCollection colAprCMOtrosDatos;
		public DalSic.AprCMOtrosDatoCollection AprCMOtrosDatos
		{
			get
			{
				if(colAprCMOtrosDatos == null)
				{
					colAprCMOtrosDatos = new DalSic.AprCMOtrosDatoCollection().Where(AprCMOtrosDato.Columns.IdControlNiñoSano, IdControlNiñoSano).Load();
					colAprCMOtrosDatos.ListChanged += new ListChangedEventHandler(colAprCMOtrosDatos_ListChanged);
				}
				return colAprCMOtrosDatos;			
			}
			set 
			{ 
					colAprCMOtrosDatos = value; 
					colAprCMOtrosDatos.ListChanged += new ListChangedEventHandler(colAprCMOtrosDatos_ListChanged);
			}
		}
		
		void colAprCMOtrosDatos_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprCMOtrosDatos[e.NewIndex].IdControlNiñoSano = IdControlNiñoSano;
		    }
		}
				
		private DalSic.AprCondicionesViviendaCollection colAprCondicionesViviendaRecords;
		public DalSic.AprCondicionesViviendaCollection AprCondicionesViviendaRecords
		{
			get
			{
				if(colAprCondicionesViviendaRecords == null)
				{
					colAprCondicionesViviendaRecords = new DalSic.AprCondicionesViviendaCollection().Where(AprCondicionesVivienda.Columns.IdControlNiñoSano, IdControlNiñoSano).Load();
					colAprCondicionesViviendaRecords.ListChanged += new ListChangedEventHandler(colAprCondicionesViviendaRecords_ListChanged);
				}
				return colAprCondicionesViviendaRecords;			
			}
			set 
			{ 
					colAprCondicionesViviendaRecords = value; 
					colAprCondicionesViviendaRecords.ListChanged += new ListChangedEventHandler(colAprCondicionesViviendaRecords_ListChanged);
			}
		}
		
		void colAprCondicionesViviendaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprCondicionesViviendaRecords[e.NewIndex].IdControlNiñoSano = IdControlNiñoSano;
		    }
		}
				
		private DalSic.AprControlNiñoSanoEnfermeriumCollection colAprControlNiñoSanoEnfermeria;
		public DalSic.AprControlNiñoSanoEnfermeriumCollection AprControlNiñoSanoEnfermeria
		{
			get
			{
				if(colAprControlNiñoSanoEnfermeria == null)
				{
					colAprControlNiñoSanoEnfermeria = new DalSic.AprControlNiñoSanoEnfermeriumCollection().Where(AprControlNiñoSanoEnfermerium.Columns.IdControlNiñoSano, IdControlNiñoSano).Load();
					colAprControlNiñoSanoEnfermeria.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoEnfermeria_ListChanged);
				}
				return colAprControlNiñoSanoEnfermeria;			
			}
			set 
			{ 
					colAprControlNiñoSanoEnfermeria = value; 
					colAprControlNiñoSanoEnfermeria.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoEnfermeria_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoEnfermeria_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoEnfermeria[e.NewIndex].IdControlNiñoSano = IdControlNiñoSano;
		    }
		}
				
		private DalSic.AprControlNiñoSanoConsultorioCollection colAprControlNiñoSanoConsultorioRecords;
		public DalSic.AprControlNiñoSanoConsultorioCollection AprControlNiñoSanoConsultorioRecords
		{
			get
			{
				if(colAprControlNiñoSanoConsultorioRecords == null)
				{
					colAprControlNiñoSanoConsultorioRecords = new DalSic.AprControlNiñoSanoConsultorioCollection().Where(AprControlNiñoSanoConsultorio.Columns.IdControlNiñoSano, IdControlNiñoSano).Load();
					colAprControlNiñoSanoConsultorioRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoConsultorioRecords_ListChanged);
				}
				return colAprControlNiñoSanoConsultorioRecords;			
			}
			set 
			{ 
					colAprControlNiñoSanoConsultorioRecords = value; 
					colAprControlNiñoSanoConsultorioRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoConsultorioRecords_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoConsultorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoConsultorioRecords[e.NewIndex].IdControlNiñoSano = IdControlNiñoSano;
		    }
		}
				
		private DalSic.AprControlNiñoSanoHemoglobinaCollection colAprControlNiñoSanoHemoglobinaRecords;
		public DalSic.AprControlNiñoSanoHemoglobinaCollection AprControlNiñoSanoHemoglobinaRecords
		{
			get
			{
				if(colAprControlNiñoSanoHemoglobinaRecords == null)
				{
					colAprControlNiñoSanoHemoglobinaRecords = new DalSic.AprControlNiñoSanoHemoglobinaCollection().Where(AprControlNiñoSanoHemoglobina.Columns.IdControlNiñoSano, IdControlNiñoSano).Load();
					colAprControlNiñoSanoHemoglobinaRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoHemoglobinaRecords_ListChanged);
				}
				return colAprControlNiñoSanoHemoglobinaRecords;			
			}
			set 
			{ 
					colAprControlNiñoSanoHemoglobinaRecords = value; 
					colAprControlNiñoSanoHemoglobinaRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoHemoglobinaRecords_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoHemoglobinaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoHemoglobinaRecords[e.NewIndex].IdControlNiñoSano = IdControlNiñoSano;
		    }
		}
				
		private DalSic.AprControlNiñoSanoOdontologicoCollection colAprControlNiñoSanoOdontologicoRecords;
		public DalSic.AprControlNiñoSanoOdontologicoCollection AprControlNiñoSanoOdontologicoRecords
		{
			get
			{
				if(colAprControlNiñoSanoOdontologicoRecords == null)
				{
					colAprControlNiñoSanoOdontologicoRecords = new DalSic.AprControlNiñoSanoOdontologicoCollection().Where(AprControlNiñoSanoOdontologico.Columns.IdControlNiñoSano, IdControlNiñoSano).Load();
					colAprControlNiñoSanoOdontologicoRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoOdontologicoRecords_ListChanged);
				}
				return colAprControlNiñoSanoOdontologicoRecords;			
			}
			set 
			{ 
					colAprControlNiñoSanoOdontologicoRecords = value; 
					colAprControlNiñoSanoOdontologicoRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoOdontologicoRecords_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoOdontologicoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoOdontologicoRecords[e.NewIndex].IdControlNiñoSano = IdControlNiñoSano;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprCalendarioVisita ActiveRecord object related to this AprControlNiñoSano
		/// 
		/// </summary>
		public DalSic.AprCalendarioVisita AprCalendarioVisita
		{
			get { return DalSic.AprCalendarioVisita.FetchByID(this.IdCalendarioVisitas); }
			set { SetColumnValue("idCalendarioVisitas", value.IdCalendarioVisitas); }
		}
		
		
		/// <summary>
		/// Returns a ConConsultum ActiveRecord object related to this AprControlNiñoSano
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
		public static void Insert(int varIdConsulta,int? varIdCalendarioVisitas,int? varEdad,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprControlNiñoSano item = new AprControlNiñoSano();
			
			item.IdConsulta = varIdConsulta;
			
			item.IdCalendarioVisitas = varIdCalendarioVisitas;
			
			item.Edad = varEdad;
			
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
		public static void Update(int varIdControlNiñoSano,int varIdConsulta,int? varIdCalendarioVisitas,int? varEdad,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprControlNiñoSano item = new AprControlNiñoSano();
			
				item.IdControlNiñoSano = varIdControlNiñoSano;
			
				item.IdConsulta = varIdConsulta;
			
				item.IdCalendarioVisitas = varIdCalendarioVisitas;
			
				item.Edad = varEdad;
			
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
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCalendarioVisitasColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdControlNiñoSano = @"idControlNiñoSano";
			 public static string IdConsulta = @"idConsulta";
			 public static string IdCalendarioVisitas = @"idCalendarioVisitas";
			 public static string Edad = @"Edad";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprCMOtrosDatos != null)
                {
                    foreach (DalSic.AprCMOtrosDato item in colAprCMOtrosDatos)
                    {
                        if (item.IdControlNiñoSano != IdControlNiñoSano)
                        {
                            item.IdControlNiñoSano = IdControlNiñoSano;
                        }
                    }
               }
		
                if (colAprCondicionesViviendaRecords != null)
                {
                    foreach (DalSic.AprCondicionesVivienda item in colAprCondicionesViviendaRecords)
                    {
                        if (item.IdControlNiñoSano != IdControlNiñoSano)
                        {
                            item.IdControlNiñoSano = IdControlNiñoSano;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    foreach (DalSic.AprControlNiñoSanoEnfermerium item in colAprControlNiñoSanoEnfermeria)
                    {
                        if (item.IdControlNiñoSano != IdControlNiñoSano)
                        {
                            item.IdControlNiñoSano = IdControlNiñoSano;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoConsultorioRecords != null)
                {
                    foreach (DalSic.AprControlNiñoSanoConsultorio item in colAprControlNiñoSanoConsultorioRecords)
                    {
                        if (item.IdControlNiñoSano != IdControlNiñoSano)
                        {
                            item.IdControlNiñoSano = IdControlNiñoSano;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoHemoglobinaRecords != null)
                {
                    foreach (DalSic.AprControlNiñoSanoHemoglobina item in colAprControlNiñoSanoHemoglobinaRecords)
                    {
                        if (item.IdControlNiñoSano != IdControlNiñoSano)
                        {
                            item.IdControlNiñoSano = IdControlNiñoSano;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoOdontologicoRecords != null)
                {
                    foreach (DalSic.AprControlNiñoSanoOdontologico item in colAprControlNiñoSanoOdontologicoRecords)
                    {
                        if (item.IdControlNiñoSano != IdControlNiñoSano)
                        {
                            item.IdControlNiñoSano = IdControlNiñoSano;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprCMOtrosDatos != null)
                {
                    colAprCMOtrosDatos.SaveAll();
               }
		
                if (colAprCondicionesViviendaRecords != null)
                {
                    colAprCondicionesViviendaRecords.SaveAll();
               }
		
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    colAprControlNiñoSanoEnfermeria.SaveAll();
               }
		
                if (colAprControlNiñoSanoConsultorioRecords != null)
                {
                    colAprControlNiñoSanoConsultorioRecords.SaveAll();
               }
		
                if (colAprControlNiñoSanoHemoglobinaRecords != null)
                {
                    colAprControlNiñoSanoHemoglobinaRecords.SaveAll();
               }
		
                if (colAprControlNiñoSanoOdontologicoRecords != null)
                {
                    colAprControlNiñoSanoOdontologicoRecords.SaveAll();
               }
		}
        #endregion
	}
}
