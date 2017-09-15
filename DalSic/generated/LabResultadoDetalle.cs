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
	/// Strongly-typed collection for the LabResultadoDetalle class.
	/// </summary>
    [Serializable]
	public partial class LabResultadoDetalleCollection : ActiveList<LabResultadoDetalle, LabResultadoDetalleCollection>
	{	   
		public LabResultadoDetalleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabResultadoDetalleCollection</returns>
		public LabResultadoDetalleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabResultadoDetalle o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_ResultadoDetalle table.
	/// </summary>
	[Serializable]
	public partial class LabResultadoDetalle : ActiveRecord<LabResultadoDetalle>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabResultadoDetalle()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabResultadoDetalle(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabResultadoDetalle(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabResultadoDetalle(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_ResultadoDetalle", TableType.Table, DataService.GetInstance("sicProvider"));
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
				
				TableSchema.TableColumn colvarIdDetalleProtocolo = new TableSchema.TableColumn(schema);
				colvarIdDetalleProtocolo.ColumnName = "idDetalleProtocolo";
				colvarIdDetalleProtocolo.DataType = DbType.Int32;
				colvarIdDetalleProtocolo.MaxLength = 0;
				colvarIdDetalleProtocolo.AutoIncrement = false;
				colvarIdDetalleProtocolo.IsNullable = false;
				colvarIdDetalleProtocolo.IsPrimaryKey = true;
				colvarIdDetalleProtocolo.IsForeignKey = false;
				colvarIdDetalleProtocolo.IsReadOnly = false;
				colvarIdDetalleProtocolo.DefaultSetting = @"";
				colvarIdDetalleProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDetalleProtocolo);
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "codigo";
				colvarCodigo.DataType = DbType.String;
				colvarCodigo.MaxLength = 50;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = false;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarOrdenArea = new TableSchema.TableColumn(schema);
				colvarOrdenArea.ColumnName = "ordenArea";
				colvarOrdenArea.DataType = DbType.Int32;
				colvarOrdenArea.MaxLength = 0;
				colvarOrdenArea.AutoIncrement = false;
				colvarOrdenArea.IsNullable = false;
				colvarOrdenArea.IsPrimaryKey = false;
				colvarOrdenArea.IsForeignKey = false;
				colvarOrdenArea.IsReadOnly = false;
				colvarOrdenArea.DefaultSetting = @"";
				colvarOrdenArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdenArea);
				
				TableSchema.TableColumn colvarOrden = new TableSchema.TableColumn(schema);
				colvarOrden.ColumnName = "orden";
				colvarOrden.DataType = DbType.Int32;
				colvarOrden.MaxLength = 0;
				colvarOrden.AutoIncrement = false;
				colvarOrden.IsNullable = false;
				colvarOrden.IsPrimaryKey = false;
				colvarOrden.IsForeignKey = false;
				colvarOrden.IsReadOnly = false;
				colvarOrden.DefaultSetting = @"";
				colvarOrden.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrden);
				
				TableSchema.TableColumn colvarArea = new TableSchema.TableColumn(schema);
				colvarArea.ColumnName = "area";
				colvarArea.DataType = DbType.String;
				colvarArea.MaxLength = 50;
				colvarArea.AutoIncrement = false;
				colvarArea.IsNullable = false;
				colvarArea.IsPrimaryKey = false;
				colvarArea.IsForeignKey = false;
				colvarArea.IsReadOnly = false;
				colvarArea.DefaultSetting = @"";
				colvarArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArea);
				
				TableSchema.TableColumn colvarGrupo = new TableSchema.TableColumn(schema);
				colvarGrupo.ColumnName = "grupo";
				colvarGrupo.DataType = DbType.String;
				colvarGrupo.MaxLength = 500;
				colvarGrupo.AutoIncrement = false;
				colvarGrupo.IsNullable = false;
				colvarGrupo.IsPrimaryKey = false;
				colvarGrupo.IsForeignKey = false;
				colvarGrupo.IsReadOnly = false;
				colvarGrupo.DefaultSetting = @"";
				colvarGrupo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrupo);
				
				TableSchema.TableColumn colvarItem = new TableSchema.TableColumn(schema);
				colvarItem.ColumnName = "item";
				colvarItem.DataType = DbType.String;
				colvarItem.MaxLength = 500;
				colvarItem.AutoIncrement = false;
				colvarItem.IsNullable = false;
				colvarItem.IsPrimaryKey = false;
				colvarItem.IsForeignKey = false;
				colvarItem.IsReadOnly = false;
				colvarItem.DefaultSetting = @"";
				colvarItem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItem);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.String;
				colvarObservaciones.MaxLength = 500;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = false;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarEsTitulo = new TableSchema.TableColumn(schema);
				colvarEsTitulo.ColumnName = "esTitulo";
				colvarEsTitulo.DataType = DbType.AnsiString;
				colvarEsTitulo.MaxLength = 2;
				colvarEsTitulo.AutoIncrement = false;
				colvarEsTitulo.IsNullable = false;
				colvarEsTitulo.IsPrimaryKey = false;
				colvarEsTitulo.IsForeignKey = false;
				colvarEsTitulo.IsReadOnly = false;
				colvarEsTitulo.DefaultSetting = @"";
				colvarEsTitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEsTitulo);
				
				TableSchema.TableColumn colvarDerivado = new TableSchema.TableColumn(schema);
				colvarDerivado.ColumnName = "derivado";
				colvarDerivado.DataType = DbType.String;
				colvarDerivado.MaxLength = 100;
				colvarDerivado.AutoIncrement = false;
				colvarDerivado.IsNullable = false;
				colvarDerivado.IsPrimaryKey = false;
				colvarDerivado.IsForeignKey = false;
				colvarDerivado.IsReadOnly = false;
				colvarDerivado.DefaultSetting = @"";
				colvarDerivado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDerivado);
				
				TableSchema.TableColumn colvarUnidad = new TableSchema.TableColumn(schema);
				colvarUnidad.ColumnName = "unidad";
				colvarUnidad.DataType = DbType.String;
				colvarUnidad.MaxLength = 100;
				colvarUnidad.AutoIncrement = false;
				colvarUnidad.IsNullable = false;
				colvarUnidad.IsPrimaryKey = false;
				colvarUnidad.IsForeignKey = false;
				colvarUnidad.IsReadOnly = false;
				colvarUnidad.DefaultSetting = @"";
				colvarUnidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidad);
				
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
				
				TableSchema.TableColumn colvarMetodo = new TableSchema.TableColumn(schema);
				colvarMetodo.ColumnName = "metodo";
				colvarMetodo.DataType = DbType.String;
				colvarMetodo.MaxLength = 100;
				colvarMetodo.AutoIncrement = false;
				colvarMetodo.IsNullable = false;
				colvarMetodo.IsPrimaryKey = false;
				colvarMetodo.IsForeignKey = false;
				colvarMetodo.IsReadOnly = false;
				colvarMetodo.DefaultSetting = @"";
				colvarMetodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMetodo);
				
				TableSchema.TableColumn colvarValorReferencia = new TableSchema.TableColumn(schema);
				colvarValorReferencia.ColumnName = "valorReferencia";
				colvarValorReferencia.DataType = DbType.String;
				colvarValorReferencia.MaxLength = 500;
				colvarValorReferencia.AutoIncrement = false;
				colvarValorReferencia.IsNullable = true;
				colvarValorReferencia.IsPrimaryKey = false;
				colvarValorReferencia.IsForeignKey = false;
				colvarValorReferencia.IsReadOnly = false;
				colvarValorReferencia.DefaultSetting = @"";
				colvarValorReferencia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorReferencia);
				
				TableSchema.TableColumn colvarOrden1 = new TableSchema.TableColumn(schema);
				colvarOrden1.ColumnName = "orden1";
				colvarOrden1.DataType = DbType.Int32;
				colvarOrden1.MaxLength = 0;
				colvarOrden1.AutoIncrement = false;
				colvarOrden1.IsNullable = false;
				colvarOrden1.IsPrimaryKey = false;
				colvarOrden1.IsForeignKey = false;
				colvarOrden1.IsReadOnly = false;
				colvarOrden1.DefaultSetting = @"";
				colvarOrden1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrden1);
				
				TableSchema.TableColumn colvarMuestra = new TableSchema.TableColumn(schema);
				colvarMuestra.ColumnName = "muestra";
				colvarMuestra.DataType = DbType.String;
				colvarMuestra.MaxLength = 2;
				colvarMuestra.AutoIncrement = false;
				colvarMuestra.IsNullable = false;
				colvarMuestra.IsPrimaryKey = false;
				colvarMuestra.IsForeignKey = false;
				colvarMuestra.IsReadOnly = false;
				colvarMuestra.DefaultSetting = @"";
				colvarMuestra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMuestra);
				
				TableSchema.TableColumn colvarConresultado = new TableSchema.TableColumn(schema);
				colvarConresultado.ColumnName = "conresultado";
				colvarConresultado.DataType = DbType.Int32;
				colvarConresultado.MaxLength = 0;
				colvarConresultado.AutoIncrement = false;
				colvarConresultado.IsNullable = false;
				colvarConresultado.IsPrimaryKey = false;
				colvarConresultado.IsForeignKey = false;
				colvarConresultado.IsReadOnly = false;
				colvarConresultado.DefaultSetting = @"";
				colvarConresultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConresultado);
				
				TableSchema.TableColumn colvarResultado = new TableSchema.TableColumn(schema);
				colvarResultado.ColumnName = "resultado";
				colvarResultado.DataType = DbType.String;
				colvarResultado.MaxLength = 4000;
				colvarResultado.AutoIncrement = false;
				colvarResultado.IsNullable = true;
				colvarResultado.IsPrimaryKey = false;
				colvarResultado.IsForeignKey = false;
				colvarResultado.IsReadOnly = false;
				colvarResultado.DefaultSetting = @"";
				colvarResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResultado);
				
				TableSchema.TableColumn colvarCodigo2 = new TableSchema.TableColumn(schema);
				colvarCodigo2.ColumnName = "codigo2";
				colvarCodigo2.DataType = DbType.String;
				colvarCodigo2.MaxLength = 50;
				colvarCodigo2.AutoIncrement = false;
				colvarCodigo2.IsNullable = false;
				colvarCodigo2.IsPrimaryKey = false;
				colvarCodigo2.IsForeignKey = false;
				colvarCodigo2.IsReadOnly = false;
				colvarCodigo2.DefaultSetting = @"";
				colvarCodigo2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo2);
				
				TableSchema.TableColumn colvarCodigoNomenclador = new TableSchema.TableColumn(schema);
				colvarCodigoNomenclador.ColumnName = "codigoNomenclador";
				colvarCodigoNomenclador.DataType = DbType.AnsiString;
				colvarCodigoNomenclador.MaxLength = 50;
				colvarCodigoNomenclador.AutoIncrement = false;
				colvarCodigoNomenclador.IsNullable = true;
				colvarCodigoNomenclador.IsPrimaryKey = false;
				colvarCodigoNomenclador.IsForeignKey = false;
				colvarCodigoNomenclador.IsReadOnly = false;
				colvarCodigoNomenclador.DefaultSetting = @"";
				colvarCodigoNomenclador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoNomenclador);
				
				TableSchema.TableColumn colvarProfesionalVal = new TableSchema.TableColumn(schema);
				colvarProfesionalVal.ColumnName = "profesional_val";
				colvarProfesionalVal.DataType = DbType.String;
				colvarProfesionalVal.MaxLength = 500;
				colvarProfesionalVal.AutoIncrement = false;
				colvarProfesionalVal.IsNullable = false;
				colvarProfesionalVal.IsPrimaryKey = false;
				colvarProfesionalVal.IsForeignKey = false;
				colvarProfesionalVal.IsReadOnly = false;
				
						colvarProfesionalVal.DefaultSetting = @"('')";
				colvarProfesionalVal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProfesionalVal);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("LAB_ResultadoDetalle",schema);
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
		  
		[XmlAttribute("IdDetalleProtocolo")]
		[Bindable(true)]
		public int IdDetalleProtocolo 
		{
			get { return GetColumnValue<int>(Columns.IdDetalleProtocolo); }
			set { SetColumnValue(Columns.IdDetalleProtocolo, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public string Codigo 
		{
			get { return GetColumnValue<string>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("OrdenArea")]
		[Bindable(true)]
		public int OrdenArea 
		{
			get { return GetColumnValue<int>(Columns.OrdenArea); }
			set { SetColumnValue(Columns.OrdenArea, value); }
		}
		  
		[XmlAttribute("Orden")]
		[Bindable(true)]
		public int Orden 
		{
			get { return GetColumnValue<int>(Columns.Orden); }
			set { SetColumnValue(Columns.Orden, value); }
		}
		  
		[XmlAttribute("Area")]
		[Bindable(true)]
		public string Area 
		{
			get { return GetColumnValue<string>(Columns.Area); }
			set { SetColumnValue(Columns.Area, value); }
		}
		  
		[XmlAttribute("Grupo")]
		[Bindable(true)]
		public string Grupo 
		{
			get { return GetColumnValue<string>(Columns.Grupo); }
			set { SetColumnValue(Columns.Grupo, value); }
		}
		  
		[XmlAttribute("Item")]
		[Bindable(true)]
		public string Item 
		{
			get { return GetColumnValue<string>(Columns.Item); }
			set { SetColumnValue(Columns.Item, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("EsTitulo")]
		[Bindable(true)]
		public string EsTitulo 
		{
			get { return GetColumnValue<string>(Columns.EsTitulo); }
			set { SetColumnValue(Columns.EsTitulo, value); }
		}
		  
		[XmlAttribute("Derivado")]
		[Bindable(true)]
		public string Derivado 
		{
			get { return GetColumnValue<string>(Columns.Derivado); }
			set { SetColumnValue(Columns.Derivado, value); }
		}
		  
		[XmlAttribute("Unidad")]
		[Bindable(true)]
		public string Unidad 
		{
			get { return GetColumnValue<string>(Columns.Unidad); }
			set { SetColumnValue(Columns.Unidad, value); }
		}
		  
		[XmlAttribute("Hiv")]
		[Bindable(true)]
		public bool? Hiv 
		{
			get { return GetColumnValue<bool?>(Columns.Hiv); }
			set { SetColumnValue(Columns.Hiv, value); }
		}
		  
		[XmlAttribute("Metodo")]
		[Bindable(true)]
		public string Metodo 
		{
			get { return GetColumnValue<string>(Columns.Metodo); }
			set { SetColumnValue(Columns.Metodo, value); }
		}
		  
		[XmlAttribute("ValorReferencia")]
		[Bindable(true)]
		public string ValorReferencia 
		{
			get { return GetColumnValue<string>(Columns.ValorReferencia); }
			set { SetColumnValue(Columns.ValorReferencia, value); }
		}
		  
		[XmlAttribute("Orden1")]
		[Bindable(true)]
		public int Orden1 
		{
			get { return GetColumnValue<int>(Columns.Orden1); }
			set { SetColumnValue(Columns.Orden1, value); }
		}
		  
		[XmlAttribute("Muestra")]
		[Bindable(true)]
		public string Muestra 
		{
			get { return GetColumnValue<string>(Columns.Muestra); }
			set { SetColumnValue(Columns.Muestra, value); }
		}
		  
		[XmlAttribute("Conresultado")]
		[Bindable(true)]
		public int Conresultado 
		{
			get { return GetColumnValue<int>(Columns.Conresultado); }
			set { SetColumnValue(Columns.Conresultado, value); }
		}
		  
		[XmlAttribute("Resultado")]
		[Bindable(true)]
		public string Resultado 
		{
			get { return GetColumnValue<string>(Columns.Resultado); }
			set { SetColumnValue(Columns.Resultado, value); }
		}
		  
		[XmlAttribute("Codigo2")]
		[Bindable(true)]
		public string Codigo2 
		{
			get { return GetColumnValue<string>(Columns.Codigo2); }
			set { SetColumnValue(Columns.Codigo2, value); }
		}
		  
		[XmlAttribute("CodigoNomenclador")]
		[Bindable(true)]
		public string CodigoNomenclador 
		{
			get { return GetColumnValue<string>(Columns.CodigoNomenclador); }
			set { SetColumnValue(Columns.CodigoNomenclador, value); }
		}
		  
		[XmlAttribute("ProfesionalVal")]
		[Bindable(true)]
		public string ProfesionalVal 
		{
			get { return GetColumnValue<string>(Columns.ProfesionalVal); }
			set { SetColumnValue(Columns.ProfesionalVal, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdProtocolo,int varIdEfector,int varIdDetalleProtocolo,string varCodigo,int varOrdenArea,int varOrden,string varArea,string varGrupo,string varItem,string varObservaciones,string varEsTitulo,string varDerivado,string varUnidad,bool? varHiv,string varMetodo,string varValorReferencia,int varOrden1,string varMuestra,int varConresultado,string varResultado,string varCodigo2,string varCodigoNomenclador,string varProfesionalVal)
		{
			LabResultadoDetalle item = new LabResultadoDetalle();
			
			item.IdProtocolo = varIdProtocolo;
			
			item.IdEfector = varIdEfector;
			
			item.IdDetalleProtocolo = varIdDetalleProtocolo;
			
			item.Codigo = varCodigo;
			
			item.OrdenArea = varOrdenArea;
			
			item.Orden = varOrden;
			
			item.Area = varArea;
			
			item.Grupo = varGrupo;
			
			item.Item = varItem;
			
			item.Observaciones = varObservaciones;
			
			item.EsTitulo = varEsTitulo;
			
			item.Derivado = varDerivado;
			
			item.Unidad = varUnidad;
			
			item.Hiv = varHiv;
			
			item.Metodo = varMetodo;
			
			item.ValorReferencia = varValorReferencia;
			
			item.Orden1 = varOrden1;
			
			item.Muestra = varMuestra;
			
			item.Conresultado = varConresultado;
			
			item.Resultado = varResultado;
			
			item.Codigo2 = varCodigo2;
			
			item.CodigoNomenclador = varCodigoNomenclador;
			
			item.ProfesionalVal = varProfesionalVal;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdProtocolo,int varIdEfector,int varIdDetalleProtocolo,string varCodigo,int varOrdenArea,int varOrden,string varArea,string varGrupo,string varItem,string varObservaciones,string varEsTitulo,string varDerivado,string varUnidad,bool? varHiv,string varMetodo,string varValorReferencia,int varOrden1,string varMuestra,int varConresultado,string varResultado,string varCodigo2,string varCodigoNomenclador,string varProfesionalVal)
		{
			LabResultadoDetalle item = new LabResultadoDetalle();
			
				item.IdProtocolo = varIdProtocolo;
			
				item.IdEfector = varIdEfector;
			
				item.IdDetalleProtocolo = varIdDetalleProtocolo;
			
				item.Codigo = varCodigo;
			
				item.OrdenArea = varOrdenArea;
			
				item.Orden = varOrden;
			
				item.Area = varArea;
			
				item.Grupo = varGrupo;
			
				item.Item = varItem;
			
				item.Observaciones = varObservaciones;
			
				item.EsTitulo = varEsTitulo;
			
				item.Derivado = varDerivado;
			
				item.Unidad = varUnidad;
			
				item.Hiv = varHiv;
			
				item.Metodo = varMetodo;
			
				item.ValorReferencia = varValorReferencia;
			
				item.Orden1 = varOrden1;
			
				item.Muestra = varMuestra;
			
				item.Conresultado = varConresultado;
			
				item.Resultado = varResultado;
			
				item.Codigo2 = varCodigo2;
			
				item.CodigoNomenclador = varCodigoNomenclador;
			
				item.ProfesionalVal = varProfesionalVal;
			
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
        
        
        
        public static TableSchema.TableColumn IdDetalleProtocoloColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdenAreaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdenColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn GrupoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ItemColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn EsTituloColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DerivadoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn HivColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn MetodoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorReferenciaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn Orden1Column
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn MuestraColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ConresultadoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ResultadoColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn Codigo2Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoNomencladorColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ProfesionalValColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProtocolo = @"idProtocolo";
			 public static string IdEfector = @"idEfector";
			 public static string IdDetalleProtocolo = @"idDetalleProtocolo";
			 public static string Codigo = @"codigo";
			 public static string OrdenArea = @"ordenArea";
			 public static string Orden = @"orden";
			 public static string Area = @"area";
			 public static string Grupo = @"grupo";
			 public static string Item = @"item";
			 public static string Observaciones = @"observaciones";
			 public static string EsTitulo = @"esTitulo";
			 public static string Derivado = @"derivado";
			 public static string Unidad = @"unidad";
			 public static string Hiv = @"hiv";
			 public static string Metodo = @"metodo";
			 public static string ValorReferencia = @"valorReferencia";
			 public static string Orden1 = @"orden1";
			 public static string Muestra = @"muestra";
			 public static string Conresultado = @"conresultado";
			 public static string Resultado = @"resultado";
			 public static string Codigo2 = @"codigo2";
			 public static string CodigoNomenclador = @"codigoNomenclador";
			 public static string ProfesionalVal = @"profesional_val";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
