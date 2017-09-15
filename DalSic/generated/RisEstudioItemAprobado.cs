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
	/// Strongly-typed collection for the RisEstudioItemAprobado class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioItemAprobadoCollection : ActiveList<RisEstudioItemAprobado, RisEstudioItemAprobadoCollection>
	{	   
		public RisEstudioItemAprobadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioItemAprobadoCollection</returns>
		public RisEstudioItemAprobadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioItemAprobado o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioItemAprobado table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioItemAprobado : ActiveRecord<RisEstudioItemAprobado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioItemAprobado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioItemAprobado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioItemAprobado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioItemAprobado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioItemAprobado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioItemAprobado = new TableSchema.TableColumn(schema);
				colvarIdEstudioItemAprobado.ColumnName = "idEstudioItemAprobado";
				colvarIdEstudioItemAprobado.DataType = DbType.Int32;
				colvarIdEstudioItemAprobado.MaxLength = 0;
				colvarIdEstudioItemAprobado.AutoIncrement = true;
				colvarIdEstudioItemAprobado.IsNullable = false;
				colvarIdEstudioItemAprobado.IsPrimaryKey = true;
				colvarIdEstudioItemAprobado.IsForeignKey = false;
				colvarIdEstudioItemAprobado.IsReadOnly = false;
				colvarIdEstudioItemAprobado.DefaultSetting = @"";
				colvarIdEstudioItemAprobado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioItemAprobado);
				
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
				
				TableSchema.TableColumn colvarIdItemAprobado = new TableSchema.TableColumn(schema);
				colvarIdItemAprobado.ColumnName = "idItemAprobado";
				colvarIdItemAprobado.DataType = DbType.Int32;
				colvarIdItemAprobado.MaxLength = 0;
				colvarIdItemAprobado.AutoIncrement = false;
				colvarIdItemAprobado.IsNullable = false;
				colvarIdItemAprobado.IsPrimaryKey = false;
				colvarIdItemAprobado.IsForeignKey = false;
				colvarIdItemAprobado.IsReadOnly = false;
				colvarIdItemAprobado.DefaultSetting = @"";
				colvarIdItemAprobado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItemAprobado);
				
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
				
				TableSchema.TableColumn colvarNumeroDisposicion = new TableSchema.TableColumn(schema);
				colvarNumeroDisposicion.ColumnName = "numeroDisposicion";
				colvarNumeroDisposicion.DataType = DbType.AnsiString;
				colvarNumeroDisposicion.MaxLength = 50;
				colvarNumeroDisposicion.AutoIncrement = false;
				colvarNumeroDisposicion.IsNullable = true;
				colvarNumeroDisposicion.IsPrimaryKey = false;
				colvarNumeroDisposicion.IsForeignKey = false;
				colvarNumeroDisposicion.IsReadOnly = false;
				colvarNumeroDisposicion.DefaultSetting = @"";
				colvarNumeroDisposicion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDisposicion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioItemAprobado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioItemAprobado")]
		[Bindable(true)]
		public int IdEstudioItemAprobado 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioItemAprobado); }
			set { SetColumnValue(Columns.IdEstudioItemAprobado, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdItemAprobado")]
		[Bindable(true)]
		public int IdItemAprobado 
		{
			get { return GetColumnValue<int>(Columns.IdItemAprobado); }
			set { SetColumnValue(Columns.IdItemAprobado, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("NumeroDisposicion")]
		[Bindable(true)]
		public string NumeroDisposicion 
		{
			get { return GetColumnValue<string>(Columns.NumeroDisposicion); }
			set { SetColumnValue(Columns.NumeroDisposicion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdItemAprobado,DateTime varFecha,string varNumeroDisposicion)
		{
			RisEstudioItemAprobado item = new RisEstudioItemAprobado();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdItemAprobado = varIdItemAprobado;
			
			item.Fecha = varFecha;
			
			item.NumeroDisposicion = varNumeroDisposicion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioItemAprobado,int varIdEstudio,int varIdItemAprobado,DateTime varFecha,string varNumeroDisposicion)
		{
			RisEstudioItemAprobado item = new RisEstudioItemAprobado();
			
				item.IdEstudioItemAprobado = varIdEstudioItemAprobado;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdItemAprobado = varIdItemAprobado;
			
				item.Fecha = varFecha;
			
				item.NumeroDisposicion = varNumeroDisposicion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioItemAprobadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemAprobadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDisposicionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioItemAprobado = @"idEstudioItemAprobado";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdItemAprobado = @"idItemAprobado";
			 public static string Fecha = @"fecha";
			 public static string NumeroDisposicion = @"numeroDisposicion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
