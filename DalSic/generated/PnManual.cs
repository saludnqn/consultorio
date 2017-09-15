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
	/// Strongly-typed collection for the PnManual class.
	/// </summary>
    [Serializable]
	public partial class PnManualCollection : ActiveList<PnManual, PnManualCollection>
	{	   
		public PnManualCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnManualCollection</returns>
		public PnManualCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnManual o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_manual table.
	/// </summary>
	[Serializable]
	public partial class PnManual : ActiveRecord<PnManual>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnManual()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnManual(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnManual(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnManual(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_manual", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdManual = new TableSchema.TableColumn(schema);
				colvarIdManual.ColumnName = "id_manual";
				colvarIdManual.DataType = DbType.Int32;
				colvarIdManual.MaxLength = 0;
				colvarIdManual.AutoIncrement = true;
				colvarIdManual.IsNullable = false;
				colvarIdManual.IsPrimaryKey = true;
				colvarIdManual.IsForeignKey = false;
				colvarIdManual.IsReadOnly = false;
				colvarIdManual.DefaultSetting = @"";
				colvarIdManual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdManual);
				
				TableSchema.TableColumn colvarTitulo = new TableSchema.TableColumn(schema);
				colvarTitulo.ColumnName = "titulo";
				colvarTitulo.DataType = DbType.AnsiString;
				colvarTitulo.MaxLength = -1;
				colvarTitulo.AutoIncrement = false;
				colvarTitulo.IsNullable = true;
				colvarTitulo.IsPrimaryKey = false;
				colvarTitulo.IsForeignKey = false;
				colvarTitulo.IsReadOnly = false;
				colvarTitulo.DefaultSetting = @"";
				colvarTitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitulo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.Int16;
				colvarEstado.MaxLength = 0;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarHistorial = new TableSchema.TableColumn(schema);
				colvarHistorial.ColumnName = "historial";
				colvarHistorial.DataType = DbType.Int16;
				colvarHistorial.MaxLength = 0;
				colvarHistorial.AutoIncrement = false;
				colvarHistorial.IsNullable = true;
				colvarHistorial.IsPrimaryKey = false;
				colvarHistorial.IsForeignKey = false;
				colvarHistorial.IsReadOnly = false;
				colvarHistorial.DefaultSetting = @"";
				colvarHistorial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHistorial);
				
				TableSchema.TableColumn colvarIdDistrito = new TableSchema.TableColumn(schema);
				colvarIdDistrito.ColumnName = "id_distrito";
				colvarIdDistrito.DataType = DbType.Int32;
				colvarIdDistrito.MaxLength = 0;
				colvarIdDistrito.AutoIncrement = false;
				colvarIdDistrito.IsNullable = true;
				colvarIdDistrito.IsPrimaryKey = false;
				colvarIdDistrito.IsForeignKey = false;
				colvarIdDistrito.IsReadOnly = false;
				colvarIdDistrito.DefaultSetting = @"";
				colvarIdDistrito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDistrito);
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "id_clasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = false;
				colvarIdClasificacion.IsNullable = true;
				colvarIdClasificacion.IsPrimaryKey = false;
				colvarIdClasificacion.IsForeignKey = false;
				colvarIdClasificacion.IsReadOnly = false;
				colvarIdClasificacion.DefaultSetting = @"";
				colvarIdClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdClasificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_manual",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdManual")]
		[Bindable(true)]
		public int IdManual 
		{
			get { return GetColumnValue<int>(Columns.IdManual); }
			set { SetColumnValue(Columns.IdManual, value); }
		}
		  
		[XmlAttribute("Titulo")]
		[Bindable(true)]
		public string Titulo 
		{
			get { return GetColumnValue<string>(Columns.Titulo); }
			set { SetColumnValue(Columns.Titulo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public short? Estado 
		{
			get { return GetColumnValue<short?>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Historial")]
		[Bindable(true)]
		public short? Historial 
		{
			get { return GetColumnValue<short?>(Columns.Historial); }
			set { SetColumnValue(Columns.Historial, value); }
		}
		  
		[XmlAttribute("IdDistrito")]
		[Bindable(true)]
		public int? IdDistrito 
		{
			get { return GetColumnValue<int?>(Columns.IdDistrito); }
			set { SetColumnValue(Columns.IdDistrito, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int? IdClasificacion 
		{
			get { return GetColumnValue<int?>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTitulo,string varDescripcion,short? varEstado,short? varHistorial,int? varIdDistrito,int? varIdClasificacion)
		{
			PnManual item = new PnManual();
			
			item.Titulo = varTitulo;
			
			item.Descripcion = varDescripcion;
			
			item.Estado = varEstado;
			
			item.Historial = varHistorial;
			
			item.IdDistrito = varIdDistrito;
			
			item.IdClasificacion = varIdClasificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdManual,string varTitulo,string varDescripcion,short? varEstado,short? varHistorial,int? varIdDistrito,int? varIdClasificacion)
		{
			PnManual item = new PnManual();
			
				item.IdManual = varIdManual;
			
				item.Titulo = varTitulo;
			
				item.Descripcion = varDescripcion;
			
				item.Estado = varEstado;
			
				item.Historial = varHistorial;
			
				item.IdDistrito = varIdDistrito;
			
				item.IdClasificacion = varIdClasificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdManualColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TituloColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn HistorialColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDistritoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdManual = @"id_manual";
			 public static string Titulo = @"titulo";
			 public static string Descripcion = @"descripcion";
			 public static string Estado = @"estado";
			 public static string Historial = @"historial";
			 public static string IdDistrito = @"id_distrito";
			 public static string IdClasificacion = @"id_clasificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
