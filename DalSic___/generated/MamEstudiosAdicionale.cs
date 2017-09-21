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
	/// Strongly-typed collection for the MamEstudiosAdicionale class.
	/// </summary>
    [Serializable]
	public partial class MamEstudiosAdicionaleCollection : ActiveList<MamEstudiosAdicionale, MamEstudiosAdicionaleCollection>
	{	   
		public MamEstudiosAdicionaleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamEstudiosAdicionaleCollection</returns>
		public MamEstudiosAdicionaleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamEstudiosAdicionale o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_EstudiosAdicionales table.
	/// </summary>
	[Serializable]
	public partial class MamEstudiosAdicionale : ActiveRecord<MamEstudiosAdicionale>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamEstudiosAdicionale()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamEstudiosAdicionale(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamEstudiosAdicionale(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamEstudiosAdicionale(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_EstudiosAdicionales", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioAdicional = new TableSchema.TableColumn(schema);
				colvarIdEstudioAdicional.ColumnName = "idEstudioAdicional";
				colvarIdEstudioAdicional.DataType = DbType.Int32;
				colvarIdEstudioAdicional.MaxLength = 0;
				colvarIdEstudioAdicional.AutoIncrement = true;
				colvarIdEstudioAdicional.IsNullable = false;
				colvarIdEstudioAdicional.IsPrimaryKey = true;
				colvarIdEstudioAdicional.IsForeignKey = false;
				colvarIdEstudioAdicional.IsReadOnly = false;
				colvarIdEstudioAdicional.DefaultSetting = @"";
				colvarIdEstudioAdicional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioAdicional);
				
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
				
				TableSchema.TableColumn colvarIdMotivoEstudio = new TableSchema.TableColumn(schema);
				colvarIdMotivoEstudio.ColumnName = "idMotivoEstudio";
				colvarIdMotivoEstudio.DataType = DbType.Int32;
				colvarIdMotivoEstudio.MaxLength = 0;
				colvarIdMotivoEstudio.AutoIncrement = false;
				colvarIdMotivoEstudio.IsNullable = false;
				colvarIdMotivoEstudio.IsPrimaryKey = false;
				colvarIdMotivoEstudio.IsForeignKey = true;
				colvarIdMotivoEstudio.IsReadOnly = false;
				
						colvarIdMotivoEstudio.DefaultSetting = @"((0))";
				
					colvarIdMotivoEstudio.ForeignKeyTableName = "MAM_Motivo";
				schema.Columns.Add(colvarIdMotivoEstudio);
				
				TableSchema.TableColumn colvarFechaEstudio = new TableSchema.TableColumn(schema);
				colvarFechaEstudio.ColumnName = "fechaEstudio";
				colvarFechaEstudio.DataType = DbType.DateTime;
				colvarFechaEstudio.MaxLength = 0;
				colvarFechaEstudio.AutoIncrement = false;
				colvarFechaEstudio.IsNullable = false;
				colvarFechaEstudio.IsPrimaryKey = false;
				colvarFechaEstudio.IsForeignKey = false;
				colvarFechaEstudio.IsReadOnly = false;
				colvarFechaEstudio.DefaultSetting = @"";
				colvarFechaEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEstudio);
				
				TableSchema.TableColumn colvarMagnificada = new TableSchema.TableColumn(schema);
				colvarMagnificada.ColumnName = "magnificada";
				colvarMagnificada.DataType = DbType.Int32;
				colvarMagnificada.MaxLength = 0;
				colvarMagnificada.AutoIncrement = false;
				colvarMagnificada.IsNullable = false;
				colvarMagnificada.IsPrimaryKey = false;
				colvarMagnificada.IsForeignKey = false;
				colvarMagnificada.IsReadOnly = false;
				
						colvarMagnificada.DefaultSetting = @"((0))";
				colvarMagnificada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMagnificada);
				
				TableSchema.TableColumn colvarIdBiradsI = new TableSchema.TableColumn(schema);
				colvarIdBiradsI.ColumnName = "idBiradsI";
				colvarIdBiradsI.DataType = DbType.Int32;
				colvarIdBiradsI.MaxLength = 0;
				colvarIdBiradsI.AutoIncrement = false;
				colvarIdBiradsI.IsNullable = false;
				colvarIdBiradsI.IsPrimaryKey = false;
				colvarIdBiradsI.IsForeignKey = true;
				colvarIdBiradsI.IsReadOnly = false;
				
						colvarIdBiradsI.DefaultSetting = @"((0))";
				
					colvarIdBiradsI.ForeignKeyTableName = "MAM_Birads";
				schema.Columns.Add(colvarIdBiradsI);
				
				TableSchema.TableColumn colvarIdBiradsD = new TableSchema.TableColumn(schema);
				colvarIdBiradsD.ColumnName = "idBiradsD";
				colvarIdBiradsD.DataType = DbType.Int32;
				colvarIdBiradsD.MaxLength = 0;
				colvarIdBiradsD.AutoIncrement = false;
				colvarIdBiradsD.IsNullable = false;
				colvarIdBiradsD.IsPrimaryKey = false;
				colvarIdBiradsD.IsForeignKey = true;
				colvarIdBiradsD.IsReadOnly = false;
				
						colvarIdBiradsD.DefaultSetting = @"((0))";
				
					colvarIdBiradsD.ForeignKeyTableName = "MAM_Birads";
				schema.Columns.Add(colvarIdBiradsD);
				
				TableSchema.TableColumn colvarIdBiradsDef = new TableSchema.TableColumn(schema);
				colvarIdBiradsDef.ColumnName = "idBiradsDef";
				colvarIdBiradsDef.DataType = DbType.Int32;
				colvarIdBiradsDef.MaxLength = 0;
				colvarIdBiradsDef.AutoIncrement = false;
				colvarIdBiradsDef.IsNullable = false;
				colvarIdBiradsDef.IsPrimaryKey = false;
				colvarIdBiradsDef.IsForeignKey = true;
				colvarIdBiradsDef.IsReadOnly = false;
				
						colvarIdBiradsDef.DefaultSetting = @"((0))";
				
					colvarIdBiradsDef.ForeignKeyTableName = "MAM_Birads";
				schema.Columns.Add(colvarIdBiradsDef);
				
				TableSchema.TableColumn colvarInforme = new TableSchema.TableColumn(schema);
				colvarInforme.ColumnName = "informe";
				colvarInforme.DataType = DbType.AnsiString;
				colvarInforme.MaxLength = 2000;
				colvarInforme.AutoIncrement = false;
				colvarInforme.IsNullable = false;
				colvarInforme.IsPrimaryKey = false;
				colvarInforme.IsForeignKey = false;
				colvarInforme.IsReadOnly = false;
				colvarInforme.DefaultSetting = @"";
				colvarInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInforme);
				
				TableSchema.TableColumn colvarIdProfesionalResponsable = new TableSchema.TableColumn(schema);
				colvarIdProfesionalResponsable.ColumnName = "idProfesionalResponsable";
				colvarIdProfesionalResponsable.DataType = DbType.Int32;
				colvarIdProfesionalResponsable.MaxLength = 0;
				colvarIdProfesionalResponsable.AutoIncrement = false;
				colvarIdProfesionalResponsable.IsNullable = false;
				colvarIdProfesionalResponsable.IsPrimaryKey = false;
				colvarIdProfesionalResponsable.IsForeignKey = true;
				colvarIdProfesionalResponsable.IsReadOnly = false;
				
						colvarIdProfesionalResponsable.DefaultSetting = @"((0))";
				
					colvarIdProfesionalResponsable.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesionalResponsable);
				
				TableSchema.TableColumn colvarIdCentroSalud = new TableSchema.TableColumn(schema);
				colvarIdCentroSalud.ColumnName = "idCentroSalud";
				colvarIdCentroSalud.DataType = DbType.Int32;
				colvarIdCentroSalud.MaxLength = 0;
				colvarIdCentroSalud.AutoIncrement = false;
				colvarIdCentroSalud.IsNullable = false;
				colvarIdCentroSalud.IsPrimaryKey = false;
				colvarIdCentroSalud.IsForeignKey = true;
				colvarIdCentroSalud.IsReadOnly = false;
				
						colvarIdCentroSalud.DefaultSetting = @"((0))";
				
					colvarIdCentroSalud.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdCentroSalud);
				
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
				
				TableSchema.TableColumn colvarIdEfectorRealizaEstudio = new TableSchema.TableColumn(schema);
				colvarIdEfectorRealizaEstudio.ColumnName = "idEfectorRealizaEstudio";
				colvarIdEfectorRealizaEstudio.DataType = DbType.Int32;
				colvarIdEfectorRealizaEstudio.MaxLength = 0;
				colvarIdEfectorRealizaEstudio.AutoIncrement = false;
				colvarIdEfectorRealizaEstudio.IsNullable = false;
				colvarIdEfectorRealizaEstudio.IsPrimaryKey = false;
				colvarIdEfectorRealizaEstudio.IsForeignKey = true;
				colvarIdEfectorRealizaEstudio.IsReadOnly = false;
				
						colvarIdEfectorRealizaEstudio.DefaultSetting = @"((0))";
				
					colvarIdEfectorRealizaEstudio.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorRealizaEstudio);
				
				TableSchema.TableColumn colvarIdTipoEquipo = new TableSchema.TableColumn(schema);
				colvarIdTipoEquipo.ColumnName = "idTipoEquipo";
				colvarIdTipoEquipo.DataType = DbType.Int32;
				colvarIdTipoEquipo.MaxLength = 0;
				colvarIdTipoEquipo.AutoIncrement = false;
				colvarIdTipoEquipo.IsNullable = false;
				colvarIdTipoEquipo.IsPrimaryKey = false;
				colvarIdTipoEquipo.IsForeignKey = true;
				colvarIdTipoEquipo.IsReadOnly = false;
				
						colvarIdTipoEquipo.DefaultSetting = @"((0))";
				
					colvarIdTipoEquipo.ForeignKeyTableName = "MAM_TipoEquipo";
				schema.Columns.Add(colvarIdTipoEquipo);
				
				TableSchema.TableColumn colvarIdProfesionalTecnico = new TableSchema.TableColumn(schema);
				colvarIdProfesionalTecnico.ColumnName = "idProfesionalTecnico";
				colvarIdProfesionalTecnico.DataType = DbType.Int32;
				colvarIdProfesionalTecnico.MaxLength = 0;
				colvarIdProfesionalTecnico.AutoIncrement = false;
				colvarIdProfesionalTecnico.IsNullable = false;
				colvarIdProfesionalTecnico.IsPrimaryKey = false;
				colvarIdProfesionalTecnico.IsForeignKey = true;
				colvarIdProfesionalTecnico.IsReadOnly = false;
				
						colvarIdProfesionalTecnico.DefaultSetting = @"((0))";
				
					colvarIdProfesionalTecnico.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesionalTecnico);
				
				TableSchema.TableColumn colvarFechaInforme = new TableSchema.TableColumn(schema);
				colvarFechaInforme.ColumnName = "fechaInforme";
				colvarFechaInforme.DataType = DbType.DateTime;
				colvarFechaInforme.MaxLength = 0;
				colvarFechaInforme.AutoIncrement = false;
				colvarFechaInforme.IsNullable = false;
				colvarFechaInforme.IsPrimaryKey = false;
				colvarFechaInforme.IsForeignKey = false;
				colvarFechaInforme.IsReadOnly = false;
				
						colvarFechaInforme.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInforme);
				
				TableSchema.TableColumn colvarProtocolo = new TableSchema.TableColumn(schema);
				colvarProtocolo.ColumnName = "protocolo";
				colvarProtocolo.DataType = DbType.AnsiString;
				colvarProtocolo.MaxLength = 20;
				colvarProtocolo.AutoIncrement = false;
				colvarProtocolo.IsNullable = false;
				colvarProtocolo.IsPrimaryKey = false;
				colvarProtocolo.IsForeignKey = false;
				colvarProtocolo.IsReadOnly = false;
				
						colvarProtocolo.DefaultSetting = @"('')";
				colvarProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProtocolo);
				
				TableSchema.TableColumn colvarTomosintesis = new TableSchema.TableColumn(schema);
				colvarTomosintesis.ColumnName = "tomosintesis";
				colvarTomosintesis.DataType = DbType.Int32;
				colvarTomosintesis.MaxLength = 0;
				colvarTomosintesis.AutoIncrement = false;
				colvarTomosintesis.IsNullable = false;
				colvarTomosintesis.IsPrimaryKey = false;
				colvarTomosintesis.IsForeignKey = false;
				colvarTomosintesis.IsReadOnly = false;
				
						colvarTomosintesis.DefaultSetting = @"((0))";
				colvarTomosintesis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTomosintesis);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_EstudiosAdicionales",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioAdicional")]
		[Bindable(true)]
		public int IdEstudioAdicional 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioAdicional); }
			set { SetColumnValue(Columns.IdEstudioAdicional, value); }
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
		  
		[XmlAttribute("IdMotivoEstudio")]
		[Bindable(true)]
		public int IdMotivoEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoEstudio); }
			set { SetColumnValue(Columns.IdMotivoEstudio, value); }
		}
		  
		[XmlAttribute("FechaEstudio")]
		[Bindable(true)]
		public DateTime FechaEstudio 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaEstudio); }
			set { SetColumnValue(Columns.FechaEstudio, value); }
		}
		  
		[XmlAttribute("Magnificada")]
		[Bindable(true)]
		public int Magnificada 
		{
			get { return GetColumnValue<int>(Columns.Magnificada); }
			set { SetColumnValue(Columns.Magnificada, value); }
		}
		  
		[XmlAttribute("IdBiradsI")]
		[Bindable(true)]
		public int IdBiradsI 
		{
			get { return GetColumnValue<int>(Columns.IdBiradsI); }
			set { SetColumnValue(Columns.IdBiradsI, value); }
		}
		  
		[XmlAttribute("IdBiradsD")]
		[Bindable(true)]
		public int IdBiradsD 
		{
			get { return GetColumnValue<int>(Columns.IdBiradsD); }
			set { SetColumnValue(Columns.IdBiradsD, value); }
		}
		  
		[XmlAttribute("IdBiradsDef")]
		[Bindable(true)]
		public int IdBiradsDef 
		{
			get { return GetColumnValue<int>(Columns.IdBiradsDef); }
			set { SetColumnValue(Columns.IdBiradsDef, value); }
		}
		  
		[XmlAttribute("Informe")]
		[Bindable(true)]
		public string Informe 
		{
			get { return GetColumnValue<string>(Columns.Informe); }
			set { SetColumnValue(Columns.Informe, value); }
		}
		  
		[XmlAttribute("IdProfesionalResponsable")]
		[Bindable(true)]
		public int IdProfesionalResponsable 
		{
			get { return GetColumnValue<int>(Columns.IdProfesionalResponsable); }
			set { SetColumnValue(Columns.IdProfesionalResponsable, value); }
		}
		  
		[XmlAttribute("IdCentroSalud")]
		[Bindable(true)]
		public int IdCentroSalud 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSalud); }
			set { SetColumnValue(Columns.IdCentroSalud, value); }
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
		  
		[XmlAttribute("IdEfectorRealizaEstudio")]
		[Bindable(true)]
		public int IdEfectorRealizaEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEfectorRealizaEstudio); }
			set { SetColumnValue(Columns.IdEfectorRealizaEstudio, value); }
		}
		  
		[XmlAttribute("IdTipoEquipo")]
		[Bindable(true)]
		public int IdTipoEquipo 
		{
			get { return GetColumnValue<int>(Columns.IdTipoEquipo); }
			set { SetColumnValue(Columns.IdTipoEquipo, value); }
		}
		  
		[XmlAttribute("IdProfesionalTecnico")]
		[Bindable(true)]
		public int IdProfesionalTecnico 
		{
			get { return GetColumnValue<int>(Columns.IdProfesionalTecnico); }
			set { SetColumnValue(Columns.IdProfesionalTecnico, value); }
		}
		  
		[XmlAttribute("FechaInforme")]
		[Bindable(true)]
		public DateTime FechaInforme 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInforme); }
			set { SetColumnValue(Columns.FechaInforme, value); }
		}
		  
		[XmlAttribute("Protocolo")]
		[Bindable(true)]
		public string Protocolo 
		{
			get { return GetColumnValue<string>(Columns.Protocolo); }
			set { SetColumnValue(Columns.Protocolo, value); }
		}
		  
		[XmlAttribute("Tomosintesis")]
		[Bindable(true)]
		public int Tomosintesis 
		{
			get { return GetColumnValue<int>(Columns.Tomosintesis); }
			set { SetColumnValue(Columns.Tomosintesis, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSalud); }
			set { SetColumnValue("idCentroSalud", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdEfectorRealizaEstudio
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorRealizaEstudio); }
			set { SetColumnValue("idEfectorRealizaEstudio", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a MamBirad ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.MamBirad MamBirad
		{
			get { return DalSic.MamBirad.FetchByID(this.IdBiradsDef); }
			set { SetColumnValue("idBiradsDef", value.IdBirads); }
		}
		
		
		/// <summary>
		/// Returns a MamBirad ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.MamBirad MamBiradToIdBiradsI
		{
			get { return DalSic.MamBirad.FetchByID(this.IdBiradsI); }
			set { SetColumnValue("idBiradsI", value.IdBirads); }
		}
		
		
		/// <summary>
		/// Returns a MamBirad ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.MamBirad MamBiradToIdBiradsD
		{
			get { return DalSic.MamBirad.FetchByID(this.IdBiradsD); }
			set { SetColumnValue("idBiradsD", value.IdBirads); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.SysPaciente SysPaciente
		{
			get { return DalSic.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a MamTipoEquipo ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.MamTipoEquipo MamTipoEquipo
		{
			get { return DalSic.MamTipoEquipo.FetchByID(this.IdTipoEquipo); }
			set { SetColumnValue("idTipoEquipo", value.IdTipoEquipo); }
		}
		
		
		/// <summary>
		/// Returns a MamMotivo ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.MamMotivo MamMotivo
		{
			get { return DalSic.MamMotivo.FetchByID(this.IdMotivoEstudio); }
			set { SetColumnValue("idMotivoEstudio", value.IdMotivo); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesionalResponsable); }
			set { SetColumnValue("idProfesionalResponsable", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamEstudiosAdicionale
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesionalToIdProfesionalTecnico
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesionalTecnico); }
			set { SetColumnValue("idProfesionalTecnico", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varEdad,int varIdMotivoEstudio,DateTime varFechaEstudio,int varMagnificada,int varIdBiradsI,int varIdBiradsD,int varIdBiradsDef,string varInforme,int varIdProfesionalResponsable,int varIdCentroSalud,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varIdEfectorRealizaEstudio,int varIdTipoEquipo,int varIdProfesionalTecnico,DateTime varFechaInforme,string varProtocolo,int varTomosintesis)
		{
			MamEstudiosAdicionale item = new MamEstudiosAdicionale();
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.IdMotivoEstudio = varIdMotivoEstudio;
			
			item.FechaEstudio = varFechaEstudio;
			
			item.Magnificada = varMagnificada;
			
			item.IdBiradsI = varIdBiradsI;
			
			item.IdBiradsD = varIdBiradsD;
			
			item.IdBiradsDef = varIdBiradsDef;
			
			item.Informe = varInforme;
			
			item.IdProfesionalResponsable = varIdProfesionalResponsable;
			
			item.IdCentroSalud = varIdCentroSalud;
			
			item.Activo = varActivo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IdEfectorRealizaEstudio = varIdEfectorRealizaEstudio;
			
			item.IdTipoEquipo = varIdTipoEquipo;
			
			item.IdProfesionalTecnico = varIdProfesionalTecnico;
			
			item.FechaInforme = varFechaInforme;
			
			item.Protocolo = varProtocolo;
			
			item.Tomosintesis = varTomosintesis;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioAdicional,int varIdPaciente,int varEdad,int varIdMotivoEstudio,DateTime varFechaEstudio,int varMagnificada,int varIdBiradsI,int varIdBiradsD,int varIdBiradsDef,string varInforme,int varIdProfesionalResponsable,int varIdCentroSalud,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varIdEfectorRealizaEstudio,int varIdTipoEquipo,int varIdProfesionalTecnico,DateTime varFechaInforme,string varProtocolo,int varTomosintesis)
		{
			MamEstudiosAdicionale item = new MamEstudiosAdicionale();
			
				item.IdEstudioAdicional = varIdEstudioAdicional;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.IdMotivoEstudio = varIdMotivoEstudio;
			
				item.FechaEstudio = varFechaEstudio;
			
				item.Magnificada = varMagnificada;
			
				item.IdBiradsI = varIdBiradsI;
			
				item.IdBiradsD = varIdBiradsD;
			
				item.IdBiradsDef = varIdBiradsDef;
			
				item.Informe = varInforme;
			
				item.IdProfesionalResponsable = varIdProfesionalResponsable;
			
				item.IdCentroSalud = varIdCentroSalud;
			
				item.Activo = varActivo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.IdEfectorRealizaEstudio = varIdEfectorRealizaEstudio;
			
				item.IdTipoEquipo = varIdTipoEquipo;
			
				item.IdProfesionalTecnico = varIdProfesionalTecnico;
			
				item.FechaInforme = varFechaInforme;
			
				item.Protocolo = varProtocolo;
			
				item.Tomosintesis = varTomosintesis;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioAdicionalColumn
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
        
        
        
        public static TableSchema.TableColumn IdMotivoEstudioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEstudioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MagnificadaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBiradsIColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBiradsDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBiradsDefColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalResponsableColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorRealizaEstudioColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEquipoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalTecnicoColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInformeColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ProtocoloColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn TomosintesisColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioAdicional = @"idEstudioAdicional";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string IdMotivoEstudio = @"idMotivoEstudio";
			 public static string FechaEstudio = @"fechaEstudio";
			 public static string Magnificada = @"magnificada";
			 public static string IdBiradsI = @"idBiradsI";
			 public static string IdBiradsD = @"idBiradsD";
			 public static string IdBiradsDef = @"idBiradsDef";
			 public static string Informe = @"informe";
			 public static string IdProfesionalResponsable = @"idProfesionalResponsable";
			 public static string IdCentroSalud = @"idCentroSalud";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IdEfectorRealizaEstudio = @"idEfectorRealizaEstudio";
			 public static string IdTipoEquipo = @"idTipoEquipo";
			 public static string IdProfesionalTecnico = @"idProfesionalTecnico";
			 public static string FechaInforme = @"fechaInforme";
			 public static string Protocolo = @"protocolo";
			 public static string Tomosintesis = @"tomosintesis";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
