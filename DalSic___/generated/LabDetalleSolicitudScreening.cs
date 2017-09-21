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
	/// Strongly-typed collection for the LabDetalleSolicitudScreening class.
	/// </summary>
    [Serializable]
	public partial class LabDetalleSolicitudScreeningCollection : ActiveList<LabDetalleSolicitudScreening, LabDetalleSolicitudScreeningCollection>
	{	   
		public LabDetalleSolicitudScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabDetalleSolicitudScreeningCollection</returns>
		public LabDetalleSolicitudScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabDetalleSolicitudScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_DetalleSolicitudScreening table.
	/// </summary>
	[Serializable]
	public partial class LabDetalleSolicitudScreening : ActiveRecord<LabDetalleSolicitudScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabDetalleSolicitudScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabDetalleSolicitudScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabDetalleSolicitudScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabDetalleSolicitudScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_DetalleSolicitudScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDetalleSolicitudScreening = new TableSchema.TableColumn(schema);
				colvarIdDetalleSolicitudScreening.ColumnName = "idDetalleSolicitudScreening";
				colvarIdDetalleSolicitudScreening.DataType = DbType.Int32;
				colvarIdDetalleSolicitudScreening.MaxLength = 0;
				colvarIdDetalleSolicitudScreening.AutoIncrement = true;
				colvarIdDetalleSolicitudScreening.IsNullable = false;
				colvarIdDetalleSolicitudScreening.IsPrimaryKey = true;
				colvarIdDetalleSolicitudScreening.IsForeignKey = false;
				colvarIdDetalleSolicitudScreening.IsReadOnly = false;
				colvarIdDetalleSolicitudScreening.DefaultSetting = @"";
				colvarIdDetalleSolicitudScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDetalleSolicitudScreening);
				
				TableSchema.TableColumn colvarIdSolicitudScreening = new TableSchema.TableColumn(schema);
				colvarIdSolicitudScreening.ColumnName = "idSolicitudScreening";
				colvarIdSolicitudScreening.DataType = DbType.Int32;
				colvarIdSolicitudScreening.MaxLength = 0;
				colvarIdSolicitudScreening.AutoIncrement = false;
				colvarIdSolicitudScreening.IsNullable = false;
				colvarIdSolicitudScreening.IsPrimaryKey = false;
				colvarIdSolicitudScreening.IsForeignKey = true;
				colvarIdSolicitudScreening.IsReadOnly = false;
				colvarIdSolicitudScreening.DefaultSetting = @"";
				
					colvarIdSolicitudScreening.ForeignKeyTableName = "LAB_SolicitudScreening";
				schema.Columns.Add(colvarIdSolicitudScreening);
				
				TableSchema.TableColumn colvarIdItem = new TableSchema.TableColumn(schema);
				colvarIdItem.ColumnName = "idItem";
				colvarIdItem.DataType = DbType.Int32;
				colvarIdItem.MaxLength = 0;
				colvarIdItem.AutoIncrement = false;
				colvarIdItem.IsNullable = false;
				colvarIdItem.IsPrimaryKey = false;
				colvarIdItem.IsForeignKey = true;
				colvarIdItem.IsReadOnly = false;
				colvarIdItem.DefaultSetting = @"";
				
					colvarIdItem.ForeignKeyTableName = "LAB_ItemScreening";
				schema.Columns.Add(colvarIdItem);
				
				TableSchema.TableColumn colvarResultado = new TableSchema.TableColumn(schema);
				colvarResultado.ColumnName = "resultado";
				colvarResultado.DataType = DbType.String;
				colvarResultado.MaxLength = 500;
				colvarResultado.AutoIncrement = false;
				colvarResultado.IsNullable = false;
				colvarResultado.IsPrimaryKey = false;
				colvarResultado.IsForeignKey = false;
				colvarResultado.IsReadOnly = false;
				colvarResultado.DefaultSetting = @"";
				colvarResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResultado);
				
				TableSchema.TableColumn colvarMetodo = new TableSchema.TableColumn(schema);
				colvarMetodo.ColumnName = "metodo";
				colvarMetodo.DataType = DbType.String;
				colvarMetodo.MaxLength = 500;
				colvarMetodo.AutoIncrement = false;
				colvarMetodo.IsNullable = false;
				colvarMetodo.IsPrimaryKey = false;
				colvarMetodo.IsForeignKey = false;
				colvarMetodo.IsReadOnly = false;
				colvarMetodo.DefaultSetting = @"";
				colvarMetodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMetodo);
				
				TableSchema.TableColumn colvarValorReferencia = new TableSchema.TableColumn(schema);
				colvarValorReferencia.ColumnName = "valorReferencia";
				colvarValorReferencia.DataType = DbType.String;
				colvarValorReferencia.MaxLength = 500;
				colvarValorReferencia.AutoIncrement = false;
				colvarValorReferencia.IsNullable = false;
				colvarValorReferencia.IsPrimaryKey = false;
				colvarValorReferencia.IsForeignKey = false;
				colvarValorReferencia.IsReadOnly = false;
				colvarValorReferencia.DefaultSetting = @"";
				colvarValorReferencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorReferencia);
				
				TableSchema.TableColumn colvarIdUsuarioResultado = new TableSchema.TableColumn(schema);
				colvarIdUsuarioResultado.ColumnName = "idUsuarioResultado";
				colvarIdUsuarioResultado.DataType = DbType.AnsiString;
				colvarIdUsuarioResultado.MaxLength = 50;
				colvarIdUsuarioResultado.AutoIncrement = false;
				colvarIdUsuarioResultado.IsNullable = false;
				colvarIdUsuarioResultado.IsPrimaryKey = false;
				colvarIdUsuarioResultado.IsForeignKey = false;
				colvarIdUsuarioResultado.IsReadOnly = false;
				colvarIdUsuarioResultado.DefaultSetting = @"";
				colvarIdUsuarioResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioResultado);
				
				TableSchema.TableColumn colvarFechaResultado = new TableSchema.TableColumn(schema);
				colvarFechaResultado.ColumnName = "fechaResultado";
				colvarFechaResultado.DataType = DbType.DateTime;
				colvarFechaResultado.MaxLength = 0;
				colvarFechaResultado.AutoIncrement = false;
				colvarFechaResultado.IsNullable = false;
				colvarFechaResultado.IsPrimaryKey = false;
				colvarFechaResultado.IsForeignKey = false;
				colvarFechaResultado.IsReadOnly = false;
				
						colvarFechaResultado.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaResultado);
				
				TableSchema.TableColumn colvarIdUsuarioValida = new TableSchema.TableColumn(schema);
				colvarIdUsuarioValida.ColumnName = "idUsuarioValida";
				colvarIdUsuarioValida.DataType = DbType.AnsiString;
				colvarIdUsuarioValida.MaxLength = 50;
				colvarIdUsuarioValida.AutoIncrement = false;
				colvarIdUsuarioValida.IsNullable = false;
				colvarIdUsuarioValida.IsPrimaryKey = false;
				colvarIdUsuarioValida.IsForeignKey = false;
				colvarIdUsuarioValida.IsReadOnly = false;
				colvarIdUsuarioValida.DefaultSetting = @"";
				colvarIdUsuarioValida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioValida);
				
				TableSchema.TableColumn colvarFechaValida = new TableSchema.TableColumn(schema);
				colvarFechaValida.ColumnName = "fechaValida";
				colvarFechaValida.DataType = DbType.DateTime;
				colvarFechaValida.MaxLength = 0;
				colvarFechaValida.AutoIncrement = false;
				colvarFechaValida.IsNullable = false;
				colvarFechaValida.IsPrimaryKey = false;
				colvarFechaValida.IsForeignKey = false;
				colvarFechaValida.IsReadOnly = false;
				
						colvarFechaValida.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaValida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaValida);
				
				TableSchema.TableColumn colvarValorEncontrado = new TableSchema.TableColumn(schema);
				colvarValorEncontrado.ColumnName = "valorEncontrado";
				colvarValorEncontrado.DataType = DbType.AnsiString;
				colvarValorEncontrado.MaxLength = 30;
				colvarValorEncontrado.AutoIncrement = false;
				colvarValorEncontrado.IsNullable = true;
				colvarValorEncontrado.IsPrimaryKey = false;
				colvarValorEncontrado.IsForeignKey = false;
				colvarValorEncontrado.IsReadOnly = false;
				colvarValorEncontrado.DefaultSetting = @"";
				colvarValorEncontrado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorEncontrado);
				
				TableSchema.TableColumn colvarIdResultado = new TableSchema.TableColumn(schema);
				colvarIdResultado.ColumnName = "IdResultado";
				colvarIdResultado.DataType = DbType.Int32;
				colvarIdResultado.MaxLength = 0;
				colvarIdResultado.AutoIncrement = false;
				colvarIdResultado.IsNullable = true;
				colvarIdResultado.IsPrimaryKey = false;
				colvarIdResultado.IsForeignKey = false;
				colvarIdResultado.IsReadOnly = false;
				colvarIdResultado.DefaultSetting = @"";
				colvarIdResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdResultado);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_DetalleSolicitudScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDetalleSolicitudScreening")]
		[Bindable(true)]
		public int IdDetalleSolicitudScreening 
		{
			get { return GetColumnValue<int>(Columns.IdDetalleSolicitudScreening); }
			set { SetColumnValue(Columns.IdDetalleSolicitudScreening, value); }
		}
		  
		[XmlAttribute("IdSolicitudScreening")]
		[Bindable(true)]
		public int IdSolicitudScreening 
		{
			get { return GetColumnValue<int>(Columns.IdSolicitudScreening); }
			set { SetColumnValue(Columns.IdSolicitudScreening, value); }
		}
		  
		[XmlAttribute("IdItem")]
		[Bindable(true)]
		public int IdItem 
		{
			get { return GetColumnValue<int>(Columns.IdItem); }
			set { SetColumnValue(Columns.IdItem, value); }
		}
		  
		[XmlAttribute("Resultado")]
		[Bindable(true)]
		public string Resultado 
		{
			get { return GetColumnValue<string>(Columns.Resultado); }
			set { SetColumnValue(Columns.Resultado, value); }
		}
		  
		[XmlAttribute("Metodo")]
		[Bindable(true)]
		public string Metodo 
		{
			get { return GetColumnValue<string>(Columns.Metodo); }
			set { SetColumnValue(Columns.Metodo, value); }
		}
		  
		[XmlAttribute("ValorReferencia")]
		[Bindable(true)]
		public string ValorReferencia 
		{
			get { return GetColumnValue<string>(Columns.ValorReferencia); }
			set { SetColumnValue(Columns.ValorReferencia, value); }
		}
		  
		[XmlAttribute("IdUsuarioResultado")]
		[Bindable(true)]
		public string IdUsuarioResultado 
		{
			get { return GetColumnValue<string>(Columns.IdUsuarioResultado); }
			set { SetColumnValue(Columns.IdUsuarioResultado, value); }
		}
		  
		[XmlAttribute("FechaResultado")]
		[Bindable(true)]
		public DateTime FechaResultado 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaResultado); }
			set { SetColumnValue(Columns.FechaResultado, value); }
		}
		  
		[XmlAttribute("IdUsuarioValida")]
		[Bindable(true)]
		public string IdUsuarioValida 
		{
			get { return GetColumnValue<string>(Columns.IdUsuarioValida); }
			set { SetColumnValue(Columns.IdUsuarioValida, value); }
		}
		  
		[XmlAttribute("FechaValida")]
		[Bindable(true)]
		public DateTime FechaValida 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaValida); }
			set { SetColumnValue(Columns.FechaValida, value); }
		}
		  
		[XmlAttribute("ValorEncontrado")]
		[Bindable(true)]
		public string ValorEncontrado 
		{
			get { return GetColumnValue<string>(Columns.ValorEncontrado); }
			set { SetColumnValue(Columns.ValorEncontrado, value); }
		}
		  
		[XmlAttribute("IdResultado")]
		[Bindable(true)]
		public int? IdResultado 
		{
			get { return GetColumnValue<int?>(Columns.IdResultado); }
			set { SetColumnValue(Columns.IdResultado, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabSolicitudScreening ActiveRecord object related to this LabDetalleSolicitudScreening
		/// 
		/// </summary>
		public DalSic.LabSolicitudScreening LabSolicitudScreening
		{
			get { return DalSic.LabSolicitudScreening.FetchByID(this.IdSolicitudScreening); }
			set { SetColumnValue("idSolicitudScreening", value.IdSolicitudScreening); }
		}
		
		
		/// <summary>
		/// Returns a LabItemScreening ActiveRecord object related to this LabDetalleSolicitudScreening
		/// 
		/// </summary>
		public DalSic.LabItemScreening LabItemScreening
		{
			get { return DalSic.LabItemScreening.FetchByID(this.IdItem); }
			set { SetColumnValue("idItem", value.IdItemScreening); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdSolicitudScreening,int varIdItem,string varResultado,string varMetodo,string varValorReferencia,string varIdUsuarioResultado,DateTime varFechaResultado,string varIdUsuarioValida,DateTime varFechaValida,string varValorEncontrado,int? varIdResultado)
		{
			LabDetalleSolicitudScreening item = new LabDetalleSolicitudScreening();
			
			item.IdSolicitudScreening = varIdSolicitudScreening;
			
			item.IdItem = varIdItem;
			
			item.Resultado = varResultado;
			
			item.Metodo = varMetodo;
			
			item.ValorReferencia = varValorReferencia;
			
			item.IdUsuarioResultado = varIdUsuarioResultado;
			
			item.FechaResultado = varFechaResultado;
			
			item.IdUsuarioValida = varIdUsuarioValida;
			
			item.FechaValida = varFechaValida;
			
			item.ValorEncontrado = varValorEncontrado;
			
			item.IdResultado = varIdResultado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDetalleSolicitudScreening,int varIdSolicitudScreening,int varIdItem,string varResultado,string varMetodo,string varValorReferencia,string varIdUsuarioResultado,DateTime varFechaResultado,string varIdUsuarioValida,DateTime varFechaValida,string varValorEncontrado,int? varIdResultado)
		{
			LabDetalleSolicitudScreening item = new LabDetalleSolicitudScreening();
			
				item.IdDetalleSolicitudScreening = varIdDetalleSolicitudScreening;
			
				item.IdSolicitudScreening = varIdSolicitudScreening;
			
				item.IdItem = varIdItem;
			
				item.Resultado = varResultado;
			
				item.Metodo = varMetodo;
			
				item.ValorReferencia = varValorReferencia;
			
				item.IdUsuarioResultado = varIdUsuarioResultado;
			
				item.FechaResultado = varFechaResultado;
			
				item.IdUsuarioValida = varIdUsuarioValida;
			
				item.FechaValida = varFechaValida;
			
				item.ValorEncontrado = varValorEncontrado;
			
				item.IdResultado = varIdResultado;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDetalleSolicitudScreeningColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ResultadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MetodoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorReferenciaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioResultadoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaResultadoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioValidaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaValidaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorEncontradoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResultadoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDetalleSolicitudScreening = @"idDetalleSolicitudScreening";
			 public static string IdSolicitudScreening = @"idSolicitudScreening";
			 public static string IdItem = @"idItem";
			 public static string Resultado = @"resultado";
			 public static string Metodo = @"metodo";
			 public static string ValorReferencia = @"valorReferencia";
			 public static string IdUsuarioResultado = @"idUsuarioResultado";
			 public static string FechaResultado = @"fechaResultado";
			 public static string IdUsuarioValida = @"idUsuarioValida";
			 public static string FechaValida = @"fechaValida";
			 public static string ValorEncontrado = @"valorEncontrado";
			 public static string IdResultado = @"IdResultado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
