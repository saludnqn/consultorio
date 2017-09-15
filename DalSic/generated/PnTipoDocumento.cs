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
	/// Strongly-typed collection for the PnTipoDocumento class.
	/// </summary>
    [Serializable]
	public partial class PnTipoDocumentoCollection : ActiveList<PnTipoDocumento, PnTipoDocumentoCollection>
	{	   
		public PnTipoDocumentoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTipoDocumentoCollection</returns>
		public PnTipoDocumentoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTipoDocumento o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_tipo_documento table.
	/// </summary>
	[Serializable]
	public partial class PnTipoDocumento : ActiveRecord<PnTipoDocumento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTipoDocumento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTipoDocumento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTipoDocumento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTipoDocumento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_tipo_documento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoDocumento = new TableSchema.TableColumn(schema);
				colvarIdTipoDocumento.ColumnName = "id_tipo_documento";
				colvarIdTipoDocumento.DataType = DbType.Int32;
				colvarIdTipoDocumento.MaxLength = 0;
				colvarIdTipoDocumento.AutoIncrement = true;
				colvarIdTipoDocumento.IsNullable = false;
				colvarIdTipoDocumento.IsPrimaryKey = true;
				colvarIdTipoDocumento.IsForeignKey = false;
				colvarIdTipoDocumento.IsReadOnly = false;
				colvarIdTipoDocumento.DefaultSetting = @"";
				colvarIdTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoDocumento);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.AnsiString;
				colvarTipo.MaxLength = 5;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 50;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarIdBeneficiario = new TableSchema.TableColumn(schema);
				colvarIdBeneficiario.ColumnName = "id_beneficiario";
				colvarIdBeneficiario.DataType = DbType.Int32;
				colvarIdBeneficiario.MaxLength = 0;
				colvarIdBeneficiario.AutoIncrement = false;
				colvarIdBeneficiario.IsNullable = false;
				colvarIdBeneficiario.IsPrimaryKey = false;
				colvarIdBeneficiario.IsForeignKey = false;
				colvarIdBeneficiario.IsReadOnly = false;
				colvarIdBeneficiario.DefaultSetting = @"";
				colvarIdBeneficiario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBeneficiario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_tipo_documento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoDocumento")]
		[Bindable(true)]
		public int IdTipoDocumento 
		{
			get { return GetColumnValue<int>(Columns.IdTipoDocumento); }
			set { SetColumnValue(Columns.IdTipoDocumento, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("IdBeneficiario")]
		[Bindable(true)]
		public int IdBeneficiario 
		{
			get { return GetColumnValue<int>(Columns.IdBeneficiario); }
			set { SetColumnValue(Columns.IdBeneficiario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTipo,string varDescripcion,int varIdBeneficiario)
		{
			PnTipoDocumento item = new PnTipoDocumento();
			
			item.Tipo = varTipo;
			
			item.Descripcion = varDescripcion;
			
			item.IdBeneficiario = varIdBeneficiario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoDocumento,string varTipo,string varDescripcion,int varIdBeneficiario)
		{
			PnTipoDocumento item = new PnTipoDocumento();
			
				item.IdTipoDocumento = varIdTipoDocumento;
			
				item.Tipo = varTipo;
			
				item.Descripcion = varDescripcion;
			
				item.IdBeneficiario = varIdBeneficiario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoDocumentoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBeneficiarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTipoDocumento = @"id_tipo_documento";
			 public static string Tipo = @"tipo";
			 public static string Descripcion = @"descripcion";
			 public static string IdBeneficiario = @"id_beneficiario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
