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
	/// Strongly-typed collection for the PnParametro class.
	/// </summary>
    [Serializable]
	public partial class PnParametroCollection : ActiveList<PnParametro, PnParametroCollection>
	{	   
		public PnParametroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnParametroCollection</returns>
		public PnParametroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnParametro o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_parametros table.
	/// </summary>
	[Serializable]
	public partial class PnParametro : ActiveRecord<PnParametro>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnParametro()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnParametro(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnParametro(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnParametro(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_parametros", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarParametro = new TableSchema.TableColumn(schema);
				colvarParametro.ColumnName = "parametro";
				colvarParametro.DataType = DbType.AnsiString;
				colvarParametro.MaxLength = -1;
				colvarParametro.AutoIncrement = false;
				colvarParametro.IsNullable = true;
				colvarParametro.IsPrimaryKey = false;
				colvarParametro.IsForeignKey = false;
				colvarParametro.IsReadOnly = false;
				colvarParametro.DefaultSetting = @"";
				colvarParametro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParametro);
				
				TableSchema.TableColumn colvarValor = new TableSchema.TableColumn(schema);
				colvarValor.ColumnName = "valor";
				colvarValor.DataType = DbType.AnsiString;
				colvarValor.MaxLength = -1;
				colvarValor.AutoIncrement = false;
				colvarValor.IsNullable = true;
				colvarValor.IsPrimaryKey = false;
				colvarValor.IsForeignKey = false;
				colvarValor.IsReadOnly = false;
				colvarValor.DefaultSetting = @"";
				colvarValor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValor);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = -1;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarIdParametro = new TableSchema.TableColumn(schema);
				colvarIdParametro.ColumnName = "id_parametro";
				colvarIdParametro.DataType = DbType.Int32;
				colvarIdParametro.MaxLength = 0;
				colvarIdParametro.AutoIncrement = true;
				colvarIdParametro.IsNullable = false;
				colvarIdParametro.IsPrimaryKey = true;
				colvarIdParametro.IsForeignKey = false;
				colvarIdParametro.IsReadOnly = false;
				colvarIdParametro.DefaultSetting = @"";
				colvarIdParametro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdParametro);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_parametros",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Parametro")]
		[Bindable(true)]
		public string Parametro 
		{
			get { return GetColumnValue<string>(Columns.Parametro); }
			set { SetColumnValue(Columns.Parametro, value); }
		}
		  
		[XmlAttribute("Valor")]
		[Bindable(true)]
		public string Valor 
		{
			get { return GetColumnValue<string>(Columns.Valor); }
			set { SetColumnValue(Columns.Valor, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("IdParametro")]
		[Bindable(true)]
		public int IdParametro 
		{
			get { return GetColumnValue<int>(Columns.IdParametro); }
			set { SetColumnValue(Columns.IdParametro, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varParametro,string varValor,string varComentario)
		{
			PnParametro item = new PnParametro();
			
			item.Parametro = varParametro;
			
			item.Valor = varValor;
			
			item.Comentario = varComentario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varParametro,string varValor,string varComentario,int varIdParametro)
		{
			PnParametro item = new PnParametro();
			
				item.Parametro = varParametro;
			
				item.Valor = varValor;
			
				item.Comentario = varComentario;
			
				item.IdParametro = varIdParametro;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ParametroColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdParametroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Parametro = @"parametro";
			 public static string Valor = @"valor";
			 public static string Comentario = @"comentario";
			 public static string IdParametro = @"id_parametro";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
