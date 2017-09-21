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
	/// Strongly-typed collection for the RemAgente class.
	/// </summary>
    [Serializable]
	public partial class RemAgenteCollection : ActiveList<RemAgente, RemAgenteCollection>
	{	   
		public RemAgenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RemAgenteCollection</returns>
		public RemAgenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RemAgente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Rem_Agente table.
	/// </summary>
	[Serializable]
	public partial class RemAgente : ActiveRecord<RemAgente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RemAgente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RemAgente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RemAgente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RemAgente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Rem_Agente", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAgente = new TableSchema.TableColumn(schema);
				colvarIdAgente.ColumnName = "idAgente";
				colvarIdAgente.DataType = DbType.Int32;
				colvarIdAgente.MaxLength = 0;
				colvarIdAgente.AutoIncrement = true;
				colvarIdAgente.IsNullable = false;
				colvarIdAgente.IsPrimaryKey = true;
				colvarIdAgente.IsForeignKey = false;
				colvarIdAgente.IsReadOnly = false;
				colvarIdAgente.DefaultSetting = @"";
				colvarIdAgente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAgente);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.String;
				colvarApellido.MaxLength = 50;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = false;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				
						colvarApellido.DefaultSetting = @"('')";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.Int32;
				colvarCodigo.MaxLength = 0;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				
						colvarCodigo.DefaultSetting = @"((0))";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarNombreCompleto = new TableSchema.TableColumn(schema);
				colvarNombreCompleto.ColumnName = "nombreCompleto";
				colvarNombreCompleto.DataType = DbType.String;
				colvarNombreCompleto.MaxLength = 102;
				colvarNombreCompleto.AutoIncrement = false;
				colvarNombreCompleto.IsNullable = false;
				colvarNombreCompleto.IsPrimaryKey = false;
				colvarNombreCompleto.IsForeignKey = false;
				colvarNombreCompleto.IsReadOnly = true;
				colvarNombreCompleto.DefaultSetting = @"";
				colvarNombreCompleto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreCompleto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Rem_Agente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAgente")]
		[Bindable(true)]
		public int IdAgente 
		{
			get { return GetColumnValue<int>(Columns.IdAgente); }
			set { SetColumnValue(Columns.IdAgente, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public int Codigo 
		{
			get { return GetColumnValue<int>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("NombreCompleto")]
		[Bindable(true)]
		public string NombreCompleto 
		{
			get { return GetColumnValue<string>(Columns.NombreCompleto); }
			set { SetColumnValue(Columns.NombreCompleto, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.RemFormularioCollection colRemFormularioRecords;
		public DalSic.RemFormularioCollection RemFormularioRecords
		{
			get
			{
				if(colRemFormularioRecords == null)
				{
					colRemFormularioRecords = new DalSic.RemFormularioCollection().Where(RemFormulario.Columns.IdAgente, IdAgente).Load();
					colRemFormularioRecords.ListChanged += new ListChangedEventHandler(colRemFormularioRecords_ListChanged);
				}
				return colRemFormularioRecords;			
			}
			set 
			{ 
					colRemFormularioRecords = value; 
					colRemFormularioRecords.ListChanged += new ListChangedEventHandler(colRemFormularioRecords_ListChanged);
			}
		}
		
		void colRemFormularioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colRemFormularioRecords[e.NewIndex].IdAgente = IdAgente;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varApellido,string varNombre,int varCodigo,bool varActivo,string varNombreCompleto)
		{
			RemAgente item = new RemAgente();
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.Codigo = varCodigo;
			
			item.Activo = varActivo;
			
			item.NombreCompleto = varNombreCompleto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAgente,string varApellido,string varNombre,int varCodigo,bool varActivo,string varNombreCompleto)
		{
			RemAgente item = new RemAgente();
			
				item.IdAgente = varIdAgente;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.Codigo = varCodigo;
			
				item.Activo = varActivo;
			
				item.NombreCompleto = varNombreCompleto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAgenteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreCompletoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAgente = @"idAgente";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string Codigo = @"codigo";
			 public static string Activo = @"activo";
			 public static string NombreCompleto = @"nombreCompleto";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colRemFormularioRecords != null)
                {
                    foreach (DalSic.RemFormulario item in colRemFormularioRecords)
                    {
                        if (item.IdAgente != IdAgente)
                        {
                            item.IdAgente = IdAgente;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colRemFormularioRecords != null)
                {
                    colRemFormularioRecords.SaveAll();
               }
		}
        #endregion
	}
}
