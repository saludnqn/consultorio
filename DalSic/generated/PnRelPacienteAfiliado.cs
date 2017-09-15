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
	/// Strongly-typed collection for the PnRelPacienteAfiliado class.
	/// </summary>
    [Serializable]
	public partial class PnRelPacienteAfiliadoCollection : ActiveList<PnRelPacienteAfiliado, PnRelPacienteAfiliadoCollection>
	{	   
		public PnRelPacienteAfiliadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnRelPacienteAfiliadoCollection</returns>
		public PnRelPacienteAfiliadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnRelPacienteAfiliado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_RelPacienteAfiliado table.
	/// </summary>
	[Serializable]
	public partial class PnRelPacienteAfiliado : ActiveRecord<PnRelPacienteAfiliado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnRelPacienteAfiliado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnRelPacienteAfiliado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnRelPacienteAfiliado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnRelPacienteAfiliado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_RelPacienteAfiliado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelPacienteAfiliado = new TableSchema.TableColumn(schema);
				colvarIdRelPacienteAfiliado.ColumnName = "idRelPacienteAfiliado";
				colvarIdRelPacienteAfiliado.DataType = DbType.Int32;
				colvarIdRelPacienteAfiliado.MaxLength = 0;
				colvarIdRelPacienteAfiliado.AutoIncrement = true;
				colvarIdRelPacienteAfiliado.IsNullable = false;
				colvarIdRelPacienteAfiliado.IsPrimaryKey = true;
				colvarIdRelPacienteAfiliado.IsForeignKey = false;
				colvarIdRelPacienteAfiliado.IsReadOnly = false;
				colvarIdRelPacienteAfiliado.DefaultSetting = @"";
				colvarIdRelPacienteAfiliado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelPacienteAfiliado);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarClavebeneficiario = new TableSchema.TableColumn(schema);
				colvarClavebeneficiario.ColumnName = "clavebeneficiario";
				colvarClavebeneficiario.DataType = DbType.AnsiString;
				colvarClavebeneficiario.MaxLength = 50;
				colvarClavebeneficiario.AutoIncrement = false;
				colvarClavebeneficiario.IsNullable = false;
				colvarClavebeneficiario.IsPrimaryKey = false;
				colvarClavebeneficiario.IsForeignKey = false;
				colvarClavebeneficiario.IsReadOnly = false;
				colvarClavebeneficiario.DefaultSetting = @"";
				colvarClavebeneficiario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClavebeneficiario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_RelPacienteAfiliado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelPacienteAfiliado")]
		[Bindable(true)]
		public int IdRelPacienteAfiliado 
		{
			get { return GetColumnValue<int>(Columns.IdRelPacienteAfiliado); }
			set { SetColumnValue(Columns.IdRelPacienteAfiliado, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Clavebeneficiario")]
		[Bindable(true)]
		public string Clavebeneficiario 
		{
			get { return GetColumnValue<string>(Columns.Clavebeneficiario); }
			set { SetColumnValue(Columns.Clavebeneficiario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,string varClavebeneficiario)
		{
			PnRelPacienteAfiliado item = new PnRelPacienteAfiliado();
			
			item.IdPaciente = varIdPaciente;
			
			item.Clavebeneficiario = varClavebeneficiario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelPacienteAfiliado,int varIdPaciente,string varClavebeneficiario)
		{
			PnRelPacienteAfiliado item = new PnRelPacienteAfiliado();
			
				item.IdRelPacienteAfiliado = varIdRelPacienteAfiliado;
			
				item.IdPaciente = varIdPaciente;
			
				item.Clavebeneficiario = varClavebeneficiario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelPacienteAfiliadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClavebeneficiarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelPacienteAfiliado = @"idRelPacienteAfiliado";
			 public static string IdPaciente = @"idPaciente";
			 public static string Clavebeneficiario = @"clavebeneficiario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
