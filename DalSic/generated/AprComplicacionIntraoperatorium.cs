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
	/// Strongly-typed collection for the AprComplicacionIntraoperatorium class.
	/// </summary>
    [Serializable]
	public partial class AprComplicacionIntraoperatoriumCollection : ActiveList<AprComplicacionIntraoperatorium, AprComplicacionIntraoperatoriumCollection>
	{	   
		public AprComplicacionIntraoperatoriumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprComplicacionIntraoperatoriumCollection</returns>
		public AprComplicacionIntraoperatoriumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprComplicacionIntraoperatorium o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ComplicacionIntraoperatoria table.
	/// </summary>
	[Serializable]
	public partial class AprComplicacionIntraoperatorium : ActiveRecord<AprComplicacionIntraoperatorium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprComplicacionIntraoperatorium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprComplicacionIntraoperatorium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprComplicacionIntraoperatorium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprComplicacionIntraoperatorium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ComplicacionIntraoperatoria", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdComplicacionIntraoperatoria = new TableSchema.TableColumn(schema);
				colvarIdComplicacionIntraoperatoria.ColumnName = "idComplicacionIntraoperatoria";
				colvarIdComplicacionIntraoperatoria.DataType = DbType.Int32;
				colvarIdComplicacionIntraoperatoria.MaxLength = 0;
				colvarIdComplicacionIntraoperatoria.AutoIncrement = true;
				colvarIdComplicacionIntraoperatoria.IsNullable = false;
				colvarIdComplicacionIntraoperatoria.IsPrimaryKey = true;
				colvarIdComplicacionIntraoperatoria.IsForeignKey = false;
				colvarIdComplicacionIntraoperatoria.IsReadOnly = false;
				colvarIdComplicacionIntraoperatoria.DefaultSetting = @"";
				colvarIdComplicacionIntraoperatoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdComplicacionIntraoperatoria);
				
				TableSchema.TableColumn colvarDTipoComplicacionIntraoperatoria = new TableSchema.TableColumn(schema);
				colvarDTipoComplicacionIntraoperatoria.ColumnName = "dTipoComplicacionIntraoperatoria";
				colvarDTipoComplicacionIntraoperatoria.DataType = DbType.Int32;
				colvarDTipoComplicacionIntraoperatoria.MaxLength = 0;
				colvarDTipoComplicacionIntraoperatoria.AutoIncrement = false;
				colvarDTipoComplicacionIntraoperatoria.IsNullable = false;
				colvarDTipoComplicacionIntraoperatoria.IsPrimaryKey = false;
				colvarDTipoComplicacionIntraoperatoria.IsForeignKey = false;
				colvarDTipoComplicacionIntraoperatoria.IsReadOnly = false;
				colvarDTipoComplicacionIntraoperatoria.DefaultSetting = @"";
				colvarDTipoComplicacionIntraoperatoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDTipoComplicacionIntraoperatoria);
				
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
				DataService.Providers["sicProvider"].AddSchema("APR_ComplicacionIntraoperatoria",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdComplicacionIntraoperatoria")]
		[Bindable(true)]
		public int IdComplicacionIntraoperatoria 
		{
			get { return GetColumnValue<int>(Columns.IdComplicacionIntraoperatoria); }
			set { SetColumnValue(Columns.IdComplicacionIntraoperatoria, value); }
		}
		  
		[XmlAttribute("DTipoComplicacionIntraoperatoria")]
		[Bindable(true)]
		public int DTipoComplicacionIntraoperatoria 
		{
			get { return GetColumnValue<int>(Columns.DTipoComplicacionIntraoperatoria); }
			set { SetColumnValue(Columns.DTipoComplicacionIntraoperatoria, value); }
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
		public static void Insert(int varDTipoComplicacionIntraoperatoria,string varNombre)
		{
			AprComplicacionIntraoperatorium item = new AprComplicacionIntraoperatorium();
			
			item.DTipoComplicacionIntraoperatoria = varDTipoComplicacionIntraoperatoria;
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdComplicacionIntraoperatoria,int varDTipoComplicacionIntraoperatoria,string varNombre)
		{
			AprComplicacionIntraoperatorium item = new AprComplicacionIntraoperatorium();
			
				item.IdComplicacionIntraoperatoria = varIdComplicacionIntraoperatoria;
			
				item.DTipoComplicacionIntraoperatoria = varDTipoComplicacionIntraoperatoria;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdComplicacionIntraoperatoriaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DTipoComplicacionIntraoperatoriaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdComplicacionIntraoperatoria = @"idComplicacionIntraoperatoria";
			 public static string DTipoComplicacionIntraoperatoria = @"dTipoComplicacionIntraoperatoria";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
