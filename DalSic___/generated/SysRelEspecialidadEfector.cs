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
	/// Strongly-typed collection for the SysRelEspecialidadEfector class.
	/// </summary>
    [Serializable]
	public partial class SysRelEspecialidadEfectorCollection : ActiveList<SysRelEspecialidadEfector, SysRelEspecialidadEfectorCollection>
	{	   
		public SysRelEspecialidadEfectorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelEspecialidadEfectorCollection</returns>
		public SysRelEspecialidadEfectorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelEspecialidadEfector o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelEspecialidadEfector table.
	/// </summary>
	[Serializable]
	public partial class SysRelEspecialidadEfector : ActiveRecord<SysRelEspecialidadEfector>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelEspecialidadEfector()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelEspecialidadEfector(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelEspecialidadEfector(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelEspecialidadEfector(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelEspecialidadEfector", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelEspecialidadEfector = new TableSchema.TableColumn(schema);
				colvarIdRelEspecialidadEfector.ColumnName = "idRelEspecialidadEfector";
				colvarIdRelEspecialidadEfector.DataType = DbType.Int32;
				colvarIdRelEspecialidadEfector.MaxLength = 0;
				colvarIdRelEspecialidadEfector.AutoIncrement = true;
				colvarIdRelEspecialidadEfector.IsNullable = false;
				colvarIdRelEspecialidadEfector.IsPrimaryKey = true;
				colvarIdRelEspecialidadEfector.IsForeignKey = false;
				colvarIdRelEspecialidadEfector.IsReadOnly = false;
				colvarIdRelEspecialidadEfector.DefaultSetting = @"";
				colvarIdRelEspecialidadEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelEspecialidadEfector);
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = false;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = true;
				colvarIdEspecialidad.IsReadOnly = false;
				colvarIdEspecialidad.DefaultSetting = @"";
				
					colvarIdEspecialidad.ForeignKeyTableName = "Sys_Especialidad";
				schema.Columns.Add(colvarIdEspecialidad);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarDuracionTurno = new TableSchema.TableColumn(schema);
				colvarDuracionTurno.ColumnName = "duracionTurno";
				colvarDuracionTurno.DataType = DbType.Int32;
				colvarDuracionTurno.MaxLength = 0;
				colvarDuracionTurno.AutoIncrement = false;
				colvarDuracionTurno.IsNullable = false;
				colvarDuracionTurno.IsPrimaryKey = false;
				colvarDuracionTurno.IsForeignKey = false;
				colvarDuracionTurno.IsReadOnly = false;
				colvarDuracionTurno.DefaultSetting = @"";
				colvarDuracionTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDuracionTurno);
				
				TableSchema.TableColumn colvarPorcentajeTurnosDia = new TableSchema.TableColumn(schema);
				colvarPorcentajeTurnosDia.ColumnName = "porcentajeTurnosDia";
				colvarPorcentajeTurnosDia.DataType = DbType.Int32;
				colvarPorcentajeTurnosDia.MaxLength = 0;
				colvarPorcentajeTurnosDia.AutoIncrement = false;
				colvarPorcentajeTurnosDia.IsNullable = false;
				colvarPorcentajeTurnosDia.IsPrimaryKey = false;
				colvarPorcentajeTurnosDia.IsForeignKey = false;
				colvarPorcentajeTurnosDia.IsReadOnly = false;
				
						colvarPorcentajeTurnosDia.DefaultSetting = @"((0))";
				colvarPorcentajeTurnosDia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPorcentajeTurnosDia);
				
				TableSchema.TableColumn colvarPorcentajeTurnosAnticipado = new TableSchema.TableColumn(schema);
				colvarPorcentajeTurnosAnticipado.ColumnName = "porcentajeTurnosAnticipado";
				colvarPorcentajeTurnosAnticipado.DataType = DbType.Int32;
				colvarPorcentajeTurnosAnticipado.MaxLength = 0;
				colvarPorcentajeTurnosAnticipado.AutoIncrement = false;
				colvarPorcentajeTurnosAnticipado.IsNullable = false;
				colvarPorcentajeTurnosAnticipado.IsPrimaryKey = false;
				colvarPorcentajeTurnosAnticipado.IsForeignKey = false;
				colvarPorcentajeTurnosAnticipado.IsReadOnly = false;
				
						colvarPorcentajeTurnosAnticipado.DefaultSetting = @"((0))";
				colvarPorcentajeTurnosAnticipado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPorcentajeTurnosAnticipado);
				
				TableSchema.TableColumn colvarMaximoSobreturnos = new TableSchema.TableColumn(schema);
				colvarMaximoSobreturnos.ColumnName = "maximoSobreturnos";
				colvarMaximoSobreturnos.DataType = DbType.Int32;
				colvarMaximoSobreturnos.MaxLength = 0;
				colvarMaximoSobreturnos.AutoIncrement = false;
				colvarMaximoSobreturnos.IsNullable = false;
				colvarMaximoSobreturnos.IsPrimaryKey = false;
				colvarMaximoSobreturnos.IsForeignKey = false;
				colvarMaximoSobreturnos.IsReadOnly = false;
				
						colvarMaximoSobreturnos.DefaultSetting = @"((0))";
				colvarMaximoSobreturnos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaximoSobreturnos);
				
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
				
						colvarFechaRegistro.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelEspecialidadEfector",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelEspecialidadEfector")]
		[Bindable(true)]
		public int IdRelEspecialidadEfector 
		{
			get { return GetColumnValue<int>(Columns.IdRelEspecialidadEfector); }
			set { SetColumnValue(Columns.IdRelEspecialidadEfector, value); }
		}
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int IdEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("DuracionTurno")]
		[Bindable(true)]
		public int DuracionTurno 
		{
			get { return GetColumnValue<int>(Columns.DuracionTurno); }
			set { SetColumnValue(Columns.DuracionTurno, value); }
		}
		  
		[XmlAttribute("PorcentajeTurnosDia")]
		[Bindable(true)]
		public int PorcentajeTurnosDia 
		{
			get { return GetColumnValue<int>(Columns.PorcentajeTurnosDia); }
			set { SetColumnValue(Columns.PorcentajeTurnosDia, value); }
		}
		  
		[XmlAttribute("PorcentajeTurnosAnticipado")]
		[Bindable(true)]
		public int PorcentajeTurnosAnticipado 
		{
			get { return GetColumnValue<int>(Columns.PorcentajeTurnosAnticipado); }
			set { SetColumnValue(Columns.PorcentajeTurnosAnticipado, value); }
		}
		  
		[XmlAttribute("MaximoSobreturnos")]
		[Bindable(true)]
		public int MaximoSobreturnos 
		{
			get { return GetColumnValue<int>(Columns.MaximoSobreturnos); }
			set { SetColumnValue(Columns.MaximoSobreturnos, value); }
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
		/// Returns a SysEspecialidad ActiveRecord object related to this SysRelEspecialidadEfector
		/// 
		/// </summary>
		public DalSic.SysEspecialidad SysEspecialidad
		{
			get { return DalSic.SysEspecialidad.FetchByID(this.IdEspecialidad); }
			set { SetColumnValue("idEspecialidad", value.IdEspecialidad); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysRelEspecialidadEfector
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEspecialidad,int varIdEfector,int varDuracionTurno,int varPorcentajeTurnosDia,int varPorcentajeTurnosAnticipado,int varMaximoSobreturnos,int varIdUsuarioRegistro,DateTime varFechaRegistro)
		{
			SysRelEspecialidadEfector item = new SysRelEspecialidadEfector();
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdEfector = varIdEfector;
			
			item.DuracionTurno = varDuracionTurno;
			
			item.PorcentajeTurnosDia = varPorcentajeTurnosDia;
			
			item.PorcentajeTurnosAnticipado = varPorcentajeTurnosAnticipado;
			
			item.MaximoSobreturnos = varMaximoSobreturnos;
			
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
		public static void Update(int varIdRelEspecialidadEfector,int varIdEspecialidad,int varIdEfector,int varDuracionTurno,int varPorcentajeTurnosDia,int varPorcentajeTurnosAnticipado,int varMaximoSobreturnos,int varIdUsuarioRegistro,DateTime varFechaRegistro)
		{
			SysRelEspecialidadEfector item = new SysRelEspecialidadEfector();
			
				item.IdRelEspecialidadEfector = varIdRelEspecialidadEfector;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdEfector = varIdEfector;
			
				item.DuracionTurno = varDuracionTurno;
			
				item.PorcentajeTurnosDia = varPorcentajeTurnosDia;
			
				item.PorcentajeTurnosAnticipado = varPorcentajeTurnosAnticipado;
			
				item.MaximoSobreturnos = varMaximoSobreturnos;
			
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
        
        
        public static TableSchema.TableColumn IdRelEspecialidadEfectorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DuracionTurnoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PorcentajeTurnosDiaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PorcentajeTurnosAnticipadoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MaximoSobreturnosColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelEspecialidadEfector = @"idRelEspecialidadEfector";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdEfector = @"idEfector";
			 public static string DuracionTurno = @"duracionTurno";
			 public static string PorcentajeTurnosDia = @"porcentajeTurnosDia";
			 public static string PorcentajeTurnosAnticipado = @"porcentajeTurnosAnticipado";
			 public static string MaximoSobreturnos = @"maximoSobreturnos";
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
