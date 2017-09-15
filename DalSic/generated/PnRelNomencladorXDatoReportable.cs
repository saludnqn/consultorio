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
	/// Strongly-typed collection for the PnRelNomencladorXDatoReportable class.
	/// </summary>
    [Serializable]
	public partial class PnRelNomencladorXDatoReportableCollection : ActiveList<PnRelNomencladorXDatoReportable, PnRelNomencladorXDatoReportableCollection>
	{	   
		public PnRelNomencladorXDatoReportableCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnRelNomencladorXDatoReportableCollection</returns>
		public PnRelNomencladorXDatoReportableCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnRelNomencladorXDatoReportable o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_Rel_NomencladorXDatoReportable table.
	/// </summary>
	[Serializable]
	public partial class PnRelNomencladorXDatoReportable : ActiveRecord<PnRelNomencladorXDatoReportable>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnRelNomencladorXDatoReportable()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnRelNomencladorXDatoReportable(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnRelNomencladorXDatoReportable(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnRelNomencladorXDatoReportable(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_Rel_NomencladorXDatoReportable", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNomencladorXDatoReportable = new TableSchema.TableColumn(schema);
				colvarIdNomencladorXDatoReportable.ColumnName = "idNomencladorXDatoReportable";
				colvarIdNomencladorXDatoReportable.DataType = DbType.Int32;
				colvarIdNomencladorXDatoReportable.MaxLength = 0;
				colvarIdNomencladorXDatoReportable.AutoIncrement = true;
				colvarIdNomencladorXDatoReportable.IsNullable = false;
				colvarIdNomencladorXDatoReportable.IsPrimaryKey = true;
				colvarIdNomencladorXDatoReportable.IsForeignKey = false;
				colvarIdNomencladorXDatoReportable.IsReadOnly = false;
				colvarIdNomencladorXDatoReportable.DefaultSetting = @"";
				colvarIdNomencladorXDatoReportable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomencladorXDatoReportable);
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "idNomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = false;
				colvarIdNomenclador.IsNullable = true;
				colvarIdNomenclador.IsPrimaryKey = false;
				colvarIdNomenclador.IsForeignKey = true;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				
					colvarIdNomenclador.ForeignKeyTableName = "PN_nomenclador";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarIdDatoReportable = new TableSchema.TableColumn(schema);
				colvarIdDatoReportable.ColumnName = "idDatoReportable";
				colvarIdDatoReportable.DataType = DbType.Int32;
				colvarIdDatoReportable.MaxLength = 0;
				colvarIdDatoReportable.AutoIncrement = false;
				colvarIdDatoReportable.IsNullable = true;
				colvarIdDatoReportable.IsPrimaryKey = false;
				colvarIdDatoReportable.IsForeignKey = true;
				colvarIdDatoReportable.IsReadOnly = false;
				colvarIdDatoReportable.DefaultSetting = @"";
				
					colvarIdDatoReportable.ForeignKeyTableName = "PN_datos_reportables";
				schema.Columns.Add(colvarIdDatoReportable);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_Rel_NomencladorXDatoReportable",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNomencladorXDatoReportable")]
		[Bindable(true)]
		public int IdNomencladorXDatoReportable 
		{
			get { return GetColumnValue<int>(Columns.IdNomencladorXDatoReportable); }
			set { SetColumnValue(Columns.IdNomencladorXDatoReportable, value); }
		}
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int? IdNomenclador 
		{
			get { return GetColumnValue<int?>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("IdDatoReportable")]
		[Bindable(true)]
		public int? IdDatoReportable 
		{
			get { return GetColumnValue<int?>(Columns.IdDatoReportable); }
			set { SetColumnValue(Columns.IdDatoReportable, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnNomenclador ActiveRecord object related to this PnRelNomencladorXDatoReportable
		/// 
		/// </summary>
		public DalSic.PnNomenclador PnNomenclador
		{
			get { return DalSic.PnNomenclador.FetchByID(this.IdNomenclador); }
			set { SetColumnValue("idNomenclador", value.IdNomenclador); }
		}
		
		
		/// <summary>
		/// Returns a PnDatosReportable ActiveRecord object related to this PnRelNomencladorXDatoReportable
		/// 
		/// </summary>
		public DalSic.PnDatosReportable PnDatosReportable
		{
			get { return DalSic.PnDatosReportable.FetchByID(this.IdDatoReportable); }
			set { SetColumnValue("idDatoReportable", value.IdDatoReportable); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdNomenclador,int? varIdDatoReportable)
		{
			PnRelNomencladorXDatoReportable item = new PnRelNomencladorXDatoReportable();
			
			item.IdNomenclador = varIdNomenclador;
			
			item.IdDatoReportable = varIdDatoReportable;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNomencladorXDatoReportable,int? varIdNomenclador,int? varIdDatoReportable)
		{
			PnRelNomencladorXDatoReportable item = new PnRelNomencladorXDatoReportable();
			
				item.IdNomencladorXDatoReportable = varIdNomencladorXDatoReportable;
			
				item.IdNomenclador = varIdNomenclador;
			
				item.IdDatoReportable = varIdDatoReportable;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNomencladorXDatoReportableColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDatoReportableColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNomencladorXDatoReportable = @"idNomencladorXDatoReportable";
			 public static string IdNomenclador = @"idNomenclador";
			 public static string IdDatoReportable = @"idDatoReportable";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
