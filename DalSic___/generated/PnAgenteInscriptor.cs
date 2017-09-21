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
	/// Strongly-typed collection for the PnAgenteInscriptor class.
	/// </summary>
    [Serializable]
	public partial class PnAgenteInscriptorCollection : ActiveList<PnAgenteInscriptor, PnAgenteInscriptorCollection>
	{	   
		public PnAgenteInscriptorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAgenteInscriptorCollection</returns>
		public PnAgenteInscriptorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAgenteInscriptor o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_agente_inscriptor table.
	/// </summary>
	[Serializable]
	public partial class PnAgenteInscriptor : ActiveRecord<PnAgenteInscriptor>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAgenteInscriptor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAgenteInscriptor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAgenteInscriptor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAgenteInscriptor(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_agente_inscriptor", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgenteInscriptor = new TableSchema.TableColumn(schema);
				colvarIdAgenteInscriptor.ColumnName = "id_agente_inscriptor";
				colvarIdAgenteInscriptor.DataType = DbType.Int32;
				colvarIdAgenteInscriptor.MaxLength = 0;
				colvarIdAgenteInscriptor.AutoIncrement = true;
				colvarIdAgenteInscriptor.IsNullable = false;
				colvarIdAgenteInscriptor.IsPrimaryKey = true;
				colvarIdAgenteInscriptor.IsForeignKey = false;
				colvarIdAgenteInscriptor.IsReadOnly = false;
				colvarIdAgenteInscriptor.DefaultSetting = @"";
				colvarIdAgenteInscriptor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgenteInscriptor);
				
				TableSchema.TableColumn colvarDescripcionAgente = new TableSchema.TableColumn(schema);
				colvarDescripcionAgente.ColumnName = "descripcion_agente";
				colvarDescripcionAgente.DataType = DbType.AnsiString;
				colvarDescripcionAgente.MaxLength = -1;
				colvarDescripcionAgente.AutoIncrement = false;
				colvarDescripcionAgente.IsNullable = true;
				colvarDescripcionAgente.IsPrimaryKey = false;
				colvarDescripcionAgente.IsForeignKey = false;
				colvarDescripcionAgente.IsReadOnly = false;
				colvarDescripcionAgente.DefaultSetting = @"";
				colvarDescripcionAgente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionAgente);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_agente_inscriptor",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgenteInscriptor")]
		[Bindable(true)]
		public int IdAgenteInscriptor 
		{
			get { return GetColumnValue<int>(Columns.IdAgenteInscriptor); }
			set { SetColumnValue(Columns.IdAgenteInscriptor, value); }
		}
		  
		[XmlAttribute("DescripcionAgente")]
		[Bindable(true)]
		public string DescripcionAgente 
		{
			get { return GetColumnValue<string>(Columns.DescripcionAgente); }
			set { SetColumnValue(Columns.DescripcionAgente, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcionAgente)
		{
			PnAgenteInscriptor item = new PnAgenteInscriptor();
			
			item.DescripcionAgente = varDescripcionAgente;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgenteInscriptor,string varDescripcionAgente)
		{
			PnAgenteInscriptor item = new PnAgenteInscriptor();
			
				item.IdAgenteInscriptor = varIdAgenteInscriptor;
			
				item.DescripcionAgente = varDescripcionAgente;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgenteInscriptorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionAgenteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgenteInscriptor = @"id_agente_inscriptor";
			 public static string DescripcionAgente = @"descripcion_agente";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
