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
	/// Strongly-typed collection for the GuardiaTiposEgreso class.
	/// </summary>
    [Serializable]
	public partial class GuardiaTiposEgresoCollection : ActiveList<GuardiaTiposEgreso, GuardiaTiposEgresoCollection>
	{	   
		public GuardiaTiposEgresoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaTiposEgresoCollection</returns>
		public GuardiaTiposEgresoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaTiposEgreso o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_TiposEgresos table.
	/// </summary>
	[Serializable]
	public partial class GuardiaTiposEgreso : ActiveRecord<GuardiaTiposEgreso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaTiposEgreso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaTiposEgreso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaTiposEgreso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaTiposEgreso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_TiposEgresos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
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
				
				TableSchema.TableColumn colvarTipoUbicacionRequerida = new TableSchema.TableColumn(schema);
				colvarTipoUbicacionRequerida.ColumnName = "tipoUbicacionRequerida";
				colvarTipoUbicacionRequerida.DataType = DbType.Int32;
				colvarTipoUbicacionRequerida.MaxLength = 0;
				colvarTipoUbicacionRequerida.AutoIncrement = false;
				colvarTipoUbicacionRequerida.IsNullable = true;
				colvarTipoUbicacionRequerida.IsPrimaryKey = false;
				colvarTipoUbicacionRequerida.IsForeignKey = false;
				colvarTipoUbicacionRequerida.IsReadOnly = false;
				colvarTipoUbicacionRequerida.DefaultSetting = @"";
				colvarTipoUbicacionRequerida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoUbicacionRequerida);
				
				TableSchema.TableColumn colvarSubTipoUbicacionRequerida = new TableSchema.TableColumn(schema);
				colvarSubTipoUbicacionRequerida.ColumnName = "subTipoUbicacionRequerida";
				colvarSubTipoUbicacionRequerida.DataType = DbType.Int32;
				colvarSubTipoUbicacionRequerida.MaxLength = 0;
				colvarSubTipoUbicacionRequerida.AutoIncrement = false;
				colvarSubTipoUbicacionRequerida.IsNullable = true;
				colvarSubTipoUbicacionRequerida.IsPrimaryKey = false;
				colvarSubTipoUbicacionRequerida.IsForeignKey = false;
				colvarSubTipoUbicacionRequerida.IsReadOnly = false;
				colvarSubTipoUbicacionRequerida.DefaultSetting = @"";
				colvarSubTipoUbicacionRequerida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTipoUbicacionRequerida);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_TiposEgresos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("TipoUbicacionRequerida")]
		[Bindable(true)]
		public int? TipoUbicacionRequerida 
		{
			get { return GetColumnValue<int?>(Columns.TipoUbicacionRequerida); }
			set { SetColumnValue(Columns.TipoUbicacionRequerida, value); }
		}
		  
		[XmlAttribute("SubTipoUbicacionRequerida")]
		[Bindable(true)]
		public int? SubTipoUbicacionRequerida 
		{
			get { return GetColumnValue<int?>(Columns.SubTipoUbicacionRequerida); }
			set { SetColumnValue(Columns.SubTipoUbicacionRequerida, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.GuardiaRegistroCollection colGuardiaRegistros;
		public DalSic.GuardiaRegistroCollection GuardiaRegistros
		{
			get
			{
				if(colGuardiaRegistros == null)
				{
					colGuardiaRegistros = new DalSic.GuardiaRegistroCollection().Where(GuardiaRegistro.Columns.EgresoTipo, Id).Load();
					colGuardiaRegistros.ListChanged += new ListChangedEventHandler(colGuardiaRegistros_ListChanged);
				}
				return colGuardiaRegistros;			
			}
			set 
			{ 
					colGuardiaRegistros = value; 
					colGuardiaRegistros.ListChanged += new ListChangedEventHandler(colGuardiaRegistros_ListChanged);
			}
		}
		
		void colGuardiaRegistros_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colGuardiaRegistros[e.NewIndex].EgresoTipo = Id;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int? varTipoUbicacionRequerida,int? varSubTipoUbicacionRequerida)
		{
			GuardiaTiposEgreso item = new GuardiaTiposEgreso();
			
			item.Nombre = varNombre;
			
			item.TipoUbicacionRequerida = varTipoUbicacionRequerida;
			
			item.SubTipoUbicacionRequerida = varSubTipoUbicacionRequerida;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varNombre,int? varTipoUbicacionRequerida,int? varSubTipoUbicacionRequerida)
		{
			GuardiaTiposEgreso item = new GuardiaTiposEgreso();
			
				item.Id = varId;
			
				item.Nombre = varNombre;
			
				item.TipoUbicacionRequerida = varTipoUbicacionRequerida;
			
				item.SubTipoUbicacionRequerida = varSubTipoUbicacionRequerida;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoUbicacionRequeridaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTipoUbicacionRequeridaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Nombre = @"nombre";
			 public static string TipoUbicacionRequerida = @"tipoUbicacionRequerida";
			 public static string SubTipoUbicacionRequerida = @"subTipoUbicacionRequerida";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colGuardiaRegistros != null)
                {
                    foreach (DalSic.GuardiaRegistro item in colGuardiaRegistros)
                    {
                        if (item.EgresoTipo != Id)
                        {
                            item.EgresoTipo = Id;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colGuardiaRegistros != null)
                {
                    colGuardiaRegistros.SaveAll();
               }
		}
        #endregion
	}
}
