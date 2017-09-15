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
	/// Strongly-typed collection for the TupTurnosProtegido class.
	/// </summary>
    [Serializable]
	public partial class TupTurnosProtegidoCollection : ActiveList<TupTurnosProtegido, TupTurnosProtegidoCollection>
	{	   
		public TupTurnosProtegidoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TupTurnosProtegidoCollection</returns>
		public TupTurnosProtegidoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TupTurnosProtegido o = this[i];
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
	/// This is an ActiveRecord class which wraps the TUP_TurnosProtegidos table.
	/// </summary>
	[Serializable]
	public partial class TupTurnosProtegido : ActiveRecord<TupTurnosProtegido>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TupTurnosProtegido()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TupTurnosProtegido(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TupTurnosProtegido(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TupTurnosProtegido(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TUP_TurnosProtegidos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdTurnoSubsecretaria = new TableSchema.TableColumn(schema);
				colvarIdTurnoSubsecretaria.ColumnName = "idTurnoSubsecretaria";
				colvarIdTurnoSubsecretaria.DataType = DbType.Int32;
				colvarIdTurnoSubsecretaria.MaxLength = 0;
				colvarIdTurnoSubsecretaria.AutoIncrement = true;
				colvarIdTurnoSubsecretaria.IsNullable = false;
				colvarIdTurnoSubsecretaria.IsPrimaryKey = true;
				colvarIdTurnoSubsecretaria.IsForeignKey = false;
				colvarIdTurnoSubsecretaria.IsReadOnly = false;
				colvarIdTurnoSubsecretaria.DefaultSetting = @"";
				colvarIdTurnoSubsecretaria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoSubsecretaria);
				
				TableSchema.TableColumn colvarIdInterconsulta = new TableSchema.TableColumn(schema);
				colvarIdInterconsulta.ColumnName = "idInterconsulta";
				colvarIdInterconsulta.DataType = DbType.Int32;
				colvarIdInterconsulta.MaxLength = 0;
				colvarIdInterconsulta.AutoIncrement = false;
				colvarIdInterconsulta.IsNullable = false;
				colvarIdInterconsulta.IsPrimaryKey = false;
				colvarIdInterconsulta.IsForeignKey = false;
				colvarIdInterconsulta.IsReadOnly = false;
				colvarIdInterconsulta.DefaultSetting = @"";
				colvarIdInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInterconsulta);
				
				TableSchema.TableColumn colvarIdTurnoEfector = new TableSchema.TableColumn(schema);
				colvarIdTurnoEfector.ColumnName = "idTurnoEfector";
				colvarIdTurnoEfector.DataType = DbType.Int32;
				colvarIdTurnoEfector.MaxLength = 0;
				colvarIdTurnoEfector.AutoIncrement = false;
				colvarIdTurnoEfector.IsNullable = false;
				colvarIdTurnoEfector.IsPrimaryKey = false;
				colvarIdTurnoEfector.IsForeignKey = false;
				colvarIdTurnoEfector.IsReadOnly = false;
				colvarIdTurnoEfector.DefaultSetting = @"";
				colvarIdTurnoEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTurnoEfector);
				
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
				
				TableSchema.TableColumn colvarIdExternoEspecialidad = new TableSchema.TableColumn(schema);
				colvarIdExternoEspecialidad.ColumnName = "idExternoEspecialidad";
				colvarIdExternoEspecialidad.DataType = DbType.Int32;
				colvarIdExternoEspecialidad.MaxLength = 0;
				colvarIdExternoEspecialidad.AutoIncrement = false;
				colvarIdExternoEspecialidad.IsNullable = false;
				colvarIdExternoEspecialidad.IsPrimaryKey = false;
				colvarIdExternoEspecialidad.IsForeignKey = false;
				colvarIdExternoEspecialidad.IsReadOnly = false;
				colvarIdExternoEspecialidad.DefaultSetting = @"";
				colvarIdExternoEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExternoEspecialidad);
				
				TableSchema.TableColumn colvarNombreEspecialidad = new TableSchema.TableColumn(schema);
				colvarNombreEspecialidad.ColumnName = "nombreEspecialidad";
				colvarNombreEspecialidad.DataType = DbType.AnsiString;
				colvarNombreEspecialidad.MaxLength = 200;
				colvarNombreEspecialidad.AutoIncrement = false;
				colvarNombreEspecialidad.IsNullable = false;
				colvarNombreEspecialidad.IsPrimaryKey = false;
				colvarNombreEspecialidad.IsForeignKey = false;
				colvarNombreEspecialidad.IsReadOnly = false;
				colvarNombreEspecialidad.DefaultSetting = @"";
				colvarNombreEspecialidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreEspecialidad);
				
				TableSchema.TableColumn colvarIdExternoProfesional = new TableSchema.TableColumn(schema);
				colvarIdExternoProfesional.ColumnName = "idExternoProfesional";
				colvarIdExternoProfesional.DataType = DbType.Int32;
				colvarIdExternoProfesional.MaxLength = 0;
				colvarIdExternoProfesional.AutoIncrement = false;
				colvarIdExternoProfesional.IsNullable = false;
				colvarIdExternoProfesional.IsPrimaryKey = false;
				colvarIdExternoProfesional.IsForeignKey = false;
				colvarIdExternoProfesional.IsReadOnly = false;
				colvarIdExternoProfesional.DefaultSetting = @"";
				colvarIdExternoProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdExternoProfesional);
				
				TableSchema.TableColumn colvarNombreProfesional = new TableSchema.TableColumn(schema);
				colvarNombreProfesional.ColumnName = "nombreProfesional";
				colvarNombreProfesional.DataType = DbType.AnsiString;
				colvarNombreProfesional.MaxLength = 200;
				colvarNombreProfesional.AutoIncrement = false;
				colvarNombreProfesional.IsNullable = false;
				colvarNombreProfesional.IsPrimaryKey = false;
				colvarNombreProfesional.IsForeignKey = false;
				colvarNombreProfesional.IsReadOnly = false;
				colvarNombreProfesional.DefaultSetting = @"";
				colvarNombreProfesional.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreProfesional);
				
				TableSchema.TableColumn colvarFechaTurno = new TableSchema.TableColumn(schema);
				colvarFechaTurno.ColumnName = "fechaTurno";
				colvarFechaTurno.DataType = DbType.DateTime;
				colvarFechaTurno.MaxLength = 0;
				colvarFechaTurno.AutoIncrement = false;
				colvarFechaTurno.IsNullable = false;
				colvarFechaTurno.IsPrimaryKey = false;
				colvarFechaTurno.IsForeignKey = false;
				colvarFechaTurno.IsReadOnly = false;
				colvarFechaTurno.DefaultSetting = @"";
				colvarFechaTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTurno);
				
				TableSchema.TableColumn colvarHoraTurno = new TableSchema.TableColumn(schema);
				colvarHoraTurno.ColumnName = "horaTurno";
				colvarHoraTurno.DataType = DbType.DateTime;
				colvarHoraTurno.MaxLength = 0;
				colvarHoraTurno.AutoIncrement = false;
				colvarHoraTurno.IsNullable = false;
				colvarHoraTurno.IsPrimaryKey = false;
				colvarHoraTurno.IsForeignKey = false;
				colvarHoraTurno.IsReadOnly = false;
				colvarHoraTurno.DefaultSetting = @"";
				colvarHoraTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraTurno);
				
				TableSchema.TableColumn colvarIdUsuarioCarga = new TableSchema.TableColumn(schema);
				colvarIdUsuarioCarga.ColumnName = "idUsuarioCarga";
				colvarIdUsuarioCarga.DataType = DbType.Int32;
				colvarIdUsuarioCarga.MaxLength = 0;
				colvarIdUsuarioCarga.AutoIncrement = false;
				colvarIdUsuarioCarga.IsNullable = false;
				colvarIdUsuarioCarga.IsPrimaryKey = false;
				colvarIdUsuarioCarga.IsForeignKey = false;
				colvarIdUsuarioCarga.IsReadOnly = false;
				colvarIdUsuarioCarga.DefaultSetting = @"";
				colvarIdUsuarioCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuarioCarga);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("TUP_TurnosProtegidos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdTurnoSubsecretaria")]
		[Bindable(true)]
		public int IdTurnoSubsecretaria 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoSubsecretaria); }
			set { SetColumnValue(Columns.IdTurnoSubsecretaria, value); }
		}
		  
		[XmlAttribute("IdInterconsulta")]
		[Bindable(true)]
		public int IdInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdInterconsulta); }
			set { SetColumnValue(Columns.IdInterconsulta, value); }
		}
		  
		[XmlAttribute("IdTurnoEfector")]
		[Bindable(true)]
		public int IdTurnoEfector 
		{
			get { return GetColumnValue<int>(Columns.IdTurnoEfector); }
			set { SetColumnValue(Columns.IdTurnoEfector, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdExternoEspecialidad")]
		[Bindable(true)]
		public int IdExternoEspecialidad 
		{
			get { return GetColumnValue<int>(Columns.IdExternoEspecialidad); }
			set { SetColumnValue(Columns.IdExternoEspecialidad, value); }
		}
		  
		[XmlAttribute("NombreEspecialidad")]
		[Bindable(true)]
		public string NombreEspecialidad 
		{
			get { return GetColumnValue<string>(Columns.NombreEspecialidad); }
			set { SetColumnValue(Columns.NombreEspecialidad, value); }
		}
		  
		[XmlAttribute("IdExternoProfesional")]
		[Bindable(true)]
		public int IdExternoProfesional 
		{
			get { return GetColumnValue<int>(Columns.IdExternoProfesional); }
			set { SetColumnValue(Columns.IdExternoProfesional, value); }
		}
		  
		[XmlAttribute("NombreProfesional")]
		[Bindable(true)]
		public string NombreProfesional 
		{
			get { return GetColumnValue<string>(Columns.NombreProfesional); }
			set { SetColumnValue(Columns.NombreProfesional, value); }
		}
		  
		[XmlAttribute("FechaTurno")]
		[Bindable(true)]
		public DateTime FechaTurno 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaTurno); }
			set { SetColumnValue(Columns.FechaTurno, value); }
		}
		  
		[XmlAttribute("HoraTurno")]
		[Bindable(true)]
		public DateTime HoraTurno 
		{
			get { return GetColumnValue<DateTime>(Columns.HoraTurno); }
			set { SetColumnValue(Columns.HoraTurno, value); }
		}
		  
		[XmlAttribute("IdUsuarioCarga")]
		[Bindable(true)]
		public int IdUsuarioCarga 
		{
			get { return GetColumnValue<int>(Columns.IdUsuarioCarga); }
			set { SetColumnValue(Columns.IdUsuarioCarga, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInterconsulta,int varIdTurnoEfector,int varIdEfector,int varIdExternoEspecialidad,string varNombreEspecialidad,int varIdExternoProfesional,string varNombreProfesional,DateTime varFechaTurno,DateTime varHoraTurno,int varIdUsuarioCarga)
		{
			TupTurnosProtegido item = new TupTurnosProtegido();
			
			item.IdInterconsulta = varIdInterconsulta;
			
			item.IdTurnoEfector = varIdTurnoEfector;
			
			item.IdEfector = varIdEfector;
			
			item.IdExternoEspecialidad = varIdExternoEspecialidad;
			
			item.NombreEspecialidad = varNombreEspecialidad;
			
			item.IdExternoProfesional = varIdExternoProfesional;
			
			item.NombreProfesional = varNombreProfesional;
			
			item.FechaTurno = varFechaTurno;
			
			item.HoraTurno = varHoraTurno;
			
			item.IdUsuarioCarga = varIdUsuarioCarga;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdTurnoSubsecretaria,int varIdInterconsulta,int varIdTurnoEfector,int varIdEfector,int varIdExternoEspecialidad,string varNombreEspecialidad,int varIdExternoProfesional,string varNombreProfesional,DateTime varFechaTurno,DateTime varHoraTurno,int varIdUsuarioCarga)
		{
			TupTurnosProtegido item = new TupTurnosProtegido();
			
				item.IdTurnoSubsecretaria = varIdTurnoSubsecretaria;
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.IdTurnoEfector = varIdTurnoEfector;
			
				item.IdEfector = varIdEfector;
			
				item.IdExternoEspecialidad = varIdExternoEspecialidad;
			
				item.NombreEspecialidad = varNombreEspecialidad;
			
				item.IdExternoProfesional = varIdExternoProfesional;
			
				item.NombreProfesional = varNombreProfesional;
			
				item.FechaTurno = varFechaTurno;
			
				item.HoraTurno = varHoraTurno;
			
				item.IdUsuarioCarga = varIdUsuarioCarga;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdTurnoSubsecretariaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTurnoEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExternoEspecialidadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreEspecialidadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdExternoProfesionalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreProfesionalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTurnoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraTurnoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioCargaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdTurnoSubsecretaria = @"idTurnoSubsecretaria";
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string IdTurnoEfector = @"idTurnoEfector";
			 public static string IdEfector = @"idEfector";
			 public static string IdExternoEspecialidad = @"idExternoEspecialidad";
			 public static string NombreEspecialidad = @"nombreEspecialidad";
			 public static string IdExternoProfesional = @"idExternoProfesional";
			 public static string NombreProfesional = @"nombreProfesional";
			 public static string FechaTurno = @"fechaTurno";
			 public static string HoraTurno = @"horaTurno";
			 public static string IdUsuarioCarga = @"idUsuarioCarga";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
