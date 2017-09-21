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
	/// Strongly-typed collection for the AprAcompañante class.
	/// </summary>
    [Serializable]
	public partial class AprAcompañanteCollection : ActiveList<AprAcompañante, AprAcompañanteCollection>
	{	   
		public AprAcompañanteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAcompañanteCollection</returns>
		public AprAcompañanteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAcompañante o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_Acompañante table.
	/// </summary>
	[Serializable]
	public partial class AprAcompañante : ActiveRecord<AprAcompañante>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAcompañante()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAcompañante(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAcompañante(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAcompañante(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_Acompañante", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAcompañante = new TableSchema.TableColumn(schema);
				colvarIdAcompañante.ColumnName = "idAcompañante";
				colvarIdAcompañante.DataType = DbType.Int32;
				colvarIdAcompañante.MaxLength = 0;
				colvarIdAcompañante.AutoIncrement = true;
				colvarIdAcompañante.IsNullable = false;
				colvarIdAcompañante.IsPrimaryKey = true;
				colvarIdAcompañante.IsForeignKey = false;
				colvarIdAcompañante.IsReadOnly = false;
				colvarIdAcompañante.DefaultSetting = @"";
				colvarIdAcompañante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAcompañante);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_Acompañante",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAcompañante")]
		[Bindable(true)]
		public int IdAcompañante 
		{
			get { return GetColumnValue<int>(Columns.IdAcompañante); }
			set { SetColumnValue(Columns.IdAcompañante, value); }
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
        
				
		private DalSic.AprAbortoCollection colAprAbortoRecords;
		public DalSic.AprAbortoCollection AprAbortoRecords
		{
			get
			{
				if(colAprAbortoRecords == null)
				{
					colAprAbortoRecords = new DalSic.AprAbortoCollection().Where(AprAborto.Columns.IdAcompañante, IdAcompañante).Load();
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
				}
				return colAprAbortoRecords;			
			}
			set 
			{ 
					colAprAbortoRecords = value; 
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
			}
		}
		
		void colAprAbortoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAbortoRecords[e.NewIndex].IdAcompañante = IdAcompañante;
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
			AprAcompañante item = new AprAcompañante();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAcompañante,string varNombre)
		{
			AprAcompañante item = new AprAcompañante();
			
				item.IdAcompañante = varIdAcompañante;
			
				item.Nombre = varNombre;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAcompañanteColumn
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
			 public static string IdAcompañante = @"idAcompañante";
			 public static string Nombre = @"nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprAbortoRecords != null)
                {
                    foreach (DalSic.AprAborto item in colAprAbortoRecords)
                    {
                        if (item.IdAcompañante != IdAcompañante)
                        {
                            item.IdAcompañante = IdAcompañante;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprAbortoRecords != null)
                {
                    colAprAbortoRecords.SaveAll();
               }
		}
        #endregion
	}
}
