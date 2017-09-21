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
	/// Strongly-typed collection for the AprAntecedentePerinatalNacimiento class.
	/// </summary>
    [Serializable]
	public partial class AprAntecedentePerinatalNacimientoCollection : ActiveList<AprAntecedentePerinatalNacimiento, AprAntecedentePerinatalNacimientoCollection>
	{	   
		public AprAntecedentePerinatalNacimientoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAntecedentePerinatalNacimientoCollection</returns>
		public AprAntecedentePerinatalNacimientoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAntecedentePerinatalNacimiento o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AntecedentePerinatalNacimiento table.
	/// </summary>
	[Serializable]
	public partial class AprAntecedentePerinatalNacimiento : ActiveRecord<AprAntecedentePerinatalNacimiento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAntecedentePerinatalNacimiento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAntecedentePerinatalNacimiento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAntecedentePerinatalNacimiento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAntecedentePerinatalNacimiento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AntecedentePerinatalNacimiento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAntecedentePerinatalNacimiento = new TableSchema.TableColumn(schema);
				colvarIdAntecedentePerinatalNacimiento.ColumnName = "idAntecedentePerinatalNacimiento";
				colvarIdAntecedentePerinatalNacimiento.DataType = DbType.Int32;
				colvarIdAntecedentePerinatalNacimiento.MaxLength = 0;
				colvarIdAntecedentePerinatalNacimiento.AutoIncrement = true;
				colvarIdAntecedentePerinatalNacimiento.IsNullable = false;
				colvarIdAntecedentePerinatalNacimiento.IsPrimaryKey = true;
				colvarIdAntecedentePerinatalNacimiento.IsForeignKey = false;
				colvarIdAntecedentePerinatalNacimiento.IsReadOnly = false;
				colvarIdAntecedentePerinatalNacimiento.DefaultSetting = @"";
				colvarIdAntecedentePerinatalNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAntecedentePerinatalNacimiento);
				
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
				
				TableSchema.TableColumn colvarIdAntecedentePerinatal = new TableSchema.TableColumn(schema);
				colvarIdAntecedentePerinatal.ColumnName = "idAntecedentePerinatal";
				colvarIdAntecedentePerinatal.DataType = DbType.Int32;
				colvarIdAntecedentePerinatal.MaxLength = 0;
				colvarIdAntecedentePerinatal.AutoIncrement = false;
				colvarIdAntecedentePerinatal.IsNullable = false;
				colvarIdAntecedentePerinatal.IsPrimaryKey = false;
				colvarIdAntecedentePerinatal.IsForeignKey = true;
				colvarIdAntecedentePerinatal.IsReadOnly = false;
				colvarIdAntecedentePerinatal.DefaultSetting = @"";
				
					colvarIdAntecedentePerinatal.ForeignKeyTableName = "APR_AntecedentePerinatal";
				schema.Columns.Add(colvarIdAntecedentePerinatal);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "Peso";
				colvarPeso.DataType = DbType.Double;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = false;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarNacidoVivo = new TableSchema.TableColumn(schema);
				colvarNacidoVivo.ColumnName = "NacidoVivo";
				colvarNacidoVivo.DataType = DbType.Boolean;
				colvarNacidoVivo.MaxLength = 0;
				colvarNacidoVivo.AutoIncrement = false;
				colvarNacidoVivo.IsNullable = false;
				colvarNacidoVivo.IsPrimaryKey = false;
				colvarNacidoVivo.IsForeignKey = false;
				colvarNacidoVivo.IsReadOnly = false;
				colvarNacidoVivo.DefaultSetting = @"";
				colvarNacidoVivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNacidoVivo);
				
				TableSchema.TableColumn colvarFechaFallecimiento = new TableSchema.TableColumn(schema);
				colvarFechaFallecimiento.ColumnName = "FechaFallecimiento";
				colvarFechaFallecimiento.DataType = DbType.DateTime;
				colvarFechaFallecimiento.MaxLength = 0;
				colvarFechaFallecimiento.AutoIncrement = false;
				colvarFechaFallecimiento.IsNullable = true;
				colvarFechaFallecimiento.IsPrimaryKey = false;
				colvarFechaFallecimiento.IsForeignKey = false;
				colvarFechaFallecimiento.IsReadOnly = false;
				colvarFechaFallecimiento.DefaultSetting = @"";
				colvarFechaFallecimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFallecimiento);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_AntecedentePerinatalNacimiento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAntecedentePerinatalNacimiento")]
		[Bindable(true)]
		public int IdAntecedentePerinatalNacimiento 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedentePerinatalNacimiento); }
			set { SetColumnValue(Columns.IdAntecedentePerinatalNacimiento, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdAntecedentePerinatal")]
		[Bindable(true)]
		public int IdAntecedentePerinatal 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedentePerinatal); }
			set { SetColumnValue(Columns.IdAntecedentePerinatal, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public double Peso 
		{
			get { return GetColumnValue<double>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("NacidoVivo")]
		[Bindable(true)]
		public bool NacidoVivo 
		{
			get { return GetColumnValue<bool>(Columns.NacidoVivo); }
			set { SetColumnValue(Columns.NacidoVivo, value); }
		}
		  
		[XmlAttribute("FechaFallecimiento")]
		[Bindable(true)]
		public DateTime? FechaFallecimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaFallecimiento); }
			set { SetColumnValue(Columns.FechaFallecimiento, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprAntecedentePerinatal ActiveRecord object related to this AprAntecedentePerinatalNacimiento
		/// 
		/// </summary>
		public DalSic.AprAntecedentePerinatal AprAntecedentePerinatal
		{
			get { return DalSic.AprAntecedentePerinatal.FetchByID(this.IdAntecedentePerinatal); }
			set { SetColumnValue("idAntecedentePerinatal", value.IdAntecedentePerinatal); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdAntecedentePerinatal,double varPeso,bool varNacidoVivo,DateTime? varFechaFallecimiento)
		{
			AprAntecedentePerinatalNacimiento item = new AprAntecedentePerinatalNacimiento();
			
			item.IdEfector = varIdEfector;
			
			item.IdAntecedentePerinatal = varIdAntecedentePerinatal;
			
			item.Peso = varPeso;
			
			item.NacidoVivo = varNacidoVivo;
			
			item.FechaFallecimiento = varFechaFallecimiento;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAntecedentePerinatalNacimiento,int varIdEfector,int varIdAntecedentePerinatal,double varPeso,bool varNacidoVivo,DateTime? varFechaFallecimiento)
		{
			AprAntecedentePerinatalNacimiento item = new AprAntecedentePerinatalNacimiento();
			
				item.IdAntecedentePerinatalNacimiento = varIdAntecedentePerinatalNacimiento;
			
				item.IdEfector = varIdEfector;
			
				item.IdAntecedentePerinatal = varIdAntecedentePerinatal;
			
				item.Peso = varPeso;
			
				item.NacidoVivo = varNacidoVivo;
			
				item.FechaFallecimiento = varFechaFallecimiento;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAntecedentePerinatalNacimientoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAntecedentePerinatalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NacidoVivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFallecimientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAntecedentePerinatalNacimiento = @"idAntecedentePerinatalNacimiento";
			 public static string IdEfector = @"idEfector";
			 public static string IdAntecedentePerinatal = @"idAntecedentePerinatal";
			 public static string Peso = @"Peso";
			 public static string NacidoVivo = @"NacidoVivo";
			 public static string FechaFallecimiento = @"FechaFallecimiento";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
