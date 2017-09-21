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
	/// Strongly-typed collection for the RemClasificacion class.
	/// </summary>
    [Serializable]
	public partial class RemClasificacionCollection : ActiveList<RemClasificacion, RemClasificacionCollection>
	{	   
		public RemClasificacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemClasificacionCollection</returns>
		public RemClasificacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemClasificacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_Clasificacion table.
	/// </summary>
	[Serializable]
	public partial class RemClasificacion : ActiveRecord<RemClasificacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemClasificacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemClasificacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemClasificacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemClasificacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_Clasificacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "idClasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = true;
				colvarIdClasificacion.IsNullable = false;
				colvarIdClasificacion.IsPrimaryKey = true;
				colvarIdClasificacion.IsForeignKey = false;
				colvarIdClasificacion.IsReadOnly = false;
				colvarIdClasificacion.DefaultSetting = @"";
				colvarIdClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdClasificacion);
				
				TableSchema.TableColumn colvarIdFormulario = new TableSchema.TableColumn(schema);
				colvarIdFormulario.ColumnName = "idFormulario";
				colvarIdFormulario.DataType = DbType.Int32;
				colvarIdFormulario.MaxLength = 0;
				colvarIdFormulario.AutoIncrement = false;
				colvarIdFormulario.IsNullable = false;
				colvarIdFormulario.IsPrimaryKey = false;
				colvarIdFormulario.IsForeignKey = true;
				colvarIdFormulario.IsReadOnly = false;
				
						colvarIdFormulario.DefaultSetting = @"((0))";
				
					colvarIdFormulario.ForeignKeyTableName = "Rem_Formulario";
				schema.Columns.Add(colvarIdFormulario);
				
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
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
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
				
				TableSchema.TableColumn colvarNroClasificacion = new TableSchema.TableColumn(schema);
				colvarNroClasificacion.ColumnName = "nroClasificacion";
				colvarNroClasificacion.DataType = DbType.Int32;
				colvarNroClasificacion.MaxLength = 0;
				colvarNroClasificacion.AutoIncrement = false;
				colvarNroClasificacion.IsNullable = false;
				colvarNroClasificacion.IsPrimaryKey = false;
				colvarNroClasificacion.IsForeignKey = false;
				colvarNroClasificacion.IsReadOnly = false;
				
						colvarNroClasificacion.DefaultSetting = @"((0))";
				colvarNroClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroClasificacion);
				
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
				
				TableSchema.TableColumn colvarExamenPies = new TableSchema.TableColumn(schema);
				colvarExamenPies.ColumnName = "examenPies";
				colvarExamenPies.DataType = DbType.Int32;
				colvarExamenPies.MaxLength = 0;
				colvarExamenPies.AutoIncrement = false;
				colvarExamenPies.IsNullable = false;
				colvarExamenPies.IsPrimaryKey = false;
				colvarExamenPies.IsForeignKey = false;
				colvarExamenPies.IsReadOnly = false;
				
						colvarExamenPies.DefaultSetting = @"((0))";
				colvarExamenPies.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExamenPies);
				
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
				
				TableSchema.TableColumn colvarActividadFisica = new TableSchema.TableColumn(schema);
				colvarActividadFisica.ColumnName = "actividadFisica";
				colvarActividadFisica.DataType = DbType.Int32;
				colvarActividadFisica.MaxLength = 0;
				colvarActividadFisica.AutoIncrement = false;
				colvarActividadFisica.IsNullable = false;
				colvarActividadFisica.IsPrimaryKey = false;
				colvarActividadFisica.IsForeignKey = false;
				colvarActividadFisica.IsReadOnly = false;
				
						colvarActividadFisica.DefaultSetting = @"((0))";
				colvarActividadFisica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActividadFisica);
				
				TableSchema.TableColumn colvarAFAdecuada = new TableSchema.TableColumn(schema);
				colvarAFAdecuada.ColumnName = "aFAdecuada";
				colvarAFAdecuada.DataType = DbType.Boolean;
				colvarAFAdecuada.MaxLength = 0;
				colvarAFAdecuada.AutoIncrement = false;
				colvarAFAdecuada.IsNullable = false;
				colvarAFAdecuada.IsPrimaryKey = false;
				colvarAFAdecuada.IsForeignKey = false;
				colvarAFAdecuada.IsReadOnly = false;
				
						colvarAFAdecuada.DefaultSetting = @"((0))";
				colvarAFAdecuada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAFAdecuada);
				
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
				
				TableSchema.TableColumn colvarRelacionAlbuminaOrina = new TableSchema.TableColumn(schema);
				colvarRelacionAlbuminaOrina.ColumnName = "relacionAlbuminaOrina";
				colvarRelacionAlbuminaOrina.DataType = DbType.Decimal;
				colvarRelacionAlbuminaOrina.MaxLength = 0;
				colvarRelacionAlbuminaOrina.AutoIncrement = false;
				colvarRelacionAlbuminaOrina.IsNullable = false;
				colvarRelacionAlbuminaOrina.IsPrimaryKey = false;
				colvarRelacionAlbuminaOrina.IsForeignKey = false;
				colvarRelacionAlbuminaOrina.IsReadOnly = false;
				
						colvarRelacionAlbuminaOrina.DefaultSetting = @"((0))";
				colvarRelacionAlbuminaOrina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRelacionAlbuminaOrina);
				
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
				
				TableSchema.TableColumn colvarNombreInsulina = new TableSchema.TableColumn(schema);
				colvarNombreInsulina.ColumnName = "nombreInsulina";
				colvarNombreInsulina.DataType = DbType.String;
				colvarNombreInsulina.MaxLength = 50;
				colvarNombreInsulina.AutoIncrement = false;
				colvarNombreInsulina.IsNullable = false;
				colvarNombreInsulina.IsPrimaryKey = false;
				colvarNombreInsulina.IsForeignKey = false;
				colvarNombreInsulina.IsReadOnly = false;
				
						colvarNombreInsulina.DefaultSetting = @"('')";
				colvarNombreInsulina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreInsulina);
				
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
				
				TableSchema.TableColumn colvarAlcoholismo = new TableSchema.TableColumn(schema);
				colvarAlcoholismo.ColumnName = "alcoholismo";
				colvarAlcoholismo.DataType = DbType.Decimal;
				colvarAlcoholismo.MaxLength = 0;
				colvarAlcoholismo.AutoIncrement = false;
				colvarAlcoholismo.IsNullable = false;
				colvarAlcoholismo.IsPrimaryKey = false;
				colvarAlcoholismo.IsForeignKey = false;
				colvarAlcoholismo.IsReadOnly = false;
				
						colvarAlcoholismo.DefaultSetting = @"((0))";
				colvarAlcoholismo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlcoholismo);
				
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
				
				TableSchema.TableColumn colvarEstadiEnfermedadRenal = new TableSchema.TableColumn(schema);
				colvarEstadiEnfermedadRenal.ColumnName = "estadiEnfermedadRenal";
				colvarEstadiEnfermedadRenal.DataType = DbType.Int32;
				colvarEstadiEnfermedadRenal.MaxLength = 0;
				colvarEstadiEnfermedadRenal.AutoIncrement = false;
				colvarEstadiEnfermedadRenal.IsNullable = false;
				colvarEstadiEnfermedadRenal.IsPrimaryKey = false;
				colvarEstadiEnfermedadRenal.IsForeignKey = false;
				colvarEstadiEnfermedadRenal.IsReadOnly = false;
				
						colvarEstadiEnfermedadRenal.DefaultSetting = @"((0))";
				colvarEstadiEnfermedadRenal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadiEnfermedadRenal);
				
				TableSchema.TableColumn colvarNroAutomonitoreo = new TableSchema.TableColumn(schema);
				colvarNroAutomonitoreo.ColumnName = "nroAutomonitoreo";
				colvarNroAutomonitoreo.DataType = DbType.Int32;
				colvarNroAutomonitoreo.MaxLength = 0;
				colvarNroAutomonitoreo.AutoIncrement = false;
				colvarNroAutomonitoreo.IsNullable = false;
				colvarNroAutomonitoreo.IsPrimaryKey = false;
				colvarNroAutomonitoreo.IsForeignKey = false;
				colvarNroAutomonitoreo.IsReadOnly = false;
				
						colvarNroAutomonitoreo.DefaultSetting = @"((0))";
				colvarNroAutomonitoreo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroAutomonitoreo);
				
				TableSchema.TableColumn colvarTirasReactivas = new TableSchema.TableColumn(schema);
				colvarTirasReactivas.ColumnName = "tirasReactivas";
				colvarTirasReactivas.DataType = DbType.Boolean;
				colvarTirasReactivas.MaxLength = 0;
				colvarTirasReactivas.AutoIncrement = false;
				colvarTirasReactivas.IsNullable = false;
				colvarTirasReactivas.IsPrimaryKey = false;
				colvarTirasReactivas.IsForeignKey = false;
				colvarTirasReactivas.IsReadOnly = false;
				
						colvarTirasReactivas.DefaultSetting = @"((0))";
				colvarTirasReactivas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTirasReactivas);
				
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
				
				TableSchema.TableColumn colvarMedicoCabecera = new TableSchema.TableColumn(schema);
				colvarMedicoCabecera.ColumnName = "medicoCabecera";
				colvarMedicoCabecera.DataType = DbType.AnsiString;
				colvarMedicoCabecera.MaxLength = 200;
				colvarMedicoCabecera.AutoIncrement = false;
				colvarMedicoCabecera.IsNullable = false;
				colvarMedicoCabecera.IsPrimaryKey = false;
				colvarMedicoCabecera.IsForeignKey = false;
				colvarMedicoCabecera.IsReadOnly = false;
				
						colvarMedicoCabecera.DefaultSetting = @"('')";
				colvarMedicoCabecera.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedicoCabecera);
				
				TableSchema.TableColumn colvarAutomonitoreo1 = new TableSchema.TableColumn(schema);
				colvarAutomonitoreo1.ColumnName = "automonitoreo1";
				colvarAutomonitoreo1.DataType = DbType.Boolean;
				colvarAutomonitoreo1.MaxLength = 0;
				colvarAutomonitoreo1.AutoIncrement = false;
				colvarAutomonitoreo1.IsNullable = false;
				colvarAutomonitoreo1.IsPrimaryKey = false;
				colvarAutomonitoreo1.IsForeignKey = false;
				colvarAutomonitoreo1.IsReadOnly = false;
				
						colvarAutomonitoreo1.DefaultSetting = @"((0))";
				colvarAutomonitoreo1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutomonitoreo1);
				
				TableSchema.TableColumn colvarAutomonitoreo2 = new TableSchema.TableColumn(schema);
				colvarAutomonitoreo2.ColumnName = "automonitoreo2";
				colvarAutomonitoreo2.DataType = DbType.Boolean;
				colvarAutomonitoreo2.MaxLength = 0;
				colvarAutomonitoreo2.AutoIncrement = false;
				colvarAutomonitoreo2.IsNullable = false;
				colvarAutomonitoreo2.IsPrimaryKey = false;
				colvarAutomonitoreo2.IsForeignKey = false;
				colvarAutomonitoreo2.IsReadOnly = false;
				
						colvarAutomonitoreo2.DefaultSetting = @"((0))";
				colvarAutomonitoreo2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutomonitoreo2);
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = false;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = false;
				colvarIdObraSocial.IsReadOnly = false;
				
						colvarIdObraSocial.DefaultSetting = @"((0))";
				colvarIdObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdObraSocial);
				
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
				
				TableSchema.TableColumn colvarRiesgoCardiovascular = new TableSchema.TableColumn(schema);
				colvarRiesgoCardiovascular.ColumnName = "riesgoCardiovascular";
				colvarRiesgoCardiovascular.DataType = DbType.Int32;
				colvarRiesgoCardiovascular.MaxLength = 0;
				colvarRiesgoCardiovascular.AutoIncrement = false;
				colvarRiesgoCardiovascular.IsNullable = false;
				colvarRiesgoCardiovascular.IsPrimaryKey = false;
				colvarRiesgoCardiovascular.IsForeignKey = false;
				colvarRiesgoCardiovascular.IsReadOnly = false;
				
						colvarRiesgoCardiovascular.DefaultSetting = @"((0))";
				colvarRiesgoCardiovascular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRiesgoCardiovascular);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_Clasificacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int IdClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		  
		[XmlAttribute("IdFormulario")]
		[Bindable(true)]
		public int IdFormulario 
		{
			get { return GetColumnValue<int>(Columns.IdFormulario); }
			set { SetColumnValue(Columns.IdFormulario, value); }
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
		  
		[XmlAttribute("NroClasificacion")]
		[Bindable(true)]
		public int NroClasificacion 
		{
			get { return GetColumnValue<int>(Columns.NroClasificacion); }
			set { SetColumnValue(Columns.NroClasificacion, value); }
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
		  
		[XmlAttribute("ExamenPies")]
		[Bindable(true)]
		public int ExamenPies 
		{
			get { return GetColumnValue<int>(Columns.ExamenPies); }
			set { SetColumnValue(Columns.ExamenPies, value); }
		}
		  
		[XmlAttribute("PlanAlimentario")]
		[Bindable(true)]
		public int PlanAlimentario 
		{
			get { return GetColumnValue<int>(Columns.PlanAlimentario); }
			set { SetColumnValue(Columns.PlanAlimentario, value); }
		}
		  
		[XmlAttribute("ActividadFisica")]
		[Bindable(true)]
		public int ActividadFisica 
		{
			get { return GetColumnValue<int>(Columns.ActividadFisica); }
			set { SetColumnValue(Columns.ActividadFisica, value); }
		}
		  
		[XmlAttribute("AFAdecuada")]
		[Bindable(true)]
		public bool AFAdecuada 
		{
			get { return GetColumnValue<bool>(Columns.AFAdecuada); }
			set { SetColumnValue(Columns.AFAdecuada, value); }
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
		  
		[XmlAttribute("HbAc1")]
		[Bindable(true)]
		public decimal HbAc1 
		{
			get { return GetColumnValue<decimal>(Columns.HbAc1); }
			set { SetColumnValue(Columns.HbAc1, value); }
		}
		  
		[XmlAttribute("Hematocrito")]
		[Bindable(true)]
		public decimal Hematocrito 
		{
			get { return GetColumnValue<decimal>(Columns.Hematocrito); }
			set { SetColumnValue(Columns.Hematocrito, value); }
		}
		  
		[XmlAttribute("ColesterolTotal")]
		[Bindable(true)]
		public decimal ColesterolTotal 
		{
			get { return GetColumnValue<decimal>(Columns.ColesterolTotal); }
			set { SetColumnValue(Columns.ColesterolTotal, value); }
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
		  
		[XmlAttribute("Microalbuminuria")]
		[Bindable(true)]
		public decimal Microalbuminuria 
		{
			get { return GetColumnValue<decimal>(Columns.Microalbuminuria); }
			set { SetColumnValue(Columns.Microalbuminuria, value); }
		}
		  
		[XmlAttribute("Claerence")]
		[Bindable(true)]
		public decimal Claerence 
		{
			get { return GetColumnValue<decimal>(Columns.Claerence); }
			set { SetColumnValue(Columns.Claerence, value); }
		}
		  
		[XmlAttribute("RelacionAlbuminaOrina")]
		[Bindable(true)]
		public decimal RelacionAlbuminaOrina 
		{
			get { return GetColumnValue<decimal>(Columns.RelacionAlbuminaOrina); }
			set { SetColumnValue(Columns.RelacionAlbuminaOrina, value); }
		}
		  
		[XmlAttribute("OtrosLab")]
		[Bindable(true)]
		public string OtrosLab 
		{
			get { return GetColumnValue<string>(Columns.OtrosLab); }
			set { SetColumnValue(Columns.OtrosLab, value); }
		}
		  
		[XmlAttribute("NombreInsulina")]
		[Bindable(true)]
		public string NombreInsulina 
		{
			get { return GetColumnValue<string>(Columns.NombreInsulina); }
			set { SetColumnValue(Columns.NombreInsulina, value); }
		}
		  
		[XmlAttribute("PresentacionInsulina")]
		[Bindable(true)]
		public int PresentacionInsulina 
		{
			get { return GetColumnValue<int>(Columns.PresentacionInsulina); }
			set { SetColumnValue(Columns.PresentacionInsulina, value); }
		}
		  
		[XmlAttribute("InsulinaNPH")]
		[Bindable(true)]
		public bool InsulinaNPH 
		{
			get { return GetColumnValue<bool>(Columns.InsulinaNPH); }
			set { SetColumnValue(Columns.InsulinaNPH, value); }
		}
		  
		[XmlAttribute("UnidadesDiaINPH")]
		[Bindable(true)]
		public int UnidadesDiaINPH 
		{
			get { return GetColumnValue<int>(Columns.UnidadesDiaINPH); }
			set { SetColumnValue(Columns.UnidadesDiaINPH, value); }
		}
		  
		[XmlAttribute("InsulinaRap")]
		[Bindable(true)]
		public bool InsulinaRap 
		{
			get { return GetColumnValue<bool>(Columns.InsulinaRap); }
			set { SetColumnValue(Columns.InsulinaRap, value); }
		}
		  
		[XmlAttribute("UnidadesDiaIRap")]
		[Bindable(true)]
		public int UnidadesDiaIRap 
		{
			get { return GetColumnValue<int>(Columns.UnidadesDiaIRap); }
			set { SetColumnValue(Columns.UnidadesDiaIRap, value); }
		}
		  
		[XmlAttribute("InsulinaAnalog")]
		[Bindable(true)]
		public bool InsulinaAnalog 
		{
			get { return GetColumnValue<bool>(Columns.InsulinaAnalog); }
			set { SetColumnValue(Columns.InsulinaAnalog, value); }
		}
		  
		[XmlAttribute("UnidadesDiaIAnalog")]
		[Bindable(true)]
		public int UnidadesDiaIAnalog 
		{
			get { return GetColumnValue<int>(Columns.UnidadesDiaIAnalog); }
			set { SetColumnValue(Columns.UnidadesDiaIAnalog, value); }
		}
		  
		[XmlAttribute("Alcoholismo")]
		[Bindable(true)]
		public decimal Alcoholismo 
		{
			get { return GetColumnValue<decimal>(Columns.Alcoholismo); }
			set { SetColumnValue(Columns.Alcoholismo, value); }
		}
		  
		[XmlAttribute("IUProteinaCreatinina")]
		[Bindable(true)]
		public decimal IUProteinaCreatinina 
		{
			get { return GetColumnValue<decimal>(Columns.IUProteinaCreatinina); }
			set { SetColumnValue(Columns.IUProteinaCreatinina, value); }
		}
		  
		[XmlAttribute("IUAlbuminaCreatinina")]
		[Bindable(true)]
		public decimal IUAlbuminaCreatinina 
		{
			get { return GetColumnValue<decimal>(Columns.IUAlbuminaCreatinina); }
			set { SetColumnValue(Columns.IUAlbuminaCreatinina, value); }
		}
		  
		[XmlAttribute("FiltradoGlomerular")]
		[Bindable(true)]
		public decimal FiltradoGlomerular 
		{
			get { return GetColumnValue<decimal>(Columns.FiltradoGlomerular); }
			set { SetColumnValue(Columns.FiltradoGlomerular, value); }
		}
		  
		[XmlAttribute("Hematities")]
		[Bindable(true)]
		public string Hematities 
		{
			get { return GetColumnValue<string>(Columns.Hematities); }
			set { SetColumnValue(Columns.Hematities, value); }
		}
		  
		[XmlAttribute("EstadiEnfermedadRenal")]
		[Bindable(true)]
		public int EstadiEnfermedadRenal 
		{
			get { return GetColumnValue<int>(Columns.EstadiEnfermedadRenal); }
			set { SetColumnValue(Columns.EstadiEnfermedadRenal, value); }
		}
		  
		[XmlAttribute("NroAutomonitoreo")]
		[Bindable(true)]
		public int NroAutomonitoreo 
		{
			get { return GetColumnValue<int>(Columns.NroAutomonitoreo); }
			set { SetColumnValue(Columns.NroAutomonitoreo, value); }
		}
		  
		[XmlAttribute("TirasReactivas")]
		[Bindable(true)]
		public bool TirasReactivas 
		{
			get { return GetColumnValue<bool>(Columns.TirasReactivas); }
			set { SetColumnValue(Columns.TirasReactivas, value); }
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
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("MedicoCabecera")]
		[Bindable(true)]
		public string MedicoCabecera 
		{
			get { return GetColumnValue<string>(Columns.MedicoCabecera); }
			set { SetColumnValue(Columns.MedicoCabecera, value); }
		}
		  
		[XmlAttribute("Automonitoreo1")]
		[Bindable(true)]
		public bool Automonitoreo1 
		{
			get { return GetColumnValue<bool>(Columns.Automonitoreo1); }
			set { SetColumnValue(Columns.Automonitoreo1, value); }
		}
		  
		[XmlAttribute("Automonitoreo2")]
		[Bindable(true)]
		public bool Automonitoreo2 
		{
			get { return GetColumnValue<bool>(Columns.Automonitoreo2); }
			set { SetColumnValue(Columns.Automonitoreo2, value); }
		}
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int IdObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("OtrosMedicam")]
		[Bindable(true)]
		public string OtrosMedicam 
		{
			get { return GetColumnValue<string>(Columns.OtrosMedicam); }
			set { SetColumnValue(Columns.OtrosMedicam, value); }
		}
		  
		[XmlAttribute("RiesgoCardiovascular")]
		[Bindable(true)]
		public int RiesgoCardiovascular 
		{
			get { return GetColumnValue<int>(Columns.RiesgoCardiovascular); }
			set { SetColumnValue(Columns.RiesgoCardiovascular, value); }
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
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.RemEstudioOcularCollection colRemEstudioOcularRecords;
		public DalSic.RemEstudioOcularCollection RemEstudioOcularRecords
		{
			get
			{
				if(colRemEstudioOcularRecords == null)
				{
					colRemEstudioOcularRecords = new DalSic.RemEstudioOcularCollection().Where(RemEstudioOcular.Columns.IdClasificacion, IdClasificacion).Load();
					colRemEstudioOcularRecords.ListChanged += new ListChangedEventHandler(colRemEstudioOcularRecords_ListChanged);
				}
				return colRemEstudioOcularRecords;			
			}
			set 
			{ 
					colRemEstudioOcularRecords = value; 
					colRemEstudioOcularRecords.ListChanged += new ListChangedEventHandler(colRemEstudioOcularRecords_ListChanged);
			}
		}
		
		void colRemEstudioOcularRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemEstudioOcularRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.RemRelMedicamentoClasificacionCollection colRemRelMedicamentoClasificacionRecords;
		public DalSic.RemRelMedicamentoClasificacionCollection RemRelMedicamentoClasificacionRecords
		{
			get
			{
				if(colRemRelMedicamentoClasificacionRecords == null)
				{
					colRemRelMedicamentoClasificacionRecords = new DalSic.RemRelMedicamentoClasificacionCollection().Where(RemRelMedicamentoClasificacion.Columns.IdClasificacion, IdClasificacion).Load();
					colRemRelMedicamentoClasificacionRecords.ListChanged += new ListChangedEventHandler(colRemRelMedicamentoClasificacionRecords_ListChanged);
				}
				return colRemRelMedicamentoClasificacionRecords;			
			}
			set 
			{ 
					colRemRelMedicamentoClasificacionRecords = value; 
					colRemRelMedicamentoClasificacionRecords.ListChanged += new ListChangedEventHandler(colRemRelMedicamentoClasificacionRecords_ListChanged);
			}
		}
		
		void colRemRelMedicamentoClasificacionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemRelMedicamentoClasificacionRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.SysRelAntecedentePacienteCollection colSysRelAntecedentePacienteRecords;
		public DalSic.SysRelAntecedentePacienteCollection SysRelAntecedentePacienteRecords
		{
			get
			{
				if(colSysRelAntecedentePacienteRecords == null)
				{
					colSysRelAntecedentePacienteRecords = new DalSic.SysRelAntecedentePacienteCollection().Where(SysRelAntecedentePaciente.Columns.IdClasificacion, IdClasificacion).Load();
					colSysRelAntecedentePacienteRecords.ListChanged += new ListChangedEventHandler(colSysRelAntecedentePacienteRecords_ListChanged);
				}
				return colSysRelAntecedentePacienteRecords;			
			}
			set 
			{ 
					colSysRelAntecedentePacienteRecords = value; 
					colSysRelAntecedentePacienteRecords.ListChanged += new ListChangedEventHandler(colSysRelAntecedentePacienteRecords_ListChanged);
			}
		}
		
		void colSysRelAntecedentePacienteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelAntecedentePacienteRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.RemComplicacioneCollection colRemComplicaciones;
		public DalSic.RemComplicacioneCollection RemComplicaciones
		{
			get
			{
				if(colRemComplicaciones == null)
				{
					colRemComplicaciones = new DalSic.RemComplicacioneCollection().Where(RemComplicacione.Columns.IdClasificacion, IdClasificacion).Load();
					colRemComplicaciones.ListChanged += new ListChangedEventHandler(colRemComplicaciones_ListChanged);
				}
				return colRemComplicaciones;			
			}
			set 
			{ 
					colRemComplicaciones = value; 
					colRemComplicaciones.ListChanged += new ListChangedEventHandler(colRemComplicaciones_ListChanged);
			}
		}
		
		void colRemComplicaciones_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemComplicaciones[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.RemInternacionCollection colRemInternacionRecords;
		public DalSic.RemInternacionCollection RemInternacionRecords
		{
			get
			{
				if(colRemInternacionRecords == null)
				{
					colRemInternacionRecords = new DalSic.RemInternacionCollection().Where(RemInternacion.Columns.IdClasificacion, IdClasificacion).Load();
					colRemInternacionRecords.ListChanged += new ListChangedEventHandler(colRemInternacionRecords_ListChanged);
				}
				return colRemInternacionRecords;			
			}
			set 
			{ 
					colRemInternacionRecords = value; 
					colRemInternacionRecords.ListChanged += new ListChangedEventHandler(colRemInternacionRecords_ListChanged);
			}
		}
		
		void colRemInternacionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemInternacionRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.RemRelMedicamentoSeguimientoCollection colRemRelMedicamentoSeguimientoRecords;
		public DalSic.RemRelMedicamentoSeguimientoCollection RemRelMedicamentoSeguimientoRecords
		{
			get
			{
				if(colRemRelMedicamentoSeguimientoRecords == null)
				{
					colRemRelMedicamentoSeguimientoRecords = new DalSic.RemRelMedicamentoSeguimientoCollection().Where(RemRelMedicamentoSeguimiento.Columns.IdClasificacion, IdClasificacion).Load();
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
		        colRemRelMedicamentoSeguimientoRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.RemExamenPieCollection colRemExamenPieRecords;
		public DalSic.RemExamenPieCollection RemExamenPieRecords
		{
			get
			{
				if(colRemExamenPieRecords == null)
				{
					colRemExamenPieRecords = new DalSic.RemExamenPieCollection().Where(RemExamenPie.Columns.IdClasificacion, IdClasificacion).Load();
					colRemExamenPieRecords.ListChanged += new ListChangedEventHandler(colRemExamenPieRecords_ListChanged);
				}
				return colRemExamenPieRecords;			
			}
			set 
			{ 
					colRemExamenPieRecords = value; 
					colRemExamenPieRecords.ListChanged += new ListChangedEventHandler(colRemExamenPieRecords_ListChanged);
			}
		}
		
		void colRemExamenPieRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemExamenPieRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
				
		private DalSic.RemSeguimientoCollection colRemSeguimientoRecords;
		public DalSic.RemSeguimientoCollection RemSeguimientoRecords
		{
			get
			{
				if(colRemSeguimientoRecords == null)
				{
					colRemSeguimientoRecords = new DalSic.RemSeguimientoCollection().Where(RemSeguimiento.Columns.IdClasificacion, IdClasificacion).Load();
					colRemSeguimientoRecords.ListChanged += new ListChangedEventHandler(colRemSeguimientoRecords_ListChanged);
				}
				return colRemSeguimientoRecords;			
			}
			set 
			{ 
					colRemSeguimientoRecords = value; 
					colRemSeguimientoRecords.ListChanged += new ListChangedEventHandler(colRemSeguimientoRecords_ListChanged);
			}
		}
		
		void colRemSeguimientoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemSeguimientoRecords[e.NewIndex].IdClasificacion = IdClasificacion;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this RemClasificacion
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this RemClasificacion
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this RemClasificacion
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a RemFormulario ActiveRecord object related to this RemClasificacion
		/// 
		/// </summary>
		public DalSic.RemFormulario RemFormulario
		{
			get { return DalSic.RemFormulario.FetchByID(this.IdFormulario); }
			set { SetColumnValue("idFormulario", value.IdFormulario); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdFormulario,int varIdEfector,int varIdPaciente,int varEdad,int varNroClasificacion,DateTime varFechaControl,decimal varPeso,decimal varTalla,decimal varImc,int varTAS,int varTAD,int varExamenPies,int varPlanAlimentario,int varActividadFisica,bool varAFAdecuada,decimal varCircunferenciaAbdominal,DateTime varFechaLab,decimal varGlucemia,string varUnidadGlucemia,decimal varHbAc1,decimal varHematocrito,decimal varColesterolTotal,string varUnidadColTotal,decimal varHdl,string varUnidadHDL,decimal varLdl,string varUnidadLDL,decimal varTgl,string varUnidadTGL,decimal varCreatininemia,string varUnidadCreatininemia,decimal varPtog,string varUnidadPTOG,decimal varMicroalbuminuria,decimal varClaerence,decimal varRelacionAlbuminaOrina,string varOtrosLab,string varNombreInsulina,int varPresentacionInsulina,bool varInsulinaNPH,int varUnidadesDiaINPH,bool varInsulinaRap,int varUnidadesDiaIRap,bool varInsulinaAnalog,int varUnidadesDiaIAnalog,decimal varAlcoholismo,decimal varIUProteinaCreatinina,decimal varIUAlbuminaCreatinina,decimal varFiltradoGlomerular,string varHematities,int varEstadiEnfermedadRenal,int varNroAutomonitoreo,bool varTirasReactivas,string varOtrasDrogas1,decimal varDosisODrogas1,string varOtrasDrogras2,decimal varDosisODrogas2,int varIdProfesional,string varMedicoCabecera,bool varAutomonitoreo1,bool varAutomonitoreo2,int varIdObraSocial,string varOtrosMedicam,int varRiesgoCardiovascular,bool varCerrar,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			RemClasificacion item = new RemClasificacion();
			
			item.IdFormulario = varIdFormulario;
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.NroClasificacion = varNroClasificacion;
			
			item.FechaControl = varFechaControl;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.Imc = varImc;
			
			item.TAS = varTAS;
			
			item.TAD = varTAD;
			
			item.ExamenPies = varExamenPies;
			
			item.PlanAlimentario = varPlanAlimentario;
			
			item.ActividadFisica = varActividadFisica;
			
			item.AFAdecuada = varAFAdecuada;
			
			item.CircunferenciaAbdominal = varCircunferenciaAbdominal;
			
			item.FechaLab = varFechaLab;
			
			item.Glucemia = varGlucemia;
			
			item.UnidadGlucemia = varUnidadGlucemia;
			
			item.HbAc1 = varHbAc1;
			
			item.Hematocrito = varHematocrito;
			
			item.ColesterolTotal = varColesterolTotal;
			
			item.UnidadColTotal = varUnidadColTotal;
			
			item.Hdl = varHdl;
			
			item.UnidadHDL = varUnidadHDL;
			
			item.Ldl = varLdl;
			
			item.UnidadLDL = varUnidadLDL;
			
			item.Tgl = varTgl;
			
			item.UnidadTGL = varUnidadTGL;
			
			item.Creatininemia = varCreatininemia;
			
			item.UnidadCreatininemia = varUnidadCreatininemia;
			
			item.Ptog = varPtog;
			
			item.UnidadPTOG = varUnidadPTOG;
			
			item.Microalbuminuria = varMicroalbuminuria;
			
			item.Claerence = varClaerence;
			
			item.RelacionAlbuminaOrina = varRelacionAlbuminaOrina;
			
			item.OtrosLab = varOtrosLab;
			
			item.NombreInsulina = varNombreInsulina;
			
			item.PresentacionInsulina = varPresentacionInsulina;
			
			item.InsulinaNPH = varInsulinaNPH;
			
			item.UnidadesDiaINPH = varUnidadesDiaINPH;
			
			item.InsulinaRap = varInsulinaRap;
			
			item.UnidadesDiaIRap = varUnidadesDiaIRap;
			
			item.InsulinaAnalog = varInsulinaAnalog;
			
			item.UnidadesDiaIAnalog = varUnidadesDiaIAnalog;
			
			item.Alcoholismo = varAlcoholismo;
			
			item.IUProteinaCreatinina = varIUProteinaCreatinina;
			
			item.IUAlbuminaCreatinina = varIUAlbuminaCreatinina;
			
			item.FiltradoGlomerular = varFiltradoGlomerular;
			
			item.Hematities = varHematities;
			
			item.EstadiEnfermedadRenal = varEstadiEnfermedadRenal;
			
			item.NroAutomonitoreo = varNroAutomonitoreo;
			
			item.TirasReactivas = varTirasReactivas;
			
			item.OtrasDrogas1 = varOtrasDrogas1;
			
			item.DosisODrogas1 = varDosisODrogas1;
			
			item.OtrasDrogras2 = varOtrasDrogras2;
			
			item.DosisODrogas2 = varDosisODrogas2;
			
			item.IdProfesional = varIdProfesional;
			
			item.MedicoCabecera = varMedicoCabecera;
			
			item.Automonitoreo1 = varAutomonitoreo1;
			
			item.Automonitoreo2 = varAutomonitoreo2;
			
			item.IdObraSocial = varIdObraSocial;
			
			item.OtrosMedicam = varOtrosMedicam;
			
			item.RiesgoCardiovascular = varRiesgoCardiovascular;
			
			item.Cerrar = varCerrar;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdClasificacion,int varIdFormulario,int varIdEfector,int varIdPaciente,int varEdad,int varNroClasificacion,DateTime varFechaControl,decimal varPeso,decimal varTalla,decimal varImc,int varTAS,int varTAD,int varExamenPies,int varPlanAlimentario,int varActividadFisica,bool varAFAdecuada,decimal varCircunferenciaAbdominal,DateTime varFechaLab,decimal varGlucemia,string varUnidadGlucemia,decimal varHbAc1,decimal varHematocrito,decimal varColesterolTotal,string varUnidadColTotal,decimal varHdl,string varUnidadHDL,decimal varLdl,string varUnidadLDL,decimal varTgl,string varUnidadTGL,decimal varCreatininemia,string varUnidadCreatininemia,decimal varPtog,string varUnidadPTOG,decimal varMicroalbuminuria,decimal varClaerence,decimal varRelacionAlbuminaOrina,string varOtrosLab,string varNombreInsulina,int varPresentacionInsulina,bool varInsulinaNPH,int varUnidadesDiaINPH,bool varInsulinaRap,int varUnidadesDiaIRap,bool varInsulinaAnalog,int varUnidadesDiaIAnalog,decimal varAlcoholismo,decimal varIUProteinaCreatinina,decimal varIUAlbuminaCreatinina,decimal varFiltradoGlomerular,string varHematities,int varEstadiEnfermedadRenal,int varNroAutomonitoreo,bool varTirasReactivas,string varOtrasDrogas1,decimal varDosisODrogas1,string varOtrasDrogras2,decimal varDosisODrogas2,int varIdProfesional,string varMedicoCabecera,bool varAutomonitoreo1,bool varAutomonitoreo2,int varIdObraSocial,string varOtrosMedicam,int varRiesgoCardiovascular,bool varCerrar,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			RemClasificacion item = new RemClasificacion();
			
				item.IdClasificacion = varIdClasificacion;
			
				item.IdFormulario = varIdFormulario;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.NroClasificacion = varNroClasificacion;
			
				item.FechaControl = varFechaControl;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.Imc = varImc;
			
				item.TAS = varTAS;
			
				item.TAD = varTAD;
			
				item.ExamenPies = varExamenPies;
			
				item.PlanAlimentario = varPlanAlimentario;
			
				item.ActividadFisica = varActividadFisica;
			
				item.AFAdecuada = varAFAdecuada;
			
				item.CircunferenciaAbdominal = varCircunferenciaAbdominal;
			
				item.FechaLab = varFechaLab;
			
				item.Glucemia = varGlucemia;
			
				item.UnidadGlucemia = varUnidadGlucemia;
			
				item.HbAc1 = varHbAc1;
			
				item.Hematocrito = varHematocrito;
			
				item.ColesterolTotal = varColesterolTotal;
			
				item.UnidadColTotal = varUnidadColTotal;
			
				item.Hdl = varHdl;
			
				item.UnidadHDL = varUnidadHDL;
			
				item.Ldl = varLdl;
			
				item.UnidadLDL = varUnidadLDL;
			
				item.Tgl = varTgl;
			
				item.UnidadTGL = varUnidadTGL;
			
				item.Creatininemia = varCreatininemia;
			
				item.UnidadCreatininemia = varUnidadCreatininemia;
			
				item.Ptog = varPtog;
			
				item.UnidadPTOG = varUnidadPTOG;
			
				item.Microalbuminuria = varMicroalbuminuria;
			
				item.Claerence = varClaerence;
			
				item.RelacionAlbuminaOrina = varRelacionAlbuminaOrina;
			
				item.OtrosLab = varOtrosLab;
			
				item.NombreInsulina = varNombreInsulina;
			
				item.PresentacionInsulina = varPresentacionInsulina;
			
				item.InsulinaNPH = varInsulinaNPH;
			
				item.UnidadesDiaINPH = varUnidadesDiaINPH;
			
				item.InsulinaRap = varInsulinaRap;
			
				item.UnidadesDiaIRap = varUnidadesDiaIRap;
			
				item.InsulinaAnalog = varInsulinaAnalog;
			
				item.UnidadesDiaIAnalog = varUnidadesDiaIAnalog;
			
				item.Alcoholismo = varAlcoholismo;
			
				item.IUProteinaCreatinina = varIUProteinaCreatinina;
			
				item.IUAlbuminaCreatinina = varIUAlbuminaCreatinina;
			
				item.FiltradoGlomerular = varFiltradoGlomerular;
			
				item.Hematities = varHematities;
			
				item.EstadiEnfermedadRenal = varEstadiEnfermedadRenal;
			
				item.NroAutomonitoreo = varNroAutomonitoreo;
			
				item.TirasReactivas = varTirasReactivas;
			
				item.OtrasDrogas1 = varOtrasDrogas1;
			
				item.DosisODrogas1 = varDosisODrogas1;
			
				item.OtrasDrogras2 = varOtrasDrogras2;
			
				item.DosisODrogas2 = varDosisODrogas2;
			
				item.IdProfesional = varIdProfesional;
			
				item.MedicoCabecera = varMedicoCabecera;
			
				item.Automonitoreo1 = varAutomonitoreo1;
			
				item.Automonitoreo2 = varAutomonitoreo2;
			
				item.IdObraSocial = varIdObraSocial;
			
				item.OtrosMedicam = varOtrosMedicam;
			
				item.RiesgoCardiovascular = varRiesgoCardiovascular;
			
				item.Cerrar = varCerrar;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFormularioColumn
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
        
        
        
        public static TableSchema.TableColumn NroClasificacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ImcColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TASColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TADColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ExamenPiesColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PlanAlimentarioColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ActividadFisicaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn AFAdecuadaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CircunferenciaAbdominalColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaLabColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucemiaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadGlucemiaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn HbAc1Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn HematocritoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ColesterolTotalColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadColTotalColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn HdlColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadHDLColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn LdlColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadLDLColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn TglColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadTGLColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatininemiaColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadCreatininemiaColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn PtogColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadPTOGColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn MicroalbuminuriaColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaerenceColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn RelacionAlbuminaOrinaColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosLabColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreInsulinaColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn PresentacionInsulinaColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn InsulinaNPHColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadesDiaINPHColumn
        {
            get { return Schema.Columns[41]; }
        }
        
        
        
        public static TableSchema.TableColumn InsulinaRapColumn
        {
            get { return Schema.Columns[42]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadesDiaIRapColumn
        {
            get { return Schema.Columns[43]; }
        }
        
        
        
        public static TableSchema.TableColumn InsulinaAnalogColumn
        {
            get { return Schema.Columns[44]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadesDiaIAnalogColumn
        {
            get { return Schema.Columns[45]; }
        }
        
        
        
        public static TableSchema.TableColumn AlcoholismoColumn
        {
            get { return Schema.Columns[46]; }
        }
        
        
        
        public static TableSchema.TableColumn IUProteinaCreatininaColumn
        {
            get { return Schema.Columns[47]; }
        }
        
        
        
        public static TableSchema.TableColumn IUAlbuminaCreatininaColumn
        {
            get { return Schema.Columns[48]; }
        }
        
        
        
        public static TableSchema.TableColumn FiltradoGlomerularColumn
        {
            get { return Schema.Columns[49]; }
        }
        
        
        
        public static TableSchema.TableColumn HematitiesColumn
        {
            get { return Schema.Columns[50]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadiEnfermedadRenalColumn
        {
            get { return Schema.Columns[51]; }
        }
        
        
        
        public static TableSchema.TableColumn NroAutomonitoreoColumn
        {
            get { return Schema.Columns[52]; }
        }
        
        
        
        public static TableSchema.TableColumn TirasReactivasColumn
        {
            get { return Schema.Columns[53]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasDrogas1Column
        {
            get { return Schema.Columns[54]; }
        }
        
        
        
        public static TableSchema.TableColumn DosisODrogas1Column
        {
            get { return Schema.Columns[55]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasDrogras2Column
        {
            get { return Schema.Columns[56]; }
        }
        
        
        
        public static TableSchema.TableColumn DosisODrogas2Column
        {
            get { return Schema.Columns[57]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[58]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoCabeceraColumn
        {
            get { return Schema.Columns[59]; }
        }
        
        
        
        public static TableSchema.TableColumn Automonitoreo1Column
        {
            get { return Schema.Columns[60]; }
        }
        
        
        
        public static TableSchema.TableColumn Automonitoreo2Column
        {
            get { return Schema.Columns[61]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[62]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrosMedicamColumn
        {
            get { return Schema.Columns[63]; }
        }
        
        
        
        public static TableSchema.TableColumn RiesgoCardiovascularColumn
        {
            get { return Schema.Columns[64]; }
        }
        
        
        
        public static TableSchema.TableColumn CerrarColumn
        {
            get { return Schema.Columns[65]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[66]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[67]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[68]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[69]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdClasificacion = @"idClasificacion";
			 public static string IdFormulario = @"idFormulario";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string NroClasificacion = @"nroClasificacion";
			 public static string FechaControl = @"fechaControl";
			 public static string Peso = @"peso";
			 public static string Talla = @"talla";
			 public static string Imc = @"Imc";
			 public static string TAS = @"tAS";
			 public static string TAD = @"tAD";
			 public static string ExamenPies = @"examenPies";
			 public static string PlanAlimentario = @"planAlimentario";
			 public static string ActividadFisica = @"actividadFisica";
			 public static string AFAdecuada = @"aFAdecuada";
			 public static string CircunferenciaAbdominal = @"circunferenciaAbdominal";
			 public static string FechaLab = @"fechaLab";
			 public static string Glucemia = @"glucemia";
			 public static string UnidadGlucemia = @"unidadGlucemia";
			 public static string HbAc1 = @"HbAc1";
			 public static string Hematocrito = @"hematocrito";
			 public static string ColesterolTotal = @"colesterolTotal";
			 public static string UnidadColTotal = @"unidadColTotal";
			 public static string Hdl = @"HDL";
			 public static string UnidadHDL = @"unidadHDL";
			 public static string Ldl = @"LDL";
			 public static string UnidadLDL = @"unidadLDL";
			 public static string Tgl = @"TGL";
			 public static string UnidadTGL = @"unidadTGL";
			 public static string Creatininemia = @"creatininemia";
			 public static string UnidadCreatininemia = @"unidadCreatininemia";
			 public static string Ptog = @"PTOG";
			 public static string UnidadPTOG = @"unidadPTOG";
			 public static string Microalbuminuria = @"microalbuminuria";
			 public static string Claerence = @"claerence";
			 public static string RelacionAlbuminaOrina = @"relacionAlbuminaOrina";
			 public static string OtrosLab = @"otrosLab";
			 public static string NombreInsulina = @"nombreInsulina";
			 public static string PresentacionInsulina = @"presentacionInsulina";
			 public static string InsulinaNPH = @"insulinaNPH";
			 public static string UnidadesDiaINPH = @"unidadesDiaINPH";
			 public static string InsulinaRap = @"insulinaRap";
			 public static string UnidadesDiaIRap = @"unidadesDiaIRap";
			 public static string InsulinaAnalog = @"insulinaAnalog";
			 public static string UnidadesDiaIAnalog = @"unidadesDiaIAnalog";
			 public static string Alcoholismo = @"alcoholismo";
			 public static string IUProteinaCreatinina = @"iUProteinaCreatinina";
			 public static string IUAlbuminaCreatinina = @"iUAlbuminaCreatinina";
			 public static string FiltradoGlomerular = @"filtradoGlomerular";
			 public static string Hematities = @"hematities";
			 public static string EstadiEnfermedadRenal = @"estadiEnfermedadRenal";
			 public static string NroAutomonitoreo = @"nroAutomonitoreo";
			 public static string TirasReactivas = @"tirasReactivas";
			 public static string OtrasDrogas1 = @"otrasDrogas1";
			 public static string DosisODrogas1 = @"dosisODrogas1";
			 public static string OtrasDrogras2 = @"otrasDrogras2";
			 public static string DosisODrogas2 = @"dosisODrogas2";
			 public static string IdProfesional = @"idProfesional";
			 public static string MedicoCabecera = @"medicoCabecera";
			 public static string Automonitoreo1 = @"automonitoreo1";
			 public static string Automonitoreo2 = @"automonitoreo2";
			 public static string IdObraSocial = @"idObraSocial";
			 public static string OtrosMedicam = @"otrosMedicam";
			 public static string RiesgoCardiovascular = @"riesgoCardiovascular";
			 public static string Cerrar = @"cerrar";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colRemEstudioOcularRecords != null)
                {
                    foreach (DalSic.RemEstudioOcular item in colRemEstudioOcularRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colRemRelMedicamentoClasificacionRecords != null)
                {
                    foreach (DalSic.RemRelMedicamentoClasificacion item in colRemRelMedicamentoClasificacionRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colSysRelAntecedentePacienteRecords != null)
                {
                    foreach (DalSic.SysRelAntecedentePaciente item in colSysRelAntecedentePacienteRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colRemComplicaciones != null)
                {
                    foreach (DalSic.RemComplicacione item in colRemComplicaciones)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colRemInternacionRecords != null)
                {
                    foreach (DalSic.RemInternacion item in colRemInternacionRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colRemRelMedicamentoSeguimientoRecords != null)
                {
                    foreach (DalSic.RemRelMedicamentoSeguimiento item in colRemRelMedicamentoSeguimientoRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colRemExamenPieRecords != null)
                {
                    foreach (DalSic.RemExamenPie item in colRemExamenPieRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		
                if (colRemSeguimientoRecords != null)
                {
                    foreach (DalSic.RemSeguimiento item in colRemSeguimientoRecords)
                    {
                        if (item.IdClasificacion != IdClasificacion)
                        {
                            item.IdClasificacion = IdClasificacion;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colRemEstudioOcularRecords != null)
                {
                    colRemEstudioOcularRecords.SaveAll();
               }
		
                if (colRemRelMedicamentoClasificacionRecords != null)
                {
                    colRemRelMedicamentoClasificacionRecords.SaveAll();
               }
		
                if (colSysRelAntecedentePacienteRecords != null)
                {
                    colSysRelAntecedentePacienteRecords.SaveAll();
               }
		
                if (colRemComplicaciones != null)
                {
                    colRemComplicaciones.SaveAll();
               }
		
                if (colRemInternacionRecords != null)
                {
                    colRemInternacionRecords.SaveAll();
               }
		
                if (colRemRelMedicamentoSeguimientoRecords != null)
                {
                    colRemRelMedicamentoSeguimientoRecords.SaveAll();
               }
		
                if (colRemExamenPieRecords != null)
                {
                    colRemExamenPieRecords.SaveAll();
               }
		
                if (colRemSeguimientoRecords != null)
                {
                    colRemSeguimientoRecords.SaveAll();
               }
		}
        #endregion
	}
}
