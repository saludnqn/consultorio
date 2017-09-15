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
	/// Strongly-typed collection for the ConAgenda class.
	/// </summary>
    [Serializable]
	public partial class ConAgendaCollection : ActiveList<ConAgenda, ConAgendaCollection>
	{	   
		public ConAgendaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConAgendaCollection</returns>
		public ConAgendaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConAgenda o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_Agenda table.
	/// </summary>
	[Serializable]
	public partial class ConAgenda : ActiveRecord<ConAgenda>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConAgenda()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConAgenda(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConAgenda(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConAgenda(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_Agenda", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
				colvarIdAgenda.ColumnName = "idAgenda";
				colvarIdAgenda.DataType = DbType.Int32;
				colvarIdAgenda.MaxLength = 0;
				colvarIdAgenda.AutoIncrement = true;
				colvarIdAgenda.IsNullable = false;
				colvarIdAgenda.IsPrimaryKey = true;
				colvarIdAgenda.IsForeignKey = true;
				colvarIdAgenda.IsReadOnly = false;
				colvarIdAgenda.DefaultSetting = @"";
				
					colvarIdAgenda.ForeignKeyTableName = "CON_Agenda";
				schema.Columns.Add(colvarIdAgenda);
				
				TableSchema.TableColumn colvarIdAgendaEstado = new TableSchema.TableColumn(schema);
				colvarIdAgendaEstado.ColumnName = "idAgendaEstado";
				colvarIdAgendaEstado.DataType = DbType.Int32;
				colvarIdAgendaEstado.MaxLength = 0;
				colvarIdAgendaEstado.AutoIncrement = false;
				colvarIdAgendaEstado.IsNullable = false;
				colvarIdAgendaEstado.IsPrimaryKey = false;
				colvarIdAgendaEstado.IsForeignKey = true;
				colvarIdAgendaEstado.IsReadOnly = false;
				
						colvarIdAgendaEstado.DefaultSetting = @"((0))";
				
					colvarIdAgendaEstado.ForeignKeyTableName = "CON_AgendaEstado";
				schema.Columns.Add(colvarIdAgendaEstado);
				
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
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "idServicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = false;
				colvarIdServicio.IsNullable = false;
				colvarIdServicio.IsPrimaryKey = false;
				colvarIdServicio.IsForeignKey = true;
				colvarIdServicio.IsReadOnly = false;
				colvarIdServicio.DefaultSetting = @"";
				
					colvarIdServicio.ForeignKeyTableName = "Sys_Servicio";
				schema.Columns.Add(colvarIdServicio);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarIdTipoPrestacion = new TableSchema.TableColumn(schema);
				colvarIdTipoPrestacion.ColumnName = "idTipoPrestacion";
				colvarIdTipoPrestacion.DataType = DbType.Int32;
				colvarIdTipoPrestacion.MaxLength = 0;
				colvarIdTipoPrestacion.AutoIncrement = false;
				colvarIdTipoPrestacion.IsNullable = false;
				colvarIdTipoPrestacion.IsPrimaryKey = false;
				colvarIdTipoPrestacion.IsForeignKey = true;
				colvarIdTipoPrestacion.IsReadOnly = false;
				
						colvarIdTipoPrestacion.DefaultSetting = @"((0))";
				
					colvarIdTipoPrestacion.ForeignKeyTableName = "CON_TipoPrestacion";
				schema.Columns.Add(colvarIdTipoPrestacion);
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = false;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = true;
				colvarIdEspecialidad.IsReadOnly = false;
				
						colvarIdEspecialidad.DefaultSetting = @"((0))";
				
					colvarIdEspecialidad.ForeignKeyTableName = "Sys_Especialidad";
				schema.Columns.Add(colvarIdEspecialidad);
				
				TableSchema.TableColumn colvarIdConsultorio = new TableSchema.TableColumn(schema);
				colvarIdConsultorio.ColumnName = "idConsultorio";
				colvarIdConsultorio.DataType = DbType.Int32;
				colvarIdConsultorio.MaxLength = 0;
				colvarIdConsultorio.AutoIncrement = false;
				colvarIdConsultorio.IsNullable = false;
				colvarIdConsultorio.IsPrimaryKey = false;
				colvarIdConsultorio.IsForeignKey = true;
				colvarIdConsultorio.IsReadOnly = false;
				
						colvarIdConsultorio.DefaultSetting = @"((0))";
				
					colvarIdConsultorio.ForeignKeyTableName = "CON_Consultorio";
				schema.Columns.Add(colvarIdConsultorio);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"((0))";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarDuracion = new TableSchema.TableColumn(schema);
				colvarDuracion.ColumnName = "duracion";
				colvarDuracion.DataType = DbType.Int32;
				colvarDuracion.MaxLength = 0;
				colvarDuracion.AutoIncrement = false;
				colvarDuracion.IsNullable = false;
				colvarDuracion.IsPrimaryKey = false;
				colvarDuracion.IsForeignKey = false;
				colvarDuracion.IsReadOnly = false;
				
						colvarDuracion.DefaultSetting = @"((0))";
				colvarDuracion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDuracion);
				
				TableSchema.TableColumn colvarHoraInicio = new TableSchema.TableColumn(schema);
				colvarHoraInicio.ColumnName = "horaInicio";
				colvarHoraInicio.DataType = DbType.AnsiStringFixedLength;
				colvarHoraInicio.MaxLength = 5;
				colvarHoraInicio.AutoIncrement = false;
				colvarHoraInicio.IsNullable = false;
				colvarHoraInicio.IsPrimaryKey = false;
				colvarHoraInicio.IsForeignKey = false;
				colvarHoraInicio.IsReadOnly = false;
				
						colvarHoraInicio.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarHoraInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraInicio);
				
				TableSchema.TableColumn colvarHoraFin = new TableSchema.TableColumn(schema);
				colvarHoraFin.ColumnName = "horaFin";
				colvarHoraFin.DataType = DbType.AnsiStringFixedLength;
				colvarHoraFin.MaxLength = 5;
				colvarHoraFin.AutoIncrement = false;
				colvarHoraFin.IsNullable = false;
				colvarHoraFin.IsPrimaryKey = false;
				colvarHoraFin.IsForeignKey = false;
				colvarHoraFin.IsReadOnly = false;
				
						colvarHoraFin.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarHoraFin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraFin);
				
				TableSchema.TableColumn colvarMaximoSobreturnos = new TableSchema.TableColumn(schema);
				colvarMaximoSobreturnos.ColumnName = "maximoSobreturnos";
				colvarMaximoSobreturnos.DataType = DbType.Int32;
				colvarMaximoSobreturnos.MaxLength = 0;
				colvarMaximoSobreturnos.AutoIncrement = false;
				colvarMaximoSobreturnos.IsNullable = false;
				colvarMaximoSobreturnos.IsPrimaryKey = false;
				colvarMaximoSobreturnos.IsForeignKey = false;
				colvarMaximoSobreturnos.IsReadOnly = false;
				colvarMaximoSobreturnos.DefaultSetting = @"";
				colvarMaximoSobreturnos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaximoSobreturnos);
				
				TableSchema.TableColumn colvarPorcentajeTurnosDia = new TableSchema.TableColumn(schema);
				colvarPorcentajeTurnosDia.ColumnName = "porcentajeTurnosDia";
				colvarPorcentajeTurnosDia.DataType = DbType.Int32;
				colvarPorcentajeTurnosDia.MaxLength = 0;
				colvarPorcentajeTurnosDia.AutoIncrement = false;
				colvarPorcentajeTurnosDia.IsNullable = false;
				colvarPorcentajeTurnosDia.IsPrimaryKey = false;
				colvarPorcentajeTurnosDia.IsForeignKey = false;
				colvarPorcentajeTurnosDia.IsReadOnly = false;
				
						colvarPorcentajeTurnosDia.DefaultSetting = @"((0))";
				colvarPorcentajeTurnosDia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPorcentajeTurnosDia);
				
				TableSchema.TableColumn colvarPorcentajeTurnosAnticipados = new TableSchema.TableColumn(schema);
				colvarPorcentajeTurnosAnticipados.ColumnName = "porcentajeTurnosAnticipados";
				colvarPorcentajeTurnosAnticipados.DataType = DbType.Int32;
				colvarPorcentajeTurnosAnticipados.MaxLength = 0;
				colvarPorcentajeTurnosAnticipados.AutoIncrement = false;
				colvarPorcentajeTurnosAnticipados.IsNullable = false;
				colvarPorcentajeTurnosAnticipados.IsPrimaryKey = false;
				colvarPorcentajeTurnosAnticipados.IsForeignKey = false;
				colvarPorcentajeTurnosAnticipados.IsReadOnly = false;
				
						colvarPorcentajeTurnosAnticipados.DefaultSetting = @"((0))";
				colvarPorcentajeTurnosAnticipados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPorcentajeTurnosAnticipados);
				
				TableSchema.TableColumn colvarCitarPorBloques = new TableSchema.TableColumn(schema);
				colvarCitarPorBloques.ColumnName = "citarPorBloques";
				colvarCitarPorBloques.DataType = DbType.Boolean;
				colvarCitarPorBloques.MaxLength = 0;
				colvarCitarPorBloques.AutoIncrement = false;
				colvarCitarPorBloques.IsNullable = false;
				colvarCitarPorBloques.IsPrimaryKey = false;
				colvarCitarPorBloques.IsForeignKey = false;
				colvarCitarPorBloques.IsReadOnly = false;
				
						colvarCitarPorBloques.DefaultSetting = @"((0))";
				colvarCitarPorBloques.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCitarPorBloques);
				
				TableSchema.TableColumn colvarCantidadInterconsulta = new TableSchema.TableColumn(schema);
				colvarCantidadInterconsulta.ColumnName = "cantidadInterconsulta";
				colvarCantidadInterconsulta.DataType = DbType.Int32;
				colvarCantidadInterconsulta.MaxLength = 0;
				colvarCantidadInterconsulta.AutoIncrement = false;
				colvarCantidadInterconsulta.IsNullable = false;
				colvarCantidadInterconsulta.IsPrimaryKey = false;
				colvarCantidadInterconsulta.IsForeignKey = false;
				colvarCantidadInterconsulta.IsReadOnly = false;
				
						colvarCantidadInterconsulta.DefaultSetting = @"((0))";
				colvarCantidadInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadInterconsulta);
				
				TableSchema.TableColumn colvarTurnosDisponibles = new TableSchema.TableColumn(schema);
				colvarTurnosDisponibles.ColumnName = "turnosDisponibles";
				colvarTurnosDisponibles.DataType = DbType.Boolean;
				colvarTurnosDisponibles.MaxLength = 0;
				colvarTurnosDisponibles.AutoIncrement = false;
				colvarTurnosDisponibles.IsNullable = false;
				colvarTurnosDisponibles.IsPrimaryKey = false;
				colvarTurnosDisponibles.IsForeignKey = false;
				colvarTurnosDisponibles.IsReadOnly = false;
				
						colvarTurnosDisponibles.DefaultSetting = @"((1))";
				colvarTurnosDisponibles.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTurnosDisponibles);
				
				TableSchema.TableColumn colvarIdMotivoInactivacion = new TableSchema.TableColumn(schema);
				colvarIdMotivoInactivacion.ColumnName = "idMotivoInactivacion";
				colvarIdMotivoInactivacion.DataType = DbType.Int32;
				colvarIdMotivoInactivacion.MaxLength = 0;
				colvarIdMotivoInactivacion.AutoIncrement = false;
				colvarIdMotivoInactivacion.IsNullable = true;
				colvarIdMotivoInactivacion.IsPrimaryKey = false;
				colvarIdMotivoInactivacion.IsForeignKey = false;
				colvarIdMotivoInactivacion.IsReadOnly = false;
				
						colvarIdMotivoInactivacion.DefaultSetting = @"('0')";
				colvarIdMotivoInactivacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoInactivacion);
				
				TableSchema.TableColumn colvarMultiprofesional = new TableSchema.TableColumn(schema);
				colvarMultiprofesional.ColumnName = "multiprofesional";
				colvarMultiprofesional.DataType = DbType.Boolean;
				colvarMultiprofesional.MaxLength = 0;
				colvarMultiprofesional.AutoIncrement = false;
				colvarMultiprofesional.IsNullable = false;
				colvarMultiprofesional.IsPrimaryKey = false;
				colvarMultiprofesional.IsForeignKey = false;
				colvarMultiprofesional.IsReadOnly = false;
				
						colvarMultiprofesional.DefaultSetting = @"((0))";
				colvarMultiprofesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMultiprofesional);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_Agenda",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgenda")]
		[Bindable(true)]
		public int IdAgenda 
		{
			get { return GetColumnValue<int>(Columns.IdAgenda); }
			set { SetColumnValue(Columns.IdAgenda, value); }
		}
		  
		[XmlAttribute("IdAgendaEstado")]
		[Bindable(true)]
		public int IdAgendaEstado 
		{
			get { return GetColumnValue<int>(Columns.IdAgendaEstado); }
			set { SetColumnValue(Columns.IdAgendaEstado, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int IdServicio 
		{
			get { return GetColumnValue<int>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("IdTipoPrestacion")]
		[Bindable(true)]
		public int IdTipoPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdTipoPrestacion); }
			set { SetColumnValue(Columns.IdTipoPrestacion, value); }
		}
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int IdEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("IdConsultorio")]
		[Bindable(true)]
		public int IdConsultorio 
		{
			get { return GetColumnValue<int>(Columns.IdConsultorio); }
			set { SetColumnValue(Columns.IdConsultorio, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Duracion")]
		[Bindable(true)]
		public int Duracion 
		{
			get { return GetColumnValue<int>(Columns.Duracion); }
			set { SetColumnValue(Columns.Duracion, value); }
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
		  
		[XmlAttribute("MaximoSobreturnos")]
		[Bindable(true)]
		public int MaximoSobreturnos 
		{
			get { return GetColumnValue<int>(Columns.MaximoSobreturnos); }
			set { SetColumnValue(Columns.MaximoSobreturnos, value); }
		}
		  
		[XmlAttribute("PorcentajeTurnosDia")]
		[Bindable(true)]
		public int PorcentajeTurnosDia 
		{
			get { return GetColumnValue<int>(Columns.PorcentajeTurnosDia); }
			set { SetColumnValue(Columns.PorcentajeTurnosDia, value); }
		}
		  
		[XmlAttribute("PorcentajeTurnosAnticipados")]
		[Bindable(true)]
		public int PorcentajeTurnosAnticipados 
		{
			get { return GetColumnValue<int>(Columns.PorcentajeTurnosAnticipados); }
			set { SetColumnValue(Columns.PorcentajeTurnosAnticipados, value); }
		}
		  
		[XmlAttribute("CitarPorBloques")]
		[Bindable(true)]
		public bool CitarPorBloques 
		{
			get { return GetColumnValue<bool>(Columns.CitarPorBloques); }
			set { SetColumnValue(Columns.CitarPorBloques, value); }
		}
		  
		[XmlAttribute("CantidadInterconsulta")]
		[Bindable(true)]
		public int CantidadInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.CantidadInterconsulta); }
			set { SetColumnValue(Columns.CantidadInterconsulta, value); }
		}
		  
		[XmlAttribute("TurnosDisponibles")]
		[Bindable(true)]
		public bool TurnosDisponibles 
		{
			get { return GetColumnValue<bool>(Columns.TurnosDisponibles); }
			set { SetColumnValue(Columns.TurnosDisponibles, value); }
		}
		  
		[XmlAttribute("IdMotivoInactivacion")]
		[Bindable(true)]
		public int? IdMotivoInactivacion 
		{
			get { return GetColumnValue<int?>(Columns.IdMotivoInactivacion); }
			set { SetColumnValue(Columns.IdMotivoInactivacion, value); }
		}
		  
		[XmlAttribute("Multiprofesional")]
		[Bindable(true)]
		public bool Multiprofesional 
		{
			get { return GetColumnValue<bool>(Columns.Multiprofesional); }
			set { SetColumnValue(Columns.Multiprofesional, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.ConAgendaBloqueoCollection colConAgendaBloqueoRecords;
		public DalSic.ConAgendaBloqueoCollection ConAgendaBloqueoRecords
		{
			get
			{
				if(colConAgendaBloqueoRecords == null)
				{
					colConAgendaBloqueoRecords = new DalSic.ConAgendaBloqueoCollection().Where(ConAgendaBloqueo.Columns.IdAgenda, IdAgenda).Load();
					colConAgendaBloqueoRecords.ListChanged += new ListChangedEventHandler(colConAgendaBloqueoRecords_ListChanged);
				}
				return colConAgendaBloqueoRecords;			
			}
			set 
			{ 
					colConAgendaBloqueoRecords = value; 
					colConAgendaBloqueoRecords.ListChanged += new ListChangedEventHandler(colConAgendaBloqueoRecords_ListChanged);
			}
		}
		
		void colConAgendaBloqueoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaBloqueoRecords[e.NewIndex].IdAgenda = IdAgenda;
		    }
		}
				
		private DalSic.ConTurnoReservaInterconsultumCollection colConTurnoReservaInterconsulta;
		public DalSic.ConTurnoReservaInterconsultumCollection ConTurnoReservaInterconsulta
		{
			get
			{
				if(colConTurnoReservaInterconsulta == null)
				{
					colConTurnoReservaInterconsulta = new DalSic.ConTurnoReservaInterconsultumCollection().Where(ConTurnoReservaInterconsultum.Columns.IdAgenda, IdAgenda).Load();
					colConTurnoReservaInterconsulta.ListChanged += new ListChangedEventHandler(colConTurnoReservaInterconsulta_ListChanged);
				}
				return colConTurnoReservaInterconsulta;			
			}
			set 
			{ 
					colConTurnoReservaInterconsulta = value; 
					colConTurnoReservaInterconsulta.ListChanged += new ListChangedEventHandler(colConTurnoReservaInterconsulta_ListChanged);
			}
		}
		
		void colConTurnoReservaInterconsulta_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoReservaInterconsulta[e.NewIndex].IdAgenda = IdAgenda;
		    }
		}
				
		private DalSic.ConTurnoCollection colConTurnoRecords;
		public DalSic.ConTurnoCollection ConTurnoRecords
		{
			get
			{
				if(colConTurnoRecords == null)
				{
					colConTurnoRecords = new DalSic.ConTurnoCollection().Where(ConTurno.Columns.IdAgenda, IdAgenda).Load();
					colConTurnoRecords.ListChanged += new ListChangedEventHandler(colConTurnoRecords_ListChanged);
				}
				return colConTurnoRecords;			
			}
			set 
			{ 
					colConTurnoRecords = value; 
					colConTurnoRecords.ListChanged += new ListChangedEventHandler(colConTurnoRecords_ListChanged);
			}
		}
		
		void colConTurnoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoRecords[e.NewIndex].IdAgenda = IdAgenda;
		    }
		}
				
		private DalSic.ConAgendaCollection colChildConAgendaRecords;
		public DalSic.ConAgendaCollection ChildConAgendaRecords
		{
			get
			{
				if(colChildConAgendaRecords == null)
				{
					colChildConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdAgenda, IdAgenda).Load();
					colChildConAgendaRecords.ListChanged += new ListChangedEventHandler(colChildConAgendaRecords_ListChanged);
				}
				return colChildConAgendaRecords;			
			}
			set 
			{ 
					colChildConAgendaRecords = value; 
					colChildConAgendaRecords.ListChanged += new ListChangedEventHandler(colChildConAgendaRecords_ListChanged);
			}
		}
		
		void colChildConAgendaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colChildConAgendaRecords[e.NewIndex].IdAgenda = IdAgenda;
		    }
		}
				
		private DalSic.ConAgendaProfesionalCollection colConAgendaProfesionalRecords;
		public DalSic.ConAgendaProfesionalCollection ConAgendaProfesionalRecords
		{
			get
			{
				if(colConAgendaProfesionalRecords == null)
				{
					colConAgendaProfesionalRecords = new DalSic.ConAgendaProfesionalCollection().Where(ConAgendaProfesional.Columns.IdAgenda, IdAgenda).Load();
					colConAgendaProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaProfesionalRecords_ListChanged);
				}
				return colConAgendaProfesionalRecords;			
			}
			set 
			{ 
					colConAgendaProfesionalRecords = value; 
					colConAgendaProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaProfesionalRecords_ListChanged);
			}
		}
		
		void colConAgendaProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaProfesionalRecords[e.NewIndex].IdAgenda = IdAgenda;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEspecialidad ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.SysEspecialidad SysEspecialidad
		{
			get { return DalSic.SysEspecialidad.FetchByID(this.IdEspecialidad); }
			set { SetColumnValue("idEspecialidad", value.IdEspecialidad); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a ConTipoPrestacion ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.ConTipoPrestacion ConTipoPrestacion
		{
			get { return DalSic.ConTipoPrestacion.FetchByID(this.IdTipoPrestacion); }
			set { SetColumnValue("idTipoPrestacion", value.IdTipoPrestacion); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a ConAgenda ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.ConAgenda ParentConAgenda
		{
			get { return DalSic.ConAgenda.FetchByID(this.IdAgenda); }
			set { SetColumnValue("idAgenda", value.IdAgenda); }
		}
		
		
		/// <summary>
		/// Returns a ConAgendaEstado ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.ConAgendaEstado ConAgendaEstado
		{
			get { return DalSic.ConAgendaEstado.FetchByID(this.IdAgendaEstado); }
			set { SetColumnValue("idAgendaEstado", value.IdAgendaEstado); }
		}
		
		
		/// <summary>
		/// Returns a ConConsultorio ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.ConConsultorio ConConsultorio
		{
			get { return DalSic.ConConsultorio.FetchByID(this.IdConsultorio); }
			set { SetColumnValue("idConsultorio", value.IdConsultorio); }
		}
		
		
		/// <summary>
		/// Returns a SysServicio ActiveRecord object related to this ConAgenda
		/// 
		/// </summary>
		public DalSic.SysServicio SysServicio
		{
			get { return DalSic.SysServicio.FetchByID(this.IdServicio); }
			set { SetColumnValue("idServicio", value.IdServicio); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgendaEstado,int varIdEfector,int varIdServicio,int varIdProfesional,int varIdTipoPrestacion,int varIdEspecialidad,int varIdConsultorio,DateTime varFecha,int varDuracion,string varHoraInicio,string varHoraFin,int varMaximoSobreturnos,int varPorcentajeTurnosDia,int varPorcentajeTurnosAnticipados,bool varCitarPorBloques,int varCantidadInterconsulta,bool varTurnosDisponibles,int? varIdMotivoInactivacion,bool varMultiprofesional)
		{
			ConAgenda item = new ConAgenda();
			
			item.IdAgendaEstado = varIdAgendaEstado;
			
			item.IdEfector = varIdEfector;
			
			item.IdServicio = varIdServicio;
			
			item.IdProfesional = varIdProfesional;
			
			item.IdTipoPrestacion = varIdTipoPrestacion;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdConsultorio = varIdConsultorio;
			
			item.Fecha = varFecha;
			
			item.Duracion = varDuracion;
			
			item.HoraInicio = varHoraInicio;
			
			item.HoraFin = varHoraFin;
			
			item.MaximoSobreturnos = varMaximoSobreturnos;
			
			item.PorcentajeTurnosDia = varPorcentajeTurnosDia;
			
			item.PorcentajeTurnosAnticipados = varPorcentajeTurnosAnticipados;
			
			item.CitarPorBloques = varCitarPorBloques;
			
			item.CantidadInterconsulta = varCantidadInterconsulta;
			
			item.TurnosDisponibles = varTurnosDisponibles;
			
			item.IdMotivoInactivacion = varIdMotivoInactivacion;
			
			item.Multiprofesional = varMultiprofesional;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgenda,int varIdAgendaEstado,int varIdEfector,int varIdServicio,int varIdProfesional,int varIdTipoPrestacion,int varIdEspecialidad,int varIdConsultorio,DateTime varFecha,int varDuracion,string varHoraInicio,string varHoraFin,int varMaximoSobreturnos,int varPorcentajeTurnosDia,int varPorcentajeTurnosAnticipados,bool varCitarPorBloques,int varCantidadInterconsulta,bool varTurnosDisponibles,int? varIdMotivoInactivacion,bool varMultiprofesional)
		{
			ConAgenda item = new ConAgenda();
			
				item.IdAgenda = varIdAgenda;
			
				item.IdAgendaEstado = varIdAgendaEstado;
			
				item.IdEfector = varIdEfector;
			
				item.IdServicio = varIdServicio;
			
				item.IdProfesional = varIdProfesional;
			
				item.IdTipoPrestacion = varIdTipoPrestacion;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdConsultorio = varIdConsultorio;
			
				item.Fecha = varFecha;
			
				item.Duracion = varDuracion;
			
				item.HoraInicio = varHoraInicio;
			
				item.HoraFin = varHoraFin;
			
				item.MaximoSobreturnos = varMaximoSobreturnos;
			
				item.PorcentajeTurnosDia = varPorcentajeTurnosDia;
			
				item.PorcentajeTurnosAnticipados = varPorcentajeTurnosAnticipados;
			
				item.CitarPorBloques = varCitarPorBloques;
			
				item.CantidadInterconsulta = varCantidadInterconsulta;
			
				item.TurnosDisponibles = varTurnosDisponibles;
			
				item.IdMotivoInactivacion = varIdMotivoInactivacion;
			
				item.Multiprofesional = varMultiprofesional;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgendaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaEstadoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPrestacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultorioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DuracionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraInicioColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraFinColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn MaximoSobreturnosColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PorcentajeTurnosDiaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PorcentajeTurnosAnticipadosColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CitarPorBloquesColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadInterconsultaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn TurnosDisponiblesColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoInactivacionColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn MultiprofesionalColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgenda = @"idAgenda";
			 public static string IdAgendaEstado = @"idAgendaEstado";
			 public static string IdEfector = @"idEfector";
			 public static string IdServicio = @"idServicio";
			 public static string IdProfesional = @"idProfesional";
			 public static string IdTipoPrestacion = @"idTipoPrestacion";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdConsultorio = @"idConsultorio";
			 public static string Fecha = @"fecha";
			 public static string Duracion = @"duracion";
			 public static string HoraInicio = @"horaInicio";
			 public static string HoraFin = @"horaFin";
			 public static string MaximoSobreturnos = @"maximoSobreturnos";
			 public static string PorcentajeTurnosDia = @"porcentajeTurnosDia";
			 public static string PorcentajeTurnosAnticipados = @"porcentajeTurnosAnticipados";
			 public static string CitarPorBloques = @"citarPorBloques";
			 public static string CantidadInterconsulta = @"cantidadInterconsulta";
			 public static string TurnosDisponibles = @"turnosDisponibles";
			 public static string IdMotivoInactivacion = @"idMotivoInactivacion";
			 public static string Multiprofesional = @"multiprofesional";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConAgendaBloqueoRecords != null)
                {
                    foreach (DalSic.ConAgendaBloqueo item in colConAgendaBloqueoRecords)
                    {
                        if (item.IdAgenda != IdAgenda)
                        {
                            item.IdAgenda = IdAgenda;
                        }
                    }
               }
		
                if (colConTurnoReservaInterconsulta != null)
                {
                    foreach (DalSic.ConTurnoReservaInterconsultum item in colConTurnoReservaInterconsulta)
                    {
                        if (item.IdAgenda != IdAgenda)
                        {
                            item.IdAgenda = IdAgenda;
                        }
                    }
               }
		
                if (colConTurnoRecords != null)
                {
                    foreach (DalSic.ConTurno item in colConTurnoRecords)
                    {
                        if (item.IdAgenda != IdAgenda)
                        {
                            item.IdAgenda = IdAgenda;
                        }
                    }
               }
		
                if (colChildConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colChildConAgendaRecords)
                    {
                        if (item.IdAgenda != IdAgenda)
                        {
                            item.IdAgenda = IdAgenda;
                        }
                    }
               }
		
                if (colConAgendaProfesionalRecords != null)
                {
                    foreach (DalSic.ConAgendaProfesional item in colConAgendaProfesionalRecords)
                    {
                        if (item.IdAgenda != IdAgenda)
                        {
                            item.IdAgenda = IdAgenda;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConAgendaBloqueoRecords != null)
                {
                    colConAgendaBloqueoRecords.SaveAll();
               }
		
                if (colConTurnoReservaInterconsulta != null)
                {
                    colConTurnoReservaInterconsulta.SaveAll();
               }
		
                if (colConTurnoRecords != null)
                {
                    colConTurnoRecords.SaveAll();
               }
		
                if (colChildConAgendaRecords != null)
                {
                    colChildConAgendaRecords.SaveAll();
               }
		
                if (colConAgendaProfesionalRecords != null)
                {
                    colConAgendaProfesionalRecords.SaveAll();
               }
		}
        #endregion
	}
}
