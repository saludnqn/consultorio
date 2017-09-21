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
	/// Strongly-typed collection for the PnReporteHipoacustium class.
	/// </summary>
    [Serializable]
	public partial class PnReporteHipoacustiumCollection : ActiveList<PnReporteHipoacustium, PnReporteHipoacustiumCollection>
	{	   
		public PnReporteHipoacustiumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnReporteHipoacustiumCollection</returns>
		public PnReporteHipoacustiumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnReporteHipoacustium o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_reporte_hipoacustia table.
	/// </summary>
	[Serializable]
	public partial class PnReporteHipoacustium : ActiveRecord<PnReporteHipoacustium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnReporteHipoacustium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnReporteHipoacustium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnReporteHipoacustium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnReporteHipoacustium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_reporte_hipoacustia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdReporteHipoacustia = new TableSchema.TableColumn(schema);
				colvarIdReporteHipoacustia.ColumnName = "id_reporte_hipoacustia";
				colvarIdReporteHipoacustia.DataType = DbType.Int32;
				colvarIdReporteHipoacustia.MaxLength = 0;
				colvarIdReporteHipoacustia.AutoIncrement = true;
				colvarIdReporteHipoacustia.IsNullable = false;
				colvarIdReporteHipoacustia.IsPrimaryKey = true;
				colvarIdReporteHipoacustia.IsForeignKey = false;
				colvarIdReporteHipoacustia.IsReadOnly = false;
				colvarIdReporteHipoacustia.DefaultSetting = @"";
				colvarIdReporteHipoacustia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdReporteHipoacustia);
				
				TableSchema.TableColumn colvarIdPrestacion = new TableSchema.TableColumn(schema);
				colvarIdPrestacion.ColumnName = "id_prestacion";
				colvarIdPrestacion.DataType = DbType.Int32;
				colvarIdPrestacion.MaxLength = 0;
				colvarIdPrestacion.AutoIncrement = false;
				colvarIdPrestacion.IsNullable = false;
				colvarIdPrestacion.IsPrimaryKey = false;
				colvarIdPrestacion.IsForeignKey = false;
				colvarIdPrestacion.IsReadOnly = false;
				colvarIdPrestacion.DefaultSetting = @"";
				colvarIdPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrestacion);
				
				TableSchema.TableColumn colvarOidoD = new TableSchema.TableColumn(schema);
				colvarOidoD.ColumnName = "oido_d";
				colvarOidoD.DataType = DbType.AnsiString;
				colvarOidoD.MaxLength = 100;
				colvarOidoD.AutoIncrement = false;
				colvarOidoD.IsNullable = true;
				colvarOidoD.IsPrimaryKey = false;
				colvarOidoD.IsForeignKey = false;
				colvarOidoD.IsReadOnly = false;
				colvarOidoD.DefaultSetting = @"";
				colvarOidoD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOidoD);
				
				TableSchema.TableColumn colvarOidoI = new TableSchema.TableColumn(schema);
				colvarOidoI.ColumnName = "oido_i";
				colvarOidoI.DataType = DbType.AnsiString;
				colvarOidoI.MaxLength = 100;
				colvarOidoI.AutoIncrement = false;
				colvarOidoI.IsNullable = true;
				colvarOidoI.IsPrimaryKey = false;
				colvarOidoI.IsForeignKey = false;
				colvarOidoI.IsReadOnly = false;
				colvarOidoI.DefaultSetting = @"";
				colvarOidoI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOidoI);
				
				TableSchema.TableColumn colvarGradoHipo = new TableSchema.TableColumn(schema);
				colvarGradoHipo.ColumnName = "grado_hipo";
				colvarGradoHipo.DataType = DbType.AnsiString;
				colvarGradoHipo.MaxLength = 100;
				colvarGradoHipo.AutoIncrement = false;
				colvarGradoHipo.IsNullable = true;
				colvarGradoHipo.IsPrimaryKey = false;
				colvarGradoHipo.IsForeignKey = false;
				colvarGradoHipo.IsReadOnly = false;
				colvarGradoHipo.DefaultSetting = @"";
				colvarGradoHipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGradoHipo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_reporte_hipoacustia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdReporteHipoacustia")]
		[Bindable(true)]
		public int IdReporteHipoacustia 
		{
			get { return GetColumnValue<int>(Columns.IdReporteHipoacustia); }
			set { SetColumnValue(Columns.IdReporteHipoacustia, value); }
		}
		  
		[XmlAttribute("IdPrestacion")]
		[Bindable(true)]
		public int IdPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdPrestacion); }
			set { SetColumnValue(Columns.IdPrestacion, value); }
		}
		  
		[XmlAttribute("OidoD")]
		[Bindable(true)]
		public string OidoD 
		{
			get { return GetColumnValue<string>(Columns.OidoD); }
			set { SetColumnValue(Columns.OidoD, value); }
		}
		  
		[XmlAttribute("OidoI")]
		[Bindable(true)]
		public string OidoI 
		{
			get { return GetColumnValue<string>(Columns.OidoI); }
			set { SetColumnValue(Columns.OidoI, value); }
		}
		  
		[XmlAttribute("GradoHipo")]
		[Bindable(true)]
		public string GradoHipo 
		{
			get { return GetColumnValue<string>(Columns.GradoHipo); }
			set { SetColumnValue(Columns.GradoHipo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPrestacion,string varOidoD,string varOidoI,string varGradoHipo)
		{
			PnReporteHipoacustium item = new PnReporteHipoacustium();
			
			item.IdPrestacion = varIdPrestacion;
			
			item.OidoD = varOidoD;
			
			item.OidoI = varOidoI;
			
			item.GradoHipo = varGradoHipo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdReporteHipoacustia,int varIdPrestacion,string varOidoD,string varOidoI,string varGradoHipo)
		{
			PnReporteHipoacustium item = new PnReporteHipoacustium();
			
				item.IdReporteHipoacustia = varIdReporteHipoacustia;
			
				item.IdPrestacion = varIdPrestacion;
			
				item.OidoD = varOidoD;
			
				item.OidoI = varOidoI;
			
				item.GradoHipo = varGradoHipo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdReporteHipoacustiaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPrestacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OidoDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn OidoIColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn GradoHipoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdReporteHipoacustia = @"id_reporte_hipoacustia";
			 public static string IdPrestacion = @"id_prestacion";
			 public static string OidoD = @"oido_d";
			 public static string OidoI = @"oido_i";
			 public static string GradoHipo = @"grado_hipo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
