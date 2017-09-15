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
	/// Strongly-typed collection for the AprAntecedentePatologiaEmbarazo class.
	/// </summary>
    [Serializable]
	public partial class AprAntecedentePatologiaEmbarazoCollection : ActiveList<AprAntecedentePatologiaEmbarazo, AprAntecedentePatologiaEmbarazoCollection>
	{	   
		public AprAntecedentePatologiaEmbarazoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAntecedentePatologiaEmbarazoCollection</returns>
		public AprAntecedentePatologiaEmbarazoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAntecedentePatologiaEmbarazo o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AntecedentePatologiaEmbarazo table.
	/// </summary>
	[Serializable]
	public partial class AprAntecedentePatologiaEmbarazo : ActiveRecord<AprAntecedentePatologiaEmbarazo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAntecedentePatologiaEmbarazo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAntecedentePatologiaEmbarazo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAntecedentePatologiaEmbarazo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAntecedentePatologiaEmbarazo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AntecedentePatologiaEmbarazo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAntecedentePatologiaEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdAntecedentePatologiaEmbarazo.ColumnName = "idAntecedentePatologiaEmbarazo";
				colvarIdAntecedentePatologiaEmbarazo.DataType = DbType.Int32;
				colvarIdAntecedentePatologiaEmbarazo.MaxLength = 0;
				colvarIdAntecedentePatologiaEmbarazo.AutoIncrement = true;
				colvarIdAntecedentePatologiaEmbarazo.IsNullable = false;
				colvarIdAntecedentePatologiaEmbarazo.IsPrimaryKey = true;
				colvarIdAntecedentePatologiaEmbarazo.IsForeignKey = false;
				colvarIdAntecedentePatologiaEmbarazo.IsReadOnly = false;
				colvarIdAntecedentePatologiaEmbarazo.DefaultSetting = @"";
				colvarIdAntecedentePatologiaEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAntecedentePatologiaEmbarazo);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_AntecedentePatologiaEmbarazo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAntecedentePatologiaEmbarazo")]
		[Bindable(true)]
		public int IdAntecedentePatologiaEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedentePatologiaEmbarazo); }
			set { SetColumnValue(Columns.IdAntecedentePatologiaEmbarazo, value); }
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
		/// Returns a SysCIE10 ActiveRecord object related to this AprAntecedentePatologiaEmbarazo
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.IdPatologiaEmbarazo); }
			set { SetColumnValue("idPatologiaEmbarazo", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a AprEmbarazo ActiveRecord object related to this AprAntecedentePatologiaEmbarazo
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
			AprAntecedentePatologiaEmbarazo item = new AprAntecedentePatologiaEmbarazo();
			
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
		public static void Update(int varIdAntecedentePatologiaEmbarazo,int varIdEfector,int varIdEmbarazo,int varIdPatologiaEmbarazo)
		{
			AprAntecedentePatologiaEmbarazo item = new AprAntecedentePatologiaEmbarazo();
			
				item.IdAntecedentePatologiaEmbarazo = varIdAntecedentePatologiaEmbarazo;
			
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
        
        
        public static TableSchema.TableColumn IdAntecedentePatologiaEmbarazoColumn
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
			 public static string IdAntecedentePatologiaEmbarazo = @"idAntecedentePatologiaEmbarazo";
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
