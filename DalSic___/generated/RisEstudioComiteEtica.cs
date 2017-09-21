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
	/// Strongly-typed collection for the RisEstudioComiteEtica class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioComiteEticaCollection : ActiveList<RisEstudioComiteEtica, RisEstudioComiteEticaCollection>
	{	   
		public RisEstudioComiteEticaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioComiteEticaCollection</returns>
		public RisEstudioComiteEticaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioComiteEtica o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioComiteEtica table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioComiteEtica : ActiveRecord<RisEstudioComiteEtica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioComiteEtica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioComiteEtica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioComiteEtica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioComiteEtica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioComiteEtica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioComiteEtica = new TableSchema.TableColumn(schema);
				colvarIdEstudioComiteEtica.ColumnName = "idEstudioComiteEtica";
				colvarIdEstudioComiteEtica.DataType = DbType.Int32;
				colvarIdEstudioComiteEtica.MaxLength = 0;
				colvarIdEstudioComiteEtica.AutoIncrement = true;
				colvarIdEstudioComiteEtica.IsNullable = false;
				colvarIdEstudioComiteEtica.IsPrimaryKey = true;
				colvarIdEstudioComiteEtica.IsForeignKey = false;
				colvarIdEstudioComiteEtica.IsReadOnly = false;
				colvarIdEstudioComiteEtica.DefaultSetting = @"";
				colvarIdEstudioComiteEtica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioComiteEtica);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarIdComiteEtica = new TableSchema.TableColumn(schema);
				colvarIdComiteEtica.ColumnName = "idComiteEtica";
				colvarIdComiteEtica.DataType = DbType.Int32;
				colvarIdComiteEtica.MaxLength = 0;
				colvarIdComiteEtica.AutoIncrement = false;
				colvarIdComiteEtica.IsNullable = false;
				colvarIdComiteEtica.IsPrimaryKey = false;
				colvarIdComiteEtica.IsForeignKey = false;
				colvarIdComiteEtica.IsReadOnly = false;
				colvarIdComiteEtica.DefaultSetting = @"";
				colvarIdComiteEtica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdComiteEtica);
				
				TableSchema.TableColumn colvarDictamen = new TableSchema.TableColumn(schema);
				colvarDictamen.ColumnName = "dictamen";
				colvarDictamen.DataType = DbType.AnsiString;
				colvarDictamen.MaxLength = 100;
				colvarDictamen.AutoIncrement = false;
				colvarDictamen.IsNullable = false;
				colvarDictamen.IsPrimaryKey = false;
				colvarDictamen.IsForeignKey = false;
				colvarDictamen.IsReadOnly = false;
				colvarDictamen.DefaultSetting = @"";
				colvarDictamen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDictamen);
				
				TableSchema.TableColumn colvarFechaDictamen = new TableSchema.TableColumn(schema);
				colvarFechaDictamen.ColumnName = "fechaDictamen";
				colvarFechaDictamen.DataType = DbType.DateTime;
				colvarFechaDictamen.MaxLength = 0;
				colvarFechaDictamen.AutoIncrement = false;
				colvarFechaDictamen.IsNullable = false;
				colvarFechaDictamen.IsPrimaryKey = false;
				colvarFechaDictamen.IsForeignKey = false;
				colvarFechaDictamen.IsReadOnly = false;
				colvarFechaDictamen.DefaultSetting = @"";
				colvarFechaDictamen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDictamen);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioComiteEtica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioComiteEtica")]
		[Bindable(true)]
		public int IdEstudioComiteEtica 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioComiteEtica); }
			set { SetColumnValue(Columns.IdEstudioComiteEtica, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdComiteEtica")]
		[Bindable(true)]
		public int IdComiteEtica 
		{
			get { return GetColumnValue<int>(Columns.IdComiteEtica); }
			set { SetColumnValue(Columns.IdComiteEtica, value); }
		}
		  
		[XmlAttribute("Dictamen")]
		[Bindable(true)]
		public string Dictamen 
		{
			get { return GetColumnValue<string>(Columns.Dictamen); }
			set { SetColumnValue(Columns.Dictamen, value); }
		}
		  
		[XmlAttribute("FechaDictamen")]
		[Bindable(true)]
		public DateTime FechaDictamen 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaDictamen); }
			set { SetColumnValue(Columns.FechaDictamen, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdComiteEtica,string varDictamen,DateTime varFechaDictamen)
		{
			RisEstudioComiteEtica item = new RisEstudioComiteEtica();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdComiteEtica = varIdComiteEtica;
			
			item.Dictamen = varDictamen;
			
			item.FechaDictamen = varFechaDictamen;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioComiteEtica,int varIdEstudio,int varIdComiteEtica,string varDictamen,DateTime varFechaDictamen)
		{
			RisEstudioComiteEtica item = new RisEstudioComiteEtica();
			
				item.IdEstudioComiteEtica = varIdEstudioComiteEtica;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdComiteEtica = varIdComiteEtica;
			
				item.Dictamen = varDictamen;
			
				item.FechaDictamen = varFechaDictamen;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioComiteEticaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdComiteEticaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DictamenColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDictamenColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioComiteEtica = @"idEstudioComiteEtica";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdComiteEtica = @"idComiteEtica";
			 public static string Dictamen = @"dictamen";
			 public static string FechaDictamen = @"fechaDictamen";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
