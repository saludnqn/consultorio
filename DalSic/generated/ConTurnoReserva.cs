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
	/// Strongly-typed collection for the ConTurnoReserva class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoReservaCollection : ActiveList<ConTurnoReserva, ConTurnoReservaCollection>
	{	   
		public ConTurnoReservaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoReservaCollection</returns>
		public ConTurnoReservaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoReserva o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoReserva table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoReserva : ActiveRecord<ConTurnoReserva>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoReserva()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoReserva(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoReserva(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoReserva(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoReserva", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdReserva = new TableSchema.TableColumn(schema);
				colvarIdReserva.ColumnName = "idReserva";
				colvarIdReserva.DataType = DbType.Int32;
				colvarIdReserva.MaxLength = 0;
				colvarIdReserva.AutoIncrement = true;
				colvarIdReserva.IsNullable = false;
				colvarIdReserva.IsPrimaryKey = true;
				colvarIdReserva.IsForeignKey = false;
				colvarIdReserva.IsReadOnly = false;
				colvarIdReserva.DefaultSetting = @"";
				colvarIdReserva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdReserva);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = true;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				
					colvarIdUsuario.ForeignKeyTableName = "Sys_Usuario";
				schema.Columns.Add(colvarIdUsuario);
				
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
				
				TableSchema.TableColumn colvarIdTurno = new TableSchema.TableColumn(schema);
				colvarIdTurno.ColumnName = "idTurno";
				colvarIdTurno.DataType = DbType.Int32;
				colvarIdTurno.MaxLength = 0;
				colvarIdTurno.AutoIncrement = false;
				colvarIdTurno.IsNullable = false;
				colvarIdTurno.IsPrimaryKey = false;
				colvarIdTurno.IsForeignKey = true;
				colvarIdTurno.IsReadOnly = false;
				colvarIdTurno.DefaultSetting = @"";
				
					colvarIdTurno.ForeignKeyTableName = "CON_Turno";
				schema.Columns.Add(colvarIdTurno);
				
				TableSchema.TableColumn colvarReservaHasta = new TableSchema.TableColumn(schema);
				colvarReservaHasta.ColumnName = "reservaHasta";
				colvarReservaHasta.DataType = DbType.DateTime;
				colvarReservaHasta.MaxLength = 0;
				colvarReservaHasta.AutoIncrement = false;
				colvarReservaHasta.IsNullable = false;
				colvarReservaHasta.IsPrimaryKey = false;
				colvarReservaHasta.IsForeignKey = false;
				colvarReservaHasta.IsReadOnly = false;
				colvarReservaHasta.DefaultSetting = @"";
				colvarReservaHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReservaHasta);
				
				TableSchema.TableColumn colvarCofirmoTurno = new TableSchema.TableColumn(schema);
				colvarCofirmoTurno.ColumnName = "cofirmoTurno";
				colvarCofirmoTurno.DataType = DbType.Boolean;
				colvarCofirmoTurno.MaxLength = 0;
				colvarCofirmoTurno.AutoIncrement = false;
				colvarCofirmoTurno.IsNullable = false;
				colvarCofirmoTurno.IsPrimaryKey = false;
				colvarCofirmoTurno.IsForeignKey = false;
				colvarCofirmoTurno.IsReadOnly = false;
				
						colvarCofirmoTurno.DefaultSetting = @"((0))";
				colvarCofirmoTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCofirmoTurno);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoReserva",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdReserva")]
		[Bindable(true)]
		public int IdReserva 
		{
			get { return GetColumnValue<int>(Columns.IdReserva); }
			set { SetColumnValue(Columns.IdReserva, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdTurno")]
		[Bindable(true)]
		public int IdTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTurno); }
			set { SetColumnValue(Columns.IdTurno, value); }
		}
		  
		[XmlAttribute("ReservaHasta")]
		[Bindable(true)]
		public DateTime ReservaHasta 
		{
			get { return GetColumnValue<DateTime>(Columns.ReservaHasta); }
			set { SetColumnValue(Columns.ReservaHasta, value); }
		}
		  
		[XmlAttribute("CofirmoTurno")]
		[Bindable(true)]
		public bool CofirmoTurno 
		{
			get { return GetColumnValue<bool>(Columns.CofirmoTurno); }
			set { SetColumnValue(Columns.CofirmoTurno, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this ConTurnoReserva
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysUsuario ActiveRecord object related to this ConTurnoReserva
		/// 
		/// </summary>
		public DalSic.SysUsuario SysUsuario
		{
			get { return DalSic.SysUsuario.FetchByID(this.IdUsuario); }
			set { SetColumnValue("idUsuario", value.IdUsuario); }
		}
		
		
		/// <summary>
		/// Returns a ConTurno ActiveRecord object related to this ConTurnoReserva
		/// 
		/// </summary>
		public DalSic.ConTurno ConTurno
		{
			get { return DalSic.ConTurno.FetchByID(this.IdTurno); }
			set { SetColumnValue("idTurno", value.IdTurno); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdUsuario,int varIdPaciente,int varIdTurno,DateTime varReservaHasta,bool varCofirmoTurno)
		{
			ConTurnoReserva item = new ConTurnoReserva();
			
			item.IdUsuario = varIdUsuario;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdTurno = varIdTurno;
			
			item.ReservaHasta = varReservaHasta;
			
			item.CofirmoTurno = varCofirmoTurno;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdReserva,int varIdUsuario,int varIdPaciente,int varIdTurno,DateTime varReservaHasta,bool varCofirmoTurno)
		{
			ConTurnoReserva item = new ConTurnoReserva();
			
				item.IdReserva = varIdReserva;
			
				item.IdUsuario = varIdUsuario;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdTurno = varIdTurno;
			
				item.ReservaHasta = varReservaHasta;
			
				item.CofirmoTurno = varCofirmoTurno;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdReservaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ReservaHastaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CofirmoTurnoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdReserva = @"idReserva";
			 public static string IdUsuario = @"idUsuario";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdTurno = @"idTurno";
			 public static string ReservaHasta = @"reservaHasta";
			 public static string CofirmoTurno = @"cofirmoTurno";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
