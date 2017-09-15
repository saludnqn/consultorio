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
	/// Strongly-typed collection for the PnSubirArchivo class.
	/// </summary>
    [Serializable]
	public partial class PnSubirArchivoCollection : ActiveList<PnSubirArchivo, PnSubirArchivoCollection>
	{	   
		public PnSubirArchivoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSubirArchivoCollection</returns>
		public PnSubirArchivoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSubirArchivo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_subir_archivos table.
	/// </summary>
	[Serializable]
	public partial class PnSubirArchivo : ActiveRecord<PnSubirArchivo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSubirArchivo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSubirArchivo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSubirArchivo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSubirArchivo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_subir_archivos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarCategoria = new TableSchema.TableColumn(schema);
				colvarCategoria.ColumnName = "categoria";
				colvarCategoria.DataType = DbType.AnsiString;
				colvarCategoria.MaxLength = -1;
				colvarCategoria.AutoIncrement = false;
				colvarCategoria.IsNullable = true;
				colvarCategoria.IsPrimaryKey = false;
				colvarCategoria.IsForeignKey = false;
				colvarCategoria.IsReadOnly = false;
				colvarCategoria.DefaultSetting = @"";
				colvarCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoria);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = -1;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarCreadopor = new TableSchema.TableColumn(schema);
				colvarCreadopor.ColumnName = "creadopor";
				colvarCreadopor.DataType = DbType.AnsiString;
				colvarCreadopor.MaxLength = -1;
				colvarCreadopor.AutoIncrement = false;
				colvarCreadopor.IsNullable = false;
				colvarCreadopor.IsPrimaryKey = false;
				colvarCreadopor.IsForeignKey = false;
				colvarCreadopor.IsReadOnly = false;
				colvarCreadopor.DefaultSetting = @"";
				colvarCreadopor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreadopor);
				
				TableSchema.TableColumn colvarSize = new TableSchema.TableColumn(schema);
				colvarSize.ColumnName = "size";
				colvarSize.DataType = DbType.AnsiString;
				colvarSize.MaxLength = -1;
				colvarSize.AutoIncrement = false;
				colvarSize.IsNullable = false;
				colvarSize.IsPrimaryKey = false;
				colvarSize.IsForeignKey = false;
				colvarSize.IsReadOnly = false;
				colvarSize.DefaultSetting = @"";
				colvarSize.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSize);
				
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
				
				TableSchema.TableColumn colvarAcceso = new TableSchema.TableColumn(schema);
				colvarAcceso.ColumnName = "acceso";
				colvarAcceso.DataType = DbType.AnsiString;
				colvarAcceso.MaxLength = -1;
				colvarAcceso.AutoIncrement = false;
				colvarAcceso.IsNullable = true;
				colvarAcceso.IsPrimaryKey = false;
				colvarAcceso.IsForeignKey = false;
				colvarAcceso.IsReadOnly = false;
				colvarAcceso.DefaultSetting = @"";
				colvarAcceso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso);
				
				TableSchema.TableColumn colvarIdDirectoriosArchivos = new TableSchema.TableColumn(schema);
				colvarIdDirectoriosArchivos.ColumnName = "id_directorios_archivos";
				colvarIdDirectoriosArchivos.DataType = DbType.AnsiString;
				colvarIdDirectoriosArchivos.MaxLength = -1;
				colvarIdDirectoriosArchivos.AutoIncrement = false;
				colvarIdDirectoriosArchivos.IsNullable = true;
				colvarIdDirectoriosArchivos.IsPrimaryKey = false;
				colvarIdDirectoriosArchivos.IsForeignKey = false;
				colvarIdDirectoriosArchivos.IsReadOnly = false;
				colvarIdDirectoriosArchivos.DefaultSetting = @"";
				colvarIdDirectoriosArchivos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDirectoriosArchivos);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_subir_archivos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Categoria")]
		[Bindable(true)]
		public string Categoria 
		{
			get { return GetColumnValue<string>(Columns.Categoria); }
			set { SetColumnValue(Columns.Categoria, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("Creadopor")]
		[Bindable(true)]
		public string Creadopor 
		{
			get { return GetColumnValue<string>(Columns.Creadopor); }
			set { SetColumnValue(Columns.Creadopor, value); }
		}
		  
		[XmlAttribute("Size")]
		[Bindable(true)]
		public string Size 
		{
			get { return GetColumnValue<string>(Columns.Size); }
			set { SetColumnValue(Columns.Size, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Acceso")]
		[Bindable(true)]
		public string Acceso 
		{
			get { return GetColumnValue<string>(Columns.Acceso); }
			set { SetColumnValue(Columns.Acceso, value); }
		}
		  
		[XmlAttribute("IdDirectoriosArchivos")]
		[Bindable(true)]
		public string IdDirectoriosArchivos 
		{
			get { return GetColumnValue<string>(Columns.IdDirectoriosArchivos); }
			set { SetColumnValue(Columns.IdDirectoriosArchivos, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varCategoria,string varComentario,string varCreadopor,string varSize,DateTime varFecha,string varAcceso,string varIdDirectoriosArchivos)
		{
			PnSubirArchivo item = new PnSubirArchivo();
			
			item.Nombre = varNombre;
			
			item.Categoria = varCategoria;
			
			item.Comentario = varComentario;
			
			item.Creadopor = varCreadopor;
			
			item.Size = varSize;
			
			item.Fecha = varFecha;
			
			item.Acceso = varAcceso;
			
			item.IdDirectoriosArchivos = varIdDirectoriosArchivos;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varNombre,string varCategoria,string varComentario,string varCreadopor,string varSize,DateTime varFecha,string varAcceso,string varIdDirectoriosArchivos)
		{
			PnSubirArchivo item = new PnSubirArchivo();
			
				item.Id = varId;
			
				item.Nombre = varNombre;
			
				item.Categoria = varCategoria;
			
				item.Comentario = varComentario;
			
				item.Creadopor = varCreadopor;
			
				item.Size = varSize;
			
				item.Fecha = varFecha;
			
				item.Acceso = varAcceso;
			
				item.IdDirectoriosArchivos = varIdDirectoriosArchivos;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoriaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreadoporColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SizeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AccesoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDirectoriosArchivosColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Nombre = @"nombre";
			 public static string Categoria = @"categoria";
			 public static string Comentario = @"comentario";
			 public static string Creadopor = @"creadopor";
			 public static string Size = @"size";
			 public static string Fecha = @"fecha";
			 public static string Acceso = @"acceso";
			 public static string IdDirectoriosArchivos = @"id_directorios_archivos";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
