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
	/// Strongly-typed collection for the PnEfeConv class.
	/// </summary>
    [Serializable]
	public partial class PnEfeConvCollection : ActiveList<PnEfeConv, PnEfeConvCollection>
	{	   
		public PnEfeConvCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnEfeConvCollection</returns>
		public PnEfeConvCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnEfeConv o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_efe_conv table.
	/// </summary>
	[Serializable]
	public partial class PnEfeConv : ActiveRecord<PnEfeConv>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnEfeConv()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnEfeConv(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnEfeConv(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnEfeConv(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_efe_conv", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdEfeConv = new TableSchema.TableColumn(schema);
				colvarIdEfeConv.ColumnName = "id_efe_conv";
				colvarIdEfeConv.DataType = DbType.Int32;
				colvarIdEfeConv.MaxLength = 0;
				colvarIdEfeConv.AutoIncrement = true;
				colvarIdEfeConv.IsNullable = false;
				colvarIdEfeConv.IsPrimaryKey = true;
				colvarIdEfeConv.IsForeignKey = false;
				colvarIdEfeConv.IsReadOnly = false;
				colvarIdEfeConv.DefaultSetting = @"";
				colvarIdEfeConv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEfeConv);
				
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
				
				TableSchema.TableColumn colvarDomicilio = new TableSchema.TableColumn(schema);
				colvarDomicilio.ColumnName = "domicilio";
				colvarDomicilio.DataType = DbType.AnsiString;
				colvarDomicilio.MaxLength = -1;
				colvarDomicilio.AutoIncrement = false;
				colvarDomicilio.IsNullable = true;
				colvarDomicilio.IsPrimaryKey = false;
				colvarDomicilio.IsForeignKey = false;
				colvarDomicilio.IsReadOnly = false;
				colvarDomicilio.DefaultSetting = @"";
				colvarDomicilio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicilio);
				
				TableSchema.TableColumn colvarDepartamento = new TableSchema.TableColumn(schema);
				colvarDepartamento.ColumnName = "departamento";
				colvarDepartamento.DataType = DbType.AnsiString;
				colvarDepartamento.MaxLength = -1;
				colvarDepartamento.AutoIncrement = false;
				colvarDepartamento.IsNullable = true;
				colvarDepartamento.IsPrimaryKey = false;
				colvarDepartamento.IsForeignKey = false;
				colvarDepartamento.IsReadOnly = false;
				colvarDepartamento.DefaultSetting = @"";
				colvarDepartamento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDepartamento);
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "localidad";
				colvarLocalidad.DataType = DbType.Int32;
				colvarLocalidad.MaxLength = 0;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarCodPos = new TableSchema.TableColumn(schema);
				colvarCodPos.ColumnName = "cod_pos";
				colvarCodPos.DataType = DbType.Int32;
				colvarCodPos.MaxLength = 0;
				colvarCodPos.AutoIncrement = false;
				colvarCodPos.IsNullable = true;
				colvarCodPos.IsPrimaryKey = false;
				colvarCodPos.IsForeignKey = false;
				colvarCodPos.IsReadOnly = false;
				colvarCodPos.DefaultSetting = @"";
				colvarCodPos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodPos);
				
				TableSchema.TableColumn colvarCuidad = new TableSchema.TableColumn(schema);
				colvarCuidad.ColumnName = "cuidad";
				colvarCuidad.DataType = DbType.AnsiString;
				colvarCuidad.MaxLength = -1;
				colvarCuidad.AutoIncrement = false;
				colvarCuidad.IsNullable = true;
				colvarCuidad.IsPrimaryKey = false;
				colvarCuidad.IsForeignKey = false;
				colvarCuidad.IsReadOnly = false;
				colvarCuidad.DefaultSetting = @"";
				colvarCuidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuidad);
				
				TableSchema.TableColumn colvarReferente = new TableSchema.TableColumn(schema);
				colvarReferente.ColumnName = "referente";
				colvarReferente.DataType = DbType.AnsiString;
				colvarReferente.MaxLength = -1;
				colvarReferente.AutoIncrement = false;
				colvarReferente.IsNullable = true;
				colvarReferente.IsPrimaryKey = false;
				colvarReferente.IsForeignKey = false;
				colvarReferente.IsReadOnly = false;
				colvarReferente.DefaultSetting = @"";
				colvarReferente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferente);
				
				TableSchema.TableColumn colvarTel = new TableSchema.TableColumn(schema);
				colvarTel.ColumnName = "tel";
				colvarTel.DataType = DbType.AnsiString;
				colvarTel.MaxLength = -1;
				colvarTel.AutoIncrement = false;
				colvarTel.IsNullable = true;
				colvarTel.IsPrimaryKey = false;
				colvarTel.IsForeignKey = false;
				colvarTel.IsReadOnly = false;
				colvarTel.DefaultSetting = @"";
				colvarTel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTel);
				
				TableSchema.TableColumn colvarComGestion = new TableSchema.TableColumn(schema);
				colvarComGestion.ColumnName = "com_gestion";
				colvarComGestion.DataType = DbType.AnsiString;
				colvarComGestion.MaxLength = -1;
				colvarComGestion.AutoIncrement = false;
				colvarComGestion.IsNullable = true;
				colvarComGestion.IsPrimaryKey = false;
				colvarComGestion.IsForeignKey = false;
				colvarComGestion.IsReadOnly = false;
				colvarComGestion.DefaultSetting = @"";
				colvarComGestion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComGestion);
				
				TableSchema.TableColumn colvarComGestionFirmante = new TableSchema.TableColumn(schema);
				colvarComGestionFirmante.ColumnName = "com_gestion_firmante";
				colvarComGestionFirmante.DataType = DbType.AnsiString;
				colvarComGestionFirmante.MaxLength = -1;
				colvarComGestionFirmante.AutoIncrement = false;
				colvarComGestionFirmante.IsNullable = true;
				colvarComGestionFirmante.IsPrimaryKey = false;
				colvarComGestionFirmante.IsForeignKey = false;
				colvarComGestionFirmante.IsReadOnly = false;
				colvarComGestionFirmante.DefaultSetting = @"";
				colvarComGestionFirmante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComGestionFirmante);
				
				TableSchema.TableColumn colvarFechaCompGes = new TableSchema.TableColumn(schema);
				colvarFechaCompGes.ColumnName = "fecha_comp_ges";
				colvarFechaCompGes.DataType = DbType.DateTime;
				colvarFechaCompGes.MaxLength = 0;
				colvarFechaCompGes.AutoIncrement = false;
				colvarFechaCompGes.IsNullable = true;
				colvarFechaCompGes.IsPrimaryKey = false;
				colvarFechaCompGes.IsForeignKey = false;
				colvarFechaCompGes.IsReadOnly = false;
				colvarFechaCompGes.DefaultSetting = @"";
				colvarFechaCompGes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaCompGes);
				
				TableSchema.TableColumn colvarFechaFinCompGes = new TableSchema.TableColumn(schema);
				colvarFechaFinCompGes.ColumnName = "fecha_fin_comp_ges";
				colvarFechaFinCompGes.DataType = DbType.DateTime;
				colvarFechaFinCompGes.MaxLength = 0;
				colvarFechaFinCompGes.AutoIncrement = false;
				colvarFechaFinCompGes.IsNullable = true;
				colvarFechaFinCompGes.IsPrimaryKey = false;
				colvarFechaFinCompGes.IsForeignKey = false;
				colvarFechaFinCompGes.IsReadOnly = false;
				colvarFechaFinCompGes.DefaultSetting = @"";
				colvarFechaFinCompGes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFinCompGes);
				
				TableSchema.TableColumn colvarComGestionPagoIndirecto = new TableSchema.TableColumn(schema);
				colvarComGestionPagoIndirecto.ColumnName = "com_gestion_pago_indirecto";
				colvarComGestionPagoIndirecto.DataType = DbType.AnsiString;
				colvarComGestionPagoIndirecto.MaxLength = -1;
				colvarComGestionPagoIndirecto.AutoIncrement = false;
				colvarComGestionPagoIndirecto.IsNullable = true;
				colvarComGestionPagoIndirecto.IsPrimaryKey = false;
				colvarComGestionPagoIndirecto.IsForeignKey = false;
				colvarComGestionPagoIndirecto.IsReadOnly = false;
				colvarComGestionPagoIndirecto.DefaultSetting = @"";
				colvarComGestionPagoIndirecto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComGestionPagoIndirecto);
				
				TableSchema.TableColumn colvarTerceroAdmin = new TableSchema.TableColumn(schema);
				colvarTerceroAdmin.ColumnName = "tercero_admin";
				colvarTerceroAdmin.DataType = DbType.AnsiString;
				colvarTerceroAdmin.MaxLength = -1;
				colvarTerceroAdmin.AutoIncrement = false;
				colvarTerceroAdmin.IsNullable = true;
				colvarTerceroAdmin.IsPrimaryKey = false;
				colvarTerceroAdmin.IsForeignKey = false;
				colvarTerceroAdmin.IsReadOnly = false;
				colvarTerceroAdmin.DefaultSetting = @"";
				colvarTerceroAdmin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTerceroAdmin);
				
				TableSchema.TableColumn colvarTerceroAdminFirmante = new TableSchema.TableColumn(schema);
				colvarTerceroAdminFirmante.ColumnName = "tercero_admin_firmante";
				colvarTerceroAdminFirmante.DataType = DbType.AnsiString;
				colvarTerceroAdminFirmante.MaxLength = -1;
				colvarTerceroAdminFirmante.AutoIncrement = false;
				colvarTerceroAdminFirmante.IsNullable = true;
				colvarTerceroAdminFirmante.IsPrimaryKey = false;
				colvarTerceroAdminFirmante.IsForeignKey = false;
				colvarTerceroAdminFirmante.IsReadOnly = false;
				colvarTerceroAdminFirmante.DefaultSetting = @"";
				colvarTerceroAdminFirmante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTerceroAdminFirmante);
				
				TableSchema.TableColumn colvarFechaTerceroAdmin = new TableSchema.TableColumn(schema);
				colvarFechaTerceroAdmin.ColumnName = "fecha_tercero_admin";
				colvarFechaTerceroAdmin.DataType = DbType.DateTime;
				colvarFechaTerceroAdmin.MaxLength = 0;
				colvarFechaTerceroAdmin.AutoIncrement = false;
				colvarFechaTerceroAdmin.IsNullable = true;
				colvarFechaTerceroAdmin.IsPrimaryKey = false;
				colvarFechaTerceroAdmin.IsForeignKey = false;
				colvarFechaTerceroAdmin.IsReadOnly = false;
				colvarFechaTerceroAdmin.DefaultSetting = @"";
				colvarFechaTerceroAdmin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTerceroAdmin);
				
				TableSchema.TableColumn colvarFechaFinTerceroAdmin = new TableSchema.TableColumn(schema);
				colvarFechaFinTerceroAdmin.ColumnName = "fecha_fin_tercero_admin";
				colvarFechaFinTerceroAdmin.DataType = DbType.DateTime;
				colvarFechaFinTerceroAdmin.MaxLength = 0;
				colvarFechaFinTerceroAdmin.AutoIncrement = false;
				colvarFechaFinTerceroAdmin.IsNullable = true;
				colvarFechaFinTerceroAdmin.IsPrimaryKey = false;
				colvarFechaFinTerceroAdmin.IsForeignKey = false;
				colvarFechaFinTerceroAdmin.IsReadOnly = false;
				colvarFechaFinTerceroAdmin.DefaultSetting = @"";
				colvarFechaFinTerceroAdmin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaFinTerceroAdmin);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = true;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
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
				
				TableSchema.TableColumn colvarFechaModificacion = new TableSchema.TableColumn(schema);
				colvarFechaModificacion.ColumnName = "fecha_modificacion";
				colvarFechaModificacion.DataType = DbType.DateTime;
				colvarFechaModificacion.MaxLength = 0;
				colvarFechaModificacion.AutoIncrement = false;
				colvarFechaModificacion.IsNullable = true;
				colvarFechaModificacion.IsPrimaryKey = false;
				colvarFechaModificacion.IsForeignKey = false;
				colvarFechaModificacion.IsReadOnly = false;
				colvarFechaModificacion.DefaultSetting = @"";
				colvarFechaModificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaModificacion);
				
				TableSchema.TableColumn colvarDniFirmanteActual = new TableSchema.TableColumn(schema);
				colvarDniFirmanteActual.ColumnName = "dni_firmante_actual";
				colvarDniFirmanteActual.DataType = DbType.AnsiString;
				colvarDniFirmanteActual.MaxLength = -1;
				colvarDniFirmanteActual.AutoIncrement = false;
				colvarDniFirmanteActual.IsNullable = true;
				colvarDniFirmanteActual.IsPrimaryKey = false;
				colvarDniFirmanteActual.IsForeignKey = false;
				colvarDniFirmanteActual.IsReadOnly = false;
				colvarDniFirmanteActual.DefaultSetting = @"";
				colvarDniFirmanteActual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDniFirmanteActual);
				
				TableSchema.TableColumn colvarComGestionFirmanteActual = new TableSchema.TableColumn(schema);
				colvarComGestionFirmanteActual.ColumnName = "com_gestion_firmante_actual";
				colvarComGestionFirmanteActual.DataType = DbType.AnsiString;
				colvarComGestionFirmanteActual.MaxLength = -1;
				colvarComGestionFirmanteActual.AutoIncrement = false;
				colvarComGestionFirmanteActual.IsNullable = true;
				colvarComGestionFirmanteActual.IsPrimaryKey = false;
				colvarComGestionFirmanteActual.IsForeignKey = false;
				colvarComGestionFirmanteActual.IsReadOnly = false;
				colvarComGestionFirmanteActual.DefaultSetting = @"";
				colvarComGestionFirmanteActual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComGestionFirmanteActual);
				
				TableSchema.TableColumn colvarN2008 = new TableSchema.TableColumn(schema);
				colvarN2008.ColumnName = "n_2008";
				colvarN2008.DataType = DbType.AnsiString;
				colvarN2008.MaxLength = -1;
				colvarN2008.AutoIncrement = false;
				colvarN2008.IsNullable = true;
				colvarN2008.IsPrimaryKey = false;
				colvarN2008.IsForeignKey = false;
				colvarN2008.IsReadOnly = false;
				colvarN2008.DefaultSetting = @"";
				colvarN2008.ForeignKeyTableName = "";
				schema.Columns.Add(colvarN2008);
				
				TableSchema.TableColumn colvarN2009 = new TableSchema.TableColumn(schema);
				colvarN2009.ColumnName = "n_2009";
				colvarN2009.DataType = DbType.AnsiString;
				colvarN2009.MaxLength = -1;
				colvarN2009.AutoIncrement = false;
				colvarN2009.IsNullable = true;
				colvarN2009.IsPrimaryKey = false;
				colvarN2009.IsForeignKey = false;
				colvarN2009.IsReadOnly = false;
				colvarN2009.DefaultSetting = @"";
				colvarN2009.ForeignKeyTableName = "";
				schema.Columns.Add(colvarN2009);
				
				TableSchema.TableColumn colvarIdNomencladorDetalle = new TableSchema.TableColumn(schema);
				colvarIdNomencladorDetalle.ColumnName = "id_nomenclador_detalle";
				colvarIdNomencladorDetalle.DataType = DbType.Int32;
				colvarIdNomencladorDetalle.MaxLength = 0;
				colvarIdNomencladorDetalle.AutoIncrement = false;
				colvarIdNomencladorDetalle.IsNullable = true;
				colvarIdNomencladorDetalle.IsPrimaryKey = false;
				colvarIdNomencladorDetalle.IsForeignKey = false;
				colvarIdNomencladorDetalle.IsReadOnly = false;
				colvarIdNomencladorDetalle.DefaultSetting = @"";
				colvarIdNomencladorDetalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNomencladorDetalle);
				
				TableSchema.TableColumn colvarIdZonaSani = new TableSchema.TableColumn(schema);
				colvarIdZonaSani.ColumnName = "id_zona_sani";
				colvarIdZonaSani.DataType = DbType.Int32;
				colvarIdZonaSani.MaxLength = 0;
				colvarIdZonaSani.AutoIncrement = false;
				colvarIdZonaSani.IsNullable = true;
				colvarIdZonaSani.IsPrimaryKey = false;
				colvarIdZonaSani.IsForeignKey = true;
				colvarIdZonaSani.IsReadOnly = false;
				colvarIdZonaSani.DefaultSetting = @"";
				
					colvarIdZonaSani.ForeignKeyTableName = "PN_zona_sani";
				schema.Columns.Add(colvarIdZonaSani);
				
				TableSchema.TableColumn colvarMail = new TableSchema.TableColumn(schema);
				colvarMail.ColumnName = "mail";
				colvarMail.DataType = DbType.AnsiString;
				colvarMail.MaxLength = -1;
				colvarMail.AutoIncrement = false;
				colvarMail.IsNullable = true;
				colvarMail.IsPrimaryKey = false;
				colvarMail.IsForeignKey = false;
				colvarMail.IsReadOnly = false;
				colvarMail.DefaultSetting = @"";
				colvarMail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMail);
				
				TableSchema.TableColumn colvarIncentivo = new TableSchema.TableColumn(schema);
				colvarIncentivo.ColumnName = "incentivo";
				colvarIncentivo.DataType = DbType.AnsiString;
				colvarIncentivo.MaxLength = 2;
				colvarIncentivo.AutoIncrement = false;
				colvarIncentivo.IsNullable = true;
				colvarIncentivo.IsPrimaryKey = false;
				colvarIncentivo.IsForeignKey = false;
				colvarIncentivo.IsReadOnly = false;
				colvarIncentivo.DefaultSetting = @"";
				colvarIncentivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIncentivo);
				
				TableSchema.TableColumn colvarPerAltaCom = new TableSchema.TableColumn(schema);
				colvarPerAltaCom.ColumnName = "per_alta_com";
				colvarPerAltaCom.DataType = DbType.AnsiString;
				colvarPerAltaCom.MaxLength = 2;
				colvarPerAltaCom.AutoIncrement = false;
				colvarPerAltaCom.IsNullable = true;
				colvarPerAltaCom.IsPrimaryKey = false;
				colvarPerAltaCom.IsForeignKey = false;
				colvarPerAltaCom.IsReadOnly = false;
				colvarPerAltaCom.DefaultSetting = @"";
				colvarPerAltaCom.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerAltaCom);
				
				TableSchema.TableColumn colvarAdendaPer = new TableSchema.TableColumn(schema);
				colvarAdendaPer.ColumnName = "adenda_per";
				colvarAdendaPer.DataType = DbType.AnsiString;
				colvarAdendaPer.MaxLength = 50;
				colvarAdendaPer.AutoIncrement = false;
				colvarAdendaPer.IsNullable = true;
				colvarAdendaPer.IsPrimaryKey = false;
				colvarAdendaPer.IsForeignKey = false;
				colvarAdendaPer.IsReadOnly = false;
				colvarAdendaPer.DefaultSetting = @"";
				colvarAdendaPer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdendaPer);
				
				TableSchema.TableColumn colvarFechaAdendaPer = new TableSchema.TableColumn(schema);
				colvarFechaAdendaPer.ColumnName = "fecha_adenda_per";
				colvarFechaAdendaPer.DataType = DbType.DateTime;
				colvarFechaAdendaPer.MaxLength = 0;
				colvarFechaAdendaPer.AutoIncrement = false;
				colvarFechaAdendaPer.IsNullable = true;
				colvarFechaAdendaPer.IsPrimaryKey = false;
				colvarFechaAdendaPer.IsForeignKey = false;
				colvarFechaAdendaPer.IsReadOnly = false;
				colvarFechaAdendaPer.DefaultSetting = @"";
				colvarFechaAdendaPer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAdendaPer);
				
				TableSchema.TableColumn colvarCategoriaPer = new TableSchema.TableColumn(schema);
				colvarCategoriaPer.ColumnName = "categoria_per";
				colvarCategoriaPer.DataType = DbType.AnsiString;
				colvarCategoriaPer.MaxLength = -1;
				colvarCategoriaPer.AutoIncrement = false;
				colvarCategoriaPer.IsNullable = true;
				colvarCategoriaPer.IsPrimaryKey = false;
				colvarCategoriaPer.IsForeignKey = false;
				colvarCategoriaPer.IsReadOnly = false;
				colvarCategoriaPer.DefaultSetting = @"";
				colvarCategoriaPer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoriaPer);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_efe_conv",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdEfeConv")]
		[Bindable(true)]
		public int IdEfeConv 
		{
			get { return GetColumnValue<int>(Columns.IdEfeConv); }
			set { SetColumnValue(Columns.IdEfeConv, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("Departamento")]
		[Bindable(true)]
		public string Departamento 
		{
			get { return GetColumnValue<string>(Columns.Departamento); }
			set { SetColumnValue(Columns.Departamento, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public int? Localidad 
		{
			get { return GetColumnValue<int?>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("CodPos")]
		[Bindable(true)]
		public int? CodPos 
		{
			get { return GetColumnValue<int?>(Columns.CodPos); }
			set { SetColumnValue(Columns.CodPos, value); }
		}
		  
		[XmlAttribute("Cuidad")]
		[Bindable(true)]
		public string Cuidad 
		{
			get { return GetColumnValue<string>(Columns.Cuidad); }
			set { SetColumnValue(Columns.Cuidad, value); }
		}
		  
		[XmlAttribute("Referente")]
		[Bindable(true)]
		public string Referente 
		{
			get { return GetColumnValue<string>(Columns.Referente); }
			set { SetColumnValue(Columns.Referente, value); }
		}
		  
		[XmlAttribute("Tel")]
		[Bindable(true)]
		public string Tel 
		{
			get { return GetColumnValue<string>(Columns.Tel); }
			set { SetColumnValue(Columns.Tel, value); }
		}
		  
		[XmlAttribute("ComGestion")]
		[Bindable(true)]
		public string ComGestion 
		{
			get { return GetColumnValue<string>(Columns.ComGestion); }
			set { SetColumnValue(Columns.ComGestion, value); }
		}
		  
		[XmlAttribute("ComGestionFirmante")]
		[Bindable(true)]
		public string ComGestionFirmante 
		{
			get { return GetColumnValue<string>(Columns.ComGestionFirmante); }
			set { SetColumnValue(Columns.ComGestionFirmante, value); }
		}
		  
		[XmlAttribute("FechaCompGes")]
		[Bindable(true)]
		public DateTime? FechaCompGes 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCompGes); }
			set { SetColumnValue(Columns.FechaCompGes, value); }
		}
		  
		[XmlAttribute("FechaFinCompGes")]
		[Bindable(true)]
		public DateTime? FechaFinCompGes 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaFinCompGes); }
			set { SetColumnValue(Columns.FechaFinCompGes, value); }
		}
		  
		[XmlAttribute("ComGestionPagoIndirecto")]
		[Bindable(true)]
		public string ComGestionPagoIndirecto 
		{
			get { return GetColumnValue<string>(Columns.ComGestionPagoIndirecto); }
			set { SetColumnValue(Columns.ComGestionPagoIndirecto, value); }
		}
		  
		[XmlAttribute("TerceroAdmin")]
		[Bindable(true)]
		public string TerceroAdmin 
		{
			get { return GetColumnValue<string>(Columns.TerceroAdmin); }
			set { SetColumnValue(Columns.TerceroAdmin, value); }
		}
		  
		[XmlAttribute("TerceroAdminFirmante")]
		[Bindable(true)]
		public string TerceroAdminFirmante 
		{
			get { return GetColumnValue<string>(Columns.TerceroAdminFirmante); }
			set { SetColumnValue(Columns.TerceroAdminFirmante, value); }
		}
		  
		[XmlAttribute("FechaTerceroAdmin")]
		[Bindable(true)]
		public DateTime? FechaTerceroAdmin 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaTerceroAdmin); }
			set { SetColumnValue(Columns.FechaTerceroAdmin, value); }
		}
		  
		[XmlAttribute("FechaFinTerceroAdmin")]
		[Bindable(true)]
		public DateTime? FechaFinTerceroAdmin 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaFinTerceroAdmin); }
			set { SetColumnValue(Columns.FechaFinTerceroAdmin, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("FechaModificacion")]
		[Bindable(true)]
		public DateTime? FechaModificacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaModificacion); }
			set { SetColumnValue(Columns.FechaModificacion, value); }
		}
		  
		[XmlAttribute("DniFirmanteActual")]
		[Bindable(true)]
		public string DniFirmanteActual 
		{
			get { return GetColumnValue<string>(Columns.DniFirmanteActual); }
			set { SetColumnValue(Columns.DniFirmanteActual, value); }
		}
		  
		[XmlAttribute("ComGestionFirmanteActual")]
		[Bindable(true)]
		public string ComGestionFirmanteActual 
		{
			get { return GetColumnValue<string>(Columns.ComGestionFirmanteActual); }
			set { SetColumnValue(Columns.ComGestionFirmanteActual, value); }
		}
		  
		[XmlAttribute("N2008")]
		[Bindable(true)]
		public string N2008 
		{
			get { return GetColumnValue<string>(Columns.N2008); }
			set { SetColumnValue(Columns.N2008, value); }
		}
		  
		[XmlAttribute("N2009")]
		[Bindable(true)]
		public string N2009 
		{
			get { return GetColumnValue<string>(Columns.N2009); }
			set { SetColumnValue(Columns.N2009, value); }
		}
		  
		[XmlAttribute("IdNomencladorDetalle")]
		[Bindable(true)]
		public int? IdNomencladorDetalle 
		{
			get { return GetColumnValue<int?>(Columns.IdNomencladorDetalle); }
			set { SetColumnValue(Columns.IdNomencladorDetalle, value); }
		}
		  
		[XmlAttribute("IdZonaSani")]
		[Bindable(true)]
		public int? IdZonaSani 
		{
			get { return GetColumnValue<int?>(Columns.IdZonaSani); }
			set { SetColumnValue(Columns.IdZonaSani, value); }
		}
		  
		[XmlAttribute("Mail")]
		[Bindable(true)]
		public string Mail 
		{
			get { return GetColumnValue<string>(Columns.Mail); }
			set { SetColumnValue(Columns.Mail, value); }
		}
		  
		[XmlAttribute("Incentivo")]
		[Bindable(true)]
		public string Incentivo 
		{
			get { return GetColumnValue<string>(Columns.Incentivo); }
			set { SetColumnValue(Columns.Incentivo, value); }
		}
		  
		[XmlAttribute("PerAltaCom")]
		[Bindable(true)]
		public string PerAltaCom 
		{
			get { return GetColumnValue<string>(Columns.PerAltaCom); }
			set { SetColumnValue(Columns.PerAltaCom, value); }
		}
		  
		[XmlAttribute("AdendaPer")]
		[Bindable(true)]
		public string AdendaPer 
		{
			get { return GetColumnValue<string>(Columns.AdendaPer); }
			set { SetColumnValue(Columns.AdendaPer, value); }
		}
		  
		[XmlAttribute("FechaAdendaPer")]
		[Bindable(true)]
		public DateTime? FechaAdendaPer 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAdendaPer); }
			set { SetColumnValue(Columns.FechaAdendaPer, value); }
		}
		  
		[XmlAttribute("CategoriaPer")]
		[Bindable(true)]
		public string CategoriaPer 
		{
			get { return GetColumnValue<string>(Columns.CategoriaPer); }
			set { SetColumnValue(Columns.CategoriaPer, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a PnZonaSani ActiveRecord object related to this PnEfeConv
		/// 
		/// </summary>
		public DalSic.PnZonaSani PnZonaSani
		{
			get { return DalSic.PnZonaSani.FetchByID(this.IdZonaSani); }
			set { SetColumnValue("id_zona_sani", value.IdZonaSani); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,string varDomicilio,string varDepartamento,int? varLocalidad,int? varCodPos,string varCuidad,string varReferente,string varTel,string varComGestion,string varComGestionFirmante,DateTime? varFechaCompGes,DateTime? varFechaFinCompGes,string varComGestionPagoIndirecto,string varTerceroAdmin,string varTerceroAdminFirmante,DateTime? varFechaTerceroAdmin,DateTime? varFechaFinTerceroAdmin,string varCuie,string varUsuario,DateTime? varFechaModificacion,string varDniFirmanteActual,string varComGestionFirmanteActual,string varN2008,string varN2009,int? varIdNomencladorDetalle,int? varIdZonaSani,string varMail,string varIncentivo,string varPerAltaCom,string varAdendaPer,DateTime? varFechaAdendaPer,string varCategoriaPer)
		{
			PnEfeConv item = new PnEfeConv();
			
			item.Nombre = varNombre;
			
			item.Domicilio = varDomicilio;
			
			item.Departamento = varDepartamento;
			
			item.Localidad = varLocalidad;
			
			item.CodPos = varCodPos;
			
			item.Cuidad = varCuidad;
			
			item.Referente = varReferente;
			
			item.Tel = varTel;
			
			item.ComGestion = varComGestion;
			
			item.ComGestionFirmante = varComGestionFirmante;
			
			item.FechaCompGes = varFechaCompGes;
			
			item.FechaFinCompGes = varFechaFinCompGes;
			
			item.ComGestionPagoIndirecto = varComGestionPagoIndirecto;
			
			item.TerceroAdmin = varTerceroAdmin;
			
			item.TerceroAdminFirmante = varTerceroAdminFirmante;
			
			item.FechaTerceroAdmin = varFechaTerceroAdmin;
			
			item.FechaFinTerceroAdmin = varFechaFinTerceroAdmin;
			
			item.Cuie = varCuie;
			
			item.Usuario = varUsuario;
			
			item.FechaModificacion = varFechaModificacion;
			
			item.DniFirmanteActual = varDniFirmanteActual;
			
			item.ComGestionFirmanteActual = varComGestionFirmanteActual;
			
			item.N2008 = varN2008;
			
			item.N2009 = varN2009;
			
			item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
			item.IdZonaSani = varIdZonaSani;
			
			item.Mail = varMail;
			
			item.Incentivo = varIncentivo;
			
			item.PerAltaCom = varPerAltaCom;
			
			item.AdendaPer = varAdendaPer;
			
			item.FechaAdendaPer = varFechaAdendaPer;
			
			item.CategoriaPer = varCategoriaPer;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdEfeConv,string varNombre,string varDomicilio,string varDepartamento,int? varLocalidad,int? varCodPos,string varCuidad,string varReferente,string varTel,string varComGestion,string varComGestionFirmante,DateTime? varFechaCompGes,DateTime? varFechaFinCompGes,string varComGestionPagoIndirecto,string varTerceroAdmin,string varTerceroAdminFirmante,DateTime? varFechaTerceroAdmin,DateTime? varFechaFinTerceroAdmin,string varCuie,string varUsuario,DateTime? varFechaModificacion,string varDniFirmanteActual,string varComGestionFirmanteActual,string varN2008,string varN2009,int? varIdNomencladorDetalle,int? varIdZonaSani,string varMail,string varIncentivo,string varPerAltaCom,string varAdendaPer,DateTime? varFechaAdendaPer,string varCategoriaPer)
		{
			PnEfeConv item = new PnEfeConv();
			
				item.IdEfeConv = varIdEfeConv;
			
				item.Nombre = varNombre;
			
				item.Domicilio = varDomicilio;
			
				item.Departamento = varDepartamento;
			
				item.Localidad = varLocalidad;
			
				item.CodPos = varCodPos;
			
				item.Cuidad = varCuidad;
			
				item.Referente = varReferente;
			
				item.Tel = varTel;
			
				item.ComGestion = varComGestion;
			
				item.ComGestionFirmante = varComGestionFirmante;
			
				item.FechaCompGes = varFechaCompGes;
			
				item.FechaFinCompGes = varFechaFinCompGes;
			
				item.ComGestionPagoIndirecto = varComGestionPagoIndirecto;
			
				item.TerceroAdmin = varTerceroAdmin;
			
				item.TerceroAdminFirmante = varTerceroAdminFirmante;
			
				item.FechaTerceroAdmin = varFechaTerceroAdmin;
			
				item.FechaFinTerceroAdmin = varFechaFinTerceroAdmin;
			
				item.Cuie = varCuie;
			
				item.Usuario = varUsuario;
			
				item.FechaModificacion = varFechaModificacion;
			
				item.DniFirmanteActual = varDniFirmanteActual;
			
				item.ComGestionFirmanteActual = varComGestionFirmanteActual;
			
				item.N2008 = varN2008;
			
				item.N2009 = varN2009;
			
				item.IdNomencladorDetalle = varIdNomencladorDetalle;
			
				item.IdZonaSani = varIdZonaSani;
			
				item.Mail = varMail;
			
				item.Incentivo = varIncentivo;
			
				item.PerAltaCom = varPerAltaCom;
			
				item.AdendaPer = varAdendaPer;
			
				item.FechaAdendaPer = varFechaAdendaPer;
			
				item.CategoriaPer = varCategoriaPer;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdEfeConvColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DepartamentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CodPosColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CuidadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ReferenteColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TelColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ComGestionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ComGestionFirmanteColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCompGesColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFinCompGesColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ComGestionPagoIndirectoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn TerceroAdminColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn TerceroAdminFirmanteColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTerceroAdminColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaFinTerceroAdminColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaModificacionColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn DniFirmanteActualColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ComGestionFirmanteActualColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn N2008Column
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn N2009Column
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNomencladorDetalleColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn IdZonaSaniColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn MailColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn IncentivoColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn PerAltaComColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn AdendaPerColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAdendaPerColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoriaPerColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdEfeConv = @"id_efe_conv";
			 public static string Nombre = @"nombre";
			 public static string Domicilio = @"domicilio";
			 public static string Departamento = @"departamento";
			 public static string Localidad = @"localidad";
			 public static string CodPos = @"cod_pos";
			 public static string Cuidad = @"cuidad";
			 public static string Referente = @"referente";
			 public static string Tel = @"tel";
			 public static string ComGestion = @"com_gestion";
			 public static string ComGestionFirmante = @"com_gestion_firmante";
			 public static string FechaCompGes = @"fecha_comp_ges";
			 public static string FechaFinCompGes = @"fecha_fin_comp_ges";
			 public static string ComGestionPagoIndirecto = @"com_gestion_pago_indirecto";
			 public static string TerceroAdmin = @"tercero_admin";
			 public static string TerceroAdminFirmante = @"tercero_admin_firmante";
			 public static string FechaTerceroAdmin = @"fecha_tercero_admin";
			 public static string FechaFinTerceroAdmin = @"fecha_fin_tercero_admin";
			 public static string Cuie = @"cuie";
			 public static string Usuario = @"usuario";
			 public static string FechaModificacion = @"fecha_modificacion";
			 public static string DniFirmanteActual = @"dni_firmante_actual";
			 public static string ComGestionFirmanteActual = @"com_gestion_firmante_actual";
			 public static string N2008 = @"n_2008";
			 public static string N2009 = @"n_2009";
			 public static string IdNomencladorDetalle = @"id_nomenclador_detalle";
			 public static string IdZonaSani = @"id_zona_sani";
			 public static string Mail = @"mail";
			 public static string Incentivo = @"incentivo";
			 public static string PerAltaCom = @"per_alta_com";
			 public static string AdendaPer = @"adenda_per";
			 public static string FechaAdendaPer = @"fecha_adenda_per";
			 public static string CategoriaPer = @"categoria_per";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
