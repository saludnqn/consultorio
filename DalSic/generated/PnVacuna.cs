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
	/// Strongly-typed collection for the PnVacuna class.
	/// </summary>
    [Serializable]
	public partial class PnVacunaCollection : ActiveList<PnVacuna, PnVacunaCollection>
	{	   
		public PnVacunaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnVacunaCollection</returns>
		public PnVacunaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnVacuna o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_vacunas table.
	/// </summary>
	[Serializable]
	public partial class PnVacuna : ActiveRecord<PnVacuna>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnVacuna()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnVacuna(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnVacuna(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnVacuna(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_vacunas", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdVacunas = new TableSchema.TableColumn(schema);
				colvarIdVacunas.ColumnName = "id_vacunas";
				colvarIdVacunas.DataType = DbType.Int32;
				colvarIdVacunas.MaxLength = 0;
				colvarIdVacunas.AutoIncrement = true;
				colvarIdVacunas.IsNullable = false;
				colvarIdVacunas.IsPrimaryKey = true;
				colvarIdVacunas.IsForeignKey = false;
				colvarIdVacunas.IsReadOnly = false;
				colvarIdVacunas.DefaultSetting = @"";
				colvarIdVacunas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVacunas);
				
				TableSchema.TableColumn colvarIdVacApli = new TableSchema.TableColumn(schema);
				colvarIdVacApli.ColumnName = "id_vac_apli";
				colvarIdVacApli.DataType = DbType.Int32;
				colvarIdVacApli.MaxLength = 0;
				colvarIdVacApli.AutoIncrement = false;
				colvarIdVacApli.IsNullable = false;
				colvarIdVacApli.IsPrimaryKey = false;
				colvarIdVacApli.IsForeignKey = false;
				colvarIdVacApli.IsReadOnly = false;
				colvarIdVacApli.DefaultSetting = @"";
				colvarIdVacApli.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdVacApli);
				
				TableSchema.TableColumn colvarIdDosisApli = new TableSchema.TableColumn(schema);
				colvarIdDosisApli.ColumnName = "id_dosis_apli";
				colvarIdDosisApli.DataType = DbType.Int32;
				colvarIdDosisApli.MaxLength = 0;
				colvarIdDosisApli.AutoIncrement = false;
				colvarIdDosisApli.IsNullable = false;
				colvarIdDosisApli.IsPrimaryKey = false;
				colvarIdDosisApli.IsForeignKey = false;
				colvarIdDosisApli.IsReadOnly = false;
				colvarIdDosisApli.DefaultSetting = @"";
				colvarIdDosisApli.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDosisApli);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = -1;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarDni = new TableSchema.TableColumn(schema);
				colvarDni.ColumnName = "dni";
				colvarDni.DataType = DbType.AnsiString;
				colvarDni.MaxLength = -1;
				colvarDni.AutoIncrement = false;
				colvarDni.IsNullable = true;
				colvarDni.IsPrimaryKey = false;
				colvarDni.IsForeignKey = false;
				colvarDni.IsReadOnly = false;
				colvarDni.DefaultSetting = @"";
				colvarDni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDni);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.AnsiString;
				colvarSexo.MaxLength = -1;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = true;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarFechaNac = new TableSchema.TableColumn(schema);
				colvarFechaNac.ColumnName = "fecha_nac";
				colvarFechaNac.DataType = DbType.DateTime;
				colvarFechaNac.MaxLength = 0;
				colvarFechaNac.AutoIncrement = false;
				colvarFechaNac.IsNullable = true;
				colvarFechaNac.IsPrimaryKey = false;
				colvarFechaNac.IsForeignKey = false;
				colvarFechaNac.IsReadOnly = false;
				colvarFechaNac.DefaultSetting = @"";
				colvarFechaNac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNac);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = -1;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarFechaVac = new TableSchema.TableColumn(schema);
				colvarFechaVac.ColumnName = "fecha_vac";
				colvarFechaVac.DataType = DbType.DateTime;
				colvarFechaVac.MaxLength = 0;
				colvarFechaVac.AutoIncrement = false;
				colvarFechaVac.IsNullable = true;
				colvarFechaVac.IsPrimaryKey = false;
				colvarFechaVac.IsForeignKey = false;
				colvarFechaVac.IsReadOnly = false;
				colvarFechaVac.DefaultSetting = @"";
				colvarFechaVac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaVac);
				
				TableSchema.TableColumn colvarNomResp = new TableSchema.TableColumn(schema);
				colvarNomResp.ColumnName = "nom_resp";
				colvarNomResp.DataType = DbType.AnsiString;
				colvarNomResp.MaxLength = -1;
				colvarNomResp.AutoIncrement = false;
				colvarNomResp.IsNullable = true;
				colvarNomResp.IsPrimaryKey = false;
				colvarNomResp.IsForeignKey = false;
				colvarNomResp.IsReadOnly = false;
				colvarNomResp.DefaultSetting = @"";
				colvarNomResp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNomResp);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_vacunas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdVacunas")]
		[Bindable(true)]
		public int IdVacunas 
		{
			get { return GetColumnValue<int>(Columns.IdVacunas); }
			set { SetColumnValue(Columns.IdVacunas, value); }
		}
		  
		[XmlAttribute("IdVacApli")]
		[Bindable(true)]
		public int IdVacApli 
		{
			get { return GetColumnValue<int>(Columns.IdVacApli); }
			set { SetColumnValue(Columns.IdVacApli, value); }
		}
		  
		[XmlAttribute("IdDosisApli")]
		[Bindable(true)]
		public int IdDosisApli 
		{
			get { return GetColumnValue<int>(Columns.IdDosisApli); }
			set { SetColumnValue(Columns.IdDosisApli, value); }
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
		  
		[XmlAttribute("Dni")]
		[Bindable(true)]
		public string Dni 
		{
			get { return GetColumnValue<string>(Columns.Dni); }
			set { SetColumnValue(Columns.Dni, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("FechaNac")]
		[Bindable(true)]
		public DateTime? FechaNac 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNac); }
			set { SetColumnValue(Columns.FechaNac, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("FechaVac")]
		[Bindable(true)]
		public DateTime? FechaVac 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaVac); }
			set { SetColumnValue(Columns.FechaVac, value); }
		}
		  
		[XmlAttribute("NomResp")]
		[Bindable(true)]
		public string NomResp 
		{
			get { return GetColumnValue<string>(Columns.NomResp); }
			set { SetColumnValue(Columns.NomResp, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdVacApli,int varIdDosisApli,string varApellido,string varNombre,string varDni,string varSexo,DateTime? varFechaNac,string varDomicilio,DateTime? varFechaVac,string varNomResp,string varComentario,string varCuie)
		{
			PnVacuna item = new PnVacuna();
			
			item.IdVacApli = varIdVacApli;
			
			item.IdDosisApli = varIdDosisApli;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.Dni = varDni;
			
			item.Sexo = varSexo;
			
			item.FechaNac = varFechaNac;
			
			item.Domicilio = varDomicilio;
			
			item.FechaVac = varFechaVac;
			
			item.NomResp = varNomResp;
			
			item.Comentario = varComentario;
			
			item.Cuie = varCuie;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdVacunas,int varIdVacApli,int varIdDosisApli,string varApellido,string varNombre,string varDni,string varSexo,DateTime? varFechaNac,string varDomicilio,DateTime? varFechaVac,string varNomResp,string varComentario,string varCuie)
		{
			PnVacuna item = new PnVacuna();
			
				item.IdVacunas = varIdVacunas;
			
				item.IdVacApli = varIdVacApli;
			
				item.IdDosisApli = varIdDosisApli;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.Dni = varDni;
			
				item.Sexo = varSexo;
			
				item.FechaNac = varFechaNac;
			
				item.Domicilio = varDomicilio;
			
				item.FechaVac = varFechaVac;
			
				item.NomResp = varNomResp;
			
				item.Comentario = varComentario;
			
				item.Cuie = varCuie;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdVacunasColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdVacApliColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDosisApliColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DniColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaVacColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NomRespColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdVacunas = @"id_vacunas";
			 public static string IdVacApli = @"id_vac_apli";
			 public static string IdDosisApli = @"id_dosis_apli";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string Dni = @"dni";
			 public static string Sexo = @"sexo";
			 public static string FechaNac = @"fecha_nac";
			 public static string Domicilio = @"domicilio";
			 public static string FechaVac = @"fecha_vac";
			 public static string NomResp = @"nom_resp";
			 public static string Comentario = @"comentario";
			 public static string Cuie = @"cuie";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
