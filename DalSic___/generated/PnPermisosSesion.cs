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
	/// Strongly-typed collection for the PnPermisosSesion class.
	/// </summary>
    [Serializable]
	public partial class PnPermisosSesionCollection : ActiveList<PnPermisosSesion, PnPermisosSesionCollection>
	{	   
		public PnPermisosSesionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPermisosSesionCollection</returns>
		public PnPermisosSesionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPermisosSesion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_permisos_sesion table.
	/// </summary>
	[Serializable]
	public partial class PnPermisosSesion : ActiveRecord<PnPermisosSesion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPermisosSesion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPermisosSesion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPermisosSesion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPermisosSesion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_permisos_sesion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPermisosSesion = new TableSchema.TableColumn(schema);
				colvarIdPermisosSesion.ColumnName = "id_permisos_sesion";
				colvarIdPermisosSesion.DataType = DbType.Int32;
				colvarIdPermisosSesion.MaxLength = 0;
				colvarIdPermisosSesion.AutoIncrement = true;
				colvarIdPermisosSesion.IsNullable = false;
				colvarIdPermisosSesion.IsPrimaryKey = true;
				colvarIdPermisosSesion.IsForeignKey = false;
				colvarIdPermisosSesion.IsReadOnly = false;
				colvarIdPermisosSesion.DefaultSetting = @"";
				colvarIdPermisosSesion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPermisosSesion);
				
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
				
				TableSchema.TableColumn colvarData = new TableSchema.TableColumn(schema);
				colvarData.ColumnName = "data";
				colvarData.DataType = DbType.AnsiString;
				colvarData.MaxLength = -1;
				colvarData.AutoIncrement = false;
				colvarData.IsNullable = true;
				colvarData.IsPrimaryKey = false;
				colvarData.IsForeignKey = false;
				colvarData.IsReadOnly = false;
				colvarData.DefaultSetting = @"";
				colvarData.ForeignKeyTableName = "";
				schema.Columns.Add(colvarData);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_permisos_sesion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPermisosSesion")]
		[Bindable(true)]
		public int IdPermisosSesion 
		{
			get { return GetColumnValue<int>(Columns.IdPermisosSesion); }
			set { SetColumnValue(Columns.IdPermisosSesion, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("Data")]
		[Bindable(true)]
		public string Data 
		{
			get { return GetColumnValue<string>(Columns.Data); }
			set { SetColumnValue(Columns.Data, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnUsuario ActiveRecord object related to this PnPermisosSesion
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
		public static void Insert(int varIdUsuario,string varData)
		{
			PnPermisosSesion item = new PnPermisosSesion();
			
			item.IdUsuario = varIdUsuario;
			
			item.Data = varData;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPermisosSesion,int varIdUsuario,string varData)
		{
			PnPermisosSesion item = new PnPermisosSesion();
			
				item.IdPermisosSesion = varIdPermisosSesion;
			
				item.IdUsuario = varIdUsuario;
			
				item.Data = varData;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPermisosSesionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DataColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPermisosSesion = @"id_permisos_sesion";
			 public static string IdUsuario = @"id_usuario";
			 public static string Data = @"data";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
