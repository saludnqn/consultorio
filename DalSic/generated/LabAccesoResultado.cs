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
	/// Strongly-typed collection for the LabAccesoResultado class.
	/// </summary>
    [Serializable]
	public partial class LabAccesoResultadoCollection : ActiveList<LabAccesoResultado, LabAccesoResultadoCollection>
	{	   
		public LabAccesoResultadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabAccesoResultadoCollection</returns>
		public LabAccesoResultadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabAccesoResultado o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_AccesoResultado table.
	/// </summary>
	[Serializable]
	public partial class LabAccesoResultado : ActiveRecord<LabAccesoResultado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabAccesoResultado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabAccesoResultado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabAccesoResultado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabAccesoResultado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_AccesoResultado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAccesoResultado = new TableSchema.TableColumn(schema);
				colvarIdAccesoResultado.ColumnName = "idAccesoResultado";
				colvarIdAccesoResultado.DataType = DbType.Int32;
				colvarIdAccesoResultado.MaxLength = 0;
				colvarIdAccesoResultado.AutoIncrement = true;
				colvarIdAccesoResultado.IsNullable = false;
				colvarIdAccesoResultado.IsPrimaryKey = true;
				colvarIdAccesoResultado.IsForeignKey = false;
				colvarIdAccesoResultado.IsReadOnly = false;
				colvarIdAccesoResultado.DefaultSetting = @"";
				colvarIdAccesoResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAccesoResultado);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "idUsuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
				colvarNumeroDocumento.ColumnName = "numeroDocumento";
				colvarNumeroDocumento.DataType = DbType.Int32;
				colvarNumeroDocumento.MaxLength = 0;
				colvarNumeroDocumento.AutoIncrement = false;
				colvarNumeroDocumento.IsNullable = false;
				colvarNumeroDocumento.IsPrimaryKey = false;
				colvarNumeroDocumento.IsForeignKey = false;
				colvarNumeroDocumento.IsReadOnly = false;
				colvarNumeroDocumento.DefaultSetting = @"";
				colvarNumeroDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDocumento);
				
				TableSchema.TableColumn colvarNumeroProtocolo = new TableSchema.TableColumn(schema);
				colvarNumeroProtocolo.ColumnName = "numeroProtocolo";
				colvarNumeroProtocolo.DataType = DbType.AnsiString;
				colvarNumeroProtocolo.MaxLength = 50;
				colvarNumeroProtocolo.AutoIncrement = false;
				colvarNumeroProtocolo.IsNullable = false;
				colvarNumeroProtocolo.IsPrimaryKey = false;
				colvarNumeroProtocolo.IsForeignKey = false;
				colvarNumeroProtocolo.IsReadOnly = false;
				colvarNumeroProtocolo.DefaultSetting = @"";
				colvarNumeroProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroProtocolo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_AccesoResultado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAccesoResultado")]
		[Bindable(true)]
		public int IdAccesoResultado 
		{
			get { return GetColumnValue<int>(Columns.IdAccesoResultado); }
			set { SetColumnValue(Columns.IdAccesoResultado, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("NumeroDocumento")]
		[Bindable(true)]
		public int NumeroDocumento 
		{
			get { return GetColumnValue<int>(Columns.NumeroDocumento); }
			set { SetColumnValue(Columns.NumeroDocumento, value); }
		}
		  
		[XmlAttribute("NumeroProtocolo")]
		[Bindable(true)]
		public string NumeroProtocolo 
		{
			get { return GetColumnValue<string>(Columns.NumeroProtocolo); }
			set { SetColumnValue(Columns.NumeroProtocolo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdUsuario,DateTime varFecha,int varNumeroDocumento,string varNumeroProtocolo)
		{
			LabAccesoResultado item = new LabAccesoResultado();
			
			item.IdUsuario = varIdUsuario;
			
			item.Fecha = varFecha;
			
			item.NumeroDocumento = varNumeroDocumento;
			
			item.NumeroProtocolo = varNumeroProtocolo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAccesoResultado,int varIdUsuario,DateTime varFecha,int varNumeroDocumento,string varNumeroProtocolo)
		{
			LabAccesoResultado item = new LabAccesoResultado();
			
				item.IdAccesoResultado = varIdAccesoResultado;
			
				item.IdUsuario = varIdUsuario;
			
				item.Fecha = varFecha;
			
				item.NumeroDocumento = varNumeroDocumento;
			
				item.NumeroProtocolo = varNumeroProtocolo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAccesoResultadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocumentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroProtocoloColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAccesoResultado = @"idAccesoResultado";
			 public static string IdUsuario = @"idUsuario";
			 public static string Fecha = @"fecha";
			 public static string NumeroDocumento = @"numeroDocumento";
			 public static string NumeroProtocolo = @"numeroProtocolo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
