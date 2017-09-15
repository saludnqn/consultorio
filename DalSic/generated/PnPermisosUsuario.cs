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
	/// Strongly-typed collection for the PnPermisosUsuario class.
	/// </summary>
    [Serializable]
	public partial class PnPermisosUsuarioCollection : ActiveList<PnPermisosUsuario, PnPermisosUsuarioCollection>
	{	   
		public PnPermisosUsuarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPermisosUsuarioCollection</returns>
		public PnPermisosUsuarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPermisosUsuario o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_permisos_usuarios table.
	/// </summary>
	[Serializable]
	public partial class PnPermisosUsuario : ActiveRecord<PnPermisosUsuario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPermisosUsuario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPermisosUsuario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPermisosUsuario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPermisosUsuario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_permisos_usuarios", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPu = new TableSchema.TableColumn(schema);
				colvarIdPu.ColumnName = "id_pu";
				colvarIdPu.DataType = DbType.Int32;
				colvarIdPu.MaxLength = 0;
				colvarIdPu.AutoIncrement = true;
				colvarIdPu.IsNullable = false;
				colvarIdPu.IsPrimaryKey = true;
				colvarIdPu.IsForeignKey = false;
				colvarIdPu.IsReadOnly = false;
				colvarIdPu.DefaultSetting = @"";
				colvarIdPu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPu);
				
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
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = true;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				
					colvarIdUsuario.ForeignKeyTableName = "PN_usuarios";
				schema.Columns.Add(colvarIdUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_permisos_usuarios",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPu")]
		[Bindable(true)]
		public int IdPu 
		{
			get { return GetColumnValue<int>(Columns.IdPu); }
			set { SetColumnValue(Columns.IdPu, value); }
		}
		  
		[XmlAttribute("IdPermiso")]
		[Bindable(true)]
		public int IdPermiso 
		{
			get { return GetColumnValue<int>(Columns.IdPermiso); }
			set { SetColumnValue(Columns.IdPermiso, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnPermiso ActiveRecord object related to this PnPermisosUsuario
		/// 
		/// </summary>
		public DalSic.PnPermiso PnPermiso
		{
			get { return DalSic.PnPermiso.FetchByID(this.IdPermiso); }
			set { SetColumnValue("id_permiso", value.IdPermiso); }
		}
		
		
		/// <summary>
		/// Returns a PnUsuario ActiveRecord object related to this PnPermisosUsuario
		/// 
		/// </summary>
		public DalSic.PnUsuario PnUsuario
		{
			get { return DalSic.PnUsuario.FetchByID(this.IdUsuario); }
			set { SetColumnValue("id_usuario", value.IdUsuario); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPermiso,int varIdUsuario)
		{
			PnPermisosUsuario item = new PnPermisosUsuario();
			
			item.IdPermiso = varIdPermiso;
			
			item.IdUsuario = varIdUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPu,int varIdPermiso,int varIdUsuario)
		{
			PnPermisosUsuario item = new PnPermisosUsuario();
			
				item.IdPu = varIdPu;
			
				item.IdPermiso = varIdPermiso;
			
				item.IdUsuario = varIdUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPuColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPermisoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPu = @"id_pu";
			 public static string IdPermiso = @"id_permiso";
			 public static string IdUsuario = @"id_usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
