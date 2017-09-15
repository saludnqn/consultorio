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
	/// Strongly-typed collection for the IcoTiposUsuario class.
	/// </summary>
    [Serializable]
	public partial class IcoTiposUsuarioCollection : ActiveList<IcoTiposUsuario, IcoTiposUsuarioCollection>
	{	   
		public IcoTiposUsuarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>IcoTiposUsuarioCollection</returns>
		public IcoTiposUsuarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                IcoTiposUsuario o = this[i];
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
	/// This is an ActiveRecord class which wraps the ICO_TiposUsuario table.
	/// </summary>
	[Serializable]
	public partial class IcoTiposUsuario : ActiveRecord<IcoTiposUsuario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public IcoTiposUsuario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public IcoTiposUsuario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public IcoTiposUsuario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public IcoTiposUsuario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ICO_TiposUsuario", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoUsuario = new TableSchema.TableColumn(schema);
				colvarIdTipoUsuario.ColumnName = "idTipoUsuario";
				colvarIdTipoUsuario.DataType = DbType.Int32;
				colvarIdTipoUsuario.MaxLength = 0;
				colvarIdTipoUsuario.AutoIncrement = true;
				colvarIdTipoUsuario.IsNullable = false;
				colvarIdTipoUsuario.IsPrimaryKey = true;
				colvarIdTipoUsuario.IsForeignKey = false;
				colvarIdTipoUsuario.IsReadOnly = false;
				colvarIdTipoUsuario.DefaultSetting = @"";
				colvarIdTipoUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoUsuario);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarTipoUsuario = new TableSchema.TableColumn(schema);
				colvarTipoUsuario.ColumnName = "tipoUsuario";
				colvarTipoUsuario.DataType = DbType.AnsiString;
				colvarTipoUsuario.MaxLength = 50;
				colvarTipoUsuario.AutoIncrement = false;
				colvarTipoUsuario.IsNullable = false;
				colvarTipoUsuario.IsPrimaryKey = false;
				colvarTipoUsuario.IsForeignKey = false;
				colvarTipoUsuario.IsReadOnly = false;
				colvarTipoUsuario.DefaultSetting = @"";
				colvarTipoUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("ICO_TiposUsuario",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoUsuario")]
		[Bindable(true)]
		public int IdTipoUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdTipoUsuario); }
			set { SetColumnValue(Columns.IdTipoUsuario, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("TipoUsuario")]
		[Bindable(true)]
		public string TipoUsuario 
		{
			get { return GetColumnValue<string>(Columns.TipoUsuario); }
			set { SetColumnValue(Columns.TipoUsuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdUsuario,string varTipoUsuario)
		{
			IcoTiposUsuario item = new IcoTiposUsuario();
			
			item.IdUsuario = varIdUsuario;
			
			item.TipoUsuario = varTipoUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoUsuario,int varIdUsuario,string varTipoUsuario)
		{
			IcoTiposUsuario item = new IcoTiposUsuario();
			
				item.IdTipoUsuario = varIdTipoUsuario;
			
				item.IdUsuario = varIdUsuario;
			
				item.TipoUsuario = varTipoUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoUsuarioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoUsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoUsuario = @"idTipoUsuario";
			 public static string IdUsuario = @"idUsuario";
			 public static string TipoUsuario = @"tipoUsuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
