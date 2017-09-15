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
	/// Strongly-typed collection for the PnIndicadoresIn class.
	/// </summary>
    [Serializable]
	public partial class PnIndicadoresInCollection : ActiveList<PnIndicadoresIn, PnIndicadoresInCollection>
	{	   
		public PnIndicadoresInCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnIndicadoresInCollection</returns>
		public PnIndicadoresInCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnIndicadoresIn o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_indicadores_ins table.
	/// </summary>
	[Serializable]
	public partial class PnIndicadoresIn : ActiveRecord<PnIndicadoresIn>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnIndicadoresIn()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnIndicadoresIn(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnIndicadoresIn(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnIndicadoresIn(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_indicadores_ins", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdIndicadoresIns = new TableSchema.TableColumn(schema);
				colvarIdIndicadoresIns.ColumnName = "id_indicadores_ins";
				colvarIdIndicadoresIns.DataType = DbType.Int32;
				colvarIdIndicadoresIns.MaxLength = 0;
				colvarIdIndicadoresIns.AutoIncrement = true;
				colvarIdIndicadoresIns.IsNullable = false;
				colvarIdIndicadoresIns.IsPrimaryKey = true;
				colvarIdIndicadoresIns.IsForeignKey = false;
				colvarIdIndicadoresIns.IsReadOnly = false;
				colvarIdIndicadoresIns.DefaultSetting = @"";
				colvarIdIndicadoresIns.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdIndicadoresIns);
				
				TableSchema.TableColumn colvarIdDescIndicadorIns = new TableSchema.TableColumn(schema);
				colvarIdDescIndicadorIns.ColumnName = "id_desc_indicador_ins";
				colvarIdDescIndicadorIns.DataType = DbType.Int32;
				colvarIdDescIndicadorIns.MaxLength = 0;
				colvarIdDescIndicadorIns.AutoIncrement = false;
				colvarIdDescIndicadorIns.IsNullable = false;
				colvarIdDescIndicadorIns.IsPrimaryKey = false;
				colvarIdDescIndicadorIns.IsForeignKey = false;
				colvarIdDescIndicadorIns.IsReadOnly = false;
				colvarIdDescIndicadorIns.DefaultSetting = @"";
				colvarIdDescIndicadorIns.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDescIndicadorIns);
				
				TableSchema.TableColumn colvarMes = new TableSchema.TableColumn(schema);
				colvarMes.ColumnName = "mes";
				colvarMes.DataType = DbType.Int32;
				colvarMes.MaxLength = 0;
				colvarMes.AutoIncrement = false;
				colvarMes.IsNullable = true;
				colvarMes.IsPrimaryKey = false;
				colvarMes.IsForeignKey = false;
				colvarMes.IsReadOnly = false;
				colvarMes.DefaultSetting = @"";
				colvarMes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMes);
				
				TableSchema.TableColumn colvarAnio = new TableSchema.TableColumn(schema);
				colvarAnio.ColumnName = "anio";
				colvarAnio.DataType = DbType.Int32;
				colvarAnio.MaxLength = 0;
				colvarAnio.AutoIncrement = false;
				colvarAnio.IsNullable = true;
				colvarAnio.IsPrimaryKey = false;
				colvarAnio.IsForeignKey = false;
				colvarAnio.IsReadOnly = false;
				colvarAnio.DefaultSetting = @"";
				colvarAnio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnio);
				
				TableSchema.TableColumn colvarValor = new TableSchema.TableColumn(schema);
				colvarValor.ColumnName = "valor";
				colvarValor.DataType = DbType.Decimal;
				colvarValor.MaxLength = 0;
				colvarValor.AutoIncrement = false;
				colvarValor.IsNullable = true;
				colvarValor.IsPrimaryKey = false;
				colvarValor.IsForeignKey = false;
				colvarValor.IsReadOnly = false;
				colvarValor.DefaultSetting = @"";
				colvarValor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValor);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_indicadores_ins",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdIndicadoresIns")]
		[Bindable(true)]
		public int IdIndicadoresIns 
		{
			get { return GetColumnValue<int>(Columns.IdIndicadoresIns); }
			set { SetColumnValue(Columns.IdIndicadoresIns, value); }
		}
		  
		[XmlAttribute("IdDescIndicadorIns")]
		[Bindable(true)]
		public int IdDescIndicadorIns 
		{
			get { return GetColumnValue<int>(Columns.IdDescIndicadorIns); }
			set { SetColumnValue(Columns.IdDescIndicadorIns, value); }
		}
		  
		[XmlAttribute("Mes")]
		[Bindable(true)]
		public int? Mes 
		{
			get { return GetColumnValue<int?>(Columns.Mes); }
			set { SetColumnValue(Columns.Mes, value); }
		}
		  
		[XmlAttribute("Anio")]
		[Bindable(true)]
		public int? Anio 
		{
			get { return GetColumnValue<int?>(Columns.Anio); }
			set { SetColumnValue(Columns.Anio, value); }
		}
		  
		[XmlAttribute("Valor")]
		[Bindable(true)]
		public decimal? Valor 
		{
			get { return GetColumnValue<decimal?>(Columns.Valor); }
			set { SetColumnValue(Columns.Valor, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdDescIndicadorIns,int? varMes,int? varAnio,decimal? varValor)
		{
			PnIndicadoresIn item = new PnIndicadoresIn();
			
			item.IdDescIndicadorIns = varIdDescIndicadorIns;
			
			item.Mes = varMes;
			
			item.Anio = varAnio;
			
			item.Valor = varValor;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdIndicadoresIns,int varIdDescIndicadorIns,int? varMes,int? varAnio,decimal? varValor)
		{
			PnIndicadoresIn item = new PnIndicadoresIn();
			
				item.IdIndicadoresIns = varIdIndicadoresIns;
			
				item.IdDescIndicadorIns = varIdDescIndicadorIns;
			
				item.Mes = varMes;
			
				item.Anio = varAnio;
			
				item.Valor = varValor;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdIndicadoresInsColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDescIndicadorInsColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MesColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdIndicadoresIns = @"id_indicadores_ins";
			 public static string IdDescIndicadorIns = @"id_desc_indicador_ins";
			 public static string Mes = @"mes";
			 public static string Anio = @"anio";
			 public static string Valor = @"valor";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
