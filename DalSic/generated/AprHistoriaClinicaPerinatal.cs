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
	/// Strongly-typed collection for the AprHistoriaClinicaPerinatal class.
	/// </summary>
    [Serializable]
	public partial class AprHistoriaClinicaPerinatalCollection : ActiveList<AprHistoriaClinicaPerinatal, AprHistoriaClinicaPerinatalCollection>
	{	   
		public AprHistoriaClinicaPerinatalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprHistoriaClinicaPerinatalCollection</returns>
		public AprHistoriaClinicaPerinatalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprHistoriaClinicaPerinatal o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_HistoriaClinicaPerinatal table.
	/// </summary>
	[Serializable]
	public partial class AprHistoriaClinicaPerinatal : ActiveRecord<AprHistoriaClinicaPerinatal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprHistoriaClinicaPerinatal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprHistoriaClinicaPerinatal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprHistoriaClinicaPerinatal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprHistoriaClinicaPerinatal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_HistoriaClinicaPerinatal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHistoriaClinicaPerinatal = new TableSchema.TableColumn(schema);
				colvarIdHistoriaClinicaPerinatal.ColumnName = "idHistoriaClinicaPerinatal";
				colvarIdHistoriaClinicaPerinatal.DataType = DbType.Int32;
				colvarIdHistoriaClinicaPerinatal.MaxLength = 0;
				colvarIdHistoriaClinicaPerinatal.AutoIncrement = true;
				colvarIdHistoriaClinicaPerinatal.IsNullable = false;
				colvarIdHistoriaClinicaPerinatal.IsPrimaryKey = true;
				colvarIdHistoriaClinicaPerinatal.IsForeignKey = false;
				colvarIdHistoriaClinicaPerinatal.IsReadOnly = false;
				colvarIdHistoriaClinicaPerinatal.DefaultSetting = @"";
				colvarIdHistoriaClinicaPerinatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHistoriaClinicaPerinatal);
				
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
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "Apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = -1;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "Domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = -1;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarDni = new TableSchema.TableColumn(schema);
				colvarDni.ColumnName = "DNI";
				colvarDni.DataType = DbType.AnsiString;
				colvarDni.MaxLength = -1;
				colvarDni.AutoIncrement = false;
				colvarDni.IsNullable = true;
				colvarDni.IsPrimaryKey = false;
				colvarDni.IsForeignKey = false;
				colvarDni.IsReadOnly = false;
				colvarDni.DefaultSetting = @"";
				colvarDni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDni);
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "Localidad";
				colvarLocalidad.DataType = DbType.AnsiString;
				colvarLocalidad.MaxLength = -1;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "Telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = -1;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "FechaNacimiento";
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
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "Edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = true;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				colvarEdad.DefaultSetting = @"";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarDatosDeContacto = new TableSchema.TableColumn(schema);
				colvarDatosDeContacto.ColumnName = "DatosDeContacto";
				colvarDatosDeContacto.DataType = DbType.AnsiString;
				colvarDatosDeContacto.MaxLength = 300;
				colvarDatosDeContacto.AutoIncrement = false;
				colvarDatosDeContacto.IsNullable = true;
				colvarDatosDeContacto.IsPrimaryKey = false;
				colvarDatosDeContacto.IsForeignKey = false;
				colvarDatosDeContacto.IsReadOnly = false;
				colvarDatosDeContacto.DefaultSetting = @"";
				colvarDatosDeContacto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatosDeContacto);
				
				TableSchema.TableColumn colvarEdadMenor15Mayor35 = new TableSchema.TableColumn(schema);
				colvarEdadMenor15Mayor35.ColumnName = "EdadMenor15Mayor35";
				colvarEdadMenor15Mayor35.DataType = DbType.Boolean;
				colvarEdadMenor15Mayor35.MaxLength = 0;
				colvarEdadMenor15Mayor35.AutoIncrement = false;
				colvarEdadMenor15Mayor35.IsNullable = true;
				colvarEdadMenor15Mayor35.IsPrimaryKey = false;
				colvarEdadMenor15Mayor35.IsForeignKey = false;
				colvarEdadMenor15Mayor35.IsReadOnly = false;
				colvarEdadMenor15Mayor35.DefaultSetting = @"";
				colvarEdadMenor15Mayor35.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadMenor15Mayor35);
				
				TableSchema.TableColumn colvarEtniaBlanca = new TableSchema.TableColumn(schema);
				colvarEtniaBlanca.ColumnName = "EtniaBlanca";
				colvarEtniaBlanca.DataType = DbType.Boolean;
				colvarEtniaBlanca.MaxLength = 0;
				colvarEtniaBlanca.AutoIncrement = false;
				colvarEtniaBlanca.IsNullable = true;
				colvarEtniaBlanca.IsPrimaryKey = false;
				colvarEtniaBlanca.IsForeignKey = false;
				colvarEtniaBlanca.IsReadOnly = false;
				colvarEtniaBlanca.DefaultSetting = @"";
				colvarEtniaBlanca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEtniaBlanca);
				
				TableSchema.TableColumn colvarEtniaIndigena = new TableSchema.TableColumn(schema);
				colvarEtniaIndigena.ColumnName = "EtniaIndigena";
				colvarEtniaIndigena.DataType = DbType.Boolean;
				colvarEtniaIndigena.MaxLength = 0;
				colvarEtniaIndigena.AutoIncrement = false;
				colvarEtniaIndigena.IsNullable = true;
				colvarEtniaIndigena.IsPrimaryKey = false;
				colvarEtniaIndigena.IsForeignKey = false;
				colvarEtniaIndigena.IsReadOnly = false;
				colvarEtniaIndigena.DefaultSetting = @"";
				colvarEtniaIndigena.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEtniaIndigena);
				
				TableSchema.TableColumn colvarEtniaMestiza = new TableSchema.TableColumn(schema);
				colvarEtniaMestiza.ColumnName = "EtniaMestiza";
				colvarEtniaMestiza.DataType = DbType.Boolean;
				colvarEtniaMestiza.MaxLength = 0;
				colvarEtniaMestiza.AutoIncrement = false;
				colvarEtniaMestiza.IsNullable = true;
				colvarEtniaMestiza.IsPrimaryKey = false;
				colvarEtniaMestiza.IsForeignKey = false;
				colvarEtniaMestiza.IsReadOnly = false;
				colvarEtniaMestiza.DefaultSetting = @"";
				colvarEtniaMestiza.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEtniaMestiza);
				
				TableSchema.TableColumn colvarEtniaNegra = new TableSchema.TableColumn(schema);
				colvarEtniaNegra.ColumnName = "EtniaNegra";
				colvarEtniaNegra.DataType = DbType.Boolean;
				colvarEtniaNegra.MaxLength = 0;
				colvarEtniaNegra.AutoIncrement = false;
				colvarEtniaNegra.IsNullable = true;
				colvarEtniaNegra.IsPrimaryKey = false;
				colvarEtniaNegra.IsForeignKey = false;
				colvarEtniaNegra.IsReadOnly = false;
				colvarEtniaNegra.DefaultSetting = @"";
				colvarEtniaNegra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEtniaNegra);
				
				TableSchema.TableColumn colvarEtniaOtra = new TableSchema.TableColumn(schema);
				colvarEtniaOtra.ColumnName = "EtniaOtra";
				colvarEtniaOtra.DataType = DbType.Boolean;
				colvarEtniaOtra.MaxLength = 0;
				colvarEtniaOtra.AutoIncrement = false;
				colvarEtniaOtra.IsNullable = true;
				colvarEtniaOtra.IsPrimaryKey = false;
				colvarEtniaOtra.IsForeignKey = false;
				colvarEtniaOtra.IsReadOnly = false;
				colvarEtniaOtra.DefaultSetting = @"";
				colvarEtniaOtra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEtniaOtra);
				
				TableSchema.TableColumn colvarAlfabetaSi = new TableSchema.TableColumn(schema);
				colvarAlfabetaSi.ColumnName = "AlfabetaSi";
				colvarAlfabetaSi.DataType = DbType.Boolean;
				colvarAlfabetaSi.MaxLength = 0;
				colvarAlfabetaSi.AutoIncrement = false;
				colvarAlfabetaSi.IsNullable = true;
				colvarAlfabetaSi.IsPrimaryKey = false;
				colvarAlfabetaSi.IsForeignKey = false;
				colvarAlfabetaSi.IsReadOnly = false;
				colvarAlfabetaSi.DefaultSetting = @"";
				colvarAlfabetaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlfabetaSi);
				
				TableSchema.TableColumn colvarAlfabetaNo = new TableSchema.TableColumn(schema);
				colvarAlfabetaNo.ColumnName = "AlfabetaNo";
				colvarAlfabetaNo.DataType = DbType.Boolean;
				colvarAlfabetaNo.MaxLength = 0;
				colvarAlfabetaNo.AutoIncrement = false;
				colvarAlfabetaNo.IsNullable = true;
				colvarAlfabetaNo.IsPrimaryKey = false;
				colvarAlfabetaNo.IsForeignKey = false;
				colvarAlfabetaNo.IsReadOnly = false;
				colvarAlfabetaNo.DefaultSetting = @"";
				colvarAlfabetaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlfabetaNo);
				
				TableSchema.TableColumn colvarEstudiosNinguno = new TableSchema.TableColumn(schema);
				colvarEstudiosNinguno.ColumnName = "EstudiosNinguno";
				colvarEstudiosNinguno.DataType = DbType.Boolean;
				colvarEstudiosNinguno.MaxLength = 0;
				colvarEstudiosNinguno.AutoIncrement = false;
				colvarEstudiosNinguno.IsNullable = true;
				colvarEstudiosNinguno.IsPrimaryKey = false;
				colvarEstudiosNinguno.IsForeignKey = false;
				colvarEstudiosNinguno.IsReadOnly = false;
				colvarEstudiosNinguno.DefaultSetting = @"";
				colvarEstudiosNinguno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosNinguno);
				
				TableSchema.TableColumn colvarEstudiosPrimario = new TableSchema.TableColumn(schema);
				colvarEstudiosPrimario.ColumnName = "EstudiosPrimario";
				colvarEstudiosPrimario.DataType = DbType.Boolean;
				colvarEstudiosPrimario.MaxLength = 0;
				colvarEstudiosPrimario.AutoIncrement = false;
				colvarEstudiosPrimario.IsNullable = true;
				colvarEstudiosPrimario.IsPrimaryKey = false;
				colvarEstudiosPrimario.IsForeignKey = false;
				colvarEstudiosPrimario.IsReadOnly = false;
				colvarEstudiosPrimario.DefaultSetting = @"";
				colvarEstudiosPrimario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosPrimario);
				
				TableSchema.TableColumn colvarEstudiosSecundario = new TableSchema.TableColumn(schema);
				colvarEstudiosSecundario.ColumnName = "EstudiosSecundario";
				colvarEstudiosSecundario.DataType = DbType.Boolean;
				colvarEstudiosSecundario.MaxLength = 0;
				colvarEstudiosSecundario.AutoIncrement = false;
				colvarEstudiosSecundario.IsNullable = true;
				colvarEstudiosSecundario.IsPrimaryKey = false;
				colvarEstudiosSecundario.IsForeignKey = false;
				colvarEstudiosSecundario.IsReadOnly = false;
				colvarEstudiosSecundario.DefaultSetting = @"";
				colvarEstudiosSecundario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosSecundario);
				
				TableSchema.TableColumn colvarEstudiosUniversitario = new TableSchema.TableColumn(schema);
				colvarEstudiosUniversitario.ColumnName = "EstudiosUniversitario";
				colvarEstudiosUniversitario.DataType = DbType.Boolean;
				colvarEstudiosUniversitario.MaxLength = 0;
				colvarEstudiosUniversitario.AutoIncrement = false;
				colvarEstudiosUniversitario.IsNullable = true;
				colvarEstudiosUniversitario.IsPrimaryKey = false;
				colvarEstudiosUniversitario.IsForeignKey = false;
				colvarEstudiosUniversitario.IsReadOnly = false;
				colvarEstudiosUniversitario.DefaultSetting = @"";
				colvarEstudiosUniversitario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosUniversitario);
				
				TableSchema.TableColumn colvarAñosMayorNivel = new TableSchema.TableColumn(schema);
				colvarAñosMayorNivel.ColumnName = "AñosMayorNivel";
				colvarAñosMayorNivel.DataType = DbType.Int32;
				colvarAñosMayorNivel.MaxLength = 0;
				colvarAñosMayorNivel.AutoIncrement = false;
				colvarAñosMayorNivel.IsNullable = true;
				colvarAñosMayorNivel.IsPrimaryKey = false;
				colvarAñosMayorNivel.IsForeignKey = false;
				colvarAñosMayorNivel.IsReadOnly = false;
				colvarAñosMayorNivel.DefaultSetting = @"";
				colvarAñosMayorNivel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAñosMayorNivel);
				
				TableSchema.TableColumn colvarEstadoCivilCasada = new TableSchema.TableColumn(schema);
				colvarEstadoCivilCasada.ColumnName = "EstadoCivilCasada";
				colvarEstadoCivilCasada.DataType = DbType.Boolean;
				colvarEstadoCivilCasada.MaxLength = 0;
				colvarEstadoCivilCasada.AutoIncrement = false;
				colvarEstadoCivilCasada.IsNullable = true;
				colvarEstadoCivilCasada.IsPrimaryKey = false;
				colvarEstadoCivilCasada.IsForeignKey = false;
				colvarEstadoCivilCasada.IsReadOnly = false;
				colvarEstadoCivilCasada.DefaultSetting = @"";
				colvarEstadoCivilCasada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoCivilCasada);
				
				TableSchema.TableColumn colvarEstadoCivilUnionEstable = new TableSchema.TableColumn(schema);
				colvarEstadoCivilUnionEstable.ColumnName = "EstadoCivilUnionEstable";
				colvarEstadoCivilUnionEstable.DataType = DbType.Boolean;
				colvarEstadoCivilUnionEstable.MaxLength = 0;
				colvarEstadoCivilUnionEstable.AutoIncrement = false;
				colvarEstadoCivilUnionEstable.IsNullable = true;
				colvarEstadoCivilUnionEstable.IsPrimaryKey = false;
				colvarEstadoCivilUnionEstable.IsForeignKey = false;
				colvarEstadoCivilUnionEstable.IsReadOnly = false;
				colvarEstadoCivilUnionEstable.DefaultSetting = @"";
				colvarEstadoCivilUnionEstable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoCivilUnionEstable);
				
				TableSchema.TableColumn colvarEstadoCivilSoltera = new TableSchema.TableColumn(schema);
				colvarEstadoCivilSoltera.ColumnName = "EstadoCivilSoltera";
				colvarEstadoCivilSoltera.DataType = DbType.Boolean;
				colvarEstadoCivilSoltera.MaxLength = 0;
				colvarEstadoCivilSoltera.AutoIncrement = false;
				colvarEstadoCivilSoltera.IsNullable = true;
				colvarEstadoCivilSoltera.IsPrimaryKey = false;
				colvarEstadoCivilSoltera.IsForeignKey = false;
				colvarEstadoCivilSoltera.IsReadOnly = false;
				colvarEstadoCivilSoltera.DefaultSetting = @"";
				colvarEstadoCivilSoltera.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoCivilSoltera);
				
				TableSchema.TableColumn colvarEstadoCivilOtro = new TableSchema.TableColumn(schema);
				colvarEstadoCivilOtro.ColumnName = "EstadoCivilOtro";
				colvarEstadoCivilOtro.DataType = DbType.Boolean;
				colvarEstadoCivilOtro.MaxLength = 0;
				colvarEstadoCivilOtro.AutoIncrement = false;
				colvarEstadoCivilOtro.IsNullable = true;
				colvarEstadoCivilOtro.IsPrimaryKey = false;
				colvarEstadoCivilOtro.IsForeignKey = false;
				colvarEstadoCivilOtro.IsReadOnly = false;
				colvarEstadoCivilOtro.DefaultSetting = @"";
				colvarEstadoCivilOtro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoCivilOtro);
				
				TableSchema.TableColumn colvarViveSolaSi = new TableSchema.TableColumn(schema);
				colvarViveSolaSi.ColumnName = "ViveSolaSi";
				colvarViveSolaSi.DataType = DbType.Boolean;
				colvarViveSolaSi.MaxLength = 0;
				colvarViveSolaSi.AutoIncrement = false;
				colvarViveSolaSi.IsNullable = true;
				colvarViveSolaSi.IsPrimaryKey = false;
				colvarViveSolaSi.IsForeignKey = false;
				colvarViveSolaSi.IsReadOnly = false;
				colvarViveSolaSi.DefaultSetting = @"";
				colvarViveSolaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViveSolaSi);
				
				TableSchema.TableColumn colvarViveSolaNo = new TableSchema.TableColumn(schema);
				colvarViveSolaNo.ColumnName = "ViveSolaNo";
				colvarViveSolaNo.DataType = DbType.Boolean;
				colvarViveSolaNo.MaxLength = 0;
				colvarViveSolaNo.AutoIncrement = false;
				colvarViveSolaNo.IsNullable = true;
				colvarViveSolaNo.IsPrimaryKey = false;
				colvarViveSolaNo.IsForeignKey = false;
				colvarViveSolaNo.IsReadOnly = false;
				colvarViveSolaNo.DefaultSetting = @"";
				colvarViveSolaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViveSolaNo);
				
				TableSchema.TableColumn colvarLugarControlPerinatal = new TableSchema.TableColumn(schema);
				colvarLugarControlPerinatal.ColumnName = "LugarControlPerinatal";
				colvarLugarControlPerinatal.DataType = DbType.AnsiString;
				colvarLugarControlPerinatal.MaxLength = -1;
				colvarLugarControlPerinatal.AutoIncrement = false;
				colvarLugarControlPerinatal.IsNullable = true;
				colvarLugarControlPerinatal.IsPrimaryKey = false;
				colvarLugarControlPerinatal.IsForeignKey = false;
				colvarLugarControlPerinatal.IsReadOnly = false;
				colvarLugarControlPerinatal.DefaultSetting = @"";
				colvarLugarControlPerinatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLugarControlPerinatal);
				
				TableSchema.TableColumn colvarLugarPartoAborto = new TableSchema.TableColumn(schema);
				colvarLugarPartoAborto.ColumnName = "LugarPartoAborto";
				colvarLugarPartoAborto.DataType = DbType.AnsiString;
				colvarLugarPartoAborto.MaxLength = -1;
				colvarLugarPartoAborto.AutoIncrement = false;
				colvarLugarPartoAborto.IsNullable = true;
				colvarLugarPartoAborto.IsPrimaryKey = false;
				colvarLugarPartoAborto.IsForeignKey = false;
				colvarLugarPartoAborto.IsReadOnly = false;
				colvarLugarPartoAborto.DefaultSetting = @"";
				colvarLugarPartoAborto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLugarPartoAborto);
				
				TableSchema.TableColumn colvarAntFamTBCSi = new TableSchema.TableColumn(schema);
				colvarAntFamTBCSi.ColumnName = "AntFamTBCSi";
				colvarAntFamTBCSi.DataType = DbType.Boolean;
				colvarAntFamTBCSi.MaxLength = 0;
				colvarAntFamTBCSi.AutoIncrement = false;
				colvarAntFamTBCSi.IsNullable = true;
				colvarAntFamTBCSi.IsPrimaryKey = false;
				colvarAntFamTBCSi.IsForeignKey = false;
				colvarAntFamTBCSi.IsReadOnly = false;
				colvarAntFamTBCSi.DefaultSetting = @"";
				colvarAntFamTBCSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamTBCSi);
				
				TableSchema.TableColumn colvarAntFamTBCNo = new TableSchema.TableColumn(schema);
				colvarAntFamTBCNo.ColumnName = "AntFamTBCNo";
				colvarAntFamTBCNo.DataType = DbType.Boolean;
				colvarAntFamTBCNo.MaxLength = 0;
				colvarAntFamTBCNo.AutoIncrement = false;
				colvarAntFamTBCNo.IsNullable = true;
				colvarAntFamTBCNo.IsPrimaryKey = false;
				colvarAntFamTBCNo.IsForeignKey = false;
				colvarAntFamTBCNo.IsReadOnly = false;
				colvarAntFamTBCNo.DefaultSetting = @"";
				colvarAntFamTBCNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamTBCNo);
				
				TableSchema.TableColumn colvarAntFamDiabetesSi = new TableSchema.TableColumn(schema);
				colvarAntFamDiabetesSi.ColumnName = "AntFamDiabetesSi";
				colvarAntFamDiabetesSi.DataType = DbType.Boolean;
				colvarAntFamDiabetesSi.MaxLength = 0;
				colvarAntFamDiabetesSi.AutoIncrement = false;
				colvarAntFamDiabetesSi.IsNullable = true;
				colvarAntFamDiabetesSi.IsPrimaryKey = false;
				colvarAntFamDiabetesSi.IsForeignKey = false;
				colvarAntFamDiabetesSi.IsReadOnly = false;
				colvarAntFamDiabetesSi.DefaultSetting = @"";
				colvarAntFamDiabetesSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamDiabetesSi);
				
				TableSchema.TableColumn colvarAntFamDiabetesNo = new TableSchema.TableColumn(schema);
				colvarAntFamDiabetesNo.ColumnName = "AntFamDiabetesNo";
				colvarAntFamDiabetesNo.DataType = DbType.Boolean;
				colvarAntFamDiabetesNo.MaxLength = 0;
				colvarAntFamDiabetesNo.AutoIncrement = false;
				colvarAntFamDiabetesNo.IsNullable = true;
				colvarAntFamDiabetesNo.IsPrimaryKey = false;
				colvarAntFamDiabetesNo.IsForeignKey = false;
				colvarAntFamDiabetesNo.IsReadOnly = false;
				colvarAntFamDiabetesNo.DefaultSetting = @"";
				colvarAntFamDiabetesNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamDiabetesNo);
				
				TableSchema.TableColumn colvarAntFamHipertensionSi = new TableSchema.TableColumn(schema);
				colvarAntFamHipertensionSi.ColumnName = "AntFamHipertensionSi";
				colvarAntFamHipertensionSi.DataType = DbType.Boolean;
				colvarAntFamHipertensionSi.MaxLength = 0;
				colvarAntFamHipertensionSi.AutoIncrement = false;
				colvarAntFamHipertensionSi.IsNullable = true;
				colvarAntFamHipertensionSi.IsPrimaryKey = false;
				colvarAntFamHipertensionSi.IsForeignKey = false;
				colvarAntFamHipertensionSi.IsReadOnly = false;
				colvarAntFamHipertensionSi.DefaultSetting = @"";
				colvarAntFamHipertensionSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamHipertensionSi);
				
				TableSchema.TableColumn colvarAntFamHipertensionNo = new TableSchema.TableColumn(schema);
				colvarAntFamHipertensionNo.ColumnName = "AntFamHipertensionNo";
				colvarAntFamHipertensionNo.DataType = DbType.Boolean;
				colvarAntFamHipertensionNo.MaxLength = 0;
				colvarAntFamHipertensionNo.AutoIncrement = false;
				colvarAntFamHipertensionNo.IsNullable = true;
				colvarAntFamHipertensionNo.IsPrimaryKey = false;
				colvarAntFamHipertensionNo.IsForeignKey = false;
				colvarAntFamHipertensionNo.IsReadOnly = false;
				colvarAntFamHipertensionNo.DefaultSetting = @"";
				colvarAntFamHipertensionNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamHipertensionNo);
				
				TableSchema.TableColumn colvarAntFamInfeccionUrinariaSi = new TableSchema.TableColumn(schema);
				colvarAntFamInfeccionUrinariaSi.ColumnName = "AntFamInfeccionUrinariaSi";
				colvarAntFamInfeccionUrinariaSi.DataType = DbType.Boolean;
				colvarAntFamInfeccionUrinariaSi.MaxLength = 0;
				colvarAntFamInfeccionUrinariaSi.AutoIncrement = false;
				colvarAntFamInfeccionUrinariaSi.IsNullable = true;
				colvarAntFamInfeccionUrinariaSi.IsPrimaryKey = false;
				colvarAntFamInfeccionUrinariaSi.IsForeignKey = false;
				colvarAntFamInfeccionUrinariaSi.IsReadOnly = false;
				colvarAntFamInfeccionUrinariaSi.DefaultSetting = @"";
				colvarAntFamInfeccionUrinariaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamInfeccionUrinariaSi);
				
				TableSchema.TableColumn colvarAntFamInfeccionUrinariaNo = new TableSchema.TableColumn(schema);
				colvarAntFamInfeccionUrinariaNo.ColumnName = "AntFamInfeccionUrinariaNo";
				colvarAntFamInfeccionUrinariaNo.DataType = DbType.Boolean;
				colvarAntFamInfeccionUrinariaNo.MaxLength = 0;
				colvarAntFamInfeccionUrinariaNo.AutoIncrement = false;
				colvarAntFamInfeccionUrinariaNo.IsNullable = true;
				colvarAntFamInfeccionUrinariaNo.IsPrimaryKey = false;
				colvarAntFamInfeccionUrinariaNo.IsForeignKey = false;
				colvarAntFamInfeccionUrinariaNo.IsReadOnly = false;
				colvarAntFamInfeccionUrinariaNo.DefaultSetting = @"";
				colvarAntFamInfeccionUrinariaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamInfeccionUrinariaNo);
				
				TableSchema.TableColumn colvarAntFamOtrasInfeccionesSi = new TableSchema.TableColumn(schema);
				colvarAntFamOtrasInfeccionesSi.ColumnName = "AntFamOtrasInfeccionesSi";
				colvarAntFamOtrasInfeccionesSi.DataType = DbType.Boolean;
				colvarAntFamOtrasInfeccionesSi.MaxLength = 0;
				colvarAntFamOtrasInfeccionesSi.AutoIncrement = false;
				colvarAntFamOtrasInfeccionesSi.IsNullable = true;
				colvarAntFamOtrasInfeccionesSi.IsPrimaryKey = false;
				colvarAntFamOtrasInfeccionesSi.IsForeignKey = false;
				colvarAntFamOtrasInfeccionesSi.IsReadOnly = false;
				colvarAntFamOtrasInfeccionesSi.DefaultSetting = @"";
				colvarAntFamOtrasInfeccionesSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamOtrasInfeccionesSi);
				
				TableSchema.TableColumn colvarAntFamOtrasInfeccionesNo = new TableSchema.TableColumn(schema);
				colvarAntFamOtrasInfeccionesNo.ColumnName = "AntFamOtrasInfeccionesNo";
				colvarAntFamOtrasInfeccionesNo.DataType = DbType.Boolean;
				colvarAntFamOtrasInfeccionesNo.MaxLength = 0;
				colvarAntFamOtrasInfeccionesNo.AutoIncrement = false;
				colvarAntFamOtrasInfeccionesNo.IsNullable = true;
				colvarAntFamOtrasInfeccionesNo.IsPrimaryKey = false;
				colvarAntFamOtrasInfeccionesNo.IsForeignKey = false;
				colvarAntFamOtrasInfeccionesNo.IsReadOnly = false;
				colvarAntFamOtrasInfeccionesNo.DefaultSetting = @"";
				colvarAntFamOtrasInfeccionesNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamOtrasInfeccionesNo);
				
				TableSchema.TableColumn colvarAntFamOtroSi = new TableSchema.TableColumn(schema);
				colvarAntFamOtroSi.ColumnName = "AntFamOtroSi";
				colvarAntFamOtroSi.DataType = DbType.Boolean;
				colvarAntFamOtroSi.MaxLength = 0;
				colvarAntFamOtroSi.AutoIncrement = false;
				colvarAntFamOtroSi.IsNullable = true;
				colvarAntFamOtroSi.IsPrimaryKey = false;
				colvarAntFamOtroSi.IsForeignKey = false;
				colvarAntFamOtroSi.IsReadOnly = false;
				colvarAntFamOtroSi.DefaultSetting = @"";
				colvarAntFamOtroSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamOtroSi);
				
				TableSchema.TableColumn colvarAntFamOtroNo = new TableSchema.TableColumn(schema);
				colvarAntFamOtroNo.ColumnName = "AntFamOtroNo";
				colvarAntFamOtroNo.DataType = DbType.Boolean;
				colvarAntFamOtroNo.MaxLength = 0;
				colvarAntFamOtroNo.AutoIncrement = false;
				colvarAntFamOtroNo.IsNullable = true;
				colvarAntFamOtroNo.IsPrimaryKey = false;
				colvarAntFamOtroNo.IsForeignKey = false;
				colvarAntFamOtroNo.IsReadOnly = false;
				colvarAntFamOtroNo.DefaultSetting = @"";
				colvarAntFamOtroNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntFamOtroNo);
				
				TableSchema.TableColumn colvarAntPerTBCSi = new TableSchema.TableColumn(schema);
				colvarAntPerTBCSi.ColumnName = "AntPerTBCSi";
				colvarAntPerTBCSi.DataType = DbType.Boolean;
				colvarAntPerTBCSi.MaxLength = 0;
				colvarAntPerTBCSi.AutoIncrement = false;
				colvarAntPerTBCSi.IsNullable = true;
				colvarAntPerTBCSi.IsPrimaryKey = false;
				colvarAntPerTBCSi.IsForeignKey = false;
				colvarAntPerTBCSi.IsReadOnly = false;
				colvarAntPerTBCSi.DefaultSetting = @"";
				colvarAntPerTBCSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerTBCSi);
				
				TableSchema.TableColumn colvarAntPerTBCNo = new TableSchema.TableColumn(schema);
				colvarAntPerTBCNo.ColumnName = "AntPerTBCNo";
				colvarAntPerTBCNo.DataType = DbType.Boolean;
				colvarAntPerTBCNo.MaxLength = 0;
				colvarAntPerTBCNo.AutoIncrement = false;
				colvarAntPerTBCNo.IsNullable = true;
				colvarAntPerTBCNo.IsPrimaryKey = false;
				colvarAntPerTBCNo.IsForeignKey = false;
				colvarAntPerTBCNo.IsReadOnly = false;
				colvarAntPerTBCNo.DefaultSetting = @"";
				colvarAntPerTBCNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerTBCNo);
				
				TableSchema.TableColumn colvarAntPerDiabetesI = new TableSchema.TableColumn(schema);
				colvarAntPerDiabetesI.ColumnName = "AntPerDiabetesI";
				colvarAntPerDiabetesI.DataType = DbType.Boolean;
				colvarAntPerDiabetesI.MaxLength = 0;
				colvarAntPerDiabetesI.AutoIncrement = false;
				colvarAntPerDiabetesI.IsNullable = true;
				colvarAntPerDiabetesI.IsPrimaryKey = false;
				colvarAntPerDiabetesI.IsForeignKey = false;
				colvarAntPerDiabetesI.IsReadOnly = false;
				colvarAntPerDiabetesI.DefaultSetting = @"";
				colvarAntPerDiabetesI.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerDiabetesI);
				
				TableSchema.TableColumn colvarAntPerDiabetesII = new TableSchema.TableColumn(schema);
				colvarAntPerDiabetesII.ColumnName = "AntPerDiabetesII";
				colvarAntPerDiabetesII.DataType = DbType.Boolean;
				colvarAntPerDiabetesII.MaxLength = 0;
				colvarAntPerDiabetesII.AutoIncrement = false;
				colvarAntPerDiabetesII.IsNullable = true;
				colvarAntPerDiabetesII.IsPrimaryKey = false;
				colvarAntPerDiabetesII.IsForeignKey = false;
				colvarAntPerDiabetesII.IsReadOnly = false;
				colvarAntPerDiabetesII.DefaultSetting = @"";
				colvarAntPerDiabetesII.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerDiabetesII);
				
				TableSchema.TableColumn colvarAntPerDiabetesG = new TableSchema.TableColumn(schema);
				colvarAntPerDiabetesG.ColumnName = "AntPerDiabetesG";
				colvarAntPerDiabetesG.DataType = DbType.Boolean;
				colvarAntPerDiabetesG.MaxLength = 0;
				colvarAntPerDiabetesG.AutoIncrement = false;
				colvarAntPerDiabetesG.IsNullable = true;
				colvarAntPerDiabetesG.IsPrimaryKey = false;
				colvarAntPerDiabetesG.IsForeignKey = false;
				colvarAntPerDiabetesG.IsReadOnly = false;
				colvarAntPerDiabetesG.DefaultSetting = @"";
				colvarAntPerDiabetesG.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerDiabetesG);
				
				TableSchema.TableColumn colvarAntPerDiabetesNo = new TableSchema.TableColumn(schema);
				colvarAntPerDiabetesNo.ColumnName = "AntPerDiabetesNo";
				colvarAntPerDiabetesNo.DataType = DbType.Boolean;
				colvarAntPerDiabetesNo.MaxLength = 0;
				colvarAntPerDiabetesNo.AutoIncrement = false;
				colvarAntPerDiabetesNo.IsNullable = true;
				colvarAntPerDiabetesNo.IsPrimaryKey = false;
				colvarAntPerDiabetesNo.IsForeignKey = false;
				colvarAntPerDiabetesNo.IsReadOnly = false;
				colvarAntPerDiabetesNo.DefaultSetting = @"";
				colvarAntPerDiabetesNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerDiabetesNo);
				
				TableSchema.TableColumn colvarAntPerHipertensionSi = new TableSchema.TableColumn(schema);
				colvarAntPerHipertensionSi.ColumnName = "AntPerHipertensionSi";
				colvarAntPerHipertensionSi.DataType = DbType.Boolean;
				colvarAntPerHipertensionSi.MaxLength = 0;
				colvarAntPerHipertensionSi.AutoIncrement = false;
				colvarAntPerHipertensionSi.IsNullable = true;
				colvarAntPerHipertensionSi.IsPrimaryKey = false;
				colvarAntPerHipertensionSi.IsForeignKey = false;
				colvarAntPerHipertensionSi.IsReadOnly = false;
				colvarAntPerHipertensionSi.DefaultSetting = @"";
				colvarAntPerHipertensionSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerHipertensionSi);
				
				TableSchema.TableColumn colvarAntPerHipertensionNo = new TableSchema.TableColumn(schema);
				colvarAntPerHipertensionNo.ColumnName = "AntPerHipertensionNo";
				colvarAntPerHipertensionNo.DataType = DbType.Boolean;
				colvarAntPerHipertensionNo.MaxLength = 0;
				colvarAntPerHipertensionNo.AutoIncrement = false;
				colvarAntPerHipertensionNo.IsNullable = true;
				colvarAntPerHipertensionNo.IsPrimaryKey = false;
				colvarAntPerHipertensionNo.IsForeignKey = false;
				colvarAntPerHipertensionNo.IsReadOnly = false;
				colvarAntPerHipertensionNo.DefaultSetting = @"";
				colvarAntPerHipertensionNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerHipertensionNo);
				
				TableSchema.TableColumn colvarAntPerInfeccionUrinariaSi = new TableSchema.TableColumn(schema);
				colvarAntPerInfeccionUrinariaSi.ColumnName = "AntPerInfeccionUrinariaSi";
				colvarAntPerInfeccionUrinariaSi.DataType = DbType.Boolean;
				colvarAntPerInfeccionUrinariaSi.MaxLength = 0;
				colvarAntPerInfeccionUrinariaSi.AutoIncrement = false;
				colvarAntPerInfeccionUrinariaSi.IsNullable = true;
				colvarAntPerInfeccionUrinariaSi.IsPrimaryKey = false;
				colvarAntPerInfeccionUrinariaSi.IsForeignKey = false;
				colvarAntPerInfeccionUrinariaSi.IsReadOnly = false;
				colvarAntPerInfeccionUrinariaSi.DefaultSetting = @"";
				colvarAntPerInfeccionUrinariaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerInfeccionUrinariaSi);
				
				TableSchema.TableColumn colvarAntPerInfeccionUrinariaNo = new TableSchema.TableColumn(schema);
				colvarAntPerInfeccionUrinariaNo.ColumnName = "AntPerInfeccionUrinariaNo";
				colvarAntPerInfeccionUrinariaNo.DataType = DbType.Boolean;
				colvarAntPerInfeccionUrinariaNo.MaxLength = 0;
				colvarAntPerInfeccionUrinariaNo.AutoIncrement = false;
				colvarAntPerInfeccionUrinariaNo.IsNullable = true;
				colvarAntPerInfeccionUrinariaNo.IsPrimaryKey = false;
				colvarAntPerInfeccionUrinariaNo.IsForeignKey = false;
				colvarAntPerInfeccionUrinariaNo.IsReadOnly = false;
				colvarAntPerInfeccionUrinariaNo.DefaultSetting = @"";
				colvarAntPerInfeccionUrinariaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerInfeccionUrinariaNo);
				
				TableSchema.TableColumn colvarAntPerOtrasInfeccionesSi = new TableSchema.TableColumn(schema);
				colvarAntPerOtrasInfeccionesSi.ColumnName = "AntPerOtrasInfeccionesSi";
				colvarAntPerOtrasInfeccionesSi.DataType = DbType.Boolean;
				colvarAntPerOtrasInfeccionesSi.MaxLength = 0;
				colvarAntPerOtrasInfeccionesSi.AutoIncrement = false;
				colvarAntPerOtrasInfeccionesSi.IsNullable = true;
				colvarAntPerOtrasInfeccionesSi.IsPrimaryKey = false;
				colvarAntPerOtrasInfeccionesSi.IsForeignKey = false;
				colvarAntPerOtrasInfeccionesSi.IsReadOnly = false;
				colvarAntPerOtrasInfeccionesSi.DefaultSetting = @"";
				colvarAntPerOtrasInfeccionesSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerOtrasInfeccionesSi);
				
				TableSchema.TableColumn colvarAntPerOtrasInfeccionesNo = new TableSchema.TableColumn(schema);
				colvarAntPerOtrasInfeccionesNo.ColumnName = "AntPerOtrasInfeccionesNo";
				colvarAntPerOtrasInfeccionesNo.DataType = DbType.Boolean;
				colvarAntPerOtrasInfeccionesNo.MaxLength = 0;
				colvarAntPerOtrasInfeccionesNo.AutoIncrement = false;
				colvarAntPerOtrasInfeccionesNo.IsNullable = true;
				colvarAntPerOtrasInfeccionesNo.IsPrimaryKey = false;
				colvarAntPerOtrasInfeccionesNo.IsForeignKey = false;
				colvarAntPerOtrasInfeccionesNo.IsReadOnly = false;
				colvarAntPerOtrasInfeccionesNo.DefaultSetting = @"";
				colvarAntPerOtrasInfeccionesNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerOtrasInfeccionesNo);
				
				TableSchema.TableColumn colvarAntPerOtroSi = new TableSchema.TableColumn(schema);
				colvarAntPerOtroSi.ColumnName = "AntPerOtroSi";
				colvarAntPerOtroSi.DataType = DbType.Boolean;
				colvarAntPerOtroSi.MaxLength = 0;
				colvarAntPerOtroSi.AutoIncrement = false;
				colvarAntPerOtroSi.IsNullable = true;
				colvarAntPerOtroSi.IsPrimaryKey = false;
				colvarAntPerOtroSi.IsForeignKey = false;
				colvarAntPerOtroSi.IsReadOnly = false;
				colvarAntPerOtroSi.DefaultSetting = @"";
				colvarAntPerOtroSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerOtroSi);
				
				TableSchema.TableColumn colvarAntPerOtroNo = new TableSchema.TableColumn(schema);
				colvarAntPerOtroNo.ColumnName = "AntPerOtroNo";
				colvarAntPerOtroNo.DataType = DbType.Boolean;
				colvarAntPerOtroNo.MaxLength = 0;
				colvarAntPerOtroNo.AutoIncrement = false;
				colvarAntPerOtroNo.IsNullable = true;
				colvarAntPerOtroNo.IsPrimaryKey = false;
				colvarAntPerOtroNo.IsForeignKey = false;
				colvarAntPerOtroNo.IsReadOnly = false;
				colvarAntPerOtroNo.DefaultSetting = @"";
				colvarAntPerOtroNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerOtroNo);
				
				TableSchema.TableColumn colvarAntPerInfertilidadSi = new TableSchema.TableColumn(schema);
				colvarAntPerInfertilidadSi.ColumnName = "AntPerInfertilidadSi";
				colvarAntPerInfertilidadSi.DataType = DbType.Boolean;
				colvarAntPerInfertilidadSi.MaxLength = 0;
				colvarAntPerInfertilidadSi.AutoIncrement = false;
				colvarAntPerInfertilidadSi.IsNullable = true;
				colvarAntPerInfertilidadSi.IsPrimaryKey = false;
				colvarAntPerInfertilidadSi.IsForeignKey = false;
				colvarAntPerInfertilidadSi.IsReadOnly = false;
				colvarAntPerInfertilidadSi.DefaultSetting = @"";
				colvarAntPerInfertilidadSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerInfertilidadSi);
				
				TableSchema.TableColumn colvarAntPerInfertilidadNo = new TableSchema.TableColumn(schema);
				colvarAntPerInfertilidadNo.ColumnName = "AntPerInfertilidadNo";
				colvarAntPerInfertilidadNo.DataType = DbType.Boolean;
				colvarAntPerInfertilidadNo.MaxLength = 0;
				colvarAntPerInfertilidadNo.AutoIncrement = false;
				colvarAntPerInfertilidadNo.IsNullable = true;
				colvarAntPerInfertilidadNo.IsPrimaryKey = false;
				colvarAntPerInfertilidadNo.IsForeignKey = false;
				colvarAntPerInfertilidadNo.IsReadOnly = false;
				colvarAntPerInfertilidadNo.DefaultSetting = @"";
				colvarAntPerInfertilidadNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerInfertilidadNo);
				
				TableSchema.TableColumn colvarAntPerCardiopatiaSi = new TableSchema.TableColumn(schema);
				colvarAntPerCardiopatiaSi.ColumnName = "AntPerCardiopatiaSi";
				colvarAntPerCardiopatiaSi.DataType = DbType.Boolean;
				colvarAntPerCardiopatiaSi.MaxLength = 0;
				colvarAntPerCardiopatiaSi.AutoIncrement = false;
				colvarAntPerCardiopatiaSi.IsNullable = true;
				colvarAntPerCardiopatiaSi.IsPrimaryKey = false;
				colvarAntPerCardiopatiaSi.IsForeignKey = false;
				colvarAntPerCardiopatiaSi.IsReadOnly = false;
				colvarAntPerCardiopatiaSi.DefaultSetting = @"";
				colvarAntPerCardiopatiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerCardiopatiaSi);
				
				TableSchema.TableColumn colvarAntPerCardiopatiaNo = new TableSchema.TableColumn(schema);
				colvarAntPerCardiopatiaNo.ColumnName = "AntPerCardiopatiaNo";
				colvarAntPerCardiopatiaNo.DataType = DbType.Boolean;
				colvarAntPerCardiopatiaNo.MaxLength = 0;
				colvarAntPerCardiopatiaNo.AutoIncrement = false;
				colvarAntPerCardiopatiaNo.IsNullable = true;
				colvarAntPerCardiopatiaNo.IsPrimaryKey = false;
				colvarAntPerCardiopatiaNo.IsForeignKey = false;
				colvarAntPerCardiopatiaNo.IsReadOnly = false;
				colvarAntPerCardiopatiaNo.DefaultSetting = @"";
				colvarAntPerCardiopatiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerCardiopatiaNo);
				
				TableSchema.TableColumn colvarAntPerNefropatiaSi = new TableSchema.TableColumn(schema);
				colvarAntPerNefropatiaSi.ColumnName = "AntPerNefropatiaSi";
				colvarAntPerNefropatiaSi.DataType = DbType.Boolean;
				colvarAntPerNefropatiaSi.MaxLength = 0;
				colvarAntPerNefropatiaSi.AutoIncrement = false;
				colvarAntPerNefropatiaSi.IsNullable = true;
				colvarAntPerNefropatiaSi.IsPrimaryKey = false;
				colvarAntPerNefropatiaSi.IsForeignKey = false;
				colvarAntPerNefropatiaSi.IsReadOnly = false;
				colvarAntPerNefropatiaSi.DefaultSetting = @"";
				colvarAntPerNefropatiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerNefropatiaSi);
				
				TableSchema.TableColumn colvarAntPerNefropatiaNo = new TableSchema.TableColumn(schema);
				colvarAntPerNefropatiaNo.ColumnName = "AntPerNefropatiaNo";
				colvarAntPerNefropatiaNo.DataType = DbType.Boolean;
				colvarAntPerNefropatiaNo.MaxLength = 0;
				colvarAntPerNefropatiaNo.AutoIncrement = false;
				colvarAntPerNefropatiaNo.IsNullable = true;
				colvarAntPerNefropatiaNo.IsPrimaryKey = false;
				colvarAntPerNefropatiaNo.IsForeignKey = false;
				colvarAntPerNefropatiaNo.IsReadOnly = false;
				colvarAntPerNefropatiaNo.DefaultSetting = @"";
				colvarAntPerNefropatiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerNefropatiaNo);
				
				TableSchema.TableColumn colvarAntPerViolenciaSi = new TableSchema.TableColumn(schema);
				colvarAntPerViolenciaSi.ColumnName = "AntPerViolenciaSi";
				colvarAntPerViolenciaSi.DataType = DbType.Boolean;
				colvarAntPerViolenciaSi.MaxLength = 0;
				colvarAntPerViolenciaSi.AutoIncrement = false;
				colvarAntPerViolenciaSi.IsNullable = true;
				colvarAntPerViolenciaSi.IsPrimaryKey = false;
				colvarAntPerViolenciaSi.IsForeignKey = false;
				colvarAntPerViolenciaSi.IsReadOnly = false;
				colvarAntPerViolenciaSi.DefaultSetting = @"";
				colvarAntPerViolenciaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerViolenciaSi);
				
				TableSchema.TableColumn colvarAntPerViolenciaNo = new TableSchema.TableColumn(schema);
				colvarAntPerViolenciaNo.ColumnName = "AntPerViolenciaNo";
				colvarAntPerViolenciaNo.DataType = DbType.Boolean;
				colvarAntPerViolenciaNo.MaxLength = 0;
				colvarAntPerViolenciaNo.AutoIncrement = false;
				colvarAntPerViolenciaNo.IsNullable = true;
				colvarAntPerViolenciaNo.IsPrimaryKey = false;
				colvarAntPerViolenciaNo.IsForeignKey = false;
				colvarAntPerViolenciaNo.IsReadOnly = false;
				colvarAntPerViolenciaNo.DefaultSetting = @"";
				colvarAntPerViolenciaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerViolenciaNo);
				
				TableSchema.TableColumn colvarAntPerAlergiaMedicamentoSi = new TableSchema.TableColumn(schema);
				colvarAntPerAlergiaMedicamentoSi.ColumnName = "AntPerAlergiaMedicamentoSi";
				colvarAntPerAlergiaMedicamentoSi.DataType = DbType.Boolean;
				colvarAntPerAlergiaMedicamentoSi.MaxLength = 0;
				colvarAntPerAlergiaMedicamentoSi.AutoIncrement = false;
				colvarAntPerAlergiaMedicamentoSi.IsNullable = true;
				colvarAntPerAlergiaMedicamentoSi.IsPrimaryKey = false;
				colvarAntPerAlergiaMedicamentoSi.IsForeignKey = false;
				colvarAntPerAlergiaMedicamentoSi.IsReadOnly = false;
				colvarAntPerAlergiaMedicamentoSi.DefaultSetting = @"";
				colvarAntPerAlergiaMedicamentoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerAlergiaMedicamentoSi);
				
				TableSchema.TableColumn colvarAntPerAlergiaMedicamentoNo = new TableSchema.TableColumn(schema);
				colvarAntPerAlergiaMedicamentoNo.ColumnName = "AntPerAlergiaMedicamentoNo";
				colvarAntPerAlergiaMedicamentoNo.DataType = DbType.Boolean;
				colvarAntPerAlergiaMedicamentoNo.MaxLength = 0;
				colvarAntPerAlergiaMedicamentoNo.AutoIncrement = false;
				colvarAntPerAlergiaMedicamentoNo.IsNullable = true;
				colvarAntPerAlergiaMedicamentoNo.IsPrimaryKey = false;
				colvarAntPerAlergiaMedicamentoNo.IsForeignKey = false;
				colvarAntPerAlergiaMedicamentoNo.IsReadOnly = false;
				colvarAntPerAlergiaMedicamentoNo.DefaultSetting = @"";
				colvarAntPerAlergiaMedicamentoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntPerAlergiaMedicamentoNo);
				
				TableSchema.TableColumn colvarAntecedentesObservacion = new TableSchema.TableColumn(schema);
				colvarAntecedentesObservacion.ColumnName = "AntecedentesObservacion";
				colvarAntecedentesObservacion.DataType = DbType.AnsiString;
				colvarAntecedentesObservacion.MaxLength = -1;
				colvarAntecedentesObservacion.AutoIncrement = false;
				colvarAntecedentesObservacion.IsNullable = true;
				colvarAntecedentesObservacion.IsPrimaryKey = false;
				colvarAntecedentesObservacion.IsForeignKey = false;
				colvarAntecedentesObservacion.IsReadOnly = false;
				colvarAntecedentesObservacion.DefaultSetting = @"";
				colvarAntecedentesObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecedentesObservacion);
				
				TableSchema.TableColumn colvarGestasPrevias = new TableSchema.TableColumn(schema);
				colvarGestasPrevias.ColumnName = "GestasPrevias";
				colvarGestasPrevias.DataType = DbType.Int32;
				colvarGestasPrevias.MaxLength = 0;
				colvarGestasPrevias.AutoIncrement = false;
				colvarGestasPrevias.IsNullable = true;
				colvarGestasPrevias.IsPrimaryKey = false;
				colvarGestasPrevias.IsForeignKey = false;
				colvarGestasPrevias.IsReadOnly = false;
				colvarGestasPrevias.DefaultSetting = @"";
				colvarGestasPrevias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGestasPrevias);
				
				TableSchema.TableColumn colvarAbortos = new TableSchema.TableColumn(schema);
				colvarAbortos.ColumnName = "Abortos";
				colvarAbortos.DataType = DbType.Int32;
				colvarAbortos.MaxLength = 0;
				colvarAbortos.AutoIncrement = false;
				colvarAbortos.IsNullable = true;
				colvarAbortos.IsPrimaryKey = false;
				colvarAbortos.IsForeignKey = false;
				colvarAbortos.IsReadOnly = false;
				colvarAbortos.DefaultSetting = @"";
				colvarAbortos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAbortos);
				
				TableSchema.TableColumn colvarEmbEctopicos = new TableSchema.TableColumn(schema);
				colvarEmbEctopicos.ColumnName = "EmbEctopicos";
				colvarEmbEctopicos.DataType = DbType.Int32;
				colvarEmbEctopicos.MaxLength = 0;
				colvarEmbEctopicos.AutoIncrement = false;
				colvarEmbEctopicos.IsNullable = true;
				colvarEmbEctopicos.IsPrimaryKey = false;
				colvarEmbEctopicos.IsForeignKey = false;
				colvarEmbEctopicos.IsReadOnly = false;
				colvarEmbEctopicos.DefaultSetting = @"";
				colvarEmbEctopicos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbEctopicos);
				
				TableSchema.TableColumn colvarAbortos3concecutivos = new TableSchema.TableColumn(schema);
				colvarAbortos3concecutivos.ColumnName = "Abortos3concecutivos";
				colvarAbortos3concecutivos.DataType = DbType.Boolean;
				colvarAbortos3concecutivos.MaxLength = 0;
				colvarAbortos3concecutivos.AutoIncrement = false;
				colvarAbortos3concecutivos.IsNullable = true;
				colvarAbortos3concecutivos.IsPrimaryKey = false;
				colvarAbortos3concecutivos.IsForeignKey = false;
				colvarAbortos3concecutivos.IsReadOnly = false;
				colvarAbortos3concecutivos.DefaultSetting = @"";
				colvarAbortos3concecutivos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAbortos3concecutivos);
				
				TableSchema.TableColumn colvarPartos = new TableSchema.TableColumn(schema);
				colvarPartos.ColumnName = "Partos";
				colvarPartos.DataType = DbType.Int32;
				colvarPartos.MaxLength = 0;
				colvarPartos.AutoIncrement = false;
				colvarPartos.IsNullable = true;
				colvarPartos.IsPrimaryKey = false;
				colvarPartos.IsForeignKey = false;
				colvarPartos.IsReadOnly = false;
				colvarPartos.DefaultSetting = @"";
				colvarPartos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPartos);
				
				TableSchema.TableColumn colvarPartosVaginales = new TableSchema.TableColumn(schema);
				colvarPartosVaginales.ColumnName = "PartosVaginales";
				colvarPartosVaginales.DataType = DbType.Int32;
				colvarPartosVaginales.MaxLength = 0;
				colvarPartosVaginales.AutoIncrement = false;
				colvarPartosVaginales.IsNullable = true;
				colvarPartosVaginales.IsPrimaryKey = false;
				colvarPartosVaginales.IsForeignKey = false;
				colvarPartosVaginales.IsReadOnly = false;
				colvarPartosVaginales.DefaultSetting = @"";
				colvarPartosVaginales.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPartosVaginales);
				
				TableSchema.TableColumn colvarCesareas = new TableSchema.TableColumn(schema);
				colvarCesareas.ColumnName = "Cesareas";
				colvarCesareas.DataType = DbType.Int32;
				colvarCesareas.MaxLength = 0;
				colvarCesareas.AutoIncrement = false;
				colvarCesareas.IsNullable = true;
				colvarCesareas.IsPrimaryKey = false;
				colvarCesareas.IsForeignKey = false;
				colvarCesareas.IsReadOnly = false;
				colvarCesareas.DefaultSetting = @"";
				colvarCesareas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCesareas);
				
				TableSchema.TableColumn colvarNacidosVivos = new TableSchema.TableColumn(schema);
				colvarNacidosVivos.ColumnName = "NacidosVivos";
				colvarNacidosVivos.DataType = DbType.Int32;
				colvarNacidosVivos.MaxLength = 0;
				colvarNacidosVivos.AutoIncrement = false;
				colvarNacidosVivos.IsNullable = true;
				colvarNacidosVivos.IsPrimaryKey = false;
				colvarNacidosVivos.IsForeignKey = false;
				colvarNacidosVivos.IsReadOnly = false;
				colvarNacidosVivos.DefaultSetting = @"";
				colvarNacidosVivos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNacidosVivos);
				
				TableSchema.TableColumn colvarNacidosMuertos = new TableSchema.TableColumn(schema);
				colvarNacidosMuertos.ColumnName = "NacidosMuertos";
				colvarNacidosMuertos.DataType = DbType.Int32;
				colvarNacidosMuertos.MaxLength = 0;
				colvarNacidosMuertos.AutoIncrement = false;
				colvarNacidosMuertos.IsNullable = true;
				colvarNacidosMuertos.IsPrimaryKey = false;
				colvarNacidosMuertos.IsForeignKey = false;
				colvarNacidosMuertos.IsReadOnly = false;
				colvarNacidosMuertos.DefaultSetting = @"";
				colvarNacidosMuertos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNacidosMuertos);
				
				TableSchema.TableColumn colvarViven = new TableSchema.TableColumn(schema);
				colvarViven.ColumnName = "Viven";
				colvarViven.DataType = DbType.Int32;
				colvarViven.MaxLength = 0;
				colvarViven.AutoIncrement = false;
				colvarViven.IsNullable = true;
				colvarViven.IsPrimaryKey = false;
				colvarViven.IsForeignKey = false;
				colvarViven.IsReadOnly = false;
				colvarViven.DefaultSetting = @"";
				colvarViven.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViven);
				
				TableSchema.TableColumn colvarMuertosPrimerSemana = new TableSchema.TableColumn(schema);
				colvarMuertosPrimerSemana.ColumnName = "MuertosPrimerSemana";
				colvarMuertosPrimerSemana.DataType = DbType.Int32;
				colvarMuertosPrimerSemana.MaxLength = 0;
				colvarMuertosPrimerSemana.AutoIncrement = false;
				colvarMuertosPrimerSemana.IsNullable = true;
				colvarMuertosPrimerSemana.IsPrimaryKey = false;
				colvarMuertosPrimerSemana.IsForeignKey = false;
				colvarMuertosPrimerSemana.IsReadOnly = false;
				colvarMuertosPrimerSemana.DefaultSetting = @"";
				colvarMuertosPrimerSemana.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMuertosPrimerSemana);
				
				TableSchema.TableColumn colvarMuertosDespuesPrimerSemana = new TableSchema.TableColumn(schema);
				colvarMuertosDespuesPrimerSemana.ColumnName = "MuertosDespuesPrimerSemana";
				colvarMuertosDespuesPrimerSemana.DataType = DbType.Int32;
				colvarMuertosDespuesPrimerSemana.MaxLength = 0;
				colvarMuertosDespuesPrimerSemana.AutoIncrement = false;
				colvarMuertosDespuesPrimerSemana.IsNullable = true;
				colvarMuertosDespuesPrimerSemana.IsPrimaryKey = false;
				colvarMuertosDespuesPrimerSemana.IsForeignKey = false;
				colvarMuertosDespuesPrimerSemana.IsReadOnly = false;
				colvarMuertosDespuesPrimerSemana.DefaultSetting = @"";
				colvarMuertosDespuesPrimerSemana.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMuertosDespuesPrimerSemana);
				
				TableSchema.TableColumn colvarAntecedentesGemelaresSi = new TableSchema.TableColumn(schema);
				colvarAntecedentesGemelaresSi.ColumnName = "AntecedentesGemelaresSi";
				colvarAntecedentesGemelaresSi.DataType = DbType.Boolean;
				colvarAntecedentesGemelaresSi.MaxLength = 0;
				colvarAntecedentesGemelaresSi.AutoIncrement = false;
				colvarAntecedentesGemelaresSi.IsNullable = true;
				colvarAntecedentesGemelaresSi.IsPrimaryKey = false;
				colvarAntecedentesGemelaresSi.IsForeignKey = false;
				colvarAntecedentesGemelaresSi.IsReadOnly = false;
				colvarAntecedentesGemelaresSi.DefaultSetting = @"";
				colvarAntecedentesGemelaresSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecedentesGemelaresSi);
				
				TableSchema.TableColumn colvarAntecedentesGemelaresNo = new TableSchema.TableColumn(schema);
				colvarAntecedentesGemelaresNo.ColumnName = "AntecedentesGemelaresNo";
				colvarAntecedentesGemelaresNo.DataType = DbType.Boolean;
				colvarAntecedentesGemelaresNo.MaxLength = 0;
				colvarAntecedentesGemelaresNo.AutoIncrement = false;
				colvarAntecedentesGemelaresNo.IsNullable = true;
				colvarAntecedentesGemelaresNo.IsPrimaryKey = false;
				colvarAntecedentesGemelaresNo.IsForeignKey = false;
				colvarAntecedentesGemelaresNo.IsReadOnly = false;
				colvarAntecedentesGemelaresNo.DefaultSetting = @"";
				colvarAntecedentesGemelaresNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecedentesGemelaresNo);
				
				TableSchema.TableColumn colvarUltPrevioNC = new TableSchema.TableColumn(schema);
				colvarUltPrevioNC.ColumnName = "UltPrevioNC";
				colvarUltPrevioNC.DataType = DbType.Boolean;
				colvarUltPrevioNC.MaxLength = 0;
				colvarUltPrevioNC.AutoIncrement = false;
				colvarUltPrevioNC.IsNullable = true;
				colvarUltPrevioNC.IsPrimaryKey = false;
				colvarUltPrevioNC.IsForeignKey = false;
				colvarUltPrevioNC.IsReadOnly = false;
				colvarUltPrevioNC.DefaultSetting = @"";
				colvarUltPrevioNC.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUltPrevioNC);
				
				TableSchema.TableColumn colvarUltPrevioNormal = new TableSchema.TableColumn(schema);
				colvarUltPrevioNormal.ColumnName = "UltPrevioNormal";
				colvarUltPrevioNormal.DataType = DbType.Boolean;
				colvarUltPrevioNormal.MaxLength = 0;
				colvarUltPrevioNormal.AutoIncrement = false;
				colvarUltPrevioNormal.IsNullable = true;
				colvarUltPrevioNormal.IsPrimaryKey = false;
				colvarUltPrevioNormal.IsForeignKey = false;
				colvarUltPrevioNormal.IsReadOnly = false;
				colvarUltPrevioNormal.DefaultSetting = @"";
				colvarUltPrevioNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUltPrevioNormal);
				
				TableSchema.TableColumn colvarUltPrevioMenor2500 = new TableSchema.TableColumn(schema);
				colvarUltPrevioMenor2500.ColumnName = "UltPrevioMenor2500";
				colvarUltPrevioMenor2500.DataType = DbType.Boolean;
				colvarUltPrevioMenor2500.MaxLength = 0;
				colvarUltPrevioMenor2500.AutoIncrement = false;
				colvarUltPrevioMenor2500.IsNullable = true;
				colvarUltPrevioMenor2500.IsPrimaryKey = false;
				colvarUltPrevioMenor2500.IsForeignKey = false;
				colvarUltPrevioMenor2500.IsReadOnly = false;
				colvarUltPrevioMenor2500.DefaultSetting = @"";
				colvarUltPrevioMenor2500.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUltPrevioMenor2500);
				
				TableSchema.TableColumn colvarUltPrevioMayor4000 = new TableSchema.TableColumn(schema);
				colvarUltPrevioMayor4000.ColumnName = "UltPrevioMayor4000";
				colvarUltPrevioMayor4000.DataType = DbType.Boolean;
				colvarUltPrevioMayor4000.MaxLength = 0;
				colvarUltPrevioMayor4000.AutoIncrement = false;
				colvarUltPrevioMayor4000.IsNullable = true;
				colvarUltPrevioMayor4000.IsPrimaryKey = false;
				colvarUltPrevioMayor4000.IsForeignKey = false;
				colvarUltPrevioMayor4000.IsReadOnly = false;
				colvarUltPrevioMayor4000.DefaultSetting = @"";
				colvarUltPrevioMayor4000.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUltPrevioMayor4000);
				
				TableSchema.TableColumn colvarFinEmbarazoAnterior = new TableSchema.TableColumn(schema);
				colvarFinEmbarazoAnterior.ColumnName = "FinEmbarazoAnterior";
				colvarFinEmbarazoAnterior.DataType = DbType.DateTime;
				colvarFinEmbarazoAnterior.MaxLength = 0;
				colvarFinEmbarazoAnterior.AutoIncrement = false;
				colvarFinEmbarazoAnterior.IsNullable = true;
				colvarFinEmbarazoAnterior.IsPrimaryKey = false;
				colvarFinEmbarazoAnterior.IsForeignKey = false;
				colvarFinEmbarazoAnterior.IsReadOnly = false;
				colvarFinEmbarazoAnterior.DefaultSetting = @"";
				colvarFinEmbarazoAnterior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFinEmbarazoAnterior);
				
				TableSchema.TableColumn colvarFinEmbAnteriorMenor1Año = new TableSchema.TableColumn(schema);
				colvarFinEmbAnteriorMenor1Año.ColumnName = "FinEmbAnteriorMenor1Año";
				colvarFinEmbAnteriorMenor1Año.DataType = DbType.Boolean;
				colvarFinEmbAnteriorMenor1Año.MaxLength = 0;
				colvarFinEmbAnteriorMenor1Año.AutoIncrement = false;
				colvarFinEmbAnteriorMenor1Año.IsNullable = true;
				colvarFinEmbAnteriorMenor1Año.IsPrimaryKey = false;
				colvarFinEmbAnteriorMenor1Año.IsForeignKey = false;
				colvarFinEmbAnteriorMenor1Año.IsReadOnly = false;
				colvarFinEmbAnteriorMenor1Año.DefaultSetting = @"";
				colvarFinEmbAnteriorMenor1Año.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFinEmbAnteriorMenor1Año);
				
				TableSchema.TableColumn colvarEmbarazoPlaneadoSi = new TableSchema.TableColumn(schema);
				colvarEmbarazoPlaneadoSi.ColumnName = "EmbarazoPlaneadoSi";
				colvarEmbarazoPlaneadoSi.DataType = DbType.Boolean;
				colvarEmbarazoPlaneadoSi.MaxLength = 0;
				colvarEmbarazoPlaneadoSi.AutoIncrement = false;
				colvarEmbarazoPlaneadoSi.IsNullable = true;
				colvarEmbarazoPlaneadoSi.IsPrimaryKey = false;
				colvarEmbarazoPlaneadoSi.IsForeignKey = false;
				colvarEmbarazoPlaneadoSi.IsReadOnly = false;
				colvarEmbarazoPlaneadoSi.DefaultSetting = @"";
				colvarEmbarazoPlaneadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoPlaneadoSi);
				
				TableSchema.TableColumn colvarEmbarazoPlaneadoNo = new TableSchema.TableColumn(schema);
				colvarEmbarazoPlaneadoNo.ColumnName = "EmbarazoPlaneadoNo";
				colvarEmbarazoPlaneadoNo.DataType = DbType.Boolean;
				colvarEmbarazoPlaneadoNo.MaxLength = 0;
				colvarEmbarazoPlaneadoNo.AutoIncrement = false;
				colvarEmbarazoPlaneadoNo.IsNullable = true;
				colvarEmbarazoPlaneadoNo.IsPrimaryKey = false;
				colvarEmbarazoPlaneadoNo.IsForeignKey = false;
				colvarEmbarazoPlaneadoNo.IsReadOnly = false;
				colvarEmbarazoPlaneadoNo.DefaultSetting = @"";
				colvarEmbarazoPlaneadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoPlaneadoNo);
				
				TableSchema.TableColumn colvarFracMetAnticonceptivoNoUsaba = new TableSchema.TableColumn(schema);
				colvarFracMetAnticonceptivoNoUsaba.ColumnName = "FracMetAnticonceptivoNoUsaba";
				colvarFracMetAnticonceptivoNoUsaba.DataType = DbType.Boolean;
				colvarFracMetAnticonceptivoNoUsaba.MaxLength = 0;
				colvarFracMetAnticonceptivoNoUsaba.AutoIncrement = false;
				colvarFracMetAnticonceptivoNoUsaba.IsNullable = true;
				colvarFracMetAnticonceptivoNoUsaba.IsPrimaryKey = false;
				colvarFracMetAnticonceptivoNoUsaba.IsForeignKey = false;
				colvarFracMetAnticonceptivoNoUsaba.IsReadOnly = false;
				colvarFracMetAnticonceptivoNoUsaba.DefaultSetting = @"";
				colvarFracMetAnticonceptivoNoUsaba.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFracMetAnticonceptivoNoUsaba);
				
				TableSchema.TableColumn colvarFracMetAnticonceptivoBarrera = new TableSchema.TableColumn(schema);
				colvarFracMetAnticonceptivoBarrera.ColumnName = "FracMetAnticonceptivoBarrera";
				colvarFracMetAnticonceptivoBarrera.DataType = DbType.Boolean;
				colvarFracMetAnticonceptivoBarrera.MaxLength = 0;
				colvarFracMetAnticonceptivoBarrera.AutoIncrement = false;
				colvarFracMetAnticonceptivoBarrera.IsNullable = true;
				colvarFracMetAnticonceptivoBarrera.IsPrimaryKey = false;
				colvarFracMetAnticonceptivoBarrera.IsForeignKey = false;
				colvarFracMetAnticonceptivoBarrera.IsReadOnly = false;
				colvarFracMetAnticonceptivoBarrera.DefaultSetting = @"";
				colvarFracMetAnticonceptivoBarrera.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFracMetAnticonceptivoBarrera);
				
				TableSchema.TableColumn colvarFracMetAnticonceptivoDIU = new TableSchema.TableColumn(schema);
				colvarFracMetAnticonceptivoDIU.ColumnName = "FracMetAnticonceptivoDIU";
				colvarFracMetAnticonceptivoDIU.DataType = DbType.Boolean;
				colvarFracMetAnticonceptivoDIU.MaxLength = 0;
				colvarFracMetAnticonceptivoDIU.AutoIncrement = false;
				colvarFracMetAnticonceptivoDIU.IsNullable = true;
				colvarFracMetAnticonceptivoDIU.IsPrimaryKey = false;
				colvarFracMetAnticonceptivoDIU.IsForeignKey = false;
				colvarFracMetAnticonceptivoDIU.IsReadOnly = false;
				colvarFracMetAnticonceptivoDIU.DefaultSetting = @"";
				colvarFracMetAnticonceptivoDIU.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFracMetAnticonceptivoDIU);
				
				TableSchema.TableColumn colvarFracMetAnticonceptivoHormonal = new TableSchema.TableColumn(schema);
				colvarFracMetAnticonceptivoHormonal.ColumnName = "FracMetAnticonceptivoHormonal";
				colvarFracMetAnticonceptivoHormonal.DataType = DbType.Boolean;
				colvarFracMetAnticonceptivoHormonal.MaxLength = 0;
				colvarFracMetAnticonceptivoHormonal.AutoIncrement = false;
				colvarFracMetAnticonceptivoHormonal.IsNullable = true;
				colvarFracMetAnticonceptivoHormonal.IsPrimaryKey = false;
				colvarFracMetAnticonceptivoHormonal.IsForeignKey = false;
				colvarFracMetAnticonceptivoHormonal.IsReadOnly = false;
				colvarFracMetAnticonceptivoHormonal.DefaultSetting = @"";
				colvarFracMetAnticonceptivoHormonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFracMetAnticonceptivoHormonal);
				
				TableSchema.TableColumn colvarFracMetAnticonceptivoEmergencia = new TableSchema.TableColumn(schema);
				colvarFracMetAnticonceptivoEmergencia.ColumnName = "FracMetAnticonceptivoEmergencia";
				colvarFracMetAnticonceptivoEmergencia.DataType = DbType.Boolean;
				colvarFracMetAnticonceptivoEmergencia.MaxLength = 0;
				colvarFracMetAnticonceptivoEmergencia.AutoIncrement = false;
				colvarFracMetAnticonceptivoEmergencia.IsNullable = true;
				colvarFracMetAnticonceptivoEmergencia.IsPrimaryKey = false;
				colvarFracMetAnticonceptivoEmergencia.IsForeignKey = false;
				colvarFracMetAnticonceptivoEmergencia.IsReadOnly = false;
				colvarFracMetAnticonceptivoEmergencia.DefaultSetting = @"";
				colvarFracMetAnticonceptivoEmergencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFracMetAnticonceptivoEmergencia);
				
				TableSchema.TableColumn colvarFracMetAnticonceptivoNatural = new TableSchema.TableColumn(schema);
				colvarFracMetAnticonceptivoNatural.ColumnName = "FracMetAnticonceptivoNatural";
				colvarFracMetAnticonceptivoNatural.DataType = DbType.Boolean;
				colvarFracMetAnticonceptivoNatural.MaxLength = 0;
				colvarFracMetAnticonceptivoNatural.AutoIncrement = false;
				colvarFracMetAnticonceptivoNatural.IsNullable = true;
				colvarFracMetAnticonceptivoNatural.IsPrimaryKey = false;
				colvarFracMetAnticonceptivoNatural.IsForeignKey = false;
				colvarFracMetAnticonceptivoNatural.IsReadOnly = false;
				colvarFracMetAnticonceptivoNatural.DefaultSetting = @"";
				colvarFracMetAnticonceptivoNatural.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFracMetAnticonceptivoNatural);
				
				TableSchema.TableColumn colvarPesoAnterior = new TableSchema.TableColumn(schema);
				colvarPesoAnterior.ColumnName = "PesoAnterior";
				colvarPesoAnterior.DataType = DbType.Decimal;
				colvarPesoAnterior.MaxLength = 0;
				colvarPesoAnterior.AutoIncrement = false;
				colvarPesoAnterior.IsNullable = true;
				colvarPesoAnterior.IsPrimaryKey = false;
				colvarPesoAnterior.IsForeignKey = false;
				colvarPesoAnterior.IsReadOnly = false;
				colvarPesoAnterior.DefaultSetting = @"";
				colvarPesoAnterior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPesoAnterior);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "Talla";
				colvarTalla.DataType = DbType.Int32;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = true;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarFum = new TableSchema.TableColumn(schema);
				colvarFum.ColumnName = "FUM";
				colvarFum.DataType = DbType.DateTime;
				colvarFum.MaxLength = 0;
				colvarFum.AutoIncrement = false;
				colvarFum.IsNullable = true;
				colvarFum.IsPrimaryKey = false;
				colvarFum.IsForeignKey = false;
				colvarFum.IsReadOnly = false;
				colvarFum.DefaultSetting = @"";
				colvarFum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFum);
				
				TableSchema.TableColumn colvarFpp = new TableSchema.TableColumn(schema);
				colvarFpp.ColumnName = "FPP";
				colvarFpp.DataType = DbType.DateTime;
				colvarFpp.MaxLength = 0;
				colvarFpp.AutoIncrement = false;
				colvarFpp.IsNullable = true;
				colvarFpp.IsPrimaryKey = false;
				colvarFpp.IsForeignKey = false;
				colvarFpp.IsReadOnly = false;
				colvarFpp.DefaultSetting = @"";
				colvarFpp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFpp);
				
				TableSchema.TableColumn colvarEGConfiableFUMSi = new TableSchema.TableColumn(schema);
				colvarEGConfiableFUMSi.ColumnName = "EGConfiableFUMSi";
				colvarEGConfiableFUMSi.DataType = DbType.Boolean;
				colvarEGConfiableFUMSi.MaxLength = 0;
				colvarEGConfiableFUMSi.AutoIncrement = false;
				colvarEGConfiableFUMSi.IsNullable = true;
				colvarEGConfiableFUMSi.IsPrimaryKey = false;
				colvarEGConfiableFUMSi.IsForeignKey = false;
				colvarEGConfiableFUMSi.IsReadOnly = false;
				colvarEGConfiableFUMSi.DefaultSetting = @"";
				colvarEGConfiableFUMSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEGConfiableFUMSi);
				
				TableSchema.TableColumn colvarEGConfiableFUMNo = new TableSchema.TableColumn(schema);
				colvarEGConfiableFUMNo.ColumnName = "EGConfiableFUMNo";
				colvarEGConfiableFUMNo.DataType = DbType.Boolean;
				colvarEGConfiableFUMNo.MaxLength = 0;
				colvarEGConfiableFUMNo.AutoIncrement = false;
				colvarEGConfiableFUMNo.IsNullable = true;
				colvarEGConfiableFUMNo.IsPrimaryKey = false;
				colvarEGConfiableFUMNo.IsForeignKey = false;
				colvarEGConfiableFUMNo.IsReadOnly = false;
				colvarEGConfiableFUMNo.DefaultSetting = @"";
				colvarEGConfiableFUMNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEGConfiableFUMNo);
				
				TableSchema.TableColumn colvarEGConfiableEcoMenor20semanasSi = new TableSchema.TableColumn(schema);
				colvarEGConfiableEcoMenor20semanasSi.ColumnName = "EGConfiableEcoMenor20semanasSi";
				colvarEGConfiableEcoMenor20semanasSi.DataType = DbType.Boolean;
				colvarEGConfiableEcoMenor20semanasSi.MaxLength = 0;
				colvarEGConfiableEcoMenor20semanasSi.AutoIncrement = false;
				colvarEGConfiableEcoMenor20semanasSi.IsNullable = true;
				colvarEGConfiableEcoMenor20semanasSi.IsPrimaryKey = false;
				colvarEGConfiableEcoMenor20semanasSi.IsForeignKey = false;
				colvarEGConfiableEcoMenor20semanasSi.IsReadOnly = false;
				colvarEGConfiableEcoMenor20semanasSi.DefaultSetting = @"";
				colvarEGConfiableEcoMenor20semanasSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEGConfiableEcoMenor20semanasSi);
				
				TableSchema.TableColumn colvarEGConfiableEcoMenor20semanasNo = new TableSchema.TableColumn(schema);
				colvarEGConfiableEcoMenor20semanasNo.ColumnName = "EGConfiableEcoMenor20semanasNo";
				colvarEGConfiableEcoMenor20semanasNo.DataType = DbType.Boolean;
				colvarEGConfiableEcoMenor20semanasNo.MaxLength = 0;
				colvarEGConfiableEcoMenor20semanasNo.AutoIncrement = false;
				colvarEGConfiableEcoMenor20semanasNo.IsNullable = true;
				colvarEGConfiableEcoMenor20semanasNo.IsPrimaryKey = false;
				colvarEGConfiableEcoMenor20semanasNo.IsForeignKey = false;
				colvarEGConfiableEcoMenor20semanasNo.IsReadOnly = false;
				colvarEGConfiableEcoMenor20semanasNo.DefaultSetting = @"";
				colvarEGConfiableEcoMenor20semanasNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEGConfiableEcoMenor20semanasNo);
				
				TableSchema.TableColumn colvarFumaActivo1TrimSi = new TableSchema.TableColumn(schema);
				colvarFumaActivo1TrimSi.ColumnName = "FumaActivo1TrimSi";
				colvarFumaActivo1TrimSi.DataType = DbType.Boolean;
				colvarFumaActivo1TrimSi.MaxLength = 0;
				colvarFumaActivo1TrimSi.AutoIncrement = false;
				colvarFumaActivo1TrimSi.IsNullable = true;
				colvarFumaActivo1TrimSi.IsPrimaryKey = false;
				colvarFumaActivo1TrimSi.IsForeignKey = false;
				colvarFumaActivo1TrimSi.IsReadOnly = false;
				colvarFumaActivo1TrimSi.DefaultSetting = @"";
				colvarFumaActivo1TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaActivo1TrimSi);
				
				TableSchema.TableColumn colvarFumaActivo1TrimNo = new TableSchema.TableColumn(schema);
				colvarFumaActivo1TrimNo.ColumnName = "FumaActivo1TrimNo";
				colvarFumaActivo1TrimNo.DataType = DbType.Boolean;
				colvarFumaActivo1TrimNo.MaxLength = 0;
				colvarFumaActivo1TrimNo.AutoIncrement = false;
				colvarFumaActivo1TrimNo.IsNullable = true;
				colvarFumaActivo1TrimNo.IsPrimaryKey = false;
				colvarFumaActivo1TrimNo.IsForeignKey = false;
				colvarFumaActivo1TrimNo.IsReadOnly = false;
				colvarFumaActivo1TrimNo.DefaultSetting = @"";
				colvarFumaActivo1TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaActivo1TrimNo);
				
				TableSchema.TableColumn colvarFumaActivo2TrimSi = new TableSchema.TableColumn(schema);
				colvarFumaActivo2TrimSi.ColumnName = "FumaActivo2TrimSi";
				colvarFumaActivo2TrimSi.DataType = DbType.Boolean;
				colvarFumaActivo2TrimSi.MaxLength = 0;
				colvarFumaActivo2TrimSi.AutoIncrement = false;
				colvarFumaActivo2TrimSi.IsNullable = true;
				colvarFumaActivo2TrimSi.IsPrimaryKey = false;
				colvarFumaActivo2TrimSi.IsForeignKey = false;
				colvarFumaActivo2TrimSi.IsReadOnly = false;
				colvarFumaActivo2TrimSi.DefaultSetting = @"";
				colvarFumaActivo2TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaActivo2TrimSi);
				
				TableSchema.TableColumn colvarFumaActivo2TrimNo = new TableSchema.TableColumn(schema);
				colvarFumaActivo2TrimNo.ColumnName = "FumaActivo2TrimNo";
				colvarFumaActivo2TrimNo.DataType = DbType.Boolean;
				colvarFumaActivo2TrimNo.MaxLength = 0;
				colvarFumaActivo2TrimNo.AutoIncrement = false;
				colvarFumaActivo2TrimNo.IsNullable = true;
				colvarFumaActivo2TrimNo.IsPrimaryKey = false;
				colvarFumaActivo2TrimNo.IsForeignKey = false;
				colvarFumaActivo2TrimNo.IsReadOnly = false;
				colvarFumaActivo2TrimNo.DefaultSetting = @"";
				colvarFumaActivo2TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaActivo2TrimNo);
				
				TableSchema.TableColumn colvarFumaActivo3TrimSi = new TableSchema.TableColumn(schema);
				colvarFumaActivo3TrimSi.ColumnName = "FumaActivo3TrimSi";
				colvarFumaActivo3TrimSi.DataType = DbType.Boolean;
				colvarFumaActivo3TrimSi.MaxLength = 0;
				colvarFumaActivo3TrimSi.AutoIncrement = false;
				colvarFumaActivo3TrimSi.IsNullable = true;
				colvarFumaActivo3TrimSi.IsPrimaryKey = false;
				colvarFumaActivo3TrimSi.IsForeignKey = false;
				colvarFumaActivo3TrimSi.IsReadOnly = false;
				colvarFumaActivo3TrimSi.DefaultSetting = @"";
				colvarFumaActivo3TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaActivo3TrimSi);
				
				TableSchema.TableColumn colvarFumaActivo3TrimNo = new TableSchema.TableColumn(schema);
				colvarFumaActivo3TrimNo.ColumnName = "FumaActivo3TrimNo";
				colvarFumaActivo3TrimNo.DataType = DbType.Boolean;
				colvarFumaActivo3TrimNo.MaxLength = 0;
				colvarFumaActivo3TrimNo.AutoIncrement = false;
				colvarFumaActivo3TrimNo.IsNullable = true;
				colvarFumaActivo3TrimNo.IsPrimaryKey = false;
				colvarFumaActivo3TrimNo.IsForeignKey = false;
				colvarFumaActivo3TrimNo.IsReadOnly = false;
				colvarFumaActivo3TrimNo.DefaultSetting = @"";
				colvarFumaActivo3TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaActivo3TrimNo);
				
				TableSchema.TableColumn colvarFumaPasivo1TrimSi = new TableSchema.TableColumn(schema);
				colvarFumaPasivo1TrimSi.ColumnName = "FumaPasivo1TrimSi";
				colvarFumaPasivo1TrimSi.DataType = DbType.Boolean;
				colvarFumaPasivo1TrimSi.MaxLength = 0;
				colvarFumaPasivo1TrimSi.AutoIncrement = false;
				colvarFumaPasivo1TrimSi.IsNullable = true;
				colvarFumaPasivo1TrimSi.IsPrimaryKey = false;
				colvarFumaPasivo1TrimSi.IsForeignKey = false;
				colvarFumaPasivo1TrimSi.IsReadOnly = false;
				colvarFumaPasivo1TrimSi.DefaultSetting = @"";
				colvarFumaPasivo1TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaPasivo1TrimSi);
				
				TableSchema.TableColumn colvarFumaPasivo1TrimNo = new TableSchema.TableColumn(schema);
				colvarFumaPasivo1TrimNo.ColumnName = "FumaPasivo1TrimNo";
				colvarFumaPasivo1TrimNo.DataType = DbType.Boolean;
				colvarFumaPasivo1TrimNo.MaxLength = 0;
				colvarFumaPasivo1TrimNo.AutoIncrement = false;
				colvarFumaPasivo1TrimNo.IsNullable = true;
				colvarFumaPasivo1TrimNo.IsPrimaryKey = false;
				colvarFumaPasivo1TrimNo.IsForeignKey = false;
				colvarFumaPasivo1TrimNo.IsReadOnly = false;
				colvarFumaPasivo1TrimNo.DefaultSetting = @"";
				colvarFumaPasivo1TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaPasivo1TrimNo);
				
				TableSchema.TableColumn colvarFumaPasivo2TrimSi = new TableSchema.TableColumn(schema);
				colvarFumaPasivo2TrimSi.ColumnName = "FumaPasivo2TrimSi";
				colvarFumaPasivo2TrimSi.DataType = DbType.Boolean;
				colvarFumaPasivo2TrimSi.MaxLength = 0;
				colvarFumaPasivo2TrimSi.AutoIncrement = false;
				colvarFumaPasivo2TrimSi.IsNullable = true;
				colvarFumaPasivo2TrimSi.IsPrimaryKey = false;
				colvarFumaPasivo2TrimSi.IsForeignKey = false;
				colvarFumaPasivo2TrimSi.IsReadOnly = false;
				colvarFumaPasivo2TrimSi.DefaultSetting = @"";
				colvarFumaPasivo2TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaPasivo2TrimSi);
				
				TableSchema.TableColumn colvarFumaPasivo2TrimNo = new TableSchema.TableColumn(schema);
				colvarFumaPasivo2TrimNo.ColumnName = "FumaPasivo2TrimNo";
				colvarFumaPasivo2TrimNo.DataType = DbType.Boolean;
				colvarFumaPasivo2TrimNo.MaxLength = 0;
				colvarFumaPasivo2TrimNo.AutoIncrement = false;
				colvarFumaPasivo2TrimNo.IsNullable = true;
				colvarFumaPasivo2TrimNo.IsPrimaryKey = false;
				colvarFumaPasivo2TrimNo.IsForeignKey = false;
				colvarFumaPasivo2TrimNo.IsReadOnly = false;
				colvarFumaPasivo2TrimNo.DefaultSetting = @"";
				colvarFumaPasivo2TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaPasivo2TrimNo);
				
				TableSchema.TableColumn colvarFumaPasivo3TrimSi = new TableSchema.TableColumn(schema);
				colvarFumaPasivo3TrimSi.ColumnName = "FumaPasivo3TrimSi";
				colvarFumaPasivo3TrimSi.DataType = DbType.Boolean;
				colvarFumaPasivo3TrimSi.MaxLength = 0;
				colvarFumaPasivo3TrimSi.AutoIncrement = false;
				colvarFumaPasivo3TrimSi.IsNullable = true;
				colvarFumaPasivo3TrimSi.IsPrimaryKey = false;
				colvarFumaPasivo3TrimSi.IsForeignKey = false;
				colvarFumaPasivo3TrimSi.IsReadOnly = false;
				colvarFumaPasivo3TrimSi.DefaultSetting = @"";
				colvarFumaPasivo3TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaPasivo3TrimSi);
				
				TableSchema.TableColumn colvarFumaPasivo3TrimNo = new TableSchema.TableColumn(schema);
				colvarFumaPasivo3TrimNo.ColumnName = "FumaPasivo3TrimNo";
				colvarFumaPasivo3TrimNo.DataType = DbType.Boolean;
				colvarFumaPasivo3TrimNo.MaxLength = 0;
				colvarFumaPasivo3TrimNo.AutoIncrement = false;
				colvarFumaPasivo3TrimNo.IsNullable = true;
				colvarFumaPasivo3TrimNo.IsPrimaryKey = false;
				colvarFumaPasivo3TrimNo.IsForeignKey = false;
				colvarFumaPasivo3TrimNo.IsReadOnly = false;
				colvarFumaPasivo3TrimNo.DefaultSetting = @"";
				colvarFumaPasivo3TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFumaPasivo3TrimNo);
				
				TableSchema.TableColumn colvarDrogas1TrimSi = new TableSchema.TableColumn(schema);
				colvarDrogas1TrimSi.ColumnName = "Drogas1TrimSi";
				colvarDrogas1TrimSi.DataType = DbType.Boolean;
				colvarDrogas1TrimSi.MaxLength = 0;
				colvarDrogas1TrimSi.AutoIncrement = false;
				colvarDrogas1TrimSi.IsNullable = true;
				colvarDrogas1TrimSi.IsPrimaryKey = false;
				colvarDrogas1TrimSi.IsForeignKey = false;
				colvarDrogas1TrimSi.IsReadOnly = false;
				colvarDrogas1TrimSi.DefaultSetting = @"";
				colvarDrogas1TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas1TrimSi);
				
				TableSchema.TableColumn colvarDrogas1TrimNo = new TableSchema.TableColumn(schema);
				colvarDrogas1TrimNo.ColumnName = "Drogas1TrimNo";
				colvarDrogas1TrimNo.DataType = DbType.Boolean;
				colvarDrogas1TrimNo.MaxLength = 0;
				colvarDrogas1TrimNo.AutoIncrement = false;
				colvarDrogas1TrimNo.IsNullable = true;
				colvarDrogas1TrimNo.IsPrimaryKey = false;
				colvarDrogas1TrimNo.IsForeignKey = false;
				colvarDrogas1TrimNo.IsReadOnly = false;
				colvarDrogas1TrimNo.DefaultSetting = @"";
				colvarDrogas1TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas1TrimNo);
				
				TableSchema.TableColumn colvarDrogas2TrimSi = new TableSchema.TableColumn(schema);
				colvarDrogas2TrimSi.ColumnName = "Drogas2TrimSi";
				colvarDrogas2TrimSi.DataType = DbType.Boolean;
				colvarDrogas2TrimSi.MaxLength = 0;
				colvarDrogas2TrimSi.AutoIncrement = false;
				colvarDrogas2TrimSi.IsNullable = true;
				colvarDrogas2TrimSi.IsPrimaryKey = false;
				colvarDrogas2TrimSi.IsForeignKey = false;
				colvarDrogas2TrimSi.IsReadOnly = false;
				colvarDrogas2TrimSi.DefaultSetting = @"";
				colvarDrogas2TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas2TrimSi);
				
				TableSchema.TableColumn colvarDrogas2TrimNo = new TableSchema.TableColumn(schema);
				colvarDrogas2TrimNo.ColumnName = "Drogas2TrimNo";
				colvarDrogas2TrimNo.DataType = DbType.Boolean;
				colvarDrogas2TrimNo.MaxLength = 0;
				colvarDrogas2TrimNo.AutoIncrement = false;
				colvarDrogas2TrimNo.IsNullable = true;
				colvarDrogas2TrimNo.IsPrimaryKey = false;
				colvarDrogas2TrimNo.IsForeignKey = false;
				colvarDrogas2TrimNo.IsReadOnly = false;
				colvarDrogas2TrimNo.DefaultSetting = @"";
				colvarDrogas2TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas2TrimNo);
				
				TableSchema.TableColumn colvarDrogas3TrimSi = new TableSchema.TableColumn(schema);
				colvarDrogas3TrimSi.ColumnName = "Drogas3TrimSi";
				colvarDrogas3TrimSi.DataType = DbType.Boolean;
				colvarDrogas3TrimSi.MaxLength = 0;
				colvarDrogas3TrimSi.AutoIncrement = false;
				colvarDrogas3TrimSi.IsNullable = true;
				colvarDrogas3TrimSi.IsPrimaryKey = false;
				colvarDrogas3TrimSi.IsForeignKey = false;
				colvarDrogas3TrimSi.IsReadOnly = false;
				colvarDrogas3TrimSi.DefaultSetting = @"";
				colvarDrogas3TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas3TrimSi);
				
				TableSchema.TableColumn colvarDrogas3TrimNo = new TableSchema.TableColumn(schema);
				colvarDrogas3TrimNo.ColumnName = "Drogas3TrimNo";
				colvarDrogas3TrimNo.DataType = DbType.Boolean;
				colvarDrogas3TrimNo.MaxLength = 0;
				colvarDrogas3TrimNo.AutoIncrement = false;
				colvarDrogas3TrimNo.IsNullable = true;
				colvarDrogas3TrimNo.IsPrimaryKey = false;
				colvarDrogas3TrimNo.IsForeignKey = false;
				colvarDrogas3TrimNo.IsReadOnly = false;
				colvarDrogas3TrimNo.DefaultSetting = @"";
				colvarDrogas3TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDrogas3TrimNo);
				
				TableSchema.TableColumn colvarAlcohol1TrimSi = new TableSchema.TableColumn(schema);
				colvarAlcohol1TrimSi.ColumnName = "Alcohol1TrimSi";
				colvarAlcohol1TrimSi.DataType = DbType.Boolean;
				colvarAlcohol1TrimSi.MaxLength = 0;
				colvarAlcohol1TrimSi.AutoIncrement = false;
				colvarAlcohol1TrimSi.IsNullable = true;
				colvarAlcohol1TrimSi.IsPrimaryKey = false;
				colvarAlcohol1TrimSi.IsForeignKey = false;
				colvarAlcohol1TrimSi.IsReadOnly = false;
				colvarAlcohol1TrimSi.DefaultSetting = @"";
				colvarAlcohol1TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcohol1TrimSi);
				
				TableSchema.TableColumn colvarAlcohol1TrimNo = new TableSchema.TableColumn(schema);
				colvarAlcohol1TrimNo.ColumnName = "Alcohol1TrimNo";
				colvarAlcohol1TrimNo.DataType = DbType.Boolean;
				colvarAlcohol1TrimNo.MaxLength = 0;
				colvarAlcohol1TrimNo.AutoIncrement = false;
				colvarAlcohol1TrimNo.IsNullable = true;
				colvarAlcohol1TrimNo.IsPrimaryKey = false;
				colvarAlcohol1TrimNo.IsForeignKey = false;
				colvarAlcohol1TrimNo.IsReadOnly = false;
				colvarAlcohol1TrimNo.DefaultSetting = @"";
				colvarAlcohol1TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcohol1TrimNo);
				
				TableSchema.TableColumn colvarAlcohol2TrimSi = new TableSchema.TableColumn(schema);
				colvarAlcohol2TrimSi.ColumnName = "Alcohol2TrimSi";
				colvarAlcohol2TrimSi.DataType = DbType.Boolean;
				colvarAlcohol2TrimSi.MaxLength = 0;
				colvarAlcohol2TrimSi.AutoIncrement = false;
				colvarAlcohol2TrimSi.IsNullable = true;
				colvarAlcohol2TrimSi.IsPrimaryKey = false;
				colvarAlcohol2TrimSi.IsForeignKey = false;
				colvarAlcohol2TrimSi.IsReadOnly = false;
				colvarAlcohol2TrimSi.DefaultSetting = @"";
				colvarAlcohol2TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcohol2TrimSi);
				
				TableSchema.TableColumn colvarAlcohol2TrimNo = new TableSchema.TableColumn(schema);
				colvarAlcohol2TrimNo.ColumnName = "Alcohol2TrimNo";
				colvarAlcohol2TrimNo.DataType = DbType.Boolean;
				colvarAlcohol2TrimNo.MaxLength = 0;
				colvarAlcohol2TrimNo.AutoIncrement = false;
				colvarAlcohol2TrimNo.IsNullable = true;
				colvarAlcohol2TrimNo.IsPrimaryKey = false;
				colvarAlcohol2TrimNo.IsForeignKey = false;
				colvarAlcohol2TrimNo.IsReadOnly = false;
				colvarAlcohol2TrimNo.DefaultSetting = @"";
				colvarAlcohol2TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcohol2TrimNo);
				
				TableSchema.TableColumn colvarAlcohol3TrimSi = new TableSchema.TableColumn(schema);
				colvarAlcohol3TrimSi.ColumnName = "Alcohol3TrimSi";
				colvarAlcohol3TrimSi.DataType = DbType.Boolean;
				colvarAlcohol3TrimSi.MaxLength = 0;
				colvarAlcohol3TrimSi.AutoIncrement = false;
				colvarAlcohol3TrimSi.IsNullable = true;
				colvarAlcohol3TrimSi.IsPrimaryKey = false;
				colvarAlcohol3TrimSi.IsForeignKey = false;
				colvarAlcohol3TrimSi.IsReadOnly = false;
				colvarAlcohol3TrimSi.DefaultSetting = @"";
				colvarAlcohol3TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcohol3TrimSi);
				
				TableSchema.TableColumn colvarAlcohol3TrimNo = new TableSchema.TableColumn(schema);
				colvarAlcohol3TrimNo.ColumnName = "Alcohol3TrimNo";
				colvarAlcohol3TrimNo.DataType = DbType.Boolean;
				colvarAlcohol3TrimNo.MaxLength = 0;
				colvarAlcohol3TrimNo.AutoIncrement = false;
				colvarAlcohol3TrimNo.IsNullable = true;
				colvarAlcohol3TrimNo.IsPrimaryKey = false;
				colvarAlcohol3TrimNo.IsForeignKey = false;
				colvarAlcohol3TrimNo.IsReadOnly = false;
				colvarAlcohol3TrimNo.DefaultSetting = @"";
				colvarAlcohol3TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcohol3TrimNo);
				
				TableSchema.TableColumn colvarViolencia1TrimSi = new TableSchema.TableColumn(schema);
				colvarViolencia1TrimSi.ColumnName = "Violencia1TrimSi";
				colvarViolencia1TrimSi.DataType = DbType.Boolean;
				colvarViolencia1TrimSi.MaxLength = 0;
				colvarViolencia1TrimSi.AutoIncrement = false;
				colvarViolencia1TrimSi.IsNullable = true;
				colvarViolencia1TrimSi.IsPrimaryKey = false;
				colvarViolencia1TrimSi.IsForeignKey = false;
				colvarViolencia1TrimSi.IsReadOnly = false;
				colvarViolencia1TrimSi.DefaultSetting = @"";
				colvarViolencia1TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViolencia1TrimSi);
				
				TableSchema.TableColumn colvarViolencia1TrimNo = new TableSchema.TableColumn(schema);
				colvarViolencia1TrimNo.ColumnName = "Violencia1TrimNo";
				colvarViolencia1TrimNo.DataType = DbType.Boolean;
				colvarViolencia1TrimNo.MaxLength = 0;
				colvarViolencia1TrimNo.AutoIncrement = false;
				colvarViolencia1TrimNo.IsNullable = true;
				colvarViolencia1TrimNo.IsPrimaryKey = false;
				colvarViolencia1TrimNo.IsForeignKey = false;
				colvarViolencia1TrimNo.IsReadOnly = false;
				colvarViolencia1TrimNo.DefaultSetting = @"";
				colvarViolencia1TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViolencia1TrimNo);
				
				TableSchema.TableColumn colvarViolencia2TrimSi = new TableSchema.TableColumn(schema);
				colvarViolencia2TrimSi.ColumnName = "Violencia2TrimSi";
				colvarViolencia2TrimSi.DataType = DbType.Boolean;
				colvarViolencia2TrimSi.MaxLength = 0;
				colvarViolencia2TrimSi.AutoIncrement = false;
				colvarViolencia2TrimSi.IsNullable = true;
				colvarViolencia2TrimSi.IsPrimaryKey = false;
				colvarViolencia2TrimSi.IsForeignKey = false;
				colvarViolencia2TrimSi.IsReadOnly = false;
				colvarViolencia2TrimSi.DefaultSetting = @"";
				colvarViolencia2TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViolencia2TrimSi);
				
				TableSchema.TableColumn colvarViolencia2TrimNo = new TableSchema.TableColumn(schema);
				colvarViolencia2TrimNo.ColumnName = "Violencia2TrimNo";
				colvarViolencia2TrimNo.DataType = DbType.Boolean;
				colvarViolencia2TrimNo.MaxLength = 0;
				colvarViolencia2TrimNo.AutoIncrement = false;
				colvarViolencia2TrimNo.IsNullable = true;
				colvarViolencia2TrimNo.IsPrimaryKey = false;
				colvarViolencia2TrimNo.IsForeignKey = false;
				colvarViolencia2TrimNo.IsReadOnly = false;
				colvarViolencia2TrimNo.DefaultSetting = @"";
				colvarViolencia2TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViolencia2TrimNo);
				
				TableSchema.TableColumn colvarViolencia3TrimSi = new TableSchema.TableColumn(schema);
				colvarViolencia3TrimSi.ColumnName = "Violencia3TrimSi";
				colvarViolencia3TrimSi.DataType = DbType.Boolean;
				colvarViolencia3TrimSi.MaxLength = 0;
				colvarViolencia3TrimSi.AutoIncrement = false;
				colvarViolencia3TrimSi.IsNullable = true;
				colvarViolencia3TrimSi.IsPrimaryKey = false;
				colvarViolencia3TrimSi.IsForeignKey = false;
				colvarViolencia3TrimSi.IsReadOnly = false;
				colvarViolencia3TrimSi.DefaultSetting = @"";
				colvarViolencia3TrimSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViolencia3TrimSi);
				
				TableSchema.TableColumn colvarViolencia3TrimNo = new TableSchema.TableColumn(schema);
				colvarViolencia3TrimNo.ColumnName = "Violencia3TrimNo";
				colvarViolencia3TrimNo.DataType = DbType.Boolean;
				colvarViolencia3TrimNo.MaxLength = 0;
				colvarViolencia3TrimNo.AutoIncrement = false;
				colvarViolencia3TrimNo.IsNullable = true;
				colvarViolencia3TrimNo.IsPrimaryKey = false;
				colvarViolencia3TrimNo.IsForeignKey = false;
				colvarViolencia3TrimNo.IsReadOnly = false;
				colvarViolencia3TrimNo.DefaultSetting = @"";
				colvarViolencia3TrimNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViolencia3TrimNo);
				
				TableSchema.TableColumn colvarAntirubeolaPrevia = new TableSchema.TableColumn(schema);
				colvarAntirubeolaPrevia.ColumnName = "AntirubeolaPrevia";
				colvarAntirubeolaPrevia.DataType = DbType.Boolean;
				colvarAntirubeolaPrevia.MaxLength = 0;
				colvarAntirubeolaPrevia.AutoIncrement = false;
				colvarAntirubeolaPrevia.IsNullable = true;
				colvarAntirubeolaPrevia.IsPrimaryKey = false;
				colvarAntirubeolaPrevia.IsForeignKey = false;
				colvarAntirubeolaPrevia.IsReadOnly = false;
				colvarAntirubeolaPrevia.DefaultSetting = @"";
				colvarAntirubeolaPrevia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntirubeolaPrevia);
				
				TableSchema.TableColumn colvarAntirubeolaNoSabe = new TableSchema.TableColumn(schema);
				colvarAntirubeolaNoSabe.ColumnName = "AntirubeolaNoSabe";
				colvarAntirubeolaNoSabe.DataType = DbType.Boolean;
				colvarAntirubeolaNoSabe.MaxLength = 0;
				colvarAntirubeolaNoSabe.AutoIncrement = false;
				colvarAntirubeolaNoSabe.IsNullable = true;
				colvarAntirubeolaNoSabe.IsPrimaryKey = false;
				colvarAntirubeolaNoSabe.IsForeignKey = false;
				colvarAntirubeolaNoSabe.IsReadOnly = false;
				colvarAntirubeolaNoSabe.DefaultSetting = @"";
				colvarAntirubeolaNoSabe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntirubeolaNoSabe);
				
				TableSchema.TableColumn colvarAntirubeolaEmbarazo = new TableSchema.TableColumn(schema);
				colvarAntirubeolaEmbarazo.ColumnName = "AntirubeolaEmbarazo";
				colvarAntirubeolaEmbarazo.DataType = DbType.Boolean;
				colvarAntirubeolaEmbarazo.MaxLength = 0;
				colvarAntirubeolaEmbarazo.AutoIncrement = false;
				colvarAntirubeolaEmbarazo.IsNullable = true;
				colvarAntirubeolaEmbarazo.IsPrimaryKey = false;
				colvarAntirubeolaEmbarazo.IsForeignKey = false;
				colvarAntirubeolaEmbarazo.IsReadOnly = false;
				colvarAntirubeolaEmbarazo.DefaultSetting = @"";
				colvarAntirubeolaEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntirubeolaEmbarazo);
				
				TableSchema.TableColumn colvarAntirubeolaNo = new TableSchema.TableColumn(schema);
				colvarAntirubeolaNo.ColumnName = "AntirubeolaNo";
				colvarAntirubeolaNo.DataType = DbType.Boolean;
				colvarAntirubeolaNo.MaxLength = 0;
				colvarAntirubeolaNo.AutoIncrement = false;
				colvarAntirubeolaNo.IsNullable = true;
				colvarAntirubeolaNo.IsPrimaryKey = false;
				colvarAntirubeolaNo.IsForeignKey = false;
				colvarAntirubeolaNo.IsReadOnly = false;
				colvarAntirubeolaNo.DefaultSetting = @"";
				colvarAntirubeolaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntirubeolaNo);
				
				TableSchema.TableColumn colvarAntitetanicaVigenteNo = new TableSchema.TableColumn(schema);
				colvarAntitetanicaVigenteNo.ColumnName = "AntitetanicaVigenteNo";
				colvarAntitetanicaVigenteNo.DataType = DbType.Boolean;
				colvarAntitetanicaVigenteNo.MaxLength = 0;
				colvarAntitetanicaVigenteNo.AutoIncrement = false;
				colvarAntitetanicaVigenteNo.IsNullable = true;
				colvarAntitetanicaVigenteNo.IsPrimaryKey = false;
				colvarAntitetanicaVigenteNo.IsForeignKey = false;
				colvarAntitetanicaVigenteNo.IsReadOnly = false;
				colvarAntitetanicaVigenteNo.DefaultSetting = @"";
				colvarAntitetanicaVigenteNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntitetanicaVigenteNo);
				
				TableSchema.TableColumn colvarAntitetanicaVigenteSi = new TableSchema.TableColumn(schema);
				colvarAntitetanicaVigenteSi.ColumnName = "AntitetanicaVigenteSi";
				colvarAntitetanicaVigenteSi.DataType = DbType.Boolean;
				colvarAntitetanicaVigenteSi.MaxLength = 0;
				colvarAntitetanicaVigenteSi.AutoIncrement = false;
				colvarAntitetanicaVigenteSi.IsNullable = true;
				colvarAntitetanicaVigenteSi.IsPrimaryKey = false;
				colvarAntitetanicaVigenteSi.IsForeignKey = false;
				colvarAntitetanicaVigenteSi.IsReadOnly = false;
				colvarAntitetanicaVigenteSi.DefaultSetting = @"";
				colvarAntitetanicaVigenteSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntitetanicaVigenteSi);
				
				TableSchema.TableColumn colvarAntitetanica1DosisMesGestacion = new TableSchema.TableColumn(schema);
				colvarAntitetanica1DosisMesGestacion.ColumnName = "Antitetanica1DosisMesGestacion";
				colvarAntitetanica1DosisMesGestacion.DataType = DbType.Int32;
				colvarAntitetanica1DosisMesGestacion.MaxLength = 0;
				colvarAntitetanica1DosisMesGestacion.AutoIncrement = false;
				colvarAntitetanica1DosisMesGestacion.IsNullable = true;
				colvarAntitetanica1DosisMesGestacion.IsPrimaryKey = false;
				colvarAntitetanica1DosisMesGestacion.IsForeignKey = false;
				colvarAntitetanica1DosisMesGestacion.IsReadOnly = false;
				colvarAntitetanica1DosisMesGestacion.DefaultSetting = @"";
				colvarAntitetanica1DosisMesGestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntitetanica1DosisMesGestacion);
				
				TableSchema.TableColumn colvarAntitetanica2DosisMesGestacion = new TableSchema.TableColumn(schema);
				colvarAntitetanica2DosisMesGestacion.ColumnName = "Antitetanica2DosisMesGestacion";
				colvarAntitetanica2DosisMesGestacion.DataType = DbType.Int32;
				colvarAntitetanica2DosisMesGestacion.MaxLength = 0;
				colvarAntitetanica2DosisMesGestacion.AutoIncrement = false;
				colvarAntitetanica2DosisMesGestacion.IsNullable = true;
				colvarAntitetanica2DosisMesGestacion.IsPrimaryKey = false;
				colvarAntitetanica2DosisMesGestacion.IsForeignKey = false;
				colvarAntitetanica2DosisMesGestacion.IsReadOnly = false;
				colvarAntitetanica2DosisMesGestacion.DefaultSetting = @"";
				colvarAntitetanica2DosisMesGestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntitetanica2DosisMesGestacion);
				
				TableSchema.TableColumn colvarExamenOdotologicoNormalSi = new TableSchema.TableColumn(schema);
				colvarExamenOdotologicoNormalSi.ColumnName = "ExamenOdotologicoNormalSi";
				colvarExamenOdotologicoNormalSi.DataType = DbType.Boolean;
				colvarExamenOdotologicoNormalSi.MaxLength = 0;
				colvarExamenOdotologicoNormalSi.AutoIncrement = false;
				colvarExamenOdotologicoNormalSi.IsNullable = true;
				colvarExamenOdotologicoNormalSi.IsPrimaryKey = false;
				colvarExamenOdotologicoNormalSi.IsForeignKey = false;
				colvarExamenOdotologicoNormalSi.IsReadOnly = false;
				colvarExamenOdotologicoNormalSi.DefaultSetting = @"";
				colvarExamenOdotologicoNormalSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenOdotologicoNormalSi);
				
				TableSchema.TableColumn colvarExamenOdotologicoNormalNo = new TableSchema.TableColumn(schema);
				colvarExamenOdotologicoNormalNo.ColumnName = "ExamenOdotologicoNormalNo";
				colvarExamenOdotologicoNormalNo.DataType = DbType.Boolean;
				colvarExamenOdotologicoNormalNo.MaxLength = 0;
				colvarExamenOdotologicoNormalNo.AutoIncrement = false;
				colvarExamenOdotologicoNormalNo.IsNullable = true;
				colvarExamenOdotologicoNormalNo.IsPrimaryKey = false;
				colvarExamenOdotologicoNormalNo.IsForeignKey = false;
				colvarExamenOdotologicoNormalNo.IsReadOnly = false;
				colvarExamenOdotologicoNormalNo.DefaultSetting = @"";
				colvarExamenOdotologicoNormalNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenOdotologicoNormalNo);
				
				TableSchema.TableColumn colvarExamenMamasNormalSi = new TableSchema.TableColumn(schema);
				colvarExamenMamasNormalSi.ColumnName = "ExamenMamasNormalSi";
				colvarExamenMamasNormalSi.DataType = DbType.Boolean;
				colvarExamenMamasNormalSi.MaxLength = 0;
				colvarExamenMamasNormalSi.AutoIncrement = false;
				colvarExamenMamasNormalSi.IsNullable = true;
				colvarExamenMamasNormalSi.IsPrimaryKey = false;
				colvarExamenMamasNormalSi.IsForeignKey = false;
				colvarExamenMamasNormalSi.IsReadOnly = false;
				colvarExamenMamasNormalSi.DefaultSetting = @"";
				colvarExamenMamasNormalSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenMamasNormalSi);
				
				TableSchema.TableColumn colvarExamenMamasNormalNo = new TableSchema.TableColumn(schema);
				colvarExamenMamasNormalNo.ColumnName = "ExamenMamasNormalNo";
				colvarExamenMamasNormalNo.DataType = DbType.Boolean;
				colvarExamenMamasNormalNo.MaxLength = 0;
				colvarExamenMamasNormalNo.AutoIncrement = false;
				colvarExamenMamasNormalNo.IsNullable = true;
				colvarExamenMamasNormalNo.IsPrimaryKey = false;
				colvarExamenMamasNormalNo.IsForeignKey = false;
				colvarExamenMamasNormalNo.IsReadOnly = false;
				colvarExamenMamasNormalNo.DefaultSetting = @"";
				colvarExamenMamasNormalNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenMamasNormalNo);
				
				TableSchema.TableColumn colvarCervixInspeccionVisualNormal = new TableSchema.TableColumn(schema);
				colvarCervixInspeccionVisualNormal.ColumnName = "CervixInspeccionVisualNormal";
				colvarCervixInspeccionVisualNormal.DataType = DbType.Boolean;
				colvarCervixInspeccionVisualNormal.MaxLength = 0;
				colvarCervixInspeccionVisualNormal.AutoIncrement = false;
				colvarCervixInspeccionVisualNormal.IsNullable = true;
				colvarCervixInspeccionVisualNormal.IsPrimaryKey = false;
				colvarCervixInspeccionVisualNormal.IsForeignKey = false;
				colvarCervixInspeccionVisualNormal.IsReadOnly = false;
				colvarCervixInspeccionVisualNormal.DefaultSetting = @"";
				colvarCervixInspeccionVisualNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixInspeccionVisualNormal);
				
				TableSchema.TableColumn colvarCervixInspeccionVisualAnormal = new TableSchema.TableColumn(schema);
				colvarCervixInspeccionVisualAnormal.ColumnName = "CervixInspeccionVisualAnormal";
				colvarCervixInspeccionVisualAnormal.DataType = DbType.Boolean;
				colvarCervixInspeccionVisualAnormal.MaxLength = 0;
				colvarCervixInspeccionVisualAnormal.AutoIncrement = false;
				colvarCervixInspeccionVisualAnormal.IsNullable = true;
				colvarCervixInspeccionVisualAnormal.IsPrimaryKey = false;
				colvarCervixInspeccionVisualAnormal.IsForeignKey = false;
				colvarCervixInspeccionVisualAnormal.IsReadOnly = false;
				colvarCervixInspeccionVisualAnormal.DefaultSetting = @"";
				colvarCervixInspeccionVisualAnormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixInspeccionVisualAnormal);
				
				TableSchema.TableColumn colvarCervixInspeccionVisualNoSeHizo = new TableSchema.TableColumn(schema);
				colvarCervixInspeccionVisualNoSeHizo.ColumnName = "CervixInspeccionVisualNoSeHizo";
				colvarCervixInspeccionVisualNoSeHizo.DataType = DbType.Boolean;
				colvarCervixInspeccionVisualNoSeHizo.MaxLength = 0;
				colvarCervixInspeccionVisualNoSeHizo.AutoIncrement = false;
				colvarCervixInspeccionVisualNoSeHizo.IsNullable = true;
				colvarCervixInspeccionVisualNoSeHizo.IsPrimaryKey = false;
				colvarCervixInspeccionVisualNoSeHizo.IsForeignKey = false;
				colvarCervixInspeccionVisualNoSeHizo.IsReadOnly = false;
				colvarCervixInspeccionVisualNoSeHizo.DefaultSetting = @"";
				colvarCervixInspeccionVisualNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixInspeccionVisualNoSeHizo);
				
				TableSchema.TableColumn colvarCervixPAPNormal = new TableSchema.TableColumn(schema);
				colvarCervixPAPNormal.ColumnName = "CervixPAPNormal";
				colvarCervixPAPNormal.DataType = DbType.Boolean;
				colvarCervixPAPNormal.MaxLength = 0;
				colvarCervixPAPNormal.AutoIncrement = false;
				colvarCervixPAPNormal.IsNullable = true;
				colvarCervixPAPNormal.IsPrimaryKey = false;
				colvarCervixPAPNormal.IsForeignKey = false;
				colvarCervixPAPNormal.IsReadOnly = false;
				colvarCervixPAPNormal.DefaultSetting = @"";
				colvarCervixPAPNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixPAPNormal);
				
				TableSchema.TableColumn colvarCervixPAPAnormal = new TableSchema.TableColumn(schema);
				colvarCervixPAPAnormal.ColumnName = "CervixPAPAnormal";
				colvarCervixPAPAnormal.DataType = DbType.Boolean;
				colvarCervixPAPAnormal.MaxLength = 0;
				colvarCervixPAPAnormal.AutoIncrement = false;
				colvarCervixPAPAnormal.IsNullable = true;
				colvarCervixPAPAnormal.IsPrimaryKey = false;
				colvarCervixPAPAnormal.IsForeignKey = false;
				colvarCervixPAPAnormal.IsReadOnly = false;
				colvarCervixPAPAnormal.DefaultSetting = @"";
				colvarCervixPAPAnormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixPAPAnormal);
				
				TableSchema.TableColumn colvarCervixPAPNoSeHizo = new TableSchema.TableColumn(schema);
				colvarCervixPAPNoSeHizo.ColumnName = "CervixPAPNoSeHizo";
				colvarCervixPAPNoSeHizo.DataType = DbType.Boolean;
				colvarCervixPAPNoSeHizo.MaxLength = 0;
				colvarCervixPAPNoSeHizo.AutoIncrement = false;
				colvarCervixPAPNoSeHizo.IsNullable = true;
				colvarCervixPAPNoSeHizo.IsPrimaryKey = false;
				colvarCervixPAPNoSeHizo.IsForeignKey = false;
				colvarCervixPAPNoSeHizo.IsReadOnly = false;
				colvarCervixPAPNoSeHizo.DefaultSetting = @"";
				colvarCervixPAPNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixPAPNoSeHizo);
				
				TableSchema.TableColumn colvarCervixCOLPNormal = new TableSchema.TableColumn(schema);
				colvarCervixCOLPNormal.ColumnName = "CervixCOLPNormal";
				colvarCervixCOLPNormal.DataType = DbType.Boolean;
				colvarCervixCOLPNormal.MaxLength = 0;
				colvarCervixCOLPNormal.AutoIncrement = false;
				colvarCervixCOLPNormal.IsNullable = true;
				colvarCervixCOLPNormal.IsPrimaryKey = false;
				colvarCervixCOLPNormal.IsForeignKey = false;
				colvarCervixCOLPNormal.IsReadOnly = false;
				colvarCervixCOLPNormal.DefaultSetting = @"";
				colvarCervixCOLPNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixCOLPNormal);
				
				TableSchema.TableColumn colvarCervixCOLPAnormal = new TableSchema.TableColumn(schema);
				colvarCervixCOLPAnormal.ColumnName = "CervixCOLPAnormal";
				colvarCervixCOLPAnormal.DataType = DbType.Boolean;
				colvarCervixCOLPAnormal.MaxLength = 0;
				colvarCervixCOLPAnormal.AutoIncrement = false;
				colvarCervixCOLPAnormal.IsNullable = true;
				colvarCervixCOLPAnormal.IsPrimaryKey = false;
				colvarCervixCOLPAnormal.IsForeignKey = false;
				colvarCervixCOLPAnormal.IsReadOnly = false;
				colvarCervixCOLPAnormal.DefaultSetting = @"";
				colvarCervixCOLPAnormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixCOLPAnormal);
				
				TableSchema.TableColumn colvarCervixCOLPNoSeHizo = new TableSchema.TableColumn(schema);
				colvarCervixCOLPNoSeHizo.ColumnName = "CervixCOLPNoSeHizo";
				colvarCervixCOLPNoSeHizo.DataType = DbType.Boolean;
				colvarCervixCOLPNoSeHizo.MaxLength = 0;
				colvarCervixCOLPNoSeHizo.AutoIncrement = false;
				colvarCervixCOLPNoSeHizo.IsNullable = true;
				colvarCervixCOLPNoSeHizo.IsPrimaryKey = false;
				colvarCervixCOLPNoSeHizo.IsForeignKey = false;
				colvarCervixCOLPNoSeHizo.IsReadOnly = false;
				colvarCervixCOLPNoSeHizo.DefaultSetting = @"";
				colvarCervixCOLPNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCervixCOLPNoSeHizo);
				
				TableSchema.TableColumn colvarGrupo = new TableSchema.TableColumn(schema);
				colvarGrupo.ColumnName = "Grupo";
				colvarGrupo.DataType = DbType.AnsiString;
				colvarGrupo.MaxLength = -1;
				colvarGrupo.AutoIncrement = false;
				colvarGrupo.IsNullable = true;
				colvarGrupo.IsPrimaryKey = false;
				colvarGrupo.IsForeignKey = false;
				colvarGrupo.IsReadOnly = false;
				colvarGrupo.DefaultSetting = @"";
				colvarGrupo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupo);
				
				TableSchema.TableColumn colvarRHPositivo = new TableSchema.TableColumn(schema);
				colvarRHPositivo.ColumnName = "RHPositivo";
				colvarRHPositivo.DataType = DbType.Boolean;
				colvarRHPositivo.MaxLength = 0;
				colvarRHPositivo.AutoIncrement = false;
				colvarRHPositivo.IsNullable = true;
				colvarRHPositivo.IsPrimaryKey = false;
				colvarRHPositivo.IsForeignKey = false;
				colvarRHPositivo.IsReadOnly = false;
				colvarRHPositivo.DefaultSetting = @"";
				colvarRHPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRHPositivo);
				
				TableSchema.TableColumn colvarRHNegativo = new TableSchema.TableColumn(schema);
				colvarRHNegativo.ColumnName = "RHNegativo";
				colvarRHNegativo.DataType = DbType.Boolean;
				colvarRHNegativo.MaxLength = 0;
				colvarRHNegativo.AutoIncrement = false;
				colvarRHNegativo.IsNullable = true;
				colvarRHNegativo.IsPrimaryKey = false;
				colvarRHNegativo.IsForeignKey = false;
				colvarRHNegativo.IsReadOnly = false;
				colvarRHNegativo.DefaultSetting = @"";
				colvarRHNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRHNegativo);
				
				TableSchema.TableColumn colvarInmunizacionSi = new TableSchema.TableColumn(schema);
				colvarInmunizacionSi.ColumnName = "InmunizacionSi";
				colvarInmunizacionSi.DataType = DbType.Boolean;
				colvarInmunizacionSi.MaxLength = 0;
				colvarInmunizacionSi.AutoIncrement = false;
				colvarInmunizacionSi.IsNullable = true;
				colvarInmunizacionSi.IsPrimaryKey = false;
				colvarInmunizacionSi.IsForeignKey = false;
				colvarInmunizacionSi.IsReadOnly = false;
				colvarInmunizacionSi.DefaultSetting = @"";
				colvarInmunizacionSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInmunizacionSi);
				
				TableSchema.TableColumn colvarInmunizacionNo = new TableSchema.TableColumn(schema);
				colvarInmunizacionNo.ColumnName = "InmunizacionNo";
				colvarInmunizacionNo.DataType = DbType.Boolean;
				colvarInmunizacionNo.MaxLength = 0;
				colvarInmunizacionNo.AutoIncrement = false;
				colvarInmunizacionNo.IsNullable = true;
				colvarInmunizacionNo.IsPrimaryKey = false;
				colvarInmunizacionNo.IsForeignKey = false;
				colvarInmunizacionNo.IsReadOnly = false;
				colvarInmunizacionNo.DefaultSetting = @"";
				colvarInmunizacionNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInmunizacionNo);
				
				TableSchema.TableColumn colvarGammaGlobulinaNo = new TableSchema.TableColumn(schema);
				colvarGammaGlobulinaNo.ColumnName = "GammaGlobulinaNo";
				colvarGammaGlobulinaNo.DataType = DbType.Boolean;
				colvarGammaGlobulinaNo.MaxLength = 0;
				colvarGammaGlobulinaNo.AutoIncrement = false;
				colvarGammaGlobulinaNo.IsNullable = true;
				colvarGammaGlobulinaNo.IsPrimaryKey = false;
				colvarGammaGlobulinaNo.IsForeignKey = false;
				colvarGammaGlobulinaNo.IsReadOnly = false;
				colvarGammaGlobulinaNo.DefaultSetting = @"";
				colvarGammaGlobulinaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGammaGlobulinaNo);
				
				TableSchema.TableColumn colvarGammaGlobulinaSi = new TableSchema.TableColumn(schema);
				colvarGammaGlobulinaSi.ColumnName = "GammaGlobulinaSi";
				colvarGammaGlobulinaSi.DataType = DbType.Boolean;
				colvarGammaGlobulinaSi.MaxLength = 0;
				colvarGammaGlobulinaSi.AutoIncrement = false;
				colvarGammaGlobulinaSi.IsNullable = true;
				colvarGammaGlobulinaSi.IsPrimaryKey = false;
				colvarGammaGlobulinaSi.IsForeignKey = false;
				colvarGammaGlobulinaSi.IsReadOnly = false;
				colvarGammaGlobulinaSi.DefaultSetting = @"";
				colvarGammaGlobulinaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGammaGlobulinaSi);
				
				TableSchema.TableColumn colvarGammaGlobulinaNoCorresponde = new TableSchema.TableColumn(schema);
				colvarGammaGlobulinaNoCorresponde.ColumnName = "GammaGlobulinaNoCorresponde";
				colvarGammaGlobulinaNoCorresponde.DataType = DbType.Boolean;
				colvarGammaGlobulinaNoCorresponde.MaxLength = 0;
				colvarGammaGlobulinaNoCorresponde.AutoIncrement = false;
				colvarGammaGlobulinaNoCorresponde.IsNullable = true;
				colvarGammaGlobulinaNoCorresponde.IsPrimaryKey = false;
				colvarGammaGlobulinaNoCorresponde.IsForeignKey = false;
				colvarGammaGlobulinaNoCorresponde.IsReadOnly = false;
				colvarGammaGlobulinaNoCorresponde.DefaultSetting = @"";
				colvarGammaGlobulinaNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGammaGlobulinaNoCorresponde);
				
				TableSchema.TableColumn colvarToxoPlasmosisMenor20SemLGGNegativo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosisMenor20SemLGGNegativo.ColumnName = "ToxoPlasmosisMenor20SemLGGNegativo";
				colvarToxoPlasmosisMenor20SemLGGNegativo.DataType = DbType.Boolean;
				colvarToxoPlasmosisMenor20SemLGGNegativo.MaxLength = 0;
				colvarToxoPlasmosisMenor20SemLGGNegativo.AutoIncrement = false;
				colvarToxoPlasmosisMenor20SemLGGNegativo.IsNullable = true;
				colvarToxoPlasmosisMenor20SemLGGNegativo.IsPrimaryKey = false;
				colvarToxoPlasmosisMenor20SemLGGNegativo.IsForeignKey = false;
				colvarToxoPlasmosisMenor20SemLGGNegativo.IsReadOnly = false;
				colvarToxoPlasmosisMenor20SemLGGNegativo.DefaultSetting = @"";
				colvarToxoPlasmosisMenor20SemLGGNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosisMenor20SemLGGNegativo);
				
				TableSchema.TableColumn colvarToxoPlasmosisMenor20SemLGGPositivo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosisMenor20SemLGGPositivo.ColumnName = "ToxoPlasmosisMenor20SemLGGPositivo";
				colvarToxoPlasmosisMenor20SemLGGPositivo.DataType = DbType.Boolean;
				colvarToxoPlasmosisMenor20SemLGGPositivo.MaxLength = 0;
				colvarToxoPlasmosisMenor20SemLGGPositivo.AutoIncrement = false;
				colvarToxoPlasmosisMenor20SemLGGPositivo.IsNullable = true;
				colvarToxoPlasmosisMenor20SemLGGPositivo.IsPrimaryKey = false;
				colvarToxoPlasmosisMenor20SemLGGPositivo.IsForeignKey = false;
				colvarToxoPlasmosisMenor20SemLGGPositivo.IsReadOnly = false;
				colvarToxoPlasmosisMenor20SemLGGPositivo.DefaultSetting = @"";
				colvarToxoPlasmosisMenor20SemLGGPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosisMenor20SemLGGPositivo);
				
				TableSchema.TableColumn colvarToxoPlasmosisMenor20SemLGGNoSeHizo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.ColumnName = "ToxoPlasmosisMenor20SemLGGNoSeHizo";
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.DataType = DbType.Boolean;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.MaxLength = 0;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.AutoIncrement = false;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.IsNullable = true;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.IsPrimaryKey = false;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.IsForeignKey = false;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.IsReadOnly = false;
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.DefaultSetting = @"";
				colvarToxoPlasmosisMenor20SemLGGNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosisMenor20SemLGGNoSeHizo);
				
				TableSchema.TableColumn colvarToxoPlasmosisMayor20SemLGGNegativo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosisMayor20SemLGGNegativo.ColumnName = "ToxoPlasmosisMayor20SemLGGNegativo";
				colvarToxoPlasmosisMayor20SemLGGNegativo.DataType = DbType.Boolean;
				colvarToxoPlasmosisMayor20SemLGGNegativo.MaxLength = 0;
				colvarToxoPlasmosisMayor20SemLGGNegativo.AutoIncrement = false;
				colvarToxoPlasmosisMayor20SemLGGNegativo.IsNullable = true;
				colvarToxoPlasmosisMayor20SemLGGNegativo.IsPrimaryKey = false;
				colvarToxoPlasmosisMayor20SemLGGNegativo.IsForeignKey = false;
				colvarToxoPlasmosisMayor20SemLGGNegativo.IsReadOnly = false;
				colvarToxoPlasmosisMayor20SemLGGNegativo.DefaultSetting = @"";
				colvarToxoPlasmosisMayor20SemLGGNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosisMayor20SemLGGNegativo);
				
				TableSchema.TableColumn colvarToxoPlasmosisMayor20SemLGGPositivo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosisMayor20SemLGGPositivo.ColumnName = "ToxoPlasmosisMayor20SemLGGPositivo";
				colvarToxoPlasmosisMayor20SemLGGPositivo.DataType = DbType.Boolean;
				colvarToxoPlasmosisMayor20SemLGGPositivo.MaxLength = 0;
				colvarToxoPlasmosisMayor20SemLGGPositivo.AutoIncrement = false;
				colvarToxoPlasmosisMayor20SemLGGPositivo.IsNullable = true;
				colvarToxoPlasmosisMayor20SemLGGPositivo.IsPrimaryKey = false;
				colvarToxoPlasmosisMayor20SemLGGPositivo.IsForeignKey = false;
				colvarToxoPlasmosisMayor20SemLGGPositivo.IsReadOnly = false;
				colvarToxoPlasmosisMayor20SemLGGPositivo.DefaultSetting = @"";
				colvarToxoPlasmosisMayor20SemLGGPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosisMayor20SemLGGPositivo);
				
				TableSchema.TableColumn colvarToxoPlasmosisMayor20SemLGGNoSeHizo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.ColumnName = "ToxoPlasmosisMayor20SemLGGNoSeHizo";
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.DataType = DbType.Boolean;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.MaxLength = 0;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.AutoIncrement = false;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.IsNullable = true;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.IsPrimaryKey = false;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.IsForeignKey = false;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.IsReadOnly = false;
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.DefaultSetting = @"";
				colvarToxoPlasmosisMayor20SemLGGNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosisMayor20SemLGGNoSeHizo);
				
				TableSchema.TableColumn colvarToxoPlasmosis1ConsultaLGMNegativo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosis1ConsultaLGMNegativo.ColumnName = "ToxoPlasmosis1ConsultaLGMNegativo";
				colvarToxoPlasmosis1ConsultaLGMNegativo.DataType = DbType.Boolean;
				colvarToxoPlasmosis1ConsultaLGMNegativo.MaxLength = 0;
				colvarToxoPlasmosis1ConsultaLGMNegativo.AutoIncrement = false;
				colvarToxoPlasmosis1ConsultaLGMNegativo.IsNullable = true;
				colvarToxoPlasmosis1ConsultaLGMNegativo.IsPrimaryKey = false;
				colvarToxoPlasmosis1ConsultaLGMNegativo.IsForeignKey = false;
				colvarToxoPlasmosis1ConsultaLGMNegativo.IsReadOnly = false;
				colvarToxoPlasmosis1ConsultaLGMNegativo.DefaultSetting = @"";
				colvarToxoPlasmosis1ConsultaLGMNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosis1ConsultaLGMNegativo);
				
				TableSchema.TableColumn colvarToxoPlasmosis1ConsultaLGMPositivo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosis1ConsultaLGMPositivo.ColumnName = "ToxoPlasmosis1ConsultaLGMPositivo";
				colvarToxoPlasmosis1ConsultaLGMPositivo.DataType = DbType.Boolean;
				colvarToxoPlasmosis1ConsultaLGMPositivo.MaxLength = 0;
				colvarToxoPlasmosis1ConsultaLGMPositivo.AutoIncrement = false;
				colvarToxoPlasmosis1ConsultaLGMPositivo.IsNullable = true;
				colvarToxoPlasmosis1ConsultaLGMPositivo.IsPrimaryKey = false;
				colvarToxoPlasmosis1ConsultaLGMPositivo.IsForeignKey = false;
				colvarToxoPlasmosis1ConsultaLGMPositivo.IsReadOnly = false;
				colvarToxoPlasmosis1ConsultaLGMPositivo.DefaultSetting = @"";
				colvarToxoPlasmosis1ConsultaLGMPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosis1ConsultaLGMPositivo);
				
				TableSchema.TableColumn colvarToxoPlasmosis1ConsultaLGMNoSeHizo = new TableSchema.TableColumn(schema);
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.ColumnName = "ToxoPlasmosis1ConsultaLGMNoSeHizo";
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.DataType = DbType.Boolean;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.MaxLength = 0;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.AutoIncrement = false;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.IsNullable = true;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.IsPrimaryKey = false;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.IsForeignKey = false;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.IsReadOnly = false;
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.DefaultSetting = @"";
				colvarToxoPlasmosis1ConsultaLGMNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxoPlasmosis1ConsultaLGMNoSeHizo);
				
				TableSchema.TableColumn colvarChagasNegativo = new TableSchema.TableColumn(schema);
				colvarChagasNegativo.ColumnName = "ChagasNegativo";
				colvarChagasNegativo.DataType = DbType.Boolean;
				colvarChagasNegativo.MaxLength = 0;
				colvarChagasNegativo.AutoIncrement = false;
				colvarChagasNegativo.IsNullable = true;
				colvarChagasNegativo.IsPrimaryKey = false;
				colvarChagasNegativo.IsForeignKey = false;
				colvarChagasNegativo.IsReadOnly = false;
				colvarChagasNegativo.DefaultSetting = @"";
				colvarChagasNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChagasNegativo);
				
				TableSchema.TableColumn colvarChagasPositivo = new TableSchema.TableColumn(schema);
				colvarChagasPositivo.ColumnName = "ChagasPositivo";
				colvarChagasPositivo.DataType = DbType.Boolean;
				colvarChagasPositivo.MaxLength = 0;
				colvarChagasPositivo.AutoIncrement = false;
				colvarChagasPositivo.IsNullable = true;
				colvarChagasPositivo.IsPrimaryKey = false;
				colvarChagasPositivo.IsForeignKey = false;
				colvarChagasPositivo.IsReadOnly = false;
				colvarChagasPositivo.DefaultSetting = @"";
				colvarChagasPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChagasPositivo);
				
				TableSchema.TableColumn colvarChagasNoSeHizo = new TableSchema.TableColumn(schema);
				colvarChagasNoSeHizo.ColumnName = "ChagasNoSeHizo";
				colvarChagasNoSeHizo.DataType = DbType.Boolean;
				colvarChagasNoSeHizo.MaxLength = 0;
				colvarChagasNoSeHizo.AutoIncrement = false;
				colvarChagasNoSeHizo.IsNullable = true;
				colvarChagasNoSeHizo.IsPrimaryKey = false;
				colvarChagasNoSeHizo.IsForeignKey = false;
				colvarChagasNoSeHizo.IsReadOnly = false;
				colvarChagasNoSeHizo.DefaultSetting = @"";
				colvarChagasNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChagasNoSeHizo);
				
				TableSchema.TableColumn colvarHepatitisBNegativo = new TableSchema.TableColumn(schema);
				colvarHepatitisBNegativo.ColumnName = "HepatitisBNegativo";
				colvarHepatitisBNegativo.DataType = DbType.Boolean;
				colvarHepatitisBNegativo.MaxLength = 0;
				colvarHepatitisBNegativo.AutoIncrement = false;
				colvarHepatitisBNegativo.IsNullable = true;
				colvarHepatitisBNegativo.IsPrimaryKey = false;
				colvarHepatitisBNegativo.IsForeignKey = false;
				colvarHepatitisBNegativo.IsReadOnly = false;
				colvarHepatitisBNegativo.DefaultSetting = @"";
				colvarHepatitisBNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHepatitisBNegativo);
				
				TableSchema.TableColumn colvarHepatitisBPositivo = new TableSchema.TableColumn(schema);
				colvarHepatitisBPositivo.ColumnName = "HepatitisBPositivo";
				colvarHepatitisBPositivo.DataType = DbType.Boolean;
				colvarHepatitisBPositivo.MaxLength = 0;
				colvarHepatitisBPositivo.AutoIncrement = false;
				colvarHepatitisBPositivo.IsNullable = true;
				colvarHepatitisBPositivo.IsPrimaryKey = false;
				colvarHepatitisBPositivo.IsForeignKey = false;
				colvarHepatitisBPositivo.IsReadOnly = false;
				colvarHepatitisBPositivo.DefaultSetting = @"";
				colvarHepatitisBPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHepatitisBPositivo);
				
				TableSchema.TableColumn colvarHepatitisBNoSeHizo = new TableSchema.TableColumn(schema);
				colvarHepatitisBNoSeHizo.ColumnName = "HepatitisBNoSeHizo";
				colvarHepatitisBNoSeHizo.DataType = DbType.Boolean;
				colvarHepatitisBNoSeHizo.MaxLength = 0;
				colvarHepatitisBNoSeHizo.AutoIncrement = false;
				colvarHepatitisBNoSeHizo.IsNullable = true;
				colvarHepatitisBNoSeHizo.IsPrimaryKey = false;
				colvarHepatitisBNoSeHizo.IsForeignKey = false;
				colvarHepatitisBNoSeHizo.IsReadOnly = false;
				colvarHepatitisBNoSeHizo.DefaultSetting = @"";
				colvarHepatitisBNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHepatitisBNoSeHizo);
				
				TableSchema.TableColumn colvarBacteriuraMenor20SemNormal = new TableSchema.TableColumn(schema);
				colvarBacteriuraMenor20SemNormal.ColumnName = "BacteriuraMenor20SemNormal";
				colvarBacteriuraMenor20SemNormal.DataType = DbType.Boolean;
				colvarBacteriuraMenor20SemNormal.MaxLength = 0;
				colvarBacteriuraMenor20SemNormal.AutoIncrement = false;
				colvarBacteriuraMenor20SemNormal.IsNullable = true;
				colvarBacteriuraMenor20SemNormal.IsPrimaryKey = false;
				colvarBacteriuraMenor20SemNormal.IsForeignKey = false;
				colvarBacteriuraMenor20SemNormal.IsReadOnly = false;
				colvarBacteriuraMenor20SemNormal.DefaultSetting = @"";
				colvarBacteriuraMenor20SemNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBacteriuraMenor20SemNormal);
				
				TableSchema.TableColumn colvarBacteriuraMenor20SemAnormal = new TableSchema.TableColumn(schema);
				colvarBacteriuraMenor20SemAnormal.ColumnName = "BacteriuraMenor20SemAnormal";
				colvarBacteriuraMenor20SemAnormal.DataType = DbType.Boolean;
				colvarBacteriuraMenor20SemAnormal.MaxLength = 0;
				colvarBacteriuraMenor20SemAnormal.AutoIncrement = false;
				colvarBacteriuraMenor20SemAnormal.IsNullable = true;
				colvarBacteriuraMenor20SemAnormal.IsPrimaryKey = false;
				colvarBacteriuraMenor20SemAnormal.IsForeignKey = false;
				colvarBacteriuraMenor20SemAnormal.IsReadOnly = false;
				colvarBacteriuraMenor20SemAnormal.DefaultSetting = @"";
				colvarBacteriuraMenor20SemAnormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBacteriuraMenor20SemAnormal);
				
				TableSchema.TableColumn colvarBacteriuraMenor20SemNoSeHizo = new TableSchema.TableColumn(schema);
				colvarBacteriuraMenor20SemNoSeHizo.ColumnName = "BacteriuraMenor20SemNoSeHizo";
				colvarBacteriuraMenor20SemNoSeHizo.DataType = DbType.Boolean;
				colvarBacteriuraMenor20SemNoSeHizo.MaxLength = 0;
				colvarBacteriuraMenor20SemNoSeHizo.AutoIncrement = false;
				colvarBacteriuraMenor20SemNoSeHizo.IsNullable = true;
				colvarBacteriuraMenor20SemNoSeHizo.IsPrimaryKey = false;
				colvarBacteriuraMenor20SemNoSeHizo.IsForeignKey = false;
				colvarBacteriuraMenor20SemNoSeHizo.IsReadOnly = false;
				colvarBacteriuraMenor20SemNoSeHizo.DefaultSetting = @"";
				colvarBacteriuraMenor20SemNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBacteriuraMenor20SemNoSeHizo);
				
				TableSchema.TableColumn colvarBacteriuraMayor20SemNormal = new TableSchema.TableColumn(schema);
				colvarBacteriuraMayor20SemNormal.ColumnName = "BacteriuraMayor20SemNormal";
				colvarBacteriuraMayor20SemNormal.DataType = DbType.Boolean;
				colvarBacteriuraMayor20SemNormal.MaxLength = 0;
				colvarBacteriuraMayor20SemNormal.AutoIncrement = false;
				colvarBacteriuraMayor20SemNormal.IsNullable = true;
				colvarBacteriuraMayor20SemNormal.IsPrimaryKey = false;
				colvarBacteriuraMayor20SemNormal.IsForeignKey = false;
				colvarBacteriuraMayor20SemNormal.IsReadOnly = false;
				colvarBacteriuraMayor20SemNormal.DefaultSetting = @"";
				colvarBacteriuraMayor20SemNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBacteriuraMayor20SemNormal);
				
				TableSchema.TableColumn colvarBacteriuraMayor20SemAnormal = new TableSchema.TableColumn(schema);
				colvarBacteriuraMayor20SemAnormal.ColumnName = "BacteriuraMayor20SemAnormal";
				colvarBacteriuraMayor20SemAnormal.DataType = DbType.Boolean;
				colvarBacteriuraMayor20SemAnormal.MaxLength = 0;
				colvarBacteriuraMayor20SemAnormal.AutoIncrement = false;
				colvarBacteriuraMayor20SemAnormal.IsNullable = true;
				colvarBacteriuraMayor20SemAnormal.IsPrimaryKey = false;
				colvarBacteriuraMayor20SemAnormal.IsForeignKey = false;
				colvarBacteriuraMayor20SemAnormal.IsReadOnly = false;
				colvarBacteriuraMayor20SemAnormal.DefaultSetting = @"";
				colvarBacteriuraMayor20SemAnormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBacteriuraMayor20SemAnormal);
				
				TableSchema.TableColumn colvarBacteriuraMayor20SemNoSeHizo = new TableSchema.TableColumn(schema);
				colvarBacteriuraMayor20SemNoSeHizo.ColumnName = "BacteriuraMayor20SemNoSeHizo";
				colvarBacteriuraMayor20SemNoSeHizo.DataType = DbType.Boolean;
				colvarBacteriuraMayor20SemNoSeHizo.MaxLength = 0;
				colvarBacteriuraMayor20SemNoSeHizo.AutoIncrement = false;
				colvarBacteriuraMayor20SemNoSeHizo.IsNullable = true;
				colvarBacteriuraMayor20SemNoSeHizo.IsPrimaryKey = false;
				colvarBacteriuraMayor20SemNoSeHizo.IsForeignKey = false;
				colvarBacteriuraMayor20SemNoSeHizo.IsReadOnly = false;
				colvarBacteriuraMayor20SemNoSeHizo.DefaultSetting = @"";
				colvarBacteriuraMayor20SemNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBacteriuraMayor20SemNoSeHizo);
				
				TableSchema.TableColumn colvarGlucemiaMenor20Sem = new TableSchema.TableColumn(schema);
				colvarGlucemiaMenor20Sem.ColumnName = "GlucemiaMenor20Sem";
				colvarGlucemiaMenor20Sem.DataType = DbType.Decimal;
				colvarGlucemiaMenor20Sem.MaxLength = 0;
				colvarGlucemiaMenor20Sem.AutoIncrement = false;
				colvarGlucemiaMenor20Sem.IsNullable = true;
				colvarGlucemiaMenor20Sem.IsPrimaryKey = false;
				colvarGlucemiaMenor20Sem.IsForeignKey = false;
				colvarGlucemiaMenor20Sem.IsReadOnly = false;
				colvarGlucemiaMenor20Sem.DefaultSetting = @"";
				colvarGlucemiaMenor20Sem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucemiaMenor20Sem);
				
				TableSchema.TableColumn colvarGlucemiaMenor20SemMayor105 = new TableSchema.TableColumn(schema);
				colvarGlucemiaMenor20SemMayor105.ColumnName = "GlucemiaMenor20SemMayor105";
				colvarGlucemiaMenor20SemMayor105.DataType = DbType.Boolean;
				colvarGlucemiaMenor20SemMayor105.MaxLength = 0;
				colvarGlucemiaMenor20SemMayor105.AutoIncrement = false;
				colvarGlucemiaMenor20SemMayor105.IsNullable = true;
				colvarGlucemiaMenor20SemMayor105.IsPrimaryKey = false;
				colvarGlucemiaMenor20SemMayor105.IsForeignKey = false;
				colvarGlucemiaMenor20SemMayor105.IsReadOnly = false;
				colvarGlucemiaMenor20SemMayor105.DefaultSetting = @"";
				colvarGlucemiaMenor20SemMayor105.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucemiaMenor20SemMayor105);
				
				TableSchema.TableColumn colvarGlucemiaMayor20Sem = new TableSchema.TableColumn(schema);
				colvarGlucemiaMayor20Sem.ColumnName = "GlucemiaMayor20Sem";
				colvarGlucemiaMayor20Sem.DataType = DbType.Decimal;
				colvarGlucemiaMayor20Sem.MaxLength = 0;
				colvarGlucemiaMayor20Sem.AutoIncrement = false;
				colvarGlucemiaMayor20Sem.IsNullable = true;
				colvarGlucemiaMayor20Sem.IsPrimaryKey = false;
				colvarGlucemiaMayor20Sem.IsForeignKey = false;
				colvarGlucemiaMayor20Sem.IsReadOnly = false;
				colvarGlucemiaMayor20Sem.DefaultSetting = @"";
				colvarGlucemiaMayor20Sem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucemiaMayor20Sem);
				
				TableSchema.TableColumn colvarGlucemiaMayor20SemMayor105 = new TableSchema.TableColumn(schema);
				colvarGlucemiaMayor20SemMayor105.ColumnName = "GlucemiaMayor20SemMayor105";
				colvarGlucemiaMayor20SemMayor105.DataType = DbType.Boolean;
				colvarGlucemiaMayor20SemMayor105.MaxLength = 0;
				colvarGlucemiaMayor20SemMayor105.AutoIncrement = false;
				colvarGlucemiaMayor20SemMayor105.IsNullable = true;
				colvarGlucemiaMayor20SemMayor105.IsPrimaryKey = false;
				colvarGlucemiaMayor20SemMayor105.IsForeignKey = false;
				colvarGlucemiaMayor20SemMayor105.IsReadOnly = false;
				colvarGlucemiaMayor20SemMayor105.DefaultSetting = @"";
				colvarGlucemiaMayor20SemMayor105.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucemiaMayor20SemMayor105);
				
				TableSchema.TableColumn colvarVIHCRSi = new TableSchema.TableColumn(schema);
				colvarVIHCRSi.ColumnName = "VIHCRSi";
				colvarVIHCRSi.DataType = DbType.Boolean;
				colvarVIHCRSi.MaxLength = 0;
				colvarVIHCRSi.AutoIncrement = false;
				colvarVIHCRSi.IsNullable = true;
				colvarVIHCRSi.IsPrimaryKey = false;
				colvarVIHCRSi.IsForeignKey = false;
				colvarVIHCRSi.IsReadOnly = false;
				colvarVIHCRSi.DefaultSetting = @"";
				colvarVIHCRSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHCRSi);
				
				TableSchema.TableColumn colvarVIHCRNo = new TableSchema.TableColumn(schema);
				colvarVIHCRNo.ColumnName = "VIHCRNo";
				colvarVIHCRNo.DataType = DbType.Boolean;
				colvarVIHCRNo.MaxLength = 0;
				colvarVIHCRNo.AutoIncrement = false;
				colvarVIHCRNo.IsNullable = true;
				colvarVIHCRNo.IsPrimaryKey = false;
				colvarVIHCRNo.IsForeignKey = false;
				colvarVIHCRNo.IsReadOnly = false;
				colvarVIHCRNo.DefaultSetting = @"";
				colvarVIHCRNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHCRNo);
				
				TableSchema.TableColumn colvarVIHPrimerMuestraSolicitadoSi = new TableSchema.TableColumn(schema);
				colvarVIHPrimerMuestraSolicitadoSi.ColumnName = "VIHPrimerMuestraSolicitadoSi";
				colvarVIHPrimerMuestraSolicitadoSi.DataType = DbType.Boolean;
				colvarVIHPrimerMuestraSolicitadoSi.MaxLength = 0;
				colvarVIHPrimerMuestraSolicitadoSi.AutoIncrement = false;
				colvarVIHPrimerMuestraSolicitadoSi.IsNullable = true;
				colvarVIHPrimerMuestraSolicitadoSi.IsPrimaryKey = false;
				colvarVIHPrimerMuestraSolicitadoSi.IsForeignKey = false;
				colvarVIHPrimerMuestraSolicitadoSi.IsReadOnly = false;
				colvarVIHPrimerMuestraSolicitadoSi.DefaultSetting = @"";
				colvarVIHPrimerMuestraSolicitadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHPrimerMuestraSolicitadoSi);
				
				TableSchema.TableColumn colvarVIHPrimerMuestraSolicitadoNo = new TableSchema.TableColumn(schema);
				colvarVIHPrimerMuestraSolicitadoNo.ColumnName = "VIHPrimerMuestraSolicitadoNo";
				colvarVIHPrimerMuestraSolicitadoNo.DataType = DbType.Boolean;
				colvarVIHPrimerMuestraSolicitadoNo.MaxLength = 0;
				colvarVIHPrimerMuestraSolicitadoNo.AutoIncrement = false;
				colvarVIHPrimerMuestraSolicitadoNo.IsNullable = true;
				colvarVIHPrimerMuestraSolicitadoNo.IsPrimaryKey = false;
				colvarVIHPrimerMuestraSolicitadoNo.IsForeignKey = false;
				colvarVIHPrimerMuestraSolicitadoNo.IsReadOnly = false;
				colvarVIHPrimerMuestraSolicitadoNo.DefaultSetting = @"";
				colvarVIHPrimerMuestraSolicitadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHPrimerMuestraSolicitadoNo);
				
				TableSchema.TableColumn colvarVIHPrimerMuestraRealizadoSi = new TableSchema.TableColumn(schema);
				colvarVIHPrimerMuestraRealizadoSi.ColumnName = "VIHPrimerMuestraRealizadoSi";
				colvarVIHPrimerMuestraRealizadoSi.DataType = DbType.Boolean;
				colvarVIHPrimerMuestraRealizadoSi.MaxLength = 0;
				colvarVIHPrimerMuestraRealizadoSi.AutoIncrement = false;
				colvarVIHPrimerMuestraRealizadoSi.IsNullable = true;
				colvarVIHPrimerMuestraRealizadoSi.IsPrimaryKey = false;
				colvarVIHPrimerMuestraRealizadoSi.IsForeignKey = false;
				colvarVIHPrimerMuestraRealizadoSi.IsReadOnly = false;
				colvarVIHPrimerMuestraRealizadoSi.DefaultSetting = @"";
				colvarVIHPrimerMuestraRealizadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHPrimerMuestraRealizadoSi);
				
				TableSchema.TableColumn colvarVIHPrimerMuestraRealizadoNo = new TableSchema.TableColumn(schema);
				colvarVIHPrimerMuestraRealizadoNo.ColumnName = "VIHPrimerMuestraRealizadoNo";
				colvarVIHPrimerMuestraRealizadoNo.DataType = DbType.Boolean;
				colvarVIHPrimerMuestraRealizadoNo.MaxLength = 0;
				colvarVIHPrimerMuestraRealizadoNo.AutoIncrement = false;
				colvarVIHPrimerMuestraRealizadoNo.IsNullable = true;
				colvarVIHPrimerMuestraRealizadoNo.IsPrimaryKey = false;
				colvarVIHPrimerMuestraRealizadoNo.IsForeignKey = false;
				colvarVIHPrimerMuestraRealizadoNo.IsReadOnly = false;
				colvarVIHPrimerMuestraRealizadoNo.DefaultSetting = @"";
				colvarVIHPrimerMuestraRealizadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHPrimerMuestraRealizadoNo);
				
				TableSchema.TableColumn colvarVIHPrimerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarVIHPrimerMuestraFecha.ColumnName = "VIHPrimerMuestraFecha";
				colvarVIHPrimerMuestraFecha.DataType = DbType.DateTime;
				colvarVIHPrimerMuestraFecha.MaxLength = 0;
				colvarVIHPrimerMuestraFecha.AutoIncrement = false;
				colvarVIHPrimerMuestraFecha.IsNullable = true;
				colvarVIHPrimerMuestraFecha.IsPrimaryKey = false;
				colvarVIHPrimerMuestraFecha.IsForeignKey = false;
				colvarVIHPrimerMuestraFecha.IsReadOnly = false;
				colvarVIHPrimerMuestraFecha.DefaultSetting = @"";
				colvarVIHPrimerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHPrimerMuestraFecha);
				
				TableSchema.TableColumn colvarHBMenor20Sem = new TableSchema.TableColumn(schema);
				colvarHBMenor20Sem.ColumnName = "HBMenor20Sem";
				colvarHBMenor20Sem.DataType = DbType.Decimal;
				colvarHBMenor20Sem.MaxLength = 0;
				colvarHBMenor20Sem.AutoIncrement = false;
				colvarHBMenor20Sem.IsNullable = true;
				colvarHBMenor20Sem.IsPrimaryKey = false;
				colvarHBMenor20Sem.IsForeignKey = false;
				colvarHBMenor20Sem.IsReadOnly = false;
				colvarHBMenor20Sem.DefaultSetting = @"";
				colvarHBMenor20Sem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHBMenor20Sem);
				
				TableSchema.TableColumn colvarHBMenor20SemMenor11 = new TableSchema.TableColumn(schema);
				colvarHBMenor20SemMenor11.ColumnName = "HBMenor20SemMenor11";
				colvarHBMenor20SemMenor11.DataType = DbType.Boolean;
				colvarHBMenor20SemMenor11.MaxLength = 0;
				colvarHBMenor20SemMenor11.AutoIncrement = false;
				colvarHBMenor20SemMenor11.IsNullable = true;
				colvarHBMenor20SemMenor11.IsPrimaryKey = false;
				colvarHBMenor20SemMenor11.IsForeignKey = false;
				colvarHBMenor20SemMenor11.IsReadOnly = false;
				colvarHBMenor20SemMenor11.DefaultSetting = @"";
				colvarHBMenor20SemMenor11.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHBMenor20SemMenor11);
				
				TableSchema.TableColumn colvarHBMayor20Sem = new TableSchema.TableColumn(schema);
				colvarHBMayor20Sem.ColumnName = "HBMayor20Sem";
				colvarHBMayor20Sem.DataType = DbType.Decimal;
				colvarHBMayor20Sem.MaxLength = 0;
				colvarHBMayor20Sem.AutoIncrement = false;
				colvarHBMayor20Sem.IsNullable = true;
				colvarHBMayor20Sem.IsPrimaryKey = false;
				colvarHBMayor20Sem.IsForeignKey = false;
				colvarHBMayor20Sem.IsReadOnly = false;
				colvarHBMayor20Sem.DefaultSetting = @"";
				colvarHBMayor20Sem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHBMayor20Sem);
				
				TableSchema.TableColumn colvarHBMayor20SemMenor11 = new TableSchema.TableColumn(schema);
				colvarHBMayor20SemMenor11.ColumnName = "HBMayor20SemMenor11";
				colvarHBMayor20SemMenor11.DataType = DbType.Boolean;
				colvarHBMayor20SemMenor11.MaxLength = 0;
				colvarHBMayor20SemMenor11.AutoIncrement = false;
				colvarHBMayor20SemMenor11.IsNullable = true;
				colvarHBMayor20SemMenor11.IsPrimaryKey = false;
				colvarHBMayor20SemMenor11.IsForeignKey = false;
				colvarHBMayor20SemMenor11.IsReadOnly = false;
				colvarHBMayor20SemMenor11.DefaultSetting = @"";
				colvarHBMayor20SemMenor11.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHBMayor20SemMenor11);
				
				TableSchema.TableColumn colvarFeIndicadoSi = new TableSchema.TableColumn(schema);
				colvarFeIndicadoSi.ColumnName = "FeIndicadoSi";
				colvarFeIndicadoSi.DataType = DbType.Boolean;
				colvarFeIndicadoSi.MaxLength = 0;
				colvarFeIndicadoSi.AutoIncrement = false;
				colvarFeIndicadoSi.IsNullable = true;
				colvarFeIndicadoSi.IsPrimaryKey = false;
				colvarFeIndicadoSi.IsForeignKey = false;
				colvarFeIndicadoSi.IsReadOnly = false;
				colvarFeIndicadoSi.DefaultSetting = @"";
				colvarFeIndicadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeIndicadoSi);
				
				TableSchema.TableColumn colvarFeIndicadoNo = new TableSchema.TableColumn(schema);
				colvarFeIndicadoNo.ColumnName = "FeIndicadoNo";
				colvarFeIndicadoNo.DataType = DbType.Boolean;
				colvarFeIndicadoNo.MaxLength = 0;
				colvarFeIndicadoNo.AutoIncrement = false;
				colvarFeIndicadoNo.IsNullable = true;
				colvarFeIndicadoNo.IsPrimaryKey = false;
				colvarFeIndicadoNo.IsForeignKey = false;
				colvarFeIndicadoNo.IsReadOnly = false;
				colvarFeIndicadoNo.DefaultSetting = @"";
				colvarFeIndicadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeIndicadoNo);
				
				TableSchema.TableColumn colvarFolatosIndicadosSi = new TableSchema.TableColumn(schema);
				colvarFolatosIndicadosSi.ColumnName = "FolatosIndicadosSi";
				colvarFolatosIndicadosSi.DataType = DbType.Boolean;
				colvarFolatosIndicadosSi.MaxLength = 0;
				colvarFolatosIndicadosSi.AutoIncrement = false;
				colvarFolatosIndicadosSi.IsNullable = true;
				colvarFolatosIndicadosSi.IsPrimaryKey = false;
				colvarFolatosIndicadosSi.IsForeignKey = false;
				colvarFolatosIndicadosSi.IsReadOnly = false;
				colvarFolatosIndicadosSi.DefaultSetting = @"";
				colvarFolatosIndicadosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFolatosIndicadosSi);
				
				TableSchema.TableColumn colvarFolatosIndicadosNo = new TableSchema.TableColumn(schema);
				colvarFolatosIndicadosNo.ColumnName = "FolatosIndicadosNo";
				colvarFolatosIndicadosNo.DataType = DbType.Boolean;
				colvarFolatosIndicadosNo.MaxLength = 0;
				colvarFolatosIndicadosNo.AutoIncrement = false;
				colvarFolatosIndicadosNo.IsNullable = true;
				colvarFolatosIndicadosNo.IsPrimaryKey = false;
				colvarFolatosIndicadosNo.IsForeignKey = false;
				colvarFolatosIndicadosNo.IsReadOnly = false;
				colvarFolatosIndicadosNo.DefaultSetting = @"";
				colvarFolatosIndicadosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFolatosIndicadosNo);
				
				TableSchema.TableColumn colvarEstreptococoB3537SemanasNegativo = new TableSchema.TableColumn(schema);
				colvarEstreptococoB3537SemanasNegativo.ColumnName = "EstreptococoB3537SemanasNegativo";
				colvarEstreptococoB3537SemanasNegativo.DataType = DbType.Boolean;
				colvarEstreptococoB3537SemanasNegativo.MaxLength = 0;
				colvarEstreptococoB3537SemanasNegativo.AutoIncrement = false;
				colvarEstreptococoB3537SemanasNegativo.IsNullable = true;
				colvarEstreptococoB3537SemanasNegativo.IsPrimaryKey = false;
				colvarEstreptococoB3537SemanasNegativo.IsForeignKey = false;
				colvarEstreptococoB3537SemanasNegativo.IsReadOnly = false;
				colvarEstreptococoB3537SemanasNegativo.DefaultSetting = @"";
				colvarEstreptococoB3537SemanasNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstreptococoB3537SemanasNegativo);
				
				TableSchema.TableColumn colvarEstreptococoB3537SemanasPositivo = new TableSchema.TableColumn(schema);
				colvarEstreptococoB3537SemanasPositivo.ColumnName = "EstreptococoB3537SemanasPositivo";
				colvarEstreptococoB3537SemanasPositivo.DataType = DbType.Boolean;
				colvarEstreptococoB3537SemanasPositivo.MaxLength = 0;
				colvarEstreptococoB3537SemanasPositivo.AutoIncrement = false;
				colvarEstreptococoB3537SemanasPositivo.IsNullable = true;
				colvarEstreptococoB3537SemanasPositivo.IsPrimaryKey = false;
				colvarEstreptococoB3537SemanasPositivo.IsForeignKey = false;
				colvarEstreptococoB3537SemanasPositivo.IsReadOnly = false;
				colvarEstreptococoB3537SemanasPositivo.DefaultSetting = @"";
				colvarEstreptococoB3537SemanasPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstreptococoB3537SemanasPositivo);
				
				TableSchema.TableColumn colvarEstreptococoB3537SemanasNoSeHizo = new TableSchema.TableColumn(schema);
				colvarEstreptococoB3537SemanasNoSeHizo.ColumnName = "EstreptococoB3537SemanasNoSeHizo";
				colvarEstreptococoB3537SemanasNoSeHizo.DataType = DbType.Boolean;
				colvarEstreptococoB3537SemanasNoSeHizo.MaxLength = 0;
				colvarEstreptococoB3537SemanasNoSeHizo.AutoIncrement = false;
				colvarEstreptococoB3537SemanasNoSeHizo.IsNullable = true;
				colvarEstreptococoB3537SemanasNoSeHizo.IsPrimaryKey = false;
				colvarEstreptococoB3537SemanasNoSeHizo.IsForeignKey = false;
				colvarEstreptococoB3537SemanasNoSeHizo.IsReadOnly = false;
				colvarEstreptococoB3537SemanasNoSeHizo.DefaultSetting = @"";
				colvarEstreptococoB3537SemanasNoSeHizo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstreptococoB3537SemanasNoSeHizo);
				
				TableSchema.TableColumn colvarPreparacionPartoSi = new TableSchema.TableColumn(schema);
				colvarPreparacionPartoSi.ColumnName = "PreparacionPartoSi";
				colvarPreparacionPartoSi.DataType = DbType.Boolean;
				colvarPreparacionPartoSi.MaxLength = 0;
				colvarPreparacionPartoSi.AutoIncrement = false;
				colvarPreparacionPartoSi.IsNullable = true;
				colvarPreparacionPartoSi.IsPrimaryKey = false;
				colvarPreparacionPartoSi.IsForeignKey = false;
				colvarPreparacionPartoSi.IsReadOnly = false;
				colvarPreparacionPartoSi.DefaultSetting = @"";
				colvarPreparacionPartoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPreparacionPartoSi);
				
				TableSchema.TableColumn colvarPreparacionPartoNo = new TableSchema.TableColumn(schema);
				colvarPreparacionPartoNo.ColumnName = "PreparacionPartoNo";
				colvarPreparacionPartoNo.DataType = DbType.Boolean;
				colvarPreparacionPartoNo.MaxLength = 0;
				colvarPreparacionPartoNo.AutoIncrement = false;
				colvarPreparacionPartoNo.IsNullable = true;
				colvarPreparacionPartoNo.IsPrimaryKey = false;
				colvarPreparacionPartoNo.IsForeignKey = false;
				colvarPreparacionPartoNo.IsReadOnly = false;
				colvarPreparacionPartoNo.DefaultSetting = @"";
				colvarPreparacionPartoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPreparacionPartoNo);
				
				TableSchema.TableColumn colvarConsejeriaLactanciaMaternaSi = new TableSchema.TableColumn(schema);
				colvarConsejeriaLactanciaMaternaSi.ColumnName = "ConsejeriaLactanciaMaternaSi";
				colvarConsejeriaLactanciaMaternaSi.DataType = DbType.Boolean;
				colvarConsejeriaLactanciaMaternaSi.MaxLength = 0;
				colvarConsejeriaLactanciaMaternaSi.AutoIncrement = false;
				colvarConsejeriaLactanciaMaternaSi.IsNullable = true;
				colvarConsejeriaLactanciaMaternaSi.IsPrimaryKey = false;
				colvarConsejeriaLactanciaMaternaSi.IsForeignKey = false;
				colvarConsejeriaLactanciaMaternaSi.IsReadOnly = false;
				colvarConsejeriaLactanciaMaternaSi.DefaultSetting = @"";
				colvarConsejeriaLactanciaMaternaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsejeriaLactanciaMaternaSi);
				
				TableSchema.TableColumn colvarConsejeriaLactanciaMaternaNo = new TableSchema.TableColumn(schema);
				colvarConsejeriaLactanciaMaternaNo.ColumnName = "ConsejeriaLactanciaMaternaNo";
				colvarConsejeriaLactanciaMaternaNo.DataType = DbType.Boolean;
				colvarConsejeriaLactanciaMaternaNo.MaxLength = 0;
				colvarConsejeriaLactanciaMaternaNo.AutoIncrement = false;
				colvarConsejeriaLactanciaMaternaNo.IsNullable = true;
				colvarConsejeriaLactanciaMaternaNo.IsPrimaryKey = false;
				colvarConsejeriaLactanciaMaternaNo.IsForeignKey = false;
				colvarConsejeriaLactanciaMaternaNo.IsReadOnly = false;
				colvarConsejeriaLactanciaMaternaNo.DefaultSetting = @"";
				colvarConsejeriaLactanciaMaternaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsejeriaLactanciaMaternaNo);
				
				TableSchema.TableColumn colvarSifilisTratParejaMenor20SemNo = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMenor20SemNo.ColumnName = "SifilisTratParejaMenor20SemNo";
				colvarSifilisTratParejaMenor20SemNo.DataType = DbType.Boolean;
				colvarSifilisTratParejaMenor20SemNo.MaxLength = 0;
				colvarSifilisTratParejaMenor20SemNo.AutoIncrement = false;
				colvarSifilisTratParejaMenor20SemNo.IsNullable = true;
				colvarSifilisTratParejaMenor20SemNo.IsPrimaryKey = false;
				colvarSifilisTratParejaMenor20SemNo.IsForeignKey = false;
				colvarSifilisTratParejaMenor20SemNo.IsReadOnly = false;
				colvarSifilisTratParejaMenor20SemNo.DefaultSetting = @"";
				colvarSifilisTratParejaMenor20SemNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMenor20SemNo);
				
				TableSchema.TableColumn colvarSifilisTratParejaMenor20SemSi = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMenor20SemSi.ColumnName = "SifilisTratParejaMenor20SemSi";
				colvarSifilisTratParejaMenor20SemSi.DataType = DbType.Boolean;
				colvarSifilisTratParejaMenor20SemSi.MaxLength = 0;
				colvarSifilisTratParejaMenor20SemSi.AutoIncrement = false;
				colvarSifilisTratParejaMenor20SemSi.IsNullable = true;
				colvarSifilisTratParejaMenor20SemSi.IsPrimaryKey = false;
				colvarSifilisTratParejaMenor20SemSi.IsForeignKey = false;
				colvarSifilisTratParejaMenor20SemSi.IsReadOnly = false;
				colvarSifilisTratParejaMenor20SemSi.DefaultSetting = @"";
				colvarSifilisTratParejaMenor20SemSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMenor20SemSi);
				
				TableSchema.TableColumn colvarSifilisTratParejaMenor20SemSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMenor20SemSinDatos.ColumnName = "SifilisTratParejaMenor20SemSinDatos";
				colvarSifilisTratParejaMenor20SemSinDatos.DataType = DbType.Boolean;
				colvarSifilisTratParejaMenor20SemSinDatos.MaxLength = 0;
				colvarSifilisTratParejaMenor20SemSinDatos.AutoIncrement = false;
				colvarSifilisTratParejaMenor20SemSinDatos.IsNullable = true;
				colvarSifilisTratParejaMenor20SemSinDatos.IsPrimaryKey = false;
				colvarSifilisTratParejaMenor20SemSinDatos.IsForeignKey = false;
				colvarSifilisTratParejaMenor20SemSinDatos.IsReadOnly = false;
				colvarSifilisTratParejaMenor20SemSinDatos.DefaultSetting = @"";
				colvarSifilisTratParejaMenor20SemSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMenor20SemSinDatos);
				
				TableSchema.TableColumn colvarSifilisTratParejaMenor20SemNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMenor20SemNoCorresponde.ColumnName = "SifilisTratParejaMenor20SemNoCorresponde";
				colvarSifilisTratParejaMenor20SemNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisTratParejaMenor20SemNoCorresponde.MaxLength = 0;
				colvarSifilisTratParejaMenor20SemNoCorresponde.AutoIncrement = false;
				colvarSifilisTratParejaMenor20SemNoCorresponde.IsNullable = true;
				colvarSifilisTratParejaMenor20SemNoCorresponde.IsPrimaryKey = false;
				colvarSifilisTratParejaMenor20SemNoCorresponde.IsForeignKey = false;
				colvarSifilisTratParejaMenor20SemNoCorresponde.IsReadOnly = false;
				colvarSifilisTratParejaMenor20SemNoCorresponde.DefaultSetting = @"";
				colvarSifilisTratParejaMenor20SemNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMenor20SemNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisTratParejaMayor20SemNo = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMayor20SemNo.ColumnName = "SifilisTratParejaMayor20SemNo";
				colvarSifilisTratParejaMayor20SemNo.DataType = DbType.Boolean;
				colvarSifilisTratParejaMayor20SemNo.MaxLength = 0;
				colvarSifilisTratParejaMayor20SemNo.AutoIncrement = false;
				colvarSifilisTratParejaMayor20SemNo.IsNullable = true;
				colvarSifilisTratParejaMayor20SemNo.IsPrimaryKey = false;
				colvarSifilisTratParejaMayor20SemNo.IsForeignKey = false;
				colvarSifilisTratParejaMayor20SemNo.IsReadOnly = false;
				colvarSifilisTratParejaMayor20SemNo.DefaultSetting = @"";
				colvarSifilisTratParejaMayor20SemNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMayor20SemNo);
				
				TableSchema.TableColumn colvarSifilisTratParejaMayor20SemSi = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMayor20SemSi.ColumnName = "SifilisTratParejaMayor20SemSi";
				colvarSifilisTratParejaMayor20SemSi.DataType = DbType.Boolean;
				colvarSifilisTratParejaMayor20SemSi.MaxLength = 0;
				colvarSifilisTratParejaMayor20SemSi.AutoIncrement = false;
				colvarSifilisTratParejaMayor20SemSi.IsNullable = true;
				colvarSifilisTratParejaMayor20SemSi.IsPrimaryKey = false;
				colvarSifilisTratParejaMayor20SemSi.IsForeignKey = false;
				colvarSifilisTratParejaMayor20SemSi.IsReadOnly = false;
				colvarSifilisTratParejaMayor20SemSi.DefaultSetting = @"";
				colvarSifilisTratParejaMayor20SemSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMayor20SemSi);
				
				TableSchema.TableColumn colvarSifilisTratParejaMayor20SemSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMayor20SemSinDatos.ColumnName = "SifilisTratParejaMayor20SemSinDatos";
				colvarSifilisTratParejaMayor20SemSinDatos.DataType = DbType.Boolean;
				colvarSifilisTratParejaMayor20SemSinDatos.MaxLength = 0;
				colvarSifilisTratParejaMayor20SemSinDatos.AutoIncrement = false;
				colvarSifilisTratParejaMayor20SemSinDatos.IsNullable = true;
				colvarSifilisTratParejaMayor20SemSinDatos.IsPrimaryKey = false;
				colvarSifilisTratParejaMayor20SemSinDatos.IsForeignKey = false;
				colvarSifilisTratParejaMayor20SemSinDatos.IsReadOnly = false;
				colvarSifilisTratParejaMayor20SemSinDatos.DefaultSetting = @"";
				colvarSifilisTratParejaMayor20SemSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMayor20SemSinDatos);
				
				TableSchema.TableColumn colvarSifilisTratParejaMayor20SemNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisTratParejaMayor20SemNoCorresponde.ColumnName = "SifilisTratParejaMayor20SemNoCorresponde";
				colvarSifilisTratParejaMayor20SemNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisTratParejaMayor20SemNoCorresponde.MaxLength = 0;
				colvarSifilisTratParejaMayor20SemNoCorresponde.AutoIncrement = false;
				colvarSifilisTratParejaMayor20SemNoCorresponde.IsNullable = true;
				colvarSifilisTratParejaMayor20SemNoCorresponde.IsPrimaryKey = false;
				colvarSifilisTratParejaMayor20SemNoCorresponde.IsForeignKey = false;
				colvarSifilisTratParejaMayor20SemNoCorresponde.IsReadOnly = false;
				colvarSifilisTratParejaMayor20SemNoCorresponde.DefaultSetting = @"";
				colvarSifilisTratParejaMayor20SemNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratParejaMayor20SemNoCorresponde);
				
				TableSchema.TableColumn colvarOAAntecedenteEclampsiaSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteEclampsiaSi.ColumnName = "OAAntecedenteEclampsiaSi";
				colvarOAAntecedenteEclampsiaSi.DataType = DbType.Boolean;
				colvarOAAntecedenteEclampsiaSi.MaxLength = 0;
				colvarOAAntecedenteEclampsiaSi.AutoIncrement = false;
				colvarOAAntecedenteEclampsiaSi.IsNullable = true;
				colvarOAAntecedenteEclampsiaSi.IsPrimaryKey = false;
				colvarOAAntecedenteEclampsiaSi.IsForeignKey = false;
				colvarOAAntecedenteEclampsiaSi.IsReadOnly = false;
				colvarOAAntecedenteEclampsiaSi.DefaultSetting = @"";
				colvarOAAntecedenteEclampsiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteEclampsiaSi);
				
				TableSchema.TableColumn colvarOAAntecedenteEclampsiaNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteEclampsiaNo.ColumnName = "OAAntecedenteEclampsiaNo";
				colvarOAAntecedenteEclampsiaNo.DataType = DbType.Boolean;
				colvarOAAntecedenteEclampsiaNo.MaxLength = 0;
				colvarOAAntecedenteEclampsiaNo.AutoIncrement = false;
				colvarOAAntecedenteEclampsiaNo.IsNullable = true;
				colvarOAAntecedenteEclampsiaNo.IsPrimaryKey = false;
				colvarOAAntecedenteEclampsiaNo.IsForeignKey = false;
				colvarOAAntecedenteEclampsiaNo.IsReadOnly = false;
				colvarOAAntecedenteEclampsiaNo.DefaultSetting = @"";
				colvarOAAntecedenteEclampsiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteEclampsiaNo);
				
				TableSchema.TableColumn colvarOAActualEclampsiaSi = new TableSchema.TableColumn(schema);
				colvarOAActualEclampsiaSi.ColumnName = "OAActualEclampsiaSi";
				colvarOAActualEclampsiaSi.DataType = DbType.Boolean;
				colvarOAActualEclampsiaSi.MaxLength = 0;
				colvarOAActualEclampsiaSi.AutoIncrement = false;
				colvarOAActualEclampsiaSi.IsNullable = true;
				colvarOAActualEclampsiaSi.IsPrimaryKey = false;
				colvarOAActualEclampsiaSi.IsForeignKey = false;
				colvarOAActualEclampsiaSi.IsReadOnly = false;
				colvarOAActualEclampsiaSi.DefaultSetting = @"";
				colvarOAActualEclampsiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualEclampsiaSi);
				
				TableSchema.TableColumn colvarOAActualEclampsiaNo = new TableSchema.TableColumn(schema);
				colvarOAActualEclampsiaNo.ColumnName = "OAActualEclampsiaNo";
				colvarOAActualEclampsiaNo.DataType = DbType.Boolean;
				colvarOAActualEclampsiaNo.MaxLength = 0;
				colvarOAActualEclampsiaNo.AutoIncrement = false;
				colvarOAActualEclampsiaNo.IsNullable = true;
				colvarOAActualEclampsiaNo.IsPrimaryKey = false;
				colvarOAActualEclampsiaNo.IsForeignKey = false;
				colvarOAActualEclampsiaNo.IsReadOnly = false;
				colvarOAActualEclampsiaNo.DefaultSetting = @"";
				colvarOAActualEclampsiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualEclampsiaNo);
				
				TableSchema.TableColumn colvarOAAntecedentePreeclampsiaSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedentePreeclampsiaSi.ColumnName = "OAAntecedentePreeclampsiaSi";
				colvarOAAntecedentePreeclampsiaSi.DataType = DbType.Boolean;
				colvarOAAntecedentePreeclampsiaSi.MaxLength = 0;
				colvarOAAntecedentePreeclampsiaSi.AutoIncrement = false;
				colvarOAAntecedentePreeclampsiaSi.IsNullable = true;
				colvarOAAntecedentePreeclampsiaSi.IsPrimaryKey = false;
				colvarOAAntecedentePreeclampsiaSi.IsForeignKey = false;
				colvarOAAntecedentePreeclampsiaSi.IsReadOnly = false;
				colvarOAAntecedentePreeclampsiaSi.DefaultSetting = @"";
				colvarOAAntecedentePreeclampsiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedentePreeclampsiaSi);
				
				TableSchema.TableColumn colvarOAAntecedentePreeclampsiaNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedentePreeclampsiaNo.ColumnName = "OAAntecedentePreeclampsiaNo";
				colvarOAAntecedentePreeclampsiaNo.DataType = DbType.Boolean;
				colvarOAAntecedentePreeclampsiaNo.MaxLength = 0;
				colvarOAAntecedentePreeclampsiaNo.AutoIncrement = false;
				colvarOAAntecedentePreeclampsiaNo.IsNullable = true;
				colvarOAAntecedentePreeclampsiaNo.IsPrimaryKey = false;
				colvarOAAntecedentePreeclampsiaNo.IsForeignKey = false;
				colvarOAAntecedentePreeclampsiaNo.IsReadOnly = false;
				colvarOAAntecedentePreeclampsiaNo.DefaultSetting = @"";
				colvarOAAntecedentePreeclampsiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedentePreeclampsiaNo);
				
				TableSchema.TableColumn colvarOAActualPreeclampsiaSi = new TableSchema.TableColumn(schema);
				colvarOAActualPreeclampsiaSi.ColumnName = "OAActualPreeclampsiaSi";
				colvarOAActualPreeclampsiaSi.DataType = DbType.Boolean;
				colvarOAActualPreeclampsiaSi.MaxLength = 0;
				colvarOAActualPreeclampsiaSi.AutoIncrement = false;
				colvarOAActualPreeclampsiaSi.IsNullable = true;
				colvarOAActualPreeclampsiaSi.IsPrimaryKey = false;
				colvarOAActualPreeclampsiaSi.IsForeignKey = false;
				colvarOAActualPreeclampsiaSi.IsReadOnly = false;
				colvarOAActualPreeclampsiaSi.DefaultSetting = @"";
				colvarOAActualPreeclampsiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualPreeclampsiaSi);
				
				TableSchema.TableColumn colvarOAActualPreeclampsiaNo = new TableSchema.TableColumn(schema);
				colvarOAActualPreeclampsiaNo.ColumnName = "OAActualPreeclampsiaNo";
				colvarOAActualPreeclampsiaNo.DataType = DbType.Boolean;
				colvarOAActualPreeclampsiaNo.MaxLength = 0;
				colvarOAActualPreeclampsiaNo.AutoIncrement = false;
				colvarOAActualPreeclampsiaNo.IsNullable = true;
				colvarOAActualPreeclampsiaNo.IsPrimaryKey = false;
				colvarOAActualPreeclampsiaNo.IsForeignKey = false;
				colvarOAActualPreeclampsiaNo.IsReadOnly = false;
				colvarOAActualPreeclampsiaNo.DefaultSetting = @"";
				colvarOAActualPreeclampsiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualPreeclampsiaNo);
				
				TableSchema.TableColumn colvarOAAntecedenteCirugiaGinUrinarSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteCirugiaGinUrinarSi.ColumnName = "OAAntecedenteCirugiaGinUrinarSi";
				colvarOAAntecedenteCirugiaGinUrinarSi.DataType = DbType.Boolean;
				colvarOAAntecedenteCirugiaGinUrinarSi.MaxLength = 0;
				colvarOAAntecedenteCirugiaGinUrinarSi.AutoIncrement = false;
				colvarOAAntecedenteCirugiaGinUrinarSi.IsNullable = true;
				colvarOAAntecedenteCirugiaGinUrinarSi.IsPrimaryKey = false;
				colvarOAAntecedenteCirugiaGinUrinarSi.IsForeignKey = false;
				colvarOAAntecedenteCirugiaGinUrinarSi.IsReadOnly = false;
				colvarOAAntecedenteCirugiaGinUrinarSi.DefaultSetting = @"";
				colvarOAAntecedenteCirugiaGinUrinarSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteCirugiaGinUrinarSi);
				
				TableSchema.TableColumn colvarOAAntecedenteCirugiaGinUrinarNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteCirugiaGinUrinarNo.ColumnName = "OAAntecedenteCirugiaGinUrinarNo";
				colvarOAAntecedenteCirugiaGinUrinarNo.DataType = DbType.Boolean;
				colvarOAAntecedenteCirugiaGinUrinarNo.MaxLength = 0;
				colvarOAAntecedenteCirugiaGinUrinarNo.AutoIncrement = false;
				colvarOAAntecedenteCirugiaGinUrinarNo.IsNullable = true;
				colvarOAAntecedenteCirugiaGinUrinarNo.IsPrimaryKey = false;
				colvarOAAntecedenteCirugiaGinUrinarNo.IsForeignKey = false;
				colvarOAAntecedenteCirugiaGinUrinarNo.IsReadOnly = false;
				colvarOAAntecedenteCirugiaGinUrinarNo.DefaultSetting = @"";
				colvarOAAntecedenteCirugiaGinUrinarNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteCirugiaGinUrinarNo);
				
				TableSchema.TableColumn colvarOAActualCirugiaGinUrinarSi = new TableSchema.TableColumn(schema);
				colvarOAActualCirugiaGinUrinarSi.ColumnName = "OAActualCirugiaGinUrinarSi";
				colvarOAActualCirugiaGinUrinarSi.DataType = DbType.Boolean;
				colvarOAActualCirugiaGinUrinarSi.MaxLength = 0;
				colvarOAActualCirugiaGinUrinarSi.AutoIncrement = false;
				colvarOAActualCirugiaGinUrinarSi.IsNullable = true;
				colvarOAActualCirugiaGinUrinarSi.IsPrimaryKey = false;
				colvarOAActualCirugiaGinUrinarSi.IsForeignKey = false;
				colvarOAActualCirugiaGinUrinarSi.IsReadOnly = false;
				colvarOAActualCirugiaGinUrinarSi.DefaultSetting = @"";
				colvarOAActualCirugiaGinUrinarSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualCirugiaGinUrinarSi);
				
				TableSchema.TableColumn colvarOAActualCirugiaGinUrinarNo = new TableSchema.TableColumn(schema);
				colvarOAActualCirugiaGinUrinarNo.ColumnName = "OAActualCirugiaGinUrinarNo";
				colvarOAActualCirugiaGinUrinarNo.DataType = DbType.Boolean;
				colvarOAActualCirugiaGinUrinarNo.MaxLength = 0;
				colvarOAActualCirugiaGinUrinarNo.AutoIncrement = false;
				colvarOAActualCirugiaGinUrinarNo.IsNullable = true;
				colvarOAActualCirugiaGinUrinarNo.IsPrimaryKey = false;
				colvarOAActualCirugiaGinUrinarNo.IsForeignKey = false;
				colvarOAActualCirugiaGinUrinarNo.IsReadOnly = false;
				colvarOAActualCirugiaGinUrinarNo.DefaultSetting = @"";
				colvarOAActualCirugiaGinUrinarNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualCirugiaGinUrinarNo);
				
				TableSchema.TableColumn colvarOAAntecedenteAPPrematuroSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteAPPrematuroSi.ColumnName = "OAAntecedenteAPPrematuroSi";
				colvarOAAntecedenteAPPrematuroSi.DataType = DbType.Boolean;
				colvarOAAntecedenteAPPrematuroSi.MaxLength = 0;
				colvarOAAntecedenteAPPrematuroSi.AutoIncrement = false;
				colvarOAAntecedenteAPPrematuroSi.IsNullable = true;
				colvarOAAntecedenteAPPrematuroSi.IsPrimaryKey = false;
				colvarOAAntecedenteAPPrematuroSi.IsForeignKey = false;
				colvarOAAntecedenteAPPrematuroSi.IsReadOnly = false;
				colvarOAAntecedenteAPPrematuroSi.DefaultSetting = @"";
				colvarOAAntecedenteAPPrematuroSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteAPPrematuroSi);
				
				TableSchema.TableColumn colvarOAAntecedenteAPPrematuroNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteAPPrematuroNo.ColumnName = "OAAntecedenteAPPrematuroNo";
				colvarOAAntecedenteAPPrematuroNo.DataType = DbType.Boolean;
				colvarOAAntecedenteAPPrematuroNo.MaxLength = 0;
				colvarOAAntecedenteAPPrematuroNo.AutoIncrement = false;
				colvarOAAntecedenteAPPrematuroNo.IsNullable = true;
				colvarOAAntecedenteAPPrematuroNo.IsPrimaryKey = false;
				colvarOAAntecedenteAPPrematuroNo.IsForeignKey = false;
				colvarOAAntecedenteAPPrematuroNo.IsReadOnly = false;
				colvarOAAntecedenteAPPrematuroNo.DefaultSetting = @"";
				colvarOAAntecedenteAPPrematuroNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteAPPrematuroNo);
				
				TableSchema.TableColumn colvarOAActualAPPrematuroSi = new TableSchema.TableColumn(schema);
				colvarOAActualAPPrematuroSi.ColumnName = "OAActualAPPrematuroSi";
				colvarOAActualAPPrematuroSi.DataType = DbType.Boolean;
				colvarOAActualAPPrematuroSi.MaxLength = 0;
				colvarOAActualAPPrematuroSi.AutoIncrement = false;
				colvarOAActualAPPrematuroSi.IsNullable = true;
				colvarOAActualAPPrematuroSi.IsPrimaryKey = false;
				colvarOAActualAPPrematuroSi.IsForeignKey = false;
				colvarOAActualAPPrematuroSi.IsReadOnly = false;
				colvarOAActualAPPrematuroSi.DefaultSetting = @"";
				colvarOAActualAPPrematuroSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualAPPrematuroSi);
				
				TableSchema.TableColumn colvarOAActualAPPrematuroNo = new TableSchema.TableColumn(schema);
				colvarOAActualAPPrematuroNo.ColumnName = "OAActualAPPrematuroNo";
				colvarOAActualAPPrematuroNo.DataType = DbType.Boolean;
				colvarOAActualAPPrematuroNo.MaxLength = 0;
				colvarOAActualAPPrematuroNo.AutoIncrement = false;
				colvarOAActualAPPrematuroNo.IsNullable = true;
				colvarOAActualAPPrematuroNo.IsPrimaryKey = false;
				colvarOAActualAPPrematuroNo.IsForeignKey = false;
				colvarOAActualAPPrematuroNo.IsReadOnly = false;
				colvarOAActualAPPrematuroNo.DefaultSetting = @"";
				colvarOAActualAPPrematuroNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualAPPrematuroNo);
				
				TableSchema.TableColumn colvarOAAntecedenteRCIUSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteRCIUSi.ColumnName = "OAAntecedenteRCIUSi";
				colvarOAAntecedenteRCIUSi.DataType = DbType.Boolean;
				colvarOAAntecedenteRCIUSi.MaxLength = 0;
				colvarOAAntecedenteRCIUSi.AutoIncrement = false;
				colvarOAAntecedenteRCIUSi.IsNullable = true;
				colvarOAAntecedenteRCIUSi.IsPrimaryKey = false;
				colvarOAAntecedenteRCIUSi.IsForeignKey = false;
				colvarOAAntecedenteRCIUSi.IsReadOnly = false;
				colvarOAAntecedenteRCIUSi.DefaultSetting = @"";
				colvarOAAntecedenteRCIUSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteRCIUSi);
				
				TableSchema.TableColumn colvarOAAntecedenteRCIUNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteRCIUNo.ColumnName = "OAAntecedenteRCIUNo";
				colvarOAAntecedenteRCIUNo.DataType = DbType.Boolean;
				colvarOAAntecedenteRCIUNo.MaxLength = 0;
				colvarOAAntecedenteRCIUNo.AutoIncrement = false;
				colvarOAAntecedenteRCIUNo.IsNullable = true;
				colvarOAAntecedenteRCIUNo.IsPrimaryKey = false;
				colvarOAAntecedenteRCIUNo.IsForeignKey = false;
				colvarOAAntecedenteRCIUNo.IsReadOnly = false;
				colvarOAAntecedenteRCIUNo.DefaultSetting = @"";
				colvarOAAntecedenteRCIUNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteRCIUNo);
				
				TableSchema.TableColumn colvarOAActualRCIUSi = new TableSchema.TableColumn(schema);
				colvarOAActualRCIUSi.ColumnName = "OAActualRCIUSi";
				colvarOAActualRCIUSi.DataType = DbType.Boolean;
				colvarOAActualRCIUSi.MaxLength = 0;
				colvarOAActualRCIUSi.AutoIncrement = false;
				colvarOAActualRCIUSi.IsNullable = true;
				colvarOAActualRCIUSi.IsPrimaryKey = false;
				colvarOAActualRCIUSi.IsForeignKey = false;
				colvarOAActualRCIUSi.IsReadOnly = false;
				colvarOAActualRCIUSi.DefaultSetting = @"";
				colvarOAActualRCIUSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualRCIUSi);
				
				TableSchema.TableColumn colvarOAActualRCIUNo = new TableSchema.TableColumn(schema);
				colvarOAActualRCIUNo.ColumnName = "OAActualRCIUNo";
				colvarOAActualRCIUNo.DataType = DbType.Boolean;
				colvarOAActualRCIUNo.MaxLength = 0;
				colvarOAActualRCIUNo.AutoIncrement = false;
				colvarOAActualRCIUNo.IsNullable = true;
				colvarOAActualRCIUNo.IsPrimaryKey = false;
				colvarOAActualRCIUNo.IsForeignKey = false;
				colvarOAActualRCIUNo.IsReadOnly = false;
				colvarOAActualRCIUNo.DefaultSetting = @"";
				colvarOAActualRCIUNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualRCIUNo);
				
				TableSchema.TableColumn colvarOAAntecedenteHemorragiaObstetricaSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteHemorragiaObstetricaSi.ColumnName = "OAAntecedenteHemorragiaObstetricaSi";
				colvarOAAntecedenteHemorragiaObstetricaSi.DataType = DbType.Boolean;
				colvarOAAntecedenteHemorragiaObstetricaSi.MaxLength = 0;
				colvarOAAntecedenteHemorragiaObstetricaSi.AutoIncrement = false;
				colvarOAAntecedenteHemorragiaObstetricaSi.IsNullable = true;
				colvarOAAntecedenteHemorragiaObstetricaSi.IsPrimaryKey = false;
				colvarOAAntecedenteHemorragiaObstetricaSi.IsForeignKey = false;
				colvarOAAntecedenteHemorragiaObstetricaSi.IsReadOnly = false;
				colvarOAAntecedenteHemorragiaObstetricaSi.DefaultSetting = @"";
				colvarOAAntecedenteHemorragiaObstetricaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteHemorragiaObstetricaSi);
				
				TableSchema.TableColumn colvarOAAntecedenteHemorragiaObstetricaNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteHemorragiaObstetricaNo.ColumnName = "OAAntecedenteHemorragiaObstetricaNo";
				colvarOAAntecedenteHemorragiaObstetricaNo.DataType = DbType.Boolean;
				colvarOAAntecedenteHemorragiaObstetricaNo.MaxLength = 0;
				colvarOAAntecedenteHemorragiaObstetricaNo.AutoIncrement = false;
				colvarOAAntecedenteHemorragiaObstetricaNo.IsNullable = true;
				colvarOAAntecedenteHemorragiaObstetricaNo.IsPrimaryKey = false;
				colvarOAAntecedenteHemorragiaObstetricaNo.IsForeignKey = false;
				colvarOAAntecedenteHemorragiaObstetricaNo.IsReadOnly = false;
				colvarOAAntecedenteHemorragiaObstetricaNo.DefaultSetting = @"";
				colvarOAAntecedenteHemorragiaObstetricaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteHemorragiaObstetricaNo);
				
				TableSchema.TableColumn colvarOAActualHemorragiaObstetricaSi = new TableSchema.TableColumn(schema);
				colvarOAActualHemorragiaObstetricaSi.ColumnName = "OAActualHemorragiaObstetricaSi";
				colvarOAActualHemorragiaObstetricaSi.DataType = DbType.Boolean;
				colvarOAActualHemorragiaObstetricaSi.MaxLength = 0;
				colvarOAActualHemorragiaObstetricaSi.AutoIncrement = false;
				colvarOAActualHemorragiaObstetricaSi.IsNullable = true;
				colvarOAActualHemorragiaObstetricaSi.IsPrimaryKey = false;
				colvarOAActualHemorragiaObstetricaSi.IsForeignKey = false;
				colvarOAActualHemorragiaObstetricaSi.IsReadOnly = false;
				colvarOAActualHemorragiaObstetricaSi.DefaultSetting = @"";
				colvarOAActualHemorragiaObstetricaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualHemorragiaObstetricaSi);
				
				TableSchema.TableColumn colvarOAActualHemorragiaObstetricaNo = new TableSchema.TableColumn(schema);
				colvarOAActualHemorragiaObstetricaNo.ColumnName = "OAActualHemorragiaObstetricaNo";
				colvarOAActualHemorragiaObstetricaNo.DataType = DbType.Boolean;
				colvarOAActualHemorragiaObstetricaNo.MaxLength = 0;
				colvarOAActualHemorragiaObstetricaNo.AutoIncrement = false;
				colvarOAActualHemorragiaObstetricaNo.IsNullable = true;
				colvarOAActualHemorragiaObstetricaNo.IsPrimaryKey = false;
				colvarOAActualHemorragiaObstetricaNo.IsForeignKey = false;
				colvarOAActualHemorragiaObstetricaNo.IsReadOnly = false;
				colvarOAActualHemorragiaObstetricaNo.DefaultSetting = @"";
				colvarOAActualHemorragiaObstetricaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualHemorragiaObstetricaNo);
				
				TableSchema.TableColumn colvarOAAntecedenteMacrosomiaFetalSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteMacrosomiaFetalSi.ColumnName = "OAAntecedenteMacrosomiaFetalSi";
				colvarOAAntecedenteMacrosomiaFetalSi.DataType = DbType.Boolean;
				colvarOAAntecedenteMacrosomiaFetalSi.MaxLength = 0;
				colvarOAAntecedenteMacrosomiaFetalSi.AutoIncrement = false;
				colvarOAAntecedenteMacrosomiaFetalSi.IsNullable = true;
				colvarOAAntecedenteMacrosomiaFetalSi.IsPrimaryKey = false;
				colvarOAAntecedenteMacrosomiaFetalSi.IsForeignKey = false;
				colvarOAAntecedenteMacrosomiaFetalSi.IsReadOnly = false;
				colvarOAAntecedenteMacrosomiaFetalSi.DefaultSetting = @"";
				colvarOAAntecedenteMacrosomiaFetalSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteMacrosomiaFetalSi);
				
				TableSchema.TableColumn colvarOAAntecedenteMacrosomiaFetalNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteMacrosomiaFetalNo.ColumnName = "OAAntecedenteMacrosomiaFetalNo";
				colvarOAAntecedenteMacrosomiaFetalNo.DataType = DbType.Boolean;
				colvarOAAntecedenteMacrosomiaFetalNo.MaxLength = 0;
				colvarOAAntecedenteMacrosomiaFetalNo.AutoIncrement = false;
				colvarOAAntecedenteMacrosomiaFetalNo.IsNullable = true;
				colvarOAAntecedenteMacrosomiaFetalNo.IsPrimaryKey = false;
				colvarOAAntecedenteMacrosomiaFetalNo.IsForeignKey = false;
				colvarOAAntecedenteMacrosomiaFetalNo.IsReadOnly = false;
				colvarOAAntecedenteMacrosomiaFetalNo.DefaultSetting = @"";
				colvarOAAntecedenteMacrosomiaFetalNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteMacrosomiaFetalNo);
				
				TableSchema.TableColumn colvarOAActualMacrosomiaFetalSi = new TableSchema.TableColumn(schema);
				colvarOAActualMacrosomiaFetalSi.ColumnName = "OAActualMacrosomiaFetalSi";
				colvarOAActualMacrosomiaFetalSi.DataType = DbType.Boolean;
				colvarOAActualMacrosomiaFetalSi.MaxLength = 0;
				colvarOAActualMacrosomiaFetalSi.AutoIncrement = false;
				colvarOAActualMacrosomiaFetalSi.IsNullable = true;
				colvarOAActualMacrosomiaFetalSi.IsPrimaryKey = false;
				colvarOAActualMacrosomiaFetalSi.IsForeignKey = false;
				colvarOAActualMacrosomiaFetalSi.IsReadOnly = false;
				colvarOAActualMacrosomiaFetalSi.DefaultSetting = @"";
				colvarOAActualMacrosomiaFetalSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualMacrosomiaFetalSi);
				
				TableSchema.TableColumn colvarOAActualMacrosomiaFetalNo = new TableSchema.TableColumn(schema);
				colvarOAActualMacrosomiaFetalNo.ColumnName = "OAActualMacrosomiaFetalNo";
				colvarOAActualMacrosomiaFetalNo.DataType = DbType.Boolean;
				colvarOAActualMacrosomiaFetalNo.MaxLength = 0;
				colvarOAActualMacrosomiaFetalNo.AutoIncrement = false;
				colvarOAActualMacrosomiaFetalNo.IsNullable = true;
				colvarOAActualMacrosomiaFetalNo.IsPrimaryKey = false;
				colvarOAActualMacrosomiaFetalNo.IsForeignKey = false;
				colvarOAActualMacrosomiaFetalNo.IsReadOnly = false;
				colvarOAActualMacrosomiaFetalNo.DefaultSetting = @"";
				colvarOAActualMacrosomiaFetalNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualMacrosomiaFetalNo);
				
				TableSchema.TableColumn colvarOAAntecedentePolihidramniosSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedentePolihidramniosSi.ColumnName = "OAAntecedentePolihidramniosSi";
				colvarOAAntecedentePolihidramniosSi.DataType = DbType.Boolean;
				colvarOAAntecedentePolihidramniosSi.MaxLength = 0;
				colvarOAAntecedentePolihidramniosSi.AutoIncrement = false;
				colvarOAAntecedentePolihidramniosSi.IsNullable = true;
				colvarOAAntecedentePolihidramniosSi.IsPrimaryKey = false;
				colvarOAAntecedentePolihidramniosSi.IsForeignKey = false;
				colvarOAAntecedentePolihidramniosSi.IsReadOnly = false;
				colvarOAAntecedentePolihidramniosSi.DefaultSetting = @"";
				colvarOAAntecedentePolihidramniosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedentePolihidramniosSi);
				
				TableSchema.TableColumn colvarOAAntecedentePolihidramniosNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedentePolihidramniosNo.ColumnName = "OAAntecedentePolihidramniosNo";
				colvarOAAntecedentePolihidramniosNo.DataType = DbType.Boolean;
				colvarOAAntecedentePolihidramniosNo.MaxLength = 0;
				colvarOAAntecedentePolihidramniosNo.AutoIncrement = false;
				colvarOAAntecedentePolihidramniosNo.IsNullable = true;
				colvarOAAntecedentePolihidramniosNo.IsPrimaryKey = false;
				colvarOAAntecedentePolihidramniosNo.IsForeignKey = false;
				colvarOAAntecedentePolihidramniosNo.IsReadOnly = false;
				colvarOAAntecedentePolihidramniosNo.DefaultSetting = @"";
				colvarOAAntecedentePolihidramniosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedentePolihidramniosNo);
				
				TableSchema.TableColumn colvarOAActualPolihidramniosSi = new TableSchema.TableColumn(schema);
				colvarOAActualPolihidramniosSi.ColumnName = "OAActualPolihidramniosSi";
				colvarOAActualPolihidramniosSi.DataType = DbType.Boolean;
				colvarOAActualPolihidramniosSi.MaxLength = 0;
				colvarOAActualPolihidramniosSi.AutoIncrement = false;
				colvarOAActualPolihidramniosSi.IsNullable = true;
				colvarOAActualPolihidramniosSi.IsPrimaryKey = false;
				colvarOAActualPolihidramniosSi.IsForeignKey = false;
				colvarOAActualPolihidramniosSi.IsReadOnly = false;
				colvarOAActualPolihidramniosSi.DefaultSetting = @"";
				colvarOAActualPolihidramniosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualPolihidramniosSi);
				
				TableSchema.TableColumn colvarOAActualPolihidramniosNo = new TableSchema.TableColumn(schema);
				colvarOAActualPolihidramniosNo.ColumnName = "OAActualPolihidramniosNo";
				colvarOAActualPolihidramniosNo.DataType = DbType.Boolean;
				colvarOAActualPolihidramniosNo.MaxLength = 0;
				colvarOAActualPolihidramniosNo.AutoIncrement = false;
				colvarOAActualPolihidramniosNo.IsNullable = true;
				colvarOAActualPolihidramniosNo.IsPrimaryKey = false;
				colvarOAActualPolihidramniosNo.IsForeignKey = false;
				colvarOAActualPolihidramniosNo.IsReadOnly = false;
				colvarOAActualPolihidramniosNo.DefaultSetting = @"";
				colvarOAActualPolihidramniosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualPolihidramniosNo);
				
				TableSchema.TableColumn colvarOAAntecedenteOligoanmiosSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteOligoanmiosSi.ColumnName = "OAAntecedenteOligoanmiosSi";
				colvarOAAntecedenteOligoanmiosSi.DataType = DbType.Boolean;
				colvarOAAntecedenteOligoanmiosSi.MaxLength = 0;
				colvarOAAntecedenteOligoanmiosSi.AutoIncrement = false;
				colvarOAAntecedenteOligoanmiosSi.IsNullable = true;
				colvarOAAntecedenteOligoanmiosSi.IsPrimaryKey = false;
				colvarOAAntecedenteOligoanmiosSi.IsForeignKey = false;
				colvarOAAntecedenteOligoanmiosSi.IsReadOnly = false;
				colvarOAAntecedenteOligoanmiosSi.DefaultSetting = @"";
				colvarOAAntecedenteOligoanmiosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteOligoanmiosSi);
				
				TableSchema.TableColumn colvarOAAntecedenteOligoanmiosNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteOligoanmiosNo.ColumnName = "OAAntecedenteOligoanmiosNo";
				colvarOAAntecedenteOligoanmiosNo.DataType = DbType.Boolean;
				colvarOAAntecedenteOligoanmiosNo.MaxLength = 0;
				colvarOAAntecedenteOligoanmiosNo.AutoIncrement = false;
				colvarOAAntecedenteOligoanmiosNo.IsNullable = true;
				colvarOAAntecedenteOligoanmiosNo.IsPrimaryKey = false;
				colvarOAAntecedenteOligoanmiosNo.IsForeignKey = false;
				colvarOAAntecedenteOligoanmiosNo.IsReadOnly = false;
				colvarOAAntecedenteOligoanmiosNo.DefaultSetting = @"";
				colvarOAAntecedenteOligoanmiosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteOligoanmiosNo);
				
				TableSchema.TableColumn colvarOAActualOligoanmiosSi = new TableSchema.TableColumn(schema);
				colvarOAActualOligoanmiosSi.ColumnName = "OAActualOligoanmiosSi";
				colvarOAActualOligoanmiosSi.DataType = DbType.Boolean;
				colvarOAActualOligoanmiosSi.MaxLength = 0;
				colvarOAActualOligoanmiosSi.AutoIncrement = false;
				colvarOAActualOligoanmiosSi.IsNullable = true;
				colvarOAActualOligoanmiosSi.IsPrimaryKey = false;
				colvarOAActualOligoanmiosSi.IsForeignKey = false;
				colvarOAActualOligoanmiosSi.IsReadOnly = false;
				colvarOAActualOligoanmiosSi.DefaultSetting = @"";
				colvarOAActualOligoanmiosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualOligoanmiosSi);
				
				TableSchema.TableColumn colvarOAActualOligoanmiosNo = new TableSchema.TableColumn(schema);
				colvarOAActualOligoanmiosNo.ColumnName = "OAActualOligoanmiosNo";
				colvarOAActualOligoanmiosNo.DataType = DbType.Boolean;
				colvarOAActualOligoanmiosNo.MaxLength = 0;
				colvarOAActualOligoanmiosNo.AutoIncrement = false;
				colvarOAActualOligoanmiosNo.IsNullable = true;
				colvarOAActualOligoanmiosNo.IsPrimaryKey = false;
				colvarOAActualOligoanmiosNo.IsForeignKey = false;
				colvarOAActualOligoanmiosNo.IsReadOnly = false;
				colvarOAActualOligoanmiosNo.DefaultSetting = @"";
				colvarOAActualOligoanmiosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualOligoanmiosNo);
				
				TableSchema.TableColumn colvarOAAntecedenteRotPremMembranasSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteRotPremMembranasSi.ColumnName = "OAAntecedenteRotPremMembranasSi";
				colvarOAAntecedenteRotPremMembranasSi.DataType = DbType.Boolean;
				colvarOAAntecedenteRotPremMembranasSi.MaxLength = 0;
				colvarOAAntecedenteRotPremMembranasSi.AutoIncrement = false;
				colvarOAAntecedenteRotPremMembranasSi.IsNullable = true;
				colvarOAAntecedenteRotPremMembranasSi.IsPrimaryKey = false;
				colvarOAAntecedenteRotPremMembranasSi.IsForeignKey = false;
				colvarOAAntecedenteRotPremMembranasSi.IsReadOnly = false;
				colvarOAAntecedenteRotPremMembranasSi.DefaultSetting = @"";
				colvarOAAntecedenteRotPremMembranasSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteRotPremMembranasSi);
				
				TableSchema.TableColumn colvarOAAntecedenteRotPremMembranasNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteRotPremMembranasNo.ColumnName = "OAAntecedenteRotPremMembranasNo";
				colvarOAAntecedenteRotPremMembranasNo.DataType = DbType.Boolean;
				colvarOAAntecedenteRotPremMembranasNo.MaxLength = 0;
				colvarOAAntecedenteRotPremMembranasNo.AutoIncrement = false;
				colvarOAAntecedenteRotPremMembranasNo.IsNullable = true;
				colvarOAAntecedenteRotPremMembranasNo.IsPrimaryKey = false;
				colvarOAAntecedenteRotPremMembranasNo.IsForeignKey = false;
				colvarOAAntecedenteRotPremMembranasNo.IsReadOnly = false;
				colvarOAAntecedenteRotPremMembranasNo.DefaultSetting = @"";
				colvarOAAntecedenteRotPremMembranasNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteRotPremMembranasNo);
				
				TableSchema.TableColumn colvarOAActualRotPremMembranasSi = new TableSchema.TableColumn(schema);
				colvarOAActualRotPremMembranasSi.ColumnName = "OAActualRotPremMembranasSi";
				colvarOAActualRotPremMembranasSi.DataType = DbType.Boolean;
				colvarOAActualRotPremMembranasSi.MaxLength = 0;
				colvarOAActualRotPremMembranasSi.AutoIncrement = false;
				colvarOAActualRotPremMembranasSi.IsNullable = true;
				colvarOAActualRotPremMembranasSi.IsPrimaryKey = false;
				colvarOAActualRotPremMembranasSi.IsForeignKey = false;
				colvarOAActualRotPremMembranasSi.IsReadOnly = false;
				colvarOAActualRotPremMembranasSi.DefaultSetting = @"";
				colvarOAActualRotPremMembranasSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualRotPremMembranasSi);
				
				TableSchema.TableColumn colvarOAActualRotPremMembranasNo = new TableSchema.TableColumn(schema);
				colvarOAActualRotPremMembranasNo.ColumnName = "OAActualRotPremMembranasNo";
				colvarOAActualRotPremMembranasNo.DataType = DbType.Boolean;
				colvarOAActualRotPremMembranasNo.MaxLength = 0;
				colvarOAActualRotPremMembranasNo.AutoIncrement = false;
				colvarOAActualRotPremMembranasNo.IsNullable = true;
				colvarOAActualRotPremMembranasNo.IsPrimaryKey = false;
				colvarOAActualRotPremMembranasNo.IsForeignKey = false;
				colvarOAActualRotPremMembranasNo.IsReadOnly = false;
				colvarOAActualRotPremMembranasNo.DefaultSetting = @"";
				colvarOAActualRotPremMembranasNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualRotPremMembranasNo);
				
				TableSchema.TableColumn colvarOAAntecedenteIsoinmunizacionesSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteIsoinmunizacionesSi.ColumnName = "OAAntecedenteIsoinmunizacionesSi";
				colvarOAAntecedenteIsoinmunizacionesSi.DataType = DbType.Boolean;
				colvarOAAntecedenteIsoinmunizacionesSi.MaxLength = 0;
				colvarOAAntecedenteIsoinmunizacionesSi.AutoIncrement = false;
				colvarOAAntecedenteIsoinmunizacionesSi.IsNullable = true;
				colvarOAAntecedenteIsoinmunizacionesSi.IsPrimaryKey = false;
				colvarOAAntecedenteIsoinmunizacionesSi.IsForeignKey = false;
				colvarOAAntecedenteIsoinmunizacionesSi.IsReadOnly = false;
				colvarOAAntecedenteIsoinmunizacionesSi.DefaultSetting = @"";
				colvarOAAntecedenteIsoinmunizacionesSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteIsoinmunizacionesSi);
				
				TableSchema.TableColumn colvarOAAntecedenteIsoinmunizacionesNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteIsoinmunizacionesNo.ColumnName = "OAAntecedenteIsoinmunizacionesNo";
				colvarOAAntecedenteIsoinmunizacionesNo.DataType = DbType.Boolean;
				colvarOAAntecedenteIsoinmunizacionesNo.MaxLength = 0;
				colvarOAAntecedenteIsoinmunizacionesNo.AutoIncrement = false;
				colvarOAAntecedenteIsoinmunizacionesNo.IsNullable = true;
				colvarOAAntecedenteIsoinmunizacionesNo.IsPrimaryKey = false;
				colvarOAAntecedenteIsoinmunizacionesNo.IsForeignKey = false;
				colvarOAAntecedenteIsoinmunizacionesNo.IsReadOnly = false;
				colvarOAAntecedenteIsoinmunizacionesNo.DefaultSetting = @"";
				colvarOAAntecedenteIsoinmunizacionesNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteIsoinmunizacionesNo);
				
				TableSchema.TableColumn colvarOAActualIsoinmunizacionesSi = new TableSchema.TableColumn(schema);
				colvarOAActualIsoinmunizacionesSi.ColumnName = "OAActualIsoinmunizacionesSi";
				colvarOAActualIsoinmunizacionesSi.DataType = DbType.Boolean;
				colvarOAActualIsoinmunizacionesSi.MaxLength = 0;
				colvarOAActualIsoinmunizacionesSi.AutoIncrement = false;
				colvarOAActualIsoinmunizacionesSi.IsNullable = true;
				colvarOAActualIsoinmunizacionesSi.IsPrimaryKey = false;
				colvarOAActualIsoinmunizacionesSi.IsForeignKey = false;
				colvarOAActualIsoinmunizacionesSi.IsReadOnly = false;
				colvarOAActualIsoinmunizacionesSi.DefaultSetting = @"";
				colvarOAActualIsoinmunizacionesSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualIsoinmunizacionesSi);
				
				TableSchema.TableColumn colvarOAActualIsoinmunizacionesNo = new TableSchema.TableColumn(schema);
				colvarOAActualIsoinmunizacionesNo.ColumnName = "OAActualIsoinmunizacionesNo";
				colvarOAActualIsoinmunizacionesNo.DataType = DbType.Boolean;
				colvarOAActualIsoinmunizacionesNo.MaxLength = 0;
				colvarOAActualIsoinmunizacionesNo.AutoIncrement = false;
				colvarOAActualIsoinmunizacionesNo.IsNullable = true;
				colvarOAActualIsoinmunizacionesNo.IsPrimaryKey = false;
				colvarOAActualIsoinmunizacionesNo.IsForeignKey = false;
				colvarOAActualIsoinmunizacionesNo.IsReadOnly = false;
				colvarOAActualIsoinmunizacionesNo.DefaultSetting = @"";
				colvarOAActualIsoinmunizacionesNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualIsoinmunizacionesNo);
				
				TableSchema.TableColumn colvarOAAntecedenteColestasisSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteColestasisSi.ColumnName = "OAAntecedenteColestasisSi";
				colvarOAAntecedenteColestasisSi.DataType = DbType.Boolean;
				colvarOAAntecedenteColestasisSi.MaxLength = 0;
				colvarOAAntecedenteColestasisSi.AutoIncrement = false;
				colvarOAAntecedenteColestasisSi.IsNullable = true;
				colvarOAAntecedenteColestasisSi.IsPrimaryKey = false;
				colvarOAAntecedenteColestasisSi.IsForeignKey = false;
				colvarOAAntecedenteColestasisSi.IsReadOnly = false;
				colvarOAAntecedenteColestasisSi.DefaultSetting = @"";
				colvarOAAntecedenteColestasisSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteColestasisSi);
				
				TableSchema.TableColumn colvarOAAntecedenteColestasisNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteColestasisNo.ColumnName = "OAAntecedenteColestasisNo";
				colvarOAAntecedenteColestasisNo.DataType = DbType.Boolean;
				colvarOAAntecedenteColestasisNo.MaxLength = 0;
				colvarOAAntecedenteColestasisNo.AutoIncrement = false;
				colvarOAAntecedenteColestasisNo.IsNullable = true;
				colvarOAAntecedenteColestasisNo.IsPrimaryKey = false;
				colvarOAAntecedenteColestasisNo.IsForeignKey = false;
				colvarOAAntecedenteColestasisNo.IsReadOnly = false;
				colvarOAAntecedenteColestasisNo.DefaultSetting = @"";
				colvarOAAntecedenteColestasisNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteColestasisNo);
				
				TableSchema.TableColumn colvarOAActualColestasisSi = new TableSchema.TableColumn(schema);
				colvarOAActualColestasisSi.ColumnName = "OAActualColestasisSi";
				colvarOAActualColestasisSi.DataType = DbType.Boolean;
				colvarOAActualColestasisSi.MaxLength = 0;
				colvarOAActualColestasisSi.AutoIncrement = false;
				colvarOAActualColestasisSi.IsNullable = true;
				colvarOAActualColestasisSi.IsPrimaryKey = false;
				colvarOAActualColestasisSi.IsForeignKey = false;
				colvarOAActualColestasisSi.IsReadOnly = false;
				colvarOAActualColestasisSi.DefaultSetting = @"";
				colvarOAActualColestasisSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualColestasisSi);
				
				TableSchema.TableColumn colvarOAActualColestasisNo = new TableSchema.TableColumn(schema);
				colvarOAActualColestasisNo.ColumnName = "OAActualColestasisNo";
				colvarOAActualColestasisNo.DataType = DbType.Boolean;
				colvarOAActualColestasisNo.MaxLength = 0;
				colvarOAActualColestasisNo.AutoIncrement = false;
				colvarOAActualColestasisNo.IsNullable = true;
				colvarOAActualColestasisNo.IsPrimaryKey = false;
				colvarOAActualColestasisNo.IsForeignKey = false;
				colvarOAActualColestasisNo.IsReadOnly = false;
				colvarOAActualColestasisNo.DefaultSetting = @"";
				colvarOAActualColestasisNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAActualColestasisNo);
				
				TableSchema.TableColumn colvarOAAntecedenteMortPerinatalRecurrenteSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteMortPerinatalRecurrenteSi.ColumnName = "OAAntecedenteMortPerinatalRecurrenteSi";
				colvarOAAntecedenteMortPerinatalRecurrenteSi.DataType = DbType.Boolean;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.MaxLength = 0;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.AutoIncrement = false;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.IsNullable = true;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.IsPrimaryKey = false;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.IsForeignKey = false;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.IsReadOnly = false;
				colvarOAAntecedenteMortPerinatalRecurrenteSi.DefaultSetting = @"";
				colvarOAAntecedenteMortPerinatalRecurrenteSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteMortPerinatalRecurrenteSi);
				
				TableSchema.TableColumn colvarOAAntecedenteMortPerinatalRecurrenteNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteMortPerinatalRecurrenteNo.ColumnName = "OAAntecedenteMortPerinatalRecurrenteNo";
				colvarOAAntecedenteMortPerinatalRecurrenteNo.DataType = DbType.Boolean;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.MaxLength = 0;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.AutoIncrement = false;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.IsNullable = true;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.IsPrimaryKey = false;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.IsForeignKey = false;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.IsReadOnly = false;
				colvarOAAntecedenteMortPerinatalRecurrenteNo.DefaultSetting = @"";
				colvarOAAntecedenteMortPerinatalRecurrenteNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteMortPerinatalRecurrenteNo);
				
				TableSchema.TableColumn colvarOAAntecedenteRetencionPlacentaSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteRetencionPlacentaSi.ColumnName = "OAAntecedenteRetencionPlacentaSi";
				colvarOAAntecedenteRetencionPlacentaSi.DataType = DbType.Boolean;
				colvarOAAntecedenteRetencionPlacentaSi.MaxLength = 0;
				colvarOAAntecedenteRetencionPlacentaSi.AutoIncrement = false;
				colvarOAAntecedenteRetencionPlacentaSi.IsNullable = true;
				colvarOAAntecedenteRetencionPlacentaSi.IsPrimaryKey = false;
				colvarOAAntecedenteRetencionPlacentaSi.IsForeignKey = false;
				colvarOAAntecedenteRetencionPlacentaSi.IsReadOnly = false;
				colvarOAAntecedenteRetencionPlacentaSi.DefaultSetting = @"";
				colvarOAAntecedenteRetencionPlacentaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteRetencionPlacentaSi);
				
				TableSchema.TableColumn colvarOAAntecedenteRetencionPlacentaNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteRetencionPlacentaNo.ColumnName = "OAAntecedenteRetencionPlacentaNo";
				colvarOAAntecedenteRetencionPlacentaNo.DataType = DbType.Boolean;
				colvarOAAntecedenteRetencionPlacentaNo.MaxLength = 0;
				colvarOAAntecedenteRetencionPlacentaNo.AutoIncrement = false;
				colvarOAAntecedenteRetencionPlacentaNo.IsNullable = true;
				colvarOAAntecedenteRetencionPlacentaNo.IsPrimaryKey = false;
				colvarOAAntecedenteRetencionPlacentaNo.IsForeignKey = false;
				colvarOAAntecedenteRetencionPlacentaNo.IsReadOnly = false;
				colvarOAAntecedenteRetencionPlacentaNo.DefaultSetting = @"";
				colvarOAAntecedenteRetencionPlacentaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteRetencionPlacentaNo);
				
				TableSchema.TableColumn colvarOAAntecedenteDistociaHombrosSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteDistociaHombrosSi.ColumnName = "OAAntecedenteDistociaHombrosSi";
				colvarOAAntecedenteDistociaHombrosSi.DataType = DbType.Boolean;
				colvarOAAntecedenteDistociaHombrosSi.MaxLength = 0;
				colvarOAAntecedenteDistociaHombrosSi.AutoIncrement = false;
				colvarOAAntecedenteDistociaHombrosSi.IsNullable = true;
				colvarOAAntecedenteDistociaHombrosSi.IsPrimaryKey = false;
				colvarOAAntecedenteDistociaHombrosSi.IsForeignKey = false;
				colvarOAAntecedenteDistociaHombrosSi.IsReadOnly = false;
				colvarOAAntecedenteDistociaHombrosSi.DefaultSetting = @"";
				colvarOAAntecedenteDistociaHombrosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteDistociaHombrosSi);
				
				TableSchema.TableColumn colvarOAAntecedenteDistociaHombrosNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteDistociaHombrosNo.ColumnName = "OAAntecedenteDistociaHombrosNo";
				colvarOAAntecedenteDistociaHombrosNo.DataType = DbType.Boolean;
				colvarOAAntecedenteDistociaHombrosNo.MaxLength = 0;
				colvarOAAntecedenteDistociaHombrosNo.AutoIncrement = false;
				colvarOAAntecedenteDistociaHombrosNo.IsNullable = true;
				colvarOAAntecedenteDistociaHombrosNo.IsPrimaryKey = false;
				colvarOAAntecedenteDistociaHombrosNo.IsForeignKey = false;
				colvarOAAntecedenteDistociaHombrosNo.IsReadOnly = false;
				colvarOAAntecedenteDistociaHombrosNo.DefaultSetting = @"";
				colvarOAAntecedenteDistociaHombrosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteDistociaHombrosNo);
				
				TableSchema.TableColumn colvarOAAntecedenteMalformCongenSi = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteMalformCongenSi.ColumnName = "OAAntecedenteMalformCongenSi";
				colvarOAAntecedenteMalformCongenSi.DataType = DbType.Boolean;
				colvarOAAntecedenteMalformCongenSi.MaxLength = 0;
				colvarOAAntecedenteMalformCongenSi.AutoIncrement = false;
				colvarOAAntecedenteMalformCongenSi.IsNullable = true;
				colvarOAAntecedenteMalformCongenSi.IsPrimaryKey = false;
				colvarOAAntecedenteMalformCongenSi.IsForeignKey = false;
				colvarOAAntecedenteMalformCongenSi.IsReadOnly = false;
				colvarOAAntecedenteMalformCongenSi.DefaultSetting = @"";
				colvarOAAntecedenteMalformCongenSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteMalformCongenSi);
				
				TableSchema.TableColumn colvarOAAntecedenteMalformCongenNo = new TableSchema.TableColumn(schema);
				colvarOAAntecedenteMalformCongenNo.ColumnName = "OAAntecedenteMalformCongenNo";
				colvarOAAntecedenteMalformCongenNo.DataType = DbType.Boolean;
				colvarOAAntecedenteMalformCongenNo.MaxLength = 0;
				colvarOAAntecedenteMalformCongenNo.AutoIncrement = false;
				colvarOAAntecedenteMalformCongenNo.IsNullable = true;
				colvarOAAntecedenteMalformCongenNo.IsPrimaryKey = false;
				colvarOAAntecedenteMalformCongenNo.IsForeignKey = false;
				colvarOAAntecedenteMalformCongenNo.IsReadOnly = false;
				colvarOAAntecedenteMalformCongenNo.DefaultSetting = @"";
				colvarOAAntecedenteMalformCongenNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOAAntecedenteMalformCongenNo);
				
				TableSchema.TableColumn colvarFactorRiesgoEmbarazoSinContSocialSi = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoEmbarazoSinContSocialSi.ColumnName = "FactorRiesgoEmbarazoSinContSocialSi";
				colvarFactorRiesgoEmbarazoSinContSocialSi.DataType = DbType.Boolean;
				colvarFactorRiesgoEmbarazoSinContSocialSi.MaxLength = 0;
				colvarFactorRiesgoEmbarazoSinContSocialSi.AutoIncrement = false;
				colvarFactorRiesgoEmbarazoSinContSocialSi.IsNullable = true;
				colvarFactorRiesgoEmbarazoSinContSocialSi.IsPrimaryKey = false;
				colvarFactorRiesgoEmbarazoSinContSocialSi.IsForeignKey = false;
				colvarFactorRiesgoEmbarazoSinContSocialSi.IsReadOnly = false;
				colvarFactorRiesgoEmbarazoSinContSocialSi.DefaultSetting = @"";
				colvarFactorRiesgoEmbarazoSinContSocialSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoEmbarazoSinContSocialSi);
				
				TableSchema.TableColumn colvarFactorRiesgoEmbarazoSinContSocialNo = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoEmbarazoSinContSocialNo.ColumnName = "FactorRiesgoEmbarazoSinContSocialNo";
				colvarFactorRiesgoEmbarazoSinContSocialNo.DataType = DbType.Boolean;
				colvarFactorRiesgoEmbarazoSinContSocialNo.MaxLength = 0;
				colvarFactorRiesgoEmbarazoSinContSocialNo.AutoIncrement = false;
				colvarFactorRiesgoEmbarazoSinContSocialNo.IsNullable = true;
				colvarFactorRiesgoEmbarazoSinContSocialNo.IsPrimaryKey = false;
				colvarFactorRiesgoEmbarazoSinContSocialNo.IsForeignKey = false;
				colvarFactorRiesgoEmbarazoSinContSocialNo.IsReadOnly = false;
				colvarFactorRiesgoEmbarazoSinContSocialNo.DefaultSetting = @"";
				colvarFactorRiesgoEmbarazoSinContSocialNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoEmbarazoSinContSocialNo);
				
				TableSchema.TableColumn colvarFactorRiesgoFamiliaSinIngresosFijosSi = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.ColumnName = "FactorRiesgoFamiliaSinIngresosFijosSi";
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.DataType = DbType.Boolean;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.MaxLength = 0;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.AutoIncrement = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.IsNullable = true;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.IsPrimaryKey = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.IsForeignKey = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.IsReadOnly = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.DefaultSetting = @"";
				colvarFactorRiesgoFamiliaSinIngresosFijosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoFamiliaSinIngresosFijosSi);
				
				TableSchema.TableColumn colvarFactorRiesgoFamiliaSinIngresosFijosNo = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.ColumnName = "FactorRiesgoFamiliaSinIngresosFijosNo";
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.DataType = DbType.Boolean;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.MaxLength = 0;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.AutoIncrement = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.IsNullable = true;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.IsPrimaryKey = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.IsForeignKey = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.IsReadOnly = false;
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.DefaultSetting = @"";
				colvarFactorRiesgoFamiliaSinIngresosFijosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoFamiliaSinIngresosFijosNo);
				
				TableSchema.TableColumn colvarFactorRiesgoEmbarazoFuertRechazadoSi = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.ColumnName = "FactorRiesgoEmbarazoFuertRechazadoSi";
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.DataType = DbType.Boolean;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.MaxLength = 0;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.AutoIncrement = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.IsNullable = true;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.IsPrimaryKey = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.IsForeignKey = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.IsReadOnly = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.DefaultSetting = @"";
				colvarFactorRiesgoEmbarazoFuertRechazadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoEmbarazoFuertRechazadoSi);
				
				TableSchema.TableColumn colvarFactorRiesgoEmbarazoFuertRechazadoNo = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.ColumnName = "FactorRiesgoEmbarazoFuertRechazadoNo";
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.DataType = DbType.Boolean;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.MaxLength = 0;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.AutoIncrement = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.IsNullable = true;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.IsPrimaryKey = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.IsForeignKey = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.IsReadOnly = false;
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.DefaultSetting = @"";
				colvarFactorRiesgoEmbarazoFuertRechazadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoEmbarazoFuertRechazadoNo);
				
				TableSchema.TableColumn colvarFactorRiesgoHijosDadosAdopcionSi = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoHijosDadosAdopcionSi.ColumnName = "FactorRiesgoHijosDadosAdopcionSi";
				colvarFactorRiesgoHijosDadosAdopcionSi.DataType = DbType.Boolean;
				colvarFactorRiesgoHijosDadosAdopcionSi.MaxLength = 0;
				colvarFactorRiesgoHijosDadosAdopcionSi.AutoIncrement = false;
				colvarFactorRiesgoHijosDadosAdopcionSi.IsNullable = true;
				colvarFactorRiesgoHijosDadosAdopcionSi.IsPrimaryKey = false;
				colvarFactorRiesgoHijosDadosAdopcionSi.IsForeignKey = false;
				colvarFactorRiesgoHijosDadosAdopcionSi.IsReadOnly = false;
				colvarFactorRiesgoHijosDadosAdopcionSi.DefaultSetting = @"";
				colvarFactorRiesgoHijosDadosAdopcionSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoHijosDadosAdopcionSi);
				
				TableSchema.TableColumn colvarFactorRiesgoHijosDadosAdopcionNo = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoHijosDadosAdopcionNo.ColumnName = "FactorRiesgoHijosDadosAdopcionNo";
				colvarFactorRiesgoHijosDadosAdopcionNo.DataType = DbType.Boolean;
				colvarFactorRiesgoHijosDadosAdopcionNo.MaxLength = 0;
				colvarFactorRiesgoHijosDadosAdopcionNo.AutoIncrement = false;
				colvarFactorRiesgoHijosDadosAdopcionNo.IsNullable = true;
				colvarFactorRiesgoHijosDadosAdopcionNo.IsPrimaryKey = false;
				colvarFactorRiesgoHijosDadosAdopcionNo.IsForeignKey = false;
				colvarFactorRiesgoHijosDadosAdopcionNo.IsReadOnly = false;
				colvarFactorRiesgoHijosDadosAdopcionNo.DefaultSetting = @"";
				colvarFactorRiesgoHijosDadosAdopcionNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoHijosDadosAdopcionNo);
				
				TableSchema.TableColumn colvarFactorRiesgoViviendaSinServiciosBasicosSi = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.ColumnName = "FactorRiesgoViviendaSinServiciosBasicosSi";
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.DataType = DbType.Boolean;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.MaxLength = 0;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.AutoIncrement = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.IsNullable = true;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.IsPrimaryKey = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.IsForeignKey = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.IsReadOnly = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.DefaultSetting = @"";
				colvarFactorRiesgoViviendaSinServiciosBasicosSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoViviendaSinServiciosBasicosSi);
				
				TableSchema.TableColumn colvarFactorRiesgoViviendaSinServiciosBasicosNo = new TableSchema.TableColumn(schema);
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.ColumnName = "FactorRiesgoViviendaSinServiciosBasicosNo";
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.DataType = DbType.Boolean;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.MaxLength = 0;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.AutoIncrement = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.IsNullable = true;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.IsPrimaryKey = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.IsForeignKey = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.IsReadOnly = false;
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.DefaultSetting = @"";
				colvarFactorRiesgoViviendaSinServiciosBasicosNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFactorRiesgoViviendaSinServiciosBasicosNo);
				
				TableSchema.TableColumn colvarCaptacionOportunaAntes16sem = new TableSchema.TableColumn(schema);
				colvarCaptacionOportunaAntes16sem.ColumnName = "CaptacionOportunaAntes16sem";
				colvarCaptacionOportunaAntes16sem.DataType = DbType.Boolean;
				colvarCaptacionOportunaAntes16sem.MaxLength = 0;
				colvarCaptacionOportunaAntes16sem.AutoIncrement = false;
				colvarCaptacionOportunaAntes16sem.IsNullable = true;
				colvarCaptacionOportunaAntes16sem.IsPrimaryKey = false;
				colvarCaptacionOportunaAntes16sem.IsForeignKey = false;
				colvarCaptacionOportunaAntes16sem.IsReadOnly = false;
				colvarCaptacionOportunaAntes16sem.DefaultSetting = @"";
				colvarCaptacionOportunaAntes16sem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaptacionOportunaAntes16sem);
				
				TableSchema.TableColumn colvarCaptacionOportunaDespues16sem = new TableSchema.TableColumn(schema);
				colvarCaptacionOportunaDespues16sem.ColumnName = "CaptacionOportunaDespues16sem";
				colvarCaptacionOportunaDespues16sem.DataType = DbType.Boolean;
				colvarCaptacionOportunaDespues16sem.MaxLength = 0;
				colvarCaptacionOportunaDespues16sem.AutoIncrement = false;
				colvarCaptacionOportunaDespues16sem.IsNullable = true;
				colvarCaptacionOportunaDespues16sem.IsPrimaryKey = false;
				colvarCaptacionOportunaDespues16sem.IsForeignKey = false;
				colvarCaptacionOportunaDespues16sem.IsReadOnly = false;
				colvarCaptacionOportunaDespues16sem.DefaultSetting = @"";
				colvarCaptacionOportunaDespues16sem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaptacionOportunaDespues16sem);
				
				TableSchema.TableColumn colvarFechaMuestraPAP = new TableSchema.TableColumn(schema);
				colvarFechaMuestraPAP.ColumnName = "FechaMuestraPAP";
				colvarFechaMuestraPAP.DataType = DbType.DateTime;
				colvarFechaMuestraPAP.MaxLength = 0;
				colvarFechaMuestraPAP.AutoIncrement = false;
				colvarFechaMuestraPAP.IsNullable = true;
				colvarFechaMuestraPAP.IsPrimaryKey = false;
				colvarFechaMuestraPAP.IsForeignKey = false;
				colvarFechaMuestraPAP.IsReadOnly = false;
				colvarFechaMuestraPAP.DefaultSetting = @"";
				colvarFechaMuestraPAP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaMuestraPAP);
				
				TableSchema.TableColumn colvarFechaTripleAcelular = new TableSchema.TableColumn(schema);
				colvarFechaTripleAcelular.ColumnName = "FechaTripleAcelular";
				colvarFechaTripleAcelular.DataType = DbType.DateTime;
				colvarFechaTripleAcelular.MaxLength = 0;
				colvarFechaTripleAcelular.AutoIncrement = false;
				colvarFechaTripleAcelular.IsNullable = true;
				colvarFechaTripleAcelular.IsPrimaryKey = false;
				colvarFechaTripleAcelular.IsForeignKey = false;
				colvarFechaTripleAcelular.IsReadOnly = false;
				colvarFechaTripleAcelular.DefaultSetting = @"";
				colvarFechaTripleAcelular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTripleAcelular);
				
				TableSchema.TableColumn colvarFechaAntigripal = new TableSchema.TableColumn(schema);
				colvarFechaAntigripal.ColumnName = "FechaAntigripal";
				colvarFechaAntigripal.DataType = DbType.DateTime;
				colvarFechaAntigripal.MaxLength = 0;
				colvarFechaAntigripal.AutoIncrement = false;
				colvarFechaAntigripal.IsNullable = true;
				colvarFechaAntigripal.IsPrimaryKey = false;
				colvarFechaAntigripal.IsForeignKey = false;
				colvarFechaAntigripal.IsReadOnly = false;
				colvarFechaAntigripal.DefaultSetting = @"";
				colvarFechaAntigripal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAntigripal);
				
				TableSchema.TableColumn colvarVIHSegundaMuestraSolicitadoSi = new TableSchema.TableColumn(schema);
				colvarVIHSegundaMuestraSolicitadoSi.ColumnName = "VIHSegundaMuestraSolicitadoSi";
				colvarVIHSegundaMuestraSolicitadoSi.DataType = DbType.Boolean;
				colvarVIHSegundaMuestraSolicitadoSi.MaxLength = 0;
				colvarVIHSegundaMuestraSolicitadoSi.AutoIncrement = false;
				colvarVIHSegundaMuestraSolicitadoSi.IsNullable = true;
				colvarVIHSegundaMuestraSolicitadoSi.IsPrimaryKey = false;
				colvarVIHSegundaMuestraSolicitadoSi.IsForeignKey = false;
				colvarVIHSegundaMuestraSolicitadoSi.IsReadOnly = false;
				colvarVIHSegundaMuestraSolicitadoSi.DefaultSetting = @"";
				colvarVIHSegundaMuestraSolicitadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHSegundaMuestraSolicitadoSi);
				
				TableSchema.TableColumn colvarVIHSegundaMuestraSolicitadoNo = new TableSchema.TableColumn(schema);
				colvarVIHSegundaMuestraSolicitadoNo.ColumnName = "VIHSegundaMuestraSolicitadoNo";
				colvarVIHSegundaMuestraSolicitadoNo.DataType = DbType.Boolean;
				colvarVIHSegundaMuestraSolicitadoNo.MaxLength = 0;
				colvarVIHSegundaMuestraSolicitadoNo.AutoIncrement = false;
				colvarVIHSegundaMuestraSolicitadoNo.IsNullable = true;
				colvarVIHSegundaMuestraSolicitadoNo.IsPrimaryKey = false;
				colvarVIHSegundaMuestraSolicitadoNo.IsForeignKey = false;
				colvarVIHSegundaMuestraSolicitadoNo.IsReadOnly = false;
				colvarVIHSegundaMuestraSolicitadoNo.DefaultSetting = @"";
				colvarVIHSegundaMuestraSolicitadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHSegundaMuestraSolicitadoNo);
				
				TableSchema.TableColumn colvarVIHSegundaMuestraRealizadoSi = new TableSchema.TableColumn(schema);
				colvarVIHSegundaMuestraRealizadoSi.ColumnName = "VIHSegundaMuestraRealizadoSi";
				colvarVIHSegundaMuestraRealizadoSi.DataType = DbType.Boolean;
				colvarVIHSegundaMuestraRealizadoSi.MaxLength = 0;
				colvarVIHSegundaMuestraRealizadoSi.AutoIncrement = false;
				colvarVIHSegundaMuestraRealizadoSi.IsNullable = true;
				colvarVIHSegundaMuestraRealizadoSi.IsPrimaryKey = false;
				colvarVIHSegundaMuestraRealizadoSi.IsForeignKey = false;
				colvarVIHSegundaMuestraRealizadoSi.IsReadOnly = false;
				colvarVIHSegundaMuestraRealizadoSi.DefaultSetting = @"";
				colvarVIHSegundaMuestraRealizadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHSegundaMuestraRealizadoSi);
				
				TableSchema.TableColumn colvarVIHSegundaMuestraRealizadoNo = new TableSchema.TableColumn(schema);
				colvarVIHSegundaMuestraRealizadoNo.ColumnName = "VIHSegundaMuestraRealizadoNo";
				colvarVIHSegundaMuestraRealizadoNo.DataType = DbType.Boolean;
				colvarVIHSegundaMuestraRealizadoNo.MaxLength = 0;
				colvarVIHSegundaMuestraRealizadoNo.AutoIncrement = false;
				colvarVIHSegundaMuestraRealizadoNo.IsNullable = true;
				colvarVIHSegundaMuestraRealizadoNo.IsPrimaryKey = false;
				colvarVIHSegundaMuestraRealizadoNo.IsForeignKey = false;
				colvarVIHSegundaMuestraRealizadoNo.IsReadOnly = false;
				colvarVIHSegundaMuestraRealizadoNo.DefaultSetting = @"";
				colvarVIHSegundaMuestraRealizadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHSegundaMuestraRealizadoNo);
				
				TableSchema.TableColumn colvarVIHSegundaMuestraFecha = new TableSchema.TableColumn(schema);
				colvarVIHSegundaMuestraFecha.ColumnName = "VIHSegundaMuestraFecha";
				colvarVIHSegundaMuestraFecha.DataType = DbType.DateTime;
				colvarVIHSegundaMuestraFecha.MaxLength = 0;
				colvarVIHSegundaMuestraFecha.AutoIncrement = false;
				colvarVIHSegundaMuestraFecha.IsNullable = true;
				colvarVIHSegundaMuestraFecha.IsPrimaryKey = false;
				colvarVIHSegundaMuestraFecha.IsForeignKey = false;
				colvarVIHSegundaMuestraFecha.IsReadOnly = false;
				colvarVIHSegundaMuestraFecha.DefaultSetting = @"";
				colvarVIHSegundaMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHSegundaMuestraFecha);
				
				TableSchema.TableColumn colvarVIHTercerMuestraSolicitadoSi = new TableSchema.TableColumn(schema);
				colvarVIHTercerMuestraSolicitadoSi.ColumnName = "VIHTercerMuestraSolicitadoSi";
				colvarVIHTercerMuestraSolicitadoSi.DataType = DbType.Boolean;
				colvarVIHTercerMuestraSolicitadoSi.MaxLength = 0;
				colvarVIHTercerMuestraSolicitadoSi.AutoIncrement = false;
				colvarVIHTercerMuestraSolicitadoSi.IsNullable = true;
				colvarVIHTercerMuestraSolicitadoSi.IsPrimaryKey = false;
				colvarVIHTercerMuestraSolicitadoSi.IsForeignKey = false;
				colvarVIHTercerMuestraSolicitadoSi.IsReadOnly = false;
				colvarVIHTercerMuestraSolicitadoSi.DefaultSetting = @"";
				colvarVIHTercerMuestraSolicitadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHTercerMuestraSolicitadoSi);
				
				TableSchema.TableColumn colvarVIHTercerMuestraSolicitadoNo = new TableSchema.TableColumn(schema);
				colvarVIHTercerMuestraSolicitadoNo.ColumnName = "VIHTercerMuestraSolicitadoNo";
				colvarVIHTercerMuestraSolicitadoNo.DataType = DbType.Boolean;
				colvarVIHTercerMuestraSolicitadoNo.MaxLength = 0;
				colvarVIHTercerMuestraSolicitadoNo.AutoIncrement = false;
				colvarVIHTercerMuestraSolicitadoNo.IsNullable = true;
				colvarVIHTercerMuestraSolicitadoNo.IsPrimaryKey = false;
				colvarVIHTercerMuestraSolicitadoNo.IsForeignKey = false;
				colvarVIHTercerMuestraSolicitadoNo.IsReadOnly = false;
				colvarVIHTercerMuestraSolicitadoNo.DefaultSetting = @"";
				colvarVIHTercerMuestraSolicitadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHTercerMuestraSolicitadoNo);
				
				TableSchema.TableColumn colvarVIHTercerMuestraRealizadoSi = new TableSchema.TableColumn(schema);
				colvarVIHTercerMuestraRealizadoSi.ColumnName = "VIHTercerMuestraRealizadoSi";
				colvarVIHTercerMuestraRealizadoSi.DataType = DbType.Boolean;
				colvarVIHTercerMuestraRealizadoSi.MaxLength = 0;
				colvarVIHTercerMuestraRealizadoSi.AutoIncrement = false;
				colvarVIHTercerMuestraRealizadoSi.IsNullable = true;
				colvarVIHTercerMuestraRealizadoSi.IsPrimaryKey = false;
				colvarVIHTercerMuestraRealizadoSi.IsForeignKey = false;
				colvarVIHTercerMuestraRealizadoSi.IsReadOnly = false;
				colvarVIHTercerMuestraRealizadoSi.DefaultSetting = @"";
				colvarVIHTercerMuestraRealizadoSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHTercerMuestraRealizadoSi);
				
				TableSchema.TableColumn colvarVIHTercerMuestraRealizadoNo = new TableSchema.TableColumn(schema);
				colvarVIHTercerMuestraRealizadoNo.ColumnName = "VIHTercerMuestraRealizadoNo";
				colvarVIHTercerMuestraRealizadoNo.DataType = DbType.Boolean;
				colvarVIHTercerMuestraRealizadoNo.MaxLength = 0;
				colvarVIHTercerMuestraRealizadoNo.AutoIncrement = false;
				colvarVIHTercerMuestraRealizadoNo.IsNullable = true;
				colvarVIHTercerMuestraRealizadoNo.IsPrimaryKey = false;
				colvarVIHTercerMuestraRealizadoNo.IsForeignKey = false;
				colvarVIHTercerMuestraRealizadoNo.IsReadOnly = false;
				colvarVIHTercerMuestraRealizadoNo.DefaultSetting = @"";
				colvarVIHTercerMuestraRealizadoNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHTercerMuestraRealizadoNo);
				
				TableSchema.TableColumn colvarVIHTercerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarVIHTercerMuestraFecha.ColumnName = "VIHTercerMuestraFecha";
				colvarVIHTercerMuestraFecha.DataType = DbType.DateTime;
				colvarVIHTercerMuestraFecha.MaxLength = 0;
				colvarVIHTercerMuestraFecha.AutoIncrement = false;
				colvarVIHTercerMuestraFecha.IsNullable = true;
				colvarVIHTercerMuestraFecha.IsPrimaryKey = false;
				colvarVIHTercerMuestraFecha.IsForeignKey = false;
				colvarVIHTercerMuestraFecha.IsReadOnly = false;
				colvarVIHTercerMuestraFecha.DefaultSetting = @"";
				colvarVIHTercerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVIHTercerMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoPrimerMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoPrimerMuestra.ColumnName = "SifilisPruebaNoTrepoPrimerMuestra";
				colvarSifilisPruebaNoTrepoPrimerMuestra.DataType = DbType.Decimal;
				colvarSifilisPruebaNoTrepoPrimerMuestra.MaxLength = 0;
				colvarSifilisPruebaNoTrepoPrimerMuestra.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoPrimerMuestra.IsNullable = true;
				colvarSifilisPruebaNoTrepoPrimerMuestra.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestra.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestra.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoPrimerMuestra.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoPrimerMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoPrimerMuestra);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoPrimerMuestraNegativo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.ColumnName = "SifilisPruebaNoTrepoPrimerMuestraNegativo";
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.MaxLength = 0;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.IsNullable = true;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoPrimerMuestraNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoPrimerMuestraNegativo);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoPrimerMuestraPositivo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.ColumnName = "SifilisPruebaNoTrepoPrimerMuestraPositivo";
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.MaxLength = 0;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.IsNullable = true;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoPrimerMuestraPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoPrimerMuestraPositivo);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.ColumnName = "SifilisPruebaNoTrepoPrimerMuestraSinDatos";
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.MaxLength = 0;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.IsNullable = true;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoPrimerMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoPrimerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.ColumnName = "SifilisPruebaNoTrepoPrimerMuestraFecha";
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.MaxLength = 0;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.IsNullable = true;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoPrimerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoPrimerMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoSegundaMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoSegundaMuestra.ColumnName = "SifilisPruebaNoTrepoSegundaMuestra";
				colvarSifilisPruebaNoTrepoSegundaMuestra.DataType = DbType.Decimal;
				colvarSifilisPruebaNoTrepoSegundaMuestra.MaxLength = 0;
				colvarSifilisPruebaNoTrepoSegundaMuestra.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoSegundaMuestra.IsNullable = true;
				colvarSifilisPruebaNoTrepoSegundaMuestra.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestra.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestra.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoSegundaMuestra.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoSegundaMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoSegundaMuestra);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoSegundaMuestraNegativo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.ColumnName = "SifilisPruebaNoTrepoSegundaMuestraNegativo";
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.MaxLength = 0;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.IsNullable = true;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoSegundaMuestraNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoSegundaMuestraNegativo);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoSegundaMuestraPositivo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.ColumnName = "SifilisPruebaNoTrepoSegundaMuestraPositivo";
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.MaxLength = 0;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.IsNullable = true;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoSegundaMuestraPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoSegundaMuestraPositivo);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.ColumnName = "SifilisPruebaNoTrepoSegundaMuestraSinDatos";
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.MaxLength = 0;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.IsNullable = true;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoSegundaMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoSegundaMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.ColumnName = "SifilisPruebaNoTrepoSegundaMuestraFecha";
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.MaxLength = 0;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.IsNullable = true;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoSegundaMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoSegundaMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoTercerMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoTercerMuestra.ColumnName = "SifilisPruebaNoTrepoTercerMuestra";
				colvarSifilisPruebaNoTrepoTercerMuestra.DataType = DbType.Decimal;
				colvarSifilisPruebaNoTrepoTercerMuestra.MaxLength = 0;
				colvarSifilisPruebaNoTrepoTercerMuestra.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoTercerMuestra.IsNullable = true;
				colvarSifilisPruebaNoTrepoTercerMuestra.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestra.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestra.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoTercerMuestra.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoTercerMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoTercerMuestra);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoTercerMuestraNegativo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.ColumnName = "SifilisPruebaNoTrepoTercerMuestraNegativo";
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.MaxLength = 0;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.IsNullable = true;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoTercerMuestraNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoTercerMuestraNegativo);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoTercerMuestraPositivo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.ColumnName = "SifilisPruebaNoTrepoTercerMuestraPositivo";
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.MaxLength = 0;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.IsNullable = true;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoTercerMuestraPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoTercerMuestraPositivo);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoTercerMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.ColumnName = "SifilisPruebaNoTrepoTercerMuestraSinDatos";
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.MaxLength = 0;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.IsNullable = true;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoTercerMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoTercerMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisPruebaNoTrepoTercerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.ColumnName = "SifilisPruebaNoTrepoTercerMuestraFecha";
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.MaxLength = 0;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.AutoIncrement = false;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.IsNullable = true;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.IsPrimaryKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.IsForeignKey = false;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.IsReadOnly = false;
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.DefaultSetting = @"";
				colvarSifilisPruebaNoTrepoTercerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaNoTrepoTercerMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoPrimerMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoPrimerMuestra.ColumnName = "SifilisPruebaTrepoPrimerMuestra";
				colvarSifilisPruebaTrepoPrimerMuestra.DataType = DbType.Decimal;
				colvarSifilisPruebaTrepoPrimerMuestra.MaxLength = 0;
				colvarSifilisPruebaTrepoPrimerMuestra.AutoIncrement = false;
				colvarSifilisPruebaTrepoPrimerMuestra.IsNullable = true;
				colvarSifilisPruebaTrepoPrimerMuestra.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoPrimerMuestra.IsForeignKey = false;
				colvarSifilisPruebaTrepoPrimerMuestra.IsReadOnly = false;
				colvarSifilisPruebaTrepoPrimerMuestra.DefaultSetting = @"";
				colvarSifilisPruebaTrepoPrimerMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoPrimerMuestra);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoPrimerMuestraNegativo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.ColumnName = "SifilisPruebaTrepoPrimerMuestraNegativo";
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.MaxLength = 0;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.AutoIncrement = false;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.IsNullable = true;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.IsForeignKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.IsReadOnly = false;
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.DefaultSetting = @"";
				colvarSifilisPruebaTrepoPrimerMuestraNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoPrimerMuestraNegativo);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoPrimerMuestraPositivo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.ColumnName = "SifilisPruebaTrepoPrimerMuestraPositivo";
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.MaxLength = 0;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.AutoIncrement = false;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.IsNullable = true;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.IsForeignKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.IsReadOnly = false;
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.DefaultSetting = @"";
				colvarSifilisPruebaTrepoPrimerMuestraPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoPrimerMuestraPositivo);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoPrimerMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.ColumnName = "SifilisPruebaTrepoPrimerMuestraSinDatos";
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.MaxLength = 0;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.AutoIncrement = false;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.IsNullable = true;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.IsForeignKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.IsReadOnly = false;
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisPruebaTrepoPrimerMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoPrimerMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.ColumnName = "SifilisPruebaTrepoPrimerMuestraNoCorresponde";
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.MaxLength = 0;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.AutoIncrement = false;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.IsNullable = true;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.IsForeignKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.IsReadOnly = false;
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.DefaultSetting = @"";
				colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoPrimerMuestraNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoPrimerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoPrimerMuestraFecha.ColumnName = "SifilisPruebaTrepoPrimerMuestraFecha";
				colvarSifilisPruebaTrepoPrimerMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.MaxLength = 0;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.AutoIncrement = false;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.IsNullable = true;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.IsForeignKey = false;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.IsReadOnly = false;
				colvarSifilisPruebaTrepoPrimerMuestraFecha.DefaultSetting = @"";
				colvarSifilisPruebaTrepoPrimerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoPrimerMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoSegundaMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoSegundaMuestra.ColumnName = "SifilisPruebaTrepoSegundaMuestra";
				colvarSifilisPruebaTrepoSegundaMuestra.DataType = DbType.Decimal;
				colvarSifilisPruebaTrepoSegundaMuestra.MaxLength = 0;
				colvarSifilisPruebaTrepoSegundaMuestra.AutoIncrement = false;
				colvarSifilisPruebaTrepoSegundaMuestra.IsNullable = true;
				colvarSifilisPruebaTrepoSegundaMuestra.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoSegundaMuestra.IsForeignKey = false;
				colvarSifilisPruebaTrepoSegundaMuestra.IsReadOnly = false;
				colvarSifilisPruebaTrepoSegundaMuestra.DefaultSetting = @"";
				colvarSifilisPruebaTrepoSegundaMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoSegundaMuestra);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoSegundaMuestraNegativo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.ColumnName = "SifilisPruebaTrepoSegundaMuestraNegativo";
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.MaxLength = 0;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.AutoIncrement = false;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.IsNullable = true;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.IsForeignKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.IsReadOnly = false;
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.DefaultSetting = @"";
				colvarSifilisPruebaTrepoSegundaMuestraNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoSegundaMuestraNegativo);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoSegundaMuestraPositivo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.ColumnName = "SifilisPruebaTrepoSegundaMuestraPositivo";
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.MaxLength = 0;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.AutoIncrement = false;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.IsNullable = true;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.IsForeignKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.IsReadOnly = false;
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.DefaultSetting = @"";
				colvarSifilisPruebaTrepoSegundaMuestraPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoSegundaMuestraPositivo);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoSegundaMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.ColumnName = "SifilisPruebaTrepoSegundaMuestraSinDatos";
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.MaxLength = 0;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.AutoIncrement = false;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.IsNullable = true;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.IsForeignKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.IsReadOnly = false;
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisPruebaTrepoSegundaMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoSegundaMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.ColumnName = "SifilisPruebaTrepoSegundaMuestraNoCorresponde";
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.MaxLength = 0;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.AutoIncrement = false;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.IsNullable = true;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.IsForeignKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.IsReadOnly = false;
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.DefaultSetting = @"";
				colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoSegundaMuestraNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoSegundaMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoSegundaMuestraFecha.ColumnName = "SifilisPruebaTrepoSegundaMuestraFecha";
				colvarSifilisPruebaTrepoSegundaMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.MaxLength = 0;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.AutoIncrement = false;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.IsNullable = true;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.IsForeignKey = false;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.IsReadOnly = false;
				colvarSifilisPruebaTrepoSegundaMuestraFecha.DefaultSetting = @"";
				colvarSifilisPruebaTrepoSegundaMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoSegundaMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoTercerMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoTercerMuestra.ColumnName = "SifilisPruebaTrepoTercerMuestra";
				colvarSifilisPruebaTrepoTercerMuestra.DataType = DbType.Decimal;
				colvarSifilisPruebaTrepoTercerMuestra.MaxLength = 0;
				colvarSifilisPruebaTrepoTercerMuestra.AutoIncrement = false;
				colvarSifilisPruebaTrepoTercerMuestra.IsNullable = true;
				colvarSifilisPruebaTrepoTercerMuestra.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoTercerMuestra.IsForeignKey = false;
				colvarSifilisPruebaTrepoTercerMuestra.IsReadOnly = false;
				colvarSifilisPruebaTrepoTercerMuestra.DefaultSetting = @"";
				colvarSifilisPruebaTrepoTercerMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoTercerMuestra);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoTercerMuestraNegativo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoTercerMuestraNegativo.ColumnName = "SifilisPruebaTrepoTercerMuestraNegativo";
				colvarSifilisPruebaTrepoTercerMuestraNegativo.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.MaxLength = 0;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.AutoIncrement = false;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.IsNullable = true;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.IsForeignKey = false;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.IsReadOnly = false;
				colvarSifilisPruebaTrepoTercerMuestraNegativo.DefaultSetting = @"";
				colvarSifilisPruebaTrepoTercerMuestraNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoTercerMuestraNegativo);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoTercerMuestraPositivo = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoTercerMuestraPositivo.ColumnName = "SifilisPruebaTrepoTercerMuestraPositivo";
				colvarSifilisPruebaTrepoTercerMuestraPositivo.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.MaxLength = 0;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.AutoIncrement = false;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.IsNullable = true;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.IsForeignKey = false;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.IsReadOnly = false;
				colvarSifilisPruebaTrepoTercerMuestraPositivo.DefaultSetting = @"";
				colvarSifilisPruebaTrepoTercerMuestraPositivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoTercerMuestraPositivo);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoTercerMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.ColumnName = "SifilisPruebaTrepoTercerMuestraSinDatos";
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.MaxLength = 0;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.AutoIncrement = false;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.IsNullable = true;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.IsForeignKey = false;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.IsReadOnly = false;
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisPruebaTrepoTercerMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoTercerMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoTercerMuestraNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.ColumnName = "SifilisPruebaTrepoTercerMuestraNoCorresponde";
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.MaxLength = 0;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.AutoIncrement = false;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.IsNullable = true;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.IsForeignKey = false;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.IsReadOnly = false;
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.DefaultSetting = @"";
				colvarSifilisPruebaTrepoTercerMuestraNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoTercerMuestraNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisPruebaTrepoTercerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisPruebaTrepoTercerMuestraFecha.ColumnName = "SifilisPruebaTrepoTercerMuestraFecha";
				colvarSifilisPruebaTrepoTercerMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisPruebaTrepoTercerMuestraFecha.MaxLength = 0;
				colvarSifilisPruebaTrepoTercerMuestraFecha.AutoIncrement = false;
				colvarSifilisPruebaTrepoTercerMuestraFecha.IsNullable = true;
				colvarSifilisPruebaTrepoTercerMuestraFecha.IsPrimaryKey = false;
				colvarSifilisPruebaTrepoTercerMuestraFecha.IsForeignKey = false;
				colvarSifilisPruebaTrepoTercerMuestraFecha.IsReadOnly = false;
				colvarSifilisPruebaTrepoTercerMuestraFecha.DefaultSetting = @"";
				colvarSifilisPruebaTrepoTercerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisPruebaTrepoTercerMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisTratamientoPrimerMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoPrimerMuestra.ColumnName = "SifilisTratamientoPrimerMuestra";
				colvarSifilisTratamientoPrimerMuestra.DataType = DbType.Decimal;
				colvarSifilisTratamientoPrimerMuestra.MaxLength = 0;
				colvarSifilisTratamientoPrimerMuestra.AutoIncrement = false;
				colvarSifilisTratamientoPrimerMuestra.IsNullable = true;
				colvarSifilisTratamientoPrimerMuestra.IsPrimaryKey = false;
				colvarSifilisTratamientoPrimerMuestra.IsForeignKey = false;
				colvarSifilisTratamientoPrimerMuestra.IsReadOnly = false;
				colvarSifilisTratamientoPrimerMuestra.DefaultSetting = @"";
				colvarSifilisTratamientoPrimerMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoPrimerMuestra);
				
				TableSchema.TableColumn colvarSifilisTratamientoPrimerMuestraNo = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoPrimerMuestraNo.ColumnName = "SifilisTratamientoPrimerMuestraNo";
				colvarSifilisTratamientoPrimerMuestraNo.DataType = DbType.Boolean;
				colvarSifilisTratamientoPrimerMuestraNo.MaxLength = 0;
				colvarSifilisTratamientoPrimerMuestraNo.AutoIncrement = false;
				colvarSifilisTratamientoPrimerMuestraNo.IsNullable = true;
				colvarSifilisTratamientoPrimerMuestraNo.IsPrimaryKey = false;
				colvarSifilisTratamientoPrimerMuestraNo.IsForeignKey = false;
				colvarSifilisTratamientoPrimerMuestraNo.IsReadOnly = false;
				colvarSifilisTratamientoPrimerMuestraNo.DefaultSetting = @"";
				colvarSifilisTratamientoPrimerMuestraNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoPrimerMuestraNo);
				
				TableSchema.TableColumn colvarSifilisTratamientoPrimerMuestraSi = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoPrimerMuestraSi.ColumnName = "SifilisTratamientoPrimerMuestraSi";
				colvarSifilisTratamientoPrimerMuestraSi.DataType = DbType.Boolean;
				colvarSifilisTratamientoPrimerMuestraSi.MaxLength = 0;
				colvarSifilisTratamientoPrimerMuestraSi.AutoIncrement = false;
				colvarSifilisTratamientoPrimerMuestraSi.IsNullable = true;
				colvarSifilisTratamientoPrimerMuestraSi.IsPrimaryKey = false;
				colvarSifilisTratamientoPrimerMuestraSi.IsForeignKey = false;
				colvarSifilisTratamientoPrimerMuestraSi.IsReadOnly = false;
				colvarSifilisTratamientoPrimerMuestraSi.DefaultSetting = @"";
				colvarSifilisTratamientoPrimerMuestraSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoPrimerMuestraSi);
				
				TableSchema.TableColumn colvarSifilisTratamientoPrimerMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoPrimerMuestraSinDatos.ColumnName = "SifilisTratamientoPrimerMuestraSinDatos";
				colvarSifilisTratamientoPrimerMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisTratamientoPrimerMuestraSinDatos.MaxLength = 0;
				colvarSifilisTratamientoPrimerMuestraSinDatos.AutoIncrement = false;
				colvarSifilisTratamientoPrimerMuestraSinDatos.IsNullable = true;
				colvarSifilisTratamientoPrimerMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisTratamientoPrimerMuestraSinDatos.IsForeignKey = false;
				colvarSifilisTratamientoPrimerMuestraSinDatos.IsReadOnly = false;
				colvarSifilisTratamientoPrimerMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisTratamientoPrimerMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoPrimerMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisTratamientoPrimerMuestraNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.ColumnName = "SifilisTratamientoPrimerMuestraNoCorresponde";
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.MaxLength = 0;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.AutoIncrement = false;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.IsNullable = true;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.IsPrimaryKey = false;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.IsForeignKey = false;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.IsReadOnly = false;
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.DefaultSetting = @"";
				colvarSifilisTratamientoPrimerMuestraNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoPrimerMuestraNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisTratamientoPrimerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoPrimerMuestraFecha.ColumnName = "SifilisTratamientoPrimerMuestraFecha";
				colvarSifilisTratamientoPrimerMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisTratamientoPrimerMuestraFecha.MaxLength = 0;
				colvarSifilisTratamientoPrimerMuestraFecha.AutoIncrement = false;
				colvarSifilisTratamientoPrimerMuestraFecha.IsNullable = true;
				colvarSifilisTratamientoPrimerMuestraFecha.IsPrimaryKey = false;
				colvarSifilisTratamientoPrimerMuestraFecha.IsForeignKey = false;
				colvarSifilisTratamientoPrimerMuestraFecha.IsReadOnly = false;
				colvarSifilisTratamientoPrimerMuestraFecha.DefaultSetting = @"";
				colvarSifilisTratamientoPrimerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoPrimerMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisTratamientoSegundaMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoSegundaMuestra.ColumnName = "SifilisTratamientoSegundaMuestra";
				colvarSifilisTratamientoSegundaMuestra.DataType = DbType.Decimal;
				colvarSifilisTratamientoSegundaMuestra.MaxLength = 0;
				colvarSifilisTratamientoSegundaMuestra.AutoIncrement = false;
				colvarSifilisTratamientoSegundaMuestra.IsNullable = true;
				colvarSifilisTratamientoSegundaMuestra.IsPrimaryKey = false;
				colvarSifilisTratamientoSegundaMuestra.IsForeignKey = false;
				colvarSifilisTratamientoSegundaMuestra.IsReadOnly = false;
				colvarSifilisTratamientoSegundaMuestra.DefaultSetting = @"";
				colvarSifilisTratamientoSegundaMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoSegundaMuestra);
				
				TableSchema.TableColumn colvarSifilisTratamientoSegundaMuestraNo = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoSegundaMuestraNo.ColumnName = "SifilisTratamientoSegundaMuestraNo";
				colvarSifilisTratamientoSegundaMuestraNo.DataType = DbType.Boolean;
				colvarSifilisTratamientoSegundaMuestraNo.MaxLength = 0;
				colvarSifilisTratamientoSegundaMuestraNo.AutoIncrement = false;
				colvarSifilisTratamientoSegundaMuestraNo.IsNullable = true;
				colvarSifilisTratamientoSegundaMuestraNo.IsPrimaryKey = false;
				colvarSifilisTratamientoSegundaMuestraNo.IsForeignKey = false;
				colvarSifilisTratamientoSegundaMuestraNo.IsReadOnly = false;
				colvarSifilisTratamientoSegundaMuestraNo.DefaultSetting = @"";
				colvarSifilisTratamientoSegundaMuestraNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoSegundaMuestraNo);
				
				TableSchema.TableColumn colvarSifilisTratamientoSegundaMuestraSi = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoSegundaMuestraSi.ColumnName = "SifilisTratamientoSegundaMuestraSi";
				colvarSifilisTratamientoSegundaMuestraSi.DataType = DbType.Boolean;
				colvarSifilisTratamientoSegundaMuestraSi.MaxLength = 0;
				colvarSifilisTratamientoSegundaMuestraSi.AutoIncrement = false;
				colvarSifilisTratamientoSegundaMuestraSi.IsNullable = true;
				colvarSifilisTratamientoSegundaMuestraSi.IsPrimaryKey = false;
				colvarSifilisTratamientoSegundaMuestraSi.IsForeignKey = false;
				colvarSifilisTratamientoSegundaMuestraSi.IsReadOnly = false;
				colvarSifilisTratamientoSegundaMuestraSi.DefaultSetting = @"";
				colvarSifilisTratamientoSegundaMuestraSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoSegundaMuestraSi);
				
				TableSchema.TableColumn colvarSifilisTratamientoSegundaMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoSegundaMuestraSinDatos.ColumnName = "SifilisTratamientoSegundaMuestraSinDatos";
				colvarSifilisTratamientoSegundaMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisTratamientoSegundaMuestraSinDatos.MaxLength = 0;
				colvarSifilisTratamientoSegundaMuestraSinDatos.AutoIncrement = false;
				colvarSifilisTratamientoSegundaMuestraSinDatos.IsNullable = true;
				colvarSifilisTratamientoSegundaMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisTratamientoSegundaMuestraSinDatos.IsForeignKey = false;
				colvarSifilisTratamientoSegundaMuestraSinDatos.IsReadOnly = false;
				colvarSifilisTratamientoSegundaMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisTratamientoSegundaMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoSegundaMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisTratamientoSegundaMuestraNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.ColumnName = "SifilisTratamientoSegundaMuestraNoCorresponde";
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.MaxLength = 0;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.AutoIncrement = false;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.IsNullable = true;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.IsPrimaryKey = false;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.IsForeignKey = false;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.IsReadOnly = false;
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.DefaultSetting = @"";
				colvarSifilisTratamientoSegundaMuestraNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoSegundaMuestraNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisTratamientoSegundaMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoSegundaMuestraFecha.ColumnName = "SifilisTratamientoSegundaMuestraFecha";
				colvarSifilisTratamientoSegundaMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisTratamientoSegundaMuestraFecha.MaxLength = 0;
				colvarSifilisTratamientoSegundaMuestraFecha.AutoIncrement = false;
				colvarSifilisTratamientoSegundaMuestraFecha.IsNullable = true;
				colvarSifilisTratamientoSegundaMuestraFecha.IsPrimaryKey = false;
				colvarSifilisTratamientoSegundaMuestraFecha.IsForeignKey = false;
				colvarSifilisTratamientoSegundaMuestraFecha.IsReadOnly = false;
				colvarSifilisTratamientoSegundaMuestraFecha.DefaultSetting = @"";
				colvarSifilisTratamientoSegundaMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoSegundaMuestraFecha);
				
				TableSchema.TableColumn colvarSifilisTratamientoTercerMuestra = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoTercerMuestra.ColumnName = "SifilisTratamientoTercerMuestra";
				colvarSifilisTratamientoTercerMuestra.DataType = DbType.Decimal;
				colvarSifilisTratamientoTercerMuestra.MaxLength = 0;
				colvarSifilisTratamientoTercerMuestra.AutoIncrement = false;
				colvarSifilisTratamientoTercerMuestra.IsNullable = true;
				colvarSifilisTratamientoTercerMuestra.IsPrimaryKey = false;
				colvarSifilisTratamientoTercerMuestra.IsForeignKey = false;
				colvarSifilisTratamientoTercerMuestra.IsReadOnly = false;
				colvarSifilisTratamientoTercerMuestra.DefaultSetting = @"";
				colvarSifilisTratamientoTercerMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoTercerMuestra);
				
				TableSchema.TableColumn colvarSifilisTratamientoTercerMuestraNo = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoTercerMuestraNo.ColumnName = "SifilisTratamientoTercerMuestraNo";
				colvarSifilisTratamientoTercerMuestraNo.DataType = DbType.Boolean;
				colvarSifilisTratamientoTercerMuestraNo.MaxLength = 0;
				colvarSifilisTratamientoTercerMuestraNo.AutoIncrement = false;
				colvarSifilisTratamientoTercerMuestraNo.IsNullable = true;
				colvarSifilisTratamientoTercerMuestraNo.IsPrimaryKey = false;
				colvarSifilisTratamientoTercerMuestraNo.IsForeignKey = false;
				colvarSifilisTratamientoTercerMuestraNo.IsReadOnly = false;
				colvarSifilisTratamientoTercerMuestraNo.DefaultSetting = @"";
				colvarSifilisTratamientoTercerMuestraNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoTercerMuestraNo);
				
				TableSchema.TableColumn colvarSifilisTratamientoTercerMuestraSi = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoTercerMuestraSi.ColumnName = "SifilisTratamientoTercerMuestraSi";
				colvarSifilisTratamientoTercerMuestraSi.DataType = DbType.Boolean;
				colvarSifilisTratamientoTercerMuestraSi.MaxLength = 0;
				colvarSifilisTratamientoTercerMuestraSi.AutoIncrement = false;
				colvarSifilisTratamientoTercerMuestraSi.IsNullable = true;
				colvarSifilisTratamientoTercerMuestraSi.IsPrimaryKey = false;
				colvarSifilisTratamientoTercerMuestraSi.IsForeignKey = false;
				colvarSifilisTratamientoTercerMuestraSi.IsReadOnly = false;
				colvarSifilisTratamientoTercerMuestraSi.DefaultSetting = @"";
				colvarSifilisTratamientoTercerMuestraSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoTercerMuestraSi);
				
				TableSchema.TableColumn colvarSifilisTratamientoTercerMuestraSinDatos = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoTercerMuestraSinDatos.ColumnName = "SifilisTratamientoTercerMuestraSinDatos";
				colvarSifilisTratamientoTercerMuestraSinDatos.DataType = DbType.Boolean;
				colvarSifilisTratamientoTercerMuestraSinDatos.MaxLength = 0;
				colvarSifilisTratamientoTercerMuestraSinDatos.AutoIncrement = false;
				colvarSifilisTratamientoTercerMuestraSinDatos.IsNullable = true;
				colvarSifilisTratamientoTercerMuestraSinDatos.IsPrimaryKey = false;
				colvarSifilisTratamientoTercerMuestraSinDatos.IsForeignKey = false;
				colvarSifilisTratamientoTercerMuestraSinDatos.IsReadOnly = false;
				colvarSifilisTratamientoTercerMuestraSinDatos.DefaultSetting = @"";
				colvarSifilisTratamientoTercerMuestraSinDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoTercerMuestraSinDatos);
				
				TableSchema.TableColumn colvarSifilisTratamientoTercerMuestraNoCorresponde = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoTercerMuestraNoCorresponde.ColumnName = "SifilisTratamientoTercerMuestraNoCorresponde";
				colvarSifilisTratamientoTercerMuestraNoCorresponde.DataType = DbType.Boolean;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.MaxLength = 0;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.AutoIncrement = false;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.IsNullable = true;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.IsPrimaryKey = false;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.IsForeignKey = false;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.IsReadOnly = false;
				colvarSifilisTratamientoTercerMuestraNoCorresponde.DefaultSetting = @"";
				colvarSifilisTratamientoTercerMuestraNoCorresponde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoTercerMuestraNoCorresponde);
				
				TableSchema.TableColumn colvarSifilisTratamientoTercerMuestraFecha = new TableSchema.TableColumn(schema);
				colvarSifilisTratamientoTercerMuestraFecha.ColumnName = "SifilisTratamientoTercerMuestraFecha";
				colvarSifilisTratamientoTercerMuestraFecha.DataType = DbType.DateTime;
				colvarSifilisTratamientoTercerMuestraFecha.MaxLength = 0;
				colvarSifilisTratamientoTercerMuestraFecha.AutoIncrement = false;
				colvarSifilisTratamientoTercerMuestraFecha.IsNullable = true;
				colvarSifilisTratamientoTercerMuestraFecha.IsPrimaryKey = false;
				colvarSifilisTratamientoTercerMuestraFecha.IsForeignKey = false;
				colvarSifilisTratamientoTercerMuestraFecha.IsReadOnly = false;
				colvarSifilisTratamientoTercerMuestraFecha.DefaultSetting = @"";
				colvarSifilisTratamientoTercerMuestraFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilisTratamientoTercerMuestraFecha);
				
				TableSchema.TableColumn colvarActiva = new TableSchema.TableColumn(schema);
				colvarActiva.ColumnName = "activa";
				colvarActiva.DataType = DbType.Boolean;
				colvarActiva.MaxLength = 0;
				colvarActiva.AutoIncrement = false;
				colvarActiva.IsNullable = false;
				colvarActiva.IsPrimaryKey = false;
				colvarActiva.IsForeignKey = false;
				colvarActiva.IsReadOnly = false;
				
						colvarActiva.DefaultSetting = @"((1))";
				colvarActiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActiva);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 300;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
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
				
				TableSchema.TableColumn colvarIdEfectorTrasladoUt = new TableSchema.TableColumn(schema);
				colvarIdEfectorTrasladoUt.ColumnName = "idEfectorTrasladoUt";
				colvarIdEfectorTrasladoUt.DataType = DbType.Int32;
				colvarIdEfectorTrasladoUt.MaxLength = 0;
				colvarIdEfectorTrasladoUt.AutoIncrement = false;
				colvarIdEfectorTrasladoUt.IsNullable = true;
				colvarIdEfectorTrasladoUt.IsPrimaryKey = false;
				colvarIdEfectorTrasladoUt.IsForeignKey = true;
				colvarIdEfectorTrasladoUt.IsReadOnly = false;
				colvarIdEfectorTrasladoUt.DefaultSetting = @"";
				
					colvarIdEfectorTrasladoUt.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorTrasladoUt);
				
				TableSchema.TableColumn colvarDiabetesActualSi = new TableSchema.TableColumn(schema);
				colvarDiabetesActualSi.ColumnName = "DiabetesActualSi";
				colvarDiabetesActualSi.DataType = DbType.Boolean;
				colvarDiabetesActualSi.MaxLength = 0;
				colvarDiabetesActualSi.AutoIncrement = false;
				colvarDiabetesActualSi.IsNullable = true;
				colvarDiabetesActualSi.IsPrimaryKey = false;
				colvarDiabetesActualSi.IsForeignKey = false;
				colvarDiabetesActualSi.IsReadOnly = false;
				colvarDiabetesActualSi.DefaultSetting = @"";
				colvarDiabetesActualSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiabetesActualSi);
				
				TableSchema.TableColumn colvarDiabetesActualNo = new TableSchema.TableColumn(schema);
				colvarDiabetesActualNo.ColumnName = "DiabetesActualNo";
				colvarDiabetesActualNo.DataType = DbType.Boolean;
				colvarDiabetesActualNo.MaxLength = 0;
				colvarDiabetesActualNo.AutoIncrement = false;
				colvarDiabetesActualNo.IsNullable = true;
				colvarDiabetesActualNo.IsPrimaryKey = false;
				colvarDiabetesActualNo.IsForeignKey = false;
				colvarDiabetesActualNo.IsReadOnly = false;
				colvarDiabetesActualNo.DefaultSetting = @"";
				colvarDiabetesActualNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiabetesActualNo);
				
				TableSchema.TableColumn colvarAnemiaSi = new TableSchema.TableColumn(schema);
				colvarAnemiaSi.ColumnName = "AnemiaSi";
				colvarAnemiaSi.DataType = DbType.Boolean;
				colvarAnemiaSi.MaxLength = 0;
				colvarAnemiaSi.AutoIncrement = false;
				colvarAnemiaSi.IsNullable = true;
				colvarAnemiaSi.IsPrimaryKey = false;
				colvarAnemiaSi.IsForeignKey = false;
				colvarAnemiaSi.IsReadOnly = false;
				colvarAnemiaSi.DefaultSetting = @"";
				colvarAnemiaSi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnemiaSi);
				
				TableSchema.TableColumn colvarAnemiaNo = new TableSchema.TableColumn(schema);
				colvarAnemiaNo.ColumnName = "AnemiaNo";
				colvarAnemiaNo.DataType = DbType.Boolean;
				colvarAnemiaNo.MaxLength = 0;
				colvarAnemiaNo.AutoIncrement = false;
				colvarAnemiaNo.IsNullable = true;
				colvarAnemiaNo.IsPrimaryKey = false;
				colvarAnemiaNo.IsForeignKey = false;
				colvarAnemiaNo.IsReadOnly = false;
				colvarAnemiaNo.DefaultSetting = @"";
				colvarAnemiaNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnemiaNo);
				
				TableSchema.TableColumn colvarNumeroIdentidad = new TableSchema.TableColumn(schema);
				colvarNumeroIdentidad.ColumnName = "NumeroIdentidad";
				colvarNumeroIdentidad.DataType = DbType.AnsiString;
				colvarNumeroIdentidad.MaxLength = -1;
				colvarNumeroIdentidad.AutoIncrement = false;
				colvarNumeroIdentidad.IsNullable = true;
				colvarNumeroIdentidad.IsPrimaryKey = false;
				colvarNumeroIdentidad.IsForeignKey = false;
				colvarNumeroIdentidad.IsReadOnly = false;
				colvarNumeroIdentidad.DefaultSetting = @"";
				colvarNumeroIdentidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroIdentidad);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_HistoriaClinicaPerinatal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHistoriaClinicaPerinatal")]
		[Bindable(true)]
		public int IdHistoriaClinicaPerinatal 
		{
			get { return GetColumnValue<int>(Columns.IdHistoriaClinicaPerinatal); }
			set { SetColumnValue(Columns.IdHistoriaClinicaPerinatal, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Dni")]
		[Bindable(true)]
		public string Dni 
		{
			get { return GetColumnValue<string>(Columns.Dni); }
			set { SetColumnValue(Columns.Dni, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int? Edad 
		{
			get { return GetColumnValue<int?>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("DatosDeContacto")]
		[Bindable(true)]
		public string DatosDeContacto 
		{
			get { return GetColumnValue<string>(Columns.DatosDeContacto); }
			set { SetColumnValue(Columns.DatosDeContacto, value); }
		}
		  
		[XmlAttribute("EdadMenor15Mayor35")]
		[Bindable(true)]
		public bool? EdadMenor15Mayor35 
		{
			get { return GetColumnValue<bool?>(Columns.EdadMenor15Mayor35); }
			set { SetColumnValue(Columns.EdadMenor15Mayor35, value); }
		}
		  
		[XmlAttribute("EtniaBlanca")]
		[Bindable(true)]
		public bool? EtniaBlanca 
		{
			get { return GetColumnValue<bool?>(Columns.EtniaBlanca); }
			set { SetColumnValue(Columns.EtniaBlanca, value); }
		}
		  
		[XmlAttribute("EtniaIndigena")]
		[Bindable(true)]
		public bool? EtniaIndigena 
		{
			get { return GetColumnValue<bool?>(Columns.EtniaIndigena); }
			set { SetColumnValue(Columns.EtniaIndigena, value); }
		}
		  
		[XmlAttribute("EtniaMestiza")]
		[Bindable(true)]
		public bool? EtniaMestiza 
		{
			get { return GetColumnValue<bool?>(Columns.EtniaMestiza); }
			set { SetColumnValue(Columns.EtniaMestiza, value); }
		}
		  
		[XmlAttribute("EtniaNegra")]
		[Bindable(true)]
		public bool? EtniaNegra 
		{
			get { return GetColumnValue<bool?>(Columns.EtniaNegra); }
			set { SetColumnValue(Columns.EtniaNegra, value); }
		}
		  
		[XmlAttribute("EtniaOtra")]
		[Bindable(true)]
		public bool? EtniaOtra 
		{
			get { return GetColumnValue<bool?>(Columns.EtniaOtra); }
			set { SetColumnValue(Columns.EtniaOtra, value); }
		}
		  
		[XmlAttribute("AlfabetaSi")]
		[Bindable(true)]
		public bool? AlfabetaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AlfabetaSi); }
			set { SetColumnValue(Columns.AlfabetaSi, value); }
		}
		  
		[XmlAttribute("AlfabetaNo")]
		[Bindable(true)]
		public bool? AlfabetaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AlfabetaNo); }
			set { SetColumnValue(Columns.AlfabetaNo, value); }
		}
		  
		[XmlAttribute("EstudiosNinguno")]
		[Bindable(true)]
		public bool? EstudiosNinguno 
		{
			get { return GetColumnValue<bool?>(Columns.EstudiosNinguno); }
			set { SetColumnValue(Columns.EstudiosNinguno, value); }
		}
		  
		[XmlAttribute("EstudiosPrimario")]
		[Bindable(true)]
		public bool? EstudiosPrimario 
		{
			get { return GetColumnValue<bool?>(Columns.EstudiosPrimario); }
			set { SetColumnValue(Columns.EstudiosPrimario, value); }
		}
		  
		[XmlAttribute("EstudiosSecundario")]
		[Bindable(true)]
		public bool? EstudiosSecundario 
		{
			get { return GetColumnValue<bool?>(Columns.EstudiosSecundario); }
			set { SetColumnValue(Columns.EstudiosSecundario, value); }
		}
		  
		[XmlAttribute("EstudiosUniversitario")]
		[Bindable(true)]
		public bool? EstudiosUniversitario 
		{
			get { return GetColumnValue<bool?>(Columns.EstudiosUniversitario); }
			set { SetColumnValue(Columns.EstudiosUniversitario, value); }
		}
		  
		[XmlAttribute("AñosMayorNivel")]
		[Bindable(true)]
		public int? AñosMayorNivel 
		{
			get { return GetColumnValue<int?>(Columns.AñosMayorNivel); }
			set { SetColumnValue(Columns.AñosMayorNivel, value); }
		}
		  
		[XmlAttribute("EstadoCivilCasada")]
		[Bindable(true)]
		public bool? EstadoCivilCasada 
		{
			get { return GetColumnValue<bool?>(Columns.EstadoCivilCasada); }
			set { SetColumnValue(Columns.EstadoCivilCasada, value); }
		}
		  
		[XmlAttribute("EstadoCivilUnionEstable")]
		[Bindable(true)]
		public bool? EstadoCivilUnionEstable 
		{
			get { return GetColumnValue<bool?>(Columns.EstadoCivilUnionEstable); }
			set { SetColumnValue(Columns.EstadoCivilUnionEstable, value); }
		}
		  
		[XmlAttribute("EstadoCivilSoltera")]
		[Bindable(true)]
		public bool? EstadoCivilSoltera 
		{
			get { return GetColumnValue<bool?>(Columns.EstadoCivilSoltera); }
			set { SetColumnValue(Columns.EstadoCivilSoltera, value); }
		}
		  
		[XmlAttribute("EstadoCivilOtro")]
		[Bindable(true)]
		public bool? EstadoCivilOtro 
		{
			get { return GetColumnValue<bool?>(Columns.EstadoCivilOtro); }
			set { SetColumnValue(Columns.EstadoCivilOtro, value); }
		}
		  
		[XmlAttribute("ViveSolaSi")]
		[Bindable(true)]
		public bool? ViveSolaSi 
		{
			get { return GetColumnValue<bool?>(Columns.ViveSolaSi); }
			set { SetColumnValue(Columns.ViveSolaSi, value); }
		}
		  
		[XmlAttribute("ViveSolaNo")]
		[Bindable(true)]
		public bool? ViveSolaNo 
		{
			get { return GetColumnValue<bool?>(Columns.ViveSolaNo); }
			set { SetColumnValue(Columns.ViveSolaNo, value); }
		}
		  
		[XmlAttribute("LugarControlPerinatal")]
		[Bindable(true)]
		public string LugarControlPerinatal 
		{
			get { return GetColumnValue<string>(Columns.LugarControlPerinatal); }
			set { SetColumnValue(Columns.LugarControlPerinatal, value); }
		}
		  
		[XmlAttribute("LugarPartoAborto")]
		[Bindable(true)]
		public string LugarPartoAborto 
		{
			get { return GetColumnValue<string>(Columns.LugarPartoAborto); }
			set { SetColumnValue(Columns.LugarPartoAborto, value); }
		}
		  
		[XmlAttribute("AntFamTBCSi")]
		[Bindable(true)]
		public bool? AntFamTBCSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamTBCSi); }
			set { SetColumnValue(Columns.AntFamTBCSi, value); }
		}
		  
		[XmlAttribute("AntFamTBCNo")]
		[Bindable(true)]
		public bool? AntFamTBCNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamTBCNo); }
			set { SetColumnValue(Columns.AntFamTBCNo, value); }
		}
		  
		[XmlAttribute("AntFamDiabetesSi")]
		[Bindable(true)]
		public bool? AntFamDiabetesSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamDiabetesSi); }
			set { SetColumnValue(Columns.AntFamDiabetesSi, value); }
		}
		  
		[XmlAttribute("AntFamDiabetesNo")]
		[Bindable(true)]
		public bool? AntFamDiabetesNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamDiabetesNo); }
			set { SetColumnValue(Columns.AntFamDiabetesNo, value); }
		}
		  
		[XmlAttribute("AntFamHipertensionSi")]
		[Bindable(true)]
		public bool? AntFamHipertensionSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamHipertensionSi); }
			set { SetColumnValue(Columns.AntFamHipertensionSi, value); }
		}
		  
		[XmlAttribute("AntFamHipertensionNo")]
		[Bindable(true)]
		public bool? AntFamHipertensionNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamHipertensionNo); }
			set { SetColumnValue(Columns.AntFamHipertensionNo, value); }
		}
		  
		[XmlAttribute("AntFamInfeccionUrinariaSi")]
		[Bindable(true)]
		public bool? AntFamInfeccionUrinariaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamInfeccionUrinariaSi); }
			set { SetColumnValue(Columns.AntFamInfeccionUrinariaSi, value); }
		}
		  
		[XmlAttribute("AntFamInfeccionUrinariaNo")]
		[Bindable(true)]
		public bool? AntFamInfeccionUrinariaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamInfeccionUrinariaNo); }
			set { SetColumnValue(Columns.AntFamInfeccionUrinariaNo, value); }
		}
		  
		[XmlAttribute("AntFamOtrasInfeccionesSi")]
		[Bindable(true)]
		public bool? AntFamOtrasInfeccionesSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamOtrasInfeccionesSi); }
			set { SetColumnValue(Columns.AntFamOtrasInfeccionesSi, value); }
		}
		  
		[XmlAttribute("AntFamOtrasInfeccionesNo")]
		[Bindable(true)]
		public bool? AntFamOtrasInfeccionesNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamOtrasInfeccionesNo); }
			set { SetColumnValue(Columns.AntFamOtrasInfeccionesNo, value); }
		}
		  
		[XmlAttribute("AntFamOtroSi")]
		[Bindable(true)]
		public bool? AntFamOtroSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamOtroSi); }
			set { SetColumnValue(Columns.AntFamOtroSi, value); }
		}
		  
		[XmlAttribute("AntFamOtroNo")]
		[Bindable(true)]
		public bool? AntFamOtroNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntFamOtroNo); }
			set { SetColumnValue(Columns.AntFamOtroNo, value); }
		}
		  
		[XmlAttribute("AntPerTBCSi")]
		[Bindable(true)]
		public bool? AntPerTBCSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerTBCSi); }
			set { SetColumnValue(Columns.AntPerTBCSi, value); }
		}
		  
		[XmlAttribute("AntPerTBCNo")]
		[Bindable(true)]
		public bool? AntPerTBCNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerTBCNo); }
			set { SetColumnValue(Columns.AntPerTBCNo, value); }
		}
		  
		[XmlAttribute("AntPerDiabetesI")]
		[Bindable(true)]
		public bool? AntPerDiabetesI 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerDiabetesI); }
			set { SetColumnValue(Columns.AntPerDiabetesI, value); }
		}
		  
		[XmlAttribute("AntPerDiabetesII")]
		[Bindable(true)]
		public bool? AntPerDiabetesII 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerDiabetesII); }
			set { SetColumnValue(Columns.AntPerDiabetesII, value); }
		}
		  
		[XmlAttribute("AntPerDiabetesG")]
		[Bindable(true)]
		public bool? AntPerDiabetesG 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerDiabetesG); }
			set { SetColumnValue(Columns.AntPerDiabetesG, value); }
		}
		  
		[XmlAttribute("AntPerDiabetesNo")]
		[Bindable(true)]
		public bool? AntPerDiabetesNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerDiabetesNo); }
			set { SetColumnValue(Columns.AntPerDiabetesNo, value); }
		}
		  
		[XmlAttribute("AntPerHipertensionSi")]
		[Bindable(true)]
		public bool? AntPerHipertensionSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerHipertensionSi); }
			set { SetColumnValue(Columns.AntPerHipertensionSi, value); }
		}
		  
		[XmlAttribute("AntPerHipertensionNo")]
		[Bindable(true)]
		public bool? AntPerHipertensionNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerHipertensionNo); }
			set { SetColumnValue(Columns.AntPerHipertensionNo, value); }
		}
		  
		[XmlAttribute("AntPerInfeccionUrinariaSi")]
		[Bindable(true)]
		public bool? AntPerInfeccionUrinariaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerInfeccionUrinariaSi); }
			set { SetColumnValue(Columns.AntPerInfeccionUrinariaSi, value); }
		}
		  
		[XmlAttribute("AntPerInfeccionUrinariaNo")]
		[Bindable(true)]
		public bool? AntPerInfeccionUrinariaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerInfeccionUrinariaNo); }
			set { SetColumnValue(Columns.AntPerInfeccionUrinariaNo, value); }
		}
		  
		[XmlAttribute("AntPerOtrasInfeccionesSi")]
		[Bindable(true)]
		public bool? AntPerOtrasInfeccionesSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerOtrasInfeccionesSi); }
			set { SetColumnValue(Columns.AntPerOtrasInfeccionesSi, value); }
		}
		  
		[XmlAttribute("AntPerOtrasInfeccionesNo")]
		[Bindable(true)]
		public bool? AntPerOtrasInfeccionesNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerOtrasInfeccionesNo); }
			set { SetColumnValue(Columns.AntPerOtrasInfeccionesNo, value); }
		}
		  
		[XmlAttribute("AntPerOtroSi")]
		[Bindable(true)]
		public bool? AntPerOtroSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerOtroSi); }
			set { SetColumnValue(Columns.AntPerOtroSi, value); }
		}
		  
		[XmlAttribute("AntPerOtroNo")]
		[Bindable(true)]
		public bool? AntPerOtroNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerOtroNo); }
			set { SetColumnValue(Columns.AntPerOtroNo, value); }
		}
		  
		[XmlAttribute("AntPerInfertilidadSi")]
		[Bindable(true)]
		public bool? AntPerInfertilidadSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerInfertilidadSi); }
			set { SetColumnValue(Columns.AntPerInfertilidadSi, value); }
		}
		  
		[XmlAttribute("AntPerInfertilidadNo")]
		[Bindable(true)]
		public bool? AntPerInfertilidadNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerInfertilidadNo); }
			set { SetColumnValue(Columns.AntPerInfertilidadNo, value); }
		}
		  
		[XmlAttribute("AntPerCardiopatiaSi")]
		[Bindable(true)]
		public bool? AntPerCardiopatiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerCardiopatiaSi); }
			set { SetColumnValue(Columns.AntPerCardiopatiaSi, value); }
		}
		  
		[XmlAttribute("AntPerCardiopatiaNo")]
		[Bindable(true)]
		public bool? AntPerCardiopatiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerCardiopatiaNo); }
			set { SetColumnValue(Columns.AntPerCardiopatiaNo, value); }
		}
		  
		[XmlAttribute("AntPerNefropatiaSi")]
		[Bindable(true)]
		public bool? AntPerNefropatiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerNefropatiaSi); }
			set { SetColumnValue(Columns.AntPerNefropatiaSi, value); }
		}
		  
		[XmlAttribute("AntPerNefropatiaNo")]
		[Bindable(true)]
		public bool? AntPerNefropatiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerNefropatiaNo); }
			set { SetColumnValue(Columns.AntPerNefropatiaNo, value); }
		}
		  
		[XmlAttribute("AntPerViolenciaSi")]
		[Bindable(true)]
		public bool? AntPerViolenciaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerViolenciaSi); }
			set { SetColumnValue(Columns.AntPerViolenciaSi, value); }
		}
		  
		[XmlAttribute("AntPerViolenciaNo")]
		[Bindable(true)]
		public bool? AntPerViolenciaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerViolenciaNo); }
			set { SetColumnValue(Columns.AntPerViolenciaNo, value); }
		}
		  
		[XmlAttribute("AntPerAlergiaMedicamentoSi")]
		[Bindable(true)]
		public bool? AntPerAlergiaMedicamentoSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerAlergiaMedicamentoSi); }
			set { SetColumnValue(Columns.AntPerAlergiaMedicamentoSi, value); }
		}
		  
		[XmlAttribute("AntPerAlergiaMedicamentoNo")]
		[Bindable(true)]
		public bool? AntPerAlergiaMedicamentoNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntPerAlergiaMedicamentoNo); }
			set { SetColumnValue(Columns.AntPerAlergiaMedicamentoNo, value); }
		}
		  
		[XmlAttribute("AntecedentesObservacion")]
		[Bindable(true)]
		public string AntecedentesObservacion 
		{
			get { return GetColumnValue<string>(Columns.AntecedentesObservacion); }
			set { SetColumnValue(Columns.AntecedentesObservacion, value); }
		}
		  
		[XmlAttribute("GestasPrevias")]
		[Bindable(true)]
		public int? GestasPrevias 
		{
			get { return GetColumnValue<int?>(Columns.GestasPrevias); }
			set { SetColumnValue(Columns.GestasPrevias, value); }
		}
		  
		[XmlAttribute("Abortos")]
		[Bindable(true)]
		public int? Abortos 
		{
			get { return GetColumnValue<int?>(Columns.Abortos); }
			set { SetColumnValue(Columns.Abortos, value); }
		}
		  
		[XmlAttribute("EmbEctopicos")]
		[Bindable(true)]
		public int? EmbEctopicos 
		{
			get { return GetColumnValue<int?>(Columns.EmbEctopicos); }
			set { SetColumnValue(Columns.EmbEctopicos, value); }
		}
		  
		[XmlAttribute("Abortos3concecutivos")]
		[Bindable(true)]
		public bool? Abortos3concecutivos 
		{
			get { return GetColumnValue<bool?>(Columns.Abortos3concecutivos); }
			set { SetColumnValue(Columns.Abortos3concecutivos, value); }
		}
		  
		[XmlAttribute("Partos")]
		[Bindable(true)]
		public int? Partos 
		{
			get { return GetColumnValue<int?>(Columns.Partos); }
			set { SetColumnValue(Columns.Partos, value); }
		}
		  
		[XmlAttribute("PartosVaginales")]
		[Bindable(true)]
		public int? PartosVaginales 
		{
			get { return GetColumnValue<int?>(Columns.PartosVaginales); }
			set { SetColumnValue(Columns.PartosVaginales, value); }
		}
		  
		[XmlAttribute("Cesareas")]
		[Bindable(true)]
		public int? Cesareas 
		{
			get { return GetColumnValue<int?>(Columns.Cesareas); }
			set { SetColumnValue(Columns.Cesareas, value); }
		}
		  
		[XmlAttribute("NacidosVivos")]
		[Bindable(true)]
		public int? NacidosVivos 
		{
			get { return GetColumnValue<int?>(Columns.NacidosVivos); }
			set { SetColumnValue(Columns.NacidosVivos, value); }
		}
		  
		[XmlAttribute("NacidosMuertos")]
		[Bindable(true)]
		public int? NacidosMuertos 
		{
			get { return GetColumnValue<int?>(Columns.NacidosMuertos); }
			set { SetColumnValue(Columns.NacidosMuertos, value); }
		}
		  
		[XmlAttribute("Viven")]
		[Bindable(true)]
		public int? Viven 
		{
			get { return GetColumnValue<int?>(Columns.Viven); }
			set { SetColumnValue(Columns.Viven, value); }
		}
		  
		[XmlAttribute("MuertosPrimerSemana")]
		[Bindable(true)]
		public int? MuertosPrimerSemana 
		{
			get { return GetColumnValue<int?>(Columns.MuertosPrimerSemana); }
			set { SetColumnValue(Columns.MuertosPrimerSemana, value); }
		}
		  
		[XmlAttribute("MuertosDespuesPrimerSemana")]
		[Bindable(true)]
		public int? MuertosDespuesPrimerSemana 
		{
			get { return GetColumnValue<int?>(Columns.MuertosDespuesPrimerSemana); }
			set { SetColumnValue(Columns.MuertosDespuesPrimerSemana, value); }
		}
		  
		[XmlAttribute("AntecedentesGemelaresSi")]
		[Bindable(true)]
		public bool? AntecedentesGemelaresSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntecedentesGemelaresSi); }
			set { SetColumnValue(Columns.AntecedentesGemelaresSi, value); }
		}
		  
		[XmlAttribute("AntecedentesGemelaresNo")]
		[Bindable(true)]
		public bool? AntecedentesGemelaresNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntecedentesGemelaresNo); }
			set { SetColumnValue(Columns.AntecedentesGemelaresNo, value); }
		}
		  
		[XmlAttribute("UltPrevioNC")]
		[Bindable(true)]
		public bool? UltPrevioNC 
		{
			get { return GetColumnValue<bool?>(Columns.UltPrevioNC); }
			set { SetColumnValue(Columns.UltPrevioNC, value); }
		}
		  
		[XmlAttribute("UltPrevioNormal")]
		[Bindable(true)]
		public bool? UltPrevioNormal 
		{
			get { return GetColumnValue<bool?>(Columns.UltPrevioNormal); }
			set { SetColumnValue(Columns.UltPrevioNormal, value); }
		}
		  
		[XmlAttribute("UltPrevioMenor2500")]
		[Bindable(true)]
		public bool? UltPrevioMenor2500 
		{
			get { return GetColumnValue<bool?>(Columns.UltPrevioMenor2500); }
			set { SetColumnValue(Columns.UltPrevioMenor2500, value); }
		}
		  
		[XmlAttribute("UltPrevioMayor4000")]
		[Bindable(true)]
		public bool? UltPrevioMayor4000 
		{
			get { return GetColumnValue<bool?>(Columns.UltPrevioMayor4000); }
			set { SetColumnValue(Columns.UltPrevioMayor4000, value); }
		}
		  
		[XmlAttribute("FinEmbarazoAnterior")]
		[Bindable(true)]
		public DateTime? FinEmbarazoAnterior 
		{
			get { return GetColumnValue<DateTime?>(Columns.FinEmbarazoAnterior); }
			set { SetColumnValue(Columns.FinEmbarazoAnterior, value); }
		}
		  
		[XmlAttribute("FinEmbAnteriorMenor1Año")]
		[Bindable(true)]
		public bool? FinEmbAnteriorMenor1Año 
		{
			get { return GetColumnValue<bool?>(Columns.FinEmbAnteriorMenor1Año); }
			set { SetColumnValue(Columns.FinEmbAnteriorMenor1Año, value); }
		}
		  
		[XmlAttribute("EmbarazoPlaneadoSi")]
		[Bindable(true)]
		public bool? EmbarazoPlaneadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.EmbarazoPlaneadoSi); }
			set { SetColumnValue(Columns.EmbarazoPlaneadoSi, value); }
		}
		  
		[XmlAttribute("EmbarazoPlaneadoNo")]
		[Bindable(true)]
		public bool? EmbarazoPlaneadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.EmbarazoPlaneadoNo); }
			set { SetColumnValue(Columns.EmbarazoPlaneadoNo, value); }
		}
		  
		[XmlAttribute("FracMetAnticonceptivoNoUsaba")]
		[Bindable(true)]
		public bool? FracMetAnticonceptivoNoUsaba 
		{
			get { return GetColumnValue<bool?>(Columns.FracMetAnticonceptivoNoUsaba); }
			set { SetColumnValue(Columns.FracMetAnticonceptivoNoUsaba, value); }
		}
		  
		[XmlAttribute("FracMetAnticonceptivoBarrera")]
		[Bindable(true)]
		public bool? FracMetAnticonceptivoBarrera 
		{
			get { return GetColumnValue<bool?>(Columns.FracMetAnticonceptivoBarrera); }
			set { SetColumnValue(Columns.FracMetAnticonceptivoBarrera, value); }
		}
		  
		[XmlAttribute("FracMetAnticonceptivoDIU")]
		[Bindable(true)]
		public bool? FracMetAnticonceptivoDIU 
		{
			get { return GetColumnValue<bool?>(Columns.FracMetAnticonceptivoDIU); }
			set { SetColumnValue(Columns.FracMetAnticonceptivoDIU, value); }
		}
		  
		[XmlAttribute("FracMetAnticonceptivoHormonal")]
		[Bindable(true)]
		public bool? FracMetAnticonceptivoHormonal 
		{
			get { return GetColumnValue<bool?>(Columns.FracMetAnticonceptivoHormonal); }
			set { SetColumnValue(Columns.FracMetAnticonceptivoHormonal, value); }
		}
		  
		[XmlAttribute("FracMetAnticonceptivoEmergencia")]
		[Bindable(true)]
		public bool? FracMetAnticonceptivoEmergencia 
		{
			get { return GetColumnValue<bool?>(Columns.FracMetAnticonceptivoEmergencia); }
			set { SetColumnValue(Columns.FracMetAnticonceptivoEmergencia, value); }
		}
		  
		[XmlAttribute("FracMetAnticonceptivoNatural")]
		[Bindable(true)]
		public bool? FracMetAnticonceptivoNatural 
		{
			get { return GetColumnValue<bool?>(Columns.FracMetAnticonceptivoNatural); }
			set { SetColumnValue(Columns.FracMetAnticonceptivoNatural, value); }
		}
		  
		[XmlAttribute("PesoAnterior")]
		[Bindable(true)]
		public decimal? PesoAnterior 
		{
			get { return GetColumnValue<decimal?>(Columns.PesoAnterior); }
			set { SetColumnValue(Columns.PesoAnterior, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public int? Talla 
		{
			get { return GetColumnValue<int?>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("Fum")]
		[Bindable(true)]
		public DateTime? Fum 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fum); }
			set { SetColumnValue(Columns.Fum, value); }
		}
		  
		[XmlAttribute("Fpp")]
		[Bindable(true)]
		public DateTime? Fpp 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fpp); }
			set { SetColumnValue(Columns.Fpp, value); }
		}
		  
		[XmlAttribute("EGConfiableFUMSi")]
		[Bindable(true)]
		public bool? EGConfiableFUMSi 
		{
			get { return GetColumnValue<bool?>(Columns.EGConfiableFUMSi); }
			set { SetColumnValue(Columns.EGConfiableFUMSi, value); }
		}
		  
		[XmlAttribute("EGConfiableFUMNo")]
		[Bindable(true)]
		public bool? EGConfiableFUMNo 
		{
			get { return GetColumnValue<bool?>(Columns.EGConfiableFUMNo); }
			set { SetColumnValue(Columns.EGConfiableFUMNo, value); }
		}
		  
		[XmlAttribute("EGConfiableEcoMenor20semanasSi")]
		[Bindable(true)]
		public bool? EGConfiableEcoMenor20semanasSi 
		{
			get { return GetColumnValue<bool?>(Columns.EGConfiableEcoMenor20semanasSi); }
			set { SetColumnValue(Columns.EGConfiableEcoMenor20semanasSi, value); }
		}
		  
		[XmlAttribute("EGConfiableEcoMenor20semanasNo")]
		[Bindable(true)]
		public bool? EGConfiableEcoMenor20semanasNo 
		{
			get { return GetColumnValue<bool?>(Columns.EGConfiableEcoMenor20semanasNo); }
			set { SetColumnValue(Columns.EGConfiableEcoMenor20semanasNo, value); }
		}
		  
		[XmlAttribute("FumaActivo1TrimSi")]
		[Bindable(true)]
		public bool? FumaActivo1TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.FumaActivo1TrimSi); }
			set { SetColumnValue(Columns.FumaActivo1TrimSi, value); }
		}
		  
		[XmlAttribute("FumaActivo1TrimNo")]
		[Bindable(true)]
		public bool? FumaActivo1TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.FumaActivo1TrimNo); }
			set { SetColumnValue(Columns.FumaActivo1TrimNo, value); }
		}
		  
		[XmlAttribute("FumaActivo2TrimSi")]
		[Bindable(true)]
		public bool? FumaActivo2TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.FumaActivo2TrimSi); }
			set { SetColumnValue(Columns.FumaActivo2TrimSi, value); }
		}
		  
		[XmlAttribute("FumaActivo2TrimNo")]
		[Bindable(true)]
		public bool? FumaActivo2TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.FumaActivo2TrimNo); }
			set { SetColumnValue(Columns.FumaActivo2TrimNo, value); }
		}
		  
		[XmlAttribute("FumaActivo3TrimSi")]
		[Bindable(true)]
		public bool? FumaActivo3TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.FumaActivo3TrimSi); }
			set { SetColumnValue(Columns.FumaActivo3TrimSi, value); }
		}
		  
		[XmlAttribute("FumaActivo3TrimNo")]
		[Bindable(true)]
		public bool? FumaActivo3TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.FumaActivo3TrimNo); }
			set { SetColumnValue(Columns.FumaActivo3TrimNo, value); }
		}
		  
		[XmlAttribute("FumaPasivo1TrimSi")]
		[Bindable(true)]
		public bool? FumaPasivo1TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.FumaPasivo1TrimSi); }
			set { SetColumnValue(Columns.FumaPasivo1TrimSi, value); }
		}
		  
		[XmlAttribute("FumaPasivo1TrimNo")]
		[Bindable(true)]
		public bool? FumaPasivo1TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.FumaPasivo1TrimNo); }
			set { SetColumnValue(Columns.FumaPasivo1TrimNo, value); }
		}
		  
		[XmlAttribute("FumaPasivo2TrimSi")]
		[Bindable(true)]
		public bool? FumaPasivo2TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.FumaPasivo2TrimSi); }
			set { SetColumnValue(Columns.FumaPasivo2TrimSi, value); }
		}
		  
		[XmlAttribute("FumaPasivo2TrimNo")]
		[Bindable(true)]
		public bool? FumaPasivo2TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.FumaPasivo2TrimNo); }
			set { SetColumnValue(Columns.FumaPasivo2TrimNo, value); }
		}
		  
		[XmlAttribute("FumaPasivo3TrimSi")]
		[Bindable(true)]
		public bool? FumaPasivo3TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.FumaPasivo3TrimSi); }
			set { SetColumnValue(Columns.FumaPasivo3TrimSi, value); }
		}
		  
		[XmlAttribute("FumaPasivo3TrimNo")]
		[Bindable(true)]
		public bool? FumaPasivo3TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.FumaPasivo3TrimNo); }
			set { SetColumnValue(Columns.FumaPasivo3TrimNo, value); }
		}
		  
		[XmlAttribute("Drogas1TrimSi")]
		[Bindable(true)]
		public bool? Drogas1TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Drogas1TrimSi); }
			set { SetColumnValue(Columns.Drogas1TrimSi, value); }
		}
		  
		[XmlAttribute("Drogas1TrimNo")]
		[Bindable(true)]
		public bool? Drogas1TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Drogas1TrimNo); }
			set { SetColumnValue(Columns.Drogas1TrimNo, value); }
		}
		  
		[XmlAttribute("Drogas2TrimSi")]
		[Bindable(true)]
		public bool? Drogas2TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Drogas2TrimSi); }
			set { SetColumnValue(Columns.Drogas2TrimSi, value); }
		}
		  
		[XmlAttribute("Drogas2TrimNo")]
		[Bindable(true)]
		public bool? Drogas2TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Drogas2TrimNo); }
			set { SetColumnValue(Columns.Drogas2TrimNo, value); }
		}
		  
		[XmlAttribute("Drogas3TrimSi")]
		[Bindable(true)]
		public bool? Drogas3TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Drogas3TrimSi); }
			set { SetColumnValue(Columns.Drogas3TrimSi, value); }
		}
		  
		[XmlAttribute("Drogas3TrimNo")]
		[Bindable(true)]
		public bool? Drogas3TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Drogas3TrimNo); }
			set { SetColumnValue(Columns.Drogas3TrimNo, value); }
		}
		  
		[XmlAttribute("Alcohol1TrimSi")]
		[Bindable(true)]
		public bool? Alcohol1TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Alcohol1TrimSi); }
			set { SetColumnValue(Columns.Alcohol1TrimSi, value); }
		}
		  
		[XmlAttribute("Alcohol1TrimNo")]
		[Bindable(true)]
		public bool? Alcohol1TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Alcohol1TrimNo); }
			set { SetColumnValue(Columns.Alcohol1TrimNo, value); }
		}
		  
		[XmlAttribute("Alcohol2TrimSi")]
		[Bindable(true)]
		public bool? Alcohol2TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Alcohol2TrimSi); }
			set { SetColumnValue(Columns.Alcohol2TrimSi, value); }
		}
		  
		[XmlAttribute("Alcohol2TrimNo")]
		[Bindable(true)]
		public bool? Alcohol2TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Alcohol2TrimNo); }
			set { SetColumnValue(Columns.Alcohol2TrimNo, value); }
		}
		  
		[XmlAttribute("Alcohol3TrimSi")]
		[Bindable(true)]
		public bool? Alcohol3TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Alcohol3TrimSi); }
			set { SetColumnValue(Columns.Alcohol3TrimSi, value); }
		}
		  
		[XmlAttribute("Alcohol3TrimNo")]
		[Bindable(true)]
		public bool? Alcohol3TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Alcohol3TrimNo); }
			set { SetColumnValue(Columns.Alcohol3TrimNo, value); }
		}
		  
		[XmlAttribute("Violencia1TrimSi")]
		[Bindable(true)]
		public bool? Violencia1TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Violencia1TrimSi); }
			set { SetColumnValue(Columns.Violencia1TrimSi, value); }
		}
		  
		[XmlAttribute("Violencia1TrimNo")]
		[Bindable(true)]
		public bool? Violencia1TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Violencia1TrimNo); }
			set { SetColumnValue(Columns.Violencia1TrimNo, value); }
		}
		  
		[XmlAttribute("Violencia2TrimSi")]
		[Bindable(true)]
		public bool? Violencia2TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Violencia2TrimSi); }
			set { SetColumnValue(Columns.Violencia2TrimSi, value); }
		}
		  
		[XmlAttribute("Violencia2TrimNo")]
		[Bindable(true)]
		public bool? Violencia2TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Violencia2TrimNo); }
			set { SetColumnValue(Columns.Violencia2TrimNo, value); }
		}
		  
		[XmlAttribute("Violencia3TrimSi")]
		[Bindable(true)]
		public bool? Violencia3TrimSi 
		{
			get { return GetColumnValue<bool?>(Columns.Violencia3TrimSi); }
			set { SetColumnValue(Columns.Violencia3TrimSi, value); }
		}
		  
		[XmlAttribute("Violencia3TrimNo")]
		[Bindable(true)]
		public bool? Violencia3TrimNo 
		{
			get { return GetColumnValue<bool?>(Columns.Violencia3TrimNo); }
			set { SetColumnValue(Columns.Violencia3TrimNo, value); }
		}
		  
		[XmlAttribute("AntirubeolaPrevia")]
		[Bindable(true)]
		public bool? AntirubeolaPrevia 
		{
			get { return GetColumnValue<bool?>(Columns.AntirubeolaPrevia); }
			set { SetColumnValue(Columns.AntirubeolaPrevia, value); }
		}
		  
		[XmlAttribute("AntirubeolaNoSabe")]
		[Bindable(true)]
		public bool? AntirubeolaNoSabe 
		{
			get { return GetColumnValue<bool?>(Columns.AntirubeolaNoSabe); }
			set { SetColumnValue(Columns.AntirubeolaNoSabe, value); }
		}
		  
		[XmlAttribute("AntirubeolaEmbarazo")]
		[Bindable(true)]
		public bool? AntirubeolaEmbarazo 
		{
			get { return GetColumnValue<bool?>(Columns.AntirubeolaEmbarazo); }
			set { SetColumnValue(Columns.AntirubeolaEmbarazo, value); }
		}
		  
		[XmlAttribute("AntirubeolaNo")]
		[Bindable(true)]
		public bool? AntirubeolaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntirubeolaNo); }
			set { SetColumnValue(Columns.AntirubeolaNo, value); }
		}
		  
		[XmlAttribute("AntitetanicaVigenteNo")]
		[Bindable(true)]
		public bool? AntitetanicaVigenteNo 
		{
			get { return GetColumnValue<bool?>(Columns.AntitetanicaVigenteNo); }
			set { SetColumnValue(Columns.AntitetanicaVigenteNo, value); }
		}
		  
		[XmlAttribute("AntitetanicaVigenteSi")]
		[Bindable(true)]
		public bool? AntitetanicaVigenteSi 
		{
			get { return GetColumnValue<bool?>(Columns.AntitetanicaVigenteSi); }
			set { SetColumnValue(Columns.AntitetanicaVigenteSi, value); }
		}
		  
		[XmlAttribute("Antitetanica1DosisMesGestacion")]
		[Bindable(true)]
		public int? Antitetanica1DosisMesGestacion 
		{
			get { return GetColumnValue<int?>(Columns.Antitetanica1DosisMesGestacion); }
			set { SetColumnValue(Columns.Antitetanica1DosisMesGestacion, value); }
		}
		  
		[XmlAttribute("Antitetanica2DosisMesGestacion")]
		[Bindable(true)]
		public int? Antitetanica2DosisMesGestacion 
		{
			get { return GetColumnValue<int?>(Columns.Antitetanica2DosisMesGestacion); }
			set { SetColumnValue(Columns.Antitetanica2DosisMesGestacion, value); }
		}
		  
		[XmlAttribute("ExamenOdotologicoNormalSi")]
		[Bindable(true)]
		public bool? ExamenOdotologicoNormalSi 
		{
			get { return GetColumnValue<bool?>(Columns.ExamenOdotologicoNormalSi); }
			set { SetColumnValue(Columns.ExamenOdotologicoNormalSi, value); }
		}
		  
		[XmlAttribute("ExamenOdotologicoNormalNo")]
		[Bindable(true)]
		public bool? ExamenOdotologicoNormalNo 
		{
			get { return GetColumnValue<bool?>(Columns.ExamenOdotologicoNormalNo); }
			set { SetColumnValue(Columns.ExamenOdotologicoNormalNo, value); }
		}
		  
		[XmlAttribute("ExamenMamasNormalSi")]
		[Bindable(true)]
		public bool? ExamenMamasNormalSi 
		{
			get { return GetColumnValue<bool?>(Columns.ExamenMamasNormalSi); }
			set { SetColumnValue(Columns.ExamenMamasNormalSi, value); }
		}
		  
		[XmlAttribute("ExamenMamasNormalNo")]
		[Bindable(true)]
		public bool? ExamenMamasNormalNo 
		{
			get { return GetColumnValue<bool?>(Columns.ExamenMamasNormalNo); }
			set { SetColumnValue(Columns.ExamenMamasNormalNo, value); }
		}
		  
		[XmlAttribute("CervixInspeccionVisualNormal")]
		[Bindable(true)]
		public bool? CervixInspeccionVisualNormal 
		{
			get { return GetColumnValue<bool?>(Columns.CervixInspeccionVisualNormal); }
			set { SetColumnValue(Columns.CervixInspeccionVisualNormal, value); }
		}
		  
		[XmlAttribute("CervixInspeccionVisualAnormal")]
		[Bindable(true)]
		public bool? CervixInspeccionVisualAnormal 
		{
			get { return GetColumnValue<bool?>(Columns.CervixInspeccionVisualAnormal); }
			set { SetColumnValue(Columns.CervixInspeccionVisualAnormal, value); }
		}
		  
		[XmlAttribute("CervixInspeccionVisualNoSeHizo")]
		[Bindable(true)]
		public bool? CervixInspeccionVisualNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.CervixInspeccionVisualNoSeHizo); }
			set { SetColumnValue(Columns.CervixInspeccionVisualNoSeHizo, value); }
		}
		  
		[XmlAttribute("CervixPAPNormal")]
		[Bindable(true)]
		public bool? CervixPAPNormal 
		{
			get { return GetColumnValue<bool?>(Columns.CervixPAPNormal); }
			set { SetColumnValue(Columns.CervixPAPNormal, value); }
		}
		  
		[XmlAttribute("CervixPAPAnormal")]
		[Bindable(true)]
		public bool? CervixPAPAnormal 
		{
			get { return GetColumnValue<bool?>(Columns.CervixPAPAnormal); }
			set { SetColumnValue(Columns.CervixPAPAnormal, value); }
		}
		  
		[XmlAttribute("CervixPAPNoSeHizo")]
		[Bindable(true)]
		public bool? CervixPAPNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.CervixPAPNoSeHizo); }
			set { SetColumnValue(Columns.CervixPAPNoSeHizo, value); }
		}
		  
		[XmlAttribute("CervixCOLPNormal")]
		[Bindable(true)]
		public bool? CervixCOLPNormal 
		{
			get { return GetColumnValue<bool?>(Columns.CervixCOLPNormal); }
			set { SetColumnValue(Columns.CervixCOLPNormal, value); }
		}
		  
		[XmlAttribute("CervixCOLPAnormal")]
		[Bindable(true)]
		public bool? CervixCOLPAnormal 
		{
			get { return GetColumnValue<bool?>(Columns.CervixCOLPAnormal); }
			set { SetColumnValue(Columns.CervixCOLPAnormal, value); }
		}
		  
		[XmlAttribute("CervixCOLPNoSeHizo")]
		[Bindable(true)]
		public bool? CervixCOLPNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.CervixCOLPNoSeHizo); }
			set { SetColumnValue(Columns.CervixCOLPNoSeHizo, value); }
		}
		  
		[XmlAttribute("Grupo")]
		[Bindable(true)]
		public string Grupo 
		{
			get { return GetColumnValue<string>(Columns.Grupo); }
			set { SetColumnValue(Columns.Grupo, value); }
		}
		  
		[XmlAttribute("RHPositivo")]
		[Bindable(true)]
		public bool? RHPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.RHPositivo); }
			set { SetColumnValue(Columns.RHPositivo, value); }
		}
		  
		[XmlAttribute("RHNegativo")]
		[Bindable(true)]
		public bool? RHNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.RHNegativo); }
			set { SetColumnValue(Columns.RHNegativo, value); }
		}
		  
		[XmlAttribute("InmunizacionSi")]
		[Bindable(true)]
		public bool? InmunizacionSi 
		{
			get { return GetColumnValue<bool?>(Columns.InmunizacionSi); }
			set { SetColumnValue(Columns.InmunizacionSi, value); }
		}
		  
		[XmlAttribute("InmunizacionNo")]
		[Bindable(true)]
		public bool? InmunizacionNo 
		{
			get { return GetColumnValue<bool?>(Columns.InmunizacionNo); }
			set { SetColumnValue(Columns.InmunizacionNo, value); }
		}
		  
		[XmlAttribute("GammaGlobulinaNo")]
		[Bindable(true)]
		public bool? GammaGlobulinaNo 
		{
			get { return GetColumnValue<bool?>(Columns.GammaGlobulinaNo); }
			set { SetColumnValue(Columns.GammaGlobulinaNo, value); }
		}
		  
		[XmlAttribute("GammaGlobulinaSi")]
		[Bindable(true)]
		public bool? GammaGlobulinaSi 
		{
			get { return GetColumnValue<bool?>(Columns.GammaGlobulinaSi); }
			set { SetColumnValue(Columns.GammaGlobulinaSi, value); }
		}
		  
		[XmlAttribute("GammaGlobulinaNoCorresponde")]
		[Bindable(true)]
		public bool? GammaGlobulinaNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.GammaGlobulinaNoCorresponde); }
			set { SetColumnValue(Columns.GammaGlobulinaNoCorresponde, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosisMenor20SemLGGNegativo")]
		[Bindable(true)]
		public bool? ToxoPlasmosisMenor20SemLGGNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosisMenor20SemLGGNegativo); }
			set { SetColumnValue(Columns.ToxoPlasmosisMenor20SemLGGNegativo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosisMenor20SemLGGPositivo")]
		[Bindable(true)]
		public bool? ToxoPlasmosisMenor20SemLGGPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosisMenor20SemLGGPositivo); }
			set { SetColumnValue(Columns.ToxoPlasmosisMenor20SemLGGPositivo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosisMenor20SemLGGNoSeHizo")]
		[Bindable(true)]
		public bool? ToxoPlasmosisMenor20SemLGGNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosisMenor20SemLGGNoSeHizo); }
			set { SetColumnValue(Columns.ToxoPlasmosisMenor20SemLGGNoSeHizo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosisMayor20SemLGGNegativo")]
		[Bindable(true)]
		public bool? ToxoPlasmosisMayor20SemLGGNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosisMayor20SemLGGNegativo); }
			set { SetColumnValue(Columns.ToxoPlasmosisMayor20SemLGGNegativo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosisMayor20SemLGGPositivo")]
		[Bindable(true)]
		public bool? ToxoPlasmosisMayor20SemLGGPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosisMayor20SemLGGPositivo); }
			set { SetColumnValue(Columns.ToxoPlasmosisMayor20SemLGGPositivo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosisMayor20SemLGGNoSeHizo")]
		[Bindable(true)]
		public bool? ToxoPlasmosisMayor20SemLGGNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosisMayor20SemLGGNoSeHizo); }
			set { SetColumnValue(Columns.ToxoPlasmosisMayor20SemLGGNoSeHizo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosis1ConsultaLGMNegativo")]
		[Bindable(true)]
		public bool? ToxoPlasmosis1ConsultaLGMNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosis1ConsultaLGMNegativo); }
			set { SetColumnValue(Columns.ToxoPlasmosis1ConsultaLGMNegativo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosis1ConsultaLGMPositivo")]
		[Bindable(true)]
		public bool? ToxoPlasmosis1ConsultaLGMPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosis1ConsultaLGMPositivo); }
			set { SetColumnValue(Columns.ToxoPlasmosis1ConsultaLGMPositivo, value); }
		}
		  
		[XmlAttribute("ToxoPlasmosis1ConsultaLGMNoSeHizo")]
		[Bindable(true)]
		public bool? ToxoPlasmosis1ConsultaLGMNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.ToxoPlasmosis1ConsultaLGMNoSeHizo); }
			set { SetColumnValue(Columns.ToxoPlasmosis1ConsultaLGMNoSeHizo, value); }
		}
		  
		[XmlAttribute("ChagasNegativo")]
		[Bindable(true)]
		public bool? ChagasNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.ChagasNegativo); }
			set { SetColumnValue(Columns.ChagasNegativo, value); }
		}
		  
		[XmlAttribute("ChagasPositivo")]
		[Bindable(true)]
		public bool? ChagasPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.ChagasPositivo); }
			set { SetColumnValue(Columns.ChagasPositivo, value); }
		}
		  
		[XmlAttribute("ChagasNoSeHizo")]
		[Bindable(true)]
		public bool? ChagasNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.ChagasNoSeHizo); }
			set { SetColumnValue(Columns.ChagasNoSeHizo, value); }
		}
		  
		[XmlAttribute("HepatitisBNegativo")]
		[Bindable(true)]
		public bool? HepatitisBNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.HepatitisBNegativo); }
			set { SetColumnValue(Columns.HepatitisBNegativo, value); }
		}
		  
		[XmlAttribute("HepatitisBPositivo")]
		[Bindable(true)]
		public bool? HepatitisBPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.HepatitisBPositivo); }
			set { SetColumnValue(Columns.HepatitisBPositivo, value); }
		}
		  
		[XmlAttribute("HepatitisBNoSeHizo")]
		[Bindable(true)]
		public bool? HepatitisBNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.HepatitisBNoSeHizo); }
			set { SetColumnValue(Columns.HepatitisBNoSeHizo, value); }
		}
		  
		[XmlAttribute("BacteriuraMenor20SemNormal")]
		[Bindable(true)]
		public bool? BacteriuraMenor20SemNormal 
		{
			get { return GetColumnValue<bool?>(Columns.BacteriuraMenor20SemNormal); }
			set { SetColumnValue(Columns.BacteriuraMenor20SemNormal, value); }
		}
		  
		[XmlAttribute("BacteriuraMenor20SemAnormal")]
		[Bindable(true)]
		public bool? BacteriuraMenor20SemAnormal 
		{
			get { return GetColumnValue<bool?>(Columns.BacteriuraMenor20SemAnormal); }
			set { SetColumnValue(Columns.BacteriuraMenor20SemAnormal, value); }
		}
		  
		[XmlAttribute("BacteriuraMenor20SemNoSeHizo")]
		[Bindable(true)]
		public bool? BacteriuraMenor20SemNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.BacteriuraMenor20SemNoSeHizo); }
			set { SetColumnValue(Columns.BacteriuraMenor20SemNoSeHizo, value); }
		}
		  
		[XmlAttribute("BacteriuraMayor20SemNormal")]
		[Bindable(true)]
		public bool? BacteriuraMayor20SemNormal 
		{
			get { return GetColumnValue<bool?>(Columns.BacteriuraMayor20SemNormal); }
			set { SetColumnValue(Columns.BacteriuraMayor20SemNormal, value); }
		}
		  
		[XmlAttribute("BacteriuraMayor20SemAnormal")]
		[Bindable(true)]
		public bool? BacteriuraMayor20SemAnormal 
		{
			get { return GetColumnValue<bool?>(Columns.BacteriuraMayor20SemAnormal); }
			set { SetColumnValue(Columns.BacteriuraMayor20SemAnormal, value); }
		}
		  
		[XmlAttribute("BacteriuraMayor20SemNoSeHizo")]
		[Bindable(true)]
		public bool? BacteriuraMayor20SemNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.BacteriuraMayor20SemNoSeHizo); }
			set { SetColumnValue(Columns.BacteriuraMayor20SemNoSeHizo, value); }
		}
		  
		[XmlAttribute("GlucemiaMenor20Sem")]
		[Bindable(true)]
		public decimal? GlucemiaMenor20Sem 
		{
			get { return GetColumnValue<decimal?>(Columns.GlucemiaMenor20Sem); }
			set { SetColumnValue(Columns.GlucemiaMenor20Sem, value); }
		}
		  
		[XmlAttribute("GlucemiaMenor20SemMayor105")]
		[Bindable(true)]
		public bool? GlucemiaMenor20SemMayor105 
		{
			get { return GetColumnValue<bool?>(Columns.GlucemiaMenor20SemMayor105); }
			set { SetColumnValue(Columns.GlucemiaMenor20SemMayor105, value); }
		}
		  
		[XmlAttribute("GlucemiaMayor20Sem")]
		[Bindable(true)]
		public decimal? GlucemiaMayor20Sem 
		{
			get { return GetColumnValue<decimal?>(Columns.GlucemiaMayor20Sem); }
			set { SetColumnValue(Columns.GlucemiaMayor20Sem, value); }
		}
		  
		[XmlAttribute("GlucemiaMayor20SemMayor105")]
		[Bindable(true)]
		public bool? GlucemiaMayor20SemMayor105 
		{
			get { return GetColumnValue<bool?>(Columns.GlucemiaMayor20SemMayor105); }
			set { SetColumnValue(Columns.GlucemiaMayor20SemMayor105, value); }
		}
		  
		[XmlAttribute("VIHCRSi")]
		[Bindable(true)]
		public bool? VIHCRSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHCRSi); }
			set { SetColumnValue(Columns.VIHCRSi, value); }
		}
		  
		[XmlAttribute("VIHCRNo")]
		[Bindable(true)]
		public bool? VIHCRNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHCRNo); }
			set { SetColumnValue(Columns.VIHCRNo, value); }
		}
		  
		[XmlAttribute("VIHPrimerMuestraSolicitadoSi")]
		[Bindable(true)]
		public bool? VIHPrimerMuestraSolicitadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHPrimerMuestraSolicitadoSi); }
			set { SetColumnValue(Columns.VIHPrimerMuestraSolicitadoSi, value); }
		}
		  
		[XmlAttribute("VIHPrimerMuestraSolicitadoNo")]
		[Bindable(true)]
		public bool? VIHPrimerMuestraSolicitadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHPrimerMuestraSolicitadoNo); }
			set { SetColumnValue(Columns.VIHPrimerMuestraSolicitadoNo, value); }
		}
		  
		[XmlAttribute("VIHPrimerMuestraRealizadoSi")]
		[Bindable(true)]
		public bool? VIHPrimerMuestraRealizadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHPrimerMuestraRealizadoSi); }
			set { SetColumnValue(Columns.VIHPrimerMuestraRealizadoSi, value); }
		}
		  
		[XmlAttribute("VIHPrimerMuestraRealizadoNo")]
		[Bindable(true)]
		public bool? VIHPrimerMuestraRealizadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHPrimerMuestraRealizadoNo); }
			set { SetColumnValue(Columns.VIHPrimerMuestraRealizadoNo, value); }
		}
		  
		[XmlAttribute("VIHPrimerMuestraFecha")]
		[Bindable(true)]
		public DateTime? VIHPrimerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.VIHPrimerMuestraFecha); }
			set { SetColumnValue(Columns.VIHPrimerMuestraFecha, value); }
		}
		  
		[XmlAttribute("HBMenor20Sem")]
		[Bindable(true)]
		public decimal? HBMenor20Sem 
		{
			get { return GetColumnValue<decimal?>(Columns.HBMenor20Sem); }
			set { SetColumnValue(Columns.HBMenor20Sem, value); }
		}
		  
		[XmlAttribute("HBMenor20SemMenor11")]
		[Bindable(true)]
		public bool? HBMenor20SemMenor11 
		{
			get { return GetColumnValue<bool?>(Columns.HBMenor20SemMenor11); }
			set { SetColumnValue(Columns.HBMenor20SemMenor11, value); }
		}
		  
		[XmlAttribute("HBMayor20Sem")]
		[Bindable(true)]
		public decimal? HBMayor20Sem 
		{
			get { return GetColumnValue<decimal?>(Columns.HBMayor20Sem); }
			set { SetColumnValue(Columns.HBMayor20Sem, value); }
		}
		  
		[XmlAttribute("HBMayor20SemMenor11")]
		[Bindable(true)]
		public bool? HBMayor20SemMenor11 
		{
			get { return GetColumnValue<bool?>(Columns.HBMayor20SemMenor11); }
			set { SetColumnValue(Columns.HBMayor20SemMenor11, value); }
		}
		  
		[XmlAttribute("FeIndicadoSi")]
		[Bindable(true)]
		public bool? FeIndicadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.FeIndicadoSi); }
			set { SetColumnValue(Columns.FeIndicadoSi, value); }
		}
		  
		[XmlAttribute("FeIndicadoNo")]
		[Bindable(true)]
		public bool? FeIndicadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.FeIndicadoNo); }
			set { SetColumnValue(Columns.FeIndicadoNo, value); }
		}
		  
		[XmlAttribute("FolatosIndicadosSi")]
		[Bindable(true)]
		public bool? FolatosIndicadosSi 
		{
			get { return GetColumnValue<bool?>(Columns.FolatosIndicadosSi); }
			set { SetColumnValue(Columns.FolatosIndicadosSi, value); }
		}
		  
		[XmlAttribute("FolatosIndicadosNo")]
		[Bindable(true)]
		public bool? FolatosIndicadosNo 
		{
			get { return GetColumnValue<bool?>(Columns.FolatosIndicadosNo); }
			set { SetColumnValue(Columns.FolatosIndicadosNo, value); }
		}
		  
		[XmlAttribute("EstreptococoB3537SemanasNegativo")]
		[Bindable(true)]
		public bool? EstreptococoB3537SemanasNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.EstreptococoB3537SemanasNegativo); }
			set { SetColumnValue(Columns.EstreptococoB3537SemanasNegativo, value); }
		}
		  
		[XmlAttribute("EstreptococoB3537SemanasPositivo")]
		[Bindable(true)]
		public bool? EstreptococoB3537SemanasPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.EstreptococoB3537SemanasPositivo); }
			set { SetColumnValue(Columns.EstreptococoB3537SemanasPositivo, value); }
		}
		  
		[XmlAttribute("EstreptococoB3537SemanasNoSeHizo")]
		[Bindable(true)]
		public bool? EstreptococoB3537SemanasNoSeHizo 
		{
			get { return GetColumnValue<bool?>(Columns.EstreptococoB3537SemanasNoSeHizo); }
			set { SetColumnValue(Columns.EstreptococoB3537SemanasNoSeHizo, value); }
		}
		  
		[XmlAttribute("PreparacionPartoSi")]
		[Bindable(true)]
		public bool? PreparacionPartoSi 
		{
			get { return GetColumnValue<bool?>(Columns.PreparacionPartoSi); }
			set { SetColumnValue(Columns.PreparacionPartoSi, value); }
		}
		  
		[XmlAttribute("PreparacionPartoNo")]
		[Bindable(true)]
		public bool? PreparacionPartoNo 
		{
			get { return GetColumnValue<bool?>(Columns.PreparacionPartoNo); }
			set { SetColumnValue(Columns.PreparacionPartoNo, value); }
		}
		  
		[XmlAttribute("ConsejeriaLactanciaMaternaSi")]
		[Bindable(true)]
		public bool? ConsejeriaLactanciaMaternaSi 
		{
			get { return GetColumnValue<bool?>(Columns.ConsejeriaLactanciaMaternaSi); }
			set { SetColumnValue(Columns.ConsejeriaLactanciaMaternaSi, value); }
		}
		  
		[XmlAttribute("ConsejeriaLactanciaMaternaNo")]
		[Bindable(true)]
		public bool? ConsejeriaLactanciaMaternaNo 
		{
			get { return GetColumnValue<bool?>(Columns.ConsejeriaLactanciaMaternaNo); }
			set { SetColumnValue(Columns.ConsejeriaLactanciaMaternaNo, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMenor20SemNo")]
		[Bindable(true)]
		public bool? SifilisTratParejaMenor20SemNo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMenor20SemNo); }
			set { SetColumnValue(Columns.SifilisTratParejaMenor20SemNo, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMenor20SemSi")]
		[Bindable(true)]
		public bool? SifilisTratParejaMenor20SemSi 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMenor20SemSi); }
			set { SetColumnValue(Columns.SifilisTratParejaMenor20SemSi, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMenor20SemSinDatos")]
		[Bindable(true)]
		public bool? SifilisTratParejaMenor20SemSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMenor20SemSinDatos); }
			set { SetColumnValue(Columns.SifilisTratParejaMenor20SemSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMenor20SemNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisTratParejaMenor20SemNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMenor20SemNoCorresponde); }
			set { SetColumnValue(Columns.SifilisTratParejaMenor20SemNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMayor20SemNo")]
		[Bindable(true)]
		public bool? SifilisTratParejaMayor20SemNo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMayor20SemNo); }
			set { SetColumnValue(Columns.SifilisTratParejaMayor20SemNo, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMayor20SemSi")]
		[Bindable(true)]
		public bool? SifilisTratParejaMayor20SemSi 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMayor20SemSi); }
			set { SetColumnValue(Columns.SifilisTratParejaMayor20SemSi, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMayor20SemSinDatos")]
		[Bindable(true)]
		public bool? SifilisTratParejaMayor20SemSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMayor20SemSinDatos); }
			set { SetColumnValue(Columns.SifilisTratParejaMayor20SemSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisTratParejaMayor20SemNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisTratParejaMayor20SemNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratParejaMayor20SemNoCorresponde); }
			set { SetColumnValue(Columns.SifilisTratParejaMayor20SemNoCorresponde, value); }
		}
		  
		[XmlAttribute("OAAntecedenteEclampsiaSi")]
		[Bindable(true)]
		public bool? OAAntecedenteEclampsiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteEclampsiaSi); }
			set { SetColumnValue(Columns.OAAntecedenteEclampsiaSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteEclampsiaNo")]
		[Bindable(true)]
		public bool? OAAntecedenteEclampsiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteEclampsiaNo); }
			set { SetColumnValue(Columns.OAAntecedenteEclampsiaNo, value); }
		}
		  
		[XmlAttribute("OAActualEclampsiaSi")]
		[Bindable(true)]
		public bool? OAActualEclampsiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualEclampsiaSi); }
			set { SetColumnValue(Columns.OAActualEclampsiaSi, value); }
		}
		  
		[XmlAttribute("OAActualEclampsiaNo")]
		[Bindable(true)]
		public bool? OAActualEclampsiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualEclampsiaNo); }
			set { SetColumnValue(Columns.OAActualEclampsiaNo, value); }
		}
		  
		[XmlAttribute("OAAntecedentePreeclampsiaSi")]
		[Bindable(true)]
		public bool? OAAntecedentePreeclampsiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedentePreeclampsiaSi); }
			set { SetColumnValue(Columns.OAAntecedentePreeclampsiaSi, value); }
		}
		  
		[XmlAttribute("OAAntecedentePreeclampsiaNo")]
		[Bindable(true)]
		public bool? OAAntecedentePreeclampsiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedentePreeclampsiaNo); }
			set { SetColumnValue(Columns.OAAntecedentePreeclampsiaNo, value); }
		}
		  
		[XmlAttribute("OAActualPreeclampsiaSi")]
		[Bindable(true)]
		public bool? OAActualPreeclampsiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualPreeclampsiaSi); }
			set { SetColumnValue(Columns.OAActualPreeclampsiaSi, value); }
		}
		  
		[XmlAttribute("OAActualPreeclampsiaNo")]
		[Bindable(true)]
		public bool? OAActualPreeclampsiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualPreeclampsiaNo); }
			set { SetColumnValue(Columns.OAActualPreeclampsiaNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteCirugiaGinUrinarSi")]
		[Bindable(true)]
		public bool? OAAntecedenteCirugiaGinUrinarSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteCirugiaGinUrinarSi); }
			set { SetColumnValue(Columns.OAAntecedenteCirugiaGinUrinarSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteCirugiaGinUrinarNo")]
		[Bindable(true)]
		public bool? OAAntecedenteCirugiaGinUrinarNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteCirugiaGinUrinarNo); }
			set { SetColumnValue(Columns.OAAntecedenteCirugiaGinUrinarNo, value); }
		}
		  
		[XmlAttribute("OAActualCirugiaGinUrinarSi")]
		[Bindable(true)]
		public bool? OAActualCirugiaGinUrinarSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualCirugiaGinUrinarSi); }
			set { SetColumnValue(Columns.OAActualCirugiaGinUrinarSi, value); }
		}
		  
		[XmlAttribute("OAActualCirugiaGinUrinarNo")]
		[Bindable(true)]
		public bool? OAActualCirugiaGinUrinarNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualCirugiaGinUrinarNo); }
			set { SetColumnValue(Columns.OAActualCirugiaGinUrinarNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteAPPrematuroSi")]
		[Bindable(true)]
		public bool? OAAntecedenteAPPrematuroSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteAPPrematuroSi); }
			set { SetColumnValue(Columns.OAAntecedenteAPPrematuroSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteAPPrematuroNo")]
		[Bindable(true)]
		public bool? OAAntecedenteAPPrematuroNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteAPPrematuroNo); }
			set { SetColumnValue(Columns.OAAntecedenteAPPrematuroNo, value); }
		}
		  
		[XmlAttribute("OAActualAPPrematuroSi")]
		[Bindable(true)]
		public bool? OAActualAPPrematuroSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualAPPrematuroSi); }
			set { SetColumnValue(Columns.OAActualAPPrematuroSi, value); }
		}
		  
		[XmlAttribute("OAActualAPPrematuroNo")]
		[Bindable(true)]
		public bool? OAActualAPPrematuroNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualAPPrematuroNo); }
			set { SetColumnValue(Columns.OAActualAPPrematuroNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteRCIUSi")]
		[Bindable(true)]
		public bool? OAAntecedenteRCIUSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteRCIUSi); }
			set { SetColumnValue(Columns.OAAntecedenteRCIUSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteRCIUNo")]
		[Bindable(true)]
		public bool? OAAntecedenteRCIUNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteRCIUNo); }
			set { SetColumnValue(Columns.OAAntecedenteRCIUNo, value); }
		}
		  
		[XmlAttribute("OAActualRCIUSi")]
		[Bindable(true)]
		public bool? OAActualRCIUSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualRCIUSi); }
			set { SetColumnValue(Columns.OAActualRCIUSi, value); }
		}
		  
		[XmlAttribute("OAActualRCIUNo")]
		[Bindable(true)]
		public bool? OAActualRCIUNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualRCIUNo); }
			set { SetColumnValue(Columns.OAActualRCIUNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteHemorragiaObstetricaSi")]
		[Bindable(true)]
		public bool? OAAntecedenteHemorragiaObstetricaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteHemorragiaObstetricaSi); }
			set { SetColumnValue(Columns.OAAntecedenteHemorragiaObstetricaSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteHemorragiaObstetricaNo")]
		[Bindable(true)]
		public bool? OAAntecedenteHemorragiaObstetricaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteHemorragiaObstetricaNo); }
			set { SetColumnValue(Columns.OAAntecedenteHemorragiaObstetricaNo, value); }
		}
		  
		[XmlAttribute("OAActualHemorragiaObstetricaSi")]
		[Bindable(true)]
		public bool? OAActualHemorragiaObstetricaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualHemorragiaObstetricaSi); }
			set { SetColumnValue(Columns.OAActualHemorragiaObstetricaSi, value); }
		}
		  
		[XmlAttribute("OAActualHemorragiaObstetricaNo")]
		[Bindable(true)]
		public bool? OAActualHemorragiaObstetricaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualHemorragiaObstetricaNo); }
			set { SetColumnValue(Columns.OAActualHemorragiaObstetricaNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteMacrosomiaFetalSi")]
		[Bindable(true)]
		public bool? OAAntecedenteMacrosomiaFetalSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteMacrosomiaFetalSi); }
			set { SetColumnValue(Columns.OAAntecedenteMacrosomiaFetalSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteMacrosomiaFetalNo")]
		[Bindable(true)]
		public bool? OAAntecedenteMacrosomiaFetalNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteMacrosomiaFetalNo); }
			set { SetColumnValue(Columns.OAAntecedenteMacrosomiaFetalNo, value); }
		}
		  
		[XmlAttribute("OAActualMacrosomiaFetalSi")]
		[Bindable(true)]
		public bool? OAActualMacrosomiaFetalSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualMacrosomiaFetalSi); }
			set { SetColumnValue(Columns.OAActualMacrosomiaFetalSi, value); }
		}
		  
		[XmlAttribute("OAActualMacrosomiaFetalNo")]
		[Bindable(true)]
		public bool? OAActualMacrosomiaFetalNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualMacrosomiaFetalNo); }
			set { SetColumnValue(Columns.OAActualMacrosomiaFetalNo, value); }
		}
		  
		[XmlAttribute("OAAntecedentePolihidramniosSi")]
		[Bindable(true)]
		public bool? OAAntecedentePolihidramniosSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedentePolihidramniosSi); }
			set { SetColumnValue(Columns.OAAntecedentePolihidramniosSi, value); }
		}
		  
		[XmlAttribute("OAAntecedentePolihidramniosNo")]
		[Bindable(true)]
		public bool? OAAntecedentePolihidramniosNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedentePolihidramniosNo); }
			set { SetColumnValue(Columns.OAAntecedentePolihidramniosNo, value); }
		}
		  
		[XmlAttribute("OAActualPolihidramniosSi")]
		[Bindable(true)]
		public bool? OAActualPolihidramniosSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualPolihidramniosSi); }
			set { SetColumnValue(Columns.OAActualPolihidramniosSi, value); }
		}
		  
		[XmlAttribute("OAActualPolihidramniosNo")]
		[Bindable(true)]
		public bool? OAActualPolihidramniosNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualPolihidramniosNo); }
			set { SetColumnValue(Columns.OAActualPolihidramniosNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteOligoanmiosSi")]
		[Bindable(true)]
		public bool? OAAntecedenteOligoanmiosSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteOligoanmiosSi); }
			set { SetColumnValue(Columns.OAAntecedenteOligoanmiosSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteOligoanmiosNo")]
		[Bindable(true)]
		public bool? OAAntecedenteOligoanmiosNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteOligoanmiosNo); }
			set { SetColumnValue(Columns.OAAntecedenteOligoanmiosNo, value); }
		}
		  
		[XmlAttribute("OAActualOligoanmiosSi")]
		[Bindable(true)]
		public bool? OAActualOligoanmiosSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualOligoanmiosSi); }
			set { SetColumnValue(Columns.OAActualOligoanmiosSi, value); }
		}
		  
		[XmlAttribute("OAActualOligoanmiosNo")]
		[Bindable(true)]
		public bool? OAActualOligoanmiosNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualOligoanmiosNo); }
			set { SetColumnValue(Columns.OAActualOligoanmiosNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteRotPremMembranasSi")]
		[Bindable(true)]
		public bool? OAAntecedenteRotPremMembranasSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteRotPremMembranasSi); }
			set { SetColumnValue(Columns.OAAntecedenteRotPremMembranasSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteRotPremMembranasNo")]
		[Bindable(true)]
		public bool? OAAntecedenteRotPremMembranasNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteRotPremMembranasNo); }
			set { SetColumnValue(Columns.OAAntecedenteRotPremMembranasNo, value); }
		}
		  
		[XmlAttribute("OAActualRotPremMembranasSi")]
		[Bindable(true)]
		public bool? OAActualRotPremMembranasSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualRotPremMembranasSi); }
			set { SetColumnValue(Columns.OAActualRotPremMembranasSi, value); }
		}
		  
		[XmlAttribute("OAActualRotPremMembranasNo")]
		[Bindable(true)]
		public bool? OAActualRotPremMembranasNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualRotPremMembranasNo); }
			set { SetColumnValue(Columns.OAActualRotPremMembranasNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteIsoinmunizacionesSi")]
		[Bindable(true)]
		public bool? OAAntecedenteIsoinmunizacionesSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteIsoinmunizacionesSi); }
			set { SetColumnValue(Columns.OAAntecedenteIsoinmunizacionesSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteIsoinmunizacionesNo")]
		[Bindable(true)]
		public bool? OAAntecedenteIsoinmunizacionesNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteIsoinmunizacionesNo); }
			set { SetColumnValue(Columns.OAAntecedenteIsoinmunizacionesNo, value); }
		}
		  
		[XmlAttribute("OAActualIsoinmunizacionesSi")]
		[Bindable(true)]
		public bool? OAActualIsoinmunizacionesSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualIsoinmunizacionesSi); }
			set { SetColumnValue(Columns.OAActualIsoinmunizacionesSi, value); }
		}
		  
		[XmlAttribute("OAActualIsoinmunizacionesNo")]
		[Bindable(true)]
		public bool? OAActualIsoinmunizacionesNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualIsoinmunizacionesNo); }
			set { SetColumnValue(Columns.OAActualIsoinmunizacionesNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteColestasisSi")]
		[Bindable(true)]
		public bool? OAAntecedenteColestasisSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteColestasisSi); }
			set { SetColumnValue(Columns.OAAntecedenteColestasisSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteColestasisNo")]
		[Bindable(true)]
		public bool? OAAntecedenteColestasisNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteColestasisNo); }
			set { SetColumnValue(Columns.OAAntecedenteColestasisNo, value); }
		}
		  
		[XmlAttribute("OAActualColestasisSi")]
		[Bindable(true)]
		public bool? OAActualColestasisSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualColestasisSi); }
			set { SetColumnValue(Columns.OAActualColestasisSi, value); }
		}
		  
		[XmlAttribute("OAActualColestasisNo")]
		[Bindable(true)]
		public bool? OAActualColestasisNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAActualColestasisNo); }
			set { SetColumnValue(Columns.OAActualColestasisNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteMortPerinatalRecurrenteSi")]
		[Bindable(true)]
		public bool? OAAntecedenteMortPerinatalRecurrenteSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteMortPerinatalRecurrenteSi); }
			set { SetColumnValue(Columns.OAAntecedenteMortPerinatalRecurrenteSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteMortPerinatalRecurrenteNo")]
		[Bindable(true)]
		public bool? OAAntecedenteMortPerinatalRecurrenteNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteMortPerinatalRecurrenteNo); }
			set { SetColumnValue(Columns.OAAntecedenteMortPerinatalRecurrenteNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteRetencionPlacentaSi")]
		[Bindable(true)]
		public bool? OAAntecedenteRetencionPlacentaSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteRetencionPlacentaSi); }
			set { SetColumnValue(Columns.OAAntecedenteRetencionPlacentaSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteRetencionPlacentaNo")]
		[Bindable(true)]
		public bool? OAAntecedenteRetencionPlacentaNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteRetencionPlacentaNo); }
			set { SetColumnValue(Columns.OAAntecedenteRetencionPlacentaNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteDistociaHombrosSi")]
		[Bindable(true)]
		public bool? OAAntecedenteDistociaHombrosSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteDistociaHombrosSi); }
			set { SetColumnValue(Columns.OAAntecedenteDistociaHombrosSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteDistociaHombrosNo")]
		[Bindable(true)]
		public bool? OAAntecedenteDistociaHombrosNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteDistociaHombrosNo); }
			set { SetColumnValue(Columns.OAAntecedenteDistociaHombrosNo, value); }
		}
		  
		[XmlAttribute("OAAntecedenteMalformCongenSi")]
		[Bindable(true)]
		public bool? OAAntecedenteMalformCongenSi 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteMalformCongenSi); }
			set { SetColumnValue(Columns.OAAntecedenteMalformCongenSi, value); }
		}
		  
		[XmlAttribute("OAAntecedenteMalformCongenNo")]
		[Bindable(true)]
		public bool? OAAntecedenteMalformCongenNo 
		{
			get { return GetColumnValue<bool?>(Columns.OAAntecedenteMalformCongenNo); }
			set { SetColumnValue(Columns.OAAntecedenteMalformCongenNo, value); }
		}
		  
		[XmlAttribute("FactorRiesgoEmbarazoSinContSocialSi")]
		[Bindable(true)]
		public bool? FactorRiesgoEmbarazoSinContSocialSi 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoEmbarazoSinContSocialSi); }
			set { SetColumnValue(Columns.FactorRiesgoEmbarazoSinContSocialSi, value); }
		}
		  
		[XmlAttribute("FactorRiesgoEmbarazoSinContSocialNo")]
		[Bindable(true)]
		public bool? FactorRiesgoEmbarazoSinContSocialNo 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoEmbarazoSinContSocialNo); }
			set { SetColumnValue(Columns.FactorRiesgoEmbarazoSinContSocialNo, value); }
		}
		  
		[XmlAttribute("FactorRiesgoFamiliaSinIngresosFijosSi")]
		[Bindable(true)]
		public bool? FactorRiesgoFamiliaSinIngresosFijosSi 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoFamiliaSinIngresosFijosSi); }
			set { SetColumnValue(Columns.FactorRiesgoFamiliaSinIngresosFijosSi, value); }
		}
		  
		[XmlAttribute("FactorRiesgoFamiliaSinIngresosFijosNo")]
		[Bindable(true)]
		public bool? FactorRiesgoFamiliaSinIngresosFijosNo 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoFamiliaSinIngresosFijosNo); }
			set { SetColumnValue(Columns.FactorRiesgoFamiliaSinIngresosFijosNo, value); }
		}
		  
		[XmlAttribute("FactorRiesgoEmbarazoFuertRechazadoSi")]
		[Bindable(true)]
		public bool? FactorRiesgoEmbarazoFuertRechazadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoEmbarazoFuertRechazadoSi); }
			set { SetColumnValue(Columns.FactorRiesgoEmbarazoFuertRechazadoSi, value); }
		}
		  
		[XmlAttribute("FactorRiesgoEmbarazoFuertRechazadoNo")]
		[Bindable(true)]
		public bool? FactorRiesgoEmbarazoFuertRechazadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoEmbarazoFuertRechazadoNo); }
			set { SetColumnValue(Columns.FactorRiesgoEmbarazoFuertRechazadoNo, value); }
		}
		  
		[XmlAttribute("FactorRiesgoHijosDadosAdopcionSi")]
		[Bindable(true)]
		public bool? FactorRiesgoHijosDadosAdopcionSi 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoHijosDadosAdopcionSi); }
			set { SetColumnValue(Columns.FactorRiesgoHijosDadosAdopcionSi, value); }
		}
		  
		[XmlAttribute("FactorRiesgoHijosDadosAdopcionNo")]
		[Bindable(true)]
		public bool? FactorRiesgoHijosDadosAdopcionNo 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoHijosDadosAdopcionNo); }
			set { SetColumnValue(Columns.FactorRiesgoHijosDadosAdopcionNo, value); }
		}
		  
		[XmlAttribute("FactorRiesgoViviendaSinServiciosBasicosSi")]
		[Bindable(true)]
		public bool? FactorRiesgoViviendaSinServiciosBasicosSi 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoViviendaSinServiciosBasicosSi); }
			set { SetColumnValue(Columns.FactorRiesgoViviendaSinServiciosBasicosSi, value); }
		}
		  
		[XmlAttribute("FactorRiesgoViviendaSinServiciosBasicosNo")]
		[Bindable(true)]
		public bool? FactorRiesgoViviendaSinServiciosBasicosNo 
		{
			get { return GetColumnValue<bool?>(Columns.FactorRiesgoViviendaSinServiciosBasicosNo); }
			set { SetColumnValue(Columns.FactorRiesgoViviendaSinServiciosBasicosNo, value); }
		}
		  
		[XmlAttribute("CaptacionOportunaAntes16sem")]
		[Bindable(true)]
		public bool? CaptacionOportunaAntes16sem 
		{
			get { return GetColumnValue<bool?>(Columns.CaptacionOportunaAntes16sem); }
			set { SetColumnValue(Columns.CaptacionOportunaAntes16sem, value); }
		}
		  
		[XmlAttribute("CaptacionOportunaDespues16sem")]
		[Bindable(true)]
		public bool? CaptacionOportunaDespues16sem 
		{
			get { return GetColumnValue<bool?>(Columns.CaptacionOportunaDespues16sem); }
			set { SetColumnValue(Columns.CaptacionOportunaDespues16sem, value); }
		}
		  
		[XmlAttribute("FechaMuestraPAP")]
		[Bindable(true)]
		public DateTime? FechaMuestraPAP 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaMuestraPAP); }
			set { SetColumnValue(Columns.FechaMuestraPAP, value); }
		}
		  
		[XmlAttribute("FechaTripleAcelular")]
		[Bindable(true)]
		public DateTime? FechaTripleAcelular 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaTripleAcelular); }
			set { SetColumnValue(Columns.FechaTripleAcelular, value); }
		}
		  
		[XmlAttribute("FechaAntigripal")]
		[Bindable(true)]
		public DateTime? FechaAntigripal 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAntigripal); }
			set { SetColumnValue(Columns.FechaAntigripal, value); }
		}
		  
		[XmlAttribute("VIHSegundaMuestraSolicitadoSi")]
		[Bindable(true)]
		public bool? VIHSegundaMuestraSolicitadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHSegundaMuestraSolicitadoSi); }
			set { SetColumnValue(Columns.VIHSegundaMuestraSolicitadoSi, value); }
		}
		  
		[XmlAttribute("VIHSegundaMuestraSolicitadoNo")]
		[Bindable(true)]
		public bool? VIHSegundaMuestraSolicitadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHSegundaMuestraSolicitadoNo); }
			set { SetColumnValue(Columns.VIHSegundaMuestraSolicitadoNo, value); }
		}
		  
		[XmlAttribute("VIHSegundaMuestraRealizadoSi")]
		[Bindable(true)]
		public bool? VIHSegundaMuestraRealizadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHSegundaMuestraRealizadoSi); }
			set { SetColumnValue(Columns.VIHSegundaMuestraRealizadoSi, value); }
		}
		  
		[XmlAttribute("VIHSegundaMuestraRealizadoNo")]
		[Bindable(true)]
		public bool? VIHSegundaMuestraRealizadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHSegundaMuestraRealizadoNo); }
			set { SetColumnValue(Columns.VIHSegundaMuestraRealizadoNo, value); }
		}
		  
		[XmlAttribute("VIHSegundaMuestraFecha")]
		[Bindable(true)]
		public DateTime? VIHSegundaMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.VIHSegundaMuestraFecha); }
			set { SetColumnValue(Columns.VIHSegundaMuestraFecha, value); }
		}
		  
		[XmlAttribute("VIHTercerMuestraSolicitadoSi")]
		[Bindable(true)]
		public bool? VIHTercerMuestraSolicitadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHTercerMuestraSolicitadoSi); }
			set { SetColumnValue(Columns.VIHTercerMuestraSolicitadoSi, value); }
		}
		  
		[XmlAttribute("VIHTercerMuestraSolicitadoNo")]
		[Bindable(true)]
		public bool? VIHTercerMuestraSolicitadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHTercerMuestraSolicitadoNo); }
			set { SetColumnValue(Columns.VIHTercerMuestraSolicitadoNo, value); }
		}
		  
		[XmlAttribute("VIHTercerMuestraRealizadoSi")]
		[Bindable(true)]
		public bool? VIHTercerMuestraRealizadoSi 
		{
			get { return GetColumnValue<bool?>(Columns.VIHTercerMuestraRealizadoSi); }
			set { SetColumnValue(Columns.VIHTercerMuestraRealizadoSi, value); }
		}
		  
		[XmlAttribute("VIHTercerMuestraRealizadoNo")]
		[Bindable(true)]
		public bool? VIHTercerMuestraRealizadoNo 
		{
			get { return GetColumnValue<bool?>(Columns.VIHTercerMuestraRealizadoNo); }
			set { SetColumnValue(Columns.VIHTercerMuestraRealizadoNo, value); }
		}
		  
		[XmlAttribute("VIHTercerMuestraFecha")]
		[Bindable(true)]
		public DateTime? VIHTercerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.VIHTercerMuestraFecha); }
			set { SetColumnValue(Columns.VIHTercerMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoPrimerMuestra")]
		[Bindable(true)]
		public decimal? SifilisPruebaNoTrepoPrimerMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisPruebaNoTrepoPrimerMuestra); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoPrimerMuestra, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoPrimerMuestraNegativo")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoPrimerMuestraNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoPrimerMuestraNegativo); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoPrimerMuestraNegativo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoPrimerMuestraPositivo")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoPrimerMuestraPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoPrimerMuestraPositivo); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoPrimerMuestraPositivo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoPrimerMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoPrimerMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoPrimerMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoPrimerMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoPrimerMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisPruebaNoTrepoPrimerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisPruebaNoTrepoPrimerMuestraFecha); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoPrimerMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoSegundaMuestra")]
		[Bindable(true)]
		public decimal? SifilisPruebaNoTrepoSegundaMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisPruebaNoTrepoSegundaMuestra); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoSegundaMuestra, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoSegundaMuestraNegativo")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoSegundaMuestraNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoSegundaMuestraNegativo); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoSegundaMuestraNegativo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoSegundaMuestraPositivo")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoSegundaMuestraPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoSegundaMuestraPositivo); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoSegundaMuestraPositivo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoSegundaMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoSegundaMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoSegundaMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoSegundaMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoSegundaMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisPruebaNoTrepoSegundaMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisPruebaNoTrepoSegundaMuestraFecha); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoSegundaMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoTercerMuestra")]
		[Bindable(true)]
		public decimal? SifilisPruebaNoTrepoTercerMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisPruebaNoTrepoTercerMuestra); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoTercerMuestra, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoTercerMuestraNegativo")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoTercerMuestraNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoTercerMuestraNegativo); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoTercerMuestraNegativo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoTercerMuestraPositivo")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoTercerMuestraPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoTercerMuestraPositivo); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoTercerMuestraPositivo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoTercerMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisPruebaNoTrepoTercerMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaNoTrepoTercerMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoTercerMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisPruebaNoTrepoTercerMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisPruebaNoTrepoTercerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisPruebaNoTrepoTercerMuestraFecha); }
			set { SetColumnValue(Columns.SifilisPruebaNoTrepoTercerMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoPrimerMuestra")]
		[Bindable(true)]
		public decimal? SifilisPruebaTrepoPrimerMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisPruebaTrepoPrimerMuestra); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoPrimerMuestra, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoPrimerMuestraNegativo")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoPrimerMuestraNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoPrimerMuestraNegativo); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoPrimerMuestraNegativo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoPrimerMuestraPositivo")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoPrimerMuestraPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoPrimerMuestraPositivo); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoPrimerMuestraPositivo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoPrimerMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoPrimerMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoPrimerMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoPrimerMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoPrimerMuestraNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoPrimerMuestraNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoPrimerMuestraNoCorresponde); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoPrimerMuestraNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoPrimerMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisPruebaTrepoPrimerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisPruebaTrepoPrimerMuestraFecha); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoPrimerMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoSegundaMuestra")]
		[Bindable(true)]
		public decimal? SifilisPruebaTrepoSegundaMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisPruebaTrepoSegundaMuestra); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoSegundaMuestra, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoSegundaMuestraNegativo")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoSegundaMuestraNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoSegundaMuestraNegativo); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoSegundaMuestraNegativo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoSegundaMuestraPositivo")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoSegundaMuestraPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoSegundaMuestraPositivo); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoSegundaMuestraPositivo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoSegundaMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoSegundaMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoSegundaMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoSegundaMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoSegundaMuestraNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoSegundaMuestraNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoSegundaMuestraNoCorresponde); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoSegundaMuestraNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoSegundaMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisPruebaTrepoSegundaMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisPruebaTrepoSegundaMuestraFecha); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoSegundaMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoTercerMuestra")]
		[Bindable(true)]
		public decimal? SifilisPruebaTrepoTercerMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisPruebaTrepoTercerMuestra); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoTercerMuestra, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoTercerMuestraNegativo")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoTercerMuestraNegativo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoTercerMuestraNegativo); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoTercerMuestraNegativo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoTercerMuestraPositivo")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoTercerMuestraPositivo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoTercerMuestraPositivo); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoTercerMuestraPositivo, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoTercerMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoTercerMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoTercerMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoTercerMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoTercerMuestraNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisPruebaTrepoTercerMuestraNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisPruebaTrepoTercerMuestraNoCorresponde); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoTercerMuestraNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisPruebaTrepoTercerMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisPruebaTrepoTercerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisPruebaTrepoTercerMuestraFecha); }
			set { SetColumnValue(Columns.SifilisPruebaTrepoTercerMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoPrimerMuestra")]
		[Bindable(true)]
		public decimal? SifilisTratamientoPrimerMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisTratamientoPrimerMuestra); }
			set { SetColumnValue(Columns.SifilisTratamientoPrimerMuestra, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoPrimerMuestraNo")]
		[Bindable(true)]
		public bool? SifilisTratamientoPrimerMuestraNo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoPrimerMuestraNo); }
			set { SetColumnValue(Columns.SifilisTratamientoPrimerMuestraNo, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoPrimerMuestraSi")]
		[Bindable(true)]
		public bool? SifilisTratamientoPrimerMuestraSi 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoPrimerMuestraSi); }
			set { SetColumnValue(Columns.SifilisTratamientoPrimerMuestraSi, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoPrimerMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisTratamientoPrimerMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoPrimerMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisTratamientoPrimerMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoPrimerMuestraNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisTratamientoPrimerMuestraNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoPrimerMuestraNoCorresponde); }
			set { SetColumnValue(Columns.SifilisTratamientoPrimerMuestraNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoPrimerMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisTratamientoPrimerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisTratamientoPrimerMuestraFecha); }
			set { SetColumnValue(Columns.SifilisTratamientoPrimerMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoSegundaMuestra")]
		[Bindable(true)]
		public decimal? SifilisTratamientoSegundaMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisTratamientoSegundaMuestra); }
			set { SetColumnValue(Columns.SifilisTratamientoSegundaMuestra, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoSegundaMuestraNo")]
		[Bindable(true)]
		public bool? SifilisTratamientoSegundaMuestraNo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoSegundaMuestraNo); }
			set { SetColumnValue(Columns.SifilisTratamientoSegundaMuestraNo, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoSegundaMuestraSi")]
		[Bindable(true)]
		public bool? SifilisTratamientoSegundaMuestraSi 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoSegundaMuestraSi); }
			set { SetColumnValue(Columns.SifilisTratamientoSegundaMuestraSi, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoSegundaMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisTratamientoSegundaMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoSegundaMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisTratamientoSegundaMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoSegundaMuestraNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisTratamientoSegundaMuestraNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoSegundaMuestraNoCorresponde); }
			set { SetColumnValue(Columns.SifilisTratamientoSegundaMuestraNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoSegundaMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisTratamientoSegundaMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisTratamientoSegundaMuestraFecha); }
			set { SetColumnValue(Columns.SifilisTratamientoSegundaMuestraFecha, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoTercerMuestra")]
		[Bindable(true)]
		public decimal? SifilisTratamientoTercerMuestra 
		{
			get { return GetColumnValue<decimal?>(Columns.SifilisTratamientoTercerMuestra); }
			set { SetColumnValue(Columns.SifilisTratamientoTercerMuestra, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoTercerMuestraNo")]
		[Bindable(true)]
		public bool? SifilisTratamientoTercerMuestraNo 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoTercerMuestraNo); }
			set { SetColumnValue(Columns.SifilisTratamientoTercerMuestraNo, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoTercerMuestraSi")]
		[Bindable(true)]
		public bool? SifilisTratamientoTercerMuestraSi 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoTercerMuestraSi); }
			set { SetColumnValue(Columns.SifilisTratamientoTercerMuestraSi, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoTercerMuestraSinDatos")]
		[Bindable(true)]
		public bool? SifilisTratamientoTercerMuestraSinDatos 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoTercerMuestraSinDatos); }
			set { SetColumnValue(Columns.SifilisTratamientoTercerMuestraSinDatos, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoTercerMuestraNoCorresponde")]
		[Bindable(true)]
		public bool? SifilisTratamientoTercerMuestraNoCorresponde 
		{
			get { return GetColumnValue<bool?>(Columns.SifilisTratamientoTercerMuestraNoCorresponde); }
			set { SetColumnValue(Columns.SifilisTratamientoTercerMuestraNoCorresponde, value); }
		}
		  
		[XmlAttribute("SifilisTratamientoTercerMuestraFecha")]
		[Bindable(true)]
		public DateTime? SifilisTratamientoTercerMuestraFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.SifilisTratamientoTercerMuestraFecha); }
			set { SetColumnValue(Columns.SifilisTratamientoTercerMuestraFecha, value); }
		}
		  
		[XmlAttribute("Activa")]
		[Bindable(true)]
		public bool Activa 
		{
			get { return GetColumnValue<bool>(Columns.Activa); }
			set { SetColumnValue(Columns.Activa, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
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
		  
		[XmlAttribute("IdEfectorTrasladoUt")]
		[Bindable(true)]
		public int? IdEfectorTrasladoUt 
		{
			get { return GetColumnValue<int?>(Columns.IdEfectorTrasladoUt); }
			set { SetColumnValue(Columns.IdEfectorTrasladoUt, value); }
		}
		  
		[XmlAttribute("DiabetesActualSi")]
		[Bindable(true)]
		public bool? DiabetesActualSi 
		{
			get { return GetColumnValue<bool?>(Columns.DiabetesActualSi); }
			set { SetColumnValue(Columns.DiabetesActualSi, value); }
		}
		  
		[XmlAttribute("DiabetesActualNo")]
		[Bindable(true)]
		public bool? DiabetesActualNo 
		{
			get { return GetColumnValue<bool?>(Columns.DiabetesActualNo); }
			set { SetColumnValue(Columns.DiabetesActualNo, value); }
		}
		  
		[XmlAttribute("AnemiaSi")]
		[Bindable(true)]
		public bool? AnemiaSi 
		{
			get { return GetColumnValue<bool?>(Columns.AnemiaSi); }
			set { SetColumnValue(Columns.AnemiaSi, value); }
		}
		  
		[XmlAttribute("AnemiaNo")]
		[Bindable(true)]
		public bool? AnemiaNo 
		{
			get { return GetColumnValue<bool?>(Columns.AnemiaNo); }
			set { SetColumnValue(Columns.AnemiaNo, value); }
		}
		  
		[XmlAttribute("NumeroIdentidad")]
		[Bindable(true)]
		public string NumeroIdentidad 
		{
			get { return GetColumnValue<string>(Columns.NumeroIdentidad); }
			set { SetColumnValue(Columns.NumeroIdentidad, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprPartoProvisorioCollection colAprPartoProvisorioRecords;
		public DalSic.AprPartoProvisorioCollection AprPartoProvisorioRecords
		{
			get
			{
				if(colAprPartoProvisorioRecords == null)
				{
					colAprPartoProvisorioRecords = new DalSic.AprPartoProvisorioCollection().Where(AprPartoProvisorio.Columns.IdHistoriaClinicaPerinatal, IdHistoriaClinicaPerinatal).Load();
					colAprPartoProvisorioRecords.ListChanged += new ListChangedEventHandler(colAprPartoProvisorioRecords_ListChanged);
				}
				return colAprPartoProvisorioRecords;			
			}
			set 
			{ 
					colAprPartoProvisorioRecords = value; 
					colAprPartoProvisorioRecords.ListChanged += new ListChangedEventHandler(colAprPartoProvisorioRecords_ListChanged);
			}
		}
		
		void colAprPartoProvisorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprPartoProvisorioRecords[e.NewIndex].IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
		    }
		}
				
		private DalSic.AprHistoriaClinicaPerinatalDetalleCollection colAprHistoriaClinicaPerinatalDetalleRecords;
		public DalSic.AprHistoriaClinicaPerinatalDetalleCollection AprHistoriaClinicaPerinatalDetalleRecords
		{
			get
			{
				if(colAprHistoriaClinicaPerinatalDetalleRecords == null)
				{
					colAprHistoriaClinicaPerinatalDetalleRecords = new DalSic.AprHistoriaClinicaPerinatalDetalleCollection().Where(AprHistoriaClinicaPerinatalDetalle.Columns.IdHistoriaClinicaPerinatal, IdHistoriaClinicaPerinatal).Load();
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
		        colAprHistoriaClinicaPerinatalDetalleRecords[e.NewIndex].IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this AprHistoriaClinicaPerinatal
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorTrasladoUt); }
			set { SetColumnValue("idEfectorTrasladoUt", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this AprHistoriaClinicaPerinatal
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdEfectorTrasladoUt
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorTrasladoUt); }
			set { SetColumnValue("idEfectorTrasladoUt", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this AprHistoriaClinicaPerinatal
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,string varNombre,string varApellido,string varDomicilio,string varDni,string varLocalidad,string varTelefono,DateTime? varFechaNacimiento,int? varEdad,string varDatosDeContacto,bool? varEdadMenor15Mayor35,bool? varEtniaBlanca,bool? varEtniaIndigena,bool? varEtniaMestiza,bool? varEtniaNegra,bool? varEtniaOtra,bool? varAlfabetaSi,bool? varAlfabetaNo,bool? varEstudiosNinguno,bool? varEstudiosPrimario,bool? varEstudiosSecundario,bool? varEstudiosUniversitario,int? varAñosMayorNivel,bool? varEstadoCivilCasada,bool? varEstadoCivilUnionEstable,bool? varEstadoCivilSoltera,bool? varEstadoCivilOtro,bool? varViveSolaSi,bool? varViveSolaNo,string varLugarControlPerinatal,string varLugarPartoAborto,bool? varAntFamTBCSi,bool? varAntFamTBCNo,bool? varAntFamDiabetesSi,bool? varAntFamDiabetesNo,bool? varAntFamHipertensionSi,bool? varAntFamHipertensionNo,bool? varAntFamInfeccionUrinariaSi,bool? varAntFamInfeccionUrinariaNo,bool? varAntFamOtrasInfeccionesSi,bool? varAntFamOtrasInfeccionesNo,bool? varAntFamOtroSi,bool? varAntFamOtroNo,bool? varAntPerTBCSi,bool? varAntPerTBCNo,bool? varAntPerDiabetesI,bool? varAntPerDiabetesII,bool? varAntPerDiabetesG,bool? varAntPerDiabetesNo,bool? varAntPerHipertensionSi,bool? varAntPerHipertensionNo,bool? varAntPerInfeccionUrinariaSi,bool? varAntPerInfeccionUrinariaNo,bool? varAntPerOtrasInfeccionesSi,bool? varAntPerOtrasInfeccionesNo,bool? varAntPerOtroSi,bool? varAntPerOtroNo,bool? varAntPerInfertilidadSi,bool? varAntPerInfertilidadNo,bool? varAntPerCardiopatiaSi,bool? varAntPerCardiopatiaNo,bool? varAntPerNefropatiaSi,bool? varAntPerNefropatiaNo,bool? varAntPerViolenciaSi,bool? varAntPerViolenciaNo,bool? varAntPerAlergiaMedicamentoSi,bool? varAntPerAlergiaMedicamentoNo,string varAntecedentesObservacion,int? varGestasPrevias,int? varAbortos,int? varEmbEctopicos,bool? varAbortos3concecutivos,int? varPartos,int? varPartosVaginales,int? varCesareas,int? varNacidosVivos,int? varNacidosMuertos,int? varViven,int? varMuertosPrimerSemana,int? varMuertosDespuesPrimerSemana,bool? varAntecedentesGemelaresSi,bool? varAntecedentesGemelaresNo,bool? varUltPrevioNC,bool? varUltPrevioNormal,bool? varUltPrevioMenor2500,bool? varUltPrevioMayor4000,DateTime? varFinEmbarazoAnterior,bool? varFinEmbAnteriorMenor1Año,bool? varEmbarazoPlaneadoSi,bool? varEmbarazoPlaneadoNo,bool? varFracMetAnticonceptivoNoUsaba,bool? varFracMetAnticonceptivoBarrera,bool? varFracMetAnticonceptivoDIU,bool? varFracMetAnticonceptivoHormonal,bool? varFracMetAnticonceptivoEmergencia,bool? varFracMetAnticonceptivoNatural,decimal? varPesoAnterior,int? varTalla,DateTime? varFum,DateTime? varFpp,bool? varEGConfiableFUMSi,bool? varEGConfiableFUMNo,bool? varEGConfiableEcoMenor20semanasSi,bool? varEGConfiableEcoMenor20semanasNo,bool? varFumaActivo1TrimSi,bool? varFumaActivo1TrimNo,bool? varFumaActivo2TrimSi,bool? varFumaActivo2TrimNo,bool? varFumaActivo3TrimSi,bool? varFumaActivo3TrimNo,bool? varFumaPasivo1TrimSi,bool? varFumaPasivo1TrimNo,bool? varFumaPasivo2TrimSi,bool? varFumaPasivo2TrimNo,bool? varFumaPasivo3TrimSi,bool? varFumaPasivo3TrimNo,bool? varDrogas1TrimSi,bool? varDrogas1TrimNo,bool? varDrogas2TrimSi,bool? varDrogas2TrimNo,bool? varDrogas3TrimSi,bool? varDrogas3TrimNo,bool? varAlcohol1TrimSi,bool? varAlcohol1TrimNo,bool? varAlcohol2TrimSi,bool? varAlcohol2TrimNo,bool? varAlcohol3TrimSi,bool? varAlcohol3TrimNo,bool? varViolencia1TrimSi,bool? varViolencia1TrimNo,bool? varViolencia2TrimSi,bool? varViolencia2TrimNo,bool? varViolencia3TrimSi,bool? varViolencia3TrimNo,bool? varAntirubeolaPrevia,bool? varAntirubeolaNoSabe,bool? varAntirubeolaEmbarazo,bool? varAntirubeolaNo,bool? varAntitetanicaVigenteNo,bool? varAntitetanicaVigenteSi,int? varAntitetanica1DosisMesGestacion,int? varAntitetanica2DosisMesGestacion,bool? varExamenOdotologicoNormalSi,bool? varExamenOdotologicoNormalNo,bool? varExamenMamasNormalSi,bool? varExamenMamasNormalNo,bool? varCervixInspeccionVisualNormal,bool? varCervixInspeccionVisualAnormal,bool? varCervixInspeccionVisualNoSeHizo,bool? varCervixPAPNormal,bool? varCervixPAPAnormal,bool? varCervixPAPNoSeHizo,bool? varCervixCOLPNormal,bool? varCervixCOLPAnormal,bool? varCervixCOLPNoSeHizo,string varGrupo,bool? varRHPositivo,bool? varRHNegativo,bool? varInmunizacionSi,bool? varInmunizacionNo,bool? varGammaGlobulinaNo,bool? varGammaGlobulinaSi,bool? varGammaGlobulinaNoCorresponde,bool? varToxoPlasmosisMenor20SemLGGNegativo,bool? varToxoPlasmosisMenor20SemLGGPositivo,bool? varToxoPlasmosisMenor20SemLGGNoSeHizo,bool? varToxoPlasmosisMayor20SemLGGNegativo,bool? varToxoPlasmosisMayor20SemLGGPositivo,bool? varToxoPlasmosisMayor20SemLGGNoSeHizo,bool? varToxoPlasmosis1ConsultaLGMNegativo,bool? varToxoPlasmosis1ConsultaLGMPositivo,bool? varToxoPlasmosis1ConsultaLGMNoSeHizo,bool? varChagasNegativo,bool? varChagasPositivo,bool? varChagasNoSeHizo,bool? varHepatitisBNegativo,bool? varHepatitisBPositivo,bool? varHepatitisBNoSeHizo,bool? varBacteriuraMenor20SemNormal,bool? varBacteriuraMenor20SemAnormal,bool? varBacteriuraMenor20SemNoSeHizo,bool? varBacteriuraMayor20SemNormal,bool? varBacteriuraMayor20SemAnormal,bool? varBacteriuraMayor20SemNoSeHizo,decimal? varGlucemiaMenor20Sem,bool? varGlucemiaMenor20SemMayor105,decimal? varGlucemiaMayor20Sem,bool? varGlucemiaMayor20SemMayor105,bool? varVIHCRSi,bool? varVIHCRNo,bool? varVIHPrimerMuestraSolicitadoSi,bool? varVIHPrimerMuestraSolicitadoNo,bool? varVIHPrimerMuestraRealizadoSi,bool? varVIHPrimerMuestraRealizadoNo,DateTime? varVIHPrimerMuestraFecha,decimal? varHBMenor20Sem,bool? varHBMenor20SemMenor11,decimal? varHBMayor20Sem,bool? varHBMayor20SemMenor11,bool? varFeIndicadoSi,bool? varFeIndicadoNo,bool? varFolatosIndicadosSi,bool? varFolatosIndicadosNo,bool? varEstreptococoB3537SemanasNegativo,bool? varEstreptococoB3537SemanasPositivo,bool? varEstreptococoB3537SemanasNoSeHizo,bool? varPreparacionPartoSi,bool? varPreparacionPartoNo,bool? varConsejeriaLactanciaMaternaSi,bool? varConsejeriaLactanciaMaternaNo,bool? varSifilisTratParejaMenor20SemNo,bool? varSifilisTratParejaMenor20SemSi,bool? varSifilisTratParejaMenor20SemSinDatos,bool? varSifilisTratParejaMenor20SemNoCorresponde,bool? varSifilisTratParejaMayor20SemNo,bool? varSifilisTratParejaMayor20SemSi,bool? varSifilisTratParejaMayor20SemSinDatos,bool? varSifilisTratParejaMayor20SemNoCorresponde,bool? varOAAntecedenteEclampsiaSi,bool? varOAAntecedenteEclampsiaNo,bool? varOAActualEclampsiaSi,bool? varOAActualEclampsiaNo,bool? varOAAntecedentePreeclampsiaSi,bool? varOAAntecedentePreeclampsiaNo,bool? varOAActualPreeclampsiaSi,bool? varOAActualPreeclampsiaNo,bool? varOAAntecedenteCirugiaGinUrinarSi,bool? varOAAntecedenteCirugiaGinUrinarNo,bool? varOAActualCirugiaGinUrinarSi,bool? varOAActualCirugiaGinUrinarNo,bool? varOAAntecedenteAPPrematuroSi,bool? varOAAntecedenteAPPrematuroNo,bool? varOAActualAPPrematuroSi,bool? varOAActualAPPrematuroNo,bool? varOAAntecedenteRCIUSi,bool? varOAAntecedenteRCIUNo,bool? varOAActualRCIUSi,bool? varOAActualRCIUNo,bool? varOAAntecedenteHemorragiaObstetricaSi,bool? varOAAntecedenteHemorragiaObstetricaNo,bool? varOAActualHemorragiaObstetricaSi,bool? varOAActualHemorragiaObstetricaNo,bool? varOAAntecedenteMacrosomiaFetalSi,bool? varOAAntecedenteMacrosomiaFetalNo,bool? varOAActualMacrosomiaFetalSi,bool? varOAActualMacrosomiaFetalNo,bool? varOAAntecedentePolihidramniosSi,bool? varOAAntecedentePolihidramniosNo,bool? varOAActualPolihidramniosSi,bool? varOAActualPolihidramniosNo,bool? varOAAntecedenteOligoanmiosSi,bool? varOAAntecedenteOligoanmiosNo,bool? varOAActualOligoanmiosSi,bool? varOAActualOligoanmiosNo,bool? varOAAntecedenteRotPremMembranasSi,bool? varOAAntecedenteRotPremMembranasNo,bool? varOAActualRotPremMembranasSi,bool? varOAActualRotPremMembranasNo,bool? varOAAntecedenteIsoinmunizacionesSi,bool? varOAAntecedenteIsoinmunizacionesNo,bool? varOAActualIsoinmunizacionesSi,bool? varOAActualIsoinmunizacionesNo,bool? varOAAntecedenteColestasisSi,bool? varOAAntecedenteColestasisNo,bool? varOAActualColestasisSi,bool? varOAActualColestasisNo,bool? varOAAntecedenteMortPerinatalRecurrenteSi,bool? varOAAntecedenteMortPerinatalRecurrenteNo,bool? varOAAntecedenteRetencionPlacentaSi,bool? varOAAntecedenteRetencionPlacentaNo,bool? varOAAntecedenteDistociaHombrosSi,bool? varOAAntecedenteDistociaHombrosNo,bool? varOAAntecedenteMalformCongenSi,bool? varOAAntecedenteMalformCongenNo,bool? varFactorRiesgoEmbarazoSinContSocialSi,bool? varFactorRiesgoEmbarazoSinContSocialNo,bool? varFactorRiesgoFamiliaSinIngresosFijosSi,bool? varFactorRiesgoFamiliaSinIngresosFijosNo,bool? varFactorRiesgoEmbarazoFuertRechazadoSi,bool? varFactorRiesgoEmbarazoFuertRechazadoNo,bool? varFactorRiesgoHijosDadosAdopcionSi,bool? varFactorRiesgoHijosDadosAdopcionNo,bool? varFactorRiesgoViviendaSinServiciosBasicosSi,bool? varFactorRiesgoViviendaSinServiciosBasicosNo,bool? varCaptacionOportunaAntes16sem,bool? varCaptacionOportunaDespues16sem,DateTime? varFechaMuestraPAP,DateTime? varFechaTripleAcelular,DateTime? varFechaAntigripal,bool? varVIHSegundaMuestraSolicitadoSi,bool? varVIHSegundaMuestraSolicitadoNo,bool? varVIHSegundaMuestraRealizadoSi,bool? varVIHSegundaMuestraRealizadoNo,DateTime? varVIHSegundaMuestraFecha,bool? varVIHTercerMuestraSolicitadoSi,bool? varVIHTercerMuestraSolicitadoNo,bool? varVIHTercerMuestraRealizadoSi,bool? varVIHTercerMuestraRealizadoNo,DateTime? varVIHTercerMuestraFecha,decimal? varSifilisPruebaNoTrepoPrimerMuestra,bool? varSifilisPruebaNoTrepoPrimerMuestraNegativo,bool? varSifilisPruebaNoTrepoPrimerMuestraPositivo,bool? varSifilisPruebaNoTrepoPrimerMuestraSinDatos,DateTime? varSifilisPruebaNoTrepoPrimerMuestraFecha,decimal? varSifilisPruebaNoTrepoSegundaMuestra,bool? varSifilisPruebaNoTrepoSegundaMuestraNegativo,bool? varSifilisPruebaNoTrepoSegundaMuestraPositivo,bool? varSifilisPruebaNoTrepoSegundaMuestraSinDatos,DateTime? varSifilisPruebaNoTrepoSegundaMuestraFecha,decimal? varSifilisPruebaNoTrepoTercerMuestra,bool? varSifilisPruebaNoTrepoTercerMuestraNegativo,bool? varSifilisPruebaNoTrepoTercerMuestraPositivo,bool? varSifilisPruebaNoTrepoTercerMuestraSinDatos,DateTime? varSifilisPruebaNoTrepoTercerMuestraFecha,decimal? varSifilisPruebaTrepoPrimerMuestra,bool? varSifilisPruebaTrepoPrimerMuestraNegativo,bool? varSifilisPruebaTrepoPrimerMuestraPositivo,bool? varSifilisPruebaTrepoPrimerMuestraSinDatos,bool? varSifilisPruebaTrepoPrimerMuestraNoCorresponde,DateTime? varSifilisPruebaTrepoPrimerMuestraFecha,decimal? varSifilisPruebaTrepoSegundaMuestra,bool? varSifilisPruebaTrepoSegundaMuestraNegativo,bool? varSifilisPruebaTrepoSegundaMuestraPositivo,bool? varSifilisPruebaTrepoSegundaMuestraSinDatos,bool? varSifilisPruebaTrepoSegundaMuestraNoCorresponde,DateTime? varSifilisPruebaTrepoSegundaMuestraFecha,decimal? varSifilisPruebaTrepoTercerMuestra,bool? varSifilisPruebaTrepoTercerMuestraNegativo,bool? varSifilisPruebaTrepoTercerMuestraPositivo,bool? varSifilisPruebaTrepoTercerMuestraSinDatos,bool? varSifilisPruebaTrepoTercerMuestraNoCorresponde,DateTime? varSifilisPruebaTrepoTercerMuestraFecha,decimal? varSifilisTratamientoPrimerMuestra,bool? varSifilisTratamientoPrimerMuestraNo,bool? varSifilisTratamientoPrimerMuestraSi,bool? varSifilisTratamientoPrimerMuestraSinDatos,bool? varSifilisTratamientoPrimerMuestraNoCorresponde,DateTime? varSifilisTratamientoPrimerMuestraFecha,decimal? varSifilisTratamientoSegundaMuestra,bool? varSifilisTratamientoSegundaMuestraNo,bool? varSifilisTratamientoSegundaMuestraSi,bool? varSifilisTratamientoSegundaMuestraSinDatos,bool? varSifilisTratamientoSegundaMuestraNoCorresponde,DateTime? varSifilisTratamientoSegundaMuestraFecha,decimal? varSifilisTratamientoTercerMuestra,bool? varSifilisTratamientoTercerMuestraNo,bool? varSifilisTratamientoTercerMuestraSi,bool? varSifilisTratamientoTercerMuestraSinDatos,bool? varSifilisTratamientoTercerMuestraNoCorresponde,DateTime? varSifilisTratamientoTercerMuestraFecha,bool varActiva,string varObservaciones,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdEfectorTrasladoUt,bool? varDiabetesActualSi,bool? varDiabetesActualNo,bool? varAnemiaSi,bool? varAnemiaNo,string varNumeroIdentidad)
		{
			AprHistoriaClinicaPerinatal item = new AprHistoriaClinicaPerinatal();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.Nombre = varNombre;
			
			item.Apellido = varApellido;
			
			item.Domicilio = varDomicilio;
			
			item.Dni = varDni;
			
			item.Localidad = varLocalidad;
			
			item.Telefono = varTelefono;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.Edad = varEdad;
			
			item.DatosDeContacto = varDatosDeContacto;
			
			item.EdadMenor15Mayor35 = varEdadMenor15Mayor35;
			
			item.EtniaBlanca = varEtniaBlanca;
			
			item.EtniaIndigena = varEtniaIndigena;
			
			item.EtniaMestiza = varEtniaMestiza;
			
			item.EtniaNegra = varEtniaNegra;
			
			item.EtniaOtra = varEtniaOtra;
			
			item.AlfabetaSi = varAlfabetaSi;
			
			item.AlfabetaNo = varAlfabetaNo;
			
			item.EstudiosNinguno = varEstudiosNinguno;
			
			item.EstudiosPrimario = varEstudiosPrimario;
			
			item.EstudiosSecundario = varEstudiosSecundario;
			
			item.EstudiosUniversitario = varEstudiosUniversitario;
			
			item.AñosMayorNivel = varAñosMayorNivel;
			
			item.EstadoCivilCasada = varEstadoCivilCasada;
			
			item.EstadoCivilUnionEstable = varEstadoCivilUnionEstable;
			
			item.EstadoCivilSoltera = varEstadoCivilSoltera;
			
			item.EstadoCivilOtro = varEstadoCivilOtro;
			
			item.ViveSolaSi = varViveSolaSi;
			
			item.ViveSolaNo = varViveSolaNo;
			
			item.LugarControlPerinatal = varLugarControlPerinatal;
			
			item.LugarPartoAborto = varLugarPartoAborto;
			
			item.AntFamTBCSi = varAntFamTBCSi;
			
			item.AntFamTBCNo = varAntFamTBCNo;
			
			item.AntFamDiabetesSi = varAntFamDiabetesSi;
			
			item.AntFamDiabetesNo = varAntFamDiabetesNo;
			
			item.AntFamHipertensionSi = varAntFamHipertensionSi;
			
			item.AntFamHipertensionNo = varAntFamHipertensionNo;
			
			item.AntFamInfeccionUrinariaSi = varAntFamInfeccionUrinariaSi;
			
			item.AntFamInfeccionUrinariaNo = varAntFamInfeccionUrinariaNo;
			
			item.AntFamOtrasInfeccionesSi = varAntFamOtrasInfeccionesSi;
			
			item.AntFamOtrasInfeccionesNo = varAntFamOtrasInfeccionesNo;
			
			item.AntFamOtroSi = varAntFamOtroSi;
			
			item.AntFamOtroNo = varAntFamOtroNo;
			
			item.AntPerTBCSi = varAntPerTBCSi;
			
			item.AntPerTBCNo = varAntPerTBCNo;
			
			item.AntPerDiabetesI = varAntPerDiabetesI;
			
			item.AntPerDiabetesII = varAntPerDiabetesII;
			
			item.AntPerDiabetesG = varAntPerDiabetesG;
			
			item.AntPerDiabetesNo = varAntPerDiabetesNo;
			
			item.AntPerHipertensionSi = varAntPerHipertensionSi;
			
			item.AntPerHipertensionNo = varAntPerHipertensionNo;
			
			item.AntPerInfeccionUrinariaSi = varAntPerInfeccionUrinariaSi;
			
			item.AntPerInfeccionUrinariaNo = varAntPerInfeccionUrinariaNo;
			
			item.AntPerOtrasInfeccionesSi = varAntPerOtrasInfeccionesSi;
			
			item.AntPerOtrasInfeccionesNo = varAntPerOtrasInfeccionesNo;
			
			item.AntPerOtroSi = varAntPerOtroSi;
			
			item.AntPerOtroNo = varAntPerOtroNo;
			
			item.AntPerInfertilidadSi = varAntPerInfertilidadSi;
			
			item.AntPerInfertilidadNo = varAntPerInfertilidadNo;
			
			item.AntPerCardiopatiaSi = varAntPerCardiopatiaSi;
			
			item.AntPerCardiopatiaNo = varAntPerCardiopatiaNo;
			
			item.AntPerNefropatiaSi = varAntPerNefropatiaSi;
			
			item.AntPerNefropatiaNo = varAntPerNefropatiaNo;
			
			item.AntPerViolenciaSi = varAntPerViolenciaSi;
			
			item.AntPerViolenciaNo = varAntPerViolenciaNo;
			
			item.AntPerAlergiaMedicamentoSi = varAntPerAlergiaMedicamentoSi;
			
			item.AntPerAlergiaMedicamentoNo = varAntPerAlergiaMedicamentoNo;
			
			item.AntecedentesObservacion = varAntecedentesObservacion;
			
			item.GestasPrevias = varGestasPrevias;
			
			item.Abortos = varAbortos;
			
			item.EmbEctopicos = varEmbEctopicos;
			
			item.Abortos3concecutivos = varAbortos3concecutivos;
			
			item.Partos = varPartos;
			
			item.PartosVaginales = varPartosVaginales;
			
			item.Cesareas = varCesareas;
			
			item.NacidosVivos = varNacidosVivos;
			
			item.NacidosMuertos = varNacidosMuertos;
			
			item.Viven = varViven;
			
			item.MuertosPrimerSemana = varMuertosPrimerSemana;
			
			item.MuertosDespuesPrimerSemana = varMuertosDespuesPrimerSemana;
			
			item.AntecedentesGemelaresSi = varAntecedentesGemelaresSi;
			
			item.AntecedentesGemelaresNo = varAntecedentesGemelaresNo;
			
			item.UltPrevioNC = varUltPrevioNC;
			
			item.UltPrevioNormal = varUltPrevioNormal;
			
			item.UltPrevioMenor2500 = varUltPrevioMenor2500;
			
			item.UltPrevioMayor4000 = varUltPrevioMayor4000;
			
			item.FinEmbarazoAnterior = varFinEmbarazoAnterior;
			
			item.FinEmbAnteriorMenor1Año = varFinEmbAnteriorMenor1Año;
			
			item.EmbarazoPlaneadoSi = varEmbarazoPlaneadoSi;
			
			item.EmbarazoPlaneadoNo = varEmbarazoPlaneadoNo;
			
			item.FracMetAnticonceptivoNoUsaba = varFracMetAnticonceptivoNoUsaba;
			
			item.FracMetAnticonceptivoBarrera = varFracMetAnticonceptivoBarrera;
			
			item.FracMetAnticonceptivoDIU = varFracMetAnticonceptivoDIU;
			
			item.FracMetAnticonceptivoHormonal = varFracMetAnticonceptivoHormonal;
			
			item.FracMetAnticonceptivoEmergencia = varFracMetAnticonceptivoEmergencia;
			
			item.FracMetAnticonceptivoNatural = varFracMetAnticonceptivoNatural;
			
			item.PesoAnterior = varPesoAnterior;
			
			item.Talla = varTalla;
			
			item.Fum = varFum;
			
			item.Fpp = varFpp;
			
			item.EGConfiableFUMSi = varEGConfiableFUMSi;
			
			item.EGConfiableFUMNo = varEGConfiableFUMNo;
			
			item.EGConfiableEcoMenor20semanasSi = varEGConfiableEcoMenor20semanasSi;
			
			item.EGConfiableEcoMenor20semanasNo = varEGConfiableEcoMenor20semanasNo;
			
			item.FumaActivo1TrimSi = varFumaActivo1TrimSi;
			
			item.FumaActivo1TrimNo = varFumaActivo1TrimNo;
			
			item.FumaActivo2TrimSi = varFumaActivo2TrimSi;
			
			item.FumaActivo2TrimNo = varFumaActivo2TrimNo;
			
			item.FumaActivo3TrimSi = varFumaActivo3TrimSi;
			
			item.FumaActivo3TrimNo = varFumaActivo3TrimNo;
			
			item.FumaPasivo1TrimSi = varFumaPasivo1TrimSi;
			
			item.FumaPasivo1TrimNo = varFumaPasivo1TrimNo;
			
			item.FumaPasivo2TrimSi = varFumaPasivo2TrimSi;
			
			item.FumaPasivo2TrimNo = varFumaPasivo2TrimNo;
			
			item.FumaPasivo3TrimSi = varFumaPasivo3TrimSi;
			
			item.FumaPasivo3TrimNo = varFumaPasivo3TrimNo;
			
			item.Drogas1TrimSi = varDrogas1TrimSi;
			
			item.Drogas1TrimNo = varDrogas1TrimNo;
			
			item.Drogas2TrimSi = varDrogas2TrimSi;
			
			item.Drogas2TrimNo = varDrogas2TrimNo;
			
			item.Drogas3TrimSi = varDrogas3TrimSi;
			
			item.Drogas3TrimNo = varDrogas3TrimNo;
			
			item.Alcohol1TrimSi = varAlcohol1TrimSi;
			
			item.Alcohol1TrimNo = varAlcohol1TrimNo;
			
			item.Alcohol2TrimSi = varAlcohol2TrimSi;
			
			item.Alcohol2TrimNo = varAlcohol2TrimNo;
			
			item.Alcohol3TrimSi = varAlcohol3TrimSi;
			
			item.Alcohol3TrimNo = varAlcohol3TrimNo;
			
			item.Violencia1TrimSi = varViolencia1TrimSi;
			
			item.Violencia1TrimNo = varViolencia1TrimNo;
			
			item.Violencia2TrimSi = varViolencia2TrimSi;
			
			item.Violencia2TrimNo = varViolencia2TrimNo;
			
			item.Violencia3TrimSi = varViolencia3TrimSi;
			
			item.Violencia3TrimNo = varViolencia3TrimNo;
			
			item.AntirubeolaPrevia = varAntirubeolaPrevia;
			
			item.AntirubeolaNoSabe = varAntirubeolaNoSabe;
			
			item.AntirubeolaEmbarazo = varAntirubeolaEmbarazo;
			
			item.AntirubeolaNo = varAntirubeolaNo;
			
			item.AntitetanicaVigenteNo = varAntitetanicaVigenteNo;
			
			item.AntitetanicaVigenteSi = varAntitetanicaVigenteSi;
			
			item.Antitetanica1DosisMesGestacion = varAntitetanica1DosisMesGestacion;
			
			item.Antitetanica2DosisMesGestacion = varAntitetanica2DosisMesGestacion;
			
			item.ExamenOdotologicoNormalSi = varExamenOdotologicoNormalSi;
			
			item.ExamenOdotologicoNormalNo = varExamenOdotologicoNormalNo;
			
			item.ExamenMamasNormalSi = varExamenMamasNormalSi;
			
			item.ExamenMamasNormalNo = varExamenMamasNormalNo;
			
			item.CervixInspeccionVisualNormal = varCervixInspeccionVisualNormal;
			
			item.CervixInspeccionVisualAnormal = varCervixInspeccionVisualAnormal;
			
			item.CervixInspeccionVisualNoSeHizo = varCervixInspeccionVisualNoSeHizo;
			
			item.CervixPAPNormal = varCervixPAPNormal;
			
			item.CervixPAPAnormal = varCervixPAPAnormal;
			
			item.CervixPAPNoSeHizo = varCervixPAPNoSeHizo;
			
			item.CervixCOLPNormal = varCervixCOLPNormal;
			
			item.CervixCOLPAnormal = varCervixCOLPAnormal;
			
			item.CervixCOLPNoSeHizo = varCervixCOLPNoSeHizo;
			
			item.Grupo = varGrupo;
			
			item.RHPositivo = varRHPositivo;
			
			item.RHNegativo = varRHNegativo;
			
			item.InmunizacionSi = varInmunizacionSi;
			
			item.InmunizacionNo = varInmunizacionNo;
			
			item.GammaGlobulinaNo = varGammaGlobulinaNo;
			
			item.GammaGlobulinaSi = varGammaGlobulinaSi;
			
			item.GammaGlobulinaNoCorresponde = varGammaGlobulinaNoCorresponde;
			
			item.ToxoPlasmosisMenor20SemLGGNegativo = varToxoPlasmosisMenor20SemLGGNegativo;
			
			item.ToxoPlasmosisMenor20SemLGGPositivo = varToxoPlasmosisMenor20SemLGGPositivo;
			
			item.ToxoPlasmosisMenor20SemLGGNoSeHizo = varToxoPlasmosisMenor20SemLGGNoSeHizo;
			
			item.ToxoPlasmosisMayor20SemLGGNegativo = varToxoPlasmosisMayor20SemLGGNegativo;
			
			item.ToxoPlasmosisMayor20SemLGGPositivo = varToxoPlasmosisMayor20SemLGGPositivo;
			
			item.ToxoPlasmosisMayor20SemLGGNoSeHizo = varToxoPlasmosisMayor20SemLGGNoSeHizo;
			
			item.ToxoPlasmosis1ConsultaLGMNegativo = varToxoPlasmosis1ConsultaLGMNegativo;
			
			item.ToxoPlasmosis1ConsultaLGMPositivo = varToxoPlasmosis1ConsultaLGMPositivo;
			
			item.ToxoPlasmosis1ConsultaLGMNoSeHizo = varToxoPlasmosis1ConsultaLGMNoSeHizo;
			
			item.ChagasNegativo = varChagasNegativo;
			
			item.ChagasPositivo = varChagasPositivo;
			
			item.ChagasNoSeHizo = varChagasNoSeHizo;
			
			item.HepatitisBNegativo = varHepatitisBNegativo;
			
			item.HepatitisBPositivo = varHepatitisBPositivo;
			
			item.HepatitisBNoSeHizo = varHepatitisBNoSeHizo;
			
			item.BacteriuraMenor20SemNormal = varBacteriuraMenor20SemNormal;
			
			item.BacteriuraMenor20SemAnormal = varBacteriuraMenor20SemAnormal;
			
			item.BacteriuraMenor20SemNoSeHizo = varBacteriuraMenor20SemNoSeHizo;
			
			item.BacteriuraMayor20SemNormal = varBacteriuraMayor20SemNormal;
			
			item.BacteriuraMayor20SemAnormal = varBacteriuraMayor20SemAnormal;
			
			item.BacteriuraMayor20SemNoSeHizo = varBacteriuraMayor20SemNoSeHizo;
			
			item.GlucemiaMenor20Sem = varGlucemiaMenor20Sem;
			
			item.GlucemiaMenor20SemMayor105 = varGlucemiaMenor20SemMayor105;
			
			item.GlucemiaMayor20Sem = varGlucemiaMayor20Sem;
			
			item.GlucemiaMayor20SemMayor105 = varGlucemiaMayor20SemMayor105;
			
			item.VIHCRSi = varVIHCRSi;
			
			item.VIHCRNo = varVIHCRNo;
			
			item.VIHPrimerMuestraSolicitadoSi = varVIHPrimerMuestraSolicitadoSi;
			
			item.VIHPrimerMuestraSolicitadoNo = varVIHPrimerMuestraSolicitadoNo;
			
			item.VIHPrimerMuestraRealizadoSi = varVIHPrimerMuestraRealizadoSi;
			
			item.VIHPrimerMuestraRealizadoNo = varVIHPrimerMuestraRealizadoNo;
			
			item.VIHPrimerMuestraFecha = varVIHPrimerMuestraFecha;
			
			item.HBMenor20Sem = varHBMenor20Sem;
			
			item.HBMenor20SemMenor11 = varHBMenor20SemMenor11;
			
			item.HBMayor20Sem = varHBMayor20Sem;
			
			item.HBMayor20SemMenor11 = varHBMayor20SemMenor11;
			
			item.FeIndicadoSi = varFeIndicadoSi;
			
			item.FeIndicadoNo = varFeIndicadoNo;
			
			item.FolatosIndicadosSi = varFolatosIndicadosSi;
			
			item.FolatosIndicadosNo = varFolatosIndicadosNo;
			
			item.EstreptococoB3537SemanasNegativo = varEstreptococoB3537SemanasNegativo;
			
			item.EstreptococoB3537SemanasPositivo = varEstreptococoB3537SemanasPositivo;
			
			item.EstreptococoB3537SemanasNoSeHizo = varEstreptococoB3537SemanasNoSeHizo;
			
			item.PreparacionPartoSi = varPreparacionPartoSi;
			
			item.PreparacionPartoNo = varPreparacionPartoNo;
			
			item.ConsejeriaLactanciaMaternaSi = varConsejeriaLactanciaMaternaSi;
			
			item.ConsejeriaLactanciaMaternaNo = varConsejeriaLactanciaMaternaNo;
			
			item.SifilisTratParejaMenor20SemNo = varSifilisTratParejaMenor20SemNo;
			
			item.SifilisTratParejaMenor20SemSi = varSifilisTratParejaMenor20SemSi;
			
			item.SifilisTratParejaMenor20SemSinDatos = varSifilisTratParejaMenor20SemSinDatos;
			
			item.SifilisTratParejaMenor20SemNoCorresponde = varSifilisTratParejaMenor20SemNoCorresponde;
			
			item.SifilisTratParejaMayor20SemNo = varSifilisTratParejaMayor20SemNo;
			
			item.SifilisTratParejaMayor20SemSi = varSifilisTratParejaMayor20SemSi;
			
			item.SifilisTratParejaMayor20SemSinDatos = varSifilisTratParejaMayor20SemSinDatos;
			
			item.SifilisTratParejaMayor20SemNoCorresponde = varSifilisTratParejaMayor20SemNoCorresponde;
			
			item.OAAntecedenteEclampsiaSi = varOAAntecedenteEclampsiaSi;
			
			item.OAAntecedenteEclampsiaNo = varOAAntecedenteEclampsiaNo;
			
			item.OAActualEclampsiaSi = varOAActualEclampsiaSi;
			
			item.OAActualEclampsiaNo = varOAActualEclampsiaNo;
			
			item.OAAntecedentePreeclampsiaSi = varOAAntecedentePreeclampsiaSi;
			
			item.OAAntecedentePreeclampsiaNo = varOAAntecedentePreeclampsiaNo;
			
			item.OAActualPreeclampsiaSi = varOAActualPreeclampsiaSi;
			
			item.OAActualPreeclampsiaNo = varOAActualPreeclampsiaNo;
			
			item.OAAntecedenteCirugiaGinUrinarSi = varOAAntecedenteCirugiaGinUrinarSi;
			
			item.OAAntecedenteCirugiaGinUrinarNo = varOAAntecedenteCirugiaGinUrinarNo;
			
			item.OAActualCirugiaGinUrinarSi = varOAActualCirugiaGinUrinarSi;
			
			item.OAActualCirugiaGinUrinarNo = varOAActualCirugiaGinUrinarNo;
			
			item.OAAntecedenteAPPrematuroSi = varOAAntecedenteAPPrematuroSi;
			
			item.OAAntecedenteAPPrematuroNo = varOAAntecedenteAPPrematuroNo;
			
			item.OAActualAPPrematuroSi = varOAActualAPPrematuroSi;
			
			item.OAActualAPPrematuroNo = varOAActualAPPrematuroNo;
			
			item.OAAntecedenteRCIUSi = varOAAntecedenteRCIUSi;
			
			item.OAAntecedenteRCIUNo = varOAAntecedenteRCIUNo;
			
			item.OAActualRCIUSi = varOAActualRCIUSi;
			
			item.OAActualRCIUNo = varOAActualRCIUNo;
			
			item.OAAntecedenteHemorragiaObstetricaSi = varOAAntecedenteHemorragiaObstetricaSi;
			
			item.OAAntecedenteHemorragiaObstetricaNo = varOAAntecedenteHemorragiaObstetricaNo;
			
			item.OAActualHemorragiaObstetricaSi = varOAActualHemorragiaObstetricaSi;
			
			item.OAActualHemorragiaObstetricaNo = varOAActualHemorragiaObstetricaNo;
			
			item.OAAntecedenteMacrosomiaFetalSi = varOAAntecedenteMacrosomiaFetalSi;
			
			item.OAAntecedenteMacrosomiaFetalNo = varOAAntecedenteMacrosomiaFetalNo;
			
			item.OAActualMacrosomiaFetalSi = varOAActualMacrosomiaFetalSi;
			
			item.OAActualMacrosomiaFetalNo = varOAActualMacrosomiaFetalNo;
			
			item.OAAntecedentePolihidramniosSi = varOAAntecedentePolihidramniosSi;
			
			item.OAAntecedentePolihidramniosNo = varOAAntecedentePolihidramniosNo;
			
			item.OAActualPolihidramniosSi = varOAActualPolihidramniosSi;
			
			item.OAActualPolihidramniosNo = varOAActualPolihidramniosNo;
			
			item.OAAntecedenteOligoanmiosSi = varOAAntecedenteOligoanmiosSi;
			
			item.OAAntecedenteOligoanmiosNo = varOAAntecedenteOligoanmiosNo;
			
			item.OAActualOligoanmiosSi = varOAActualOligoanmiosSi;
			
			item.OAActualOligoanmiosNo = varOAActualOligoanmiosNo;
			
			item.OAAntecedenteRotPremMembranasSi = varOAAntecedenteRotPremMembranasSi;
			
			item.OAAntecedenteRotPremMembranasNo = varOAAntecedenteRotPremMembranasNo;
			
			item.OAActualRotPremMembranasSi = varOAActualRotPremMembranasSi;
			
			item.OAActualRotPremMembranasNo = varOAActualRotPremMembranasNo;
			
			item.OAAntecedenteIsoinmunizacionesSi = varOAAntecedenteIsoinmunizacionesSi;
			
			item.OAAntecedenteIsoinmunizacionesNo = varOAAntecedenteIsoinmunizacionesNo;
			
			item.OAActualIsoinmunizacionesSi = varOAActualIsoinmunizacionesSi;
			
			item.OAActualIsoinmunizacionesNo = varOAActualIsoinmunizacionesNo;
			
			item.OAAntecedenteColestasisSi = varOAAntecedenteColestasisSi;
			
			item.OAAntecedenteColestasisNo = varOAAntecedenteColestasisNo;
			
			item.OAActualColestasisSi = varOAActualColestasisSi;
			
			item.OAActualColestasisNo = varOAActualColestasisNo;
			
			item.OAAntecedenteMortPerinatalRecurrenteSi = varOAAntecedenteMortPerinatalRecurrenteSi;
			
			item.OAAntecedenteMortPerinatalRecurrenteNo = varOAAntecedenteMortPerinatalRecurrenteNo;
			
			item.OAAntecedenteRetencionPlacentaSi = varOAAntecedenteRetencionPlacentaSi;
			
			item.OAAntecedenteRetencionPlacentaNo = varOAAntecedenteRetencionPlacentaNo;
			
			item.OAAntecedenteDistociaHombrosSi = varOAAntecedenteDistociaHombrosSi;
			
			item.OAAntecedenteDistociaHombrosNo = varOAAntecedenteDistociaHombrosNo;
			
			item.OAAntecedenteMalformCongenSi = varOAAntecedenteMalformCongenSi;
			
			item.OAAntecedenteMalformCongenNo = varOAAntecedenteMalformCongenNo;
			
			item.FactorRiesgoEmbarazoSinContSocialSi = varFactorRiesgoEmbarazoSinContSocialSi;
			
			item.FactorRiesgoEmbarazoSinContSocialNo = varFactorRiesgoEmbarazoSinContSocialNo;
			
			item.FactorRiesgoFamiliaSinIngresosFijosSi = varFactorRiesgoFamiliaSinIngresosFijosSi;
			
			item.FactorRiesgoFamiliaSinIngresosFijosNo = varFactorRiesgoFamiliaSinIngresosFijosNo;
			
			item.FactorRiesgoEmbarazoFuertRechazadoSi = varFactorRiesgoEmbarazoFuertRechazadoSi;
			
			item.FactorRiesgoEmbarazoFuertRechazadoNo = varFactorRiesgoEmbarazoFuertRechazadoNo;
			
			item.FactorRiesgoHijosDadosAdopcionSi = varFactorRiesgoHijosDadosAdopcionSi;
			
			item.FactorRiesgoHijosDadosAdopcionNo = varFactorRiesgoHijosDadosAdopcionNo;
			
			item.FactorRiesgoViviendaSinServiciosBasicosSi = varFactorRiesgoViviendaSinServiciosBasicosSi;
			
			item.FactorRiesgoViviendaSinServiciosBasicosNo = varFactorRiesgoViviendaSinServiciosBasicosNo;
			
			item.CaptacionOportunaAntes16sem = varCaptacionOportunaAntes16sem;
			
			item.CaptacionOportunaDespues16sem = varCaptacionOportunaDespues16sem;
			
			item.FechaMuestraPAP = varFechaMuestraPAP;
			
			item.FechaTripleAcelular = varFechaTripleAcelular;
			
			item.FechaAntigripal = varFechaAntigripal;
			
			item.VIHSegundaMuestraSolicitadoSi = varVIHSegundaMuestraSolicitadoSi;
			
			item.VIHSegundaMuestraSolicitadoNo = varVIHSegundaMuestraSolicitadoNo;
			
			item.VIHSegundaMuestraRealizadoSi = varVIHSegundaMuestraRealizadoSi;
			
			item.VIHSegundaMuestraRealizadoNo = varVIHSegundaMuestraRealizadoNo;
			
			item.VIHSegundaMuestraFecha = varVIHSegundaMuestraFecha;
			
			item.VIHTercerMuestraSolicitadoSi = varVIHTercerMuestraSolicitadoSi;
			
			item.VIHTercerMuestraSolicitadoNo = varVIHTercerMuestraSolicitadoNo;
			
			item.VIHTercerMuestraRealizadoSi = varVIHTercerMuestraRealizadoSi;
			
			item.VIHTercerMuestraRealizadoNo = varVIHTercerMuestraRealizadoNo;
			
			item.VIHTercerMuestraFecha = varVIHTercerMuestraFecha;
			
			item.SifilisPruebaNoTrepoPrimerMuestra = varSifilisPruebaNoTrepoPrimerMuestra;
			
			item.SifilisPruebaNoTrepoPrimerMuestraNegativo = varSifilisPruebaNoTrepoPrimerMuestraNegativo;
			
			item.SifilisPruebaNoTrepoPrimerMuestraPositivo = varSifilisPruebaNoTrepoPrimerMuestraPositivo;
			
			item.SifilisPruebaNoTrepoPrimerMuestraSinDatos = varSifilisPruebaNoTrepoPrimerMuestraSinDatos;
			
			item.SifilisPruebaNoTrepoPrimerMuestraFecha = varSifilisPruebaNoTrepoPrimerMuestraFecha;
			
			item.SifilisPruebaNoTrepoSegundaMuestra = varSifilisPruebaNoTrepoSegundaMuestra;
			
			item.SifilisPruebaNoTrepoSegundaMuestraNegativo = varSifilisPruebaNoTrepoSegundaMuestraNegativo;
			
			item.SifilisPruebaNoTrepoSegundaMuestraPositivo = varSifilisPruebaNoTrepoSegundaMuestraPositivo;
			
			item.SifilisPruebaNoTrepoSegundaMuestraSinDatos = varSifilisPruebaNoTrepoSegundaMuestraSinDatos;
			
			item.SifilisPruebaNoTrepoSegundaMuestraFecha = varSifilisPruebaNoTrepoSegundaMuestraFecha;
			
			item.SifilisPruebaNoTrepoTercerMuestra = varSifilisPruebaNoTrepoTercerMuestra;
			
			item.SifilisPruebaNoTrepoTercerMuestraNegativo = varSifilisPruebaNoTrepoTercerMuestraNegativo;
			
			item.SifilisPruebaNoTrepoTercerMuestraPositivo = varSifilisPruebaNoTrepoTercerMuestraPositivo;
			
			item.SifilisPruebaNoTrepoTercerMuestraSinDatos = varSifilisPruebaNoTrepoTercerMuestraSinDatos;
			
			item.SifilisPruebaNoTrepoTercerMuestraFecha = varSifilisPruebaNoTrepoTercerMuestraFecha;
			
			item.SifilisPruebaTrepoPrimerMuestra = varSifilisPruebaTrepoPrimerMuestra;
			
			item.SifilisPruebaTrepoPrimerMuestraNegativo = varSifilisPruebaTrepoPrimerMuestraNegativo;
			
			item.SifilisPruebaTrepoPrimerMuestraPositivo = varSifilisPruebaTrepoPrimerMuestraPositivo;
			
			item.SifilisPruebaTrepoPrimerMuestraSinDatos = varSifilisPruebaTrepoPrimerMuestraSinDatos;
			
			item.SifilisPruebaTrepoPrimerMuestraNoCorresponde = varSifilisPruebaTrepoPrimerMuestraNoCorresponde;
			
			item.SifilisPruebaTrepoPrimerMuestraFecha = varSifilisPruebaTrepoPrimerMuestraFecha;
			
			item.SifilisPruebaTrepoSegundaMuestra = varSifilisPruebaTrepoSegundaMuestra;
			
			item.SifilisPruebaTrepoSegundaMuestraNegativo = varSifilisPruebaTrepoSegundaMuestraNegativo;
			
			item.SifilisPruebaTrepoSegundaMuestraPositivo = varSifilisPruebaTrepoSegundaMuestraPositivo;
			
			item.SifilisPruebaTrepoSegundaMuestraSinDatos = varSifilisPruebaTrepoSegundaMuestraSinDatos;
			
			item.SifilisPruebaTrepoSegundaMuestraNoCorresponde = varSifilisPruebaTrepoSegundaMuestraNoCorresponde;
			
			item.SifilisPruebaTrepoSegundaMuestraFecha = varSifilisPruebaTrepoSegundaMuestraFecha;
			
			item.SifilisPruebaTrepoTercerMuestra = varSifilisPruebaTrepoTercerMuestra;
			
			item.SifilisPruebaTrepoTercerMuestraNegativo = varSifilisPruebaTrepoTercerMuestraNegativo;
			
			item.SifilisPruebaTrepoTercerMuestraPositivo = varSifilisPruebaTrepoTercerMuestraPositivo;
			
			item.SifilisPruebaTrepoTercerMuestraSinDatos = varSifilisPruebaTrepoTercerMuestraSinDatos;
			
			item.SifilisPruebaTrepoTercerMuestraNoCorresponde = varSifilisPruebaTrepoTercerMuestraNoCorresponde;
			
			item.SifilisPruebaTrepoTercerMuestraFecha = varSifilisPruebaTrepoTercerMuestraFecha;
			
			item.SifilisTratamientoPrimerMuestra = varSifilisTratamientoPrimerMuestra;
			
			item.SifilisTratamientoPrimerMuestraNo = varSifilisTratamientoPrimerMuestraNo;
			
			item.SifilisTratamientoPrimerMuestraSi = varSifilisTratamientoPrimerMuestraSi;
			
			item.SifilisTratamientoPrimerMuestraSinDatos = varSifilisTratamientoPrimerMuestraSinDatos;
			
			item.SifilisTratamientoPrimerMuestraNoCorresponde = varSifilisTratamientoPrimerMuestraNoCorresponde;
			
			item.SifilisTratamientoPrimerMuestraFecha = varSifilisTratamientoPrimerMuestraFecha;
			
			item.SifilisTratamientoSegundaMuestra = varSifilisTratamientoSegundaMuestra;
			
			item.SifilisTratamientoSegundaMuestraNo = varSifilisTratamientoSegundaMuestraNo;
			
			item.SifilisTratamientoSegundaMuestraSi = varSifilisTratamientoSegundaMuestraSi;
			
			item.SifilisTratamientoSegundaMuestraSinDatos = varSifilisTratamientoSegundaMuestraSinDatos;
			
			item.SifilisTratamientoSegundaMuestraNoCorresponde = varSifilisTratamientoSegundaMuestraNoCorresponde;
			
			item.SifilisTratamientoSegundaMuestraFecha = varSifilisTratamientoSegundaMuestraFecha;
			
			item.SifilisTratamientoTercerMuestra = varSifilisTratamientoTercerMuestra;
			
			item.SifilisTratamientoTercerMuestraNo = varSifilisTratamientoTercerMuestraNo;
			
			item.SifilisTratamientoTercerMuestraSi = varSifilisTratamientoTercerMuestraSi;
			
			item.SifilisTratamientoTercerMuestraSinDatos = varSifilisTratamientoTercerMuestraSinDatos;
			
			item.SifilisTratamientoTercerMuestraNoCorresponde = varSifilisTratamientoTercerMuestraNoCorresponde;
			
			item.SifilisTratamientoTercerMuestraFecha = varSifilisTratamientoTercerMuestraFecha;
			
			item.Activa = varActiva;
			
			item.Observaciones = varObservaciones;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IdEfectorTrasladoUt = varIdEfectorTrasladoUt;
			
			item.DiabetesActualSi = varDiabetesActualSi;
			
			item.DiabetesActualNo = varDiabetesActualNo;
			
			item.AnemiaSi = varAnemiaSi;
			
			item.AnemiaNo = varAnemiaNo;
			
			item.NumeroIdentidad = varNumeroIdentidad;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdHistoriaClinicaPerinatal,int varIdEfector,int varIdPaciente,string varNombre,string varApellido,string varDomicilio,string varDni,string varLocalidad,string varTelefono,DateTime? varFechaNacimiento,int? varEdad,string varDatosDeContacto,bool? varEdadMenor15Mayor35,bool? varEtniaBlanca,bool? varEtniaIndigena,bool? varEtniaMestiza,bool? varEtniaNegra,bool? varEtniaOtra,bool? varAlfabetaSi,bool? varAlfabetaNo,bool? varEstudiosNinguno,bool? varEstudiosPrimario,bool? varEstudiosSecundario,bool? varEstudiosUniversitario,int? varAñosMayorNivel,bool? varEstadoCivilCasada,bool? varEstadoCivilUnionEstable,bool? varEstadoCivilSoltera,bool? varEstadoCivilOtro,bool? varViveSolaSi,bool? varViveSolaNo,string varLugarControlPerinatal,string varLugarPartoAborto,bool? varAntFamTBCSi,bool? varAntFamTBCNo,bool? varAntFamDiabetesSi,bool? varAntFamDiabetesNo,bool? varAntFamHipertensionSi,bool? varAntFamHipertensionNo,bool? varAntFamInfeccionUrinariaSi,bool? varAntFamInfeccionUrinariaNo,bool? varAntFamOtrasInfeccionesSi,bool? varAntFamOtrasInfeccionesNo,bool? varAntFamOtroSi,bool? varAntFamOtroNo,bool? varAntPerTBCSi,bool? varAntPerTBCNo,bool? varAntPerDiabetesI,bool? varAntPerDiabetesII,bool? varAntPerDiabetesG,bool? varAntPerDiabetesNo,bool? varAntPerHipertensionSi,bool? varAntPerHipertensionNo,bool? varAntPerInfeccionUrinariaSi,bool? varAntPerInfeccionUrinariaNo,bool? varAntPerOtrasInfeccionesSi,bool? varAntPerOtrasInfeccionesNo,bool? varAntPerOtroSi,bool? varAntPerOtroNo,bool? varAntPerInfertilidadSi,bool? varAntPerInfertilidadNo,bool? varAntPerCardiopatiaSi,bool? varAntPerCardiopatiaNo,bool? varAntPerNefropatiaSi,bool? varAntPerNefropatiaNo,bool? varAntPerViolenciaSi,bool? varAntPerViolenciaNo,bool? varAntPerAlergiaMedicamentoSi,bool? varAntPerAlergiaMedicamentoNo,string varAntecedentesObservacion,int? varGestasPrevias,int? varAbortos,int? varEmbEctopicos,bool? varAbortos3concecutivos,int? varPartos,int? varPartosVaginales,int? varCesareas,int? varNacidosVivos,int? varNacidosMuertos,int? varViven,int? varMuertosPrimerSemana,int? varMuertosDespuesPrimerSemana,bool? varAntecedentesGemelaresSi,bool? varAntecedentesGemelaresNo,bool? varUltPrevioNC,bool? varUltPrevioNormal,bool? varUltPrevioMenor2500,bool? varUltPrevioMayor4000,DateTime? varFinEmbarazoAnterior,bool? varFinEmbAnteriorMenor1Año,bool? varEmbarazoPlaneadoSi,bool? varEmbarazoPlaneadoNo,bool? varFracMetAnticonceptivoNoUsaba,bool? varFracMetAnticonceptivoBarrera,bool? varFracMetAnticonceptivoDIU,bool? varFracMetAnticonceptivoHormonal,bool? varFracMetAnticonceptivoEmergencia,bool? varFracMetAnticonceptivoNatural,decimal? varPesoAnterior,int? varTalla,DateTime? varFum,DateTime? varFpp,bool? varEGConfiableFUMSi,bool? varEGConfiableFUMNo,bool? varEGConfiableEcoMenor20semanasSi,bool? varEGConfiableEcoMenor20semanasNo,bool? varFumaActivo1TrimSi,bool? varFumaActivo1TrimNo,bool? varFumaActivo2TrimSi,bool? varFumaActivo2TrimNo,bool? varFumaActivo3TrimSi,bool? varFumaActivo3TrimNo,bool? varFumaPasivo1TrimSi,bool? varFumaPasivo1TrimNo,bool? varFumaPasivo2TrimSi,bool? varFumaPasivo2TrimNo,bool? varFumaPasivo3TrimSi,bool? varFumaPasivo3TrimNo,bool? varDrogas1TrimSi,bool? varDrogas1TrimNo,bool? varDrogas2TrimSi,bool? varDrogas2TrimNo,bool? varDrogas3TrimSi,bool? varDrogas3TrimNo,bool? varAlcohol1TrimSi,bool? varAlcohol1TrimNo,bool? varAlcohol2TrimSi,bool? varAlcohol2TrimNo,bool? varAlcohol3TrimSi,bool? varAlcohol3TrimNo,bool? varViolencia1TrimSi,bool? varViolencia1TrimNo,bool? varViolencia2TrimSi,bool? varViolencia2TrimNo,bool? varViolencia3TrimSi,bool? varViolencia3TrimNo,bool? varAntirubeolaPrevia,bool? varAntirubeolaNoSabe,bool? varAntirubeolaEmbarazo,bool? varAntirubeolaNo,bool? varAntitetanicaVigenteNo,bool? varAntitetanicaVigenteSi,int? varAntitetanica1DosisMesGestacion,int? varAntitetanica2DosisMesGestacion,bool? varExamenOdotologicoNormalSi,bool? varExamenOdotologicoNormalNo,bool? varExamenMamasNormalSi,bool? varExamenMamasNormalNo,bool? varCervixInspeccionVisualNormal,bool? varCervixInspeccionVisualAnormal,bool? varCervixInspeccionVisualNoSeHizo,bool? varCervixPAPNormal,bool? varCervixPAPAnormal,bool? varCervixPAPNoSeHizo,bool? varCervixCOLPNormal,bool? varCervixCOLPAnormal,bool? varCervixCOLPNoSeHizo,string varGrupo,bool? varRHPositivo,bool? varRHNegativo,bool? varInmunizacionSi,bool? varInmunizacionNo,bool? varGammaGlobulinaNo,bool? varGammaGlobulinaSi,bool? varGammaGlobulinaNoCorresponde,bool? varToxoPlasmosisMenor20SemLGGNegativo,bool? varToxoPlasmosisMenor20SemLGGPositivo,bool? varToxoPlasmosisMenor20SemLGGNoSeHizo,bool? varToxoPlasmosisMayor20SemLGGNegativo,bool? varToxoPlasmosisMayor20SemLGGPositivo,bool? varToxoPlasmosisMayor20SemLGGNoSeHizo,bool? varToxoPlasmosis1ConsultaLGMNegativo,bool? varToxoPlasmosis1ConsultaLGMPositivo,bool? varToxoPlasmosis1ConsultaLGMNoSeHizo,bool? varChagasNegativo,bool? varChagasPositivo,bool? varChagasNoSeHizo,bool? varHepatitisBNegativo,bool? varHepatitisBPositivo,bool? varHepatitisBNoSeHizo,bool? varBacteriuraMenor20SemNormal,bool? varBacteriuraMenor20SemAnormal,bool? varBacteriuraMenor20SemNoSeHizo,bool? varBacteriuraMayor20SemNormal,bool? varBacteriuraMayor20SemAnormal,bool? varBacteriuraMayor20SemNoSeHizo,decimal? varGlucemiaMenor20Sem,bool? varGlucemiaMenor20SemMayor105,decimal? varGlucemiaMayor20Sem,bool? varGlucemiaMayor20SemMayor105,bool? varVIHCRSi,bool? varVIHCRNo,bool? varVIHPrimerMuestraSolicitadoSi,bool? varVIHPrimerMuestraSolicitadoNo,bool? varVIHPrimerMuestraRealizadoSi,bool? varVIHPrimerMuestraRealizadoNo,DateTime? varVIHPrimerMuestraFecha,decimal? varHBMenor20Sem,bool? varHBMenor20SemMenor11,decimal? varHBMayor20Sem,bool? varHBMayor20SemMenor11,bool? varFeIndicadoSi,bool? varFeIndicadoNo,bool? varFolatosIndicadosSi,bool? varFolatosIndicadosNo,bool? varEstreptococoB3537SemanasNegativo,bool? varEstreptococoB3537SemanasPositivo,bool? varEstreptococoB3537SemanasNoSeHizo,bool? varPreparacionPartoSi,bool? varPreparacionPartoNo,bool? varConsejeriaLactanciaMaternaSi,bool? varConsejeriaLactanciaMaternaNo,bool? varSifilisTratParejaMenor20SemNo,bool? varSifilisTratParejaMenor20SemSi,bool? varSifilisTratParejaMenor20SemSinDatos,bool? varSifilisTratParejaMenor20SemNoCorresponde,bool? varSifilisTratParejaMayor20SemNo,bool? varSifilisTratParejaMayor20SemSi,bool? varSifilisTratParejaMayor20SemSinDatos,bool? varSifilisTratParejaMayor20SemNoCorresponde,bool? varOAAntecedenteEclampsiaSi,bool? varOAAntecedenteEclampsiaNo,bool? varOAActualEclampsiaSi,bool? varOAActualEclampsiaNo,bool? varOAAntecedentePreeclampsiaSi,bool? varOAAntecedentePreeclampsiaNo,bool? varOAActualPreeclampsiaSi,bool? varOAActualPreeclampsiaNo,bool? varOAAntecedenteCirugiaGinUrinarSi,bool? varOAAntecedenteCirugiaGinUrinarNo,bool? varOAActualCirugiaGinUrinarSi,bool? varOAActualCirugiaGinUrinarNo,bool? varOAAntecedenteAPPrematuroSi,bool? varOAAntecedenteAPPrematuroNo,bool? varOAActualAPPrematuroSi,bool? varOAActualAPPrematuroNo,bool? varOAAntecedenteRCIUSi,bool? varOAAntecedenteRCIUNo,bool? varOAActualRCIUSi,bool? varOAActualRCIUNo,bool? varOAAntecedenteHemorragiaObstetricaSi,bool? varOAAntecedenteHemorragiaObstetricaNo,bool? varOAActualHemorragiaObstetricaSi,bool? varOAActualHemorragiaObstetricaNo,bool? varOAAntecedenteMacrosomiaFetalSi,bool? varOAAntecedenteMacrosomiaFetalNo,bool? varOAActualMacrosomiaFetalSi,bool? varOAActualMacrosomiaFetalNo,bool? varOAAntecedentePolihidramniosSi,bool? varOAAntecedentePolihidramniosNo,bool? varOAActualPolihidramniosSi,bool? varOAActualPolihidramniosNo,bool? varOAAntecedenteOligoanmiosSi,bool? varOAAntecedenteOligoanmiosNo,bool? varOAActualOligoanmiosSi,bool? varOAActualOligoanmiosNo,bool? varOAAntecedenteRotPremMembranasSi,bool? varOAAntecedenteRotPremMembranasNo,bool? varOAActualRotPremMembranasSi,bool? varOAActualRotPremMembranasNo,bool? varOAAntecedenteIsoinmunizacionesSi,bool? varOAAntecedenteIsoinmunizacionesNo,bool? varOAActualIsoinmunizacionesSi,bool? varOAActualIsoinmunizacionesNo,bool? varOAAntecedenteColestasisSi,bool? varOAAntecedenteColestasisNo,bool? varOAActualColestasisSi,bool? varOAActualColestasisNo,bool? varOAAntecedenteMortPerinatalRecurrenteSi,bool? varOAAntecedenteMortPerinatalRecurrenteNo,bool? varOAAntecedenteRetencionPlacentaSi,bool? varOAAntecedenteRetencionPlacentaNo,bool? varOAAntecedenteDistociaHombrosSi,bool? varOAAntecedenteDistociaHombrosNo,bool? varOAAntecedenteMalformCongenSi,bool? varOAAntecedenteMalformCongenNo,bool? varFactorRiesgoEmbarazoSinContSocialSi,bool? varFactorRiesgoEmbarazoSinContSocialNo,bool? varFactorRiesgoFamiliaSinIngresosFijosSi,bool? varFactorRiesgoFamiliaSinIngresosFijosNo,bool? varFactorRiesgoEmbarazoFuertRechazadoSi,bool? varFactorRiesgoEmbarazoFuertRechazadoNo,bool? varFactorRiesgoHijosDadosAdopcionSi,bool? varFactorRiesgoHijosDadosAdopcionNo,bool? varFactorRiesgoViviendaSinServiciosBasicosSi,bool? varFactorRiesgoViviendaSinServiciosBasicosNo,bool? varCaptacionOportunaAntes16sem,bool? varCaptacionOportunaDespues16sem,DateTime? varFechaMuestraPAP,DateTime? varFechaTripleAcelular,DateTime? varFechaAntigripal,bool? varVIHSegundaMuestraSolicitadoSi,bool? varVIHSegundaMuestraSolicitadoNo,bool? varVIHSegundaMuestraRealizadoSi,bool? varVIHSegundaMuestraRealizadoNo,DateTime? varVIHSegundaMuestraFecha,bool? varVIHTercerMuestraSolicitadoSi,bool? varVIHTercerMuestraSolicitadoNo,bool? varVIHTercerMuestraRealizadoSi,bool? varVIHTercerMuestraRealizadoNo,DateTime? varVIHTercerMuestraFecha,decimal? varSifilisPruebaNoTrepoPrimerMuestra,bool? varSifilisPruebaNoTrepoPrimerMuestraNegativo,bool? varSifilisPruebaNoTrepoPrimerMuestraPositivo,bool? varSifilisPruebaNoTrepoPrimerMuestraSinDatos,DateTime? varSifilisPruebaNoTrepoPrimerMuestraFecha,decimal? varSifilisPruebaNoTrepoSegundaMuestra,bool? varSifilisPruebaNoTrepoSegundaMuestraNegativo,bool? varSifilisPruebaNoTrepoSegundaMuestraPositivo,bool? varSifilisPruebaNoTrepoSegundaMuestraSinDatos,DateTime? varSifilisPruebaNoTrepoSegundaMuestraFecha,decimal? varSifilisPruebaNoTrepoTercerMuestra,bool? varSifilisPruebaNoTrepoTercerMuestraNegativo,bool? varSifilisPruebaNoTrepoTercerMuestraPositivo,bool? varSifilisPruebaNoTrepoTercerMuestraSinDatos,DateTime? varSifilisPruebaNoTrepoTercerMuestraFecha,decimal? varSifilisPruebaTrepoPrimerMuestra,bool? varSifilisPruebaTrepoPrimerMuestraNegativo,bool? varSifilisPruebaTrepoPrimerMuestraPositivo,bool? varSifilisPruebaTrepoPrimerMuestraSinDatos,bool? varSifilisPruebaTrepoPrimerMuestraNoCorresponde,DateTime? varSifilisPruebaTrepoPrimerMuestraFecha,decimal? varSifilisPruebaTrepoSegundaMuestra,bool? varSifilisPruebaTrepoSegundaMuestraNegativo,bool? varSifilisPruebaTrepoSegundaMuestraPositivo,bool? varSifilisPruebaTrepoSegundaMuestraSinDatos,bool? varSifilisPruebaTrepoSegundaMuestraNoCorresponde,DateTime? varSifilisPruebaTrepoSegundaMuestraFecha,decimal? varSifilisPruebaTrepoTercerMuestra,bool? varSifilisPruebaTrepoTercerMuestraNegativo,bool? varSifilisPruebaTrepoTercerMuestraPositivo,bool? varSifilisPruebaTrepoTercerMuestraSinDatos,bool? varSifilisPruebaTrepoTercerMuestraNoCorresponde,DateTime? varSifilisPruebaTrepoTercerMuestraFecha,decimal? varSifilisTratamientoPrimerMuestra,bool? varSifilisTratamientoPrimerMuestraNo,bool? varSifilisTratamientoPrimerMuestraSi,bool? varSifilisTratamientoPrimerMuestraSinDatos,bool? varSifilisTratamientoPrimerMuestraNoCorresponde,DateTime? varSifilisTratamientoPrimerMuestraFecha,decimal? varSifilisTratamientoSegundaMuestra,bool? varSifilisTratamientoSegundaMuestraNo,bool? varSifilisTratamientoSegundaMuestraSi,bool? varSifilisTratamientoSegundaMuestraSinDatos,bool? varSifilisTratamientoSegundaMuestraNoCorresponde,DateTime? varSifilisTratamientoSegundaMuestraFecha,decimal? varSifilisTratamientoTercerMuestra,bool? varSifilisTratamientoTercerMuestraNo,bool? varSifilisTratamientoTercerMuestraSi,bool? varSifilisTratamientoTercerMuestraSinDatos,bool? varSifilisTratamientoTercerMuestraNoCorresponde,DateTime? varSifilisTratamientoTercerMuestraFecha,bool varActiva,string varObservaciones,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdEfectorTrasladoUt,bool? varDiabetesActualSi,bool? varDiabetesActualNo,bool? varAnemiaSi,bool? varAnemiaNo,string varNumeroIdentidad)
		{
			AprHistoriaClinicaPerinatal item = new AprHistoriaClinicaPerinatal();
			
				item.IdHistoriaClinicaPerinatal = varIdHistoriaClinicaPerinatal;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.Nombre = varNombre;
			
				item.Apellido = varApellido;
			
				item.Domicilio = varDomicilio;
			
				item.Dni = varDni;
			
				item.Localidad = varLocalidad;
			
				item.Telefono = varTelefono;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.Edad = varEdad;
			
				item.DatosDeContacto = varDatosDeContacto;
			
				item.EdadMenor15Mayor35 = varEdadMenor15Mayor35;
			
				item.EtniaBlanca = varEtniaBlanca;
			
				item.EtniaIndigena = varEtniaIndigena;
			
				item.EtniaMestiza = varEtniaMestiza;
			
				item.EtniaNegra = varEtniaNegra;
			
				item.EtniaOtra = varEtniaOtra;
			
				item.AlfabetaSi = varAlfabetaSi;
			
				item.AlfabetaNo = varAlfabetaNo;
			
				item.EstudiosNinguno = varEstudiosNinguno;
			
				item.EstudiosPrimario = varEstudiosPrimario;
			
				item.EstudiosSecundario = varEstudiosSecundario;
			
				item.EstudiosUniversitario = varEstudiosUniversitario;
			
				item.AñosMayorNivel = varAñosMayorNivel;
			
				item.EstadoCivilCasada = varEstadoCivilCasada;
			
				item.EstadoCivilUnionEstable = varEstadoCivilUnionEstable;
			
				item.EstadoCivilSoltera = varEstadoCivilSoltera;
			
				item.EstadoCivilOtro = varEstadoCivilOtro;
			
				item.ViveSolaSi = varViveSolaSi;
			
				item.ViveSolaNo = varViveSolaNo;
			
				item.LugarControlPerinatal = varLugarControlPerinatal;
			
				item.LugarPartoAborto = varLugarPartoAborto;
			
				item.AntFamTBCSi = varAntFamTBCSi;
			
				item.AntFamTBCNo = varAntFamTBCNo;
			
				item.AntFamDiabetesSi = varAntFamDiabetesSi;
			
				item.AntFamDiabetesNo = varAntFamDiabetesNo;
			
				item.AntFamHipertensionSi = varAntFamHipertensionSi;
			
				item.AntFamHipertensionNo = varAntFamHipertensionNo;
			
				item.AntFamInfeccionUrinariaSi = varAntFamInfeccionUrinariaSi;
			
				item.AntFamInfeccionUrinariaNo = varAntFamInfeccionUrinariaNo;
			
				item.AntFamOtrasInfeccionesSi = varAntFamOtrasInfeccionesSi;
			
				item.AntFamOtrasInfeccionesNo = varAntFamOtrasInfeccionesNo;
			
				item.AntFamOtroSi = varAntFamOtroSi;
			
				item.AntFamOtroNo = varAntFamOtroNo;
			
				item.AntPerTBCSi = varAntPerTBCSi;
			
				item.AntPerTBCNo = varAntPerTBCNo;
			
				item.AntPerDiabetesI = varAntPerDiabetesI;
			
				item.AntPerDiabetesII = varAntPerDiabetesII;
			
				item.AntPerDiabetesG = varAntPerDiabetesG;
			
				item.AntPerDiabetesNo = varAntPerDiabetesNo;
			
				item.AntPerHipertensionSi = varAntPerHipertensionSi;
			
				item.AntPerHipertensionNo = varAntPerHipertensionNo;
			
				item.AntPerInfeccionUrinariaSi = varAntPerInfeccionUrinariaSi;
			
				item.AntPerInfeccionUrinariaNo = varAntPerInfeccionUrinariaNo;
			
				item.AntPerOtrasInfeccionesSi = varAntPerOtrasInfeccionesSi;
			
				item.AntPerOtrasInfeccionesNo = varAntPerOtrasInfeccionesNo;
			
				item.AntPerOtroSi = varAntPerOtroSi;
			
				item.AntPerOtroNo = varAntPerOtroNo;
			
				item.AntPerInfertilidadSi = varAntPerInfertilidadSi;
			
				item.AntPerInfertilidadNo = varAntPerInfertilidadNo;
			
				item.AntPerCardiopatiaSi = varAntPerCardiopatiaSi;
			
				item.AntPerCardiopatiaNo = varAntPerCardiopatiaNo;
			
				item.AntPerNefropatiaSi = varAntPerNefropatiaSi;
			
				item.AntPerNefropatiaNo = varAntPerNefropatiaNo;
			
				item.AntPerViolenciaSi = varAntPerViolenciaSi;
			
				item.AntPerViolenciaNo = varAntPerViolenciaNo;
			
				item.AntPerAlergiaMedicamentoSi = varAntPerAlergiaMedicamentoSi;
			
				item.AntPerAlergiaMedicamentoNo = varAntPerAlergiaMedicamentoNo;
			
				item.AntecedentesObservacion = varAntecedentesObservacion;
			
				item.GestasPrevias = varGestasPrevias;
			
				item.Abortos = varAbortos;
			
				item.EmbEctopicos = varEmbEctopicos;
			
				item.Abortos3concecutivos = varAbortos3concecutivos;
			
				item.Partos = varPartos;
			
				item.PartosVaginales = varPartosVaginales;
			
				item.Cesareas = varCesareas;
			
				item.NacidosVivos = varNacidosVivos;
			
				item.NacidosMuertos = varNacidosMuertos;
			
				item.Viven = varViven;
			
				item.MuertosPrimerSemana = varMuertosPrimerSemana;
			
				item.MuertosDespuesPrimerSemana = varMuertosDespuesPrimerSemana;
			
				item.AntecedentesGemelaresSi = varAntecedentesGemelaresSi;
			
				item.AntecedentesGemelaresNo = varAntecedentesGemelaresNo;
			
				item.UltPrevioNC = varUltPrevioNC;
			
				item.UltPrevioNormal = varUltPrevioNormal;
			
				item.UltPrevioMenor2500 = varUltPrevioMenor2500;
			
				item.UltPrevioMayor4000 = varUltPrevioMayor4000;
			
				item.FinEmbarazoAnterior = varFinEmbarazoAnterior;
			
				item.FinEmbAnteriorMenor1Año = varFinEmbAnteriorMenor1Año;
			
				item.EmbarazoPlaneadoSi = varEmbarazoPlaneadoSi;
			
				item.EmbarazoPlaneadoNo = varEmbarazoPlaneadoNo;
			
				item.FracMetAnticonceptivoNoUsaba = varFracMetAnticonceptivoNoUsaba;
			
				item.FracMetAnticonceptivoBarrera = varFracMetAnticonceptivoBarrera;
			
				item.FracMetAnticonceptivoDIU = varFracMetAnticonceptivoDIU;
			
				item.FracMetAnticonceptivoHormonal = varFracMetAnticonceptivoHormonal;
			
				item.FracMetAnticonceptivoEmergencia = varFracMetAnticonceptivoEmergencia;
			
				item.FracMetAnticonceptivoNatural = varFracMetAnticonceptivoNatural;
			
				item.PesoAnterior = varPesoAnterior;
			
				item.Talla = varTalla;
			
				item.Fum = varFum;
			
				item.Fpp = varFpp;
			
				item.EGConfiableFUMSi = varEGConfiableFUMSi;
			
				item.EGConfiableFUMNo = varEGConfiableFUMNo;
			
				item.EGConfiableEcoMenor20semanasSi = varEGConfiableEcoMenor20semanasSi;
			
				item.EGConfiableEcoMenor20semanasNo = varEGConfiableEcoMenor20semanasNo;
			
				item.FumaActivo1TrimSi = varFumaActivo1TrimSi;
			
				item.FumaActivo1TrimNo = varFumaActivo1TrimNo;
			
				item.FumaActivo2TrimSi = varFumaActivo2TrimSi;
			
				item.FumaActivo2TrimNo = varFumaActivo2TrimNo;
			
				item.FumaActivo3TrimSi = varFumaActivo3TrimSi;
			
				item.FumaActivo3TrimNo = varFumaActivo3TrimNo;
			
				item.FumaPasivo1TrimSi = varFumaPasivo1TrimSi;
			
				item.FumaPasivo1TrimNo = varFumaPasivo1TrimNo;
			
				item.FumaPasivo2TrimSi = varFumaPasivo2TrimSi;
			
				item.FumaPasivo2TrimNo = varFumaPasivo2TrimNo;
			
				item.FumaPasivo3TrimSi = varFumaPasivo3TrimSi;
			
				item.FumaPasivo3TrimNo = varFumaPasivo3TrimNo;
			
				item.Drogas1TrimSi = varDrogas1TrimSi;
			
				item.Drogas1TrimNo = varDrogas1TrimNo;
			
				item.Drogas2TrimSi = varDrogas2TrimSi;
			
				item.Drogas2TrimNo = varDrogas2TrimNo;
			
				item.Drogas3TrimSi = varDrogas3TrimSi;
			
				item.Drogas3TrimNo = varDrogas3TrimNo;
			
				item.Alcohol1TrimSi = varAlcohol1TrimSi;
			
				item.Alcohol1TrimNo = varAlcohol1TrimNo;
			
				item.Alcohol2TrimSi = varAlcohol2TrimSi;
			
				item.Alcohol2TrimNo = varAlcohol2TrimNo;
			
				item.Alcohol3TrimSi = varAlcohol3TrimSi;
			
				item.Alcohol3TrimNo = varAlcohol3TrimNo;
			
				item.Violencia1TrimSi = varViolencia1TrimSi;
			
				item.Violencia1TrimNo = varViolencia1TrimNo;
			
				item.Violencia2TrimSi = varViolencia2TrimSi;
			
				item.Violencia2TrimNo = varViolencia2TrimNo;
			
				item.Violencia3TrimSi = varViolencia3TrimSi;
			
				item.Violencia3TrimNo = varViolencia3TrimNo;
			
				item.AntirubeolaPrevia = varAntirubeolaPrevia;
			
				item.AntirubeolaNoSabe = varAntirubeolaNoSabe;
			
				item.AntirubeolaEmbarazo = varAntirubeolaEmbarazo;
			
				item.AntirubeolaNo = varAntirubeolaNo;
			
				item.AntitetanicaVigenteNo = varAntitetanicaVigenteNo;
			
				item.AntitetanicaVigenteSi = varAntitetanicaVigenteSi;
			
				item.Antitetanica1DosisMesGestacion = varAntitetanica1DosisMesGestacion;
			
				item.Antitetanica2DosisMesGestacion = varAntitetanica2DosisMesGestacion;
			
				item.ExamenOdotologicoNormalSi = varExamenOdotologicoNormalSi;
			
				item.ExamenOdotologicoNormalNo = varExamenOdotologicoNormalNo;
			
				item.ExamenMamasNormalSi = varExamenMamasNormalSi;
			
				item.ExamenMamasNormalNo = varExamenMamasNormalNo;
			
				item.CervixInspeccionVisualNormal = varCervixInspeccionVisualNormal;
			
				item.CervixInspeccionVisualAnormal = varCervixInspeccionVisualAnormal;
			
				item.CervixInspeccionVisualNoSeHizo = varCervixInspeccionVisualNoSeHizo;
			
				item.CervixPAPNormal = varCervixPAPNormal;
			
				item.CervixPAPAnormal = varCervixPAPAnormal;
			
				item.CervixPAPNoSeHizo = varCervixPAPNoSeHizo;
			
				item.CervixCOLPNormal = varCervixCOLPNormal;
			
				item.CervixCOLPAnormal = varCervixCOLPAnormal;
			
				item.CervixCOLPNoSeHizo = varCervixCOLPNoSeHizo;
			
				item.Grupo = varGrupo;
			
				item.RHPositivo = varRHPositivo;
			
				item.RHNegativo = varRHNegativo;
			
				item.InmunizacionSi = varInmunizacionSi;
			
				item.InmunizacionNo = varInmunizacionNo;
			
				item.GammaGlobulinaNo = varGammaGlobulinaNo;
			
				item.GammaGlobulinaSi = varGammaGlobulinaSi;
			
				item.GammaGlobulinaNoCorresponde = varGammaGlobulinaNoCorresponde;
			
				item.ToxoPlasmosisMenor20SemLGGNegativo = varToxoPlasmosisMenor20SemLGGNegativo;
			
				item.ToxoPlasmosisMenor20SemLGGPositivo = varToxoPlasmosisMenor20SemLGGPositivo;
			
				item.ToxoPlasmosisMenor20SemLGGNoSeHizo = varToxoPlasmosisMenor20SemLGGNoSeHizo;
			
				item.ToxoPlasmosisMayor20SemLGGNegativo = varToxoPlasmosisMayor20SemLGGNegativo;
			
				item.ToxoPlasmosisMayor20SemLGGPositivo = varToxoPlasmosisMayor20SemLGGPositivo;
			
				item.ToxoPlasmosisMayor20SemLGGNoSeHizo = varToxoPlasmosisMayor20SemLGGNoSeHizo;
			
				item.ToxoPlasmosis1ConsultaLGMNegativo = varToxoPlasmosis1ConsultaLGMNegativo;
			
				item.ToxoPlasmosis1ConsultaLGMPositivo = varToxoPlasmosis1ConsultaLGMPositivo;
			
				item.ToxoPlasmosis1ConsultaLGMNoSeHizo = varToxoPlasmosis1ConsultaLGMNoSeHizo;
			
				item.ChagasNegativo = varChagasNegativo;
			
				item.ChagasPositivo = varChagasPositivo;
			
				item.ChagasNoSeHizo = varChagasNoSeHizo;
			
				item.HepatitisBNegativo = varHepatitisBNegativo;
			
				item.HepatitisBPositivo = varHepatitisBPositivo;
			
				item.HepatitisBNoSeHizo = varHepatitisBNoSeHizo;
			
				item.BacteriuraMenor20SemNormal = varBacteriuraMenor20SemNormal;
			
				item.BacteriuraMenor20SemAnormal = varBacteriuraMenor20SemAnormal;
			
				item.BacteriuraMenor20SemNoSeHizo = varBacteriuraMenor20SemNoSeHizo;
			
				item.BacteriuraMayor20SemNormal = varBacteriuraMayor20SemNormal;
			
				item.BacteriuraMayor20SemAnormal = varBacteriuraMayor20SemAnormal;
			
				item.BacteriuraMayor20SemNoSeHizo = varBacteriuraMayor20SemNoSeHizo;
			
				item.GlucemiaMenor20Sem = varGlucemiaMenor20Sem;
			
				item.GlucemiaMenor20SemMayor105 = varGlucemiaMenor20SemMayor105;
			
				item.GlucemiaMayor20Sem = varGlucemiaMayor20Sem;
			
				item.GlucemiaMayor20SemMayor105 = varGlucemiaMayor20SemMayor105;
			
				item.VIHCRSi = varVIHCRSi;
			
				item.VIHCRNo = varVIHCRNo;
			
				item.VIHPrimerMuestraSolicitadoSi = varVIHPrimerMuestraSolicitadoSi;
			
				item.VIHPrimerMuestraSolicitadoNo = varVIHPrimerMuestraSolicitadoNo;
			
				item.VIHPrimerMuestraRealizadoSi = varVIHPrimerMuestraRealizadoSi;
			
				item.VIHPrimerMuestraRealizadoNo = varVIHPrimerMuestraRealizadoNo;
			
				item.VIHPrimerMuestraFecha = varVIHPrimerMuestraFecha;
			
				item.HBMenor20Sem = varHBMenor20Sem;
			
				item.HBMenor20SemMenor11 = varHBMenor20SemMenor11;
			
				item.HBMayor20Sem = varHBMayor20Sem;
			
				item.HBMayor20SemMenor11 = varHBMayor20SemMenor11;
			
				item.FeIndicadoSi = varFeIndicadoSi;
			
				item.FeIndicadoNo = varFeIndicadoNo;
			
				item.FolatosIndicadosSi = varFolatosIndicadosSi;
			
				item.FolatosIndicadosNo = varFolatosIndicadosNo;
			
				item.EstreptococoB3537SemanasNegativo = varEstreptococoB3537SemanasNegativo;
			
				item.EstreptococoB3537SemanasPositivo = varEstreptococoB3537SemanasPositivo;
			
				item.EstreptococoB3537SemanasNoSeHizo = varEstreptococoB3537SemanasNoSeHizo;
			
				item.PreparacionPartoSi = varPreparacionPartoSi;
			
				item.PreparacionPartoNo = varPreparacionPartoNo;
			
				item.ConsejeriaLactanciaMaternaSi = varConsejeriaLactanciaMaternaSi;
			
				item.ConsejeriaLactanciaMaternaNo = varConsejeriaLactanciaMaternaNo;
			
				item.SifilisTratParejaMenor20SemNo = varSifilisTratParejaMenor20SemNo;
			
				item.SifilisTratParejaMenor20SemSi = varSifilisTratParejaMenor20SemSi;
			
				item.SifilisTratParejaMenor20SemSinDatos = varSifilisTratParejaMenor20SemSinDatos;
			
				item.SifilisTratParejaMenor20SemNoCorresponde = varSifilisTratParejaMenor20SemNoCorresponde;
			
				item.SifilisTratParejaMayor20SemNo = varSifilisTratParejaMayor20SemNo;
			
				item.SifilisTratParejaMayor20SemSi = varSifilisTratParejaMayor20SemSi;
			
				item.SifilisTratParejaMayor20SemSinDatos = varSifilisTratParejaMayor20SemSinDatos;
			
				item.SifilisTratParejaMayor20SemNoCorresponde = varSifilisTratParejaMayor20SemNoCorresponde;
			
				item.OAAntecedenteEclampsiaSi = varOAAntecedenteEclampsiaSi;
			
				item.OAAntecedenteEclampsiaNo = varOAAntecedenteEclampsiaNo;
			
				item.OAActualEclampsiaSi = varOAActualEclampsiaSi;
			
				item.OAActualEclampsiaNo = varOAActualEclampsiaNo;
			
				item.OAAntecedentePreeclampsiaSi = varOAAntecedentePreeclampsiaSi;
			
				item.OAAntecedentePreeclampsiaNo = varOAAntecedentePreeclampsiaNo;
			
				item.OAActualPreeclampsiaSi = varOAActualPreeclampsiaSi;
			
				item.OAActualPreeclampsiaNo = varOAActualPreeclampsiaNo;
			
				item.OAAntecedenteCirugiaGinUrinarSi = varOAAntecedenteCirugiaGinUrinarSi;
			
				item.OAAntecedenteCirugiaGinUrinarNo = varOAAntecedenteCirugiaGinUrinarNo;
			
				item.OAActualCirugiaGinUrinarSi = varOAActualCirugiaGinUrinarSi;
			
				item.OAActualCirugiaGinUrinarNo = varOAActualCirugiaGinUrinarNo;
			
				item.OAAntecedenteAPPrematuroSi = varOAAntecedenteAPPrematuroSi;
			
				item.OAAntecedenteAPPrematuroNo = varOAAntecedenteAPPrematuroNo;
			
				item.OAActualAPPrematuroSi = varOAActualAPPrematuroSi;
			
				item.OAActualAPPrematuroNo = varOAActualAPPrematuroNo;
			
				item.OAAntecedenteRCIUSi = varOAAntecedenteRCIUSi;
			
				item.OAAntecedenteRCIUNo = varOAAntecedenteRCIUNo;
			
				item.OAActualRCIUSi = varOAActualRCIUSi;
			
				item.OAActualRCIUNo = varOAActualRCIUNo;
			
				item.OAAntecedenteHemorragiaObstetricaSi = varOAAntecedenteHemorragiaObstetricaSi;
			
				item.OAAntecedenteHemorragiaObstetricaNo = varOAAntecedenteHemorragiaObstetricaNo;
			
				item.OAActualHemorragiaObstetricaSi = varOAActualHemorragiaObstetricaSi;
			
				item.OAActualHemorragiaObstetricaNo = varOAActualHemorragiaObstetricaNo;
			
				item.OAAntecedenteMacrosomiaFetalSi = varOAAntecedenteMacrosomiaFetalSi;
			
				item.OAAntecedenteMacrosomiaFetalNo = varOAAntecedenteMacrosomiaFetalNo;
			
				item.OAActualMacrosomiaFetalSi = varOAActualMacrosomiaFetalSi;
			
				item.OAActualMacrosomiaFetalNo = varOAActualMacrosomiaFetalNo;
			
				item.OAAntecedentePolihidramniosSi = varOAAntecedentePolihidramniosSi;
			
				item.OAAntecedentePolihidramniosNo = varOAAntecedentePolihidramniosNo;
			
				item.OAActualPolihidramniosSi = varOAActualPolihidramniosSi;
			
				item.OAActualPolihidramniosNo = varOAActualPolihidramniosNo;
			
				item.OAAntecedenteOligoanmiosSi = varOAAntecedenteOligoanmiosSi;
			
				item.OAAntecedenteOligoanmiosNo = varOAAntecedenteOligoanmiosNo;
			
				item.OAActualOligoanmiosSi = varOAActualOligoanmiosSi;
			
				item.OAActualOligoanmiosNo = varOAActualOligoanmiosNo;
			
				item.OAAntecedenteRotPremMembranasSi = varOAAntecedenteRotPremMembranasSi;
			
				item.OAAntecedenteRotPremMembranasNo = varOAAntecedenteRotPremMembranasNo;
			
				item.OAActualRotPremMembranasSi = varOAActualRotPremMembranasSi;
			
				item.OAActualRotPremMembranasNo = varOAActualRotPremMembranasNo;
			
				item.OAAntecedenteIsoinmunizacionesSi = varOAAntecedenteIsoinmunizacionesSi;
			
				item.OAAntecedenteIsoinmunizacionesNo = varOAAntecedenteIsoinmunizacionesNo;
			
				item.OAActualIsoinmunizacionesSi = varOAActualIsoinmunizacionesSi;
			
				item.OAActualIsoinmunizacionesNo = varOAActualIsoinmunizacionesNo;
			
				item.OAAntecedenteColestasisSi = varOAAntecedenteColestasisSi;
			
				item.OAAntecedenteColestasisNo = varOAAntecedenteColestasisNo;
			
				item.OAActualColestasisSi = varOAActualColestasisSi;
			
				item.OAActualColestasisNo = varOAActualColestasisNo;
			
				item.OAAntecedenteMortPerinatalRecurrenteSi = varOAAntecedenteMortPerinatalRecurrenteSi;
			
				item.OAAntecedenteMortPerinatalRecurrenteNo = varOAAntecedenteMortPerinatalRecurrenteNo;
			
				item.OAAntecedenteRetencionPlacentaSi = varOAAntecedenteRetencionPlacentaSi;
			
				item.OAAntecedenteRetencionPlacentaNo = varOAAntecedenteRetencionPlacentaNo;
			
				item.OAAntecedenteDistociaHombrosSi = varOAAntecedenteDistociaHombrosSi;
			
				item.OAAntecedenteDistociaHombrosNo = varOAAntecedenteDistociaHombrosNo;
			
				item.OAAntecedenteMalformCongenSi = varOAAntecedenteMalformCongenSi;
			
				item.OAAntecedenteMalformCongenNo = varOAAntecedenteMalformCongenNo;
			
				item.FactorRiesgoEmbarazoSinContSocialSi = varFactorRiesgoEmbarazoSinContSocialSi;
			
				item.FactorRiesgoEmbarazoSinContSocialNo = varFactorRiesgoEmbarazoSinContSocialNo;
			
				item.FactorRiesgoFamiliaSinIngresosFijosSi = varFactorRiesgoFamiliaSinIngresosFijosSi;
			
				item.FactorRiesgoFamiliaSinIngresosFijosNo = varFactorRiesgoFamiliaSinIngresosFijosNo;
			
				item.FactorRiesgoEmbarazoFuertRechazadoSi = varFactorRiesgoEmbarazoFuertRechazadoSi;
			
				item.FactorRiesgoEmbarazoFuertRechazadoNo = varFactorRiesgoEmbarazoFuertRechazadoNo;
			
				item.FactorRiesgoHijosDadosAdopcionSi = varFactorRiesgoHijosDadosAdopcionSi;
			
				item.FactorRiesgoHijosDadosAdopcionNo = varFactorRiesgoHijosDadosAdopcionNo;
			
				item.FactorRiesgoViviendaSinServiciosBasicosSi = varFactorRiesgoViviendaSinServiciosBasicosSi;
			
				item.FactorRiesgoViviendaSinServiciosBasicosNo = varFactorRiesgoViviendaSinServiciosBasicosNo;
			
				item.CaptacionOportunaAntes16sem = varCaptacionOportunaAntes16sem;
			
				item.CaptacionOportunaDespues16sem = varCaptacionOportunaDespues16sem;
			
				item.FechaMuestraPAP = varFechaMuestraPAP;
			
				item.FechaTripleAcelular = varFechaTripleAcelular;
			
				item.FechaAntigripal = varFechaAntigripal;
			
				item.VIHSegundaMuestraSolicitadoSi = varVIHSegundaMuestraSolicitadoSi;
			
				item.VIHSegundaMuestraSolicitadoNo = varVIHSegundaMuestraSolicitadoNo;
			
				item.VIHSegundaMuestraRealizadoSi = varVIHSegundaMuestraRealizadoSi;
			
				item.VIHSegundaMuestraRealizadoNo = varVIHSegundaMuestraRealizadoNo;
			
				item.VIHSegundaMuestraFecha = varVIHSegundaMuestraFecha;
			
				item.VIHTercerMuestraSolicitadoSi = varVIHTercerMuestraSolicitadoSi;
			
				item.VIHTercerMuestraSolicitadoNo = varVIHTercerMuestraSolicitadoNo;
			
				item.VIHTercerMuestraRealizadoSi = varVIHTercerMuestraRealizadoSi;
			
				item.VIHTercerMuestraRealizadoNo = varVIHTercerMuestraRealizadoNo;
			
				item.VIHTercerMuestraFecha = varVIHTercerMuestraFecha;
			
				item.SifilisPruebaNoTrepoPrimerMuestra = varSifilisPruebaNoTrepoPrimerMuestra;
			
				item.SifilisPruebaNoTrepoPrimerMuestraNegativo = varSifilisPruebaNoTrepoPrimerMuestraNegativo;
			
				item.SifilisPruebaNoTrepoPrimerMuestraPositivo = varSifilisPruebaNoTrepoPrimerMuestraPositivo;
			
				item.SifilisPruebaNoTrepoPrimerMuestraSinDatos = varSifilisPruebaNoTrepoPrimerMuestraSinDatos;
			
				item.SifilisPruebaNoTrepoPrimerMuestraFecha = varSifilisPruebaNoTrepoPrimerMuestraFecha;
			
				item.SifilisPruebaNoTrepoSegundaMuestra = varSifilisPruebaNoTrepoSegundaMuestra;
			
				item.SifilisPruebaNoTrepoSegundaMuestraNegativo = varSifilisPruebaNoTrepoSegundaMuestraNegativo;
			
				item.SifilisPruebaNoTrepoSegundaMuestraPositivo = varSifilisPruebaNoTrepoSegundaMuestraPositivo;
			
				item.SifilisPruebaNoTrepoSegundaMuestraSinDatos = varSifilisPruebaNoTrepoSegundaMuestraSinDatos;
			
				item.SifilisPruebaNoTrepoSegundaMuestraFecha = varSifilisPruebaNoTrepoSegundaMuestraFecha;
			
				item.SifilisPruebaNoTrepoTercerMuestra = varSifilisPruebaNoTrepoTercerMuestra;
			
				item.SifilisPruebaNoTrepoTercerMuestraNegativo = varSifilisPruebaNoTrepoTercerMuestraNegativo;
			
				item.SifilisPruebaNoTrepoTercerMuestraPositivo = varSifilisPruebaNoTrepoTercerMuestraPositivo;
			
				item.SifilisPruebaNoTrepoTercerMuestraSinDatos = varSifilisPruebaNoTrepoTercerMuestraSinDatos;
			
				item.SifilisPruebaNoTrepoTercerMuestraFecha = varSifilisPruebaNoTrepoTercerMuestraFecha;
			
				item.SifilisPruebaTrepoPrimerMuestra = varSifilisPruebaTrepoPrimerMuestra;
			
				item.SifilisPruebaTrepoPrimerMuestraNegativo = varSifilisPruebaTrepoPrimerMuestraNegativo;
			
				item.SifilisPruebaTrepoPrimerMuestraPositivo = varSifilisPruebaTrepoPrimerMuestraPositivo;
			
				item.SifilisPruebaTrepoPrimerMuestraSinDatos = varSifilisPruebaTrepoPrimerMuestraSinDatos;
			
				item.SifilisPruebaTrepoPrimerMuestraNoCorresponde = varSifilisPruebaTrepoPrimerMuestraNoCorresponde;
			
				item.SifilisPruebaTrepoPrimerMuestraFecha = varSifilisPruebaTrepoPrimerMuestraFecha;
			
				item.SifilisPruebaTrepoSegundaMuestra = varSifilisPruebaTrepoSegundaMuestra;
			
				item.SifilisPruebaTrepoSegundaMuestraNegativo = varSifilisPruebaTrepoSegundaMuestraNegativo;
			
				item.SifilisPruebaTrepoSegundaMuestraPositivo = varSifilisPruebaTrepoSegundaMuestraPositivo;
			
				item.SifilisPruebaTrepoSegundaMuestraSinDatos = varSifilisPruebaTrepoSegundaMuestraSinDatos;
			
				item.SifilisPruebaTrepoSegundaMuestraNoCorresponde = varSifilisPruebaTrepoSegundaMuestraNoCorresponde;
			
				item.SifilisPruebaTrepoSegundaMuestraFecha = varSifilisPruebaTrepoSegundaMuestraFecha;
			
				item.SifilisPruebaTrepoTercerMuestra = varSifilisPruebaTrepoTercerMuestra;
			
				item.SifilisPruebaTrepoTercerMuestraNegativo = varSifilisPruebaTrepoTercerMuestraNegativo;
			
				item.SifilisPruebaTrepoTercerMuestraPositivo = varSifilisPruebaTrepoTercerMuestraPositivo;
			
				item.SifilisPruebaTrepoTercerMuestraSinDatos = varSifilisPruebaTrepoTercerMuestraSinDatos;
			
				item.SifilisPruebaTrepoTercerMuestraNoCorresponde = varSifilisPruebaTrepoTercerMuestraNoCorresponde;
			
				item.SifilisPruebaTrepoTercerMuestraFecha = varSifilisPruebaTrepoTercerMuestraFecha;
			
				item.SifilisTratamientoPrimerMuestra = varSifilisTratamientoPrimerMuestra;
			
				item.SifilisTratamientoPrimerMuestraNo = varSifilisTratamientoPrimerMuestraNo;
			
				item.SifilisTratamientoPrimerMuestraSi = varSifilisTratamientoPrimerMuestraSi;
			
				item.SifilisTratamientoPrimerMuestraSinDatos = varSifilisTratamientoPrimerMuestraSinDatos;
			
				item.SifilisTratamientoPrimerMuestraNoCorresponde = varSifilisTratamientoPrimerMuestraNoCorresponde;
			
				item.SifilisTratamientoPrimerMuestraFecha = varSifilisTratamientoPrimerMuestraFecha;
			
				item.SifilisTratamientoSegundaMuestra = varSifilisTratamientoSegundaMuestra;
			
				item.SifilisTratamientoSegundaMuestraNo = varSifilisTratamientoSegundaMuestraNo;
			
				item.SifilisTratamientoSegundaMuestraSi = varSifilisTratamientoSegundaMuestraSi;
			
				item.SifilisTratamientoSegundaMuestraSinDatos = varSifilisTratamientoSegundaMuestraSinDatos;
			
				item.SifilisTratamientoSegundaMuestraNoCorresponde = varSifilisTratamientoSegundaMuestraNoCorresponde;
			
				item.SifilisTratamientoSegundaMuestraFecha = varSifilisTratamientoSegundaMuestraFecha;
			
				item.SifilisTratamientoTercerMuestra = varSifilisTratamientoTercerMuestra;
			
				item.SifilisTratamientoTercerMuestraNo = varSifilisTratamientoTercerMuestraNo;
			
				item.SifilisTratamientoTercerMuestraSi = varSifilisTratamientoTercerMuestraSi;
			
				item.SifilisTratamientoTercerMuestraSinDatos = varSifilisTratamientoTercerMuestraSinDatos;
			
				item.SifilisTratamientoTercerMuestraNoCorresponde = varSifilisTratamientoTercerMuestraNoCorresponde;
			
				item.SifilisTratamientoTercerMuestraFecha = varSifilisTratamientoTercerMuestraFecha;
			
				item.Activa = varActiva;
			
				item.Observaciones = varObservaciones;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.IdEfectorTrasladoUt = varIdEfectorTrasladoUt;
			
				item.DiabetesActualSi = varDiabetesActualSi;
			
				item.DiabetesActualNo = varDiabetesActualNo;
			
				item.AnemiaSi = varAnemiaSi;
			
				item.AnemiaNo = varAnemiaNo;
			
				item.NumeroIdentidad = varNumeroIdentidad;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHistoriaClinicaPerinatalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DniColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DatosDeContactoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadMenor15Mayor35Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn EtniaBlancaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn EtniaIndigenaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn EtniaMestizaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn EtniaNegraColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EtniaOtraColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn AlfabetaSiColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn AlfabetaNoColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosNingunoColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosPrimarioColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosSecundarioColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosUniversitarioColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn AñosMayorNivelColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoCivilCasadaColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoCivilUnionEstableColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoCivilSolteraColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoCivilOtroColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn ViveSolaSiColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn ViveSolaNoColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn LugarControlPerinatalColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn LugarPartoAbortoColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamTBCSiColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamTBCNoColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamDiabetesSiColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamDiabetesNoColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamHipertensionSiColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamHipertensionNoColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamInfeccionUrinariaSiColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamInfeccionUrinariaNoColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamOtrasInfeccionesSiColumn
        {
            get { return Schema.Columns[41]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamOtrasInfeccionesNoColumn
        {
            get { return Schema.Columns[42]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamOtroSiColumn
        {
            get { return Schema.Columns[43]; }
        }
        
        
        
        public static TableSchema.TableColumn AntFamOtroNoColumn
        {
            get { return Schema.Columns[44]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerTBCSiColumn
        {
            get { return Schema.Columns[45]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerTBCNoColumn
        {
            get { return Schema.Columns[46]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerDiabetesIColumn
        {
            get { return Schema.Columns[47]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerDiabetesIIColumn
        {
            get { return Schema.Columns[48]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerDiabetesGColumn
        {
            get { return Schema.Columns[49]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerDiabetesNoColumn
        {
            get { return Schema.Columns[50]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerHipertensionSiColumn
        {
            get { return Schema.Columns[51]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerHipertensionNoColumn
        {
            get { return Schema.Columns[52]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerInfeccionUrinariaSiColumn
        {
            get { return Schema.Columns[53]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerInfeccionUrinariaNoColumn
        {
            get { return Schema.Columns[54]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerOtrasInfeccionesSiColumn
        {
            get { return Schema.Columns[55]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerOtrasInfeccionesNoColumn
        {
            get { return Schema.Columns[56]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerOtroSiColumn
        {
            get { return Schema.Columns[57]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerOtroNoColumn
        {
            get { return Schema.Columns[58]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerInfertilidadSiColumn
        {
            get { return Schema.Columns[59]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerInfertilidadNoColumn
        {
            get { return Schema.Columns[60]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerCardiopatiaSiColumn
        {
            get { return Schema.Columns[61]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerCardiopatiaNoColumn
        {
            get { return Schema.Columns[62]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerNefropatiaSiColumn
        {
            get { return Schema.Columns[63]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerNefropatiaNoColumn
        {
            get { return Schema.Columns[64]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerViolenciaSiColumn
        {
            get { return Schema.Columns[65]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerViolenciaNoColumn
        {
            get { return Schema.Columns[66]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerAlergiaMedicamentoSiColumn
        {
            get { return Schema.Columns[67]; }
        }
        
        
        
        public static TableSchema.TableColumn AntPerAlergiaMedicamentoNoColumn
        {
            get { return Schema.Columns[68]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecedentesObservacionColumn
        {
            get { return Schema.Columns[69]; }
        }
        
        
        
        public static TableSchema.TableColumn GestasPreviasColumn
        {
            get { return Schema.Columns[70]; }
        }
        
        
        
        public static TableSchema.TableColumn AbortosColumn
        {
            get { return Schema.Columns[71]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbEctopicosColumn
        {
            get { return Schema.Columns[72]; }
        }
        
        
        
        public static TableSchema.TableColumn Abortos3concecutivosColumn
        {
            get { return Schema.Columns[73]; }
        }
        
        
        
        public static TableSchema.TableColumn PartosColumn
        {
            get { return Schema.Columns[74]; }
        }
        
        
        
        public static TableSchema.TableColumn PartosVaginalesColumn
        {
            get { return Schema.Columns[75]; }
        }
        
        
        
        public static TableSchema.TableColumn CesareasColumn
        {
            get { return Schema.Columns[76]; }
        }
        
        
        
        public static TableSchema.TableColumn NacidosVivosColumn
        {
            get { return Schema.Columns[77]; }
        }
        
        
        
        public static TableSchema.TableColumn NacidosMuertosColumn
        {
            get { return Schema.Columns[78]; }
        }
        
        
        
        public static TableSchema.TableColumn VivenColumn
        {
            get { return Schema.Columns[79]; }
        }
        
        
        
        public static TableSchema.TableColumn MuertosPrimerSemanaColumn
        {
            get { return Schema.Columns[80]; }
        }
        
        
        
        public static TableSchema.TableColumn MuertosDespuesPrimerSemanaColumn
        {
            get { return Schema.Columns[81]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecedentesGemelaresSiColumn
        {
            get { return Schema.Columns[82]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecedentesGemelaresNoColumn
        {
            get { return Schema.Columns[83]; }
        }
        
        
        
        public static TableSchema.TableColumn UltPrevioNCColumn
        {
            get { return Schema.Columns[84]; }
        }
        
        
        
        public static TableSchema.TableColumn UltPrevioNormalColumn
        {
            get { return Schema.Columns[85]; }
        }
        
        
        
        public static TableSchema.TableColumn UltPrevioMenor2500Column
        {
            get { return Schema.Columns[86]; }
        }
        
        
        
        public static TableSchema.TableColumn UltPrevioMayor4000Column
        {
            get { return Schema.Columns[87]; }
        }
        
        
        
        public static TableSchema.TableColumn FinEmbarazoAnteriorColumn
        {
            get { return Schema.Columns[88]; }
        }
        
        
        
        public static TableSchema.TableColumn FinEmbAnteriorMenor1AñoColumn
        {
            get { return Schema.Columns[89]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoPlaneadoSiColumn
        {
            get { return Schema.Columns[90]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoPlaneadoNoColumn
        {
            get { return Schema.Columns[91]; }
        }
        
        
        
        public static TableSchema.TableColumn FracMetAnticonceptivoNoUsabaColumn
        {
            get { return Schema.Columns[92]; }
        }
        
        
        
        public static TableSchema.TableColumn FracMetAnticonceptivoBarreraColumn
        {
            get { return Schema.Columns[93]; }
        }
        
        
        
        public static TableSchema.TableColumn FracMetAnticonceptivoDIUColumn
        {
            get { return Schema.Columns[94]; }
        }
        
        
        
        public static TableSchema.TableColumn FracMetAnticonceptivoHormonalColumn
        {
            get { return Schema.Columns[95]; }
        }
        
        
        
        public static TableSchema.TableColumn FracMetAnticonceptivoEmergenciaColumn
        {
            get { return Schema.Columns[96]; }
        }
        
        
        
        public static TableSchema.TableColumn FracMetAnticonceptivoNaturalColumn
        {
            get { return Schema.Columns[97]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoAnteriorColumn
        {
            get { return Schema.Columns[98]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[99]; }
        }
        
        
        
        public static TableSchema.TableColumn FumColumn
        {
            get { return Schema.Columns[100]; }
        }
        
        
        
        public static TableSchema.TableColumn FppColumn
        {
            get { return Schema.Columns[101]; }
        }
        
        
        
        public static TableSchema.TableColumn EGConfiableFUMSiColumn
        {
            get { return Schema.Columns[102]; }
        }
        
        
        
        public static TableSchema.TableColumn EGConfiableFUMNoColumn
        {
            get { return Schema.Columns[103]; }
        }
        
        
        
        public static TableSchema.TableColumn EGConfiableEcoMenor20semanasSiColumn
        {
            get { return Schema.Columns[104]; }
        }
        
        
        
        public static TableSchema.TableColumn EGConfiableEcoMenor20semanasNoColumn
        {
            get { return Schema.Columns[105]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaActivo1TrimSiColumn
        {
            get { return Schema.Columns[106]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaActivo1TrimNoColumn
        {
            get { return Schema.Columns[107]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaActivo2TrimSiColumn
        {
            get { return Schema.Columns[108]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaActivo2TrimNoColumn
        {
            get { return Schema.Columns[109]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaActivo3TrimSiColumn
        {
            get { return Schema.Columns[110]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaActivo3TrimNoColumn
        {
            get { return Schema.Columns[111]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaPasivo1TrimSiColumn
        {
            get { return Schema.Columns[112]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaPasivo1TrimNoColumn
        {
            get { return Schema.Columns[113]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaPasivo2TrimSiColumn
        {
            get { return Schema.Columns[114]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaPasivo2TrimNoColumn
        {
            get { return Schema.Columns[115]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaPasivo3TrimSiColumn
        {
            get { return Schema.Columns[116]; }
        }
        
        
        
        public static TableSchema.TableColumn FumaPasivo3TrimNoColumn
        {
            get { return Schema.Columns[117]; }
        }
        
        
        
        public static TableSchema.TableColumn Drogas1TrimSiColumn
        {
            get { return Schema.Columns[118]; }
        }
        
        
        
        public static TableSchema.TableColumn Drogas1TrimNoColumn
        {
            get { return Schema.Columns[119]; }
        }
        
        
        
        public static TableSchema.TableColumn Drogas2TrimSiColumn
        {
            get { return Schema.Columns[120]; }
        }
        
        
        
        public static TableSchema.TableColumn Drogas2TrimNoColumn
        {
            get { return Schema.Columns[121]; }
        }
        
        
        
        public static TableSchema.TableColumn Drogas3TrimSiColumn
        {
            get { return Schema.Columns[122]; }
        }
        
        
        
        public static TableSchema.TableColumn Drogas3TrimNoColumn
        {
            get { return Schema.Columns[123]; }
        }
        
        
        
        public static TableSchema.TableColumn Alcohol1TrimSiColumn
        {
            get { return Schema.Columns[124]; }
        }
        
        
        
        public static TableSchema.TableColumn Alcohol1TrimNoColumn
        {
            get { return Schema.Columns[125]; }
        }
        
        
        
        public static TableSchema.TableColumn Alcohol2TrimSiColumn
        {
            get { return Schema.Columns[126]; }
        }
        
        
        
        public static TableSchema.TableColumn Alcohol2TrimNoColumn
        {
            get { return Schema.Columns[127]; }
        }
        
        
        
        public static TableSchema.TableColumn Alcohol3TrimSiColumn
        {
            get { return Schema.Columns[128]; }
        }
        
        
        
        public static TableSchema.TableColumn Alcohol3TrimNoColumn
        {
            get { return Schema.Columns[129]; }
        }
        
        
        
        public static TableSchema.TableColumn Violencia1TrimSiColumn
        {
            get { return Schema.Columns[130]; }
        }
        
        
        
        public static TableSchema.TableColumn Violencia1TrimNoColumn
        {
            get { return Schema.Columns[131]; }
        }
        
        
        
        public static TableSchema.TableColumn Violencia2TrimSiColumn
        {
            get { return Schema.Columns[132]; }
        }
        
        
        
        public static TableSchema.TableColumn Violencia2TrimNoColumn
        {
            get { return Schema.Columns[133]; }
        }
        
        
        
        public static TableSchema.TableColumn Violencia3TrimSiColumn
        {
            get { return Schema.Columns[134]; }
        }
        
        
        
        public static TableSchema.TableColumn Violencia3TrimNoColumn
        {
            get { return Schema.Columns[135]; }
        }
        
        
        
        public static TableSchema.TableColumn AntirubeolaPreviaColumn
        {
            get { return Schema.Columns[136]; }
        }
        
        
        
        public static TableSchema.TableColumn AntirubeolaNoSabeColumn
        {
            get { return Schema.Columns[137]; }
        }
        
        
        
        public static TableSchema.TableColumn AntirubeolaEmbarazoColumn
        {
            get { return Schema.Columns[138]; }
        }
        
        
        
        public static TableSchema.TableColumn AntirubeolaNoColumn
        {
            get { return Schema.Columns[139]; }
        }
        
        
        
        public static TableSchema.TableColumn AntitetanicaVigenteNoColumn
        {
            get { return Schema.Columns[140]; }
        }
        
        
        
        public static TableSchema.TableColumn AntitetanicaVigenteSiColumn
        {
            get { return Schema.Columns[141]; }
        }
        
        
        
        public static TableSchema.TableColumn Antitetanica1DosisMesGestacionColumn
        {
            get { return Schema.Columns[142]; }
        }
        
        
        
        public static TableSchema.TableColumn Antitetanica2DosisMesGestacionColumn
        {
            get { return Schema.Columns[143]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenOdotologicoNormalSiColumn
        {
            get { return Schema.Columns[144]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenOdotologicoNormalNoColumn
        {
            get { return Schema.Columns[145]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenMamasNormalSiColumn
        {
            get { return Schema.Columns[146]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenMamasNormalNoColumn
        {
            get { return Schema.Columns[147]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixInspeccionVisualNormalColumn
        {
            get { return Schema.Columns[148]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixInspeccionVisualAnormalColumn
        {
            get { return Schema.Columns[149]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixInspeccionVisualNoSeHizoColumn
        {
            get { return Schema.Columns[150]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixPAPNormalColumn
        {
            get { return Schema.Columns[151]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixPAPAnormalColumn
        {
            get { return Schema.Columns[152]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixPAPNoSeHizoColumn
        {
            get { return Schema.Columns[153]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixCOLPNormalColumn
        {
            get { return Schema.Columns[154]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixCOLPAnormalColumn
        {
            get { return Schema.Columns[155]; }
        }
        
        
        
        public static TableSchema.TableColumn CervixCOLPNoSeHizoColumn
        {
            get { return Schema.Columns[156]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoColumn
        {
            get { return Schema.Columns[157]; }
        }
        
        
        
        public static TableSchema.TableColumn RHPositivoColumn
        {
            get { return Schema.Columns[158]; }
        }
        
        
        
        public static TableSchema.TableColumn RHNegativoColumn
        {
            get { return Schema.Columns[159]; }
        }
        
        
        
        public static TableSchema.TableColumn InmunizacionSiColumn
        {
            get { return Schema.Columns[160]; }
        }
        
        
        
        public static TableSchema.TableColumn InmunizacionNoColumn
        {
            get { return Schema.Columns[161]; }
        }
        
        
        
        public static TableSchema.TableColumn GammaGlobulinaNoColumn
        {
            get { return Schema.Columns[162]; }
        }
        
        
        
        public static TableSchema.TableColumn GammaGlobulinaSiColumn
        {
            get { return Schema.Columns[163]; }
        }
        
        
        
        public static TableSchema.TableColumn GammaGlobulinaNoCorrespondeColumn
        {
            get { return Schema.Columns[164]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosisMenor20SemLGGNegativoColumn
        {
            get { return Schema.Columns[165]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosisMenor20SemLGGPositivoColumn
        {
            get { return Schema.Columns[166]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosisMenor20SemLGGNoSeHizoColumn
        {
            get { return Schema.Columns[167]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosisMayor20SemLGGNegativoColumn
        {
            get { return Schema.Columns[168]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosisMayor20SemLGGPositivoColumn
        {
            get { return Schema.Columns[169]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosisMayor20SemLGGNoSeHizoColumn
        {
            get { return Schema.Columns[170]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosis1ConsultaLGMNegativoColumn
        {
            get { return Schema.Columns[171]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosis1ConsultaLGMPositivoColumn
        {
            get { return Schema.Columns[172]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoPlasmosis1ConsultaLGMNoSeHizoColumn
        {
            get { return Schema.Columns[173]; }
        }
        
        
        
        public static TableSchema.TableColumn ChagasNegativoColumn
        {
            get { return Schema.Columns[174]; }
        }
        
        
        
        public static TableSchema.TableColumn ChagasPositivoColumn
        {
            get { return Schema.Columns[175]; }
        }
        
        
        
        public static TableSchema.TableColumn ChagasNoSeHizoColumn
        {
            get { return Schema.Columns[176]; }
        }
        
        
        
        public static TableSchema.TableColumn HepatitisBNegativoColumn
        {
            get { return Schema.Columns[177]; }
        }
        
        
        
        public static TableSchema.TableColumn HepatitisBPositivoColumn
        {
            get { return Schema.Columns[178]; }
        }
        
        
        
        public static TableSchema.TableColumn HepatitisBNoSeHizoColumn
        {
            get { return Schema.Columns[179]; }
        }
        
        
        
        public static TableSchema.TableColumn BacteriuraMenor20SemNormalColumn
        {
            get { return Schema.Columns[180]; }
        }
        
        
        
        public static TableSchema.TableColumn BacteriuraMenor20SemAnormalColumn
        {
            get { return Schema.Columns[181]; }
        }
        
        
        
        public static TableSchema.TableColumn BacteriuraMenor20SemNoSeHizoColumn
        {
            get { return Schema.Columns[182]; }
        }
        
        
        
        public static TableSchema.TableColumn BacteriuraMayor20SemNormalColumn
        {
            get { return Schema.Columns[183]; }
        }
        
        
        
        public static TableSchema.TableColumn BacteriuraMayor20SemAnormalColumn
        {
            get { return Schema.Columns[184]; }
        }
        
        
        
        public static TableSchema.TableColumn BacteriuraMayor20SemNoSeHizoColumn
        {
            get { return Schema.Columns[185]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaMenor20SemColumn
        {
            get { return Schema.Columns[186]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaMenor20SemMayor105Column
        {
            get { return Schema.Columns[187]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaMayor20SemColumn
        {
            get { return Schema.Columns[188]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaMayor20SemMayor105Column
        {
            get { return Schema.Columns[189]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHCRSiColumn
        {
            get { return Schema.Columns[190]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHCRNoColumn
        {
            get { return Schema.Columns[191]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHPrimerMuestraSolicitadoSiColumn
        {
            get { return Schema.Columns[192]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHPrimerMuestraSolicitadoNoColumn
        {
            get { return Schema.Columns[193]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHPrimerMuestraRealizadoSiColumn
        {
            get { return Schema.Columns[194]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHPrimerMuestraRealizadoNoColumn
        {
            get { return Schema.Columns[195]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHPrimerMuestraFechaColumn
        {
            get { return Schema.Columns[196]; }
        }
        
        
        
        public static TableSchema.TableColumn HBMenor20SemColumn
        {
            get { return Schema.Columns[197]; }
        }
        
        
        
        public static TableSchema.TableColumn HBMenor20SemMenor11Column
        {
            get { return Schema.Columns[198]; }
        }
        
        
        
        public static TableSchema.TableColumn HBMayor20SemColumn
        {
            get { return Schema.Columns[199]; }
        }
        
        
        
        public static TableSchema.TableColumn HBMayor20SemMenor11Column
        {
            get { return Schema.Columns[200]; }
        }
        
        
        
        public static TableSchema.TableColumn FeIndicadoSiColumn
        {
            get { return Schema.Columns[201]; }
        }
        
        
        
        public static TableSchema.TableColumn FeIndicadoNoColumn
        {
            get { return Schema.Columns[202]; }
        }
        
        
        
        public static TableSchema.TableColumn FolatosIndicadosSiColumn
        {
            get { return Schema.Columns[203]; }
        }
        
        
        
        public static TableSchema.TableColumn FolatosIndicadosNoColumn
        {
            get { return Schema.Columns[204]; }
        }
        
        
        
        public static TableSchema.TableColumn EstreptococoB3537SemanasNegativoColumn
        {
            get { return Schema.Columns[205]; }
        }
        
        
        
        public static TableSchema.TableColumn EstreptococoB3537SemanasPositivoColumn
        {
            get { return Schema.Columns[206]; }
        }
        
        
        
        public static TableSchema.TableColumn EstreptococoB3537SemanasNoSeHizoColumn
        {
            get { return Schema.Columns[207]; }
        }
        
        
        
        public static TableSchema.TableColumn PreparacionPartoSiColumn
        {
            get { return Schema.Columns[208]; }
        }
        
        
        
        public static TableSchema.TableColumn PreparacionPartoNoColumn
        {
            get { return Schema.Columns[209]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsejeriaLactanciaMaternaSiColumn
        {
            get { return Schema.Columns[210]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsejeriaLactanciaMaternaNoColumn
        {
            get { return Schema.Columns[211]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMenor20SemNoColumn
        {
            get { return Schema.Columns[212]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMenor20SemSiColumn
        {
            get { return Schema.Columns[213]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMenor20SemSinDatosColumn
        {
            get { return Schema.Columns[214]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMenor20SemNoCorrespondeColumn
        {
            get { return Schema.Columns[215]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMayor20SemNoColumn
        {
            get { return Schema.Columns[216]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMayor20SemSiColumn
        {
            get { return Schema.Columns[217]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMayor20SemSinDatosColumn
        {
            get { return Schema.Columns[218]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratParejaMayor20SemNoCorrespondeColumn
        {
            get { return Schema.Columns[219]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteEclampsiaSiColumn
        {
            get { return Schema.Columns[220]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteEclampsiaNoColumn
        {
            get { return Schema.Columns[221]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualEclampsiaSiColumn
        {
            get { return Schema.Columns[222]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualEclampsiaNoColumn
        {
            get { return Schema.Columns[223]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedentePreeclampsiaSiColumn
        {
            get { return Schema.Columns[224]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedentePreeclampsiaNoColumn
        {
            get { return Schema.Columns[225]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualPreeclampsiaSiColumn
        {
            get { return Schema.Columns[226]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualPreeclampsiaNoColumn
        {
            get { return Schema.Columns[227]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteCirugiaGinUrinarSiColumn
        {
            get { return Schema.Columns[228]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteCirugiaGinUrinarNoColumn
        {
            get { return Schema.Columns[229]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualCirugiaGinUrinarSiColumn
        {
            get { return Schema.Columns[230]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualCirugiaGinUrinarNoColumn
        {
            get { return Schema.Columns[231]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteAPPrematuroSiColumn
        {
            get { return Schema.Columns[232]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteAPPrematuroNoColumn
        {
            get { return Schema.Columns[233]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualAPPrematuroSiColumn
        {
            get { return Schema.Columns[234]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualAPPrematuroNoColumn
        {
            get { return Schema.Columns[235]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteRCIUSiColumn
        {
            get { return Schema.Columns[236]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteRCIUNoColumn
        {
            get { return Schema.Columns[237]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualRCIUSiColumn
        {
            get { return Schema.Columns[238]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualRCIUNoColumn
        {
            get { return Schema.Columns[239]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteHemorragiaObstetricaSiColumn
        {
            get { return Schema.Columns[240]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteHemorragiaObstetricaNoColumn
        {
            get { return Schema.Columns[241]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualHemorragiaObstetricaSiColumn
        {
            get { return Schema.Columns[242]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualHemorragiaObstetricaNoColumn
        {
            get { return Schema.Columns[243]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteMacrosomiaFetalSiColumn
        {
            get { return Schema.Columns[244]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteMacrosomiaFetalNoColumn
        {
            get { return Schema.Columns[245]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualMacrosomiaFetalSiColumn
        {
            get { return Schema.Columns[246]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualMacrosomiaFetalNoColumn
        {
            get { return Schema.Columns[247]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedentePolihidramniosSiColumn
        {
            get { return Schema.Columns[248]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedentePolihidramniosNoColumn
        {
            get { return Schema.Columns[249]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualPolihidramniosSiColumn
        {
            get { return Schema.Columns[250]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualPolihidramniosNoColumn
        {
            get { return Schema.Columns[251]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteOligoanmiosSiColumn
        {
            get { return Schema.Columns[252]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteOligoanmiosNoColumn
        {
            get { return Schema.Columns[253]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualOligoanmiosSiColumn
        {
            get { return Schema.Columns[254]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualOligoanmiosNoColumn
        {
            get { return Schema.Columns[255]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteRotPremMembranasSiColumn
        {
            get { return Schema.Columns[256]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteRotPremMembranasNoColumn
        {
            get { return Schema.Columns[257]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualRotPremMembranasSiColumn
        {
            get { return Schema.Columns[258]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualRotPremMembranasNoColumn
        {
            get { return Schema.Columns[259]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteIsoinmunizacionesSiColumn
        {
            get { return Schema.Columns[260]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteIsoinmunizacionesNoColumn
        {
            get { return Schema.Columns[261]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualIsoinmunizacionesSiColumn
        {
            get { return Schema.Columns[262]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualIsoinmunizacionesNoColumn
        {
            get { return Schema.Columns[263]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteColestasisSiColumn
        {
            get { return Schema.Columns[264]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteColestasisNoColumn
        {
            get { return Schema.Columns[265]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualColestasisSiColumn
        {
            get { return Schema.Columns[266]; }
        }
        
        
        
        public static TableSchema.TableColumn OAActualColestasisNoColumn
        {
            get { return Schema.Columns[267]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteMortPerinatalRecurrenteSiColumn
        {
            get { return Schema.Columns[268]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteMortPerinatalRecurrenteNoColumn
        {
            get { return Schema.Columns[269]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteRetencionPlacentaSiColumn
        {
            get { return Schema.Columns[270]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteRetencionPlacentaNoColumn
        {
            get { return Schema.Columns[271]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteDistociaHombrosSiColumn
        {
            get { return Schema.Columns[272]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteDistociaHombrosNoColumn
        {
            get { return Schema.Columns[273]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteMalformCongenSiColumn
        {
            get { return Schema.Columns[274]; }
        }
        
        
        
        public static TableSchema.TableColumn OAAntecedenteMalformCongenNoColumn
        {
            get { return Schema.Columns[275]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoEmbarazoSinContSocialSiColumn
        {
            get { return Schema.Columns[276]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoEmbarazoSinContSocialNoColumn
        {
            get { return Schema.Columns[277]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoFamiliaSinIngresosFijosSiColumn
        {
            get { return Schema.Columns[278]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoFamiliaSinIngresosFijosNoColumn
        {
            get { return Schema.Columns[279]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoEmbarazoFuertRechazadoSiColumn
        {
            get { return Schema.Columns[280]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoEmbarazoFuertRechazadoNoColumn
        {
            get { return Schema.Columns[281]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoHijosDadosAdopcionSiColumn
        {
            get { return Schema.Columns[282]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoHijosDadosAdopcionNoColumn
        {
            get { return Schema.Columns[283]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoViviendaSinServiciosBasicosSiColumn
        {
            get { return Schema.Columns[284]; }
        }
        
        
        
        public static TableSchema.TableColumn FactorRiesgoViviendaSinServiciosBasicosNoColumn
        {
            get { return Schema.Columns[285]; }
        }
        
        
        
        public static TableSchema.TableColumn CaptacionOportunaAntes16semColumn
        {
            get { return Schema.Columns[286]; }
        }
        
        
        
        public static TableSchema.TableColumn CaptacionOportunaDespues16semColumn
        {
            get { return Schema.Columns[287]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaMuestraPAPColumn
        {
            get { return Schema.Columns[288]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTripleAcelularColumn
        {
            get { return Schema.Columns[289]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAntigripalColumn
        {
            get { return Schema.Columns[290]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHSegundaMuestraSolicitadoSiColumn
        {
            get { return Schema.Columns[291]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHSegundaMuestraSolicitadoNoColumn
        {
            get { return Schema.Columns[292]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHSegundaMuestraRealizadoSiColumn
        {
            get { return Schema.Columns[293]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHSegundaMuestraRealizadoNoColumn
        {
            get { return Schema.Columns[294]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHSegundaMuestraFechaColumn
        {
            get { return Schema.Columns[295]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHTercerMuestraSolicitadoSiColumn
        {
            get { return Schema.Columns[296]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHTercerMuestraSolicitadoNoColumn
        {
            get { return Schema.Columns[297]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHTercerMuestraRealizadoSiColumn
        {
            get { return Schema.Columns[298]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHTercerMuestraRealizadoNoColumn
        {
            get { return Schema.Columns[299]; }
        }
        
        
        
        public static TableSchema.TableColumn VIHTercerMuestraFechaColumn
        {
            get { return Schema.Columns[300]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoPrimerMuestraColumn
        {
            get { return Schema.Columns[301]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoPrimerMuestraNegativoColumn
        {
            get { return Schema.Columns[302]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoPrimerMuestraPositivoColumn
        {
            get { return Schema.Columns[303]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoPrimerMuestraSinDatosColumn
        {
            get { return Schema.Columns[304]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoPrimerMuestraFechaColumn
        {
            get { return Schema.Columns[305]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoSegundaMuestraColumn
        {
            get { return Schema.Columns[306]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoSegundaMuestraNegativoColumn
        {
            get { return Schema.Columns[307]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoSegundaMuestraPositivoColumn
        {
            get { return Schema.Columns[308]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoSegundaMuestraSinDatosColumn
        {
            get { return Schema.Columns[309]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoSegundaMuestraFechaColumn
        {
            get { return Schema.Columns[310]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoTercerMuestraColumn
        {
            get { return Schema.Columns[311]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoTercerMuestraNegativoColumn
        {
            get { return Schema.Columns[312]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoTercerMuestraPositivoColumn
        {
            get { return Schema.Columns[313]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoTercerMuestraSinDatosColumn
        {
            get { return Schema.Columns[314]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaNoTrepoTercerMuestraFechaColumn
        {
            get { return Schema.Columns[315]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoPrimerMuestraColumn
        {
            get { return Schema.Columns[316]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoPrimerMuestraNegativoColumn
        {
            get { return Schema.Columns[317]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoPrimerMuestraPositivoColumn
        {
            get { return Schema.Columns[318]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoPrimerMuestraSinDatosColumn
        {
            get { return Schema.Columns[319]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoPrimerMuestraNoCorrespondeColumn
        {
            get { return Schema.Columns[320]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoPrimerMuestraFechaColumn
        {
            get { return Schema.Columns[321]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoSegundaMuestraColumn
        {
            get { return Schema.Columns[322]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoSegundaMuestraNegativoColumn
        {
            get { return Schema.Columns[323]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoSegundaMuestraPositivoColumn
        {
            get { return Schema.Columns[324]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoSegundaMuestraSinDatosColumn
        {
            get { return Schema.Columns[325]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoSegundaMuestraNoCorrespondeColumn
        {
            get { return Schema.Columns[326]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoSegundaMuestraFechaColumn
        {
            get { return Schema.Columns[327]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoTercerMuestraColumn
        {
            get { return Schema.Columns[328]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoTercerMuestraNegativoColumn
        {
            get { return Schema.Columns[329]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoTercerMuestraPositivoColumn
        {
            get { return Schema.Columns[330]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoTercerMuestraSinDatosColumn
        {
            get { return Schema.Columns[331]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoTercerMuestraNoCorrespondeColumn
        {
            get { return Schema.Columns[332]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisPruebaTrepoTercerMuestraFechaColumn
        {
            get { return Schema.Columns[333]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoPrimerMuestraColumn
        {
            get { return Schema.Columns[334]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoPrimerMuestraNoColumn
        {
            get { return Schema.Columns[335]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoPrimerMuestraSiColumn
        {
            get { return Schema.Columns[336]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoPrimerMuestraSinDatosColumn
        {
            get { return Schema.Columns[337]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoPrimerMuestraNoCorrespondeColumn
        {
            get { return Schema.Columns[338]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoPrimerMuestraFechaColumn
        {
            get { return Schema.Columns[339]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoSegundaMuestraColumn
        {
            get { return Schema.Columns[340]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoSegundaMuestraNoColumn
        {
            get { return Schema.Columns[341]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoSegundaMuestraSiColumn
        {
            get { return Schema.Columns[342]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoSegundaMuestraSinDatosColumn
        {
            get { return Schema.Columns[343]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoSegundaMuestraNoCorrespondeColumn
        {
            get { return Schema.Columns[344]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoSegundaMuestraFechaColumn
        {
            get { return Schema.Columns[345]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoTercerMuestraColumn
        {
            get { return Schema.Columns[346]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoTercerMuestraNoColumn
        {
            get { return Schema.Columns[347]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoTercerMuestraSiColumn
        {
            get { return Schema.Columns[348]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoTercerMuestraSinDatosColumn
        {
            get { return Schema.Columns[349]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoTercerMuestraNoCorrespondeColumn
        {
            get { return Schema.Columns[350]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisTratamientoTercerMuestraFechaColumn
        {
            get { return Schema.Columns[351]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivaColumn
        {
            get { return Schema.Columns[352]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[353]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[354]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[355]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[356]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[357]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorTrasladoUtColumn
        {
            get { return Schema.Columns[358]; }
        }
        
        
        
        public static TableSchema.TableColumn DiabetesActualSiColumn
        {
            get { return Schema.Columns[359]; }
        }
        
        
        
        public static TableSchema.TableColumn DiabetesActualNoColumn
        {
            get { return Schema.Columns[360]; }
        }
        
        
        
        public static TableSchema.TableColumn AnemiaSiColumn
        {
            get { return Schema.Columns[361]; }
        }
        
        
        
        public static TableSchema.TableColumn AnemiaNoColumn
        {
            get { return Schema.Columns[362]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroIdentidadColumn
        {
            get { return Schema.Columns[363]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHistoriaClinicaPerinatal = @"idHistoriaClinicaPerinatal";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string Nombre = @"Nombre";
			 public static string Apellido = @"Apellido";
			 public static string Domicilio = @"Domicilio";
			 public static string Dni = @"DNI";
			 public static string Localidad = @"Localidad";
			 public static string Telefono = @"Telefono";
			 public static string FechaNacimiento = @"FechaNacimiento";
			 public static string Edad = @"Edad";
			 public static string DatosDeContacto = @"DatosDeContacto";
			 public static string EdadMenor15Mayor35 = @"EdadMenor15Mayor35";
			 public static string EtniaBlanca = @"EtniaBlanca";
			 public static string EtniaIndigena = @"EtniaIndigena";
			 public static string EtniaMestiza = @"EtniaMestiza";
			 public static string EtniaNegra = @"EtniaNegra";
			 public static string EtniaOtra = @"EtniaOtra";
			 public static string AlfabetaSi = @"AlfabetaSi";
			 public static string AlfabetaNo = @"AlfabetaNo";
			 public static string EstudiosNinguno = @"EstudiosNinguno";
			 public static string EstudiosPrimario = @"EstudiosPrimario";
			 public static string EstudiosSecundario = @"EstudiosSecundario";
			 public static string EstudiosUniversitario = @"EstudiosUniversitario";
			 public static string AñosMayorNivel = @"AñosMayorNivel";
			 public static string EstadoCivilCasada = @"EstadoCivilCasada";
			 public static string EstadoCivilUnionEstable = @"EstadoCivilUnionEstable";
			 public static string EstadoCivilSoltera = @"EstadoCivilSoltera";
			 public static string EstadoCivilOtro = @"EstadoCivilOtro";
			 public static string ViveSolaSi = @"ViveSolaSi";
			 public static string ViveSolaNo = @"ViveSolaNo";
			 public static string LugarControlPerinatal = @"LugarControlPerinatal";
			 public static string LugarPartoAborto = @"LugarPartoAborto";
			 public static string AntFamTBCSi = @"AntFamTBCSi";
			 public static string AntFamTBCNo = @"AntFamTBCNo";
			 public static string AntFamDiabetesSi = @"AntFamDiabetesSi";
			 public static string AntFamDiabetesNo = @"AntFamDiabetesNo";
			 public static string AntFamHipertensionSi = @"AntFamHipertensionSi";
			 public static string AntFamHipertensionNo = @"AntFamHipertensionNo";
			 public static string AntFamInfeccionUrinariaSi = @"AntFamInfeccionUrinariaSi";
			 public static string AntFamInfeccionUrinariaNo = @"AntFamInfeccionUrinariaNo";
			 public static string AntFamOtrasInfeccionesSi = @"AntFamOtrasInfeccionesSi";
			 public static string AntFamOtrasInfeccionesNo = @"AntFamOtrasInfeccionesNo";
			 public static string AntFamOtroSi = @"AntFamOtroSi";
			 public static string AntFamOtroNo = @"AntFamOtroNo";
			 public static string AntPerTBCSi = @"AntPerTBCSi";
			 public static string AntPerTBCNo = @"AntPerTBCNo";
			 public static string AntPerDiabetesI = @"AntPerDiabetesI";
			 public static string AntPerDiabetesII = @"AntPerDiabetesII";
			 public static string AntPerDiabetesG = @"AntPerDiabetesG";
			 public static string AntPerDiabetesNo = @"AntPerDiabetesNo";
			 public static string AntPerHipertensionSi = @"AntPerHipertensionSi";
			 public static string AntPerHipertensionNo = @"AntPerHipertensionNo";
			 public static string AntPerInfeccionUrinariaSi = @"AntPerInfeccionUrinariaSi";
			 public static string AntPerInfeccionUrinariaNo = @"AntPerInfeccionUrinariaNo";
			 public static string AntPerOtrasInfeccionesSi = @"AntPerOtrasInfeccionesSi";
			 public static string AntPerOtrasInfeccionesNo = @"AntPerOtrasInfeccionesNo";
			 public static string AntPerOtroSi = @"AntPerOtroSi";
			 public static string AntPerOtroNo = @"AntPerOtroNo";
			 public static string AntPerInfertilidadSi = @"AntPerInfertilidadSi";
			 public static string AntPerInfertilidadNo = @"AntPerInfertilidadNo";
			 public static string AntPerCardiopatiaSi = @"AntPerCardiopatiaSi";
			 public static string AntPerCardiopatiaNo = @"AntPerCardiopatiaNo";
			 public static string AntPerNefropatiaSi = @"AntPerNefropatiaSi";
			 public static string AntPerNefropatiaNo = @"AntPerNefropatiaNo";
			 public static string AntPerViolenciaSi = @"AntPerViolenciaSi";
			 public static string AntPerViolenciaNo = @"AntPerViolenciaNo";
			 public static string AntPerAlergiaMedicamentoSi = @"AntPerAlergiaMedicamentoSi";
			 public static string AntPerAlergiaMedicamentoNo = @"AntPerAlergiaMedicamentoNo";
			 public static string AntecedentesObservacion = @"AntecedentesObservacion";
			 public static string GestasPrevias = @"GestasPrevias";
			 public static string Abortos = @"Abortos";
			 public static string EmbEctopicos = @"EmbEctopicos";
			 public static string Abortos3concecutivos = @"Abortos3concecutivos";
			 public static string Partos = @"Partos";
			 public static string PartosVaginales = @"PartosVaginales";
			 public static string Cesareas = @"Cesareas";
			 public static string NacidosVivos = @"NacidosVivos";
			 public static string NacidosMuertos = @"NacidosMuertos";
			 public static string Viven = @"Viven";
			 public static string MuertosPrimerSemana = @"MuertosPrimerSemana";
			 public static string MuertosDespuesPrimerSemana = @"MuertosDespuesPrimerSemana";
			 public static string AntecedentesGemelaresSi = @"AntecedentesGemelaresSi";
			 public static string AntecedentesGemelaresNo = @"AntecedentesGemelaresNo";
			 public static string UltPrevioNC = @"UltPrevioNC";
			 public static string UltPrevioNormal = @"UltPrevioNormal";
			 public static string UltPrevioMenor2500 = @"UltPrevioMenor2500";
			 public static string UltPrevioMayor4000 = @"UltPrevioMayor4000";
			 public static string FinEmbarazoAnterior = @"FinEmbarazoAnterior";
			 public static string FinEmbAnteriorMenor1Año = @"FinEmbAnteriorMenor1Año";
			 public static string EmbarazoPlaneadoSi = @"EmbarazoPlaneadoSi";
			 public static string EmbarazoPlaneadoNo = @"EmbarazoPlaneadoNo";
			 public static string FracMetAnticonceptivoNoUsaba = @"FracMetAnticonceptivoNoUsaba";
			 public static string FracMetAnticonceptivoBarrera = @"FracMetAnticonceptivoBarrera";
			 public static string FracMetAnticonceptivoDIU = @"FracMetAnticonceptivoDIU";
			 public static string FracMetAnticonceptivoHormonal = @"FracMetAnticonceptivoHormonal";
			 public static string FracMetAnticonceptivoEmergencia = @"FracMetAnticonceptivoEmergencia";
			 public static string FracMetAnticonceptivoNatural = @"FracMetAnticonceptivoNatural";
			 public static string PesoAnterior = @"PesoAnterior";
			 public static string Talla = @"Talla";
			 public static string Fum = @"FUM";
			 public static string Fpp = @"FPP";
			 public static string EGConfiableFUMSi = @"EGConfiableFUMSi";
			 public static string EGConfiableFUMNo = @"EGConfiableFUMNo";
			 public static string EGConfiableEcoMenor20semanasSi = @"EGConfiableEcoMenor20semanasSi";
			 public static string EGConfiableEcoMenor20semanasNo = @"EGConfiableEcoMenor20semanasNo";
			 public static string FumaActivo1TrimSi = @"FumaActivo1TrimSi";
			 public static string FumaActivo1TrimNo = @"FumaActivo1TrimNo";
			 public static string FumaActivo2TrimSi = @"FumaActivo2TrimSi";
			 public static string FumaActivo2TrimNo = @"FumaActivo2TrimNo";
			 public static string FumaActivo3TrimSi = @"FumaActivo3TrimSi";
			 public static string FumaActivo3TrimNo = @"FumaActivo3TrimNo";
			 public static string FumaPasivo1TrimSi = @"FumaPasivo1TrimSi";
			 public static string FumaPasivo1TrimNo = @"FumaPasivo1TrimNo";
			 public static string FumaPasivo2TrimSi = @"FumaPasivo2TrimSi";
			 public static string FumaPasivo2TrimNo = @"FumaPasivo2TrimNo";
			 public static string FumaPasivo3TrimSi = @"FumaPasivo3TrimSi";
			 public static string FumaPasivo3TrimNo = @"FumaPasivo3TrimNo";
			 public static string Drogas1TrimSi = @"Drogas1TrimSi";
			 public static string Drogas1TrimNo = @"Drogas1TrimNo";
			 public static string Drogas2TrimSi = @"Drogas2TrimSi";
			 public static string Drogas2TrimNo = @"Drogas2TrimNo";
			 public static string Drogas3TrimSi = @"Drogas3TrimSi";
			 public static string Drogas3TrimNo = @"Drogas3TrimNo";
			 public static string Alcohol1TrimSi = @"Alcohol1TrimSi";
			 public static string Alcohol1TrimNo = @"Alcohol1TrimNo";
			 public static string Alcohol2TrimSi = @"Alcohol2TrimSi";
			 public static string Alcohol2TrimNo = @"Alcohol2TrimNo";
			 public static string Alcohol3TrimSi = @"Alcohol3TrimSi";
			 public static string Alcohol3TrimNo = @"Alcohol3TrimNo";
			 public static string Violencia1TrimSi = @"Violencia1TrimSi";
			 public static string Violencia1TrimNo = @"Violencia1TrimNo";
			 public static string Violencia2TrimSi = @"Violencia2TrimSi";
			 public static string Violencia2TrimNo = @"Violencia2TrimNo";
			 public static string Violencia3TrimSi = @"Violencia3TrimSi";
			 public static string Violencia3TrimNo = @"Violencia3TrimNo";
			 public static string AntirubeolaPrevia = @"AntirubeolaPrevia";
			 public static string AntirubeolaNoSabe = @"AntirubeolaNoSabe";
			 public static string AntirubeolaEmbarazo = @"AntirubeolaEmbarazo";
			 public static string AntirubeolaNo = @"AntirubeolaNo";
			 public static string AntitetanicaVigenteNo = @"AntitetanicaVigenteNo";
			 public static string AntitetanicaVigenteSi = @"AntitetanicaVigenteSi";
			 public static string Antitetanica1DosisMesGestacion = @"Antitetanica1DosisMesGestacion";
			 public static string Antitetanica2DosisMesGestacion = @"Antitetanica2DosisMesGestacion";
			 public static string ExamenOdotologicoNormalSi = @"ExamenOdotologicoNormalSi";
			 public static string ExamenOdotologicoNormalNo = @"ExamenOdotologicoNormalNo";
			 public static string ExamenMamasNormalSi = @"ExamenMamasNormalSi";
			 public static string ExamenMamasNormalNo = @"ExamenMamasNormalNo";
			 public static string CervixInspeccionVisualNormal = @"CervixInspeccionVisualNormal";
			 public static string CervixInspeccionVisualAnormal = @"CervixInspeccionVisualAnormal";
			 public static string CervixInspeccionVisualNoSeHizo = @"CervixInspeccionVisualNoSeHizo";
			 public static string CervixPAPNormal = @"CervixPAPNormal";
			 public static string CervixPAPAnormal = @"CervixPAPAnormal";
			 public static string CervixPAPNoSeHizo = @"CervixPAPNoSeHizo";
			 public static string CervixCOLPNormal = @"CervixCOLPNormal";
			 public static string CervixCOLPAnormal = @"CervixCOLPAnormal";
			 public static string CervixCOLPNoSeHizo = @"CervixCOLPNoSeHizo";
			 public static string Grupo = @"Grupo";
			 public static string RHPositivo = @"RHPositivo";
			 public static string RHNegativo = @"RHNegativo";
			 public static string InmunizacionSi = @"InmunizacionSi";
			 public static string InmunizacionNo = @"InmunizacionNo";
			 public static string GammaGlobulinaNo = @"GammaGlobulinaNo";
			 public static string GammaGlobulinaSi = @"GammaGlobulinaSi";
			 public static string GammaGlobulinaNoCorresponde = @"GammaGlobulinaNoCorresponde";
			 public static string ToxoPlasmosisMenor20SemLGGNegativo = @"ToxoPlasmosisMenor20SemLGGNegativo";
			 public static string ToxoPlasmosisMenor20SemLGGPositivo = @"ToxoPlasmosisMenor20SemLGGPositivo";
			 public static string ToxoPlasmosisMenor20SemLGGNoSeHizo = @"ToxoPlasmosisMenor20SemLGGNoSeHizo";
			 public static string ToxoPlasmosisMayor20SemLGGNegativo = @"ToxoPlasmosisMayor20SemLGGNegativo";
			 public static string ToxoPlasmosisMayor20SemLGGPositivo = @"ToxoPlasmosisMayor20SemLGGPositivo";
			 public static string ToxoPlasmosisMayor20SemLGGNoSeHizo = @"ToxoPlasmosisMayor20SemLGGNoSeHizo";
			 public static string ToxoPlasmosis1ConsultaLGMNegativo = @"ToxoPlasmosis1ConsultaLGMNegativo";
			 public static string ToxoPlasmosis1ConsultaLGMPositivo = @"ToxoPlasmosis1ConsultaLGMPositivo";
			 public static string ToxoPlasmosis1ConsultaLGMNoSeHizo = @"ToxoPlasmosis1ConsultaLGMNoSeHizo";
			 public static string ChagasNegativo = @"ChagasNegativo";
			 public static string ChagasPositivo = @"ChagasPositivo";
			 public static string ChagasNoSeHizo = @"ChagasNoSeHizo";
			 public static string HepatitisBNegativo = @"HepatitisBNegativo";
			 public static string HepatitisBPositivo = @"HepatitisBPositivo";
			 public static string HepatitisBNoSeHizo = @"HepatitisBNoSeHizo";
			 public static string BacteriuraMenor20SemNormal = @"BacteriuraMenor20SemNormal";
			 public static string BacteriuraMenor20SemAnormal = @"BacteriuraMenor20SemAnormal";
			 public static string BacteriuraMenor20SemNoSeHizo = @"BacteriuraMenor20SemNoSeHizo";
			 public static string BacteriuraMayor20SemNormal = @"BacteriuraMayor20SemNormal";
			 public static string BacteriuraMayor20SemAnormal = @"BacteriuraMayor20SemAnormal";
			 public static string BacteriuraMayor20SemNoSeHizo = @"BacteriuraMayor20SemNoSeHizo";
			 public static string GlucemiaMenor20Sem = @"GlucemiaMenor20Sem";
			 public static string GlucemiaMenor20SemMayor105 = @"GlucemiaMenor20SemMayor105";
			 public static string GlucemiaMayor20Sem = @"GlucemiaMayor20Sem";
			 public static string GlucemiaMayor20SemMayor105 = @"GlucemiaMayor20SemMayor105";
			 public static string VIHCRSi = @"VIHCRSi";
			 public static string VIHCRNo = @"VIHCRNo";
			 public static string VIHPrimerMuestraSolicitadoSi = @"VIHPrimerMuestraSolicitadoSi";
			 public static string VIHPrimerMuestraSolicitadoNo = @"VIHPrimerMuestraSolicitadoNo";
			 public static string VIHPrimerMuestraRealizadoSi = @"VIHPrimerMuestraRealizadoSi";
			 public static string VIHPrimerMuestraRealizadoNo = @"VIHPrimerMuestraRealizadoNo";
			 public static string VIHPrimerMuestraFecha = @"VIHPrimerMuestraFecha";
			 public static string HBMenor20Sem = @"HBMenor20Sem";
			 public static string HBMenor20SemMenor11 = @"HBMenor20SemMenor11";
			 public static string HBMayor20Sem = @"HBMayor20Sem";
			 public static string HBMayor20SemMenor11 = @"HBMayor20SemMenor11";
			 public static string FeIndicadoSi = @"FeIndicadoSi";
			 public static string FeIndicadoNo = @"FeIndicadoNo";
			 public static string FolatosIndicadosSi = @"FolatosIndicadosSi";
			 public static string FolatosIndicadosNo = @"FolatosIndicadosNo";
			 public static string EstreptococoB3537SemanasNegativo = @"EstreptococoB3537SemanasNegativo";
			 public static string EstreptococoB3537SemanasPositivo = @"EstreptococoB3537SemanasPositivo";
			 public static string EstreptococoB3537SemanasNoSeHizo = @"EstreptococoB3537SemanasNoSeHizo";
			 public static string PreparacionPartoSi = @"PreparacionPartoSi";
			 public static string PreparacionPartoNo = @"PreparacionPartoNo";
			 public static string ConsejeriaLactanciaMaternaSi = @"ConsejeriaLactanciaMaternaSi";
			 public static string ConsejeriaLactanciaMaternaNo = @"ConsejeriaLactanciaMaternaNo";
			 public static string SifilisTratParejaMenor20SemNo = @"SifilisTratParejaMenor20SemNo";
			 public static string SifilisTratParejaMenor20SemSi = @"SifilisTratParejaMenor20SemSi";
			 public static string SifilisTratParejaMenor20SemSinDatos = @"SifilisTratParejaMenor20SemSinDatos";
			 public static string SifilisTratParejaMenor20SemNoCorresponde = @"SifilisTratParejaMenor20SemNoCorresponde";
			 public static string SifilisTratParejaMayor20SemNo = @"SifilisTratParejaMayor20SemNo";
			 public static string SifilisTratParejaMayor20SemSi = @"SifilisTratParejaMayor20SemSi";
			 public static string SifilisTratParejaMayor20SemSinDatos = @"SifilisTratParejaMayor20SemSinDatos";
			 public static string SifilisTratParejaMayor20SemNoCorresponde = @"SifilisTratParejaMayor20SemNoCorresponde";
			 public static string OAAntecedenteEclampsiaSi = @"OAAntecedenteEclampsiaSi";
			 public static string OAAntecedenteEclampsiaNo = @"OAAntecedenteEclampsiaNo";
			 public static string OAActualEclampsiaSi = @"OAActualEclampsiaSi";
			 public static string OAActualEclampsiaNo = @"OAActualEclampsiaNo";
			 public static string OAAntecedentePreeclampsiaSi = @"OAAntecedentePreeclampsiaSi";
			 public static string OAAntecedentePreeclampsiaNo = @"OAAntecedentePreeclampsiaNo";
			 public static string OAActualPreeclampsiaSi = @"OAActualPreeclampsiaSi";
			 public static string OAActualPreeclampsiaNo = @"OAActualPreeclampsiaNo";
			 public static string OAAntecedenteCirugiaGinUrinarSi = @"OAAntecedenteCirugiaGinUrinarSi";
			 public static string OAAntecedenteCirugiaGinUrinarNo = @"OAAntecedenteCirugiaGinUrinarNo";
			 public static string OAActualCirugiaGinUrinarSi = @"OAActualCirugiaGinUrinarSi";
			 public static string OAActualCirugiaGinUrinarNo = @"OAActualCirugiaGinUrinarNo";
			 public static string OAAntecedenteAPPrematuroSi = @"OAAntecedenteAPPrematuroSi";
			 public static string OAAntecedenteAPPrematuroNo = @"OAAntecedenteAPPrematuroNo";
			 public static string OAActualAPPrematuroSi = @"OAActualAPPrematuroSi";
			 public static string OAActualAPPrematuroNo = @"OAActualAPPrematuroNo";
			 public static string OAAntecedenteRCIUSi = @"OAAntecedenteRCIUSi";
			 public static string OAAntecedenteRCIUNo = @"OAAntecedenteRCIUNo";
			 public static string OAActualRCIUSi = @"OAActualRCIUSi";
			 public static string OAActualRCIUNo = @"OAActualRCIUNo";
			 public static string OAAntecedenteHemorragiaObstetricaSi = @"OAAntecedenteHemorragiaObstetricaSi";
			 public static string OAAntecedenteHemorragiaObstetricaNo = @"OAAntecedenteHemorragiaObstetricaNo";
			 public static string OAActualHemorragiaObstetricaSi = @"OAActualHemorragiaObstetricaSi";
			 public static string OAActualHemorragiaObstetricaNo = @"OAActualHemorragiaObstetricaNo";
			 public static string OAAntecedenteMacrosomiaFetalSi = @"OAAntecedenteMacrosomiaFetalSi";
			 public static string OAAntecedenteMacrosomiaFetalNo = @"OAAntecedenteMacrosomiaFetalNo";
			 public static string OAActualMacrosomiaFetalSi = @"OAActualMacrosomiaFetalSi";
			 public static string OAActualMacrosomiaFetalNo = @"OAActualMacrosomiaFetalNo";
			 public static string OAAntecedentePolihidramniosSi = @"OAAntecedentePolihidramniosSi";
			 public static string OAAntecedentePolihidramniosNo = @"OAAntecedentePolihidramniosNo";
			 public static string OAActualPolihidramniosSi = @"OAActualPolihidramniosSi";
			 public static string OAActualPolihidramniosNo = @"OAActualPolihidramniosNo";
			 public static string OAAntecedenteOligoanmiosSi = @"OAAntecedenteOligoanmiosSi";
			 public static string OAAntecedenteOligoanmiosNo = @"OAAntecedenteOligoanmiosNo";
			 public static string OAActualOligoanmiosSi = @"OAActualOligoanmiosSi";
			 public static string OAActualOligoanmiosNo = @"OAActualOligoanmiosNo";
			 public static string OAAntecedenteRotPremMembranasSi = @"OAAntecedenteRotPremMembranasSi";
			 public static string OAAntecedenteRotPremMembranasNo = @"OAAntecedenteRotPremMembranasNo";
			 public static string OAActualRotPremMembranasSi = @"OAActualRotPremMembranasSi";
			 public static string OAActualRotPremMembranasNo = @"OAActualRotPremMembranasNo";
			 public static string OAAntecedenteIsoinmunizacionesSi = @"OAAntecedenteIsoinmunizacionesSi";
			 public static string OAAntecedenteIsoinmunizacionesNo = @"OAAntecedenteIsoinmunizacionesNo";
			 public static string OAActualIsoinmunizacionesSi = @"OAActualIsoinmunizacionesSi";
			 public static string OAActualIsoinmunizacionesNo = @"OAActualIsoinmunizacionesNo";
			 public static string OAAntecedenteColestasisSi = @"OAAntecedenteColestasisSi";
			 public static string OAAntecedenteColestasisNo = @"OAAntecedenteColestasisNo";
			 public static string OAActualColestasisSi = @"OAActualColestasisSi";
			 public static string OAActualColestasisNo = @"OAActualColestasisNo";
			 public static string OAAntecedenteMortPerinatalRecurrenteSi = @"OAAntecedenteMortPerinatalRecurrenteSi";
			 public static string OAAntecedenteMortPerinatalRecurrenteNo = @"OAAntecedenteMortPerinatalRecurrenteNo";
			 public static string OAAntecedenteRetencionPlacentaSi = @"OAAntecedenteRetencionPlacentaSi";
			 public static string OAAntecedenteRetencionPlacentaNo = @"OAAntecedenteRetencionPlacentaNo";
			 public static string OAAntecedenteDistociaHombrosSi = @"OAAntecedenteDistociaHombrosSi";
			 public static string OAAntecedenteDistociaHombrosNo = @"OAAntecedenteDistociaHombrosNo";
			 public static string OAAntecedenteMalformCongenSi = @"OAAntecedenteMalformCongenSi";
			 public static string OAAntecedenteMalformCongenNo = @"OAAntecedenteMalformCongenNo";
			 public static string FactorRiesgoEmbarazoSinContSocialSi = @"FactorRiesgoEmbarazoSinContSocialSi";
			 public static string FactorRiesgoEmbarazoSinContSocialNo = @"FactorRiesgoEmbarazoSinContSocialNo";
			 public static string FactorRiesgoFamiliaSinIngresosFijosSi = @"FactorRiesgoFamiliaSinIngresosFijosSi";
			 public static string FactorRiesgoFamiliaSinIngresosFijosNo = @"FactorRiesgoFamiliaSinIngresosFijosNo";
			 public static string FactorRiesgoEmbarazoFuertRechazadoSi = @"FactorRiesgoEmbarazoFuertRechazadoSi";
			 public static string FactorRiesgoEmbarazoFuertRechazadoNo = @"FactorRiesgoEmbarazoFuertRechazadoNo";
			 public static string FactorRiesgoHijosDadosAdopcionSi = @"FactorRiesgoHijosDadosAdopcionSi";
			 public static string FactorRiesgoHijosDadosAdopcionNo = @"FactorRiesgoHijosDadosAdopcionNo";
			 public static string FactorRiesgoViviendaSinServiciosBasicosSi = @"FactorRiesgoViviendaSinServiciosBasicosSi";
			 public static string FactorRiesgoViviendaSinServiciosBasicosNo = @"FactorRiesgoViviendaSinServiciosBasicosNo";
			 public static string CaptacionOportunaAntes16sem = @"CaptacionOportunaAntes16sem";
			 public static string CaptacionOportunaDespues16sem = @"CaptacionOportunaDespues16sem";
			 public static string FechaMuestraPAP = @"FechaMuestraPAP";
			 public static string FechaTripleAcelular = @"FechaTripleAcelular";
			 public static string FechaAntigripal = @"FechaAntigripal";
			 public static string VIHSegundaMuestraSolicitadoSi = @"VIHSegundaMuestraSolicitadoSi";
			 public static string VIHSegundaMuestraSolicitadoNo = @"VIHSegundaMuestraSolicitadoNo";
			 public static string VIHSegundaMuestraRealizadoSi = @"VIHSegundaMuestraRealizadoSi";
			 public static string VIHSegundaMuestraRealizadoNo = @"VIHSegundaMuestraRealizadoNo";
			 public static string VIHSegundaMuestraFecha = @"VIHSegundaMuestraFecha";
			 public static string VIHTercerMuestraSolicitadoSi = @"VIHTercerMuestraSolicitadoSi";
			 public static string VIHTercerMuestraSolicitadoNo = @"VIHTercerMuestraSolicitadoNo";
			 public static string VIHTercerMuestraRealizadoSi = @"VIHTercerMuestraRealizadoSi";
			 public static string VIHTercerMuestraRealizadoNo = @"VIHTercerMuestraRealizadoNo";
			 public static string VIHTercerMuestraFecha = @"VIHTercerMuestraFecha";
			 public static string SifilisPruebaNoTrepoPrimerMuestra = @"SifilisPruebaNoTrepoPrimerMuestra";
			 public static string SifilisPruebaNoTrepoPrimerMuestraNegativo = @"SifilisPruebaNoTrepoPrimerMuestraNegativo";
			 public static string SifilisPruebaNoTrepoPrimerMuestraPositivo = @"SifilisPruebaNoTrepoPrimerMuestraPositivo";
			 public static string SifilisPruebaNoTrepoPrimerMuestraSinDatos = @"SifilisPruebaNoTrepoPrimerMuestraSinDatos";
			 public static string SifilisPruebaNoTrepoPrimerMuestraFecha = @"SifilisPruebaNoTrepoPrimerMuestraFecha";
			 public static string SifilisPruebaNoTrepoSegundaMuestra = @"SifilisPruebaNoTrepoSegundaMuestra";
			 public static string SifilisPruebaNoTrepoSegundaMuestraNegativo = @"SifilisPruebaNoTrepoSegundaMuestraNegativo";
			 public static string SifilisPruebaNoTrepoSegundaMuestraPositivo = @"SifilisPruebaNoTrepoSegundaMuestraPositivo";
			 public static string SifilisPruebaNoTrepoSegundaMuestraSinDatos = @"SifilisPruebaNoTrepoSegundaMuestraSinDatos";
			 public static string SifilisPruebaNoTrepoSegundaMuestraFecha = @"SifilisPruebaNoTrepoSegundaMuestraFecha";
			 public static string SifilisPruebaNoTrepoTercerMuestra = @"SifilisPruebaNoTrepoTercerMuestra";
			 public static string SifilisPruebaNoTrepoTercerMuestraNegativo = @"SifilisPruebaNoTrepoTercerMuestraNegativo";
			 public static string SifilisPruebaNoTrepoTercerMuestraPositivo = @"SifilisPruebaNoTrepoTercerMuestraPositivo";
			 public static string SifilisPruebaNoTrepoTercerMuestraSinDatos = @"SifilisPruebaNoTrepoTercerMuestraSinDatos";
			 public static string SifilisPruebaNoTrepoTercerMuestraFecha = @"SifilisPruebaNoTrepoTercerMuestraFecha";
			 public static string SifilisPruebaTrepoPrimerMuestra = @"SifilisPruebaTrepoPrimerMuestra";
			 public static string SifilisPruebaTrepoPrimerMuestraNegativo = @"SifilisPruebaTrepoPrimerMuestraNegativo";
			 public static string SifilisPruebaTrepoPrimerMuestraPositivo = @"SifilisPruebaTrepoPrimerMuestraPositivo";
			 public static string SifilisPruebaTrepoPrimerMuestraSinDatos = @"SifilisPruebaTrepoPrimerMuestraSinDatos";
			 public static string SifilisPruebaTrepoPrimerMuestraNoCorresponde = @"SifilisPruebaTrepoPrimerMuestraNoCorresponde";
			 public static string SifilisPruebaTrepoPrimerMuestraFecha = @"SifilisPruebaTrepoPrimerMuestraFecha";
			 public static string SifilisPruebaTrepoSegundaMuestra = @"SifilisPruebaTrepoSegundaMuestra";
			 public static string SifilisPruebaTrepoSegundaMuestraNegativo = @"SifilisPruebaTrepoSegundaMuestraNegativo";
			 public static string SifilisPruebaTrepoSegundaMuestraPositivo = @"SifilisPruebaTrepoSegundaMuestraPositivo";
			 public static string SifilisPruebaTrepoSegundaMuestraSinDatos = @"SifilisPruebaTrepoSegundaMuestraSinDatos";
			 public static string SifilisPruebaTrepoSegundaMuestraNoCorresponde = @"SifilisPruebaTrepoSegundaMuestraNoCorresponde";
			 public static string SifilisPruebaTrepoSegundaMuestraFecha = @"SifilisPruebaTrepoSegundaMuestraFecha";
			 public static string SifilisPruebaTrepoTercerMuestra = @"SifilisPruebaTrepoTercerMuestra";
			 public static string SifilisPruebaTrepoTercerMuestraNegativo = @"SifilisPruebaTrepoTercerMuestraNegativo";
			 public static string SifilisPruebaTrepoTercerMuestraPositivo = @"SifilisPruebaTrepoTercerMuestraPositivo";
			 public static string SifilisPruebaTrepoTercerMuestraSinDatos = @"SifilisPruebaTrepoTercerMuestraSinDatos";
			 public static string SifilisPruebaTrepoTercerMuestraNoCorresponde = @"SifilisPruebaTrepoTercerMuestraNoCorresponde";
			 public static string SifilisPruebaTrepoTercerMuestraFecha = @"SifilisPruebaTrepoTercerMuestraFecha";
			 public static string SifilisTratamientoPrimerMuestra = @"SifilisTratamientoPrimerMuestra";
			 public static string SifilisTratamientoPrimerMuestraNo = @"SifilisTratamientoPrimerMuestraNo";
			 public static string SifilisTratamientoPrimerMuestraSi = @"SifilisTratamientoPrimerMuestraSi";
			 public static string SifilisTratamientoPrimerMuestraSinDatos = @"SifilisTratamientoPrimerMuestraSinDatos";
			 public static string SifilisTratamientoPrimerMuestraNoCorresponde = @"SifilisTratamientoPrimerMuestraNoCorresponde";
			 public static string SifilisTratamientoPrimerMuestraFecha = @"SifilisTratamientoPrimerMuestraFecha";
			 public static string SifilisTratamientoSegundaMuestra = @"SifilisTratamientoSegundaMuestra";
			 public static string SifilisTratamientoSegundaMuestraNo = @"SifilisTratamientoSegundaMuestraNo";
			 public static string SifilisTratamientoSegundaMuestraSi = @"SifilisTratamientoSegundaMuestraSi";
			 public static string SifilisTratamientoSegundaMuestraSinDatos = @"SifilisTratamientoSegundaMuestraSinDatos";
			 public static string SifilisTratamientoSegundaMuestraNoCorresponde = @"SifilisTratamientoSegundaMuestraNoCorresponde";
			 public static string SifilisTratamientoSegundaMuestraFecha = @"SifilisTratamientoSegundaMuestraFecha";
			 public static string SifilisTratamientoTercerMuestra = @"SifilisTratamientoTercerMuestra";
			 public static string SifilisTratamientoTercerMuestraNo = @"SifilisTratamientoTercerMuestraNo";
			 public static string SifilisTratamientoTercerMuestraSi = @"SifilisTratamientoTercerMuestraSi";
			 public static string SifilisTratamientoTercerMuestraSinDatos = @"SifilisTratamientoTercerMuestraSinDatos";
			 public static string SifilisTratamientoTercerMuestraNoCorresponde = @"SifilisTratamientoTercerMuestraNoCorresponde";
			 public static string SifilisTratamientoTercerMuestraFecha = @"SifilisTratamientoTercerMuestraFecha";
			 public static string Activa = @"activa";
			 public static string Observaciones = @"observaciones";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IdEfectorTrasladoUt = @"idEfectorTrasladoUt";
			 public static string DiabetesActualSi = @"DiabetesActualSi";
			 public static string DiabetesActualNo = @"DiabetesActualNo";
			 public static string AnemiaSi = @"AnemiaSi";
			 public static string AnemiaNo = @"AnemiaNo";
			 public static string NumeroIdentidad = @"NumeroIdentidad";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprPartoProvisorioRecords != null)
                {
                    foreach (DalSic.AprPartoProvisorio item in colAprPartoProvisorioRecords)
                    {
                        if (item.IdHistoriaClinicaPerinatal != IdHistoriaClinicaPerinatal)
                        {
                            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
                        }
                    }
               }
		
                if (colAprHistoriaClinicaPerinatalDetalleRecords != null)
                {
                    foreach (DalSic.AprHistoriaClinicaPerinatalDetalle item in colAprHistoriaClinicaPerinatalDetalleRecords)
                    {
                        if (item.IdHistoriaClinicaPerinatal != IdHistoriaClinicaPerinatal)
                        {
                            item.IdHistoriaClinicaPerinatal = IdHistoriaClinicaPerinatal;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprPartoProvisorioRecords != null)
                {
                    colAprPartoProvisorioRecords.SaveAll();
               }
		
                if (colAprHistoriaClinicaPerinatalDetalleRecords != null)
                {
                    colAprHistoriaClinicaPerinatalDetalleRecords.SaveAll();
               }
		}
        #endregion
	}
}
