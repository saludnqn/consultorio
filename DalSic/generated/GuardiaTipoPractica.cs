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
	/// Strongly-typed collection for the GuardiaTipoPractica class.
	/// </summary>
    [Serializable]
	public partial class GuardiaTipoPracticaCollection : ActiveList<GuardiaTipoPractica, GuardiaTipoPracticaCollection>
	{	   
		public GuardiaTipoPracticaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaTipoPracticaCollection</returns>
		public GuardiaTipoPracticaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaTipoPractica o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_TipoPracticas table.
	/// </summary>
	[Serializable]
	public partial class GuardiaTipoPractica : ActiveRecord<GuardiaTipoPractica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaTipoPractica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaTipoPractica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaTipoPractica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaTipoPractica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_TipoPracticas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdPadre = new TableSchema.TableColumn(schema);
				colvarIdPadre.ColumnName = "idPadre";
				colvarIdPadre.DataType = DbType.Int32;
				colvarIdPadre.MaxLength = 0;
				colvarIdPadre.AutoIncrement = false;
				colvarIdPadre.IsNullable = true;
				colvarIdPadre.IsPrimaryKey = false;
				colvarIdPadre.IsForeignKey = false;
				colvarIdPadre.IsReadOnly = false;
				colvarIdPadre.DefaultSetting = @"";
				colvarIdPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPadre);
				
				TableSchema.TableColumn colvarClase = new TableSchema.TableColumn(schema);
				colvarClase.ColumnName = "clase";
				colvarClase.DataType = DbType.Int32;
				colvarClase.MaxLength = 0;
				colvarClase.AutoIncrement = false;
				colvarClase.IsNullable = true;
				colvarClase.IsPrimaryKey = false;
				colvarClase.IsForeignKey = false;
				colvarClase.IsReadOnly = false;
				colvarClase.DefaultSetting = @"";
				colvarClase.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClase);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarUrlIcono = new TableSchema.TableColumn(schema);
				colvarUrlIcono.ColumnName = "urlIcono";
				colvarUrlIcono.DataType = DbType.AnsiString;
				colvarUrlIcono.MaxLength = 200;
				colvarUrlIcono.AutoIncrement = false;
				colvarUrlIcono.IsNullable = true;
				colvarUrlIcono.IsPrimaryKey = false;
				colvarUrlIcono.IsForeignKey = false;
				colvarUrlIcono.IsReadOnly = false;
				colvarUrlIcono.DefaultSetting = @"";
				colvarUrlIcono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrlIcono);
				
				TableSchema.TableColumn colvarVinculadoPrestaciones = new TableSchema.TableColumn(schema);
				colvarVinculadoPrestaciones.ColumnName = "vinculadoPrestaciones";
				colvarVinculadoPrestaciones.DataType = DbType.Boolean;
				colvarVinculadoPrestaciones.MaxLength = 0;
				colvarVinculadoPrestaciones.AutoIncrement = false;
				colvarVinculadoPrestaciones.IsNullable = true;
				colvarVinculadoPrestaciones.IsPrimaryKey = false;
				colvarVinculadoPrestaciones.IsForeignKey = false;
				colvarVinculadoPrestaciones.IsReadOnly = false;
				colvarVinculadoPrestaciones.DefaultSetting = @"";
				colvarVinculadoPrestaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVinculadoPrestaciones);
				
				TableSchema.TableColumn colvarAdvertencia = new TableSchema.TableColumn(schema);
				colvarAdvertencia.ColumnName = "advertencia";
				colvarAdvertencia.DataType = DbType.AnsiString;
				colvarAdvertencia.MaxLength = -1;
				colvarAdvertencia.AutoIncrement = false;
				colvarAdvertencia.IsNullable = true;
				colvarAdvertencia.IsPrimaryKey = false;
				colvarAdvertencia.IsForeignKey = false;
				colvarAdvertencia.IsReadOnly = false;
				colvarAdvertencia.DefaultSetting = @"";
				colvarAdvertencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdvertencia);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_TipoPracticas",schema);
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
		  
		[XmlAttribute("IdPadre")]
		[Bindable(true)]
		public int? IdPadre 
		{
			get { return GetColumnValue<int?>(Columns.IdPadre); }
			set { SetColumnValue(Columns.IdPadre, value); }
		}
		  
		[XmlAttribute("Clase")]
		[Bindable(true)]
		public int? Clase 
		{
			get { return GetColumnValue<int?>(Columns.Clase); }
			set { SetColumnValue(Columns.Clase, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("UrlIcono")]
		[Bindable(true)]
		public string UrlIcono 
		{
			get { return GetColumnValue<string>(Columns.UrlIcono); }
			set { SetColumnValue(Columns.UrlIcono, value); }
		}
		  
		[XmlAttribute("VinculadoPrestaciones")]
		[Bindable(true)]
		public bool? VinculadoPrestaciones 
		{
			get { return GetColumnValue<bool?>(Columns.VinculadoPrestaciones); }
			set { SetColumnValue(Columns.VinculadoPrestaciones, value); }
		}
		  
		[XmlAttribute("Advertencia")]
		[Bindable(true)]
		public string Advertencia 
		{
			get { return GetColumnValue<string>(Columns.Advertencia); }
			set { SetColumnValue(Columns.Advertencia, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varId,int? varIdPadre,int? varClase,string varNombre,string varUrlIcono,bool? varVinculadoPrestaciones,string varAdvertencia)
		{
			GuardiaTipoPractica item = new GuardiaTipoPractica();
			
			item.Id = varId;
			
			item.IdPadre = varIdPadre;
			
			item.Clase = varClase;
			
			item.Nombre = varNombre;
			
			item.UrlIcono = varUrlIcono;
			
			item.VinculadoPrestaciones = varVinculadoPrestaciones;
			
			item.Advertencia = varAdvertencia;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdPadre,int? varClase,string varNombre,string varUrlIcono,bool? varVinculadoPrestaciones,string varAdvertencia)
		{
			GuardiaTipoPractica item = new GuardiaTipoPractica();
			
				item.Id = varId;
			
				item.IdPadre = varIdPadre;
			
				item.Clase = varClase;
			
				item.Nombre = varNombre;
			
				item.UrlIcono = varUrlIcono;
			
				item.VinculadoPrestaciones = varVinculadoPrestaciones;
			
				item.Advertencia = varAdvertencia;
			
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
        
        
        
        public static TableSchema.TableColumn IdPadreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaseColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlIconoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn VinculadoPrestacionesColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AdvertenciaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdPadre = @"idPadre";
			 public static string Clase = @"clase";
			 public static string Nombre = @"nombre";
			 public static string UrlIcono = @"urlIcono";
			 public static string VinculadoPrestaciones = @"vinculadoPrestaciones";
			 public static string Advertencia = @"advertencia";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
