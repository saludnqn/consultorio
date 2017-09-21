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
	/// Strongly-typed collection for the ConAgendaGrupal class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaGrupalCollection : ActiveList<ConAgendaGrupal, ConAgendaGrupalCollection>
	{	   
		public ConAgendaGrupalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaGrupalCollection</returns>
		public ConAgendaGrupalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgendaGrupal o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_AgendaGrupal table.
	/// </summary>
	[Serializable]
	public partial class ConAgendaGrupal : ActiveRecord<ConAgendaGrupal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgendaGrupal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgendaGrupal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgendaGrupal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgendaGrupal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_AgendaGrupal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgendaGrupal = new TableSchema.TableColumn(schema);
				colvarIdAgendaGrupal.ColumnName = "idAgendaGrupal";
				colvarIdAgendaGrupal.DataType = DbType.Int32;
				colvarIdAgendaGrupal.MaxLength = 0;
				colvarIdAgendaGrupal.AutoIncrement = true;
				colvarIdAgendaGrupal.IsNullable = false;
				colvarIdAgendaGrupal.IsPrimaryKey = true;
				colvarIdAgendaGrupal.IsForeignKey = false;
				colvarIdAgendaGrupal.IsReadOnly = false;
				colvarIdAgendaGrupal.DefaultSetting = @"";
				colvarIdAgendaGrupal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgendaGrupal);
				
				TableSchema.TableColumn colvarIdAgendaEstado = new TableSchema.TableColumn(schema);
				colvarIdAgendaEstado.ColumnName = "idAgendaEstado";
				colvarIdAgendaEstado.DataType = DbType.Int32;
				colvarIdAgendaEstado.MaxLength = 0;
				colvarIdAgendaEstado.AutoIncrement = false;
				colvarIdAgendaEstado.IsNullable = false;
				colvarIdAgendaEstado.IsPrimaryKey = false;
				colvarIdAgendaEstado.IsForeignKey = true;
				colvarIdAgendaEstado.IsReadOnly = false;
				
						colvarIdAgendaEstado.DefaultSetting = @"((1))";
				
					colvarIdAgendaEstado.ForeignKeyTableName = "CON_AgendaEstado";
				schema.Columns.Add(colvarIdAgendaEstado);
				
				TableSchema.TableColumn colvarIdMotivoInactivacion = new TableSchema.TableColumn(schema);
				colvarIdMotivoInactivacion.ColumnName = "idMotivoInactivacion";
				colvarIdMotivoInactivacion.DataType = DbType.Int32;
				colvarIdMotivoInactivacion.MaxLength = 0;
				colvarIdMotivoInactivacion.AutoIncrement = false;
				colvarIdMotivoInactivacion.IsNullable = true;
				colvarIdMotivoInactivacion.IsPrimaryKey = false;
				colvarIdMotivoInactivacion.IsForeignKey = true;
				colvarIdMotivoInactivacion.IsReadOnly = false;
				colvarIdMotivoInactivacion.DefaultSetting = @"";
				
					colvarIdMotivoInactivacion.ForeignKeyTableName = "CON_MotivoInactivacionAgenda";
				schema.Columns.Add(colvarIdMotivoInactivacion);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdTematica = new TableSchema.TableColumn(schema);
				colvarIdTematica.ColumnName = "idTematica";
				colvarIdTematica.DataType = DbType.Int32;
				colvarIdTematica.MaxLength = 0;
				colvarIdTematica.AutoIncrement = false;
				colvarIdTematica.IsNullable = false;
				colvarIdTematica.IsPrimaryKey = false;
				colvarIdTematica.IsForeignKey = true;
				colvarIdTematica.IsReadOnly = false;
				colvarIdTematica.DefaultSetting = @"";
				
					colvarIdTematica.ForeignKeyTableName = "CON_Tematica";
				schema.Columns.Add(colvarIdTematica);
				
				TableSchema.TableColumn colvarTematicaOtra = new TableSchema.TableColumn(schema);
				colvarTematicaOtra.ColumnName = "tematicaOtra";
				colvarTematicaOtra.DataType = DbType.AnsiString;
				colvarTematicaOtra.MaxLength = 200;
				colvarTematicaOtra.AutoIncrement = false;
				colvarTematicaOtra.IsNullable = true;
				colvarTematicaOtra.IsPrimaryKey = false;
				colvarTematicaOtra.IsForeignKey = false;
				colvarTematicaOtra.IsReadOnly = false;
				
						colvarTematicaOtra.DefaultSetting = @"('')";
				colvarTematicaOtra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTematicaOtra);
				
				TableSchema.TableColumn colvarIdTipoActividadGrupal = new TableSchema.TableColumn(schema);
				colvarIdTipoActividadGrupal.ColumnName = "idTipoActividadGrupal";
				colvarIdTipoActividadGrupal.DataType = DbType.Int32;
				colvarIdTipoActividadGrupal.MaxLength = 0;
				colvarIdTipoActividadGrupal.AutoIncrement = false;
				colvarIdTipoActividadGrupal.IsNullable = false;
				colvarIdTipoActividadGrupal.IsPrimaryKey = false;
				colvarIdTipoActividadGrupal.IsForeignKey = true;
				colvarIdTipoActividadGrupal.IsReadOnly = false;
				colvarIdTipoActividadGrupal.DefaultSetting = @"";
				
					colvarIdTipoActividadGrupal.ForeignKeyTableName = "CON_TipoActividadGrupal";
				schema.Columns.Add(colvarIdTipoActividadGrupal);
				
				TableSchema.TableColumn colvarTipoActividadGrupalOtro = new TableSchema.TableColumn(schema);
				colvarTipoActividadGrupalOtro.ColumnName = "tipoActividadGrupalOtro";
				colvarTipoActividadGrupalOtro.DataType = DbType.AnsiString;
				colvarTipoActividadGrupalOtro.MaxLength = 200;
				colvarTipoActividadGrupalOtro.AutoIncrement = false;
				colvarTipoActividadGrupalOtro.IsNullable = true;
				colvarTipoActividadGrupalOtro.IsPrimaryKey = false;
				colvarTipoActividadGrupalOtro.IsForeignKey = false;
				colvarTipoActividadGrupalOtro.IsReadOnly = false;
				
						colvarTipoActividadGrupalOtro.DefaultSetting = @"('')";
				colvarTipoActividadGrupalOtro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoActividadGrupalOtro);
				
				TableSchema.TableColumn colvarIdLugarActividadGrupal = new TableSchema.TableColumn(schema);
				colvarIdLugarActividadGrupal.ColumnName = "idLugarActividadGrupal";
				colvarIdLugarActividadGrupal.DataType = DbType.Int32;
				colvarIdLugarActividadGrupal.MaxLength = 0;
				colvarIdLugarActividadGrupal.AutoIncrement = false;
				colvarIdLugarActividadGrupal.IsNullable = false;
				colvarIdLugarActividadGrupal.IsPrimaryKey = false;
				colvarIdLugarActividadGrupal.IsForeignKey = true;
				colvarIdLugarActividadGrupal.IsReadOnly = false;
				colvarIdLugarActividadGrupal.DefaultSetting = @"";
				
					colvarIdLugarActividadGrupal.ForeignKeyTableName = "CON_LugarActividadGrupal";
				schema.Columns.Add(colvarIdLugarActividadGrupal);
				
				TableSchema.TableColumn colvarLugarActividadGrupalOtro = new TableSchema.TableColumn(schema);
				colvarLugarActividadGrupalOtro.ColumnName = "lugarActividadGrupalOtro";
				colvarLugarActividadGrupalOtro.DataType = DbType.AnsiString;
				colvarLugarActividadGrupalOtro.MaxLength = 200;
				colvarLugarActividadGrupalOtro.AutoIncrement = false;
				colvarLugarActividadGrupalOtro.IsNullable = true;
				colvarLugarActividadGrupalOtro.IsPrimaryKey = false;
				colvarLugarActividadGrupalOtro.IsForeignKey = false;
				colvarLugarActividadGrupalOtro.IsReadOnly = false;
				
						colvarLugarActividadGrupalOtro.DefaultSetting = @"('')";
				colvarLugarActividadGrupalOtro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLugarActividadGrupalOtro);
				
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
				
				TableSchema.TableColumn colvarHoraInicio = new TableSchema.TableColumn(schema);
				colvarHoraInicio.ColumnName = "horaInicio";
				colvarHoraInicio.DataType = DbType.AnsiString;
				colvarHoraInicio.MaxLength = 5;
				colvarHoraInicio.AutoIncrement = false;
				colvarHoraInicio.IsNullable = false;
				colvarHoraInicio.IsPrimaryKey = false;
				colvarHoraInicio.IsForeignKey = false;
				colvarHoraInicio.IsReadOnly = false;
				colvarHoraInicio.DefaultSetting = @"";
				colvarHoraInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraInicio);
				
				TableSchema.TableColumn colvarHoraFin = new TableSchema.TableColumn(schema);
				colvarHoraFin.ColumnName = "horaFin";
				colvarHoraFin.DataType = DbType.AnsiString;
				colvarHoraFin.MaxLength = 5;
				colvarHoraFin.AutoIncrement = false;
				colvarHoraFin.IsNullable = false;
				colvarHoraFin.IsPrimaryKey = false;
				colvarHoraFin.IsForeignKey = false;
				colvarHoraFin.IsReadOnly = false;
				colvarHoraFin.DefaultSetting = @"";
				colvarHoraFin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraFin);
				
				TableSchema.TableColumn colvarCantidadAsistentes = new TableSchema.TableColumn(schema);
				colvarCantidadAsistentes.ColumnName = "cantidadAsistentes";
				colvarCantidadAsistentes.DataType = DbType.Int32;
				colvarCantidadAsistentes.MaxLength = 0;
				colvarCantidadAsistentes.AutoIncrement = false;
				colvarCantidadAsistentes.IsNullable = true;
				colvarCantidadAsistentes.IsPrimaryKey = false;
				colvarCantidadAsistentes.IsForeignKey = false;
				colvarCantidadAsistentes.IsReadOnly = false;
				
						colvarCantidadAsistentes.DefaultSetting = @"((0))";
				colvarCantidadAsistentes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadAsistentes);
				
				TableSchema.TableColumn colvarOtrosOrganismos = new TableSchema.TableColumn(schema);
				colvarOtrosOrganismos.ColumnName = "otrosOrganismos";
				colvarOtrosOrganismos.DataType = DbType.AnsiString;
				colvarOtrosOrganismos.MaxLength = 200;
				colvarOtrosOrganismos.AutoIncrement = false;
				colvarOtrosOrganismos.IsNullable = true;
				colvarOtrosOrganismos.IsPrimaryKey = false;
				colvarOtrosOrganismos.IsForeignKey = false;
				colvarOtrosOrganismos.IsReadOnly = false;
				colvarOtrosOrganismos.DefaultSetting = @"";
				colvarOtrosOrganismos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrosOrganismos);
				
				TableSchema.TableColumn colvarIdConsultorio = new TableSchema.TableColumn(schema);
				colvarIdConsultorio.ColumnName = "idConsultorio";
				colvarIdConsultorio.DataType = DbType.Int32;
				colvarIdConsultorio.MaxLength = 0;
				colvarIdConsultorio.AutoIncrement = false;
				colvarIdConsultorio.IsNullable = true;
				colvarIdConsultorio.IsPrimaryKey = false;
				colvarIdConsultorio.IsForeignKey = true;
				colvarIdConsultorio.IsReadOnly = false;
				colvarIdConsultorio.DefaultSetting = @"";
				
					colvarIdConsultorio.ForeignKeyTableName = "CON_Consultorio";
				schema.Columns.Add(colvarIdConsultorio);
				
				TableSchema.TableColumn colvarResumenActividad = new TableSchema.TableColumn(schema);
				colvarResumenActividad.ColumnName = "resumenActividad";
				colvarResumenActividad.DataType = DbType.AnsiString;
				colvarResumenActividad.MaxLength = 6000;
				colvarResumenActividad.AutoIncrement = false;
				colvarResumenActividad.IsNullable = true;
				colvarResumenActividad.IsPrimaryKey = false;
				colvarResumenActividad.IsForeignKey = false;
				colvarResumenActividad.IsReadOnly = false;
				colvarResumenActividad.DefaultSetting = @"";
				colvarResumenActividad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResumenActividad);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_AgendaGrupal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgendaGrupal")]
		[Bindable(true)]
		public int IdAgendaGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaGrupal); }
			set { SetColumnValue(Columns.IdAgendaGrupal, value); }
		}
		  
		[XmlAttribute("IdAgendaEstado")]
		[Bindable(true)]
		public int IdAgendaEstado 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaEstado); }
			set { SetColumnValue(Columns.IdAgendaEstado, value); }
		}
		  
		[XmlAttribute("IdMotivoInactivacion")]
		[Bindable(true)]
		public int? IdMotivoInactivacion 
		{
			get { return GetColumnValue<int?>(Columns.IdMotivoInactivacion); }
			set { SetColumnValue(Columns.IdMotivoInactivacion, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdTematica")]
		[Bindable(true)]
		public int IdTematica 
		{
			get { return GetColumnValue<int>(Columns.IdTematica); }
			set { SetColumnValue(Columns.IdTematica, value); }
		}
		  
		[XmlAttribute("TematicaOtra")]
		[Bindable(true)]
		public string TematicaOtra 
		{
			get { return GetColumnValue<string>(Columns.TematicaOtra); }
			set { SetColumnValue(Columns.TematicaOtra, value); }
		}
		  
		[XmlAttribute("IdTipoActividadGrupal")]
		[Bindable(true)]
		public int IdTipoActividadGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdTipoActividadGrupal); }
			set { SetColumnValue(Columns.IdTipoActividadGrupal, value); }
		}
		  
		[XmlAttribute("TipoActividadGrupalOtro")]
		[Bindable(true)]
		public string TipoActividadGrupalOtro 
		{
			get { return GetColumnValue<string>(Columns.TipoActividadGrupalOtro); }
			set { SetColumnValue(Columns.TipoActividadGrupalOtro, value); }
		}
		  
		[XmlAttribute("IdLugarActividadGrupal")]
		[Bindable(true)]
		public int IdLugarActividadGrupal 
		{
			get { return GetColumnValue<int>(Columns.IdLugarActividadGrupal); }
			set { SetColumnValue(Columns.IdLugarActividadGrupal, value); }
		}
		  
		[XmlAttribute("LugarActividadGrupalOtro")]
		[Bindable(true)]
		public string LugarActividadGrupalOtro 
		{
			get { return GetColumnValue<string>(Columns.LugarActividadGrupalOtro); }
			set { SetColumnValue(Columns.LugarActividadGrupalOtro, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("HoraInicio")]
		[Bindable(true)]
		public string HoraInicio 
		{
			get { return GetColumnValue<string>(Columns.HoraInicio); }
			set { SetColumnValue(Columns.HoraInicio, value); }
		}
		  
		[XmlAttribute("HoraFin")]
		[Bindable(true)]
		public string HoraFin 
		{
			get { return GetColumnValue<string>(Columns.HoraFin); }
			set { SetColumnValue(Columns.HoraFin, value); }
		}
		  
		[XmlAttribute("CantidadAsistentes")]
		[Bindable(true)]
		public int? CantidadAsistentes 
		{
			get { return GetColumnValue<int?>(Columns.CantidadAsistentes); }
			set { SetColumnValue(Columns.CantidadAsistentes, value); }
		}
		  
		[XmlAttribute("OtrosOrganismos")]
		[Bindable(true)]
		public string OtrosOrganismos 
		{
			get { return GetColumnValue<string>(Columns.OtrosOrganismos); }
			set { SetColumnValue(Columns.OtrosOrganismos, value); }
		}
		  
		[XmlAttribute("IdConsultorio")]
		[Bindable(true)]
		public int? IdConsultorio 
		{
			get { return GetColumnValue<int?>(Columns.IdConsultorio); }
			set { SetColumnValue(Columns.IdConsultorio, value); }
		}
		  
		[XmlAttribute("ResumenActividad")]
		[Bindable(true)]
		public string ResumenActividad 
		{
			get { return GetColumnValue<string>(Columns.ResumenActividad); }
			set { SetColumnValue(Columns.ResumenActividad, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.ConAgendaGrupalOrganismoCollection colConAgendaGrupalOrganismoRecords;
		public DalSic.ConAgendaGrupalOrganismoCollection ConAgendaGrupalOrganismoRecords
		{
			get
			{
				if(colConAgendaGrupalOrganismoRecords == null)
				{
					colConAgendaGrupalOrganismoRecords = new DalSic.ConAgendaGrupalOrganismoCollection().Where(ConAgendaGrupalOrganismo.Columns.IdAgendaGrupal, IdAgendaGrupal).Load();
					colConAgendaGrupalOrganismoRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalOrganismoRecords_ListChanged);
				}
				return colConAgendaGrupalOrganismoRecords;			
			}
			set 
			{ 
					colConAgendaGrupalOrganismoRecords = value; 
					colConAgendaGrupalOrganismoRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalOrganismoRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalOrganismoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalOrganismoRecords[e.NewIndex].IdAgendaGrupal = IdAgendaGrupal;
		    }
		}
				
		private DalSic.ConAgendaGrupalProfesionalCollection colConAgendaGrupalProfesionalRecords;
		public DalSic.ConAgendaGrupalProfesionalCollection ConAgendaGrupalProfesionalRecords
		{
			get
			{
				if(colConAgendaGrupalProfesionalRecords == null)
				{
					colConAgendaGrupalProfesionalRecords = new DalSic.ConAgendaGrupalProfesionalCollection().Where(ConAgendaGrupalProfesional.Columns.IdAgendaGrupal, IdAgendaGrupal).Load();
					colConAgendaGrupalProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalProfesionalRecords_ListChanged);
				}
				return colConAgendaGrupalProfesionalRecords;			
			}
			set 
			{ 
					colConAgendaGrupalProfesionalRecords = value; 
					colConAgendaGrupalProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalProfesionalRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalProfesionalRecords[e.NewIndex].IdAgendaGrupal = IdAgendaGrupal;
		    }
		}
				
		private DalSic.ConAgendaGrupalPacienteCollection colConAgendaGrupalPacienteRecords;
		public DalSic.ConAgendaGrupalPacienteCollection ConAgendaGrupalPacienteRecords
		{
			get
			{
				if(colConAgendaGrupalPacienteRecords == null)
				{
					colConAgendaGrupalPacienteRecords = new DalSic.ConAgendaGrupalPacienteCollection().Where(ConAgendaGrupalPaciente.Columns.IdAgendaGrupal, IdAgendaGrupal).Load();
					colConAgendaGrupalPacienteRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalPacienteRecords_ListChanged);
				}
				return colConAgendaGrupalPacienteRecords;			
			}
			set 
			{ 
					colConAgendaGrupalPacienteRecords = value; 
					colConAgendaGrupalPacienteRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalPacienteRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalPacienteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalPacienteRecords[e.NewIndex].IdAgendaGrupal = IdAgendaGrupal;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ConMotivoInactivacionAgenda ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.ConMotivoInactivacionAgenda ConMotivoInactivacionAgenda
		{
			get { return DalSic.ConMotivoInactivacionAgenda.FetchByID(this.IdMotivoInactivacion); }
			set { SetColumnValue("idMotivoInactivacion", value.IdMotivoInactivacion); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a ConAgendaEstado ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.ConAgendaEstado ConAgendaEstado
		{
			get { return DalSic.ConAgendaEstado.FetchByID(this.IdAgendaEstado); }
			set { SetColumnValue("idAgendaEstado", value.IdAgendaEstado); }
		}
		
		
		/// <summary>
		/// Returns a ConConsultorio ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.ConConsultorio ConConsultorio
		{
			get { return DalSic.ConConsultorio.FetchByID(this.IdConsultorio); }
			set { SetColumnValue("idConsultorio", value.IdConsultorio); }
		}
		
		
		/// <summary>
		/// Returns a ConTematica ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.ConTematica ConTematica
		{
			get { return DalSic.ConTematica.FetchByID(this.IdTematica); }
			set { SetColumnValue("idTematica", value.IdTematica); }
		}
		
		
		/// <summary>
		/// Returns a ConTipoActividadGrupal ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.ConTipoActividadGrupal ConTipoActividadGrupal
		{
			get { return DalSic.ConTipoActividadGrupal.FetchByID(this.IdTipoActividadGrupal); }
			set { SetColumnValue("idTipoActividadGrupal", value.IdTipoActividadGrupal); }
		}
		
		
		/// <summary>
		/// Returns a ConLugarActividadGrupal ActiveRecord object related to this ConAgendaGrupal
		/// 
		/// </summary>
		public DalSic.ConLugarActividadGrupal ConLugarActividadGrupal
		{
			get { return DalSic.ConLugarActividadGrupal.FetchByID(this.IdLugarActividadGrupal); }
			set { SetColumnValue("idLugarActividadGrupal", value.IdLugarActividadGrupal); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgendaEstado,int? varIdMotivoInactivacion,int varIdEfector,int varIdTematica,string varTematicaOtra,int varIdTipoActividadGrupal,string varTipoActividadGrupalOtro,int varIdLugarActividadGrupal,string varLugarActividadGrupalOtro,DateTime varFecha,string varHoraInicio,string varHoraFin,int? varCantidadAsistentes,string varOtrosOrganismos,int? varIdConsultorio,string varResumenActividad,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			ConAgendaGrupal item = new ConAgendaGrupal();
			
			item.IdAgendaEstado = varIdAgendaEstado;
			
			item.IdMotivoInactivacion = varIdMotivoInactivacion;
			
			item.IdEfector = varIdEfector;
			
			item.IdTematica = varIdTematica;
			
			item.TematicaOtra = varTematicaOtra;
			
			item.IdTipoActividadGrupal = varIdTipoActividadGrupal;
			
			item.TipoActividadGrupalOtro = varTipoActividadGrupalOtro;
			
			item.IdLugarActividadGrupal = varIdLugarActividadGrupal;
			
			item.LugarActividadGrupalOtro = varLugarActividadGrupalOtro;
			
			item.Fecha = varFecha;
			
			item.HoraInicio = varHoraInicio;
			
			item.HoraFin = varHoraFin;
			
			item.CantidadAsistentes = varCantidadAsistentes;
			
			item.OtrosOrganismos = varOtrosOrganismos;
			
			item.IdConsultorio = varIdConsultorio;
			
			item.ResumenActividad = varResumenActividad;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgendaGrupal,int varIdAgendaEstado,int? varIdMotivoInactivacion,int varIdEfector,int varIdTematica,string varTematicaOtra,int varIdTipoActividadGrupal,string varTipoActividadGrupalOtro,int varIdLugarActividadGrupal,string varLugarActividadGrupalOtro,DateTime varFecha,string varHoraInicio,string varHoraFin,int? varCantidadAsistentes,string varOtrosOrganismos,int? varIdConsultorio,string varResumenActividad,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			ConAgendaGrupal item = new ConAgendaGrupal();
			
				item.IdAgendaGrupal = varIdAgendaGrupal;
			
				item.IdAgendaEstado = varIdAgendaEstado;
			
				item.IdMotivoInactivacion = varIdMotivoInactivacion;
			
				item.IdEfector = varIdEfector;
			
				item.IdTematica = varIdTematica;
			
				item.TematicaOtra = varTematicaOtra;
			
				item.IdTipoActividadGrupal = varIdTipoActividadGrupal;
			
				item.TipoActividadGrupalOtro = varTipoActividadGrupalOtro;
			
				item.IdLugarActividadGrupal = varIdLugarActividadGrupal;
			
				item.LugarActividadGrupalOtro = varLugarActividadGrupalOtro;
			
				item.Fecha = varFecha;
			
				item.HoraInicio = varHoraInicio;
			
				item.HoraFin = varHoraFin;
			
				item.CantidadAsistentes = varCantidadAsistentes;
			
				item.OtrosOrganismos = varOtrosOrganismos;
			
				item.IdConsultorio = varIdConsultorio;
			
				item.ResumenActividad = varResumenActividad;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgendaGrupalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaEstadoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoInactivacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTematicaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TematicaOtraColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoActividadGrupalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoActividadGrupalOtroColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLugarActividadGrupalColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LugarActividadGrupalOtroColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraInicioColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraFinColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadAsistentesColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosOrganismosColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultorioColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ResumenActividadColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgendaGrupal = @"idAgendaGrupal";
			 public static string IdAgendaEstado = @"idAgendaEstado";
			 public static string IdMotivoInactivacion = @"idMotivoInactivacion";
			 public static string IdEfector = @"idEfector";
			 public static string IdTematica = @"idTematica";
			 public static string TematicaOtra = @"tematicaOtra";
			 public static string IdTipoActividadGrupal = @"idTipoActividadGrupal";
			 public static string TipoActividadGrupalOtro = @"tipoActividadGrupalOtro";
			 public static string IdLugarActividadGrupal = @"idLugarActividadGrupal";
			 public static string LugarActividadGrupalOtro = @"lugarActividadGrupalOtro";
			 public static string Fecha = @"fecha";
			 public static string HoraInicio = @"horaInicio";
			 public static string HoraFin = @"horaFin";
			 public static string CantidadAsistentes = @"cantidadAsistentes";
			 public static string OtrosOrganismos = @"otrosOrganismos";
			 public static string IdConsultorio = @"idConsultorio";
			 public static string ResumenActividad = @"resumenActividad";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConAgendaGrupalOrganismoRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupalOrganismo item in colConAgendaGrupalOrganismoRecords)
                    {
                        if (item.IdAgendaGrupal != IdAgendaGrupal)
                        {
                            item.IdAgendaGrupal = IdAgendaGrupal;
                        }
                    }
               }
		
                if (colConAgendaGrupalProfesionalRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupalProfesional item in colConAgendaGrupalProfesionalRecords)
                    {
                        if (item.IdAgendaGrupal != IdAgendaGrupal)
                        {
                            item.IdAgendaGrupal = IdAgendaGrupal;
                        }
                    }
               }
		
                if (colConAgendaGrupalPacienteRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupalPaciente item in colConAgendaGrupalPacienteRecords)
                    {
                        if (item.IdAgendaGrupal != IdAgendaGrupal)
                        {
                            item.IdAgendaGrupal = IdAgendaGrupal;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConAgendaGrupalOrganismoRecords != null)
                {
                    colConAgendaGrupalOrganismoRecords.SaveAll();
               }
		
                if (colConAgendaGrupalProfesionalRecords != null)
                {
                    colConAgendaGrupalProfesionalRecords.SaveAll();
               }
		
                if (colConAgendaGrupalPacienteRecords != null)
                {
                    colConAgendaGrupalPacienteRecords.SaveAll();
               }
		}
        #endregion
	}
}
