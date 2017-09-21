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
	/// Strongly-typed collection for the ConTurnoReservaInterconsultum class.
	/// </summary>
    [Serializable]
	public partial class ConTurnoReservaInterconsultumCollection : ActiveList<ConTurnoReservaInterconsultum, ConTurnoReservaInterconsultumCollection>
	{	   
		public ConTurnoReservaInterconsultumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConTurnoReservaInterconsultumCollection</returns>
		public ConTurnoReservaInterconsultumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConTurnoReservaInterconsultum o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_TurnoReservaInterconsulta table.
	/// </summary>
	[Serializable]
	public partial class ConTurnoReservaInterconsultum : ActiveRecord<ConTurnoReservaInterconsultum>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConTurnoReservaInterconsultum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConTurnoReservaInterconsultum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConTurnoReservaInterconsultum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConTurnoReservaInterconsultum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_TurnoReservaInterconsulta", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdInterconsulta = new TableSchema.TableColumn(schema);
				colvarIdInterconsulta.ColumnName = "idInterconsulta";
				colvarIdInterconsulta.DataType = DbType.Int32;
				colvarIdInterconsulta.MaxLength = 0;
				colvarIdInterconsulta.AutoIncrement = true;
				colvarIdInterconsulta.IsNullable = false;
				colvarIdInterconsulta.IsPrimaryKey = true;
				colvarIdInterconsulta.IsForeignKey = false;
				colvarIdInterconsulta.IsReadOnly = false;
				colvarIdInterconsulta.DefaultSetting = @"";
				colvarIdInterconsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInterconsulta);
				
				TableSchema.TableColumn colvarIdAgenda = new TableSchema.TableColumn(schema);
				colvarIdAgenda.ColumnName = "idAgenda";
				colvarIdAgenda.DataType = DbType.Int32;
				colvarIdAgenda.MaxLength = 0;
				colvarIdAgenda.AutoIncrement = false;
				colvarIdAgenda.IsNullable = false;
				colvarIdAgenda.IsPrimaryKey = false;
				colvarIdAgenda.IsForeignKey = true;
				colvarIdAgenda.IsReadOnly = false;
				colvarIdAgenda.DefaultSetting = @"";
				
					colvarIdAgenda.ForeignKeyTableName = "CON_Agenda";
				schema.Columns.Add(colvarIdAgenda);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarHoraTurno = new TableSchema.TableColumn(schema);
				colvarHoraTurno.ColumnName = "horaTurno";
				colvarHoraTurno.DataType = DbType.AnsiStringFixedLength;
				colvarHoraTurno.MaxLength = 5;
				colvarHoraTurno.AutoIncrement = false;
				colvarHoraTurno.IsNullable = false;
				colvarHoraTurno.IsPrimaryKey = false;
				colvarHoraTurno.IsForeignKey = false;
				colvarHoraTurno.IsReadOnly = false;
				colvarHoraTurno.DefaultSetting = @"";
				colvarHoraTurno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoraTurno);
				
				TableSchema.TableColumn colvarReservaHasta = new TableSchema.TableColumn(schema);
				colvarReservaHasta.ColumnName = "reservaHasta";
				colvarReservaHasta.DataType = DbType.DateTime;
				colvarReservaHasta.MaxLength = 0;
				colvarReservaHasta.AutoIncrement = false;
				colvarReservaHasta.IsNullable = false;
				colvarReservaHasta.IsPrimaryKey = false;
				colvarReservaHasta.IsForeignKey = false;
				colvarReservaHasta.IsReadOnly = false;
				colvarReservaHasta.DefaultSetting = @"";
				colvarReservaHasta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReservaHasta);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_TurnoReservaInterconsulta",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdInterconsulta")]
		[Bindable(true)]
		public int IdInterconsulta 
		{
			get { return GetColumnValue<int>(Columns.IdInterconsulta); }
			set { SetColumnValue(Columns.IdInterconsulta, value); }
		}
		  
		[XmlAttribute("IdAgenda")]
		[Bindable(true)]
		public int IdAgenda 
		{
			get { return GetColumnValue<int>(Columns.IdAgenda); }
			set { SetColumnValue(Columns.IdAgenda, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("HoraTurno")]
		[Bindable(true)]
		public string HoraTurno 
		{
			get { return GetColumnValue<string>(Columns.HoraTurno); }
			set { SetColumnValue(Columns.HoraTurno, value); }
		}
		  
		[XmlAttribute("ReservaHasta")]
		[Bindable(true)]
		public DateTime ReservaHasta 
		{
			get { return GetColumnValue<DateTime>(Columns.ReservaHasta); }
			set { SetColumnValue(Columns.ReservaHasta, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this ConTurnoReservaInterconsultum
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a ConAgenda ActiveRecord object related to this ConTurnoReservaInterconsultum
		/// 
		/// </summary>
		public DalSic.ConAgenda ConAgenda
		{
			get { return DalSic.ConAgenda.FetchByID(this.IdAgenda); }
			set { SetColumnValue("idAgenda", value.IdAgenda); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdAgenda,int varIdEfector,string varHoraTurno,DateTime varReservaHasta)
		{
			ConTurnoReservaInterconsultum item = new ConTurnoReservaInterconsultum();
			
			item.IdAgenda = varIdAgenda;
			
			item.IdEfector = varIdEfector;
			
			item.HoraTurno = varHoraTurno;
			
			item.ReservaHasta = varReservaHasta;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdInterconsulta,int varIdAgenda,int varIdEfector,string varHoraTurno,DateTime varReservaHasta)
		{
			ConTurnoReservaInterconsultum item = new ConTurnoReservaInterconsultum();
			
				item.IdInterconsulta = varIdInterconsulta;
			
				item.IdAgenda = varIdAgenda;
			
				item.IdEfector = varIdEfector;
			
				item.HoraTurno = varHoraTurno;
			
				item.ReservaHasta = varReservaHasta;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdInterconsultaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAgendaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HoraTurnoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ReservaHastaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdInterconsulta = @"idInterconsulta";
			 public static string IdAgenda = @"idAgenda";
			 public static string IdEfector = @"idEfector";
			 public static string HoraTurno = @"horaTurno";
			 public static string ReservaHasta = @"reservaHasta";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
