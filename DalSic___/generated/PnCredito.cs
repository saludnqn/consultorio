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
	/// Strongly-typed collection for the PnCredito class.
	/// </summary>
    [Serializable]
	public partial class PnCreditoCollection : ActiveList<PnCredito, PnCreditoCollection>
	{	   
		public PnCreditoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCreditoCollection</returns>
		public PnCreditoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCredito o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_credito table.
	/// </summary>
	[Serializable]
	public partial class PnCredito : ActiveRecord<PnCredito>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCredito()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCredito(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCredito(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCredito(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_credito", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCredito = new TableSchema.TableColumn(schema);
				colvarIdCredito.ColumnName = "id_credito";
				colvarIdCredito.DataType = DbType.Int32;
				colvarIdCredito.MaxLength = 0;
				colvarIdCredito.AutoIncrement = true;
				colvarIdCredito.IsNullable = false;
				colvarIdCredito.IsPrimaryKey = true;
				colvarIdCredito.IsForeignKey = false;
				colvarIdCredito.IsReadOnly = false;
				colvarIdCredito.DefaultSetting = @"";
				colvarIdCredito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCredito);
				
				TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
				colvarCantidad.ColumnName = "cantidad";
				colvarCantidad.DataType = DbType.Decimal;
				colvarCantidad.MaxLength = 0;
				colvarCantidad.AutoIncrement = false;
				colvarCantidad.IsNullable = true;
				colvarCantidad.IsPrimaryKey = false;
				colvarCantidad.IsForeignKey = false;
				colvarCantidad.IsReadOnly = false;
				colvarCantidad.DefaultSetting = @"";
				colvarCantidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidad);
				
				TableSchema.TableColumn colvarIdFactura = new TableSchema.TableColumn(schema);
				colvarIdFactura.ColumnName = "id_factura";
				colvarIdFactura.DataType = DbType.Int32;
				colvarIdFactura.MaxLength = 0;
				colvarIdFactura.AutoIncrement = false;
				colvarIdFactura.IsNullable = false;
				colvarIdFactura.IsPrimaryKey = false;
				colvarIdFactura.IsForeignKey = false;
				colvarIdFactura.IsReadOnly = false;
				colvarIdFactura.DefaultSetting = @"";
				colvarIdFactura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFactura);
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "id_nomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = false;
				colvarIdNomenclador.IsNullable = false;
				colvarIdNomenclador.IsPrimaryKey = false;
				colvarIdNomenclador.IsForeignKey = false;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				colvarIdNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarIdMotivoD = new TableSchema.TableColumn(schema);
				colvarIdMotivoD.ColumnName = "id_motivo_d";
				colvarIdMotivoD.DataType = DbType.Int32;
				colvarIdMotivoD.MaxLength = 0;
				colvarIdMotivoD.AutoIncrement = false;
				colvarIdMotivoD.IsNullable = false;
				colvarIdMotivoD.IsPrimaryKey = false;
				colvarIdMotivoD.IsForeignKey = false;
				colvarIdMotivoD.IsReadOnly = false;
				colvarIdMotivoD.DefaultSetting = @"";
				colvarIdMotivoD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoD);
				
				TableSchema.TableColumn colvarMonto = new TableSchema.TableColumn(schema);
				colvarMonto.ColumnName = "monto";
				colvarMonto.DataType = DbType.Decimal;
				colvarMonto.MaxLength = 0;
				colvarMonto.AutoIncrement = false;
				colvarMonto.IsNullable = true;
				colvarMonto.IsPrimaryKey = false;
				colvarMonto.IsForeignKey = false;
				colvarMonto.IsReadOnly = false;
				colvarMonto.DefaultSetting = @"";
				colvarMonto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMonto);
				
				TableSchema.TableColumn colvarCodigoCred = new TableSchema.TableColumn(schema);
				colvarCodigoCred.ColumnName = "codigo_cred";
				colvarCodigoCred.DataType = DbType.AnsiString;
				colvarCodigoCred.MaxLength = -1;
				colvarCodigoCred.AutoIncrement = false;
				colvarCodigoCred.IsNullable = true;
				colvarCodigoCred.IsPrimaryKey = false;
				colvarCodigoCred.IsForeignKey = false;
				colvarCodigoCred.IsReadOnly = false;
				colvarCodigoCred.DefaultSetting = @"";
				colvarCodigoCred.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoCred);
				
				TableSchema.TableColumn colvarObservacionesCred = new TableSchema.TableColumn(schema);
				colvarObservacionesCred.ColumnName = "observaciones_cred";
				colvarObservacionesCred.DataType = DbType.AnsiString;
				colvarObservacionesCred.MaxLength = -1;
				colvarObservacionesCred.AutoIncrement = false;
				colvarObservacionesCred.IsNullable = true;
				colvarObservacionesCred.IsPrimaryKey = false;
				colvarObservacionesCred.IsForeignKey = false;
				colvarObservacionesCred.IsReadOnly = false;
				colvarObservacionesCred.DefaultSetting = @"";
				colvarObservacionesCred.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionesCred);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_credito",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCredito")]
		[Bindable(true)]
		public int IdCredito 
		{
			get { return GetColumnValue<int>(Columns.IdCredito); }
			set { SetColumnValue(Columns.IdCredito, value); }
		}
		  
		[XmlAttribute("Cantidad")]
		[Bindable(true)]
		public decimal? Cantidad 
		{
			get { return GetColumnValue<decimal?>(Columns.Cantidad); }
			set { SetColumnValue(Columns.Cantidad, value); }
		}
		  
		[XmlAttribute("IdFactura")]
		[Bindable(true)]
		public int IdFactura 
		{
			get { return GetColumnValue<int>(Columns.IdFactura); }
			set { SetColumnValue(Columns.IdFactura, value); }
		}
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int IdNomenclador 
		{
			get { return GetColumnValue<int>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("IdMotivoD")]
		[Bindable(true)]
		public int IdMotivoD 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoD); }
			set { SetColumnValue(Columns.IdMotivoD, value); }
		}
		  
		[XmlAttribute("Monto")]
		[Bindable(true)]
		public decimal? Monto 
		{
			get { return GetColumnValue<decimal?>(Columns.Monto); }
			set { SetColumnValue(Columns.Monto, value); }
		}
		  
		[XmlAttribute("CodigoCred")]
		[Bindable(true)]
		public string CodigoCred 
		{
			get { return GetColumnValue<string>(Columns.CodigoCred); }
			set { SetColumnValue(Columns.CodigoCred, value); }
		}
		  
		[XmlAttribute("ObservacionesCred")]
		[Bindable(true)]
		public string ObservacionesCred 
		{
			get { return GetColumnValue<string>(Columns.ObservacionesCred); }
			set { SetColumnValue(Columns.ObservacionesCred, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(decimal? varCantidad,int varIdFactura,int varIdNomenclador,int varIdMotivoD,decimal? varMonto,string varCodigoCred,string varObservacionesCred)
		{
			PnCredito item = new PnCredito();
			
			item.Cantidad = varCantidad;
			
			item.IdFactura = varIdFactura;
			
			item.IdNomenclador = varIdNomenclador;
			
			item.IdMotivoD = varIdMotivoD;
			
			item.Monto = varMonto;
			
			item.CodigoCred = varCodigoCred;
			
			item.ObservacionesCred = varObservacionesCred;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCredito,decimal? varCantidad,int varIdFactura,int varIdNomenclador,int varIdMotivoD,decimal? varMonto,string varCodigoCred,string varObservacionesCred)
		{
			PnCredito item = new PnCredito();
			
				item.IdCredito = varIdCredito;
			
				item.Cantidad = varCantidad;
			
				item.IdFactura = varIdFactura;
			
				item.IdNomenclador = varIdNomenclador;
			
				item.IdMotivoD = varIdMotivoD;
			
				item.Monto = varMonto;
			
				item.CodigoCred = varCodigoCred;
			
				item.ObservacionesCred = varObservacionesCred;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCreditoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFacturaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MontoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoCredColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesCredColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCredito = @"id_credito";
			 public static string Cantidad = @"cantidad";
			 public static string IdFactura = @"id_factura";
			 public static string IdNomenclador = @"id_nomenclador";
			 public static string IdMotivoD = @"id_motivo_d";
			 public static string Monto = @"monto";
			 public static string CodigoCred = @"codigo_cred";
			 public static string ObservacionesCred = @"observaciones_cred";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
