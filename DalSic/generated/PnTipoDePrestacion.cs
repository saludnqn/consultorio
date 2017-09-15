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
	/// Strongly-typed collection for the PnTipoDePrestacion class.
	/// </summary>
    [Serializable]
	public partial class PnTipoDePrestacionCollection : ActiveList<PnTipoDePrestacion, PnTipoDePrestacionCollection>
	{	   
		public PnTipoDePrestacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTipoDePrestacionCollection</returns>
		public PnTipoDePrestacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTipoDePrestacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_TipoDePrestacion table.
	/// </summary>
	[Serializable]
	public partial class PnTipoDePrestacion : ActiveRecord<PnTipoDePrestacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTipoDePrestacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTipoDePrestacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTipoDePrestacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTipoDePrestacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_TipoDePrestacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoDePrestacion = new TableSchema.TableColumn(schema);
				colvarIdTipoDePrestacion.ColumnName = "idTipoDePrestacion";
				colvarIdTipoDePrestacion.DataType = DbType.Int32;
				colvarIdTipoDePrestacion.MaxLength = 0;
				colvarIdTipoDePrestacion.AutoIncrement = true;
				colvarIdTipoDePrestacion.IsNullable = false;
				colvarIdTipoDePrestacion.IsPrimaryKey = true;
				colvarIdTipoDePrestacion.IsForeignKey = false;
				colvarIdTipoDePrestacion.IsReadOnly = false;
				colvarIdTipoDePrestacion.DefaultSetting = @"";
				colvarIdTipoDePrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoDePrestacion);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarIdNomencladorDetalle = new TableSchema.TableColumn(schema);
				colvarIdNomencladorDetalle.ColumnName = "idNomencladorDetalle";
				colvarIdNomencladorDetalle.DataType = DbType.Int32;
				colvarIdNomencladorDetalle.MaxLength = 0;
				colvarIdNomencladorDetalle.AutoIncrement = false;
				colvarIdNomencladorDetalle.IsNullable = true;
				colvarIdNomencladorDetalle.IsPrimaryKey = false;
				colvarIdNomencladorDetalle.IsForeignKey = true;
				colvarIdNomencladorDetalle.IsReadOnly = false;
				colvarIdNomencladorDetalle.DefaultSetting = @"";
				
					colvarIdNomencladorDetalle.ForeignKeyTableName = "PN_nomenclador_detalle";
				schema.Columns.Add(colvarIdNomencladorDetalle);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_TipoDePrestacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoDePrestacion")]
		[Bindable(true)]
		public int IdTipoDePrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdTipoDePrestacion); }
			set { SetColumnValue(Columns.IdTipoDePrestacion, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int? IdNomencladorDetalle 
		{
			get { return GetColumnValue<int?>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnFacturaCollection colPnFacturaRecords;
		public DalSic.PnFacturaCollection PnFacturaRecords
		{
			get
			{
				if(colPnFacturaRecords == null)
				{
					colPnFacturaRecords = new DalSic.PnFacturaCollection().Where(PnFactura.Columns.IdTipoDePrestacion, IdTipoDePrestacion).Load();
					colPnFacturaRecords.ListChanged += new ListChangedEventHandler(colPnFacturaRecords_ListChanged);
				}
				return colPnFacturaRecords;			
			}
			set 
			{ 
					colPnFacturaRecords = value; 
					colPnFacturaRecords.ListChanged += new ListChangedEventHandler(colPnFacturaRecords_ListChanged);
			}
		}
		
		void colPnFacturaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnFacturaRecords[e.NewIndex].IdTipoDePrestacion = IdTipoDePrestacion;
		    }
		}
				
		private DalSic.PnComprobanteCollection colPnComprobanteRecords;
		public DalSic.PnComprobanteCollection PnComprobanteRecords
		{
			get
			{
				if(colPnComprobanteRecords == null)
				{
					colPnComprobanteRecords = new DalSic.PnComprobanteCollection().Where(PnComprobante.Columns.IdTipoDePrestacion, IdTipoDePrestacion).Load();
					colPnComprobanteRecords.ListChanged += new ListChangedEventHandler(colPnComprobanteRecords_ListChanged);
				}
				return colPnComprobanteRecords;			
			}
			set 
			{ 
					colPnComprobanteRecords = value; 
					colPnComprobanteRecords.ListChanged += new ListChangedEventHandler(colPnComprobanteRecords_ListChanged);
			}
		}
		
		void colPnComprobanteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnComprobanteRecords[e.NewIndex].IdTipoDePrestacion = IdTipoDePrestacion;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnNomencladorDetalle ActiveRecord object related to this PnTipoDePrestacion
		/// 
		/// </summary>
		public DalSic.PnNomencladorDetalle PnNomencladorDetalle
		{
			get { return DalSic.PnNomencladorDetalle.FetchByID(this.IdNomencladorDetalle); }
			set { SetColumnValue("idNomencladorDetalle", value.IdNomencladorDetalle); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,int? varIdNomencladorDetalle)
		{
			PnTipoDePrestacion item = new PnTipoDePrestacion();
			
			item.Descripcion = varDescripcion;
			
			item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoDePrestacion,string varDescripcion,int? varIdNomencladorDetalle)
		{
			PnTipoDePrestacion item = new PnTipoDePrestacion();
			
				item.IdTipoDePrestacion = varIdTipoDePrestacion;
			
				item.Descripcion = varDescripcion;
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoDePrestacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoDePrestacion = @"idTipoDePrestacion";
			 public static string Descripcion = @"descripcion";
			 public static string IdNomencladorDetalle = @"idNomencladorDetalle";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnFacturaRecords != null)
                {
                    foreach (DalSic.PnFactura item in colPnFacturaRecords)
                    {
                        if (item.IdTipoDePrestacion != IdTipoDePrestacion)
                        {
                            item.IdTipoDePrestacion = IdTipoDePrestacion;
                        }
                    }
               }
		
                if (colPnComprobanteRecords != null)
                {
                    foreach (DalSic.PnComprobante item in colPnComprobanteRecords)
                    {
                        if (item.IdTipoDePrestacion != IdTipoDePrestacion)
                        {
                            item.IdTipoDePrestacion = IdTipoDePrestacion;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnFacturaRecords != null)
                {
                    colPnFacturaRecords.SaveAll();
               }
		
                if (colPnComprobanteRecords != null)
                {
                    colPnComprobanteRecords.SaveAll();
               }
		}
        #endregion
	}
}
