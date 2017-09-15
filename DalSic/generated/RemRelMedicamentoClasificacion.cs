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
	/// Strongly-typed collection for the RemRelMedicamentoClasificacion class.
	/// </summary>
    [Serializable]
	public partial class RemRelMedicamentoClasificacionCollection : ActiveList<RemRelMedicamentoClasificacion, RemRelMedicamentoClasificacionCollection>
	{	   
		public RemRelMedicamentoClasificacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemRelMedicamentoClasificacionCollection</returns>
		public RemRelMedicamentoClasificacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemRelMedicamentoClasificacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_RelMedicamentoClasificacion table.
	/// </summary>
	[Serializable]
	public partial class RemRelMedicamentoClasificacion : ActiveRecord<RemRelMedicamentoClasificacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemRelMedicamentoClasificacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemRelMedicamentoClasificacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemRelMedicamentoClasificacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemRelMedicamentoClasificacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_RelMedicamentoClasificacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelMedicamentoClasificacion = new TableSchema.TableColumn(schema);
				colvarIdRelMedicamentoClasificacion.ColumnName = "idRelMedicamentoClasificacion";
				colvarIdRelMedicamentoClasificacion.DataType = DbType.Int32;
				colvarIdRelMedicamentoClasificacion.MaxLength = 0;
				colvarIdRelMedicamentoClasificacion.AutoIncrement = true;
				colvarIdRelMedicamentoClasificacion.IsNullable = false;
				colvarIdRelMedicamentoClasificacion.IsPrimaryKey = true;
				colvarIdRelMedicamentoClasificacion.IsForeignKey = false;
				colvarIdRelMedicamentoClasificacion.IsReadOnly = false;
				colvarIdRelMedicamentoClasificacion.DefaultSetting = @"";
				colvarIdRelMedicamentoClasificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelMedicamentoClasificacion);
				
				TableSchema.TableColumn colvarIdMedicamento = new TableSchema.TableColumn(schema);
				colvarIdMedicamento.ColumnName = "idMedicamento";
				colvarIdMedicamento.DataType = DbType.Int32;
				colvarIdMedicamento.MaxLength = 0;
				colvarIdMedicamento.AutoIncrement = false;
				colvarIdMedicamento.IsNullable = false;
				colvarIdMedicamento.IsPrimaryKey = false;
				colvarIdMedicamento.IsForeignKey = true;
				colvarIdMedicamento.IsReadOnly = false;
				
						colvarIdMedicamento.DefaultSetting = @"((0))";
				
					colvarIdMedicamento.ForeignKeyTableName = "Sys_Medicamento";
				schema.Columns.Add(colvarIdMedicamento);
				
				TableSchema.TableColumn colvarIdClasificacion = new TableSchema.TableColumn(schema);
				colvarIdClasificacion.ColumnName = "idClasificacion";
				colvarIdClasificacion.DataType = DbType.Int32;
				colvarIdClasificacion.MaxLength = 0;
				colvarIdClasificacion.AutoIncrement = false;
				colvarIdClasificacion.IsNullable = false;
				colvarIdClasificacion.IsPrimaryKey = false;
				colvarIdClasificacion.IsForeignKey = true;
				colvarIdClasificacion.IsReadOnly = false;
				
						colvarIdClasificacion.DefaultSetting = @"((0))";
				
					colvarIdClasificacion.ForeignKeyTableName = "Rem_Clasificacion";
				schema.Columns.Add(colvarIdClasificacion);
				
				TableSchema.TableColumn colvarDosis = new TableSchema.TableColumn(schema);
				colvarDosis.ColumnName = "dosis";
				colvarDosis.DataType = DbType.Double;
				colvarDosis.MaxLength = 0;
				colvarDosis.AutoIncrement = false;
				colvarDosis.IsNullable = false;
				colvarDosis.IsPrimaryKey = false;
				colvarDosis.IsForeignKey = false;
				colvarDosis.IsReadOnly = false;
				
						colvarDosis.DefaultSetting = @"((0))";
				colvarDosis.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDosis);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_RelMedicamentoClasificacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelMedicamentoClasificacion")]
		[Bindable(true)]
		public int IdRelMedicamentoClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdRelMedicamentoClasificacion); }
			set { SetColumnValue(Columns.IdRelMedicamentoClasificacion, value); }
		}
		  
		[XmlAttribute("IdMedicamento")]
		[Bindable(true)]
		public int IdMedicamento 
		{
			get { return GetColumnValue<int>(Columns.IdMedicamento); }
			set { SetColumnValue(Columns.IdMedicamento, value); }
		}
		  
		[XmlAttribute("IdClasificacion")]
		[Bindable(true)]
		public int IdClasificacion 
		{
			get { return GetColumnValue<int>(Columns.IdClasificacion); }
			set { SetColumnValue(Columns.IdClasificacion, value); }
		}
		  
		[XmlAttribute("Dosis")]
		[Bindable(true)]
		public double Dosis 
		{
			get { return GetColumnValue<double>(Columns.Dosis); }
			set { SetColumnValue(Columns.Dosis, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysMedicamento ActiveRecord object related to this RemRelMedicamentoClasificacion
		/// 
		/// </summary>
		public DalSic.SysMedicamento SysMedicamento
		{
			get { return DalSic.SysMedicamento.FetchByID(this.IdMedicamento); }
			set { SetColumnValue("idMedicamento", value.IdMedicamento); }
		}
		
		
		/// <summary>
		/// Returns a RemClasificacion ActiveRecord object related to this RemRelMedicamentoClasificacion
		/// 
		/// </summary>
		public DalSic.RemClasificacion RemClasificacion
		{
			get { return DalSic.RemClasificacion.FetchByID(this.IdClasificacion); }
			set { SetColumnValue("idClasificacion", value.IdClasificacion); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdMedicamento,int varIdClasificacion,double varDosis)
		{
			RemRelMedicamentoClasificacion item = new RemRelMedicamentoClasificacion();
			
			item.IdMedicamento = varIdMedicamento;
			
			item.IdClasificacion = varIdClasificacion;
			
			item.Dosis = varDosis;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelMedicamentoClasificacion,int varIdMedicamento,int varIdClasificacion,double varDosis)
		{
			RemRelMedicamentoClasificacion item = new RemRelMedicamentoClasificacion();
			
				item.IdRelMedicamentoClasificacion = varIdRelMedicamentoClasificacion;
			
				item.IdMedicamento = varIdMedicamento;
			
				item.IdClasificacion = varIdClasificacion;
			
				item.Dosis = varDosis;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelMedicamentoClasificacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdMedicamentoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdClasificacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DosisColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelMedicamentoClasificacion = @"idRelMedicamentoClasificacion";
			 public static string IdMedicamento = @"idMedicamento";
			 public static string IdClasificacion = @"idClasificacion";
			 public static string Dosis = @"dosis";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
