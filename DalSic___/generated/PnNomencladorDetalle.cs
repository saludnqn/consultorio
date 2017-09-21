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
	/// Strongly-typed collection for the PnNomencladorDetalle class.
	/// </summary>
    [Serializable]
	public partial class PnNomencladorDetalleCollection : ActiveList<PnNomencladorDetalle, PnNomencladorDetalleCollection>
	{	   
		public PnNomencladorDetalleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnNomencladorDetalleCollection</returns>
		public PnNomencladorDetalleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnNomencladorDetalle o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_nomenclador_detalle table.
	/// </summary>
	[Serializable]
	public partial class PnNomencladorDetalle : ActiveRecord<PnNomencladorDetalle>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnNomencladorDetalle()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnNomencladorDetalle(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnNomencladorDetalle(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnNomencladorDetalle(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_nomenclador_detalle", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNomencladorDetalle = new TableSchema.TableColumn(schema);
				colvarIdNomencladorDetalle.ColumnName = "id_nomenclador_detalle";
				colvarIdNomencladorDetalle.DataType = DbType.Int32;
				colvarIdNomencladorDetalle.MaxLength = 0;
				colvarIdNomencladorDetalle.AutoIncrement = true;
				colvarIdNomencladorDetalle.IsNullable = false;
				colvarIdNomencladorDetalle.IsPrimaryKey = true;
				colvarIdNomencladorDetalle.IsForeignKey = false;
				colvarIdNomencladorDetalle.IsReadOnly = false;
				colvarIdNomencladorDetalle.DefaultSetting = @"";
				colvarIdNomencladorDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomencladorDetalle);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarFechaDesde = new TableSchema.TableColumn(schema);
				colvarFechaDesde.ColumnName = "fecha_desde";
				colvarFechaDesde.DataType = DbType.DateTime;
				colvarFechaDesde.MaxLength = 0;
				colvarFechaDesde.AutoIncrement = false;
				colvarFechaDesde.IsNullable = true;
				colvarFechaDesde.IsPrimaryKey = false;
				colvarFechaDesde.IsForeignKey = false;
				colvarFechaDesde.IsReadOnly = false;
				colvarFechaDesde.DefaultSetting = @"";
				colvarFechaDesde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDesde);
				
				TableSchema.TableColumn colvarFechaHasta = new TableSchema.TableColumn(schema);
				colvarFechaHasta.ColumnName = "fecha_hasta";
				colvarFechaHasta.DataType = DbType.DateTime;
				colvarFechaHasta.MaxLength = 0;
				colvarFechaHasta.AutoIncrement = false;
				colvarFechaHasta.IsNullable = true;
				colvarFechaHasta.IsPrimaryKey = false;
				colvarFechaHasta.IsForeignKey = false;
				colvarFechaHasta.IsReadOnly = false;
				colvarFechaHasta.DefaultSetting = @"";
				colvarFechaHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHasta);
				
				TableSchema.TableColumn colvarModoFacturacion = new TableSchema.TableColumn(schema);
				colvarModoFacturacion.ColumnName = "modo_facturacion";
				colvarModoFacturacion.DataType = DbType.Int32;
				colvarModoFacturacion.MaxLength = 0;
				colvarModoFacturacion.AutoIncrement = false;
				colvarModoFacturacion.IsNullable = false;
				colvarModoFacturacion.IsPrimaryKey = false;
				colvarModoFacturacion.IsForeignKey = false;
				colvarModoFacturacion.IsReadOnly = false;
				
						colvarModoFacturacion.DefaultSetting = @"((0))";
				colvarModoFacturacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModoFacturacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_nomenclador_detalle",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int IdNomencladorDetalle 
		{
			get { return GetColumnValue<int>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("FechaDesde")]
		[Bindable(true)]
		public DateTime? FechaDesde 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDesde); }
			set { SetColumnValue(Columns.FechaDesde, value); }
		}
		  
		[XmlAttribute("FechaHasta")]
		[Bindable(true)]
		public DateTime? FechaHasta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaHasta); }
			set { SetColumnValue(Columns.FechaHasta, value); }
		}
		  
		[XmlAttribute("ModoFacturacion")]
		[Bindable(true)]
		public int ModoFacturacion 
		{
			get { return GetColumnValue<int>(Columns.ModoFacturacion); }
			set { SetColumnValue(Columns.ModoFacturacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnNomencladorCollection colPnNomencladorRecords;
		public DalSic.PnNomencladorCollection PnNomencladorRecords
		{
			get
			{
				if(colPnNomencladorRecords == null)
				{
					colPnNomencladorRecords = new DalSic.PnNomencladorCollection().Where(PnNomenclador.Columns.IdNomencladorDetalle, IdNomencladorDetalle).Load();
					colPnNomencladorRecords.ListChanged += new ListChangedEventHandler(colPnNomencladorRecords_ListChanged);
				}
				return colPnNomencladorRecords;			
			}
			set 
			{ 
					colPnNomencladorRecords = value; 
					colPnNomencladorRecords.ListChanged += new ListChangedEventHandler(colPnNomencladorRecords_ListChanged);
			}
		}
		
		void colPnNomencladorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnNomencladorRecords[e.NewIndex].IdNomencladorDetalle = IdNomencladorDetalle;
		    }
		}
				
		private DalSic.PnTipoDePrestacionCollection colPnTipoDePrestacionRecords;
		public DalSic.PnTipoDePrestacionCollection PnTipoDePrestacionRecords
		{
			get
			{
				if(colPnTipoDePrestacionRecords == null)
				{
					colPnTipoDePrestacionRecords = new DalSic.PnTipoDePrestacionCollection().Where(PnTipoDePrestacion.Columns.IdNomencladorDetalle, IdNomencladorDetalle).Load();
					colPnTipoDePrestacionRecords.ListChanged += new ListChangedEventHandler(colPnTipoDePrestacionRecords_ListChanged);
				}
				return colPnTipoDePrestacionRecords;			
			}
			set 
			{ 
					colPnTipoDePrestacionRecords = value; 
					colPnTipoDePrestacionRecords.ListChanged += new ListChangedEventHandler(colPnTipoDePrestacionRecords_ListChanged);
			}
		}
		
		void colPnTipoDePrestacionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnTipoDePrestacionRecords[e.NewIndex].IdNomencladorDetalle = IdNomencladorDetalle;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,DateTime? varFechaDesde,DateTime? varFechaHasta,int varModoFacturacion)
		{
			PnNomencladorDetalle item = new PnNomencladorDetalle();
			
			item.Descripcion = varDescripcion;
			
			item.FechaDesde = varFechaDesde;
			
			item.FechaHasta = varFechaHasta;
			
			item.ModoFacturacion = varModoFacturacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNomencladorDetalle,string varDescripcion,DateTime? varFechaDesde,DateTime? varFechaHasta,int varModoFacturacion)
		{
			PnNomencladorDetalle item = new PnNomencladorDetalle();
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
				item.Descripcion = varDescripcion;
			
				item.FechaDesde = varFechaDesde;
			
				item.FechaHasta = varFechaHasta;
			
				item.ModoFacturacion = varModoFacturacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDesdeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHastaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ModoFacturacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNomencladorDetalle = @"id_nomenclador_detalle";
			 public static string Descripcion = @"descripcion";
			 public static string FechaDesde = @"fecha_desde";
			 public static string FechaHasta = @"fecha_hasta";
			 public static string ModoFacturacion = @"modo_facturacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnNomencladorRecords != null)
                {
                    foreach (DalSic.PnNomenclador item in colPnNomencladorRecords)
                    {
                        if (item.IdNomencladorDetalle != IdNomencladorDetalle)
                        {
                            item.IdNomencladorDetalle = IdNomencladorDetalle;
                        }
                    }
               }
		
                if (colPnTipoDePrestacionRecords != null)
                {
                    foreach (DalSic.PnTipoDePrestacion item in colPnTipoDePrestacionRecords)
                    {
                        if (item.IdNomencladorDetalle != IdNomencladorDetalle)
                        {
                            item.IdNomencladorDetalle = IdNomencladorDetalle;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnNomencladorRecords != null)
                {
                    colPnNomencladorRecords.SaveAll();
               }
		
                if (colPnTipoDePrestacionRecords != null)
                {
                    colPnTipoDePrestacionRecords.SaveAll();
               }
		}
        #endregion
	}
}
