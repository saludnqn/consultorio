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
	/// Strongly-typed collection for the PnFeriado class.
	/// </summary>
    [Serializable]
	public partial class PnFeriadoCollection : ActiveList<PnFeriado, PnFeriadoCollection>
	{	   
		public PnFeriadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnFeriadoCollection</returns>
		public PnFeriadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnFeriado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_feriados table.
	/// </summary>
	[Serializable]
	public partial class PnFeriado : ActiveRecord<PnFeriado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnFeriado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnFeriado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnFeriado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnFeriado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_feriados", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdFecha = new TableSchema.TableColumn(schema);
				colvarIdFecha.ColumnName = "id_fecha";
				colvarIdFecha.DataType = DbType.Int32;
				colvarIdFecha.MaxLength = 0;
				colvarIdFecha.AutoIncrement = true;
				colvarIdFecha.IsNullable = false;
				colvarIdFecha.IsPrimaryKey = true;
				colvarIdFecha.IsForeignKey = false;
				colvarIdFecha.IsReadOnly = false;
				colvarIdFecha.DefaultSetting = @"";
				colvarIdFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFecha);
				
				TableSchema.TableColumn colvarDia = new TableSchema.TableColumn(schema);
				colvarDia.ColumnName = "dia";
				colvarDia.DataType = DbType.Int32;
				colvarDia.MaxLength = 0;
				colvarDia.AutoIncrement = false;
				colvarDia.IsNullable = true;
				colvarDia.IsPrimaryKey = false;
				colvarDia.IsForeignKey = false;
				colvarDia.IsReadOnly = false;
				colvarDia.DefaultSetting = @"";
				colvarDia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDia);
				
				TableSchema.TableColumn colvarMes = new TableSchema.TableColumn(schema);
				colvarMes.ColumnName = "mes";
				colvarMes.DataType = DbType.Int32;
				colvarMes.MaxLength = 0;
				colvarMes.AutoIncrement = false;
				colvarMes.IsNullable = true;
				colvarMes.IsPrimaryKey = false;
				colvarMes.IsForeignKey = false;
				colvarMes.IsReadOnly = false;
				colvarMes.DefaultSetting = @"";
				colvarMes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMes);
				
				TableSchema.TableColumn colvarAnio = new TableSchema.TableColumn(schema);
				colvarAnio.ColumnName = "anio";
				colvarAnio.DataType = DbType.Int32;
				colvarAnio.MaxLength = 0;
				colvarAnio.AutoIncrement = false;
				colvarAnio.IsNullable = true;
				colvarAnio.IsPrimaryKey = false;
				colvarAnio.IsForeignKey = false;
				colvarAnio.IsReadOnly = false;
				colvarAnio.DefaultSetting = @"";
				colvarAnio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnio);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_feriados",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdFecha")]
		[Bindable(true)]
		public int IdFecha 
		{
			get { return GetColumnValue<int>(Columns.IdFecha); }
			set { SetColumnValue(Columns.IdFecha, value); }
		}
		  
		[XmlAttribute("Dia")]
		[Bindable(true)]
		public int? Dia 
		{
			get { return GetColumnValue<int?>(Columns.Dia); }
			set { SetColumnValue(Columns.Dia, value); }
		}
		  
		[XmlAttribute("Mes")]
		[Bindable(true)]
		public int? Mes 
		{
			get { return GetColumnValue<int?>(Columns.Mes); }
			set { SetColumnValue(Columns.Mes, value); }
		}
		  
		[XmlAttribute("Anio")]
		[Bindable(true)]
		public int? Anio 
		{
			get { return GetColumnValue<int?>(Columns.Anio); }
			set { SetColumnValue(Columns.Anio, value); }
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
		public static void Insert(int? varDia,int? varMes,int? varAnio,string varDescripcion)
		{
			PnFeriado item = new PnFeriado();
			
			item.Dia = varDia;
			
			item.Mes = varMes;
			
			item.Anio = varAnio;
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdFecha,int? varDia,int? varMes,int? varAnio,string varDescripcion)
		{
			PnFeriado item = new PnFeriado();
			
				item.IdFecha = varIdFecha;
			
				item.Dia = varDia;
			
				item.Mes = varMes;
			
				item.Anio = varAnio;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdFechaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DiaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MesColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdFecha = @"id_fecha";
			 public static string Dia = @"dia";
			 public static string Mes = @"mes";
			 public static string Anio = @"anio";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
