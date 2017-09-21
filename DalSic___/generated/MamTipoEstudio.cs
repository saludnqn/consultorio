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
	/// Strongly-typed collection for the MamTipoEstudio class.
	/// </summary>
    [Serializable]
	public partial class MamTipoEstudioCollection : ActiveList<MamTipoEstudio, MamTipoEstudioCollection>
	{	   
		public MamTipoEstudioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamTipoEstudioCollection</returns>
		public MamTipoEstudioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamTipoEstudio o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_TipoEstudio table.
	/// </summary>
	[Serializable]
	public partial class MamTipoEstudio : ActiveRecord<MamTipoEstudio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamTipoEstudio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamTipoEstudio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamTipoEstudio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamTipoEstudio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_TipoEstudio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoEstudio = new TableSchema.TableColumn(schema);
				colvarIdTipoEstudio.ColumnName = "idTipoEstudio";
				colvarIdTipoEstudio.DataType = DbType.Int32;
				colvarIdTipoEstudio.MaxLength = 0;
				colvarIdTipoEstudio.AutoIncrement = true;
				colvarIdTipoEstudio.IsNullable = false;
				colvarIdTipoEstudio.IsPrimaryKey = true;
				colvarIdTipoEstudio.IsForeignKey = false;
				colvarIdTipoEstudio.IsReadOnly = false;
				colvarIdTipoEstudio.DefaultSetting = @"";
				colvarIdTipoEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEstudio);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdSitam = new TableSchema.TableColumn(schema);
				colvarIdSitam.ColumnName = "idSitam";
				colvarIdSitam.DataType = DbType.Int32;
				colvarIdSitam.MaxLength = 0;
				colvarIdSitam.AutoIncrement = false;
				colvarIdSitam.IsNullable = true;
				colvarIdSitam.IsPrimaryKey = false;
				colvarIdSitam.IsForeignKey = false;
				colvarIdSitam.IsReadOnly = false;
				colvarIdSitam.DefaultSetting = @"";
				colvarIdSitam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSitam);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_TipoEstudio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoEstudio")]
		[Bindable(true)]
		public int IdTipoEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdTipoEstudio); }
			set { SetColumnValue(Columns.IdTipoEstudio, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdSitam")]
		[Bindable(true)]
		public int? IdSitam 
		{
			get { return GetColumnValue<int?>(Columns.IdSitam); }
			set { SetColumnValue(Columns.IdSitam, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.MamEstudiosHospitalProvincialCollection colMamEstudiosHospitalProvincialRecords;
		public DalSic.MamEstudiosHospitalProvincialCollection MamEstudiosHospitalProvincialRecords
		{
			get
			{
				if(colMamEstudiosHospitalProvincialRecords == null)
				{
					colMamEstudiosHospitalProvincialRecords = new DalSic.MamEstudiosHospitalProvincialCollection().Where(MamEstudiosHospitalProvincial.Columns.IdTipoEstudio, IdTipoEstudio).Load();
					colMamEstudiosHospitalProvincialRecords.ListChanged += new ListChangedEventHandler(colMamEstudiosHospitalProvincialRecords_ListChanged);
				}
				return colMamEstudiosHospitalProvincialRecords;			
			}
			set 
			{ 
					colMamEstudiosHospitalProvincialRecords = value; 
					colMamEstudiosHospitalProvincialRecords.ListChanged += new ListChangedEventHandler(colMamEstudiosHospitalProvincialRecords_ListChanged);
			}
		}
		
		void colMamEstudiosHospitalProvincialRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosHospitalProvincialRecords[e.NewIndex].IdTipoEstudio = IdTipoEstudio;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int? varIdSitam)
		{
			MamTipoEstudio item = new MamTipoEstudio();
			
			item.Nombre = varNombre;
			
			item.IdSitam = varIdSitam;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoEstudio,string varNombre,int? varIdSitam)
		{
			MamTipoEstudio item = new MamTipoEstudio();
			
				item.IdTipoEstudio = varIdTipoEstudio;
			
				item.Nombre = varNombre;
			
				item.IdSitam = varIdSitam;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoEstudioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSitamColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoEstudio = @"idTipoEstudio";
			 public static string Nombre = @"nombre";
			 public static string IdSitam = @"idSitam";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamEstudiosHospitalProvincialRecords != null)
                {
                    foreach (DalSic.MamEstudiosHospitalProvincial item in colMamEstudiosHospitalProvincialRecords)
                    {
                        if (item.IdTipoEstudio != IdTipoEstudio)
                        {
                            item.IdTipoEstudio = IdTipoEstudio;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamEstudiosHospitalProvincialRecords != null)
                {
                    colMamEstudiosHospitalProvincialRecords.SaveAll();
               }
		}
        #endregion
	}
}
