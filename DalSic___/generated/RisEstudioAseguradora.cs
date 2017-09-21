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
	/// Strongly-typed collection for the RisEstudioAseguradora class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioAseguradoraCollection : ActiveList<RisEstudioAseguradora, RisEstudioAseguradoraCollection>
	{	   
		public RisEstudioAseguradoraCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioAseguradoraCollection</returns>
		public RisEstudioAseguradoraCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioAseguradora o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioAseguradora table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioAseguradora : ActiveRecord<RisEstudioAseguradora>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioAseguradora()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioAseguradora(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioAseguradora(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioAseguradora(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioAseguradora", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioAseguradora = new TableSchema.TableColumn(schema);
				colvarIdEstudioAseguradora.ColumnName = "idEstudioAseguradora";
				colvarIdEstudioAseguradora.DataType = DbType.Int32;
				colvarIdEstudioAseguradora.MaxLength = 0;
				colvarIdEstudioAseguradora.AutoIncrement = true;
				colvarIdEstudioAseguradora.IsNullable = false;
				colvarIdEstudioAseguradora.IsPrimaryKey = true;
				colvarIdEstudioAseguradora.IsForeignKey = false;
				colvarIdEstudioAseguradora.IsReadOnly = false;
				colvarIdEstudioAseguradora.DefaultSetting = @"";
				colvarIdEstudioAseguradora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioAseguradora);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarIdAseguradora = new TableSchema.TableColumn(schema);
				colvarIdAseguradora.ColumnName = "idAseguradora";
				colvarIdAseguradora.DataType = DbType.Int32;
				colvarIdAseguradora.MaxLength = 0;
				colvarIdAseguradora.AutoIncrement = false;
				colvarIdAseguradora.IsNullable = false;
				colvarIdAseguradora.IsPrimaryKey = false;
				colvarIdAseguradora.IsForeignKey = false;
				colvarIdAseguradora.IsReadOnly = false;
				colvarIdAseguradora.DefaultSetting = @"";
				colvarIdAseguradora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAseguradora);
				
				TableSchema.TableColumn colvarNumeroPoliza = new TableSchema.TableColumn(schema);
				colvarNumeroPoliza.ColumnName = "numeroPoliza";
				colvarNumeroPoliza.DataType = DbType.AnsiString;
				colvarNumeroPoliza.MaxLength = 100;
				colvarNumeroPoliza.AutoIncrement = false;
				colvarNumeroPoliza.IsNullable = false;
				colvarNumeroPoliza.IsPrimaryKey = false;
				colvarNumeroPoliza.IsForeignKey = false;
				colvarNumeroPoliza.IsReadOnly = false;
				colvarNumeroPoliza.DefaultSetting = @"";
				colvarNumeroPoliza.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroPoliza);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioAseguradora",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioAseguradora")]
		[Bindable(true)]
		public int IdEstudioAseguradora 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioAseguradora); }
			set { SetColumnValue(Columns.IdEstudioAseguradora, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdAseguradora")]
		[Bindable(true)]
		public int IdAseguradora 
		{
			get { return GetColumnValue<int>(Columns.IdAseguradora); }
			set { SetColumnValue(Columns.IdAseguradora, value); }
		}
		  
		[XmlAttribute("NumeroPoliza")]
		[Bindable(true)]
		public string NumeroPoliza 
		{
			get { return GetColumnValue<string>(Columns.NumeroPoliza); }
			set { SetColumnValue(Columns.NumeroPoliza, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdAseguradora,string varNumeroPoliza)
		{
			RisEstudioAseguradora item = new RisEstudioAseguradora();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdAseguradora = varIdAseguradora;
			
			item.NumeroPoliza = varNumeroPoliza;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioAseguradora,int varIdEstudio,int varIdAseguradora,string varNumeroPoliza)
		{
			RisEstudioAseguradora item = new RisEstudioAseguradora();
			
				item.IdEstudioAseguradora = varIdEstudioAseguradora;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdAseguradora = varIdAseguradora;
			
				item.NumeroPoliza = varNumeroPoliza;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioAseguradoraColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAseguradoraColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroPolizaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioAseguradora = @"idEstudioAseguradora";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdAseguradora = @"idAseguradora";
			 public static string NumeroPoliza = @"numeroPoliza";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
