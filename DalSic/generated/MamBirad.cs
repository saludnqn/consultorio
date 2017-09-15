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
	/// Strongly-typed collection for the MamBirad class.
	/// </summary>
    [Serializable]
	public partial class MamBiradCollection : ActiveList<MamBirad, MamBiradCollection>
	{	   
		public MamBiradCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamBiradCollection</returns>
		public MamBiradCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamBirad o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_Birads table.
	/// </summary>
	[Serializable]
	public partial class MamBirad : ActiveRecord<MamBirad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamBirad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamBirad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamBirad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamBirad(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_Birads", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdBirads = new TableSchema.TableColumn(schema);
				colvarIdBirads.ColumnName = "idBirads";
				colvarIdBirads.DataType = DbType.Int32;
				colvarIdBirads.MaxLength = 0;
				colvarIdBirads.AutoIncrement = true;
				colvarIdBirads.IsNullable = false;
				colvarIdBirads.IsPrimaryKey = true;
				colvarIdBirads.IsForeignKey = false;
				colvarIdBirads.IsReadOnly = false;
				colvarIdBirads.DefaultSetting = @"";
				colvarIdBirads.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBirads);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 200;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarObservacion = new TableSchema.TableColumn(schema);
				colvarObservacion.ColumnName = "observacion";
				colvarObservacion.DataType = DbType.AnsiString;
				colvarObservacion.MaxLength = 500;
				colvarObservacion.AutoIncrement = false;
				colvarObservacion.IsNullable = true;
				colvarObservacion.IsPrimaryKey = false;
				colvarObservacion.IsForeignKey = false;
				colvarObservacion.IsReadOnly = false;
				colvarObservacion.DefaultSetting = @"";
				colvarObservacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_Birads",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdBirads")]
		[Bindable(true)]
		public int IdBirads 
		{
			get { return GetColumnValue<int>(Columns.IdBirads); }
			set { SetColumnValue(Columns.IdBirads, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Observacion")]
		[Bindable(true)]
		public string Observacion 
		{
			get { return GetColumnValue<string>(Columns.Observacion); }
			set { SetColumnValue(Columns.Observacion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionales;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionales
		{
			get
			{
				if(colMamEstudiosAdicionales == null)
				{
					colMamEstudiosAdicionales = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdBiradsDef, IdBirads).Load();
					colMamEstudiosAdicionales.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionales_ListChanged);
				}
				return colMamEstudiosAdicionales;			
			}
			set 
			{ 
					colMamEstudiosAdicionales = value; 
					colMamEstudiosAdicionales.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionales_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionales_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionales[e.NewIndex].IdBiradsDef = IdBirads;
		    }
		}
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionalesFromMamBirad;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionalesFromMamBirad
		{
			get
			{
				if(colMamEstudiosAdicionalesFromMamBirad == null)
				{
					colMamEstudiosAdicionalesFromMamBirad = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdBiradsI, IdBirads).Load();
					colMamEstudiosAdicionalesFromMamBirad.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromMamBirad_ListChanged);
				}
				return colMamEstudiosAdicionalesFromMamBirad;			
			}
			set 
			{ 
					colMamEstudiosAdicionalesFromMamBirad = value; 
					colMamEstudiosAdicionalesFromMamBirad.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromMamBirad_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionalesFromMamBirad_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionalesFromMamBirad[e.NewIndex].IdBiradsI = IdBirads;
		    }
		}
				
		private DalSic.MamEstudiosAdicionaleCollection colMamEstudiosAdicionalesFromMamBiradIdBiradsD;
		public DalSic.MamEstudiosAdicionaleCollection MamEstudiosAdicionalesFromMamBiradIdBiradsD
		{
			get
			{
				if(colMamEstudiosAdicionalesFromMamBiradIdBiradsD == null)
				{
					colMamEstudiosAdicionalesFromMamBiradIdBiradsD = new DalSic.MamEstudiosAdicionaleCollection().Where(MamEstudiosAdicionale.Columns.IdBiradsD, IdBirads).Load();
					colMamEstudiosAdicionalesFromMamBiradIdBiradsD.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromMamBiradIdBiradsD_ListChanged);
				}
				return colMamEstudiosAdicionalesFromMamBiradIdBiradsD;			
			}
			set 
			{ 
					colMamEstudiosAdicionalesFromMamBiradIdBiradsD = value; 
					colMamEstudiosAdicionalesFromMamBiradIdBiradsD.ListChanged += new ListChangedEventHandler(colMamEstudiosAdicionalesFromMamBiradIdBiradsD_ListChanged);
			}
		}
		
		void colMamEstudiosAdicionalesFromMamBiradIdBiradsD_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEstudiosAdicionalesFromMamBiradIdBiradsD[e.NewIndex].IdBiradsD = IdBirads;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecords;
		public DalSic.MamRegistroCollection MamRegistroRecords
		{
			get
			{
				if(colMamRegistroRecords == null)
				{
					colMamRegistroRecords = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdBiradsDef, IdBirads).Load();
					colMamRegistroRecords.ListChanged += new ListChangedEventHandler(colMamRegistroRecords_ListChanged);
				}
				return colMamRegistroRecords;			
			}
			set 
			{ 
					colMamRegistroRecords = value; 
					colMamRegistroRecords.ListChanged += new ListChangedEventHandler(colMamRegistroRecords_ListChanged);
			}
		}
		
		void colMamRegistroRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecords[e.NewIndex].IdBiradsDef = IdBirads;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecordsFromMamBirad;
		public DalSic.MamRegistroCollection MamRegistroRecordsFromMamBirad
		{
			get
			{
				if(colMamRegistroRecordsFromMamBirad == null)
				{
					colMamRegistroRecordsFromMamBirad = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdBiradsD, IdBirads).Load();
					colMamRegistroRecordsFromMamBirad.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromMamBirad_ListChanged);
				}
				return colMamRegistroRecordsFromMamBirad;			
			}
			set 
			{ 
					colMamRegistroRecordsFromMamBirad = value; 
					colMamRegistroRecordsFromMamBirad.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromMamBirad_ListChanged);
			}
		}
		
		void colMamRegistroRecordsFromMamBirad_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecordsFromMamBirad[e.NewIndex].IdBiradsD = IdBirads;
		    }
		}
				
		private DalSic.MamRegistroCollection colMamRegistroRecordsFromMamBiradIdBiradsI;
		public DalSic.MamRegistroCollection MamRegistroRecordsFromMamBiradIdBiradsI
		{
			get
			{
				if(colMamRegistroRecordsFromMamBiradIdBiradsI == null)
				{
					colMamRegistroRecordsFromMamBiradIdBiradsI = new DalSic.MamRegistroCollection().Where(MamRegistro.Columns.IdBiradsI, IdBirads).Load();
					colMamRegistroRecordsFromMamBiradIdBiradsI.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromMamBiradIdBiradsI_ListChanged);
				}
				return colMamRegistroRecordsFromMamBiradIdBiradsI;			
			}
			set 
			{ 
					colMamRegistroRecordsFromMamBiradIdBiradsI = value; 
					colMamRegistroRecordsFromMamBiradIdBiradsI.ListChanged += new ListChangedEventHandler(colMamRegistroRecordsFromMamBiradIdBiradsI_ListChanged);
			}
		}
		
		void colMamRegistroRecordsFromMamBiradIdBiradsI_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamRegistroRecordsFromMamBiradIdBiradsI[e.NewIndex].IdBiradsI = IdBirads;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografia;
		public DalSic.MamEcografiumCollection MamEcografia
		{
			get
			{
				if(colMamEcografia == null)
				{
					colMamEcografia = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdBiradsDef, IdBirads).Load();
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
		        colMamEcografia[e.NewIndex].IdBiradsDef = IdBirads;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografiaFromMamBirad;
		public DalSic.MamEcografiumCollection MamEcografiaFromMamBirad
		{
			get
			{
				if(colMamEcografiaFromMamBirad == null)
				{
					colMamEcografiaFromMamBirad = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdBiradsI, IdBirads).Load();
					colMamEcografiaFromMamBirad.ListChanged += new ListChangedEventHandler(colMamEcografiaFromMamBirad_ListChanged);
				}
				return colMamEcografiaFromMamBirad;			
			}
			set 
			{ 
					colMamEcografiaFromMamBirad = value; 
					colMamEcografiaFromMamBirad.ListChanged += new ListChangedEventHandler(colMamEcografiaFromMamBirad_ListChanged);
			}
		}
		
		void colMamEcografiaFromMamBirad_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografiaFromMamBirad[e.NewIndex].IdBiradsI = IdBirads;
		    }
		}
				
		private DalSic.MamEcografiumCollection colMamEcografiaFromMamBiradIdBiradsD;
		public DalSic.MamEcografiumCollection MamEcografiaFromMamBiradIdBiradsD
		{
			get
			{
				if(colMamEcografiaFromMamBiradIdBiradsD == null)
				{
					colMamEcografiaFromMamBiradIdBiradsD = new DalSic.MamEcografiumCollection().Where(MamEcografium.Columns.IdBiradsD, IdBirads).Load();
					colMamEcografiaFromMamBiradIdBiradsD.ListChanged += new ListChangedEventHandler(colMamEcografiaFromMamBiradIdBiradsD_ListChanged);
				}
				return colMamEcografiaFromMamBiradIdBiradsD;			
			}
			set 
			{ 
					colMamEcografiaFromMamBiradIdBiradsD = value; 
					colMamEcografiaFromMamBiradIdBiradsD.ListChanged += new ListChangedEventHandler(colMamEcografiaFromMamBiradIdBiradsD_ListChanged);
			}
		}
		
		void colMamEcografiaFromMamBiradIdBiradsD_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colMamEcografiaFromMamBiradIdBiradsD[e.NewIndex].IdBiradsD = IdBirads;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varDescripcion,string varObservacion)
		{
			MamBirad item = new MamBirad();
			
			item.Nombre = varNombre;
			
			item.Descripcion = varDescripcion;
			
			item.Observacion = varObservacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdBirads,string varNombre,string varDescripcion,string varObservacion)
		{
			MamBirad item = new MamBirad();
			
				item.IdBirads = varIdBirads;
			
				item.Nombre = varNombre;
			
				item.Descripcion = varDescripcion;
			
				item.Observacion = varObservacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdBiradsColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdBirads = @"idBirads";
			 public static string Nombre = @"nombre";
			 public static string Descripcion = @"descripcion";
			 public static string Observacion = @"observacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colMamEstudiosAdicionales != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionales)
                    {
                        if (item.IdBiradsDef != IdBirads)
                        {
                            item.IdBiradsDef = IdBirads;
                        }
                    }
               }
		
                if (colMamEstudiosAdicionalesFromMamBirad != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionalesFromMamBirad)
                    {
                        if (item.IdBiradsI != IdBirads)
                        {
                            item.IdBiradsI = IdBirads;
                        }
                    }
               }
		
                if (colMamEstudiosAdicionalesFromMamBiradIdBiradsD != null)
                {
                    foreach (DalSic.MamEstudiosAdicionale item in colMamEstudiosAdicionalesFromMamBiradIdBiradsD)
                    {
                        if (item.IdBiradsD != IdBirads)
                        {
                            item.IdBiradsD = IdBirads;
                        }
                    }
               }
		
                if (colMamRegistroRecords != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecords)
                    {
                        if (item.IdBiradsDef != IdBirads)
                        {
                            item.IdBiradsDef = IdBirads;
                        }
                    }
               }
		
                if (colMamRegistroRecordsFromMamBirad != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecordsFromMamBirad)
                    {
                        if (item.IdBiradsD != IdBirads)
                        {
                            item.IdBiradsD = IdBirads;
                        }
                    }
               }
		
                if (colMamRegistroRecordsFromMamBiradIdBiradsI != null)
                {
                    foreach (DalSic.MamRegistro item in colMamRegistroRecordsFromMamBiradIdBiradsI)
                    {
                        if (item.IdBiradsI != IdBirads)
                        {
                            item.IdBiradsI = IdBirads;
                        }
                    }
               }
		
                if (colMamEcografia != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografia)
                    {
                        if (item.IdBiradsDef != IdBirads)
                        {
                            item.IdBiradsDef = IdBirads;
                        }
                    }
               }
		
                if (colMamEcografiaFromMamBirad != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografiaFromMamBirad)
                    {
                        if (item.IdBiradsI != IdBirads)
                        {
                            item.IdBiradsI = IdBirads;
                        }
                    }
               }
		
                if (colMamEcografiaFromMamBiradIdBiradsD != null)
                {
                    foreach (DalSic.MamEcografium item in colMamEcografiaFromMamBiradIdBiradsD)
                    {
                        if (item.IdBiradsD != IdBirads)
                        {
                            item.IdBiradsD = IdBirads;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colMamEstudiosAdicionales != null)
                {
                    colMamEstudiosAdicionales.SaveAll();
               }
		
                if (colMamEstudiosAdicionalesFromMamBirad != null)
                {
                    colMamEstudiosAdicionalesFromMamBirad.SaveAll();
               }
		
                if (colMamEstudiosAdicionalesFromMamBiradIdBiradsD != null)
                {
                    colMamEstudiosAdicionalesFromMamBiradIdBiradsD.SaveAll();
               }
		
                if (colMamRegistroRecords != null)
                {
                    colMamRegistroRecords.SaveAll();
               }
		
                if (colMamRegistroRecordsFromMamBirad != null)
                {
                    colMamRegistroRecordsFromMamBirad.SaveAll();
               }
		
                if (colMamRegistroRecordsFromMamBiradIdBiradsI != null)
                {
                    colMamRegistroRecordsFromMamBiradIdBiradsI.SaveAll();
               }
		
                if (colMamEcografia != null)
                {
                    colMamEcografia.SaveAll();
               }
		
                if (colMamEcografiaFromMamBirad != null)
                {
                    colMamEcografiaFromMamBirad.SaveAll();
               }
		
                if (colMamEcografiaFromMamBiradIdBiradsD != null)
                {
                    colMamEcografiaFromMamBiradIdBiradsD.SaveAll();
               }
		}
        #endregion
	}
}
