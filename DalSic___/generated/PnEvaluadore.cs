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
	/// Strongly-typed collection for the PnEvaluadore class.
	/// </summary>
    [Serializable]
	public partial class PnEvaluadoreCollection : ActiveList<PnEvaluadore, PnEvaluadoreCollection>
	{	   
		public PnEvaluadoreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEvaluadoreCollection</returns>
		public PnEvaluadoreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEvaluadore o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_evaluadores table.
	/// </summary>
	[Serializable]
	public partial class PnEvaluadore : ActiveRecord<PnEvaluadore>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEvaluadore()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEvaluadore(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEvaluadore(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEvaluadore(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_evaluadores", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEvaluador = new TableSchema.TableColumn(schema);
				colvarIdEvaluador.ColumnName = "id_evaluador";
				colvarIdEvaluador.DataType = DbType.Int32;
				colvarIdEvaluador.MaxLength = 0;
				colvarIdEvaluador.AutoIncrement = true;
				colvarIdEvaluador.IsNullable = false;
				colvarIdEvaluador.IsPrimaryKey = true;
				colvarIdEvaluador.IsForeignKey = false;
				colvarIdEvaluador.IsReadOnly = false;
				colvarIdEvaluador.DefaultSetting = @"";
				colvarIdEvaluador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEvaluador);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = true;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_evaluadores",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEvaluador")]
		[Bindable(true)]
		public int IdEvaluador 
		{
			get { return GetColumnValue<int>(Columns.IdEvaluador); }
			set { SetColumnValue(Columns.IdEvaluador, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int? IdUsuario 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdUsuario)
		{
			PnEvaluadore item = new PnEvaluadore();
			
			item.IdUsuario = varIdUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEvaluador,int? varIdUsuario)
		{
			PnEvaluadore item = new PnEvaluadore();
			
				item.IdEvaluador = varIdEvaluador;
			
				item.IdUsuario = varIdUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEvaluadorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEvaluador = @"id_evaluador";
			 public static string IdUsuario = @"id_usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
