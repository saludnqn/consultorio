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
	/// Strongly-typed collection for the PnTrzPre class.
	/// </summary>
    [Serializable]
	public partial class PnTrzPreCollection : ActiveList<PnTrzPre, PnTrzPreCollection>
	{	   
		public PnTrzPreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnTrzPreCollection</returns>
		public PnTrzPreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnTrzPre o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_trz_pres table.
	/// </summary>
	[Serializable]
	public partial class PnTrzPre : ActiveRecord<PnTrzPre>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnTrzPre()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnTrzPre(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnTrzPre(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnTrzPre(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_trz_pres", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTrzPres = new TableSchema.TableColumn(schema);
				colvarIdTrzPres.ColumnName = "id_trz_pres";
				colvarIdTrzPres.DataType = DbType.Int32;
				colvarIdTrzPres.MaxLength = 0;
				colvarIdTrzPres.AutoIncrement = true;
				colvarIdTrzPres.IsNullable = false;
				colvarIdTrzPres.IsPrimaryKey = true;
				colvarIdTrzPres.IsForeignKey = false;
				colvarIdTrzPres.IsReadOnly = false;
				colvarIdTrzPres.DefaultSetting = @"";
				colvarIdTrzPres.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTrzPres);
				
				TableSchema.TableColumn colvarTextoBoton = new TableSchema.TableColumn(schema);
				colvarTextoBoton.ColumnName = "texto_boton";
				colvarTextoBoton.DataType = DbType.AnsiString;
				colvarTextoBoton.MaxLength = -1;
				colvarTextoBoton.AutoIncrement = false;
				colvarTextoBoton.IsNullable = false;
				colvarTextoBoton.IsPrimaryKey = false;
				colvarTextoBoton.IsForeignKey = false;
				colvarTextoBoton.IsReadOnly = false;
				colvarTextoBoton.DefaultSetting = @"";
				colvarTextoBoton.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTextoBoton);
				
				TableSchema.TableColumn colvarTrzVincula = new TableSchema.TableColumn(schema);
				colvarTrzVincula.ColumnName = "trz_vincula";
				colvarTrzVincula.DataType = DbType.AnsiString;
				colvarTrzVincula.MaxLength = -1;
				colvarTrzVincula.AutoIncrement = false;
				colvarTrzVincula.IsNullable = false;
				colvarTrzVincula.IsPrimaryKey = false;
				colvarTrzVincula.IsForeignKey = false;
				colvarTrzVincula.IsReadOnly = false;
				colvarTrzVincula.DefaultSetting = @"";
				colvarTrzVincula.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrzVincula);
				
				TableSchema.TableColumn colvarPaginaDestino = new TableSchema.TableColumn(schema);
				colvarPaginaDestino.ColumnName = "pagina_destino";
				colvarPaginaDestino.DataType = DbType.AnsiString;
				colvarPaginaDestino.MaxLength = -1;
				colvarPaginaDestino.AutoIncrement = false;
				colvarPaginaDestino.IsNullable = false;
				colvarPaginaDestino.IsPrimaryKey = false;
				colvarPaginaDestino.IsForeignKey = false;
				colvarPaginaDestino.IsReadOnly = false;
				colvarPaginaDestino.DefaultSetting = @"";
				colvarPaginaDestino.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaginaDestino);
				
				TableSchema.TableColumn colvarParamPaginaDestino = new TableSchema.TableColumn(schema);
				colvarParamPaginaDestino.ColumnName = "param_pagina_destino";
				colvarParamPaginaDestino.DataType = DbType.AnsiString;
				colvarParamPaginaDestino.MaxLength = -1;
				colvarParamPaginaDestino.AutoIncrement = false;
				colvarParamPaginaDestino.IsNullable = false;
				colvarParamPaginaDestino.IsPrimaryKey = false;
				colvarParamPaginaDestino.IsForeignKey = false;
				colvarParamPaginaDestino.IsReadOnly = false;
				colvarParamPaginaDestino.DefaultSetting = @"";
				colvarParamPaginaDestino.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParamPaginaDestino);
				
				TableSchema.TableColumn colvarObligaEfector = new TableSchema.TableColumn(schema);
				colvarObligaEfector.ColumnName = "obliga_efector";
				colvarObligaEfector.DataType = DbType.AnsiStringFixedLength;
				colvarObligaEfector.MaxLength = 1;
				colvarObligaEfector.AutoIncrement = false;
				colvarObligaEfector.IsNullable = false;
				colvarObligaEfector.IsPrimaryKey = false;
				colvarObligaEfector.IsForeignKey = false;
				colvarObligaEfector.IsReadOnly = false;
				colvarObligaEfector.DefaultSetting = @"";
				colvarObligaEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObligaEfector);
				
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
				DataService.Providers["sicProvider"].AddSchema("PN_trz_pres",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTrzPres")]
		[Bindable(true)]
		public int IdTrzPres 
		{
			get { return GetColumnValue<int>(Columns.IdTrzPres); }
			set { SetColumnValue(Columns.IdTrzPres, value); }
		}
		  
		[XmlAttribute("TextoBoton")]
		[Bindable(true)]
		public string TextoBoton 
		{
			get { return GetColumnValue<string>(Columns.TextoBoton); }
			set { SetColumnValue(Columns.TextoBoton, value); }
		}
		  
		[XmlAttribute("TrzVincula")]
		[Bindable(true)]
		public string TrzVincula 
		{
			get { return GetColumnValue<string>(Columns.TrzVincula); }
			set { SetColumnValue(Columns.TrzVincula, value); }
		}
		  
		[XmlAttribute("PaginaDestino")]
		[Bindable(true)]
		public string PaginaDestino 
		{
			get { return GetColumnValue<string>(Columns.PaginaDestino); }
			set { SetColumnValue(Columns.PaginaDestino, value); }
		}
		  
		[XmlAttribute("ParamPaginaDestino")]
		[Bindable(true)]
		public string ParamPaginaDestino 
		{
			get { return GetColumnValue<string>(Columns.ParamPaginaDestino); }
			set { SetColumnValue(Columns.ParamPaginaDestino, value); }
		}
		  
		[XmlAttribute("ObligaEfector")]
		[Bindable(true)]
		public string ObligaEfector 
		{
			get { return GetColumnValue<string>(Columns.ObligaEfector); }
			set { SetColumnValue(Columns.ObligaEfector, value); }
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
		public static void Insert(string varTextoBoton,string varTrzVincula,string varPaginaDestino,string varParamPaginaDestino,string varObligaEfector,string varPracticaVincula,string varObjPrestacionVincula,string varDiagnostico,string varGrupoEtareo,string varSexo)
		{
			PnTrzPre item = new PnTrzPre();
			
			item.TextoBoton = varTextoBoton;
			
			item.TrzVincula = varTrzVincula;
			
			item.PaginaDestino = varPaginaDestino;
			
			item.ParamPaginaDestino = varParamPaginaDestino;
			
			item.ObligaEfector = varObligaEfector;
			
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
		public static void Update(int varIdTrzPres,string varTextoBoton,string varTrzVincula,string varPaginaDestino,string varParamPaginaDestino,string varObligaEfector,string varPracticaVincula,string varObjPrestacionVincula,string varDiagnostico,string varGrupoEtareo,string varSexo)
		{
			PnTrzPre item = new PnTrzPre();
			
				item.IdTrzPres = varIdTrzPres;
			
				item.TextoBoton = varTextoBoton;
			
				item.TrzVincula = varTrzVincula;
			
				item.PaginaDestino = varPaginaDestino;
			
				item.ParamPaginaDestino = varParamPaginaDestino;
			
				item.ObligaEfector = varObligaEfector;
			
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
        
        
        public static TableSchema.TableColumn IdTrzPresColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TextoBotonColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TrzVinculaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PaginaDestinoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ParamPaginaDestinoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObligaEfectorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PracticaVinculaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ObjPrestacionVinculaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoEtareoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTrzPres = @"id_trz_pres";
			 public static string TextoBoton = @"texto_boton";
			 public static string TrzVincula = @"trz_vincula";
			 public static string PaginaDestino = @"pagina_destino";
			 public static string ParamPaginaDestino = @"param_pagina_destino";
			 public static string ObligaEfector = @"obliga_efector";
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
