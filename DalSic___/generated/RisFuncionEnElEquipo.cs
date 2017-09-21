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
	/// Strongly-typed collection for the RisFuncionEnElEquipo class.
	/// </summary>
    [Serializable]
	public partial class RisFuncionEnElEquipoCollection : ActiveList<RisFuncionEnElEquipo, RisFuncionEnElEquipoCollection>
	{	   
		public RisFuncionEnElEquipoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisFuncionEnElEquipoCollection</returns>
		public RisFuncionEnElEquipoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisFuncionEnElEquipo o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_FuncionEnElEquipo table.
	/// </summary>
	[Serializable]
	public partial class RisFuncionEnElEquipo : ActiveRecord<RisFuncionEnElEquipo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisFuncionEnElEquipo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisFuncionEnElEquipo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisFuncionEnElEquipo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisFuncionEnElEquipo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_FuncionEnElEquipo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdFuncionEnElEquipo = new TableSchema.TableColumn(schema);
				colvarIdFuncionEnElEquipo.ColumnName = "idFuncionEnElEquipo";
				colvarIdFuncionEnElEquipo.DataType = DbType.Int32;
				colvarIdFuncionEnElEquipo.MaxLength = 0;
				colvarIdFuncionEnElEquipo.AutoIncrement = true;
				colvarIdFuncionEnElEquipo.IsNullable = false;
				colvarIdFuncionEnElEquipo.IsPrimaryKey = true;
				colvarIdFuncionEnElEquipo.IsForeignKey = false;
				colvarIdFuncionEnElEquipo.IsReadOnly = false;
				colvarIdFuncionEnElEquipo.DefaultSetting = @"";
				colvarIdFuncionEnElEquipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFuncionEnElEquipo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_FuncionEnElEquipo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdFuncionEnElEquipo")]
		[Bindable(true)]
		public int IdFuncionEnElEquipo 
		{
			get { return GetColumnValue<int>(Columns.IdFuncionEnElEquipo); }
			set { SetColumnValue(Columns.IdFuncionEnElEquipo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion)
		{
			RisFuncionEnElEquipo item = new RisFuncionEnElEquipo();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdFuncionEnElEquipo,string varDescripcion)
		{
			RisFuncionEnElEquipo item = new RisFuncionEnElEquipo();
			
				item.IdFuncionEnElEquipo = varIdFuncionEnElEquipo;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdFuncionEnElEquipoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdFuncionEnElEquipo = @"idFuncionEnElEquipo";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
