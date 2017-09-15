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
	/// Strongly-typed collection for the PnTipoEvento class.
	/// </summary>
    [Serializable]
	public partial class PnTipoEventoCollection : ActiveList<PnTipoEvento, PnTipoEventoCollection>
	{	   
		public PnTipoEventoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTipoEventoCollection</returns>
		public PnTipoEventoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTipoEvento o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_tipo_evento table.
	/// </summary>
	[Serializable]
	public partial class PnTipoEvento : ActiveRecord<PnTipoEvento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTipoEvento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTipoEvento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTipoEvento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTipoEvento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_tipo_evento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoEvento = new TableSchema.TableColumn(schema);
				colvarIdTipoEvento.ColumnName = "id_tipo_evento";
				colvarIdTipoEvento.DataType = DbType.Int32;
				colvarIdTipoEvento.MaxLength = 0;
				colvarIdTipoEvento.AutoIncrement = true;
				colvarIdTipoEvento.IsNullable = false;
				colvarIdTipoEvento.IsPrimaryKey = true;
				colvarIdTipoEvento.IsForeignKey = false;
				colvarIdTipoEvento.IsReadOnly = false;
				colvarIdTipoEvento.DefaultSetting = @"";
				colvarIdTipoEvento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEvento);
				
				TableSchema.TableColumn colvarTipoEvento = new TableSchema.TableColumn(schema);
				colvarTipoEvento.ColumnName = "tipo_evento";
				colvarTipoEvento.DataType = DbType.AnsiString;
				colvarTipoEvento.MaxLength = -1;
				colvarTipoEvento.AutoIncrement = false;
				colvarTipoEvento.IsNullable = true;
				colvarTipoEvento.IsPrimaryKey = false;
				colvarTipoEvento.IsForeignKey = false;
				colvarTipoEvento.IsReadOnly = false;
				colvarTipoEvento.DefaultSetting = @"";
				colvarTipoEvento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoEvento);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_tipo_evento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoEvento")]
		[Bindable(true)]
		public int IdTipoEvento 
		{
			get { return GetColumnValue<int>(Columns.IdTipoEvento); }
			set { SetColumnValue(Columns.IdTipoEvento, value); }
		}
		  
		[XmlAttribute("TipoEvento")]
		[Bindable(true)]
		public string TipoEvento 
		{
			get { return GetColumnValue<string>(Columns.TipoEvento); }
			set { SetColumnValue(Columns.TipoEvento, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTipoEvento)
		{
			PnTipoEvento item = new PnTipoEvento();
			
			item.TipoEvento = varTipoEvento;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoEvento,string varTipoEvento)
		{
			PnTipoEvento item = new PnTipoEvento();
			
				item.IdTipoEvento = varIdTipoEvento;
			
				item.TipoEvento = varTipoEvento;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoEventoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoEventoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoEvento = @"id_tipo_evento";
			 public static string TipoEvento = @"tipo_evento";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
