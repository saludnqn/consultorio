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
	/// Strongly-typed collection for the PnLogPacPap class.
	/// </summary>
    [Serializable]
	public partial class PnLogPacPapCollection : ActiveList<PnLogPacPap, PnLogPacPapCollection>
	{	   
		public PnLogPacPapCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLogPacPapCollection</returns>
		public PnLogPacPapCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLogPacPap o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_log_pac_pap table.
	/// </summary>
	[Serializable]
	public partial class PnLogPacPap : ActiveRecord<PnLogPacPap>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLogPacPap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLogPacPap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLogPacPap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLogPacPap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_log_pac_pap", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLogPacPap = new TableSchema.TableColumn(schema);
				colvarIdLogPacPap.ColumnName = "id_log_pac_pap";
				colvarIdLogPacPap.DataType = DbType.Int32;
				colvarIdLogPacPap.MaxLength = 0;
				colvarIdLogPacPap.AutoIncrement = true;
				colvarIdLogPacPap.IsNullable = false;
				colvarIdLogPacPap.IsPrimaryKey = true;
				colvarIdLogPacPap.IsForeignKey = false;
				colvarIdLogPacPap.IsReadOnly = false;
				colvarIdLogPacPap.DefaultSetting = @"";
				colvarIdLogPacPap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLogPacPap);
				
				TableSchema.TableColumn colvarIdPacPap = new TableSchema.TableColumn(schema);
				colvarIdPacPap.ColumnName = "id_pac_pap";
				colvarIdPacPap.DataType = DbType.Int32;
				colvarIdPacPap.MaxLength = 0;
				colvarIdPacPap.AutoIncrement = false;
				colvarIdPacPap.IsNullable = false;
				colvarIdPacPap.IsPrimaryKey = false;
				colvarIdPacPap.IsForeignKey = false;
				colvarIdPacPap.IsReadOnly = false;
				colvarIdPacPap.DefaultSetting = @"";
				colvarIdPacPap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPacPap);
				
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
				
				TableSchema.TableColumn colvarForma = new TableSchema.TableColumn(schema);
				colvarForma.ColumnName = "forma";
				colvarForma.DataType = DbType.AnsiString;
				colvarForma.MaxLength = -1;
				colvarForma.AutoIncrement = false;
				colvarForma.IsNullable = true;
				colvarForma.IsPrimaryKey = false;
				colvarForma.IsForeignKey = false;
				colvarForma.IsReadOnly = false;
				colvarForma.DefaultSetting = @"";
				colvarForma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarForma);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_log_pac_pap",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLogPacPap")]
		[Bindable(true)]
		public int IdLogPacPap 
		{
			get { return GetColumnValue<int>(Columns.IdLogPacPap); }
			set { SetColumnValue(Columns.IdLogPacPap, value); }
		}
		  
		[XmlAttribute("IdPacPap")]
		[Bindable(true)]
		public int IdPacPap 
		{
			get { return GetColumnValue<int>(Columns.IdPacPap); }
			set { SetColumnValue(Columns.IdPacPap, value); }
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
		  
		[XmlAttribute("Forma")]
		[Bindable(true)]
		public string Forma 
		{
			get { return GetColumnValue<string>(Columns.Forma); }
			set { SetColumnValue(Columns.Forma, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPacPap,DateTime? varFecha,string varUsuario,string varTipo,string varForma)
		{
			PnLogPacPap item = new PnLogPacPap();
			
			item.IdPacPap = varIdPacPap;
			
			item.Fecha = varFecha;
			
			item.Usuario = varUsuario;
			
			item.Tipo = varTipo;
			
			item.Forma = varForma;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLogPacPap,int varIdPacPap,DateTime? varFecha,string varUsuario,string varTipo,string varForma)
		{
			PnLogPacPap item = new PnLogPacPap();
			
				item.IdLogPacPap = varIdLogPacPap;
			
				item.IdPacPap = varIdPacPap;
			
				item.Fecha = varFecha;
			
				item.Usuario = varUsuario;
			
				item.Tipo = varTipo;
			
				item.Forma = varForma;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLogPacPapColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacPapColumn
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
        
        
        
        public static TableSchema.TableColumn FormaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLogPacPap = @"id_log_pac_pap";
			 public static string IdPacPap = @"id_pac_pap";
			 public static string Fecha = @"fecha";
			 public static string Usuario = @"usuario";
			 public static string Tipo = @"tipo";
			 public static string Forma = @"forma";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
