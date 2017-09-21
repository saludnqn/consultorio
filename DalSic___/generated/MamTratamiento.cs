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
	/// Strongly-typed collection for the MamTratamiento class.
	/// </summary>
    [Serializable]
	public partial class MamTratamientoCollection : ActiveList<MamTratamiento, MamTratamientoCollection>
	{	   
		public MamTratamientoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamTratamientoCollection</returns>
		public MamTratamientoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamTratamiento o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_Tratamientos table.
	/// </summary>
	[Serializable]
	public partial class MamTratamiento : ActiveRecord<MamTratamiento>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamTratamiento()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamTratamiento(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamTratamiento(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamTratamiento(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_Tratamientos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTratamiento = new TableSchema.TableColumn(schema);
				colvarIdTratamiento.ColumnName = "idTratamiento";
				colvarIdTratamiento.DataType = DbType.Int32;
				colvarIdTratamiento.MaxLength = 0;
				colvarIdTratamiento.AutoIncrement = true;
				colvarIdTratamiento.IsNullable = false;
				colvarIdTratamiento.IsPrimaryKey = true;
				colvarIdTratamiento.IsForeignKey = false;
				colvarIdTratamiento.IsReadOnly = false;
				colvarIdTratamiento.DefaultSetting = @"";
				colvarIdTratamiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTratamiento);
				
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
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
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
				
				TableSchema.TableColumn colvarNeoadyuvancia = new TableSchema.TableColumn(schema);
				colvarNeoadyuvancia.ColumnName = "neoadyuvancia";
				colvarNeoadyuvancia.DataType = DbType.Int32;
				colvarNeoadyuvancia.MaxLength = 0;
				colvarNeoadyuvancia.AutoIncrement = false;
				colvarNeoadyuvancia.IsNullable = false;
				colvarNeoadyuvancia.IsPrimaryKey = false;
				colvarNeoadyuvancia.IsForeignKey = false;
				colvarNeoadyuvancia.IsReadOnly = false;
				
						colvarNeoadyuvancia.DefaultSetting = @"((0))";
				colvarNeoadyuvancia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeoadyuvancia);
				
				TableSchema.TableColumn colvarFechaInicioNeoadyuvancia = new TableSchema.TableColumn(schema);
				colvarFechaInicioNeoadyuvancia.ColumnName = "fechaInicioNeoadyuvancia";
				colvarFechaInicioNeoadyuvancia.DataType = DbType.DateTime;
				colvarFechaInicioNeoadyuvancia.MaxLength = 0;
				colvarFechaInicioNeoadyuvancia.AutoIncrement = false;
				colvarFechaInicioNeoadyuvancia.IsNullable = false;
				colvarFechaInicioNeoadyuvancia.IsPrimaryKey = false;
				colvarFechaInicioNeoadyuvancia.IsForeignKey = false;
				colvarFechaInicioNeoadyuvancia.IsReadOnly = false;
				colvarFechaInicioNeoadyuvancia.DefaultSetting = @"";
				colvarFechaInicioNeoadyuvancia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInicioNeoadyuvancia);
				
				TableSchema.TableColumn colvarQuimioterapia = new TableSchema.TableColumn(schema);
				colvarQuimioterapia.ColumnName = "quimioterapia";
				colvarQuimioterapia.DataType = DbType.Int32;
				colvarQuimioterapia.MaxLength = 0;
				colvarQuimioterapia.AutoIncrement = false;
				colvarQuimioterapia.IsNullable = false;
				colvarQuimioterapia.IsPrimaryKey = false;
				colvarQuimioterapia.IsForeignKey = false;
				colvarQuimioterapia.IsReadOnly = false;
				
						colvarQuimioterapia.DefaultSetting = @"((0))";
				colvarQuimioterapia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuimioterapia);
				
				TableSchema.TableColumn colvarFechaInicioQuimio = new TableSchema.TableColumn(schema);
				colvarFechaInicioQuimio.ColumnName = "fechaInicioQuimio";
				colvarFechaInicioQuimio.DataType = DbType.DateTime;
				colvarFechaInicioQuimio.MaxLength = 0;
				colvarFechaInicioQuimio.AutoIncrement = false;
				colvarFechaInicioQuimio.IsNullable = false;
				colvarFechaInicioQuimio.IsPrimaryKey = false;
				colvarFechaInicioQuimio.IsForeignKey = false;
				colvarFechaInicioQuimio.IsReadOnly = false;
				colvarFechaInicioQuimio.DefaultSetting = @"";
				colvarFechaInicioQuimio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInicioQuimio);
				
				TableSchema.TableColumn colvarRadioterapia = new TableSchema.TableColumn(schema);
				colvarRadioterapia.ColumnName = "radioterapia";
				colvarRadioterapia.DataType = DbType.Int32;
				colvarRadioterapia.MaxLength = 0;
				colvarRadioterapia.AutoIncrement = false;
				colvarRadioterapia.IsNullable = false;
				colvarRadioterapia.IsPrimaryKey = false;
				colvarRadioterapia.IsForeignKey = false;
				colvarRadioterapia.IsReadOnly = false;
				
						colvarRadioterapia.DefaultSetting = @"((0))";
				colvarRadioterapia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRadioterapia);
				
				TableSchema.TableColumn colvarFechaInicioRadioterapia = new TableSchema.TableColumn(schema);
				colvarFechaInicioRadioterapia.ColumnName = "fechaInicioRadioterapia";
				colvarFechaInicioRadioterapia.DataType = DbType.DateTime;
				colvarFechaInicioRadioterapia.MaxLength = 0;
				colvarFechaInicioRadioterapia.AutoIncrement = false;
				colvarFechaInicioRadioterapia.IsNullable = false;
				colvarFechaInicioRadioterapia.IsPrimaryKey = false;
				colvarFechaInicioRadioterapia.IsForeignKey = false;
				colvarFechaInicioRadioterapia.IsReadOnly = false;
				colvarFechaInicioRadioterapia.DefaultSetting = @"";
				colvarFechaInicioRadioterapia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInicioRadioterapia);
				
				TableSchema.TableColumn colvarTrastuzumab = new TableSchema.TableColumn(schema);
				colvarTrastuzumab.ColumnName = "trastuzumab";
				colvarTrastuzumab.DataType = DbType.Int32;
				colvarTrastuzumab.MaxLength = 0;
				colvarTrastuzumab.AutoIncrement = false;
				colvarTrastuzumab.IsNullable = false;
				colvarTrastuzumab.IsPrimaryKey = false;
				colvarTrastuzumab.IsForeignKey = false;
				colvarTrastuzumab.IsReadOnly = false;
				
						colvarTrastuzumab.DefaultSetting = @"((0))";
				colvarTrastuzumab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrastuzumab);
				
				TableSchema.TableColumn colvarFechaInicioTrastuzumab = new TableSchema.TableColumn(schema);
				colvarFechaInicioTrastuzumab.ColumnName = "fechaInicioTrastuzumab";
				colvarFechaInicioTrastuzumab.DataType = DbType.DateTime;
				colvarFechaInicioTrastuzumab.MaxLength = 0;
				colvarFechaInicioTrastuzumab.AutoIncrement = false;
				colvarFechaInicioTrastuzumab.IsNullable = false;
				colvarFechaInicioTrastuzumab.IsPrimaryKey = false;
				colvarFechaInicioTrastuzumab.IsForeignKey = false;
				colvarFechaInicioTrastuzumab.IsReadOnly = false;
				colvarFechaInicioTrastuzumab.DefaultSetting = @"";
				colvarFechaInicioTrastuzumab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInicioTrastuzumab);
				
				TableSchema.TableColumn colvarHormonoterapia = new TableSchema.TableColumn(schema);
				colvarHormonoterapia.ColumnName = "Hormonoterapia";
				colvarHormonoterapia.DataType = DbType.AnsiString;
				colvarHormonoterapia.MaxLength = 50;
				colvarHormonoterapia.AutoIncrement = false;
				colvarHormonoterapia.IsNullable = false;
				colvarHormonoterapia.IsPrimaryKey = false;
				colvarHormonoterapia.IsForeignKey = false;
				colvarHormonoterapia.IsReadOnly = false;
				
						colvarHormonoterapia.DefaultSetting = @"('')";
				colvarHormonoterapia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHormonoterapia);
				
				TableSchema.TableColumn colvarFechaHormonoterapiaInicial = new TableSchema.TableColumn(schema);
				colvarFechaHormonoterapiaInicial.ColumnName = "fechaHormonoterapiaInicial";
				colvarFechaHormonoterapiaInicial.DataType = DbType.DateTime;
				colvarFechaHormonoterapiaInicial.MaxLength = 0;
				colvarFechaHormonoterapiaInicial.AutoIncrement = false;
				colvarFechaHormonoterapiaInicial.IsNullable = false;
				colvarFechaHormonoterapiaInicial.IsPrimaryKey = false;
				colvarFechaHormonoterapiaInicial.IsForeignKey = false;
				colvarFechaHormonoterapiaInicial.IsReadOnly = false;
				colvarFechaHormonoterapiaInicial.DefaultSetting = @"";
				colvarFechaHormonoterapiaInicial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHormonoterapiaInicial);
				
				TableSchema.TableColumn colvarFechaHormonoterapia = new TableSchema.TableColumn(schema);
				colvarFechaHormonoterapia.ColumnName = "fechaHormonoterapia";
				colvarFechaHormonoterapia.DataType = DbType.DateTime;
				colvarFechaHormonoterapia.MaxLength = 0;
				colvarFechaHormonoterapia.AutoIncrement = false;
				colvarFechaHormonoterapia.IsNullable = false;
				colvarFechaHormonoterapia.IsPrimaryKey = false;
				colvarFechaHormonoterapia.IsForeignKey = false;
				colvarFechaHormonoterapia.IsReadOnly = false;
				colvarFechaHormonoterapia.DefaultSetting = @"";
				colvarFechaHormonoterapia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHormonoterapia);
				
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
				
				TableSchema.TableColumn colvarIdResponsableExamen = new TableSchema.TableColumn(schema);
				colvarIdResponsableExamen.ColumnName = "idResponsableExamen";
				colvarIdResponsableExamen.DataType = DbType.Int32;
				colvarIdResponsableExamen.MaxLength = 0;
				colvarIdResponsableExamen.AutoIncrement = false;
				colvarIdResponsableExamen.IsNullable = false;
				colvarIdResponsableExamen.IsPrimaryKey = false;
				colvarIdResponsableExamen.IsForeignKey = true;
				colvarIdResponsableExamen.IsReadOnly = false;
				
						colvarIdResponsableExamen.DefaultSetting = @"((0))";
				
					colvarIdResponsableExamen.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdResponsableExamen);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_Tratamientos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTratamiento")]
		[Bindable(true)]
		public int IdTratamiento 
		{
			get { return GetColumnValue<int>(Columns.IdTratamiento); }
			set { SetColumnValue(Columns.IdTratamiento, value); }
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
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("Neoadyuvancia")]
		[Bindable(true)]
		public int Neoadyuvancia 
		{
			get { return GetColumnValue<int>(Columns.Neoadyuvancia); }
			set { SetColumnValue(Columns.Neoadyuvancia, value); }
		}
		  
		[XmlAttribute("FechaInicioNeoadyuvancia")]
		[Bindable(true)]
		public DateTime FechaInicioNeoadyuvancia 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInicioNeoadyuvancia); }
			set { SetColumnValue(Columns.FechaInicioNeoadyuvancia, value); }
		}
		  
		[XmlAttribute("Quimioterapia")]
		[Bindable(true)]
		public int Quimioterapia 
		{
			get { return GetColumnValue<int>(Columns.Quimioterapia); }
			set { SetColumnValue(Columns.Quimioterapia, value); }
		}
		  
		[XmlAttribute("FechaInicioQuimio")]
		[Bindable(true)]
		public DateTime FechaInicioQuimio 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInicioQuimio); }
			set { SetColumnValue(Columns.FechaInicioQuimio, value); }
		}
		  
		[XmlAttribute("Radioterapia")]
		[Bindable(true)]
		public int Radioterapia 
		{
			get { return GetColumnValue<int>(Columns.Radioterapia); }
			set { SetColumnValue(Columns.Radioterapia, value); }
		}
		  
		[XmlAttribute("FechaInicioRadioterapia")]
		[Bindable(true)]
		public DateTime FechaInicioRadioterapia 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInicioRadioterapia); }
			set { SetColumnValue(Columns.FechaInicioRadioterapia, value); }
		}
		  
		[XmlAttribute("Trastuzumab")]
		[Bindable(true)]
		public int Trastuzumab 
		{
			get { return GetColumnValue<int>(Columns.Trastuzumab); }
			set { SetColumnValue(Columns.Trastuzumab, value); }
		}
		  
		[XmlAttribute("FechaInicioTrastuzumab")]
		[Bindable(true)]
		public DateTime FechaInicioTrastuzumab 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInicioTrastuzumab); }
			set { SetColumnValue(Columns.FechaInicioTrastuzumab, value); }
		}
		  
		[XmlAttribute("Hormonoterapia")]
		[Bindable(true)]
		public string Hormonoterapia 
		{
			get { return GetColumnValue<string>(Columns.Hormonoterapia); }
			set { SetColumnValue(Columns.Hormonoterapia, value); }
		}
		  
		[XmlAttribute("FechaHormonoterapiaInicial")]
		[Bindable(true)]
		public DateTime FechaHormonoterapiaInicial 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHormonoterapiaInicial); }
			set { SetColumnValue(Columns.FechaHormonoterapiaInicial, value); }
		}
		  
		[XmlAttribute("FechaHormonoterapia")]
		[Bindable(true)]
		public DateTime FechaHormonoterapia 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHormonoterapia); }
			set { SetColumnValue(Columns.FechaHormonoterapia, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		  
		[XmlAttribute("IdResponsableExamen")]
		[Bindable(true)]
		public int IdResponsableExamen 
		{
			get { return GetColumnValue<int>(Columns.IdResponsableExamen); }
			set { SetColumnValue(Columns.IdResponsableExamen, value); }
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
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamTratamiento
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSalud); }
			set { SetColumnValue("idCentroSalud", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamTratamiento
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdResponsableExamen); }
			set { SetColumnValue("idResponsableExamen", value.IdProfesional); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,DateTime varFecha,int varEdad,int varNeoadyuvancia,DateTime varFechaInicioNeoadyuvancia,int varQuimioterapia,DateTime varFechaInicioQuimio,int varRadioterapia,DateTime varFechaInicioRadioterapia,int varTrastuzumab,DateTime varFechaInicioTrastuzumab,string varHormonoterapia,DateTime varFechaHormonoterapiaInicial,DateTime varFechaHormonoterapia,string varObservacion,int varIdResponsableExamen,int varIdCentroSalud,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamTratamiento item = new MamTratamiento();
			
			item.IdPaciente = varIdPaciente;
			
			item.Fecha = varFecha;
			
			item.Edad = varEdad;
			
			item.Neoadyuvancia = varNeoadyuvancia;
			
			item.FechaInicioNeoadyuvancia = varFechaInicioNeoadyuvancia;
			
			item.Quimioterapia = varQuimioterapia;
			
			item.FechaInicioQuimio = varFechaInicioQuimio;
			
			item.Radioterapia = varRadioterapia;
			
			item.FechaInicioRadioterapia = varFechaInicioRadioterapia;
			
			item.Trastuzumab = varTrastuzumab;
			
			item.FechaInicioTrastuzumab = varFechaInicioTrastuzumab;
			
			item.Hormonoterapia = varHormonoterapia;
			
			item.FechaHormonoterapiaInicial = varFechaHormonoterapiaInicial;
			
			item.FechaHormonoterapia = varFechaHormonoterapia;
			
			item.Observacion = varObservacion;
			
			item.IdResponsableExamen = varIdResponsableExamen;
			
			item.IdCentroSalud = varIdCentroSalud;
			
			item.Activo = varActivo;
			
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
		public static void Update(int varIdTratamiento,int varIdPaciente,DateTime varFecha,int varEdad,int varNeoadyuvancia,DateTime varFechaInicioNeoadyuvancia,int varQuimioterapia,DateTime varFechaInicioQuimio,int varRadioterapia,DateTime varFechaInicioRadioterapia,int varTrastuzumab,DateTime varFechaInicioTrastuzumab,string varHormonoterapia,DateTime varFechaHormonoterapiaInicial,DateTime varFechaHormonoterapia,string varObservacion,int varIdResponsableExamen,int varIdCentroSalud,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamTratamiento item = new MamTratamiento();
			
				item.IdTratamiento = varIdTratamiento;
			
				item.IdPaciente = varIdPaciente;
			
				item.Fecha = varFecha;
			
				item.Edad = varEdad;
			
				item.Neoadyuvancia = varNeoadyuvancia;
			
				item.FechaInicioNeoadyuvancia = varFechaInicioNeoadyuvancia;
			
				item.Quimioterapia = varQuimioterapia;
			
				item.FechaInicioQuimio = varFechaInicioQuimio;
			
				item.Radioterapia = varRadioterapia;
			
				item.FechaInicioRadioterapia = varFechaInicioRadioterapia;
			
				item.Trastuzumab = varTrastuzumab;
			
				item.FechaInicioTrastuzumab = varFechaInicioTrastuzumab;
			
				item.Hormonoterapia = varHormonoterapia;
			
				item.FechaHormonoterapiaInicial = varFechaHormonoterapiaInicial;
			
				item.FechaHormonoterapia = varFechaHormonoterapia;
			
				item.Observacion = varObservacion;
			
				item.IdResponsableExamen = varIdResponsableExamen;
			
				item.IdCentroSalud = varIdCentroSalud;
			
				item.Activo = varActivo;
			
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
        
        
        public static TableSchema.TableColumn IdTratamientoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NeoadyuvanciaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInicioNeoadyuvanciaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn QuimioterapiaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInicioQuimioColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn RadioterapiaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInicioRadioterapiaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn TrastuzumabColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInicioTrastuzumabColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn HormonoterapiaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHormonoterapiaInicialColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHormonoterapiaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResponsableExamenColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludColumn
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
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTratamiento = @"idTratamiento";
			 public static string IdPaciente = @"idPaciente";
			 public static string Fecha = @"fecha";
			 public static string Edad = @"edad";
			 public static string Neoadyuvancia = @"neoadyuvancia";
			 public static string FechaInicioNeoadyuvancia = @"fechaInicioNeoadyuvancia";
			 public static string Quimioterapia = @"quimioterapia";
			 public static string FechaInicioQuimio = @"fechaInicioQuimio";
			 public static string Radioterapia = @"radioterapia";
			 public static string FechaInicioRadioterapia = @"fechaInicioRadioterapia";
			 public static string Trastuzumab = @"trastuzumab";
			 public static string FechaInicioTrastuzumab = @"fechaInicioTrastuzumab";
			 public static string Hormonoterapia = @"Hormonoterapia";
			 public static string FechaHormonoterapiaInicial = @"fechaHormonoterapiaInicial";
			 public static string FechaHormonoterapia = @"fechaHormonoterapia";
			 public static string Observacion = @"observacion";
			 public static string IdResponsableExamen = @"idResponsableExamen";
			 public static string IdCentroSalud = @"idCentroSalud";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
