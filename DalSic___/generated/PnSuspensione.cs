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
	/// Strongly-typed collection for the PnSuspensione class.
	/// </summary>
    [Serializable]
	public partial class PnSuspensioneCollection : ActiveList<PnSuspensione, PnSuspensioneCollection>
	{	   
		public PnSuspensioneCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSuspensioneCollection</returns>
		public PnSuspensioneCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSuspensione o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_suspensiones table.
	/// </summary>
	[Serializable]
	public partial class PnSuspensione : ActiveRecord<PnSuspensione>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSuspensione()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSuspensione(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSuspensione(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSuspensione(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_suspensiones", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSuspension = new TableSchema.TableColumn(schema);
				colvarIdSuspension.ColumnName = "id_suspension";
				colvarIdSuspension.DataType = DbType.Int32;
				colvarIdSuspension.MaxLength = 0;
				colvarIdSuspension.AutoIncrement = true;
				colvarIdSuspension.IsNullable = false;
				colvarIdSuspension.IsPrimaryKey = true;
				colvarIdSuspension.IsForeignKey = false;
				colvarIdSuspension.IsReadOnly = false;
				colvarIdSuspension.DefaultSetting = @"";
				colvarIdSuspension.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSuspension);
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = false;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = false;
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
				
				TableSchema.TableColumn colvarMotivo = new TableSchema.TableColumn(schema);
				colvarMotivo.ColumnName = "motivo";
				colvarMotivo.DataType = DbType.AnsiString;
				colvarMotivo.MaxLength = -1;
				colvarMotivo.AutoIncrement = false;
				colvarMotivo.IsNullable = false;
				colvarMotivo.IsPrimaryKey = false;
				colvarMotivo.IsForeignKey = false;
				colvarMotivo.IsReadOnly = false;
				colvarMotivo.DefaultSetting = @"";
				colvarMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivo);
				
				TableSchema.TableColumn colvarDias = new TableSchema.TableColumn(schema);
				colvarDias.ColumnName = "dias";
				colvarDias.DataType = DbType.Int16;
				colvarDias.MaxLength = 0;
				colvarDias.AutoIncrement = false;
				colvarDias.IsNullable = false;
				colvarDias.IsPrimaryKey = false;
				colvarDias.IsForeignKey = false;
				colvarDias.IsReadOnly = false;
				colvarDias.DefaultSetting = @"";
				colvarDias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDias);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_suspensiones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSuspension")]
		[Bindable(true)]
		public int IdSuspension 
		{
			get { return GetColumnValue<int>(Columns.IdSuspension); }
			set { SetColumnValue(Columns.IdSuspension, value); }
		}
		  
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
		  
		[XmlAttribute("Motivo")]
		[Bindable(true)]
		public string Motivo 
		{
			get { return GetColumnValue<string>(Columns.Motivo); }
			set { SetColumnValue(Columns.Motivo, value); }
		}
		  
		[XmlAttribute("Dias")]
		[Bindable(true)]
		public short Dias 
		{
			get { return GetColumnValue<short>(Columns.Dias); }
			set { SetColumnValue(Columns.Dias, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdLegajo,DateTime varFecha,string varMotivo,short varDias)
		{
			PnSuspensione item = new PnSuspensione();
			
			item.IdLegajo = varIdLegajo;
			
			item.Fecha = varFecha;
			
			item.Motivo = varMotivo;
			
			item.Dias = varDias;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSuspension,int varIdLegajo,DateTime varFecha,string varMotivo,short varDias)
		{
			PnSuspensione item = new PnSuspensione();
			
				item.IdSuspension = varIdSuspension;
			
				item.IdLegajo = varIdLegajo;
			
				item.Fecha = varFecha;
			
				item.Motivo = varMotivo;
			
				item.Dias = varDias;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSuspensionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSuspension = @"id_suspension";
			 public static string IdLegajo = @"id_legajo";
			 public static string Fecha = @"fecha";
			 public static string Motivo = @"motivo";
			 public static string Dias = @"dias";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
