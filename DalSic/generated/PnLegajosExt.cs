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
	/// Strongly-typed collection for the PnLegajosExt class.
	/// </summary>
    [Serializable]
	public partial class PnLegajosExtCollection : ActiveList<PnLegajosExt, PnLegajosExtCollection>
	{	   
		public PnLegajosExtCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLegajosExtCollection</returns>
		public PnLegajosExtCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLegajosExt o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_legajos_ext table.
	/// </summary>
	[Serializable]
	public partial class PnLegajosExt : ActiveRecord<PnLegajosExt>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLegajosExt()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLegajosExt(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLegajosExt(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLegajosExt(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_legajos_ext", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = true;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = true;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarEstadoCivil = new TableSchema.TableColumn(schema);
				colvarEstadoCivil.ColumnName = "estado_civil";
				colvarEstadoCivil.DataType = DbType.Int16;
				colvarEstadoCivil.MaxLength = 0;
				colvarEstadoCivil.AutoIncrement = false;
				colvarEstadoCivil.IsNullable = false;
				colvarEstadoCivil.IsPrimaryKey = false;
				colvarEstadoCivil.IsForeignKey = false;
				colvarEstadoCivil.IsReadOnly = false;
				colvarEstadoCivil.DefaultSetting = @"";
				colvarEstadoCivil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoCivil);
				
				TableSchema.TableColumn colvarFechaEstadoCivil = new TableSchema.TableColumn(schema);
				colvarFechaEstadoCivil.ColumnName = "fecha_estado_civil";
				colvarFechaEstadoCivil.DataType = DbType.DateTime;
				colvarFechaEstadoCivil.MaxLength = 0;
				colvarFechaEstadoCivil.AutoIncrement = false;
				colvarFechaEstadoCivil.IsNullable = false;
				colvarFechaEstadoCivil.IsPrimaryKey = false;
				colvarFechaEstadoCivil.IsForeignKey = false;
				colvarFechaEstadoCivil.IsReadOnly = false;
				colvarFechaEstadoCivil.DefaultSetting = @"";
				colvarFechaEstadoCivil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEstadoCivil);
				
				TableSchema.TableColumn colvarCedulaIdentidad = new TableSchema.TableColumn(schema);
				colvarCedulaIdentidad.ColumnName = "cedula_identidad";
				colvarCedulaIdentidad.DataType = DbType.AnsiString;
				colvarCedulaIdentidad.MaxLength = -1;
				colvarCedulaIdentidad.AutoIncrement = false;
				colvarCedulaIdentidad.IsNullable = true;
				colvarCedulaIdentidad.IsPrimaryKey = false;
				colvarCedulaIdentidad.IsForeignKey = false;
				colvarCedulaIdentidad.IsReadOnly = false;
				colvarCedulaIdentidad.DefaultSetting = @"";
				colvarCedulaIdentidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCedulaIdentidad);
				
				TableSchema.TableColumn colvarNacionalidad = new TableSchema.TableColumn(schema);
				colvarNacionalidad.ColumnName = "nacionalidad";
				colvarNacionalidad.DataType = DbType.AnsiString;
				colvarNacionalidad.MaxLength = -1;
				colvarNacionalidad.AutoIncrement = false;
				colvarNacionalidad.IsNullable = false;
				colvarNacionalidad.IsPrimaryKey = false;
				colvarNacionalidad.IsForeignKey = false;
				colvarNacionalidad.IsReadOnly = false;
				colvarNacionalidad.DefaultSetting = @"";
				colvarNacionalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNacionalidad);
				
				TableSchema.TableColumn colvarTipoNacionalidad = new TableSchema.TableColumn(schema);
				colvarTipoNacionalidad.ColumnName = "tipo_nacionalidad";
				colvarTipoNacionalidad.DataType = DbType.Int16;
				colvarTipoNacionalidad.MaxLength = 0;
				colvarTipoNacionalidad.AutoIncrement = false;
				colvarTipoNacionalidad.IsNullable = false;
				colvarTipoNacionalidad.IsPrimaryKey = false;
				colvarTipoNacionalidad.IsForeignKey = false;
				colvarTipoNacionalidad.IsReadOnly = false;
				colvarTipoNacionalidad.DefaultSetting = @"";
				colvarTipoNacionalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoNacionalidad);
				
				TableSchema.TableColumn colvarBajaMotivo = new TableSchema.TableColumn(schema);
				colvarBajaMotivo.ColumnName = "baja_motivo";
				colvarBajaMotivo.DataType = DbType.AnsiString;
				colvarBajaMotivo.MaxLength = -1;
				colvarBajaMotivo.AutoIncrement = false;
				colvarBajaMotivo.IsNullable = true;
				colvarBajaMotivo.IsPrimaryKey = false;
				colvarBajaMotivo.IsForeignKey = false;
				colvarBajaMotivo.IsReadOnly = false;
				colvarBajaMotivo.DefaultSetting = @"";
				colvarBajaMotivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBajaMotivo);
				
				TableSchema.TableColumn colvarBajaObservaciones = new TableSchema.TableColumn(schema);
				colvarBajaObservaciones.ColumnName = "baja_observaciones";
				colvarBajaObservaciones.DataType = DbType.AnsiString;
				colvarBajaObservaciones.MaxLength = -1;
				colvarBajaObservaciones.AutoIncrement = false;
				colvarBajaObservaciones.IsNullable = true;
				colvarBajaObservaciones.IsPrimaryKey = false;
				colvarBajaObservaciones.IsForeignKey = false;
				colvarBajaObservaciones.IsReadOnly = false;
				colvarBajaObservaciones.DefaultSetting = @"";
				colvarBajaObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBajaObservaciones);
				
				TableSchema.TableColumn colvarInPresentador = new TableSchema.TableColumn(schema);
				colvarInPresentador.ColumnName = "in_presentador";
				colvarInPresentador.DataType = DbType.AnsiString;
				colvarInPresentador.MaxLength = -1;
				colvarInPresentador.AutoIncrement = false;
				colvarInPresentador.IsNullable = true;
				colvarInPresentador.IsPrimaryKey = false;
				colvarInPresentador.IsForeignKey = false;
				colvarInPresentador.IsReadOnly = false;
				colvarInPresentador.DefaultSetting = @"";
				colvarInPresentador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInPresentador);
				
				TableSchema.TableColumn colvarInOcupacion = new TableSchema.TableColumn(schema);
				colvarInOcupacion.ColumnName = "in_ocupacion";
				colvarInOcupacion.DataType = DbType.AnsiString;
				colvarInOcupacion.MaxLength = -1;
				colvarInOcupacion.AutoIncrement = false;
				colvarInOcupacion.IsNullable = true;
				colvarInOcupacion.IsPrimaryKey = false;
				colvarInOcupacion.IsForeignKey = false;
				colvarInOcupacion.IsReadOnly = false;
				colvarInOcupacion.DefaultSetting = @"";
				colvarInOcupacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInOcupacion);
				
				TableSchema.TableColumn colvarInSueldoInicial = new TableSchema.TableColumn(schema);
				colvarInSueldoInicial.ColumnName = "in_sueldo_inicial";
				colvarInSueldoInicial.DataType = DbType.Decimal;
				colvarInSueldoInicial.MaxLength = 0;
				colvarInSueldoInicial.AutoIncrement = false;
				colvarInSueldoInicial.IsNullable = true;
				colvarInSueldoInicial.IsPrimaryKey = false;
				colvarInSueldoInicial.IsForeignKey = false;
				colvarInSueldoInicial.IsReadOnly = false;
				colvarInSueldoInicial.DefaultSetting = @"";
				colvarInSueldoInicial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInSueldoInicial);
				
				TableSchema.TableColumn colvarInExamenMedico = new TableSchema.TableColumn(schema);
				colvarInExamenMedico.ColumnName = "in_examen_medico";
				colvarInExamenMedico.DataType = DbType.AnsiStringFixedLength;
				colvarInExamenMedico.MaxLength = 1;
				colvarInExamenMedico.AutoIncrement = false;
				colvarInExamenMedico.IsNullable = false;
				colvarInExamenMedico.IsPrimaryKey = false;
				colvarInExamenMedico.IsForeignKey = false;
				colvarInExamenMedico.IsReadOnly = false;
				colvarInExamenMedico.DefaultSetting = @"";
				colvarInExamenMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInExamenMedico);
				
				TableSchema.TableColumn colvarInFecha = new TableSchema.TableColumn(schema);
				colvarInFecha.ColumnName = "in_fecha";
				colvarInFecha.DataType = DbType.DateTime;
				colvarInFecha.MaxLength = 0;
				colvarInFecha.AutoIncrement = false;
				colvarInFecha.IsNullable = true;
				colvarInFecha.IsPrimaryKey = false;
				colvarInFecha.IsForeignKey = false;
				colvarInFecha.IsReadOnly = false;
				colvarInFecha.DefaultSetting = @"";
				colvarInFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInFecha);
				
				TableSchema.TableColumn colvarInSector = new TableSchema.TableColumn(schema);
				colvarInSector.ColumnName = "in_sector";
				colvarInSector.DataType = DbType.AnsiString;
				colvarInSector.MaxLength = -1;
				colvarInSector.AutoIncrement = false;
				colvarInSector.IsNullable = true;
				colvarInSector.IsPrimaryKey = false;
				colvarInSector.IsForeignKey = false;
				colvarInSector.IsReadOnly = false;
				colvarInSector.DefaultSetting = @"";
				colvarInSector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInSector);
				
				TableSchema.TableColumn colvarInObservaciones = new TableSchema.TableColumn(schema);
				colvarInObservaciones.ColumnName = "in_observaciones";
				colvarInObservaciones.DataType = DbType.AnsiString;
				colvarInObservaciones.MaxLength = -1;
				colvarInObservaciones.AutoIncrement = false;
				colvarInObservaciones.IsNullable = true;
				colvarInObservaciones.IsPrimaryKey = false;
				colvarInObservaciones.IsForeignKey = false;
				colvarInObservaciones.IsReadOnly = false;
				colvarInObservaciones.DefaultSetting = @"";
				colvarInObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInObservaciones);
				
				TableSchema.TableColumn colvarInCalificacion = new TableSchema.TableColumn(schema);
				colvarInCalificacion.ColumnName = "in_calificacion";
				colvarInCalificacion.DataType = DbType.AnsiString;
				colvarInCalificacion.MaxLength = -1;
				colvarInCalificacion.AutoIncrement = false;
				colvarInCalificacion.IsNullable = true;
				colvarInCalificacion.IsPrimaryKey = false;
				colvarInCalificacion.IsForeignKey = false;
				colvarInCalificacion.IsReadOnly = false;
				colvarInCalificacion.DefaultSetting = @"";
				colvarInCalificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInCalificacion);
				
				TableSchema.TableColumn colvarInSeguroVidaObligatorio = new TableSchema.TableColumn(schema);
				colvarInSeguroVidaObligatorio.ColumnName = "in_seguro_vida_obligatorio";
				colvarInSeguroVidaObligatorio.DataType = DbType.AnsiString;
				colvarInSeguroVidaObligatorio.MaxLength = -1;
				colvarInSeguroVidaObligatorio.AutoIncrement = false;
				colvarInSeguroVidaObligatorio.IsNullable = true;
				colvarInSeguroVidaObligatorio.IsPrimaryKey = false;
				colvarInSeguroVidaObligatorio.IsForeignKey = false;
				colvarInSeguroVidaObligatorio.IsReadOnly = false;
				colvarInSeguroVidaObligatorio.DefaultSetting = @"";
				colvarInSeguroVidaObligatorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInSeguroVidaObligatorio);
				
				TableSchema.TableColumn colvarInSeguroVida = new TableSchema.TableColumn(schema);
				colvarInSeguroVida.ColumnName = "in_seguro_vida";
				colvarInSeguroVida.DataType = DbType.AnsiString;
				colvarInSeguroVida.MaxLength = -1;
				colvarInSeguroVida.AutoIncrement = false;
				colvarInSeguroVida.IsNullable = true;
				colvarInSeguroVida.IsPrimaryKey = false;
				colvarInSeguroVida.IsForeignKey = false;
				colvarInSeguroVida.IsReadOnly = false;
				colvarInSeguroVida.DefaultSetting = @"";
				colvarInSeguroVida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInSeguroVida);
				
				TableSchema.TableColumn colvarInArt = new TableSchema.TableColumn(schema);
				colvarInArt.ColumnName = "in_art";
				colvarInArt.DataType = DbType.AnsiString;
				colvarInArt.MaxLength = -1;
				colvarInArt.AutoIncrement = false;
				colvarInArt.IsNullable = true;
				colvarInArt.IsPrimaryKey = false;
				colvarInArt.IsForeignKey = false;
				colvarInArt.IsReadOnly = false;
				colvarInArt.DefaultSetting = @"";
				colvarInArt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInArt);
				
				TableSchema.TableColumn colvarInBeneficiario = new TableSchema.TableColumn(schema);
				colvarInBeneficiario.ColumnName = "in_beneficiario";
				colvarInBeneficiario.DataType = DbType.AnsiString;
				colvarInBeneficiario.MaxLength = -1;
				colvarInBeneficiario.AutoIncrement = false;
				colvarInBeneficiario.IsNullable = true;
				colvarInBeneficiario.IsPrimaryKey = false;
				colvarInBeneficiario.IsForeignKey = false;
				colvarInBeneficiario.IsReadOnly = false;
				colvarInBeneficiario.DefaultSetting = @"";
				colvarInBeneficiario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInBeneficiario);
				
				TableSchema.TableColumn colvarInCategoria = new TableSchema.TableColumn(schema);
				colvarInCategoria.ColumnName = "in_categoria";
				colvarInCategoria.DataType = DbType.Int16;
				colvarInCategoria.MaxLength = 0;
				colvarInCategoria.AutoIncrement = false;
				colvarInCategoria.IsNullable = false;
				colvarInCategoria.IsPrimaryKey = false;
				colvarInCategoria.IsForeignKey = false;
				colvarInCategoria.IsReadOnly = false;
				colvarInCategoria.DefaultSetting = @"";
				colvarInCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInCategoria);
				
				TableSchema.TableColumn colvarProfesion = new TableSchema.TableColumn(schema);
				colvarProfesion.ColumnName = "profesion";
				colvarProfesion.DataType = DbType.AnsiString;
				colvarProfesion.MaxLength = -1;
				colvarProfesion.AutoIncrement = false;
				colvarProfesion.IsNullable = true;
				colvarProfesion.IsPrimaryKey = false;
				colvarProfesion.IsForeignKey = false;
				colvarProfesion.IsReadOnly = false;
				colvarProfesion.DefaultSetting = @"";
				colvarProfesion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProfesion);
				
				TableSchema.TableColumn colvarEstudios = new TableSchema.TableColumn(schema);
				colvarEstudios.ColumnName = "estudios";
				colvarEstudios.DataType = DbType.AnsiString;
				colvarEstudios.MaxLength = -1;
				colvarEstudios.AutoIncrement = false;
				colvarEstudios.IsNullable = true;
				colvarEstudios.IsPrimaryKey = false;
				colvarEstudios.IsForeignKey = false;
				colvarEstudios.IsReadOnly = false;
				colvarEstudios.DefaultSetting = @"";
				colvarEstudios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudios);
				
				TableSchema.TableColumn colvarCodigoPostal = new TableSchema.TableColumn(schema);
				colvarCodigoPostal.ColumnName = "codigo_postal";
				colvarCodigoPostal.DataType = DbType.Int16;
				colvarCodigoPostal.MaxLength = 0;
				colvarCodigoPostal.AutoIncrement = false;
				colvarCodigoPostal.IsNullable = true;
				colvarCodigoPostal.IsPrimaryKey = false;
				colvarCodigoPostal.IsForeignKey = false;
				colvarCodigoPostal.IsReadOnly = false;
				colvarCodigoPostal.DefaultSetting = @"";
				colvarCodigoPostal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoPostal);
				
				TableSchema.TableColumn colvarOtrosConocimientos = new TableSchema.TableColumn(schema);
				colvarOtrosConocimientos.ColumnName = "otros_conocimientos";
				colvarOtrosConocimientos.DataType = DbType.AnsiString;
				colvarOtrosConocimientos.MaxLength = -1;
				colvarOtrosConocimientos.AutoIncrement = false;
				colvarOtrosConocimientos.IsNullable = true;
				colvarOtrosConocimientos.IsPrimaryKey = false;
				colvarOtrosConocimientos.IsForeignKey = false;
				colvarOtrosConocimientos.IsReadOnly = false;
				colvarOtrosConocimientos.DefaultSetting = @"";
				colvarOtrosConocimientos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrosConocimientos);
				
				TableSchema.TableColumn colvarExhibeTitulos = new TableSchema.TableColumn(schema);
				colvarExhibeTitulos.ColumnName = "exhibe_titulos";
				colvarExhibeTitulos.DataType = DbType.AnsiStringFixedLength;
				colvarExhibeTitulos.MaxLength = 1;
				colvarExhibeTitulos.AutoIncrement = false;
				colvarExhibeTitulos.IsNullable = false;
				colvarExhibeTitulos.IsPrimaryKey = false;
				colvarExhibeTitulos.IsForeignKey = false;
				colvarExhibeTitulos.IsReadOnly = false;
				colvarExhibeTitulos.DefaultSetting = @"";
				colvarExhibeTitulos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExhibeTitulos);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_legajos_ext",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("EstadoCivil")]
		[Bindable(true)]
		public short EstadoCivil 
		{
			get { return GetColumnValue<short>(Columns.EstadoCivil); }
			set { SetColumnValue(Columns.EstadoCivil, value); }
		}
		  
		[XmlAttribute("FechaEstadoCivil")]
		[Bindable(true)]
		public DateTime FechaEstadoCivil 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaEstadoCivil); }
			set { SetColumnValue(Columns.FechaEstadoCivil, value); }
		}
		  
		[XmlAttribute("CedulaIdentidad")]
		[Bindable(true)]
		public string CedulaIdentidad 
		{
			get { return GetColumnValue<string>(Columns.CedulaIdentidad); }
			set { SetColumnValue(Columns.CedulaIdentidad, value); }
		}
		  
		[XmlAttribute("Nacionalidad")]
		[Bindable(true)]
		public string Nacionalidad 
		{
			get { return GetColumnValue<string>(Columns.Nacionalidad); }
			set { SetColumnValue(Columns.Nacionalidad, value); }
		}
		  
		[XmlAttribute("TipoNacionalidad")]
		[Bindable(true)]
		public short TipoNacionalidad 
		{
			get { return GetColumnValue<short>(Columns.TipoNacionalidad); }
			set { SetColumnValue(Columns.TipoNacionalidad, value); }
		}
		  
		[XmlAttribute("BajaMotivo")]
		[Bindable(true)]
		public string BajaMotivo 
		{
			get { return GetColumnValue<string>(Columns.BajaMotivo); }
			set { SetColumnValue(Columns.BajaMotivo, value); }
		}
		  
		[XmlAttribute("BajaObservaciones")]
		[Bindable(true)]
		public string BajaObservaciones 
		{
			get { return GetColumnValue<string>(Columns.BajaObservaciones); }
			set { SetColumnValue(Columns.BajaObservaciones, value); }
		}
		  
		[XmlAttribute("InPresentador")]
		[Bindable(true)]
		public string InPresentador 
		{
			get { return GetColumnValue<string>(Columns.InPresentador); }
			set { SetColumnValue(Columns.InPresentador, value); }
		}
		  
		[XmlAttribute("InOcupacion")]
		[Bindable(true)]
		public string InOcupacion 
		{
			get { return GetColumnValue<string>(Columns.InOcupacion); }
			set { SetColumnValue(Columns.InOcupacion, value); }
		}
		  
		[XmlAttribute("InSueldoInicial")]
		[Bindable(true)]
		public decimal? InSueldoInicial 
		{
			get { return GetColumnValue<decimal?>(Columns.InSueldoInicial); }
			set { SetColumnValue(Columns.InSueldoInicial, value); }
		}
		  
		[XmlAttribute("InExamenMedico")]
		[Bindable(true)]
		public string InExamenMedico 
		{
			get { return GetColumnValue<string>(Columns.InExamenMedico); }
			set { SetColumnValue(Columns.InExamenMedico, value); }
		}
		  
		[XmlAttribute("InFecha")]
		[Bindable(true)]
		public DateTime? InFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.InFecha); }
			set { SetColumnValue(Columns.InFecha, value); }
		}
		  
		[XmlAttribute("InSector")]
		[Bindable(true)]
		public string InSector 
		{
			get { return GetColumnValue<string>(Columns.InSector); }
			set { SetColumnValue(Columns.InSector, value); }
		}
		  
		[XmlAttribute("InObservaciones")]
		[Bindable(true)]
		public string InObservaciones 
		{
			get { return GetColumnValue<string>(Columns.InObservaciones); }
			set { SetColumnValue(Columns.InObservaciones, value); }
		}
		  
		[XmlAttribute("InCalificacion")]
		[Bindable(true)]
		public string InCalificacion 
		{
			get { return GetColumnValue<string>(Columns.InCalificacion); }
			set { SetColumnValue(Columns.InCalificacion, value); }
		}
		  
		[XmlAttribute("InSeguroVidaObligatorio")]
		[Bindable(true)]
		public string InSeguroVidaObligatorio 
		{
			get { return GetColumnValue<string>(Columns.InSeguroVidaObligatorio); }
			set { SetColumnValue(Columns.InSeguroVidaObligatorio, value); }
		}
		  
		[XmlAttribute("InSeguroVida")]
		[Bindable(true)]
		public string InSeguroVida 
		{
			get { return GetColumnValue<string>(Columns.InSeguroVida); }
			set { SetColumnValue(Columns.InSeguroVida, value); }
		}
		  
		[XmlAttribute("InArt")]
		[Bindable(true)]
		public string InArt 
		{
			get { return GetColumnValue<string>(Columns.InArt); }
			set { SetColumnValue(Columns.InArt, value); }
		}
		  
		[XmlAttribute("InBeneficiario")]
		[Bindable(true)]
		public string InBeneficiario 
		{
			get { return GetColumnValue<string>(Columns.InBeneficiario); }
			set { SetColumnValue(Columns.InBeneficiario, value); }
		}
		  
		[XmlAttribute("InCategoria")]
		[Bindable(true)]
		public short InCategoria 
		{
			get { return GetColumnValue<short>(Columns.InCategoria); }
			set { SetColumnValue(Columns.InCategoria, value); }
		}
		  
		[XmlAttribute("Profesion")]
		[Bindable(true)]
		public string Profesion 
		{
			get { return GetColumnValue<string>(Columns.Profesion); }
			set { SetColumnValue(Columns.Profesion, value); }
		}
		  
		[XmlAttribute("Estudios")]
		[Bindable(true)]
		public string Estudios 
		{
			get { return GetColumnValue<string>(Columns.Estudios); }
			set { SetColumnValue(Columns.Estudios, value); }
		}
		  
		[XmlAttribute("CodigoPostal")]
		[Bindable(true)]
		public short? CodigoPostal 
		{
			get { return GetColumnValue<short?>(Columns.CodigoPostal); }
			set { SetColumnValue(Columns.CodigoPostal, value); }
		}
		  
		[XmlAttribute("OtrosConocimientos")]
		[Bindable(true)]
		public string OtrosConocimientos 
		{
			get { return GetColumnValue<string>(Columns.OtrosConocimientos); }
			set { SetColumnValue(Columns.OtrosConocimientos, value); }
		}
		  
		[XmlAttribute("ExhibeTitulos")]
		[Bindable(true)]
		public string ExhibeTitulos 
		{
			get { return GetColumnValue<string>(Columns.ExhibeTitulos); }
			set { SetColumnValue(Columns.ExhibeTitulos, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(short varEstadoCivil,DateTime varFechaEstadoCivil,string varCedulaIdentidad,string varNacionalidad,short varTipoNacionalidad,string varBajaMotivo,string varBajaObservaciones,string varInPresentador,string varInOcupacion,decimal? varInSueldoInicial,string varInExamenMedico,DateTime? varInFecha,string varInSector,string varInObservaciones,string varInCalificacion,string varInSeguroVidaObligatorio,string varInSeguroVida,string varInArt,string varInBeneficiario,short varInCategoria,string varProfesion,string varEstudios,short? varCodigoPostal,string varOtrosConocimientos,string varExhibeTitulos)
		{
			PnLegajosExt item = new PnLegajosExt();
			
			item.EstadoCivil = varEstadoCivil;
			
			item.FechaEstadoCivil = varFechaEstadoCivil;
			
			item.CedulaIdentidad = varCedulaIdentidad;
			
			item.Nacionalidad = varNacionalidad;
			
			item.TipoNacionalidad = varTipoNacionalidad;
			
			item.BajaMotivo = varBajaMotivo;
			
			item.BajaObservaciones = varBajaObservaciones;
			
			item.InPresentador = varInPresentador;
			
			item.InOcupacion = varInOcupacion;
			
			item.InSueldoInicial = varInSueldoInicial;
			
			item.InExamenMedico = varInExamenMedico;
			
			item.InFecha = varInFecha;
			
			item.InSector = varInSector;
			
			item.InObservaciones = varInObservaciones;
			
			item.InCalificacion = varInCalificacion;
			
			item.InSeguroVidaObligatorio = varInSeguroVidaObligatorio;
			
			item.InSeguroVida = varInSeguroVida;
			
			item.InArt = varInArt;
			
			item.InBeneficiario = varInBeneficiario;
			
			item.InCategoria = varInCategoria;
			
			item.Profesion = varProfesion;
			
			item.Estudios = varEstudios;
			
			item.CodigoPostal = varCodigoPostal;
			
			item.OtrosConocimientos = varOtrosConocimientos;
			
			item.ExhibeTitulos = varExhibeTitulos;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLegajo,short varEstadoCivil,DateTime varFechaEstadoCivil,string varCedulaIdentidad,string varNacionalidad,short varTipoNacionalidad,string varBajaMotivo,string varBajaObservaciones,string varInPresentador,string varInOcupacion,decimal? varInSueldoInicial,string varInExamenMedico,DateTime? varInFecha,string varInSector,string varInObservaciones,string varInCalificacion,string varInSeguroVidaObligatorio,string varInSeguroVida,string varInArt,string varInBeneficiario,short varInCategoria,string varProfesion,string varEstudios,short? varCodigoPostal,string varOtrosConocimientos,string varExhibeTitulos)
		{
			PnLegajosExt item = new PnLegajosExt();
			
				item.IdLegajo = varIdLegajo;
			
				item.EstadoCivil = varEstadoCivil;
			
				item.FechaEstadoCivil = varFechaEstadoCivil;
			
				item.CedulaIdentidad = varCedulaIdentidad;
			
				item.Nacionalidad = varNacionalidad;
			
				item.TipoNacionalidad = varTipoNacionalidad;
			
				item.BajaMotivo = varBajaMotivo;
			
				item.BajaObservaciones = varBajaObservaciones;
			
				item.InPresentador = varInPresentador;
			
				item.InOcupacion = varInOcupacion;
			
				item.InSueldoInicial = varInSueldoInicial;
			
				item.InExamenMedico = varInExamenMedico;
			
				item.InFecha = varInFecha;
			
				item.InSector = varInSector;
			
				item.InObservaciones = varInObservaciones;
			
				item.InCalificacion = varInCalificacion;
			
				item.InSeguroVidaObligatorio = varInSeguroVidaObligatorio;
			
				item.InSeguroVida = varInSeguroVida;
			
				item.InArt = varInArt;
			
				item.InBeneficiario = varInBeneficiario;
			
				item.InCategoria = varInCategoria;
			
				item.Profesion = varProfesion;
			
				item.Estudios = varEstudios;
			
				item.CodigoPostal = varCodigoPostal;
			
				item.OtrosConocimientos = varOtrosConocimientos;
			
				item.ExhibeTitulos = varExhibeTitulos;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoCivilColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEstadoCivilColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CedulaIdentidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NacionalidadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoNacionalidadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaMotivoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaObservacionesColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn InPresentadorColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn InOcupacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn InSueldoInicialColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn InExamenMedicoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn InFechaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn InSectorColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn InObservacionesColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn InCalificacionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn InSeguroVidaObligatorioColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn InSeguroVidaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn InArtColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn InBeneficiarioColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn InCategoriaColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ProfesionColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoPostalColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosConocimientosColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn ExhibeTitulosColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLegajo = @"id_legajo";
			 public static string EstadoCivil = @"estado_civil";
			 public static string FechaEstadoCivil = @"fecha_estado_civil";
			 public static string CedulaIdentidad = @"cedula_identidad";
			 public static string Nacionalidad = @"nacionalidad";
			 public static string TipoNacionalidad = @"tipo_nacionalidad";
			 public static string BajaMotivo = @"baja_motivo";
			 public static string BajaObservaciones = @"baja_observaciones";
			 public static string InPresentador = @"in_presentador";
			 public static string InOcupacion = @"in_ocupacion";
			 public static string InSueldoInicial = @"in_sueldo_inicial";
			 public static string InExamenMedico = @"in_examen_medico";
			 public static string InFecha = @"in_fecha";
			 public static string InSector = @"in_sector";
			 public static string InObservaciones = @"in_observaciones";
			 public static string InCalificacion = @"in_calificacion";
			 public static string InSeguroVidaObligatorio = @"in_seguro_vida_obligatorio";
			 public static string InSeguroVida = @"in_seguro_vida";
			 public static string InArt = @"in_art";
			 public static string InBeneficiario = @"in_beneficiario";
			 public static string InCategoria = @"in_categoria";
			 public static string Profesion = @"profesion";
			 public static string Estudios = @"estudios";
			 public static string CodigoPostal = @"codigo_postal";
			 public static string OtrosConocimientos = @"otros_conocimientos";
			 public static string ExhibeTitulos = @"exhibe_titulos";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
