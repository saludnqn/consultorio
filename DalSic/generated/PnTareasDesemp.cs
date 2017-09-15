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
	/// Strongly-typed collection for the PnTareasDesemp class.
	/// </summary>
    [Serializable]
	public partial class PnTareasDesempCollection : ActiveList<PnTareasDesemp, PnTareasDesempCollection>
	{	   
		public PnTareasDesempCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTareasDesempCollection</returns>
		public PnTareasDesempCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTareasDesemp o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_tareas_desemp table.
	/// </summary>
	[Serializable]
	public partial class PnTareasDesemp : ActiveRecord<PnTareasDesemp>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTareasDesemp()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTareasDesemp(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTareasDesemp(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTareasDesemp(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_tareas_desemp", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTarea = new TableSchema.TableColumn(schema);
				colvarIdTarea.ColumnName = "id_tarea";
				colvarIdTarea.DataType = DbType.Int32;
				colvarIdTarea.MaxLength = 0;
				colvarIdTarea.AutoIncrement = true;
				colvarIdTarea.IsNullable = false;
				colvarIdTarea.IsPrimaryKey = true;
				colvarIdTarea.IsForeignKey = false;
				colvarIdTarea.IsReadOnly = false;
				colvarIdTarea.DefaultSetting = @"";
				colvarIdTarea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTarea);
				
				TableSchema.TableColumn colvarNombreTarea = new TableSchema.TableColumn(schema);
				colvarNombreTarea.ColumnName = "nombre_tarea";
				colvarNombreTarea.DataType = DbType.AnsiString;
				colvarNombreTarea.MaxLength = -1;
				colvarNombreTarea.AutoIncrement = false;
				colvarNombreTarea.IsNullable = true;
				colvarNombreTarea.IsPrimaryKey = false;
				colvarNombreTarea.IsForeignKey = false;
				colvarNombreTarea.IsReadOnly = false;
				colvarNombreTarea.DefaultSetting = @"";
				colvarNombreTarea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreTarea);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_tareas_desemp",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTarea")]
		[Bindable(true)]
		public int IdTarea 
		{
			get { return GetColumnValue<int>(Columns.IdTarea); }
			set { SetColumnValue(Columns.IdTarea, value); }
		}
		  
		[XmlAttribute("NombreTarea")]
		[Bindable(true)]
		public string NombreTarea 
		{
			get { return GetColumnValue<string>(Columns.NombreTarea); }
			set { SetColumnValue(Columns.NombreTarea, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombreTarea)
		{
			PnTareasDesemp item = new PnTareasDesemp();
			
			item.NombreTarea = varNombreTarea;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTarea,string varNombreTarea)
		{
			PnTareasDesemp item = new PnTareasDesemp();
			
				item.IdTarea = varIdTarea;
			
				item.NombreTarea = varNombreTarea;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTareaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreTareaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTarea = @"id_tarea";
			 public static string NombreTarea = @"nombre_tarea";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
