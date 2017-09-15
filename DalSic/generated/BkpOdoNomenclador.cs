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
	/// Strongly-typed collection for the BkpOdoNomenclador class.
	/// </summary>
    [Serializable]
	public partial class BkpOdoNomencladorCollection : ActiveList<BkpOdoNomenclador, BkpOdoNomencladorCollection>
	{	   
		public BkpOdoNomencladorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>BkpOdoNomencladorCollection</returns>
		public BkpOdoNomencladorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                BkpOdoNomenclador o = this[i];
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
	/// This is an ActiveRecord class which wraps the bkp_ODO_Nomenclador table.
	/// </summary>
	[Serializable]
	public partial class BkpOdoNomenclador : ActiveRecord<BkpOdoNomenclador>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public BkpOdoNomenclador()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public BkpOdoNomenclador(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public BkpOdoNomenclador(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public BkpOdoNomenclador(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("bkp_ODO_Nomenclador", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNomencladorID = new TableSchema.TableColumn(schema);
				colvarNomencladorID.ColumnName = "NomencladorID";
				colvarNomencladorID.DataType = DbType.AnsiStringFixedLength;
				colvarNomencladorID.MaxLength = 5;
				colvarNomencladorID.AutoIncrement = false;
				colvarNomencladorID.IsNullable = false;
				colvarNomencladorID.IsPrimaryKey = true;
				colvarNomencladorID.IsForeignKey = false;
				colvarNomencladorID.IsReadOnly = false;
				colvarNomencladorID.DefaultSetting = @"";
				colvarNomencladorID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNomencladorID);
				
				TableSchema.TableColumn colvarNomencladorDescripcion = new TableSchema.TableColumn(schema);
				colvarNomencladorDescripcion.ColumnName = "NomencladorDescripcion";
				colvarNomencladorDescripcion.DataType = DbType.AnsiStringFixedLength;
				colvarNomencladorDescripcion.MaxLength = 255;
				colvarNomencladorDescripcion.AutoIncrement = false;
				colvarNomencladorDescripcion.IsNullable = false;
				colvarNomencladorDescripcion.IsPrimaryKey = false;
				colvarNomencladorDescripcion.IsForeignKey = false;
				colvarNomencladorDescripcion.IsReadOnly = false;
				colvarNomencladorDescripcion.DefaultSetting = @"";
				colvarNomencladorDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNomencladorDescripcion);
				
				TableSchema.TableColumn colvarNomencladorClasificacion = new TableSchema.TableColumn(schema);
				colvarNomencladorClasificacion.ColumnName = "NomencladorClasificacion";
				colvarNomencladorClasificacion.DataType = DbType.AnsiStringFixedLength;
				colvarNomencladorClasificacion.MaxLength = 40;
				colvarNomencladorClasificacion.AutoIncrement = false;
				colvarNomencladorClasificacion.IsNullable = false;
				colvarNomencladorClasificacion.IsPrimaryKey = false;
				colvarNomencladorClasificacion.IsForeignKey = false;
				colvarNomencladorClasificacion.IsReadOnly = false;
				colvarNomencladorClasificacion.DefaultSetting = @"";
				colvarNomencladorClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNomencladorClasificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("bkp_ODO_Nomenclador",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("NomencladorID")]
		[Bindable(true)]
		public string NomencladorID 
		{
			get { return GetColumnValue<string>(Columns.NomencladorID); }
			set { SetColumnValue(Columns.NomencladorID, value); }
		}
		  
		[XmlAttribute("NomencladorDescripcion")]
		[Bindable(true)]
		public string NomencladorDescripcion 
		{
			get { return GetColumnValue<string>(Columns.NomencladorDescripcion); }
			set { SetColumnValue(Columns.NomencladorDescripcion, value); }
		}
		  
		[XmlAttribute("NomencladorClasificacion")]
		[Bindable(true)]
		public string NomencladorClasificacion 
		{
			get { return GetColumnValue<string>(Columns.NomencladorClasificacion); }
			set { SetColumnValue(Columns.NomencladorClasificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNomencladorID,string varNomencladorDescripcion,string varNomencladorClasificacion)
		{
			BkpOdoNomenclador item = new BkpOdoNomenclador();
			
			item.NomencladorID = varNomencladorID;
			
			item.NomencladorDescripcion = varNomencladorDescripcion;
			
			item.NomencladorClasificacion = varNomencladorClasificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varNomencladorID,string varNomencladorDescripcion,string varNomencladorClasificacion)
		{
			BkpOdoNomenclador item = new BkpOdoNomenclador();
			
				item.NomencladorID = varNomencladorID;
			
				item.NomencladorDescripcion = varNomencladorDescripcion;
			
				item.NomencladorClasificacion = varNomencladorClasificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn NomencladorIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NomencladorDescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NomencladorClasificacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string NomencladorID = @"NomencladorID";
			 public static string NomencladorDescripcion = @"NomencladorDescripcion";
			 public static string NomencladorClasificacion = @"NomencladorClasificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
