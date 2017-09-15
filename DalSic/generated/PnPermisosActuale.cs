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
	/// Strongly-typed collection for the PnPermisosActuale class.
	/// </summary>
    [Serializable]
	public partial class PnPermisosActualeCollection : ActiveList<PnPermisosActuale, PnPermisosActualeCollection>
	{	   
		public PnPermisosActualeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPermisosActualeCollection</returns>
		public PnPermisosActualeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPermisosActuale o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_permisos_actuales table.
	/// </summary>
	[Serializable]
	public partial class PnPermisosActuale : ActiveRecord<PnPermisosActuale>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPermisosActuale()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPermisosActuale(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPermisosActuale(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPermisosActuale(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_permisos_actuales", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPermisosActuales = new TableSchema.TableColumn(schema);
				colvarIdPermisosActuales.ColumnName = "id_permisos_actuales";
				colvarIdPermisosActuales.DataType = DbType.Int32;
				colvarIdPermisosActuales.MaxLength = 0;
				colvarIdPermisosActuales.AutoIncrement = true;
				colvarIdPermisosActuales.IsNullable = false;
				colvarIdPermisosActuales.IsPrimaryKey = true;
				colvarIdPermisosActuales.IsForeignKey = false;
				colvarIdPermisosActuales.IsReadOnly = false;
				colvarIdPermisosActuales.DefaultSetting = @"";
				colvarIdPermisosActuales.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPermisosActuales);
				
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
				DataService.Providers["sicProvider"].AddSchema("PN_permisos_actuales",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPermisosActuales")]
		[Bindable(true)]
		public int IdPermisosActuales 
		{
			get { return GetColumnValue<int>(Columns.IdPermisosActuales); }
			set { SetColumnValue(Columns.IdPermisosActuales, value); }
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
		/// Returns a PnUsuario ActiveRecord object related to this PnPermisosActuale
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
			PnPermisosActuale item = new PnPermisosActuale();
			
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
		public static void Update(int varIdPermisosActuales,int varIdUsuario,string varData)
		{
			PnPermisosActuale item = new PnPermisosActuale();
			
				item.IdPermisosActuales = varIdPermisosActuales;
			
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
        
        
        public static TableSchema.TableColumn IdPermisosActualesColumn
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
			 public static string IdPermisosActuales = @"id_permisos_actuales";
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
