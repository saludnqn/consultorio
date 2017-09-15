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
	/// Strongly-typed collection for the ConTurnoEstado class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoEstadoCollection : ActiveList<ConTurnoEstado, ConTurnoEstadoCollection>
	{	   
		public ConTurnoEstadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoEstadoCollection</returns>
		public ConTurnoEstadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoEstado o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoEstado table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoEstado : ActiveRecord<ConTurnoEstado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoEstado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoEstado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoEstado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoEstado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoEstado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTurnoEstado = new TableSchema.TableColumn(schema);
				colvarIdTurnoEstado.ColumnName = "idTurnoEstado";
				colvarIdTurnoEstado.DataType = DbType.Int32;
				colvarIdTurnoEstado.MaxLength = 0;
				colvarIdTurnoEstado.AutoIncrement = true;
				colvarIdTurnoEstado.IsNullable = false;
				colvarIdTurnoEstado.IsPrimaryKey = true;
				colvarIdTurnoEstado.IsForeignKey = false;
				colvarIdTurnoEstado.IsReadOnly = false;
				colvarIdTurnoEstado.DefaultSetting = @"";
				colvarIdTurnoEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoEstado);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarAccion = new TableSchema.TableColumn(schema);
				colvarAccion.ColumnName = "Accion";
				colvarAccion.DataType = DbType.String;
				colvarAccion.MaxLength = 100;
				colvarAccion.AutoIncrement = false;
				colvarAccion.IsNullable = false;
				colvarAccion.IsPrimaryKey = false;
				colvarAccion.IsForeignKey = false;
				colvarAccion.IsReadOnly = false;
				colvarAccion.DefaultSetting = @"";
				colvarAccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccion);
				
				TableSchema.TableColumn colvarImagenComando = new TableSchema.TableColumn(schema);
				colvarImagenComando.ColumnName = "imagenComando";
				colvarImagenComando.DataType = DbType.String;
				colvarImagenComando.MaxLength = 150;
				colvarImagenComando.AutoIncrement = false;
				colvarImagenComando.IsNullable = false;
				colvarImagenComando.IsPrimaryKey = false;
				colvarImagenComando.IsForeignKey = false;
				colvarImagenComando.IsReadOnly = false;
				
						colvarImagenComando.DefaultSetting = @"(' ')";
				colvarImagenComando.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImagenComando);
				
				TableSchema.TableColumn colvarNombreComando = new TableSchema.TableColumn(schema);
				colvarNombreComando.ColumnName = "nombreComando";
				colvarNombreComando.DataType = DbType.String;
				colvarNombreComando.MaxLength = 150;
				colvarNombreComando.AutoIncrement = false;
				colvarNombreComando.IsNullable = false;
				colvarNombreComando.IsPrimaryKey = false;
				colvarNombreComando.IsForeignKey = false;
				colvarNombreComando.IsReadOnly = false;
				
						colvarNombreComando.DefaultSetting = @"(' ')";
				colvarNombreComando.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreComando);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoEstado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTurnoEstado")]
		[Bindable(true)]
		public int IdTurnoEstado 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoEstado); }
			set { SetColumnValue(Columns.IdTurnoEstado, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Accion")]
		[Bindable(true)]
		public string Accion 
		{
			get { return GetColumnValue<string>(Columns.Accion); }
			set { SetColumnValue(Columns.Accion, value); }
		}
		  
		[XmlAttribute("ImagenComando")]
		[Bindable(true)]
		public string ImagenComando 
		{
			get { return GetColumnValue<string>(Columns.ImagenComando); }
			set { SetColumnValue(Columns.ImagenComando, value); }
		}
		  
		[XmlAttribute("NombreComando")]
		[Bindable(true)]
		public string NombreComando 
		{
			get { return GetColumnValue<string>(Columns.NombreComando); }
			set { SetColumnValue(Columns.NombreComando, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.ConTurnoAuditoriumCollection colConTurnoAuditoria;
		public DalSic.ConTurnoAuditoriumCollection ConTurnoAuditoria
		{
			get
			{
				if(colConTurnoAuditoria == null)
				{
					colConTurnoAuditoria = new DalSic.ConTurnoAuditoriumCollection().Where(ConTurnoAuditorium.Columns.IdTurnoEstado, IdTurnoEstado).Load();
					colConTurnoAuditoria.ListChanged += new ListChangedEventHandler(colConTurnoAuditoria_ListChanged);
				}
				return colConTurnoAuditoria;			
			}
			set 
			{ 
					colConTurnoAuditoria = value; 
					colConTurnoAuditoria.ListChanged += new ListChangedEventHandler(colConTurnoAuditoria_ListChanged);
			}
		}
		
		void colConTurnoAuditoria_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoAuditoria[e.NewIndex].IdTurnoEstado = IdTurnoEstado;
		    }
		}
				
		private DalSic.ConTurnoCollection colConTurnoRecords;
		public DalSic.ConTurnoCollection ConTurnoRecords
		{
			get
			{
				if(colConTurnoRecords == null)
				{
					colConTurnoRecords = new DalSic.ConTurnoCollection().Where(ConTurno.Columns.IdTurnoEstado, IdTurnoEstado).Load();
					colConTurnoRecords.ListChanged += new ListChangedEventHandler(colConTurnoRecords_ListChanged);
				}
				return colConTurnoRecords;			
			}
			set 
			{ 
					colConTurnoRecords = value; 
					colConTurnoRecords.ListChanged += new ListChangedEventHandler(colConTurnoRecords_ListChanged);
			}
		}
		
		void colConTurnoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoRecords[e.NewIndex].IdTurnoEstado = IdTurnoEstado;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varAccion,string varImagenComando,string varNombreComando)
		{
			ConTurnoEstado item = new ConTurnoEstado();
			
			item.Nombre = varNombre;
			
			item.Accion = varAccion;
			
			item.ImagenComando = varImagenComando;
			
			item.NombreComando = varNombreComando;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTurnoEstado,string varNombre,string varAccion,string varImagenComando,string varNombreComando)
		{
			ConTurnoEstado item = new ConTurnoEstado();
			
				item.IdTurnoEstado = varIdTurnoEstado;
			
				item.Nombre = varNombre;
			
				item.Accion = varAccion;
			
				item.ImagenComando = varImagenComando;
			
				item.NombreComando = varNombreComando;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTurnoEstadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AccionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ImagenComandoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreComandoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTurnoEstado = @"idTurnoEstado";
			 public static string Nombre = @"nombre";
			 public static string Accion = @"Accion";
			 public static string ImagenComando = @"imagenComando";
			 public static string NombreComando = @"nombreComando";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConTurnoAuditoria != null)
                {
                    foreach (DalSic.ConTurnoAuditorium item in colConTurnoAuditoria)
                    {
                        if (item.IdTurnoEstado != IdTurnoEstado)
                        {
                            item.IdTurnoEstado = IdTurnoEstado;
                        }
                    }
               }
		
                if (colConTurnoRecords != null)
                {
                    foreach (DalSic.ConTurno item in colConTurnoRecords)
                    {
                        if (item.IdTurnoEstado != IdTurnoEstado)
                        {
                            item.IdTurnoEstado = IdTurnoEstado;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConTurnoAuditoria != null)
                {
                    colConTurnoAuditoria.SaveAll();
               }
		
                if (colConTurnoRecords != null)
                {
                    colConTurnoRecords.SaveAll();
               }
		}
        #endregion
	}
}
