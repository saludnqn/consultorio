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
	/// Strongly-typed collection for the PsmEFisico class.
	/// </summary>
    [Serializable]
	public partial class PsmEFisicoCollection : ActiveList<PsmEFisico, PsmEFisicoCollection>
	{	   
		public PsmEFisicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PsmEFisicoCollection</returns>
		public PsmEFisicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PsmEFisico o = this[i];
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
	/// This is an ActiveRecord class which wraps the PSM_EFisico table.
	/// </summary>
	[Serializable]
	public partial class PsmEFisico : ActiveRecord<PsmEFisico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PsmEFisico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PsmEFisico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PsmEFisico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PsmEFisico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PSM_EFisico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPSMEFisico = new TableSchema.TableColumn(schema);
				colvarIdPSMEFisico.ColumnName = "idPSMEFisico";
				colvarIdPSMEFisico.DataType = DbType.Decimal;
				colvarIdPSMEFisico.MaxLength = 0;
				colvarIdPSMEFisico.AutoIncrement = false;
				colvarIdPSMEFisico.IsNullable = false;
				colvarIdPSMEFisico.IsPrimaryKey = true;
				colvarIdPSMEFisico.IsForeignKey = false;
				colvarIdPSMEFisico.IsReadOnly = false;
				colvarIdPSMEFisico.DefaultSetting = @"";
				colvarIdPSMEFisico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPSMEFisico);
				
				TableSchema.TableColumn colvarIdPSMEFisicoItems = new TableSchema.TableColumn(schema);
				colvarIdPSMEFisicoItems.ColumnName = "idPSMEFisicoItems";
				colvarIdPSMEFisicoItems.DataType = DbType.Decimal;
				colvarIdPSMEFisicoItems.MaxLength = 0;
				colvarIdPSMEFisicoItems.AutoIncrement = false;
				colvarIdPSMEFisicoItems.IsNullable = false;
				colvarIdPSMEFisicoItems.IsPrimaryKey = true;
				colvarIdPSMEFisicoItems.IsForeignKey = false;
				colvarIdPSMEFisicoItems.IsReadOnly = false;
				colvarIdPSMEFisicoItems.DefaultSetting = @"";
				colvarIdPSMEFisicoItems.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPSMEFisicoItems);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarExamenFisico = new TableSchema.TableColumn(schema);
				colvarExamenFisico.ColumnName = "ExamenFisico";
				colvarExamenFisico.DataType = DbType.String;
				colvarExamenFisico.MaxLength = 100;
				colvarExamenFisico.AutoIncrement = false;
				colvarExamenFisico.IsNullable = true;
				colvarExamenFisico.IsPrimaryKey = false;
				colvarExamenFisico.IsForeignKey = false;
				colvarExamenFisico.IsReadOnly = false;
				colvarExamenFisico.DefaultSetting = @"";
				colvarExamenFisico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenFisico);
				
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
				DataService.Providers["sicProvider"].AddSchema("PSM_EFisico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPSMEFisico")]
		[Bindable(true)]
		public decimal IdPSMEFisico 
		{
			get { return GetColumnValue<decimal>(Columns.IdPSMEFisico); }
			set { SetColumnValue(Columns.IdPSMEFisico, value); }
		}
		  
		[XmlAttribute("IdPSMEFisicoItems")]
		[Bindable(true)]
		public decimal IdPSMEFisicoItems 
		{
			get { return GetColumnValue<decimal>(Columns.IdPSMEFisicoItems); }
			set { SetColumnValue(Columns.IdPSMEFisicoItems, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("ExamenFisico")]
		[Bindable(true)]
		public string ExamenFisico 
		{
			get { return GetColumnValue<string>(Columns.ExamenFisico); }
			set { SetColumnValue(Columns.ExamenFisico, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(decimal varIdPSMEFisico,decimal varIdPSMEFisicoItems,string varNombre,string varExamenFisico,bool varActivo)
		{
			PsmEFisico item = new PsmEFisico();
			
			item.IdPSMEFisico = varIdPSMEFisico;
			
			item.IdPSMEFisicoItems = varIdPSMEFisicoItems;
			
			item.Nombre = varNombre;
			
			item.ExamenFisico = varExamenFisico;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(decimal varIdPSMEFisico,decimal varIdPSMEFisicoItems,string varNombre,string varExamenFisico,bool varActivo)
		{
			PsmEFisico item = new PsmEFisico();
			
				item.IdPSMEFisico = varIdPSMEFisico;
			
				item.IdPSMEFisicoItems = varIdPSMEFisicoItems;
			
				item.Nombre = varNombre;
			
				item.ExamenFisico = varExamenFisico;
			
				item.Activo = varActivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPSMEFisicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPSMEFisicoItemsColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenFisicoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPSMEFisico = @"idPSMEFisico";
			 public static string IdPSMEFisicoItems = @"idPSMEFisicoItems";
			 public static string Nombre = @"Nombre";
			 public static string ExamenFisico = @"ExamenFisico";
			 public static string Activo = @"activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
