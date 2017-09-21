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
	/// Strongly-typed collection for the PnTransaccionCertificado class.
	/// </summary>
    [Serializable]
	public partial class PnTransaccionCertificadoCollection : ActiveList<PnTransaccionCertificado, PnTransaccionCertificadoCollection>
	{	   
		public PnTransaccionCertificadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTransaccionCertificadoCollection</returns>
		public PnTransaccionCertificadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTransaccionCertificado o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_transaccion_certificado table.
	/// </summary>
	[Serializable]
	public partial class PnTransaccionCertificado : ActiveRecord<PnTransaccionCertificado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTransaccionCertificado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTransaccionCertificado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTransaccionCertificado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTransaccionCertificado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_transaccion_certificado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTransaccionCertificado = new TableSchema.TableColumn(schema);
				colvarIdTransaccionCertificado.ColumnName = "id_transaccion_certificado";
				colvarIdTransaccionCertificado.DataType = DbType.Int32;
				colvarIdTransaccionCertificado.MaxLength = 0;
				colvarIdTransaccionCertificado.AutoIncrement = true;
				colvarIdTransaccionCertificado.IsNullable = false;
				colvarIdTransaccionCertificado.IsPrimaryKey = true;
				colvarIdTransaccionCertificado.IsForeignKey = false;
				colvarIdTransaccionCertificado.IsReadOnly = false;
				colvarIdTransaccionCertificado.DefaultSetting = @"";
				colvarIdTransaccionCertificado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTransaccionCertificado);
				
				TableSchema.TableColumn colvarIdSmiafiliados = new TableSchema.TableColumn(schema);
				colvarIdSmiafiliados.ColumnName = "id_smiafiliados";
				colvarIdSmiafiliados.DataType = DbType.Int32;
				colvarIdSmiafiliados.MaxLength = 0;
				colvarIdSmiafiliados.AutoIncrement = false;
				colvarIdSmiafiliados.IsNullable = true;
				colvarIdSmiafiliados.IsPrimaryKey = false;
				colvarIdSmiafiliados.IsForeignKey = false;
				colvarIdSmiafiliados.IsReadOnly = false;
				colvarIdSmiafiliados.DefaultSetting = @"";
				colvarIdSmiafiliados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSmiafiliados);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = -1;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
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
				
				TableSchema.TableColumn colvarIpmaquina = new TableSchema.TableColumn(schema);
				colvarIpmaquina.ColumnName = "ipmaquina";
				colvarIpmaquina.DataType = DbType.AnsiString;
				colvarIpmaquina.MaxLength = -1;
				colvarIpmaquina.AutoIncrement = false;
				colvarIpmaquina.IsNullable = true;
				colvarIpmaquina.IsPrimaryKey = false;
				colvarIpmaquina.IsForeignKey = false;
				colvarIpmaquina.IsReadOnly = false;
				colvarIpmaquina.DefaultSetting = @"";
				colvarIpmaquina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIpmaquina);
				
				TableSchema.TableColumn colvarIdBeneficiarios = new TableSchema.TableColumn(schema);
				colvarIdBeneficiarios.ColumnName = "id_beneficiarios";
				colvarIdBeneficiarios.DataType = DbType.Int32;
				colvarIdBeneficiarios.MaxLength = 0;
				colvarIdBeneficiarios.AutoIncrement = false;
				colvarIdBeneficiarios.IsNullable = true;
				colvarIdBeneficiarios.IsPrimaryKey = false;
				colvarIdBeneficiarios.IsForeignKey = false;
				colvarIdBeneficiarios.IsReadOnly = false;
				colvarIdBeneficiarios.DefaultSetting = @"";
				colvarIdBeneficiarios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBeneficiarios);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_transaccion_certificado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTransaccionCertificado")]
		[Bindable(true)]
		public int IdTransaccionCertificado 
		{
			get { return GetColumnValue<int>(Columns.IdTransaccionCertificado); }
			set { SetColumnValue(Columns.IdTransaccionCertificado, value); }
		}
		  
		[XmlAttribute("IdSmiafiliados")]
		[Bindable(true)]
		public int? IdSmiafiliados 
		{
			get { return GetColumnValue<int?>(Columns.IdSmiafiliados); }
			set { SetColumnValue(Columns.IdSmiafiliados, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Ipmaquina")]
		[Bindable(true)]
		public string Ipmaquina 
		{
			get { return GetColumnValue<string>(Columns.Ipmaquina); }
			set { SetColumnValue(Columns.Ipmaquina, value); }
		}
		  
		[XmlAttribute("IdBeneficiarios")]
		[Bindable(true)]
		public int? IdBeneficiarios 
		{
			get { return GetColumnValue<int?>(Columns.IdBeneficiarios); }
			set { SetColumnValue(Columns.IdBeneficiarios, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdSmiafiliados,string varUsuario,DateTime? varFecha,string varIpmaquina,int? varIdBeneficiarios)
		{
			PnTransaccionCertificado item = new PnTransaccionCertificado();
			
			item.IdSmiafiliados = varIdSmiafiliados;
			
			item.Usuario = varUsuario;
			
			item.Fecha = varFecha;
			
			item.Ipmaquina = varIpmaquina;
			
			item.IdBeneficiarios = varIdBeneficiarios;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTransaccionCertificado,int? varIdSmiafiliados,string varUsuario,DateTime? varFecha,string varIpmaquina,int? varIdBeneficiarios)
		{
			PnTransaccionCertificado item = new PnTransaccionCertificado();
			
				item.IdTransaccionCertificado = varIdTransaccionCertificado;
			
				item.IdSmiafiliados = varIdSmiafiliados;
			
				item.Usuario = varUsuario;
			
				item.Fecha = varFecha;
			
				item.Ipmaquina = varIpmaquina;
			
				item.IdBeneficiarios = varIdBeneficiarios;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTransaccionCertificadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSmiafiliadosColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IpmaquinaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBeneficiariosColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTransaccionCertificado = @"id_transaccion_certificado";
			 public static string IdSmiafiliados = @"id_smiafiliados";
			 public static string Usuario = @"usuario";
			 public static string Fecha = @"fecha";
			 public static string Ipmaquina = @"ipmaquina";
			 public static string IdBeneficiarios = @"id_beneficiarios";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
