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
	/// Strongly-typed collection for the AprAmbienteProcedimiento class.
	/// </summary>
    [Serializable]
	public partial class AprAmbienteProcedimientoCollection : ActiveList<AprAmbienteProcedimiento, AprAmbienteProcedimientoCollection>
	{	   
		public AprAmbienteProcedimientoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAmbienteProcedimientoCollection</returns>
		public AprAmbienteProcedimientoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAmbienteProcedimiento o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AmbienteProcedimiento table.
	/// </summary>
	[Serializable]
	public partial class AprAmbienteProcedimiento : ActiveRecord<AprAmbienteProcedimiento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAmbienteProcedimiento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAmbienteProcedimiento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAmbienteProcedimiento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAmbienteProcedimiento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AmbienteProcedimiento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAmbienteProcedimiento = new TableSchema.TableColumn(schema);
				colvarIdAmbienteProcedimiento.ColumnName = "idAmbienteProcedimiento";
				colvarIdAmbienteProcedimiento.DataType = DbType.Int32;
				colvarIdAmbienteProcedimiento.MaxLength = 0;
				colvarIdAmbienteProcedimiento.AutoIncrement = true;
				colvarIdAmbienteProcedimiento.IsNullable = false;
				colvarIdAmbienteProcedimiento.IsPrimaryKey = true;
				colvarIdAmbienteProcedimiento.IsForeignKey = false;
				colvarIdAmbienteProcedimiento.IsReadOnly = false;
				colvarIdAmbienteProcedimiento.DefaultSetting = @"";
				colvarIdAmbienteProcedimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAmbienteProcedimiento);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_AmbienteProcedimiento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAmbienteProcedimiento")]
		[Bindable(true)]
		public int IdAmbienteProcedimiento 
		{
			get { return GetColumnValue<int>(Columns.IdAmbienteProcedimiento); }
			set { SetColumnValue(Columns.IdAmbienteProcedimiento, value); }
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
			AprAmbienteProcedimiento item = new AprAmbienteProcedimiento();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAmbienteProcedimiento,string varNombre)
		{
			AprAmbienteProcedimiento item = new AprAmbienteProcedimiento();
			
				item.IdAmbienteProcedimiento = varIdAmbienteProcedimiento;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAmbienteProcedimientoColumn
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
			 public static string IdAmbienteProcedimiento = @"idAmbienteProcedimiento";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
