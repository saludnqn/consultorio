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
	/// Strongly-typed collection for the SysEfector class.
	/// </summary>
    [Serializable]
	public partial class SysEfectorCollection : ActiveList<SysEfector, SysEfectorCollection>
	{	   
		public SysEfectorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysEfectorCollection</returns>
		public SysEfectorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysEfector o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Efector table.
	/// </summary>
	[Serializable]
	public partial class SysEfector : ActiveRecord<SysEfector>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysEfector()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysEfector(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysEfector(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysEfector(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Efector", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = true;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = true;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdZona = new TableSchema.TableColumn(schema);
				colvarIdZona.ColumnName = "idZona";
				colvarIdZona.DataType = DbType.Int32;
				colvarIdZona.MaxLength = 0;
				colvarIdZona.AutoIncrement = false;
				colvarIdZona.IsNullable = false;
				colvarIdZona.IsPrimaryKey = false;
				colvarIdZona.IsForeignKey = true;
				colvarIdZona.IsReadOnly = false;
				colvarIdZona.DefaultSetting = @"";
				
					colvarIdZona.ForeignKeyTableName = "Sys_Zona";
				schema.Columns.Add(colvarIdZona);
				
				TableSchema.TableColumn colvarNombreNacion = new TableSchema.TableColumn(schema);
				colvarNombreNacion.ColumnName = "nombreNacion";
				colvarNombreNacion.DataType = DbType.String;
				colvarNombreNacion.MaxLength = 100;
				colvarNombreNacion.AutoIncrement = false;
				colvarNombreNacion.IsNullable = false;
				colvarNombreNacion.IsPrimaryKey = false;
				colvarNombreNacion.IsForeignKey = false;
				colvarNombreNacion.IsReadOnly = false;
				
						colvarNombreNacion.DefaultSetting = @"('')";
				colvarNombreNacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreNacion);
				
				TableSchema.TableColumn colvarComplejidad = new TableSchema.TableColumn(schema);
				colvarComplejidad.ColumnName = "complejidad";
				colvarComplejidad.DataType = DbType.String;
				colvarComplejidad.MaxLength = 10;
				colvarComplejidad.AutoIncrement = false;
				colvarComplejidad.IsNullable = false;
				colvarComplejidad.IsPrimaryKey = false;
				colvarComplejidad.IsForeignKey = false;
				colvarComplejidad.IsReadOnly = false;
				
						colvarComplejidad.DefaultSetting = @"('')";
				colvarComplejidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComplejidad);
				
				TableSchema.TableColumn colvarIdEfectorSuperior = new TableSchema.TableColumn(schema);
				colvarIdEfectorSuperior.ColumnName = "idEfectorSuperior";
				colvarIdEfectorSuperior.DataType = DbType.Int32;
				colvarIdEfectorSuperior.MaxLength = 0;
				colvarIdEfectorSuperior.AutoIncrement = false;
				colvarIdEfectorSuperior.IsNullable = false;
				colvarIdEfectorSuperior.IsPrimaryKey = false;
				colvarIdEfectorSuperior.IsForeignKey = true;
				colvarIdEfectorSuperior.IsReadOnly = false;
				
						colvarIdEfectorSuperior.DefaultSetting = @"('')";
				
					colvarIdEfectorSuperior.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorSuperior);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.String;
				colvarDomicilio.MaxLength = 200;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = false;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				
						colvarDomicilio.DefaultSetting = @"('')";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.String;
				colvarTelefono.MaxLength = 10;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = false;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				
						colvarTelefono.DefaultSetting = @"('')";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarReponsable = new TableSchema.TableColumn(schema);
				colvarReponsable.ColumnName = "reponsable";
				colvarReponsable.DataType = DbType.String;
				colvarReponsable.MaxLength = 100;
				colvarReponsable.AutoIncrement = false;
				colvarReponsable.IsNullable = false;
				colvarReponsable.IsPrimaryKey = false;
				colvarReponsable.IsForeignKey = false;
				colvarReponsable.IsReadOnly = false;
				
						colvarReponsable.DefaultSetting = @"('')";
				colvarReponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReponsable);
				
				TableSchema.TableColumn colvarCodigoRemediar = new TableSchema.TableColumn(schema);
				colvarCodigoRemediar.ColumnName = "codigoRemediar";
				colvarCodigoRemediar.DataType = DbType.String;
				colvarCodigoRemediar.MaxLength = 10;
				colvarCodigoRemediar.AutoIncrement = false;
				colvarCodigoRemediar.IsNullable = true;
				colvarCodigoRemediar.IsPrimaryKey = false;
				colvarCodigoRemediar.IsForeignKey = false;
				colvarCodigoRemediar.IsReadOnly = false;
				colvarCodigoRemediar.DefaultSetting = @"";
				colvarCodigoRemediar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoRemediar);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = true;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarIdTipoEfector = new TableSchema.TableColumn(schema);
				colvarIdTipoEfector.ColumnName = "idTipoEfector";
				colvarIdTipoEfector.DataType = DbType.Int32;
				colvarIdTipoEfector.MaxLength = 0;
				colvarIdTipoEfector.AutoIncrement = false;
				colvarIdTipoEfector.IsNullable = true;
				colvarIdTipoEfector.IsPrimaryKey = false;
				colvarIdTipoEfector.IsForeignKey = false;
				colvarIdTipoEfector.IsReadOnly = false;
				colvarIdTipoEfector.DefaultSetting = @"";
				colvarIdTipoEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoEfector);
				
				TableSchema.TableColumn colvarCodigoSisa = new TableSchema.TableColumn(schema);
				colvarCodigoSisa.ColumnName = "codigoSisa";
				colvarCodigoSisa.DataType = DbType.AnsiString;
				colvarCodigoSisa.MaxLength = 50;
				colvarCodigoSisa.AutoIncrement = false;
				colvarCodigoSisa.IsNullable = true;
				colvarCodigoSisa.IsPrimaryKey = false;
				colvarCodigoSisa.IsForeignKey = false;
				colvarCodigoSisa.IsReadOnly = false;
				
						colvarCodigoSisa.DefaultSetting = @"((0))";
				colvarCodigoSisa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoSisa);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_Efector",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdZona")]
		[Bindable(true)]
		public int IdZona 
		{
			get { return GetColumnValue<int>(Columns.IdZona); }
			set { SetColumnValue(Columns.IdZona, value); }
		}
		  
		[XmlAttribute("NombreNacion")]
		[Bindable(true)]
		public string NombreNacion 
		{
			get { return GetColumnValue<string>(Columns.NombreNacion); }
			set { SetColumnValue(Columns.NombreNacion, value); }
		}
		  
		[XmlAttribute("Complejidad")]
		[Bindable(true)]
		public string Complejidad 
		{
			get { return GetColumnValue<string>(Columns.Complejidad); }
			set { SetColumnValue(Columns.Complejidad, value); }
		}
		  
		[XmlAttribute("IdEfectorSuperior")]
		[Bindable(true)]
		public int IdEfectorSuperior 
		{
			get { return GetColumnValue<int>(Columns.IdEfectorSuperior); }
			set { SetColumnValue(Columns.IdEfectorSuperior, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("Reponsable")]
		[Bindable(true)]
		public string Reponsable 
		{
			get { return GetColumnValue<string>(Columns.Reponsable); }
			set { SetColumnValue(Columns.Reponsable, value); }
		}
		  
		[XmlAttribute("CodigoRemediar")]
		[Bindable(true)]
		public string CodigoRemediar 
		{
			get { return GetColumnValue<string>(Columns.CodigoRemediar); }
			set { SetColumnValue(Columns.CodigoRemediar, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("IdTipoEfector")]
		[Bindable(true)]
		public int? IdTipoEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoEfector); }
			set { SetColumnValue(Columns.IdTipoEfector, value); }
		}
		  
		[XmlAttribute("CodigoSisa")]
		[Bindable(true)]
		public string CodigoSisa 
		{
			get { return GetColumnValue<string>(Columns.CodigoSisa); }
			set { SetColumnValue(Columns.CodigoSisa, value); }
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
					colTabControlRecords = new DalSic.TabControlCollection().Where(TabControl.Columns.IdEfector, IdEfector).Load();
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
		        colTabControlRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.AprControlOdontologicoCollection colAprControlOdontologicoRecords;
		public DalSic.AprControlOdontologicoCollection AprControlOdontologicoRecords
		{
			get
			{
				if(colAprControlOdontologicoRecords == null)
				{
					colAprControlOdontologicoRecords = new DalSic.AprControlOdontologicoCollection().Where(AprControlOdontologico.Columns.IdEfector, IdEfector).Load();
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
		        colAprControlOdontologicoRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamEstudiosHospitalProvincialCollection colMamEstudiosHospitalProvincialRecords;
		public DalSic.MamEstudiosHospitalProvincialCollection MamEstudiosHospitalProvincialRecords
		{
			get
			{
				if(colMamEstudiosHospitalProvincialRecords == null)
				{
					colMamEstudiosHospitalProvincialRecords = new DalSic.MamEstudiosHospitalProvincialCollection().Where(MamEstudiosHospitalProvincial.Columns.SolicitudCentroSalud, IdEfector).Load();
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
		        colMamEstudiosHospitalProvincialRecords[e.NewIndex].SolicitudCentroSalud = IdEfector;
		    }
		}
				
		private DalSic.AprPartoProvisorioCollection colAprPartoProvisorioRecords;
		public DalSic.AprPartoProvisorioCollection AprPartoProvisorioRecords
		{
			get
			{
				if(colAprPartoProvisorioRecords == null)
				{
					colAprPartoProvisorioRecords = new DalSic.AprPartoProvisorioCollection().Where(AprPartoProvisorio.Columns.IdEfectorParto, IdEfector).Load();
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
		        colAprPartoProvisorioRecords[e.NewIndex].IdEfectorParto = IdEfector;
		    }
		}
				
		private DalSic.AprInterconsultumCollection colAprInterconsulta;
		public DalSic.AprInterconsultumCollection AprInterconsulta
		{
			get
			{
				if(colAprInterconsulta == null)
				{
					colAprInterconsulta = new DalSic.AprInterconsultumCollection().Where(AprInterconsultum.Columns.IdEfector, IdEfector).Load();
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
		        colAprInterconsulta[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.SysRelServicioEfectorCollection colSysRelServicioEfectorRecords;
		public DalSic.SysRelServicioEfectorCollection SysRelServicioEfectorRecords
		{
			get
			{
				if(colSysRelServicioEfectorRecords == null)
				{
					colSysRelServicioEfectorRecords = new DalSic.SysRelServicioEfectorCollection().Where(SysRelServicioEfector.Columns.IdEfector, IdEfector).Load();
					colSysRelServicioEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelServicioEfectorRecords_ListChanged);
				}
				return colSysRelServicioEfectorRecords;			
			}
			set 
			{ 
					colSysRelServicioEfectorRecords = value; 
					colSysRelServicioEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelServicioEfectorRecords_ListChanged);
			}
		}
		
		void colSysRelServicioEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelServicioEfectorRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamCirugiumCollection colMamCirugia;
		public DalSic.MamCirugiumCollection MamCirugia
		{
			get
			{
				if(colMamCirugia == null)
				{
					colMamCirugia = new DalSic.MamCirugiumCollection().Where(MamCirugium.Columns.IdCentroSalud, IdEfector).Load();
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
		        colMamCirugia[e.NewIndex].IdCentroSalud = IdEfector;
		    }
		}
				
		private DalSic.ConConsultorioTipoCollection colConConsultorioTipoRecords;
		public DalSic.ConConsultorioTipoCollection ConConsultorioTipoRecords
		{
			get
			{
				if(colConConsultorioTipoRecords == null)
				{
					colConConsultorioTipoRecords = new DalSic.ConConsultorioTipoCollection().Where(ConConsultorioTipo.Columns.IdEfector, IdEfector).Load();
					colConConsultorioTipoRecords.ListChanged += new ListChangedEventHandler(colConConsultorioTipoRecords_ListChanged);
				}
				return colConConsultorioTipoRecords;			
			}
			set 
			{ 
					colConConsultorioTipoRecords = value; 
					colConConsultorioTipoRecords.ListChanged += new ListChangedEventHandler(colConConsultorioTipoRecords_ListChanged);
			}
		}
		
		void colConConsultorioTipoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsultorioTipoRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.ConAgendaGrupalCollection colConAgendaGrupalRecords;
		public DalSic.ConAgendaGrupalCollection ConAgendaGrupalRecords
		{
			get
			{
				if(colConAgendaGrupalRecords == null)
				{
					colConAgendaGrupalRecords = new DalSic.ConAgendaGrupalCollection().Where(ConAgendaGrupal.Columns.IdEfector, IdEfector).Load();
					colConAgendaGrupalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalRecords_ListChanged);
				}
				return colConAgendaGrupalRecords;			
			}
			set 
			{ 
					colConAgendaGrupalRecords = value; 
					colConAgendaGrupalRecords.ListChanged += new ListChangedEventHandler(colConAgendaGrupalRecords_ListChanged);
			}
		}
		
		void colConAgendaGrupalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConAgendaGrupalRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.LabSolicitudScreeningCollection colLabSolicitudScreeningRecords;
		public DalSic.LabSolicitudScreeningCollection LabSolicitudScreeningRecords
		{
			get
			{
				if(colLabSolicitudScreeningRecords == null)
				{
					colLabSolicitudScreeningRecords = new DalSic.LabSolicitudScreeningCollection().Where(LabSolicitudScreening.Columns.IdEfectorSolicitante, IdEfector).Load();
					colLabSolicitudScreeningRecords.ListChanged += new ListChangedEventHandler(colLabSolicitudScreeningRecords_ListChanged);
				}
				return colLabSolicitudScreeningRecords;			
			}
			set 
			{ 
					colLabSolicitudScreeningRecords = value; 
					colLabSolicitudScreeningRecords.ListChanged += new ListChangedEventHandler(colLabSolicitudScreeningRecords_ListChanged);
			}
		}
		
		void colLabSolicitudScreeningRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabSolicitudScreeningRecords[e.NewIndex].IdEfectorSolicitante = IdEfector;
		    }
		}
				
		private DalSic.LabSolicitudScreeningCollection colLabSolicitudScreeningRecordsFromSysEfector;
		public DalSic.LabSolicitudScreeningCollection LabSolicitudScreeningRecordsFromSysEfector
		{
			get
			{
				if(colLabSolicitudScreeningRecordsFromSysEfector == null)
				{
					colLabSolicitudScreeningRecordsFromSysEfector = new DalSic.LabSolicitudScreeningCollection().Where(LabSolicitudScreening.Columns.IdLugarControl, IdEfector).Load();
					colLabSolicitudScreeningRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colLabSolicitudScreeningRecordsFromSysEfector_ListChanged);
				}
				return colLabSolicitudScreeningRecordsFromSysEfector;			
			}
			set 
			{ 
					colLabSolicitudScreeningRecordsFromSysEfector = value; 
					colLabSolicitudScreeningRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colLabSolicitudScreeningRecordsFromSysEfector_ListChanged);
			}
		}
		
		void colLabSolicitudScreeningRecordsFromSysEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colLabSolicitudScreeningRecordsFromSysEfector[e.NewIndex].IdLugarControl = IdEfector;
		    }
		}
				
		private DalSic.MamAnatomiaPatologicaCollection colMamAnatomiaPatologicaRecords;
		public DalSic.MamAnatomiaPatologicaCollection MamAnatomiaPatologicaRecords
		{
			get
			{
				if(colMamAnatomiaPatologicaRecords == null)
				{
					colMamAnatomiaPatologicaRecords = new DalSic.MamAnatomiaPatologicaCollection().Where(MamAnatomiaPatologica.Columns.IdCentroSaludInforme, IdEfector).Load();
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
		        colMamAnatomiaPatologicaRecords[e.NewIndex].IdCentroSaludInforme = IdEfector;
		    }
		}
				
		private DalSic.MamAnatomiaPatologicaCollection colMamAnatomiaPatologicaRecordsFromSysEfector;
		public DalSic.MamAnatomiaPatologicaCollection MamAnatomiaPatologicaRecordsFromSysEfector
		{
			get
			{
				if(colMamAnatomiaPatologicaRecordsFromSysEfector == null)
				{
					colMamAnatomiaPatologicaRecordsFromSysEfector = new DalSic.MamAnatomiaPatologicaCollection().Where(MamAnatomiaPatologica.Columns.IdCentroSaludMuestra, IdEfector).Load();
					colMamAnatomiaPatologicaRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecordsFromSysEfector_ListChanged);
				}
				return colMamAnatomiaPatologicaRecordsFromSysEfector;			
			}
			set 
			{ 
					colMamAnatomiaPatologicaRecordsFromSysEfector = value; 
					colMamAnatomiaPatologicaRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecordsFromSysEfector_ListChanged);
			}
		}
		
		void colMamAnatomiaPatologicaRecordsFromSysEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamAnatomiaPatologicaRecordsFromSysEfector[e.NewIndex].IdCentroSaludMuestra = IdEfector;
		    }
		}
				
		private DalSic.FacJefeLaboratorioCollection colFacJefeLaboratorioRecords;
		public DalSic.FacJefeLaboratorioCollection FacJefeLaboratorioRecords
		{
			get
			{
				if(colFacJefeLaboratorioRecords == null)
				{
					colFacJefeLaboratorioRecords = new DalSic.FacJefeLaboratorioCollection().Where(FacJefeLaboratorio.Columns.IdEfector, IdEfector).Load();
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
		        colFacJefeLaboratorioRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.RemClasificacionCollection colRemClasificacionRecords;
		public DalSic.RemClasificacionCollection RemClasificacionRecords
		{
			get
			{
				if(colRemClasificacionRecords == null)
				{
					colRemClasificacionRecords = new DalSic.RemClasificacionCollection().Where(RemClasificacion.Columns.IdEfector, IdEfector).Load();
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
		        colRemClasificacionRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.AprActividadControlPerinatalCollection colAprActividadControlPerinatalRecords;
		public DalSic.AprActividadControlPerinatalCollection AprActividadControlPerinatalRecords
		{
			get
			{
				if(colAprActividadControlPerinatalRecords == null)
				{
					colAprActividadControlPerinatalRecords = new DalSic.AprActividadControlPerinatalCollection().Where(AprActividadControlPerinatal.Columns.IdEfector, IdEfector).Load();
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
		        colAprActividadControlPerinatalRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamPiezaQuirurgicaCollection colMamPiezaQuirurgicaRecords;
		public DalSic.MamPiezaQuirurgicaCollection MamPiezaQuirurgicaRecords
		{
			get
			{
				if(colMamPiezaQuirurgicaRecords == null)
				{
					colMamPiezaQuirurgicaRecords = new DalSic.MamPiezaQuirurgicaCollection().Where(MamPiezaQuirurgica.Columns.IdCentroSaludInforme, IdEfector).Load();
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
		        colMamPiezaQuirurgicaRecords[e.NewIndex].IdCentroSaludInforme = IdEfector;
		    }
		}
				
		private DalSic.ConTurnoReservaInterconsultumCollection colConTurnoReservaInterconsulta;
		public DalSic.ConTurnoReservaInterconsultumCollection ConTurnoReservaInterconsulta
		{
			get
			{
				if(colConTurnoReservaInterconsulta == null)
				{
					colConTurnoReservaInterconsulta = new DalSic.ConTurnoReservaInterconsultumCollection().Where(ConTurnoReservaInterconsultum.Columns.IdEfector, IdEfector).Load();
					colConTurnoReservaInterconsulta.ListChanged += new ListChangedEventHandler(colConTurnoReservaInterconsulta_ListChanged);
				}
				return colConTurnoReservaInterconsulta;			
			}
			set 
			{ 
					colConTurnoReservaInterconsulta = value; 
					colConTurnoReservaInterconsulta.ListChanged += new ListChangedEventHandler(colConTurnoReservaInterconsulta_ListChanged);
			}
		}
		
		void colConTurnoReservaInterconsulta_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConTurnoReservaInterconsulta[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionales;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionales
		{
			get
			{
				if(colMamEstudiosAdicionales == null)
				{
					colMamEstudiosAdicionales = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdCentroSalud, IdEfector).Load();
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
		        colMamEstudiosAdicionales[e.NewIndex].IdCentroSalud = IdEfector;
		    }
		}
				
		private DalSic.SysEfectorCollection colChildSysEfectorRecords;
		public DalSic.SysEfectorCollection ChildSysEfectorRecords
		{
			get
			{
				if(colChildSysEfectorRecords == null)
				{
					colChildSysEfectorRecords = new DalSic.SysEfectorCollection().Where(SysEfector.Columns.IdEfectorSuperior, IdEfector).Load();
					colChildSysEfectorRecords.ListChanged += new ListChangedEventHandler(colChildSysEfectorRecords_ListChanged);
				}
				return colChildSysEfectorRecords;			
			}
			set 
			{ 
					colChildSysEfectorRecords = value; 
					colChildSysEfectorRecords.ListChanged += new ListChangedEventHandler(colChildSysEfectorRecords_ListChanged);
			}
		}
		
		void colChildSysEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colChildSysEfectorRecords[e.NewIndex].IdEfectorSuperior = IdEfector;
		    }
		}
				
		private DalSic.SysRelProfesionalEfectorCollection colSysRelProfesionalEfectorRecords;
		public DalSic.SysRelProfesionalEfectorCollection SysRelProfesionalEfectorRecords
		{
			get
			{
				if(colSysRelProfesionalEfectorRecords == null)
				{
					colSysRelProfesionalEfectorRecords = new DalSic.SysRelProfesionalEfectorCollection().Where(SysRelProfesionalEfector.Columns.IdEfector, IdEfector).Load();
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
		        colSysRelProfesionalEfectorRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.SysEstablecimientoCollection colSysEstablecimientoRecords;
		public DalSic.SysEstablecimientoCollection SysEstablecimientoRecords
		{
			get
			{
				if(colSysEstablecimientoRecords == null)
				{
					colSysEstablecimientoRecords = new DalSic.SysEstablecimientoCollection().Where(SysEstablecimiento.Columns.IdEfector, IdEfector).Load();
					colSysEstablecimientoRecords.ListChanged += new ListChangedEventHandler(colSysEstablecimientoRecords_ListChanged);
				}
				return colSysEstablecimientoRecords;			
			}
			set 
			{ 
					colSysEstablecimientoRecords = value; 
					colSysEstablecimientoRecords.ListChanged += new ListChangedEventHandler(colSysEstablecimientoRecords_ListChanged);
			}
		}
		
		void colSysEstablecimientoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysEstablecimientoRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.SysRelEspecialidadEfectorCollection colSysRelEspecialidadEfectorRecords;
		public DalSic.SysRelEspecialidadEfectorCollection SysRelEspecialidadEfectorRecords
		{
			get
			{
				if(colSysRelEspecialidadEfectorRecords == null)
				{
					colSysRelEspecialidadEfectorRecords = new DalSic.SysRelEspecialidadEfectorCollection().Where(SysRelEspecialidadEfector.Columns.IdEfector, IdEfector).Load();
					colSysRelEspecialidadEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelEspecialidadEfectorRecords_ListChanged);
				}
				return colSysRelEspecialidadEfectorRecords;			
			}
			set 
			{ 
					colSysRelEspecialidadEfectorRecords = value; 
					colSysRelEspecialidadEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelEspecialidadEfectorRecords_ListChanged);
			}
		}
		
		void colSysRelEspecialidadEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelEspecialidadEfectorRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.SysRelHistoriaClinicaEfectorCollection colSysRelHistoriaClinicaEfectorRecords;
		public DalSic.SysRelHistoriaClinicaEfectorCollection SysRelHistoriaClinicaEfectorRecords
		{
			get
			{
				if(colSysRelHistoriaClinicaEfectorRecords == null)
				{
					colSysRelHistoriaClinicaEfectorRecords = new DalSic.SysRelHistoriaClinicaEfectorCollection().Where(SysRelHistoriaClinicaEfector.Columns.IdEfector, IdEfector).Load();
					colSysRelHistoriaClinicaEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelHistoriaClinicaEfectorRecords_ListChanged);
				}
				return colSysRelHistoriaClinicaEfectorRecords;			
			}
			set 
			{ 
					colSysRelHistoriaClinicaEfectorRecords = value; 
					colSysRelHistoriaClinicaEfectorRecords.ListChanged += new ListChangedEventHandler(colSysRelHistoriaClinicaEfectorRecords_ListChanged);
			}
		}
		
		void colSysRelHistoriaClinicaEfectorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelHistoriaClinicaEfectorRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografia;
		public DalSic.MamEcografiumCollection MamEcografia
		{
			get
			{
				if(colMamEcografia == null)
				{
					colMamEcografia = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdEfectorRealizaEstudio, IdEfector).Load();
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
		        colMamEcografia[e.NewIndex].IdEfectorRealizaEstudio = IdEfector;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografiaFromSysEfector;
		public DalSic.MamEcografiumCollection MamEcografiaFromSysEfector
		{
			get
			{
				if(colMamEcografiaFromSysEfector == null)
				{
					colMamEcografiaFromSysEfector = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdEfectorSolicita, IdEfector).Load();
					colMamEcografiaFromSysEfector.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysEfector_ListChanged);
				}
				return colMamEcografiaFromSysEfector;			
			}
			set 
			{ 
					colMamEcografiaFromSysEfector = value; 
					colMamEcografiaFromSysEfector.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysEfector_ListChanged);
			}
		}
		
		void colMamEcografiaFromSysEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografiaFromSysEfector[e.NewIndex].IdEfectorSolicita = IdEfector;
		    }
		}
				
		private DalSic.AprHistoriaClinicaPerinatalCollection colAprHistoriaClinicaPerinatalRecords;
		public DalSic.AprHistoriaClinicaPerinatalCollection AprHistoriaClinicaPerinatalRecords
		{
			get
			{
				if(colAprHistoriaClinicaPerinatalRecords == null)
				{
					colAprHistoriaClinicaPerinatalRecords = new DalSic.AprHistoriaClinicaPerinatalCollection().Where(AprHistoriaClinicaPerinatal.Columns.IdEfectorTrasladoUt, IdEfector).Load();
					colAprHistoriaClinicaPerinatalRecords.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalRecords_ListChanged);
				}
				return colAprHistoriaClinicaPerinatalRecords;			
			}
			set 
			{ 
					colAprHistoriaClinicaPerinatalRecords = value; 
					colAprHistoriaClinicaPerinatalRecords.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalRecords_ListChanged);
			}
		}
		
		void colAprHistoriaClinicaPerinatalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprHistoriaClinicaPerinatalRecords[e.NewIndex].IdEfectorTrasladoUt = IdEfector;
		    }
		}
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionalesFromSysEfector;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionalesFromSysEfector
		{
			get
			{
				if(colMamEstudiosAdicionalesFromSysEfector == null)
				{
					colMamEstudiosAdicionalesFromSysEfector = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdEfectorRealizaEstudio, IdEfector).Load();
					colMamEstudiosAdicionalesFromSysEfector.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromSysEfector_ListChanged);
				}
				return colMamEstudiosAdicionalesFromSysEfector;			
			}
			set 
			{ 
					colMamEstudiosAdicionalesFromSysEfector = value; 
					colMamEstudiosAdicionalesFromSysEfector.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromSysEfector_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionalesFromSysEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionalesFromSysEfector[e.NewIndex].IdEfectorRealizaEstudio = IdEfector;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecords;
		public DalSic.MamRegistroCollection MamRegistroRecords
		{
			get
			{
				if(colMamRegistroRecords == null)
				{
					colMamRegistroRecords = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdEfectorRealizaEstudio, IdEfector).Load();
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
		        colMamRegistroRecords[e.NewIndex].IdEfectorRealizaEstudio = IdEfector;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecordsFromSysEfector;
		public DalSic.MamRegistroCollection MamRegistroRecordsFromSysEfector
		{
			get
			{
				if(colMamRegistroRecordsFromSysEfector == null)
				{
					colMamRegistroRecordsFromSysEfector = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdEfectorControl, IdEfector).Load();
					colMamRegistroRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysEfector_ListChanged);
				}
				return colMamRegistroRecordsFromSysEfector;			
			}
			set 
			{ 
					colMamRegistroRecordsFromSysEfector = value; 
					colMamRegistroRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysEfector_ListChanged);
			}
		}
		
		void colMamRegistroRecordsFromSysEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecordsFromSysEfector[e.NewIndex].IdEfectorControl = IdEfector;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia;
		public DalSic.MamRegistroCollection MamRegistroRecordsFromSysEfectorIdEfectorProcedencia
		{
			get
			{
				if(colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia == null)
				{
					colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdEfectorProcedencia, IdEfector).Load();
					colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia_ListChanged);
				}
				return colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia;			
			}
			set 
			{ 
					colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia = value; 
					colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia_ListChanged);
			}
		}
		
		void colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia[e.NewIndex].IdEfectorProcedencia = IdEfector;
		    }
		}
				
		private DalSic.AprHistoriaClinicaPerinatalCollection colAprHistoriaClinicaPerinatalRecordsFromSysEfector;
		public DalSic.AprHistoriaClinicaPerinatalCollection AprHistoriaClinicaPerinatalRecordsFromSysEfector
		{
			get
			{
				if(colAprHistoriaClinicaPerinatalRecordsFromSysEfector == null)
				{
					colAprHistoriaClinicaPerinatalRecordsFromSysEfector = new DalSic.AprHistoriaClinicaPerinatalCollection().Where(AprHistoriaClinicaPerinatal.Columns.IdEfectorTrasladoUt, IdEfector).Load();
					colAprHistoriaClinicaPerinatalRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalRecordsFromSysEfector_ListChanged);
				}
				return colAprHistoriaClinicaPerinatalRecordsFromSysEfector;			
			}
			set 
			{ 
					colAprHistoriaClinicaPerinatalRecordsFromSysEfector = value; 
					colAprHistoriaClinicaPerinatalRecordsFromSysEfector.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalRecordsFromSysEfector_ListChanged);
			}
		}
		
		void colAprHistoriaClinicaPerinatalRecordsFromSysEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprHistoriaClinicaPerinatalRecordsFromSysEfector[e.NewIndex].IdEfectorTrasladoUt = IdEfector;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografiaFromSysEfectorIdEfectorInforma;
		public DalSic.MamEcografiumCollection MamEcografiaFromSysEfectorIdEfectorInforma
		{
			get
			{
				if(colMamEcografiaFromSysEfectorIdEfectorInforma == null)
				{
					colMamEcografiaFromSysEfectorIdEfectorInforma = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdEfectorInforma, IdEfector).Load();
					colMamEcografiaFromSysEfectorIdEfectorInforma.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysEfectorIdEfectorInforma_ListChanged);
				}
				return colMamEcografiaFromSysEfectorIdEfectorInforma;			
			}
			set 
			{ 
					colMamEcografiaFromSysEfectorIdEfectorInforma = value; 
					colMamEcografiaFromSysEfectorIdEfectorInforma.ListChanged += new ListChangedEventHandler(colMamEcografiaFromSysEfectorIdEfectorInforma_ListChanged);
			}
		}
		
		void colMamEcografiaFromSysEfectorIdEfectorInforma_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografiaFromSysEfectorIdEfectorInforma[e.NewIndex].IdEfectorInforma = IdEfector;
		    }
		}
				
		private DalSic.MamAntecedenteCollection colMamAntecedentes;
		public DalSic.MamAntecedenteCollection MamAntecedentes
		{
			get
			{
				if(colMamAntecedentes == null)
				{
					colMamAntecedentes = new DalSic.MamAntecedenteCollection().Where(MamAntecedente.Columns.IdEfector, IdEfector).Load();
					colMamAntecedentes.ListChanged += new ListChangedEventHandler(colMamAntecedentes_ListChanged);
				}
				return colMamAntecedentes;			
			}
			set 
			{ 
					colMamAntecedentes = value; 
					colMamAntecedentes.ListChanged += new ListChangedEventHandler(colMamAntecedentes_ListChanged);
			}
		}
		
		void colMamAntecedentes_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamAntecedentes[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.SysUsuarioCollection colSysUsuarioRecords;
		public DalSic.SysUsuarioCollection SysUsuarioRecords
		{
			get
			{
				if(colSysUsuarioRecords == null)
				{
					colSysUsuarioRecords = new DalSic.SysUsuarioCollection().Where(SysUsuario.Columns.IdEfector, IdEfector).Load();
					colSysUsuarioRecords.ListChanged += new ListChangedEventHandler(colSysUsuarioRecords_ListChanged);
				}
				return colSysUsuarioRecords;			
			}
			set 
			{ 
					colSysUsuarioRecords = value; 
					colSysUsuarioRecords.ListChanged += new ListChangedEventHandler(colSysUsuarioRecords_ListChanged);
			}
		}
		
		void colSysUsuarioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysUsuarioRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.AprActividadFisicaCollection colAprActividadFisicaRecords;
		public DalSic.AprActividadFisicaCollection AprActividadFisicaRecords
		{
			get
			{
				if(colAprActividadFisicaRecords == null)
				{
					colAprActividadFisicaRecords = new DalSic.AprActividadFisicaCollection().Where(AprActividadFisica.Columns.IdEfector, IdEfector).Load();
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
		        colAprActividadFisicaRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamEstadioClinicoCollection colMamEstadioClinicoRecords;
		public DalSic.MamEstadioClinicoCollection MamEstadioClinicoRecords
		{
			get
			{
				if(colMamEstadioClinicoRecords == null)
				{
					colMamEstadioClinicoRecords = new DalSic.MamEstadioClinicoCollection().Where(MamEstadioClinico.Columns.IdCentroSalud, IdEfector).Load();
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
		        colMamEstadioClinicoRecords[e.NewIndex].IdCentroSalud = IdEfector;
		    }
		}
				
		private DalSic.MamExamenFisicoCollection colMamExamenFisicoRecords;
		public DalSic.MamExamenFisicoCollection MamExamenFisicoRecords
		{
			get
			{
				if(colMamExamenFisicoRecords == null)
				{
					colMamExamenFisicoRecords = new DalSic.MamExamenFisicoCollection().Where(MamExamenFisico.Columns.IdCentroSalud, IdEfector).Load();
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
		        colMamExamenFisicoRecords[e.NewIndex].IdCentroSalud = IdEfector;
		    }
		}
				
		private DalSic.ConAgendaCollection colConAgendaRecords;
		public DalSic.ConAgendaCollection ConAgendaRecords
		{
			get
			{
				if(colConAgendaRecords == null)
				{
					colConAgendaRecords = new DalSic.ConAgendaCollection().Where(ConAgenda.Columns.IdEfector, IdEfector).Load();
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
		        colConAgendaRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.MamTratamientoCollection colMamTratamientos;
		public DalSic.MamTratamientoCollection MamTratamientos
		{
			get
			{
				if(colMamTratamientos == null)
				{
					colMamTratamientos = new DalSic.MamTratamientoCollection().Where(MamTratamiento.Columns.IdCentroSalud, IdEfector).Load();
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
		        colMamTratamientos[e.NewIndex].IdCentroSalud = IdEfector;
		    }
		}
				
		private DalSic.AprHistoriaClinicaPerinatalCollection colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector;
		public DalSic.AprHistoriaClinicaPerinatalCollection AprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector
		{
			get
			{
				if(colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector == null)
				{
					colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector = new DalSic.AprHistoriaClinicaPerinatalCollection().Where(AprHistoriaClinicaPerinatal.Columns.IdEfector, IdEfector).Load();
					colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector_ListChanged);
				}
				return colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector;			
			}
			set 
			{ 
					colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector = value; 
					colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector.ListChanged += new ListChangedEventHandler(colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector_ListChanged);
			}
		}
		
		void colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.SysProfesionalCollection colSysProfesionalRecords;
		public DalSic.SysProfesionalCollection SysProfesionalRecords
		{
			get
			{
				if(colSysProfesionalRecords == null)
				{
					colSysProfesionalRecords = new DalSic.SysProfesionalCollection().Where(SysProfesional.Columns.IdEfector, IdEfector).Load();
					colSysProfesionalRecords.ListChanged += new ListChangedEventHandler(colSysProfesionalRecords_ListChanged);
				}
				return colSysProfesionalRecords;			
			}
			set 
			{ 
					colSysProfesionalRecords = value; 
					colSysProfesionalRecords.ListChanged += new ListChangedEventHandler(colSysProfesionalRecords_ListChanged);
			}
		}
		
		void colSysProfesionalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysProfesionalRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
				
		private DalSic.RemFormularioCollection colRemFormularioRecords;
		public DalSic.RemFormularioCollection RemFormularioRecords
		{
			get
			{
				if(colRemFormularioRecords == null)
				{
					colRemFormularioRecords = new DalSic.RemFormularioCollection().Where(RemFormulario.Columns.IdEfector, IdEfector).Load();
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
		        colRemFormularioRecords[e.NewIndex].IdEfector = IdEfector;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this SysEfector
		/// 
		/// </summary>
		public DalSic.SysEfector ParentSysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfectorSuperior); }
			set { SetColumnValue("idEfectorSuperior", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysZona ActiveRecord object related to this SysEfector
		/// 
		/// </summary>
		public DalSic.SysZona SysZona
		{
			get { return DalSic.SysZona.FetchByID(this.IdZona); }
			set { SetColumnValue("idZona", value.IdZona); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdZona,string varNombreNacion,string varComplejidad,int varIdEfectorSuperior,string varDomicilio,string varTelefono,string varReponsable,string varCodigoRemediar,string varCuie,int? varIdTipoEfector,string varCodigoSisa)
		{
			SysEfector item = new SysEfector();
			
			item.Nombre = varNombre;
			
			item.IdZona = varIdZona;
			
			item.NombreNacion = varNombreNacion;
			
			item.Complejidad = varComplejidad;
			
			item.IdEfectorSuperior = varIdEfectorSuperior;
			
			item.Domicilio = varDomicilio;
			
			item.Telefono = varTelefono;
			
			item.Reponsable = varReponsable;
			
			item.CodigoRemediar = varCodigoRemediar;
			
			item.Cuie = varCuie;
			
			item.IdTipoEfector = varIdTipoEfector;
			
			item.CodigoSisa = varCodigoSisa;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEfector,string varNombre,int varIdZona,string varNombreNacion,string varComplejidad,int varIdEfectorSuperior,string varDomicilio,string varTelefono,string varReponsable,string varCodigoRemediar,string varCuie,int? varIdTipoEfector,string varCodigoSisa)
		{
			SysEfector item = new SysEfector();
			
				item.IdEfector = varIdEfector;
			
				item.Nombre = varNombre;
			
				item.IdZona = varIdZona;
			
				item.NombreNacion = varNombreNacion;
			
				item.Complejidad = varComplejidad;
			
				item.IdEfectorSuperior = varIdEfectorSuperior;
			
				item.Domicilio = varDomicilio;
			
				item.Telefono = varTelefono;
			
				item.Reponsable = varReponsable;
			
				item.CodigoRemediar = varCodigoRemediar;
			
				item.Cuie = varCuie;
			
				item.IdTipoEfector = varIdTipoEfector;
			
				item.CodigoSisa = varCodigoSisa;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdZonaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreNacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ComplejidadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorSuperiorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ReponsableColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoRemediarColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoEfectorColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoSisaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEfector = @"idEfector";
			 public static string Nombre = @"nombre";
			 public static string IdZona = @"idZona";
			 public static string NombreNacion = @"nombreNacion";
			 public static string Complejidad = @"complejidad";
			 public static string IdEfectorSuperior = @"idEfectorSuperior";
			 public static string Domicilio = @"domicilio";
			 public static string Telefono = @"telefono";
			 public static string Reponsable = @"reponsable";
			 public static string CodigoRemediar = @"codigoRemediar";
			 public static string Cuie = @"cuie";
			 public static string IdTipoEfector = @"idTipoEfector";
			 public static string CodigoSisa = @"codigoSisa";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colTabControlRecords != null)
                {
                    foreach (DalSic.TabControl item in colTabControlRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colAprControlOdontologicoRecords != null)
                {
                    foreach (DalSic.AprControlOdontologico item in colAprControlOdontologicoRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamEstudiosHospitalProvincialRecords != null)
                {
                    foreach (DalSic.MamEstudiosHospitalProvincial item in colMamEstudiosHospitalProvincialRecords)
                    {
                        if (item.SolicitudCentroSalud != IdEfector)
                        {
                            item.SolicitudCentroSalud = IdEfector;
                        }
                    }
               }
		
                if (colAprPartoProvisorioRecords != null)
                {
                    foreach (DalSic.AprPartoProvisorio item in colAprPartoProvisorioRecords)
                    {
                        if (item.IdEfectorParto != IdEfector)
                        {
                            item.IdEfectorParto = IdEfector;
                        }
                    }
               }
		
                if (colAprInterconsulta != null)
                {
                    foreach (DalSic.AprInterconsultum item in colAprInterconsulta)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colSysRelServicioEfectorRecords != null)
                {
                    foreach (DalSic.SysRelServicioEfector item in colSysRelServicioEfectorRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamCirugia != null)
                {
                    foreach (DalSic.MamCirugium item in colMamCirugia)
                    {
                        if (item.IdCentroSalud != IdEfector)
                        {
                            item.IdCentroSalud = IdEfector;
                        }
                    }
               }
		
                if (colConConsultorioTipoRecords != null)
                {
                    foreach (DalSic.ConConsultorioTipo item in colConConsultorioTipoRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colConAgendaGrupalRecords != null)
                {
                    foreach (DalSic.ConAgendaGrupal item in colConAgendaGrupalRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colLabSolicitudScreeningRecords != null)
                {
                    foreach (DalSic.LabSolicitudScreening item in colLabSolicitudScreeningRecords)
                    {
                        if (item.IdEfectorSolicitante != IdEfector)
                        {
                            item.IdEfectorSolicitante = IdEfector;
                        }
                    }
               }
		
                if (colLabSolicitudScreeningRecordsFromSysEfector != null)
                {
                    foreach (DalSic.LabSolicitudScreening item in colLabSolicitudScreeningRecordsFromSysEfector)
                    {
                        if (item.IdLugarControl != IdEfector)
                        {
                            item.IdLugarControl = IdEfector;
                        }
                    }
               }
		
                if (colMamAnatomiaPatologicaRecords != null)
                {
                    foreach (DalSic.MamAnatomiaPatologica item in colMamAnatomiaPatologicaRecords)
                    {
                        if (item.IdCentroSaludInforme != IdEfector)
                        {
                            item.IdCentroSaludInforme = IdEfector;
                        }
                    }
               }
		
                if (colMamAnatomiaPatologicaRecordsFromSysEfector != null)
                {
                    foreach (DalSic.MamAnatomiaPatologica item in colMamAnatomiaPatologicaRecordsFromSysEfector)
                    {
                        if (item.IdCentroSaludMuestra != IdEfector)
                        {
                            item.IdCentroSaludMuestra = IdEfector;
                        }
                    }
               }
		
                if (colFacJefeLaboratorioRecords != null)
                {
                    foreach (DalSic.FacJefeLaboratorio item in colFacJefeLaboratorioRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colRemClasificacionRecords != null)
                {
                    foreach (DalSic.RemClasificacion item in colRemClasificacionRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colAprActividadControlPerinatalRecords != null)
                {
                    foreach (DalSic.AprActividadControlPerinatal item in colAprActividadControlPerinatalRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamPiezaQuirurgicaRecords != null)
                {
                    foreach (DalSic.MamPiezaQuirurgica item in colMamPiezaQuirurgicaRecords)
                    {
                        if (item.IdCentroSaludInforme != IdEfector)
                        {
                            item.IdCentroSaludInforme = IdEfector;
                        }
                    }
               }
		
                if (colConTurnoReservaInterconsulta != null)
                {
                    foreach (DalSic.ConTurnoReservaInterconsultum item in colConTurnoReservaInterconsulta)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamEstudiosAdicionales != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionales)
                    {
                        if (item.IdCentroSalud != IdEfector)
                        {
                            item.IdCentroSalud = IdEfector;
                        }
                    }
               }
		
                if (colChildSysEfectorRecords != null)
                {
                    foreach (DalSic.SysEfector item in colChildSysEfectorRecords)
                    {
                        if (item.IdEfectorSuperior != IdEfector)
                        {
                            item.IdEfectorSuperior = IdEfector;
                        }
                    }
               }
		
                if (colSysRelProfesionalEfectorRecords != null)
                {
                    foreach (DalSic.SysRelProfesionalEfector item in colSysRelProfesionalEfectorRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colSysEstablecimientoRecords != null)
                {
                    foreach (DalSic.SysEstablecimiento item in colSysEstablecimientoRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colSysRelEspecialidadEfectorRecords != null)
                {
                    foreach (DalSic.SysRelEspecialidadEfector item in colSysRelEspecialidadEfectorRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colSysRelHistoriaClinicaEfectorRecords != null)
                {
                    foreach (DalSic.SysRelHistoriaClinicaEfector item in colSysRelHistoriaClinicaEfectorRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamEcografia != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografia)
                    {
                        if (item.IdEfectorRealizaEstudio != IdEfector)
                        {
                            item.IdEfectorRealizaEstudio = IdEfector;
                        }
                    }
               }
		
                if (colMamEcografiaFromSysEfector != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografiaFromSysEfector)
                    {
                        if (item.IdEfectorSolicita != IdEfector)
                        {
                            item.IdEfectorSolicita = IdEfector;
                        }
                    }
               }
		
                if (colAprHistoriaClinicaPerinatalRecords != null)
                {
                    foreach (DalSic.AprHistoriaClinicaPerinatal item in colAprHistoriaClinicaPerinatalRecords)
                    {
                        if (item.IdEfectorTrasladoUt != IdEfector)
                        {
                            item.IdEfectorTrasladoUt = IdEfector;
                        }
                    }
               }
		
                if (colMamEstudiosAdicionalesFromSysEfector != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionalesFromSysEfector)
                    {
                        if (item.IdEfectorRealizaEstudio != IdEfector)
                        {
                            item.IdEfectorRealizaEstudio = IdEfector;
                        }
                    }
               }
		
                if (colMamRegistroRecords != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecords)
                    {
                        if (item.IdEfectorRealizaEstudio != IdEfector)
                        {
                            item.IdEfectorRealizaEstudio = IdEfector;
                        }
                    }
               }
		
                if (colMamRegistroRecordsFromSysEfector != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecordsFromSysEfector)
                    {
                        if (item.IdEfectorControl != IdEfector)
                        {
                            item.IdEfectorControl = IdEfector;
                        }
                    }
               }
		
                if (colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia)
                    {
                        if (item.IdEfectorProcedencia != IdEfector)
                        {
                            item.IdEfectorProcedencia = IdEfector;
                        }
                    }
               }
		
                if (colAprHistoriaClinicaPerinatalRecordsFromSysEfector != null)
                {
                    foreach (DalSic.AprHistoriaClinicaPerinatal item in colAprHistoriaClinicaPerinatalRecordsFromSysEfector)
                    {
                        if (item.IdEfectorTrasladoUt != IdEfector)
                        {
                            item.IdEfectorTrasladoUt = IdEfector;
                        }
                    }
               }
		
                if (colMamEcografiaFromSysEfectorIdEfectorInforma != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografiaFromSysEfectorIdEfectorInforma)
                    {
                        if (item.IdEfectorInforma != IdEfector)
                        {
                            item.IdEfectorInforma = IdEfector;
                        }
                    }
               }
		
                if (colMamAntecedentes != null)
                {
                    foreach (DalSic.MamAntecedente item in colMamAntecedentes)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colSysUsuarioRecords != null)
                {
                    foreach (DalSic.SysUsuario item in colSysUsuarioRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colAprActividadFisicaRecords != null)
                {
                    foreach (DalSic.AprActividadFisica item in colAprActividadFisicaRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamEstadioClinicoRecords != null)
                {
                    foreach (DalSic.MamEstadioClinico item in colMamEstadioClinicoRecords)
                    {
                        if (item.IdCentroSalud != IdEfector)
                        {
                            item.IdCentroSalud = IdEfector;
                        }
                    }
               }
		
                if (colMamExamenFisicoRecords != null)
                {
                    foreach (DalSic.MamExamenFisico item in colMamExamenFisicoRecords)
                    {
                        if (item.IdCentroSalud != IdEfector)
                        {
                            item.IdCentroSalud = IdEfector;
                        }
                    }
               }
		
                if (colConAgendaRecords != null)
                {
                    foreach (DalSic.ConAgenda item in colConAgendaRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colMamTratamientos != null)
                {
                    foreach (DalSic.MamTratamiento item in colMamTratamientos)
                    {
                        if (item.IdCentroSalud != IdEfector)
                        {
                            item.IdCentroSalud = IdEfector;
                        }
                    }
               }
		
                if (colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector != null)
                {
                    foreach (DalSic.AprHistoriaClinicaPerinatal item in colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colSysProfesionalRecords != null)
                {
                    foreach (DalSic.SysProfesional item in colSysProfesionalRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
                        }
                    }
               }
		
                if (colRemFormularioRecords != null)
                {
                    foreach (DalSic.RemFormulario item in colRemFormularioRecords)
                    {
                        if (item.IdEfector != IdEfector)
                        {
                            item.IdEfector = IdEfector;
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
		
                if (colAprControlOdontologicoRecords != null)
                {
                    colAprControlOdontologicoRecords.SaveAll();
               }
		
                if (colMamEstudiosHospitalProvincialRecords != null)
                {
                    colMamEstudiosHospitalProvincialRecords.SaveAll();
               }
		
                if (colAprPartoProvisorioRecords != null)
                {
                    colAprPartoProvisorioRecords.SaveAll();
               }
		
                if (colAprInterconsulta != null)
                {
                    colAprInterconsulta.SaveAll();
               }
		
                if (colSysRelServicioEfectorRecords != null)
                {
                    colSysRelServicioEfectorRecords.SaveAll();
               }
		
                if (colMamCirugia != null)
                {
                    colMamCirugia.SaveAll();
               }
		
                if (colConConsultorioTipoRecords != null)
                {
                    colConConsultorioTipoRecords.SaveAll();
               }
		
                if (colConAgendaGrupalRecords != null)
                {
                    colConAgendaGrupalRecords.SaveAll();
               }
		
                if (colLabSolicitudScreeningRecords != null)
                {
                    colLabSolicitudScreeningRecords.SaveAll();
               }
		
                if (colLabSolicitudScreeningRecordsFromSysEfector != null)
                {
                    colLabSolicitudScreeningRecordsFromSysEfector.SaveAll();
               }
		
                if (colMamAnatomiaPatologicaRecords != null)
                {
                    colMamAnatomiaPatologicaRecords.SaveAll();
               }
		
                if (colMamAnatomiaPatologicaRecordsFromSysEfector != null)
                {
                    colMamAnatomiaPatologicaRecordsFromSysEfector.SaveAll();
               }
		
                if (colFacJefeLaboratorioRecords != null)
                {
                    colFacJefeLaboratorioRecords.SaveAll();
               }
		
                if (colRemClasificacionRecords != null)
                {
                    colRemClasificacionRecords.SaveAll();
               }
		
                if (colAprActividadControlPerinatalRecords != null)
                {
                    colAprActividadControlPerinatalRecords.SaveAll();
               }
		
                if (colMamPiezaQuirurgicaRecords != null)
                {
                    colMamPiezaQuirurgicaRecords.SaveAll();
               }
		
                if (colConTurnoReservaInterconsulta != null)
                {
                    colConTurnoReservaInterconsulta.SaveAll();
               }
		
                if (colMamEstudiosAdicionales != null)
                {
                    colMamEstudiosAdicionales.SaveAll();
               }
		
                if (colChildSysEfectorRecords != null)
                {
                    colChildSysEfectorRecords.SaveAll();
               }
		
                if (colSysRelProfesionalEfectorRecords != null)
                {
                    colSysRelProfesionalEfectorRecords.SaveAll();
               }
		
                if (colSysEstablecimientoRecords != null)
                {
                    colSysEstablecimientoRecords.SaveAll();
               }
		
                if (colSysRelEspecialidadEfectorRecords != null)
                {
                    colSysRelEspecialidadEfectorRecords.SaveAll();
               }
		
                if (colSysRelHistoriaClinicaEfectorRecords != null)
                {
                    colSysRelHistoriaClinicaEfectorRecords.SaveAll();
               }
		
                if (colMamEcografia != null)
                {
                    colMamEcografia.SaveAll();
               }
		
                if (colMamEcografiaFromSysEfector != null)
                {
                    colMamEcografiaFromSysEfector.SaveAll();
               }
		
                if (colAprHistoriaClinicaPerinatalRecords != null)
                {
                    colAprHistoriaClinicaPerinatalRecords.SaveAll();
               }
		
                if (colMamEstudiosAdicionalesFromSysEfector != null)
                {
                    colMamEstudiosAdicionalesFromSysEfector.SaveAll();
               }
		
                if (colMamRegistroRecords != null)
                {
                    colMamRegistroRecords.SaveAll();
               }
		
                if (colMamRegistroRecordsFromSysEfector != null)
                {
                    colMamRegistroRecordsFromSysEfector.SaveAll();
               }
		
                if (colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia != null)
                {
                    colMamRegistroRecordsFromSysEfectorIdEfectorProcedencia.SaveAll();
               }
		
                if (colAprHistoriaClinicaPerinatalRecordsFromSysEfector != null)
                {
                    colAprHistoriaClinicaPerinatalRecordsFromSysEfector.SaveAll();
               }
		
                if (colMamEcografiaFromSysEfectorIdEfectorInforma != null)
                {
                    colMamEcografiaFromSysEfectorIdEfectorInforma.SaveAll();
               }
		
                if (colMamAntecedentes != null)
                {
                    colMamAntecedentes.SaveAll();
               }
		
                if (colSysUsuarioRecords != null)
                {
                    colSysUsuarioRecords.SaveAll();
               }
		
                if (colAprActividadFisicaRecords != null)
                {
                    colAprActividadFisicaRecords.SaveAll();
               }
		
                if (colMamEstadioClinicoRecords != null)
                {
                    colMamEstadioClinicoRecords.SaveAll();
               }
		
                if (colMamExamenFisicoRecords != null)
                {
                    colMamExamenFisicoRecords.SaveAll();
               }
		
                if (colConAgendaRecords != null)
                {
                    colConAgendaRecords.SaveAll();
               }
		
                if (colMamTratamientos != null)
                {
                    colMamTratamientos.SaveAll();
               }
		
                if (colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector != null)
                {
                    colAprHistoriaClinicaPerinatalRecordsFromSysEfectorIdEfector.SaveAll();
               }
		
                if (colSysProfesionalRecords != null)
                {
                    colSysProfesionalRecords.SaveAll();
               }
		
                if (colRemFormularioRecords != null)
                {
                    colRemFormularioRecords.SaveAll();
               }
		}
        #endregion
	}
}
