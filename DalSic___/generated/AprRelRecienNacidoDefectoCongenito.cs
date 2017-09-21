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
	/// Strongly-typed collection for the AprRelRecienNacidoDefectoCongenito class.
	/// </summary>
    [Serializable]
	public partial class AprRelRecienNacidoDefectoCongenitoCollection : ActiveList<AprRelRecienNacidoDefectoCongenito, AprRelRecienNacidoDefectoCongenitoCollection>
	{	   
		public AprRelRecienNacidoDefectoCongenitoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprRelRecienNacidoDefectoCongenitoCollection</returns>
		public AprRelRecienNacidoDefectoCongenitoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprRelRecienNacidoDefectoCongenito o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_RelRecienNacidoDefectoCongenito table.
	/// </summary>
	[Serializable]
	public partial class AprRelRecienNacidoDefectoCongenito : ActiveRecord<AprRelRecienNacidoDefectoCongenito>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprRelRecienNacidoDefectoCongenito()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprRelRecienNacidoDefectoCongenito(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprRelRecienNacidoDefectoCongenito(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprRelRecienNacidoDefectoCongenito(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_RelRecienNacidoDefectoCongenito", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdRecienNacido = new TableSchema.TableColumn(schema);
				colvarIdRecienNacido.ColumnName = "idRecienNacido";
				colvarIdRecienNacido.DataType = DbType.Int32;
				colvarIdRecienNacido.MaxLength = 0;
				colvarIdRecienNacido.AutoIncrement = false;
				colvarIdRecienNacido.IsNullable = false;
				colvarIdRecienNacido.IsPrimaryKey = false;
				colvarIdRecienNacido.IsForeignKey = true;
				colvarIdRecienNacido.IsReadOnly = false;
				colvarIdRecienNacido.DefaultSetting = @"";
				
					colvarIdRecienNacido.ForeignKeyTableName = "APR_RecienNacido";
				schema.Columns.Add(colvarIdRecienNacido);
				
				TableSchema.TableColumn colvarIdDefectoCongenito = new TableSchema.TableColumn(schema);
				colvarIdDefectoCongenito.ColumnName = "idDefectoCongenito";
				colvarIdDefectoCongenito.DataType = DbType.Int32;
				colvarIdDefectoCongenito.MaxLength = 0;
				colvarIdDefectoCongenito.AutoIncrement = false;
				colvarIdDefectoCongenito.IsNullable = false;
				colvarIdDefectoCongenito.IsPrimaryKey = false;
				colvarIdDefectoCongenito.IsForeignKey = true;
				colvarIdDefectoCongenito.IsReadOnly = false;
				colvarIdDefectoCongenito.DefaultSetting = @"";
				
					colvarIdDefectoCongenito.ForeignKeyTableName = "APR_DefectoCongenito";
				schema.Columns.Add(colvarIdDefectoCongenito);
				
				TableSchema.TableColumn colvarDefectoMayor = new TableSchema.TableColumn(schema);
				colvarDefectoMayor.ColumnName = "DefectoMayor";
				colvarDefectoMayor.DataType = DbType.Boolean;
				colvarDefectoMayor.MaxLength = 0;
				colvarDefectoMayor.AutoIncrement = false;
				colvarDefectoMayor.IsNullable = true;
				colvarDefectoMayor.IsPrimaryKey = false;
				colvarDefectoMayor.IsForeignKey = false;
				colvarDefectoMayor.IsReadOnly = false;
				colvarDefectoMayor.DefaultSetting = @"";
				colvarDefectoMayor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDefectoMayor);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_RelRecienNacidoDefectoCongenito",schema);
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
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdRecienNacido")]
		[Bindable(true)]
		public int IdRecienNacido 
		{
			get { return GetColumnValue<int>(Columns.IdRecienNacido); }
			set { SetColumnValue(Columns.IdRecienNacido, value); }
		}
		  
		[XmlAttribute("IdDefectoCongenito")]
		[Bindable(true)]
		public int IdDefectoCongenito 
		{
			get { return GetColumnValue<int>(Columns.IdDefectoCongenito); }
			set { SetColumnValue(Columns.IdDefectoCongenito, value); }
		}
		  
		[XmlAttribute("DefectoMayor")]
		[Bindable(true)]
		public bool? DefectoMayor 
		{
			get { return GetColumnValue<bool?>(Columns.DefectoMayor); }
			set { SetColumnValue(Columns.DefectoMayor, value); }
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
		/// Returns a AprRecienNacido ActiveRecord object related to this AprRelRecienNacidoDefectoCongenito
		/// 
		/// </summary>
		public DalSic.AprRecienNacido AprRecienNacido
		{
			get { return DalSic.AprRecienNacido.FetchByID(this.IdRecienNacido); }
			set { SetColumnValue("idRecienNacido", value.IdRecienNacido); }
		}
		
		
		/// <summary>
		/// Returns a AprDefectoCongenito ActiveRecord object related to this AprRelRecienNacidoDefectoCongenito
		/// 
		/// </summary>
		public DalSic.AprDefectoCongenito AprDefectoCongenito
		{
			get { return DalSic.AprDefectoCongenito.FetchByID(this.IdDefectoCongenito); }
			set { SetColumnValue("idDefectoCongenito", value.IdDefectoCongenito); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdRecienNacido,int varIdDefectoCongenito,bool? varDefectoMayor,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprRelRecienNacidoDefectoCongenito item = new AprRelRecienNacidoDefectoCongenito();
			
			item.IdEfector = varIdEfector;
			
			item.IdRecienNacido = varIdRecienNacido;
			
			item.IdDefectoCongenito = varIdDefectoCongenito;
			
			item.DefectoMayor = varDefectoMayor;
			
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
		public static void Update(int varIdRelacion,int varIdEfector,int varIdRecienNacido,int varIdDefectoCongenito,bool? varDefectoMayor,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprRelRecienNacidoDefectoCongenito item = new AprRelRecienNacidoDefectoCongenito();
			
				item.IdRelacion = varIdRelacion;
			
				item.IdEfector = varIdEfector;
			
				item.IdRecienNacido = varIdRecienNacido;
			
				item.IdDefectoCongenito = varIdDefectoCongenito;
			
				item.DefectoMayor = varDefectoMayor;
			
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
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdRecienNacidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDefectoCongenitoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DefectoMayorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelacion = @"idRelacion";
			 public static string IdEfector = @"idEfector";
			 public static string IdRecienNacido = @"idRecienNacido";
			 public static string IdDefectoCongenito = @"idDefectoCongenito";
			 public static string DefectoMayor = @"DefectoMayor";
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
