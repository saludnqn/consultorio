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
	/// Strongly-typed collection for the LabItemScreening class.
	/// </summary>
    [Serializable]
	public partial class LabItemScreeningCollection : ActiveList<LabItemScreening, LabItemScreeningCollection>
	{	   
		public LabItemScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabItemScreeningCollection</returns>
		public LabItemScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabItemScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_ItemScreening table.
	/// </summary>
	[Serializable]
	public partial class LabItemScreening : ActiveRecord<LabItemScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabItemScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabItemScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabItemScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabItemScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_ItemScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdItemScreening = new TableSchema.TableColumn(schema);
				colvarIdItemScreening.ColumnName = "idItemScreening";
				colvarIdItemScreening.DataType = DbType.Int32;
				colvarIdItemScreening.MaxLength = 0;
				colvarIdItemScreening.AutoIncrement = true;
				colvarIdItemScreening.IsNullable = false;
				colvarIdItemScreening.IsPrimaryKey = true;
				colvarIdItemScreening.IsForeignKey = false;
				colvarIdItemScreening.IsReadOnly = false;
				colvarIdItemScreening.DefaultSetting = @"";
				colvarIdItemScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItemScreening);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdMetodo = new TableSchema.TableColumn(schema);
				colvarIdMetodo.ColumnName = "idMetodo";
				colvarIdMetodo.DataType = DbType.Int32;
				colvarIdMetodo.MaxLength = 0;
				colvarIdMetodo.AutoIncrement = false;
				colvarIdMetodo.IsNullable = false;
				colvarIdMetodo.IsPrimaryKey = false;
				colvarIdMetodo.IsForeignKey = true;
				colvarIdMetodo.IsReadOnly = false;
				
						colvarIdMetodo.DefaultSetting = @"((0))";
				
					colvarIdMetodo.ForeignKeyTableName = "LAB_MetodoScreening";
				schema.Columns.Add(colvarIdMetodo);
				
				TableSchema.TableColumn colvarValorReferencia = new TableSchema.TableColumn(schema);
				colvarValorReferencia.ColumnName = "valorReferencia";
				colvarValorReferencia.DataType = DbType.String;
				colvarValorReferencia.MaxLength = 500;
				colvarValorReferencia.AutoIncrement = false;
				colvarValorReferencia.IsNullable = false;
				colvarValorReferencia.IsPrimaryKey = false;
				colvarValorReferencia.IsForeignKey = false;
				colvarValorReferencia.IsReadOnly = false;
				colvarValorReferencia.DefaultSetting = @"";
				colvarValorReferencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorReferencia);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.Int32;
				colvarIdUsuarioRegistro.MaxLength = 0;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = false;
				colvarIdUsuarioRegistro.IsPrimaryKey = false;
				colvarIdUsuarioRegistro.IsForeignKey = false;
				colvarIdUsuarioRegistro.IsReadOnly = false;
				colvarIdUsuarioRegistro.DefaultSetting = @"";
				colvarIdUsuarioRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRegistro);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
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
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = false;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				colvarBaja.DefaultSetting = @"";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				TableSchema.TableColumn colvarAbreviatura = new TableSchema.TableColumn(schema);
				colvarAbreviatura.ColumnName = "Abreviatura";
				colvarAbreviatura.DataType = DbType.String;
				colvarAbreviatura.MaxLength = 50;
				colvarAbreviatura.AutoIncrement = false;
				colvarAbreviatura.IsNullable = false;
				colvarAbreviatura.IsPrimaryKey = false;
				colvarAbreviatura.IsForeignKey = false;
				colvarAbreviatura.IsReadOnly = false;
				colvarAbreviatura.DefaultSetting = @"";
				colvarAbreviatura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAbreviatura);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_ItemScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdItemScreening")]
		[Bindable(true)]
		public int IdItemScreening 
		{
			get { return GetColumnValue<int>(Columns.IdItemScreening); }
			set { SetColumnValue(Columns.IdItemScreening, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdMetodo")]
		[Bindable(true)]
		public int IdMetodo 
		{
			get { return GetColumnValue<int>(Columns.IdMetodo); }
			set { SetColumnValue(Columns.IdMetodo, value); }
		}
		  
		[XmlAttribute("ValorReferencia")]
		[Bindable(true)]
		public string ValorReferencia 
		{
			get { return GetColumnValue<string>(Columns.ValorReferencia); }
			set { SetColumnValue(Columns.ValorReferencia, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public int IdUsuarioRegistro 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool Baja 
		{
			get { return GetColumnValue<bool>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		  
		[XmlAttribute("Abreviatura")]
		[Bindable(true)]
		public string Abreviatura 
		{
			get { return GetColumnValue<string>(Columns.Abreviatura); }
			set { SetColumnValue(Columns.Abreviatura, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.LabItemScreeningResultadoCollection colLabItemScreeningResultadoRecords;
		public DalSic.LabItemScreeningResultadoCollection LabItemScreeningResultadoRecords
		{
			get
			{
				if(colLabItemScreeningResultadoRecords == null)
				{
					colLabItemScreeningResultadoRecords = new DalSic.LabItemScreeningResultadoCollection().Where(LabItemScreeningResultado.Columns.IdItemScreening, IdItemScreening).Load();
					colLabItemScreeningResultadoRecords.ListChanged += new ListChangedEventHandler(colLabItemScreeningResultadoRecords_ListChanged);
				}
				return colLabItemScreeningResultadoRecords;			
			}
			set 
			{ 
					colLabItemScreeningResultadoRecords = value; 
					colLabItemScreeningResultadoRecords.ListChanged += new ListChangedEventHandler(colLabItemScreeningResultadoRecords_ListChanged);
			}
		}
		
		void colLabItemScreeningResultadoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabItemScreeningResultadoRecords[e.NewIndex].IdItemScreening = IdItemScreening;
		    }
		}
				
		private DalSic.LabDetalleSolicitudScreeningCollection colLabDetalleSolicitudScreeningRecords;
		public DalSic.LabDetalleSolicitudScreeningCollection LabDetalleSolicitudScreeningRecords
		{
			get
			{
				if(colLabDetalleSolicitudScreeningRecords == null)
				{
					colLabDetalleSolicitudScreeningRecords = new DalSic.LabDetalleSolicitudScreeningCollection().Where(LabDetalleSolicitudScreening.Columns.IdItem, IdItemScreening).Load();
					colLabDetalleSolicitudScreeningRecords.ListChanged += new ListChangedEventHandler(colLabDetalleSolicitudScreeningRecords_ListChanged);
				}
				return colLabDetalleSolicitudScreeningRecords;			
			}
			set 
			{ 
					colLabDetalleSolicitudScreeningRecords = value; 
					colLabDetalleSolicitudScreeningRecords.ListChanged += new ListChangedEventHandler(colLabDetalleSolicitudScreeningRecords_ListChanged);
			}
		}
		
		void colLabDetalleSolicitudScreeningRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabDetalleSolicitudScreeningRecords[e.NewIndex].IdItem = IdItemScreening;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabMetodoScreening ActiveRecord object related to this LabItemScreening
		/// 
		/// </summary>
		public DalSic.LabMetodoScreening LabMetodoScreening
		{
			get { return DalSic.LabMetodoScreening.FetchByID(this.IdMetodo); }
			set { SetColumnValue("idMetodo", value.IdMetodoScreening); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdMetodo,string varValorReferencia,int varIdUsuarioRegistro,DateTime varFechaRegistro,bool varBaja,string varAbreviatura)
		{
			LabItemScreening item = new LabItemScreening();
			
			item.Nombre = varNombre;
			
			item.IdMetodo = varIdMetodo;
			
			item.ValorReferencia = varValorReferencia;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.Baja = varBaja;
			
			item.Abreviatura = varAbreviatura;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdItemScreening,string varNombre,int varIdMetodo,string varValorReferencia,int varIdUsuarioRegistro,DateTime varFechaRegistro,bool varBaja,string varAbreviatura)
		{
			LabItemScreening item = new LabItemScreening();
			
				item.IdItemScreening = varIdItemScreening;
			
				item.Nombre = varNombre;
			
				item.IdMetodo = varIdMetodo;
			
				item.ValorReferencia = varValorReferencia;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.Baja = varBaja;
			
				item.Abreviatura = varAbreviatura;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdItemScreeningColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMetodoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorReferenciaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AbreviaturaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdItemScreening = @"idItemScreening";
			 public static string Nombre = @"nombre";
			 public static string IdMetodo = @"idMetodo";
			 public static string ValorReferencia = @"valorReferencia";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string Baja = @"baja";
			 public static string Abreviatura = @"Abreviatura";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colLabItemScreeningResultadoRecords != null)
                {
                    foreach (DalSic.LabItemScreeningResultado item in colLabItemScreeningResultadoRecords)
                    {
                        if (item.IdItemScreening != IdItemScreening)
                        {
                            item.IdItemScreening = IdItemScreening;
                        }
                    }
               }
		
                if (colLabDetalleSolicitudScreeningRecords != null)
                {
                    foreach (DalSic.LabDetalleSolicitudScreening item in colLabDetalleSolicitudScreeningRecords)
                    {
                        if (item.IdItem != IdItemScreening)
                        {
                            item.IdItem = IdItemScreening;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colLabItemScreeningResultadoRecords != null)
                {
                    colLabItemScreeningResultadoRecords.SaveAll();
               }
		
                if (colLabDetalleSolicitudScreeningRecords != null)
                {
                    colLabDetalleSolicitudScreeningRecords.SaveAll();
               }
		}
        #endregion
	}
}
