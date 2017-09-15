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
	/// Strongly-typed collection for the PnDirectoriosArchivo class.
	/// </summary>
    [Serializable]
	public partial class PnDirectoriosArchivoCollection : ActiveList<PnDirectoriosArchivo, PnDirectoriosArchivoCollection>
	{	   
		public PnDirectoriosArchivoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnDirectoriosArchivoCollection</returns>
		public PnDirectoriosArchivoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnDirectoriosArchivo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_directorios_archivos table.
	/// </summary>
	[Serializable]
	public partial class PnDirectoriosArchivo : ActiveRecord<PnDirectoriosArchivo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnDirectoriosArchivo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnDirectoriosArchivo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnDirectoriosArchivo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnDirectoriosArchivo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_directorios_archivos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDirectoriosArchivosSerial = new TableSchema.TableColumn(schema);
				colvarIdDirectoriosArchivosSerial.ColumnName = "id_directorios_archivos_serial";
				colvarIdDirectoriosArchivosSerial.DataType = DbType.Int32;
				colvarIdDirectoriosArchivosSerial.MaxLength = 0;
				colvarIdDirectoriosArchivosSerial.AutoIncrement = true;
				colvarIdDirectoriosArchivosSerial.IsNullable = false;
				colvarIdDirectoriosArchivosSerial.IsPrimaryKey = true;
				colvarIdDirectoriosArchivosSerial.IsForeignKey = false;
				colvarIdDirectoriosArchivosSerial.IsReadOnly = false;
				colvarIdDirectoriosArchivosSerial.DefaultSetting = @"";
				colvarIdDirectoriosArchivosSerial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDirectoriosArchivosSerial);
				
				TableSchema.TableColumn colvarIdDirectoriosArchivos = new TableSchema.TableColumn(schema);
				colvarIdDirectoriosArchivos.ColumnName = "id_directorios_archivos";
				colvarIdDirectoriosArchivos.DataType = DbType.AnsiString;
				colvarIdDirectoriosArchivos.MaxLength = -1;
				colvarIdDirectoriosArchivos.AutoIncrement = false;
				colvarIdDirectoriosArchivos.IsNullable = false;
				colvarIdDirectoriosArchivos.IsPrimaryKey = false;
				colvarIdDirectoriosArchivos.IsForeignKey = false;
				colvarIdDirectoriosArchivos.IsReadOnly = false;
				colvarIdDirectoriosArchivos.DefaultSetting = @"";
				colvarIdDirectoriosArchivos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDirectoriosArchivos);
				
				TableSchema.TableColumn colvarNombreNodo = new TableSchema.TableColumn(schema);
				colvarNombreNodo.ColumnName = "nombre_nodo";
				colvarNombreNodo.DataType = DbType.AnsiString;
				colvarNombreNodo.MaxLength = -1;
				colvarNombreNodo.AutoIncrement = false;
				colvarNombreNodo.IsNullable = true;
				colvarNombreNodo.IsPrimaryKey = false;
				colvarNombreNodo.IsForeignKey = false;
				colvarNombreNodo.IsReadOnly = false;
				colvarNombreNodo.DefaultSetting = @"";
				colvarNombreNodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreNodo);
				
				TableSchema.TableColumn colvarIdNodoPadre = new TableSchema.TableColumn(schema);
				colvarIdNodoPadre.ColumnName = "id_nodo_padre";
				colvarIdNodoPadre.DataType = DbType.AnsiString;
				colvarIdNodoPadre.MaxLength = -1;
				colvarIdNodoPadre.AutoIncrement = false;
				colvarIdNodoPadre.IsNullable = true;
				colvarIdNodoPadre.IsPrimaryKey = false;
				colvarIdNodoPadre.IsForeignKey = false;
				colvarIdNodoPadre.IsReadOnly = false;
				colvarIdNodoPadre.DefaultSetting = @"";
				colvarIdNodoPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNodoPadre);
				
				TableSchema.TableColumn colvarNombreNodoPadre = new TableSchema.TableColumn(schema);
				colvarNombreNodoPadre.ColumnName = "nombre_nodo_padre";
				colvarNombreNodoPadre.DataType = DbType.AnsiString;
				colvarNombreNodoPadre.MaxLength = -1;
				colvarNombreNodoPadre.AutoIncrement = false;
				colvarNombreNodoPadre.IsNullable = true;
				colvarNombreNodoPadre.IsPrimaryKey = false;
				colvarNombreNodoPadre.IsForeignKey = false;
				colvarNombreNodoPadre.IsReadOnly = false;
				colvarNombreNodoPadre.DefaultSetting = @"";
				colvarNombreNodoPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreNodoPadre);
				
				TableSchema.TableColumn colvarPath = new TableSchema.TableColumn(schema);
				colvarPath.ColumnName = "path";
				colvarPath.DataType = DbType.AnsiString;
				colvarPath.MaxLength = -1;
				colvarPath.AutoIncrement = false;
				colvarPath.IsNullable = true;
				colvarPath.IsPrimaryKey = false;
				colvarPath.IsForeignKey = false;
				colvarPath.IsReadOnly = false;
				colvarPath.DefaultSetting = @"";
				colvarPath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPath);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_directorios_archivos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDirectoriosArchivosSerial")]
		[Bindable(true)]
		public int IdDirectoriosArchivosSerial 
		{
			get { return GetColumnValue<int>(Columns.IdDirectoriosArchivosSerial); }
			set { SetColumnValue(Columns.IdDirectoriosArchivosSerial, value); }
		}
		  
		[XmlAttribute("IdDirectoriosArchivos")]
		[Bindable(true)]
		public string IdDirectoriosArchivos 
		{
			get { return GetColumnValue<string>(Columns.IdDirectoriosArchivos); }
			set { SetColumnValue(Columns.IdDirectoriosArchivos, value); }
		}
		  
		[XmlAttribute("NombreNodo")]
		[Bindable(true)]
		public string NombreNodo 
		{
			get { return GetColumnValue<string>(Columns.NombreNodo); }
			set { SetColumnValue(Columns.NombreNodo, value); }
		}
		  
		[XmlAttribute("IdNodoPadre")]
		[Bindable(true)]
		public string IdNodoPadre 
		{
			get { return GetColumnValue<string>(Columns.IdNodoPadre); }
			set { SetColumnValue(Columns.IdNodoPadre, value); }
		}
		  
		[XmlAttribute("NombreNodoPadre")]
		[Bindable(true)]
		public string NombreNodoPadre 
		{
			get { return GetColumnValue<string>(Columns.NombreNodoPadre); }
			set { SetColumnValue(Columns.NombreNodoPadre, value); }
		}
		  
		[XmlAttribute("Path")]
		[Bindable(true)]
		public string Path 
		{
			get { return GetColumnValue<string>(Columns.Path); }
			set { SetColumnValue(Columns.Path, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varIdDirectoriosArchivos,string varNombreNodo,string varIdNodoPadre,string varNombreNodoPadre,string varPath)
		{
			PnDirectoriosArchivo item = new PnDirectoriosArchivo();
			
			item.IdDirectoriosArchivos = varIdDirectoriosArchivos;
			
			item.NombreNodo = varNombreNodo;
			
			item.IdNodoPadre = varIdNodoPadre;
			
			item.NombreNodoPadre = varNombreNodoPadre;
			
			item.Path = varPath;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDirectoriosArchivosSerial,string varIdDirectoriosArchivos,string varNombreNodo,string varIdNodoPadre,string varNombreNodoPadre,string varPath)
		{
			PnDirectoriosArchivo item = new PnDirectoriosArchivo();
			
				item.IdDirectoriosArchivosSerial = varIdDirectoriosArchivosSerial;
			
				item.IdDirectoriosArchivos = varIdDirectoriosArchivos;
			
				item.NombreNodo = varNombreNodo;
			
				item.IdNodoPadre = varIdNodoPadre;
			
				item.NombreNodoPadre = varNombreNodoPadre;
			
				item.Path = varPath;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDirectoriosArchivosSerialColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDirectoriosArchivosColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreNodoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNodoPadreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreNodoPadreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PathColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDirectoriosArchivosSerial = @"id_directorios_archivos_serial";
			 public static string IdDirectoriosArchivos = @"id_directorios_archivos";
			 public static string NombreNodo = @"nombre_nodo";
			 public static string IdNodoPadre = @"id_nodo_padre";
			 public static string NombreNodoPadre = @"nombre_nodo_padre";
			 public static string Path = @"path";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
