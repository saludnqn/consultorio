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
	/// Strongly-typed collection for the RisVigenciaPoliza class.
	/// </summary>
    [Serializable]
	public partial class RisVigenciaPolizaCollection : ActiveList<RisVigenciaPoliza, RisVigenciaPolizaCollection>
	{	   
		public RisVigenciaPolizaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisVigenciaPolizaCollection</returns>
		public RisVigenciaPolizaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisVigenciaPoliza o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_VigenciaPoliza table.
	/// </summary>
	[Serializable]
	public partial class RisVigenciaPoliza : ActiveRecord<RisVigenciaPoliza>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisVigenciaPoliza()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisVigenciaPoliza(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisVigenciaPoliza(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisVigenciaPoliza(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_VigenciaPoliza", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdVigenciaPoliza = new TableSchema.TableColumn(schema);
				colvarIdVigenciaPoliza.ColumnName = "idVigenciaPoliza";
				colvarIdVigenciaPoliza.DataType = DbType.Int32;
				colvarIdVigenciaPoliza.MaxLength = 0;
				colvarIdVigenciaPoliza.AutoIncrement = true;
				colvarIdVigenciaPoliza.IsNullable = false;
				colvarIdVigenciaPoliza.IsPrimaryKey = true;
				colvarIdVigenciaPoliza.IsForeignKey = false;
				colvarIdVigenciaPoliza.IsReadOnly = false;
				colvarIdVigenciaPoliza.DefaultSetting = @"";
				colvarIdVigenciaPoliza.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVigenciaPoliza);
				
				TableSchema.TableColumn colvarIdEstudioAseguradora = new TableSchema.TableColumn(schema);
				colvarIdEstudioAseguradora.ColumnName = "idEstudioAseguradora";
				colvarIdEstudioAseguradora.DataType = DbType.Int32;
				colvarIdEstudioAseguradora.MaxLength = 0;
				colvarIdEstudioAseguradora.AutoIncrement = false;
				colvarIdEstudioAseguradora.IsNullable = false;
				colvarIdEstudioAseguradora.IsPrimaryKey = false;
				colvarIdEstudioAseguradora.IsForeignKey = false;
				colvarIdEstudioAseguradora.IsReadOnly = false;
				colvarIdEstudioAseguradora.DefaultSetting = @"";
				colvarIdEstudioAseguradora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioAseguradora);
				
				TableSchema.TableColumn colvarFechaInicio = new TableSchema.TableColumn(schema);
				colvarFechaInicio.ColumnName = "fechaInicio";
				colvarFechaInicio.DataType = DbType.DateTime;
				colvarFechaInicio.MaxLength = 0;
				colvarFechaInicio.AutoIncrement = false;
				colvarFechaInicio.IsNullable = false;
				colvarFechaInicio.IsPrimaryKey = false;
				colvarFechaInicio.IsForeignKey = false;
				colvarFechaInicio.IsReadOnly = false;
				colvarFechaInicio.DefaultSetting = @"";
				colvarFechaInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInicio);
				
				TableSchema.TableColumn colvarFechaFin = new TableSchema.TableColumn(schema);
				colvarFechaFin.ColumnName = "fechaFin";
				colvarFechaFin.DataType = DbType.DateTime;
				colvarFechaFin.MaxLength = 0;
				colvarFechaFin.AutoIncrement = false;
				colvarFechaFin.IsNullable = false;
				colvarFechaFin.IsPrimaryKey = false;
				colvarFechaFin.IsForeignKey = false;
				colvarFechaFin.IsReadOnly = false;
				colvarFechaFin.DefaultSetting = @"";
				colvarFechaFin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFin);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_VigenciaPoliza",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdVigenciaPoliza")]
		[Bindable(true)]
		public int IdVigenciaPoliza 
		{
			get { return GetColumnValue<int>(Columns.IdVigenciaPoliza); }
			set { SetColumnValue(Columns.IdVigenciaPoliza, value); }
		}
		  
		[XmlAttribute("IdEstudioAseguradora")]
		[Bindable(true)]
		public int IdEstudioAseguradora 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioAseguradora); }
			set { SetColumnValue(Columns.IdEstudioAseguradora, value); }
		}
		  
		[XmlAttribute("FechaInicio")]
		[Bindable(true)]
		public DateTime FechaInicio 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInicio); }
			set { SetColumnValue(Columns.FechaInicio, value); }
		}
		  
		[XmlAttribute("FechaFin")]
		[Bindable(true)]
		public DateTime FechaFin 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaFin); }
			set { SetColumnValue(Columns.FechaFin, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudioAseguradora,DateTime varFechaInicio,DateTime varFechaFin)
		{
			RisVigenciaPoliza item = new RisVigenciaPoliza();
			
			item.IdEstudioAseguradora = varIdEstudioAseguradora;
			
			item.FechaInicio = varFechaInicio;
			
			item.FechaFin = varFechaFin;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdVigenciaPoliza,int varIdEstudioAseguradora,DateTime varFechaInicio,DateTime varFechaFin)
		{
			RisVigenciaPoliza item = new RisVigenciaPoliza();
			
				item.IdVigenciaPoliza = varIdVigenciaPoliza;
			
				item.IdEstudioAseguradora = varIdEstudioAseguradora;
			
				item.FechaInicio = varFechaInicio;
			
				item.FechaFin = varFechaFin;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdVigenciaPolizaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioAseguradoraColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInicioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFinColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdVigenciaPoliza = @"idVigenciaPoliza";
			 public static string IdEstudioAseguradora = @"idEstudioAseguradora";
			 public static string FechaInicio = @"fechaInicio";
			 public static string FechaFin = @"fechaFin";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
