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
	/// Strongly-typed collection for the PnArchivoManual class.
	/// </summary>
    [Serializable]
	public partial class PnArchivoManualCollection : ActiveList<PnArchivoManual, PnArchivoManualCollection>
	{	   
		public PnArchivoManualCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnArchivoManualCollection</returns>
		public PnArchivoManualCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnArchivoManual o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_archivo_manual table.
	/// </summary>
	[Serializable]
	public partial class PnArchivoManual : ActiveRecord<PnArchivoManual>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnArchivoManual()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnArchivoManual(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnArchivoManual(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnArchivoManual(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_archivo_manual", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdArchivoManual = new TableSchema.TableColumn(schema);
				colvarIdArchivoManual.ColumnName = "id_archivo_manual";
				colvarIdArchivoManual.DataType = DbType.Int32;
				colvarIdArchivoManual.MaxLength = 0;
				colvarIdArchivoManual.AutoIncrement = true;
				colvarIdArchivoManual.IsNullable = false;
				colvarIdArchivoManual.IsPrimaryKey = true;
				colvarIdArchivoManual.IsForeignKey = false;
				colvarIdArchivoManual.IsReadOnly = false;
				colvarIdArchivoManual.DefaultSetting = @"";
				colvarIdArchivoManual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdArchivoManual);
				
				TableSchema.TableColumn colvarIdManual = new TableSchema.TableColumn(schema);
				colvarIdManual.ColumnName = "id_manual";
				colvarIdManual.DataType = DbType.Int32;
				colvarIdManual.MaxLength = 0;
				colvarIdManual.AutoIncrement = false;
				colvarIdManual.IsNullable = false;
				colvarIdManual.IsPrimaryKey = false;
				colvarIdManual.IsForeignKey = false;
				colvarIdManual.IsReadOnly = false;
				colvarIdManual.DefaultSetting = @"";
				colvarIdManual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdManual);
				
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
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.AnsiString;
				colvarTipo.MaxLength = -1;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarTamaño = new TableSchema.TableColumn(schema);
				colvarTamaño.ColumnName = "tamaño";
				colvarTamaño.DataType = DbType.Int32;
				colvarTamaño.MaxLength = 0;
				colvarTamaño.AutoIncrement = false;
				colvarTamaño.IsNullable = true;
				colvarTamaño.IsPrimaryKey = false;
				colvarTamaño.IsForeignKey = false;
				colvarTamaño.IsReadOnly = false;
				colvarTamaño.DefaultSetting = @"";
				colvarTamaño.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTamaño);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_archivo_manual",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdArchivoManual")]
		[Bindable(true)]
		public int IdArchivoManual 
		{
			get { return GetColumnValue<int>(Columns.IdArchivoManual); }
			set { SetColumnValue(Columns.IdArchivoManual, value); }
		}
		  
		[XmlAttribute("IdManual")]
		[Bindable(true)]
		public int IdManual 
		{
			get { return GetColumnValue<int>(Columns.IdManual); }
			set { SetColumnValue(Columns.IdManual, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Tamaño")]
		[Bindable(true)]
		public int? Tamaño 
		{
			get { return GetColumnValue<int?>(Columns.Tamaño); }
			set { SetColumnValue(Columns.Tamaño, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdManual,string varNombre,string varTipo,int? varTamaño)
		{
			PnArchivoManual item = new PnArchivoManual();
			
			item.IdManual = varIdManual;
			
			item.Nombre = varNombre;
			
			item.Tipo = varTipo;
			
			item.Tamaño = varTamaño;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdArchivoManual,int varIdManual,string varNombre,string varTipo,int? varTamaño)
		{
			PnArchivoManual item = new PnArchivoManual();
			
				item.IdArchivoManual = varIdArchivoManual;
			
				item.IdManual = varIdManual;
			
				item.Nombre = varNombre;
			
				item.Tipo = varTipo;
			
				item.Tamaño = varTamaño;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdArchivoManualColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdManualColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TamañoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdArchivoManual = @"id_archivo_manual";
			 public static string IdManual = @"id_manual";
			 public static string Nombre = @"nombre";
			 public static string Tipo = @"tipo";
			 public static string Tamaño = @"tamaño";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
