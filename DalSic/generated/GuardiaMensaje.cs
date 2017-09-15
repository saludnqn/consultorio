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
	/// Strongly-typed collection for the GuardiaMensaje class.
	/// </summary>
    [Serializable]
	public partial class GuardiaMensajeCollection : ActiveList<GuardiaMensaje, GuardiaMensajeCollection>
	{	   
		public GuardiaMensajeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaMensajeCollection</returns>
		public GuardiaMensajeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaMensaje o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Mensajes table.
	/// </summary>
	[Serializable]
	public partial class GuardiaMensaje : ActiveRecord<GuardiaMensaje>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaMensaje()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaMensaje(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaMensaje(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaMensaje(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Mensajes", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdUserSend = new TableSchema.TableColumn(schema);
				colvarIdUserSend.ColumnName = "id_userSend";
				colvarIdUserSend.DataType = DbType.Int32;
				colvarIdUserSend.MaxLength = 0;
				colvarIdUserSend.AutoIncrement = false;
				colvarIdUserSend.IsNullable = true;
				colvarIdUserSend.IsPrimaryKey = false;
				colvarIdUserSend.IsForeignKey = false;
				colvarIdUserSend.IsReadOnly = false;
				colvarIdUserSend.DefaultSetting = @"";
				colvarIdUserSend.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUserSend);
				
				TableSchema.TableColumn colvarIdUserReceive = new TableSchema.TableColumn(schema);
				colvarIdUserReceive.ColumnName = "id_userReceive";
				colvarIdUserReceive.DataType = DbType.Int32;
				colvarIdUserReceive.MaxLength = 0;
				colvarIdUserReceive.AutoIncrement = false;
				colvarIdUserReceive.IsNullable = true;
				colvarIdUserReceive.IsPrimaryKey = false;
				colvarIdUserReceive.IsForeignKey = false;
				colvarIdUserReceive.IsReadOnly = false;
				colvarIdUserReceive.DefaultSetting = @"";
				colvarIdUserReceive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUserReceive);
				
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
				
				TableSchema.TableColumn colvarIdTipo = new TableSchema.TableColumn(schema);
				colvarIdTipo.ColumnName = "id_tipo";
				colvarIdTipo.DataType = DbType.Int32;
				colvarIdTipo.MaxLength = 0;
				colvarIdTipo.AutoIncrement = false;
				colvarIdTipo.IsNullable = false;
				colvarIdTipo.IsPrimaryKey = false;
				colvarIdTipo.IsForeignKey = false;
				colvarIdTipo.IsReadOnly = false;
				colvarIdTipo.DefaultSetting = @"";
				colvarIdTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipo);
				
				TableSchema.TableColumn colvarData = new TableSchema.TableColumn(schema);
				colvarData.ColumnName = "data";
				colvarData.DataType = DbType.AnsiString;
				colvarData.MaxLength = 50;
				colvarData.AutoIncrement = false;
				colvarData.IsNullable = true;
				colvarData.IsPrimaryKey = false;
				colvarData.IsForeignKey = false;
				colvarData.IsReadOnly = false;
				colvarData.DefaultSetting = @"";
				colvarData.ForeignKeyTableName = "";
				schema.Columns.Add(colvarData);
				
				TableSchema.TableColumn colvarReaded = new TableSchema.TableColumn(schema);
				colvarReaded.ColumnName = "readed";
				colvarReaded.DataType = DbType.Boolean;
				colvarReaded.MaxLength = 0;
				colvarReaded.AutoIncrement = false;
				colvarReaded.IsNullable = true;
				colvarReaded.IsPrimaryKey = false;
				colvarReaded.IsForeignKey = false;
				colvarReaded.IsReadOnly = false;
				colvarReaded.DefaultSetting = @"";
				colvarReaded.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReaded);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
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
				
				TableSchema.TableColumn colvarIdUserReaded = new TableSchema.TableColumn(schema);
				colvarIdUserReaded.ColumnName = "id_userReaded";
				colvarIdUserReaded.DataType = DbType.Int32;
				colvarIdUserReaded.MaxLength = 0;
				colvarIdUserReaded.AutoIncrement = false;
				colvarIdUserReaded.IsNullable = true;
				colvarIdUserReaded.IsPrimaryKey = false;
				colvarIdUserReaded.IsForeignKey = false;
				colvarIdUserReaded.IsReadOnly = false;
				colvarIdUserReaded.DefaultSetting = @"";
				colvarIdUserReaded.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUserReaded);
				
				TableSchema.TableColumn colvarFechaReaded = new TableSchema.TableColumn(schema);
				colvarFechaReaded.ColumnName = "fechaReaded";
				colvarFechaReaded.DataType = DbType.DateTime;
				colvarFechaReaded.MaxLength = 0;
				colvarFechaReaded.AutoIncrement = false;
				colvarFechaReaded.IsNullable = true;
				colvarFechaReaded.IsPrimaryKey = false;
				colvarFechaReaded.IsForeignKey = false;
				colvarFechaReaded.IsReadOnly = false;
				colvarFechaReaded.DefaultSetting = @"";
				colvarFechaReaded.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaReaded);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Mensajes",schema);
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
		  
		[XmlAttribute("IdUserSend")]
		[Bindable(true)]
		public int? IdUserSend 
		{
			get { return GetColumnValue<int?>(Columns.IdUserSend); }
			set { SetColumnValue(Columns.IdUserSend, value); }
		}
		  
		[XmlAttribute("IdUserReceive")]
		[Bindable(true)]
		public int? IdUserReceive 
		{
			get { return GetColumnValue<int?>(Columns.IdUserReceive); }
			set { SetColumnValue(Columns.IdUserReceive, value); }
		}
		  
		[XmlAttribute("IdVistaReceive")]
		[Bindable(true)]
		public int? IdVistaReceive 
		{
			get { return GetColumnValue<int?>(Columns.IdVistaReceive); }
			set { SetColumnValue(Columns.IdVistaReceive, value); }
		}
		  
		[XmlAttribute("IdTipo")]
		[Bindable(true)]
		public int IdTipo 
		{
			get { return GetColumnValue<int>(Columns.IdTipo); }
			set { SetColumnValue(Columns.IdTipo, value); }
		}
		  
		[XmlAttribute("Data")]
		[Bindable(true)]
		public string Data 
		{
			get { return GetColumnValue<string>(Columns.Data); }
			set { SetColumnValue(Columns.Data, value); }
		}
		  
		[XmlAttribute("Readed")]
		[Bindable(true)]
		public bool? Readed 
		{
			get { return GetColumnValue<bool?>(Columns.Readed); }
			set { SetColumnValue(Columns.Readed, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("IdUserReaded")]
		[Bindable(true)]
		public int? IdUserReaded 
		{
			get { return GetColumnValue<int?>(Columns.IdUserReaded); }
			set { SetColumnValue(Columns.IdUserReaded, value); }
		}
		  
		[XmlAttribute("FechaReaded")]
		[Bindable(true)]
		public DateTime? FechaReaded 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaReaded); }
			set { SetColumnValue(Columns.FechaReaded, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdUserSend,int? varIdUserReceive,int? varIdVistaReceive,int varIdTipo,string varData,bool? varReaded,DateTime varFecha,int? varIdUserReaded,DateTime? varFechaReaded)
		{
			GuardiaMensaje item = new GuardiaMensaje();
			
			item.IdUserSend = varIdUserSend;
			
			item.IdUserReceive = varIdUserReceive;
			
			item.IdVistaReceive = varIdVistaReceive;
			
			item.IdTipo = varIdTipo;
			
			item.Data = varData;
			
			item.Readed = varReaded;
			
			item.Fecha = varFecha;
			
			item.IdUserReaded = varIdUserReaded;
			
			item.FechaReaded = varFechaReaded;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdUserSend,int? varIdUserReceive,int? varIdVistaReceive,int varIdTipo,string varData,bool? varReaded,DateTime varFecha,int? varIdUserReaded,DateTime? varFechaReaded)
		{
			GuardiaMensaje item = new GuardiaMensaje();
			
				item.Id = varId;
			
				item.IdUserSend = varIdUserSend;
			
				item.IdUserReceive = varIdUserReceive;
			
				item.IdVistaReceive = varIdVistaReceive;
			
				item.IdTipo = varIdTipo;
			
				item.Data = varData;
			
				item.Readed = varReaded;
			
				item.Fecha = varFecha;
			
				item.IdUserReaded = varIdUserReaded;
			
				item.FechaReaded = varFechaReaded;
			
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
        
        
        
        public static TableSchema.TableColumn IdUserSendColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUserReceiveColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVistaReceiveColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DataColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ReadedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUserReadedColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaReadedColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdUserSend = @"id_userSend";
			 public static string IdUserReceive = @"id_userReceive";
			 public static string IdVistaReceive = @"id_vistaReceive";
			 public static string IdTipo = @"id_tipo";
			 public static string Data = @"data";
			 public static string Readed = @"readed";
			 public static string Fecha = @"fecha";
			 public static string IdUserReaded = @"id_userReaded";
			 public static string FechaReaded = @"fechaReaded";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
