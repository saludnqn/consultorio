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
	/// Strongly-typed collection for the AprActividadEmbarazo class.
	/// </summary>
    [Serializable]
	public partial class AprActividadEmbarazoCollection : ActiveList<AprActividadEmbarazo, AprActividadEmbarazoCollection>
	{	   
		public AprActividadEmbarazoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprActividadEmbarazoCollection</returns>
		public AprActividadEmbarazoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprActividadEmbarazo o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ActividadEmbarazo table.
	/// </summary>
	[Serializable]
	public partial class AprActividadEmbarazo : ActiveRecord<AprActividadEmbarazo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprActividadEmbarazo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprActividadEmbarazo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprActividadEmbarazo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprActividadEmbarazo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ActividadEmbarazo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdActividadEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdActividadEmbarazo.ColumnName = "idActividadEmbarazo";
				colvarIdActividadEmbarazo.DataType = DbType.Int32;
				colvarIdActividadEmbarazo.MaxLength = 0;
				colvarIdActividadEmbarazo.AutoIncrement = true;
				colvarIdActividadEmbarazo.IsNullable = false;
				colvarIdActividadEmbarazo.IsPrimaryKey = true;
				colvarIdActividadEmbarazo.IsForeignKey = false;
				colvarIdActividadEmbarazo.IsReadOnly = false;
				colvarIdActividadEmbarazo.DefaultSetting = @"";
				colvarIdActividadEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdActividadEmbarazo);
				
				TableSchema.TableColumn colvarIdTipoActividadEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdTipoActividadEmbarazo.ColumnName = "idTipoActividadEmbarazo";
				colvarIdTipoActividadEmbarazo.DataType = DbType.Int32;
				colvarIdTipoActividadEmbarazo.MaxLength = 0;
				colvarIdTipoActividadEmbarazo.AutoIncrement = false;
				colvarIdTipoActividadEmbarazo.IsNullable = false;
				colvarIdTipoActividadEmbarazo.IsPrimaryKey = false;
				colvarIdTipoActividadEmbarazo.IsForeignKey = true;
				colvarIdTipoActividadEmbarazo.IsReadOnly = false;
				colvarIdTipoActividadEmbarazo.DefaultSetting = @"";
				
					colvarIdTipoActividadEmbarazo.ForeignKeyTableName = "APR_TipoActividadEmbarazo";
				schema.Columns.Add(colvarIdTipoActividadEmbarazo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
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
				DataService.Providers["sicProvider"].AddSchema("APR_ActividadEmbarazo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdActividadEmbarazo")]
		[Bindable(true)]
		public int IdActividadEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdActividadEmbarazo); }
			set { SetColumnValue(Columns.IdActividadEmbarazo, value); }
		}
		  
		[XmlAttribute("IdTipoActividadEmbarazo")]
		[Bindable(true)]
		public int IdTipoActividadEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdTipoActividadEmbarazo); }
			set { SetColumnValue(Columns.IdTipoActividadEmbarazo, value); }
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
        
				
		private DalSic.AprActividadControlPerinatalCollection colAprActividadControlPerinatalRecords;
		public DalSic.AprActividadControlPerinatalCollection AprActividadControlPerinatalRecords
		{
			get
			{
				if(colAprActividadControlPerinatalRecords == null)
				{
					colAprActividadControlPerinatalRecords = new DalSic.AprActividadControlPerinatalCollection().Where(AprActividadControlPerinatal.Columns.IdActividadEmbarazo, IdActividadEmbarazo).Load();
					colAprActividadControlPerinatalRecords.ListChanged += new ListChangedEventHandler(colAprActividadControlPerinatalRecords_ListChanged);
				}
				return colAprActividadControlPerinatalRecords;			
			}
			set 
			{ 
					colAprActividadControlPerinatalRecords = value; 
					colAprActividadControlPerinatalRecords.ListChanged += new ListChangedEventHandler(colAprActividadControlPerinatalRecords_ListChanged);
			}
		}
		
		void colAprActividadControlPerinatalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprActividadControlPerinatalRecords[e.NewIndex].IdActividadEmbarazo = IdActividadEmbarazo;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprTipoActividadEmbarazo ActiveRecord object related to this AprActividadEmbarazo
		/// 
		/// </summary>
		public DalSic.AprTipoActividadEmbarazo AprTipoActividadEmbarazo
		{
			get { return DalSic.AprTipoActividadEmbarazo.FetchByID(this.IdTipoActividadEmbarazo); }
			set { SetColumnValue("idTipoActividadEmbarazo", value.IdTipoActividadEmbarazo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdTipoActividadEmbarazo,string varNombre)
		{
			AprActividadEmbarazo item = new AprActividadEmbarazo();
			
			item.IdTipoActividadEmbarazo = varIdTipoActividadEmbarazo;
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdActividadEmbarazo,int varIdTipoActividadEmbarazo,string varNombre)
		{
			AprActividadEmbarazo item = new AprActividadEmbarazo();
			
				item.IdActividadEmbarazo = varIdActividadEmbarazo;
			
				item.IdTipoActividadEmbarazo = varIdTipoActividadEmbarazo;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdActividadEmbarazoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoActividadEmbarazoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdActividadEmbarazo = @"idActividadEmbarazo";
			 public static string IdTipoActividadEmbarazo = @"idTipoActividadEmbarazo";
			 public static string Nombre = @"Nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprActividadControlPerinatalRecords != null)
                {
                    foreach (DalSic.AprActividadControlPerinatal item in colAprActividadControlPerinatalRecords)
                    {
                        if (item.IdActividadEmbarazo != IdActividadEmbarazo)
                        {
                            item.IdActividadEmbarazo = IdActividadEmbarazo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprActividadControlPerinatalRecords != null)
                {
                    colAprActividadControlPerinatalRecords.SaveAll();
               }
		}
        #endregion
	}
}
