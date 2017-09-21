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
	/// Strongly-typed collection for the PnRelPrestacionXDatoReportable class.
	/// </summary>
    [Serializable]
	public partial class PnRelPrestacionXDatoReportableCollection : ActiveList<PnRelPrestacionXDatoReportable, PnRelPrestacionXDatoReportableCollection>
	{	   
		public PnRelPrestacionXDatoReportableCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnRelPrestacionXDatoReportableCollection</returns>
		public PnRelPrestacionXDatoReportableCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnRelPrestacionXDatoReportable o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_Rel_PrestacionXDatoReportable table.
	/// </summary>
	[Serializable]
	public partial class PnRelPrestacionXDatoReportable : ActiveRecord<PnRelPrestacionXDatoReportable>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnRelPrestacionXDatoReportable()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnRelPrestacionXDatoReportable(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnRelPrestacionXDatoReportable(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnRelPrestacionXDatoReportable(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_Rel_PrestacionXDatoReportable", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPrestacionXDatoReportable = new TableSchema.TableColumn(schema);
				colvarIdPrestacionXDatoReportable.ColumnName = "idPrestacionXDatoReportable";
				colvarIdPrestacionXDatoReportable.DataType = DbType.Int32;
				colvarIdPrestacionXDatoReportable.MaxLength = 0;
				colvarIdPrestacionXDatoReportable.AutoIncrement = true;
				colvarIdPrestacionXDatoReportable.IsNullable = false;
				colvarIdPrestacionXDatoReportable.IsPrimaryKey = true;
				colvarIdPrestacionXDatoReportable.IsForeignKey = false;
				colvarIdPrestacionXDatoReportable.IsReadOnly = false;
				colvarIdPrestacionXDatoReportable.DefaultSetting = @"";
				colvarIdPrestacionXDatoReportable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrestacionXDatoReportable);
				
				TableSchema.TableColumn colvarIdPrestacion = new TableSchema.TableColumn(schema);
				colvarIdPrestacion.ColumnName = "idPrestacion";
				colvarIdPrestacion.DataType = DbType.Int32;
				colvarIdPrestacion.MaxLength = 0;
				colvarIdPrestacion.AutoIncrement = false;
				colvarIdPrestacion.IsNullable = true;
				colvarIdPrestacion.IsPrimaryKey = false;
				colvarIdPrestacion.IsForeignKey = true;
				colvarIdPrestacion.IsReadOnly = false;
				colvarIdPrestacion.DefaultSetting = @"";
				
					colvarIdPrestacion.ForeignKeyTableName = "PN_prestacion";
				schema.Columns.Add(colvarIdPrestacion);
				
				TableSchema.TableColumn colvarIdDatoReportable = new TableSchema.TableColumn(schema);
				colvarIdDatoReportable.ColumnName = "idDatoReportable";
				colvarIdDatoReportable.DataType = DbType.Int32;
				colvarIdDatoReportable.MaxLength = 0;
				colvarIdDatoReportable.AutoIncrement = false;
				colvarIdDatoReportable.IsNullable = true;
				colvarIdDatoReportable.IsPrimaryKey = false;
				colvarIdDatoReportable.IsForeignKey = true;
				colvarIdDatoReportable.IsReadOnly = false;
				colvarIdDatoReportable.DefaultSetting = @"";
				
					colvarIdDatoReportable.ForeignKeyTableName = "PN_datos_reportables";
				schema.Columns.Add(colvarIdDatoReportable);
				
				TableSchema.TableColumn colvarValor = new TableSchema.TableColumn(schema);
				colvarValor.ColumnName = "valor";
				colvarValor.DataType = DbType.AnsiString;
				colvarValor.MaxLength = 30;
				colvarValor.AutoIncrement = false;
				colvarValor.IsNullable = true;
				colvarValor.IsPrimaryKey = false;
				colvarValor.IsForeignKey = false;
				colvarValor.IsReadOnly = false;
				colvarValor.DefaultSetting = @"";
				colvarValor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValor);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_Rel_PrestacionXDatoReportable",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPrestacionXDatoReportable")]
		[Bindable(true)]
		public int IdPrestacionXDatoReportable 
		{
			get { return GetColumnValue<int>(Columns.IdPrestacionXDatoReportable); }
			set { SetColumnValue(Columns.IdPrestacionXDatoReportable, value); }
		}
		  
		[XmlAttribute("IdPrestacion")]
		[Bindable(true)]
		public int? IdPrestacion 
		{
			get { return GetColumnValue<int?>(Columns.IdPrestacion); }
			set { SetColumnValue(Columns.IdPrestacion, value); }
		}
		  
		[XmlAttribute("IdDatoReportable")]
		[Bindable(true)]
		public int? IdDatoReportable 
		{
			get { return GetColumnValue<int?>(Columns.IdDatoReportable); }
			set { SetColumnValue(Columns.IdDatoReportable, value); }
		}
		  
		[XmlAttribute("Valor")]
		[Bindable(true)]
		public string Valor 
		{
			get { return GetColumnValue<string>(Columns.Valor); }
			set { SetColumnValue(Columns.Valor, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnDatosReportable ActiveRecord object related to this PnRelPrestacionXDatoReportable
		/// 
		/// </summary>
		public DalSic.PnDatosReportable PnDatosReportable
		{
			get { return DalSic.PnDatosReportable.FetchByID(this.IdDatoReportable); }
			set { SetColumnValue("idDatoReportable", value.IdDatoReportable); }
		}
		
		
		/// <summary>
		/// Returns a PnPrestacion ActiveRecord object related to this PnRelPrestacionXDatoReportable
		/// 
		/// </summary>
		public DalSic.PnPrestacion PnPrestacion
		{
			get { return DalSic.PnPrestacion.FetchByID(this.IdPrestacion); }
			set { SetColumnValue("idPrestacion", value.IdPrestacion); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdPrestacion,int? varIdDatoReportable,string varValor)
		{
			PnRelPrestacionXDatoReportable item = new PnRelPrestacionXDatoReportable();
			
			item.IdPrestacion = varIdPrestacion;
			
			item.IdDatoReportable = varIdDatoReportable;
			
			item.Valor = varValor;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPrestacionXDatoReportable,int? varIdPrestacion,int? varIdDatoReportable,string varValor)
		{
			PnRelPrestacionXDatoReportable item = new PnRelPrestacionXDatoReportable();
			
				item.IdPrestacionXDatoReportable = varIdPrestacionXDatoReportable;
			
				item.IdPrestacion = varIdPrestacion;
			
				item.IdDatoReportable = varIdDatoReportable;
			
				item.Valor = varValor;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPrestacionXDatoReportableColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPrestacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDatoReportableColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPrestacionXDatoReportable = @"idPrestacionXDatoReportable";
			 public static string IdPrestacion = @"idPrestacion";
			 public static string IdDatoReportable = @"idDatoReportable";
			 public static string Valor = @"valor";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
