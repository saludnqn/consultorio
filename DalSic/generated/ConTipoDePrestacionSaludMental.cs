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
	/// Strongly-typed collection for the ConTipoDePrestacionSaludMental class.
	/// </summary>
    [Serializable]
	public partial class ConTipoDePrestacionSaludMentalCollection : ActiveList<ConTipoDePrestacionSaludMental, ConTipoDePrestacionSaludMentalCollection>
	{	   
		public ConTipoDePrestacionSaludMentalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTipoDePrestacionSaludMentalCollection</returns>
		public ConTipoDePrestacionSaludMentalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTipoDePrestacionSaludMental o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TipoDePrestacionSaludMental table.
	/// </summary>
	[Serializable]
	public partial class ConTipoDePrestacionSaludMental : ActiveRecord<ConTipoDePrestacionSaludMental>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTipoDePrestacionSaludMental()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTipoDePrestacionSaludMental(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTipoDePrestacionSaludMental(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTipoDePrestacionSaludMental(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TipoDePrestacionSaludMental", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoPrestacion = new TableSchema.TableColumn(schema);
				colvarIdTipoPrestacion.ColumnName = "idTipoPrestacion";
				colvarIdTipoPrestacion.DataType = DbType.Int32;
				colvarIdTipoPrestacion.MaxLength = 0;
				colvarIdTipoPrestacion.AutoIncrement = true;
				colvarIdTipoPrestacion.IsNullable = false;
				colvarIdTipoPrestacion.IsPrimaryKey = true;
				colvarIdTipoPrestacion.IsForeignKey = false;
				colvarIdTipoPrestacion.IsReadOnly = false;
				colvarIdTipoPrestacion.DefaultSetting = @"";
				colvarIdTipoPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoPrestacion);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 20;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TipoDePrestacionSaludMental",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoPrestacion")]
		[Bindable(true)]
		public int IdTipoPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdTipoPrestacion); }
			set { SetColumnValue(Columns.IdTipoPrestacion, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			ConTipoDePrestacionSaludMental item = new ConTipoDePrestacionSaludMental();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoPrestacion,string varNombre)
		{
			ConTipoDePrestacionSaludMental item = new ConTipoDePrestacionSaludMental();
			
				item.IdTipoPrestacion = varIdTipoPrestacion;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoPrestacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoPrestacion = @"idTipoPrestacion";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
