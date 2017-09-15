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
	/// Strongly-typed collection for the MamPiezaQuirurgica class.
	/// </summary>
    [Serializable]
	public partial class MamPiezaQuirurgicaCollection : ActiveList<MamPiezaQuirurgica, MamPiezaQuirurgicaCollection>
	{	   
		public MamPiezaQuirurgicaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MamPiezaQuirurgicaCollection</returns>
		public MamPiezaQuirurgicaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MamPiezaQuirurgica o = this[i];
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
	/// This is an ActiveRecord class which wraps the MAM_PiezaQuirurgica table.
	/// </summary>
	[Serializable]
	public partial class MamPiezaQuirurgica : ActiveRecord<MamPiezaQuirurgica>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MamPiezaQuirurgica()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MamPiezaQuirurgica(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MamPiezaQuirurgica(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MamPiezaQuirurgica(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("MAM_PiezaQuirurgica", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPiezaQuirurgica = new TableSchema.TableColumn(schema);
				colvarIdPiezaQuirurgica.ColumnName = "idPiezaQuirurgica";
				colvarIdPiezaQuirurgica.DataType = DbType.Int32;
				colvarIdPiezaQuirurgica.MaxLength = 0;
				colvarIdPiezaQuirurgica.AutoIncrement = true;
				colvarIdPiezaQuirurgica.IsNullable = false;
				colvarIdPiezaQuirurgica.IsPrimaryKey = true;
				colvarIdPiezaQuirurgica.IsForeignKey = false;
				colvarIdPiezaQuirurgica.IsReadOnly = false;
				colvarIdPiezaQuirurgica.DefaultSetting = @"";
				colvarIdPiezaQuirurgica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPiezaQuirurgica);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = false;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				
						colvarIdPaciente.DefaultSetting = @"((0))";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = false;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				
						colvarEdad.DefaultSetting = @"((0))";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarFechaTomaMuestra = new TableSchema.TableColumn(schema);
				colvarFechaTomaMuestra.ColumnName = "fechaTomaMuestra";
				colvarFechaTomaMuestra.DataType = DbType.DateTime;
				colvarFechaTomaMuestra.MaxLength = 0;
				colvarFechaTomaMuestra.AutoIncrement = false;
				colvarFechaTomaMuestra.IsNullable = false;
				colvarFechaTomaMuestra.IsPrimaryKey = false;
				colvarFechaTomaMuestra.IsForeignKey = false;
				colvarFechaTomaMuestra.IsReadOnly = false;
				colvarFechaTomaMuestra.DefaultSetting = @"";
				colvarFechaTomaMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTomaMuestra);
				
				TableSchema.TableColumn colvarFechaRecepcion = new TableSchema.TableColumn(schema);
				colvarFechaRecepcion.ColumnName = "fechaRecepcion";
				colvarFechaRecepcion.DataType = DbType.DateTime;
				colvarFechaRecepcion.MaxLength = 0;
				colvarFechaRecepcion.AutoIncrement = false;
				colvarFechaRecepcion.IsNullable = false;
				colvarFechaRecepcion.IsPrimaryKey = false;
				colvarFechaRecepcion.IsForeignKey = false;
				colvarFechaRecepcion.IsReadOnly = false;
				colvarFechaRecepcion.DefaultSetting = @"";
				colvarFechaRecepcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecepcion);
				
				TableSchema.TableColumn colvarNumeroIngreso = new TableSchema.TableColumn(schema);
				colvarNumeroIngreso.ColumnName = "numeroIngreso";
				colvarNumeroIngreso.DataType = DbType.AnsiString;
				colvarNumeroIngreso.MaxLength = 20;
				colvarNumeroIngreso.AutoIncrement = false;
				colvarNumeroIngreso.IsNullable = false;
				colvarNumeroIngreso.IsPrimaryKey = false;
				colvarNumeroIngreso.IsForeignKey = false;
				colvarNumeroIngreso.IsReadOnly = false;
				
						colvarNumeroIngreso.DefaultSetting = @"((0))";
				colvarNumeroIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroIngreso);
				
				TableSchema.TableColumn colvarMaterialIngresado = new TableSchema.TableColumn(schema);
				colvarMaterialIngresado.ColumnName = "materialIngresado";
				colvarMaterialIngresado.DataType = DbType.AnsiString;
				colvarMaterialIngresado.MaxLength = 20;
				colvarMaterialIngresado.AutoIncrement = false;
				colvarMaterialIngresado.IsNullable = false;
				colvarMaterialIngresado.IsPrimaryKey = false;
				colvarMaterialIngresado.IsForeignKey = false;
				colvarMaterialIngresado.IsReadOnly = false;
				
						colvarMaterialIngresado.DefaultSetting = @"((0))";
				colvarMaterialIngresado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaterialIngresado);
				
				TableSchema.TableColumn colvarCentinelaDerecho = new TableSchema.TableColumn(schema);
				colvarCentinelaDerecho.ColumnName = "centinelaDerecho";
				colvarCentinelaDerecho.DataType = DbType.AnsiString;
				colvarCentinelaDerecho.MaxLength = 10;
				colvarCentinelaDerecho.AutoIncrement = false;
				colvarCentinelaDerecho.IsNullable = false;
				colvarCentinelaDerecho.IsPrimaryKey = false;
				colvarCentinelaDerecho.IsForeignKey = false;
				colvarCentinelaDerecho.IsReadOnly = false;
				
						colvarCentinelaDerecho.DefaultSetting = @"((0))";
				colvarCentinelaDerecho.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCentinelaDerecho);
				
				TableSchema.TableColumn colvarCentinelaIzquierdo = new TableSchema.TableColumn(schema);
				colvarCentinelaIzquierdo.ColumnName = "centinelaIzquierdo";
				colvarCentinelaIzquierdo.DataType = DbType.AnsiString;
				colvarCentinelaIzquierdo.MaxLength = 10;
				colvarCentinelaIzquierdo.AutoIncrement = false;
				colvarCentinelaIzquierdo.IsNullable = false;
				colvarCentinelaIzquierdo.IsPrimaryKey = false;
				colvarCentinelaIzquierdo.IsForeignKey = false;
				colvarCentinelaIzquierdo.IsReadOnly = false;
				
						colvarCentinelaIzquierdo.DefaultSetting = @"((0))";
				colvarCentinelaIzquierdo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCentinelaIzquierdo);
				
				TableSchema.TableColumn colvarFechaInforme = new TableSchema.TableColumn(schema);
				colvarFechaInforme.ColumnName = "fechaInforme";
				colvarFechaInforme.DataType = DbType.DateTime;
				colvarFechaInforme.MaxLength = 0;
				colvarFechaInforme.AutoIncrement = false;
				colvarFechaInforme.IsNullable = false;
				colvarFechaInforme.IsPrimaryKey = false;
				colvarFechaInforme.IsForeignKey = false;
				colvarFechaInforme.IsReadOnly = false;
				colvarFechaInforme.DefaultSetting = @"";
				colvarFechaInforme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInforme);
				
				TableSchema.TableColumn colvarIdDiagnosticoHistologico = new TableSchema.TableColumn(schema);
				colvarIdDiagnosticoHistologico.ColumnName = "idDiagnosticoHistologico";
				colvarIdDiagnosticoHistologico.DataType = DbType.Int32;
				colvarIdDiagnosticoHistologico.MaxLength = 0;
				colvarIdDiagnosticoHistologico.AutoIncrement = false;
				colvarIdDiagnosticoHistologico.IsNullable = false;
				colvarIdDiagnosticoHistologico.IsPrimaryKey = false;
				colvarIdDiagnosticoHistologico.IsForeignKey = true;
				colvarIdDiagnosticoHistologico.IsReadOnly = false;
				
						colvarIdDiagnosticoHistologico.DefaultSetting = @"((0))";
				
					colvarIdDiagnosticoHistologico.ForeignKeyTableName = "MAM_DiagnoticoHistologico";
				schema.Columns.Add(colvarIdDiagnosticoHistologico);
				
				TableSchema.TableColumn colvarTamanioTumor = new TableSchema.TableColumn(schema);
				colvarTamanioTumor.ColumnName = "tamanioTumor";
				colvarTamanioTumor.DataType = DbType.Decimal;
				colvarTamanioTumor.MaxLength = 0;
				colvarTamanioTumor.AutoIncrement = false;
				colvarTamanioTumor.IsNullable = false;
				colvarTamanioTumor.IsPrimaryKey = false;
				colvarTamanioTumor.IsForeignKey = false;
				colvarTamanioTumor.IsReadOnly = false;
				
						colvarTamanioTumor.DefaultSetting = @"((0))";
				colvarTamanioTumor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTamanioTumor);
				
				TableSchema.TableColumn colvarGangliosResecados = new TableSchema.TableColumn(schema);
				colvarGangliosResecados.ColumnName = "gangliosResecados";
				colvarGangliosResecados.DataType = DbType.Int32;
				colvarGangliosResecados.MaxLength = 0;
				colvarGangliosResecados.AutoIncrement = false;
				colvarGangliosResecados.IsNullable = false;
				colvarGangliosResecados.IsPrimaryKey = false;
				colvarGangliosResecados.IsForeignKey = false;
				colvarGangliosResecados.IsReadOnly = false;
				
						colvarGangliosResecados.DefaultSetting = @"((0))";
				colvarGangliosResecados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGangliosResecados);
				
				TableSchema.TableColumn colvarGangliosPositivos = new TableSchema.TableColumn(schema);
				colvarGangliosPositivos.ColumnName = "gangliosPositivos";
				colvarGangliosPositivos.DataType = DbType.Int32;
				colvarGangliosPositivos.MaxLength = 0;
				colvarGangliosPositivos.AutoIncrement = false;
				colvarGangliosPositivos.IsNullable = false;
				colvarGangliosPositivos.IsPrimaryKey = false;
				colvarGangliosPositivos.IsForeignKey = false;
				colvarGangliosPositivos.IsReadOnly = false;
				
						colvarGangliosPositivos.DefaultSetting = @"((0))";
				colvarGangliosPositivos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGangliosPositivos);
				
				TableSchema.TableColumn colvarReceptorHormonalRE = new TableSchema.TableColumn(schema);
				colvarReceptorHormonalRE.ColumnName = "receptorHormonalRE";
				colvarReceptorHormonalRE.DataType = DbType.Int32;
				colvarReceptorHormonalRE.MaxLength = 0;
				colvarReceptorHormonalRE.AutoIncrement = false;
				colvarReceptorHormonalRE.IsNullable = false;
				colvarReceptorHormonalRE.IsPrimaryKey = false;
				colvarReceptorHormonalRE.IsForeignKey = false;
				colvarReceptorHormonalRE.IsReadOnly = false;
				
						colvarReceptorHormonalRE.DefaultSetting = @"((0))";
				colvarReceptorHormonalRE.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReceptorHormonalRE);
				
				TableSchema.TableColumn colvarReceptorHormonalRP = new TableSchema.TableColumn(schema);
				colvarReceptorHormonalRP.ColumnName = "receptorHormonalRP";
				colvarReceptorHormonalRP.DataType = DbType.Int32;
				colvarReceptorHormonalRP.MaxLength = 0;
				colvarReceptorHormonalRP.AutoIncrement = false;
				colvarReceptorHormonalRP.IsNullable = false;
				colvarReceptorHormonalRP.IsPrimaryKey = false;
				colvarReceptorHormonalRP.IsForeignKey = false;
				colvarReceptorHormonalRP.IsReadOnly = false;
				
						colvarReceptorHormonalRP.DefaultSetting = @"((0))";
				colvarReceptorHormonalRP.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReceptorHormonalRP);
				
				TableSchema.TableColumn colvarCerbHerb = new TableSchema.TableColumn(schema);
				colvarCerbHerb.ColumnName = "CerbHerb";
				colvarCerbHerb.DataType = DbType.Int32;
				colvarCerbHerb.MaxLength = 0;
				colvarCerbHerb.AutoIncrement = false;
				colvarCerbHerb.IsNullable = false;
				colvarCerbHerb.IsPrimaryKey = false;
				colvarCerbHerb.IsForeignKey = false;
				colvarCerbHerb.IsReadOnly = false;
				
						colvarCerbHerb.DefaultSetting = @"((0))";
				colvarCerbHerb.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCerbHerb);
				
				TableSchema.TableColumn colvarIdResponsableInforme = new TableSchema.TableColumn(schema);
				colvarIdResponsableInforme.ColumnName = "idResponsableInforme";
				colvarIdResponsableInforme.DataType = DbType.Int32;
				colvarIdResponsableInforme.MaxLength = 0;
				colvarIdResponsableInforme.AutoIncrement = false;
				colvarIdResponsableInforme.IsNullable = false;
				colvarIdResponsableInforme.IsPrimaryKey = false;
				colvarIdResponsableInforme.IsForeignKey = true;
				colvarIdResponsableInforme.IsReadOnly = false;
				
						colvarIdResponsableInforme.DefaultSetting = @"((0))";
				
					colvarIdResponsableInforme.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdResponsableInforme);
				
				TableSchema.TableColumn colvarIdCentroSaludInforme = new TableSchema.TableColumn(schema);
				colvarIdCentroSaludInforme.ColumnName = "idCentroSaludInforme";
				colvarIdCentroSaludInforme.DataType = DbType.Int32;
				colvarIdCentroSaludInforme.MaxLength = 0;
				colvarIdCentroSaludInforme.AutoIncrement = false;
				colvarIdCentroSaludInforme.IsNullable = false;
				colvarIdCentroSaludInforme.IsPrimaryKey = false;
				colvarIdCentroSaludInforme.IsForeignKey = true;
				colvarIdCentroSaludInforme.IsReadOnly = false;
				
						colvarIdCentroSaludInforme.DefaultSetting = @"((0))";
				
					colvarIdCentroSaludInforme.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdCentroSaludInforme);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 2000;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = false;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				
						colvarObservaciones.DefaultSetting = @"('')";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"('')";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("MAM_PiezaQuirurgica",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPiezaQuirurgica")]
		[Bindable(true)]
		public int IdPiezaQuirurgica 
		{
			get { return GetColumnValue<int>(Columns.IdPiezaQuirurgica); }
			set { SetColumnValue(Columns.IdPiezaQuirurgica, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int IdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("FechaTomaMuestra")]
		[Bindable(true)]
		public DateTime FechaTomaMuestra 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaTomaMuestra); }
			set { SetColumnValue(Columns.FechaTomaMuestra, value); }
		}
		  
		[XmlAttribute("FechaRecepcion")]
		[Bindable(true)]
		public DateTime FechaRecepcion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRecepcion); }
			set { SetColumnValue(Columns.FechaRecepcion, value); }
		}
		  
		[XmlAttribute("NumeroIngreso")]
		[Bindable(true)]
		public string NumeroIngreso 
		{
			get { return GetColumnValue<string>(Columns.NumeroIngreso); }
			set { SetColumnValue(Columns.NumeroIngreso, value); }
		}
		  
		[XmlAttribute("MaterialIngresado")]
		[Bindable(true)]
		public string MaterialIngresado 
		{
			get { return GetColumnValue<string>(Columns.MaterialIngresado); }
			set { SetColumnValue(Columns.MaterialIngresado, value); }
		}
		  
		[XmlAttribute("CentinelaDerecho")]
		[Bindable(true)]
		public string CentinelaDerecho 
		{
			get { return GetColumnValue<string>(Columns.CentinelaDerecho); }
			set { SetColumnValue(Columns.CentinelaDerecho, value); }
		}
		  
		[XmlAttribute("CentinelaIzquierdo")]
		[Bindable(true)]
		public string CentinelaIzquierdo 
		{
			get { return GetColumnValue<string>(Columns.CentinelaIzquierdo); }
			set { SetColumnValue(Columns.CentinelaIzquierdo, value); }
		}
		  
		[XmlAttribute("FechaInforme")]
		[Bindable(true)]
		public DateTime FechaInforme 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaInforme); }
			set { SetColumnValue(Columns.FechaInforme, value); }
		}
		  
		[XmlAttribute("IdDiagnosticoHistologico")]
		[Bindable(true)]
		public int IdDiagnosticoHistologico 
		{
			get { return GetColumnValue<int>(Columns.IdDiagnosticoHistologico); }
			set { SetColumnValue(Columns.IdDiagnosticoHistologico, value); }
		}
		  
		[XmlAttribute("TamanioTumor")]
		[Bindable(true)]
		public decimal TamanioTumor 
		{
			get { return GetColumnValue<decimal>(Columns.TamanioTumor); }
			set { SetColumnValue(Columns.TamanioTumor, value); }
		}
		  
		[XmlAttribute("GangliosResecados")]
		[Bindable(true)]
		public int GangliosResecados 
		{
			get { return GetColumnValue<int>(Columns.GangliosResecados); }
			set { SetColumnValue(Columns.GangliosResecados, value); }
		}
		  
		[XmlAttribute("GangliosPositivos")]
		[Bindable(true)]
		public int GangliosPositivos 
		{
			get { return GetColumnValue<int>(Columns.GangliosPositivos); }
			set { SetColumnValue(Columns.GangliosPositivos, value); }
		}
		  
		[XmlAttribute("ReceptorHormonalRE")]
		[Bindable(true)]
		public int ReceptorHormonalRE 
		{
			get { return GetColumnValue<int>(Columns.ReceptorHormonalRE); }
			set { SetColumnValue(Columns.ReceptorHormonalRE, value); }
		}
		  
		[XmlAttribute("ReceptorHormonalRP")]
		[Bindable(true)]
		public int ReceptorHormonalRP 
		{
			get { return GetColumnValue<int>(Columns.ReceptorHormonalRP); }
			set { SetColumnValue(Columns.ReceptorHormonalRP, value); }
		}
		  
		[XmlAttribute("CerbHerb")]
		[Bindable(true)]
		public int CerbHerb 
		{
			get { return GetColumnValue<int>(Columns.CerbHerb); }
			set { SetColumnValue(Columns.CerbHerb, value); }
		}
		  
		[XmlAttribute("IdResponsableInforme")]
		[Bindable(true)]
		public int IdResponsableInforme 
		{
			get { return GetColumnValue<int>(Columns.IdResponsableInforme); }
			set { SetColumnValue(Columns.IdResponsableInforme, value); }
		}
		  
		[XmlAttribute("IdCentroSaludInforme")]
		[Bindable(true)]
		public int IdCentroSaludInforme 
		{
			get { return GetColumnValue<int>(Columns.IdCentroSaludInforme); }
			set { SetColumnValue(Columns.IdCentroSaludInforme, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
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
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
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
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this MamPiezaQuirurgica
		/// 
		/// </summary>
		public DalSic.SysEfector SysEfector
		{
			get { return DalSic.SysEfector.FetchByID(this.IdCentroSaludInforme); }
			set { SetColumnValue("idCentroSaludInforme", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this MamPiezaQuirurgica
		/// 
		/// </summary>
		public DalSic.SysProfesional SysProfesional
		{
			get { return DalSic.SysProfesional.FetchByID(this.IdResponsableInforme); }
			set { SetColumnValue("idResponsableInforme", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a MamDiagnoticoHistologico ActiveRecord object related to this MamPiezaQuirurgica
		/// 
		/// </summary>
		public DalSic.MamDiagnoticoHistologico MamDiagnoticoHistologico
		{
			get { return DalSic.MamDiagnoticoHistologico.FetchByID(this.IdDiagnosticoHistologico); }
			set { SetColumnValue("idDiagnosticoHistologico", value.IdDiagnosticoHistologico); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdPaciente,int varEdad,DateTime varFechaTomaMuestra,DateTime varFechaRecepcion,string varNumeroIngreso,string varMaterialIngresado,string varCentinelaDerecho,string varCentinelaIzquierdo,DateTime varFechaInforme,int varIdDiagnosticoHistologico,decimal varTamanioTumor,int varGangliosResecados,int varGangliosPositivos,int varReceptorHormonalRE,int varReceptorHormonalRP,int varCerbHerb,int varIdResponsableInforme,int varIdCentroSaludInforme,string varObservaciones,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamPiezaQuirurgica item = new MamPiezaQuirurgica();
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.FechaTomaMuestra = varFechaTomaMuestra;
			
			item.FechaRecepcion = varFechaRecepcion;
			
			item.NumeroIngreso = varNumeroIngreso;
			
			item.MaterialIngresado = varMaterialIngresado;
			
			item.CentinelaDerecho = varCentinelaDerecho;
			
			item.CentinelaIzquierdo = varCentinelaIzquierdo;
			
			item.FechaInforme = varFechaInforme;
			
			item.IdDiagnosticoHistologico = varIdDiagnosticoHistologico;
			
			item.TamanioTumor = varTamanioTumor;
			
			item.GangliosResecados = varGangliosResecados;
			
			item.GangliosPositivos = varGangliosPositivos;
			
			item.ReceptorHormonalRE = varReceptorHormonalRE;
			
			item.ReceptorHormonalRP = varReceptorHormonalRP;
			
			item.CerbHerb = varCerbHerb;
			
			item.IdResponsableInforme = varIdResponsableInforme;
			
			item.IdCentroSaludInforme = varIdCentroSaludInforme;
			
			item.Observaciones = varObservaciones;
			
			item.Activo = varActivo;
			
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
		public static void Update(int varIdPiezaQuirurgica,int varIdPaciente,int varEdad,DateTime varFechaTomaMuestra,DateTime varFechaRecepcion,string varNumeroIngreso,string varMaterialIngresado,string varCentinelaDerecho,string varCentinelaIzquierdo,DateTime varFechaInforme,int varIdDiagnosticoHistologico,decimal varTamanioTumor,int varGangliosResecados,int varGangliosPositivos,int varReceptorHormonalRE,int varReceptorHormonalRP,int varCerbHerb,int varIdResponsableInforme,int varIdCentroSaludInforme,string varObservaciones,bool varActivo,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			MamPiezaQuirurgica item = new MamPiezaQuirurgica();
			
				item.IdPiezaQuirurgica = varIdPiezaQuirurgica;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.FechaTomaMuestra = varFechaTomaMuestra;
			
				item.FechaRecepcion = varFechaRecepcion;
			
				item.NumeroIngreso = varNumeroIngreso;
			
				item.MaterialIngresado = varMaterialIngresado;
			
				item.CentinelaDerecho = varCentinelaDerecho;
			
				item.CentinelaIzquierdo = varCentinelaIzquierdo;
			
				item.FechaInforme = varFechaInforme;
			
				item.IdDiagnosticoHistologico = varIdDiagnosticoHistologico;
			
				item.TamanioTumor = varTamanioTumor;
			
				item.GangliosResecados = varGangliosResecados;
			
				item.GangliosPositivos = varGangliosPositivos;
			
				item.ReceptorHormonalRE = varReceptorHormonalRE;
			
				item.ReceptorHormonalRP = varReceptorHormonalRP;
			
				item.CerbHerb = varCerbHerb;
			
				item.IdResponsableInforme = varIdResponsableInforme;
			
				item.IdCentroSaludInforme = varIdCentroSaludInforme;
			
				item.Observaciones = varObservaciones;
			
				item.Activo = varActivo;
			
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
        
        
        public static TableSchema.TableColumn IdPiezaQuirurgicaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTomaMuestraColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecepcionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroIngresoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MaterialIngresadoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CentinelaDerechoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CentinelaIzquierdoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInformeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDiagnosticoHistologicoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TamanioTumorColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn GangliosResecadosColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn GangliosPositivosColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ReceptorHormonalREColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ReceptorHormonalRPColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CerbHerbColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdResponsableInformeColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCentroSaludInformeColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
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
			 public static string IdPiezaQuirurgica = @"idPiezaQuirurgica";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string FechaTomaMuestra = @"fechaTomaMuestra";
			 public static string FechaRecepcion = @"fechaRecepcion";
			 public static string NumeroIngreso = @"numeroIngreso";
			 public static string MaterialIngresado = @"materialIngresado";
			 public static string CentinelaDerecho = @"centinelaDerecho";
			 public static string CentinelaIzquierdo = @"centinelaIzquierdo";
			 public static string FechaInforme = @"fechaInforme";
			 public static string IdDiagnosticoHistologico = @"idDiagnosticoHistologico";
			 public static string TamanioTumor = @"tamanioTumor";
			 public static string GangliosResecados = @"gangliosResecados";
			 public static string GangliosPositivos = @"gangliosPositivos";
			 public static string ReceptorHormonalRE = @"receptorHormonalRE";
			 public static string ReceptorHormonalRP = @"receptorHormonalRP";
			 public static string CerbHerb = @"CerbHerb";
			 public static string IdResponsableInforme = @"idResponsableInforme";
			 public static string IdCentroSaludInforme = @"idCentroSaludInforme";
			 public static string Observaciones = @"observaciones";
			 public static string Activo = @"activo";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
