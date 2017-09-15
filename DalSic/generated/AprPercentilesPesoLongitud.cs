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
	/// Strongly-typed collection for the AprPercentilesPesoLongitud class.
	/// </summary>
    [Serializable]
	public partial class AprPercentilesPesoLongitudCollection : ActiveList<AprPercentilesPesoLongitud, AprPercentilesPesoLongitudCollection>
	{	   
		public AprPercentilesPesoLongitudCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprPercentilesPesoLongitudCollection</returns>
		public AprPercentilesPesoLongitudCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprPercentilesPesoLongitud o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_PercentilesPesoLongitud table.
	/// </summary>
	[Serializable]
	public partial class AprPercentilesPesoLongitud : ActiveRecord<AprPercentilesPesoLongitud>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprPercentilesPesoLongitud()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprPercentilesPesoLongitud(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprPercentilesPesoLongitud(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprPercentilesPesoLongitud(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_PercentilesPesoLongitud", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarLongitud = new TableSchema.TableColumn(schema);
				colvarLongitud.ColumnName = "Longitud";
				colvarLongitud.DataType = DbType.Decimal;
				colvarLongitud.MaxLength = 0;
				colvarLongitud.AutoIncrement = false;
				colvarLongitud.IsNullable = false;
				colvarLongitud.IsPrimaryKey = false;
				colvarLongitud.IsForeignKey = false;
				colvarLongitud.IsReadOnly = false;
				colvarLongitud.DefaultSetting = @"";
				colvarLongitud.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLongitud);
				
				TableSchema.TableColumn colvarL = new TableSchema.TableColumn(schema);
				colvarL.ColumnName = "L";
				colvarL.DataType = DbType.Decimal;
				colvarL.MaxLength = 0;
				colvarL.AutoIncrement = false;
				colvarL.IsNullable = false;
				colvarL.IsPrimaryKey = false;
				colvarL.IsForeignKey = false;
				colvarL.IsReadOnly = false;
				colvarL.DefaultSetting = @"";
				colvarL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarL);
				
				TableSchema.TableColumn colvarM = new TableSchema.TableColumn(schema);
				colvarM.ColumnName = "M";
				colvarM.DataType = DbType.Decimal;
				colvarM.MaxLength = 0;
				colvarM.AutoIncrement = false;
				colvarM.IsNullable = false;
				colvarM.IsPrimaryKey = false;
				colvarM.IsForeignKey = false;
				colvarM.IsReadOnly = false;
				colvarM.DefaultSetting = @"";
				colvarM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarM);
				
				TableSchema.TableColumn colvarS = new TableSchema.TableColumn(schema);
				colvarS.ColumnName = "S";
				colvarS.DataType = DbType.Decimal;
				colvarS.MaxLength = 0;
				colvarS.AutoIncrement = false;
				colvarS.IsNullable = false;
				colvarS.IsPrimaryKey = false;
				colvarS.IsForeignKey = false;
				colvarS.IsReadOnly = false;
				colvarS.DefaultSetting = @"";
				colvarS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarS);
				
				TableSchema.TableColumn colvarP01 = new TableSchema.TableColumn(schema);
				colvarP01.ColumnName = "P01";
				colvarP01.DataType = DbType.Decimal;
				colvarP01.MaxLength = 0;
				colvarP01.AutoIncrement = false;
				colvarP01.IsNullable = false;
				colvarP01.IsPrimaryKey = false;
				colvarP01.IsForeignKey = false;
				colvarP01.IsReadOnly = false;
				colvarP01.DefaultSetting = @"";
				colvarP01.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP01);
				
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
				
				TableSchema.TableColumn colvarP5 = new TableSchema.TableColumn(schema);
				colvarP5.ColumnName = "P5";
				colvarP5.DataType = DbType.Decimal;
				colvarP5.MaxLength = 0;
				colvarP5.AutoIncrement = false;
				colvarP5.IsNullable = false;
				colvarP5.IsPrimaryKey = false;
				colvarP5.IsForeignKey = false;
				colvarP5.IsReadOnly = false;
				colvarP5.DefaultSetting = @"";
				colvarP5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP5);
				
				TableSchema.TableColumn colvarP10 = new TableSchema.TableColumn(schema);
				colvarP10.ColumnName = "P10";
				colvarP10.DataType = DbType.Decimal;
				colvarP10.MaxLength = 0;
				colvarP10.AutoIncrement = false;
				colvarP10.IsNullable = false;
				colvarP10.IsPrimaryKey = false;
				colvarP10.IsForeignKey = false;
				colvarP10.IsReadOnly = false;
				colvarP10.DefaultSetting = @"";
				colvarP10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP10);
				
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
				
				TableSchema.TableColumn colvarP25 = new TableSchema.TableColumn(schema);
				colvarP25.ColumnName = "P25";
				colvarP25.DataType = DbType.Decimal;
				colvarP25.MaxLength = 0;
				colvarP25.AutoIncrement = false;
				colvarP25.IsNullable = false;
				colvarP25.IsPrimaryKey = false;
				colvarP25.IsForeignKey = false;
				colvarP25.IsReadOnly = false;
				colvarP25.DefaultSetting = @"";
				colvarP25.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP25);
				
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
				
				TableSchema.TableColumn colvarP75 = new TableSchema.TableColumn(schema);
				colvarP75.ColumnName = "P75";
				colvarP75.DataType = DbType.Decimal;
				colvarP75.MaxLength = 0;
				colvarP75.AutoIncrement = false;
				colvarP75.IsNullable = false;
				colvarP75.IsPrimaryKey = false;
				colvarP75.IsForeignKey = false;
				colvarP75.IsReadOnly = false;
				colvarP75.DefaultSetting = @"";
				colvarP75.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP75);
				
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
				
				TableSchema.TableColumn colvarP90 = new TableSchema.TableColumn(schema);
				colvarP90.ColumnName = "P90";
				colvarP90.DataType = DbType.Decimal;
				colvarP90.MaxLength = 0;
				colvarP90.AutoIncrement = false;
				colvarP90.IsNullable = false;
				colvarP90.IsPrimaryKey = false;
				colvarP90.IsForeignKey = false;
				colvarP90.IsReadOnly = false;
				colvarP90.DefaultSetting = @"";
				colvarP90.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP90);
				
				TableSchema.TableColumn colvarP95 = new TableSchema.TableColumn(schema);
				colvarP95.ColumnName = "P95";
				colvarP95.DataType = DbType.Decimal;
				colvarP95.MaxLength = 0;
				colvarP95.AutoIncrement = false;
				colvarP95.IsNullable = false;
				colvarP95.IsPrimaryKey = false;
				colvarP95.IsForeignKey = false;
				colvarP95.IsReadOnly = false;
				colvarP95.DefaultSetting = @"";
				colvarP95.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP95);
				
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
				
				TableSchema.TableColumn colvarP999 = new TableSchema.TableColumn(schema);
				colvarP999.ColumnName = "P999";
				colvarP999.DataType = DbType.Decimal;
				colvarP999.MaxLength = 0;
				colvarP999.AutoIncrement = false;
				colvarP999.IsNullable = false;
				colvarP999.IsPrimaryKey = false;
				colvarP999.IsForeignKey = false;
				colvarP999.IsReadOnly = false;
				colvarP999.DefaultSetting = @"";
				colvarP999.ForeignKeyTableName = "";
				schema.Columns.Add(colvarP999);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_PercentilesPesoLongitud",schema);
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
		  
		[XmlAttribute("Longitud")]
		[Bindable(true)]
		public decimal Longitud 
		{
			get { return GetColumnValue<decimal>(Columns.Longitud); }
			set { SetColumnValue(Columns.Longitud, value); }
		}
		  
		[XmlAttribute("L")]
		[Bindable(true)]
		public decimal L 
		{
			get { return GetColumnValue<decimal>(Columns.L); }
			set { SetColumnValue(Columns.L, value); }
		}
		  
		[XmlAttribute("M")]
		[Bindable(true)]
		public decimal M 
		{
			get { return GetColumnValue<decimal>(Columns.M); }
			set { SetColumnValue(Columns.M, value); }
		}
		  
		[XmlAttribute("S")]
		[Bindable(true)]
		public decimal S 
		{
			get { return GetColumnValue<decimal>(Columns.S); }
			set { SetColumnValue(Columns.S, value); }
		}
		  
		[XmlAttribute("P01")]
		[Bindable(true)]
		public decimal P01 
		{
			get { return GetColumnValue<decimal>(Columns.P01); }
			set { SetColumnValue(Columns.P01, value); }
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
		  
		[XmlAttribute("P5")]
		[Bindable(true)]
		public decimal P5 
		{
			get { return GetColumnValue<decimal>(Columns.P5); }
			set { SetColumnValue(Columns.P5, value); }
		}
		  
		[XmlAttribute("P10")]
		[Bindable(true)]
		public decimal P10 
		{
			get { return GetColumnValue<decimal>(Columns.P10); }
			set { SetColumnValue(Columns.P10, value); }
		}
		  
		[XmlAttribute("P15")]
		[Bindable(true)]
		public decimal P15 
		{
			get { return GetColumnValue<decimal>(Columns.P15); }
			set { SetColumnValue(Columns.P15, value); }
		}
		  
		[XmlAttribute("P25")]
		[Bindable(true)]
		public decimal P25 
		{
			get { return GetColumnValue<decimal>(Columns.P25); }
			set { SetColumnValue(Columns.P25, value); }
		}
		  
		[XmlAttribute("P50")]
		[Bindable(true)]
		public decimal P50 
		{
			get { return GetColumnValue<decimal>(Columns.P50); }
			set { SetColumnValue(Columns.P50, value); }
		}
		  
		[XmlAttribute("P75")]
		[Bindable(true)]
		public decimal P75 
		{
			get { return GetColumnValue<decimal>(Columns.P75); }
			set { SetColumnValue(Columns.P75, value); }
		}
		  
		[XmlAttribute("P85")]
		[Bindable(true)]
		public decimal P85 
		{
			get { return GetColumnValue<decimal>(Columns.P85); }
			set { SetColumnValue(Columns.P85, value); }
		}
		  
		[XmlAttribute("P90")]
		[Bindable(true)]
		public decimal P90 
		{
			get { return GetColumnValue<decimal>(Columns.P90); }
			set { SetColumnValue(Columns.P90, value); }
		}
		  
		[XmlAttribute("P95")]
		[Bindable(true)]
		public decimal P95 
		{
			get { return GetColumnValue<decimal>(Columns.P95); }
			set { SetColumnValue(Columns.P95, value); }
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
		  
		[XmlAttribute("P999")]
		[Bindable(true)]
		public decimal P999 
		{
			get { return GetColumnValue<decimal>(Columns.P999); }
			set { SetColumnValue(Columns.P999, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSexo,decimal varLongitud,decimal varL,decimal varM,decimal varS,decimal varP01,decimal varP1,decimal varP3,decimal varP5,decimal varP10,decimal varP15,decimal varP25,decimal varP50,decimal varP75,decimal varP85,decimal varP90,decimal varP95,decimal varP97,decimal varP99,decimal varP999)
		{
			AprPercentilesPesoLongitud item = new AprPercentilesPesoLongitud();
			
			item.Sexo = varSexo;
			
			item.Longitud = varLongitud;
			
			item.L = varL;
			
			item.M = varM;
			
			item.S = varS;
			
			item.P01 = varP01;
			
			item.P1 = varP1;
			
			item.P3 = varP3;
			
			item.P5 = varP5;
			
			item.P10 = varP10;
			
			item.P15 = varP15;
			
			item.P25 = varP25;
			
			item.P50 = varP50;
			
			item.P75 = varP75;
			
			item.P85 = varP85;
			
			item.P90 = varP90;
			
			item.P95 = varP95;
			
			item.P97 = varP97;
			
			item.P99 = varP99;
			
			item.P999 = varP999;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varSexo,decimal varLongitud,decimal varL,decimal varM,decimal varS,decimal varP01,decimal varP1,decimal varP3,decimal varP5,decimal varP10,decimal varP15,decimal varP25,decimal varP50,decimal varP75,decimal varP85,decimal varP90,decimal varP95,decimal varP97,decimal varP99,decimal varP999)
		{
			AprPercentilesPesoLongitud item = new AprPercentilesPesoLongitud();
			
				item.Id = varId;
			
				item.Sexo = varSexo;
			
				item.Longitud = varLongitud;
			
				item.L = varL;
			
				item.M = varM;
			
				item.S = varS;
			
				item.P01 = varP01;
			
				item.P1 = varP1;
			
				item.P3 = varP3;
			
				item.P5 = varP5;
			
				item.P10 = varP10;
			
				item.P15 = varP15;
			
				item.P25 = varP25;
			
				item.P50 = varP50;
			
				item.P75 = varP75;
			
				item.P85 = varP85;
			
				item.P90 = varP90;
			
				item.P95 = varP95;
			
				item.P97 = varP97;
			
				item.P99 = varP99;
			
				item.P999 = varP999;
			
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
        
        
        
        public static TableSchema.TableColumn LongitudColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn P01Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn P1Column
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn P3Column
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn P5Column
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn P10Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn P15Column
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn P25Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn P50Column
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn P75Column
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn P85Column
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn P90Column
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn P95Column
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn P97Column
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn P99Column
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn P999Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Sexo = @"Sexo";
			 public static string Longitud = @"Longitud";
			 public static string L = @"L";
			 public static string M = @"M";
			 public static string S = @"S";
			 public static string P01 = @"P01";
			 public static string P1 = @"P1";
			 public static string P3 = @"P3";
			 public static string P5 = @"P5";
			 public static string P10 = @"P10";
			 public static string P15 = @"P15";
			 public static string P25 = @"P25";
			 public static string P50 = @"P50";
			 public static string P75 = @"P75";
			 public static string P85 = @"P85";
			 public static string P90 = @"P90";
			 public static string P95 = @"P95";
			 public static string P97 = @"P97";
			 public static string P99 = @"P99";
			 public static string P999 = @"P999";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
