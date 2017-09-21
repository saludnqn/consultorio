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
	/// Strongly-typed collection for the PnAsistencium class.
	/// </summary>
    [Serializable]
	public partial class PnAsistenciumCollection : ActiveList<PnAsistencium, PnAsistenciumCollection>
	{	   
		public PnAsistenciumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnAsistenciumCollection</returns>
		public PnAsistenciumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnAsistencium o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_asistencia table.
	/// </summary>
	[Serializable]
	public partial class PnAsistencium : ActiveRecord<PnAsistencium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnAsistencium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnAsistencium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnAsistencium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnAsistencium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_asistencia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAsistencia = new TableSchema.TableColumn(schema);
				colvarIdAsistencia.ColumnName = "id_asistencia";
				colvarIdAsistencia.DataType = DbType.Int32;
				colvarIdAsistencia.MaxLength = 0;
				colvarIdAsistencia.AutoIncrement = true;
				colvarIdAsistencia.IsNullable = false;
				colvarIdAsistencia.IsPrimaryKey = true;
				colvarIdAsistencia.IsForeignKey = false;
				colvarIdAsistencia.IsReadOnly = false;
				colvarIdAsistencia.DefaultSetting = @"";
				colvarIdAsistencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAsistencia);
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = false;
				colvarIdLegajo.IsNullable = true;
				colvarIdLegajo.IsPrimaryKey = false;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = true;
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
				
				TableSchema.TableColumn colvarHoraEntra = new TableSchema.TableColumn(schema);
				colvarHoraEntra.ColumnName = "hora_entra";
				colvarHoraEntra.DataType = DbType.AnsiString;
				colvarHoraEntra.MaxLength = 16;
				colvarHoraEntra.AutoIncrement = false;
				colvarHoraEntra.IsNullable = false;
				colvarHoraEntra.IsPrimaryKey = false;
				colvarHoraEntra.IsForeignKey = false;
				colvarHoraEntra.IsReadOnly = false;
				colvarHoraEntra.DefaultSetting = @"";
				colvarHoraEntra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraEntra);
				
				TableSchema.TableColumn colvarHoraSale = new TableSchema.TableColumn(schema);
				colvarHoraSale.ColumnName = "hora_sale";
				colvarHoraSale.DataType = DbType.AnsiString;
				colvarHoraSale.MaxLength = 16;
				colvarHoraSale.AutoIncrement = false;
				colvarHoraSale.IsNullable = true;
				colvarHoraSale.IsPrimaryKey = false;
				colvarHoraSale.IsForeignKey = false;
				colvarHoraSale.IsReadOnly = false;
				colvarHoraSale.DefaultSetting = @"";
				colvarHoraSale.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraSale);
				
				TableSchema.TableColumn colvarIdServidor = new TableSchema.TableColumn(schema);
				colvarIdServidor.ColumnName = "id_servidor";
				colvarIdServidor.DataType = DbType.Int32;
				colvarIdServidor.MaxLength = 0;
				colvarIdServidor.AutoIncrement = false;
				colvarIdServidor.IsNullable = true;
				colvarIdServidor.IsPrimaryKey = false;
				colvarIdServidor.IsForeignKey = false;
				colvarIdServidor.IsReadOnly = false;
				colvarIdServidor.DefaultSetting = @"";
				colvarIdServidor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdServidor);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_asistencia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAsistencia")]
		[Bindable(true)]
		public int IdAsistencia 
		{
			get { return GetColumnValue<int>(Columns.IdAsistencia); }
			set { SetColumnValue(Columns.IdAsistencia, value); }
		}
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int? IdLegajo 
		{
			get { return GetColumnValue<int?>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int? IdUsuario 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("HoraEntra")]
		[Bindable(true)]
		public string HoraEntra 
		{
			get { return GetColumnValue<string>(Columns.HoraEntra); }
			set { SetColumnValue(Columns.HoraEntra, value); }
		}
		  
		[XmlAttribute("HoraSale")]
		[Bindable(true)]
		public string HoraSale 
		{
			get { return GetColumnValue<string>(Columns.HoraSale); }
			set { SetColumnValue(Columns.HoraSale, value); }
		}
		  
		[XmlAttribute("IdServidor")]
		[Bindable(true)]
		public int? IdServidor 
		{
			get { return GetColumnValue<int?>(Columns.IdServidor); }
			set { SetColumnValue(Columns.IdServidor, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdLegajo,int? varIdUsuario,DateTime varFecha,string varHoraEntra,string varHoraSale,int? varIdServidor)
		{
			PnAsistencium item = new PnAsistencium();
			
			item.IdLegajo = varIdLegajo;
			
			item.IdUsuario = varIdUsuario;
			
			item.Fecha = varFecha;
			
			item.HoraEntra = varHoraEntra;
			
			item.HoraSale = varHoraSale;
			
			item.IdServidor = varIdServidor;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAsistencia,int? varIdLegajo,int? varIdUsuario,DateTime varFecha,string varHoraEntra,string varHoraSale,int? varIdServidor)
		{
			PnAsistencium item = new PnAsistencium();
			
				item.IdAsistencia = varIdAsistencia;
			
				item.IdLegajo = varIdLegajo;
			
				item.IdUsuario = varIdUsuario;
			
				item.Fecha = varFecha;
			
				item.HoraEntra = varHoraEntra;
			
				item.HoraSale = varHoraSale;
			
				item.IdServidor = varIdServidor;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAsistenciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraEntraColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraSaleColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdServidorColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAsistencia = @"id_asistencia";
			 public static string IdLegajo = @"id_legajo";
			 public static string IdUsuario = @"id_usuario";
			 public static string Fecha = @"fecha";
			 public static string HoraEntra = @"hora_entra";
			 public static string HoraSale = @"hora_sale";
			 public static string IdServidor = @"id_servidor";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
