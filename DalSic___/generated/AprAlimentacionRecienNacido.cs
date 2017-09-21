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
	/// Strongly-typed collection for the AprAlimentacionRecienNacido class.
	/// </summary>
    [Serializable]
	public partial class AprAlimentacionRecienNacidoCollection : ActiveList<AprAlimentacionRecienNacido, AprAlimentacionRecienNacidoCollection>
	{	   
		public AprAlimentacionRecienNacidoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAlimentacionRecienNacidoCollection</returns>
		public AprAlimentacionRecienNacidoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAlimentacionRecienNacido o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AlimentacionRecienNacido table.
	/// </summary>
	[Serializable]
	public partial class AprAlimentacionRecienNacido : ActiveRecord<AprAlimentacionRecienNacido>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAlimentacionRecienNacido()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAlimentacionRecienNacido(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAlimentacionRecienNacido(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAlimentacionRecienNacido(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AlimentacionRecienNacido", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAlimentacionRecienNacido = new TableSchema.TableColumn(schema);
				colvarIdAlimentacionRecienNacido.ColumnName = "idAlimentacionRecienNacido";
				colvarIdAlimentacionRecienNacido.DataType = DbType.Int32;
				colvarIdAlimentacionRecienNacido.MaxLength = 0;
				colvarIdAlimentacionRecienNacido.AutoIncrement = true;
				colvarIdAlimentacionRecienNacido.IsNullable = false;
				colvarIdAlimentacionRecienNacido.IsPrimaryKey = true;
				colvarIdAlimentacionRecienNacido.IsForeignKey = false;
				colvarIdAlimentacionRecienNacido.IsReadOnly = false;
				colvarIdAlimentacionRecienNacido.DefaultSetting = @"";
				colvarIdAlimentacionRecienNacido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAlimentacionRecienNacido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_AlimentacionRecienNacido",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAlimentacionRecienNacido")]
		[Bindable(true)]
		public int IdAlimentacionRecienNacido 
		{
			get { return GetColumnValue<int>(Columns.IdAlimentacionRecienNacido); }
			set { SetColumnValue(Columns.IdAlimentacionRecienNacido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			AprAlimentacionRecienNacido item = new AprAlimentacionRecienNacido();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAlimentacionRecienNacido,string varNombre)
		{
			AprAlimentacionRecienNacido item = new AprAlimentacionRecienNacido();
			
				item.IdAlimentacionRecienNacido = varIdAlimentacionRecienNacido;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAlimentacionRecienNacidoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAlimentacionRecienNacido = @"idAlimentacionRecienNacido";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}