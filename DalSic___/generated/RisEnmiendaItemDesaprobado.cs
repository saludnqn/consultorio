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
	/// Strongly-typed collection for the RisEnmiendaItemDesaprobado class.
	/// </summary>
    [Serializable]
	public partial class RisEnmiendaItemDesaprobadoCollection : ActiveList<RisEnmiendaItemDesaprobado, RisEnmiendaItemDesaprobadoCollection>
	{	   
		public RisEnmiendaItemDesaprobadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEnmiendaItemDesaprobadoCollection</returns>
		public RisEnmiendaItemDesaprobadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEnmiendaItemDesaprobado o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EnmiendaItemDesaprobado table.
	/// </summary>
	[Serializable]
	public partial class RisEnmiendaItemDesaprobado : ActiveRecord<RisEnmiendaItemDesaprobado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEnmiendaItemDesaprobado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEnmiendaItemDesaprobado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEnmiendaItemDesaprobado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEnmiendaItemDesaprobado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EnmiendaItemDesaprobado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEnmiendaItemDesaprobado = new TableSchema.TableColumn(schema);
				colvarIdEnmiendaItemDesaprobado.ColumnName = "idEnmiendaItemDesaprobado";
				colvarIdEnmiendaItemDesaprobado.DataType = DbType.Int32;
				colvarIdEnmiendaItemDesaprobado.MaxLength = 0;
				colvarIdEnmiendaItemDesaprobado.AutoIncrement = true;
				colvarIdEnmiendaItemDesaprobado.IsNullable = false;
				colvarIdEnmiendaItemDesaprobado.IsPrimaryKey = true;
				colvarIdEnmiendaItemDesaprobado.IsForeignKey = false;
				colvarIdEnmiendaItemDesaprobado.IsReadOnly = false;
				colvarIdEnmiendaItemDesaprobado.DefaultSetting = @"";
				colvarIdEnmiendaItemDesaprobado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEnmiendaItemDesaprobado);
				
				TableSchema.TableColumn colvarIdEnmienda = new TableSchema.TableColumn(schema);
				colvarIdEnmienda.ColumnName = "idEnmienda";
				colvarIdEnmienda.DataType = DbType.Int32;
				colvarIdEnmienda.MaxLength = 0;
				colvarIdEnmienda.AutoIncrement = false;
				colvarIdEnmienda.IsNullable = false;
				colvarIdEnmienda.IsPrimaryKey = false;
				colvarIdEnmienda.IsForeignKey = false;
				colvarIdEnmienda.IsReadOnly = false;
				colvarIdEnmienda.DefaultSetting = @"";
				colvarIdEnmienda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEnmienda);
				
				TableSchema.TableColumn colvarIdItemDesaprobado = new TableSchema.TableColumn(schema);
				colvarIdItemDesaprobado.ColumnName = "idItemDesaprobado";
				colvarIdItemDesaprobado.DataType = DbType.Int32;
				colvarIdItemDesaprobado.MaxLength = 0;
				colvarIdItemDesaprobado.AutoIncrement = false;
				colvarIdItemDesaprobado.IsNullable = false;
				colvarIdItemDesaprobado.IsPrimaryKey = false;
				colvarIdItemDesaprobado.IsForeignKey = false;
				colvarIdItemDesaprobado.IsReadOnly = false;
				colvarIdItemDesaprobado.DefaultSetting = @"";
				colvarIdItemDesaprobado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItemDesaprobado);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EnmiendaItemDesaprobado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEnmiendaItemDesaprobado")]
		[Bindable(true)]
		public int IdEnmiendaItemDesaprobado 
		{
			get { return GetColumnValue<int>(Columns.IdEnmiendaItemDesaprobado); }
			set { SetColumnValue(Columns.IdEnmiendaItemDesaprobado, value); }
		}
		  
		[XmlAttribute("IdEnmienda")]
		[Bindable(true)]
		public int IdEnmienda 
		{
			get { return GetColumnValue<int>(Columns.IdEnmienda); }
			set { SetColumnValue(Columns.IdEnmienda, value); }
		}
		  
		[XmlAttribute("IdItemDesaprobado")]
		[Bindable(true)]
		public int IdItemDesaprobado 
		{
			get { return GetColumnValue<int>(Columns.IdItemDesaprobado); }
			set { SetColumnValue(Columns.IdItemDesaprobado, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEnmienda,int varIdItemDesaprobado)
		{
			RisEnmiendaItemDesaprobado item = new RisEnmiendaItemDesaprobado();
			
			item.IdEnmienda = varIdEnmienda;
			
			item.IdItemDesaprobado = varIdItemDesaprobado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEnmiendaItemDesaprobado,int varIdEnmienda,int varIdItemDesaprobado)
		{
			RisEnmiendaItemDesaprobado item = new RisEnmiendaItemDesaprobado();
			
				item.IdEnmiendaItemDesaprobado = varIdEnmiendaItemDesaprobado;
			
				item.IdEnmienda = varIdEnmienda;
			
				item.IdItemDesaprobado = varIdItemDesaprobado;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEnmiendaItemDesaprobadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEnmiendaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemDesaprobadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEnmiendaItemDesaprobado = @"idEnmiendaItemDesaprobado";
			 public static string IdEnmienda = @"idEnmienda";
			 public static string IdItemDesaprobado = @"idItemDesaprobado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
