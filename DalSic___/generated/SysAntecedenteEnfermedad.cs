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
	/// Strongly-typed collection for the SysAntecedenteEnfermedad class.
	/// </summary>
    [Serializable]
	public partial class SysAntecedenteEnfermedadCollection : ActiveList<SysAntecedenteEnfermedad, SysAntecedenteEnfermedadCollection>
	{	   
		public SysAntecedenteEnfermedadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysAntecedenteEnfermedadCollection</returns>
		public SysAntecedenteEnfermedadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysAntecedenteEnfermedad o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_AntecedenteEnfermedad table.
	/// </summary>
	[Serializable]
	public partial class SysAntecedenteEnfermedad : ActiveRecord<SysAntecedenteEnfermedad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysAntecedenteEnfermedad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysAntecedenteEnfermedad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysAntecedenteEnfermedad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysAntecedenteEnfermedad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_AntecedenteEnfermedad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAntecedenteEnfermedad = new TableSchema.TableColumn(schema);
				colvarIdAntecedenteEnfermedad.ColumnName = "idAntecedenteEnfermedad";
				colvarIdAntecedenteEnfermedad.DataType = DbType.Int32;
				colvarIdAntecedenteEnfermedad.MaxLength = 0;
				colvarIdAntecedenteEnfermedad.AutoIncrement = true;
				colvarIdAntecedenteEnfermedad.IsNullable = false;
				colvarIdAntecedenteEnfermedad.IsPrimaryKey = true;
				colvarIdAntecedenteEnfermedad.IsForeignKey = false;
				colvarIdAntecedenteEnfermedad.IsReadOnly = false;
				colvarIdAntecedenteEnfermedad.DefaultSetting = @"";
				colvarIdAntecedenteEnfermedad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAntecedenteEnfermedad);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
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
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "FechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				colvarFechaRegistro.DefaultSetting = @"";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				TableSchema.TableColumn colvarFamiliar = new TableSchema.TableColumn(schema);
				colvarFamiliar.ColumnName = "Familiar";
				colvarFamiliar.DataType = DbType.Boolean;
				colvarFamiliar.MaxLength = 0;
				colvarFamiliar.AutoIncrement = false;
				colvarFamiliar.IsNullable = true;
				colvarFamiliar.IsPrimaryKey = false;
				colvarFamiliar.IsForeignKey = false;
				colvarFamiliar.IsReadOnly = false;
				colvarFamiliar.DefaultSetting = @"";
				colvarFamiliar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFamiliar);
				
				TableSchema.TableColumn colvarTipoParentezco = new TableSchema.TableColumn(schema);
				colvarTipoParentezco.ColumnName = "TipoParentezco";
				colvarTipoParentezco.DataType = DbType.AnsiString;
				colvarTipoParentezco.MaxLength = 50;
				colvarTipoParentezco.AutoIncrement = false;
				colvarTipoParentezco.IsNullable = true;
				colvarTipoParentezco.IsPrimaryKey = false;
				colvarTipoParentezco.IsForeignKey = false;
				colvarTipoParentezco.IsReadOnly = false;
				colvarTipoParentezco.DefaultSetting = @"";
				colvarTipoParentezco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoParentezco);
				
				TableSchema.TableColumn colvarCODCIE10 = new TableSchema.TableColumn(schema);
				colvarCODCIE10.ColumnName = "CODCIE10";
				colvarCODCIE10.DataType = DbType.Int32;
				colvarCODCIE10.MaxLength = 0;
				colvarCODCIE10.AutoIncrement = false;
				colvarCODCIE10.IsNullable = false;
				colvarCODCIE10.IsPrimaryKey = false;
				colvarCODCIE10.IsForeignKey = true;
				colvarCODCIE10.IsReadOnly = false;
				colvarCODCIE10.DefaultSetting = @"";
				
					colvarCODCIE10.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarCODCIE10);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_AntecedenteEnfermedad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAntecedenteEnfermedad")]
		[Bindable(true)]
		public int IdAntecedenteEnfermedad 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedenteEnfermedad); }
			set { SetColumnValue(Columns.IdAntecedenteEnfermedad, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("Familiar")]
		[Bindable(true)]
		public bool? Familiar 
		{
			get { return GetColumnValue<bool?>(Columns.Familiar); }
			set { SetColumnValue(Columns.Familiar, value); }
		}
		  
		[XmlAttribute("TipoParentezco")]
		[Bindable(true)]
		public string TipoParentezco 
		{
			get { return GetColumnValue<string>(Columns.TipoParentezco); }
			set { SetColumnValue(Columns.TipoParentezco, value); }
		}
		  
		[XmlAttribute("CODCIE10")]
		[Bindable(true)]
		public int CODCIE10 
		{
			get { return GetColumnValue<int>(Columns.CODCIE10); }
			set { SetColumnValue(Columns.CODCIE10, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this SysAntecedenteEnfermedad
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.CODCIE10); }
			set { SetColumnValue("CODCIE10", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this SysAntecedenteEnfermedad
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
		public static void Insert(int varIdEfector,int varIdPaciente,DateTime varFechaRegistro,bool? varFamiliar,string varTipoParentezco,int varCODCIE10)
		{
			SysAntecedenteEnfermedad item = new SysAntecedenteEnfermedad();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.Familiar = varFamiliar;
			
			item.TipoParentezco = varTipoParentezco;
			
			item.CODCIE10 = varCODCIE10;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAntecedenteEnfermedad,int varIdEfector,int varIdPaciente,DateTime varFechaRegistro,bool? varFamiliar,string varTipoParentezco,int varCODCIE10)
		{
			SysAntecedenteEnfermedad item = new SysAntecedenteEnfermedad();
			
				item.IdAntecedenteEnfermedad = varIdAntecedenteEnfermedad;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.Familiar = varFamiliar;
			
				item.TipoParentezco = varTipoParentezco;
			
				item.CODCIE10 = varCODCIE10;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAntecedenteEnfermedadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FamiliarColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoParentezcoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CODCIE10Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAntecedenteEnfermedad = @"idAntecedenteEnfermedad";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string FechaRegistro = @"FechaRegistro";
			 public static string Familiar = @"Familiar";
			 public static string TipoParentezco = @"TipoParentezco";
			 public static string CODCIE10 = @"CODCIE10";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
