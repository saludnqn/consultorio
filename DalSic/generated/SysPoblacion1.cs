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
	/// Strongly-typed collection for the SysPoblacion1 class.
	/// </summary>
    [Serializable]
	public partial class SysPoblacion1Collection : ActiveList<SysPoblacion1, SysPoblacion1Collection>
	{	   
		public SysPoblacion1Collection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysPoblacion1Collection</returns>
		public SysPoblacion1Collection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysPoblacion1 o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Poblacion1 table.
	/// </summary>
	[Serializable]
	public partial class SysPoblacion1 : ActiveRecord<SysPoblacion1>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysPoblacion1()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysPoblacion1(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysPoblacion1(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysPoblacion1(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Poblacion1", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPoblacion = new TableSchema.TableColumn(schema);
				colvarIdPoblacion.ColumnName = "idPoblacion";
				colvarIdPoblacion.DataType = DbType.Int32;
				colvarIdPoblacion.MaxLength = 0;
				colvarIdPoblacion.AutoIncrement = true;
				colvarIdPoblacion.IsNullable = false;
				colvarIdPoblacion.IsPrimaryKey = true;
				colvarIdPoblacion.IsForeignKey = false;
				colvarIdPoblacion.IsReadOnly = false;
				colvarIdPoblacion.DefaultSetting = @"";
				colvarIdPoblacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPoblacion);
				
				TableSchema.TableColumn colvarIdLocalidad = new TableSchema.TableColumn(schema);
				colvarIdLocalidad.ColumnName = "IdLocalidad";
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
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "Localidad";
				colvarLocalidad.DataType = DbType.String;
				colvarLocalidad.MaxLength = 255;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "Sexo";
				colvarSexo.DataType = DbType.String;
				colvarSexo.MaxLength = 255;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = true;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "Edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = true;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				colvarEdad.DefaultSetting = @"";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarAño = new TableSchema.TableColumn(schema);
				colvarAño.ColumnName = "Año";
				colvarAño.DataType = DbType.Int32;
				colvarAño.MaxLength = 0;
				colvarAño.AutoIncrement = false;
				colvarAño.IsNullable = true;
				colvarAño.IsPrimaryKey = false;
				colvarAño.IsForeignKey = false;
				colvarAño.IsReadOnly = false;
				colvarAño.DefaultSetting = @"";
				colvarAño.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAño);
				
				TableSchema.TableColumn colvarHabitantes = new TableSchema.TableColumn(schema);
				colvarHabitantes.ColumnName = "Habitantes";
				colvarHabitantes.DataType = DbType.Int32;
				colvarHabitantes.MaxLength = 0;
				colvarHabitantes.AutoIncrement = false;
				colvarHabitantes.IsNullable = true;
				colvarHabitantes.IsPrimaryKey = false;
				colvarHabitantes.IsForeignKey = false;
				colvarHabitantes.IsReadOnly = false;
				colvarHabitantes.DefaultSetting = @"";
				colvarHabitantes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHabitantes);
				
				TableSchema.TableColumn colvarZona = new TableSchema.TableColumn(schema);
				colvarZona.ColumnName = "Zona";
				colvarZona.DataType = DbType.Int32;
				colvarZona.MaxLength = 0;
				colvarZona.AutoIncrement = false;
				colvarZona.IsNullable = true;
				colvarZona.IsPrimaryKey = false;
				colvarZona.IsForeignKey = false;
				colvarZona.IsReadOnly = false;
				colvarZona.DefaultSetting = @"";
				colvarZona.ForeignKeyTableName = "";
				schema.Columns.Add(colvarZona);
				
				TableSchema.TableColumn colvarDepartamentos = new TableSchema.TableColumn(schema);
				colvarDepartamentos.ColumnName = "Departamentos";
				colvarDepartamentos.DataType = DbType.String;
				colvarDepartamentos.MaxLength = 255;
				colvarDepartamentos.AutoIncrement = false;
				colvarDepartamentos.IsNullable = true;
				colvarDepartamentos.IsPrimaryKey = false;
				colvarDepartamentos.IsForeignKey = false;
				colvarDepartamentos.IsReadOnly = false;
				colvarDepartamentos.DefaultSetting = @"";
				colvarDepartamentos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDepartamentos);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Poblacion1",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPoblacion")]
		[Bindable(true)]
		public int IdPoblacion 
		{
			get { return GetColumnValue<int>(Columns.IdPoblacion); }
			set { SetColumnValue(Columns.IdPoblacion, value); }
		}
		  
		[XmlAttribute("IdLocalidad")]
		[Bindable(true)]
		public int? IdLocalidad 
		{
			get { return GetColumnValue<int?>(Columns.IdLocalidad); }
			set { SetColumnValue(Columns.IdLocalidad, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int? Edad 
		{
			get { return GetColumnValue<int?>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("Año")]
		[Bindable(true)]
		public int? Año 
		{
			get { return GetColumnValue<int?>(Columns.Año); }
			set { SetColumnValue(Columns.Año, value); }
		}
		  
		[XmlAttribute("Habitantes")]
		[Bindable(true)]
		public int? Habitantes 
		{
			get { return GetColumnValue<int?>(Columns.Habitantes); }
			set { SetColumnValue(Columns.Habitantes, value); }
		}
		  
		[XmlAttribute("Zona")]
		[Bindable(true)]
		public int? Zona 
		{
			get { return GetColumnValue<int?>(Columns.Zona); }
			set { SetColumnValue(Columns.Zona, value); }
		}
		  
		[XmlAttribute("Departamentos")]
		[Bindable(true)]
		public string Departamentos 
		{
			get { return GetColumnValue<string>(Columns.Departamentos); }
			set { SetColumnValue(Columns.Departamentos, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdLocalidad,string varLocalidad,string varSexo,int? varEdad,int? varAño,int? varHabitantes,int? varZona,string varDepartamentos)
		{
			SysPoblacion1 item = new SysPoblacion1();
			
			item.IdLocalidad = varIdLocalidad;
			
			item.Localidad = varLocalidad;
			
			item.Sexo = varSexo;
			
			item.Edad = varEdad;
			
			item.Año = varAño;
			
			item.Habitantes = varHabitantes;
			
			item.Zona = varZona;
			
			item.Departamentos = varDepartamentos;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPoblacion,int? varIdLocalidad,string varLocalidad,string varSexo,int? varEdad,int? varAño,int? varHabitantes,int? varZona,string varDepartamentos)
		{
			SysPoblacion1 item = new SysPoblacion1();
			
				item.IdPoblacion = varIdPoblacion;
			
				item.IdLocalidad = varIdLocalidad;
			
				item.Localidad = varLocalidad;
			
				item.Sexo = varSexo;
			
				item.Edad = varEdad;
			
				item.Año = varAño;
			
				item.Habitantes = varHabitantes;
			
				item.Zona = varZona;
			
				item.Departamentos = varDepartamentos;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPoblacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLocalidadColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AñoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn HabitantesColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ZonaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DepartamentosColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPoblacion = @"idPoblacion";
			 public static string IdLocalidad = @"IdLocalidad";
			 public static string Localidad = @"Localidad";
			 public static string Sexo = @"Sexo";
			 public static string Edad = @"Edad";
			 public static string Año = @"Año";
			 public static string Habitantes = @"Habitantes";
			 public static string Zona = @"Zona";
			 public static string Departamentos = @"Departamentos";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
