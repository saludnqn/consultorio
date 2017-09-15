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
	/// Strongly-typed collection for the IcoDialogoInterconsultum class.
	/// </summary>
    [Serializable]
	public partial class IcoDialogoInterconsultumCollection : ActiveList<IcoDialogoInterconsultum, IcoDialogoInterconsultumCollection>
	{	   
		public IcoDialogoInterconsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>IcoDialogoInterconsultumCollection</returns>
		public IcoDialogoInterconsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                IcoDialogoInterconsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the ICO_DialogoInterconsulta table.
	/// </summary>
	[Serializable]
	public partial class IcoDialogoInterconsultum : ActiveRecord<IcoDialogoInterconsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public IcoDialogoInterconsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public IcoDialogoInterconsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public IcoDialogoInterconsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public IcoDialogoInterconsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ICO_DialogoInterconsulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDialogoInterconsulta = new TableSchema.TableColumn(schema);
				colvarIdDialogoInterconsulta.ColumnName = "idDialogoInterconsulta";
				colvarIdDialogoInterconsulta.DataType = DbType.Int32;
				colvarIdDialogoInterconsulta.MaxLength = 0;
				colvarIdDialogoInterconsulta.AutoIncrement = true;
				colvarIdDialogoInterconsulta.IsNullable = false;
				colvarIdDialogoInterconsulta.IsPrimaryKey = true;
				colvarIdDialogoInterconsulta.IsForeignKey = false;
				colvarIdDialogoInterconsulta.IsReadOnly = false;
				colvarIdDialogoInterconsulta.DefaultSetting = @"";
				colvarIdDialogoInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDialogoInterconsulta);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = false;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				colvarIdProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = false;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = false;
				colvarIdEspecialidad.IsReadOnly = false;
				colvarIdEspecialidad.DefaultSetting = @"";
				colvarIdEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEspecialidad);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 6000;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarRespuesta = new TableSchema.TableColumn(schema);
				colvarRespuesta.ColumnName = "respuesta";
				colvarRespuesta.DataType = DbType.AnsiString;
				colvarRespuesta.MaxLength = 6000;
				colvarRespuesta.AutoIncrement = false;
				colvarRespuesta.IsNullable = false;
				colvarRespuesta.IsPrimaryKey = false;
				colvarRespuesta.IsForeignKey = false;
				colvarRespuesta.IsReadOnly = false;
				colvarRespuesta.DefaultSetting = @"";
				colvarRespuesta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRespuesta);
				
				TableSchema.TableColumn colvarIdZona = new TableSchema.TableColumn(schema);
				colvarIdZona.ColumnName = "idZona";
				colvarIdZona.DataType = DbType.Int32;
				colvarIdZona.MaxLength = 0;
				colvarIdZona.AutoIncrement = false;
				colvarIdZona.IsNullable = true;
				colvarIdZona.IsPrimaryKey = false;
				colvarIdZona.IsForeignKey = false;
				colvarIdZona.IsReadOnly = false;
				colvarIdZona.DefaultSetting = @"";
				colvarIdZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdZona);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdUsuarioCarga = new TableSchema.TableColumn(schema);
				colvarIdUsuarioCarga.ColumnName = "idUsuarioCarga";
				colvarIdUsuarioCarga.DataType = DbType.Int32;
				colvarIdUsuarioCarga.MaxLength = 0;
				colvarIdUsuarioCarga.AutoIncrement = false;
				colvarIdUsuarioCarga.IsNullable = true;
				colvarIdUsuarioCarga.IsPrimaryKey = false;
				colvarIdUsuarioCarga.IsForeignKey = false;
				colvarIdUsuarioCarga.IsReadOnly = false;
				colvarIdUsuarioCarga.DefaultSetting = @"";
				colvarIdUsuarioCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioCarga);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("ICO_DialogoInterconsulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDialogoInterconsulta")]
		[Bindable(true)]
		public int IdDialogoInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdDialogoInterconsulta); }
			set { SetColumnValue(Columns.IdDialogoInterconsulta, value); }
		}
		  
		[XmlAttribute("IdInterconsulta")]
		[Bindable(true)]
		public int IdInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdInterconsulta); }
			set { SetColumnValue(Columns.IdInterconsulta, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int IdEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Respuesta")]
		[Bindable(true)]
		public string Respuesta 
		{
			get { return GetColumnValue<string>(Columns.Respuesta); }
			set { SetColumnValue(Columns.Respuesta, value); }
		}
		  
		[XmlAttribute("IdZona")]
		[Bindable(true)]
		public int? IdZona 
		{
			get { return GetColumnValue<int?>(Columns.IdZona); }
			set { SetColumnValue(Columns.IdZona, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdUsuarioCarga")]
		[Bindable(true)]
		public int? IdUsuarioCarga 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuarioCarga); }
			set { SetColumnValue(Columns.IdUsuarioCarga, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInterconsulta,DateTime varFecha,int varIdProfesional,int varIdEspecialidad,string varDescripcion,string varRespuesta,int? varIdZona,int? varIdEfector,int? varIdUsuarioCarga)
		{
			IcoDialogoInterconsultum item = new IcoDialogoInterconsultum();
			
			item.IdInterconsulta = varIdInterconsulta;
			
			item.Fecha = varFecha;
			
			item.IdProfesional = varIdProfesional;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.Descripcion = varDescripcion;
			
			item.Respuesta = varRespuesta;
			
			item.IdZona = varIdZona;
			
			item.IdEfector = varIdEfector;
			
			item.IdUsuarioCarga = varIdUsuarioCarga;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDialogoInterconsulta,int varIdInterconsulta,DateTime varFecha,int varIdProfesional,int varIdEspecialidad,string varDescripcion,string varRespuesta,int? varIdZona,int? varIdEfector,int? varIdUsuarioCarga)
		{
			IcoDialogoInterconsultum item = new IcoDialogoInterconsultum();
			
				item.IdDialogoInterconsulta = varIdDialogoInterconsulta;
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.Fecha = varFecha;
			
				item.IdProfesional = varIdProfesional;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.Descripcion = varDescripcion;
			
				item.Respuesta = varRespuesta;
			
				item.IdZona = varIdZona;
			
				item.IdEfector = varIdEfector;
			
				item.IdUsuarioCarga = varIdUsuarioCarga;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDialogoInterconsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn RespuestaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdZonaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioCargaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDialogoInterconsulta = @"idDialogoInterconsulta";
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string Fecha = @"fecha";
			 public static string IdProfesional = @"idProfesional";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string Descripcion = @"descripcion";
			 public static string Respuesta = @"respuesta";
			 public static string IdZona = @"idZona";
			 public static string IdEfector = @"idEfector";
			 public static string IdUsuarioCarga = @"idUsuarioCarga";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
