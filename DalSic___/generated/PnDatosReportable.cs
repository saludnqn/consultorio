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
	/// Strongly-typed collection for the PnDatosReportable class.
	/// </summary>
    [Serializable]
	public partial class PnDatosReportableCollection : ActiveList<PnDatosReportable, PnDatosReportableCollection>
	{	   
		public PnDatosReportableCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnDatosReportableCollection</returns>
		public PnDatosReportableCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnDatosReportable o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_datos_reportables table.
	/// </summary>
	[Serializable]
	public partial class PnDatosReportable : ActiveRecord<PnDatosReportable>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnDatosReportable()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnDatosReportable(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnDatosReportable(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnDatosReportable(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_datos_reportables", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDatoReportable = new TableSchema.TableColumn(schema);
				colvarIdDatoReportable.ColumnName = "idDatoReportable";
				colvarIdDatoReportable.DataType = DbType.Int32;
				colvarIdDatoReportable.MaxLength = 0;
				colvarIdDatoReportable.AutoIncrement = true;
				colvarIdDatoReportable.IsNullable = false;
				colvarIdDatoReportable.IsPrimaryKey = true;
				colvarIdDatoReportable.IsForeignKey = false;
				colvarIdDatoReportable.IsReadOnly = false;
				colvarIdDatoReportable.DefaultSetting = @"";
				colvarIdDatoReportable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDatoReportable);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarUnidadMedida = new TableSchema.TableColumn(schema);
				colvarUnidadMedida.ColumnName = "unidad_medida";
				colvarUnidadMedida.DataType = DbType.AnsiString;
				colvarUnidadMedida.MaxLength = 20;
				colvarUnidadMedida.AutoIncrement = false;
				colvarUnidadMedida.IsNullable = true;
				colvarUnidadMedida.IsPrimaryKey = false;
				colvarUnidadMedida.IsForeignKey = false;
				colvarUnidadMedida.IsReadOnly = false;
				colvarUnidadMedida.DefaultSetting = @"";
				colvarUnidadMedida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadMedida);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_datos_reportables",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDatoReportable")]
		[Bindable(true)]
		public int IdDatoReportable 
		{
			get { return GetColumnValue<int>(Columns.IdDatoReportable); }
			set { SetColumnValue(Columns.IdDatoReportable, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("UnidadMedida")]
		[Bindable(true)]
		public string UnidadMedida 
		{
			get { return GetColumnValue<string>(Columns.UnidadMedida); }
			set { SetColumnValue(Columns.UnidadMedida, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnRelNomencladorXDatoReportableCollection colPnRelNomencladorXDatoReportableRecords;
		public DalSic.PnRelNomencladorXDatoReportableCollection PnRelNomencladorXDatoReportableRecords
		{
			get
			{
				if(colPnRelNomencladorXDatoReportableRecords == null)
				{
					colPnRelNomencladorXDatoReportableRecords = new DalSic.PnRelNomencladorXDatoReportableCollection().Where(PnRelNomencladorXDatoReportable.Columns.IdDatoReportable, IdDatoReportable).Load();
					colPnRelNomencladorXDatoReportableRecords.ListChanged += new ListChangedEventHandler(colPnRelNomencladorXDatoReportableRecords_ListChanged);
				}
				return colPnRelNomencladorXDatoReportableRecords;			
			}
			set 
			{ 
					colPnRelNomencladorXDatoReportableRecords = value; 
					colPnRelNomencladorXDatoReportableRecords.ListChanged += new ListChangedEventHandler(colPnRelNomencladorXDatoReportableRecords_ListChanged);
			}
		}
		
		void colPnRelNomencladorXDatoReportableRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnRelNomencladorXDatoReportableRecords[e.NewIndex].IdDatoReportable = IdDatoReportable;
		    }
		}
				
		private DalSic.PnRelPrestacionXDatoReportableCollection colPnRelPrestacionXDatoReportableRecords;
		public DalSic.PnRelPrestacionXDatoReportableCollection PnRelPrestacionXDatoReportableRecords
		{
			get
			{
				if(colPnRelPrestacionXDatoReportableRecords == null)
				{
					colPnRelPrestacionXDatoReportableRecords = new DalSic.PnRelPrestacionXDatoReportableCollection().Where(PnRelPrestacionXDatoReportable.Columns.IdDatoReportable, IdDatoReportable).Load();
					colPnRelPrestacionXDatoReportableRecords.ListChanged += new ListChangedEventHandler(colPnRelPrestacionXDatoReportableRecords_ListChanged);
				}
				return colPnRelPrestacionXDatoReportableRecords;			
			}
			set 
			{ 
					colPnRelPrestacionXDatoReportableRecords = value; 
					colPnRelPrestacionXDatoReportableRecords.ListChanged += new ListChangedEventHandler(colPnRelPrestacionXDatoReportableRecords_ListChanged);
			}
		}
		
		void colPnRelPrestacionXDatoReportableRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnRelPrestacionXDatoReportableRecords[e.NewIndex].IdDatoReportable = IdDatoReportable;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varUnidadMedida)
		{
			PnDatosReportable item = new PnDatosReportable();
			
			item.Nombre = varNombre;
			
			item.UnidadMedida = varUnidadMedida;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDatoReportable,string varNombre,string varUnidadMedida)
		{
			PnDatosReportable item = new PnDatosReportable();
			
				item.IdDatoReportable = varIdDatoReportable;
			
				item.Nombre = varNombre;
			
				item.UnidadMedida = varUnidadMedida;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDatoReportableColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadMedidaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdDatoReportable = @"idDatoReportable";
			 public static string Nombre = @"nombre";
			 public static string UnidadMedida = @"unidad_medida";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnRelNomencladorXDatoReportableRecords != null)
                {
                    foreach (DalSic.PnRelNomencladorXDatoReportable item in colPnRelNomencladorXDatoReportableRecords)
                    {
                        if (item.IdDatoReportable != IdDatoReportable)
                        {
                            item.IdDatoReportable = IdDatoReportable;
                        }
                    }
               }
		
                if (colPnRelPrestacionXDatoReportableRecords != null)
                {
                    foreach (DalSic.PnRelPrestacionXDatoReportable item in colPnRelPrestacionXDatoReportableRecords)
                    {
                        if (item.IdDatoReportable != IdDatoReportable)
                        {
                            item.IdDatoReportable = IdDatoReportable;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnRelNomencladorXDatoReportableRecords != null)
                {
                    colPnRelNomencladorXDatoReportableRecords.SaveAll();
               }
		
                if (colPnRelPrestacionXDatoReportableRecords != null)
                {
                    colPnRelPrestacionXDatoReportableRecords.SaveAll();
               }
		}
        #endregion
	}
}
