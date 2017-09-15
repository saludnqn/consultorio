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
	/// Strongly-typed collection for the PnLogPrestacion class.
	/// </summary>
    [Serializable]
	public partial class PnLogPrestacionCollection : ActiveList<PnLogPrestacion, PnLogPrestacionCollection>
	{	   
		public PnLogPrestacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLogPrestacionCollection</returns>
		public PnLogPrestacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLogPrestacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_log_prestacion table.
	/// </summary>
	[Serializable]
	public partial class PnLogPrestacion : ActiveRecord<PnLogPrestacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLogPrestacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLogPrestacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLogPrestacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLogPrestacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_log_prestacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLogPrestacion = new TableSchema.TableColumn(schema);
				colvarIdLogPrestacion.ColumnName = "id_log_prestacion";
				colvarIdLogPrestacion.DataType = DbType.Int32;
				colvarIdLogPrestacion.MaxLength = 0;
				colvarIdLogPrestacion.AutoIncrement = true;
				colvarIdLogPrestacion.IsNullable = false;
				colvarIdLogPrestacion.IsPrimaryKey = true;
				colvarIdLogPrestacion.IsForeignKey = false;
				colvarIdLogPrestacion.IsReadOnly = false;
				colvarIdLogPrestacion.DefaultSetting = @"";
				colvarIdLogPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLogPrestacion);
				
				TableSchema.TableColumn colvarIdPrestacion = new TableSchema.TableColumn(schema);
				colvarIdPrestacion.ColumnName = "id_prestacion";
				colvarIdPrestacion.DataType = DbType.Int32;
				colvarIdPrestacion.MaxLength = 0;
				colvarIdPrestacion.AutoIncrement = false;
				colvarIdPrestacion.IsNullable = false;
				colvarIdPrestacion.IsPrimaryKey = false;
				colvarIdPrestacion.IsForeignKey = false;
				colvarIdPrestacion.IsReadOnly = false;
				colvarIdPrestacion.DefaultSetting = @"";
				colvarIdPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrestacion);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
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
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = -1;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_log_prestacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLogPrestacion")]
		[Bindable(true)]
		public int IdLogPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdLogPrestacion); }
			set { SetColumnValue(Columns.IdLogPrestacion, value); }
		}
		  
		[XmlAttribute("IdPrestacion")]
		[Bindable(true)]
		public int IdPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdPrestacion); }
			set { SetColumnValue(Columns.IdPrestacion, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPrestacion,DateTime? varFecha,string varTipo,string varDescripcion,string varUsuario)
		{
			PnLogPrestacion item = new PnLogPrestacion();
			
			item.IdPrestacion = varIdPrestacion;
			
			item.Fecha = varFecha;
			
			item.Tipo = varTipo;
			
			item.Descripcion = varDescripcion;
			
			item.Usuario = varUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLogPrestacion,int varIdPrestacion,DateTime? varFecha,string varTipo,string varDescripcion,string varUsuario)
		{
			PnLogPrestacion item = new PnLogPrestacion();
			
				item.IdLogPrestacion = varIdLogPrestacion;
			
				item.IdPrestacion = varIdPrestacion;
			
				item.Fecha = varFecha;
			
				item.Tipo = varTipo;
			
				item.Descripcion = varDescripcion;
			
				item.Usuario = varUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLogPrestacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPrestacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLogPrestacion = @"id_log_prestacion";
			 public static string IdPrestacion = @"id_prestacion";
			 public static string Fecha = @"fecha";
			 public static string Tipo = @"tipo";
			 public static string Descripcion = @"descripcion";
			 public static string Usuario = @"usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
