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
	/// Strongly-typed collection for the ConAgendaEstado class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaEstadoCollection : ActiveList<ConAgendaEstado, ConAgendaEstadoCollection>
	{	   
		public ConAgendaEstadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaEstadoCollection</returns>
		public ConAgendaEstadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaEstado o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaEstado table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaEstado : ActiveRecord<ConAgendaEstado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaEstado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaEstado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaEstado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaEstado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaEstado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgendaEstado = new TableSchema.TableColumn(schema);
				colvarIdAgendaEstado.ColumnName = "idAgendaEstado";
				colvarIdAgendaEstado.DataType = DbType.Int32;
				colvarIdAgendaEstado.MaxLength = 0;
				colvarIdAgendaEstado.AutoIncrement = true;
				colvarIdAgendaEstado.IsNullable = false;
				colvarIdAgendaEstado.IsPrimaryKey = true;
				colvarIdAgendaEstado.IsForeignKey = false;
				colvarIdAgendaEstado.IsReadOnly = false;
				colvarIdAgendaEstado.DefaultSetting = @"";
				colvarIdAgendaEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgendaEstado);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaEstado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgendaEstado")]
		[Bindable(true)]
		public int IdAgendaEstado 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaEstado); }
			set { SetColumnValue(Columns.IdAgendaEstado, value); }
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
        
				
		private DalSic.ConAgendaAuditoriumCollection colConAgendaAuditoria;
		public DalSic.ConAgendaAuditoriumCollection ConAgendaAuditoria
		{
			get
			{
				if(colConAgendaAuditoria == null)
				{
					colConAgendaAuditoria = new DalSic.ConAgendaAuditoriumCollection().Where(ConAgendaAuditorium.Columns.IdAgendaEstado, IdAgendaEstado).Load();
					colConAgendaAuditoria.ListChanged += new ListChangedEventHandler(colConAgendaAuditoria_ListChanged);
				}
				return colConAgendaAuditoria;			
			}
			set 
			{ 
					colConAgendaAuditoria = value; 
					colConAgendaAuditoria.ListChanged += new ListChangedEventHandler(colConAgendaAuditoria_ListChanged);
			}
		}
		
		void colConAgendaAuditoria_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaAuditoria[e.NewIndex].IdAgendaEstado = IdAgendaEstado;
		    }
		}
				
		private DalSic.ConAgendaAuditoriumCollection colConAgendaAuditoriaFromConAgendaEstado;
		public DalSic.ConAgendaAuditoriumCollection ConAgendaAuditoriaFromConAgendaEstado
		{
			get
			{
				if(colConAgendaAuditoriaFromConAgendaEstado == null)
				{
					colConAgendaAuditoriaFromConAgendaEstado = new DalSic.ConAgendaAuditoriumCollection().Where(ConAgendaAuditorium.Columns.IdAgendaEstado, IdAgendaEstado).Load();
					colConAgendaAuditoriaFromConAgendaEstado.ListChanged += new ListChangedEventHandler(colConAgendaAuditoriaFromConAgendaEstado_ListChanged);
				}
				return colConAgendaAuditoriaFromConAgendaEstado;			
			}
			set 
			{ 
					colConAgendaAuditoriaFromConAgendaEstado = value; 
					colConAgendaAuditoriaFromConAgendaEstado.ListChanged += new ListChangedEventHandler(colConAgendaAuditoriaFromConAgendaEstado_ListChanged);
			}
		}
		
		void colConAgendaAuditoriaFromConAgendaEstado_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaAuditoriaFromConAgendaEstado[e.NewIndex].IdAgendaEstado = IdAgendaEstado;
		    }
		}
				
		private DalSic.ConAgendaGrupalCollection colConAgendaGrupalRecords;
		public DalSic.ConAgendaGrupalCollection ConAgendaGrupalRecords
		{
			get
			{
				if(colConAgendaGrupalRecords == null)
				{
					colConAgendaGrupalRecords = new DalSic.ConAgendaGrupalCollection().Where(ConAgendaGrupal.Columns.IdAgendaEstado, IdAgendaEstado).Load();
					colConAgendaGrupalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalRecords_ListChanged);
				}
				return colConAgendaGrupalRecords;			
			}
			set 
			{ 
					colConAgendaGrupalRecords = value; 
					colConAgendaGrupalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalRecords[e.NewIndex].IdAgendaEstado = IdAgendaEstado;
		    }
		}
				
		private DalSic.ConAgendaCollection colConAgendaRecords;
		public DalSic.ConAgendaCollection ConAgendaRecords
		{
			get
			{
				if(colConAgendaRecords == null)
				{
					colConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdAgendaEstado, IdAgendaEstado).Load();
					colConAgendaRecords.ListChanged += new ListChangedEventHandler(colConAgendaRecords_ListChanged);
				}
				return colConAgendaRecords;			
			}
			set 
			{ 
					colConAgendaRecords = value; 
					colConAgendaRecords.ListChanged += new ListChangedEventHandler(colConAgendaRecords_ListChanged);
			}
		}
		
		void colConAgendaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaRecords[e.NewIndex].IdAgendaEstado = IdAgendaEstado;
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
			ConAgendaEstado item = new ConAgendaEstado();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgendaEstado,string varNombre)
		{
			ConAgendaEstado item = new ConAgendaEstado();
			
				item.IdAgendaEstado = varIdAgendaEstado;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgendaEstadoColumn
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
			 public static string IdAgendaEstado = @"idAgendaEstado";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConAgendaAuditoria != null)
                {
                    foreach (DalSic.ConAgendaAuditorium item in colConAgendaAuditoria)
                    {
                        if (item.IdAgendaEstado != IdAgendaEstado)
                        {
                            item.IdAgendaEstado = IdAgendaEstado;
                        }
                    }
               }
		
                if (colConAgendaAuditoriaFromConAgendaEstado != null)
                {
                    foreach (DalSic.ConAgendaAuditorium item in colConAgendaAuditoriaFromConAgendaEstado)
                    {
                        if (item.IdAgendaEstado != IdAgendaEstado)
                        {
                            item.IdAgendaEstado = IdAgendaEstado;
                        }
                    }
               }
		
                if (colConAgendaGrupalRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupal item in colConAgendaGrupalRecords)
                    {
                        if (item.IdAgendaEstado != IdAgendaEstado)
                        {
                            item.IdAgendaEstado = IdAgendaEstado;
                        }
                    }
               }
		
                if (colConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colConAgendaRecords)
                    {
                        if (item.IdAgendaEstado != IdAgendaEstado)
                        {
                            item.IdAgendaEstado = IdAgendaEstado;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConAgendaAuditoria != null)
                {
                    colConAgendaAuditoria.SaveAll();
               }
		
                if (colConAgendaAuditoriaFromConAgendaEstado != null)
                {
                    colConAgendaAuditoriaFromConAgendaEstado.SaveAll();
               }
		
                if (colConAgendaGrupalRecords != null)
                {
                    colConAgendaGrupalRecords.SaveAll();
               }
		
                if (colConAgendaRecords != null)
                {
                    colConAgendaRecords.SaveAll();
               }
		}
        #endregion
	}
}
