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
	/// Strongly-typed collection for the LabItemScreeningResultado class.
	/// </summary>
    [Serializable]
	public partial class LabItemScreeningResultadoCollection : ActiveList<LabItemScreeningResultado, LabItemScreeningResultadoCollection>
	{	   
		public LabItemScreeningResultadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabItemScreeningResultadoCollection</returns>
		public LabItemScreeningResultadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabItemScreeningResultado o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_ItemScreeningResultado table.
	/// </summary>
	[Serializable]
	public partial class LabItemScreeningResultado : ActiveRecord<LabItemScreeningResultado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabItemScreeningResultado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabItemScreeningResultado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabItemScreeningResultado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabItemScreeningResultado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_ItemScreeningResultado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdResultado = new TableSchema.TableColumn(schema);
				colvarIdResultado.ColumnName = "idResultado";
				colvarIdResultado.DataType = DbType.Int32;
				colvarIdResultado.MaxLength = 0;
				colvarIdResultado.AutoIncrement = true;
				colvarIdResultado.IsNullable = false;
				colvarIdResultado.IsPrimaryKey = true;
				colvarIdResultado.IsForeignKey = false;
				colvarIdResultado.IsReadOnly = false;
				colvarIdResultado.DefaultSetting = @"";
				colvarIdResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdResultado);
				
				TableSchema.TableColumn colvarIdItemScreening = new TableSchema.TableColumn(schema);
				colvarIdItemScreening.ColumnName = "idItemScreening";
				colvarIdItemScreening.DataType = DbType.Int32;
				colvarIdItemScreening.MaxLength = 0;
				colvarIdItemScreening.AutoIncrement = false;
				colvarIdItemScreening.IsNullable = false;
				colvarIdItemScreening.IsPrimaryKey = false;
				colvarIdItemScreening.IsForeignKey = true;
				colvarIdItemScreening.IsReadOnly = false;
				colvarIdItemScreening.DefaultSetting = @"";
				
					colvarIdItemScreening.ForeignKeyTableName = "LAB_ItemScreening";
				schema.Columns.Add(colvarIdItemScreening);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 200;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarAbreviatura = new TableSchema.TableColumn(schema);
				colvarAbreviatura.ColumnName = "abreviatura";
				colvarAbreviatura.DataType = DbType.AnsiString;
				colvarAbreviatura.MaxLength = 50;
				colvarAbreviatura.AutoIncrement = false;
				colvarAbreviatura.IsNullable = false;
				colvarAbreviatura.IsPrimaryKey = false;
				colvarAbreviatura.IsForeignKey = false;
				colvarAbreviatura.IsReadOnly = false;
				colvarAbreviatura.DefaultSetting = @"";
				colvarAbreviatura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAbreviatura);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = false;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				
						colvarBaja.DefaultSetting = @"((0))";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.Int32;
				colvarIdUsuarioRegistro.MaxLength = 0;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = false;
				colvarIdUsuarioRegistro.IsPrimaryKey = false;
				colvarIdUsuarioRegistro.IsForeignKey = false;
				colvarIdUsuarioRegistro.IsReadOnly = false;
				colvarIdUsuarioRegistro.DefaultSetting = @"";
				colvarIdUsuarioRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRegistro);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				
						colvarFechaRegistro.DefaultSetting = @"(getdate())";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				TableSchema.TableColumn colvarPendiente = new TableSchema.TableColumn(schema);
				colvarPendiente.ColumnName = "pendiente";
				colvarPendiente.DataType = DbType.Boolean;
				colvarPendiente.MaxLength = 0;
				colvarPendiente.AutoIncrement = false;
				colvarPendiente.IsNullable = false;
				colvarPendiente.IsPrimaryKey = false;
				colvarPendiente.IsForeignKey = false;
				colvarPendiente.IsReadOnly = false;
				
						colvarPendiente.DefaultSetting = @"((0))";
				colvarPendiente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPendiente);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_ItemScreeningResultado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdResultado")]
		[Bindable(true)]
		public int IdResultado 
		{
			get { return GetColumnValue<int>(Columns.IdResultado); }
			set { SetColumnValue(Columns.IdResultado, value); }
		}
		  
		[XmlAttribute("IdItemScreening")]
		[Bindable(true)]
		public int IdItemScreening 
		{
			get { return GetColumnValue<int>(Columns.IdItemScreening); }
			set { SetColumnValue(Columns.IdItemScreening, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Abreviatura")]
		[Bindable(true)]
		public string Abreviatura 
		{
			get { return GetColumnValue<string>(Columns.Abreviatura); }
			set { SetColumnValue(Columns.Abreviatura, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool Baja 
		{
			get { return GetColumnValue<bool>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public int IdUsuarioRegistro 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("Pendiente")]
		[Bindable(true)]
		public bool Pendiente 
		{
			get { return GetColumnValue<bool>(Columns.Pendiente); }
			set { SetColumnValue(Columns.Pendiente, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabItemScreening ActiveRecord object related to this LabItemScreeningResultado
		/// 
		/// </summary>
		public DalSic.LabItemScreening LabItemScreening
		{
			get { return DalSic.LabItemScreening.FetchByID(this.IdItemScreening); }
			set { SetColumnValue("idItemScreening", value.IdItemScreening); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdItemScreening,string varNombre,string varAbreviatura,bool varBaja,int varIdUsuarioRegistro,DateTime varFechaRegistro,bool varPendiente)
		{
			LabItemScreeningResultado item = new LabItemScreeningResultado();
			
			item.IdItemScreening = varIdItemScreening;
			
			item.Nombre = varNombre;
			
			item.Abreviatura = varAbreviatura;
			
			item.Baja = varBaja;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.Pendiente = varPendiente;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdResultado,int varIdItemScreening,string varNombre,string varAbreviatura,bool varBaja,int varIdUsuarioRegistro,DateTime varFechaRegistro,bool varPendiente)
		{
			LabItemScreeningResultado item = new LabItemScreeningResultado();
			
				item.IdResultado = varIdResultado;
			
				item.IdItemScreening = varIdItemScreening;
			
				item.Nombre = varNombre;
			
				item.Abreviatura = varAbreviatura;
			
				item.Baja = varBaja;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.Pendiente = varPendiente;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdResultadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemScreeningColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AbreviaturaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PendienteColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdResultado = @"idResultado";
			 public static string IdItemScreening = @"idItemScreening";
			 public static string Nombre = @"nombre";
			 public static string Abreviatura = @"abreviatura";
			 public static string Baja = @"baja";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string Pendiente = @"pendiente";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
