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
	/// Strongly-typed collection for the PnEnfermedade class.
	/// </summary>
    [Serializable]
	public partial class PnEnfermedadeCollection : ActiveList<PnEnfermedade, PnEnfermedadeCollection>
	{	   
		public PnEnfermedadeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEnfermedadeCollection</returns>
		public PnEnfermedadeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEnfermedade o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_enfermedades table.
	/// </summary>
	[Serializable]
	public partial class PnEnfermedade : ActiveRecord<PnEnfermedade>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEnfermedade()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEnfermedade(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEnfermedade(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEnfermedade(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_enfermedades", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
				colvarDiagnostico.ColumnName = "diagnostico";
				colvarDiagnostico.DataType = DbType.AnsiString;
				colvarDiagnostico.MaxLength = -1;
				colvarDiagnostico.AutoIncrement = false;
				colvarDiagnostico.IsNullable = false;
				colvarDiagnostico.IsPrimaryKey = false;
				colvarDiagnostico.IsForeignKey = false;
				colvarDiagnostico.IsReadOnly = false;
				colvarDiagnostico.DefaultSetting = @"";
				colvarDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnostico);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_enfermedades",schema);
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
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Diagnostico")]
		[Bindable(true)]
		public string Diagnostico 
		{
			get { return GetColumnValue<string>(Columns.Diagnostico); }
			set { SetColumnValue(Columns.Diagnostico, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varFecha,string varDiagnostico)
		{
			PnEnfermedade item = new PnEnfermedade();
			
			item.Fecha = varFecha;
			
			item.Diagnostico = varDiagnostico;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLegajo,DateTime varFecha,string varDiagnostico)
		{
			PnEnfermedade item = new PnEnfermedade();
			
				item.IdLegajo = varIdLegajo;
			
				item.Fecha = varFecha;
			
				item.Diagnostico = varDiagnostico;
			
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
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLegajo = @"id_legajo";
			 public static string Fecha = @"fecha";
			 public static string Diagnostico = @"diagnostico";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
