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
	/// Strongly-typed collection for the LabSolicitudScreening class.
	/// </summary>
    [Serializable]
	public partial class LabSolicitudScreeningCollection : ActiveList<LabSolicitudScreening, LabSolicitudScreeningCollection>
	{	   
		public LabSolicitudScreeningCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabSolicitudScreeningCollection</returns>
		public LabSolicitudScreeningCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabSolicitudScreening o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_SolicitudScreening table.
	/// </summary>
	[Serializable]
	public partial class LabSolicitudScreening : ActiveRecord<LabSolicitudScreening>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabSolicitudScreening()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabSolicitudScreening(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabSolicitudScreening(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabSolicitudScreening(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_SolicitudScreening", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSolicitudScreening = new TableSchema.TableColumn(schema);
				colvarIdSolicitudScreening.ColumnName = "idSolicitudScreening";
				colvarIdSolicitudScreening.DataType = DbType.Int32;
				colvarIdSolicitudScreening.MaxLength = 0;
				colvarIdSolicitudScreening.AutoIncrement = true;
				colvarIdSolicitudScreening.IsNullable = false;
				colvarIdSolicitudScreening.IsPrimaryKey = true;
				colvarIdSolicitudScreening.IsForeignKey = false;
				colvarIdSolicitudScreening.IsReadOnly = false;
				colvarIdSolicitudScreening.DefaultSetting = @"";
				colvarIdSolicitudScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSolicitudScreening);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarIdEfectorSolicitante = new TableSchema.TableColumn(schema);
				colvarIdEfectorSolicitante.ColumnName = "idEfectorSolicitante";
				colvarIdEfectorSolicitante.DataType = DbType.Int32;
				colvarIdEfectorSolicitante.MaxLength = 0;
				colvarIdEfectorSolicitante.AutoIncrement = false;
				colvarIdEfectorSolicitante.IsNullable = false;
				colvarIdEfectorSolicitante.IsPrimaryKey = false;
				colvarIdEfectorSolicitante.IsForeignKey = true;
				colvarIdEfectorSolicitante.IsReadOnly = false;
				colvarIdEfectorSolicitante.DefaultSetting = @"";
				
					colvarIdEfectorSolicitante.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorSolicitante);
				
				TableSchema.TableColumn colvarNumeroTarjeta = new TableSchema.TableColumn(schema);
				colvarNumeroTarjeta.ColumnName = "numeroTarjeta";
				colvarNumeroTarjeta.DataType = DbType.Int32;
				colvarNumeroTarjeta.MaxLength = 0;
				colvarNumeroTarjeta.AutoIncrement = false;
				colvarNumeroTarjeta.IsNullable = false;
				colvarNumeroTarjeta.IsPrimaryKey = false;
				colvarNumeroTarjeta.IsForeignKey = false;
				colvarNumeroTarjeta.IsReadOnly = false;
				
						colvarNumeroTarjeta.DefaultSetting = @"((0))";
				colvarNumeroTarjeta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroTarjeta);
				
				TableSchema.TableColumn colvarMedicoSolicitante = new TableSchema.TableColumn(schema);
				colvarMedicoSolicitante.ColumnName = "medicoSolicitante";
				colvarMedicoSolicitante.DataType = DbType.String;
				colvarMedicoSolicitante.MaxLength = 500;
				colvarMedicoSolicitante.AutoIncrement = false;
				colvarMedicoSolicitante.IsNullable = false;
				colvarMedicoSolicitante.IsPrimaryKey = false;
				colvarMedicoSolicitante.IsForeignKey = false;
				colvarMedicoSolicitante.IsReadOnly = false;
				colvarMedicoSolicitante.DefaultSetting = @"";
				colvarMedicoSolicitante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicoSolicitante);
				
				TableSchema.TableColumn colvarApellidoMaterno = new TableSchema.TableColumn(schema);
				colvarApellidoMaterno.ColumnName = "apellidoMaterno";
				colvarApellidoMaterno.DataType = DbType.String;
				colvarApellidoMaterno.MaxLength = 500;
				colvarApellidoMaterno.AutoIncrement = false;
				colvarApellidoMaterno.IsNullable = false;
				colvarApellidoMaterno.IsPrimaryKey = false;
				colvarApellidoMaterno.IsForeignKey = false;
				colvarApellidoMaterno.IsReadOnly = false;
				colvarApellidoMaterno.DefaultSetting = @"";
				colvarApellidoMaterno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoMaterno);
				
				TableSchema.TableColumn colvarApellidoPaterno = new TableSchema.TableColumn(schema);
				colvarApellidoPaterno.ColumnName = "apellidoPaterno";
				colvarApellidoPaterno.DataType = DbType.String;
				colvarApellidoPaterno.MaxLength = 500;
				colvarApellidoPaterno.AutoIncrement = false;
				colvarApellidoPaterno.IsNullable = false;
				colvarApellidoPaterno.IsPrimaryKey = false;
				colvarApellidoPaterno.IsForeignKey = false;
				colvarApellidoPaterno.IsReadOnly = false;
				colvarApellidoPaterno.DefaultSetting = @"";
				colvarApellidoPaterno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoPaterno);
				
				TableSchema.TableColumn colvarHoraNacimiento = new TableSchema.TableColumn(schema);
				colvarHoraNacimiento.ColumnName = "horaNacimiento";
				colvarHoraNacimiento.DataType = DbType.String;
				colvarHoraNacimiento.MaxLength = 50;
				colvarHoraNacimiento.AutoIncrement = false;
				colvarHoraNacimiento.IsNullable = false;
				colvarHoraNacimiento.IsPrimaryKey = false;
				colvarHoraNacimiento.IsForeignKey = false;
				colvarHoraNacimiento.IsReadOnly = false;
				colvarHoraNacimiento.DefaultSetting = @"";
				colvarHoraNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraNacimiento);
				
				TableSchema.TableColumn colvarEdadGestacional = new TableSchema.TableColumn(schema);
				colvarEdadGestacional.ColumnName = "edadGestacional";
				colvarEdadGestacional.DataType = DbType.Int32;
				colvarEdadGestacional.MaxLength = 0;
				colvarEdadGestacional.AutoIncrement = false;
				colvarEdadGestacional.IsNullable = false;
				colvarEdadGestacional.IsPrimaryKey = false;
				colvarEdadGestacional.IsForeignKey = false;
				colvarEdadGestacional.IsReadOnly = false;
				colvarEdadGestacional.DefaultSetting = @"";
				colvarEdadGestacional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadGestacional);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = false;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarPrimeraMuestra = new TableSchema.TableColumn(schema);
				colvarPrimeraMuestra.ColumnName = "primeraMuestra";
				colvarPrimeraMuestra.DataType = DbType.Boolean;
				colvarPrimeraMuestra.MaxLength = 0;
				colvarPrimeraMuestra.AutoIncrement = false;
				colvarPrimeraMuestra.IsNullable = false;
				colvarPrimeraMuestra.IsPrimaryKey = false;
				colvarPrimeraMuestra.IsForeignKey = false;
				colvarPrimeraMuestra.IsReadOnly = false;
				
						colvarPrimeraMuestra.DefaultSetting = @"((1))";
				colvarPrimeraMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimeraMuestra);
				
				TableSchema.TableColumn colvarIdMotivoRepeticion = new TableSchema.TableColumn(schema);
				colvarIdMotivoRepeticion.ColumnName = "idMotivoRepeticion";
				colvarIdMotivoRepeticion.DataType = DbType.Int32;
				colvarIdMotivoRepeticion.MaxLength = 0;
				colvarIdMotivoRepeticion.AutoIncrement = false;
				colvarIdMotivoRepeticion.IsNullable = false;
				colvarIdMotivoRepeticion.IsPrimaryKey = false;
				colvarIdMotivoRepeticion.IsForeignKey = false;
				colvarIdMotivoRepeticion.IsReadOnly = false;
				
						colvarIdMotivoRepeticion.DefaultSetting = @"((0))";
				colvarIdMotivoRepeticion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoRepeticion);
				
				TableSchema.TableColumn colvarFechaExtraccion = new TableSchema.TableColumn(schema);
				colvarFechaExtraccion.ColumnName = "fechaExtraccion";
				colvarFechaExtraccion.DataType = DbType.DateTime;
				colvarFechaExtraccion.MaxLength = 0;
				colvarFechaExtraccion.AutoIncrement = false;
				colvarFechaExtraccion.IsNullable = false;
				colvarFechaExtraccion.IsPrimaryKey = false;
				colvarFechaExtraccion.IsForeignKey = false;
				colvarFechaExtraccion.IsReadOnly = false;
				colvarFechaExtraccion.DefaultSetting = @"";
				colvarFechaExtraccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaExtraccion);
				
				TableSchema.TableColumn colvarHoraExtraccion = new TableSchema.TableColumn(schema);
				colvarHoraExtraccion.ColumnName = "horaExtraccion";
				colvarHoraExtraccion.DataType = DbType.String;
				colvarHoraExtraccion.MaxLength = 50;
				colvarHoraExtraccion.AutoIncrement = false;
				colvarHoraExtraccion.IsNullable = false;
				colvarHoraExtraccion.IsPrimaryKey = false;
				colvarHoraExtraccion.IsForeignKey = false;
				colvarHoraExtraccion.IsReadOnly = false;
				colvarHoraExtraccion.DefaultSetting = @"";
				colvarHoraExtraccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraExtraccion);
				
				TableSchema.TableColumn colvarIngestaLeche24Horas = new TableSchema.TableColumn(schema);
				colvarIngestaLeche24Horas.ColumnName = "ingestaLeche24Horas";
				colvarIngestaLeche24Horas.DataType = DbType.Boolean;
				colvarIngestaLeche24Horas.MaxLength = 0;
				colvarIngestaLeche24Horas.AutoIncrement = false;
				colvarIngestaLeche24Horas.IsNullable = false;
				colvarIngestaLeche24Horas.IsPrimaryKey = false;
				colvarIngestaLeche24Horas.IsForeignKey = false;
				colvarIngestaLeche24Horas.IsReadOnly = false;
				
						colvarIngestaLeche24Horas.DefaultSetting = @"((0))";
				colvarIngestaLeche24Horas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngestaLeche24Horas);
				
				TableSchema.TableColumn colvarTipoAlimentacion = new TableSchema.TableColumn(schema);
				colvarTipoAlimentacion.ColumnName = "tipoAlimentacion";
				colvarTipoAlimentacion.DataType = DbType.Int32;
				colvarTipoAlimentacion.MaxLength = 0;
				colvarTipoAlimentacion.AutoIncrement = false;
				colvarTipoAlimentacion.IsNullable = false;
				colvarTipoAlimentacion.IsPrimaryKey = false;
				colvarTipoAlimentacion.IsForeignKey = false;
				colvarTipoAlimentacion.IsReadOnly = false;
				
						colvarTipoAlimentacion.DefaultSetting = @"((0))";
				colvarTipoAlimentacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoAlimentacion);
				
				TableSchema.TableColumn colvarAntibiotico = new TableSchema.TableColumn(schema);
				colvarAntibiotico.ColumnName = "antibiotico";
				colvarAntibiotico.DataType = DbType.Boolean;
				colvarAntibiotico.MaxLength = 0;
				colvarAntibiotico.AutoIncrement = false;
				colvarAntibiotico.IsNullable = false;
				colvarAntibiotico.IsPrimaryKey = false;
				colvarAntibiotico.IsForeignKey = false;
				colvarAntibiotico.IsReadOnly = false;
				
						colvarAntibiotico.DefaultSetting = @"((0))";
				colvarAntibiotico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntibiotico);
				
				TableSchema.TableColumn colvarTransfusion = new TableSchema.TableColumn(schema);
				colvarTransfusion.ColumnName = "transfusion";
				colvarTransfusion.DataType = DbType.Boolean;
				colvarTransfusion.MaxLength = 0;
				colvarTransfusion.AutoIncrement = false;
				colvarTransfusion.IsNullable = false;
				colvarTransfusion.IsPrimaryKey = false;
				colvarTransfusion.IsForeignKey = false;
				colvarTransfusion.IsReadOnly = false;
				
						colvarTransfusion.DefaultSetting = @"((0))";
				colvarTransfusion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransfusion);
				
				TableSchema.TableColumn colvarCorticoides = new TableSchema.TableColumn(schema);
				colvarCorticoides.ColumnName = "corticoides";
				colvarCorticoides.DataType = DbType.Boolean;
				colvarCorticoides.MaxLength = 0;
				colvarCorticoides.AutoIncrement = false;
				colvarCorticoides.IsNullable = false;
				colvarCorticoides.IsPrimaryKey = false;
				colvarCorticoides.IsForeignKey = false;
				colvarCorticoides.IsReadOnly = false;
				
						colvarCorticoides.DefaultSetting = @"((0))";
				colvarCorticoides.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCorticoides);
				
				TableSchema.TableColumn colvarDopamina = new TableSchema.TableColumn(schema);
				colvarDopamina.ColumnName = "dopamina";
				colvarDopamina.DataType = DbType.Boolean;
				colvarDopamina.MaxLength = 0;
				colvarDopamina.AutoIncrement = false;
				colvarDopamina.IsNullable = false;
				colvarDopamina.IsPrimaryKey = false;
				colvarDopamina.IsForeignKey = false;
				colvarDopamina.IsReadOnly = false;
				
						colvarDopamina.DefaultSetting = @"((0))";
				colvarDopamina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDopamina);
				
				TableSchema.TableColumn colvarEnfermedadTiroideaMaterna = new TableSchema.TableColumn(schema);
				colvarEnfermedadTiroideaMaterna.ColumnName = "enfermedadTiroideaMaterna";
				colvarEnfermedadTiroideaMaterna.DataType = DbType.Boolean;
				colvarEnfermedadTiroideaMaterna.MaxLength = 0;
				colvarEnfermedadTiroideaMaterna.AutoIncrement = false;
				colvarEnfermedadTiroideaMaterna.IsNullable = false;
				colvarEnfermedadTiroideaMaterna.IsPrimaryKey = false;
				colvarEnfermedadTiroideaMaterna.IsForeignKey = false;
				colvarEnfermedadTiroideaMaterna.IsReadOnly = false;
				
						colvarEnfermedadTiroideaMaterna.DefaultSetting = @"((0))";
				colvarEnfermedadTiroideaMaterna.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnfermedadTiroideaMaterna);
				
				TableSchema.TableColumn colvarAntecedentesMaternos = new TableSchema.TableColumn(schema);
				colvarAntecedentesMaternos.ColumnName = "antecedentesMaternos";
				colvarAntecedentesMaternos.DataType = DbType.String;
				colvarAntecedentesMaternos.MaxLength = -1;
				colvarAntecedentesMaternos.AutoIncrement = false;
				colvarAntecedentesMaternos.IsNullable = false;
				colvarAntecedentesMaternos.IsPrimaryKey = false;
				colvarAntecedentesMaternos.IsForeignKey = false;
				colvarAntecedentesMaternos.IsReadOnly = false;
				colvarAntecedentesMaternos.DefaultSetting = @"";
				colvarAntecedentesMaternos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecedentesMaternos);
				
				TableSchema.TableColumn colvarCorticoidesMaterno = new TableSchema.TableColumn(schema);
				colvarCorticoidesMaterno.ColumnName = "corticoidesMaterno";
				colvarCorticoidesMaterno.DataType = DbType.Boolean;
				colvarCorticoidesMaterno.MaxLength = 0;
				colvarCorticoidesMaterno.AutoIncrement = false;
				colvarCorticoidesMaterno.IsNullable = false;
				colvarCorticoidesMaterno.IsPrimaryKey = false;
				colvarCorticoidesMaterno.IsForeignKey = false;
				colvarCorticoidesMaterno.IsReadOnly = false;
				
						colvarCorticoidesMaterno.DefaultSetting = @"((0))";
				colvarCorticoidesMaterno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCorticoidesMaterno);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.String;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = false;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarObservacionesResultados = new TableSchema.TableColumn(schema);
				colvarObservacionesResultados.ColumnName = "observacionesResultados";
				colvarObservacionesResultados.DataType = DbType.String;
				colvarObservacionesResultados.MaxLength = -1;
				colvarObservacionesResultados.AutoIncrement = false;
				colvarObservacionesResultados.IsNullable = false;
				colvarObservacionesResultados.IsPrimaryKey = false;
				colvarObservacionesResultados.IsForeignKey = false;
				colvarObservacionesResultados.IsReadOnly = false;
				colvarObservacionesResultados.DefaultSetting = @"";
				colvarObservacionesResultados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionesResultados);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.Int32;
				colvarEstado.MaxLength = 0;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = false;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				
						colvarEstado.DefaultSetting = @"((0))";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarIdUsuarioRegistro = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRegistro.ColumnName = "idUsuarioRegistro";
				colvarIdUsuarioRegistro.DataType = DbType.Int32;
				colvarIdUsuarioRegistro.MaxLength = 0;
				colvarIdUsuarioRegistro.AutoIncrement = false;
				colvarIdUsuarioRegistro.IsNullable = false;
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
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				colvarFechaRegistro.DefaultSetting = @"";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				TableSchema.TableColumn colvarIdUsuarioEnvio = new TableSchema.TableColumn(schema);
				colvarIdUsuarioEnvio.ColumnName = "idUsuarioEnvio";
				colvarIdUsuarioEnvio.DataType = DbType.AnsiString;
				colvarIdUsuarioEnvio.MaxLength = 50;
				colvarIdUsuarioEnvio.AutoIncrement = false;
				colvarIdUsuarioEnvio.IsNullable = false;
				colvarIdUsuarioEnvio.IsPrimaryKey = false;
				colvarIdUsuarioEnvio.IsForeignKey = false;
				colvarIdUsuarioEnvio.IsReadOnly = false;
				colvarIdUsuarioEnvio.DefaultSetting = @"";
				colvarIdUsuarioEnvio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioEnvio);
				
				TableSchema.TableColumn colvarFechaEnvio = new TableSchema.TableColumn(schema);
				colvarFechaEnvio.ColumnName = "fechaEnvio";
				colvarFechaEnvio.DataType = DbType.DateTime;
				colvarFechaEnvio.MaxLength = 0;
				colvarFechaEnvio.AutoIncrement = false;
				colvarFechaEnvio.IsNullable = false;
				colvarFechaEnvio.IsPrimaryKey = false;
				colvarFechaEnvio.IsForeignKey = false;
				colvarFechaEnvio.IsReadOnly = false;
				
						colvarFechaEnvio.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaEnvio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEnvio);
				
				TableSchema.TableColumn colvarIdUsuarioRecibe = new TableSchema.TableColumn(schema);
				colvarIdUsuarioRecibe.ColumnName = "idUsuarioRecibe";
				colvarIdUsuarioRecibe.DataType = DbType.AnsiString;
				colvarIdUsuarioRecibe.MaxLength = 50;
				colvarIdUsuarioRecibe.AutoIncrement = false;
				colvarIdUsuarioRecibe.IsNullable = false;
				colvarIdUsuarioRecibe.IsPrimaryKey = false;
				colvarIdUsuarioRecibe.IsForeignKey = false;
				colvarIdUsuarioRecibe.IsReadOnly = false;
				colvarIdUsuarioRecibe.DefaultSetting = @"";
				colvarIdUsuarioRecibe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioRecibe);
				
				TableSchema.TableColumn colvarFechaRecibe = new TableSchema.TableColumn(schema);
				colvarFechaRecibe.ColumnName = "fechaRecibe";
				colvarFechaRecibe.DataType = DbType.DateTime;
				colvarFechaRecibe.MaxLength = 0;
				colvarFechaRecibe.AutoIncrement = false;
				colvarFechaRecibe.IsNullable = false;
				colvarFechaRecibe.IsPrimaryKey = false;
				colvarFechaRecibe.IsForeignKey = false;
				colvarFechaRecibe.IsReadOnly = false;
				
						colvarFechaRecibe.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaRecibe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecibe);
				
				TableSchema.TableColumn colvarIdUsuarioValida = new TableSchema.TableColumn(schema);
				colvarIdUsuarioValida.ColumnName = "idUsuarioValida";
				colvarIdUsuarioValida.DataType = DbType.AnsiString;
				colvarIdUsuarioValida.MaxLength = 50;
				colvarIdUsuarioValida.AutoIncrement = false;
				colvarIdUsuarioValida.IsNullable = false;
				colvarIdUsuarioValida.IsPrimaryKey = false;
				colvarIdUsuarioValida.IsForeignKey = false;
				colvarIdUsuarioValida.IsReadOnly = false;
				colvarIdUsuarioValida.DefaultSetting = @"";
				colvarIdUsuarioValida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioValida);
				
				TableSchema.TableColumn colvarFechaValida = new TableSchema.TableColumn(schema);
				colvarFechaValida.ColumnName = "fechaValida";
				colvarFechaValida.DataType = DbType.DateTime;
				colvarFechaValida.MaxLength = 0;
				colvarFechaValida.AutoIncrement = false;
				colvarFechaValida.IsNullable = false;
				colvarFechaValida.IsPrimaryKey = false;
				colvarFechaValida.IsForeignKey = false;
				colvarFechaValida.IsReadOnly = false;
				
						colvarFechaValida.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaValida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaValida);
				
				TableSchema.TableColumn colvarIdLugarControl = new TableSchema.TableColumn(schema);
				colvarIdLugarControl.ColumnName = "idLugarControl";
				colvarIdLugarControl.DataType = DbType.Int32;
				colvarIdLugarControl.MaxLength = 0;
				colvarIdLugarControl.AutoIncrement = false;
				colvarIdLugarControl.IsNullable = false;
				colvarIdLugarControl.IsPrimaryKey = false;
				colvarIdLugarControl.IsForeignKey = true;
				colvarIdLugarControl.IsReadOnly = false;
				colvarIdLugarControl.DefaultSetting = @"";
				
					colvarIdLugarControl.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdLugarControl);
				
				TableSchema.TableColumn colvarIdEfectorModifica = new TableSchema.TableColumn(schema);
				colvarIdEfectorModifica.ColumnName = "idEfectorModifica";
				colvarIdEfectorModifica.DataType = DbType.Int32;
				colvarIdEfectorModifica.MaxLength = 0;
				colvarIdEfectorModifica.AutoIncrement = false;
				colvarIdEfectorModifica.IsNullable = true;
				colvarIdEfectorModifica.IsPrimaryKey = false;
				colvarIdEfectorModifica.IsForeignKey = false;
				colvarIdEfectorModifica.IsReadOnly = false;
				colvarIdEfectorModifica.DefaultSetting = @"";
				colvarIdEfectorModifica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfectorModifica);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "Comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = 4000;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarMotivo = new TableSchema.TableColumn(schema);
				colvarMotivo.ColumnName = "Motivo";
				colvarMotivo.DataType = DbType.AnsiString;
				colvarMotivo.MaxLength = 4000;
				colvarMotivo.AutoIncrement = false;
				colvarMotivo.IsNullable = true;
				colvarMotivo.IsPrimaryKey = false;
				colvarMotivo.IsForeignKey = false;
				colvarMotivo.IsReadOnly = false;
				colvarMotivo.DefaultSetting = @"";
				colvarMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_SolicitudScreening",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSolicitudScreening")]
		[Bindable(true)]
		public int IdSolicitudScreening 
		{
			get { return GetColumnValue<int>(Columns.IdSolicitudScreening); }
			set { SetColumnValue(Columns.IdSolicitudScreening, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdEfectorSolicitante")]
		[Bindable(true)]
		public int IdEfectorSolicitante 
		{
			get { return GetColumnValue<int>(Columns.IdEfectorSolicitante); }
			set { SetColumnValue(Columns.IdEfectorSolicitante, value); }
		}
		  
		[XmlAttribute("NumeroTarjeta")]
		[Bindable(true)]
		public int NumeroTarjeta 
		{
			get { return GetColumnValue<int>(Columns.NumeroTarjeta); }
			set { SetColumnValue(Columns.NumeroTarjeta, value); }
		}
		  
		[XmlAttribute("MedicoSolicitante")]
		[Bindable(true)]
		public string MedicoSolicitante 
		{
			get { return GetColumnValue<string>(Columns.MedicoSolicitante); }
			set { SetColumnValue(Columns.MedicoSolicitante, value); }
		}
		  
		[XmlAttribute("ApellidoMaterno")]
		[Bindable(true)]
		public string ApellidoMaterno 
		{
			get { return GetColumnValue<string>(Columns.ApellidoMaterno); }
			set { SetColumnValue(Columns.ApellidoMaterno, value); }
		}
		  
		[XmlAttribute("ApellidoPaterno")]
		[Bindable(true)]
		public string ApellidoPaterno 
		{
			get { return GetColumnValue<string>(Columns.ApellidoPaterno); }
			set { SetColumnValue(Columns.ApellidoPaterno, value); }
		}
		  
		[XmlAttribute("HoraNacimiento")]
		[Bindable(true)]
		public string HoraNacimiento 
		{
			get { return GetColumnValue<string>(Columns.HoraNacimiento); }
			set { SetColumnValue(Columns.HoraNacimiento, value); }
		}
		  
		[XmlAttribute("EdadGestacional")]
		[Bindable(true)]
		public int EdadGestacional 
		{
			get { return GetColumnValue<int>(Columns.EdadGestacional); }
			set { SetColumnValue(Columns.EdadGestacional, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal Peso 
		{
			get { return GetColumnValue<decimal>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("PrimeraMuestra")]
		[Bindable(true)]
		public bool PrimeraMuestra 
		{
			get { return GetColumnValue<bool>(Columns.PrimeraMuestra); }
			set { SetColumnValue(Columns.PrimeraMuestra, value); }
		}
		  
		[XmlAttribute("IdMotivoRepeticion")]
		[Bindable(true)]
		public int IdMotivoRepeticion 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoRepeticion); }
			set { SetColumnValue(Columns.IdMotivoRepeticion, value); }
		}
		  
		[XmlAttribute("FechaExtraccion")]
		[Bindable(true)]
		public DateTime FechaExtraccion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaExtraccion); }
			set { SetColumnValue(Columns.FechaExtraccion, value); }
		}
		  
		[XmlAttribute("HoraExtraccion")]
		[Bindable(true)]
		public string HoraExtraccion 
		{
			get { return GetColumnValue<string>(Columns.HoraExtraccion); }
			set { SetColumnValue(Columns.HoraExtraccion, value); }
		}
		  
		[XmlAttribute("IngestaLeche24Horas")]
		[Bindable(true)]
		public bool IngestaLeche24Horas 
		{
			get { return GetColumnValue<bool>(Columns.IngestaLeche24Horas); }
			set { SetColumnValue(Columns.IngestaLeche24Horas, value); }
		}
		  
		[XmlAttribute("TipoAlimentacion")]
		[Bindable(true)]
		public int TipoAlimentacion 
		{
			get { return GetColumnValue<int>(Columns.TipoAlimentacion); }
			set { SetColumnValue(Columns.TipoAlimentacion, value); }
		}
		  
		[XmlAttribute("Antibiotico")]
		[Bindable(true)]
		public bool Antibiotico 
		{
			get { return GetColumnValue<bool>(Columns.Antibiotico); }
			set { SetColumnValue(Columns.Antibiotico, value); }
		}
		  
		[XmlAttribute("Transfusion")]
		[Bindable(true)]
		public bool Transfusion 
		{
			get { return GetColumnValue<bool>(Columns.Transfusion); }
			set { SetColumnValue(Columns.Transfusion, value); }
		}
		  
		[XmlAttribute("Corticoides")]
		[Bindable(true)]
		public bool Corticoides 
		{
			get { return GetColumnValue<bool>(Columns.Corticoides); }
			set { SetColumnValue(Columns.Corticoides, value); }
		}
		  
		[XmlAttribute("Dopamina")]
		[Bindable(true)]
		public bool Dopamina 
		{
			get { return GetColumnValue<bool>(Columns.Dopamina); }
			set { SetColumnValue(Columns.Dopamina, value); }
		}
		  
		[XmlAttribute("EnfermedadTiroideaMaterna")]
		[Bindable(true)]
		public bool EnfermedadTiroideaMaterna 
		{
			get { return GetColumnValue<bool>(Columns.EnfermedadTiroideaMaterna); }
			set { SetColumnValue(Columns.EnfermedadTiroideaMaterna, value); }
		}
		  
		[XmlAttribute("AntecedentesMaternos")]
		[Bindable(true)]
		public string AntecedentesMaternos 
		{
			get { return GetColumnValue<string>(Columns.AntecedentesMaternos); }
			set { SetColumnValue(Columns.AntecedentesMaternos, value); }
		}
		  
		[XmlAttribute("CorticoidesMaterno")]
		[Bindable(true)]
		public bool CorticoidesMaterno 
		{
			get { return GetColumnValue<bool>(Columns.CorticoidesMaterno); }
			set { SetColumnValue(Columns.CorticoidesMaterno, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("ObservacionesResultados")]
		[Bindable(true)]
		public string ObservacionesResultados 
		{
			get { return GetColumnValue<string>(Columns.ObservacionesResultados); }
			set { SetColumnValue(Columns.ObservacionesResultados, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public int Estado 
		{
			get { return GetColumnValue<int>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("IdUsuarioRegistro")]
		[Bindable(true)]
		public int IdUsuarioRegistro 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioRegistro); }
			set { SetColumnValue(Columns.IdUsuarioRegistro, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		  
		[XmlAttribute("IdUsuarioEnvio")]
		[Bindable(true)]
		public string IdUsuarioEnvio 
		{
			get { return GetColumnValue<string>(Columns.IdUsuarioEnvio); }
			set { SetColumnValue(Columns.IdUsuarioEnvio, value); }
		}
		  
		[XmlAttribute("FechaEnvio")]
		[Bindable(true)]
		public DateTime FechaEnvio 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaEnvio); }
			set { SetColumnValue(Columns.FechaEnvio, value); }
		}
		  
		[XmlAttribute("IdUsuarioRecibe")]
		[Bindable(true)]
		public string IdUsuarioRecibe 
		{
			get { return GetColumnValue<string>(Columns.IdUsuarioRecibe); }
			set { SetColumnValue(Columns.IdUsuarioRecibe, value); }
		}
		  
		[XmlAttribute("FechaRecibe")]
		[Bindable(true)]
		public DateTime FechaRecibe 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRecibe); }
			set { SetColumnValue(Columns.FechaRecibe, value); }
		}
		  
		[XmlAttribute("IdUsuarioValida")]
		[Bindable(true)]
		public string IdUsuarioValida 
		{
			get { return GetColumnValue<string>(Columns.IdUsuarioValida); }
			set { SetColumnValue(Columns.IdUsuarioValida, value); }
		}
		  
		[XmlAttribute("FechaValida")]
		[Bindable(true)]
		public DateTime FechaValida 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaValida); }
			set { SetColumnValue(Columns.FechaValida, value); }
		}
		  
		[XmlAttribute("IdLugarControl")]
		[Bindable(true)]
		public int IdLugarControl 
		{
			get { return GetColumnValue<int>(Columns.IdLugarControl); }
			set { SetColumnValue(Columns.IdLugarControl, value); }
		}
		  
		[XmlAttribute("IdEfectorModifica")]
		[Bindable(true)]
		public int? IdEfectorModifica 
		{
			get { return GetColumnValue<int?>(Columns.IdEfectorModifica); }
			set { SetColumnValue(Columns.IdEfectorModifica, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("Motivo")]
		[Bindable(true)]
		public string Motivo 
		{
			get { return GetColumnValue<string>(Columns.Motivo); }
			set { SetColumnValue(Columns.Motivo, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.LabProtocoloScreeningDetalleCollection colLabProtocoloScreeningDetalleRecords;
		public DalSic.LabProtocoloScreeningDetalleCollection LabProtocoloScreeningDetalleRecords
		{
			get
			{
				if(colLabProtocoloScreeningDetalleRecords == null)
				{
					colLabProtocoloScreeningDetalleRecords = new DalSic.LabProtocoloScreeningDetalleCollection().Where(LabProtocoloScreeningDetalle.Columns.IdSolicitudScreening, IdSolicitudScreening).Load();
					colLabProtocoloScreeningDetalleRecords.ListChanged += new ListChangedEventHandler(colLabProtocoloScreeningDetalleRecords_ListChanged);
				}
				return colLabProtocoloScreeningDetalleRecords;			
			}
			set 
			{ 
					colLabProtocoloScreeningDetalleRecords = value; 
					colLabProtocoloScreeningDetalleRecords.ListChanged += new ListChangedEventHandler(colLabProtocoloScreeningDetalleRecords_ListChanged);
			}
		}
		
		void colLabProtocoloScreeningDetalleRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabProtocoloScreeningDetalleRecords[e.NewIndex].IdSolicitudScreening = IdSolicitudScreening;
		    }
		}
				
		private DalSic.LabAlarmaScreeningCollection colLabAlarmaScreeningRecords;
		public DalSic.LabAlarmaScreeningCollection LabAlarmaScreeningRecords
		{
			get
			{
				if(colLabAlarmaScreeningRecords == null)
				{
					colLabAlarmaScreeningRecords = new DalSic.LabAlarmaScreeningCollection().Where(LabAlarmaScreening.Columns.IdSolicitudScreening, IdSolicitudScreening).Load();
					colLabAlarmaScreeningRecords.ListChanged += new ListChangedEventHandler(colLabAlarmaScreeningRecords_ListChanged);
				}
				return colLabAlarmaScreeningRecords;			
			}
			set 
			{ 
					colLabAlarmaScreeningRecords = value; 
					colLabAlarmaScreeningRecords.ListChanged += new ListChangedEventHandler(colLabAlarmaScreeningRecords_ListChanged);
			}
		}
		
		void colLabAlarmaScreeningRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabAlarmaScreeningRecords[e.NewIndex].IdSolicitudScreening = IdSolicitudScreening;
		    }
		}
				
		private DalSic.LabDetalleSolicitudScreeningCollection colLabDetalleSolicitudScreeningRecords;
		public DalSic.LabDetalleSolicitudScreeningCollection LabDetalleSolicitudScreeningRecords
		{
			get
			{
				if(colLabDetalleSolicitudScreeningRecords == null)
				{
					colLabDetalleSolicitudScreeningRecords = new DalSic.LabDetalleSolicitudScreeningCollection().Where(LabDetalleSolicitudScreening.Columns.IdSolicitudScreening, IdSolicitudScreening).Load();
					colLabDetalleSolicitudScreeningRecords.ListChanged += new ListChangedEventHandler(colLabDetalleSolicitudScreeningRecords_ListChanged);
				}
				return colLabDetalleSolicitudScreeningRecords;			
			}
			set 
			{ 
					colLabDetalleSolicitudScreeningRecords = value; 
					colLabDetalleSolicitudScreeningRecords.ListChanged += new ListChangedEventHandler(colLabDetalleSolicitudScreeningRecords_ListChanged);
			}
		}
		
		void colLabDetalleSolicitudScreeningRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabDetalleSolicitudScreeningRecords[e.NewIndex].IdSolicitudScreening = IdSolicitudScreening;
		    }
		}
				
		private DalSic.LabSolicitudScreeningRepeticionCollection colLabSolicitudScreeningRepeticionRecords;
		public DalSic.LabSolicitudScreeningRepeticionCollection LabSolicitudScreeningRepeticionRecords
		{
			get
			{
				if(colLabSolicitudScreeningRepeticionRecords == null)
				{
					colLabSolicitudScreeningRepeticionRecords = new DalSic.LabSolicitudScreeningRepeticionCollection().Where(LabSolicitudScreeningRepeticion.Columns.IdSolicitudScreening, IdSolicitudScreening).Load();
					colLabSolicitudScreeningRepeticionRecords.ListChanged += new ListChangedEventHandler(colLabSolicitudScreeningRepeticionRecords_ListChanged);
				}
				return colLabSolicitudScreeningRepeticionRecords;			
			}
			set 
			{ 
					colLabSolicitudScreeningRepeticionRecords = value; 
					colLabSolicitudScreeningRepeticionRecords.ListChanged += new ListChangedEventHandler(colLabSolicitudScreeningRepeticionRecords_ListChanged);
			}
		}
		
		void colLabSolicitudScreeningRepeticionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabSolicitudScreeningRepeticionRecords[e.NewIndex].IdSolicitudScreening = IdSolicitudScreening;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this LabSolicitudScreening
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorSolicitante); }
			set { SetColumnValue("idEfectorSolicitante", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this LabSolicitudScreening
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdLugarControl
		{
			get { return DalSic.SysEfector.FetchByID(this.IdLugarControl); }
			set { SetColumnValue("idLugarControl", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varIdEfectorSolicitante,int varNumeroTarjeta,string varMedicoSolicitante,string varApellidoMaterno,string varApellidoPaterno,string varHoraNacimiento,int varEdadGestacional,decimal varPeso,bool varPrimeraMuestra,int varIdMotivoRepeticion,DateTime varFechaExtraccion,string varHoraExtraccion,bool varIngestaLeche24Horas,int varTipoAlimentacion,bool varAntibiotico,bool varTransfusion,bool varCorticoides,bool varDopamina,bool varEnfermedadTiroideaMaterna,string varAntecedentesMaternos,bool varCorticoidesMaterno,string varObservaciones,string varObservacionesResultados,int varEstado,int varIdUsuarioRegistro,DateTime varFechaRegistro,string varIdUsuarioEnvio,DateTime varFechaEnvio,string varIdUsuarioRecibe,DateTime varFechaRecibe,string varIdUsuarioValida,DateTime varFechaValida,int varIdLugarControl,int? varIdEfectorModifica,string varComentario,string varMotivo)
		{
			LabSolicitudScreening item = new LabSolicitudScreening();
			
			item.IdPaciente = varIdPaciente;
			
			item.IdEfectorSolicitante = varIdEfectorSolicitante;
			
			item.NumeroTarjeta = varNumeroTarjeta;
			
			item.MedicoSolicitante = varMedicoSolicitante;
			
			item.ApellidoMaterno = varApellidoMaterno;
			
			item.ApellidoPaterno = varApellidoPaterno;
			
			item.HoraNacimiento = varHoraNacimiento;
			
			item.EdadGestacional = varEdadGestacional;
			
			item.Peso = varPeso;
			
			item.PrimeraMuestra = varPrimeraMuestra;
			
			item.IdMotivoRepeticion = varIdMotivoRepeticion;
			
			item.FechaExtraccion = varFechaExtraccion;
			
			item.HoraExtraccion = varHoraExtraccion;
			
			item.IngestaLeche24Horas = varIngestaLeche24Horas;
			
			item.TipoAlimentacion = varTipoAlimentacion;
			
			item.Antibiotico = varAntibiotico;
			
			item.Transfusion = varTransfusion;
			
			item.Corticoides = varCorticoides;
			
			item.Dopamina = varDopamina;
			
			item.EnfermedadTiroideaMaterna = varEnfermedadTiroideaMaterna;
			
			item.AntecedentesMaternos = varAntecedentesMaternos;
			
			item.CorticoidesMaterno = varCorticoidesMaterno;
			
			item.Observaciones = varObservaciones;
			
			item.ObservacionesResultados = varObservacionesResultados;
			
			item.Estado = varEstado;
			
			item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
			item.FechaRegistro = varFechaRegistro;
			
			item.IdUsuarioEnvio = varIdUsuarioEnvio;
			
			item.FechaEnvio = varFechaEnvio;
			
			item.IdUsuarioRecibe = varIdUsuarioRecibe;
			
			item.FechaRecibe = varFechaRecibe;
			
			item.IdUsuarioValida = varIdUsuarioValida;
			
			item.FechaValida = varFechaValida;
			
			item.IdLugarControl = varIdLugarControl;
			
			item.IdEfectorModifica = varIdEfectorModifica;
			
			item.Comentario = varComentario;
			
			item.Motivo = varMotivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSolicitudScreening,int varIdPaciente,int varIdEfectorSolicitante,int varNumeroTarjeta,string varMedicoSolicitante,string varApellidoMaterno,string varApellidoPaterno,string varHoraNacimiento,int varEdadGestacional,decimal varPeso,bool varPrimeraMuestra,int varIdMotivoRepeticion,DateTime varFechaExtraccion,string varHoraExtraccion,bool varIngestaLeche24Horas,int varTipoAlimentacion,bool varAntibiotico,bool varTransfusion,bool varCorticoides,bool varDopamina,bool varEnfermedadTiroideaMaterna,string varAntecedentesMaternos,bool varCorticoidesMaterno,string varObservaciones,string varObservacionesResultados,int varEstado,int varIdUsuarioRegistro,DateTime varFechaRegistro,string varIdUsuarioEnvio,DateTime varFechaEnvio,string varIdUsuarioRecibe,DateTime varFechaRecibe,string varIdUsuarioValida,DateTime varFechaValida,int varIdLugarControl,int? varIdEfectorModifica,string varComentario,string varMotivo)
		{
			LabSolicitudScreening item = new LabSolicitudScreening();
			
				item.IdSolicitudScreening = varIdSolicitudScreening;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdEfectorSolicitante = varIdEfectorSolicitante;
			
				item.NumeroTarjeta = varNumeroTarjeta;
			
				item.MedicoSolicitante = varMedicoSolicitante;
			
				item.ApellidoMaterno = varApellidoMaterno;
			
				item.ApellidoPaterno = varApellidoPaterno;
			
				item.HoraNacimiento = varHoraNacimiento;
			
				item.EdadGestacional = varEdadGestacional;
			
				item.Peso = varPeso;
			
				item.PrimeraMuestra = varPrimeraMuestra;
			
				item.IdMotivoRepeticion = varIdMotivoRepeticion;
			
				item.FechaExtraccion = varFechaExtraccion;
			
				item.HoraExtraccion = varHoraExtraccion;
			
				item.IngestaLeche24Horas = varIngestaLeche24Horas;
			
				item.TipoAlimentacion = varTipoAlimentacion;
			
				item.Antibiotico = varAntibiotico;
			
				item.Transfusion = varTransfusion;
			
				item.Corticoides = varCorticoides;
			
				item.Dopamina = varDopamina;
			
				item.EnfermedadTiroideaMaterna = varEnfermedadTiroideaMaterna;
			
				item.AntecedentesMaternos = varAntecedentesMaternos;
			
				item.CorticoidesMaterno = varCorticoidesMaterno;
			
				item.Observaciones = varObservaciones;
			
				item.ObservacionesResultados = varObservacionesResultados;
			
				item.Estado = varEstado;
			
				item.IdUsuarioRegistro = varIdUsuarioRegistro;
			
				item.FechaRegistro = varFechaRegistro;
			
				item.IdUsuarioEnvio = varIdUsuarioEnvio;
			
				item.FechaEnvio = varFechaEnvio;
			
				item.IdUsuarioRecibe = varIdUsuarioRecibe;
			
				item.FechaRecibe = varFechaRecibe;
			
				item.IdUsuarioValida = varIdUsuarioValida;
			
				item.FechaValida = varFechaValida;
			
				item.IdLugarControl = varIdLugarControl;
			
				item.IdEfectorModifica = varIdEfectorModifica;
			
				item.Comentario = varComentario;
			
				item.Motivo = varMotivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorSolicitanteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroTarjetaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoSolicitanteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoMaternoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoPaternoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraNacimientoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadGestacionalColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimeraMuestraColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoRepeticionColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaExtraccionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraExtraccionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IngestaLeche24HorasColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoAlimentacionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn AntibioticoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn TransfusionColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CorticoidesColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn DopaminaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn EnfermedadTiroideaMaternaColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecedentesMaternosColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn CorticoidesMaternoColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesResultadosColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRegistroColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioEnvioColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEnvioColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioRecibeColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecibeColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioValidaColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaValidaColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLugarControlColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorModificaColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSolicitudScreening = @"idSolicitudScreening";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdEfectorSolicitante = @"idEfectorSolicitante";
			 public static string NumeroTarjeta = @"numeroTarjeta";
			 public static string MedicoSolicitante = @"medicoSolicitante";
			 public static string ApellidoMaterno = @"apellidoMaterno";
			 public static string ApellidoPaterno = @"apellidoPaterno";
			 public static string HoraNacimiento = @"horaNacimiento";
			 public static string EdadGestacional = @"edadGestacional";
			 public static string Peso = @"peso";
			 public static string PrimeraMuestra = @"primeraMuestra";
			 public static string IdMotivoRepeticion = @"idMotivoRepeticion";
			 public static string FechaExtraccion = @"fechaExtraccion";
			 public static string HoraExtraccion = @"horaExtraccion";
			 public static string IngestaLeche24Horas = @"ingestaLeche24Horas";
			 public static string TipoAlimentacion = @"tipoAlimentacion";
			 public static string Antibiotico = @"antibiotico";
			 public static string Transfusion = @"transfusion";
			 public static string Corticoides = @"corticoides";
			 public static string Dopamina = @"dopamina";
			 public static string EnfermedadTiroideaMaterna = @"enfermedadTiroideaMaterna";
			 public static string AntecedentesMaternos = @"antecedentesMaternos";
			 public static string CorticoidesMaterno = @"corticoidesMaterno";
			 public static string Observaciones = @"observaciones";
			 public static string ObservacionesResultados = @"observacionesResultados";
			 public static string Estado = @"estado";
			 public static string IdUsuarioRegistro = @"idUsuarioRegistro";
			 public static string FechaRegistro = @"fechaRegistro";
			 public static string IdUsuarioEnvio = @"idUsuarioEnvio";
			 public static string FechaEnvio = @"fechaEnvio";
			 public static string IdUsuarioRecibe = @"idUsuarioRecibe";
			 public static string FechaRecibe = @"fechaRecibe";
			 public static string IdUsuarioValida = @"idUsuarioValida";
			 public static string FechaValida = @"fechaValida";
			 public static string IdLugarControl = @"idLugarControl";
			 public static string IdEfectorModifica = @"idEfectorModifica";
			 public static string Comentario = @"Comentario";
			 public static string Motivo = @"Motivo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colLabProtocoloScreeningDetalleRecords != null)
                {
                    foreach (DalSic.LabProtocoloScreeningDetalle item in colLabProtocoloScreeningDetalleRecords)
                    {
                        if (item.IdSolicitudScreening != IdSolicitudScreening)
                        {
                            item.IdSolicitudScreening = IdSolicitudScreening;
                        }
                    }
               }
		
                if (colLabAlarmaScreeningRecords != null)
                {
                    foreach (DalSic.LabAlarmaScreening item in colLabAlarmaScreeningRecords)
                    {
                        if (item.IdSolicitudScreening != IdSolicitudScreening)
                        {
                            item.IdSolicitudScreening = IdSolicitudScreening;
                        }
                    }
               }
		
                if (colLabDetalleSolicitudScreeningRecords != null)
                {
                    foreach (DalSic.LabDetalleSolicitudScreening item in colLabDetalleSolicitudScreeningRecords)
                    {
                        if (item.IdSolicitudScreening != IdSolicitudScreening)
                        {
                            item.IdSolicitudScreening = IdSolicitudScreening;
                        }
                    }
               }
		
                if (colLabSolicitudScreeningRepeticionRecords != null)
                {
                    foreach (DalSic.LabSolicitudScreeningRepeticion item in colLabSolicitudScreeningRepeticionRecords)
                    {
                        if (item.IdSolicitudScreening != IdSolicitudScreening)
                        {
                            item.IdSolicitudScreening = IdSolicitudScreening;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colLabProtocoloScreeningDetalleRecords != null)
                {
                    colLabProtocoloScreeningDetalleRecords.SaveAll();
               }
		
                if (colLabAlarmaScreeningRecords != null)
                {
                    colLabAlarmaScreeningRecords.SaveAll();
               }
		
                if (colLabDetalleSolicitudScreeningRecords != null)
                {
                    colLabDetalleSolicitudScreeningRecords.SaveAll();
               }
		
                if (colLabSolicitudScreeningRepeticionRecords != null)
                {
                    colLabSolicitudScreeningRepeticionRecords.SaveAll();
               }
		}
        #endregion
	}
}
