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
	/// Strongly-typed collection for the LabResultadoEncabezado class.
	/// </summary>
    [Serializable]
	public partial class LabResultadoEncabezadoCollection : ActiveList<LabResultadoEncabezado, LabResultadoEncabezadoCollection>
	{	   
		public LabResultadoEncabezadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabResultadoEncabezadoCollection</returns>
		public LabResultadoEncabezadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabResultadoEncabezado o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_ResultadoEncabezado table.
	/// </summary>
	[Serializable]
	public partial class LabResultadoEncabezado : ActiveRecord<LabResultadoEncabezado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabResultadoEncabezado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabResultadoEncabezado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabResultadoEncabezado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabResultadoEncabezado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_ResultadoEncabezado", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProtocolo = new TableSchema.TableColumn(schema);
				colvarIdProtocolo.ColumnName = "idProtocolo";
				colvarIdProtocolo.DataType = DbType.Int32;
				colvarIdProtocolo.MaxLength = 0;
				colvarIdProtocolo.AutoIncrement = false;
				colvarIdProtocolo.IsNullable = false;
				colvarIdProtocolo.IsPrimaryKey = true;
				colvarIdProtocolo.IsForeignKey = false;
				colvarIdProtocolo.IsReadOnly = false;
				colvarIdProtocolo.DefaultSetting = @"";
				colvarIdProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProtocolo);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = false;
				colvarIdEfector.IsPrimaryKey = true;
				colvarIdEfector.IsForeignKey = false;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				colvarIdEfector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.String;
				colvarApellido.MaxLength = 100;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = false;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = false;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				colvarEdad.DefaultSetting = @"";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarUnidadEdad = new TableSchema.TableColumn(schema);
				colvarUnidadEdad.ColumnName = "unidadEdad";
				colvarUnidadEdad.DataType = DbType.AnsiString;
				colvarUnidadEdad.MaxLength = 5;
				colvarUnidadEdad.AutoIncrement = false;
				colvarUnidadEdad.IsNullable = true;
				colvarUnidadEdad.IsPrimaryKey = false;
				colvarUnidadEdad.IsForeignKey = false;
				colvarUnidadEdad.IsReadOnly = false;
				colvarUnidadEdad.DefaultSetting = @"";
				colvarUnidadEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadEdad);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.AnsiString;
				colvarFechaNacimiento.MaxLength = 10;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.String;
				colvarSexo.MaxLength = 1;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = false;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
				colvarNumeroDocumento.ColumnName = "numeroDocumento";
				colvarNumeroDocumento.DataType = DbType.Int32;
				colvarNumeroDocumento.MaxLength = 0;
				colvarNumeroDocumento.AutoIncrement = false;
				colvarNumeroDocumento.IsNullable = false;
				colvarNumeroDocumento.IsPrimaryKey = false;
				colvarNumeroDocumento.IsForeignKey = false;
				colvarNumeroDocumento.IsReadOnly = false;
				colvarNumeroDocumento.DefaultSetting = @"";
				colvarNumeroDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDocumento);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.AnsiString;
				colvarFecha.MaxLength = 10;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarFecha1 = new TableSchema.TableColumn(schema);
				colvarFecha1.ColumnName = "fecha1";
				colvarFecha1.DataType = DbType.DateTime;
				colvarFecha1.MaxLength = 0;
				colvarFecha1.AutoIncrement = false;
				colvarFecha1.IsNullable = false;
				colvarFecha1.IsPrimaryKey = false;
				colvarFecha1.IsForeignKey = false;
				colvarFecha1.IsReadOnly = false;
				colvarFecha1.DefaultSetting = @"";
				colvarFecha1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha1);
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.String;
				colvarDomicilio.MaxLength = 261;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarHc = new TableSchema.TableColumn(schema);
				colvarHc.ColumnName = "HC";
				colvarHc.DataType = DbType.Int32;
				colvarHc.MaxLength = 0;
				colvarHc.AutoIncrement = false;
				colvarHc.IsNullable = false;
				colvarHc.IsPrimaryKey = false;
				colvarHc.IsForeignKey = false;
				colvarHc.IsReadOnly = false;
				colvarHc.DefaultSetting = @"";
				colvarHc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHc);
				
				TableSchema.TableColumn colvarPrioridad = new TableSchema.TableColumn(schema);
				colvarPrioridad.ColumnName = "prioridad";
				colvarPrioridad.DataType = DbType.String;
				colvarPrioridad.MaxLength = 50;
				colvarPrioridad.AutoIncrement = false;
				colvarPrioridad.IsNullable = false;
				colvarPrioridad.IsPrimaryKey = false;
				colvarPrioridad.IsForeignKey = false;
				colvarPrioridad.IsReadOnly = false;
				colvarPrioridad.DefaultSetting = @"";
				colvarPrioridad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrioridad);
				
				TableSchema.TableColumn colvarOrigen = new TableSchema.TableColumn(schema);
				colvarOrigen.ColumnName = "origen";
				colvarOrigen.DataType = DbType.String;
				colvarOrigen.MaxLength = 50;
				colvarOrigen.AutoIncrement = false;
				colvarOrigen.IsNullable = false;
				colvarOrigen.IsPrimaryKey = false;
				colvarOrigen.IsForeignKey = false;
				colvarOrigen.IsReadOnly = false;
				colvarOrigen.DefaultSetting = @"";
				colvarOrigen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrigen);
				
				TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
				colvarNumero.ColumnName = "numero";
				colvarNumero.DataType = DbType.AnsiString;
				colvarNumero.MaxLength = 50;
				colvarNumero.AutoIncrement = false;
				colvarNumero.IsNullable = true;
				colvarNumero.IsPrimaryKey = false;
				colvarNumero.IsForeignKey = false;
				colvarNumero.IsReadOnly = false;
				colvarNumero.DefaultSetting = @"";
				colvarNumero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumero);
				
				TableSchema.TableColumn colvarHiv = new TableSchema.TableColumn(schema);
				colvarHiv.ColumnName = "hiv";
				colvarHiv.DataType = DbType.Boolean;
				colvarHiv.MaxLength = 0;
				colvarHiv.AutoIncrement = false;
				colvarHiv.IsNullable = true;
				colvarHiv.IsPrimaryKey = false;
				colvarHiv.IsForeignKey = false;
				colvarHiv.IsReadOnly = false;
				colvarHiv.DefaultSetting = @"";
				colvarHiv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHiv);
				
				TableSchema.TableColumn colvarSolicitante = new TableSchema.TableColumn(schema);
				colvarSolicitante.ColumnName = "solicitante";
				colvarSolicitante.DataType = DbType.String;
				colvarSolicitante.MaxLength = 205;
				colvarSolicitante.AutoIncrement = false;
				colvarSolicitante.IsNullable = true;
				colvarSolicitante.IsPrimaryKey = false;
				colvarSolicitante.IsForeignKey = false;
				colvarSolicitante.IsReadOnly = false;
				colvarSolicitante.DefaultSetting = @"";
				colvarSolicitante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSolicitante);
				
				TableSchema.TableColumn colvarSector = new TableSchema.TableColumn(schema);
				colvarSector.ColumnName = "sector";
				colvarSector.DataType = DbType.AnsiString;
				colvarSector.MaxLength = 50;
				colvarSector.AutoIncrement = false;
				colvarSector.IsNullable = false;
				colvarSector.IsPrimaryKey = false;
				colvarSector.IsForeignKey = false;
				colvarSector.IsReadOnly = false;
				colvarSector.DefaultSetting = @"";
				colvarSector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSector);
				
				TableSchema.TableColumn colvarSala = new TableSchema.TableColumn(schema);
				colvarSala.ColumnName = "sala";
				colvarSala.DataType = DbType.AnsiString;
				colvarSala.MaxLength = 50;
				colvarSala.AutoIncrement = false;
				colvarSala.IsNullable = false;
				colvarSala.IsPrimaryKey = false;
				colvarSala.IsForeignKey = false;
				colvarSala.IsReadOnly = false;
				colvarSala.DefaultSetting = @"";
				colvarSala.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSala);
				
				TableSchema.TableColumn colvarCama = new TableSchema.TableColumn(schema);
				colvarCama.ColumnName = "cama";
				colvarCama.DataType = DbType.AnsiString;
				colvarCama.MaxLength = 50;
				colvarCama.AutoIncrement = false;
				colvarCama.IsNullable = false;
				colvarCama.IsPrimaryKey = false;
				colvarCama.IsForeignKey = false;
				colvarCama.IsReadOnly = false;
				colvarCama.DefaultSetting = @"";
				colvarCama.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCama);
				
				TableSchema.TableColumn colvarEmbarazo = new TableSchema.TableColumn(schema);
				colvarEmbarazo.ColumnName = "embarazo";
				colvarEmbarazo.DataType = DbType.AnsiString;
				colvarEmbarazo.MaxLength = 1;
				colvarEmbarazo.AutoIncrement = false;
				colvarEmbarazo.IsNullable = false;
				colvarEmbarazo.IsPrimaryKey = false;
				colvarEmbarazo.IsForeignKey = false;
				colvarEmbarazo.IsReadOnly = false;
				colvarEmbarazo.DefaultSetting = @"";
				colvarEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmbarazo);
				
				TableSchema.TableColumn colvarEfectorSolicitante = new TableSchema.TableColumn(schema);
				colvarEfectorSolicitante.ColumnName = "EfectorSolicitante";
				colvarEfectorSolicitante.DataType = DbType.String;
				colvarEfectorSolicitante.MaxLength = 100;
				colvarEfectorSolicitante.AutoIncrement = false;
				colvarEfectorSolicitante.IsNullable = false;
				colvarEfectorSolicitante.IsPrimaryKey = false;
				colvarEfectorSolicitante.IsForeignKey = false;
				colvarEfectorSolicitante.IsReadOnly = false;
				colvarEfectorSolicitante.DefaultSetting = @"";
				colvarEfectorSolicitante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEfectorSolicitante);
				
				TableSchema.TableColumn colvarIdSolicitudScreening = new TableSchema.TableColumn(schema);
				colvarIdSolicitudScreening.ColumnName = "idSolicitudScreening";
				colvarIdSolicitudScreening.DataType = DbType.Int32;
				colvarIdSolicitudScreening.MaxLength = 0;
				colvarIdSolicitudScreening.AutoIncrement = false;
				colvarIdSolicitudScreening.IsNullable = true;
				colvarIdSolicitudScreening.IsPrimaryKey = false;
				colvarIdSolicitudScreening.IsForeignKey = false;
				colvarIdSolicitudScreening.IsReadOnly = false;
				colvarIdSolicitudScreening.DefaultSetting = @"";
				colvarIdSolicitudScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSolicitudScreening);
				
				TableSchema.TableColumn colvarFechaRecibeScreening = new TableSchema.TableColumn(schema);
				colvarFechaRecibeScreening.ColumnName = "fechaRecibeScreening";
				colvarFechaRecibeScreening.DataType = DbType.DateTime;
				colvarFechaRecibeScreening.MaxLength = 0;
				colvarFechaRecibeScreening.AutoIncrement = false;
				colvarFechaRecibeScreening.IsNullable = true;
				colvarFechaRecibeScreening.IsPrimaryKey = false;
				colvarFechaRecibeScreening.IsForeignKey = false;
				colvarFechaRecibeScreening.IsReadOnly = false;
				colvarFechaRecibeScreening.DefaultSetting = @"";
				colvarFechaRecibeScreening.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecibeScreening);
				
				TableSchema.TableColumn colvarObservacionesResultados = new TableSchema.TableColumn(schema);
				colvarObservacionesResultados.ColumnName = "observacionesResultados";
				colvarObservacionesResultados.DataType = DbType.String;
				colvarObservacionesResultados.MaxLength = 4000;
				colvarObservacionesResultados.AutoIncrement = false;
				colvarObservacionesResultados.IsNullable = true;
				colvarObservacionesResultados.IsPrimaryKey = false;
				colvarObservacionesResultados.IsForeignKey = false;
				colvarObservacionesResultados.IsReadOnly = false;
				colvarObservacionesResultados.DefaultSetting = @"";
				colvarObservacionesResultados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservacionesResultados);
				
				TableSchema.TableColumn colvarTipoMuestra = new TableSchema.TableColumn(schema);
				colvarTipoMuestra.ColumnName = "tipoMuestra";
				colvarTipoMuestra.DataType = DbType.String;
				colvarTipoMuestra.MaxLength = 500;
				colvarTipoMuestra.AutoIncrement = false;
				colvarTipoMuestra.IsNullable = true;
				colvarTipoMuestra.IsPrimaryKey = false;
				colvarTipoMuestra.IsForeignKey = false;
				colvarTipoMuestra.IsReadOnly = false;
				colvarTipoMuestra.DefaultSetting = @"";
				colvarTipoMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoMuestra);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_ResultadoEncabezado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProtocolo")]
		[Bindable(true)]
		public int IdProtocolo 
		{
			get { return GetColumnValue<int>(Columns.IdProtocolo); }
			set { SetColumnValue(Columns.IdProtocolo, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int IdEfector 
		{
			get { return GetColumnValue<int>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
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
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int Edad 
		{
			get { return GetColumnValue<int>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("UnidadEdad")]
		[Bindable(true)]
		public string UnidadEdad 
		{
			get { return GetColumnValue<string>(Columns.UnidadEdad); }
			set { SetColumnValue(Columns.UnidadEdad, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public string FechaNacimiento 
		{
			get { return GetColumnValue<string>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("NumeroDocumento")]
		[Bindable(true)]
		public int NumeroDocumento 
		{
			get { return GetColumnValue<int>(Columns.NumeroDocumento); }
			set { SetColumnValue(Columns.NumeroDocumento, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public string Fecha 
		{
			get { return GetColumnValue<string>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Fecha1")]
		[Bindable(true)]
		public DateTime Fecha1 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha1); }
			set { SetColumnValue(Columns.Fecha1, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Hc")]
		[Bindable(true)]
		public int Hc 
		{
			get { return GetColumnValue<int>(Columns.Hc); }
			set { SetColumnValue(Columns.Hc, value); }
		}
		  
		[XmlAttribute("Prioridad")]
		[Bindable(true)]
		public string Prioridad 
		{
			get { return GetColumnValue<string>(Columns.Prioridad); }
			set { SetColumnValue(Columns.Prioridad, value); }
		}
		  
		[XmlAttribute("Origen")]
		[Bindable(true)]
		public string Origen 
		{
			get { return GetColumnValue<string>(Columns.Origen); }
			set { SetColumnValue(Columns.Origen, value); }
		}
		  
		[XmlAttribute("Numero")]
		[Bindable(true)]
		public string Numero 
		{
			get { return GetColumnValue<string>(Columns.Numero); }
			set { SetColumnValue(Columns.Numero, value); }
		}
		  
		[XmlAttribute("Hiv")]
		[Bindable(true)]
		public bool? Hiv 
		{
			get { return GetColumnValue<bool?>(Columns.Hiv); }
			set { SetColumnValue(Columns.Hiv, value); }
		}
		  
		[XmlAttribute("Solicitante")]
		[Bindable(true)]
		public string Solicitante 
		{
			get { return GetColumnValue<string>(Columns.Solicitante); }
			set { SetColumnValue(Columns.Solicitante, value); }
		}
		  
		[XmlAttribute("Sector")]
		[Bindable(true)]
		public string Sector 
		{
			get { return GetColumnValue<string>(Columns.Sector); }
			set { SetColumnValue(Columns.Sector, value); }
		}
		  
		[XmlAttribute("Sala")]
		[Bindable(true)]
		public string Sala 
		{
			get { return GetColumnValue<string>(Columns.Sala); }
			set { SetColumnValue(Columns.Sala, value); }
		}
		  
		[XmlAttribute("Cama")]
		[Bindable(true)]
		public string Cama 
		{
			get { return GetColumnValue<string>(Columns.Cama); }
			set { SetColumnValue(Columns.Cama, value); }
		}
		  
		[XmlAttribute("Embarazo")]
		[Bindable(true)]
		public string Embarazo 
		{
			get { return GetColumnValue<string>(Columns.Embarazo); }
			set { SetColumnValue(Columns.Embarazo, value); }
		}
		  
		[XmlAttribute("EfectorSolicitante")]
		[Bindable(true)]
		public string EfectorSolicitante 
		{
			get { return GetColumnValue<string>(Columns.EfectorSolicitante); }
			set { SetColumnValue(Columns.EfectorSolicitante, value); }
		}
		  
		[XmlAttribute("IdSolicitudScreening")]
		[Bindable(true)]
		public int? IdSolicitudScreening 
		{
			get { return GetColumnValue<int?>(Columns.IdSolicitudScreening); }
			set { SetColumnValue(Columns.IdSolicitudScreening, value); }
		}
		  
		[XmlAttribute("FechaRecibeScreening")]
		[Bindable(true)]
		public DateTime? FechaRecibeScreening 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRecibeScreening); }
			set { SetColumnValue(Columns.FechaRecibeScreening, value); }
		}
		  
		[XmlAttribute("ObservacionesResultados")]
		[Bindable(true)]
		public string ObservacionesResultados 
		{
			get { return GetColumnValue<string>(Columns.ObservacionesResultados); }
			set { SetColumnValue(Columns.ObservacionesResultados, value); }
		}
		  
		[XmlAttribute("TipoMuestra")]
		[Bindable(true)]
		public string TipoMuestra 
		{
			get { return GetColumnValue<string>(Columns.TipoMuestra); }
			set { SetColumnValue(Columns.TipoMuestra, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.FacOrdenLaboratorioCollection colFacOrdenLaboratorioRecords;
		public DalSic.FacOrdenLaboratorioCollection FacOrdenLaboratorioRecords
		{
			get
			{
				if(colFacOrdenLaboratorioRecords == null)
				{
					colFacOrdenLaboratorioRecords = new DalSic.FacOrdenLaboratorioCollection().Where(FacOrdenLaboratorio.Columns.IdEfector, IdProtocolo).Load();
					colFacOrdenLaboratorioRecords.ListChanged += new ListChangedEventHandler(colFacOrdenLaboratorioRecords_ListChanged);
				}
				return colFacOrdenLaboratorioRecords;			
			}
			set 
			{ 
					colFacOrdenLaboratorioRecords = value; 
					colFacOrdenLaboratorioRecords.ListChanged += new ListChangedEventHandler(colFacOrdenLaboratorioRecords_ListChanged);
			}
		}
		
		void colFacOrdenLaboratorioRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colFacOrdenLaboratorioRecords[e.NewIndex].IdEfector = IdProtocolo;
		    }
		}
				
		private DalSic.FacOrdenLaboratorioCollection colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado;
		public DalSic.FacOrdenLaboratorioCollection FacOrdenLaboratorioRecordsFromLabResultadoEncabezado
		{
			get
			{
				if(colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado == null)
				{
					colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado = new DalSic.FacOrdenLaboratorioCollection().Where(FacOrdenLaboratorio.Columns.IdProtocolo, IdProtocolo).Load();
					colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado.ListChanged += new ListChangedEventHandler(colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado_ListChanged);
				}
				return colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado;			
			}
			set 
			{ 
					colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado = value; 
					colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado.ListChanged += new ListChangedEventHandler(colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado_ListChanged);
			}
		}
		
		void colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado[e.NewIndex].IdProtocolo = IdProtocolo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdProtocolo,int varIdEfector,string varApellido,string varNombre,int varEdad,string varUnidadEdad,string varFechaNacimiento,string varSexo,int varNumeroDocumento,string varFecha,DateTime varFecha1,string varDomicilio,int varHc,string varPrioridad,string varOrigen,string varNumero,bool? varHiv,string varSolicitante,string varSector,string varSala,string varCama,string varEmbarazo,string varEfectorSolicitante,int? varIdSolicitudScreening,DateTime? varFechaRecibeScreening,string varObservacionesResultados,string varTipoMuestra)
		{
			LabResultadoEncabezado item = new LabResultadoEncabezado();
			
			item.IdProtocolo = varIdProtocolo;
			
			item.IdEfector = varIdEfector;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.Edad = varEdad;
			
			item.UnidadEdad = varUnidadEdad;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.Sexo = varSexo;
			
			item.NumeroDocumento = varNumeroDocumento;
			
			item.Fecha = varFecha;
			
			item.Fecha1 = varFecha1;
			
			item.Domicilio = varDomicilio;
			
			item.Hc = varHc;
			
			item.Prioridad = varPrioridad;
			
			item.Origen = varOrigen;
			
			item.Numero = varNumero;
			
			item.Hiv = varHiv;
			
			item.Solicitante = varSolicitante;
			
			item.Sector = varSector;
			
			item.Sala = varSala;
			
			item.Cama = varCama;
			
			item.Embarazo = varEmbarazo;
			
			item.EfectorSolicitante = varEfectorSolicitante;
			
			item.IdSolicitudScreening = varIdSolicitudScreening;
			
			item.FechaRecibeScreening = varFechaRecibeScreening;
			
			item.ObservacionesResultados = varObservacionesResultados;
			
			item.TipoMuestra = varTipoMuestra;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdProtocolo,int varIdEfector,string varApellido,string varNombre,int varEdad,string varUnidadEdad,string varFechaNacimiento,string varSexo,int varNumeroDocumento,string varFecha,DateTime varFecha1,string varDomicilio,int varHc,string varPrioridad,string varOrigen,string varNumero,bool? varHiv,string varSolicitante,string varSector,string varSala,string varCama,string varEmbarazo,string varEfectorSolicitante,int? varIdSolicitudScreening,DateTime? varFechaRecibeScreening,string varObservacionesResultados,string varTipoMuestra)
		{
			LabResultadoEncabezado item = new LabResultadoEncabezado();
			
				item.IdProtocolo = varIdProtocolo;
			
				item.IdEfector = varIdEfector;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.Edad = varEdad;
			
				item.UnidadEdad = varUnidadEdad;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.Sexo = varSexo;
			
				item.NumeroDocumento = varNumeroDocumento;
			
				item.Fecha = varFecha;
			
				item.Fecha1 = varFecha1;
			
				item.Domicilio = varDomicilio;
			
				item.Hc = varHc;
			
				item.Prioridad = varPrioridad;
			
				item.Origen = varOrigen;
			
				item.Numero = varNumero;
			
				item.Hiv = varHiv;
			
				item.Solicitante = varSolicitante;
			
				item.Sector = varSector;
			
				item.Sala = varSala;
			
				item.Cama = varCama;
			
				item.Embarazo = varEmbarazo;
			
				item.EfectorSolicitante = varEfectorSolicitante;
			
				item.IdSolicitudScreening = varIdSolicitudScreening;
			
				item.FechaRecibeScreening = varFechaRecibeScreening;
			
				item.ObservacionesResultados = varObservacionesResultados;
			
				item.TipoMuestra = varTipoMuestra;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProtocoloColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadEdadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocumentoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn Fecha1Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn HcColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PrioridadColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn OrigenColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn HivColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn SolicitanteColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn SectorColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn SalaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CamaColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn EmbarazoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn EfectorSolicitanteColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSolicitudScreeningColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecibeScreeningColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesResultadosColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoMuestraColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProtocolo = @"idProtocolo";
			 public static string IdEfector = @"idEfector";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string Edad = @"edad";
			 public static string UnidadEdad = @"unidadEdad";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string Sexo = @"sexo";
			 public static string NumeroDocumento = @"numeroDocumento";
			 public static string Fecha = @"fecha";
			 public static string Fecha1 = @"fecha1";
			 public static string Domicilio = @"domicilio";
			 public static string Hc = @"HC";
			 public static string Prioridad = @"prioridad";
			 public static string Origen = @"origen";
			 public static string Numero = @"numero";
			 public static string Hiv = @"hiv";
			 public static string Solicitante = @"solicitante";
			 public static string Sector = @"sector";
			 public static string Sala = @"sala";
			 public static string Cama = @"cama";
			 public static string Embarazo = @"embarazo";
			 public static string EfectorSolicitante = @"EfectorSolicitante";
			 public static string IdSolicitudScreening = @"idSolicitudScreening";
			 public static string FechaRecibeScreening = @"fechaRecibeScreening";
			 public static string ObservacionesResultados = @"observacionesResultados";
			 public static string TipoMuestra = @"tipoMuestra";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colFacOrdenLaboratorioRecords != null)
                {
                    foreach (DalSic.FacOrdenLaboratorio item in colFacOrdenLaboratorioRecords)
                    {
                        if (item.IdEfector != IdProtocolo)
                        {
                            item.IdEfector = IdProtocolo;
                        }
                    }
               }
		
                if (colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado != null)
                {
                    foreach (DalSic.FacOrdenLaboratorio item in colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado)
                    {
                        if (item.IdProtocolo != IdProtocolo)
                        {
                            item.IdProtocolo = IdProtocolo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colFacOrdenLaboratorioRecords != null)
                {
                    colFacOrdenLaboratorioRecords.SaveAll();
               }
		
                if (colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado != null)
                {
                    colFacOrdenLaboratorioRecordsFromLabResultadoEncabezado.SaveAll();
               }
		}
        #endregion
	}
}
