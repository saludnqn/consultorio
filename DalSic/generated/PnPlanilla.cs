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
	/// Strongly-typed collection for the PnPlanilla class.
	/// </summary>
    [Serializable]
	public partial class PnPlanillaCollection : ActiveList<PnPlanilla, PnPlanillaCollection>
	{	   
		public PnPlanillaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPlanillaCollection</returns>
		public PnPlanillaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPlanilla o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_planillas table.
	/// </summary>
	[Serializable]
	public partial class PnPlanilla : ActiveRecord<PnPlanilla>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPlanilla()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPlanilla(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPlanilla(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPlanilla(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_planillas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPlanillas = new TableSchema.TableColumn(schema);
				colvarIdPlanillas.ColumnName = "id_planillas";
				colvarIdPlanillas.DataType = DbType.Int32;
				colvarIdPlanillas.MaxLength = 0;
				colvarIdPlanillas.AutoIncrement = true;
				colvarIdPlanillas.IsNullable = false;
				colvarIdPlanillas.IsPrimaryKey = true;
				colvarIdPlanillas.IsForeignKey = false;
				colvarIdPlanillas.IsReadOnly = false;
				colvarIdPlanillas.DefaultSetting = @"";
				colvarIdPlanillas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPlanillas);
				
				TableSchema.TableColumn colvarIdAgenteInscriptor = new TableSchema.TableColumn(schema);
				colvarIdAgenteInscriptor.ColumnName = "id_agente_inscriptor";
				colvarIdAgenteInscriptor.DataType = DbType.Int32;
				colvarIdAgenteInscriptor.MaxLength = 0;
				colvarIdAgenteInscriptor.AutoIncrement = false;
				colvarIdAgenteInscriptor.IsNullable = false;
				colvarIdAgenteInscriptor.IsPrimaryKey = false;
				colvarIdAgenteInscriptor.IsForeignKey = false;
				colvarIdAgenteInscriptor.IsReadOnly = false;
				colvarIdAgenteInscriptor.DefaultSetting = @"";
				colvarIdAgenteInscriptor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgenteInscriptor);
				
				TableSchema.TableColumn colvarIdEntrega = new TableSchema.TableColumn(schema);
				colvarIdEntrega.ColumnName = "id_entrega";
				colvarIdEntrega.DataType = DbType.Int32;
				colvarIdEntrega.MaxLength = 0;
				colvarIdEntrega.AutoIncrement = false;
				colvarIdEntrega.IsNullable = false;
				colvarIdEntrega.IsPrimaryKey = false;
				colvarIdEntrega.IsForeignKey = false;
				colvarIdEntrega.IsReadOnly = false;
				colvarIdEntrega.DefaultSetting = @"";
				colvarIdEntrega.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEntrega);
				
				TableSchema.TableColumn colvarIdRecibe = new TableSchema.TableColumn(schema);
				colvarIdRecibe.ColumnName = "id_recibe";
				colvarIdRecibe.DataType = DbType.Int32;
				colvarIdRecibe.MaxLength = 0;
				colvarIdRecibe.AutoIncrement = false;
				colvarIdRecibe.IsNullable = false;
				colvarIdRecibe.IsPrimaryKey = false;
				colvarIdRecibe.IsForeignKey = false;
				colvarIdRecibe.IsReadOnly = false;
				colvarIdRecibe.DefaultSetting = @"";
				colvarIdRecibe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRecibe);
				
				TableSchema.TableColumn colvarPeriodo = new TableSchema.TableColumn(schema);
				colvarPeriodo.ColumnName = "periodo";
				colvarPeriodo.DataType = DbType.AnsiString;
				colvarPeriodo.MaxLength = -1;
				colvarPeriodo.AutoIncrement = false;
				colvarPeriodo.IsNullable = true;
				colvarPeriodo.IsPrimaryKey = false;
				colvarPeriodo.IsForeignKey = false;
				colvarPeriodo.IsReadOnly = false;
				colvarPeriodo.DefaultSetting = @"";
				colvarPeriodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodo);
				
				TableSchema.TableColumn colvarCantNino = new TableSchema.TableColumn(schema);
				colvarCantNino.ColumnName = "cant_nino";
				colvarCantNino.DataType = DbType.Int32;
				colvarCantNino.MaxLength = 0;
				colvarCantNino.AutoIncrement = false;
				colvarCantNino.IsNullable = true;
				colvarCantNino.IsPrimaryKey = false;
				colvarCantNino.IsForeignKey = false;
				colvarCantNino.IsReadOnly = false;
				colvarCantNino.DefaultSetting = @"";
				colvarCantNino.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantNino);
				
				TableSchema.TableColumn colvarCantEmbarazada = new TableSchema.TableColumn(schema);
				colvarCantEmbarazada.ColumnName = "cant_embarazada";
				colvarCantEmbarazada.DataType = DbType.Int32;
				colvarCantEmbarazada.MaxLength = 0;
				colvarCantEmbarazada.AutoIncrement = false;
				colvarCantEmbarazada.IsNullable = true;
				colvarCantEmbarazada.IsPrimaryKey = false;
				colvarCantEmbarazada.IsForeignKey = false;
				colvarCantEmbarazada.IsReadOnly = false;
				colvarCantEmbarazada.DefaultSetting = @"";
				colvarCantEmbarazada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantEmbarazada);
				
				TableSchema.TableColumn colvarMotivo = new TableSchema.TableColumn(schema);
				colvarMotivo.ColumnName = "motivo";
				colvarMotivo.DataType = DbType.AnsiString;
				colvarMotivo.MaxLength = -1;
				colvarMotivo.AutoIncrement = false;
				colvarMotivo.IsNullable = true;
				colvarMotivo.IsPrimaryKey = false;
				colvarMotivo.IsForeignKey = false;
				colvarMotivo.IsReadOnly = false;
				colvarMotivo.DefaultSetting = @"";
				colvarMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivo);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = -1;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.AnsiString;
				colvarTipo.MaxLength = -1;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "id_efector";
				colvarIdEfector.DataType = DbType.AnsiString;
				colvarIdEfector.MaxLength = -1;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
				colvarFechaHora.ColumnName = "fecha_hora";
				colvarFechaHora.DataType = DbType.DateTime;
				colvarFechaHora.MaxLength = 0;
				colvarFechaHora.AutoIncrement = false;
				colvarFechaHora.IsNullable = true;
				colvarFechaHora.IsPrimaryKey = false;
				colvarFechaHora.IsForeignKey = false;
				colvarFechaHora.IsReadOnly = false;
				colvarFechaHora.DefaultSetting = @"";
				colvarFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHora);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_planillas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPlanillas")]
		[Bindable(true)]
		public int IdPlanillas 
		{
			get { return GetColumnValue<int>(Columns.IdPlanillas); }
			set { SetColumnValue(Columns.IdPlanillas, value); }
		}
		  
		[XmlAttribute("IdAgenteInscriptor")]
		[Bindable(true)]
		public int IdAgenteInscriptor 
		{
			get { return GetColumnValue<int>(Columns.IdAgenteInscriptor); }
			set { SetColumnValue(Columns.IdAgenteInscriptor, value); }
		}
		  
		[XmlAttribute("IdEntrega")]
		[Bindable(true)]
		public int IdEntrega 
		{
			get { return GetColumnValue<int>(Columns.IdEntrega); }
			set { SetColumnValue(Columns.IdEntrega, value); }
		}
		  
		[XmlAttribute("IdRecibe")]
		[Bindable(true)]
		public int IdRecibe 
		{
			get { return GetColumnValue<int>(Columns.IdRecibe); }
			set { SetColumnValue(Columns.IdRecibe, value); }
		}
		  
		[XmlAttribute("Periodo")]
		[Bindable(true)]
		public string Periodo 
		{
			get { return GetColumnValue<string>(Columns.Periodo); }
			set { SetColumnValue(Columns.Periodo, value); }
		}
		  
		[XmlAttribute("CantNino")]
		[Bindable(true)]
		public int? CantNino 
		{
			get { return GetColumnValue<int?>(Columns.CantNino); }
			set { SetColumnValue(Columns.CantNino, value); }
		}
		  
		[XmlAttribute("CantEmbarazada")]
		[Bindable(true)]
		public int? CantEmbarazada 
		{
			get { return GetColumnValue<int?>(Columns.CantEmbarazada); }
			set { SetColumnValue(Columns.CantEmbarazada, value); }
		}
		  
		[XmlAttribute("Motivo")]
		[Bindable(true)]
		public string Motivo 
		{
			get { return GetColumnValue<string>(Columns.Motivo); }
			set { SetColumnValue(Columns.Motivo, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public string IdEfector 
		{
			get { return GetColumnValue<string>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("FechaHora")]
		[Bindable(true)]
		public DateTime? FechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaHora); }
			set { SetColumnValue(Columns.FechaHora, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgenteInscriptor,int varIdEntrega,int varIdRecibe,string varPeriodo,int? varCantNino,int? varCantEmbarazada,string varMotivo,string varUsuario,string varTipo,string varIdEfector,DateTime? varFechaHora)
		{
			PnPlanilla item = new PnPlanilla();
			
			item.IdAgenteInscriptor = varIdAgenteInscriptor;
			
			item.IdEntrega = varIdEntrega;
			
			item.IdRecibe = varIdRecibe;
			
			item.Periodo = varPeriodo;
			
			item.CantNino = varCantNino;
			
			item.CantEmbarazada = varCantEmbarazada;
			
			item.Motivo = varMotivo;
			
			item.Usuario = varUsuario;
			
			item.Tipo = varTipo;
			
			item.IdEfector = varIdEfector;
			
			item.FechaHora = varFechaHora;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPlanillas,int varIdAgenteInscriptor,int varIdEntrega,int varIdRecibe,string varPeriodo,int? varCantNino,int? varCantEmbarazada,string varMotivo,string varUsuario,string varTipo,string varIdEfector,DateTime? varFechaHora)
		{
			PnPlanilla item = new PnPlanilla();
			
				item.IdPlanillas = varIdPlanillas;
			
				item.IdAgenteInscriptor = varIdAgenteInscriptor;
			
				item.IdEntrega = varIdEntrega;
			
				item.IdRecibe = varIdRecibe;
			
				item.Periodo = varPeriodo;
			
				item.CantNino = varCantNino;
			
				item.CantEmbarazada = varCantEmbarazada;
			
				item.Motivo = varMotivo;
			
				item.Usuario = varUsuario;
			
				item.Tipo = varTipo;
			
				item.IdEfector = varIdEfector;
			
				item.FechaHora = varFechaHora;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPlanillasColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgenteInscriptorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEntregaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdRecibeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CantNinoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CantEmbarazadaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHoraColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPlanillas = @"id_planillas";
			 public static string IdAgenteInscriptor = @"id_agente_inscriptor";
			 public static string IdEntrega = @"id_entrega";
			 public static string IdRecibe = @"id_recibe";
			 public static string Periodo = @"periodo";
			 public static string CantNino = @"cant_nino";
			 public static string CantEmbarazada = @"cant_embarazada";
			 public static string Motivo = @"motivo";
			 public static string Usuario = @"usuario";
			 public static string Tipo = @"tipo";
			 public static string IdEfector = @"id_efector";
			 public static string FechaHora = @"fecha_hora";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
