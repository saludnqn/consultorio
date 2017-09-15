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
	/// Strongly-typed collection for the SysRelPacienteObraSocial class.
	/// </summary>
    [Serializable]
	public partial class SysRelPacienteObraSocialCollection : ActiveList<SysRelPacienteObraSocial, SysRelPacienteObraSocialCollection>
	{	   
		public SysRelPacienteObraSocialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysRelPacienteObraSocialCollection</returns>
		public SysRelPacienteObraSocialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysRelPacienteObraSocial o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_RelPacienteObraSocial table.
	/// </summary>
	[Serializable]
	public partial class SysRelPacienteObraSocial : ActiveRecord<SysRelPacienteObraSocial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysRelPacienteObraSocial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysRelPacienteObraSocial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysRelPacienteObraSocial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysRelPacienteObraSocial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_RelPacienteObraSocial", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelPacienteObraSocial = new TableSchema.TableColumn(schema);
				colvarIdRelPacienteObraSocial.ColumnName = "idRelPacienteObraSocial";
				colvarIdRelPacienteObraSocial.DataType = DbType.Int32;
				colvarIdRelPacienteObraSocial.MaxLength = 0;
				colvarIdRelPacienteObraSocial.AutoIncrement = true;
				colvarIdRelPacienteObraSocial.IsNullable = false;
				colvarIdRelPacienteObraSocial.IsPrimaryKey = true;
				colvarIdRelPacienteObraSocial.IsForeignKey = false;
				colvarIdRelPacienteObraSocial.IsReadOnly = false;
				colvarIdRelPacienteObraSocial.DefaultSetting = @"";
				colvarIdRelPacienteObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelPacienteObraSocial);
				
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
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = false;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = true;
				colvarIdObraSocial.IsReadOnly = false;
				colvarIdObraSocial.DefaultSetting = @"";
				
					colvarIdObraSocial.ForeignKeyTableName = "Sys_ObraSocial";
				schema.Columns.Add(colvarIdObraSocial);
				
				TableSchema.TableColumn colvarNumeroAfiliado = new TableSchema.TableColumn(schema);
				colvarNumeroAfiliado.ColumnName = "numeroAfiliado";
				colvarNumeroAfiliado.DataType = DbType.AnsiString;
				colvarNumeroAfiliado.MaxLength = 50;
				colvarNumeroAfiliado.AutoIncrement = false;
				colvarNumeroAfiliado.IsNullable = false;
				colvarNumeroAfiliado.IsPrimaryKey = false;
				colvarNumeroAfiliado.IsForeignKey = false;
				colvarNumeroAfiliado.IsReadOnly = false;
				colvarNumeroAfiliado.DefaultSetting = @"";
				colvarNumeroAfiliado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroAfiliado);
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fechaAlta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = false;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				colvarFechaAlta.DefaultSetting = @"";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_RelPacienteObraSocial",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelPacienteObraSocial")]
		[Bindable(true)]
		public int IdRelPacienteObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdRelPacienteObraSocial); }
			set { SetColumnValue(Columns.IdRelPacienteObraSocial, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int IdObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("NumeroAfiliado")]
		[Bindable(true)]
		public string NumeroAfiliado 
		{
			get { return GetColumnValue<string>(Columns.NumeroAfiliado); }
			set { SetColumnValue(Columns.NumeroAfiliado, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime FechaAlta 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysObraSocial ActiveRecord object related to this SysRelPacienteObraSocial
		/// 
		/// </summary>
		public DalSic.SysObraSocial SysObraSocial
		{
			get { return DalSic.SysObraSocial.FetchByID(this.IdObraSocial); }
			set { SetColumnValue("idObraSocial", value.IdObraSocial); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this SysRelPacienteObraSocial
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
		public static void Insert(int varIdPaciente,int varIdObraSocial,string varNumeroAfiliado,DateTime varFechaAlta)
		{
			SysRelPacienteObraSocial item = new SysRelPacienteObraSocial();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdObraSocial = varIdObraSocial;
			
			item.NumeroAfiliado = varNumeroAfiliado;
			
			item.FechaAlta = varFechaAlta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelPacienteObraSocial,int varIdPaciente,int varIdObraSocial,string varNumeroAfiliado,DateTime varFechaAlta)
		{
			SysRelPacienteObraSocial item = new SysRelPacienteObraSocial();
			
				item.IdRelPacienteObraSocial = varIdRelPacienteObraSocial;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdObraSocial = varIdObraSocial;
			
				item.NumeroAfiliado = varNumeroAfiliado;
			
				item.FechaAlta = varFechaAlta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelPacienteObraSocialColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroAfiliadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelPacienteObraSocial = @"idRelPacienteObraSocial";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdObraSocial = @"idObraSocial";
			 public static string NumeroAfiliado = @"numeroAfiliado";
			 public static string FechaAlta = @"fechaAlta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
