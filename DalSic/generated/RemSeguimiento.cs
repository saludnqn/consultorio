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
	/// Strongly-typed collection for the RemSeguimiento class.
	/// </summary>
    [Serializable]
	public partial class RemSeguimientoCollection : ActiveList<RemSeguimiento, RemSeguimientoCollection>
	{	   
		public RemSeguimientoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemSeguimientoCollection</returns>
		public RemSeguimientoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemSeguimiento o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_Seguimiento table.
	/// </summary>
	[Serializable]
	public partial class RemSeguimiento : ActiveRecord<RemSeguimiento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemSeguimiento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemSeguimiento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemSeguimiento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemSeguimiento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_Seguimiento", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSeguimiento = new TableSchema.TableColumn(schema);
				colvarIdSeguimiento.ColumnName = "idSeguimiento";
				colvarIdSeguimiento.DataType = DbType.Int32;
				colvarIdSeguimiento.MaxLength = 0;
				colvarIdSeguimiento.AutoIncrement = true;
				colvarIdSeguimiento.IsNullable = false;
				colvarIdSeguimiento.IsPrimaryKey = true;
				colvarIdSeguimiento.IsForeignKey = false;
				colvarIdSeguimiento.IsReadOnly = false;
				colvarIdSeguimiento.DefaultSetting = @"";
				colvarIdSeguimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSeguimiento);
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "idClasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = false;
				colvarIdClasificacion.IsNullable = false;
				colvarIdClasificacion.IsPrimaryKey = false;
				colvarIdClasificacion.IsForeignKey = true;
				colvarIdClasificacion.IsReadOnly = false;
				
						colvarIdClasificacion.DefaultSetting = @"((0))";
				
					colvarIdClasificacion.ForeignKeyTableName = "Rem_Clasificacion";
				schema.Columns.Add(colvarIdClasificacion);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				
						colvarIdEfector.DefaultSetting = @"((0))";
				colvarIdEfector.ForeignKeyTableName = "";
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
				
				TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
				colvarFechaControl.ColumnName = "fechaControl";
				colvarFechaControl.DataType = DbType.DateTime;
				colvarFechaControl.MaxLength = 0;
				colvarFechaControl.AutoIncrement = false;
				colvarFechaControl.IsNullable = false;
				colvarFechaControl.IsPrimaryKey = false;
				colvarFechaControl.IsForeignKey = false;
				colvarFechaControl.IsReadOnly = false;
				
						colvarFechaControl.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaControl);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = false;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				
						colvarPeso.DefaultSetting = @"((0))";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "talla";
				colvarTalla.DataType = DbType.Decimal;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = false;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				
						colvarTalla.DefaultSetting = @"((0))";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarImc = new TableSchema.TableColumn(schema);
				colvarImc.ColumnName = "Imc";
				colvarImc.DataType = DbType.Decimal;
				colvarImc.MaxLength = 0;
				colvarImc.AutoIncrement = false;
				colvarImc.IsNullable = false;
				colvarImc.IsPrimaryKey = false;
				colvarImc.IsForeignKey = false;
				colvarImc.IsReadOnly = false;
				
						colvarImc.DefaultSetting = @"((0))";
				colvarImc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImc);
				
				TableSchema.TableColumn colvarTAS = new TableSchema.TableColumn(schema);
				colvarTAS.ColumnName = "tAS";
				colvarTAS.DataType = DbType.Int32;
				colvarTAS.MaxLength = 0;
				colvarTAS.AutoIncrement = false;
				colvarTAS.IsNullable = false;
				colvarTAS.IsPrimaryKey = false;
				colvarTAS.IsForeignKey = false;
				colvarTAS.IsReadOnly = false;
				colvarTAS.DefaultSetting = @"";
				colvarTAS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTAS);
				
				TableSchema.TableColumn colvarTAD = new TableSchema.TableColumn(schema);
				colvarTAD.ColumnName = "tAD";
				colvarTAD.DataType = DbType.Int32;
				colvarTAD.MaxLength = 0;
				colvarTAD.AutoIncrement = false;
				colvarTAD.IsNullable = false;
				colvarTAD.IsPrimaryKey = false;
				colvarTAD.IsForeignKey = false;
				colvarTAD.IsReadOnly = false;
				colvarTAD.DefaultSetting = @"";
				colvarTAD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTAD);
				
				TableSchema.TableColumn colvarExamenPiesCompleto = new TableSchema.TableColumn(schema);
				colvarExamenPiesCompleto.ColumnName = "examenPiesCompleto";
				colvarExamenPiesCompleto.DataType = DbType.Int32;
				colvarExamenPiesCompleto.MaxLength = 0;
				colvarExamenPiesCompleto.AutoIncrement = false;
				colvarExamenPiesCompleto.IsNullable = false;
				colvarExamenPiesCompleto.IsPrimaryKey = false;
				colvarExamenPiesCompleto.IsForeignKey = false;
				colvarExamenPiesCompleto.IsReadOnly = false;
				
						colvarExamenPiesCompleto.DefaultSetting = @"((0))";
				colvarExamenPiesCompleto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenPiesCompleto);
				
				TableSchema.TableColumn colvarPlanAlimentario = new TableSchema.TableColumn(schema);
				colvarPlanAlimentario.ColumnName = "planAlimentario";
				colvarPlanAlimentario.DataType = DbType.Int32;
				colvarPlanAlimentario.MaxLength = 0;
				colvarPlanAlimentario.AutoIncrement = false;
				colvarPlanAlimentario.IsNullable = false;
				colvarPlanAlimentario.IsPrimaryKey = false;
				colvarPlanAlimentario.IsForeignKey = false;
				colvarPlanAlimentario.IsReadOnly = false;
				
						colvarPlanAlimentario.DefaultSetting = @"((0))";
				colvarPlanAlimentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlanAlimentario);
				
				TableSchema.TableColumn colvarActividadFisicaAdecuada = new TableSchema.TableColumn(schema);
				colvarActividadFisicaAdecuada.ColumnName = "actividadFisicaAdecuada";
				colvarActividadFisicaAdecuada.DataType = DbType.Int32;
				colvarActividadFisicaAdecuada.MaxLength = 0;
				colvarActividadFisicaAdecuada.AutoIncrement = false;
				colvarActividadFisicaAdecuada.IsNullable = false;
				colvarActividadFisicaAdecuada.IsPrimaryKey = false;
				colvarActividadFisicaAdecuada.IsForeignKey = false;
				colvarActividadFisicaAdecuada.IsReadOnly = false;
				
						colvarActividadFisicaAdecuada.DefaultSetting = @"((0))";
				colvarActividadFisicaAdecuada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActividadFisicaAdecuada);
				
				TableSchema.TableColumn colvarCircunferenciaAbdominal = new TableSchema.TableColumn(schema);
				colvarCircunferenciaAbdominal.ColumnName = "circunferenciaAbdominal";
				colvarCircunferenciaAbdominal.DataType = DbType.Decimal;
				colvarCircunferenciaAbdominal.MaxLength = 0;
				colvarCircunferenciaAbdominal.AutoIncrement = false;
				colvarCircunferenciaAbdominal.IsNullable = false;
				colvarCircunferenciaAbdominal.IsPrimaryKey = false;
				colvarCircunferenciaAbdominal.IsForeignKey = false;
				colvarCircunferenciaAbdominal.IsReadOnly = false;
				
						colvarCircunferenciaAbdominal.DefaultSetting = @"((0))";
				colvarCircunferenciaAbdominal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCircunferenciaAbdominal);
				
				TableSchema.TableColumn colvarFechaLab = new TableSchema.TableColumn(schema);
				colvarFechaLab.ColumnName = "fechaLab";
				colvarFechaLab.DataType = DbType.DateTime;
				colvarFechaLab.MaxLength = 0;
				colvarFechaLab.AutoIncrement = false;
				colvarFechaLab.IsNullable = false;
				colvarFechaLab.IsPrimaryKey = false;
				colvarFechaLab.IsForeignKey = false;
				colvarFechaLab.IsReadOnly = false;
				
						colvarFechaLab.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaLab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaLab);
				
				TableSchema.TableColumn colvarGlucemia = new TableSchema.TableColumn(schema);
				colvarGlucemia.ColumnName = "glucemia";
				colvarGlucemia.DataType = DbType.Decimal;
				colvarGlucemia.MaxLength = 0;
				colvarGlucemia.AutoIncrement = false;
				colvarGlucemia.IsNullable = false;
				colvarGlucemia.IsPrimaryKey = false;
				colvarGlucemia.IsForeignKey = false;
				colvarGlucemia.IsReadOnly = false;
				
						colvarGlucemia.DefaultSetting = @"((0))";
				colvarGlucemia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucemia);
				
				TableSchema.TableColumn colvarUnidadGlucemia = new TableSchema.TableColumn(schema);
				colvarUnidadGlucemia.ColumnName = "unidadGlucemia";
				colvarUnidadGlucemia.DataType = DbType.AnsiString;
				colvarUnidadGlucemia.MaxLength = 10;
				colvarUnidadGlucemia.AutoIncrement = false;
				colvarUnidadGlucemia.IsNullable = false;
				colvarUnidadGlucemia.IsPrimaryKey = false;
				colvarUnidadGlucemia.IsForeignKey = false;
				colvarUnidadGlucemia.IsReadOnly = false;
				
						colvarUnidadGlucemia.DefaultSetting = @"('')";
				colvarUnidadGlucemia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadGlucemia);
				
				TableSchema.TableColumn colvarGlucemiaSolicitada = new TableSchema.TableColumn(schema);
				colvarGlucemiaSolicitada.ColumnName = "glucemiaSolicitada";
				colvarGlucemiaSolicitada.DataType = DbType.Boolean;
				colvarGlucemiaSolicitada.MaxLength = 0;
				colvarGlucemiaSolicitada.AutoIncrement = false;
				colvarGlucemiaSolicitada.IsNullable = false;
				colvarGlucemiaSolicitada.IsPrimaryKey = false;
				colvarGlucemiaSolicitada.IsForeignKey = false;
				colvarGlucemiaSolicitada.IsReadOnly = false;
				
						colvarGlucemiaSolicitada.DefaultSetting = @"((0))";
				colvarGlucemiaSolicitada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucemiaSolicitada);
				
				TableSchema.TableColumn colvarHbAc1 = new TableSchema.TableColumn(schema);
				colvarHbAc1.ColumnName = "HbAc1";
				colvarHbAc1.DataType = DbType.Decimal;
				colvarHbAc1.MaxLength = 0;
				colvarHbAc1.AutoIncrement = false;
				colvarHbAc1.IsNullable = false;
				colvarHbAc1.IsPrimaryKey = false;
				colvarHbAc1.IsForeignKey = false;
				colvarHbAc1.IsReadOnly = false;
				colvarHbAc1.DefaultSetting = @"";
				colvarHbAc1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHbAc1);
				
				TableSchema.TableColumn colvarHbAc1solicitado = new TableSchema.TableColumn(schema);
				colvarHbAc1solicitado.ColumnName = "HbAc1solicitado";
				colvarHbAc1solicitado.DataType = DbType.Boolean;
				colvarHbAc1solicitado.MaxLength = 0;
				colvarHbAc1solicitado.AutoIncrement = false;
				colvarHbAc1solicitado.IsNullable = false;
				colvarHbAc1solicitado.IsPrimaryKey = false;
				colvarHbAc1solicitado.IsForeignKey = false;
				colvarHbAc1solicitado.IsReadOnly = false;
				
						colvarHbAc1solicitado.DefaultSetting = @"((0))";
				colvarHbAc1solicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHbAc1solicitado);
				
				TableSchema.TableColumn colvarHematocrito = new TableSchema.TableColumn(schema);
				colvarHematocrito.ColumnName = "hematocrito";
				colvarHematocrito.DataType = DbType.Decimal;
				colvarHematocrito.MaxLength = 0;
				colvarHematocrito.AutoIncrement = false;
				colvarHematocrito.IsNullable = false;
				colvarHematocrito.IsPrimaryKey = false;
				colvarHematocrito.IsForeignKey = false;
				colvarHematocrito.IsReadOnly = false;
				
						colvarHematocrito.DefaultSetting = @"((0))";
				colvarHematocrito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHematocrito);
				
				TableSchema.TableColumn colvarHemtocritoSolicitado = new TableSchema.TableColumn(schema);
				colvarHemtocritoSolicitado.ColumnName = "hemtocritoSolicitado";
				colvarHemtocritoSolicitado.DataType = DbType.Boolean;
				colvarHemtocritoSolicitado.MaxLength = 0;
				colvarHemtocritoSolicitado.AutoIncrement = false;
				colvarHemtocritoSolicitado.IsNullable = false;
				colvarHemtocritoSolicitado.IsPrimaryKey = false;
				colvarHemtocritoSolicitado.IsForeignKey = false;
				colvarHemtocritoSolicitado.IsReadOnly = false;
				
						colvarHemtocritoSolicitado.DefaultSetting = @"((0))";
				colvarHemtocritoSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHemtocritoSolicitado);
				
				TableSchema.TableColumn colvarColesterolTotal = new TableSchema.TableColumn(schema);
				colvarColesterolTotal.ColumnName = "colesterolTotal";
				colvarColesterolTotal.DataType = DbType.Decimal;
				colvarColesterolTotal.MaxLength = 0;
				colvarColesterolTotal.AutoIncrement = false;
				colvarColesterolTotal.IsNullable = false;
				colvarColesterolTotal.IsPrimaryKey = false;
				colvarColesterolTotal.IsForeignKey = false;
				colvarColesterolTotal.IsReadOnly = false;
				colvarColesterolTotal.DefaultSetting = @"";
				colvarColesterolTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarColesterolTotal);
				
				TableSchema.TableColumn colvarColeterolSolicitado = new TableSchema.TableColumn(schema);
				colvarColeterolSolicitado.ColumnName = "coleterolSolicitado";
				colvarColeterolSolicitado.DataType = DbType.Boolean;
				colvarColeterolSolicitado.MaxLength = 0;
				colvarColeterolSolicitado.AutoIncrement = false;
				colvarColeterolSolicitado.IsNullable = false;
				colvarColeterolSolicitado.IsPrimaryKey = false;
				colvarColeterolSolicitado.IsForeignKey = false;
				colvarColeterolSolicitado.IsReadOnly = false;
				
						colvarColeterolSolicitado.DefaultSetting = @"((0))";
				colvarColeterolSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarColeterolSolicitado);
				
				TableSchema.TableColumn colvarUnidadColTotal = new TableSchema.TableColumn(schema);
				colvarUnidadColTotal.ColumnName = "unidadColTotal";
				colvarUnidadColTotal.DataType = DbType.AnsiString;
				colvarUnidadColTotal.MaxLength = 10;
				colvarUnidadColTotal.AutoIncrement = false;
				colvarUnidadColTotal.IsNullable = false;
				colvarUnidadColTotal.IsPrimaryKey = false;
				colvarUnidadColTotal.IsForeignKey = false;
				colvarUnidadColTotal.IsReadOnly = false;
				
						colvarUnidadColTotal.DefaultSetting = @"('')";
				colvarUnidadColTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadColTotal);
				
				TableSchema.TableColumn colvarHdl = new TableSchema.TableColumn(schema);
				colvarHdl.ColumnName = "HDL";
				colvarHdl.DataType = DbType.Decimal;
				colvarHdl.MaxLength = 0;
				colvarHdl.AutoIncrement = false;
				colvarHdl.IsNullable = false;
				colvarHdl.IsPrimaryKey = false;
				colvarHdl.IsForeignKey = false;
				colvarHdl.IsReadOnly = false;
				colvarHdl.DefaultSetting = @"";
				colvarHdl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHdl);
				
				TableSchema.TableColumn colvarUnidadHDL = new TableSchema.TableColumn(schema);
				colvarUnidadHDL.ColumnName = "unidadHDL";
				colvarUnidadHDL.DataType = DbType.AnsiString;
				colvarUnidadHDL.MaxLength = 10;
				colvarUnidadHDL.AutoIncrement = false;
				colvarUnidadHDL.IsNullable = false;
				colvarUnidadHDL.IsPrimaryKey = false;
				colvarUnidadHDL.IsForeignKey = false;
				colvarUnidadHDL.IsReadOnly = false;
				
						colvarUnidadHDL.DefaultSetting = @"('')";
				colvarUnidadHDL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadHDL);
				
				TableSchema.TableColumn colvarHdlSolicitado = new TableSchema.TableColumn(schema);
				colvarHdlSolicitado.ColumnName = "HdlSolicitado";
				colvarHdlSolicitado.DataType = DbType.Boolean;
				colvarHdlSolicitado.MaxLength = 0;
				colvarHdlSolicitado.AutoIncrement = false;
				colvarHdlSolicitado.IsNullable = false;
				colvarHdlSolicitado.IsPrimaryKey = false;
				colvarHdlSolicitado.IsForeignKey = false;
				colvarHdlSolicitado.IsReadOnly = false;
				
						colvarHdlSolicitado.DefaultSetting = @"((0))";
				colvarHdlSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHdlSolicitado);
				
				TableSchema.TableColumn colvarLdl = new TableSchema.TableColumn(schema);
				colvarLdl.ColumnName = "LDL";
				colvarLdl.DataType = DbType.Decimal;
				colvarLdl.MaxLength = 0;
				colvarLdl.AutoIncrement = false;
				colvarLdl.IsNullable = false;
				colvarLdl.IsPrimaryKey = false;
				colvarLdl.IsForeignKey = false;
				colvarLdl.IsReadOnly = false;
				colvarLdl.DefaultSetting = @"";
				colvarLdl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLdl);
				
				TableSchema.TableColumn colvarUnidadLDL = new TableSchema.TableColumn(schema);
				colvarUnidadLDL.ColumnName = "unidadLDL";
				colvarUnidadLDL.DataType = DbType.AnsiString;
				colvarUnidadLDL.MaxLength = 10;
				colvarUnidadLDL.AutoIncrement = false;
				colvarUnidadLDL.IsNullable = false;
				colvarUnidadLDL.IsPrimaryKey = false;
				colvarUnidadLDL.IsForeignKey = false;
				colvarUnidadLDL.IsReadOnly = false;
				
						colvarUnidadLDL.DefaultSetting = @"('')";
				colvarUnidadLDL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadLDL);
				
				TableSchema.TableColumn colvarLdlSolicitado = new TableSchema.TableColumn(schema);
				colvarLdlSolicitado.ColumnName = "LdlSolicitado";
				colvarLdlSolicitado.DataType = DbType.Boolean;
				colvarLdlSolicitado.MaxLength = 0;
				colvarLdlSolicitado.AutoIncrement = false;
				colvarLdlSolicitado.IsNullable = false;
				colvarLdlSolicitado.IsPrimaryKey = false;
				colvarLdlSolicitado.IsForeignKey = false;
				colvarLdlSolicitado.IsReadOnly = false;
				
						colvarLdlSolicitado.DefaultSetting = @"((0))";
				colvarLdlSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLdlSolicitado);
				
				TableSchema.TableColumn colvarTgl = new TableSchema.TableColumn(schema);
				colvarTgl.ColumnName = "TGL";
				colvarTgl.DataType = DbType.Decimal;
				colvarTgl.MaxLength = 0;
				colvarTgl.AutoIncrement = false;
				colvarTgl.IsNullable = false;
				colvarTgl.IsPrimaryKey = false;
				colvarTgl.IsForeignKey = false;
				colvarTgl.IsReadOnly = false;
				colvarTgl.DefaultSetting = @"";
				colvarTgl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTgl);
				
				TableSchema.TableColumn colvarUnidadTGL = new TableSchema.TableColumn(schema);
				colvarUnidadTGL.ColumnName = "unidadTGL";
				colvarUnidadTGL.DataType = DbType.AnsiString;
				colvarUnidadTGL.MaxLength = 10;
				colvarUnidadTGL.AutoIncrement = false;
				colvarUnidadTGL.IsNullable = false;
				colvarUnidadTGL.IsPrimaryKey = false;
				colvarUnidadTGL.IsForeignKey = false;
				colvarUnidadTGL.IsReadOnly = false;
				
						colvarUnidadTGL.DefaultSetting = @"('')";
				colvarUnidadTGL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadTGL);
				
				TableSchema.TableColumn colvarTglSolicitado = new TableSchema.TableColumn(schema);
				colvarTglSolicitado.ColumnName = "TglSolicitado";
				colvarTglSolicitado.DataType = DbType.Boolean;
				colvarTglSolicitado.MaxLength = 0;
				colvarTglSolicitado.AutoIncrement = false;
				colvarTglSolicitado.IsNullable = false;
				colvarTglSolicitado.IsPrimaryKey = false;
				colvarTglSolicitado.IsForeignKey = false;
				colvarTglSolicitado.IsReadOnly = false;
				
						colvarTglSolicitado.DefaultSetting = @"((0))";
				colvarTglSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTglSolicitado);
				
				TableSchema.TableColumn colvarCreatininemia = new TableSchema.TableColumn(schema);
				colvarCreatininemia.ColumnName = "creatininemia";
				colvarCreatininemia.DataType = DbType.Decimal;
				colvarCreatininemia.MaxLength = 0;
				colvarCreatininemia.AutoIncrement = false;
				colvarCreatininemia.IsNullable = false;
				colvarCreatininemia.IsPrimaryKey = false;
				colvarCreatininemia.IsForeignKey = false;
				colvarCreatininemia.IsReadOnly = false;
				
						colvarCreatininemia.DefaultSetting = @"((0))";
				colvarCreatininemia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatininemia);
				
				TableSchema.TableColumn colvarUnidadCreatininemia = new TableSchema.TableColumn(schema);
				colvarUnidadCreatininemia.ColumnName = "unidadCreatininemia";
				colvarUnidadCreatininemia.DataType = DbType.AnsiString;
				colvarUnidadCreatininemia.MaxLength = 10;
				colvarUnidadCreatininemia.AutoIncrement = false;
				colvarUnidadCreatininemia.IsNullable = false;
				colvarUnidadCreatininemia.IsPrimaryKey = false;
				colvarUnidadCreatininemia.IsForeignKey = false;
				colvarUnidadCreatininemia.IsReadOnly = false;
				
						colvarUnidadCreatininemia.DefaultSetting = @"('')";
				colvarUnidadCreatininemia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadCreatininemia);
				
				TableSchema.TableColumn colvarCreatininemiSolicitada = new TableSchema.TableColumn(schema);
				colvarCreatininemiSolicitada.ColumnName = "creatininemiSolicitada";
				colvarCreatininemiSolicitada.DataType = DbType.Boolean;
				colvarCreatininemiSolicitada.MaxLength = 0;
				colvarCreatininemiSolicitada.AutoIncrement = false;
				colvarCreatininemiSolicitada.IsNullable = false;
				colvarCreatininemiSolicitada.IsPrimaryKey = false;
				colvarCreatininemiSolicitada.IsForeignKey = false;
				colvarCreatininemiSolicitada.IsReadOnly = false;
				
						colvarCreatininemiSolicitada.DefaultSetting = @"((0))";
				colvarCreatininemiSolicitada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatininemiSolicitada);
				
				TableSchema.TableColumn colvarPtog = new TableSchema.TableColumn(schema);
				colvarPtog.ColumnName = "PTOG";
				colvarPtog.DataType = DbType.Decimal;
				colvarPtog.MaxLength = 0;
				colvarPtog.AutoIncrement = false;
				colvarPtog.IsNullable = false;
				colvarPtog.IsPrimaryKey = false;
				colvarPtog.IsForeignKey = false;
				colvarPtog.IsReadOnly = false;
				
						colvarPtog.DefaultSetting = @"((0))";
				colvarPtog.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPtog);
				
				TableSchema.TableColumn colvarUnidadPTOG = new TableSchema.TableColumn(schema);
				colvarUnidadPTOG.ColumnName = "unidadPTOG";
				colvarUnidadPTOG.DataType = DbType.AnsiString;
				colvarUnidadPTOG.MaxLength = 10;
				colvarUnidadPTOG.AutoIncrement = false;
				colvarUnidadPTOG.IsNullable = false;
				colvarUnidadPTOG.IsPrimaryKey = false;
				colvarUnidadPTOG.IsForeignKey = false;
				colvarUnidadPTOG.IsReadOnly = false;
				
						colvarUnidadPTOG.DefaultSetting = @"('')";
				colvarUnidadPTOG.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadPTOG);
				
				TableSchema.TableColumn colvarPtogSolicitado = new TableSchema.TableColumn(schema);
				colvarPtogSolicitado.ColumnName = "PtogSolicitado";
				colvarPtogSolicitado.DataType = DbType.Boolean;
				colvarPtogSolicitado.MaxLength = 0;
				colvarPtogSolicitado.AutoIncrement = false;
				colvarPtogSolicitado.IsNullable = false;
				colvarPtogSolicitado.IsPrimaryKey = false;
				colvarPtogSolicitado.IsForeignKey = false;
				colvarPtogSolicitado.IsReadOnly = false;
				
						colvarPtogSolicitado.DefaultSetting = @"((0))";
				colvarPtogSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPtogSolicitado);
				
				TableSchema.TableColumn colvarMicroalbuminuria = new TableSchema.TableColumn(schema);
				colvarMicroalbuminuria.ColumnName = "microalbuminuria";
				colvarMicroalbuminuria.DataType = DbType.Decimal;
				colvarMicroalbuminuria.MaxLength = 0;
				colvarMicroalbuminuria.AutoIncrement = false;
				colvarMicroalbuminuria.IsNullable = false;
				colvarMicroalbuminuria.IsPrimaryKey = false;
				colvarMicroalbuminuria.IsForeignKey = false;
				colvarMicroalbuminuria.IsReadOnly = false;
				
						colvarMicroalbuminuria.DefaultSetting = @"((0))";
				colvarMicroalbuminuria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMicroalbuminuria);
				
				TableSchema.TableColumn colvarMicroalbuminuriaSolicitada = new TableSchema.TableColumn(schema);
				colvarMicroalbuminuriaSolicitada.ColumnName = "microalbuminuriaSolicitada";
				colvarMicroalbuminuriaSolicitada.DataType = DbType.Boolean;
				colvarMicroalbuminuriaSolicitada.MaxLength = 0;
				colvarMicroalbuminuriaSolicitada.AutoIncrement = false;
				colvarMicroalbuminuriaSolicitada.IsNullable = false;
				colvarMicroalbuminuriaSolicitada.IsPrimaryKey = false;
				colvarMicroalbuminuriaSolicitada.IsForeignKey = false;
				colvarMicroalbuminuriaSolicitada.IsReadOnly = false;
				
						colvarMicroalbuminuriaSolicitada.DefaultSetting = @"((0))";
				colvarMicroalbuminuriaSolicitada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMicroalbuminuriaSolicitada);
				
				TableSchema.TableColumn colvarClaerence = new TableSchema.TableColumn(schema);
				colvarClaerence.ColumnName = "claerence";
				colvarClaerence.DataType = DbType.Decimal;
				colvarClaerence.MaxLength = 0;
				colvarClaerence.AutoIncrement = false;
				colvarClaerence.IsNullable = false;
				colvarClaerence.IsPrimaryKey = false;
				colvarClaerence.IsForeignKey = false;
				colvarClaerence.IsReadOnly = false;
				
						colvarClaerence.DefaultSetting = @"((0))";
				colvarClaerence.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClaerence);
				
				TableSchema.TableColumn colvarClearenceSolicitado = new TableSchema.TableColumn(schema);
				colvarClearenceSolicitado.ColumnName = "clearenceSolicitado";
				colvarClearenceSolicitado.DataType = DbType.Boolean;
				colvarClearenceSolicitado.MaxLength = 0;
				colvarClearenceSolicitado.AutoIncrement = false;
				colvarClearenceSolicitado.IsNullable = false;
				colvarClearenceSolicitado.IsPrimaryKey = false;
				colvarClearenceSolicitado.IsForeignKey = false;
				colvarClearenceSolicitado.IsReadOnly = false;
				
						colvarClearenceSolicitado.DefaultSetting = @"((0))";
				colvarClearenceSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClearenceSolicitado);
				
				TableSchema.TableColumn colvarRelacionCOrina = new TableSchema.TableColumn(schema);
				colvarRelacionCOrina.ColumnName = "relacionCOrina";
				colvarRelacionCOrina.DataType = DbType.Decimal;
				colvarRelacionCOrina.MaxLength = 0;
				colvarRelacionCOrina.AutoIncrement = false;
				colvarRelacionCOrina.IsNullable = false;
				colvarRelacionCOrina.IsPrimaryKey = false;
				colvarRelacionCOrina.IsForeignKey = false;
				colvarRelacionCOrina.IsReadOnly = false;
				
						colvarRelacionCOrina.DefaultSetting = @"((0))";
				colvarRelacionCOrina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRelacionCOrina);
				
				TableSchema.TableColumn colvarOtrosLab = new TableSchema.TableColumn(schema);
				colvarOtrosLab.ColumnName = "otrosLab";
				colvarOtrosLab.DataType = DbType.String;
				colvarOtrosLab.MaxLength = 300;
				colvarOtrosLab.AutoIncrement = false;
				colvarOtrosLab.IsNullable = false;
				colvarOtrosLab.IsPrimaryKey = false;
				colvarOtrosLab.IsForeignKey = false;
				colvarOtrosLab.IsReadOnly = false;
				
						colvarOtrosLab.DefaultSetting = @"('')";
				colvarOtrosLab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrosLab);
				
				TableSchema.TableColumn colvarInsulinaNPH = new TableSchema.TableColumn(schema);
				colvarInsulinaNPH.ColumnName = "insulinaNPH";
				colvarInsulinaNPH.DataType = DbType.Boolean;
				colvarInsulinaNPH.MaxLength = 0;
				colvarInsulinaNPH.AutoIncrement = false;
				colvarInsulinaNPH.IsNullable = false;
				colvarInsulinaNPH.IsPrimaryKey = false;
				colvarInsulinaNPH.IsForeignKey = false;
				colvarInsulinaNPH.IsReadOnly = false;
				
						colvarInsulinaNPH.DefaultSetting = @"((0))";
				colvarInsulinaNPH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsulinaNPH);
				
				TableSchema.TableColumn colvarInsulinaRap = new TableSchema.TableColumn(schema);
				colvarInsulinaRap.ColumnName = "insulinaRap";
				colvarInsulinaRap.DataType = DbType.Boolean;
				colvarInsulinaRap.MaxLength = 0;
				colvarInsulinaRap.AutoIncrement = false;
				colvarInsulinaRap.IsNullable = false;
				colvarInsulinaRap.IsPrimaryKey = false;
				colvarInsulinaRap.IsForeignKey = false;
				colvarInsulinaRap.IsReadOnly = false;
				
						colvarInsulinaRap.DefaultSetting = @"((0))";
				colvarInsulinaRap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsulinaRap);
				
				TableSchema.TableColumn colvarInsulinaAnalog = new TableSchema.TableColumn(schema);
				colvarInsulinaAnalog.ColumnName = "insulinaAnalog";
				colvarInsulinaAnalog.DataType = DbType.Boolean;
				colvarInsulinaAnalog.MaxLength = 0;
				colvarInsulinaAnalog.AutoIncrement = false;
				colvarInsulinaAnalog.IsNullable = false;
				colvarInsulinaAnalog.IsPrimaryKey = false;
				colvarInsulinaAnalog.IsForeignKey = false;
				colvarInsulinaAnalog.IsReadOnly = false;
				
						colvarInsulinaAnalog.DefaultSetting = @"((0))";
				colvarInsulinaAnalog.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsulinaAnalog);
				
				TableSchema.TableColumn colvarPresentacionInsulina = new TableSchema.TableColumn(schema);
				colvarPresentacionInsulina.ColumnName = "presentacionInsulina";
				colvarPresentacionInsulina.DataType = DbType.Int32;
				colvarPresentacionInsulina.MaxLength = 0;
				colvarPresentacionInsulina.AutoIncrement = false;
				colvarPresentacionInsulina.IsNullable = false;
				colvarPresentacionInsulina.IsPrimaryKey = false;
				colvarPresentacionInsulina.IsForeignKey = false;
				colvarPresentacionInsulina.IsReadOnly = false;
				
						colvarPresentacionInsulina.DefaultSetting = @"((0))";
				colvarPresentacionInsulina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresentacionInsulina);
				
				TableSchema.TableColumn colvarOtrasDrogas1 = new TableSchema.TableColumn(schema);
				colvarOtrasDrogas1.ColumnName = "otrasDrogas1";
				colvarOtrasDrogas1.DataType = DbType.AnsiString;
				colvarOtrasDrogas1.MaxLength = 200;
				colvarOtrasDrogas1.AutoIncrement = false;
				colvarOtrasDrogas1.IsNullable = false;
				colvarOtrasDrogas1.IsPrimaryKey = false;
				colvarOtrasDrogas1.IsForeignKey = false;
				colvarOtrasDrogas1.IsReadOnly = false;
				
						colvarOtrasDrogas1.DefaultSetting = @"('')";
				colvarOtrasDrogas1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrasDrogas1);
				
				TableSchema.TableColumn colvarDosisODrogas1 = new TableSchema.TableColumn(schema);
				colvarDosisODrogas1.ColumnName = "dosisODrogas1";
				colvarDosisODrogas1.DataType = DbType.Decimal;
				colvarDosisODrogas1.MaxLength = 0;
				colvarDosisODrogas1.AutoIncrement = false;
				colvarDosisODrogas1.IsNullable = false;
				colvarDosisODrogas1.IsPrimaryKey = false;
				colvarDosisODrogas1.IsForeignKey = false;
				colvarDosisODrogas1.IsReadOnly = false;
				colvarDosisODrogas1.DefaultSetting = @"";
				colvarDosisODrogas1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDosisODrogas1);
				
				TableSchema.TableColumn colvarOtrasDrogras2 = new TableSchema.TableColumn(schema);
				colvarOtrasDrogras2.ColumnName = "otrasDrogras2";
				colvarOtrasDrogras2.DataType = DbType.AnsiString;
				colvarOtrasDrogras2.MaxLength = 200;
				colvarOtrasDrogras2.AutoIncrement = false;
				colvarOtrasDrogras2.IsNullable = false;
				colvarOtrasDrogras2.IsPrimaryKey = false;
				colvarOtrasDrogras2.IsForeignKey = false;
				colvarOtrasDrogras2.IsReadOnly = false;
				
						colvarOtrasDrogras2.DefaultSetting = @"('')";
				colvarOtrasDrogras2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrasDrogras2);
				
				TableSchema.TableColumn colvarDosisODrogas2 = new TableSchema.TableColumn(schema);
				colvarDosisODrogas2.ColumnName = "dosisODrogas2";
				colvarDosisODrogas2.DataType = DbType.Decimal;
				colvarDosisODrogas2.MaxLength = 0;
				colvarDosisODrogas2.AutoIncrement = false;
				colvarDosisODrogas2.IsNullable = false;
				colvarDosisODrogas2.IsPrimaryKey = false;
				colvarDosisODrogas2.IsForeignKey = false;
				colvarDosisODrogas2.IsReadOnly = false;
				colvarDosisODrogas2.DefaultSetting = @"";
				colvarDosisODrogas2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDosisODrogas2);
				
				TableSchema.TableColumn colvarOtrosMedicam = new TableSchema.TableColumn(schema);
				colvarOtrosMedicam.ColumnName = "otrosMedicam";
				colvarOtrosMedicam.DataType = DbType.AnsiString;
				colvarOtrosMedicam.MaxLength = 300;
				colvarOtrosMedicam.AutoIncrement = false;
				colvarOtrosMedicam.IsNullable = false;
				colvarOtrosMedicam.IsPrimaryKey = false;
				colvarOtrosMedicam.IsForeignKey = false;
				colvarOtrosMedicam.IsReadOnly = false;
				
						colvarOtrosMedicam.DefaultSetting = @"('')";
				colvarOtrosMedicam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrosMedicam);
				
				TableSchema.TableColumn colvarAutomonitoreoGLucemico = new TableSchema.TableColumn(schema);
				colvarAutomonitoreoGLucemico.ColumnName = "automonitoreoGLucemico";
				colvarAutomonitoreoGLucemico.DataType = DbType.Int32;
				colvarAutomonitoreoGLucemico.MaxLength = 0;
				colvarAutomonitoreoGLucemico.AutoIncrement = false;
				colvarAutomonitoreoGLucemico.IsNullable = false;
				colvarAutomonitoreoGLucemico.IsPrimaryKey = false;
				colvarAutomonitoreoGLucemico.IsForeignKey = false;
				colvarAutomonitoreoGLucemico.IsReadOnly = false;
				
						colvarAutomonitoreoGLucemico.DefaultSetting = @"((0))";
				colvarAutomonitoreoGLucemico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutomonitoreoGLucemico);
				
				TableSchema.TableColumn colvarNroTirasSemana = new TableSchema.TableColumn(schema);
				colvarNroTirasSemana.ColumnName = "nroTirasSemana";
				colvarNroTirasSemana.DataType = DbType.Int32;
				colvarNroTirasSemana.MaxLength = 0;
				colvarNroTirasSemana.AutoIncrement = false;
				colvarNroTirasSemana.IsNullable = false;
				colvarNroTirasSemana.IsPrimaryKey = false;
				colvarNroTirasSemana.IsForeignKey = false;
				colvarNroTirasSemana.IsReadOnly = false;
				
						colvarNroTirasSemana.DefaultSetting = @"((0))";
				colvarNroTirasSemana.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroTirasSemana);
				
				TableSchema.TableColumn colvarEducacionGrupalS = new TableSchema.TableColumn(schema);
				colvarEducacionGrupalS.ColumnName = "educacionGrupalS";
				colvarEducacionGrupalS.DataType = DbType.Boolean;
				colvarEducacionGrupalS.MaxLength = 0;
				colvarEducacionGrupalS.AutoIncrement = false;
				colvarEducacionGrupalS.IsNullable = false;
				colvarEducacionGrupalS.IsPrimaryKey = false;
				colvarEducacionGrupalS.IsForeignKey = false;
				colvarEducacionGrupalS.IsReadOnly = false;
				
						colvarEducacionGrupalS.DefaultSetting = @"((0))";
				colvarEducacionGrupalS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEducacionGrupalS);
				
				TableSchema.TableColumn colvarEducacionGrupalR = new TableSchema.TableColumn(schema);
				colvarEducacionGrupalR.ColumnName = "educacionGrupalR";
				colvarEducacionGrupalR.DataType = DbType.Boolean;
				colvarEducacionGrupalR.MaxLength = 0;
				colvarEducacionGrupalR.AutoIncrement = false;
				colvarEducacionGrupalR.IsNullable = false;
				colvarEducacionGrupalR.IsPrimaryKey = false;
				colvarEducacionGrupalR.IsForeignKey = false;
				colvarEducacionGrupalR.IsReadOnly = false;
				
						colvarEducacionGrupalR.DefaultSetting = @"((0))";
				colvarEducacionGrupalR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEducacionGrupalR);
				
				TableSchema.TableColumn colvarConsultorioNutricionalS = new TableSchema.TableColumn(schema);
				colvarConsultorioNutricionalS.ColumnName = "consultorioNutricionalS";
				colvarConsultorioNutricionalS.DataType = DbType.Boolean;
				colvarConsultorioNutricionalS.MaxLength = 0;
				colvarConsultorioNutricionalS.AutoIncrement = false;
				colvarConsultorioNutricionalS.IsNullable = false;
				colvarConsultorioNutricionalS.IsPrimaryKey = false;
				colvarConsultorioNutricionalS.IsForeignKey = false;
				colvarConsultorioNutricionalS.IsReadOnly = false;
				
						colvarConsultorioNutricionalS.DefaultSetting = @"((0))";
				colvarConsultorioNutricionalS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsultorioNutricionalS);
				
				TableSchema.TableColumn colvarConsultorioNutricionalR = new TableSchema.TableColumn(schema);
				colvarConsultorioNutricionalR.ColumnName = "consultorioNutricionalR";
				colvarConsultorioNutricionalR.DataType = DbType.Boolean;
				colvarConsultorioNutricionalR.MaxLength = 0;
				colvarConsultorioNutricionalR.AutoIncrement = false;
				colvarConsultorioNutricionalR.IsNullable = false;
				colvarConsultorioNutricionalR.IsPrimaryKey = false;
				colvarConsultorioNutricionalR.IsForeignKey = false;
				colvarConsultorioNutricionalR.IsReadOnly = false;
				
						colvarConsultorioNutricionalR.DefaultSetting = @"((0))";
				colvarConsultorioNutricionalR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsultorioNutricionalR);
				
				TableSchema.TableColumn colvarConsultorioPodologicoS = new TableSchema.TableColumn(schema);
				colvarConsultorioPodologicoS.ColumnName = "consultorioPodologicoS";
				colvarConsultorioPodologicoS.DataType = DbType.Boolean;
				colvarConsultorioPodologicoS.MaxLength = 0;
				colvarConsultorioPodologicoS.AutoIncrement = false;
				colvarConsultorioPodologicoS.IsNullable = false;
				colvarConsultorioPodologicoS.IsPrimaryKey = false;
				colvarConsultorioPodologicoS.IsForeignKey = false;
				colvarConsultorioPodologicoS.IsReadOnly = false;
				
						colvarConsultorioPodologicoS.DefaultSetting = @"((0))";
				colvarConsultorioPodologicoS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsultorioPodologicoS);
				
				TableSchema.TableColumn colvarConsultorioPodologicoR = new TableSchema.TableColumn(schema);
				colvarConsultorioPodologicoR.ColumnName = "consultorioPodologicoR";
				colvarConsultorioPodologicoR.DataType = DbType.Boolean;
				colvarConsultorioPodologicoR.MaxLength = 0;
				colvarConsultorioPodologicoR.AutoIncrement = false;
				colvarConsultorioPodologicoR.IsNullable = false;
				colvarConsultorioPodologicoR.IsPrimaryKey = false;
				colvarConsultorioPodologicoR.IsForeignKey = false;
				colvarConsultorioPodologicoR.IsReadOnly = false;
				
						colvarConsultorioPodologicoR.DefaultSetting = @"((0))";
				colvarConsultorioPodologicoR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsultorioPodologicoR);
				
				TableSchema.TableColumn colvarCardiologiaS = new TableSchema.TableColumn(schema);
				colvarCardiologiaS.ColumnName = "cardiologiaS";
				colvarCardiologiaS.DataType = DbType.Boolean;
				colvarCardiologiaS.MaxLength = 0;
				colvarCardiologiaS.AutoIncrement = false;
				colvarCardiologiaS.IsNullable = false;
				colvarCardiologiaS.IsPrimaryKey = false;
				colvarCardiologiaS.IsForeignKey = false;
				colvarCardiologiaS.IsReadOnly = false;
				
						colvarCardiologiaS.DefaultSetting = @"((0))";
				colvarCardiologiaS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardiologiaS);
				
				TableSchema.TableColumn colvarCardiologiaR = new TableSchema.TableColumn(schema);
				colvarCardiologiaR.ColumnName = "cardiologiaR";
				colvarCardiologiaR.DataType = DbType.Boolean;
				colvarCardiologiaR.MaxLength = 0;
				colvarCardiologiaR.AutoIncrement = false;
				colvarCardiologiaR.IsNullable = false;
				colvarCardiologiaR.IsPrimaryKey = false;
				colvarCardiologiaR.IsForeignKey = false;
				colvarCardiologiaR.IsReadOnly = false;
				
						colvarCardiologiaR.DefaultSetting = @"((0))";
				colvarCardiologiaR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardiologiaR);
				
				TableSchema.TableColumn colvarNefrologiaS = new TableSchema.TableColumn(schema);
				colvarNefrologiaS.ColumnName = "nefrologiaS";
				colvarNefrologiaS.DataType = DbType.Boolean;
				colvarNefrologiaS.MaxLength = 0;
				colvarNefrologiaS.AutoIncrement = false;
				colvarNefrologiaS.IsNullable = false;
				colvarNefrologiaS.IsPrimaryKey = false;
				colvarNefrologiaS.IsForeignKey = false;
				colvarNefrologiaS.IsReadOnly = false;
				
						colvarNefrologiaS.DefaultSetting = @"((0))";
				colvarNefrologiaS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNefrologiaS);
				
				TableSchema.TableColumn colvarNefrologiaR = new TableSchema.TableColumn(schema);
				colvarNefrologiaR.ColumnName = "nefrologiaR";
				colvarNefrologiaR.DataType = DbType.Boolean;
				colvarNefrologiaR.MaxLength = 0;
				colvarNefrologiaR.AutoIncrement = false;
				colvarNefrologiaR.IsNullable = false;
				colvarNefrologiaR.IsPrimaryKey = false;
				colvarNefrologiaR.IsForeignKey = false;
				colvarNefrologiaR.IsReadOnly = false;
				
						colvarNefrologiaR.DefaultSetting = @"((0))";
				colvarNefrologiaR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNefrologiaR);
				
				TableSchema.TableColumn colvarClinicaMedicaS = new TableSchema.TableColumn(schema);
				colvarClinicaMedicaS.ColumnName = "clinicaMedicaS";
				colvarClinicaMedicaS.DataType = DbType.Boolean;
				colvarClinicaMedicaS.MaxLength = 0;
				colvarClinicaMedicaS.AutoIncrement = false;
				colvarClinicaMedicaS.IsNullable = false;
				colvarClinicaMedicaS.IsPrimaryKey = false;
				colvarClinicaMedicaS.IsForeignKey = false;
				colvarClinicaMedicaS.IsReadOnly = false;
				
						colvarClinicaMedicaS.DefaultSetting = @"((0))";
				colvarClinicaMedicaS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClinicaMedicaS);
				
				TableSchema.TableColumn colvarClinicaMedicaR = new TableSchema.TableColumn(schema);
				colvarClinicaMedicaR.ColumnName = "clinicaMedicaR";
				colvarClinicaMedicaR.DataType = DbType.Boolean;
				colvarClinicaMedicaR.MaxLength = 0;
				colvarClinicaMedicaR.AutoIncrement = false;
				colvarClinicaMedicaR.IsNullable = false;
				colvarClinicaMedicaR.IsPrimaryKey = false;
				colvarClinicaMedicaR.IsForeignKey = false;
				colvarClinicaMedicaR.IsReadOnly = false;
				
						colvarClinicaMedicaR.DefaultSetting = @"((0))";
				colvarClinicaMedicaR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClinicaMedicaR);
				
				TableSchema.TableColumn colvarOftalmologiaS = new TableSchema.TableColumn(schema);
				colvarOftalmologiaS.ColumnName = "oftalmologiaS";
				colvarOftalmologiaS.DataType = DbType.Boolean;
				colvarOftalmologiaS.MaxLength = 0;
				colvarOftalmologiaS.AutoIncrement = false;
				colvarOftalmologiaS.IsNullable = false;
				colvarOftalmologiaS.IsPrimaryKey = false;
				colvarOftalmologiaS.IsForeignKey = false;
				colvarOftalmologiaS.IsReadOnly = false;
				
						colvarOftalmologiaS.DefaultSetting = @"((0))";
				colvarOftalmologiaS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOftalmologiaS);
				
				TableSchema.TableColumn colvarOftalmologiaR = new TableSchema.TableColumn(schema);
				colvarOftalmologiaR.ColumnName = "oftalmologiaR";
				colvarOftalmologiaR.DataType = DbType.Boolean;
				colvarOftalmologiaR.MaxLength = 0;
				colvarOftalmologiaR.AutoIncrement = false;
				colvarOftalmologiaR.IsNullable = false;
				colvarOftalmologiaR.IsPrimaryKey = false;
				colvarOftalmologiaR.IsForeignKey = false;
				colvarOftalmologiaR.IsReadOnly = false;
				
						colvarOftalmologiaR.DefaultSetting = @"((0))";
				colvarOftalmologiaR.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOftalmologiaR);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				
						colvarIdProfesional.DefaultSetting = @"((0))";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarCerrar = new TableSchema.TableColumn(schema);
				colvarCerrar.ColumnName = "cerrar";
				colvarCerrar.DataType = DbType.Boolean;
				colvarCerrar.MaxLength = 0;
				colvarCerrar.AutoIncrement = false;
				colvarCerrar.IsNullable = false;
				colvarCerrar.IsPrimaryKey = false;
				colvarCerrar.IsForeignKey = false;
				colvarCerrar.IsReadOnly = false;
				
						colvarCerrar.DefaultSetting = @"((0))";
				colvarCerrar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCerrar);
				
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
				
				TableSchema.TableColumn colvarUnidadCOrina = new TableSchema.TableColumn(schema);
				colvarUnidadCOrina.ColumnName = "unidadCOrina";
				colvarUnidadCOrina.DataType = DbType.AnsiString;
				colvarUnidadCOrina.MaxLength = 10;
				colvarUnidadCOrina.AutoIncrement = false;
				colvarUnidadCOrina.IsNullable = false;
				colvarUnidadCOrina.IsPrimaryKey = false;
				colvarUnidadCOrina.IsForeignKey = false;
				colvarUnidadCOrina.IsReadOnly = false;
				
						colvarUnidadCOrina.DefaultSetting = @"('')";
				colvarUnidadCOrina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadCOrina);
				
				TableSchema.TableColumn colvarRelacionCOrinaSolicitado = new TableSchema.TableColumn(schema);
				colvarRelacionCOrinaSolicitado.ColumnName = "relacionCOrinaSolicitado";
				colvarRelacionCOrinaSolicitado.DataType = DbType.Boolean;
				colvarRelacionCOrinaSolicitado.MaxLength = 0;
				colvarRelacionCOrinaSolicitado.AutoIncrement = false;
				colvarRelacionCOrinaSolicitado.IsNullable = false;
				colvarRelacionCOrinaSolicitado.IsPrimaryKey = false;
				colvarRelacionCOrinaSolicitado.IsForeignKey = false;
				colvarRelacionCOrinaSolicitado.IsReadOnly = false;
				
						colvarRelacionCOrinaSolicitado.DefaultSetting = @"((0))";
				colvarRelacionCOrinaSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRelacionCOrinaSolicitado);
				
				TableSchema.TableColumn colvarNombreInsulina = new TableSchema.TableColumn(schema);
				colvarNombreInsulina.ColumnName = "nombreInsulina";
				colvarNombreInsulina.DataType = DbType.AnsiString;
				colvarNombreInsulina.MaxLength = 50;
				colvarNombreInsulina.AutoIncrement = false;
				colvarNombreInsulina.IsNullable = false;
				colvarNombreInsulina.IsPrimaryKey = false;
				colvarNombreInsulina.IsForeignKey = false;
				colvarNombreInsulina.IsReadOnly = false;
				
						colvarNombreInsulina.DefaultSetting = @"('')";
				colvarNombreInsulina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreInsulina);
				
				TableSchema.TableColumn colvarUnidadesDiaINPH = new TableSchema.TableColumn(schema);
				colvarUnidadesDiaINPH.ColumnName = "unidadesDiaINPH";
				colvarUnidadesDiaINPH.DataType = DbType.Int32;
				colvarUnidadesDiaINPH.MaxLength = 0;
				colvarUnidadesDiaINPH.AutoIncrement = false;
				colvarUnidadesDiaINPH.IsNullable = false;
				colvarUnidadesDiaINPH.IsPrimaryKey = false;
				colvarUnidadesDiaINPH.IsForeignKey = false;
				colvarUnidadesDiaINPH.IsReadOnly = false;
				
						colvarUnidadesDiaINPH.DefaultSetting = @"((0))";
				colvarUnidadesDiaINPH.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadesDiaINPH);
				
				TableSchema.TableColumn colvarUnidadesDiaIRap = new TableSchema.TableColumn(schema);
				colvarUnidadesDiaIRap.ColumnName = "unidadesDiaIRap";
				colvarUnidadesDiaIRap.DataType = DbType.Int32;
				colvarUnidadesDiaIRap.MaxLength = 0;
				colvarUnidadesDiaIRap.AutoIncrement = false;
				colvarUnidadesDiaIRap.IsNullable = false;
				colvarUnidadesDiaIRap.IsPrimaryKey = false;
				colvarUnidadesDiaIRap.IsForeignKey = false;
				colvarUnidadesDiaIRap.IsReadOnly = false;
				
						colvarUnidadesDiaIRap.DefaultSetting = @"((0))";
				colvarUnidadesDiaIRap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadesDiaIRap);
				
				TableSchema.TableColumn colvarUnidadesDiaIAnalog = new TableSchema.TableColumn(schema);
				colvarUnidadesDiaIAnalog.ColumnName = "unidadesDiaIAnalog";
				colvarUnidadesDiaIAnalog.DataType = DbType.Int32;
				colvarUnidadesDiaIAnalog.MaxLength = 0;
				colvarUnidadesDiaIAnalog.AutoIncrement = false;
				colvarUnidadesDiaIAnalog.IsNullable = false;
				colvarUnidadesDiaIAnalog.IsPrimaryKey = false;
				colvarUnidadesDiaIAnalog.IsForeignKey = false;
				colvarUnidadesDiaIAnalog.IsReadOnly = false;
				
						colvarUnidadesDiaIAnalog.DefaultSetting = @"((0))";
				colvarUnidadesDiaIAnalog.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadesDiaIAnalog);
				
				TableSchema.TableColumn colvarHematities = new TableSchema.TableColumn(schema);
				colvarHematities.ColumnName = "hematities";
				colvarHematities.DataType = DbType.AnsiString;
				colvarHematities.MaxLength = 10;
				colvarHematities.AutoIncrement = false;
				colvarHematities.IsNullable = false;
				colvarHematities.IsPrimaryKey = false;
				colvarHematities.IsForeignKey = false;
				colvarHematities.IsReadOnly = false;
				
						colvarHematities.DefaultSetting = @"((0))";
				colvarHematities.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHematities);
				
				TableSchema.TableColumn colvarHematitiesSolicitado = new TableSchema.TableColumn(schema);
				colvarHematitiesSolicitado.ColumnName = "hematitiesSolicitado";
				colvarHematitiesSolicitado.DataType = DbType.Boolean;
				colvarHematitiesSolicitado.MaxLength = 0;
				colvarHematitiesSolicitado.AutoIncrement = false;
				colvarHematitiesSolicitado.IsNullable = false;
				colvarHematitiesSolicitado.IsPrimaryKey = false;
				colvarHematitiesSolicitado.IsForeignKey = false;
				colvarHematitiesSolicitado.IsReadOnly = false;
				
						colvarHematitiesSolicitado.DefaultSetting = @"((0))";
				colvarHematitiesSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHematitiesSolicitado);
				
				TableSchema.TableColumn colvarFiltradoGlomerular = new TableSchema.TableColumn(schema);
				colvarFiltradoGlomerular.ColumnName = "filtradoGlomerular";
				colvarFiltradoGlomerular.DataType = DbType.Decimal;
				colvarFiltradoGlomerular.MaxLength = 0;
				colvarFiltradoGlomerular.AutoIncrement = false;
				colvarFiltradoGlomerular.IsNullable = false;
				colvarFiltradoGlomerular.IsPrimaryKey = false;
				colvarFiltradoGlomerular.IsForeignKey = false;
				colvarFiltradoGlomerular.IsReadOnly = false;
				
						colvarFiltradoGlomerular.DefaultSetting = @"((0))";
				colvarFiltradoGlomerular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFiltradoGlomerular);
				
				TableSchema.TableColumn colvarFiltradoGlomSolicitado = new TableSchema.TableColumn(schema);
				colvarFiltradoGlomSolicitado.ColumnName = "filtradoGlomSolicitado";
				colvarFiltradoGlomSolicitado.DataType = DbType.Boolean;
				colvarFiltradoGlomSolicitado.MaxLength = 0;
				colvarFiltradoGlomSolicitado.AutoIncrement = false;
				colvarFiltradoGlomSolicitado.IsNullable = false;
				colvarFiltradoGlomSolicitado.IsPrimaryKey = false;
				colvarFiltradoGlomSolicitado.IsForeignKey = false;
				colvarFiltradoGlomSolicitado.IsReadOnly = false;
				
						colvarFiltradoGlomSolicitado.DefaultSetting = @"((0))";
				colvarFiltradoGlomSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFiltradoGlomSolicitado);
				
				TableSchema.TableColumn colvarIUProteinaCreatinina = new TableSchema.TableColumn(schema);
				colvarIUProteinaCreatinina.ColumnName = "iUProteinaCreatinina";
				colvarIUProteinaCreatinina.DataType = DbType.Decimal;
				colvarIUProteinaCreatinina.MaxLength = 0;
				colvarIUProteinaCreatinina.AutoIncrement = false;
				colvarIUProteinaCreatinina.IsNullable = false;
				colvarIUProteinaCreatinina.IsPrimaryKey = false;
				colvarIUProteinaCreatinina.IsForeignKey = false;
				colvarIUProteinaCreatinina.IsReadOnly = false;
				
						colvarIUProteinaCreatinina.DefaultSetting = @"((0))";
				colvarIUProteinaCreatinina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIUProteinaCreatinina);
				
				TableSchema.TableColumn colvarIUProtCreatininaSolicitado = new TableSchema.TableColumn(schema);
				colvarIUProtCreatininaSolicitado.ColumnName = "iUProtCreatininaSolicitado";
				colvarIUProtCreatininaSolicitado.DataType = DbType.Boolean;
				colvarIUProtCreatininaSolicitado.MaxLength = 0;
				colvarIUProtCreatininaSolicitado.AutoIncrement = false;
				colvarIUProtCreatininaSolicitado.IsNullable = false;
				colvarIUProtCreatininaSolicitado.IsPrimaryKey = false;
				colvarIUProtCreatininaSolicitado.IsForeignKey = false;
				colvarIUProtCreatininaSolicitado.IsReadOnly = false;
				
						colvarIUProtCreatininaSolicitado.DefaultSetting = @"((0))";
				colvarIUProtCreatininaSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIUProtCreatininaSolicitado);
				
				TableSchema.TableColumn colvarIUAlbuminaCreatinina = new TableSchema.TableColumn(schema);
				colvarIUAlbuminaCreatinina.ColumnName = "iUAlbuminaCreatinina";
				colvarIUAlbuminaCreatinina.DataType = DbType.Decimal;
				colvarIUAlbuminaCreatinina.MaxLength = 0;
				colvarIUAlbuminaCreatinina.AutoIncrement = false;
				colvarIUAlbuminaCreatinina.IsNullable = false;
				colvarIUAlbuminaCreatinina.IsPrimaryKey = false;
				colvarIUAlbuminaCreatinina.IsForeignKey = false;
				colvarIUAlbuminaCreatinina.IsReadOnly = false;
				
						colvarIUAlbuminaCreatinina.DefaultSetting = @"((0))";
				colvarIUAlbuminaCreatinina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIUAlbuminaCreatinina);
				
				TableSchema.TableColumn colvarIUAlbumCreatinSolicitado = new TableSchema.TableColumn(schema);
				colvarIUAlbumCreatinSolicitado.ColumnName = "iUAlbumCreatinSolicitado";
				colvarIUAlbumCreatinSolicitado.DataType = DbType.Boolean;
				colvarIUAlbumCreatinSolicitado.MaxLength = 0;
				colvarIUAlbumCreatinSolicitado.AutoIncrement = false;
				colvarIUAlbumCreatinSolicitado.IsNullable = false;
				colvarIUAlbumCreatinSolicitado.IsPrimaryKey = false;
				colvarIUAlbumCreatinSolicitado.IsForeignKey = false;
				colvarIUAlbumCreatinSolicitado.IsReadOnly = false;
				
						colvarIUAlbumCreatinSolicitado.DefaultSetting = @"((0))";
				colvarIUAlbumCreatinSolicitado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIUAlbumCreatinSolicitado);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_Seguimiento",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSeguimiento")]
		[Bindable(true)]
		public int IdSeguimiento 
		{
			get { return GetColumnValue<int>(Columns.IdSeguimiento); }
			set { SetColumnValue(Columns.IdSeguimiento, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int IdClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
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
		  
		[XmlAttribute("FechaControl")]
		[Bindable(true)]
		public DateTime FechaControl 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaControl); }
			set { SetColumnValue(Columns.FechaControl, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal Peso 
		{
			get { return GetColumnValue<decimal>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public decimal Talla 
		{
			get { return GetColumnValue<decimal>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("Imc")]
		[Bindable(true)]
		public decimal Imc 
		{
			get { return GetColumnValue<decimal>(Columns.Imc); }
			set { SetColumnValue(Columns.Imc, value); }
		}
		  
		[XmlAttribute("TAS")]
		[Bindable(true)]
		public int TAS 
		{
			get { return GetColumnValue<int>(Columns.TAS); }
			set { SetColumnValue(Columns.TAS, value); }
		}
		  
		[XmlAttribute("TAD")]
		[Bindable(true)]
		public int TAD 
		{
			get { return GetColumnValue<int>(Columns.TAD); }
			set { SetColumnValue(Columns.TAD, value); }
		}
		  
		[XmlAttribute("ExamenPiesCompleto")]
		[Bindable(true)]
		public int ExamenPiesCompleto 
		{
			get { return GetColumnValue<int>(Columns.ExamenPiesCompleto); }
			set { SetColumnValue(Columns.ExamenPiesCompleto, value); }
		}
		  
		[XmlAttribute("PlanAlimentario")]
		[Bindable(true)]
		public int PlanAlimentario 
		{
			get { return GetColumnValue<int>(Columns.PlanAlimentario); }
			set { SetColumnValue(Columns.PlanAlimentario, value); }
		}
		  
		[XmlAttribute("ActividadFisicaAdecuada")]
		[Bindable(true)]
		public int ActividadFisicaAdecuada 
		{
			get { return GetColumnValue<int>(Columns.ActividadFisicaAdecuada); }
			set { SetColumnValue(Columns.ActividadFisicaAdecuada, value); }
		}
		  
		[XmlAttribute("CircunferenciaAbdominal")]
		[Bindable(true)]
		public decimal CircunferenciaAbdominal 
		{
			get { return GetColumnValue<decimal>(Columns.CircunferenciaAbdominal); }
			set { SetColumnValue(Columns.CircunferenciaAbdominal, value); }
		}
		  
		[XmlAttribute("FechaLab")]
		[Bindable(true)]
		public DateTime FechaLab 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaLab); }
			set { SetColumnValue(Columns.FechaLab, value); }
		}
		  
		[XmlAttribute("Glucemia")]
		[Bindable(true)]
		public decimal Glucemia 
		{
			get { return GetColumnValue<decimal>(Columns.Glucemia); }
			set { SetColumnValue(Columns.Glucemia, value); }
		}
		  
		[XmlAttribute("UnidadGlucemia")]
		[Bindable(true)]
		public string UnidadGlucemia 
		{
			get { return GetColumnValue<string>(Columns.UnidadGlucemia); }
			set { SetColumnValue(Columns.UnidadGlucemia, value); }
		}
		  
		[XmlAttribute("GlucemiaSolicitada")]
		[Bindable(true)]
		public bool GlucemiaSolicitada 
		{
			get { return GetColumnValue<bool>(Columns.GlucemiaSolicitada); }
			set { SetColumnValue(Columns.GlucemiaSolicitada, value); }
		}
		  
		[XmlAttribute("HbAc1")]
		[Bindable(true)]
		public decimal HbAc1 
		{
			get { return GetColumnValue<decimal>(Columns.HbAc1); }
			set { SetColumnValue(Columns.HbAc1, value); }
		}
		  
		[XmlAttribute("HbAc1solicitado")]
		[Bindable(true)]
		public bool HbAc1solicitado 
		{
			get { return GetColumnValue<bool>(Columns.HbAc1solicitado); }
			set { SetColumnValue(Columns.HbAc1solicitado, value); }
		}
		  
		[XmlAttribute("Hematocrito")]
		[Bindable(true)]
		public decimal Hematocrito 
		{
			get { return GetColumnValue<decimal>(Columns.Hematocrito); }
			set { SetColumnValue(Columns.Hematocrito, value); }
		}
		  
		[XmlAttribute("HemtocritoSolicitado")]
		[Bindable(true)]
		public bool HemtocritoSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.HemtocritoSolicitado); }
			set { SetColumnValue(Columns.HemtocritoSolicitado, value); }
		}
		  
		[XmlAttribute("ColesterolTotal")]
		[Bindable(true)]
		public decimal ColesterolTotal 
		{
			get { return GetColumnValue<decimal>(Columns.ColesterolTotal); }
			set { SetColumnValue(Columns.ColesterolTotal, value); }
		}
		  
		[XmlAttribute("ColeterolSolicitado")]
		[Bindable(true)]
		public bool ColeterolSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.ColeterolSolicitado); }
			set { SetColumnValue(Columns.ColeterolSolicitado, value); }
		}
		  
		[XmlAttribute("UnidadColTotal")]
		[Bindable(true)]
		public string UnidadColTotal 
		{
			get { return GetColumnValue<string>(Columns.UnidadColTotal); }
			set { SetColumnValue(Columns.UnidadColTotal, value); }
		}
		  
		[XmlAttribute("Hdl")]
		[Bindable(true)]
		public decimal Hdl 
		{
			get { return GetColumnValue<decimal>(Columns.Hdl); }
			set { SetColumnValue(Columns.Hdl, value); }
		}
		  
		[XmlAttribute("UnidadHDL")]
		[Bindable(true)]
		public string UnidadHDL 
		{
			get { return GetColumnValue<string>(Columns.UnidadHDL); }
			set { SetColumnValue(Columns.UnidadHDL, value); }
		}
		  
		[XmlAttribute("HdlSolicitado")]
		[Bindable(true)]
		public bool HdlSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.HdlSolicitado); }
			set { SetColumnValue(Columns.HdlSolicitado, value); }
		}
		  
		[XmlAttribute("Ldl")]
		[Bindable(true)]
		public decimal Ldl 
		{
			get { return GetColumnValue<decimal>(Columns.Ldl); }
			set { SetColumnValue(Columns.Ldl, value); }
		}
		  
		[XmlAttribute("UnidadLDL")]
		[Bindable(true)]
		public string UnidadLDL 
		{
			get { return GetColumnValue<string>(Columns.UnidadLDL); }
			set { SetColumnValue(Columns.UnidadLDL, value); }
		}
		  
		[XmlAttribute("LdlSolicitado")]
		[Bindable(true)]
		public bool LdlSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.LdlSolicitado); }
			set { SetColumnValue(Columns.LdlSolicitado, value); }
		}
		  
		[XmlAttribute("Tgl")]
		[Bindable(true)]
		public decimal Tgl 
		{
			get { return GetColumnValue<decimal>(Columns.Tgl); }
			set { SetColumnValue(Columns.Tgl, value); }
		}
		  
		[XmlAttribute("UnidadTGL")]
		[Bindable(true)]
		public string UnidadTGL 
		{
			get { return GetColumnValue<string>(Columns.UnidadTGL); }
			set { SetColumnValue(Columns.UnidadTGL, value); }
		}
		  
		[XmlAttribute("TglSolicitado")]
		[Bindable(true)]
		public bool TglSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.TglSolicitado); }
			set { SetColumnValue(Columns.TglSolicitado, value); }
		}
		  
		[XmlAttribute("Creatininemia")]
		[Bindable(true)]
		public decimal Creatininemia 
		{
			get { return GetColumnValue<decimal>(Columns.Creatininemia); }
			set { SetColumnValue(Columns.Creatininemia, value); }
		}
		  
		[XmlAttribute("UnidadCreatininemia")]
		[Bindable(true)]
		public string UnidadCreatininemia 
		{
			get { return GetColumnValue<string>(Columns.UnidadCreatininemia); }
			set { SetColumnValue(Columns.UnidadCreatininemia, value); }
		}
		  
		[XmlAttribute("CreatininemiSolicitada")]
		[Bindable(true)]
		public bool CreatininemiSolicitada 
		{
			get { return GetColumnValue<bool>(Columns.CreatininemiSolicitada); }
			set { SetColumnValue(Columns.CreatininemiSolicitada, value); }
		}
		  
		[XmlAttribute("Ptog")]
		[Bindable(true)]
		public decimal Ptog 
		{
			get { return GetColumnValue<decimal>(Columns.Ptog); }
			set { SetColumnValue(Columns.Ptog, value); }
		}
		  
		[XmlAttribute("UnidadPTOG")]
		[Bindable(true)]
		public string UnidadPTOG 
		{
			get { return GetColumnValue<string>(Columns.UnidadPTOG); }
			set { SetColumnValue(Columns.UnidadPTOG, value); }
		}
		  
		[XmlAttribute("PtogSolicitado")]
		[Bindable(true)]
		public bool PtogSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.PtogSolicitado); }
			set { SetColumnValue(Columns.PtogSolicitado, value); }
		}
		  
		[XmlAttribute("Microalbuminuria")]
		[Bindable(true)]
		public decimal Microalbuminuria 
		{
			get { return GetColumnValue<decimal>(Columns.Microalbuminuria); }
			set { SetColumnValue(Columns.Microalbuminuria, value); }
		}
		  
		[XmlAttribute("MicroalbuminuriaSolicitada")]
		[Bindable(true)]
		public bool MicroalbuminuriaSolicitada 
		{
			get { return GetColumnValue<bool>(Columns.MicroalbuminuriaSolicitada); }
			set { SetColumnValue(Columns.MicroalbuminuriaSolicitada, value); }
		}
		  
		[XmlAttribute("Claerence")]
		[Bindable(true)]
		public decimal Claerence 
		{
			get { return GetColumnValue<decimal>(Columns.Claerence); }
			set { SetColumnValue(Columns.Claerence, value); }
		}
		  
		[XmlAttribute("ClearenceSolicitado")]
		[Bindable(true)]
		public bool ClearenceSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.ClearenceSolicitado); }
			set { SetColumnValue(Columns.ClearenceSolicitado, value); }
		}
		  
		[XmlAttribute("RelacionCOrina")]
		[Bindable(true)]
		public decimal RelacionCOrina 
		{
			get { return GetColumnValue<decimal>(Columns.RelacionCOrina); }
			set { SetColumnValue(Columns.RelacionCOrina, value); }
		}
		  
		[XmlAttribute("OtrosLab")]
		[Bindable(true)]
		public string OtrosLab 
		{
			get { return GetColumnValue<string>(Columns.OtrosLab); }
			set { SetColumnValue(Columns.OtrosLab, value); }
		}
		  
		[XmlAttribute("InsulinaNPH")]
		[Bindable(true)]
		public bool InsulinaNPH 
		{
			get { return GetColumnValue<bool>(Columns.InsulinaNPH); }
			set { SetColumnValue(Columns.InsulinaNPH, value); }
		}
		  
		[XmlAttribute("InsulinaRap")]
		[Bindable(true)]
		public bool InsulinaRap 
		{
			get { return GetColumnValue<bool>(Columns.InsulinaRap); }
			set { SetColumnValue(Columns.InsulinaRap, value); }
		}
		  
		[XmlAttribute("InsulinaAnalog")]
		[Bindable(true)]
		public bool InsulinaAnalog 
		{
			get { return GetColumnValue<bool>(Columns.InsulinaAnalog); }
			set { SetColumnValue(Columns.InsulinaAnalog, value); }
		}
		  
		[XmlAttribute("PresentacionInsulina")]
		[Bindable(true)]
		public int PresentacionInsulina 
		{
			get { return GetColumnValue<int>(Columns.PresentacionInsulina); }
			set { SetColumnValue(Columns.PresentacionInsulina, value); }
		}
		  
		[XmlAttribute("OtrasDrogas1")]
		[Bindable(true)]
		public string OtrasDrogas1 
		{
			get { return GetColumnValue<string>(Columns.OtrasDrogas1); }
			set { SetColumnValue(Columns.OtrasDrogas1, value); }
		}
		  
		[XmlAttribute("DosisODrogas1")]
		[Bindable(true)]
		public decimal DosisODrogas1 
		{
			get { return GetColumnValue<decimal>(Columns.DosisODrogas1); }
			set { SetColumnValue(Columns.DosisODrogas1, value); }
		}
		  
		[XmlAttribute("OtrasDrogras2")]
		[Bindable(true)]
		public string OtrasDrogras2 
		{
			get { return GetColumnValue<string>(Columns.OtrasDrogras2); }
			set { SetColumnValue(Columns.OtrasDrogras2, value); }
		}
		  
		[XmlAttribute("DosisODrogas2")]
		[Bindable(true)]
		public decimal DosisODrogas2 
		{
			get { return GetColumnValue<decimal>(Columns.DosisODrogas2); }
			set { SetColumnValue(Columns.DosisODrogas2, value); }
		}
		  
		[XmlAttribute("OtrosMedicam")]
		[Bindable(true)]
		public string OtrosMedicam 
		{
			get { return GetColumnValue<string>(Columns.OtrosMedicam); }
			set { SetColumnValue(Columns.OtrosMedicam, value); }
		}
		  
		[XmlAttribute("AutomonitoreoGLucemico")]
		[Bindable(true)]
		public int AutomonitoreoGLucemico 
		{
			get { return GetColumnValue<int>(Columns.AutomonitoreoGLucemico); }
			set { SetColumnValue(Columns.AutomonitoreoGLucemico, value); }
		}
		  
		[XmlAttribute("NroTirasSemana")]
		[Bindable(true)]
		public int NroTirasSemana 
		{
			get { return GetColumnValue<int>(Columns.NroTirasSemana); }
			set { SetColumnValue(Columns.NroTirasSemana, value); }
		}
		  
		[XmlAttribute("EducacionGrupalS")]
		[Bindable(true)]
		public bool EducacionGrupalS 
		{
			get { return GetColumnValue<bool>(Columns.EducacionGrupalS); }
			set { SetColumnValue(Columns.EducacionGrupalS, value); }
		}
		  
		[XmlAttribute("EducacionGrupalR")]
		[Bindable(true)]
		public bool EducacionGrupalR 
		{
			get { return GetColumnValue<bool>(Columns.EducacionGrupalR); }
			set { SetColumnValue(Columns.EducacionGrupalR, value); }
		}
		  
		[XmlAttribute("ConsultorioNutricionalS")]
		[Bindable(true)]
		public bool ConsultorioNutricionalS 
		{
			get { return GetColumnValue<bool>(Columns.ConsultorioNutricionalS); }
			set { SetColumnValue(Columns.ConsultorioNutricionalS, value); }
		}
		  
		[XmlAttribute("ConsultorioNutricionalR")]
		[Bindable(true)]
		public bool ConsultorioNutricionalR 
		{
			get { return GetColumnValue<bool>(Columns.ConsultorioNutricionalR); }
			set { SetColumnValue(Columns.ConsultorioNutricionalR, value); }
		}
		  
		[XmlAttribute("ConsultorioPodologicoS")]
		[Bindable(true)]
		public bool ConsultorioPodologicoS 
		{
			get { return GetColumnValue<bool>(Columns.ConsultorioPodologicoS); }
			set { SetColumnValue(Columns.ConsultorioPodologicoS, value); }
		}
		  
		[XmlAttribute("ConsultorioPodologicoR")]
		[Bindable(true)]
		public bool ConsultorioPodologicoR 
		{
			get { return GetColumnValue<bool>(Columns.ConsultorioPodologicoR); }
			set { SetColumnValue(Columns.ConsultorioPodologicoR, value); }
		}
		  
		[XmlAttribute("CardiologiaS")]
		[Bindable(true)]
		public bool CardiologiaS 
		{
			get { return GetColumnValue<bool>(Columns.CardiologiaS); }
			set { SetColumnValue(Columns.CardiologiaS, value); }
		}
		  
		[XmlAttribute("CardiologiaR")]
		[Bindable(true)]
		public bool CardiologiaR 
		{
			get { return GetColumnValue<bool>(Columns.CardiologiaR); }
			set { SetColumnValue(Columns.CardiologiaR, value); }
		}
		  
		[XmlAttribute("NefrologiaS")]
		[Bindable(true)]
		public bool NefrologiaS 
		{
			get { return GetColumnValue<bool>(Columns.NefrologiaS); }
			set { SetColumnValue(Columns.NefrologiaS, value); }
		}
		  
		[XmlAttribute("NefrologiaR")]
		[Bindable(true)]
		public bool NefrologiaR 
		{
			get { return GetColumnValue<bool>(Columns.NefrologiaR); }
			set { SetColumnValue(Columns.NefrologiaR, value); }
		}
		  
		[XmlAttribute("ClinicaMedicaS")]
		[Bindable(true)]
		public bool ClinicaMedicaS 
		{
			get { return GetColumnValue<bool>(Columns.ClinicaMedicaS); }
			set { SetColumnValue(Columns.ClinicaMedicaS, value); }
		}
		  
		[XmlAttribute("ClinicaMedicaR")]
		[Bindable(true)]
		public bool ClinicaMedicaR 
		{
			get { return GetColumnValue<bool>(Columns.ClinicaMedicaR); }
			set { SetColumnValue(Columns.ClinicaMedicaR, value); }
		}
		  
		[XmlAttribute("OftalmologiaS")]
		[Bindable(true)]
		public bool OftalmologiaS 
		{
			get { return GetColumnValue<bool>(Columns.OftalmologiaS); }
			set { SetColumnValue(Columns.OftalmologiaS, value); }
		}
		  
		[XmlAttribute("OftalmologiaR")]
		[Bindable(true)]
		public bool OftalmologiaR 
		{
			get { return GetColumnValue<bool>(Columns.OftalmologiaR); }
			set { SetColumnValue(Columns.OftalmologiaR, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("Cerrar")]
		[Bindable(true)]
		public bool Cerrar 
		{
			get { return GetColumnValue<bool>(Columns.Cerrar); }
			set { SetColumnValue(Columns.Cerrar, value); }
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
		  
		[XmlAttribute("UnidadCOrina")]
		[Bindable(true)]
		public string UnidadCOrina 
		{
			get { return GetColumnValue<string>(Columns.UnidadCOrina); }
			set { SetColumnValue(Columns.UnidadCOrina, value); }
		}
		  
		[XmlAttribute("RelacionCOrinaSolicitado")]
		[Bindable(true)]
		public bool RelacionCOrinaSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.RelacionCOrinaSolicitado); }
			set { SetColumnValue(Columns.RelacionCOrinaSolicitado, value); }
		}
		  
		[XmlAttribute("NombreInsulina")]
		[Bindable(true)]
		public string NombreInsulina 
		{
			get { return GetColumnValue<string>(Columns.NombreInsulina); }
			set { SetColumnValue(Columns.NombreInsulina, value); }
		}
		  
		[XmlAttribute("UnidadesDiaINPH")]
		[Bindable(true)]
		public int UnidadesDiaINPH 
		{
			get { return GetColumnValue<int>(Columns.UnidadesDiaINPH); }
			set { SetColumnValue(Columns.UnidadesDiaINPH, value); }
		}
		  
		[XmlAttribute("UnidadesDiaIRap")]
		[Bindable(true)]
		public int UnidadesDiaIRap 
		{
			get { return GetColumnValue<int>(Columns.UnidadesDiaIRap); }
			set { SetColumnValue(Columns.UnidadesDiaIRap, value); }
		}
		  
		[XmlAttribute("UnidadesDiaIAnalog")]
		[Bindable(true)]
		public int UnidadesDiaIAnalog 
		{
			get { return GetColumnValue<int>(Columns.UnidadesDiaIAnalog); }
			set { SetColumnValue(Columns.UnidadesDiaIAnalog, value); }
		}
		  
		[XmlAttribute("Hematities")]
		[Bindable(true)]
		public string Hematities 
		{
			get { return GetColumnValue<string>(Columns.Hematities); }
			set { SetColumnValue(Columns.Hematities, value); }
		}
		  
		[XmlAttribute("HematitiesSolicitado")]
		[Bindable(true)]
		public bool HematitiesSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.HematitiesSolicitado); }
			set { SetColumnValue(Columns.HematitiesSolicitado, value); }
		}
		  
		[XmlAttribute("FiltradoGlomerular")]
		[Bindable(true)]
		public decimal FiltradoGlomerular 
		{
			get { return GetColumnValue<decimal>(Columns.FiltradoGlomerular); }
			set { SetColumnValue(Columns.FiltradoGlomerular, value); }
		}
		  
		[XmlAttribute("FiltradoGlomSolicitado")]
		[Bindable(true)]
		public bool FiltradoGlomSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.FiltradoGlomSolicitado); }
			set { SetColumnValue(Columns.FiltradoGlomSolicitado, value); }
		}
		  
		[XmlAttribute("IUProteinaCreatinina")]
		[Bindable(true)]
		public decimal IUProteinaCreatinina 
		{
			get { return GetColumnValue<decimal>(Columns.IUProteinaCreatinina); }
			set { SetColumnValue(Columns.IUProteinaCreatinina, value); }
		}
		  
		[XmlAttribute("IUProtCreatininaSolicitado")]
		[Bindable(true)]
		public bool IUProtCreatininaSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.IUProtCreatininaSolicitado); }
			set { SetColumnValue(Columns.IUProtCreatininaSolicitado, value); }
		}
		  
		[XmlAttribute("IUAlbuminaCreatinina")]
		[Bindable(true)]
		public decimal IUAlbuminaCreatinina 
		{
			get { return GetColumnValue<decimal>(Columns.IUAlbuminaCreatinina); }
			set { SetColumnValue(Columns.IUAlbuminaCreatinina, value); }
		}
		  
		[XmlAttribute("IUAlbumCreatinSolicitado")]
		[Bindable(true)]
		public bool IUAlbumCreatinSolicitado 
		{
			get { return GetColumnValue<bool>(Columns.IUAlbumCreatinSolicitado); }
			set { SetColumnValue(Columns.IUAlbumCreatinSolicitado, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.RemRelMedicamentoSeguimientoCollection colRemRelMedicamentoSeguimientoRecords;
		public DalSic.RemRelMedicamentoSeguimientoCollection RemRelMedicamentoSeguimientoRecords
		{
			get
			{
				if(colRemRelMedicamentoSeguimientoRecords == null)
				{
					colRemRelMedicamentoSeguimientoRecords = new DalSic.RemRelMedicamentoSeguimientoCollection().Where(RemRelMedicamentoSeguimiento.Columns.IdSeguimiento, IdSeguimiento).Load();
					colRemRelMedicamentoSeguimientoRecords.ListChanged += new ListChangedEventHandler(colRemRelMedicamentoSeguimientoRecords_ListChanged);
				}
				return colRemRelMedicamentoSeguimientoRecords;			
			}
			set 
			{ 
					colRemRelMedicamentoSeguimientoRecords = value; 
					colRemRelMedicamentoSeguimientoRecords.ListChanged += new ListChangedEventHandler(colRemRelMedicamentoSeguimientoRecords_ListChanged);
			}
		}
		
		void colRemRelMedicamentoSeguimientoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemRelMedicamentoSeguimientoRecords[e.NewIndex].IdSeguimiento = IdSeguimiento;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a RemClasificacion ActiveRecord object related to this RemSeguimiento
		/// 
		/// </summary>
		public DalSic.RemClasificacion RemClasificacion
		{
			get { return DalSic.RemClasificacion.FetchByID(this.IdClasificacion); }
			set { SetColumnValue("idClasificacion", value.IdClasificacion); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this RemSeguimiento
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdClasificacion,int varIdEfector,int varIdPaciente,int varEdad,DateTime varFechaControl,decimal varPeso,decimal varTalla,decimal varImc,int varTAS,int varTAD,int varExamenPiesCompleto,int varPlanAlimentario,int varActividadFisicaAdecuada,decimal varCircunferenciaAbdominal,DateTime varFechaLab,decimal varGlucemia,string varUnidadGlucemia,bool varGlucemiaSolicitada,decimal varHbAc1,bool varHbAc1solicitado,decimal varHematocrito,bool varHemtocritoSolicitado,decimal varColesterolTotal,bool varColeterolSolicitado,string varUnidadColTotal,decimal varHdl,string varUnidadHDL,bool varHdlSolicitado,decimal varLdl,string varUnidadLDL,bool varLdlSolicitado,decimal varTgl,string varUnidadTGL,bool varTglSolicitado,decimal varCreatininemia,string varUnidadCreatininemia,bool varCreatininemiSolicitada,decimal varPtog,string varUnidadPTOG,bool varPtogSolicitado,decimal varMicroalbuminuria,bool varMicroalbuminuriaSolicitada,decimal varClaerence,bool varClearenceSolicitado,decimal varRelacionCOrina,string varOtrosLab,bool varInsulinaNPH,bool varInsulinaRap,bool varInsulinaAnalog,int varPresentacionInsulina,string varOtrasDrogas1,decimal varDosisODrogas1,string varOtrasDrogras2,decimal varDosisODrogas2,string varOtrosMedicam,int varAutomonitoreoGLucemico,int varNroTirasSemana,bool varEducacionGrupalS,bool varEducacionGrupalR,bool varConsultorioNutricionalS,bool varConsultorioNutricionalR,bool varConsultorioPodologicoS,bool varConsultorioPodologicoR,bool varCardiologiaS,bool varCardiologiaR,bool varNefrologiaS,bool varNefrologiaR,bool varClinicaMedicaS,bool varClinicaMedicaR,bool varOftalmologiaS,bool varOftalmologiaR,int varIdProfesional,bool varCerrar,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,string varUnidadCOrina,bool varRelacionCOrinaSolicitado,string varNombreInsulina,int varUnidadesDiaINPH,int varUnidadesDiaIRap,int varUnidadesDiaIAnalog,string varHematities,bool varHematitiesSolicitado,decimal varFiltradoGlomerular,bool varFiltradoGlomSolicitado,decimal varIUProteinaCreatinina,bool varIUProtCreatininaSolicitado,decimal varIUAlbuminaCreatinina,bool varIUAlbumCreatinSolicitado)
		{
			RemSeguimiento item = new RemSeguimiento();
			
			item.IdClasificacion = varIdClasificacion;
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.FechaControl = varFechaControl;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.Imc = varImc;
			
			item.TAS = varTAS;
			
			item.TAD = varTAD;
			
			item.ExamenPiesCompleto = varExamenPiesCompleto;
			
			item.PlanAlimentario = varPlanAlimentario;
			
			item.ActividadFisicaAdecuada = varActividadFisicaAdecuada;
			
			item.CircunferenciaAbdominal = varCircunferenciaAbdominal;
			
			item.FechaLab = varFechaLab;
			
			item.Glucemia = varGlucemia;
			
			item.UnidadGlucemia = varUnidadGlucemia;
			
			item.GlucemiaSolicitada = varGlucemiaSolicitada;
			
			item.HbAc1 = varHbAc1;
			
			item.HbAc1solicitado = varHbAc1solicitado;
			
			item.Hematocrito = varHematocrito;
			
			item.HemtocritoSolicitado = varHemtocritoSolicitado;
			
			item.ColesterolTotal = varColesterolTotal;
			
			item.ColeterolSolicitado = varColeterolSolicitado;
			
			item.UnidadColTotal = varUnidadColTotal;
			
			item.Hdl = varHdl;
			
			item.UnidadHDL = varUnidadHDL;
			
			item.HdlSolicitado = varHdlSolicitado;
			
			item.Ldl = varLdl;
			
			item.UnidadLDL = varUnidadLDL;
			
			item.LdlSolicitado = varLdlSolicitado;
			
			item.Tgl = varTgl;
			
			item.UnidadTGL = varUnidadTGL;
			
			item.TglSolicitado = varTglSolicitado;
			
			item.Creatininemia = varCreatininemia;
			
			item.UnidadCreatininemia = varUnidadCreatininemia;
			
			item.CreatininemiSolicitada = varCreatininemiSolicitada;
			
			item.Ptog = varPtog;
			
			item.UnidadPTOG = varUnidadPTOG;
			
			item.PtogSolicitado = varPtogSolicitado;
			
			item.Microalbuminuria = varMicroalbuminuria;
			
			item.MicroalbuminuriaSolicitada = varMicroalbuminuriaSolicitada;
			
			item.Claerence = varClaerence;
			
			item.ClearenceSolicitado = varClearenceSolicitado;
			
			item.RelacionCOrina = varRelacionCOrina;
			
			item.OtrosLab = varOtrosLab;
			
			item.InsulinaNPH = varInsulinaNPH;
			
			item.InsulinaRap = varInsulinaRap;
			
			item.InsulinaAnalog = varInsulinaAnalog;
			
			item.PresentacionInsulina = varPresentacionInsulina;
			
			item.OtrasDrogas1 = varOtrasDrogas1;
			
			item.DosisODrogas1 = varDosisODrogas1;
			
			item.OtrasDrogras2 = varOtrasDrogras2;
			
			item.DosisODrogas2 = varDosisODrogas2;
			
			item.OtrosMedicam = varOtrosMedicam;
			
			item.AutomonitoreoGLucemico = varAutomonitoreoGLucemico;
			
			item.NroTirasSemana = varNroTirasSemana;
			
			item.EducacionGrupalS = varEducacionGrupalS;
			
			item.EducacionGrupalR = varEducacionGrupalR;
			
			item.ConsultorioNutricionalS = varConsultorioNutricionalS;
			
			item.ConsultorioNutricionalR = varConsultorioNutricionalR;
			
			item.ConsultorioPodologicoS = varConsultorioPodologicoS;
			
			item.ConsultorioPodologicoR = varConsultorioPodologicoR;
			
			item.CardiologiaS = varCardiologiaS;
			
			item.CardiologiaR = varCardiologiaR;
			
			item.NefrologiaS = varNefrologiaS;
			
			item.NefrologiaR = varNefrologiaR;
			
			item.ClinicaMedicaS = varClinicaMedicaS;
			
			item.ClinicaMedicaR = varClinicaMedicaR;
			
			item.OftalmologiaS = varOftalmologiaS;
			
			item.OftalmologiaR = varOftalmologiaR;
			
			item.IdProfesional = varIdProfesional;
			
			item.Cerrar = varCerrar;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.UnidadCOrina = varUnidadCOrina;
			
			item.RelacionCOrinaSolicitado = varRelacionCOrinaSolicitado;
			
			item.NombreInsulina = varNombreInsulina;
			
			item.UnidadesDiaINPH = varUnidadesDiaINPH;
			
			item.UnidadesDiaIRap = varUnidadesDiaIRap;
			
			item.UnidadesDiaIAnalog = varUnidadesDiaIAnalog;
			
			item.Hematities = varHematities;
			
			item.HematitiesSolicitado = varHematitiesSolicitado;
			
			item.FiltradoGlomerular = varFiltradoGlomerular;
			
			item.FiltradoGlomSolicitado = varFiltradoGlomSolicitado;
			
			item.IUProteinaCreatinina = varIUProteinaCreatinina;
			
			item.IUProtCreatininaSolicitado = varIUProtCreatininaSolicitado;
			
			item.IUAlbuminaCreatinina = varIUAlbuminaCreatinina;
			
			item.IUAlbumCreatinSolicitado = varIUAlbumCreatinSolicitado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSeguimiento,int varIdClasificacion,int varIdEfector,int varIdPaciente,int varEdad,DateTime varFechaControl,decimal varPeso,decimal varTalla,decimal varImc,int varTAS,int varTAD,int varExamenPiesCompleto,int varPlanAlimentario,int varActividadFisicaAdecuada,decimal varCircunferenciaAbdominal,DateTime varFechaLab,decimal varGlucemia,string varUnidadGlucemia,bool varGlucemiaSolicitada,decimal varHbAc1,bool varHbAc1solicitado,decimal varHematocrito,bool varHemtocritoSolicitado,decimal varColesterolTotal,bool varColeterolSolicitado,string varUnidadColTotal,decimal varHdl,string varUnidadHDL,bool varHdlSolicitado,decimal varLdl,string varUnidadLDL,bool varLdlSolicitado,decimal varTgl,string varUnidadTGL,bool varTglSolicitado,decimal varCreatininemia,string varUnidadCreatininemia,bool varCreatininemiSolicitada,decimal varPtog,string varUnidadPTOG,bool varPtogSolicitado,decimal varMicroalbuminuria,bool varMicroalbuminuriaSolicitada,decimal varClaerence,bool varClearenceSolicitado,decimal varRelacionCOrina,string varOtrosLab,bool varInsulinaNPH,bool varInsulinaRap,bool varInsulinaAnalog,int varPresentacionInsulina,string varOtrasDrogas1,decimal varDosisODrogas1,string varOtrasDrogras2,decimal varDosisODrogas2,string varOtrosMedicam,int varAutomonitoreoGLucemico,int varNroTirasSemana,bool varEducacionGrupalS,bool varEducacionGrupalR,bool varConsultorioNutricionalS,bool varConsultorioNutricionalR,bool varConsultorioPodologicoS,bool varConsultorioPodologicoR,bool varCardiologiaS,bool varCardiologiaR,bool varNefrologiaS,bool varNefrologiaR,bool varClinicaMedicaS,bool varClinicaMedicaR,bool varOftalmologiaS,bool varOftalmologiaR,int varIdProfesional,bool varCerrar,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,string varUnidadCOrina,bool varRelacionCOrinaSolicitado,string varNombreInsulina,int varUnidadesDiaINPH,int varUnidadesDiaIRap,int varUnidadesDiaIAnalog,string varHematities,bool varHematitiesSolicitado,decimal varFiltradoGlomerular,bool varFiltradoGlomSolicitado,decimal varIUProteinaCreatinina,bool varIUProtCreatininaSolicitado,decimal varIUAlbuminaCreatinina,bool varIUAlbumCreatinSolicitado)
		{
			RemSeguimiento item = new RemSeguimiento();
			
				item.IdSeguimiento = varIdSeguimiento;
			
				item.IdClasificacion = varIdClasificacion;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.FechaControl = varFechaControl;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.Imc = varImc;
			
				item.TAS = varTAS;
			
				item.TAD = varTAD;
			
				item.ExamenPiesCompleto = varExamenPiesCompleto;
			
				item.PlanAlimentario = varPlanAlimentario;
			
				item.ActividadFisicaAdecuada = varActividadFisicaAdecuada;
			
				item.CircunferenciaAbdominal = varCircunferenciaAbdominal;
			
				item.FechaLab = varFechaLab;
			
				item.Glucemia = varGlucemia;
			
				item.UnidadGlucemia = varUnidadGlucemia;
			
				item.GlucemiaSolicitada = varGlucemiaSolicitada;
			
				item.HbAc1 = varHbAc1;
			
				item.HbAc1solicitado = varHbAc1solicitado;
			
				item.Hematocrito = varHematocrito;
			
				item.HemtocritoSolicitado = varHemtocritoSolicitado;
			
				item.ColesterolTotal = varColesterolTotal;
			
				item.ColeterolSolicitado = varColeterolSolicitado;
			
				item.UnidadColTotal = varUnidadColTotal;
			
				item.Hdl = varHdl;
			
				item.UnidadHDL = varUnidadHDL;
			
				item.HdlSolicitado = varHdlSolicitado;
			
				item.Ldl = varLdl;
			
				item.UnidadLDL = varUnidadLDL;
			
				item.LdlSolicitado = varLdlSolicitado;
			
				item.Tgl = varTgl;
			
				item.UnidadTGL = varUnidadTGL;
			
				item.TglSolicitado = varTglSolicitado;
			
				item.Creatininemia = varCreatininemia;
			
				item.UnidadCreatininemia = varUnidadCreatininemia;
			
				item.CreatininemiSolicitada = varCreatininemiSolicitada;
			
				item.Ptog = varPtog;
			
				item.UnidadPTOG = varUnidadPTOG;
			
				item.PtogSolicitado = varPtogSolicitado;
			
				item.Microalbuminuria = varMicroalbuminuria;
			
				item.MicroalbuminuriaSolicitada = varMicroalbuminuriaSolicitada;
			
				item.Claerence = varClaerence;
			
				item.ClearenceSolicitado = varClearenceSolicitado;
			
				item.RelacionCOrina = varRelacionCOrina;
			
				item.OtrosLab = varOtrosLab;
			
				item.InsulinaNPH = varInsulinaNPH;
			
				item.InsulinaRap = varInsulinaRap;
			
				item.InsulinaAnalog = varInsulinaAnalog;
			
				item.PresentacionInsulina = varPresentacionInsulina;
			
				item.OtrasDrogas1 = varOtrasDrogas1;
			
				item.DosisODrogas1 = varDosisODrogas1;
			
				item.OtrasDrogras2 = varOtrasDrogras2;
			
				item.DosisODrogas2 = varDosisODrogas2;
			
				item.OtrosMedicam = varOtrosMedicam;
			
				item.AutomonitoreoGLucemico = varAutomonitoreoGLucemico;
			
				item.NroTirasSemana = varNroTirasSemana;
			
				item.EducacionGrupalS = varEducacionGrupalS;
			
				item.EducacionGrupalR = varEducacionGrupalR;
			
				item.ConsultorioNutricionalS = varConsultorioNutricionalS;
			
				item.ConsultorioNutricionalR = varConsultorioNutricionalR;
			
				item.ConsultorioPodologicoS = varConsultorioPodologicoS;
			
				item.ConsultorioPodologicoR = varConsultorioPodologicoR;
			
				item.CardiologiaS = varCardiologiaS;
			
				item.CardiologiaR = varCardiologiaR;
			
				item.NefrologiaS = varNefrologiaS;
			
				item.NefrologiaR = varNefrologiaR;
			
				item.ClinicaMedicaS = varClinicaMedicaS;
			
				item.ClinicaMedicaR = varClinicaMedicaR;
			
				item.OftalmologiaS = varOftalmologiaS;
			
				item.OftalmologiaR = varOftalmologiaR;
			
				item.IdProfesional = varIdProfesional;
			
				item.Cerrar = varCerrar;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.UnidadCOrina = varUnidadCOrina;
			
				item.RelacionCOrinaSolicitado = varRelacionCOrinaSolicitado;
			
				item.NombreInsulina = varNombreInsulina;
			
				item.UnidadesDiaINPH = varUnidadesDiaINPH;
			
				item.UnidadesDiaIRap = varUnidadesDiaIRap;
			
				item.UnidadesDiaIAnalog = varUnidadesDiaIAnalog;
			
				item.Hematities = varHematities;
			
				item.HematitiesSolicitado = varHematitiesSolicitado;
			
				item.FiltradoGlomerular = varFiltradoGlomerular;
			
				item.FiltradoGlomSolicitado = varFiltradoGlomSolicitado;
			
				item.IUProteinaCreatinina = varIUProteinaCreatinina;
			
				item.IUProtCreatininaSolicitado = varIUProtCreatininaSolicitado;
			
				item.IUAlbuminaCreatinina = varIUAlbuminaCreatinina;
			
				item.IUAlbumCreatinSolicitado = varIUAlbumCreatinSolicitado;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSeguimientoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ImcColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn TASColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TADColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenPiesCompletoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn PlanAlimentarioColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ActividadFisicaAdecuadaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn CircunferenciaAbdominalColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaLabColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadGlucemiaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaSolicitadaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn HbAc1Column
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn HbAc1solicitadoColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn HematocritoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn HemtocritoSolicitadoColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ColesterolTotalColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ColeterolSolicitadoColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadColTotalColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn HdlColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadHDLColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn HdlSolicitadoColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn LdlColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadLDLColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn LdlSolicitadoColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn TglColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadTGLColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn TglSolicitadoColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatininemiaColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadCreatininemiaColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatininemiSolicitadaColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn PtogColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadPTOGColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn PtogSolicitadoColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        public static TableSchema.TableColumn MicroalbuminuriaColumn
        {
            get { return Schema.Columns[41]; }
        }
        
        
        
        public static TableSchema.TableColumn MicroalbuminuriaSolicitadaColumn
        {
            get { return Schema.Columns[42]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaerenceColumn
        {
            get { return Schema.Columns[43]; }
        }
        
        
        
        public static TableSchema.TableColumn ClearenceSolicitadoColumn
        {
            get { return Schema.Columns[44]; }
        }
        
        
        
        public static TableSchema.TableColumn RelacionCOrinaColumn
        {
            get { return Schema.Columns[45]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosLabColumn
        {
            get { return Schema.Columns[46]; }
        }
        
        
        
        public static TableSchema.TableColumn InsulinaNPHColumn
        {
            get { return Schema.Columns[47]; }
        }
        
        
        
        public static TableSchema.TableColumn InsulinaRapColumn
        {
            get { return Schema.Columns[48]; }
        }
        
        
        
        public static TableSchema.TableColumn InsulinaAnalogColumn
        {
            get { return Schema.Columns[49]; }
        }
        
        
        
        public static TableSchema.TableColumn PresentacionInsulinaColumn
        {
            get { return Schema.Columns[50]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasDrogas1Column
        {
            get { return Schema.Columns[51]; }
        }
        
        
        
        public static TableSchema.TableColumn DosisODrogas1Column
        {
            get { return Schema.Columns[52]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasDrogras2Column
        {
            get { return Schema.Columns[53]; }
        }
        
        
        
        public static TableSchema.TableColumn DosisODrogas2Column
        {
            get { return Schema.Columns[54]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosMedicamColumn
        {
            get { return Schema.Columns[55]; }
        }
        
        
        
        public static TableSchema.TableColumn AutomonitoreoGLucemicoColumn
        {
            get { return Schema.Columns[56]; }
        }
        
        
        
        public static TableSchema.TableColumn NroTirasSemanaColumn
        {
            get { return Schema.Columns[57]; }
        }
        
        
        
        public static TableSchema.TableColumn EducacionGrupalSColumn
        {
            get { return Schema.Columns[58]; }
        }
        
        
        
        public static TableSchema.TableColumn EducacionGrupalRColumn
        {
            get { return Schema.Columns[59]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsultorioNutricionalSColumn
        {
            get { return Schema.Columns[60]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsultorioNutricionalRColumn
        {
            get { return Schema.Columns[61]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsultorioPodologicoSColumn
        {
            get { return Schema.Columns[62]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsultorioPodologicoRColumn
        {
            get { return Schema.Columns[63]; }
        }
        
        
        
        public static TableSchema.TableColumn CardiologiaSColumn
        {
            get { return Schema.Columns[64]; }
        }
        
        
        
        public static TableSchema.TableColumn CardiologiaRColumn
        {
            get { return Schema.Columns[65]; }
        }
        
        
        
        public static TableSchema.TableColumn NefrologiaSColumn
        {
            get { return Schema.Columns[66]; }
        }
        
        
        
        public static TableSchema.TableColumn NefrologiaRColumn
        {
            get { return Schema.Columns[67]; }
        }
        
        
        
        public static TableSchema.TableColumn ClinicaMedicaSColumn
        {
            get { return Schema.Columns[68]; }
        }
        
        
        
        public static TableSchema.TableColumn ClinicaMedicaRColumn
        {
            get { return Schema.Columns[69]; }
        }
        
        
        
        public static TableSchema.TableColumn OftalmologiaSColumn
        {
            get { return Schema.Columns[70]; }
        }
        
        
        
        public static TableSchema.TableColumn OftalmologiaRColumn
        {
            get { return Schema.Columns[71]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[72]; }
        }
        
        
        
        public static TableSchema.TableColumn CerrarColumn
        {
            get { return Schema.Columns[73]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[74]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[75]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[76]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[77]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadCOrinaColumn
        {
            get { return Schema.Columns[78]; }
        }
        
        
        
        public static TableSchema.TableColumn RelacionCOrinaSolicitadoColumn
        {
            get { return Schema.Columns[79]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreInsulinaColumn
        {
            get { return Schema.Columns[80]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadesDiaINPHColumn
        {
            get { return Schema.Columns[81]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadesDiaIRapColumn
        {
            get { return Schema.Columns[82]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadesDiaIAnalogColumn
        {
            get { return Schema.Columns[83]; }
        }
        
        
        
        public static TableSchema.TableColumn HematitiesColumn
        {
            get { return Schema.Columns[84]; }
        }
        
        
        
        public static TableSchema.TableColumn HematitiesSolicitadoColumn
        {
            get { return Schema.Columns[85]; }
        }
        
        
        
        public static TableSchema.TableColumn FiltradoGlomerularColumn
        {
            get { return Schema.Columns[86]; }
        }
        
        
        
        public static TableSchema.TableColumn FiltradoGlomSolicitadoColumn
        {
            get { return Schema.Columns[87]; }
        }
        
        
        
        public static TableSchema.TableColumn IUProteinaCreatininaColumn
        {
            get { return Schema.Columns[88]; }
        }
        
        
        
        public static TableSchema.TableColumn IUProtCreatininaSolicitadoColumn
        {
            get { return Schema.Columns[89]; }
        }
        
        
        
        public static TableSchema.TableColumn IUAlbuminaCreatininaColumn
        {
            get { return Schema.Columns[90]; }
        }
        
        
        
        public static TableSchema.TableColumn IUAlbumCreatinSolicitadoColumn
        {
            get { return Schema.Columns[91]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSeguimiento = @"idSeguimiento";
			 public static string IdClasificacion = @"idClasificacion";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string FechaControl = @"fechaControl";
			 public static string Peso = @"peso";
			 public static string Talla = @"talla";
			 public static string Imc = @"Imc";
			 public static string TAS = @"tAS";
			 public static string TAD = @"tAD";
			 public static string ExamenPiesCompleto = @"examenPiesCompleto";
			 public static string PlanAlimentario = @"planAlimentario";
			 public static string ActividadFisicaAdecuada = @"actividadFisicaAdecuada";
			 public static string CircunferenciaAbdominal = @"circunferenciaAbdominal";
			 public static string FechaLab = @"fechaLab";
			 public static string Glucemia = @"glucemia";
			 public static string UnidadGlucemia = @"unidadGlucemia";
			 public static string GlucemiaSolicitada = @"glucemiaSolicitada";
			 public static string HbAc1 = @"HbAc1";
			 public static string HbAc1solicitado = @"HbAc1solicitado";
			 public static string Hematocrito = @"hematocrito";
			 public static string HemtocritoSolicitado = @"hemtocritoSolicitado";
			 public static string ColesterolTotal = @"colesterolTotal";
			 public static string ColeterolSolicitado = @"coleterolSolicitado";
			 public static string UnidadColTotal = @"unidadColTotal";
			 public static string Hdl = @"HDL";
			 public static string UnidadHDL = @"unidadHDL";
			 public static string HdlSolicitado = @"HdlSolicitado";
			 public static string Ldl = @"LDL";
			 public static string UnidadLDL = @"unidadLDL";
			 public static string LdlSolicitado = @"LdlSolicitado";
			 public static string Tgl = @"TGL";
			 public static string UnidadTGL = @"unidadTGL";
			 public static string TglSolicitado = @"TglSolicitado";
			 public static string Creatininemia = @"creatininemia";
			 public static string UnidadCreatininemia = @"unidadCreatininemia";
			 public static string CreatininemiSolicitada = @"creatininemiSolicitada";
			 public static string Ptog = @"PTOG";
			 public static string UnidadPTOG = @"unidadPTOG";
			 public static string PtogSolicitado = @"PtogSolicitado";
			 public static string Microalbuminuria = @"microalbuminuria";
			 public static string MicroalbuminuriaSolicitada = @"microalbuminuriaSolicitada";
			 public static string Claerence = @"claerence";
			 public static string ClearenceSolicitado = @"clearenceSolicitado";
			 public static string RelacionCOrina = @"relacionCOrina";
			 public static string OtrosLab = @"otrosLab";
			 public static string InsulinaNPH = @"insulinaNPH";
			 public static string InsulinaRap = @"insulinaRap";
			 public static string InsulinaAnalog = @"insulinaAnalog";
			 public static string PresentacionInsulina = @"presentacionInsulina";
			 public static string OtrasDrogas1 = @"otrasDrogas1";
			 public static string DosisODrogas1 = @"dosisODrogas1";
			 public static string OtrasDrogras2 = @"otrasDrogras2";
			 public static string DosisODrogas2 = @"dosisODrogas2";
			 public static string OtrosMedicam = @"otrosMedicam";
			 public static string AutomonitoreoGLucemico = @"automonitoreoGLucemico";
			 public static string NroTirasSemana = @"nroTirasSemana";
			 public static string EducacionGrupalS = @"educacionGrupalS";
			 public static string EducacionGrupalR = @"educacionGrupalR";
			 public static string ConsultorioNutricionalS = @"consultorioNutricionalS";
			 public static string ConsultorioNutricionalR = @"consultorioNutricionalR";
			 public static string ConsultorioPodologicoS = @"consultorioPodologicoS";
			 public static string ConsultorioPodologicoR = @"consultorioPodologicoR";
			 public static string CardiologiaS = @"cardiologiaS";
			 public static string CardiologiaR = @"cardiologiaR";
			 public static string NefrologiaS = @"nefrologiaS";
			 public static string NefrologiaR = @"nefrologiaR";
			 public static string ClinicaMedicaS = @"clinicaMedicaS";
			 public static string ClinicaMedicaR = @"clinicaMedicaR";
			 public static string OftalmologiaS = @"oftalmologiaS";
			 public static string OftalmologiaR = @"oftalmologiaR";
			 public static string IdProfesional = @"idProfesional";
			 public static string Cerrar = @"cerrar";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string UnidadCOrina = @"unidadCOrina";
			 public static string RelacionCOrinaSolicitado = @"relacionCOrinaSolicitado";
			 public static string NombreInsulina = @"nombreInsulina";
			 public static string UnidadesDiaINPH = @"unidadesDiaINPH";
			 public static string UnidadesDiaIRap = @"unidadesDiaIRap";
			 public static string UnidadesDiaIAnalog = @"unidadesDiaIAnalog";
			 public static string Hematities = @"hematities";
			 public static string HematitiesSolicitado = @"hematitiesSolicitado";
			 public static string FiltradoGlomerular = @"filtradoGlomerular";
			 public static string FiltradoGlomSolicitado = @"filtradoGlomSolicitado";
			 public static string IUProteinaCreatinina = @"iUProteinaCreatinina";
			 public static string IUProtCreatininaSolicitado = @"iUProtCreatininaSolicitado";
			 public static string IUAlbuminaCreatinina = @"iUAlbuminaCreatinina";
			 public static string IUAlbumCreatinSolicitado = @"iUAlbumCreatinSolicitado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colRemRelMedicamentoSeguimientoRecords != null)
                {
                    foreach (DalSic.RemRelMedicamentoSeguimiento item in colRemRelMedicamentoSeguimientoRecords)
                    {
                        if (item.IdSeguimiento != IdSeguimiento)
                        {
                            item.IdSeguimiento = IdSeguimiento;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colRemRelMedicamentoSeguimientoRecords != null)
                {
                    colRemRelMedicamentoSeguimientoRecords.SaveAll();
               }
		}
        #endregion
	}
}
