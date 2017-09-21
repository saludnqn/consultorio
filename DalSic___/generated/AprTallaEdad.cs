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
	/// Strongly-typed collection for the AprTallaEdad class.
	/// </summary>
    [Serializable]
	public partial class AprTallaEdadCollection : ActiveList<AprTallaEdad, AprTallaEdadCollection>
	{	   
		public AprTallaEdadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprTallaEdadCollection</returns>
		public AprTallaEdadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprTallaEdad o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_TallaEdad table.
	/// </summary>
	[Serializable]
	public partial class AprTallaEdad : ActiveRecord<AprTallaEdad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprTallaEdad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprTallaEdad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprTallaEdad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprTallaEdad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_TallaEdad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTallaEdad = new TableSchema.TableColumn(schema);
				colvarIdTallaEdad.ColumnName = "idTallaEdad";
				colvarIdTallaEdad.DataType = DbType.Int32;
				colvarIdTallaEdad.MaxLength = 0;
				colvarIdTallaEdad.AutoIncrement = true;
				colvarIdTallaEdad.IsNullable = false;
				colvarIdTallaEdad.IsPrimaryKey = true;
				colvarIdTallaEdad.IsForeignKey = false;
				colvarIdTallaEdad.IsReadOnly = false;
				colvarIdTallaEdad.DefaultSetting = @"";
				colvarIdTallaEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTallaEdad);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_TallaEdad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTallaEdad")]
		[Bindable(true)]
		public int IdTallaEdad 
		{
			get { return GetColumnValue<int>(Columns.IdTallaEdad); }
			set { SetColumnValue(Columns.IdTallaEdad, value); }
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
        
				
		private DalSic.AprControlNiñoSanoEnfermeriumCollection colAprControlNiñoSanoEnfermeria;
		public DalSic.AprControlNiñoSanoEnfermeriumCollection AprControlNiñoSanoEnfermeria
		{
			get
			{
				if(colAprControlNiñoSanoEnfermeria == null)
				{
					colAprControlNiñoSanoEnfermeria = new DalSic.AprControlNiñoSanoEnfermeriumCollection().Where(AprControlNiñoSanoEnfermerium.Columns.IdTallaEdad, IdTallaEdad).Load();
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
		        colAprControlNiñoSanoEnfermeria[e.NewIndex].IdTallaEdad = IdTallaEdad;
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
			AprTallaEdad item = new AprTallaEdad();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTallaEdad,string varNombre)
		{
			AprTallaEdad item = new AprTallaEdad();
			
				item.IdTallaEdad = varIdTallaEdad;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTallaEdadColumn
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
			 public static string IdTallaEdad = @"idTallaEdad";
			 public static string Nombre = @"Nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    foreach (DalSic.AprControlNiñoSanoEnfermerium item in colAprControlNiñoSanoEnfermeria)
                    {
                        if (item.IdTallaEdad != IdTallaEdad)
                        {
                            item.IdTallaEdad = IdTallaEdad;
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
