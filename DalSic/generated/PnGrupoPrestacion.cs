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
	/// Strongly-typed collection for the PnGrupoPrestacion class.
	/// </summary>
    [Serializable]
	public partial class PnGrupoPrestacionCollection : ActiveList<PnGrupoPrestacion, PnGrupoPrestacionCollection>
	{	   
		public PnGrupoPrestacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnGrupoPrestacionCollection</returns>
		public PnGrupoPrestacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnGrupoPrestacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_grupo_prestacion table.
	/// </summary>
	[Serializable]
	public partial class PnGrupoPrestacion : ActiveRecord<PnGrupoPrestacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnGrupoPrestacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnGrupoPrestacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnGrupoPrestacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnGrupoPrestacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_grupo_prestacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCategoriaPrestacion = new TableSchema.TableColumn(schema);
				colvarIdCategoriaPrestacion.ColumnName = "id_categoria_prestacion";
				colvarIdCategoriaPrestacion.DataType = DbType.Int32;
				colvarIdCategoriaPrestacion.MaxLength = 0;
				colvarIdCategoriaPrestacion.AutoIncrement = false;
				colvarIdCategoriaPrestacion.IsNullable = false;
				colvarIdCategoriaPrestacion.IsPrimaryKey = false;
				colvarIdCategoriaPrestacion.IsForeignKey = false;
				colvarIdCategoriaPrestacion.IsReadOnly = false;
				colvarIdCategoriaPrestacion.DefaultSetting = @"";
				colvarIdCategoriaPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCategoriaPrestacion);
				
				TableSchema.TableColumn colvarTema = new TableSchema.TableColumn(schema);
				colvarTema.ColumnName = "tema";
				colvarTema.DataType = DbType.AnsiString;
				colvarTema.MaxLength = 255;
				colvarTema.AutoIncrement = false;
				colvarTema.IsNullable = true;
				colvarTema.IsPrimaryKey = false;
				colvarTema.IsForeignKey = false;
				colvarTema.IsReadOnly = false;
				colvarTema.DefaultSetting = @"";
				colvarTema.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTema);
				
				TableSchema.TableColumn colvarCategoria = new TableSchema.TableColumn(schema);
				colvarCategoria.ColumnName = "categoria";
				colvarCategoria.DataType = DbType.AnsiString;
				colvarCategoria.MaxLength = 255;
				colvarCategoria.AutoIncrement = false;
				colvarCategoria.IsNullable = true;
				colvarCategoria.IsPrimaryKey = false;
				colvarCategoria.IsForeignKey = false;
				colvarCategoria.IsReadOnly = false;
				colvarCategoria.DefaultSetting = @"";
				colvarCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoria);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiString;
				colvarCodigo.MaxLength = 255;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = true;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarCategoriaPadre = new TableSchema.TableColumn(schema);
				colvarCategoriaPadre.ColumnName = "categoria_padre";
				colvarCategoriaPadre.DataType = DbType.AnsiString;
				colvarCategoriaPadre.MaxLength = 255;
				colvarCategoriaPadre.AutoIncrement = false;
				colvarCategoriaPadre.IsNullable = true;
				colvarCategoriaPadre.IsPrimaryKey = false;
				colvarCategoriaPadre.IsForeignKey = false;
				colvarCategoriaPadre.IsReadOnly = false;
				colvarCategoriaPadre.DefaultSetting = @"";
				colvarCategoriaPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoriaPadre);
				
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
				
				TableSchema.TableColumn colvarNeo = new TableSchema.TableColumn(schema);
				colvarNeo.ColumnName = "neo";
				colvarNeo.DataType = DbType.AnsiStringFixedLength;
				colvarNeo.MaxLength = 1;
				colvarNeo.AutoIncrement = false;
				colvarNeo.IsNullable = true;
				colvarNeo.IsPrimaryKey = false;
				colvarNeo.IsForeignKey = false;
				colvarNeo.IsReadOnly = false;
				
						colvarNeo.DefaultSetting = @"((0))";
				colvarNeo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNeo);
				
				TableSchema.TableColumn colvarCeroacinco = new TableSchema.TableColumn(schema);
				colvarCeroacinco.ColumnName = "ceroacinco";
				colvarCeroacinco.DataType = DbType.AnsiStringFixedLength;
				colvarCeroacinco.MaxLength = 1;
				colvarCeroacinco.AutoIncrement = false;
				colvarCeroacinco.IsNullable = true;
				colvarCeroacinco.IsPrimaryKey = false;
				colvarCeroacinco.IsForeignKey = false;
				colvarCeroacinco.IsReadOnly = false;
				
						colvarCeroacinco.DefaultSetting = @"((0))";
				colvarCeroacinco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCeroacinco);
				
				TableSchema.TableColumn colvarIdGrupoPrestacion = new TableSchema.TableColumn(schema);
				colvarIdGrupoPrestacion.ColumnName = "id_grupo_prestacion";
				colvarIdGrupoPrestacion.DataType = DbType.Int32;
				colvarIdGrupoPrestacion.MaxLength = 0;
				colvarIdGrupoPrestacion.AutoIncrement = true;
				colvarIdGrupoPrestacion.IsNullable = false;
				colvarIdGrupoPrestacion.IsPrimaryKey = true;
				colvarIdGrupoPrestacion.IsForeignKey = false;
				colvarIdGrupoPrestacion.IsReadOnly = false;
				colvarIdGrupoPrestacion.DefaultSetting = @"";
				colvarIdGrupoPrestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdGrupoPrestacion);
				
				TableSchema.TableColumn colvarSeisanueve = new TableSchema.TableColumn(schema);
				colvarSeisanueve.ColumnName = "seisanueve";
				colvarSeisanueve.DataType = DbType.AnsiStringFixedLength;
				colvarSeisanueve.MaxLength = 1;
				colvarSeisanueve.AutoIncrement = false;
				colvarSeisanueve.IsNullable = true;
				colvarSeisanueve.IsPrimaryKey = false;
				colvarSeisanueve.IsForeignKey = false;
				colvarSeisanueve.IsReadOnly = false;
				
						colvarSeisanueve.DefaultSetting = @"((0))";
				colvarSeisanueve.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeisanueve);
				
				TableSchema.TableColumn colvarAdol = new TableSchema.TableColumn(schema);
				colvarAdol.ColumnName = "adol";
				colvarAdol.DataType = DbType.AnsiStringFixedLength;
				colvarAdol.MaxLength = 1;
				colvarAdol.AutoIncrement = false;
				colvarAdol.IsNullable = true;
				colvarAdol.IsPrimaryKey = false;
				colvarAdol.IsForeignKey = false;
				colvarAdol.IsReadOnly = false;
				
						colvarAdol.DefaultSetting = @"((0))";
				colvarAdol.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdol);
				
				TableSchema.TableColumn colvarAdulto = new TableSchema.TableColumn(schema);
				colvarAdulto.ColumnName = "adulto";
				colvarAdulto.DataType = DbType.AnsiStringFixedLength;
				colvarAdulto.MaxLength = 1;
				colvarAdulto.AutoIncrement = false;
				colvarAdulto.IsNullable = true;
				colvarAdulto.IsPrimaryKey = false;
				colvarAdulto.IsForeignKey = false;
				colvarAdulto.IsReadOnly = false;
				
						colvarAdulto.DefaultSetting = @"((0))";
				colvarAdulto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdulto);
				
				TableSchema.TableColumn colvarF = new TableSchema.TableColumn(schema);
				colvarF.ColumnName = "f";
				colvarF.DataType = DbType.AnsiStringFixedLength;
				colvarF.MaxLength = 1;
				colvarF.AutoIncrement = false;
				colvarF.IsNullable = true;
				colvarF.IsPrimaryKey = false;
				colvarF.IsForeignKey = false;
				colvarF.IsReadOnly = false;
				
						colvarF.DefaultSetting = @"((0))";
				colvarF.ForeignKeyTableName = "";
				schema.Columns.Add(colvarF);
				
				TableSchema.TableColumn colvarM = new TableSchema.TableColumn(schema);
				colvarM.ColumnName = "m";
				colvarM.DataType = DbType.AnsiStringFixedLength;
				colvarM.MaxLength = 1;
				colvarM.AutoIncrement = false;
				colvarM.IsNullable = true;
				colvarM.IsPrimaryKey = false;
				colvarM.IsForeignKey = false;
				colvarM.IsReadOnly = false;
				
						colvarM.DefaultSetting = @"((0))";
				colvarM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarM);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_grupo_prestacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCategoriaPrestacion")]
		[Bindable(true)]
		public int IdCategoriaPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdCategoriaPrestacion); }
			set { SetColumnValue(Columns.IdCategoriaPrestacion, value); }
		}
		  
		[XmlAttribute("Tema")]
		[Bindable(true)]
		public string Tema 
		{
			get { return GetColumnValue<string>(Columns.Tema); }
			set { SetColumnValue(Columns.Tema, value); }
		}
		  
		[XmlAttribute("Categoria")]
		[Bindable(true)]
		public string Categoria 
		{
			get { return GetColumnValue<string>(Columns.Categoria); }
			set { SetColumnValue(Columns.Categoria, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("CategoriaPadre")]
		[Bindable(true)]
		public string CategoriaPadre 
		{
			get { return GetColumnValue<string>(Columns.CategoriaPadre); }
			set { SetColumnValue(Columns.CategoriaPadre, value); }
		}
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int? IdNomencladorDetalle 
		{
			get { return GetColumnValue<int?>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
		}
		  
		[XmlAttribute("Precio")]
		[Bindable(true)]
		public decimal? Precio 
		{
			get { return GetColumnValue<decimal?>(Columns.Precio); }
			set { SetColumnValue(Columns.Precio, value); }
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
		  
		[XmlAttribute("IdGrupoPrestacion")]
		[Bindable(true)]
		public int IdGrupoPrestacion 
		{
			get { return GetColumnValue<int>(Columns.IdGrupoPrestacion); }
			set { SetColumnValue(Columns.IdGrupoPrestacion, value); }
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
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdCategoriaPrestacion,string varTema,string varCategoria,string varCodigo,string varCategoriaPadre,int? varIdNomencladorDetalle,decimal? varPrecio,string varNeo,string varCeroacinco,string varSeisanueve,string varAdol,string varAdulto,string varF,string varM,int? varDiasUti,int? varDiasSala,int? varDiasTotal,int? varDiasMax)
		{
			PnGrupoPrestacion item = new PnGrupoPrestacion();
			
			item.IdCategoriaPrestacion = varIdCategoriaPrestacion;
			
			item.Tema = varTema;
			
			item.Categoria = varCategoria;
			
			item.Codigo = varCodigo;
			
			item.CategoriaPadre = varCategoriaPadre;
			
			item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
			item.Precio = varPrecio;
			
			item.Neo = varNeo;
			
			item.Ceroacinco = varCeroacinco;
			
			item.Seisanueve = varSeisanueve;
			
			item.Adol = varAdol;
			
			item.Adulto = varAdulto;
			
			item.F = varF;
			
			item.M = varM;
			
			item.DiasUti = varDiasUti;
			
			item.DiasSala = varDiasSala;
			
			item.DiasTotal = varDiasTotal;
			
			item.DiasMax = varDiasMax;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCategoriaPrestacion,string varTema,string varCategoria,string varCodigo,string varCategoriaPadre,int? varIdNomencladorDetalle,decimal? varPrecio,string varNeo,string varCeroacinco,int varIdGrupoPrestacion,string varSeisanueve,string varAdol,string varAdulto,string varF,string varM,int? varDiasUti,int? varDiasSala,int? varDiasTotal,int? varDiasMax)
		{
			PnGrupoPrestacion item = new PnGrupoPrestacion();
			
				item.IdCategoriaPrestacion = varIdCategoriaPrestacion;
			
				item.Tema = varTema;
			
				item.Categoria = varCategoria;
			
				item.Codigo = varCodigo;
			
				item.CategoriaPadre = varCategoriaPadre;
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
				item.Precio = varPrecio;
			
				item.Neo = varNeo;
			
				item.Ceroacinco = varCeroacinco;
			
				item.IdGrupoPrestacion = varIdGrupoPrestacion;
			
				item.Seisanueve = varSeisanueve;
			
				item.Adol = varAdol;
			
				item.Adulto = varAdulto;
			
				item.F = varF;
			
				item.M = varM;
			
				item.DiasUti = varDiasUti;
			
				item.DiasSala = varDiasSala;
			
				item.DiasTotal = varDiasTotal;
			
				item.DiasMax = varDiasMax;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCategoriaPrestacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TemaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoriaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoriaPadreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PrecioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NeoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CeroacincoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdGrupoPrestacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SeisanueveColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AdolColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AdultoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn MColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasUtiColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasSalaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasTotalColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn DiasMaxColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCategoriaPrestacion = @"id_categoria_prestacion";
			 public static string Tema = @"tema";
			 public static string Categoria = @"categoria";
			 public static string Codigo = @"codigo";
			 public static string CategoriaPadre = @"categoria_padre";
			 public static string IdNomencladorDetalle = @"id_nomenclador_detalle";
			 public static string Precio = @"precio";
			 public static string Neo = @"neo";
			 public static string Ceroacinco = @"ceroacinco";
			 public static string IdGrupoPrestacion = @"id_grupo_prestacion";
			 public static string Seisanueve = @"seisanueve";
			 public static string Adol = @"adol";
			 public static string Adulto = @"adulto";
			 public static string F = @"f";
			 public static string M = @"m";
			 public static string DiasUti = @"dias_uti";
			 public static string DiasSala = @"dias_sala";
			 public static string DiasTotal = @"dias_total";
			 public static string DiasMax = @"dias_max";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
