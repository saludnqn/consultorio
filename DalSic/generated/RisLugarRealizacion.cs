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
	/// Strongly-typed collection for the RisLugarRealizacion class.
	/// </summary>
    [Serializable]
	public partial class RisLugarRealizacionCollection : ActiveList<RisLugarRealizacion, RisLugarRealizacionCollection>
	{	   
		public RisLugarRealizacionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RisLugarRealizacionCollection</returns>
		public RisLugarRealizacionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RisLugarRealizacion o = this[i];
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
	/// This is an ActiveRecord class which wraps the RIS_LugarRealizacion table.
	/// </summary>
	[Serializable]
	public partial class RisLugarRealizacion : ActiveRecord<RisLugarRealizacion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RisLugarRealizacion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RisLugarRealizacion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RisLugarRealizacion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RisLugarRealizacion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RIS_LugarRealizacion", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLugarRealizacion = new TableSchema.TableColumn(schema);
				colvarIdLugarRealizacion.ColumnName = "idLugarRealizacion";
				colvarIdLugarRealizacion.DataType = DbType.Int32;
				colvarIdLugarRealizacion.MaxLength = 0;
				colvarIdLugarRealizacion.AutoIncrement = true;
				colvarIdLugarRealizacion.IsNullable = false;
				colvarIdLugarRealizacion.IsPrimaryKey = true;
				colvarIdLugarRealizacion.IsForeignKey = false;
				colvarIdLugarRealizacion.IsReadOnly = false;
				colvarIdLugarRealizacion.DefaultSetting = @"";
				colvarIdLugarRealizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLugarRealizacion);
				
				TableSchema.TableColumn colvarIdEstudio = new TableSchema.TableColumn(schema);
				colvarIdEstudio.ColumnName = "idEstudio";
				colvarIdEstudio.DataType = DbType.Int32;
				colvarIdEstudio.MaxLength = 0;
				colvarIdEstudio.AutoIncrement = false;
				colvarIdEstudio.IsNullable = false;
				colvarIdEstudio.IsPrimaryKey = false;
				colvarIdEstudio.IsForeignKey = false;
				colvarIdEstudio.IsReadOnly = false;
				colvarIdEstudio.DefaultSetting = @"";
				colvarIdEstudio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEstudio);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = 100;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = false;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
				TableSchema.TableColumn colvarAmbito = new TableSchema.TableColumn(schema);
				colvarAmbito.ColumnName = "ambito";
				colvarAmbito.DataType = DbType.AnsiString;
				colvarAmbito.MaxLength = 100;
				colvarAmbito.AutoIncrement = false;
				colvarAmbito.IsNullable = false;
				colvarAmbito.IsPrimaryKey = false;
				colvarAmbito.IsForeignKey = false;
				colvarAmbito.IsReadOnly = false;
				colvarAmbito.DefaultSetting = @"";
				colvarAmbito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmbito);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = 100;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = false;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarCp = new TableSchema.TableColumn(schema);
				colvarCp.ColumnName = "cp";
				colvarCp.DataType = DbType.AnsiString;
				colvarCp.MaxLength = 100;
				colvarCp.AutoIncrement = false;
				colvarCp.IsNullable = false;
				colvarCp.IsPrimaryKey = false;
				colvarCp.IsForeignKey = false;
				colvarCp.IsReadOnly = false;
				colvarCp.DefaultSetting = @"";
				colvarCp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCp);
				
				TableSchema.TableColumn colvarCiudad = new TableSchema.TableColumn(schema);
				colvarCiudad.ColumnName = "ciudad";
				colvarCiudad.DataType = DbType.AnsiString;
				colvarCiudad.MaxLength = 100;
				colvarCiudad.AutoIncrement = false;
				colvarCiudad.IsNullable = false;
				colvarCiudad.IsPrimaryKey = false;
				colvarCiudad.IsForeignKey = false;
				colvarCiudad.IsReadOnly = false;
				colvarCiudad.DefaultSetting = @"";
				colvarCiudad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCiudad);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 100;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = false;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "responsable";
				colvarResponsable.DataType = DbType.AnsiString;
				colvarResponsable.MaxLength = 100;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = false;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				TableSchema.TableColumn colvarCargo = new TableSchema.TableColumn(schema);
				colvarCargo.ColumnName = "cargo";
				colvarCargo.DataType = DbType.AnsiString;
				colvarCargo.MaxLength = 100;
				colvarCargo.AutoIncrement = false;
				colvarCargo.IsNullable = false;
				colvarCargo.IsPrimaryKey = false;
				colvarCargo.IsForeignKey = false;
				colvarCargo.IsReadOnly = false;
				colvarCargo.DefaultSetting = @"";
				colvarCargo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCargo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("RIS_LugarRealizacion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLugarRealizacion")]
		[Bindable(true)]
		public int IdLugarRealizacion 
		{
			get { return GetColumnValue<int>(Columns.IdLugarRealizacion); }
			set { SetColumnValue(Columns.IdLugarRealizacion, value); }
		}
		  
		[XmlAttribute("IdEstudio")]
		[Bindable(true)]
		public int IdEstudio 
		{
			get { return GetColumnValue<int>(Columns.IdEstudio); }
			set { SetColumnValue(Columns.IdEstudio, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Ambito")]
		[Bindable(true)]
		public string Ambito 
		{
			get { return GetColumnValue<string>(Columns.Ambito); }
			set { SetColumnValue(Columns.Ambito, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Cp")]
		[Bindable(true)]
		public string Cp 
		{
			get { return GetColumnValue<string>(Columns.Cp); }
			set { SetColumnValue(Columns.Cp, value); }
		}
		  
		[XmlAttribute("Ciudad")]
		[Bindable(true)]
		public string Ciudad 
		{
			get { return GetColumnValue<string>(Columns.Ciudad); }
			set { SetColumnValue(Columns.Ciudad, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		  
		[XmlAttribute("Cargo")]
		[Bindable(true)]
		public string Cargo 
		{
			get { return GetColumnValue<string>(Columns.Cargo); }
			set { SetColumnValue(Columns.Cargo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEstudio,string varDescripcion,string varAmbito,string varDomicilio,string varCp,string varCiudad,string varEmail,string varResponsable,string varCargo)
		{
			RisLugarRealizacion item = new RisLugarRealizacion();
			
			item.IdEstudio = varIdEstudio;
			
			item.Descripcion = varDescripcion;
			
			item.Ambito = varAmbito;
			
			item.Domicilio = varDomicilio;
			
			item.Cp = varCp;
			
			item.Ciudad = varCiudad;
			
			item.Email = varEmail;
			
			item.Responsable = varResponsable;
			
			item.Cargo = varCargo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLugarRealizacion,int varIdEstudio,string varDescripcion,string varAmbito,string varDomicilio,string varCp,string varCiudad,string varEmail,string varResponsable,string varCargo)
		{
			RisLugarRealizacion item = new RisLugarRealizacion();
			
				item.IdLugarRealizacion = varIdLugarRealizacion;
			
				item.IdEstudio = varIdEstudio;
			
				item.Descripcion = varDescripcion;
			
				item.Ambito = varAmbito;
			
				item.Domicilio = varDomicilio;
			
				item.Cp = varCp;
			
				item.Ciudad = varCiudad;
			
				item.Email = varEmail;
			
				item.Responsable = varResponsable;
			
				item.Cargo = varCargo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLugarRealizacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstudioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AmbitoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CpColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CiudadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CargoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLugarRealizacion = @"idLugarRealizacion";
			 public static string IdEstudio = @"idEstudio";
			 public static string Descripcion = @"descripcion";
			 public static string Ambito = @"ambito";
			 public static string Domicilio = @"domicilio";
			 public static string Cp = @"cp";
			 public static string Ciudad = @"ciudad";
			 public static string Email = @"email";
			 public static string Responsable = @"responsable";
			 public static string Cargo = @"cargo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
