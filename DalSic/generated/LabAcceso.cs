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
	/// Strongly-typed collection for the LabAcceso class.
	/// </summary>
    [Serializable]
	public partial class LabAccesoCollection : ActiveList<LabAcceso, LabAccesoCollection>
	{	   
		public LabAccesoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabAccesoCollection</returns>
		public LabAccesoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabAcceso o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_Acceso table.
	/// </summary>
	[Serializable]
	public partial class LabAcceso : ActiveRecord<LabAcceso>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabAcceso()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabAcceso(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabAcceso(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabAcceso(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_Acceso", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAcceso = new TableSchema.TableColumn(schema);
				colvarIdAcceso.ColumnName = "idAcceso";
				colvarIdAcceso.DataType = DbType.Int32;
				colvarIdAcceso.MaxLength = 0;
				colvarIdAcceso.AutoIncrement = true;
				colvarIdAcceso.IsNullable = false;
				colvarIdAcceso.IsPrimaryKey = true;
				colvarIdAcceso.IsForeignKey = false;
				colvarIdAcceso.IsReadOnly = false;
				colvarIdAcceso.DefaultSetting = @"";
				colvarIdAcceso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAcceso);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarFechaUltimoAcceso = new TableSchema.TableColumn(schema);
				colvarFechaUltimoAcceso.ColumnName = "fechaUltimoAcceso";
				colvarFechaUltimoAcceso.DataType = DbType.DateTime;
				colvarFechaUltimoAcceso.MaxLength = 0;
				colvarFechaUltimoAcceso.AutoIncrement = false;
				colvarFechaUltimoAcceso.IsNullable = false;
				colvarFechaUltimoAcceso.IsPrimaryKey = false;
				colvarFechaUltimoAcceso.IsForeignKey = false;
				colvarFechaUltimoAcceso.IsReadOnly = false;
				colvarFechaUltimoAcceso.DefaultSetting = @"";
				colvarFechaUltimoAcceso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaUltimoAcceso);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_Acceso",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAcceso")]
		[Bindable(true)]
		public int IdAcceso 
		{
			get { return GetColumnValue<int>(Columns.IdAcceso); }
			set { SetColumnValue(Columns.IdAcceso, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaUltimoAcceso")]
		[Bindable(true)]
		public DateTime FechaUltimoAcceso 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaUltimoAcceso); }
			set { SetColumnValue(Columns.FechaUltimoAcceso, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdUsuario,DateTime varFechaUltimoAcceso)
		{
			LabAcceso item = new LabAcceso();
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaUltimoAcceso = varFechaUltimoAcceso;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAcceso,int varIdUsuario,DateTime varFechaUltimoAcceso)
		{
			LabAcceso item = new LabAcceso();
			
				item.IdAcceso = varIdAcceso;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaUltimoAcceso = varFechaUltimoAcceso;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAccesoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaUltimoAccesoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAcceso = @"idAcceso";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaUltimoAcceso = @"fechaUltimoAcceso";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
