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
	/// Strongly-typed collection for the RisEstudioInvestigador class.
	/// </summary>
    [Serializable]
	public partial class RisEstudioInvestigadorCollection : ActiveList<RisEstudioInvestigador, RisEstudioInvestigadorCollection>
	{	   
		public RisEstudioInvestigadorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisEstudioInvestigadorCollection</returns>
		public RisEstudioInvestigadorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisEstudioInvestigador o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_EstudioInvestigador table.
	/// </summary>
	[Serializable]
	public partial class RisEstudioInvestigador : ActiveRecord<RisEstudioInvestigador>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisEstudioInvestigador()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisEstudioInvestigador(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisEstudioInvestigador(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisEstudioInvestigador(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_EstudioInvestigador", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEstudioInvestigador = new TableSchema.TableColumn(schema);
				colvarIdEstudioInvestigador.ColumnName = "idEstudioInvestigador";
				colvarIdEstudioInvestigador.DataType = DbType.Int32;
				colvarIdEstudioInvestigador.MaxLength = 0;
				colvarIdEstudioInvestigador.AutoIncrement = true;
				colvarIdEstudioInvestigador.IsNullable = false;
				colvarIdEstudioInvestigador.IsPrimaryKey = true;
				colvarIdEstudioInvestigador.IsForeignKey = false;
				colvarIdEstudioInvestigador.IsReadOnly = false;
				colvarIdEstudioInvestigador.DefaultSetting = @"";
				colvarIdEstudioInvestigador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudioInvestigador);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarIdInvestigador = new TableSchema.TableColumn(schema);
				colvarIdInvestigador.ColumnName = "idInvestigador";
				colvarIdInvestigador.DataType = DbType.Int32;
				colvarIdInvestigador.MaxLength = 0;
				colvarIdInvestigador.AutoIncrement = false;
				colvarIdInvestigador.IsNullable = false;
				colvarIdInvestigador.IsPrimaryKey = false;
				colvarIdInvestigador.IsForeignKey = false;
				colvarIdInvestigador.IsReadOnly = false;
				colvarIdInvestigador.DefaultSetting = @"";
				colvarIdInvestigador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInvestigador);
				
				TableSchema.TableColumn colvarIdFuncionEnElEquipo = new TableSchema.TableColumn(schema);
				colvarIdFuncionEnElEquipo.ColumnName = "idFuncionEnElEquipo";
				colvarIdFuncionEnElEquipo.DataType = DbType.Int32;
				colvarIdFuncionEnElEquipo.MaxLength = 0;
				colvarIdFuncionEnElEquipo.AutoIncrement = false;
				colvarIdFuncionEnElEquipo.IsNullable = true;
				colvarIdFuncionEnElEquipo.IsPrimaryKey = false;
				colvarIdFuncionEnElEquipo.IsForeignKey = false;
				colvarIdFuncionEnElEquipo.IsReadOnly = false;
				colvarIdFuncionEnElEquipo.DefaultSetting = @"";
				colvarIdFuncionEnElEquipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFuncionEnElEquipo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_EstudioInvestigador",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEstudioInvestigador")]
		[Bindable(true)]
		public int IdEstudioInvestigador 
		{
			get { return GetColumnValue<int>(Columns.IdEstudioInvestigador); }
			set { SetColumnValue(Columns.IdEstudioInvestigador, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("IdInvestigador")]
		[Bindable(true)]
		public int IdInvestigador 
		{
			get { return GetColumnValue<int>(Columns.IdInvestigador); }
			set { SetColumnValue(Columns.IdInvestigador, value); }
		}
		  
		[XmlAttribute("IdFuncionEnElEquipo")]
		[Bindable(true)]
		public int? IdFuncionEnElEquipo 
		{
			get { return GetColumnValue<int?>(Columns.IdFuncionEnElEquipo); }
			set { SetColumnValue(Columns.IdFuncionEnElEquipo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,int varIdInvestigador,int? varIdFuncionEnElEquipo)
		{
			RisEstudioInvestigador item = new RisEstudioInvestigador();
			
			item.IdEstudio = varIdEstudio;
			
			item.IdInvestigador = varIdInvestigador;
			
			item.IdFuncionEnElEquipo = varIdFuncionEnElEquipo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEstudioInvestigador,int varIdEstudio,int varIdInvestigador,int? varIdFuncionEnElEquipo)
		{
			RisEstudioInvestigador item = new RisEstudioInvestigador();
			
				item.IdEstudioInvestigador = varIdEstudioInvestigador;
			
				item.IdEstudio = varIdEstudio;
			
				item.IdInvestigador = varIdInvestigador;
			
				item.IdFuncionEnElEquipo = varIdFuncionEnElEquipo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEstudioInvestigadorColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInvestigadorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdFuncionEnElEquipoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEstudioInvestigador = @"idEstudioInvestigador";
			 public static string IdEstudio = @"idEstudio";
			 public static string IdInvestigador = @"idInvestigador";
			 public static string IdFuncionEnElEquipo = @"idFuncionEnElEquipo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
