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
	/// Strongly-typed collection for the PnLogPlanilla class.
	/// </summary>
    [Serializable]
	public partial class PnLogPlanillaCollection : ActiveList<PnLogPlanilla, PnLogPlanillaCollection>
	{	   
		public PnLogPlanillaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLogPlanillaCollection</returns>
		public PnLogPlanillaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLogPlanilla o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_log_planilla table.
	/// </summary>
	[Serializable]
	public partial class PnLogPlanilla : ActiveRecord<PnLogPlanilla>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLogPlanilla()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLogPlanilla(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLogPlanilla(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLogPlanilla(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_log_planilla", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLogPlanilla = new TableSchema.TableColumn(schema);
				colvarIdLogPlanilla.ColumnName = "id_log_planilla";
				colvarIdLogPlanilla.DataType = DbType.Int32;
				colvarIdLogPlanilla.MaxLength = 0;
				colvarIdLogPlanilla.AutoIncrement = true;
				colvarIdLogPlanilla.IsNullable = false;
				colvarIdLogPlanilla.IsPrimaryKey = true;
				colvarIdLogPlanilla.IsForeignKey = false;
				colvarIdLogPlanilla.IsReadOnly = false;
				colvarIdLogPlanilla.DefaultSetting = @"";
				colvarIdLogPlanilla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLogPlanilla);
				
				TableSchema.TableColumn colvarIdPlanillas = new TableSchema.TableColumn(schema);
				colvarIdPlanillas.ColumnName = "id_planillas";
				colvarIdPlanillas.DataType = DbType.Int32;
				colvarIdPlanillas.MaxLength = 0;
				colvarIdPlanillas.AutoIncrement = false;
				colvarIdPlanillas.IsNullable = false;
				colvarIdPlanillas.IsPrimaryKey = false;
				colvarIdPlanillas.IsForeignKey = false;
				colvarIdPlanillas.IsReadOnly = false;
				colvarIdPlanillas.DefaultSetting = @"";
				colvarIdPlanillas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPlanillas);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_log_planilla",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLogPlanilla")]
		[Bindable(true)]
		public int IdLogPlanilla 
		{
			get { return GetColumnValue<int>(Columns.IdLogPlanilla); }
			set { SetColumnValue(Columns.IdLogPlanilla, value); }
		}
		  
		[XmlAttribute("IdPlanillas")]
		[Bindable(true)]
		public int IdPlanillas 
		{
			get { return GetColumnValue<int>(Columns.IdPlanillas); }
			set { SetColumnValue(Columns.IdPlanillas, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPlanillas,string varDescripcion,string varUsuario,DateTime? varFecha)
		{
			PnLogPlanilla item = new PnLogPlanilla();
			
			item.IdPlanillas = varIdPlanillas;
			
			item.Descripcion = varDescripcion;
			
			item.Usuario = varUsuario;
			
			item.Fecha = varFecha;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLogPlanilla,int varIdPlanillas,string varDescripcion,string varUsuario,DateTime? varFecha)
		{
			PnLogPlanilla item = new PnLogPlanilla();
			
				item.IdLogPlanilla = varIdLogPlanilla;
			
				item.IdPlanillas = varIdPlanillas;
			
				item.Descripcion = varDescripcion;
			
				item.Usuario = varUsuario;
			
				item.Fecha = varFecha;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLogPlanillaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPlanillasColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLogPlanilla = @"id_log_planilla";
			 public static string IdPlanillas = @"id_planillas";
			 public static string Descripcion = @"descripcion";
			 public static string Usuario = @"usuario";
			 public static string Fecha = @"fecha";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
