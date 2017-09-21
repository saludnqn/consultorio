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
	/// Strongly-typed collection for the PnArbol class.
	/// </summary>
    [Serializable]
	public partial class PnArbolCollection : ActiveList<PnArbol, PnArbolCollection>
	{	   
		public PnArbolCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnArbolCollection</returns>
		public PnArbolCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnArbol o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_arbol table.
	/// </summary>
	[Serializable]
	public partial class PnArbol : ActiveRecord<PnArbol>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnArbol()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnArbol(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnArbol(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnArbol(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_arbol", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNodo = new TableSchema.TableColumn(schema);
				colvarIdNodo.ColumnName = "id_nodo";
				colvarIdNodo.DataType = DbType.Int32;
				colvarIdNodo.MaxLength = 0;
				colvarIdNodo.AutoIncrement = true;
				colvarIdNodo.IsNullable = false;
				colvarIdNodo.IsPrimaryKey = true;
				colvarIdNodo.IsForeignKey = false;
				colvarIdNodo.IsReadOnly = false;
				colvarIdNodo.DefaultSetting = @"";
				colvarIdNodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNodo);
				
				TableSchema.TableColumn colvarIdPermisoPadre = new TableSchema.TableColumn(schema);
				colvarIdPermisoPadre.ColumnName = "id_permiso_padre";
				colvarIdPermisoPadre.DataType = DbType.Int32;
				colvarIdPermisoPadre.MaxLength = 0;
				colvarIdPermisoPadre.AutoIncrement = false;
				colvarIdPermisoPadre.IsNullable = true;
				colvarIdPermisoPadre.IsPrimaryKey = false;
				colvarIdPermisoPadre.IsForeignKey = false;
				colvarIdPermisoPadre.IsReadOnly = false;
				colvarIdPermisoPadre.DefaultSetting = @"";
				colvarIdPermisoPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPermisoPadre);
				
				TableSchema.TableColumn colvarIdPermisoHijo = new TableSchema.TableColumn(schema);
				colvarIdPermisoHijo.ColumnName = "id_permiso_hijo";
				colvarIdPermisoHijo.DataType = DbType.Int32;
				colvarIdPermisoHijo.MaxLength = 0;
				colvarIdPermisoHijo.AutoIncrement = false;
				colvarIdPermisoHijo.IsNullable = true;
				colvarIdPermisoHijo.IsPrimaryKey = false;
				colvarIdPermisoHijo.IsForeignKey = false;
				colvarIdPermisoHijo.IsReadOnly = false;
				colvarIdPermisoHijo.DefaultSetting = @"";
				colvarIdPermisoHijo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPermisoHijo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_arbol",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNodo")]
		[Bindable(true)]
		public int IdNodo 
		{
			get { return GetColumnValue<int>(Columns.IdNodo); }
			set { SetColumnValue(Columns.IdNodo, value); }
		}
		  
		[XmlAttribute("IdPermisoPadre")]
		[Bindable(true)]
		public int? IdPermisoPadre 
		{
			get { return GetColumnValue<int?>(Columns.IdPermisoPadre); }
			set { SetColumnValue(Columns.IdPermisoPadre, value); }
		}
		  
		[XmlAttribute("IdPermisoHijo")]
		[Bindable(true)]
		public int? IdPermisoHijo 
		{
			get { return GetColumnValue<int?>(Columns.IdPermisoHijo); }
			set { SetColumnValue(Columns.IdPermisoHijo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdPermisoPadre,int? varIdPermisoHijo)
		{
			PnArbol item = new PnArbol();
			
			item.IdPermisoPadre = varIdPermisoPadre;
			
			item.IdPermisoHijo = varIdPermisoHijo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNodo,int? varIdPermisoPadre,int? varIdPermisoHijo)
		{
			PnArbol item = new PnArbol();
			
				item.IdNodo = varIdNodo;
			
				item.IdPermisoPadre = varIdPermisoPadre;
			
				item.IdPermisoHijo = varIdPermisoHijo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNodoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPermisoPadreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPermisoHijoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNodo = @"id_nodo";
			 public static string IdPermisoPadre = @"id_permiso_padre";
			 public static string IdPermisoHijo = @"id_permiso_hijo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
