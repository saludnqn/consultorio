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
	/// Strongly-typed collection for the PnSmiafiliado class.
	/// </summary>
    [Serializable]
	public partial class PnSmiafiliadoCollection : ActiveList<PnSmiafiliado, PnSmiafiliadoCollection>
	{	   
		public PnSmiafiliadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSmiafiliadoCollection</returns>
		public PnSmiafiliadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSmiafiliado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_smiafiliados table.
	/// </summary>
	[Serializable]
	public partial class PnSmiafiliado : ActiveRecord<PnSmiafiliado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSmiafiliado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSmiafiliado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSmiafiliado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSmiafiliado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_smiafiliados", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSmiafiliados = new TableSchema.TableColumn(schema);
				colvarIdSmiafiliados.ColumnName = "id_smiafiliados";
				colvarIdSmiafiliados.DataType = DbType.Int32;
				colvarIdSmiafiliados.MaxLength = 0;
				colvarIdSmiafiliados.AutoIncrement = true;
				colvarIdSmiafiliados.IsNullable = false;
				colvarIdSmiafiliados.IsPrimaryKey = true;
				colvarIdSmiafiliados.IsForeignKey = false;
				colvarIdSmiafiliados.IsReadOnly = false;
				colvarIdSmiafiliados.DefaultSetting = @"";
				colvarIdSmiafiliados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSmiafiliados);
				
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
				
				TableSchema.TableColumn colvarAfiapellido = new TableSchema.TableColumn(schema);
				colvarAfiapellido.ColumnName = "afiapellido";
				colvarAfiapellido.DataType = DbType.AnsiString;
				colvarAfiapellido.MaxLength = -1;
				colvarAfiapellido.AutoIncrement = false;
				colvarAfiapellido.IsNullable = true;
				colvarAfiapellido.IsPrimaryKey = false;
				colvarAfiapellido.IsForeignKey = false;
				colvarAfiapellido.IsReadOnly = false;
				colvarAfiapellido.DefaultSetting = @"";
				colvarAfiapellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfiapellido);
				
				TableSchema.TableColumn colvarAfinombre = new TableSchema.TableColumn(schema);
				colvarAfinombre.ColumnName = "afinombre";
				colvarAfinombre.DataType = DbType.AnsiString;
				colvarAfinombre.MaxLength = -1;
				colvarAfinombre.AutoIncrement = false;
				colvarAfinombre.IsNullable = true;
				colvarAfinombre.IsPrimaryKey = false;
				colvarAfinombre.IsForeignKey = false;
				colvarAfinombre.IsReadOnly = false;
				colvarAfinombre.DefaultSetting = @"";
				colvarAfinombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfinombre);
				
				TableSchema.TableColumn colvarAfitipodoc = new TableSchema.TableColumn(schema);
				colvarAfitipodoc.ColumnName = "afitipodoc";
				colvarAfitipodoc.DataType = DbType.AnsiString;
				colvarAfitipodoc.MaxLength = -1;
				colvarAfitipodoc.AutoIncrement = false;
				colvarAfitipodoc.IsNullable = true;
				colvarAfitipodoc.IsPrimaryKey = false;
				colvarAfitipodoc.IsForeignKey = false;
				colvarAfitipodoc.IsReadOnly = false;
				colvarAfitipodoc.DefaultSetting = @"";
				colvarAfitipodoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfitipodoc);
				
				TableSchema.TableColumn colvarAficlasedoc = new TableSchema.TableColumn(schema);
				colvarAficlasedoc.ColumnName = "aficlasedoc";
				colvarAficlasedoc.DataType = DbType.AnsiStringFixedLength;
				colvarAficlasedoc.MaxLength = 2;
				colvarAficlasedoc.AutoIncrement = false;
				colvarAficlasedoc.IsNullable = true;
				colvarAficlasedoc.IsPrimaryKey = false;
				colvarAficlasedoc.IsForeignKey = false;
				colvarAficlasedoc.IsReadOnly = false;
				colvarAficlasedoc.DefaultSetting = @"";
				colvarAficlasedoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAficlasedoc);
				
				TableSchema.TableColumn colvarAfidni = new TableSchema.TableColumn(schema);
				colvarAfidni.ColumnName = "afidni";
				colvarAfidni.DataType = DbType.AnsiString;
				colvarAfidni.MaxLength = -1;
				colvarAfidni.AutoIncrement = false;
				colvarAfidni.IsNullable = true;
				colvarAfidni.IsPrimaryKey = false;
				colvarAfidni.IsForeignKey = false;
				colvarAfidni.IsReadOnly = false;
				colvarAfidni.DefaultSetting = @"";
				colvarAfidni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidni);
				
				TableSchema.TableColumn colvarAfisexo = new TableSchema.TableColumn(schema);
				colvarAfisexo.ColumnName = "afisexo";
				colvarAfisexo.DataType = DbType.AnsiStringFixedLength;
				colvarAfisexo.MaxLength = 20;
				colvarAfisexo.AutoIncrement = false;
				colvarAfisexo.IsNullable = true;
				colvarAfisexo.IsPrimaryKey = false;
				colvarAfisexo.IsForeignKey = false;
				colvarAfisexo.IsReadOnly = false;
				colvarAfisexo.DefaultSetting = @"";
				colvarAfisexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfisexo);
				
				TableSchema.TableColumn colvarAfidomdepartamento = new TableSchema.TableColumn(schema);
				colvarAfidomdepartamento.ColumnName = "afidomdepartamento";
				colvarAfidomdepartamento.DataType = DbType.AnsiString;
				colvarAfidomdepartamento.MaxLength = -1;
				colvarAfidomdepartamento.AutoIncrement = false;
				colvarAfidomdepartamento.IsNullable = true;
				colvarAfidomdepartamento.IsPrimaryKey = false;
				colvarAfidomdepartamento.IsForeignKey = false;
				colvarAfidomdepartamento.IsReadOnly = false;
				colvarAfidomdepartamento.DefaultSetting = @"";
				colvarAfidomdepartamento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomdepartamento);
				
				TableSchema.TableColumn colvarAfidomlocalidad = new TableSchema.TableColumn(schema);
				colvarAfidomlocalidad.ColumnName = "afidomlocalidad";
				colvarAfidomlocalidad.DataType = DbType.AnsiString;
				colvarAfidomlocalidad.MaxLength = -1;
				colvarAfidomlocalidad.AutoIncrement = false;
				colvarAfidomlocalidad.IsNullable = true;
				colvarAfidomlocalidad.IsPrimaryKey = false;
				colvarAfidomlocalidad.IsForeignKey = false;
				colvarAfidomlocalidad.IsReadOnly = false;
				colvarAfidomlocalidad.DefaultSetting = @"";
				colvarAfidomlocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomlocalidad);
				
				TableSchema.TableColumn colvarAfitipocategoria = new TableSchema.TableColumn(schema);
				colvarAfitipocategoria.ColumnName = "afitipocategoria";
				colvarAfitipocategoria.DataType = DbType.Int32;
				colvarAfitipocategoria.MaxLength = 0;
				colvarAfitipocategoria.AutoIncrement = false;
				colvarAfitipocategoria.IsNullable = true;
				colvarAfitipocategoria.IsPrimaryKey = false;
				colvarAfitipocategoria.IsForeignKey = true;
				colvarAfitipocategoria.IsReadOnly = false;
				colvarAfitipocategoria.DefaultSetting = @"";
				
					colvarAfitipocategoria.ForeignKeyTableName = "PN_smitiposcategorias";
				schema.Columns.Add(colvarAfitipocategoria);
				
				TableSchema.TableColumn colvarAfifechanac = new TableSchema.TableColumn(schema);
				colvarAfifechanac.ColumnName = "afifechanac";
				colvarAfifechanac.DataType = DbType.DateTime;
				colvarAfifechanac.MaxLength = 0;
				colvarAfifechanac.AutoIncrement = false;
				colvarAfifechanac.IsNullable = true;
				colvarAfifechanac.IsPrimaryKey = false;
				colvarAfifechanac.IsForeignKey = false;
				colvarAfifechanac.IsReadOnly = false;
				colvarAfifechanac.DefaultSetting = @"";
				colvarAfifechanac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfifechanac);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.AnsiStringFixedLength;
				colvarActivo.MaxLength = 2;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = true;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarCuieefectorasignado = new TableSchema.TableColumn(schema);
				colvarCuieefectorasignado.ColumnName = "cuieefectorasignado";
				colvarCuieefectorasignado.DataType = DbType.AnsiString;
				colvarCuieefectorasignado.MaxLength = 10;
				colvarCuieefectorasignado.AutoIncrement = false;
				colvarCuieefectorasignado.IsNullable = true;
				colvarCuieefectorasignado.IsPrimaryKey = false;
				colvarCuieefectorasignado.IsForeignKey = false;
				colvarCuieefectorasignado.IsReadOnly = false;
				colvarCuieefectorasignado.DefaultSetting = @"";
				colvarCuieefectorasignado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuieefectorasignado);
				
				TableSchema.TableColumn colvarCuielugaratencionhabitual = new TableSchema.TableColumn(schema);
				colvarCuielugaratencionhabitual.ColumnName = "cuielugaratencionhabitual";
				colvarCuielugaratencionhabitual.DataType = DbType.AnsiString;
				colvarCuielugaratencionhabitual.MaxLength = 10;
				colvarCuielugaratencionhabitual.AutoIncrement = false;
				colvarCuielugaratencionhabitual.IsNullable = true;
				colvarCuielugaratencionhabitual.IsPrimaryKey = false;
				colvarCuielugaratencionhabitual.IsForeignKey = false;
				colvarCuielugaratencionhabitual.IsReadOnly = false;
				colvarCuielugaratencionhabitual.DefaultSetting = @"";
				colvarCuielugaratencionhabitual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuielugaratencionhabitual);
				
				TableSchema.TableColumn colvarMotivobaja = new TableSchema.TableColumn(schema);
				colvarMotivobaja.ColumnName = "motivobaja";
				colvarMotivobaja.DataType = DbType.Int32;
				colvarMotivobaja.MaxLength = 0;
				colvarMotivobaja.AutoIncrement = false;
				colvarMotivobaja.IsNullable = true;
				colvarMotivobaja.IsPrimaryKey = false;
				colvarMotivobaja.IsForeignKey = false;
				colvarMotivobaja.IsReadOnly = false;
				colvarMotivobaja.DefaultSetting = @"";
				colvarMotivobaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivobaja);
				
				TableSchema.TableColumn colvarMensajebaja = new TableSchema.TableColumn(schema);
				colvarMensajebaja.ColumnName = "mensajebaja";
				colvarMensajebaja.DataType = DbType.AnsiString;
				colvarMensajebaja.MaxLength = -1;
				colvarMensajebaja.AutoIncrement = false;
				colvarMensajebaja.IsNullable = true;
				colvarMensajebaja.IsPrimaryKey = false;
				colvarMensajebaja.IsForeignKey = false;
				colvarMensajebaja.IsReadOnly = false;
				colvarMensajebaja.DefaultSetting = @"";
				colvarMensajebaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMensajebaja);
				
				TableSchema.TableColumn colvarFechainscripcion = new TableSchema.TableColumn(schema);
				colvarFechainscripcion.ColumnName = "fechainscripcion";
				colvarFechainscripcion.DataType = DbType.DateTime;
				colvarFechainscripcion.MaxLength = 0;
				colvarFechainscripcion.AutoIncrement = false;
				colvarFechainscripcion.IsNullable = true;
				colvarFechainscripcion.IsPrimaryKey = false;
				colvarFechainscripcion.IsForeignKey = false;
				colvarFechainscripcion.IsReadOnly = false;
				colvarFechainscripcion.DefaultSetting = @"";
				colvarFechainscripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechainscripcion);
				
				TableSchema.TableColumn colvarFechacarga = new TableSchema.TableColumn(schema);
				colvarFechacarga.ColumnName = "fechacarga";
				colvarFechacarga.DataType = DbType.DateTime;
				colvarFechacarga.MaxLength = 0;
				colvarFechacarga.AutoIncrement = false;
				colvarFechacarga.IsNullable = true;
				colvarFechacarga.IsPrimaryKey = false;
				colvarFechacarga.IsForeignKey = false;
				colvarFechacarga.IsReadOnly = false;
				colvarFechacarga.DefaultSetting = @"";
				colvarFechacarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechacarga);
				
				TableSchema.TableColumn colvarUsuariocarga = new TableSchema.TableColumn(schema);
				colvarUsuariocarga.ColumnName = "usuariocarga";
				colvarUsuariocarga.DataType = DbType.AnsiString;
				colvarUsuariocarga.MaxLength = -1;
				colvarUsuariocarga.AutoIncrement = false;
				colvarUsuariocarga.IsNullable = true;
				colvarUsuariocarga.IsPrimaryKey = false;
				colvarUsuariocarga.IsForeignKey = false;
				colvarUsuariocarga.IsReadOnly = false;
				colvarUsuariocarga.DefaultSetting = @"";
				colvarUsuariocarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuariocarga);
				
				TableSchema.TableColumn colvarEmbarazoactual = new TableSchema.TableColumn(schema);
				colvarEmbarazoactual.ColumnName = "embarazoactual";
				colvarEmbarazoactual.DataType = DbType.AnsiStringFixedLength;
				colvarEmbarazoactual.MaxLength = 1;
				colvarEmbarazoactual.AutoIncrement = false;
				colvarEmbarazoactual.IsNullable = true;
				colvarEmbarazoactual.IsPrimaryKey = false;
				colvarEmbarazoactual.IsForeignKey = false;
				colvarEmbarazoactual.IsReadOnly = false;
				colvarEmbarazoactual.DefaultSetting = @"";
				colvarEmbarazoactual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoactual);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_smiafiliados",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSmiafiliados")]
		[Bindable(true)]
		public int IdSmiafiliados 
		{
			get { return GetColumnValue<int>(Columns.IdSmiafiliados); }
			set { SetColumnValue(Columns.IdSmiafiliados, value); }
		}
		  
		[XmlAttribute("Clavebeneficiario")]
		[Bindable(true)]
		public string Clavebeneficiario 
		{
			get { return GetColumnValue<string>(Columns.Clavebeneficiario); }
			set { SetColumnValue(Columns.Clavebeneficiario, value); }
		}
		  
		[XmlAttribute("Afiapellido")]
		[Bindable(true)]
		public string Afiapellido 
		{
			get { return GetColumnValue<string>(Columns.Afiapellido); }
			set { SetColumnValue(Columns.Afiapellido, value); }
		}
		  
		[XmlAttribute("Afinombre")]
		[Bindable(true)]
		public string Afinombre 
		{
			get { return GetColumnValue<string>(Columns.Afinombre); }
			set { SetColumnValue(Columns.Afinombre, value); }
		}
		  
		[XmlAttribute("Afitipodoc")]
		[Bindable(true)]
		public string Afitipodoc 
		{
			get { return GetColumnValue<string>(Columns.Afitipodoc); }
			set { SetColumnValue(Columns.Afitipodoc, value); }
		}
		  
		[XmlAttribute("Aficlasedoc")]
		[Bindable(true)]
		public string Aficlasedoc 
		{
			get { return GetColumnValue<string>(Columns.Aficlasedoc); }
			set { SetColumnValue(Columns.Aficlasedoc, value); }
		}
		  
		[XmlAttribute("Afidni")]
		[Bindable(true)]
		public string Afidni 
		{
			get { return GetColumnValue<string>(Columns.Afidni); }
			set { SetColumnValue(Columns.Afidni, value); }
		}
		  
		[XmlAttribute("Afisexo")]
		[Bindable(true)]
		public string Afisexo 
		{
			get { return GetColumnValue<string>(Columns.Afisexo); }
			set { SetColumnValue(Columns.Afisexo, value); }
		}
		  
		[XmlAttribute("Afidomdepartamento")]
		[Bindable(true)]
		public string Afidomdepartamento 
		{
			get { return GetColumnValue<string>(Columns.Afidomdepartamento); }
			set { SetColumnValue(Columns.Afidomdepartamento, value); }
		}
		  
		[XmlAttribute("Afidomlocalidad")]
		[Bindable(true)]
		public string Afidomlocalidad 
		{
			get { return GetColumnValue<string>(Columns.Afidomlocalidad); }
			set { SetColumnValue(Columns.Afidomlocalidad, value); }
		}
		  
		[XmlAttribute("Afitipocategoria")]
		[Bindable(true)]
		public int? Afitipocategoria 
		{
			get { return GetColumnValue<int?>(Columns.Afitipocategoria); }
			set { SetColumnValue(Columns.Afitipocategoria, value); }
		}
		  
		[XmlAttribute("Afifechanac")]
		[Bindable(true)]
		public DateTime? Afifechanac 
		{
			get { return GetColumnValue<DateTime?>(Columns.Afifechanac); }
			set { SetColumnValue(Columns.Afifechanac, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public string Activo 
		{
			get { return GetColumnValue<string>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("Cuieefectorasignado")]
		[Bindable(true)]
		public string Cuieefectorasignado 
		{
			get { return GetColumnValue<string>(Columns.Cuieefectorasignado); }
			set { SetColumnValue(Columns.Cuieefectorasignado, value); }
		}
		  
		[XmlAttribute("Cuielugaratencionhabitual")]
		[Bindable(true)]
		public string Cuielugaratencionhabitual 
		{
			get { return GetColumnValue<string>(Columns.Cuielugaratencionhabitual); }
			set { SetColumnValue(Columns.Cuielugaratencionhabitual, value); }
		}
		  
		[XmlAttribute("Motivobaja")]
		[Bindable(true)]
		public int? Motivobaja 
		{
			get { return GetColumnValue<int?>(Columns.Motivobaja); }
			set { SetColumnValue(Columns.Motivobaja, value); }
		}
		  
		[XmlAttribute("Mensajebaja")]
		[Bindable(true)]
		public string Mensajebaja 
		{
			get { return GetColumnValue<string>(Columns.Mensajebaja); }
			set { SetColumnValue(Columns.Mensajebaja, value); }
		}
		  
		[XmlAttribute("Fechainscripcion")]
		[Bindable(true)]
		public DateTime? Fechainscripcion 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechainscripcion); }
			set { SetColumnValue(Columns.Fechainscripcion, value); }
		}
		  
		[XmlAttribute("Fechacarga")]
		[Bindable(true)]
		public DateTime? Fechacarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechacarga); }
			set { SetColumnValue(Columns.Fechacarga, value); }
		}
		  
		[XmlAttribute("Usuariocarga")]
		[Bindable(true)]
		public string Usuariocarga 
		{
			get { return GetColumnValue<string>(Columns.Usuariocarga); }
			set { SetColumnValue(Columns.Usuariocarga, value); }
		}
		  
		[XmlAttribute("Embarazoactual")]
		[Bindable(true)]
		public string Embarazoactual 
		{
			get { return GetColumnValue<string>(Columns.Embarazoactual); }
			set { SetColumnValue(Columns.Embarazoactual, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnComprobanteCollection colPnComprobanteRecords;
		public DalSic.PnComprobanteCollection PnComprobanteRecords
		{
			get
			{
				if(colPnComprobanteRecords == null)
				{
					colPnComprobanteRecords = new DalSic.PnComprobanteCollection().Where(PnComprobante.Columns.IdSmiafiliados, IdSmiafiliados).Load();
					colPnComprobanteRecords.ListChanged += new ListChangedEventHandler(colPnComprobanteRecords_ListChanged);
				}
				return colPnComprobanteRecords;			
			}
			set 
			{ 
					colPnComprobanteRecords = value; 
					colPnComprobanteRecords.ListChanged += new ListChangedEventHandler(colPnComprobanteRecords_ListChanged);
			}
		}
		
		void colPnComprobanteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnComprobanteRecords[e.NewIndex].IdSmiafiliados = IdSmiafiliados;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnSmitiposcategoria ActiveRecord object related to this PnSmiafiliado
		/// 
		/// </summary>
		public DalSic.PnSmitiposcategoria PnSmitiposcategoria
		{
			get { return DalSic.PnSmitiposcategoria.FetchByID(this.Afitipocategoria); }
			set { SetColumnValue("afitipocategoria", value.Codcategoria); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varClavebeneficiario,string varAfiapellido,string varAfinombre,string varAfitipodoc,string varAficlasedoc,string varAfidni,string varAfisexo,string varAfidomdepartamento,string varAfidomlocalidad,int? varAfitipocategoria,DateTime? varAfifechanac,string varActivo,string varCuieefectorasignado,string varCuielugaratencionhabitual,int? varMotivobaja,string varMensajebaja,DateTime? varFechainscripcion,DateTime? varFechacarga,string varUsuariocarga,string varEmbarazoactual)
		{
			PnSmiafiliado item = new PnSmiafiliado();
			
			item.Clavebeneficiario = varClavebeneficiario;
			
			item.Afiapellido = varAfiapellido;
			
			item.Afinombre = varAfinombre;
			
			item.Afitipodoc = varAfitipodoc;
			
			item.Aficlasedoc = varAficlasedoc;
			
			item.Afidni = varAfidni;
			
			item.Afisexo = varAfisexo;
			
			item.Afidomdepartamento = varAfidomdepartamento;
			
			item.Afidomlocalidad = varAfidomlocalidad;
			
			item.Afitipocategoria = varAfitipocategoria;
			
			item.Afifechanac = varAfifechanac;
			
			item.Activo = varActivo;
			
			item.Cuieefectorasignado = varCuieefectorasignado;
			
			item.Cuielugaratencionhabitual = varCuielugaratencionhabitual;
			
			item.Motivobaja = varMotivobaja;
			
			item.Mensajebaja = varMensajebaja;
			
			item.Fechainscripcion = varFechainscripcion;
			
			item.Fechacarga = varFechacarga;
			
			item.Usuariocarga = varUsuariocarga;
			
			item.Embarazoactual = varEmbarazoactual;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSmiafiliados,string varClavebeneficiario,string varAfiapellido,string varAfinombre,string varAfitipodoc,string varAficlasedoc,string varAfidni,string varAfisexo,string varAfidomdepartamento,string varAfidomlocalidad,int? varAfitipocategoria,DateTime? varAfifechanac,string varActivo,string varCuieefectorasignado,string varCuielugaratencionhabitual,int? varMotivobaja,string varMensajebaja,DateTime? varFechainscripcion,DateTime? varFechacarga,string varUsuariocarga,string varEmbarazoactual)
		{
			PnSmiafiliado item = new PnSmiafiliado();
			
				item.IdSmiafiliados = varIdSmiafiliados;
			
				item.Clavebeneficiario = varClavebeneficiario;
			
				item.Afiapellido = varAfiapellido;
			
				item.Afinombre = varAfinombre;
			
				item.Afitipodoc = varAfitipodoc;
			
				item.Aficlasedoc = varAficlasedoc;
			
				item.Afidni = varAfidni;
			
				item.Afisexo = varAfisexo;
			
				item.Afidomdepartamento = varAfidomdepartamento;
			
				item.Afidomlocalidad = varAfidomlocalidad;
			
				item.Afitipocategoria = varAfitipocategoria;
			
				item.Afifechanac = varAfifechanac;
			
				item.Activo = varActivo;
			
				item.Cuieefectorasignado = varCuieefectorasignado;
			
				item.Cuielugaratencionhabitual = varCuielugaratencionhabitual;
			
				item.Motivobaja = varMotivobaja;
			
				item.Mensajebaja = varMensajebaja;
			
				item.Fechainscripcion = varFechainscripcion;
			
				item.Fechacarga = varFechacarga;
			
				item.Usuariocarga = varUsuariocarga;
			
				item.Embarazoactual = varEmbarazoactual;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSmiafiliadosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClavebeneficiarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AfiapellidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AfinombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AfitipodocColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AficlasedocColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidniColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AfisexoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomdepartamentoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomlocalidadColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn AfitipocategoriaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AfifechanacColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieefectorasignadoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn CuielugaratencionhabitualColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivobajaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn MensajebajaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn FechainscripcionColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn FechacargaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuariocargaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoactualColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSmiafiliados = @"id_smiafiliados";
			 public static string Clavebeneficiario = @"clavebeneficiario";
			 public static string Afiapellido = @"afiapellido";
			 public static string Afinombre = @"afinombre";
			 public static string Afitipodoc = @"afitipodoc";
			 public static string Aficlasedoc = @"aficlasedoc";
			 public static string Afidni = @"afidni";
			 public static string Afisexo = @"afisexo";
			 public static string Afidomdepartamento = @"afidomdepartamento";
			 public static string Afidomlocalidad = @"afidomlocalidad";
			 public static string Afitipocategoria = @"afitipocategoria";
			 public static string Afifechanac = @"afifechanac";
			 public static string Activo = @"activo";
			 public static string Cuieefectorasignado = @"cuieefectorasignado";
			 public static string Cuielugaratencionhabitual = @"cuielugaratencionhabitual";
			 public static string Motivobaja = @"motivobaja";
			 public static string Mensajebaja = @"mensajebaja";
			 public static string Fechainscripcion = @"fechainscripcion";
			 public static string Fechacarga = @"fechacarga";
			 public static string Usuariocarga = @"usuariocarga";
			 public static string Embarazoactual = @"embarazoactual";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnComprobanteRecords != null)
                {
                    foreach (DalSic.PnComprobante item in colPnComprobanteRecords)
                    {
                        if (item.IdSmiafiliados != IdSmiafiliados)
                        {
                            item.IdSmiafiliados = IdSmiafiliados;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnComprobanteRecords != null)
                {
                    colPnComprobanteRecords.SaveAll();
               }
		}
        #endregion
	}
}
