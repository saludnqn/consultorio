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
	/// Strongly-typed collection for the RisEnmienda class.
	/// </summary>
    [Serializable]
	public partial class RisEnmiendaCollection : ActiveList<RisEnmienda, RisEnmiendaCollection>
	{	   
		public RisEnmiendaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEnmiendaCollection</returns>
		public RisEnmiendaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEnmienda o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_Enmienda table.
	/// </summary>
	[Serializable]
	public partial class RisEnmienda : ActiveRecord<RisEnmienda>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEnmienda()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEnmienda(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEnmienda(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEnmienda(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_Enmienda", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEnmienda = new TableSchema.TableColumn(schema);
				colvarIdEnmienda.ColumnName = "idEnmienda";
				colvarIdEnmienda.DataType = DbType.Int32;
				colvarIdEnmienda.MaxLength = 0;
				colvarIdEnmienda.AutoIncrement = true;
				colvarIdEnmienda.IsNullable = false;
				colvarIdEnmienda.IsPrimaryKey = true;
				colvarIdEnmienda.IsForeignKey = false;
				colvarIdEnmienda.IsReadOnly = false;
				colvarIdEnmienda.DefaultSetting = @"";
				colvarIdEnmienda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEnmienda);
				
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
				
				TableSchema.TableColumn colvarModificacion = new TableSchema.TableColumn(schema);
				colvarModificacion.ColumnName = "modificacion";
				colvarModificacion.DataType = DbType.AnsiString;
				colvarModificacion.MaxLength = 100;
				colvarModificacion.AutoIncrement = false;
				colvarModificacion.IsNullable = true;
				colvarModificacion.IsPrimaryKey = false;
				colvarModificacion.IsForeignKey = false;
				colvarModificacion.IsReadOnly = false;
				colvarModificacion.DefaultSetting = @"";
				colvarModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModificacion);
				
				TableSchema.TableColumn colvarDictamen = new TableSchema.TableColumn(schema);
				colvarDictamen.ColumnName = "dictamen";
				colvarDictamen.DataType = DbType.AnsiString;
				colvarDictamen.MaxLength = 100;
				colvarDictamen.AutoIncrement = false;
				colvarDictamen.IsNullable = true;
				colvarDictamen.IsPrimaryKey = false;
				colvarDictamen.IsForeignKey = false;
				colvarDictamen.IsReadOnly = false;
				colvarDictamen.DefaultSetting = @"";
				colvarDictamen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDictamen);
				
				TableSchema.TableColumn colvarFechaDictamen = new TableSchema.TableColumn(schema);
				colvarFechaDictamen.ColumnName = "fechaDictamen";
				colvarFechaDictamen.DataType = DbType.DateTime;
				colvarFechaDictamen.MaxLength = 0;
				colvarFechaDictamen.AutoIncrement = false;
				colvarFechaDictamen.IsNullable = true;
				colvarFechaDictamen.IsPrimaryKey = false;
				colvarFechaDictamen.IsForeignKey = false;
				colvarFechaDictamen.IsReadOnly = false;
				colvarFechaDictamen.DefaultSetting = @"";
				colvarFechaDictamen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDictamen);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 2000;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_Enmienda",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEnmienda")]
		[Bindable(true)]
		public int IdEnmienda 
		{
			get { return GetColumnValue<int>(Columns.IdEnmienda); }
			set { SetColumnValue(Columns.IdEnmienda, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("Modificacion")]
		[Bindable(true)]
		public string Modificacion 
		{
			get { return GetColumnValue<string>(Columns.Modificacion); }
			set { SetColumnValue(Columns.Modificacion, value); }
		}
		  
		[XmlAttribute("Dictamen")]
		[Bindable(true)]
		public string Dictamen 
		{
			get { return GetColumnValue<string>(Columns.Dictamen); }
			set { SetColumnValue(Columns.Dictamen, value); }
		}
		  
		[XmlAttribute("FechaDictamen")]
		[Bindable(true)]
		public DateTime? FechaDictamen 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDictamen); }
			set { SetColumnValue(Columns.FechaDictamen, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,string varModificacion,string varDictamen,DateTime? varFechaDictamen,string varObservaciones)
		{
			RisEnmienda item = new RisEnmienda();
			
			item.IdEstudio = varIdEstudio;
			
			item.Modificacion = varModificacion;
			
			item.Dictamen = varDictamen;
			
			item.FechaDictamen = varFechaDictamen;
			
			item.Observaciones = varObservaciones;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEnmienda,int varIdEstudio,string varModificacion,string varDictamen,DateTime? varFechaDictamen,string varObservaciones)
		{
			RisEnmienda item = new RisEnmienda();
			
				item.IdEnmienda = varIdEnmienda;
			
				item.IdEstudio = varIdEstudio;
			
				item.Modificacion = varModificacion;
			
				item.Dictamen = varDictamen;
			
				item.FechaDictamen = varFechaDictamen;
			
				item.Observaciones = varObservaciones;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEnmiendaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ModificacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DictamenColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDictamenColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEnmienda = @"idEnmienda";
			 public static string IdEstudio = @"idEstudio";
			 public static string Modificacion = @"modificacion";
			 public static string Dictamen = @"dictamen";
			 public static string FechaDictamen = @"fechaDictamen";
			 public static string Observaciones = @"observaciones";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
