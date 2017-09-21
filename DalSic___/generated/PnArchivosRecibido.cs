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
	/// Strongly-typed collection for the PnArchivosRecibido class.
	/// </summary>
    [Serializable]
	public partial class PnArchivosRecibidoCollection : ActiveList<PnArchivosRecibido, PnArchivosRecibidoCollection>
	{	   
		public PnArchivosRecibidoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnArchivosRecibidoCollection</returns>
		public PnArchivosRecibidoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnArchivosRecibido o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_archivos_recibidos table.
	/// </summary>
	[Serializable]
	public partial class PnArchivosRecibido : ActiveRecord<PnArchivosRecibido>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnArchivosRecibido()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnArchivosRecibido(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnArchivosRecibido(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnArchivosRecibido(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_archivos_recibidos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdArchivosRecibidos = new TableSchema.TableColumn(schema);
				colvarIdArchivosRecibidos.ColumnName = "id_archivos_recibidos";
				colvarIdArchivosRecibidos.DataType = DbType.Int32;
				colvarIdArchivosRecibidos.MaxLength = 0;
				colvarIdArchivosRecibidos.AutoIncrement = true;
				colvarIdArchivosRecibidos.IsNullable = false;
				colvarIdArchivosRecibidos.IsPrimaryKey = true;
				colvarIdArchivosRecibidos.IsForeignKey = false;
				colvarIdArchivosRecibidos.IsReadOnly = false;
				colvarIdArchivosRecibidos.DefaultSetting = @"";
				colvarIdArchivosRecibidos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdArchivosRecibidos);
				
				TableSchema.TableColumn colvarIdArchivosEnviados = new TableSchema.TableColumn(schema);
				colvarIdArchivosEnviados.ColumnName = "id_archivos_enviados";
				colvarIdArchivosEnviados.DataType = DbType.Int32;
				colvarIdArchivosEnviados.MaxLength = 0;
				colvarIdArchivosEnviados.AutoIncrement = false;
				colvarIdArchivosEnviados.IsNullable = false;
				colvarIdArchivosEnviados.IsPrimaryKey = false;
				colvarIdArchivosEnviados.IsForeignKey = false;
				colvarIdArchivosEnviados.IsReadOnly = false;
				colvarIdArchivosEnviados.DefaultSetting = @"";
				colvarIdArchivosEnviados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdArchivosEnviados);
				
				TableSchema.TableColumn colvarFechaRecepcion = new TableSchema.TableColumn(schema);
				colvarFechaRecepcion.ColumnName = "fecha_recepcion";
				colvarFechaRecepcion.DataType = DbType.DateTime;
				colvarFechaRecepcion.MaxLength = 0;
				colvarFechaRecepcion.AutoIncrement = false;
				colvarFechaRecepcion.IsNullable = true;
				colvarFechaRecepcion.IsPrimaryKey = false;
				colvarFechaRecepcion.IsForeignKey = false;
				colvarFechaRecepcion.IsReadOnly = false;
				colvarFechaRecepcion.DefaultSetting = @"";
				colvarFechaRecepcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecepcion);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.AnsiString;
				colvarEstado.MaxLength = 1;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = 10;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				TableSchema.TableColumn colvarNombreArchivo = new TableSchema.TableColumn(schema);
				colvarNombreArchivo.ColumnName = "nombre_archivo";
				colvarNombreArchivo.DataType = DbType.AnsiString;
				colvarNombreArchivo.MaxLength = 100;
				colvarNombreArchivo.AutoIncrement = false;
				colvarNombreArchivo.IsNullable = true;
				colvarNombreArchivo.IsPrimaryKey = false;
				colvarNombreArchivo.IsForeignKey = false;
				colvarNombreArchivo.IsReadOnly = false;
				colvarNombreArchivo.DefaultSetting = @"";
				colvarNombreArchivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreArchivo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_archivos_recibidos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdArchivosRecibidos")]
		[Bindable(true)]
		public int IdArchivosRecibidos 
		{
			get { return GetColumnValue<int>(Columns.IdArchivosRecibidos); }
			set { SetColumnValue(Columns.IdArchivosRecibidos, value); }
		}
		  
		[XmlAttribute("IdArchivosEnviados")]
		[Bindable(true)]
		public int IdArchivosEnviados 
		{
			get { return GetColumnValue<int>(Columns.IdArchivosEnviados); }
			set { SetColumnValue(Columns.IdArchivosEnviados, value); }
		}
		  
		[XmlAttribute("FechaRecepcion")]
		[Bindable(true)]
		public DateTime? FechaRecepcion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRecepcion); }
			set { SetColumnValue(Columns.FechaRecepcion, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public string Estado 
		{
			get { return GetColumnValue<string>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("NombreArchivo")]
		[Bindable(true)]
		public string NombreArchivo 
		{
			get { return GetColumnValue<string>(Columns.NombreArchivo); }
			set { SetColumnValue(Columns.NombreArchivo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdArchivosEnviados,DateTime? varFechaRecepcion,string varEstado,string varUsuario,string varNombreArchivo)
		{
			PnArchivosRecibido item = new PnArchivosRecibido();
			
			item.IdArchivosEnviados = varIdArchivosEnviados;
			
			item.FechaRecepcion = varFechaRecepcion;
			
			item.Estado = varEstado;
			
			item.Usuario = varUsuario;
			
			item.NombreArchivo = varNombreArchivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdArchivosRecibidos,int varIdArchivosEnviados,DateTime? varFechaRecepcion,string varEstado,string varUsuario,string varNombreArchivo)
		{
			PnArchivosRecibido item = new PnArchivosRecibido();
			
				item.IdArchivosRecibidos = varIdArchivosRecibidos;
			
				item.IdArchivosEnviados = varIdArchivosEnviados;
			
				item.FechaRecepcion = varFechaRecepcion;
			
				item.Estado = varEstado;
			
				item.Usuario = varUsuario;
			
				item.NombreArchivo = varNombreArchivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdArchivosRecibidosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdArchivosEnviadosColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecepcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreArchivoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdArchivosRecibidos = @"id_archivos_recibidos";
			 public static string IdArchivosEnviados = @"id_archivos_enviados";
			 public static string FechaRecepcion = @"fecha_recepcion";
			 public static string Estado = @"estado";
			 public static string Usuario = @"usuario";
			 public static string NombreArchivo = @"nombre_archivo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
