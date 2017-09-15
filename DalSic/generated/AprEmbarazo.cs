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
	/// Strongly-typed collection for the AprEmbarazo class.
	/// </summary>
    [Serializable]
	public partial class AprEmbarazoCollection : ActiveList<AprEmbarazo, AprEmbarazoCollection>
	{	   
		public AprEmbarazoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprEmbarazoCollection</returns>
		public AprEmbarazoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprEmbarazo o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_Embarazo table.
	/// </summary>
	[Serializable]
	public partial class AprEmbarazo : ActiveRecord<AprEmbarazo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprEmbarazo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprEmbarazo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprEmbarazo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprEmbarazo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_Embarazo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdEmbarazo.ColumnName = "idEmbarazo";
				colvarIdEmbarazo.DataType = DbType.Int32;
				colvarIdEmbarazo.MaxLength = 0;
				colvarIdEmbarazo.AutoIncrement = true;
				colvarIdEmbarazo.IsNullable = false;
				colvarIdEmbarazo.IsPrimaryKey = true;
				colvarIdEmbarazo.IsForeignKey = false;
				colvarIdEmbarazo.IsReadOnly = false;
				colvarIdEmbarazo.DefaultSetting = @"";
				colvarIdEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEmbarazo);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
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
				
				TableSchema.TableColumn colvarPlaneado = new TableSchema.TableColumn(schema);
				colvarPlaneado.ColumnName = "Planeado";
				colvarPlaneado.DataType = DbType.Boolean;
				colvarPlaneado.MaxLength = 0;
				colvarPlaneado.AutoIncrement = false;
				colvarPlaneado.IsNullable = true;
				colvarPlaneado.IsPrimaryKey = false;
				colvarPlaneado.IsForeignKey = false;
				colvarPlaneado.IsReadOnly = false;
				colvarPlaneado.DefaultSetting = @"";
				colvarPlaneado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlaneado);
				
				TableSchema.TableColumn colvarIdFracasoMetodoAnticonceptivo = new TableSchema.TableColumn(schema);
				colvarIdFracasoMetodoAnticonceptivo.ColumnName = "idFracasoMetodoAnticonceptivo";
				colvarIdFracasoMetodoAnticonceptivo.DataType = DbType.Int32;
				colvarIdFracasoMetodoAnticonceptivo.MaxLength = 0;
				colvarIdFracasoMetodoAnticonceptivo.AutoIncrement = false;
				colvarIdFracasoMetodoAnticonceptivo.IsNullable = true;
				colvarIdFracasoMetodoAnticonceptivo.IsPrimaryKey = false;
				colvarIdFracasoMetodoAnticonceptivo.IsForeignKey = false;
				colvarIdFracasoMetodoAnticonceptivo.IsReadOnly = false;
				colvarIdFracasoMetodoAnticonceptivo.DefaultSetting = @"";
				colvarIdFracasoMetodoAnticonceptivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFracasoMetodoAnticonceptivo);
				
				TableSchema.TableColumn colvarFum = new TableSchema.TableColumn(schema);
				colvarFum.ColumnName = "FUM";
				colvarFum.DataType = DbType.DateTime;
				colvarFum.MaxLength = 0;
				colvarFum.AutoIncrement = false;
				colvarFum.IsNullable = false;
				colvarFum.IsPrimaryKey = false;
				colvarFum.IsForeignKey = false;
				colvarFum.IsReadOnly = false;
				colvarFum.DefaultSetting = @"";
				colvarFum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFum);
				
				TableSchema.TableColumn colvarFpp = new TableSchema.TableColumn(schema);
				colvarFpp.ColumnName = "FPP";
				colvarFpp.DataType = DbType.DateTime;
				colvarFpp.MaxLength = 0;
				colvarFpp.AutoIncrement = false;
				colvarFpp.IsNullable = false;
				colvarFpp.IsPrimaryKey = false;
				colvarFpp.IsForeignKey = false;
				colvarFpp.IsReadOnly = false;
				colvarFpp.DefaultSetting = @"";
				colvarFpp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFpp);
				
				TableSchema.TableColumn colvarPesoAnterior = new TableSchema.TableColumn(schema);
				colvarPesoAnterior.ColumnName = "PesoAnterior";
				colvarPesoAnterior.DataType = DbType.Double;
				colvarPesoAnterior.MaxLength = 0;
				colvarPesoAnterior.AutoIncrement = false;
				colvarPesoAnterior.IsNullable = true;
				colvarPesoAnterior.IsPrimaryKey = false;
				colvarPesoAnterior.IsForeignKey = false;
				colvarPesoAnterior.IsReadOnly = false;
				colvarPesoAnterior.DefaultSetting = @"";
				colvarPesoAnterior.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPesoAnterior);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "Talla";
				colvarTalla.DataType = DbType.Double;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = true;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_Embarazo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEmbarazo")]
		[Bindable(true)]
		public int IdEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdEmbarazo); }
			set { SetColumnValue(Columns.IdEmbarazo, value); }
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
		  
		[XmlAttribute("Planeado")]
		[Bindable(true)]
		public bool? Planeado 
		{
			get { return GetColumnValue<bool?>(Columns.Planeado); }
			set { SetColumnValue(Columns.Planeado, value); }
		}
		  
		[XmlAttribute("IdFracasoMetodoAnticonceptivo")]
		[Bindable(true)]
		public int? IdFracasoMetodoAnticonceptivo 
		{
			get { return GetColumnValue<int?>(Columns.IdFracasoMetodoAnticonceptivo); }
			set { SetColumnValue(Columns.IdFracasoMetodoAnticonceptivo, value); }
		}
		  
		[XmlAttribute("Fum")]
		[Bindable(true)]
		public DateTime Fum 
		{
			get { return GetColumnValue<DateTime>(Columns.Fum); }
			set { SetColumnValue(Columns.Fum, value); }
		}
		  
		[XmlAttribute("Fpp")]
		[Bindable(true)]
		public DateTime Fpp 
		{
			get { return GetColumnValue<DateTime>(Columns.Fpp); }
			set { SetColumnValue(Columns.Fpp, value); }
		}
		  
		[XmlAttribute("PesoAnterior")]
		[Bindable(true)]
		public double? PesoAnterior 
		{
			get { return GetColumnValue<double?>(Columns.PesoAnterior); }
			set { SetColumnValue(Columns.PesoAnterior, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public double? Talla 
		{
			get { return GetColumnValue<double?>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprEgresoMaternoCollection colAprEgresoMaternoRecords;
		public DalSic.AprEgresoMaternoCollection AprEgresoMaternoRecords
		{
			get
			{
				if(colAprEgresoMaternoRecords == null)
				{
					colAprEgresoMaternoRecords = new DalSic.AprEgresoMaternoCollection().Where(AprEgresoMaterno.Columns.IdEmbarazo, IdEmbarazo).Load();
					colAprEgresoMaternoRecords.ListChanged += new ListChangedEventHandler(colAprEgresoMaternoRecords_ListChanged);
				}
				return colAprEgresoMaternoRecords;			
			}
			set 
			{ 
					colAprEgresoMaternoRecords = value; 
					colAprEgresoMaternoRecords.ListChanged += new ListChangedEventHandler(colAprEgresoMaternoRecords_ListChanged);
			}
		}
		
		void colAprEgresoMaternoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprEgresoMaternoRecords[e.NewIndex].IdEmbarazo = IdEmbarazo;
		    }
		}
				
		private DalSic.AprEstiloVidaCollection colAprEstiloVidaRecords;
		public DalSic.AprEstiloVidaCollection AprEstiloVidaRecords
		{
			get
			{
				if(colAprEstiloVidaRecords == null)
				{
					colAprEstiloVidaRecords = new DalSic.AprEstiloVidaCollection().Where(AprEstiloVida.Columns.IdEmbarazo, IdEmbarazo).Load();
					colAprEstiloVidaRecords.ListChanged += new ListChangedEventHandler(colAprEstiloVidaRecords_ListChanged);
				}
				return colAprEstiloVidaRecords;			
			}
			set 
			{ 
					colAprEstiloVidaRecords = value; 
					colAprEstiloVidaRecords.ListChanged += new ListChangedEventHandler(colAprEstiloVidaRecords_ListChanged);
			}
		}
		
		void colAprEstiloVidaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprEstiloVidaRecords[e.NewIndex].IdEmbarazo = IdEmbarazo;
		    }
		}
				
		private DalSic.AprActualPatologiaEmbarazoCollection colAprActualPatologiaEmbarazoRecords;
		public DalSic.AprActualPatologiaEmbarazoCollection AprActualPatologiaEmbarazoRecords
		{
			get
			{
				if(colAprActualPatologiaEmbarazoRecords == null)
				{
					colAprActualPatologiaEmbarazoRecords = new DalSic.AprActualPatologiaEmbarazoCollection().Where(AprActualPatologiaEmbarazo.Columns.IdEmbarazo, IdEmbarazo).Load();
					colAprActualPatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprActualPatologiaEmbarazoRecords_ListChanged);
				}
				return colAprActualPatologiaEmbarazoRecords;			
			}
			set 
			{ 
					colAprActualPatologiaEmbarazoRecords = value; 
					colAprActualPatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprActualPatologiaEmbarazoRecords_ListChanged);
			}
		}
		
		void colAprActualPatologiaEmbarazoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprActualPatologiaEmbarazoRecords[e.NewIndex].IdEmbarazo = IdEmbarazo;
		    }
		}
				
		private DalSic.AprAntecedentePatologiaEmbarazoCollection colAprAntecedentePatologiaEmbarazoRecords;
		public DalSic.AprAntecedentePatologiaEmbarazoCollection AprAntecedentePatologiaEmbarazoRecords
		{
			get
			{
				if(colAprAntecedentePatologiaEmbarazoRecords == null)
				{
					colAprAntecedentePatologiaEmbarazoRecords = new DalSic.AprAntecedentePatologiaEmbarazoCollection().Where(AprAntecedentePatologiaEmbarazo.Columns.IdEmbarazo, IdEmbarazo).Load();
					colAprAntecedentePatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprAntecedentePatologiaEmbarazoRecords_ListChanged);
				}
				return colAprAntecedentePatologiaEmbarazoRecords;			
			}
			set 
			{ 
					colAprAntecedentePatologiaEmbarazoRecords = value; 
					colAprAntecedentePatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprAntecedentePatologiaEmbarazoRecords_ListChanged);
			}
		}
		
		void colAprAntecedentePatologiaEmbarazoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAntecedentePatologiaEmbarazoRecords[e.NewIndex].IdEmbarazo = IdEmbarazo;
		    }
		}
				
		private DalSic.AprAbortoCollection colAprAbortoRecords;
		public DalSic.AprAbortoCollection AprAbortoRecords
		{
			get
			{
				if(colAprAbortoRecords == null)
				{
					colAprAbortoRecords = new DalSic.AprAbortoCollection().Where(AprAborto.Columns.IdEmbarazo, IdEmbarazo).Load();
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
				}
				return colAprAbortoRecords;			
			}
			set 
			{ 
					colAprAbortoRecords = value; 
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
			}
		}
		
		void colAprAbortoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAbortoRecords[e.NewIndex].IdEmbarazo = IdEmbarazo;
		    }
		}
				
		private DalSic.AprConsultaAntenatalCollection colAprConsultaAntenatalRecords;
		public DalSic.AprConsultaAntenatalCollection AprConsultaAntenatalRecords
		{
			get
			{
				if(colAprConsultaAntenatalRecords == null)
				{
					colAprConsultaAntenatalRecords = new DalSic.AprConsultaAntenatalCollection().Where(AprConsultaAntenatal.Columns.IdEmbarazo, IdEmbarazo).Load();
					colAprConsultaAntenatalRecords.ListChanged += new ListChangedEventHandler(colAprConsultaAntenatalRecords_ListChanged);
				}
				return colAprConsultaAntenatalRecords;			
			}
			set 
			{ 
					colAprConsultaAntenatalRecords = value; 
					colAprConsultaAntenatalRecords.ListChanged += new ListChangedEventHandler(colAprConsultaAntenatalRecords_ListChanged);
			}
		}
		
		void colAprConsultaAntenatalRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprConsultaAntenatalRecords[e.NewIndex].IdEmbarazo = IdEmbarazo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,bool? varPlaneado,int? varIdFracasoMetodoAnticonceptivo,DateTime varFum,DateTime varFpp,double? varPesoAnterior,double? varTalla)
		{
			AprEmbarazo item = new AprEmbarazo();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.Planeado = varPlaneado;
			
			item.IdFracasoMetodoAnticonceptivo = varIdFracasoMetodoAnticonceptivo;
			
			item.Fum = varFum;
			
			item.Fpp = varFpp;
			
			item.PesoAnterior = varPesoAnterior;
			
			item.Talla = varTalla;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEmbarazo,int varIdEfector,int varIdPaciente,bool? varPlaneado,int? varIdFracasoMetodoAnticonceptivo,DateTime varFum,DateTime varFpp,double? varPesoAnterior,double? varTalla)
		{
			AprEmbarazo item = new AprEmbarazo();
			
				item.IdEmbarazo = varIdEmbarazo;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.Planeado = varPlaneado;
			
				item.IdFracasoMetodoAnticonceptivo = varIdFracasoMetodoAnticonceptivo;
			
				item.Fum = varFum;
			
				item.Fpp = varFpp;
			
				item.PesoAnterior = varPesoAnterior;
			
				item.Talla = varTalla;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEmbarazoColumn
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
        
        
        
        public static TableSchema.TableColumn PlaneadoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFracasoMetodoAnticonceptivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FumColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FppColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoAnteriorColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEmbarazo = @"idEmbarazo";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string Planeado = @"Planeado";
			 public static string IdFracasoMetodoAnticonceptivo = @"idFracasoMetodoAnticonceptivo";
			 public static string Fum = @"FUM";
			 public static string Fpp = @"FPP";
			 public static string PesoAnterior = @"PesoAnterior";
			 public static string Talla = @"Talla";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprEgresoMaternoRecords != null)
                {
                    foreach (DalSic.AprEgresoMaterno item in colAprEgresoMaternoRecords)
                    {
                        if (item.IdEmbarazo != IdEmbarazo)
                        {
                            item.IdEmbarazo = IdEmbarazo;
                        }
                    }
               }
		
                if (colAprEstiloVidaRecords != null)
                {
                    foreach (DalSic.AprEstiloVida item in colAprEstiloVidaRecords)
                    {
                        if (item.IdEmbarazo != IdEmbarazo)
                        {
                            item.IdEmbarazo = IdEmbarazo;
                        }
                    }
               }
		
                if (colAprActualPatologiaEmbarazoRecords != null)
                {
                    foreach (DalSic.AprActualPatologiaEmbarazo item in colAprActualPatologiaEmbarazoRecords)
                    {
                        if (item.IdEmbarazo != IdEmbarazo)
                        {
                            item.IdEmbarazo = IdEmbarazo;
                        }
                    }
               }
		
                if (colAprAntecedentePatologiaEmbarazoRecords != null)
                {
                    foreach (DalSic.AprAntecedentePatologiaEmbarazo item in colAprAntecedentePatologiaEmbarazoRecords)
                    {
                        if (item.IdEmbarazo != IdEmbarazo)
                        {
                            item.IdEmbarazo = IdEmbarazo;
                        }
                    }
               }
		
                if (colAprAbortoRecords != null)
                {
                    foreach (DalSic.AprAborto item in colAprAbortoRecords)
                    {
                        if (item.IdEmbarazo != IdEmbarazo)
                        {
                            item.IdEmbarazo = IdEmbarazo;
                        }
                    }
               }
		
                if (colAprConsultaAntenatalRecords != null)
                {
                    foreach (DalSic.AprConsultaAntenatal item in colAprConsultaAntenatalRecords)
                    {
                        if (item.IdEmbarazo != IdEmbarazo)
                        {
                            item.IdEmbarazo = IdEmbarazo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprEgresoMaternoRecords != null)
                {
                    colAprEgresoMaternoRecords.SaveAll();
               }
		
                if (colAprEstiloVidaRecords != null)
                {
                    colAprEstiloVidaRecords.SaveAll();
               }
		
                if (colAprActualPatologiaEmbarazoRecords != null)
                {
                    colAprActualPatologiaEmbarazoRecords.SaveAll();
               }
		
                if (colAprAntecedentePatologiaEmbarazoRecords != null)
                {
                    colAprAntecedentePatologiaEmbarazoRecords.SaveAll();
               }
		
                if (colAprAbortoRecords != null)
                {
                    colAprAbortoRecords.SaveAll();
               }
		
                if (colAprConsultaAntenatalRecords != null)
                {
                    colAprConsultaAntenatalRecords.SaveAll();
               }
		}
        #endregion
	}
}
