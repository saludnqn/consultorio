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
	/// Strongly-typed collection for the PnCapacitado class.
	/// </summary>
    [Serializable]
	public partial class PnCapacitadoCollection : ActiveList<PnCapacitado, PnCapacitadoCollection>
	{	   
		public PnCapacitadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCapacitadoCollection</returns>
		public PnCapacitadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCapacitado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_capacitados table.
	/// </summary>
	[Serializable]
	public partial class PnCapacitado : ActiveRecord<PnCapacitado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCapacitado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCapacitado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCapacitado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCapacitado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_capacitados", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = true;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = true;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarIdCapacitacion = new TableSchema.TableColumn(schema);
				colvarIdCapacitacion.ColumnName = "id_capacitacion";
				colvarIdCapacitacion.DataType = DbType.Int32;
				colvarIdCapacitacion.MaxLength = 0;
				colvarIdCapacitacion.AutoIncrement = false;
				colvarIdCapacitacion.IsNullable = false;
				colvarIdCapacitacion.IsPrimaryKey = false;
				colvarIdCapacitacion.IsForeignKey = false;
				colvarIdCapacitacion.IsReadOnly = false;
				colvarIdCapacitacion.DefaultSetting = @"";
				colvarIdCapacitacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCapacitacion);
				
				TableSchema.TableColumn colvarCalificacion = new TableSchema.TableColumn(schema);
				colvarCalificacion.ColumnName = "calificacion";
				colvarCalificacion.DataType = DbType.Int16;
				colvarCalificacion.MaxLength = 0;
				colvarCalificacion.AutoIncrement = false;
				colvarCalificacion.IsNullable = true;
				colvarCalificacion.IsPrimaryKey = false;
				colvarCalificacion.IsForeignKey = false;
				colvarCalificacion.IsReadOnly = false;
				colvarCalificacion.DefaultSetting = @"";
				colvarCalificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCalificacion);
				
				TableSchema.TableColumn colvarCalificador = new TableSchema.TableColumn(schema);
				colvarCalificador.ColumnName = "calificador";
				colvarCalificador.DataType = DbType.AnsiString;
				colvarCalificador.MaxLength = -1;
				colvarCalificador.AutoIncrement = false;
				colvarCalificador.IsNullable = true;
				colvarCalificador.IsPrimaryKey = false;
				colvarCalificador.IsForeignKey = false;
				colvarCalificador.IsReadOnly = false;
				colvarCalificador.DefaultSetting = @"";
				colvarCalificador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCalificador);
				
				TableSchema.TableColumn colvarFechaCalificacion = new TableSchema.TableColumn(schema);
				colvarFechaCalificacion.ColumnName = "fecha_calificacion";
				colvarFechaCalificacion.DataType = DbType.DateTime;
				colvarFechaCalificacion.MaxLength = 0;
				colvarFechaCalificacion.AutoIncrement = false;
				colvarFechaCalificacion.IsNullable = true;
				colvarFechaCalificacion.IsPrimaryKey = false;
				colvarFechaCalificacion.IsForeignKey = false;
				colvarFechaCalificacion.IsReadOnly = false;
				colvarFechaCalificacion.DefaultSetting = @"";
				colvarFechaCalificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCalificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_capacitados",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("IdCapacitacion")]
		[Bindable(true)]
		public int IdCapacitacion 
		{
			get { return GetColumnValue<int>(Columns.IdCapacitacion); }
			set { SetColumnValue(Columns.IdCapacitacion, value); }
		}
		  
		[XmlAttribute("Calificacion")]
		[Bindable(true)]
		public short? Calificacion 
		{
			get { return GetColumnValue<short?>(Columns.Calificacion); }
			set { SetColumnValue(Columns.Calificacion, value); }
		}
		  
		[XmlAttribute("Calificador")]
		[Bindable(true)]
		public string Calificador 
		{
			get { return GetColumnValue<string>(Columns.Calificador); }
			set { SetColumnValue(Columns.Calificador, value); }
		}
		  
		[XmlAttribute("FechaCalificacion")]
		[Bindable(true)]
		public DateTime? FechaCalificacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCalificacion); }
			set { SetColumnValue(Columns.FechaCalificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdCapacitacion,short? varCalificacion,string varCalificador,DateTime? varFechaCalificacion)
		{
			PnCapacitado item = new PnCapacitado();
			
			item.IdCapacitacion = varIdCapacitacion;
			
			item.Calificacion = varCalificacion;
			
			item.Calificador = varCalificador;
			
			item.FechaCalificacion = varFechaCalificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLegajo,int varIdCapacitacion,short? varCalificacion,string varCalificador,DateTime? varFechaCalificacion)
		{
			PnCapacitado item = new PnCapacitado();
			
				item.IdLegajo = varIdLegajo;
			
				item.IdCapacitacion = varIdCapacitacion;
			
				item.Calificacion = varCalificacion;
			
				item.Calificador = varCalificador;
			
				item.FechaCalificacion = varFechaCalificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCapacitacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CalificacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CalificadorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCalificacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLegajo = @"id_legajo";
			 public static string IdCapacitacion = @"id_capacitacion";
			 public static string Calificacion = @"calificacion";
			 public static string Calificador = @"calificador";
			 public static string FechaCalificacion = @"fecha_calificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
