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
	/// Strongly-typed collection for the PnLogEvento class.
	/// </summary>
    [Serializable]
	public partial class PnLogEventoCollection : ActiveList<PnLogEvento, PnLogEventoCollection>
	{	   
		public PnLogEventoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLogEventoCollection</returns>
		public PnLogEventoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLogEvento o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_log_evento table.
	/// </summary>
	[Serializable]
	public partial class PnLogEvento : ActiveRecord<PnLogEvento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLogEvento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLogEvento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLogEvento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLogEvento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_log_evento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLog = new TableSchema.TableColumn(schema);
				colvarIdLog.ColumnName = "id_log";
				colvarIdLog.DataType = DbType.Int32;
				colvarIdLog.MaxLength = 0;
				colvarIdLog.AutoIncrement = true;
				colvarIdLog.IsNullable = false;
				colvarIdLog.IsPrimaryKey = true;
				colvarIdLog.IsForeignKey = false;
				colvarIdLog.IsReadOnly = false;
				colvarIdLog.DefaultSetting = @"";
				colvarIdLog.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLog);
				
				TableSchema.TableColumn colvarIdEvento = new TableSchema.TableColumn(schema);
				colvarIdEvento.ColumnName = "id_evento";
				colvarIdEvento.DataType = DbType.Int32;
				colvarIdEvento.MaxLength = 0;
				colvarIdEvento.AutoIncrement = false;
				colvarIdEvento.IsNullable = false;
				colvarIdEvento.IsPrimaryKey = false;
				colvarIdEvento.IsForeignKey = false;
				colvarIdEvento.IsReadOnly = false;
				colvarIdEvento.DefaultSetting = @"";
				colvarIdEvento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEvento);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_log_evento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLog")]
		[Bindable(true)]
		public int IdLog 
		{
			get { return GetColumnValue<int>(Columns.IdLog); }
			set { SetColumnValue(Columns.IdLog, value); }
		}
		  
		[XmlAttribute("IdEvento")]
		[Bindable(true)]
		public int IdEvento 
		{
			get { return GetColumnValue<int>(Columns.IdEvento); }
			set { SetColumnValue(Columns.IdEvento, value); }
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
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEvento,string varUsuario,DateTime? varFecha,string varComentario)
		{
			PnLogEvento item = new PnLogEvento();
			
			item.IdEvento = varIdEvento;
			
			item.Usuario = varUsuario;
			
			item.Fecha = varFecha;
			
			item.Comentario = varComentario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLog,int varIdEvento,string varUsuario,DateTime? varFecha,string varComentario)
		{
			PnLogEvento item = new PnLogEvento();
			
				item.IdLog = varIdLog;
			
				item.IdEvento = varIdEvento;
			
				item.Usuario = varUsuario;
			
				item.Fecha = varFecha;
			
				item.Comentario = varComentario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLogColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEventoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLog = @"id_log";
			 public static string IdEvento = @"id_evento";
			 public static string Usuario = @"usuario";
			 public static string Fecha = @"fecha";
			 public static string Comentario = @"comentario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
