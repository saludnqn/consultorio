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
	/// Strongly-typed collection for the AprEstiloVida class.
	/// </summary>
    [Serializable]
	public partial class AprEstiloVidaCollection : ActiveList<AprEstiloVida, AprEstiloVidaCollection>
	{	   
		public AprEstiloVidaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprEstiloVidaCollection</returns>
		public AprEstiloVidaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprEstiloVida o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_EstiloVida table.
	/// </summary>
	[Serializable]
	public partial class AprEstiloVida : ActiveRecord<AprEstiloVida>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprEstiloVida()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprEstiloVida(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprEstiloVida(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprEstiloVida(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_EstiloVida", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstiloVida = new TableSchema.TableColumn(schema);
				colvarIdEstiloVida.ColumnName = "idEstiloVida";
				colvarIdEstiloVida.DataType = DbType.Int32;
				colvarIdEstiloVida.MaxLength = 0;
				colvarIdEstiloVida.AutoIncrement = true;
				colvarIdEstiloVida.IsNullable = false;
				colvarIdEstiloVida.IsPrimaryKey = true;
				colvarIdEstiloVida.IsForeignKey = false;
				colvarIdEstiloVida.IsReadOnly = false;
				colvarIdEstiloVida.DefaultSetting = @"";
				colvarIdEstiloVida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstiloVida);
				
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
				colvarIdEmbarazo.IsNullable = false;
				colvarIdEmbarazo.IsPrimaryKey = false;
				colvarIdEmbarazo.IsForeignKey = true;
				colvarIdEmbarazo.IsReadOnly = false;
				colvarIdEmbarazo.DefaultSetting = @"";
				
					colvarIdEmbarazo.ForeignKeyTableName = "APR_Embarazo";
				schema.Columns.Add(colvarIdEmbarazo);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "Fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarTrimestre = new TableSchema.TableColumn(schema);
				colvarTrimestre.ColumnName = "Trimestre";
				colvarTrimestre.DataType = DbType.Int32;
				colvarTrimestre.MaxLength = 0;
				colvarTrimestre.AutoIncrement = false;
				colvarTrimestre.IsNullable = false;
				colvarTrimestre.IsPrimaryKey = false;
				colvarTrimestre.IsForeignKey = false;
				colvarTrimestre.IsReadOnly = false;
				colvarTrimestre.DefaultSetting = @"";
				colvarTrimestre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrimestre);
				
				TableSchema.TableColumn colvarIdFactorRiesgoEstiloVida = new TableSchema.TableColumn(schema);
				colvarIdFactorRiesgoEstiloVida.ColumnName = "idFactorRiesgoEstiloVida";
				colvarIdFactorRiesgoEstiloVida.DataType = DbType.Int32;
				colvarIdFactorRiesgoEstiloVida.MaxLength = 0;
				colvarIdFactorRiesgoEstiloVida.AutoIncrement = false;
				colvarIdFactorRiesgoEstiloVida.IsNullable = false;
				colvarIdFactorRiesgoEstiloVida.IsPrimaryKey = false;
				colvarIdFactorRiesgoEstiloVida.IsForeignKey = true;
				colvarIdFactorRiesgoEstiloVida.IsReadOnly = false;
				colvarIdFactorRiesgoEstiloVida.DefaultSetting = @"";
				
					colvarIdFactorRiesgoEstiloVida.ForeignKeyTableName = "APR_FactorRiesgoEstiloVida";
				schema.Columns.Add(colvarIdFactorRiesgoEstiloVida);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_EstiloVida",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstiloVida")]
		[Bindable(true)]
		public int IdEstiloVida 
		{
			get { return GetColumnValue<int>(Columns.IdEstiloVida); }
			set { SetColumnValue(Columns.IdEstiloVida, value); }
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
		public int IdEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdEmbarazo); }
			set { SetColumnValue(Columns.IdEmbarazo, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Trimestre")]
		[Bindable(true)]
		public int Trimestre 
		{
			get { return GetColumnValue<int>(Columns.Trimestre); }
			set { SetColumnValue(Columns.Trimestre, value); }
		}
		  
		[XmlAttribute("IdFactorRiesgoEstiloVida")]
		[Bindable(true)]
		public int IdFactorRiesgoEstiloVida 
		{
			get { return GetColumnValue<int>(Columns.IdFactorRiesgoEstiloVida); }
			set { SetColumnValue(Columns.IdFactorRiesgoEstiloVida, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprEmbarazo ActiveRecord object related to this AprEstiloVida
		/// 
		/// </summary>
		public DalSic.AprEmbarazo AprEmbarazo
		{
			get { return DalSic.AprEmbarazo.FetchByID(this.IdEmbarazo); }
			set { SetColumnValue("idEmbarazo", value.IdEmbarazo); }
		}
		
		
		/// <summary>
		/// Returns a AprFactorRiesgoEstiloVida ActiveRecord object related to this AprEstiloVida
		/// 
		/// </summary>
		public DalSic.AprFactorRiesgoEstiloVida AprFactorRiesgoEstiloVida
		{
			get { return DalSic.AprFactorRiesgoEstiloVida.FetchByID(this.IdFactorRiesgoEstiloVida); }
			set { SetColumnValue("idFactorRiesgoEstiloVida", value.IdFactorRiesgoEstiloVida); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdEmbarazo,DateTime varFecha,int varTrimestre,int varIdFactorRiesgoEstiloVida)
		{
			AprEstiloVida item = new AprEstiloVida();
			
			item.IdEfector = varIdEfector;
			
			item.IdEmbarazo = varIdEmbarazo;
			
			item.Fecha = varFecha;
			
			item.Trimestre = varTrimestre;
			
			item.IdFactorRiesgoEstiloVida = varIdFactorRiesgoEstiloVida;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstiloVida,int varIdEfector,int varIdEmbarazo,DateTime varFecha,int varTrimestre,int varIdFactorRiesgoEstiloVida)
		{
			AprEstiloVida item = new AprEstiloVida();
			
				item.IdEstiloVida = varIdEstiloVida;
			
				item.IdEfector = varIdEfector;
			
				item.IdEmbarazo = varIdEmbarazo;
			
				item.Fecha = varFecha;
			
				item.Trimestre = varTrimestre;
			
				item.IdFactorRiesgoEstiloVida = varIdFactorRiesgoEstiloVida;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstiloVidaColumn
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
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TrimestreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFactorRiesgoEstiloVidaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstiloVida = @"idEstiloVida";
			 public static string IdEfector = @"idEfector";
			 public static string IdEmbarazo = @"idEmbarazo";
			 public static string Fecha = @"Fecha";
			 public static string Trimestre = @"Trimestre";
			 public static string IdFactorRiesgoEstiloVida = @"idFactorRiesgoEstiloVida";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
