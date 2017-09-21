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
	/// Strongly-typed collection for the MamMotivoConsultum class.
	/// </summary>
    [Serializable]
	public partial class MamMotivoConsultumCollection : ActiveList<MamMotivoConsultum, MamMotivoConsultumCollection>
	{	   
		public MamMotivoConsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamMotivoConsultumCollection</returns>
		public MamMotivoConsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamMotivoConsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_MotivoConsulta table.
	/// </summary>
	[Serializable]
	public partial class MamMotivoConsultum : ActiveRecord<MamMotivoConsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamMotivoConsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamMotivoConsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamMotivoConsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamMotivoConsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_MotivoConsulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarIdMotivoConsulta.ColumnName = "idMotivoConsulta";
				colvarIdMotivoConsulta.DataType = DbType.Int32;
				colvarIdMotivoConsulta.MaxLength = 0;
				colvarIdMotivoConsulta.AutoIncrement = true;
				colvarIdMotivoConsulta.IsNullable = false;
				colvarIdMotivoConsulta.IsPrimaryKey = true;
				colvarIdMotivoConsulta.IsForeignKey = false;
				colvarIdMotivoConsulta.IsReadOnly = false;
				colvarIdMotivoConsulta.DefaultSetting = @"";
				colvarIdMotivoConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMotivoConsulta);
				
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
				
				TableSchema.TableColumn colvarIdTipoMotivoConsulta = new TableSchema.TableColumn(schema);
				colvarIdTipoMotivoConsulta.ColumnName = "idTipoMotivoConsulta";
				colvarIdTipoMotivoConsulta.DataType = DbType.Int32;
				colvarIdTipoMotivoConsulta.MaxLength = 0;
				colvarIdTipoMotivoConsulta.AutoIncrement = false;
				colvarIdTipoMotivoConsulta.IsNullable = false;
				colvarIdTipoMotivoConsulta.IsPrimaryKey = false;
				colvarIdTipoMotivoConsulta.IsForeignKey = true;
				colvarIdTipoMotivoConsulta.IsReadOnly = false;
				
						colvarIdTipoMotivoConsulta.DefaultSetting = @"((0))";
				
					colvarIdTipoMotivoConsulta.ForeignKeyTableName = "MAM_TipoMotivoConsulta";
				schema.Columns.Add(colvarIdTipoMotivoConsulta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_MotivoConsulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMotivoConsulta")]
		[Bindable(true)]
		public int IdMotivoConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdMotivoConsulta); }
			set { SetColumnValue(Columns.IdMotivoConsulta, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdTipoMotivoConsulta")]
		[Bindable(true)]
		public int IdTipoMotivoConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdTipoMotivoConsulta); }
			set { SetColumnValue(Columns.IdTipoMotivoConsulta, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.MamEcografiumCollection colMamEcografia;
		public DalSic.MamEcografiumCollection MamEcografia
		{
			get
			{
				if(colMamEcografia == null)
				{
					colMamEcografia = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdMotivoEstudio, IdMotivoConsulta).Load();
					colMamEcografia.ListChanged += new ListChangedEventHandler(colMamEcografia_ListChanged);
				}
				return colMamEcografia;			
			}
			set 
			{ 
					colMamEcografia = value; 
					colMamEcografia.ListChanged += new ListChangedEventHandler(colMamEcografia_ListChanged);
			}
		}
		
		void colMamEcografia_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografia[e.NewIndex].IdMotivoEstudio = IdMotivoConsulta;
		    }
		}
				
		private DalSic.MamExamenFisicoCollection colMamExamenFisicoRecords;
		public DalSic.MamExamenFisicoCollection MamExamenFisicoRecords
		{
			get
			{
				if(colMamExamenFisicoRecords == null)
				{
					colMamExamenFisicoRecords = new DalSic.MamExamenFisicoCollection().Where(MamExamenFisico.Columns.IdMotivoConsulta, IdMotivoConsulta).Load();
					colMamExamenFisicoRecords.ListChanged += new ListChangedEventHandler(colMamExamenFisicoRecords_ListChanged);
				}
				return colMamExamenFisicoRecords;			
			}
			set 
			{ 
					colMamExamenFisicoRecords = value; 
					colMamExamenFisicoRecords.ListChanged += new ListChangedEventHandler(colMamExamenFisicoRecords_ListChanged);
			}
		}
		
		void colMamExamenFisicoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamExamenFisicoRecords[e.NewIndex].IdMotivoConsulta = IdMotivoConsulta;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a MamTipoMotivoConsultum ActiveRecord object related to this MamMotivoConsultum
		/// 
		/// </summary>
		public DalSic.MamTipoMotivoConsultum MamTipoMotivoConsultum
		{
			get { return DalSic.MamTipoMotivoConsultum.FetchByID(this.IdTipoMotivoConsulta); }
			set { SetColumnValue("idTipoMotivoConsulta", value.IdTipoMotivoConsulta); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdTipoMotivoConsulta)
		{
			MamMotivoConsultum item = new MamMotivoConsultum();
			
			item.Nombre = varNombre;
			
			item.IdTipoMotivoConsulta = varIdTipoMotivoConsulta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMotivoConsulta,string varNombre,int varIdTipoMotivoConsulta)
		{
			MamMotivoConsultum item = new MamMotivoConsultum();
			
				item.IdMotivoConsulta = varIdMotivoConsulta;
			
				item.Nombre = varNombre;
			
				item.IdTipoMotivoConsulta = varIdTipoMotivoConsulta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMotivoConsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoMotivoConsultaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMotivoConsulta = @"idMotivoConsulta";
			 public static string Nombre = @"nombre";
			 public static string IdTipoMotivoConsulta = @"idTipoMotivoConsulta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamEcografia != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografia)
                    {
                        if (item.IdMotivoEstudio != IdMotivoConsulta)
                        {
                            item.IdMotivoEstudio = IdMotivoConsulta;
                        }
                    }
               }
		
                if (colMamExamenFisicoRecords != null)
                {
                    foreach (DalSic.MamExamenFisico item in colMamExamenFisicoRecords)
                    {
                        if (item.IdMotivoConsulta != IdMotivoConsulta)
                        {
                            item.IdMotivoConsulta = IdMotivoConsulta;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamEcografia != null)
                {
                    colMamEcografia.SaveAll();
               }
		
                if (colMamExamenFisicoRecords != null)
                {
                    colMamExamenFisicoRecords.SaveAll();
               }
		}
        #endregion
	}
}
