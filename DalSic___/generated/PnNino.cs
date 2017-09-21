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
	/// Strongly-typed collection for the PnNino class.
	/// </summary>
    [Serializable]
	public partial class PnNinoCollection : ActiveList<PnNino, PnNinoCollection>
	{	   
		public PnNinoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnNinoCollection</returns>
		public PnNinoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnNino o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_nino table.
	/// </summary>
	[Serializable]
	public partial class PnNino : ActiveRecord<PnNino>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnNino()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnNino(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnNino(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnNino(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_nino", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdNino = new TableSchema.TableColumn(schema);
				colvarIdNino.ColumnName = "id_nino";
				colvarIdNino.DataType = DbType.Int32;
				colvarIdNino.MaxLength = 0;
				colvarIdNino.AutoIncrement = true;
				colvarIdNino.IsNullable = false;
				colvarIdNino.IsPrimaryKey = true;
				colvarIdNino.IsForeignKey = false;
				colvarIdNino.IsReadOnly = false;
				colvarIdNino.DefaultSetting = @"";
				colvarIdNino.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNino);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarClave = new TableSchema.TableColumn(schema);
				colvarClave.ColumnName = "clave";
				colvarClave.DataType = DbType.AnsiString;
				colvarClave.MaxLength = 50;
				colvarClave.AutoIncrement = false;
				colvarClave.IsNullable = true;
				colvarClave.IsPrimaryKey = false;
				colvarClave.IsForeignKey = false;
				colvarClave.IsReadOnly = false;
				colvarClave.DefaultSetting = @"";
				colvarClave.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClave);
				
				TableSchema.TableColumn colvarClaseDoc = new TableSchema.TableColumn(schema);
				colvarClaseDoc.ColumnName = "clase_doc";
				colvarClaseDoc.DataType = DbType.AnsiString;
				colvarClaseDoc.MaxLength = -1;
				colvarClaseDoc.AutoIncrement = false;
				colvarClaseDoc.IsNullable = true;
				colvarClaseDoc.IsPrimaryKey = false;
				colvarClaseDoc.IsForeignKey = false;
				colvarClaseDoc.IsReadOnly = false;
				colvarClaseDoc.DefaultSetting = @"";
				colvarClaseDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClaseDoc);
				
				TableSchema.TableColumn colvarTipoDoc = new TableSchema.TableColumn(schema);
				colvarTipoDoc.ColumnName = "tipo_doc";
				colvarTipoDoc.DataType = DbType.AnsiString;
				colvarTipoDoc.MaxLength = -1;
				colvarTipoDoc.AutoIncrement = false;
				colvarTipoDoc.IsNullable = true;
				colvarTipoDoc.IsPrimaryKey = false;
				colvarTipoDoc.IsForeignKey = false;
				colvarTipoDoc.IsReadOnly = false;
				colvarTipoDoc.DefaultSetting = @"";
				colvarTipoDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDoc);
				
				TableSchema.TableColumn colvarNumDoc = new TableSchema.TableColumn(schema);
				colvarNumDoc.ColumnName = "num_doc";
				colvarNumDoc.DataType = DbType.Decimal;
				colvarNumDoc.MaxLength = 0;
				colvarNumDoc.AutoIncrement = false;
				colvarNumDoc.IsNullable = true;
				colvarNumDoc.IsPrimaryKey = false;
				colvarNumDoc.IsForeignKey = false;
				colvarNumDoc.IsReadOnly = false;
				colvarNumDoc.DefaultSetting = @"";
				colvarNumDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumDoc);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = -1;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = -1;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarFechaNac = new TableSchema.TableColumn(schema);
				colvarFechaNac.ColumnName = "fecha_nac";
				colvarFechaNac.DataType = DbType.DateTime;
				colvarFechaNac.MaxLength = 0;
				colvarFechaNac.AutoIncrement = false;
				colvarFechaNac.IsNullable = true;
				colvarFechaNac.IsPrimaryKey = false;
				colvarFechaNac.IsForeignKey = false;
				colvarFechaNac.IsReadOnly = false;
				colvarFechaNac.DefaultSetting = @"";
				colvarFechaNac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNac);
				
				TableSchema.TableColumn colvarFechaControl = new TableSchema.TableColumn(schema);
				colvarFechaControl.ColumnName = "fecha_control";
				colvarFechaControl.DataType = DbType.DateTime;
				colvarFechaControl.MaxLength = 0;
				colvarFechaControl.AutoIncrement = false;
				colvarFechaControl.IsNullable = true;
				colvarFechaControl.IsPrimaryKey = false;
				colvarFechaControl.IsForeignKey = false;
				colvarFechaControl.IsReadOnly = false;
				colvarFechaControl.DefaultSetting = @"";
				colvarFechaControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaControl);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "peso";
				colvarPeso.DataType = DbType.Decimal;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarTalla = new TableSchema.TableColumn(schema);
				colvarTalla.ColumnName = "talla";
				colvarTalla.DataType = DbType.Decimal;
				colvarTalla.MaxLength = 0;
				colvarTalla.AutoIncrement = false;
				colvarTalla.IsNullable = true;
				colvarTalla.IsPrimaryKey = false;
				colvarTalla.IsForeignKey = false;
				colvarTalla.IsReadOnly = false;
				colvarTalla.DefaultSetting = @"";
				colvarTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTalla);
				
				TableSchema.TableColumn colvarPerimCefalico = new TableSchema.TableColumn(schema);
				colvarPerimCefalico.ColumnName = "perim_cefalico";
				colvarPerimCefalico.DataType = DbType.Decimal;
				colvarPerimCefalico.MaxLength = 0;
				colvarPerimCefalico.AutoIncrement = false;
				colvarPerimCefalico.IsNullable = true;
				colvarPerimCefalico.IsPrimaryKey = false;
				colvarPerimCefalico.IsForeignKey = false;
				colvarPerimCefalico.IsReadOnly = false;
				colvarPerimCefalico.DefaultSetting = @"";
				colvarPerimCefalico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerimCefalico);
				
				TableSchema.TableColumn colvarPercenPesoEdad = new TableSchema.TableColumn(schema);
				colvarPercenPesoEdad.ColumnName = "percen_peso_edad";
				colvarPercenPesoEdad.DataType = DbType.AnsiString;
				colvarPercenPesoEdad.MaxLength = -1;
				colvarPercenPesoEdad.AutoIncrement = false;
				colvarPercenPesoEdad.IsNullable = true;
				colvarPercenPesoEdad.IsPrimaryKey = false;
				colvarPercenPesoEdad.IsForeignKey = false;
				colvarPercenPesoEdad.IsReadOnly = false;
				colvarPercenPesoEdad.DefaultSetting = @"";
				colvarPercenPesoEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPercenPesoEdad);
				
				TableSchema.TableColumn colvarPercenTallaEdad = new TableSchema.TableColumn(schema);
				colvarPercenTallaEdad.ColumnName = "percen_talla_edad";
				colvarPercenTallaEdad.DataType = DbType.AnsiString;
				colvarPercenTallaEdad.MaxLength = -1;
				colvarPercenTallaEdad.AutoIncrement = false;
				colvarPercenTallaEdad.IsNullable = true;
				colvarPercenTallaEdad.IsPrimaryKey = false;
				colvarPercenTallaEdad.IsForeignKey = false;
				colvarPercenTallaEdad.IsReadOnly = false;
				colvarPercenTallaEdad.DefaultSetting = @"";
				colvarPercenTallaEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPercenTallaEdad);
				
				TableSchema.TableColumn colvarPercenPerimCefaliEdad = new TableSchema.TableColumn(schema);
				colvarPercenPerimCefaliEdad.ColumnName = "percen_perim_cefali_edad";
				colvarPercenPerimCefaliEdad.DataType = DbType.AnsiString;
				colvarPercenPerimCefaliEdad.MaxLength = -1;
				colvarPercenPerimCefaliEdad.AutoIncrement = false;
				colvarPercenPerimCefaliEdad.IsNullable = true;
				colvarPercenPerimCefaliEdad.IsPrimaryKey = false;
				colvarPercenPerimCefaliEdad.IsForeignKey = false;
				colvarPercenPerimCefaliEdad.IsReadOnly = false;
				colvarPercenPerimCefaliEdad.DefaultSetting = @"";
				colvarPercenPerimCefaliEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPercenPerimCefaliEdad);
				
				TableSchema.TableColumn colvarPercenPesoTalla = new TableSchema.TableColumn(schema);
				colvarPercenPesoTalla.ColumnName = "percen_peso_talla";
				colvarPercenPesoTalla.DataType = DbType.AnsiString;
				colvarPercenPesoTalla.MaxLength = -1;
				colvarPercenPesoTalla.AutoIncrement = false;
				colvarPercenPesoTalla.IsNullable = true;
				colvarPercenPesoTalla.IsPrimaryKey = false;
				colvarPercenPesoTalla.IsForeignKey = false;
				colvarPercenPesoTalla.IsReadOnly = false;
				colvarPercenPesoTalla.DefaultSetting = @"";
				colvarPercenPesoTalla.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPercenPesoTalla);
				
				TableSchema.TableColumn colvarTripleViral = new TableSchema.TableColumn(schema);
				colvarTripleViral.ColumnName = "triple_viral";
				colvarTripleViral.DataType = DbType.DateTime;
				colvarTripleViral.MaxLength = 0;
				colvarTripleViral.AutoIncrement = false;
				colvarTripleViral.IsNullable = true;
				colvarTripleViral.IsPrimaryKey = false;
				colvarTripleViral.IsForeignKey = false;
				colvarTripleViral.IsReadOnly = false;
				colvarTripleViral.DefaultSetting = @"";
				colvarTripleViral.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTripleViral);
				
				TableSchema.TableColumn colvarNinoEdad = new TableSchema.TableColumn(schema);
				colvarNinoEdad.ColumnName = "nino_edad";
				colvarNinoEdad.DataType = DbType.Int32;
				colvarNinoEdad.MaxLength = 0;
				colvarNinoEdad.AutoIncrement = false;
				colvarNinoEdad.IsNullable = true;
				colvarNinoEdad.IsPrimaryKey = false;
				colvarNinoEdad.IsForeignKey = false;
				colvarNinoEdad.IsReadOnly = false;
				colvarNinoEdad.DefaultSetting = @"";
				colvarNinoEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNinoEdad);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = -1;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarFechaCarga = new TableSchema.TableColumn(schema);
				colvarFechaCarga.ColumnName = "fecha_carga";
				colvarFechaCarga.DataType = DbType.DateTime;
				colvarFechaCarga.MaxLength = 0;
				colvarFechaCarga.AutoIncrement = false;
				colvarFechaCarga.IsNullable = true;
				colvarFechaCarga.IsPrimaryKey = false;
				colvarFechaCarga.IsForeignKey = false;
				colvarFechaCarga.IsReadOnly = false;
				colvarFechaCarga.DefaultSetting = @"";
				colvarFechaCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCarga);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = -1;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_nino",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdNino")]
		[Bindable(true)]
		public int IdNino 
		{
			get { return GetColumnValue<int>(Columns.IdNino); }
			set { SetColumnValue(Columns.IdNino, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Clave")]
		[Bindable(true)]
		public string Clave 
		{
			get { return GetColumnValue<string>(Columns.Clave); }
			set { SetColumnValue(Columns.Clave, value); }
		}
		  
		[XmlAttribute("ClaseDoc")]
		[Bindable(true)]
		public string ClaseDoc 
		{
			get { return GetColumnValue<string>(Columns.ClaseDoc); }
			set { SetColumnValue(Columns.ClaseDoc, value); }
		}
		  
		[XmlAttribute("TipoDoc")]
		[Bindable(true)]
		public string TipoDoc 
		{
			get { return GetColumnValue<string>(Columns.TipoDoc); }
			set { SetColumnValue(Columns.TipoDoc, value); }
		}
		  
		[XmlAttribute("NumDoc")]
		[Bindable(true)]
		public decimal? NumDoc 
		{
			get { return GetColumnValue<decimal?>(Columns.NumDoc); }
			set { SetColumnValue(Columns.NumDoc, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("FechaNac")]
		[Bindable(true)]
		public DateTime? FechaNac 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNac); }
			set { SetColumnValue(Columns.FechaNac, value); }
		}
		  
		[XmlAttribute("FechaControl")]
		[Bindable(true)]
		public DateTime? FechaControl 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaControl); }
			set { SetColumnValue(Columns.FechaControl, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public decimal? Peso 
		{
			get { return GetColumnValue<decimal?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("Talla")]
		[Bindable(true)]
		public decimal? Talla 
		{
			get { return GetColumnValue<decimal?>(Columns.Talla); }
			set { SetColumnValue(Columns.Talla, value); }
		}
		  
		[XmlAttribute("PerimCefalico")]
		[Bindable(true)]
		public decimal? PerimCefalico 
		{
			get { return GetColumnValue<decimal?>(Columns.PerimCefalico); }
			set { SetColumnValue(Columns.PerimCefalico, value); }
		}
		  
		[XmlAttribute("PercenPesoEdad")]
		[Bindable(true)]
		public string PercenPesoEdad 
		{
			get { return GetColumnValue<string>(Columns.PercenPesoEdad); }
			set { SetColumnValue(Columns.PercenPesoEdad, value); }
		}
		  
		[XmlAttribute("PercenTallaEdad")]
		[Bindable(true)]
		public string PercenTallaEdad 
		{
			get { return GetColumnValue<string>(Columns.PercenTallaEdad); }
			set { SetColumnValue(Columns.PercenTallaEdad, value); }
		}
		  
		[XmlAttribute("PercenPerimCefaliEdad")]
		[Bindable(true)]
		public string PercenPerimCefaliEdad 
		{
			get { return GetColumnValue<string>(Columns.PercenPerimCefaliEdad); }
			set { SetColumnValue(Columns.PercenPerimCefaliEdad, value); }
		}
		  
		[XmlAttribute("PercenPesoTalla")]
		[Bindable(true)]
		public string PercenPesoTalla 
		{
			get { return GetColumnValue<string>(Columns.PercenPesoTalla); }
			set { SetColumnValue(Columns.PercenPesoTalla, value); }
		}
		  
		[XmlAttribute("TripleViral")]
		[Bindable(true)]
		public DateTime? TripleViral 
		{
			get { return GetColumnValue<DateTime?>(Columns.TripleViral); }
			set { SetColumnValue(Columns.TripleViral, value); }
		}
		  
		[XmlAttribute("NinoEdad")]
		[Bindable(true)]
		public int? NinoEdad 
		{
			get { return GetColumnValue<int?>(Columns.NinoEdad); }
			set { SetColumnValue(Columns.NinoEdad, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varClave,string varClaseDoc,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaNac,DateTime? varFechaControl,decimal? varPeso,decimal? varTalla,decimal? varPerimCefalico,string varPercenPesoEdad,string varPercenTallaEdad,string varPercenPerimCefaliEdad,string varPercenPesoTalla,DateTime? varTripleViral,int? varNinoEdad,string varObservaciones,DateTime? varFechaCarga,string varUsuario)
		{
			PnNino item = new PnNino();
			
			item.Cuie = varCuie;
			
			item.Clave = varClave;
			
			item.ClaseDoc = varClaseDoc;
			
			item.TipoDoc = varTipoDoc;
			
			item.NumDoc = varNumDoc;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.FechaNac = varFechaNac;
			
			item.FechaControl = varFechaControl;
			
			item.Peso = varPeso;
			
			item.Talla = varTalla;
			
			item.PerimCefalico = varPerimCefalico;
			
			item.PercenPesoEdad = varPercenPesoEdad;
			
			item.PercenTallaEdad = varPercenTallaEdad;
			
			item.PercenPerimCefaliEdad = varPercenPerimCefaliEdad;
			
			item.PercenPesoTalla = varPercenPesoTalla;
			
			item.TripleViral = varTripleViral;
			
			item.NinoEdad = varNinoEdad;
			
			item.Observaciones = varObservaciones;
			
			item.FechaCarga = varFechaCarga;
			
			item.Usuario = varUsuario;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdNino,string varCuie,string varClave,string varClaseDoc,string varTipoDoc,decimal? varNumDoc,string varApellido,string varNombre,DateTime? varFechaNac,DateTime? varFechaControl,decimal? varPeso,decimal? varTalla,decimal? varPerimCefalico,string varPercenPesoEdad,string varPercenTallaEdad,string varPercenPerimCefaliEdad,string varPercenPesoTalla,DateTime? varTripleViral,int? varNinoEdad,string varObservaciones,DateTime? varFechaCarga,string varUsuario)
		{
			PnNino item = new PnNino();
			
				item.IdNino = varIdNino;
			
				item.Cuie = varCuie;
			
				item.Clave = varClave;
			
				item.ClaseDoc = varClaseDoc;
			
				item.TipoDoc = varTipoDoc;
			
				item.NumDoc = varNumDoc;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.FechaNac = varFechaNac;
			
				item.FechaControl = varFechaControl;
			
				item.Peso = varPeso;
			
				item.Talla = varTalla;
			
				item.PerimCefalico = varPerimCefalico;
			
				item.PercenPesoEdad = varPercenPesoEdad;
			
				item.PercenTallaEdad = varPercenTallaEdad;
			
				item.PercenPerimCefaliEdad = varPercenPerimCefaliEdad;
			
				item.PercenPesoTalla = varPercenPesoTalla;
			
				item.TripleViral = varTripleViral;
			
				item.NinoEdad = varNinoEdad;
			
				item.Observaciones = varObservaciones;
			
				item.FechaCarga = varFechaCarga;
			
				item.Usuario = varUsuario;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdNinoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaveColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaseDocColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NumDocColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaControlColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TallaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn PerimCefalicoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PercenPesoEdadColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PercenTallaEdadColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn PercenPerimCefaliEdadColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn PercenPesoTallaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn TripleViralColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn NinoEdadColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdNino = @"id_nino";
			 public static string Cuie = @"cuie";
			 public static string Clave = @"clave";
			 public static string ClaseDoc = @"clase_doc";
			 public static string TipoDoc = @"tipo_doc";
			 public static string NumDoc = @"num_doc";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string FechaNac = @"fecha_nac";
			 public static string FechaControl = @"fecha_control";
			 public static string Peso = @"peso";
			 public static string Talla = @"talla";
			 public static string PerimCefalico = @"perim_cefalico";
			 public static string PercenPesoEdad = @"percen_peso_edad";
			 public static string PercenTallaEdad = @"percen_talla_edad";
			 public static string PercenPerimCefaliEdad = @"percen_perim_cefali_edad";
			 public static string PercenPesoTalla = @"percen_peso_talla";
			 public static string TripleViral = @"triple_viral";
			 public static string NinoEdad = @"nino_edad";
			 public static string Observaciones = @"observaciones";
			 public static string FechaCarga = @"fecha_carga";
			 public static string Usuario = @"usuario";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
