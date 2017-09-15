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
	/// Strongly-typed collection for the MamMaterial class.
	/// </summary>
    [Serializable]
	public partial class MamMaterialCollection : ActiveList<MamMaterial, MamMaterialCollection>
	{	   
		public MamMaterialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamMaterialCollection</returns>
		public MamMaterialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamMaterial o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_Material table.
	/// </summary>
	[Serializable]
	public partial class MamMaterial : ActiveRecord<MamMaterial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamMaterial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamMaterial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamMaterial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamMaterial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_Material", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMaterial = new TableSchema.TableColumn(schema);
				colvarIdMaterial.ColumnName = "idMaterial";
				colvarIdMaterial.DataType = DbType.Int32;
				colvarIdMaterial.MaxLength = 0;
				colvarIdMaterial.AutoIncrement = true;
				colvarIdMaterial.IsNullable = false;
				colvarIdMaterial.IsPrimaryKey = true;
				colvarIdMaterial.IsForeignKey = false;
				colvarIdMaterial.IsReadOnly = false;
				colvarIdMaterial.DefaultSetting = @"";
				colvarIdMaterial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMaterial);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 20;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				
						colvarDescripcion.DefaultSetting = @"('')";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_Material",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMaterial")]
		[Bindable(true)]
		public int IdMaterial 
		{
			get { return GetColumnValue<int>(Columns.IdMaterial); }
			set { SetColumnValue(Columns.IdMaterial, value); }
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
        
				
		private DalSic.MamCirugiumCollection colMamCirugia;
		public DalSic.MamCirugiumCollection MamCirugia
		{
			get
			{
				if(colMamCirugia == null)
				{
					colMamCirugia = new DalSic.MamCirugiumCollection().Where(MamCirugium.Columns.IdMaterialDer, IdMaterial).Load();
					colMamCirugia.ListChanged += new ListChangedEventHandler(colMamCirugia_ListChanged);
				}
				return colMamCirugia;			
			}
			set 
			{ 
					colMamCirugia = value; 
					colMamCirugia.ListChanged += new ListChangedEventHandler(colMamCirugia_ListChanged);
			}
		}
		
		void colMamCirugia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamCirugia[e.NewIndex].IdMaterialDer = IdMaterial;
		    }
		}
				
		private DalSic.MamCirugiumCollection colMamCirugiaFromMamMaterial;
		public DalSic.MamCirugiumCollection MamCirugiaFromMamMaterial
		{
			get
			{
				if(colMamCirugiaFromMamMaterial == null)
				{
					colMamCirugiaFromMamMaterial = new DalSic.MamCirugiumCollection().Where(MamCirugium.Columns.IdMaterialIzq, IdMaterial).Load();
					colMamCirugiaFromMamMaterial.ListChanged += new ListChangedEventHandler(colMamCirugiaFromMamMaterial_ListChanged);
				}
				return colMamCirugiaFromMamMaterial;			
			}
			set 
			{ 
					colMamCirugiaFromMamMaterial = value; 
					colMamCirugiaFromMamMaterial.ListChanged += new ListChangedEventHandler(colMamCirugiaFromMamMaterial_ListChanged);
			}
		}
		
		void colMamCirugiaFromMamMaterial_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamCirugiaFromMamMaterial[e.NewIndex].IdMaterialIzq = IdMaterial;
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
			MamMaterial item = new MamMaterial();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMaterial,string varDescripcion)
		{
			MamMaterial item = new MamMaterial();
			
				item.IdMaterial = varIdMaterial;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMaterialColumn
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
			 public static string IdMaterial = @"idMaterial";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamCirugia != null)
                {
                    foreach (DalSic.MamCirugium item in colMamCirugia)
                    {
                        if (item.IdMaterialDer != IdMaterial)
                        {
                            item.IdMaterialDer = IdMaterial;
                        }
                    }
               }
		
                if (colMamCirugiaFromMamMaterial != null)
                {
                    foreach (DalSic.MamCirugium item in colMamCirugiaFromMamMaterial)
                    {
                        if (item.IdMaterialIzq != IdMaterial)
                        {
                            item.IdMaterialIzq = IdMaterial;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamCirugia != null)
                {
                    colMamCirugia.SaveAll();
               }
		
                if (colMamCirugiaFromMamMaterial != null)
                {
                    colMamCirugiaFromMamMaterial.SaveAll();
               }
		}
        #endregion
	}
}
