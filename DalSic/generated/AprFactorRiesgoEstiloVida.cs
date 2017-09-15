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
	/// Strongly-typed collection for the AprFactorRiesgoEstiloVida class.
	/// </summary>
    [Serializable]
	public partial class AprFactorRiesgoEstiloVidaCollection : ActiveList<AprFactorRiesgoEstiloVida, AprFactorRiesgoEstiloVidaCollection>
	{	   
		public AprFactorRiesgoEstiloVidaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprFactorRiesgoEstiloVidaCollection</returns>
		public AprFactorRiesgoEstiloVidaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprFactorRiesgoEstiloVida o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_FactorRiesgoEstiloVida table.
	/// </summary>
	[Serializable]
	public partial class AprFactorRiesgoEstiloVida : ActiveRecord<AprFactorRiesgoEstiloVida>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprFactorRiesgoEstiloVida()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprFactorRiesgoEstiloVida(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprFactorRiesgoEstiloVida(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprFactorRiesgoEstiloVida(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_FactorRiesgoEstiloVida", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdFactorRiesgoEstiloVida = new TableSchema.TableColumn(schema);
				colvarIdFactorRiesgoEstiloVida.ColumnName = "idFactorRiesgoEstiloVida";
				colvarIdFactorRiesgoEstiloVida.DataType = DbType.Int32;
				colvarIdFactorRiesgoEstiloVida.MaxLength = 0;
				colvarIdFactorRiesgoEstiloVida.AutoIncrement = true;
				colvarIdFactorRiesgoEstiloVida.IsNullable = false;
				colvarIdFactorRiesgoEstiloVida.IsPrimaryKey = true;
				colvarIdFactorRiesgoEstiloVida.IsForeignKey = false;
				colvarIdFactorRiesgoEstiloVida.IsReadOnly = false;
				colvarIdFactorRiesgoEstiloVida.DefaultSetting = @"";
				colvarIdFactorRiesgoEstiloVida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFactorRiesgoEstiloVida);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_FactorRiesgoEstiloVida",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdFactorRiesgoEstiloVida")]
		[Bindable(true)]
		public int IdFactorRiesgoEstiloVida 
		{
			get { return GetColumnValue<int>(Columns.IdFactorRiesgoEstiloVida); }
			set { SetColumnValue(Columns.IdFactorRiesgoEstiloVida, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprEstiloVidaCollection colAprEstiloVidaRecords;
		public DalSic.AprEstiloVidaCollection AprEstiloVidaRecords
		{
			get
			{
				if(colAprEstiloVidaRecords == null)
				{
					colAprEstiloVidaRecords = new DalSic.AprEstiloVidaCollection().Where(AprEstiloVida.Columns.IdFactorRiesgoEstiloVida, IdFactorRiesgoEstiloVida).Load();
					colAprEstiloVidaRecords.ListChanged += new ListChangedEventHandler(colAprEstiloVidaRecords_ListChanged);
				}
				return colAprEstiloVidaRecords;			
			}
			set 
			{ 
					colAprEstiloVidaRecords = value; 
					colAprEstiloVidaRecords.ListChanged += new ListChangedEventHandler(colAprEstiloVidaRecords_ListChanged);
			}
		}
		
		void colAprEstiloVidaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprEstiloVidaRecords[e.NewIndex].IdFactorRiesgoEstiloVida = IdFactorRiesgoEstiloVida;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			AprFactorRiesgoEstiloVida item = new AprFactorRiesgoEstiloVida();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdFactorRiesgoEstiloVida,string varNombre)
		{
			AprFactorRiesgoEstiloVida item = new AprFactorRiesgoEstiloVida();
			
				item.IdFactorRiesgoEstiloVida = varIdFactorRiesgoEstiloVida;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdFactorRiesgoEstiloVidaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdFactorRiesgoEstiloVida = @"idFactorRiesgoEstiloVida";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprEstiloVidaRecords != null)
                {
                    foreach (DalSic.AprEstiloVida item in colAprEstiloVidaRecords)
                    {
                        if (item.IdFactorRiesgoEstiloVida != IdFactorRiesgoEstiloVida)
                        {
                            item.IdFactorRiesgoEstiloVida = IdFactorRiesgoEstiloVida;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprEstiloVidaRecords != null)
                {
                    colAprEstiloVidaRecords.SaveAll();
               }
		}
        #endregion
	}
}
