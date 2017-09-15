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
	/// Strongly-typed collection for the PnSumariosPersonal class.
	/// </summary>
    [Serializable]
	public partial class PnSumariosPersonalCollection : ActiveList<PnSumariosPersonal, PnSumariosPersonalCollection>
	{	   
		public PnSumariosPersonalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSumariosPersonalCollection</returns>
		public PnSumariosPersonalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSumariosPersonal o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_sumarios_personal table.
	/// </summary>
	[Serializable]
	public partial class PnSumariosPersonal : ActiveRecord<PnSumariosPersonal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSumariosPersonal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSumariosPersonal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSumariosPersonal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSumariosPersonal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_sumarios_personal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSumarioPersonal = new TableSchema.TableColumn(schema);
				colvarIdSumarioPersonal.ColumnName = "id_sumario_personal";
				colvarIdSumarioPersonal.DataType = DbType.Int32;
				colvarIdSumarioPersonal.MaxLength = 0;
				colvarIdSumarioPersonal.AutoIncrement = true;
				colvarIdSumarioPersonal.IsNullable = false;
				colvarIdSumarioPersonal.IsPrimaryKey = true;
				colvarIdSumarioPersonal.IsForeignKey = false;
				colvarIdSumarioPersonal.IsReadOnly = false;
				colvarIdSumarioPersonal.DefaultSetting = @"";
				colvarIdSumarioPersonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSumarioPersonal);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarTitulo = new TableSchema.TableColumn(schema);
				colvarTitulo.ColumnName = "titulo";
				colvarTitulo.DataType = DbType.AnsiString;
				colvarTitulo.MaxLength = -1;
				colvarTitulo.AutoIncrement = false;
				colvarTitulo.IsNullable = true;
				colvarTitulo.IsPrimaryKey = false;
				colvarTitulo.IsForeignKey = false;
				colvarTitulo.IsReadOnly = false;
				colvarTitulo.DefaultSetting = @"";
				colvarTitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitulo);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_sumarios_personal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSumarioPersonal")]
		[Bindable(true)]
		public int IdSumarioPersonal 
		{
			get { return GetColumnValue<int>(Columns.IdSumarioPersonal); }
			set { SetColumnValue(Columns.IdSumarioPersonal, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Titulo")]
		[Bindable(true)]
		public string Titulo 
		{
			get { return GetColumnValue<string>(Columns.Titulo); }
			set { SetColumnValue(Columns.Titulo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime? varFecha,string varTitulo,string varDescripcion,int varIdLegajo)
		{
			PnSumariosPersonal item = new PnSumariosPersonal();
			
			item.Fecha = varFecha;
			
			item.Titulo = varTitulo;
			
			item.Descripcion = varDescripcion;
			
			item.IdLegajo = varIdLegajo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSumarioPersonal,DateTime? varFecha,string varTitulo,string varDescripcion,int varIdLegajo)
		{
			PnSumariosPersonal item = new PnSumariosPersonal();
			
				item.IdSumarioPersonal = varIdSumarioPersonal;
			
				item.Fecha = varFecha;
			
				item.Titulo = varTitulo;
			
				item.Descripcion = varDescripcion;
			
				item.IdLegajo = varIdLegajo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSumarioPersonalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TituloColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSumarioPersonal = @"id_sumario_personal";
			 public static string Fecha = @"fecha";
			 public static string Titulo = @"titulo";
			 public static string Descripcion = @"descripcion";
			 public static string IdLegajo = @"id_legajo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
