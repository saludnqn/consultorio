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
	/// Strongly-typed collection for the PnMu class.
	/// </summary>
    [Serializable]
	public partial class PnMuCollection : ActiveList<PnMu, PnMuCollection>
	{	   
		public PnMuCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnMuCollection</returns>
		public PnMuCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnMu o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_mu table.
	/// </summary>
	[Serializable]
	public partial class PnMu : ActiveRecord<PnMu>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnMu()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnMu(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnMu(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnMu(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_mu", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMu = new TableSchema.TableColumn(schema);
				colvarIdMu.ColumnName = "id_mu";
				colvarIdMu.DataType = DbType.Int32;
				colvarIdMu.MaxLength = 0;
				colvarIdMu.AutoIncrement = true;
				colvarIdMu.IsNullable = false;
				colvarIdMu.IsPrimaryKey = true;
				colvarIdMu.IsForeignKey = false;
				colvarIdMu.IsReadOnly = false;
				colvarIdMu.DefaultSetting = @"";
				colvarIdMu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMu);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = -1;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarTipoDoc = new TableSchema.TableColumn(schema);
				colvarTipoDoc.ColumnName = "tipo_doc";
				colvarTipoDoc.DataType = DbType.AnsiString;
				colvarTipoDoc.MaxLength = -1;
				colvarTipoDoc.AutoIncrement = false;
				colvarTipoDoc.IsNullable = true;
				colvarTipoDoc.IsPrimaryKey = false;
				colvarTipoDoc.IsForeignKey = false;
				colvarTipoDoc.IsReadOnly = false;
				colvarTipoDoc.DefaultSetting = @"";
				colvarTipoDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDoc);
				
				TableSchema.TableColumn colvarNumDoc = new TableSchema.TableColumn(schema);
				colvarNumDoc.ColumnName = "num_doc";
				colvarNumDoc.DataType = DbType.Decimal;
				colvarNumDoc.MaxLength = 0;
				colvarNumDoc.AutoIncrement = false;
				colvarNumDoc.IsNullable = true;
				colvarNumDoc.IsPrimaryKey = false;
				colvarNumDoc.IsForeignKey = false;
				colvarNumDoc.IsReadOnly = false;
				colvarNumDoc.DefaultSetting = @"";
				colvarNumDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumDoc);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = -1;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarFechaDefuncion = new TableSchema.TableColumn(schema);
				colvarFechaDefuncion.ColumnName = "fecha_defuncion";
				colvarFechaDefuncion.DataType = DbType.DateTime;
				colvarFechaDefuncion.MaxLength = 0;
				colvarFechaDefuncion.AutoIncrement = false;
				colvarFechaDefuncion.IsNullable = true;
				colvarFechaDefuncion.IsPrimaryKey = false;
				colvarFechaDefuncion.IsForeignKey = false;
				colvarFechaDefuncion.IsReadOnly = false;
				colvarFechaDefuncion.DefaultSetting = @"";
				colvarFechaDefuncion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDefuncion);
				
				TableSchema.TableColumn colvarFechaAuditoria = new TableSchema.TableColumn(schema);
				colvarFechaAuditoria.ColumnName = "fecha_auditoria";
				colvarFechaAuditoria.DataType = DbType.DateTime;
				colvarFechaAuditoria.MaxLength = 0;
				colvarFechaAuditoria.AutoIncrement = false;
				colvarFechaAuditoria.IsNullable = true;
				colvarFechaAuditoria.IsPrimaryKey = false;
				colvarFechaAuditoria.IsForeignKey = false;
				colvarFechaAuditoria.IsReadOnly = false;
				colvarFechaAuditoria.DefaultSetting = @"";
				colvarFechaAuditoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAuditoria);
				
				TableSchema.TableColumn colvarFechaParInt = new TableSchema.TableColumn(schema);
				colvarFechaParInt.ColumnName = "fecha_par_int";
				colvarFechaParInt.DataType = DbType.DateTime;
				colvarFechaParInt.MaxLength = 0;
				colvarFechaParInt.AutoIncrement = false;
				colvarFechaParInt.IsNullable = true;
				colvarFechaParInt.IsPrimaryKey = false;
				colvarFechaParInt.IsForeignKey = false;
				colvarFechaParInt.IsReadOnly = false;
				colvarFechaParInt.DefaultSetting = @"";
				colvarFechaParInt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaParInt);
				
				TableSchema.TableColumn colvarFechaNac = new TableSchema.TableColumn(schema);
				colvarFechaNac.ColumnName = "fecha_nac";
				colvarFechaNac.DataType = DbType.DateTime;
				colvarFechaNac.MaxLength = 0;
				colvarFechaNac.AutoIncrement = false;
				colvarFechaNac.IsNullable = true;
				colvarFechaNac.IsPrimaryKey = false;
				colvarFechaNac.IsForeignKey = false;
				colvarFechaNac.IsReadOnly = false;
				colvarFechaNac.DefaultSetting = @"";
				colvarFechaNac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNac);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "fecha_carga";
				colvarFechaCarga.DataType = DbType.DateTime;
				colvarFechaCarga.MaxLength = 0;
				colvarFechaCarga.AutoIncrement = false;
				colvarFechaCarga.IsNullable = true;
				colvarFechaCarga.IsPrimaryKey = false;
				colvarFechaCarga.IsForeignKey = false;
				colvarFechaCarga.IsReadOnly = false;
				colvarFechaCarga.DefaultSetting = @"";
				colvarFechaCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCarga);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = -1;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_mu",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMu")]
		[Bindable(true)]
		public int IdMu 
		{
			get { return GetColumnValue<int>(Columns.IdMu); }
			set { SetColumnValue(Columns.IdMu, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("TipoDoc")]
		[Bindable(true)]
		public string TipoDoc 
		{
			get { return GetColumnValue<string>(Columns.TipoDoc); }
			set { SetColumnValue(Columns.TipoDoc, value); }
		}
		  
		[XmlAttribute("NumDoc")]
		[Bindable(true)]
		public decimal? NumDoc 
		{
			get { return GetColumnValue<decimal?>(Columns.NumDoc); }
			set { SetColumnValue(Columns.NumDoc, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("FechaDefuncion")]
		[Bindable(true)]
		public DateTime? FechaDefuncion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDefuncion); }
			set { SetColumnValue(Columns.FechaDefuncion, value); }
		}
		  
		[XmlAttribute("FechaAuditoria")]
		[Bindable(true)]
		public DateTime? FechaAuditoria 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAuditoria); }
			set { SetColumnValue(Columns.FechaAuditoria, value); }
		}
		  
		[XmlAttribute("FechaParInt")]
		[Bindable(true)]
		public DateTime? FechaParInt 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaParInt); }
			set { SetColumnValue(Columns.FechaParInt, value); }
		}
		  
		[XmlAttribute("FechaNac")]
		[Bindable(true)]
		public DateTime? FechaNac 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNac); }
			set { SetColumnValue(Columns.FechaNac, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaDefuncion,DateTime? varFechaAuditoria,DateTime? varFechaParInt,DateTime? varFechaNac,string varObservaciones,DateTime? varFechaCarga,string varUsuario)
		{
			PnMu item = new PnMu();
			
			item.Cuie = varCuie;
			
			item.TipoDoc = varTipoDoc;
			
			item.NumDoc = varNumDoc;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.FechaDefuncion = varFechaDefuncion;
			
			item.FechaAuditoria = varFechaAuditoria;
			
			item.FechaParInt = varFechaParInt;
			
			item.FechaNac = varFechaNac;
			
			item.Observaciones = varObservaciones;
			
			item.FechaCarga = varFechaCarga;
			
			item.Usuario = varUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMu,string varCuie,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaDefuncion,DateTime? varFechaAuditoria,DateTime? varFechaParInt,DateTime? varFechaNac,string varObservaciones,DateTime? varFechaCarga,string varUsuario)
		{
			PnMu item = new PnMu();
			
				item.IdMu = varIdMu;
			
				item.Cuie = varCuie;
			
				item.TipoDoc = varTipoDoc;
			
				item.NumDoc = varNumDoc;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.FechaDefuncion = varFechaDefuncion;
			
				item.FechaAuditoria = varFechaAuditoria;
			
				item.FechaParInt = varFechaParInt;
			
				item.FechaNac = varFechaNac;
			
				item.Observaciones = varObservaciones;
			
				item.FechaCarga = varFechaCarga;
			
				item.Usuario = varUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMuColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NumDocColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDefuncionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAuditoriaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaParIntColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMu = @"id_mu";
			 public static string Cuie = @"cuie";
			 public static string TipoDoc = @"tipo_doc";
			 public static string NumDoc = @"num_doc";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string FechaDefuncion = @"fecha_defuncion";
			 public static string FechaAuditoria = @"fecha_auditoria";
			 public static string FechaParInt = @"fecha_par_int";
			 public static string FechaNac = @"fecha_nac";
			 public static string Observaciones = @"observaciones";
			 public static string FechaCarga = @"fecha_carga";
			 public static string Usuario = @"usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
