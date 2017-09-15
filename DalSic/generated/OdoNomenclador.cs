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
	/// Strongly-typed collection for the OdoNomenclador class.
	/// </summary>
    [Serializable]
	public partial class OdoNomencladorCollection : ActiveList<OdoNomenclador, OdoNomencladorCollection>
	{	   
		public OdoNomencladorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>OdoNomencladorCollection</returns>
		public OdoNomencladorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                OdoNomenclador o = this[i];
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
	/// This is an ActiveRecord class which wraps the ODO_Nomenclador table.
	/// </summary>
	[Serializable]
	public partial class OdoNomenclador : ActiveRecord<OdoNomenclador>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public OdoNomenclador()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public OdoNomenclador(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public OdoNomenclador(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public OdoNomenclador(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ODO_Nomenclador", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "idNomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = true;
				colvarIdNomenclador.IsNullable = false;
				colvarIdNomenclador.IsPrimaryKey = true;
				colvarIdNomenclador.IsForeignKey = false;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				colvarIdNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiStringFixedLength;
				colvarCodigo.MaxLength = 5;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarClasificacion = new TableSchema.TableColumn(schema);
				colvarClasificacion.ColumnName = "clasificacion";
				colvarClasificacion.DataType = DbType.AnsiString;
				colvarClasificacion.MaxLength = 50;
				colvarClasificacion.AutoIncrement = false;
				colvarClasificacion.IsNullable = false;
				colvarClasificacion.IsPrimaryKey = false;
				colvarClasificacion.IsForeignKey = false;
				colvarClasificacion.IsReadOnly = false;
				colvarClasificacion.DefaultSetting = @"";
				colvarClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClasificacion);
				
				TableSchema.TableColumn colvarPiezaDental = new TableSchema.TableColumn(schema);
				colvarPiezaDental.ColumnName = "piezaDental";
				colvarPiezaDental.DataType = DbType.Boolean;
				colvarPiezaDental.MaxLength = 0;
				colvarPiezaDental.AutoIncrement = false;
				colvarPiezaDental.IsNullable = false;
				colvarPiezaDental.IsPrimaryKey = false;
				colvarPiezaDental.IsForeignKey = false;
				colvarPiezaDental.IsReadOnly = false;
				colvarPiezaDental.DefaultSetting = @"";
				colvarPiezaDental.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPiezaDental);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("ODO_Nomenclador",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int IdNomenclador 
		{
			get { return GetColumnValue<int>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Clasificacion")]
		[Bindable(true)]
		public string Clasificacion 
		{
			get { return GetColumnValue<string>(Columns.Clasificacion); }
			set { SetColumnValue(Columns.Clasificacion, value); }
		}
		  
		[XmlAttribute("PiezaDental")]
		[Bindable(true)]
		public bool PiezaDental 
		{
			get { return GetColumnValue<bool>(Columns.PiezaDental); }
			set { SetColumnValue(Columns.PiezaDental, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodigo,string varDescripcion,string varClasificacion,bool varPiezaDental)
		{
			OdoNomenclador item = new OdoNomenclador();
			
			item.Codigo = varCodigo;
			
			item.Descripcion = varDescripcion;
			
			item.Clasificacion = varClasificacion;
			
			item.PiezaDental = varPiezaDental;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNomenclador,string varCodigo,string varDescripcion,string varClasificacion,bool varPiezaDental)
		{
			OdoNomenclador item = new OdoNomenclador();
			
				item.IdNomenclador = varIdNomenclador;
			
				item.Codigo = varCodigo;
			
				item.Descripcion = varDescripcion;
			
				item.Clasificacion = varClasificacion;
			
				item.PiezaDental = varPiezaDental;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ClasificacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PiezaDentalColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNomenclador = @"idNomenclador";
			 public static string Codigo = @"codigo";
			 public static string Descripcion = @"descripcion";
			 public static string Clasificacion = @"clasificacion";
			 public static string PiezaDental = @"piezaDental";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
