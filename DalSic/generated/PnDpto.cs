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
	/// Strongly-typed collection for the PnDpto class.
	/// </summary>
    [Serializable]
	public partial class PnDptoCollection : ActiveList<PnDpto, PnDptoCollection>
	{	   
		public PnDptoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnDptoCollection</returns>
		public PnDptoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnDpto o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_dpto table.
	/// </summary>
	[Serializable]
	public partial class PnDpto : ActiveRecord<PnDpto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnDpto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnDpto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnDpto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnDpto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_dpto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDpto = new TableSchema.TableColumn(schema);
				colvarIdDpto.ColumnName = "id_dpto";
				colvarIdDpto.DataType = DbType.Int32;
				colvarIdDpto.MaxLength = 0;
				colvarIdDpto.AutoIncrement = true;
				colvarIdDpto.IsNullable = false;
				colvarIdDpto.IsPrimaryKey = true;
				colvarIdDpto.IsForeignKey = false;
				colvarIdDpto.IsReadOnly = false;
				colvarIdDpto.DefaultSetting = @"";
				colvarIdDpto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDpto);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiString;
				colvarCodigo.MaxLength = -1;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = true;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarInsCompAnual = new TableSchema.TableColumn(schema);
				colvarInsCompAnual.ColumnName = "ins_comp_anual";
				colvarInsCompAnual.DataType = DbType.Int32;
				colvarInsCompAnual.MaxLength = 0;
				colvarInsCompAnual.AutoIncrement = false;
				colvarInsCompAnual.IsNullable = true;
				colvarInsCompAnual.IsPrimaryKey = false;
				colvarInsCompAnual.IsForeignKey = false;
				colvarInsCompAnual.IsReadOnly = false;
				colvarInsCompAnual.DefaultSetting = @"";
				colvarInsCompAnual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsCompAnual);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_dpto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDpto")]
		[Bindable(true)]
		public int IdDpto 
		{
			get { return GetColumnValue<int>(Columns.IdDpto); }
			set { SetColumnValue(Columns.IdDpto, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("InsCompAnual")]
		[Bindable(true)]
		public int? InsCompAnual 
		{
			get { return GetColumnValue<int?>(Columns.InsCompAnual); }
			set { SetColumnValue(Columns.InsCompAnual, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varCodigo,int? varInsCompAnual)
		{
			PnDpto item = new PnDpto();
			
			item.Nombre = varNombre;
			
			item.Codigo = varCodigo;
			
			item.InsCompAnual = varInsCompAnual;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDpto,string varNombre,string varCodigo,int? varInsCompAnual)
		{
			PnDpto item = new PnDpto();
			
				item.IdDpto = varIdDpto;
			
				item.Nombre = varNombre;
			
				item.Codigo = varCodigo;
			
				item.InsCompAnual = varInsCompAnual;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDptoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn InsCompAnualColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDpto = @"id_dpto";
			 public static string Nombre = @"nombre";
			 public static string Codigo = @"codigo";
			 public static string InsCompAnual = @"ins_comp_anual";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
