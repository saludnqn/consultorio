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
	/// Strongly-typed collection for the GuardiaTurnero class.
	/// </summary>
    [Serializable]
	public partial class GuardiaTurneroCollection : ActiveList<GuardiaTurnero, GuardiaTurneroCollection>
	{	   
		public GuardiaTurneroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaTurneroCollection</returns>
		public GuardiaTurneroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaTurnero o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Turnero table.
	/// </summary>
	[Serializable]
	public partial class GuardiaTurnero : ActiveRecord<GuardiaTurnero>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaTurnero()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaTurnero(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaTurnero(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaTurnero(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Turnero", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = true;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarValorInt = new TableSchema.TableColumn(schema);
				colvarValorInt.ColumnName = "valorInt";
				colvarValorInt.DataType = DbType.Int32;
				colvarValorInt.MaxLength = 0;
				colvarValorInt.AutoIncrement = false;
				colvarValorInt.IsNullable = true;
				colvarValorInt.IsPrimaryKey = false;
				colvarValorInt.IsForeignKey = false;
				colvarValorInt.IsReadOnly = false;
				colvarValorInt.DefaultSetting = @"";
				colvarValorInt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorInt);
				
				TableSchema.TableColumn colvarValorString = new TableSchema.TableColumn(schema);
				colvarValorString.ColumnName = "valorString";
				colvarValorString.DataType = DbType.String;
				colvarValorString.MaxLength = 500;
				colvarValorString.AutoIncrement = false;
				colvarValorString.IsNullable = true;
				colvarValorString.IsPrimaryKey = false;
				colvarValorString.IsForeignKey = false;
				colvarValorString.IsReadOnly = false;
				colvarValorString.DefaultSetting = @"";
				colvarValorString.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorString);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Turnero",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("ValorInt")]
		[Bindable(true)]
		public int? ValorInt 
		{
			get { return GetColumnValue<int?>(Columns.ValorInt); }
			set { SetColumnValue(Columns.ValorInt, value); }
		}
		  
		[XmlAttribute("ValorString")]
		[Bindable(true)]
		public string ValorString 
		{
			get { return GetColumnValue<string>(Columns.ValorString); }
			set { SetColumnValue(Columns.ValorString, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int? varValorInt,string varValorString)
		{
			GuardiaTurnero item = new GuardiaTurnero();
			
			item.Nombre = varNombre;
			
			item.ValorInt = varValorInt;
			
			item.ValorString = varValorString;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varNombre,int? varValorInt,string varValorString)
		{
			GuardiaTurnero item = new GuardiaTurnero();
			
				item.Nombre = varNombre;
			
				item.ValorInt = varValorInt;
			
				item.ValorString = varValorString;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorIntColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorStringColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Nombre = @"nombre";
			 public static string ValorInt = @"valorInt";
			 public static string ValorString = @"valorString";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
