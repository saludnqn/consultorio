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
	/// Strongly-typed collection for the AprEgresoMaterno class.
	/// </summary>
    [Serializable]
	public partial class AprEgresoMaternoCollection : ActiveList<AprEgresoMaterno, AprEgresoMaternoCollection>
	{	   
		public AprEgresoMaternoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprEgresoMaternoCollection</returns>
		public AprEgresoMaternoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprEgresoMaterno o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_EgresoMaterno table.
	/// </summary>
	[Serializable]
	public partial class AprEgresoMaterno : ActiveRecord<AprEgresoMaterno>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprEgresoMaterno()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprEgresoMaterno(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprEgresoMaterno(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprEgresoMaterno(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_EgresoMaterno", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEgresoMaterno = new TableSchema.TableColumn(schema);
				colvarIdEgresoMaterno.ColumnName = "idEgresoMaterno";
				colvarIdEgresoMaterno.DataType = DbType.Int32;
				colvarIdEgresoMaterno.MaxLength = 0;
				colvarIdEgresoMaterno.AutoIncrement = true;
				colvarIdEgresoMaterno.IsNullable = false;
				colvarIdEgresoMaterno.IsPrimaryKey = true;
				colvarIdEgresoMaterno.IsForeignKey = false;
				colvarIdEgresoMaterno.IsReadOnly = false;
				colvarIdEgresoMaterno.DefaultSetting = @"";
				colvarIdEgresoMaterno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEgresoMaterno);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdEmbarazo.ColumnName = "idEmbarazo";
				colvarIdEmbarazo.DataType = DbType.Int32;
				colvarIdEmbarazo.MaxLength = 0;
				colvarIdEmbarazo.AutoIncrement = false;
				colvarIdEmbarazo.IsNullable = true;
				colvarIdEmbarazo.IsPrimaryKey = false;
				colvarIdEmbarazo.IsForeignKey = true;
				colvarIdEmbarazo.IsReadOnly = false;
				colvarIdEmbarazo.DefaultSetting = @"";
				
					colvarIdEmbarazo.ForeignKeyTableName = "APR_Embarazo";
				schema.Columns.Add(colvarIdEmbarazo);
				
				TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
				colvarFechaHora.ColumnName = "FechaHora";
				colvarFechaHora.DataType = DbType.DateTime;
				colvarFechaHora.MaxLength = 0;
				colvarFechaHora.AutoIncrement = false;
				colvarFechaHora.IsNullable = true;
				colvarFechaHora.IsPrimaryKey = false;
				colvarFechaHora.IsForeignKey = false;
				colvarFechaHora.IsReadOnly = false;
				colvarFechaHora.DefaultSetting = @"";
				colvarFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHora);
				
				TableSchema.TableColumn colvarIdTraslado = new TableSchema.TableColumn(schema);
				colvarIdTraslado.ColumnName = "idTraslado";
				colvarIdTraslado.DataType = DbType.Int32;
				colvarIdTraslado.MaxLength = 0;
				colvarIdTraslado.AutoIncrement = false;
				colvarIdTraslado.IsNullable = true;
				colvarIdTraslado.IsPrimaryKey = false;
				colvarIdTraslado.IsForeignKey = false;
				colvarIdTraslado.IsReadOnly = false;
				colvarIdTraslado.DefaultSetting = @"";
				colvarIdTraslado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTraslado);
				
				TableSchema.TableColumn colvarIdEstadoEgreso = new TableSchema.TableColumn(schema);
				colvarIdEstadoEgreso.ColumnName = "idEstadoEgreso";
				colvarIdEstadoEgreso.DataType = DbType.Int32;
				colvarIdEstadoEgreso.MaxLength = 0;
				colvarIdEstadoEgreso.AutoIncrement = false;
				colvarIdEstadoEgreso.IsNullable = true;
				colvarIdEstadoEgreso.IsPrimaryKey = false;
				colvarIdEstadoEgreso.IsForeignKey = false;
				colvarIdEstadoEgreso.IsReadOnly = false;
				colvarIdEstadoEgreso.DefaultSetting = @"";
				colvarIdEstadoEgreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadoEgreso);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "Responsable";
				colvarResponsable.DataType = DbType.AnsiString;
				colvarResponsable.MaxLength = 50;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = true;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				TableSchema.TableColumn colvarConsejeriaAntiConcepcion = new TableSchema.TableColumn(schema);
				colvarConsejeriaAntiConcepcion.ColumnName = "ConsejeriaAntiConcepcion";
				colvarConsejeriaAntiConcepcion.DataType = DbType.Boolean;
				colvarConsejeriaAntiConcepcion.MaxLength = 0;
				colvarConsejeriaAntiConcepcion.AutoIncrement = false;
				colvarConsejeriaAntiConcepcion.IsNullable = true;
				colvarConsejeriaAntiConcepcion.IsPrimaryKey = false;
				colvarConsejeriaAntiConcepcion.IsForeignKey = false;
				colvarConsejeriaAntiConcepcion.IsReadOnly = false;
				colvarConsejeriaAntiConcepcion.DefaultSetting = @"";
				colvarConsejeriaAntiConcepcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsejeriaAntiConcepcion);
				
				TableSchema.TableColumn colvarIdMetodoAnticonceptivoElegido = new TableSchema.TableColumn(schema);
				colvarIdMetodoAnticonceptivoElegido.ColumnName = "idMetodoAnticonceptivoElegido";
				colvarIdMetodoAnticonceptivoElegido.DataType = DbType.Int32;
				colvarIdMetodoAnticonceptivoElegido.MaxLength = 0;
				colvarIdMetodoAnticonceptivoElegido.AutoIncrement = false;
				colvarIdMetodoAnticonceptivoElegido.IsNullable = true;
				colvarIdMetodoAnticonceptivoElegido.IsPrimaryKey = false;
				colvarIdMetodoAnticonceptivoElegido.IsForeignKey = false;
				colvarIdMetodoAnticonceptivoElegido.IsReadOnly = false;
				colvarIdMetodoAnticonceptivoElegido.DefaultSetting = @"";
				colvarIdMetodoAnticonceptivoElegido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMetodoAnticonceptivoElegido);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_EgresoMaterno",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEgresoMaterno")]
		[Bindable(true)]
		public int IdEgresoMaterno 
		{
			get { return GetColumnValue<int>(Columns.IdEgresoMaterno); }
			set { SetColumnValue(Columns.IdEgresoMaterno, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdEmbarazo")]
		[Bindable(true)]
		public int? IdEmbarazo 
		{
			get { return GetColumnValue<int?>(Columns.IdEmbarazo); }
			set { SetColumnValue(Columns.IdEmbarazo, value); }
		}
		  
		[XmlAttribute("FechaHora")]
		[Bindable(true)]
		public DateTime? FechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaHora); }
			set { SetColumnValue(Columns.FechaHora, value); }
		}
		  
		[XmlAttribute("IdTraslado")]
		[Bindable(true)]
		public int? IdTraslado 
		{
			get { return GetColumnValue<int?>(Columns.IdTraslado); }
			set { SetColumnValue(Columns.IdTraslado, value); }
		}
		  
		[XmlAttribute("IdEstadoEgreso")]
		[Bindable(true)]
		public int? IdEstadoEgreso 
		{
			get { return GetColumnValue<int?>(Columns.IdEstadoEgreso); }
			set { SetColumnValue(Columns.IdEstadoEgreso, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		  
		[XmlAttribute("ConsejeriaAntiConcepcion")]
		[Bindable(true)]
		public bool? ConsejeriaAntiConcepcion 
		{
			get { return GetColumnValue<bool?>(Columns.ConsejeriaAntiConcepcion); }
			set { SetColumnValue(Columns.ConsejeriaAntiConcepcion, value); }
		}
		  
		[XmlAttribute("IdMetodoAnticonceptivoElegido")]
		[Bindable(true)]
		public int? IdMetodoAnticonceptivoElegido 
		{
			get { return GetColumnValue<int?>(Columns.IdMetodoAnticonceptivoElegido); }
			set { SetColumnValue(Columns.IdMetodoAnticonceptivoElegido, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprEmbarazo ActiveRecord object related to this AprEgresoMaterno
		/// 
		/// </summary>
		public DalSic.AprEmbarazo AprEmbarazo
		{
			get { return DalSic.AprEmbarazo.FetchByID(this.IdEmbarazo); }
			set { SetColumnValue("idEmbarazo", value.IdEmbarazo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int? varIdEmbarazo,DateTime? varFechaHora,int? varIdTraslado,int? varIdEstadoEgreso,string varResponsable,bool? varConsejeriaAntiConcepcion,int? varIdMetodoAnticonceptivoElegido)
		{
			AprEgresoMaterno item = new AprEgresoMaterno();
			
			item.IdEfector = varIdEfector;
			
			item.IdEmbarazo = varIdEmbarazo;
			
			item.FechaHora = varFechaHora;
			
			item.IdTraslado = varIdTraslado;
			
			item.IdEstadoEgreso = varIdEstadoEgreso;
			
			item.Responsable = varResponsable;
			
			item.ConsejeriaAntiConcepcion = varConsejeriaAntiConcepcion;
			
			item.IdMetodoAnticonceptivoElegido = varIdMetodoAnticonceptivoElegido;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEgresoMaterno,int varIdEfector,int? varIdEmbarazo,DateTime? varFechaHora,int? varIdTraslado,int? varIdEstadoEgreso,string varResponsable,bool? varConsejeriaAntiConcepcion,int? varIdMetodoAnticonceptivoElegido)
		{
			AprEgresoMaterno item = new AprEgresoMaterno();
			
				item.IdEgresoMaterno = varIdEgresoMaterno;
			
				item.IdEfector = varIdEfector;
			
				item.IdEmbarazo = varIdEmbarazo;
			
				item.FechaHora = varFechaHora;
			
				item.IdTraslado = varIdTraslado;
			
				item.IdEstadoEgreso = varIdEstadoEgreso;
			
				item.Responsable = varResponsable;
			
				item.ConsejeriaAntiConcepcion = varConsejeriaAntiConcepcion;
			
				item.IdMetodoAnticonceptivoElegido = varIdMetodoAnticonceptivoElegido;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEgresoMaternoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEmbarazoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHoraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTrasladoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoEgresoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsejeriaAntiConcepcionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMetodoAnticonceptivoElegidoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEgresoMaterno = @"idEgresoMaterno";
			 public static string IdEfector = @"idEfector";
			 public static string IdEmbarazo = @"idEmbarazo";
			 public static string FechaHora = @"FechaHora";
			 public static string IdTraslado = @"idTraslado";
			 public static string IdEstadoEgreso = @"idEstadoEgreso";
			 public static string Responsable = @"Responsable";
			 public static string ConsejeriaAntiConcepcion = @"ConsejeriaAntiConcepcion";
			 public static string IdMetodoAnticonceptivoElegido = @"idMetodoAnticonceptivoElegido";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
