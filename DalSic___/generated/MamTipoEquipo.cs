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
	/// Strongly-typed collection for the MamTipoEquipo class.
	/// </summary>
    [Serializable]
	public partial class MamTipoEquipoCollection : ActiveList<MamTipoEquipo, MamTipoEquipoCollection>
	{	   
		public MamTipoEquipoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamTipoEquipoCollection</returns>
		public MamTipoEquipoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamTipoEquipo o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_TipoEquipo table.
	/// </summary>
	[Serializable]
	public partial class MamTipoEquipo : ActiveRecord<MamTipoEquipo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamTipoEquipo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamTipoEquipo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamTipoEquipo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamTipoEquipo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_TipoEquipo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoEquipo = new TableSchema.TableColumn(schema);
				colvarIdTipoEquipo.ColumnName = "idTipoEquipo";
				colvarIdTipoEquipo.DataType = DbType.Int32;
				colvarIdTipoEquipo.MaxLength = 0;
				colvarIdTipoEquipo.AutoIncrement = true;
				colvarIdTipoEquipo.IsNullable = false;
				colvarIdTipoEquipo.IsPrimaryKey = true;
				colvarIdTipoEquipo.IsForeignKey = false;
				colvarIdTipoEquipo.IsReadOnly = false;
				colvarIdTipoEquipo.DefaultSetting = @"";
				colvarIdTipoEquipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEquipo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_TipoEquipo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoEquipo")]
		[Bindable(true)]
		public int IdTipoEquipo 
		{
			get { return GetColumnValue<int>(Columns.IdTipoEquipo); }
			set { SetColumnValue(Columns.IdTipoEquipo, value); }
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
        
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionales;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionales
		{
			get
			{
				if(colMamEstudiosAdicionales == null)
				{
					colMamEstudiosAdicionales = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdTipoEquipo, IdTipoEquipo).Load();
					colMamEstudiosAdicionales.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionales_ListChanged);
				}
				return colMamEstudiosAdicionales;			
			}
			set 
			{ 
					colMamEstudiosAdicionales = value; 
					colMamEstudiosAdicionales.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionales_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionales_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionales[e.NewIndex].IdTipoEquipo = IdTipoEquipo;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografia;
		public DalSic.MamEcografiumCollection MamEcografia
		{
			get
			{
				if(colMamEcografia == null)
				{
					colMamEcografia = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdTipoEquipo, IdTipoEquipo).Load();
					colMamEcografia.ListChanged += new ListChangedEventHandler(colMamEcografia_ListChanged);
				}
				return colMamEcografia;			
			}
			set 
			{ 
					colMamEcografia = value; 
					colMamEcografia.ListChanged += new ListChangedEventHandler(colMamEcografia_ListChanged);
			}
		}
		
		void colMamEcografia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografia[e.NewIndex].IdTipoEquipo = IdTipoEquipo;
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
			MamTipoEquipo item = new MamTipoEquipo();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoEquipo,string varNombre)
		{
			MamTipoEquipo item = new MamTipoEquipo();
			
				item.IdTipoEquipo = varIdTipoEquipo;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoEquipoColumn
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
			 public static string IdTipoEquipo = @"idTipoEquipo";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamEstudiosAdicionales != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionales)
                    {
                        if (item.IdTipoEquipo != IdTipoEquipo)
                        {
                            item.IdTipoEquipo = IdTipoEquipo;
                        }
                    }
               }
		
                if (colMamEcografia != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografia)
                    {
                        if (item.IdTipoEquipo != IdTipoEquipo)
                        {
                            item.IdTipoEquipo = IdTipoEquipo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamEstudiosAdicionales != null)
                {
                    colMamEstudiosAdicionales.SaveAll();
               }
		
                if (colMamEcografia != null)
                {
                    colMamEcografia.SaveAll();
               }
		}
        #endregion
	}
}
