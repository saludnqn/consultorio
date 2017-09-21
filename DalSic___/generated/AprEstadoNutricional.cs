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
	/// Strongly-typed collection for the AprEstadoNutricional class.
	/// </summary>
    [Serializable]
	public partial class AprEstadoNutricionalCollection : ActiveList<AprEstadoNutricional, AprEstadoNutricionalCollection>
	{	   
		public AprEstadoNutricionalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprEstadoNutricionalCollection</returns>
		public AprEstadoNutricionalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprEstadoNutricional o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_EstadoNutricional table.
	/// </summary>
	[Serializable]
	public partial class AprEstadoNutricional : ActiveRecord<AprEstadoNutricional>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprEstadoNutricional()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprEstadoNutricional(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprEstadoNutricional(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprEstadoNutricional(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_EstadoNutricional", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstadoNutricional = new TableSchema.TableColumn(schema);
				colvarIdEstadoNutricional.ColumnName = "idEstadoNutricional";
				colvarIdEstadoNutricional.DataType = DbType.Int32;
				colvarIdEstadoNutricional.MaxLength = 0;
				colvarIdEstadoNutricional.AutoIncrement = true;
				colvarIdEstadoNutricional.IsNullable = false;
				colvarIdEstadoNutricional.IsPrimaryKey = true;
				colvarIdEstadoNutricional.IsForeignKey = false;
				colvarIdEstadoNutricional.IsReadOnly = false;
				colvarIdEstadoNutricional.DefaultSetting = @"";
				colvarIdEstadoNutricional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadoNutricional);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarMinSemanas = new TableSchema.TableColumn(schema);
				colvarMinSemanas.ColumnName = "MinSemanas";
				colvarMinSemanas.DataType = DbType.Int32;
				colvarMinSemanas.MaxLength = 0;
				colvarMinSemanas.AutoIncrement = false;
				colvarMinSemanas.IsNullable = false;
				colvarMinSemanas.IsPrimaryKey = false;
				colvarMinSemanas.IsForeignKey = false;
				colvarMinSemanas.IsReadOnly = false;
				colvarMinSemanas.DefaultSetting = @"";
				colvarMinSemanas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMinSemanas);
				
				TableSchema.TableColumn colvarMaxSemanas = new TableSchema.TableColumn(schema);
				colvarMaxSemanas.ColumnName = "MaxSemanas";
				colvarMaxSemanas.DataType = DbType.Int32;
				colvarMaxSemanas.MaxLength = 0;
				colvarMaxSemanas.AutoIncrement = false;
				colvarMaxSemanas.IsNullable = false;
				colvarMaxSemanas.IsPrimaryKey = false;
				colvarMaxSemanas.IsForeignKey = false;
				colvarMaxSemanas.IsReadOnly = false;
				colvarMaxSemanas.DefaultSetting = @"";
				colvarMaxSemanas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaxSemanas);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_EstadoNutricional",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstadoNutricional")]
		[Bindable(true)]
		public int IdEstadoNutricional 
		{
			get { return GetColumnValue<int>(Columns.IdEstadoNutricional); }
			set { SetColumnValue(Columns.IdEstadoNutricional, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("MinSemanas")]
		[Bindable(true)]
		public int MinSemanas 
		{
			get { return GetColumnValue<int>(Columns.MinSemanas); }
			set { SetColumnValue(Columns.MinSemanas, value); }
		}
		  
		[XmlAttribute("MaxSemanas")]
		[Bindable(true)]
		public int MaxSemanas 
		{
			get { return GetColumnValue<int>(Columns.MaxSemanas); }
			set { SetColumnValue(Columns.MaxSemanas, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprControlNiñoSanoEnfermeriumCollection colAprControlNiñoSanoEnfermeria;
		public DalSic.AprControlNiñoSanoEnfermeriumCollection AprControlNiñoSanoEnfermeria
		{
			get
			{
				if(colAprControlNiñoSanoEnfermeria == null)
				{
					colAprControlNiñoSanoEnfermeria = new DalSic.AprControlNiñoSanoEnfermeriumCollection().Where(AprControlNiñoSanoEnfermerium.Columns.IdEstadoNutricional, IdEstadoNutricional).Load();
					colAprControlNiñoSanoEnfermeria.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoEnfermeria_ListChanged);
				}
				return colAprControlNiñoSanoEnfermeria;			
			}
			set 
			{ 
					colAprControlNiñoSanoEnfermeria = value; 
					colAprControlNiñoSanoEnfermeria.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoEnfermeria_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoEnfermeria_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoEnfermeria[e.NewIndex].IdEstadoNutricional = IdEstadoNutricional;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varMinSemanas,int varMaxSemanas,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprEstadoNutricional item = new AprEstadoNutricional();
			
			item.Nombre = varNombre;
			
			item.MinSemanas = varMinSemanas;
			
			item.MaxSemanas = varMaxSemanas;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstadoNutricional,string varNombre,int varMinSemanas,int varMaxSemanas,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprEstadoNutricional item = new AprEstadoNutricional();
			
				item.IdEstadoNutricional = varIdEstadoNutricional;
			
				item.Nombre = varNombre;
			
				item.MinSemanas = varMinSemanas;
			
				item.MaxSemanas = varMaxSemanas;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstadoNutricionalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MinSemanasColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MaxSemanasColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstadoNutricional = @"idEstadoNutricional";
			 public static string Nombre = @"Nombre";
			 public static string MinSemanas = @"MinSemanas";
			 public static string MaxSemanas = @"MaxSemanas";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    foreach (DalSic.AprControlNiñoSanoEnfermerium item in colAprControlNiñoSanoEnfermeria)
                    {
                        if (item.IdEstadoNutricional != IdEstadoNutricional)
                        {
                            item.IdEstadoNutricional = IdEstadoNutricional;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    colAprControlNiñoSanoEnfermeria.SaveAll();
               }
		}
        #endregion
	}
}
