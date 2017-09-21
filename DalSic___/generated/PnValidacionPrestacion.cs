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
	/// Strongly-typed collection for the PnValidacionPrestacion class.
	/// </summary>
    [Serializable]
	public partial class PnValidacionPrestacionCollection : ActiveList<PnValidacionPrestacion, PnValidacionPrestacionCollection>
	{	   
		public PnValidacionPrestacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnValidacionPrestacionCollection</returns>
		public PnValidacionPrestacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnValidacionPrestacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_validacion_prestacion table.
	/// </summary>
	[Serializable]
	public partial class PnValidacionPrestacion : ActiveRecord<PnValidacionPrestacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnValidacionPrestacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnValidacionPrestacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnValidacionPrestacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnValidacionPrestacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_validacion_prestacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdValPres = new TableSchema.TableColumn(schema);
				colvarIdValPres.ColumnName = "id_val_pres";
				colvarIdValPres.DataType = DbType.Int32;
				colvarIdValPres.MaxLength = 0;
				colvarIdValPres.AutoIncrement = true;
				colvarIdValPres.IsNullable = false;
				colvarIdValPres.IsPrimaryKey = true;
				colvarIdValPres.IsForeignKey = false;
				colvarIdValPres.IsReadOnly = false;
				colvarIdValPres.DefaultSetting = @"";
				colvarIdValPres.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdValPres);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiString;
				colvarCodigo.MaxLength = -1;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = true;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarCantPresLim = new TableSchema.TableColumn(schema);
				colvarCantPresLim.ColumnName = "cant_pres_lim";
				colvarCantPresLim.DataType = DbType.Int32;
				colvarCantPresLim.MaxLength = 0;
				colvarCantPresLim.AutoIncrement = false;
				colvarCantPresLim.IsNullable = true;
				colvarCantPresLim.IsPrimaryKey = false;
				colvarCantPresLim.IsForeignKey = false;
				colvarCantPresLim.IsReadOnly = false;
				colvarCantPresLim.DefaultSetting = @"";
				colvarCantPresLim.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantPresLim);
				
				TableSchema.TableColumn colvarPerPresLimite = new TableSchema.TableColumn(schema);
				colvarPerPresLimite.ColumnName = "per_pres_limite";
				colvarPerPresLimite.DataType = DbType.Int32;
				colvarPerPresLimite.MaxLength = 0;
				colvarPerPresLimite.AutoIncrement = false;
				colvarPerPresLimite.IsNullable = true;
				colvarPerPresLimite.IsPrimaryKey = false;
				colvarPerPresLimite.IsForeignKey = false;
				colvarPerPresLimite.IsReadOnly = false;
				colvarPerPresLimite.DefaultSetting = @"";
				colvarPerPresLimite.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerPresLimite);
				
				TableSchema.TableColumn colvarMsgError = new TableSchema.TableColumn(schema);
				colvarMsgError.ColumnName = "msg_error";
				colvarMsgError.DataType = DbType.AnsiString;
				colvarMsgError.MaxLength = -1;
				colvarMsgError.AutoIncrement = false;
				colvarMsgError.IsNullable = true;
				colvarMsgError.IsPrimaryKey = false;
				colvarMsgError.IsForeignKey = false;
				colvarMsgError.IsReadOnly = false;
				colvarMsgError.DefaultSetting = @"";
				colvarMsgError.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMsgError);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_validacion_prestacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdValPres")]
		[Bindable(true)]
		public int IdValPres 
		{
			get { return GetColumnValue<int>(Columns.IdValPres); }
			set { SetColumnValue(Columns.IdValPres, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("CantPresLim")]
		[Bindable(true)]
		public int? CantPresLim 
		{
			get { return GetColumnValue<int?>(Columns.CantPresLim); }
			set { SetColumnValue(Columns.CantPresLim, value); }
		}
		  
		[XmlAttribute("PerPresLimite")]
		[Bindable(true)]
		public int? PerPresLimite 
		{
			get { return GetColumnValue<int?>(Columns.PerPresLimite); }
			set { SetColumnValue(Columns.PerPresLimite, value); }
		}
		  
		[XmlAttribute("MsgError")]
		[Bindable(true)]
		public string MsgError 
		{
			get { return GetColumnValue<string>(Columns.MsgError); }
			set { SetColumnValue(Columns.MsgError, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodigo,int? varCantPresLim,int? varPerPresLimite,string varMsgError)
		{
			PnValidacionPrestacion item = new PnValidacionPrestacion();
			
			item.Codigo = varCodigo;
			
			item.CantPresLim = varCantPresLim;
			
			item.PerPresLimite = varPerPresLimite;
			
			item.MsgError = varMsgError;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdValPres,string varCodigo,int? varCantPresLim,int? varPerPresLimite,string varMsgError)
		{
			PnValidacionPrestacion item = new PnValidacionPrestacion();
			
				item.IdValPres = varIdValPres;
			
				item.Codigo = varCodigo;
			
				item.CantPresLim = varCantPresLim;
			
				item.PerPresLimite = varPerPresLimite;
			
				item.MsgError = varMsgError;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdValPresColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CantPresLimColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PerPresLimiteColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MsgErrorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdValPres = @"id_val_pres";
			 public static string Codigo = @"codigo";
			 public static string CantPresLim = @"cant_pres_lim";
			 public static string PerPresLimite = @"per_pres_limite";
			 public static string MsgError = @"msg_error";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
