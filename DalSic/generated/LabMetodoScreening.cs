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
	/// Strongly-typed collection for the LabMetodoScreening class.
	/// </summary>
    [Serializable]
	public partial class LabMetodoScreeningCollection : ActiveList<LabMetodoScreening, LabMetodoScreeningCollection>
	{	   
		public LabMetodoScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabMetodoScreeningCollection</returns>
		public LabMetodoScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabMetodoScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_MetodoScreening table.
	/// </summary>
	[Serializable]
	public partial class LabMetodoScreening : ActiveRecord<LabMetodoScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabMetodoScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabMetodoScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabMetodoScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabMetodoScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_MetodoScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMetodoScreening = new TableSchema.TableColumn(schema);
				colvarIdMetodoScreening.ColumnName = "idMetodoScreening";
				colvarIdMetodoScreening.DataType = DbType.Int32;
				colvarIdMetodoScreening.MaxLength = 0;
				colvarIdMetodoScreening.AutoIncrement = true;
				colvarIdMetodoScreening.IsNullable = false;
				colvarIdMetodoScreening.IsPrimaryKey = true;
				colvarIdMetodoScreening.IsForeignKey = false;
				colvarIdMetodoScreening.IsReadOnly = false;
				colvarIdMetodoScreening.DefaultSetting = @"";
				colvarIdMetodoScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMetodoScreening);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 500;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "Baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = false;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				
						colvarBaja.DefaultSetting = @"((0))";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_MetodoScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMetodoScreening")]
		[Bindable(true)]
		public int IdMetodoScreening 
		{
			get { return GetColumnValue<int>(Columns.IdMetodoScreening); }
			set { SetColumnValue(Columns.IdMetodoScreening, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool Baja 
		{
			get { return GetColumnValue<bool>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.LabItemScreeningCollection colLabItemScreeningRecords;
		public DalSic.LabItemScreeningCollection LabItemScreeningRecords
		{
			get
			{
				if(colLabItemScreeningRecords == null)
				{
					colLabItemScreeningRecords = new DalSic.LabItemScreeningCollection().Where(LabItemScreening.Columns.IdMetodo, IdMetodoScreening).Load();
					colLabItemScreeningRecords.ListChanged += new ListChangedEventHandler(colLabItemScreeningRecords_ListChanged);
				}
				return colLabItemScreeningRecords;			
			}
			set 
			{ 
					colLabItemScreeningRecords = value; 
					colLabItemScreeningRecords.ListChanged += new ListChangedEventHandler(colLabItemScreeningRecords_ListChanged);
			}
		}
		
		void colLabItemScreeningRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabItemScreeningRecords[e.NewIndex].IdMetodo = IdMetodoScreening;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,bool varBaja)
		{
			LabMetodoScreening item = new LabMetodoScreening();
			
			item.Descripcion = varDescripcion;
			
			item.Baja = varBaja;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMetodoScreening,string varDescripcion,bool varBaja)
		{
			LabMetodoScreening item = new LabMetodoScreening();
			
				item.IdMetodoScreening = varIdMetodoScreening;
			
				item.Descripcion = varDescripcion;
			
				item.Baja = varBaja;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMetodoScreeningColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMetodoScreening = @"idMetodoScreening";
			 public static string Descripcion = @"descripcion";
			 public static string Baja = @"Baja";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colLabItemScreeningRecords != null)
                {
                    foreach (DalSic.LabItemScreening item in colLabItemScreeningRecords)
                    {
                        if (item.IdMetodo != IdMetodoScreening)
                        {
                            item.IdMetodo = IdMetodoScreening;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colLabItemScreeningRecords != null)
                {
                    colLabItemScreeningRecords.SaveAll();
               }
		}
        #endregion
	}
}
