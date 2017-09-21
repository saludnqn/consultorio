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
	/// Strongly-typed collection for the ConTurnoAsistencium class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoAsistenciumCollection : ActiveList<ConTurnoAsistencium, ConTurnoAsistenciumCollection>
	{	   
		public ConTurnoAsistenciumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoAsistenciumCollection</returns>
		public ConTurnoAsistenciumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoAsistencium o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoAsistencia table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoAsistencium : ActiveRecord<ConTurnoAsistencium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoAsistencium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoAsistencium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoAsistencium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoAsistencium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoAsistencia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAsistencia = new TableSchema.TableColumn(schema);
				colvarIdAsistencia.ColumnName = "idAsistencia";
				colvarIdAsistencia.DataType = DbType.Int32;
				colvarIdAsistencia.MaxLength = 0;
				colvarIdAsistencia.AutoIncrement = true;
				colvarIdAsistencia.IsNullable = false;
				colvarIdAsistencia.IsPrimaryKey = true;
				colvarIdAsistencia.IsForeignKey = false;
				colvarIdAsistencia.IsReadOnly = false;
				colvarIdAsistencia.DefaultSetting = @"";
				colvarIdAsistencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAsistencia);
				
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
				
				TableSchema.TableColumn colvarFechaAsistencia = new TableSchema.TableColumn(schema);
				colvarFechaAsistencia.ColumnName = "fechaAsistencia";
				colvarFechaAsistencia.DataType = DbType.DateTime;
				colvarFechaAsistencia.MaxLength = 0;
				colvarFechaAsistencia.AutoIncrement = false;
				colvarFechaAsistencia.IsNullable = false;
				colvarFechaAsistencia.IsPrimaryKey = false;
				colvarFechaAsistencia.IsForeignKey = false;
				colvarFechaAsistencia.IsReadOnly = false;
				colvarFechaAsistencia.DefaultSetting = @"";
				colvarFechaAsistencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAsistencia);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoAsistencia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAsistencia")]
		[Bindable(true)]
		public int IdAsistencia 
		{
			get { return GetColumnValue<int>(Columns.IdAsistencia); }
			set { SetColumnValue(Columns.IdAsistencia, value); }
		}
		  
		[XmlAttribute("IdTurno")]
		[Bindable(true)]
		public int IdTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTurno); }
			set { SetColumnValue(Columns.IdTurno, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaAsistencia")]
		[Bindable(true)]
		public DateTime FechaAsistencia 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAsistencia); }
			set { SetColumnValue(Columns.FechaAsistencia, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConTurno ActiveRecord object related to this ConTurnoAsistencium
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
		public static void Insert(int varIdTurno,int varIdUsuario,DateTime varFechaAsistencia)
		{
			ConTurnoAsistencium item = new ConTurnoAsistencium();
			
			item.IdTurno = varIdTurno;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaAsistencia = varFechaAsistencia;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAsistencia,int varIdTurno,int varIdUsuario,DateTime varFechaAsistencia)
		{
			ConTurnoAsistencium item = new ConTurnoAsistencium();
			
				item.IdAsistencia = varIdAsistencia;
			
				item.IdTurno = varIdTurno;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaAsistencia = varFechaAsistencia;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAsistenciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAsistenciaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAsistencia = @"idAsistencia";
			 public static string IdTurno = @"idTurno";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaAsistencia = @"fechaAsistencia";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
