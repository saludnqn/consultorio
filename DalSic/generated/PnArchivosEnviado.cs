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
	/// Strongly-typed collection for the PnArchivosEnviado class.
	/// </summary>
    [Serializable]
	public partial class PnArchivosEnviadoCollection : ActiveList<PnArchivosEnviado, PnArchivosEnviadoCollection>
	{	   
		public PnArchivosEnviadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnArchivosEnviadoCollection</returns>
		public PnArchivosEnviadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnArchivosEnviado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_archivos_enviados table.
	/// </summary>
	[Serializable]
	public partial class PnArchivosEnviado : ActiveRecord<PnArchivosEnviado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnArchivosEnviado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnArchivosEnviado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnArchivosEnviado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnArchivosEnviado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_archivos_enviados", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdArchivosEnviados = new TableSchema.TableColumn(schema);
				colvarIdArchivosEnviados.ColumnName = "id_archivos_enviados";
				colvarIdArchivosEnviados.DataType = DbType.Int32;
				colvarIdArchivosEnviados.MaxLength = 0;
				colvarIdArchivosEnviados.AutoIncrement = true;
				colvarIdArchivosEnviados.IsNullable = false;
				colvarIdArchivosEnviados.IsPrimaryKey = true;
				colvarIdArchivosEnviados.IsForeignKey = false;
				colvarIdArchivosEnviados.IsReadOnly = false;
				colvarIdArchivosEnviados.DefaultSetting = @"";
				colvarIdArchivosEnviados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdArchivosEnviados);
				
				TableSchema.TableColumn colvarFechaGeneracion = new TableSchema.TableColumn(schema);
				colvarFechaGeneracion.ColumnName = "fecha_generacion";
				colvarFechaGeneracion.DataType = DbType.DateTime;
				colvarFechaGeneracion.MaxLength = 0;
				colvarFechaGeneracion.AutoIncrement = false;
				colvarFechaGeneracion.IsNullable = true;
				colvarFechaGeneracion.IsPrimaryKey = false;
				colvarFechaGeneracion.IsForeignKey = false;
				colvarFechaGeneracion.IsReadOnly = false;
				colvarFechaGeneracion.DefaultSetting = @"";
				colvarFechaGeneracion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaGeneracion);
				
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
				
				TableSchema.TableColumn colvarNombreArchivoEnviado = new TableSchema.TableColumn(schema);
				colvarNombreArchivoEnviado.ColumnName = "nombre_archivo_enviado";
				colvarNombreArchivoEnviado.DataType = DbType.AnsiString;
				colvarNombreArchivoEnviado.MaxLength = 50;
				colvarNombreArchivoEnviado.AutoIncrement = false;
				colvarNombreArchivoEnviado.IsNullable = true;
				colvarNombreArchivoEnviado.IsPrimaryKey = false;
				colvarNombreArchivoEnviado.IsForeignKey = false;
				colvarNombreArchivoEnviado.IsReadOnly = false;
				colvarNombreArchivoEnviado.DefaultSetting = @"";
				colvarNombreArchivoEnviado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreArchivoEnviado);
				
				TableSchema.TableColumn colvarCantidadRegistrosEnviados = new TableSchema.TableColumn(schema);
				colvarCantidadRegistrosEnviados.ColumnName = "cantidad_registros_enviados";
				colvarCantidadRegistrosEnviados.DataType = DbType.Int32;
				colvarCantidadRegistrosEnviados.MaxLength = 0;
				colvarCantidadRegistrosEnviados.AutoIncrement = false;
				colvarCantidadRegistrosEnviados.IsNullable = true;
				colvarCantidadRegistrosEnviados.IsPrimaryKey = false;
				colvarCantidadRegistrosEnviados.IsForeignKey = false;
				colvarCantidadRegistrosEnviados.IsReadOnly = false;
				colvarCantidadRegistrosEnviados.DefaultSetting = @"";
				colvarCantidadRegistrosEnviados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadRegistrosEnviados);
				
				TableSchema.TableColumn colvarIdComienzoLote = new TableSchema.TableColumn(schema);
				colvarIdComienzoLote.ColumnName = "id_comienzo_lote";
				colvarIdComienzoLote.DataType = DbType.AnsiString;
				colvarIdComienzoLote.MaxLength = 16;
				colvarIdComienzoLote.AutoIncrement = false;
				colvarIdComienzoLote.IsNullable = true;
				colvarIdComienzoLote.IsPrimaryKey = false;
				colvarIdComienzoLote.IsForeignKey = false;
				colvarIdComienzoLote.IsReadOnly = false;
				colvarIdComienzoLote.DefaultSetting = @"";
				colvarIdComienzoLote.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdComienzoLote);
				
				TableSchema.TableColumn colvarFechaRecepcionRespuesta = new TableSchema.TableColumn(schema);
				colvarFechaRecepcionRespuesta.ColumnName = "fecha_recepcion_respuesta";
				colvarFechaRecepcionRespuesta.DataType = DbType.DateTime;
				colvarFechaRecepcionRespuesta.MaxLength = 0;
				colvarFechaRecepcionRespuesta.AutoIncrement = false;
				colvarFechaRecepcionRespuesta.IsNullable = true;
				colvarFechaRecepcionRespuesta.IsPrimaryKey = false;
				colvarFechaRecepcionRespuesta.IsForeignKey = false;
				colvarFechaRecepcionRespuesta.IsReadOnly = false;
				colvarFechaRecepcionRespuesta.DefaultSetting = @"";
				colvarFechaRecepcionRespuesta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecepcionRespuesta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_archivos_enviados",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdArchivosEnviados")]
		[Bindable(true)]
		public int IdArchivosEnviados 
		{
			get { return GetColumnValue<int>(Columns.IdArchivosEnviados); }
			set { SetColumnValue(Columns.IdArchivosEnviados, value); }
		}
		  
		[XmlAttribute("FechaGeneracion")]
		[Bindable(true)]
		public DateTime? FechaGeneracion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaGeneracion); }
			set { SetColumnValue(Columns.FechaGeneracion, value); }
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
		  
		[XmlAttribute("NombreArchivoEnviado")]
		[Bindable(true)]
		public string NombreArchivoEnviado 
		{
			get { return GetColumnValue<string>(Columns.NombreArchivoEnviado); }
			set { SetColumnValue(Columns.NombreArchivoEnviado, value); }
		}
		  
		[XmlAttribute("CantidadRegistrosEnviados")]
		[Bindable(true)]
		public int? CantidadRegistrosEnviados 
		{
			get { return GetColumnValue<int?>(Columns.CantidadRegistrosEnviados); }
			set { SetColumnValue(Columns.CantidadRegistrosEnviados, value); }
		}
		  
		[XmlAttribute("IdComienzoLote")]
		[Bindable(true)]
		public string IdComienzoLote 
		{
			get { return GetColumnValue<string>(Columns.IdComienzoLote); }
			set { SetColumnValue(Columns.IdComienzoLote, value); }
		}
		  
		[XmlAttribute("FechaRecepcionRespuesta")]
		[Bindable(true)]
		public DateTime? FechaRecepcionRespuesta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRecepcionRespuesta); }
			set { SetColumnValue(Columns.FechaRecepcionRespuesta, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime? varFechaGeneracion,string varEstado,string varUsuario,string varNombreArchivoEnviado,int? varCantidadRegistrosEnviados,string varIdComienzoLote,DateTime? varFechaRecepcionRespuesta)
		{
			PnArchivosEnviado item = new PnArchivosEnviado();
			
			item.FechaGeneracion = varFechaGeneracion;
			
			item.Estado = varEstado;
			
			item.Usuario = varUsuario;
			
			item.NombreArchivoEnviado = varNombreArchivoEnviado;
			
			item.CantidadRegistrosEnviados = varCantidadRegistrosEnviados;
			
			item.IdComienzoLote = varIdComienzoLote;
			
			item.FechaRecepcionRespuesta = varFechaRecepcionRespuesta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdArchivosEnviados,DateTime? varFechaGeneracion,string varEstado,string varUsuario,string varNombreArchivoEnviado,int? varCantidadRegistrosEnviados,string varIdComienzoLote,DateTime? varFechaRecepcionRespuesta)
		{
			PnArchivosEnviado item = new PnArchivosEnviado();
			
				item.IdArchivosEnviados = varIdArchivosEnviados;
			
				item.FechaGeneracion = varFechaGeneracion;
			
				item.Estado = varEstado;
			
				item.Usuario = varUsuario;
			
				item.NombreArchivoEnviado = varNombreArchivoEnviado;
			
				item.CantidadRegistrosEnviados = varCantidadRegistrosEnviados;
			
				item.IdComienzoLote = varIdComienzoLote;
			
				item.FechaRecepcionRespuesta = varFechaRecepcionRespuesta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdArchivosEnviadosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaGeneracionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreArchivoEnviadoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadRegistrosEnviadosColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdComienzoLoteColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecepcionRespuestaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdArchivosEnviados = @"id_archivos_enviados";
			 public static string FechaGeneracion = @"fecha_generacion";
			 public static string Estado = @"estado";
			 public static string Usuario = @"usuario";
			 public static string NombreArchivoEnviado = @"nombre_archivo_enviado";
			 public static string CantidadRegistrosEnviados = @"cantidad_registros_enviados";
			 public static string IdComienzoLote = @"id_comienzo_lote";
			 public static string FechaRecepcionRespuesta = @"fecha_recepcion_respuesta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
