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
	/// Strongly-typed collection for the GuardiaMedicosFuncione class.
	/// </summary>
    [Serializable]
	public partial class GuardiaMedicosFuncioneCollection : ActiveList<GuardiaMedicosFuncione, GuardiaMedicosFuncioneCollection>
	{	   
		public GuardiaMedicosFuncioneCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaMedicosFuncioneCollection</returns>
		public GuardiaMedicosFuncioneCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaMedicosFuncione o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Medicos_Funciones table.
	/// </summary>
	[Serializable]
	public partial class GuardiaMedicosFuncione : ActiveRecord<GuardiaMedicosFuncione>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaMedicosFuncione()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaMedicosFuncione(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaMedicosFuncione(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaMedicosFuncione(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Medicos_Funciones", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMedico = new TableSchema.TableColumn(schema);
				colvarIdMedico.ColumnName = "idMedico";
				colvarIdMedico.DataType = DbType.Int32;
				colvarIdMedico.MaxLength = 0;
				colvarIdMedico.AutoIncrement = false;
				colvarIdMedico.IsNullable = false;
				colvarIdMedico.IsPrimaryKey = true;
				colvarIdMedico.IsForeignKey = false;
				colvarIdMedico.IsReadOnly = false;
				colvarIdMedico.DefaultSetting = @"";
				colvarIdMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedico);
				
				TableSchema.TableColumn colvarIdFuncion = new TableSchema.TableColumn(schema);
				colvarIdFuncion.ColumnName = "idFuncion";
				colvarIdFuncion.DataType = DbType.AnsiString;
				colvarIdFuncion.MaxLength = 50;
				colvarIdFuncion.AutoIncrement = false;
				colvarIdFuncion.IsNullable = false;
				colvarIdFuncion.IsPrimaryKey = false;
				colvarIdFuncion.IsForeignKey = false;
				colvarIdFuncion.IsReadOnly = false;
				colvarIdFuncion.DefaultSetting = @"";
				colvarIdFuncion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFuncion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Medicos_Funciones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMedico")]
		[Bindable(true)]
		public int IdMedico 
		{
			get { return GetColumnValue<int>(Columns.IdMedico); }
			set { SetColumnValue(Columns.IdMedico, value); }
		}
		  
		[XmlAttribute("IdFuncion")]
		[Bindable(true)]
		public string IdFuncion 
		{
			get { return GetColumnValue<string>(Columns.IdFuncion); }
			set { SetColumnValue(Columns.IdFuncion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdMedico,string varIdFuncion)
		{
			GuardiaMedicosFuncione item = new GuardiaMedicosFuncione();
			
			item.IdMedico = varIdMedico;
			
			item.IdFuncion = varIdFuncion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMedico,string varIdFuncion)
		{
			GuardiaMedicosFuncione item = new GuardiaMedicosFuncione();
			
				item.IdMedico = varIdMedico;
			
				item.IdFuncion = varIdFuncion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMedicoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFuncionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMedico = @"idMedico";
			 public static string IdFuncion = @"idFuncion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
