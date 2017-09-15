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
	/// Strongly-typed collection for the PnEvento class.
	/// </summary>
    [Serializable]
	public partial class PnEventoCollection : ActiveList<PnEvento, PnEventoCollection>
	{	   
		public PnEventoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEventoCollection</returns>
		public PnEventoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEvento o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_evento table.
	/// </summary>
	[Serializable]
	public partial class PnEvento : ActiveRecord<PnEvento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEvento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEvento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEvento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEvento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_evento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEvento = new TableSchema.TableColumn(schema);
				colvarIdEvento.ColumnName = "id_evento";
				colvarIdEvento.DataType = DbType.Int32;
				colvarIdEvento.MaxLength = 0;
				colvarIdEvento.AutoIncrement = true;
				colvarIdEvento.IsNullable = false;
				colvarIdEvento.IsPrimaryKey = true;
				colvarIdEvento.IsForeignKey = false;
				colvarIdEvento.IsReadOnly = false;
				colvarIdEvento.DefaultSetting = @"";
				colvarIdEvento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEvento);
				
				TableSchema.TableColumn colvarIdTipoEvento = new TableSchema.TableColumn(schema);
				colvarIdTipoEvento.ColumnName = "id_tipo_evento";
				colvarIdTipoEvento.DataType = DbType.Int32;
				colvarIdTipoEvento.MaxLength = 0;
				colvarIdTipoEvento.AutoIncrement = false;
				colvarIdTipoEvento.IsNullable = false;
				colvarIdTipoEvento.IsPrimaryKey = false;
				colvarIdTipoEvento.IsForeignKey = false;
				colvarIdTipoEvento.IsReadOnly = false;
				colvarIdTipoEvento.DefaultSetting = @"";
				colvarIdTipoEvento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEvento);
				
				TableSchema.TableColumn colvarArea = new TableSchema.TableColumn(schema);
				colvarArea.ColumnName = "area";
				colvarArea.DataType = DbType.AnsiString;
				colvarArea.MaxLength = -1;
				colvarArea.AutoIncrement = false;
				colvarArea.IsNullable = true;
				colvarArea.IsPrimaryKey = false;
				colvarArea.IsForeignKey = false;
				colvarArea.IsReadOnly = false;
				colvarArea.DefaultSetting = @"";
				colvarArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArea);
				
				TableSchema.TableColumn colvarSuseso = new TableSchema.TableColumn(schema);
				colvarSuseso.ColumnName = "suseso";
				colvarSuseso.DataType = DbType.AnsiString;
				colvarSuseso.MaxLength = -1;
				colvarSuseso.AutoIncrement = false;
				colvarSuseso.IsNullable = true;
				colvarSuseso.IsPrimaryKey = false;
				colvarSuseso.IsForeignKey = false;
				colvarSuseso.IsReadOnly = false;
				colvarSuseso.DefaultSetting = @"";
				colvarSuseso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSuseso);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.Int16;
				colvarEstado.MaxLength = 0;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarMedida = new TableSchema.TableColumn(schema);
				colvarMedida.ColumnName = "medida";
				colvarMedida.DataType = DbType.AnsiString;
				colvarMedida.MaxLength = -1;
				colvarMedida.AutoIncrement = false;
				colvarMedida.IsNullable = true;
				colvarMedida.IsPrimaryKey = false;
				colvarMedida.IsForeignKey = false;
				colvarMedida.IsReadOnly = false;
				colvarMedida.DefaultSetting = @"";
				colvarMedida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedida);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_evento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEvento")]
		[Bindable(true)]
		public int IdEvento 
		{
			get { return GetColumnValue<int>(Columns.IdEvento); }
			set { SetColumnValue(Columns.IdEvento, value); }
		}
		  
		[XmlAttribute("IdTipoEvento")]
		[Bindable(true)]
		public int IdTipoEvento 
		{
			get { return GetColumnValue<int>(Columns.IdTipoEvento); }
			set { SetColumnValue(Columns.IdTipoEvento, value); }
		}
		  
		[XmlAttribute("Area")]
		[Bindable(true)]
		public string Area 
		{
			get { return GetColumnValue<string>(Columns.Area); }
			set { SetColumnValue(Columns.Area, value); }
		}
		  
		[XmlAttribute("Suseso")]
		[Bindable(true)]
		public string Suseso 
		{
			get { return GetColumnValue<string>(Columns.Suseso); }
			set { SetColumnValue(Columns.Suseso, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public short? Estado 
		{
			get { return GetColumnValue<short?>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Medida")]
		[Bindable(true)]
		public string Medida 
		{
			get { return GetColumnValue<string>(Columns.Medida); }
			set { SetColumnValue(Columns.Medida, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdTipoEvento,string varArea,string varSuseso,short? varEstado,string varMedida)
		{
			PnEvento item = new PnEvento();
			
			item.IdTipoEvento = varIdTipoEvento;
			
			item.Area = varArea;
			
			item.Suseso = varSuseso;
			
			item.Estado = varEstado;
			
			item.Medida = varMedida;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEvento,int varIdTipoEvento,string varArea,string varSuseso,short? varEstado,string varMedida)
		{
			PnEvento item = new PnEvento();
			
				item.IdEvento = varIdEvento;
			
				item.IdTipoEvento = varIdTipoEvento;
			
				item.Area = varArea;
			
				item.Suseso = varSuseso;
			
				item.Estado = varEstado;
			
				item.Medida = varMedida;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEventoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEventoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SusesoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MedidaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEvento = @"id_evento";
			 public static string IdTipoEvento = @"id_tipo_evento";
			 public static string Area = @"area";
			 public static string Suseso = @"suseso";
			 public static string Estado = @"estado";
			 public static string Medida = @"medida";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
