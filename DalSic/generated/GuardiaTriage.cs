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
	/// Strongly-typed collection for the GuardiaTriage class.
	/// </summary>
    [Serializable]
	public partial class GuardiaTriageCollection : ActiveList<GuardiaTriage, GuardiaTriageCollection>
	{	   
		public GuardiaTriageCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaTriageCollection</returns>
		public GuardiaTriageCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaTriage o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Triage table.
	/// </summary>
	[Serializable]
	public partial class GuardiaTriage : ActiveRecord<GuardiaTriage>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaTriage()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaTriage(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaTriage(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaTriage(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Triage", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarRegistroGuardia = new TableSchema.TableColumn(schema);
				colvarRegistroGuardia.ColumnName = "registroGuardia";
				colvarRegistroGuardia.DataType = DbType.Int32;
				colvarRegistroGuardia.MaxLength = 0;
				colvarRegistroGuardia.AutoIncrement = false;
				colvarRegistroGuardia.IsNullable = false;
				colvarRegistroGuardia.IsPrimaryKey = false;
				colvarRegistroGuardia.IsForeignKey = true;
				colvarRegistroGuardia.IsReadOnly = false;
				colvarRegistroGuardia.DefaultSetting = @"";
				
					colvarRegistroGuardia.ForeignKeyTableName = "Guardia_Registros";
				schema.Columns.Add(colvarRegistroGuardia);
				
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
				
				TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
				colvarFechaHora.ColumnName = "fechaHora";
				colvarFechaHora.DataType = DbType.DateTime;
				colvarFechaHora.MaxLength = 0;
				colvarFechaHora.AutoIncrement = false;
				colvarFechaHora.IsNullable = false;
				colvarFechaHora.IsPrimaryKey = false;
				colvarFechaHora.IsForeignKey = false;
				colvarFechaHora.IsReadOnly = false;
				colvarFechaHora.DefaultSetting = @"";
				colvarFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHora);
				
				TableSchema.TableColumn colvarTensionArterial = new TableSchema.TableColumn(schema);
				colvarTensionArterial.ColumnName = "tensionArterial";
				colvarTensionArterial.DataType = DbType.AnsiString;
				colvarTensionArterial.MaxLength = 50;
				colvarTensionArterial.AutoIncrement = false;
				colvarTensionArterial.IsNullable = true;
				colvarTensionArterial.IsPrimaryKey = false;
				colvarTensionArterial.IsForeignKey = false;
				colvarTensionArterial.IsReadOnly = false;
				colvarTensionArterial.DefaultSetting = @"";
				colvarTensionArterial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTensionArterial);
				
				TableSchema.TableColumn colvarFrecuenciaCardiaca = new TableSchema.TableColumn(schema);
				colvarFrecuenciaCardiaca.ColumnName = "frecuenciaCardiaca";
				colvarFrecuenciaCardiaca.DataType = DbType.Int32;
				colvarFrecuenciaCardiaca.MaxLength = 0;
				colvarFrecuenciaCardiaca.AutoIncrement = false;
				colvarFrecuenciaCardiaca.IsNullable = true;
				colvarFrecuenciaCardiaca.IsPrimaryKey = false;
				colvarFrecuenciaCardiaca.IsForeignKey = false;
				colvarFrecuenciaCardiaca.IsReadOnly = false;
				colvarFrecuenciaCardiaca.DefaultSetting = @"";
				colvarFrecuenciaCardiaca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFrecuenciaCardiaca);
				
				TableSchema.TableColumn colvarFrecuenciaRespiratoria = new TableSchema.TableColumn(schema);
				colvarFrecuenciaRespiratoria.ColumnName = "frecuenciaRespiratoria";
				colvarFrecuenciaRespiratoria.DataType = DbType.Int32;
				colvarFrecuenciaRespiratoria.MaxLength = 0;
				colvarFrecuenciaRespiratoria.AutoIncrement = false;
				colvarFrecuenciaRespiratoria.IsNullable = true;
				colvarFrecuenciaRespiratoria.IsPrimaryKey = false;
				colvarFrecuenciaRespiratoria.IsForeignKey = false;
				colvarFrecuenciaRespiratoria.IsReadOnly = false;
				colvarFrecuenciaRespiratoria.DefaultSetting = @"";
				colvarFrecuenciaRespiratoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFrecuenciaRespiratoria);
				
				TableSchema.TableColumn colvarTemperatura = new TableSchema.TableColumn(schema);
				colvarTemperatura.ColumnName = "temperatura";
				colvarTemperatura.DataType = DbType.Double;
				colvarTemperatura.MaxLength = 0;
				colvarTemperatura.AutoIncrement = false;
				colvarTemperatura.IsNullable = true;
				colvarTemperatura.IsPrimaryKey = false;
				colvarTemperatura.IsForeignKey = false;
				colvarTemperatura.IsReadOnly = false;
				colvarTemperatura.DefaultSetting = @"";
				colvarTemperatura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTemperatura);
				
				TableSchema.TableColumn colvarSaturacionOxigeno = new TableSchema.TableColumn(schema);
				colvarSaturacionOxigeno.ColumnName = "saturacionOxigeno";
				colvarSaturacionOxigeno.DataType = DbType.Int32;
				colvarSaturacionOxigeno.MaxLength = 0;
				colvarSaturacionOxigeno.AutoIncrement = false;
				colvarSaturacionOxigeno.IsNullable = true;
				colvarSaturacionOxigeno.IsPrimaryKey = false;
				colvarSaturacionOxigeno.IsForeignKey = false;
				colvarSaturacionOxigeno.IsReadOnly = false;
				colvarSaturacionOxigeno.DefaultSetting = @"";
				colvarSaturacionOxigeno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSaturacionOxigeno);
				
				TableSchema.TableColumn colvarGlasgowOcular = new TableSchema.TableColumn(schema);
				colvarGlasgowOcular.ColumnName = "glasgow_ocular";
				colvarGlasgowOcular.DataType = DbType.Int32;
				colvarGlasgowOcular.MaxLength = 0;
				colvarGlasgowOcular.AutoIncrement = false;
				colvarGlasgowOcular.IsNullable = true;
				colvarGlasgowOcular.IsPrimaryKey = false;
				colvarGlasgowOcular.IsForeignKey = false;
				colvarGlasgowOcular.IsReadOnly = false;
				colvarGlasgowOcular.DefaultSetting = @"";
				colvarGlasgowOcular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlasgowOcular);
				
				TableSchema.TableColumn colvarGlasgowVerbal = new TableSchema.TableColumn(schema);
				colvarGlasgowVerbal.ColumnName = "glasgow_verbal";
				colvarGlasgowVerbal.DataType = DbType.Int32;
				colvarGlasgowVerbal.MaxLength = 0;
				colvarGlasgowVerbal.AutoIncrement = false;
				colvarGlasgowVerbal.IsNullable = true;
				colvarGlasgowVerbal.IsPrimaryKey = false;
				colvarGlasgowVerbal.IsForeignKey = false;
				colvarGlasgowVerbal.IsReadOnly = false;
				colvarGlasgowVerbal.DefaultSetting = @"";
				colvarGlasgowVerbal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlasgowVerbal);
				
				TableSchema.TableColumn colvarGlasgowMotor = new TableSchema.TableColumn(schema);
				colvarGlasgowMotor.ColumnName = "glasgow_motor";
				colvarGlasgowMotor.DataType = DbType.Int32;
				colvarGlasgowMotor.MaxLength = 0;
				colvarGlasgowMotor.AutoIncrement = false;
				colvarGlasgowMotor.IsNullable = true;
				colvarGlasgowMotor.IsPrimaryKey = false;
				colvarGlasgowMotor.IsForeignKey = false;
				colvarGlasgowMotor.IsReadOnly = false;
				colvarGlasgowMotor.DefaultSetting = @"";
				colvarGlasgowMotor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlasgowMotor);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Double;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarPupilasTamano = new TableSchema.TableColumn(schema);
				colvarPupilasTamano.ColumnName = "pupilas_tamano";
				colvarPupilasTamano.DataType = DbType.AnsiString;
				colvarPupilasTamano.MaxLength = 50;
				colvarPupilasTamano.AutoIncrement = false;
				colvarPupilasTamano.IsNullable = true;
				colvarPupilasTamano.IsPrimaryKey = false;
				colvarPupilasTamano.IsForeignKey = false;
				colvarPupilasTamano.IsReadOnly = false;
				colvarPupilasTamano.DefaultSetting = @"";
				colvarPupilasTamano.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPupilasTamano);
				
				TableSchema.TableColumn colvarPupilasReactividad = new TableSchema.TableColumn(schema);
				colvarPupilasReactividad.ColumnName = "pupilas_reactividad";
				colvarPupilasReactividad.DataType = DbType.AnsiString;
				colvarPupilasReactividad.MaxLength = 50;
				colvarPupilasReactividad.AutoIncrement = false;
				colvarPupilasReactividad.IsNullable = true;
				colvarPupilasReactividad.IsPrimaryKey = false;
				colvarPupilasReactividad.IsForeignKey = false;
				colvarPupilasReactividad.IsReadOnly = false;
				colvarPupilasReactividad.DefaultSetting = @"";
				colvarPupilasReactividad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPupilasReactividad);
				
				TableSchema.TableColumn colvarPupilasSimetria = new TableSchema.TableColumn(schema);
				colvarPupilasSimetria.ColumnName = "pupilas_simetria";
				colvarPupilasSimetria.DataType = DbType.AnsiString;
				colvarPupilasSimetria.MaxLength = 50;
				colvarPupilasSimetria.AutoIncrement = false;
				colvarPupilasSimetria.IsNullable = true;
				colvarPupilasSimetria.IsPrimaryKey = false;
				colvarPupilasSimetria.IsForeignKey = false;
				colvarPupilasSimetria.IsReadOnly = false;
				colvarPupilasSimetria.DefaultSetting = @"";
				colvarPupilasSimetria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPupilasSimetria);
				
				TableSchema.TableColumn colvarSensorio = new TableSchema.TableColumn(schema);
				colvarSensorio.ColumnName = "sensorio";
				colvarSensorio.DataType = DbType.AnsiString;
				colvarSensorio.MaxLength = 50;
				colvarSensorio.AutoIncrement = false;
				colvarSensorio.IsNullable = true;
				colvarSensorio.IsPrimaryKey = false;
				colvarSensorio.IsForeignKey = false;
				colvarSensorio.IsReadOnly = false;
				colvarSensorio.DefaultSetting = @"";
				colvarSensorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSensorio);
				
				TableSchema.TableColumn colvarSibilancia = new TableSchema.TableColumn(schema);
				colvarSibilancia.ColumnName = "sibilancia";
				colvarSibilancia.DataType = DbType.AnsiString;
				colvarSibilancia.MaxLength = 50;
				colvarSibilancia.AutoIncrement = false;
				colvarSibilancia.IsNullable = true;
				colvarSibilancia.IsPrimaryKey = false;
				colvarSibilancia.IsForeignKey = false;
				colvarSibilancia.IsReadOnly = false;
				colvarSibilancia.DefaultSetting = @"";
				colvarSibilancia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSibilancia);
				
				TableSchema.TableColumn colvarMuscAccesorio = new TableSchema.TableColumn(schema);
				colvarMuscAccesorio.ColumnName = "muscAccesorio";
				colvarMuscAccesorio.DataType = DbType.AnsiString;
				colvarMuscAccesorio.MaxLength = 50;
				colvarMuscAccesorio.AutoIncrement = false;
				colvarMuscAccesorio.IsNullable = true;
				colvarMuscAccesorio.IsPrimaryKey = false;
				colvarMuscAccesorio.IsForeignKey = false;
				colvarMuscAccesorio.IsReadOnly = false;
				colvarMuscAccesorio.DefaultSetting = @"";
				colvarMuscAccesorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMuscAccesorio);
				
				TableSchema.TableColumn colvarIngresoAlimentacionCant = new TableSchema.TableColumn(schema);
				colvarIngresoAlimentacionCant.ColumnName = "ingresoAlimentacionCant";
				colvarIngresoAlimentacionCant.DataType = DbType.AnsiString;
				colvarIngresoAlimentacionCant.MaxLength = 50;
				colvarIngresoAlimentacionCant.AutoIncrement = false;
				colvarIngresoAlimentacionCant.IsNullable = true;
				colvarIngresoAlimentacionCant.IsPrimaryKey = false;
				colvarIngresoAlimentacionCant.IsForeignKey = false;
				colvarIngresoAlimentacionCant.IsReadOnly = false;
				colvarIngresoAlimentacionCant.DefaultSetting = @"";
				colvarIngresoAlimentacionCant.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngresoAlimentacionCant);
				
				TableSchema.TableColumn colvarIngresoAlimentacionTipo = new TableSchema.TableColumn(schema);
				colvarIngresoAlimentacionTipo.ColumnName = "ingresoAlimentacionTipo";
				colvarIngresoAlimentacionTipo.DataType = DbType.AnsiString;
				colvarIngresoAlimentacionTipo.MaxLength = 50;
				colvarIngresoAlimentacionTipo.AutoIncrement = false;
				colvarIngresoAlimentacionTipo.IsNullable = true;
				colvarIngresoAlimentacionTipo.IsPrimaryKey = false;
				colvarIngresoAlimentacionTipo.IsForeignKey = false;
				colvarIngresoAlimentacionTipo.IsReadOnly = false;
				colvarIngresoAlimentacionTipo.DefaultSetting = @"";
				colvarIngresoAlimentacionTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngresoAlimentacionTipo);
				
				TableSchema.TableColumn colvarIngresoSolucion = new TableSchema.TableColumn(schema);
				colvarIngresoSolucion.ColumnName = "ingresoSolucion";
				colvarIngresoSolucion.DataType = DbType.AnsiString;
				colvarIngresoSolucion.MaxLength = 50;
				colvarIngresoSolucion.AutoIncrement = false;
				colvarIngresoSolucion.IsNullable = true;
				colvarIngresoSolucion.IsPrimaryKey = false;
				colvarIngresoSolucion.IsForeignKey = false;
				colvarIngresoSolucion.IsReadOnly = false;
				colvarIngresoSolucion.DefaultSetting = @"";
				colvarIngresoSolucion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngresoSolucion);
				
				TableSchema.TableColumn colvarIngresoOtros = new TableSchema.TableColumn(schema);
				colvarIngresoOtros.ColumnName = "ingresoOtros";
				colvarIngresoOtros.DataType = DbType.AnsiString;
				colvarIngresoOtros.MaxLength = 300;
				colvarIngresoOtros.AutoIncrement = false;
				colvarIngresoOtros.IsNullable = true;
				colvarIngresoOtros.IsPrimaryKey = false;
				colvarIngresoOtros.IsForeignKey = false;
				colvarIngresoOtros.IsReadOnly = false;
				colvarIngresoOtros.DefaultSetting = @"";
				colvarIngresoOtros.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngresoOtros);
				
				TableSchema.TableColumn colvarEgresoDepos = new TableSchema.TableColumn(schema);
				colvarEgresoDepos.ColumnName = "egresoDepos";
				colvarEgresoDepos.DataType = DbType.AnsiString;
				colvarEgresoDepos.MaxLength = 50;
				colvarEgresoDepos.AutoIncrement = false;
				colvarEgresoDepos.IsNullable = true;
				colvarEgresoDepos.IsPrimaryKey = false;
				colvarEgresoDepos.IsForeignKey = false;
				colvarEgresoDepos.IsReadOnly = false;
				colvarEgresoDepos.DefaultSetting = @"";
				colvarEgresoDepos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoDepos);
				
				TableSchema.TableColumn colvarEgresoOrina = new TableSchema.TableColumn(schema);
				colvarEgresoOrina.ColumnName = "egresoOrina";
				colvarEgresoOrina.DataType = DbType.AnsiString;
				colvarEgresoOrina.MaxLength = 50;
				colvarEgresoOrina.AutoIncrement = false;
				colvarEgresoOrina.IsNullable = true;
				colvarEgresoOrina.IsPrimaryKey = false;
				colvarEgresoOrina.IsForeignKey = false;
				colvarEgresoOrina.IsReadOnly = false;
				colvarEgresoOrina.DefaultSetting = @"";
				colvarEgresoOrina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoOrina);
				
				TableSchema.TableColumn colvarEgresoVomito = new TableSchema.TableColumn(schema);
				colvarEgresoVomito.ColumnName = "egresoVomito";
				colvarEgresoVomito.DataType = DbType.AnsiString;
				colvarEgresoVomito.MaxLength = 50;
				colvarEgresoVomito.AutoIncrement = false;
				colvarEgresoVomito.IsNullable = true;
				colvarEgresoVomito.IsPrimaryKey = false;
				colvarEgresoVomito.IsForeignKey = false;
				colvarEgresoVomito.IsReadOnly = false;
				colvarEgresoVomito.DefaultSetting = @"";
				colvarEgresoVomito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoVomito);
				
				TableSchema.TableColumn colvarEgresoSng = new TableSchema.TableColumn(schema);
				colvarEgresoSng.ColumnName = "egresoSng";
				colvarEgresoSng.DataType = DbType.AnsiString;
				colvarEgresoSng.MaxLength = 50;
				colvarEgresoSng.AutoIncrement = false;
				colvarEgresoSng.IsNullable = true;
				colvarEgresoSng.IsPrimaryKey = false;
				colvarEgresoSng.IsForeignKey = false;
				colvarEgresoSng.IsReadOnly = false;
				colvarEgresoSng.DefaultSetting = @"";
				colvarEgresoSng.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoSng);
				
				TableSchema.TableColumn colvarEgresoOtros = new TableSchema.TableColumn(schema);
				colvarEgresoOtros.ColumnName = "egresoOtros";
				colvarEgresoOtros.DataType = DbType.AnsiString;
				colvarEgresoOtros.MaxLength = 300;
				colvarEgresoOtros.AutoIncrement = false;
				colvarEgresoOtros.IsNullable = true;
				colvarEgresoOtros.IsPrimaryKey = false;
				colvarEgresoOtros.IsForeignKey = false;
				colvarEgresoOtros.IsReadOnly = false;
				colvarEgresoOtros.DefaultSetting = @"";
				colvarEgresoOtros.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEgresoOtros);
				
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
				
				TableSchema.TableColumn colvarAuditUser = new TableSchema.TableColumn(schema);
				colvarAuditUser.ColumnName = "audit_user";
				colvarAuditUser.DataType = DbType.Int32;
				colvarAuditUser.MaxLength = 0;
				colvarAuditUser.AutoIncrement = false;
				colvarAuditUser.IsNullable = true;
				colvarAuditUser.IsPrimaryKey = false;
				colvarAuditUser.IsForeignKey = false;
				colvarAuditUser.IsReadOnly = false;
				colvarAuditUser.DefaultSetting = @"";
				colvarAuditUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuditUser);
				
				TableSchema.TableColumn colvarEscalaDelDolor = new TableSchema.TableColumn(schema);
				colvarEscalaDelDolor.ColumnName = "escalaDelDolor";
				colvarEscalaDelDolor.DataType = DbType.Int32;
				colvarEscalaDelDolor.MaxLength = 0;
				colvarEscalaDelDolor.AutoIncrement = false;
				colvarEscalaDelDolor.IsNullable = true;
				colvarEscalaDelDolor.IsPrimaryKey = false;
				colvarEscalaDelDolor.IsForeignKey = false;
				colvarEscalaDelDolor.IsReadOnly = false;
				colvarEscalaDelDolor.DefaultSetting = @"";
				colvarEscalaDelDolor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEscalaDelDolor);
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "idClasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = false;
				colvarIdClasificacion.IsNullable = true;
				colvarIdClasificacion.IsPrimaryKey = false;
				colvarIdClasificacion.IsForeignKey = false;
				colvarIdClasificacion.IsReadOnly = false;
				colvarIdClasificacion.DefaultSetting = @"";
				colvarIdClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdClasificacion);
				
				TableSchema.TableColumn colvarTriage = new TableSchema.TableColumn(schema);
				colvarTriage.ColumnName = "triage";
				colvarTriage.DataType = DbType.Boolean;
				colvarTriage.MaxLength = 0;
				colvarTriage.AutoIncrement = false;
				colvarTriage.IsNullable = true;
				colvarTriage.IsPrimaryKey = false;
				colvarTriage.IsForeignKey = false;
				colvarTriage.IsReadOnly = false;
				
						colvarTriage.DefaultSetting = @"((0))";
				colvarTriage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTriage);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Triage",schema);
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
		  
		[XmlAttribute("RegistroGuardia")]
		[Bindable(true)]
		public int RegistroGuardia 
		{
			get { return GetColumnValue<int>(Columns.RegistroGuardia); }
			set { SetColumnValue(Columns.RegistroGuardia, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("FechaHora")]
		[Bindable(true)]
		public DateTime FechaHora 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHora); }
			set { SetColumnValue(Columns.FechaHora, value); }
		}
		  
		[XmlAttribute("TensionArterial")]
		[Bindable(true)]
		public string TensionArterial 
		{
			get { return GetColumnValue<string>(Columns.TensionArterial); }
			set { SetColumnValue(Columns.TensionArterial, value); }
		}
		  
		[XmlAttribute("FrecuenciaCardiaca")]
		[Bindable(true)]
		public int? FrecuenciaCardiaca 
		{
			get { return GetColumnValue<int?>(Columns.FrecuenciaCardiaca); }
			set { SetColumnValue(Columns.FrecuenciaCardiaca, value); }
		}
		  
		[XmlAttribute("FrecuenciaRespiratoria")]
		[Bindable(true)]
		public int? FrecuenciaRespiratoria 
		{
			get { return GetColumnValue<int?>(Columns.FrecuenciaRespiratoria); }
			set { SetColumnValue(Columns.FrecuenciaRespiratoria, value); }
		}
		  
		[XmlAttribute("Temperatura")]
		[Bindable(true)]
		public double? Temperatura 
		{
			get { return GetColumnValue<double?>(Columns.Temperatura); }
			set { SetColumnValue(Columns.Temperatura, value); }
		}
		  
		[XmlAttribute("SaturacionOxigeno")]
		[Bindable(true)]
		public int? SaturacionOxigeno 
		{
			get { return GetColumnValue<int?>(Columns.SaturacionOxigeno); }
			set { SetColumnValue(Columns.SaturacionOxigeno, value); }
		}
		  
		[XmlAttribute("GlasgowOcular")]
		[Bindable(true)]
		public int? GlasgowOcular 
		{
			get { return GetColumnValue<int?>(Columns.GlasgowOcular); }
			set { SetColumnValue(Columns.GlasgowOcular, value); }
		}
		  
		[XmlAttribute("GlasgowVerbal")]
		[Bindable(true)]
		public int? GlasgowVerbal 
		{
			get { return GetColumnValue<int?>(Columns.GlasgowVerbal); }
			set { SetColumnValue(Columns.GlasgowVerbal, value); }
		}
		  
		[XmlAttribute("GlasgowMotor")]
		[Bindable(true)]
		public int? GlasgowMotor 
		{
			get { return GetColumnValue<int?>(Columns.GlasgowMotor); }
			set { SetColumnValue(Columns.GlasgowMotor, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public double? Peso 
		{
			get { return GetColumnValue<double?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("PupilasTamano")]
		[Bindable(true)]
		public string PupilasTamano 
		{
			get { return GetColumnValue<string>(Columns.PupilasTamano); }
			set { SetColumnValue(Columns.PupilasTamano, value); }
		}
		  
		[XmlAttribute("PupilasReactividad")]
		[Bindable(true)]
		public string PupilasReactividad 
		{
			get { return GetColumnValue<string>(Columns.PupilasReactividad); }
			set { SetColumnValue(Columns.PupilasReactividad, value); }
		}
		  
		[XmlAttribute("PupilasSimetria")]
		[Bindable(true)]
		public string PupilasSimetria 
		{
			get { return GetColumnValue<string>(Columns.PupilasSimetria); }
			set { SetColumnValue(Columns.PupilasSimetria, value); }
		}
		  
		[XmlAttribute("Sensorio")]
		[Bindable(true)]
		public string Sensorio 
		{
			get { return GetColumnValue<string>(Columns.Sensorio); }
			set { SetColumnValue(Columns.Sensorio, value); }
		}
		  
		[XmlAttribute("Sibilancia")]
		[Bindable(true)]
		public string Sibilancia 
		{
			get { return GetColumnValue<string>(Columns.Sibilancia); }
			set { SetColumnValue(Columns.Sibilancia, value); }
		}
		  
		[XmlAttribute("MuscAccesorio")]
		[Bindable(true)]
		public string MuscAccesorio 
		{
			get { return GetColumnValue<string>(Columns.MuscAccesorio); }
			set { SetColumnValue(Columns.MuscAccesorio, value); }
		}
		  
		[XmlAttribute("IngresoAlimentacionCant")]
		[Bindable(true)]
		public string IngresoAlimentacionCant 
		{
			get { return GetColumnValue<string>(Columns.IngresoAlimentacionCant); }
			set { SetColumnValue(Columns.IngresoAlimentacionCant, value); }
		}
		  
		[XmlAttribute("IngresoAlimentacionTipo")]
		[Bindable(true)]
		public string IngresoAlimentacionTipo 
		{
			get { return GetColumnValue<string>(Columns.IngresoAlimentacionTipo); }
			set { SetColumnValue(Columns.IngresoAlimentacionTipo, value); }
		}
		  
		[XmlAttribute("IngresoSolucion")]
		[Bindable(true)]
		public string IngresoSolucion 
		{
			get { return GetColumnValue<string>(Columns.IngresoSolucion); }
			set { SetColumnValue(Columns.IngresoSolucion, value); }
		}
		  
		[XmlAttribute("IngresoOtros")]
		[Bindable(true)]
		public string IngresoOtros 
		{
			get { return GetColumnValue<string>(Columns.IngresoOtros); }
			set { SetColumnValue(Columns.IngresoOtros, value); }
		}
		  
		[XmlAttribute("EgresoDepos")]
		[Bindable(true)]
		public string EgresoDepos 
		{
			get { return GetColumnValue<string>(Columns.EgresoDepos); }
			set { SetColumnValue(Columns.EgresoDepos, value); }
		}
		  
		[XmlAttribute("EgresoOrina")]
		[Bindable(true)]
		public string EgresoOrina 
		{
			get { return GetColumnValue<string>(Columns.EgresoOrina); }
			set { SetColumnValue(Columns.EgresoOrina, value); }
		}
		  
		[XmlAttribute("EgresoVomito")]
		[Bindable(true)]
		public string EgresoVomito 
		{
			get { return GetColumnValue<string>(Columns.EgresoVomito); }
			set { SetColumnValue(Columns.EgresoVomito, value); }
		}
		  
		[XmlAttribute("EgresoSng")]
		[Bindable(true)]
		public string EgresoSng 
		{
			get { return GetColumnValue<string>(Columns.EgresoSng); }
			set { SetColumnValue(Columns.EgresoSng, value); }
		}
		  
		[XmlAttribute("EgresoOtros")]
		[Bindable(true)]
		public string EgresoOtros 
		{
			get { return GetColumnValue<string>(Columns.EgresoOtros); }
			set { SetColumnValue(Columns.EgresoOtros, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("AuditUser")]
		[Bindable(true)]
		public int? AuditUser 
		{
			get { return GetColumnValue<int?>(Columns.AuditUser); }
			set { SetColumnValue(Columns.AuditUser, value); }
		}
		  
		[XmlAttribute("EscalaDelDolor")]
		[Bindable(true)]
		public int? EscalaDelDolor 
		{
			get { return GetColumnValue<int?>(Columns.EscalaDelDolor); }
			set { SetColumnValue(Columns.EscalaDelDolor, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int? IdClasificacion 
		{
			get { return GetColumnValue<int?>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		  
		[XmlAttribute("Triage")]
		[Bindable(true)]
		public bool? Triage 
		{
			get { return GetColumnValue<bool?>(Columns.Triage); }
			set { SetColumnValue(Columns.Triage, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a GuardiaRegistro ActiveRecord object related to this GuardiaTriage
		/// 
		/// </summary>
		public DalSic.GuardiaRegistro GuardiaRegistro
		{
			get { return DalSic.GuardiaRegistro.FetchByID(this.RegistroGuardia); }
			set { SetColumnValue("registroGuardia", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegistroGuardia,int? varIdEfector,DateTime varFechaHora,string varTensionArterial,int? varFrecuenciaCardiaca,int? varFrecuenciaRespiratoria,double? varTemperatura,int? varSaturacionOxigeno,int? varGlasgowOcular,int? varGlasgowVerbal,int? varGlasgowMotor,double? varPeso,string varPupilasTamano,string varPupilasReactividad,string varPupilasSimetria,string varSensorio,string varSibilancia,string varMuscAccesorio,string varIngresoAlimentacionCant,string varIngresoAlimentacionTipo,string varIngresoSolucion,string varIngresoOtros,string varEgresoDepos,string varEgresoOrina,string varEgresoVomito,string varEgresoSng,string varEgresoOtros,string varObservaciones,int? varAuditUser,int? varEscalaDelDolor,int? varIdClasificacion,bool? varTriage)
		{
			GuardiaTriage item = new GuardiaTriage();
			
			item.RegistroGuardia = varRegistroGuardia;
			
			item.IdEfector = varIdEfector;
			
			item.FechaHora = varFechaHora;
			
			item.TensionArterial = varTensionArterial;
			
			item.FrecuenciaCardiaca = varFrecuenciaCardiaca;
			
			item.FrecuenciaRespiratoria = varFrecuenciaRespiratoria;
			
			item.Temperatura = varTemperatura;
			
			item.SaturacionOxigeno = varSaturacionOxigeno;
			
			item.GlasgowOcular = varGlasgowOcular;
			
			item.GlasgowVerbal = varGlasgowVerbal;
			
			item.GlasgowMotor = varGlasgowMotor;
			
			item.Peso = varPeso;
			
			item.PupilasTamano = varPupilasTamano;
			
			item.PupilasReactividad = varPupilasReactividad;
			
			item.PupilasSimetria = varPupilasSimetria;
			
			item.Sensorio = varSensorio;
			
			item.Sibilancia = varSibilancia;
			
			item.MuscAccesorio = varMuscAccesorio;
			
			item.IngresoAlimentacionCant = varIngresoAlimentacionCant;
			
			item.IngresoAlimentacionTipo = varIngresoAlimentacionTipo;
			
			item.IngresoSolucion = varIngresoSolucion;
			
			item.IngresoOtros = varIngresoOtros;
			
			item.EgresoDepos = varEgresoDepos;
			
			item.EgresoOrina = varEgresoOrina;
			
			item.EgresoVomito = varEgresoVomito;
			
			item.EgresoSng = varEgresoSng;
			
			item.EgresoOtros = varEgresoOtros;
			
			item.Observaciones = varObservaciones;
			
			item.AuditUser = varAuditUser;
			
			item.EscalaDelDolor = varEscalaDelDolor;
			
			item.IdClasificacion = varIdClasificacion;
			
			item.Triage = varTriage;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varRegistroGuardia,int? varIdEfector,DateTime varFechaHora,string varTensionArterial,int? varFrecuenciaCardiaca,int? varFrecuenciaRespiratoria,double? varTemperatura,int? varSaturacionOxigeno,int? varGlasgowOcular,int? varGlasgowVerbal,int? varGlasgowMotor,double? varPeso,string varPupilasTamano,string varPupilasReactividad,string varPupilasSimetria,string varSensorio,string varSibilancia,string varMuscAccesorio,string varIngresoAlimentacionCant,string varIngresoAlimentacionTipo,string varIngresoSolucion,string varIngresoOtros,string varEgresoDepos,string varEgresoOrina,string varEgresoVomito,string varEgresoSng,string varEgresoOtros,string varObservaciones,int? varAuditUser,int? varEscalaDelDolor,int? varIdClasificacion,bool? varTriage)
		{
			GuardiaTriage item = new GuardiaTriage();
			
				item.Id = varId;
			
				item.RegistroGuardia = varRegistroGuardia;
			
				item.IdEfector = varIdEfector;
			
				item.FechaHora = varFechaHora;
			
				item.TensionArterial = varTensionArterial;
			
				item.FrecuenciaCardiaca = varFrecuenciaCardiaca;
			
				item.FrecuenciaRespiratoria = varFrecuenciaRespiratoria;
			
				item.Temperatura = varTemperatura;
			
				item.SaturacionOxigeno = varSaturacionOxigeno;
			
				item.GlasgowOcular = varGlasgowOcular;
			
				item.GlasgowVerbal = varGlasgowVerbal;
			
				item.GlasgowMotor = varGlasgowMotor;
			
				item.Peso = varPeso;
			
				item.PupilasTamano = varPupilasTamano;
			
				item.PupilasReactividad = varPupilasReactividad;
			
				item.PupilasSimetria = varPupilasSimetria;
			
				item.Sensorio = varSensorio;
			
				item.Sibilancia = varSibilancia;
			
				item.MuscAccesorio = varMuscAccesorio;
			
				item.IngresoAlimentacionCant = varIngresoAlimentacionCant;
			
				item.IngresoAlimentacionTipo = varIngresoAlimentacionTipo;
			
				item.IngresoSolucion = varIngresoSolucion;
			
				item.IngresoOtros = varIngresoOtros;
			
				item.EgresoDepos = varEgresoDepos;
			
				item.EgresoOrina = varEgresoOrina;
			
				item.EgresoVomito = varEgresoVomito;
			
				item.EgresoSng = varEgresoSng;
			
				item.EgresoOtros = varEgresoOtros;
			
				item.Observaciones = varObservaciones;
			
				item.AuditUser = varAuditUser;
			
				item.EscalaDelDolor = varEscalaDelDolor;
			
				item.IdClasificacion = varIdClasificacion;
			
				item.Triage = varTriage;
			
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
        
        
        
        public static TableSchema.TableColumn RegistroGuardiaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHoraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TensionArterialColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FrecuenciaCardiacaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FrecuenciaRespiratoriaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TemperaturaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn SaturacionOxigenoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn GlasgowOcularColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn GlasgowVerbalColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn GlasgowMotorColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PupilasTamanoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PupilasReactividadColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn PupilasSimetriaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn SensorioColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn SibilanciaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn MuscAccesorioColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoAlimentacionCantColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoAlimentacionTipoColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoSolucionColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IngresoOtrosColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoDeposColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoOrinaColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoVomitoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoSngColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn EgresoOtrosColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn AuditUserColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn EscalaDelDolorColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn TriageColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string RegistroGuardia = @"registroGuardia";
			 public static string IdEfector = @"idEfector";
			 public static string FechaHora = @"fechaHora";
			 public static string TensionArterial = @"tensionArterial";
			 public static string FrecuenciaCardiaca = @"frecuenciaCardiaca";
			 public static string FrecuenciaRespiratoria = @"frecuenciaRespiratoria";
			 public static string Temperatura = @"temperatura";
			 public static string SaturacionOxigeno = @"saturacionOxigeno";
			 public static string GlasgowOcular = @"glasgow_ocular";
			 public static string GlasgowVerbal = @"glasgow_verbal";
			 public static string GlasgowMotor = @"glasgow_motor";
			 public static string Peso = @"peso";
			 public static string PupilasTamano = @"pupilas_tamano";
			 public static string PupilasReactividad = @"pupilas_reactividad";
			 public static string PupilasSimetria = @"pupilas_simetria";
			 public static string Sensorio = @"sensorio";
			 public static string Sibilancia = @"sibilancia";
			 public static string MuscAccesorio = @"muscAccesorio";
			 public static string IngresoAlimentacionCant = @"ingresoAlimentacionCant";
			 public static string IngresoAlimentacionTipo = @"ingresoAlimentacionTipo";
			 public static string IngresoSolucion = @"ingresoSolucion";
			 public static string IngresoOtros = @"ingresoOtros";
			 public static string EgresoDepos = @"egresoDepos";
			 public static string EgresoOrina = @"egresoOrina";
			 public static string EgresoVomito = @"egresoVomito";
			 public static string EgresoSng = @"egresoSng";
			 public static string EgresoOtros = @"egresoOtros";
			 public static string Observaciones = @"observaciones";
			 public static string AuditUser = @"audit_user";
			 public static string EscalaDelDolor = @"escalaDelDolor";
			 public static string IdClasificacion = @"idClasificacion";
			 public static string Triage = @"triage";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
