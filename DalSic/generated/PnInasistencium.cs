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
	/// Strongly-typed collection for the PnInasistencium class.
	/// </summary>
    [Serializable]
	public partial class PnInasistenciumCollection : ActiveList<PnInasistencium, PnInasistenciumCollection>
	{	   
		public PnInasistenciumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnInasistenciumCollection</returns>
		public PnInasistenciumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnInasistencium o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_inasistencia table.
	/// </summary>
	[Serializable]
	public partial class PnInasistencium : ActiveRecord<PnInasistencium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnInasistencium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnInasistencium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnInasistencium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnInasistencium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_inasistencia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdInasistencia = new TableSchema.TableColumn(schema);
				colvarIdInasistencia.ColumnName = "id_inasistencia";
				colvarIdInasistencia.DataType = DbType.Int32;
				colvarIdInasistencia.MaxLength = 0;
				colvarIdInasistencia.AutoIncrement = true;
				colvarIdInasistencia.IsNullable = false;
				colvarIdInasistencia.IsPrimaryKey = true;
				colvarIdInasistencia.IsForeignKey = false;
				colvarIdInasistencia.IsReadOnly = false;
				colvarIdInasistencia.DefaultSetting = @"";
				colvarIdInasistencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInasistencia);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
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
				
				TableSchema.TableColumn colvarTipoJustificacion = new TableSchema.TableColumn(schema);
				colvarTipoJustificacion.ColumnName = "tipo_justificacion";
				colvarTipoJustificacion.DataType = DbType.Int16;
				colvarTipoJustificacion.MaxLength = 0;
				colvarTipoJustificacion.AutoIncrement = false;
				colvarTipoJustificacion.IsNullable = true;
				colvarTipoJustificacion.IsPrimaryKey = false;
				colvarTipoJustificacion.IsForeignKey = false;
				colvarTipoJustificacion.IsReadOnly = false;
				colvarTipoJustificacion.DefaultSetting = @"";
				colvarTipoJustificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoJustificacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_inasistencia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdInasistencia")]
		[Bindable(true)]
		public int IdInasistencia 
		{
			get { return GetColumnValue<int>(Columns.IdInasistencia); }
			set { SetColumnValue(Columns.IdInasistencia, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("TipoJustificacion")]
		[Bindable(true)]
		public short? TipoJustificacion 
		{
			get { return GetColumnValue<short?>(Columns.TipoJustificacion); }
			set { SetColumnValue(Columns.TipoJustificacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdUsuario,string varComentario,DateTime? varFecha,short? varTipoJustificacion)
		{
			PnInasistencium item = new PnInasistencium();
			
			item.IdUsuario = varIdUsuario;
			
			item.Comentario = varComentario;
			
			item.Fecha = varFecha;
			
			item.TipoJustificacion = varTipoJustificacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdInasistencia,int varIdUsuario,string varComentario,DateTime? varFecha,short? varTipoJustificacion)
		{
			PnInasistencium item = new PnInasistencium();
			
				item.IdInasistencia = varIdInasistencia;
			
				item.IdUsuario = varIdUsuario;
			
				item.Comentario = varComentario;
			
				item.Fecha = varFecha;
			
				item.TipoJustificacion = varTipoJustificacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdInasistenciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoJustificacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdInasistencia = @"id_inasistencia";
			 public static string IdUsuario = @"id_usuario";
			 public static string Comentario = @"comentario";
			 public static string Fecha = @"fecha";
			 public static string TipoJustificacion = @"tipo_justificacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
