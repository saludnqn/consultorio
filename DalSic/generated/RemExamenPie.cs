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
	/// Strongly-typed collection for the RemExamenPie class.
	/// </summary>
    [Serializable]
	public partial class RemExamenPieCollection : ActiveList<RemExamenPie, RemExamenPieCollection>
	{	   
		public RemExamenPieCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemExamenPieCollection</returns>
		public RemExamenPieCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemExamenPie o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_ExamenPie table.
	/// </summary>
	[Serializable]
	public partial class RemExamenPie : ActiveRecord<RemExamenPie>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemExamenPie()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemExamenPie(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemExamenPie(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemExamenPie(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_ExamenPie", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdExamenPies = new TableSchema.TableColumn(schema);
				colvarIdExamenPies.ColumnName = "idExamenPies";
				colvarIdExamenPies.DataType = DbType.Int32;
				colvarIdExamenPies.MaxLength = 0;
				colvarIdExamenPies.AutoIncrement = true;
				colvarIdExamenPies.IsNullable = false;
				colvarIdExamenPies.IsPrimaryKey = true;
				colvarIdExamenPies.IsForeignKey = false;
				colvarIdExamenPies.IsReadOnly = false;
				colvarIdExamenPies.DefaultSetting = @"";
				colvarIdExamenPies.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExamenPies);
				
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
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 200;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = false;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				
						colvarObservacion.DefaultSetting = @"('')";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				TableSchema.TableColumn colvarSensibTermica = new TableSchema.TableColumn(schema);
				colvarSensibTermica.ColumnName = "sensibTermica";
				colvarSensibTermica.DataType = DbType.Int32;
				colvarSensibTermica.MaxLength = 0;
				colvarSensibTermica.AutoIncrement = false;
				colvarSensibTermica.IsNullable = false;
				colvarSensibTermica.IsPrimaryKey = false;
				colvarSensibTermica.IsForeignKey = false;
				colvarSensibTermica.IsReadOnly = false;
				
						colvarSensibTermica.DefaultSetting = @"((0))";
				colvarSensibTermica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSensibTermica);
				
				TableSchema.TableColumn colvarSensibAlgesica = new TableSchema.TableColumn(schema);
				colvarSensibAlgesica.ColumnName = "sensibAlgesica";
				colvarSensibAlgesica.DataType = DbType.Int32;
				colvarSensibAlgesica.MaxLength = 0;
				colvarSensibAlgesica.AutoIncrement = false;
				colvarSensibAlgesica.IsNullable = false;
				colvarSensibAlgesica.IsPrimaryKey = false;
				colvarSensibAlgesica.IsForeignKey = false;
				colvarSensibAlgesica.IsReadOnly = false;
				
						colvarSensibAlgesica.DefaultSetting = @"((0))";
				colvarSensibAlgesica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSensibAlgesica);
				
				TableSchema.TableColumn colvarReflejoPatelar = new TableSchema.TableColumn(schema);
				colvarReflejoPatelar.ColumnName = "reflejoPatelar";
				colvarReflejoPatelar.DataType = DbType.Int32;
				colvarReflejoPatelar.MaxLength = 0;
				colvarReflejoPatelar.AutoIncrement = false;
				colvarReflejoPatelar.IsNullable = false;
				colvarReflejoPatelar.IsPrimaryKey = false;
				colvarReflejoPatelar.IsForeignKey = false;
				colvarReflejoPatelar.IsReadOnly = false;
				
						colvarReflejoPatelar.DefaultSetting = @"((0))";
				colvarReflejoPatelar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReflejoPatelar);
				
				TableSchema.TableColumn colvarReflejoAquileano = new TableSchema.TableColumn(schema);
				colvarReflejoAquileano.ColumnName = "reflejoAquileano";
				colvarReflejoAquileano.DataType = DbType.Int32;
				colvarReflejoAquileano.MaxLength = 0;
				colvarReflejoAquileano.AutoIncrement = false;
				colvarReflejoAquileano.IsNullable = false;
				colvarReflejoAquileano.IsPrimaryKey = false;
				colvarReflejoAquileano.IsForeignKey = false;
				colvarReflejoAquileano.IsReadOnly = false;
				
						colvarReflejoAquileano.DefaultSetting = @"((0))";
				colvarReflejoAquileano.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReflejoAquileano);
				
				TableSchema.TableColumn colvarSignoAbanico = new TableSchema.TableColumn(schema);
				colvarSignoAbanico.ColumnName = "signoAbanico";
				colvarSignoAbanico.DataType = DbType.Int32;
				colvarSignoAbanico.MaxLength = 0;
				colvarSignoAbanico.AutoIncrement = false;
				colvarSignoAbanico.IsNullable = false;
				colvarSignoAbanico.IsPrimaryKey = false;
				colvarSignoAbanico.IsForeignKey = false;
				colvarSignoAbanico.IsReadOnly = false;
				
						colvarSignoAbanico.DefaultSetting = @"((0))";
				colvarSignoAbanico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSignoAbanico);
				
				TableSchema.TableColumn colvarSensibDiapason = new TableSchema.TableColumn(schema);
				colvarSensibDiapason.ColumnName = "sensibDiapason";
				colvarSensibDiapason.DataType = DbType.Int32;
				colvarSensibDiapason.MaxLength = 0;
				colvarSensibDiapason.AutoIncrement = false;
				colvarSensibDiapason.IsNullable = false;
				colvarSensibDiapason.IsPrimaryKey = false;
				colvarSensibDiapason.IsForeignKey = false;
				colvarSensibDiapason.IsReadOnly = false;
				
						colvarSensibDiapason.DefaultSetting = @"((0))";
				colvarSensibDiapason.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSensibDiapason);
				
				TableSchema.TableColumn colvarFuerzaMuscular = new TableSchema.TableColumn(schema);
				colvarFuerzaMuscular.ColumnName = "fuerzaMuscular";
				colvarFuerzaMuscular.DataType = DbType.Int32;
				colvarFuerzaMuscular.MaxLength = 0;
				colvarFuerzaMuscular.AutoIncrement = false;
				colvarFuerzaMuscular.IsNullable = false;
				colvarFuerzaMuscular.IsPrimaryKey = false;
				colvarFuerzaMuscular.IsForeignKey = false;
				colvarFuerzaMuscular.IsReadOnly = false;
				
						colvarFuerzaMuscular.DefaultSetting = @"((0))";
				colvarFuerzaMuscular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFuerzaMuscular);
				
				TableSchema.TableColumn colvarAlteracionesApoyo = new TableSchema.TableColumn(schema);
				colvarAlteracionesApoyo.ColumnName = "alteracionesApoyo";
				colvarAlteracionesApoyo.DataType = DbType.Int32;
				colvarAlteracionesApoyo.MaxLength = 0;
				colvarAlteracionesApoyo.AutoIncrement = false;
				colvarAlteracionesApoyo.IsNullable = false;
				colvarAlteracionesApoyo.IsPrimaryKey = false;
				colvarAlteracionesApoyo.IsForeignKey = false;
				colvarAlteracionesApoyo.IsReadOnly = false;
				
						colvarAlteracionesApoyo.DefaultSetting = @"((0))";
				colvarAlteracionesApoyo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlteracionesApoyo);
				
				TableSchema.TableColumn colvarDisminucionMovilidad = new TableSchema.TableColumn(schema);
				colvarDisminucionMovilidad.ColumnName = "disminucionMovilidad";
				colvarDisminucionMovilidad.DataType = DbType.Int32;
				colvarDisminucionMovilidad.MaxLength = 0;
				colvarDisminucionMovilidad.AutoIncrement = false;
				colvarDisminucionMovilidad.IsNullable = false;
				colvarDisminucionMovilidad.IsPrimaryKey = false;
				colvarDisminucionMovilidad.IsForeignKey = false;
				colvarDisminucionMovilidad.IsReadOnly = false;
				
						colvarDisminucionMovilidad.DefaultSetting = @"((0))";
				colvarDisminucionMovilidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDisminucionMovilidad);
				
				TableSchema.TableColumn colvarDedosMartillo = new TableSchema.TableColumn(schema);
				colvarDedosMartillo.ColumnName = "dedosMartillo";
				colvarDedosMartillo.DataType = DbType.Int32;
				colvarDedosMartillo.MaxLength = 0;
				colvarDedosMartillo.AutoIncrement = false;
				colvarDedosMartillo.IsNullable = false;
				colvarDedosMartillo.IsPrimaryKey = false;
				colvarDedosMartillo.IsForeignKey = false;
				colvarDedosMartillo.IsReadOnly = false;
				
						colvarDedosMartillo.DefaultSetting = @"((0))";
				colvarDedosMartillo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDedosMartillo);
				
				TableSchema.TableColumn colvarClinodactilia = new TableSchema.TableColumn(schema);
				colvarClinodactilia.ColumnName = "clinodactilia";
				colvarClinodactilia.DataType = DbType.Int32;
				colvarClinodactilia.MaxLength = 0;
				colvarClinodactilia.AutoIncrement = false;
				colvarClinodactilia.IsNullable = false;
				colvarClinodactilia.IsPrimaryKey = false;
				colvarClinodactilia.IsForeignKey = false;
				colvarClinodactilia.IsReadOnly = false;
				
						colvarClinodactilia.DefaultSetting = @"((0))";
				colvarClinodactilia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClinodactilia);
				
				TableSchema.TableColumn colvarHalluxValgus = new TableSchema.TableColumn(schema);
				colvarHalluxValgus.ColumnName = "halluxValgus";
				colvarHalluxValgus.DataType = DbType.Int32;
				colvarHalluxValgus.MaxLength = 0;
				colvarHalluxValgus.AutoIncrement = false;
				colvarHalluxValgus.IsNullable = false;
				colvarHalluxValgus.IsPrimaryKey = false;
				colvarHalluxValgus.IsForeignKey = false;
				colvarHalluxValgus.IsReadOnly = false;
				
						colvarHalluxValgus.DefaultSetting = @"((0))";
				colvarHalluxValgus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHalluxValgus);
				
				TableSchema.TableColumn colvarAusenciaVello = new TableSchema.TableColumn(schema);
				colvarAusenciaVello.ColumnName = "ausenciaVello";
				colvarAusenciaVello.DataType = DbType.Int32;
				colvarAusenciaVello.MaxLength = 0;
				colvarAusenciaVello.AutoIncrement = false;
				colvarAusenciaVello.IsNullable = false;
				colvarAusenciaVello.IsPrimaryKey = false;
				colvarAusenciaVello.IsForeignKey = false;
				colvarAusenciaVello.IsReadOnly = false;
				
						colvarAusenciaVello.DefaultSetting = @"((0))";
				colvarAusenciaVello.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAusenciaVello);
				
				TableSchema.TableColumn colvarDisminucionPlantar = new TableSchema.TableColumn(schema);
				colvarDisminucionPlantar.ColumnName = "disminucionPlantar";
				colvarDisminucionPlantar.DataType = DbType.Int32;
				colvarDisminucionPlantar.MaxLength = 0;
				colvarDisminucionPlantar.AutoIncrement = false;
				colvarDisminucionPlantar.IsNullable = false;
				colvarDisminucionPlantar.IsPrimaryKey = false;
				colvarDisminucionPlantar.IsForeignKey = false;
				colvarDisminucionPlantar.IsReadOnly = false;
				
						colvarDisminucionPlantar.DefaultSetting = @"((0))";
				colvarDisminucionPlantar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDisminucionPlantar);
				
				TableSchema.TableColumn colvarEritroclanosis = new TableSchema.TableColumn(schema);
				colvarEritroclanosis.ColumnName = "eritroclanosis";
				colvarEritroclanosis.DataType = DbType.Int32;
				colvarEritroclanosis.MaxLength = 0;
				colvarEritroclanosis.AutoIncrement = false;
				colvarEritroclanosis.IsNullable = false;
				colvarEritroclanosis.IsPrimaryKey = false;
				colvarEritroclanosis.IsForeignKey = false;
				colvarEritroclanosis.IsReadOnly = false;
				
						colvarEritroclanosis.DefaultSetting = @"((0))";
				colvarEritroclanosis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEritroclanosis);
				
				TableSchema.TableColumn colvarHiperqueatosisPlantar = new TableSchema.TableColumn(schema);
				colvarHiperqueatosisPlantar.ColumnName = "hiperqueatosisPlantar";
				colvarHiperqueatosisPlantar.DataType = DbType.Int32;
				colvarHiperqueatosisPlantar.MaxLength = 0;
				colvarHiperqueatosisPlantar.AutoIncrement = false;
				colvarHiperqueatosisPlantar.IsNullable = false;
				colvarHiperqueatosisPlantar.IsPrimaryKey = false;
				colvarHiperqueatosisPlantar.IsForeignKey = false;
				colvarHiperqueatosisPlantar.IsReadOnly = false;
				
						colvarHiperqueatosisPlantar.DefaultSetting = @"((0))";
				colvarHiperqueatosisPlantar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHiperqueatosisPlantar);
				
				TableSchema.TableColumn colvarHiperqueatosisUnias = new TableSchema.TableColumn(schema);
				colvarHiperqueatosisUnias.ColumnName = "hiperqueatosisUnias";
				colvarHiperqueatosisUnias.DataType = DbType.Int32;
				colvarHiperqueatosisUnias.MaxLength = 0;
				colvarHiperqueatosisUnias.AutoIncrement = false;
				colvarHiperqueatosisUnias.IsNullable = false;
				colvarHiperqueatosisUnias.IsPrimaryKey = false;
				colvarHiperqueatosisUnias.IsForeignKey = false;
				colvarHiperqueatosisUnias.IsReadOnly = false;
				
						colvarHiperqueatosisUnias.DefaultSetting = @"((0))";
				colvarHiperqueatosisUnias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHiperqueatosisUnias);
				
				TableSchema.TableColumn colvarMicosisUnias = new TableSchema.TableColumn(schema);
				colvarMicosisUnias.ColumnName = "micosisUnias";
				colvarMicosisUnias.DataType = DbType.Int32;
				colvarMicosisUnias.MaxLength = 0;
				colvarMicosisUnias.AutoIncrement = false;
				colvarMicosisUnias.IsNullable = false;
				colvarMicosisUnias.IsPrimaryKey = false;
				colvarMicosisUnias.IsForeignKey = false;
				colvarMicosisUnias.IsReadOnly = false;
				colvarMicosisUnias.DefaultSetting = @"";
				colvarMicosisUnias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMicosisUnias);
				
				TableSchema.TableColumn colvarPresenciaLesiones = new TableSchema.TableColumn(schema);
				colvarPresenciaLesiones.ColumnName = "presenciaLesiones";
				colvarPresenciaLesiones.DataType = DbType.AnsiString;
				colvarPresenciaLesiones.MaxLength = 200;
				colvarPresenciaLesiones.AutoIncrement = false;
				colvarPresenciaLesiones.IsNullable = false;
				colvarPresenciaLesiones.IsPrimaryKey = false;
				colvarPresenciaLesiones.IsForeignKey = false;
				colvarPresenciaLesiones.IsReadOnly = false;
				
						colvarPresenciaLesiones.DefaultSetting = @"('')";
				colvarPresenciaLesiones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPresenciaLesiones);
				
				TableSchema.TableColumn colvarPuntajeNegativo = new TableSchema.TableColumn(schema);
				colvarPuntajeNegativo.ColumnName = "puntajeNegativo";
				colvarPuntajeNegativo.DataType = DbType.Int32;
				colvarPuntajeNegativo.MaxLength = 0;
				colvarPuntajeNegativo.AutoIncrement = false;
				colvarPuntajeNegativo.IsNullable = true;
				colvarPuntajeNegativo.IsPrimaryKey = false;
				colvarPuntajeNegativo.IsForeignKey = false;
				colvarPuntajeNegativo.IsReadOnly = false;
				
						colvarPuntajeNegativo.DefaultSetting = @"((0))";
				colvarPuntajeNegativo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPuntajeNegativo);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_ExamenPie",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdExamenPies")]
		[Bindable(true)]
		public int IdExamenPies 
		{
			get { return GetColumnValue<int>(Columns.IdExamenPies); }
			set { SetColumnValue(Columns.IdExamenPies, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int IdClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("SensibTermica")]
		[Bindable(true)]
		public int SensibTermica 
		{
			get { return GetColumnValue<int>(Columns.SensibTermica); }
			set { SetColumnValue(Columns.SensibTermica, value); }
		}
		  
		[XmlAttribute("SensibAlgesica")]
		[Bindable(true)]
		public int SensibAlgesica 
		{
			get { return GetColumnValue<int>(Columns.SensibAlgesica); }
			set { SetColumnValue(Columns.SensibAlgesica, value); }
		}
		  
		[XmlAttribute("ReflejoPatelar")]
		[Bindable(true)]
		public int ReflejoPatelar 
		{
			get { return GetColumnValue<int>(Columns.ReflejoPatelar); }
			set { SetColumnValue(Columns.ReflejoPatelar, value); }
		}
		  
		[XmlAttribute("ReflejoAquileano")]
		[Bindable(true)]
		public int ReflejoAquileano 
		{
			get { return GetColumnValue<int>(Columns.ReflejoAquileano); }
			set { SetColumnValue(Columns.ReflejoAquileano, value); }
		}
		  
		[XmlAttribute("SignoAbanico")]
		[Bindable(true)]
		public int SignoAbanico 
		{
			get { return GetColumnValue<int>(Columns.SignoAbanico); }
			set { SetColumnValue(Columns.SignoAbanico, value); }
		}
		  
		[XmlAttribute("SensibDiapason")]
		[Bindable(true)]
		public int SensibDiapason 
		{
			get { return GetColumnValue<int>(Columns.SensibDiapason); }
			set { SetColumnValue(Columns.SensibDiapason, value); }
		}
		  
		[XmlAttribute("FuerzaMuscular")]
		[Bindable(true)]
		public int FuerzaMuscular 
		{
			get { return GetColumnValue<int>(Columns.FuerzaMuscular); }
			set { SetColumnValue(Columns.FuerzaMuscular, value); }
		}
		  
		[XmlAttribute("AlteracionesApoyo")]
		[Bindable(true)]
		public int AlteracionesApoyo 
		{
			get { return GetColumnValue<int>(Columns.AlteracionesApoyo); }
			set { SetColumnValue(Columns.AlteracionesApoyo, value); }
		}
		  
		[XmlAttribute("DisminucionMovilidad")]
		[Bindable(true)]
		public int DisminucionMovilidad 
		{
			get { return GetColumnValue<int>(Columns.DisminucionMovilidad); }
			set { SetColumnValue(Columns.DisminucionMovilidad, value); }
		}
		  
		[XmlAttribute("DedosMartillo")]
		[Bindable(true)]
		public int DedosMartillo 
		{
			get { return GetColumnValue<int>(Columns.DedosMartillo); }
			set { SetColumnValue(Columns.DedosMartillo, value); }
		}
		  
		[XmlAttribute("Clinodactilia")]
		[Bindable(true)]
		public int Clinodactilia 
		{
			get { return GetColumnValue<int>(Columns.Clinodactilia); }
			set { SetColumnValue(Columns.Clinodactilia, value); }
		}
		  
		[XmlAttribute("HalluxValgus")]
		[Bindable(true)]
		public int HalluxValgus 
		{
			get { return GetColumnValue<int>(Columns.HalluxValgus); }
			set { SetColumnValue(Columns.HalluxValgus, value); }
		}
		  
		[XmlAttribute("AusenciaVello")]
		[Bindable(true)]
		public int AusenciaVello 
		{
			get { return GetColumnValue<int>(Columns.AusenciaVello); }
			set { SetColumnValue(Columns.AusenciaVello, value); }
		}
		  
		[XmlAttribute("DisminucionPlantar")]
		[Bindable(true)]
		public int DisminucionPlantar 
		{
			get { return GetColumnValue<int>(Columns.DisminucionPlantar); }
			set { SetColumnValue(Columns.DisminucionPlantar, value); }
		}
		  
		[XmlAttribute("Eritroclanosis")]
		[Bindable(true)]
		public int Eritroclanosis 
		{
			get { return GetColumnValue<int>(Columns.Eritroclanosis); }
			set { SetColumnValue(Columns.Eritroclanosis, value); }
		}
		  
		[XmlAttribute("HiperqueatosisPlantar")]
		[Bindable(true)]
		public int HiperqueatosisPlantar 
		{
			get { return GetColumnValue<int>(Columns.HiperqueatosisPlantar); }
			set { SetColumnValue(Columns.HiperqueatosisPlantar, value); }
		}
		  
		[XmlAttribute("HiperqueatosisUnias")]
		[Bindable(true)]
		public int HiperqueatosisUnias 
		{
			get { return GetColumnValue<int>(Columns.HiperqueatosisUnias); }
			set { SetColumnValue(Columns.HiperqueatosisUnias, value); }
		}
		  
		[XmlAttribute("MicosisUnias")]
		[Bindable(true)]
		public int MicosisUnias 
		{
			get { return GetColumnValue<int>(Columns.MicosisUnias); }
			set { SetColumnValue(Columns.MicosisUnias, value); }
		}
		  
		[XmlAttribute("PresenciaLesiones")]
		[Bindable(true)]
		public string PresenciaLesiones 
		{
			get { return GetColumnValue<string>(Columns.PresenciaLesiones); }
			set { SetColumnValue(Columns.PresenciaLesiones, value); }
		}
		  
		[XmlAttribute("PuntajeNegativo")]
		[Bindable(true)]
		public int? PuntajeNegativo 
		{
			get { return GetColumnValue<int?>(Columns.PuntajeNegativo); }
			set { SetColumnValue(Columns.PuntajeNegativo, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.RemTablaExamanCollection colRemTablaExamen;
		public DalSic.RemTablaExamanCollection RemTablaExamen
		{
			get
			{
				if(colRemTablaExamen == null)
				{
					colRemTablaExamen = new DalSic.RemTablaExamanCollection().Where(RemTablaExaman.Columns.IdExamenPies, IdExamenPies).Load();
					colRemTablaExamen.ListChanged += new ListChangedEventHandler(colRemTablaExamen_ListChanged);
				}
				return colRemTablaExamen;			
			}
			set 
			{ 
					colRemTablaExamen = value; 
					colRemTablaExamen.ListChanged += new ListChangedEventHandler(colRemTablaExamen_ListChanged);
			}
		}
		
		void colRemTablaExamen_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemTablaExamen[e.NewIndex].IdExamenPies = IdExamenPies;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a RemClasificacion ActiveRecord object related to this RemExamenPie
		/// 
		/// </summary>
		public DalSic.RemClasificacion RemClasificacion
		{
			get { return DalSic.RemClasificacion.FetchByID(this.IdClasificacion); }
			set { SetColumnValue("idClasificacion", value.IdClasificacion); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdClasificacion,int varIdPaciente,DateTime varFecha,string varObservacion,int varSensibTermica,int varSensibAlgesica,int varReflejoPatelar,int varReflejoAquileano,int varSignoAbanico,int varSensibDiapason,int varFuerzaMuscular,int varAlteracionesApoyo,int varDisminucionMovilidad,int varDedosMartillo,int varClinodactilia,int varHalluxValgus,int varAusenciaVello,int varDisminucionPlantar,int varEritroclanosis,int varHiperqueatosisPlantar,int varHiperqueatosisUnias,int varMicosisUnias,string varPresenciaLesiones,int? varPuntajeNegativo,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
		{
			RemExamenPie item = new RemExamenPie();
			
			item.IdEfector = varIdEfector;
			
			item.IdClasificacion = varIdClasificacion;
			
			item.IdPaciente = varIdPaciente;
			
			item.Fecha = varFecha;
			
			item.Observacion = varObservacion;
			
			item.SensibTermica = varSensibTermica;
			
			item.SensibAlgesica = varSensibAlgesica;
			
			item.ReflejoPatelar = varReflejoPatelar;
			
			item.ReflejoAquileano = varReflejoAquileano;
			
			item.SignoAbanico = varSignoAbanico;
			
			item.SensibDiapason = varSensibDiapason;
			
			item.FuerzaMuscular = varFuerzaMuscular;
			
			item.AlteracionesApoyo = varAlteracionesApoyo;
			
			item.DisminucionMovilidad = varDisminucionMovilidad;
			
			item.DedosMartillo = varDedosMartillo;
			
			item.Clinodactilia = varClinodactilia;
			
			item.HalluxValgus = varHalluxValgus;
			
			item.AusenciaVello = varAusenciaVello;
			
			item.DisminucionPlantar = varDisminucionPlantar;
			
			item.Eritroclanosis = varEritroclanosis;
			
			item.HiperqueatosisPlantar = varHiperqueatosisPlantar;
			
			item.HiperqueatosisUnias = varHiperqueatosisUnias;
			
			item.MicosisUnias = varMicosisUnias;
			
			item.PresenciaLesiones = varPresenciaLesiones;
			
			item.PuntajeNegativo = varPuntajeNegativo;
			
			item.CreatedOn = varCreatedOn;
			
			item.CreatedBy = varCreatedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.ModifiedBy = varModifiedBy;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdExamenPies,int varIdEfector,int varIdClasificacion,int varIdPaciente,DateTime varFecha,string varObservacion,int varSensibTermica,int varSensibAlgesica,int varReflejoPatelar,int varReflejoAquileano,int varSignoAbanico,int varSensibDiapason,int varFuerzaMuscular,int varAlteracionesApoyo,int varDisminucionMovilidad,int varDedosMartillo,int varClinodactilia,int varHalluxValgus,int varAusenciaVello,int varDisminucionPlantar,int varEritroclanosis,int varHiperqueatosisPlantar,int varHiperqueatosisUnias,int varMicosisUnias,string varPresenciaLesiones,int? varPuntajeNegativo,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
		{
			RemExamenPie item = new RemExamenPie();
			
				item.IdExamenPies = varIdExamenPies;
			
				item.IdEfector = varIdEfector;
			
				item.IdClasificacion = varIdClasificacion;
			
				item.IdPaciente = varIdPaciente;
			
				item.Fecha = varFecha;
			
				item.Observacion = varObservacion;
			
				item.SensibTermica = varSensibTermica;
			
				item.SensibAlgesica = varSensibAlgesica;
			
				item.ReflejoPatelar = varReflejoPatelar;
			
				item.ReflejoAquileano = varReflejoAquileano;
			
				item.SignoAbanico = varSignoAbanico;
			
				item.SensibDiapason = varSensibDiapason;
			
				item.FuerzaMuscular = varFuerzaMuscular;
			
				item.AlteracionesApoyo = varAlteracionesApoyo;
			
				item.DisminucionMovilidad = varDisminucionMovilidad;
			
				item.DedosMartillo = varDedosMartillo;
			
				item.Clinodactilia = varClinodactilia;
			
				item.HalluxValgus = varHalluxValgus;
			
				item.AusenciaVello = varAusenciaVello;
			
				item.DisminucionPlantar = varDisminucionPlantar;
			
				item.Eritroclanosis = varEritroclanosis;
			
				item.HiperqueatosisPlantar = varHiperqueatosisPlantar;
			
				item.HiperqueatosisUnias = varHiperqueatosisUnias;
			
				item.MicosisUnias = varMicosisUnias;
			
				item.PresenciaLesiones = varPresenciaLesiones;
			
				item.PuntajeNegativo = varPuntajeNegativo;
			
				item.CreatedOn = varCreatedOn;
			
				item.CreatedBy = varCreatedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.ModifiedBy = varModifiedBy;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdExamenPiesColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SensibTermicaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SensibAlgesicaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ReflejoPatelarColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ReflejoAquileanoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SignoAbanicoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SensibDiapasonColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FuerzaMuscularColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn AlteracionesApoyoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DisminucionMovilidadColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn DedosMartilloColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ClinodactiliaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn HalluxValgusColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn AusenciaVelloColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn DisminucionPlantarColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn EritroclanosisColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn HiperqueatosisPlantarColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn HiperqueatosisUniasColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn MicosisUniasColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn PresenciaLesionesColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn PuntajeNegativoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdExamenPies = @"idExamenPies";
			 public static string IdEfector = @"idEfector";
			 public static string IdClasificacion = @"idClasificacion";
			 public static string IdPaciente = @"idPaciente";
			 public static string Fecha = @"fecha";
			 public static string Observacion = @"observacion";
			 public static string SensibTermica = @"sensibTermica";
			 public static string SensibAlgesica = @"sensibAlgesica";
			 public static string ReflejoPatelar = @"reflejoPatelar";
			 public static string ReflejoAquileano = @"reflejoAquileano";
			 public static string SignoAbanico = @"signoAbanico";
			 public static string SensibDiapason = @"sensibDiapason";
			 public static string FuerzaMuscular = @"fuerzaMuscular";
			 public static string AlteracionesApoyo = @"alteracionesApoyo";
			 public static string DisminucionMovilidad = @"disminucionMovilidad";
			 public static string DedosMartillo = @"dedosMartillo";
			 public static string Clinodactilia = @"clinodactilia";
			 public static string HalluxValgus = @"halluxValgus";
			 public static string AusenciaVello = @"ausenciaVello";
			 public static string DisminucionPlantar = @"disminucionPlantar";
			 public static string Eritroclanosis = @"eritroclanosis";
			 public static string HiperqueatosisPlantar = @"hiperqueatosisPlantar";
			 public static string HiperqueatosisUnias = @"hiperqueatosisUnias";
			 public static string MicosisUnias = @"micosisUnias";
			 public static string PresenciaLesiones = @"presenciaLesiones";
			 public static string PuntajeNegativo = @"puntajeNegativo";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colRemTablaExamen != null)
                {
                    foreach (DalSic.RemTablaExaman item in colRemTablaExamen)
                    {
                        if (item.IdExamenPies != IdExamenPies)
                        {
                            item.IdExamenPies = IdExamenPies;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colRemTablaExamen != null)
                {
                    colRemTablaExamen.SaveAll();
               }
		}
        #endregion
	}
}
