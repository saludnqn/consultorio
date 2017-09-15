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
	/// Strongly-typed collection for the MamDiagnoticoHistologico class.
	/// </summary>
    [Serializable]
	public partial class MamDiagnoticoHistologicoCollection : ActiveList<MamDiagnoticoHistologico, MamDiagnoticoHistologicoCollection>
	{	   
		public MamDiagnoticoHistologicoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamDiagnoticoHistologicoCollection</returns>
		public MamDiagnoticoHistologicoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamDiagnoticoHistologico o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_DiagnoticoHistologico table.
	/// </summary>
	[Serializable]
	public partial class MamDiagnoticoHistologico : ActiveRecord<MamDiagnoticoHistologico>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamDiagnoticoHistologico()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamDiagnoticoHistologico(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamDiagnoticoHistologico(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamDiagnoticoHistologico(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_DiagnoticoHistologico", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdDiagnosticoHistologico = new TableSchema.TableColumn(schema);
				colvarIdDiagnosticoHistologico.ColumnName = "idDiagnosticoHistologico";
				colvarIdDiagnosticoHistologico.DataType = DbType.Int32;
				colvarIdDiagnosticoHistologico.MaxLength = 0;
				colvarIdDiagnosticoHistologico.AutoIncrement = true;
				colvarIdDiagnosticoHistologico.IsNullable = false;
				colvarIdDiagnosticoHistologico.IsPrimaryKey = true;
				colvarIdDiagnosticoHistologico.IsForeignKey = false;
				colvarIdDiagnosticoHistologico.IsReadOnly = false;
				colvarIdDiagnosticoHistologico.DefaultSetting = @"";
				colvarIdDiagnosticoHistologico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDiagnosticoHistologico);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 50;
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
				DataService.Providers["sicProvider"].AddSchema("MAM_DiagnoticoHistologico",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdDiagnosticoHistologico")]
		[Bindable(true)]
		public int IdDiagnosticoHistologico 
		{
			get { return GetColumnValue<int>(Columns.IdDiagnosticoHistologico); }
			set { SetColumnValue(Columns.IdDiagnosticoHistologico, value); }
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
					colMamAnatomiaPatologicaRecords = new DalSic.MamAnatomiaPatologicaCollection().Where(MamAnatomiaPatologica.Columns.IdDiagnosticoHistologico, IdDiagnosticoHistologico).Load();
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
		        colMamAnatomiaPatologicaRecords[e.NewIndex].IdDiagnosticoHistologico = IdDiagnosticoHistologico;
		    }
		}
				
		private DalSic.MamPiezaQuirurgicaCollection colMamPiezaQuirurgicaRecords;
		public DalSic.MamPiezaQuirurgicaCollection MamPiezaQuirurgicaRecords
		{
			get
			{
				if(colMamPiezaQuirurgicaRecords == null)
				{
					colMamPiezaQuirurgicaRecords = new DalSic.MamPiezaQuirurgicaCollection().Where(MamPiezaQuirurgica.Columns.IdDiagnosticoHistologico, IdDiagnosticoHistologico).Load();
					colMamPiezaQuirurgicaRecords.ListChanged += new ListChangedEventHandler(colMamPiezaQuirurgicaRecords_ListChanged);
				}
				return colMamPiezaQuirurgicaRecords;			
			}
			set 
			{ 
					colMamPiezaQuirurgicaRecords = value; 
					colMamPiezaQuirurgicaRecords.ListChanged += new ListChangedEventHandler(colMamPiezaQuirurgicaRecords_ListChanged);
			}
		}
		
		void colMamPiezaQuirurgicaRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamPiezaQuirurgicaRecords[e.NewIndex].IdDiagnosticoHistologico = IdDiagnosticoHistologico;
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
			MamDiagnoticoHistologico item = new MamDiagnoticoHistologico();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdDiagnosticoHistologico,string varDescripcion)
		{
			MamDiagnoticoHistologico item = new MamDiagnoticoHistologico();
			
				item.IdDiagnosticoHistologico = varIdDiagnosticoHistologico;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdDiagnosticoHistologicoColumn
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
			 public static string IdDiagnosticoHistologico = @"idDiagnosticoHistologico";
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
                        if (item.IdDiagnosticoHistologico != IdDiagnosticoHistologico)
                        {
                            item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
                        }
                    }
               }
		
                if (colMamPiezaQuirurgicaRecords != null)
                {
                    foreach (DalSic.MamPiezaQuirurgica item in colMamPiezaQuirurgicaRecords)
                    {
                        if (item.IdDiagnosticoHistologico != IdDiagnosticoHistologico)
                        {
                            item.IdDiagnosticoHistologico = IdDiagnosticoHistologico;
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
		
                if (colMamPiezaQuirurgicaRecords != null)
                {
                    colMamPiezaQuirurgicaRecords.SaveAll();
               }
		}
        #endregion
	}
}
