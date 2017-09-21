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
	/// Strongly-typed collection for the AprPercentilesPesoEstatura class.
	/// </summary>
    [Serializable]
	public partial class AprPercentilesPesoEstaturaCollection : ActiveList<AprPercentilesPesoEstatura, AprPercentilesPesoEstaturaCollection>
	{	   
		public AprPercentilesPesoEstaturaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprPercentilesPesoEstaturaCollection</returns>
		public AprPercentilesPesoEstaturaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprPercentilesPesoEstatura o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_PercentilesPesoEstatura table.
	/// </summary>
	[Serializable]
	public partial class AprPercentilesPesoEstatura : ActiveRecord<AprPercentilesPesoEstatura>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprPercentilesPesoEstatura()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprPercentilesPesoEstatura(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprPercentilesPesoEstatura(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprPercentilesPesoEstatura(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_PercentilesPesoEstatura", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "Sexo";
				colvarSexo.DataType = DbType.Int32;
				colvarSexo.MaxLength = 0;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = false;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarEstatura = new TableSchema.TableColumn(schema);
				colvarEstatura.ColumnName = "Estatura";
				colvarEstatura.DataType = DbType.Decimal;
				colvarEstatura.MaxLength = 0;
				colvarEstatura.AutoIncrement = false;
				colvarEstatura.IsNullable = false;
				colvarEstatura.IsPrimaryKey = false;
				colvarEstatura.IsForeignKey = false;
				colvarEstatura.IsReadOnly = false;
				colvarEstatura.DefaultSetting = @"";
				colvarEstatura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstatura);
				
				TableSchema.TableColumn colvarP1 = new TableSchema.TableColumn(schema);
				colvarP1.ColumnName = "P1";
				colvarP1.DataType = DbType.Decimal;
				colvarP1.MaxLength = 0;
				colvarP1.AutoIncrement = false;
				colvarP1.IsNullable = false;
				colvarP1.IsPrimaryKey = false;
				colvarP1.IsForeignKey = false;
				colvarP1.IsReadOnly = false;
				colvarP1.DefaultSetting = @"";
				colvarP1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP1);
				
				TableSchema.TableColumn colvarP3 = new TableSchema.TableColumn(schema);
				colvarP3.ColumnName = "P3";
				colvarP3.DataType = DbType.Decimal;
				colvarP3.MaxLength = 0;
				colvarP3.AutoIncrement = false;
				colvarP3.IsNullable = false;
				colvarP3.IsPrimaryKey = false;
				colvarP3.IsForeignKey = false;
				colvarP3.IsReadOnly = false;
				colvarP3.DefaultSetting = @"";
				colvarP3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP3);
				
				TableSchema.TableColumn colvarP15 = new TableSchema.TableColumn(schema);
				colvarP15.ColumnName = "P15";
				colvarP15.DataType = DbType.Decimal;
				colvarP15.MaxLength = 0;
				colvarP15.AutoIncrement = false;
				colvarP15.IsNullable = false;
				colvarP15.IsPrimaryKey = false;
				colvarP15.IsForeignKey = false;
				colvarP15.IsReadOnly = false;
				colvarP15.DefaultSetting = @"";
				colvarP15.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP15);
				
				TableSchema.TableColumn colvarP50 = new TableSchema.TableColumn(schema);
				colvarP50.ColumnName = "P50";
				colvarP50.DataType = DbType.Decimal;
				colvarP50.MaxLength = 0;
				colvarP50.AutoIncrement = false;
				colvarP50.IsNullable = false;
				colvarP50.IsPrimaryKey = false;
				colvarP50.IsForeignKey = false;
				colvarP50.IsReadOnly = false;
				colvarP50.DefaultSetting = @"";
				colvarP50.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP50);
				
				TableSchema.TableColumn colvarP85 = new TableSchema.TableColumn(schema);
				colvarP85.ColumnName = "P85";
				colvarP85.DataType = DbType.Decimal;
				colvarP85.MaxLength = 0;
				colvarP85.AutoIncrement = false;
				colvarP85.IsNullable = false;
				colvarP85.IsPrimaryKey = false;
				colvarP85.IsForeignKey = false;
				colvarP85.IsReadOnly = false;
				colvarP85.DefaultSetting = @"";
				colvarP85.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP85);
				
				TableSchema.TableColumn colvarP97 = new TableSchema.TableColumn(schema);
				colvarP97.ColumnName = "P97";
				colvarP97.DataType = DbType.Decimal;
				colvarP97.MaxLength = 0;
				colvarP97.AutoIncrement = false;
				colvarP97.IsNullable = false;
				colvarP97.IsPrimaryKey = false;
				colvarP97.IsForeignKey = false;
				colvarP97.IsReadOnly = false;
				colvarP97.DefaultSetting = @"";
				colvarP97.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP97);
				
				TableSchema.TableColumn colvarP99 = new TableSchema.TableColumn(schema);
				colvarP99.ColumnName = "P99";
				colvarP99.DataType = DbType.Decimal;
				colvarP99.MaxLength = 0;
				colvarP99.AutoIncrement = false;
				colvarP99.IsNullable = false;
				colvarP99.IsPrimaryKey = false;
				colvarP99.IsForeignKey = false;
				colvarP99.IsReadOnly = false;
				colvarP99.DefaultSetting = @"";
				colvarP99.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP99);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_PercentilesPesoEstatura",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public int Sexo 
		{
			get { return GetColumnValue<int>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("Estatura")]
		[Bindable(true)]
		public decimal Estatura 
		{
			get { return GetColumnValue<decimal>(Columns.Estatura); }
			set { SetColumnValue(Columns.Estatura, value); }
		}
		  
		[XmlAttribute("P1")]
		[Bindable(true)]
		public decimal P1 
		{
			get { return GetColumnValue<decimal>(Columns.P1); }
			set { SetColumnValue(Columns.P1, value); }
		}
		  
		[XmlAttribute("P3")]
		[Bindable(true)]
		public decimal P3 
		{
			get { return GetColumnValue<decimal>(Columns.P3); }
			set { SetColumnValue(Columns.P3, value); }
		}
		  
		[XmlAttribute("P15")]
		[Bindable(true)]
		public decimal P15 
		{
			get { return GetColumnValue<decimal>(Columns.P15); }
			set { SetColumnValue(Columns.P15, value); }
		}
		  
		[XmlAttribute("P50")]
		[Bindable(true)]
		public decimal P50 
		{
			get { return GetColumnValue<decimal>(Columns.P50); }
			set { SetColumnValue(Columns.P50, value); }
		}
		  
		[XmlAttribute("P85")]
		[Bindable(true)]
		public decimal P85 
		{
			get { return GetColumnValue<decimal>(Columns.P85); }
			set { SetColumnValue(Columns.P85, value); }
		}
		  
		[XmlAttribute("P97")]
		[Bindable(true)]
		public decimal P97 
		{
			get { return GetColumnValue<decimal>(Columns.P97); }
			set { SetColumnValue(Columns.P97, value); }
		}
		  
		[XmlAttribute("P99")]
		[Bindable(true)]
		public decimal P99 
		{
			get { return GetColumnValue<decimal>(Columns.P99); }
			set { SetColumnValue(Columns.P99, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSexo,decimal varEstatura,decimal varP1,decimal varP3,decimal varP15,decimal varP50,decimal varP85,decimal varP97,decimal varP99)
		{
			AprPercentilesPesoEstatura item = new AprPercentilesPesoEstatura();
			
			item.Sexo = varSexo;
			
			item.Estatura = varEstatura;
			
			item.P1 = varP1;
			
			item.P3 = varP3;
			
			item.P15 = varP15;
			
			item.P50 = varP50;
			
			item.P85 = varP85;
			
			item.P97 = varP97;
			
			item.P99 = varP99;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varSexo,decimal varEstatura,decimal varP1,decimal varP3,decimal varP15,decimal varP50,decimal varP85,decimal varP97,decimal varP99)
		{
			AprPercentilesPesoEstatura item = new AprPercentilesPesoEstatura();
			
				item.Id = varId;
			
				item.Sexo = varSexo;
			
				item.Estatura = varEstatura;
			
				item.P1 = varP1;
			
				item.P3 = varP3;
			
				item.P15 = varP15;
			
				item.P50 = varP50;
			
				item.P85 = varP85;
			
				item.P97 = varP97;
			
				item.P99 = varP99;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EstaturaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn P1Column
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn P3Column
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn P15Column
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn P50Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn P85Column
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn P97Column
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn P99Column
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Sexo = @"Sexo";
			 public static string Estatura = @"Estatura";
			 public static string P1 = @"P1";
			 public static string P3 = @"P3";
			 public static string P15 = @"P15";
			 public static string P50 = @"P50";
			 public static string P85 = @"P85";
			 public static string P97 = @"P97";
			 public static string P99 = @"P99";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
