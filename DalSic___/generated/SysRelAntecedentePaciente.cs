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
	/// Strongly-typed collection for the SysRelAntecedentePaciente class.
	/// </summary>
    [Serializable]
	public partial class SysRelAntecedentePacienteCollection : ActiveList<SysRelAntecedentePaciente, SysRelAntecedentePacienteCollection>
	{	   
		public SysRelAntecedentePacienteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelAntecedentePacienteCollection</returns>
		public SysRelAntecedentePacienteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelAntecedentePaciente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelAntecedentePaciente table.
	/// </summary>
	[Serializable]
	public partial class SysRelAntecedentePaciente : ActiveRecord<SysRelAntecedentePaciente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelAntecedentePaciente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelAntecedentePaciente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelAntecedentePaciente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelAntecedentePaciente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelAntecedentePaciente", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelAntecedentePaciente = new TableSchema.TableColumn(schema);
				colvarIdRelAntecedentePaciente.ColumnName = "idRelAntecedentePaciente";
				colvarIdRelAntecedentePaciente.DataType = DbType.Int32;
				colvarIdRelAntecedentePaciente.MaxLength = 0;
				colvarIdRelAntecedentePaciente.AutoIncrement = true;
				colvarIdRelAntecedentePaciente.IsNullable = false;
				colvarIdRelAntecedentePaciente.IsPrimaryKey = true;
				colvarIdRelAntecedentePaciente.IsForeignKey = false;
				colvarIdRelAntecedentePaciente.IsReadOnly = false;
				colvarIdRelAntecedentePaciente.DefaultSetting = @"";
				colvarIdRelAntecedentePaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelAntecedentePaciente);
				
				TableSchema.TableColumn colvarIdAntecedente = new TableSchema.TableColumn(schema);
				colvarIdAntecedente.ColumnName = "idAntecedente";
				colvarIdAntecedente.DataType = DbType.Int32;
				colvarIdAntecedente.MaxLength = 0;
				colvarIdAntecedente.AutoIncrement = false;
				colvarIdAntecedente.IsNullable = true;
				colvarIdAntecedente.IsPrimaryKey = false;
				colvarIdAntecedente.IsForeignKey = true;
				colvarIdAntecedente.IsReadOnly = false;
				colvarIdAntecedente.DefaultSetting = @"";
				
					colvarIdAntecedente.ForeignKeyTableName = "Sys_Antecedente";
				schema.Columns.Add(colvarIdAntecedente);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "idClasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = false;
				colvarIdClasificacion.IsNullable = true;
				colvarIdClasificacion.IsPrimaryKey = false;
				colvarIdClasificacion.IsForeignKey = true;
				colvarIdClasificacion.IsReadOnly = false;
				colvarIdClasificacion.DefaultSetting = @"";
				
					colvarIdClasificacion.ForeignKeyTableName = "Rem_Clasificacion";
				schema.Columns.Add(colvarIdClasificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelAntecedentePaciente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelAntecedentePaciente")]
		[Bindable(true)]
		public int IdRelAntecedentePaciente 
		{
			get { return GetColumnValue<int>(Columns.IdRelAntecedentePaciente); }
			set { SetColumnValue(Columns.IdRelAntecedentePaciente, value); }
		}
		  
		[XmlAttribute("IdAntecedente")]
		[Bindable(true)]
		public int? IdAntecedente 
		{
			get { return GetColumnValue<int?>(Columns.IdAntecedente); }
			set { SetColumnValue(Columns.IdAntecedente, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int? IdClasificacion 
		{
			get { return GetColumnValue<int?>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysAntecedente ActiveRecord object related to this SysRelAntecedentePaciente
		/// 
		/// </summary>
		public DalSic.SysAntecedente SysAntecedente
		{
			get { return DalSic.SysAntecedente.FetchByID(this.IdAntecedente); }
			set { SetColumnValue("idAntecedente", value.IdAntecedente); }
		}
		
		
		/// <summary>
		/// Returns a RemClasificacion ActiveRecord object related to this SysRelAntecedentePaciente
		/// 
		/// </summary>
		public DalSic.RemClasificacion RemClasificacion
		{
			get { return DalSic.RemClasificacion.FetchByID(this.IdClasificacion); }
			set { SetColumnValue("idClasificacion", value.IdClasificacion); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this SysRelAntecedentePaciente
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdAntecedente,int? varIdPaciente,int? varIdClasificacion)
		{
			SysRelAntecedentePaciente item = new SysRelAntecedentePaciente();
			
			item.IdAntecedente = varIdAntecedente;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdClasificacion = varIdClasificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelAntecedentePaciente,int? varIdAntecedente,int? varIdPaciente,int? varIdClasificacion)
		{
			SysRelAntecedentePaciente item = new SysRelAntecedentePaciente();
			
				item.IdRelAntecedentePaciente = varIdRelAntecedentePaciente;
			
				item.IdAntecedente = varIdAntecedente;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdClasificacion = varIdClasificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelAntecedentePacienteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAntecedenteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelAntecedentePaciente = @"idRelAntecedentePaciente";
			 public static string IdAntecedente = @"idAntecedente";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdClasificacion = @"idClasificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
