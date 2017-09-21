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
	/// Strongly-typed collection for the SysMedicamentoRubro class.
	/// </summary>
    [Serializable]
	public partial class SysMedicamentoRubroCollection : ActiveList<SysMedicamentoRubro, SysMedicamentoRubroCollection>
	{	   
		public SysMedicamentoRubroCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysMedicamentoRubroCollection</returns>
		public SysMedicamentoRubroCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysMedicamentoRubro o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_MedicamentoRubro table.
	/// </summary>
	[Serializable]
	public partial class SysMedicamentoRubro : ActiveRecord<SysMedicamentoRubro>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysMedicamentoRubro()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysMedicamentoRubro(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysMedicamentoRubro(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysMedicamentoRubro(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_MedicamentoRubro", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMedicamentoRubro = new TableSchema.TableColumn(schema);
				colvarIdMedicamentoRubro.ColumnName = "idMedicamentoRubro";
				colvarIdMedicamentoRubro.DataType = DbType.Int32;
				colvarIdMedicamentoRubro.MaxLength = 0;
				colvarIdMedicamentoRubro.AutoIncrement = false;
				colvarIdMedicamentoRubro.IsNullable = false;
				colvarIdMedicamentoRubro.IsPrimaryKey = true;
				colvarIdMedicamentoRubro.IsForeignKey = false;
				colvarIdMedicamentoRubro.IsReadOnly = false;
				colvarIdMedicamentoRubro.DefaultSetting = @"";
				colvarIdMedicamentoRubro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMedicamentoRubro);
				
				TableSchema.TableColumn colvarPadre = new TableSchema.TableColumn(schema);
				colvarPadre.ColumnName = "padre";
				colvarPadre.DataType = DbType.Int32;
				colvarPadre.MaxLength = 0;
				colvarPadre.AutoIncrement = false;
				colvarPadre.IsNullable = true;
				colvarPadre.IsPrimaryKey = false;
				colvarPadre.IsForeignKey = false;
				colvarPadre.IsReadOnly = false;
				colvarPadre.DefaultSetting = @"";
				colvarPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPadre);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 255;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarRubroPrimerNivel = new TableSchema.TableColumn(schema);
				colvarRubroPrimerNivel.ColumnName = "rubroPrimerNivel";
				colvarRubroPrimerNivel.DataType = DbType.Int32;
				colvarRubroPrimerNivel.MaxLength = 0;
				colvarRubroPrimerNivel.AutoIncrement = false;
				colvarRubroPrimerNivel.IsNullable = true;
				colvarRubroPrimerNivel.IsPrimaryKey = false;
				colvarRubroPrimerNivel.IsForeignKey = false;
				colvarRubroPrimerNivel.IsReadOnly = false;
				colvarRubroPrimerNivel.DefaultSetting = @"";
				colvarRubroPrimerNivel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRubroPrimerNivel);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_MedicamentoRubro",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMedicamentoRubro")]
		[Bindable(true)]
		public int IdMedicamentoRubro 
		{
			get { return GetColumnValue<int>(Columns.IdMedicamentoRubro); }
			set { SetColumnValue(Columns.IdMedicamentoRubro, value); }
		}
		  
		[XmlAttribute("Padre")]
		[Bindable(true)]
		public int? Padre 
		{
			get { return GetColumnValue<int?>(Columns.Padre); }
			set { SetColumnValue(Columns.Padre, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("RubroPrimerNivel")]
		[Bindable(true)]
		public int? RubroPrimerNivel 
		{
			get { return GetColumnValue<int?>(Columns.RubroPrimerNivel); }
			set { SetColumnValue(Columns.RubroPrimerNivel, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysMedicamentoCollection colSysMedicamentoRecords;
		public DalSic.SysMedicamentoCollection SysMedicamentoRecords
		{
			get
			{
				if(colSysMedicamentoRecords == null)
				{
					colSysMedicamentoRecords = new DalSic.SysMedicamentoCollection().Where(SysMedicamento.Columns.IdMedicamentoRubro, IdMedicamentoRubro).Load();
					colSysMedicamentoRecords.ListChanged += new ListChangedEventHandler(colSysMedicamentoRecords_ListChanged);
				}
				return colSysMedicamentoRecords;			
			}
			set 
			{ 
					colSysMedicamentoRecords = value; 
					colSysMedicamentoRecords.ListChanged += new ListChangedEventHandler(colSysMedicamentoRecords_ListChanged);
			}
		}
		
		void colSysMedicamentoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysMedicamentoRecords[e.NewIndex].IdMedicamentoRubro = IdMedicamentoRubro;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdMedicamentoRubro,int? varPadre,string varNombre,int? varRubroPrimerNivel)
		{
			SysMedicamentoRubro item = new SysMedicamentoRubro();
			
			item.IdMedicamentoRubro = varIdMedicamentoRubro;
			
			item.Padre = varPadre;
			
			item.Nombre = varNombre;
			
			item.RubroPrimerNivel = varRubroPrimerNivel;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMedicamentoRubro,int? varPadre,string varNombre,int? varRubroPrimerNivel)
		{
			SysMedicamentoRubro item = new SysMedicamentoRubro();
			
				item.IdMedicamentoRubro = varIdMedicamentoRubro;
			
				item.Padre = varPadre;
			
				item.Nombre = varNombre;
			
				item.RubroPrimerNivel = varRubroPrimerNivel;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMedicamentoRubroColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PadreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RubroPrimerNivelColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMedicamentoRubro = @"idMedicamentoRubro";
			 public static string Padre = @"padre";
			 public static string Nombre = @"nombre";
			 public static string RubroPrimerNivel = @"rubroPrimerNivel";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysMedicamentoRecords != null)
                {
                    foreach (DalSic.SysMedicamento item in colSysMedicamentoRecords)
                    {
                        if (item.IdMedicamentoRubro != IdMedicamentoRubro)
                        {
                            item.IdMedicamentoRubro = IdMedicamentoRubro;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysMedicamentoRecords != null)
                {
                    colSysMedicamentoRecords.SaveAll();
               }
		}
        #endregion
	}
}
