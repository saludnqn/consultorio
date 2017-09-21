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
	/// Strongly-typed collection for the AprCalendarioVacuna class.
	/// </summary>
    [Serializable]
	public partial class AprCalendarioVacunaCollection : ActiveList<AprCalendarioVacuna, AprCalendarioVacunaCollection>
	{	   
		public AprCalendarioVacunaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprCalendarioVacunaCollection</returns>
		public AprCalendarioVacunaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprCalendarioVacuna o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_CalendarioVacuna table.
	/// </summary>
	[Serializable]
	public partial class AprCalendarioVacuna : ActiveRecord<AprCalendarioVacuna>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprCalendarioVacuna()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprCalendarioVacuna(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprCalendarioVacuna(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprCalendarioVacuna(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_CalendarioVacuna", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCalendarioVacuna = new TableSchema.TableColumn(schema);
				colvarIdCalendarioVacuna.ColumnName = "idCalendarioVacuna";
				colvarIdCalendarioVacuna.DataType = DbType.Int32;
				colvarIdCalendarioVacuna.MaxLength = 0;
				colvarIdCalendarioVacuna.AutoIncrement = true;
				colvarIdCalendarioVacuna.IsNullable = false;
				colvarIdCalendarioVacuna.IsPrimaryKey = true;
				colvarIdCalendarioVacuna.IsForeignKey = false;
				colvarIdCalendarioVacuna.IsReadOnly = false;
				colvarIdCalendarioVacuna.DefaultSetting = @"";
				colvarIdCalendarioVacuna.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCalendarioVacuna);
				
				TableSchema.TableColumn colvarIdVacuna = new TableSchema.TableColumn(schema);
				colvarIdVacuna.ColumnName = "idVacuna";
				colvarIdVacuna.DataType = DbType.Int32;
				colvarIdVacuna.MaxLength = 0;
				colvarIdVacuna.AutoIncrement = false;
				colvarIdVacuna.IsNullable = false;
				colvarIdVacuna.IsPrimaryKey = false;
				colvarIdVacuna.IsForeignKey = true;
				colvarIdVacuna.IsReadOnly = false;
				colvarIdVacuna.DefaultSetting = @"";
				
					colvarIdVacuna.ForeignKeyTableName = "Sys_Medicamento";
				schema.Columns.Add(colvarIdVacuna);
				
				TableSchema.TableColumn colvarNombreVacuna = new TableSchema.TableColumn(schema);
				colvarNombreVacuna.ColumnName = "NombreVacuna";
				colvarNombreVacuna.DataType = DbType.AnsiString;
				colvarNombreVacuna.MaxLength = 50;
				colvarNombreVacuna.AutoIncrement = false;
				colvarNombreVacuna.IsNullable = false;
				colvarNombreVacuna.IsPrimaryKey = false;
				colvarNombreVacuna.IsForeignKey = false;
				colvarNombreVacuna.IsReadOnly = false;
				colvarNombreVacuna.DefaultSetting = @"";
				colvarNombreVacuna.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreVacuna);
				
				TableSchema.TableColumn colvarIdNumeroDosis = new TableSchema.TableColumn(schema);
				colvarIdNumeroDosis.ColumnName = "idNumeroDosis";
				colvarIdNumeroDosis.DataType = DbType.Int32;
				colvarIdNumeroDosis.MaxLength = 0;
				colvarIdNumeroDosis.AutoIncrement = false;
				colvarIdNumeroDosis.IsNullable = false;
				colvarIdNumeroDosis.IsPrimaryKey = false;
				colvarIdNumeroDosis.IsForeignKey = true;
				colvarIdNumeroDosis.IsReadOnly = false;
				colvarIdNumeroDosis.DefaultSetting = @"";
				
					colvarIdNumeroDosis.ForeignKeyTableName = "APR_NumeroDosis";
				schema.Columns.Add(colvarIdNumeroDosis);
				
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
				colvarNombreEdad.IsNullable = false;
				colvarNombreEdad.IsPrimaryKey = false;
				colvarNombreEdad.IsForeignKey = false;
				colvarNombreEdad.IsReadOnly = false;
				colvarNombreEdad.DefaultSetting = @"";
				colvarNombreEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreEdad);
				
				TableSchema.TableColumn colvarObligatoria = new TableSchema.TableColumn(schema);
				colvarObligatoria.ColumnName = "Obligatoria";
				colvarObligatoria.DataType = DbType.Boolean;
				colvarObligatoria.MaxLength = 0;
				colvarObligatoria.AutoIncrement = false;
				colvarObligatoria.IsNullable = false;
				colvarObligatoria.IsPrimaryKey = false;
				colvarObligatoria.IsForeignKey = false;
				colvarObligatoria.IsReadOnly = false;
				colvarObligatoria.DefaultSetting = @"";
				colvarObligatoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObligatoria);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_CalendarioVacuna",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCalendarioVacuna")]
		[Bindable(true)]
		public int IdCalendarioVacuna 
		{
			get { return GetColumnValue<int>(Columns.IdCalendarioVacuna); }
			set { SetColumnValue(Columns.IdCalendarioVacuna, value); }
		}
		  
		[XmlAttribute("IdVacuna")]
		[Bindable(true)]
		public int IdVacuna 
		{
			get { return GetColumnValue<int>(Columns.IdVacuna); }
			set { SetColumnValue(Columns.IdVacuna, value); }
		}
		  
		[XmlAttribute("NombreVacuna")]
		[Bindable(true)]
		public string NombreVacuna 
		{
			get { return GetColumnValue<string>(Columns.NombreVacuna); }
			set { SetColumnValue(Columns.NombreVacuna, value); }
		}
		  
		[XmlAttribute("IdNumeroDosis")]
		[Bindable(true)]
		public int IdNumeroDosis 
		{
			get { return GetColumnValue<int>(Columns.IdNumeroDosis); }
			set { SetColumnValue(Columns.IdNumeroDosis, value); }
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
		  
		[XmlAttribute("Obligatoria")]
		[Bindable(true)]
		public bool Obligatoria 
		{
			get { return GetColumnValue<bool>(Columns.Obligatoria); }
			set { SetColumnValue(Columns.Obligatoria, value); }
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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprNumeroDosi ActiveRecord object related to this AprCalendarioVacuna
		/// 
		/// </summary>
		public DalSic.AprNumeroDosi AprNumeroDosi
		{
			get { return DalSic.AprNumeroDosi.FetchByID(this.IdNumeroDosis); }
			set { SetColumnValue("idNumeroDosis", value.IdNumeroDosis); }
		}
		
		
		/// <summary>
		/// Returns a SysMedicamento ActiveRecord object related to this AprCalendarioVacuna
		/// 
		/// </summary>
		public DalSic.SysMedicamento SysMedicamento
		{
			get { return DalSic.SysMedicamento.FetchByID(this.IdVacuna); }
			set { SetColumnValue("idVacuna", value.IdMedicamento); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdVacuna,string varNombreVacuna,int varIdNumeroDosis,int varEdadSemanas,string varNombreEdad,bool varObligatoria,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprCalendarioVacuna item = new AprCalendarioVacuna();
			
			item.IdVacuna = varIdVacuna;
			
			item.NombreVacuna = varNombreVacuna;
			
			item.IdNumeroDosis = varIdNumeroDosis;
			
			item.EdadSemanas = varEdadSemanas;
			
			item.NombreEdad = varNombreEdad;
			
			item.Obligatoria = varObligatoria;
			
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
		public static void Update(int varIdCalendarioVacuna,int varIdVacuna,string varNombreVacuna,int varIdNumeroDosis,int varEdadSemanas,string varNombreEdad,bool varObligatoria,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprCalendarioVacuna item = new AprCalendarioVacuna();
			
				item.IdCalendarioVacuna = varIdCalendarioVacuna;
			
				item.IdVacuna = varIdVacuna;
			
				item.NombreVacuna = varNombreVacuna;
			
				item.IdNumeroDosis = varIdNumeroDosis;
			
				item.EdadSemanas = varEdadSemanas;
			
				item.NombreEdad = varNombreEdad;
			
				item.Obligatoria = varObligatoria;
			
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
        
        
        public static TableSchema.TableColumn IdCalendarioVacunaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVacunaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreVacunaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNumeroDosisColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadSemanasColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreEdadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ObligatoriaColumn
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
			 public static string IdCalendarioVacuna = @"idCalendarioVacuna";
			 public static string IdVacuna = @"idVacuna";
			 public static string NombreVacuna = @"NombreVacuna";
			 public static string IdNumeroDosis = @"idNumeroDosis";
			 public static string EdadSemanas = @"EdadSemanas";
			 public static string NombreEdad = @"NombreEdad";
			 public static string Obligatoria = @"Obligatoria";
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
