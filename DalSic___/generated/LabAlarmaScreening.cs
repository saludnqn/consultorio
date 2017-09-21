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
	/// Strongly-typed collection for the LabAlarmaScreening class.
	/// </summary>
    [Serializable]
	public partial class LabAlarmaScreeningCollection : ActiveList<LabAlarmaScreening, LabAlarmaScreeningCollection>
	{	   
		public LabAlarmaScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabAlarmaScreeningCollection</returns>
		public LabAlarmaScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabAlarmaScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_AlarmaScreening table.
	/// </summary>
	[Serializable]
	public partial class LabAlarmaScreening : ActiveRecord<LabAlarmaScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabAlarmaScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabAlarmaScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabAlarmaScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabAlarmaScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_AlarmaScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAlarmaScreening = new TableSchema.TableColumn(schema);
				colvarIdAlarmaScreening.ColumnName = "idAlarmaScreening";
				colvarIdAlarmaScreening.DataType = DbType.Int32;
				colvarIdAlarmaScreening.MaxLength = 0;
				colvarIdAlarmaScreening.AutoIncrement = true;
				colvarIdAlarmaScreening.IsNullable = false;
				colvarIdAlarmaScreening.IsPrimaryKey = true;
				colvarIdAlarmaScreening.IsForeignKey = false;
				colvarIdAlarmaScreening.IsReadOnly = false;
				colvarIdAlarmaScreening.DefaultSetting = @"";
				colvarIdAlarmaScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAlarmaScreening);
				
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
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 500;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.Int32;
				colvarIdUsuarioRegistro.MaxLength = 0;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = false;
				colvarIdUsuarioRegistro.IsPrimaryKey = false;
				colvarIdUsuarioRegistro.IsForeignKey = false;
				colvarIdUsuarioRegistro.IsReadOnly = false;
				colvarIdUsuarioRegistro.DefaultSetting = @"";
				colvarIdUsuarioRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRegistro);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				colvarFechaRegistro.DefaultSetting = @"";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_AlarmaScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAlarmaScreening")]
		[Bindable(true)]
		public int IdAlarmaScreening 
		{
			get { return GetColumnValue<int>(Columns.IdAlarmaScreening); }
			set { SetColumnValue(Columns.IdAlarmaScreening, value); }
		}
		  
		[XmlAttribute("IdSolicitudScreening")]
		[Bindable(true)]
		public int IdSolicitudScreening 
		{
			get { return GetColumnValue<int>(Columns.IdSolicitudScreening); }
			set { SetColumnValue(Columns.IdSolicitudScreening, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public int IdUsuarioRegistro 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabSolicitudScreening ActiveRecord object related to this LabAlarmaScreening
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
		public static void Insert(int varIdSolicitudScreening,string varDescripcion,int varIdUsuarioRegistro,DateTime varFechaRegistro)
		{
			LabAlarmaScreening item = new LabAlarmaScreening();
			
			item.IdSolicitudScreening = varIdSolicitudScreening;
			
			item.Descripcion = varDescripcion;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.FechaRegistro = varFechaRegistro;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAlarmaScreening,int varIdSolicitudScreening,string varDescripcion,int varIdUsuarioRegistro,DateTime varFechaRegistro)
		{
			LabAlarmaScreening item = new LabAlarmaScreening();
			
				item.IdAlarmaScreening = varIdAlarmaScreening;
			
				item.IdSolicitudScreening = varIdSolicitudScreening;
			
				item.Descripcion = varDescripcion;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
				item.FechaRegistro = varFechaRegistro;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAlarmaScreeningColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAlarmaScreening = @"idAlarmaScreening";
			 public static string IdSolicitudScreening = @"idSolicitudScreening";
			 public static string Descripcion = @"descripcion";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
			 public static string FechaRegistro = @"fechaRegistro";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
