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
	/// Strongly-typed collection for the AprEgresoPorAborto class.
	/// </summary>
    [Serializable]
	public partial class AprEgresoPorAbortoCollection : ActiveList<AprEgresoPorAborto, AprEgresoPorAbortoCollection>
	{	   
		public AprEgresoPorAbortoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprEgresoPorAbortoCollection</returns>
		public AprEgresoPorAbortoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprEgresoPorAborto o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_EgresoPorAborto table.
	/// </summary>
	[Serializable]
	public partial class AprEgresoPorAborto : ActiveRecord<AprEgresoPorAborto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprEgresoPorAborto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprEgresoPorAborto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprEgresoPorAborto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprEgresoPorAborto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_EgresoPorAborto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEgresoPorAborto = new TableSchema.TableColumn(schema);
				colvarIdEgresoPorAborto.ColumnName = "idEgresoPorAborto";
				colvarIdEgresoPorAborto.DataType = DbType.Int32;
				colvarIdEgresoPorAborto.MaxLength = 0;
				colvarIdEgresoPorAborto.AutoIncrement = true;
				colvarIdEgresoPorAborto.IsNullable = false;
				colvarIdEgresoPorAborto.IsPrimaryKey = true;
				colvarIdEgresoPorAborto.IsForeignKey = false;
				colvarIdEgresoPorAborto.IsReadOnly = false;
				colvarIdEgresoPorAborto.DefaultSetting = @"";
				colvarIdEgresoPorAborto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEgresoPorAborto);
				
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
				
				TableSchema.TableColumn colvarIdAborto = new TableSchema.TableColumn(schema);
				colvarIdAborto.ColumnName = "idAborto";
				colvarIdAborto.DataType = DbType.Int32;
				colvarIdAborto.MaxLength = 0;
				colvarIdAborto.AutoIncrement = false;
				colvarIdAborto.IsNullable = false;
				colvarIdAborto.IsPrimaryKey = false;
				colvarIdAborto.IsForeignKey = true;
				colvarIdAborto.IsReadOnly = false;
				colvarIdAborto.DefaultSetting = @"";
				
					colvarIdAborto.ForeignKeyTableName = "APR_Aborto";
				schema.Columns.Add(colvarIdAborto);
				
				TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
				colvarFechaHora.ColumnName = "FechaHora";
				colvarFechaHora.DataType = DbType.DateTime;
				colvarFechaHora.MaxLength = 0;
				colvarFechaHora.AutoIncrement = false;
				colvarFechaHora.IsNullable = false;
				colvarFechaHora.IsPrimaryKey = false;
				colvarFechaHora.IsForeignKey = false;
				colvarFechaHora.IsReadOnly = false;
				colvarFechaHora.DefaultSetting = @"";
				colvarFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHora);
				
				TableSchema.TableColumn colvarIdTipoEgreso = new TableSchema.TableColumn(schema);
				colvarIdTipoEgreso.ColumnName = "idTipoEgreso";
				colvarIdTipoEgreso.DataType = DbType.Int32;
				colvarIdTipoEgreso.MaxLength = 0;
				colvarIdTipoEgreso.AutoIncrement = false;
				colvarIdTipoEgreso.IsNullable = true;
				colvarIdTipoEgreso.IsPrimaryKey = false;
				colvarIdTipoEgreso.IsForeignKey = false;
				colvarIdTipoEgreso.IsReadOnly = false;
				colvarIdTipoEgreso.DefaultSetting = @"";
				colvarIdTipoEgreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEgreso);
				
				TableSchema.TableColumn colvarIdEstadoEgreso = new TableSchema.TableColumn(schema);
				colvarIdEstadoEgreso.ColumnName = "idEstadoEgreso";
				colvarIdEstadoEgreso.DataType = DbType.Int32;
				colvarIdEstadoEgreso.MaxLength = 0;
				colvarIdEstadoEgreso.AutoIncrement = false;
				colvarIdEstadoEgreso.IsNullable = true;
				colvarIdEstadoEgreso.IsPrimaryKey = false;
				colvarIdEstadoEgreso.IsForeignKey = false;
				colvarIdEstadoEgreso.IsReadOnly = false;
				colvarIdEstadoEgreso.DefaultSetting = @"";
				colvarIdEstadoEgreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadoEgreso);
				
				TableSchema.TableColumn colvarDIAGCIE10 = new TableSchema.TableColumn(schema);
				colvarDIAGCIE10.ColumnName = "DIAGCIE10";
				colvarDIAGCIE10.DataType = DbType.Int32;
				colvarDIAGCIE10.MaxLength = 0;
				colvarDIAGCIE10.AutoIncrement = false;
				colvarDIAGCIE10.IsNullable = true;
				colvarDIAGCIE10.IsPrimaryKey = false;
				colvarDIAGCIE10.IsForeignKey = true;
				colvarDIAGCIE10.IsReadOnly = false;
				colvarDIAGCIE10.DefaultSetting = @"";
				
					colvarDIAGCIE10.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarDIAGCIE10);
				
				TableSchema.TableColumn colvarIdTratamientoEgresoAborto = new TableSchema.TableColumn(schema);
				colvarIdTratamientoEgresoAborto.ColumnName = "idTratamientoEgresoAborto";
				colvarIdTratamientoEgresoAborto.DataType = DbType.Int32;
				colvarIdTratamientoEgresoAborto.MaxLength = 0;
				colvarIdTratamientoEgresoAborto.AutoIncrement = false;
				colvarIdTratamientoEgresoAborto.IsNullable = true;
				colvarIdTratamientoEgresoAborto.IsPrimaryKey = false;
				colvarIdTratamientoEgresoAborto.IsForeignKey = false;
				colvarIdTratamientoEgresoAborto.IsReadOnly = false;
				colvarIdTratamientoEgresoAborto.DefaultSetting = @"";
				colvarIdTratamientoEgresoAborto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTratamientoEgresoAborto);
				
				TableSchema.TableColumn colvarIdTraslado = new TableSchema.TableColumn(schema);
				colvarIdTraslado.ColumnName = "idTraslado";
				colvarIdTraslado.DataType = DbType.Int32;
				colvarIdTraslado.MaxLength = 0;
				colvarIdTraslado.AutoIncrement = false;
				colvarIdTraslado.IsNullable = true;
				colvarIdTraslado.IsPrimaryKey = false;
				colvarIdTraslado.IsForeignKey = false;
				colvarIdTraslado.IsReadOnly = false;
				colvarIdTraslado.DefaultSetting = @"";
				colvarIdTraslado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTraslado);
				
				TableSchema.TableColumn colvarAutopsia = new TableSchema.TableColumn(schema);
				colvarAutopsia.ColumnName = "Autopsia";
				colvarAutopsia.DataType = DbType.Boolean;
				colvarAutopsia.MaxLength = 0;
				colvarAutopsia.AutoIncrement = false;
				colvarAutopsia.IsNullable = true;
				colvarAutopsia.IsPrimaryKey = false;
				colvarAutopsia.IsForeignKey = false;
				colvarAutopsia.IsReadOnly = false;
				colvarAutopsia.DefaultSetting = @"";
				colvarAutopsia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutopsia);
				
				TableSchema.TableColumn colvarIniciaMetodoAnticonceptivo = new TableSchema.TableColumn(schema);
				colvarIniciaMetodoAnticonceptivo.ColumnName = "IniciaMetodoAnticonceptivo";
				colvarIniciaMetodoAnticonceptivo.DataType = DbType.Boolean;
				colvarIniciaMetodoAnticonceptivo.MaxLength = 0;
				colvarIniciaMetodoAnticonceptivo.AutoIncrement = false;
				colvarIniciaMetodoAnticonceptivo.IsNullable = true;
				colvarIniciaMetodoAnticonceptivo.IsPrimaryKey = false;
				colvarIniciaMetodoAnticonceptivo.IsForeignKey = false;
				colvarIniciaMetodoAnticonceptivo.IsReadOnly = false;
				colvarIniciaMetodoAnticonceptivo.DefaultSetting = @"";
				colvarIniciaMetodoAnticonceptivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIniciaMetodoAnticonceptivo);
				
				TableSchema.TableColumn colvarIdMetodoAnticonceptivoPreferido = new TableSchema.TableColumn(schema);
				colvarIdMetodoAnticonceptivoPreferido.ColumnName = "idMetodoAnticonceptivoPreferido";
				colvarIdMetodoAnticonceptivoPreferido.DataType = DbType.Int32;
				colvarIdMetodoAnticonceptivoPreferido.MaxLength = 0;
				colvarIdMetodoAnticonceptivoPreferido.AutoIncrement = false;
				colvarIdMetodoAnticonceptivoPreferido.IsNullable = true;
				colvarIdMetodoAnticonceptivoPreferido.IsPrimaryKey = false;
				colvarIdMetodoAnticonceptivoPreferido.IsForeignKey = false;
				colvarIdMetodoAnticonceptivoPreferido.IsReadOnly = false;
				colvarIdMetodoAnticonceptivoPreferido.DefaultSetting = @"";
				colvarIdMetodoAnticonceptivoPreferido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMetodoAnticonceptivoPreferido);
				
				TableSchema.TableColumn colvarIdMetodoAnticonceptivoAccedido = new TableSchema.TableColumn(schema);
				colvarIdMetodoAnticonceptivoAccedido.ColumnName = "idMetodoAnticonceptivoAccedido";
				colvarIdMetodoAnticonceptivoAccedido.DataType = DbType.Int32;
				colvarIdMetodoAnticonceptivoAccedido.MaxLength = 0;
				colvarIdMetodoAnticonceptivoAccedido.AutoIncrement = false;
				colvarIdMetodoAnticonceptivoAccedido.IsNullable = true;
				colvarIdMetodoAnticonceptivoAccedido.IsPrimaryKey = false;
				colvarIdMetodoAnticonceptivoAccedido.IsForeignKey = false;
				colvarIdMetodoAnticonceptivoAccedido.IsReadOnly = false;
				colvarIdMetodoAnticonceptivoAccedido.DefaultSetting = @"";
				colvarIdMetodoAnticonceptivoAccedido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMetodoAnticonceptivoAccedido);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "Responsable";
				colvarResponsable.DataType = DbType.AnsiString;
				colvarResponsable.MaxLength = 50;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = true;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_EgresoPorAborto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEgresoPorAborto")]
		[Bindable(true)]
		public int IdEgresoPorAborto 
		{
			get { return GetColumnValue<int>(Columns.IdEgresoPorAborto); }
			set { SetColumnValue(Columns.IdEgresoPorAborto, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdAborto")]
		[Bindable(true)]
		public int IdAborto 
		{
			get { return GetColumnValue<int>(Columns.IdAborto); }
			set { SetColumnValue(Columns.IdAborto, value); }
		}
		  
		[XmlAttribute("FechaHora")]
		[Bindable(true)]
		public DateTime FechaHora 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHora); }
			set { SetColumnValue(Columns.FechaHora, value); }
		}
		  
		[XmlAttribute("IdTipoEgreso")]
		[Bindable(true)]
		public int? IdTipoEgreso 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoEgreso); }
			set { SetColumnValue(Columns.IdTipoEgreso, value); }
		}
		  
		[XmlAttribute("IdEstadoEgreso")]
		[Bindable(true)]
		public int? IdEstadoEgreso 
		{
			get { return GetColumnValue<int?>(Columns.IdEstadoEgreso); }
			set { SetColumnValue(Columns.IdEstadoEgreso, value); }
		}
		  
		[XmlAttribute("DIAGCIE10")]
		[Bindable(true)]
		public int? DIAGCIE10 
		{
			get { return GetColumnValue<int?>(Columns.DIAGCIE10); }
			set { SetColumnValue(Columns.DIAGCIE10, value); }
		}
		  
		[XmlAttribute("IdTratamientoEgresoAborto")]
		[Bindable(true)]
		public int? IdTratamientoEgresoAborto 
		{
			get { return GetColumnValue<int?>(Columns.IdTratamientoEgresoAborto); }
			set { SetColumnValue(Columns.IdTratamientoEgresoAborto, value); }
		}
		  
		[XmlAttribute("IdTraslado")]
		[Bindable(true)]
		public int? IdTraslado 
		{
			get { return GetColumnValue<int?>(Columns.IdTraslado); }
			set { SetColumnValue(Columns.IdTraslado, value); }
		}
		  
		[XmlAttribute("Autopsia")]
		[Bindable(true)]
		public bool? Autopsia 
		{
			get { return GetColumnValue<bool?>(Columns.Autopsia); }
			set { SetColumnValue(Columns.Autopsia, value); }
		}
		  
		[XmlAttribute("IniciaMetodoAnticonceptivo")]
		[Bindable(true)]
		public bool? IniciaMetodoAnticonceptivo 
		{
			get { return GetColumnValue<bool?>(Columns.IniciaMetodoAnticonceptivo); }
			set { SetColumnValue(Columns.IniciaMetodoAnticonceptivo, value); }
		}
		  
		[XmlAttribute("IdMetodoAnticonceptivoPreferido")]
		[Bindable(true)]
		public int? IdMetodoAnticonceptivoPreferido 
		{
			get { return GetColumnValue<int?>(Columns.IdMetodoAnticonceptivoPreferido); }
			set { SetColumnValue(Columns.IdMetodoAnticonceptivoPreferido, value); }
		}
		  
		[XmlAttribute("IdMetodoAnticonceptivoAccedido")]
		[Bindable(true)]
		public int? IdMetodoAnticonceptivoAccedido 
		{
			get { return GetColumnValue<int?>(Columns.IdMetodoAnticonceptivoAccedido); }
			set { SetColumnValue(Columns.IdMetodoAnticonceptivoAccedido, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprAborto ActiveRecord object related to this AprEgresoPorAborto
		/// 
		/// </summary>
		public DalSic.AprAborto AprAborto
		{
			get { return DalSic.AprAborto.FetchByID(this.IdAborto); }
			set { SetColumnValue("idAborto", value.IdAborto); }
		}
		
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this AprEgresoPorAborto
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.DIAGCIE10); }
			set { SetColumnValue("DIAGCIE10", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdAborto,DateTime varFechaHora,int? varIdTipoEgreso,int? varIdEstadoEgreso,int? varDIAGCIE10,int? varIdTratamientoEgresoAborto,int? varIdTraslado,bool? varAutopsia,bool? varIniciaMetodoAnticonceptivo,int? varIdMetodoAnticonceptivoPreferido,int? varIdMetodoAnticonceptivoAccedido,string varResponsable)
		{
			AprEgresoPorAborto item = new AprEgresoPorAborto();
			
			item.IdEfector = varIdEfector;
			
			item.IdAborto = varIdAborto;
			
			item.FechaHora = varFechaHora;
			
			item.IdTipoEgreso = varIdTipoEgreso;
			
			item.IdEstadoEgreso = varIdEstadoEgreso;
			
			item.DIAGCIE10 = varDIAGCIE10;
			
			item.IdTratamientoEgresoAborto = varIdTratamientoEgresoAborto;
			
			item.IdTraslado = varIdTraslado;
			
			item.Autopsia = varAutopsia;
			
			item.IniciaMetodoAnticonceptivo = varIniciaMetodoAnticonceptivo;
			
			item.IdMetodoAnticonceptivoPreferido = varIdMetodoAnticonceptivoPreferido;
			
			item.IdMetodoAnticonceptivoAccedido = varIdMetodoAnticonceptivoAccedido;
			
			item.Responsable = varResponsable;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEgresoPorAborto,int varIdEfector,int varIdAborto,DateTime varFechaHora,int? varIdTipoEgreso,int? varIdEstadoEgreso,int? varDIAGCIE10,int? varIdTratamientoEgresoAborto,int? varIdTraslado,bool? varAutopsia,bool? varIniciaMetodoAnticonceptivo,int? varIdMetodoAnticonceptivoPreferido,int? varIdMetodoAnticonceptivoAccedido,string varResponsable)
		{
			AprEgresoPorAborto item = new AprEgresoPorAborto();
			
				item.IdEgresoPorAborto = varIdEgresoPorAborto;
			
				item.IdEfector = varIdEfector;
			
				item.IdAborto = varIdAborto;
			
				item.FechaHora = varFechaHora;
			
				item.IdTipoEgreso = varIdTipoEgreso;
			
				item.IdEstadoEgreso = varIdEstadoEgreso;
			
				item.DIAGCIE10 = varDIAGCIE10;
			
				item.IdTratamientoEgresoAborto = varIdTratamientoEgresoAborto;
			
				item.IdTraslado = varIdTraslado;
			
				item.Autopsia = varAutopsia;
			
				item.IniciaMetodoAnticonceptivo = varIniciaMetodoAnticonceptivo;
			
				item.IdMetodoAnticonceptivoPreferido = varIdMetodoAnticonceptivoPreferido;
			
				item.IdMetodoAnticonceptivoAccedido = varIdMetodoAnticonceptivoAccedido;
			
				item.Responsable = varResponsable;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEgresoPorAbortoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAbortoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHoraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEgresoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoEgresoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DIAGCIE10Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTratamientoEgresoAbortoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTrasladoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AutopsiaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IniciaMetodoAnticonceptivoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMetodoAnticonceptivoPreferidoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMetodoAnticonceptivoAccedidoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEgresoPorAborto = @"idEgresoPorAborto";
			 public static string IdEfector = @"idEfector";
			 public static string IdAborto = @"idAborto";
			 public static string FechaHora = @"FechaHora";
			 public static string IdTipoEgreso = @"idTipoEgreso";
			 public static string IdEstadoEgreso = @"idEstadoEgreso";
			 public static string DIAGCIE10 = @"DIAGCIE10";
			 public static string IdTratamientoEgresoAborto = @"idTratamientoEgresoAborto";
			 public static string IdTraslado = @"idTraslado";
			 public static string Autopsia = @"Autopsia";
			 public static string IniciaMetodoAnticonceptivo = @"IniciaMetodoAnticonceptivo";
			 public static string IdMetodoAnticonceptivoPreferido = @"idMetodoAnticonceptivoPreferido";
			 public static string IdMetodoAnticonceptivoAccedido = @"idMetodoAnticonceptivoAccedido";
			 public static string Responsable = @"Responsable";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
