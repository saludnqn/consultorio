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
	/// Strongly-typed collection for the GuardiaRegistrosPracticasLaboratorio class.
	/// </summary>
    [Serializable]
	public partial class GuardiaRegistrosPracticasLaboratorioCollection : ActiveList<GuardiaRegistrosPracticasLaboratorio, GuardiaRegistrosPracticasLaboratorioCollection>
	{	   
		public GuardiaRegistrosPracticasLaboratorioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>GuardiaRegistrosPracticasLaboratorioCollection</returns>
		public GuardiaRegistrosPracticasLaboratorioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                GuardiaRegistrosPracticasLaboratorio o = this[i];
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
	/// This is an ActiveRecord class which wraps the Guardia_Registros_Practicas_Laboratorio table.
	/// </summary>
	[Serializable]
	public partial class GuardiaRegistrosPracticasLaboratorio : ActiveRecord<GuardiaRegistrosPracticasLaboratorio>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public GuardiaRegistrosPracticasLaboratorio()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public GuardiaRegistrosPracticasLaboratorio(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public GuardiaRegistrosPracticasLaboratorio(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public GuardiaRegistrosPracticasLaboratorio(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Guardia_Registros_Practicas_Laboratorio", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPractica = new TableSchema.TableColumn(schema);
				colvarIdPractica.ColumnName = "idPractica";
				colvarIdPractica.DataType = DbType.Int32;
				colvarIdPractica.MaxLength = 0;
				colvarIdPractica.AutoIncrement = false;
				colvarIdPractica.IsNullable = false;
				colvarIdPractica.IsPrimaryKey = true;
				colvarIdPractica.IsForeignKey = false;
				colvarIdPractica.IsReadOnly = false;
				colvarIdPractica.DefaultSetting = @"";
				colvarIdPractica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPractica);
				
				TableSchema.TableColumn colvarHematocrito = new TableSchema.TableColumn(schema);
				colvarHematocrito.ColumnName = "hematocrito";
				colvarHematocrito.DataType = DbType.Boolean;
				colvarHematocrito.MaxLength = 0;
				colvarHematocrito.AutoIncrement = false;
				colvarHematocrito.IsNullable = false;
				colvarHematocrito.IsPrimaryKey = false;
				colvarHematocrito.IsForeignKey = false;
				colvarHematocrito.IsReadOnly = false;
				colvarHematocrito.DefaultSetting = @"";
				colvarHematocrito.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHematocrito);
				
				TableSchema.TableColumn colvarHemoglobina = new TableSchema.TableColumn(schema);
				colvarHemoglobina.ColumnName = "hemoglobina";
				colvarHemoglobina.DataType = DbType.Boolean;
				colvarHemoglobina.MaxLength = 0;
				colvarHemoglobina.AutoIncrement = false;
				colvarHemoglobina.IsNullable = false;
				colvarHemoglobina.IsPrimaryKey = false;
				colvarHemoglobina.IsForeignKey = false;
				colvarHemoglobina.IsReadOnly = false;
				colvarHemoglobina.DefaultSetting = @"";
				colvarHemoglobina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHemoglobina);
				
				TableSchema.TableColumn colvarFormulaLeucocitaria = new TableSchema.TableColumn(schema);
				colvarFormulaLeucocitaria.ColumnName = "formulaLeucocitaria";
				colvarFormulaLeucocitaria.DataType = DbType.Boolean;
				colvarFormulaLeucocitaria.MaxLength = 0;
				colvarFormulaLeucocitaria.AutoIncrement = false;
				colvarFormulaLeucocitaria.IsNullable = false;
				colvarFormulaLeucocitaria.IsPrimaryKey = false;
				colvarFormulaLeucocitaria.IsForeignKey = false;
				colvarFormulaLeucocitaria.IsReadOnly = false;
				colvarFormulaLeucocitaria.DefaultSetting = @"";
				colvarFormulaLeucocitaria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFormulaLeucocitaria);
				
				TableSchema.TableColumn colvarPlaquetas = new TableSchema.TableColumn(schema);
				colvarPlaquetas.ColumnName = "plaquetas";
				colvarPlaquetas.DataType = DbType.Boolean;
				colvarPlaquetas.MaxLength = 0;
				colvarPlaquetas.AutoIncrement = false;
				colvarPlaquetas.IsNullable = false;
				colvarPlaquetas.IsPrimaryKey = false;
				colvarPlaquetas.IsForeignKey = false;
				colvarPlaquetas.IsReadOnly = false;
				colvarPlaquetas.DefaultSetting = @"";
				colvarPlaquetas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlaquetas);
				
				TableSchema.TableColumn colvarUrea = new TableSchema.TableColumn(schema);
				colvarUrea.ColumnName = "urea";
				colvarUrea.DataType = DbType.Boolean;
				colvarUrea.MaxLength = 0;
				colvarUrea.AutoIncrement = false;
				colvarUrea.IsNullable = false;
				colvarUrea.IsPrimaryKey = false;
				colvarUrea.IsForeignKey = false;
				colvarUrea.IsReadOnly = false;
				colvarUrea.DefaultSetting = @"";
				colvarUrea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrea);
				
				TableSchema.TableColumn colvarCreatinina = new TableSchema.TableColumn(schema);
				colvarCreatinina.ColumnName = "creatinina";
				colvarCreatinina.DataType = DbType.Boolean;
				colvarCreatinina.MaxLength = 0;
				colvarCreatinina.AutoIncrement = false;
				colvarCreatinina.IsNullable = false;
				colvarCreatinina.IsPrimaryKey = false;
				colvarCreatinina.IsForeignKey = false;
				colvarCreatinina.IsReadOnly = false;
				colvarCreatinina.DefaultSetting = @"";
				colvarCreatinina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatinina);
				
				TableSchema.TableColumn colvarGlucosa = new TableSchema.TableColumn(schema);
				colvarGlucosa.ColumnName = "glucosa";
				colvarGlucosa.DataType = DbType.Boolean;
				colvarGlucosa.MaxLength = 0;
				colvarGlucosa.AutoIncrement = false;
				colvarGlucosa.IsNullable = false;
				colvarGlucosa.IsPrimaryKey = false;
				colvarGlucosa.IsForeignKey = false;
				colvarGlucosa.IsReadOnly = false;
				colvarGlucosa.DefaultSetting = @"";
				colvarGlucosa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGlucosa);
				
				TableSchema.TableColumn colvarLactato = new TableSchema.TableColumn(schema);
				colvarLactato.ColumnName = "lactato";
				colvarLactato.DataType = DbType.Boolean;
				colvarLactato.MaxLength = 0;
				colvarLactato.AutoIncrement = false;
				colvarLactato.IsNullable = false;
				colvarLactato.IsPrimaryKey = false;
				colvarLactato.IsForeignKey = false;
				colvarLactato.IsReadOnly = false;
				colvarLactato.DefaultSetting = @"";
				colvarLactato.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLactato);
				
				TableSchema.TableColumn colvarGot = new TableSchema.TableColumn(schema);
				colvarGot.ColumnName = "got";
				colvarGot.DataType = DbType.Boolean;
				colvarGot.MaxLength = 0;
				colvarGot.AutoIncrement = false;
				colvarGot.IsNullable = false;
				colvarGot.IsPrimaryKey = false;
				colvarGot.IsForeignKey = false;
				colvarGot.IsReadOnly = false;
				colvarGot.DefaultSetting = @"";
				colvarGot.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGot);
				
				TableSchema.TableColumn colvarAmilasa = new TableSchema.TableColumn(schema);
				colvarAmilasa.ColumnName = "amilasa";
				colvarAmilasa.DataType = DbType.Boolean;
				colvarAmilasa.MaxLength = 0;
				colvarAmilasa.AutoIncrement = false;
				colvarAmilasa.IsNullable = false;
				colvarAmilasa.IsPrimaryKey = false;
				colvarAmilasa.IsForeignKey = false;
				colvarAmilasa.IsReadOnly = false;
				colvarAmilasa.DefaultSetting = @"";
				colvarAmilasa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmilasa);
				
				TableSchema.TableColumn colvarHiv = new TableSchema.TableColumn(schema);
				colvarHiv.ColumnName = "hiv";
				colvarHiv.DataType = DbType.Boolean;
				colvarHiv.MaxLength = 0;
				colvarHiv.AutoIncrement = false;
				colvarHiv.IsNullable = false;
				colvarHiv.IsPrimaryKey = false;
				colvarHiv.IsForeignKey = false;
				colvarHiv.IsReadOnly = false;
				colvarHiv.DefaultSetting = @"";
				colvarHiv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHiv);
				
				TableSchema.TableColumn colvarCkCkmb = new TableSchema.TableColumn(schema);
				colvarCkCkmb.ColumnName = "ck_ckmb";
				colvarCkCkmb.DataType = DbType.Boolean;
				colvarCkCkmb.MaxLength = 0;
				colvarCkCkmb.AutoIncrement = false;
				colvarCkCkmb.IsNullable = false;
				colvarCkCkmb.IsPrimaryKey = false;
				colvarCkCkmb.IsForeignKey = false;
				colvarCkCkmb.IsReadOnly = false;
				colvarCkCkmb.DefaultSetting = @"";
				colvarCkCkmb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCkCkmb);
				
				TableSchema.TableColumn colvarCloro = new TableSchema.TableColumn(schema);
				colvarCloro.ColumnName = "cloro";
				colvarCloro.DataType = DbType.Boolean;
				colvarCloro.MaxLength = 0;
				colvarCloro.AutoIncrement = false;
				colvarCloro.IsNullable = false;
				colvarCloro.IsPrimaryKey = false;
				colvarCloro.IsForeignKey = false;
				colvarCloro.IsReadOnly = false;
				colvarCloro.DefaultSetting = @"";
				colvarCloro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCloro);
				
				TableSchema.TableColumn colvarIonograma = new TableSchema.TableColumn(schema);
				colvarIonograma.ColumnName = "ionograma";
				colvarIonograma.DataType = DbType.Boolean;
				colvarIonograma.MaxLength = 0;
				colvarIonograma.AutoIncrement = false;
				colvarIonograma.IsNullable = false;
				colvarIonograma.IsPrimaryKey = false;
				colvarIonograma.IsForeignKey = false;
				colvarIonograma.IsReadOnly = false;
				colvarIonograma.DefaultSetting = @"";
				colvarIonograma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIonograma);
				
				TableSchema.TableColumn colvarGasesSangre = new TableSchema.TableColumn(schema);
				colvarGasesSangre.ColumnName = "gasesSangre";
				colvarGasesSangre.DataType = DbType.Boolean;
				colvarGasesSangre.MaxLength = 0;
				colvarGasesSangre.AutoIncrement = false;
				colvarGasesSangre.IsNullable = false;
				colvarGasesSangre.IsPrimaryKey = false;
				colvarGasesSangre.IsForeignKey = false;
				colvarGasesSangre.IsReadOnly = false;
				colvarGasesSangre.DefaultSetting = @"";
				colvarGasesSangre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGasesSangre);
				
				TableSchema.TableColumn colvarCalcioIonico = new TableSchema.TableColumn(schema);
				colvarCalcioIonico.ColumnName = "calcioIonico";
				colvarCalcioIonico.DataType = DbType.Boolean;
				colvarCalcioIonico.MaxLength = 0;
				colvarCalcioIonico.AutoIncrement = false;
				colvarCalcioIonico.IsNullable = false;
				colvarCalcioIonico.IsPrimaryKey = false;
				colvarCalcioIonico.IsForeignKey = false;
				colvarCalcioIonico.IsReadOnly = false;
				colvarCalcioIonico.DefaultSetting = @"";
				colvarCalcioIonico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCalcioIonico);
				
				TableSchema.TableColumn colvarProteinas = new TableSchema.TableColumn(schema);
				colvarProteinas.ColumnName = "proteinas";
				colvarProteinas.DataType = DbType.Boolean;
				colvarProteinas.MaxLength = 0;
				colvarProteinas.AutoIncrement = false;
				colvarProteinas.IsNullable = false;
				colvarProteinas.IsPrimaryKey = false;
				colvarProteinas.IsForeignKey = false;
				colvarProteinas.IsReadOnly = false;
				colvarProteinas.DefaultSetting = @"";
				colvarProteinas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProteinas);
				
				TableSchema.TableColumn colvarSedimentoOrina = new TableSchema.TableColumn(schema);
				colvarSedimentoOrina.ColumnName = "sedimentoOrina";
				colvarSedimentoOrina.DataType = DbType.Boolean;
				colvarSedimentoOrina.MaxLength = 0;
				colvarSedimentoOrina.AutoIncrement = false;
				colvarSedimentoOrina.IsNullable = false;
				colvarSedimentoOrina.IsPrimaryKey = false;
				colvarSedimentoOrina.IsForeignKey = false;
				colvarSedimentoOrina.IsReadOnly = false;
				colvarSedimentoOrina.DefaultSetting = @"";
				colvarSedimentoOrina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSedimentoOrina);
				
				TableSchema.TableColumn colvarBilirrubina = new TableSchema.TableColumn(schema);
				colvarBilirrubina.ColumnName = "bilirrubina";
				colvarBilirrubina.DataType = DbType.Boolean;
				colvarBilirrubina.MaxLength = 0;
				colvarBilirrubina.AutoIncrement = false;
				colvarBilirrubina.IsNullable = false;
				colvarBilirrubina.IsPrimaryKey = false;
				colvarBilirrubina.IsForeignKey = false;
				colvarBilirrubina.IsReadOnly = false;
				colvarBilirrubina.DefaultSetting = @"";
				colvarBilirrubina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBilirrubina);
				
				TableSchema.TableColumn colvarTiempoProtrombina = new TableSchema.TableColumn(schema);
				colvarTiempoProtrombina.ColumnName = "tiempoProtrombina";
				colvarTiempoProtrombina.DataType = DbType.Boolean;
				colvarTiempoProtrombina.MaxLength = 0;
				colvarTiempoProtrombina.AutoIncrement = false;
				colvarTiempoProtrombina.IsNullable = false;
				colvarTiempoProtrombina.IsPrimaryKey = false;
				colvarTiempoProtrombina.IsForeignKey = false;
				colvarTiempoProtrombina.IsReadOnly = false;
				colvarTiempoProtrombina.DefaultSetting = @"";
				colvarTiempoProtrombina.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTiempoProtrombina);
				
				TableSchema.TableColumn colvarKptt = new TableSchema.TableColumn(schema);
				colvarKptt.ColumnName = "kptt";
				colvarKptt.DataType = DbType.Boolean;
				colvarKptt.MaxLength = 0;
				colvarKptt.AutoIncrement = false;
				colvarKptt.IsNullable = false;
				colvarKptt.IsPrimaryKey = false;
				colvarKptt.IsForeignKey = false;
				colvarKptt.IsReadOnly = false;
				colvarKptt.DefaultSetting = @"";
				colvarKptt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKptt);
				
				TableSchema.TableColumn colvarGpt = new TableSchema.TableColumn(schema);
				colvarGpt.ColumnName = "gpt";
				colvarGpt.DataType = DbType.Boolean;
				colvarGpt.MaxLength = 0;
				colvarGpt.AutoIncrement = false;
				colvarGpt.IsNullable = false;
				colvarGpt.IsPrimaryKey = false;
				colvarGpt.IsForeignKey = false;
				colvarGpt.IsReadOnly = false;
				colvarGpt.DefaultSetting = @"";
				colvarGpt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGpt);
				
				TableSchema.TableColumn colvarVdrl = new TableSchema.TableColumn(schema);
				colvarVdrl.ColumnName = "vdrl";
				colvarVdrl.DataType = DbType.Boolean;
				colvarVdrl.MaxLength = 0;
				colvarVdrl.AutoIncrement = false;
				colvarVdrl.IsNullable = false;
				colvarVdrl.IsPrimaryKey = false;
				colvarVdrl.IsForeignKey = false;
				colvarVdrl.IsReadOnly = false;
				colvarVdrl.DefaultSetting = @"";
				colvarVdrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVdrl);
				
				TableSchema.TableColumn colvarLdh = new TableSchema.TableColumn(schema);
				colvarLdh.ColumnName = "ldh";
				colvarLdh.DataType = DbType.Boolean;
				colvarLdh.MaxLength = 0;
				colvarLdh.AutoIncrement = false;
				colvarLdh.IsNullable = false;
				colvarLdh.IsPrimaryKey = false;
				colvarLdh.IsForeignKey = false;
				colvarLdh.IsReadOnly = false;
				colvarLdh.DefaultSetting = @"";
				colvarLdh.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLdh);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("Guardia_Registros_Practicas_Laboratorio",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPractica")]
		[Bindable(true)]
		public int IdPractica 
		{
			get { return GetColumnValue<int>(Columns.IdPractica); }
			set { SetColumnValue(Columns.IdPractica, value); }
		}
		  
		[XmlAttribute("Hematocrito")]
		[Bindable(true)]
		public bool Hematocrito 
		{
			get { return GetColumnValue<bool>(Columns.Hematocrito); }
			set { SetColumnValue(Columns.Hematocrito, value); }
		}
		  
		[XmlAttribute("Hemoglobina")]
		[Bindable(true)]
		public bool Hemoglobina 
		{
			get { return GetColumnValue<bool>(Columns.Hemoglobina); }
			set { SetColumnValue(Columns.Hemoglobina, value); }
		}
		  
		[XmlAttribute("FormulaLeucocitaria")]
		[Bindable(true)]
		public bool FormulaLeucocitaria 
		{
			get { return GetColumnValue<bool>(Columns.FormulaLeucocitaria); }
			set { SetColumnValue(Columns.FormulaLeucocitaria, value); }
		}
		  
		[XmlAttribute("Plaquetas")]
		[Bindable(true)]
		public bool Plaquetas 
		{
			get { return GetColumnValue<bool>(Columns.Plaquetas); }
			set { SetColumnValue(Columns.Plaquetas, value); }
		}
		  
		[XmlAttribute("Urea")]
		[Bindable(true)]
		public bool Urea 
		{
			get { return GetColumnValue<bool>(Columns.Urea); }
			set { SetColumnValue(Columns.Urea, value); }
		}
		  
		[XmlAttribute("Creatinina")]
		[Bindable(true)]
		public bool Creatinina 
		{
			get { return GetColumnValue<bool>(Columns.Creatinina); }
			set { SetColumnValue(Columns.Creatinina, value); }
		}
		  
		[XmlAttribute("Glucosa")]
		[Bindable(true)]
		public bool Glucosa 
		{
			get { return GetColumnValue<bool>(Columns.Glucosa); }
			set { SetColumnValue(Columns.Glucosa, value); }
		}
		  
		[XmlAttribute("Lactato")]
		[Bindable(true)]
		public bool Lactato 
		{
			get { return GetColumnValue<bool>(Columns.Lactato); }
			set { SetColumnValue(Columns.Lactato, value); }
		}
		  
		[XmlAttribute("Got")]
		[Bindable(true)]
		public bool Got 
		{
			get { return GetColumnValue<bool>(Columns.Got); }
			set { SetColumnValue(Columns.Got, value); }
		}
		  
		[XmlAttribute("Amilasa")]
		[Bindable(true)]
		public bool Amilasa 
		{
			get { return GetColumnValue<bool>(Columns.Amilasa); }
			set { SetColumnValue(Columns.Amilasa, value); }
		}
		  
		[XmlAttribute("Hiv")]
		[Bindable(true)]
		public bool Hiv 
		{
			get { return GetColumnValue<bool>(Columns.Hiv); }
			set { SetColumnValue(Columns.Hiv, value); }
		}
		  
		[XmlAttribute("CkCkmb")]
		[Bindable(true)]
		public bool CkCkmb 
		{
			get { return GetColumnValue<bool>(Columns.CkCkmb); }
			set { SetColumnValue(Columns.CkCkmb, value); }
		}
		  
		[XmlAttribute("Cloro")]
		[Bindable(true)]
		public bool Cloro 
		{
			get { return GetColumnValue<bool>(Columns.Cloro); }
			set { SetColumnValue(Columns.Cloro, value); }
		}
		  
		[XmlAttribute("Ionograma")]
		[Bindable(true)]
		public bool Ionograma 
		{
			get { return GetColumnValue<bool>(Columns.Ionograma); }
			set { SetColumnValue(Columns.Ionograma, value); }
		}
		  
		[XmlAttribute("GasesSangre")]
		[Bindable(true)]
		public bool GasesSangre 
		{
			get { return GetColumnValue<bool>(Columns.GasesSangre); }
			set { SetColumnValue(Columns.GasesSangre, value); }
		}
		  
		[XmlAttribute("CalcioIonico")]
		[Bindable(true)]
		public bool CalcioIonico 
		{
			get { return GetColumnValue<bool>(Columns.CalcioIonico); }
			set { SetColumnValue(Columns.CalcioIonico, value); }
		}
		  
		[XmlAttribute("Proteinas")]
		[Bindable(true)]
		public bool Proteinas 
		{
			get { return GetColumnValue<bool>(Columns.Proteinas); }
			set { SetColumnValue(Columns.Proteinas, value); }
		}
		  
		[XmlAttribute("SedimentoOrina")]
		[Bindable(true)]
		public bool SedimentoOrina 
		{
			get { return GetColumnValue<bool>(Columns.SedimentoOrina); }
			set { SetColumnValue(Columns.SedimentoOrina, value); }
		}
		  
		[XmlAttribute("Bilirrubina")]
		[Bindable(true)]
		public bool Bilirrubina 
		{
			get { return GetColumnValue<bool>(Columns.Bilirrubina); }
			set { SetColumnValue(Columns.Bilirrubina, value); }
		}
		  
		[XmlAttribute("TiempoProtrombina")]
		[Bindable(true)]
		public bool TiempoProtrombina 
		{
			get { return GetColumnValue<bool>(Columns.TiempoProtrombina); }
			set { SetColumnValue(Columns.TiempoProtrombina, value); }
		}
		  
		[XmlAttribute("Kptt")]
		[Bindable(true)]
		public bool Kptt 
		{
			get { return GetColumnValue<bool>(Columns.Kptt); }
			set { SetColumnValue(Columns.Kptt, value); }
		}
		  
		[XmlAttribute("Gpt")]
		[Bindable(true)]
		public bool Gpt 
		{
			get { return GetColumnValue<bool>(Columns.Gpt); }
			set { SetColumnValue(Columns.Gpt, value); }
		}
		  
		[XmlAttribute("Vdrl")]
		[Bindable(true)]
		public bool Vdrl 
		{
			get { return GetColumnValue<bool>(Columns.Vdrl); }
			set { SetColumnValue(Columns.Vdrl, value); }
		}
		  
		[XmlAttribute("Ldh")]
		[Bindable(true)]
		public bool Ldh 
		{
			get { return GetColumnValue<bool>(Columns.Ldh); }
			set { SetColumnValue(Columns.Ldh, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPractica,bool varHematocrito,bool varHemoglobina,bool varFormulaLeucocitaria,bool varPlaquetas,bool varUrea,bool varCreatinina,bool varGlucosa,bool varLactato,bool varGot,bool varAmilasa,bool varHiv,bool varCkCkmb,bool varCloro,bool varIonograma,bool varGasesSangre,bool varCalcioIonico,bool varProteinas,bool varSedimentoOrina,bool varBilirrubina,bool varTiempoProtrombina,bool varKptt,bool varGpt,bool varVdrl,bool varLdh)
		{
			GuardiaRegistrosPracticasLaboratorio item = new GuardiaRegistrosPracticasLaboratorio();
			
			item.IdPractica = varIdPractica;
			
			item.Hematocrito = varHematocrito;
			
			item.Hemoglobina = varHemoglobina;
			
			item.FormulaLeucocitaria = varFormulaLeucocitaria;
			
			item.Plaquetas = varPlaquetas;
			
			item.Urea = varUrea;
			
			item.Creatinina = varCreatinina;
			
			item.Glucosa = varGlucosa;
			
			item.Lactato = varLactato;
			
			item.Got = varGot;
			
			item.Amilasa = varAmilasa;
			
			item.Hiv = varHiv;
			
			item.CkCkmb = varCkCkmb;
			
			item.Cloro = varCloro;
			
			item.Ionograma = varIonograma;
			
			item.GasesSangre = varGasesSangre;
			
			item.CalcioIonico = varCalcioIonico;
			
			item.Proteinas = varProteinas;
			
			item.SedimentoOrina = varSedimentoOrina;
			
			item.Bilirrubina = varBilirrubina;
			
			item.TiempoProtrombina = varTiempoProtrombina;
			
			item.Kptt = varKptt;
			
			item.Gpt = varGpt;
			
			item.Vdrl = varVdrl;
			
			item.Ldh = varLdh;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPractica,bool varHematocrito,bool varHemoglobina,bool varFormulaLeucocitaria,bool varPlaquetas,bool varUrea,bool varCreatinina,bool varGlucosa,bool varLactato,bool varGot,bool varAmilasa,bool varHiv,bool varCkCkmb,bool varCloro,bool varIonograma,bool varGasesSangre,bool varCalcioIonico,bool varProteinas,bool varSedimentoOrina,bool varBilirrubina,bool varTiempoProtrombina,bool varKptt,bool varGpt,bool varVdrl,bool varLdh)
		{
			GuardiaRegistrosPracticasLaboratorio item = new GuardiaRegistrosPracticasLaboratorio();
			
				item.IdPractica = varIdPractica;
			
				item.Hematocrito = varHematocrito;
			
				item.Hemoglobina = varHemoglobina;
			
				item.FormulaLeucocitaria = varFormulaLeucocitaria;
			
				item.Plaquetas = varPlaquetas;
			
				item.Urea = varUrea;
			
				item.Creatinina = varCreatinina;
			
				item.Glucosa = varGlucosa;
			
				item.Lactato = varLactato;
			
				item.Got = varGot;
			
				item.Amilasa = varAmilasa;
			
				item.Hiv = varHiv;
			
				item.CkCkmb = varCkCkmb;
			
				item.Cloro = varCloro;
			
				item.Ionograma = varIonograma;
			
				item.GasesSangre = varGasesSangre;
			
				item.CalcioIonico = varCalcioIonico;
			
				item.Proteinas = varProteinas;
			
				item.SedimentoOrina = varSedimentoOrina;
			
				item.Bilirrubina = varBilirrubina;
			
				item.TiempoProtrombina = varTiempoProtrombina;
			
				item.Kptt = varKptt;
			
				item.Gpt = varGpt;
			
				item.Vdrl = varVdrl;
			
				item.Ldh = varLdh;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPracticaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn HematocritoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn HemoglobinaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FormulaLeucocitariaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PlaquetasColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UreaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatininaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn GlucosaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn LactatoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn GotColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn AmilasaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn HivColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn CkCkmbColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CloroColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IonogramaColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn GasesSangreColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CalcioIonicoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ProteinasColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn SedimentoOrinaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn BilirrubinaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn TiempoProtrombinaColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn KpttColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn GptColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn VdrlColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn LdhColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPractica = @"idPractica";
			 public static string Hematocrito = @"hematocrito";
			 public static string Hemoglobina = @"hemoglobina";
			 public static string FormulaLeucocitaria = @"formulaLeucocitaria";
			 public static string Plaquetas = @"plaquetas";
			 public static string Urea = @"urea";
			 public static string Creatinina = @"creatinina";
			 public static string Glucosa = @"glucosa";
			 public static string Lactato = @"lactato";
			 public static string Got = @"got";
			 public static string Amilasa = @"amilasa";
			 public static string Hiv = @"hiv";
			 public static string CkCkmb = @"ck_ckmb";
			 public static string Cloro = @"cloro";
			 public static string Ionograma = @"ionograma";
			 public static string GasesSangre = @"gasesSangre";
			 public static string CalcioIonico = @"calcioIonico";
			 public static string Proteinas = @"proteinas";
			 public static string SedimentoOrina = @"sedimentoOrina";
			 public static string Bilirrubina = @"bilirrubina";
			 public static string TiempoProtrombina = @"tiempoProtrombina";
			 public static string Kptt = @"kptt";
			 public static string Gpt = @"gpt";
			 public static string Vdrl = @"vdrl";
			 public static string Ldh = @"ldh";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
