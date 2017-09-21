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
	/// Strongly-typed collection for the RemComplicacione class.
	/// </summary>
    [Serializable]
	public partial class RemComplicacioneCollection : ActiveList<RemComplicacione, RemComplicacioneCollection>
	{	   
		public RemComplicacioneCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemComplicacioneCollection</returns>
		public RemComplicacioneCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemComplicacione o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_Complicaciones table.
	/// </summary>
	[Serializable]
	public partial class RemComplicacione : ActiveRecord<RemComplicacione>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemComplicacione()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemComplicacione(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemComplicacione(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemComplicacione(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_Complicaciones", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdComplicaciones = new TableSchema.TableColumn(schema);
				colvarIdComplicaciones.ColumnName = "idComplicaciones";
				colvarIdComplicaciones.DataType = DbType.Int32;
				colvarIdComplicaciones.MaxLength = 0;
				colvarIdComplicaciones.AutoIncrement = true;
				colvarIdComplicaciones.IsNullable = false;
				colvarIdComplicaciones.IsPrimaryKey = true;
				colvarIdComplicaciones.IsForeignKey = false;
				colvarIdComplicaciones.IsReadOnly = false;
				colvarIdComplicaciones.DefaultSetting = @"";
				colvarIdComplicaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdComplicaciones);
				
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
				
				TableSchema.TableColumn colvarDisfuncionErectil = new TableSchema.TableColumn(schema);
				colvarDisfuncionErectil.ColumnName = "disfuncionErectil";
				colvarDisfuncionErectil.DataType = DbType.Boolean;
				colvarDisfuncionErectil.MaxLength = 0;
				colvarDisfuncionErectil.AutoIncrement = false;
				colvarDisfuncionErectil.IsNullable = false;
				colvarDisfuncionErectil.IsPrimaryKey = false;
				colvarDisfuncionErectil.IsForeignKey = false;
				colvarDisfuncionErectil.IsReadOnly = false;
				
						colvarDisfuncionErectil.DefaultSetting = @"((0))";
				colvarDisfuncionErectil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDisfuncionErectil);
				
				TableSchema.TableColumn colvarHipotencionOrtost = new TableSchema.TableColumn(schema);
				colvarHipotencionOrtost.ColumnName = "hipotencionOrtost";
				colvarHipotencionOrtost.DataType = DbType.Boolean;
				colvarHipotencionOrtost.MaxLength = 0;
				colvarHipotencionOrtost.AutoIncrement = false;
				colvarHipotencionOrtost.IsNullable = false;
				colvarHipotencionOrtost.IsPrimaryKey = false;
				colvarHipotencionOrtost.IsForeignKey = false;
				colvarHipotencionOrtost.IsReadOnly = false;
				
						colvarHipotencionOrtost.DefaultSetting = @"((0))";
				colvarHipotencionOrtost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHipotencionOrtost);
				
				TableSchema.TableColumn colvarIam = new TableSchema.TableColumn(schema);
				colvarIam.ColumnName = "iam";
				colvarIam.DataType = DbType.Boolean;
				colvarIam.MaxLength = 0;
				colvarIam.AutoIncrement = false;
				colvarIam.IsNullable = false;
				colvarIam.IsPrimaryKey = false;
				colvarIam.IsForeignKey = false;
				colvarIam.IsReadOnly = false;
				
						colvarIam.DefaultSetting = @"((0))";
				colvarIam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIam);
				
				TableSchema.TableColumn colvarAnginaPecho = new TableSchema.TableColumn(schema);
				colvarAnginaPecho.ColumnName = "anginaPecho";
				colvarAnginaPecho.DataType = DbType.Boolean;
				colvarAnginaPecho.MaxLength = 0;
				colvarAnginaPecho.AutoIncrement = false;
				colvarAnginaPecho.IsNullable = false;
				colvarAnginaPecho.IsPrimaryKey = false;
				colvarAnginaPecho.IsForeignKey = false;
				colvarAnginaPecho.IsReadOnly = false;
				
						colvarAnginaPecho.DefaultSetting = @"((1))";
				colvarAnginaPecho.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnginaPecho);
				
				TableSchema.TableColumn colvarAcv = new TableSchema.TableColumn(schema);
				colvarAcv.ColumnName = "acv";
				colvarAcv.DataType = DbType.Boolean;
				colvarAcv.MaxLength = 0;
				colvarAcv.AutoIncrement = false;
				colvarAcv.IsNullable = false;
				colvarAcv.IsPrimaryKey = false;
				colvarAcv.IsForeignKey = false;
				colvarAcv.IsReadOnly = false;
				
						colvarAcv.DefaultSetting = @"((0))";
				colvarAcv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcv);
				
				TableSchema.TableColumn colvarAit = new TableSchema.TableColumn(schema);
				colvarAit.ColumnName = "ait";
				colvarAit.DataType = DbType.Boolean;
				colvarAit.MaxLength = 0;
				colvarAit.AutoIncrement = false;
				colvarAit.IsNullable = false;
				colvarAit.IsPrimaryKey = false;
				colvarAit.IsForeignKey = false;
				colvarAit.IsReadOnly = false;
				
						colvarAit.DefaultSetting = @"((1))";
				colvarAit.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAit);
				
				TableSchema.TableColumn colvarClaudicMMII = new TableSchema.TableColumn(schema);
				colvarClaudicMMII.ColumnName = "claudicMMII";
				colvarClaudicMMII.DataType = DbType.Boolean;
				colvarClaudicMMII.MaxLength = 0;
				colvarClaudicMMII.AutoIncrement = false;
				colvarClaudicMMII.IsNullable = false;
				colvarClaudicMMII.IsPrimaryKey = false;
				colvarClaudicMMII.IsForeignKey = false;
				colvarClaudicMMII.IsReadOnly = false;
				
						colvarClaudicMMII.DefaultSetting = @"((0))";
				colvarClaudicMMII.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClaudicMMII);
				
				TableSchema.TableColumn colvarCirugRevascMioc = new TableSchema.TableColumn(schema);
				colvarCirugRevascMioc.ColumnName = "cirugRevascMioc";
				colvarCirugRevascMioc.DataType = DbType.Boolean;
				colvarCirugRevascMioc.MaxLength = 0;
				colvarCirugRevascMioc.AutoIncrement = false;
				colvarCirugRevascMioc.IsNullable = false;
				colvarCirugRevascMioc.IsPrimaryKey = false;
				colvarCirugRevascMioc.IsForeignKey = false;
				colvarCirugRevascMioc.IsReadOnly = false;
				
						colvarCirugRevascMioc.DefaultSetting = @"((0))";
				colvarCirugRevascMioc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCirugRevascMioc);
				
				TableSchema.TableColumn colvarInsuficienciaRenal = new TableSchema.TableColumn(schema);
				colvarInsuficienciaRenal.ColumnName = "insuficienciaRenal";
				colvarInsuficienciaRenal.DataType = DbType.Boolean;
				colvarInsuficienciaRenal.MaxLength = 0;
				colvarInsuficienciaRenal.AutoIncrement = false;
				colvarInsuficienciaRenal.IsNullable = false;
				colvarInsuficienciaRenal.IsPrimaryKey = false;
				colvarInsuficienciaRenal.IsForeignKey = false;
				colvarInsuficienciaRenal.IsReadOnly = false;
				
						colvarInsuficienciaRenal.DefaultSetting = @"((0))";
				colvarInsuficienciaRenal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsuficienciaRenal);
				
				TableSchema.TableColumn colvarNefropatia = new TableSchema.TableColumn(schema);
				colvarNefropatia.ColumnName = "nefropatia";
				colvarNefropatia.DataType = DbType.Boolean;
				colvarNefropatia.MaxLength = 0;
				colvarNefropatia.AutoIncrement = false;
				colvarNefropatia.IsNullable = false;
				colvarNefropatia.IsPrimaryKey = false;
				colvarNefropatia.IsForeignKey = false;
				colvarNefropatia.IsReadOnly = false;
				
						colvarNefropatia.DefaultSetting = @"((0))";
				colvarNefropatia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNefropatia);
				
				TableSchema.TableColumn colvarDialisis = new TableSchema.TableColumn(schema);
				colvarDialisis.ColumnName = "dialisis";
				colvarDialisis.DataType = DbType.Boolean;
				colvarDialisis.MaxLength = 0;
				colvarDialisis.AutoIncrement = false;
				colvarDialisis.IsNullable = false;
				colvarDialisis.IsPrimaryKey = false;
				colvarDialisis.IsForeignKey = false;
				colvarDialisis.IsReadOnly = false;
				
						colvarDialisis.DefaultSetting = @"((0))";
				colvarDialisis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDialisis);
				
				TableSchema.TableColumn colvarTransplante = new TableSchema.TableColumn(schema);
				colvarTransplante.ColumnName = "transplante";
				colvarTransplante.DataType = DbType.Boolean;
				colvarTransplante.MaxLength = 0;
				colvarTransplante.AutoIncrement = false;
				colvarTransplante.IsNullable = false;
				colvarTransplante.IsPrimaryKey = false;
				colvarTransplante.IsForeignKey = false;
				colvarTransplante.IsReadOnly = false;
				
						colvarTransplante.DefaultSetting = @"((0))";
				colvarTransplante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransplante);
				
				TableSchema.TableColumn colvarCeguera = new TableSchema.TableColumn(schema);
				colvarCeguera.ColumnName = "ceguera";
				colvarCeguera.DataType = DbType.Boolean;
				colvarCeguera.MaxLength = 0;
				colvarCeguera.AutoIncrement = false;
				colvarCeguera.IsNullable = false;
				colvarCeguera.IsPrimaryKey = false;
				colvarCeguera.IsForeignKey = false;
				colvarCeguera.IsReadOnly = false;
				
						colvarCeguera.DefaultSetting = @"((0))";
				colvarCeguera.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCeguera);
				
				TableSchema.TableColumn colvarAmputSupramal = new TableSchema.TableColumn(schema);
				colvarAmputSupramal.ColumnName = "amputSupramal";
				colvarAmputSupramal.DataType = DbType.Boolean;
				colvarAmputSupramal.MaxLength = 0;
				colvarAmputSupramal.AutoIncrement = false;
				colvarAmputSupramal.IsNullable = false;
				colvarAmputSupramal.IsPrimaryKey = false;
				colvarAmputSupramal.IsForeignKey = false;
				colvarAmputSupramal.IsReadOnly = false;
				
						colvarAmputSupramal.DefaultSetting = @"((0))";
				colvarAmputSupramal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmputSupramal);
				
				TableSchema.TableColumn colvarAmputInferomal = new TableSchema.TableColumn(schema);
				colvarAmputInferomal.ColumnName = "amputInferomal";
				colvarAmputInferomal.DataType = DbType.Boolean;
				colvarAmputInferomal.MaxLength = 0;
				colvarAmputInferomal.AutoIncrement = false;
				colvarAmputInferomal.IsNullable = false;
				colvarAmputInferomal.IsPrimaryKey = false;
				colvarAmputInferomal.IsForeignKey = false;
				colvarAmputInferomal.IsReadOnly = false;
				
						colvarAmputInferomal.DefaultSetting = @"((0))";
				colvarAmputInferomal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmputInferomal);
				
				TableSchema.TableColumn colvarOtrasAmputaciones = new TableSchema.TableColumn(schema);
				colvarOtrasAmputaciones.ColumnName = "otrasAmputaciones";
				colvarOtrasAmputaciones.DataType = DbType.Boolean;
				colvarOtrasAmputaciones.MaxLength = 0;
				colvarOtrasAmputaciones.AutoIncrement = false;
				colvarOtrasAmputaciones.IsNullable = false;
				colvarOtrasAmputaciones.IsPrimaryKey = false;
				colvarOtrasAmputaciones.IsForeignKey = false;
				colvarOtrasAmputaciones.IsReadOnly = false;
				
						colvarOtrasAmputaciones.DefaultSetting = @"((0))";
				colvarOtrasAmputaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrasAmputaciones);
				
				TableSchema.TableColumn colvarEcg = new TableSchema.TableColumn(schema);
				colvarEcg.ColumnName = "ECG";
				colvarEcg.DataType = DbType.DateTime;
				colvarEcg.MaxLength = 0;
				colvarEcg.AutoIncrement = false;
				colvarEcg.IsNullable = false;
				colvarEcg.IsPrimaryKey = false;
				colvarEcg.IsForeignKey = false;
				colvarEcg.IsReadOnly = false;
				
						colvarEcg.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarEcg.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEcg);
				
				TableSchema.TableColumn colvarHipertrofia = new TableSchema.TableColumn(schema);
				colvarHipertrofia.ColumnName = "hipertrofia";
				colvarHipertrofia.DataType = DbType.Boolean;
				colvarHipertrofia.MaxLength = 0;
				colvarHipertrofia.AutoIncrement = false;
				colvarHipertrofia.IsNullable = false;
				colvarHipertrofia.IsPrimaryKey = false;
				colvarHipertrofia.IsForeignKey = false;
				colvarHipertrofia.IsReadOnly = false;
				
						colvarHipertrofia.DefaultSetting = @"((0))";
				colvarHipertrofia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHipertrofia);
				
				TableSchema.TableColumn colvarNormal = new TableSchema.TableColumn(schema);
				colvarNormal.ColumnName = "normal";
				colvarNormal.DataType = DbType.Boolean;
				colvarNormal.MaxLength = 0;
				colvarNormal.AutoIncrement = false;
				colvarNormal.IsNullable = false;
				colvarNormal.IsPrimaryKey = false;
				colvarNormal.IsForeignKey = false;
				colvarNormal.IsReadOnly = false;
				
						colvarNormal.DefaultSetting = @"((0))";
				colvarNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNormal);
				
				TableSchema.TableColumn colvarEcocardiograma = new TableSchema.TableColumn(schema);
				colvarEcocardiograma.ColumnName = "ecocardiograma";
				colvarEcocardiograma.DataType = DbType.DateTime;
				colvarEcocardiograma.MaxLength = 0;
				colvarEcocardiograma.AutoIncrement = false;
				colvarEcocardiograma.IsNullable = false;
				colvarEcocardiograma.IsPrimaryKey = false;
				colvarEcocardiograma.IsForeignKey = false;
				colvarEcocardiograma.IsReadOnly = false;
				
						colvarEcocardiograma.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarEcocardiograma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEcocardiograma);
				
				TableSchema.TableColumn colvarEcocardNormal = new TableSchema.TableColumn(schema);
				colvarEcocardNormal.ColumnName = "ecocardNormal";
				colvarEcocardNormal.DataType = DbType.Boolean;
				colvarEcocardNormal.MaxLength = 0;
				colvarEcocardNormal.AutoIncrement = false;
				colvarEcocardNormal.IsNullable = false;
				colvarEcocardNormal.IsPrimaryKey = false;
				colvarEcocardNormal.IsForeignKey = false;
				colvarEcocardNormal.IsReadOnly = false;
				
						colvarEcocardNormal.DefaultSetting = @"((0))";
				colvarEcocardNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEcocardNormal);
				
				TableSchema.TableColumn colvarErgometria = new TableSchema.TableColumn(schema);
				colvarErgometria.ColumnName = "ergometria";
				colvarErgometria.DataType = DbType.DateTime;
				colvarErgometria.MaxLength = 0;
				colvarErgometria.AutoIncrement = false;
				colvarErgometria.IsNullable = false;
				colvarErgometria.IsPrimaryKey = false;
				colvarErgometria.IsForeignKey = false;
				colvarErgometria.IsReadOnly = false;
				
						colvarErgometria.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarErgometria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErgometria);
				
				TableSchema.TableColumn colvarErgometNormal = new TableSchema.TableColumn(schema);
				colvarErgometNormal.ColumnName = "ergometNormal";
				colvarErgometNormal.DataType = DbType.Boolean;
				colvarErgometNormal.MaxLength = 0;
				colvarErgometNormal.AutoIncrement = false;
				colvarErgometNormal.IsNullable = false;
				colvarErgometNormal.IsPrimaryKey = false;
				colvarErgometNormal.IsForeignKey = false;
				colvarErgometNormal.IsReadOnly = false;
				
						colvarErgometNormal.DefaultSetting = @"((0))";
				colvarErgometNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErgometNormal);
				
				TableSchema.TableColumn colvarConsejoAntitabaco = new TableSchema.TableColumn(schema);
				colvarConsejoAntitabaco.ColumnName = "consejoAntitabaco";
				colvarConsejoAntitabaco.DataType = DbType.DateTime;
				colvarConsejoAntitabaco.MaxLength = 0;
				colvarConsejoAntitabaco.AutoIncrement = false;
				colvarConsejoAntitabaco.IsNullable = false;
				colvarConsejoAntitabaco.IsPrimaryKey = false;
				colvarConsejoAntitabaco.IsForeignKey = false;
				colvarConsejoAntitabaco.IsReadOnly = false;
				
						colvarConsejoAntitabaco.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarConsejoAntitabaco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConsejoAntitabaco);
				
				TableSchema.TableColumn colvarPrecontemplativa = new TableSchema.TableColumn(schema);
				colvarPrecontemplativa.ColumnName = "precontemplativa";
				colvarPrecontemplativa.DataType = DbType.Boolean;
				colvarPrecontemplativa.MaxLength = 0;
				colvarPrecontemplativa.AutoIncrement = false;
				colvarPrecontemplativa.IsNullable = false;
				colvarPrecontemplativa.IsPrimaryKey = false;
				colvarPrecontemplativa.IsForeignKey = false;
				colvarPrecontemplativa.IsReadOnly = false;
				
						colvarPrecontemplativa.DefaultSetting = @"((0))";
				colvarPrecontemplativa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrecontemplativa);
				
				TableSchema.TableColumn colvarContemplativa = new TableSchema.TableColumn(schema);
				colvarContemplativa.ColumnName = "contemplativa";
				colvarContemplativa.DataType = DbType.Boolean;
				colvarContemplativa.MaxLength = 0;
				colvarContemplativa.AutoIncrement = false;
				colvarContemplativa.IsNullable = false;
				colvarContemplativa.IsPrimaryKey = false;
				colvarContemplativa.IsForeignKey = false;
				colvarContemplativa.IsReadOnly = false;
				
						colvarContemplativa.DefaultSetting = @"((0))";
				colvarContemplativa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContemplativa);
				
				TableSchema.TableColumn colvarPreparacion = new TableSchema.TableColumn(schema);
				colvarPreparacion.ColumnName = "preparacion";
				colvarPreparacion.DataType = DbType.Boolean;
				colvarPreparacion.MaxLength = 0;
				colvarPreparacion.AutoIncrement = false;
				colvarPreparacion.IsNullable = false;
				colvarPreparacion.IsPrimaryKey = false;
				colvarPreparacion.IsForeignKey = false;
				colvarPreparacion.IsReadOnly = false;
				
						colvarPreparacion.DefaultSetting = @"((0))";
				colvarPreparacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPreparacion);
				
				TableSchema.TableColumn colvarDejoFumar = new TableSchema.TableColumn(schema);
				colvarDejoFumar.ColumnName = "dejoFumar";
				colvarDejoFumar.DataType = DbType.DateTime;
				colvarDejoFumar.MaxLength = 0;
				colvarDejoFumar.AutoIncrement = false;
				colvarDejoFumar.IsNullable = false;
				colvarDejoFumar.IsPrimaryKey = false;
				colvarDejoFumar.IsForeignKey = false;
				colvarDejoFumar.IsReadOnly = false;
				
						colvarDejoFumar.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarDejoFumar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDejoFumar);
				
				TableSchema.TableColumn colvarFechaFojo = new TableSchema.TableColumn(schema);
				colvarFechaFojo.ColumnName = "fechaFojo";
				colvarFechaFojo.DataType = DbType.DateTime;
				colvarFechaFojo.MaxLength = 0;
				colvarFechaFojo.AutoIncrement = false;
				colvarFechaFojo.IsNullable = false;
				colvarFechaFojo.IsPrimaryKey = false;
				colvarFechaFojo.IsForeignKey = false;
				colvarFechaFojo.IsReadOnly = false;
				
						colvarFechaFojo.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaFojo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFojo);
				
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
				
				TableSchema.TableColumn colvarFondoONormal = new TableSchema.TableColumn(schema);
				colvarFondoONormal.ColumnName = "fondoONormal";
				colvarFondoONormal.DataType = DbType.Int32;
				colvarFondoONormal.MaxLength = 0;
				colvarFondoONormal.AutoIncrement = false;
				colvarFondoONormal.IsNullable = false;
				colvarFondoONormal.IsPrimaryKey = false;
				colvarFondoONormal.IsForeignKey = false;
				colvarFondoONormal.IsReadOnly = false;
				
						colvarFondoONormal.DefaultSetting = @"((0))";
				colvarFondoONormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFondoONormal);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_Complicaciones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdComplicaciones")]
		[Bindable(true)]
		public int IdComplicaciones 
		{
			get { return GetColumnValue<int>(Columns.IdComplicaciones); }
			set { SetColumnValue(Columns.IdComplicaciones, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int IdClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		  
		[XmlAttribute("DisfuncionErectil")]
		[Bindable(true)]
		public bool DisfuncionErectil 
		{
			get { return GetColumnValue<bool>(Columns.DisfuncionErectil); }
			set { SetColumnValue(Columns.DisfuncionErectil, value); }
		}
		  
		[XmlAttribute("HipotencionOrtost")]
		[Bindable(true)]
		public bool HipotencionOrtost 
		{
			get { return GetColumnValue<bool>(Columns.HipotencionOrtost); }
			set { SetColumnValue(Columns.HipotencionOrtost, value); }
		}
		  
		[XmlAttribute("Iam")]
		[Bindable(true)]
		public bool Iam 
		{
			get { return GetColumnValue<bool>(Columns.Iam); }
			set { SetColumnValue(Columns.Iam, value); }
		}
		  
		[XmlAttribute("AnginaPecho")]
		[Bindable(true)]
		public bool AnginaPecho 
		{
			get { return GetColumnValue<bool>(Columns.AnginaPecho); }
			set { SetColumnValue(Columns.AnginaPecho, value); }
		}
		  
		[XmlAttribute("Acv")]
		[Bindable(true)]
		public bool Acv 
		{
			get { return GetColumnValue<bool>(Columns.Acv); }
			set { SetColumnValue(Columns.Acv, value); }
		}
		  
		[XmlAttribute("Ait")]
		[Bindable(true)]
		public bool Ait 
		{
			get { return GetColumnValue<bool>(Columns.Ait); }
			set { SetColumnValue(Columns.Ait, value); }
		}
		  
		[XmlAttribute("ClaudicMMII")]
		[Bindable(true)]
		public bool ClaudicMMII 
		{
			get { return GetColumnValue<bool>(Columns.ClaudicMMII); }
			set { SetColumnValue(Columns.ClaudicMMII, value); }
		}
		  
		[XmlAttribute("CirugRevascMioc")]
		[Bindable(true)]
		public bool CirugRevascMioc 
		{
			get { return GetColumnValue<bool>(Columns.CirugRevascMioc); }
			set { SetColumnValue(Columns.CirugRevascMioc, value); }
		}
		  
		[XmlAttribute("InsuficienciaRenal")]
		[Bindable(true)]
		public bool InsuficienciaRenal 
		{
			get { return GetColumnValue<bool>(Columns.InsuficienciaRenal); }
			set { SetColumnValue(Columns.InsuficienciaRenal, value); }
		}
		  
		[XmlAttribute("Nefropatia")]
		[Bindable(true)]
		public bool Nefropatia 
		{
			get { return GetColumnValue<bool>(Columns.Nefropatia); }
			set { SetColumnValue(Columns.Nefropatia, value); }
		}
		  
		[XmlAttribute("Dialisis")]
		[Bindable(true)]
		public bool Dialisis 
		{
			get { return GetColumnValue<bool>(Columns.Dialisis); }
			set { SetColumnValue(Columns.Dialisis, value); }
		}
		  
		[XmlAttribute("Transplante")]
		[Bindable(true)]
		public bool Transplante 
		{
			get { return GetColumnValue<bool>(Columns.Transplante); }
			set { SetColumnValue(Columns.Transplante, value); }
		}
		  
		[XmlAttribute("Ceguera")]
		[Bindable(true)]
		public bool Ceguera 
		{
			get { return GetColumnValue<bool>(Columns.Ceguera); }
			set { SetColumnValue(Columns.Ceguera, value); }
		}
		  
		[XmlAttribute("AmputSupramal")]
		[Bindable(true)]
		public bool AmputSupramal 
		{
			get { return GetColumnValue<bool>(Columns.AmputSupramal); }
			set { SetColumnValue(Columns.AmputSupramal, value); }
		}
		  
		[XmlAttribute("AmputInferomal")]
		[Bindable(true)]
		public bool AmputInferomal 
		{
			get { return GetColumnValue<bool>(Columns.AmputInferomal); }
			set { SetColumnValue(Columns.AmputInferomal, value); }
		}
		  
		[XmlAttribute("OtrasAmputaciones")]
		[Bindable(true)]
		public bool OtrasAmputaciones 
		{
			get { return GetColumnValue<bool>(Columns.OtrasAmputaciones); }
			set { SetColumnValue(Columns.OtrasAmputaciones, value); }
		}
		  
		[XmlAttribute("Ecg")]
		[Bindable(true)]
		public DateTime Ecg 
		{
			get { return GetColumnValue<DateTime>(Columns.Ecg); }
			set { SetColumnValue(Columns.Ecg, value); }
		}
		  
		[XmlAttribute("Hipertrofia")]
		[Bindable(true)]
		public bool Hipertrofia 
		{
			get { return GetColumnValue<bool>(Columns.Hipertrofia); }
			set { SetColumnValue(Columns.Hipertrofia, value); }
		}
		  
		[XmlAttribute("Normal")]
		[Bindable(true)]
		public bool Normal 
		{
			get { return GetColumnValue<bool>(Columns.Normal); }
			set { SetColumnValue(Columns.Normal, value); }
		}
		  
		[XmlAttribute("Ecocardiograma")]
		[Bindable(true)]
		public DateTime Ecocardiograma 
		{
			get { return GetColumnValue<DateTime>(Columns.Ecocardiograma); }
			set { SetColumnValue(Columns.Ecocardiograma, value); }
		}
		  
		[XmlAttribute("EcocardNormal")]
		[Bindable(true)]
		public bool EcocardNormal 
		{
			get { return GetColumnValue<bool>(Columns.EcocardNormal); }
			set { SetColumnValue(Columns.EcocardNormal, value); }
		}
		  
		[XmlAttribute("Ergometria")]
		[Bindable(true)]
		public DateTime Ergometria 
		{
			get { return GetColumnValue<DateTime>(Columns.Ergometria); }
			set { SetColumnValue(Columns.Ergometria, value); }
		}
		  
		[XmlAttribute("ErgometNormal")]
		[Bindable(true)]
		public bool ErgometNormal 
		{
			get { return GetColumnValue<bool>(Columns.ErgometNormal); }
			set { SetColumnValue(Columns.ErgometNormal, value); }
		}
		  
		[XmlAttribute("ConsejoAntitabaco")]
		[Bindable(true)]
		public DateTime ConsejoAntitabaco 
		{
			get { return GetColumnValue<DateTime>(Columns.ConsejoAntitabaco); }
			set { SetColumnValue(Columns.ConsejoAntitabaco, value); }
		}
		  
		[XmlAttribute("Precontemplativa")]
		[Bindable(true)]
		public bool Precontemplativa 
		{
			get { return GetColumnValue<bool>(Columns.Precontemplativa); }
			set { SetColumnValue(Columns.Precontemplativa, value); }
		}
		  
		[XmlAttribute("Contemplativa")]
		[Bindable(true)]
		public bool Contemplativa 
		{
			get { return GetColumnValue<bool>(Columns.Contemplativa); }
			set { SetColumnValue(Columns.Contemplativa, value); }
		}
		  
		[XmlAttribute("Preparacion")]
		[Bindable(true)]
		public bool Preparacion 
		{
			get { return GetColumnValue<bool>(Columns.Preparacion); }
			set { SetColumnValue(Columns.Preparacion, value); }
		}
		  
		[XmlAttribute("DejoFumar")]
		[Bindable(true)]
		public DateTime DejoFumar 
		{
			get { return GetColumnValue<DateTime>(Columns.DejoFumar); }
			set { SetColumnValue(Columns.DejoFumar, value); }
		}
		  
		[XmlAttribute("FechaFojo")]
		[Bindable(true)]
		public DateTime FechaFojo 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaFojo); }
			set { SetColumnValue(Columns.FechaFojo, value); }
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
		  
		[XmlAttribute("FondoONormal")]
		[Bindable(true)]
		public int FondoONormal 
		{
			get { return GetColumnValue<int>(Columns.FondoONormal); }
			set { SetColumnValue(Columns.FondoONormal, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a RemClasificacion ActiveRecord object related to this RemComplicacione
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
		public static void Insert(int varIdClasificacion,bool varDisfuncionErectil,bool varHipotencionOrtost,bool varIam,bool varAnginaPecho,bool varAcv,bool varAit,bool varClaudicMMII,bool varCirugRevascMioc,bool varInsuficienciaRenal,bool varNefropatia,bool varDialisis,bool varTransplante,bool varCeguera,bool varAmputSupramal,bool varAmputInferomal,bool varOtrasAmputaciones,DateTime varEcg,bool varHipertrofia,bool varNormal,DateTime varEcocardiograma,bool varEcocardNormal,DateTime varErgometria,bool varErgometNormal,DateTime varConsejoAntitabaco,bool varPrecontemplativa,bool varContemplativa,bool varPreparacion,DateTime varDejoFumar,DateTime varFechaFojo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varFondoONormal)
		{
			RemComplicacione item = new RemComplicacione();
			
			item.IdClasificacion = varIdClasificacion;
			
			item.DisfuncionErectil = varDisfuncionErectil;
			
			item.HipotencionOrtost = varHipotencionOrtost;
			
			item.Iam = varIam;
			
			item.AnginaPecho = varAnginaPecho;
			
			item.Acv = varAcv;
			
			item.Ait = varAit;
			
			item.ClaudicMMII = varClaudicMMII;
			
			item.CirugRevascMioc = varCirugRevascMioc;
			
			item.InsuficienciaRenal = varInsuficienciaRenal;
			
			item.Nefropatia = varNefropatia;
			
			item.Dialisis = varDialisis;
			
			item.Transplante = varTransplante;
			
			item.Ceguera = varCeguera;
			
			item.AmputSupramal = varAmputSupramal;
			
			item.AmputInferomal = varAmputInferomal;
			
			item.OtrasAmputaciones = varOtrasAmputaciones;
			
			item.Ecg = varEcg;
			
			item.Hipertrofia = varHipertrofia;
			
			item.Normal = varNormal;
			
			item.Ecocardiograma = varEcocardiograma;
			
			item.EcocardNormal = varEcocardNormal;
			
			item.Ergometria = varErgometria;
			
			item.ErgometNormal = varErgometNormal;
			
			item.ConsejoAntitabaco = varConsejoAntitabaco;
			
			item.Precontemplativa = varPrecontemplativa;
			
			item.Contemplativa = varContemplativa;
			
			item.Preparacion = varPreparacion;
			
			item.DejoFumar = varDejoFumar;
			
			item.FechaFojo = varFechaFojo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.FondoONormal = varFondoONormal;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdComplicaciones,int varIdClasificacion,bool varDisfuncionErectil,bool varHipotencionOrtost,bool varIam,bool varAnginaPecho,bool varAcv,bool varAit,bool varClaudicMMII,bool varCirugRevascMioc,bool varInsuficienciaRenal,bool varNefropatia,bool varDialisis,bool varTransplante,bool varCeguera,bool varAmputSupramal,bool varAmputInferomal,bool varOtrasAmputaciones,DateTime varEcg,bool varHipertrofia,bool varNormal,DateTime varEcocardiograma,bool varEcocardNormal,DateTime varErgometria,bool varErgometNormal,DateTime varConsejoAntitabaco,bool varPrecontemplativa,bool varContemplativa,bool varPreparacion,DateTime varDejoFumar,DateTime varFechaFojo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varFondoONormal)
		{
			RemComplicacione item = new RemComplicacione();
			
				item.IdComplicaciones = varIdComplicaciones;
			
				item.IdClasificacion = varIdClasificacion;
			
				item.DisfuncionErectil = varDisfuncionErectil;
			
				item.HipotencionOrtost = varHipotencionOrtost;
			
				item.Iam = varIam;
			
				item.AnginaPecho = varAnginaPecho;
			
				item.Acv = varAcv;
			
				item.Ait = varAit;
			
				item.ClaudicMMII = varClaudicMMII;
			
				item.CirugRevascMioc = varCirugRevascMioc;
			
				item.InsuficienciaRenal = varInsuficienciaRenal;
			
				item.Nefropatia = varNefropatia;
			
				item.Dialisis = varDialisis;
			
				item.Transplante = varTransplante;
			
				item.Ceguera = varCeguera;
			
				item.AmputSupramal = varAmputSupramal;
			
				item.AmputInferomal = varAmputInferomal;
			
				item.OtrasAmputaciones = varOtrasAmputaciones;
			
				item.Ecg = varEcg;
			
				item.Hipertrofia = varHipertrofia;
			
				item.Normal = varNormal;
			
				item.Ecocardiograma = varEcocardiograma;
			
				item.EcocardNormal = varEcocardNormal;
			
				item.Ergometria = varErgometria;
			
				item.ErgometNormal = varErgometNormal;
			
				item.ConsejoAntitabaco = varConsejoAntitabaco;
			
				item.Precontemplativa = varPrecontemplativa;
			
				item.Contemplativa = varContemplativa;
			
				item.Preparacion = varPreparacion;
			
				item.DejoFumar = varDejoFumar;
			
				item.FechaFojo = varFechaFojo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.FondoONormal = varFondoONormal;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdComplicacionesColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DisfuncionErectilColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HipotencionOrtostColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IamColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AnginaPechoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AcvColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AitColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaudicMMIIColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CirugRevascMiocColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn InsuficienciaRenalColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NefropatiaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DialisisColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn TransplanteColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn CegueraColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn AmputSupramalColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn AmputInferomalColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrasAmputacionesColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn EcgColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn HipertrofiaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn NormalColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn EcocardiogramaColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn EcocardNormalColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ErgometriaColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ErgometNormalColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn ConsejoAntitabacoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn PrecontemplativaColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn ContemplativaColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn PreparacionColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn DejoFumarColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFojoColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn FondoONormalColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdComplicaciones = @"idComplicaciones";
			 public static string IdClasificacion = @"idClasificacion";
			 public static string DisfuncionErectil = @"disfuncionErectil";
			 public static string HipotencionOrtost = @"hipotencionOrtost";
			 public static string Iam = @"iam";
			 public static string AnginaPecho = @"anginaPecho";
			 public static string Acv = @"acv";
			 public static string Ait = @"ait";
			 public static string ClaudicMMII = @"claudicMMII";
			 public static string CirugRevascMioc = @"cirugRevascMioc";
			 public static string InsuficienciaRenal = @"insuficienciaRenal";
			 public static string Nefropatia = @"nefropatia";
			 public static string Dialisis = @"dialisis";
			 public static string Transplante = @"transplante";
			 public static string Ceguera = @"ceguera";
			 public static string AmputSupramal = @"amputSupramal";
			 public static string AmputInferomal = @"amputInferomal";
			 public static string OtrasAmputaciones = @"otrasAmputaciones";
			 public static string Ecg = @"ECG";
			 public static string Hipertrofia = @"hipertrofia";
			 public static string Normal = @"normal";
			 public static string Ecocardiograma = @"ecocardiograma";
			 public static string EcocardNormal = @"ecocardNormal";
			 public static string Ergometria = @"ergometria";
			 public static string ErgometNormal = @"ergometNormal";
			 public static string ConsejoAntitabaco = @"consejoAntitabaco";
			 public static string Precontemplativa = @"precontemplativa";
			 public static string Contemplativa = @"contemplativa";
			 public static string Preparacion = @"preparacion";
			 public static string DejoFumar = @"dejoFumar";
			 public static string FechaFojo = @"fechaFojo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string FondoONormal = @"fondoONormal";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
