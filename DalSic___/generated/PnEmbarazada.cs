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
	/// Strongly-typed collection for the PnEmbarazada class.
	/// </summary>
    [Serializable]
	public partial class PnEmbarazadaCollection : ActiveList<PnEmbarazada, PnEmbarazadaCollection>
	{	   
		public PnEmbarazadaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEmbarazadaCollection</returns>
		public PnEmbarazadaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEmbarazada o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_embarazadas table.
	/// </summary>
	[Serializable]
	public partial class PnEmbarazada : ActiveRecord<PnEmbarazada>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEmbarazada()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEmbarazada(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEmbarazada(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEmbarazada(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_embarazadas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEmb = new TableSchema.TableColumn(schema);
				colvarIdEmb.ColumnName = "id_emb";
				colvarIdEmb.DataType = DbType.Int32;
				colvarIdEmb.MaxLength = 0;
				colvarIdEmb.AutoIncrement = true;
				colvarIdEmb.IsNullable = false;
				colvarIdEmb.IsPrimaryKey = true;
				colvarIdEmb.IsForeignKey = false;
				colvarIdEmb.IsReadOnly = false;
				colvarIdEmb.DefaultSetting = @"";
				colvarIdEmb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEmb);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarClave = new TableSchema.TableColumn(schema);
				colvarClave.ColumnName = "clave";
				colvarClave.DataType = DbType.AnsiString;
				colvarClave.MaxLength = 50;
				colvarClave.AutoIncrement = false;
				colvarClave.IsNullable = true;
				colvarClave.IsPrimaryKey = false;
				colvarClave.IsForeignKey = false;
				colvarClave.IsReadOnly = false;
				colvarClave.DefaultSetting = @"";
				colvarClave.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClave);
				
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
				
				TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
				colvarFechaControl.ColumnName = "fecha_control";
				colvarFechaControl.DataType = DbType.DateTime;
				colvarFechaControl.MaxLength = 0;
				colvarFechaControl.AutoIncrement = false;
				colvarFechaControl.IsNullable = true;
				colvarFechaControl.IsPrimaryKey = false;
				colvarFechaControl.IsForeignKey = false;
				colvarFechaControl.IsReadOnly = false;
				colvarFechaControl.DefaultSetting = @"";
				colvarFechaControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaControl);
				
				TableSchema.TableColumn colvarSemGestacion = new TableSchema.TableColumn(schema);
				colvarSemGestacion.ColumnName = "sem_gestacion";
				colvarSemGestacion.DataType = DbType.Decimal;
				colvarSemGestacion.MaxLength = 0;
				colvarSemGestacion.AutoIncrement = false;
				colvarSemGestacion.IsNullable = true;
				colvarSemGestacion.IsPrimaryKey = false;
				colvarSemGestacion.IsForeignKey = false;
				colvarSemGestacion.IsReadOnly = false;
				colvarSemGestacion.DefaultSetting = @"";
				colvarSemGestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSemGestacion);
				
				TableSchema.TableColumn colvarFum = new TableSchema.TableColumn(schema);
				colvarFum.ColumnName = "fum";
				colvarFum.DataType = DbType.DateTime;
				colvarFum.MaxLength = 0;
				colvarFum.AutoIncrement = false;
				colvarFum.IsNullable = true;
				colvarFum.IsPrimaryKey = false;
				colvarFum.IsForeignKey = false;
				colvarFum.IsReadOnly = false;
				colvarFum.DefaultSetting = @"";
				colvarFum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFum);
				
				TableSchema.TableColumn colvarFpp = new TableSchema.TableColumn(schema);
				colvarFpp.ColumnName = "fpp";
				colvarFpp.DataType = DbType.DateTime;
				colvarFpp.MaxLength = 0;
				colvarFpp.AutoIncrement = false;
				colvarFpp.IsNullable = true;
				colvarFpp.IsPrimaryKey = false;
				colvarFpp.IsForeignKey = false;
				colvarFpp.IsReadOnly = false;
				colvarFpp.DefaultSetting = @"";
				colvarFpp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFpp);
				
				TableSchema.TableColumn colvarFpcp = new TableSchema.TableColumn(schema);
				colvarFpcp.ColumnName = "fpcp";
				colvarFpcp.DataType = DbType.DateTime;
				colvarFpcp.MaxLength = 0;
				colvarFpcp.AutoIncrement = false;
				colvarFpcp.IsNullable = true;
				colvarFpcp.IsPrimaryKey = false;
				colvarFpcp.IsForeignKey = false;
				colvarFpcp.IsReadOnly = false;
				colvarFpcp.DefaultSetting = @"";
				colvarFpcp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFpcp);
				
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
				
				TableSchema.TableColumn colvarAntitetanica = new TableSchema.TableColumn(schema);
				colvarAntitetanica.ColumnName = "antitetanica";
				colvarAntitetanica.DataType = DbType.AnsiString;
				colvarAntitetanica.MaxLength = -1;
				colvarAntitetanica.AutoIncrement = false;
				colvarAntitetanica.IsNullable = true;
				colvarAntitetanica.IsPrimaryKey = false;
				colvarAntitetanica.IsForeignKey = false;
				colvarAntitetanica.IsReadOnly = false;
				colvarAntitetanica.DefaultSetting = @"";
				colvarAntitetanica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntitetanica);
				
				TableSchema.TableColumn colvarVdrl = new TableSchema.TableColumn(schema);
				colvarVdrl.ColumnName = "vdrl";
				colvarVdrl.DataType = DbType.AnsiString;
				colvarVdrl.MaxLength = -1;
				colvarVdrl.AutoIncrement = false;
				colvarVdrl.IsNullable = true;
				colvarVdrl.IsPrimaryKey = false;
				colvarVdrl.IsForeignKey = false;
				colvarVdrl.IsReadOnly = false;
				colvarVdrl.DefaultSetting = @"";
				colvarVdrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVdrl);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_embarazadas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEmb")]
		[Bindable(true)]
		public int IdEmb 
		{
			get { return GetColumnValue<int>(Columns.IdEmb); }
			set { SetColumnValue(Columns.IdEmb, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Clave")]
		[Bindable(true)]
		public string Clave 
		{
			get { return GetColumnValue<string>(Columns.Clave); }
			set { SetColumnValue(Columns.Clave, value); }
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
		  
		[XmlAttribute("FechaControl")]
		[Bindable(true)]
		public DateTime? FechaControl 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaControl); }
			set { SetColumnValue(Columns.FechaControl, value); }
		}
		  
		[XmlAttribute("SemGestacion")]
		[Bindable(true)]
		public decimal? SemGestacion 
		{
			get { return GetColumnValue<decimal?>(Columns.SemGestacion); }
			set { SetColumnValue(Columns.SemGestacion, value); }
		}
		  
		[XmlAttribute("Fum")]
		[Bindable(true)]
		public DateTime? Fum 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fum); }
			set { SetColumnValue(Columns.Fum, value); }
		}
		  
		[XmlAttribute("Fpp")]
		[Bindable(true)]
		public DateTime? Fpp 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fpp); }
			set { SetColumnValue(Columns.Fpp, value); }
		}
		  
		[XmlAttribute("Fpcp")]
		[Bindable(true)]
		public DateTime? Fpcp 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fpcp); }
			set { SetColumnValue(Columns.Fpcp, value); }
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
		  
		[XmlAttribute("Antitetanica")]
		[Bindable(true)]
		public string Antitetanica 
		{
			get { return GetColumnValue<string>(Columns.Antitetanica); }
			set { SetColumnValue(Columns.Antitetanica, value); }
		}
		  
		[XmlAttribute("Vdrl")]
		[Bindable(true)]
		public string Vdrl 
		{
			get { return GetColumnValue<string>(Columns.Vdrl); }
			set { SetColumnValue(Columns.Vdrl, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varClave,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaControl,decimal? varSemGestacion,DateTime? varFum,DateTime? varFpp,DateTime? varFpcp,string varObservaciones,DateTime? varFechaCarga,string varUsuario,string varAntitetanica,string varVdrl)
		{
			PnEmbarazada item = new PnEmbarazada();
			
			item.Cuie = varCuie;
			
			item.Clave = varClave;
			
			item.TipoDoc = varTipoDoc;
			
			item.NumDoc = varNumDoc;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.FechaControl = varFechaControl;
			
			item.SemGestacion = varSemGestacion;
			
			item.Fum = varFum;
			
			item.Fpp = varFpp;
			
			item.Fpcp = varFpcp;
			
			item.Observaciones = varObservaciones;
			
			item.FechaCarga = varFechaCarga;
			
			item.Usuario = varUsuario;
			
			item.Antitetanica = varAntitetanica;
			
			item.Vdrl = varVdrl;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEmb,string varCuie,string varClave,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaControl,decimal? varSemGestacion,DateTime? varFum,DateTime? varFpp,DateTime? varFpcp,string varObservaciones,DateTime? varFechaCarga,string varUsuario,string varAntitetanica,string varVdrl)
		{
			PnEmbarazada item = new PnEmbarazada();
			
				item.IdEmb = varIdEmb;
			
				item.Cuie = varCuie;
			
				item.Clave = varClave;
			
				item.TipoDoc = varTipoDoc;
			
				item.NumDoc = varNumDoc;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.FechaControl = varFechaControl;
			
				item.SemGestacion = varSemGestacion;
			
				item.Fum = varFum;
			
				item.Fpp = varFpp;
			
				item.Fpcp = varFpcp;
			
				item.Observaciones = varObservaciones;
			
				item.FechaCarga = varFechaCarga;
			
				item.Usuario = varUsuario;
			
				item.Antitetanica = varAntitetanica;
			
				item.Vdrl = varVdrl;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEmbColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaveColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumDocColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn SemGestacionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FumColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FppColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FpcpColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn AntitetanicaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn VdrlColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEmb = @"id_emb";
			 public static string Cuie = @"cuie";
			 public static string Clave = @"clave";
			 public static string TipoDoc = @"tipo_doc";
			 public static string NumDoc = @"num_doc";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string FechaControl = @"fecha_control";
			 public static string SemGestacion = @"sem_gestacion";
			 public static string Fum = @"fum";
			 public static string Fpp = @"fpp";
			 public static string Fpcp = @"fpcp";
			 public static string Observaciones = @"observaciones";
			 public static string FechaCarga = @"fecha_carga";
			 public static string Usuario = @"usuario";
			 public static string Antitetanica = @"antitetanica";
			 public static string Vdrl = @"vdrl";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
