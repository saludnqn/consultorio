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
	/// Strongly-typed collection for the AutHistoricoVehiculoPmp class.
	/// </summary>
    [Serializable]
	public partial class AutHistoricoVehiculoPmpCollection : ActiveList<AutHistoricoVehiculoPmp, AutHistoricoVehiculoPmpCollection>
	{	   
		public AutHistoricoVehiculoPmpCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AutHistoricoVehiculoPmpCollection</returns>
		public AutHistoricoVehiculoPmpCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AutHistoricoVehiculoPmp o = this[i];
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
	/// This is an ActiveRecord class which wraps the AUT_Historico_Vehiculo_PMP table.
	/// </summary>
	[Serializable]
	public partial class AutHistoricoVehiculoPmp : ActiveRecord<AutHistoricoVehiculoPmp>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AutHistoricoVehiculoPmp()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AutHistoricoVehiculoPmp(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AutHistoricoVehiculoPmp(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AutHistoricoVehiculoPmp(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("AUT_Historico_Vehiculo_PMP", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHistoricoVehiculoPMP = new TableSchema.TableColumn(schema);
				colvarIdHistoricoVehiculoPMP.ColumnName = "idHistoricoVehiculoPMP";
				colvarIdHistoricoVehiculoPMP.DataType = DbType.Int32;
				colvarIdHistoricoVehiculoPMP.MaxLength = 0;
				colvarIdHistoricoVehiculoPMP.AutoIncrement = true;
				colvarIdHistoricoVehiculoPMP.IsNullable = false;
				colvarIdHistoricoVehiculoPMP.IsPrimaryKey = true;
				colvarIdHistoricoVehiculoPMP.IsForeignKey = false;
				colvarIdHistoricoVehiculoPMP.IsReadOnly = false;
				colvarIdHistoricoVehiculoPMP.DefaultSetting = @"";
				colvarIdHistoricoVehiculoPMP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHistoricoVehiculoPMP);
				
				TableSchema.TableColumn colvarIdVehiculoPMP = new TableSchema.TableColumn(schema);
				colvarIdVehiculoPMP.ColumnName = "idVehiculoPMP";
				colvarIdVehiculoPMP.DataType = DbType.Int32;
				colvarIdVehiculoPMP.MaxLength = 0;
				colvarIdVehiculoPMP.AutoIncrement = false;
				colvarIdVehiculoPMP.IsNullable = false;
				colvarIdVehiculoPMP.IsPrimaryKey = false;
				colvarIdVehiculoPMP.IsForeignKey = true;
				colvarIdVehiculoPMP.IsReadOnly = false;
				colvarIdVehiculoPMP.DefaultSetting = @"";
				
					colvarIdVehiculoPMP.ForeignKeyTableName = "AUT_Vehiculo_PMP";
				schema.Columns.Add(colvarIdVehiculoPMP);
				
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
				
				TableSchema.TableColumn colvarKilometraje = new TableSchema.TableColumn(schema);
				colvarKilometraje.ColumnName = "kilometraje";
				colvarKilometraje.DataType = DbType.Int32;
				colvarKilometraje.MaxLength = 0;
				colvarKilometraje.AutoIncrement = false;
				colvarKilometraje.IsNullable = false;
				colvarKilometraje.IsPrimaryKey = false;
				colvarKilometraje.IsForeignKey = false;
				colvarKilometraje.IsReadOnly = false;
				colvarKilometraje.DefaultSetting = @"";
				colvarKilometraje.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKilometraje);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("AUT_Historico_Vehiculo_PMP",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHistoricoVehiculoPMP")]
		[Bindable(true)]
		public int IdHistoricoVehiculoPMP 
		{
			get { return GetColumnValue<int>(Columns.IdHistoricoVehiculoPMP); }
			set { SetColumnValue(Columns.IdHistoricoVehiculoPMP, value); }
		}
		  
		[XmlAttribute("IdVehiculoPMP")]
		[Bindable(true)]
		public int IdVehiculoPMP 
		{
			get { return GetColumnValue<int>(Columns.IdVehiculoPMP); }
			set { SetColumnValue(Columns.IdVehiculoPMP, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Kilometraje")]
		[Bindable(true)]
		public int Kilometraje 
		{
			get { return GetColumnValue<int>(Columns.Kilometraje); }
			set { SetColumnValue(Columns.Kilometraje, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdVehiculoPMP,DateTime varFecha,int varKilometraje)
		{
			AutHistoricoVehiculoPmp item = new AutHistoricoVehiculoPmp();
			
			item.IdVehiculoPMP = varIdVehiculoPMP;
			
			item.Fecha = varFecha;
			
			item.Kilometraje = varKilometraje;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdHistoricoVehiculoPMP,int varIdVehiculoPMP,DateTime varFecha,int varKilometraje)
		{
			AutHistoricoVehiculoPmp item = new AutHistoricoVehiculoPmp();
			
				item.IdHistoricoVehiculoPMP = varIdHistoricoVehiculoPMP;
			
				item.IdVehiculoPMP = varIdVehiculoPMP;
			
				item.Fecha = varFecha;
			
				item.Kilometraje = varKilometraje;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHistoricoVehiculoPMPColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVehiculoPMPColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn KilometrajeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHistoricoVehiculoPMP = @"idHistoricoVehiculoPMP";
			 public static string IdVehiculoPMP = @"idVehiculoPMP";
			 public static string Fecha = @"fecha";
			 public static string Kilometraje = @"kilometraje";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
