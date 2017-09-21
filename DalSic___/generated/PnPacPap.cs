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
	/// Strongly-typed collection for the PnPacPap class.
	/// </summary>
    [Serializable]
	public partial class PnPacPapCollection : ActiveList<PnPacPap, PnPacPapCollection>
	{	   
		public PnPacPapCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPacPapCollection</returns>
		public PnPacPapCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPacPap o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_pac_pap table.
	/// </summary>
	[Serializable]
	public partial class PnPacPap : ActiveRecord<PnPacPap>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPacPap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPacPap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPacPap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPacPap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_pac_pap", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPacPap = new TableSchema.TableColumn(schema);
				colvarIdPacPap.ColumnName = "id_pac_pap";
				colvarIdPacPap.DataType = DbType.Int32;
				colvarIdPacPap.MaxLength = 0;
				colvarIdPacPap.AutoIncrement = true;
				colvarIdPacPap.IsNullable = false;
				colvarIdPacPap.IsPrimaryKey = true;
				colvarIdPacPap.IsForeignKey = false;
				colvarIdPacPap.IsReadOnly = false;
				colvarIdPacPap.DefaultSetting = @"";
				colvarIdPacPap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPacPap);
				
				TableSchema.TableColumn colvarIdNoConformidad = new TableSchema.TableColumn(schema);
				colvarIdNoConformidad.ColumnName = "id_no_conformidad";
				colvarIdNoConformidad.DataType = DbType.Int32;
				colvarIdNoConformidad.MaxLength = 0;
				colvarIdNoConformidad.AutoIncrement = false;
				colvarIdNoConformidad.IsNullable = false;
				colvarIdNoConformidad.IsPrimaryKey = false;
				colvarIdNoConformidad.IsForeignKey = false;
				colvarIdNoConformidad.IsReadOnly = false;
				colvarIdNoConformidad.DefaultSetting = @"";
				colvarIdNoConformidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNoConformidad);
				
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
				
				TableSchema.TableColumn colvarAccionCorrectiva = new TableSchema.TableColumn(schema);
				colvarAccionCorrectiva.ColumnName = "accion_correctiva";
				colvarAccionCorrectiva.DataType = DbType.AnsiString;
				colvarAccionCorrectiva.MaxLength = -1;
				colvarAccionCorrectiva.AutoIncrement = false;
				colvarAccionCorrectiva.IsNullable = true;
				colvarAccionCorrectiva.IsPrimaryKey = false;
				colvarAccionCorrectiva.IsForeignKey = false;
				colvarAccionCorrectiva.IsReadOnly = false;
				colvarAccionCorrectiva.DefaultSetting = @"";
				colvarAccionCorrectiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccionCorrectiva);
				
				TableSchema.TableColumn colvarEvaluacionEficacia = new TableSchema.TableColumn(schema);
				colvarEvaluacionEficacia.ColumnName = "evaluacion_eficacia";
				colvarEvaluacionEficacia.DataType = DbType.AnsiString;
				colvarEvaluacionEficacia.MaxLength = -1;
				colvarEvaluacionEficacia.AutoIncrement = false;
				colvarEvaluacionEficacia.IsNullable = true;
				colvarEvaluacionEficacia.IsPrimaryKey = false;
				colvarEvaluacionEficacia.IsForeignKey = false;
				colvarEvaluacionEficacia.IsReadOnly = false;
				colvarEvaluacionEficacia.DefaultSetting = @"";
				colvarEvaluacionEficacia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEvaluacionEficacia);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.Int16;
				colvarTipo.MaxLength = 0;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
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
				
				TableSchema.TableColumn colvarFechaCierre = new TableSchema.TableColumn(schema);
				colvarFechaCierre.ColumnName = "fecha_cierre";
				colvarFechaCierre.DataType = DbType.DateTime;
				colvarFechaCierre.MaxLength = 0;
				colvarFechaCierre.AutoIncrement = false;
				colvarFechaCierre.IsNullable = true;
				colvarFechaCierre.IsPrimaryKey = false;
				colvarFechaCierre.IsForeignKey = false;
				colvarFechaCierre.IsReadOnly = false;
				colvarFechaCierre.DefaultSetting = @"";
				colvarFechaCierre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCierre);
				
				TableSchema.TableColumn colvarAccionInmediata = new TableSchema.TableColumn(schema);
				colvarAccionInmediata.ColumnName = "accion_inmediata";
				colvarAccionInmediata.DataType = DbType.AnsiString;
				colvarAccionInmediata.MaxLength = -1;
				colvarAccionInmediata.AutoIncrement = false;
				colvarAccionInmediata.IsNullable = true;
				colvarAccionInmediata.IsPrimaryKey = false;
				colvarAccionInmediata.IsForeignKey = false;
				colvarAccionInmediata.IsReadOnly = false;
				colvarAccionInmediata.DefaultSetting = @"";
				colvarAccionInmediata.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccionInmediata);
				
				TableSchema.TableColumn colvarCausaNc = new TableSchema.TableColumn(schema);
				colvarCausaNc.ColumnName = "causa_nc";
				colvarCausaNc.DataType = DbType.AnsiString;
				colvarCausaNc.MaxLength = -1;
				colvarCausaNc.AutoIncrement = false;
				colvarCausaNc.IsNullable = true;
				colvarCausaNc.IsPrimaryKey = false;
				colvarCausaNc.IsForeignKey = false;
				colvarCausaNc.IsReadOnly = false;
				colvarCausaNc.DefaultSetting = @"";
				colvarCausaNc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCausaNc);
				
				TableSchema.TableColumn colvarVerificacion = new TableSchema.TableColumn(schema);
				colvarVerificacion.ColumnName = "verificacion";
				colvarVerificacion.DataType = DbType.Int16;
				colvarVerificacion.MaxLength = 0;
				colvarVerificacion.AutoIncrement = false;
				colvarVerificacion.IsNullable = true;
				colvarVerificacion.IsPrimaryKey = false;
				colvarVerificacion.IsForeignKey = false;
				colvarVerificacion.IsReadOnly = false;
				colvarVerificacion.DefaultSetting = @"";
				colvarVerificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVerificacion);
				
				TableSchema.TableColumn colvarFechaVerificacion = new TableSchema.TableColumn(schema);
				colvarFechaVerificacion.ColumnName = "fecha_verificacion";
				colvarFechaVerificacion.DataType = DbType.DateTime;
				colvarFechaVerificacion.MaxLength = 0;
				colvarFechaVerificacion.AutoIncrement = false;
				colvarFechaVerificacion.IsNullable = true;
				colvarFechaVerificacion.IsPrimaryKey = false;
				colvarFechaVerificacion.IsForeignKey = false;
				colvarFechaVerificacion.IsReadOnly = false;
				colvarFechaVerificacion.DefaultSetting = @"";
				colvarFechaVerificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaVerificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_pac_pap",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPacPap")]
		[Bindable(true)]
		public int IdPacPap 
		{
			get { return GetColumnValue<int>(Columns.IdPacPap); }
			set { SetColumnValue(Columns.IdPacPap, value); }
		}
		  
		[XmlAttribute("IdNoConformidad")]
		[Bindable(true)]
		public int IdNoConformidad 
		{
			get { return GetColumnValue<int>(Columns.IdNoConformidad); }
			set { SetColumnValue(Columns.IdNoConformidad, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("AccionCorrectiva")]
		[Bindable(true)]
		public string AccionCorrectiva 
		{
			get { return GetColumnValue<string>(Columns.AccionCorrectiva); }
			set { SetColumnValue(Columns.AccionCorrectiva, value); }
		}
		  
		[XmlAttribute("EvaluacionEficacia")]
		[Bindable(true)]
		public string EvaluacionEficacia 
		{
			get { return GetColumnValue<string>(Columns.EvaluacionEficacia); }
			set { SetColumnValue(Columns.EvaluacionEficacia, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public short? Tipo 
		{
			get { return GetColumnValue<short?>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Area")]
		[Bindable(true)]
		public string Area 
		{
			get { return GetColumnValue<string>(Columns.Area); }
			set { SetColumnValue(Columns.Area, value); }
		}
		  
		[XmlAttribute("FechaCierre")]
		[Bindable(true)]
		public DateTime? FechaCierre 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCierre); }
			set { SetColumnValue(Columns.FechaCierre, value); }
		}
		  
		[XmlAttribute("AccionInmediata")]
		[Bindable(true)]
		public string AccionInmediata 
		{
			get { return GetColumnValue<string>(Columns.AccionInmediata); }
			set { SetColumnValue(Columns.AccionInmediata, value); }
		}
		  
		[XmlAttribute("CausaNc")]
		[Bindable(true)]
		public string CausaNc 
		{
			get { return GetColumnValue<string>(Columns.CausaNc); }
			set { SetColumnValue(Columns.CausaNc, value); }
		}
		  
		[XmlAttribute("Verificacion")]
		[Bindable(true)]
		public short? Verificacion 
		{
			get { return GetColumnValue<short?>(Columns.Verificacion); }
			set { SetColumnValue(Columns.Verificacion, value); }
		}
		  
		[XmlAttribute("FechaVerificacion")]
		[Bindable(true)]
		public DateTime? FechaVerificacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaVerificacion); }
			set { SetColumnValue(Columns.FechaVerificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdNoConformidad,string varDescripcion,string varAccionCorrectiva,string varEvaluacionEficacia,short? varTipo,DateTime? varFecha,string varArea,DateTime? varFechaCierre,string varAccionInmediata,string varCausaNc,short? varVerificacion,DateTime? varFechaVerificacion)
		{
			PnPacPap item = new PnPacPap();
			
			item.IdNoConformidad = varIdNoConformidad;
			
			item.Descripcion = varDescripcion;
			
			item.AccionCorrectiva = varAccionCorrectiva;
			
			item.EvaluacionEficacia = varEvaluacionEficacia;
			
			item.Tipo = varTipo;
			
			item.Fecha = varFecha;
			
			item.Area = varArea;
			
			item.FechaCierre = varFechaCierre;
			
			item.AccionInmediata = varAccionInmediata;
			
			item.CausaNc = varCausaNc;
			
			item.Verificacion = varVerificacion;
			
			item.FechaVerificacion = varFechaVerificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPacPap,int varIdNoConformidad,string varDescripcion,string varAccionCorrectiva,string varEvaluacionEficacia,short? varTipo,DateTime? varFecha,string varArea,DateTime? varFechaCierre,string varAccionInmediata,string varCausaNc,short? varVerificacion,DateTime? varFechaVerificacion)
		{
			PnPacPap item = new PnPacPap();
			
				item.IdPacPap = varIdPacPap;
			
				item.IdNoConformidad = varIdNoConformidad;
			
				item.Descripcion = varDescripcion;
			
				item.AccionCorrectiva = varAccionCorrectiva;
			
				item.EvaluacionEficacia = varEvaluacionEficacia;
			
				item.Tipo = varTipo;
			
				item.Fecha = varFecha;
			
				item.Area = varArea;
			
				item.FechaCierre = varFechaCierre;
			
				item.AccionInmediata = varAccionInmediata;
			
				item.CausaNc = varCausaNc;
			
				item.Verificacion = varVerificacion;
			
				item.FechaVerificacion = varFechaVerificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPacPapColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNoConformidadColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AccionCorrectivaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EvaluacionEficaciaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCierreColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AccionInmediataColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CausaNcColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn VerificacionColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaVerificacionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPacPap = @"id_pac_pap";
			 public static string IdNoConformidad = @"id_no_conformidad";
			 public static string Descripcion = @"descripcion";
			 public static string AccionCorrectiva = @"accion_correctiva";
			 public static string EvaluacionEficacia = @"evaluacion_eficacia";
			 public static string Tipo = @"tipo";
			 public static string Fecha = @"fecha";
			 public static string Area = @"area";
			 public static string FechaCierre = @"fecha_cierre";
			 public static string AccionInmediata = @"accion_inmediata";
			 public static string CausaNc = @"causa_nc";
			 public static string Verificacion = @"verificacion";
			 public static string FechaVerificacion = @"fecha_verificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
