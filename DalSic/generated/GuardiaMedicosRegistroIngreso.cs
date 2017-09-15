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
	/// Strongly-typed collection for the GuardiaMedicosRegistroIngreso class.
	/// </summary>
    [Serializable]
	public partial class GuardiaMedicosRegistroIngresoCollection : ActiveList<GuardiaMedicosRegistroIngreso, GuardiaMedicosRegistroIngresoCollection>
	{	   
		public GuardiaMedicosRegistroIngresoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaMedicosRegistroIngresoCollection</returns>
		public GuardiaMedicosRegistroIngresoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaMedicosRegistroIngreso o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Medicos_registroIngreso table.
	/// </summary>
	[Serializable]
	public partial class GuardiaMedicosRegistroIngreso : ActiveRecord<GuardiaMedicosRegistroIngreso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaMedicosRegistroIngreso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaMedicosRegistroIngreso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaMedicosRegistroIngreso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaMedicosRegistroIngreso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Medicos_registroIngreso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdUser = new TableSchema.TableColumn(schema);
				colvarIdUser.ColumnName = "id_user";
				colvarIdUser.DataType = DbType.Int32;
				colvarIdUser.MaxLength = 0;
				colvarIdUser.AutoIncrement = false;
				colvarIdUser.IsNullable = false;
				colvarIdUser.IsPrimaryKey = false;
				colvarIdUser.IsForeignKey = false;
				colvarIdUser.IsReadOnly = false;
				colvarIdUser.DefaultSetting = @"";
				colvarIdUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUser);
				
				TableSchema.TableColumn colvarIdMedico = new TableSchema.TableColumn(schema);
				colvarIdMedico.ColumnName = "id_medico";
				colvarIdMedico.DataType = DbType.Int32;
				colvarIdMedico.MaxLength = 0;
				colvarIdMedico.AutoIncrement = false;
				colvarIdMedico.IsNullable = false;
				colvarIdMedico.IsPrimaryKey = false;
				colvarIdMedico.IsForeignKey = false;
				colvarIdMedico.IsReadOnly = false;
				colvarIdMedico.DefaultSetting = @"";
				colvarIdMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedico);
				
				TableSchema.TableColumn colvarFechaCreacion = new TableSchema.TableColumn(schema);
				colvarFechaCreacion.ColumnName = "fechaCreacion";
				colvarFechaCreacion.DataType = DbType.DateTime;
				colvarFechaCreacion.MaxLength = 0;
				colvarFechaCreacion.AutoIncrement = false;
				colvarFechaCreacion.IsNullable = false;
				colvarFechaCreacion.IsPrimaryKey = false;
				colvarFechaCreacion.IsForeignKey = false;
				colvarFechaCreacion.IsReadOnly = false;
				colvarFechaCreacion.DefaultSetting = @"";
				colvarFechaCreacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCreacion);
				
				TableSchema.TableColumn colvarFechaDesde = new TableSchema.TableColumn(schema);
				colvarFechaDesde.ColumnName = "fechaDesde";
				colvarFechaDesde.DataType = DbType.DateTime;
				colvarFechaDesde.MaxLength = 0;
				colvarFechaDesde.AutoIncrement = false;
				colvarFechaDesde.IsNullable = false;
				colvarFechaDesde.IsPrimaryKey = false;
				colvarFechaDesde.IsForeignKey = false;
				colvarFechaDesde.IsReadOnly = false;
				colvarFechaDesde.DefaultSetting = @"";
				colvarFechaDesde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDesde);
				
				TableSchema.TableColumn colvarFechaHasta = new TableSchema.TableColumn(schema);
				colvarFechaHasta.ColumnName = "fechaHasta";
				colvarFechaHasta.DataType = DbType.DateTime;
				colvarFechaHasta.MaxLength = 0;
				colvarFechaHasta.AutoIncrement = false;
				colvarFechaHasta.IsNullable = false;
				colvarFechaHasta.IsPrimaryKey = false;
				colvarFechaHasta.IsForeignKey = false;
				colvarFechaHasta.IsReadOnly = false;
				colvarFechaHasta.DefaultSetting = @"";
				colvarFechaHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHasta);
				
				TableSchema.TableColumn colvarFechaRecordatorio = new TableSchema.TableColumn(schema);
				colvarFechaRecordatorio.ColumnName = "fechaRecordatorio";
				colvarFechaRecordatorio.DataType = DbType.DateTime;
				colvarFechaRecordatorio.MaxLength = 0;
				colvarFechaRecordatorio.AutoIncrement = false;
				colvarFechaRecordatorio.IsNullable = false;
				colvarFechaRecordatorio.IsPrimaryKey = false;
				colvarFechaRecordatorio.IsForeignKey = false;
				colvarFechaRecordatorio.IsReadOnly = false;
				colvarFechaRecordatorio.DefaultSetting = @"";
				colvarFechaRecordatorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecordatorio);
				
				TableSchema.TableColumn colvarFueImpresa = new TableSchema.TableColumn(schema);
				colvarFueImpresa.ColumnName = "fueImpresa";
				colvarFueImpresa.DataType = DbType.Boolean;
				colvarFueImpresa.MaxLength = 0;
				colvarFueImpresa.AutoIncrement = false;
				colvarFueImpresa.IsNullable = false;
				colvarFueImpresa.IsPrimaryKey = false;
				colvarFueImpresa.IsForeignKey = false;
				colvarFueImpresa.IsReadOnly = false;
				colvarFueImpresa.DefaultSetting = @"";
				colvarFueImpresa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFueImpresa);
				
				TableSchema.TableColumn colvarJobCreateMessage = new TableSchema.TableColumn(schema);
				colvarJobCreateMessage.ColumnName = "jobCreateMessage";
				colvarJobCreateMessage.DataType = DbType.Boolean;
				colvarJobCreateMessage.MaxLength = 0;
				colvarJobCreateMessage.AutoIncrement = false;
				colvarJobCreateMessage.IsNullable = false;
				colvarJobCreateMessage.IsPrimaryKey = false;
				colvarJobCreateMessage.IsForeignKey = false;
				colvarJobCreateMessage.IsReadOnly = false;
				colvarJobCreateMessage.DefaultSetting = @"";
				colvarJobCreateMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarJobCreateMessage);
				
				TableSchema.TableColumn colvarIdVistaReceive = new TableSchema.TableColumn(schema);
				colvarIdVistaReceive.ColumnName = "id_vistaReceive";
				colvarIdVistaReceive.DataType = DbType.Int32;
				colvarIdVistaReceive.MaxLength = 0;
				colvarIdVistaReceive.AutoIncrement = false;
				colvarIdVistaReceive.IsNullable = true;
				colvarIdVistaReceive.IsPrimaryKey = false;
				colvarIdVistaReceive.IsForeignKey = false;
				colvarIdVistaReceive.IsReadOnly = false;
				colvarIdVistaReceive.DefaultSetting = @"";
				colvarIdVistaReceive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVistaReceive);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Medicos_registroIngreso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdUser")]
		[Bindable(true)]
		public int IdUser 
		{
			get { return GetColumnValue<int>(Columns.IdUser); }
			set { SetColumnValue(Columns.IdUser, value); }
		}
		  
		[XmlAttribute("IdMedico")]
		[Bindable(true)]
		public int IdMedico 
		{
			get { return GetColumnValue<int>(Columns.IdMedico); }
			set { SetColumnValue(Columns.IdMedico, value); }
		}
		  
		[XmlAttribute("FechaCreacion")]
		[Bindable(true)]
		public DateTime FechaCreacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaCreacion); }
			set { SetColumnValue(Columns.FechaCreacion, value); }
		}
		  
		[XmlAttribute("FechaDesde")]
		[Bindable(true)]
		public DateTime FechaDesde 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaDesde); }
			set { SetColumnValue(Columns.FechaDesde, value); }
		}
		  
		[XmlAttribute("FechaHasta")]
		[Bindable(true)]
		public DateTime FechaHasta 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHasta); }
			set { SetColumnValue(Columns.FechaHasta, value); }
		}
		  
		[XmlAttribute("FechaRecordatorio")]
		[Bindable(true)]
		public DateTime FechaRecordatorio 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRecordatorio); }
			set { SetColumnValue(Columns.FechaRecordatorio, value); }
		}
		  
		[XmlAttribute("FueImpresa")]
		[Bindable(true)]
		public bool FueImpresa 
		{
			get { return GetColumnValue<bool>(Columns.FueImpresa); }
			set { SetColumnValue(Columns.FueImpresa, value); }
		}
		  
		[XmlAttribute("JobCreateMessage")]
		[Bindable(true)]
		public bool JobCreateMessage 
		{
			get { return GetColumnValue<bool>(Columns.JobCreateMessage); }
			set { SetColumnValue(Columns.JobCreateMessage, value); }
		}
		  
		[XmlAttribute("IdVistaReceive")]
		[Bindable(true)]
		public int? IdVistaReceive 
		{
			get { return GetColumnValue<int?>(Columns.IdVistaReceive); }
			set { SetColumnValue(Columns.IdVistaReceive, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdUser,int varIdMedico,DateTime varFechaCreacion,DateTime varFechaDesde,DateTime varFechaHasta,DateTime varFechaRecordatorio,bool varFueImpresa,bool varJobCreateMessage,int? varIdVistaReceive)
		{
			GuardiaMedicosRegistroIngreso item = new GuardiaMedicosRegistroIngreso();
			
			item.IdUser = varIdUser;
			
			item.IdMedico = varIdMedico;
			
			item.FechaCreacion = varFechaCreacion;
			
			item.FechaDesde = varFechaDesde;
			
			item.FechaHasta = varFechaHasta;
			
			item.FechaRecordatorio = varFechaRecordatorio;
			
			item.FueImpresa = varFueImpresa;
			
			item.JobCreateMessage = varJobCreateMessage;
			
			item.IdVistaReceive = varIdVistaReceive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varIdUser,int varIdMedico,DateTime varFechaCreacion,DateTime varFechaDesde,DateTime varFechaHasta,DateTime varFechaRecordatorio,bool varFueImpresa,bool varJobCreateMessage,int? varIdVistaReceive)
		{
			GuardiaMedicosRegistroIngreso item = new GuardiaMedicosRegistroIngreso();
			
				item.Id = varId;
			
				item.IdUser = varIdUser;
			
				item.IdMedico = varIdMedico;
			
				item.FechaCreacion = varFechaCreacion;
			
				item.FechaDesde = varFechaDesde;
			
				item.FechaHasta = varFechaHasta;
			
				item.FechaRecordatorio = varFechaRecordatorio;
			
				item.FueImpresa = varFueImpresa;
			
				item.JobCreateMessage = varJobCreateMessage;
			
				item.IdVistaReceive = varIdVistaReceive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUserColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMedicoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCreacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDesdeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHastaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecordatorioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FueImpresaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn JobCreateMessageColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVistaReceiveColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdUser = @"id_user";
			 public static string IdMedico = @"id_medico";
			 public static string FechaCreacion = @"fechaCreacion";
			 public static string FechaDesde = @"fechaDesde";
			 public static string FechaHasta = @"fechaHasta";
			 public static string FechaRecordatorio = @"fechaRecordatorio";
			 public static string FueImpresa = @"fueImpresa";
			 public static string JobCreateMessage = @"jobCreateMessage";
			 public static string IdVistaReceive = @"id_vistaReceive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
