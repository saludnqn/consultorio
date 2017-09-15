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
	/// Strongly-typed collection for the RemTablaExaman class.
	/// </summary>
    [Serializable]
	public partial class RemTablaExamanCollection : ActiveList<RemTablaExaman, RemTablaExamanCollection>
	{	   
		public RemTablaExamanCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemTablaExamanCollection</returns>
		public RemTablaExamanCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemTablaExaman o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_TablaExamen table.
	/// </summary>
	[Serializable]
	public partial class RemTablaExaman : ActiveRecord<RemTablaExaman>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemTablaExaman()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemTablaExaman(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemTablaExaman(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemTablaExaman(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_TablaExamen", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTablaExamen = new TableSchema.TableColumn(schema);
				colvarIdTablaExamen.ColumnName = "idTablaExamen";
				colvarIdTablaExamen.DataType = DbType.Int32;
				colvarIdTablaExamen.MaxLength = 0;
				colvarIdTablaExamen.AutoIncrement = true;
				colvarIdTablaExamen.IsNullable = false;
				colvarIdTablaExamen.IsPrimaryKey = true;
				colvarIdTablaExamen.IsForeignKey = false;
				colvarIdTablaExamen.IsReadOnly = false;
				colvarIdTablaExamen.DefaultSetting = @"";
				colvarIdTablaExamen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTablaExamen);
				
				TableSchema.TableColumn colvarIdExamenPies = new TableSchema.TableColumn(schema);
				colvarIdExamenPies.ColumnName = "idExamenPies";
				colvarIdExamenPies.DataType = DbType.Int32;
				colvarIdExamenPies.MaxLength = 0;
				colvarIdExamenPies.AutoIncrement = false;
				colvarIdExamenPies.IsNullable = true;
				colvarIdExamenPies.IsPrimaryKey = false;
				colvarIdExamenPies.IsForeignKey = true;
				colvarIdExamenPies.IsReadOnly = false;
				colvarIdExamenPies.DefaultSetting = @"";
				
					colvarIdExamenPies.ForeignKeyTableName = "Rem_ExamenPie";
				schema.Columns.Add(colvarIdExamenPies);
				
				TableSchema.TableColumn colvarII1 = new TableSchema.TableColumn(schema);
				colvarII1.ColumnName = "II1";
				colvarII1.DataType = DbType.Boolean;
				colvarII1.MaxLength = 0;
				colvarII1.AutoIncrement = false;
				colvarII1.IsNullable = true;
				colvarII1.IsPrimaryKey = false;
				colvarII1.IsForeignKey = false;
				colvarII1.IsReadOnly = false;
				colvarII1.DefaultSetting = @"";
				colvarII1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII1);
				
				TableSchema.TableColumn colvarII2 = new TableSchema.TableColumn(schema);
				colvarII2.ColumnName = "II2";
				colvarII2.DataType = DbType.Boolean;
				colvarII2.MaxLength = 0;
				colvarII2.AutoIncrement = false;
				colvarII2.IsNullable = true;
				colvarII2.IsPrimaryKey = false;
				colvarII2.IsForeignKey = false;
				colvarII2.IsReadOnly = false;
				colvarII2.DefaultSetting = @"";
				colvarII2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII2);
				
				TableSchema.TableColumn colvarII3 = new TableSchema.TableColumn(schema);
				colvarII3.ColumnName = "II3";
				colvarII3.DataType = DbType.Boolean;
				colvarII3.MaxLength = 0;
				colvarII3.AutoIncrement = false;
				colvarII3.IsNullable = true;
				colvarII3.IsPrimaryKey = false;
				colvarII3.IsForeignKey = false;
				colvarII3.IsReadOnly = false;
				colvarII3.DefaultSetting = @"";
				colvarII3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII3);
				
				TableSchema.TableColumn colvarII4 = new TableSchema.TableColumn(schema);
				colvarII4.ColumnName = "II4";
				colvarII4.DataType = DbType.Boolean;
				colvarII4.MaxLength = 0;
				colvarII4.AutoIncrement = false;
				colvarII4.IsNullable = true;
				colvarII4.IsPrimaryKey = false;
				colvarII4.IsForeignKey = false;
				colvarII4.IsReadOnly = false;
				colvarII4.DefaultSetting = @"";
				colvarII4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII4);
				
				TableSchema.TableColumn colvarII5 = new TableSchema.TableColumn(schema);
				colvarII5.ColumnName = "II5";
				colvarII5.DataType = DbType.Boolean;
				colvarII5.MaxLength = 0;
				colvarII5.AutoIncrement = false;
				colvarII5.IsNullable = true;
				colvarII5.IsPrimaryKey = false;
				colvarII5.IsForeignKey = false;
				colvarII5.IsReadOnly = false;
				colvarII5.DefaultSetting = @"";
				colvarII5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII5);
				
				TableSchema.TableColumn colvarII6 = new TableSchema.TableColumn(schema);
				colvarII6.ColumnName = "II6";
				colvarII6.DataType = DbType.Boolean;
				colvarII6.MaxLength = 0;
				colvarII6.AutoIncrement = false;
				colvarII6.IsNullable = true;
				colvarII6.IsPrimaryKey = false;
				colvarII6.IsForeignKey = false;
				colvarII6.IsReadOnly = false;
				colvarII6.DefaultSetting = @"";
				colvarII6.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII6);
				
				TableSchema.TableColumn colvarII7 = new TableSchema.TableColumn(schema);
				colvarII7.ColumnName = "II7";
				colvarII7.DataType = DbType.Boolean;
				colvarII7.MaxLength = 0;
				colvarII7.AutoIncrement = false;
				colvarII7.IsNullable = true;
				colvarII7.IsPrimaryKey = false;
				colvarII7.IsForeignKey = false;
				colvarII7.IsReadOnly = false;
				colvarII7.DefaultSetting = @"";
				colvarII7.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII7);
				
				TableSchema.TableColumn colvarII8 = new TableSchema.TableColumn(schema);
				colvarII8.ColumnName = "II8";
				colvarII8.DataType = DbType.Boolean;
				colvarII8.MaxLength = 0;
				colvarII8.AutoIncrement = false;
				colvarII8.IsNullable = true;
				colvarII8.IsPrimaryKey = false;
				colvarII8.IsForeignKey = false;
				colvarII8.IsReadOnly = false;
				colvarII8.DefaultSetting = @"";
				colvarII8.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII8);
				
				TableSchema.TableColumn colvarII9 = new TableSchema.TableColumn(schema);
				colvarII9.ColumnName = "II9";
				colvarII9.DataType = DbType.Boolean;
				colvarII9.MaxLength = 0;
				colvarII9.AutoIncrement = false;
				colvarII9.IsNullable = true;
				colvarII9.IsPrimaryKey = false;
				colvarII9.IsForeignKey = false;
				colvarII9.IsReadOnly = false;
				colvarII9.DefaultSetting = @"";
				colvarII9.ForeignKeyTableName = "";
				schema.Columns.Add(colvarII9);
				
				TableSchema.TableColumn colvarDD1 = new TableSchema.TableColumn(schema);
				colvarDD1.ColumnName = "DD1";
				colvarDD1.DataType = DbType.Boolean;
				colvarDD1.MaxLength = 0;
				colvarDD1.AutoIncrement = false;
				colvarDD1.IsNullable = true;
				colvarDD1.IsPrimaryKey = false;
				colvarDD1.IsForeignKey = false;
				colvarDD1.IsReadOnly = false;
				colvarDD1.DefaultSetting = @"";
				colvarDD1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD1);
				
				TableSchema.TableColumn colvarDD2 = new TableSchema.TableColumn(schema);
				colvarDD2.ColumnName = "DD2";
				colvarDD2.DataType = DbType.Boolean;
				colvarDD2.MaxLength = 0;
				colvarDD2.AutoIncrement = false;
				colvarDD2.IsNullable = true;
				colvarDD2.IsPrimaryKey = false;
				colvarDD2.IsForeignKey = false;
				colvarDD2.IsReadOnly = false;
				colvarDD2.DefaultSetting = @"";
				colvarDD2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD2);
				
				TableSchema.TableColumn colvarDD3 = new TableSchema.TableColumn(schema);
				colvarDD3.ColumnName = "DD3";
				colvarDD3.DataType = DbType.Boolean;
				colvarDD3.MaxLength = 0;
				colvarDD3.AutoIncrement = false;
				colvarDD3.IsNullable = true;
				colvarDD3.IsPrimaryKey = false;
				colvarDD3.IsForeignKey = false;
				colvarDD3.IsReadOnly = false;
				colvarDD3.DefaultSetting = @"";
				colvarDD3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD3);
				
				TableSchema.TableColumn colvarDD4 = new TableSchema.TableColumn(schema);
				colvarDD4.ColumnName = "DD4";
				colvarDD4.DataType = DbType.Boolean;
				colvarDD4.MaxLength = 0;
				colvarDD4.AutoIncrement = false;
				colvarDD4.IsNullable = true;
				colvarDD4.IsPrimaryKey = false;
				colvarDD4.IsForeignKey = false;
				colvarDD4.IsReadOnly = false;
				colvarDD4.DefaultSetting = @"";
				colvarDD4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD4);
				
				TableSchema.TableColumn colvarDD5 = new TableSchema.TableColumn(schema);
				colvarDD5.ColumnName = "DD5";
				colvarDD5.DataType = DbType.Boolean;
				colvarDD5.MaxLength = 0;
				colvarDD5.AutoIncrement = false;
				colvarDD5.IsNullable = true;
				colvarDD5.IsPrimaryKey = false;
				colvarDD5.IsForeignKey = false;
				colvarDD5.IsReadOnly = false;
				colvarDD5.DefaultSetting = @"";
				colvarDD5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD5);
				
				TableSchema.TableColumn colvarDD6 = new TableSchema.TableColumn(schema);
				colvarDD6.ColumnName = "DD6";
				colvarDD6.DataType = DbType.Boolean;
				colvarDD6.MaxLength = 0;
				colvarDD6.AutoIncrement = false;
				colvarDD6.IsNullable = true;
				colvarDD6.IsPrimaryKey = false;
				colvarDD6.IsForeignKey = false;
				colvarDD6.IsReadOnly = false;
				colvarDD6.DefaultSetting = @"";
				colvarDD6.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD6);
				
				TableSchema.TableColumn colvarDD7 = new TableSchema.TableColumn(schema);
				colvarDD7.ColumnName = "DD7";
				colvarDD7.DataType = DbType.Boolean;
				colvarDD7.MaxLength = 0;
				colvarDD7.AutoIncrement = false;
				colvarDD7.IsNullable = true;
				colvarDD7.IsPrimaryKey = false;
				colvarDD7.IsForeignKey = false;
				colvarDD7.IsReadOnly = false;
				colvarDD7.DefaultSetting = @"";
				colvarDD7.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD7);
				
				TableSchema.TableColumn colvarDD8 = new TableSchema.TableColumn(schema);
				colvarDD8.ColumnName = "DD8";
				colvarDD8.DataType = DbType.Boolean;
				colvarDD8.MaxLength = 0;
				colvarDD8.AutoIncrement = false;
				colvarDD8.IsNullable = true;
				colvarDD8.IsPrimaryKey = false;
				colvarDD8.IsForeignKey = false;
				colvarDD8.IsReadOnly = false;
				colvarDD8.DefaultSetting = @"";
				colvarDD8.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD8);
				
				TableSchema.TableColumn colvarDD9 = new TableSchema.TableColumn(schema);
				colvarDD9.ColumnName = "DD9";
				colvarDD9.DataType = DbType.Boolean;
				colvarDD9.MaxLength = 0;
				colvarDD9.AutoIncrement = false;
				colvarDD9.IsNullable = true;
				colvarDD9.IsPrimaryKey = false;
				colvarDD9.IsForeignKey = false;
				colvarDD9.IsReadOnly = false;
				colvarDD9.DefaultSetting = @"";
				colvarDD9.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDD9);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_TablaExamen",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTablaExamen")]
		[Bindable(true)]
		public int IdTablaExamen 
		{
			get { return GetColumnValue<int>(Columns.IdTablaExamen); }
			set { SetColumnValue(Columns.IdTablaExamen, value); }
		}
		  
		[XmlAttribute("IdExamenPies")]
		[Bindable(true)]
		public int? IdExamenPies 
		{
			get { return GetColumnValue<int?>(Columns.IdExamenPies); }
			set { SetColumnValue(Columns.IdExamenPies, value); }
		}
		  
		[XmlAttribute("II1")]
		[Bindable(true)]
		public bool? II1 
		{
			get { return GetColumnValue<bool?>(Columns.II1); }
			set { SetColumnValue(Columns.II1, value); }
		}
		  
		[XmlAttribute("II2")]
		[Bindable(true)]
		public bool? II2 
		{
			get { return GetColumnValue<bool?>(Columns.II2); }
			set { SetColumnValue(Columns.II2, value); }
		}
		  
		[XmlAttribute("II3")]
		[Bindable(true)]
		public bool? II3 
		{
			get { return GetColumnValue<bool?>(Columns.II3); }
			set { SetColumnValue(Columns.II3, value); }
		}
		  
		[XmlAttribute("II4")]
		[Bindable(true)]
		public bool? II4 
		{
			get { return GetColumnValue<bool?>(Columns.II4); }
			set { SetColumnValue(Columns.II4, value); }
		}
		  
		[XmlAttribute("II5")]
		[Bindable(true)]
		public bool? II5 
		{
			get { return GetColumnValue<bool?>(Columns.II5); }
			set { SetColumnValue(Columns.II5, value); }
		}
		  
		[XmlAttribute("II6")]
		[Bindable(true)]
		public bool? II6 
		{
			get { return GetColumnValue<bool?>(Columns.II6); }
			set { SetColumnValue(Columns.II6, value); }
		}
		  
		[XmlAttribute("II7")]
		[Bindable(true)]
		public bool? II7 
		{
			get { return GetColumnValue<bool?>(Columns.II7); }
			set { SetColumnValue(Columns.II7, value); }
		}
		  
		[XmlAttribute("II8")]
		[Bindable(true)]
		public bool? II8 
		{
			get { return GetColumnValue<bool?>(Columns.II8); }
			set { SetColumnValue(Columns.II8, value); }
		}
		  
		[XmlAttribute("II9")]
		[Bindable(true)]
		public bool? II9 
		{
			get { return GetColumnValue<bool?>(Columns.II9); }
			set { SetColumnValue(Columns.II9, value); }
		}
		  
		[XmlAttribute("DD1")]
		[Bindable(true)]
		public bool? DD1 
		{
			get { return GetColumnValue<bool?>(Columns.DD1); }
			set { SetColumnValue(Columns.DD1, value); }
		}
		  
		[XmlAttribute("DD2")]
		[Bindable(true)]
		public bool? DD2 
		{
			get { return GetColumnValue<bool?>(Columns.DD2); }
			set { SetColumnValue(Columns.DD2, value); }
		}
		  
		[XmlAttribute("DD3")]
		[Bindable(true)]
		public bool? DD3 
		{
			get { return GetColumnValue<bool?>(Columns.DD3); }
			set { SetColumnValue(Columns.DD3, value); }
		}
		  
		[XmlAttribute("DD4")]
		[Bindable(true)]
		public bool? DD4 
		{
			get { return GetColumnValue<bool?>(Columns.DD4); }
			set { SetColumnValue(Columns.DD4, value); }
		}
		  
		[XmlAttribute("DD5")]
		[Bindable(true)]
		public bool? DD5 
		{
			get { return GetColumnValue<bool?>(Columns.DD5); }
			set { SetColumnValue(Columns.DD5, value); }
		}
		  
		[XmlAttribute("DD6")]
		[Bindable(true)]
		public bool? DD6 
		{
			get { return GetColumnValue<bool?>(Columns.DD6); }
			set { SetColumnValue(Columns.DD6, value); }
		}
		  
		[XmlAttribute("DD7")]
		[Bindable(true)]
		public bool? DD7 
		{
			get { return GetColumnValue<bool?>(Columns.DD7); }
			set { SetColumnValue(Columns.DD7, value); }
		}
		  
		[XmlAttribute("DD8")]
		[Bindable(true)]
		public bool? DD8 
		{
			get { return GetColumnValue<bool?>(Columns.DD8); }
			set { SetColumnValue(Columns.DD8, value); }
		}
		  
		[XmlAttribute("DD9")]
		[Bindable(true)]
		public bool? DD9 
		{
			get { return GetColumnValue<bool?>(Columns.DD9); }
			set { SetColumnValue(Columns.DD9, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a RemExamenPie ActiveRecord object related to this RemTablaExaman
		/// 
		/// </summary>
		public DalSic.RemExamenPie RemExamenPie
		{
			get { return DalSic.RemExamenPie.FetchByID(this.IdExamenPies); }
			set { SetColumnValue("idExamenPies", value.IdExamenPies); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdExamenPies,bool? varII1,bool? varII2,bool? varII3,bool? varII4,bool? varII5,bool? varII6,bool? varII7,bool? varII8,bool? varII9,bool? varDD1,bool? varDD2,bool? varDD3,bool? varDD4,bool? varDD5,bool? varDD6,bool? varDD7,bool? varDD8,bool? varDD9)
		{
			RemTablaExaman item = new RemTablaExaman();
			
			item.IdExamenPies = varIdExamenPies;
			
			item.II1 = varII1;
			
			item.II2 = varII2;
			
			item.II3 = varII3;
			
			item.II4 = varII4;
			
			item.II5 = varII5;
			
			item.II6 = varII6;
			
			item.II7 = varII7;
			
			item.II8 = varII8;
			
			item.II9 = varII9;
			
			item.DD1 = varDD1;
			
			item.DD2 = varDD2;
			
			item.DD3 = varDD3;
			
			item.DD4 = varDD4;
			
			item.DD5 = varDD5;
			
			item.DD6 = varDD6;
			
			item.DD7 = varDD7;
			
			item.DD8 = varDD8;
			
			item.DD9 = varDD9;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTablaExamen,int? varIdExamenPies,bool? varII1,bool? varII2,bool? varII3,bool? varII4,bool? varII5,bool? varII6,bool? varII7,bool? varII8,bool? varII9,bool? varDD1,bool? varDD2,bool? varDD3,bool? varDD4,bool? varDD5,bool? varDD6,bool? varDD7,bool? varDD8,bool? varDD9)
		{
			RemTablaExaman item = new RemTablaExaman();
			
				item.IdTablaExamen = varIdTablaExamen;
			
				item.IdExamenPies = varIdExamenPies;
			
				item.II1 = varII1;
			
				item.II2 = varII2;
			
				item.II3 = varII3;
			
				item.II4 = varII4;
			
				item.II5 = varII5;
			
				item.II6 = varII6;
			
				item.II7 = varII7;
			
				item.II8 = varII8;
			
				item.II9 = varII9;
			
				item.DD1 = varDD1;
			
				item.DD2 = varDD2;
			
				item.DD3 = varDD3;
			
				item.DD4 = varDD4;
			
				item.DD5 = varDD5;
			
				item.DD6 = varDD6;
			
				item.DD7 = varDD7;
			
				item.DD8 = varDD8;
			
				item.DD9 = varDD9;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTablaExamenColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExamenPiesColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn II1Column
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn II2Column
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn II3Column
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn II4Column
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn II5Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn II6Column
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn II7Column
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn II8Column
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn II9Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DD1Column
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DD2Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn DD3Column
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DD4Column
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn DD5Column
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn DD6Column
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn DD7Column
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn DD8Column
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn DD9Column
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTablaExamen = @"idTablaExamen";
			 public static string IdExamenPies = @"idExamenPies";
			 public static string II1 = @"II1";
			 public static string II2 = @"II2";
			 public static string II3 = @"II3";
			 public static string II4 = @"II4";
			 public static string II5 = @"II5";
			 public static string II6 = @"II6";
			 public static string II7 = @"II7";
			 public static string II8 = @"II8";
			 public static string II9 = @"II9";
			 public static string DD1 = @"DD1";
			 public static string DD2 = @"DD2";
			 public static string DD3 = @"DD3";
			 public static string DD4 = @"DD4";
			 public static string DD5 = @"DD5";
			 public static string DD6 = @"DD6";
			 public static string DD7 = @"DD7";
			 public static string DD8 = @"DD8";
			 public static string DD9 = @"DD9";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
