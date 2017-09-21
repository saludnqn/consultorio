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
	/// Strongly-typed collection for the RisEvaluacionRechazada class.
	/// </summary>
    [Serializable]
	public partial class RisEvaluacionRechazadaCollection : ActiveList<RisEvaluacionRechazada, RisEvaluacionRechazadaCollection>
	{	   
		public RisEvaluacionRechazadaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEvaluacionRechazadaCollection</returns>
		public RisEvaluacionRechazadaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEvaluacionRechazada o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EvaluacionRechazada table.
	/// </summary>
	[Serializable]
	public partial class RisEvaluacionRechazada : ActiveRecord<RisEvaluacionRechazada>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEvaluacionRechazada()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEvaluacionRechazada(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEvaluacionRechazada(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEvaluacionRechazada(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EvaluacionRechazada", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEvaluacionRechazada = new TableSchema.TableColumn(schema);
				colvarIdEvaluacionRechazada.ColumnName = "idEvaluacionRechazada";
				colvarIdEvaluacionRechazada.DataType = DbType.Int32;
				colvarIdEvaluacionRechazada.MaxLength = 0;
				colvarIdEvaluacionRechazada.AutoIncrement = true;
				colvarIdEvaluacionRechazada.IsNullable = false;
				colvarIdEvaluacionRechazada.IsPrimaryKey = true;
				colvarIdEvaluacionRechazada.IsForeignKey = false;
				colvarIdEvaluacionRechazada.IsReadOnly = false;
				colvarIdEvaluacionRechazada.DefaultSetting = @"";
				colvarIdEvaluacionRechazada.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEvaluacionRechazada);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = true;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarNumeroRegistro = new TableSchema.TableColumn(schema);
				colvarNumeroRegistro.ColumnName = "numeroRegistro";
				colvarNumeroRegistro.DataType = DbType.String;
				colvarNumeroRegistro.MaxLength = 50;
				colvarNumeroRegistro.AutoIncrement = false;
				colvarNumeroRegistro.IsNullable = true;
				colvarNumeroRegistro.IsPrimaryKey = false;
				colvarNumeroRegistro.IsForeignKey = false;
				colvarNumeroRegistro.IsReadOnly = false;
				colvarNumeroRegistro.DefaultSetting = @"";
				colvarNumeroRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroRegistro);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarInstitucionPertenece = new TableSchema.TableColumn(schema);
				colvarInstitucionPertenece.ColumnName = "institucionPertenece";
				colvarInstitucionPertenece.DataType = DbType.String;
				colvarInstitucionPertenece.MaxLength = 100;
				colvarInstitucionPertenece.AutoIncrement = false;
				colvarInstitucionPertenece.IsNullable = true;
				colvarInstitucionPertenece.IsPrimaryKey = false;
				colvarInstitucionPertenece.IsForeignKey = false;
				colvarInstitucionPertenece.IsReadOnly = false;
				colvarInstitucionPertenece.DefaultSetting = @"";
				colvarInstitucionPertenece.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInstitucionPertenece);
				
				TableSchema.TableColumn colvarResponsableComite = new TableSchema.TableColumn(schema);
				colvarResponsableComite.ColumnName = "responsableComite";
				colvarResponsableComite.DataType = DbType.String;
				colvarResponsableComite.MaxLength = 100;
				colvarResponsableComite.AutoIncrement = false;
				colvarResponsableComite.IsNullable = true;
				colvarResponsableComite.IsPrimaryKey = false;
				colvarResponsableComite.IsForeignKey = false;
				colvarResponsableComite.IsReadOnly = false;
				colvarResponsableComite.DefaultSetting = @"";
				colvarResponsableComite.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsableComite);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.String;
				colvarDomicilio.MaxLength = 100;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.String;
				colvarTelefono.MaxLength = 100;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarMail = new TableSchema.TableColumn(schema);
				colvarMail.ColumnName = "mail";
				colvarMail.DataType = DbType.String;
				colvarMail.MaxLength = 100;
				colvarMail.AutoIncrement = false;
				colvarMail.IsNullable = true;
				colvarMail.IsPrimaryKey = false;
				colvarMail.IsForeignKey = false;
				colvarMail.IsReadOnly = false;
				colvarMail.DefaultSetting = @"";
				colvarMail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMail);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EvaluacionRechazada",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEvaluacionRechazada")]
		[Bindable(true)]
		public int IdEvaluacionRechazada 
		{
			get { return GetColumnValue<int>(Columns.IdEvaluacionRechazada); }
			set { SetColumnValue(Columns.IdEvaluacionRechazada, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int? IdEstudio 
		{
			get { return GetColumnValue<int?>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("NumeroRegistro")]
		[Bindable(true)]
		public string NumeroRegistro 
		{
			get { return GetColumnValue<string>(Columns.NumeroRegistro); }
			set { SetColumnValue(Columns.NumeroRegistro, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("InstitucionPertenece")]
		[Bindable(true)]
		public string InstitucionPertenece 
		{
			get { return GetColumnValue<string>(Columns.InstitucionPertenece); }
			set { SetColumnValue(Columns.InstitucionPertenece, value); }
		}
		  
		[XmlAttribute("ResponsableComite")]
		[Bindable(true)]
		public string ResponsableComite 
		{
			get { return GetColumnValue<string>(Columns.ResponsableComite); }
			set { SetColumnValue(Columns.ResponsableComite, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("Mail")]
		[Bindable(true)]
		public string Mail 
		{
			get { return GetColumnValue<string>(Columns.Mail); }
			set { SetColumnValue(Columns.Mail, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEstudio,string varNumeroRegistro,DateTime? varFecha,string varInstitucionPertenece,string varResponsableComite,string varDomicilio,string varTelefono,string varMail)
		{
			RisEvaluacionRechazada item = new RisEvaluacionRechazada();
			
			item.IdEstudio = varIdEstudio;
			
			item.NumeroRegistro = varNumeroRegistro;
			
			item.Fecha = varFecha;
			
			item.InstitucionPertenece = varInstitucionPertenece;
			
			item.ResponsableComite = varResponsableComite;
			
			item.Domicilio = varDomicilio;
			
			item.Telefono = varTelefono;
			
			item.Mail = varMail;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEvaluacionRechazada,int? varIdEstudio,string varNumeroRegistro,DateTime? varFecha,string varInstitucionPertenece,string varResponsableComite,string varDomicilio,string varTelefono,string varMail)
		{
			RisEvaluacionRechazada item = new RisEvaluacionRechazada();
			
				item.IdEvaluacionRechazada = varIdEvaluacionRechazada;
			
				item.IdEstudio = varIdEstudio;
			
				item.NumeroRegistro = varNumeroRegistro;
			
				item.Fecha = varFecha;
			
				item.InstitucionPertenece = varInstitucionPertenece;
			
				item.ResponsableComite = varResponsableComite;
			
				item.Domicilio = varDomicilio;
			
				item.Telefono = varTelefono;
			
				item.Mail = varMail;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEvaluacionRechazadaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroRegistroColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn InstitucionPerteneceColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableComiteColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn MailColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEvaluacionRechazada = @"idEvaluacionRechazada";
			 public static string IdEstudio = @"idEstudio";
			 public static string NumeroRegistro = @"numeroRegistro";
			 public static string Fecha = @"fecha";
			 public static string InstitucionPertenece = @"institucionPertenece";
			 public static string ResponsableComite = @"responsableComite";
			 public static string Domicilio = @"domicilio";
			 public static string Telefono = @"telefono";
			 public static string Mail = @"mail";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
