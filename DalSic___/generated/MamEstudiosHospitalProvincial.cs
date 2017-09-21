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
	/// Strongly-typed collection for the MamEstudiosHospitalProvincial class.
	/// </summary>
    [Serializable]
	public partial class MamEstudiosHospitalProvincialCollection : ActiveList<MamEstudiosHospitalProvincial, MamEstudiosHospitalProvincialCollection>
	{	   
		public MamEstudiosHospitalProvincialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamEstudiosHospitalProvincialCollection</returns>
		public MamEstudiosHospitalProvincialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamEstudiosHospitalProvincial o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_EstudiosHospitalProvincial table.
	/// </summary>
	[Serializable]
	public partial class MamEstudiosHospitalProvincial : ActiveRecord<MamEstudiosHospitalProvincial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamEstudiosHospitalProvincial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamEstudiosHospitalProvincial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamEstudiosHospitalProvincial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamEstudiosHospitalProvincial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_EstudiosHospitalProvincial", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMamografiaHP = new TableSchema.TableColumn(schema);
				colvarIdMamografiaHP.ColumnName = "idMamografiaHP";
				colvarIdMamografiaHP.DataType = DbType.Int32;
				colvarIdMamografiaHP.MaxLength = 0;
				colvarIdMamografiaHP.AutoIncrement = true;
				colvarIdMamografiaHP.IsNullable = false;
				colvarIdMamografiaHP.IsPrimaryKey = true;
				colvarIdMamografiaHP.IsForeignKey = false;
				colvarIdMamografiaHP.IsReadOnly = false;
				colvarIdMamografiaHP.DefaultSetting = @"";
				colvarIdMamografiaHP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMamografiaHP);
				
				TableSchema.TableColumn colvarIdHistoria = new TableSchema.TableColumn(schema);
				colvarIdHistoria.ColumnName = "idHistoria";
				colvarIdHistoria.DataType = DbType.Int32;
				colvarIdHistoria.MaxLength = 0;
				colvarIdHistoria.AutoIncrement = false;
				colvarIdHistoria.IsNullable = true;
				colvarIdHistoria.IsPrimaryKey = false;
				colvarIdHistoria.IsForeignKey = false;
				colvarIdHistoria.IsReadOnly = false;
				colvarIdHistoria.DefaultSetting = @"";
				colvarIdHistoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHistoria);
				
				TableSchema.TableColumn colvarTipoDocumento = new TableSchema.TableColumn(schema);
				colvarTipoDocumento.ColumnName = "tipoDocumento";
				colvarTipoDocumento.DataType = DbType.AnsiString;
				colvarTipoDocumento.MaxLength = 10;
				colvarTipoDocumento.AutoIncrement = false;
				colvarTipoDocumento.IsNullable = true;
				colvarTipoDocumento.IsPrimaryKey = false;
				colvarTipoDocumento.IsForeignKey = false;
				colvarTipoDocumento.IsReadOnly = false;
				colvarTipoDocumento.DefaultSetting = @"";
				colvarTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocumento);
				
				TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
				colvarDocumento.ColumnName = "Documento";
				colvarDocumento.DataType = DbType.Int32;
				colvarDocumento.MaxLength = 0;
				colvarDocumento.AutoIncrement = false;
				colvarDocumento.IsNullable = true;
				colvarDocumento.IsPrimaryKey = false;
				colvarDocumento.IsForeignKey = false;
				colvarDocumento.IsReadOnly = false;
				colvarDocumento.DefaultSetting = @"";
				colvarDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumento);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "Apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = 50;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarObraSocial = new TableSchema.TableColumn(schema);
				colvarObraSocial.ColumnName = "obraSocial";
				colvarObraSocial.DataType = DbType.AnsiString;
				colvarObraSocial.MaxLength = 2000;
				colvarObraSocial.AutoIncrement = false;
				colvarObraSocial.IsNullable = true;
				colvarObraSocial.IsPrimaryKey = false;
				colvarObraSocial.IsForeignKey = false;
				colvarObraSocial.IsReadOnly = false;
				
						colvarObraSocial.DefaultSetting = @"('')";
				colvarObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObraSocial);
				
				TableSchema.TableColumn colvarInformacionContacto = new TableSchema.TableColumn(schema);
				colvarInformacionContacto.ColumnName = "informacionContacto";
				colvarInformacionContacto.DataType = DbType.AnsiString;
				colvarInformacionContacto.MaxLength = 500;
				colvarInformacionContacto.AutoIncrement = false;
				colvarInformacionContacto.IsNullable = true;
				colvarInformacionContacto.IsPrimaryKey = false;
				colvarInformacionContacto.IsForeignKey = false;
				colvarInformacionContacto.IsReadOnly = false;
				colvarInformacionContacto.DefaultSetting = @"";
				colvarInformacionContacto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformacionContacto);
				
				TableSchema.TableColumn colvarDireccion = new TableSchema.TableColumn(schema);
				colvarDireccion.ColumnName = "Direccion";
				colvarDireccion.DataType = DbType.AnsiString;
				colvarDireccion.MaxLength = 500;
				colvarDireccion.AutoIncrement = false;
				colvarDireccion.IsNullable = true;
				colvarDireccion.IsPrimaryKey = false;
				colvarDireccion.IsForeignKey = false;
				colvarDireccion.IsReadOnly = false;
				colvarDireccion.DefaultSetting = @"";
				colvarDireccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccion);
				
				TableSchema.TableColumn colvarSolicitudProfesional = new TableSchema.TableColumn(schema);
				colvarSolicitudProfesional.ColumnName = "SolicitudProfesional";
				colvarSolicitudProfesional.DataType = DbType.Int32;
				colvarSolicitudProfesional.MaxLength = 0;
				colvarSolicitudProfesional.AutoIncrement = false;
				colvarSolicitudProfesional.IsNullable = true;
				colvarSolicitudProfesional.IsPrimaryKey = false;
				colvarSolicitudProfesional.IsForeignKey = true;
				colvarSolicitudProfesional.IsReadOnly = false;
				colvarSolicitudProfesional.DefaultSetting = @"";
				
					colvarSolicitudProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarSolicitudProfesional);
				
				TableSchema.TableColumn colvarSolicitudCentroSalud = new TableSchema.TableColumn(schema);
				colvarSolicitudCentroSalud.ColumnName = "SolicitudCentroSalud";
				colvarSolicitudCentroSalud.DataType = DbType.Int32;
				colvarSolicitudCentroSalud.MaxLength = 0;
				colvarSolicitudCentroSalud.AutoIncrement = false;
				colvarSolicitudCentroSalud.IsNullable = true;
				colvarSolicitudCentroSalud.IsPrimaryKey = false;
				colvarSolicitudCentroSalud.IsForeignKey = true;
				colvarSolicitudCentroSalud.IsReadOnly = false;
				colvarSolicitudCentroSalud.DefaultSetting = @"";
				
					colvarSolicitudCentroSalud.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarSolicitudCentroSalud);
				
				TableSchema.TableColumn colvarBiradIzquierdo = new TableSchema.TableColumn(schema);
				colvarBiradIzquierdo.ColumnName = "BiradIzquierdo";
				colvarBiradIzquierdo.DataType = DbType.Int32;
				colvarBiradIzquierdo.MaxLength = 0;
				colvarBiradIzquierdo.AutoIncrement = false;
				colvarBiradIzquierdo.IsNullable = true;
				colvarBiradIzquierdo.IsPrimaryKey = false;
				colvarBiradIzquierdo.IsForeignKey = false;
				colvarBiradIzquierdo.IsReadOnly = false;
				colvarBiradIzquierdo.DefaultSetting = @"";
				colvarBiradIzquierdo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBiradIzquierdo);
				
				TableSchema.TableColumn colvarBiradDerecho = new TableSchema.TableColumn(schema);
				colvarBiradDerecho.ColumnName = "BiradDerecho";
				colvarBiradDerecho.DataType = DbType.Int32;
				colvarBiradDerecho.MaxLength = 0;
				colvarBiradDerecho.AutoIncrement = false;
				colvarBiradDerecho.IsNullable = true;
				colvarBiradDerecho.IsPrimaryKey = false;
				colvarBiradDerecho.IsForeignKey = false;
				colvarBiradDerecho.IsReadOnly = false;
				colvarBiradDerecho.DefaultSetting = @"";
				colvarBiradDerecho.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBiradDerecho);
				
				TableSchema.TableColumn colvarBiradDefinitivo = new TableSchema.TableColumn(schema);
				colvarBiradDefinitivo.ColumnName = "BiradDefinitivo";
				colvarBiradDefinitivo.DataType = DbType.Int32;
				colvarBiradDefinitivo.MaxLength = 0;
				colvarBiradDefinitivo.AutoIncrement = false;
				colvarBiradDefinitivo.IsNullable = true;
				colvarBiradDefinitivo.IsPrimaryKey = false;
				colvarBiradDefinitivo.IsForeignKey = false;
				colvarBiradDefinitivo.IsReadOnly = false;
				colvarBiradDefinitivo.DefaultSetting = @"";
				colvarBiradDefinitivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBiradDefinitivo);
				
				TableSchema.TableColumn colvarFechaPlaca = new TableSchema.TableColumn(schema);
				colvarFechaPlaca.ColumnName = "fechaPlaca";
				colvarFechaPlaca.DataType = DbType.DateTime;
				colvarFechaPlaca.MaxLength = 0;
				colvarFechaPlaca.AutoIncrement = false;
				colvarFechaPlaca.IsNullable = true;
				colvarFechaPlaca.IsPrimaryKey = false;
				colvarFechaPlaca.IsForeignKey = false;
				colvarFechaPlaca.IsReadOnly = false;
				colvarFechaPlaca.DefaultSetting = @"";
				colvarFechaPlaca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPlaca);
				
				TableSchema.TableColumn colvarFechaInforme = new TableSchema.TableColumn(schema);
				colvarFechaInforme.ColumnName = "fechaInforme";
				colvarFechaInforme.DataType = DbType.DateTime;
				colvarFechaInforme.MaxLength = 0;
				colvarFechaInforme.AutoIncrement = false;
				colvarFechaInforme.IsNullable = true;
				colvarFechaInforme.IsPrimaryKey = false;
				colvarFechaInforme.IsForeignKey = false;
				colvarFechaInforme.IsReadOnly = false;
				colvarFechaInforme.DefaultSetting = @"";
				colvarFechaInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInforme);
				
				TableSchema.TableColumn colvarInforme = new TableSchema.TableColumn(schema);
				colvarInforme.ColumnName = "informe";
				colvarInforme.DataType = DbType.AnsiString;
				colvarInforme.MaxLength = 5000;
				colvarInforme.AutoIncrement = false;
				colvarInforme.IsNullable = true;
				colvarInforme.IsPrimaryKey = false;
				colvarInforme.IsForeignKey = false;
				colvarInforme.IsReadOnly = false;
				colvarInforme.DefaultSetting = @"";
				colvarInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInforme);
				
				TableSchema.TableColumn colvarIdMotivo = new TableSchema.TableColumn(schema);
				colvarIdMotivo.ColumnName = "idMotivo";
				colvarIdMotivo.DataType = DbType.Int32;
				colvarIdMotivo.MaxLength = 0;
				colvarIdMotivo.AutoIncrement = false;
				colvarIdMotivo.IsNullable = true;
				colvarIdMotivo.IsPrimaryKey = false;
				colvarIdMotivo.IsForeignKey = false;
				colvarIdMotivo.IsReadOnly = false;
				colvarIdMotivo.DefaultSetting = @"";
				colvarIdMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivo);
				
				TableSchema.TableColumn colvarMotivo = new TableSchema.TableColumn(schema);
				colvarMotivo.ColumnName = "motivo";
				colvarMotivo.DataType = DbType.AnsiString;
				colvarMotivo.MaxLength = 100;
				colvarMotivo.AutoIncrement = false;
				colvarMotivo.IsNullable = true;
				colvarMotivo.IsPrimaryKey = false;
				colvarMotivo.IsForeignKey = false;
				colvarMotivo.IsReadOnly = false;
				colvarMotivo.DefaultSetting = @"";
				colvarMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivo);
				
				TableSchema.TableColumn colvarIdMotivoSitam = new TableSchema.TableColumn(schema);
				colvarIdMotivoSitam.ColumnName = "idMotivoSitam";
				colvarIdMotivoSitam.DataType = DbType.Int32;
				colvarIdMotivoSitam.MaxLength = 0;
				colvarIdMotivoSitam.AutoIncrement = false;
				colvarIdMotivoSitam.IsNullable = true;
				colvarIdMotivoSitam.IsPrimaryKey = false;
				colvarIdMotivoSitam.IsForeignKey = false;
				colvarIdMotivoSitam.IsReadOnly = false;
				colvarIdMotivoSitam.DefaultSetting = @"";
				colvarIdMotivoSitam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoSitam);
				
				TableSchema.TableColumn colvarIdTipoEstudio = new TableSchema.TableColumn(schema);
				colvarIdTipoEstudio.ColumnName = "idTipoEstudio";
				colvarIdTipoEstudio.DataType = DbType.Int32;
				colvarIdTipoEstudio.MaxLength = 0;
				colvarIdTipoEstudio.AutoIncrement = false;
				colvarIdTipoEstudio.IsNullable = true;
				colvarIdTipoEstudio.IsPrimaryKey = false;
				colvarIdTipoEstudio.IsForeignKey = true;
				colvarIdTipoEstudio.IsReadOnly = false;
				colvarIdTipoEstudio.DefaultSetting = @"";
				
					colvarIdTipoEstudio.ForeignKeyTableName = "MAM_TipoEstudio";
				schema.Columns.Add(colvarIdTipoEstudio);
				
				TableSchema.TableColumn colvarIdTipoEstudioSitam = new TableSchema.TableColumn(schema);
				colvarIdTipoEstudioSitam.ColumnName = "idTipoEstudioSitam";
				colvarIdTipoEstudioSitam.DataType = DbType.Int32;
				colvarIdTipoEstudioSitam.MaxLength = 0;
				colvarIdTipoEstudioSitam.AutoIncrement = false;
				colvarIdTipoEstudioSitam.IsNullable = true;
				colvarIdTipoEstudioSitam.IsPrimaryKey = false;
				colvarIdTipoEstudioSitam.IsForeignKey = false;
				colvarIdTipoEstudioSitam.IsReadOnly = false;
				colvarIdTipoEstudioSitam.DefaultSetting = @"";
				colvarIdTipoEstudioSitam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEstudioSitam);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 500;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarPasadoSips = new TableSchema.TableColumn(schema);
				colvarPasadoSips.ColumnName = "pasadoSips";
				colvarPasadoSips.DataType = DbType.Boolean;
				colvarPasadoSips.MaxLength = 0;
				colvarPasadoSips.AutoIncrement = false;
				colvarPasadoSips.IsNullable = false;
				colvarPasadoSips.IsPrimaryKey = false;
				colvarPasadoSips.IsForeignKey = false;
				colvarPasadoSips.IsReadOnly = false;
				
						colvarPasadoSips.DefaultSetting = @"((0))";
				colvarPasadoSips.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPasadoSips);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
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
				
				TableSchema.TableColumn colvarInformeProfesional = new TableSchema.TableColumn(schema);
				colvarInformeProfesional.ColumnName = "informeProfesional";
				colvarInformeProfesional.DataType = DbType.Int32;
				colvarInformeProfesional.MaxLength = 0;
				colvarInformeProfesional.AutoIncrement = false;
				colvarInformeProfesional.IsNullable = true;
				colvarInformeProfesional.IsPrimaryKey = false;
				colvarInformeProfesional.IsForeignKey = false;
				colvarInformeProfesional.IsReadOnly = false;
				
						colvarInformeProfesional.DefaultSetting = @"((0))";
				colvarInformeProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformeProfesional);
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "localidad";
				colvarLocalidad.DataType = DbType.AnsiString;
				colvarLocalidad.MaxLength = 100;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarInformacionCelular = new TableSchema.TableColumn(schema);
				colvarInformacionCelular.ColumnName = "informacionCelular";
				colvarInformacionCelular.DataType = DbType.AnsiString;
				colvarInformacionCelular.MaxLength = 20;
				colvarInformacionCelular.AutoIncrement = false;
				colvarInformacionCelular.IsNullable = true;
				colvarInformacionCelular.IsPrimaryKey = false;
				colvarInformacionCelular.IsForeignKey = false;
				colvarInformacionCelular.IsReadOnly = false;
				colvarInformacionCelular.DefaultSetting = @"";
				colvarInformacionCelular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformacionCelular);
				
				TableSchema.TableColumn colvarSolicitudProfesionalSSS = new TableSchema.TableColumn(schema);
				colvarSolicitudProfesionalSSS.ColumnName = "solicitudProfesionalSSS";
				colvarSolicitudProfesionalSSS.DataType = DbType.Int32;
				colvarSolicitudProfesionalSSS.MaxLength = 0;
				colvarSolicitudProfesionalSSS.AutoIncrement = false;
				colvarSolicitudProfesionalSSS.IsNullable = true;
				colvarSolicitudProfesionalSSS.IsPrimaryKey = false;
				colvarSolicitudProfesionalSSS.IsForeignKey = false;
				colvarSolicitudProfesionalSSS.IsReadOnly = false;
				
						colvarSolicitudProfesionalSSS.DefaultSetting = @"((0))";
				colvarSolicitudProfesionalSSS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSolicitudProfesionalSSS);
				
				TableSchema.TableColumn colvarSolicitudProfesionalDNI = new TableSchema.TableColumn(schema);
				colvarSolicitudProfesionalDNI.ColumnName = "solicitudProfesionalDNI";
				colvarSolicitudProfesionalDNI.DataType = DbType.Int32;
				colvarSolicitudProfesionalDNI.MaxLength = 0;
				colvarSolicitudProfesionalDNI.AutoIncrement = false;
				colvarSolicitudProfesionalDNI.IsNullable = true;
				colvarSolicitudProfesionalDNI.IsPrimaryKey = false;
				colvarSolicitudProfesionalDNI.IsForeignKey = false;
				colvarSolicitudProfesionalDNI.IsReadOnly = false;
				
						colvarSolicitudProfesionalDNI.DefaultSetting = @"((0))";
				colvarSolicitudProfesionalDNI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSolicitudProfesionalDNI);
				
				TableSchema.TableColumn colvarInformeProfesionalSSS = new TableSchema.TableColumn(schema);
				colvarInformeProfesionalSSS.ColumnName = "informeProfesionalSSS";
				colvarInformeProfesionalSSS.DataType = DbType.Int32;
				colvarInformeProfesionalSSS.MaxLength = 0;
				colvarInformeProfesionalSSS.AutoIncrement = false;
				colvarInformeProfesionalSSS.IsNullable = true;
				colvarInformeProfesionalSSS.IsPrimaryKey = false;
				colvarInformeProfesionalSSS.IsForeignKey = false;
				colvarInformeProfesionalSSS.IsReadOnly = false;
				
						colvarInformeProfesionalSSS.DefaultSetting = @"((0))";
				colvarInformeProfesionalSSS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformeProfesionalSSS);
				
				TableSchema.TableColumn colvarInformeProfesionalDNI = new TableSchema.TableColumn(schema);
				colvarInformeProfesionalDNI.ColumnName = "informeProfesionalDNI";
				colvarInformeProfesionalDNI.DataType = DbType.Int32;
				colvarInformeProfesionalDNI.MaxLength = 0;
				colvarInformeProfesionalDNI.AutoIncrement = false;
				colvarInformeProfesionalDNI.IsNullable = true;
				colvarInformeProfesionalDNI.IsPrimaryKey = false;
				colvarInformeProfesionalDNI.IsForeignKey = false;
				colvarInformeProfesionalDNI.IsReadOnly = false;
				
						colvarInformeProfesionalDNI.DefaultSetting = @"((0))";
				colvarInformeProfesionalDNI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformeProfesionalDNI);
				
				TableSchema.TableColumn colvarEquipo = new TableSchema.TableColumn(schema);
				colvarEquipo.ColumnName = "equipo";
				colvarEquipo.DataType = DbType.AnsiString;
				colvarEquipo.MaxLength = 50;
				colvarEquipo.AutoIncrement = false;
				colvarEquipo.IsNullable = true;
				colvarEquipo.IsPrimaryKey = false;
				colvarEquipo.IsForeignKey = false;
				colvarEquipo.IsReadOnly = false;
				
						colvarEquipo.DefaultSetting = @"('')";
				colvarEquipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEquipo);
				
				TableSchema.TableColumn colvarMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarMotivoConsulta.ColumnName = "motivoConsulta";
				colvarMotivoConsulta.DataType = DbType.AnsiString;
				colvarMotivoConsulta.MaxLength = 100;
				colvarMotivoConsulta.AutoIncrement = false;
				colvarMotivoConsulta.IsNullable = true;
				colvarMotivoConsulta.IsPrimaryKey = false;
				colvarMotivoConsulta.IsForeignKey = false;
				colvarMotivoConsulta.IsReadOnly = false;
				
						colvarMotivoConsulta.DefaultSetting = @"('')";
				colvarMotivoConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivoConsulta);
				
				TableSchema.TableColumn colvarProtocolo = new TableSchema.TableColumn(schema);
				colvarProtocolo.ColumnName = "protocolo";
				colvarProtocolo.DataType = DbType.Int32;
				colvarProtocolo.MaxLength = 0;
				colvarProtocolo.AutoIncrement = false;
				colvarProtocolo.IsNullable = true;
				colvarProtocolo.IsPrimaryKey = false;
				colvarProtocolo.IsForeignKey = false;
				colvarProtocolo.IsReadOnly = false;
				
						colvarProtocolo.DefaultSetting = @"((0))";
				colvarProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProtocolo);
				
				TableSchema.TableColumn colvarProtocoloPrefijo = new TableSchema.TableColumn(schema);
				colvarProtocoloPrefijo.ColumnName = "protocoloPrefijo";
				colvarProtocoloPrefijo.DataType = DbType.AnsiStringFixedLength;
				colvarProtocoloPrefijo.MaxLength = 10;
				colvarProtocoloPrefijo.AutoIncrement = false;
				colvarProtocoloPrefijo.IsNullable = true;
				colvarProtocoloPrefijo.IsPrimaryKey = false;
				colvarProtocoloPrefijo.IsForeignKey = false;
				colvarProtocoloPrefijo.IsReadOnly = false;
				
						colvarProtocoloPrefijo.DefaultSetting = @"('')";
				colvarProtocoloPrefijo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProtocoloPrefijo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_EstudiosHospitalProvincial",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMamografiaHP")]
		[Bindable(true)]
		public int IdMamografiaHP 
		{
			get { return GetColumnValue<int>(Columns.IdMamografiaHP); }
			set { SetColumnValue(Columns.IdMamografiaHP, value); }
		}
		  
		[XmlAttribute("IdHistoria")]
		[Bindable(true)]
		public int? IdHistoria 
		{
			get { return GetColumnValue<int?>(Columns.IdHistoria); }
			set { SetColumnValue(Columns.IdHistoria, value); }
		}
		  
		[XmlAttribute("TipoDocumento")]
		[Bindable(true)]
		public string TipoDocumento 
		{
			get { return GetColumnValue<string>(Columns.TipoDocumento); }
			set { SetColumnValue(Columns.TipoDocumento, value); }
		}
		  
		[XmlAttribute("Documento")]
		[Bindable(true)]
		public int? Documento 
		{
			get { return GetColumnValue<int?>(Columns.Documento); }
			set { SetColumnValue(Columns.Documento, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("ObraSocial")]
		[Bindable(true)]
		public string ObraSocial 
		{
			get { return GetColumnValue<string>(Columns.ObraSocial); }
			set { SetColumnValue(Columns.ObraSocial, value); }
		}
		  
		[XmlAttribute("InformacionContacto")]
		[Bindable(true)]
		public string InformacionContacto 
		{
			get { return GetColumnValue<string>(Columns.InformacionContacto); }
			set { SetColumnValue(Columns.InformacionContacto, value); }
		}
		  
		[XmlAttribute("Direccion")]
		[Bindable(true)]
		public string Direccion 
		{
			get { return GetColumnValue<string>(Columns.Direccion); }
			set { SetColumnValue(Columns.Direccion, value); }
		}
		  
		[XmlAttribute("SolicitudProfesional")]
		[Bindable(true)]
		public int? SolicitudProfesional 
		{
			get { return GetColumnValue<int?>(Columns.SolicitudProfesional); }
			set { SetColumnValue(Columns.SolicitudProfesional, value); }
		}
		  
		[XmlAttribute("SolicitudCentroSalud")]
		[Bindable(true)]
		public int? SolicitudCentroSalud 
		{
			get { return GetColumnValue<int?>(Columns.SolicitudCentroSalud); }
			set { SetColumnValue(Columns.SolicitudCentroSalud, value); }
		}
		  
		[XmlAttribute("BiradIzquierdo")]
		[Bindable(true)]
		public int? BiradIzquierdo 
		{
			get { return GetColumnValue<int?>(Columns.BiradIzquierdo); }
			set { SetColumnValue(Columns.BiradIzquierdo, value); }
		}
		  
		[XmlAttribute("BiradDerecho")]
		[Bindable(true)]
		public int? BiradDerecho 
		{
			get { return GetColumnValue<int?>(Columns.BiradDerecho); }
			set { SetColumnValue(Columns.BiradDerecho, value); }
		}
		  
		[XmlAttribute("BiradDefinitivo")]
		[Bindable(true)]
		public int? BiradDefinitivo 
		{
			get { return GetColumnValue<int?>(Columns.BiradDefinitivo); }
			set { SetColumnValue(Columns.BiradDefinitivo, value); }
		}
		  
		[XmlAttribute("FechaPlaca")]
		[Bindable(true)]
		public DateTime? FechaPlaca 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaPlaca); }
			set { SetColumnValue(Columns.FechaPlaca, value); }
		}
		  
		[XmlAttribute("FechaInforme")]
		[Bindable(true)]
		public DateTime? FechaInforme 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaInforme); }
			set { SetColumnValue(Columns.FechaInforme, value); }
		}
		  
		[XmlAttribute("Informe")]
		[Bindable(true)]
		public string Informe 
		{
			get { return GetColumnValue<string>(Columns.Informe); }
			set { SetColumnValue(Columns.Informe, value); }
		}
		  
		[XmlAttribute("IdMotivo")]
		[Bindable(true)]
		public int? IdMotivo 
		{
			get { return GetColumnValue<int?>(Columns.IdMotivo); }
			set { SetColumnValue(Columns.IdMotivo, value); }
		}
		  
		[XmlAttribute("Motivo")]
		[Bindable(true)]
		public string Motivo 
		{
			get { return GetColumnValue<string>(Columns.Motivo); }
			set { SetColumnValue(Columns.Motivo, value); }
		}
		  
		[XmlAttribute("IdMotivoSitam")]
		[Bindable(true)]
		public int? IdMotivoSitam 
		{
			get { return GetColumnValue<int?>(Columns.IdMotivoSitam); }
			set { SetColumnValue(Columns.IdMotivoSitam, value); }
		}
		  
		[XmlAttribute("IdTipoEstudio")]
		[Bindable(true)]
		public int? IdTipoEstudio 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoEstudio); }
			set { SetColumnValue(Columns.IdTipoEstudio, value); }
		}
		  
		[XmlAttribute("IdTipoEstudioSitam")]
		[Bindable(true)]
		public int? IdTipoEstudioSitam 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoEstudioSitam); }
			set { SetColumnValue(Columns.IdTipoEstudioSitam, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("PasadoSips")]
		[Bindable(true)]
		public bool PasadoSips 
		{
			get { return GetColumnValue<bool>(Columns.PasadoSips); }
			set { SetColumnValue(Columns.PasadoSips, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
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
		  
		[XmlAttribute("InformeProfesional")]
		[Bindable(true)]
		public int? InformeProfesional 
		{
			get { return GetColumnValue<int?>(Columns.InformeProfesional); }
			set { SetColumnValue(Columns.InformeProfesional, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("InformacionCelular")]
		[Bindable(true)]
		public string InformacionCelular 
		{
			get { return GetColumnValue<string>(Columns.InformacionCelular); }
			set { SetColumnValue(Columns.InformacionCelular, value); }
		}
		  
		[XmlAttribute("SolicitudProfesionalSSS")]
		[Bindable(true)]
		public int? SolicitudProfesionalSSS 
		{
			get { return GetColumnValue<int?>(Columns.SolicitudProfesionalSSS); }
			set { SetColumnValue(Columns.SolicitudProfesionalSSS, value); }
		}
		  
		[XmlAttribute("SolicitudProfesionalDNI")]
		[Bindable(true)]
		public int? SolicitudProfesionalDNI 
		{
			get { return GetColumnValue<int?>(Columns.SolicitudProfesionalDNI); }
			set { SetColumnValue(Columns.SolicitudProfesionalDNI, value); }
		}
		  
		[XmlAttribute("InformeProfesionalSSS")]
		[Bindable(true)]
		public int? InformeProfesionalSSS 
		{
			get { return GetColumnValue<int?>(Columns.InformeProfesionalSSS); }
			set { SetColumnValue(Columns.InformeProfesionalSSS, value); }
		}
		  
		[XmlAttribute("InformeProfesionalDNI")]
		[Bindable(true)]
		public int? InformeProfesionalDNI 
		{
			get { return GetColumnValue<int?>(Columns.InformeProfesionalDNI); }
			set { SetColumnValue(Columns.InformeProfesionalDNI, value); }
		}
		  
		[XmlAttribute("Equipo")]
		[Bindable(true)]
		public string Equipo 
		{
			get { return GetColumnValue<string>(Columns.Equipo); }
			set { SetColumnValue(Columns.Equipo, value); }
		}
		  
		[XmlAttribute("MotivoConsulta")]
		[Bindable(true)]
		public string MotivoConsulta 
		{
			get { return GetColumnValue<string>(Columns.MotivoConsulta); }
			set { SetColumnValue(Columns.MotivoConsulta, value); }
		}
		  
		[XmlAttribute("Protocolo")]
		[Bindable(true)]
		public int? Protocolo 
		{
			get { return GetColumnValue<int?>(Columns.Protocolo); }
			set { SetColumnValue(Columns.Protocolo, value); }
		}
		  
		[XmlAttribute("ProtocoloPrefijo")]
		[Bindable(true)]
		public string ProtocoloPrefijo 
		{
			get { return GetColumnValue<string>(Columns.ProtocoloPrefijo); }
			set { SetColumnValue(Columns.ProtocoloPrefijo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamEstudiosHospitalProvincial
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.SolicitudCentroSalud); }
			set { SetColumnValue("SolicitudCentroSalud", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a MamTipoEstudio ActiveRecord object related to this MamEstudiosHospitalProvincial
		/// 
		/// </summary>
		public DalSic.MamTipoEstudio MamTipoEstudio
		{
			get { return DalSic.MamTipoEstudio.FetchByID(this.IdTipoEstudio); }
			set { SetColumnValue("idTipoEstudio", value.IdTipoEstudio); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamEstudiosHospitalProvincial
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.SolicitudProfesional); }
			set { SetColumnValue("SolicitudProfesional", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdHistoria,string varTipoDocumento,int? varDocumento,string varApellido,string varNombre,DateTime? varFechaNacimiento,string varObraSocial,string varInformacionContacto,string varDireccion,int? varSolicitudProfesional,int? varSolicitudCentroSalud,int? varBiradIzquierdo,int? varBiradDerecho,int? varBiradDefinitivo,DateTime? varFechaPlaca,DateTime? varFechaInforme,string varInforme,int? varIdMotivo,string varMotivo,int? varIdMotivoSitam,int? varIdTipoEstudio,int? varIdTipoEstudioSitam,string varObservaciones,bool varPasadoSips,bool varActivo,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varInformeProfesional,string varLocalidad,string varInformacionCelular,int? varSolicitudProfesionalSSS,int? varSolicitudProfesionalDNI,int? varInformeProfesionalSSS,int? varInformeProfesionalDNI,string varEquipo,string varMotivoConsulta,int? varProtocolo,string varProtocoloPrefijo)
		{
			MamEstudiosHospitalProvincial item = new MamEstudiosHospitalProvincial();
			
			item.IdHistoria = varIdHistoria;
			
			item.TipoDocumento = varTipoDocumento;
			
			item.Documento = varDocumento;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.ObraSocial = varObraSocial;
			
			item.InformacionContacto = varInformacionContacto;
			
			item.Direccion = varDireccion;
			
			item.SolicitudProfesional = varSolicitudProfesional;
			
			item.SolicitudCentroSalud = varSolicitudCentroSalud;
			
			item.BiradIzquierdo = varBiradIzquierdo;
			
			item.BiradDerecho = varBiradDerecho;
			
			item.BiradDefinitivo = varBiradDefinitivo;
			
			item.FechaPlaca = varFechaPlaca;
			
			item.FechaInforme = varFechaInforme;
			
			item.Informe = varInforme;
			
			item.IdMotivo = varIdMotivo;
			
			item.Motivo = varMotivo;
			
			item.IdMotivoSitam = varIdMotivoSitam;
			
			item.IdTipoEstudio = varIdTipoEstudio;
			
			item.IdTipoEstudioSitam = varIdTipoEstudioSitam;
			
			item.Observaciones = varObservaciones;
			
			item.PasadoSips = varPasadoSips;
			
			item.Activo = varActivo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.InformeProfesional = varInformeProfesional;
			
			item.Localidad = varLocalidad;
			
			item.InformacionCelular = varInformacionCelular;
			
			item.SolicitudProfesionalSSS = varSolicitudProfesionalSSS;
			
			item.SolicitudProfesionalDNI = varSolicitudProfesionalDNI;
			
			item.InformeProfesionalSSS = varInformeProfesionalSSS;
			
			item.InformeProfesionalDNI = varInformeProfesionalDNI;
			
			item.Equipo = varEquipo;
			
			item.MotivoConsulta = varMotivoConsulta;
			
			item.Protocolo = varProtocolo;
			
			item.ProtocoloPrefijo = varProtocoloPrefijo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMamografiaHP,int? varIdHistoria,string varTipoDocumento,int? varDocumento,string varApellido,string varNombre,DateTime? varFechaNacimiento,string varObraSocial,string varInformacionContacto,string varDireccion,int? varSolicitudProfesional,int? varSolicitudCentroSalud,int? varBiradIzquierdo,int? varBiradDerecho,int? varBiradDefinitivo,DateTime? varFechaPlaca,DateTime? varFechaInforme,string varInforme,int? varIdMotivo,string varMotivo,int? varIdMotivoSitam,int? varIdTipoEstudio,int? varIdTipoEstudioSitam,string varObservaciones,bool varPasadoSips,bool varActivo,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varInformeProfesional,string varLocalidad,string varInformacionCelular,int? varSolicitudProfesionalSSS,int? varSolicitudProfesionalDNI,int? varInformeProfesionalSSS,int? varInformeProfesionalDNI,string varEquipo,string varMotivoConsulta,int? varProtocolo,string varProtocoloPrefijo)
		{
			MamEstudiosHospitalProvincial item = new MamEstudiosHospitalProvincial();
			
				item.IdMamografiaHP = varIdMamografiaHP;
			
				item.IdHistoria = varIdHistoria;
			
				item.TipoDocumento = varTipoDocumento;
			
				item.Documento = varDocumento;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.ObraSocial = varObraSocial;
			
				item.InformacionContacto = varInformacionContacto;
			
				item.Direccion = varDireccion;
			
				item.SolicitudProfesional = varSolicitudProfesional;
			
				item.SolicitudCentroSalud = varSolicitudCentroSalud;
			
				item.BiradIzquierdo = varBiradIzquierdo;
			
				item.BiradDerecho = varBiradDerecho;
			
				item.BiradDefinitivo = varBiradDefinitivo;
			
				item.FechaPlaca = varFechaPlaca;
			
				item.FechaInforme = varFechaInforme;
			
				item.Informe = varInforme;
			
				item.IdMotivo = varIdMotivo;
			
				item.Motivo = varMotivo;
			
				item.IdMotivoSitam = varIdMotivoSitam;
			
				item.IdTipoEstudio = varIdTipoEstudio;
			
				item.IdTipoEstudioSitam = varIdTipoEstudioSitam;
			
				item.Observaciones = varObservaciones;
			
				item.PasadoSips = varPasadoSips;
			
				item.Activo = varActivo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.InformeProfesional = varInformeProfesional;
			
				item.Localidad = varLocalidad;
			
				item.InformacionCelular = varInformacionCelular;
			
				item.SolicitudProfesionalSSS = varSolicitudProfesionalSSS;
			
				item.SolicitudProfesionalDNI = varSolicitudProfesionalDNI;
			
				item.InformeProfesionalSSS = varInformeProfesionalSSS;
			
				item.InformeProfesionalDNI = varInformeProfesionalDNI;
			
				item.Equipo = varEquipo;
			
				item.MotivoConsulta = varMotivoConsulta;
			
				item.Protocolo = varProtocolo;
			
				item.ProtocoloPrefijo = varProtocoloPrefijo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMamografiaHPColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdHistoriaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocumentoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ObraSocialColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn InformacionContactoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SolicitudProfesionalColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SolicitudCentroSaludColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn BiradIzquierdoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn BiradDerechoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn BiradDefinitivoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPlacaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInformeColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoSitamColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEstudioColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEstudioSitamColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn PasadoSipsColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeProfesionalColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn InformacionCelularColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn SolicitudProfesionalSSSColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn SolicitudProfesionalDNIColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeProfesionalSSSColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeProfesionalDNIColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn EquipoColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivoConsultaColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn ProtocoloColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn ProtocoloPrefijoColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMamografiaHP = @"idMamografiaHP";
			 public static string IdHistoria = @"idHistoria";
			 public static string TipoDocumento = @"tipoDocumento";
			 public static string Documento = @"Documento";
			 public static string Apellido = @"Apellido";
			 public static string Nombre = @"Nombre";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string ObraSocial = @"obraSocial";
			 public static string InformacionContacto = @"informacionContacto";
			 public static string Direccion = @"Direccion";
			 public static string SolicitudProfesional = @"SolicitudProfesional";
			 public static string SolicitudCentroSalud = @"SolicitudCentroSalud";
			 public static string BiradIzquierdo = @"BiradIzquierdo";
			 public static string BiradDerecho = @"BiradDerecho";
			 public static string BiradDefinitivo = @"BiradDefinitivo";
			 public static string FechaPlaca = @"fechaPlaca";
			 public static string FechaInforme = @"fechaInforme";
			 public static string Informe = @"informe";
			 public static string IdMotivo = @"idMotivo";
			 public static string Motivo = @"motivo";
			 public static string IdMotivoSitam = @"idMotivoSitam";
			 public static string IdTipoEstudio = @"idTipoEstudio";
			 public static string IdTipoEstudioSitam = @"idTipoEstudioSitam";
			 public static string Observaciones = @"observaciones";
			 public static string PasadoSips = @"pasadoSips";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string InformeProfesional = @"informeProfesional";
			 public static string Localidad = @"localidad";
			 public static string InformacionCelular = @"informacionCelular";
			 public static string SolicitudProfesionalSSS = @"solicitudProfesionalSSS";
			 public static string SolicitudProfesionalDNI = @"solicitudProfesionalDNI";
			 public static string InformeProfesionalSSS = @"informeProfesionalSSS";
			 public static string InformeProfesionalDNI = @"informeProfesionalDNI";
			 public static string Equipo = @"equipo";
			 public static string MotivoConsulta = @"motivoConsulta";
			 public static string Protocolo = @"protocolo";
			 public static string ProtocoloPrefijo = @"protocoloPrefijo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
