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
	/// Strongly-typed collection for the AprControlNiñoSanoOdontologico class.
	/// </summary>
    [Serializable]
	public partial class AprControlNiñoSanoOdontologicoCollection : ActiveList<AprControlNiñoSanoOdontologico, AprControlNiñoSanoOdontologicoCollection>
	{	   
		public AprControlNiñoSanoOdontologicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprControlNiñoSanoOdontologicoCollection</returns>
		public AprControlNiñoSanoOdontologicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprControlNiñoSanoOdontologico o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ControlNiñoSanoOdontologico table.
	/// </summary>
	[Serializable]
	public partial class AprControlNiñoSanoOdontologico : ActiveRecord<AprControlNiñoSanoOdontologico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprControlNiñoSanoOdontologico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprControlNiñoSanoOdontologico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprControlNiñoSanoOdontologico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprControlNiñoSanoOdontologico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ControlNiñoSanoOdontologico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdControlOdontologico = new TableSchema.TableColumn(schema);
				colvarIdControlOdontologico.ColumnName = "idControlOdontologico";
				colvarIdControlOdontologico.DataType = DbType.Int32;
				colvarIdControlOdontologico.MaxLength = 0;
				colvarIdControlOdontologico.AutoIncrement = true;
				colvarIdControlOdontologico.IsNullable = false;
				colvarIdControlOdontologico.IsPrimaryKey = true;
				colvarIdControlOdontologico.IsForeignKey = false;
				colvarIdControlOdontologico.IsReadOnly = false;
				colvarIdControlOdontologico.DefaultSetting = @"";
				colvarIdControlOdontologico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdControlOdontologico);
				
				TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
				colvarIdControlNiñoSano.DataType = DbType.Int32;
				colvarIdControlNiñoSano.MaxLength = 0;
				colvarIdControlNiñoSano.AutoIncrement = false;
				colvarIdControlNiñoSano.IsNullable = false;
				colvarIdControlNiñoSano.IsPrimaryKey = false;
				colvarIdControlNiñoSano.IsForeignKey = true;
				colvarIdControlNiñoSano.IsReadOnly = false;
				colvarIdControlNiñoSano.DefaultSetting = @"";
				
					colvarIdControlNiñoSano.ForeignKeyTableName = "APR_ControlNiñoSano";
				schema.Columns.Add(colvarIdControlNiñoSano);
				
				TableSchema.TableColumn colvarProfesional = new TableSchema.TableColumn(schema);
				colvarProfesional.ColumnName = "Profesional";
				colvarProfesional.DataType = DbType.AnsiString;
				colvarProfesional.MaxLength = 50;
				colvarProfesional.AutoIncrement = false;
				colvarProfesional.IsNullable = false;
				colvarProfesional.IsPrimaryKey = false;
				colvarProfesional.IsForeignKey = false;
				colvarProfesional.IsReadOnly = false;
				colvarProfesional.DefaultSetting = @"";
				colvarProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProfesional);
				
				TableSchema.TableColumn colvarIdDiagnosticoControlOdontologico = new TableSchema.TableColumn(schema);
				colvarIdDiagnosticoControlOdontologico.ColumnName = "idDiagnosticoControlOdontologico";
				colvarIdDiagnosticoControlOdontologico.DataType = DbType.Int32;
				colvarIdDiagnosticoControlOdontologico.MaxLength = 0;
				colvarIdDiagnosticoControlOdontologico.AutoIncrement = false;
				colvarIdDiagnosticoControlOdontologico.IsNullable = false;
				colvarIdDiagnosticoControlOdontologico.IsPrimaryKey = false;
				colvarIdDiagnosticoControlOdontologico.IsForeignKey = true;
				colvarIdDiagnosticoControlOdontologico.IsReadOnly = false;
				colvarIdDiagnosticoControlOdontologico.DefaultSetting = @"";
				
					colvarIdDiagnosticoControlOdontologico.ForeignKeyTableName = "APR_DiagnosticoControlOdontologico";
				schema.Columns.Add(colvarIdDiagnosticoControlOdontologico);
				
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
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "Observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = -1;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = true;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				colvarObservacion.DefaultSetting = @"";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ControlNiñoSanoOdontologico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdControlOdontologico")]
		[Bindable(true)]
		public int IdControlOdontologico 
		{
			get { return GetColumnValue<int>(Columns.IdControlOdontologico); }
			set { SetColumnValue(Columns.IdControlOdontologico, value); }
		}
		  
		[XmlAttribute("IdControlNiñoSano")]
		[Bindable(true)]
		public int IdControlNiñoSano 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSano); }
			set { SetColumnValue(Columns.IdControlNiñoSano, value); }
		}
		  
		[XmlAttribute("Profesional")]
		[Bindable(true)]
		public string Profesional 
		{
			get { return GetColumnValue<string>(Columns.Profesional); }
			set { SetColumnValue(Columns.Profesional, value); }
		}
		  
		[XmlAttribute("IdDiagnosticoControlOdontologico")]
		[Bindable(true)]
		public int IdDiagnosticoControlOdontologico 
		{
			get { return GetColumnValue<int>(Columns.IdDiagnosticoControlOdontologico); }
			set { SetColumnValue(Columns.IdDiagnosticoControlOdontologico, value); }
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
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprControlNiñoSano ActiveRecord object related to this AprControlNiñoSanoOdontologico
		/// 
		/// </summary>
		public DalSic.AprControlNiñoSano AprControlNiñoSano
		{
			get { return DalSic.AprControlNiñoSano.FetchByID(this.IdControlNiñoSano); }
			set { SetColumnValue("idControlNiñoSano", value.IdControlNiñoSano); }
		}
		
		
		/// <summary>
		/// Returns a AprDiagnosticoControlOdontologico ActiveRecord object related to this AprControlNiñoSanoOdontologico
		/// 
		/// </summary>
		public DalSic.AprDiagnosticoControlOdontologico AprDiagnosticoControlOdontologico
		{
			get { return DalSic.AprDiagnosticoControlOdontologico.FetchByID(this.IdDiagnosticoControlOdontologico); }
			set { SetColumnValue("idDiagnosticoControlOdontologico", value.IdDiagnosticoControlOdontologico); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdControlNiñoSano,string varProfesional,int varIdDiagnosticoControlOdontologico,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,string varObservacion)
		{
			AprControlNiñoSanoOdontologico item = new AprControlNiñoSanoOdontologico();
			
			item.IdControlNiñoSano = varIdControlNiñoSano;
			
			item.Profesional = varProfesional;
			
			item.IdDiagnosticoControlOdontologico = varIdDiagnosticoControlOdontologico;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Observacion = varObservacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdControlOdontologico,int varIdControlNiñoSano,string varProfesional,int varIdDiagnosticoControlOdontologico,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,string varObservacion)
		{
			AprControlNiñoSanoOdontologico item = new AprControlNiñoSanoOdontologico();
			
				item.IdControlOdontologico = varIdControlOdontologico;
			
				item.IdControlNiñoSano = varIdControlNiñoSano;
			
				item.Profesional = varProfesional;
			
				item.IdDiagnosticoControlOdontologico = varIdDiagnosticoControlOdontologico;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Observacion = varObservacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdControlOdontologicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProfesionalColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDiagnosticoControlOdontologicoColumn
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
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdControlOdontologico = @"idControlOdontologico";
			 public static string IdControlNiñoSano = @"idControlNiñoSano";
			 public static string Profesional = @"Profesional";
			 public static string IdDiagnosticoControlOdontologico = @"idDiagnosticoControlOdontologico";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string Observacion = @"Observacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
