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
	/// Strongly-typed collection for the PnAusentismo class.
	/// </summary>
    [Serializable]
	public partial class PnAusentismoCollection : ActiveList<PnAusentismo, PnAusentismoCollection>
	{	   
		public PnAusentismoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAusentismoCollection</returns>
		public PnAusentismoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAusentismo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_ausentismo table.
	/// </summary>
	[Serializable]
	public partial class PnAusentismo : ActiveRecord<PnAusentismo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAusentismo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAusentismo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAusentismo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAusentismo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_ausentismo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = true;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = true;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarAgno = new TableSchema.TableColumn(schema);
				colvarAgno.ColumnName = "agno";
				colvarAgno.DataType = DbType.Int16;
				colvarAgno.MaxLength = 0;
				colvarAgno.AutoIncrement = false;
				colvarAgno.IsNullable = false;
				colvarAgno.IsPrimaryKey = false;
				colvarAgno.IsForeignKey = false;
				colvarAgno.IsReadOnly = false;
				colvarAgno.DefaultSetting = @"";
				colvarAgno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAgno);
				
				TableSchema.TableColumn colvarInpuntualidad = new TableSchema.TableColumn(schema);
				colvarInpuntualidad.ColumnName = "inpuntualidad";
				colvarInpuntualidad.DataType = DbType.Int16;
				colvarInpuntualidad.MaxLength = 0;
				colvarInpuntualidad.AutoIncrement = false;
				colvarInpuntualidad.IsNullable = false;
				colvarInpuntualidad.IsPrimaryKey = false;
				colvarInpuntualidad.IsForeignKey = false;
				colvarInpuntualidad.IsReadOnly = false;
				colvarInpuntualidad.DefaultSetting = @"";
				colvarInpuntualidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInpuntualidad);
				
				TableSchema.TableColumn colvarInasistencia = new TableSchema.TableColumn(schema);
				colvarInasistencia.ColumnName = "inasistencia";
				colvarInasistencia.DataType = DbType.Int16;
				colvarInasistencia.MaxLength = 0;
				colvarInasistencia.AutoIncrement = false;
				colvarInasistencia.IsNullable = false;
				colvarInasistencia.IsPrimaryKey = false;
				colvarInasistencia.IsForeignKey = false;
				colvarInasistencia.IsReadOnly = false;
				colvarInasistencia.DefaultSetting = @"";
				colvarInasistencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInasistencia);
				
				TableSchema.TableColumn colvarEnfermedad = new TableSchema.TableColumn(schema);
				colvarEnfermedad.ColumnName = "enfermedad";
				colvarEnfermedad.DataType = DbType.Int16;
				colvarEnfermedad.MaxLength = 0;
				colvarEnfermedad.AutoIncrement = false;
				colvarEnfermedad.IsNullable = false;
				colvarEnfermedad.IsPrimaryKey = false;
				colvarEnfermedad.IsForeignKey = false;
				colvarEnfermedad.IsReadOnly = false;
				colvarEnfermedad.DefaultSetting = @"";
				colvarEnfermedad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnfermedad);
				
				TableSchema.TableColumn colvarAccidente = new TableSchema.TableColumn(schema);
				colvarAccidente.ColumnName = "accidente";
				colvarAccidente.DataType = DbType.Int16;
				colvarAccidente.MaxLength = 0;
				colvarAccidente.AutoIncrement = false;
				colvarAccidente.IsNullable = false;
				colvarAccidente.IsPrimaryKey = false;
				colvarAccidente.IsForeignKey = false;
				colvarAccidente.IsReadOnly = false;
				colvarAccidente.DefaultSetting = @"";
				colvarAccidente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccidente);
				
				TableSchema.TableColumn colvarLicencias = new TableSchema.TableColumn(schema);
				colvarLicencias.ColumnName = "licencias";
				colvarLicencias.DataType = DbType.Int16;
				colvarLicencias.MaxLength = 0;
				colvarLicencias.AutoIncrement = false;
				colvarLicencias.IsNullable = false;
				colvarLicencias.IsPrimaryKey = false;
				colvarLicencias.IsForeignKey = false;
				colvarLicencias.IsReadOnly = false;
				colvarLicencias.DefaultSetting = @"";
				colvarLicencias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLicencias);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_ausentismo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("Agno")]
		[Bindable(true)]
		public short Agno 
		{
			get { return GetColumnValue<short>(Columns.Agno); }
			set { SetColumnValue(Columns.Agno, value); }
		}
		  
		[XmlAttribute("Inpuntualidad")]
		[Bindable(true)]
		public short Inpuntualidad 
		{
			get { return GetColumnValue<short>(Columns.Inpuntualidad); }
			set { SetColumnValue(Columns.Inpuntualidad, value); }
		}
		  
		[XmlAttribute("Inasistencia")]
		[Bindable(true)]
		public short Inasistencia 
		{
			get { return GetColumnValue<short>(Columns.Inasistencia); }
			set { SetColumnValue(Columns.Inasistencia, value); }
		}
		  
		[XmlAttribute("Enfermedad")]
		[Bindable(true)]
		public short Enfermedad 
		{
			get { return GetColumnValue<short>(Columns.Enfermedad); }
			set { SetColumnValue(Columns.Enfermedad, value); }
		}
		  
		[XmlAttribute("Accidente")]
		[Bindable(true)]
		public short Accidente 
		{
			get { return GetColumnValue<short>(Columns.Accidente); }
			set { SetColumnValue(Columns.Accidente, value); }
		}
		  
		[XmlAttribute("Licencias")]
		[Bindable(true)]
		public short Licencias 
		{
			get { return GetColumnValue<short>(Columns.Licencias); }
			set { SetColumnValue(Columns.Licencias, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(short varAgno,short varInpuntualidad,short varInasistencia,short varEnfermedad,short varAccidente,short varLicencias)
		{
			PnAusentismo item = new PnAusentismo();
			
			item.Agno = varAgno;
			
			item.Inpuntualidad = varInpuntualidad;
			
			item.Inasistencia = varInasistencia;
			
			item.Enfermedad = varEnfermedad;
			
			item.Accidente = varAccidente;
			
			item.Licencias = varLicencias;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLegajo,short varAgno,short varInpuntualidad,short varInasistencia,short varEnfermedad,short varAccidente,short varLicencias)
		{
			PnAusentismo item = new PnAusentismo();
			
				item.IdLegajo = varIdLegajo;
			
				item.Agno = varAgno;
			
				item.Inpuntualidad = varInpuntualidad;
			
				item.Inasistencia = varInasistencia;
			
				item.Enfermedad = varEnfermedad;
			
				item.Accidente = varAccidente;
			
				item.Licencias = varLicencias;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AgnoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn InpuntualidadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn InasistenciaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EnfermedadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AccidenteColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn LicenciasColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLegajo = @"id_legajo";
			 public static string Agno = @"agno";
			 public static string Inpuntualidad = @"inpuntualidad";
			 public static string Inasistencia = @"inasistencia";
			 public static string Enfermedad = @"enfermedad";
			 public static string Accidente = @"accidente";
			 public static string Licencias = @"licencias";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
