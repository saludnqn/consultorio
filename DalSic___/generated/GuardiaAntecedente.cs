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
	/// Strongly-typed collection for the GuardiaAntecedente class.
	/// </summary>
    [Serializable]
	public partial class GuardiaAntecedenteCollection : ActiveList<GuardiaAntecedente, GuardiaAntecedenteCollection>
	{	   
		public GuardiaAntecedenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaAntecedenteCollection</returns>
		public GuardiaAntecedenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaAntecedente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Antecedentes table.
	/// </summary>
	[Serializable]
	public partial class GuardiaAntecedente : ActiveRecord<GuardiaAntecedente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaAntecedente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaAntecedente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaAntecedente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaAntecedente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Antecedentes", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarAsma = new TableSchema.TableColumn(schema);
				colvarAsma.ColumnName = "asma";
				colvarAsma.DataType = DbType.Boolean;
				colvarAsma.MaxLength = 0;
				colvarAsma.AutoIncrement = false;
				colvarAsma.IsNullable = true;
				colvarAsma.IsPrimaryKey = false;
				colvarAsma.IsForeignKey = false;
				colvarAsma.IsReadOnly = false;
				colvarAsma.DefaultSetting = @"";
				colvarAsma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAsma);
				
				TableSchema.TableColumn colvarAsmaText = new TableSchema.TableColumn(schema);
				colvarAsmaText.ColumnName = "asmaText";
				colvarAsmaText.DataType = DbType.AnsiString;
				colvarAsmaText.MaxLength = -1;
				colvarAsmaText.AutoIncrement = false;
				colvarAsmaText.IsNullable = true;
				colvarAsmaText.IsPrimaryKey = false;
				colvarAsmaText.IsForeignKey = false;
				colvarAsmaText.IsReadOnly = false;
				colvarAsmaText.DefaultSetting = @"";
				colvarAsmaText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAsmaText);
				
				TableSchema.TableColumn colvarIrc = new TableSchema.TableColumn(schema);
				colvarIrc.ColumnName = "irc";
				colvarIrc.DataType = DbType.Boolean;
				colvarIrc.MaxLength = 0;
				colvarIrc.AutoIncrement = false;
				colvarIrc.IsNullable = true;
				colvarIrc.IsPrimaryKey = false;
				colvarIrc.IsForeignKey = false;
				colvarIrc.IsReadOnly = false;
				colvarIrc.DefaultSetting = @"";
				colvarIrc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIrc);
				
				TableSchema.TableColumn colvarIrcText = new TableSchema.TableColumn(schema);
				colvarIrcText.ColumnName = "ircText";
				colvarIrcText.DataType = DbType.AnsiString;
				colvarIrcText.MaxLength = -1;
				colvarIrcText.AutoIncrement = false;
				colvarIrcText.IsNullable = true;
				colvarIrcText.IsPrimaryKey = false;
				colvarIrcText.IsForeignKey = false;
				colvarIrcText.IsReadOnly = false;
				colvarIrcText.DefaultSetting = @"";
				colvarIrcText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIrcText);
				
				TableSchema.TableColumn colvarCirugias = new TableSchema.TableColumn(schema);
				colvarCirugias.ColumnName = "cirugias";
				colvarCirugias.DataType = DbType.Boolean;
				colvarCirugias.MaxLength = 0;
				colvarCirugias.AutoIncrement = false;
				colvarCirugias.IsNullable = true;
				colvarCirugias.IsPrimaryKey = false;
				colvarCirugias.IsForeignKey = false;
				colvarCirugias.IsReadOnly = false;
				colvarCirugias.DefaultSetting = @"";
				colvarCirugias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCirugias);
				
				TableSchema.TableColumn colvarCirugiasText = new TableSchema.TableColumn(schema);
				colvarCirugiasText.ColumnName = "cirugiasText";
				colvarCirugiasText.DataType = DbType.AnsiString;
				colvarCirugiasText.MaxLength = -1;
				colvarCirugiasText.AutoIncrement = false;
				colvarCirugiasText.IsNullable = true;
				colvarCirugiasText.IsPrimaryKey = false;
				colvarCirugiasText.IsForeignKey = false;
				colvarCirugiasText.IsReadOnly = false;
				colvarCirugiasText.DefaultSetting = @"";
				colvarCirugiasText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCirugiasText);
				
				TableSchema.TableColumn colvarHta = new TableSchema.TableColumn(schema);
				colvarHta.ColumnName = "hta";
				colvarHta.DataType = DbType.Boolean;
				colvarHta.MaxLength = 0;
				colvarHta.AutoIncrement = false;
				colvarHta.IsNullable = true;
				colvarHta.IsPrimaryKey = false;
				colvarHta.IsForeignKey = false;
				colvarHta.IsReadOnly = false;
				colvarHta.DefaultSetting = @"";
				colvarHta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHta);
				
				TableSchema.TableColumn colvarHtaText = new TableSchema.TableColumn(schema);
				colvarHtaText.ColumnName = "htaText";
				colvarHtaText.DataType = DbType.AnsiString;
				colvarHtaText.MaxLength = -1;
				colvarHtaText.AutoIncrement = false;
				colvarHtaText.IsNullable = true;
				colvarHtaText.IsPrimaryKey = false;
				colvarHtaText.IsForeignKey = false;
				colvarHtaText.IsReadOnly = false;
				colvarHtaText.DefaultSetting = @"";
				colvarHtaText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHtaText);
				
				TableSchema.TableColumn colvarInfectologicas = new TableSchema.TableColumn(schema);
				colvarInfectologicas.ColumnName = "infectologicas";
				colvarInfectologicas.DataType = DbType.Boolean;
				colvarInfectologicas.MaxLength = 0;
				colvarInfectologicas.AutoIncrement = false;
				colvarInfectologicas.IsNullable = true;
				colvarInfectologicas.IsPrimaryKey = false;
				colvarInfectologicas.IsForeignKey = false;
				colvarInfectologicas.IsReadOnly = false;
				colvarInfectologicas.DefaultSetting = @"";
				colvarInfectologicas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInfectologicas);
				
				TableSchema.TableColumn colvarInfectologicasText = new TableSchema.TableColumn(schema);
				colvarInfectologicasText.ColumnName = "infectologicasText";
				colvarInfectologicasText.DataType = DbType.AnsiString;
				colvarInfectologicasText.MaxLength = -1;
				colvarInfectologicasText.AutoIncrement = false;
				colvarInfectologicasText.IsNullable = true;
				colvarInfectologicasText.IsPrimaryKey = false;
				colvarInfectologicasText.IsForeignKey = false;
				colvarInfectologicasText.IsReadOnly = false;
				colvarInfectologicasText.DefaultSetting = @"";
				colvarInfectologicasText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInfectologicasText);
				
				TableSchema.TableColumn colvarAlergias = new TableSchema.TableColumn(schema);
				colvarAlergias.ColumnName = "alergias";
				colvarAlergias.DataType = DbType.Boolean;
				colvarAlergias.MaxLength = 0;
				colvarAlergias.AutoIncrement = false;
				colvarAlergias.IsNullable = true;
				colvarAlergias.IsPrimaryKey = false;
				colvarAlergias.IsForeignKey = false;
				colvarAlergias.IsReadOnly = false;
				colvarAlergias.DefaultSetting = @"";
				colvarAlergias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlergias);
				
				TableSchema.TableColumn colvarAlergiasText = new TableSchema.TableColumn(schema);
				colvarAlergiasText.ColumnName = "alergiasText";
				colvarAlergiasText.DataType = DbType.AnsiString;
				colvarAlergiasText.MaxLength = -1;
				colvarAlergiasText.AutoIncrement = false;
				colvarAlergiasText.IsNullable = true;
				colvarAlergiasText.IsPrimaryKey = false;
				colvarAlergiasText.IsForeignKey = false;
				colvarAlergiasText.IsReadOnly = false;
				colvarAlergiasText.DefaultSetting = @"";
				colvarAlergiasText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlergiasText);
				
				TableSchema.TableColumn colvarAdicciones = new TableSchema.TableColumn(schema);
				colvarAdicciones.ColumnName = "adicciones";
				colvarAdicciones.DataType = DbType.Boolean;
				colvarAdicciones.MaxLength = 0;
				colvarAdicciones.AutoIncrement = false;
				colvarAdicciones.IsNullable = true;
				colvarAdicciones.IsPrimaryKey = false;
				colvarAdicciones.IsForeignKey = false;
				colvarAdicciones.IsReadOnly = false;
				colvarAdicciones.DefaultSetting = @"";
				colvarAdicciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdicciones);
				
				TableSchema.TableColumn colvarAdiccionesText = new TableSchema.TableColumn(schema);
				colvarAdiccionesText.ColumnName = "adiccionesText";
				colvarAdiccionesText.DataType = DbType.AnsiString;
				colvarAdiccionesText.MaxLength = -1;
				colvarAdiccionesText.AutoIncrement = false;
				colvarAdiccionesText.IsNullable = true;
				colvarAdiccionesText.IsPrimaryKey = false;
				colvarAdiccionesText.IsForeignKey = false;
				colvarAdiccionesText.IsReadOnly = false;
				colvarAdiccionesText.DefaultSetting = @"";
				colvarAdiccionesText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdiccionesText);
				
				TableSchema.TableColumn colvarConvulsiones = new TableSchema.TableColumn(schema);
				colvarConvulsiones.ColumnName = "convulsiones";
				colvarConvulsiones.DataType = DbType.Boolean;
				colvarConvulsiones.MaxLength = 0;
				colvarConvulsiones.AutoIncrement = false;
				colvarConvulsiones.IsNullable = true;
				colvarConvulsiones.IsPrimaryKey = false;
				colvarConvulsiones.IsForeignKey = false;
				colvarConvulsiones.IsReadOnly = false;
				colvarConvulsiones.DefaultSetting = @"";
				colvarConvulsiones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConvulsiones);
				
				TableSchema.TableColumn colvarConvulsionesText = new TableSchema.TableColumn(schema);
				colvarConvulsionesText.ColumnName = "convulsionesText";
				colvarConvulsionesText.DataType = DbType.AnsiString;
				colvarConvulsionesText.MaxLength = -1;
				colvarConvulsionesText.AutoIncrement = false;
				colvarConvulsionesText.IsNullable = true;
				colvarConvulsionesText.IsPrimaryKey = false;
				colvarConvulsionesText.IsForeignKey = false;
				colvarConvulsionesText.IsReadOnly = false;
				colvarConvulsionesText.DefaultSetting = @"";
				colvarConvulsionesText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConvulsionesText);
				
				TableSchema.TableColumn colvarEpoc = new TableSchema.TableColumn(schema);
				colvarEpoc.ColumnName = "epoc";
				colvarEpoc.DataType = DbType.Boolean;
				colvarEpoc.MaxLength = 0;
				colvarEpoc.AutoIncrement = false;
				colvarEpoc.IsNullable = true;
				colvarEpoc.IsPrimaryKey = false;
				colvarEpoc.IsForeignKey = false;
				colvarEpoc.IsReadOnly = false;
				colvarEpoc.DefaultSetting = @"";
				colvarEpoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEpoc);
				
				TableSchema.TableColumn colvarEpocText = new TableSchema.TableColumn(schema);
				colvarEpocText.ColumnName = "epocText";
				colvarEpocText.DataType = DbType.AnsiString;
				colvarEpocText.MaxLength = -1;
				colvarEpocText.AutoIncrement = false;
				colvarEpocText.IsNullable = true;
				colvarEpocText.IsPrimaryKey = false;
				colvarEpocText.IsForeignKey = false;
				colvarEpocText.IsReadOnly = false;
				colvarEpocText.DefaultSetting = @"";
				colvarEpocText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEpocText);
				
				TableSchema.TableColumn colvarCardiopatia = new TableSchema.TableColumn(schema);
				colvarCardiopatia.ColumnName = "cardiopatia";
				colvarCardiopatia.DataType = DbType.Boolean;
				colvarCardiopatia.MaxLength = 0;
				colvarCardiopatia.AutoIncrement = false;
				colvarCardiopatia.IsNullable = true;
				colvarCardiopatia.IsPrimaryKey = false;
				colvarCardiopatia.IsForeignKey = false;
				colvarCardiopatia.IsReadOnly = false;
				colvarCardiopatia.DefaultSetting = @"";
				colvarCardiopatia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardiopatia);
				
				TableSchema.TableColumn colvarCardiopatiaText = new TableSchema.TableColumn(schema);
				colvarCardiopatiaText.ColumnName = "cardiopatiaText";
				colvarCardiopatiaText.DataType = DbType.AnsiString;
				colvarCardiopatiaText.MaxLength = -1;
				colvarCardiopatiaText.AutoIncrement = false;
				colvarCardiopatiaText.IsNullable = true;
				colvarCardiopatiaText.IsPrimaryKey = false;
				colvarCardiopatiaText.IsForeignKey = false;
				colvarCardiopatiaText.IsReadOnly = false;
				colvarCardiopatiaText.DefaultSetting = @"";
				colvarCardiopatiaText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardiopatiaText);
				
				TableSchema.TableColumn colvarNeoplasias = new TableSchema.TableColumn(schema);
				colvarNeoplasias.ColumnName = "neoplasias";
				colvarNeoplasias.DataType = DbType.Boolean;
				colvarNeoplasias.MaxLength = 0;
				colvarNeoplasias.AutoIncrement = false;
				colvarNeoplasias.IsNullable = true;
				colvarNeoplasias.IsPrimaryKey = false;
				colvarNeoplasias.IsForeignKey = false;
				colvarNeoplasias.IsReadOnly = false;
				colvarNeoplasias.DefaultSetting = @"";
				colvarNeoplasias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeoplasias);
				
				TableSchema.TableColumn colvarNeoplasiasText = new TableSchema.TableColumn(schema);
				colvarNeoplasiasText.ColumnName = "neoplasiasText";
				colvarNeoplasiasText.DataType = DbType.AnsiString;
				colvarNeoplasiasText.MaxLength = -1;
				colvarNeoplasiasText.AutoIncrement = false;
				colvarNeoplasiasText.IsNullable = true;
				colvarNeoplasiasText.IsPrimaryKey = false;
				colvarNeoplasiasText.IsForeignKey = false;
				colvarNeoplasiasText.IsReadOnly = false;
				colvarNeoplasiasText.DefaultSetting = @"";
				colvarNeoplasiasText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeoplasiasText);
				
				TableSchema.TableColumn colvarTraumatismos = new TableSchema.TableColumn(schema);
				colvarTraumatismos.ColumnName = "traumatismos";
				colvarTraumatismos.DataType = DbType.Boolean;
				colvarTraumatismos.MaxLength = 0;
				colvarTraumatismos.AutoIncrement = false;
				colvarTraumatismos.IsNullable = true;
				colvarTraumatismos.IsPrimaryKey = false;
				colvarTraumatismos.IsForeignKey = false;
				colvarTraumatismos.IsReadOnly = false;
				colvarTraumatismos.DefaultSetting = @"";
				colvarTraumatismos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTraumatismos);
				
				TableSchema.TableColumn colvarTraumatismosText = new TableSchema.TableColumn(schema);
				colvarTraumatismosText.ColumnName = "traumatismosText";
				colvarTraumatismosText.DataType = DbType.AnsiString;
				colvarTraumatismosText.MaxLength = -1;
				colvarTraumatismosText.AutoIncrement = false;
				colvarTraumatismosText.IsNullable = true;
				colvarTraumatismosText.IsPrimaryKey = false;
				colvarTraumatismosText.IsForeignKey = false;
				colvarTraumatismosText.IsReadOnly = false;
				colvarTraumatismosText.DefaultSetting = @"";
				colvarTraumatismosText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTraumatismosText);
				
				TableSchema.TableColumn colvarVacunas = new TableSchema.TableColumn(schema);
				colvarVacunas.ColumnName = "vacunas";
				colvarVacunas.DataType = DbType.Boolean;
				colvarVacunas.MaxLength = 0;
				colvarVacunas.AutoIncrement = false;
				colvarVacunas.IsNullable = true;
				colvarVacunas.IsPrimaryKey = false;
				colvarVacunas.IsForeignKey = false;
				colvarVacunas.IsReadOnly = false;
				colvarVacunas.DefaultSetting = @"";
				colvarVacunas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunas);
				
				TableSchema.TableColumn colvarVacunasText = new TableSchema.TableColumn(schema);
				colvarVacunasText.ColumnName = "vacunasText";
				colvarVacunasText.DataType = DbType.AnsiString;
				colvarVacunasText.MaxLength = -1;
				colvarVacunasText.AutoIncrement = false;
				colvarVacunasText.IsNullable = true;
				colvarVacunasText.IsPrimaryKey = false;
				colvarVacunasText.IsForeignKey = false;
				colvarVacunasText.IsReadOnly = false;
				colvarVacunasText.DefaultSetting = @"";
				colvarVacunasText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunasText);
				
				TableSchema.TableColumn colvarEndocrinologia = new TableSchema.TableColumn(schema);
				colvarEndocrinologia.ColumnName = "endocrinologia";
				colvarEndocrinologia.DataType = DbType.Boolean;
				colvarEndocrinologia.MaxLength = 0;
				colvarEndocrinologia.AutoIncrement = false;
				colvarEndocrinologia.IsNullable = true;
				colvarEndocrinologia.IsPrimaryKey = false;
				colvarEndocrinologia.IsForeignKey = false;
				colvarEndocrinologia.IsReadOnly = false;
				colvarEndocrinologia.DefaultSetting = @"";
				colvarEndocrinologia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndocrinologia);
				
				TableSchema.TableColumn colvarEndocrinologiaText = new TableSchema.TableColumn(schema);
				colvarEndocrinologiaText.ColumnName = "endocrinologiaText";
				colvarEndocrinologiaText.DataType = DbType.AnsiString;
				colvarEndocrinologiaText.MaxLength = -1;
				colvarEndocrinologiaText.AutoIncrement = false;
				colvarEndocrinologiaText.IsNullable = true;
				colvarEndocrinologiaText.IsPrimaryKey = false;
				colvarEndocrinologiaText.IsForeignKey = false;
				colvarEndocrinologiaText.IsReadOnly = false;
				colvarEndocrinologiaText.DefaultSetting = @"";
				colvarEndocrinologiaText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndocrinologiaText);
				
				TableSchema.TableColumn colvarRespiratorios = new TableSchema.TableColumn(schema);
				colvarRespiratorios.ColumnName = "respiratorios";
				colvarRespiratorios.DataType = DbType.Boolean;
				colvarRespiratorios.MaxLength = 0;
				colvarRespiratorios.AutoIncrement = false;
				colvarRespiratorios.IsNullable = true;
				colvarRespiratorios.IsPrimaryKey = false;
				colvarRespiratorios.IsForeignKey = false;
				colvarRespiratorios.IsReadOnly = false;
				colvarRespiratorios.DefaultSetting = @"";
				colvarRespiratorios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRespiratorios);
				
				TableSchema.TableColumn colvarRespiratoriosText = new TableSchema.TableColumn(schema);
				colvarRespiratoriosText.ColumnName = "respiratoriosText";
				colvarRespiratoriosText.DataType = DbType.AnsiString;
				colvarRespiratoriosText.MaxLength = -1;
				colvarRespiratoriosText.AutoIncrement = false;
				colvarRespiratoriosText.IsNullable = true;
				colvarRespiratoriosText.IsPrimaryKey = false;
				colvarRespiratoriosText.IsForeignKey = false;
				colvarRespiratoriosText.IsReadOnly = false;
				colvarRespiratoriosText.DefaultSetting = @"";
				colvarRespiratoriosText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRespiratoriosText);
				
				TableSchema.TableColumn colvarInmunodeficiencia = new TableSchema.TableColumn(schema);
				colvarInmunodeficiencia.ColumnName = "inmunodeficiencia";
				colvarInmunodeficiencia.DataType = DbType.Boolean;
				colvarInmunodeficiencia.MaxLength = 0;
				colvarInmunodeficiencia.AutoIncrement = false;
				colvarInmunodeficiencia.IsNullable = true;
				colvarInmunodeficiencia.IsPrimaryKey = false;
				colvarInmunodeficiencia.IsForeignKey = false;
				colvarInmunodeficiencia.IsReadOnly = false;
				colvarInmunodeficiencia.DefaultSetting = @"";
				colvarInmunodeficiencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInmunodeficiencia);
				
				TableSchema.TableColumn colvarInmunodeficienciaText = new TableSchema.TableColumn(schema);
				colvarInmunodeficienciaText.ColumnName = "inmunodeficienciaText";
				colvarInmunodeficienciaText.DataType = DbType.AnsiString;
				colvarInmunodeficienciaText.MaxLength = -1;
				colvarInmunodeficienciaText.AutoIncrement = false;
				colvarInmunodeficienciaText.IsNullable = true;
				colvarInmunodeficienciaText.IsPrimaryKey = false;
				colvarInmunodeficienciaText.IsForeignKey = false;
				colvarInmunodeficienciaText.IsReadOnly = false;
				colvarInmunodeficienciaText.DefaultSetting = @"";
				colvarInmunodeficienciaText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInmunodeficienciaText);
				
				TableSchema.TableColumn colvarRetrasoMaduativo = new TableSchema.TableColumn(schema);
				colvarRetrasoMaduativo.ColumnName = "retrasoMaduativo";
				colvarRetrasoMaduativo.DataType = DbType.Boolean;
				colvarRetrasoMaduativo.MaxLength = 0;
				colvarRetrasoMaduativo.AutoIncrement = false;
				colvarRetrasoMaduativo.IsNullable = true;
				colvarRetrasoMaduativo.IsPrimaryKey = false;
				colvarRetrasoMaduativo.IsForeignKey = false;
				colvarRetrasoMaduativo.IsReadOnly = false;
				colvarRetrasoMaduativo.DefaultSetting = @"";
				colvarRetrasoMaduativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRetrasoMaduativo);
				
				TableSchema.TableColumn colvarRetrasoMadurativoText = new TableSchema.TableColumn(schema);
				colvarRetrasoMadurativoText.ColumnName = "retrasoMadurativoText";
				colvarRetrasoMadurativoText.DataType = DbType.AnsiString;
				colvarRetrasoMadurativoText.MaxLength = -1;
				colvarRetrasoMadurativoText.AutoIncrement = false;
				colvarRetrasoMadurativoText.IsNullable = true;
				colvarRetrasoMadurativoText.IsPrimaryKey = false;
				colvarRetrasoMadurativoText.IsForeignKey = false;
				colvarRetrasoMadurativoText.IsReadOnly = false;
				colvarRetrasoMadurativoText.DefaultSetting = @"";
				colvarRetrasoMadurativoText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRetrasoMadurativoText);
				
				TableSchema.TableColumn colvarMalformaciones = new TableSchema.TableColumn(schema);
				colvarMalformaciones.ColumnName = "malformaciones";
				colvarMalformaciones.DataType = DbType.Boolean;
				colvarMalformaciones.MaxLength = 0;
				colvarMalformaciones.AutoIncrement = false;
				colvarMalformaciones.IsNullable = true;
				colvarMalformaciones.IsPrimaryKey = false;
				colvarMalformaciones.IsForeignKey = false;
				colvarMalformaciones.IsReadOnly = false;
				colvarMalformaciones.DefaultSetting = @"";
				colvarMalformaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMalformaciones);
				
				TableSchema.TableColumn colvarMalformacionesText = new TableSchema.TableColumn(schema);
				colvarMalformacionesText.ColumnName = "malformacionesText";
				colvarMalformacionesText.DataType = DbType.AnsiString;
				colvarMalformacionesText.MaxLength = -1;
				colvarMalformacionesText.AutoIncrement = false;
				colvarMalformacionesText.IsNullable = true;
				colvarMalformacionesText.IsPrimaryKey = false;
				colvarMalformacionesText.IsForeignKey = false;
				colvarMalformacionesText.IsReadOnly = false;
				colvarMalformacionesText.DefaultSetting = @"";
				colvarMalformacionesText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMalformacionesText);
				
				TableSchema.TableColumn colvarAlteracionesSistemaNervioso = new TableSchema.TableColumn(schema);
				colvarAlteracionesSistemaNervioso.ColumnName = "alteracionesSistemaNervioso";
				colvarAlteracionesSistemaNervioso.DataType = DbType.Boolean;
				colvarAlteracionesSistemaNervioso.MaxLength = 0;
				colvarAlteracionesSistemaNervioso.AutoIncrement = false;
				colvarAlteracionesSistemaNervioso.IsNullable = true;
				colvarAlteracionesSistemaNervioso.IsPrimaryKey = false;
				colvarAlteracionesSistemaNervioso.IsForeignKey = false;
				colvarAlteracionesSistemaNervioso.IsReadOnly = false;
				colvarAlteracionesSistemaNervioso.DefaultSetting = @"";
				colvarAlteracionesSistemaNervioso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlteracionesSistemaNervioso);
				
				TableSchema.TableColumn colvarAlteracionesSistemaNerviosoText = new TableSchema.TableColumn(schema);
				colvarAlteracionesSistemaNerviosoText.ColumnName = "alteracionesSistemaNerviosoText";
				colvarAlteracionesSistemaNerviosoText.DataType = DbType.AnsiString;
				colvarAlteracionesSistemaNerviosoText.MaxLength = -1;
				colvarAlteracionesSistemaNerviosoText.AutoIncrement = false;
				colvarAlteracionesSistemaNerviosoText.IsNullable = true;
				colvarAlteracionesSistemaNerviosoText.IsPrimaryKey = false;
				colvarAlteracionesSistemaNerviosoText.IsForeignKey = false;
				colvarAlteracionesSistemaNerviosoText.IsReadOnly = false;
				colvarAlteracionesSistemaNerviosoText.DefaultSetting = @"";
				colvarAlteracionesSistemaNerviosoText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlteracionesSistemaNerviosoText);
				
				TableSchema.TableColumn colvarOtras = new TableSchema.TableColumn(schema);
				colvarOtras.ColumnName = "otras";
				colvarOtras.DataType = DbType.Boolean;
				colvarOtras.MaxLength = 0;
				colvarOtras.AutoIncrement = false;
				colvarOtras.IsNullable = true;
				colvarOtras.IsPrimaryKey = false;
				colvarOtras.IsForeignKey = false;
				colvarOtras.IsReadOnly = false;
				colvarOtras.DefaultSetting = @"";
				colvarOtras.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtras);
				
				TableSchema.TableColumn colvarOtrasText = new TableSchema.TableColumn(schema);
				colvarOtrasText.ColumnName = "otrasText";
				colvarOtrasText.DataType = DbType.AnsiString;
				colvarOtrasText.MaxLength = -1;
				colvarOtrasText.AutoIncrement = false;
				colvarOtrasText.IsNullable = true;
				colvarOtrasText.IsPrimaryKey = false;
				colvarOtrasText.IsForeignKey = false;
				colvarOtrasText.IsReadOnly = false;
				colvarOtrasText.DefaultSetting = @"";
				colvarOtrasText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrasText);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Antecedentes",schema);
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
		  
		[XmlAttribute("Asma")]
		[Bindable(true)]
		public bool? Asma 
		{
			get { return GetColumnValue<bool?>(Columns.Asma); }
			set { SetColumnValue(Columns.Asma, value); }
		}
		  
		[XmlAttribute("AsmaText")]
		[Bindable(true)]
		public string AsmaText 
		{
			get { return GetColumnValue<string>(Columns.AsmaText); }
			set { SetColumnValue(Columns.AsmaText, value); }
		}
		  
		[XmlAttribute("Irc")]
		[Bindable(true)]
		public bool? Irc 
		{
			get { return GetColumnValue<bool?>(Columns.Irc); }
			set { SetColumnValue(Columns.Irc, value); }
		}
		  
		[XmlAttribute("IrcText")]
		[Bindable(true)]
		public string IrcText 
		{
			get { return GetColumnValue<string>(Columns.IrcText); }
			set { SetColumnValue(Columns.IrcText, value); }
		}
		  
		[XmlAttribute("Cirugias")]
		[Bindable(true)]
		public bool? Cirugias 
		{
			get { return GetColumnValue<bool?>(Columns.Cirugias); }
			set { SetColumnValue(Columns.Cirugias, value); }
		}
		  
		[XmlAttribute("CirugiasText")]
		[Bindable(true)]
		public string CirugiasText 
		{
			get { return GetColumnValue<string>(Columns.CirugiasText); }
			set { SetColumnValue(Columns.CirugiasText, value); }
		}
		  
		[XmlAttribute("Hta")]
		[Bindable(true)]
		public bool? Hta 
		{
			get { return GetColumnValue<bool?>(Columns.Hta); }
			set { SetColumnValue(Columns.Hta, value); }
		}
		  
		[XmlAttribute("HtaText")]
		[Bindable(true)]
		public string HtaText 
		{
			get { return GetColumnValue<string>(Columns.HtaText); }
			set { SetColumnValue(Columns.HtaText, value); }
		}
		  
		[XmlAttribute("Infectologicas")]
		[Bindable(true)]
		public bool? Infectologicas 
		{
			get { return GetColumnValue<bool?>(Columns.Infectologicas); }
			set { SetColumnValue(Columns.Infectologicas, value); }
		}
		  
		[XmlAttribute("InfectologicasText")]
		[Bindable(true)]
		public string InfectologicasText 
		{
			get { return GetColumnValue<string>(Columns.InfectologicasText); }
			set { SetColumnValue(Columns.InfectologicasText, value); }
		}
		  
		[XmlAttribute("Alergias")]
		[Bindable(true)]
		public bool? Alergias 
		{
			get { return GetColumnValue<bool?>(Columns.Alergias); }
			set { SetColumnValue(Columns.Alergias, value); }
		}
		  
		[XmlAttribute("AlergiasText")]
		[Bindable(true)]
		public string AlergiasText 
		{
			get { return GetColumnValue<string>(Columns.AlergiasText); }
			set { SetColumnValue(Columns.AlergiasText, value); }
		}
		  
		[XmlAttribute("Adicciones")]
		[Bindable(true)]
		public bool? Adicciones 
		{
			get { return GetColumnValue<bool?>(Columns.Adicciones); }
			set { SetColumnValue(Columns.Adicciones, value); }
		}
		  
		[XmlAttribute("AdiccionesText")]
		[Bindable(true)]
		public string AdiccionesText 
		{
			get { return GetColumnValue<string>(Columns.AdiccionesText); }
			set { SetColumnValue(Columns.AdiccionesText, value); }
		}
		  
		[XmlAttribute("Convulsiones")]
		[Bindable(true)]
		public bool? Convulsiones 
		{
			get { return GetColumnValue<bool?>(Columns.Convulsiones); }
			set { SetColumnValue(Columns.Convulsiones, value); }
		}
		  
		[XmlAttribute("ConvulsionesText")]
		[Bindable(true)]
		public string ConvulsionesText 
		{
			get { return GetColumnValue<string>(Columns.ConvulsionesText); }
			set { SetColumnValue(Columns.ConvulsionesText, value); }
		}
		  
		[XmlAttribute("Epoc")]
		[Bindable(true)]
		public bool? Epoc 
		{
			get { return GetColumnValue<bool?>(Columns.Epoc); }
			set { SetColumnValue(Columns.Epoc, value); }
		}
		  
		[XmlAttribute("EpocText")]
		[Bindable(true)]
		public string EpocText 
		{
			get { return GetColumnValue<string>(Columns.EpocText); }
			set { SetColumnValue(Columns.EpocText, value); }
		}
		  
		[XmlAttribute("Cardiopatia")]
		[Bindable(true)]
		public bool? Cardiopatia 
		{
			get { return GetColumnValue<bool?>(Columns.Cardiopatia); }
			set { SetColumnValue(Columns.Cardiopatia, value); }
		}
		  
		[XmlAttribute("CardiopatiaText")]
		[Bindable(true)]
		public string CardiopatiaText 
		{
			get { return GetColumnValue<string>(Columns.CardiopatiaText); }
			set { SetColumnValue(Columns.CardiopatiaText, value); }
		}
		  
		[XmlAttribute("Neoplasias")]
		[Bindable(true)]
		public bool? Neoplasias 
		{
			get { return GetColumnValue<bool?>(Columns.Neoplasias); }
			set { SetColumnValue(Columns.Neoplasias, value); }
		}
		  
		[XmlAttribute("NeoplasiasText")]
		[Bindable(true)]
		public string NeoplasiasText 
		{
			get { return GetColumnValue<string>(Columns.NeoplasiasText); }
			set { SetColumnValue(Columns.NeoplasiasText, value); }
		}
		  
		[XmlAttribute("Traumatismos")]
		[Bindable(true)]
		public bool? Traumatismos 
		{
			get { return GetColumnValue<bool?>(Columns.Traumatismos); }
			set { SetColumnValue(Columns.Traumatismos, value); }
		}
		  
		[XmlAttribute("TraumatismosText")]
		[Bindable(true)]
		public string TraumatismosText 
		{
			get { return GetColumnValue<string>(Columns.TraumatismosText); }
			set { SetColumnValue(Columns.TraumatismosText, value); }
		}
		  
		[XmlAttribute("Vacunas")]
		[Bindable(true)]
		public bool? Vacunas 
		{
			get { return GetColumnValue<bool?>(Columns.Vacunas); }
			set { SetColumnValue(Columns.Vacunas, value); }
		}
		  
		[XmlAttribute("VacunasText")]
		[Bindable(true)]
		public string VacunasText 
		{
			get { return GetColumnValue<string>(Columns.VacunasText); }
			set { SetColumnValue(Columns.VacunasText, value); }
		}
		  
		[XmlAttribute("Endocrinologia")]
		[Bindable(true)]
		public bool? Endocrinologia 
		{
			get { return GetColumnValue<bool?>(Columns.Endocrinologia); }
			set { SetColumnValue(Columns.Endocrinologia, value); }
		}
		  
		[XmlAttribute("EndocrinologiaText")]
		[Bindable(true)]
		public string EndocrinologiaText 
		{
			get { return GetColumnValue<string>(Columns.EndocrinologiaText); }
			set { SetColumnValue(Columns.EndocrinologiaText, value); }
		}
		  
		[XmlAttribute("Respiratorios")]
		[Bindable(true)]
		public bool? Respiratorios 
		{
			get { return GetColumnValue<bool?>(Columns.Respiratorios); }
			set { SetColumnValue(Columns.Respiratorios, value); }
		}
		  
		[XmlAttribute("RespiratoriosText")]
		[Bindable(true)]
		public string RespiratoriosText 
		{
			get { return GetColumnValue<string>(Columns.RespiratoriosText); }
			set { SetColumnValue(Columns.RespiratoriosText, value); }
		}
		  
		[XmlAttribute("Inmunodeficiencia")]
		[Bindable(true)]
		public bool? Inmunodeficiencia 
		{
			get { return GetColumnValue<bool?>(Columns.Inmunodeficiencia); }
			set { SetColumnValue(Columns.Inmunodeficiencia, value); }
		}
		  
		[XmlAttribute("InmunodeficienciaText")]
		[Bindable(true)]
		public string InmunodeficienciaText 
		{
			get { return GetColumnValue<string>(Columns.InmunodeficienciaText); }
			set { SetColumnValue(Columns.InmunodeficienciaText, value); }
		}
		  
		[XmlAttribute("RetrasoMaduativo")]
		[Bindable(true)]
		public bool? RetrasoMaduativo 
		{
			get { return GetColumnValue<bool?>(Columns.RetrasoMaduativo); }
			set { SetColumnValue(Columns.RetrasoMaduativo, value); }
		}
		  
		[XmlAttribute("RetrasoMadurativoText")]
		[Bindable(true)]
		public string RetrasoMadurativoText 
		{
			get { return GetColumnValue<string>(Columns.RetrasoMadurativoText); }
			set { SetColumnValue(Columns.RetrasoMadurativoText, value); }
		}
		  
		[XmlAttribute("Malformaciones")]
		[Bindable(true)]
		public bool? Malformaciones 
		{
			get { return GetColumnValue<bool?>(Columns.Malformaciones); }
			set { SetColumnValue(Columns.Malformaciones, value); }
		}
		  
		[XmlAttribute("MalformacionesText")]
		[Bindable(true)]
		public string MalformacionesText 
		{
			get { return GetColumnValue<string>(Columns.MalformacionesText); }
			set { SetColumnValue(Columns.MalformacionesText, value); }
		}
		  
		[XmlAttribute("AlteracionesSistemaNervioso")]
		[Bindable(true)]
		public bool? AlteracionesSistemaNervioso 
		{
			get { return GetColumnValue<bool?>(Columns.AlteracionesSistemaNervioso); }
			set { SetColumnValue(Columns.AlteracionesSistemaNervioso, value); }
		}
		  
		[XmlAttribute("AlteracionesSistemaNerviosoText")]
		[Bindable(true)]
		public string AlteracionesSistemaNerviosoText 
		{
			get { return GetColumnValue<string>(Columns.AlteracionesSistemaNerviosoText); }
			set { SetColumnValue(Columns.AlteracionesSistemaNerviosoText, value); }
		}
		  
		[XmlAttribute("Otras")]
		[Bindable(true)]
		public bool? Otras 
		{
			get { return GetColumnValue<bool?>(Columns.Otras); }
			set { SetColumnValue(Columns.Otras, value); }
		}
		  
		[XmlAttribute("OtrasText")]
		[Bindable(true)]
		public string OtrasText 
		{
			get { return GetColumnValue<string>(Columns.OtrasText); }
			set { SetColumnValue(Columns.OtrasText, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varId,bool? varAsma,string varAsmaText,bool? varIrc,string varIrcText,bool? varCirugias,string varCirugiasText,bool? varHta,string varHtaText,bool? varInfectologicas,string varInfectologicasText,bool? varAlergias,string varAlergiasText,bool? varAdicciones,string varAdiccionesText,bool? varConvulsiones,string varConvulsionesText,bool? varEpoc,string varEpocText,bool? varCardiopatia,string varCardiopatiaText,bool? varNeoplasias,string varNeoplasiasText,bool? varTraumatismos,string varTraumatismosText,bool? varVacunas,string varVacunasText,bool? varEndocrinologia,string varEndocrinologiaText,bool? varRespiratorios,string varRespiratoriosText,bool? varInmunodeficiencia,string varInmunodeficienciaText,bool? varRetrasoMaduativo,string varRetrasoMadurativoText,bool? varMalformaciones,string varMalformacionesText,bool? varAlteracionesSistemaNervioso,string varAlteracionesSistemaNerviosoText,bool? varOtras,string varOtrasText)
		{
			GuardiaAntecedente item = new GuardiaAntecedente();
			
			item.Id = varId;
			
			item.Asma = varAsma;
			
			item.AsmaText = varAsmaText;
			
			item.Irc = varIrc;
			
			item.IrcText = varIrcText;
			
			item.Cirugias = varCirugias;
			
			item.CirugiasText = varCirugiasText;
			
			item.Hta = varHta;
			
			item.HtaText = varHtaText;
			
			item.Infectologicas = varInfectologicas;
			
			item.InfectologicasText = varInfectologicasText;
			
			item.Alergias = varAlergias;
			
			item.AlergiasText = varAlergiasText;
			
			item.Adicciones = varAdicciones;
			
			item.AdiccionesText = varAdiccionesText;
			
			item.Convulsiones = varConvulsiones;
			
			item.ConvulsionesText = varConvulsionesText;
			
			item.Epoc = varEpoc;
			
			item.EpocText = varEpocText;
			
			item.Cardiopatia = varCardiopatia;
			
			item.CardiopatiaText = varCardiopatiaText;
			
			item.Neoplasias = varNeoplasias;
			
			item.NeoplasiasText = varNeoplasiasText;
			
			item.Traumatismos = varTraumatismos;
			
			item.TraumatismosText = varTraumatismosText;
			
			item.Vacunas = varVacunas;
			
			item.VacunasText = varVacunasText;
			
			item.Endocrinologia = varEndocrinologia;
			
			item.EndocrinologiaText = varEndocrinologiaText;
			
			item.Respiratorios = varRespiratorios;
			
			item.RespiratoriosText = varRespiratoriosText;
			
			item.Inmunodeficiencia = varInmunodeficiencia;
			
			item.InmunodeficienciaText = varInmunodeficienciaText;
			
			item.RetrasoMaduativo = varRetrasoMaduativo;
			
			item.RetrasoMadurativoText = varRetrasoMadurativoText;
			
			item.Malformaciones = varMalformaciones;
			
			item.MalformacionesText = varMalformacionesText;
			
			item.AlteracionesSistemaNervioso = varAlteracionesSistemaNervioso;
			
			item.AlteracionesSistemaNerviosoText = varAlteracionesSistemaNerviosoText;
			
			item.Otras = varOtras;
			
			item.OtrasText = varOtrasText;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,bool? varAsma,string varAsmaText,bool? varIrc,string varIrcText,bool? varCirugias,string varCirugiasText,bool? varHta,string varHtaText,bool? varInfectologicas,string varInfectologicasText,bool? varAlergias,string varAlergiasText,bool? varAdicciones,string varAdiccionesText,bool? varConvulsiones,string varConvulsionesText,bool? varEpoc,string varEpocText,bool? varCardiopatia,string varCardiopatiaText,bool? varNeoplasias,string varNeoplasiasText,bool? varTraumatismos,string varTraumatismosText,bool? varVacunas,string varVacunasText,bool? varEndocrinologia,string varEndocrinologiaText,bool? varRespiratorios,string varRespiratoriosText,bool? varInmunodeficiencia,string varInmunodeficienciaText,bool? varRetrasoMaduativo,string varRetrasoMadurativoText,bool? varMalformaciones,string varMalformacionesText,bool? varAlteracionesSistemaNervioso,string varAlteracionesSistemaNerviosoText,bool? varOtras,string varOtrasText)
		{
			GuardiaAntecedente item = new GuardiaAntecedente();
			
				item.Id = varId;
			
				item.Asma = varAsma;
			
				item.AsmaText = varAsmaText;
			
				item.Irc = varIrc;
			
				item.IrcText = varIrcText;
			
				item.Cirugias = varCirugias;
			
				item.CirugiasText = varCirugiasText;
			
				item.Hta = varHta;
			
				item.HtaText = varHtaText;
			
				item.Infectologicas = varInfectologicas;
			
				item.InfectologicasText = varInfectologicasText;
			
				item.Alergias = varAlergias;
			
				item.AlergiasText = varAlergiasText;
			
				item.Adicciones = varAdicciones;
			
				item.AdiccionesText = varAdiccionesText;
			
				item.Convulsiones = varConvulsiones;
			
				item.ConvulsionesText = varConvulsionesText;
			
				item.Epoc = varEpoc;
			
				item.EpocText = varEpocText;
			
				item.Cardiopatia = varCardiopatia;
			
				item.CardiopatiaText = varCardiopatiaText;
			
				item.Neoplasias = varNeoplasias;
			
				item.NeoplasiasText = varNeoplasiasText;
			
				item.Traumatismos = varTraumatismos;
			
				item.TraumatismosText = varTraumatismosText;
			
				item.Vacunas = varVacunas;
			
				item.VacunasText = varVacunasText;
			
				item.Endocrinologia = varEndocrinologia;
			
				item.EndocrinologiaText = varEndocrinologiaText;
			
				item.Respiratorios = varRespiratorios;
			
				item.RespiratoriosText = varRespiratoriosText;
			
				item.Inmunodeficiencia = varInmunodeficiencia;
			
				item.InmunodeficienciaText = varInmunodeficienciaText;
			
				item.RetrasoMaduativo = varRetrasoMaduativo;
			
				item.RetrasoMadurativoText = varRetrasoMadurativoText;
			
				item.Malformaciones = varMalformaciones;
			
				item.MalformacionesText = varMalformacionesText;
			
				item.AlteracionesSistemaNervioso = varAlteracionesSistemaNervioso;
			
				item.AlteracionesSistemaNerviosoText = varAlteracionesSistemaNerviosoText;
			
				item.Otras = varOtras;
			
				item.OtrasText = varOtrasText;
			
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
        
        
        
        public static TableSchema.TableColumn AsmaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AsmaTextColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IrcColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IrcTextColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CirugiasColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CirugiasTextColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn HtaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn HtaTextColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn InfectologicasColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn InfectologicasTextColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AlergiasColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AlergiasTextColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn AdiccionesColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AdiccionesTextColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ConvulsionesColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ConvulsionesTextColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EpocColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn EpocTextColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CardiopatiaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CardiopatiaTextColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn NeoplasiasColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn NeoplasiasTextColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn TraumatismosColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn TraumatismosTextColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunasColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunasTextColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn EndocrinologiaColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn EndocrinologiaTextColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn RespiratoriosColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn RespiratoriosTextColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn InmunodeficienciaColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn InmunodeficienciaTextColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn RetrasoMaduativoColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn RetrasoMadurativoTextColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn MalformacionesColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn MalformacionesTextColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn AlteracionesSistemaNerviosoColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn AlteracionesSistemaNerviosoTextColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasTextColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Asma = @"asma";
			 public static string AsmaText = @"asmaText";
			 public static string Irc = @"irc";
			 public static string IrcText = @"ircText";
			 public static string Cirugias = @"cirugias";
			 public static string CirugiasText = @"cirugiasText";
			 public static string Hta = @"hta";
			 public static string HtaText = @"htaText";
			 public static string Infectologicas = @"infectologicas";
			 public static string InfectologicasText = @"infectologicasText";
			 public static string Alergias = @"alergias";
			 public static string AlergiasText = @"alergiasText";
			 public static string Adicciones = @"adicciones";
			 public static string AdiccionesText = @"adiccionesText";
			 public static string Convulsiones = @"convulsiones";
			 public static string ConvulsionesText = @"convulsionesText";
			 public static string Epoc = @"epoc";
			 public static string EpocText = @"epocText";
			 public static string Cardiopatia = @"cardiopatia";
			 public static string CardiopatiaText = @"cardiopatiaText";
			 public static string Neoplasias = @"neoplasias";
			 public static string NeoplasiasText = @"neoplasiasText";
			 public static string Traumatismos = @"traumatismos";
			 public static string TraumatismosText = @"traumatismosText";
			 public static string Vacunas = @"vacunas";
			 public static string VacunasText = @"vacunasText";
			 public static string Endocrinologia = @"endocrinologia";
			 public static string EndocrinologiaText = @"endocrinologiaText";
			 public static string Respiratorios = @"respiratorios";
			 public static string RespiratoriosText = @"respiratoriosText";
			 public static string Inmunodeficiencia = @"inmunodeficiencia";
			 public static string InmunodeficienciaText = @"inmunodeficienciaText";
			 public static string RetrasoMaduativo = @"retrasoMaduativo";
			 public static string RetrasoMadurativoText = @"retrasoMadurativoText";
			 public static string Malformaciones = @"malformaciones";
			 public static string MalformacionesText = @"malformacionesText";
			 public static string AlteracionesSistemaNervioso = @"alteracionesSistemaNervioso";
			 public static string AlteracionesSistemaNerviosoText = @"alteracionesSistemaNerviosoText";
			 public static string Otras = @"otras";
			 public static string OtrasText = @"otrasText";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
