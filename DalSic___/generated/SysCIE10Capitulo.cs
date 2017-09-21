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
	/// Strongly-typed collection for the SysCIE10Capitulo class.
	/// </summary>
    [Serializable]
	public partial class SysCIE10CapituloCollection : ActiveList<SysCIE10Capitulo, SysCIE10CapituloCollection>
	{	   
		public SysCIE10CapituloCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysCIE10CapituloCollection</returns>
		public SysCIE10CapituloCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysCIE10Capitulo o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_CIE10Capitulo table.
	/// </summary>
	[Serializable]
	public partial class SysCIE10Capitulo : ActiveRecord<SysCIE10Capitulo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysCIE10Capitulo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysCIE10Capitulo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysCIE10Capitulo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysCIE10Capitulo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_CIE10Capitulo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCie10Capitulo = new TableSchema.TableColumn(schema);
				colvarIdCie10Capitulo.ColumnName = "idCie10Capitulo";
				colvarIdCie10Capitulo.DataType = DbType.Int32;
				colvarIdCie10Capitulo.MaxLength = 0;
				colvarIdCie10Capitulo.AutoIncrement = true;
				colvarIdCie10Capitulo.IsNullable = false;
				colvarIdCie10Capitulo.IsPrimaryKey = true;
				colvarIdCie10Capitulo.IsForeignKey = false;
				colvarIdCie10Capitulo.IsReadOnly = false;
				colvarIdCie10Capitulo.DefaultSetting = @"";
				colvarIdCie10Capitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCie10Capitulo);
				
				TableSchema.TableColumn colvarCapitulo = new TableSchema.TableColumn(schema);
				colvarCapitulo.ColumnName = "CAPITULO";
				colvarCapitulo.DataType = DbType.String;
				colvarCapitulo.MaxLength = 2;
				colvarCapitulo.AutoIncrement = false;
				colvarCapitulo.IsNullable = false;
				colvarCapitulo.IsPrimaryKey = false;
				colvarCapitulo.IsForeignKey = false;
				colvarCapitulo.IsReadOnly = false;
				colvarCapitulo.DefaultSetting = @"";
				colvarCapitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCapitulo);
				
				TableSchema.TableColumn colvarDescrip = new TableSchema.TableColumn(schema);
				colvarDescrip.ColumnName = "DESCRIP";
				colvarDescrip.DataType = DbType.String;
				colvarDescrip.MaxLength = 135;
				colvarDescrip.AutoIncrement = false;
				colvarDescrip.IsNullable = false;
				colvarDescrip.IsPrimaryKey = false;
				colvarDescrip.IsForeignKey = false;
				colvarDescrip.IsReadOnly = false;
				colvarDescrip.DefaultSetting = @"";
				colvarDescrip.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescrip);
				
				TableSchema.TableColumn colvarRango = new TableSchema.TableColumn(schema);
				colvarRango.ColumnName = "RANGO";
				colvarRango.DataType = DbType.String;
				colvarRango.MaxLength = 7;
				colvarRango.AutoIncrement = false;
				colvarRango.IsNullable = false;
				colvarRango.IsPrimaryKey = false;
				colvarRango.IsForeignKey = false;
				colvarRango.IsReadOnly = false;
				colvarRango.DefaultSetting = @"";
				colvarRango.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRango);
				
				TableSchema.TableColumn colvarCapirom = new TableSchema.TableColumn(schema);
				colvarCapirom.ColumnName = "CAPIROM";
				colvarCapirom.DataType = DbType.String;
				colvarCapirom.MaxLength = 5;
				colvarCapirom.AutoIncrement = false;
				colvarCapirom.IsNullable = false;
				colvarCapirom.IsPrimaryKey = false;
				colvarCapirom.IsForeignKey = false;
				colvarCapirom.IsReadOnly = false;
				colvarCapirom.DefaultSetting = @"";
				colvarCapirom.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCapirom);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_CIE10Capitulo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCie10Capitulo")]
		[Bindable(true)]
		public int IdCie10Capitulo 
		{
			get { return GetColumnValue<int>(Columns.IdCie10Capitulo); }
			set { SetColumnValue(Columns.IdCie10Capitulo, value); }
		}
		  
		[XmlAttribute("Capitulo")]
		[Bindable(true)]
		public string Capitulo 
		{
			get { return GetColumnValue<string>(Columns.Capitulo); }
			set { SetColumnValue(Columns.Capitulo, value); }
		}
		  
		[XmlAttribute("Descrip")]
		[Bindable(true)]
		public string Descrip 
		{
			get { return GetColumnValue<string>(Columns.Descrip); }
			set { SetColumnValue(Columns.Descrip, value); }
		}
		  
		[XmlAttribute("Rango")]
		[Bindable(true)]
		public string Rango 
		{
			get { return GetColumnValue<string>(Columns.Rango); }
			set { SetColumnValue(Columns.Rango, value); }
		}
		  
		[XmlAttribute("Capirom")]
		[Bindable(true)]
		public string Capirom 
		{
			get { return GetColumnValue<string>(Columns.Capirom); }
			set { SetColumnValue(Columns.Capirom, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCapitulo,string varDescrip,string varRango,string varCapirom)
		{
			SysCIE10Capitulo item = new SysCIE10Capitulo();
			
			item.Capitulo = varCapitulo;
			
			item.Descrip = varDescrip;
			
			item.Rango = varRango;
			
			item.Capirom = varCapirom;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCie10Capitulo,string varCapitulo,string varDescrip,string varRango,string varCapirom)
		{
			SysCIE10Capitulo item = new SysCIE10Capitulo();
			
				item.IdCie10Capitulo = varIdCie10Capitulo;
			
				item.Capitulo = varCapitulo;
			
				item.Descrip = varDescrip;
			
				item.Rango = varRango;
			
				item.Capirom = varCapirom;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCie10CapituloColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CapituloColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RangoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CapiromColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCie10Capitulo = @"idCie10Capitulo";
			 public static string Capitulo = @"CAPITULO";
			 public static string Descrip = @"DESCRIP";
			 public static string Rango = @"RANGO";
			 public static string Capirom = @"CAPIROM";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
