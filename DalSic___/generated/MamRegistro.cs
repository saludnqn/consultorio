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
	/// Strongly-typed collection for the MamRegistro class.
	/// </summary>
    [Serializable]
	public partial class MamRegistroCollection : ActiveList<MamRegistro, MamRegistroCollection>
	{	   
		public MamRegistroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamRegistroCollection</returns>
		public MamRegistroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamRegistro o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_Registro table.
	/// </summary>
	[Serializable]
	public partial class MamRegistro : ActiveRecord<MamRegistro>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamRegistro()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamRegistro(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamRegistro(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamRegistro(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_Registro", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMamas = new TableSchema.TableColumn(schema);
				colvarIdMamas.ColumnName = "idMamas";
				colvarIdMamas.DataType = DbType.Int32;
				colvarIdMamas.MaxLength = 0;
				colvarIdMamas.AutoIncrement = true;
				colvarIdMamas.IsNullable = false;
				colvarIdMamas.IsPrimaryKey = true;
				colvarIdMamas.IsForeignKey = false;
				colvarIdMamas.IsReadOnly = false;
				colvarIdMamas.DefaultSetting = @"";
				colvarIdMamas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMamas);
				
				TableSchema.TableColumn colvarIdEfectorProcedencia = new TableSchema.TableColumn(schema);
				colvarIdEfectorProcedencia.ColumnName = "idEfectorProcedencia";
				colvarIdEfectorProcedencia.DataType = DbType.Int32;
				colvarIdEfectorProcedencia.MaxLength = 0;
				colvarIdEfectorProcedencia.AutoIncrement = false;
				colvarIdEfectorProcedencia.IsNullable = false;
				colvarIdEfectorProcedencia.IsPrimaryKey = false;
				colvarIdEfectorProcedencia.IsForeignKey = true;
				colvarIdEfectorProcedencia.IsReadOnly = false;
				colvarIdEfectorProcedencia.DefaultSetting = @"";
				
					colvarIdEfectorProcedencia.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorProcedencia);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
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
				
				TableSchema.TableColumn colvarFechaIngreso = new TableSchema.TableColumn(schema);
				colvarFechaIngreso.ColumnName = "fechaIngreso";
				colvarFechaIngreso.DataType = DbType.DateTime;
				colvarFechaIngreso.MaxLength = 0;
				colvarFechaIngreso.AutoIncrement = false;
				colvarFechaIngreso.IsNullable = false;
				colvarFechaIngreso.IsPrimaryKey = false;
				colvarFechaIngreso.IsForeignKey = false;
				colvarFechaIngreso.IsReadOnly = false;
				colvarFechaIngreso.DefaultSetting = @"";
				colvarFechaIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaIngreso);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 500;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = false;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				
						colvarObservacion.DefaultSetting = @"('')";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				TableSchema.TableColumn colvarIdProfesionalSolicita = new TableSchema.TableColumn(schema);
				colvarIdProfesionalSolicita.ColumnName = "idProfesionalSolicita";
				colvarIdProfesionalSolicita.DataType = DbType.Int32;
				colvarIdProfesionalSolicita.MaxLength = 0;
				colvarIdProfesionalSolicita.AutoIncrement = false;
				colvarIdProfesionalSolicita.IsNullable = false;
				colvarIdProfesionalSolicita.IsPrimaryKey = false;
				colvarIdProfesionalSolicita.IsForeignKey = true;
				colvarIdProfesionalSolicita.IsReadOnly = false;
				colvarIdProfesionalSolicita.DefaultSetting = @"";
				
					colvarIdProfesionalSolicita.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesionalSolicita);
				
				TableSchema.TableColumn colvarFechaPlaca = new TableSchema.TableColumn(schema);
				colvarFechaPlaca.ColumnName = "fechaPlaca";
				colvarFechaPlaca.DataType = DbType.DateTime;
				colvarFechaPlaca.MaxLength = 0;
				colvarFechaPlaca.AutoIncrement = false;
				colvarFechaPlaca.IsNullable = false;
				colvarFechaPlaca.IsPrimaryKey = false;
				colvarFechaPlaca.IsForeignKey = false;
				colvarFechaPlaca.IsReadOnly = false;
				colvarFechaPlaca.DefaultSetting = @"";
				colvarFechaPlaca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaPlaca);
				
				TableSchema.TableColumn colvarFechaInforme = new TableSchema.TableColumn(schema);
				colvarFechaInforme.ColumnName = "fechaInforme";
				colvarFechaInforme.DataType = DbType.DateTime;
				colvarFechaInforme.MaxLength = 0;
				colvarFechaInforme.AutoIncrement = false;
				colvarFechaInforme.IsNullable = false;
				colvarFechaInforme.IsPrimaryKey = false;
				colvarFechaInforme.IsForeignKey = false;
				colvarFechaInforme.IsReadOnly = false;
				colvarFechaInforme.DefaultSetting = @"";
				colvarFechaInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInforme);
				
				TableSchema.TableColumn colvarInforme = new TableSchema.TableColumn(schema);
				colvarInforme.ColumnName = "informe";
				colvarInforme.DataType = DbType.AnsiString;
				colvarInforme.MaxLength = 2000;
				colvarInforme.AutoIncrement = false;
				colvarInforme.IsNullable = false;
				colvarInforme.IsPrimaryKey = false;
				colvarInforme.IsForeignKey = false;
				colvarInforme.IsReadOnly = false;
				
						colvarInforme.DefaultSetting = @"('')";
				colvarInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInforme);
				
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
				
				TableSchema.TableColumn colvarIdEfectorControl = new TableSchema.TableColumn(schema);
				colvarIdEfectorControl.ColumnName = "idEfectorControl";
				colvarIdEfectorControl.DataType = DbType.Int32;
				colvarIdEfectorControl.MaxLength = 0;
				colvarIdEfectorControl.AutoIncrement = false;
				colvarIdEfectorControl.IsNullable = false;
				colvarIdEfectorControl.IsPrimaryKey = false;
				colvarIdEfectorControl.IsForeignKey = true;
				colvarIdEfectorControl.IsReadOnly = false;
				
						colvarIdEfectorControl.DefaultSetting = @"((0))";
				
					colvarIdEfectorControl.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorControl);
				
				TableSchema.TableColumn colvarProcedimiento = new TableSchema.TableColumn(schema);
				colvarProcedimiento.ColumnName = "procedimiento";
				colvarProcedimiento.DataType = DbType.AnsiString;
				colvarProcedimiento.MaxLength = 50;
				colvarProcedimiento.AutoIncrement = false;
				colvarProcedimiento.IsNullable = false;
				colvarProcedimiento.IsPrimaryKey = false;
				colvarProcedimiento.IsForeignKey = false;
				colvarProcedimiento.IsReadOnly = false;
				
						colvarProcedimiento.DefaultSetting = @"('')";
				colvarProcedimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProcedimiento);
				
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
				
				TableSchema.TableColumn colvarIdMotivo = new TableSchema.TableColumn(schema);
				colvarIdMotivo.ColumnName = "idMotivo";
				colvarIdMotivo.DataType = DbType.Int32;
				colvarIdMotivo.MaxLength = 0;
				colvarIdMotivo.AutoIncrement = false;
				colvarIdMotivo.IsNullable = false;
				colvarIdMotivo.IsPrimaryKey = false;
				colvarIdMotivo.IsForeignKey = true;
				colvarIdMotivo.IsReadOnly = false;
				
						colvarIdMotivo.DefaultSetting = @"((0))";
				
					colvarIdMotivo.ForeignKeyTableName = "MAM_Motivo";
				schema.Columns.Add(colvarIdMotivo);
				
				TableSchema.TableColumn colvarIdProfesionalInforma = new TableSchema.TableColumn(schema);
				colvarIdProfesionalInforma.ColumnName = "idProfesionalInforma";
				colvarIdProfesionalInforma.DataType = DbType.Int32;
				colvarIdProfesionalInforma.MaxLength = 0;
				colvarIdProfesionalInforma.AutoIncrement = false;
				colvarIdProfesionalInforma.IsNullable = false;
				colvarIdProfesionalInforma.IsPrimaryKey = false;
				colvarIdProfesionalInforma.IsForeignKey = true;
				colvarIdProfesionalInforma.IsReadOnly = false;
				
						colvarIdProfesionalInforma.DefaultSetting = @"((0))";
				
					colvarIdProfesionalInforma.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesionalInforma);
				
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
				colvarIdTipoEquipo.IsForeignKey = false;
				colvarIdTipoEquipo.IsReadOnly = false;
				
						colvarIdTipoEquipo.DefaultSetting = @"((0))";
				colvarIdTipoEquipo.ForeignKeyTableName = "";
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_Registro",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMamas")]
		[Bindable(true)]
		public int IdMamas 
		{
			get { return GetColumnValue<int>(Columns.IdMamas); }
			set { SetColumnValue(Columns.IdMamas, value); }
		}
		  
		[XmlAttribute("IdEfectorProcedencia")]
		[Bindable(true)]
		public int IdEfectorProcedencia 
		{
			get { return GetColumnValue<int>(Columns.IdEfectorProcedencia); }
			set { SetColumnValue(Columns.IdEfectorProcedencia, value); }
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
		  
		[XmlAttribute("FechaIngreso")]
		[Bindable(true)]
		public DateTime FechaIngreso 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaIngreso); }
			set { SetColumnValue(Columns.FechaIngreso, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("IdProfesionalSolicita")]
		[Bindable(true)]
		public int IdProfesionalSolicita 
		{
			get { return GetColumnValue<int>(Columns.IdProfesionalSolicita); }
			set { SetColumnValue(Columns.IdProfesionalSolicita, value); }
		}
		  
		[XmlAttribute("FechaPlaca")]
		[Bindable(true)]
		public DateTime FechaPlaca 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaPlaca); }
			set { SetColumnValue(Columns.FechaPlaca, value); }
		}
		  
		[XmlAttribute("FechaInforme")]
		[Bindable(true)]
		public DateTime FechaInforme 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInforme); }
			set { SetColumnValue(Columns.FechaInforme, value); }
		}
		  
		[XmlAttribute("Informe")]
		[Bindable(true)]
		public string Informe 
		{
			get { return GetColumnValue<string>(Columns.Informe); }
			set { SetColumnValue(Columns.Informe, value); }
		}
		  
		[XmlAttribute("Protocolo")]
		[Bindable(true)]
		public string Protocolo 
		{
			get { return GetColumnValue<string>(Columns.Protocolo); }
			set { SetColumnValue(Columns.Protocolo, value); }
		}
		  
		[XmlAttribute("IdEfectorControl")]
		[Bindable(true)]
		public int IdEfectorControl 
		{
			get { return GetColumnValue<int>(Columns.IdEfectorControl); }
			set { SetColumnValue(Columns.IdEfectorControl, value); }
		}
		  
		[XmlAttribute("Procedimiento")]
		[Bindable(true)]
		public string Procedimiento 
		{
			get { return GetColumnValue<string>(Columns.Procedimiento); }
			set { SetColumnValue(Columns.Procedimiento, value); }
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
		  
		[XmlAttribute("IdMotivo")]
		[Bindable(true)]
		public int IdMotivo 
		{
			get { return GetColumnValue<int>(Columns.IdMotivo); }
			set { SetColumnValue(Columns.IdMotivo, value); }
		}
		  
		[XmlAttribute("IdProfesionalInforma")]
		[Bindable(true)]
		public int IdProfesionalInforma 
		{
			get { return GetColumnValue<int>(Columns.IdProfesionalInforma); }
			set { SetColumnValue(Columns.IdProfesionalInforma, value); }
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
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorRealizaEstudio); }
			set { SetColumnValue("idEfectorRealizaEstudio", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdEfectorControl
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorControl); }
			set { SetColumnValue("idEfectorControl", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfectorToIdEfectorProcedencia
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorProcedencia); }
			set { SetColumnValue("idEfectorProcedencia", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a MamBirad ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.MamBirad MamBirad
		{
			get { return DalSic.MamBirad.FetchByID(this.IdBiradsDef); }
			set { SetColumnValue("idBiradsDef", value.IdBirads); }
		}
		
		
		/// <summary>
		/// Returns a MamBirad ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.MamBirad MamBiradToIdBiradsD
		{
			get { return DalSic.MamBirad.FetchByID(this.IdBiradsD); }
			set { SetColumnValue("idBiradsD", value.IdBirads); }
		}
		
		
		/// <summary>
		/// Returns a MamBirad ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.MamBirad MamBiradToIdBiradsI
		{
			get { return DalSic.MamBirad.FetchByID(this.IdBiradsI); }
			set { SetColumnValue("idBiradsI", value.IdBirads); }
		}
		
		
		/// <summary>
		/// Returns a MamMotivo ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.MamMotivo MamMotivo
		{
			get { return DalSic.MamMotivo.FetchByID(this.IdMotivo); }
			set { SetColumnValue("idMotivo", value.IdMotivo); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesionalTecnico); }
			set { SetColumnValue("idProfesionalTecnico", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesionalToIdProfesionalSolicita
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesionalSolicita); }
			set { SetColumnValue("idProfesionalSolicita", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamRegistro
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesionalToIdProfesionalInforma
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesionalInforma); }
			set { SetColumnValue("idProfesionalInforma", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfectorProcedencia,int varIdPaciente,int varEdad,DateTime varFechaIngreso,string varObservacion,int varIdProfesionalSolicita,DateTime varFechaPlaca,DateTime varFechaInforme,string varInforme,string varProtocolo,int varIdEfectorControl,string varProcedimiento,int varIdBiradsI,int varIdBiradsD,int varIdBiradsDef,int varIdMotivo,int varIdProfesionalInforma,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varIdEfectorRealizaEstudio,int varIdTipoEquipo,int varIdProfesionalTecnico)
		{
			MamRegistro item = new MamRegistro();
			
			item.IdEfectorProcedencia = varIdEfectorProcedencia;
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.FechaIngreso = varFechaIngreso;
			
			item.Observacion = varObservacion;
			
			item.IdProfesionalSolicita = varIdProfesionalSolicita;
			
			item.FechaPlaca = varFechaPlaca;
			
			item.FechaInforme = varFechaInforme;
			
			item.Informe = varInforme;
			
			item.Protocolo = varProtocolo;
			
			item.IdEfectorControl = varIdEfectorControl;
			
			item.Procedimiento = varProcedimiento;
			
			item.IdBiradsI = varIdBiradsI;
			
			item.IdBiradsD = varIdBiradsD;
			
			item.IdBiradsDef = varIdBiradsDef;
			
			item.IdMotivo = varIdMotivo;
			
			item.IdProfesionalInforma = varIdProfesionalInforma;
			
			item.Activo = varActivo;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IdEfectorRealizaEstudio = varIdEfectorRealizaEstudio;
			
			item.IdTipoEquipo = varIdTipoEquipo;
			
			item.IdProfesionalTecnico = varIdProfesionalTecnico;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMamas,int varIdEfectorProcedencia,int varIdPaciente,int varEdad,DateTime varFechaIngreso,string varObservacion,int varIdProfesionalSolicita,DateTime varFechaPlaca,DateTime varFechaInforme,string varInforme,string varProtocolo,int varIdEfectorControl,string varProcedimiento,int varIdBiradsI,int varIdBiradsD,int varIdBiradsDef,int varIdMotivo,int varIdProfesionalInforma,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,int varIdEfectorRealizaEstudio,int varIdTipoEquipo,int varIdProfesionalTecnico)
		{
			MamRegistro item = new MamRegistro();
			
				item.IdMamas = varIdMamas;
			
				item.IdEfectorProcedencia = varIdEfectorProcedencia;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.FechaIngreso = varFechaIngreso;
			
				item.Observacion = varObservacion;
			
				item.IdProfesionalSolicita = varIdProfesionalSolicita;
			
				item.FechaPlaca = varFechaPlaca;
			
				item.FechaInforme = varFechaInforme;
			
				item.Informe = varInforme;
			
				item.Protocolo = varProtocolo;
			
				item.IdEfectorControl = varIdEfectorControl;
			
				item.Procedimiento = varProcedimiento;
			
				item.IdBiradsI = varIdBiradsI;
			
				item.IdBiradsD = varIdBiradsD;
			
				item.IdBiradsDef = varIdBiradsDef;
			
				item.IdMotivo = varIdMotivo;
			
				item.IdProfesionalInforma = varIdProfesionalInforma;
			
				item.Activo = varActivo;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.IdEfectorRealizaEstudio = varIdEfectorRealizaEstudio;
			
				item.IdTipoEquipo = varIdTipoEquipo;
			
				item.IdProfesionalTecnico = varIdProfesionalTecnico;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMamasColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorProcedenciaColumn
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
        
        
        
        public static TableSchema.TableColumn FechaIngresoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalSolicitaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaPlacaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInformeColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn InformeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ProtocoloColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorControlColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ProcedimientoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBiradsIColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBiradsDColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBiradsDefColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMotivoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalInformaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorRealizaEstudioColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEquipoColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalTecnicoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMamas = @"idMamas";
			 public static string IdEfectorProcedencia = @"idEfectorProcedencia";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string FechaIngreso = @"fechaIngreso";
			 public static string Observacion = @"observacion";
			 public static string IdProfesionalSolicita = @"idProfesionalSolicita";
			 public static string FechaPlaca = @"fechaPlaca";
			 public static string FechaInforme = @"fechaInforme";
			 public static string Informe = @"informe";
			 public static string Protocolo = @"protocolo";
			 public static string IdEfectorControl = @"idEfectorControl";
			 public static string Procedimiento = @"procedimiento";
			 public static string IdBiradsI = @"idBiradsI";
			 public static string IdBiradsD = @"idBiradsD";
			 public static string IdBiradsDef = @"idBiradsDef";
			 public static string IdMotivo = @"idMotivo";
			 public static string IdProfesionalInforma = @"idProfesionalInforma";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IdEfectorRealizaEstudio = @"idEfectorRealizaEstudio";
			 public static string IdTipoEquipo = @"idTipoEquipo";
			 public static string IdProfesionalTecnico = @"idProfesionalTecnico";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
