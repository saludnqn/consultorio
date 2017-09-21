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
	/// Strongly-typed collection for the LabProtocoloScreening class.
	/// </summary>
    [Serializable]
	public partial class LabProtocoloScreeningCollection : ActiveList<LabProtocoloScreening, LabProtocoloScreeningCollection>
	{	   
		public LabProtocoloScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabProtocoloScreeningCollection</returns>
		public LabProtocoloScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabProtocoloScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_ProtocoloScreening table.
	/// </summary>
	[Serializable]
	public partial class LabProtocoloScreening : ActiveRecord<LabProtocoloScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabProtocoloScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabProtocoloScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabProtocoloScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabProtocoloScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_ProtocoloScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProtocoloHead = new TableSchema.TableColumn(schema);
				colvarIdProtocoloHead.ColumnName = "idProtocoloHead";
				colvarIdProtocoloHead.DataType = DbType.Decimal;
				colvarIdProtocoloHead.MaxLength = 0;
				colvarIdProtocoloHead.AutoIncrement = true;
				colvarIdProtocoloHead.IsNullable = false;
				colvarIdProtocoloHead.IsPrimaryKey = true;
				colvarIdProtocoloHead.IsForeignKey = false;
				colvarIdProtocoloHead.IsReadOnly = false;
				colvarIdProtocoloHead.DefaultSetting = @"";
				colvarIdProtocoloHead.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProtocoloHead);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = false;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				
						colvarBaja.DefaultSetting = @"((0))";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"(getdate())";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_ProtocoloScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProtocoloHead")]
		[Bindable(true)]
		public decimal IdProtocoloHead 
		{
			get { return GetColumnValue<decimal>(Columns.IdProtocoloHead); }
			set { SetColumnValue(Columns.IdProtocoloHead, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool Baja 
		{
			get { return GetColumnValue<bool>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(bool varBaja,DateTime varFecha)
		{
			LabProtocoloScreening item = new LabProtocoloScreening();
			
			item.Baja = varBaja;
			
			item.Fecha = varFecha;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(decimal varIdProtocoloHead,bool varBaja,DateTime varFecha)
		{
			LabProtocoloScreening item = new LabProtocoloScreening();
			
				item.IdProtocoloHead = varIdProtocoloHead;
			
				item.Baja = varBaja;
			
				item.Fecha = varFecha;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProtocoloHeadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProtocoloHead = @"idProtocoloHead";
			 public static string Baja = @"baja";
			 public static string Fecha = @"fecha";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
