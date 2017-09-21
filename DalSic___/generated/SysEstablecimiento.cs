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
	/// Strongly-typed collection for the SysEstablecimiento class.
	/// </summary>
    [Serializable]
	public partial class SysEstablecimientoCollection : ActiveList<SysEstablecimiento, SysEstablecimientoCollection>
	{	   
		public SysEstablecimientoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysEstablecimientoCollection</returns>
		public SysEstablecimientoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysEstablecimiento o = this[i];
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
	/// This is an ActiveRecord class which wraps the sys_Establecimiento table.
	/// </summary>
	[Serializable]
	public partial class SysEstablecimiento : ActiveRecord<SysEstablecimiento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysEstablecimiento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysEstablecimiento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysEstablecimiento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysEstablecimiento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("sys_Establecimiento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstablecimiento = new TableSchema.TableColumn(schema);
				colvarIdEstablecimiento.ColumnName = "idEstablecimiento";
				colvarIdEstablecimiento.DataType = DbType.Int32;
				colvarIdEstablecimiento.MaxLength = 0;
				colvarIdEstablecimiento.AutoIncrement = false;
				colvarIdEstablecimiento.IsNullable = false;
				colvarIdEstablecimiento.IsPrimaryKey = true;
				colvarIdEstablecimiento.IsForeignKey = false;
				colvarIdEstablecimiento.IsReadOnly = false;
				colvarIdEstablecimiento.DefaultSetting = @"";
				colvarIdEstablecimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstablecimiento);
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "Localidad";
				colvarLocalidad.DataType = DbType.AnsiString;
				colvarLocalidad.MaxLength = 300;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 300;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdZona = new TableSchema.TableColumn(schema);
				colvarIdZona.ColumnName = "idZona";
				colvarIdZona.DataType = DbType.Int32;
				colvarIdZona.MaxLength = 0;
				colvarIdZona.AutoIncrement = false;
				colvarIdZona.IsNullable = false;
				colvarIdZona.IsPrimaryKey = false;
				colvarIdZona.IsForeignKey = false;
				colvarIdZona.IsReadOnly = false;
				colvarIdZona.DefaultSetting = @"";
				colvarIdZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdZona);
				
				TableSchema.TableColumn colvarIdLocalidad = new TableSchema.TableColumn(schema);
				colvarIdLocalidad.ColumnName = "idLocalidad";
				colvarIdLocalidad.DataType = DbType.Int32;
				colvarIdLocalidad.MaxLength = 0;
				colvarIdLocalidad.AutoIncrement = false;
				colvarIdLocalidad.IsNullable = true;
				colvarIdLocalidad.IsPrimaryKey = false;
				colvarIdLocalidad.IsForeignKey = false;
				colvarIdLocalidad.IsReadOnly = false;
				colvarIdLocalidad.DefaultSetting = @"";
				colvarIdLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLocalidad);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarTipoEstab = new TableSchema.TableColumn(schema);
				colvarTipoEstab.ColumnName = "TipoEstab";
				colvarTipoEstab.DataType = DbType.String;
				colvarTipoEstab.MaxLength = 10;
				colvarTipoEstab.AutoIncrement = false;
				colvarTipoEstab.IsNullable = true;
				colvarTipoEstab.IsPrimaryKey = false;
				colvarTipoEstab.IsForeignKey = false;
				colvarTipoEstab.IsReadOnly = false;
				colvarTipoEstab.DefaultSetting = @"";
				colvarTipoEstab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoEstab);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("sys_Establecimiento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstablecimiento")]
		[Bindable(true)]
		public int IdEstablecimiento 
		{
			get { return GetColumnValue<int>(Columns.IdEstablecimiento); }
			set { SetColumnValue(Columns.IdEstablecimiento, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdZona")]
		[Bindable(true)]
		public int IdZona 
		{
			get { return GetColumnValue<int>(Columns.IdZona); }
			set { SetColumnValue(Columns.IdZona, value); }
		}
		  
		[XmlAttribute("IdLocalidad")]
		[Bindable(true)]
		public int? IdLocalidad 
		{
			get { return GetColumnValue<int?>(Columns.IdLocalidad); }
			set { SetColumnValue(Columns.IdLocalidad, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("TipoEstab")]
		[Bindable(true)]
		public string TipoEstab 
		{
			get { return GetColumnValue<string>(Columns.TipoEstab); }
			set { SetColumnValue(Columns.TipoEstab, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysEstablecimiento
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstablecimiento,string varLocalidad,string varNombre,int varIdZona,int? varIdLocalidad,int? varIdEfector,string varTipoEstab)
		{
			SysEstablecimiento item = new SysEstablecimiento();
			
			item.IdEstablecimiento = varIdEstablecimiento;
			
			item.Localidad = varLocalidad;
			
			item.Nombre = varNombre;
			
			item.IdZona = varIdZona;
			
			item.IdLocalidad = varIdLocalidad;
			
			item.IdEfector = varIdEfector;
			
			item.TipoEstab = varTipoEstab;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstablecimiento,string varLocalidad,string varNombre,int varIdZona,int? varIdLocalidad,int? varIdEfector,string varTipoEstab)
		{
			SysEstablecimiento item = new SysEstablecimiento();
			
				item.IdEstablecimiento = varIdEstablecimiento;
			
				item.Localidad = varLocalidad;
			
				item.Nombre = varNombre;
			
				item.IdZona = varIdZona;
			
				item.IdLocalidad = varIdLocalidad;
			
				item.IdEfector = varIdEfector;
			
				item.TipoEstab = varTipoEstab;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstablecimientoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdZonaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLocalidadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoEstabColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstablecimiento = @"idEstablecimiento";
			 public static string Localidad = @"Localidad";
			 public static string Nombre = @"Nombre";
			 public static string IdZona = @"idZona";
			 public static string IdLocalidad = @"idLocalidad";
			 public static string IdEfector = @"idEfector";
			 public static string TipoEstab = @"TipoEstab";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
