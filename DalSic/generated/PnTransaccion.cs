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
	/// Strongly-typed collection for the PnTransaccion class.
	/// </summary>
    [Serializable]
	public partial class PnTransaccionCollection : ActiveList<PnTransaccion, PnTransaccionCollection>
	{	   
		public PnTransaccionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTransaccionCollection</returns>
		public PnTransaccionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTransaccion o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_transaccion table.
	/// </summary>
	[Serializable]
	public partial class PnTransaccion : ActiveRecord<PnTransaccion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTransaccion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTransaccion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTransaccion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTransaccion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_transaccion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTransac = new TableSchema.TableColumn(schema);
				colvarIdTransac.ColumnName = "id_transac";
				colvarIdTransac.DataType = DbType.Int32;
				colvarIdTransac.MaxLength = 0;
				colvarIdTransac.AutoIncrement = true;
				colvarIdTransac.IsNullable = false;
				colvarIdTransac.IsPrimaryKey = true;
				colvarIdTransac.IsForeignKey = false;
				colvarIdTransac.IsReadOnly = false;
				colvarIdTransac.DefaultSetting = @"";
				colvarIdTransac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTransac);
				
				TableSchema.TableColumn colvarIdExpediente = new TableSchema.TableColumn(schema);
				colvarIdExpediente.ColumnName = "id_expediente";
				colvarIdExpediente.DataType = DbType.Int64;
				colvarIdExpediente.MaxLength = 0;
				colvarIdExpediente.AutoIncrement = false;
				colvarIdExpediente.IsNullable = false;
				colvarIdExpediente.IsPrimaryKey = false;
				colvarIdExpediente.IsForeignKey = false;
				colvarIdExpediente.IsReadOnly = false;
				colvarIdExpediente.DefaultSetting = @"";
				colvarIdExpediente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExpediente);
				
				TableSchema.TableColumn colvarIdArea = new TableSchema.TableColumn(schema);
				colvarIdArea.ColumnName = "id_area";
				colvarIdArea.DataType = DbType.Int32;
				colvarIdArea.MaxLength = 0;
				colvarIdArea.AutoIncrement = false;
				colvarIdArea.IsNullable = false;
				colvarIdArea.IsPrimaryKey = false;
				colvarIdArea.IsForeignKey = false;
				colvarIdArea.IsReadOnly = false;
				colvarIdArea.DefaultSetting = @"";
				colvarIdArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdArea);
				
				TableSchema.TableColumn colvarFechaMov = new TableSchema.TableColumn(schema);
				colvarFechaMov.ColumnName = "fecha_mov";
				colvarFechaMov.DataType = DbType.DateTime;
				colvarFechaMov.MaxLength = 0;
				colvarFechaMov.AutoIncrement = false;
				colvarFechaMov.IsNullable = true;
				colvarFechaMov.IsPrimaryKey = false;
				colvarFechaMov.IsForeignKey = false;
				colvarFechaMov.IsReadOnly = false;
				colvarFechaMov.DefaultSetting = @"";
				colvarFechaMov.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaMov);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.AnsiStringFixedLength;
				colvarEstado.MaxLength = 1;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				colvarEstado.DefaultSetting = @"";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = -1;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarDebCred = new TableSchema.TableColumn(schema);
				colvarDebCred.ColumnName = "deb_cred";
				colvarDebCred.DataType = DbType.Int32;
				colvarDebCred.MaxLength = 0;
				colvarDebCred.AutoIncrement = false;
				colvarDebCred.IsNullable = true;
				colvarDebCred.IsPrimaryKey = false;
				colvarDebCred.IsForeignKey = false;
				colvarDebCred.IsReadOnly = false;
				colvarDebCred.DefaultSetting = @"";
				colvarDebCred.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDebCred);
				
				TableSchema.TableColumn colvarNumTranf = new TableSchema.TableColumn(schema);
				colvarNumTranf.ColumnName = "num_tranf";
				colvarNumTranf.DataType = DbType.Int64;
				colvarNumTranf.MaxLength = 0;
				colvarNumTranf.AutoIncrement = false;
				colvarNumTranf.IsNullable = true;
				colvarNumTranf.IsPrimaryKey = false;
				colvarNumTranf.IsForeignKey = false;
				colvarNumTranf.IsReadOnly = false;
				colvarNumTranf.DefaultSetting = @"";
				colvarNumTranf.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumTranf);
				
				TableSchema.TableColumn colvarFechaInf = new TableSchema.TableColumn(schema);
				colvarFechaInf.ColumnName = "fecha_inf";
				colvarFechaInf.DataType = DbType.DateTime;
				colvarFechaInf.MaxLength = 0;
				colvarFechaInf.AutoIncrement = false;
				colvarFechaInf.IsNullable = true;
				colvarFechaInf.IsPrimaryKey = false;
				colvarFechaInf.IsForeignKey = false;
				colvarFechaInf.IsReadOnly = false;
				colvarFechaInf.DefaultSetting = @"";
				colvarFechaInf.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInf);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_transaccion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTransac")]
		[Bindable(true)]
		public int IdTransac 
		{
			get { return GetColumnValue<int>(Columns.IdTransac); }
			set { SetColumnValue(Columns.IdTransac, value); }
		}
		  
		[XmlAttribute("IdExpediente")]
		[Bindable(true)]
		public long IdExpediente 
		{
			get { return GetColumnValue<long>(Columns.IdExpediente); }
			set { SetColumnValue(Columns.IdExpediente, value); }
		}
		  
		[XmlAttribute("IdArea")]
		[Bindable(true)]
		public int IdArea 
		{
			get { return GetColumnValue<int>(Columns.IdArea); }
			set { SetColumnValue(Columns.IdArea, value); }
		}
		  
		[XmlAttribute("FechaMov")]
		[Bindable(true)]
		public DateTime? FechaMov 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaMov); }
			set { SetColumnValue(Columns.FechaMov, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public string Estado 
		{
			get { return GetColumnValue<string>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("DebCred")]
		[Bindable(true)]
		public int? DebCred 
		{
			get { return GetColumnValue<int?>(Columns.DebCred); }
			set { SetColumnValue(Columns.DebCred, value); }
		}
		  
		[XmlAttribute("NumTranf")]
		[Bindable(true)]
		public long? NumTranf 
		{
			get { return GetColumnValue<long?>(Columns.NumTranf); }
			set { SetColumnValue(Columns.NumTranf, value); }
		}
		  
		[XmlAttribute("FechaInf")]
		[Bindable(true)]
		public DateTime? FechaInf 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaInf); }
			set { SetColumnValue(Columns.FechaInf, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(long varIdExpediente,int varIdArea,DateTime? varFechaMov,string varEstado,string varComentario,int? varDebCred,long? varNumTranf,DateTime? varFechaInf)
		{
			PnTransaccion item = new PnTransaccion();
			
			item.IdExpediente = varIdExpediente;
			
			item.IdArea = varIdArea;
			
			item.FechaMov = varFechaMov;
			
			item.Estado = varEstado;
			
			item.Comentario = varComentario;
			
			item.DebCred = varDebCred;
			
			item.NumTranf = varNumTranf;
			
			item.FechaInf = varFechaInf;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTransac,long varIdExpediente,int varIdArea,DateTime? varFechaMov,string varEstado,string varComentario,int? varDebCred,long? varNumTranf,DateTime? varFechaInf)
		{
			PnTransaccion item = new PnTransaccion();
			
				item.IdTransac = varIdTransac;
			
				item.IdExpediente = varIdExpediente;
			
				item.IdArea = varIdArea;
			
				item.FechaMov = varFechaMov;
			
				item.Estado = varEstado;
			
				item.Comentario = varComentario;
			
				item.DebCred = varDebCred;
			
				item.NumTranf = varNumTranf;
			
				item.FechaInf = varFechaInf;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTransacColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExpedienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAreaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaMovColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DebCredColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NumTranfColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInfColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTransac = @"id_transac";
			 public static string IdExpediente = @"id_expediente";
			 public static string IdArea = @"id_area";
			 public static string FechaMov = @"fecha_mov";
			 public static string Estado = @"estado";
			 public static string Comentario = @"comentario";
			 public static string DebCred = @"deb_cred";
			 public static string NumTranf = @"num_tranf";
			 public static string FechaInf = @"fecha_inf";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
