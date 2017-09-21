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
	/// Strongly-typed collection for the PnPromocione class.
	/// </summary>
    [Serializable]
	public partial class PnPromocioneCollection : ActiveList<PnPromocione, PnPromocioneCollection>
	{	   
		public PnPromocioneCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPromocioneCollection</returns>
		public PnPromocioneCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPromocione o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_promociones table.
	/// </summary>
	[Serializable]
	public partial class PnPromocione : ActiveRecord<PnPromocione>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPromocione()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPromocione(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPromocione(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPromocione(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_promociones", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdCategoria = new TableSchema.TableColumn(schema);
				colvarIdCategoria.ColumnName = "id_categoria";
				colvarIdCategoria.DataType = DbType.Int16;
				colvarIdCategoria.MaxLength = 0;
				colvarIdCategoria.AutoIncrement = false;
				colvarIdCategoria.IsNullable = false;
				colvarIdCategoria.IsPrimaryKey = false;
				colvarIdCategoria.IsForeignKey = false;
				colvarIdCategoria.IsReadOnly = false;
				colvarIdCategoria.DefaultSetting = @"";
				colvarIdCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCategoria);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_promociones",schema);
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
		  
		[XmlAttribute("IdCategoria")]
		[Bindable(true)]
		public short IdCategoria 
		{
			get { return GetColumnValue<short>(Columns.IdCategoria); }
			set { SetColumnValue(Columns.IdCategoria, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varFecha,short varIdCategoria,string varComentario)
		{
			PnPromocione item = new PnPromocione();
			
			item.Fecha = varFecha;
			
			item.IdCategoria = varIdCategoria;
			
			item.Comentario = varComentario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLegajo,DateTime varFecha,short varIdCategoria,string varComentario)
		{
			PnPromocione item = new PnPromocione();
			
				item.IdLegajo = varIdLegajo;
			
				item.Fecha = varFecha;
			
				item.IdCategoria = varIdCategoria;
			
				item.Comentario = varComentario;
			
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
        
        
        
        public static TableSchema.TableColumn IdCategoriaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLegajo = @"id_legajo";
			 public static string Fecha = @"fecha";
			 public static string IdCategoria = @"id_categoria";
			 public static string Comentario = @"comentario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
