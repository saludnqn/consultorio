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
	/// Strongly-typed collection for the PnAnexo class.
	/// </summary>
    [Serializable]
	public partial class PnAnexoCollection : ActiveList<PnAnexo, PnAnexoCollection>
	{	   
		public PnAnexoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAnexoCollection</returns>
		public PnAnexoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAnexo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_anexo table.
	/// </summary>
	[Serializable]
	public partial class PnAnexo : ActiveRecord<PnAnexo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAnexo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAnexo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAnexo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAnexo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_anexo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAnexo = new TableSchema.TableColumn(schema);
				colvarIdAnexo.ColumnName = "id_anexo";
				colvarIdAnexo.DataType = DbType.Int32;
				colvarIdAnexo.MaxLength = 0;
				colvarIdAnexo.AutoIncrement = true;
				colvarIdAnexo.IsNullable = false;
				colvarIdAnexo.IsPrimaryKey = true;
				colvarIdAnexo.IsForeignKey = false;
				colvarIdAnexo.IsReadOnly = false;
				colvarIdAnexo.DefaultSetting = @"";
				colvarIdAnexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAnexo);
				
				TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
				colvarNumero.ColumnName = "numero";
				colvarNumero.DataType = DbType.Int32;
				colvarNumero.MaxLength = 0;
				colvarNumero.AutoIncrement = false;
				colvarNumero.IsNullable = true;
				colvarNumero.IsPrimaryKey = false;
				colvarNumero.IsForeignKey = false;
				colvarNumero.IsReadOnly = false;
				colvarNumero.DefaultSetting = @"";
				colvarNumero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumero);
				
				TableSchema.TableColumn colvarPrueba = new TableSchema.TableColumn(schema);
				colvarPrueba.ColumnName = "prueba";
				colvarPrueba.DataType = DbType.AnsiString;
				colvarPrueba.MaxLength = -1;
				colvarPrueba.AutoIncrement = false;
				colvarPrueba.IsNullable = true;
				colvarPrueba.IsPrimaryKey = false;
				colvarPrueba.IsForeignKey = false;
				colvarPrueba.IsReadOnly = false;
				colvarPrueba.DefaultSetting = @"";
				colvarPrueba.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrueba);
				
				TableSchema.TableColumn colvarCategoria = new TableSchema.TableColumn(schema);
				colvarCategoria.ColumnName = "categoria";
				colvarCategoria.DataType = DbType.Int32;
				colvarCategoria.MaxLength = 0;
				colvarCategoria.AutoIncrement = false;
				colvarCategoria.IsNullable = true;
				colvarCategoria.IsPrimaryKey = false;
				colvarCategoria.IsForeignKey = false;
				colvarCategoria.IsReadOnly = false;
				colvarCategoria.DefaultSetting = @"";
				colvarCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoria);
				
				TableSchema.TableColumn colvarPrecio = new TableSchema.TableColumn(schema);
				colvarPrecio.ColumnName = "precio";
				colvarPrecio.DataType = DbType.Decimal;
				colvarPrecio.MaxLength = 0;
				colvarPrecio.AutoIncrement = false;
				colvarPrecio.IsNullable = true;
				colvarPrecio.IsPrimaryKey = false;
				colvarPrecio.IsForeignKey = false;
				colvarPrecio.IsReadOnly = false;
				colvarPrecio.DefaultSetting = @"";
				colvarPrecio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrecio);
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "id_nomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = false;
				colvarIdNomenclador.IsNullable = true;
				colvarIdNomenclador.IsPrimaryKey = false;
				colvarIdNomenclador.IsForeignKey = false;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				colvarIdNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarIdNomencladorDetalle = new TableSchema.TableColumn(schema);
				colvarIdNomencladorDetalle.ColumnName = "id_nomenclador_detalle";
				colvarIdNomencladorDetalle.DataType = DbType.Int32;
				colvarIdNomencladorDetalle.MaxLength = 0;
				colvarIdNomencladorDetalle.AutoIncrement = false;
				colvarIdNomencladorDetalle.IsNullable = true;
				colvarIdNomencladorDetalle.IsPrimaryKey = false;
				colvarIdNomencladorDetalle.IsForeignKey = false;
				colvarIdNomencladorDetalle.IsReadOnly = false;
				colvarIdNomencladorDetalle.DefaultSetting = @"";
				colvarIdNomencladorDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomencladorDetalle);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_anexo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAnexo")]
		[Bindable(true)]
		public int IdAnexo 
		{
			get { return GetColumnValue<int>(Columns.IdAnexo); }
			set { SetColumnValue(Columns.IdAnexo, value); }
		}
		  
		[XmlAttribute("Numero")]
		[Bindable(true)]
		public int? Numero 
		{
			get { return GetColumnValue<int?>(Columns.Numero); }
			set { SetColumnValue(Columns.Numero, value); }
		}
		  
		[XmlAttribute("Prueba")]
		[Bindable(true)]
		public string Prueba 
		{
			get { return GetColumnValue<string>(Columns.Prueba); }
			set { SetColumnValue(Columns.Prueba, value); }
		}
		  
		[XmlAttribute("Categoria")]
		[Bindable(true)]
		public int? Categoria 
		{
			get { return GetColumnValue<int?>(Columns.Categoria); }
			set { SetColumnValue(Columns.Categoria, value); }
		}
		  
		[XmlAttribute("Precio")]
		[Bindable(true)]
		public decimal? Precio 
		{
			get { return GetColumnValue<decimal?>(Columns.Precio); }
			set { SetColumnValue(Columns.Precio, value); }
		}
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int? IdNomenclador 
		{
			get { return GetColumnValue<int?>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int? IdNomencladorDetalle 
		{
			get { return GetColumnValue<int?>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varNumero,string varPrueba,int? varCategoria,decimal? varPrecio,int? varIdNomenclador,int? varIdNomencladorDetalle)
		{
			PnAnexo item = new PnAnexo();
			
			item.Numero = varNumero;
			
			item.Prueba = varPrueba;
			
			item.Categoria = varCategoria;
			
			item.Precio = varPrecio;
			
			item.IdNomenclador = varIdNomenclador;
			
			item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAnexo,int? varNumero,string varPrueba,int? varCategoria,decimal? varPrecio,int? varIdNomenclador,int? varIdNomencladorDetalle)
		{
			PnAnexo item = new PnAnexo();
			
				item.IdAnexo = varIdAnexo;
			
				item.Numero = varNumero;
			
				item.Prueba = varPrueba;
			
				item.Categoria = varCategoria;
			
				item.Precio = varPrecio;
			
				item.IdNomenclador = varIdNomenclador;
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAnexoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PruebaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoriaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrecioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAnexo = @"id_anexo";
			 public static string Numero = @"numero";
			 public static string Prueba = @"prueba";
			 public static string Categoria = @"categoria";
			 public static string Precio = @"precio";
			 public static string IdNomenclador = @"id_nomenclador";
			 public static string IdNomencladorDetalle = @"id_nomenclador_detalle";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
