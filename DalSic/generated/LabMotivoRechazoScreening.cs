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
	/// Strongly-typed collection for the LabMotivoRechazoScreening class.
	/// </summary>
    [Serializable]
	public partial class LabMotivoRechazoScreeningCollection : ActiveList<LabMotivoRechazoScreening, LabMotivoRechazoScreeningCollection>
	{	   
		public LabMotivoRechazoScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabMotivoRechazoScreeningCollection</returns>
		public LabMotivoRechazoScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabMotivoRechazoScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_MotivoRechazoScreening table.
	/// </summary>
	[Serializable]
	public partial class LabMotivoRechazoScreening : ActiveRecord<LabMotivoRechazoScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabMotivoRechazoScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabMotivoRechazoScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabMotivoRechazoScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabMotivoRechazoScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_MotivoRechazoScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMotivoRechazoScreening = new TableSchema.TableColumn(schema);
				colvarIdMotivoRechazoScreening.ColumnName = "idMotivoRechazoScreening";
				colvarIdMotivoRechazoScreening.DataType = DbType.Int32;
				colvarIdMotivoRechazoScreening.MaxLength = 0;
				colvarIdMotivoRechazoScreening.AutoIncrement = true;
				colvarIdMotivoRechazoScreening.IsNullable = false;
				colvarIdMotivoRechazoScreening.IsPrimaryKey = true;
				colvarIdMotivoRechazoScreening.IsForeignKey = false;
				colvarIdMotivoRechazoScreening.IsReadOnly = false;
				colvarIdMotivoRechazoScreening.DefaultSetting = @"";
				colvarIdMotivoRechazoScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoRechazoScreening);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.String;
				colvarDescripcion.MaxLength = 500;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_MotivoRechazoScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMotivoRechazoScreening")]
		[Bindable(true)]
		public int IdMotivoRechazoScreening 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoRechazoScreening); }
			set { SetColumnValue(Columns.IdMotivoRechazoScreening, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion)
		{
			LabMotivoRechazoScreening item = new LabMotivoRechazoScreening();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMotivoRechazoScreening,string varDescripcion)
		{
			LabMotivoRechazoScreening item = new LabMotivoRechazoScreening();
			
				item.IdMotivoRechazoScreening = varIdMotivoRechazoScreening;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMotivoRechazoScreeningColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMotivoRechazoScreening = @"idMotivoRechazoScreening";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
