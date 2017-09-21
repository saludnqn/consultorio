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
	/// Strongly-typed collection for the MamAnatomiaPatologica class.
	/// </summary>
    [Serializable]
	public partial class MamAnatomiaPatologicaCollection : ActiveList<MamAnatomiaPatologica, MamAnatomiaPatologicaCollection>
	{	   
		public MamAnatomiaPatologicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamAnatomiaPatologicaCollection</returns>
		public MamAnatomiaPatologicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamAnatomiaPatologica o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_AnatomiaPatologica table.
	/// </summary>
	[Serializable]
	public partial class MamAnatomiaPatologica : ActiveRecord<MamAnatomiaPatologica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamAnatomiaPatologica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamAnatomiaPatologica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamAnatomiaPatologica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamAnatomiaPatologica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_AnatomiaPatologica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAnatomiaPatologica = new TableSchema.TableColumn(schema);
				colvarIdAnatomiaPatologica.ColumnName = "idAnatomiaPatologica";
				colvarIdAnatomiaPatologica.DataType = DbType.Int32;
				colvarIdAnatomiaPatologica.MaxLength = 0;
				colvarIdAnatomiaPatologica.AutoIncrement = true;
				colvarIdAnatomiaPatologica.IsNullable = false;
				colvarIdAnatomiaPatologica.IsPrimaryKey = true;
				colvarIdAnatomiaPatologica.IsForeignKey = false;
				colvarIdAnatomiaPatologica.IsReadOnly = false;
				colvarIdAnatomiaPatologica.DefaultSetting = @"";
				colvarIdAnatomiaPatologica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAnatomiaPatologica);
				
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
				
				TableSchema.TableColumn colvarGanglioAxilar = new TableSchema.TableColumn(schema);
				colvarGanglioAxilar.ColumnName = "ganglioAxilar";
				colvarGanglioAxilar.DataType = DbType.Int32;
				colvarGanglioAxilar.MaxLength = 0;
				colvarGanglioAxilar.AutoIncrement = false;
				colvarGanglioAxilar.IsNullable = false;
				colvarGanglioAxilar.IsPrimaryKey = false;
				colvarGanglioAxilar.IsForeignKey = false;
				colvarGanglioAxilar.IsReadOnly = false;
				colvarGanglioAxilar.DefaultSetting = @"";
				colvarGanglioAxilar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGanglioAxilar);
				
				TableSchema.TableColumn colvarNoduloMama = new TableSchema.TableColumn(schema);
				colvarNoduloMama.ColumnName = "noduloMama";
				colvarNoduloMama.DataType = DbType.Int32;
				colvarNoduloMama.MaxLength = 0;
				colvarNoduloMama.AutoIncrement = false;
				colvarNoduloMama.IsNullable = false;
				colvarNoduloMama.IsPrimaryKey = false;
				colvarNoduloMama.IsForeignKey = false;
				colvarNoduloMama.IsReadOnly = false;
				
						colvarNoduloMama.DefaultSetting = @"('')";
				colvarNoduloMama.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNoduloMama);
				
				TableSchema.TableColumn colvarMicrocalcificaciones = new TableSchema.TableColumn(schema);
				colvarMicrocalcificaciones.ColumnName = "microcalcificaciones";
				colvarMicrocalcificaciones.DataType = DbType.Int32;
				colvarMicrocalcificaciones.MaxLength = 0;
				colvarMicrocalcificaciones.AutoIncrement = false;
				colvarMicrocalcificaciones.IsNullable = false;
				colvarMicrocalcificaciones.IsPrimaryKey = false;
				colvarMicrocalcificaciones.IsForeignKey = false;
				colvarMicrocalcificaciones.IsReadOnly = false;
				
						colvarMicrocalcificaciones.DefaultSetting = @"((0))";
				colvarMicrocalcificaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMicrocalcificaciones);
				
				TableSchema.TableColumn colvarPiel = new TableSchema.TableColumn(schema);
				colvarPiel.ColumnName = "piel";
				colvarPiel.DataType = DbType.Int32;
				colvarPiel.MaxLength = 0;
				colvarPiel.AutoIncrement = false;
				colvarPiel.IsNullable = false;
				colvarPiel.IsPrimaryKey = false;
				colvarPiel.IsForeignKey = false;
				colvarPiel.IsReadOnly = false;
				
						colvarPiel.DefaultSetting = @"((0))";
				colvarPiel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPiel);
				
				TableSchema.TableColumn colvarDerrame = new TableSchema.TableColumn(schema);
				colvarDerrame.ColumnName = "derrame";
				colvarDerrame.DataType = DbType.Int32;
				colvarDerrame.MaxLength = 0;
				colvarDerrame.AutoIncrement = false;
				colvarDerrame.IsNullable = false;
				colvarDerrame.IsPrimaryKey = false;
				colvarDerrame.IsForeignKey = false;
				colvarDerrame.IsReadOnly = false;
				
						colvarDerrame.DefaultSetting = @"((0))";
				colvarDerrame.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDerrame);
				
				TableSchema.TableColumn colvarFechaTomaMuestra = new TableSchema.TableColumn(schema);
				colvarFechaTomaMuestra.ColumnName = "fechaTomaMuestra";
				colvarFechaTomaMuestra.DataType = DbType.DateTime;
				colvarFechaTomaMuestra.MaxLength = 0;
				colvarFechaTomaMuestra.AutoIncrement = false;
				colvarFechaTomaMuestra.IsNullable = false;
				colvarFechaTomaMuestra.IsPrimaryKey = false;
				colvarFechaTomaMuestra.IsForeignKey = false;
				colvarFechaTomaMuestra.IsReadOnly = false;
				
						colvarFechaTomaMuestra.DefaultSetting = @"((0))";
				colvarFechaTomaMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTomaMuestra);
				
				TableSchema.TableColumn colvarFechaRecepcionMuestra = new TableSchema.TableColumn(schema);
				colvarFechaRecepcionMuestra.ColumnName = "fechaRecepcionMuestra";
				colvarFechaRecepcionMuestra.DataType = DbType.DateTime;
				colvarFechaRecepcionMuestra.MaxLength = 0;
				colvarFechaRecepcionMuestra.AutoIncrement = false;
				colvarFechaRecepcionMuestra.IsNullable = false;
				colvarFechaRecepcionMuestra.IsPrimaryKey = false;
				colvarFechaRecepcionMuestra.IsForeignKey = false;
				colvarFechaRecepcionMuestra.IsReadOnly = false;
				colvarFechaRecepcionMuestra.DefaultSetting = @"";
				colvarFechaRecepcionMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecepcionMuestra);
				
				TableSchema.TableColumn colvarFechaInformeMuestra = new TableSchema.TableColumn(schema);
				colvarFechaInformeMuestra.ColumnName = "fechaInformeMuestra";
				colvarFechaInformeMuestra.DataType = DbType.DateTime;
				colvarFechaInformeMuestra.MaxLength = 0;
				colvarFechaInformeMuestra.AutoIncrement = false;
				colvarFechaInformeMuestra.IsNullable = false;
				colvarFechaInformeMuestra.IsPrimaryKey = false;
				colvarFechaInformeMuestra.IsForeignKey = false;
				colvarFechaInformeMuestra.IsReadOnly = false;
				colvarFechaInformeMuestra.DefaultSetting = @"";
				colvarFechaInformeMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInformeMuestra);
				
				TableSchema.TableColumn colvarNumeroIngreso = new TableSchema.TableColumn(schema);
				colvarNumeroIngreso.ColumnName = "numeroIngreso";
				colvarNumeroIngreso.DataType = DbType.AnsiString;
				colvarNumeroIngreso.MaxLength = 20;
				colvarNumeroIngreso.AutoIncrement = false;
				colvarNumeroIngreso.IsNullable = false;
				colvarNumeroIngreso.IsPrimaryKey = false;
				colvarNumeroIngreso.IsForeignKey = false;
				colvarNumeroIngreso.IsReadOnly = false;
				
						colvarNumeroIngreso.DefaultSetting = @"('')";
				colvarNumeroIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroIngreso);
				
				TableSchema.TableColumn colvarIdResponsableMuestra = new TableSchema.TableColumn(schema);
				colvarIdResponsableMuestra.ColumnName = "idResponsableMuestra";
				colvarIdResponsableMuestra.DataType = DbType.Int32;
				colvarIdResponsableMuestra.MaxLength = 0;
				colvarIdResponsableMuestra.AutoIncrement = false;
				colvarIdResponsableMuestra.IsNullable = false;
				colvarIdResponsableMuestra.IsPrimaryKey = false;
				colvarIdResponsableMuestra.IsForeignKey = true;
				colvarIdResponsableMuestra.IsReadOnly = false;
				
						colvarIdResponsableMuestra.DefaultSetting = @"((0))";
				
					colvarIdResponsableMuestra.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdResponsableMuestra);
				
				TableSchema.TableColumn colvarIdCentroSaludMuestra = new TableSchema.TableColumn(schema);
				colvarIdCentroSaludMuestra.ColumnName = "idCentroSaludMuestra";
				colvarIdCentroSaludMuestra.DataType = DbType.Int32;
				colvarIdCentroSaludMuestra.MaxLength = 0;
				colvarIdCentroSaludMuestra.AutoIncrement = false;
				colvarIdCentroSaludMuestra.IsNullable = false;
				colvarIdCentroSaludMuestra.IsPrimaryKey = false;
				colvarIdCentroSaludMuestra.IsForeignKey = true;
				colvarIdCentroSaludMuestra.IsReadOnly = false;
				
						colvarIdCentroSaludMuestra.DefaultSetting = @"((0))";
				
					colvarIdCentroSaludMuestra.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdCentroSaludMuestra);
				
				TableSchema.TableColumn colvarIdDiagnosticoCitologico = new TableSchema.TableColumn(schema);
				colvarIdDiagnosticoCitologico.ColumnName = "idDiagnosticoCitologico";
				colvarIdDiagnosticoCitologico.DataType = DbType.Int32;
				colvarIdDiagnosticoCitologico.MaxLength = 0;
				colvarIdDiagnosticoCitologico.AutoIncrement = false;
				colvarIdDiagnosticoCitologico.IsNullable = false;
				colvarIdDiagnosticoCitologico.IsPrimaryKey = false;
				colvarIdDiagnosticoCitologico.IsForeignKey = true;
				colvarIdDiagnosticoCitologico.IsReadOnly = false;
				
						colvarIdDiagnosticoCitologico.DefaultSetting = @"((0))";
				
					colvarIdDiagnosticoCitologico.ForeignKeyTableName = "MAM_DiagnosticoCitologico";
				schema.Columns.Add(colvarIdDiagnosticoCitologico);
				
				TableSchema.TableColumn colvarIdDiagnosticoHistologico = new TableSchema.TableColumn(schema);
				colvarIdDiagnosticoHistologico.ColumnName = "idDiagnosticoHistologico";
				colvarIdDiagnosticoHistologico.DataType = DbType.Int32;
				colvarIdDiagnosticoHistologico.MaxLength = 0;
				colvarIdDiagnosticoHistologico.AutoIncrement = false;
				colvarIdDiagnosticoHistologico.IsNullable = false;
				colvarIdDiagnosticoHistologico.IsPrimaryKey = false;
				colvarIdDiagnosticoHistologico.IsForeignKey = true;
				colvarIdDiagnosticoHistologico.IsReadOnly = false;
				
						colvarIdDiagnosticoHistologico.DefaultSetting = @"((0))";
				
					colvarIdDiagnosticoHistologico.ForeignKeyTableName = "MAM_DiagnoticoHistologico";
				schema.Columns.Add(colvarIdDiagnosticoHistologico);
				
				TableSchema.TableColumn colvarFechaInforme = new TableSchema.TableColumn(schema);
				colvarFechaInforme.ColumnName = "fechaInforme";
				colvarFechaInforme.DataType = DbType.DateTime;
				colvarFechaInforme.MaxLength = 0;
				colvarFechaInforme.AutoIncrement = false;
				colvarFechaInforme.IsNullable = false;
				colvarFechaInforme.IsPrimaryKey = false;
				colvarFechaInforme.IsForeignKey = false;
				colvarFechaInforme.IsReadOnly = false;
				
						colvarFechaInforme.DefaultSetting = @"('')";
				colvarFechaInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInforme);
				
				TableSchema.TableColumn colvarIdResponsableInforme = new TableSchema.TableColumn(schema);
				colvarIdResponsableInforme.ColumnName = "idResponsableInforme";
				colvarIdResponsableInforme.DataType = DbType.Int32;
				colvarIdResponsableInforme.MaxLength = 0;
				colvarIdResponsableInforme.AutoIncrement = false;
				colvarIdResponsableInforme.IsNullable = false;
				colvarIdResponsableInforme.IsPrimaryKey = false;
				colvarIdResponsableInforme.IsForeignKey = true;
				colvarIdResponsableInforme.IsReadOnly = false;
				
						colvarIdResponsableInforme.DefaultSetting = @"((0))";
				
					colvarIdResponsableInforme.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdResponsableInforme);
				
				TableSchema.TableColumn colvarIdCentroSaludInforme = new TableSchema.TableColumn(schema);
				colvarIdCentroSaludInforme.ColumnName = "idCentroSaludInforme";
				colvarIdCentroSaludInforme.DataType = DbType.Int32;
				colvarIdCentroSaludInforme.MaxLength = 0;
				colvarIdCentroSaludInforme.AutoIncrement = false;
				colvarIdCentroSaludInforme.IsNullable = false;
				colvarIdCentroSaludInforme.IsPrimaryKey = false;
				colvarIdCentroSaludInforme.IsForeignKey = true;
				colvarIdCentroSaludInforme.IsReadOnly = false;
				
						colvarIdCentroSaludInforme.DefaultSetting = @"((0))";
				
					colvarIdCentroSaludInforme.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdCentroSaludInforme);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 1000;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = false;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				
						colvarObservaciones.DefaultSetting = @"('')";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
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
				
				TableSchema.TableColumn colvarGuia = new TableSchema.TableColumn(schema);
				colvarGuia.ColumnName = "guia";
				colvarGuia.DataType = DbType.AnsiString;
				colvarGuia.MaxLength = 20;
				colvarGuia.AutoIncrement = false;
				colvarGuia.IsNullable = false;
				colvarGuia.IsPrimaryKey = false;
				colvarGuia.IsForeignKey = false;
				colvarGuia.IsReadOnly = false;
				
						colvarGuia.DefaultSetting = @"('')";
				colvarGuia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGuia);
				
				TableSchema.TableColumn colvarMetodo = new TableSchema.TableColumn(schema);
				colvarMetodo.ColumnName = "metodo";
				colvarMetodo.DataType = DbType.AnsiString;
				colvarMetodo.MaxLength = 20;
				colvarMetodo.AutoIncrement = false;
				colvarMetodo.IsNullable = false;
				colvarMetodo.IsPrimaryKey = false;
				colvarMetodo.IsForeignKey = false;
				colvarMetodo.IsReadOnly = false;
				
						colvarMetodo.DefaultSetting = @"('')";
				colvarMetodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMetodo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_AnatomiaPatologica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAnatomiaPatologica")]
		[Bindable(true)]
		public int IdAnatomiaPatologica 
		{
			get { return GetColumnValue<int>(Columns.IdAnatomiaPatologica); }
			set { SetColumnValue(Columns.IdAnatomiaPatologica, value); }
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
		  
		[XmlAttribute("GanglioAxilar")]
		[Bindable(true)]
		public int GanglioAxilar 
		{
			get { return GetColumnValue<int>(Columns.GanglioAxilar); }
			set { SetColumnValue(Columns.GanglioAxilar, value); }
		}
		  
		[XmlAttribute("NoduloMama")]
		[Bindable(true)]
		public int NoduloMama 
		{
			get { return GetColumnValue<int>(Columns.NoduloMama); }
			set { SetColumnValue(Columns.NoduloMama, value); }
		}
		  
		[XmlAttribute("Microcalcificaciones")]
		[Bindable(true)]
		public int Microcalcificaciones 
		{
			get { return GetColumnValue<int>(Columns.Microcalcificaciones); }
			set { SetColumnValue(Columns.Microcalcificaciones, value); }
		}
		  
		[XmlAttribute("Piel")]
		[Bindable(true)]
		public int Piel 
		{
			get { return GetColumnValue<int>(Columns.Piel); }
			set { SetColumnValue(Columns.Piel, value); }
		}
		  
		[XmlAttribute("Derrame")]
		[Bindable(true)]
		public int Derrame 
		{
			get { return GetColumnValue<int>(Columns.Derrame); }
			set { SetColumnValue(Columns.Derrame, value); }
		}
		  
		[XmlAttribute("FechaTomaMuestra")]
		[Bindable(true)]
		public DateTime FechaTomaMuestra 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaTomaMuestra); }
			set { SetColumnValue(Columns.FechaTomaMuestra, value); }
		}
		  
		[XmlAttribute("FechaRecepcionMuestra")]
		[Bindable(true)]
		public DateTime FechaRecepcionMuestra 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRecepcionMuestra); }
			set { SetColumnValue(Columns.FechaRecepcionMuestra, value); }
		}
		  
		[XmlAttribute("FechaInformeMuestra")]
		[Bindable(true)]
		public DateTime FechaInformeMuestra 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInformeMuestra); }
			set { SetColumnValue(Columns.FechaInformeMuestra, value); }
		}
		  
		[XmlAttribute("NumeroIngreso")]
		[Bindable(true)]
		public string NumeroIngreso 
		{
			get { return GetColumnValue<string>(Columns.NumeroIngreso); }
			set { SetColumnValue(Columns.NumeroIngreso, value); }
		}
		  
		[XmlAttribute("IdResponsableMuestra")]
		[Bindable(true)]
		public int IdResponsableMuestra 
		{
			get { return GetColumnValue<int>(Columns.IdResponsableMuestra); }
			set { SetColumnValue(Columns.IdResponsableMuestra, value); }
		}
		  
		[XmlAttribute("IdCentroSaludMuestra")]
		[Bindable(true)]
		public int IdCentroSaludMuestra 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSaludMuestra); }
			set { SetColumnValue(Columns.IdCentroSaludMuestra, value); }
		}
		  
		[XmlAttribute("IdDiagnosticoCitologico")]
		[Bindable(true)]
		public int IdDiagnosticoCitologico 
		{
			get { return GetColumnValue<int>(Columns.IdDiagnosticoCitologico); }
			set { SetColumnValue(Columns.IdDiagnosticoCitologico, value); }
		}
		  
		[XmlAttribute("IdDiagnosticoHistologico")]
		[Bindable(true)]
		public int IdDiagnosticoHistologico 
		{
			get { return GetColumnValue<int>(Columns.IdDiagnosticoHistologico); }
			set { SetColumnValue(Columns.IdDiagnosticoHistologico, value); }
		}
		  
		[XmlAttribute("FechaInforme")]
		[Bindable(true)]
		public DateTime FechaInforme 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInforme); }
			set { SetColumnValue(Columns.FechaInforme, value); }
		}
		  
		[XmlAttribute("IdResponsableInforme")]
		[Bindable(true)]
		public int IdResponsableInforme 
		{
			get { return GetColumnValue<int>(Columns.IdResponsableInforme); }
			set { SetColumnValue(Columns.IdResponsableInforme, value); }
		}
		  
		[XmlAttribute("IdCentroSaludInforme")]
		[Bindable(true)]
		public int IdCentroSaludInforme 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSaludInforme); }
			set { SetColumnValue(Columns.IdCentroSaludInforme, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
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
		  
		[XmlAttribute("Guia")]
		[Bindable(true)]
		public string Guia 
		{
			get { return GetColumnValue<string>(Columns.Guia); }
			set { SetColumnValue(Columns.Guia, value); }
		}
		  
		[XmlAttribute("Metodo")]
		[Bindable(true)]
		public string Metodo 
		{
			get { return GetColumnValue<string>(Columns.Metodo); }
			set { SetColumnValue(Columns.Metodo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamAnatomiaPatologica
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSaludInforme); }
			set { SetColumnValue("idCentroSaludInforme", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamAnatomiaPatologica
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdCentroSaludMuestra
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSaludMuestra); }
			set { SetColumnValue("idCentroSaludMuestra", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamAnatomiaPatologica
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdResponsableMuestra); }
			set { SetColumnValue("idResponsableMuestra", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamAnatomiaPatologica
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesionalToIdResponsableInforme
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdResponsableInforme); }
			set { SetColumnValue("idResponsableInforme", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a MamDiagnoticoHistologico ActiveRecord object related to this MamAnatomiaPatologica
		/// 
		/// </summary>
		public DalSic.MamDiagnoticoHistologico MamDiagnoticoHistologico
		{
			get { return DalSic.MamDiagnoticoHistologico.FetchByID(this.IdDiagnosticoHistologico); }
			set { SetColumnValue("idDiagnosticoHistologico", value.IdDiagnosticoHistologico); }
		}
		
		
		/// <summary>
		/// Returns a MamDiagnosticoCitologico ActiveRecord object related to this MamAnatomiaPatologica
		/// 
		/// </summary>
		public DalSic.MamDiagnosticoCitologico MamDiagnosticoCitologico
		{
			get { return DalSic.MamDiagnosticoCitologico.FetchByID(this.IdDiagnosticoCitologico); }
			set { SetColumnValue("idDiagnosticoCitologico", value.IdDiagnosticoCitologico); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varEdad,int varGanglioAxilar,int varNoduloMama,int varMicrocalcificaciones,int varPiel,int varDerrame,DateTime varFechaTomaMuestra,DateTime varFechaRecepcionMuestra,DateTime varFechaInformeMuestra,string varNumeroIngreso,int varIdResponsableMuestra,int varIdCentroSaludMuestra,int varIdDiagnosticoCitologico,int varIdDiagnosticoHistologico,DateTime varFechaInforme,int varIdResponsableInforme,int varIdCentroSaludInforme,string varObservaciones,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,string varGuia,string varMetodo)
		{
			MamAnatomiaPatologica item = new MamAnatomiaPatologica();
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.GanglioAxilar = varGanglioAxilar;
			
			item.NoduloMama = varNoduloMama;
			
			item.Microcalcificaciones = varMicrocalcificaciones;
			
			item.Piel = varPiel;
			
			item.Derrame = varDerrame;
			
			item.FechaTomaMuestra = varFechaTomaMuestra;
			
			item.FechaRecepcionMuestra = varFechaRecepcionMuestra;
			
			item.FechaInformeMuestra = varFechaInformeMuestra;
			
			item.NumeroIngreso = varNumeroIngreso;
			
			item.IdResponsableMuestra = varIdResponsableMuestra;
			
			item.IdCentroSaludMuestra = varIdCentroSaludMuestra;
			
			item.IdDiagnosticoCitologico = varIdDiagnosticoCitologico;
			
			item.IdDiagnosticoHistologico = varIdDiagnosticoHistologico;
			
			item.FechaInforme = varFechaInforme;
			
			item.IdResponsableInforme = varIdResponsableInforme;
			
			item.IdCentroSaludInforme = varIdCentroSaludInforme;
			
			item.Observaciones = varObservaciones;
			
			item.Activo = varActivo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Guia = varGuia;
			
			item.Metodo = varMetodo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAnatomiaPatologica,int varIdPaciente,int varEdad,int varGanglioAxilar,int varNoduloMama,int varMicrocalcificaciones,int varPiel,int varDerrame,DateTime varFechaTomaMuestra,DateTime varFechaRecepcionMuestra,DateTime varFechaInformeMuestra,string varNumeroIngreso,int varIdResponsableMuestra,int varIdCentroSaludMuestra,int varIdDiagnosticoCitologico,int varIdDiagnosticoHistologico,DateTime varFechaInforme,int varIdResponsableInforme,int varIdCentroSaludInforme,string varObservaciones,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,string varGuia,string varMetodo)
		{
			MamAnatomiaPatologica item = new MamAnatomiaPatologica();
			
				item.IdAnatomiaPatologica = varIdAnatomiaPatologica;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.GanglioAxilar = varGanglioAxilar;
			
				item.NoduloMama = varNoduloMama;
			
				item.Microcalcificaciones = varMicrocalcificaciones;
			
				item.Piel = varPiel;
			
				item.Derrame = varDerrame;
			
				item.FechaTomaMuestra = varFechaTomaMuestra;
			
				item.FechaRecepcionMuestra = varFechaRecepcionMuestra;
			
				item.FechaInformeMuestra = varFechaInformeMuestra;
			
				item.NumeroIngreso = varNumeroIngreso;
			
				item.IdResponsableMuestra = varIdResponsableMuestra;
			
				item.IdCentroSaludMuestra = varIdCentroSaludMuestra;
			
				item.IdDiagnosticoCitologico = varIdDiagnosticoCitologico;
			
				item.IdDiagnosticoHistologico = varIdDiagnosticoHistologico;
			
				item.FechaInforme = varFechaInforme;
			
				item.IdResponsableInforme = varIdResponsableInforme;
			
				item.IdCentroSaludInforme = varIdCentroSaludInforme;
			
				item.Observaciones = varObservaciones;
			
				item.Activo = varActivo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Guia = varGuia;
			
				item.Metodo = varMetodo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAnatomiaPatologicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn GanglioAxilarColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NoduloMamaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MicrocalcificacionesColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PielColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DerrameColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTomaMuestraColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecepcionMuestraColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInformeMuestraColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroIngresoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResponsableMuestraColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludMuestraColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDiagnosticoCitologicoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDiagnosticoHistologicoColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInformeColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResponsableInformeColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludInformeColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn GuiaColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn MetodoColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAnatomiaPatologica = @"idAnatomiaPatologica";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string GanglioAxilar = @"ganglioAxilar";
			 public static string NoduloMama = @"noduloMama";
			 public static string Microcalcificaciones = @"microcalcificaciones";
			 public static string Piel = @"piel";
			 public static string Derrame = @"derrame";
			 public static string FechaTomaMuestra = @"fechaTomaMuestra";
			 public static string FechaRecepcionMuestra = @"fechaRecepcionMuestra";
			 public static string FechaInformeMuestra = @"fechaInformeMuestra";
			 public static string NumeroIngreso = @"numeroIngreso";
			 public static string IdResponsableMuestra = @"idResponsableMuestra";
			 public static string IdCentroSaludMuestra = @"idCentroSaludMuestra";
			 public static string IdDiagnosticoCitologico = @"idDiagnosticoCitologico";
			 public static string IdDiagnosticoHistologico = @"idDiagnosticoHistologico";
			 public static string FechaInforme = @"fechaInforme";
			 public static string IdResponsableInforme = @"idResponsableInforme";
			 public static string IdCentroSaludInforme = @"idCentroSaludInforme";
			 public static string Observaciones = @"observaciones";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string Guia = @"guia";
			 public static string Metodo = @"metodo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
