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
	/// Strongly-typed collection for the RisPresentacionInforme class.
	/// </summary>
    [Serializable]
	public partial class RisPresentacionInformeCollection : ActiveList<RisPresentacionInforme, RisPresentacionInformeCollection>
	{	   
		public RisPresentacionInformeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisPresentacionInformeCollection</returns>
		public RisPresentacionInformeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisPresentacionInforme o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_PresentacionInforme table.
	/// </summary>
	[Serializable]
	public partial class RisPresentacionInforme : ActiveRecord<RisPresentacionInforme>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisPresentacionInforme()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisPresentacionInforme(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisPresentacionInforme(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisPresentacionInforme(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_PresentacionInforme", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPresentacionInforme = new TableSchema.TableColumn(schema);
				colvarIdPresentacionInforme.ColumnName = "idPresentacionInforme";
				colvarIdPresentacionInforme.DataType = DbType.Int32;
				colvarIdPresentacionInforme.MaxLength = 0;
				colvarIdPresentacionInforme.AutoIncrement = true;
				colvarIdPresentacionInforme.IsNullable = false;
				colvarIdPresentacionInforme.IsPrimaryKey = true;
				colvarIdPresentacionInforme.IsForeignKey = false;
				colvarIdPresentacionInforme.IsReadOnly = false;
				colvarIdPresentacionInforme.DefaultSetting = @"";
				colvarIdPresentacionInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPresentacionInforme);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_PresentacionInforme",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPresentacionInforme")]
		[Bindable(true)]
		public int IdPresentacionInforme 
		{
			get { return GetColumnValue<int>(Columns.IdPresentacionInforme); }
			set { SetColumnValue(Columns.IdPresentacionInforme, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
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
		public static void Insert(int varIdEstudio,DateTime varFecha)
		{
			RisPresentacionInforme item = new RisPresentacionInforme();
			
			item.IdEstudio = varIdEstudio;
			
			item.Fecha = varFecha;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPresentacionInforme,int varIdEstudio,DateTime varFecha)
		{
			RisPresentacionInforme item = new RisPresentacionInforme();
			
				item.IdPresentacionInforme = varIdPresentacionInforme;
			
				item.IdEstudio = varIdEstudio;
			
				item.Fecha = varFecha;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPresentacionInformeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
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
			 public static string IdPresentacionInforme = @"idPresentacionInforme";
			 public static string IdEstudio = @"idEstudio";
			 public static string Fecha = @"fecha";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
