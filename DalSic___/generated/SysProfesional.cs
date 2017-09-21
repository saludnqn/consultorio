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
	/// Strongly-typed collection for the SysProfesional class.
	/// </summary>
    [Serializable]
	public partial class SysProfesionalCollection : ActiveList<SysProfesional, SysProfesionalCollection>
	{	   
		public SysProfesionalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysProfesionalCollection</returns>
		public SysProfesionalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysProfesional o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Profesional table.
	/// </summary>
	[Serializable]
	public partial class SysProfesional : ActiveRecord<SysProfesional>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysProfesional()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysProfesional(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysProfesional(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysProfesional(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Profesional", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = true;
				colvarIdProfesional.IsNullable = false;
				colvarIdProfesional.IsPrimaryKey = true;
				colvarIdProfesional.IsForeignKey = false;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				colvarIdProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProfesional);
				
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
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.String;
				colvarApellido.MaxLength = 50;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = false;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdTipoDocumento = new TableSchema.TableColumn(schema);
				colvarIdTipoDocumento.ColumnName = "idTipoDocumento";
				colvarIdTipoDocumento.DataType = DbType.Int32;
				colvarIdTipoDocumento.MaxLength = 0;
				colvarIdTipoDocumento.AutoIncrement = false;
				colvarIdTipoDocumento.IsNullable = false;
				colvarIdTipoDocumento.IsPrimaryKey = false;
				colvarIdTipoDocumento.IsForeignKey = true;
				colvarIdTipoDocumento.IsReadOnly = false;
				colvarIdTipoDocumento.DefaultSetting = @"";
				
					colvarIdTipoDocumento.ForeignKeyTableName = "Sys_TipoDocumento";
				schema.Columns.Add(colvarIdTipoDocumento);
				
				TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
				colvarNumeroDocumento.ColumnName = "numeroDocumento";
				colvarNumeroDocumento.DataType = DbType.Int32;
				colvarNumeroDocumento.MaxLength = 0;
				colvarNumeroDocumento.AutoIncrement = false;
				colvarNumeroDocumento.IsNullable = false;
				colvarNumeroDocumento.IsPrimaryKey = false;
				colvarNumeroDocumento.IsForeignKey = false;
				colvarNumeroDocumento.IsReadOnly = false;
				colvarNumeroDocumento.DefaultSetting = @"";
				colvarNumeroDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDocumento);
				
				TableSchema.TableColumn colvarMatricula = new TableSchema.TableColumn(schema);
				colvarMatricula.ColumnName = "matricula";
				colvarMatricula.DataType = DbType.String;
				colvarMatricula.MaxLength = 20;
				colvarMatricula.AutoIncrement = false;
				colvarMatricula.IsNullable = false;
				colvarMatricula.IsPrimaryKey = false;
				colvarMatricula.IsForeignKey = false;
				colvarMatricula.IsReadOnly = false;
				
						colvarMatricula.DefaultSetting = @"((0))";
				colvarMatricula.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMatricula);
				
				TableSchema.TableColumn colvarLegajo = new TableSchema.TableColumn(schema);
				colvarLegajo.ColumnName = "legajo";
				colvarLegajo.DataType = DbType.AnsiString;
				colvarLegajo.MaxLength = 10;
				colvarLegajo.AutoIncrement = false;
				colvarLegajo.IsNullable = false;
				colvarLegajo.IsPrimaryKey = false;
				colvarLegajo.IsForeignKey = false;
				colvarLegajo.IsReadOnly = false;
				
						colvarLegajo.DefaultSetting = @"('')";
				colvarLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLegajo);
				
				TableSchema.TableColumn colvarCodigoSISA = new TableSchema.TableColumn(schema);
				colvarCodigoSISA.ColumnName = "codigoSISA";
				colvarCodigoSISA.DataType = DbType.AnsiString;
				colvarCodigoSISA.MaxLength = 20;
				colvarCodigoSISA.AutoIncrement = false;
				colvarCodigoSISA.IsNullable = false;
				colvarCodigoSISA.IsPrimaryKey = false;
				colvarCodigoSISA.IsForeignKey = false;
				colvarCodigoSISA.IsReadOnly = false;
				
						colvarCodigoSISA.DefaultSetting = @"('')";
				colvarCodigoSISA.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoSISA);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarNombreCompleto = new TableSchema.TableColumn(schema);
				colvarNombreCompleto.ColumnName = "NombreCompleto";
				colvarNombreCompleto.DataType = DbType.String;
				colvarNombreCompleto.MaxLength = 102;
				colvarNombreCompleto.AutoIncrement = false;
				colvarNombreCompleto.IsNullable = false;
				colvarNombreCompleto.IsPrimaryKey = false;
				colvarNombreCompleto.IsForeignKey = false;
				colvarNombreCompleto.IsReadOnly = true;
				colvarNombreCompleto.DefaultSetting = @"";
				colvarNombreCompleto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreCompleto);
				
				TableSchema.TableColumn colvarApellidoyNombre = new TableSchema.TableColumn(schema);
				colvarApellidoyNombre.ColumnName = "ApellidoyNombre";
				colvarApellidoyNombre.DataType = DbType.String;
				colvarApellidoyNombre.MaxLength = 102;
				colvarApellidoyNombre.AutoIncrement = false;
				colvarApellidoyNombre.IsNullable = false;
				colvarApellidoyNombre.IsPrimaryKey = false;
				colvarApellidoyNombre.IsForeignKey = false;
				colvarApellidoyNombre.IsReadOnly = true;
				colvarApellidoyNombre.DefaultSetting = @"";
				colvarApellidoyNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoyNombre);
				
				TableSchema.TableColumn colvarIdTipoProfesional = new TableSchema.TableColumn(schema);
				colvarIdTipoProfesional.ColumnName = "idTipoProfesional";
				colvarIdTipoProfesional.DataType = DbType.Int32;
				colvarIdTipoProfesional.MaxLength = 0;
				colvarIdTipoProfesional.AutoIncrement = false;
				colvarIdTipoProfesional.IsNullable = false;
				colvarIdTipoProfesional.IsPrimaryKey = false;
				colvarIdTipoProfesional.IsForeignKey = true;
				colvarIdTipoProfesional.IsReadOnly = false;
				
						colvarIdTipoProfesional.DefaultSetting = @"((0))";
				
					colvarIdTipoProfesional.ForeignKeyTableName = "Sys_TipoProfesional";
				schema.Columns.Add(colvarIdTipoProfesional);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "fechaModificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = false;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				colvarFechaModificacion.DefaultSetting = @"";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				TableSchema.TableColumn colvarMail = new TableSchema.TableColumn(schema);
				colvarMail.ColumnName = "mail";
				colvarMail.DataType = DbType.AnsiString;
				colvarMail.MaxLength = 100;
				colvarMail.AutoIncrement = false;
				colvarMail.IsNullable = true;
				colvarMail.IsPrimaryKey = false;
				colvarMail.IsForeignKey = false;
				colvarMail.IsReadOnly = false;
				colvarMail.DefaultSetting = @"";
				colvarMail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMail);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = 50;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
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
				DataService.Providers["sicProvider"].AddSchema("Sys_Profesional",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int IdProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdTipoDocumento")]
		[Bindable(true)]
		public int IdTipoDocumento 
		{
			get { return GetColumnValue<int>(Columns.IdTipoDocumento); }
			set { SetColumnValue(Columns.IdTipoDocumento, value); }
		}
		  
		[XmlAttribute("NumeroDocumento")]
		[Bindable(true)]
		public int NumeroDocumento 
		{
			get { return GetColumnValue<int>(Columns.NumeroDocumento); }
			set { SetColumnValue(Columns.NumeroDocumento, value); }
		}
		  
		[XmlAttribute("Matricula")]
		[Bindable(true)]
		public string Matricula 
		{
			get { return GetColumnValue<string>(Columns.Matricula); }
			set { SetColumnValue(Columns.Matricula, value); }
		}
		  
		[XmlAttribute("Legajo")]
		[Bindable(true)]
		public string Legajo 
		{
			get { return GetColumnValue<string>(Columns.Legajo); }
			set { SetColumnValue(Columns.Legajo, value); }
		}
		  
		[XmlAttribute("CodigoSISA")]
		[Bindable(true)]
		public string CodigoSISA 
		{
			get { return GetColumnValue<string>(Columns.CodigoSISA); }
			set { SetColumnValue(Columns.CodigoSISA, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("NombreCompleto")]
		[Bindable(true)]
		public string NombreCompleto 
		{
			get { return GetColumnValue<string>(Columns.NombreCompleto); }
			set { SetColumnValue(Columns.NombreCompleto, value); }
		}
		  
		[XmlAttribute("ApellidoyNombre")]
		[Bindable(true)]
		public string ApellidoyNombre 
		{
			get { return GetColumnValue<string>(Columns.ApellidoyNombre); }
			set { SetColumnValue(Columns.ApellidoyNombre, value); }
		}
		  
		[XmlAttribute("IdTipoProfesional")]
		[Bindable(true)]
		public int IdTipoProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdTipoProfesional); }
			set { SetColumnValue(Columns.IdTipoProfesional, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime FechaModificacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("Mail")]
		[Bindable(true)]
		public string Mail 
		{
			get { return GetColumnValue<string>(Columns.Mail); }
			set { SetColumnValue(Columns.Mail, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
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
        
				
		private DalSic.TabControlCollection colTabControlRecords;
		public DalSic.TabControlCollection TabControlRecords
		{
			get
			{
				if(colTabControlRecords == null)
				{
					colTabControlRecords = new DalSic.TabControlCollection().Where(TabControl.Columns.IdProfesional, IdProfesional).Load();
					colTabControlRecords.ListChanged += new ListChangedEventHandler(colTabControlRecords_ListChanged);
				}
				return colTabControlRecords;			
			}
			set 
			{ 
					colTabControlRecords = value; 
					colTabControlRecords.ListChanged += new ListChangedEventHandler(colTabControlRecords_ListChanged);
			}
		}
		
		void colTabControlRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colTabControlRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamEstudiosHospitalProvincialCollection colMamEstudiosHospitalProvincialRecords;
		public DalSic.MamEstudiosHospitalProvincialCollection MamEstudiosHospitalProvincialRecords
		{
			get
			{
				if(colMamEstudiosHospitalProvincialRecords == null)
				{
					colMamEstudiosHospitalProvincialRecords = new DalSic.MamEstudiosHospitalProvincialCollection().Where(MamEstudiosHospitalProvincial.Columns.SolicitudProfesional, IdProfesional).Load();
					colMamEstudiosHospitalProvincialRecords.ListChanged += new ListChangedEventHandler(colMamEstudiosHospitalProvincialRecords_ListChanged);
				}
				return colMamEstudiosHospitalProvincialRecords;			
			}
			set 
			{ 
					colMamEstudiosHospitalProvincialRecords = value; 
					colMamEstudiosHospitalProvincialRecords.ListChanged += new ListChangedEventHandler(colMamEstudiosHospitalProvincialRecords_ListChanged);
			}
		}
		
		void colMamEstudiosHospitalProvincialRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosHospitalProvincialRecords[e.NewIndex].SolicitudProfesional = IdProfesional;
		    }
		}
				
		private DalSic.AprControlOdontologicoCollection colAprControlOdontologicoRecords;
		public DalSic.AprControlOdontologicoCollection AprControlOdontologicoRecords
		{
			get
			{
				if(colAprControlOdontologicoRecords == null)
				{
					colAprControlOdontologicoRecords = new DalSic.AprControlOdontologicoCollection().Where(AprControlOdontologico.Columns.IdProfesional, IdProfesional).Load();
					colAprControlOdontologicoRecords.ListChanged += new ListChangedEventHandler(colAprControlOdontologicoRecords_ListChanged);
				}
				return colAprControlOdontologicoRecords;			
			}
			set 
			{ 
					colAprControlOdontologicoRecords = value; 
					colAprControlOdontologicoRecords.ListChanged += new ListChangedEventHandler(colAprControlOdontologicoRecords_ListChanged);
			}
		}
		
		void colAprControlOdontologicoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlOdontologicoRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.AprPartoProvisorioCollection colAprPartoProvisorioRecords;
		public DalSic.AprPartoProvisorioCollection AprPartoProvisorioRecords
		{
			get
			{
				if(colAprPartoProvisorioRecords == null)
				{
					colAprPartoProvisorioRecords = new DalSic.AprPartoProvisorioCollection().Where(AprPartoProvisorio.Columns.IdProfesional, IdProfesional).Load();
					colAprPartoProvisorioRecords.ListChanged += new ListChangedEventHandler(colAprPartoProvisorioRecords_ListChanged);
				}
				return colAprPartoProvisorioRecords;			
			}
			set 
			{ 
					colAprPartoProvisorioRecords = value; 
					colAprPartoProvisorioRecords.ListChanged += new ListChangedEventHandler(colAprPartoProvisorioRecords_ListChanged);
			}
		}
		
		void colAprPartoProvisorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprPartoProvisorioRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.RemFormularioCollection colRemFormularioRecords;
		public DalSic.RemFormularioCollection RemFormularioRecords
		{
			get
			{
				if(colRemFormularioRecords == null)
				{
					colRemFormularioRecords = new DalSic.RemFormularioCollection().Where(RemFormulario.Columns.IdProfesional, IdProfesional).Load();
					colRemFormularioRecords.ListChanged += new ListChangedEventHandler(colRemFormularioRecords_ListChanged);
				}
				return colRemFormularioRecords;			
			}
			set 
			{ 
					colRemFormularioRecords = value; 
					colRemFormularioRecords.ListChanged += new ListChangedEventHandler(colRemFormularioRecords_ListChanged);
			}
		}
		
		void colRemFormularioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemFormularioRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.AprInterconsultumCollection colAprInterconsulta;
		public DalSic.AprInterconsultumCollection AprInterconsulta
		{
			get
			{
				if(colAprInterconsulta == null)
				{
					colAprInterconsulta = new DalSic.AprInterconsultumCollection().Where(AprInterconsultum.Columns.IdProfesional, IdProfesional).Load();
					colAprInterconsulta.ListChanged += new ListChangedEventHandler(colAprInterconsulta_ListChanged);
				}
				return colAprInterconsulta;			
			}
			set 
			{ 
					colAprInterconsulta = value; 
					colAprInterconsulta.ListChanged += new ListChangedEventHandler(colAprInterconsulta_ListChanged);
			}
		}
		
		void colAprInterconsulta_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprInterconsulta[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamCirugiumCollection colMamCirugia;
		public DalSic.MamCirugiumCollection MamCirugia
		{
			get
			{
				if(colMamCirugia == null)
				{
					colMamCirugia = new DalSic.MamCirugiumCollection().Where(MamCirugium.Columns.IdProfesionalResponsable, IdProfesional).Load();
					colMamCirugia.ListChanged += new ListChangedEventHandler(colMamCirugia_ListChanged);
				}
				return colMamCirugia;			
			}
			set 
			{ 
					colMamCirugia = value; 
					colMamCirugia.ListChanged += new ListChangedEventHandler(colMamCirugia_ListChanged);
			}
		}
		
		void colMamCirugia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamCirugia[e.NewIndex].IdProfesionalResponsable = IdProfesional;
		    }
		}
				
		private DalSic.ConAgendaCollection colConAgendaRecords;
		public DalSic.ConAgendaCollection ConAgendaRecords
		{
			get
			{
				if(colConAgendaRecords == null)
				{
					colConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdProfesional, IdProfesional).Load();
					colConAgendaRecords.ListChanged += new ListChangedEventHandler(colConAgendaRecords_ListChanged);
				}
				return colConAgendaRecords;			
			}
			set 
			{ 
					colConAgendaRecords = value; 
					colConAgendaRecords.ListChanged += new ListChangedEventHandler(colConAgendaRecords_ListChanged);
			}
		}
		
		void colConAgendaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.ConAgendaGrupalProfesionalCollection colConAgendaGrupalProfesionalRecords;
		public DalSic.ConAgendaGrupalProfesionalCollection ConAgendaGrupalProfesionalRecords
		{
			get
			{
				if(colConAgendaGrupalProfesionalRecords == null)
				{
					colConAgendaGrupalProfesionalRecords = new DalSic.ConAgendaGrupalProfesionalCollection().Where(ConAgendaGrupalProfesional.Columns.IdProfesional, IdProfesional).Load();
					colConAgendaGrupalProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalProfesionalRecords_ListChanged);
				}
				return colConAgendaGrupalProfesionalRecords;			
			}
			set 
			{ 
					colConAgendaGrupalProfesionalRecords = value; 
					colConAgendaGrupalProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalProfesionalRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalProfesionalRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamAnatomiaPatologicaCollection colMamAnatomiaPatologicaRecords;
		public DalSic.MamAnatomiaPatologicaCollection MamAnatomiaPatologicaRecords
		{
			get
			{
				if(colMamAnatomiaPatologicaRecords == null)
				{
					colMamAnatomiaPatologicaRecords = new DalSic.MamAnatomiaPatologicaCollection().Where(MamAnatomiaPatologica.Columns.IdResponsableMuestra, IdProfesional).Load();
					colMamAnatomiaPatologicaRecords.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecords_ListChanged);
				}
				return colMamAnatomiaPatologicaRecords;			
			}
			set 
			{ 
					colMamAnatomiaPatologicaRecords = value; 
					colMamAnatomiaPatologicaRecords.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecords_ListChanged);
			}
		}
		
		void colMamAnatomiaPatologicaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamAnatomiaPatologicaRecords[e.NewIndex].IdResponsableMuestra = IdProfesional;
		    }
		}
				
		private DalSic.FacJefeLaboratorioCollection colFacJefeLaboratorioRecords;
		public DalSic.FacJefeLaboratorioCollection FacJefeLaboratorioRecords
		{
			get
			{
				if(colFacJefeLaboratorioRecords == null)
				{
					colFacJefeLaboratorioRecords = new DalSic.FacJefeLaboratorioCollection().Where(FacJefeLaboratorio.Columns.IdProfesional, IdProfesional).Load();
					colFacJefeLaboratorioRecords.ListChanged += new ListChangedEventHandler(colFacJefeLaboratorioRecords_ListChanged);
				}
				return colFacJefeLaboratorioRecords;			
			}
			set 
			{ 
					colFacJefeLaboratorioRecords = value; 
					colFacJefeLaboratorioRecords.ListChanged += new ListChangedEventHandler(colFacJefeLaboratorioRecords_ListChanged);
			}
		}
		
		void colFacJefeLaboratorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colFacJefeLaboratorioRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamAnatomiaPatologicaCollection colMamAnatomiaPatologicaRecordsFromSysProfesional;
		public DalSic.MamAnatomiaPatologicaCollection MamAnatomiaPatologicaRecordsFromSysProfesional
		{
			get
			{
				if(colMamAnatomiaPatologicaRecordsFromSysProfesional == null)
				{
					colMamAnatomiaPatologicaRecordsFromSysProfesional = new DalSic.MamAnatomiaPatologicaCollection().Where(MamAnatomiaPatologica.Columns.IdResponsableInforme, IdProfesional).Load();
					colMamAnatomiaPatologicaRecordsFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecordsFromSysProfesional_ListChanged);
				}
				return colMamAnatomiaPatologicaRecordsFromSysProfesional;			
			}
			set 
			{ 
					colMamAnatomiaPatologicaRecordsFromSysProfesional = value; 
					colMamAnatomiaPatologicaRecordsFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecordsFromSysProfesional_ListChanged);
			}
		}
		
		void colMamAnatomiaPatologicaRecordsFromSysProfesional_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamAnatomiaPatologicaRecordsFromSysProfesional[e.NewIndex].IdResponsableInforme = IdProfesional;
		    }
		}
				
		private DalSic.RemClasificacionCollection colRemClasificacionRecords;
		public DalSic.RemClasificacionCollection RemClasificacionRecords
		{
			get
			{
				if(colRemClasificacionRecords == null)
				{
					colRemClasificacionRecords = new DalSic.RemClasificacionCollection().Where(RemClasificacion.Columns.IdProfesional, IdProfesional).Load();
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
		        colRemClasificacionRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamPiezaQuirurgicaCollection colMamPiezaQuirurgicaRecords;
		public DalSic.MamPiezaQuirurgicaCollection MamPiezaQuirurgicaRecords
		{
			get
			{
				if(colMamPiezaQuirurgicaRecords == null)
				{
					colMamPiezaQuirurgicaRecords = new DalSic.MamPiezaQuirurgicaCollection().Where(MamPiezaQuirurgica.Columns.IdResponsableInforme, IdProfesional).Load();
					colMamPiezaQuirurgicaRecords.ListChanged += new ListChangedEventHandler(colMamPiezaQuirurgicaRecords_ListChanged);
				}
				return colMamPiezaQuirurgicaRecords;			
			}
			set 
			{ 
					colMamPiezaQuirurgicaRecords = value; 
					colMamPiezaQuirurgicaRecords.ListChanged += new ListChangedEventHandler(colMamPiezaQuirurgicaRecords_ListChanged);
			}
		}
		
		void colMamPiezaQuirurgicaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamPiezaQuirurgicaRecords[e.NewIndex].IdResponsableInforme = IdProfesional;
		    }
		}
				
		private DalSic.AprActividadControlPerinatalCollection colAprActividadControlPerinatalRecords;
		public DalSic.AprActividadControlPerinatalCollection AprActividadControlPerinatalRecords
		{
			get
			{
				if(colAprActividadControlPerinatalRecords == null)
				{
					colAprActividadControlPerinatalRecords = new DalSic.AprActividadControlPerinatalCollection().Where(AprActividadControlPerinatal.Columns.IdProfesional, IdProfesional).Load();
					colAprActividadControlPerinatalRecords.ListChanged += new ListChangedEventHandler(colAprActividadControlPerinatalRecords_ListChanged);
				}
				return colAprActividadControlPerinatalRecords;			
			}
			set 
			{ 
					colAprActividadControlPerinatalRecords = value; 
					colAprActividadControlPerinatalRecords.ListChanged += new ListChangedEventHandler(colAprActividadControlPerinatalRecords_ListChanged);
			}
		}
		
		void colAprActividadControlPerinatalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprActividadControlPerinatalRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionales;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionales
		{
			get
			{
				if(colMamEstudiosAdicionales == null)
				{
					colMamEstudiosAdicionales = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdProfesionalResponsable, IdProfesional).Load();
					colMamEstudiosAdicionales.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionales_ListChanged);
				}
				return colMamEstudiosAdicionales;			
			}
			set 
			{ 
					colMamEstudiosAdicionales = value; 
					colMamEstudiosAdicionales.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionales_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionales_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionales[e.NewIndex].IdProfesionalResponsable = IdProfesional;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografia;
		public DalSic.MamEcografiumCollection MamEcografia
		{
			get
			{
				if(colMamEcografia == null)
				{
					colMamEcografia = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdProfesionalTecnico, IdProfesional).Load();
					colMamEcografia.ListChanged += new ListChangedEventHandler(colMamEcografia_ListChanged);
				}
				return colMamEcografia;			
			}
			set 
			{ 
					colMamEcografia = value; 
					colMamEcografia.ListChanged += new ListChangedEventHandler(colMamEcografia_ListChanged);
			}
		}
		
		void colMamEcografia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografia[e.NewIndex].IdProfesionalTecnico = IdProfesional;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografiaFromSysProfesional;
		public DalSic.MamEcografiumCollection MamEcografiaFromSysProfesional
		{
			get
			{
				if(colMamEcografiaFromSysProfesional == null)
				{
					colMamEcografiaFromSysProfesional = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdProfesionalSolicita, IdProfesional).Load();
					colMamEcografiaFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysProfesional_ListChanged);
				}
				return colMamEcografiaFromSysProfesional;			
			}
			set 
			{ 
					colMamEcografiaFromSysProfesional = value; 
					colMamEcografiaFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysProfesional_ListChanged);
			}
		}
		
		void colMamEcografiaFromSysProfesional_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografiaFromSysProfesional[e.NewIndex].IdProfesionalSolicita = IdProfesional;
		    }
		}
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionalesFromSysProfesional;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionalesFromSysProfesional
		{
			get
			{
				if(colMamEstudiosAdicionalesFromSysProfesional == null)
				{
					colMamEstudiosAdicionalesFromSysProfesional = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdProfesionalTecnico, IdProfesional).Load();
					colMamEstudiosAdicionalesFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromSysProfesional_ListChanged);
				}
				return colMamEstudiosAdicionalesFromSysProfesional;			
			}
			set 
			{ 
					colMamEstudiosAdicionalesFromSysProfesional = value; 
					colMamEstudiosAdicionalesFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromSysProfesional_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionalesFromSysProfesional_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionalesFromSysProfesional[e.NewIndex].IdProfesionalTecnico = IdProfesional;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecords;
		public DalSic.MamRegistroCollection MamRegistroRecords
		{
			get
			{
				if(colMamRegistroRecords == null)
				{
					colMamRegistroRecords = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdProfesionalTecnico, IdProfesional).Load();
					colMamRegistroRecords.ListChanged += new ListChangedEventHandler(colMamRegistroRecords_ListChanged);
				}
				return colMamRegistroRecords;			
			}
			set 
			{ 
					colMamRegistroRecords = value; 
					colMamRegistroRecords.ListChanged += new ListChangedEventHandler(colMamRegistroRecords_ListChanged);
			}
		}
		
		void colMamRegistroRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecords[e.NewIndex].IdProfesionalTecnico = IdProfesional;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecordsFromSysProfesional;
		public DalSic.MamRegistroCollection MamRegistroRecordsFromSysProfesional
		{
			get
			{
				if(colMamRegistroRecordsFromSysProfesional == null)
				{
					colMamRegistroRecordsFromSysProfesional = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdProfesionalSolicita, IdProfesional).Load();
					colMamRegistroRecordsFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysProfesional_ListChanged);
				}
				return colMamRegistroRecordsFromSysProfesional;			
			}
			set 
			{ 
					colMamRegistroRecordsFromSysProfesional = value; 
					colMamRegistroRecordsFromSysProfesional.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysProfesional_ListChanged);
			}
		}
		
		void colMamRegistroRecordsFromSysProfesional_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecordsFromSysProfesional[e.NewIndex].IdProfesionalSolicita = IdProfesional;
		    }
		}
				
		private DalSic.AprActividadFisicaCollection colAprActividadFisicaRecords;
		public DalSic.AprActividadFisicaCollection AprActividadFisicaRecords
		{
			get
			{
				if(colAprActividadFisicaRecords == null)
				{
					colAprActividadFisicaRecords = new DalSic.AprActividadFisicaCollection().Where(AprActividadFisica.Columns.IdProfesional, IdProfesional).Load();
					colAprActividadFisicaRecords.ListChanged += new ListChangedEventHandler(colAprActividadFisicaRecords_ListChanged);
				}
				return colAprActividadFisicaRecords;			
			}
			set 
			{ 
					colAprActividadFisicaRecords = value; 
					colAprActividadFisicaRecords.ListChanged += new ListChangedEventHandler(colAprActividadFisicaRecords_ListChanged);
			}
		}
		
		void colAprActividadFisicaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprActividadFisicaRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.ConConsultumCollection colConConsulta;
		public DalSic.ConConsultumCollection ConConsulta
		{
			get
			{
				if(colConConsulta == null)
				{
					colConConsulta = new DalSic.ConConsultumCollection().Where(ConConsultum.Columns.IdProfesional, IdProfesional).Load();
					colConConsulta.ListChanged += new ListChangedEventHandler(colConConsulta_ListChanged);
				}
				return colConConsulta;			
			}
			set 
			{ 
					colConConsulta = value; 
					colConConsulta.ListChanged += new ListChangedEventHandler(colConConsulta_ListChanged);
			}
		}
		
		void colConConsulta_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsulta[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografiaFromSysProfesionalIdProfesionalResponsable;
		public DalSic.MamEcografiumCollection MamEcografiaFromSysProfesionalIdProfesionalResponsable
		{
			get
			{
				if(colMamEcografiaFromSysProfesionalIdProfesionalResponsable == null)
				{
					colMamEcografiaFromSysProfesionalIdProfesionalResponsable = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdProfesionalResponsable, IdProfesional).Load();
					colMamEcografiaFromSysProfesionalIdProfesionalResponsable.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysProfesionalIdProfesionalResponsable_ListChanged);
				}
				return colMamEcografiaFromSysProfesionalIdProfesionalResponsable;			
			}
			set 
			{ 
					colMamEcografiaFromSysProfesionalIdProfesionalResponsable = value; 
					colMamEcografiaFromSysProfesionalIdProfesionalResponsable.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysProfesionalIdProfesionalResponsable_ListChanged);
			}
		}
		
		void colMamEcografiaFromSysProfesionalIdProfesionalResponsable_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografiaFromSysProfesionalIdProfesionalResponsable[e.NewIndex].IdProfesionalResponsable = IdProfesional;
		    }
		}
				
		private DalSic.MamEstadioClinicoCollection colMamEstadioClinicoRecords;
		public DalSic.MamEstadioClinicoCollection MamEstadioClinicoRecords
		{
			get
			{
				if(colMamEstadioClinicoRecords == null)
				{
					colMamEstadioClinicoRecords = new DalSic.MamEstadioClinicoCollection().Where(MamEstadioClinico.Columns.IdProfesional, IdProfesional).Load();
					colMamEstadioClinicoRecords.ListChanged += new ListChangedEventHandler(colMamEstadioClinicoRecords_ListChanged);
				}
				return colMamEstadioClinicoRecords;			
			}
			set 
			{ 
					colMamEstadioClinicoRecords = value; 
					colMamEstadioClinicoRecords.ListChanged += new ListChangedEventHandler(colMamEstadioClinicoRecords_ListChanged);
			}
		}
		
		void colMamEstadioClinicoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstadioClinicoRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamExamenFisicoCollection colMamExamenFisicoRecords;
		public DalSic.MamExamenFisicoCollection MamExamenFisicoRecords
		{
			get
			{
				if(colMamExamenFisicoRecords == null)
				{
					colMamExamenFisicoRecords = new DalSic.MamExamenFisicoCollection().Where(MamExamenFisico.Columns.IdResponsableExamen, IdProfesional).Load();
					colMamExamenFisicoRecords.ListChanged += new ListChangedEventHandler(colMamExamenFisicoRecords_ListChanged);
				}
				return colMamExamenFisicoRecords;			
			}
			set 
			{ 
					colMamExamenFisicoRecords = value; 
					colMamExamenFisicoRecords.ListChanged += new ListChangedEventHandler(colMamExamenFisicoRecords_ListChanged);
			}
		}
		
		void colMamExamenFisicoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamExamenFisicoRecords[e.NewIndex].IdResponsableExamen = IdProfesional;
		    }
		}
				
		private DalSic.AprControlNiñoSanoEnfermeriumCollection colAprControlNiñoSanoEnfermeria;
		public DalSic.AprControlNiñoSanoEnfermeriumCollection AprControlNiñoSanoEnfermeria
		{
			get
			{
				if(colAprControlNiñoSanoEnfermeria == null)
				{
					colAprControlNiñoSanoEnfermeria = new DalSic.AprControlNiñoSanoEnfermeriumCollection().Where(AprControlNiñoSanoEnfermerium.Columns.IdProfesional, IdProfesional).Load();
					colAprControlNiñoSanoEnfermeria.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoEnfermeria_ListChanged);
				}
				return colAprControlNiñoSanoEnfermeria;			
			}
			set 
			{ 
					colAprControlNiñoSanoEnfermeria = value; 
					colAprControlNiñoSanoEnfermeria.ListChanged += new ListChangedEventHandler(colAprControlNiñoSanoEnfermeria_ListChanged);
			}
		}
		
		void colAprControlNiñoSanoEnfermeria_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprControlNiñoSanoEnfermeria[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.ConAgendaProfesionalCollection colConAgendaProfesionalRecords;
		public DalSic.ConAgendaProfesionalCollection ConAgendaProfesionalRecords
		{
			get
			{
				if(colConAgendaProfesionalRecords == null)
				{
					colConAgendaProfesionalRecords = new DalSic.ConAgendaProfesionalCollection().Where(ConAgendaProfesional.Columns.IdProfesional, IdProfesional).Load();
					colConAgendaProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaProfesionalRecords_ListChanged);
				}
				return colConAgendaProfesionalRecords;			
			}
			set 
			{ 
					colConAgendaProfesionalRecords = value; 
					colConAgendaProfesionalRecords.ListChanged += new ListChangedEventHandler(colConAgendaProfesionalRecords_ListChanged);
			}
		}
		
		void colConAgendaProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaProfesionalRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.MamTratamientoCollection colMamTratamientos;
		public DalSic.MamTratamientoCollection MamTratamientos
		{
			get
			{
				if(colMamTratamientos == null)
				{
					colMamTratamientos = new DalSic.MamTratamientoCollection().Where(MamTratamiento.Columns.IdResponsableExamen, IdProfesional).Load();
					colMamTratamientos.ListChanged += new ListChangedEventHandler(colMamTratamientos_ListChanged);
				}
				return colMamTratamientos;			
			}
			set 
			{ 
					colMamTratamientos = value; 
					colMamTratamientos.ListChanged += new ListChangedEventHandler(colMamTratamientos_ListChanged);
			}
		}
		
		void colMamTratamientos_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamTratamientos[e.NewIndex].IdResponsableExamen = IdProfesional;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma;
		public DalSic.MamRegistroCollection MamRegistroRecordsFromSysProfesionalIdProfesionalInforma
		{
			get
			{
				if(colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma == null)
				{
					colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdProfesionalInforma, IdProfesional).Load();
					colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma_ListChanged);
				}
				return colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma;			
			}
			set 
			{ 
					colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma = value; 
					colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma_ListChanged);
			}
		}
		
		void colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma[e.NewIndex].IdProfesionalInforma = IdProfesional;
		    }
		}
				
		private DalSic.GuardiaRegistroCollection colGuardiaRegistros;
		public DalSic.GuardiaRegistroCollection GuardiaRegistros
		{
			get
			{
				if(colGuardiaRegistros == null)
				{
					colGuardiaRegistros = new DalSic.GuardiaRegistroCollection().Where(GuardiaRegistro.Columns.MedicoResponsable, IdProfesional).Load();
					colGuardiaRegistros.ListChanged += new ListChangedEventHandler(colGuardiaRegistros_ListChanged);
				}
				return colGuardiaRegistros;			
			}
			set 
			{ 
					colGuardiaRegistros = value; 
					colGuardiaRegistros.ListChanged += new ListChangedEventHandler(colGuardiaRegistros_ListChanged);
			}
		}
		
		void colGuardiaRegistros_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colGuardiaRegistros[e.NewIndex].MedicoResponsable = IdProfesional;
		    }
		}
				
		private DalSic.SysRelProfesionalEfectorCollection colSysRelProfesionalEfectorRecords;
		public DalSic.SysRelProfesionalEfectorCollection SysRelProfesionalEfectorRecords
		{
			get
			{
				if(colSysRelProfesionalEfectorRecords == null)
				{
					colSysRelProfesionalEfectorRecords = new DalSic.SysRelProfesionalEfectorCollection().Where(SysRelProfesionalEfector.Columns.IdProfesional, IdProfesional).Load();
					colSysRelProfesionalEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelProfesionalEfectorRecords_ListChanged);
				}
				return colSysRelProfesionalEfectorRecords;			
			}
			set 
			{ 
					colSysRelProfesionalEfectorRecords = value; 
					colSysRelProfesionalEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelProfesionalEfectorRecords_ListChanged);
			}
		}
		
		void colSysRelProfesionalEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelProfesionalEfectorRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
				
		private DalSic.RemSeguimientoCollection colRemSeguimientoRecords;
		public DalSic.RemSeguimientoCollection RemSeguimientoRecords
		{
			get
			{
				if(colRemSeguimientoRecords == null)
				{
					colRemSeguimientoRecords = new DalSic.RemSeguimientoCollection().Where(RemSeguimiento.Columns.IdProfesional, IdProfesional).Load();
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
		        colRemSeguimientoRecords[e.NewIndex].IdProfesional = IdProfesional;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysProfesional
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysTipoProfesional ActiveRecord object related to this SysProfesional
		/// 
		/// </summary>
		public DalSic.SysTipoProfesional SysTipoProfesional
		{
			get { return DalSic.SysTipoProfesional.FetchByID(this.IdTipoProfesional); }
			set { SetColumnValue("idTipoProfesional", value.IdTipoProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysTipoDocumento ActiveRecord object related to this SysProfesional
		/// 
		/// </summary>
		public DalSic.SysTipoDocumento SysTipoDocumento
		{
			get { return DalSic.SysTipoDocumento.FetchByID(this.IdTipoDocumento); }
			set { SetColumnValue("idTipoDocumento", value.IdTipoDocumento); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,string varApellido,string varNombre,int varIdTipoDocumento,int varNumeroDocumento,string varMatricula,string varLegajo,string varCodigoSISA,bool varActivo,string varNombreCompleto,string varApellidoyNombre,int varIdTipoProfesional,int varIdUsuario,DateTime varFechaModificacion,string varMail,string varTelefono,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			SysProfesional item = new SysProfesional();
			
			item.IdEfector = varIdEfector;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.IdTipoDocumento = varIdTipoDocumento;
			
			item.NumeroDocumento = varNumeroDocumento;
			
			item.Matricula = varMatricula;
			
			item.Legajo = varLegajo;
			
			item.CodigoSISA = varCodigoSISA;
			
			item.Activo = varActivo;
			
			item.NombreCompleto = varNombreCompleto;
			
			item.ApellidoyNombre = varApellidoyNombre;
			
			item.IdTipoProfesional = varIdTipoProfesional;
			
			item.IdUsuario = varIdUsuario;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.Mail = varMail;
			
			item.Telefono = varTelefono;
			
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
		public static void Update(int varIdProfesional,int varIdEfector,string varApellido,string varNombre,int varIdTipoDocumento,int varNumeroDocumento,string varMatricula,string varLegajo,string varCodigoSISA,bool varActivo,string varNombreCompleto,string varApellidoyNombre,int varIdTipoProfesional,int varIdUsuario,DateTime varFechaModificacion,string varMail,string varTelefono,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			SysProfesional item = new SysProfesional();
			
				item.IdProfesional = varIdProfesional;
			
				item.IdEfector = varIdEfector;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.IdTipoDocumento = varIdTipoDocumento;
			
				item.NumeroDocumento = varNumeroDocumento;
			
				item.Matricula = varMatricula;
			
				item.Legajo = varLegajo;
			
				item.CodigoSISA = varCodigoSISA;
			
				item.Activo = varActivo;
			
				item.NombreCompleto = varNombreCompleto;
			
				item.ApellidoyNombre = varApellidoyNombre;
			
				item.IdTipoProfesional = varIdTipoProfesional;
			
				item.IdUsuario = varIdUsuario;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.Mail = varMail;
			
				item.Telefono = varTelefono;
			
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
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoDocumentoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocumentoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MatriculaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn LegajoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoSISAColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreCompletoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoyNombreColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoProfesionalColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MailColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProfesional = @"idProfesional";
			 public static string IdEfector = @"idEfector";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string IdTipoDocumento = @"idTipoDocumento";
			 public static string NumeroDocumento = @"numeroDocumento";
			 public static string Matricula = @"matricula";
			 public static string Legajo = @"legajo";
			 public static string CodigoSISA = @"codigoSISA";
			 public static string Activo = @"activo";
			 public static string NombreCompleto = @"NombreCompleto";
			 public static string ApellidoyNombre = @"ApellidoyNombre";
			 public static string IdTipoProfesional = @"idTipoProfesional";
			 public static string IdUsuario = @"idUsuario";
			 public static string FechaModificacion = @"fechaModificacion";
			 public static string Mail = @"mail";
			 public static string Telefono = @"telefono";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colTabControlRecords != null)
                {
                    foreach (DalSic.TabControl item in colTabControlRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamEstudiosHospitalProvincialRecords != null)
                {
                    foreach (DalSic.MamEstudiosHospitalProvincial item in colMamEstudiosHospitalProvincialRecords)
                    {
                        if (item.SolicitudProfesional != IdProfesional)
                        {
                            item.SolicitudProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colAprControlOdontologicoRecords != null)
                {
                    foreach (DalSic.AprControlOdontologico item in colAprControlOdontologicoRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colAprPartoProvisorioRecords != null)
                {
                    foreach (DalSic.AprPartoProvisorio item in colAprPartoProvisorioRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colRemFormularioRecords != null)
                {
                    foreach (DalSic.RemFormulario item in colRemFormularioRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colAprInterconsulta != null)
                {
                    foreach (DalSic.AprInterconsultum item in colAprInterconsulta)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamCirugia != null)
                {
                    foreach (DalSic.MamCirugium item in colMamCirugia)
                    {
                        if (item.IdProfesionalResponsable != IdProfesional)
                        {
                            item.IdProfesionalResponsable = IdProfesional;
                        }
                    }
               }
		
                if (colConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colConAgendaRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colConAgendaGrupalProfesionalRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupalProfesional item in colConAgendaGrupalProfesionalRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamAnatomiaPatologicaRecords != null)
                {
                    foreach (DalSic.MamAnatomiaPatologica item in colMamAnatomiaPatologicaRecords)
                    {
                        if (item.IdResponsableMuestra != IdProfesional)
                        {
                            item.IdResponsableMuestra = IdProfesional;
                        }
                    }
               }
		
                if (colFacJefeLaboratorioRecords != null)
                {
                    foreach (DalSic.FacJefeLaboratorio item in colFacJefeLaboratorioRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamAnatomiaPatologicaRecordsFromSysProfesional != null)
                {
                    foreach (DalSic.MamAnatomiaPatologica item in colMamAnatomiaPatologicaRecordsFromSysProfesional)
                    {
                        if (item.IdResponsableInforme != IdProfesional)
                        {
                            item.IdResponsableInforme = IdProfesional;
                        }
                    }
               }
		
                if (colRemClasificacionRecords != null)
                {
                    foreach (DalSic.RemClasificacion item in colRemClasificacionRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamPiezaQuirurgicaRecords != null)
                {
                    foreach (DalSic.MamPiezaQuirurgica item in colMamPiezaQuirurgicaRecords)
                    {
                        if (item.IdResponsableInforme != IdProfesional)
                        {
                            item.IdResponsableInforme = IdProfesional;
                        }
                    }
               }
		
                if (colAprActividadControlPerinatalRecords != null)
                {
                    foreach (DalSic.AprActividadControlPerinatal item in colAprActividadControlPerinatalRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamEstudiosAdicionales != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionales)
                    {
                        if (item.IdProfesionalResponsable != IdProfesional)
                        {
                            item.IdProfesionalResponsable = IdProfesional;
                        }
                    }
               }
		
                if (colMamEcografia != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografia)
                    {
                        if (item.IdProfesionalTecnico != IdProfesional)
                        {
                            item.IdProfesionalTecnico = IdProfesional;
                        }
                    }
               }
		
                if (colMamEcografiaFromSysProfesional != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografiaFromSysProfesional)
                    {
                        if (item.IdProfesionalSolicita != IdProfesional)
                        {
                            item.IdProfesionalSolicita = IdProfesional;
                        }
                    }
               }
		
                if (colMamEstudiosAdicionalesFromSysProfesional != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionalesFromSysProfesional)
                    {
                        if (item.IdProfesionalTecnico != IdProfesional)
                        {
                            item.IdProfesionalTecnico = IdProfesional;
                        }
                    }
               }
		
                if (colMamRegistroRecords != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecords)
                    {
                        if (item.IdProfesionalTecnico != IdProfesional)
                        {
                            item.IdProfesionalTecnico = IdProfesional;
                        }
                    }
               }
		
                if (colMamRegistroRecordsFromSysProfesional != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecordsFromSysProfesional)
                    {
                        if (item.IdProfesionalSolicita != IdProfesional)
                        {
                            item.IdProfesionalSolicita = IdProfesional;
                        }
                    }
               }
		
                if (colAprActividadFisicaRecords != null)
                {
                    foreach (DalSic.AprActividadFisica item in colAprActividadFisicaRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colConConsulta != null)
                {
                    foreach (DalSic.ConConsultum item in colConConsulta)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamEcografiaFromSysProfesionalIdProfesionalResponsable != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografiaFromSysProfesionalIdProfesionalResponsable)
                    {
                        if (item.IdProfesionalResponsable != IdProfesional)
                        {
                            item.IdProfesionalResponsable = IdProfesional;
                        }
                    }
               }
		
                if (colMamEstadioClinicoRecords != null)
                {
                    foreach (DalSic.MamEstadioClinico item in colMamEstadioClinicoRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamExamenFisicoRecords != null)
                {
                    foreach (DalSic.MamExamenFisico item in colMamExamenFisicoRecords)
                    {
                        if (item.IdResponsableExamen != IdProfesional)
                        {
                            item.IdResponsableExamen = IdProfesional;
                        }
                    }
               }
		
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    foreach (DalSic.AprControlNiñoSanoEnfermerium item in colAprControlNiñoSanoEnfermeria)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colConAgendaProfesionalRecords != null)
                {
                    foreach (DalSic.ConAgendaProfesional item in colConAgendaProfesionalRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colMamTratamientos != null)
                {
                    foreach (DalSic.MamTratamiento item in colMamTratamientos)
                    {
                        if (item.IdResponsableExamen != IdProfesional)
                        {
                            item.IdResponsableExamen = IdProfesional;
                        }
                    }
               }
		
                if (colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma)
                    {
                        if (item.IdProfesionalInforma != IdProfesional)
                        {
                            item.IdProfesionalInforma = IdProfesional;
                        }
                    }
               }
		
                if (colGuardiaRegistros != null)
                {
                    foreach (DalSic.GuardiaRegistro item in colGuardiaRegistros)
                    {
                        if (item.MedicoResponsable != IdProfesional)
                        {
                            item.MedicoResponsable = IdProfesional;
                        }
                    }
               }
		
                if (colSysRelProfesionalEfectorRecords != null)
                {
                    foreach (DalSic.SysRelProfesionalEfector item in colSysRelProfesionalEfectorRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		
                if (colRemSeguimientoRecords != null)
                {
                    foreach (DalSic.RemSeguimiento item in colRemSeguimientoRecords)
                    {
                        if (item.IdProfesional != IdProfesional)
                        {
                            item.IdProfesional = IdProfesional;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colTabControlRecords != null)
                {
                    colTabControlRecords.SaveAll();
               }
		
                if (colMamEstudiosHospitalProvincialRecords != null)
                {
                    colMamEstudiosHospitalProvincialRecords.SaveAll();
               }
		
                if (colAprControlOdontologicoRecords != null)
                {
                    colAprControlOdontologicoRecords.SaveAll();
               }
		
                if (colAprPartoProvisorioRecords != null)
                {
                    colAprPartoProvisorioRecords.SaveAll();
               }
		
                if (colRemFormularioRecords != null)
                {
                    colRemFormularioRecords.SaveAll();
               }
		
                if (colAprInterconsulta != null)
                {
                    colAprInterconsulta.SaveAll();
               }
		
                if (colMamCirugia != null)
                {
                    colMamCirugia.SaveAll();
               }
		
                if (colConAgendaRecords != null)
                {
                    colConAgendaRecords.SaveAll();
               }
		
                if (colConAgendaGrupalProfesionalRecords != null)
                {
                    colConAgendaGrupalProfesionalRecords.SaveAll();
               }
		
                if (colMamAnatomiaPatologicaRecords != null)
                {
                    colMamAnatomiaPatologicaRecords.SaveAll();
               }
		
                if (colFacJefeLaboratorioRecords != null)
                {
                    colFacJefeLaboratorioRecords.SaveAll();
               }
		
                if (colMamAnatomiaPatologicaRecordsFromSysProfesional != null)
                {
                    colMamAnatomiaPatologicaRecordsFromSysProfesional.SaveAll();
               }
		
                if (colRemClasificacionRecords != null)
                {
                    colRemClasificacionRecords.SaveAll();
               }
		
                if (colMamPiezaQuirurgicaRecords != null)
                {
                    colMamPiezaQuirurgicaRecords.SaveAll();
               }
		
                if (colAprActividadControlPerinatalRecords != null)
                {
                    colAprActividadControlPerinatalRecords.SaveAll();
               }
		
                if (colMamEstudiosAdicionales != null)
                {
                    colMamEstudiosAdicionales.SaveAll();
               }
		
                if (colMamEcografia != null)
                {
                    colMamEcografia.SaveAll();
               }
		
                if (colMamEcografiaFromSysProfesional != null)
                {
                    colMamEcografiaFromSysProfesional.SaveAll();
               }
		
                if (colMamEstudiosAdicionalesFromSysProfesional != null)
                {
                    colMamEstudiosAdicionalesFromSysProfesional.SaveAll();
               }
		
                if (colMamRegistroRecords != null)
                {
                    colMamRegistroRecords.SaveAll();
               }
		
                if (colMamRegistroRecordsFromSysProfesional != null)
                {
                    colMamRegistroRecordsFromSysProfesional.SaveAll();
               }
		
                if (colAprActividadFisicaRecords != null)
                {
                    colAprActividadFisicaRecords.SaveAll();
               }
		
                if (colConConsulta != null)
                {
                    colConConsulta.SaveAll();
               }
		
                if (colMamEcografiaFromSysProfesionalIdProfesionalResponsable != null)
                {
                    colMamEcografiaFromSysProfesionalIdProfesionalResponsable.SaveAll();
               }
		
                if (colMamEstadioClinicoRecords != null)
                {
                    colMamEstadioClinicoRecords.SaveAll();
               }
		
                if (colMamExamenFisicoRecords != null)
                {
                    colMamExamenFisicoRecords.SaveAll();
               }
		
                if (colAprControlNiñoSanoEnfermeria != null)
                {
                    colAprControlNiñoSanoEnfermeria.SaveAll();
               }
		
                if (colConAgendaProfesionalRecords != null)
                {
                    colConAgendaProfesionalRecords.SaveAll();
               }
		
                if (colMamTratamientos != null)
                {
                    colMamTratamientos.SaveAll();
               }
		
                if (colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma != null)
                {
                    colMamRegistroRecordsFromSysProfesionalIdProfesionalInforma.SaveAll();
               }
		
                if (colGuardiaRegistros != null)
                {
                    colGuardiaRegistros.SaveAll();
               }
		
                if (colSysRelProfesionalEfectorRecords != null)
                {
                    colSysRelProfesionalEfectorRecords.SaveAll();
               }
		
                if (colRemSeguimientoRecords != null)
                {
                    colRemSeguimientoRecords.SaveAll();
               }
		}
        #endregion
	}
}
