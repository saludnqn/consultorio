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
	/// Strongly-typed collection for the PnPrestacionesNueva class.
	/// </summary>
    [Serializable]
	public partial class PnPrestacionesNuevaCollection : ActiveList<PnPrestacionesNueva, PnPrestacionesNuevaCollection>
	{	   
		public PnPrestacionesNuevaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPrestacionesNuevaCollection</returns>
		public PnPrestacionesNuevaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPrestacionesNueva o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_PrestacionesNuevas table.
	/// </summary>
	[Serializable]
	public partial class PnPrestacionesNueva : ActiveRecord<PnPrestacionesNueva>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPrestacionesNueva()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPrestacionesNueva(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPrestacionesNueva(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPrestacionesNueva(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_PrestacionesNuevas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPrestacionesNuevas = new TableSchema.TableColumn(schema);
				colvarIdPrestacionesNuevas.ColumnName = "idPrestacionesNuevas";
				colvarIdPrestacionesNuevas.DataType = DbType.Int32;
				colvarIdPrestacionesNuevas.MaxLength = 0;
				colvarIdPrestacionesNuevas.AutoIncrement = true;
				colvarIdPrestacionesNuevas.IsNullable = false;
				colvarIdPrestacionesNuevas.IsPrimaryKey = true;
				colvarIdPrestacionesNuevas.IsForeignKey = false;
				colvarIdPrestacionesNuevas.IsReadOnly = false;
				colvarIdPrestacionesNuevas.DefaultSetting = @"";
				colvarIdPrestacionesNuevas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrestacionesNuevas);
				
				TableSchema.TableColumn colvarCodigoPrestacion = new TableSchema.TableColumn(schema);
				colvarCodigoPrestacion.ColumnName = "codigo_prestacion";
				colvarCodigoPrestacion.DataType = DbType.String;
				colvarCodigoPrestacion.MaxLength = 255;
				colvarCodigoPrestacion.AutoIncrement = false;
				colvarCodigoPrestacion.IsNullable = true;
				colvarCodigoPrestacion.IsPrimaryKey = false;
				colvarCodigoPrestacion.IsForeignKey = false;
				colvarCodigoPrestacion.IsReadOnly = false;
				colvarCodigoPrestacion.DefaultSetting = @"";
				colvarCodigoPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoPrestacion);
				
				TableSchema.TableColumn colvarDescripcionPrestacion = new TableSchema.TableColumn(schema);
				colvarDescripcionPrestacion.ColumnName = "descripcion_prestacion";
				colvarDescripcionPrestacion.DataType = DbType.String;
				colvarDescripcionPrestacion.MaxLength = 255;
				colvarDescripcionPrestacion.AutoIncrement = false;
				colvarDescripcionPrestacion.IsNullable = true;
				colvarDescripcionPrestacion.IsPrimaryKey = false;
				colvarDescripcionPrestacion.IsForeignKey = false;
				colvarDescripcionPrestacion.IsReadOnly = false;
				colvarDescripcionPrestacion.DefaultSetting = @"";
				colvarDescripcionPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionPrestacion);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "tipo";
				colvarTipo.DataType = DbType.String;
				colvarTipo.MaxLength = 255;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = true;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarObjeto = new TableSchema.TableColumn(schema);
				colvarObjeto.ColumnName = "objeto";
				colvarObjeto.DataType = DbType.String;
				colvarObjeto.MaxLength = 255;
				colvarObjeto.AutoIncrement = false;
				colvarObjeto.IsNullable = true;
				colvarObjeto.IsPrimaryKey = false;
				colvarObjeto.IsForeignKey = false;
				colvarObjeto.IsReadOnly = false;
				colvarObjeto.DefaultSetting = @"";
				colvarObjeto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObjeto);
				
				TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
				colvarDiagnostico.ColumnName = "diagnostico";
				colvarDiagnostico.DataType = DbType.String;
				colvarDiagnostico.MaxLength = 255;
				colvarDiagnostico.AutoIncrement = false;
				colvarDiagnostico.IsNullable = true;
				colvarDiagnostico.IsPrimaryKey = false;
				colvarDiagnostico.IsForeignKey = false;
				colvarDiagnostico.IsReadOnly = false;
				colvarDiagnostico.DefaultSetting = @"";
				colvarDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnostico);
				
				TableSchema.TableColumn colvarMatrizExtendida = new TableSchema.TableColumn(schema);
				colvarMatrizExtendida.ColumnName = "matriz_extendida";
				colvarMatrizExtendida.DataType = DbType.String;
				colvarMatrizExtendida.MaxLength = 255;
				colvarMatrizExtendida.AutoIncrement = false;
				colvarMatrizExtendida.IsNullable = true;
				colvarMatrizExtendida.IsPrimaryKey = false;
				colvarMatrizExtendida.IsForeignKey = false;
				colvarMatrizExtendida.IsReadOnly = false;
				colvarMatrizExtendida.DefaultSetting = @"";
				colvarMatrizExtendida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMatrizExtendida);
				
				TableSchema.TableColumn colvarLineaCuidado = new TableSchema.TableColumn(schema);
				colvarLineaCuidado.ColumnName = "linea_cuidado";
				colvarLineaCuidado.DataType = DbType.String;
				colvarLineaCuidado.MaxLength = 255;
				colvarLineaCuidado.AutoIncrement = false;
				colvarLineaCuidado.IsNullable = true;
				colvarLineaCuidado.IsPrimaryKey = false;
				colvarLineaCuidado.IsForeignKey = false;
				colvarLineaCuidado.IsReadOnly = false;
				colvarLineaCuidado.DefaultSetting = @"";
				colvarLineaCuidado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLineaCuidado);
				
				TableSchema.TableColumn colvarGrupoEtario = new TableSchema.TableColumn(schema);
				colvarGrupoEtario.ColumnName = "grupo_etario";
				colvarGrupoEtario.DataType = DbType.String;
				colvarGrupoEtario.MaxLength = 255;
				colvarGrupoEtario.AutoIncrement = false;
				colvarGrupoEtario.IsNullable = true;
				colvarGrupoEtario.IsPrimaryKey = false;
				colvarGrupoEtario.IsForeignKey = false;
				colvarGrupoEtario.IsReadOnly = false;
				colvarGrupoEtario.DefaultSetting = @"";
				colvarGrupoEtario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupoEtario);
				
				TableSchema.TableColumn colvarDescripcionGrupoEtario = new TableSchema.TableColumn(schema);
				colvarDescripcionGrupoEtario.ColumnName = "descripcion_grupo_etario";
				colvarDescripcionGrupoEtario.DataType = DbType.String;
				colvarDescripcionGrupoEtario.MaxLength = 255;
				colvarDescripcionGrupoEtario.AutoIncrement = false;
				colvarDescripcionGrupoEtario.IsNullable = true;
				colvarDescripcionGrupoEtario.IsPrimaryKey = false;
				colvarDescripcionGrupoEtario.IsForeignKey = false;
				colvarDescripcionGrupoEtario.IsReadOnly = false;
				colvarDescripcionGrupoEtario.DefaultSetting = @"";
				colvarDescripcionGrupoEtario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionGrupoEtario);
				
				TableSchema.TableColumn colvarCatastrofico = new TableSchema.TableColumn(schema);
				colvarCatastrofico.ColumnName = "catastrofico";
				colvarCatastrofico.DataType = DbType.String;
				colvarCatastrofico.MaxLength = 255;
				colvarCatastrofico.AutoIncrement = false;
				colvarCatastrofico.IsNullable = true;
				colvarCatastrofico.IsPrimaryKey = false;
				colvarCatastrofico.IsForeignKey = false;
				colvarCatastrofico.IsReadOnly = false;
				colvarCatastrofico.DefaultSetting = @"";
				colvarCatastrofico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCatastrofico);
				
				TableSchema.TableColumn colvarCcc = new TableSchema.TableColumn(schema);
				colvarCcc.ColumnName = "ccc";
				colvarCcc.DataType = DbType.String;
				colvarCcc.MaxLength = 255;
				colvarCcc.AutoIncrement = false;
				colvarCcc.IsNullable = true;
				colvarCcc.IsPrimaryKey = false;
				colvarCcc.IsForeignKey = false;
				colvarCcc.IsReadOnly = false;
				colvarCcc.DefaultSetting = @"";
				colvarCcc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCcc);
				
				TableSchema.TableColumn colvarPatologia = new TableSchema.TableColumn(schema);
				colvarPatologia.ColumnName = "patologia";
				colvarPatologia.DataType = DbType.String;
				colvarPatologia.MaxLength = 255;
				colvarPatologia.AutoIncrement = false;
				colvarPatologia.IsNullable = true;
				colvarPatologia.IsPrimaryKey = false;
				colvarPatologia.IsForeignKey = false;
				colvarPatologia.IsReadOnly = false;
				colvarPatologia.DefaultSetting = @"";
				colvarPatologia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPatologia);
				
				TableSchema.TableColumn colvarModulos = new TableSchema.TableColumn(schema);
				colvarModulos.ColumnName = "modulo(s)";
				colvarModulos.DataType = DbType.String;
				colvarModulos.MaxLength = 255;
				colvarModulos.AutoIncrement = false;
				colvarModulos.IsNullable = true;
				colvarModulos.IsPrimaryKey = false;
				colvarModulos.IsForeignKey = false;
				colvarModulos.IsReadOnly = false;
				colvarModulos.DefaultSetting = @"";
				colvarModulos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModulos);
				
				TableSchema.TableColumn colvarEstrategicos = new TableSchema.TableColumn(schema);
				colvarEstrategicos.ColumnName = "estrategicos";
				colvarEstrategicos.DataType = DbType.String;
				colvarEstrategicos.MaxLength = 255;
				colvarEstrategicos.AutoIncrement = false;
				colvarEstrategicos.IsNullable = true;
				colvarEstrategicos.IsPrimaryKey = false;
				colvarEstrategicos.IsForeignKey = false;
				colvarEstrategicos.IsReadOnly = false;
				colvarEstrategicos.DefaultSetting = @"";
				colvarEstrategicos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstrategicos);
				
				TableSchema.TableColumn colvarMujeresEmbarazadas = new TableSchema.TableColumn(schema);
				colvarMujeresEmbarazadas.ColumnName = "mujeres_embarazadas";
				colvarMujeresEmbarazadas.DataType = DbType.String;
				colvarMujeresEmbarazadas.MaxLength = 255;
				colvarMujeresEmbarazadas.AutoIncrement = false;
				colvarMujeresEmbarazadas.IsNullable = true;
				colvarMujeresEmbarazadas.IsPrimaryKey = false;
				colvarMujeresEmbarazadas.IsForeignKey = false;
				colvarMujeresEmbarazadas.IsReadOnly = false;
				colvarMujeresEmbarazadas.DefaultSetting = @"";
				colvarMujeresEmbarazadas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMujeresEmbarazadas);
				
				TableSchema.TableColumn colvarEmbarazoRiesgo = new TableSchema.TableColumn(schema);
				colvarEmbarazoRiesgo.ColumnName = "embarazo_riesgo";
				colvarEmbarazoRiesgo.DataType = DbType.String;
				colvarEmbarazoRiesgo.MaxLength = 255;
				colvarEmbarazoRiesgo.AutoIncrement = false;
				colvarEmbarazoRiesgo.IsNullable = true;
				colvarEmbarazoRiesgo.IsPrimaryKey = false;
				colvarEmbarazoRiesgo.IsForeignKey = false;
				colvarEmbarazoRiesgo.IsReadOnly = false;
				colvarEmbarazoRiesgo.DefaultSetting = @"";
				colvarEmbarazoRiesgo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoRiesgo);
				
				TableSchema.TableColumn colvarEmbarazoNormal = new TableSchema.TableColumn(schema);
				colvarEmbarazoNormal.ColumnName = "embarazo_normal";
				colvarEmbarazoNormal.DataType = DbType.String;
				colvarEmbarazoNormal.MaxLength = 255;
				colvarEmbarazoNormal.AutoIncrement = false;
				colvarEmbarazoNormal.IsNullable = true;
				colvarEmbarazoNormal.IsPrimaryKey = false;
				colvarEmbarazoNormal.IsForeignKey = false;
				colvarEmbarazoNormal.IsReadOnly = false;
				colvarEmbarazoNormal.DefaultSetting = @"";
				colvarEmbarazoNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoNormal);
				
				TableSchema.TableColumn colvarOdps = new TableSchema.TableColumn(schema);
				colvarOdps.ColumnName = "odp(s)";
				colvarOdps.DataType = DbType.String;
				colvarOdps.MaxLength = 255;
				colvarOdps.AutoIncrement = false;
				colvarOdps.IsNullable = true;
				colvarOdps.IsPrimaryKey = false;
				colvarOdps.IsForeignKey = false;
				colvarOdps.IsReadOnly = false;
				colvarOdps.DefaultSetting = @"";
				colvarOdps.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOdps);
				
				TableSchema.TableColumn colvarPpac = new TableSchema.TableColumn(schema);
				colvarPpac.ColumnName = "ppac";
				colvarPpac.DataType = DbType.String;
				colvarPpac.MaxLength = 255;
				colvarPpac.AutoIncrement = false;
				colvarPpac.IsNullable = true;
				colvarPpac.IsPrimaryKey = false;
				colvarPpac.IsForeignKey = false;
				colvarPpac.IsReadOnly = false;
				colvarPpac.DefaultSetting = @"";
				colvarPpac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPpac);
				
				TableSchema.TableColumn colvarSara = new TableSchema.TableColumn(schema);
				colvarSara.ColumnName = "sara";
				colvarSara.DataType = DbType.String;
				colvarSara.MaxLength = 255;
				colvarSara.AutoIncrement = false;
				colvarSara.IsNullable = true;
				colvarSara.IsPrimaryKey = false;
				colvarSara.IsForeignKey = false;
				colvarSara.IsReadOnly = false;
				colvarSara.DefaultSetting = @"";
				colvarSara.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSara);
				
				TableSchema.TableColumn colvarAmbulatorio = new TableSchema.TableColumn(schema);
				colvarAmbulatorio.ColumnName = "ambulatorio";
				colvarAmbulatorio.DataType = DbType.String;
				colvarAmbulatorio.MaxLength = 255;
				colvarAmbulatorio.AutoIncrement = false;
				colvarAmbulatorio.IsNullable = true;
				colvarAmbulatorio.IsPrimaryKey = false;
				colvarAmbulatorio.IsForeignKey = false;
				colvarAmbulatorio.IsReadOnly = false;
				colvarAmbulatorio.DefaultSetting = @"";
				colvarAmbulatorio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmbulatorio);
				
				TableSchema.TableColumn colvarInternacion = new TableSchema.TableColumn(schema);
				colvarInternacion.ColumnName = "internacion";
				colvarInternacion.DataType = DbType.String;
				colvarInternacion.MaxLength = 255;
				colvarInternacion.AutoIncrement = false;
				colvarInternacion.IsNullable = true;
				colvarInternacion.IsPrimaryKey = false;
				colvarInternacion.IsForeignKey = false;
				colvarInternacion.IsReadOnly = false;
				colvarInternacion.DefaultSetting = @"";
				colvarInternacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInternacion);
				
				TableSchema.TableColumn colvarHospitalDia = new TableSchema.TableColumn(schema);
				colvarHospitalDia.ColumnName = "hospital_dia";
				colvarHospitalDia.DataType = DbType.String;
				colvarHospitalDia.MaxLength = 255;
				colvarHospitalDia.AutoIncrement = false;
				colvarHospitalDia.IsNullable = true;
				colvarHospitalDia.IsPrimaryKey = false;
				colvarHospitalDia.IsForeignKey = false;
				colvarHospitalDia.IsReadOnly = false;
				colvarHospitalDia.DefaultSetting = @"";
				colvarHospitalDia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHospitalDia);
				
				TableSchema.TableColumn colvarTraslado = new TableSchema.TableColumn(schema);
				colvarTraslado.ColumnName = "traslado";
				colvarTraslado.DataType = DbType.String;
				colvarTraslado.MaxLength = 255;
				colvarTraslado.AutoIncrement = false;
				colvarTraslado.IsNullable = true;
				colvarTraslado.IsPrimaryKey = false;
				colvarTraslado.IsForeignKey = false;
				colvarTraslado.IsReadOnly = false;
				colvarTraslado.DefaultSetting = @"";
				colvarTraslado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTraslado);
				
				TableSchema.TableColumn colvarPatologiaQuirurgica = new TableSchema.TableColumn(schema);
				colvarPatologiaQuirurgica.ColumnName = "patologia_quirurgica";
				colvarPatologiaQuirurgica.DataType = DbType.String;
				colvarPatologiaQuirurgica.MaxLength = 255;
				colvarPatologiaQuirurgica.AutoIncrement = false;
				colvarPatologiaQuirurgica.IsNullable = true;
				colvarPatologiaQuirurgica.IsPrimaryKey = false;
				colvarPatologiaQuirurgica.IsForeignKey = false;
				colvarPatologiaQuirurgica.IsReadOnly = false;
				colvarPatologiaQuirurgica.DefaultSetting = @"";
				colvarPatologiaQuirurgica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPatologiaQuirurgica);
				
				TableSchema.TableColumn colvarPatologiaPrematurez = new TableSchema.TableColumn(schema);
				colvarPatologiaPrematurez.ColumnName = "patologia_prematurez";
				colvarPatologiaPrematurez.DataType = DbType.String;
				colvarPatologiaPrematurez.MaxLength = 255;
				colvarPatologiaPrematurez.AutoIncrement = false;
				colvarPatologiaPrematurez.IsNullable = true;
				colvarPatologiaPrematurez.IsPrimaryKey = false;
				colvarPatologiaPrematurez.IsForeignKey = false;
				colvarPatologiaPrematurez.IsReadOnly = false;
				colvarPatologiaPrematurez.DefaultSetting = @"";
				colvarPatologiaPrematurez.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPatologiaPrematurez);
				
				TableSchema.TableColumn colvarIi = new TableSchema.TableColumn(schema);
				colvarIi.ColumnName = "ii";
				colvarIi.DataType = DbType.String;
				colvarIi.MaxLength = 255;
				colvarIi.AutoIncrement = false;
				colvarIi.IsNullable = true;
				colvarIi.IsPrimaryKey = false;
				colvarIi.IsForeignKey = false;
				colvarIi.IsReadOnly = false;
				colvarIi.DefaultSetting = @"";
				colvarIi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIi);
				
				TableSchema.TableColumn colvarIiia = new TableSchema.TableColumn(schema);
				colvarIiia.ColumnName = "iiia";
				colvarIiia.DataType = DbType.String;
				colvarIiia.MaxLength = 255;
				colvarIiia.AutoIncrement = false;
				colvarIiia.IsNullable = true;
				colvarIiia.IsPrimaryKey = false;
				colvarIiia.IsForeignKey = false;
				colvarIiia.IsReadOnly = false;
				colvarIiia.DefaultSetting = @"";
				colvarIiia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIiia);
				
				TableSchema.TableColumn colvarIiib = new TableSchema.TableColumn(schema);
				colvarIiib.ColumnName = "iiib";
				colvarIiib.DataType = DbType.String;
				colvarIiib.MaxLength = 255;
				colvarIiib.AutoIncrement = false;
				colvarIiib.IsNullable = true;
				colvarIiib.IsPrimaryKey = false;
				colvarIiib.IsForeignKey = false;
				colvarIiib.IsReadOnly = false;
				colvarIiib.DefaultSetting = @"";
				colvarIiib.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIiib);
				
				TableSchema.TableColumn colvarPriorizadas = new TableSchema.TableColumn(schema);
				colvarPriorizadas.ColumnName = "priorizadas";
				colvarPriorizadas.DataType = DbType.String;
				colvarPriorizadas.MaxLength = 255;
				colvarPriorizadas.AutoIncrement = false;
				colvarPriorizadas.IsNullable = true;
				colvarPriorizadas.IsPrimaryKey = false;
				colvarPriorizadas.IsForeignKey = false;
				colvarPriorizadas.IsReadOnly = false;
				colvarPriorizadas.DefaultSetting = @"";
				colvarPriorizadas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPriorizadas);
				
				TableSchema.TableColumn colvarTrazadoras = new TableSchema.TableColumn(schema);
				colvarTrazadoras.ColumnName = "trazadora(s)";
				colvarTrazadoras.DataType = DbType.Double;
				colvarTrazadoras.MaxLength = 0;
				colvarTrazadoras.AutoIncrement = false;
				colvarTrazadoras.IsNullable = true;
				colvarTrazadoras.IsPrimaryKey = false;
				colvarTrazadoras.IsForeignKey = false;
				colvarTrazadoras.IsReadOnly = false;
				colvarTrazadoras.DefaultSetting = @"";
				colvarTrazadoras.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrazadoras);
				
				TableSchema.TableColumn colvarGruposCeb = new TableSchema.TableColumn(schema);
				colvarGruposCeb.ColumnName = "grupo(s) ceb";
				colvarGruposCeb.DataType = DbType.String;
				colvarGruposCeb.MaxLength = 255;
				colvarGruposCeb.AutoIncrement = false;
				colvarGruposCeb.IsNullable = true;
				colvarGruposCeb.IsPrimaryKey = false;
				colvarGruposCeb.IsForeignKey = false;
				colvarGruposCeb.IsReadOnly = false;
				colvarGruposCeb.DefaultSetting = @"";
				colvarGruposCeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGruposCeb);
				
				TableSchema.TableColumn colvarDescripcionGruposCeb = new TableSchema.TableColumn(schema);
				colvarDescripcionGruposCeb.ColumnName = "descripcion_grupos_ceb";
				colvarDescripcionGruposCeb.DataType = DbType.String;
				colvarDescripcionGruposCeb.MaxLength = 255;
				colvarDescripcionGruposCeb.AutoIncrement = false;
				colvarDescripcionGruposCeb.IsNullable = true;
				colvarDescripcionGruposCeb.IsPrimaryKey = false;
				colvarDescripcionGruposCeb.IsForeignKey = false;
				colvarDescripcionGruposCeb.IsReadOnly = false;
				colvarDescripcionGruposCeb.DefaultSetting = @"";
				colvarDescripcionGruposCeb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionGruposCeb);
				
				TableSchema.TableColumn colvarCodigosNacer = new TableSchema.TableColumn(schema);
				colvarCodigosNacer.ColumnName = "codigos_nacer";
				colvarCodigosNacer.DataType = DbType.String;
				colvarCodigosNacer.MaxLength = 255;
				colvarCodigosNacer.AutoIncrement = false;
				colvarCodigosNacer.IsNullable = true;
				colvarCodigosNacer.IsPrimaryKey = false;
				colvarCodigosNacer.IsForeignKey = false;
				colvarCodigosNacer.IsReadOnly = false;
				colvarCodigosNacer.DefaultSetting = @"";
				colvarCodigosNacer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigosNacer);
				
				TableSchema.TableColumn colvarCodigosRural = new TableSchema.TableColumn(schema);
				colvarCodigosRural.ColumnName = "codigos_rural";
				colvarCodigosRural.DataType = DbType.String;
				colvarCodigosRural.MaxLength = 255;
				colvarCodigosRural.AutoIncrement = false;
				colvarCodigosRural.IsNullable = true;
				colvarCodigosRural.IsPrimaryKey = false;
				colvarCodigosRural.IsForeignKey = false;
				colvarCodigosRural.IsReadOnly = false;
				colvarCodigosRural.DefaultSetting = @"";
				colvarCodigosRural.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigosRural);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_PrestacionesNuevas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPrestacionesNuevas")]
		[Bindable(true)]
		public int IdPrestacionesNuevas 
		{
			get { return GetColumnValue<int>(Columns.IdPrestacionesNuevas); }
			set { SetColumnValue(Columns.IdPrestacionesNuevas, value); }
		}
		  
		[XmlAttribute("CodigoPrestacion")]
		[Bindable(true)]
		public string CodigoPrestacion 
		{
			get { return GetColumnValue<string>(Columns.CodigoPrestacion); }
			set { SetColumnValue(Columns.CodigoPrestacion, value); }
		}
		  
		[XmlAttribute("DescripcionPrestacion")]
		[Bindable(true)]
		public string DescripcionPrestacion 
		{
			get { return GetColumnValue<string>(Columns.DescripcionPrestacion); }
			set { SetColumnValue(Columns.DescripcionPrestacion, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public string Tipo 
		{
			get { return GetColumnValue<string>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Objeto")]
		[Bindable(true)]
		public string Objeto 
		{
			get { return GetColumnValue<string>(Columns.Objeto); }
			set { SetColumnValue(Columns.Objeto, value); }
		}
		  
		[XmlAttribute("Diagnostico")]
		[Bindable(true)]
		public string Diagnostico 
		{
			get { return GetColumnValue<string>(Columns.Diagnostico); }
			set { SetColumnValue(Columns.Diagnostico, value); }
		}
		  
		[XmlAttribute("MatrizExtendida")]
		[Bindable(true)]
		public string MatrizExtendida 
		{
			get { return GetColumnValue<string>(Columns.MatrizExtendida); }
			set { SetColumnValue(Columns.MatrizExtendida, value); }
		}
		  
		[XmlAttribute("LineaCuidado")]
		[Bindable(true)]
		public string LineaCuidado 
		{
			get { return GetColumnValue<string>(Columns.LineaCuidado); }
			set { SetColumnValue(Columns.LineaCuidado, value); }
		}
		  
		[XmlAttribute("GrupoEtario")]
		[Bindable(true)]
		public string GrupoEtario 
		{
			get { return GetColumnValue<string>(Columns.GrupoEtario); }
			set { SetColumnValue(Columns.GrupoEtario, value); }
		}
		  
		[XmlAttribute("DescripcionGrupoEtario")]
		[Bindable(true)]
		public string DescripcionGrupoEtario 
		{
			get { return GetColumnValue<string>(Columns.DescripcionGrupoEtario); }
			set { SetColumnValue(Columns.DescripcionGrupoEtario, value); }
		}
		  
		[XmlAttribute("Catastrofico")]
		[Bindable(true)]
		public string Catastrofico 
		{
			get { return GetColumnValue<string>(Columns.Catastrofico); }
			set { SetColumnValue(Columns.Catastrofico, value); }
		}
		  
		[XmlAttribute("Ccc")]
		[Bindable(true)]
		public string Ccc 
		{
			get { return GetColumnValue<string>(Columns.Ccc); }
			set { SetColumnValue(Columns.Ccc, value); }
		}
		  
		[XmlAttribute("Patologia")]
		[Bindable(true)]
		public string Patologia 
		{
			get { return GetColumnValue<string>(Columns.Patologia); }
			set { SetColumnValue(Columns.Patologia, value); }
		}
		  
		[XmlAttribute("Modulos")]
		[Bindable(true)]
		public string Modulos 
		{
			get { return GetColumnValue<string>(Columns.Modulos); }
			set { SetColumnValue(Columns.Modulos, value); }
		}
		  
		[XmlAttribute("Estrategicos")]
		[Bindable(true)]
		public string Estrategicos 
		{
			get { return GetColumnValue<string>(Columns.Estrategicos); }
			set { SetColumnValue(Columns.Estrategicos, value); }
		}
		  
		[XmlAttribute("MujeresEmbarazadas")]
		[Bindable(true)]
		public string MujeresEmbarazadas 
		{
			get { return GetColumnValue<string>(Columns.MujeresEmbarazadas); }
			set { SetColumnValue(Columns.MujeresEmbarazadas, value); }
		}
		  
		[XmlAttribute("EmbarazoRiesgo")]
		[Bindable(true)]
		public string EmbarazoRiesgo 
		{
			get { return GetColumnValue<string>(Columns.EmbarazoRiesgo); }
			set { SetColumnValue(Columns.EmbarazoRiesgo, value); }
		}
		  
		[XmlAttribute("EmbarazoNormal")]
		[Bindable(true)]
		public string EmbarazoNormal 
		{
			get { return GetColumnValue<string>(Columns.EmbarazoNormal); }
			set { SetColumnValue(Columns.EmbarazoNormal, value); }
		}
		  
		[XmlAttribute("Odps")]
		[Bindable(true)]
		public string Odps 
		{
			get { return GetColumnValue<string>(Columns.Odps); }
			set { SetColumnValue(Columns.Odps, value); }
		}
		  
		[XmlAttribute("Ppac")]
		[Bindable(true)]
		public string Ppac 
		{
			get { return GetColumnValue<string>(Columns.Ppac); }
			set { SetColumnValue(Columns.Ppac, value); }
		}
		  
		[XmlAttribute("Sara")]
		[Bindable(true)]
		public string Sara 
		{
			get { return GetColumnValue<string>(Columns.Sara); }
			set { SetColumnValue(Columns.Sara, value); }
		}
		  
		[XmlAttribute("Ambulatorio")]
		[Bindable(true)]
		public string Ambulatorio 
		{
			get { return GetColumnValue<string>(Columns.Ambulatorio); }
			set { SetColumnValue(Columns.Ambulatorio, value); }
		}
		  
		[XmlAttribute("Internacion")]
		[Bindable(true)]
		public string Internacion 
		{
			get { return GetColumnValue<string>(Columns.Internacion); }
			set { SetColumnValue(Columns.Internacion, value); }
		}
		  
		[XmlAttribute("HospitalDia")]
		[Bindable(true)]
		public string HospitalDia 
		{
			get { return GetColumnValue<string>(Columns.HospitalDia); }
			set { SetColumnValue(Columns.HospitalDia, value); }
		}
		  
		[XmlAttribute("Traslado")]
		[Bindable(true)]
		public string Traslado 
		{
			get { return GetColumnValue<string>(Columns.Traslado); }
			set { SetColumnValue(Columns.Traslado, value); }
		}
		  
		[XmlAttribute("PatologiaQuirurgica")]
		[Bindable(true)]
		public string PatologiaQuirurgica 
		{
			get { return GetColumnValue<string>(Columns.PatologiaQuirurgica); }
			set { SetColumnValue(Columns.PatologiaQuirurgica, value); }
		}
		  
		[XmlAttribute("PatologiaPrematurez")]
		[Bindable(true)]
		public string PatologiaPrematurez 
		{
			get { return GetColumnValue<string>(Columns.PatologiaPrematurez); }
			set { SetColumnValue(Columns.PatologiaPrematurez, value); }
		}
		  
		[XmlAttribute("Ii")]
		[Bindable(true)]
		public string Ii 
		{
			get { return GetColumnValue<string>(Columns.Ii); }
			set { SetColumnValue(Columns.Ii, value); }
		}
		  
		[XmlAttribute("Iiia")]
		[Bindable(true)]
		public string Iiia 
		{
			get { return GetColumnValue<string>(Columns.Iiia); }
			set { SetColumnValue(Columns.Iiia, value); }
		}
		  
		[XmlAttribute("Iiib")]
		[Bindable(true)]
		public string Iiib 
		{
			get { return GetColumnValue<string>(Columns.Iiib); }
			set { SetColumnValue(Columns.Iiib, value); }
		}
		  
		[XmlAttribute("Priorizadas")]
		[Bindable(true)]
		public string Priorizadas 
		{
			get { return GetColumnValue<string>(Columns.Priorizadas); }
			set { SetColumnValue(Columns.Priorizadas, value); }
		}
		  
		[XmlAttribute("Trazadoras")]
		[Bindable(true)]
		public double? Trazadoras 
		{
			get { return GetColumnValue<double?>(Columns.Trazadoras); }
			set { SetColumnValue(Columns.Trazadoras, value); }
		}
		  
		[XmlAttribute("GruposCeb")]
		[Bindable(true)]
		public string GruposCeb 
		{
			get { return GetColumnValue<string>(Columns.GruposCeb); }
			set { SetColumnValue(Columns.GruposCeb, value); }
		}
		  
		[XmlAttribute("DescripcionGruposCeb")]
		[Bindable(true)]
		public string DescripcionGruposCeb 
		{
			get { return GetColumnValue<string>(Columns.DescripcionGruposCeb); }
			set { SetColumnValue(Columns.DescripcionGruposCeb, value); }
		}
		  
		[XmlAttribute("CodigosNacer")]
		[Bindable(true)]
		public string CodigosNacer 
		{
			get { return GetColumnValue<string>(Columns.CodigosNacer); }
			set { SetColumnValue(Columns.CodigosNacer, value); }
		}
		  
		[XmlAttribute("CodigosRural")]
		[Bindable(true)]
		public string CodigosRural 
		{
			get { return GetColumnValue<string>(Columns.CodigosRural); }
			set { SetColumnValue(Columns.CodigosRural, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodigoPrestacion,string varDescripcionPrestacion,string varTipo,string varObjeto,string varDiagnostico,string varMatrizExtendida,string varLineaCuidado,string varGrupoEtario,string varDescripcionGrupoEtario,string varCatastrofico,string varCcc,string varPatologia,string varModulos,string varEstrategicos,string varMujeresEmbarazadas,string varEmbarazoRiesgo,string varEmbarazoNormal,string varOdps,string varPpac,string varSara,string varAmbulatorio,string varInternacion,string varHospitalDia,string varTraslado,string varPatologiaQuirurgica,string varPatologiaPrematurez,string varIi,string varIiia,string varIiib,string varPriorizadas,double? varTrazadoras,string varGruposCeb,string varDescripcionGruposCeb,string varCodigosNacer,string varCodigosRural)
		{
			PnPrestacionesNueva item = new PnPrestacionesNueva();
			
			item.CodigoPrestacion = varCodigoPrestacion;
			
			item.DescripcionPrestacion = varDescripcionPrestacion;
			
			item.Tipo = varTipo;
			
			item.Objeto = varObjeto;
			
			item.Diagnostico = varDiagnostico;
			
			item.MatrizExtendida = varMatrizExtendida;
			
			item.LineaCuidado = varLineaCuidado;
			
			item.GrupoEtario = varGrupoEtario;
			
			item.DescripcionGrupoEtario = varDescripcionGrupoEtario;
			
			item.Catastrofico = varCatastrofico;
			
			item.Ccc = varCcc;
			
			item.Patologia = varPatologia;
			
			item.Modulos = varModulos;
			
			item.Estrategicos = varEstrategicos;
			
			item.MujeresEmbarazadas = varMujeresEmbarazadas;
			
			item.EmbarazoRiesgo = varEmbarazoRiesgo;
			
			item.EmbarazoNormal = varEmbarazoNormal;
			
			item.Odps = varOdps;
			
			item.Ppac = varPpac;
			
			item.Sara = varSara;
			
			item.Ambulatorio = varAmbulatorio;
			
			item.Internacion = varInternacion;
			
			item.HospitalDia = varHospitalDia;
			
			item.Traslado = varTraslado;
			
			item.PatologiaQuirurgica = varPatologiaQuirurgica;
			
			item.PatologiaPrematurez = varPatologiaPrematurez;
			
			item.Ii = varIi;
			
			item.Iiia = varIiia;
			
			item.Iiib = varIiib;
			
			item.Priorizadas = varPriorizadas;
			
			item.Trazadoras = varTrazadoras;
			
			item.GruposCeb = varGruposCeb;
			
			item.DescripcionGruposCeb = varDescripcionGruposCeb;
			
			item.CodigosNacer = varCodigosNacer;
			
			item.CodigosRural = varCodigosRural;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPrestacionesNuevas,string varCodigoPrestacion,string varDescripcionPrestacion,string varTipo,string varObjeto,string varDiagnostico,string varMatrizExtendida,string varLineaCuidado,string varGrupoEtario,string varDescripcionGrupoEtario,string varCatastrofico,string varCcc,string varPatologia,string varModulos,string varEstrategicos,string varMujeresEmbarazadas,string varEmbarazoRiesgo,string varEmbarazoNormal,string varOdps,string varPpac,string varSara,string varAmbulatorio,string varInternacion,string varHospitalDia,string varTraslado,string varPatologiaQuirurgica,string varPatologiaPrematurez,string varIi,string varIiia,string varIiib,string varPriorizadas,double? varTrazadoras,string varGruposCeb,string varDescripcionGruposCeb,string varCodigosNacer,string varCodigosRural)
		{
			PnPrestacionesNueva item = new PnPrestacionesNueva();
			
				item.IdPrestacionesNuevas = varIdPrestacionesNuevas;
			
				item.CodigoPrestacion = varCodigoPrestacion;
			
				item.DescripcionPrestacion = varDescripcionPrestacion;
			
				item.Tipo = varTipo;
			
				item.Objeto = varObjeto;
			
				item.Diagnostico = varDiagnostico;
			
				item.MatrizExtendida = varMatrizExtendida;
			
				item.LineaCuidado = varLineaCuidado;
			
				item.GrupoEtario = varGrupoEtario;
			
				item.DescripcionGrupoEtario = varDescripcionGrupoEtario;
			
				item.Catastrofico = varCatastrofico;
			
				item.Ccc = varCcc;
			
				item.Patologia = varPatologia;
			
				item.Modulos = varModulos;
			
				item.Estrategicos = varEstrategicos;
			
				item.MujeresEmbarazadas = varMujeresEmbarazadas;
			
				item.EmbarazoRiesgo = varEmbarazoRiesgo;
			
				item.EmbarazoNormal = varEmbarazoNormal;
			
				item.Odps = varOdps;
			
				item.Ppac = varPpac;
			
				item.Sara = varSara;
			
				item.Ambulatorio = varAmbulatorio;
			
				item.Internacion = varInternacion;
			
				item.HospitalDia = varHospitalDia;
			
				item.Traslado = varTraslado;
			
				item.PatologiaQuirurgica = varPatologiaQuirurgica;
			
				item.PatologiaPrematurez = varPatologiaPrematurez;
			
				item.Ii = varIi;
			
				item.Iiia = varIiia;
			
				item.Iiib = varIiib;
			
				item.Priorizadas = varPriorizadas;
			
				item.Trazadoras = varTrazadoras;
			
				item.GruposCeb = varGruposCeb;
			
				item.DescripcionGruposCeb = varDescripcionGruposCeb;
			
				item.CodigosNacer = varCodigosNacer;
			
				item.CodigosRural = varCodigosRural;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPrestacionesNuevasColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoPrestacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionPrestacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ObjetoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MatrizExtendidaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn LineaCuidadoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoEtarioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionGrupoEtarioColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CatastroficoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CccColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn PatologiaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ModulosColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn EstrategicosColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MujeresEmbarazadasColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoRiesgoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoNormalColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn OdpsColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn PpacColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn SaraColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn AmbulatorioColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn InternacionColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn HospitalDiaColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn TrasladoColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn PatologiaQuirurgicaColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn PatologiaPrematurezColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn IiColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn IiiaColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn IiibColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn PriorizadasColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn TrazadorasColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn GruposCebColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionGruposCebColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigosNacerColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigosRuralColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPrestacionesNuevas = @"idPrestacionesNuevas";
			 public static string CodigoPrestacion = @"codigo_prestacion";
			 public static string DescripcionPrestacion = @"descripcion_prestacion";
			 public static string Tipo = @"tipo";
			 public static string Objeto = @"objeto";
			 public static string Diagnostico = @"diagnostico";
			 public static string MatrizExtendida = @"matriz_extendida";
			 public static string LineaCuidado = @"linea_cuidado";
			 public static string GrupoEtario = @"grupo_etario";
			 public static string DescripcionGrupoEtario = @"descripcion_grupo_etario";
			 public static string Catastrofico = @"catastrofico";
			 public static string Ccc = @"ccc";
			 public static string Patologia = @"patologia";
			 public static string Modulos = @"modulo(s)";
			 public static string Estrategicos = @"estrategicos";
			 public static string MujeresEmbarazadas = @"mujeres_embarazadas";
			 public static string EmbarazoRiesgo = @"embarazo_riesgo";
			 public static string EmbarazoNormal = @"embarazo_normal";
			 public static string Odps = @"odp(s)";
			 public static string Ppac = @"ppac";
			 public static string Sara = @"sara";
			 public static string Ambulatorio = @"ambulatorio";
			 public static string Internacion = @"internacion";
			 public static string HospitalDia = @"hospital_dia";
			 public static string Traslado = @"traslado";
			 public static string PatologiaQuirurgica = @"patologia_quirurgica";
			 public static string PatologiaPrematurez = @"patologia_prematurez";
			 public static string Ii = @"ii";
			 public static string Iiia = @"iiia";
			 public static string Iiib = @"iiib";
			 public static string Priorizadas = @"priorizadas";
			 public static string Trazadoras = @"trazadora(s)";
			 public static string GruposCeb = @"grupo(s) ceb";
			 public static string DescripcionGruposCeb = @"descripcion_grupos_ceb";
			 public static string CodigosNacer = @"codigos_nacer";
			 public static string CodigosRural = @"codigos_rural";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
