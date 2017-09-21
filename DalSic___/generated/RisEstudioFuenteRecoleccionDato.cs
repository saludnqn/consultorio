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
	/// Strongly-typed collection for the RisEstudioFuenteRecoleccionDato class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioFuenteRecoleccionDatoCollection : ActiveList<RisEstudioFuenteRecoleccionDato, RisEstudioFuenteRecoleccionDatoCollection>
	{	   
		public RisEstudioFuenteRecoleccionDatoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioFuenteRecoleccionDatoCollection</returns>
		public RisEstudioFuenteRecoleccionDatoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioFuenteRecoleccionDato o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioFuenteRecoleccionDatos table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioFuenteRecoleccionDato : ActiveRecord<RisEstudioFuenteRecoleccionDato>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioFuenteRecoleccionDato()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioFuenteRecoleccionDato(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioFuenteRecoleccionDato(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioFuenteRecoleccionDato(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioFuenteRecoleccionDatos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioFuenteRecoleccionDatos = new TableSchema.TableColumn(schema);
				colvarIdEstudioFuenteRecoleccionDatos.ColumnName = "idEstudioFuenteRecoleccionDatos";
				colvarIdEstudioFuenteRecoleccionDatos.DataType = DbType.Int32;
				colvarIdEstudioFuenteRecoleccionDatos.MaxLength = 0;
				colvarIdEstudioFuenteRecoleccionDatos.AutoIncrement = true;
				colvarIdEstudioFuenteRecoleccionDatos.IsNullable = false;
				colvarIdEstudioFuenteRecoleccionDatos.IsPrimaryKey = true;
				colvarIdEstudioFuenteRecoleccionDatos.IsForeignKey = false;
				colvarIdEstudioFuenteRecoleccionDatos.IsReadOnly = false;
				colvarIdEstudioFuenteRecoleccionDatos.DefaultSetting = @"";
				colvarIdEstudioFuenteRecoleccionDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioFuenteRecoleccionDatos);
				
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
				
				TableSchema.TableColumn colvarIdFuenteRecoleccionDatos = new TableSchema.TableColumn(schema);
				colvarIdFuenteRecoleccionDatos.ColumnName = "idFuenteRecoleccionDatos";
				colvarIdFuenteRecoleccionDatos.DataType = DbType.Int32;
				colvarIdFuenteRecoleccionDatos.MaxLength = 0;
				colvarIdFuenteRecoleccionDatos.AutoIncrement = false;
				colvarIdFuenteRecoleccionDatos.IsNullable = false;
				colvarIdFuenteRecoleccionDatos.IsPrimaryKey = false;
				colvarIdFuenteRecoleccionDatos.IsForeignKey = false;
				colvarIdFuenteRecoleccionDatos.IsReadOnly = false;
				colvarIdFuenteRecoleccionDatos.DefaultSetting = @"";
				colvarIdFuenteRecoleccionDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFuenteRecoleccionDatos);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioFuenteRecoleccionDatos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioFuenteRecoleccionDatos")]
		[Bindable(true)]
		public int IdEstudioFuenteRecoleccionDatos 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioFuenteRecoleccionDatos); }
			set { SetColumnValue(Columns.IdEstudioFuenteRecoleccionDatos, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdFuenteRecoleccionDatos")]
		[Bindable(true)]
		public int IdFuenteRecoleccionDatos 
		{
			get { return GetColumnValue<int>(Columns.IdFuenteRecoleccionDatos); }
			set { SetColumnValue(Columns.IdFuenteRecoleccionDatos, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdFuenteRecoleccionDatos)
		{
			RisEstudioFuenteRecoleccionDato item = new RisEstudioFuenteRecoleccionDato();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdFuenteRecoleccionDatos = varIdFuenteRecoleccionDatos;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioFuenteRecoleccionDatos,int varIdEstudio,int varIdFuenteRecoleccionDatos)
		{
			RisEstudioFuenteRecoleccionDato item = new RisEstudioFuenteRecoleccionDato();
			
				item.IdEstudioFuenteRecoleccionDatos = varIdEstudioFuenteRecoleccionDatos;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdFuenteRecoleccionDatos = varIdFuenteRecoleccionDatos;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioFuenteRecoleccionDatosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFuenteRecoleccionDatosColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioFuenteRecoleccionDatos = @"idEstudioFuenteRecoleccionDatos";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdFuenteRecoleccionDatos = @"idFuenteRecoleccionDatos";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
