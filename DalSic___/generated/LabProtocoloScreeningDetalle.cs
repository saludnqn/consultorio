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
	/// Strongly-typed collection for the LabProtocoloScreeningDetalle class.
	/// </summary>
    [Serializable]
	public partial class LabProtocoloScreeningDetalleCollection : ActiveList<LabProtocoloScreeningDetalle, LabProtocoloScreeningDetalleCollection>
	{	   
		public LabProtocoloScreeningDetalleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabProtocoloScreeningDetalleCollection</returns>
		public LabProtocoloScreeningDetalleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabProtocoloScreeningDetalle o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_ProtocoloScreeningDetalle table.
	/// </summary>
	[Serializable]
	public partial class LabProtocoloScreeningDetalle : ActiveRecord<LabProtocoloScreeningDetalle>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabProtocoloScreeningDetalle()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabProtocoloScreeningDetalle(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabProtocoloScreeningDetalle(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabProtocoloScreeningDetalle(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_ProtocoloScreeningDetalle", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProtocolo = new TableSchema.TableColumn(schema);
				colvarIdProtocolo.ColumnName = "idProtocolo";
				colvarIdProtocolo.DataType = DbType.Decimal;
				colvarIdProtocolo.MaxLength = 0;
				colvarIdProtocolo.AutoIncrement = true;
				colvarIdProtocolo.IsNullable = false;
				colvarIdProtocolo.IsPrimaryKey = true;
				colvarIdProtocolo.IsForeignKey = false;
				colvarIdProtocolo.IsReadOnly = false;
				colvarIdProtocolo.DefaultSetting = @"";
				colvarIdProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProtocolo);
				
				TableSchema.TableColumn colvarIdSolicitudScreening = new TableSchema.TableColumn(schema);
				colvarIdSolicitudScreening.ColumnName = "idSolicitudScreening";
				colvarIdSolicitudScreening.DataType = DbType.Int32;
				colvarIdSolicitudScreening.MaxLength = 0;
				colvarIdSolicitudScreening.AutoIncrement = false;
				colvarIdSolicitudScreening.IsNullable = false;
				colvarIdSolicitudScreening.IsPrimaryKey = false;
				colvarIdSolicitudScreening.IsForeignKey = true;
				colvarIdSolicitudScreening.IsReadOnly = false;
				colvarIdSolicitudScreening.DefaultSetting = @"";
				
					colvarIdSolicitudScreening.ForeignKeyTableName = "LAB_SolicitudScreening";
				schema.Columns.Add(colvarIdSolicitudScreening);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"(getdate())";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarIdProtocoloHead = new TableSchema.TableColumn(schema);
				colvarIdProtocoloHead.ColumnName = "idProtocoloHead";
				colvarIdProtocoloHead.DataType = DbType.Decimal;
				colvarIdProtocoloHead.MaxLength = 0;
				colvarIdProtocoloHead.AutoIncrement = false;
				colvarIdProtocoloHead.IsNullable = false;
				colvarIdProtocoloHead.IsPrimaryKey = false;
				colvarIdProtocoloHead.IsForeignKey = false;
				colvarIdProtocoloHead.IsReadOnly = false;
				colvarIdProtocoloHead.DefaultSetting = @"";
				colvarIdProtocoloHead.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProtocoloHead);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_ProtocoloScreeningDetalle",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProtocolo")]
		[Bindable(true)]
		public decimal IdProtocolo 
		{
			get { return GetColumnValue<decimal>(Columns.IdProtocolo); }
			set { SetColumnValue(Columns.IdProtocolo, value); }
		}
		  
		[XmlAttribute("IdSolicitudScreening")]
		[Bindable(true)]
		public int IdSolicitudScreening 
		{
			get { return GetColumnValue<int>(Columns.IdSolicitudScreening); }
			set { SetColumnValue(Columns.IdSolicitudScreening, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("IdProtocoloHead")]
		[Bindable(true)]
		public decimal IdProtocoloHead 
		{
			get { return GetColumnValue<decimal>(Columns.IdProtocoloHead); }
			set { SetColumnValue(Columns.IdProtocoloHead, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a LabSolicitudScreening ActiveRecord object related to this LabProtocoloScreeningDetalle
		/// 
		/// </summary>
		public DalSic.LabSolicitudScreening LabSolicitudScreening
		{
			get { return DalSic.LabSolicitudScreening.FetchByID(this.IdSolicitudScreening); }
			set { SetColumnValue("idSolicitudScreening", value.IdSolicitudScreening); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdSolicitudScreening,DateTime? varFecha,decimal varIdProtocoloHead)
		{
			LabProtocoloScreeningDetalle item = new LabProtocoloScreeningDetalle();
			
			item.IdSolicitudScreening = varIdSolicitudScreening;
			
			item.Fecha = varFecha;
			
			item.IdProtocoloHead = varIdProtocoloHead;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(decimal varIdProtocolo,int varIdSolicitudScreening,DateTime? varFecha,decimal varIdProtocoloHead)
		{
			LabProtocoloScreeningDetalle item = new LabProtocoloScreeningDetalle();
			
				item.IdProtocolo = varIdProtocolo;
			
				item.IdSolicitudScreening = varIdSolicitudScreening;
			
				item.Fecha = varFecha;
			
				item.IdProtocoloHead = varIdProtocoloHead;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProtocoloColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProtocoloHeadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProtocolo = @"idProtocolo";
			 public static string IdSolicitudScreening = @"idSolicitudScreening";
			 public static string Fecha = @"fecha";
			 public static string IdProtocoloHead = @"idProtocoloHead";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
