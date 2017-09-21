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
	/// Strongly-typed collection for the ConMotivosDeBloqueo class.
	/// </summary>
    [Serializable]
	public partial class ConMotivosDeBloqueoCollection : ActiveList<ConMotivosDeBloqueo, ConMotivosDeBloqueoCollection>
	{	   
		public ConMotivosDeBloqueoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConMotivosDeBloqueoCollection</returns>
		public ConMotivosDeBloqueoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConMotivosDeBloqueo o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_MotivosDeBloqueo table.
	/// </summary>
	[Serializable]
	public partial class ConMotivosDeBloqueo : ActiveRecord<ConMotivosDeBloqueo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConMotivosDeBloqueo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConMotivosDeBloqueo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConMotivosDeBloqueo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConMotivosDeBloqueo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_MotivosDeBloqueo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMotivoBloqueo = new TableSchema.TableColumn(schema);
				colvarIdMotivoBloqueo.ColumnName = "idMotivoBloqueo";
				colvarIdMotivoBloqueo.DataType = DbType.Int32;
				colvarIdMotivoBloqueo.MaxLength = 0;
				colvarIdMotivoBloqueo.AutoIncrement = true;
				colvarIdMotivoBloqueo.IsNullable = false;
				colvarIdMotivoBloqueo.IsPrimaryKey = true;
				colvarIdMotivoBloqueo.IsForeignKey = false;
				colvarIdMotivoBloqueo.IsReadOnly = false;
				colvarIdMotivoBloqueo.DefaultSetting = @"";
				colvarIdMotivoBloqueo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoBloqueo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 40;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_MotivosDeBloqueo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMotivoBloqueo")]
		[Bindable(true)]
		public int IdMotivoBloqueo 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoBloqueo); }
			set { SetColumnValue(Columns.IdMotivoBloqueo, value); }
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
        
				
		private DalSic.ConTurnoBloqueoCollection colConTurnoBloqueoRecords;
		public DalSic.ConTurnoBloqueoCollection ConTurnoBloqueoRecords
		{
			get
			{
				if(colConTurnoBloqueoRecords == null)
				{
					colConTurnoBloqueoRecords = new DalSic.ConTurnoBloqueoCollection().Where(ConTurnoBloqueo.Columns.IdMotivoBloqueo, IdMotivoBloqueo).Load();
					colConTurnoBloqueoRecords.ListChanged += new ListChangedEventHandler(colConTurnoBloqueoRecords_ListChanged);
				}
				return colConTurnoBloqueoRecords;			
			}
			set 
			{ 
					colConTurnoBloqueoRecords = value; 
					colConTurnoBloqueoRecords.ListChanged += new ListChangedEventHandler(colConTurnoBloqueoRecords_ListChanged);
			}
		}
		
		void colConTurnoBloqueoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoBloqueoRecords[e.NewIndex].IdMotivoBloqueo = IdMotivoBloqueo;
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
			ConMotivosDeBloqueo item = new ConMotivosDeBloqueo();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMotivoBloqueo,string varDescripcion)
		{
			ConMotivosDeBloqueo item = new ConMotivosDeBloqueo();
			
				item.IdMotivoBloqueo = varIdMotivoBloqueo;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMotivoBloqueoColumn
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
			 public static string IdMotivoBloqueo = @"idMotivoBloqueo";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConTurnoBloqueoRecords != null)
                {
                    foreach (DalSic.ConTurnoBloqueo item in colConTurnoBloqueoRecords)
                    {
                        if (item.IdMotivoBloqueo != IdMotivoBloqueo)
                        {
                            item.IdMotivoBloqueo = IdMotivoBloqueo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConTurnoBloqueoRecords != null)
                {
                    colConTurnoBloqueoRecords.SaveAll();
               }
		}
        #endregion
	}
}
