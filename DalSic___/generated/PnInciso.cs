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
	/// Strongly-typed collection for the PnInciso class.
	/// </summary>
    [Serializable]
	public partial class PnIncisoCollection : ActiveList<PnInciso, PnIncisoCollection>
	{	   
		public PnIncisoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnIncisoCollection</returns>
		public PnIncisoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnInciso o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_inciso table.
	/// </summary>
	[Serializable]
	public partial class PnInciso : ActiveRecord<PnInciso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnInciso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnInciso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnInciso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnInciso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_inciso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdInciso = new TableSchema.TableColumn(schema);
				colvarIdInciso.ColumnName = "id_inciso";
				colvarIdInciso.DataType = DbType.Int32;
				colvarIdInciso.MaxLength = 0;
				colvarIdInciso.AutoIncrement = true;
				colvarIdInciso.IsNullable = false;
				colvarIdInciso.IsPrimaryKey = true;
				colvarIdInciso.IsForeignKey = false;
				colvarIdInciso.IsReadOnly = false;
				colvarIdInciso.DefaultSetting = @"";
				colvarIdInciso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInciso);
				
				TableSchema.TableColumn colvarInsNombre = new TableSchema.TableColumn(schema);
				colvarInsNombre.ColumnName = "ins_nombre";
				colvarInsNombre.DataType = DbType.AnsiString;
				colvarInsNombre.MaxLength = -1;
				colvarInsNombre.AutoIncrement = false;
				colvarInsNombre.IsNullable = true;
				colvarInsNombre.IsPrimaryKey = false;
				colvarInsNombre.IsForeignKey = false;
				colvarInsNombre.IsReadOnly = false;
				colvarInsNombre.DefaultSetting = @"";
				colvarInsNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsNombre);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiString;
				colvarCodigo.MaxLength = 3;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				
						colvarCodigo.DefaultSetting = @"((0.0))";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_inciso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdInciso")]
		[Bindable(true)]
		public int IdInciso 
		{
			get { return GetColumnValue<int>(Columns.IdInciso); }
			set { SetColumnValue(Columns.IdInciso, value); }
		}
		  
		[XmlAttribute("InsNombre")]
		[Bindable(true)]
		public string InsNombre 
		{
			get { return GetColumnValue<string>(Columns.InsNombre); }
			set { SetColumnValue(Columns.InsNombre, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnIncisoItemGastoCollection colPnIncisoItemGastoRecords;
		public DalSic.PnIncisoItemGastoCollection PnIncisoItemGastoRecords
		{
			get
			{
				if(colPnIncisoItemGastoRecords == null)
				{
					colPnIncisoItemGastoRecords = new DalSic.PnIncisoItemGastoCollection().Where(PnIncisoItemGasto.Columns.IdInciso, IdInciso).Load();
					colPnIncisoItemGastoRecords.ListChanged += new ListChangedEventHandler(colPnIncisoItemGastoRecords_ListChanged);
				}
				return colPnIncisoItemGastoRecords;			
			}
			set 
			{ 
					colPnIncisoItemGastoRecords = value; 
					colPnIncisoItemGastoRecords.ListChanged += new ListChangedEventHandler(colPnIncisoItemGastoRecords_ListChanged);
			}
		}
		
		void colPnIncisoItemGastoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnIncisoItemGastoRecords[e.NewIndex].IdInciso = IdInciso;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varInsNombre,string varCodigo)
		{
			PnInciso item = new PnInciso();
			
			item.InsNombre = varInsNombre;
			
			item.Codigo = varCodigo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdInciso,string varInsNombre,string varCodigo)
		{
			PnInciso item = new PnInciso();
			
				item.IdInciso = varIdInciso;
			
				item.InsNombre = varInsNombre;
			
				item.Codigo = varCodigo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdIncisoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn InsNombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdInciso = @"id_inciso";
			 public static string InsNombre = @"ins_nombre";
			 public static string Codigo = @"codigo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnIncisoItemGastoRecords != null)
                {
                    foreach (DalSic.PnIncisoItemGasto item in colPnIncisoItemGastoRecords)
                    {
                        if (item.IdInciso != IdInciso)
                        {
                            item.IdInciso = IdInciso;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnIncisoItemGastoRecords != null)
                {
                    colPnIncisoItemGastoRecords.SaveAll();
               }
		}
        #endregion
	}
}
