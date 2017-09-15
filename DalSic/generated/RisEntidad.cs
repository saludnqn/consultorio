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
	/// Strongly-typed collection for the RisEntidad class.
	/// </summary>
    [Serializable]
	public partial class RisEntidadCollection : ActiveList<RisEntidad, RisEntidadCollection>
	{	   
		public RisEntidadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEntidadCollection</returns>
		public RisEntidadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEntidad o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_Entidad table.
	/// </summary>
	[Serializable]
	public partial class RisEntidad : ActiveRecord<RisEntidad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEntidad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEntidad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEntidad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEntidad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_Entidad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEntidad = new TableSchema.TableColumn(schema);
				colvarIdEntidad.ColumnName = "idEntidad";
				colvarIdEntidad.DataType = DbType.Int32;
				colvarIdEntidad.MaxLength = 0;
				colvarIdEntidad.AutoIncrement = true;
				colvarIdEntidad.IsNullable = false;
				colvarIdEntidad.IsPrimaryKey = true;
				colvarIdEntidad.IsForeignKey = false;
				colvarIdEntidad.IsReadOnly = false;
				colvarIdEntidad.DefaultSetting = @"";
				colvarIdEntidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEntidad);
				
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
				
				TableSchema.TableColumn colvarCaracter = new TableSchema.TableColumn(schema);
				colvarCaracter.ColumnName = "caracter";
				colvarCaracter.DataType = DbType.AnsiString;
				colvarCaracter.MaxLength = 100;
				colvarCaracter.AutoIncrement = false;
				colvarCaracter.IsNullable = true;
				colvarCaracter.IsPrimaryKey = false;
				colvarCaracter.IsForeignKey = false;
				colvarCaracter.IsReadOnly = false;
				colvarCaracter.DefaultSetting = @"";
				colvarCaracter.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaracter);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = 100;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 100;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = true;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.AnsiString;
				colvarTipo.MaxLength = 100;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarTipoEntidad = new TableSchema.TableColumn(schema);
				colvarTipoEntidad.ColumnName = "tipoEntidad";
				colvarTipoEntidad.DataType = DbType.AnsiString;
				colvarTipoEntidad.MaxLength = 100;
				colvarTipoEntidad.AutoIncrement = false;
				colvarTipoEntidad.IsNullable = true;
				colvarTipoEntidad.IsPrimaryKey = false;
				colvarTipoEntidad.IsForeignKey = false;
				colvarTipoEntidad.IsReadOnly = false;
				colvarTipoEntidad.DefaultSetting = @"";
				colvarTipoEntidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoEntidad);
				
				TableSchema.TableColumn colvarCaracteristicas = new TableSchema.TableColumn(schema);
				colvarCaracteristicas.ColumnName = "caracteristicas";
				colvarCaracteristicas.DataType = DbType.AnsiString;
				colvarCaracteristicas.MaxLength = 100;
				colvarCaracteristicas.AutoIncrement = false;
				colvarCaracteristicas.IsNullable = true;
				colvarCaracteristicas.IsPrimaryKey = false;
				colvarCaracteristicas.IsForeignKey = false;
				colvarCaracteristicas.IsReadOnly = false;
				colvarCaracteristicas.DefaultSetting = @"";
				colvarCaracteristicas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaracteristicas);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_Entidad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEntidad")]
		[Bindable(true)]
		public int IdEntidad 
		{
			get { return GetColumnValue<int>(Columns.IdEntidad); }
			set { SetColumnValue(Columns.IdEntidad, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Caracter")]
		[Bindable(true)]
		public string Caracter 
		{
			get { return GetColumnValue<string>(Columns.Caracter); }
			set { SetColumnValue(Columns.Caracter, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("TipoEntidad")]
		[Bindable(true)]
		public string TipoEntidad 
		{
			get { return GetColumnValue<string>(Columns.TipoEntidad); }
			set { SetColumnValue(Columns.TipoEntidad, value); }
		}
		  
		[XmlAttribute("Caracteristicas")]
		[Bindable(true)]
		public string Caracteristicas 
		{
			get { return GetColumnValue<string>(Columns.Caracteristicas); }
			set { SetColumnValue(Columns.Caracteristicas, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varCaracter,string varDomicilio,string varEmail,string varTipo,string varTipoEntidad,string varCaracteristicas)
		{
			RisEntidad item = new RisEntidad();
			
			item.Nombre = varNombre;
			
			item.Caracter = varCaracter;
			
			item.Domicilio = varDomicilio;
			
			item.Email = varEmail;
			
			item.Tipo = varTipo;
			
			item.TipoEntidad = varTipoEntidad;
			
			item.Caracteristicas = varCaracteristicas;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEntidad,string varNombre,string varCaracter,string varDomicilio,string varEmail,string varTipo,string varTipoEntidad,string varCaracteristicas)
		{
			RisEntidad item = new RisEntidad();
			
				item.IdEntidad = varIdEntidad;
			
				item.Nombre = varNombre;
			
				item.Caracter = varCaracter;
			
				item.Domicilio = varDomicilio;
			
				item.Email = varEmail;
			
				item.Tipo = varTipo;
			
				item.TipoEntidad = varTipoEntidad;
			
				item.Caracteristicas = varCaracteristicas;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEntidadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CaracterColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoEntidadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CaracteristicasColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEntidad = @"idEntidad";
			 public static string Nombre = @"nombre";
			 public static string Caracter = @"caracter";
			 public static string Domicilio = @"domicilio";
			 public static string Email = @"email";
			 public static string Tipo = @"tipo";
			 public static string TipoEntidad = @"tipoEntidad";
			 public static string Caracteristicas = @"caracteristicas";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
