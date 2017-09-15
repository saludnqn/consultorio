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
	/// Strongly-typed collection for the RisCaracteristica class.
	/// </summary>
    [Serializable]
	public partial class RisCaracteristicaCollection : ActiveList<RisCaracteristica, RisCaracteristicaCollection>
	{	   
		public RisCaracteristicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisCaracteristicaCollection</returns>
		public RisCaracteristicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisCaracteristica o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_Caracteristica table.
	/// </summary>
	[Serializable]
	public partial class RisCaracteristica : ActiveRecord<RisCaracteristica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisCaracteristica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisCaracteristica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisCaracteristica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisCaracteristica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_Caracteristica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCaracteristica = new TableSchema.TableColumn(schema);
				colvarIdCaracteristica.ColumnName = "idCaracteristica";
				colvarIdCaracteristica.DataType = DbType.Int32;
				colvarIdCaracteristica.MaxLength = 0;
				colvarIdCaracteristica.AutoIncrement = true;
				colvarIdCaracteristica.IsNullable = false;
				colvarIdCaracteristica.IsPrimaryKey = true;
				colvarIdCaracteristica.IsForeignKey = false;
				colvarIdCaracteristica.IsReadOnly = false;
				colvarIdCaracteristica.DefaultSetting = @"";
				colvarIdCaracteristica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCaracteristica);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 500;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarTipoEstudio = new TableSchema.TableColumn(schema);
				colvarTipoEstudio.ColumnName = "tipoEstudio";
				colvarTipoEstudio.DataType = DbType.AnsiString;
				colvarTipoEstudio.MaxLength = 100;
				colvarTipoEstudio.AutoIncrement = false;
				colvarTipoEstudio.IsNullable = false;
				colvarTipoEstudio.IsPrimaryKey = false;
				colvarTipoEstudio.IsForeignKey = false;
				colvarTipoEstudio.IsReadOnly = false;
				colvarTipoEstudio.DefaultSetting = @"";
				colvarTipoEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoEstudio);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_Caracteristica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCaracteristica")]
		[Bindable(true)]
		public int IdCaracteristica 
		{
			get { return GetColumnValue<int>(Columns.IdCaracteristica); }
			set { SetColumnValue(Columns.IdCaracteristica, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("TipoEstudio")]
		[Bindable(true)]
		public string TipoEstudio 
		{
			get { return GetColumnValue<string>(Columns.TipoEstudio); }
			set { SetColumnValue(Columns.TipoEstudio, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,string varTipoEstudio)
		{
			RisCaracteristica item = new RisCaracteristica();
			
			item.Descripcion = varDescripcion;
			
			item.TipoEstudio = varTipoEstudio;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCaracteristica,string varDescripcion,string varTipoEstudio)
		{
			RisCaracteristica item = new RisCaracteristica();
			
				item.IdCaracteristica = varIdCaracteristica;
			
				item.Descripcion = varDescripcion;
			
				item.TipoEstudio = varTipoEstudio;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCaracteristicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoEstudioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCaracteristica = @"idCaracteristica";
			 public static string Descripcion = @"descripcion";
			 public static string TipoEstudio = @"tipoEstudio";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
