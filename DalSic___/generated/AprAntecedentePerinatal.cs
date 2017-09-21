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
	/// Strongly-typed collection for the AprAntecedentePerinatal class.
	/// </summary>
    [Serializable]
	public partial class AprAntecedentePerinatalCollection : ActiveList<AprAntecedentePerinatal, AprAntecedentePerinatalCollection>
	{	   
		public AprAntecedentePerinatalCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprAntecedentePerinatalCollection</returns>
		public AprAntecedentePerinatalCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprAntecedentePerinatal o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_AntecedentePerinatal table.
	/// </summary>
	[Serializable]
	public partial class AprAntecedentePerinatal : ActiveRecord<AprAntecedentePerinatal>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprAntecedentePerinatal()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprAntecedentePerinatal(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprAntecedentePerinatal(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprAntecedentePerinatal(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_AntecedentePerinatal", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAntecedentePerinatal = new TableSchema.TableColumn(schema);
				colvarIdAntecedentePerinatal.ColumnName = "idAntecedentePerinatal";
				colvarIdAntecedentePerinatal.DataType = DbType.Int32;
				colvarIdAntecedentePerinatal.MaxLength = 0;
				colvarIdAntecedentePerinatal.AutoIncrement = true;
				colvarIdAntecedentePerinatal.IsNullable = false;
				colvarIdAntecedentePerinatal.IsPrimaryKey = true;
				colvarIdAntecedentePerinatal.IsForeignKey = false;
				colvarIdAntecedentePerinatal.IsReadOnly = false;
				colvarIdAntecedentePerinatal.DefaultSetting = @"";
				colvarIdAntecedentePerinatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAntecedentePerinatal);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarFechaGestacion = new TableSchema.TableColumn(schema);
				colvarFechaGestacion.ColumnName = "FechaGestacion";
				colvarFechaGestacion.DataType = DbType.DateTime;
				colvarFechaGestacion.MaxLength = 0;
				colvarFechaGestacion.AutoIncrement = false;
				colvarFechaGestacion.IsNullable = false;
				colvarFechaGestacion.IsPrimaryKey = false;
				colvarFechaGestacion.IsForeignKey = false;
				colvarFechaGestacion.IsReadOnly = false;
				colvarFechaGestacion.DefaultSetting = @"";
				colvarFechaGestacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaGestacion);
				
				TableSchema.TableColumn colvarFechaFinalizacion = new TableSchema.TableColumn(schema);
				colvarFechaFinalizacion.ColumnName = "FechaFinalizacion";
				colvarFechaFinalizacion.DataType = DbType.DateTime;
				colvarFechaFinalizacion.MaxLength = 0;
				colvarFechaFinalizacion.AutoIncrement = false;
				colvarFechaFinalizacion.IsNullable = false;
				colvarFechaFinalizacion.IsPrimaryKey = false;
				colvarFechaFinalizacion.IsForeignKey = false;
				colvarFechaFinalizacion.IsReadOnly = false;
				colvarFechaFinalizacion.DefaultSetting = @"";
				colvarFechaFinalizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFinalizacion);
				
				TableSchema.TableColumn colvarIdModoFinalizacionEmbarazo = new TableSchema.TableColumn(schema);
				colvarIdModoFinalizacionEmbarazo.ColumnName = "idModoFinalizacionEmbarazo";
				colvarIdModoFinalizacionEmbarazo.DataType = DbType.Int32;
				colvarIdModoFinalizacionEmbarazo.MaxLength = 0;
				colvarIdModoFinalizacionEmbarazo.AutoIncrement = false;
				colvarIdModoFinalizacionEmbarazo.IsNullable = false;
				colvarIdModoFinalizacionEmbarazo.IsPrimaryKey = false;
				colvarIdModoFinalizacionEmbarazo.IsForeignKey = false;
				colvarIdModoFinalizacionEmbarazo.IsReadOnly = false;
				colvarIdModoFinalizacionEmbarazo.DefaultSetting = @"";
				colvarIdModoFinalizacionEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdModoFinalizacionEmbarazo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_AntecedentePerinatal",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAntecedentePerinatal")]
		[Bindable(true)]
		public int IdAntecedentePerinatal 
		{
			get { return GetColumnValue<int>(Columns.IdAntecedentePerinatal); }
			set { SetColumnValue(Columns.IdAntecedentePerinatal, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("FechaGestacion")]
		[Bindable(true)]
		public DateTime FechaGestacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaGestacion); }
			set { SetColumnValue(Columns.FechaGestacion, value); }
		}
		  
		[XmlAttribute("FechaFinalizacion")]
		[Bindable(true)]
		public DateTime FechaFinalizacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaFinalizacion); }
			set { SetColumnValue(Columns.FechaFinalizacion, value); }
		}
		  
		[XmlAttribute("IdModoFinalizacionEmbarazo")]
		[Bindable(true)]
		public int IdModoFinalizacionEmbarazo 
		{
			get { return GetColumnValue<int>(Columns.IdModoFinalizacionEmbarazo); }
			set { SetColumnValue(Columns.IdModoFinalizacionEmbarazo, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprAntecedentePerinatalNacimientoCollection colAprAntecedentePerinatalNacimientoRecords;
		public DalSic.AprAntecedentePerinatalNacimientoCollection AprAntecedentePerinatalNacimientoRecords
		{
			get
			{
				if(colAprAntecedentePerinatalNacimientoRecords == null)
				{
					colAprAntecedentePerinatalNacimientoRecords = new DalSic.AprAntecedentePerinatalNacimientoCollection().Where(AprAntecedentePerinatalNacimiento.Columns.IdAntecedentePerinatal, IdAntecedentePerinatal).Load();
					colAprAntecedentePerinatalNacimientoRecords.ListChanged += new ListChangedEventHandler(colAprAntecedentePerinatalNacimientoRecords_ListChanged);
				}
				return colAprAntecedentePerinatalNacimientoRecords;			
			}
			set 
			{ 
					colAprAntecedentePerinatalNacimientoRecords = value; 
					colAprAntecedentePerinatalNacimientoRecords.ListChanged += new ListChangedEventHandler(colAprAntecedentePerinatalNacimientoRecords_ListChanged);
			}
		}
		
		void colAprAntecedentePerinatalNacimientoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAntecedentePerinatalNacimientoRecords[e.NewIndex].IdAntecedentePerinatal = IdAntecedentePerinatal;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int varIdPaciente,DateTime varFechaGestacion,DateTime varFechaFinalizacion,int varIdModoFinalizacionEmbarazo)
		{
			AprAntecedentePerinatal item = new AprAntecedentePerinatal();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.FechaGestacion = varFechaGestacion;
			
			item.FechaFinalizacion = varFechaFinalizacion;
			
			item.IdModoFinalizacionEmbarazo = varIdModoFinalizacionEmbarazo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAntecedentePerinatal,int varIdEfector,int varIdPaciente,DateTime varFechaGestacion,DateTime varFechaFinalizacion,int varIdModoFinalizacionEmbarazo)
		{
			AprAntecedentePerinatal item = new AprAntecedentePerinatal();
			
				item.IdAntecedentePerinatal = varIdAntecedentePerinatal;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.FechaGestacion = varFechaGestacion;
			
				item.FechaFinalizacion = varFechaFinalizacion;
			
				item.IdModoFinalizacionEmbarazo = varIdModoFinalizacionEmbarazo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAntecedentePerinatalColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaGestacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFinalizacionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IdModoFinalizacionEmbarazoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAntecedentePerinatal = @"idAntecedentePerinatal";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string FechaGestacion = @"FechaGestacion";
			 public static string FechaFinalizacion = @"FechaFinalizacion";
			 public static string IdModoFinalizacionEmbarazo = @"idModoFinalizacionEmbarazo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprAntecedentePerinatalNacimientoRecords != null)
                {
                    foreach (DalSic.AprAntecedentePerinatalNacimiento item in colAprAntecedentePerinatalNacimientoRecords)
                    {
                        if (item.IdAntecedentePerinatal != IdAntecedentePerinatal)
                        {
                            item.IdAntecedentePerinatal = IdAntecedentePerinatal;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprAntecedentePerinatalNacimientoRecords != null)
                {
                    colAprAntecedentePerinatalNacimientoRecords.SaveAll();
               }
		}
        #endregion
	}
}
