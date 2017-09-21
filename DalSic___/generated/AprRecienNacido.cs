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
	/// Strongly-typed collection for the AprRecienNacido class.
	/// </summary>
    [Serializable]
	public partial class AprRecienNacidoCollection : ActiveList<AprRecienNacido, AprRecienNacidoCollection>
	{	   
		public AprRecienNacidoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprRecienNacidoCollection</returns>
		public AprRecienNacidoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprRecienNacido o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_RecienNacido table.
	/// </summary>
	[Serializable]
	public partial class AprRecienNacido : ActiveRecord<AprRecienNacido>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprRecienNacido()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprRecienNacido(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprRecienNacido(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprRecienNacido(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_RecienNacido", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRecienNacido = new TableSchema.TableColumn(schema);
				colvarIdRecienNacido.ColumnName = "idRecienNacido";
				colvarIdRecienNacido.DataType = DbType.Int32;
				colvarIdRecienNacido.MaxLength = 0;
				colvarIdRecienNacido.AutoIncrement = true;
				colvarIdRecienNacido.IsNullable = false;
				colvarIdRecienNacido.IsPrimaryKey = true;
				colvarIdRecienNacido.IsForeignKey = false;
				colvarIdRecienNacido.IsReadOnly = false;
				colvarIdRecienNacido.DefaultSetting = @"";
				colvarIdRecienNacido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRecienNacido);
				
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
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarPeso = new TableSchema.TableColumn(schema);
				colvarPeso.ColumnName = "Peso";
				colvarPeso.DataType = DbType.Double;
				colvarPeso.MaxLength = 0;
				colvarPeso.AutoIncrement = false;
				colvarPeso.IsNullable = true;
				colvarPeso.IsPrimaryKey = false;
				colvarPeso.IsForeignKey = false;
				colvarPeso.IsReadOnly = false;
				colvarPeso.DefaultSetting = @"";
				colvarPeso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeso);
				
				TableSchema.TableColumn colvarPerimetroCefalico = new TableSchema.TableColumn(schema);
				colvarPerimetroCefalico.ColumnName = "PerimetroCefalico";
				colvarPerimetroCefalico.DataType = DbType.Double;
				colvarPerimetroCefalico.MaxLength = 0;
				colvarPerimetroCefalico.AutoIncrement = false;
				colvarPerimetroCefalico.IsNullable = true;
				colvarPerimetroCefalico.IsPrimaryKey = false;
				colvarPerimetroCefalico.IsForeignKey = false;
				colvarPerimetroCefalico.IsReadOnly = false;
				colvarPerimetroCefalico.DefaultSetting = @"";
				colvarPerimetroCefalico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerimetroCefalico);
				
				TableSchema.TableColumn colvarLongitud = new TableSchema.TableColumn(schema);
				colvarLongitud.ColumnName = "Longitud";
				colvarLongitud.DataType = DbType.Double;
				colvarLongitud.MaxLength = 0;
				colvarLongitud.AutoIncrement = false;
				colvarLongitud.IsNullable = true;
				colvarLongitud.IsPrimaryKey = false;
				colvarLongitud.IsForeignKey = false;
				colvarLongitud.IsReadOnly = false;
				colvarLongitud.DefaultSetting = @"";
				colvarLongitud.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLongitud);
				
				TableSchema.TableColumn colvarAPGAR1 = new TableSchema.TableColumn(schema);
				colvarAPGAR1.ColumnName = "APGAR1";
				colvarAPGAR1.DataType = DbType.Int32;
				colvarAPGAR1.MaxLength = 0;
				colvarAPGAR1.AutoIncrement = false;
				colvarAPGAR1.IsNullable = true;
				colvarAPGAR1.IsPrimaryKey = false;
				colvarAPGAR1.IsForeignKey = false;
				colvarAPGAR1.IsReadOnly = false;
				colvarAPGAR1.DefaultSetting = @"";
				colvarAPGAR1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAPGAR1);
				
				TableSchema.TableColumn colvarAPGAR5 = new TableSchema.TableColumn(schema);
				colvarAPGAR5.ColumnName = "APGAR5";
				colvarAPGAR5.DataType = DbType.Int32;
				colvarAPGAR5.MaxLength = 0;
				colvarAPGAR5.AutoIncrement = false;
				colvarAPGAR5.IsNullable = true;
				colvarAPGAR5.IsPrimaryKey = false;
				colvarAPGAR5.IsForeignKey = false;
				colvarAPGAR5.IsReadOnly = false;
				colvarAPGAR5.DefaultSetting = @"";
				colvarAPGAR5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAPGAR5);
				
				TableSchema.TableColumn colvarPesoAlAlta = new TableSchema.TableColumn(schema);
				colvarPesoAlAlta.ColumnName = "PesoAlAlta";
				colvarPesoAlAlta.DataType = DbType.Double;
				colvarPesoAlAlta.MaxLength = 0;
				colvarPesoAlAlta.AutoIncrement = false;
				colvarPesoAlAlta.IsNullable = true;
				colvarPesoAlAlta.IsPrimaryKey = false;
				colvarPesoAlAlta.IsForeignKey = false;
				colvarPesoAlAlta.IsReadOnly = false;
				colvarPesoAlAlta.DefaultSetting = @"";
				colvarPesoAlAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPesoAlAlta);
				
				TableSchema.TableColumn colvarGemelar = new TableSchema.TableColumn(schema);
				colvarGemelar.ColumnName = "Gemelar";
				colvarGemelar.DataType = DbType.Boolean;
				colvarGemelar.MaxLength = 0;
				colvarGemelar.AutoIncrement = false;
				colvarGemelar.IsNullable = true;
				colvarGemelar.IsPrimaryKey = false;
				colvarGemelar.IsForeignKey = false;
				colvarGemelar.IsReadOnly = false;
				colvarGemelar.DefaultSetting = @"";
				colvarGemelar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGemelar);
				
				TableSchema.TableColumn colvarNroGesta = new TableSchema.TableColumn(schema);
				colvarNroGesta.ColumnName = "NroGesta";
				colvarNroGesta.DataType = DbType.Int32;
				colvarNroGesta.MaxLength = 0;
				colvarNroGesta.AutoIncrement = false;
				colvarNroGesta.IsNullable = true;
				colvarNroGesta.IsPrimaryKey = false;
				colvarNroGesta.IsForeignKey = false;
				colvarNroGesta.IsReadOnly = false;
				colvarNroGesta.DefaultSetting = @"";
				colvarNroGesta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroGesta);
				
				TableSchema.TableColumn colvarDiagnosticoNeonatalTemporal = new TableSchema.TableColumn(schema);
				colvarDiagnosticoNeonatalTemporal.ColumnName = "DiagnosticoNeonatalTemporal";
				colvarDiagnosticoNeonatalTemporal.DataType = DbType.AnsiString;
				colvarDiagnosticoNeonatalTemporal.MaxLength = 50;
				colvarDiagnosticoNeonatalTemporal.AutoIncrement = false;
				colvarDiagnosticoNeonatalTemporal.IsNullable = true;
				colvarDiagnosticoNeonatalTemporal.IsPrimaryKey = false;
				colvarDiagnosticoNeonatalTemporal.IsForeignKey = false;
				colvarDiagnosticoNeonatalTemporal.IsReadOnly = false;
				colvarDiagnosticoNeonatalTemporal.DefaultSetting = @"";
				colvarDiagnosticoNeonatalTemporal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoNeonatalTemporal);
				
				TableSchema.TableColumn colvarDiagnosticoNeonatalFisico = new TableSchema.TableColumn(schema);
				colvarDiagnosticoNeonatalFisico.ColumnName = "DiagnosticoNeonatalFisico";
				colvarDiagnosticoNeonatalFisico.DataType = DbType.AnsiString;
				colvarDiagnosticoNeonatalFisico.MaxLength = 50;
				colvarDiagnosticoNeonatalFisico.AutoIncrement = false;
				colvarDiagnosticoNeonatalFisico.IsNullable = true;
				colvarDiagnosticoNeonatalFisico.IsPrimaryKey = false;
				colvarDiagnosticoNeonatalFisico.IsForeignKey = false;
				colvarDiagnosticoNeonatalFisico.IsReadOnly = false;
				colvarDiagnosticoNeonatalFisico.DefaultSetting = @"";
				colvarDiagnosticoNeonatalFisico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoNeonatalFisico);
				
				TableSchema.TableColumn colvarScreeningRealizado = new TableSchema.TableColumn(schema);
				colvarScreeningRealizado.ColumnName = "ScreeningRealizado";
				colvarScreeningRealizado.DataType = DbType.Boolean;
				colvarScreeningRealizado.MaxLength = 0;
				colvarScreeningRealizado.AutoIncrement = false;
				colvarScreeningRealizado.IsNullable = true;
				colvarScreeningRealizado.IsPrimaryKey = false;
				colvarScreeningRealizado.IsForeignKey = false;
				colvarScreeningRealizado.IsReadOnly = false;
				colvarScreeningRealizado.DefaultSetting = @"";
				colvarScreeningRealizado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScreeningRealizado);
				
				TableSchema.TableColumn colvarScreeningNormal = new TableSchema.TableColumn(schema);
				colvarScreeningNormal.ColumnName = "ScreeningNormal";
				colvarScreeningNormal.DataType = DbType.Boolean;
				colvarScreeningNormal.MaxLength = 0;
				colvarScreeningNormal.AutoIncrement = false;
				colvarScreeningNormal.IsNullable = true;
				colvarScreeningNormal.IsPrimaryKey = false;
				colvarScreeningNormal.IsForeignKey = false;
				colvarScreeningNormal.IsReadOnly = false;
				colvarScreeningNormal.DefaultSetting = @"";
				colvarScreeningNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScreeningNormal);
				
				TableSchema.TableColumn colvarOEARealizado = new TableSchema.TableColumn(schema);
				colvarOEARealizado.ColumnName = "OEARealizado";
				colvarOEARealizado.DataType = DbType.AnsiString;
				colvarOEARealizado.MaxLength = 50;
				colvarOEARealizado.AutoIncrement = false;
				colvarOEARealizado.IsNullable = true;
				colvarOEARealizado.IsPrimaryKey = false;
				colvarOEARealizado.IsForeignKey = false;
				colvarOEARealizado.IsReadOnly = false;
				colvarOEARealizado.DefaultSetting = @"";
				colvarOEARealizado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOEARealizado);
				
				TableSchema.TableColumn colvarEmbarazoNormal = new TableSchema.TableColumn(schema);
				colvarEmbarazoNormal.ColumnName = "EmbarazoNormal";
				colvarEmbarazoNormal.DataType = DbType.Boolean;
				colvarEmbarazoNormal.MaxLength = 0;
				colvarEmbarazoNormal.AutoIncrement = false;
				colvarEmbarazoNormal.IsNullable = true;
				colvarEmbarazoNormal.IsPrimaryKey = false;
				colvarEmbarazoNormal.IsForeignKey = false;
				colvarEmbarazoNormal.IsReadOnly = false;
				colvarEmbarazoNormal.DefaultSetting = @"";
				colvarEmbarazoNormal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazoNormal);
				
				TableSchema.TableColumn colvarIdTipoParto = new TableSchema.TableColumn(schema);
				colvarIdTipoParto.ColumnName = "idTipoParto";
				colvarIdTipoParto.DataType = DbType.Int32;
				colvarIdTipoParto.MaxLength = 0;
				colvarIdTipoParto.AutoIncrement = false;
				colvarIdTipoParto.IsNullable = true;
				colvarIdTipoParto.IsPrimaryKey = false;
				colvarIdTipoParto.IsForeignKey = true;
				colvarIdTipoParto.IsReadOnly = false;
				colvarIdTipoParto.DefaultSetting = @"";
				
					colvarIdTipoParto.ForeignKeyTableName = "APR_TipoParto";
				schema.Columns.Add(colvarIdTipoParto);
				
				TableSchema.TableColumn colvarPesquizaNeonatal = new TableSchema.TableColumn(schema);
				colvarPesquizaNeonatal.ColumnName = "PesquizaNeonatal";
				colvarPesquizaNeonatal.DataType = DbType.Boolean;
				colvarPesquizaNeonatal.MaxLength = 0;
				colvarPesquizaNeonatal.AutoIncrement = false;
				colvarPesquizaNeonatal.IsNullable = true;
				colvarPesquizaNeonatal.IsPrimaryKey = false;
				colvarPesquizaNeonatal.IsForeignKey = false;
				colvarPesquizaNeonatal.IsReadOnly = false;
				colvarPesquizaNeonatal.DefaultSetting = @"";
				colvarPesquizaNeonatal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPesquizaNeonatal);
				
				TableSchema.TableColumn colvarHb12meses = new TableSchema.TableColumn(schema);
				colvarHb12meses.ColumnName = "Hb12meses";
				colvarHb12meses.DataType = DbType.Boolean;
				colvarHb12meses.MaxLength = 0;
				colvarHb12meses.AutoIncrement = false;
				colvarHb12meses.IsNullable = true;
				colvarHb12meses.IsPrimaryKey = false;
				colvarHb12meses.IsForeignKey = false;
				colvarHb12meses.IsReadOnly = false;
				colvarHb12meses.DefaultSetting = @"";
				colvarHb12meses.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHb12meses);
				
				TableSchema.TableColumn colvarTA3 = new TableSchema.TableColumn(schema);
				colvarTA3.ColumnName = "TA3";
				colvarTA3.DataType = DbType.Boolean;
				colvarTA3.MaxLength = 0;
				colvarTA3.AutoIncrement = false;
				colvarTA3.IsNullable = true;
				colvarTA3.IsPrimaryKey = false;
				colvarTA3.IsForeignKey = false;
				colvarTA3.IsReadOnly = false;
				colvarTA3.DefaultSetting = @"";
				colvarTA3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTA3);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_RecienNacido",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRecienNacido")]
		[Bindable(true)]
		public int IdRecienNacido 
		{
			get { return GetColumnValue<int>(Columns.IdRecienNacido); }
			set { SetColumnValue(Columns.IdRecienNacido, value); }
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
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Peso")]
		[Bindable(true)]
		public double? Peso 
		{
			get { return GetColumnValue<double?>(Columns.Peso); }
			set { SetColumnValue(Columns.Peso, value); }
		}
		  
		[XmlAttribute("PerimetroCefalico")]
		[Bindable(true)]
		public double? PerimetroCefalico 
		{
			get { return GetColumnValue<double?>(Columns.PerimetroCefalico); }
			set { SetColumnValue(Columns.PerimetroCefalico, value); }
		}
		  
		[XmlAttribute("Longitud")]
		[Bindable(true)]
		public double? Longitud 
		{
			get { return GetColumnValue<double?>(Columns.Longitud); }
			set { SetColumnValue(Columns.Longitud, value); }
		}
		  
		[XmlAttribute("APGAR1")]
		[Bindable(true)]
		public int? APGAR1 
		{
			get { return GetColumnValue<int?>(Columns.APGAR1); }
			set { SetColumnValue(Columns.APGAR1, value); }
		}
		  
		[XmlAttribute("APGAR5")]
		[Bindable(true)]
		public int? APGAR5 
		{
			get { return GetColumnValue<int?>(Columns.APGAR5); }
			set { SetColumnValue(Columns.APGAR5, value); }
		}
		  
		[XmlAttribute("PesoAlAlta")]
		[Bindable(true)]
		public double? PesoAlAlta 
		{
			get { return GetColumnValue<double?>(Columns.PesoAlAlta); }
			set { SetColumnValue(Columns.PesoAlAlta, value); }
		}
		  
		[XmlAttribute("Gemelar")]
		[Bindable(true)]
		public bool? Gemelar 
		{
			get { return GetColumnValue<bool?>(Columns.Gemelar); }
			set { SetColumnValue(Columns.Gemelar, value); }
		}
		  
		[XmlAttribute("NroGesta")]
		[Bindable(true)]
		public int? NroGesta 
		{
			get { return GetColumnValue<int?>(Columns.NroGesta); }
			set { SetColumnValue(Columns.NroGesta, value); }
		}
		  
		[XmlAttribute("DiagnosticoNeonatalTemporal")]
		[Bindable(true)]
		public string DiagnosticoNeonatalTemporal 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoNeonatalTemporal); }
			set { SetColumnValue(Columns.DiagnosticoNeonatalTemporal, value); }
		}
		  
		[XmlAttribute("DiagnosticoNeonatalFisico")]
		[Bindable(true)]
		public string DiagnosticoNeonatalFisico 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoNeonatalFisico); }
			set { SetColumnValue(Columns.DiagnosticoNeonatalFisico, value); }
		}
		  
		[XmlAttribute("ScreeningRealizado")]
		[Bindable(true)]
		public bool? ScreeningRealizado 
		{
			get { return GetColumnValue<bool?>(Columns.ScreeningRealizado); }
			set { SetColumnValue(Columns.ScreeningRealizado, value); }
		}
		  
		[XmlAttribute("ScreeningNormal")]
		[Bindable(true)]
		public bool? ScreeningNormal 
		{
			get { return GetColumnValue<bool?>(Columns.ScreeningNormal); }
			set { SetColumnValue(Columns.ScreeningNormal, value); }
		}
		  
		[XmlAttribute("OEARealizado")]
		[Bindable(true)]
		public string OEARealizado 
		{
			get { return GetColumnValue<string>(Columns.OEARealizado); }
			set { SetColumnValue(Columns.OEARealizado, value); }
		}
		  
		[XmlAttribute("EmbarazoNormal")]
		[Bindable(true)]
		public bool? EmbarazoNormal 
		{
			get { return GetColumnValue<bool?>(Columns.EmbarazoNormal); }
			set { SetColumnValue(Columns.EmbarazoNormal, value); }
		}
		  
		[XmlAttribute("IdTipoParto")]
		[Bindable(true)]
		public int? IdTipoParto 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoParto); }
			set { SetColumnValue(Columns.IdTipoParto, value); }
		}
		  
		[XmlAttribute("PesquizaNeonatal")]
		[Bindable(true)]
		public bool? PesquizaNeonatal 
		{
			get { return GetColumnValue<bool?>(Columns.PesquizaNeonatal); }
			set { SetColumnValue(Columns.PesquizaNeonatal, value); }
		}
		  
		[XmlAttribute("Hb12meses")]
		[Bindable(true)]
		public bool? Hb12meses 
		{
			get { return GetColumnValue<bool?>(Columns.Hb12meses); }
			set { SetColumnValue(Columns.Hb12meses, value); }
		}
		  
		[XmlAttribute("TA3")]
		[Bindable(true)]
		public bool? TA3 
		{
			get { return GetColumnValue<bool?>(Columns.TA3); }
			set { SetColumnValue(Columns.TA3, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.AprRelRecienNacidoDefectoCongenitoCollection colAprRelRecienNacidoDefectoCongenitoRecords;
		public DalSic.AprRelRecienNacidoDefectoCongenitoCollection AprRelRecienNacidoDefectoCongenitoRecords
		{
			get
			{
				if(colAprRelRecienNacidoDefectoCongenitoRecords == null)
				{
					colAprRelRecienNacidoDefectoCongenitoRecords = new DalSic.AprRelRecienNacidoDefectoCongenitoCollection().Where(AprRelRecienNacidoDefectoCongenito.Columns.IdRecienNacido, IdRecienNacido).Load();
					colAprRelRecienNacidoDefectoCongenitoRecords.ListChanged += new ListChangedEventHandler(colAprRelRecienNacidoDefectoCongenitoRecords_ListChanged);
				}
				return colAprRelRecienNacidoDefectoCongenitoRecords;			
			}
			set 
			{ 
					colAprRelRecienNacidoDefectoCongenitoRecords = value; 
					colAprRelRecienNacidoDefectoCongenitoRecords.ListChanged += new ListChangedEventHandler(colAprRelRecienNacidoDefectoCongenitoRecords_ListChanged);
			}
		}
		
		void colAprRelRecienNacidoDefectoCongenitoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colAprRelRecienNacidoDefectoCongenitoRecords[e.NewIndex].IdRecienNacido = IdRecienNacido;
		    }
		}
				
		private DalSic.AprRelRecienNacidoEnfermedadCollection colAprRelRecienNacidoEnfermedadRecords;
		public DalSic.AprRelRecienNacidoEnfermedadCollection AprRelRecienNacidoEnfermedadRecords
		{
			get
			{
				if(colAprRelRecienNacidoEnfermedadRecords == null)
				{
					colAprRelRecienNacidoEnfermedadRecords = new DalSic.AprRelRecienNacidoEnfermedadCollection().Where(AprRelRecienNacidoEnfermedad.Columns.IdRecienNacido, IdRecienNacido).Load();
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
		        colAprRelRecienNacidoEnfermedadRecords[e.NewIndex].IdRecienNacido = IdRecienNacido;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprTipoParto ActiveRecord object related to this AprRecienNacido
		/// 
		/// </summary>
		public DalSic.AprTipoParto AprTipoParto
		{
			get { return DalSic.AprTipoParto.FetchByID(this.IdTipoParto); }
			set { SetColumnValue("idTipoParto", value.IdTipoParto); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdEfector,int? varIdPaciente,double? varPeso,double? varPerimetroCefalico,double? varLongitud,int? varAPGAR1,int? varAPGAR5,double? varPesoAlAlta,bool? varGemelar,int? varNroGesta,string varDiagnosticoNeonatalTemporal,string varDiagnosticoNeonatalFisico,bool? varScreeningRealizado,bool? varScreeningNormal,string varOEARealizado,bool? varEmbarazoNormal,int? varIdTipoParto,bool? varPesquizaNeonatal,bool? varHb12meses,bool? varTA3,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprRecienNacido item = new AprRecienNacido();
			
			item.IdEfector = varIdEfector;
			
			item.IdPaciente = varIdPaciente;
			
			item.Peso = varPeso;
			
			item.PerimetroCefalico = varPerimetroCefalico;
			
			item.Longitud = varLongitud;
			
			item.APGAR1 = varAPGAR1;
			
			item.APGAR5 = varAPGAR5;
			
			item.PesoAlAlta = varPesoAlAlta;
			
			item.Gemelar = varGemelar;
			
			item.NroGesta = varNroGesta;
			
			item.DiagnosticoNeonatalTemporal = varDiagnosticoNeonatalTemporal;
			
			item.DiagnosticoNeonatalFisico = varDiagnosticoNeonatalFisico;
			
			item.ScreeningRealizado = varScreeningRealizado;
			
			item.ScreeningNormal = varScreeningNormal;
			
			item.OEARealizado = varOEARealizado;
			
			item.EmbarazoNormal = varEmbarazoNormal;
			
			item.IdTipoParto = varIdTipoParto;
			
			item.PesquizaNeonatal = varPesquizaNeonatal;
			
			item.Hb12meses = varHb12meses;
			
			item.TA3 = varTA3;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRecienNacido,int varIdEfector,int? varIdPaciente,double? varPeso,double? varPerimetroCefalico,double? varLongitud,int? varAPGAR1,int? varAPGAR5,double? varPesoAlAlta,bool? varGemelar,int? varNroGesta,string varDiagnosticoNeonatalTemporal,string varDiagnosticoNeonatalFisico,bool? varScreeningRealizado,bool? varScreeningNormal,string varOEARealizado,bool? varEmbarazoNormal,int? varIdTipoParto,bool? varPesquizaNeonatal,bool? varHb12meses,bool? varTA3,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn)
		{
			AprRecienNacido item = new AprRecienNacido();
			
				item.IdRecienNacido = varIdRecienNacido;
			
				item.IdEfector = varIdEfector;
			
				item.IdPaciente = varIdPaciente;
			
				item.Peso = varPeso;
			
				item.PerimetroCefalico = varPerimetroCefalico;
			
				item.Longitud = varLongitud;
			
				item.APGAR1 = varAPGAR1;
			
				item.APGAR5 = varAPGAR5;
			
				item.PesoAlAlta = varPesoAlAlta;
			
				item.Gemelar = varGemelar;
			
				item.NroGesta = varNroGesta;
			
				item.DiagnosticoNeonatalTemporal = varDiagnosticoNeonatalTemporal;
			
				item.DiagnosticoNeonatalFisico = varDiagnosticoNeonatalFisico;
			
				item.ScreeningRealizado = varScreeningRealizado;
			
				item.ScreeningNormal = varScreeningNormal;
			
				item.OEARealizado = varOEARealizado;
			
				item.EmbarazoNormal = varEmbarazoNormal;
			
				item.IdTipoParto = varIdTipoParto;
			
				item.PesquizaNeonatal = varPesquizaNeonatal;
			
				item.Hb12meses = varHb12meses;
			
				item.TA3 = varTA3;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRecienNacidoColumn
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
        
        
        
        public static TableSchema.TableColumn PesoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PerimetroCefalicoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn LongitudColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn APGAR1Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn APGAR5Column
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PesoAlAltaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn GemelarColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NroGestaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoNeonatalTemporalColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoNeonatalFisicoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ScreeningRealizadoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ScreeningNormalColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn OEARealizadoColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoNormalColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPartoColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn PesquizaNeonatalColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn Hb12mesesColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn TA3Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRecienNacido = @"idRecienNacido";
			 public static string IdEfector = @"idEfector";
			 public static string IdPaciente = @"idPaciente";
			 public static string Peso = @"Peso";
			 public static string PerimetroCefalico = @"PerimetroCefalico";
			 public static string Longitud = @"Longitud";
			 public static string APGAR1 = @"APGAR1";
			 public static string APGAR5 = @"APGAR5";
			 public static string PesoAlAlta = @"PesoAlAlta";
			 public static string Gemelar = @"Gemelar";
			 public static string NroGesta = @"NroGesta";
			 public static string DiagnosticoNeonatalTemporal = @"DiagnosticoNeonatalTemporal";
			 public static string DiagnosticoNeonatalFisico = @"DiagnosticoNeonatalFisico";
			 public static string ScreeningRealizado = @"ScreeningRealizado";
			 public static string ScreeningNormal = @"ScreeningNormal";
			 public static string OEARealizado = @"OEARealizado";
			 public static string EmbarazoNormal = @"EmbarazoNormal";
			 public static string IdTipoParto = @"idTipoParto";
			 public static string PesquizaNeonatal = @"PesquizaNeonatal";
			 public static string Hb12meses = @"Hb12meses";
			 public static string TA3 = @"TA3";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colAprRelRecienNacidoDefectoCongenitoRecords != null)
                {
                    foreach (DalSic.AprRelRecienNacidoDefectoCongenito item in colAprRelRecienNacidoDefectoCongenitoRecords)
                    {
                        if (item.IdRecienNacido != IdRecienNacido)
                        {
                            item.IdRecienNacido = IdRecienNacido;
                        }
                    }
               }
		
                if (colAprRelRecienNacidoEnfermedadRecords != null)
                {
                    foreach (DalSic.AprRelRecienNacidoEnfermedad item in colAprRelRecienNacidoEnfermedadRecords)
                    {
                        if (item.IdRecienNacido != IdRecienNacido)
                        {
                            item.IdRecienNacido = IdRecienNacido;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colAprRelRecienNacidoDefectoCongenitoRecords != null)
                {
                    colAprRelRecienNacidoDefectoCongenitoRecords.SaveAll();
               }
		
                if (colAprRelRecienNacidoEnfermedadRecords != null)
                {
                    colAprRelRecienNacidoEnfermedadRecords.SaveAll();
               }
		}
        #endregion
	}
}
