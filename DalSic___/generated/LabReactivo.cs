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
	/// Strongly-typed collection for the LabReactivo class.
	/// </summary>
    [Serializable]
	public partial class LabReactivoCollection : ActiveList<LabReactivo, LabReactivoCollection>
	{	   
		public LabReactivoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabReactivoCollection</returns>
		public LabReactivoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabReactivo o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_Reactivo table.
	/// </summary>
	[Serializable]
	public partial class LabReactivo : ActiveRecord<LabReactivo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabReactivo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabReactivo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabReactivo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabReactivo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_Reactivo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdReactivo = new TableSchema.TableColumn(schema);
				colvarIdReactivo.ColumnName = "idReactivo";
				colvarIdReactivo.DataType = DbType.Int32;
				colvarIdReactivo.MaxLength = 0;
				colvarIdReactivo.AutoIncrement = true;
				colvarIdReactivo.IsNullable = false;
				colvarIdReactivo.IsPrimaryKey = true;
				colvarIdReactivo.IsForeignKey = false;
				colvarIdReactivo.IsReadOnly = false;
				colvarIdReactivo.DefaultSetting = @"";
				colvarIdReactivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdReactivo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 500;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdArea = new TableSchema.TableColumn(schema);
				colvarIdArea.ColumnName = "idArea";
				colvarIdArea.DataType = DbType.Int32;
				colvarIdArea.MaxLength = 0;
				colvarIdArea.AutoIncrement = false;
				colvarIdArea.IsNullable = false;
				colvarIdArea.IsPrimaryKey = false;
				colvarIdArea.IsForeignKey = false;
				colvarIdArea.IsReadOnly = false;
				colvarIdArea.DefaultSetting = @"";
				colvarIdArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdArea);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_Reactivo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdReactivo")]
		[Bindable(true)]
		public int IdReactivo 
		{
			get { return GetColumnValue<int>(Columns.IdReactivo); }
			set { SetColumnValue(Columns.IdReactivo, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdArea")]
		[Bindable(true)]
		public int IdArea 
		{
			get { return GetColumnValue<int>(Columns.IdArea); }
			set { SetColumnValue(Columns.IdArea, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdArea)
		{
			LabReactivo item = new LabReactivo();
			
			item.Nombre = varNombre;
			
			item.IdArea = varIdArea;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdReactivo,string varNombre,int varIdArea)
		{
			LabReactivo item = new LabReactivo();
			
				item.IdReactivo = varIdReactivo;
			
				item.Nombre = varNombre;
			
				item.IdArea = varIdArea;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdReactivoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAreaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdReactivo = @"idReactivo";
			 public static string Nombre = @"nombre";
			 public static string IdArea = @"idArea";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
