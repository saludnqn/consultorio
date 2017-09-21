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
	/// Strongly-typed collection for the MamAntecedente class.
	/// </summary>
    [Serializable]
	public partial class MamAntecedenteCollection : ActiveList<MamAntecedente, MamAntecedenteCollection>
	{	   
		public MamAntecedenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamAntecedenteCollection</returns>
		public MamAntecedenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamAntecedente o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_Antecedentes table.
	/// </summary>
	[Serializable]
	public partial class MamAntecedente : ActiveRecord<MamAntecedente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamAntecedente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamAntecedente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamAntecedente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamAntecedente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_Antecedentes", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAntecedenteMamas = new TableSchema.TableColumn(schema);
				colvarIdAntecedenteMamas.ColumnName = "idAntecedenteMamas";
				colvarIdAntecedenteMamas.DataType = DbType.Int32;
				colvarIdAntecedenteMamas.MaxLength = 0;
				colvarIdAntecedenteMamas.AutoIncrement = true;
				colvarIdAntecedenteMamas.IsNullable = false;
				colvarIdAntecedenteMamas.IsPrimaryKey = true;
				colvarIdAntecedenteMamas.IsForeignKey = false;
				colvarIdAntecedenteMamas.IsReadOnly = false;
				colvarIdAntecedenteMamas.DefaultSetting = @"";
				colvarIdAntecedenteMamas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAntecedenteMamas);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((0))";
				
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
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = false;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				
						colvarEdad.DefaultSetting = @"((0))";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarIdMetodoAnticonceptivo = new TableSchema.TableColumn(schema);
				colvarIdMetodoAnticonceptivo.ColumnName = "idMetodoAnticonceptivo";
				colvarIdMetodoAnticonceptivo.DataType = DbType.Int32;
				colvarIdMetodoAnticonceptivo.MaxLength = 0;
				colvarIdMetodoAnticonceptivo.AutoIncrement = false;
				colvarIdMetodoAnticonceptivo.IsNullable = false;
				colvarIdMetodoAnticonceptivo.IsPrimaryKey = false;
				colvarIdMetodoAnticonceptivo.IsForeignKey = true;
				colvarIdMetodoAnticonceptivo.IsReadOnly = false;
				
						colvarIdMetodoAnticonceptivo.DefaultSetting = @"((0))";
				
					colvarIdMetodoAnticonceptivo.ForeignKeyTableName = "TAM_MetodoAnticonceptivo";
				schema.Columns.Add(colvarIdMetodoAnticonceptivo);
				
				TableSchema.TableColumn colvarEmbarazoActual = new TableSchema.TableColumn(schema);
				colvarEmbarazoActual.ColumnName = "embarazoActual";
				colvarEmbarazoActual.DataType = DbType.Int32;
				colvarEmbarazoActual.MaxLength = 0;
				colvarEmbarazoActual.AutoIncrement = false;
				colvarEmbarazoActual.IsNullable = false;
				colvarEmbarazoActual.IsPrimaryKey = false;
				colvarEmbarazoActual.IsForeignKey = false;
				colvarEmbarazoActual.IsReadOnly = false;
				
						colvarEmbarazoActual.DefaultSetting = @"((0))";
				colvarEmbarazoActual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoActual);
				
				TableSchema.TableColumn colvarCantidadPartos = new TableSchema.TableColumn(schema);
				colvarCantidadPartos.ColumnName = "cantidadPartos";
				colvarCantidadPartos.DataType = DbType.Int32;
				colvarCantidadPartos.MaxLength = 0;
				colvarCantidadPartos.AutoIncrement = false;
				colvarCantidadPartos.IsNullable = false;
				colvarCantidadPartos.IsPrimaryKey = false;
				colvarCantidadPartos.IsForeignKey = false;
				colvarCantidadPartos.IsReadOnly = false;
				
						colvarCantidadPartos.DefaultSetting = @"((0))";
				colvarCantidadPartos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadPartos);
				
				TableSchema.TableColumn colvarCantidadEmbarazos = new TableSchema.TableColumn(schema);
				colvarCantidadEmbarazos.ColumnName = "cantidadEmbarazos";
				colvarCantidadEmbarazos.DataType = DbType.Int32;
				colvarCantidadEmbarazos.MaxLength = 0;
				colvarCantidadEmbarazos.AutoIncrement = false;
				colvarCantidadEmbarazos.IsNullable = false;
				colvarCantidadEmbarazos.IsPrimaryKey = false;
				colvarCantidadEmbarazos.IsForeignKey = false;
				colvarCantidadEmbarazos.IsReadOnly = false;
				
						colvarCantidadEmbarazos.DefaultSetting = @"((0))";
				colvarCantidadEmbarazos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadEmbarazos);
				
				TableSchema.TableColumn colvarAntecLactancia = new TableSchema.TableColumn(schema);
				colvarAntecLactancia.ColumnName = "antecLactancia";
				colvarAntecLactancia.DataType = DbType.Int32;
				colvarAntecLactancia.MaxLength = 0;
				colvarAntecLactancia.AutoIncrement = false;
				colvarAntecLactancia.IsNullable = false;
				colvarAntecLactancia.IsPrimaryKey = false;
				colvarAntecLactancia.IsForeignKey = false;
				colvarAntecLactancia.IsReadOnly = false;
				
						colvarAntecLactancia.DefaultSetting = @"((0))";
				colvarAntecLactancia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecLactancia);
				
				TableSchema.TableColumn colvarAntecCancer = new TableSchema.TableColumn(schema);
				colvarAntecCancer.ColumnName = "antecCancer";
				colvarAntecCancer.DataType = DbType.Int32;
				colvarAntecCancer.MaxLength = 0;
				colvarAntecCancer.AutoIncrement = false;
				colvarAntecCancer.IsNullable = false;
				colvarAntecCancer.IsPrimaryKey = false;
				colvarAntecCancer.IsForeignKey = false;
				colvarAntecCancer.IsReadOnly = false;
				
						colvarAntecCancer.DefaultSetting = @"((0))";
				colvarAntecCancer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecCancer);
				
				TableSchema.TableColumn colvarAntecCancerCual = new TableSchema.TableColumn(schema);
				colvarAntecCancerCual.ColumnName = "antecCancerCual";
				colvarAntecCancerCual.DataType = DbType.AnsiString;
				colvarAntecCancerCual.MaxLength = 20;
				colvarAntecCancerCual.AutoIncrement = false;
				colvarAntecCancerCual.IsNullable = false;
				colvarAntecCancerCual.IsPrimaryKey = false;
				colvarAntecCancerCual.IsForeignKey = false;
				colvarAntecCancerCual.IsReadOnly = false;
				
						colvarAntecCancerCual.DefaultSetting = @"('')";
				colvarAntecCancerCual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecCancerCual);
				
				TableSchema.TableColumn colvarAntecCancerTipoParentezco = new TableSchema.TableColumn(schema);
				colvarAntecCancerTipoParentezco.ColumnName = "antecCancerTipoParentezco";
				colvarAntecCancerTipoParentezco.DataType = DbType.AnsiString;
				colvarAntecCancerTipoParentezco.MaxLength = 20;
				colvarAntecCancerTipoParentezco.AutoIncrement = false;
				colvarAntecCancerTipoParentezco.IsNullable = false;
				colvarAntecCancerTipoParentezco.IsPrimaryKey = false;
				colvarAntecCancerTipoParentezco.IsForeignKey = false;
				colvarAntecCancerTipoParentezco.IsReadOnly = false;
				
						colvarAntecCancerTipoParentezco.DefaultSetting = @"('')";
				colvarAntecCancerTipoParentezco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecCancerTipoParentezco);
				
				TableSchema.TableColumn colvarFechaFUM = new TableSchema.TableColumn(schema);
				colvarFechaFUM.ColumnName = "fechaFUM";
				colvarFechaFUM.DataType = DbType.DateTime;
				colvarFechaFUM.MaxLength = 0;
				colvarFechaFUM.AutoIncrement = false;
				colvarFechaFUM.IsNullable = false;
				colvarFechaFUM.IsPrimaryKey = false;
				colvarFechaFUM.IsForeignKey = false;
				colvarFechaFUM.IsReadOnly = false;
				colvarFechaFUM.DefaultSetting = @"";
				colvarFechaFUM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFUM);
				
				TableSchema.TableColumn colvarEdadFUM = new TableSchema.TableColumn(schema);
				colvarEdadFUM.ColumnName = "edadFUM";
				colvarEdadFUM.DataType = DbType.Int32;
				colvarEdadFUM.MaxLength = 0;
				colvarEdadFUM.AutoIncrement = false;
				colvarEdadFUM.IsNullable = false;
				colvarEdadFUM.IsPrimaryKey = false;
				colvarEdadFUM.IsForeignKey = false;
				colvarEdadFUM.IsReadOnly = false;
				
						colvarEdadFUM.DefaultSetting = @"((0))";
				colvarEdadFUM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadFUM);
				
				TableSchema.TableColumn colvarEdadPrimerEmb = new TableSchema.TableColumn(schema);
				colvarEdadPrimerEmb.ColumnName = "edadPrimerEmb";
				colvarEdadPrimerEmb.DataType = DbType.Int32;
				colvarEdadPrimerEmb.MaxLength = 0;
				colvarEdadPrimerEmb.AutoIncrement = false;
				colvarEdadPrimerEmb.IsNullable = false;
				colvarEdadPrimerEmb.IsPrimaryKey = false;
				colvarEdadPrimerEmb.IsForeignKey = false;
				colvarEdadPrimerEmb.IsReadOnly = false;
				
						colvarEdadPrimerEmb.DefaultSetting = @"((0))";
				colvarEdadPrimerEmb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdadPrimerEmb);
				
				TableSchema.TableColumn colvarMenopausia = new TableSchema.TableColumn(schema);
				colvarMenopausia.ColumnName = "menopausia";
				colvarMenopausia.DataType = DbType.Int32;
				colvarMenopausia.MaxLength = 0;
				colvarMenopausia.AutoIncrement = false;
				colvarMenopausia.IsNullable = false;
				colvarMenopausia.IsPrimaryKey = false;
				colvarMenopausia.IsForeignKey = false;
				colvarMenopausia.IsReadOnly = false;
				
						colvarMenopausia.DefaultSetting = @"((0))";
				colvarMenopausia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMenopausia);
				
				TableSchema.TableColumn colvarThr = new TableSchema.TableColumn(schema);
				colvarThr.ColumnName = "THR";
				colvarThr.DataType = DbType.Int32;
				colvarThr.MaxLength = 0;
				colvarThr.AutoIncrement = false;
				colvarThr.IsNullable = false;
				colvarThr.IsPrimaryKey = false;
				colvarThr.IsForeignKey = false;
				colvarThr.IsReadOnly = false;
				
						colvarThr.DefaultSetting = @"((0))";
				colvarThr.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThr);
				
				TableSchema.TableColumn colvarTiempoUso = new TableSchema.TableColumn(schema);
				colvarTiempoUso.ColumnName = "tiempoUso";
				colvarTiempoUso.DataType = DbType.AnsiString;
				colvarTiempoUso.MaxLength = 20;
				colvarTiempoUso.AutoIncrement = false;
				colvarTiempoUso.IsNullable = false;
				colvarTiempoUso.IsPrimaryKey = false;
				colvarTiempoUso.IsForeignKey = false;
				colvarTiempoUso.IsReadOnly = false;
				
						colvarTiempoUso.DefaultSetting = @"('')";
				colvarTiempoUso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoUso);
				
				TableSchema.TableColumn colvarAntecEnfermedadMx = new TableSchema.TableColumn(schema);
				colvarAntecEnfermedadMx.ColumnName = "antecEnfermedadMx";
				colvarAntecEnfermedadMx.DataType = DbType.Int32;
				colvarAntecEnfermedadMx.MaxLength = 0;
				colvarAntecEnfermedadMx.AutoIncrement = false;
				colvarAntecEnfermedadMx.IsNullable = false;
				colvarAntecEnfermedadMx.IsPrimaryKey = false;
				colvarAntecEnfermedadMx.IsForeignKey = false;
				colvarAntecEnfermedadMx.IsReadOnly = false;
				
						colvarAntecEnfermedadMx.DefaultSetting = @"((0))";
				colvarAntecEnfermedadMx.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecEnfermedadMx);
				
				TableSchema.TableColumn colvarAntecBiopsiaMx = new TableSchema.TableColumn(schema);
				colvarAntecBiopsiaMx.ColumnName = "antecBiopsiaMx";
				colvarAntecBiopsiaMx.DataType = DbType.Int32;
				colvarAntecBiopsiaMx.MaxLength = 0;
				colvarAntecBiopsiaMx.AutoIncrement = false;
				colvarAntecBiopsiaMx.IsNullable = false;
				colvarAntecBiopsiaMx.IsPrimaryKey = false;
				colvarAntecBiopsiaMx.IsForeignKey = false;
				colvarAntecBiopsiaMx.IsReadOnly = false;
				
						colvarAntecBiopsiaMx.DefaultSetting = @"((0))";
				colvarAntecBiopsiaMx.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecBiopsiaMx);
				
				TableSchema.TableColumn colvarLocalizacionBMx = new TableSchema.TableColumn(schema);
				colvarLocalizacionBMx.ColumnName = "localizacionBMx";
				colvarLocalizacionBMx.DataType = DbType.AnsiString;
				colvarLocalizacionBMx.MaxLength = 20;
				colvarLocalizacionBMx.AutoIncrement = false;
				colvarLocalizacionBMx.IsNullable = false;
				colvarLocalizacionBMx.IsPrimaryKey = false;
				colvarLocalizacionBMx.IsForeignKey = false;
				colvarLocalizacionBMx.IsReadOnly = false;
				
						colvarLocalizacionBMx.DefaultSetting = @"('')";
				colvarLocalizacionBMx.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalizacionBMx);
				
				TableSchema.TableColumn colvarInformeAnatomiaPatologica = new TableSchema.TableColumn(schema);
				colvarInformeAnatomiaPatologica.ColumnName = "informeAnatomiaPatologica";
				colvarInformeAnatomiaPatologica.DataType = DbType.AnsiString;
				colvarInformeAnatomiaPatologica.MaxLength = 1000;
				colvarInformeAnatomiaPatologica.AutoIncrement = false;
				colvarInformeAnatomiaPatologica.IsNullable = false;
				colvarInformeAnatomiaPatologica.IsPrimaryKey = false;
				colvarInformeAnatomiaPatologica.IsForeignKey = false;
				colvarInformeAnatomiaPatologica.IsReadOnly = false;
				
						colvarInformeAnatomiaPatologica.DefaultSetting = @"('')";
				colvarInformeAnatomiaPatologica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformeAnatomiaPatologica);
				
				TableSchema.TableColumn colvarAntecCancerPersonal = new TableSchema.TableColumn(schema);
				colvarAntecCancerPersonal.ColumnName = "antecCancerPersonal";
				colvarAntecCancerPersonal.DataType = DbType.Int32;
				colvarAntecCancerPersonal.MaxLength = 0;
				colvarAntecCancerPersonal.AutoIncrement = false;
				colvarAntecCancerPersonal.IsNullable = false;
				colvarAntecCancerPersonal.IsPrimaryKey = false;
				colvarAntecCancerPersonal.IsForeignKey = false;
				colvarAntecCancerPersonal.IsReadOnly = false;
				
						colvarAntecCancerPersonal.DefaultSetting = @"((0))";
				colvarAntecCancerPersonal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecCancerPersonal);
				
				TableSchema.TableColumn colvarAntecCancerPersonalCual = new TableSchema.TableColumn(schema);
				colvarAntecCancerPersonalCual.ColumnName = "antecCancerPersonalCual";
				colvarAntecCancerPersonalCual.DataType = DbType.AnsiString;
				colvarAntecCancerPersonalCual.MaxLength = 50;
				colvarAntecCancerPersonalCual.AutoIncrement = false;
				colvarAntecCancerPersonalCual.IsNullable = false;
				colvarAntecCancerPersonalCual.IsPrimaryKey = false;
				colvarAntecCancerPersonalCual.IsForeignKey = false;
				colvarAntecCancerPersonalCual.IsReadOnly = false;
				
						colvarAntecCancerPersonalCual.DefaultSetting = @"('')";
				colvarAntecCancerPersonalCual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAntecCancerPersonalCual);
				
				TableSchema.TableColumn colvarMxPrevia = new TableSchema.TableColumn(schema);
				colvarMxPrevia.ColumnName = "mxPrevia";
				colvarMxPrevia.DataType = DbType.Int32;
				colvarMxPrevia.MaxLength = 0;
				colvarMxPrevia.AutoIncrement = false;
				colvarMxPrevia.IsNullable = false;
				colvarMxPrevia.IsPrimaryKey = false;
				colvarMxPrevia.IsForeignKey = false;
				colvarMxPrevia.IsReadOnly = false;
				
						colvarMxPrevia.DefaultSetting = @"((0))";
				colvarMxPrevia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMxPrevia);
				
				TableSchema.TableColumn colvarFechaMxPrevia = new TableSchema.TableColumn(schema);
				colvarFechaMxPrevia.ColumnName = "fechaMxPrevia";
				colvarFechaMxPrevia.DataType = DbType.DateTime;
				colvarFechaMxPrevia.MaxLength = 0;
				colvarFechaMxPrevia.AutoIncrement = false;
				colvarFechaMxPrevia.IsNullable = false;
				colvarFechaMxPrevia.IsPrimaryKey = false;
				colvarFechaMxPrevia.IsForeignKey = false;
				colvarFechaMxPrevia.IsReadOnly = false;
				colvarFechaMxPrevia.DefaultSetting = @"";
				colvarFechaMxPrevia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaMxPrevia);
				
				TableSchema.TableColumn colvarTiempoEstimado = new TableSchema.TableColumn(schema);
				colvarTiempoEstimado.ColumnName = "tiempoEstimado";
				colvarTiempoEstimado.DataType = DbType.AnsiString;
				colvarTiempoEstimado.MaxLength = 20;
				colvarTiempoEstimado.AutoIncrement = false;
				colvarTiempoEstimado.IsNullable = false;
				colvarTiempoEstimado.IsPrimaryKey = false;
				colvarTiempoEstimado.IsForeignKey = false;
				colvarTiempoEstimado.IsReadOnly = false;
				
						colvarTiempoEstimado.DefaultSetting = @"('')";
				colvarTiempoEstimado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoEstimado);
				
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
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"('')";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				TableSchema.TableColumn colvarMenarca = new TableSchema.TableColumn(schema);
				colvarMenarca.ColumnName = "menarca";
				colvarMenarca.DataType = DbType.Int32;
				colvarMenarca.MaxLength = 0;
				colvarMenarca.AutoIncrement = false;
				colvarMenarca.IsNullable = false;
				colvarMenarca.IsPrimaryKey = false;
				colvarMenarca.IsForeignKey = false;
				colvarMenarca.IsReadOnly = false;
				
						colvarMenarca.DefaultSetting = @"((0))";
				colvarMenarca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMenarca);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_Antecedentes",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAntecedenteMamas")]
		[Bindable(true)]
		public int IdAntecedenteMamas 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedenteMamas); }
			set { SetColumnValue(Columns.IdAntecedenteMamas, value); }
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
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("IdMetodoAnticonceptivo")]
		[Bindable(true)]
		public int IdMetodoAnticonceptivo 
		{
			get { return GetColumnValue<int>(Columns.IdMetodoAnticonceptivo); }
			set { SetColumnValue(Columns.IdMetodoAnticonceptivo, value); }
		}
		  
		[XmlAttribute("EmbarazoActual")]
		[Bindable(true)]
		public int EmbarazoActual 
		{
			get { return GetColumnValue<int>(Columns.EmbarazoActual); }
			set { SetColumnValue(Columns.EmbarazoActual, value); }
		}
		  
		[XmlAttribute("CantidadPartos")]
		[Bindable(true)]
		public int CantidadPartos 
		{
			get { return GetColumnValue<int>(Columns.CantidadPartos); }
			set { SetColumnValue(Columns.CantidadPartos, value); }
		}
		  
		[XmlAttribute("CantidadEmbarazos")]
		[Bindable(true)]
		public int CantidadEmbarazos 
		{
			get { return GetColumnValue<int>(Columns.CantidadEmbarazos); }
			set { SetColumnValue(Columns.CantidadEmbarazos, value); }
		}
		  
		[XmlAttribute("AntecLactancia")]
		[Bindable(true)]
		public int AntecLactancia 
		{
			get { return GetColumnValue<int>(Columns.AntecLactancia); }
			set { SetColumnValue(Columns.AntecLactancia, value); }
		}
		  
		[XmlAttribute("AntecCancer")]
		[Bindable(true)]
		public int AntecCancer 
		{
			get { return GetColumnValue<int>(Columns.AntecCancer); }
			set { SetColumnValue(Columns.AntecCancer, value); }
		}
		  
		[XmlAttribute("AntecCancerCual")]
		[Bindable(true)]
		public string AntecCancerCual 
		{
			get { return GetColumnValue<string>(Columns.AntecCancerCual); }
			set { SetColumnValue(Columns.AntecCancerCual, value); }
		}
		  
		[XmlAttribute("AntecCancerTipoParentezco")]
		[Bindable(true)]
		public string AntecCancerTipoParentezco 
		{
			get { return GetColumnValue<string>(Columns.AntecCancerTipoParentezco); }
			set { SetColumnValue(Columns.AntecCancerTipoParentezco, value); }
		}
		  
		[XmlAttribute("FechaFUM")]
		[Bindable(true)]
		public DateTime FechaFUM 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaFUM); }
			set { SetColumnValue(Columns.FechaFUM, value); }
		}
		  
		[XmlAttribute("EdadFUM")]
		[Bindable(true)]
		public int EdadFUM 
		{
			get { return GetColumnValue<int>(Columns.EdadFUM); }
			set { SetColumnValue(Columns.EdadFUM, value); }
		}
		  
		[XmlAttribute("EdadPrimerEmb")]
		[Bindable(true)]
		public int EdadPrimerEmb 
		{
			get { return GetColumnValue<int>(Columns.EdadPrimerEmb); }
			set { SetColumnValue(Columns.EdadPrimerEmb, value); }
		}
		  
		[XmlAttribute("Menopausia")]
		[Bindable(true)]
		public int Menopausia 
		{
			get { return GetColumnValue<int>(Columns.Menopausia); }
			set { SetColumnValue(Columns.Menopausia, value); }
		}
		  
		[XmlAttribute("Thr")]
		[Bindable(true)]
		public int Thr 
		{
			get { return GetColumnValue<int>(Columns.Thr); }
			set { SetColumnValue(Columns.Thr, value); }
		}
		  
		[XmlAttribute("TiempoUso")]
		[Bindable(true)]
		public string TiempoUso 
		{
			get { return GetColumnValue<string>(Columns.TiempoUso); }
			set { SetColumnValue(Columns.TiempoUso, value); }
		}
		  
		[XmlAttribute("AntecEnfermedadMx")]
		[Bindable(true)]
		public int AntecEnfermedadMx 
		{
			get { return GetColumnValue<int>(Columns.AntecEnfermedadMx); }
			set { SetColumnValue(Columns.AntecEnfermedadMx, value); }
		}
		  
		[XmlAttribute("AntecBiopsiaMx")]
		[Bindable(true)]
		public int AntecBiopsiaMx 
		{
			get { return GetColumnValue<int>(Columns.AntecBiopsiaMx); }
			set { SetColumnValue(Columns.AntecBiopsiaMx, value); }
		}
		  
		[XmlAttribute("LocalizacionBMx")]
		[Bindable(true)]
		public string LocalizacionBMx 
		{
			get { return GetColumnValue<string>(Columns.LocalizacionBMx); }
			set { SetColumnValue(Columns.LocalizacionBMx, value); }
		}
		  
		[XmlAttribute("InformeAnatomiaPatologica")]
		[Bindable(true)]
		public string InformeAnatomiaPatologica 
		{
			get { return GetColumnValue<string>(Columns.InformeAnatomiaPatologica); }
			set { SetColumnValue(Columns.InformeAnatomiaPatologica, value); }
		}
		  
		[XmlAttribute("AntecCancerPersonal")]
		[Bindable(true)]
		public int AntecCancerPersonal 
		{
			get { return GetColumnValue<int>(Columns.AntecCancerPersonal); }
			set { SetColumnValue(Columns.AntecCancerPersonal, value); }
		}
		  
		[XmlAttribute("AntecCancerPersonalCual")]
		[Bindable(true)]
		public string AntecCancerPersonalCual 
		{
			get { return GetColumnValue<string>(Columns.AntecCancerPersonalCual); }
			set { SetColumnValue(Columns.AntecCancerPersonalCual, value); }
		}
		  
		[XmlAttribute("MxPrevia")]
		[Bindable(true)]
		public int MxPrevia 
		{
			get { return GetColumnValue<int>(Columns.MxPrevia); }
			set { SetColumnValue(Columns.MxPrevia, value); }
		}
		  
		[XmlAttribute("FechaMxPrevia")]
		[Bindable(true)]
		public DateTime FechaMxPrevia 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaMxPrevia); }
			set { SetColumnValue(Columns.FechaMxPrevia, value); }
		}
		  
		[XmlAttribute("TiempoEstimado")]
		[Bindable(true)]
		public string TiempoEstimado 
		{
			get { return GetColumnValue<string>(Columns.TiempoEstimado); }
			set { SetColumnValue(Columns.TiempoEstimado, value); }
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
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
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
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		  
		[XmlAttribute("Menarca")]
		[Bindable(true)]
		public int Menarca 
		{
			get { return GetColumnValue<int>(Columns.Menarca); }
			set { SetColumnValue(Columns.Menarca, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamAntecedente
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a TamMetodoAnticonceptivo ActiveRecord object related to this MamAntecedente
		/// 
		/// </summary>
		public DalSic.TamMetodoAnticonceptivo TamMetodoAnticonceptivo
		{
			get { return DalSic.TamMetodoAnticonceptivo.FetchByID(this.IdMetodoAnticonceptivo); }
			set { SetColumnValue("idMetodoAnticonceptivo", value.IdMetodoAnticonceptivo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,int varEdad,int varIdMetodoAnticonceptivo,int varEmbarazoActual,int varCantidadPartos,int varCantidadEmbarazos,int varAntecLactancia,int varAntecCancer,string varAntecCancerCual,string varAntecCancerTipoParentezco,DateTime varFechaFUM,int varEdadFUM,int varEdadPrimerEmb,int varMenopausia,int varThr,string varTiempoUso,int varAntecEnfermedadMx,int varAntecBiopsiaMx,string varLocalizacionBMx,string varInformeAnatomiaPatologica,int varAntecCancerPersonal,string varAntecCancerPersonalCual,int varMxPrevia,DateTime varFechaMxPrevia,string varTiempoEstimado,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varMenarca)
		{
			MamAntecedente item = new MamAntecedente();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.IdMetodoAnticonceptivo = varIdMetodoAnticonceptivo;
			
			item.EmbarazoActual = varEmbarazoActual;
			
			item.CantidadPartos = varCantidadPartos;
			
			item.CantidadEmbarazos = varCantidadEmbarazos;
			
			item.AntecLactancia = varAntecLactancia;
			
			item.AntecCancer = varAntecCancer;
			
			item.AntecCancerCual = varAntecCancerCual;
			
			item.AntecCancerTipoParentezco = varAntecCancerTipoParentezco;
			
			item.FechaFUM = varFechaFUM;
			
			item.EdadFUM = varEdadFUM;
			
			item.EdadPrimerEmb = varEdadPrimerEmb;
			
			item.Menopausia = varMenopausia;
			
			item.Thr = varThr;
			
			item.TiempoUso = varTiempoUso;
			
			item.AntecEnfermedadMx = varAntecEnfermedadMx;
			
			item.AntecBiopsiaMx = varAntecBiopsiaMx;
			
			item.LocalizacionBMx = varLocalizacionBMx;
			
			item.InformeAnatomiaPatologica = varInformeAnatomiaPatologica;
			
			item.AntecCancerPersonal = varAntecCancerPersonal;
			
			item.AntecCancerPersonalCual = varAntecCancerPersonalCual;
			
			item.MxPrevia = varMxPrevia;
			
			item.FechaMxPrevia = varFechaMxPrevia;
			
			item.TiempoEstimado = varTiempoEstimado;
			
			item.Activo = varActivo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Menarca = varMenarca;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAntecedenteMamas,int varIdEfector,int varIdPaciente,int varEdad,int varIdMetodoAnticonceptivo,int varEmbarazoActual,int varCantidadPartos,int varCantidadEmbarazos,int varAntecLactancia,int varAntecCancer,string varAntecCancerCual,string varAntecCancerTipoParentezco,DateTime varFechaFUM,int varEdadFUM,int varEdadPrimerEmb,int varMenopausia,int varThr,string varTiempoUso,int varAntecEnfermedadMx,int varAntecBiopsiaMx,string varLocalizacionBMx,string varInformeAnatomiaPatologica,int varAntecCancerPersonal,string varAntecCancerPersonalCual,int varMxPrevia,DateTime varFechaMxPrevia,string varTiempoEstimado,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varMenarca)
		{
			MamAntecedente item = new MamAntecedente();
			
				item.IdAntecedenteMamas = varIdAntecedenteMamas;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.IdMetodoAnticonceptivo = varIdMetodoAnticonceptivo;
			
				item.EmbarazoActual = varEmbarazoActual;
			
				item.CantidadPartos = varCantidadPartos;
			
				item.CantidadEmbarazos = varCantidadEmbarazos;
			
				item.AntecLactancia = varAntecLactancia;
			
				item.AntecCancer = varAntecCancer;
			
				item.AntecCancerCual = varAntecCancerCual;
			
				item.AntecCancerTipoParentezco = varAntecCancerTipoParentezco;
			
				item.FechaFUM = varFechaFUM;
			
				item.EdadFUM = varEdadFUM;
			
				item.EdadPrimerEmb = varEdadPrimerEmb;
			
				item.Menopausia = varMenopausia;
			
				item.Thr = varThr;
			
				item.TiempoUso = varTiempoUso;
			
				item.AntecEnfermedadMx = varAntecEnfermedadMx;
			
				item.AntecBiopsiaMx = varAntecBiopsiaMx;
			
				item.LocalizacionBMx = varLocalizacionBMx;
			
				item.InformeAnatomiaPatologica = varInformeAnatomiaPatologica;
			
				item.AntecCancerPersonal = varAntecCancerPersonal;
			
				item.AntecCancerPersonalCual = varAntecCancerPersonalCual;
			
				item.MxPrevia = varMxPrevia;
			
				item.FechaMxPrevia = varFechaMxPrevia;
			
				item.TiempoEstimado = varTiempoEstimado;
			
				item.Activo = varActivo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Menarca = varMenarca;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAntecedenteMamasColumn
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
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMetodoAnticonceptivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoActualColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadPartosColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadEmbarazosColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecLactanciaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecCancerColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecCancerCualColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecCancerTipoParentezcoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFUMColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadFUMColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadPrimerEmbColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MenopausiaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ThrColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoUsoColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecEnfermedadMxColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecBiopsiaMxColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalizacionBMxColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeAnatomiaPatologicaColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecCancerPersonalColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn AntecCancerPersonalCualColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn MxPreviaColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaMxPreviaColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoEstimadoColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn MenarcaColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAntecedenteMamas = @"idAntecedenteMamas";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string IdMetodoAnticonceptivo = @"idMetodoAnticonceptivo";
			 public static string EmbarazoActual = @"embarazoActual";
			 public static string CantidadPartos = @"cantidadPartos";
			 public static string CantidadEmbarazos = @"cantidadEmbarazos";
			 public static string AntecLactancia = @"antecLactancia";
			 public static string AntecCancer = @"antecCancer";
			 public static string AntecCancerCual = @"antecCancerCual";
			 public static string AntecCancerTipoParentezco = @"antecCancerTipoParentezco";
			 public static string FechaFUM = @"fechaFUM";
			 public static string EdadFUM = @"edadFUM";
			 public static string EdadPrimerEmb = @"edadPrimerEmb";
			 public static string Menopausia = @"menopausia";
			 public static string Thr = @"THR";
			 public static string TiempoUso = @"tiempoUso";
			 public static string AntecEnfermedadMx = @"antecEnfermedadMx";
			 public static string AntecBiopsiaMx = @"antecBiopsiaMx";
			 public static string LocalizacionBMx = @"localizacionBMx";
			 public static string InformeAnatomiaPatologica = @"informeAnatomiaPatologica";
			 public static string AntecCancerPersonal = @"antecCancerPersonal";
			 public static string AntecCancerPersonalCual = @"antecCancerPersonalCual";
			 public static string MxPrevia = @"mxPrevia";
			 public static string FechaMxPrevia = @"fechaMxPrevia";
			 public static string TiempoEstimado = @"tiempoEstimado";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string Menarca = @"menarca";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
