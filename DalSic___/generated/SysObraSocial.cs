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
	/// Strongly-typed collection for the SysObraSocial class.
	/// </summary>
    [Serializable]
	public partial class SysObraSocialCollection : ActiveList<SysObraSocial, SysObraSocialCollection>
	{	   
		public SysObraSocialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysObraSocialCollection</returns>
		public SysObraSocialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysObraSocial o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_ObraSocial table.
	/// </summary>
	[Serializable]
	public partial class SysObraSocial : ActiveRecord<SysObraSocial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysObraSocial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysObraSocial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysObraSocial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysObraSocial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_ObraSocial", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = true;
				colvarIdObraSocial.IsNullable = false;
				colvarIdObraSocial.IsPrimaryKey = true;
				colvarIdObraSocial.IsForeignKey = false;
				colvarIdObraSocial.IsReadOnly = false;
				colvarIdObraSocial.DefaultSetting = @"";
				colvarIdObraSocial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdObraSocial);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 200;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarSigla = new TableSchema.TableColumn(schema);
				colvarSigla.ColumnName = "sigla";
				colvarSigla.DataType = DbType.String;
				colvarSigla.MaxLength = 50;
				colvarSigla.AutoIncrement = false;
				colvarSigla.IsNullable = false;
				colvarSigla.IsPrimaryKey = false;
				colvarSigla.IsForeignKey = false;
				colvarSigla.IsReadOnly = false;
				
						colvarSigla.DefaultSetting = @"('')";
				colvarSigla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSigla);
				
				TableSchema.TableColumn colvarCodigoNacion = new TableSchema.TableColumn(schema);
				colvarCodigoNacion.ColumnName = "codigoNacion";
				colvarCodigoNacion.DataType = DbType.AnsiString;
				colvarCodigoNacion.MaxLength = 200;
				colvarCodigoNacion.AutoIncrement = false;
				colvarCodigoNacion.IsNullable = false;
				colvarCodigoNacion.IsPrimaryKey = false;
				colvarCodigoNacion.IsForeignKey = false;
				colvarCodigoNacion.IsReadOnly = false;
				
						colvarCodigoNacion.DefaultSetting = @"('')";
				colvarCodigoNacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoNacion);
				
				TableSchema.TableColumn colvarCuenta = new TableSchema.TableColumn(schema);
				colvarCuenta.ColumnName = "cuenta";
				colvarCuenta.DataType = DbType.AnsiString;
				colvarCuenta.MaxLength = 50;
				colvarCuenta.AutoIncrement = false;
				colvarCuenta.IsNullable = false;
				colvarCuenta.IsPrimaryKey = false;
				colvarCuenta.IsForeignKey = false;
				colvarCuenta.IsReadOnly = false;
				
						colvarCuenta.DefaultSetting = @"('')";
				colvarCuenta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuenta);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = 500;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = false;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				
						colvarDomicilio.DefaultSetting = @"('')";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarIdTipoIva = new TableSchema.TableColumn(schema);
				colvarIdTipoIva.ColumnName = "idTipoIva";
				colvarIdTipoIva.DataType = DbType.Int32;
				colvarIdTipoIva.MaxLength = 0;
				colvarIdTipoIva.AutoIncrement = false;
				colvarIdTipoIva.IsNullable = false;
				colvarIdTipoIva.IsPrimaryKey = false;
				colvarIdTipoIva.IsForeignKey = false;
				colvarIdTipoIva.IsReadOnly = false;
				
						colvarIdTipoIva.DefaultSetting = @"((0))";
				colvarIdTipoIva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoIva);
				
				TableSchema.TableColumn colvarCuit = new TableSchema.TableColumn(schema);
				colvarCuit.ColumnName = "cuit";
				colvarCuit.DataType = DbType.AnsiString;
				colvarCuit.MaxLength = 50;
				colvarCuit.AutoIncrement = false;
				colvarCuit.IsNullable = false;
				colvarCuit.IsPrimaryKey = false;
				colvarCuit.IsForeignKey = false;
				colvarCuit.IsReadOnly = false;
				
						colvarCuit.DefaultSetting = @"('')";
				colvarCuit.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuit);
				
				TableSchema.TableColumn colvarContacto = new TableSchema.TableColumn(schema);
				colvarContacto.ColumnName = "contacto";
				colvarContacto.DataType = DbType.AnsiString;
				colvarContacto.MaxLength = 500;
				colvarContacto.AutoIncrement = false;
				colvarContacto.IsNullable = false;
				colvarContacto.IsPrimaryKey = false;
				colvarContacto.IsForeignKey = false;
				colvarContacto.IsReadOnly = false;
				
						colvarContacto.DefaultSetting = @"('')";
				colvarContacto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContacto);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = 50;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = false;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				
						colvarTelefono.DefaultSetting = @"('')";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarIdTipoObraSocial = new TableSchema.TableColumn(schema);
				colvarIdTipoObraSocial.ColumnName = "idTipoObraSocial";
				colvarIdTipoObraSocial.DataType = DbType.Int32;
				colvarIdTipoObraSocial.MaxLength = 0;
				colvarIdTipoObraSocial.AutoIncrement = false;
				colvarIdTipoObraSocial.IsNullable = false;
				colvarIdTipoObraSocial.IsPrimaryKey = false;
				colvarIdTipoObraSocial.IsForeignKey = true;
				colvarIdTipoObraSocial.IsReadOnly = false;
				
						colvarIdTipoObraSocial.DefaultSetting = @"((0))";
				
					colvarIdTipoObraSocial.ForeignKeyTableName = "Sys_TipoObraSocial";
				schema.Columns.Add(colvarIdTipoObraSocial);
				
				TableSchema.TableColumn colvarIdObraSocialDepende = new TableSchema.TableColumn(schema);
				colvarIdObraSocialDepende.ColumnName = "idObraSocialDepende";
				colvarIdObraSocialDepende.DataType = DbType.Int32;
				colvarIdObraSocialDepende.MaxLength = 0;
				colvarIdObraSocialDepende.AutoIncrement = false;
				colvarIdObraSocialDepende.IsNullable = false;
				colvarIdObraSocialDepende.IsPrimaryKey = false;
				colvarIdObraSocialDepende.IsForeignKey = false;
				colvarIdObraSocialDepende.IsReadOnly = false;
				
						colvarIdObraSocialDepende.DefaultSetting = @"((0))";
				colvarIdObraSocialDepende.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdObraSocialDepende);
				
				TableSchema.TableColumn colvarFacturaPerCapita = new TableSchema.TableColumn(schema);
				colvarFacturaPerCapita.ColumnName = "facturaPerCapita";
				colvarFacturaPerCapita.DataType = DbType.Boolean;
				colvarFacturaPerCapita.MaxLength = 0;
				colvarFacturaPerCapita.AutoIncrement = false;
				colvarFacturaPerCapita.IsNullable = false;
				colvarFacturaPerCapita.IsPrimaryKey = false;
				colvarFacturaPerCapita.IsForeignKey = false;
				colvarFacturaPerCapita.IsReadOnly = false;
				
						colvarFacturaPerCapita.DefaultSetting = @"((0))";
				colvarFacturaPerCapita.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFacturaPerCapita);
				
				TableSchema.TableColumn colvarFacturaCarteraFija = new TableSchema.TableColumn(schema);
				colvarFacturaCarteraFija.ColumnName = "facturaCarteraFija";
				colvarFacturaCarteraFija.DataType = DbType.Boolean;
				colvarFacturaCarteraFija.MaxLength = 0;
				colvarFacturaCarteraFija.AutoIncrement = false;
				colvarFacturaCarteraFija.IsNullable = false;
				colvarFacturaCarteraFija.IsPrimaryKey = false;
				colvarFacturaCarteraFija.IsForeignKey = false;
				colvarFacturaCarteraFija.IsReadOnly = false;
				
						colvarFacturaCarteraFija.DefaultSetting = @"((0))";
				colvarFacturaCarteraFija.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFacturaCarteraFija);
				
				TableSchema.TableColumn colvarFacturaAjuste = new TableSchema.TableColumn(schema);
				colvarFacturaAjuste.ColumnName = "facturaAjuste";
				colvarFacturaAjuste.DataType = DbType.Boolean;
				colvarFacturaAjuste.MaxLength = 0;
				colvarFacturaAjuste.AutoIncrement = false;
				colvarFacturaAjuste.IsNullable = false;
				colvarFacturaAjuste.IsPrimaryKey = false;
				colvarFacturaAjuste.IsForeignKey = false;
				colvarFacturaAjuste.IsReadOnly = false;
				
						colvarFacturaAjuste.DefaultSetting = @"((0))";
				colvarFacturaAjuste.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFacturaAjuste);
				
				TableSchema.TableColumn colvarFacturaPorcentajeAjuste = new TableSchema.TableColumn(schema);
				colvarFacturaPorcentajeAjuste.ColumnName = "facturaPorcentajeAjuste";
				colvarFacturaPorcentajeAjuste.DataType = DbType.Decimal;
				colvarFacturaPorcentajeAjuste.MaxLength = 0;
				colvarFacturaPorcentajeAjuste.AutoIncrement = false;
				colvarFacturaPorcentajeAjuste.IsNullable = false;
				colvarFacturaPorcentajeAjuste.IsPrimaryKey = false;
				colvarFacturaPorcentajeAjuste.IsForeignKey = false;
				colvarFacturaPorcentajeAjuste.IsReadOnly = false;
				
						colvarFacturaPorcentajeAjuste.DefaultSetting = @"((0))";
				colvarFacturaPorcentajeAjuste.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFacturaPorcentajeAjuste);
				
				TableSchema.TableColumn colvarNroOrden = new TableSchema.TableColumn(schema);
				colvarNroOrden.ColumnName = "nroOrden";
				colvarNroOrden.DataType = DbType.Int32;
				colvarNroOrden.MaxLength = 0;
				colvarNroOrden.AutoIncrement = false;
				colvarNroOrden.IsNullable = false;
				colvarNroOrden.IsPrimaryKey = false;
				colvarNroOrden.IsForeignKey = false;
				colvarNroOrden.IsReadOnly = false;
				
						colvarNroOrden.DefaultSetting = @"((10000))";
				colvarNroOrden.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroOrden);
				
				TableSchema.TableColumn colvarPermiteFacturaFueraConvenio = new TableSchema.TableColumn(schema);
				colvarPermiteFacturaFueraConvenio.ColumnName = "permiteFacturaFueraConvenio";
				colvarPermiteFacturaFueraConvenio.DataType = DbType.Boolean;
				colvarPermiteFacturaFueraConvenio.MaxLength = 0;
				colvarPermiteFacturaFueraConvenio.AutoIncrement = false;
				colvarPermiteFacturaFueraConvenio.IsNullable = false;
				colvarPermiteFacturaFueraConvenio.IsPrimaryKey = false;
				colvarPermiteFacturaFueraConvenio.IsForeignKey = false;
				colvarPermiteFacturaFueraConvenio.IsReadOnly = false;
				
						colvarPermiteFacturaFueraConvenio.DefaultSetting = @"((0))";
				colvarPermiteFacturaFueraConvenio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPermiteFacturaFueraConvenio);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_ObraSocial",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int IdObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Sigla")]
		[Bindable(true)]
		public string Sigla 
		{
			get { return GetColumnValue<string>(Columns.Sigla); }
			set { SetColumnValue(Columns.Sigla, value); }
		}
		  
		[XmlAttribute("CodigoNacion")]
		[Bindable(true)]
		public string CodigoNacion 
		{
			get { return GetColumnValue<string>(Columns.CodigoNacion); }
			set { SetColumnValue(Columns.CodigoNacion, value); }
		}
		  
		[XmlAttribute("Cuenta")]
		[Bindable(true)]
		public string Cuenta 
		{
			get { return GetColumnValue<string>(Columns.Cuenta); }
			set { SetColumnValue(Columns.Cuenta, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("IdTipoIva")]
		[Bindable(true)]
		public int IdTipoIva 
		{
			get { return GetColumnValue<int>(Columns.IdTipoIva); }
			set { SetColumnValue(Columns.IdTipoIva, value); }
		}
		  
		[XmlAttribute("Cuit")]
		[Bindable(true)]
		public string Cuit 
		{
			get { return GetColumnValue<string>(Columns.Cuit); }
			set { SetColumnValue(Columns.Cuit, value); }
		}
		  
		[XmlAttribute("Contacto")]
		[Bindable(true)]
		public string Contacto 
		{
			get { return GetColumnValue<string>(Columns.Contacto); }
			set { SetColumnValue(Columns.Contacto, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("IdTipoObraSocial")]
		[Bindable(true)]
		public int IdTipoObraSocial 
		{
			get { return GetColumnValue<int>(Columns.IdTipoObraSocial); }
			set { SetColumnValue(Columns.IdTipoObraSocial, value); }
		}
		  
		[XmlAttribute("IdObraSocialDepende")]
		[Bindable(true)]
		public int IdObraSocialDepende 
		{
			get { return GetColumnValue<int>(Columns.IdObraSocialDepende); }
			set { SetColumnValue(Columns.IdObraSocialDepende, value); }
		}
		  
		[XmlAttribute("FacturaPerCapita")]
		[Bindable(true)]
		public bool FacturaPerCapita 
		{
			get { return GetColumnValue<bool>(Columns.FacturaPerCapita); }
			set { SetColumnValue(Columns.FacturaPerCapita, value); }
		}
		  
		[XmlAttribute("FacturaCarteraFija")]
		[Bindable(true)]
		public bool FacturaCarteraFija 
		{
			get { return GetColumnValue<bool>(Columns.FacturaCarteraFija); }
			set { SetColumnValue(Columns.FacturaCarteraFija, value); }
		}
		  
		[XmlAttribute("FacturaAjuste")]
		[Bindable(true)]
		public bool FacturaAjuste 
		{
			get { return GetColumnValue<bool>(Columns.FacturaAjuste); }
			set { SetColumnValue(Columns.FacturaAjuste, value); }
		}
		  
		[XmlAttribute("FacturaPorcentajeAjuste")]
		[Bindable(true)]
		public decimal FacturaPorcentajeAjuste 
		{
			get { return GetColumnValue<decimal>(Columns.FacturaPorcentajeAjuste); }
			set { SetColumnValue(Columns.FacturaPorcentajeAjuste, value); }
		}
		  
		[XmlAttribute("NroOrden")]
		[Bindable(true)]
		public int NroOrden 
		{
			get { return GetColumnValue<int>(Columns.NroOrden); }
			set { SetColumnValue(Columns.NroOrden, value); }
		}
		  
		[XmlAttribute("PermiteFacturaFueraConvenio")]
		[Bindable(true)]
		public bool PermiteFacturaFueraConvenio 
		{
			get { return GetColumnValue<bool>(Columns.PermiteFacturaFueraConvenio); }
			set { SetColumnValue(Columns.PermiteFacturaFueraConvenio, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.FacContratoObraSocialCollection colFacContratoObraSocialRecords;
		public DalSic.FacContratoObraSocialCollection FacContratoObraSocialRecords
		{
			get
			{
				if(colFacContratoObraSocialRecords == null)
				{
					colFacContratoObraSocialRecords = new DalSic.FacContratoObraSocialCollection().Where(FacContratoObraSocial.Columns.IdObraSocial, IdObraSocial).Load();
					colFacContratoObraSocialRecords.ListChanged += new ListChangedEventHandler(colFacContratoObraSocialRecords_ListChanged);
				}
				return colFacContratoObraSocialRecords;			
			}
			set 
			{ 
					colFacContratoObraSocialRecords = value; 
					colFacContratoObraSocialRecords.ListChanged += new ListChangedEventHandler(colFacContratoObraSocialRecords_ListChanged);
			}
		}
		
		void colFacContratoObraSocialRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colFacContratoObraSocialRecords[e.NewIndex].IdObraSocial = IdObraSocial;
		    }
		}
				
		private DalSic.RemFormularioCollection colRemFormularioRecords;
		public DalSic.RemFormularioCollection RemFormularioRecords
		{
			get
			{
				if(colRemFormularioRecords == null)
				{
					colRemFormularioRecords = new DalSic.RemFormularioCollection().Where(RemFormulario.Columns.IdObraSocial, IdObraSocial).Load();
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
		        colRemFormularioRecords[e.NewIndex].IdObraSocial = IdObraSocial;
		    }
		}
				
		private DalSic.SysRelPacienteObraSocialCollection colSysRelPacienteObraSocialRecords;
		public DalSic.SysRelPacienteObraSocialCollection SysRelPacienteObraSocialRecords
		{
			get
			{
				if(colSysRelPacienteObraSocialRecords == null)
				{
					colSysRelPacienteObraSocialRecords = new DalSic.SysRelPacienteObraSocialCollection().Where(SysRelPacienteObraSocial.Columns.IdObraSocial, IdObraSocial).Load();
					colSysRelPacienteObraSocialRecords.ListChanged += new ListChangedEventHandler(colSysRelPacienteObraSocialRecords_ListChanged);
				}
				return colSysRelPacienteObraSocialRecords;			
			}
			set 
			{ 
					colSysRelPacienteObraSocialRecords = value; 
					colSysRelPacienteObraSocialRecords.ListChanged += new ListChangedEventHandler(colSysRelPacienteObraSocialRecords_ListChanged);
			}
		}
		
		void colSysRelPacienteObraSocialRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysRelPacienteObraSocialRecords[e.NewIndex].IdObraSocial = IdObraSocial;
		    }
		}
				
		private DalSic.SysPacienteCollection colSysPacienteRecords;
		public DalSic.SysPacienteCollection SysPacienteRecords
		{
			get
			{
				if(colSysPacienteRecords == null)
				{
					colSysPacienteRecords = new DalSic.SysPacienteCollection().Where(SysPaciente.Columns.IdObraSocial, IdObraSocial).Load();
					colSysPacienteRecords.ListChanged += new ListChangedEventHandler(colSysPacienteRecords_ListChanged);
				}
				return colSysPacienteRecords;			
			}
			set 
			{ 
					colSysPacienteRecords = value; 
					colSysPacienteRecords.ListChanged += new ListChangedEventHandler(colSysPacienteRecords_ListChanged);
			}
		}
		
		void colSysPacienteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysPacienteRecords[e.NewIndex].IdObraSocial = IdObraSocial;
		    }
		}
				
		private DalSic.ConConsultumCollection colConConsulta;
		public DalSic.ConConsultumCollection ConConsulta
		{
			get
			{
				if(colConConsulta == null)
				{
					colConConsulta = new DalSic.ConConsultumCollection().Where(ConConsultum.Columns.IdObraSocial, IdObraSocial).Load();
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
		        colConConsulta[e.NewIndex].IdObraSocial = IdObraSocial;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysTipoObraSocial ActiveRecord object related to this SysObraSocial
		/// 
		/// </summary>
		public DalSic.SysTipoObraSocial SysTipoObraSocial
		{
			get { return DalSic.SysTipoObraSocial.FetchByID(this.IdTipoObraSocial); }
			set { SetColumnValue("idTipoObraSocial", value.IdTipoObraSocial); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varSigla,string varCodigoNacion,string varCuenta,string varDomicilio,int varIdTipoIva,string varCuit,string varContacto,string varTelefono,int varIdTipoObraSocial,int varIdObraSocialDepende,bool varFacturaPerCapita,bool varFacturaCarteraFija,bool varFacturaAjuste,decimal varFacturaPorcentajeAjuste,int varNroOrden,bool varPermiteFacturaFueraConvenio)
		{
			SysObraSocial item = new SysObraSocial();
			
			item.Nombre = varNombre;
			
			item.Sigla = varSigla;
			
			item.CodigoNacion = varCodigoNacion;
			
			item.Cuenta = varCuenta;
			
			item.Domicilio = varDomicilio;
			
			item.IdTipoIva = varIdTipoIva;
			
			item.Cuit = varCuit;
			
			item.Contacto = varContacto;
			
			item.Telefono = varTelefono;
			
			item.IdTipoObraSocial = varIdTipoObraSocial;
			
			item.IdObraSocialDepende = varIdObraSocialDepende;
			
			item.FacturaPerCapita = varFacturaPerCapita;
			
			item.FacturaCarteraFija = varFacturaCarteraFija;
			
			item.FacturaAjuste = varFacturaAjuste;
			
			item.FacturaPorcentajeAjuste = varFacturaPorcentajeAjuste;
			
			item.NroOrden = varNroOrden;
			
			item.PermiteFacturaFueraConvenio = varPermiteFacturaFueraConvenio;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdObraSocial,string varNombre,string varSigla,string varCodigoNacion,string varCuenta,string varDomicilio,int varIdTipoIva,string varCuit,string varContacto,string varTelefono,int varIdTipoObraSocial,int varIdObraSocialDepende,bool varFacturaPerCapita,bool varFacturaCarteraFija,bool varFacturaAjuste,decimal varFacturaPorcentajeAjuste,int varNroOrden,bool varPermiteFacturaFueraConvenio)
		{
			SysObraSocial item = new SysObraSocial();
			
				item.IdObraSocial = varIdObraSocial;
			
				item.Nombre = varNombre;
			
				item.Sigla = varSigla;
			
				item.CodigoNacion = varCodigoNacion;
			
				item.Cuenta = varCuenta;
			
				item.Domicilio = varDomicilio;
			
				item.IdTipoIva = varIdTipoIva;
			
				item.Cuit = varCuit;
			
				item.Contacto = varContacto;
			
				item.Telefono = varTelefono;
			
				item.IdTipoObraSocial = varIdTipoObraSocial;
			
				item.IdObraSocialDepende = varIdObraSocialDepende;
			
				item.FacturaPerCapita = varFacturaPerCapita;
			
				item.FacturaCarteraFija = varFacturaCarteraFija;
			
				item.FacturaAjuste = varFacturaAjuste;
			
				item.FacturaPorcentajeAjuste = varFacturaPorcentajeAjuste;
			
				item.NroOrden = varNroOrden;
			
				item.PermiteFacturaFueraConvenio = varPermiteFacturaFueraConvenio;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SiglaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoNacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CuentaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoIvaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CuitColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoObraSocialColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialDependeColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FacturaPerCapitaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FacturaCarteraFijaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FacturaAjusteColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn FacturaPorcentajeAjusteColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn NroOrdenColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn PermiteFacturaFueraConvenioColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdObraSocial = @"idObraSocial";
			 public static string Nombre = @"nombre";
			 public static string Sigla = @"sigla";
			 public static string CodigoNacion = @"codigoNacion";
			 public static string Cuenta = @"cuenta";
			 public static string Domicilio = @"domicilio";
			 public static string IdTipoIva = @"idTipoIva";
			 public static string Cuit = @"cuit";
			 public static string Contacto = @"contacto";
			 public static string Telefono = @"telefono";
			 public static string IdTipoObraSocial = @"idTipoObraSocial";
			 public static string IdObraSocialDepende = @"idObraSocialDepende";
			 public static string FacturaPerCapita = @"facturaPerCapita";
			 public static string FacturaCarteraFija = @"facturaCarteraFija";
			 public static string FacturaAjuste = @"facturaAjuste";
			 public static string FacturaPorcentajeAjuste = @"facturaPorcentajeAjuste";
			 public static string NroOrden = @"nroOrden";
			 public static string PermiteFacturaFueraConvenio = @"permiteFacturaFueraConvenio";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colFacContratoObraSocialRecords != null)
                {
                    foreach (DalSic.FacContratoObraSocial item in colFacContratoObraSocialRecords)
                    {
                        if (item.IdObraSocial != IdObraSocial)
                        {
                            item.IdObraSocial = IdObraSocial;
                        }
                    }
               }
		
                if (colRemFormularioRecords != null)
                {
                    foreach (DalSic.RemFormulario item in colRemFormularioRecords)
                    {
                        if (item.IdObraSocial != IdObraSocial)
                        {
                            item.IdObraSocial = IdObraSocial;
                        }
                    }
               }
		
                if (colSysRelPacienteObraSocialRecords != null)
                {
                    foreach (DalSic.SysRelPacienteObraSocial item in colSysRelPacienteObraSocialRecords)
                    {
                        if (item.IdObraSocial != IdObraSocial)
                        {
                            item.IdObraSocial = IdObraSocial;
                        }
                    }
               }
		
                if (colSysPacienteRecords != null)
                {
                    foreach (DalSic.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdObraSocial != IdObraSocial)
                        {
                            item.IdObraSocial = IdObraSocial;
                        }
                    }
               }
		
                if (colConConsulta != null)
                {
                    foreach (DalSic.ConConsultum item in colConConsulta)
                    {
                        if (item.IdObraSocial != IdObraSocial)
                        {
                            item.IdObraSocial = IdObraSocial;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colFacContratoObraSocialRecords != null)
                {
                    colFacContratoObraSocialRecords.SaveAll();
               }
		
                if (colRemFormularioRecords != null)
                {
                    colRemFormularioRecords.SaveAll();
               }
		
                if (colSysRelPacienteObraSocialRecords != null)
                {
                    colSysRelPacienteObraSocialRecords.SaveAll();
               }
		
                if (colSysPacienteRecords != null)
                {
                    colSysPacienteRecords.SaveAll();
               }
		
                if (colConConsulta != null)
                {
                    colConConsulta.SaveAll();
               }
		}
        #endregion
	}
}
