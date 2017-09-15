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
	/// Strongly-typed collection for the FacContratoObraSocial class.
	/// </summary>
    [Serializable]
	public partial class FacContratoObraSocialCollection : ActiveList<FacContratoObraSocial, FacContratoObraSocialCollection>
	{	   
		public FacContratoObraSocialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>FacContratoObraSocialCollection</returns>
		public FacContratoObraSocialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                FacContratoObraSocial o = this[i];
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
	/// This is an ActiveRecord class which wraps the FAC_ContratoObraSocial table.
	/// </summary>
	[Serializable]
	public partial class FacContratoObraSocial : ActiveRecord<FacContratoObraSocial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public FacContratoObraSocial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public FacContratoObraSocial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public FacContratoObraSocial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public FacContratoObraSocial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("FAC_ContratoObraSocial", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdContratoObraSocial = new TableSchema.TableColumn(schema);
				colvarIdContratoObraSocial.ColumnName = "idContratoObraSocial";
				colvarIdContratoObraSocial.DataType = DbType.Int32;
				colvarIdContratoObraSocial.MaxLength = 0;
				colvarIdContratoObraSocial.AutoIncrement = true;
				colvarIdContratoObraSocial.IsNullable = false;
				colvarIdContratoObraSocial.IsPrimaryKey = true;
				colvarIdContratoObraSocial.IsForeignKey = false;
				colvarIdContratoObraSocial.IsReadOnly = false;
				colvarIdContratoObraSocial.DefaultSetting = @"";
				colvarIdContratoObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdContratoObraSocial);
				
				TableSchema.TableColumn colvarIdTipoNomenclador = new TableSchema.TableColumn(schema);
				colvarIdTipoNomenclador.ColumnName = "idTipoNomenclador";
				colvarIdTipoNomenclador.DataType = DbType.Int32;
				colvarIdTipoNomenclador.MaxLength = 0;
				colvarIdTipoNomenclador.AutoIncrement = false;
				colvarIdTipoNomenclador.IsNullable = false;
				colvarIdTipoNomenclador.IsPrimaryKey = false;
				colvarIdTipoNomenclador.IsForeignKey = true;
				colvarIdTipoNomenclador.IsReadOnly = false;
				colvarIdTipoNomenclador.DefaultSetting = @"";
				
					colvarIdTipoNomenclador.ForeignKeyTableName = "FAC_TipoNomenclador";
				schema.Columns.Add(colvarIdTipoNomenclador);
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = false;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = true;
				colvarIdObraSocial.IsReadOnly = false;
				colvarIdObraSocial.DefaultSetting = @"";
				
					colvarIdObraSocial.ForeignKeyTableName = "Sys_ObraSocial";
				schema.Columns.Add(colvarIdObraSocial);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("FAC_ContratoObraSocial",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdContratoObraSocial")]
		[Bindable(true)]
		public int IdContratoObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdContratoObraSocial); }
			set { SetColumnValue(Columns.IdContratoObraSocial, value); }
		}
		  
		[XmlAttribute("IdTipoNomenclador")]
		[Bindable(true)]
		public int IdTipoNomenclador 
		{
			get { return GetColumnValue<int>(Columns.IdTipoNomenclador); }
			set { SetColumnValue(Columns.IdTipoNomenclador, value); }
		}
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int IdObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysObraSocial ActiveRecord object related to this FacContratoObraSocial
		/// 
		/// </summary>
		public DalSic.SysObraSocial SysObraSocial
		{
			get { return DalSic.SysObraSocial.FetchByID(this.IdObraSocial); }
			set { SetColumnValue("idObraSocial", value.IdObraSocial); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdTipoNomenclador,int varIdObraSocial)
		{
			FacContratoObraSocial item = new FacContratoObraSocial();
			
			item.IdTipoNomenclador = varIdTipoNomenclador;
			
			item.IdObraSocial = varIdObraSocial;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdContratoObraSocial,int varIdTipoNomenclador,int varIdObraSocial)
		{
			FacContratoObraSocial item = new FacContratoObraSocial();
			
				item.IdContratoObraSocial = varIdContratoObraSocial;
			
				item.IdTipoNomenclador = varIdTipoNomenclador;
			
				item.IdObraSocial = varIdObraSocial;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdContratoObraSocialColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoNomencladorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdContratoObraSocial = @"idContratoObraSocial";
			 public static string IdTipoNomenclador = @"idTipoNomenclador";
			 public static string IdObraSocial = @"idObraSocial";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
