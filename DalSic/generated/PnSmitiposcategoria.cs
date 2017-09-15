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
	/// Strongly-typed collection for the PnSmitiposcategoria class.
	/// </summary>
    [Serializable]
	public partial class PnSmitiposcategoriaCollection : ActiveList<PnSmitiposcategoria, PnSmitiposcategoriaCollection>
	{	   
		public PnSmitiposcategoriaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnSmitiposcategoriaCollection</returns>
		public PnSmitiposcategoriaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnSmitiposcategoria o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_smitiposcategorias table.
	/// </summary>
	[Serializable]
	public partial class PnSmitiposcategoria : ActiveRecord<PnSmitiposcategoria>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnSmitiposcategoria()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnSmitiposcategoria(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnSmitiposcategoria(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnSmitiposcategoria(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_smitiposcategorias", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCodcategoria = new TableSchema.TableColumn(schema);
				colvarCodcategoria.ColumnName = "codcategoria";
				colvarCodcategoria.DataType = DbType.Int32;
				colvarCodcategoria.MaxLength = 0;
				colvarCodcategoria.AutoIncrement = true;
				colvarCodcategoria.IsNullable = false;
				colvarCodcategoria.IsPrimaryKey = true;
				colvarCodcategoria.IsForeignKey = false;
				colvarCodcategoria.IsReadOnly = false;
				colvarCodcategoria.DefaultSetting = @"";
				colvarCodcategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodcategoria);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_smitiposcategorias",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Codcategoria")]
		[Bindable(true)]
		public int Codcategoria 
		{
			get { return GetColumnValue<int>(Columns.Codcategoria); }
			set { SetColumnValue(Columns.Codcategoria, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnSmiafiliadoCollection colPnSmiafiliados;
		public DalSic.PnSmiafiliadoCollection PnSmiafiliados
		{
			get
			{
				if(colPnSmiafiliados == null)
				{
					colPnSmiafiliados = new DalSic.PnSmiafiliadoCollection().Where(PnSmiafiliado.Columns.Afitipocategoria, Codcategoria).Load();
					colPnSmiafiliados.ListChanged += new ListChangedEventHandler(colPnSmiafiliados_ListChanged);
				}
				return colPnSmiafiliados;			
			}
			set 
			{ 
					colPnSmiafiliados = value; 
					colPnSmiafiliados.ListChanged += new ListChangedEventHandler(colPnSmiafiliados_ListChanged);
			}
		}
		
		void colPnSmiafiliados_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnSmiafiliados[e.NewIndex].Afitipocategoria = Codcategoria;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescripcion)
		{
			PnSmitiposcategoria item = new PnSmitiposcategoria();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCodcategoria,string varDescripcion)
		{
			PnSmitiposcategoria item = new PnSmitiposcategoria();
			
				item.Codcategoria = varCodcategoria;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CodcategoriaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Codcategoria = @"codcategoria";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnSmiafiliados != null)
                {
                    foreach (DalSic.PnSmiafiliado item in colPnSmiafiliados)
                    {
                        if (item.Afitipocategoria != Codcategoria)
                        {
                            item.Afitipocategoria = Codcategoria;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnSmiafiliados != null)
                {
                    colPnSmiafiliados.SaveAll();
               }
		}
        #endregion
	}
}
