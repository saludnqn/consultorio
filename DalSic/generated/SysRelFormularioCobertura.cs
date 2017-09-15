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
	/// Strongly-typed collection for the SysRelFormularioCobertura class.
	/// </summary>
    [Serializable]
	public partial class SysRelFormularioCoberturaCollection : ActiveList<SysRelFormularioCobertura, SysRelFormularioCoberturaCollection>
	{	   
		public SysRelFormularioCoberturaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelFormularioCoberturaCollection</returns>
		public SysRelFormularioCoberturaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelFormularioCobertura o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelFormularioCobertura table.
	/// </summary>
	[Serializable]
	public partial class SysRelFormularioCobertura : ActiveRecord<SysRelFormularioCobertura>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelFormularioCobertura()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelFormularioCobertura(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelFormularioCobertura(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelFormularioCobertura(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelFormularioCobertura", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelFormularioCobertura = new TableSchema.TableColumn(schema);
				colvarIdRelFormularioCobertura.ColumnName = "idRelFormularioCobertura";
				colvarIdRelFormularioCobertura.DataType = DbType.Int32;
				colvarIdRelFormularioCobertura.MaxLength = 0;
				colvarIdRelFormularioCobertura.AutoIncrement = true;
				colvarIdRelFormularioCobertura.IsNullable = false;
				colvarIdRelFormularioCobertura.IsPrimaryKey = true;
				colvarIdRelFormularioCobertura.IsForeignKey = false;
				colvarIdRelFormularioCobertura.IsReadOnly = false;
				colvarIdRelFormularioCobertura.DefaultSetting = @"";
				colvarIdRelFormularioCobertura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelFormularioCobertura);
				
				TableSchema.TableColumn colvarIdFormulario = new TableSchema.TableColumn(schema);
				colvarIdFormulario.ColumnName = "idFormulario";
				colvarIdFormulario.DataType = DbType.Int32;
				colvarIdFormulario.MaxLength = 0;
				colvarIdFormulario.AutoIncrement = false;
				colvarIdFormulario.IsNullable = false;
				colvarIdFormulario.IsPrimaryKey = false;
				colvarIdFormulario.IsForeignKey = true;
				colvarIdFormulario.IsReadOnly = false;
				
						colvarIdFormulario.DefaultSetting = @"((0))";
				
					colvarIdFormulario.ForeignKeyTableName = "Rem_Formulario";
				schema.Columns.Add(colvarIdFormulario);
				
				TableSchema.TableColumn colvarIdTipoCobertura = new TableSchema.TableColumn(schema);
				colvarIdTipoCobertura.ColumnName = "idTipoCobertura";
				colvarIdTipoCobertura.DataType = DbType.Int32;
				colvarIdTipoCobertura.MaxLength = 0;
				colvarIdTipoCobertura.AutoIncrement = false;
				colvarIdTipoCobertura.IsNullable = false;
				colvarIdTipoCobertura.IsPrimaryKey = false;
				colvarIdTipoCobertura.IsForeignKey = true;
				colvarIdTipoCobertura.IsReadOnly = false;
				
						colvarIdTipoCobertura.DefaultSetting = @"((0))";
				
					colvarIdTipoCobertura.ForeignKeyTableName = "Rem_TipoCobertura";
				schema.Columns.Add(colvarIdTipoCobertura);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelFormularioCobertura",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelFormularioCobertura")]
		[Bindable(true)]
		public int IdRelFormularioCobertura 
		{
			get { return GetColumnValue<int>(Columns.IdRelFormularioCobertura); }
			set { SetColumnValue(Columns.IdRelFormularioCobertura, value); }
		}
		  
		[XmlAttribute("IdFormulario")]
		[Bindable(true)]
		public int IdFormulario 
		{
			get { return GetColumnValue<int>(Columns.IdFormulario); }
			set { SetColumnValue(Columns.IdFormulario, value); }
		}
		  
		[XmlAttribute("IdTipoCobertura")]
		[Bindable(true)]
		public int IdTipoCobertura 
		{
			get { return GetColumnValue<int>(Columns.IdTipoCobertura); }
			set { SetColumnValue(Columns.IdTipoCobertura, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a RemTipoCobertura ActiveRecord object related to this SysRelFormularioCobertura
		/// 
		/// </summary>
		public DalSic.RemTipoCobertura RemTipoCobertura
		{
			get { return DalSic.RemTipoCobertura.FetchByID(this.IdTipoCobertura); }
			set { SetColumnValue("idTipoCobertura", value.IdTipoCobertura); }
		}
		
		
		/// <summary>
		/// Returns a RemFormulario ActiveRecord object related to this SysRelFormularioCobertura
		/// 
		/// </summary>
		public DalSic.RemFormulario RemFormulario
		{
			get { return DalSic.RemFormulario.FetchByID(this.IdFormulario); }
			set { SetColumnValue("idFormulario", value.IdFormulario); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdFormulario,int varIdTipoCobertura)
		{
			SysRelFormularioCobertura item = new SysRelFormularioCobertura();
			
			item.IdFormulario = varIdFormulario;
			
			item.IdTipoCobertura = varIdTipoCobertura;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelFormularioCobertura,int varIdFormulario,int varIdTipoCobertura)
		{
			SysRelFormularioCobertura item = new SysRelFormularioCobertura();
			
				item.IdRelFormularioCobertura = varIdRelFormularioCobertura;
			
				item.IdFormulario = varIdFormulario;
			
				item.IdTipoCobertura = varIdTipoCobertura;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelFormularioCoberturaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFormularioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoCoberturaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelFormularioCobertura = @"idRelFormularioCobertura";
			 public static string IdFormulario = @"idFormulario";
			 public static string IdTipoCobertura = @"idTipoCobertura";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
