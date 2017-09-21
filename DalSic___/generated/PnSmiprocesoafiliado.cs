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
	/// Strongly-typed collection for the PnSmiprocesoafiliado class.
	/// </summary>
    [Serializable]
	public partial class PnSmiprocesoafiliadoCollection : ActiveList<PnSmiprocesoafiliado, PnSmiprocesoafiliadoCollection>
	{	   
		public PnSmiprocesoafiliadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSmiprocesoafiliadoCollection</returns>
		public PnSmiprocesoafiliadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSmiprocesoafiliado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_smiprocesoafiliados table.
	/// </summary>
	[Serializable]
	public partial class PnSmiprocesoafiliado : ActiveRecord<PnSmiprocesoafiliado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSmiprocesoafiliado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSmiprocesoafiliado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSmiprocesoafiliado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSmiprocesoafiliado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_smiprocesoafiliados", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProcafiliado = new TableSchema.TableColumn(schema);
				colvarIdProcafiliado.ColumnName = "id_procafiliado";
				colvarIdProcafiliado.DataType = DbType.Int32;
				colvarIdProcafiliado.MaxLength = 0;
				colvarIdProcafiliado.AutoIncrement = true;
				colvarIdProcafiliado.IsNullable = false;
				colvarIdProcafiliado.IsPrimaryKey = true;
				colvarIdProcafiliado.IsForeignKey = false;
				colvarIdProcafiliado.IsReadOnly = false;
				colvarIdProcafiliado.DefaultSetting = @"";
				colvarIdProcafiliado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProcafiliado);
				
				TableSchema.TableColumn colvarPeriodo = new TableSchema.TableColumn(schema);
				colvarPeriodo.ColumnName = "periodo";
				colvarPeriodo.DataType = DbType.AnsiString;
				colvarPeriodo.MaxLength = -1;
				colvarPeriodo.AutoIncrement = false;
				colvarPeriodo.IsNullable = true;
				colvarPeriodo.IsPrimaryKey = false;
				colvarPeriodo.IsForeignKey = false;
				colvarPeriodo.IsReadOnly = false;
				colvarPeriodo.DefaultSetting = @"";
				colvarPeriodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodo);
				
				TableSchema.TableColumn colvarCodigocialtadatos = new TableSchema.TableColumn(schema);
				colvarCodigocialtadatos.ColumnName = "codigocialtadatos";
				colvarCodigocialtadatos.DataType = DbType.AnsiString;
				colvarCodigocialtadatos.MaxLength = -1;
				colvarCodigocialtadatos.AutoIncrement = false;
				colvarCodigocialtadatos.IsNullable = true;
				colvarCodigocialtadatos.IsPrimaryKey = false;
				colvarCodigocialtadatos.IsForeignKey = false;
				colvarCodigocialtadatos.IsReadOnly = false;
				colvarCodigocialtadatos.DefaultSetting = @"";
				colvarCodigocialtadatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigocialtadatos);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_smiprocesoafiliados",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProcafiliado")]
		[Bindable(true)]
		public int IdProcafiliado 
		{
			get { return GetColumnValue<int>(Columns.IdProcafiliado); }
			set { SetColumnValue(Columns.IdProcafiliado, value); }
		}
		  
		[XmlAttribute("Periodo")]
		[Bindable(true)]
		public string Periodo 
		{
			get { return GetColumnValue<string>(Columns.Periodo); }
			set { SetColumnValue(Columns.Periodo, value); }
		}
		  
		[XmlAttribute("Codigocialtadatos")]
		[Bindable(true)]
		public string Codigocialtadatos 
		{
			get { return GetColumnValue<string>(Columns.Codigocialtadatos); }
			set { SetColumnValue(Columns.Codigocialtadatos, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varPeriodo,string varCodigocialtadatos)
		{
			PnSmiprocesoafiliado item = new PnSmiprocesoafiliado();
			
			item.Periodo = varPeriodo;
			
			item.Codigocialtadatos = varCodigocialtadatos;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdProcafiliado,string varPeriodo,string varCodigocialtadatos)
		{
			PnSmiprocesoafiliado item = new PnSmiprocesoafiliado();
			
				item.IdProcafiliado = varIdProcafiliado;
			
				item.Periodo = varPeriodo;
			
				item.Codigocialtadatos = varCodigocialtadatos;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProcafiliadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigocialtadatosColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProcafiliado = @"id_procafiliado";
			 public static string Periodo = @"periodo";
			 public static string Codigocialtadatos = @"codigocialtadatos";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
