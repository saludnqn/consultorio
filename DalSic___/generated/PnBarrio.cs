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
	/// Strongly-typed collection for the PnBarrio class.
	/// </summary>
    [Serializable]
	public partial class PnBarrioCollection : ActiveList<PnBarrio, PnBarrioCollection>
	{	   
		public PnBarrioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnBarrioCollection</returns>
		public PnBarrioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnBarrio o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_barrios table.
	/// </summary>
	[Serializable]
	public partial class PnBarrio : ActiveRecord<PnBarrio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnBarrio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnBarrio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnBarrio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnBarrio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_barrios", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdBarrio = new TableSchema.TableColumn(schema);
				colvarIdBarrio.ColumnName = "id_barrio";
				colvarIdBarrio.DataType = DbType.Int32;
				colvarIdBarrio.MaxLength = 0;
				colvarIdBarrio.AutoIncrement = true;
				colvarIdBarrio.IsNullable = false;
				colvarIdBarrio.IsPrimaryKey = true;
				colvarIdBarrio.IsForeignKey = false;
				colvarIdBarrio.IsReadOnly = false;
				colvarIdBarrio.DefaultSetting = @"";
				colvarIdBarrio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBarrio);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdMunicipio = new TableSchema.TableColumn(schema);
				colvarIdMunicipio.ColumnName = "id_municipio";
				colvarIdMunicipio.DataType = DbType.Int32;
				colvarIdMunicipio.MaxLength = 0;
				colvarIdMunicipio.AutoIncrement = false;
				colvarIdMunicipio.IsNullable = false;
				colvarIdMunicipio.IsPrimaryKey = false;
				colvarIdMunicipio.IsForeignKey = false;
				colvarIdMunicipio.IsReadOnly = false;
				colvarIdMunicipio.DefaultSetting = @"";
				colvarIdMunicipio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMunicipio);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_barrios",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdBarrio")]
		[Bindable(true)]
		public int IdBarrio 
		{
			get { return GetColumnValue<int>(Columns.IdBarrio); }
			set { SetColumnValue(Columns.IdBarrio, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdMunicipio")]
		[Bindable(true)]
		public int IdMunicipio 
		{
			get { return GetColumnValue<int>(Columns.IdMunicipio); }
			set { SetColumnValue(Columns.IdMunicipio, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdMunicipio)
		{
			PnBarrio item = new PnBarrio();
			
			item.Nombre = varNombre;
			
			item.IdMunicipio = varIdMunicipio;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdBarrio,string varNombre,int varIdMunicipio)
		{
			PnBarrio item = new PnBarrio();
			
				item.IdBarrio = varIdBarrio;
			
				item.Nombre = varNombre;
			
				item.IdMunicipio = varIdMunicipio;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdBarrioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMunicipioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdBarrio = @"id_barrio";
			 public static string Nombre = @"nombre";
			 public static string IdMunicipio = @"id_municipio";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
