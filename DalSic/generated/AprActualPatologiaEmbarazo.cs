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
	/// Strongly-typed collection for the AprActualPatologiaEmbarazo class.
	/// </summary>
    [Serializable]
	public partial class AprActualPatologiaEmbarazoCollection : ActiveList<AprActualPatologiaEmbarazo, AprActualPatologiaEmbarazoCollection>
	{	   
		public AprActualPatologiaEmbarazoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprActualPatologiaEmbarazoCollection</returns>
		public AprActualPatologiaEmbarazoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprActualPatologiaEmbarazo o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ActualPatologiaEmbarazo table.
	/// </summary>
	[Serializable]
	public partial class AprActualPatologiaEmbarazo : ActiveRecord<AprActualPatologiaEmbarazo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprActualPatologiaEmbarazo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprActualPatologiaEmbarazo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprActualPatologiaEmbarazo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprActualPatologiaEmbarazo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ActualPatologiaEmbarazo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdActualPatologiaEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdActualPatologiaEmbarazo.ColumnName = "idActualPatologiaEmbarazo";
				colvarIdActualPatologiaEmbarazo.DataType = DbType.Int32;
				colvarIdActualPatologiaEmbarazo.MaxLength = 0;
				colvarIdActualPatologiaEmbarazo.AutoIncrement = true;
				colvarIdActualPatologiaEmbarazo.IsNullable = false;
				colvarIdActualPatologiaEmbarazo.IsPrimaryKey = true;
				colvarIdActualPatologiaEmbarazo.IsForeignKey = false;
				colvarIdActualPatologiaEmbarazo.IsReadOnly = false;
				colvarIdActualPatologiaEmbarazo.DefaultSetting = @"";
				colvarIdActualPatologiaEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdActualPatologiaEmbarazo);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdEmbarazo.ColumnName = "idEmbarazo";
				colvarIdEmbarazo.DataType = DbType.Int32;
				colvarIdEmbarazo.MaxLength = 0;
				colvarIdEmbarazo.AutoIncrement = false;
				colvarIdEmbarazo.IsNullable = false;
				colvarIdEmbarazo.IsPrimaryKey = false;
				colvarIdEmbarazo.IsForeignKey = true;
				colvarIdEmbarazo.IsReadOnly = false;
				colvarIdEmbarazo.DefaultSetting = @"";
				
					colvarIdEmbarazo.ForeignKeyTableName = "APR_Embarazo";
				schema.Columns.Add(colvarIdEmbarazo);
				
				TableSchema.TableColumn colvarIdPatologiaEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdPatologiaEmbarazo.ColumnName = "idPatologiaEmbarazo";
				colvarIdPatologiaEmbarazo.DataType = DbType.Int32;
				colvarIdPatologiaEmbarazo.MaxLength = 0;
				colvarIdPatologiaEmbarazo.AutoIncrement = false;
				colvarIdPatologiaEmbarazo.IsNullable = false;
				colvarIdPatologiaEmbarazo.IsPrimaryKey = false;
				colvarIdPatologiaEmbarazo.IsForeignKey = true;
				colvarIdPatologiaEmbarazo.IsReadOnly = false;
				colvarIdPatologiaEmbarazo.DefaultSetting = @"";
				
					colvarIdPatologiaEmbarazo.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarIdPatologiaEmbarazo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ActualPatologiaEmbarazo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdActualPatologiaEmbarazo")]
		[Bindable(true)]
		public int IdActualPatologiaEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdActualPatologiaEmbarazo); }
			set { SetColumnValue(Columns.IdActualPatologiaEmbarazo, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdEmbarazo")]
		[Bindable(true)]
		public int IdEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdEmbarazo); }
			set { SetColumnValue(Columns.IdEmbarazo, value); }
		}
		  
		[XmlAttribute("IdPatologiaEmbarazo")]
		[Bindable(true)]
		public int IdPatologiaEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdPatologiaEmbarazo); }
			set { SetColumnValue(Columns.IdPatologiaEmbarazo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this AprActualPatologiaEmbarazo
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.IdPatologiaEmbarazo); }
			set { SetColumnValue("idPatologiaEmbarazo", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a AprEmbarazo ActiveRecord object related to this AprActualPatologiaEmbarazo
		/// 
		/// </summary>
		public DalSic.AprEmbarazo AprEmbarazo
		{
			get { return DalSic.AprEmbarazo.FetchByID(this.IdEmbarazo); }
			set { SetColumnValue("idEmbarazo", value.IdEmbarazo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdEmbarazo,int varIdPatologiaEmbarazo)
		{
			AprActualPatologiaEmbarazo item = new AprActualPatologiaEmbarazo();
			
			item.IdEfector = varIdEfector;
			
			item.IdEmbarazo = varIdEmbarazo;
			
			item.IdPatologiaEmbarazo = varIdPatologiaEmbarazo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdActualPatologiaEmbarazo,int varIdEfector,int varIdEmbarazo,int varIdPatologiaEmbarazo)
		{
			AprActualPatologiaEmbarazo item = new AprActualPatologiaEmbarazo();
			
				item.IdActualPatologiaEmbarazo = varIdActualPatologiaEmbarazo;
			
				item.IdEfector = varIdEfector;
			
				item.IdEmbarazo = varIdEmbarazo;
			
				item.IdPatologiaEmbarazo = varIdPatologiaEmbarazo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdActualPatologiaEmbarazoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEmbarazoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPatologiaEmbarazoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdActualPatologiaEmbarazo = @"idActualPatologiaEmbarazo";
			 public static string IdEfector = @"idEfector";
			 public static string IdEmbarazo = @"idEmbarazo";
			 public static string IdPatologiaEmbarazo = @"idPatologiaEmbarazo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
