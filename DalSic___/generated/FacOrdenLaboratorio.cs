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
	/// Strongly-typed collection for the FacOrdenLaboratorio class.
	/// </summary>
    [Serializable]
	public partial class FacOrdenLaboratorioCollection : ActiveList<FacOrdenLaboratorio, FacOrdenLaboratorioCollection>
	{	   
		public FacOrdenLaboratorioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>FacOrdenLaboratorioCollection</returns>
		public FacOrdenLaboratorioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                FacOrdenLaboratorio o = this[i];
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
	/// This is an ActiveRecord class which wraps the FAC_OrdenLaboratorio table.
	/// </summary>
	[Serializable]
	public partial class FacOrdenLaboratorio : ActiveRecord<FacOrdenLaboratorio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public FacOrdenLaboratorio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public FacOrdenLaboratorio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public FacOrdenLaboratorio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public FacOrdenLaboratorio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("FAC_OrdenLaboratorio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdOrdenLaboratorio = new TableSchema.TableColumn(schema);
				colvarIdOrdenLaboratorio.ColumnName = "idOrdenLaboratorio";
				colvarIdOrdenLaboratorio.DataType = DbType.Int32;
				colvarIdOrdenLaboratorio.MaxLength = 0;
				colvarIdOrdenLaboratorio.AutoIncrement = true;
				colvarIdOrdenLaboratorio.IsNullable = false;
				colvarIdOrdenLaboratorio.IsPrimaryKey = true;
				colvarIdOrdenLaboratorio.IsForeignKey = false;
				colvarIdOrdenLaboratorio.IsReadOnly = false;
				colvarIdOrdenLaboratorio.DefaultSetting = @"";
				colvarIdOrdenLaboratorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdOrdenLaboratorio);
				
				TableSchema.TableColumn colvarIdOrden = new TableSchema.TableColumn(schema);
				colvarIdOrden.ColumnName = "idOrden";
				colvarIdOrden.DataType = DbType.Int32;
				colvarIdOrden.MaxLength = 0;
				colvarIdOrden.AutoIncrement = false;
				colvarIdOrden.IsNullable = false;
				colvarIdOrden.IsPrimaryKey = false;
				colvarIdOrden.IsForeignKey = true;
				colvarIdOrden.IsReadOnly = false;
				colvarIdOrden.DefaultSetting = @"";
				
					colvarIdOrden.ForeignKeyTableName = "FAC_Orden";
				schema.Columns.Add(colvarIdOrden);
				
				TableSchema.TableColumn colvarIdProtocolo = new TableSchema.TableColumn(schema);
				colvarIdProtocolo.ColumnName = "idProtocolo";
				colvarIdProtocolo.DataType = DbType.Int32;
				colvarIdProtocolo.MaxLength = 0;
				colvarIdProtocolo.AutoIncrement = false;
				colvarIdProtocolo.IsNullable = false;
				colvarIdProtocolo.IsPrimaryKey = false;
				colvarIdProtocolo.IsForeignKey = true;
				colvarIdProtocolo.IsReadOnly = false;
				colvarIdProtocolo.DefaultSetting = @"";
				
					colvarIdProtocolo.ForeignKeyTableName = "LAB_ResultadoEncabezado";
				schema.Columns.Add(colvarIdProtocolo);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "LAB_ResultadoEncabezado";
				schema.Columns.Add(colvarIdEfector);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("FAC_OrdenLaboratorio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdOrdenLaboratorio")]
		[Bindable(true)]
		public int IdOrdenLaboratorio 
		{
			get { return GetColumnValue<int>(Columns.IdOrdenLaboratorio); }
			set { SetColumnValue(Columns.IdOrdenLaboratorio, value); }
		}
		  
		[XmlAttribute("IdOrden")]
		[Bindable(true)]
		public int IdOrden 
		{
			get { return GetColumnValue<int>(Columns.IdOrden); }
			set { SetColumnValue(Columns.IdOrden, value); }
		}
		  
		[XmlAttribute("IdProtocolo")]
		[Bindable(true)]
		public int IdProtocolo 
		{
			get { return GetColumnValue<int>(Columns.IdProtocolo); }
			set { SetColumnValue(Columns.IdProtocolo, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabResultadoEncabezado ActiveRecord object related to this FacOrdenLaboratorio
		/// 
		/// </summary>
		public DalSic.LabResultadoEncabezado LabResultadoEncabezado
		{
			get { return DalSic.LabResultadoEncabezado.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdProtocolo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdOrden,int varIdProtocolo,int varIdEfector)
		{
			FacOrdenLaboratorio item = new FacOrdenLaboratorio();
			
			item.IdOrden = varIdOrden;
			
			item.IdProtocolo = varIdProtocolo;
			
			item.IdEfector = varIdEfector;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdOrdenLaboratorio,int varIdOrden,int varIdProtocolo,int varIdEfector)
		{
			FacOrdenLaboratorio item = new FacOrdenLaboratorio();
			
				item.IdOrdenLaboratorio = varIdOrdenLaboratorio;
			
				item.IdOrden = varIdOrden;
			
				item.IdProtocolo = varIdProtocolo;
			
				item.IdEfector = varIdEfector;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdOrdenLaboratorioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdOrdenColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProtocoloColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdOrdenLaboratorio = @"idOrdenLaboratorio";
			 public static string IdOrden = @"idOrden";
			 public static string IdProtocolo = @"idProtocolo";
			 public static string IdEfector = @"idEfector";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
