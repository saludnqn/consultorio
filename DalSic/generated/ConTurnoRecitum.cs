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
	/// Strongly-typed collection for the ConTurnoRecitum class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoRecitumCollection : ActiveList<ConTurnoRecitum, ConTurnoRecitumCollection>
	{	   
		public ConTurnoRecitumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoRecitumCollection</returns>
		public ConTurnoRecitumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoRecitum o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoRecita table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoRecitum : ActiveRecord<ConTurnoRecitum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoRecitum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoRecitum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoRecitum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoRecitum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoRecita", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRecita = new TableSchema.TableColumn(schema);
				colvarIdRecita.ColumnName = "idRecita";
				colvarIdRecita.DataType = DbType.Int32;
				colvarIdRecita.MaxLength = 0;
				colvarIdRecita.AutoIncrement = true;
				colvarIdRecita.IsNullable = false;
				colvarIdRecita.IsPrimaryKey = true;
				colvarIdRecita.IsForeignKey = false;
				colvarIdRecita.IsReadOnly = false;
				colvarIdRecita.DefaultSetting = @"";
				colvarIdRecita.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRecita);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdTurnoAnterior = new TableSchema.TableColumn(schema);
				colvarIdTurnoAnterior.ColumnName = "idTurnoAnterior";
				colvarIdTurnoAnterior.DataType = DbType.Int32;
				colvarIdTurnoAnterior.MaxLength = 0;
				colvarIdTurnoAnterior.AutoIncrement = false;
				colvarIdTurnoAnterior.IsNullable = false;
				colvarIdTurnoAnterior.IsPrimaryKey = false;
				colvarIdTurnoAnterior.IsForeignKey = true;
				colvarIdTurnoAnterior.IsReadOnly = false;
				colvarIdTurnoAnterior.DefaultSetting = @"";
				
					colvarIdTurnoAnterior.ForeignKeyTableName = "CON_Turno";
				schema.Columns.Add(colvarIdTurnoAnterior);
				
				TableSchema.TableColumn colvarIdAgendaAnterior = new TableSchema.TableColumn(schema);
				colvarIdAgendaAnterior.ColumnName = "idAgendaAnterior";
				colvarIdAgendaAnterior.DataType = DbType.Int32;
				colvarIdAgendaAnterior.MaxLength = 0;
				colvarIdAgendaAnterior.AutoIncrement = false;
				colvarIdAgendaAnterior.IsNullable = false;
				colvarIdAgendaAnterior.IsPrimaryKey = false;
				colvarIdAgendaAnterior.IsForeignKey = false;
				colvarIdAgendaAnterior.IsReadOnly = false;
				colvarIdAgendaAnterior.DefaultSetting = @"";
				colvarIdAgendaAnterior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgendaAnterior);
				
				TableSchema.TableColumn colvarFechaAnterior = new TableSchema.TableColumn(schema);
				colvarFechaAnterior.ColumnName = "fechaAnterior";
				colvarFechaAnterior.DataType = DbType.DateTime;
				colvarFechaAnterior.MaxLength = 0;
				colvarFechaAnterior.AutoIncrement = false;
				colvarFechaAnterior.IsNullable = false;
				colvarFechaAnterior.IsPrimaryKey = false;
				colvarFechaAnterior.IsForeignKey = false;
				colvarFechaAnterior.IsReadOnly = false;
				colvarFechaAnterior.DefaultSetting = @"";
				colvarFechaAnterior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAnterior);
				
				TableSchema.TableColumn colvarHoraAnterior = new TableSchema.TableColumn(schema);
				colvarHoraAnterior.ColumnName = "horaAnterior";
				colvarHoraAnterior.DataType = DbType.AnsiStringFixedLength;
				colvarHoraAnterior.MaxLength = 5;
				colvarHoraAnterior.AutoIncrement = false;
				colvarHoraAnterior.IsNullable = false;
				colvarHoraAnterior.IsPrimaryKey = false;
				colvarHoraAnterior.IsForeignKey = false;
				colvarHoraAnterior.IsReadOnly = false;
				colvarHoraAnterior.DefaultSetting = @"";
				colvarHoraAnterior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraAnterior);
				
				TableSchema.TableColumn colvarIdTurnoActual = new TableSchema.TableColumn(schema);
				colvarIdTurnoActual.ColumnName = "idTurnoActual";
				colvarIdTurnoActual.DataType = DbType.Int32;
				colvarIdTurnoActual.MaxLength = 0;
				colvarIdTurnoActual.AutoIncrement = false;
				colvarIdTurnoActual.IsNullable = false;
				colvarIdTurnoActual.IsPrimaryKey = false;
				colvarIdTurnoActual.IsForeignKey = true;
				colvarIdTurnoActual.IsReadOnly = false;
				colvarIdTurnoActual.DefaultSetting = @"";
				
					colvarIdTurnoActual.ForeignKeyTableName = "CON_Turno";
				schema.Columns.Add(colvarIdTurnoActual);
				
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
				
				TableSchema.TableColumn colvarFechaRecita = new TableSchema.TableColumn(schema);
				colvarFechaRecita.ColumnName = "fechaRecita";
				colvarFechaRecita.DataType = DbType.DateTime;
				colvarFechaRecita.MaxLength = 0;
				colvarFechaRecita.AutoIncrement = false;
				colvarFechaRecita.IsNullable = false;
				colvarFechaRecita.IsPrimaryKey = false;
				colvarFechaRecita.IsForeignKey = false;
				colvarFechaRecita.IsReadOnly = false;
				colvarFechaRecita.DefaultSetting = @"";
				colvarFechaRecita.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecita);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoRecita",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRecita")]
		[Bindable(true)]
		public int IdRecita 
		{
			get { return GetColumnValue<int>(Columns.IdRecita); }
			set { SetColumnValue(Columns.IdRecita, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdTurnoAnterior")]
		[Bindable(true)]
		public int IdTurnoAnterior 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoAnterior); }
			set { SetColumnValue(Columns.IdTurnoAnterior, value); }
		}
		  
		[XmlAttribute("IdAgendaAnterior")]
		[Bindable(true)]
		public int IdAgendaAnterior 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaAnterior); }
			set { SetColumnValue(Columns.IdAgendaAnterior, value); }
		}
		  
		[XmlAttribute("FechaAnterior")]
		[Bindable(true)]
		public DateTime FechaAnterior 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAnterior); }
			set { SetColumnValue(Columns.FechaAnterior, value); }
		}
		  
		[XmlAttribute("HoraAnterior")]
		[Bindable(true)]
		public string HoraAnterior 
		{
			get { return GetColumnValue<string>(Columns.HoraAnterior); }
			set { SetColumnValue(Columns.HoraAnterior, value); }
		}
		  
		[XmlAttribute("IdTurnoActual")]
		[Bindable(true)]
		public int IdTurnoActual 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoActual); }
			set { SetColumnValue(Columns.IdTurnoActual, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaRecita")]
		[Bindable(true)]
		public DateTime FechaRecita 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRecita); }
			set { SetColumnValue(Columns.FechaRecita, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this ConTurnoRecitum
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a ConTurno ActiveRecord object related to this ConTurnoRecitum
		/// 
		/// </summary>
		public DalSic.ConTurno ConTurno
		{
			get { return DalSic.ConTurno.FetchByID(this.IdTurnoAnterior); }
			set { SetColumnValue("idTurnoAnterior", value.IdTurno); }
		}
		
		
		/// <summary>
		/// Returns a ConTurno ActiveRecord object related to this ConTurnoRecitum
		/// 
		/// </summary>
		public DalSic.ConTurno ConTurnoToIdTurnoActual
		{
			get { return DalSic.ConTurno.FetchByID(this.IdTurnoActual); }
			set { SetColumnValue("idTurnoActual", value.IdTurno); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varIdTurnoAnterior,int varIdAgendaAnterior,DateTime varFechaAnterior,string varHoraAnterior,int varIdTurnoActual,int varIdUsuario,DateTime varFechaRecita)
		{
			ConTurnoRecitum item = new ConTurnoRecitum();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdTurnoAnterior = varIdTurnoAnterior;
			
			item.IdAgendaAnterior = varIdAgendaAnterior;
			
			item.FechaAnterior = varFechaAnterior;
			
			item.HoraAnterior = varHoraAnterior;
			
			item.IdTurnoActual = varIdTurnoActual;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaRecita = varFechaRecita;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRecita,int varIdPaciente,int varIdTurnoAnterior,int varIdAgendaAnterior,DateTime varFechaAnterior,string varHoraAnterior,int varIdTurnoActual,int varIdUsuario,DateTime varFechaRecita)
		{
			ConTurnoRecitum item = new ConTurnoRecitum();
			
				item.IdRecita = varIdRecita;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdTurnoAnterior = varIdTurnoAnterior;
			
				item.IdAgendaAnterior = varIdAgendaAnterior;
			
				item.FechaAnterior = varFechaAnterior;
			
				item.HoraAnterior = varHoraAnterior;
			
				item.IdTurnoActual = varIdTurnoActual;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaRecita = varFechaRecita;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRecitaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoAnteriorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaAnteriorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAnteriorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraAnteriorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoActualColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecitaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRecita = @"idRecita";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdTurnoAnterior = @"idTurnoAnterior";
			 public static string IdAgendaAnterior = @"idAgendaAnterior";
			 public static string FechaAnterior = @"fechaAnterior";
			 public static string HoraAnterior = @"horaAnterior";
			 public static string IdTurnoActual = @"idTurnoActual";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaRecita = @"fechaRecita";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
