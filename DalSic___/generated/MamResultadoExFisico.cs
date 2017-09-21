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
	/// Strongly-typed collection for the MamResultadoExFisico class.
	/// </summary>
    [Serializable]
	public partial class MamResultadoExFisicoCollection : ActiveList<MamResultadoExFisico, MamResultadoExFisicoCollection>
	{	   
		public MamResultadoExFisicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamResultadoExFisicoCollection</returns>
		public MamResultadoExFisicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamResultadoExFisico o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_ResultadoExFisico table.
	/// </summary>
	[Serializable]
	public partial class MamResultadoExFisico : ActiveRecord<MamResultadoExFisico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamResultadoExFisico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamResultadoExFisico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamResultadoExFisico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamResultadoExFisico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_ResultadoExFisico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdResultadoExFisico = new TableSchema.TableColumn(schema);
				colvarIdResultadoExFisico.ColumnName = "idResultadoExFisico";
				colvarIdResultadoExFisico.DataType = DbType.Int32;
				colvarIdResultadoExFisico.MaxLength = 0;
				colvarIdResultadoExFisico.AutoIncrement = true;
				colvarIdResultadoExFisico.IsNullable = false;
				colvarIdResultadoExFisico.IsPrimaryKey = true;
				colvarIdResultadoExFisico.IsForeignKey = false;
				colvarIdResultadoExFisico.IsReadOnly = false;
				colvarIdResultadoExFisico.DefaultSetting = @"";
				colvarIdResultadoExFisico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdResultadoExFisico);
				
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
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_ResultadoExFisico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdResultadoExFisico")]
		[Bindable(true)]
		public int IdResultadoExFisico 
		{
			get { return GetColumnValue<int>(Columns.IdResultadoExFisico); }
			set { SetColumnValue(Columns.IdResultadoExFisico, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.MamExamenFisicoCollection colMamExamenFisicoRecords;
		public DalSic.MamExamenFisicoCollection MamExamenFisicoRecords
		{
			get
			{
				if(colMamExamenFisicoRecords == null)
				{
					colMamExamenFisicoRecords = new DalSic.MamExamenFisicoCollection().Where(MamExamenFisico.Columns.IdResultadoExFisico, IdResultadoExFisico).Load();
					colMamExamenFisicoRecords.ListChanged += new ListChangedEventHandler(colMamExamenFisicoRecords_ListChanged);
				}
				return colMamExamenFisicoRecords;			
			}
			set 
			{ 
					colMamExamenFisicoRecords = value; 
					colMamExamenFisicoRecords.ListChanged += new ListChangedEventHandler(colMamExamenFisicoRecords_ListChanged);
			}
		}
		
		void colMamExamenFisicoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamExamenFisicoRecords[e.NewIndex].IdResultadoExFisico = IdResultadoExFisico;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,bool varActivo)
		{
			MamResultadoExFisico item = new MamResultadoExFisico();
			
			item.Nombre = varNombre;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdResultadoExFisico,string varNombre,bool varActivo)
		{
			MamResultadoExFisico item = new MamResultadoExFisico();
			
				item.IdResultadoExFisico = varIdResultadoExFisico;
			
				item.Nombre = varNombre;
			
				item.Activo = varActivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdResultadoExFisicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdResultadoExFisico = @"idResultadoExFisico";
			 public static string Nombre = @"nombre";
			 public static string Activo = @"activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamExamenFisicoRecords != null)
                {
                    foreach (DalSic.MamExamenFisico item in colMamExamenFisicoRecords)
                    {
                        if (item.IdResultadoExFisico != IdResultadoExFisico)
                        {
                            item.IdResultadoExFisico = IdResultadoExFisico;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamExamenFisicoRecords != null)
                {
                    colMamExamenFisicoRecords.SaveAll();
               }
		}
        #endregion
	}
}
