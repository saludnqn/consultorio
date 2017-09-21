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
	/// Strongly-typed collection for the PnPermisosGrupo class.
	/// </summary>
    [Serializable]
	public partial class PnPermisosGrupoCollection : ActiveList<PnPermisosGrupo, PnPermisosGrupoCollection>
	{	   
		public PnPermisosGrupoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPermisosGrupoCollection</returns>
		public PnPermisosGrupoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPermisosGrupo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_permisos_grupos table.
	/// </summary>
	[Serializable]
	public partial class PnPermisosGrupo : ActiveRecord<PnPermisosGrupo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPermisosGrupo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPermisosGrupo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPermisosGrupo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPermisosGrupo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_permisos_grupos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPg = new TableSchema.TableColumn(schema);
				colvarIdPg.ColumnName = "id_pg";
				colvarIdPg.DataType = DbType.Int32;
				colvarIdPg.MaxLength = 0;
				colvarIdPg.AutoIncrement = true;
				colvarIdPg.IsNullable = false;
				colvarIdPg.IsPrimaryKey = true;
				colvarIdPg.IsForeignKey = false;
				colvarIdPg.IsReadOnly = false;
				colvarIdPg.DefaultSetting = @"";
				colvarIdPg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPg);
				
				TableSchema.TableColumn colvarIdPermiso = new TableSchema.TableColumn(schema);
				colvarIdPermiso.ColumnName = "id_permiso";
				colvarIdPermiso.DataType = DbType.Int32;
				colvarIdPermiso.MaxLength = 0;
				colvarIdPermiso.AutoIncrement = false;
				colvarIdPermiso.IsNullable = false;
				colvarIdPermiso.IsPrimaryKey = false;
				colvarIdPermiso.IsForeignKey = true;
				colvarIdPermiso.IsReadOnly = false;
				colvarIdPermiso.DefaultSetting = @"";
				
					colvarIdPermiso.ForeignKeyTableName = "PN_permisos";
				schema.Columns.Add(colvarIdPermiso);
				
				TableSchema.TableColumn colvarIdGrupo = new TableSchema.TableColumn(schema);
				colvarIdGrupo.ColumnName = "id_grupo";
				colvarIdGrupo.DataType = DbType.Int32;
				colvarIdGrupo.MaxLength = 0;
				colvarIdGrupo.AutoIncrement = false;
				colvarIdGrupo.IsNullable = false;
				colvarIdGrupo.IsPrimaryKey = false;
				colvarIdGrupo.IsForeignKey = true;
				colvarIdGrupo.IsReadOnly = false;
				colvarIdGrupo.DefaultSetting = @"";
				
					colvarIdGrupo.ForeignKeyTableName = "PN_grupos";
				schema.Columns.Add(colvarIdGrupo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_permisos_grupos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPg")]
		[Bindable(true)]
		public int IdPg 
		{
			get { return GetColumnValue<int>(Columns.IdPg); }
			set { SetColumnValue(Columns.IdPg, value); }
		}
		  
		[XmlAttribute("IdPermiso")]
		[Bindable(true)]
		public int IdPermiso 
		{
			get { return GetColumnValue<int>(Columns.IdPermiso); }
			set { SetColumnValue(Columns.IdPermiso, value); }
		}
		  
		[XmlAttribute("IdGrupo")]
		[Bindable(true)]
		public int IdGrupo 
		{
			get { return GetColumnValue<int>(Columns.IdGrupo); }
			set { SetColumnValue(Columns.IdGrupo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnPermiso ActiveRecord object related to this PnPermisosGrupo
		/// 
		/// </summary>
		public DalSic.PnPermiso PnPermiso
		{
			get { return DalSic.PnPermiso.FetchByID(this.IdPermiso); }
			set { SetColumnValue("id_permiso", value.IdPermiso); }
		}
		
		
		/// <summary>
		/// Returns a PnGrupo ActiveRecord object related to this PnPermisosGrupo
		/// 
		/// </summary>
		public DalSic.PnGrupo PnGrupo
		{
			get { return DalSic.PnGrupo.FetchByID(this.IdGrupo); }
			set { SetColumnValue("id_grupo", value.IdGrupo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPermiso,int varIdGrupo)
		{
			PnPermisosGrupo item = new PnPermisosGrupo();
			
			item.IdPermiso = varIdPermiso;
			
			item.IdGrupo = varIdGrupo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPg,int varIdPermiso,int varIdGrupo)
		{
			PnPermisosGrupo item = new PnPermisosGrupo();
			
				item.IdPg = varIdPg;
			
				item.IdPermiso = varIdPermiso;
			
				item.IdGrupo = varIdGrupo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPgColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPermisoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdGrupoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPg = @"id_pg";
			 public static string IdPermiso = @"id_permiso";
			 public static string IdGrupo = @"id_grupo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
