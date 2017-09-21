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
	/// Strongly-typed collection for the SysRelEstadoMotivoNI class.
	/// </summary>
    [Serializable]
	public partial class SysRelEstadoMotivoNICollection : ActiveList<SysRelEstadoMotivoNI, SysRelEstadoMotivoNICollection>
	{	   
		public SysRelEstadoMotivoNICollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelEstadoMotivoNICollection</returns>
		public SysRelEstadoMotivoNICollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelEstadoMotivoNI o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelEstadoMotivoNI table.
	/// </summary>
	[Serializable]
	public partial class SysRelEstadoMotivoNI : ActiveRecord<SysRelEstadoMotivoNI>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelEstadoMotivoNI()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelEstadoMotivoNI(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelEstadoMotivoNI(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelEstadoMotivoNI(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelEstadoMotivoNI", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelEstadoMotivoNI = new TableSchema.TableColumn(schema);
				colvarIdRelEstadoMotivoNI.ColumnName = "idRelEstadoMotivoNI";
				colvarIdRelEstadoMotivoNI.DataType = DbType.Int32;
				colvarIdRelEstadoMotivoNI.MaxLength = 0;
				colvarIdRelEstadoMotivoNI.AutoIncrement = true;
				colvarIdRelEstadoMotivoNI.IsNullable = false;
				colvarIdRelEstadoMotivoNI.IsPrimaryKey = true;
				colvarIdRelEstadoMotivoNI.IsForeignKey = false;
				colvarIdRelEstadoMotivoNI.IsReadOnly = false;
				colvarIdRelEstadoMotivoNI.DefaultSetting = @"";
				colvarIdRelEstadoMotivoNI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelEstadoMotivoNI);
				
				TableSchema.TableColumn colvarIdEstado = new TableSchema.TableColumn(schema);
				colvarIdEstado.ColumnName = "idEstado";
				colvarIdEstado.DataType = DbType.Int32;
				colvarIdEstado.MaxLength = 0;
				colvarIdEstado.AutoIncrement = false;
				colvarIdEstado.IsNullable = false;
				colvarIdEstado.IsPrimaryKey = false;
				colvarIdEstado.IsForeignKey = true;
				colvarIdEstado.IsReadOnly = false;
				colvarIdEstado.DefaultSetting = @"";
				
					colvarIdEstado.ForeignKeyTableName = "Sys_Estado";
				schema.Columns.Add(colvarIdEstado);
				
				TableSchema.TableColumn colvarIdMotivoNI = new TableSchema.TableColumn(schema);
				colvarIdMotivoNI.ColumnName = "idMotivoNI";
				colvarIdMotivoNI.DataType = DbType.Int32;
				colvarIdMotivoNI.MaxLength = 0;
				colvarIdMotivoNI.AutoIncrement = false;
				colvarIdMotivoNI.IsNullable = false;
				colvarIdMotivoNI.IsPrimaryKey = false;
				colvarIdMotivoNI.IsForeignKey = true;
				colvarIdMotivoNI.IsReadOnly = false;
				
						colvarIdMotivoNI.DefaultSetting = @"((0))";
				
					colvarIdMotivoNI.ForeignKeyTableName = "Sys_MotivoNI";
				schema.Columns.Add(colvarIdMotivoNI);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelEstadoMotivoNI",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelEstadoMotivoNI")]
		[Bindable(true)]
		public int IdRelEstadoMotivoNI 
		{
			get { return GetColumnValue<int>(Columns.IdRelEstadoMotivoNI); }
			set { SetColumnValue(Columns.IdRelEstadoMotivoNI, value); }
		}
		  
		[XmlAttribute("IdEstado")]
		[Bindable(true)]
		public int IdEstado 
		{
			get { return GetColumnValue<int>(Columns.IdEstado); }
			set { SetColumnValue(Columns.IdEstado, value); }
		}
		  
		[XmlAttribute("IdMotivoNI")]
		[Bindable(true)]
		public int IdMotivoNI 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoNI); }
			set { SetColumnValue(Columns.IdMotivoNI, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEstado ActiveRecord object related to this SysRelEstadoMotivoNI
		/// 
		/// </summary>
		public DalSic.SysEstado SysEstado
		{
			get { return DalSic.SysEstado.FetchByID(this.IdEstado); }
			set { SetColumnValue("idEstado", value.IdEstado); }
		}
		
		
		/// <summary>
		/// Returns a SysMotivoNI ActiveRecord object related to this SysRelEstadoMotivoNI
		/// 
		/// </summary>
		public DalSic.SysMotivoNI SysMotivoNI
		{
			get { return DalSic.SysMotivoNI.FetchByID(this.IdMotivoNI); }
			set { SetColumnValue("idMotivoNI", value.IdMotivoNI); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstado,int varIdMotivoNI)
		{
			SysRelEstadoMotivoNI item = new SysRelEstadoMotivoNI();
			
			item.IdEstado = varIdEstado;
			
			item.IdMotivoNI = varIdMotivoNI;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelEstadoMotivoNI,int varIdEstado,int varIdMotivoNI)
		{
			SysRelEstadoMotivoNI item = new SysRelEstadoMotivoNI();
			
				item.IdRelEstadoMotivoNI = varIdRelEstadoMotivoNI;
			
				item.IdEstado = varIdEstado;
			
				item.IdMotivoNI = varIdMotivoNI;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelEstadoMotivoNIColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoNIColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelEstadoMotivoNI = @"idRelEstadoMotivoNI";
			 public static string IdEstado = @"idEstado";
			 public static string IdMotivoNI = @"idMotivoNI";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
