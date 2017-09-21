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
	/// Strongly-typed collection for the IcoDestinatarioInterconsultum class.
	/// </summary>
    [Serializable]
	public partial class IcoDestinatarioInterconsultumCollection : ActiveList<IcoDestinatarioInterconsultum, IcoDestinatarioInterconsultumCollection>
	{	   
		public IcoDestinatarioInterconsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>IcoDestinatarioInterconsultumCollection</returns>
		public IcoDestinatarioInterconsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                IcoDestinatarioInterconsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the ICO_DestinatarioInterconsulta table.
	/// </summary>
	[Serializable]
	public partial class IcoDestinatarioInterconsultum : ActiveRecord<IcoDestinatarioInterconsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public IcoDestinatarioInterconsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public IcoDestinatarioInterconsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public IcoDestinatarioInterconsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public IcoDestinatarioInterconsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ICO_DestinatarioInterconsulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDestinatariosInterconsulta = new TableSchema.TableColumn(schema);
				colvarIdDestinatariosInterconsulta.ColumnName = "idDestinatariosInterconsulta";
				colvarIdDestinatariosInterconsulta.DataType = DbType.Int32;
				colvarIdDestinatariosInterconsulta.MaxLength = 0;
				colvarIdDestinatariosInterconsulta.AutoIncrement = true;
				colvarIdDestinatariosInterconsulta.IsNullable = false;
				colvarIdDestinatariosInterconsulta.IsPrimaryKey = true;
				colvarIdDestinatariosInterconsulta.IsForeignKey = false;
				colvarIdDestinatariosInterconsulta.IsReadOnly = false;
				colvarIdDestinatariosInterconsulta.DefaultSetting = @"";
				colvarIdDestinatariosInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDestinatariosInterconsulta);
				
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
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.AnsiString;
				colvarEstado.MaxLength = 1000;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarTurnoOtorgadoFecha = new TableSchema.TableColumn(schema);
				colvarTurnoOtorgadoFecha.ColumnName = "turnoOtorgadoFecha";
				colvarTurnoOtorgadoFecha.DataType = DbType.DateTime;
				colvarTurnoOtorgadoFecha.MaxLength = 0;
				colvarTurnoOtorgadoFecha.AutoIncrement = false;
				colvarTurnoOtorgadoFecha.IsNullable = true;
				colvarTurnoOtorgadoFecha.IsPrimaryKey = false;
				colvarTurnoOtorgadoFecha.IsForeignKey = false;
				colvarTurnoOtorgadoFecha.IsReadOnly = false;
				colvarTurnoOtorgadoFecha.DefaultSetting = @"";
				colvarTurnoOtorgadoFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTurnoOtorgadoFecha);
				
				TableSchema.TableColumn colvarTurnoOtorgadoHora = new TableSchema.TableColumn(schema);
				colvarTurnoOtorgadoHora.ColumnName = "turnoOtorgadoHora";
				colvarTurnoOtorgadoHora.DataType = DbType.String;
				colvarTurnoOtorgadoHora.MaxLength = 5;
				colvarTurnoOtorgadoHora.AutoIncrement = false;
				colvarTurnoOtorgadoHora.IsNullable = true;
				colvarTurnoOtorgadoHora.IsPrimaryKey = false;
				colvarTurnoOtorgadoHora.IsForeignKey = false;
				colvarTurnoOtorgadoHora.IsReadOnly = false;
				colvarTurnoOtorgadoHora.DefaultSetting = @"";
				colvarTurnoOtorgadoHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTurnoOtorgadoHora);
				
				TableSchema.TableColumn colvarTurnoOtorgadoIdProfesional = new TableSchema.TableColumn(schema);
				colvarTurnoOtorgadoIdProfesional.ColumnName = "turnoOtorgadoIdProfesional";
				colvarTurnoOtorgadoIdProfesional.DataType = DbType.Int32;
				colvarTurnoOtorgadoIdProfesional.MaxLength = 0;
				colvarTurnoOtorgadoIdProfesional.AutoIncrement = false;
				colvarTurnoOtorgadoIdProfesional.IsNullable = true;
				colvarTurnoOtorgadoIdProfesional.IsPrimaryKey = false;
				colvarTurnoOtorgadoIdProfesional.IsForeignKey = false;
				colvarTurnoOtorgadoIdProfesional.IsReadOnly = false;
				colvarTurnoOtorgadoIdProfesional.DefaultSetting = @"";
				colvarTurnoOtorgadoIdProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTurnoOtorgadoIdProfesional);
				
				TableSchema.TableColumn colvarTurnoOtorgadoIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarTurnoOtorgadoIdEspecialidad.ColumnName = "turnoOtorgadoIdEspecialidad";
				colvarTurnoOtorgadoIdEspecialidad.DataType = DbType.Int32;
				colvarTurnoOtorgadoIdEspecialidad.MaxLength = 0;
				colvarTurnoOtorgadoIdEspecialidad.AutoIncrement = false;
				colvarTurnoOtorgadoIdEspecialidad.IsNullable = true;
				colvarTurnoOtorgadoIdEspecialidad.IsPrimaryKey = false;
				colvarTurnoOtorgadoIdEspecialidad.IsForeignKey = false;
				colvarTurnoOtorgadoIdEspecialidad.IsReadOnly = false;
				colvarTurnoOtorgadoIdEspecialidad.DefaultSetting = @"";
				colvarTurnoOtorgadoIdEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTurnoOtorgadoIdEspecialidad);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("ICO_DestinatarioInterconsulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDestinatariosInterconsulta")]
		[Bindable(true)]
		public int IdDestinatariosInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdDestinatariosInterconsulta); }
			set { SetColumnValue(Columns.IdDestinatariosInterconsulta, value); }
		}
		  
		[XmlAttribute("IdInterconsulta")]
		[Bindable(true)]
		public int IdInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdInterconsulta); }
			set { SetColumnValue(Columns.IdInterconsulta, value); }
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
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public string Estado 
		{
			get { return GetColumnValue<string>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("TurnoOtorgadoFecha")]
		[Bindable(true)]
		public DateTime? TurnoOtorgadoFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.TurnoOtorgadoFecha); }
			set { SetColumnValue(Columns.TurnoOtorgadoFecha, value); }
		}
		  
		[XmlAttribute("TurnoOtorgadoHora")]
		[Bindable(true)]
		public string TurnoOtorgadoHora 
		{
			get { return GetColumnValue<string>(Columns.TurnoOtorgadoHora); }
			set { SetColumnValue(Columns.TurnoOtorgadoHora, value); }
		}
		  
		[XmlAttribute("TurnoOtorgadoIdProfesional")]
		[Bindable(true)]
		public int? TurnoOtorgadoIdProfesional 
		{
			get { return GetColumnValue<int?>(Columns.TurnoOtorgadoIdProfesional); }
			set { SetColumnValue(Columns.TurnoOtorgadoIdProfesional, value); }
		}
		  
		[XmlAttribute("TurnoOtorgadoIdEspecialidad")]
		[Bindable(true)]
		public int? TurnoOtorgadoIdEspecialidad 
		{
			get { return GetColumnValue<int?>(Columns.TurnoOtorgadoIdEspecialidad); }
			set { SetColumnValue(Columns.TurnoOtorgadoIdEspecialidad, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInterconsulta,int varIdProfesional,int varIdEspecialidad,int? varIdZona,int? varIdEfector,string varEstado,DateTime? varTurnoOtorgadoFecha,string varTurnoOtorgadoHora,int? varTurnoOtorgadoIdProfesional,int? varTurnoOtorgadoIdEspecialidad)
		{
			IcoDestinatarioInterconsultum item = new IcoDestinatarioInterconsultum();
			
			item.IdInterconsulta = varIdInterconsulta;
			
			item.IdProfesional = varIdProfesional;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdZona = varIdZona;
			
			item.IdEfector = varIdEfector;
			
			item.Estado = varEstado;
			
			item.TurnoOtorgadoFecha = varTurnoOtorgadoFecha;
			
			item.TurnoOtorgadoHora = varTurnoOtorgadoHora;
			
			item.TurnoOtorgadoIdProfesional = varTurnoOtorgadoIdProfesional;
			
			item.TurnoOtorgadoIdEspecialidad = varTurnoOtorgadoIdEspecialidad;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDestinatariosInterconsulta,int varIdInterconsulta,int varIdProfesional,int varIdEspecialidad,int? varIdZona,int? varIdEfector,string varEstado,DateTime? varTurnoOtorgadoFecha,string varTurnoOtorgadoHora,int? varTurnoOtorgadoIdProfesional,int? varTurnoOtorgadoIdEspecialidad)
		{
			IcoDestinatarioInterconsultum item = new IcoDestinatarioInterconsultum();
			
				item.IdDestinatariosInterconsulta = varIdDestinatariosInterconsulta;
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.IdProfesional = varIdProfesional;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdZona = varIdZona;
			
				item.IdEfector = varIdEfector;
			
				item.Estado = varEstado;
			
				item.TurnoOtorgadoFecha = varTurnoOtorgadoFecha;
			
				item.TurnoOtorgadoHora = varTurnoOtorgadoHora;
			
				item.TurnoOtorgadoIdProfesional = varTurnoOtorgadoIdProfesional;
			
				item.TurnoOtorgadoIdEspecialidad = varTurnoOtorgadoIdEspecialidad;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDestinatariosInterconsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdZonaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TurnoOtorgadoFechaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TurnoOtorgadoHoraColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn TurnoOtorgadoIdProfesionalColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TurnoOtorgadoIdEspecialidadColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDestinatariosInterconsulta = @"idDestinatariosInterconsulta";
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string IdProfesional = @"idProfesional";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdZona = @"idZona";
			 public static string IdEfector = @"idEfector";
			 public static string Estado = @"estado";
			 public static string TurnoOtorgadoFecha = @"turnoOtorgadoFecha";
			 public static string TurnoOtorgadoHora = @"turnoOtorgadoHora";
			 public static string TurnoOtorgadoIdProfesional = @"turnoOtorgadoIdProfesional";
			 public static string TurnoOtorgadoIdEspecialidad = @"turnoOtorgadoIdEspecialidad";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
