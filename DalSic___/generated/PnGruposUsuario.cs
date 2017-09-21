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
	/// Strongly-typed collection for the PnGruposUsuario class.
	/// </summary>
    [Serializable]
	public partial class PnGruposUsuarioCollection : ActiveList<PnGruposUsuario, PnGruposUsuarioCollection>
	{	   
		public PnGruposUsuarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnGruposUsuarioCollection</returns>
		public PnGruposUsuarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnGruposUsuario o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_grupos_usuarios table.
	/// </summary>
	[Serializable]
	public partial class PnGruposUsuario : ActiveRecord<PnGruposUsuario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnGruposUsuario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnGruposUsuario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnGruposUsuario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnGruposUsuario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_grupos_usuarios", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdGu = new TableSchema.TableColumn(schema);
				colvarIdGu.ColumnName = "id_gu";
				colvarIdGu.DataType = DbType.Int32;
				colvarIdGu.MaxLength = 0;
				colvarIdGu.AutoIncrement = true;
				colvarIdGu.IsNullable = false;
				colvarIdGu.IsPrimaryKey = true;
				colvarIdGu.IsForeignKey = false;
				colvarIdGu.IsReadOnly = false;
				colvarIdGu.DefaultSetting = @"";
				colvarIdGu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdGu);
				
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
				DataService.Providers["sicProvider"].AddSchema("PN_grupos_usuarios",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdGu")]
		[Bindable(true)]
		public int IdGu 
		{
			get { return GetColumnValue<int>(Columns.IdGu); }
			set { SetColumnValue(Columns.IdGu, value); }
		}
		  
		[XmlAttribute("IdGrupo")]
		[Bindable(true)]
		public int IdGrupo 
		{
			get { return GetColumnValue<int>(Columns.IdGrupo); }
			set { SetColumnValue(Columns.IdGrupo, value); }
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
		/// Returns a PnUsuario ActiveRecord object related to this PnGruposUsuario
		/// 
		/// </summary>
		public DalSic.PnUsuario PnUsuario
		{
			get { return DalSic.PnUsuario.FetchByID(this.IdUsuario); }
			set { SetColumnValue("id_usuario", value.IdUsuario); }
		}
		
		
		/// <summary>
		/// Returns a PnGrupo ActiveRecord object related to this PnGruposUsuario
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
		public static void Insert(int varIdGrupo,int varIdUsuario)
		{
			PnGruposUsuario item = new PnGruposUsuario();
			
			item.IdGrupo = varIdGrupo;
			
			item.IdUsuario = varIdUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdGu,int varIdGrupo,int varIdUsuario)
		{
			PnGruposUsuario item = new PnGruposUsuario();
			
				item.IdGu = varIdGu;
			
				item.IdGrupo = varIdGrupo;
			
				item.IdUsuario = varIdUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdGuColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdGrupoColumn
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
			 public static string IdGu = @"id_gu";
			 public static string IdGrupo = @"id_grupo";
			 public static string IdUsuario = @"id_usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
