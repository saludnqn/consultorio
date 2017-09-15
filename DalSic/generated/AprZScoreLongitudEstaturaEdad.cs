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
	/// Strongly-typed collection for the AprZScoreLongitudEstaturaEdad class.
	/// </summary>
    [Serializable]
	public partial class AprZScoreLongitudEstaturaEdadCollection : ActiveList<AprZScoreLongitudEstaturaEdad, AprZScoreLongitudEstaturaEdadCollection>
	{	   
		public AprZScoreLongitudEstaturaEdadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprZScoreLongitudEstaturaEdadCollection</returns>
		public AprZScoreLongitudEstaturaEdadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprZScoreLongitudEstaturaEdad o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ZScoreLongitudEstaturaEdad table.
	/// </summary>
	[Serializable]
	public partial class AprZScoreLongitudEstaturaEdad : ActiveRecord<AprZScoreLongitudEstaturaEdad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprZScoreLongitudEstaturaEdad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprZScoreLongitudEstaturaEdad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprZScoreLongitudEstaturaEdad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprZScoreLongitudEstaturaEdad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ZScoreLongitudEstaturaEdad", TableType.Table, DataService.GetInstance("sicProvider"));
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
				colvarSexo.IsNullable = true;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
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
				
				TableSchema.TableColumn colvarSD4neg = new TableSchema.TableColumn(schema);
				colvarSD4neg.ColumnName = "SD4neg";
				colvarSD4neg.DataType = DbType.Decimal;
				colvarSD4neg.MaxLength = 0;
				colvarSD4neg.AutoIncrement = false;
				colvarSD4neg.IsNullable = true;
				colvarSD4neg.IsPrimaryKey = false;
				colvarSD4neg.IsForeignKey = false;
				colvarSD4neg.IsReadOnly = false;
				colvarSD4neg.DefaultSetting = @"";
				colvarSD4neg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD4neg);
				
				TableSchema.TableColumn colvarSD3neg = new TableSchema.TableColumn(schema);
				colvarSD3neg.ColumnName = "SD3neg";
				colvarSD3neg.DataType = DbType.Decimal;
				colvarSD3neg.MaxLength = 0;
				colvarSD3neg.AutoIncrement = false;
				colvarSD3neg.IsNullable = true;
				colvarSD3neg.IsPrimaryKey = false;
				colvarSD3neg.IsForeignKey = false;
				colvarSD3neg.IsReadOnly = false;
				colvarSD3neg.DefaultSetting = @"";
				colvarSD3neg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD3neg);
				
				TableSchema.TableColumn colvarSD2neg = new TableSchema.TableColumn(schema);
				colvarSD2neg.ColumnName = "SD2neg";
				colvarSD2neg.DataType = DbType.Decimal;
				colvarSD2neg.MaxLength = 0;
				colvarSD2neg.AutoIncrement = false;
				colvarSD2neg.IsNullable = true;
				colvarSD2neg.IsPrimaryKey = false;
				colvarSD2neg.IsForeignKey = false;
				colvarSD2neg.IsReadOnly = false;
				colvarSD2neg.DefaultSetting = @"";
				colvarSD2neg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD2neg);
				
				TableSchema.TableColumn colvarSD1neg = new TableSchema.TableColumn(schema);
				colvarSD1neg.ColumnName = "SD1neg";
				colvarSD1neg.DataType = DbType.Decimal;
				colvarSD1neg.MaxLength = 0;
				colvarSD1neg.AutoIncrement = false;
				colvarSD1neg.IsNullable = true;
				colvarSD1neg.IsPrimaryKey = false;
				colvarSD1neg.IsForeignKey = false;
				colvarSD1neg.IsReadOnly = false;
				colvarSD1neg.DefaultSetting = @"";
				colvarSD1neg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD1neg);
				
				TableSchema.TableColumn colvarSD0 = new TableSchema.TableColumn(schema);
				colvarSD0.ColumnName = "SD0";
				colvarSD0.DataType = DbType.Decimal;
				colvarSD0.MaxLength = 0;
				colvarSD0.AutoIncrement = false;
				colvarSD0.IsNullable = true;
				colvarSD0.IsPrimaryKey = false;
				colvarSD0.IsForeignKey = false;
				colvarSD0.IsReadOnly = false;
				colvarSD0.DefaultSetting = @"";
				colvarSD0.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD0);
				
				TableSchema.TableColumn colvarSD1 = new TableSchema.TableColumn(schema);
				colvarSD1.ColumnName = "SD1";
				colvarSD1.DataType = DbType.Decimal;
				colvarSD1.MaxLength = 0;
				colvarSD1.AutoIncrement = false;
				colvarSD1.IsNullable = true;
				colvarSD1.IsPrimaryKey = false;
				colvarSD1.IsForeignKey = false;
				colvarSD1.IsReadOnly = false;
				colvarSD1.DefaultSetting = @"";
				colvarSD1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD1);
				
				TableSchema.TableColumn colvarSD2 = new TableSchema.TableColumn(schema);
				colvarSD2.ColumnName = "SD2";
				colvarSD2.DataType = DbType.Decimal;
				colvarSD2.MaxLength = 0;
				colvarSD2.AutoIncrement = false;
				colvarSD2.IsNullable = true;
				colvarSD2.IsPrimaryKey = false;
				colvarSD2.IsForeignKey = false;
				colvarSD2.IsReadOnly = false;
				colvarSD2.DefaultSetting = @"";
				colvarSD2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD2);
				
				TableSchema.TableColumn colvarSD3 = new TableSchema.TableColumn(schema);
				colvarSD3.ColumnName = "SD3";
				colvarSD3.DataType = DbType.Decimal;
				colvarSD3.MaxLength = 0;
				colvarSD3.AutoIncrement = false;
				colvarSD3.IsNullable = true;
				colvarSD3.IsPrimaryKey = false;
				colvarSD3.IsForeignKey = false;
				colvarSD3.IsReadOnly = false;
				colvarSD3.DefaultSetting = @"";
				colvarSD3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD3);
				
				TableSchema.TableColumn colvarSD4 = new TableSchema.TableColumn(schema);
				colvarSD4.ColumnName = "SD4";
				colvarSD4.DataType = DbType.Decimal;
				colvarSD4.MaxLength = 0;
				colvarSD4.AutoIncrement = false;
				colvarSD4.IsNullable = true;
				colvarSD4.IsPrimaryKey = false;
				colvarSD4.IsForeignKey = false;
				colvarSD4.IsReadOnly = false;
				colvarSD4.DefaultSetting = @"";
				colvarSD4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSD4);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ZScoreLongitudEstaturaEdad",schema);
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
		public int? Sexo 
		{
			get { return GetColumnValue<int?>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int? Edad 
		{
			get { return GetColumnValue<int?>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("SD4neg")]
		[Bindable(true)]
		public decimal? SD4neg 
		{
			get { return GetColumnValue<decimal?>(Columns.SD4neg); }
			set { SetColumnValue(Columns.SD4neg, value); }
		}
		  
		[XmlAttribute("SD3neg")]
		[Bindable(true)]
		public decimal? SD3neg 
		{
			get { return GetColumnValue<decimal?>(Columns.SD3neg); }
			set { SetColumnValue(Columns.SD3neg, value); }
		}
		  
		[XmlAttribute("SD2neg")]
		[Bindable(true)]
		public decimal? SD2neg 
		{
			get { return GetColumnValue<decimal?>(Columns.SD2neg); }
			set { SetColumnValue(Columns.SD2neg, value); }
		}
		  
		[XmlAttribute("SD1neg")]
		[Bindable(true)]
		public decimal? SD1neg 
		{
			get { return GetColumnValue<decimal?>(Columns.SD1neg); }
			set { SetColumnValue(Columns.SD1neg, value); }
		}
		  
		[XmlAttribute("SD0")]
		[Bindable(true)]
		public decimal? SD0 
		{
			get { return GetColumnValue<decimal?>(Columns.SD0); }
			set { SetColumnValue(Columns.SD0, value); }
		}
		  
		[XmlAttribute("SD1")]
		[Bindable(true)]
		public decimal? SD1 
		{
			get { return GetColumnValue<decimal?>(Columns.SD1); }
			set { SetColumnValue(Columns.SD1, value); }
		}
		  
		[XmlAttribute("SD2")]
		[Bindable(true)]
		public decimal? SD2 
		{
			get { return GetColumnValue<decimal?>(Columns.SD2); }
			set { SetColumnValue(Columns.SD2, value); }
		}
		  
		[XmlAttribute("SD3")]
		[Bindable(true)]
		public decimal? SD3 
		{
			get { return GetColumnValue<decimal?>(Columns.SD3); }
			set { SetColumnValue(Columns.SD3, value); }
		}
		  
		[XmlAttribute("SD4")]
		[Bindable(true)]
		public decimal? SD4 
		{
			get { return GetColumnValue<decimal?>(Columns.SD4); }
			set { SetColumnValue(Columns.SD4, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varSexo,int? varEdad,decimal? varSD4neg,decimal? varSD3neg,decimal? varSD2neg,decimal? varSD1neg,decimal? varSD0,decimal? varSD1,decimal? varSD2,decimal? varSD3,decimal? varSD4)
		{
			AprZScoreLongitudEstaturaEdad item = new AprZScoreLongitudEstaturaEdad();
			
			item.Sexo = varSexo;
			
			item.Edad = varEdad;
			
			item.SD4neg = varSD4neg;
			
			item.SD3neg = varSD3neg;
			
			item.SD2neg = varSD2neg;
			
			item.SD1neg = varSD1neg;
			
			item.SD0 = varSD0;
			
			item.SD1 = varSD1;
			
			item.SD2 = varSD2;
			
			item.SD3 = varSD3;
			
			item.SD4 = varSD4;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varSexo,int? varEdad,decimal? varSD4neg,decimal? varSD3neg,decimal? varSD2neg,decimal? varSD1neg,decimal? varSD0,decimal? varSD1,decimal? varSD2,decimal? varSD3,decimal? varSD4)
		{
			AprZScoreLongitudEstaturaEdad item = new AprZScoreLongitudEstaturaEdad();
			
				item.Id = varId;
			
				item.Sexo = varSexo;
			
				item.Edad = varEdad;
			
				item.SD4neg = varSD4neg;
			
				item.SD3neg = varSD3neg;
			
				item.SD2neg = varSD2neg;
			
				item.SD1neg = varSD1neg;
			
				item.SD0 = varSD0;
			
				item.SD1 = varSD1;
			
				item.SD2 = varSD2;
			
				item.SD3 = varSD3;
			
				item.SD4 = varSD4;
			
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
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SD4negColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SD3negColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SD2negColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SD1negColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SD0Column
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn SD1Column
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn SD2Column
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SD3Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SD4Column
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Sexo = @"Sexo";
			 public static string Edad = @"Edad";
			 public static string SD4neg = @"SD4neg";
			 public static string SD3neg = @"SD3neg";
			 public static string SD2neg = @"SD2neg";
			 public static string SD1neg = @"SD1neg";
			 public static string SD0 = @"SD0";
			 public static string SD1 = @"SD1";
			 public static string SD2 = @"SD2";
			 public static string SD3 = @"SD3";
			 public static string SD4 = @"SD4";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
