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
	/// Strongly-typed collection for the PnGrupo class.
	/// </summary>
    [Serializable]
	public partial class PnGrupoCollection : ActiveList<PnGrupo, PnGrupoCollection>
	{	   
		public PnGrupoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnGrupoCollection</returns>
		public PnGrupoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnGrupo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_grupos table.
	/// </summary>
	[Serializable]
	public partial class PnGrupo : ActiveRecord<PnGrupo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnGrupo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnGrupo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnGrupo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnGrupo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_grupos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdGrupo = new TableSchema.TableColumn(schema);
				colvarIdGrupo.ColumnName = "id_grupo";
				colvarIdGrupo.DataType = DbType.Int32;
				colvarIdGrupo.MaxLength = 0;
				colvarIdGrupo.AutoIncrement = true;
				colvarIdGrupo.IsNullable = false;
				colvarIdGrupo.IsPrimaryKey = true;
				colvarIdGrupo.IsForeignKey = false;
				colvarIdGrupo.IsReadOnly = false;
				colvarIdGrupo.DefaultSetting = @"";
				colvarIdGrupo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdGrupo);
				
				TableSchema.TableColumn colvarUname = new TableSchema.TableColumn(schema);
				colvarUname.ColumnName = "uname";
				colvarUname.DataType = DbType.AnsiString;
				colvarUname.MaxLength = -1;
				colvarUname.AutoIncrement = false;
				colvarUname.IsNullable = false;
				colvarUname.IsPrimaryKey = false;
				colvarUname.IsForeignKey = false;
				colvarUname.IsReadOnly = false;
				colvarUname.DefaultSetting = @"";
				colvarUname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUname);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_grupos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdGrupo")]
		[Bindable(true)]
		public int IdGrupo 
		{
			get { return GetColumnValue<int>(Columns.IdGrupo); }
			set { SetColumnValue(Columns.IdGrupo, value); }
		}
		  
		[XmlAttribute("Uname")]
		[Bindable(true)]
		public string Uname 
		{
			get { return GetColumnValue<string>(Columns.Uname); }
			set { SetColumnValue(Columns.Uname, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnGruposUsuarioCollection colPnGruposUsuarios;
		public DalSic.PnGruposUsuarioCollection PnGruposUsuarios
		{
			get
			{
				if(colPnGruposUsuarios == null)
				{
					colPnGruposUsuarios = new DalSic.PnGruposUsuarioCollection().Where(PnGruposUsuario.Columns.IdGrupo, IdGrupo).Load();
					colPnGruposUsuarios.ListChanged += new ListChangedEventHandler(colPnGruposUsuarios_ListChanged);
				}
				return colPnGruposUsuarios;			
			}
			set 
			{ 
					colPnGruposUsuarios = value; 
					colPnGruposUsuarios.ListChanged += new ListChangedEventHandler(colPnGruposUsuarios_ListChanged);
			}
		}
		
		void colPnGruposUsuarios_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnGruposUsuarios[e.NewIndex].IdGrupo = IdGrupo;
		    }
		}
				
		private DalSic.PnPermisosGrupoCollection colPnPermisosGrupos;
		public DalSic.PnPermisosGrupoCollection PnPermisosGrupos
		{
			get
			{
				if(colPnPermisosGrupos == null)
				{
					colPnPermisosGrupos = new DalSic.PnPermisosGrupoCollection().Where(PnPermisosGrupo.Columns.IdGrupo, IdGrupo).Load();
					colPnPermisosGrupos.ListChanged += new ListChangedEventHandler(colPnPermisosGrupos_ListChanged);
				}
				return colPnPermisosGrupos;			
			}
			set 
			{ 
					colPnPermisosGrupos = value; 
					colPnPermisosGrupos.ListChanged += new ListChangedEventHandler(colPnPermisosGrupos_ListChanged);
			}
		}
		
		void colPnPermisosGrupos_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisosGrupos[e.NewIndex].IdGrupo = IdGrupo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUname)
		{
			PnGrupo item = new PnGrupo();
			
			item.Uname = varUname;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdGrupo,string varUname)
		{
			PnGrupo item = new PnGrupo();
			
				item.IdGrupo = varIdGrupo;
			
				item.Uname = varUname;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdGrupoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UnameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdGrupo = @"id_grupo";
			 public static string Uname = @"uname";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnGruposUsuarios != null)
                {
                    foreach (DalSic.PnGruposUsuario item in colPnGruposUsuarios)
                    {
                        if (item.IdGrupo != IdGrupo)
                        {
                            item.IdGrupo = IdGrupo;
                        }
                    }
               }
		
                if (colPnPermisosGrupos != null)
                {
                    foreach (DalSic.PnPermisosGrupo item in colPnPermisosGrupos)
                    {
                        if (item.IdGrupo != IdGrupo)
                        {
                            item.IdGrupo = IdGrupo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnGruposUsuarios != null)
                {
                    colPnGruposUsuarios.SaveAll();
               }
		
                if (colPnPermisosGrupos != null)
                {
                    colPnPermisosGrupos.SaveAll();
               }
		}
        #endregion
	}
}
