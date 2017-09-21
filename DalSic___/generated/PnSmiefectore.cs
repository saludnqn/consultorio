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
	/// Strongly-typed collection for the PnSmiefectore class.
	/// </summary>
    [Serializable]
	public partial class PnSmiefectoreCollection : ActiveList<PnSmiefectore, PnSmiefectoreCollection>
	{	   
		public PnSmiefectoreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSmiefectoreCollection</returns>
		public PnSmiefectoreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSmiefectore o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_smiefectores table.
	/// </summary>
	[Serializable]
	public partial class PnSmiefectore : ActiveRecord<PnSmiefectore>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSmiefectore()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSmiefectore(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSmiefectore(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSmiefectore(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_smiefectores", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = true;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarNombreefector = new TableSchema.TableColumn(schema);
				colvarNombreefector.ColumnName = "nombreefector";
				colvarNombreefector.DataType = DbType.AnsiString;
				colvarNombreefector.MaxLength = -1;
				colvarNombreefector.AutoIncrement = false;
				colvarNombreefector.IsNullable = true;
				colvarNombreefector.IsPrimaryKey = false;
				colvarNombreefector.IsForeignKey = false;
				colvarNombreefector.IsReadOnly = false;
				colvarNombreefector.DefaultSetting = @"";
				colvarNombreefector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreefector);
				
				TableSchema.TableColumn colvarTipoefector = new TableSchema.TableColumn(schema);
				colvarTipoefector.ColumnName = "tipoefector";
				colvarTipoefector.DataType = DbType.AnsiString;
				colvarTipoefector.MaxLength = -1;
				colvarTipoefector.AutoIncrement = false;
				colvarTipoefector.IsNullable = true;
				colvarTipoefector.IsPrimaryKey = false;
				colvarTipoefector.IsForeignKey = false;
				colvarTipoefector.IsReadOnly = false;
				colvarTipoefector.DefaultSetting = @"";
				colvarTipoefector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoefector);
				
				TableSchema.TableColumn colvarDireccion = new TableSchema.TableColumn(schema);
				colvarDireccion.ColumnName = "direccion";
				colvarDireccion.DataType = DbType.AnsiString;
				colvarDireccion.MaxLength = -1;
				colvarDireccion.AutoIncrement = false;
				colvarDireccion.IsNullable = true;
				colvarDireccion.IsPrimaryKey = false;
				colvarDireccion.IsForeignKey = false;
				colvarDireccion.IsReadOnly = false;
				colvarDireccion.DefaultSetting = @"";
				colvarDireccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccion);
				
				TableSchema.TableColumn colvarLocalidadmunicipiopartido = new TableSchema.TableColumn(schema);
				colvarLocalidadmunicipiopartido.ColumnName = "localidadmunicipiopartido";
				colvarLocalidadmunicipiopartido.DataType = DbType.AnsiString;
				colvarLocalidadmunicipiopartido.MaxLength = -1;
				colvarLocalidadmunicipiopartido.AutoIncrement = false;
				colvarLocalidadmunicipiopartido.IsNullable = true;
				colvarLocalidadmunicipiopartido.IsPrimaryKey = false;
				colvarLocalidadmunicipiopartido.IsForeignKey = false;
				colvarLocalidadmunicipiopartido.IsReadOnly = false;
				colvarLocalidadmunicipiopartido.DefaultSetting = @"";
				colvarLocalidadmunicipiopartido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidadmunicipiopartido);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_smiefectores",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Nombreefector")]
		[Bindable(true)]
		public string Nombreefector 
		{
			get { return GetColumnValue<string>(Columns.Nombreefector); }
			set { SetColumnValue(Columns.Nombreefector, value); }
		}
		  
		[XmlAttribute("Tipoefector")]
		[Bindable(true)]
		public string Tipoefector 
		{
			get { return GetColumnValue<string>(Columns.Tipoefector); }
			set { SetColumnValue(Columns.Tipoefector, value); }
		}
		  
		[XmlAttribute("Direccion")]
		[Bindable(true)]
		public string Direccion 
		{
			get { return GetColumnValue<string>(Columns.Direccion); }
			set { SetColumnValue(Columns.Direccion, value); }
		}
		  
		[XmlAttribute("Localidadmunicipiopartido")]
		[Bindable(true)]
		public string Localidadmunicipiopartido 
		{
			get { return GetColumnValue<string>(Columns.Localidadmunicipiopartido); }
			set { SetColumnValue(Columns.Localidadmunicipiopartido, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varNombreefector,string varTipoefector,string varDireccion,string varLocalidadmunicipiopartido)
		{
			PnSmiefectore item = new PnSmiefectore();
			
			item.Cuie = varCuie;
			
			item.Nombreefector = varNombreefector;
			
			item.Tipoefector = varTipoefector;
			
			item.Direccion = varDireccion;
			
			item.Localidadmunicipiopartido = varLocalidadmunicipiopartido;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varCuie,string varNombreefector,string varTipoefector,string varDireccion,string varLocalidadmunicipiopartido)
		{
			PnSmiefectore item = new PnSmiefectore();
			
				item.Cuie = varCuie;
			
				item.Nombreefector = varNombreefector;
			
				item.Tipoefector = varTipoefector;
			
				item.Direccion = varDireccion;
			
				item.Localidadmunicipiopartido = varLocalidadmunicipiopartido;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreefectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoefectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadmunicipiopartidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Cuie = @"cuie";
			 public static string Nombreefector = @"nombreefector";
			 public static string Tipoefector = @"tipoefector";
			 public static string Direccion = @"direccion";
			 public static string Localidadmunicipiopartido = @"localidadmunicipiopartido";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
