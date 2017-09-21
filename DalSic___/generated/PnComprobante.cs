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
	/// Strongly-typed collection for the PnComprobante class.
	/// </summary>
    [Serializable]
	public partial class PnComprobanteCollection : ActiveList<PnComprobante, PnComprobanteCollection>
	{	   
		public PnComprobanteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnComprobanteCollection</returns>
		public PnComprobanteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnComprobante o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_comprobante table.
	/// </summary>
	[Serializable]
	public partial class PnComprobante : ActiveRecord<PnComprobante>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnComprobante()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnComprobante(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnComprobante(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnComprobante(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_comprobante", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdComprobante = new TableSchema.TableColumn(schema);
				colvarIdComprobante.ColumnName = "id_comprobante";
				colvarIdComprobante.DataType = DbType.Int32;
				colvarIdComprobante.MaxLength = 0;
				colvarIdComprobante.AutoIncrement = true;
				colvarIdComprobante.IsNullable = false;
				colvarIdComprobante.IsPrimaryKey = true;
				colvarIdComprobante.IsForeignKey = false;
				colvarIdComprobante.IsReadOnly = false;
				colvarIdComprobante.DefaultSetting = @"";
				colvarIdComprobante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdComprobante);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarIdFactura = new TableSchema.TableColumn(schema);
				colvarIdFactura.ColumnName = "id_factura";
				colvarIdFactura.DataType = DbType.Int32;
				colvarIdFactura.MaxLength = 0;
				colvarIdFactura.AutoIncrement = false;
				colvarIdFactura.IsNullable = true;
				colvarIdFactura.IsPrimaryKey = false;
				colvarIdFactura.IsForeignKey = true;
				colvarIdFactura.IsReadOnly = false;
				colvarIdFactura.DefaultSetting = @"";
				
					colvarIdFactura.ForeignKeyTableName = "PN_factura";
				schema.Columns.Add(colvarIdFactura);
				
				TableSchema.TableColumn colvarNombreMedico = new TableSchema.TableColumn(schema);
				colvarNombreMedico.ColumnName = "nombre_medico";
				colvarNombreMedico.DataType = DbType.AnsiString;
				colvarNombreMedico.MaxLength = -1;
				colvarNombreMedico.AutoIncrement = false;
				colvarNombreMedico.IsNullable = true;
				colvarNombreMedico.IsPrimaryKey = false;
				colvarNombreMedico.IsForeignKey = false;
				colvarNombreMedico.IsReadOnly = false;
				colvarNombreMedico.DefaultSetting = @"";
				colvarNombreMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreMedico);
				
				TableSchema.TableColumn colvarFechaComprobante = new TableSchema.TableColumn(schema);
				colvarFechaComprobante.ColumnName = "fecha_comprobante";
				colvarFechaComprobante.DataType = DbType.DateTime;
				colvarFechaComprobante.MaxLength = 0;
				colvarFechaComprobante.AutoIncrement = false;
				colvarFechaComprobante.IsNullable = true;
				colvarFechaComprobante.IsPrimaryKey = false;
				colvarFechaComprobante.IsForeignKey = false;
				colvarFechaComprobante.IsReadOnly = false;
				colvarFechaComprobante.DefaultSetting = @"";
				colvarFechaComprobante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaComprobante);
				
				TableSchema.TableColumn colvarClavebeneficiario = new TableSchema.TableColumn(schema);
				colvarClavebeneficiario.ColumnName = "clavebeneficiario";
				colvarClavebeneficiario.DataType = DbType.AnsiString;
				colvarClavebeneficiario.MaxLength = 50;
				colvarClavebeneficiario.AutoIncrement = false;
				colvarClavebeneficiario.IsNullable = true;
				colvarClavebeneficiario.IsPrimaryKey = false;
				colvarClavebeneficiario.IsForeignKey = false;
				colvarClavebeneficiario.IsReadOnly = false;
				colvarClavebeneficiario.DefaultSetting = @"";
				colvarClavebeneficiario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClavebeneficiario);
				
				TableSchema.TableColumn colvarIdSmiafiliados = new TableSchema.TableColumn(schema);
				colvarIdSmiafiliados.ColumnName = "id_smiafiliados";
				colvarIdSmiafiliados.DataType = DbType.Int32;
				colvarIdSmiafiliados.MaxLength = 0;
				colvarIdSmiafiliados.AutoIncrement = false;
				colvarIdSmiafiliados.IsNullable = true;
				colvarIdSmiafiliados.IsPrimaryKey = false;
				colvarIdSmiafiliados.IsForeignKey = true;
				colvarIdSmiafiliados.IsReadOnly = false;
				colvarIdSmiafiliados.DefaultSetting = @"";
				
					colvarIdSmiafiliados.ForeignKeyTableName = "PN_smiafiliados";
				schema.Columns.Add(colvarIdSmiafiliados);
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "fecha_carga";
				colvarFechaCarga.DataType = DbType.DateTime;
				colvarFechaCarga.MaxLength = 0;
				colvarFechaCarga.AutoIncrement = false;
				colvarFechaCarga.IsNullable = true;
				colvarFechaCarga.IsPrimaryKey = false;
				colvarFechaCarga.IsForeignKey = false;
				colvarFechaCarga.IsReadOnly = false;
				colvarFechaCarga.DefaultSetting = @"";
				colvarFechaCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCarga);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = -1;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarMarca = new TableSchema.TableColumn(schema);
				colvarMarca.ColumnName = "marca";
				colvarMarca.DataType = DbType.Int32;
				colvarMarca.MaxLength = 0;
				colvarMarca.AutoIncrement = false;
				colvarMarca.IsNullable = true;
				colvarMarca.IsPrimaryKey = false;
				colvarMarca.IsForeignKey = false;
				colvarMarca.IsReadOnly = false;
				
						colvarMarca.DefaultSetting = @"((0))";
				colvarMarca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMarca);
				
				TableSchema.TableColumn colvarPeriodo = new TableSchema.TableColumn(schema);
				colvarPeriodo.ColumnName = "periodo";
				colvarPeriodo.DataType = DbType.AnsiString;
				colvarPeriodo.MaxLength = -1;
				colvarPeriodo.AutoIncrement = false;
				colvarPeriodo.IsNullable = true;
				colvarPeriodo.IsPrimaryKey = false;
				colvarPeriodo.IsForeignKey = false;
				colvarPeriodo.IsReadOnly = false;
				colvarPeriodo.DefaultSetting = @"";
				colvarPeriodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodo);
				
				TableSchema.TableColumn colvarIdServicio = new TableSchema.TableColumn(schema);
				colvarIdServicio.ColumnName = "id_servicio";
				colvarIdServicio.DataType = DbType.Int32;
				colvarIdServicio.MaxLength = 0;
				colvarIdServicio.AutoIncrement = false;
				colvarIdServicio.IsNullable = true;
				colvarIdServicio.IsPrimaryKey = false;
				colvarIdServicio.IsForeignKey = true;
				colvarIdServicio.IsReadOnly = false;
				colvarIdServicio.DefaultSetting = @"";
				
					colvarIdServicio.ForeignKeyTableName = "PN_servicio";
				schema.Columns.Add(colvarIdServicio);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.AnsiString;
				colvarActivo.MaxLength = 1;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = true;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarIdBeneficiarios = new TableSchema.TableColumn(schema);
				colvarIdBeneficiarios.ColumnName = "id_beneficiarios";
				colvarIdBeneficiarios.DataType = DbType.Int32;
				colvarIdBeneficiarios.MaxLength = 0;
				colvarIdBeneficiarios.AutoIncrement = false;
				colvarIdBeneficiarios.IsNullable = true;
				colvarIdBeneficiarios.IsPrimaryKey = false;
				colvarIdBeneficiarios.IsForeignKey = false;
				colvarIdBeneficiarios.IsReadOnly = false;
				colvarIdBeneficiarios.DefaultSetting = @"";
				colvarIdBeneficiarios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBeneficiarios);
				
				TableSchema.TableColumn colvarAltaComp = new TableSchema.TableColumn(schema);
				colvarAltaComp.ColumnName = "alta_comp";
				colvarAltaComp.DataType = DbType.AnsiString;
				colvarAltaComp.MaxLength = 2;
				colvarAltaComp.AutoIncrement = false;
				colvarAltaComp.IsNullable = true;
				colvarAltaComp.IsPrimaryKey = false;
				colvarAltaComp.IsForeignKey = false;
				colvarAltaComp.IsReadOnly = false;
				colvarAltaComp.DefaultSetting = @"";
				colvarAltaComp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAltaComp);
				
				TableSchema.TableColumn colvarIdTipoDePrestacion = new TableSchema.TableColumn(schema);
				colvarIdTipoDePrestacion.ColumnName = "idTipoDePrestacion";
				colvarIdTipoDePrestacion.DataType = DbType.Int32;
				colvarIdTipoDePrestacion.MaxLength = 0;
				colvarIdTipoDePrestacion.AutoIncrement = false;
				colvarIdTipoDePrestacion.IsNullable = true;
				colvarIdTipoDePrestacion.IsPrimaryKey = false;
				colvarIdTipoDePrestacion.IsForeignKey = true;
				colvarIdTipoDePrestacion.IsReadOnly = false;
				colvarIdTipoDePrestacion.DefaultSetting = @"";
				
					colvarIdTipoDePrestacion.ForeignKeyTableName = "PN_TipoDePrestacion";
				schema.Columns.Add(colvarIdTipoDePrestacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_comprobante",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdComprobante")]
		[Bindable(true)]
		public int IdComprobante 
		{
			get { return GetColumnValue<int>(Columns.IdComprobante); }
			set { SetColumnValue(Columns.IdComprobante, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("IdFactura")]
		[Bindable(true)]
		public int? IdFactura 
		{
			get { return GetColumnValue<int?>(Columns.IdFactura); }
			set { SetColumnValue(Columns.IdFactura, value); }
		}
		  
		[XmlAttribute("NombreMedico")]
		[Bindable(true)]
		public string NombreMedico 
		{
			get { return GetColumnValue<string>(Columns.NombreMedico); }
			set { SetColumnValue(Columns.NombreMedico, value); }
		}
		  
		[XmlAttribute("FechaComprobante")]
		[Bindable(true)]
		public DateTime? FechaComprobante 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaComprobante); }
			set { SetColumnValue(Columns.FechaComprobante, value); }
		}
		  
		[XmlAttribute("Clavebeneficiario")]
		[Bindable(true)]
		public string Clavebeneficiario 
		{
			get { return GetColumnValue<string>(Columns.Clavebeneficiario); }
			set { SetColumnValue(Columns.Clavebeneficiario, value); }
		}
		  
		[XmlAttribute("IdSmiafiliados")]
		[Bindable(true)]
		public int? IdSmiafiliados 
		{
			get { return GetColumnValue<int?>(Columns.IdSmiafiliados); }
			set { SetColumnValue(Columns.IdSmiafiliados, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("Marca")]
		[Bindable(true)]
		public int? Marca 
		{
			get { return GetColumnValue<int?>(Columns.Marca); }
			set { SetColumnValue(Columns.Marca, value); }
		}
		  
		[XmlAttribute("Periodo")]
		[Bindable(true)]
		public string Periodo 
		{
			get { return GetColumnValue<string>(Columns.Periodo); }
			set { SetColumnValue(Columns.Periodo, value); }
		}
		  
		[XmlAttribute("IdServicio")]
		[Bindable(true)]
		public int? IdServicio 
		{
			get { return GetColumnValue<int?>(Columns.IdServicio); }
			set { SetColumnValue(Columns.IdServicio, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public string Activo 
		{
			get { return GetColumnValue<string>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("IdBeneficiarios")]
		[Bindable(true)]
		public int? IdBeneficiarios 
		{
			get { return GetColumnValue<int?>(Columns.IdBeneficiarios); }
			set { SetColumnValue(Columns.IdBeneficiarios, value); }
		}
		  
		[XmlAttribute("AltaComp")]
		[Bindable(true)]
		public string AltaComp 
		{
			get { return GetColumnValue<string>(Columns.AltaComp); }
			set { SetColumnValue(Columns.AltaComp, value); }
		}
		  
		[XmlAttribute("IdTipoDePrestacion")]
		[Bindable(true)]
		public int? IdTipoDePrestacion 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoDePrestacion); }
			set { SetColumnValue(Columns.IdTipoDePrestacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnPrestacionCollection colPnPrestacionRecords;
		public DalSic.PnPrestacionCollection PnPrestacionRecords
		{
			get
			{
				if(colPnPrestacionRecords == null)
				{
					colPnPrestacionRecords = new DalSic.PnPrestacionCollection().Where(PnPrestacion.Columns.IdComprobante, IdComprobante).Load();
					colPnPrestacionRecords.ListChanged += new ListChangedEventHandler(colPnPrestacionRecords_ListChanged);
				}
				return colPnPrestacionRecords;			
			}
			set 
			{ 
					colPnPrestacionRecords = value; 
					colPnPrestacionRecords.ListChanged += new ListChangedEventHandler(colPnPrestacionRecords_ListChanged);
			}
		}
		
		void colPnPrestacionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPrestacionRecords[e.NewIndex].IdComprobante = IdComprobante;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnFactura ActiveRecord object related to this PnComprobante
		/// 
		/// </summary>
		public DalSic.PnFactura PnFactura
		{
			get { return DalSic.PnFactura.FetchByID(this.IdFactura); }
			set { SetColumnValue("id_factura", value.IdFactura); }
		}
		
		
		/// <summary>
		/// Returns a PnSmiafiliado ActiveRecord object related to this PnComprobante
		/// 
		/// </summary>
		public DalSic.PnSmiafiliado PnSmiafiliado
		{
			get { return DalSic.PnSmiafiliado.FetchByID(this.IdSmiafiliados); }
			set { SetColumnValue("id_smiafiliados", value.IdSmiafiliados); }
		}
		
		
		/// <summary>
		/// Returns a PnServicio ActiveRecord object related to this PnComprobante
		/// 
		/// </summary>
		public DalSic.PnServicio PnServicio
		{
			get { return DalSic.PnServicio.FetchByID(this.IdServicio); }
			set { SetColumnValue("id_servicio", value.IdServicio); }
		}
		
		
		/// <summary>
		/// Returns a PnTipoDePrestacion ActiveRecord object related to this PnComprobante
		/// 
		/// </summary>
		public DalSic.PnTipoDePrestacion PnTipoDePrestacion
		{
			get { return DalSic.PnTipoDePrestacion.FetchByID(this.IdTipoDePrestacion); }
			set { SetColumnValue("idTipoDePrestacion", value.IdTipoDePrestacion); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,int? varIdFactura,string varNombreMedico,DateTime? varFechaComprobante,string varClavebeneficiario,int? varIdSmiafiliados,DateTime? varFechaCarga,string varComentario,int? varMarca,string varPeriodo,int? varIdServicio,string varActivo,int? varIdBeneficiarios,string varAltaComp,int? varIdTipoDePrestacion)
		{
			PnComprobante item = new PnComprobante();
			
			item.Cuie = varCuie;
			
			item.IdFactura = varIdFactura;
			
			item.NombreMedico = varNombreMedico;
			
			item.FechaComprobante = varFechaComprobante;
			
			item.Clavebeneficiario = varClavebeneficiario;
			
			item.IdSmiafiliados = varIdSmiafiliados;
			
			item.FechaCarga = varFechaCarga;
			
			item.Comentario = varComentario;
			
			item.Marca = varMarca;
			
			item.Periodo = varPeriodo;
			
			item.IdServicio = varIdServicio;
			
			item.Activo = varActivo;
			
			item.IdBeneficiarios = varIdBeneficiarios;
			
			item.AltaComp = varAltaComp;
			
			item.IdTipoDePrestacion = varIdTipoDePrestacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdComprobante,string varCuie,int? varIdFactura,string varNombreMedico,DateTime? varFechaComprobante,string varClavebeneficiario,int? varIdSmiafiliados,DateTime? varFechaCarga,string varComentario,int? varMarca,string varPeriodo,int? varIdServicio,string varActivo,int? varIdBeneficiarios,string varAltaComp,int? varIdTipoDePrestacion)
		{
			PnComprobante item = new PnComprobante();
			
				item.IdComprobante = varIdComprobante;
			
				item.Cuie = varCuie;
			
				item.IdFactura = varIdFactura;
			
				item.NombreMedico = varNombreMedico;
			
				item.FechaComprobante = varFechaComprobante;
			
				item.Clavebeneficiario = varClavebeneficiario;
			
				item.IdSmiafiliados = varIdSmiafiliados;
			
				item.FechaCarga = varFechaCarga;
			
				item.Comentario = varComentario;
			
				item.Marca = varMarca;
			
				item.Periodo = varPeriodo;
			
				item.IdServicio = varIdServicio;
			
				item.Activo = varActivo;
			
				item.IdBeneficiarios = varIdBeneficiarios;
			
				item.AltaComp = varAltaComp;
			
				item.IdTipoDePrestacion = varIdTipoDePrestacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdComprobanteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFacturaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreMedicoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaComprobanteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ClavebeneficiarioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSmiafiliadosColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn MarcaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServicioColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBeneficiariosColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AltaCompColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoDePrestacionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdComprobante = @"id_comprobante";
			 public static string Cuie = @"cuie";
			 public static string IdFactura = @"id_factura";
			 public static string NombreMedico = @"nombre_medico";
			 public static string FechaComprobante = @"fecha_comprobante";
			 public static string Clavebeneficiario = @"clavebeneficiario";
			 public static string IdSmiafiliados = @"id_smiafiliados";
			 public static string FechaCarga = @"fecha_carga";
			 public static string Comentario = @"comentario";
			 public static string Marca = @"marca";
			 public static string Periodo = @"periodo";
			 public static string IdServicio = @"id_servicio";
			 public static string Activo = @"activo";
			 public static string IdBeneficiarios = @"id_beneficiarios";
			 public static string AltaComp = @"alta_comp";
			 public static string IdTipoDePrestacion = @"idTipoDePrestacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnPrestacionRecords != null)
                {
                    foreach (DalSic.PnPrestacion item in colPnPrestacionRecords)
                    {
                        if (item.IdComprobante != IdComprobante)
                        {
                            item.IdComprobante = IdComprobante;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnPrestacionRecords != null)
                {
                    colPnPrestacionRecords.SaveAll();
               }
		}
        #endregion
	}
}
