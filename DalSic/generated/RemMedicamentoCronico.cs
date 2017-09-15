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
	/// Strongly-typed collection for the RemMedicamentoCronico class.
	/// </summary>
    [Serializable]
	public partial class RemMedicamentoCronicoCollection : ActiveList<RemMedicamentoCronico, RemMedicamentoCronicoCollection>
	{	   
		public RemMedicamentoCronicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemMedicamentoCronicoCollection</returns>
		public RemMedicamentoCronicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemMedicamentoCronico o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_MedicamentoCronico table.
	/// </summary>
	[Serializable]
	public partial class RemMedicamentoCronico : ActiveRecord<RemMedicamentoCronico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemMedicamentoCronico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemMedicamentoCronico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemMedicamentoCronico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemMedicamentoCronico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_MedicamentoCronico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMedicamentoCronico = new TableSchema.TableColumn(schema);
				colvarIdMedicamentoCronico.ColumnName = "idMedicamentoCronico";
				colvarIdMedicamentoCronico.DataType = DbType.Int32;
				colvarIdMedicamentoCronico.MaxLength = 0;
				colvarIdMedicamentoCronico.AutoIncrement = true;
				colvarIdMedicamentoCronico.IsNullable = false;
				colvarIdMedicamentoCronico.IsPrimaryKey = true;
				colvarIdMedicamentoCronico.IsForeignKey = false;
				colvarIdMedicamentoCronico.IsReadOnly = false;
				colvarIdMedicamentoCronico.DefaultSetting = @"";
				colvarIdMedicamentoCronico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedicamentoCronico);
				
				TableSchema.TableColumn colvarIdMedicamento = new TableSchema.TableColumn(schema);
				colvarIdMedicamento.ColumnName = "idMedicamento";
				colvarIdMedicamento.DataType = DbType.Int32;
				colvarIdMedicamento.MaxLength = 0;
				colvarIdMedicamento.AutoIncrement = false;
				colvarIdMedicamento.IsNullable = false;
				colvarIdMedicamento.IsPrimaryKey = false;
				colvarIdMedicamento.IsForeignKey = true;
				colvarIdMedicamento.IsReadOnly = false;
				
						colvarIdMedicamento.DefaultSetting = @"((0))";
				
					colvarIdMedicamento.ForeignKeyTableName = "Sys_Medicamento";
				schema.Columns.Add(colvarIdMedicamento);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_MedicamentoCronico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMedicamentoCronico")]
		[Bindable(true)]
		public int IdMedicamentoCronico 
		{
			get { return GetColumnValue<int>(Columns.IdMedicamentoCronico); }
			set { SetColumnValue(Columns.IdMedicamentoCronico, value); }
		}
		  
		[XmlAttribute("IdMedicamento")]
		[Bindable(true)]
		public int IdMedicamento 
		{
			get { return GetColumnValue<int>(Columns.IdMedicamento); }
			set { SetColumnValue(Columns.IdMedicamento, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysMedicamento ActiveRecord object related to this RemMedicamentoCronico
		/// 
		/// </summary>
		public DalSic.SysMedicamento SysMedicamento
		{
			get { return DalSic.SysMedicamento.FetchByID(this.IdMedicamento); }
			set { SetColumnValue("idMedicamento", value.IdMedicamento); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdMedicamento)
		{
			RemMedicamentoCronico item = new RemMedicamentoCronico();
			
			item.IdMedicamento = varIdMedicamento;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMedicamentoCronico,int varIdMedicamento)
		{
			RemMedicamentoCronico item = new RemMedicamentoCronico();
			
				item.IdMedicamentoCronico = varIdMedicamentoCronico;
			
				item.IdMedicamento = varIdMedicamento;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMedicamentoCronicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMedicamentoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMedicamentoCronico = @"idMedicamentoCronico";
			 public static string IdMedicamento = @"idMedicamento";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
