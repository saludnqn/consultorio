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
	/// Strongly-typed collection for the PnLogManual class.
	/// </summary>
    [Serializable]
	public partial class PnLogManualCollection : ActiveList<PnLogManual, PnLogManualCollection>
	{	   
		public PnLogManualCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLogManualCollection</returns>
		public PnLogManualCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLogManual o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_log_manual table.
	/// </summary>
	[Serializable]
	public partial class PnLogManual : ActiveRecord<PnLogManual>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLogManual()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLogManual(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLogManual(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLogManual(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_log_manual", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLogManual = new TableSchema.TableColumn(schema);
				colvarIdLogManual.ColumnName = "id_log_manual";
				colvarIdLogManual.DataType = DbType.Int32;
				colvarIdLogManual.MaxLength = 0;
				colvarIdLogManual.AutoIncrement = true;
				colvarIdLogManual.IsNullable = false;
				colvarIdLogManual.IsPrimaryKey = true;
				colvarIdLogManual.IsForeignKey = false;
				colvarIdLogManual.IsReadOnly = false;
				colvarIdLogManual.DefaultSetting = @"";
				colvarIdLogManual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLogManual);
				
				TableSchema.TableColumn colvarIdManual = new TableSchema.TableColumn(schema);
				colvarIdManual.ColumnName = "id_manual";
				colvarIdManual.DataType = DbType.Int32;
				colvarIdManual.MaxLength = 0;
				colvarIdManual.AutoIncrement = false;
				colvarIdManual.IsNullable = false;
				colvarIdManual.IsPrimaryKey = false;
				colvarIdManual.IsForeignKey = false;
				colvarIdManual.IsReadOnly = false;
				colvarIdManual.DefaultSetting = @"";
				colvarIdManual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdManual);
				
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
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.AnsiString;
				colvarTipo.MaxLength = -1;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_log_manual",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLogManual")]
		[Bindable(true)]
		public int IdLogManual 
		{
			get { return GetColumnValue<int>(Columns.IdLogManual); }
			set { SetColumnValue(Columns.IdLogManual, value); }
		}
		  
		[XmlAttribute("IdManual")]
		[Bindable(true)]
		public int IdManual 
		{
			get { return GetColumnValue<int>(Columns.IdManual); }
			set { SetColumnValue(Columns.IdManual, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdManual,DateTime? varFecha,string varUsuario,string varTipo)
		{
			PnLogManual item = new PnLogManual();
			
			item.IdManual = varIdManual;
			
			item.Fecha = varFecha;
			
			item.Usuario = varUsuario;
			
			item.Tipo = varTipo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLogManual,int varIdManual,DateTime? varFecha,string varUsuario,string varTipo)
		{
			PnLogManual item = new PnLogManual();
			
				item.IdLogManual = varIdLogManual;
			
				item.IdManual = varIdManual;
			
				item.Fecha = varFecha;
			
				item.Usuario = varUsuario;
			
				item.Tipo = varTipo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLogManualColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdManualColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLogManual = @"id_log_manual";
			 public static string IdManual = @"id_manual";
			 public static string Fecha = @"fecha";
			 public static string Usuario = @"usuario";
			 public static string Tipo = @"tipo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
