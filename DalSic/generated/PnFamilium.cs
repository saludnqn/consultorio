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
	/// Strongly-typed collection for the PnFamilium class.
	/// </summary>
    [Serializable]
	public partial class PnFamiliumCollection : ActiveList<PnFamilium, PnFamiliumCollection>
	{	   
		public PnFamiliumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnFamiliumCollection</returns>
		public PnFamiliumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnFamilium o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_familia table.
	/// </summary>
	[Serializable]
	public partial class PnFamilium : ActiveRecord<PnFamilium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnFamilium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnFamilium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnFamilium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnFamilium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_familia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdFamilia = new TableSchema.TableColumn(schema);
				colvarIdFamilia.ColumnName = "id_familia";
				colvarIdFamilia.DataType = DbType.Int32;
				colvarIdFamilia.MaxLength = 0;
				colvarIdFamilia.AutoIncrement = true;
				colvarIdFamilia.IsNullable = false;
				colvarIdFamilia.IsPrimaryKey = true;
				colvarIdFamilia.IsForeignKey = false;
				colvarIdFamilia.IsReadOnly = false;
				colvarIdFamilia.DefaultSetting = @"";
				colvarIdFamilia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdFamilia);
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = false;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = false;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
				TableSchema.TableColumn colvarRelacion = new TableSchema.TableColumn(schema);
				colvarRelacion.ColumnName = "relacion";
				colvarRelacion.DataType = DbType.AnsiString;
				colvarRelacion.MaxLength = -1;
				colvarRelacion.AutoIncrement = false;
				colvarRelacion.IsNullable = false;
				colvarRelacion.IsPrimaryKey = false;
				colvarRelacion.IsForeignKey = false;
				colvarRelacion.IsReadOnly = false;
				colvarRelacion.DefaultSetting = @"";
				colvarRelacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRelacion);
				
				TableSchema.TableColumn colvarNombreApellido = new TableSchema.TableColumn(schema);
				colvarNombreApellido.ColumnName = "nombre_apellido";
				colvarNombreApellido.DataType = DbType.AnsiString;
				colvarNombreApellido.MaxLength = -1;
				colvarNombreApellido.AutoIncrement = false;
				colvarNombreApellido.IsNullable = false;
				colvarNombreApellido.IsPrimaryKey = false;
				colvarNombreApellido.IsForeignKey = false;
				colvarNombreApellido.IsReadOnly = false;
				colvarNombreApellido.DefaultSetting = @"";
				colvarNombreApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreApellido);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fecha_nacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = -1;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarDni = new TableSchema.TableColumn(schema);
				colvarDni.ColumnName = "dni";
				colvarDni.DataType = DbType.AnsiString;
				colvarDni.MaxLength = -1;
				colvarDni.AutoIncrement = false;
				colvarDni.IsNullable = true;
				colvarDni.IsPrimaryKey = false;
				colvarDni.IsForeignKey = false;
				colvarDni.IsReadOnly = false;
				colvarDni.DefaultSetting = @"";
				colvarDni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDni);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_familia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdFamilia")]
		[Bindable(true)]
		public int IdFamilia 
		{
			get { return GetColumnValue<int>(Columns.IdFamilia); }
			set { SetColumnValue(Columns.IdFamilia, value); }
		}
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
		}
		  
		[XmlAttribute("Relacion")]
		[Bindable(true)]
		public string Relacion 
		{
			get { return GetColumnValue<string>(Columns.Relacion); }
			set { SetColumnValue(Columns.Relacion, value); }
		}
		  
		[XmlAttribute("NombreApellido")]
		[Bindable(true)]
		public string NombreApellido 
		{
			get { return GetColumnValue<string>(Columns.NombreApellido); }
			set { SetColumnValue(Columns.NombreApellido, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Dni")]
		[Bindable(true)]
		public string Dni 
		{
			get { return GetColumnValue<string>(Columns.Dni); }
			set { SetColumnValue(Columns.Dni, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdLegajo,string varRelacion,string varNombreApellido,DateTime? varFechaNacimiento,string varDomicilio,string varDni)
		{
			PnFamilium item = new PnFamilium();
			
			item.IdLegajo = varIdLegajo;
			
			item.Relacion = varRelacion;
			
			item.NombreApellido = varNombreApellido;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.Domicilio = varDomicilio;
			
			item.Dni = varDni;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdFamilia,int varIdLegajo,string varRelacion,string varNombreApellido,DateTime? varFechaNacimiento,string varDomicilio,string varDni)
		{
			PnFamilium item = new PnFamilium();
			
				item.IdFamilia = varIdFamilia;
			
				item.IdLegajo = varIdLegajo;
			
				item.Relacion = varRelacion;
			
				item.NombreApellido = varNombreApellido;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.Domicilio = varDomicilio;
			
				item.Dni = varDni;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdFamiliaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RelacionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreApellidoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DniColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdFamilia = @"id_familia";
			 public static string IdLegajo = @"id_legajo";
			 public static string Relacion = @"relacion";
			 public static string NombreApellido = @"nombre_apellido";
			 public static string FechaNacimiento = @"fecha_nacimiento";
			 public static string Domicilio = @"domicilio";
			 public static string Dni = @"dni";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
