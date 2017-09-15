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
	/// Strongly-typed collection for the ConConsultaMedicamento class.
	/// </summary>
    [Serializable]
	public partial class ConConsultaMedicamentoCollection : ActiveList<ConConsultaMedicamento, ConConsultaMedicamentoCollection>
	{	   
		public ConConsultaMedicamentoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConConsultaMedicamentoCollection</returns>
		public ConConsultaMedicamentoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConConsultaMedicamento o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_ConsultaMedicamento table.
	/// </summary>
	[Serializable]
	public partial class ConConsultaMedicamento : ActiveRecord<ConConsultaMedicamento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConConsultaMedicamento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConConsultaMedicamento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConConsultaMedicamento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConConsultaMedicamento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_ConsultaMedicamento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdConsultaMedicamento = new TableSchema.TableColumn(schema);
				colvarIdConsultaMedicamento.ColumnName = "idConsultaMedicamento";
				colvarIdConsultaMedicamento.DataType = DbType.Int32;
				colvarIdConsultaMedicamento.MaxLength = 0;
				colvarIdConsultaMedicamento.AutoIncrement = true;
				colvarIdConsultaMedicamento.IsNullable = false;
				colvarIdConsultaMedicamento.IsPrimaryKey = true;
				colvarIdConsultaMedicamento.IsForeignKey = false;
				colvarIdConsultaMedicamento.IsReadOnly = false;
				colvarIdConsultaMedicamento.DefaultSetting = @"";
				colvarIdConsultaMedicamento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsultaMedicamento);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
				colvarIdConsulta.ColumnName = "idConsulta";
				colvarIdConsulta.DataType = DbType.Int32;
				colvarIdConsulta.MaxLength = 0;
				colvarIdConsulta.AutoIncrement = false;
				colvarIdConsulta.IsNullable = true;
				colvarIdConsulta.IsPrimaryKey = false;
				colvarIdConsulta.IsForeignKey = true;
				colvarIdConsulta.IsReadOnly = false;
				colvarIdConsulta.DefaultSetting = @"";
				
					colvarIdConsulta.ForeignKeyTableName = "CON_Consulta";
				schema.Columns.Add(colvarIdConsulta);
				
				TableSchema.TableColumn colvarIdMedicamento = new TableSchema.TableColumn(schema);
				colvarIdMedicamento.ColumnName = "idMedicamento";
				colvarIdMedicamento.DataType = DbType.Int32;
				colvarIdMedicamento.MaxLength = 0;
				colvarIdMedicamento.AutoIncrement = false;
				colvarIdMedicamento.IsNullable = true;
				colvarIdMedicamento.IsPrimaryKey = false;
				colvarIdMedicamento.IsForeignKey = false;
				colvarIdMedicamento.IsReadOnly = false;
				colvarIdMedicamento.DefaultSetting = @"";
				colvarIdMedicamento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedicamento);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_ConsultaMedicamento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdConsultaMedicamento")]
		[Bindable(true)]
		public int IdConsultaMedicamento 
		{
			get { return GetColumnValue<int>(Columns.IdConsultaMedicamento); }
			set { SetColumnValue(Columns.IdConsultaMedicamento, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int? IdConsulta 
		{
			get { return GetColumnValue<int?>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("IdMedicamento")]
		[Bindable(true)]
		public int? IdMedicamento 
		{
			get { return GetColumnValue<int?>(Columns.IdMedicamento); }
			set { SetColumnValue(Columns.IdMedicamento, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConConsultum ActiveRecord object related to this ConConsultaMedicamento
		/// 
		/// </summary>
		public DalSic.ConConsultum ConConsultum
		{
			get { return DalSic.ConConsultum.FetchByID(this.IdConsulta); }
			set { SetColumnValue("idConsulta", value.IdConsulta); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfector,int? varIdConsulta,int? varIdMedicamento)
		{
			ConConsultaMedicamento item = new ConConsultaMedicamento();
			
			item.IdEfector = varIdEfector;
			
			item.IdConsulta = varIdConsulta;
			
			item.IdMedicamento = varIdMedicamento;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdConsultaMedicamento,int? varIdEfector,int? varIdConsulta,int? varIdMedicamento)
		{
			ConConsultaMedicamento item = new ConConsultaMedicamento();
			
				item.IdConsultaMedicamento = varIdConsultaMedicamento;
			
				item.IdEfector = varIdEfector;
			
				item.IdConsulta = varIdConsulta;
			
				item.IdMedicamento = varIdMedicamento;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdConsultaMedicamentoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMedicamentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdConsultaMedicamento = @"idConsultaMedicamento";
			 public static string IdEfector = @"idEfector";
			 public static string IdConsulta = @"idConsulta";
			 public static string IdMedicamento = @"idMedicamento";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
