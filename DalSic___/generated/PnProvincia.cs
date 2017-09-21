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
	/// Strongly-typed collection for the PnProvincia class.
	/// </summary>
    [Serializable]
	public partial class PnProvinciaCollection : ActiveList<PnProvincia, PnProvinciaCollection>
	{	   
		public PnProvinciaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnProvinciaCollection</returns>
		public PnProvinciaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnProvincia o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_provincias table.
	/// </summary>
	[Serializable]
	public partial class PnProvincia : ActiveRecord<PnProvincia>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnProvincia()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnProvincia(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnProvincia(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnProvincia(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_provincias", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProvincia = new TableSchema.TableColumn(schema);
				colvarIdProvincia.ColumnName = "id_provincia";
				colvarIdProvincia.DataType = DbType.Int32;
				colvarIdProvincia.MaxLength = 0;
				colvarIdProvincia.AutoIncrement = true;
				colvarIdProvincia.IsNullable = false;
				colvarIdProvincia.IsPrimaryKey = true;
				colvarIdProvincia.IsForeignKey = false;
				colvarIdProvincia.IsReadOnly = false;
				colvarIdProvincia.DefaultSetting = @"";
				colvarIdProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProvincia);
				
				TableSchema.TableColumn colvarCodProvincia = new TableSchema.TableColumn(schema);
				colvarCodProvincia.ColumnName = "cod_provincia";
				colvarCodProvincia.DataType = DbType.AnsiString;
				colvarCodProvincia.MaxLength = -1;
				colvarCodProvincia.AutoIncrement = false;
				colvarCodProvincia.IsNullable = false;
				colvarCodProvincia.IsPrimaryKey = false;
				colvarCodProvincia.IsForeignKey = false;
				colvarCodProvincia.IsReadOnly = false;
				colvarCodProvincia.DefaultSetting = @"";
				colvarCodProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodProvincia);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdPais = new TableSchema.TableColumn(schema);
				colvarIdPais.ColumnName = "id_pais";
				colvarIdPais.DataType = DbType.Int32;
				colvarIdPais.MaxLength = 0;
				colvarIdPais.AutoIncrement = false;
				colvarIdPais.IsNullable = false;
				colvarIdPais.IsPrimaryKey = false;
				colvarIdPais.IsForeignKey = false;
				colvarIdPais.IsReadOnly = false;
				colvarIdPais.DefaultSetting = @"";
				colvarIdPais.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPais);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_provincias",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProvincia")]
		[Bindable(true)]
		public int IdProvincia 
		{
			get { return GetColumnValue<int>(Columns.IdProvincia); }
			set { SetColumnValue(Columns.IdProvincia, value); }
		}
		  
		[XmlAttribute("CodProvincia")]
		[Bindable(true)]
		public string CodProvincia 
		{
			get { return GetColumnValue<string>(Columns.CodProvincia); }
			set { SetColumnValue(Columns.CodProvincia, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdPais")]
		[Bindable(true)]
		public int IdPais 
		{
			get { return GetColumnValue<int>(Columns.IdPais); }
			set { SetColumnValue(Columns.IdPais, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodProvincia,string varNombre,int varIdPais)
		{
			PnProvincia item = new PnProvincia();
			
			item.CodProvincia = varCodProvincia;
			
			item.Nombre = varNombre;
			
			item.IdPais = varIdPais;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdProvincia,string varCodProvincia,string varNombre,int varIdPais)
		{
			PnProvincia item = new PnProvincia();
			
				item.IdProvincia = varIdProvincia;
			
				item.CodProvincia = varCodProvincia;
			
				item.Nombre = varNombre;
			
				item.IdPais = varIdPais;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProvinciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodProvinciaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPaisColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProvincia = @"id_provincia";
			 public static string CodProvincia = @"cod_provincia";
			 public static string Nombre = @"nombre";
			 public static string IdPais = @"id_pais";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
