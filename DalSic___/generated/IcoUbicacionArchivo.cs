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
	/// Strongly-typed collection for the IcoUbicacionArchivo class.
	/// </summary>
    [Serializable]
	public partial class IcoUbicacionArchivoCollection : ActiveList<IcoUbicacionArchivo, IcoUbicacionArchivoCollection>
	{	   
		public IcoUbicacionArchivoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>IcoUbicacionArchivoCollection</returns>
		public IcoUbicacionArchivoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                IcoUbicacionArchivo o = this[i];
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
	/// This is an ActiveRecord class which wraps the ICO_UbicacionArchivos table.
	/// </summary>
	[Serializable]
	public partial class IcoUbicacionArchivo : ActiveRecord<IcoUbicacionArchivo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public IcoUbicacionArchivo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public IcoUbicacionArchivo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public IcoUbicacionArchivo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public IcoUbicacionArchivo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ICO_UbicacionArchivos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdUbicacionArchivo = new TableSchema.TableColumn(schema);
				colvarIdUbicacionArchivo.ColumnName = "idUbicacionArchivo";
				colvarIdUbicacionArchivo.DataType = DbType.Int32;
				colvarIdUbicacionArchivo.MaxLength = 0;
				colvarIdUbicacionArchivo.AutoIncrement = true;
				colvarIdUbicacionArchivo.IsNullable = false;
				colvarIdUbicacionArchivo.IsPrimaryKey = true;
				colvarIdUbicacionArchivo.IsForeignKey = false;
				colvarIdUbicacionArchivo.IsReadOnly = false;
				colvarIdUbicacionArchivo.DefaultSetting = @"";
				colvarIdUbicacionArchivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUbicacionArchivo);
				
				TableSchema.TableColumn colvarIdInterconsulta = new TableSchema.TableColumn(schema);
				colvarIdInterconsulta.ColumnName = "idInterconsulta";
				colvarIdInterconsulta.DataType = DbType.Int32;
				colvarIdInterconsulta.MaxLength = 0;
				colvarIdInterconsulta.AutoIncrement = false;
				colvarIdInterconsulta.IsNullable = false;
				colvarIdInterconsulta.IsPrimaryKey = false;
				colvarIdInterconsulta.IsForeignKey = false;
				colvarIdInterconsulta.IsReadOnly = false;
				colvarIdInterconsulta.DefaultSetting = @"";
				colvarIdInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInterconsulta);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 500;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarUbicacion = new TableSchema.TableColumn(schema);
				colvarUbicacion.ColumnName = "ubicacion";
				colvarUbicacion.DataType = DbType.AnsiString;
				colvarUbicacion.MaxLength = 500;
				colvarUbicacion.AutoIncrement = false;
				colvarUbicacion.IsNullable = true;
				colvarUbicacion.IsPrimaryKey = false;
				colvarUbicacion.IsForeignKey = false;
				colvarUbicacion.IsReadOnly = false;
				colvarUbicacion.DefaultSetting = @"";
				colvarUbicacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUbicacion);
				
				TableSchema.TableColumn colvarDetalle = new TableSchema.TableColumn(schema);
				colvarDetalle.ColumnName = "detalle";
				colvarDetalle.DataType = DbType.AnsiString;
				colvarDetalle.MaxLength = 500;
				colvarDetalle.AutoIncrement = false;
				colvarDetalle.IsNullable = true;
				colvarDetalle.IsPrimaryKey = false;
				colvarDetalle.IsForeignKey = false;
				colvarDetalle.IsReadOnly = false;
				colvarDetalle.DefaultSetting = @"";
				colvarDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetalle);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("ICO_UbicacionArchivos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdUbicacionArchivo")]
		[Bindable(true)]
		public int IdUbicacionArchivo 
		{
			get { return GetColumnValue<int>(Columns.IdUbicacionArchivo); }
			set { SetColumnValue(Columns.IdUbicacionArchivo, value); }
		}
		  
		[XmlAttribute("IdInterconsulta")]
		[Bindable(true)]
		public int IdInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdInterconsulta); }
			set { SetColumnValue(Columns.IdInterconsulta, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Ubicacion")]
		[Bindable(true)]
		public string Ubicacion 
		{
			get { return GetColumnValue<string>(Columns.Ubicacion); }
			set { SetColumnValue(Columns.Ubicacion, value); }
		}
		  
		[XmlAttribute("Detalle")]
		[Bindable(true)]
		public string Detalle 
		{
			get { return GetColumnValue<string>(Columns.Detalle); }
			set { SetColumnValue(Columns.Detalle, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInterconsulta,string varNombre,string varUbicacion,string varDetalle)
		{
			IcoUbicacionArchivo item = new IcoUbicacionArchivo();
			
			item.IdInterconsulta = varIdInterconsulta;
			
			item.Nombre = varNombre;
			
			item.Ubicacion = varUbicacion;
			
			item.Detalle = varDetalle;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdUbicacionArchivo,int varIdInterconsulta,string varNombre,string varUbicacion,string varDetalle)
		{
			IcoUbicacionArchivo item = new IcoUbicacionArchivo();
			
				item.IdUbicacionArchivo = varIdUbicacionArchivo;
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.Nombre = varNombre;
			
				item.Ubicacion = varUbicacion;
			
				item.Detalle = varDetalle;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdUbicacionArchivoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UbicacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DetalleColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdUbicacionArchivo = @"idUbicacionArchivo";
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string Nombre = @"nombre";
			 public static string Ubicacion = @"ubicacion";
			 public static string Detalle = @"detalle";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
