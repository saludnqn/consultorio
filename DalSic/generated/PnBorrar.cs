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
	/// Strongly-typed collection for the PnBorrar class.
	/// </summary>
    [Serializable]
	public partial class PnBorrarCollection : ActiveList<PnBorrar, PnBorrarCollection>
	{	   
		public PnBorrarCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnBorrarCollection</returns>
		public PnBorrarCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnBorrar o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_Borrar table.
	/// </summary>
	[Serializable]
	public partial class PnBorrar : ActiveRecord<PnBorrar>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnBorrar()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnBorrar(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnBorrar(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnBorrar(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_Borrar", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "id_nomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = true;
				colvarIdNomenclador.IsNullable = false;
				colvarIdNomenclador.IsPrimaryKey = true;
				colvarIdNomenclador.IsForeignKey = false;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				colvarIdNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiString;
				colvarCodigo.MaxLength = -1;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = true;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarGrupo = new TableSchema.TableColumn(schema);
				colvarGrupo.ColumnName = "grupo";
				colvarGrupo.DataType = DbType.AnsiString;
				colvarGrupo.MaxLength = -1;
				colvarGrupo.AutoIncrement = false;
				colvarGrupo.IsNullable = true;
				colvarGrupo.IsPrimaryKey = false;
				colvarGrupo.IsForeignKey = false;
				colvarGrupo.IsReadOnly = false;
				colvarGrupo.DefaultSetting = @"";
				colvarGrupo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupo);
				
				TableSchema.TableColumn colvarSubgrupo = new TableSchema.TableColumn(schema);
				colvarSubgrupo.ColumnName = "subgrupo";
				colvarSubgrupo.DataType = DbType.AnsiString;
				colvarSubgrupo.MaxLength = -1;
				colvarSubgrupo.AutoIncrement = false;
				colvarSubgrupo.IsNullable = true;
				colvarSubgrupo.IsPrimaryKey = false;
				colvarSubgrupo.IsForeignKey = false;
				colvarSubgrupo.IsReadOnly = false;
				colvarSubgrupo.DefaultSetting = @"";
				colvarSubgrupo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubgrupo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarPrecio = new TableSchema.TableColumn(schema);
				colvarPrecio.ColumnName = "precio";
				colvarPrecio.DataType = DbType.Decimal;
				colvarPrecio.MaxLength = 0;
				colvarPrecio.AutoIncrement = false;
				colvarPrecio.IsNullable = true;
				colvarPrecio.IsPrimaryKey = false;
				colvarPrecio.IsForeignKey = false;
				colvarPrecio.IsReadOnly = false;
				colvarPrecio.DefaultSetting = @"";
				colvarPrecio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrecio);
				
				TableSchema.TableColumn colvarTipoNomenclador = new TableSchema.TableColumn(schema);
				colvarTipoNomenclador.ColumnName = "tipo_nomenclador";
				colvarTipoNomenclador.DataType = DbType.AnsiString;
				colvarTipoNomenclador.MaxLength = -1;
				colvarTipoNomenclador.AutoIncrement = false;
				colvarTipoNomenclador.IsNullable = true;
				colvarTipoNomenclador.IsPrimaryKey = false;
				colvarTipoNomenclador.IsForeignKey = false;
				colvarTipoNomenclador.IsReadOnly = false;
				colvarTipoNomenclador.DefaultSetting = @"";
				colvarTipoNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoNomenclador);
				
				TableSchema.TableColumn colvarIdNomencladorDetalle = new TableSchema.TableColumn(schema);
				colvarIdNomencladorDetalle.ColumnName = "id_nomenclador_detalle";
				colvarIdNomencladorDetalle.DataType = DbType.Int32;
				colvarIdNomencladorDetalle.MaxLength = 0;
				colvarIdNomencladorDetalle.AutoIncrement = false;
				colvarIdNomencladorDetalle.IsNullable = true;
				colvarIdNomencladorDetalle.IsPrimaryKey = false;
				colvarIdNomencladorDetalle.IsForeignKey = false;
				colvarIdNomencladorDetalle.IsReadOnly = false;
				colvarIdNomencladorDetalle.DefaultSetting = @"";
				colvarIdNomencladorDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomencladorDetalle);
				
				TableSchema.TableColumn colvarBorrado = new TableSchema.TableColumn(schema);
				colvarBorrado.ColumnName = "borrado";
				colvarBorrado.DataType = DbType.AnsiString;
				colvarBorrado.MaxLength = 5;
				colvarBorrado.AutoIncrement = false;
				colvarBorrado.IsNullable = true;
				colvarBorrado.IsPrimaryKey = false;
				colvarBorrado.IsForeignKey = false;
				colvarBorrado.IsReadOnly = false;
				colvarBorrado.DefaultSetting = @"";
				colvarBorrado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBorrado);
				
				TableSchema.TableColumn colvarDefinicion = new TableSchema.TableColumn(schema);
				colvarDefinicion.ColumnName = "definicion";
				colvarDefinicion.DataType = DbType.AnsiString;
				colvarDefinicion.MaxLength = -1;
				colvarDefinicion.AutoIncrement = false;
				colvarDefinicion.IsNullable = true;
				colvarDefinicion.IsPrimaryKey = false;
				colvarDefinicion.IsForeignKey = false;
				colvarDefinicion.IsReadOnly = false;
				colvarDefinicion.DefaultSetting = @"";
				colvarDefinicion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDefinicion);
				
				TableSchema.TableColumn colvarDiasUti = new TableSchema.TableColumn(schema);
				colvarDiasUti.ColumnName = "dias_uti";
				colvarDiasUti.DataType = DbType.Int32;
				colvarDiasUti.MaxLength = 0;
				colvarDiasUti.AutoIncrement = false;
				colvarDiasUti.IsNullable = true;
				colvarDiasUti.IsPrimaryKey = false;
				colvarDiasUti.IsForeignKey = false;
				colvarDiasUti.IsReadOnly = false;
				colvarDiasUti.DefaultSetting = @"";
				colvarDiasUti.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiasUti);
				
				TableSchema.TableColumn colvarDiasSala = new TableSchema.TableColumn(schema);
				colvarDiasSala.ColumnName = "dias_sala";
				colvarDiasSala.DataType = DbType.Int32;
				colvarDiasSala.MaxLength = 0;
				colvarDiasSala.AutoIncrement = false;
				colvarDiasSala.IsNullable = true;
				colvarDiasSala.IsPrimaryKey = false;
				colvarDiasSala.IsForeignKey = false;
				colvarDiasSala.IsReadOnly = false;
				colvarDiasSala.DefaultSetting = @"";
				colvarDiasSala.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiasSala);
				
				TableSchema.TableColumn colvarDiasTotal = new TableSchema.TableColumn(schema);
				colvarDiasTotal.ColumnName = "dias_total";
				colvarDiasTotal.DataType = DbType.Int32;
				colvarDiasTotal.MaxLength = 0;
				colvarDiasTotal.AutoIncrement = false;
				colvarDiasTotal.IsNullable = true;
				colvarDiasTotal.IsPrimaryKey = false;
				colvarDiasTotal.IsForeignKey = false;
				colvarDiasTotal.IsReadOnly = false;
				colvarDiasTotal.DefaultSetting = @"";
				colvarDiasTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiasTotal);
				
				TableSchema.TableColumn colvarDiasMax = new TableSchema.TableColumn(schema);
				colvarDiasMax.ColumnName = "dias_max";
				colvarDiasMax.DataType = DbType.Int32;
				colvarDiasMax.MaxLength = 0;
				colvarDiasMax.AutoIncrement = false;
				colvarDiasMax.IsNullable = true;
				colvarDiasMax.IsPrimaryKey = false;
				colvarDiasMax.IsForeignKey = false;
				colvarDiasMax.IsReadOnly = false;
				colvarDiasMax.DefaultSetting = @"";
				colvarDiasMax.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiasMax);
				
				TableSchema.TableColumn colvarNeo = new TableSchema.TableColumn(schema);
				colvarNeo.ColumnName = "neo";
				colvarNeo.DataType = DbType.AnsiString;
				colvarNeo.MaxLength = 1;
				colvarNeo.AutoIncrement = false;
				colvarNeo.IsNullable = true;
				colvarNeo.IsPrimaryKey = false;
				colvarNeo.IsForeignKey = false;
				colvarNeo.IsReadOnly = false;
				colvarNeo.DefaultSetting = @"";
				colvarNeo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeo);
				
				TableSchema.TableColumn colvarCeroacinco = new TableSchema.TableColumn(schema);
				colvarCeroacinco.ColumnName = "ceroacinco";
				colvarCeroacinco.DataType = DbType.AnsiString;
				colvarCeroacinco.MaxLength = 1;
				colvarCeroacinco.AutoIncrement = false;
				colvarCeroacinco.IsNullable = true;
				colvarCeroacinco.IsPrimaryKey = false;
				colvarCeroacinco.IsForeignKey = false;
				colvarCeroacinco.IsReadOnly = false;
				colvarCeroacinco.DefaultSetting = @"";
				colvarCeroacinco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCeroacinco);
				
				TableSchema.TableColumn colvarSeisanueve = new TableSchema.TableColumn(schema);
				colvarSeisanueve.ColumnName = "seisanueve";
				colvarSeisanueve.DataType = DbType.AnsiString;
				colvarSeisanueve.MaxLength = 1;
				colvarSeisanueve.AutoIncrement = false;
				colvarSeisanueve.IsNullable = true;
				colvarSeisanueve.IsPrimaryKey = false;
				colvarSeisanueve.IsForeignKey = false;
				colvarSeisanueve.IsReadOnly = false;
				colvarSeisanueve.DefaultSetting = @"";
				colvarSeisanueve.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeisanueve);
				
				TableSchema.TableColumn colvarAdol = new TableSchema.TableColumn(schema);
				colvarAdol.ColumnName = "adol";
				colvarAdol.DataType = DbType.AnsiString;
				colvarAdol.MaxLength = 1;
				colvarAdol.AutoIncrement = false;
				colvarAdol.IsNullable = true;
				colvarAdol.IsPrimaryKey = false;
				colvarAdol.IsForeignKey = false;
				colvarAdol.IsReadOnly = false;
				colvarAdol.DefaultSetting = @"";
				colvarAdol.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdol);
				
				TableSchema.TableColumn colvarAdulto = new TableSchema.TableColumn(schema);
				colvarAdulto.ColumnName = "adulto";
				colvarAdulto.DataType = DbType.AnsiString;
				colvarAdulto.MaxLength = 1;
				colvarAdulto.AutoIncrement = false;
				colvarAdulto.IsNullable = true;
				colvarAdulto.IsPrimaryKey = false;
				colvarAdulto.IsForeignKey = false;
				colvarAdulto.IsReadOnly = false;
				colvarAdulto.DefaultSetting = @"";
				colvarAdulto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdulto);
				
				TableSchema.TableColumn colvarF = new TableSchema.TableColumn(schema);
				colvarF.ColumnName = "f";
				colvarF.DataType = DbType.AnsiString;
				colvarF.MaxLength = 1;
				colvarF.AutoIncrement = false;
				colvarF.IsNullable = true;
				colvarF.IsPrimaryKey = false;
				colvarF.IsForeignKey = false;
				colvarF.IsReadOnly = false;
				colvarF.DefaultSetting = @"";
				colvarF.ForeignKeyTableName = "";
				schema.Columns.Add(colvarF);
				
				TableSchema.TableColumn colvarM = new TableSchema.TableColumn(schema);
				colvarM.ColumnName = "m";
				colvarM.DataType = DbType.AnsiString;
				colvarM.MaxLength = 1;
				colvarM.AutoIncrement = false;
				colvarM.IsNullable = true;
				colvarM.IsPrimaryKey = false;
				colvarM.IsForeignKey = false;
				colvarM.IsReadOnly = false;
				colvarM.DefaultSetting = @"";
				colvarM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarM);
				
				TableSchema.TableColumn colvarLineaCuidado = new TableSchema.TableColumn(schema);
				colvarLineaCuidado.ColumnName = "linea_cuidado";
				colvarLineaCuidado.DataType = DbType.AnsiString;
				colvarLineaCuidado.MaxLength = 30;
				colvarLineaCuidado.AutoIncrement = false;
				colvarLineaCuidado.IsNullable = true;
				colvarLineaCuidado.IsPrimaryKey = false;
				colvarLineaCuidado.IsForeignKey = false;
				colvarLineaCuidado.IsReadOnly = false;
				colvarLineaCuidado.DefaultSetting = @"";
				colvarLineaCuidado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLineaCuidado);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_Borrar",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int IdNomenclador 
		{
			get { return GetColumnValue<int>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("Grupo")]
		[Bindable(true)]
		public string Grupo 
		{
			get { return GetColumnValue<string>(Columns.Grupo); }
			set { SetColumnValue(Columns.Grupo, value); }
		}
		  
		[XmlAttribute("Subgrupo")]
		[Bindable(true)]
		public string Subgrupo 
		{
			get { return GetColumnValue<string>(Columns.Subgrupo); }
			set { SetColumnValue(Columns.Subgrupo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Precio")]
		[Bindable(true)]
		public decimal? Precio 
		{
			get { return GetColumnValue<decimal?>(Columns.Precio); }
			set { SetColumnValue(Columns.Precio, value); }
		}
		  
		[XmlAttribute("TipoNomenclador")]
		[Bindable(true)]
		public string TipoNomenclador 
		{
			get { return GetColumnValue<string>(Columns.TipoNomenclador); }
			set { SetColumnValue(Columns.TipoNomenclador, value); }
		}
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int? IdNomencladorDetalle 
		{
			get { return GetColumnValue<int?>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
		}
		  
		[XmlAttribute("Borrado")]
		[Bindable(true)]
		public string Borrado 
		{
			get { return GetColumnValue<string>(Columns.Borrado); }
			set { SetColumnValue(Columns.Borrado, value); }
		}
		  
		[XmlAttribute("Definicion")]
		[Bindable(true)]
		public string Definicion 
		{
			get { return GetColumnValue<string>(Columns.Definicion); }
			set { SetColumnValue(Columns.Definicion, value); }
		}
		  
		[XmlAttribute("DiasUti")]
		[Bindable(true)]
		public int? DiasUti 
		{
			get { return GetColumnValue<int?>(Columns.DiasUti); }
			set { SetColumnValue(Columns.DiasUti, value); }
		}
		  
		[XmlAttribute("DiasSala")]
		[Bindable(true)]
		public int? DiasSala 
		{
			get { return GetColumnValue<int?>(Columns.DiasSala); }
			set { SetColumnValue(Columns.DiasSala, value); }
		}
		  
		[XmlAttribute("DiasTotal")]
		[Bindable(true)]
		public int? DiasTotal 
		{
			get { return GetColumnValue<int?>(Columns.DiasTotal); }
			set { SetColumnValue(Columns.DiasTotal, value); }
		}
		  
		[XmlAttribute("DiasMax")]
		[Bindable(true)]
		public int? DiasMax 
		{
			get { return GetColumnValue<int?>(Columns.DiasMax); }
			set { SetColumnValue(Columns.DiasMax, value); }
		}
		  
		[XmlAttribute("Neo")]
		[Bindable(true)]
		public string Neo 
		{
			get { return GetColumnValue<string>(Columns.Neo); }
			set { SetColumnValue(Columns.Neo, value); }
		}
		  
		[XmlAttribute("Ceroacinco")]
		[Bindable(true)]
		public string Ceroacinco 
		{
			get { return GetColumnValue<string>(Columns.Ceroacinco); }
			set { SetColumnValue(Columns.Ceroacinco, value); }
		}
		  
		[XmlAttribute("Seisanueve")]
		[Bindable(true)]
		public string Seisanueve 
		{
			get { return GetColumnValue<string>(Columns.Seisanueve); }
			set { SetColumnValue(Columns.Seisanueve, value); }
		}
		  
		[XmlAttribute("Adol")]
		[Bindable(true)]
		public string Adol 
		{
			get { return GetColumnValue<string>(Columns.Adol); }
			set { SetColumnValue(Columns.Adol, value); }
		}
		  
		[XmlAttribute("Adulto")]
		[Bindable(true)]
		public string Adulto 
		{
			get { return GetColumnValue<string>(Columns.Adulto); }
			set { SetColumnValue(Columns.Adulto, value); }
		}
		  
		[XmlAttribute("F")]
		[Bindable(true)]
		public string F 
		{
			get { return GetColumnValue<string>(Columns.F); }
			set { SetColumnValue(Columns.F, value); }
		}
		  
		[XmlAttribute("M")]
		[Bindable(true)]
		public string M 
		{
			get { return GetColumnValue<string>(Columns.M); }
			set { SetColumnValue(Columns.M, value); }
		}
		  
		[XmlAttribute("LineaCuidado")]
		[Bindable(true)]
		public string LineaCuidado 
		{
			get { return GetColumnValue<string>(Columns.LineaCuidado); }
			set { SetColumnValue(Columns.LineaCuidado, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodigo,string varGrupo,string varSubgrupo,string varDescripcion,decimal? varPrecio,string varTipoNomenclador,int? varIdNomencladorDetalle,string varBorrado,string varDefinicion,int? varDiasUti,int? varDiasSala,int? varDiasTotal,int? varDiasMax,string varNeo,string varCeroacinco,string varSeisanueve,string varAdol,string varAdulto,string varF,string varM,string varLineaCuidado)
		{
			PnBorrar item = new PnBorrar();
			
			item.Codigo = varCodigo;
			
			item.Grupo = varGrupo;
			
			item.Subgrupo = varSubgrupo;
			
			item.Descripcion = varDescripcion;
			
			item.Precio = varPrecio;
			
			item.TipoNomenclador = varTipoNomenclador;
			
			item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
			item.Borrado = varBorrado;
			
			item.Definicion = varDefinicion;
			
			item.DiasUti = varDiasUti;
			
			item.DiasSala = varDiasSala;
			
			item.DiasTotal = varDiasTotal;
			
			item.DiasMax = varDiasMax;
			
			item.Neo = varNeo;
			
			item.Ceroacinco = varCeroacinco;
			
			item.Seisanueve = varSeisanueve;
			
			item.Adol = varAdol;
			
			item.Adulto = varAdulto;
			
			item.F = varF;
			
			item.M = varM;
			
			item.LineaCuidado = varLineaCuidado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNomenclador,string varCodigo,string varGrupo,string varSubgrupo,string varDescripcion,decimal? varPrecio,string varTipoNomenclador,int? varIdNomencladorDetalle,string varBorrado,string varDefinicion,int? varDiasUti,int? varDiasSala,int? varDiasTotal,int? varDiasMax,string varNeo,string varCeroacinco,string varSeisanueve,string varAdol,string varAdulto,string varF,string varM,string varLineaCuidado)
		{
			PnBorrar item = new PnBorrar();
			
				item.IdNomenclador = varIdNomenclador;
			
				item.Codigo = varCodigo;
			
				item.Grupo = varGrupo;
			
				item.Subgrupo = varSubgrupo;
			
				item.Descripcion = varDescripcion;
			
				item.Precio = varPrecio;
			
				item.TipoNomenclador = varTipoNomenclador;
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
				item.Borrado = varBorrado;
			
				item.Definicion = varDefinicion;
			
				item.DiasUti = varDiasUti;
			
				item.DiasSala = varDiasSala;
			
				item.DiasTotal = varDiasTotal;
			
				item.DiasMax = varDiasMax;
			
				item.Neo = varNeo;
			
				item.Ceroacinco = varCeroacinco;
			
				item.Seisanueve = varSeisanueve;
			
				item.Adol = varAdol;
			
				item.Adulto = varAdulto;
			
				item.F = varF;
			
				item.M = varM;
			
				item.LineaCuidado = varLineaCuidado;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SubgrupoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PrecioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoNomencladorColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn BorradoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DefinicionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasUtiColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasSalaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasTotalColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasMaxColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn NeoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CeroacincoColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn SeisanueveColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn AdolColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn AdultoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn FColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn MColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn LineaCuidadoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNomenclador = @"id_nomenclador";
			 public static string Codigo = @"codigo";
			 public static string Grupo = @"grupo";
			 public static string Subgrupo = @"subgrupo";
			 public static string Descripcion = @"descripcion";
			 public static string Precio = @"precio";
			 public static string TipoNomenclador = @"tipo_nomenclador";
			 public static string IdNomencladorDetalle = @"id_nomenclador_detalle";
			 public static string Borrado = @"borrado";
			 public static string Definicion = @"definicion";
			 public static string DiasUti = @"dias_uti";
			 public static string DiasSala = @"dias_sala";
			 public static string DiasTotal = @"dias_total";
			 public static string DiasMax = @"dias_max";
			 public static string Neo = @"neo";
			 public static string Ceroacinco = @"ceroacinco";
			 public static string Seisanueve = @"seisanueve";
			 public static string Adol = @"adol";
			 public static string Adulto = @"adulto";
			 public static string F = @"f";
			 public static string M = @"m";
			 public static string LineaCuidado = @"linea_cuidado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
