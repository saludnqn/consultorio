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
	/// Strongly-typed collection for the PnUadParametro class.
	/// </summary>
    [Serializable]
	public partial class PnUadParametroCollection : ActiveList<PnUadParametro, PnUadParametroCollection>
	{	   
		public PnUadParametroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnUadParametroCollection</returns>
		public PnUadParametroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnUadParametro o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_uad_parametros table.
	/// </summary>
	[Serializable]
	public partial class PnUadParametro : ActiveRecord<PnUadParametro>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnUadParametro()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnUadParametro(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnUadParametro(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnUadParametro(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_uad_parametros", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdParametros = new TableSchema.TableColumn(schema);
				colvarIdParametros.ColumnName = "id_parametros";
				colvarIdParametros.DataType = DbType.Int32;
				colvarIdParametros.MaxLength = 0;
				colvarIdParametros.AutoIncrement = true;
				colvarIdParametros.IsNullable = false;
				colvarIdParametros.IsPrimaryKey = true;
				colvarIdParametros.IsForeignKey = false;
				colvarIdParametros.IsReadOnly = false;
				colvarIdParametros.DefaultSetting = @"";
				colvarIdParametros.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdParametros);
				
				TableSchema.TableColumn colvarCodigoProvincia = new TableSchema.TableColumn(schema);
				colvarCodigoProvincia.ColumnName = "codigo_provincia";
				colvarCodigoProvincia.DataType = DbType.AnsiString;
				colvarCodigoProvincia.MaxLength = 2;
				colvarCodigoProvincia.AutoIncrement = false;
				colvarCodigoProvincia.IsNullable = true;
				colvarCodigoProvincia.IsPrimaryKey = false;
				colvarCodigoProvincia.IsForeignKey = false;
				colvarCodigoProvincia.IsReadOnly = false;
				colvarCodigoProvincia.DefaultSetting = @"";
				colvarCodigoProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoProvincia);
				
				TableSchema.TableColumn colvarCodigoUad = new TableSchema.TableColumn(schema);
				colvarCodigoUad.ColumnName = "codigo_uad";
				colvarCodigoUad.DataType = DbType.AnsiString;
				colvarCodigoUad.MaxLength = 5;
				colvarCodigoUad.AutoIncrement = false;
				colvarCodigoUad.IsNullable = true;
				colvarCodigoUad.IsPrimaryKey = false;
				colvarCodigoUad.IsForeignKey = false;
				colvarCodigoUad.IsReadOnly = false;
				colvarCodigoUad.DefaultSetting = @"";
				colvarCodigoUad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoUad);
				
				TableSchema.TableColumn colvarNombreUad = new TableSchema.TableColumn(schema);
				colvarNombreUad.ColumnName = "nombre_uad";
				colvarNombreUad.DataType = DbType.AnsiString;
				colvarNombreUad.MaxLength = 30;
				colvarNombreUad.AutoIncrement = false;
				colvarNombreUad.IsNullable = true;
				colvarNombreUad.IsPrimaryKey = false;
				colvarNombreUad.IsForeignKey = false;
				colvarNombreUad.IsReadOnly = false;
				colvarNombreUad.DefaultSetting = @"";
				colvarNombreUad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreUad);
				
				TableSchema.TableColumn colvarCodigoCi = new TableSchema.TableColumn(schema);
				colvarCodigoCi.ColumnName = "codigo_ci";
				colvarCodigoCi.DataType = DbType.AnsiString;
				colvarCodigoCi.MaxLength = 5;
				colvarCodigoCi.AutoIncrement = false;
				colvarCodigoCi.IsNullable = true;
				colvarCodigoCi.IsPrimaryKey = false;
				colvarCodigoCi.IsForeignKey = false;
				colvarCodigoCi.IsReadOnly = false;
				colvarCodigoCi.DefaultSetting = @"";
				colvarCodigoCi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoCi);
				
				TableSchema.TableColumn colvarNombreCi = new TableSchema.TableColumn(schema);
				colvarNombreCi.ColumnName = "nombre_ci";
				colvarNombreCi.DataType = DbType.AnsiString;
				colvarNombreCi.MaxLength = 30;
				colvarNombreCi.AutoIncrement = false;
				colvarNombreCi.IsNullable = true;
				colvarNombreCi.IsPrimaryKey = false;
				colvarNombreCi.IsForeignKey = false;
				colvarNombreCi.IsReadOnly = false;
				colvarNombreCi.DefaultSetting = @"";
				colvarNombreCi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreCi);
				
				TableSchema.TableColumn colvarNombreProvincia = new TableSchema.TableColumn(schema);
				colvarNombreProvincia.ColumnName = "nombre_provincia";
				colvarNombreProvincia.DataType = DbType.AnsiStringFixedLength;
				colvarNombreProvincia.MaxLength = 20;
				colvarNombreProvincia.AutoIncrement = false;
				colvarNombreProvincia.IsNullable = true;
				colvarNombreProvincia.IsPrimaryKey = false;
				colvarNombreProvincia.IsForeignKey = false;
				colvarNombreProvincia.IsReadOnly = false;
				colvarNombreProvincia.DefaultSetting = @"";
				colvarNombreProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreProvincia);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_uad_parametros",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdParametros")]
		[Bindable(true)]
		public int IdParametros 
		{
			get { return GetColumnValue<int>(Columns.IdParametros); }
			set { SetColumnValue(Columns.IdParametros, value); }
		}
		  
		[XmlAttribute("CodigoProvincia")]
		[Bindable(true)]
		public string CodigoProvincia 
		{
			get { return GetColumnValue<string>(Columns.CodigoProvincia); }
			set { SetColumnValue(Columns.CodigoProvincia, value); }
		}
		  
		[XmlAttribute("CodigoUad")]
		[Bindable(true)]
		public string CodigoUad 
		{
			get { return GetColumnValue<string>(Columns.CodigoUad); }
			set { SetColumnValue(Columns.CodigoUad, value); }
		}
		  
		[XmlAttribute("NombreUad")]
		[Bindable(true)]
		public string NombreUad 
		{
			get { return GetColumnValue<string>(Columns.NombreUad); }
			set { SetColumnValue(Columns.NombreUad, value); }
		}
		  
		[XmlAttribute("CodigoCi")]
		[Bindable(true)]
		public string CodigoCi 
		{
			get { return GetColumnValue<string>(Columns.CodigoCi); }
			set { SetColumnValue(Columns.CodigoCi, value); }
		}
		  
		[XmlAttribute("NombreCi")]
		[Bindable(true)]
		public string NombreCi 
		{
			get { return GetColumnValue<string>(Columns.NombreCi); }
			set { SetColumnValue(Columns.NombreCi, value); }
		}
		  
		[XmlAttribute("NombreProvincia")]
		[Bindable(true)]
		public string NombreProvincia 
		{
			get { return GetColumnValue<string>(Columns.NombreProvincia); }
			set { SetColumnValue(Columns.NombreProvincia, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodigoProvincia,string varCodigoUad,string varNombreUad,string varCodigoCi,string varNombreCi,string varNombreProvincia)
		{
			PnUadParametro item = new PnUadParametro();
			
			item.CodigoProvincia = varCodigoProvincia;
			
			item.CodigoUad = varCodigoUad;
			
			item.NombreUad = varNombreUad;
			
			item.CodigoCi = varCodigoCi;
			
			item.NombreCi = varNombreCi;
			
			item.NombreProvincia = varNombreProvincia;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdParametros,string varCodigoProvincia,string varCodigoUad,string varNombreUad,string varCodigoCi,string varNombreCi,string varNombreProvincia)
		{
			PnUadParametro item = new PnUadParametro();
			
				item.IdParametros = varIdParametros;
			
				item.CodigoProvincia = varCodigoProvincia;
			
				item.CodigoUad = varCodigoUad;
			
				item.NombreUad = varNombreUad;
			
				item.CodigoCi = varCodigoCi;
			
				item.NombreCi = varNombreCi;
			
				item.NombreProvincia = varNombreProvincia;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdParametrosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoProvinciaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoUadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreUadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoCiColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreCiColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreProvinciaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdParametros = @"id_parametros";
			 public static string CodigoProvincia = @"codigo_provincia";
			 public static string CodigoUad = @"codigo_uad";
			 public static string NombreUad = @"nombre_uad";
			 public static string CodigoCi = @"codigo_ci";
			 public static string NombreCi = @"nombre_ci";
			 public static string NombreProvincia = @"nombre_provincia";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
