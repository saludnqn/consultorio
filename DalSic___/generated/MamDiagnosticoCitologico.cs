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
	/// Strongly-typed collection for the MamDiagnosticoCitologico class.
	/// </summary>
    [Serializable]
	public partial class MamDiagnosticoCitologicoCollection : ActiveList<MamDiagnosticoCitologico, MamDiagnosticoCitologicoCollection>
	{	   
		public MamDiagnosticoCitologicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamDiagnosticoCitologicoCollection</returns>
		public MamDiagnosticoCitologicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamDiagnosticoCitologico o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_DiagnosticoCitologico table.
	/// </summary>
	[Serializable]
	public partial class MamDiagnosticoCitologico : ActiveRecord<MamDiagnosticoCitologico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamDiagnosticoCitologico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamDiagnosticoCitologico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamDiagnosticoCitologico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamDiagnosticoCitologico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_DiagnosticoCitologico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDiagnosticoCitologico = new TableSchema.TableColumn(schema);
				colvarIdDiagnosticoCitologico.ColumnName = "idDiagnosticoCitologico";
				colvarIdDiagnosticoCitologico.DataType = DbType.Int32;
				colvarIdDiagnosticoCitologico.MaxLength = 0;
				colvarIdDiagnosticoCitologico.AutoIncrement = true;
				colvarIdDiagnosticoCitologico.IsNullable = false;
				colvarIdDiagnosticoCitologico.IsPrimaryKey = true;
				colvarIdDiagnosticoCitologico.IsForeignKey = false;
				colvarIdDiagnosticoCitologico.IsReadOnly = false;
				colvarIdDiagnosticoCitologico.DefaultSetting = @"";
				colvarIdDiagnosticoCitologico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDiagnosticoCitologico);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 20;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				
						colvarDescripcion.DefaultSetting = @"('')";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_DiagnosticoCitologico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDiagnosticoCitologico")]
		[Bindable(true)]
		public int IdDiagnosticoCitologico 
		{
			get { return GetColumnValue<int>(Columns.IdDiagnosticoCitologico); }
			set { SetColumnValue(Columns.IdDiagnosticoCitologico, value); }
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
        
				
		private DalSic.MamAnatomiaPatologicaCollection colMamAnatomiaPatologicaRecords;
		public DalSic.MamAnatomiaPatologicaCollection MamAnatomiaPatologicaRecords
		{
			get
			{
				if(colMamAnatomiaPatologicaRecords == null)
				{
					colMamAnatomiaPatologicaRecords = new DalSic.MamAnatomiaPatologicaCollection().Where(MamAnatomiaPatologica.Columns.IdDiagnosticoCitologico, IdDiagnosticoCitologico).Load();
					colMamAnatomiaPatologicaRecords.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecords_ListChanged);
				}
				return colMamAnatomiaPatologicaRecords;			
			}
			set 
			{ 
					colMamAnatomiaPatologicaRecords = value; 
					colMamAnatomiaPatologicaRecords.ListChanged += new ListChangedEventHandler(colMamAnatomiaPatologicaRecords_ListChanged);
			}
		}
		
		void colMamAnatomiaPatologicaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamAnatomiaPatologicaRecords[e.NewIndex].IdDiagnosticoCitologico = IdDiagnosticoCitologico;
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
			MamDiagnosticoCitologico item = new MamDiagnosticoCitologico();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDiagnosticoCitologico,string varDescripcion)
		{
			MamDiagnosticoCitologico item = new MamDiagnosticoCitologico();
			
				item.IdDiagnosticoCitologico = varIdDiagnosticoCitologico;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDiagnosticoCitologicoColumn
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
			 public static string IdDiagnosticoCitologico = @"idDiagnosticoCitologico";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamAnatomiaPatologicaRecords != null)
                {
                    foreach (DalSic.MamAnatomiaPatologica item in colMamAnatomiaPatologicaRecords)
                    {
                        if (item.IdDiagnosticoCitologico != IdDiagnosticoCitologico)
                        {
                            item.IdDiagnosticoCitologico = IdDiagnosticoCitologico;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamAnatomiaPatologicaRecords != null)
                {
                    colMamAnatomiaPatologicaRecords.SaveAll();
               }
		}
        #endregion
	}
}
