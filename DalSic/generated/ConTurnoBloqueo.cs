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
	/// Strongly-typed collection for the ConTurnoBloqueo class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoBloqueoCollection : ActiveList<ConTurnoBloqueo, ConTurnoBloqueoCollection>
	{	   
		public ConTurnoBloqueoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoBloqueoCollection</returns>
		public ConTurnoBloqueoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoBloqueo o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoBloqueo table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoBloqueo : ActiveRecord<ConTurnoBloqueo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoBloqueo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoBloqueo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoBloqueo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoBloqueo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoBloqueo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTurnoBloqueo = new TableSchema.TableColumn(schema);
				colvarIdTurnoBloqueo.ColumnName = "idTurnoBloqueo";
				colvarIdTurnoBloqueo.DataType = DbType.Int32;
				colvarIdTurnoBloqueo.MaxLength = 0;
				colvarIdTurnoBloqueo.AutoIncrement = true;
				colvarIdTurnoBloqueo.IsNullable = false;
				colvarIdTurnoBloqueo.IsPrimaryKey = true;
				colvarIdTurnoBloqueo.IsForeignKey = false;
				colvarIdTurnoBloqueo.IsReadOnly = false;
				colvarIdTurnoBloqueo.DefaultSetting = @"";
				colvarIdTurnoBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoBloqueo);
				
				TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
				colvarIdAgenda.ColumnName = "idAgenda";
				colvarIdAgenda.DataType = DbType.Int32;
				colvarIdAgenda.MaxLength = 0;
				colvarIdAgenda.AutoIncrement = false;
				colvarIdAgenda.IsNullable = false;
				colvarIdAgenda.IsPrimaryKey = false;
				colvarIdAgenda.IsForeignKey = false;
				colvarIdAgenda.IsReadOnly = false;
				colvarIdAgenda.DefaultSetting = @"";
				colvarIdAgenda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgenda);
				
				TableSchema.TableColumn colvarFechaTurno = new TableSchema.TableColumn(schema);
				colvarFechaTurno.ColumnName = "fechaTurno";
				colvarFechaTurno.DataType = DbType.DateTime;
				colvarFechaTurno.MaxLength = 0;
				colvarFechaTurno.AutoIncrement = false;
				colvarFechaTurno.IsNullable = false;
				colvarFechaTurno.IsPrimaryKey = false;
				colvarFechaTurno.IsForeignKey = false;
				colvarFechaTurno.IsReadOnly = false;
				colvarFechaTurno.DefaultSetting = @"";
				colvarFechaTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTurno);
				
				TableSchema.TableColumn colvarHoraTurno = new TableSchema.TableColumn(schema);
				colvarHoraTurno.ColumnName = "horaTurno";
				colvarHoraTurno.DataType = DbType.AnsiStringFixedLength;
				colvarHoraTurno.MaxLength = 5;
				colvarHoraTurno.AutoIncrement = false;
				colvarHoraTurno.IsNullable = false;
				colvarHoraTurno.IsPrimaryKey = false;
				colvarHoraTurno.IsForeignKey = false;
				colvarHoraTurno.IsReadOnly = false;
				colvarHoraTurno.DefaultSetting = @"";
				colvarHoraTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraTurno);
				
				TableSchema.TableColumn colvarIdUsuarioBloqueo = new TableSchema.TableColumn(schema);
				colvarIdUsuarioBloqueo.ColumnName = "idUsuarioBloqueo";
				colvarIdUsuarioBloqueo.DataType = DbType.Int32;
				colvarIdUsuarioBloqueo.MaxLength = 0;
				colvarIdUsuarioBloqueo.AutoIncrement = false;
				colvarIdUsuarioBloqueo.IsNullable = false;
				colvarIdUsuarioBloqueo.IsPrimaryKey = false;
				colvarIdUsuarioBloqueo.IsForeignKey = false;
				colvarIdUsuarioBloqueo.IsReadOnly = false;
				colvarIdUsuarioBloqueo.DefaultSetting = @"";
				colvarIdUsuarioBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioBloqueo);
				
				TableSchema.TableColumn colvarFechaBloqueo = new TableSchema.TableColumn(schema);
				colvarFechaBloqueo.ColumnName = "fechaBloqueo";
				colvarFechaBloqueo.DataType = DbType.DateTime;
				colvarFechaBloqueo.MaxLength = 0;
				colvarFechaBloqueo.AutoIncrement = false;
				colvarFechaBloqueo.IsNullable = false;
				colvarFechaBloqueo.IsPrimaryKey = false;
				colvarFechaBloqueo.IsForeignKey = false;
				colvarFechaBloqueo.IsReadOnly = false;
				colvarFechaBloqueo.DefaultSetting = @"";
				colvarFechaBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaBloqueo);
				
				TableSchema.TableColumn colvarIdUsuarioDesBloqueo = new TableSchema.TableColumn(schema);
				colvarIdUsuarioDesBloqueo.ColumnName = "idUsuarioDesBloqueo";
				colvarIdUsuarioDesBloqueo.DataType = DbType.Int32;
				colvarIdUsuarioDesBloqueo.MaxLength = 0;
				colvarIdUsuarioDesBloqueo.AutoIncrement = false;
				colvarIdUsuarioDesBloqueo.IsNullable = false;
				colvarIdUsuarioDesBloqueo.IsPrimaryKey = false;
				colvarIdUsuarioDesBloqueo.IsForeignKey = false;
				colvarIdUsuarioDesBloqueo.IsReadOnly = false;
				
						colvarIdUsuarioDesBloqueo.DefaultSetting = @"((0))";
				colvarIdUsuarioDesBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioDesBloqueo);
				
				TableSchema.TableColumn colvarFechaDesBloqueo = new TableSchema.TableColumn(schema);
				colvarFechaDesBloqueo.ColumnName = "fechaDesBloqueo";
				colvarFechaDesBloqueo.DataType = DbType.DateTime;
				colvarFechaDesBloqueo.MaxLength = 0;
				colvarFechaDesBloqueo.AutoIncrement = false;
				colvarFechaDesBloqueo.IsNullable = false;
				colvarFechaDesBloqueo.IsPrimaryKey = false;
				colvarFechaDesBloqueo.IsForeignKey = false;
				colvarFechaDesBloqueo.IsReadOnly = false;
				
						colvarFechaDesBloqueo.DefaultSetting = @"('01/01/1900')";
				colvarFechaDesBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDesBloqueo);
				
				TableSchema.TableColumn colvarIdMotivoBloqueo = new TableSchema.TableColumn(schema);
				colvarIdMotivoBloqueo.ColumnName = "idMotivoBloqueo";
				colvarIdMotivoBloqueo.DataType = DbType.Int32;
				colvarIdMotivoBloqueo.MaxLength = 0;
				colvarIdMotivoBloqueo.AutoIncrement = false;
				colvarIdMotivoBloqueo.IsNullable = true;
				colvarIdMotivoBloqueo.IsPrimaryKey = false;
				colvarIdMotivoBloqueo.IsForeignKey = true;
				colvarIdMotivoBloqueo.IsReadOnly = false;
				colvarIdMotivoBloqueo.DefaultSetting = @"";
				
					colvarIdMotivoBloqueo.ForeignKeyTableName = "CON_MotivosDeBloqueo";
				schema.Columns.Add(colvarIdMotivoBloqueo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoBloqueo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTurnoBloqueo")]
		[Bindable(true)]
		public int IdTurnoBloqueo 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoBloqueo); }
			set { SetColumnValue(Columns.IdTurnoBloqueo, value); }
		}
		  
		[XmlAttribute("IdAgenda")]
		[Bindable(true)]
		public int IdAgenda 
		{
			get { return GetColumnValue<int>(Columns.IdAgenda); }
			set { SetColumnValue(Columns.IdAgenda, value); }
		}
		  
		[XmlAttribute("FechaTurno")]
		[Bindable(true)]
		public DateTime FechaTurno 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaTurno); }
			set { SetColumnValue(Columns.FechaTurno, value); }
		}
		  
		[XmlAttribute("HoraTurno")]
		[Bindable(true)]
		public string HoraTurno 
		{
			get { return GetColumnValue<string>(Columns.HoraTurno); }
			set { SetColumnValue(Columns.HoraTurno, value); }
		}
		  
		[XmlAttribute("IdUsuarioBloqueo")]
		[Bindable(true)]
		public int IdUsuarioBloqueo 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioBloqueo); }
			set { SetColumnValue(Columns.IdUsuarioBloqueo, value); }
		}
		  
		[XmlAttribute("FechaBloqueo")]
		[Bindable(true)]
		public DateTime FechaBloqueo 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaBloqueo); }
			set { SetColumnValue(Columns.FechaBloqueo, value); }
		}
		  
		[XmlAttribute("IdUsuarioDesBloqueo")]
		[Bindable(true)]
		public int IdUsuarioDesBloqueo 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioDesBloqueo); }
			set { SetColumnValue(Columns.IdUsuarioDesBloqueo, value); }
		}
		  
		[XmlAttribute("FechaDesBloqueo")]
		[Bindable(true)]
		public DateTime FechaDesBloqueo 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaDesBloqueo); }
			set { SetColumnValue(Columns.FechaDesBloqueo, value); }
		}
		  
		[XmlAttribute("IdMotivoBloqueo")]
		[Bindable(true)]
		public int? IdMotivoBloqueo 
		{
			get { return GetColumnValue<int?>(Columns.IdMotivoBloqueo); }
			set { SetColumnValue(Columns.IdMotivoBloqueo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConMotivosDeBloqueo ActiveRecord object related to this ConTurnoBloqueo
		/// 
		/// </summary>
		public DalSic.ConMotivosDeBloqueo ConMotivosDeBloqueo
		{
			get { return DalSic.ConMotivosDeBloqueo.FetchByID(this.IdMotivoBloqueo); }
			set { SetColumnValue("idMotivoBloqueo", value.IdMotivoBloqueo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgenda,DateTime varFechaTurno,string varHoraTurno,int varIdUsuarioBloqueo,DateTime varFechaBloqueo,int varIdUsuarioDesBloqueo,DateTime varFechaDesBloqueo,int? varIdMotivoBloqueo)
		{
			ConTurnoBloqueo item = new ConTurnoBloqueo();
			
			item.IdAgenda = varIdAgenda;
			
			item.FechaTurno = varFechaTurno;
			
			item.HoraTurno = varHoraTurno;
			
			item.IdUsuarioBloqueo = varIdUsuarioBloqueo;
			
			item.FechaBloqueo = varFechaBloqueo;
			
			item.IdUsuarioDesBloqueo = varIdUsuarioDesBloqueo;
			
			item.FechaDesBloqueo = varFechaDesBloqueo;
			
			item.IdMotivoBloqueo = varIdMotivoBloqueo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTurnoBloqueo,int varIdAgenda,DateTime varFechaTurno,string varHoraTurno,int varIdUsuarioBloqueo,DateTime varFechaBloqueo,int varIdUsuarioDesBloqueo,DateTime varFechaDesBloqueo,int? varIdMotivoBloqueo)
		{
			ConTurnoBloqueo item = new ConTurnoBloqueo();
			
				item.IdTurnoBloqueo = varIdTurnoBloqueo;
			
				item.IdAgenda = varIdAgenda;
			
				item.FechaTurno = varFechaTurno;
			
				item.HoraTurno = varHoraTurno;
			
				item.IdUsuarioBloqueo = varIdUsuarioBloqueo;
			
				item.FechaBloqueo = varFechaBloqueo;
			
				item.IdUsuarioDesBloqueo = varIdUsuarioDesBloqueo;
			
				item.FechaDesBloqueo = varFechaDesBloqueo;
			
				item.IdMotivoBloqueo = varIdMotivoBloqueo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTurnoBloqueoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTurnoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraTurnoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioBloqueoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaBloqueoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioDesBloqueoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDesBloqueoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoBloqueoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTurnoBloqueo = @"idTurnoBloqueo";
			 public static string IdAgenda = @"idAgenda";
			 public static string FechaTurno = @"fechaTurno";
			 public static string HoraTurno = @"horaTurno";
			 public static string IdUsuarioBloqueo = @"idUsuarioBloqueo";
			 public static string FechaBloqueo = @"fechaBloqueo";
			 public static string IdUsuarioDesBloqueo = @"idUsuarioDesBloqueo";
			 public static string FechaDesBloqueo = @"fechaDesBloqueo";
			 public static string IdMotivoBloqueo = @"idMotivoBloqueo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
