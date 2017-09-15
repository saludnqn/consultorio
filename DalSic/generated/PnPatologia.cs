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
	/// Strongly-typed collection for the PnPatologia class.
	/// </summary>
    [Serializable]
	public partial class PnPatologiaCollection : ActiveList<PnPatologia, PnPatologiaCollection>
	{	   
		public PnPatologiaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnPatologiaCollection</returns>
		public PnPatologiaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnPatologia o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_patologias table.
	/// </summary>
	[Serializable]
	public partial class PnPatologia : ActiveRecord<PnPatologia>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnPatologia()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnPatologia(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnPatologia(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnPatologia(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_patologias", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.AnsiString;
				colvarCodigo.MaxLength = 255;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 255;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
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
				
				TableSchema.TableColumn colvarNeo = new TableSchema.TableColumn(schema);
				colvarNeo.ColumnName = "neo";
				colvarNeo.DataType = DbType.AnsiStringFixedLength;
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
				colvarCeroacinco.DataType = DbType.AnsiStringFixedLength;
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
				colvarSeisanueve.DataType = DbType.AnsiStringFixedLength;
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
				colvarAdol.DataType = DbType.AnsiStringFixedLength;
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
				colvarAdulto.DataType = DbType.AnsiStringFixedLength;
				colvarAdulto.MaxLength = 1;
				colvarAdulto.AutoIncrement = false;
				colvarAdulto.IsNullable = true;
				colvarAdulto.IsPrimaryKey = false;
				colvarAdulto.IsForeignKey = false;
				colvarAdulto.IsReadOnly = false;
				colvarAdulto.DefaultSetting = @"";
				colvarAdulto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdulto);
				
				TableSchema.TableColumn colvarColor = new TableSchema.TableColumn(schema);
				colvarColor.ColumnName = "color";
				colvarColor.DataType = DbType.AnsiStringFixedLength;
				colvarColor.MaxLength = 50;
				colvarColor.AutoIncrement = false;
				colvarColor.IsNullable = true;
				colvarColor.IsPrimaryKey = false;
				colvarColor.IsForeignKey = false;
				colvarColor.IsReadOnly = false;
				colvarColor.DefaultSetting = @"";
				colvarColor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarColor);
				
				TableSchema.TableColumn colvarIdPatologias = new TableSchema.TableColumn(schema);
				colvarIdPatologias.ColumnName = "id_patologias";
				colvarIdPatologias.DataType = DbType.Int32;
				colvarIdPatologias.MaxLength = 0;
				colvarIdPatologias.AutoIncrement = true;
				colvarIdPatologias.IsNullable = false;
				colvarIdPatologias.IsPrimaryKey = true;
				colvarIdPatologias.IsForeignKey = false;
				colvarIdPatologias.IsReadOnly = false;
				colvarIdPatologias.DefaultSetting = @"";
				colvarIdPatologias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPatologias);
				
				TableSchema.TableColumn colvarF = new TableSchema.TableColumn(schema);
				colvarF.ColumnName = "f";
				colvarF.DataType = DbType.AnsiStringFixedLength;
				colvarF.MaxLength = 1;
				colvarF.AutoIncrement = false;
				colvarF.IsNullable = true;
				colvarF.IsPrimaryKey = false;
				colvarF.IsForeignKey = false;
				colvarF.IsReadOnly = false;
				colvarF.DefaultSetting = @"";
				colvarF.ForeignKeyTableName = "";
				schema.Columns.Add(colvarF);
				
				TableSchema.TableColumn colvarGrupoPatologias = new TableSchema.TableColumn(schema);
				colvarGrupoPatologias.ColumnName = "grupo_patologias";
				colvarGrupoPatologias.DataType = DbType.AnsiStringFixedLength;
				colvarGrupoPatologias.MaxLength = 50;
				colvarGrupoPatologias.AutoIncrement = false;
				colvarGrupoPatologias.IsNullable = true;
				colvarGrupoPatologias.IsPrimaryKey = false;
				colvarGrupoPatologias.IsForeignKey = false;
				colvarGrupoPatologias.IsReadOnly = false;
				colvarGrupoPatologias.DefaultSetting = @"";
				colvarGrupoPatologias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupoPatologias);
				
				TableSchema.TableColumn colvarM = new TableSchema.TableColumn(schema);
				colvarM.ColumnName = "m";
				colvarM.DataType = DbType.AnsiStringFixedLength;
				colvarM.MaxLength = 1;
				colvarM.AutoIncrement = false;
				colvarM.IsNullable = true;
				colvarM.IsPrimaryKey = false;
				colvarM.IsForeignKey = false;
				colvarM.IsReadOnly = false;
				colvarM.DefaultSetting = @"";
				colvarM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarM);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_patologias",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int? IdNomencladorDetalle 
		{
			get { return GetColumnValue<int?>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
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
		  
		[XmlAttribute("Color")]
		[Bindable(true)]
		public string Color 
		{
			get { return GetColumnValue<string>(Columns.Color); }
			set { SetColumnValue(Columns.Color, value); }
		}
		  
		[XmlAttribute("IdPatologias")]
		[Bindable(true)]
		public int IdPatologias 
		{
			get { return GetColumnValue<int>(Columns.IdPatologias); }
			set { SetColumnValue(Columns.IdPatologias, value); }
		}
		  
		[XmlAttribute("F")]
		[Bindable(true)]
		public string F 
		{
			get { return GetColumnValue<string>(Columns.F); }
			set { SetColumnValue(Columns.F, value); }
		}
		  
		[XmlAttribute("GrupoPatologias")]
		[Bindable(true)]
		public string GrupoPatologias 
		{
			get { return GetColumnValue<string>(Columns.GrupoPatologias); }
			set { SetColumnValue(Columns.GrupoPatologias, value); }
		}
		  
		[XmlAttribute("M")]
		[Bindable(true)]
		public string M 
		{
			get { return GetColumnValue<string>(Columns.M); }
			set { SetColumnValue(Columns.M, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnNomencladorXPatologiumCollection colPnNomencladorXPatologia;
		public DalSic.PnNomencladorXPatologiumCollection PnNomencladorXPatologia
		{
			get
			{
				if(colPnNomencladorXPatologia == null)
				{
					colPnNomencladorXPatologia = new DalSic.PnNomencladorXPatologiumCollection().Where(PnNomencladorXPatologium.Columns.IdPatologia, IdPatologias).Load();
					colPnNomencladorXPatologia.ListChanged += new ListChangedEventHandler(colPnNomencladorXPatologia_ListChanged);
				}
				return colPnNomencladorXPatologia;			
			}
			set 
			{ 
					colPnNomencladorXPatologia = value; 
					colPnNomencladorXPatologia.ListChanged += new ListChangedEventHandler(colPnNomencladorXPatologia_ListChanged);
			}
		}
		
		void colPnNomencladorXPatologia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnNomencladorXPatologia[e.NewIndex].IdPatologia = IdPatologias;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCodigo,string varDescripcion,int? varIdNomencladorDetalle,string varNeo,string varCeroacinco,string varSeisanueve,string varAdol,string varAdulto,string varColor,string varF,string varGrupoPatologias,string varM)
		{
			PnPatologia item = new PnPatologia();
			
			item.Codigo = varCodigo;
			
			item.Descripcion = varDescripcion;
			
			item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
			item.Neo = varNeo;
			
			item.Ceroacinco = varCeroacinco;
			
			item.Seisanueve = varSeisanueve;
			
			item.Adol = varAdol;
			
			item.Adulto = varAdulto;
			
			item.Color = varColor;
			
			item.F = varF;
			
			item.GrupoPatologias = varGrupoPatologias;
			
			item.M = varM;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varCodigo,string varDescripcion,int? varIdNomencladorDetalle,string varNeo,string varCeroacinco,string varSeisanueve,string varAdol,string varAdulto,string varColor,int varIdPatologias,string varF,string varGrupoPatologias,string varM)
		{
			PnPatologia item = new PnPatologia();
			
				item.Codigo = varCodigo;
			
				item.Descripcion = varDescripcion;
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
				item.Neo = varNeo;
			
				item.Ceroacinco = varCeroacinco;
			
				item.Seisanueve = varSeisanueve;
			
				item.Adol = varAdol;
			
				item.Adulto = varAdulto;
			
				item.Color = varColor;
			
				item.IdPatologias = varIdPatologias;
			
				item.F = varF;
			
				item.GrupoPatologias = varGrupoPatologias;
			
				item.M = varM;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NeoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CeroacincoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SeisanueveColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AdolColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AdultoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ColorColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPatologiasColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoPatologiasColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn MColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Codigo = @"codigo";
			 public static string Descripcion = @"descripcion";
			 public static string IdNomencladorDetalle = @"id_nomenclador_detalle";
			 public static string Neo = @"neo";
			 public static string Ceroacinco = @"ceroacinco";
			 public static string Seisanueve = @"seisanueve";
			 public static string Adol = @"adol";
			 public static string Adulto = @"adulto";
			 public static string Color = @"color";
			 public static string IdPatologias = @"id_patologias";
			 public static string F = @"f";
			 public static string GrupoPatologias = @"grupo_patologias";
			 public static string M = @"m";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnNomencladorXPatologia != null)
                {
                    foreach (DalSic.PnNomencladorXPatologium item in colPnNomencladorXPatologia)
                    {
                        if (item.IdPatologia != IdPatologias)
                        {
                            item.IdPatologia = IdPatologias;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnNomencladorXPatologia != null)
                {
                    colPnNomencladorXPatologia.SaveAll();
               }
		}
        #endregion
	}
}
