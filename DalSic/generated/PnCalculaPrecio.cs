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
	/// Strongly-typed collection for the PnCalculaPrecio class.
	/// </summary>
    [Serializable]
	public partial class PnCalculaPrecioCollection : ActiveList<PnCalculaPrecio, PnCalculaPrecioCollection>
	{	   
		public PnCalculaPrecioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnCalculaPrecioCollection</returns>
		public PnCalculaPrecioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnCalculaPrecio o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_calcula_precio table.
	/// </summary>
	[Serializable]
	public partial class PnCalculaPrecio : ActiveRecord<PnCalculaPrecio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnCalculaPrecio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnCalculaPrecio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnCalculaPrecio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnCalculaPrecio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_calcula_precio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCalculaPrecio = new TableSchema.TableColumn(schema);
				colvarIdCalculaPrecio.ColumnName = "id_calcula_precio";
				colvarIdCalculaPrecio.DataType = DbType.Int32;
				colvarIdCalculaPrecio.MaxLength = 0;
				colvarIdCalculaPrecio.AutoIncrement = true;
				colvarIdCalculaPrecio.IsNullable = false;
				colvarIdCalculaPrecio.IsPrimaryKey = true;
				colvarIdCalculaPrecio.IsForeignKey = false;
				colvarIdCalculaPrecio.IsReadOnly = false;
				colvarIdCalculaPrecio.DefaultSetting = @"";
				colvarIdCalculaPrecio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCalculaPrecio);
				
				TableSchema.TableColumn colvarPracticaVincula = new TableSchema.TableColumn(schema);
				colvarPracticaVincula.ColumnName = "practica_vincula";
				colvarPracticaVincula.DataType = DbType.AnsiStringFixedLength;
				colvarPracticaVincula.MaxLength = 5;
				colvarPracticaVincula.AutoIncrement = false;
				colvarPracticaVincula.IsNullable = true;
				colvarPracticaVincula.IsPrimaryKey = false;
				colvarPracticaVincula.IsForeignKey = false;
				colvarPracticaVincula.IsReadOnly = false;
				colvarPracticaVincula.DefaultSetting = @"";
				colvarPracticaVincula.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPracticaVincula);
				
				TableSchema.TableColumn colvarObjPrestacionVincula = new TableSchema.TableColumn(schema);
				colvarObjPrestacionVincula.ColumnName = "obj_prestacion_vincula";
				colvarObjPrestacionVincula.DataType = DbType.AnsiStringFixedLength;
				colvarObjPrestacionVincula.MaxLength = 5;
				colvarObjPrestacionVincula.AutoIncrement = false;
				colvarObjPrestacionVincula.IsNullable = false;
				colvarObjPrestacionVincula.IsPrimaryKey = false;
				colvarObjPrestacionVincula.IsForeignKey = false;
				colvarObjPrestacionVincula.IsReadOnly = false;
				colvarObjPrestacionVincula.DefaultSetting = @"";
				colvarObjPrestacionVincula.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObjPrestacionVincula);
				
				TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
				colvarDiagnostico.ColumnName = "diagnostico";
				colvarDiagnostico.DataType = DbType.AnsiStringFixedLength;
				colvarDiagnostico.MaxLength = 5;
				colvarDiagnostico.AutoIncrement = false;
				colvarDiagnostico.IsNullable = true;
				colvarDiagnostico.IsPrimaryKey = false;
				colvarDiagnostico.IsForeignKey = false;
				colvarDiagnostico.IsReadOnly = false;
				colvarDiagnostico.DefaultSetting = @"";
				colvarDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnostico);
				
				TableSchema.TableColumn colvarGrupoEtareo = new TableSchema.TableColumn(schema);
				colvarGrupoEtareo.ColumnName = "grupo_etareo";
				colvarGrupoEtareo.DataType = DbType.AnsiString;
				colvarGrupoEtareo.MaxLength = -1;
				colvarGrupoEtareo.AutoIncrement = false;
				colvarGrupoEtareo.IsNullable = false;
				colvarGrupoEtareo.IsPrimaryKey = false;
				colvarGrupoEtareo.IsForeignKey = false;
				colvarGrupoEtareo.IsReadOnly = false;
				colvarGrupoEtareo.DefaultSetting = @"";
				colvarGrupoEtareo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupoEtareo);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.AnsiStringFixedLength;
				colvarSexo.MaxLength = 1;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = false;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_calcula_precio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCalculaPrecio")]
		[Bindable(true)]
		public int IdCalculaPrecio 
		{
			get { return GetColumnValue<int>(Columns.IdCalculaPrecio); }
			set { SetColumnValue(Columns.IdCalculaPrecio, value); }
		}
		  
		[XmlAttribute("PracticaVincula")]
		[Bindable(true)]
		public string PracticaVincula 
		{
			get { return GetColumnValue<string>(Columns.PracticaVincula); }
			set { SetColumnValue(Columns.PracticaVincula, value); }
		}
		  
		[XmlAttribute("ObjPrestacionVincula")]
		[Bindable(true)]
		public string ObjPrestacionVincula 
		{
			get { return GetColumnValue<string>(Columns.ObjPrestacionVincula); }
			set { SetColumnValue(Columns.ObjPrestacionVincula, value); }
		}
		  
		[XmlAttribute("Diagnostico")]
		[Bindable(true)]
		public string Diagnostico 
		{
			get { return GetColumnValue<string>(Columns.Diagnostico); }
			set { SetColumnValue(Columns.Diagnostico, value); }
		}
		  
		[XmlAttribute("GrupoEtareo")]
		[Bindable(true)]
		public string GrupoEtareo 
		{
			get { return GetColumnValue<string>(Columns.GrupoEtareo); }
			set { SetColumnValue(Columns.GrupoEtareo, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varPracticaVincula,string varObjPrestacionVincula,string varDiagnostico,string varGrupoEtareo,string varSexo)
		{
			PnCalculaPrecio item = new PnCalculaPrecio();
			
			item.PracticaVincula = varPracticaVincula;
			
			item.ObjPrestacionVincula = varObjPrestacionVincula;
			
			item.Diagnostico = varDiagnostico;
			
			item.GrupoEtareo = varGrupoEtareo;
			
			item.Sexo = varSexo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCalculaPrecio,string varPracticaVincula,string varObjPrestacionVincula,string varDiagnostico,string varGrupoEtareo,string varSexo)
		{
			PnCalculaPrecio item = new PnCalculaPrecio();
			
				item.IdCalculaPrecio = varIdCalculaPrecio;
			
				item.PracticaVincula = varPracticaVincula;
			
				item.ObjPrestacionVincula = varObjPrestacionVincula;
			
				item.Diagnostico = varDiagnostico;
			
				item.GrupoEtareo = varGrupoEtareo;
			
				item.Sexo = varSexo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCalculaPrecioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PracticaVinculaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ObjPrestacionVinculaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoEtareoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCalculaPrecio = @"id_calcula_precio";
			 public static string PracticaVincula = @"practica_vincula";
			 public static string ObjPrestacionVincula = @"obj_prestacion_vincula";
			 public static string Diagnostico = @"diagnostico";
			 public static string GrupoEtareo = @"grupo_etareo";
			 public static string Sexo = @"sexo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
