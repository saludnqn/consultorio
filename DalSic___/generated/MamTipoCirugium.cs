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
	/// Strongly-typed collection for the MamTipoCirugium class.
	/// </summary>
    [Serializable]
	public partial class MamTipoCirugiumCollection : ActiveList<MamTipoCirugium, MamTipoCirugiumCollection>
	{	   
		public MamTipoCirugiumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamTipoCirugiumCollection</returns>
		public MamTipoCirugiumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamTipoCirugium o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_TipoCirugia table.
	/// </summary>
	[Serializable]
	public partial class MamTipoCirugium : ActiveRecord<MamTipoCirugium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamTipoCirugium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamTipoCirugium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamTipoCirugium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamTipoCirugium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_TipoCirugia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoCirugia = new TableSchema.TableColumn(schema);
				colvarIdTipoCirugia.ColumnName = "idTipoCirugia";
				colvarIdTipoCirugia.DataType = DbType.Int32;
				colvarIdTipoCirugia.MaxLength = 0;
				colvarIdTipoCirugia.AutoIncrement = true;
				colvarIdTipoCirugia.IsNullable = false;
				colvarIdTipoCirugia.IsPrimaryKey = true;
				colvarIdTipoCirugia.IsForeignKey = false;
				colvarIdTipoCirugia.IsReadOnly = false;
				colvarIdTipoCirugia.DefaultSetting = @"";
				colvarIdTipoCirugia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoCirugia);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 30;
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
				DataService.Providers["sicProvider"].AddSchema("MAM_TipoCirugia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoCirugia")]
		[Bindable(true)]
		public int IdTipoCirugia 
		{
			get { return GetColumnValue<int>(Columns.IdTipoCirugia); }
			set { SetColumnValue(Columns.IdTipoCirugia, value); }
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
        
				
		private DalSic.MamCirugiumCollection colMamCirugia;
		public DalSic.MamCirugiumCollection MamCirugia
		{
			get
			{
				if(colMamCirugia == null)
				{
					colMamCirugia = new DalSic.MamCirugiumCollection().Where(MamCirugium.Columns.IdTipoCirugiaDer, IdTipoCirugia).Load();
					colMamCirugia.ListChanged += new ListChangedEventHandler(colMamCirugia_ListChanged);
				}
				return colMamCirugia;			
			}
			set 
			{ 
					colMamCirugia = value; 
					colMamCirugia.ListChanged += new ListChangedEventHandler(colMamCirugia_ListChanged);
			}
		}
		
		void colMamCirugia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamCirugia[e.NewIndex].IdTipoCirugiaDer = IdTipoCirugia;
		    }
		}
				
		private DalSic.MamCirugiumCollection colMamCirugiaFromMamTipoCirugium;
		public DalSic.MamCirugiumCollection MamCirugiaFromMamTipoCirugium
		{
			get
			{
				if(colMamCirugiaFromMamTipoCirugium == null)
				{
					colMamCirugiaFromMamTipoCirugium = new DalSic.MamCirugiumCollection().Where(MamCirugium.Columns.IdTipoCirugiaIzq, IdTipoCirugia).Load();
					colMamCirugiaFromMamTipoCirugium.ListChanged += new ListChangedEventHandler(colMamCirugiaFromMamTipoCirugium_ListChanged);
				}
				return colMamCirugiaFromMamTipoCirugium;			
			}
			set 
			{ 
					colMamCirugiaFromMamTipoCirugium = value; 
					colMamCirugiaFromMamTipoCirugium.ListChanged += new ListChangedEventHandler(colMamCirugiaFromMamTipoCirugium_ListChanged);
			}
		}
		
		void colMamCirugiaFromMamTipoCirugium_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamCirugiaFromMamTipoCirugium[e.NewIndex].IdTipoCirugiaIzq = IdTipoCirugia;
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
			MamTipoCirugium item = new MamTipoCirugium();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoCirugia,string varDescripcion)
		{
			MamTipoCirugium item = new MamTipoCirugium();
			
				item.IdTipoCirugia = varIdTipoCirugia;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoCirugiaColumn
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
			 public static string IdTipoCirugia = @"idTipoCirugia";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamCirugia != null)
                {
                    foreach (DalSic.MamCirugium item in colMamCirugia)
                    {
                        if (item.IdTipoCirugiaDer != IdTipoCirugia)
                        {
                            item.IdTipoCirugiaDer = IdTipoCirugia;
                        }
                    }
               }
		
                if (colMamCirugiaFromMamTipoCirugium != null)
                {
                    foreach (DalSic.MamCirugium item in colMamCirugiaFromMamTipoCirugium)
                    {
                        if (item.IdTipoCirugiaIzq != IdTipoCirugia)
                        {
                            item.IdTipoCirugiaIzq = IdTipoCirugia;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamCirugia != null)
                {
                    colMamCirugia.SaveAll();
               }
		
                if (colMamCirugiaFromMamTipoCirugium != null)
                {
                    colMamCirugiaFromMamTipoCirugium.SaveAll();
               }
		}
        #endregion
	}
}
