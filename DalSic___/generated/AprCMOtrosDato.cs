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
	/// Strongly-typed collection for the AprCMOtrosDato class.
	/// </summary>
    [Serializable]
	public partial class AprCMOtrosDatoCollection : ActiveList<AprCMOtrosDato, AprCMOtrosDatoCollection>
	{	   
		public AprCMOtrosDatoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprCMOtrosDatoCollection</returns>
		public AprCMOtrosDatoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprCMOtrosDato o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_CMOtrosDatos table.
	/// </summary>
	[Serializable]
	public partial class AprCMOtrosDato : ActiveRecord<AprCMOtrosDato>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprCMOtrosDato()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprCMOtrosDato(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprCMOtrosDato(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprCMOtrosDato(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_CMOtrosDatos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdOtrosDatosPaternos = new TableSchema.TableColumn(schema);
				colvarIdOtrosDatosPaternos.ColumnName = "idOtrosDatosPaternos";
				colvarIdOtrosDatosPaternos.DataType = DbType.Int32;
				colvarIdOtrosDatosPaternos.MaxLength = 0;
				colvarIdOtrosDatosPaternos.AutoIncrement = true;
				colvarIdOtrosDatosPaternos.IsNullable = false;
				colvarIdOtrosDatosPaternos.IsPrimaryKey = true;
				colvarIdOtrosDatosPaternos.IsForeignKey = false;
				colvarIdOtrosDatosPaternos.IsReadOnly = false;
				colvarIdOtrosDatosPaternos.DefaultSetting = @"";
				colvarIdOtrosDatosPaternos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdOtrosDatosPaternos);
				
				TableSchema.TableColumn colvarTrabaja = new TableSchema.TableColumn(schema);
				colvarTrabaja.ColumnName = "Trabaja";
				colvarTrabaja.DataType = DbType.Boolean;
				colvarTrabaja.MaxLength = 0;
				colvarTrabaja.AutoIncrement = false;
				colvarTrabaja.IsNullable = true;
				colvarTrabaja.IsPrimaryKey = false;
				colvarTrabaja.IsForeignKey = false;
				colvarTrabaja.IsReadOnly = false;
				colvarTrabaja.DefaultSetting = @"";
				colvarTrabaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrabaja);
				
				TableSchema.TableColumn colvarCantidadHoras = new TableSchema.TableColumn(schema);
				colvarCantidadHoras.ColumnName = "CantidadHoras";
				colvarCantidadHoras.DataType = DbType.Int32;
				colvarCantidadHoras.MaxLength = 0;
				colvarCantidadHoras.AutoIncrement = false;
				colvarCantidadHoras.IsNullable = true;
				colvarCantidadHoras.IsPrimaryKey = false;
				colvarCantidadHoras.IsForeignKey = false;
				colvarCantidadHoras.IsReadOnly = false;
				colvarCantidadHoras.DefaultSetting = @"";
				colvarCantidadHoras.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadHoras);
				
				TableSchema.TableColumn colvarAsistenciaEconomica = new TableSchema.TableColumn(schema);
				colvarAsistenciaEconomica.ColumnName = "AsistenciaEconomica";
				colvarAsistenciaEconomica.DataType = DbType.Boolean;
				colvarAsistenciaEconomica.MaxLength = 0;
				colvarAsistenciaEconomica.AutoIncrement = false;
				colvarAsistenciaEconomica.IsNullable = true;
				colvarAsistenciaEconomica.IsPrimaryKey = false;
				colvarAsistenciaEconomica.IsForeignKey = false;
				colvarAsistenciaEconomica.IsReadOnly = false;
				colvarAsistenciaEconomica.DefaultSetting = @"";
				colvarAsistenciaEconomica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAsistenciaEconomica);
				
				TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
				colvarIdControlNiñoSano.DataType = DbType.Int32;
				colvarIdControlNiñoSano.MaxLength = 0;
				colvarIdControlNiñoSano.AutoIncrement = false;
				colvarIdControlNiñoSano.IsNullable = true;
				colvarIdControlNiñoSano.IsPrimaryKey = false;
				colvarIdControlNiñoSano.IsForeignKey = true;
				colvarIdControlNiñoSano.IsReadOnly = false;
				colvarIdControlNiñoSano.DefaultSetting = @"";
				
					colvarIdControlNiñoSano.ForeignKeyTableName = "APR_ControlNiñoSano";
				schema.Columns.Add(colvarIdControlNiñoSano);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_CMOtrosDatos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdOtrosDatosPaternos")]
		[Bindable(true)]
		public int IdOtrosDatosPaternos 
		{
			get { return GetColumnValue<int>(Columns.IdOtrosDatosPaternos); }
			set { SetColumnValue(Columns.IdOtrosDatosPaternos, value); }
		}
		  
		[XmlAttribute("Trabaja")]
		[Bindable(true)]
		public bool? Trabaja 
		{
			get { return GetColumnValue<bool?>(Columns.Trabaja); }
			set { SetColumnValue(Columns.Trabaja, value); }
		}
		  
		[XmlAttribute("CantidadHoras")]
		[Bindable(true)]
		public int? CantidadHoras 
		{
			get { return GetColumnValue<int?>(Columns.CantidadHoras); }
			set { SetColumnValue(Columns.CantidadHoras, value); }
		}
		  
		[XmlAttribute("AsistenciaEconomica")]
		[Bindable(true)]
		public bool? AsistenciaEconomica 
		{
			get { return GetColumnValue<bool?>(Columns.AsistenciaEconomica); }
			set { SetColumnValue(Columns.AsistenciaEconomica, value); }
		}
		  
		[XmlAttribute("IdControlNiñoSano")]
		[Bindable(true)]
		public int? IdControlNiñoSano 
		{
			get { return GetColumnValue<int?>(Columns.IdControlNiñoSano); }
			set { SetColumnValue(Columns.IdControlNiñoSano, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprControlNiñoSano ActiveRecord object related to this AprCMOtrosDato
		/// 
		/// </summary>
		public DalSic.AprControlNiñoSano AprControlNiñoSano
		{
			get { return DalSic.AprControlNiñoSano.FetchByID(this.IdControlNiñoSano); }
			set { SetColumnValue("idControlNiñoSano", value.IdControlNiñoSano); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(bool? varTrabaja,int? varCantidadHoras,bool? varAsistenciaEconomica,int? varIdControlNiñoSano,int? varIdPaciente)
		{
			AprCMOtrosDato item = new AprCMOtrosDato();
			
			item.Trabaja = varTrabaja;
			
			item.CantidadHoras = varCantidadHoras;
			
			item.AsistenciaEconomica = varAsistenciaEconomica;
			
			item.IdControlNiñoSano = varIdControlNiñoSano;
			
			item.IdPaciente = varIdPaciente;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdOtrosDatosPaternos,bool? varTrabaja,int? varCantidadHoras,bool? varAsistenciaEconomica,int? varIdControlNiñoSano,int? varIdPaciente)
		{
			AprCMOtrosDato item = new AprCMOtrosDato();
			
				item.IdOtrosDatosPaternos = varIdOtrosDatosPaternos;
			
				item.Trabaja = varTrabaja;
			
				item.CantidadHoras = varCantidadHoras;
			
				item.AsistenciaEconomica = varAsistenciaEconomica;
			
				item.IdControlNiñoSano = varIdControlNiñoSano;
			
				item.IdPaciente = varIdPaciente;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdOtrosDatosPaternosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TrabajaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadHorasColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AsistenciaEconomicaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdOtrosDatosPaternos = @"idOtrosDatosPaternos";
			 public static string Trabaja = @"Trabaja";
			 public static string CantidadHoras = @"CantidadHoras";
			 public static string AsistenciaEconomica = @"AsistenciaEconomica";
			 public static string IdControlNiñoSano = @"idControlNiñoSano";
			 public static string IdPaciente = @"idPaciente";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
