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
	/// Strongly-typed collection for the PnAltum class.
	/// </summary>
    [Serializable]
	public partial class PnAltumCollection : ActiveList<PnAltum, PnAltumCollection>
	{	   
		public PnAltumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAltumCollection</returns>
		public PnAltumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAltum o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_alta table.
	/// </summary>
	[Serializable]
	public partial class PnAltum : ActiveRecord<PnAltum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAltum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAltum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAltum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAltum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_alta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAlta = new TableSchema.TableColumn(schema);
				colvarIdAlta.ColumnName = "id_alta";
				colvarIdAlta.DataType = DbType.Int32;
				colvarIdAlta.MaxLength = 0;
				colvarIdAlta.AutoIncrement = true;
				colvarIdAlta.IsNullable = false;
				colvarIdAlta.IsPrimaryKey = true;
				colvarIdAlta.IsForeignKey = false;
				colvarIdAlta.IsReadOnly = false;
				colvarIdAlta.DefaultSetting = @"";
				colvarIdAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAlta);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = -1;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fecha_alta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = true;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				colvarFechaAlta.DefaultSetting = @"";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
				TableSchema.TableColumn colvarFechaParto = new TableSchema.TableColumn(schema);
				colvarFechaParto.ColumnName = "fecha_parto";
				colvarFechaParto.DataType = DbType.DateTime;
				colvarFechaParto.MaxLength = 0;
				colvarFechaParto.AutoIncrement = false;
				colvarFechaParto.IsNullable = true;
				colvarFechaParto.IsPrimaryKey = false;
				colvarFechaParto.IsForeignKey = false;
				colvarFechaParto.IsReadOnly = false;
				colvarFechaParto.DefaultSetting = @"";
				colvarFechaParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaParto);
				
				TableSchema.TableColumn colvarNomMadre = new TableSchema.TableColumn(schema);
				colvarNomMadre.ColumnName = "nom_madre";
				colvarNomMadre.DataType = DbType.AnsiString;
				colvarNomMadre.MaxLength = -1;
				colvarNomMadre.AutoIncrement = false;
				colvarNomMadre.IsNullable = true;
				colvarNomMadre.IsPrimaryKey = false;
				colvarNomMadre.IsForeignKey = false;
				colvarNomMadre.IsReadOnly = false;
				colvarNomMadre.DefaultSetting = @"";
				colvarNomMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNomMadre);
				
				TableSchema.TableColumn colvarDocMadre = new TableSchema.TableColumn(schema);
				colvarDocMadre.ColumnName = "doc_madre";
				colvarDocMadre.DataType = DbType.AnsiString;
				colvarDocMadre.MaxLength = -1;
				colvarDocMadre.AutoIncrement = false;
				colvarDocMadre.IsNullable = true;
				colvarDocMadre.IsPrimaryKey = false;
				colvarDocMadre.IsForeignKey = false;
				colvarDocMadre.IsReadOnly = false;
				colvarDocMadre.DefaultSetting = @"";
				colvarDocMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocMadre);
				
				TableSchema.TableColumn colvarNomBebe = new TableSchema.TableColumn(schema);
				colvarNomBebe.ColumnName = "nom_bebe";
				colvarNomBebe.DataType = DbType.AnsiString;
				colvarNomBebe.MaxLength = -1;
				colvarNomBebe.AutoIncrement = false;
				colvarNomBebe.IsNullable = true;
				colvarNomBebe.IsPrimaryKey = false;
				colvarNomBebe.IsForeignKey = false;
				colvarNomBebe.IsReadOnly = false;
				colvarNomBebe.DefaultSetting = @"";
				colvarNomBebe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNomBebe);
				
				TableSchema.TableColumn colvarRepObstetricia = new TableSchema.TableColumn(schema);
				colvarRepObstetricia.ColumnName = "rep_obstetricia";
				colvarRepObstetricia.DataType = DbType.AnsiString;
				colvarRepObstetricia.MaxLength = -1;
				colvarRepObstetricia.AutoIncrement = false;
				colvarRepObstetricia.IsNullable = true;
				colvarRepObstetricia.IsPrimaryKey = false;
				colvarRepObstetricia.IsForeignKey = false;
				colvarRepObstetricia.IsReadOnly = false;
				colvarRepObstetricia.DefaultSetting = @"";
				colvarRepObstetricia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRepObstetricia);
				
				TableSchema.TableColumn colvarRepNeo = new TableSchema.TableColumn(schema);
				colvarRepNeo.ColumnName = "rep_neo";
				colvarRepNeo.DataType = DbType.AnsiString;
				colvarRepNeo.MaxLength = -1;
				colvarRepNeo.AutoIncrement = false;
				colvarRepNeo.IsNullable = true;
				colvarRepNeo.IsPrimaryKey = false;
				colvarRepNeo.IsForeignKey = false;
				colvarRepNeo.IsReadOnly = false;
				colvarRepNeo.DefaultSetting = @"";
				colvarRepNeo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRepNeo);
				
				TableSchema.TableColumn colvarRepEnf = new TableSchema.TableColumn(schema);
				colvarRepEnf.ColumnName = "rep_enf";
				colvarRepEnf.DataType = DbType.AnsiString;
				colvarRepEnf.MaxLength = -1;
				colvarRepEnf.AutoIncrement = false;
				colvarRepEnf.IsNullable = true;
				colvarRepEnf.IsPrimaryKey = false;
				colvarRepEnf.IsForeignKey = false;
				colvarRepEnf.IsReadOnly = false;
				colvarRepEnf.DefaultSetting = @"";
				colvarRepEnf.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRepEnf);
				
				TableSchema.TableColumn colvarLlenaEpi = new TableSchema.TableColumn(schema);
				colvarLlenaEpi.ColumnName = "llena_epi";
				colvarLlenaEpi.DataType = DbType.AnsiString;
				colvarLlenaEpi.MaxLength = -1;
				colvarLlenaEpi.AutoIncrement = false;
				colvarLlenaEpi.IsNullable = true;
				colvarLlenaEpi.IsPrimaryKey = false;
				colvarLlenaEpi.IsForeignKey = false;
				colvarLlenaEpi.IsReadOnly = false;
				colvarLlenaEpi.DefaultSetting = @"";
				colvarLlenaEpi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLlenaEpi);
				
				TableSchema.TableColumn colvarCarnetParenteral = new TableSchema.TableColumn(schema);
				colvarCarnetParenteral.ColumnName = "carnet_parenteral";
				colvarCarnetParenteral.DataType = DbType.AnsiString;
				colvarCarnetParenteral.MaxLength = -1;
				colvarCarnetParenteral.AutoIncrement = false;
				colvarCarnetParenteral.IsNullable = true;
				colvarCarnetParenteral.IsPrimaryKey = false;
				colvarCarnetParenteral.IsForeignKey = false;
				colvarCarnetParenteral.IsReadOnly = false;
				colvarCarnetParenteral.DefaultSetting = @"";
				colvarCarnetParenteral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCarnetParenteral);
				
				TableSchema.TableColumn colvarPesoNacer = new TableSchema.TableColumn(schema);
				colvarPesoNacer.ColumnName = "peso_nacer";
				colvarPesoNacer.DataType = DbType.Decimal;
				colvarPesoNacer.MaxLength = 0;
				colvarPesoNacer.AutoIncrement = false;
				colvarPesoNacer.IsNullable = true;
				colvarPesoNacer.IsPrimaryKey = false;
				colvarPesoNacer.IsForeignKey = false;
				colvarPesoNacer.IsReadOnly = false;
				colvarPesoNacer.DefaultSetting = @"";
				colvarPesoNacer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPesoNacer);
				
				TableSchema.TableColumn colvarRiesgoSocial = new TableSchema.TableColumn(schema);
				colvarRiesgoSocial.ColumnName = "riesgo_social";
				colvarRiesgoSocial.DataType = DbType.AnsiString;
				colvarRiesgoSocial.MaxLength = -1;
				colvarRiesgoSocial.AutoIncrement = false;
				colvarRiesgoSocial.IsNullable = true;
				colvarRiesgoSocial.IsPrimaryKey = false;
				colvarRiesgoSocial.IsForeignKey = false;
				colvarRiesgoSocial.IsReadOnly = false;
				colvarRiesgoSocial.DefaultSetting = @"";
				colvarRiesgoSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRiesgoSocial);
				
				TableSchema.TableColumn colvarSifilis = new TableSchema.TableColumn(schema);
				colvarSifilis.ColumnName = "sifilis";
				colvarSifilis.DataType = DbType.AnsiString;
				colvarSifilis.MaxLength = -1;
				colvarSifilis.AutoIncrement = false;
				colvarSifilis.IsNullable = true;
				colvarSifilis.IsPrimaryKey = false;
				colvarSifilis.IsForeignKey = false;
				colvarSifilis.IsReadOnly = false;
				colvarSifilis.DefaultSetting = @"";
				colvarSifilis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSifilis);
				
				TableSchema.TableColumn colvarHiv = new TableSchema.TableColumn(schema);
				colvarHiv.ColumnName = "hiv";
				colvarHiv.DataType = DbType.AnsiString;
				colvarHiv.MaxLength = -1;
				colvarHiv.AutoIncrement = false;
				colvarHiv.IsNullable = true;
				colvarHiv.IsPrimaryKey = false;
				colvarHiv.IsForeignKey = false;
				colvarHiv.IsReadOnly = false;
				colvarHiv.DefaultSetting = @"";
				colvarHiv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHiv);
				
				TableSchema.TableColumn colvarHepB = new TableSchema.TableColumn(schema);
				colvarHepB.ColumnName = "hep_b";
				colvarHepB.DataType = DbType.AnsiString;
				colvarHepB.MaxLength = -1;
				colvarHepB.AutoIncrement = false;
				colvarHepB.IsNullable = true;
				colvarHepB.IsPrimaryKey = false;
				colvarHepB.IsForeignKey = false;
				colvarHepB.IsReadOnly = false;
				colvarHepB.DefaultSetting = @"";
				colvarHepB.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHepB);
				
				TableSchema.TableColumn colvarChagas = new TableSchema.TableColumn(schema);
				colvarChagas.ColumnName = "chagas";
				colvarChagas.DataType = DbType.AnsiString;
				colvarChagas.MaxLength = -1;
				colvarChagas.AutoIncrement = false;
				colvarChagas.IsNullable = true;
				colvarChagas.IsPrimaryKey = false;
				colvarChagas.IsForeignKey = false;
				colvarChagas.IsReadOnly = false;
				colvarChagas.DefaultSetting = @"";
				colvarChagas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChagas);
				
				TableSchema.TableColumn colvarToxo = new TableSchema.TableColumn(schema);
				colvarToxo.ColumnName = "toxo";
				colvarToxo.DataType = DbType.AnsiString;
				colvarToxo.MaxLength = -1;
				colvarToxo.AutoIncrement = false;
				colvarToxo.IsNullable = true;
				colvarToxo.IsPrimaryKey = false;
				colvarToxo.IsForeignKey = false;
				colvarToxo.IsReadOnly = false;
				colvarToxo.DefaultSetting = @"";
				colvarToxo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToxo);
				
				TableSchema.TableColumn colvarPesNeonatal = new TableSchema.TableColumn(schema);
				colvarPesNeonatal.ColumnName = "pes_neonatal";
				colvarPesNeonatal.DataType = DbType.AnsiString;
				colvarPesNeonatal.MaxLength = -1;
				colvarPesNeonatal.AutoIncrement = false;
				colvarPesNeonatal.IsNullable = true;
				colvarPesNeonatal.IsPrimaryKey = false;
				colvarPesNeonatal.IsForeignKey = false;
				colvarPesNeonatal.IsReadOnly = false;
				colvarPesNeonatal.DefaultSetting = @"";
				colvarPesNeonatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPesNeonatal);
				
				TableSchema.TableColumn colvarVacHepB = new TableSchema.TableColumn(schema);
				colvarVacHepB.ColumnName = "vac_hep_b";
				colvarVacHepB.DataType = DbType.AnsiString;
				colvarVacHepB.MaxLength = -1;
				colvarVacHepB.AutoIncrement = false;
				colvarVacHepB.IsNullable = true;
				colvarVacHepB.IsPrimaryKey = false;
				colvarVacHepB.IsForeignKey = false;
				colvarVacHepB.IsReadOnly = false;
				colvarVacHepB.DefaultSetting = @"";
				colvarVacHepB.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacHepB);
				
				TableSchema.TableColumn colvarVacBcg = new TableSchema.TableColumn(schema);
				colvarVacBcg.ColumnName = "vac_bcg";
				colvarVacBcg.DataType = DbType.AnsiString;
				colvarVacBcg.MaxLength = -1;
				colvarVacBcg.AutoIncrement = false;
				colvarVacBcg.IsNullable = true;
				colvarVacBcg.IsPrimaryKey = false;
				colvarVacBcg.IsForeignKey = false;
				colvarVacBcg.IsReadOnly = false;
				colvarVacBcg.DefaultSetting = @"";
				colvarVacBcg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacBcg);
				
				TableSchema.TableColumn colvarGrupoFactorMama = new TableSchema.TableColumn(schema);
				colvarGrupoFactorMama.ColumnName = "grupo_factor_mama";
				colvarGrupoFactorMama.DataType = DbType.AnsiString;
				colvarGrupoFactorMama.MaxLength = -1;
				colvarGrupoFactorMama.AutoIncrement = false;
				colvarGrupoFactorMama.IsNullable = true;
				colvarGrupoFactorMama.IsPrimaryKey = false;
				colvarGrupoFactorMama.IsForeignKey = false;
				colvarGrupoFactorMama.IsReadOnly = false;
				colvarGrupoFactorMama.DefaultSetting = @"";
				colvarGrupoFactorMama.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupoFactorMama);
				
				TableSchema.TableColumn colvarGrupoFactorBebe = new TableSchema.TableColumn(schema);
				colvarGrupoFactorBebe.ColumnName = "grupo_factor_bebe";
				colvarGrupoFactorBebe.DataType = DbType.AnsiString;
				colvarGrupoFactorBebe.MaxLength = -1;
				colvarGrupoFactorBebe.AutoIncrement = false;
				colvarGrupoFactorBebe.IsNullable = true;
				colvarGrupoFactorBebe.IsPrimaryKey = false;
				colvarGrupoFactorBebe.IsForeignKey = false;
				colvarGrupoFactorBebe.IsReadOnly = false;
				colvarGrupoFactorBebe.DefaultSetting = @"";
				colvarGrupoFactorBebe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupoFactorBebe);
				
				TableSchema.TableColumn colvarGammaAntiRh = new TableSchema.TableColumn(schema);
				colvarGammaAntiRh.ColumnName = "gamma_anti_rh";
				colvarGammaAntiRh.DataType = DbType.AnsiString;
				colvarGammaAntiRh.MaxLength = -1;
				colvarGammaAntiRh.AutoIncrement = false;
				colvarGammaAntiRh.IsNullable = true;
				colvarGammaAntiRh.IsPrimaryKey = false;
				colvarGammaAntiRh.IsForeignKey = false;
				colvarGammaAntiRh.IsReadOnly = false;
				colvarGammaAntiRh.DefaultSetting = @"";
				colvarGammaAntiRh.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGammaAntiRh);
				
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
				
				TableSchema.TableColumn colvarCuieAtHab = new TableSchema.TableColumn(schema);
				colvarCuieAtHab.ColumnName = "cuie_at_hab";
				colvarCuieAtHab.DataType = DbType.AnsiString;
				colvarCuieAtHab.MaxLength = -1;
				colvarCuieAtHab.AutoIncrement = false;
				colvarCuieAtHab.IsNullable = true;
				colvarCuieAtHab.IsPrimaryKey = false;
				colvarCuieAtHab.IsForeignKey = false;
				colvarCuieAtHab.IsReadOnly = false;
				colvarCuieAtHab.DefaultSetting = @"";
				colvarCuieAtHab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuieAtHab);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
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
				
				TableSchema.TableColumn colvarPueri = new TableSchema.TableColumn(schema);
				colvarPueri.ColumnName = "pueri";
				colvarPueri.DataType = DbType.AnsiString;
				colvarPueri.MaxLength = -1;
				colvarPueri.AutoIncrement = false;
				colvarPueri.IsNullable = true;
				colvarPueri.IsPrimaryKey = false;
				colvarPueri.IsForeignKey = false;
				colvarPueri.IsReadOnly = false;
				colvarPueri.DefaultSetting = @"";
				colvarPueri.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPueri);
				
				TableSchema.TableColumn colvarAlarmaBebe = new TableSchema.TableColumn(schema);
				colvarAlarmaBebe.ColumnName = "alarma_bebe";
				colvarAlarmaBebe.DataType = DbType.AnsiString;
				colvarAlarmaBebe.MaxLength = -1;
				colvarAlarmaBebe.AutoIncrement = false;
				colvarAlarmaBebe.IsNullable = true;
				colvarAlarmaBebe.IsPrimaryKey = false;
				colvarAlarmaBebe.IsForeignKey = false;
				colvarAlarmaBebe.IsReadOnly = false;
				colvarAlarmaBebe.DefaultSetting = @"";
				colvarAlarmaBebe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlarmaBebe);
				
				TableSchema.TableColumn colvarAlarmaMadre = new TableSchema.TableColumn(schema);
				colvarAlarmaMadre.ColumnName = "alarma_madre";
				colvarAlarmaMadre.DataType = DbType.AnsiString;
				colvarAlarmaMadre.MaxLength = -1;
				colvarAlarmaMadre.AutoIncrement = false;
				colvarAlarmaMadre.IsNullable = true;
				colvarAlarmaMadre.IsPrimaryKey = false;
				colvarAlarmaMadre.IsForeignKey = false;
				colvarAlarmaMadre.IsReadOnly = false;
				colvarAlarmaMadre.DefaultSetting = @"";
				colvarAlarmaMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlarmaMadre);
				
				TableSchema.TableColumn colvarLacMaterna = new TableSchema.TableColumn(schema);
				colvarLacMaterna.ColumnName = "lac_materna";
				colvarLacMaterna.DataType = DbType.AnsiString;
				colvarLacMaterna.MaxLength = -1;
				colvarLacMaterna.AutoIncrement = false;
				colvarLacMaterna.IsNullable = true;
				colvarLacMaterna.IsPrimaryKey = false;
				colvarLacMaterna.IsForeignKey = false;
				colvarLacMaterna.IsReadOnly = false;
				colvarLacMaterna.DefaultSetting = @"";
				colvarLacMaterna.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLacMaterna);
				
				TableSchema.TableColumn colvarSaludRepro = new TableSchema.TableColumn(schema);
				colvarSaludRepro.ColumnName = "salud_repro";
				colvarSaludRepro.DataType = DbType.AnsiString;
				colvarSaludRepro.MaxLength = -1;
				colvarSaludRepro.AutoIncrement = false;
				colvarSaludRepro.IsNullable = true;
				colvarSaludRepro.IsPrimaryKey = false;
				colvarSaludRepro.IsForeignKey = false;
				colvarSaludRepro.IsReadOnly = false;
				colvarSaludRepro.DefaultSetting = @"";
				colvarSaludRepro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSaludRepro);
				
				TableSchema.TableColumn colvarCuidadosPuerpe = new TableSchema.TableColumn(schema);
				colvarCuidadosPuerpe.ColumnName = "cuidados_puerpe";
				colvarCuidadosPuerpe.DataType = DbType.AnsiString;
				colvarCuidadosPuerpe.MaxLength = -1;
				colvarCuidadosPuerpe.AutoIncrement = false;
				colvarCuidadosPuerpe.IsNullable = true;
				colvarCuidadosPuerpe.IsPrimaryKey = false;
				colvarCuidadosPuerpe.IsForeignKey = false;
				colvarCuidadosPuerpe.IsReadOnly = false;
				colvarCuidadosPuerpe.DefaultSetting = @"";
				colvarCuidadosPuerpe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuidadosPuerpe);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_alta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAlta")]
		[Bindable(true)]
		public int IdAlta 
		{
			get { return GetColumnValue<int>(Columns.IdAlta); }
			set { SetColumnValue(Columns.IdAlta, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime? FechaAlta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		  
		[XmlAttribute("FechaParto")]
		[Bindable(true)]
		public DateTime? FechaParto 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaParto); }
			set { SetColumnValue(Columns.FechaParto, value); }
		}
		  
		[XmlAttribute("NomMadre")]
		[Bindable(true)]
		public string NomMadre 
		{
			get { return GetColumnValue<string>(Columns.NomMadre); }
			set { SetColumnValue(Columns.NomMadre, value); }
		}
		  
		[XmlAttribute("DocMadre")]
		[Bindable(true)]
		public string DocMadre 
		{
			get { return GetColumnValue<string>(Columns.DocMadre); }
			set { SetColumnValue(Columns.DocMadre, value); }
		}
		  
		[XmlAttribute("NomBebe")]
		[Bindable(true)]
		public string NomBebe 
		{
			get { return GetColumnValue<string>(Columns.NomBebe); }
			set { SetColumnValue(Columns.NomBebe, value); }
		}
		  
		[XmlAttribute("RepObstetricia")]
		[Bindable(true)]
		public string RepObstetricia 
		{
			get { return GetColumnValue<string>(Columns.RepObstetricia); }
			set { SetColumnValue(Columns.RepObstetricia, value); }
		}
		  
		[XmlAttribute("RepNeo")]
		[Bindable(true)]
		public string RepNeo 
		{
			get { return GetColumnValue<string>(Columns.RepNeo); }
			set { SetColumnValue(Columns.RepNeo, value); }
		}
		  
		[XmlAttribute("RepEnf")]
		[Bindable(true)]
		public string RepEnf 
		{
			get { return GetColumnValue<string>(Columns.RepEnf); }
			set { SetColumnValue(Columns.RepEnf, value); }
		}
		  
		[XmlAttribute("LlenaEpi")]
		[Bindable(true)]
		public string LlenaEpi 
		{
			get { return GetColumnValue<string>(Columns.LlenaEpi); }
			set { SetColumnValue(Columns.LlenaEpi, value); }
		}
		  
		[XmlAttribute("CarnetParenteral")]
		[Bindable(true)]
		public string CarnetParenteral 
		{
			get { return GetColumnValue<string>(Columns.CarnetParenteral); }
			set { SetColumnValue(Columns.CarnetParenteral, value); }
		}
		  
		[XmlAttribute("PesoNacer")]
		[Bindable(true)]
		public decimal? PesoNacer 
		{
			get { return GetColumnValue<decimal?>(Columns.PesoNacer); }
			set { SetColumnValue(Columns.PesoNacer, value); }
		}
		  
		[XmlAttribute("RiesgoSocial")]
		[Bindable(true)]
		public string RiesgoSocial 
		{
			get { return GetColumnValue<string>(Columns.RiesgoSocial); }
			set { SetColumnValue(Columns.RiesgoSocial, value); }
		}
		  
		[XmlAttribute("Sifilis")]
		[Bindable(true)]
		public string Sifilis 
		{
			get { return GetColumnValue<string>(Columns.Sifilis); }
			set { SetColumnValue(Columns.Sifilis, value); }
		}
		  
		[XmlAttribute("Hiv")]
		[Bindable(true)]
		public string Hiv 
		{
			get { return GetColumnValue<string>(Columns.Hiv); }
			set { SetColumnValue(Columns.Hiv, value); }
		}
		  
		[XmlAttribute("HepB")]
		[Bindable(true)]
		public string HepB 
		{
			get { return GetColumnValue<string>(Columns.HepB); }
			set { SetColumnValue(Columns.HepB, value); }
		}
		  
		[XmlAttribute("Chagas")]
		[Bindable(true)]
		public string Chagas 
		{
			get { return GetColumnValue<string>(Columns.Chagas); }
			set { SetColumnValue(Columns.Chagas, value); }
		}
		  
		[XmlAttribute("Toxo")]
		[Bindable(true)]
		public string Toxo 
		{
			get { return GetColumnValue<string>(Columns.Toxo); }
			set { SetColumnValue(Columns.Toxo, value); }
		}
		  
		[XmlAttribute("PesNeonatal")]
		[Bindable(true)]
		public string PesNeonatal 
		{
			get { return GetColumnValue<string>(Columns.PesNeonatal); }
			set { SetColumnValue(Columns.PesNeonatal, value); }
		}
		  
		[XmlAttribute("VacHepB")]
		[Bindable(true)]
		public string VacHepB 
		{
			get { return GetColumnValue<string>(Columns.VacHepB); }
			set { SetColumnValue(Columns.VacHepB, value); }
		}
		  
		[XmlAttribute("VacBcg")]
		[Bindable(true)]
		public string VacBcg 
		{
			get { return GetColumnValue<string>(Columns.VacBcg); }
			set { SetColumnValue(Columns.VacBcg, value); }
		}
		  
		[XmlAttribute("GrupoFactorMama")]
		[Bindable(true)]
		public string GrupoFactorMama 
		{
			get { return GetColumnValue<string>(Columns.GrupoFactorMama); }
			set { SetColumnValue(Columns.GrupoFactorMama, value); }
		}
		  
		[XmlAttribute("GrupoFactorBebe")]
		[Bindable(true)]
		public string GrupoFactorBebe 
		{
			get { return GetColumnValue<string>(Columns.GrupoFactorBebe); }
			set { SetColumnValue(Columns.GrupoFactorBebe, value); }
		}
		  
		[XmlAttribute("GammaAntiRh")]
		[Bindable(true)]
		public string GammaAntiRh 
		{
			get { return GetColumnValue<string>(Columns.GammaAntiRh); }
			set { SetColumnValue(Columns.GammaAntiRh, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("CuieAtHab")]
		[Bindable(true)]
		public string CuieAtHab 
		{
			get { return GetColumnValue<string>(Columns.CuieAtHab); }
			set { SetColumnValue(Columns.CuieAtHab, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Pueri")]
		[Bindable(true)]
		public string Pueri 
		{
			get { return GetColumnValue<string>(Columns.Pueri); }
			set { SetColumnValue(Columns.Pueri, value); }
		}
		  
		[XmlAttribute("AlarmaBebe")]
		[Bindable(true)]
		public string AlarmaBebe 
		{
			get { return GetColumnValue<string>(Columns.AlarmaBebe); }
			set { SetColumnValue(Columns.AlarmaBebe, value); }
		}
		  
		[XmlAttribute("AlarmaMadre")]
		[Bindable(true)]
		public string AlarmaMadre 
		{
			get { return GetColumnValue<string>(Columns.AlarmaMadre); }
			set { SetColumnValue(Columns.AlarmaMadre, value); }
		}
		  
		[XmlAttribute("LacMaterna")]
		[Bindable(true)]
		public string LacMaterna 
		{
			get { return GetColumnValue<string>(Columns.LacMaterna); }
			set { SetColumnValue(Columns.LacMaterna, value); }
		}
		  
		[XmlAttribute("SaludRepro")]
		[Bindable(true)]
		public string SaludRepro 
		{
			get { return GetColumnValue<string>(Columns.SaludRepro); }
			set { SetColumnValue(Columns.SaludRepro, value); }
		}
		  
		[XmlAttribute("CuidadosPuerpe")]
		[Bindable(true)]
		public string CuidadosPuerpe 
		{
			get { return GetColumnValue<string>(Columns.CuidadosPuerpe); }
			set { SetColumnValue(Columns.CuidadosPuerpe, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,DateTime? varFechaAlta,DateTime? varFechaParto,string varNomMadre,string varDocMadre,string varNomBebe,string varRepObstetricia,string varRepNeo,string varRepEnf,string varLlenaEpi,string varCarnetParenteral,decimal? varPesoNacer,string varRiesgoSocial,string varSifilis,string varHiv,string varHepB,string varChagas,string varToxo,string varPesNeonatal,string varVacHepB,string varVacBcg,string varGrupoFactorMama,string varGrupoFactorBebe,string varGammaAntiRh,string varObservaciones,string varCuieAtHab,string varDomicilio,string varPueri,string varAlarmaBebe,string varAlarmaMadre,string varLacMaterna,string varSaludRepro,string varCuidadosPuerpe)
		{
			PnAltum item = new PnAltum();
			
			item.Cuie = varCuie;
			
			item.FechaAlta = varFechaAlta;
			
			item.FechaParto = varFechaParto;
			
			item.NomMadre = varNomMadre;
			
			item.DocMadre = varDocMadre;
			
			item.NomBebe = varNomBebe;
			
			item.RepObstetricia = varRepObstetricia;
			
			item.RepNeo = varRepNeo;
			
			item.RepEnf = varRepEnf;
			
			item.LlenaEpi = varLlenaEpi;
			
			item.CarnetParenteral = varCarnetParenteral;
			
			item.PesoNacer = varPesoNacer;
			
			item.RiesgoSocial = varRiesgoSocial;
			
			item.Sifilis = varSifilis;
			
			item.Hiv = varHiv;
			
			item.HepB = varHepB;
			
			item.Chagas = varChagas;
			
			item.Toxo = varToxo;
			
			item.PesNeonatal = varPesNeonatal;
			
			item.VacHepB = varVacHepB;
			
			item.VacBcg = varVacBcg;
			
			item.GrupoFactorMama = varGrupoFactorMama;
			
			item.GrupoFactorBebe = varGrupoFactorBebe;
			
			item.GammaAntiRh = varGammaAntiRh;
			
			item.Observaciones = varObservaciones;
			
			item.CuieAtHab = varCuieAtHab;
			
			item.Domicilio = varDomicilio;
			
			item.Pueri = varPueri;
			
			item.AlarmaBebe = varAlarmaBebe;
			
			item.AlarmaMadre = varAlarmaMadre;
			
			item.LacMaterna = varLacMaterna;
			
			item.SaludRepro = varSaludRepro;
			
			item.CuidadosPuerpe = varCuidadosPuerpe;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAlta,string varCuie,DateTime? varFechaAlta,DateTime? varFechaParto,string varNomMadre,string varDocMadre,string varNomBebe,string varRepObstetricia,string varRepNeo,string varRepEnf,string varLlenaEpi,string varCarnetParenteral,decimal? varPesoNacer,string varRiesgoSocial,string varSifilis,string varHiv,string varHepB,string varChagas,string varToxo,string varPesNeonatal,string varVacHepB,string varVacBcg,string varGrupoFactorMama,string varGrupoFactorBebe,string varGammaAntiRh,string varObservaciones,string varCuieAtHab,string varDomicilio,string varPueri,string varAlarmaBebe,string varAlarmaMadre,string varLacMaterna,string varSaludRepro,string varCuidadosPuerpe)
		{
			PnAltum item = new PnAltum();
			
				item.IdAlta = varIdAlta;
			
				item.Cuie = varCuie;
			
				item.FechaAlta = varFechaAlta;
			
				item.FechaParto = varFechaParto;
			
				item.NomMadre = varNomMadre;
			
				item.DocMadre = varDocMadre;
			
				item.NomBebe = varNomBebe;
			
				item.RepObstetricia = varRepObstetricia;
			
				item.RepNeo = varRepNeo;
			
				item.RepEnf = varRepEnf;
			
				item.LlenaEpi = varLlenaEpi;
			
				item.CarnetParenteral = varCarnetParenteral;
			
				item.PesoNacer = varPesoNacer;
			
				item.RiesgoSocial = varRiesgoSocial;
			
				item.Sifilis = varSifilis;
			
				item.Hiv = varHiv;
			
				item.HepB = varHepB;
			
				item.Chagas = varChagas;
			
				item.Toxo = varToxo;
			
				item.PesNeonatal = varPesNeonatal;
			
				item.VacHepB = varVacHepB;
			
				item.VacBcg = varVacBcg;
			
				item.GrupoFactorMama = varGrupoFactorMama;
			
				item.GrupoFactorBebe = varGrupoFactorBebe;
			
				item.GammaAntiRh = varGammaAntiRh;
			
				item.Observaciones = varObservaciones;
			
				item.CuieAtHab = varCuieAtHab;
			
				item.Domicilio = varDomicilio;
			
				item.Pueri = varPueri;
			
				item.AlarmaBebe = varAlarmaBebe;
			
				item.AlarmaMadre = varAlarmaMadre;
			
				item.LacMaterna = varLacMaterna;
			
				item.SaludRepro = varSaludRepro;
			
				item.CuidadosPuerpe = varCuidadosPuerpe;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAltaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPartoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NomMadreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DocMadreColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NomBebeColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn RepObstetriciaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn RepNeoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn RepEnfColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn LlenaEpiColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CarnetParenteralColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoNacerColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn RiesgoSocialColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn SifilisColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn HivColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn HepBColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ChagasColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ToxoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn PesNeonatalColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn VacHepBColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn VacBcgColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoFactorMamaColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoFactorBebeColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn GammaAntiRhColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieAtHabColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn PueriColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn AlarmaBebeColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn AlarmaMadreColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn LacMaternaColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn SaludReproColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn CuidadosPuerpeColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAlta = @"id_alta";
			 public static string Cuie = @"cuie";
			 public static string FechaAlta = @"fecha_alta";
			 public static string FechaParto = @"fecha_parto";
			 public static string NomMadre = @"nom_madre";
			 public static string DocMadre = @"doc_madre";
			 public static string NomBebe = @"nom_bebe";
			 public static string RepObstetricia = @"rep_obstetricia";
			 public static string RepNeo = @"rep_neo";
			 public static string RepEnf = @"rep_enf";
			 public static string LlenaEpi = @"llena_epi";
			 public static string CarnetParenteral = @"carnet_parenteral";
			 public static string PesoNacer = @"peso_nacer";
			 public static string RiesgoSocial = @"riesgo_social";
			 public static string Sifilis = @"sifilis";
			 public static string Hiv = @"hiv";
			 public static string HepB = @"hep_b";
			 public static string Chagas = @"chagas";
			 public static string Toxo = @"toxo";
			 public static string PesNeonatal = @"pes_neonatal";
			 public static string VacHepB = @"vac_hep_b";
			 public static string VacBcg = @"vac_bcg";
			 public static string GrupoFactorMama = @"grupo_factor_mama";
			 public static string GrupoFactorBebe = @"grupo_factor_bebe";
			 public static string GammaAntiRh = @"gamma_anti_rh";
			 public static string Observaciones = @"observaciones";
			 public static string CuieAtHab = @"cuie_at_hab";
			 public static string Domicilio = @"domicilio";
			 public static string Pueri = @"pueri";
			 public static string AlarmaBebe = @"alarma_bebe";
			 public static string AlarmaMadre = @"alarma_madre";
			 public static string LacMaterna = @"lac_materna";
			 public static string SaludRepro = @"salud_repro";
			 public static string CuidadosPuerpe = @"cuidados_puerpe";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
