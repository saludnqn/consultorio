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
	/// Strongly-typed collection for the LabSolicitudScreeningRepeticion class.
	/// </summary>
    [Serializable]
	public partial class LabSolicitudScreeningRepeticionCollection : ActiveList<LabSolicitudScreeningRepeticion, LabSolicitudScreeningRepeticionCollection>
	{	   
		public LabSolicitudScreeningRepeticionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabSolicitudScreeningRepeticionCollection</returns>
		public LabSolicitudScreeningRepeticionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabSolicitudScreeningRepeticion o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_SolicitudScreeningRepeticion table.
	/// </summary>
	[Serializable]
	public partial class LabSolicitudScreeningRepeticion : ActiveRecord<LabSolicitudScreeningRepeticion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabSolicitudScreeningRepeticion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabSolicitudScreeningRepeticion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabSolicitudScreeningRepeticion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabSolicitudScreeningRepeticion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_SolicitudScreeningRepeticion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSolicitudScreeningRepeticion = new TableSchema.TableColumn(schema);
				colvarIdSolicitudScreeningRepeticion.ColumnName = "idSolicitudScreeningRepeticion";
				colvarIdSolicitudScreeningRepeticion.DataType = DbType.Int32;
				colvarIdSolicitudScreeningRepeticion.MaxLength = 0;
				colvarIdSolicitudScreeningRepeticion.AutoIncrement = true;
				colvarIdSolicitudScreeningRepeticion.IsNullable = false;
				colvarIdSolicitudScreeningRepeticion.IsPrimaryKey = true;
				colvarIdSolicitudScreeningRepeticion.IsForeignKey = false;
				colvarIdSolicitudScreeningRepeticion.IsReadOnly = false;
				colvarIdSolicitudScreeningRepeticion.DefaultSetting = @"";
				colvarIdSolicitudScreeningRepeticion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSolicitudScreeningRepeticion);
				
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
				
				TableSchema.TableColumn colvarIdMotivoRepeticion = new TableSchema.TableColumn(schema);
				colvarIdMotivoRepeticion.ColumnName = "idMotivoRepeticion";
				colvarIdMotivoRepeticion.DataType = DbType.Int32;
				colvarIdMotivoRepeticion.MaxLength = 0;
				colvarIdMotivoRepeticion.AutoIncrement = false;
				colvarIdMotivoRepeticion.IsNullable = false;
				colvarIdMotivoRepeticion.IsPrimaryKey = false;
				colvarIdMotivoRepeticion.IsForeignKey = true;
				colvarIdMotivoRepeticion.IsReadOnly = false;
				colvarIdMotivoRepeticion.DefaultSetting = @"";
				
					colvarIdMotivoRepeticion.ForeignKeyTableName = "LAB_MotivoRepeticionScreening";
				schema.Columns.Add(colvarIdMotivoRepeticion);
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fechaAlta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = false;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				colvarFechaAlta.DefaultSetting = @"";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.Int32;
				colvarIdUsuarioRegistro.MaxLength = 0;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = true;
				colvarIdUsuarioRegistro.IsPrimaryKey = false;
				colvarIdUsuarioRegistro.IsForeignKey = false;
				colvarIdUsuarioRegistro.IsReadOnly = false;
				colvarIdUsuarioRegistro.DefaultSetting = @"";
				colvarIdUsuarioRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRegistro);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_SolicitudScreeningRepeticion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSolicitudScreeningRepeticion")]
		[Bindable(true)]
		public int IdSolicitudScreeningRepeticion 
		{
			get { return GetColumnValue<int>(Columns.IdSolicitudScreeningRepeticion); }
			set { SetColumnValue(Columns.IdSolicitudScreeningRepeticion, value); }
		}
		  
		[XmlAttribute("IdSolicitudScreening")]
		[Bindable(true)]
		public int IdSolicitudScreening 
		{
			get { return GetColumnValue<int>(Columns.IdSolicitudScreening); }
			set { SetColumnValue(Columns.IdSolicitudScreening, value); }
		}
		  
		[XmlAttribute("IdMotivoRepeticion")]
		[Bindable(true)]
		public int IdMotivoRepeticion 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoRepeticion); }
			set { SetColumnValue(Columns.IdMotivoRepeticion, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime FechaAlta 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public int? IdUsuarioRegistro 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabMotivoRepeticionScreening ActiveRecord object related to this LabSolicitudScreeningRepeticion
		/// 
		/// </summary>
		public DalSic.LabMotivoRepeticionScreening LabMotivoRepeticionScreening
		{
			get { return DalSic.LabMotivoRepeticionScreening.FetchByID(this.IdMotivoRepeticion); }
			set { SetColumnValue("idMotivoRepeticion", value.IdMotivoRepeticionScreening); }
		}
		
		
		/// <summary>
		/// Returns a LabSolicitudScreening ActiveRecord object related to this LabSolicitudScreeningRepeticion
		/// 
		/// </summary>
		public DalSic.LabSolicitudScreening LabSolicitudScreening
		{
			get { return DalSic.LabSolicitudScreening.FetchByID(this.IdSolicitudScreening); }
			set { SetColumnValue("idSolicitudScreening", value.IdSolicitudScreening); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdSolicitudScreening,int varIdMotivoRepeticion,DateTime varFechaAlta,int? varIdUsuarioRegistro)
		{
			LabSolicitudScreeningRepeticion item = new LabSolicitudScreeningRepeticion();
			
			item.IdSolicitudScreening = varIdSolicitudScreening;
			
			item.IdMotivoRepeticion = varIdMotivoRepeticion;
			
			item.FechaAlta = varFechaAlta;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSolicitudScreeningRepeticion,int varIdSolicitudScreening,int varIdMotivoRepeticion,DateTime varFechaAlta,int? varIdUsuarioRegistro)
		{
			LabSolicitudScreeningRepeticion item = new LabSolicitudScreeningRepeticion();
			
				item.IdSolicitudScreeningRepeticion = varIdSolicitudScreeningRepeticion;
			
				item.IdSolicitudScreening = varIdSolicitudScreening;
			
				item.IdMotivoRepeticion = varIdMotivoRepeticion;
			
				item.FechaAlta = varFechaAlta;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningRepeticionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoRepeticionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSolicitudScreeningRepeticion = @"idSolicitudScreeningRepeticion";
			 public static string IdSolicitudScreening = @"idSolicitudScreening";
			 public static string IdMotivoRepeticion = @"idMotivoRepeticion";
			 public static string FechaAlta = @"fechaAlta";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
