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
	/// Strongly-typed collection for the RisEstudioEntidad class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioEntidadCollection : ActiveList<RisEstudioEntidad, RisEstudioEntidadCollection>
	{	   
		public RisEstudioEntidadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioEntidadCollection</returns>
		public RisEstudioEntidadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioEntidad o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioEntidad table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioEntidad : ActiveRecord<RisEstudioEntidad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioEntidad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioEntidad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioEntidad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioEntidad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioEntidad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioEntidad = new TableSchema.TableColumn(schema);
				colvarIdEstudioEntidad.ColumnName = "idEstudioEntidad";
				colvarIdEstudioEntidad.DataType = DbType.Int32;
				colvarIdEstudioEntidad.MaxLength = 0;
				colvarIdEstudioEntidad.AutoIncrement = true;
				colvarIdEstudioEntidad.IsNullable = false;
				colvarIdEstudioEntidad.IsPrimaryKey = true;
				colvarIdEstudioEntidad.IsForeignKey = false;
				colvarIdEstudioEntidad.IsReadOnly = false;
				colvarIdEstudioEntidad.DefaultSetting = @"";
				colvarIdEstudioEntidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioEntidad);
				
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
				
				TableSchema.TableColumn colvarIdEntidad = new TableSchema.TableColumn(schema);
				colvarIdEntidad.ColumnName = "idEntidad";
				colvarIdEntidad.DataType = DbType.Int32;
				colvarIdEntidad.MaxLength = 0;
				colvarIdEntidad.AutoIncrement = false;
				colvarIdEntidad.IsNullable = false;
				colvarIdEntidad.IsPrimaryKey = false;
				colvarIdEntidad.IsForeignKey = false;
				colvarIdEntidad.IsReadOnly = false;
				colvarIdEntidad.DefaultSetting = @"";
				colvarIdEntidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEntidad);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioEntidad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioEntidad")]
		[Bindable(true)]
		public int IdEstudioEntidad 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioEntidad); }
			set { SetColumnValue(Columns.IdEstudioEntidad, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdEntidad")]
		[Bindable(true)]
		public int IdEntidad 
		{
			get { return GetColumnValue<int>(Columns.IdEntidad); }
			set { SetColumnValue(Columns.IdEntidad, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdEntidad)
		{
			RisEstudioEntidad item = new RisEstudioEntidad();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdEntidad = varIdEntidad;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioEntidad,int varIdEstudio,int varIdEntidad)
		{
			RisEstudioEntidad item = new RisEstudioEntidad();
			
				item.IdEstudioEntidad = varIdEstudioEntidad;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdEntidad = varIdEntidad;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioEntidadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEntidadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioEntidad = @"idEstudioEntidad";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdEntidad = @"idEntidad";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
