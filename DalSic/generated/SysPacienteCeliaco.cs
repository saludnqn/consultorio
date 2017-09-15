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
	/// Strongly-typed collection for the SysPacienteCeliaco class.
	/// </summary>
    [Serializable]
	public partial class SysPacienteCeliacoCollection : ActiveList<SysPacienteCeliaco, SysPacienteCeliacoCollection>
	{	   
		public SysPacienteCeliacoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysPacienteCeliacoCollection</returns>
		public SysPacienteCeliacoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysPacienteCeliaco o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_PacienteCeliaco table.
	/// </summary>
	[Serializable]
	public partial class SysPacienteCeliaco : ActiveRecord<SysPacienteCeliaco>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysPacienteCeliaco()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysPacienteCeliaco(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysPacienteCeliaco(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysPacienteCeliaco(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_PacienteCeliaco", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPacienteCeliaco = new TableSchema.TableColumn(schema);
				colvarIdPacienteCeliaco.ColumnName = "idPacienteCeliaco";
				colvarIdPacienteCeliaco.DataType = DbType.Int32;
				colvarIdPacienteCeliaco.MaxLength = 0;
				colvarIdPacienteCeliaco.AutoIncrement = true;
				colvarIdPacienteCeliaco.IsNullable = false;
				colvarIdPacienteCeliaco.IsPrimaryKey = true;
				colvarIdPacienteCeliaco.IsForeignKey = false;
				colvarIdPacienteCeliaco.IsReadOnly = false;
				colvarIdPacienteCeliaco.DefaultSetting = @"";
				colvarIdPacienteCeliaco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPacienteCeliaco);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.String;
				colvarActivo.MaxLength = 50;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_PacienteCeliaco",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPacienteCeliaco")]
		[Bindable(true)]
		public int IdPacienteCeliaco 
		{
			get { return GetColumnValue<int>(Columns.IdPacienteCeliaco); }
			set { SetColumnValue(Columns.IdPacienteCeliaco, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public string Activo 
		{
			get { return GetColumnValue<string>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime FechaAlta 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,string varActivo,DateTime varFechaAlta)
		{
			SysPacienteCeliaco item = new SysPacienteCeliaco();
			
			item.IdPaciente = varIdPaciente;
			
			item.Activo = varActivo;
			
			item.FechaAlta = varFechaAlta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPacienteCeliaco,int varIdPaciente,string varActivo,DateTime varFechaAlta)
		{
			SysPacienteCeliaco item = new SysPacienteCeliaco();
			
				item.IdPacienteCeliaco = varIdPacienteCeliaco;
			
				item.IdPaciente = varIdPaciente;
			
				item.Activo = varActivo;
			
				item.FechaAlta = varFechaAlta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPacienteCeliacoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPacienteCeliaco = @"idPacienteCeliaco";
			 public static string IdPaciente = @"idPaciente";
			 public static string Activo = @"activo";
			 public static string FechaAlta = @"fechaAlta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
