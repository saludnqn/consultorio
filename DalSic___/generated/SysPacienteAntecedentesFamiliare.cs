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
	/// Strongly-typed collection for the SysPacienteAntecedentesFamiliare class.
	/// </summary>
    [Serializable]
	public partial class SysPacienteAntecedentesFamiliareCollection : ActiveList<SysPacienteAntecedentesFamiliare, SysPacienteAntecedentesFamiliareCollection>
	{	   
		public SysPacienteAntecedentesFamiliareCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysPacienteAntecedentesFamiliareCollection</returns>
		public SysPacienteAntecedentesFamiliareCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysPacienteAntecedentesFamiliare o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_PacienteAntecedentesFamiliares table.
	/// </summary>
	[Serializable]
	public partial class SysPacienteAntecedentesFamiliare : ActiveRecord<SysPacienteAntecedentesFamiliare>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysPacienteAntecedentesFamiliare()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysPacienteAntecedentesFamiliare(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysPacienteAntecedentesFamiliare(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysPacienteAntecedentesFamiliare(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_PacienteAntecedentesFamiliares", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdParentesco = new TableSchema.TableColumn(schema);
				colvarIdParentesco.ColumnName = "idParentesco";
				colvarIdParentesco.DataType = DbType.Int32;
				colvarIdParentesco.MaxLength = 0;
				colvarIdParentesco.AutoIncrement = false;
				colvarIdParentesco.IsNullable = true;
				colvarIdParentesco.IsPrimaryKey = false;
				colvarIdParentesco.IsForeignKey = false;
				colvarIdParentesco.IsReadOnly = false;
				colvarIdParentesco.DefaultSetting = @"";
				colvarIdParentesco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdParentesco);
				
				TableSchema.TableColumn colvarIdCie10 = new TableSchema.TableColumn(schema);
				colvarIdCie10.ColumnName = "idCie10";
				colvarIdCie10.DataType = DbType.Int32;
				colvarIdCie10.MaxLength = 0;
				colvarIdCie10.AutoIncrement = false;
				colvarIdCie10.IsNullable = true;
				colvarIdCie10.IsPrimaryKey = false;
				colvarIdCie10.IsForeignKey = false;
				colvarIdCie10.IsReadOnly = false;
				colvarIdCie10.DefaultSetting = @"";
				colvarIdCie10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCie10);
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "FechaCarga";
				colvarFechaCarga.DataType = DbType.DateTime;
				colvarFechaCarga.MaxLength = 0;
				colvarFechaCarga.AutoIncrement = false;
				colvarFechaCarga.IsNullable = true;
				colvarFechaCarga.IsPrimaryKey = false;
				colvarFechaCarga.IsForeignKey = false;
				colvarFechaCarga.IsReadOnly = false;
				colvarFechaCarga.DefaultSetting = @"";
				colvarFechaCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCarga);
				
				TableSchema.TableColumn colvarIdUsuarioCarga = new TableSchema.TableColumn(schema);
				colvarIdUsuarioCarga.ColumnName = "idUsuarioCarga";
				colvarIdUsuarioCarga.DataType = DbType.Int32;
				colvarIdUsuarioCarga.MaxLength = 0;
				colvarIdUsuarioCarga.AutoIncrement = false;
				colvarIdUsuarioCarga.IsNullable = true;
				colvarIdUsuarioCarga.IsPrimaryKey = false;
				colvarIdUsuarioCarga.IsForeignKey = false;
				colvarIdUsuarioCarga.IsReadOnly = false;
				colvarIdUsuarioCarga.DefaultSetting = @"";
				colvarIdUsuarioCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioCarga);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_PacienteAntecedentesFamiliares",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdParentesco")]
		[Bindable(true)]
		public int? IdParentesco 
		{
			get { return GetColumnValue<int?>(Columns.IdParentesco); }
			set { SetColumnValue(Columns.IdParentesco, value); }
		}
		  
		[XmlAttribute("IdCie10")]
		[Bindable(true)]
		public int? IdCie10 
		{
			get { return GetColumnValue<int?>(Columns.IdCie10); }
			set { SetColumnValue(Columns.IdCie10, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("IdUsuarioCarga")]
		[Bindable(true)]
		public int? IdUsuarioCarga 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuarioCarga); }
			set { SetColumnValue(Columns.IdUsuarioCarga, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdPaciente,int? varIdParentesco,int? varIdCie10,DateTime? varFechaCarga,int? varIdUsuarioCarga)
		{
			SysPacienteAntecedentesFamiliare item = new SysPacienteAntecedentesFamiliare();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdParentesco = varIdParentesco;
			
			item.IdCie10 = varIdCie10;
			
			item.FechaCarga = varFechaCarga;
			
			item.IdUsuarioCarga = varIdUsuarioCarga;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdPaciente,int? varIdParentesco,int? varIdCie10,DateTime? varFechaCarga,int? varIdUsuarioCarga)
		{
			SysPacienteAntecedentesFamiliare item = new SysPacienteAntecedentesFamiliare();
			
				item.Id = varId;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdParentesco = varIdParentesco;
			
				item.IdCie10 = varIdCie10;
			
				item.FechaCarga = varFechaCarga;
			
				item.IdUsuarioCarga = varIdUsuarioCarga;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdParentescoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCie10Column
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioCargaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdParentesco = @"idParentesco";
			 public static string IdCie10 = @"idCie10";
			 public static string FechaCarga = @"FechaCarga";
			 public static string IdUsuarioCarga = @"idUsuarioCarga";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
