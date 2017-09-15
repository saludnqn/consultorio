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
	/// Strongly-typed collection for the PnAccidentesLab class.
	/// </summary>
    [Serializable]
	public partial class PnAccidentesLabCollection : ActiveList<PnAccidentesLab, PnAccidentesLabCollection>
	{	   
		public PnAccidentesLabCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAccidentesLabCollection</returns>
		public PnAccidentesLabCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAccidentesLab o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_accidentes_lab table.
	/// </summary>
	[Serializable]
	public partial class PnAccidentesLab : ActiveRecord<PnAccidentesLab>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAccidentesLab()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAccidentesLab(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAccidentesLab(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAccidentesLab(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_accidentes_lab", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAccidentesLab = new TableSchema.TableColumn(schema);
				colvarIdAccidentesLab.ColumnName = "id_accidentes_lab";
				colvarIdAccidentesLab.DataType = DbType.Int32;
				colvarIdAccidentesLab.MaxLength = 0;
				colvarIdAccidentesLab.AutoIncrement = true;
				colvarIdAccidentesLab.IsNullable = false;
				colvarIdAccidentesLab.IsPrimaryKey = true;
				colvarIdAccidentesLab.IsForeignKey = false;
				colvarIdAccidentesLab.IsReadOnly = false;
				colvarIdAccidentesLab.DefaultSetting = @"";
				colvarIdAccidentesLab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAccidentesLab);
				
				TableSchema.TableColumn colvarFechInicio = new TableSchema.TableColumn(schema);
				colvarFechInicio.ColumnName = "fech_inicio";
				colvarFechInicio.DataType = DbType.DateTime;
				colvarFechInicio.MaxLength = 0;
				colvarFechInicio.AutoIncrement = false;
				colvarFechInicio.IsNullable = true;
				colvarFechInicio.IsPrimaryKey = false;
				colvarFechInicio.IsForeignKey = false;
				colvarFechInicio.IsReadOnly = false;
				colvarFechInicio.DefaultSetting = @"";
				colvarFechInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechInicio);
				
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
				
				TableSchema.TableColumn colvarArt = new TableSchema.TableColumn(schema);
				colvarArt.ColumnName = "art";
				colvarArt.DataType = DbType.AnsiString;
				colvarArt.MaxLength = -1;
				colvarArt.AutoIncrement = false;
				colvarArt.IsNullable = true;
				colvarArt.IsPrimaryKey = false;
				colvarArt.IsForeignKey = false;
				colvarArt.IsReadOnly = false;
				colvarArt.DefaultSetting = @"";
				colvarArt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArt);
				
				TableSchema.TableColumn colvarNumArt = new TableSchema.TableColumn(schema);
				colvarNumArt.ColumnName = "num_art";
				colvarNumArt.DataType = DbType.AnsiString;
				colvarNumArt.MaxLength = -1;
				colvarNumArt.AutoIncrement = false;
				colvarNumArt.IsNullable = true;
				colvarNumArt.IsPrimaryKey = false;
				colvarNumArt.IsForeignKey = false;
				colvarNumArt.IsReadOnly = false;
				colvarNumArt.DefaultSetting = @"";
				colvarNumArt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumArt);
				
				TableSchema.TableColumn colvarFechInicioArt = new TableSchema.TableColumn(schema);
				colvarFechInicioArt.ColumnName = "fech_inicio_art";
				colvarFechInicioArt.DataType = DbType.DateTime;
				colvarFechInicioArt.MaxLength = 0;
				colvarFechInicioArt.AutoIncrement = false;
				colvarFechInicioArt.IsNullable = true;
				colvarFechInicioArt.IsPrimaryKey = false;
				colvarFechInicioArt.IsForeignKey = false;
				colvarFechInicioArt.IsReadOnly = false;
				colvarFechInicioArt.DefaultSetting = @"";
				colvarFechInicioArt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechInicioArt);
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = false;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = false;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarTitulo = new TableSchema.TableColumn(schema);
				colvarTitulo.ColumnName = "titulo";
				colvarTitulo.DataType = DbType.AnsiString;
				colvarTitulo.MaxLength = -1;
				colvarTitulo.AutoIncrement = false;
				colvarTitulo.IsNullable = true;
				colvarTitulo.IsPrimaryKey = false;
				colvarTitulo.IsForeignKey = false;
				colvarTitulo.IsReadOnly = false;
				colvarTitulo.DefaultSetting = @"";
				colvarTitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitulo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_accidentes_lab",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAccidentesLab")]
		[Bindable(true)]
		public int IdAccidentesLab 
		{
			get { return GetColumnValue<int>(Columns.IdAccidentesLab); }
			set { SetColumnValue(Columns.IdAccidentesLab, value); }
		}
		  
		[XmlAttribute("FechInicio")]
		[Bindable(true)]
		public DateTime? FechInicio 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechInicio); }
			set { SetColumnValue(Columns.FechInicio, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Art")]
		[Bindable(true)]
		public string Art 
		{
			get { return GetColumnValue<string>(Columns.Art); }
			set { SetColumnValue(Columns.Art, value); }
		}
		  
		[XmlAttribute("NumArt")]
		[Bindable(true)]
		public string NumArt 
		{
			get { return GetColumnValue<string>(Columns.NumArt); }
			set { SetColumnValue(Columns.NumArt, value); }
		}
		  
		[XmlAttribute("FechInicioArt")]
		[Bindable(true)]
		public DateTime? FechInicioArt 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechInicioArt); }
			set { SetColumnValue(Columns.FechInicioArt, value); }
		}
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("Titulo")]
		[Bindable(true)]
		public string Titulo 
		{
			get { return GetColumnValue<string>(Columns.Titulo); }
			set { SetColumnValue(Columns.Titulo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime? varFechInicio,string varDescripcion,string varArt,string varNumArt,DateTime? varFechInicioArt,int varIdLegajo,string varTitulo)
		{
			PnAccidentesLab item = new PnAccidentesLab();
			
			item.FechInicio = varFechInicio;
			
			item.Descripcion = varDescripcion;
			
			item.Art = varArt;
			
			item.NumArt = varNumArt;
			
			item.FechInicioArt = varFechInicioArt;
			
			item.IdLegajo = varIdLegajo;
			
			item.Titulo = varTitulo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAccidentesLab,DateTime? varFechInicio,string varDescripcion,string varArt,string varNumArt,DateTime? varFechInicioArt,int varIdLegajo,string varTitulo)
		{
			PnAccidentesLab item = new PnAccidentesLab();
			
				item.IdAccidentesLab = varIdAccidentesLab;
			
				item.FechInicio = varFechInicio;
			
				item.Descripcion = varDescripcion;
			
				item.Art = varArt;
			
				item.NumArt = varNumArt;
			
				item.FechInicioArt = varFechInicioArt;
			
				item.IdLegajo = varIdLegajo;
			
				item.Titulo = varTitulo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAccidentesLabColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn FechInicioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ArtColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumArtColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechInicioArtColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TituloColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAccidentesLab = @"id_accidentes_lab";
			 public static string FechInicio = @"fech_inicio";
			 public static string Descripcion = @"descripcion";
			 public static string Art = @"art";
			 public static string NumArt = @"num_art";
			 public static string FechInicioArt = @"fech_inicio_art";
			 public static string IdLegajo = @"id_legajo";
			 public static string Titulo = @"titulo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
