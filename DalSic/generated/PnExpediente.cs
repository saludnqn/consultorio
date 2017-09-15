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
	/// Strongly-typed collection for the PnExpediente class.
	/// </summary>
    [Serializable]
	public partial class PnExpedienteCollection : ActiveList<PnExpediente, PnExpedienteCollection>
	{	   
		public PnExpedienteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnExpedienteCollection</returns>
		public PnExpedienteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnExpediente o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_expediente table.
	/// </summary>
	[Serializable]
	public partial class PnExpediente : ActiveRecord<PnExpediente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnExpediente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnExpediente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnExpediente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnExpediente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_expediente", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdExpediente = new TableSchema.TableColumn(schema);
				colvarIdExpediente.ColumnName = "id_expediente";
				colvarIdExpediente.DataType = DbType.Int32;
				colvarIdExpediente.MaxLength = 0;
				colvarIdExpediente.AutoIncrement = true;
				colvarIdExpediente.IsNullable = false;
				colvarIdExpediente.IsPrimaryKey = true;
				colvarIdExpediente.IsForeignKey = false;
				colvarIdExpediente.IsReadOnly = false;
				colvarIdExpediente.DefaultSetting = @"";
				colvarIdExpediente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExpediente);
				
				TableSchema.TableColumn colvarIdEfeConv = new TableSchema.TableColumn(schema);
				colvarIdEfeConv.ColumnName = "id_efe_conv";
				colvarIdEfeConv.DataType = DbType.Int32;
				colvarIdEfeConv.MaxLength = 0;
				colvarIdEfeConv.AutoIncrement = false;
				colvarIdEfeConv.IsNullable = false;
				colvarIdEfeConv.IsPrimaryKey = false;
				colvarIdEfeConv.IsForeignKey = false;
				colvarIdEfeConv.IsReadOnly = false;
				colvarIdEfeConv.DefaultSetting = @"";
				colvarIdEfeConv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfeConv);
				
				TableSchema.TableColumn colvarNroExp = new TableSchema.TableColumn(schema);
				colvarNroExp.ColumnName = "nro_exp";
				colvarNroExp.DataType = DbType.AnsiString;
				colvarNroExp.MaxLength = -1;
				colvarNroExp.AutoIncrement = false;
				colvarNroExp.IsNullable = true;
				colvarNroExp.IsPrimaryKey = false;
				colvarNroExp.IsForeignKey = false;
				colvarNroExp.IsReadOnly = false;
				colvarNroExp.DefaultSetting = @"";
				colvarNroExp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroExp);
				
				TableSchema.TableColumn colvarFechaIng = new TableSchema.TableColumn(schema);
				colvarFechaIng.ColumnName = "fecha_ing";
				colvarFechaIng.DataType = DbType.DateTime;
				colvarFechaIng.MaxLength = 0;
				colvarFechaIng.AutoIncrement = false;
				colvarFechaIng.IsNullable = true;
				colvarFechaIng.IsPrimaryKey = false;
				colvarFechaIng.IsForeignKey = false;
				colvarFechaIng.IsReadOnly = false;
				colvarFechaIng.DefaultSetting = @"";
				colvarFechaIng.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaIng);
				
				TableSchema.TableColumn colvarMonto = new TableSchema.TableColumn(schema);
				colvarMonto.ColumnName = "monto";
				colvarMonto.DataType = DbType.Int32;
				colvarMonto.MaxLength = 0;
				colvarMonto.AutoIncrement = false;
				colvarMonto.IsNullable = true;
				colvarMonto.IsPrimaryKey = false;
				colvarMonto.IsForeignKey = false;
				colvarMonto.IsReadOnly = false;
				colvarMonto.DefaultSetting = @"";
				colvarMonto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMonto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_expediente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdExpediente")]
		[Bindable(true)]
		public int IdExpediente 
		{
			get { return GetColumnValue<int>(Columns.IdExpediente); }
			set { SetColumnValue(Columns.IdExpediente, value); }
		}
		  
		[XmlAttribute("IdEfeConv")]
		[Bindable(true)]
		public int IdEfeConv 
		{
			get { return GetColumnValue<int>(Columns.IdEfeConv); }
			set { SetColumnValue(Columns.IdEfeConv, value); }
		}
		  
		[XmlAttribute("NroExp")]
		[Bindable(true)]
		public string NroExp 
		{
			get { return GetColumnValue<string>(Columns.NroExp); }
			set { SetColumnValue(Columns.NroExp, value); }
		}
		  
		[XmlAttribute("FechaIng")]
		[Bindable(true)]
		public DateTime? FechaIng 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaIng); }
			set { SetColumnValue(Columns.FechaIng, value); }
		}
		  
		[XmlAttribute("Monto")]
		[Bindable(true)]
		public int? Monto 
		{
			get { return GetColumnValue<int?>(Columns.Monto); }
			set { SetColumnValue(Columns.Monto, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfeConv,string varNroExp,DateTime? varFechaIng,int? varMonto)
		{
			PnExpediente item = new PnExpediente();
			
			item.IdEfeConv = varIdEfeConv;
			
			item.NroExp = varNroExp;
			
			item.FechaIng = varFechaIng;
			
			item.Monto = varMonto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdExpediente,int varIdEfeConv,string varNroExp,DateTime? varFechaIng,int? varMonto)
		{
			PnExpediente item = new PnExpediente();
			
				item.IdExpediente = varIdExpediente;
			
				item.IdEfeConv = varIdEfeConv;
			
				item.NroExp = varNroExp;
			
				item.FechaIng = varFechaIng;
			
				item.Monto = varMonto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdExpedienteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfeConvColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NroExpColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaIngColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdExpediente = @"id_expediente";
			 public static string IdEfeConv = @"id_efe_conv";
			 public static string NroExp = @"nro_exp";
			 public static string FechaIng = @"fecha_ing";
			 public static string Monto = @"monto";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
