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
	/// Strongly-typed collection for the PnCalificacion class.
	/// </summary>
    [Serializable]
	public partial class PnCalificacionCollection : ActiveList<PnCalificacion, PnCalificacionCollection>
	{	   
		public PnCalificacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCalificacionCollection</returns>
		public PnCalificacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCalificacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_calificacion table.
	/// </summary>
	[Serializable]
	public partial class PnCalificacion : ActiveRecord<PnCalificacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCalificacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCalificacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCalificacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCalificacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_calificacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCalificacion = new TableSchema.TableColumn(schema);
				colvarIdCalificacion.ColumnName = "id_calificacion";
				colvarIdCalificacion.DataType = DbType.Int32;
				colvarIdCalificacion.MaxLength = 0;
				colvarIdCalificacion.AutoIncrement = true;
				colvarIdCalificacion.IsNullable = false;
				colvarIdCalificacion.IsPrimaryKey = true;
				colvarIdCalificacion.IsForeignKey = false;
				colvarIdCalificacion.IsReadOnly = false;
				colvarIdCalificacion.DefaultSetting = @"";
				colvarIdCalificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCalificacion);
				
				TableSchema.TableColumn colvarNombreCalificacion = new TableSchema.TableColumn(schema);
				colvarNombreCalificacion.ColumnName = "nombre_calificacion";
				colvarNombreCalificacion.DataType = DbType.AnsiString;
				colvarNombreCalificacion.MaxLength = -1;
				colvarNombreCalificacion.AutoIncrement = false;
				colvarNombreCalificacion.IsNullable = true;
				colvarNombreCalificacion.IsPrimaryKey = false;
				colvarNombreCalificacion.IsForeignKey = false;
				colvarNombreCalificacion.IsReadOnly = false;
				colvarNombreCalificacion.DefaultSetting = @"";
				colvarNombreCalificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreCalificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_calificacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCalificacion")]
		[Bindable(true)]
		public int IdCalificacion 
		{
			get { return GetColumnValue<int>(Columns.IdCalificacion); }
			set { SetColumnValue(Columns.IdCalificacion, value); }
		}
		  
		[XmlAttribute("NombreCalificacion")]
		[Bindable(true)]
		public string NombreCalificacion 
		{
			get { return GetColumnValue<string>(Columns.NombreCalificacion); }
			set { SetColumnValue(Columns.NombreCalificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombreCalificacion)
		{
			PnCalificacion item = new PnCalificacion();
			
			item.NombreCalificacion = varNombreCalificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCalificacion,string varNombreCalificacion)
		{
			PnCalificacion item = new PnCalificacion();
			
				item.IdCalificacion = varIdCalificacion;
			
				item.NombreCalificacion = varNombreCalificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCalificacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreCalificacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCalificacion = @"id_calificacion";
			 public static string NombreCalificacion = @"nombre_calificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
