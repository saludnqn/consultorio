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
	/// Strongly-typed collection for the AprAlertaControlMenor class.
	/// </summary>
    [Serializable]
	public partial class AprAlertaControlMenorCollection : ActiveList<AprAlertaControlMenor, AprAlertaControlMenorCollection>
	{	   
		public AprAlertaControlMenorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAlertaControlMenorCollection</returns>
		public AprAlertaControlMenorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAlertaControlMenor o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AlertaControlMenor table.
	/// </summary>
	[Serializable]
	public partial class AprAlertaControlMenor : ActiveRecord<AprAlertaControlMenor>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAlertaControlMenor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAlertaControlMenor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAlertaControlMenor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAlertaControlMenor(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AlertaControlMenor", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAlerta = new TableSchema.TableColumn(schema);
				colvarIdAlerta.ColumnName = "idAlerta";
				colvarIdAlerta.DataType = DbType.Int32;
				colvarIdAlerta.MaxLength = 0;
				colvarIdAlerta.AutoIncrement = true;
				colvarIdAlerta.IsNullable = false;
				colvarIdAlerta.IsPrimaryKey = true;
				colvarIdAlerta.IsForeignKey = false;
				colvarIdAlerta.IsReadOnly = false;
				colvarIdAlerta.DefaultSetting = @"";
				colvarIdAlerta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAlerta);
				
				TableSchema.TableColumn colvarIdCalendarioVisitas = new TableSchema.TableColumn(schema);
				colvarIdCalendarioVisitas.ColumnName = "idCalendarioVisitas";
				colvarIdCalendarioVisitas.DataType = DbType.Int32;
				colvarIdCalendarioVisitas.MaxLength = 0;
				colvarIdCalendarioVisitas.AutoIncrement = false;
				colvarIdCalendarioVisitas.IsNullable = false;
				colvarIdCalendarioVisitas.IsPrimaryKey = false;
				colvarIdCalendarioVisitas.IsForeignKey = true;
				colvarIdCalendarioVisitas.IsReadOnly = false;
				colvarIdCalendarioVisitas.DefaultSetting = @"";
				
					colvarIdCalendarioVisitas.ForeignKeyTableName = "APR_CalendarioVisitas";
				schema.Columns.Add(colvarIdCalendarioVisitas);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "Descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarComprobador = new TableSchema.TableColumn(schema);
				colvarComprobador.ColumnName = "Comprobador";
				colvarComprobador.DataType = DbType.AnsiString;
				colvarComprobador.MaxLength = -1;
				colvarComprobador.AutoIncrement = false;
				colvarComprobador.IsNullable = false;
				colvarComprobador.IsPrimaryKey = false;
				colvarComprobador.IsForeignKey = false;
				colvarComprobador.IsReadOnly = false;
				colvarComprobador.DefaultSetting = @"";
				colvarComprobador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComprobador);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_AlertaControlMenor",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAlerta")]
		[Bindable(true)]
		public int IdAlerta 
		{
			get { return GetColumnValue<int>(Columns.IdAlerta); }
			set { SetColumnValue(Columns.IdAlerta, value); }
		}
		  
		[XmlAttribute("IdCalendarioVisitas")]
		[Bindable(true)]
		public int IdCalendarioVisitas 
		{
			get { return GetColumnValue<int>(Columns.IdCalendarioVisitas); }
			set { SetColumnValue(Columns.IdCalendarioVisitas, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Comprobador")]
		[Bindable(true)]
		public string Comprobador 
		{
			get { return GetColumnValue<string>(Columns.Comprobador); }
			set { SetColumnValue(Columns.Comprobador, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprCalendarioVisita ActiveRecord object related to this AprAlertaControlMenor
		/// 
		/// </summary>
		public DalSic.AprCalendarioVisita AprCalendarioVisita
		{
			get { return DalSic.AprCalendarioVisita.FetchByID(this.IdCalendarioVisitas); }
			set { SetColumnValue("idCalendarioVisitas", value.IdCalendarioVisitas); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdCalendarioVisitas,string varDescripcion,string varComprobador,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprAlertaControlMenor item = new AprAlertaControlMenor();
			
			item.IdCalendarioVisitas = varIdCalendarioVisitas;
			
			item.Descripcion = varDescripcion;
			
			item.Comprobador = varComprobador;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAlerta,int varIdCalendarioVisitas,string varDescripcion,string varComprobador,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprAlertaControlMenor item = new AprAlertaControlMenor();
			
				item.IdAlerta = varIdAlerta;
			
				item.IdCalendarioVisitas = varIdCalendarioVisitas;
			
				item.Descripcion = varDescripcion;
			
				item.Comprobador = varComprobador;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAlertaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCalendarioVisitasColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ComprobadorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAlerta = @"idAlerta";
			 public static string IdCalendarioVisitas = @"idCalendarioVisitas";
			 public static string Descripcion = @"Descripcion";
			 public static string Comprobador = @"Comprobador";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
