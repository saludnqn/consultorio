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
	/// Strongly-typed collection for the MamCirugium class.
	/// </summary>
    [Serializable]
	public partial class MamCirugiumCollection : ActiveList<MamCirugium, MamCirugiumCollection>
	{	   
		public MamCirugiumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamCirugiumCollection</returns>
		public MamCirugiumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamCirugium o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_Cirugia table.
	/// </summary>
	[Serializable]
	public partial class MamCirugium : ActiveRecord<MamCirugium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamCirugium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamCirugium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamCirugium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamCirugium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_Cirugia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCirugia = new TableSchema.TableColumn(schema);
				colvarIdCirugia.ColumnName = "idCirugia";
				colvarIdCirugia.DataType = DbType.Int32;
				colvarIdCirugia.MaxLength = 0;
				colvarIdCirugia.AutoIncrement = true;
				colvarIdCirugia.IsNullable = false;
				colvarIdCirugia.IsPrimaryKey = true;
				colvarIdCirugia.IsForeignKey = false;
				colvarIdCirugia.IsReadOnly = false;
				colvarIdCirugia.DefaultSetting = @"";
				colvarIdCirugia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCirugia);
				
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
				
				TableSchema.TableColumn colvarIndicadorT = new TableSchema.TableColumn(schema);
				colvarIndicadorT.ColumnName = "indicadorT";
				colvarIndicadorT.DataType = DbType.AnsiString;
				colvarIndicadorT.MaxLength = 10;
				colvarIndicadorT.AutoIncrement = false;
				colvarIndicadorT.IsNullable = false;
				colvarIndicadorT.IsPrimaryKey = false;
				colvarIndicadorT.IsForeignKey = false;
				colvarIndicadorT.IsReadOnly = false;
				
						colvarIndicadorT.DefaultSetting = @"('')";
				colvarIndicadorT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIndicadorT);
				
				TableSchema.TableColumn colvarIndicadorN = new TableSchema.TableColumn(schema);
				colvarIndicadorN.ColumnName = "indicadorN";
				colvarIndicadorN.DataType = DbType.AnsiString;
				colvarIndicadorN.MaxLength = 10;
				colvarIndicadorN.AutoIncrement = false;
				colvarIndicadorN.IsNullable = false;
				colvarIndicadorN.IsPrimaryKey = false;
				colvarIndicadorN.IsForeignKey = false;
				colvarIndicadorN.IsReadOnly = false;
				
						colvarIndicadorN.DefaultSetting = @"('')";
				colvarIndicadorN.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIndicadorN);
				
				TableSchema.TableColumn colvarIndicadorM = new TableSchema.TableColumn(schema);
				colvarIndicadorM.ColumnName = "indicadorM";
				colvarIndicadorM.DataType = DbType.AnsiString;
				colvarIndicadorM.MaxLength = 10;
				colvarIndicadorM.AutoIncrement = false;
				colvarIndicadorM.IsNullable = false;
				colvarIndicadorM.IsPrimaryKey = false;
				colvarIndicadorM.IsForeignKey = false;
				colvarIndicadorM.IsReadOnly = false;
				
						colvarIndicadorM.DefaultSetting = @"('')";
				colvarIndicadorM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIndicadorM);
				
				TableSchema.TableColumn colvarIdMaterialIzq = new TableSchema.TableColumn(schema);
				colvarIdMaterialIzq.ColumnName = "idMaterialIzq";
				colvarIdMaterialIzq.DataType = DbType.Int32;
				colvarIdMaterialIzq.MaxLength = 0;
				colvarIdMaterialIzq.AutoIncrement = false;
				colvarIdMaterialIzq.IsNullable = false;
				colvarIdMaterialIzq.IsPrimaryKey = false;
				colvarIdMaterialIzq.IsForeignKey = true;
				colvarIdMaterialIzq.IsReadOnly = false;
				
						colvarIdMaterialIzq.DefaultSetting = @"((0))";
				
					colvarIdMaterialIzq.ForeignKeyTableName = "MAM_Material";
				schema.Columns.Add(colvarIdMaterialIzq);
				
				TableSchema.TableColumn colvarIdMaterialDer = new TableSchema.TableColumn(schema);
				colvarIdMaterialDer.ColumnName = "idMaterialDer";
				colvarIdMaterialDer.DataType = DbType.Int32;
				colvarIdMaterialDer.MaxLength = 0;
				colvarIdMaterialDer.AutoIncrement = false;
				colvarIdMaterialDer.IsNullable = false;
				colvarIdMaterialDer.IsPrimaryKey = false;
				colvarIdMaterialDer.IsForeignKey = true;
				colvarIdMaterialDer.IsReadOnly = false;
				
						colvarIdMaterialDer.DefaultSetting = @"((0))";
				
					colvarIdMaterialDer.ForeignKeyTableName = "MAM_Material";
				schema.Columns.Add(colvarIdMaterialDer);
				
				TableSchema.TableColumn colvarIdTipoCirugiaIzq = new TableSchema.TableColumn(schema);
				colvarIdTipoCirugiaIzq.ColumnName = "idTipoCirugiaIzq";
				colvarIdTipoCirugiaIzq.DataType = DbType.Int32;
				colvarIdTipoCirugiaIzq.MaxLength = 0;
				colvarIdTipoCirugiaIzq.AutoIncrement = false;
				colvarIdTipoCirugiaIzq.IsNullable = false;
				colvarIdTipoCirugiaIzq.IsPrimaryKey = false;
				colvarIdTipoCirugiaIzq.IsForeignKey = true;
				colvarIdTipoCirugiaIzq.IsReadOnly = false;
				
						colvarIdTipoCirugiaIzq.DefaultSetting = @"((0))";
				
					colvarIdTipoCirugiaIzq.ForeignKeyTableName = "MAM_TipoCirugia";
				schema.Columns.Add(colvarIdTipoCirugiaIzq);
				
				TableSchema.TableColumn colvarIdTipoCirugiaDer = new TableSchema.TableColumn(schema);
				colvarIdTipoCirugiaDer.ColumnName = "idTipoCirugiaDer";
				colvarIdTipoCirugiaDer.DataType = DbType.Int32;
				colvarIdTipoCirugiaDer.MaxLength = 0;
				colvarIdTipoCirugiaDer.AutoIncrement = false;
				colvarIdTipoCirugiaDer.IsNullable = false;
				colvarIdTipoCirugiaDer.IsPrimaryKey = false;
				colvarIdTipoCirugiaDer.IsForeignKey = true;
				colvarIdTipoCirugiaDer.IsReadOnly = false;
				
						colvarIdTipoCirugiaDer.DefaultSetting = @"((0))";
				
					colvarIdTipoCirugiaDer.ForeignKeyTableName = "MAM_TipoCirugia";
				schema.Columns.Add(colvarIdTipoCirugiaDer);
				
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
				DataService.Providers["sicProvider"].AddSchema("MAM_Cirugia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCirugia")]
		[Bindable(true)]
		public int IdCirugia 
		{
			get { return GetColumnValue<int>(Columns.IdCirugia); }
			set { SetColumnValue(Columns.IdCirugia, value); }
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
		  
		[XmlAttribute("IndicadorT")]
		[Bindable(true)]
		public string IndicadorT 
		{
			get { return GetColumnValue<string>(Columns.IndicadorT); }
			set { SetColumnValue(Columns.IndicadorT, value); }
		}
		  
		[XmlAttribute("IndicadorN")]
		[Bindable(true)]
		public string IndicadorN 
		{
			get { return GetColumnValue<string>(Columns.IndicadorN); }
			set { SetColumnValue(Columns.IndicadorN, value); }
		}
		  
		[XmlAttribute("IndicadorM")]
		[Bindable(true)]
		public string IndicadorM 
		{
			get { return GetColumnValue<string>(Columns.IndicadorM); }
			set { SetColumnValue(Columns.IndicadorM, value); }
		}
		  
		[XmlAttribute("IdMaterialIzq")]
		[Bindable(true)]
		public int IdMaterialIzq 
		{
			get { return GetColumnValue<int>(Columns.IdMaterialIzq); }
			set { SetColumnValue(Columns.IdMaterialIzq, value); }
		}
		  
		[XmlAttribute("IdMaterialDer")]
		[Bindable(true)]
		public int IdMaterialDer 
		{
			get { return GetColumnValue<int>(Columns.IdMaterialDer); }
			set { SetColumnValue(Columns.IdMaterialDer, value); }
		}
		  
		[XmlAttribute("IdTipoCirugiaIzq")]
		[Bindable(true)]
		public int IdTipoCirugiaIzq 
		{
			get { return GetColumnValue<int>(Columns.IdTipoCirugiaIzq); }
			set { SetColumnValue(Columns.IdTipoCirugiaIzq, value); }
		}
		  
		[XmlAttribute("IdTipoCirugiaDer")]
		[Bindable(true)]
		public int IdTipoCirugiaDer 
		{
			get { return GetColumnValue<int>(Columns.IdTipoCirugiaDer); }
			set { SetColumnValue(Columns.IdTipoCirugiaDer, value); }
		}
		  
		[XmlAttribute("IdCentroSalud")]
		[Bindable(true)]
		public int IdCentroSalud 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSalud); }
			set { SetColumnValue(Columns.IdCentroSalud, value); }
		}
		  
		[XmlAttribute("IdProfesionalResponsable")]
		[Bindable(true)]
		public int IdProfesionalResponsable 
		{
			get { return GetColumnValue<int>(Columns.IdProfesionalResponsable); }
			set { SetColumnValue(Columns.IdProfesionalResponsable, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
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
		/// Returns a SysEfector ActiveRecord object related to this MamCirugium
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSalud); }
			set { SetColumnValue("idCentroSalud", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamCirugium
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdProfesionalResponsable); }
			set { SetColumnValue("idProfesionalResponsable", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a MamTipoCirugium ActiveRecord object related to this MamCirugium
		/// 
		/// </summary>
		public DalSic.MamTipoCirugium MamTipoCirugium
		{
			get { return DalSic.MamTipoCirugium.FetchByID(this.IdTipoCirugiaDer); }
			set { SetColumnValue("idTipoCirugiaDer", value.IdTipoCirugia); }
		}
		
		
		/// <summary>
		/// Returns a MamTipoCirugium ActiveRecord object related to this MamCirugium
		/// 
		/// </summary>
		public DalSic.MamTipoCirugium MamTipoCirugiumToIdTipoCirugiaIzq
		{
			get { return DalSic.MamTipoCirugium.FetchByID(this.IdTipoCirugiaIzq); }
			set { SetColumnValue("idTipoCirugiaIzq", value.IdTipoCirugia); }
		}
		
		
		/// <summary>
		/// Returns a MamMaterial ActiveRecord object related to this MamCirugium
		/// 
		/// </summary>
		public DalSic.MamMaterial MamMaterial
		{
			get { return DalSic.MamMaterial.FetchByID(this.IdMaterialDer); }
			set { SetColumnValue("idMaterialDer", value.IdMaterial); }
		}
		
		
		/// <summary>
		/// Returns a MamMaterial ActiveRecord object related to this MamCirugium
		/// 
		/// </summary>
		public DalSic.MamMaterial MamMaterialToIdMaterialIzq
		{
			get { return DalSic.MamMaterial.FetchByID(this.IdMaterialIzq); }
			set { SetColumnValue("idMaterialIzq", value.IdMaterial); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,DateTime varFecha,int varEdad,string varIndicadorT,string varIndicadorN,string varIndicadorM,int varIdMaterialIzq,int varIdMaterialDer,int varIdTipoCirugiaIzq,int varIdTipoCirugiaDer,int varIdCentroSalud,int varIdProfesionalResponsable,string varObservacion,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamCirugium item = new MamCirugium();
			
			item.IdPaciente = varIdPaciente;
			
			item.Fecha = varFecha;
			
			item.Edad = varEdad;
			
			item.IndicadorT = varIndicadorT;
			
			item.IndicadorN = varIndicadorN;
			
			item.IndicadorM = varIndicadorM;
			
			item.IdMaterialIzq = varIdMaterialIzq;
			
			item.IdMaterialDer = varIdMaterialDer;
			
			item.IdTipoCirugiaIzq = varIdTipoCirugiaIzq;
			
			item.IdTipoCirugiaDer = varIdTipoCirugiaDer;
			
			item.IdCentroSalud = varIdCentroSalud;
			
			item.IdProfesionalResponsable = varIdProfesionalResponsable;
			
			item.Observacion = varObservacion;
			
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
		public static void Update(int varIdCirugia,int varIdPaciente,DateTime varFecha,int varEdad,string varIndicadorT,string varIndicadorN,string varIndicadorM,int varIdMaterialIzq,int varIdMaterialDer,int varIdTipoCirugiaIzq,int varIdTipoCirugiaDer,int varIdCentroSalud,int varIdProfesionalResponsable,string varObservacion,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamCirugium item = new MamCirugium();
			
				item.IdCirugia = varIdCirugia;
			
				item.IdPaciente = varIdPaciente;
			
				item.Fecha = varFecha;
			
				item.Edad = varEdad;
			
				item.IndicadorT = varIndicadorT;
			
				item.IndicadorN = varIndicadorN;
			
				item.IndicadorM = varIndicadorM;
			
				item.IdMaterialIzq = varIdMaterialIzq;
			
				item.IdMaterialDer = varIdMaterialDer;
			
				item.IdTipoCirugiaIzq = varIdTipoCirugiaIzq;
			
				item.IdTipoCirugiaDer = varIdTipoCirugiaDer;
			
				item.IdCentroSalud = varIdCentroSalud;
			
				item.IdProfesionalResponsable = varIdProfesionalResponsable;
			
				item.Observacion = varObservacion;
			
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
        
        
        public static TableSchema.TableColumn IdCirugiaColumn
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
        
        
        
        public static TableSchema.TableColumn IndicadorTColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IndicadorNColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IndicadorMColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMaterialIzqColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMaterialDerColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoCirugiaIzqColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoCirugiaDerColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalResponsableColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCirugia = @"idCirugia";
			 public static string IdPaciente = @"idPaciente";
			 public static string Fecha = @"fecha";
			 public static string Edad = @"edad";
			 public static string IndicadorT = @"indicadorT";
			 public static string IndicadorN = @"indicadorN";
			 public static string IndicadorM = @"indicadorM";
			 public static string IdMaterialIzq = @"idMaterialIzq";
			 public static string IdMaterialDer = @"idMaterialDer";
			 public static string IdTipoCirugiaIzq = @"idTipoCirugiaIzq";
			 public static string IdTipoCirugiaDer = @"idTipoCirugiaDer";
			 public static string IdCentroSalud = @"idCentroSalud";
			 public static string IdProfesionalResponsable = @"idProfesionalResponsable";
			 public static string Observacion = @"observacion";
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
