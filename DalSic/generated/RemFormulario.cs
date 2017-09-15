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
	/// Strongly-typed collection for the RemFormulario class.
	/// </summary>
    [Serializable]
	public partial class RemFormularioCollection : ActiveList<RemFormulario, RemFormularioCollection>
	{	   
		public RemFormularioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemFormularioCollection</returns>
		public RemFormularioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemFormulario o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_Formulario table.
	/// </summary>
	[Serializable]
	public partial class RemFormulario : ActiveRecord<RemFormulario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemFormulario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemFormulario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemFormulario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemFormulario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_Formulario", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdFormulario = new TableSchema.TableColumn(schema);
				colvarIdFormulario.ColumnName = "idFormulario";
				colvarIdFormulario.DataType = DbType.Int32;
				colvarIdFormulario.MaxLength = 0;
				colvarIdFormulario.AutoIncrement = true;
				colvarIdFormulario.IsNullable = false;
				colvarIdFormulario.IsPrimaryKey = true;
				colvarIdFormulario.IsForeignKey = false;
				colvarIdFormulario.IsReadOnly = false;
				colvarIdFormulario.DefaultSetting = @"";
				colvarIdFormulario.ForeignKeyTableName = "";
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
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = false;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = true;
				colvarIdObraSocial.IsReadOnly = false;
				colvarIdObraSocial.DefaultSetting = @"";
				
					colvarIdObraSocial.ForeignKeyTableName = "Sys_ObraSocial";
				schema.Columns.Add(colvarIdObraSocial);
				
				TableSchema.TableColumn colvarNumeroFormulario = new TableSchema.TableColumn(schema);
				colvarNumeroFormulario.ColumnName = "numeroFormulario";
				colvarNumeroFormulario.DataType = DbType.Int32;
				colvarNumeroFormulario.MaxLength = 0;
				colvarNumeroFormulario.AutoIncrement = false;
				colvarNumeroFormulario.IsNullable = false;
				colvarNumeroFormulario.IsPrimaryKey = false;
				colvarNumeroFormulario.IsForeignKey = false;
				colvarNumeroFormulario.IsReadOnly = false;
				
						colvarNumeroFormulario.DefaultSetting = @"((0))";
				colvarNumeroFormulario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroFormulario);
				
				TableSchema.TableColumn colvarFechaEmpadronamiento = new TableSchema.TableColumn(schema);
				colvarFechaEmpadronamiento.ColumnName = "fechaEmpadronamiento";
				colvarFechaEmpadronamiento.DataType = DbType.DateTime;
				colvarFechaEmpadronamiento.MaxLength = 0;
				colvarFechaEmpadronamiento.AutoIncrement = false;
				colvarFechaEmpadronamiento.IsNullable = false;
				colvarFechaEmpadronamiento.IsPrimaryKey = false;
				colvarFechaEmpadronamiento.IsForeignKey = false;
				colvarFechaEmpadronamiento.IsReadOnly = false;
				
						colvarFechaEmpadronamiento.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaEmpadronamiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEmpadronamiento);
				
				TableSchema.TableColumn colvarIdAgente = new TableSchema.TableColumn(schema);
				colvarIdAgente.ColumnName = "idAgente";
				colvarIdAgente.DataType = DbType.Int32;
				colvarIdAgente.MaxLength = 0;
				colvarIdAgente.AutoIncrement = false;
				colvarIdAgente.IsNullable = true;
				colvarIdAgente.IsPrimaryKey = false;
				colvarIdAgente.IsForeignKey = true;
				colvarIdAgente.IsReadOnly = false;
				
						colvarIdAgente.DefaultSetting = @"((0))";
				
					colvarIdAgente.ForeignKeyTableName = "Rem_Agente";
				schema.Columns.Add(colvarIdAgente);
				
				TableSchema.TableColumn colvarIdMunicipio = new TableSchema.TableColumn(schema);
				colvarIdMunicipio.ColumnName = "idMunicipio";
				colvarIdMunicipio.DataType = DbType.Int32;
				colvarIdMunicipio.MaxLength = 0;
				colvarIdMunicipio.AutoIncrement = false;
				colvarIdMunicipio.IsNullable = false;
				colvarIdMunicipio.IsPrimaryKey = false;
				colvarIdMunicipio.IsForeignKey = true;
				colvarIdMunicipio.IsReadOnly = false;
				
						colvarIdMunicipio.DefaultSetting = @"((0))";
				
					colvarIdMunicipio.ForeignKeyTableName = "Sys_Municipio";
				schema.Columns.Add(colvarIdMunicipio);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.Int32;
				colvarSexo.MaxLength = 0;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = false;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				
						colvarSexo.DefaultSetting = @"((0))";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
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
				
				TableSchema.TableColumn colvarHta2 = new TableSchema.TableColumn(schema);
				colvarHta2.ColumnName = "hta2";
				colvarHta2.DataType = DbType.Int32;
				colvarHta2.MaxLength = 0;
				colvarHta2.AutoIncrement = false;
				colvarHta2.IsNullable = false;
				colvarHta2.IsPrimaryKey = false;
				colvarHta2.IsForeignKey = false;
				colvarHta2.IsReadOnly = false;
				
						colvarHta2.DefaultSetting = @"((0))";
				colvarHta2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHta2);
				
				TableSchema.TableColumn colvarHta3 = new TableSchema.TableColumn(schema);
				colvarHta3.ColumnName = "hta3";
				colvarHta3.DataType = DbType.Int32;
				colvarHta3.MaxLength = 0;
				colvarHta3.AutoIncrement = false;
				colvarHta3.IsNullable = false;
				colvarHta3.IsPrimaryKey = false;
				colvarHta3.IsForeignKey = false;
				colvarHta3.IsReadOnly = false;
				
						colvarHta3.DefaultSetting = @"((0))";
				colvarHta3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHta3);
				
				TableSchema.TableColumn colvarColesterol4 = new TableSchema.TableColumn(schema);
				colvarColesterol4.ColumnName = "colesterol4";
				colvarColesterol4.DataType = DbType.Int32;
				colvarColesterol4.MaxLength = 0;
				colvarColesterol4.AutoIncrement = false;
				colvarColesterol4.IsNullable = false;
				colvarColesterol4.IsPrimaryKey = false;
				colvarColesterol4.IsForeignKey = false;
				colvarColesterol4.IsReadOnly = false;
				
						colvarColesterol4.DefaultSetting = @"((0))";
				colvarColesterol4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarColesterol4);
				
				TableSchema.TableColumn colvarColesterol5 = new TableSchema.TableColumn(schema);
				colvarColesterol5.ColumnName = "colesterol5";
				colvarColesterol5.DataType = DbType.Int32;
				colvarColesterol5.MaxLength = 0;
				colvarColesterol5.AutoIncrement = false;
				colvarColesterol5.IsNullable = false;
				colvarColesterol5.IsPrimaryKey = false;
				colvarColesterol5.IsForeignKey = false;
				colvarColesterol5.IsReadOnly = false;
				
						colvarColesterol5.DefaultSetting = @"((0))";
				colvarColesterol5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarColesterol5);
				
				TableSchema.TableColumn colvarDtm26 = new TableSchema.TableColumn(schema);
				colvarDtm26.ColumnName = "dtm26";
				colvarDtm26.DataType = DbType.Int32;
				colvarDtm26.MaxLength = 0;
				colvarDtm26.AutoIncrement = false;
				colvarDtm26.IsNullable = false;
				colvarDtm26.IsPrimaryKey = false;
				colvarDtm26.IsForeignKey = false;
				colvarDtm26.IsReadOnly = false;
				
						colvarDtm26.DefaultSetting = @"((0))";
				colvarDtm26.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDtm26);
				
				TableSchema.TableColumn colvarDtm27 = new TableSchema.TableColumn(schema);
				colvarDtm27.ColumnName = "dtm27";
				colvarDtm27.DataType = DbType.Int32;
				colvarDtm27.MaxLength = 0;
				colvarDtm27.AutoIncrement = false;
				colvarDtm27.IsNullable = false;
				colvarDtm27.IsPrimaryKey = false;
				colvarDtm27.IsForeignKey = false;
				colvarDtm27.IsReadOnly = false;
				
						colvarDtm27.DefaultSetting = @"((0))";
				colvarDtm27.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDtm27);
				
				TableSchema.TableColumn colvarEcv8 = new TableSchema.TableColumn(schema);
				colvarEcv8.ColumnName = "ecv8";
				colvarEcv8.DataType = DbType.Int32;
				colvarEcv8.MaxLength = 0;
				colvarEcv8.AutoIncrement = false;
				colvarEcv8.IsNullable = false;
				colvarEcv8.IsPrimaryKey = false;
				colvarEcv8.IsForeignKey = false;
				colvarEcv8.IsReadOnly = false;
				
						colvarEcv8.DefaultSetting = @"((0))";
				colvarEcv8.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEcv8);
				
				TableSchema.TableColumn colvarTabaco9 = new TableSchema.TableColumn(schema);
				colvarTabaco9.ColumnName = "tabaco9";
				colvarTabaco9.DataType = DbType.Int32;
				colvarTabaco9.MaxLength = 0;
				colvarTabaco9.AutoIncrement = false;
				colvarTabaco9.IsNullable = false;
				colvarTabaco9.IsPrimaryKey = false;
				colvarTabaco9.IsForeignKey = false;
				colvarTabaco9.IsReadOnly = false;
				
						colvarTabaco9.DefaultSetting = @"((0))";
				colvarTabaco9.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTabaco9);
				
				TableSchema.TableColumn colvarSumatoria = new TableSchema.TableColumn(schema);
				colvarSumatoria.ColumnName = "sumatoria";
				colvarSumatoria.DataType = DbType.Int32;
				colvarSumatoria.MaxLength = 0;
				colvarSumatoria.AutoIncrement = false;
				colvarSumatoria.IsNullable = false;
				colvarSumatoria.IsPrimaryKey = false;
				colvarSumatoria.IsForeignKey = false;
				colvarSumatoria.IsReadOnly = false;
				
						colvarSumatoria.DefaultSetting = @"((0))";
				colvarSumatoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSumatoria);
				
				TableSchema.TableColumn colvarPoseeFirma = new TableSchema.TableColumn(schema);
				colvarPoseeFirma.ColumnName = "poseeFirma";
				colvarPoseeFirma.DataType = DbType.Boolean;
				colvarPoseeFirma.MaxLength = 0;
				colvarPoseeFirma.AutoIncrement = false;
				colvarPoseeFirma.IsNullable = false;
				colvarPoseeFirma.IsPrimaryKey = false;
				colvarPoseeFirma.IsForeignKey = false;
				colvarPoseeFirma.IsReadOnly = false;
				
						colvarPoseeFirma.DefaultSetting = @"((1))";
				colvarPoseeFirma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPoseeFirma);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.Int32;
				colvarCreatedBy.MaxLength = 0;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = true;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"((0))";
				
					colvarCreatedBy.ForeignKeyTableName = "Sys_Usuario";
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
				colvarModifiedBy.DataType = DbType.Int32;
				colvarModifiedBy.MaxLength = 0;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = true;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"((0))";
				
					colvarModifiedBy.ForeignKeyTableName = "Sys_Usuario";
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
				
				TableSchema.TableColumn colvarCentros = new TableSchema.TableColumn(schema);
				colvarCentros.ColumnName = "centros";
				colvarCentros.DataType = DbType.AnsiString;
				colvarCentros.MaxLength = 50;
				colvarCentros.AutoIncrement = false;
				colvarCentros.IsNullable = false;
				colvarCentros.IsPrimaryKey = false;
				colvarCentros.IsForeignKey = false;
				colvarCentros.IsReadOnly = false;
				
						colvarCentros.DefaultSetting = @"('')";
				colvarCentros.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCentros);
				
				TableSchema.TableColumn colvarVacunasCompletas = new TableSchema.TableColumn(schema);
				colvarVacunasCompletas.ColumnName = "vacunasCompletas";
				colvarVacunasCompletas.DataType = DbType.Int32;
				colvarVacunasCompletas.MaxLength = 0;
				colvarVacunasCompletas.AutoIncrement = false;
				colvarVacunasCompletas.IsNullable = false;
				colvarVacunasCompletas.IsPrimaryKey = false;
				colvarVacunasCompletas.IsForeignKey = false;
				colvarVacunasCompletas.IsReadOnly = false;
				
						colvarVacunasCompletas.DefaultSetting = @"((0))";
				colvarVacunasCompletas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacunasCompletas);
				
				TableSchema.TableColumn colvarPap = new TableSchema.TableColumn(schema);
				colvarPap.ColumnName = "pap";
				colvarPap.DataType = DbType.Int32;
				colvarPap.MaxLength = 0;
				colvarPap.AutoIncrement = false;
				colvarPap.IsNullable = false;
				colvarPap.IsPrimaryKey = false;
				colvarPap.IsForeignKey = false;
				colvarPap.IsReadOnly = false;
				
						colvarPap.DefaultSetting = @"((0))";
				colvarPap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPap);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = true;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				
						colvarIdProfesional.DefaultSetting = @"((0))";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_Formulario",schema);
			}
		}
		#endregion
		
		#region Props
		  
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
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int IdObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("NumeroFormulario")]
		[Bindable(true)]
		public int NumeroFormulario 
		{
			get { return GetColumnValue<int>(Columns.NumeroFormulario); }
			set { SetColumnValue(Columns.NumeroFormulario, value); }
		}
		  
		[XmlAttribute("FechaEmpadronamiento")]
		[Bindable(true)]
		public DateTime FechaEmpadronamiento 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaEmpadronamiento); }
			set { SetColumnValue(Columns.FechaEmpadronamiento, value); }
		}
		  
		[XmlAttribute("IdAgente")]
		[Bindable(true)]
		public int? IdAgente 
		{
			get { return GetColumnValue<int?>(Columns.IdAgente); }
			set { SetColumnValue(Columns.IdAgente, value); }
		}
		  
		[XmlAttribute("IdMunicipio")]
		[Bindable(true)]
		public int IdMunicipio 
		{
			get { return GetColumnValue<int>(Columns.IdMunicipio); }
			set { SetColumnValue(Columns.IdMunicipio, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public int Sexo 
		{
			get { return GetColumnValue<int>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("Hta2")]
		[Bindable(true)]
		public int Hta2 
		{
			get { return GetColumnValue<int>(Columns.Hta2); }
			set { SetColumnValue(Columns.Hta2, value); }
		}
		  
		[XmlAttribute("Hta3")]
		[Bindable(true)]
		public int Hta3 
		{
			get { return GetColumnValue<int>(Columns.Hta3); }
			set { SetColumnValue(Columns.Hta3, value); }
		}
		  
		[XmlAttribute("Colesterol4")]
		[Bindable(true)]
		public int Colesterol4 
		{
			get { return GetColumnValue<int>(Columns.Colesterol4); }
			set { SetColumnValue(Columns.Colesterol4, value); }
		}
		  
		[XmlAttribute("Colesterol5")]
		[Bindable(true)]
		public int Colesterol5 
		{
			get { return GetColumnValue<int>(Columns.Colesterol5); }
			set { SetColumnValue(Columns.Colesterol5, value); }
		}
		  
		[XmlAttribute("Dtm26")]
		[Bindable(true)]
		public int Dtm26 
		{
			get { return GetColumnValue<int>(Columns.Dtm26); }
			set { SetColumnValue(Columns.Dtm26, value); }
		}
		  
		[XmlAttribute("Dtm27")]
		[Bindable(true)]
		public int Dtm27 
		{
			get { return GetColumnValue<int>(Columns.Dtm27); }
			set { SetColumnValue(Columns.Dtm27, value); }
		}
		  
		[XmlAttribute("Ecv8")]
		[Bindable(true)]
		public int Ecv8 
		{
			get { return GetColumnValue<int>(Columns.Ecv8); }
			set { SetColumnValue(Columns.Ecv8, value); }
		}
		  
		[XmlAttribute("Tabaco9")]
		[Bindable(true)]
		public int Tabaco9 
		{
			get { return GetColumnValue<int>(Columns.Tabaco9); }
			set { SetColumnValue(Columns.Tabaco9, value); }
		}
		  
		[XmlAttribute("Sumatoria")]
		[Bindable(true)]
		public int Sumatoria 
		{
			get { return GetColumnValue<int>(Columns.Sumatoria); }
			set { SetColumnValue(Columns.Sumatoria, value); }
		}
		  
		[XmlAttribute("PoseeFirma")]
		[Bindable(true)]
		public bool PoseeFirma 
		{
			get { return GetColumnValue<bool>(Columns.PoseeFirma); }
			set { SetColumnValue(Columns.PoseeFirma, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public int CreatedBy 
		{
			get { return GetColumnValue<int>(Columns.CreatedBy); }
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
		public int ModifiedBy 
		{
			get { return GetColumnValue<int>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		  
		[XmlAttribute("Centros")]
		[Bindable(true)]
		public string Centros 
		{
			get { return GetColumnValue<string>(Columns.Centros); }
			set { SetColumnValue(Columns.Centros, value); }
		}
		  
		[XmlAttribute("VacunasCompletas")]
		[Bindable(true)]
		public int VacunasCompletas 
		{
			get { return GetColumnValue<int>(Columns.VacunasCompletas); }
			set { SetColumnValue(Columns.VacunasCompletas, value); }
		}
		  
		[XmlAttribute("Pap")]
		[Bindable(true)]
		public int Pap 
		{
			get { return GetColumnValue<int>(Columns.Pap); }
			set { SetColumnValue(Columns.Pap, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int? IdProfesional 
		{
			get { return GetColumnValue<int?>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysRelFormularioCoberturaCollection colSysRelFormularioCoberturaRecords;
		public DalSic.SysRelFormularioCoberturaCollection SysRelFormularioCoberturaRecords
		{
			get
			{
				if(colSysRelFormularioCoberturaRecords == null)
				{
					colSysRelFormularioCoberturaRecords = new DalSic.SysRelFormularioCoberturaCollection().Where(SysRelFormularioCobertura.Columns.IdFormulario, IdFormulario).Load();
					colSysRelFormularioCoberturaRecords.ListChanged += new ListChangedEventHandler(colSysRelFormularioCoberturaRecords_ListChanged);
				}
				return colSysRelFormularioCoberturaRecords;			
			}
			set 
			{ 
					colSysRelFormularioCoberturaRecords = value; 
					colSysRelFormularioCoberturaRecords.ListChanged += new ListChangedEventHandler(colSysRelFormularioCoberturaRecords_ListChanged);
			}
		}
		
		void colSysRelFormularioCoberturaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelFormularioCoberturaRecords[e.NewIndex].IdFormulario = IdFormulario;
		    }
		}
				
		private DalSic.RemClasificacionCollection colRemClasificacionRecords;
		public DalSic.RemClasificacionCollection RemClasificacionRecords
		{
			get
			{
				if(colRemClasificacionRecords == null)
				{
					colRemClasificacionRecords = new DalSic.RemClasificacionCollection().Where(RemClasificacion.Columns.IdFormulario, IdFormulario).Load();
					colRemClasificacionRecords.ListChanged += new ListChangedEventHandler(colRemClasificacionRecords_ListChanged);
				}
				return colRemClasificacionRecords;			
			}
			set 
			{ 
					colRemClasificacionRecords = value; 
					colRemClasificacionRecords.ListChanged += new ListChangedEventHandler(colRemClasificacionRecords_ListChanged);
			}
		}
		
		void colRemClasificacionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemClasificacionRecords[e.NewIndex].IdFormulario = IdFormulario;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysMunicipio ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysMunicipio SysMunicipio
		{
			get { return DalSic.SysMunicipio.FetchByID(this.IdMunicipio); }
			set { SetColumnValue("idMunicipio", value.IdMunicipio); }
		}
		
		
		/// <summary>
		/// Returns a SysObraSocial ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysObraSocial SysObraSocial
		{
			get { return DalSic.SysObraSocial.FetchByID(this.IdObraSocial); }
			set { SetColumnValue("idObraSocial", value.IdObraSocial); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysUsuario ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysUsuario SysUsuario
		{
			get { return DalSic.SysUsuario.FetchByID(this.ModifiedBy); }
			set { SetColumnValue("ModifiedBy", value.IdUsuario); }
		}
		
		
		/// <summary>
		/// Returns a SysUsuario ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.SysUsuario SysUsuarioToCreatedBy
		{
			get { return DalSic.SysUsuario.FetchByID(this.CreatedBy); }
			set { SetColumnValue("CreatedBy", value.IdUsuario); }
		}
		
		
		/// <summary>
		/// Returns a RemAgente ActiveRecord object related to this RemFormulario
		/// 
		/// </summary>
		public DalSic.RemAgente RemAgente
		{
			get { return DalSic.RemAgente.FetchByID(this.IdAgente); }
			set { SetColumnValue("idAgente", value.IdAgente); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,int varIdObraSocial,int varNumeroFormulario,DateTime varFechaEmpadronamiento,int? varIdAgente,int varIdMunicipio,int varSexo,int varEdad,int varHta2,int varHta3,int varColesterol4,int varColesterol5,int varDtm26,int varDtm27,int varEcv8,int varTabaco9,int varSumatoria,bool varPoseeFirma,int varCreatedBy,DateTime varCreatedOn,int varModifiedBy,DateTime varModifiedOn,string varCentros,int varVacunasCompletas,int varPap,int? varIdProfesional)
		{
			RemFormulario item = new RemFormulario();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdObraSocial = varIdObraSocial;
			
			item.NumeroFormulario = varNumeroFormulario;
			
			item.FechaEmpadronamiento = varFechaEmpadronamiento;
			
			item.IdAgente = varIdAgente;
			
			item.IdMunicipio = varIdMunicipio;
			
			item.Sexo = varSexo;
			
			item.Edad = varEdad;
			
			item.Hta2 = varHta2;
			
			item.Hta3 = varHta3;
			
			item.Colesterol4 = varColesterol4;
			
			item.Colesterol5 = varColesterol5;
			
			item.Dtm26 = varDtm26;
			
			item.Dtm27 = varDtm27;
			
			item.Ecv8 = varEcv8;
			
			item.Tabaco9 = varTabaco9;
			
			item.Sumatoria = varSumatoria;
			
			item.PoseeFirma = varPoseeFirma;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Centros = varCentros;
			
			item.VacunasCompletas = varVacunasCompletas;
			
			item.Pap = varPap;
			
			item.IdProfesional = varIdProfesional;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdFormulario,int varIdEfector,int varIdPaciente,int varIdObraSocial,int varNumeroFormulario,DateTime varFechaEmpadronamiento,int? varIdAgente,int varIdMunicipio,int varSexo,int varEdad,int varHta2,int varHta3,int varColesterol4,int varColesterol5,int varDtm26,int varDtm27,int varEcv8,int varTabaco9,int varSumatoria,bool varPoseeFirma,int varCreatedBy,DateTime varCreatedOn,int varModifiedBy,DateTime varModifiedOn,string varCentros,int varVacunasCompletas,int varPap,int? varIdProfesional)
		{
			RemFormulario item = new RemFormulario();
			
				item.IdFormulario = varIdFormulario;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdObraSocial = varIdObraSocial;
			
				item.NumeroFormulario = varNumeroFormulario;
			
				item.FechaEmpadronamiento = varFechaEmpadronamiento;
			
				item.IdAgente = varIdAgente;
			
				item.IdMunicipio = varIdMunicipio;
			
				item.Sexo = varSexo;
			
				item.Edad = varEdad;
			
				item.Hta2 = varHta2;
			
				item.Hta3 = varHta3;
			
				item.Colesterol4 = varColesterol4;
			
				item.Colesterol5 = varColesterol5;
			
				item.Dtm26 = varDtm26;
			
				item.Dtm27 = varDtm27;
			
				item.Ecv8 = varEcv8;
			
				item.Tabaco9 = varTabaco9;
			
				item.Sumatoria = varSumatoria;
			
				item.PoseeFirma = varPoseeFirma;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Centros = varCentros;
			
				item.VacunasCompletas = varVacunasCompletas;
			
				item.Pap = varPap;
			
				item.IdProfesional = varIdProfesional;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdFormularioColumn
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
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroFormularioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEmpadronamientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgenteColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMunicipioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn Hta2Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn Hta3Column
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn Colesterol4Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn Colesterol5Column
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn Dtm26Column
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn Dtm27Column
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn Ecv8Column
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn Tabaco9Column
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn SumatoriaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn PoseeFirmaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn CentrosColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn VacunasCompletasColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn PapColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdFormulario = @"idFormulario";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdObraSocial = @"idObraSocial";
			 public static string NumeroFormulario = @"numeroFormulario";
			 public static string FechaEmpadronamiento = @"fechaEmpadronamiento";
			 public static string IdAgente = @"idAgente";
			 public static string IdMunicipio = @"idMunicipio";
			 public static string Sexo = @"sexo";
			 public static string Edad = @"edad";
			 public static string Hta2 = @"hta2";
			 public static string Hta3 = @"hta3";
			 public static string Colesterol4 = @"colesterol4";
			 public static string Colesterol5 = @"colesterol5";
			 public static string Dtm26 = @"dtm26";
			 public static string Dtm27 = @"dtm27";
			 public static string Ecv8 = @"ecv8";
			 public static string Tabaco9 = @"tabaco9";
			 public static string Sumatoria = @"sumatoria";
			 public static string PoseeFirma = @"poseeFirma";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string Centros = @"centros";
			 public static string VacunasCompletas = @"vacunasCompletas";
			 public static string Pap = @"pap";
			 public static string IdProfesional = @"idProfesional";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysRelFormularioCoberturaRecords != null)
                {
                    foreach (DalSic.SysRelFormularioCobertura item in colSysRelFormularioCoberturaRecords)
                    {
                        if (item.IdFormulario != IdFormulario)
                        {
                            item.IdFormulario = IdFormulario;
                        }
                    }
               }
		
                if (colRemClasificacionRecords != null)
                {
                    foreach (DalSic.RemClasificacion item in colRemClasificacionRecords)
                    {
                        if (item.IdFormulario != IdFormulario)
                        {
                            item.IdFormulario = IdFormulario;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysRelFormularioCoberturaRecords != null)
                {
                    colSysRelFormularioCoberturaRecords.SaveAll();
               }
		
                if (colRemClasificacionRecords != null)
                {
                    colRemClasificacionRecords.SaveAll();
               }
		}
        #endregion
	}
}
