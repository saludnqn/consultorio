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
	/// Strongly-typed collection for the GuardiaRegistrosEstado class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistrosEstadoCollection : ActiveList<GuardiaRegistrosEstado, GuardiaRegistrosEstadoCollection>
	{	   
		public GuardiaRegistrosEstadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistrosEstadoCollection</returns>
		public GuardiaRegistrosEstadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistrosEstado o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros_Estados table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistrosEstado : ActiveRecord<GuardiaRegistrosEstado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistrosEstado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistrosEstado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistrosEstado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistrosEstado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros_Estados", TableType.Table, DataService.GetInstance("sicProvider"));
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
				colvarId.IsForeignKey = true;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				
					colvarId.ForeignKeyTableName = "Guardia_Registros_Estados";
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros_Estados",schema);
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
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.GuardiaRegistrosEstadoCollection colChildGuardiaRegistrosEstados;
		public DalSic.GuardiaRegistrosEstadoCollection ChildGuardiaRegistrosEstados
		{
			get
			{
				if(colChildGuardiaRegistrosEstados == null)
				{
					colChildGuardiaRegistrosEstados = new DalSic.GuardiaRegistrosEstadoCollection().Where(GuardiaRegistrosEstado.Columns.Id, Id).Load();
					colChildGuardiaRegistrosEstados.ListChanged += new ListChangedEventHandler(colChildGuardiaRegistrosEstados_ListChanged);
				}
				return colChildGuardiaRegistrosEstados;			
			}
			set 
			{ 
					colChildGuardiaRegistrosEstados = value; 
					colChildGuardiaRegistrosEstados.ListChanged += new ListChangedEventHandler(colChildGuardiaRegistrosEstados_ListChanged);
			}
		}
		
		void colChildGuardiaRegistrosEstados_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colChildGuardiaRegistrosEstados[e.NewIndex].Id = Id;
		    }
		}
				
		private DalSic.GuardiaRegistroCollection colGuardiaRegistros;
		public DalSic.GuardiaRegistroCollection GuardiaRegistros
		{
			get
			{
				if(colGuardiaRegistros == null)
				{
					colGuardiaRegistros = new DalSic.GuardiaRegistroCollection().Where(GuardiaRegistro.Columns.EstadoActual, Id).Load();
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
		        colGuardiaRegistros[e.NewIndex].EstadoActual = Id;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a GuardiaRegistrosEstado ActiveRecord object related to this GuardiaRegistrosEstado
		/// 
		/// </summary>
		public DalSic.GuardiaRegistrosEstado ParentGuardiaRegistrosEstado
		{
			get { return DalSic.GuardiaRegistrosEstado.FetchByID(this.Id); }
			set { SetColumnValue("id", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			GuardiaRegistrosEstado item = new GuardiaRegistrosEstado();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varNombre)
		{
			GuardiaRegistrosEstado item = new GuardiaRegistrosEstado();
			
				item.Id = varId;
			
				item.Nombre = varNombre;
			
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
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colChildGuardiaRegistrosEstados != null)
                {
                    foreach (DalSic.GuardiaRegistrosEstado item in colChildGuardiaRegistrosEstados)
                    {
                        if (item.Id != Id)
                        {
                            item.Id = Id;
                        }
                    }
               }
		
                if (colGuardiaRegistros != null)
                {
                    foreach (DalSic.GuardiaRegistro item in colGuardiaRegistros)
                    {
                        if (item.EstadoActual != Id)
                        {
                            item.EstadoActual = Id;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colChildGuardiaRegistrosEstados != null)
                {
                    colChildGuardiaRegistrosEstados.SaveAll();
               }
		
                if (colGuardiaRegistros != null)
                {
                    colGuardiaRegistros.SaveAll();
               }
		}
        #endregion
	}
}
