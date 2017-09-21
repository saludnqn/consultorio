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
	/// Strongly-typed collection for the RisInvestigadore class.
	/// </summary>
    [Serializable]
	public partial class RisInvestigadoreCollection : ActiveList<RisInvestigadore, RisInvestigadoreCollection>
	{	   
		public RisInvestigadoreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisInvestigadoreCollection</returns>
		public RisInvestigadoreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisInvestigadore o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_Investigadores table.
	/// </summary>
	[Serializable]
	public partial class RisInvestigadore : ActiveRecord<RisInvestigadore>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisInvestigadore()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisInvestigadore(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisInvestigadore(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisInvestigadore(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_Investigadores", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdInvestigador = new TableSchema.TableColumn(schema);
				colvarIdInvestigador.ColumnName = "idInvestigador";
				colvarIdInvestigador.DataType = DbType.Int32;
				colvarIdInvestigador.MaxLength = 0;
				colvarIdInvestigador.AutoIncrement = true;
				colvarIdInvestigador.IsNullable = false;
				colvarIdInvestigador.IsPrimaryKey = true;
				colvarIdInvestigador.IsForeignKey = false;
				colvarIdInvestigador.IsReadOnly = false;
				colvarIdInvestigador.DefaultSetting = @"";
				colvarIdInvestigador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInvestigador);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "Apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = 100;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = false;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.AnsiString;
				colvarSexo.MaxLength = 100;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = false;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = false;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarIdTipoDocumento = new TableSchema.TableColumn(schema);
				colvarIdTipoDocumento.ColumnName = "idTipoDocumento";
				colvarIdTipoDocumento.DataType = DbType.Int32;
				colvarIdTipoDocumento.MaxLength = 0;
				colvarIdTipoDocumento.AutoIncrement = false;
				colvarIdTipoDocumento.IsNullable = false;
				colvarIdTipoDocumento.IsPrimaryKey = false;
				colvarIdTipoDocumento.IsForeignKey = false;
				colvarIdTipoDocumento.IsReadOnly = false;
				colvarIdTipoDocumento.DefaultSetting = @"";
				colvarIdTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoDocumento);
				
				TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
				colvarNumeroDocumento.ColumnName = "numeroDocumento";
				colvarNumeroDocumento.DataType = DbType.AnsiString;
				colvarNumeroDocumento.MaxLength = 100;
				colvarNumeroDocumento.AutoIncrement = false;
				colvarNumeroDocumento.IsNullable = false;
				colvarNumeroDocumento.IsPrimaryKey = false;
				colvarNumeroDocumento.IsForeignKey = false;
				colvarNumeroDocumento.IsReadOnly = false;
				colvarNumeroDocumento.DefaultSetting = @"";
				colvarNumeroDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDocumento);
				
				TableSchema.TableColumn colvarIdProfesion = new TableSchema.TableColumn(schema);
				colvarIdProfesion.ColumnName = "idProfesion";
				colvarIdProfesion.DataType = DbType.Int32;
				colvarIdProfesion.MaxLength = 0;
				colvarIdProfesion.AutoIncrement = false;
				colvarIdProfesion.IsNullable = false;
				colvarIdProfesion.IsPrimaryKey = false;
				colvarIdProfesion.IsForeignKey = false;
				colvarIdProfesion.IsReadOnly = false;
				colvarIdProfesion.DefaultSetting = @"";
				colvarIdProfesion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProfesion);
				
				TableSchema.TableColumn colvarNumeroMatricula = new TableSchema.TableColumn(schema);
				colvarNumeroMatricula.ColumnName = "numeroMatricula";
				colvarNumeroMatricula.DataType = DbType.AnsiString;
				colvarNumeroMatricula.MaxLength = 100;
				colvarNumeroMatricula.AutoIncrement = false;
				colvarNumeroMatricula.IsNullable = false;
				colvarNumeroMatricula.IsPrimaryKey = false;
				colvarNumeroMatricula.IsForeignKey = false;
				colvarNumeroMatricula.IsReadOnly = false;
				colvarNumeroMatricula.DefaultSetting = @"";
				colvarNumeroMatricula.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroMatricula);
				
				TableSchema.TableColumn colvarDomicilioLaboral = new TableSchema.TableColumn(schema);
				colvarDomicilioLaboral.ColumnName = "domicilioLaboral";
				colvarDomicilioLaboral.DataType = DbType.AnsiString;
				colvarDomicilioLaboral.MaxLength = 100;
				colvarDomicilioLaboral.AutoIncrement = false;
				colvarDomicilioLaboral.IsNullable = true;
				colvarDomicilioLaboral.IsPrimaryKey = false;
				colvarDomicilioLaboral.IsForeignKey = false;
				colvarDomicilioLaboral.IsReadOnly = false;
				colvarDomicilioLaboral.DefaultSetting = @"";
				colvarDomicilioLaboral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilioLaboral);
				
				TableSchema.TableColumn colvarCpDomicilioLaboral = new TableSchema.TableColumn(schema);
				colvarCpDomicilioLaboral.ColumnName = "cpDomicilioLaboral";
				colvarCpDomicilioLaboral.DataType = DbType.AnsiString;
				colvarCpDomicilioLaboral.MaxLength = 100;
				colvarCpDomicilioLaboral.AutoIncrement = false;
				colvarCpDomicilioLaboral.IsNullable = true;
				colvarCpDomicilioLaboral.IsPrimaryKey = false;
				colvarCpDomicilioLaboral.IsForeignKey = false;
				colvarCpDomicilioLaboral.IsReadOnly = false;
				colvarCpDomicilioLaboral.DefaultSetting = @"";
				colvarCpDomicilioLaboral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCpDomicilioLaboral);
				
				TableSchema.TableColumn colvarDomicilioParticular = new TableSchema.TableColumn(schema);
				colvarDomicilioParticular.ColumnName = "domicilioParticular";
				colvarDomicilioParticular.DataType = DbType.AnsiString;
				colvarDomicilioParticular.MaxLength = 100;
				colvarDomicilioParticular.AutoIncrement = false;
				colvarDomicilioParticular.IsNullable = true;
				colvarDomicilioParticular.IsPrimaryKey = false;
				colvarDomicilioParticular.IsForeignKey = false;
				colvarDomicilioParticular.IsReadOnly = false;
				colvarDomicilioParticular.DefaultSetting = @"";
				colvarDomicilioParticular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilioParticular);
				
				TableSchema.TableColumn colvarCpDomicilioParticular = new TableSchema.TableColumn(schema);
				colvarCpDomicilioParticular.ColumnName = "cpDomicilioParticular";
				colvarCpDomicilioParticular.DataType = DbType.AnsiString;
				colvarCpDomicilioParticular.MaxLength = 100;
				colvarCpDomicilioParticular.AutoIncrement = false;
				colvarCpDomicilioParticular.IsNullable = true;
				colvarCpDomicilioParticular.IsPrimaryKey = false;
				colvarCpDomicilioParticular.IsForeignKey = false;
				colvarCpDomicilioParticular.IsReadOnly = false;
				colvarCpDomicilioParticular.DefaultSetting = @"";
				colvarCpDomicilioParticular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCpDomicilioParticular);
				
				TableSchema.TableColumn colvarIdTipoTelLaboral = new TableSchema.TableColumn(schema);
				colvarIdTipoTelLaboral.ColumnName = "idTipoTelLaboral";
				colvarIdTipoTelLaboral.DataType = DbType.Int32;
				colvarIdTipoTelLaboral.MaxLength = 0;
				colvarIdTipoTelLaboral.AutoIncrement = false;
				colvarIdTipoTelLaboral.IsNullable = false;
				colvarIdTipoTelLaboral.IsPrimaryKey = false;
				colvarIdTipoTelLaboral.IsForeignKey = false;
				colvarIdTipoTelLaboral.IsReadOnly = false;
				colvarIdTipoTelLaboral.DefaultSetting = @"";
				colvarIdTipoTelLaboral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoTelLaboral);
				
				TableSchema.TableColumn colvarTelefonoLaboral = new TableSchema.TableColumn(schema);
				colvarTelefonoLaboral.ColumnName = "telefonoLaboral";
				colvarTelefonoLaboral.DataType = DbType.AnsiString;
				colvarTelefonoLaboral.MaxLength = 100;
				colvarTelefonoLaboral.AutoIncrement = false;
				colvarTelefonoLaboral.IsNullable = true;
				colvarTelefonoLaboral.IsPrimaryKey = false;
				colvarTelefonoLaboral.IsForeignKey = false;
				colvarTelefonoLaboral.IsReadOnly = false;
				colvarTelefonoLaboral.DefaultSetting = @"";
				colvarTelefonoLaboral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefonoLaboral);
				
				TableSchema.TableColumn colvarIdTipoTelParticular = new TableSchema.TableColumn(schema);
				colvarIdTipoTelParticular.ColumnName = "idTipoTelParticular";
				colvarIdTipoTelParticular.DataType = DbType.Int32;
				colvarIdTipoTelParticular.MaxLength = 0;
				colvarIdTipoTelParticular.AutoIncrement = false;
				colvarIdTipoTelParticular.IsNullable = true;
				colvarIdTipoTelParticular.IsPrimaryKey = false;
				colvarIdTipoTelParticular.IsForeignKey = false;
				colvarIdTipoTelParticular.IsReadOnly = false;
				colvarIdTipoTelParticular.DefaultSetting = @"";
				colvarIdTipoTelParticular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoTelParticular);
				
				TableSchema.TableColumn colvarTelefonoParticular = new TableSchema.TableColumn(schema);
				colvarTelefonoParticular.ColumnName = "telefonoParticular";
				colvarTelefonoParticular.DataType = DbType.AnsiString;
				colvarTelefonoParticular.MaxLength = 100;
				colvarTelefonoParticular.AutoIncrement = false;
				colvarTelefonoParticular.IsNullable = true;
				colvarTelefonoParticular.IsPrimaryKey = false;
				colvarTelefonoParticular.IsForeignKey = false;
				colvarTelefonoParticular.IsReadOnly = false;
				colvarTelefonoParticular.DefaultSetting = @"";
				colvarTelefonoParticular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefonoParticular);
				
				TableSchema.TableColumn colvarEmailLaboral = new TableSchema.TableColumn(schema);
				colvarEmailLaboral.ColumnName = "emailLaboral";
				colvarEmailLaboral.DataType = DbType.AnsiString;
				colvarEmailLaboral.MaxLength = 100;
				colvarEmailLaboral.AutoIncrement = false;
				colvarEmailLaboral.IsNullable = true;
				colvarEmailLaboral.IsPrimaryKey = false;
				colvarEmailLaboral.IsForeignKey = false;
				colvarEmailLaboral.IsReadOnly = false;
				colvarEmailLaboral.DefaultSetting = @"";
				colvarEmailLaboral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmailLaboral);
				
				TableSchema.TableColumn colvarEmailParticular = new TableSchema.TableColumn(schema);
				colvarEmailParticular.ColumnName = "emailParticular";
				colvarEmailParticular.DataType = DbType.AnsiString;
				colvarEmailParticular.MaxLength = 100;
				colvarEmailParticular.AutoIncrement = false;
				colvarEmailParticular.IsNullable = true;
				colvarEmailParticular.IsPrimaryKey = false;
				colvarEmailParticular.IsForeignKey = false;
				colvarEmailParticular.IsReadOnly = false;
				colvarEmailParticular.DefaultSetting = @"";
				colvarEmailParticular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmailParticular);
				
				TableSchema.TableColumn colvarIdEntidad = new TableSchema.TableColumn(schema);
				colvarIdEntidad.ColumnName = "idEntidad";
				colvarIdEntidad.DataType = DbType.Int32;
				colvarIdEntidad.MaxLength = 0;
				colvarIdEntidad.AutoIncrement = false;
				colvarIdEntidad.IsNullable = true;
				colvarIdEntidad.IsPrimaryKey = false;
				colvarIdEntidad.IsForeignKey = false;
				colvarIdEntidad.IsReadOnly = false;
				colvarIdEntidad.DefaultSetting = @"";
				colvarIdEntidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEntidad);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_Investigadores",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdInvestigador")]
		[Bindable(true)]
		public int IdInvestigador 
		{
			get { return GetColumnValue<int>(Columns.IdInvestigador); }
			set { SetColumnValue(Columns.IdInvestigador, value); }
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
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime FechaNacimiento 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("IdTipoDocumento")]
		[Bindable(true)]
		public int IdTipoDocumento 
		{
			get { return GetColumnValue<int>(Columns.IdTipoDocumento); }
			set { SetColumnValue(Columns.IdTipoDocumento, value); }
		}
		  
		[XmlAttribute("NumeroDocumento")]
		[Bindable(true)]
		public string NumeroDocumento 
		{
			get { return GetColumnValue<string>(Columns.NumeroDocumento); }
			set { SetColumnValue(Columns.NumeroDocumento, value); }
		}
		  
		[XmlAttribute("IdProfesion")]
		[Bindable(true)]
		public int IdProfesion 
		{
			get { return GetColumnValue<int>(Columns.IdProfesion); }
			set { SetColumnValue(Columns.IdProfesion, value); }
		}
		  
		[XmlAttribute("NumeroMatricula")]
		[Bindable(true)]
		public string NumeroMatricula 
		{
			get { return GetColumnValue<string>(Columns.NumeroMatricula); }
			set { SetColumnValue(Columns.NumeroMatricula, value); }
		}
		  
		[XmlAttribute("DomicilioLaboral")]
		[Bindable(true)]
		public string DomicilioLaboral 
		{
			get { return GetColumnValue<string>(Columns.DomicilioLaboral); }
			set { SetColumnValue(Columns.DomicilioLaboral, value); }
		}
		  
		[XmlAttribute("CpDomicilioLaboral")]
		[Bindable(true)]
		public string CpDomicilioLaboral 
		{
			get { return GetColumnValue<string>(Columns.CpDomicilioLaboral); }
			set { SetColumnValue(Columns.CpDomicilioLaboral, value); }
		}
		  
		[XmlAttribute("DomicilioParticular")]
		[Bindable(true)]
		public string DomicilioParticular 
		{
			get { return GetColumnValue<string>(Columns.DomicilioParticular); }
			set { SetColumnValue(Columns.DomicilioParticular, value); }
		}
		  
		[XmlAttribute("CpDomicilioParticular")]
		[Bindable(true)]
		public string CpDomicilioParticular 
		{
			get { return GetColumnValue<string>(Columns.CpDomicilioParticular); }
			set { SetColumnValue(Columns.CpDomicilioParticular, value); }
		}
		  
		[XmlAttribute("IdTipoTelLaboral")]
		[Bindable(true)]
		public int IdTipoTelLaboral 
		{
			get { return GetColumnValue<int>(Columns.IdTipoTelLaboral); }
			set { SetColumnValue(Columns.IdTipoTelLaboral, value); }
		}
		  
		[XmlAttribute("TelefonoLaboral")]
		[Bindable(true)]
		public string TelefonoLaboral 
		{
			get { return GetColumnValue<string>(Columns.TelefonoLaboral); }
			set { SetColumnValue(Columns.TelefonoLaboral, value); }
		}
		  
		[XmlAttribute("IdTipoTelParticular")]
		[Bindable(true)]
		public int? IdTipoTelParticular 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoTelParticular); }
			set { SetColumnValue(Columns.IdTipoTelParticular, value); }
		}
		  
		[XmlAttribute("TelefonoParticular")]
		[Bindable(true)]
		public string TelefonoParticular 
		{
			get { return GetColumnValue<string>(Columns.TelefonoParticular); }
			set { SetColumnValue(Columns.TelefonoParticular, value); }
		}
		  
		[XmlAttribute("EmailLaboral")]
		[Bindable(true)]
		public string EmailLaboral 
		{
			get { return GetColumnValue<string>(Columns.EmailLaboral); }
			set { SetColumnValue(Columns.EmailLaboral, value); }
		}
		  
		[XmlAttribute("EmailParticular")]
		[Bindable(true)]
		public string EmailParticular 
		{
			get { return GetColumnValue<string>(Columns.EmailParticular); }
			set { SetColumnValue(Columns.EmailParticular, value); }
		}
		  
		[XmlAttribute("IdEntidad")]
		[Bindable(true)]
		public int? IdEntidad 
		{
			get { return GetColumnValue<int?>(Columns.IdEntidad); }
			set { SetColumnValue(Columns.IdEntidad, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varApellido,string varNombre,string varSexo,DateTime varFechaNacimiento,int varIdTipoDocumento,string varNumeroDocumento,int varIdProfesion,string varNumeroMatricula,string varDomicilioLaboral,string varCpDomicilioLaboral,string varDomicilioParticular,string varCpDomicilioParticular,int varIdTipoTelLaboral,string varTelefonoLaboral,int? varIdTipoTelParticular,string varTelefonoParticular,string varEmailLaboral,string varEmailParticular,int? varIdEntidad)
		{
			RisInvestigadore item = new RisInvestigadore();
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.Sexo = varSexo;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.IdTipoDocumento = varIdTipoDocumento;
			
			item.NumeroDocumento = varNumeroDocumento;
			
			item.IdProfesion = varIdProfesion;
			
			item.NumeroMatricula = varNumeroMatricula;
			
			item.DomicilioLaboral = varDomicilioLaboral;
			
			item.CpDomicilioLaboral = varCpDomicilioLaboral;
			
			item.DomicilioParticular = varDomicilioParticular;
			
			item.CpDomicilioParticular = varCpDomicilioParticular;
			
			item.IdTipoTelLaboral = varIdTipoTelLaboral;
			
			item.TelefonoLaboral = varTelefonoLaboral;
			
			item.IdTipoTelParticular = varIdTipoTelParticular;
			
			item.TelefonoParticular = varTelefonoParticular;
			
			item.EmailLaboral = varEmailLaboral;
			
			item.EmailParticular = varEmailParticular;
			
			item.IdEntidad = varIdEntidad;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdInvestigador,string varApellido,string varNombre,string varSexo,DateTime varFechaNacimiento,int varIdTipoDocumento,string varNumeroDocumento,int varIdProfesion,string varNumeroMatricula,string varDomicilioLaboral,string varCpDomicilioLaboral,string varDomicilioParticular,string varCpDomicilioParticular,int varIdTipoTelLaboral,string varTelefonoLaboral,int? varIdTipoTelParticular,string varTelefonoParticular,string varEmailLaboral,string varEmailParticular,int? varIdEntidad)
		{
			RisInvestigadore item = new RisInvestigadore();
			
				item.IdInvestigador = varIdInvestigador;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.Sexo = varSexo;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.IdTipoDocumento = varIdTipoDocumento;
			
				item.NumeroDocumento = varNumeroDocumento;
			
				item.IdProfesion = varIdProfesion;
			
				item.NumeroMatricula = varNumeroMatricula;
			
				item.DomicilioLaboral = varDomicilioLaboral;
			
				item.CpDomicilioLaboral = varCpDomicilioLaboral;
			
				item.DomicilioParticular = varDomicilioParticular;
			
				item.CpDomicilioParticular = varCpDomicilioParticular;
			
				item.IdTipoTelLaboral = varIdTipoTelLaboral;
			
				item.TelefonoLaboral = varTelefonoLaboral;
			
				item.IdTipoTelParticular = varIdTipoTelParticular;
			
				item.TelefonoParticular = varTelefonoParticular;
			
				item.EmailLaboral = varEmailLaboral;
			
				item.EmailParticular = varEmailParticular;
			
				item.IdEntidad = varIdEntidad;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdInvestigadorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoDocumentoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocumentoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroMatriculaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioLaboralColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CpDomicilioLaboralColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioParticularColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CpDomicilioParticularColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoTelLaboralColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoLaboralColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoTelParticularColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoParticularColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailLaboralColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailParticularColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEntidadColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdInvestigador = @"idInvestigador";
			 public static string Apellido = @"Apellido";
			 public static string Nombre = @"nombre";
			 public static string Sexo = @"sexo";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string IdTipoDocumento = @"idTipoDocumento";
			 public static string NumeroDocumento = @"numeroDocumento";
			 public static string IdProfesion = @"idProfesion";
			 public static string NumeroMatricula = @"numeroMatricula";
			 public static string DomicilioLaboral = @"domicilioLaboral";
			 public static string CpDomicilioLaboral = @"cpDomicilioLaboral";
			 public static string DomicilioParticular = @"domicilioParticular";
			 public static string CpDomicilioParticular = @"cpDomicilioParticular";
			 public static string IdTipoTelLaboral = @"idTipoTelLaboral";
			 public static string TelefonoLaboral = @"telefonoLaboral";
			 public static string IdTipoTelParticular = @"idTipoTelParticular";
			 public static string TelefonoParticular = @"telefonoParticular";
			 public static string EmailLaboral = @"emailLaboral";
			 public static string EmailParticular = @"emailParticular";
			 public static string IdEntidad = @"idEntidad";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
