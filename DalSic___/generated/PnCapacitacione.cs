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
	/// Strongly-typed collection for the PnCapacitacione class.
	/// </summary>
    [Serializable]
	public partial class PnCapacitacioneCollection : ActiveList<PnCapacitacione, PnCapacitacioneCollection>
	{	   
		public PnCapacitacioneCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCapacitacioneCollection</returns>
		public PnCapacitacioneCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCapacitacione o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_capacitaciones table.
	/// </summary>
	[Serializable]
	public partial class PnCapacitacione : ActiveRecord<PnCapacitacione>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCapacitacione()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCapacitacione(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCapacitacione(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCapacitacione(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_capacitaciones", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCapacitacion = new TableSchema.TableColumn(schema);
				colvarIdCapacitacion.ColumnName = "id_capacitacion";
				colvarIdCapacitacion.DataType = DbType.Int32;
				colvarIdCapacitacion.MaxLength = 0;
				colvarIdCapacitacion.AutoIncrement = true;
				colvarIdCapacitacion.IsNullable = false;
				colvarIdCapacitacion.IsPrimaryKey = true;
				colvarIdCapacitacion.IsForeignKey = false;
				colvarIdCapacitacion.IsReadOnly = false;
				colvarIdCapacitacion.DefaultSetting = @"";
				colvarIdCapacitacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCapacitacion);
				
				TableSchema.TableColumn colvarTema = new TableSchema.TableColumn(schema);
				colvarTema.ColumnName = "tema";
				colvarTema.DataType = DbType.AnsiString;
				colvarTema.MaxLength = -1;
				colvarTema.AutoIncrement = false;
				colvarTema.IsNullable = false;
				colvarTema.IsPrimaryKey = false;
				colvarTema.IsForeignKey = false;
				colvarTema.IsReadOnly = false;
				colvarTema.DefaultSetting = @"";
				colvarTema.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTema);
				
				TableSchema.TableColumn colvarDictado = new TableSchema.TableColumn(schema);
				colvarDictado.ColumnName = "dictado";
				colvarDictado.DataType = DbType.Int16;
				colvarDictado.MaxLength = 0;
				colvarDictado.AutoIncrement = false;
				colvarDictado.IsNullable = false;
				colvarDictado.IsPrimaryKey = false;
				colvarDictado.IsForeignKey = false;
				colvarDictado.IsReadOnly = false;
				colvarDictado.DefaultSetting = @"";
				colvarDictado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDictado);
				
				TableSchema.TableColumn colvarComentarios = new TableSchema.TableColumn(schema);
				colvarComentarios.ColumnName = "comentarios";
				colvarComentarios.DataType = DbType.AnsiString;
				colvarComentarios.MaxLength = -1;
				colvarComentarios.AutoIncrement = false;
				colvarComentarios.IsNullable = true;
				colvarComentarios.IsPrimaryKey = false;
				colvarComentarios.IsForeignKey = false;
				colvarComentarios.IsReadOnly = false;
				colvarComentarios.DefaultSetting = @"";
				colvarComentarios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentarios);
				
				TableSchema.TableColumn colvarDictadoDesde = new TableSchema.TableColumn(schema);
				colvarDictadoDesde.ColumnName = "dictado_desde";
				colvarDictadoDesde.DataType = DbType.DateTime;
				colvarDictadoDesde.MaxLength = 0;
				colvarDictadoDesde.AutoIncrement = false;
				colvarDictadoDesde.IsNullable = true;
				colvarDictadoDesde.IsPrimaryKey = false;
				colvarDictadoDesde.IsForeignKey = false;
				colvarDictadoDesde.IsReadOnly = false;
				colvarDictadoDesde.DefaultSetting = @"";
				colvarDictadoDesde.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDictadoDesde);
				
				TableSchema.TableColumn colvarDictadoHasta = new TableSchema.TableColumn(schema);
				colvarDictadoHasta.ColumnName = "dictado_hasta";
				colvarDictadoHasta.DataType = DbType.DateTime;
				colvarDictadoHasta.MaxLength = 0;
				colvarDictadoHasta.AutoIncrement = false;
				colvarDictadoHasta.IsNullable = true;
				colvarDictadoHasta.IsPrimaryKey = false;
				colvarDictadoHasta.IsForeignKey = false;
				colvarDictadoHasta.IsReadOnly = false;
				colvarDictadoHasta.DefaultSetting = @"";
				colvarDictadoHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDictadoHasta);
				
				TableSchema.TableColumn colvarLocacion = new TableSchema.TableColumn(schema);
				colvarLocacion.ColumnName = "locacion";
				colvarLocacion.DataType = DbType.Int16;
				colvarLocacion.MaxLength = 0;
				colvarLocacion.AutoIncrement = false;
				colvarLocacion.IsNullable = false;
				colvarLocacion.IsPrimaryKey = false;
				colvarLocacion.IsForeignKey = false;
				colvarLocacion.IsReadOnly = false;
				colvarLocacion.DefaultSetting = @"";
				colvarLocacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocacion);
				
				TableSchema.TableColumn colvarDictadoPor = new TableSchema.TableColumn(schema);
				colvarDictadoPor.ColumnName = "dictado_por";
				colvarDictadoPor.DataType = DbType.AnsiString;
				colvarDictadoPor.MaxLength = -1;
				colvarDictadoPor.AutoIncrement = false;
				colvarDictadoPor.IsNullable = true;
				colvarDictadoPor.IsPrimaryKey = false;
				colvarDictadoPor.IsForeignKey = false;
				colvarDictadoPor.IsReadOnly = false;
				colvarDictadoPor.DefaultSetting = @"";
				colvarDictadoPor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDictadoPor);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_capacitaciones",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCapacitacion")]
		[Bindable(true)]
		public int IdCapacitacion 
		{
			get { return GetColumnValue<int>(Columns.IdCapacitacion); }
			set { SetColumnValue(Columns.IdCapacitacion, value); }
		}
		  
		[XmlAttribute("Tema")]
		[Bindable(true)]
		public string Tema 
		{
			get { return GetColumnValue<string>(Columns.Tema); }
			set { SetColumnValue(Columns.Tema, value); }
		}
		  
		[XmlAttribute("Dictado")]
		[Bindable(true)]
		public short Dictado 
		{
			get { return GetColumnValue<short>(Columns.Dictado); }
			set { SetColumnValue(Columns.Dictado, value); }
		}
		  
		[XmlAttribute("Comentarios")]
		[Bindable(true)]
		public string Comentarios 
		{
			get { return GetColumnValue<string>(Columns.Comentarios); }
			set { SetColumnValue(Columns.Comentarios, value); }
		}
		  
		[XmlAttribute("DictadoDesde")]
		[Bindable(true)]
		public DateTime? DictadoDesde 
		{
			get { return GetColumnValue<DateTime?>(Columns.DictadoDesde); }
			set { SetColumnValue(Columns.DictadoDesde, value); }
		}
		  
		[XmlAttribute("DictadoHasta")]
		[Bindable(true)]
		public DateTime? DictadoHasta 
		{
			get { return GetColumnValue<DateTime?>(Columns.DictadoHasta); }
			set { SetColumnValue(Columns.DictadoHasta, value); }
		}
		  
		[XmlAttribute("Locacion")]
		[Bindable(true)]
		public short Locacion 
		{
			get { return GetColumnValue<short>(Columns.Locacion); }
			set { SetColumnValue(Columns.Locacion, value); }
		}
		  
		[XmlAttribute("DictadoPor")]
		[Bindable(true)]
		public string DictadoPor 
		{
			get { return GetColumnValue<string>(Columns.DictadoPor); }
			set { SetColumnValue(Columns.DictadoPor, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTema,short varDictado,string varComentarios,DateTime? varDictadoDesde,DateTime? varDictadoHasta,short varLocacion,string varDictadoPor)
		{
			PnCapacitacione item = new PnCapacitacione();
			
			item.Tema = varTema;
			
			item.Dictado = varDictado;
			
			item.Comentarios = varComentarios;
			
			item.DictadoDesde = varDictadoDesde;
			
			item.DictadoHasta = varDictadoHasta;
			
			item.Locacion = varLocacion;
			
			item.DictadoPor = varDictadoPor;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCapacitacion,string varTema,short varDictado,string varComentarios,DateTime? varDictadoDesde,DateTime? varDictadoHasta,short varLocacion,string varDictadoPor)
		{
			PnCapacitacione item = new PnCapacitacione();
			
				item.IdCapacitacion = varIdCapacitacion;
			
				item.Tema = varTema;
			
				item.Dictado = varDictado;
			
				item.Comentarios = varComentarios;
			
				item.DictadoDesde = varDictadoDesde;
			
				item.DictadoHasta = varDictadoHasta;
			
				item.Locacion = varLocacion;
			
				item.DictadoPor = varDictadoPor;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCapacitacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TemaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DictadoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentariosColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DictadoDesdeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DictadoHastaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn LocacionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DictadoPorColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCapacitacion = @"id_capacitacion";
			 public static string Tema = @"tema";
			 public static string Dictado = @"dictado";
			 public static string Comentarios = @"comentarios";
			 public static string DictadoDesde = @"dictado_desde";
			 public static string DictadoHasta = @"dictado_hasta";
			 public static string Locacion = @"locacion";
			 public static string DictadoPor = @"dictado_por";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
