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
	/// Strongly-typed collection for the SysHistoriaClinica class.
	/// </summary>
    [Serializable]
	public partial class SysHistoriaClinicaCollection : ActiveList<SysHistoriaClinica, SysHistoriaClinicaCollection>
	{	   
		public SysHistoriaClinicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysHistoriaClinicaCollection</returns>
		public SysHistoriaClinicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysHistoriaClinica o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_HistoriaClinica table.
	/// </summary>
	[Serializable]
	public partial class SysHistoriaClinica : ActiveRecord<SysHistoriaClinica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysHistoriaClinica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysHistoriaClinica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysHistoriaClinica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysHistoriaClinica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_HistoriaClinica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHistoriaClinica = new TableSchema.TableColumn(schema);
				colvarIdHistoriaClinica.ColumnName = "idHistoriaClinica";
				colvarIdHistoriaClinica.DataType = DbType.Int32;
				colvarIdHistoriaClinica.MaxLength = 0;
				colvarIdHistoriaClinica.AutoIncrement = true;
				colvarIdHistoriaClinica.IsNullable = false;
				colvarIdHistoriaClinica.IsPrimaryKey = true;
				colvarIdHistoriaClinica.IsForeignKey = false;
				colvarIdHistoriaClinica.IsReadOnly = false;
				colvarIdHistoriaClinica.DefaultSetting = @"";
				colvarIdHistoriaClinica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHistoriaClinica);
				
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
				
				TableSchema.TableColumn colvarIdEstadoHistoriaClinica = new TableSchema.TableColumn(schema);
				colvarIdEstadoHistoriaClinica.ColumnName = "idEstadoHistoriaClinica";
				colvarIdEstadoHistoriaClinica.DataType = DbType.Int32;
				colvarIdEstadoHistoriaClinica.MaxLength = 0;
				colvarIdEstadoHistoriaClinica.AutoIncrement = false;
				colvarIdEstadoHistoriaClinica.IsNullable = true;
				colvarIdEstadoHistoriaClinica.IsPrimaryKey = false;
				colvarIdEstadoHistoriaClinica.IsForeignKey = false;
				colvarIdEstadoHistoriaClinica.IsReadOnly = false;
				colvarIdEstadoHistoriaClinica.DefaultSetting = @"";
				colvarIdEstadoHistoriaClinica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadoHistoriaClinica);
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fechaAlta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = true;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				colvarFechaAlta.DefaultSetting = @"";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
				TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
				colvarNumero.ColumnName = "numero";
				colvarNumero.DataType = DbType.Int32;
				colvarNumero.MaxLength = 0;
				colvarNumero.AutoIncrement = false;
				colvarNumero.IsNullable = true;
				colvarNumero.IsPrimaryKey = false;
				colvarNumero.IsForeignKey = false;
				colvarNumero.IsReadOnly = false;
				colvarNumero.DefaultSetting = @"";
				colvarNumero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumero);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_HistoriaClinica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHistoriaClinica")]
		[Bindable(true)]
		public int IdHistoriaClinica 
		{
			get { return GetColumnValue<int>(Columns.IdHistoriaClinica); }
			set { SetColumnValue(Columns.IdHistoriaClinica, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdEstadoHistoriaClinica")]
		[Bindable(true)]
		public int? IdEstadoHistoriaClinica 
		{
			get { return GetColumnValue<int?>(Columns.IdEstadoHistoriaClinica); }
			set { SetColumnValue(Columns.IdEstadoHistoriaClinica, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime? FechaAlta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		  
		[XmlAttribute("Numero")]
		[Bindable(true)]
		public int? Numero 
		{
			get { return GetColumnValue<int?>(Columns.Numero); }
			set { SetColumnValue(Columns.Numero, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this SysHistoriaClinica
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
		public static void Insert(int? varIdPaciente,int? varIdEstadoHistoriaClinica,DateTime? varFechaAlta,int? varNumero)
		{
			SysHistoriaClinica item = new SysHistoriaClinica();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdEstadoHistoriaClinica = varIdEstadoHistoriaClinica;
			
			item.FechaAlta = varFechaAlta;
			
			item.Numero = varNumero;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdHistoriaClinica,int? varIdPaciente,int? varIdEstadoHistoriaClinica,DateTime? varFechaAlta,int? varNumero)
		{
			SysHistoriaClinica item = new SysHistoriaClinica();
			
				item.IdHistoriaClinica = varIdHistoriaClinica;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdEstadoHistoriaClinica = varIdEstadoHistoriaClinica;
			
				item.FechaAlta = varFechaAlta;
			
				item.Numero = varNumero;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHistoriaClinicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoHistoriaClinicaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHistoriaClinica = @"idHistoriaClinica";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdEstadoHistoriaClinica = @"idEstadoHistoriaClinica";
			 public static string FechaAlta = @"fechaAlta";
			 public static string Numero = @"numero";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
