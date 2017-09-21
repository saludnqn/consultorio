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
	/// Strongly-typed collection for the GuardiaRegistro class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistroCollection : ActiveList<GuardiaRegistro, GuardiaRegistroCollection>
	{	   
		public GuardiaRegistroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistroCollection</returns>
		public GuardiaRegistroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistro o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistro : ActiveRecord<GuardiaRegistro>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistro()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistro(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistro(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistro(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
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
				
				TableSchema.TableColumn colvarTipoGuardia = new TableSchema.TableColumn(schema);
				colvarTipoGuardia.ColumnName = "tipo_guardia";
				colvarTipoGuardia.DataType = DbType.Boolean;
				colvarTipoGuardia.MaxLength = 0;
				colvarTipoGuardia.AutoIncrement = false;
				colvarTipoGuardia.IsNullable = false;
				colvarTipoGuardia.IsPrimaryKey = false;
				colvarTipoGuardia.IsForeignKey = false;
				colvarTipoGuardia.IsReadOnly = false;
				colvarTipoGuardia.DefaultSetting = @"";
				colvarTipoGuardia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoGuardia);
				
				TableSchema.TableColumn colvarHistoria = new TableSchema.TableColumn(schema);
				colvarHistoria.ColumnName = "historia";
				colvarHistoria.DataType = DbType.Int32;
				colvarHistoria.MaxLength = 0;
				colvarHistoria.AutoIncrement = false;
				colvarHistoria.IsNullable = false;
				colvarHistoria.IsPrimaryKey = false;
				colvarHistoria.IsForeignKey = true;
				colvarHistoria.IsReadOnly = false;
				colvarHistoria.DefaultSetting = @"";
				
					colvarHistoria.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarHistoria);
				
				TableSchema.TableColumn colvarIngresoFechaHora = new TableSchema.TableColumn(schema);
				colvarIngresoFechaHora.ColumnName = "ingreso_fechaHora";
				colvarIngresoFechaHora.DataType = DbType.DateTime;
				colvarIngresoFechaHora.MaxLength = 0;
				colvarIngresoFechaHora.AutoIncrement = false;
				colvarIngresoFechaHora.IsNullable = true;
				colvarIngresoFechaHora.IsPrimaryKey = false;
				colvarIngresoFechaHora.IsForeignKey = false;
				colvarIngresoFechaHora.IsReadOnly = false;
				colvarIngresoFechaHora.DefaultSetting = @"";
				colvarIngresoFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngresoFechaHora);
				
				TableSchema.TableColumn colvarIngresoTipo = new TableSchema.TableColumn(schema);
				colvarIngresoTipo.ColumnName = "ingreso_tipo";
				colvarIngresoTipo.DataType = DbType.Int32;
				colvarIngresoTipo.MaxLength = 0;
				colvarIngresoTipo.AutoIncrement = false;
				colvarIngresoTipo.IsNullable = true;
				colvarIngresoTipo.IsPrimaryKey = false;
				colvarIngresoTipo.IsForeignKey = true;
				colvarIngresoTipo.IsReadOnly = false;
				colvarIngresoTipo.DefaultSetting = @"";
				
					colvarIngresoTipo.ForeignKeyTableName = "Guardia_TiposIngreso";
				schema.Columns.Add(colvarIngresoTipo);
				
				TableSchema.TableColumn colvarAtencionFechaHora = new TableSchema.TableColumn(schema);
				colvarAtencionFechaHora.ColumnName = "atencion_fechaHora";
				colvarAtencionFechaHora.DataType = DbType.DateTime;
				colvarAtencionFechaHora.MaxLength = 0;
				colvarAtencionFechaHora.AutoIncrement = false;
				colvarAtencionFechaHora.IsNullable = true;
				colvarAtencionFechaHora.IsPrimaryKey = false;
				colvarAtencionFechaHora.IsForeignKey = false;
				colvarAtencionFechaHora.IsReadOnly = false;
				colvarAtencionFechaHora.DefaultSetting = @"";
				colvarAtencionFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAtencionFechaHora);
				
				TableSchema.TableColumn colvarEgresoFechaHora = new TableSchema.TableColumn(schema);
				colvarEgresoFechaHora.ColumnName = "egreso_fechaHora";
				colvarEgresoFechaHora.DataType = DbType.DateTime;
				colvarEgresoFechaHora.MaxLength = 0;
				colvarEgresoFechaHora.AutoIncrement = false;
				colvarEgresoFechaHora.IsNullable = true;
				colvarEgresoFechaHora.IsPrimaryKey = false;
				colvarEgresoFechaHora.IsForeignKey = false;
				colvarEgresoFechaHora.IsReadOnly = false;
				colvarEgresoFechaHora.DefaultSetting = @"";
				colvarEgresoFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoFechaHora);
				
				TableSchema.TableColumn colvarEgresoTipo = new TableSchema.TableColumn(schema);
				colvarEgresoTipo.ColumnName = "egreso_tipo";
				colvarEgresoTipo.DataType = DbType.Int32;
				colvarEgresoTipo.MaxLength = 0;
				colvarEgresoTipo.AutoIncrement = false;
				colvarEgresoTipo.IsNullable = true;
				colvarEgresoTipo.IsPrimaryKey = false;
				colvarEgresoTipo.IsForeignKey = true;
				colvarEgresoTipo.IsReadOnly = false;
				colvarEgresoTipo.DefaultSetting = @"";
				
					colvarEgresoTipo.ForeignKeyTableName = "Guardia_TiposEgresos";
				schema.Columns.Add(colvarEgresoTipo);
				
				TableSchema.TableColumn colvarEgresoUbicacion = new TableSchema.TableColumn(schema);
				colvarEgresoUbicacion.ColumnName = "egreso_ubicacion";
				colvarEgresoUbicacion.DataType = DbType.Int32;
				colvarEgresoUbicacion.MaxLength = 0;
				colvarEgresoUbicacion.AutoIncrement = false;
				colvarEgresoUbicacion.IsNullable = true;
				colvarEgresoUbicacion.IsPrimaryKey = false;
				colvarEgresoUbicacion.IsForeignKey = false;
				colvarEgresoUbicacion.IsReadOnly = false;
				colvarEgresoUbicacion.DefaultSetting = @"";
				colvarEgresoUbicacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoUbicacion);
				
				TableSchema.TableColumn colvarClasificacion = new TableSchema.TableColumn(schema);
				colvarClasificacion.ColumnName = "clasificacion";
				colvarClasificacion.DataType = DbType.Int32;
				colvarClasificacion.MaxLength = 0;
				colvarClasificacion.AutoIncrement = false;
				colvarClasificacion.IsNullable = false;
				colvarClasificacion.IsPrimaryKey = false;
				colvarClasificacion.IsForeignKey = false;
				colvarClasificacion.IsReadOnly = false;
				colvarClasificacion.DefaultSetting = @"";
				colvarClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClasificacion);
				
				TableSchema.TableColumn colvarMedicoCabecera = new TableSchema.TableColumn(schema);
				colvarMedicoCabecera.ColumnName = "medicoCabecera";
				colvarMedicoCabecera.DataType = DbType.AnsiString;
				colvarMedicoCabecera.MaxLength = -1;
				colvarMedicoCabecera.AutoIncrement = false;
				colvarMedicoCabecera.IsNullable = true;
				colvarMedicoCabecera.IsPrimaryKey = false;
				colvarMedicoCabecera.IsForeignKey = false;
				colvarMedicoCabecera.IsReadOnly = false;
				colvarMedicoCabecera.DefaultSetting = @"";
				colvarMedicoCabecera.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicoCabecera);
				
				TableSchema.TableColumn colvarMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarMotivoConsulta.ColumnName = "motivoConsulta";
				colvarMotivoConsulta.DataType = DbType.AnsiString;
				colvarMotivoConsulta.MaxLength = -1;
				colvarMotivoConsulta.AutoIncrement = false;
				colvarMotivoConsulta.IsNullable = false;
				colvarMotivoConsulta.IsPrimaryKey = false;
				colvarMotivoConsulta.IsForeignKey = false;
				colvarMotivoConsulta.IsReadOnly = false;
				colvarMotivoConsulta.DefaultSetting = @"";
				colvarMotivoConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivoConsulta);
				
				TableSchema.TableColumn colvarDatosEnfermeria = new TableSchema.TableColumn(schema);
				colvarDatosEnfermeria.ColumnName = "datosEnfermeria";
				colvarDatosEnfermeria.DataType = DbType.AnsiString;
				colvarDatosEnfermeria.MaxLength = -1;
				colvarDatosEnfermeria.AutoIncrement = false;
				colvarDatosEnfermeria.IsNullable = true;
				colvarDatosEnfermeria.IsPrimaryKey = false;
				colvarDatosEnfermeria.IsForeignKey = false;
				colvarDatosEnfermeria.IsReadOnly = false;
				colvarDatosEnfermeria.DefaultSetting = @"";
				colvarDatosEnfermeria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatosEnfermeria);
				
				TableSchema.TableColumn colvarInterrogatorio = new TableSchema.TableColumn(schema);
				colvarInterrogatorio.ColumnName = "interrogatorio";
				colvarInterrogatorio.DataType = DbType.AnsiString;
				colvarInterrogatorio.MaxLength = -1;
				colvarInterrogatorio.AutoIncrement = false;
				colvarInterrogatorio.IsNullable = true;
				colvarInterrogatorio.IsPrimaryKey = false;
				colvarInterrogatorio.IsForeignKey = false;
				colvarInterrogatorio.IsReadOnly = false;
				colvarInterrogatorio.DefaultSetting = @"";
				colvarInterrogatorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInterrogatorio);
				
				TableSchema.TableColumn colvarEvolucionEnfermeria = new TableSchema.TableColumn(schema);
				colvarEvolucionEnfermeria.ColumnName = "evolucionEnfermeria";
				colvarEvolucionEnfermeria.DataType = DbType.AnsiString;
				colvarEvolucionEnfermeria.MaxLength = -1;
				colvarEvolucionEnfermeria.AutoIncrement = false;
				colvarEvolucionEnfermeria.IsNullable = true;
				colvarEvolucionEnfermeria.IsPrimaryKey = false;
				colvarEvolucionEnfermeria.IsForeignKey = false;
				colvarEvolucionEnfermeria.IsReadOnly = false;
				colvarEvolucionEnfermeria.DefaultSetting = @"";
				colvarEvolucionEnfermeria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEvolucionEnfermeria);
				
				TableSchema.TableColumn colvarMedicoResponsable = new TableSchema.TableColumn(schema);
				colvarMedicoResponsable.ColumnName = "medicoResponsable";
				colvarMedicoResponsable.DataType = DbType.Int32;
				colvarMedicoResponsable.MaxLength = 0;
				colvarMedicoResponsable.AutoIncrement = false;
				colvarMedicoResponsable.IsNullable = true;
				colvarMedicoResponsable.IsPrimaryKey = false;
				colvarMedicoResponsable.IsForeignKey = true;
				colvarMedicoResponsable.IsReadOnly = false;
				colvarMedicoResponsable.DefaultSetting = @"";
				
					colvarMedicoResponsable.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarMedicoResponsable);
				
				TableSchema.TableColumn colvarEvolucionMedica = new TableSchema.TableColumn(schema);
				colvarEvolucionMedica.ColumnName = "evolucionMedica";
				colvarEvolucionMedica.DataType = DbType.AnsiString;
				colvarEvolucionMedica.MaxLength = -1;
				colvarEvolucionMedica.AutoIncrement = false;
				colvarEvolucionMedica.IsNullable = true;
				colvarEvolucionMedica.IsPrimaryKey = false;
				colvarEvolucionMedica.IsForeignKey = false;
				colvarEvolucionMedica.IsReadOnly = false;
				colvarEvolucionMedica.DefaultSetting = @"";
				colvarEvolucionMedica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEvolucionMedica);
				
				TableSchema.TableColumn colvarDiagnosticoPresuntivo = new TableSchema.TableColumn(schema);
				colvarDiagnosticoPresuntivo.ColumnName = "diagnosticoPresuntivo";
				colvarDiagnosticoPresuntivo.DataType = DbType.AnsiString;
				colvarDiagnosticoPresuntivo.MaxLength = -1;
				colvarDiagnosticoPresuntivo.AutoIncrement = false;
				colvarDiagnosticoPresuntivo.IsNullable = true;
				colvarDiagnosticoPresuntivo.IsPrimaryKey = false;
				colvarDiagnosticoPresuntivo.IsForeignKey = false;
				colvarDiagnosticoPresuntivo.IsReadOnly = false;
				colvarDiagnosticoPresuntivo.DefaultSetting = @"";
				colvarDiagnosticoPresuntivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoPresuntivo);
				
				TableSchema.TableColumn colvarDiagnosticoDefinitivo = new TableSchema.TableColumn(schema);
				colvarDiagnosticoDefinitivo.ColumnName = "diagnosticoDefinitivo";
				colvarDiagnosticoDefinitivo.DataType = DbType.AnsiString;
				colvarDiagnosticoDefinitivo.MaxLength = -1;
				colvarDiagnosticoDefinitivo.AutoIncrement = false;
				colvarDiagnosticoDefinitivo.IsNullable = true;
				colvarDiagnosticoDefinitivo.IsPrimaryKey = false;
				colvarDiagnosticoDefinitivo.IsForeignKey = false;
				colvarDiagnosticoDefinitivo.IsReadOnly = false;
				colvarDiagnosticoDefinitivo.DefaultSetting = @"";
				colvarDiagnosticoDefinitivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoDefinitivo);
				
				TableSchema.TableColumn colvarDiagnosticoDefinitivoCIE10 = new TableSchema.TableColumn(schema);
				colvarDiagnosticoDefinitivoCIE10.ColumnName = "diagnosticoDefinitivo_CIE10";
				colvarDiagnosticoDefinitivoCIE10.DataType = DbType.Int32;
				colvarDiagnosticoDefinitivoCIE10.MaxLength = 0;
				colvarDiagnosticoDefinitivoCIE10.AutoIncrement = false;
				colvarDiagnosticoDefinitivoCIE10.IsNullable = true;
				colvarDiagnosticoDefinitivoCIE10.IsPrimaryKey = false;
				colvarDiagnosticoDefinitivoCIE10.IsForeignKey = false;
				colvarDiagnosticoDefinitivoCIE10.IsReadOnly = false;
				colvarDiagnosticoDefinitivoCIE10.DefaultSetting = @"";
				colvarDiagnosticoDefinitivoCIE10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoDefinitivoCIE10);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarEstadoActual = new TableSchema.TableColumn(schema);
				colvarEstadoActual.ColumnName = "estado_actual";
				colvarEstadoActual.DataType = DbType.Int32;
				colvarEstadoActual.MaxLength = 0;
				colvarEstadoActual.AutoIncrement = false;
				colvarEstadoActual.IsNullable = false;
				colvarEstadoActual.IsPrimaryKey = false;
				colvarEstadoActual.IsForeignKey = true;
				colvarEstadoActual.IsReadOnly = false;
				colvarEstadoActual.DefaultSetting = @"";
				
					colvarEstadoActual.ForeignKeyTableName = "Guardia_Registros_Estados";
				schema.Columns.Add(colvarEstadoActual);
				
				TableSchema.TableColumn colvarEstadoUbicacion = new TableSchema.TableColumn(schema);
				colvarEstadoUbicacion.ColumnName = "estado_ubicacion";
				colvarEstadoUbicacion.DataType = DbType.Int32;
				colvarEstadoUbicacion.MaxLength = 0;
				colvarEstadoUbicacion.AutoIncrement = false;
				colvarEstadoUbicacion.IsNullable = true;
				colvarEstadoUbicacion.IsPrimaryKey = false;
				colvarEstadoUbicacion.IsForeignKey = true;
				colvarEstadoUbicacion.IsReadOnly = false;
				colvarEstadoUbicacion.DefaultSetting = @"";
				
					colvarEstadoUbicacion.ForeignKeyTableName = "Ubicaciones";
				schema.Columns.Add(colvarEstadoUbicacion);
				
				TableSchema.TableColumn colvarEstadoTurno = new TableSchema.TableColumn(schema);
				colvarEstadoTurno.ColumnName = "estado_turno";
				colvarEstadoTurno.DataType = DbType.Int32;
				colvarEstadoTurno.MaxLength = 0;
				colvarEstadoTurno.AutoIncrement = false;
				colvarEstadoTurno.IsNullable = true;
				colvarEstadoTurno.IsPrimaryKey = false;
				colvarEstadoTurno.IsForeignKey = false;
				colvarEstadoTurno.IsReadOnly = false;
				colvarEstadoTurno.DefaultSetting = @"";
				colvarEstadoTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoTurno);
				
				TableSchema.TableColumn colvarEstadoTurnoLlamado = new TableSchema.TableColumn(schema);
				colvarEstadoTurnoLlamado.ColumnName = "estado_turnoLlamado";
				colvarEstadoTurnoLlamado.DataType = DbType.Boolean;
				colvarEstadoTurnoLlamado.MaxLength = 0;
				colvarEstadoTurnoLlamado.AutoIncrement = false;
				colvarEstadoTurnoLlamado.IsNullable = true;
				colvarEstadoTurnoLlamado.IsPrimaryKey = false;
				colvarEstadoTurnoLlamado.IsForeignKey = false;
				colvarEstadoTurnoLlamado.IsReadOnly = false;
				colvarEstadoTurnoLlamado.DefaultSetting = @"";
				colvarEstadoTurnoLlamado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoTurnoLlamado);
				
				TableSchema.TableColumn colvarTurnoLlamadoFechaHora = new TableSchema.TableColumn(schema);
				colvarTurnoLlamadoFechaHora.ColumnName = "turnoLlamado_fechaHora";
				colvarTurnoLlamadoFechaHora.DataType = DbType.DateTime;
				colvarTurnoLlamadoFechaHora.MaxLength = 0;
				colvarTurnoLlamadoFechaHora.AutoIncrement = false;
				colvarTurnoLlamadoFechaHora.IsNullable = true;
				colvarTurnoLlamadoFechaHora.IsPrimaryKey = false;
				colvarTurnoLlamadoFechaHora.IsForeignKey = false;
				colvarTurnoLlamadoFechaHora.IsReadOnly = false;
				colvarTurnoLlamadoFechaHora.DefaultSetting = @"";
				colvarTurnoLlamadoFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTurnoLlamadoFechaHora);
				
				TableSchema.TableColumn colvarRecuperoFinancieroPrinted = new TableSchema.TableColumn(schema);
				colvarRecuperoFinancieroPrinted.ColumnName = "recuperoFinancieroPrinted";
				colvarRecuperoFinancieroPrinted.DataType = DbType.Boolean;
				colvarRecuperoFinancieroPrinted.MaxLength = 0;
				colvarRecuperoFinancieroPrinted.AutoIncrement = false;
				colvarRecuperoFinancieroPrinted.IsNullable = true;
				colvarRecuperoFinancieroPrinted.IsPrimaryKey = false;
				colvarRecuperoFinancieroPrinted.IsForeignKey = false;
				colvarRecuperoFinancieroPrinted.IsReadOnly = false;
				colvarRecuperoFinancieroPrinted.DefaultSetting = @"";
				colvarRecuperoFinancieroPrinted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecuperoFinancieroPrinted);
				
				TableSchema.TableColumn colvarC2 = new TableSchema.TableColumn(schema);
				colvarC2.ColumnName = "c2";
				colvarC2.DataType = DbType.Boolean;
				colvarC2.MaxLength = 0;
				colvarC2.AutoIncrement = false;
				colvarC2.IsNullable = true;
				colvarC2.IsPrimaryKey = false;
				colvarC2.IsForeignKey = false;
				colvarC2.IsReadOnly = false;
				colvarC2.DefaultSetting = @"";
				colvarC2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarC2);
				
				TableSchema.TableColumn colvarPresentaCarnetVacunacion = new TableSchema.TableColumn(schema);
				colvarPresentaCarnetVacunacion.ColumnName = "presentaCarnetVacunacion";
				colvarPresentaCarnetVacunacion.DataType = DbType.Boolean;
				colvarPresentaCarnetVacunacion.MaxLength = 0;
				colvarPresentaCarnetVacunacion.AutoIncrement = false;
				colvarPresentaCarnetVacunacion.IsNullable = true;
				colvarPresentaCarnetVacunacion.IsPrimaryKey = false;
				colvarPresentaCarnetVacunacion.IsForeignKey = false;
				colvarPresentaCarnetVacunacion.IsReadOnly = false;
				colvarPresentaCarnetVacunacion.DefaultSetting = @"";
				colvarPresentaCarnetVacunacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresentaCarnetVacunacion);
				
				TableSchema.TableColumn colvarVacunacionCompleta = new TableSchema.TableColumn(schema);
				colvarVacunacionCompleta.ColumnName = "vacunacionCompleta";
				colvarVacunacionCompleta.DataType = DbType.Boolean;
				colvarVacunacionCompleta.MaxLength = 0;
				colvarVacunacionCompleta.AutoIncrement = false;
				colvarVacunacionCompleta.IsNullable = true;
				colvarVacunacionCompleta.IsPrimaryKey = false;
				colvarVacunacionCompleta.IsForeignKey = false;
				colvarVacunacionCompleta.IsReadOnly = false;
				colvarVacunacionCompleta.DefaultSetting = @"";
				colvarVacunacionCompleta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunacionCompleta);
				
				TableSchema.TableColumn colvarPlanNacer = new TableSchema.TableColumn(schema);
				colvarPlanNacer.ColumnName = "planNacer";
				colvarPlanNacer.DataType = DbType.Boolean;
				colvarPlanNacer.MaxLength = 0;
				colvarPlanNacer.AutoIncrement = false;
				colvarPlanNacer.IsNullable = true;
				colvarPlanNacer.IsPrimaryKey = false;
				colvarPlanNacer.IsForeignKey = false;
				colvarPlanNacer.IsReadOnly = false;
				colvarPlanNacer.DefaultSetting = @"";
				colvarPlanNacer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlanNacer);
				
				TableSchema.TableColumn colvarPlanNacerPosta = new TableSchema.TableColumn(schema);
				colvarPlanNacerPosta.ColumnName = "planNacerPosta";
				colvarPlanNacerPosta.DataType = DbType.Boolean;
				colvarPlanNacerPosta.MaxLength = 0;
				colvarPlanNacerPosta.AutoIncrement = false;
				colvarPlanNacerPosta.IsNullable = true;
				colvarPlanNacerPosta.IsPrimaryKey = false;
				colvarPlanNacerPosta.IsForeignKey = false;
				colvarPlanNacerPosta.IsReadOnly = false;
				colvarPlanNacerPosta.DefaultSetting = @"";
				colvarPlanNacerPosta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlanNacerPosta);
				
				TableSchema.TableColumn colvarPlanNacerInternacion = new TableSchema.TableColumn(schema);
				colvarPlanNacerInternacion.ColumnName = "planNacerInternacion";
				colvarPlanNacerInternacion.DataType = DbType.Boolean;
				colvarPlanNacerInternacion.MaxLength = 0;
				colvarPlanNacerInternacion.AutoIncrement = false;
				colvarPlanNacerInternacion.IsNullable = true;
				colvarPlanNacerInternacion.IsPrimaryKey = false;
				colvarPlanNacerInternacion.IsForeignKey = false;
				colvarPlanNacerInternacion.IsReadOnly = false;
				colvarPlanNacerInternacion.DefaultSetting = @"";
				colvarPlanNacerInternacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlanNacerInternacion);
				
				TableSchema.TableColumn colvarAuditIngresoFechaHora = new TableSchema.TableColumn(schema);
				colvarAuditIngresoFechaHora.ColumnName = "audit_ingreso_fechaHora";
				colvarAuditIngresoFechaHora.DataType = DbType.DateTime;
				colvarAuditIngresoFechaHora.MaxLength = 0;
				colvarAuditIngresoFechaHora.AutoIncrement = false;
				colvarAuditIngresoFechaHora.IsNullable = true;
				colvarAuditIngresoFechaHora.IsPrimaryKey = false;
				colvarAuditIngresoFechaHora.IsForeignKey = false;
				colvarAuditIngresoFechaHora.IsReadOnly = false;
				colvarAuditIngresoFechaHora.DefaultSetting = @"";
				colvarAuditIngresoFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditIngresoFechaHora);
				
				TableSchema.TableColumn colvarAuditAtencionFechaHora = new TableSchema.TableColumn(schema);
				colvarAuditAtencionFechaHora.ColumnName = "audit_atencion_fechaHora";
				colvarAuditAtencionFechaHora.DataType = DbType.DateTime;
				colvarAuditAtencionFechaHora.MaxLength = 0;
				colvarAuditAtencionFechaHora.AutoIncrement = false;
				colvarAuditAtencionFechaHora.IsNullable = true;
				colvarAuditAtencionFechaHora.IsPrimaryKey = false;
				colvarAuditAtencionFechaHora.IsForeignKey = false;
				colvarAuditAtencionFechaHora.IsReadOnly = false;
				colvarAuditAtencionFechaHora.DefaultSetting = @"";
				colvarAuditAtencionFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditAtencionFechaHora);
				
				TableSchema.TableColumn colvarAuditEgresoFechaHora = new TableSchema.TableColumn(schema);
				colvarAuditEgresoFechaHora.ColumnName = "audit_egreso_fechaHora";
				colvarAuditEgresoFechaHora.DataType = DbType.DateTime;
				colvarAuditEgresoFechaHora.MaxLength = 0;
				colvarAuditEgresoFechaHora.AutoIncrement = false;
				colvarAuditEgresoFechaHora.IsNullable = true;
				colvarAuditEgresoFechaHora.IsPrimaryKey = false;
				colvarAuditEgresoFechaHora.IsForeignKey = false;
				colvarAuditEgresoFechaHora.IsReadOnly = false;
				colvarAuditEgresoFechaHora.DefaultSetting = @"";
				colvarAuditEgresoFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditEgresoFechaHora);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("TipoGuardia")]
		[Bindable(true)]
		public bool TipoGuardia 
		{
			get { return GetColumnValue<bool>(Columns.TipoGuardia); }
			set { SetColumnValue(Columns.TipoGuardia, value); }
		}
		  
		[XmlAttribute("Historia")]
		[Bindable(true)]
		public int Historia 
		{
			get { return GetColumnValue<int>(Columns.Historia); }
			set { SetColumnValue(Columns.Historia, value); }
		}
		  
		[XmlAttribute("IngresoFechaHora")]
		[Bindable(true)]
		public DateTime? IngresoFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.IngresoFechaHora); }
			set { SetColumnValue(Columns.IngresoFechaHora, value); }
		}
		  
		[XmlAttribute("IngresoTipo")]
		[Bindable(true)]
		public int? IngresoTipo 
		{
			get { return GetColumnValue<int?>(Columns.IngresoTipo); }
			set { SetColumnValue(Columns.IngresoTipo, value); }
		}
		  
		[XmlAttribute("AtencionFechaHora")]
		[Bindable(true)]
		public DateTime? AtencionFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.AtencionFechaHora); }
			set { SetColumnValue(Columns.AtencionFechaHora, value); }
		}
		  
		[XmlAttribute("EgresoFechaHora")]
		[Bindable(true)]
		public DateTime? EgresoFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.EgresoFechaHora); }
			set { SetColumnValue(Columns.EgresoFechaHora, value); }
		}
		  
		[XmlAttribute("EgresoTipo")]
		[Bindable(true)]
		public int? EgresoTipo 
		{
			get { return GetColumnValue<int?>(Columns.EgresoTipo); }
			set { SetColumnValue(Columns.EgresoTipo, value); }
		}
		  
		[XmlAttribute("EgresoUbicacion")]
		[Bindable(true)]
		public int? EgresoUbicacion 
		{
			get { return GetColumnValue<int?>(Columns.EgresoUbicacion); }
			set { SetColumnValue(Columns.EgresoUbicacion, value); }
		}
		  
		[XmlAttribute("Clasificacion")]
		[Bindable(true)]
		public int Clasificacion 
		{
			get { return GetColumnValue<int>(Columns.Clasificacion); }
			set { SetColumnValue(Columns.Clasificacion, value); }
		}
		  
		[XmlAttribute("MedicoCabecera")]
		[Bindable(true)]
		public string MedicoCabecera 
		{
			get { return GetColumnValue<string>(Columns.MedicoCabecera); }
			set { SetColumnValue(Columns.MedicoCabecera, value); }
		}
		  
		[XmlAttribute("MotivoConsulta")]
		[Bindable(true)]
		public string MotivoConsulta 
		{
			get { return GetColumnValue<string>(Columns.MotivoConsulta); }
			set { SetColumnValue(Columns.MotivoConsulta, value); }
		}
		  
		[XmlAttribute("DatosEnfermeria")]
		[Bindable(true)]
		public string DatosEnfermeria 
		{
			get { return GetColumnValue<string>(Columns.DatosEnfermeria); }
			set { SetColumnValue(Columns.DatosEnfermeria, value); }
		}
		  
		[XmlAttribute("Interrogatorio")]
		[Bindable(true)]
		public string Interrogatorio 
		{
			get { return GetColumnValue<string>(Columns.Interrogatorio); }
			set { SetColumnValue(Columns.Interrogatorio, value); }
		}
		  
		[XmlAttribute("EvolucionEnfermeria")]
		[Bindable(true)]
		public string EvolucionEnfermeria 
		{
			get { return GetColumnValue<string>(Columns.EvolucionEnfermeria); }
			set { SetColumnValue(Columns.EvolucionEnfermeria, value); }
		}
		  
		[XmlAttribute("MedicoResponsable")]
		[Bindable(true)]
		public int? MedicoResponsable 
		{
			get { return GetColumnValue<int?>(Columns.MedicoResponsable); }
			set { SetColumnValue(Columns.MedicoResponsable, value); }
		}
		  
		[XmlAttribute("EvolucionMedica")]
		[Bindable(true)]
		public string EvolucionMedica 
		{
			get { return GetColumnValue<string>(Columns.EvolucionMedica); }
			set { SetColumnValue(Columns.EvolucionMedica, value); }
		}
		  
		[XmlAttribute("DiagnosticoPresuntivo")]
		[Bindable(true)]
		public string DiagnosticoPresuntivo 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoPresuntivo); }
			set { SetColumnValue(Columns.DiagnosticoPresuntivo, value); }
		}
		  
		[XmlAttribute("DiagnosticoDefinitivo")]
		[Bindable(true)]
		public string DiagnosticoDefinitivo 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoDefinitivo); }
			set { SetColumnValue(Columns.DiagnosticoDefinitivo, value); }
		}
		  
		[XmlAttribute("DiagnosticoDefinitivoCIE10")]
		[Bindable(true)]
		public int? DiagnosticoDefinitivoCIE10 
		{
			get { return GetColumnValue<int?>(Columns.DiagnosticoDefinitivoCIE10); }
			set { SetColumnValue(Columns.DiagnosticoDefinitivoCIE10, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("EstadoActual")]
		[Bindable(true)]
		public int EstadoActual 
		{
			get { return GetColumnValue<int>(Columns.EstadoActual); }
			set { SetColumnValue(Columns.EstadoActual, value); }
		}
		  
		[XmlAttribute("EstadoUbicacion")]
		[Bindable(true)]
		public int? EstadoUbicacion 
		{
			get { return GetColumnValue<int?>(Columns.EstadoUbicacion); }
			set { SetColumnValue(Columns.EstadoUbicacion, value); }
		}
		  
		[XmlAttribute("EstadoTurno")]
		[Bindable(true)]
		public int? EstadoTurno 
		{
			get { return GetColumnValue<int?>(Columns.EstadoTurno); }
			set { SetColumnValue(Columns.EstadoTurno, value); }
		}
		  
		[XmlAttribute("EstadoTurnoLlamado")]
		[Bindable(true)]
		public bool? EstadoTurnoLlamado 
		{
			get { return GetColumnValue<bool?>(Columns.EstadoTurnoLlamado); }
			set { SetColumnValue(Columns.EstadoTurnoLlamado, value); }
		}
		  
		[XmlAttribute("TurnoLlamadoFechaHora")]
		[Bindable(true)]
		public DateTime? TurnoLlamadoFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.TurnoLlamadoFechaHora); }
			set { SetColumnValue(Columns.TurnoLlamadoFechaHora, value); }
		}
		  
		[XmlAttribute("RecuperoFinancieroPrinted")]
		[Bindable(true)]
		public bool? RecuperoFinancieroPrinted 
		{
			get { return GetColumnValue<bool?>(Columns.RecuperoFinancieroPrinted); }
			set { SetColumnValue(Columns.RecuperoFinancieroPrinted, value); }
		}
		  
		[XmlAttribute("C2")]
		[Bindable(true)]
		public bool? C2 
		{
			get { return GetColumnValue<bool?>(Columns.C2); }
			set { SetColumnValue(Columns.C2, value); }
		}
		  
		[XmlAttribute("PresentaCarnetVacunacion")]
		[Bindable(true)]
		public bool? PresentaCarnetVacunacion 
		{
			get { return GetColumnValue<bool?>(Columns.PresentaCarnetVacunacion); }
			set { SetColumnValue(Columns.PresentaCarnetVacunacion, value); }
		}
		  
		[XmlAttribute("VacunacionCompleta")]
		[Bindable(true)]
		public bool? VacunacionCompleta 
		{
			get { return GetColumnValue<bool?>(Columns.VacunacionCompleta); }
			set { SetColumnValue(Columns.VacunacionCompleta, value); }
		}
		  
		[XmlAttribute("PlanNacer")]
		[Bindable(true)]
		public bool? PlanNacer 
		{
			get { return GetColumnValue<bool?>(Columns.PlanNacer); }
			set { SetColumnValue(Columns.PlanNacer, value); }
		}
		  
		[XmlAttribute("PlanNacerPosta")]
		[Bindable(true)]
		public bool? PlanNacerPosta 
		{
			get { return GetColumnValue<bool?>(Columns.PlanNacerPosta); }
			set { SetColumnValue(Columns.PlanNacerPosta, value); }
		}
		  
		[XmlAttribute("PlanNacerInternacion")]
		[Bindable(true)]
		public bool? PlanNacerInternacion 
		{
			get { return GetColumnValue<bool?>(Columns.PlanNacerInternacion); }
			set { SetColumnValue(Columns.PlanNacerInternacion, value); }
		}
		  
		[XmlAttribute("AuditIngresoFechaHora")]
		[Bindable(true)]
		public DateTime? AuditIngresoFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.AuditIngresoFechaHora); }
			set { SetColumnValue(Columns.AuditIngresoFechaHora, value); }
		}
		  
		[XmlAttribute("AuditAtencionFechaHora")]
		[Bindable(true)]
		public DateTime? AuditAtencionFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.AuditAtencionFechaHora); }
			set { SetColumnValue(Columns.AuditAtencionFechaHora, value); }
		}
		  
		[XmlAttribute("AuditEgresoFechaHora")]
		[Bindable(true)]
		public DateTime? AuditEgresoFechaHora 
		{
			get { return GetColumnValue<DateTime?>(Columns.AuditEgresoFechaHora); }
			set { SetColumnValue(Columns.AuditEgresoFechaHora, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.GuardiaRegistrosDiagnosticosCie10Collection colGuardiaRegistrosDiagnosticosCie10Records;
		public DalSic.GuardiaRegistrosDiagnosticosCie10Collection GuardiaRegistrosDiagnosticosCie10Records
		{
			get
			{
				if(colGuardiaRegistrosDiagnosticosCie10Records == null)
				{
					colGuardiaRegistrosDiagnosticosCie10Records = new DalSic.GuardiaRegistrosDiagnosticosCie10Collection().Where(GuardiaRegistrosDiagnosticosCie10.Columns.IdRegistroGuardia, Id).Load();
					colGuardiaRegistrosDiagnosticosCie10Records.ListChanged += new ListChangedEventHandler(colGuardiaRegistrosDiagnosticosCie10Records_ListChanged);
				}
				return colGuardiaRegistrosDiagnosticosCie10Records;			
			}
			set 
			{ 
					colGuardiaRegistrosDiagnosticosCie10Records = value; 
					colGuardiaRegistrosDiagnosticosCie10Records.ListChanged += new ListChangedEventHandler(colGuardiaRegistrosDiagnosticosCie10Records_ListChanged);
			}
		}
		
		void colGuardiaRegistrosDiagnosticosCie10Records_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colGuardiaRegistrosDiagnosticosCie10Records[e.NewIndex].IdRegistroGuardia = Id;
		    }
		}
				
		private DalSic.GuardiaRegistrosDiagnosticoCollection colGuardiaRegistrosDiagnosticos;
		public DalSic.GuardiaRegistrosDiagnosticoCollection GuardiaRegistrosDiagnosticos
		{
			get
			{
				if(colGuardiaRegistrosDiagnosticos == null)
				{
					colGuardiaRegistrosDiagnosticos = new DalSic.GuardiaRegistrosDiagnosticoCollection().Where(GuardiaRegistrosDiagnostico.Columns.IdRegistroGuardia, Id).Load();
					colGuardiaRegistrosDiagnosticos.ListChanged += new ListChangedEventHandler(colGuardiaRegistrosDiagnosticos_ListChanged);
				}
				return colGuardiaRegistrosDiagnosticos;			
			}
			set 
			{ 
					colGuardiaRegistrosDiagnosticos = value; 
					colGuardiaRegistrosDiagnosticos.ListChanged += new ListChangedEventHandler(colGuardiaRegistrosDiagnosticos_ListChanged);
			}
		}
		
		void colGuardiaRegistrosDiagnosticos_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colGuardiaRegistrosDiagnosticos[e.NewIndex].IdRegistroGuardia = Id;
		    }
		}
				
		private DalSic.GuardiaTriageCollection colGuardiaTriageRecords;
		public DalSic.GuardiaTriageCollection GuardiaTriageRecords
		{
			get
			{
				if(colGuardiaTriageRecords == null)
				{
					colGuardiaTriageRecords = new DalSic.GuardiaTriageCollection().Where(GuardiaTriage.Columns.RegistroGuardia, Id).Load();
					colGuardiaTriageRecords.ListChanged += new ListChangedEventHandler(colGuardiaTriageRecords_ListChanged);
				}
				return colGuardiaTriageRecords;			
			}
			set 
			{ 
					colGuardiaTriageRecords = value; 
					colGuardiaTriageRecords.ListChanged += new ListChangedEventHandler(colGuardiaTriageRecords_ListChanged);
			}
		}
		
		void colGuardiaTriageRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colGuardiaTriageRecords[e.NewIndex].RegistroGuardia = Id;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a GuardiaTiposIngreso ActiveRecord object related to this GuardiaRegistro
		/// 
		/// </summary>
		public DalSic.GuardiaTiposIngreso GuardiaTiposIngreso
		{
			get { return DalSic.GuardiaTiposIngreso.FetchByID(this.IngresoTipo); }
			set { SetColumnValue("ingreso_tipo", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a GuardiaTiposEgreso ActiveRecord object related to this GuardiaRegistro
		/// 
		/// </summary>
		public DalSic.GuardiaTiposEgreso GuardiaTiposEgreso
		{
			get { return DalSic.GuardiaTiposEgreso.FetchByID(this.EgresoTipo); }
			set { SetColumnValue("egreso_tipo", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a GuardiaRegistrosEstado ActiveRecord object related to this GuardiaRegistro
		/// 
		/// </summary>
		public DalSic.GuardiaRegistrosEstado GuardiaRegistrosEstado
		{
			get { return DalSic.GuardiaRegistrosEstado.FetchByID(this.EstadoActual); }
			set { SetColumnValue("estado_actual", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this GuardiaRegistro
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.Historia); }
			set { SetColumnValue("historia", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this GuardiaRegistro
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.MedicoResponsable); }
			set { SetColumnValue("medicoResponsable", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfector,bool varTipoGuardia,int varHistoria,DateTime? varIngresoFechaHora,int? varIngresoTipo,DateTime? varAtencionFechaHora,DateTime? varEgresoFechaHora,int? varEgresoTipo,int? varEgresoUbicacion,int varClasificacion,string varMedicoCabecera,string varMotivoConsulta,string varDatosEnfermeria,string varInterrogatorio,string varEvolucionEnfermeria,int? varMedicoResponsable,string varEvolucionMedica,string varDiagnosticoPresuntivo,string varDiagnosticoDefinitivo,int? varDiagnosticoDefinitivoCIE10,string varObservaciones,int varEstadoActual,int? varEstadoUbicacion,int? varEstadoTurno,bool? varEstadoTurnoLlamado,DateTime? varTurnoLlamadoFechaHora,bool? varRecuperoFinancieroPrinted,bool? varC2,bool? varPresentaCarnetVacunacion,bool? varVacunacionCompleta,bool? varPlanNacer,bool? varPlanNacerPosta,bool? varPlanNacerInternacion,DateTime? varAuditIngresoFechaHora,DateTime? varAuditAtencionFechaHora,DateTime? varAuditEgresoFechaHora)
		{
			GuardiaRegistro item = new GuardiaRegistro();
			
			item.IdEfector = varIdEfector;
			
			item.TipoGuardia = varTipoGuardia;
			
			item.Historia = varHistoria;
			
			item.IngresoFechaHora = varIngresoFechaHora;
			
			item.IngresoTipo = varIngresoTipo;
			
			item.AtencionFechaHora = varAtencionFechaHora;
			
			item.EgresoFechaHora = varEgresoFechaHora;
			
			item.EgresoTipo = varEgresoTipo;
			
			item.EgresoUbicacion = varEgresoUbicacion;
			
			item.Clasificacion = varClasificacion;
			
			item.MedicoCabecera = varMedicoCabecera;
			
			item.MotivoConsulta = varMotivoConsulta;
			
			item.DatosEnfermeria = varDatosEnfermeria;
			
			item.Interrogatorio = varInterrogatorio;
			
			item.EvolucionEnfermeria = varEvolucionEnfermeria;
			
			item.MedicoResponsable = varMedicoResponsable;
			
			item.EvolucionMedica = varEvolucionMedica;
			
			item.DiagnosticoPresuntivo = varDiagnosticoPresuntivo;
			
			item.DiagnosticoDefinitivo = varDiagnosticoDefinitivo;
			
			item.DiagnosticoDefinitivoCIE10 = varDiagnosticoDefinitivoCIE10;
			
			item.Observaciones = varObservaciones;
			
			item.EstadoActual = varEstadoActual;
			
			item.EstadoUbicacion = varEstadoUbicacion;
			
			item.EstadoTurno = varEstadoTurno;
			
			item.EstadoTurnoLlamado = varEstadoTurnoLlamado;
			
			item.TurnoLlamadoFechaHora = varTurnoLlamadoFechaHora;
			
			item.RecuperoFinancieroPrinted = varRecuperoFinancieroPrinted;
			
			item.C2 = varC2;
			
			item.PresentaCarnetVacunacion = varPresentaCarnetVacunacion;
			
			item.VacunacionCompleta = varVacunacionCompleta;
			
			item.PlanNacer = varPlanNacer;
			
			item.PlanNacerPosta = varPlanNacerPosta;
			
			item.PlanNacerInternacion = varPlanNacerInternacion;
			
			item.AuditIngresoFechaHora = varAuditIngresoFechaHora;
			
			item.AuditAtencionFechaHora = varAuditAtencionFechaHora;
			
			item.AuditEgresoFechaHora = varAuditEgresoFechaHora;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdEfector,bool varTipoGuardia,int varHistoria,DateTime? varIngresoFechaHora,int? varIngresoTipo,DateTime? varAtencionFechaHora,DateTime? varEgresoFechaHora,int? varEgresoTipo,int? varEgresoUbicacion,int varClasificacion,string varMedicoCabecera,string varMotivoConsulta,string varDatosEnfermeria,string varInterrogatorio,string varEvolucionEnfermeria,int? varMedicoResponsable,string varEvolucionMedica,string varDiagnosticoPresuntivo,string varDiagnosticoDefinitivo,int? varDiagnosticoDefinitivoCIE10,string varObservaciones,int varEstadoActual,int? varEstadoUbicacion,int? varEstadoTurno,bool? varEstadoTurnoLlamado,DateTime? varTurnoLlamadoFechaHora,bool? varRecuperoFinancieroPrinted,bool? varC2,bool? varPresentaCarnetVacunacion,bool? varVacunacionCompleta,bool? varPlanNacer,bool? varPlanNacerPosta,bool? varPlanNacerInternacion,DateTime? varAuditIngresoFechaHora,DateTime? varAuditAtencionFechaHora,DateTime? varAuditEgresoFechaHora)
		{
			GuardiaRegistro item = new GuardiaRegistro();
			
				item.Id = varId;
			
				item.IdEfector = varIdEfector;
			
				item.TipoGuardia = varTipoGuardia;
			
				item.Historia = varHistoria;
			
				item.IngresoFechaHora = varIngresoFechaHora;
			
				item.IngresoTipo = varIngresoTipo;
			
				item.AtencionFechaHora = varAtencionFechaHora;
			
				item.EgresoFechaHora = varEgresoFechaHora;
			
				item.EgresoTipo = varEgresoTipo;
			
				item.EgresoUbicacion = varEgresoUbicacion;
			
				item.Clasificacion = varClasificacion;
			
				item.MedicoCabecera = varMedicoCabecera;
			
				item.MotivoConsulta = varMotivoConsulta;
			
				item.DatosEnfermeria = varDatosEnfermeria;
			
				item.Interrogatorio = varInterrogatorio;
			
				item.EvolucionEnfermeria = varEvolucionEnfermeria;
			
				item.MedicoResponsable = varMedicoResponsable;
			
				item.EvolucionMedica = varEvolucionMedica;
			
				item.DiagnosticoPresuntivo = varDiagnosticoPresuntivo;
			
				item.DiagnosticoDefinitivo = varDiagnosticoDefinitivo;
			
				item.DiagnosticoDefinitivoCIE10 = varDiagnosticoDefinitivoCIE10;
			
				item.Observaciones = varObservaciones;
			
				item.EstadoActual = varEstadoActual;
			
				item.EstadoUbicacion = varEstadoUbicacion;
			
				item.EstadoTurno = varEstadoTurno;
			
				item.EstadoTurnoLlamado = varEstadoTurnoLlamado;
			
				item.TurnoLlamadoFechaHora = varTurnoLlamadoFechaHora;
			
				item.RecuperoFinancieroPrinted = varRecuperoFinancieroPrinted;
			
				item.C2 = varC2;
			
				item.PresentaCarnetVacunacion = varPresentaCarnetVacunacion;
			
				item.VacunacionCompleta = varVacunacionCompleta;
			
				item.PlanNacer = varPlanNacer;
			
				item.PlanNacerPosta = varPlanNacerPosta;
			
				item.PlanNacerInternacion = varPlanNacerInternacion;
			
				item.AuditIngresoFechaHora = varAuditIngresoFechaHora;
			
				item.AuditAtencionFechaHora = varAuditAtencionFechaHora;
			
				item.AuditEgresoFechaHora = varAuditEgresoFechaHora;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoGuardiaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HistoriaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoFechaHoraColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoTipoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AtencionFechaHoraColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoFechaHoraColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoTipoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoUbicacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ClasificacionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoCabeceraColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoConsultaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn DatosEnfermeriaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn InterrogatorioColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn EvolucionEnfermeriaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoResponsableColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EvolucionMedicaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoPresuntivoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoDefinitivoColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoDefinitivoCIE10Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoActualColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoUbicacionColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoTurnoColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoTurnoLlamadoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn TurnoLlamadoFechaHoraColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn RecuperoFinancieroPrintedColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn C2Column
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn PresentaCarnetVacunacionColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunacionCompletaColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn PlanNacerColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn PlanNacerPostaColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn PlanNacerInternacionColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditIngresoFechaHoraColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditAtencionFechaHoraColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditEgresoFechaHoraColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdEfector = @"idEfector";
			 public static string TipoGuardia = @"tipo_guardia";
			 public static string Historia = @"historia";
			 public static string IngresoFechaHora = @"ingreso_fechaHora";
			 public static string IngresoTipo = @"ingreso_tipo";
			 public static string AtencionFechaHora = @"atencion_fechaHora";
			 public static string EgresoFechaHora = @"egreso_fechaHora";
			 public static string EgresoTipo = @"egreso_tipo";
			 public static string EgresoUbicacion = @"egreso_ubicacion";
			 public static string Clasificacion = @"clasificacion";
			 public static string MedicoCabecera = @"medicoCabecera";
			 public static string MotivoConsulta = @"motivoConsulta";
			 public static string DatosEnfermeria = @"datosEnfermeria";
			 public static string Interrogatorio = @"interrogatorio";
			 public static string EvolucionEnfermeria = @"evolucionEnfermeria";
			 public static string MedicoResponsable = @"medicoResponsable";
			 public static string EvolucionMedica = @"evolucionMedica";
			 public static string DiagnosticoPresuntivo = @"diagnosticoPresuntivo";
			 public static string DiagnosticoDefinitivo = @"diagnosticoDefinitivo";
			 public static string DiagnosticoDefinitivoCIE10 = @"diagnosticoDefinitivo_CIE10";
			 public static string Observaciones = @"observaciones";
			 public static string EstadoActual = @"estado_actual";
			 public static string EstadoUbicacion = @"estado_ubicacion";
			 public static string EstadoTurno = @"estado_turno";
			 public static string EstadoTurnoLlamado = @"estado_turnoLlamado";
			 public static string TurnoLlamadoFechaHora = @"turnoLlamado_fechaHora";
			 public static string RecuperoFinancieroPrinted = @"recuperoFinancieroPrinted";
			 public static string C2 = @"c2";
			 public static string PresentaCarnetVacunacion = @"presentaCarnetVacunacion";
			 public static string VacunacionCompleta = @"vacunacionCompleta";
			 public static string PlanNacer = @"planNacer";
			 public static string PlanNacerPosta = @"planNacerPosta";
			 public static string PlanNacerInternacion = @"planNacerInternacion";
			 public static string AuditIngresoFechaHora = @"audit_ingreso_fechaHora";
			 public static string AuditAtencionFechaHora = @"audit_atencion_fechaHora";
			 public static string AuditEgresoFechaHora = @"audit_egreso_fechaHora";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colGuardiaRegistrosDiagnosticosCie10Records != null)
                {
                    foreach (DalSic.GuardiaRegistrosDiagnosticosCie10 item in colGuardiaRegistrosDiagnosticosCie10Records)
                    {
                        if (item.IdRegistroGuardia != Id)
                        {
                            item.IdRegistroGuardia = Id;
                        }
                    }
               }
		
                if (colGuardiaRegistrosDiagnosticos != null)
                {
                    foreach (DalSic.GuardiaRegistrosDiagnostico item in colGuardiaRegistrosDiagnosticos)
                    {
                        if (item.IdRegistroGuardia != Id)
                        {
                            item.IdRegistroGuardia = Id;
                        }
                    }
               }
		
                if (colGuardiaTriageRecords != null)
                {
                    foreach (DalSic.GuardiaTriage item in colGuardiaTriageRecords)
                    {
                        if (item.RegistroGuardia != Id)
                        {
                            item.RegistroGuardia = Id;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colGuardiaRegistrosDiagnosticosCie10Records != null)
                {
                    colGuardiaRegistrosDiagnosticosCie10Records.SaveAll();
               }
		
                if (colGuardiaRegistrosDiagnosticos != null)
                {
                    colGuardiaRegistrosDiagnosticos.SaveAll();
               }
		
                if (colGuardiaTriageRecords != null)
                {
                    colGuardiaTriageRecords.SaveAll();
               }
		}
        #endregion
	}
}
