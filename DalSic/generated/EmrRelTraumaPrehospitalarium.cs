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
	/// Strongly-typed collection for the EmrRelTraumaPrehospitalarium class.
	/// </summary>
    [Serializable]
	public partial class EmrRelTraumaPrehospitalariumCollection : ActiveList<EmrRelTraumaPrehospitalarium, EmrRelTraumaPrehospitalariumCollection>
	{	   
		public EmrRelTraumaPrehospitalariumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>EmrRelTraumaPrehospitalariumCollection</returns>
		public EmrRelTraumaPrehospitalariumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                EmrRelTraumaPrehospitalarium o = this[i];
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
	/// This is an ActiveRecord class which wraps the EMR_RelTraumaPrehospitalaria table.
	/// </summary>
	[Serializable]
	public partial class EmrRelTraumaPrehospitalarium : ActiveRecord<EmrRelTraumaPrehospitalarium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public EmrRelTraumaPrehospitalarium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public EmrRelTraumaPrehospitalarium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public EmrRelTraumaPrehospitalarium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public EmrRelTraumaPrehospitalarium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("EMR_RelTraumaPrehospitalaria", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelTraumaPrehospitalaria = new TableSchema.TableColumn(schema);
				colvarIdRelTraumaPrehospitalaria.ColumnName = "idRelTraumaPrehospitalaria";
				colvarIdRelTraumaPrehospitalaria.DataType = DbType.Int32;
				colvarIdRelTraumaPrehospitalaria.MaxLength = 0;
				colvarIdRelTraumaPrehospitalaria.AutoIncrement = true;
				colvarIdRelTraumaPrehospitalaria.IsNullable = false;
				colvarIdRelTraumaPrehospitalaria.IsPrimaryKey = true;
				colvarIdRelTraumaPrehospitalaria.IsForeignKey = false;
				colvarIdRelTraumaPrehospitalaria.IsReadOnly = false;
				colvarIdRelTraumaPrehospitalaria.DefaultSetting = @"";
				colvarIdRelTraumaPrehospitalaria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelTraumaPrehospitalaria);
				
				TableSchema.TableColumn colvarIdTrauma = new TableSchema.TableColumn(schema);
				colvarIdTrauma.ColumnName = "idTrauma";
				colvarIdTrauma.DataType = DbType.Int32;
				colvarIdTrauma.MaxLength = 0;
				colvarIdTrauma.AutoIncrement = false;
				colvarIdTrauma.IsNullable = true;
				colvarIdTrauma.IsPrimaryKey = false;
				colvarIdTrauma.IsForeignKey = true;
				colvarIdTrauma.IsReadOnly = false;
				colvarIdTrauma.DefaultSetting = @"";
				
					colvarIdTrauma.ForeignKeyTableName = "EMR_Trauma";
				schema.Columns.Add(colvarIdTrauma);
				
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
				
				TableSchema.TableColumn colvarIdHCPrehospitalaria = new TableSchema.TableColumn(schema);
				colvarIdHCPrehospitalaria.ColumnName = "idHCPrehospitalaria";
				colvarIdHCPrehospitalaria.DataType = DbType.Int32;
				colvarIdHCPrehospitalaria.MaxLength = 0;
				colvarIdHCPrehospitalaria.AutoIncrement = false;
				colvarIdHCPrehospitalaria.IsNullable = true;
				colvarIdHCPrehospitalaria.IsPrimaryKey = false;
				colvarIdHCPrehospitalaria.IsForeignKey = true;
				colvarIdHCPrehospitalaria.IsReadOnly = false;
				colvarIdHCPrehospitalaria.DefaultSetting = @"";
				
					colvarIdHCPrehospitalaria.ForeignKeyTableName = "EMR_Prehospitalaria";
				schema.Columns.Add(colvarIdHCPrehospitalaria);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("EMR_RelTraumaPrehospitalaria",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelTraumaPrehospitalaria")]
		[Bindable(true)]
		public int IdRelTraumaPrehospitalaria 
		{
			get { return GetColumnValue<int>(Columns.IdRelTraumaPrehospitalaria); }
			set { SetColumnValue(Columns.IdRelTraumaPrehospitalaria, value); }
		}
		  
		[XmlAttribute("IdTrauma")]
		[Bindable(true)]
		public int? IdTrauma 
		{
			get { return GetColumnValue<int?>(Columns.IdTrauma); }
			set { SetColumnValue(Columns.IdTrauma, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("IdHCPrehospitalaria")]
		[Bindable(true)]
		public int? IdHCPrehospitalaria 
		{
			get { return GetColumnValue<int?>(Columns.IdHCPrehospitalaria); }
			set { SetColumnValue(Columns.IdHCPrehospitalaria, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdTrauma,int? varIdPaciente,int? varIdHCPrehospitalaria)
		{
			EmrRelTraumaPrehospitalarium item = new EmrRelTraumaPrehospitalarium();
			
			item.IdTrauma = varIdTrauma;
			
			item.IdPaciente = varIdPaciente;
			
			item.IdHCPrehospitalaria = varIdHCPrehospitalaria;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelTraumaPrehospitalaria,int? varIdTrauma,int? varIdPaciente,int? varIdHCPrehospitalaria)
		{
			EmrRelTraumaPrehospitalarium item = new EmrRelTraumaPrehospitalarium();
			
				item.IdRelTraumaPrehospitalaria = varIdRelTraumaPrehospitalaria;
			
				item.IdTrauma = varIdTrauma;
			
				item.IdPaciente = varIdPaciente;
			
				item.IdHCPrehospitalaria = varIdHCPrehospitalaria;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelTraumaPrehospitalariaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTraumaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdHCPrehospitalariaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelTraumaPrehospitalaria = @"idRelTraumaPrehospitalaria";
			 public static string IdTrauma = @"idTrauma";
			 public static string IdPaciente = @"idPaciente";
			 public static string IdHCPrehospitalaria = @"idHCPrehospitalaria";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
