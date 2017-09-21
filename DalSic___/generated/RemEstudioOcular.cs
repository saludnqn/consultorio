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
	/// Strongly-typed collection for the RemEstudioOcular class.
	/// </summary>
    [Serializable]
	public partial class RemEstudioOcularCollection : ActiveList<RemEstudioOcular, RemEstudioOcularCollection>
	{	   
		public RemEstudioOcularCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemEstudioOcularCollection</returns>
		public RemEstudioOcularCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemEstudioOcular o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_EstudioOcular table.
	/// </summary>
	[Serializable]
	public partial class RemEstudioOcular : ActiveRecord<RemEstudioOcular>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemEstudioOcular()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemEstudioOcular(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemEstudioOcular(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemEstudioOcular(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_EstudioOcular", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioOcular = new TableSchema.TableColumn(schema);
				colvarIdEstudioOcular.ColumnName = "idEstudioOcular";
				colvarIdEstudioOcular.DataType = DbType.Int32;
				colvarIdEstudioOcular.MaxLength = 0;
				colvarIdEstudioOcular.AutoIncrement = true;
				colvarIdEstudioOcular.IsNullable = false;
				colvarIdEstudioOcular.IsPrimaryKey = true;
				colvarIdEstudioOcular.IsForeignKey = false;
				colvarIdEstudioOcular.IsReadOnly = false;
				colvarIdEstudioOcular.DefaultSetting = @"";
				colvarIdEstudioOcular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioOcular);
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "idClasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = false;
				colvarIdClasificacion.IsNullable = false;
				colvarIdClasificacion.IsPrimaryKey = false;
				colvarIdClasificacion.IsForeignKey = true;
				colvarIdClasificacion.IsReadOnly = false;
				colvarIdClasificacion.DefaultSetting = @"";
				
					colvarIdClasificacion.ForeignKeyTableName = "Rem_Clasificacion";
				schema.Columns.Add(colvarIdClasificacion);
				
				TableSchema.TableColumn colvarOIRpHipertensiva = new TableSchema.TableColumn(schema);
				colvarOIRpHipertensiva.ColumnName = "OIRpHipertensiva";
				colvarOIRpHipertensiva.DataType = DbType.Boolean;
				colvarOIRpHipertensiva.MaxLength = 0;
				colvarOIRpHipertensiva.AutoIncrement = false;
				colvarOIRpHipertensiva.IsNullable = false;
				colvarOIRpHipertensiva.IsPrimaryKey = false;
				colvarOIRpHipertensiva.IsForeignKey = false;
				colvarOIRpHipertensiva.IsReadOnly = false;
				
						colvarOIRpHipertensiva.DefaultSetting = @"((0))";
				colvarOIRpHipertensiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOIRpHipertensiva);
				
				TableSchema.TableColumn colvarOIRpDNoProliferativo = new TableSchema.TableColumn(schema);
				colvarOIRpDNoProliferativo.ColumnName = "OIRpDNoProliferativo";
				colvarOIRpDNoProliferativo.DataType = DbType.Boolean;
				colvarOIRpDNoProliferativo.MaxLength = 0;
				colvarOIRpDNoProliferativo.AutoIncrement = false;
				colvarOIRpDNoProliferativo.IsNullable = false;
				colvarOIRpDNoProliferativo.IsPrimaryKey = false;
				colvarOIRpDNoProliferativo.IsForeignKey = false;
				colvarOIRpDNoProliferativo.IsReadOnly = false;
				
						colvarOIRpDNoProliferativo.DefaultSetting = @"((0))";
				colvarOIRpDNoProliferativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOIRpDNoProliferativo);
				
				TableSchema.TableColumn colvarOIRpDProliferativo = new TableSchema.TableColumn(schema);
				colvarOIRpDProliferativo.ColumnName = "OIRpDProliferativo";
				colvarOIRpDProliferativo.DataType = DbType.Boolean;
				colvarOIRpDProliferativo.MaxLength = 0;
				colvarOIRpDProliferativo.AutoIncrement = false;
				colvarOIRpDProliferativo.IsNullable = false;
				colvarOIRpDProliferativo.IsPrimaryKey = false;
				colvarOIRpDProliferativo.IsForeignKey = false;
				colvarOIRpDProliferativo.IsReadOnly = false;
				
						colvarOIRpDProliferativo.DefaultSetting = @"((0))";
				colvarOIRpDProliferativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOIRpDProliferativo);
				
				TableSchema.TableColumn colvarOIRpDRetina = new TableSchema.TableColumn(schema);
				colvarOIRpDRetina.ColumnName = "OIRpDRetina";
				colvarOIRpDRetina.DataType = DbType.Boolean;
				colvarOIRpDRetina.MaxLength = 0;
				colvarOIRpDRetina.AutoIncrement = false;
				colvarOIRpDRetina.IsNullable = false;
				colvarOIRpDRetina.IsPrimaryKey = false;
				colvarOIRpDRetina.IsForeignKey = false;
				colvarOIRpDRetina.IsReadOnly = false;
				
						colvarOIRpDRetina.DefaultSetting = @"((0))";
				colvarOIRpDRetina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOIRpDRetina);
				
				TableSchema.TableColumn colvarODRpHipertensiva = new TableSchema.TableColumn(schema);
				colvarODRpHipertensiva.ColumnName = "ODRpHipertensiva";
				colvarODRpHipertensiva.DataType = DbType.Boolean;
				colvarODRpHipertensiva.MaxLength = 0;
				colvarODRpHipertensiva.AutoIncrement = false;
				colvarODRpHipertensiva.IsNullable = false;
				colvarODRpHipertensiva.IsPrimaryKey = false;
				colvarODRpHipertensiva.IsForeignKey = false;
				colvarODRpHipertensiva.IsReadOnly = false;
				
						colvarODRpHipertensiva.DefaultSetting = @"((0))";
				colvarODRpHipertensiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarODRpHipertensiva);
				
				TableSchema.TableColumn colvarODRpDNoProliferativo = new TableSchema.TableColumn(schema);
				colvarODRpDNoProliferativo.ColumnName = "ODRpDNoProliferativo";
				colvarODRpDNoProliferativo.DataType = DbType.Boolean;
				colvarODRpDNoProliferativo.MaxLength = 0;
				colvarODRpDNoProliferativo.AutoIncrement = false;
				colvarODRpDNoProliferativo.IsNullable = false;
				colvarODRpDNoProliferativo.IsPrimaryKey = false;
				colvarODRpDNoProliferativo.IsForeignKey = false;
				colvarODRpDNoProliferativo.IsReadOnly = false;
				
						colvarODRpDNoProliferativo.DefaultSetting = @"((0))";
				colvarODRpDNoProliferativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarODRpDNoProliferativo);
				
				TableSchema.TableColumn colvarODRpDProliferativo = new TableSchema.TableColumn(schema);
				colvarODRpDProliferativo.ColumnName = "ODRpDProliferativo";
				colvarODRpDProliferativo.DataType = DbType.Boolean;
				colvarODRpDProliferativo.MaxLength = 0;
				colvarODRpDProliferativo.AutoIncrement = false;
				colvarODRpDProliferativo.IsNullable = false;
				colvarODRpDProliferativo.IsPrimaryKey = false;
				colvarODRpDProliferativo.IsForeignKey = false;
				colvarODRpDProliferativo.IsReadOnly = false;
				
						colvarODRpDProliferativo.DefaultSetting = @"((0))";
				colvarODRpDProliferativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarODRpDProliferativo);
				
				TableSchema.TableColumn colvarODRpDRetina = new TableSchema.TableColumn(schema);
				colvarODRpDRetina.ColumnName = "ODRpDRetina";
				colvarODRpDRetina.DataType = DbType.Boolean;
				colvarODRpDRetina.MaxLength = 0;
				colvarODRpDRetina.AutoIncrement = false;
				colvarODRpDRetina.IsNullable = false;
				colvarODRpDRetina.IsPrimaryKey = false;
				colvarODRpDRetina.IsForeignKey = false;
				colvarODRpDRetina.IsReadOnly = false;
				
						colvarODRpDRetina.DefaultSetting = @"((0))";
				colvarODRpDRetina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarODRpDRetina);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_EstudioOcular",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioOcular")]
		[Bindable(true)]
		public int IdEstudioOcular 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioOcular); }
			set { SetColumnValue(Columns.IdEstudioOcular, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int IdClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		  
		[XmlAttribute("OIRpHipertensiva")]
		[Bindable(true)]
		public bool OIRpHipertensiva 
		{
			get { return GetColumnValue<bool>(Columns.OIRpHipertensiva); }
			set { SetColumnValue(Columns.OIRpHipertensiva, value); }
		}
		  
		[XmlAttribute("OIRpDNoProliferativo")]
		[Bindable(true)]
		public bool OIRpDNoProliferativo 
		{
			get { return GetColumnValue<bool>(Columns.OIRpDNoProliferativo); }
			set { SetColumnValue(Columns.OIRpDNoProliferativo, value); }
		}
		  
		[XmlAttribute("OIRpDProliferativo")]
		[Bindable(true)]
		public bool OIRpDProliferativo 
		{
			get { return GetColumnValue<bool>(Columns.OIRpDProliferativo); }
			set { SetColumnValue(Columns.OIRpDProliferativo, value); }
		}
		  
		[XmlAttribute("OIRpDRetina")]
		[Bindable(true)]
		public bool OIRpDRetina 
		{
			get { return GetColumnValue<bool>(Columns.OIRpDRetina); }
			set { SetColumnValue(Columns.OIRpDRetina, value); }
		}
		  
		[XmlAttribute("ODRpHipertensiva")]
		[Bindable(true)]
		public bool ODRpHipertensiva 
		{
			get { return GetColumnValue<bool>(Columns.ODRpHipertensiva); }
			set { SetColumnValue(Columns.ODRpHipertensiva, value); }
		}
		  
		[XmlAttribute("ODRpDNoProliferativo")]
		[Bindable(true)]
		public bool ODRpDNoProliferativo 
		{
			get { return GetColumnValue<bool>(Columns.ODRpDNoProliferativo); }
			set { SetColumnValue(Columns.ODRpDNoProliferativo, value); }
		}
		  
		[XmlAttribute("ODRpDProliferativo")]
		[Bindable(true)]
		public bool ODRpDProliferativo 
		{
			get { return GetColumnValue<bool>(Columns.ODRpDProliferativo); }
			set { SetColumnValue(Columns.ODRpDProliferativo, value); }
		}
		  
		[XmlAttribute("ODRpDRetina")]
		[Bindable(true)]
		public bool ODRpDRetina 
		{
			get { return GetColumnValue<bool>(Columns.ODRpDRetina); }
			set { SetColumnValue(Columns.ODRpDRetina, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a RemClasificacion ActiveRecord object related to this RemEstudioOcular
		/// 
		/// </summary>
		public DalSic.RemClasificacion RemClasificacion
		{
			get { return DalSic.RemClasificacion.FetchByID(this.IdClasificacion); }
			set { SetColumnValue("idClasificacion", value.IdClasificacion); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdClasificacion,bool varOIRpHipertensiva,bool varOIRpDNoProliferativo,bool varOIRpDProliferativo,bool varOIRpDRetina,bool varODRpHipertensiva,bool varODRpDNoProliferativo,bool varODRpDProliferativo,bool varODRpDRetina)
		{
			RemEstudioOcular item = new RemEstudioOcular();
			
			item.IdClasificacion = varIdClasificacion;
			
			item.OIRpHipertensiva = varOIRpHipertensiva;
			
			item.OIRpDNoProliferativo = varOIRpDNoProliferativo;
			
			item.OIRpDProliferativo = varOIRpDProliferativo;
			
			item.OIRpDRetina = varOIRpDRetina;
			
			item.ODRpHipertensiva = varODRpHipertensiva;
			
			item.ODRpDNoProliferativo = varODRpDNoProliferativo;
			
			item.ODRpDProliferativo = varODRpDProliferativo;
			
			item.ODRpDRetina = varODRpDRetina;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioOcular,int varIdClasificacion,bool varOIRpHipertensiva,bool varOIRpDNoProliferativo,bool varOIRpDProliferativo,bool varOIRpDRetina,bool varODRpHipertensiva,bool varODRpDNoProliferativo,bool varODRpDProliferativo,bool varODRpDRetina)
		{
			RemEstudioOcular item = new RemEstudioOcular();
			
				item.IdEstudioOcular = varIdEstudioOcular;
			
				item.IdClasificacion = varIdClasificacion;
			
				item.OIRpHipertensiva = varOIRpHipertensiva;
			
				item.OIRpDNoProliferativo = varOIRpDNoProliferativo;
			
				item.OIRpDProliferativo = varOIRpDProliferativo;
			
				item.OIRpDRetina = varOIRpDRetina;
			
				item.ODRpHipertensiva = varODRpHipertensiva;
			
				item.ODRpDNoProliferativo = varODRpDNoProliferativo;
			
				item.ODRpDProliferativo = varODRpDProliferativo;
			
				item.ODRpDRetina = varODRpDRetina;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioOcularColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OIRpHipertensivaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn OIRpDNoProliferativoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn OIRpDProliferativoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn OIRpDRetinaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ODRpHipertensivaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ODRpDNoProliferativoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ODRpDProliferativoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ODRpDRetinaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioOcular = @"idEstudioOcular";
			 public static string IdClasificacion = @"idClasificacion";
			 public static string OIRpHipertensiva = @"OIRpHipertensiva";
			 public static string OIRpDNoProliferativo = @"OIRpDNoProliferativo";
			 public static string OIRpDProliferativo = @"OIRpDProliferativo";
			 public static string OIRpDRetina = @"OIRpDRetina";
			 public static string ODRpHipertensiva = @"ODRpHipertensiva";
			 public static string ODRpDNoProliferativo = @"ODRpDNoProliferativo";
			 public static string ODRpDProliferativo = @"ODRpDProliferativo";
			 public static string ODRpDRetina = @"ODRpDRetina";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
