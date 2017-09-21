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
	/// Strongly-typed collection for the RisEstudioItemDesaprobado class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioItemDesaprobadoCollection : ActiveList<RisEstudioItemDesaprobado, RisEstudioItemDesaprobadoCollection>
	{	   
		public RisEstudioItemDesaprobadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioItemDesaprobadoCollection</returns>
		public RisEstudioItemDesaprobadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioItemDesaprobado o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioItemDesaprobado table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioItemDesaprobado : ActiveRecord<RisEstudioItemDesaprobado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioItemDesaprobado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioItemDesaprobado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioItemDesaprobado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioItemDesaprobado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioItemDesaprobado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioItemDesarpobado = new TableSchema.TableColumn(schema);
				colvarIdEstudioItemDesarpobado.ColumnName = "idEstudioItemDesarpobado";
				colvarIdEstudioItemDesarpobado.DataType = DbType.Int32;
				colvarIdEstudioItemDesarpobado.MaxLength = 0;
				colvarIdEstudioItemDesarpobado.AutoIncrement = true;
				colvarIdEstudioItemDesarpobado.IsNullable = false;
				colvarIdEstudioItemDesarpobado.IsPrimaryKey = true;
				colvarIdEstudioItemDesarpobado.IsForeignKey = false;
				colvarIdEstudioItemDesarpobado.IsReadOnly = false;
				colvarIdEstudioItemDesarpobado.DefaultSetting = @"";
				colvarIdEstudioItemDesarpobado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioItemDesarpobado);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
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
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioItemDesaprobado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioItemDesarpobado")]
		[Bindable(true)]
		public int IdEstudioItemDesarpobado 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioItemDesarpobado); }
			set { SetColumnValue(Columns.IdEstudioItemDesarpobado, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
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
		public static void Insert(int varIdEstudio,int varIdItemDesaprobado)
		{
			RisEstudioItemDesaprobado item = new RisEstudioItemDesaprobado();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdItemDesaprobado = varIdItemDesaprobado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioItemDesarpobado,int varIdEstudio,int varIdItemDesaprobado)
		{
			RisEstudioItemDesaprobado item = new RisEstudioItemDesaprobado();
			
				item.IdEstudioItemDesarpobado = varIdEstudioItemDesarpobado;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdItemDesaprobado = varIdItemDesaprobado;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioItemDesarpobadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
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
			 public static string IdEstudioItemDesarpobado = @"idEstudioItemDesarpobado";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdItemDesaprobado = @"idItemDesaprobado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
