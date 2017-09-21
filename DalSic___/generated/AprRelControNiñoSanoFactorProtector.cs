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
	/// Strongly-typed collection for the AprRelControNiñoSanoFactorProtector class.
	/// </summary>
    [Serializable]
	public partial class AprRelControNiñoSanoFactorProtectorCollection : ActiveList<AprRelControNiñoSanoFactorProtector, AprRelControNiñoSanoFactorProtectorCollection>
	{	   
		public AprRelControNiñoSanoFactorProtectorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprRelControNiñoSanoFactorProtectorCollection</returns>
		public AprRelControNiñoSanoFactorProtectorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprRelControNiñoSanoFactorProtector o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_RelControNiñoSanoFactorProtector table.
	/// </summary>
	[Serializable]
	public partial class AprRelControNiñoSanoFactorProtector : ActiveRecord<AprRelControNiñoSanoFactorProtector>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprRelControNiñoSanoFactorProtector()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprRelControNiñoSanoFactorProtector(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprRelControNiñoSanoFactorProtector(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprRelControNiñoSanoFactorProtector(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_RelControNiñoSanoFactorProtector", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelacion = new TableSchema.TableColumn(schema);
				colvarIdRelacion.ColumnName = "idRelacion";
				colvarIdRelacion.DataType = DbType.Int32;
				colvarIdRelacion.MaxLength = 0;
				colvarIdRelacion.AutoIncrement = true;
				colvarIdRelacion.IsNullable = false;
				colvarIdRelacion.IsPrimaryKey = true;
				colvarIdRelacion.IsForeignKey = false;
				colvarIdRelacion.IsReadOnly = false;
				colvarIdRelacion.DefaultSetting = @"";
				colvarIdRelacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelacion);
				
				TableSchema.TableColumn colvarIdControlNiñoSanoConsultorio = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSanoConsultorio.ColumnName = "idControlNiñoSanoConsultorio";
				colvarIdControlNiñoSanoConsultorio.DataType = DbType.Int32;
				colvarIdControlNiñoSanoConsultorio.MaxLength = 0;
				colvarIdControlNiñoSanoConsultorio.AutoIncrement = false;
				colvarIdControlNiñoSanoConsultorio.IsNullable = false;
				colvarIdControlNiñoSanoConsultorio.IsPrimaryKey = false;
				colvarIdControlNiñoSanoConsultorio.IsForeignKey = true;
				colvarIdControlNiñoSanoConsultorio.IsReadOnly = false;
				colvarIdControlNiñoSanoConsultorio.DefaultSetting = @"";
				
					colvarIdControlNiñoSanoConsultorio.ForeignKeyTableName = "APR_ControlNiñoSanoConsultorio";
				schema.Columns.Add(colvarIdControlNiñoSanoConsultorio);
				
				TableSchema.TableColumn colvarIdFactorProtector = new TableSchema.TableColumn(schema);
				colvarIdFactorProtector.ColumnName = "idFactorProtector";
				colvarIdFactorProtector.DataType = DbType.Int32;
				colvarIdFactorProtector.MaxLength = 0;
				colvarIdFactorProtector.AutoIncrement = false;
				colvarIdFactorProtector.IsNullable = false;
				colvarIdFactorProtector.IsPrimaryKey = false;
				colvarIdFactorProtector.IsForeignKey = true;
				colvarIdFactorProtector.IsReadOnly = false;
				colvarIdFactorProtector.DefaultSetting = @"";
				
					colvarIdFactorProtector.ForeignKeyTableName = "APR_FactorProtector";
				schema.Columns.Add(colvarIdFactorProtector);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "Observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 2147483647;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_RelControNiñoSanoFactorProtector",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelacion")]
		[Bindable(true)]
		public int IdRelacion 
		{
			get { return GetColumnValue<int>(Columns.IdRelacion); }
			set { SetColumnValue(Columns.IdRelacion, value); }
		}
		  
		[XmlAttribute("IdControlNiñoSanoConsultorio")]
		[Bindable(true)]
		public int IdControlNiñoSanoConsultorio 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSanoConsultorio); }
			set { SetColumnValue(Columns.IdControlNiñoSanoConsultorio, value); }
		}
		  
		[XmlAttribute("IdFactorProtector")]
		[Bindable(true)]
		public int IdFactorProtector 
		{
			get { return GetColumnValue<int>(Columns.IdFactorProtector); }
			set { SetColumnValue(Columns.IdFactorProtector, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
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
		/// Returns a AprControlNiñoSanoConsultorio ActiveRecord object related to this AprRelControNiñoSanoFactorProtector
		/// 
		/// </summary>
		public DalSic.AprControlNiñoSanoConsultorio AprControlNiñoSanoConsultorio
		{
			get { return DalSic.AprControlNiñoSanoConsultorio.FetchByID(this.IdControlNiñoSanoConsultorio); }
			set { SetColumnValue("idControlNiñoSanoConsultorio", value.IdControlNiñoSanoConsultorio); }
		}
		
		
		/// <summary>
		/// Returns a AprFactorProtector ActiveRecord object related to this AprRelControNiñoSanoFactorProtector
		/// 
		/// </summary>
		public DalSic.AprFactorProtector AprFactorProtector
		{
			get { return DalSic.AprFactorProtector.FetchByID(this.IdFactorProtector); }
			set { SetColumnValue("idFactorProtector", value.IdFactorProtector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdControlNiñoSanoConsultorio,int varIdFactorProtector,string varObservaciones,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprRelControNiñoSanoFactorProtector item = new AprRelControNiñoSanoFactorProtector();
			
			item.IdControlNiñoSanoConsultorio = varIdControlNiñoSanoConsultorio;
			
			item.IdFactorProtector = varIdFactorProtector;
			
			item.Observaciones = varObservaciones;
			
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
		public static void Update(int varIdRelacion,int varIdControlNiñoSanoConsultorio,int varIdFactorProtector,string varObservaciones,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprRelControNiñoSanoFactorProtector item = new AprRelControNiñoSanoFactorProtector();
			
				item.IdRelacion = varIdRelacion;
			
				item.IdControlNiñoSanoConsultorio = varIdControlNiñoSanoConsultorio;
			
				item.IdFactorProtector = varIdFactorProtector;
			
				item.Observaciones = varObservaciones;
			
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
        
        
        public static TableSchema.TableColumn IdRelacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoConsultorioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFactorProtectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
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
			 public static string IdRelacion = @"idRelacion";
			 public static string IdControlNiñoSanoConsultorio = @"idControlNiñoSanoConsultorio";
			 public static string IdFactorProtector = @"idFactorProtector";
			 public static string Observaciones = @"Observaciones";
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
