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
	/// Strongly-typed collection for the AprCalendarioVisita class.
	/// </summary>
    [Serializable]
	public partial class AprCalendarioVisitaCollection : ActiveList<AprCalendarioVisita, AprCalendarioVisitaCollection>
	{	   
		public AprCalendarioVisitaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprCalendarioVisitaCollection</returns>
		public AprCalendarioVisitaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprCalendarioVisita o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_CalendarioVisitas table.
	/// </summary>
	[Serializable]
	public partial class AprCalendarioVisita : ActiveRecord<AprCalendarioVisita>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprCalendarioVisita()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprCalendarioVisita(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprCalendarioVisita(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprCalendarioVisita(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_CalendarioVisitas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCalendarioVisitas = new TableSchema.TableColumn(schema);
				colvarIdCalendarioVisitas.ColumnName = "idCalendarioVisitas";
				colvarIdCalendarioVisitas.DataType = DbType.Int32;
				colvarIdCalendarioVisitas.MaxLength = 0;
				colvarIdCalendarioVisitas.AutoIncrement = true;
				colvarIdCalendarioVisitas.IsNullable = false;
				colvarIdCalendarioVisitas.IsPrimaryKey = true;
				colvarIdCalendarioVisitas.IsForeignKey = false;
				colvarIdCalendarioVisitas.IsReadOnly = false;
				colvarIdCalendarioVisitas.DefaultSetting = @"";
				colvarIdCalendarioVisitas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCalendarioVisitas);
				
				TableSchema.TableColumn colvarEdadSemanas = new TableSchema.TableColumn(schema);
				colvarEdadSemanas.ColumnName = "EdadSemanas";
				colvarEdadSemanas.DataType = DbType.Int32;
				colvarEdadSemanas.MaxLength = 0;
				colvarEdadSemanas.AutoIncrement = false;
				colvarEdadSemanas.IsNullable = false;
				colvarEdadSemanas.IsPrimaryKey = false;
				colvarEdadSemanas.IsForeignKey = false;
				colvarEdadSemanas.IsReadOnly = false;
				colvarEdadSemanas.DefaultSetting = @"";
				colvarEdadSemanas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadSemanas);
				
				TableSchema.TableColumn colvarNombreEdad = new TableSchema.TableColumn(schema);
				colvarNombreEdad.ColumnName = "NombreEdad";
				colvarNombreEdad.DataType = DbType.AnsiString;
				colvarNombreEdad.MaxLength = 50;
				colvarNombreEdad.AutoIncrement = false;
				colvarNombreEdad.IsNullable = true;
				colvarNombreEdad.IsPrimaryKey = false;
				colvarNombreEdad.IsForeignKey = false;
				colvarNombreEdad.IsReadOnly = false;
				colvarNombreEdad.DefaultSetting = @"";
				colvarNombreEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreEdad);
				
				TableSchema.TableColumn colvarEnfermeria = new TableSchema.TableColumn(schema);
				colvarEnfermeria.ColumnName = "Enfermeria";
				colvarEnfermeria.DataType = DbType.Boolean;
				colvarEnfermeria.MaxLength = 0;
				colvarEnfermeria.AutoIncrement = false;
				colvarEnfermeria.IsNullable = false;
				colvarEnfermeria.IsPrimaryKey = false;
				colvarEnfermeria.IsForeignKey = false;
				colvarEnfermeria.IsReadOnly = false;
				colvarEnfermeria.DefaultSetting = @"";
				colvarEnfermeria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnfermeria);
				
				TableSchema.TableColumn colvarOdontologia = new TableSchema.TableColumn(schema);
				colvarOdontologia.ColumnName = "Odontologia";
				colvarOdontologia.DataType = DbType.Boolean;
				colvarOdontologia.MaxLength = 0;
				colvarOdontologia.AutoIncrement = false;
				colvarOdontologia.IsNullable = false;
				colvarOdontologia.IsPrimaryKey = false;
				colvarOdontologia.IsForeignKey = false;
				colvarOdontologia.IsReadOnly = false;
				colvarOdontologia.DefaultSetting = @"";
				colvarOdontologia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOdontologia);
				
				TableSchema.TableColumn colvarMedico = new TableSchema.TableColumn(schema);
				colvarMedico.ColumnName = "Medico";
				colvarMedico.DataType = DbType.Boolean;
				colvarMedico.MaxLength = 0;
				colvarMedico.AutoIncrement = false;
				colvarMedico.IsNullable = false;
				colvarMedico.IsPrimaryKey = false;
				colvarMedico.IsForeignKey = false;
				colvarMedico.IsReadOnly = false;
				colvarMedico.DefaultSetting = @"";
				colvarMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedico);
				
				TableSchema.TableColumn colvarHemoglobina = new TableSchema.TableColumn(schema);
				colvarHemoglobina.ColumnName = "Hemoglobina";
				colvarHemoglobina.DataType = DbType.Boolean;
				colvarHemoglobina.MaxLength = 0;
				colvarHemoglobina.AutoIncrement = false;
				colvarHemoglobina.IsNullable = false;
				colvarHemoglobina.IsPrimaryKey = false;
				colvarHemoglobina.IsForeignKey = false;
				colvarHemoglobina.IsReadOnly = false;
				colvarHemoglobina.DefaultSetting = @"";
				colvarHemoglobina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHemoglobina);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_CalendarioVisitas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCalendarioVisitas")]
		[Bindable(true)]
		public int IdCalendarioVisitas 
		{
			get { return GetColumnValue<int>(Columns.IdCalendarioVisitas); }
			set { SetColumnValue(Columns.IdCalendarioVisitas, value); }
		}
		  
		[XmlAttribute("EdadSemanas")]
		[Bindable(true)]
		public int EdadSemanas 
		{
			get { return GetColumnValue<int>(Columns.EdadSemanas); }
			set { SetColumnValue(Columns.EdadSemanas, value); }
		}
		  
		[XmlAttribute("NombreEdad")]
		[Bindable(true)]
		public string NombreEdad 
		{
			get { return GetColumnValue<string>(Columns.NombreEdad); }
			set { SetColumnValue(Columns.NombreEdad, value); }
		}
		  
		[XmlAttribute("Enfermeria")]
		[Bindable(true)]
		public bool Enfermeria 
		{
			get { return GetColumnValue<bool>(Columns.Enfermeria); }
			set { SetColumnValue(Columns.Enfermeria, value); }
		}
		  
		[XmlAttribute("Odontologia")]
		[Bindable(true)]
		public bool Odontologia 
		{
			get { return GetColumnValue<bool>(Columns.Odontologia); }
			set { SetColumnValue(Columns.Odontologia, value); }
		}
		  
		[XmlAttribute("Medico")]
		[Bindable(true)]
		public bool Medico 
		{
			get { return GetColumnValue<bool>(Columns.Medico); }
			set { SetColumnValue(Columns.Medico, value); }
		}
		  
		[XmlAttribute("Hemoglobina")]
		[Bindable(true)]
		public bool Hemoglobina 
		{
			get { return GetColumnValue<bool>(Columns.Hemoglobina); }
			set { SetColumnValue(Columns.Hemoglobina, value); }
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
        
				
		private DalSic.AprAlertaControlMenorCollection colAprAlertaControlMenorRecords;
		public DalSic.AprAlertaControlMenorCollection AprAlertaControlMenorRecords
		{
			get
			{
				if(colAprAlertaControlMenorRecords == null)
				{
					colAprAlertaControlMenorRecords = new DalSic.AprAlertaControlMenorCollection().Where(AprAlertaControlMenor.Columns.IdCalendarioVisitas, IdCalendarioVisitas).Load();
					colAprAlertaControlMenorRecords.ListChanged += new ListChangedEventHandler(colAprAlertaControlMenorRecords_ListChanged);
				}
				return colAprAlertaControlMenorRecords;			
			}
			set 
			{ 
					colAprAlertaControlMenorRecords = value; 
					colAprAlertaControlMenorRecords.ListChanged += new ListChangedEventHandler(colAprAlertaControlMenorRecords_ListChanged);
			}
		}
		
		void colAprAlertaControlMenorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAlertaControlMenorRecords[e.NewIndex].IdCalendarioVisitas = IdCalendarioVisitas;
		    }
		}
				
		private DalSic.AprControlNiñoSanoCollection colAprControlNiñoSanoRecords;
		public DalSic.AprControlNiñoSanoCollection AprControlNiñoSanoRecords
		{
			get
			{
				if(colAprControlNiñoSanoRecords == null)
				{
					colAprControlNiñoSanoRecords = new DalSic.AprControlNiñoSanoCollection().Where(AprControlNiñoSano.Columns.IdCalendarioVisitas, IdCalendarioVisitas).Load();
					colAprControlNiñoSanoRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoRecords_ListChanged);
				}
				return colAprControlNiñoSanoRecords;			
			}
			set 
			{ 
					colAprControlNiñoSanoRecords = value; 
					colAprControlNiñoSanoRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoRecords_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoRecords[e.NewIndex].IdCalendarioVisitas = IdCalendarioVisitas;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varEdadSemanas,string varNombreEdad,bool varEnfermeria,bool varOdontologia,bool varMedico,bool varHemoglobina,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprCalendarioVisita item = new AprCalendarioVisita();
			
			item.EdadSemanas = varEdadSemanas;
			
			item.NombreEdad = varNombreEdad;
			
			item.Enfermeria = varEnfermeria;
			
			item.Odontologia = varOdontologia;
			
			item.Medico = varMedico;
			
			item.Hemoglobina = varHemoglobina;
			
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
		public static void Update(int varIdCalendarioVisitas,int varEdadSemanas,string varNombreEdad,bool varEnfermeria,bool varOdontologia,bool varMedico,bool varHemoglobina,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprCalendarioVisita item = new AprCalendarioVisita();
			
				item.IdCalendarioVisitas = varIdCalendarioVisitas;
			
				item.EdadSemanas = varEdadSemanas;
			
				item.NombreEdad = varNombreEdad;
			
				item.Enfermeria = varEnfermeria;
			
				item.Odontologia = varOdontologia;
			
				item.Medico = varMedico;
			
				item.Hemoglobina = varHemoglobina;
			
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
        
        
        public static TableSchema.TableColumn IdCalendarioVisitasColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadSemanasColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreEdadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EnfermeriaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn OdontologiaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn HemoglobinaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCalendarioVisitas = @"idCalendarioVisitas";
			 public static string EdadSemanas = @"EdadSemanas";
			 public static string NombreEdad = @"NombreEdad";
			 public static string Enfermeria = @"Enfermeria";
			 public static string Odontologia = @"Odontologia";
			 public static string Medico = @"Medico";
			 public static string Hemoglobina = @"Hemoglobina";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprAlertaControlMenorRecords != null)
                {
                    foreach (DalSic.AprAlertaControlMenor item in colAprAlertaControlMenorRecords)
                    {
                        if (item.IdCalendarioVisitas != IdCalendarioVisitas)
                        {
                            item.IdCalendarioVisitas = IdCalendarioVisitas;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoRecords != null)
                {
                    foreach (DalSic.AprControlNiñoSano item in colAprControlNiñoSanoRecords)
                    {
                        if (item.IdCalendarioVisitas != IdCalendarioVisitas)
                        {
                            item.IdCalendarioVisitas = IdCalendarioVisitas;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprAlertaControlMenorRecords != null)
                {
                    colAprAlertaControlMenorRecords.SaveAll();
               }
		
                if (colAprControlNiñoSanoRecords != null)
                {
                    colAprControlNiñoSanoRecords.SaveAll();
               }
		}
        #endregion
	}
}
