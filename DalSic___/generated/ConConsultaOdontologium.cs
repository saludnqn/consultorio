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
	/// Strongly-typed collection for the ConConsultaOdontologium class.
	/// </summary>
    [Serializable]
	public partial class ConConsultaOdontologiumCollection : ActiveList<ConConsultaOdontologium, ConConsultaOdontologiumCollection>
	{	   
		public ConConsultaOdontologiumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ConConsultaOdontologiumCollection</returns>
		public ConConsultaOdontologiumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ConConsultaOdontologium o = this[i];
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
	/// This is an ActiveRecord class which wraps the CON_ConsultaOdontologia table.
	/// </summary>
	[Serializable]
	public partial class ConConsultaOdontologium : ActiveRecord<ConConsultaOdontologium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ConConsultaOdontologium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ConConsultaOdontologium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ConConsultaOdontologium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ConConsultaOdontologium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CON_ConsultaOdontologia", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdConsultaOdontologia = new TableSchema.TableColumn(schema);
				colvarIdConsultaOdontologia.ColumnName = "idConsultaOdontologia";
				colvarIdConsultaOdontologia.DataType = DbType.Int32;
				colvarIdConsultaOdontologia.MaxLength = 0;
				colvarIdConsultaOdontologia.AutoIncrement = true;
				colvarIdConsultaOdontologia.IsNullable = false;
				colvarIdConsultaOdontologia.IsPrimaryKey = true;
				colvarIdConsultaOdontologia.IsForeignKey = false;
				colvarIdConsultaOdontologia.IsReadOnly = false;
				colvarIdConsultaOdontologia.DefaultSetting = @"";
				colvarIdConsultaOdontologia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsultaOdontologia);
				
				TableSchema.TableColumn colvarIdConsulta = new TableSchema.TableColumn(schema);
				colvarIdConsulta.ColumnName = "idConsulta";
				colvarIdConsulta.DataType = DbType.Int32;
				colvarIdConsulta.MaxLength = 0;
				colvarIdConsulta.AutoIncrement = false;
				colvarIdConsulta.IsNullable = false;
				colvarIdConsulta.IsPrimaryKey = false;
				colvarIdConsulta.IsForeignKey = false;
				colvarIdConsulta.IsReadOnly = false;
				colvarIdConsulta.DefaultSetting = @"";
				colvarIdConsulta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdConsulta);
				
				TableSchema.TableColumn colvarIdNomenclador = new TableSchema.TableColumn(schema);
				colvarIdNomenclador.ColumnName = "idNomenclador";
				colvarIdNomenclador.DataType = DbType.Int32;
				colvarIdNomenclador.MaxLength = 0;
				colvarIdNomenclador.AutoIncrement = false;
				colvarIdNomenclador.IsNullable = false;
				colvarIdNomenclador.IsPrimaryKey = false;
				colvarIdNomenclador.IsForeignKey = false;
				colvarIdNomenclador.IsReadOnly = false;
				colvarIdNomenclador.DefaultSetting = @"";
				colvarIdNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomenclador);
				
				TableSchema.TableColumn colvarDiente = new TableSchema.TableColumn(schema);
				colvarDiente.ColumnName = "diente";
				colvarDiente.DataType = DbType.Int32;
				colvarDiente.MaxLength = 0;
				colvarDiente.AutoIncrement = false;
				colvarDiente.IsNullable = false;
				colvarDiente.IsPrimaryKey = false;
				colvarDiente.IsForeignKey = false;
				colvarDiente.IsReadOnly = false;
				
						colvarDiente.DefaultSetting = @"((0))";
				colvarDiente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiente);
				
				TableSchema.TableColumn colvarCaraM = new TableSchema.TableColumn(schema);
				colvarCaraM.ColumnName = "caraM";
				colvarCaraM.DataType = DbType.Boolean;
				colvarCaraM.MaxLength = 0;
				colvarCaraM.AutoIncrement = false;
				colvarCaraM.IsNullable = false;
				colvarCaraM.IsPrimaryKey = false;
				colvarCaraM.IsForeignKey = false;
				colvarCaraM.IsReadOnly = false;
				
						colvarCaraM.DefaultSetting = @"((0))";
				colvarCaraM.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaraM);
				
				TableSchema.TableColumn colvarCaraP = new TableSchema.TableColumn(schema);
				colvarCaraP.ColumnName = "caraP";
				colvarCaraP.DataType = DbType.Boolean;
				colvarCaraP.MaxLength = 0;
				colvarCaraP.AutoIncrement = false;
				colvarCaraP.IsNullable = false;
				colvarCaraP.IsPrimaryKey = false;
				colvarCaraP.IsForeignKey = false;
				colvarCaraP.IsReadOnly = false;
				
						colvarCaraP.DefaultSetting = @"((0))";
				colvarCaraP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaraP);
				
				TableSchema.TableColumn colvarCaraD = new TableSchema.TableColumn(schema);
				colvarCaraD.ColumnName = "caraD";
				colvarCaraD.DataType = DbType.Boolean;
				colvarCaraD.MaxLength = 0;
				colvarCaraD.AutoIncrement = false;
				colvarCaraD.IsNullable = false;
				colvarCaraD.IsPrimaryKey = false;
				colvarCaraD.IsForeignKey = false;
				colvarCaraD.IsReadOnly = false;
				
						colvarCaraD.DefaultSetting = @"((0))";
				colvarCaraD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaraD);
				
				TableSchema.TableColumn colvarCaraO = new TableSchema.TableColumn(schema);
				colvarCaraO.ColumnName = "caraO";
				colvarCaraO.DataType = DbType.Boolean;
				colvarCaraO.MaxLength = 0;
				colvarCaraO.AutoIncrement = false;
				colvarCaraO.IsNullable = false;
				colvarCaraO.IsPrimaryKey = false;
				colvarCaraO.IsForeignKey = false;
				colvarCaraO.IsReadOnly = false;
				
						colvarCaraO.DefaultSetting = @"((0))";
				colvarCaraO.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaraO);
				
				TableSchema.TableColumn colvarCaraV = new TableSchema.TableColumn(schema);
				colvarCaraV.ColumnName = "caraV";
				colvarCaraV.DataType = DbType.Boolean;
				colvarCaraV.MaxLength = 0;
				colvarCaraV.AutoIncrement = false;
				colvarCaraV.IsNullable = false;
				colvarCaraV.IsPrimaryKey = false;
				colvarCaraV.IsForeignKey = false;
				colvarCaraV.IsReadOnly = false;
				
						colvarCaraV.DefaultSetting = @"((0))";
				colvarCaraV.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaraV);
				
				TableSchema.TableColumn colvarCaraL = new TableSchema.TableColumn(schema);
				colvarCaraL.ColumnName = "caraL";
				colvarCaraL.DataType = DbType.Boolean;
				colvarCaraL.MaxLength = 0;
				colvarCaraL.AutoIncrement = false;
				colvarCaraL.IsNullable = false;
				colvarCaraL.IsPrimaryKey = false;
				colvarCaraL.IsForeignKey = false;
				colvarCaraL.IsReadOnly = false;
				colvarCaraL.DefaultSetting = @"";
				colvarCaraL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCaraL);
				
				TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
				colvarCantidad.ColumnName = "cantidad";
				colvarCantidad.DataType = DbType.Int32;
				colvarCantidad.MaxLength = 0;
				colvarCantidad.AutoIncrement = false;
				colvarCantidad.IsNullable = false;
				colvarCantidad.IsPrimaryKey = false;
				colvarCantidad.IsForeignKey = false;
				colvarCantidad.IsReadOnly = false;
				
						colvarCantidad.DefaultSetting = @"((0))";
				colvarCantidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidad);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("CON_ConsultaOdontologia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdConsultaOdontologia")]
		[Bindable(true)]
		public int IdConsultaOdontologia 
		{
			get { return GetColumnValue<int>(Columns.IdConsultaOdontologia); }
			set { SetColumnValue(Columns.IdConsultaOdontologia, value); }
		}
		  
		[XmlAttribute("IdConsulta")]
		[Bindable(true)]
		public int IdConsulta 
		{
			get { return GetColumnValue<int>(Columns.IdConsulta); }
			set { SetColumnValue(Columns.IdConsulta, value); }
		}
		  
		[XmlAttribute("IdNomenclador")]
		[Bindable(true)]
		public int IdNomenclador 
		{
			get { return GetColumnValue<int>(Columns.IdNomenclador); }
			set { SetColumnValue(Columns.IdNomenclador, value); }
		}
		  
		[XmlAttribute("Diente")]
		[Bindable(true)]
		public int Diente 
		{
			get { return GetColumnValue<int>(Columns.Diente); }
			set { SetColumnValue(Columns.Diente, value); }
		}
		  
		[XmlAttribute("CaraM")]
		[Bindable(true)]
		public bool CaraM 
		{
			get { return GetColumnValue<bool>(Columns.CaraM); }
			set { SetColumnValue(Columns.CaraM, value); }
		}
		  
		[XmlAttribute("CaraP")]
		[Bindable(true)]
		public bool CaraP 
		{
			get { return GetColumnValue<bool>(Columns.CaraP); }
			set { SetColumnValue(Columns.CaraP, value); }
		}
		  
		[XmlAttribute("CaraD")]
		[Bindable(true)]
		public bool CaraD 
		{
			get { return GetColumnValue<bool>(Columns.CaraD); }
			set { SetColumnValue(Columns.CaraD, value); }
		}
		  
		[XmlAttribute("CaraO")]
		[Bindable(true)]
		public bool CaraO 
		{
			get { return GetColumnValue<bool>(Columns.CaraO); }
			set { SetColumnValue(Columns.CaraO, value); }
		}
		  
		[XmlAttribute("CaraV")]
		[Bindable(true)]
		public bool CaraV 
		{
			get { return GetColumnValue<bool>(Columns.CaraV); }
			set { SetColumnValue(Columns.CaraV, value); }
		}
		  
		[XmlAttribute("CaraL")]
		[Bindable(true)]
		public bool CaraL 
		{
			get { return GetColumnValue<bool>(Columns.CaraL); }
			set { SetColumnValue(Columns.CaraL, value); }
		}
		  
		[XmlAttribute("Cantidad")]
		[Bindable(true)]
		public int Cantidad 
		{
			get { return GetColumnValue<int>(Columns.Cantidad); }
			set { SetColumnValue(Columns.Cantidad, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdConsulta,int varIdNomenclador,int varDiente,bool varCaraM,bool varCaraP,bool varCaraD,bool varCaraO,bool varCaraV,bool varCaraL,int varCantidad)
		{
			ConConsultaOdontologium item = new ConConsultaOdontologium();
			
			item.IdConsulta = varIdConsulta;
			
			item.IdNomenclador = varIdNomenclador;
			
			item.Diente = varDiente;
			
			item.CaraM = varCaraM;
			
			item.CaraP = varCaraP;
			
			item.CaraD = varCaraD;
			
			item.CaraO = varCaraO;
			
			item.CaraV = varCaraV;
			
			item.CaraL = varCaraL;
			
			item.Cantidad = varCantidad;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdConsultaOdontologia,int varIdConsulta,int varIdNomenclador,int varDiente,bool varCaraM,bool varCaraP,bool varCaraD,bool varCaraO,bool varCaraV,bool varCaraL,int varCantidad)
		{
			ConConsultaOdontologium item = new ConConsultaOdontologium();
			
				item.IdConsultaOdontologia = varIdConsultaOdontologia;
			
				item.IdConsulta = varIdConsulta;
			
				item.IdNomenclador = varIdNomenclador;
			
				item.Diente = varDiente;
			
				item.CaraM = varCaraM;
			
				item.CaraP = varCaraP;
			
				item.CaraD = varCaraD;
			
				item.CaraO = varCaraO;
			
				item.CaraV = varCaraV;
			
				item.CaraL = varCaraL;
			
				item.Cantidad = varCantidad;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdConsultaOdontologiaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdConsultaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DienteColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CaraMColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CaraPColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CaraDColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CaraOColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CaraVColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CaraLColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdConsultaOdontologia = @"idConsultaOdontologia";
			 public static string IdConsulta = @"idConsulta";
			 public static string IdNomenclador = @"idNomenclador";
			 public static string Diente = @"diente";
			 public static string CaraM = @"caraM";
			 public static string CaraP = @"caraP";
			 public static string CaraD = @"caraD";
			 public static string CaraO = @"caraO";
			 public static string CaraV = @"caraV";
			 public static string CaraL = @"caraL";
			 public static string Cantidad = @"cantidad";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
