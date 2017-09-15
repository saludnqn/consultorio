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
	/// Strongly-typed collection for the ConConsultum class.
	/// </summary>
    [Serializable]
	public partial class ConConsultumCollection : ActiveList<ConConsultum, ConConsultumCollection>
	{	   
		public ConConsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConConsultumCollection</returns>
		public ConConsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConConsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_Consulta table.
	/// </summary>
	[Serializable]
	public partial class ConConsultum : ActiveRecord<ConConsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConConsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConConsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConConsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConConsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_Consulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
				colvarIdConsulta.ColumnName = "idConsulta";
				colvarIdConsulta.DataType = DbType.Int32;
				colvarIdConsulta.MaxLength = 0;
				colvarIdConsulta.AutoIncrement = true;
				colvarIdConsulta.IsNullable = false;
				colvarIdConsulta.IsPrimaryKey = true;
				colvarIdConsulta.IsForeignKey = false;
				colvarIdConsulta.IsReadOnly = false;
				colvarIdConsulta.DefaultSetting = @"";
				colvarIdConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsulta);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
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
				
				TableSchema.TableColumn colvarHora = new TableSchema.TableColumn(schema);
				colvarHora.ColumnName = "hora";
				colvarHora.DataType = DbType.String;
				colvarHora.MaxLength = 10;
				colvarHora.AutoIncrement = false;
				colvarHora.IsNullable = true;
				colvarHora.IsPrimaryKey = false;
				colvarHora.IsForeignKey = false;
				colvarHora.IsReadOnly = false;
				colvarHora.DefaultSetting = @"";
				colvarHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHora);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdEspecialidad.ColumnName = "idEspecialidad";
				colvarIdEspecialidad.DataType = DbType.Int32;
				colvarIdEspecialidad.MaxLength = 0;
				colvarIdEspecialidad.AutoIncrement = false;
				colvarIdEspecialidad.IsNullable = true;
				colvarIdEspecialidad.IsPrimaryKey = false;
				colvarIdEspecialidad.IsForeignKey = true;
				colvarIdEspecialidad.IsReadOnly = false;
				colvarIdEspecialidad.DefaultSetting = @"";
				
					colvarIdEspecialidad.ForeignKeyTableName = "Sys_Especialidad";
				schema.Columns.Add(colvarIdEspecialidad);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = true;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarMotivoConsulta.ColumnName = "motivoConsulta";
				colvarMotivoConsulta.DataType = DbType.String;
				colvarMotivoConsulta.MaxLength = -1;
				colvarMotivoConsulta.AutoIncrement = false;
				colvarMotivoConsulta.IsNullable = true;
				colvarMotivoConsulta.IsPrimaryKey = false;
				colvarMotivoConsulta.IsForeignKey = false;
				colvarMotivoConsulta.IsReadOnly = false;
				colvarMotivoConsulta.DefaultSetting = @"";
				colvarMotivoConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivoConsulta);
				
				TableSchema.TableColumn colvarInformeConsulta = new TableSchema.TableColumn(schema);
				colvarInformeConsulta.ColumnName = "informeConsulta";
				colvarInformeConsulta.DataType = DbType.String;
				colvarInformeConsulta.MaxLength = -1;
				colvarInformeConsulta.AutoIncrement = false;
				colvarInformeConsulta.IsNullable = true;
				colvarInformeConsulta.IsPrimaryKey = false;
				colvarInformeConsulta.IsForeignKey = false;
				colvarInformeConsulta.IsReadOnly = false;
				colvarInformeConsulta.DefaultSetting = @"";
				colvarInformeConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformeConsulta);
				
				TableSchema.TableColumn colvarIdDerivadoPor = new TableSchema.TableColumn(schema);
				colvarIdDerivadoPor.ColumnName = "idDerivadoPor";
				colvarIdDerivadoPor.DataType = DbType.Int32;
				colvarIdDerivadoPor.MaxLength = 0;
				colvarIdDerivadoPor.AutoIncrement = false;
				colvarIdDerivadoPor.IsNullable = true;
				colvarIdDerivadoPor.IsPrimaryKey = false;
				colvarIdDerivadoPor.IsForeignKey = false;
				colvarIdDerivadoPor.IsReadOnly = false;
				colvarIdDerivadoPor.DefaultSetting = @"";
				colvarIdDerivadoPor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDerivadoPor);
				
				TableSchema.TableColumn colvarIdDerivadoHacia = new TableSchema.TableColumn(schema);
				colvarIdDerivadoHacia.ColumnName = "idDerivadoHacia";
				colvarIdDerivadoHacia.DataType = DbType.Int32;
				colvarIdDerivadoHacia.MaxLength = 0;
				colvarIdDerivadoHacia.AutoIncrement = false;
				colvarIdDerivadoHacia.IsNullable = true;
				colvarIdDerivadoHacia.IsPrimaryKey = false;
				colvarIdDerivadoHacia.IsForeignKey = false;
				colvarIdDerivadoHacia.IsReadOnly = false;
				colvarIdDerivadoHacia.DefaultSetting = @"";
				colvarIdDerivadoHacia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDerivadoHacia);
				
				TableSchema.TableColumn colvarIdTipoPrestacion = new TableSchema.TableColumn(schema);
				colvarIdTipoPrestacion.ColumnName = "idTipoPrestacion";
				colvarIdTipoPrestacion.DataType = DbType.Int32;
				colvarIdTipoPrestacion.MaxLength = 0;
				colvarIdTipoPrestacion.AutoIncrement = false;
				colvarIdTipoPrestacion.IsNullable = true;
				colvarIdTipoPrestacion.IsPrimaryKey = false;
				colvarIdTipoPrestacion.IsForeignKey = false;
				colvarIdTipoPrestacion.IsReadOnly = false;
				colvarIdTipoPrestacion.DefaultSetting = @"";
				colvarIdTipoPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoPrestacion);
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = true;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = true;
				colvarIdObraSocial.IsReadOnly = false;
				colvarIdObraSocial.DefaultSetting = @"";
				
					colvarIdObraSocial.ForeignKeyTableName = "Sys_ObraSocial";
				schema.Columns.Add(colvarIdObraSocial);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.Int32;
				colvarIdUsuarioRegistro.MaxLength = 0;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = true;
				colvarIdUsuarioRegistro.IsPrimaryKey = false;
				colvarIdUsuarioRegistro.IsForeignKey = false;
				colvarIdUsuarioRegistro.IsReadOnly = false;
				colvarIdUsuarioRegistro.DefaultSetting = @"";
				colvarIdUsuarioRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRegistro);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = true;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				colvarFechaRegistro.DefaultSetting = @"";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				TableSchema.TableColumn colvarIdTurno = new TableSchema.TableColumn(schema);
				colvarIdTurno.ColumnName = "idTurno";
				colvarIdTurno.DataType = DbType.Int32;
				colvarIdTurno.MaxLength = 0;
				colvarIdTurno.AutoIncrement = false;
				colvarIdTurno.IsNullable = false;
				colvarIdTurno.IsPrimaryKey = false;
				colvarIdTurno.IsForeignKey = false;
				colvarIdTurno.IsReadOnly = false;
				
						colvarIdTurno.DefaultSetting = @"((0))";
				colvarIdTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurno);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "talla";
				colvarTalla.DataType = DbType.Decimal;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = true;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarTAS = new TableSchema.TableColumn(schema);
				colvarTAS.ColumnName = "tAS";
				colvarTAS.DataType = DbType.Int32;
				colvarTAS.MaxLength = 0;
				colvarTAS.AutoIncrement = false;
				colvarTAS.IsNullable = true;
				colvarTAS.IsPrimaryKey = false;
				colvarTAS.IsForeignKey = false;
				colvarTAS.IsReadOnly = false;
				colvarTAS.DefaultSetting = @"";
				colvarTAS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTAS);
				
				TableSchema.TableColumn colvarTAD = new TableSchema.TableColumn(schema);
				colvarTAD.ColumnName = "tAD";
				colvarTAD.DataType = DbType.Decimal;
				colvarTAD.MaxLength = 0;
				colvarTAD.AutoIncrement = false;
				colvarTAD.IsNullable = true;
				colvarTAD.IsPrimaryKey = false;
				colvarTAD.IsForeignKey = false;
				colvarTAD.IsReadOnly = false;
				colvarTAD.DefaultSetting = @"";
				colvarTAD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTAD);
				
				TableSchema.TableColumn colvarImc = new TableSchema.TableColumn(schema);
				colvarImc.ColumnName = "imc";
				colvarImc.DataType = DbType.Decimal;
				colvarImc.MaxLength = 0;
				colvarImc.AutoIncrement = false;
				colvarImc.IsNullable = true;
				colvarImc.IsPrimaryKey = false;
				colvarImc.IsForeignKey = false;
				colvarImc.IsReadOnly = false;
				colvarImc.DefaultSetting = @"";
				colvarImc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImc);
				
				TableSchema.TableColumn colvarPerimetroCefalico = new TableSchema.TableColumn(schema);
				colvarPerimetroCefalico.ColumnName = "perimetroCefalico";
				colvarPerimetroCefalico.DataType = DbType.Decimal;
				colvarPerimetroCefalico.MaxLength = 0;
				colvarPerimetroCefalico.AutoIncrement = false;
				colvarPerimetroCefalico.IsNullable = true;
				colvarPerimetroCefalico.IsPrimaryKey = false;
				colvarPerimetroCefalico.IsForeignKey = false;
				colvarPerimetroCefalico.IsReadOnly = false;
				colvarPerimetroCefalico.DefaultSetting = @"";
				colvarPerimetroCefalico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerimetroCefalico);
				
				TableSchema.TableColumn colvarRiesgoCardiovascular = new TableSchema.TableColumn(schema);
				colvarRiesgoCardiovascular.ColumnName = "riesgoCardiovascular";
				colvarRiesgoCardiovascular.DataType = DbType.Int32;
				colvarRiesgoCardiovascular.MaxLength = 0;
				colvarRiesgoCardiovascular.AutoIncrement = false;
				colvarRiesgoCardiovascular.IsNullable = true;
				colvarRiesgoCardiovascular.IsPrimaryKey = false;
				colvarRiesgoCardiovascular.IsForeignKey = false;
				colvarRiesgoCardiovascular.IsReadOnly = false;
				colvarRiesgoCardiovascular.DefaultSetting = @"";
				colvarRiesgoCardiovascular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRiesgoCardiovascular);
				
				TableSchema.TableColumn colvarIdProgramaOdontologia = new TableSchema.TableColumn(schema);
				colvarIdProgramaOdontologia.ColumnName = "idProgramaOdontologia";
				colvarIdProgramaOdontologia.DataType = DbType.Int32;
				colvarIdProgramaOdontologia.MaxLength = 0;
				colvarIdProgramaOdontologia.AutoIncrement = false;
				colvarIdProgramaOdontologia.IsNullable = false;
				colvarIdProgramaOdontologia.IsPrimaryKey = false;
				colvarIdProgramaOdontologia.IsForeignKey = false;
				colvarIdProgramaOdontologia.IsReadOnly = false;
				
						colvarIdProgramaOdontologia.DefaultSetting = @"((0))";
				colvarIdProgramaOdontologia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProgramaOdontologia);
				
				TableSchema.TableColumn colvarPrimerConsultaOdontologia = new TableSchema.TableColumn(schema);
				colvarPrimerConsultaOdontologia.ColumnName = "primerConsultaOdontologia";
				colvarPrimerConsultaOdontologia.DataType = DbType.Int32;
				colvarPrimerConsultaOdontologia.MaxLength = 0;
				colvarPrimerConsultaOdontologia.AutoIncrement = false;
				colvarPrimerConsultaOdontologia.IsNullable = false;
				colvarPrimerConsultaOdontologia.IsPrimaryKey = false;
				colvarPrimerConsultaOdontologia.IsForeignKey = false;
				colvarPrimerConsultaOdontologia.IsReadOnly = false;
				
						colvarPrimerConsultaOdontologia.DefaultSetting = @"((0))";
				colvarPrimerConsultaOdontologia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimerConsultaOdontologia);
				
				TableSchema.TableColumn colvarIdEquipo = new TableSchema.TableColumn(schema);
				colvarIdEquipo.ColumnName = "idEquipo";
				colvarIdEquipo.DataType = DbType.Int32;
				colvarIdEquipo.MaxLength = 0;
				colvarIdEquipo.AutoIncrement = false;
				colvarIdEquipo.IsNullable = true;
				colvarIdEquipo.IsPrimaryKey = false;
				colvarIdEquipo.IsForeignKey = false;
				colvarIdEquipo.IsReadOnly = false;
				colvarIdEquipo.DefaultSetting = @"";
				colvarIdEquipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEquipo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_Consulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int IdConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Hora")]
		[Bindable(true)]
		public string Hora 
		{
			get { return GetColumnValue<string>(Columns.Hora); }
			set { SetColumnValue(Columns.Hora, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdEspecialidad")]
		[Bindable(true)]
		public int? IdEspecialidad 
		{
			get { return GetColumnValue<int?>(Columns.IdEspecialidad); }
			set { SetColumnValue(Columns.IdEspecialidad, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int? IdProfesional 
		{
			get { return GetColumnValue<int?>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("MotivoConsulta")]
		[Bindable(true)]
		public string MotivoConsulta 
		{
			get { return GetColumnValue<string>(Columns.MotivoConsulta); }
			set { SetColumnValue(Columns.MotivoConsulta, value); }
		}
		  
		[XmlAttribute("InformeConsulta")]
		[Bindable(true)]
		public string InformeConsulta 
		{
			get { return GetColumnValue<string>(Columns.InformeConsulta); }
			set { SetColumnValue(Columns.InformeConsulta, value); }
		}
		  
		[XmlAttribute("IdDerivadoPor")]
		[Bindable(true)]
		public int? IdDerivadoPor 
		{
			get { return GetColumnValue<int?>(Columns.IdDerivadoPor); }
			set { SetColumnValue(Columns.IdDerivadoPor, value); }
		}
		  
		[XmlAttribute("IdDerivadoHacia")]
		[Bindable(true)]
		public int? IdDerivadoHacia 
		{
			get { return GetColumnValue<int?>(Columns.IdDerivadoHacia); }
			set { SetColumnValue(Columns.IdDerivadoHacia, value); }
		}
		  
		[XmlAttribute("IdTipoPrestacion")]
		[Bindable(true)]
		public int? IdTipoPrestacion 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoPrestacion); }
			set { SetColumnValue(Columns.IdTipoPrestacion, value); }
		}
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int? IdObraSocial 
		{
			get { return GetColumnValue<int?>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public int? IdUsuarioRegistro 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime? FechaRegistro 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("IdTurno")]
		[Bindable(true)]
		public int IdTurno 
		{
			get { return GetColumnValue<int>(Columns.IdTurno); }
			set { SetColumnValue(Columns.IdTurno, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal? Peso 
		{
			get { return GetColumnValue<decimal?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public decimal? Talla 
		{
			get { return GetColumnValue<decimal?>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("TAS")]
		[Bindable(true)]
		public int? TAS 
		{
			get { return GetColumnValue<int?>(Columns.TAS); }
			set { SetColumnValue(Columns.TAS, value); }
		}
		  
		[XmlAttribute("TAD")]
		[Bindable(true)]
		public decimal? TAD 
		{
			get { return GetColumnValue<decimal?>(Columns.TAD); }
			set { SetColumnValue(Columns.TAD, value); }
		}
		  
		[XmlAttribute("Imc")]
		[Bindable(true)]
		public decimal? Imc 
		{
			get { return GetColumnValue<decimal?>(Columns.Imc); }
			set { SetColumnValue(Columns.Imc, value); }
		}
		  
		[XmlAttribute("PerimetroCefalico")]
		[Bindable(true)]
		public decimal? PerimetroCefalico 
		{
			get { return GetColumnValue<decimal?>(Columns.PerimetroCefalico); }
			set { SetColumnValue(Columns.PerimetroCefalico, value); }
		}
		  
		[XmlAttribute("RiesgoCardiovascular")]
		[Bindable(true)]
		public int? RiesgoCardiovascular 
		{
			get { return GetColumnValue<int?>(Columns.RiesgoCardiovascular); }
			set { SetColumnValue(Columns.RiesgoCardiovascular, value); }
		}
		  
		[XmlAttribute("IdProgramaOdontologia")]
		[Bindable(true)]
		public int IdProgramaOdontologia 
		{
			get { return GetColumnValue<int>(Columns.IdProgramaOdontologia); }
			set { SetColumnValue(Columns.IdProgramaOdontologia, value); }
		}
		  
		[XmlAttribute("PrimerConsultaOdontologia")]
		[Bindable(true)]
		public int PrimerConsultaOdontologia 
		{
			get { return GetColumnValue<int>(Columns.PrimerConsultaOdontologia); }
			set { SetColumnValue(Columns.PrimerConsultaOdontologia, value); }
		}
		  
		[XmlAttribute("IdEquipo")]
		[Bindable(true)]
		public int? IdEquipo 
		{
			get { return GetColumnValue<int?>(Columns.IdEquipo); }
			set { SetColumnValue(Columns.IdEquipo, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.ConConsultaMedicamentoCollection colConConsultaMedicamentoRecords;
		public DalSic.ConConsultaMedicamentoCollection ConConsultaMedicamentoRecords
		{
			get
			{
				if(colConConsultaMedicamentoRecords == null)
				{
					colConConsultaMedicamentoRecords = new DalSic.ConConsultaMedicamentoCollection().Where(ConConsultaMedicamento.Columns.IdConsulta, IdConsulta).Load();
					colConConsultaMedicamentoRecords.ListChanged += new ListChangedEventHandler(colConConsultaMedicamentoRecords_ListChanged);
				}
				return colConConsultaMedicamentoRecords;			
			}
			set 
			{ 
					colConConsultaMedicamentoRecords = value; 
					colConConsultaMedicamentoRecords.ListChanged += new ListChangedEventHandler(colConConsultaMedicamentoRecords_ListChanged);
			}
		}
		
		void colConConsultaMedicamentoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsultaMedicamentoRecords[e.NewIndex].IdConsulta = IdConsulta;
		    }
		}
				
		private DalSic.AprControlNiñoSanoCollection colAprControlNiñoSanoRecords;
		public DalSic.AprControlNiñoSanoCollection AprControlNiñoSanoRecords
		{
			get
			{
				if(colAprControlNiñoSanoRecords == null)
				{
					colAprControlNiñoSanoRecords = new DalSic.AprControlNiñoSanoCollection().Where(AprControlNiñoSano.Columns.IdConsulta, IdConsulta).Load();
					colAprControlNiñoSanoRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoRecords_ListChanged);
				}
				return colAprControlNiñoSanoRecords;			
			}
			set 
			{ 
					colAprControlNiñoSanoRecords = value; 
					colAprControlNiñoSanoRecords.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoRecords_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoRecords[e.NewIndex].IdConsulta = IdConsulta;
		    }
		}
				
		private DalSic.AprHistoriaClinicaPerinatalDetalleCollection colAprHistoriaClinicaPerinatalDetalleRecords;
		public DalSic.AprHistoriaClinicaPerinatalDetalleCollection AprHistoriaClinicaPerinatalDetalleRecords
		{
			get
			{
				if(colAprHistoriaClinicaPerinatalDetalleRecords == null)
				{
					colAprHistoriaClinicaPerinatalDetalleRecords = new DalSic.AprHistoriaClinicaPerinatalDetalleCollection().Where(AprHistoriaClinicaPerinatalDetalle.Columns.IdConsulta, IdConsulta).Load();
					colAprHistoriaClinicaPerinatalDetalleRecords.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalDetalleRecords_ListChanged);
				}
				return colAprHistoriaClinicaPerinatalDetalleRecords;			
			}
			set 
			{ 
					colAprHistoriaClinicaPerinatalDetalleRecords = value; 
					colAprHistoriaClinicaPerinatalDetalleRecords.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalDetalleRecords_ListChanged);
			}
		}
		
		void colAprHistoriaClinicaPerinatalDetalleRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprHistoriaClinicaPerinatalDetalleRecords[e.NewIndex].IdConsulta = IdConsulta;
		    }
		}
				
		private DalSic.ConConsultaDiagnosticoCollection colConConsultaDiagnosticoRecords;
		public DalSic.ConConsultaDiagnosticoCollection ConConsultaDiagnosticoRecords
		{
			get
			{
				if(colConConsultaDiagnosticoRecords == null)
				{
					colConConsultaDiagnosticoRecords = new DalSic.ConConsultaDiagnosticoCollection().Where(ConConsultaDiagnostico.Columns.IdConsulta, IdConsulta).Load();
					colConConsultaDiagnosticoRecords.ListChanged += new ListChangedEventHandler(colConConsultaDiagnosticoRecords_ListChanged);
				}
				return colConConsultaDiagnosticoRecords;			
			}
			set 
			{ 
					colConConsultaDiagnosticoRecords = value; 
					colConConsultaDiagnosticoRecords.ListChanged += new ListChangedEventHandler(colConConsultaDiagnosticoRecords_ListChanged);
			}
		}
		
		void colConConsultaDiagnosticoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsultaDiagnosticoRecords[e.NewIndex].IdConsulta = IdConsulta;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEspecialidad ActiveRecord object related to this ConConsultum
		/// 
		/// </summary>
		public DalSic.SysEspecialidad SysEspecialidad
		{
			get { return DalSic.SysEspecialidad.FetchByID(this.IdEspecialidad); }
			set { SetColumnValue("idEspecialidad", value.IdEspecialidad); }
		}
		
		
		/// <summary>
		/// Returns a SysObraSocial ActiveRecord object related to this ConConsultum
		/// 
		/// </summary>
		public DalSic.SysObraSocial SysObraSocial
		{
			get { return DalSic.SysObraSocial.FetchByID(this.IdObraSocial); }
			set { SetColumnValue("idObraSocial", value.IdObraSocial); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this ConConsultum
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this ConConsultum
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfector,DateTime? varFecha,string varHora,int? varIdPaciente,int? varIdEspecialidad,int? varIdProfesional,string varMotivoConsulta,string varInformeConsulta,int? varIdDerivadoPor,int? varIdDerivadoHacia,int? varIdTipoPrestacion,int? varIdObraSocial,int? varIdUsuarioRegistro,DateTime? varFechaRegistro,int varIdTurno,decimal? varPeso,decimal? varTalla,int? varTAS,decimal? varTAD,decimal? varImc,decimal? varPerimetroCefalico,int? varRiesgoCardiovascular,int varIdProgramaOdontologia,int varPrimerConsultaOdontologia,int? varIdEquipo)
		{
			ConConsultum item = new ConConsultum();
			
			item.IdEfector = varIdEfector;
			
			item.Fecha = varFecha;
			
			item.Hora = varHora;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdEspecialidad = varIdEspecialidad;
			
			item.IdProfesional = varIdProfesional;
			
			item.MotivoConsulta = varMotivoConsulta;
			
			item.InformeConsulta = varInformeConsulta;
			
			item.IdDerivadoPor = varIdDerivadoPor;
			
			item.IdDerivadoHacia = varIdDerivadoHacia;
			
			item.IdTipoPrestacion = varIdTipoPrestacion;
			
			item.IdObraSocial = varIdObraSocial;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.IdTurno = varIdTurno;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.TAS = varTAS;
			
			item.TAD = varTAD;
			
			item.Imc = varImc;
			
			item.PerimetroCefalico = varPerimetroCefalico;
			
			item.RiesgoCardiovascular = varRiesgoCardiovascular;
			
			item.IdProgramaOdontologia = varIdProgramaOdontologia;
			
			item.PrimerConsultaOdontologia = varPrimerConsultaOdontologia;
			
			item.IdEquipo = varIdEquipo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdConsulta,int? varIdEfector,DateTime? varFecha,string varHora,int? varIdPaciente,int? varIdEspecialidad,int? varIdProfesional,string varMotivoConsulta,string varInformeConsulta,int? varIdDerivadoPor,int? varIdDerivadoHacia,int? varIdTipoPrestacion,int? varIdObraSocial,int? varIdUsuarioRegistro,DateTime? varFechaRegistro,int varIdTurno,decimal? varPeso,decimal? varTalla,int? varTAS,decimal? varTAD,decimal? varImc,decimal? varPerimetroCefalico,int? varRiesgoCardiovascular,int varIdProgramaOdontologia,int varPrimerConsultaOdontologia,int? varIdEquipo)
		{
			ConConsultum item = new ConConsultum();
			
				item.IdConsulta = varIdConsulta;
			
				item.IdEfector = varIdEfector;
			
				item.Fecha = varFecha;
			
				item.Hora = varHora;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdEspecialidad = varIdEspecialidad;
			
				item.IdProfesional = varIdProfesional;
			
				item.MotivoConsulta = varMotivoConsulta;
			
				item.InformeConsulta = varInformeConsulta;
			
				item.IdDerivadoPor = varIdDerivadoPor;
			
				item.IdDerivadoHacia = varIdDerivadoHacia;
			
				item.IdTipoPrestacion = varIdTipoPrestacion;
			
				item.IdObraSocial = varIdObraSocial;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.IdTurno = varIdTurno;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.TAS = varTAS;
			
				item.TAD = varTAD;
			
				item.Imc = varImc;
			
				item.PerimetroCefalico = varPerimetroCefalico;
			
				item.RiesgoCardiovascular = varRiesgoCardiovascular;
			
				item.IdProgramaOdontologia = varIdProgramaOdontologia;
			
				item.PrimerConsultaOdontologia = varPrimerConsultaOdontologia;
			
				item.IdEquipo = varIdEquipo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdConsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEspecialidadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoConsultaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeConsultaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDerivadoPorColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDerivadoHaciaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPrestacionColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn TASColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn TADColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ImcColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn PerimetroCefalicoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn RiesgoCardiovascularColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProgramaOdontologiaColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimerConsultaOdontologiaColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEquipoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdConsulta = @"idConsulta";
			 public static string IdEfector = @"idEfector";
			 public static string Fecha = @"fecha";
			 public static string Hora = @"hora";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdEspecialidad = @"idEspecialidad";
			 public static string IdProfesional = @"idProfesional";
			 public static string MotivoConsulta = @"motivoConsulta";
			 public static string InformeConsulta = @"informeConsulta";
			 public static string IdDerivadoPor = @"idDerivadoPor";
			 public static string IdDerivadoHacia = @"idDerivadoHacia";
			 public static string IdTipoPrestacion = @"idTipoPrestacion";
			 public static string IdObraSocial = @"idObraSocial";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string IdTurno = @"idTurno";
			 public static string Peso = @"peso";
			 public static string Talla = @"talla";
			 public static string TAS = @"tAS";
			 public static string TAD = @"tAD";
			 public static string Imc = @"imc";
			 public static string PerimetroCefalico = @"perimetroCefalico";
			 public static string RiesgoCardiovascular = @"riesgoCardiovascular";
			 public static string IdProgramaOdontologia = @"idProgramaOdontologia";
			 public static string PrimerConsultaOdontologia = @"primerConsultaOdontologia";
			 public static string IdEquipo = @"idEquipo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colConConsultaMedicamentoRecords != null)
                {
                    foreach (DalSic.ConConsultaMedicamento item in colConConsultaMedicamentoRecords)
                    {
                        if (item.IdConsulta != IdConsulta)
                        {
                            item.IdConsulta = IdConsulta;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoRecords != null)
                {
                    foreach (DalSic.AprControlNiñoSano item in colAprControlNiñoSanoRecords)
                    {
                        if (item.IdConsulta != IdConsulta)
                        {
                            item.IdConsulta = IdConsulta;
                        }
                    }
               }
		
                if (colAprHistoriaClinicaPerinatalDetalleRecords != null)
                {
                    foreach (DalSic.AprHistoriaClinicaPerinatalDetalle item in colAprHistoriaClinicaPerinatalDetalleRecords)
                    {
                        if (item.IdConsulta != IdConsulta)
                        {
                            item.IdConsulta = IdConsulta;
                        }
                    }
               }
		
                if (colConConsultaDiagnosticoRecords != null)
                {
                    foreach (DalSic.ConConsultaDiagnostico item in colConConsultaDiagnosticoRecords)
                    {
                        if (item.IdConsulta != IdConsulta)
                        {
                            item.IdConsulta = IdConsulta;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colConConsultaMedicamentoRecords != null)
                {
                    colConConsultaMedicamentoRecords.SaveAll();
               }
		
                if (colAprControlNiñoSanoRecords != null)
                {
                    colAprControlNiñoSanoRecords.SaveAll();
               }
		
                if (colAprHistoriaClinicaPerinatalDetalleRecords != null)
                {
                    colAprHistoriaClinicaPerinatalDetalleRecords.SaveAll();
               }
		
                if (colConConsultaDiagnosticoRecords != null)
                {
                    colConConsultaDiagnosticoRecords.SaveAll();
               }
		}
        #endregion
	}
}
