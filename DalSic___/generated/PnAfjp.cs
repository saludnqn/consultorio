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
	/// Strongly-typed collection for the PnAfjp class.
	/// </summary>
    [Serializable]
	public partial class PnAfjpCollection : ActiveList<PnAfjp, PnAfjpCollection>
	{	   
		public PnAfjpCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAfjpCollection</returns>
		public PnAfjpCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAfjp o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_afjp table.
	/// </summary>
	[Serializable]
	public partial class PnAfjp : ActiveRecord<PnAfjp>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAfjp()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAfjp(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAfjp(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAfjp(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_afjp", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAfjp = new TableSchema.TableColumn(schema);
				colvarIdAfjp.ColumnName = "id_afjp";
				colvarIdAfjp.DataType = DbType.Int32;
				colvarIdAfjp.MaxLength = 0;
				colvarIdAfjp.AutoIncrement = true;
				colvarIdAfjp.IsNullable = false;
				colvarIdAfjp.IsPrimaryKey = true;
				colvarIdAfjp.IsForeignKey = false;
				colvarIdAfjp.IsReadOnly = false;
				colvarIdAfjp.DefaultSetting = @"";
				colvarIdAfjp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAfjp);
				
				TableSchema.TableColumn colvarNombreAfjp = new TableSchema.TableColumn(schema);
				colvarNombreAfjp.ColumnName = "nombre_afjp";
				colvarNombreAfjp.DataType = DbType.AnsiString;
				colvarNombreAfjp.MaxLength = -1;
				colvarNombreAfjp.AutoIncrement = false;
				colvarNombreAfjp.IsNullable = true;
				colvarNombreAfjp.IsPrimaryKey = false;
				colvarNombreAfjp.IsForeignKey = false;
				colvarNombreAfjp.IsReadOnly = false;
				colvarNombreAfjp.DefaultSetting = @"";
				colvarNombreAfjp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreAfjp);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_afjp",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAfjp")]
		[Bindable(true)]
		public int IdAfjp 
		{
			get { return GetColumnValue<int>(Columns.IdAfjp); }
			set { SetColumnValue(Columns.IdAfjp, value); }
		}
		  
		[XmlAttribute("NombreAfjp")]
		[Bindable(true)]
		public string NombreAfjp 
		{
			get { return GetColumnValue<string>(Columns.NombreAfjp); }
			set { SetColumnValue(Columns.NombreAfjp, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombreAfjp)
		{
			PnAfjp item = new PnAfjp();
			
			item.NombreAfjp = varNombreAfjp;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAfjp,string varNombreAfjp)
		{
			PnAfjp item = new PnAfjp();
			
				item.IdAfjp = varIdAfjp;
			
				item.NombreAfjp = varNombreAfjp;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAfjpColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreAfjpColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAfjp = @"id_afjp";
			 public static string NombreAfjp = @"nombre_afjp";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
