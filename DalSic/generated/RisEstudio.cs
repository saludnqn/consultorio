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
	/// Strongly-typed collection for the RisEstudio class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioCollection : ActiveList<RisEstudio, RisEstudioCollection>
	{	   
		public RisEstudioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioCollection</returns>
		public RisEstudioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudio o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_Estudio table.
	/// </summary>
	[Serializable]
	public partial class RisEstudio : ActiveRecord<RisEstudio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_Estudio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = true;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = true;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarTipoEstudio = new TableSchema.TableColumn(schema);
				colvarTipoEstudio.ColumnName = "tipoEstudio";
				colvarTipoEstudio.DataType = DbType.AnsiString;
				colvarTipoEstudio.MaxLength = 100;
				colvarTipoEstudio.AutoIncrement = false;
				colvarTipoEstudio.IsNullable = false;
				colvarTipoEstudio.IsPrimaryKey = false;
				colvarTipoEstudio.IsForeignKey = false;
				colvarTipoEstudio.IsReadOnly = false;
				colvarTipoEstudio.DefaultSetting = @"";
				colvarTipoEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoEstudio);
				
				TableSchema.TableColumn colvarNroOrden = new TableSchema.TableColumn(schema);
				colvarNroOrden.ColumnName = "nroOrden";
				colvarNroOrden.DataType = DbType.AnsiString;
				colvarNroOrden.MaxLength = 10;
				colvarNroOrden.AutoIncrement = false;
				colvarNroOrden.IsNullable = true;
				colvarNroOrden.IsPrimaryKey = false;
				colvarNroOrden.IsForeignKey = false;
				colvarNroOrden.IsReadOnly = false;
				colvarNroOrden.DefaultSetting = @"";
				colvarNroOrden.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroOrden);
				
				TableSchema.TableColumn colvarEnmienda = new TableSchema.TableColumn(schema);
				colvarEnmienda.ColumnName = "enmienda";
				colvarEnmienda.DataType = DbType.AnsiString;
				colvarEnmienda.MaxLength = 10;
				colvarEnmienda.AutoIncrement = false;
				colvarEnmienda.IsNullable = true;
				colvarEnmienda.IsPrimaryKey = false;
				colvarEnmienda.IsForeignKey = false;
				colvarEnmienda.IsReadOnly = false;
				colvarEnmienda.DefaultSetting = @"";
				colvarEnmienda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnmienda);
				
				TableSchema.TableColumn colvarAnio = new TableSchema.TableColumn(schema);
				colvarAnio.ColumnName = "anio";
				colvarAnio.DataType = DbType.AnsiString;
				colvarAnio.MaxLength = 10;
				colvarAnio.AutoIncrement = false;
				colvarAnio.IsNullable = true;
				colvarAnio.IsPrimaryKey = false;
				colvarAnio.IsForeignKey = false;
				colvarAnio.IsReadOnly = false;
				colvarAnio.DefaultSetting = @"";
				colvarAnio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnio);
				
				TableSchema.TableColumn colvarTituloInvestigacion = new TableSchema.TableColumn(schema);
				colvarTituloInvestigacion.ColumnName = "tituloInvestigacion";
				colvarTituloInvestigacion.DataType = DbType.AnsiString;
				colvarTituloInvestigacion.MaxLength = 2000;
				colvarTituloInvestigacion.AutoIncrement = false;
				colvarTituloInvestigacion.IsNullable = true;
				colvarTituloInvestigacion.IsPrimaryKey = false;
				colvarTituloInvestigacion.IsForeignKey = false;
				colvarTituloInvestigacion.IsReadOnly = false;
				colvarTituloInvestigacion.DefaultSetting = @"";
				colvarTituloInvestigacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTituloInvestigacion);
				
				TableSchema.TableColumn colvarNroRegistroNacional = new TableSchema.TableColumn(schema);
				colvarNroRegistroNacional.ColumnName = "nroRegistroNacional";
				colvarNroRegistroNacional.DataType = DbType.AnsiString;
				colvarNroRegistroNacional.MaxLength = 100;
				colvarNroRegistroNacional.AutoIncrement = false;
				colvarNroRegistroNacional.IsNullable = true;
				colvarNroRegistroNacional.IsPrimaryKey = false;
				colvarNroRegistroNacional.IsForeignKey = false;
				colvarNroRegistroNacional.IsReadOnly = false;
				colvarNroRegistroNacional.DefaultSetting = @"";
				colvarNroRegistroNacional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroRegistroNacional);
				
				TableSchema.TableColumn colvarNroExpediente = new TableSchema.TableColumn(schema);
				colvarNroExpediente.ColumnName = "nroExpediente";
				colvarNroExpediente.DataType = DbType.AnsiString;
				colvarNroExpediente.MaxLength = 100;
				colvarNroExpediente.AutoIncrement = false;
				colvarNroExpediente.IsNullable = true;
				colvarNroExpediente.IsPrimaryKey = false;
				colvarNroExpediente.IsForeignKey = false;
				colvarNroExpediente.IsReadOnly = false;
				colvarNroExpediente.DefaultSetting = @"";
				colvarNroExpediente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroExpediente);
				
				TableSchema.TableColumn colvarNombreAbreviado = new TableSchema.TableColumn(schema);
				colvarNombreAbreviado.ColumnName = "nombreAbreviado";
				colvarNombreAbreviado.DataType = DbType.AnsiString;
				colvarNombreAbreviado.MaxLength = 100;
				colvarNombreAbreviado.AutoIncrement = false;
				colvarNombreAbreviado.IsNullable = true;
				colvarNombreAbreviado.IsPrimaryKey = false;
				colvarNombreAbreviado.IsForeignKey = false;
				colvarNombreAbreviado.IsReadOnly = false;
				colvarNombreAbreviado.DefaultSetting = @"";
				colvarNombreAbreviado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreAbreviado);
				
				TableSchema.TableColumn colvarDrogas = new TableSchema.TableColumn(schema);
				colvarDrogas.ColumnName = "drogas";
				colvarDrogas.DataType = DbType.AnsiString;
				colvarDrogas.MaxLength = 100;
				colvarDrogas.AutoIncrement = false;
				colvarDrogas.IsNullable = true;
				colvarDrogas.IsPrimaryKey = false;
				colvarDrogas.IsForeignKey = false;
				colvarDrogas.IsReadOnly = false;
				colvarDrogas.DefaultSetting = @"";
				colvarDrogas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas);
				
				TableSchema.TableColumn colvarPalabrasClave = new TableSchema.TableColumn(schema);
				colvarPalabrasClave.ColumnName = "palabrasClave";
				colvarPalabrasClave.DataType = DbType.AnsiString;
				colvarPalabrasClave.MaxLength = 100;
				colvarPalabrasClave.AutoIncrement = false;
				colvarPalabrasClave.IsNullable = true;
				colvarPalabrasClave.IsPrimaryKey = false;
				colvarPalabrasClave.IsForeignKey = false;
				colvarPalabrasClave.IsReadOnly = false;
				colvarPalabrasClave.DefaultSetting = @"";
				colvarPalabrasClave.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPalabrasClave);
				
				TableSchema.TableColumn colvarNombreIntitucionAfiliacion = new TableSchema.TableColumn(schema);
				colvarNombreIntitucionAfiliacion.ColumnName = "nombreIntitucionAfiliacion";
				colvarNombreIntitucionAfiliacion.DataType = DbType.AnsiString;
				colvarNombreIntitucionAfiliacion.MaxLength = 100;
				colvarNombreIntitucionAfiliacion.AutoIncrement = false;
				colvarNombreIntitucionAfiliacion.IsNullable = true;
				colvarNombreIntitucionAfiliacion.IsPrimaryKey = false;
				colvarNombreIntitucionAfiliacion.IsForeignKey = false;
				colvarNombreIntitucionAfiliacion.IsReadOnly = false;
				colvarNombreIntitucionAfiliacion.DefaultSetting = @"";
				colvarNombreIntitucionAfiliacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreIntitucionAfiliacion);
				
				TableSchema.TableColumn colvarReferenteInstitucionAfiliacion = new TableSchema.TableColumn(schema);
				colvarReferenteInstitucionAfiliacion.ColumnName = "referenteInstitucionAfiliacion";
				colvarReferenteInstitucionAfiliacion.DataType = DbType.AnsiString;
				colvarReferenteInstitucionAfiliacion.MaxLength = 100;
				colvarReferenteInstitucionAfiliacion.AutoIncrement = false;
				colvarReferenteInstitucionAfiliacion.IsNullable = true;
				colvarReferenteInstitucionAfiliacion.IsPrimaryKey = false;
				colvarReferenteInstitucionAfiliacion.IsForeignKey = false;
				colvarReferenteInstitucionAfiliacion.IsReadOnly = false;
				colvarReferenteInstitucionAfiliacion.DefaultSetting = @"";
				colvarReferenteInstitucionAfiliacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferenteInstitucionAfiliacion);
				
				TableSchema.TableColumn colvarTelefonoInstitucionAfiliacion = new TableSchema.TableColumn(schema);
				colvarTelefonoInstitucionAfiliacion.ColumnName = "telefonoInstitucionAfiliacion";
				colvarTelefonoInstitucionAfiliacion.DataType = DbType.AnsiString;
				colvarTelefonoInstitucionAfiliacion.MaxLength = 100;
				colvarTelefonoInstitucionAfiliacion.AutoIncrement = false;
				colvarTelefonoInstitucionAfiliacion.IsNullable = true;
				colvarTelefonoInstitucionAfiliacion.IsPrimaryKey = false;
				colvarTelefonoInstitucionAfiliacion.IsForeignKey = false;
				colvarTelefonoInstitucionAfiliacion.IsReadOnly = false;
				colvarTelefonoInstitucionAfiliacion.DefaultSetting = @"";
				colvarTelefonoInstitucionAfiliacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefonoInstitucionAfiliacion);
				
				TableSchema.TableColumn colvarDomicilioInstitucionAfiliacion = new TableSchema.TableColumn(schema);
				colvarDomicilioInstitucionAfiliacion.ColumnName = "domicilioInstitucionAfiliacion";
				colvarDomicilioInstitucionAfiliacion.DataType = DbType.AnsiString;
				colvarDomicilioInstitucionAfiliacion.MaxLength = 100;
				colvarDomicilioInstitucionAfiliacion.AutoIncrement = false;
				colvarDomicilioInstitucionAfiliacion.IsNullable = true;
				colvarDomicilioInstitucionAfiliacion.IsPrimaryKey = false;
				colvarDomicilioInstitucionAfiliacion.IsForeignKey = false;
				colvarDomicilioInstitucionAfiliacion.IsReadOnly = false;
				colvarDomicilioInstitucionAfiliacion.DefaultSetting = @"";
				colvarDomicilioInstitucionAfiliacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilioInstitucionAfiliacion);
				
				TableSchema.TableColumn colvarCpDomicilioInstitucionAfiliacion = new TableSchema.TableColumn(schema);
				colvarCpDomicilioInstitucionAfiliacion.ColumnName = "cpDomicilioInstitucionAfiliacion";
				colvarCpDomicilioInstitucionAfiliacion.DataType = DbType.AnsiString;
				colvarCpDomicilioInstitucionAfiliacion.MaxLength = 100;
				colvarCpDomicilioInstitucionAfiliacion.AutoIncrement = false;
				colvarCpDomicilioInstitucionAfiliacion.IsNullable = true;
				colvarCpDomicilioInstitucionAfiliacion.IsPrimaryKey = false;
				colvarCpDomicilioInstitucionAfiliacion.IsForeignKey = false;
				colvarCpDomicilioInstitucionAfiliacion.IsReadOnly = false;
				colvarCpDomicilioInstitucionAfiliacion.DefaultSetting = @"";
				colvarCpDomicilioInstitucionAfiliacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCpDomicilioInstitucionAfiliacion);
				
				TableSchema.TableColumn colvarEmailInstitucionAfiliacion = new TableSchema.TableColumn(schema);
				colvarEmailInstitucionAfiliacion.ColumnName = "emailInstitucionAfiliacion";
				colvarEmailInstitucionAfiliacion.DataType = DbType.AnsiString;
				colvarEmailInstitucionAfiliacion.MaxLength = 100;
				colvarEmailInstitucionAfiliacion.AutoIncrement = false;
				colvarEmailInstitucionAfiliacion.IsNullable = true;
				colvarEmailInstitucionAfiliacion.IsPrimaryKey = false;
				colvarEmailInstitucionAfiliacion.IsForeignKey = false;
				colvarEmailInstitucionAfiliacion.IsReadOnly = false;
				colvarEmailInstitucionAfiliacion.DefaultSetting = @"";
				colvarEmailInstitucionAfiliacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmailInstitucionAfiliacion);
				
				TableSchema.TableColumn colvarIdAreaTematica = new TableSchema.TableColumn(schema);
				colvarIdAreaTematica.ColumnName = "idAreaTematica";
				colvarIdAreaTematica.DataType = DbType.Int32;
				colvarIdAreaTematica.MaxLength = 0;
				colvarIdAreaTematica.AutoIncrement = false;
				colvarIdAreaTematica.IsNullable = false;
				colvarIdAreaTematica.IsPrimaryKey = false;
				colvarIdAreaTematica.IsForeignKey = false;
				colvarIdAreaTematica.IsReadOnly = false;
				colvarIdAreaTematica.DefaultSetting = @"";
				colvarIdAreaTematica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAreaTematica);
				
				TableSchema.TableColumn colvarIdFuenteRecoleccionDatos = new TableSchema.TableColumn(schema);
				colvarIdFuenteRecoleccionDatos.ColumnName = "idFuenteRecoleccionDatos";
				colvarIdFuenteRecoleccionDatos.DataType = DbType.Int32;
				colvarIdFuenteRecoleccionDatos.MaxLength = 0;
				colvarIdFuenteRecoleccionDatos.AutoIncrement = false;
				colvarIdFuenteRecoleccionDatos.IsNullable = true;
				colvarIdFuenteRecoleccionDatos.IsPrimaryKey = false;
				colvarIdFuenteRecoleccionDatos.IsForeignKey = false;
				colvarIdFuenteRecoleccionDatos.IsReadOnly = false;
				colvarIdFuenteRecoleccionDatos.DefaultSetting = @"";
				colvarIdFuenteRecoleccionDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFuenteRecoleccionDatos);
				
				TableSchema.TableColumn colvarTienePoblacionVulnerable = new TableSchema.TableColumn(schema);
				colvarTienePoblacionVulnerable.ColumnName = "tienePoblacionVulnerable";
				colvarTienePoblacionVulnerable.DataType = DbType.AnsiString;
				colvarTienePoblacionVulnerable.MaxLength = 100;
				colvarTienePoblacionVulnerable.AutoIncrement = false;
				colvarTienePoblacionVulnerable.IsNullable = true;
				colvarTienePoblacionVulnerable.IsPrimaryKey = false;
				colvarTienePoblacionVulnerable.IsForeignKey = false;
				colvarTienePoblacionVulnerable.IsReadOnly = false;
				colvarTienePoblacionVulnerable.DefaultSetting = @"";
				colvarTienePoblacionVulnerable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTienePoblacionVulnerable);
				
				TableSchema.TableColumn colvarTamanioMuestra = new TableSchema.TableColumn(schema);
				colvarTamanioMuestra.ColumnName = "tamanioMuestra";
				colvarTamanioMuestra.DataType = DbType.Int32;
				colvarTamanioMuestra.MaxLength = 0;
				colvarTamanioMuestra.AutoIncrement = false;
				colvarTamanioMuestra.IsNullable = true;
				colvarTamanioMuestra.IsPrimaryKey = false;
				colvarTamanioMuestra.IsForeignKey = false;
				colvarTamanioMuestra.IsReadOnly = false;
				colvarTamanioMuestra.DefaultSetting = @"";
				colvarTamanioMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTamanioMuestra);
				
				TableSchema.TableColumn colvarMulticentrico = new TableSchema.TableColumn(schema);
				colvarMulticentrico.ColumnName = "multicentrico";
				colvarMulticentrico.DataType = DbType.AnsiString;
				colvarMulticentrico.MaxLength = 50;
				colvarMulticentrico.AutoIncrement = false;
				colvarMulticentrico.IsNullable = true;
				colvarMulticentrico.IsPrimaryKey = false;
				colvarMulticentrico.IsForeignKey = false;
				colvarMulticentrico.IsReadOnly = false;
				colvarMulticentrico.DefaultSetting = @"";
				colvarMulticentrico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMulticentrico);
				
				TableSchema.TableColumn colvarTiempoEstimadoAnios = new TableSchema.TableColumn(schema);
				colvarTiempoEstimadoAnios.ColumnName = "tiempoEstimadoAnios";
				colvarTiempoEstimadoAnios.DataType = DbType.Int32;
				colvarTiempoEstimadoAnios.MaxLength = 0;
				colvarTiempoEstimadoAnios.AutoIncrement = false;
				colvarTiempoEstimadoAnios.IsNullable = true;
				colvarTiempoEstimadoAnios.IsPrimaryKey = false;
				colvarTiempoEstimadoAnios.IsForeignKey = false;
				colvarTiempoEstimadoAnios.IsReadOnly = false;
				colvarTiempoEstimadoAnios.DefaultSetting = @"";
				colvarTiempoEstimadoAnios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoEstimadoAnios);
				
				TableSchema.TableColumn colvarTiempoEstimadoMeses = new TableSchema.TableColumn(schema);
				colvarTiempoEstimadoMeses.ColumnName = "tiempoEstimadoMeses";
				colvarTiempoEstimadoMeses.DataType = DbType.Int32;
				colvarTiempoEstimadoMeses.MaxLength = 0;
				colvarTiempoEstimadoMeses.AutoIncrement = false;
				colvarTiempoEstimadoMeses.IsNullable = true;
				colvarTiempoEstimadoMeses.IsPrimaryKey = false;
				colvarTiempoEstimadoMeses.IsForeignKey = false;
				colvarTiempoEstimadoMeses.IsReadOnly = false;
				colvarTiempoEstimadoMeses.DefaultSetting = @"";
				colvarTiempoEstimadoMeses.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoEstimadoMeses);
				
				TableSchema.TableColumn colvarFechaIncorporacionPrimerParticipante = new TableSchema.TableColumn(schema);
				colvarFechaIncorporacionPrimerParticipante.ColumnName = "fechaIncorporacionPrimerParticipante";
				colvarFechaIncorporacionPrimerParticipante.DataType = DbType.DateTime;
				colvarFechaIncorporacionPrimerParticipante.MaxLength = 0;
				colvarFechaIncorporacionPrimerParticipante.AutoIncrement = false;
				colvarFechaIncorporacionPrimerParticipante.IsNullable = true;
				colvarFechaIncorporacionPrimerParticipante.IsPrimaryKey = false;
				colvarFechaIncorporacionPrimerParticipante.IsForeignKey = false;
				colvarFechaIncorporacionPrimerParticipante.IsReadOnly = false;
				colvarFechaIncorporacionPrimerParticipante.DefaultSetting = @"";
				colvarFechaIncorporacionPrimerParticipante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaIncorporacionPrimerParticipante);
				
				TableSchema.TableColumn colvarFechaCierreIncorporacionParticipantes = new TableSchema.TableColumn(schema);
				colvarFechaCierreIncorporacionParticipantes.ColumnName = "fechaCierreIncorporacionParticipantes";
				colvarFechaCierreIncorporacionParticipantes.DataType = DbType.DateTime;
				colvarFechaCierreIncorporacionParticipantes.MaxLength = 0;
				colvarFechaCierreIncorporacionParticipantes.AutoIncrement = false;
				colvarFechaCierreIncorporacionParticipantes.IsNullable = true;
				colvarFechaCierreIncorporacionParticipantes.IsPrimaryKey = false;
				colvarFechaCierreIncorporacionParticipantes.IsForeignKey = false;
				colvarFechaCierreIncorporacionParticipantes.IsReadOnly = false;
				colvarFechaCierreIncorporacionParticipantes.DefaultSetting = @"";
				colvarFechaCierreIncorporacionParticipantes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCierreIncorporacionParticipantes);
				
				TableSchema.TableColumn colvarIdCaractaristica = new TableSchema.TableColumn(schema);
				colvarIdCaractaristica.ColumnName = "idCaractaristica";
				colvarIdCaractaristica.DataType = DbType.Int32;
				colvarIdCaractaristica.MaxLength = 0;
				colvarIdCaractaristica.AutoIncrement = false;
				colvarIdCaractaristica.IsNullable = true;
				colvarIdCaractaristica.IsPrimaryKey = false;
				colvarIdCaractaristica.IsForeignKey = false;
				colvarIdCaractaristica.IsReadOnly = false;
				colvarIdCaractaristica.DefaultSetting = @"";
				colvarIdCaractaristica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCaractaristica);
				
				TableSchema.TableColumn colvarFechaCierreSitio = new TableSchema.TableColumn(schema);
				colvarFechaCierreSitio.ColumnName = "fechaCierreSitio";
				colvarFechaCierreSitio.DataType = DbType.DateTime;
				colvarFechaCierreSitio.MaxLength = 0;
				colvarFechaCierreSitio.AutoIncrement = false;
				colvarFechaCierreSitio.IsNullable = true;
				colvarFechaCierreSitio.IsPrimaryKey = false;
				colvarFechaCierreSitio.IsForeignKey = false;
				colvarFechaCierreSitio.IsReadOnly = false;
				colvarFechaCierreSitio.DefaultSetting = @"";
				colvarFechaCierreSitio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCierreSitio);
				
				TableSchema.TableColumn colvarOtrosCaractEstudios = new TableSchema.TableColumn(schema);
				colvarOtrosCaractEstudios.ColumnName = "otrosCaractEstudios";
				colvarOtrosCaractEstudios.DataType = DbType.AnsiString;
				colvarOtrosCaractEstudios.MaxLength = 1000;
				colvarOtrosCaractEstudios.AutoIncrement = false;
				colvarOtrosCaractEstudios.IsNullable = true;
				colvarOtrosCaractEstudios.IsPrimaryKey = false;
				colvarOtrosCaractEstudios.IsForeignKey = false;
				colvarOtrosCaractEstudios.IsReadOnly = false;
				colvarOtrosCaractEstudios.DefaultSetting = @"";
				colvarOtrosCaractEstudios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrosCaractEstudios);
				
				TableSchema.TableColumn colvarFechaAprobadoCAIBSH = new TableSchema.TableColumn(schema);
				colvarFechaAprobadoCAIBSH.ColumnName = "fechaAprobadoCAIBSH";
				colvarFechaAprobadoCAIBSH.DataType = DbType.DateTime;
				colvarFechaAprobadoCAIBSH.MaxLength = 0;
				colvarFechaAprobadoCAIBSH.AutoIncrement = false;
				colvarFechaAprobadoCAIBSH.IsNullable = true;
				colvarFechaAprobadoCAIBSH.IsPrimaryKey = false;
				colvarFechaAprobadoCAIBSH.IsForeignKey = false;
				colvarFechaAprobadoCAIBSH.IsReadOnly = false;
				colvarFechaAprobadoCAIBSH.DefaultSetting = @"";
				colvarFechaAprobadoCAIBSH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAprobadoCAIBSH);
				
				TableSchema.TableColumn colvarFechaRechazadoCAIBSH = new TableSchema.TableColumn(schema);
				colvarFechaRechazadoCAIBSH.ColumnName = "fechaRechazadoCAIBSH";
				colvarFechaRechazadoCAIBSH.DataType = DbType.DateTime;
				colvarFechaRechazadoCAIBSH.MaxLength = 0;
				colvarFechaRechazadoCAIBSH.AutoIncrement = false;
				colvarFechaRechazadoCAIBSH.IsNullable = true;
				colvarFechaRechazadoCAIBSH.IsPrimaryKey = false;
				colvarFechaRechazadoCAIBSH.IsForeignKey = false;
				colvarFechaRechazadoCAIBSH.IsReadOnly = false;
				colvarFechaRechazadoCAIBSH.DefaultSetting = @"";
				colvarFechaRechazadoCAIBSH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRechazadoCAIBSH);
				
				TableSchema.TableColumn colvarObservacionesCAIBSH = new TableSchema.TableColumn(schema);
				colvarObservacionesCAIBSH.ColumnName = "observacionesCAIBSH";
				colvarObservacionesCAIBSH.DataType = DbType.AnsiString;
				colvarObservacionesCAIBSH.MaxLength = 8000;
				colvarObservacionesCAIBSH.AutoIncrement = false;
				colvarObservacionesCAIBSH.IsNullable = true;
				colvarObservacionesCAIBSH.IsPrimaryKey = false;
				colvarObservacionesCAIBSH.IsForeignKey = false;
				colvarObservacionesCAIBSH.IsReadOnly = false;
				colvarObservacionesCAIBSH.DefaultSetting = @"";
				colvarObservacionesCAIBSH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionesCAIBSH);
				
				TableSchema.TableColumn colvarFechaInicio = new TableSchema.TableColumn(schema);
				colvarFechaInicio.ColumnName = "fechaInicio";
				colvarFechaInicio.DataType = DbType.DateTime;
				colvarFechaInicio.MaxLength = 0;
				colvarFechaInicio.AutoIncrement = false;
				colvarFechaInicio.IsNullable = true;
				colvarFechaInicio.IsPrimaryKey = false;
				colvarFechaInicio.IsForeignKey = false;
				colvarFechaInicio.IsReadOnly = false;
				colvarFechaInicio.DefaultSetting = @"";
				colvarFechaInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInicio);
				
				TableSchema.TableColumn colvarFechaFinalizacion = new TableSchema.TableColumn(schema);
				colvarFechaFinalizacion.ColumnName = "fechaFinalizacion";
				colvarFechaFinalizacion.DataType = DbType.DateTime;
				colvarFechaFinalizacion.MaxLength = 0;
				colvarFechaFinalizacion.AutoIncrement = false;
				colvarFechaFinalizacion.IsNullable = true;
				colvarFechaFinalizacion.IsPrimaryKey = false;
				colvarFechaFinalizacion.IsForeignKey = false;
				colvarFechaFinalizacion.IsReadOnly = false;
				colvarFechaFinalizacion.DefaultSetting = @"";
				colvarFechaFinalizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFinalizacion);
				
				TableSchema.TableColumn colvarFechaPresentacionInformeFinal = new TableSchema.TableColumn(schema);
				colvarFechaPresentacionInformeFinal.ColumnName = "fechaPresentacionInformeFinal";
				colvarFechaPresentacionInformeFinal.DataType = DbType.DateTime;
				colvarFechaPresentacionInformeFinal.MaxLength = 0;
				colvarFechaPresentacionInformeFinal.AutoIncrement = false;
				colvarFechaPresentacionInformeFinal.IsNullable = true;
				colvarFechaPresentacionInformeFinal.IsPrimaryKey = false;
				colvarFechaPresentacionInformeFinal.IsForeignKey = false;
				colvarFechaPresentacionInformeFinal.IsReadOnly = false;
				colvarFechaPresentacionInformeFinal.DefaultSetting = @"";
				colvarFechaPresentacionInformeFinal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPresentacionInformeFinal);
				
				TableSchema.TableColumn colvarFechaVencimientoPlazoCAIBSH = new TableSchema.TableColumn(schema);
				colvarFechaVencimientoPlazoCAIBSH.ColumnName = "fechaVencimientoPlazoCAIBSH";
				colvarFechaVencimientoPlazoCAIBSH.DataType = DbType.DateTime;
				colvarFechaVencimientoPlazoCAIBSH.MaxLength = 0;
				colvarFechaVencimientoPlazoCAIBSH.AutoIncrement = false;
				colvarFechaVencimientoPlazoCAIBSH.IsNullable = true;
				colvarFechaVencimientoPlazoCAIBSH.IsPrimaryKey = false;
				colvarFechaVencimientoPlazoCAIBSH.IsForeignKey = false;
				colvarFechaVencimientoPlazoCAIBSH.IsReadOnly = false;
				colvarFechaVencimientoPlazoCAIBSH.DefaultSetting = @"";
				colvarFechaVencimientoPlazoCAIBSH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaVencimientoPlazoCAIBSH);
				
				TableSchema.TableColumn colvarFechaRetiroEvaluacionCAIBSH = new TableSchema.TableColumn(schema);
				colvarFechaRetiroEvaluacionCAIBSH.ColumnName = "fechaRetiroEvaluacionCAIBSH";
				colvarFechaRetiroEvaluacionCAIBSH.DataType = DbType.DateTime;
				colvarFechaRetiroEvaluacionCAIBSH.MaxLength = 0;
				colvarFechaRetiroEvaluacionCAIBSH.AutoIncrement = false;
				colvarFechaRetiroEvaluacionCAIBSH.IsNullable = true;
				colvarFechaRetiroEvaluacionCAIBSH.IsPrimaryKey = false;
				colvarFechaRetiroEvaluacionCAIBSH.IsForeignKey = false;
				colvarFechaRetiroEvaluacionCAIBSH.IsReadOnly = false;
				colvarFechaRetiroEvaluacionCAIBSH.DefaultSetting = @"";
				colvarFechaRetiroEvaluacionCAIBSH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRetiroEvaluacionCAIBSH);
				
				TableSchema.TableColumn colvarOtroMotivoDictamenCAIBSH = new TableSchema.TableColumn(schema);
				colvarOtroMotivoDictamenCAIBSH.ColumnName = "otroMotivoDictamenCAIBSH";
				colvarOtroMotivoDictamenCAIBSH.DataType = DbType.AnsiString;
				colvarOtroMotivoDictamenCAIBSH.MaxLength = 1000;
				colvarOtroMotivoDictamenCAIBSH.AutoIncrement = false;
				colvarOtroMotivoDictamenCAIBSH.IsNullable = true;
				colvarOtroMotivoDictamenCAIBSH.IsPrimaryKey = false;
				colvarOtroMotivoDictamenCAIBSH.IsForeignKey = false;
				colvarOtroMotivoDictamenCAIBSH.IsReadOnly = false;
				colvarOtroMotivoDictamenCAIBSH.DefaultSetting = @"";
				colvarOtroMotivoDictamenCAIBSH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtroMotivoDictamenCAIBSH);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_Estudio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("TipoEstudio")]
		[Bindable(true)]
		public string TipoEstudio 
		{
			get { return GetColumnValue<string>(Columns.TipoEstudio); }
			set { SetColumnValue(Columns.TipoEstudio, value); }
		}
		  
		[XmlAttribute("NroOrden")]
		[Bindable(true)]
		public string NroOrden 
		{
			get { return GetColumnValue<string>(Columns.NroOrden); }
			set { SetColumnValue(Columns.NroOrden, value); }
		}
		  
		[XmlAttribute("Enmienda")]
		[Bindable(true)]
		public string Enmienda 
		{
			get { return GetColumnValue<string>(Columns.Enmienda); }
			set { SetColumnValue(Columns.Enmienda, value); }
		}
		  
		[XmlAttribute("Anio")]
		[Bindable(true)]
		public string Anio 
		{
			get { return GetColumnValue<string>(Columns.Anio); }
			set { SetColumnValue(Columns.Anio, value); }
		}
		  
		[XmlAttribute("TituloInvestigacion")]
		[Bindable(true)]
		public string TituloInvestigacion 
		{
			get { return GetColumnValue<string>(Columns.TituloInvestigacion); }
			set { SetColumnValue(Columns.TituloInvestigacion, value); }
		}
		  
		[XmlAttribute("NroRegistroNacional")]
		[Bindable(true)]
		public string NroRegistroNacional 
		{
			get { return GetColumnValue<string>(Columns.NroRegistroNacional); }
			set { SetColumnValue(Columns.NroRegistroNacional, value); }
		}
		  
		[XmlAttribute("NroExpediente")]
		[Bindable(true)]
		public string NroExpediente 
		{
			get { return GetColumnValue<string>(Columns.NroExpediente); }
			set { SetColumnValue(Columns.NroExpediente, value); }
		}
		  
		[XmlAttribute("NombreAbreviado")]
		[Bindable(true)]
		public string NombreAbreviado 
		{
			get { return GetColumnValue<string>(Columns.NombreAbreviado); }
			set { SetColumnValue(Columns.NombreAbreviado, value); }
		}
		  
		[XmlAttribute("Drogas")]
		[Bindable(true)]
		public string Drogas 
		{
			get { return GetColumnValue<string>(Columns.Drogas); }
			set { SetColumnValue(Columns.Drogas, value); }
		}
		  
		[XmlAttribute("PalabrasClave")]
		[Bindable(true)]
		public string PalabrasClave 
		{
			get { return GetColumnValue<string>(Columns.PalabrasClave); }
			set { SetColumnValue(Columns.PalabrasClave, value); }
		}
		  
		[XmlAttribute("NombreIntitucionAfiliacion")]
		[Bindable(true)]
		public string NombreIntitucionAfiliacion 
		{
			get { return GetColumnValue<string>(Columns.NombreIntitucionAfiliacion); }
			set { SetColumnValue(Columns.NombreIntitucionAfiliacion, value); }
		}
		  
		[XmlAttribute("ReferenteInstitucionAfiliacion")]
		[Bindable(true)]
		public string ReferenteInstitucionAfiliacion 
		{
			get { return GetColumnValue<string>(Columns.ReferenteInstitucionAfiliacion); }
			set { SetColumnValue(Columns.ReferenteInstitucionAfiliacion, value); }
		}
		  
		[XmlAttribute("TelefonoInstitucionAfiliacion")]
		[Bindable(true)]
		public string TelefonoInstitucionAfiliacion 
		{
			get { return GetColumnValue<string>(Columns.TelefonoInstitucionAfiliacion); }
			set { SetColumnValue(Columns.TelefonoInstitucionAfiliacion, value); }
		}
		  
		[XmlAttribute("DomicilioInstitucionAfiliacion")]
		[Bindable(true)]
		public string DomicilioInstitucionAfiliacion 
		{
			get { return GetColumnValue<string>(Columns.DomicilioInstitucionAfiliacion); }
			set { SetColumnValue(Columns.DomicilioInstitucionAfiliacion, value); }
		}
		  
		[XmlAttribute("CpDomicilioInstitucionAfiliacion")]
		[Bindable(true)]
		public string CpDomicilioInstitucionAfiliacion 
		{
			get { return GetColumnValue<string>(Columns.CpDomicilioInstitucionAfiliacion); }
			set { SetColumnValue(Columns.CpDomicilioInstitucionAfiliacion, value); }
		}
		  
		[XmlAttribute("EmailInstitucionAfiliacion")]
		[Bindable(true)]
		public string EmailInstitucionAfiliacion 
		{
			get { return GetColumnValue<string>(Columns.EmailInstitucionAfiliacion); }
			set { SetColumnValue(Columns.EmailInstitucionAfiliacion, value); }
		}
		  
		[XmlAttribute("IdAreaTematica")]
		[Bindable(true)]
		public int IdAreaTematica 
		{
			get { return GetColumnValue<int>(Columns.IdAreaTematica); }
			set { SetColumnValue(Columns.IdAreaTematica, value); }
		}
		  
		[XmlAttribute("IdFuenteRecoleccionDatos")]
		[Bindable(true)]
		public int? IdFuenteRecoleccionDatos 
		{
			get { return GetColumnValue<int?>(Columns.IdFuenteRecoleccionDatos); }
			set { SetColumnValue(Columns.IdFuenteRecoleccionDatos, value); }
		}
		  
		[XmlAttribute("TienePoblacionVulnerable")]
		[Bindable(true)]
		public string TienePoblacionVulnerable 
		{
			get { return GetColumnValue<string>(Columns.TienePoblacionVulnerable); }
			set { SetColumnValue(Columns.TienePoblacionVulnerable, value); }
		}
		  
		[XmlAttribute("TamanioMuestra")]
		[Bindable(true)]
		public int? TamanioMuestra 
		{
			get { return GetColumnValue<int?>(Columns.TamanioMuestra); }
			set { SetColumnValue(Columns.TamanioMuestra, value); }
		}
		  
		[XmlAttribute("Multicentrico")]
		[Bindable(true)]
		public string Multicentrico 
		{
			get { return GetColumnValue<string>(Columns.Multicentrico); }
			set { SetColumnValue(Columns.Multicentrico, value); }
		}
		  
		[XmlAttribute("TiempoEstimadoAnios")]
		[Bindable(true)]
		public int? TiempoEstimadoAnios 
		{
			get { return GetColumnValue<int?>(Columns.TiempoEstimadoAnios); }
			set { SetColumnValue(Columns.TiempoEstimadoAnios, value); }
		}
		  
		[XmlAttribute("TiempoEstimadoMeses")]
		[Bindable(true)]
		public int? TiempoEstimadoMeses 
		{
			get { return GetColumnValue<int?>(Columns.TiempoEstimadoMeses); }
			set { SetColumnValue(Columns.TiempoEstimadoMeses, value); }
		}
		  
		[XmlAttribute("FechaIncorporacionPrimerParticipante")]
		[Bindable(true)]
		public DateTime? FechaIncorporacionPrimerParticipante 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaIncorporacionPrimerParticipante); }
			set { SetColumnValue(Columns.FechaIncorporacionPrimerParticipante, value); }
		}
		  
		[XmlAttribute("FechaCierreIncorporacionParticipantes")]
		[Bindable(true)]
		public DateTime? FechaCierreIncorporacionParticipantes 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCierreIncorporacionParticipantes); }
			set { SetColumnValue(Columns.FechaCierreIncorporacionParticipantes, value); }
		}
		  
		[XmlAttribute("IdCaractaristica")]
		[Bindable(true)]
		public int? IdCaractaristica 
		{
			get { return GetColumnValue<int?>(Columns.IdCaractaristica); }
			set { SetColumnValue(Columns.IdCaractaristica, value); }
		}
		  
		[XmlAttribute("FechaCierreSitio")]
		[Bindable(true)]
		public DateTime? FechaCierreSitio 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCierreSitio); }
			set { SetColumnValue(Columns.FechaCierreSitio, value); }
		}
		  
		[XmlAttribute("OtrosCaractEstudios")]
		[Bindable(true)]
		public string OtrosCaractEstudios 
		{
			get { return GetColumnValue<string>(Columns.OtrosCaractEstudios); }
			set { SetColumnValue(Columns.OtrosCaractEstudios, value); }
		}
		  
		[XmlAttribute("FechaAprobadoCAIBSH")]
		[Bindable(true)]
		public DateTime? FechaAprobadoCAIBSH 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAprobadoCAIBSH); }
			set { SetColumnValue(Columns.FechaAprobadoCAIBSH, value); }
		}
		  
		[XmlAttribute("FechaRechazadoCAIBSH")]
		[Bindable(true)]
		public DateTime? FechaRechazadoCAIBSH 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRechazadoCAIBSH); }
			set { SetColumnValue(Columns.FechaRechazadoCAIBSH, value); }
		}
		  
		[XmlAttribute("ObservacionesCAIBSH")]
		[Bindable(true)]
		public string ObservacionesCAIBSH 
		{
			get { return GetColumnValue<string>(Columns.ObservacionesCAIBSH); }
			set { SetColumnValue(Columns.ObservacionesCAIBSH, value); }
		}
		  
		[XmlAttribute("FechaInicio")]
		[Bindable(true)]
		public DateTime? FechaInicio 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaInicio); }
			set { SetColumnValue(Columns.FechaInicio, value); }
		}
		  
		[XmlAttribute("FechaFinalizacion")]
		[Bindable(true)]
		public DateTime? FechaFinalizacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaFinalizacion); }
			set { SetColumnValue(Columns.FechaFinalizacion, value); }
		}
		  
		[XmlAttribute("FechaPresentacionInformeFinal")]
		[Bindable(true)]
		public DateTime? FechaPresentacionInformeFinal 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaPresentacionInformeFinal); }
			set { SetColumnValue(Columns.FechaPresentacionInformeFinal, value); }
		}
		  
		[XmlAttribute("FechaVencimientoPlazoCAIBSH")]
		[Bindable(true)]
		public DateTime? FechaVencimientoPlazoCAIBSH 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaVencimientoPlazoCAIBSH); }
			set { SetColumnValue(Columns.FechaVencimientoPlazoCAIBSH, value); }
		}
		  
		[XmlAttribute("FechaRetiroEvaluacionCAIBSH")]
		[Bindable(true)]
		public DateTime? FechaRetiroEvaluacionCAIBSH 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRetiroEvaluacionCAIBSH); }
			set { SetColumnValue(Columns.FechaRetiroEvaluacionCAIBSH, value); }
		}
		  
		[XmlAttribute("OtroMotivoDictamenCAIBSH")]
		[Bindable(true)]
		public string OtroMotivoDictamenCAIBSH 
		{
			get { return GetColumnValue<string>(Columns.OtroMotivoDictamenCAIBSH); }
			set { SetColumnValue(Columns.OtroMotivoDictamenCAIBSH, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTipoEstudio,string varNroOrden,string varEnmienda,string varAnio,string varTituloInvestigacion,string varNroRegistroNacional,string varNroExpediente,string varNombreAbreviado,string varDrogas,string varPalabrasClave,string varNombreIntitucionAfiliacion,string varReferenteInstitucionAfiliacion,string varTelefonoInstitucionAfiliacion,string varDomicilioInstitucionAfiliacion,string varCpDomicilioInstitucionAfiliacion,string varEmailInstitucionAfiliacion,int varIdAreaTematica,int? varIdFuenteRecoleccionDatos,string varTienePoblacionVulnerable,int? varTamanioMuestra,string varMulticentrico,int? varTiempoEstimadoAnios,int? varTiempoEstimadoMeses,DateTime? varFechaIncorporacionPrimerParticipante,DateTime? varFechaCierreIncorporacionParticipantes,int? varIdCaractaristica,DateTime? varFechaCierreSitio,string varOtrosCaractEstudios,DateTime? varFechaAprobadoCAIBSH,DateTime? varFechaRechazadoCAIBSH,string varObservacionesCAIBSH,DateTime? varFechaInicio,DateTime? varFechaFinalizacion,DateTime? varFechaPresentacionInformeFinal,DateTime? varFechaVencimientoPlazoCAIBSH,DateTime? varFechaRetiroEvaluacionCAIBSH,string varOtroMotivoDictamenCAIBSH)
		{
			RisEstudio item = new RisEstudio();
			
			item.TipoEstudio = varTipoEstudio;
			
			item.NroOrden = varNroOrden;
			
			item.Enmienda = varEnmienda;
			
			item.Anio = varAnio;
			
			item.TituloInvestigacion = varTituloInvestigacion;
			
			item.NroRegistroNacional = varNroRegistroNacional;
			
			item.NroExpediente = varNroExpediente;
			
			item.NombreAbreviado = varNombreAbreviado;
			
			item.Drogas = varDrogas;
			
			item.PalabrasClave = varPalabrasClave;
			
			item.NombreIntitucionAfiliacion = varNombreIntitucionAfiliacion;
			
			item.ReferenteInstitucionAfiliacion = varReferenteInstitucionAfiliacion;
			
			item.TelefonoInstitucionAfiliacion = varTelefonoInstitucionAfiliacion;
			
			item.DomicilioInstitucionAfiliacion = varDomicilioInstitucionAfiliacion;
			
			item.CpDomicilioInstitucionAfiliacion = varCpDomicilioInstitucionAfiliacion;
			
			item.EmailInstitucionAfiliacion = varEmailInstitucionAfiliacion;
			
			item.IdAreaTematica = varIdAreaTematica;
			
			item.IdFuenteRecoleccionDatos = varIdFuenteRecoleccionDatos;
			
			item.TienePoblacionVulnerable = varTienePoblacionVulnerable;
			
			item.TamanioMuestra = varTamanioMuestra;
			
			item.Multicentrico = varMulticentrico;
			
			item.TiempoEstimadoAnios = varTiempoEstimadoAnios;
			
			item.TiempoEstimadoMeses = varTiempoEstimadoMeses;
			
			item.FechaIncorporacionPrimerParticipante = varFechaIncorporacionPrimerParticipante;
			
			item.FechaCierreIncorporacionParticipantes = varFechaCierreIncorporacionParticipantes;
			
			item.IdCaractaristica = varIdCaractaristica;
			
			item.FechaCierreSitio = varFechaCierreSitio;
			
			item.OtrosCaractEstudios = varOtrosCaractEstudios;
			
			item.FechaAprobadoCAIBSH = varFechaAprobadoCAIBSH;
			
			item.FechaRechazadoCAIBSH = varFechaRechazadoCAIBSH;
			
			item.ObservacionesCAIBSH = varObservacionesCAIBSH;
			
			item.FechaInicio = varFechaInicio;
			
			item.FechaFinalizacion = varFechaFinalizacion;
			
			item.FechaPresentacionInformeFinal = varFechaPresentacionInformeFinal;
			
			item.FechaVencimientoPlazoCAIBSH = varFechaVencimientoPlazoCAIBSH;
			
			item.FechaRetiroEvaluacionCAIBSH = varFechaRetiroEvaluacionCAIBSH;
			
			item.OtroMotivoDictamenCAIBSH = varOtroMotivoDictamenCAIBSH;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudio,string varTipoEstudio,string varNroOrden,string varEnmienda,string varAnio,string varTituloInvestigacion,string varNroRegistroNacional,string varNroExpediente,string varNombreAbreviado,string varDrogas,string varPalabrasClave,string varNombreIntitucionAfiliacion,string varReferenteInstitucionAfiliacion,string varTelefonoInstitucionAfiliacion,string varDomicilioInstitucionAfiliacion,string varCpDomicilioInstitucionAfiliacion,string varEmailInstitucionAfiliacion,int varIdAreaTematica,int? varIdFuenteRecoleccionDatos,string varTienePoblacionVulnerable,int? varTamanioMuestra,string varMulticentrico,int? varTiempoEstimadoAnios,int? varTiempoEstimadoMeses,DateTime? varFechaIncorporacionPrimerParticipante,DateTime? varFechaCierreIncorporacionParticipantes,int? varIdCaractaristica,DateTime? varFechaCierreSitio,string varOtrosCaractEstudios,DateTime? varFechaAprobadoCAIBSH,DateTime? varFechaRechazadoCAIBSH,string varObservacionesCAIBSH,DateTime? varFechaInicio,DateTime? varFechaFinalizacion,DateTime? varFechaPresentacionInformeFinal,DateTime? varFechaVencimientoPlazoCAIBSH,DateTime? varFechaRetiroEvaluacionCAIBSH,string varOtroMotivoDictamenCAIBSH)
		{
			RisEstudio item = new RisEstudio();
			
				item.IdEstudio = varIdEstudio;
			
				item.TipoEstudio = varTipoEstudio;
			
				item.NroOrden = varNroOrden;
			
				item.Enmienda = varEnmienda;
			
				item.Anio = varAnio;
			
				item.TituloInvestigacion = varTituloInvestigacion;
			
				item.NroRegistroNacional = varNroRegistroNacional;
			
				item.NroExpediente = varNroExpediente;
			
				item.NombreAbreviado = varNombreAbreviado;
			
				item.Drogas = varDrogas;
			
				item.PalabrasClave = varPalabrasClave;
			
				item.NombreIntitucionAfiliacion = varNombreIntitucionAfiliacion;
			
				item.ReferenteInstitucionAfiliacion = varReferenteInstitucionAfiliacion;
			
				item.TelefonoInstitucionAfiliacion = varTelefonoInstitucionAfiliacion;
			
				item.DomicilioInstitucionAfiliacion = varDomicilioInstitucionAfiliacion;
			
				item.CpDomicilioInstitucionAfiliacion = varCpDomicilioInstitucionAfiliacion;
			
				item.EmailInstitucionAfiliacion = varEmailInstitucionAfiliacion;
			
				item.IdAreaTematica = varIdAreaTematica;
			
				item.IdFuenteRecoleccionDatos = varIdFuenteRecoleccionDatos;
			
				item.TienePoblacionVulnerable = varTienePoblacionVulnerable;
			
				item.TamanioMuestra = varTamanioMuestra;
			
				item.Multicentrico = varMulticentrico;
			
				item.TiempoEstimadoAnios = varTiempoEstimadoAnios;
			
				item.TiempoEstimadoMeses = varTiempoEstimadoMeses;
			
				item.FechaIncorporacionPrimerParticipante = varFechaIncorporacionPrimerParticipante;
			
				item.FechaCierreIncorporacionParticipantes = varFechaCierreIncorporacionParticipantes;
			
				item.IdCaractaristica = varIdCaractaristica;
			
				item.FechaCierreSitio = varFechaCierreSitio;
			
				item.OtrosCaractEstudios = varOtrosCaractEstudios;
			
				item.FechaAprobadoCAIBSH = varFechaAprobadoCAIBSH;
			
				item.FechaRechazadoCAIBSH = varFechaRechazadoCAIBSH;
			
				item.ObservacionesCAIBSH = varObservacionesCAIBSH;
			
				item.FechaInicio = varFechaInicio;
			
				item.FechaFinalizacion = varFechaFinalizacion;
			
				item.FechaPresentacionInformeFinal = varFechaPresentacionInformeFinal;
			
				item.FechaVencimientoPlazoCAIBSH = varFechaVencimientoPlazoCAIBSH;
			
				item.FechaRetiroEvaluacionCAIBSH = varFechaRetiroEvaluacionCAIBSH;
			
				item.OtroMotivoDictamenCAIBSH = varOtroMotivoDictamenCAIBSH;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NroOrdenColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EnmiendaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TituloInvestigacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NroRegistroNacionalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NroExpedienteColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreAbreviadoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DrogasColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn PalabrasClaveColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreIntitucionAfiliacionColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ReferenteInstitucionAfiliacionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoInstitucionAfiliacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioInstitucionAfiliacionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CpDomicilioInstitucionAfiliacionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailInstitucionAfiliacionColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAreaTematicaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFuenteRecoleccionDatosColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn TienePoblacionVulnerableColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn TamanioMuestraColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn MulticentricoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoEstimadoAniosColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoEstimadoMesesColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaIncorporacionPrimerParticipanteColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCierreIncorporacionParticipantesColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCaractaristicaColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCierreSitioColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosCaractEstudiosColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAprobadoCAIBSHColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRechazadoCAIBSHColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesCAIBSHColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInicioColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFinalizacionColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPresentacionInformeFinalColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaVencimientoPlazoCAIBSHColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRetiroEvaluacionCAIBSHColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn OtroMotivoDictamenCAIBSHColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudio = @"idEstudio";
			 public static string TipoEstudio = @"tipoEstudio";
			 public static string NroOrden = @"nroOrden";
			 public static string Enmienda = @"enmienda";
			 public static string Anio = @"anio";
			 public static string TituloInvestigacion = @"tituloInvestigacion";
			 public static string NroRegistroNacional = @"nroRegistroNacional";
			 public static string NroExpediente = @"nroExpediente";
			 public static string NombreAbreviado = @"nombreAbreviado";
			 public static string Drogas = @"drogas";
			 public static string PalabrasClave = @"palabrasClave";
			 public static string NombreIntitucionAfiliacion = @"nombreIntitucionAfiliacion";
			 public static string ReferenteInstitucionAfiliacion = @"referenteInstitucionAfiliacion";
			 public static string TelefonoInstitucionAfiliacion = @"telefonoInstitucionAfiliacion";
			 public static string DomicilioInstitucionAfiliacion = @"domicilioInstitucionAfiliacion";
			 public static string CpDomicilioInstitucionAfiliacion = @"cpDomicilioInstitucionAfiliacion";
			 public static string EmailInstitucionAfiliacion = @"emailInstitucionAfiliacion";
			 public static string IdAreaTematica = @"idAreaTematica";
			 public static string IdFuenteRecoleccionDatos = @"idFuenteRecoleccionDatos";
			 public static string TienePoblacionVulnerable = @"tienePoblacionVulnerable";
			 public static string TamanioMuestra = @"tamanioMuestra";
			 public static string Multicentrico = @"multicentrico";
			 public static string TiempoEstimadoAnios = @"tiempoEstimadoAnios";
			 public static string TiempoEstimadoMeses = @"tiempoEstimadoMeses";
			 public static string FechaIncorporacionPrimerParticipante = @"fechaIncorporacionPrimerParticipante";
			 public static string FechaCierreIncorporacionParticipantes = @"fechaCierreIncorporacionParticipantes";
			 public static string IdCaractaristica = @"idCaractaristica";
			 public static string FechaCierreSitio = @"fechaCierreSitio";
			 public static string OtrosCaractEstudios = @"otrosCaractEstudios";
			 public static string FechaAprobadoCAIBSH = @"fechaAprobadoCAIBSH";
			 public static string FechaRechazadoCAIBSH = @"fechaRechazadoCAIBSH";
			 public static string ObservacionesCAIBSH = @"observacionesCAIBSH";
			 public static string FechaInicio = @"fechaInicio";
			 public static string FechaFinalizacion = @"fechaFinalizacion";
			 public static string FechaPresentacionInformeFinal = @"fechaPresentacionInformeFinal";
			 public static string FechaVencimientoPlazoCAIBSH = @"fechaVencimientoPlazoCAIBSH";
			 public static string FechaRetiroEvaluacionCAIBSH = @"fechaRetiroEvaluacionCAIBSH";
			 public static string OtroMotivoDictamenCAIBSH = @"otroMotivoDictamenCAIBSH";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
