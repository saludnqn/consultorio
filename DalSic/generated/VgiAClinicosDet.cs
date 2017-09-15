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
	/// Strongly-typed collection for the VgiAClinicosDet class.
	/// </summary>
    [Serializable]
	public partial class VgiAClinicosDetCollection : ActiveList<VgiAClinicosDet, VgiAClinicosDetCollection>
	{	   
		public VgiAClinicosDetCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>VgiAClinicosDetCollection</returns>
		public VgiAClinicosDetCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                VgiAClinicosDet o = this[i];
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
	/// This is an ActiveRecord class which wraps the VGI_AClinicosDet table.
	/// </summary>
	[Serializable]
	public partial class VgiAClinicosDet : ActiveRecord<VgiAClinicosDet>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public VgiAClinicosDet()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public VgiAClinicosDet(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public VgiAClinicosDet(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public VgiAClinicosDet(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("VGI_AClinicosDet", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdVGIDatos = new TableSchema.TableColumn(schema);
				colvarIdVGIDatos.ColumnName = "idVGIDatos";
				colvarIdVGIDatos.DataType = DbType.Int32;
				colvarIdVGIDatos.MaxLength = 0;
				colvarIdVGIDatos.AutoIncrement = false;
				colvarIdVGIDatos.IsNullable = false;
				colvarIdVGIDatos.IsPrimaryKey = false;
				colvarIdVGIDatos.IsForeignKey = false;
				colvarIdVGIDatos.IsReadOnly = false;
				colvarIdVGIDatos.DefaultSetting = @"";
				colvarIdVGIDatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVGIDatos);
				
				TableSchema.TableColumn colvarIdVGIAClinico = new TableSchema.TableColumn(schema);
				colvarIdVGIAClinico.ColumnName = "idVGIAClinico";
				colvarIdVGIAClinico.DataType = DbType.Decimal;
				colvarIdVGIAClinico.MaxLength = 0;
				colvarIdVGIAClinico.AutoIncrement = true;
				colvarIdVGIAClinico.IsNullable = false;
				colvarIdVGIAClinico.IsPrimaryKey = true;
				colvarIdVGIAClinico.IsForeignKey = false;
				colvarIdVGIAClinico.IsReadOnly = false;
				colvarIdVGIAClinico.DefaultSetting = @"";
				colvarIdVGIAClinico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVGIAClinico);
				
				TableSchema.TableColumn colvarTa = new TableSchema.TableColumn(schema);
				colvarTa.ColumnName = "TA";
				colvarTa.DataType = DbType.String;
				colvarTa.MaxLength = 50;
				colvarTa.AutoIncrement = false;
				colvarTa.IsNullable = true;
				colvarTa.IsPrimaryKey = false;
				colvarTa.IsForeignKey = false;
				colvarTa.IsReadOnly = false;
				colvarTa.DefaultSetting = @"";
				colvarTa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTa);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "Peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "Talla";
				colvarTalla.DataType = DbType.Decimal;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = true;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarImc = new TableSchema.TableColumn(schema);
				colvarImc.ColumnName = "IMC";
				colvarImc.DataType = DbType.Decimal;
				colvarImc.MaxLength = 0;
				colvarImc.AutoIncrement = false;
				colvarImc.IsNullable = true;
				colvarImc.IsPrimaryKey = false;
				colvarImc.IsForeignKey = false;
				colvarImc.IsReadOnly = false;
				colvarImc.DefaultSetting = @"";
				colvarImc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImc);
				
				TableSchema.TableColumn colvarHta = new TableSchema.TableColumn(schema);
				colvarHta.ColumnName = "HTA";
				colvarHta.DataType = DbType.String;
				colvarHta.MaxLength = 2;
				colvarHta.AutoIncrement = false;
				colvarHta.IsNullable = true;
				colvarHta.IsPrimaryKey = false;
				colvarHta.IsForeignKey = false;
				colvarHta.IsReadOnly = false;
				colvarHta.DefaultSetting = @"";
				colvarHta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHta);
				
				TableSchema.TableColumn colvarDbt = new TableSchema.TableColumn(schema);
				colvarDbt.ColumnName = "DBT";
				colvarDbt.DataType = DbType.String;
				colvarDbt.MaxLength = 2;
				colvarDbt.AutoIncrement = false;
				colvarDbt.IsNullable = true;
				colvarDbt.IsPrimaryKey = false;
				colvarDbt.IsForeignKey = false;
				colvarDbt.IsReadOnly = false;
				colvarDbt.DefaultSetting = @"";
				colvarDbt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbt);
				
				TableSchema.TableColumn colvarDislip = new TableSchema.TableColumn(schema);
				colvarDislip.ColumnName = "Dislip";
				colvarDislip.DataType = DbType.String;
				colvarDislip.MaxLength = 2;
				colvarDislip.AutoIncrement = false;
				colvarDislip.IsNullable = true;
				colvarDislip.IsPrimaryKey = false;
				colvarDislip.IsForeignKey = false;
				colvarDislip.IsReadOnly = false;
				colvarDislip.DefaultSetting = @"";
				colvarDislip.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDislip);
				
				TableSchema.TableColumn colvarIrc = new TableSchema.TableColumn(schema);
				colvarIrc.ColumnName = "IRC";
				colvarIrc.DataType = DbType.String;
				colvarIrc.MaxLength = 2;
				colvarIrc.AutoIncrement = false;
				colvarIrc.IsNullable = true;
				colvarIrc.IsPrimaryKey = false;
				colvarIrc.IsForeignKey = false;
				colvarIrc.IsReadOnly = false;
				colvarIrc.DefaultSetting = @"";
				colvarIrc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIrc);
				
				TableSchema.TableColumn colvarCardioIsq = new TableSchema.TableColumn(schema);
				colvarCardioIsq.ColumnName = "CardioIsq";
				colvarCardioIsq.DataType = DbType.String;
				colvarCardioIsq.MaxLength = 2;
				colvarCardioIsq.AutoIncrement = false;
				colvarCardioIsq.IsNullable = true;
				colvarCardioIsq.IsPrimaryKey = false;
				colvarCardioIsq.IsForeignKey = false;
				colvarCardioIsq.IsReadOnly = false;
				colvarCardioIsq.DefaultSetting = @"";
				colvarCardioIsq.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardioIsq);
				
				TableSchema.TableColumn colvarAcv = new TableSchema.TableColumn(schema);
				colvarAcv.ColumnName = "ACV";
				colvarAcv.DataType = DbType.String;
				colvarAcv.MaxLength = 2;
				colvarAcv.AutoIncrement = false;
				colvarAcv.IsNullable = true;
				colvarAcv.IsPrimaryKey = false;
				colvarAcv.IsForeignKey = false;
				colvarAcv.IsReadOnly = false;
				colvarAcv.DefaultSetting = @"";
				colvarAcv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcv);
				
				TableSchema.TableColumn colvarAmputacion = new TableSchema.TableColumn(schema);
				colvarAmputacion.ColumnName = "Amputacion";
				colvarAmputacion.DataType = DbType.String;
				colvarAmputacion.MaxLength = 2;
				colvarAmputacion.AutoIncrement = false;
				colvarAmputacion.IsNullable = true;
				colvarAmputacion.IsPrimaryKey = false;
				colvarAmputacion.IsForeignKey = false;
				colvarAmputacion.IsReadOnly = false;
				colvarAmputacion.DefaultSetting = @"";
				colvarAmputacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmputacion);
				
				TableSchema.TableColumn colvarTabaquismo = new TableSchema.TableColumn(schema);
				colvarTabaquismo.ColumnName = "Tabaquismo";
				colvarTabaquismo.DataType = DbType.String;
				colvarTabaquismo.MaxLength = 2;
				colvarTabaquismo.AutoIncrement = false;
				colvarTabaquismo.IsNullable = true;
				colvarTabaquismo.IsPrimaryKey = false;
				colvarTabaquismo.IsForeignKey = false;
				colvarTabaquismo.IsReadOnly = false;
				colvarTabaquismo.DefaultSetting = @"";
				colvarTabaquismo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTabaquismo);
				
				TableSchema.TableColumn colvarAlcoholismo = new TableSchema.TableColumn(schema);
				colvarAlcoholismo.ColumnName = "Alcoholismo";
				colvarAlcoholismo.DataType = DbType.String;
				colvarAlcoholismo.MaxLength = 2;
				colvarAlcoholismo.AutoIncrement = false;
				colvarAlcoholismo.IsNullable = true;
				colvarAlcoholismo.IsPrimaryKey = false;
				colvarAlcoholismo.IsForeignKey = false;
				colvarAlcoholismo.IsReadOnly = false;
				colvarAlcoholismo.DefaultSetting = @"";
				colvarAlcoholismo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcoholismo);
				
				TableSchema.TableColumn colvarParkinson = new TableSchema.TableColumn(schema);
				colvarParkinson.ColumnName = "Parkinson";
				colvarParkinson.DataType = DbType.String;
				colvarParkinson.MaxLength = 2;
				colvarParkinson.AutoIncrement = false;
				colvarParkinson.IsNullable = true;
				colvarParkinson.IsPrimaryKey = false;
				colvarParkinson.IsForeignKey = false;
				colvarParkinson.IsReadOnly = false;
				colvarParkinson.DefaultSetting = @"";
				colvarParkinson.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParkinson);
				
				TableSchema.TableColumn colvarDemencia = new TableSchema.TableColumn(schema);
				colvarDemencia.ColumnName = "Demencia";
				colvarDemencia.DataType = DbType.String;
				colvarDemencia.MaxLength = 2;
				colvarDemencia.AutoIncrement = false;
				colvarDemencia.IsNullable = true;
				colvarDemencia.IsPrimaryKey = false;
				colvarDemencia.IsForeignKey = false;
				colvarDemencia.IsReadOnly = false;
				colvarDemencia.DefaultSetting = @"";
				colvarDemencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDemencia);
				
				TableSchema.TableColumn colvarProstatismo = new TableSchema.TableColumn(schema);
				colvarProstatismo.ColumnName = "Prostatismo";
				colvarProstatismo.DataType = DbType.String;
				colvarProstatismo.MaxLength = 2;
				colvarProstatismo.AutoIncrement = false;
				colvarProstatismo.IsNullable = true;
				colvarProstatismo.IsPrimaryKey = false;
				colvarProstatismo.IsForeignKey = false;
				colvarProstatismo.IsReadOnly = false;
				colvarProstatismo.DefaultSetting = @"";
				colvarProstatismo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProstatismo);
				
				TableSchema.TableColumn colvarIncontinencia = new TableSchema.TableColumn(schema);
				colvarIncontinencia.ColumnName = "Incontinencia";
				colvarIncontinencia.DataType = DbType.String;
				colvarIncontinencia.MaxLength = 2;
				colvarIncontinencia.AutoIncrement = false;
				colvarIncontinencia.IsNullable = true;
				colvarIncontinencia.IsPrimaryKey = false;
				colvarIncontinencia.IsForeignKey = false;
				colvarIncontinencia.IsReadOnly = false;
				colvarIncontinencia.DefaultSetting = @"";
				colvarIncontinencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIncontinencia);
				
				TableSchema.TableColumn colvarNeuplasias = new TableSchema.TableColumn(schema);
				colvarNeuplasias.ColumnName = "Neuplasias";
				colvarNeuplasias.DataType = DbType.String;
				colvarNeuplasias.MaxLength = 100;
				colvarNeuplasias.AutoIncrement = false;
				colvarNeuplasias.IsNullable = true;
				colvarNeuplasias.IsPrimaryKey = false;
				colvarNeuplasias.IsForeignKey = false;
				colvarNeuplasias.IsReadOnly = false;
				colvarNeuplasias.DefaultSetting = @"";
				colvarNeuplasias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeuplasias);
				
				TableSchema.TableColumn colvarOtros = new TableSchema.TableColumn(schema);
				colvarOtros.ColumnName = "Otros";
				colvarOtros.DataType = DbType.String;
				colvarOtros.MaxLength = 100;
				colvarOtros.AutoIncrement = false;
				colvarOtros.IsNullable = true;
				colvarOtros.IsPrimaryKey = false;
				colvarOtros.IsForeignKey = false;
				colvarOtros.IsReadOnly = false;
				colvarOtros.DefaultSetting = @"";
				colvarOtros.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtros);
				
				TableSchema.TableColumn colvarRcvg = new TableSchema.TableColumn(schema);
				colvarRcvg.ColumnName = "RCVG";
				colvarRcvg.DataType = DbType.String;
				colvarRcvg.MaxLength = 10;
				colvarRcvg.AutoIncrement = false;
				colvarRcvg.IsNullable = true;
				colvarRcvg.IsPrimaryKey = false;
				colvarRcvg.IsForeignKey = false;
				colvarRcvg.IsReadOnly = false;
				colvarRcvg.DefaultSetting = @"";
				colvarRcvg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRcvg);
				
				TableSchema.TableColumn colvarVisionConducir = new TableSchema.TableColumn(schema);
				colvarVisionConducir.ColumnName = "VisionConducir";
				colvarVisionConducir.DataType = DbType.String;
				colvarVisionConducir.MaxLength = 2;
				colvarVisionConducir.AutoIncrement = false;
				colvarVisionConducir.IsNullable = true;
				colvarVisionConducir.IsPrimaryKey = false;
				colvarVisionConducir.IsForeignKey = false;
				colvarVisionConducir.IsReadOnly = false;
				colvarVisionConducir.DefaultSetting = @"";
				colvarVisionConducir.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVisionConducir);
				
				TableSchema.TableColumn colvarVacunacionDT = new TableSchema.TableColumn(schema);
				colvarVacunacionDT.ColumnName = "VacunacionDT";
				colvarVacunacionDT.DataType = DbType.String;
				colvarVacunacionDT.MaxLength = 2;
				colvarVacunacionDT.AutoIncrement = false;
				colvarVacunacionDT.IsNullable = true;
				colvarVacunacionDT.IsPrimaryKey = false;
				colvarVacunacionDT.IsForeignKey = false;
				colvarVacunacionDT.IsReadOnly = false;
				colvarVacunacionDT.DefaultSetting = @"";
				colvarVacunacionDT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunacionDT);
				
				TableSchema.TableColumn colvarVacunacionHepB = new TableSchema.TableColumn(schema);
				colvarVacunacionHepB.ColumnName = "VacunacionHepB";
				colvarVacunacionHepB.DataType = DbType.String;
				colvarVacunacionHepB.MaxLength = 2;
				colvarVacunacionHepB.AutoIncrement = false;
				colvarVacunacionHepB.IsNullable = true;
				colvarVacunacionHepB.IsPrimaryKey = false;
				colvarVacunacionHepB.IsForeignKey = false;
				colvarVacunacionHepB.IsReadOnly = false;
				colvarVacunacionHepB.DefaultSetting = @"";
				colvarVacunacionHepB.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunacionHepB);
				
				TableSchema.TableColumn colvarVacunacionGripe = new TableSchema.TableColumn(schema);
				colvarVacunacionGripe.ColumnName = "VacunacionGripe";
				colvarVacunacionGripe.DataType = DbType.String;
				colvarVacunacionGripe.MaxLength = 2;
				colvarVacunacionGripe.AutoIncrement = false;
				colvarVacunacionGripe.IsNullable = true;
				colvarVacunacionGripe.IsPrimaryKey = false;
				colvarVacunacionGripe.IsForeignKey = false;
				colvarVacunacionGripe.IsReadOnly = false;
				colvarVacunacionGripe.DefaultSetting = @"";
				colvarVacunacionGripe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunacionGripe);
				
				TableSchema.TableColumn colvarVacunacionNeumococo = new TableSchema.TableColumn(schema);
				colvarVacunacionNeumococo.ColumnName = "VacunacionNeumococo";
				colvarVacunacionNeumococo.DataType = DbType.String;
				colvarVacunacionNeumococo.MaxLength = 2;
				colvarVacunacionNeumococo.AutoIncrement = false;
				colvarVacunacionNeumococo.IsNullable = true;
				colvarVacunacionNeumococo.IsPrimaryKey = false;
				colvarVacunacionNeumococo.IsForeignKey = false;
				colvarVacunacionNeumococo.IsReadOnly = false;
				colvarVacunacionNeumococo.DefaultSetting = @"";
				colvarVacunacionNeumococo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunacionNeumococo);
				
				TableSchema.TableColumn colvarAudicionPSeguirConv = new TableSchema.TableColumn(schema);
				colvarAudicionPSeguirConv.ColumnName = "AudicionPSeguirConv";
				colvarAudicionPSeguirConv.DataType = DbType.String;
				colvarAudicionPSeguirConv.MaxLength = 2;
				colvarAudicionPSeguirConv.AutoIncrement = false;
				colvarAudicionPSeguirConv.IsNullable = true;
				colvarAudicionPSeguirConv.IsPrimaryKey = false;
				colvarAudicionPSeguirConv.IsForeignKey = false;
				colvarAudicionPSeguirConv.IsReadOnly = false;
				colvarAudicionPSeguirConv.DefaultSetting = @"";
				colvarAudicionPSeguirConv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAudicionPSeguirConv);
				
				TableSchema.TableColumn colvarMedicacion1 = new TableSchema.TableColumn(schema);
				colvarMedicacion1.ColumnName = "Medicacion1";
				colvarMedicacion1.DataType = DbType.Int32;
				colvarMedicacion1.MaxLength = 0;
				colvarMedicacion1.AutoIncrement = false;
				colvarMedicacion1.IsNullable = true;
				colvarMedicacion1.IsPrimaryKey = false;
				colvarMedicacion1.IsForeignKey = false;
				colvarMedicacion1.IsReadOnly = false;
				colvarMedicacion1.DefaultSetting = @"";
				colvarMedicacion1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicacion1);
				
				TableSchema.TableColumn colvarMedicacion2 = new TableSchema.TableColumn(schema);
				colvarMedicacion2.ColumnName = "Medicacion2";
				colvarMedicacion2.DataType = DbType.Int32;
				colvarMedicacion2.MaxLength = 0;
				colvarMedicacion2.AutoIncrement = false;
				colvarMedicacion2.IsNullable = true;
				colvarMedicacion2.IsPrimaryKey = false;
				colvarMedicacion2.IsForeignKey = false;
				colvarMedicacion2.IsReadOnly = false;
				colvarMedicacion2.DefaultSetting = @"";
				colvarMedicacion2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicacion2);
				
				TableSchema.TableColumn colvarMedicacion3 = new TableSchema.TableColumn(schema);
				colvarMedicacion3.ColumnName = "Medicacion3";
				colvarMedicacion3.DataType = DbType.Int32;
				colvarMedicacion3.MaxLength = 0;
				colvarMedicacion3.AutoIncrement = false;
				colvarMedicacion3.IsNullable = true;
				colvarMedicacion3.IsPrimaryKey = false;
				colvarMedicacion3.IsForeignKey = false;
				colvarMedicacion3.IsReadOnly = false;
				colvarMedicacion3.DefaultSetting = @"";
				colvarMedicacion3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicacion3);
				
				TableSchema.TableColumn colvarMedicacion4 = new TableSchema.TableColumn(schema);
				colvarMedicacion4.ColumnName = "Medicacion4";
				colvarMedicacion4.DataType = DbType.Int32;
				colvarMedicacion4.MaxLength = 0;
				colvarMedicacion4.AutoIncrement = false;
				colvarMedicacion4.IsNullable = true;
				colvarMedicacion4.IsPrimaryKey = false;
				colvarMedicacion4.IsForeignKey = false;
				colvarMedicacion4.IsReadOnly = false;
				colvarMedicacion4.DefaultSetting = @"";
				colvarMedicacion4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicacion4);
				
				TableSchema.TableColumn colvarMedicacion5 = new TableSchema.TableColumn(schema);
				colvarMedicacion5.ColumnName = "Medicacion5";
				colvarMedicacion5.DataType = DbType.Int32;
				colvarMedicacion5.MaxLength = 0;
				colvarMedicacion5.AutoIncrement = false;
				colvarMedicacion5.IsNullable = true;
				colvarMedicacion5.IsPrimaryKey = false;
				colvarMedicacion5.IsForeignKey = false;
				colvarMedicacion5.IsReadOnly = false;
				colvarMedicacion5.DefaultSetting = @"";
				colvarMedicacion5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicacion5);
				
				TableSchema.TableColumn colvarCaidasFrecuentes = new TableSchema.TableColumn(schema);
				colvarCaidasFrecuentes.ColumnName = "CaidasFrecuentes";
				colvarCaidasFrecuentes.DataType = DbType.String;
				colvarCaidasFrecuentes.MaxLength = 2;
				colvarCaidasFrecuentes.AutoIncrement = false;
				colvarCaidasFrecuentes.IsNullable = true;
				colvarCaidasFrecuentes.IsPrimaryKey = false;
				colvarCaidasFrecuentes.IsForeignKey = false;
				colvarCaidasFrecuentes.IsReadOnly = false;
				colvarCaidasFrecuentes.DefaultSetting = @"";
				colvarCaidasFrecuentes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaidasFrecuentes);
				
				TableSchema.TableColumn colvarNeuplaciaDet = new TableSchema.TableColumn(schema);
				colvarNeuplaciaDet.ColumnName = "NeuplaciaDet";
				colvarNeuplaciaDet.DataType = DbType.String;
				colvarNeuplaciaDet.MaxLength = 100;
				colvarNeuplaciaDet.AutoIncrement = false;
				colvarNeuplaciaDet.IsNullable = true;
				colvarNeuplaciaDet.IsPrimaryKey = false;
				colvarNeuplaciaDet.IsForeignKey = false;
				colvarNeuplaciaDet.IsReadOnly = false;
				colvarNeuplaciaDet.DefaultSetting = @"";
				colvarNeuplaciaDet.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeuplaciaDet);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("VGI_AClinicosDet",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdVGIDatos")]
		[Bindable(true)]
		public int IdVGIDatos 
		{
			get { return GetColumnValue<int>(Columns.IdVGIDatos); }
			set { SetColumnValue(Columns.IdVGIDatos, value); }
		}
		  
		[XmlAttribute("IdVGIAClinico")]
		[Bindable(true)]
		public decimal IdVGIAClinico 
		{
			get { return GetColumnValue<decimal>(Columns.IdVGIAClinico); }
			set { SetColumnValue(Columns.IdVGIAClinico, value); }
		}
		  
		[XmlAttribute("Ta")]
		[Bindable(true)]
		public string Ta 
		{
			get { return GetColumnValue<string>(Columns.Ta); }
			set { SetColumnValue(Columns.Ta, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal? Peso 
		{
			get { return GetColumnValue<decimal?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public decimal? Talla 
		{
			get { return GetColumnValue<decimal?>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("Imc")]
		[Bindable(true)]
		public decimal? Imc 
		{
			get { return GetColumnValue<decimal?>(Columns.Imc); }
			set { SetColumnValue(Columns.Imc, value); }
		}
		  
		[XmlAttribute("Hta")]
		[Bindable(true)]
		public string Hta 
		{
			get { return GetColumnValue<string>(Columns.Hta); }
			set { SetColumnValue(Columns.Hta, value); }
		}
		  
		[XmlAttribute("Dbt")]
		[Bindable(true)]
		public string Dbt 
		{
			get { return GetColumnValue<string>(Columns.Dbt); }
			set { SetColumnValue(Columns.Dbt, value); }
		}
		  
		[XmlAttribute("Dislip")]
		[Bindable(true)]
		public string Dislip 
		{
			get { return GetColumnValue<string>(Columns.Dislip); }
			set { SetColumnValue(Columns.Dislip, value); }
		}
		  
		[XmlAttribute("Irc")]
		[Bindable(true)]
		public string Irc 
		{
			get { return GetColumnValue<string>(Columns.Irc); }
			set { SetColumnValue(Columns.Irc, value); }
		}
		  
		[XmlAttribute("CardioIsq")]
		[Bindable(true)]
		public string CardioIsq 
		{
			get { return GetColumnValue<string>(Columns.CardioIsq); }
			set { SetColumnValue(Columns.CardioIsq, value); }
		}
		  
		[XmlAttribute("Acv")]
		[Bindable(true)]
		public string Acv 
		{
			get { return GetColumnValue<string>(Columns.Acv); }
			set { SetColumnValue(Columns.Acv, value); }
		}
		  
		[XmlAttribute("Amputacion")]
		[Bindable(true)]
		public string Amputacion 
		{
			get { return GetColumnValue<string>(Columns.Amputacion); }
			set { SetColumnValue(Columns.Amputacion, value); }
		}
		  
		[XmlAttribute("Tabaquismo")]
		[Bindable(true)]
		public string Tabaquismo 
		{
			get { return GetColumnValue<string>(Columns.Tabaquismo); }
			set { SetColumnValue(Columns.Tabaquismo, value); }
		}
		  
		[XmlAttribute("Alcoholismo")]
		[Bindable(true)]
		public string Alcoholismo 
		{
			get { return GetColumnValue<string>(Columns.Alcoholismo); }
			set { SetColumnValue(Columns.Alcoholismo, value); }
		}
		  
		[XmlAttribute("Parkinson")]
		[Bindable(true)]
		public string Parkinson 
		{
			get { return GetColumnValue<string>(Columns.Parkinson); }
			set { SetColumnValue(Columns.Parkinson, value); }
		}
		  
		[XmlAttribute("Demencia")]
		[Bindable(true)]
		public string Demencia 
		{
			get { return GetColumnValue<string>(Columns.Demencia); }
			set { SetColumnValue(Columns.Demencia, value); }
		}
		  
		[XmlAttribute("Prostatismo")]
		[Bindable(true)]
		public string Prostatismo 
		{
			get { return GetColumnValue<string>(Columns.Prostatismo); }
			set { SetColumnValue(Columns.Prostatismo, value); }
		}
		  
		[XmlAttribute("Incontinencia")]
		[Bindable(true)]
		public string Incontinencia 
		{
			get { return GetColumnValue<string>(Columns.Incontinencia); }
			set { SetColumnValue(Columns.Incontinencia, value); }
		}
		  
		[XmlAttribute("Neuplasias")]
		[Bindable(true)]
		public string Neuplasias 
		{
			get { return GetColumnValue<string>(Columns.Neuplasias); }
			set { SetColumnValue(Columns.Neuplasias, value); }
		}
		  
		[XmlAttribute("Otros")]
		[Bindable(true)]
		public string Otros 
		{
			get { return GetColumnValue<string>(Columns.Otros); }
			set { SetColumnValue(Columns.Otros, value); }
		}
		  
		[XmlAttribute("Rcvg")]
		[Bindable(true)]
		public string Rcvg 
		{
			get { return GetColumnValue<string>(Columns.Rcvg); }
			set { SetColumnValue(Columns.Rcvg, value); }
		}
		  
		[XmlAttribute("VisionConducir")]
		[Bindable(true)]
		public string VisionConducir 
		{
			get { return GetColumnValue<string>(Columns.VisionConducir); }
			set { SetColumnValue(Columns.VisionConducir, value); }
		}
		  
		[XmlAttribute("VacunacionDT")]
		[Bindable(true)]
		public string VacunacionDT 
		{
			get { return GetColumnValue<string>(Columns.VacunacionDT); }
			set { SetColumnValue(Columns.VacunacionDT, value); }
		}
		  
		[XmlAttribute("VacunacionHepB")]
		[Bindable(true)]
		public string VacunacionHepB 
		{
			get { return GetColumnValue<string>(Columns.VacunacionHepB); }
			set { SetColumnValue(Columns.VacunacionHepB, value); }
		}
		  
		[XmlAttribute("VacunacionGripe")]
		[Bindable(true)]
		public string VacunacionGripe 
		{
			get { return GetColumnValue<string>(Columns.VacunacionGripe); }
			set { SetColumnValue(Columns.VacunacionGripe, value); }
		}
		  
		[XmlAttribute("VacunacionNeumococo")]
		[Bindable(true)]
		public string VacunacionNeumococo 
		{
			get { return GetColumnValue<string>(Columns.VacunacionNeumococo); }
			set { SetColumnValue(Columns.VacunacionNeumococo, value); }
		}
		  
		[XmlAttribute("AudicionPSeguirConv")]
		[Bindable(true)]
		public string AudicionPSeguirConv 
		{
			get { return GetColumnValue<string>(Columns.AudicionPSeguirConv); }
			set { SetColumnValue(Columns.AudicionPSeguirConv, value); }
		}
		  
		[XmlAttribute("Medicacion1")]
		[Bindable(true)]
		public int? Medicacion1 
		{
			get { return GetColumnValue<int?>(Columns.Medicacion1); }
			set { SetColumnValue(Columns.Medicacion1, value); }
		}
		  
		[XmlAttribute("Medicacion2")]
		[Bindable(true)]
		public int? Medicacion2 
		{
			get { return GetColumnValue<int?>(Columns.Medicacion2); }
			set { SetColumnValue(Columns.Medicacion2, value); }
		}
		  
		[XmlAttribute("Medicacion3")]
		[Bindable(true)]
		public int? Medicacion3 
		{
			get { return GetColumnValue<int?>(Columns.Medicacion3); }
			set { SetColumnValue(Columns.Medicacion3, value); }
		}
		  
		[XmlAttribute("Medicacion4")]
		[Bindable(true)]
		public int? Medicacion4 
		{
			get { return GetColumnValue<int?>(Columns.Medicacion4); }
			set { SetColumnValue(Columns.Medicacion4, value); }
		}
		  
		[XmlAttribute("Medicacion5")]
		[Bindable(true)]
		public int? Medicacion5 
		{
			get { return GetColumnValue<int?>(Columns.Medicacion5); }
			set { SetColumnValue(Columns.Medicacion5, value); }
		}
		  
		[XmlAttribute("CaidasFrecuentes")]
		[Bindable(true)]
		public string CaidasFrecuentes 
		{
			get { return GetColumnValue<string>(Columns.CaidasFrecuentes); }
			set { SetColumnValue(Columns.CaidasFrecuentes, value); }
		}
		  
		[XmlAttribute("NeuplaciaDet")]
		[Bindable(true)]
		public string NeuplaciaDet 
		{
			get { return GetColumnValue<string>(Columns.NeuplaciaDet); }
			set { SetColumnValue(Columns.NeuplaciaDet, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdVGIDatos,string varTa,decimal? varPeso,decimal? varTalla,decimal? varImc,string varHta,string varDbt,string varDislip,string varIrc,string varCardioIsq,string varAcv,string varAmputacion,string varTabaquismo,string varAlcoholismo,string varParkinson,string varDemencia,string varProstatismo,string varIncontinencia,string varNeuplasias,string varOtros,string varRcvg,string varVisionConducir,string varVacunacionDT,string varVacunacionHepB,string varVacunacionGripe,string varVacunacionNeumococo,string varAudicionPSeguirConv,int? varMedicacion1,int? varMedicacion2,int? varMedicacion3,int? varMedicacion4,int? varMedicacion5,string varCaidasFrecuentes,string varNeuplaciaDet)
		{
			VgiAClinicosDet item = new VgiAClinicosDet();
			
			item.IdVGIDatos = varIdVGIDatos;
			
			item.Ta = varTa;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.Imc = varImc;
			
			item.Hta = varHta;
			
			item.Dbt = varDbt;
			
			item.Dislip = varDislip;
			
			item.Irc = varIrc;
			
			item.CardioIsq = varCardioIsq;
			
			item.Acv = varAcv;
			
			item.Amputacion = varAmputacion;
			
			item.Tabaquismo = varTabaquismo;
			
			item.Alcoholismo = varAlcoholismo;
			
			item.Parkinson = varParkinson;
			
			item.Demencia = varDemencia;
			
			item.Prostatismo = varProstatismo;
			
			item.Incontinencia = varIncontinencia;
			
			item.Neuplasias = varNeuplasias;
			
			item.Otros = varOtros;
			
			item.Rcvg = varRcvg;
			
			item.VisionConducir = varVisionConducir;
			
			item.VacunacionDT = varVacunacionDT;
			
			item.VacunacionHepB = varVacunacionHepB;
			
			item.VacunacionGripe = varVacunacionGripe;
			
			item.VacunacionNeumococo = varVacunacionNeumococo;
			
			item.AudicionPSeguirConv = varAudicionPSeguirConv;
			
			item.Medicacion1 = varMedicacion1;
			
			item.Medicacion2 = varMedicacion2;
			
			item.Medicacion3 = varMedicacion3;
			
			item.Medicacion4 = varMedicacion4;
			
			item.Medicacion5 = varMedicacion5;
			
			item.CaidasFrecuentes = varCaidasFrecuentes;
			
			item.NeuplaciaDet = varNeuplaciaDet;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdVGIDatos,decimal varIdVGIAClinico,string varTa,decimal? varPeso,decimal? varTalla,decimal? varImc,string varHta,string varDbt,string varDislip,string varIrc,string varCardioIsq,string varAcv,string varAmputacion,string varTabaquismo,string varAlcoholismo,string varParkinson,string varDemencia,string varProstatismo,string varIncontinencia,string varNeuplasias,string varOtros,string varRcvg,string varVisionConducir,string varVacunacionDT,string varVacunacionHepB,string varVacunacionGripe,string varVacunacionNeumococo,string varAudicionPSeguirConv,int? varMedicacion1,int? varMedicacion2,int? varMedicacion3,int? varMedicacion4,int? varMedicacion5,string varCaidasFrecuentes,string varNeuplaciaDet)
		{
			VgiAClinicosDet item = new VgiAClinicosDet();
			
				item.IdVGIDatos = varIdVGIDatos;
			
				item.IdVGIAClinico = varIdVGIAClinico;
			
				item.Ta = varTa;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.Imc = varImc;
			
				item.Hta = varHta;
			
				item.Dbt = varDbt;
			
				item.Dislip = varDislip;
			
				item.Irc = varIrc;
			
				item.CardioIsq = varCardioIsq;
			
				item.Acv = varAcv;
			
				item.Amputacion = varAmputacion;
			
				item.Tabaquismo = varTabaquismo;
			
				item.Alcoholismo = varAlcoholismo;
			
				item.Parkinson = varParkinson;
			
				item.Demencia = varDemencia;
			
				item.Prostatismo = varProstatismo;
			
				item.Incontinencia = varIncontinencia;
			
				item.Neuplasias = varNeuplasias;
			
				item.Otros = varOtros;
			
				item.Rcvg = varRcvg;
			
				item.VisionConducir = varVisionConducir;
			
				item.VacunacionDT = varVacunacionDT;
			
				item.VacunacionHepB = varVacunacionHepB;
			
				item.VacunacionGripe = varVacunacionGripe;
			
				item.VacunacionNeumococo = varVacunacionNeumococo;
			
				item.AudicionPSeguirConv = varAudicionPSeguirConv;
			
				item.Medicacion1 = varMedicacion1;
			
				item.Medicacion2 = varMedicacion2;
			
				item.Medicacion3 = varMedicacion3;
			
				item.Medicacion4 = varMedicacion4;
			
				item.Medicacion5 = varMedicacion5;
			
				item.CaidasFrecuentes = varCaidasFrecuentes;
			
				item.NeuplaciaDet = varNeuplaciaDet;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdVGIDatosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVGIAClinicoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ImcColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn HtaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DbtColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DislipColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IrcColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CardioIsqColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AcvColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AmputacionColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn TabaquismoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AlcoholismoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ParkinsonColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn DemenciaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ProstatismoColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IncontinenciaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn NeuplasiasColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn RcvgColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn VisionConducirColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunacionDTColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunacionHepBColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunacionGripeColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunacionNeumococoColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn AudicionPSeguirConvColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn Medicacion1Column
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn Medicacion2Column
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn Medicacion3Column
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn Medicacion4Column
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn Medicacion5Column
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn CaidasFrecuentesColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn NeuplaciaDetColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdVGIDatos = @"idVGIDatos";
			 public static string IdVGIAClinico = @"idVGIAClinico";
			 public static string Ta = @"TA";
			 public static string Peso = @"Peso";
			 public static string Talla = @"Talla";
			 public static string Imc = @"IMC";
			 public static string Hta = @"HTA";
			 public static string Dbt = @"DBT";
			 public static string Dislip = @"Dislip";
			 public static string Irc = @"IRC";
			 public static string CardioIsq = @"CardioIsq";
			 public static string Acv = @"ACV";
			 public static string Amputacion = @"Amputacion";
			 public static string Tabaquismo = @"Tabaquismo";
			 public static string Alcoholismo = @"Alcoholismo";
			 public static string Parkinson = @"Parkinson";
			 public static string Demencia = @"Demencia";
			 public static string Prostatismo = @"Prostatismo";
			 public static string Incontinencia = @"Incontinencia";
			 public static string Neuplasias = @"Neuplasias";
			 public static string Otros = @"Otros";
			 public static string Rcvg = @"RCVG";
			 public static string VisionConducir = @"VisionConducir";
			 public static string VacunacionDT = @"VacunacionDT";
			 public static string VacunacionHepB = @"VacunacionHepB";
			 public static string VacunacionGripe = @"VacunacionGripe";
			 public static string VacunacionNeumococo = @"VacunacionNeumococo";
			 public static string AudicionPSeguirConv = @"AudicionPSeguirConv";
			 public static string Medicacion1 = @"Medicacion1";
			 public static string Medicacion2 = @"Medicacion2";
			 public static string Medicacion3 = @"Medicacion3";
			 public static string Medicacion4 = @"Medicacion4";
			 public static string Medicacion5 = @"Medicacion5";
			 public static string CaidasFrecuentes = @"CaidasFrecuentes";
			 public static string NeuplaciaDet = @"NeuplaciaDet";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
