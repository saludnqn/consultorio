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
	/// Strongly-typed collection for the SysMovimientoHistoriaClinica class.
	/// </summary>
    [Serializable]
	public partial class SysMovimientoHistoriaClinicaCollection : ActiveList<SysMovimientoHistoriaClinica, SysMovimientoHistoriaClinicaCollection>
	{	   
		public SysMovimientoHistoriaClinicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysMovimientoHistoriaClinicaCollection</returns>
		public SysMovimientoHistoriaClinicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysMovimientoHistoriaClinica o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_MovimientoHistoriaClinica table.
	/// </summary>
	[Serializable]
	public partial class SysMovimientoHistoriaClinica : ActiveRecord<SysMovimientoHistoriaClinica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysMovimientoHistoriaClinica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysMovimientoHistoriaClinica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysMovimientoHistoriaClinica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysMovimientoHistoriaClinica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_MovimientoHistoriaClinica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMovimientoHistoriaClinica = new TableSchema.TableColumn(schema);
				colvarIdMovimientoHistoriaClinica.ColumnName = "idMovimientoHistoriaClinica";
				colvarIdMovimientoHistoriaClinica.DataType = DbType.Int32;
				colvarIdMovimientoHistoriaClinica.MaxLength = 0;
				colvarIdMovimientoHistoriaClinica.AutoIncrement = true;
				colvarIdMovimientoHistoriaClinica.IsNullable = false;
				colvarIdMovimientoHistoriaClinica.IsPrimaryKey = true;
				colvarIdMovimientoHistoriaClinica.IsForeignKey = false;
				colvarIdMovimientoHistoriaClinica.IsReadOnly = false;
				colvarIdMovimientoHistoriaClinica.DefaultSetting = @"";
				colvarIdMovimientoHistoriaClinica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMovimientoHistoriaClinica);
				
				TableSchema.TableColumn colvarIdTurno = new TableSchema.TableColumn(schema);
				colvarIdTurno.ColumnName = "idTurno";
				colvarIdTurno.DataType = DbType.Int32;
				colvarIdTurno.MaxLength = 0;
				colvarIdTurno.AutoIncrement = false;
				colvarIdTurno.IsNullable = false;
				colvarIdTurno.IsPrimaryKey = false;
				colvarIdTurno.IsForeignKey = false;
				colvarIdTurno.IsReadOnly = false;
				colvarIdTurno.DefaultSetting = @"";
				colvarIdTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurno);
				
				TableSchema.TableColumn colvarFechaMovimiento = new TableSchema.TableColumn(schema);
				colvarFechaMovimiento.ColumnName = "fechaMovimiento";
				colvarFechaMovimiento.DataType = DbType.DateTime;
				colvarFechaMovimiento.MaxLength = 0;
				colvarFechaMovimiento.AutoIncrement = false;
				colvarFechaMovimiento.IsNullable = false;
				colvarFechaMovimiento.IsPrimaryKey = false;
				colvarFechaMovimiento.IsForeignKey = false;
				colvarFechaMovimiento.IsReadOnly = false;
				
						colvarFechaMovimiento.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaMovimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaMovimiento);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = 50;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = false;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_MovimientoHistoriaClinica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMovimientoHistoriaClinica")]
		[Bindable(true)]
		public int IdMovimientoHistoriaClinica 
		{
			get { return GetColumnValue<int>(Columns.IdMovimientoHistoriaClinica); }
			set { SetColumnValue(Columns.IdMovimientoHistoriaClinica, value); }
		}
		  
		[XmlAttribute("IdTurno")]
		[Bindable(true)]
		public int IdTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTurno); }
			set { SetColumnValue(Columns.IdTurno, value); }
		}
		  
		[XmlAttribute("FechaMovimiento")]
		[Bindable(true)]
		public DateTime FechaMovimiento 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaMovimiento); }
			set { SetColumnValue(Columns.FechaMovimiento, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdTurno,DateTime varFechaMovimiento,string varUsuario)
		{
			SysMovimientoHistoriaClinica item = new SysMovimientoHistoriaClinica();
			
			item.IdTurno = varIdTurno;
			
			item.FechaMovimiento = varFechaMovimiento;
			
			item.Usuario = varUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMovimientoHistoriaClinica,int varIdTurno,DateTime varFechaMovimiento,string varUsuario)
		{
			SysMovimientoHistoriaClinica item = new SysMovimientoHistoriaClinica();
			
				item.IdMovimientoHistoriaClinica = varIdMovimientoHistoriaClinica;
			
				item.IdTurno = varIdTurno;
			
				item.FechaMovimiento = varFechaMovimiento;
			
				item.Usuario = varUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMovimientoHistoriaClinicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaMovimientoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMovimientoHistoriaClinica = @"idMovimientoHistoriaClinica";
			 public static string IdTurno = @"idTurno";
			 public static string FechaMovimiento = @"fechaMovimiento";
			 public static string Usuario = @"usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
