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
	/// Strongly-typed collection for the ConAgendaBloqueo class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaBloqueoCollection : ActiveList<ConAgendaBloqueo, ConAgendaBloqueoCollection>
	{	   
		public ConAgendaBloqueoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaBloqueoCollection</returns>
		public ConAgendaBloqueoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaBloqueo o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaBloqueo table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaBloqueo : ActiveRecord<ConAgendaBloqueo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaBloqueo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaBloqueo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaBloqueo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaBloqueo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaBloqueo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdBloqueo = new TableSchema.TableColumn(schema);
				colvarIdBloqueo.ColumnName = "idBloqueo";
				colvarIdBloqueo.DataType = DbType.Int32;
				colvarIdBloqueo.MaxLength = 0;
				colvarIdBloqueo.AutoIncrement = true;
				colvarIdBloqueo.IsNullable = false;
				colvarIdBloqueo.IsPrimaryKey = true;
				colvarIdBloqueo.IsForeignKey = false;
				colvarIdBloqueo.IsReadOnly = false;
				colvarIdBloqueo.DefaultSetting = @"";
				colvarIdBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBloqueo);
				
				TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
				colvarIdAgenda.ColumnName = "idAgenda";
				colvarIdAgenda.DataType = DbType.Int32;
				colvarIdAgenda.MaxLength = 0;
				colvarIdAgenda.AutoIncrement = false;
				colvarIdAgenda.IsNullable = false;
				colvarIdAgenda.IsPrimaryKey = false;
				colvarIdAgenda.IsForeignKey = true;
				colvarIdAgenda.IsReadOnly = false;
				colvarIdAgenda.DefaultSetting = @"";
				
					colvarIdAgenda.ForeignKeyTableName = "CON_Agenda";
				schema.Columns.Add(colvarIdAgenda);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarFechaActivacion = new TableSchema.TableColumn(schema);
				colvarFechaActivacion.ColumnName = "fechaActivacion";
				colvarFechaActivacion.DataType = DbType.DateTime;
				colvarFechaActivacion.MaxLength = 0;
				colvarFechaActivacion.AutoIncrement = false;
				colvarFechaActivacion.IsNullable = false;
				colvarFechaActivacion.IsPrimaryKey = false;
				colvarFechaActivacion.IsForeignKey = false;
				colvarFechaActivacion.IsReadOnly = false;
				colvarFechaActivacion.DefaultSetting = @"";
				colvarFechaActivacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaActivacion);
				
				TableSchema.TableColumn colvarAgendaActivada = new TableSchema.TableColumn(schema);
				colvarAgendaActivada.ColumnName = "agendaActivada";
				colvarAgendaActivada.DataType = DbType.Boolean;
				colvarAgendaActivada.MaxLength = 0;
				colvarAgendaActivada.AutoIncrement = false;
				colvarAgendaActivada.IsNullable = false;
				colvarAgendaActivada.IsPrimaryKey = false;
				colvarAgendaActivada.IsForeignKey = false;
				colvarAgendaActivada.IsReadOnly = false;
				
						colvarAgendaActivada.DefaultSetting = @"((0))";
				colvarAgendaActivada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAgendaActivada);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaBloqueo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdBloqueo")]
		[Bindable(true)]
		public int IdBloqueo 
		{
			get { return GetColumnValue<int>(Columns.IdBloqueo); }
			set { SetColumnValue(Columns.IdBloqueo, value); }
		}
		  
		[XmlAttribute("IdAgenda")]
		[Bindable(true)]
		public int IdAgenda 
		{
			get { return GetColumnValue<int>(Columns.IdAgenda); }
			set { SetColumnValue(Columns.IdAgenda, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaActivacion")]
		[Bindable(true)]
		public DateTime FechaActivacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaActivacion); }
			set { SetColumnValue(Columns.FechaActivacion, value); }
		}
		  
		[XmlAttribute("AgendaActivada")]
		[Bindable(true)]
		public bool AgendaActivada 
		{
			get { return GetColumnValue<bool>(Columns.AgendaActivada); }
			set { SetColumnValue(Columns.AgendaActivada, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConAgenda ActiveRecord object related to this ConAgendaBloqueo
		/// 
		/// </summary>
		public DalSic.ConAgenda ConAgenda
		{
			get { return DalSic.ConAgenda.FetchByID(this.IdAgenda); }
			set { SetColumnValue("idAgenda", value.IdAgenda); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgenda,int varIdUsuario,DateTime varFechaActivacion,bool varAgendaActivada)
		{
			ConAgendaBloqueo item = new ConAgendaBloqueo();
			
			item.IdAgenda = varIdAgenda;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaActivacion = varFechaActivacion;
			
			item.AgendaActivada = varAgendaActivada;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdBloqueo,int varIdAgenda,int varIdUsuario,DateTime varFechaActivacion,bool varAgendaActivada)
		{
			ConAgendaBloqueo item = new ConAgendaBloqueo();
			
				item.IdBloqueo = varIdBloqueo;
			
				item.IdAgenda = varIdAgenda;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaActivacion = varFechaActivacion;
			
				item.AgendaActivada = varAgendaActivada;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdBloqueoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaActivacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AgendaActivadaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdBloqueo = @"idBloqueo";
			 public static string IdAgenda = @"idAgenda";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaActivacion = @"fechaActivacion";
			 public static string AgendaActivada = @"agendaActivada";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
