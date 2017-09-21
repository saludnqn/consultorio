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
	/// Strongly-typed collection for the AprControlNiñoSanoHemoglobina class.
	/// </summary>
    [Serializable]
	public partial class AprControlNiñoSanoHemoglobinaCollection : ActiveList<AprControlNiñoSanoHemoglobina, AprControlNiñoSanoHemoglobinaCollection>
	{	   
		public AprControlNiñoSanoHemoglobinaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprControlNiñoSanoHemoglobinaCollection</returns>
		public AprControlNiñoSanoHemoglobinaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprControlNiñoSanoHemoglobina o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_ControlNiñoSanoHemoglobina table.
	/// </summary>
	[Serializable]
	public partial class AprControlNiñoSanoHemoglobina : ActiveRecord<AprControlNiñoSanoHemoglobina>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprControlNiñoSanoHemoglobina()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprControlNiñoSanoHemoglobina(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprControlNiñoSanoHemoglobina(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprControlNiñoSanoHemoglobina(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_ControlNiñoSanoHemoglobina", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdControlNiñoSanoHemoglobina = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSanoHemoglobina.ColumnName = "idControlNiñoSanoHemoglobina";
				colvarIdControlNiñoSanoHemoglobina.DataType = DbType.Int32;
				colvarIdControlNiñoSanoHemoglobina.MaxLength = 0;
				colvarIdControlNiñoSanoHemoglobina.AutoIncrement = true;
				colvarIdControlNiñoSanoHemoglobina.IsNullable = false;
				colvarIdControlNiñoSanoHemoglobina.IsPrimaryKey = true;
				colvarIdControlNiñoSanoHemoglobina.IsForeignKey = false;
				colvarIdControlNiñoSanoHemoglobina.IsReadOnly = false;
				colvarIdControlNiñoSanoHemoglobina.DefaultSetting = @"";
				colvarIdControlNiñoSanoHemoglobina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdControlNiñoSanoHemoglobina);
				
				TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
				colvarIdControlNiñoSano.DataType = DbType.Int32;
				colvarIdControlNiñoSano.MaxLength = 0;
				colvarIdControlNiñoSano.AutoIncrement = false;
				colvarIdControlNiñoSano.IsNullable = false;
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
				
				TableSchema.TableColumn colvarValor = new TableSchema.TableColumn(schema);
				colvarValor.ColumnName = "Valor";
				colvarValor.DataType = DbType.Decimal;
				colvarValor.MaxLength = 0;
				colvarValor.AutoIncrement = false;
				colvarValor.IsNullable = false;
				colvarValor.IsPrimaryKey = false;
				colvarValor.IsForeignKey = false;
				colvarValor.IsReadOnly = false;
				colvarValor.DefaultSetting = @"";
				colvarValor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValor);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_ControlNiñoSanoHemoglobina",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdControlNiñoSanoHemoglobina")]
		[Bindable(true)]
		public int IdControlNiñoSanoHemoglobina 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSanoHemoglobina); }
			set { SetColumnValue(Columns.IdControlNiñoSanoHemoglobina, value); }
		}
		  
		[XmlAttribute("IdControlNiñoSano")]
		[Bindable(true)]
		public int IdControlNiñoSano 
		{
			get { return GetColumnValue<int>(Columns.IdControlNiñoSano); }
			set { SetColumnValue(Columns.IdControlNiñoSano, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Valor")]
		[Bindable(true)]
		public decimal Valor 
		{
			get { return GetColumnValue<decimal>(Columns.Valor); }
			set { SetColumnValue(Columns.Valor, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprControlNiñoSano ActiveRecord object related to this AprControlNiñoSanoHemoglobina
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
		public static void Insert(int varIdControlNiñoSano,int? varIdPaciente,decimal varValor)
		{
			AprControlNiñoSanoHemoglobina item = new AprControlNiñoSanoHemoglobina();
			
			item.IdControlNiñoSano = varIdControlNiñoSano;
			
			item.IdPaciente = varIdPaciente;
			
			item.Valor = varValor;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdControlNiñoSanoHemoglobina,int varIdControlNiñoSano,int? varIdPaciente,decimal varValor)
		{
			AprControlNiñoSanoHemoglobina item = new AprControlNiñoSanoHemoglobina();
			
				item.IdControlNiñoSanoHemoglobina = varIdControlNiñoSanoHemoglobina;
			
				item.IdControlNiñoSano = varIdControlNiñoSano;
			
				item.IdPaciente = varIdPaciente;
			
				item.Valor = varValor;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoHemoglobinaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdControlNiñoSanoHemoglobina = @"idControlNiñoSanoHemoglobina";
			 public static string IdControlNiñoSano = @"idControlNiñoSano";
			 public static string IdPaciente = @"idPaciente";
			 public static string Valor = @"Valor";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
