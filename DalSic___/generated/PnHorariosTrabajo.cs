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
	/// Strongly-typed collection for the PnHorariosTrabajo class.
	/// </summary>
    [Serializable]
	public partial class PnHorariosTrabajoCollection : ActiveList<PnHorariosTrabajo, PnHorariosTrabajoCollection>
	{	   
		public PnHorariosTrabajoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnHorariosTrabajoCollection</returns>
		public PnHorariosTrabajoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnHorariosTrabajo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_horarios_trabajo table.
	/// </summary>
	[Serializable]
	public partial class PnHorariosTrabajo : ActiveRecord<PnHorariosTrabajo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnHorariosTrabajo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnHorariosTrabajo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnHorariosTrabajo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnHorariosTrabajo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_horarios_trabajo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHorarioTrabajo = new TableSchema.TableColumn(schema);
				colvarIdHorarioTrabajo.ColumnName = "id_horario_trabajo";
				colvarIdHorarioTrabajo.DataType = DbType.Int32;
				colvarIdHorarioTrabajo.MaxLength = 0;
				colvarIdHorarioTrabajo.AutoIncrement = true;
				colvarIdHorarioTrabajo.IsNullable = false;
				colvarIdHorarioTrabajo.IsPrimaryKey = true;
				colvarIdHorarioTrabajo.IsForeignKey = false;
				colvarIdHorarioTrabajo.IsReadOnly = false;
				colvarIdHorarioTrabajo.DefaultSetting = @"";
				colvarIdHorarioTrabajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHorarioTrabajo);
				
				TableSchema.TableColumn colvarIdDia = new TableSchema.TableColumn(schema);
				colvarIdDia.ColumnName = "id_dia";
				colvarIdDia.DataType = DbType.Int32;
				colvarIdDia.MaxLength = 0;
				colvarIdDia.AutoIncrement = false;
				colvarIdDia.IsNullable = false;
				colvarIdDia.IsPrimaryKey = false;
				colvarIdDia.IsForeignKey = false;
				colvarIdDia.IsReadOnly = false;
				colvarIdDia.DefaultSetting = @"";
				colvarIdDia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDia);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
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
				
				TableSchema.TableColumn colvarTrabajaSabado = new TableSchema.TableColumn(schema);
				colvarTrabajaSabado.ColumnName = "trabaja_sabado";
				colvarTrabajaSabado.DataType = DbType.Int16;
				colvarTrabajaSabado.MaxLength = 0;
				colvarTrabajaSabado.AutoIncrement = false;
				colvarTrabajaSabado.IsNullable = true;
				colvarTrabajaSabado.IsPrimaryKey = false;
				colvarTrabajaSabado.IsForeignKey = false;
				colvarTrabajaSabado.IsReadOnly = false;
				colvarTrabajaSabado.DefaultSetting = @"";
				colvarTrabajaSabado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrabajaSabado);
				
				TableSchema.TableColumn colvarTrabajaDomingo = new TableSchema.TableColumn(schema);
				colvarTrabajaDomingo.ColumnName = "trabaja_domingo";
				colvarTrabajaDomingo.DataType = DbType.Int16;
				colvarTrabajaDomingo.MaxLength = 0;
				colvarTrabajaDomingo.AutoIncrement = false;
				colvarTrabajaDomingo.IsNullable = true;
				colvarTrabajaDomingo.IsPrimaryKey = false;
				colvarTrabajaDomingo.IsForeignKey = false;
				colvarTrabajaDomingo.IsReadOnly = false;
				colvarTrabajaDomingo.DefaultSetting = @"";
				colvarTrabajaDomingo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrabajaDomingo);
				
				TableSchema.TableColumn colvarInicioHorario = new TableSchema.TableColumn(schema);
				colvarInicioHorario.ColumnName = "inicio_horario";
				colvarInicioHorario.DataType = DbType.AnsiString;
				colvarInicioHorario.MaxLength = 16;
				colvarInicioHorario.AutoIncrement = false;
				colvarInicioHorario.IsNullable = true;
				colvarInicioHorario.IsPrimaryKey = false;
				colvarInicioHorario.IsForeignKey = false;
				colvarInicioHorario.IsReadOnly = false;
				colvarInicioHorario.DefaultSetting = @"";
				colvarInicioHorario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInicioHorario);
				
				TableSchema.TableColumn colvarFinHorario = new TableSchema.TableColumn(schema);
				colvarFinHorario.ColumnName = "fin_horario";
				colvarFinHorario.DataType = DbType.AnsiString;
				colvarFinHorario.MaxLength = 16;
				colvarFinHorario.AutoIncrement = false;
				colvarFinHorario.IsNullable = true;
				colvarFinHorario.IsPrimaryKey = false;
				colvarFinHorario.IsForeignKey = false;
				colvarFinHorario.IsReadOnly = false;
				colvarFinHorario.DefaultSetting = @"";
				colvarFinHorario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFinHorario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_horarios_trabajo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHorarioTrabajo")]
		[Bindable(true)]
		public int IdHorarioTrabajo 
		{
			get { return GetColumnValue<int>(Columns.IdHorarioTrabajo); }
			set { SetColumnValue(Columns.IdHorarioTrabajo, value); }
		}
		  
		[XmlAttribute("IdDia")]
		[Bindable(true)]
		public int IdDia 
		{
			get { return GetColumnValue<int>(Columns.IdDia); }
			set { SetColumnValue(Columns.IdDia, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("TrabajaSabado")]
		[Bindable(true)]
		public short? TrabajaSabado 
		{
			get { return GetColumnValue<short?>(Columns.TrabajaSabado); }
			set { SetColumnValue(Columns.TrabajaSabado, value); }
		}
		  
		[XmlAttribute("TrabajaDomingo")]
		[Bindable(true)]
		public short? TrabajaDomingo 
		{
			get { return GetColumnValue<short?>(Columns.TrabajaDomingo); }
			set { SetColumnValue(Columns.TrabajaDomingo, value); }
		}
		  
		[XmlAttribute("InicioHorario")]
		[Bindable(true)]
		public string InicioHorario 
		{
			get { return GetColumnValue<string>(Columns.InicioHorario); }
			set { SetColumnValue(Columns.InicioHorario, value); }
		}
		  
		[XmlAttribute("FinHorario")]
		[Bindable(true)]
		public string FinHorario 
		{
			get { return GetColumnValue<string>(Columns.FinHorario); }
			set { SetColumnValue(Columns.FinHorario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdDia,int varIdUsuario,short? varTrabajaSabado,short? varTrabajaDomingo,string varInicioHorario,string varFinHorario)
		{
			PnHorariosTrabajo item = new PnHorariosTrabajo();
			
			item.IdDia = varIdDia;
			
			item.IdUsuario = varIdUsuario;
			
			item.TrabajaSabado = varTrabajaSabado;
			
			item.TrabajaDomingo = varTrabajaDomingo;
			
			item.InicioHorario = varInicioHorario;
			
			item.FinHorario = varFinHorario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdHorarioTrabajo,int varIdDia,int varIdUsuario,short? varTrabajaSabado,short? varTrabajaDomingo,string varInicioHorario,string varFinHorario)
		{
			PnHorariosTrabajo item = new PnHorariosTrabajo();
			
				item.IdHorarioTrabajo = varIdHorarioTrabajo;
			
				item.IdDia = varIdDia;
			
				item.IdUsuario = varIdUsuario;
			
				item.TrabajaSabado = varTrabajaSabado;
			
				item.TrabajaDomingo = varTrabajaDomingo;
			
				item.InicioHorario = varInicioHorario;
			
				item.FinHorario = varFinHorario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHorarioTrabajoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDiaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TrabajaSabadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TrabajaDomingoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn InicioHorarioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FinHorarioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHorarioTrabajo = @"id_horario_trabajo";
			 public static string IdDia = @"id_dia";
			 public static string IdUsuario = @"id_usuario";
			 public static string TrabajaSabado = @"trabaja_sabado";
			 public static string TrabajaDomingo = @"trabaja_domingo";
			 public static string InicioHorario = @"inicio_horario";
			 public static string FinHorario = @"fin_horario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
