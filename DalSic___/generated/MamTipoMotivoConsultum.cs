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
	/// Strongly-typed collection for the MamTipoMotivoConsultum class.
	/// </summary>
    [Serializable]
	public partial class MamTipoMotivoConsultumCollection : ActiveList<MamTipoMotivoConsultum, MamTipoMotivoConsultumCollection>
	{	   
		public MamTipoMotivoConsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamTipoMotivoConsultumCollection</returns>
		public MamTipoMotivoConsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamTipoMotivoConsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_TipoMotivoConsulta table.
	/// </summary>
	[Serializable]
	public partial class MamTipoMotivoConsultum : ActiveRecord<MamTipoMotivoConsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamTipoMotivoConsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamTipoMotivoConsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamTipoMotivoConsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamTipoMotivoConsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_TipoMotivoConsulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTipoMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarIdTipoMotivoConsulta.ColumnName = "idTipoMotivoConsulta";
				colvarIdTipoMotivoConsulta.DataType = DbType.Int32;
				colvarIdTipoMotivoConsulta.MaxLength = 0;
				colvarIdTipoMotivoConsulta.AutoIncrement = true;
				colvarIdTipoMotivoConsulta.IsNullable = false;
				colvarIdTipoMotivoConsulta.IsPrimaryKey = true;
				colvarIdTipoMotivoConsulta.IsForeignKey = false;
				colvarIdTipoMotivoConsulta.IsReadOnly = false;
				colvarIdTipoMotivoConsulta.DefaultSetting = @"";
				colvarIdTipoMotivoConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTipoMotivoConsulta);
				
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
				DataService.Providers["sicProvider"].AddSchema("MAM_TipoMotivoConsulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTipoMotivoConsulta")]
		[Bindable(true)]
		public int IdTipoMotivoConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdTipoMotivoConsulta); }
			set { SetColumnValue(Columns.IdTipoMotivoConsulta, value); }
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
        
				
		private DalSic.MamMotivoConsultumCollection colMamMotivoConsulta;
		public DalSic.MamMotivoConsultumCollection MamMotivoConsulta
		{
			get
			{
				if(colMamMotivoConsulta == null)
				{
					colMamMotivoConsulta = new DalSic.MamMotivoConsultumCollection().Where(MamMotivoConsultum.Columns.IdTipoMotivoConsulta, IdTipoMotivoConsulta).Load();
					colMamMotivoConsulta.ListChanged += new ListChangedEventHandler(colMamMotivoConsulta_ListChanged);
				}
				return colMamMotivoConsulta;			
			}
			set 
			{ 
					colMamMotivoConsulta = value; 
					colMamMotivoConsulta.ListChanged += new ListChangedEventHandler(colMamMotivoConsulta_ListChanged);
			}
		}
		
		void colMamMotivoConsulta_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamMotivoConsulta[e.NewIndex].IdTipoMotivoConsulta = IdTipoMotivoConsulta;
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
			MamTipoMotivoConsultum item = new MamTipoMotivoConsultum();
			
			item.Descripcion = varDescripcion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTipoMotivoConsulta,string varDescripcion)
		{
			MamTipoMotivoConsultum item = new MamTipoMotivoConsultum();
			
				item.IdTipoMotivoConsulta = varIdTipoMotivoConsulta;
			
				item.Descripcion = varDescripcion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTipoMotivoConsultaColumn
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
			 public static string IdTipoMotivoConsulta = @"idTipoMotivoConsulta";
			 public static string Descripcion = @"descripcion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamMotivoConsulta != null)
                {
                    foreach (DalSic.MamMotivoConsultum item in colMamMotivoConsulta)
                    {
                        if (item.IdTipoMotivoConsulta != IdTipoMotivoConsulta)
                        {
                            item.IdTipoMotivoConsulta = IdTipoMotivoConsulta;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamMotivoConsulta != null)
                {
                    colMamMotivoConsulta.SaveAll();
               }
		}
        #endregion
	}
}
