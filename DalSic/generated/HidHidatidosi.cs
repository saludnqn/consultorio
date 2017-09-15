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
	/// Strongly-typed collection for the HidHidatidosi class.
	/// </summary>
    [Serializable]
	public partial class HidHidatidosiCollection : ActiveList<HidHidatidosi, HidHidatidosiCollection>
	{	   
		public HidHidatidosiCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>HidHidatidosiCollection</returns>
		public HidHidatidosiCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                HidHidatidosi o = this[i];
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
	/// This is an ActiveRecord class which wraps the Hid_Hidatidosis table.
	/// </summary>
	[Serializable]
	public partial class HidHidatidosi : ActiveRecord<HidHidatidosi>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public HidHidatidosi()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public HidHidatidosi(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public HidHidatidosi(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public HidHidatidosi(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Hid_Hidatidosis", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHidatidosis = new TableSchema.TableColumn(schema);
				colvarIdHidatidosis.ColumnName = "idHidatidosis";
				colvarIdHidatidosis.DataType = DbType.Int32;
				colvarIdHidatidosis.MaxLength = 0;
				colvarIdHidatidosis.AutoIncrement = true;
				colvarIdHidatidosis.IsNullable = false;
				colvarIdHidatidosis.IsPrimaryKey = true;
				colvarIdHidatidosis.IsForeignKey = false;
				colvarIdHidatidosis.IsReadOnly = false;
				colvarIdHidatidosis.DefaultSetting = @"";
				colvarIdHidatidosis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHidatidosis);
				
				TableSchema.TableColumn colvarIdEstablecimiento = new TableSchema.TableColumn(schema);
				colvarIdEstablecimiento.ColumnName = "idEstablecimiento";
				colvarIdEstablecimiento.DataType = DbType.Int32;
				colvarIdEstablecimiento.MaxLength = 0;
				colvarIdEstablecimiento.AutoIncrement = false;
				colvarIdEstablecimiento.IsNullable = false;
				colvarIdEstablecimiento.IsPrimaryKey = false;
				colvarIdEstablecimiento.IsForeignKey = false;
				colvarIdEstablecimiento.IsReadOnly = false;
				colvarIdEstablecimiento.DefaultSetting = @"";
				colvarIdEstablecimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstablecimiento);
				
				TableSchema.TableColumn colvarDocente = new TableSchema.TableColumn(schema);
				colvarDocente.ColumnName = "docente";
				colvarDocente.DataType = DbType.String;
				colvarDocente.MaxLength = 100;
				colvarDocente.AutoIncrement = false;
				colvarDocente.IsNullable = true;
				colvarDocente.IsPrimaryKey = false;
				colvarDocente.IsForeignKey = false;
				colvarDocente.IsReadOnly = false;
				colvarDocente.DefaultSetting = @"";
				colvarDocente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocente);
				
				TableSchema.TableColumn colvarNombrePaciente = new TableSchema.TableColumn(schema);
				colvarNombrePaciente.ColumnName = "nombrePaciente";
				colvarNombrePaciente.DataType = DbType.String;
				colvarNombrePaciente.MaxLength = 100;
				colvarNombrePaciente.AutoIncrement = false;
				colvarNombrePaciente.IsNullable = true;
				colvarNombrePaciente.IsPrimaryKey = false;
				colvarNombrePaciente.IsForeignKey = false;
				colvarNombrePaciente.IsReadOnly = false;
				colvarNombrePaciente.DefaultSetting = @"";
				colvarNombrePaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombrePaciente);
				
				TableSchema.TableColumn colvarApellidoPaciente = new TableSchema.TableColumn(schema);
				colvarApellidoPaciente.ColumnName = "apellidoPaciente";
				colvarApellidoPaciente.DataType = DbType.String;
				colvarApellidoPaciente.MaxLength = 100;
				colvarApellidoPaciente.AutoIncrement = false;
				colvarApellidoPaciente.IsNullable = true;
				colvarApellidoPaciente.IsPrimaryKey = false;
				colvarApellidoPaciente.IsForeignKey = false;
				colvarApellidoPaciente.IsReadOnly = false;
				colvarApellidoPaciente.DefaultSetting = @"";
				colvarApellidoPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoPaciente);
				
				TableSchema.TableColumn colvarDniPaciente = new TableSchema.TableColumn(schema);
				colvarDniPaciente.ColumnName = "dniPaciente";
				colvarDniPaciente.DataType = DbType.String;
				colvarDniPaciente.MaxLength = 10;
				colvarDniPaciente.AutoIncrement = false;
				colvarDniPaciente.IsNullable = true;
				colvarDniPaciente.IsPrimaryKey = false;
				colvarDniPaciente.IsForeignKey = false;
				colvarDniPaciente.IsReadOnly = false;
				colvarDniPaciente.DefaultSetting = @"";
				colvarDniPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDniPaciente);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarDomicilioPaciente = new TableSchema.TableColumn(schema);
				colvarDomicilioPaciente.ColumnName = "domicilioPaciente";
				colvarDomicilioPaciente.DataType = DbType.String;
				colvarDomicilioPaciente.MaxLength = 100;
				colvarDomicilioPaciente.AutoIncrement = false;
				colvarDomicilioPaciente.IsNullable = true;
				colvarDomicilioPaciente.IsPrimaryKey = false;
				colvarDomicilioPaciente.IsForeignKey = false;
				colvarDomicilioPaciente.IsReadOnly = false;
				colvarDomicilioPaciente.DefaultSetting = @"";
				colvarDomicilioPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilioPaciente);
				
				TableSchema.TableColumn colvarTelefonoPaciente = new TableSchema.TableColumn(schema);
				colvarTelefonoPaciente.ColumnName = "telefonoPaciente";
				colvarTelefonoPaciente.DataType = DbType.String;
				colvarTelefonoPaciente.MaxLength = 20;
				colvarTelefonoPaciente.AutoIncrement = false;
				colvarTelefonoPaciente.IsNullable = true;
				colvarTelefonoPaciente.IsPrimaryKey = false;
				colvarTelefonoPaciente.IsForeignKey = false;
				colvarTelefonoPaciente.IsReadOnly = false;
				colvarTelefonoPaciente.DefaultSetting = @"";
				colvarTelefonoPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefonoPaciente);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarNombrePadre = new TableSchema.TableColumn(schema);
				colvarNombrePadre.ColumnName = "nombrePadre";
				colvarNombrePadre.DataType = DbType.String;
				colvarNombrePadre.MaxLength = 100;
				colvarNombrePadre.AutoIncrement = false;
				colvarNombrePadre.IsNullable = true;
				colvarNombrePadre.IsPrimaryKey = false;
				colvarNombrePadre.IsForeignKey = false;
				colvarNombrePadre.IsReadOnly = false;
				colvarNombrePadre.DefaultSetting = @"";
				colvarNombrePadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombrePadre);
				
				TableSchema.TableColumn colvarApellidoPadre = new TableSchema.TableColumn(schema);
				colvarApellidoPadre.ColumnName = "apellidoPadre";
				colvarApellidoPadre.DataType = DbType.String;
				colvarApellidoPadre.MaxLength = 100;
				colvarApellidoPadre.AutoIncrement = false;
				colvarApellidoPadre.IsNullable = true;
				colvarApellidoPadre.IsPrimaryKey = false;
				colvarApellidoPadre.IsForeignKey = false;
				colvarApellidoPadre.IsReadOnly = false;
				colvarApellidoPadre.DefaultSetting = @"";
				colvarApellidoPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoPadre);
				
				TableSchema.TableColumn colvarDniPadre = new TableSchema.TableColumn(schema);
				colvarDniPadre.ColumnName = "dniPadre";
				colvarDniPadre.DataType = DbType.String;
				colvarDniPadre.MaxLength = 10;
				colvarDniPadre.AutoIncrement = false;
				colvarDniPadre.IsNullable = true;
				colvarDniPadre.IsPrimaryKey = false;
				colvarDniPadre.IsForeignKey = false;
				colvarDniPadre.IsReadOnly = false;
				colvarDniPadre.DefaultSetting = @"";
				colvarDniPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDniPadre);
				
				TableSchema.TableColumn colvarResultadoRastreo = new TableSchema.TableColumn(schema);
				colvarResultadoRastreo.ColumnName = "resultadoRastreo";
				colvarResultadoRastreo.DataType = DbType.String;
				colvarResultadoRastreo.MaxLength = 1;
				colvarResultadoRastreo.AutoIncrement = false;
				colvarResultadoRastreo.IsNullable = true;
				colvarResultadoRastreo.IsPrimaryKey = false;
				colvarResultadoRastreo.IsForeignKey = false;
				colvarResultadoRastreo.IsReadOnly = false;
				colvarResultadoRastreo.DefaultSetting = @"";
				colvarResultadoRastreo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResultadoRastreo);
				
				TableSchema.TableColumn colvarProfesional = new TableSchema.TableColumn(schema);
				colvarProfesional.ColumnName = "profesional";
				colvarProfesional.DataType = DbType.AnsiString;
				colvarProfesional.MaxLength = 100;
				colvarProfesional.AutoIncrement = false;
				colvarProfesional.IsNullable = true;
				colvarProfesional.IsPrimaryKey = false;
				colvarProfesional.IsForeignKey = false;
				colvarProfesional.IsReadOnly = false;
				colvarProfesional.DefaultSetting = @"";
				colvarProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProfesional);
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fechaAlta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = false;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				
						colvarFechaAlta.DefaultSetting = @"(getdate())";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
				TableSchema.TableColumn colvarDadoDeBaja = new TableSchema.TableColumn(schema);
				colvarDadoDeBaja.ColumnName = "dadoDeBaja";
				colvarDadoDeBaja.DataType = DbType.Boolean;
				colvarDadoDeBaja.MaxLength = 0;
				colvarDadoDeBaja.AutoIncrement = false;
				colvarDadoDeBaja.IsNullable = false;
				colvarDadoDeBaja.IsPrimaryKey = false;
				colvarDadoDeBaja.IsForeignKey = false;
				colvarDadoDeBaja.IsReadOnly = false;
				
						colvarDadoDeBaja.DefaultSetting = @"((0))";
				colvarDadoDeBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDadoDeBaja);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = true;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarIdUsuarioBaja = new TableSchema.TableColumn(schema);
				colvarIdUsuarioBaja.ColumnName = "idUsuarioBaja";
				colvarIdUsuarioBaja.DataType = DbType.Int32;
				colvarIdUsuarioBaja.MaxLength = 0;
				colvarIdUsuarioBaja.AutoIncrement = false;
				colvarIdUsuarioBaja.IsNullable = true;
				colvarIdUsuarioBaja.IsPrimaryKey = false;
				colvarIdUsuarioBaja.IsForeignKey = false;
				colvarIdUsuarioBaja.IsReadOnly = false;
				colvarIdUsuarioBaja.DefaultSetting = @"";
				colvarIdUsuarioBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioBaja);
				
				TableSchema.TableColumn colvarFechaEcografia = new TableSchema.TableColumn(schema);
				colvarFechaEcografia.ColumnName = "fechaEcografia";
				colvarFechaEcografia.DataType = DbType.DateTime;
				colvarFechaEcografia.MaxLength = 0;
				colvarFechaEcografia.AutoIncrement = false;
				colvarFechaEcografia.IsNullable = true;
				colvarFechaEcografia.IsPrimaryKey = false;
				colvarFechaEcografia.IsForeignKey = false;
				colvarFechaEcografia.IsReadOnly = false;
				colvarFechaEcografia.DefaultSetting = @"";
				colvarFechaEcografia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEcografia);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Hid_Hidatidosis",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHidatidosis")]
		[Bindable(true)]
		public int IdHidatidosis 
		{
			get { return GetColumnValue<int>(Columns.IdHidatidosis); }
			set { SetColumnValue(Columns.IdHidatidosis, value); }
		}
		  
		[XmlAttribute("IdEstablecimiento")]
		[Bindable(true)]
		public int IdEstablecimiento 
		{
			get { return GetColumnValue<int>(Columns.IdEstablecimiento); }
			set { SetColumnValue(Columns.IdEstablecimiento, value); }
		}
		  
		[XmlAttribute("Docente")]
		[Bindable(true)]
		public string Docente 
		{
			get { return GetColumnValue<string>(Columns.Docente); }
			set { SetColumnValue(Columns.Docente, value); }
		}
		  
		[XmlAttribute("NombrePaciente")]
		[Bindable(true)]
		public string NombrePaciente 
		{
			get { return GetColumnValue<string>(Columns.NombrePaciente); }
			set { SetColumnValue(Columns.NombrePaciente, value); }
		}
		  
		[XmlAttribute("ApellidoPaciente")]
		[Bindable(true)]
		public string ApellidoPaciente 
		{
			get { return GetColumnValue<string>(Columns.ApellidoPaciente); }
			set { SetColumnValue(Columns.ApellidoPaciente, value); }
		}
		  
		[XmlAttribute("DniPaciente")]
		[Bindable(true)]
		public string DniPaciente 
		{
			get { return GetColumnValue<string>(Columns.DniPaciente); }
			set { SetColumnValue(Columns.DniPaciente, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("DomicilioPaciente")]
		[Bindable(true)]
		public string DomicilioPaciente 
		{
			get { return GetColumnValue<string>(Columns.DomicilioPaciente); }
			set { SetColumnValue(Columns.DomicilioPaciente, value); }
		}
		  
		[XmlAttribute("TelefonoPaciente")]
		[Bindable(true)]
		public string TelefonoPaciente 
		{
			get { return GetColumnValue<string>(Columns.TelefonoPaciente); }
			set { SetColumnValue(Columns.TelefonoPaciente, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("NombrePadre")]
		[Bindable(true)]
		public string NombrePadre 
		{
			get { return GetColumnValue<string>(Columns.NombrePadre); }
			set { SetColumnValue(Columns.NombrePadre, value); }
		}
		  
		[XmlAttribute("ApellidoPadre")]
		[Bindable(true)]
		public string ApellidoPadre 
		{
			get { return GetColumnValue<string>(Columns.ApellidoPadre); }
			set { SetColumnValue(Columns.ApellidoPadre, value); }
		}
		  
		[XmlAttribute("DniPadre")]
		[Bindable(true)]
		public string DniPadre 
		{
			get { return GetColumnValue<string>(Columns.DniPadre); }
			set { SetColumnValue(Columns.DniPadre, value); }
		}
		  
		[XmlAttribute("ResultadoRastreo")]
		[Bindable(true)]
		public string ResultadoRastreo 
		{
			get { return GetColumnValue<string>(Columns.ResultadoRastreo); }
			set { SetColumnValue(Columns.ResultadoRastreo, value); }
		}
		  
		[XmlAttribute("Profesional")]
		[Bindable(true)]
		public string Profesional 
		{
			get { return GetColumnValue<string>(Columns.Profesional); }
			set { SetColumnValue(Columns.Profesional, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime FechaAlta 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		  
		[XmlAttribute("DadoDeBaja")]
		[Bindable(true)]
		public bool DadoDeBaja 
		{
			get { return GetColumnValue<bool>(Columns.DadoDeBaja); }
			set { SetColumnValue(Columns.DadoDeBaja, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int? IdUsuario 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("IdUsuarioBaja")]
		[Bindable(true)]
		public int? IdUsuarioBaja 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuarioBaja); }
			set { SetColumnValue(Columns.IdUsuarioBaja, value); }
		}
		  
		[XmlAttribute("FechaEcografia")]
		[Bindable(true)]
		public DateTime? FechaEcografia 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEcografia); }
			set { SetColumnValue(Columns.FechaEcografia, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstablecimiento,string varDocente,string varNombrePaciente,string varApellidoPaciente,string varDniPaciente,DateTime? varFechaNacimiento,string varDomicilioPaciente,string varTelefonoPaciente,string varObservaciones,string varNombrePadre,string varApellidoPadre,string varDniPadre,string varResultadoRastreo,string varProfesional,DateTime varFechaAlta,bool varDadoDeBaja,int? varIdUsuario,int? varIdUsuarioBaja,DateTime? varFechaEcografia)
		{
			HidHidatidosi item = new HidHidatidosi();
			
			item.IdEstablecimiento = varIdEstablecimiento;
			
			item.Docente = varDocente;
			
			item.NombrePaciente = varNombrePaciente;
			
			item.ApellidoPaciente = varApellidoPaciente;
			
			item.DniPaciente = varDniPaciente;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.DomicilioPaciente = varDomicilioPaciente;
			
			item.TelefonoPaciente = varTelefonoPaciente;
			
			item.Observaciones = varObservaciones;
			
			item.NombrePadre = varNombrePadre;
			
			item.ApellidoPadre = varApellidoPadre;
			
			item.DniPadre = varDniPadre;
			
			item.ResultadoRastreo = varResultadoRastreo;
			
			item.Profesional = varProfesional;
			
			item.FechaAlta = varFechaAlta;
			
			item.DadoDeBaja = varDadoDeBaja;
			
			item.IdUsuario = varIdUsuario;
			
			item.IdUsuarioBaja = varIdUsuarioBaja;
			
			item.FechaEcografia = varFechaEcografia;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdHidatidosis,int varIdEstablecimiento,string varDocente,string varNombrePaciente,string varApellidoPaciente,string varDniPaciente,DateTime? varFechaNacimiento,string varDomicilioPaciente,string varTelefonoPaciente,string varObservaciones,string varNombrePadre,string varApellidoPadre,string varDniPadre,string varResultadoRastreo,string varProfesional,DateTime varFechaAlta,bool varDadoDeBaja,int? varIdUsuario,int? varIdUsuarioBaja,DateTime? varFechaEcografia)
		{
			HidHidatidosi item = new HidHidatidosi();
			
				item.IdHidatidosis = varIdHidatidosis;
			
				item.IdEstablecimiento = varIdEstablecimiento;
			
				item.Docente = varDocente;
			
				item.NombrePaciente = varNombrePaciente;
			
				item.ApellidoPaciente = varApellidoPaciente;
			
				item.DniPaciente = varDniPaciente;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.DomicilioPaciente = varDomicilioPaciente;
			
				item.TelefonoPaciente = varTelefonoPaciente;
			
				item.Observaciones = varObservaciones;
			
				item.NombrePadre = varNombrePadre;
			
				item.ApellidoPadre = varApellidoPadre;
			
				item.DniPadre = varDniPadre;
			
				item.ResultadoRastreo = varResultadoRastreo;
			
				item.Profesional = varProfesional;
			
				item.FechaAlta = varFechaAlta;
			
				item.DadoDeBaja = varDadoDeBaja;
			
				item.IdUsuario = varIdUsuario;
			
				item.IdUsuarioBaja = varIdUsuarioBaja;
			
				item.FechaEcografia = varFechaEcografia;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHidatidosisColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstablecimientoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DocenteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombrePacienteColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoPacienteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DniPacienteColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioPacienteColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoPacienteColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NombrePadreColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoPadreColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DniPadreColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ResultadoRastreoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ProfesionalColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn DadoDeBajaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioBajaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEcografiaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHidatidosis = @"idHidatidosis";
			 public static string IdEstablecimiento = @"idEstablecimiento";
			 public static string Docente = @"docente";
			 public static string NombrePaciente = @"nombrePaciente";
			 public static string ApellidoPaciente = @"apellidoPaciente";
			 public static string DniPaciente = @"dniPaciente";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string DomicilioPaciente = @"domicilioPaciente";
			 public static string TelefonoPaciente = @"telefonoPaciente";
			 public static string Observaciones = @"observaciones";
			 public static string NombrePadre = @"nombrePadre";
			 public static string ApellidoPadre = @"apellidoPadre";
			 public static string DniPadre = @"dniPadre";
			 public static string ResultadoRastreo = @"resultadoRastreo";
			 public static string Profesional = @"profesional";
			 public static string FechaAlta = @"fechaAlta";
			 public static string DadoDeBaja = @"dadoDeBaja";
			 public static string IdUsuario = @"idUsuario";
			 public static string IdUsuarioBaja = @"idUsuarioBaja";
			 public static string FechaEcografia = @"fechaEcografia";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
