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
	/// Strongly-typed collection for the PnEntrega class.
	/// </summary>
    [Serializable]
	public partial class PnEntregaCollection : ActiveList<PnEntrega, PnEntregaCollection>
	{	   
		public PnEntregaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEntregaCollection</returns>
		public PnEntregaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEntrega o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_entrega table.
	/// </summary>
	[Serializable]
	public partial class PnEntrega : ActiveRecord<PnEntrega>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEntrega()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEntrega(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEntrega(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEntrega(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_entrega", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEntrega = new TableSchema.TableColumn(schema);
				colvarIdEntrega.ColumnName = "id_entrega";
				colvarIdEntrega.DataType = DbType.Int32;
				colvarIdEntrega.MaxLength = 0;
				colvarIdEntrega.AutoIncrement = true;
				colvarIdEntrega.IsNullable = false;
				colvarIdEntrega.IsPrimaryKey = true;
				colvarIdEntrega.IsForeignKey = false;
				colvarIdEntrega.IsReadOnly = false;
				colvarIdEntrega.DefaultSetting = @"";
				colvarIdEntrega.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEntrega);
				
				TableSchema.TableColumn colvarDescripcionEntrega = new TableSchema.TableColumn(schema);
				colvarDescripcionEntrega.ColumnName = "descripcion_entrega";
				colvarDescripcionEntrega.DataType = DbType.AnsiString;
				colvarDescripcionEntrega.MaxLength = -1;
				colvarDescripcionEntrega.AutoIncrement = false;
				colvarDescripcionEntrega.IsNullable = true;
				colvarDescripcionEntrega.IsPrimaryKey = false;
				colvarDescripcionEntrega.IsForeignKey = false;
				colvarDescripcionEntrega.IsReadOnly = false;
				colvarDescripcionEntrega.DefaultSetting = @"";
				colvarDescripcionEntrega.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionEntrega);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_entrega",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEntrega")]
		[Bindable(true)]
		public int IdEntrega 
		{
			get { return GetColumnValue<int>(Columns.IdEntrega); }
			set { SetColumnValue(Columns.IdEntrega, value); }
		}
		  
		[XmlAttribute("DescripcionEntrega")]
		[Bindable(true)]
		public string DescripcionEntrega 
		{
			get { return GetColumnValue<string>(Columns.DescripcionEntrega); }
			set { SetColumnValue(Columns.DescripcionEntrega, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcionEntrega)
		{
			PnEntrega item = new PnEntrega();
			
			item.DescripcionEntrega = varDescripcionEntrega;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEntrega,string varDescripcionEntrega)
		{
			PnEntrega item = new PnEntrega();
			
				item.IdEntrega = varIdEntrega;
			
				item.DescripcionEntrega = varDescripcionEntrega;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEntregaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionEntregaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEntrega = @"id_entrega";
			 public static string DescripcionEntrega = @"descripcion_entrega";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
