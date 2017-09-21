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
	/// Strongly-typed collection for the PnCategoria class.
	/// </summary>
    [Serializable]
	public partial class PnCategoriaCollection : ActiveList<PnCategoria, PnCategoriaCollection>
	{	   
		public PnCategoriaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCategoriaCollection</returns>
		public PnCategoriaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCategoria o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_categorias table.
	/// </summary>
	[Serializable]
	public partial class PnCategoria : ActiveRecord<PnCategoria>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCategoria()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCategoria(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCategoria(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCategoria(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_categorias", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCategoria = new TableSchema.TableColumn(schema);
				colvarIdCategoria.ColumnName = "id_categoria";
				colvarIdCategoria.DataType = DbType.Int32;
				colvarIdCategoria.MaxLength = 0;
				colvarIdCategoria.AutoIncrement = true;
				colvarIdCategoria.IsNullable = false;
				colvarIdCategoria.IsPrimaryKey = true;
				colvarIdCategoria.IsForeignKey = false;
				colvarIdCategoria.IsReadOnly = false;
				colvarIdCategoria.DefaultSetting = @"";
				colvarIdCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCategoria);
				
				TableSchema.TableColumn colvarCategoria = new TableSchema.TableColumn(schema);
				colvarCategoria.ColumnName = "categoria";
				colvarCategoria.DataType = DbType.AnsiString;
				colvarCategoria.MaxLength = 50;
				colvarCategoria.AutoIncrement = false;
				colvarCategoria.IsNullable = true;
				colvarCategoria.IsPrimaryKey = false;
				colvarCategoria.IsForeignKey = false;
				colvarCategoria.IsReadOnly = false;
				colvarCategoria.DefaultSetting = @"";
				colvarCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoria);
				
				TableSchema.TableColumn colvarTipoFicha = new TableSchema.TableColumn(schema);
				colvarTipoFicha.ColumnName = "tipo_ficha";
				colvarTipoFicha.DataType = DbType.AnsiStringFixedLength;
				colvarTipoFicha.MaxLength = 1;
				colvarTipoFicha.AutoIncrement = false;
				colvarTipoFicha.IsNullable = true;
				colvarTipoFicha.IsPrimaryKey = false;
				colvarTipoFicha.IsForeignKey = false;
				colvarTipoFicha.IsReadOnly = false;
				colvarTipoFicha.DefaultSetting = @"";
				colvarTipoFicha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoFicha);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_categorias",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCategoria")]
		[Bindable(true)]
		public int IdCategoria 
		{
			get { return GetColumnValue<int>(Columns.IdCategoria); }
			set { SetColumnValue(Columns.IdCategoria, value); }
		}
		  
		[XmlAttribute("Categoria")]
		[Bindable(true)]
		public string Categoria 
		{
			get { return GetColumnValue<string>(Columns.Categoria); }
			set { SetColumnValue(Columns.Categoria, value); }
		}
		  
		[XmlAttribute("TipoFicha")]
		[Bindable(true)]
		public string TipoFicha 
		{
			get { return GetColumnValue<string>(Columns.TipoFicha); }
			set { SetColumnValue(Columns.TipoFicha, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCategoria,string varTipoFicha)
		{
			PnCategoria item = new PnCategoria();
			
			item.Categoria = varCategoria;
			
			item.TipoFicha = varTipoFicha;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCategoria,string varCategoria,string varTipoFicha)
		{
			PnCategoria item = new PnCategoria();
			
				item.IdCategoria = varIdCategoria;
			
				item.Categoria = varCategoria;
			
				item.TipoFicha = varTipoFicha;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCategoriaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoriaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoFichaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCategoria = @"id_categoria";
			 public static string Categoria = @"categoria";
			 public static string TipoFicha = @"tipo_ficha";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
