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
	/// Strongly-typed collection for the PnServicio class.
	/// </summary>
    [Serializable]
	public partial class PnServicioCollection : ActiveList<PnServicio, PnServicioCollection>
	{	   
		public PnServicioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnServicioCollection</returns>
		public PnServicioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnServicio o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_servicio table.
	/// </summary>
	[Serializable]
	public partial class PnServicio : ActiveRecord<PnServicio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnServicio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnServicio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnServicio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnServicio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_servicio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "id_servicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = true;
				colvarIdServicio.IsNullable = false;
				colvarIdServicio.IsPrimaryKey = true;
				colvarIdServicio.IsForeignKey = false;
				colvarIdServicio.IsReadOnly = false;
				colvarIdServicio.DefaultSetting = @"";
				colvarIdServicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdServicio);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_servicio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int IdServicio 
		{
			get { return GetColumnValue<int>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnComprobanteCollection colPnComprobanteRecords;
		public DalSic.PnComprobanteCollection PnComprobanteRecords
		{
			get
			{
				if(colPnComprobanteRecords == null)
				{
					colPnComprobanteRecords = new DalSic.PnComprobanteCollection().Where(PnComprobante.Columns.IdServicio, IdServicio).Load();
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
		        colPnComprobanteRecords[e.NewIndex].IdServicio = IdServicio;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion)
		{
			PnServicio item = new PnServicio();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdServicio,string varDescripcion)
		{
			PnServicio item = new PnServicio();
			
				item.IdServicio = varIdServicio;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdServicio = @"id_servicio";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnComprobanteRecords != null)
                {
                    foreach (DalSic.PnComprobante item in colPnComprobanteRecords)
                    {
                        if (item.IdServicio != IdServicio)
                        {
                            item.IdServicio = IdServicio;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnComprobanteRecords != null)
                {
                    colPnComprobanteRecords.SaveAll();
               }
		}
        #endregion
	}
}
