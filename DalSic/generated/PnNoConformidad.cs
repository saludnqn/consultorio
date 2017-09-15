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
	/// Strongly-typed collection for the PnNoConformidad class.
	/// </summary>
    [Serializable]
	public partial class PnNoConformidadCollection : ActiveList<PnNoConformidad, PnNoConformidadCollection>
	{	   
		public PnNoConformidadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnNoConformidadCollection</returns>
		public PnNoConformidadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnNoConformidad o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_no_conformidad table.
	/// </summary>
	[Serializable]
	public partial class PnNoConformidad : ActiveRecord<PnNoConformidad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnNoConformidad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnNoConformidad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnNoConformidad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnNoConformidad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_no_conformidad", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNoConformidad = new TableSchema.TableColumn(schema);
				colvarIdNoConformidad.ColumnName = "id_no_conformidad";
				colvarIdNoConformidad.DataType = DbType.Int32;
				colvarIdNoConformidad.MaxLength = 0;
				colvarIdNoConformidad.AutoIncrement = true;
				colvarIdNoConformidad.IsNullable = false;
				colvarIdNoConformidad.IsPrimaryKey = true;
				colvarIdNoConformidad.IsForeignKey = false;
				colvarIdNoConformidad.IsReadOnly = false;
				colvarIdNoConformidad.DefaultSetting = @"";
				colvarIdNoConformidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNoConformidad);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.Int16;
				colvarTipo.MaxLength = 0;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_no_conformidad",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNoConformidad")]
		[Bindable(true)]
		public int IdNoConformidad 
		{
			get { return GetColumnValue<int>(Columns.IdNoConformidad); }
			set { SetColumnValue(Columns.IdNoConformidad, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public short? Tipo 
		{
			get { return GetColumnValue<short?>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion,short? varTipo)
		{
			PnNoConformidad item = new PnNoConformidad();
			
			item.Descripcion = varDescripcion;
			
			item.Tipo = varTipo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNoConformidad,string varDescripcion,short? varTipo)
		{
			PnNoConformidad item = new PnNoConformidad();
			
				item.IdNoConformidad = varIdNoConformidad;
			
				item.Descripcion = varDescripcion;
			
				item.Tipo = varTipo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNoConformidadColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNoConformidad = @"id_no_conformidad";
			 public static string Descripcion = @"descripcion";
			 public static string Tipo = @"tipo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
