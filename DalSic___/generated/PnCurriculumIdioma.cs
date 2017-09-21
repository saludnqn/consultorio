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
	/// Strongly-typed collection for the PnCurriculumIdioma class.
	/// </summary>
    [Serializable]
	public partial class PnCurriculumIdiomaCollection : ActiveList<PnCurriculumIdioma, PnCurriculumIdiomaCollection>
	{	   
		public PnCurriculumIdiomaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCurriculumIdiomaCollection</returns>
		public PnCurriculumIdiomaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCurriculumIdioma o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_curriculum_idiomas table.
	/// </summary>
	[Serializable]
	public partial class PnCurriculumIdioma : ActiveRecord<PnCurriculumIdioma>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCurriculumIdioma()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCurriculumIdioma(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCurriculumIdioma(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCurriculumIdioma(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_curriculum_idiomas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCurriculumIdiomas = new TableSchema.TableColumn(schema);
				colvarIdCurriculumIdiomas.ColumnName = "id_curriculum_idiomas";
				colvarIdCurriculumIdiomas.DataType = DbType.Int32;
				colvarIdCurriculumIdiomas.MaxLength = 0;
				colvarIdCurriculumIdiomas.AutoIncrement = true;
				colvarIdCurriculumIdiomas.IsNullable = false;
				colvarIdCurriculumIdiomas.IsPrimaryKey = true;
				colvarIdCurriculumIdiomas.IsForeignKey = false;
				colvarIdCurriculumIdiomas.IsReadOnly = false;
				colvarIdCurriculumIdiomas.DefaultSetting = @"";
				colvarIdCurriculumIdiomas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCurriculumIdiomas);
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = false;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = false;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarIdioma = new TableSchema.TableColumn(schema);
				colvarIdioma.ColumnName = "idioma";
				colvarIdioma.DataType = DbType.AnsiString;
				colvarIdioma.MaxLength = -1;
				colvarIdioma.AutoIncrement = false;
				colvarIdioma.IsNullable = false;
				colvarIdioma.IsPrimaryKey = false;
				colvarIdioma.IsForeignKey = false;
				colvarIdioma.IsReadOnly = false;
				colvarIdioma.DefaultSetting = @"";
				colvarIdioma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdioma);
				
				TableSchema.TableColumn colvarLee = new TableSchema.TableColumn(schema);
				colvarLee.ColumnName = "lee";
				colvarLee.DataType = DbType.AnsiStringFixedLength;
				colvarLee.MaxLength = 1;
				colvarLee.AutoIncrement = false;
				colvarLee.IsNullable = false;
				colvarLee.IsPrimaryKey = false;
				colvarLee.IsForeignKey = false;
				colvarLee.IsReadOnly = false;
				colvarLee.DefaultSetting = @"";
				colvarLee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLee);
				
				TableSchema.TableColumn colvarEscribe = new TableSchema.TableColumn(schema);
				colvarEscribe.ColumnName = "escribe";
				colvarEscribe.DataType = DbType.AnsiStringFixedLength;
				colvarEscribe.MaxLength = 1;
				colvarEscribe.AutoIncrement = false;
				colvarEscribe.IsNullable = false;
				colvarEscribe.IsPrimaryKey = false;
				colvarEscribe.IsForeignKey = false;
				colvarEscribe.IsReadOnly = false;
				colvarEscribe.DefaultSetting = @"";
				colvarEscribe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEscribe);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_curriculum_idiomas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCurriculumIdiomas")]
		[Bindable(true)]
		public int IdCurriculumIdiomas 
		{
			get { return GetColumnValue<int>(Columns.IdCurriculumIdiomas); }
			set { SetColumnValue(Columns.IdCurriculumIdiomas, value); }
		}
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("Idioma")]
		[Bindable(true)]
		public string Idioma 
		{
			get { return GetColumnValue<string>(Columns.Idioma); }
			set { SetColumnValue(Columns.Idioma, value); }
		}
		  
		[XmlAttribute("Lee")]
		[Bindable(true)]
		public string Lee 
		{
			get { return GetColumnValue<string>(Columns.Lee); }
			set { SetColumnValue(Columns.Lee, value); }
		}
		  
		[XmlAttribute("Escribe")]
		[Bindable(true)]
		public string Escribe 
		{
			get { return GetColumnValue<string>(Columns.Escribe); }
			set { SetColumnValue(Columns.Escribe, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdLegajo,string varIdioma,string varLee,string varEscribe)
		{
			PnCurriculumIdioma item = new PnCurriculumIdioma();
			
			item.IdLegajo = varIdLegajo;
			
			item.Idioma = varIdioma;
			
			item.Lee = varLee;
			
			item.Escribe = varEscribe;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCurriculumIdiomas,int varIdLegajo,string varIdioma,string varLee,string varEscribe)
		{
			PnCurriculumIdioma item = new PnCurriculumIdioma();
			
				item.IdCurriculumIdiomas = varIdCurriculumIdiomas;
			
				item.IdLegajo = varIdLegajo;
			
				item.Idioma = varIdioma;
			
				item.Lee = varLee;
			
				item.Escribe = varEscribe;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCurriculumIdiomasColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdiomaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LeeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EscribeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCurriculumIdiomas = @"id_curriculum_idiomas";
			 public static string IdLegajo = @"id_legajo";
			 public static string Idioma = @"idioma";
			 public static string Lee = @"lee";
			 public static string Escribe = @"escribe";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
