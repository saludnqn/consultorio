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
	/// Strongly-typed collection for the TamMetodoAnticonceptivo class.
	/// </summary>
    [Serializable]
	public partial class TamMetodoAnticonceptivoCollection : ActiveList<TamMetodoAnticonceptivo, TamMetodoAnticonceptivoCollection>
	{	   
		public TamMetodoAnticonceptivoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TamMetodoAnticonceptivoCollection</returns>
		public TamMetodoAnticonceptivoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TamMetodoAnticonceptivo o = this[i];
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
	/// This is an ActiveRecord class which wraps the TAM_MetodoAnticonceptivo table.
	/// </summary>
	[Serializable]
	public partial class TamMetodoAnticonceptivo : ActiveRecord<TamMetodoAnticonceptivo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TamMetodoAnticonceptivo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TamMetodoAnticonceptivo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TamMetodoAnticonceptivo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TamMetodoAnticonceptivo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TAM_MetodoAnticonceptivo", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMetodoAnticonceptivo = new TableSchema.TableColumn(schema);
				colvarIdMetodoAnticonceptivo.ColumnName = "idMetodoAnticonceptivo";
				colvarIdMetodoAnticonceptivo.DataType = DbType.Int32;
				colvarIdMetodoAnticonceptivo.MaxLength = 0;
				colvarIdMetodoAnticonceptivo.AutoIncrement = true;
				colvarIdMetodoAnticonceptivo.IsNullable = false;
				colvarIdMetodoAnticonceptivo.IsPrimaryKey = true;
				colvarIdMetodoAnticonceptivo.IsForeignKey = false;
				colvarIdMetodoAnticonceptivo.IsReadOnly = false;
				colvarIdMetodoAnticonceptivo.DefaultSetting = @"";
				colvarIdMetodoAnticonceptivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMetodoAnticonceptivo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				
						colvarNombre.DefaultSetting = @"('')";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("TAM_MetodoAnticonceptivo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMetodoAnticonceptivo")]
		[Bindable(true)]
		public int IdMetodoAnticonceptivo 
		{
			get { return GetColumnValue<int>(Columns.IdMetodoAnticonceptivo); }
			set { SetColumnValue(Columns.IdMetodoAnticonceptivo, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.MamAntecedenteCollection colMamAntecedentes;
		public DalSic.MamAntecedenteCollection MamAntecedentes
		{
			get
			{
				if(colMamAntecedentes == null)
				{
					colMamAntecedentes = new DalSic.MamAntecedenteCollection().Where(MamAntecedente.Columns.IdMetodoAnticonceptivo, IdMetodoAnticonceptivo).Load();
					colMamAntecedentes.ListChanged += new ListChangedEventHandler(colMamAntecedentes_ListChanged);
				}
				return colMamAntecedentes;			
			}
			set 
			{ 
					colMamAntecedentes = value; 
					colMamAntecedentes.ListChanged += new ListChangedEventHandler(colMamAntecedentes_ListChanged);
			}
		}
		
		void colMamAntecedentes_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamAntecedentes[e.NewIndex].IdMetodoAnticonceptivo = IdMetodoAnticonceptivo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			TamMetodoAnticonceptivo item = new TamMetodoAnticonceptivo();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMetodoAnticonceptivo,string varNombre)
		{
			TamMetodoAnticonceptivo item = new TamMetodoAnticonceptivo();
			
				item.IdMetodoAnticonceptivo = varIdMetodoAnticonceptivo;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMetodoAnticonceptivoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMetodoAnticonceptivo = @"idMetodoAnticonceptivo";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamAntecedentes != null)
                {
                    foreach (DalSic.MamAntecedente item in colMamAntecedentes)
                    {
                        if (item.IdMetodoAnticonceptivo != IdMetodoAnticonceptivo)
                        {
                            item.IdMetodoAnticonceptivo = IdMetodoAnticonceptivo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamAntecedentes != null)
                {
                    colMamAntecedentes.SaveAll();
               }
		}
        #endregion
	}
}
