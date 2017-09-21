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
	/// Strongly-typed collection for the PnDescIndicadorIn class.
	/// </summary>
    [Serializable]
	public partial class PnDescIndicadorInCollection : ActiveList<PnDescIndicadorIn, PnDescIndicadorInCollection>
	{	   
		public PnDescIndicadorInCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnDescIndicadorInCollection</returns>
		public PnDescIndicadorInCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnDescIndicadorIn o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_desc_indicador_ins table.
	/// </summary>
	[Serializable]
	public partial class PnDescIndicadorIn : ActiveRecord<PnDescIndicadorIn>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnDescIndicadorIn()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnDescIndicadorIn(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnDescIndicadorIn(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnDescIndicadorIn(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_desc_indicador_ins", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDescIndicadorIns = new TableSchema.TableColumn(schema);
				colvarIdDescIndicadorIns.ColumnName = "id_desc_indicador_ins";
				colvarIdDescIndicadorIns.DataType = DbType.Int32;
				colvarIdDescIndicadorIns.MaxLength = 0;
				colvarIdDescIndicadorIns.AutoIncrement = true;
				colvarIdDescIndicadorIns.IsNullable = false;
				colvarIdDescIndicadorIns.IsPrimaryKey = true;
				colvarIdDescIndicadorIns.IsForeignKey = false;
				colvarIdDescIndicadorIns.IsReadOnly = false;
				colvarIdDescIndicadorIns.DefaultSetting = @"";
				colvarIdDescIndicadorIns.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDescIndicadorIns);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarDescMedicion = new TableSchema.TableColumn(schema);
				colvarDescMedicion.ColumnName = "desc_medicion";
				colvarDescMedicion.DataType = DbType.AnsiString;
				colvarDescMedicion.MaxLength = -1;
				colvarDescMedicion.AutoIncrement = false;
				colvarDescMedicion.IsNullable = true;
				colvarDescMedicion.IsPrimaryKey = false;
				colvarDescMedicion.IsForeignKey = false;
				colvarDescMedicion.IsReadOnly = false;
				colvarDescMedicion.DefaultSetting = @"";
				colvarDescMedicion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescMedicion);
				
				TableSchema.TableColumn colvarValorDeseable = new TableSchema.TableColumn(schema);
				colvarValorDeseable.ColumnName = "valor_deseable";
				colvarValorDeseable.DataType = DbType.Decimal;
				colvarValorDeseable.MaxLength = 0;
				colvarValorDeseable.AutoIncrement = false;
				colvarValorDeseable.IsNullable = true;
				colvarValorDeseable.IsPrimaryKey = false;
				colvarValorDeseable.IsForeignKey = false;
				colvarValorDeseable.IsReadOnly = false;
				colvarValorDeseable.DefaultSetting = @"";
				colvarValorDeseable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorDeseable);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_desc_indicador_ins",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDescIndicadorIns")]
		[Bindable(true)]
		public int IdDescIndicadorIns 
		{
			get { return GetColumnValue<int>(Columns.IdDescIndicadorIns); }
			set { SetColumnValue(Columns.IdDescIndicadorIns, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("DescMedicion")]
		[Bindable(true)]
		public string DescMedicion 
		{
			get { return GetColumnValue<string>(Columns.DescMedicion); }
			set { SetColumnValue(Columns.DescMedicion, value); }
		}
		  
		[XmlAttribute("ValorDeseable")]
		[Bindable(true)]
		public decimal? ValorDeseable 
		{
			get { return GetColumnValue<decimal?>(Columns.ValorDeseable); }
			set { SetColumnValue(Columns.ValorDeseable, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,string varDescMedicion,decimal? varValorDeseable)
		{
			PnDescIndicadorIn item = new PnDescIndicadorIn();
			
			item.Descripcion = varDescripcion;
			
			item.DescMedicion = varDescMedicion;
			
			item.ValorDeseable = varValorDeseable;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDescIndicadorIns,string varDescripcion,string varDescMedicion,decimal? varValorDeseable)
		{
			PnDescIndicadorIn item = new PnDescIndicadorIn();
			
				item.IdDescIndicadorIns = varIdDescIndicadorIns;
			
				item.Descripcion = varDescripcion;
			
				item.DescMedicion = varDescMedicion;
			
				item.ValorDeseable = varValorDeseable;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDescIndicadorInsColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescMedicionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorDeseableColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDescIndicadorIns = @"id_desc_indicador_ins";
			 public static string Descripcion = @"descripcion";
			 public static string DescMedicion = @"desc_medicion";
			 public static string ValorDeseable = @"valor_deseable";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
