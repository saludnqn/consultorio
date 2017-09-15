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
	/// Strongly-typed collection for the VgiCInterconsultaItem class.
	/// </summary>
    [Serializable]
	public partial class VgiCInterconsultaItemCollection : ActiveList<VgiCInterconsultaItem, VgiCInterconsultaItemCollection>
	{	   
		public VgiCInterconsultaItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>VgiCInterconsultaItemCollection</returns>
		public VgiCInterconsultaItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                VgiCInterconsultaItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the VGI_CInterconsultaItems table.
	/// </summary>
	[Serializable]
	public partial class VgiCInterconsultaItem : ActiveRecord<VgiCInterconsultaItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public VgiCInterconsultaItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public VgiCInterconsultaItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public VgiCInterconsultaItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public VgiCInterconsultaItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("VGI_CInterconsultaItems", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCInterconsultaItems = new TableSchema.TableColumn(schema);
				colvarIdCInterconsultaItems.ColumnName = "idCInterconsultaItems";
				colvarIdCInterconsultaItems.DataType = DbType.Int32;
				colvarIdCInterconsultaItems.MaxLength = 0;
				colvarIdCInterconsultaItems.AutoIncrement = true;
				colvarIdCInterconsultaItems.IsNullable = false;
				colvarIdCInterconsultaItems.IsPrimaryKey = true;
				colvarIdCInterconsultaItems.IsForeignKey = false;
				colvarIdCInterconsultaItems.IsReadOnly = false;
				colvarIdCInterconsultaItems.DefaultSetting = @"";
				colvarIdCInterconsultaItems.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCInterconsultaItems);
				
				TableSchema.TableColumn colvarIdItems = new TableSchema.TableColumn(schema);
				colvarIdItems.ColumnName = "idItems";
				colvarIdItems.DataType = DbType.Int32;
				colvarIdItems.MaxLength = 0;
				colvarIdItems.AutoIncrement = false;
				colvarIdItems.IsNullable = true;
				colvarIdItems.IsPrimaryKey = false;
				colvarIdItems.IsForeignKey = false;
				colvarIdItems.IsReadOnly = false;
				colvarIdItems.DefaultSetting = @"";
				colvarIdItems.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItems);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 200;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarValor = new TableSchema.TableColumn(schema);
				colvarValor.ColumnName = "Valor";
				colvarValor.DataType = DbType.Int32;
				colvarValor.MaxLength = 0;
				colvarValor.AutoIncrement = false;
				colvarValor.IsNullable = true;
				colvarValor.IsPrimaryKey = false;
				colvarValor.IsForeignKey = false;
				colvarValor.IsReadOnly = false;
				colvarValor.DefaultSetting = @"";
				colvarValor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValor);
				
				TableSchema.TableColumn colvarCInterconsulta = new TableSchema.TableColumn(schema);
				colvarCInterconsulta.ColumnName = "CInterconsulta";
				colvarCInterconsulta.DataType = DbType.AnsiString;
				colvarCInterconsulta.MaxLength = 100;
				colvarCInterconsulta.AutoIncrement = false;
				colvarCInterconsulta.IsNullable = true;
				colvarCInterconsulta.IsPrimaryKey = false;
				colvarCInterconsulta.IsForeignKey = false;
				colvarCInterconsulta.IsReadOnly = false;
				colvarCInterconsulta.DefaultSetting = @"";
				colvarCInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCInterconsulta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("VGI_CInterconsultaItems",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCInterconsultaItems")]
		[Bindable(true)]
		public int IdCInterconsultaItems 
		{
			get { return GetColumnValue<int>(Columns.IdCInterconsultaItems); }
			set { SetColumnValue(Columns.IdCInterconsultaItems, value); }
		}
		  
		[XmlAttribute("IdItems")]
		[Bindable(true)]
		public int? IdItems 
		{
			get { return GetColumnValue<int?>(Columns.IdItems); }
			set { SetColumnValue(Columns.IdItems, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Valor")]
		[Bindable(true)]
		public int? Valor 
		{
			get { return GetColumnValue<int?>(Columns.Valor); }
			set { SetColumnValue(Columns.Valor, value); }
		}
		  
		[XmlAttribute("CInterconsulta")]
		[Bindable(true)]
		public string CInterconsulta 
		{
			get { return GetColumnValue<string>(Columns.CInterconsulta); }
			set { SetColumnValue(Columns.CInterconsulta, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdItems,string varNombre,int? varValor,string varCInterconsulta)
		{
			VgiCInterconsultaItem item = new VgiCInterconsultaItem();
			
			item.IdItems = varIdItems;
			
			item.Nombre = varNombre;
			
			item.Valor = varValor;
			
			item.CInterconsulta = varCInterconsulta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCInterconsultaItems,int? varIdItems,string varNombre,int? varValor,string varCInterconsulta)
		{
			VgiCInterconsultaItem item = new VgiCInterconsultaItem();
			
				item.IdCInterconsultaItems = varIdCInterconsultaItems;
			
				item.IdItems = varIdItems;
			
				item.Nombre = varNombre;
			
				item.Valor = varValor;
			
				item.CInterconsulta = varCInterconsulta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCInterconsultaItemsColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemsColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CInterconsultaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCInterconsultaItems = @"idCInterconsultaItems";
			 public static string IdItems = @"idItems";
			 public static string Nombre = @"Nombre";
			 public static string Valor = @"Valor";
			 public static string CInterconsulta = @"CInterconsulta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
