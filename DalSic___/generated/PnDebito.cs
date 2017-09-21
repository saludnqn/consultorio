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
	/// Strongly-typed collection for the PnDebito class.
	/// </summary>
    [Serializable]
	public partial class PnDebitoCollection : ActiveList<PnDebito, PnDebitoCollection>
	{	   
		public PnDebitoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnDebitoCollection</returns>
		public PnDebitoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnDebito o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_debito table.
	/// </summary>
	[Serializable]
	public partial class PnDebito : ActiveRecord<PnDebito>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnDebito()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnDebito(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnDebito(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnDebito(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_debito", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDebito = new TableSchema.TableColumn(schema);
				colvarIdDebito.ColumnName = "id_debito";
				colvarIdDebito.DataType = DbType.Int32;
				colvarIdDebito.MaxLength = 0;
				colvarIdDebito.AutoIncrement = true;
				colvarIdDebito.IsNullable = false;
				colvarIdDebito.IsPrimaryKey = true;
				colvarIdDebito.IsForeignKey = false;
				colvarIdDebito.IsReadOnly = false;
				colvarIdDebito.DefaultSetting = @"";
				colvarIdDebito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDebito);
				
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
				
				TableSchema.TableColumn colvarDocumentoDeb = new TableSchema.TableColumn(schema);
				colvarDocumentoDeb.ColumnName = "documento_deb";
				colvarDocumentoDeb.DataType = DbType.AnsiString;
				colvarDocumentoDeb.MaxLength = -1;
				colvarDocumentoDeb.AutoIncrement = false;
				colvarDocumentoDeb.IsNullable = true;
				colvarDocumentoDeb.IsPrimaryKey = false;
				colvarDocumentoDeb.IsForeignKey = false;
				colvarDocumentoDeb.IsReadOnly = false;
				colvarDocumentoDeb.DefaultSetting = @"";
				colvarDocumentoDeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumentoDeb);
				
				TableSchema.TableColumn colvarApellidoDeb = new TableSchema.TableColumn(schema);
				colvarApellidoDeb.ColumnName = "apellido_deb";
				colvarApellidoDeb.DataType = DbType.AnsiString;
				colvarApellidoDeb.MaxLength = -1;
				colvarApellidoDeb.AutoIncrement = false;
				colvarApellidoDeb.IsNullable = true;
				colvarApellidoDeb.IsPrimaryKey = false;
				colvarApellidoDeb.IsForeignKey = false;
				colvarApellidoDeb.IsReadOnly = false;
				colvarApellidoDeb.DefaultSetting = @"";
				colvarApellidoDeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoDeb);
				
				TableSchema.TableColumn colvarNombreDeb = new TableSchema.TableColumn(schema);
				colvarNombreDeb.ColumnName = "nombre_deb";
				colvarNombreDeb.DataType = DbType.AnsiString;
				colvarNombreDeb.MaxLength = -1;
				colvarNombreDeb.AutoIncrement = false;
				colvarNombreDeb.IsNullable = true;
				colvarNombreDeb.IsPrimaryKey = false;
				colvarNombreDeb.IsForeignKey = false;
				colvarNombreDeb.IsReadOnly = false;
				colvarNombreDeb.DefaultSetting = @"";
				colvarNombreDeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreDeb);
				
				TableSchema.TableColumn colvarCodigoDeb = new TableSchema.TableColumn(schema);
				colvarCodigoDeb.ColumnName = "codigo_deb";
				colvarCodigoDeb.DataType = DbType.AnsiString;
				colvarCodigoDeb.MaxLength = -1;
				colvarCodigoDeb.AutoIncrement = false;
				colvarCodigoDeb.IsNullable = true;
				colvarCodigoDeb.IsPrimaryKey = false;
				colvarCodigoDeb.IsForeignKey = false;
				colvarCodigoDeb.IsReadOnly = false;
				colvarCodigoDeb.DefaultSetting = @"";
				colvarCodigoDeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoDeb);
				
				TableSchema.TableColumn colvarObservacionesDeb = new TableSchema.TableColumn(schema);
				colvarObservacionesDeb.ColumnName = "observaciones_deb";
				colvarObservacionesDeb.DataType = DbType.AnsiString;
				colvarObservacionesDeb.MaxLength = -1;
				colvarObservacionesDeb.AutoIncrement = false;
				colvarObservacionesDeb.IsNullable = true;
				colvarObservacionesDeb.IsPrimaryKey = false;
				colvarObservacionesDeb.IsForeignKey = false;
				colvarObservacionesDeb.IsReadOnly = false;
				colvarObservacionesDeb.DefaultSetting = @"";
				colvarObservacionesDeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionesDeb);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_debito",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDebito")]
		[Bindable(true)]
		public int IdDebito 
		{
			get { return GetColumnValue<int>(Columns.IdDebito); }
			set { SetColumnValue(Columns.IdDebito, value); }
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
		  
		[XmlAttribute("Cantidad")]
		[Bindable(true)]
		public decimal? Cantidad 
		{
			get { return GetColumnValue<decimal?>(Columns.Cantidad); }
			set { SetColumnValue(Columns.Cantidad, value); }
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
		  
		[XmlAttribute("DocumentoDeb")]
		[Bindable(true)]
		public string DocumentoDeb 
		{
			get { return GetColumnValue<string>(Columns.DocumentoDeb); }
			set { SetColumnValue(Columns.DocumentoDeb, value); }
		}
		  
		[XmlAttribute("ApellidoDeb")]
		[Bindable(true)]
		public string ApellidoDeb 
		{
			get { return GetColumnValue<string>(Columns.ApellidoDeb); }
			set { SetColumnValue(Columns.ApellidoDeb, value); }
		}
		  
		[XmlAttribute("NombreDeb")]
		[Bindable(true)]
		public string NombreDeb 
		{
			get { return GetColumnValue<string>(Columns.NombreDeb); }
			set { SetColumnValue(Columns.NombreDeb, value); }
		}
		  
		[XmlAttribute("CodigoDeb")]
		[Bindable(true)]
		public string CodigoDeb 
		{
			get { return GetColumnValue<string>(Columns.CodigoDeb); }
			set { SetColumnValue(Columns.CodigoDeb, value); }
		}
		  
		[XmlAttribute("ObservacionesDeb")]
		[Bindable(true)]
		public string ObservacionesDeb 
		{
			get { return GetColumnValue<string>(Columns.ObservacionesDeb); }
			set { SetColumnValue(Columns.ObservacionesDeb, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdFactura,int varIdNomenclador,decimal? varCantidad,int varIdMotivoD,decimal? varMonto,string varDocumentoDeb,string varApellidoDeb,string varNombreDeb,string varCodigoDeb,string varObservacionesDeb)
		{
			PnDebito item = new PnDebito();
			
			item.IdFactura = varIdFactura;
			
			item.IdNomenclador = varIdNomenclador;
			
			item.Cantidad = varCantidad;
			
			item.IdMotivoD = varIdMotivoD;
			
			item.Monto = varMonto;
			
			item.DocumentoDeb = varDocumentoDeb;
			
			item.ApellidoDeb = varApellidoDeb;
			
			item.NombreDeb = varNombreDeb;
			
			item.CodigoDeb = varCodigoDeb;
			
			item.ObservacionesDeb = varObservacionesDeb;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDebito,int varIdFactura,int varIdNomenclador,decimal? varCantidad,int varIdMotivoD,decimal? varMonto,string varDocumentoDeb,string varApellidoDeb,string varNombreDeb,string varCodigoDeb,string varObservacionesDeb)
		{
			PnDebito item = new PnDebito();
			
				item.IdDebito = varIdDebito;
			
				item.IdFactura = varIdFactura;
			
				item.IdNomenclador = varIdNomenclador;
			
				item.Cantidad = varCantidad;
			
				item.IdMotivoD = varIdMotivoD;
			
				item.Monto = varMonto;
			
				item.DocumentoDeb = varDocumentoDeb;
			
				item.ApellidoDeb = varApellidoDeb;
			
				item.NombreDeb = varNombreDeb;
			
				item.CodigoDeb = varCodigoDeb;
			
				item.ObservacionesDeb = varObservacionesDeb;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDebitoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFacturaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadColumn
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
        
        
        
        public static TableSchema.TableColumn DocumentoDebColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoDebColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreDebColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoDebColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesDebColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDebito = @"id_debito";
			 public static string IdFactura = @"id_factura";
			 public static string IdNomenclador = @"id_nomenclador";
			 public static string Cantidad = @"cantidad";
			 public static string IdMotivoD = @"id_motivo_d";
			 public static string Monto = @"monto";
			 public static string DocumentoDeb = @"documento_deb";
			 public static string ApellidoDeb = @"apellido_deb";
			 public static string NombreDeb = @"nombre_deb";
			 public static string CodigoDeb = @"codigo_deb";
			 public static string ObservacionesDeb = @"observaciones_deb";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
