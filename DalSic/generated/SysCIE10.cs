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
	/// Strongly-typed collection for the SysCIE10 class.
	/// </summary>
    [Serializable]
	public partial class SysCIE10Collection : ActiveList<SysCIE10, SysCIE10Collection>
	{	   
		public SysCIE10Collection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysCIE10Collection</returns>
		public SysCIE10Collection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysCIE10 o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_CIE10 table.
	/// </summary>
	[Serializable]
	public partial class SysCIE10 : ActiveRecord<SysCIE10>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysCIE10()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysCIE10(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysCIE10(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysCIE10(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_CIE10", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarCapitulo = new TableSchema.TableColumn(schema);
				colvarCapitulo.ColumnName = "CAPITULO";
				colvarCapitulo.DataType = DbType.String;
				colvarCapitulo.MaxLength = 255;
				colvarCapitulo.AutoIncrement = false;
				colvarCapitulo.IsNullable = true;
				colvarCapitulo.IsPrimaryKey = false;
				colvarCapitulo.IsForeignKey = false;
				colvarCapitulo.IsReadOnly = false;
				colvarCapitulo.DefaultSetting = @"";
				colvarCapitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCapitulo);
				
				TableSchema.TableColumn colvarGRUPOCIE10 = new TableSchema.TableColumn(schema);
				colvarGRUPOCIE10.ColumnName = "GRUPOCIE10";
				colvarGRUPOCIE10.DataType = DbType.String;
				colvarGRUPOCIE10.MaxLength = 255;
				colvarGRUPOCIE10.AutoIncrement = false;
				colvarGRUPOCIE10.IsNullable = true;
				colvarGRUPOCIE10.IsPrimaryKey = false;
				colvarGRUPOCIE10.IsForeignKey = false;
				colvarGRUPOCIE10.IsReadOnly = false;
				colvarGRUPOCIE10.DefaultSetting = @"";
				colvarGRUPOCIE10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGRUPOCIE10);
				
				TableSchema.TableColumn colvarCausa = new TableSchema.TableColumn(schema);
				colvarCausa.ColumnName = "CAUSA";
				colvarCausa.DataType = DbType.String;
				colvarCausa.MaxLength = 255;
				colvarCausa.AutoIncrement = false;
				colvarCausa.IsNullable = true;
				colvarCausa.IsPrimaryKey = false;
				colvarCausa.IsForeignKey = false;
				colvarCausa.IsReadOnly = false;
				colvarCausa.DefaultSetting = @"";
				colvarCausa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCausa);
				
				TableSchema.TableColumn colvarSubcausa = new TableSchema.TableColumn(schema);
				colvarSubcausa.ColumnName = "SUBCAUSA";
				colvarSubcausa.DataType = DbType.String;
				colvarSubcausa.MaxLength = 255;
				colvarSubcausa.AutoIncrement = false;
				colvarSubcausa.IsNullable = true;
				colvarSubcausa.IsPrimaryKey = false;
				colvarSubcausa.IsForeignKey = false;
				colvarSubcausa.IsReadOnly = false;
				colvarSubcausa.DefaultSetting = @"";
				colvarSubcausa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubcausa);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "CODIGO";
				colvarCodigo.DataType = DbType.String;
				colvarCodigo.MaxLength = 255;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = true;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 255;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarSinonimo = new TableSchema.TableColumn(schema);
				colvarSinonimo.ColumnName = "Sinonimo";
				colvarSinonimo.DataType = DbType.String;
				colvarSinonimo.MaxLength = 255;
				colvarSinonimo.AutoIncrement = false;
				colvarSinonimo.IsNullable = true;
				colvarSinonimo.IsPrimaryKey = false;
				colvarSinonimo.IsForeignKey = false;
				colvarSinonimo.IsReadOnly = false;
				
						colvarSinonimo.DefaultSetting = @"('')";
				colvarSinonimo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSinonimo);
				
				TableSchema.TableColumn colvarDescripCap = new TableSchema.TableColumn(schema);
				colvarDescripCap.ColumnName = "DescripCap";
				colvarDescripCap.DataType = DbType.String;
				colvarDescripCap.MaxLength = 255;
				colvarDescripCap.AutoIncrement = false;
				colvarDescripCap.IsNullable = true;
				colvarDescripCap.IsPrimaryKey = false;
				colvarDescripCap.IsForeignKey = false;
				colvarDescripCap.IsReadOnly = false;
				colvarDescripCap.DefaultSetting = @"";
				colvarDescripCap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripCap);
				
				TableSchema.TableColumn colvarModif = new TableSchema.TableColumn(schema);
				colvarModif.ColumnName = "Modif";
				colvarModif.DataType = DbType.Double;
				colvarModif.MaxLength = 0;
				colvarModif.AutoIncrement = false;
				colvarModif.IsNullable = true;
				colvarModif.IsPrimaryKey = false;
				colvarModif.IsForeignKey = false;
				colvarModif.IsReadOnly = false;
				colvarModif.DefaultSetting = @"";
				colvarModif.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModif);
				
				TableSchema.TableColumn colvarCepsap = new TableSchema.TableColumn(schema);
				colvarCepsap.ColumnName = "CEPSAP";
				colvarCepsap.DataType = DbType.String;
				colvarCepsap.MaxLength = 50;
				colvarCepsap.AutoIncrement = false;
				colvarCepsap.IsNullable = true;
				colvarCepsap.IsPrimaryKey = false;
				colvarCepsap.IsForeignKey = false;
				colvarCepsap.IsReadOnly = false;
				colvarCepsap.DefaultSetting = @"";
				colvarCepsap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCepsap);
				
				TableSchema.TableColumn colvarC2 = new TableSchema.TableColumn(schema);
				colvarC2.ColumnName = "C2";
				colvarC2.DataType = DbType.Boolean;
				colvarC2.MaxLength = 0;
				colvarC2.AutoIncrement = false;
				colvarC2.IsNullable = false;
				colvarC2.IsPrimaryKey = false;
				colvarC2.IsForeignKey = false;
				colvarC2.IsReadOnly = false;
				
						colvarC2.DefaultSetting = @"((0))";
				colvarC2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarC2);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Sys_CIE10",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Capitulo")]
		[Bindable(true)]
		public string Capitulo 
		{
			get { return GetColumnValue<string>(Columns.Capitulo); }
			set { SetColumnValue(Columns.Capitulo, value); }
		}
		  
		[XmlAttribute("GRUPOCIE10")]
		[Bindable(true)]
		public string GRUPOCIE10 
		{
			get { return GetColumnValue<string>(Columns.GRUPOCIE10); }
			set { SetColumnValue(Columns.GRUPOCIE10, value); }
		}
		  
		[XmlAttribute("Causa")]
		[Bindable(true)]
		public string Causa 
		{
			get { return GetColumnValue<string>(Columns.Causa); }
			set { SetColumnValue(Columns.Causa, value); }
		}
		  
		[XmlAttribute("Subcausa")]
		[Bindable(true)]
		public string Subcausa 
		{
			get { return GetColumnValue<string>(Columns.Subcausa); }
			set { SetColumnValue(Columns.Subcausa, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Sinonimo")]
		[Bindable(true)]
		public string Sinonimo 
		{
			get { return GetColumnValue<string>(Columns.Sinonimo); }
			set { SetColumnValue(Columns.Sinonimo, value); }
		}
		  
		[XmlAttribute("DescripCap")]
		[Bindable(true)]
		public string DescripCap 
		{
			get { return GetColumnValue<string>(Columns.DescripCap); }
			set { SetColumnValue(Columns.DescripCap, value); }
		}
		  
		[XmlAttribute("Modif")]
		[Bindable(true)]
		public double? Modif 
		{
			get { return GetColumnValue<double?>(Columns.Modif); }
			set { SetColumnValue(Columns.Modif, value); }
		}
		  
		[XmlAttribute("Cepsap")]
		[Bindable(true)]
		public string Cepsap 
		{
			get { return GetColumnValue<string>(Columns.Cepsap); }
			set { SetColumnValue(Columns.Cepsap, value); }
		}
		  
		[XmlAttribute("C2")]
		[Bindable(true)]
		public bool C2 
		{
			get { return GetColumnValue<bool>(Columns.C2); }
			set { SetColumnValue(Columns.C2, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.SysAntecedenteEnfermedadCollection colSysAntecedenteEnfermedadRecords;
		public DalSic.SysAntecedenteEnfermedadCollection SysAntecedenteEnfermedadRecords
		{
			get
			{
				if(colSysAntecedenteEnfermedadRecords == null)
				{
					colSysAntecedenteEnfermedadRecords = new DalSic.SysAntecedenteEnfermedadCollection().Where(SysAntecedenteEnfermedad.Columns.CODCIE10, Id).Load();
					colSysAntecedenteEnfermedadRecords.ListChanged += new ListChangedEventHandler(colSysAntecedenteEnfermedadRecords_ListChanged);
				}
				return colSysAntecedenteEnfermedadRecords;			
			}
			set 
			{ 
					colSysAntecedenteEnfermedadRecords = value; 
					colSysAntecedenteEnfermedadRecords.ListChanged += new ListChangedEventHandler(colSysAntecedenteEnfermedadRecords_ListChanged);
			}
		}
		
		void colSysAntecedenteEnfermedadRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysAntecedenteEnfermedadRecords[e.NewIndex].CODCIE10 = Id;
		    }
		}
				
		private DalSic.AprRelRecienNacidoEnfermedadCollection colAprRelRecienNacidoEnfermedadRecords;
		public DalSic.AprRelRecienNacidoEnfermedadCollection AprRelRecienNacidoEnfermedadRecords
		{
			get
			{
				if(colAprRelRecienNacidoEnfermedadRecords == null)
				{
					colAprRelRecienNacidoEnfermedadRecords = new DalSic.AprRelRecienNacidoEnfermedadCollection().Where(AprRelRecienNacidoEnfermedad.Columns.CODCIE10, Id).Load();
					colAprRelRecienNacidoEnfermedadRecords.ListChanged += new ListChangedEventHandler(colAprRelRecienNacidoEnfermedadRecords_ListChanged);
				}
				return colAprRelRecienNacidoEnfermedadRecords;			
			}
			set 
			{ 
					colAprRelRecienNacidoEnfermedadRecords = value; 
					colAprRelRecienNacidoEnfermedadRecords.ListChanged += new ListChangedEventHandler(colAprRelRecienNacidoEnfermedadRecords_ListChanged);
			}
		}
		
		void colAprRelRecienNacidoEnfermedadRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprRelRecienNacidoEnfermedadRecords[e.NewIndex].CODCIE10 = Id;
		    }
		}
				
		private DalSic.AprAntecedentePatologiaEmbarazoCollection colAprAntecedentePatologiaEmbarazoRecords;
		public DalSic.AprAntecedentePatologiaEmbarazoCollection AprAntecedentePatologiaEmbarazoRecords
		{
			get
			{
				if(colAprAntecedentePatologiaEmbarazoRecords == null)
				{
					colAprAntecedentePatologiaEmbarazoRecords = new DalSic.AprAntecedentePatologiaEmbarazoCollection().Where(AprAntecedentePatologiaEmbarazo.Columns.IdPatologiaEmbarazo, Id).Load();
					colAprAntecedentePatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprAntecedentePatologiaEmbarazoRecords_ListChanged);
				}
				return colAprAntecedentePatologiaEmbarazoRecords;			
			}
			set 
			{ 
					colAprAntecedentePatologiaEmbarazoRecords = value; 
					colAprAntecedentePatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprAntecedentePatologiaEmbarazoRecords_ListChanged);
			}
		}
		
		void colAprAntecedentePatologiaEmbarazoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAntecedentePatologiaEmbarazoRecords[e.NewIndex].IdPatologiaEmbarazo = Id;
		    }
		}
				
		private DalSic.AprActualPatologiaEmbarazoCollection colAprActualPatologiaEmbarazoRecords;
		public DalSic.AprActualPatologiaEmbarazoCollection AprActualPatologiaEmbarazoRecords
		{
			get
			{
				if(colAprActualPatologiaEmbarazoRecords == null)
				{
					colAprActualPatologiaEmbarazoRecords = new DalSic.AprActualPatologiaEmbarazoCollection().Where(AprActualPatologiaEmbarazo.Columns.IdPatologiaEmbarazo, Id).Load();
					colAprActualPatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprActualPatologiaEmbarazoRecords_ListChanged);
				}
				return colAprActualPatologiaEmbarazoRecords;			
			}
			set 
			{ 
					colAprActualPatologiaEmbarazoRecords = value; 
					colAprActualPatologiaEmbarazoRecords.ListChanged += new ListChangedEventHandler(colAprActualPatologiaEmbarazoRecords_ListChanged);
			}
		}
		
		void colAprActualPatologiaEmbarazoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprActualPatologiaEmbarazoRecords[e.NewIndex].IdPatologiaEmbarazo = Id;
		    }
		}
				
		private DalSic.AprAbortoCollection colAprAbortoRecords;
		public DalSic.AprAbortoCollection AprAbortoRecords
		{
			get
			{
				if(colAprAbortoRecords == null)
				{
					colAprAbortoRecords = new DalSic.AprAbortoCollection().Where(AprAborto.Columns.DIAGCIE10, Id).Load();
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
				}
				return colAprAbortoRecords;			
			}
			set 
			{ 
					colAprAbortoRecords = value; 
					colAprAbortoRecords.ListChanged += new ListChangedEventHandler(colAprAbortoRecords_ListChanged);
			}
		}
		
		void colAprAbortoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprAbortoRecords[e.NewIndex].DIAGCIE10 = Id;
		    }
		}
				
		private DalSic.AprProblemasMenorCollection colAprProblemasMenorRecords;
		public DalSic.AprProblemasMenorCollection AprProblemasMenorRecords
		{
			get
			{
				if(colAprProblemasMenorRecords == null)
				{
					colAprProblemasMenorRecords = new DalSic.AprProblemasMenorCollection().Where(AprProblemasMenor.Columns.CODCIE10, Id).Load();
					colAprProblemasMenorRecords.ListChanged += new ListChangedEventHandler(colAprProblemasMenorRecords_ListChanged);
				}
				return colAprProblemasMenorRecords;			
			}
			set 
			{ 
					colAprProblemasMenorRecords = value; 
					colAprProblemasMenorRecords.ListChanged += new ListChangedEventHandler(colAprProblemasMenorRecords_ListChanged);
			}
		}
		
		void colAprProblemasMenorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprProblemasMenorRecords[e.NewIndex].CODCIE10 = Id;
		    }
		}
				
		private DalSic.AprEgresoPorAbortoCollection colAprEgresoPorAbortoRecords;
		public DalSic.AprEgresoPorAbortoCollection AprEgresoPorAbortoRecords
		{
			get
			{
				if(colAprEgresoPorAbortoRecords == null)
				{
					colAprEgresoPorAbortoRecords = new DalSic.AprEgresoPorAbortoCollection().Where(AprEgresoPorAborto.Columns.DIAGCIE10, Id).Load();
					colAprEgresoPorAbortoRecords.ListChanged += new ListChangedEventHandler(colAprEgresoPorAbortoRecords_ListChanged);
				}
				return colAprEgresoPorAbortoRecords;			
			}
			set 
			{ 
					colAprEgresoPorAbortoRecords = value; 
					colAprEgresoPorAbortoRecords.ListChanged += new ListChangedEventHandler(colAprEgresoPorAbortoRecords_ListChanged);
			}
		}
		
		void colAprEgresoPorAbortoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprEgresoPorAbortoRecords[e.NewIndex].DIAGCIE10 = Id;
		    }
		}
				
		private DalSic.GuardiaRegistrosDiagnosticosCie10Collection colGuardiaRegistrosDiagnosticosCie10Records;
		public DalSic.GuardiaRegistrosDiagnosticosCie10Collection GuardiaRegistrosDiagnosticosCie10Records
		{
			get
			{
				if(colGuardiaRegistrosDiagnosticosCie10Records == null)
				{
					colGuardiaRegistrosDiagnosticosCie10Records = new DalSic.GuardiaRegistrosDiagnosticosCie10Collection().Where(GuardiaRegistrosDiagnosticosCie10.Columns.IdCie10, Id).Load();
					colGuardiaRegistrosDiagnosticosCie10Records.ListChanged += new ListChangedEventHandler(colGuardiaRegistrosDiagnosticosCie10Records_ListChanged);
				}
				return colGuardiaRegistrosDiagnosticosCie10Records;			
			}
			set 
			{ 
					colGuardiaRegistrosDiagnosticosCie10Records = value; 
					colGuardiaRegistrosDiagnosticosCie10Records.ListChanged += new ListChangedEventHandler(colGuardiaRegistrosDiagnosticosCie10Records_ListChanged);
			}
		}
		
		void colGuardiaRegistrosDiagnosticosCie10Records_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colGuardiaRegistrosDiagnosticosCie10Records[e.NewIndex].IdCie10 = Id;
		    }
		}
				
		private DalSic.ConConsultaDiagnosticoCollection colConConsultaDiagnosticoRecords;
		public DalSic.ConConsultaDiagnosticoCollection ConConsultaDiagnosticoRecords
		{
			get
			{
				if(colConConsultaDiagnosticoRecords == null)
				{
					colConConsultaDiagnosticoRecords = new DalSic.ConConsultaDiagnosticoCollection().Where(ConConsultaDiagnostico.Columns.CODCIE10, Id).Load();
					colConConsultaDiagnosticoRecords.ListChanged += new ListChangedEventHandler(colConConsultaDiagnosticoRecords_ListChanged);
				}
				return colConConsultaDiagnosticoRecords;			
			}
			set 
			{ 
					colConConsultaDiagnosticoRecords = value; 
					colConConsultaDiagnosticoRecords.ListChanged += new ListChangedEventHandler(colConConsultaDiagnosticoRecords_ListChanged);
			}
		}
		
		void colConConsultaDiagnosticoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colConConsultaDiagnosticoRecords[e.NewIndex].CODCIE10 = Id;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCapitulo,string varGRUPOCIE10,string varCausa,string varSubcausa,string varCodigo,string varNombre,string varSinonimo,string varDescripCap,double? varModif,string varCepsap,bool varC2)
		{
			SysCIE10 item = new SysCIE10();
			
			item.Capitulo = varCapitulo;
			
			item.GRUPOCIE10 = varGRUPOCIE10;
			
			item.Causa = varCausa;
			
			item.Subcausa = varSubcausa;
			
			item.Codigo = varCodigo;
			
			item.Nombre = varNombre;
			
			item.Sinonimo = varSinonimo;
			
			item.DescripCap = varDescripCap;
			
			item.Modif = varModif;
			
			item.Cepsap = varCepsap;
			
			item.C2 = varC2;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varCapitulo,string varGRUPOCIE10,string varCausa,string varSubcausa,string varCodigo,string varNombre,string varSinonimo,string varDescripCap,double? varModif,string varCepsap,bool varC2)
		{
			SysCIE10 item = new SysCIE10();
			
				item.Id = varId;
			
				item.Capitulo = varCapitulo;
			
				item.GRUPOCIE10 = varGRUPOCIE10;
			
				item.Causa = varCausa;
			
				item.Subcausa = varSubcausa;
			
				item.Codigo = varCodigo;
			
				item.Nombre = varNombre;
			
				item.Sinonimo = varSinonimo;
			
				item.DescripCap = varDescripCap;
			
				item.Modif = varModif;
			
				item.Cepsap = varCepsap;
			
				item.C2 = varC2;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CapituloColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn GRUPOCIE10Column
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CausaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SubcausaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SinonimoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripCapColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CepsapColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn C2Column
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Capitulo = @"CAPITULO";
			 public static string GRUPOCIE10 = @"GRUPOCIE10";
			 public static string Causa = @"CAUSA";
			 public static string Subcausa = @"SUBCAUSA";
			 public static string Codigo = @"CODIGO";
			 public static string Nombre = @"Nombre";
			 public static string Sinonimo = @"Sinonimo";
			 public static string DescripCap = @"DescripCap";
			 public static string Modif = @"Modif";
			 public static string Cepsap = @"CEPSAP";
			 public static string C2 = @"C2";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysAntecedenteEnfermedadRecords != null)
                {
                    foreach (DalSic.SysAntecedenteEnfermedad item in colSysAntecedenteEnfermedadRecords)
                    {
                        if (item.CODCIE10 != Id)
                        {
                            item.CODCIE10 = Id;
                        }
                    }
               }
		
                if (colAprRelRecienNacidoEnfermedadRecords != null)
                {
                    foreach (DalSic.AprRelRecienNacidoEnfermedad item in colAprRelRecienNacidoEnfermedadRecords)
                    {
                        if (item.CODCIE10 != Id)
                        {
                            item.CODCIE10 = Id;
                        }
                    }
               }
		
                if (colAprAntecedentePatologiaEmbarazoRecords != null)
                {
                    foreach (DalSic.AprAntecedentePatologiaEmbarazo item in colAprAntecedentePatologiaEmbarazoRecords)
                    {
                        if (item.IdPatologiaEmbarazo != Id)
                        {
                            item.IdPatologiaEmbarazo = Id;
                        }
                    }
               }
		
                if (colAprActualPatologiaEmbarazoRecords != null)
                {
                    foreach (DalSic.AprActualPatologiaEmbarazo item in colAprActualPatologiaEmbarazoRecords)
                    {
                        if (item.IdPatologiaEmbarazo != Id)
                        {
                            item.IdPatologiaEmbarazo = Id;
                        }
                    }
               }
		
                if (colAprAbortoRecords != null)
                {
                    foreach (DalSic.AprAborto item in colAprAbortoRecords)
                    {
                        if (item.DIAGCIE10 != Id)
                        {
                            item.DIAGCIE10 = Id;
                        }
                    }
               }
		
                if (colAprProblemasMenorRecords != null)
                {
                    foreach (DalSic.AprProblemasMenor item in colAprProblemasMenorRecords)
                    {
                        if (item.CODCIE10 != Id)
                        {
                            item.CODCIE10 = Id;
                        }
                    }
               }
		
                if (colAprEgresoPorAbortoRecords != null)
                {
                    foreach (DalSic.AprEgresoPorAborto item in colAprEgresoPorAbortoRecords)
                    {
                        if (item.DIAGCIE10 != Id)
                        {
                            item.DIAGCIE10 = Id;
                        }
                    }
               }
		
                if (colGuardiaRegistrosDiagnosticosCie10Records != null)
                {
                    foreach (DalSic.GuardiaRegistrosDiagnosticosCie10 item in colGuardiaRegistrosDiagnosticosCie10Records)
                    {
                        if (item.IdCie10 != Id)
                        {
                            item.IdCie10 = Id;
                        }
                    }
               }
		
                if (colConConsultaDiagnosticoRecords != null)
                {
                    foreach (DalSic.ConConsultaDiagnostico item in colConConsultaDiagnosticoRecords)
                    {
                        if (item.CODCIE10 != Id)
                        {
                            item.CODCIE10 = Id;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysAntecedenteEnfermedadRecords != null)
                {
                    colSysAntecedenteEnfermedadRecords.SaveAll();
               }
		
                if (colAprRelRecienNacidoEnfermedadRecords != null)
                {
                    colAprRelRecienNacidoEnfermedadRecords.SaveAll();
               }
		
                if (colAprAntecedentePatologiaEmbarazoRecords != null)
                {
                    colAprAntecedentePatologiaEmbarazoRecords.SaveAll();
               }
		
                if (colAprActualPatologiaEmbarazoRecords != null)
                {
                    colAprActualPatologiaEmbarazoRecords.SaveAll();
               }
		
                if (colAprAbortoRecords != null)
                {
                    colAprAbortoRecords.SaveAll();
               }
		
                if (colAprProblemasMenorRecords != null)
                {
                    colAprProblemasMenorRecords.SaveAll();
               }
		
                if (colAprEgresoPorAbortoRecords != null)
                {
                    colAprEgresoPorAbortoRecords.SaveAll();
               }
		
                if (colGuardiaRegistrosDiagnosticosCie10Records != null)
                {
                    colGuardiaRegistrosDiagnosticosCie10Records.SaveAll();
               }
		
                if (colConConsultaDiagnosticoRecords != null)
                {
                    colConConsultaDiagnosticoRecords.SaveAll();
               }
		}
        #endregion
	}
}
