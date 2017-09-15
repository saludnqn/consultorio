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
	/// Strongly-typed collection for the AprAborto class.
	/// </summary>
    [Serializable]
	public partial class AprAbortoCollection : ActiveList<AprAborto, AprAbortoCollection>
	{	   
		public AprAbortoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAbortoCollection</returns>
		public AprAbortoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAborto o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_Aborto table.
	/// </summary>
	[Serializable]
	public partial class AprAborto : ActiveRecord<AprAborto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAborto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAborto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAborto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAborto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_Aborto", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAborto = new TableSchema.TableColumn(schema);
				colvarIdAborto.ColumnName = "idAborto";
				colvarIdAborto.DataType = DbType.Int32;
				colvarIdAborto.MaxLength = 0;
				colvarIdAborto.AutoIncrement = true;
				colvarIdAborto.IsNullable = false;
				colvarIdAborto.IsPrimaryKey = true;
				colvarIdAborto.IsForeignKey = false;
				colvarIdAborto.IsReadOnly = false;
				colvarIdAborto.DefaultSetting = @"";
				colvarIdAborto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAborto);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdEmbarazo.ColumnName = "idEmbarazo";
				colvarIdEmbarazo.DataType = DbType.Int32;
				colvarIdEmbarazo.MaxLength = 0;
				colvarIdEmbarazo.AutoIncrement = false;
				colvarIdEmbarazo.IsNullable = true;
				colvarIdEmbarazo.IsPrimaryKey = false;
				colvarIdEmbarazo.IsForeignKey = true;
				colvarIdEmbarazo.IsReadOnly = false;
				colvarIdEmbarazo.DefaultSetting = @"";
				
					colvarIdEmbarazo.ForeignKeyTableName = "APR_Embarazo";
				schema.Columns.Add(colvarIdEmbarazo);
				
				TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
				colvarFechaHora.ColumnName = "FechaHora";
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
				
				TableSchema.TableColumn colvarHospitalizacionDias = new TableSchema.TableColumn(schema);
				colvarHospitalizacionDias.ColumnName = "HospitalizacionDias";
				colvarHospitalizacionDias.DataType = DbType.Int32;
				colvarHospitalizacionDias.MaxLength = 0;
				colvarHospitalizacionDias.AutoIncrement = false;
				colvarHospitalizacionDias.IsNullable = true;
				colvarHospitalizacionDias.IsPrimaryKey = false;
				colvarHospitalizacionDias.IsForeignKey = false;
				colvarHospitalizacionDias.IsReadOnly = false;
				colvarHospitalizacionDias.DefaultSetting = @"";
				colvarHospitalizacionDias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHospitalizacionDias);
				
				TableSchema.TableColumn colvarIdAcompañante = new TableSchema.TableColumn(schema);
				colvarIdAcompañante.ColumnName = "idAcompañante";
				colvarIdAcompañante.DataType = DbType.Int32;
				colvarIdAcompañante.MaxLength = 0;
				colvarIdAcompañante.AutoIncrement = false;
				colvarIdAcompañante.IsNullable = true;
				colvarIdAcompañante.IsPrimaryKey = false;
				colvarIdAcompañante.IsForeignKey = true;
				colvarIdAcompañante.IsReadOnly = false;
				colvarIdAcompañante.DefaultSetting = @"";
				
					colvarIdAcompañante.ForeignKeyTableName = "APR_Acompañante";
				schema.Columns.Add(colvarIdAcompañante);
				
				TableSchema.TableColumn colvarProcedencia = new TableSchema.TableColumn(schema);
				colvarProcedencia.ColumnName = "Procedencia";
				colvarProcedencia.DataType = DbType.AnsiString;
				colvarProcedencia.MaxLength = 50;
				colvarProcedencia.AutoIncrement = false;
				colvarProcedencia.IsNullable = true;
				colvarProcedencia.IsPrimaryKey = false;
				colvarProcedencia.IsForeignKey = false;
				colvarProcedencia.IsReadOnly = false;
				colvarProcedencia.DefaultSetting = @"";
				colvarProcedencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProcedencia);
				
				TableSchema.TableColumn colvarIdTransporte = new TableSchema.TableColumn(schema);
				colvarIdTransporte.ColumnName = "idTransporte";
				colvarIdTransporte.DataType = DbType.Int32;
				colvarIdTransporte.MaxLength = 0;
				colvarIdTransporte.AutoIncrement = false;
				colvarIdTransporte.IsNullable = true;
				colvarIdTransporte.IsPrimaryKey = false;
				colvarIdTransporte.IsForeignKey = false;
				colvarIdTransporte.IsReadOnly = false;
				colvarIdTransporte.DefaultSetting = @"";
				colvarIdTransporte.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTransporte);
				
				TableSchema.TableColumn colvarTiempoTrasladoDias = new TableSchema.TableColumn(schema);
				colvarTiempoTrasladoDias.ColumnName = "TiempoTrasladoDias";
				colvarTiempoTrasladoDias.DataType = DbType.Int32;
				colvarTiempoTrasladoDias.MaxLength = 0;
				colvarTiempoTrasladoDias.AutoIncrement = false;
				colvarTiempoTrasladoDias.IsNullable = true;
				colvarTiempoTrasladoDias.IsPrimaryKey = false;
				colvarTiempoTrasladoDias.IsForeignKey = false;
				colvarTiempoTrasladoDias.IsReadOnly = false;
				colvarTiempoTrasladoDias.DefaultSetting = @"";
				colvarTiempoTrasladoDias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoTrasladoDias);
				
				TableSchema.TableColumn colvarTiempoTrasladoHoras = new TableSchema.TableColumn(schema);
				colvarTiempoTrasladoHoras.ColumnName = "TiempoTrasladoHoras";
				colvarTiempoTrasladoHoras.DataType = DbType.Int32;
				colvarTiempoTrasladoHoras.MaxLength = 0;
				colvarTiempoTrasladoHoras.AutoIncrement = false;
				colvarTiempoTrasladoHoras.IsNullable = true;
				colvarTiempoTrasladoHoras.IsPrimaryKey = false;
				colvarTiempoTrasladoHoras.IsForeignKey = false;
				colvarTiempoTrasladoHoras.IsReadOnly = false;
				colvarTiempoTrasladoHoras.DefaultSetting = @"";
				colvarTiempoTrasladoHoras.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoTrasladoHoras);
				
				TableSchema.TableColumn colvarTiempoTrasladoMinutos = new TableSchema.TableColumn(schema);
				colvarTiempoTrasladoMinutos.ColumnName = "TiempoTrasladoMinutos";
				colvarTiempoTrasladoMinutos.DataType = DbType.Int32;
				colvarTiempoTrasladoMinutos.MaxLength = 0;
				colvarTiempoTrasladoMinutos.AutoIncrement = false;
				colvarTiempoTrasladoMinutos.IsNullable = true;
				colvarTiempoTrasladoMinutos.IsPrimaryKey = false;
				colvarTiempoTrasladoMinutos.IsForeignKey = false;
				colvarTiempoTrasladoMinutos.IsReadOnly = false;
				colvarTiempoTrasladoMinutos.DefaultSetting = @"";
				colvarTiempoTrasladoMinutos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoTrasladoMinutos);
				
				TableSchema.TableColumn colvarPulso = new TableSchema.TableColumn(schema);
				colvarPulso.ColumnName = "Pulso";
				colvarPulso.DataType = DbType.Int32;
				colvarPulso.MaxLength = 0;
				colvarPulso.AutoIncrement = false;
				colvarPulso.IsNullable = true;
				colvarPulso.IsPrimaryKey = false;
				colvarPulso.IsForeignKey = false;
				colvarPulso.IsReadOnly = false;
				colvarPulso.DefaultSetting = @"";
				colvarPulso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPulso);
				
				TableSchema.TableColumn colvarPresionArterialMinima = new TableSchema.TableColumn(schema);
				colvarPresionArterialMinima.ColumnName = "PresionArterialMinima";
				colvarPresionArterialMinima.DataType = DbType.Int32;
				colvarPresionArterialMinima.MaxLength = 0;
				colvarPresionArterialMinima.AutoIncrement = false;
				colvarPresionArterialMinima.IsNullable = true;
				colvarPresionArterialMinima.IsPrimaryKey = false;
				colvarPresionArterialMinima.IsForeignKey = false;
				colvarPresionArterialMinima.IsReadOnly = false;
				colvarPresionArterialMinima.DefaultSetting = @"";
				colvarPresionArterialMinima.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresionArterialMinima);
				
				TableSchema.TableColumn colvarPresionArterialMaxima = new TableSchema.TableColumn(schema);
				colvarPresionArterialMaxima.ColumnName = "PresionArterialMaxima";
				colvarPresionArterialMaxima.DataType = DbType.Int32;
				colvarPresionArterialMaxima.MaxLength = 0;
				colvarPresionArterialMaxima.AutoIncrement = false;
				colvarPresionArterialMaxima.IsNullable = true;
				colvarPresionArterialMaxima.IsPrimaryKey = false;
				colvarPresionArterialMaxima.IsForeignKey = false;
				colvarPresionArterialMaxima.IsReadOnly = false;
				colvarPresionArterialMaxima.DefaultSetting = @"";
				colvarPresionArterialMaxima.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresionArterialMaxima);
				
				TableSchema.TableColumn colvarFrecuenciaRespiratoria = new TableSchema.TableColumn(schema);
				colvarFrecuenciaRespiratoria.ColumnName = "FrecuenciaRespiratoria";
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
				colvarTemperatura.ColumnName = "Temperatura";
				colvarTemperatura.DataType = DbType.Int32;
				colvarTemperatura.MaxLength = 0;
				colvarTemperatura.AutoIncrement = false;
				colvarTemperatura.IsNullable = true;
				colvarTemperatura.IsPrimaryKey = false;
				colvarTemperatura.IsForeignKey = false;
				colvarTemperatura.IsReadOnly = false;
				colvarTemperatura.DefaultSetting = @"";
				colvarTemperatura.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTemperatura);
				
				TableSchema.TableColumn colvarDiasDesdePrimerSintoma = new TableSchema.TableColumn(schema);
				colvarDiasDesdePrimerSintoma.ColumnName = "DiasDesdePrimerSintoma";
				colvarDiasDesdePrimerSintoma.DataType = DbType.Int32;
				colvarDiasDesdePrimerSintoma.MaxLength = 0;
				colvarDiasDesdePrimerSintoma.AutoIncrement = false;
				colvarDiasDesdePrimerSintoma.IsNullable = true;
				colvarDiasDesdePrimerSintoma.IsPrimaryKey = false;
				colvarDiasDesdePrimerSintoma.IsForeignKey = false;
				colvarDiasDesdePrimerSintoma.IsReadOnly = false;
				colvarDiasDesdePrimerSintoma.DefaultSetting = @"";
				colvarDiasDesdePrimerSintoma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiasDesdePrimerSintoma);
				
				TableSchema.TableColumn colvarHorasDesdePrimerSintoma = new TableSchema.TableColumn(schema);
				colvarHorasDesdePrimerSintoma.ColumnName = "HorasDesdePrimerSintoma";
				colvarHorasDesdePrimerSintoma.DataType = DbType.Int32;
				colvarHorasDesdePrimerSintoma.MaxLength = 0;
				colvarHorasDesdePrimerSintoma.AutoIncrement = false;
				colvarHorasDesdePrimerSintoma.IsNullable = true;
				colvarHorasDesdePrimerSintoma.IsPrimaryKey = false;
				colvarHorasDesdePrimerSintoma.IsForeignKey = false;
				colvarHorasDesdePrimerSintoma.IsReadOnly = false;
				colvarHorasDesdePrimerSintoma.DefaultSetting = @"";
				colvarHorasDesdePrimerSintoma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHorasDesdePrimerSintoma);
				
				TableSchema.TableColumn colvarIdSangrado = new TableSchema.TableColumn(schema);
				colvarIdSangrado.ColumnName = "idSangrado";
				colvarIdSangrado.DataType = DbType.Int32;
				colvarIdSangrado.MaxLength = 0;
				colvarIdSangrado.AutoIncrement = false;
				colvarIdSangrado.IsNullable = true;
				colvarIdSangrado.IsPrimaryKey = false;
				colvarIdSangrado.IsForeignKey = false;
				colvarIdSangrado.IsReadOnly = false;
				colvarIdSangrado.DefaultSetting = @"";
				colvarIdSangrado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSangrado);
				
				TableSchema.TableColumn colvarDolor = new TableSchema.TableColumn(schema);
				colvarDolor.ColumnName = "Dolor";
				colvarDolor.DataType = DbType.Int32;
				colvarDolor.MaxLength = 0;
				colvarDolor.AutoIncrement = false;
				colvarDolor.IsNullable = true;
				colvarDolor.IsPrimaryKey = false;
				colvarDolor.IsForeignKey = false;
				colvarDolor.IsReadOnly = false;
				colvarDolor.DefaultSetting = @"";
				colvarDolor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDolor);
				
				TableSchema.TableColumn colvarIdCondicionAlIngreso = new TableSchema.TableColumn(schema);
				colvarIdCondicionAlIngreso.ColumnName = "idCondicionAlIngreso";
				colvarIdCondicionAlIngreso.DataType = DbType.Int32;
				colvarIdCondicionAlIngreso.MaxLength = 0;
				colvarIdCondicionAlIngreso.AutoIncrement = false;
				colvarIdCondicionAlIngreso.IsNullable = true;
				colvarIdCondicionAlIngreso.IsPrimaryKey = false;
				colvarIdCondicionAlIngreso.IsForeignKey = true;
				colvarIdCondicionAlIngreso.IsReadOnly = false;
				colvarIdCondicionAlIngreso.DefaultSetting = @"";
				
					colvarIdCondicionAlIngreso.ForeignKeyTableName = "APR_CondicionIngreso";
				schema.Columns.Add(colvarIdCondicionAlIngreso);
				
				TableSchema.TableColumn colvarIdEstadoAbortoPresuntivo = new TableSchema.TableColumn(schema);
				colvarIdEstadoAbortoPresuntivo.ColumnName = "idEstadoAbortoPresuntivo";
				colvarIdEstadoAbortoPresuntivo.DataType = DbType.Int32;
				colvarIdEstadoAbortoPresuntivo.MaxLength = 0;
				colvarIdEstadoAbortoPresuntivo.AutoIncrement = false;
				colvarIdEstadoAbortoPresuntivo.IsNullable = true;
				colvarIdEstadoAbortoPresuntivo.IsPrimaryKey = false;
				colvarIdEstadoAbortoPresuntivo.IsForeignKey = false;
				colvarIdEstadoAbortoPresuntivo.IsReadOnly = false;
				colvarIdEstadoAbortoPresuntivo.DefaultSetting = @"";
				colvarIdEstadoAbortoPresuntivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstadoAbortoPresuntivo);
				
				TableSchema.TableColumn colvarIdTipoAbortoPresuntivo = new TableSchema.TableColumn(schema);
				colvarIdTipoAbortoPresuntivo.ColumnName = "idTipoAbortoPresuntivo";
				colvarIdTipoAbortoPresuntivo.DataType = DbType.Int32;
				colvarIdTipoAbortoPresuntivo.MaxLength = 0;
				colvarIdTipoAbortoPresuntivo.AutoIncrement = false;
				colvarIdTipoAbortoPresuntivo.IsNullable = true;
				colvarIdTipoAbortoPresuntivo.IsPrimaryKey = false;
				colvarIdTipoAbortoPresuntivo.IsForeignKey = false;
				colvarIdTipoAbortoPresuntivo.IsReadOnly = false;
				colvarIdTipoAbortoPresuntivo.DefaultSetting = @"";
				colvarIdTipoAbortoPresuntivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoAbortoPresuntivo);
				
				TableSchema.TableColumn colvarDIAGCIE10 = new TableSchema.TableColumn(schema);
				colvarDIAGCIE10.ColumnName = "DIAGCIE10";
				colvarDIAGCIE10.DataType = DbType.Int32;
				colvarDIAGCIE10.MaxLength = 0;
				colvarDIAGCIE10.AutoIncrement = false;
				colvarDIAGCIE10.IsNullable = true;
				colvarDIAGCIE10.IsPrimaryKey = false;
				colvarDIAGCIE10.IsForeignKey = true;
				colvarDIAGCIE10.IsReadOnly = false;
				colvarDIAGCIE10.DefaultSetting = @"";
				
					colvarDIAGCIE10.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarDIAGCIE10);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "Responsable";
				colvarResponsable.DataType = DbType.AnsiString;
				colvarResponsable.MaxLength = 50;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = true;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				TableSchema.TableColumn colvarIdExamenConciencia = new TableSchema.TableColumn(schema);
				colvarIdExamenConciencia.ColumnName = "idExamenConciencia";
				colvarIdExamenConciencia.DataType = DbType.Int32;
				colvarIdExamenConciencia.MaxLength = 0;
				colvarIdExamenConciencia.AutoIncrement = false;
				colvarIdExamenConciencia.IsNullable = true;
				colvarIdExamenConciencia.IsPrimaryKey = false;
				colvarIdExamenConciencia.IsForeignKey = false;
				colvarIdExamenConciencia.IsReadOnly = false;
				colvarIdExamenConciencia.DefaultSetting = @"";
				colvarIdExamenConciencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExamenConciencia);
				
				TableSchema.TableColumn colvarIdExamenPielMucosa = new TableSchema.TableColumn(schema);
				colvarIdExamenPielMucosa.ColumnName = "idExamenPielMucosa";
				colvarIdExamenPielMucosa.DataType = DbType.Int32;
				colvarIdExamenPielMucosa.MaxLength = 0;
				colvarIdExamenPielMucosa.AutoIncrement = false;
				colvarIdExamenPielMucosa.IsNullable = true;
				colvarIdExamenPielMucosa.IsPrimaryKey = false;
				colvarIdExamenPielMucosa.IsForeignKey = false;
				colvarIdExamenPielMucosa.IsReadOnly = false;
				colvarIdExamenPielMucosa.DefaultSetting = @"";
				colvarIdExamenPielMucosa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExamenPielMucosa);
				
				TableSchema.TableColumn colvarIdExamenAbdomen = new TableSchema.TableColumn(schema);
				colvarIdExamenAbdomen.ColumnName = "idExamenAbdomen";
				colvarIdExamenAbdomen.DataType = DbType.Int32;
				colvarIdExamenAbdomen.MaxLength = 0;
				colvarIdExamenAbdomen.AutoIncrement = false;
				colvarIdExamenAbdomen.IsNullable = true;
				colvarIdExamenAbdomen.IsPrimaryKey = false;
				colvarIdExamenAbdomen.IsForeignKey = false;
				colvarIdExamenAbdomen.IsReadOnly = false;
				colvarIdExamenAbdomen.DefaultSetting = @"";
				colvarIdExamenAbdomen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExamenAbdomen);
				
				TableSchema.TableColumn colvarTamañoUteroExamenBimanual = new TableSchema.TableColumn(schema);
				colvarTamañoUteroExamenBimanual.ColumnName = "TamañoUteroExamenBimanual";
				colvarTamañoUteroExamenBimanual.DataType = DbType.Int32;
				colvarTamañoUteroExamenBimanual.MaxLength = 0;
				colvarTamañoUteroExamenBimanual.AutoIncrement = false;
				colvarTamañoUteroExamenBimanual.IsNullable = true;
				colvarTamañoUteroExamenBimanual.IsPrimaryKey = false;
				colvarTamañoUteroExamenBimanual.IsForeignKey = false;
				colvarTamañoUteroExamenBimanual.IsReadOnly = false;
				colvarTamañoUteroExamenBimanual.DefaultSetting = @"";
				colvarTamañoUteroExamenBimanual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTamañoUteroExamenBimanual);
				
				TableSchema.TableColumn colvarIdPosicionUtero = new TableSchema.TableColumn(schema);
				colvarIdPosicionUtero.ColumnName = "idPosicionUtero";
				colvarIdPosicionUtero.DataType = DbType.Int32;
				colvarIdPosicionUtero.MaxLength = 0;
				colvarIdPosicionUtero.AutoIncrement = false;
				colvarIdPosicionUtero.IsNullable = true;
				colvarIdPosicionUtero.IsPrimaryKey = false;
				colvarIdPosicionUtero.IsForeignKey = false;
				colvarIdPosicionUtero.IsReadOnly = false;
				colvarIdPosicionUtero.DefaultSetting = @"";
				colvarIdPosicionUtero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPosicionUtero);
				
				TableSchema.TableColumn colvarCuelloCerrado = new TableSchema.TableColumn(schema);
				colvarCuelloCerrado.ColumnName = "CuelloCerrado";
				colvarCuelloCerrado.DataType = DbType.Boolean;
				colvarCuelloCerrado.MaxLength = 0;
				colvarCuelloCerrado.AutoIncrement = false;
				colvarCuelloCerrado.IsNullable = true;
				colvarCuelloCerrado.IsPrimaryKey = false;
				colvarCuelloCerrado.IsForeignKey = false;
				colvarCuelloCerrado.IsReadOnly = false;
				colvarCuelloCerrado.DefaultSetting = @"";
				colvarCuelloCerrado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuelloCerrado);
				
				TableSchema.TableColumn colvarRestos = new TableSchema.TableColumn(schema);
				colvarRestos.ColumnName = "Restos";
				colvarRestos.DataType = DbType.Boolean;
				colvarRestos.MaxLength = 0;
				colvarRestos.AutoIncrement = false;
				colvarRestos.IsNullable = true;
				colvarRestos.IsPrimaryKey = false;
				colvarRestos.IsForeignKey = false;
				colvarRestos.IsReadOnly = false;
				colvarRestos.DefaultSetting = @"";
				colvarRestos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRestos);
				
				TableSchema.TableColumn colvarVaginaNormal = new TableSchema.TableColumn(schema);
				colvarVaginaNormal.ColumnName = "VaginaNormal";
				colvarVaginaNormal.DataType = DbType.Boolean;
				colvarVaginaNormal.MaxLength = 0;
				colvarVaginaNormal.AutoIncrement = false;
				colvarVaginaNormal.IsNullable = true;
				colvarVaginaNormal.IsPrimaryKey = false;
				colvarVaginaNormal.IsForeignKey = false;
				colvarVaginaNormal.IsReadOnly = false;
				colvarVaginaNormal.DefaultSetting = @"";
				colvarVaginaNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVaginaNormal);
				
				TableSchema.TableColumn colvarTamañoUteroPorECO = new TableSchema.TableColumn(schema);
				colvarTamañoUteroPorECO.ColumnName = "TamañoUteroPorECO";
				colvarTamañoUteroPorECO.DataType = DbType.Int32;
				colvarTamañoUteroPorECO.MaxLength = 0;
				colvarTamañoUteroPorECO.AutoIncrement = false;
				colvarTamañoUteroPorECO.IsNullable = true;
				colvarTamañoUteroPorECO.IsPrimaryKey = false;
				colvarTamañoUteroPorECO.IsForeignKey = false;
				colvarTamañoUteroPorECO.IsReadOnly = false;
				colvarTamañoUteroPorECO.DefaultSetting = @"";
				colvarTamañoUteroPorECO.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTamañoUteroPorECO);
				
				TableSchema.TableColumn colvarDiametroLongitudinal = new TableSchema.TableColumn(schema);
				colvarDiametroLongitudinal.ColumnName = "DiametroLongitudinal";
				colvarDiametroLongitudinal.DataType = DbType.Boolean;
				colvarDiametroLongitudinal.MaxLength = 0;
				colvarDiametroLongitudinal.AutoIncrement = false;
				colvarDiametroLongitudinal.IsNullable = true;
				colvarDiametroLongitudinal.IsPrimaryKey = false;
				colvarDiametroLongitudinal.IsForeignKey = false;
				colvarDiametroLongitudinal.IsReadOnly = false;
				colvarDiametroLongitudinal.DefaultSetting = @"";
				colvarDiametroLongitudinal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiametroLongitudinal);
				
				TableSchema.TableColumn colvarAnalgesiaSolicitada = new TableSchema.TableColumn(schema);
				colvarAnalgesiaSolicitada.ColumnName = "AnalgesiaSolicitada";
				colvarAnalgesiaSolicitada.DataType = DbType.Boolean;
				colvarAnalgesiaSolicitada.MaxLength = 0;
				colvarAnalgesiaSolicitada.AutoIncrement = false;
				colvarAnalgesiaSolicitada.IsNullable = true;
				colvarAnalgesiaSolicitada.IsPrimaryKey = false;
				colvarAnalgesiaSolicitada.IsForeignKey = false;
				colvarAnalgesiaSolicitada.IsReadOnly = false;
				colvarAnalgesiaSolicitada.DefaultSetting = @"";
				colvarAnalgesiaSolicitada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnalgesiaSolicitada);
				
				TableSchema.TableColumn colvarAnalgesiaRealizada = new TableSchema.TableColumn(schema);
				colvarAnalgesiaRealizada.ColumnName = "AnalgesiaRealizada";
				colvarAnalgesiaRealizada.DataType = DbType.Boolean;
				colvarAnalgesiaRealizada.MaxLength = 0;
				colvarAnalgesiaRealizada.AutoIncrement = false;
				colvarAnalgesiaRealizada.IsNullable = true;
				colvarAnalgesiaRealizada.IsPrimaryKey = false;
				colvarAnalgesiaRealizada.IsForeignKey = false;
				colvarAnalgesiaRealizada.IsReadOnly = false;
				colvarAnalgesiaRealizada.DefaultSetting = @"";
				colvarAnalgesiaRealizada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnalgesiaRealizada);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_Aborto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAborto")]
		[Bindable(true)]
		public int IdAborto 
		{
			get { return GetColumnValue<int>(Columns.IdAborto); }
			set { SetColumnValue(Columns.IdAborto, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdEmbarazo")]
		[Bindable(true)]
		public int? IdEmbarazo 
		{
			get { return GetColumnValue<int?>(Columns.IdEmbarazo); }
			set { SetColumnValue(Columns.IdEmbarazo, value); }
		}
		  
		[XmlAttribute("FechaHora")]
		[Bindable(true)]
		public DateTime FechaHora 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHora); }
			set { SetColumnValue(Columns.FechaHora, value); }
		}
		  
		[XmlAttribute("HospitalizacionDias")]
		[Bindable(true)]
		public int? HospitalizacionDias 
		{
			get { return GetColumnValue<int?>(Columns.HospitalizacionDias); }
			set { SetColumnValue(Columns.HospitalizacionDias, value); }
		}
		  
		[XmlAttribute("IdAcompañante")]
		[Bindable(true)]
		public int? IdAcompañante 
		{
			get { return GetColumnValue<int?>(Columns.IdAcompañante); }
			set { SetColumnValue(Columns.IdAcompañante, value); }
		}
		  
		[XmlAttribute("Procedencia")]
		[Bindable(true)]
		public string Procedencia 
		{
			get { return GetColumnValue<string>(Columns.Procedencia); }
			set { SetColumnValue(Columns.Procedencia, value); }
		}
		  
		[XmlAttribute("IdTransporte")]
		[Bindable(true)]
		public int? IdTransporte 
		{
			get { return GetColumnValue<int?>(Columns.IdTransporte); }
			set { SetColumnValue(Columns.IdTransporte, value); }
		}
		  
		[XmlAttribute("TiempoTrasladoDias")]
		[Bindable(true)]
		public int? TiempoTrasladoDias 
		{
			get { return GetColumnValue<int?>(Columns.TiempoTrasladoDias); }
			set { SetColumnValue(Columns.TiempoTrasladoDias, value); }
		}
		  
		[XmlAttribute("TiempoTrasladoHoras")]
		[Bindable(true)]
		public int? TiempoTrasladoHoras 
		{
			get { return GetColumnValue<int?>(Columns.TiempoTrasladoHoras); }
			set { SetColumnValue(Columns.TiempoTrasladoHoras, value); }
		}
		  
		[XmlAttribute("TiempoTrasladoMinutos")]
		[Bindable(true)]
		public int? TiempoTrasladoMinutos 
		{
			get { return GetColumnValue<int?>(Columns.TiempoTrasladoMinutos); }
			set { SetColumnValue(Columns.TiempoTrasladoMinutos, value); }
		}
		  
		[XmlAttribute("Pulso")]
		[Bindable(true)]
		public int? Pulso 
		{
			get { return GetColumnValue<int?>(Columns.Pulso); }
			set { SetColumnValue(Columns.Pulso, value); }
		}
		  
		[XmlAttribute("PresionArterialMinima")]
		[Bindable(true)]
		public int? PresionArterialMinima 
		{
			get { return GetColumnValue<int?>(Columns.PresionArterialMinima); }
			set { SetColumnValue(Columns.PresionArterialMinima, value); }
		}
		  
		[XmlAttribute("PresionArterialMaxima")]
		[Bindable(true)]
		public int? PresionArterialMaxima 
		{
			get { return GetColumnValue<int?>(Columns.PresionArterialMaxima); }
			set { SetColumnValue(Columns.PresionArterialMaxima, value); }
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
		public int? Temperatura 
		{
			get { return GetColumnValue<int?>(Columns.Temperatura); }
			set { SetColumnValue(Columns.Temperatura, value); }
		}
		  
		[XmlAttribute("DiasDesdePrimerSintoma")]
		[Bindable(true)]
		public int? DiasDesdePrimerSintoma 
		{
			get { return GetColumnValue<int?>(Columns.DiasDesdePrimerSintoma); }
			set { SetColumnValue(Columns.DiasDesdePrimerSintoma, value); }
		}
		  
		[XmlAttribute("HorasDesdePrimerSintoma")]
		[Bindable(true)]
		public int? HorasDesdePrimerSintoma 
		{
			get { return GetColumnValue<int?>(Columns.HorasDesdePrimerSintoma); }
			set { SetColumnValue(Columns.HorasDesdePrimerSintoma, value); }
		}
		  
		[XmlAttribute("IdSangrado")]
		[Bindable(true)]
		public int? IdSangrado 
		{
			get { return GetColumnValue<int?>(Columns.IdSangrado); }
			set { SetColumnValue(Columns.IdSangrado, value); }
		}
		  
		[XmlAttribute("Dolor")]
		[Bindable(true)]
		public int? Dolor 
		{
			get { return GetColumnValue<int?>(Columns.Dolor); }
			set { SetColumnValue(Columns.Dolor, value); }
		}
		  
		[XmlAttribute("IdCondicionAlIngreso")]
		[Bindable(true)]
		public int? IdCondicionAlIngreso 
		{
			get { return GetColumnValue<int?>(Columns.IdCondicionAlIngreso); }
			set { SetColumnValue(Columns.IdCondicionAlIngreso, value); }
		}
		  
		[XmlAttribute("IdEstadoAbortoPresuntivo")]
		[Bindable(true)]
		public int? IdEstadoAbortoPresuntivo 
		{
			get { return GetColumnValue<int?>(Columns.IdEstadoAbortoPresuntivo); }
			set { SetColumnValue(Columns.IdEstadoAbortoPresuntivo, value); }
		}
		  
		[XmlAttribute("IdTipoAbortoPresuntivo")]
		[Bindable(true)]
		public int? IdTipoAbortoPresuntivo 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoAbortoPresuntivo); }
			set { SetColumnValue(Columns.IdTipoAbortoPresuntivo, value); }
		}
		  
		[XmlAttribute("DIAGCIE10")]
		[Bindable(true)]
		public int? DIAGCIE10 
		{
			get { return GetColumnValue<int?>(Columns.DIAGCIE10); }
			set { SetColumnValue(Columns.DIAGCIE10, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		  
		[XmlAttribute("IdExamenConciencia")]
		[Bindable(true)]
		public int? IdExamenConciencia 
		{
			get { return GetColumnValue<int?>(Columns.IdExamenConciencia); }
			set { SetColumnValue(Columns.IdExamenConciencia, value); }
		}
		  
		[XmlAttribute("IdExamenPielMucosa")]
		[Bindable(true)]
		public int? IdExamenPielMucosa 
		{
			get { return GetColumnValue<int?>(Columns.IdExamenPielMucosa); }
			set { SetColumnValue(Columns.IdExamenPielMucosa, value); }
		}
		  
		[XmlAttribute("IdExamenAbdomen")]
		[Bindable(true)]
		public int? IdExamenAbdomen 
		{
			get { return GetColumnValue<int?>(Columns.IdExamenAbdomen); }
			set { SetColumnValue(Columns.IdExamenAbdomen, value); }
		}
		  
		[XmlAttribute("TamañoUteroExamenBimanual")]
		[Bindable(true)]
		public int? TamañoUteroExamenBimanual 
		{
			get { return GetColumnValue<int?>(Columns.TamañoUteroExamenBimanual); }
			set { SetColumnValue(Columns.TamañoUteroExamenBimanual, value); }
		}
		  
		[XmlAttribute("IdPosicionUtero")]
		[Bindable(true)]
		public int? IdPosicionUtero 
		{
			get { return GetColumnValue<int?>(Columns.IdPosicionUtero); }
			set { SetColumnValue(Columns.IdPosicionUtero, value); }
		}
		  
		[XmlAttribute("CuelloCerrado")]
		[Bindable(true)]
		public bool? CuelloCerrado 
		{
			get { return GetColumnValue<bool?>(Columns.CuelloCerrado); }
			set { SetColumnValue(Columns.CuelloCerrado, value); }
		}
		  
		[XmlAttribute("Restos")]
		[Bindable(true)]
		public bool? Restos 
		{
			get { return GetColumnValue<bool?>(Columns.Restos); }
			set { SetColumnValue(Columns.Restos, value); }
		}
		  
		[XmlAttribute("VaginaNormal")]
		[Bindable(true)]
		public bool? VaginaNormal 
		{
			get { return GetColumnValue<bool?>(Columns.VaginaNormal); }
			set { SetColumnValue(Columns.VaginaNormal, value); }
		}
		  
		[XmlAttribute("TamañoUteroPorECO")]
		[Bindable(true)]
		public int? TamañoUteroPorECO 
		{
			get { return GetColumnValue<int?>(Columns.TamañoUteroPorECO); }
			set { SetColumnValue(Columns.TamañoUteroPorECO, value); }
		}
		  
		[XmlAttribute("DiametroLongitudinal")]
		[Bindable(true)]
		public bool? DiametroLongitudinal 
		{
			get { return GetColumnValue<bool?>(Columns.DiametroLongitudinal); }
			set { SetColumnValue(Columns.DiametroLongitudinal, value); }
		}
		  
		[XmlAttribute("AnalgesiaSolicitada")]
		[Bindable(true)]
		public bool? AnalgesiaSolicitada 
		{
			get { return GetColumnValue<bool?>(Columns.AnalgesiaSolicitada); }
			set { SetColumnValue(Columns.AnalgesiaSolicitada, value); }
		}
		  
		[XmlAttribute("AnalgesiaRealizada")]
		[Bindable(true)]
		public bool? AnalgesiaRealizada 
		{
			get { return GetColumnValue<bool?>(Columns.AnalgesiaRealizada); }
			set { SetColumnValue(Columns.AnalgesiaRealizada, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprEgresoPorAbortoCollection colAprEgresoPorAbortoRecords;
		public DalSic.AprEgresoPorAbortoCollection AprEgresoPorAbortoRecords
		{
			get
			{
				if(colAprEgresoPorAbortoRecords == null)
				{
					colAprEgresoPorAbortoRecords = new DalSic.AprEgresoPorAbortoCollection().Where(AprEgresoPorAborto.Columns.IdAborto, IdAborto).Load();
					colAprEgresoPorAbortoRecords.ListChanged += new ListChangedEventHandler(colAprEgresoPorAbortoRecords_ListChanged);
				}
				return colAprEgresoPorAbortoRecords;			
			}
			set 
			{ 
					colAprEgresoPorAbortoRecords = value; 
					colAprEgresoPorAbortoRecords.ListChanged += new ListChangedEventHandler(colAprEgresoPorAbortoRecords_ListChanged);
			}
		}
		
		void colAprEgresoPorAbortoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprEgresoPorAbortoRecords[e.NewIndex].IdAborto = IdAborto;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprAcompañante ActiveRecord object related to this AprAborto
		/// 
		/// </summary>
		public DalSic.AprAcompañante AprAcompañante
		{
			get { return DalSic.AprAcompañante.FetchByID(this.IdAcompañante); }
			set { SetColumnValue("idAcompañante", value.IdAcompañante); }
		}
		
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this AprAborto
		/// 
		/// </summary>
		public DalSic.SysCIE10 SysCIE10
		{
			get { return DalSic.SysCIE10.FetchByID(this.DIAGCIE10); }
			set { SetColumnValue("DIAGCIE10", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a AprCondicionIngreso ActiveRecord object related to this AprAborto
		/// 
		/// </summary>
		public DalSic.AprCondicionIngreso AprCondicionIngreso
		{
			get { return DalSic.AprCondicionIngreso.FetchByID(this.IdCondicionAlIngreso); }
			set { SetColumnValue("idCondicionAlIngreso", value.IdCondicionAlIngreso); }
		}
		
		
		/// <summary>
		/// Returns a AprEmbarazo ActiveRecord object related to this AprAborto
		/// 
		/// </summary>
		public DalSic.AprEmbarazo AprEmbarazo
		{
			get { return DalSic.AprEmbarazo.FetchByID(this.IdEmbarazo); }
			set { SetColumnValue("idEmbarazo", value.IdEmbarazo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int? varIdEmbarazo,DateTime varFechaHora,int? varHospitalizacionDias,int? varIdAcompañante,string varProcedencia,int? varIdTransporte,int? varTiempoTrasladoDias,int? varTiempoTrasladoHoras,int? varTiempoTrasladoMinutos,int? varPulso,int? varPresionArterialMinima,int? varPresionArterialMaxima,int? varFrecuenciaRespiratoria,int? varTemperatura,int? varDiasDesdePrimerSintoma,int? varHorasDesdePrimerSintoma,int? varIdSangrado,int? varDolor,int? varIdCondicionAlIngreso,int? varIdEstadoAbortoPresuntivo,int? varIdTipoAbortoPresuntivo,int? varDIAGCIE10,string varResponsable,int? varIdExamenConciencia,int? varIdExamenPielMucosa,int? varIdExamenAbdomen,int? varTamañoUteroExamenBimanual,int? varIdPosicionUtero,bool? varCuelloCerrado,bool? varRestos,bool? varVaginaNormal,int? varTamañoUteroPorECO,bool? varDiametroLongitudinal,bool? varAnalgesiaSolicitada,bool? varAnalgesiaRealizada)
		{
			AprAborto item = new AprAborto();
			
			item.IdEfector = varIdEfector;
			
			item.IdEmbarazo = varIdEmbarazo;
			
			item.FechaHora = varFechaHora;
			
			item.HospitalizacionDias = varHospitalizacionDias;
			
			item.IdAcompañante = varIdAcompañante;
			
			item.Procedencia = varProcedencia;
			
			item.IdTransporte = varIdTransporte;
			
			item.TiempoTrasladoDias = varTiempoTrasladoDias;
			
			item.TiempoTrasladoHoras = varTiempoTrasladoHoras;
			
			item.TiempoTrasladoMinutos = varTiempoTrasladoMinutos;
			
			item.Pulso = varPulso;
			
			item.PresionArterialMinima = varPresionArterialMinima;
			
			item.PresionArterialMaxima = varPresionArterialMaxima;
			
			item.FrecuenciaRespiratoria = varFrecuenciaRespiratoria;
			
			item.Temperatura = varTemperatura;
			
			item.DiasDesdePrimerSintoma = varDiasDesdePrimerSintoma;
			
			item.HorasDesdePrimerSintoma = varHorasDesdePrimerSintoma;
			
			item.IdSangrado = varIdSangrado;
			
			item.Dolor = varDolor;
			
			item.IdCondicionAlIngreso = varIdCondicionAlIngreso;
			
			item.IdEstadoAbortoPresuntivo = varIdEstadoAbortoPresuntivo;
			
			item.IdTipoAbortoPresuntivo = varIdTipoAbortoPresuntivo;
			
			item.DIAGCIE10 = varDIAGCIE10;
			
			item.Responsable = varResponsable;
			
			item.IdExamenConciencia = varIdExamenConciencia;
			
			item.IdExamenPielMucosa = varIdExamenPielMucosa;
			
			item.IdExamenAbdomen = varIdExamenAbdomen;
			
			item.TamañoUteroExamenBimanual = varTamañoUteroExamenBimanual;
			
			item.IdPosicionUtero = varIdPosicionUtero;
			
			item.CuelloCerrado = varCuelloCerrado;
			
			item.Restos = varRestos;
			
			item.VaginaNormal = varVaginaNormal;
			
			item.TamañoUteroPorECO = varTamañoUteroPorECO;
			
			item.DiametroLongitudinal = varDiametroLongitudinal;
			
			item.AnalgesiaSolicitada = varAnalgesiaSolicitada;
			
			item.AnalgesiaRealizada = varAnalgesiaRealizada;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAborto,int varIdEfector,int? varIdEmbarazo,DateTime varFechaHora,int? varHospitalizacionDias,int? varIdAcompañante,string varProcedencia,int? varIdTransporte,int? varTiempoTrasladoDias,int? varTiempoTrasladoHoras,int? varTiempoTrasladoMinutos,int? varPulso,int? varPresionArterialMinima,int? varPresionArterialMaxima,int? varFrecuenciaRespiratoria,int? varTemperatura,int? varDiasDesdePrimerSintoma,int? varHorasDesdePrimerSintoma,int? varIdSangrado,int? varDolor,int? varIdCondicionAlIngreso,int? varIdEstadoAbortoPresuntivo,int? varIdTipoAbortoPresuntivo,int? varDIAGCIE10,string varResponsable,int? varIdExamenConciencia,int? varIdExamenPielMucosa,int? varIdExamenAbdomen,int? varTamañoUteroExamenBimanual,int? varIdPosicionUtero,bool? varCuelloCerrado,bool? varRestos,bool? varVaginaNormal,int? varTamañoUteroPorECO,bool? varDiametroLongitudinal,bool? varAnalgesiaSolicitada,bool? varAnalgesiaRealizada)
		{
			AprAborto item = new AprAborto();
			
				item.IdAborto = varIdAborto;
			
				item.IdEfector = varIdEfector;
			
				item.IdEmbarazo = varIdEmbarazo;
			
				item.FechaHora = varFechaHora;
			
				item.HospitalizacionDias = varHospitalizacionDias;
			
				item.IdAcompañante = varIdAcompañante;
			
				item.Procedencia = varProcedencia;
			
				item.IdTransporte = varIdTransporte;
			
				item.TiempoTrasladoDias = varTiempoTrasladoDias;
			
				item.TiempoTrasladoHoras = varTiempoTrasladoHoras;
			
				item.TiempoTrasladoMinutos = varTiempoTrasladoMinutos;
			
				item.Pulso = varPulso;
			
				item.PresionArterialMinima = varPresionArterialMinima;
			
				item.PresionArterialMaxima = varPresionArterialMaxima;
			
				item.FrecuenciaRespiratoria = varFrecuenciaRespiratoria;
			
				item.Temperatura = varTemperatura;
			
				item.DiasDesdePrimerSintoma = varDiasDesdePrimerSintoma;
			
				item.HorasDesdePrimerSintoma = varHorasDesdePrimerSintoma;
			
				item.IdSangrado = varIdSangrado;
			
				item.Dolor = varDolor;
			
				item.IdCondicionAlIngreso = varIdCondicionAlIngreso;
			
				item.IdEstadoAbortoPresuntivo = varIdEstadoAbortoPresuntivo;
			
				item.IdTipoAbortoPresuntivo = varIdTipoAbortoPresuntivo;
			
				item.DIAGCIE10 = varDIAGCIE10;
			
				item.Responsable = varResponsable;
			
				item.IdExamenConciencia = varIdExamenConciencia;
			
				item.IdExamenPielMucosa = varIdExamenPielMucosa;
			
				item.IdExamenAbdomen = varIdExamenAbdomen;
			
				item.TamañoUteroExamenBimanual = varTamañoUteroExamenBimanual;
			
				item.IdPosicionUtero = varIdPosicionUtero;
			
				item.CuelloCerrado = varCuelloCerrado;
			
				item.Restos = varRestos;
			
				item.VaginaNormal = varVaginaNormal;
			
				item.TamañoUteroPorECO = varTamañoUteroPorECO;
			
				item.DiametroLongitudinal = varDiametroLongitudinal;
			
				item.AnalgesiaSolicitada = varAnalgesiaSolicitada;
			
				item.AnalgesiaRealizada = varAnalgesiaRealizada;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAbortoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEmbarazoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHoraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn HospitalizacionDiasColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAcompañanteColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ProcedenciaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTransporteColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoTrasladoDiasColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoTrasladoHorasColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoTrasladoMinutosColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn PulsoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn PresionArterialMinimaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PresionArterialMaximaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FrecuenciaRespiratoriaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn TemperaturaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasDesdePrimerSintomaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn HorasDesdePrimerSintomaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSangradoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn DolorColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCondicionAlIngresoColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoAbortoPresuntivoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoAbortoPresuntivoColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn DIAGCIE10Column
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExamenConcienciaColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExamenPielMucosaColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExamenAbdomenColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn TamañoUteroExamenBimanualColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPosicionUteroColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn CuelloCerradoColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn RestosColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn VaginaNormalColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn TamañoUteroPorECOColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn DiametroLongitudinalColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn AnalgesiaSolicitadaColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn AnalgesiaRealizadaColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAborto = @"idAborto";
			 public static string IdEfector = @"idEfector";
			 public static string IdEmbarazo = @"idEmbarazo";
			 public static string FechaHora = @"FechaHora";
			 public static string HospitalizacionDias = @"HospitalizacionDias";
			 public static string IdAcompañante = @"idAcompañante";
			 public static string Procedencia = @"Procedencia";
			 public static string IdTransporte = @"idTransporte";
			 public static string TiempoTrasladoDias = @"TiempoTrasladoDias";
			 public static string TiempoTrasladoHoras = @"TiempoTrasladoHoras";
			 public static string TiempoTrasladoMinutos = @"TiempoTrasladoMinutos";
			 public static string Pulso = @"Pulso";
			 public static string PresionArterialMinima = @"PresionArterialMinima";
			 public static string PresionArterialMaxima = @"PresionArterialMaxima";
			 public static string FrecuenciaRespiratoria = @"FrecuenciaRespiratoria";
			 public static string Temperatura = @"Temperatura";
			 public static string DiasDesdePrimerSintoma = @"DiasDesdePrimerSintoma";
			 public static string HorasDesdePrimerSintoma = @"HorasDesdePrimerSintoma";
			 public static string IdSangrado = @"idSangrado";
			 public static string Dolor = @"Dolor";
			 public static string IdCondicionAlIngreso = @"idCondicionAlIngreso";
			 public static string IdEstadoAbortoPresuntivo = @"idEstadoAbortoPresuntivo";
			 public static string IdTipoAbortoPresuntivo = @"idTipoAbortoPresuntivo";
			 public static string DIAGCIE10 = @"DIAGCIE10";
			 public static string Responsable = @"Responsable";
			 public static string IdExamenConciencia = @"idExamenConciencia";
			 public static string IdExamenPielMucosa = @"idExamenPielMucosa";
			 public static string IdExamenAbdomen = @"idExamenAbdomen";
			 public static string TamañoUteroExamenBimanual = @"TamañoUteroExamenBimanual";
			 public static string IdPosicionUtero = @"idPosicionUtero";
			 public static string CuelloCerrado = @"CuelloCerrado";
			 public static string Restos = @"Restos";
			 public static string VaginaNormal = @"VaginaNormal";
			 public static string TamañoUteroPorECO = @"TamañoUteroPorECO";
			 public static string DiametroLongitudinal = @"DiametroLongitudinal";
			 public static string AnalgesiaSolicitada = @"AnalgesiaSolicitada";
			 public static string AnalgesiaRealizada = @"AnalgesiaRealizada";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprEgresoPorAbortoRecords != null)
                {
                    foreach (DalSic.AprEgresoPorAborto item in colAprEgresoPorAbortoRecords)
                    {
                        if (item.IdAborto != IdAborto)
                        {
                            item.IdAborto = IdAborto;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprEgresoPorAbortoRecords != null)
                {
                    colAprEgresoPorAbortoRecords.SaveAll();
               }
		}
        #endregion
	}
}
