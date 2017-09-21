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
	/// Strongly-typed collection for the PnBeneficiario class.
	/// </summary>
    [Serializable]
	public partial class PnBeneficiarioCollection : ActiveList<PnBeneficiario, PnBeneficiarioCollection>
	{	   
		public PnBeneficiarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnBeneficiarioCollection</returns>
		public PnBeneficiarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnBeneficiario o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_beneficiarios table.
	/// </summary>
	[Serializable]
	public partial class PnBeneficiario : ActiveRecord<PnBeneficiario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnBeneficiario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnBeneficiario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnBeneficiario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnBeneficiario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_beneficiarios", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdBeneficiarios = new TableSchema.TableColumn(schema);
				colvarIdBeneficiarios.ColumnName = "id_beneficiarios";
				colvarIdBeneficiarios.DataType = DbType.Int32;
				colvarIdBeneficiarios.MaxLength = 0;
				colvarIdBeneficiarios.AutoIncrement = true;
				colvarIdBeneficiarios.IsNullable = false;
				colvarIdBeneficiarios.IsPrimaryKey = true;
				colvarIdBeneficiarios.IsForeignKey = false;
				colvarIdBeneficiarios.IsReadOnly = false;
				colvarIdBeneficiarios.DefaultSetting = @"";
				colvarIdBeneficiarios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBeneficiarios);
				
				TableSchema.TableColumn colvarEstadoEnvio = new TableSchema.TableColumn(schema);
				colvarEstadoEnvio.ColumnName = "estado_envio";
				colvarEstadoEnvio.DataType = DbType.AnsiString;
				colvarEstadoEnvio.MaxLength = 1;
				colvarEstadoEnvio.AutoIncrement = false;
				colvarEstadoEnvio.IsNullable = true;
				colvarEstadoEnvio.IsPrimaryKey = false;
				colvarEstadoEnvio.IsForeignKey = false;
				colvarEstadoEnvio.IsReadOnly = false;
				colvarEstadoEnvio.DefaultSetting = @"";
				colvarEstadoEnvio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoEnvio);
				
				TableSchema.TableColumn colvarClaveBeneficiario = new TableSchema.TableColumn(schema);
				colvarClaveBeneficiario.ColumnName = "clave_beneficiario";
				colvarClaveBeneficiario.DataType = DbType.AnsiString;
				colvarClaveBeneficiario.MaxLength = 16;
				colvarClaveBeneficiario.AutoIncrement = false;
				colvarClaveBeneficiario.IsNullable = true;
				colvarClaveBeneficiario.IsPrimaryKey = false;
				colvarClaveBeneficiario.IsForeignKey = false;
				colvarClaveBeneficiario.IsReadOnly = false;
				colvarClaveBeneficiario.DefaultSetting = @"";
				colvarClaveBeneficiario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClaveBeneficiario);
				
				TableSchema.TableColumn colvarTipoTransaccion = new TableSchema.TableColumn(schema);
				colvarTipoTransaccion.ColumnName = "tipo_transaccion";
				colvarTipoTransaccion.DataType = DbType.AnsiString;
				colvarTipoTransaccion.MaxLength = 1;
				colvarTipoTransaccion.AutoIncrement = false;
				colvarTipoTransaccion.IsNullable = true;
				colvarTipoTransaccion.IsPrimaryKey = false;
				colvarTipoTransaccion.IsForeignKey = false;
				colvarTipoTransaccion.IsReadOnly = false;
				colvarTipoTransaccion.DefaultSetting = @"";
				colvarTipoTransaccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoTransaccion);
				
				TableSchema.TableColumn colvarApellidoBenef = new TableSchema.TableColumn(schema);
				colvarApellidoBenef.ColumnName = "apellido_benef";
				colvarApellidoBenef.DataType = DbType.AnsiString;
				colvarApellidoBenef.MaxLength = 50;
				colvarApellidoBenef.AutoIncrement = false;
				colvarApellidoBenef.IsNullable = true;
				colvarApellidoBenef.IsPrimaryKey = false;
				colvarApellidoBenef.IsForeignKey = false;
				colvarApellidoBenef.IsReadOnly = false;
				colvarApellidoBenef.DefaultSetting = @"";
				colvarApellidoBenef.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoBenef);
				
				TableSchema.TableColumn colvarNombreBenef = new TableSchema.TableColumn(schema);
				colvarNombreBenef.ColumnName = "nombre_benef";
				colvarNombreBenef.DataType = DbType.AnsiString;
				colvarNombreBenef.MaxLength = 50;
				colvarNombreBenef.AutoIncrement = false;
				colvarNombreBenef.IsNullable = true;
				colvarNombreBenef.IsPrimaryKey = false;
				colvarNombreBenef.IsForeignKey = false;
				colvarNombreBenef.IsReadOnly = false;
				colvarNombreBenef.DefaultSetting = @"";
				colvarNombreBenef.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreBenef);
				
				TableSchema.TableColumn colvarClaseDocumentoBenef = new TableSchema.TableColumn(schema);
				colvarClaseDocumentoBenef.ColumnName = "clase_documento_benef";
				colvarClaseDocumentoBenef.DataType = DbType.AnsiString;
				colvarClaseDocumentoBenef.MaxLength = 1;
				colvarClaseDocumentoBenef.AutoIncrement = false;
				colvarClaseDocumentoBenef.IsNullable = true;
				colvarClaseDocumentoBenef.IsPrimaryKey = false;
				colvarClaseDocumentoBenef.IsForeignKey = false;
				colvarClaseDocumentoBenef.IsReadOnly = false;
				colvarClaseDocumentoBenef.DefaultSetting = @"";
				colvarClaseDocumentoBenef.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClaseDocumentoBenef);
				
				TableSchema.TableColumn colvarTipoDocumento = new TableSchema.TableColumn(schema);
				colvarTipoDocumento.ColumnName = "tipo_documento";
				colvarTipoDocumento.DataType = DbType.AnsiString;
				colvarTipoDocumento.MaxLength = 10;
				colvarTipoDocumento.AutoIncrement = false;
				colvarTipoDocumento.IsNullable = true;
				colvarTipoDocumento.IsPrimaryKey = false;
				colvarTipoDocumento.IsForeignKey = false;
				colvarTipoDocumento.IsReadOnly = false;
				colvarTipoDocumento.DefaultSetting = @"";
				colvarTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocumento);
				
				TableSchema.TableColumn colvarNumeroDoc = new TableSchema.TableColumn(schema);
				colvarNumeroDoc.ColumnName = "numero_doc";
				colvarNumeroDoc.DataType = DbType.AnsiString;
				colvarNumeroDoc.MaxLength = 12;
				colvarNumeroDoc.AutoIncrement = false;
				colvarNumeroDoc.IsNullable = true;
				colvarNumeroDoc.IsPrimaryKey = false;
				colvarNumeroDoc.IsForeignKey = false;
				colvarNumeroDoc.IsReadOnly = false;
				colvarNumeroDoc.DefaultSetting = @"";
				colvarNumeroDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDoc);
				
				TableSchema.TableColumn colvarIdCategoria = new TableSchema.TableColumn(schema);
				colvarIdCategoria.ColumnName = "id_categoria";
				colvarIdCategoria.DataType = DbType.Int32;
				colvarIdCategoria.MaxLength = 0;
				colvarIdCategoria.AutoIncrement = false;
				colvarIdCategoria.IsNullable = false;
				colvarIdCategoria.IsPrimaryKey = false;
				colvarIdCategoria.IsForeignKey = false;
				colvarIdCategoria.IsReadOnly = false;
				colvarIdCategoria.DefaultSetting = @"";
				colvarIdCategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCategoria);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "sexo";
				colvarSexo.DataType = DbType.AnsiString;
				colvarSexo.MaxLength = 1;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = true;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarFechaNacimientoBenef = new TableSchema.TableColumn(schema);
				colvarFechaNacimientoBenef.ColumnName = "fecha_nacimiento_benef";
				colvarFechaNacimientoBenef.DataType = DbType.DateTime;
				colvarFechaNacimientoBenef.MaxLength = 0;
				colvarFechaNacimientoBenef.AutoIncrement = false;
				colvarFechaNacimientoBenef.IsNullable = true;
				colvarFechaNacimientoBenef.IsPrimaryKey = false;
				colvarFechaNacimientoBenef.IsForeignKey = false;
				colvarFechaNacimientoBenef.IsReadOnly = false;
				colvarFechaNacimientoBenef.DefaultSetting = @"";
				colvarFechaNacimientoBenef.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimientoBenef);
				
				TableSchema.TableColumn colvarProvinciaNac = new TableSchema.TableColumn(schema);
				colvarProvinciaNac.ColumnName = "provincia_nac";
				colvarProvinciaNac.DataType = DbType.AnsiString;
				colvarProvinciaNac.MaxLength = 20;
				colvarProvinciaNac.AutoIncrement = false;
				colvarProvinciaNac.IsNullable = true;
				colvarProvinciaNac.IsPrimaryKey = false;
				colvarProvinciaNac.IsForeignKey = false;
				colvarProvinciaNac.IsReadOnly = false;
				colvarProvinciaNac.DefaultSetting = @"";
				colvarProvinciaNac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProvinciaNac);
				
				TableSchema.TableColumn colvarLocalidadNac = new TableSchema.TableColumn(schema);
				colvarLocalidadNac.ColumnName = "localidad_nac";
				colvarLocalidadNac.DataType = DbType.AnsiString;
				colvarLocalidadNac.MaxLength = 20;
				colvarLocalidadNac.AutoIncrement = false;
				colvarLocalidadNac.IsNullable = true;
				colvarLocalidadNac.IsPrimaryKey = false;
				colvarLocalidadNac.IsForeignKey = false;
				colvarLocalidadNac.IsReadOnly = false;
				colvarLocalidadNac.DefaultSetting = @"";
				colvarLocalidadNac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidadNac);
				
				TableSchema.TableColumn colvarPaisNac = new TableSchema.TableColumn(schema);
				colvarPaisNac.ColumnName = "pais_nac";
				colvarPaisNac.DataType = DbType.AnsiString;
				colvarPaisNac.MaxLength = 40;
				colvarPaisNac.AutoIncrement = false;
				colvarPaisNac.IsNullable = true;
				colvarPaisNac.IsPrimaryKey = false;
				colvarPaisNac.IsForeignKey = false;
				colvarPaisNac.IsReadOnly = false;
				colvarPaisNac.DefaultSetting = @"";
				colvarPaisNac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaisNac);
				
				TableSchema.TableColumn colvarIndigena = new TableSchema.TableColumn(schema);
				colvarIndigena.ColumnName = "indigena";
				colvarIndigena.DataType = DbType.AnsiString;
				colvarIndigena.MaxLength = 1;
				colvarIndigena.AutoIncrement = false;
				colvarIndigena.IsNullable = true;
				colvarIndigena.IsPrimaryKey = false;
				colvarIndigena.IsForeignKey = false;
				colvarIndigena.IsReadOnly = false;
				colvarIndigena.DefaultSetting = @"";
				colvarIndigena.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIndigena);
				
				TableSchema.TableColumn colvarIdTribu = new TableSchema.TableColumn(schema);
				colvarIdTribu.ColumnName = "id_tribu";
				colvarIdTribu.DataType = DbType.Int32;
				colvarIdTribu.MaxLength = 0;
				colvarIdTribu.AutoIncrement = false;
				colvarIdTribu.IsNullable = false;
				colvarIdTribu.IsPrimaryKey = false;
				colvarIdTribu.IsForeignKey = false;
				colvarIdTribu.IsReadOnly = false;
				colvarIdTribu.DefaultSetting = @"";
				colvarIdTribu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTribu);
				
				TableSchema.TableColumn colvarIdLengua = new TableSchema.TableColumn(schema);
				colvarIdLengua.ColumnName = "id_lengua";
				colvarIdLengua.DataType = DbType.Int32;
				colvarIdLengua.MaxLength = 0;
				colvarIdLengua.AutoIncrement = false;
				colvarIdLengua.IsNullable = false;
				colvarIdLengua.IsPrimaryKey = false;
				colvarIdLengua.IsForeignKey = false;
				colvarIdLengua.IsReadOnly = false;
				colvarIdLengua.DefaultSetting = @"";
				colvarIdLengua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLengua);
				
				TableSchema.TableColumn colvarAlfabeta = new TableSchema.TableColumn(schema);
				colvarAlfabeta.ColumnName = "alfabeta";
				colvarAlfabeta.DataType = DbType.AnsiString;
				colvarAlfabeta.MaxLength = 5;
				colvarAlfabeta.AutoIncrement = false;
				colvarAlfabeta.IsNullable = true;
				colvarAlfabeta.IsPrimaryKey = false;
				colvarAlfabeta.IsForeignKey = false;
				colvarAlfabeta.IsReadOnly = false;
				colvarAlfabeta.DefaultSetting = @"";
				colvarAlfabeta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlfabeta);
				
				TableSchema.TableColumn colvarEstudios = new TableSchema.TableColumn(schema);
				colvarEstudios.ColumnName = "estudios";
				colvarEstudios.DataType = DbType.AnsiString;
				colvarEstudios.MaxLength = 1;
				colvarEstudios.AutoIncrement = false;
				colvarEstudios.IsNullable = true;
				colvarEstudios.IsPrimaryKey = false;
				colvarEstudios.IsForeignKey = false;
				colvarEstudios.IsReadOnly = false;
				colvarEstudios.DefaultSetting = @"";
				colvarEstudios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudios);
				
				TableSchema.TableColumn colvarAnioMayorNivel = new TableSchema.TableColumn(schema);
				colvarAnioMayorNivel.ColumnName = "anio_mayor_nivel";
				colvarAnioMayorNivel.DataType = DbType.Int32;
				colvarAnioMayorNivel.MaxLength = 0;
				colvarAnioMayorNivel.AutoIncrement = false;
				colvarAnioMayorNivel.IsNullable = true;
				colvarAnioMayorNivel.IsPrimaryKey = false;
				colvarAnioMayorNivel.IsForeignKey = false;
				colvarAnioMayorNivel.IsReadOnly = false;
				
						colvarAnioMayorNivel.DefaultSetting = @"((0))";
				colvarAnioMayorNivel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnioMayorNivel);
				
				TableSchema.TableColumn colvarTipoDocMadre = new TableSchema.TableColumn(schema);
				colvarTipoDocMadre.ColumnName = "tipo_doc_madre";
				colvarTipoDocMadre.DataType = DbType.AnsiString;
				colvarTipoDocMadre.MaxLength = 5;
				colvarTipoDocMadre.AutoIncrement = false;
				colvarTipoDocMadre.IsNullable = true;
				colvarTipoDocMadre.IsPrimaryKey = false;
				colvarTipoDocMadre.IsForeignKey = false;
				colvarTipoDocMadre.IsReadOnly = false;
				colvarTipoDocMadre.DefaultSetting = @"";
				colvarTipoDocMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocMadre);
				
				TableSchema.TableColumn colvarNroDocMadre = new TableSchema.TableColumn(schema);
				colvarNroDocMadre.ColumnName = "nro_doc_madre";
				colvarNroDocMadre.DataType = DbType.AnsiString;
				colvarNroDocMadre.MaxLength = 12;
				colvarNroDocMadre.AutoIncrement = false;
				colvarNroDocMadre.IsNullable = true;
				colvarNroDocMadre.IsPrimaryKey = false;
				colvarNroDocMadre.IsForeignKey = false;
				colvarNroDocMadre.IsReadOnly = false;
				colvarNroDocMadre.DefaultSetting = @"";
				colvarNroDocMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroDocMadre);
				
				TableSchema.TableColumn colvarApellidoMadre = new TableSchema.TableColumn(schema);
				colvarApellidoMadre.ColumnName = "apellido_madre";
				colvarApellidoMadre.DataType = DbType.AnsiString;
				colvarApellidoMadre.MaxLength = 50;
				colvarApellidoMadre.AutoIncrement = false;
				colvarApellidoMadre.IsNullable = true;
				colvarApellidoMadre.IsPrimaryKey = false;
				colvarApellidoMadre.IsForeignKey = false;
				colvarApellidoMadre.IsReadOnly = false;
				colvarApellidoMadre.DefaultSetting = @"";
				colvarApellidoMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoMadre);
				
				TableSchema.TableColumn colvarNombreMadre = new TableSchema.TableColumn(schema);
				colvarNombreMadre.ColumnName = "nombre_madre";
				colvarNombreMadre.DataType = DbType.AnsiString;
				colvarNombreMadre.MaxLength = 50;
				colvarNombreMadre.AutoIncrement = false;
				colvarNombreMadre.IsNullable = true;
				colvarNombreMadre.IsPrimaryKey = false;
				colvarNombreMadre.IsForeignKey = false;
				colvarNombreMadre.IsReadOnly = false;
				colvarNombreMadre.DefaultSetting = @"";
				colvarNombreMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreMadre);
				
				TableSchema.TableColumn colvarAlfabetaMadre = new TableSchema.TableColumn(schema);
				colvarAlfabetaMadre.ColumnName = "alfabeta_madre";
				colvarAlfabetaMadre.DataType = DbType.AnsiString;
				colvarAlfabetaMadre.MaxLength = 1;
				colvarAlfabetaMadre.AutoIncrement = false;
				colvarAlfabetaMadre.IsNullable = true;
				colvarAlfabetaMadre.IsPrimaryKey = false;
				colvarAlfabetaMadre.IsForeignKey = false;
				colvarAlfabetaMadre.IsReadOnly = false;
				colvarAlfabetaMadre.DefaultSetting = @"";
				colvarAlfabetaMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlfabetaMadre);
				
				TableSchema.TableColumn colvarEstudiosMadre = new TableSchema.TableColumn(schema);
				colvarEstudiosMadre.ColumnName = "estudios_madre";
				colvarEstudiosMadre.DataType = DbType.AnsiString;
				colvarEstudiosMadre.MaxLength = 1;
				colvarEstudiosMadre.AutoIncrement = false;
				colvarEstudiosMadre.IsNullable = true;
				colvarEstudiosMadre.IsPrimaryKey = false;
				colvarEstudiosMadre.IsForeignKey = false;
				colvarEstudiosMadre.IsReadOnly = false;
				colvarEstudiosMadre.DefaultSetting = @"";
				colvarEstudiosMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosMadre);
				
				TableSchema.TableColumn colvarAnioMayorNivelMadre = new TableSchema.TableColumn(schema);
				colvarAnioMayorNivelMadre.ColumnName = "anio_mayor_nivel_madre";
				colvarAnioMayorNivelMadre.DataType = DbType.Int32;
				colvarAnioMayorNivelMadre.MaxLength = 0;
				colvarAnioMayorNivelMadre.AutoIncrement = false;
				colvarAnioMayorNivelMadre.IsNullable = true;
				colvarAnioMayorNivelMadre.IsPrimaryKey = false;
				colvarAnioMayorNivelMadre.IsForeignKey = false;
				colvarAnioMayorNivelMadre.IsReadOnly = false;
				
						colvarAnioMayorNivelMadre.DefaultSetting = @"((0))";
				colvarAnioMayorNivelMadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnioMayorNivelMadre);
				
				TableSchema.TableColumn colvarTipoDocPadre = new TableSchema.TableColumn(schema);
				colvarTipoDocPadre.ColumnName = "tipo_doc_padre";
				colvarTipoDocPadre.DataType = DbType.AnsiString;
				colvarTipoDocPadre.MaxLength = 5;
				colvarTipoDocPadre.AutoIncrement = false;
				colvarTipoDocPadre.IsNullable = true;
				colvarTipoDocPadre.IsPrimaryKey = false;
				colvarTipoDocPadre.IsForeignKey = false;
				colvarTipoDocPadre.IsReadOnly = false;
				colvarTipoDocPadre.DefaultSetting = @"";
				colvarTipoDocPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocPadre);
				
				TableSchema.TableColumn colvarNroDocPadre = new TableSchema.TableColumn(schema);
				colvarNroDocPadre.ColumnName = "nro_doc_padre";
				colvarNroDocPadre.DataType = DbType.AnsiString;
				colvarNroDocPadre.MaxLength = 12;
				colvarNroDocPadre.AutoIncrement = false;
				colvarNroDocPadre.IsNullable = true;
				colvarNroDocPadre.IsPrimaryKey = false;
				colvarNroDocPadre.IsForeignKey = false;
				colvarNroDocPadre.IsReadOnly = false;
				colvarNroDocPadre.DefaultSetting = @"";
				colvarNroDocPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroDocPadre);
				
				TableSchema.TableColumn colvarApellidoPadre = new TableSchema.TableColumn(schema);
				colvarApellidoPadre.ColumnName = "apellido_padre";
				colvarApellidoPadre.DataType = DbType.AnsiString;
				colvarApellidoPadre.MaxLength = 50;
				colvarApellidoPadre.AutoIncrement = false;
				colvarApellidoPadre.IsNullable = true;
				colvarApellidoPadre.IsPrimaryKey = false;
				colvarApellidoPadre.IsForeignKey = false;
				colvarApellidoPadre.IsReadOnly = false;
				colvarApellidoPadre.DefaultSetting = @"";
				colvarApellidoPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoPadre);
				
				TableSchema.TableColumn colvarNombrePadre = new TableSchema.TableColumn(schema);
				colvarNombrePadre.ColumnName = "nombre_padre";
				colvarNombrePadre.DataType = DbType.AnsiString;
				colvarNombrePadre.MaxLength = 50;
				colvarNombrePadre.AutoIncrement = false;
				colvarNombrePadre.IsNullable = true;
				colvarNombrePadre.IsPrimaryKey = false;
				colvarNombrePadre.IsForeignKey = false;
				colvarNombrePadre.IsReadOnly = false;
				colvarNombrePadre.DefaultSetting = @"";
				colvarNombrePadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombrePadre);
				
				TableSchema.TableColumn colvarAlfabetaPadre = new TableSchema.TableColumn(schema);
				colvarAlfabetaPadre.ColumnName = "alfabeta_padre";
				colvarAlfabetaPadre.DataType = DbType.AnsiString;
				colvarAlfabetaPadre.MaxLength = 1;
				colvarAlfabetaPadre.AutoIncrement = false;
				colvarAlfabetaPadre.IsNullable = true;
				colvarAlfabetaPadre.IsPrimaryKey = false;
				colvarAlfabetaPadre.IsForeignKey = false;
				colvarAlfabetaPadre.IsReadOnly = false;
				colvarAlfabetaPadre.DefaultSetting = @"";
				colvarAlfabetaPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlfabetaPadre);
				
				TableSchema.TableColumn colvarEstudiosPadre = new TableSchema.TableColumn(schema);
				colvarEstudiosPadre.ColumnName = "estudios_padre";
				colvarEstudiosPadre.DataType = DbType.AnsiString;
				colvarEstudiosPadre.MaxLength = 1;
				colvarEstudiosPadre.AutoIncrement = false;
				colvarEstudiosPadre.IsNullable = true;
				colvarEstudiosPadre.IsPrimaryKey = false;
				colvarEstudiosPadre.IsForeignKey = false;
				colvarEstudiosPadre.IsReadOnly = false;
				colvarEstudiosPadre.DefaultSetting = @"";
				colvarEstudiosPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosPadre);
				
				TableSchema.TableColumn colvarAnioMayorNivelPadre = new TableSchema.TableColumn(schema);
				colvarAnioMayorNivelPadre.ColumnName = "anio_mayor_nivel_padre";
				colvarAnioMayorNivelPadre.DataType = DbType.Int32;
				colvarAnioMayorNivelPadre.MaxLength = 0;
				colvarAnioMayorNivelPadre.AutoIncrement = false;
				colvarAnioMayorNivelPadre.IsNullable = true;
				colvarAnioMayorNivelPadre.IsPrimaryKey = false;
				colvarAnioMayorNivelPadre.IsForeignKey = false;
				colvarAnioMayorNivelPadre.IsReadOnly = false;
				
						colvarAnioMayorNivelPadre.DefaultSetting = @"((0))";
				colvarAnioMayorNivelPadre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnioMayorNivelPadre);
				
				TableSchema.TableColumn colvarTipoDocTutor = new TableSchema.TableColumn(schema);
				colvarTipoDocTutor.ColumnName = "tipo_doc_tutor";
				colvarTipoDocTutor.DataType = DbType.AnsiString;
				colvarTipoDocTutor.MaxLength = 5;
				colvarTipoDocTutor.AutoIncrement = false;
				colvarTipoDocTutor.IsNullable = true;
				colvarTipoDocTutor.IsPrimaryKey = false;
				colvarTipoDocTutor.IsForeignKey = false;
				colvarTipoDocTutor.IsReadOnly = false;
				colvarTipoDocTutor.DefaultSetting = @"";
				colvarTipoDocTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocTutor);
				
				TableSchema.TableColumn colvarNroDocTutor = new TableSchema.TableColumn(schema);
				colvarNroDocTutor.ColumnName = "nro_doc_tutor";
				colvarNroDocTutor.DataType = DbType.AnsiString;
				colvarNroDocTutor.MaxLength = 12;
				colvarNroDocTutor.AutoIncrement = false;
				colvarNroDocTutor.IsNullable = true;
				colvarNroDocTutor.IsPrimaryKey = false;
				colvarNroDocTutor.IsForeignKey = false;
				colvarNroDocTutor.IsReadOnly = false;
				colvarNroDocTutor.DefaultSetting = @"";
				colvarNroDocTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroDocTutor);
				
				TableSchema.TableColumn colvarApellidoTutor = new TableSchema.TableColumn(schema);
				colvarApellidoTutor.ColumnName = "apellido_tutor";
				colvarApellidoTutor.DataType = DbType.AnsiString;
				colvarApellidoTutor.MaxLength = 50;
				colvarApellidoTutor.AutoIncrement = false;
				colvarApellidoTutor.IsNullable = true;
				colvarApellidoTutor.IsPrimaryKey = false;
				colvarApellidoTutor.IsForeignKey = false;
				colvarApellidoTutor.IsReadOnly = false;
				colvarApellidoTutor.DefaultSetting = @"";
				colvarApellidoTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellidoTutor);
				
				TableSchema.TableColumn colvarNombreTutor = new TableSchema.TableColumn(schema);
				colvarNombreTutor.ColumnName = "nombre_tutor";
				colvarNombreTutor.DataType = DbType.AnsiString;
				colvarNombreTutor.MaxLength = 50;
				colvarNombreTutor.AutoIncrement = false;
				colvarNombreTutor.IsNullable = true;
				colvarNombreTutor.IsPrimaryKey = false;
				colvarNombreTutor.IsForeignKey = false;
				colvarNombreTutor.IsReadOnly = false;
				colvarNombreTutor.DefaultSetting = @"";
				colvarNombreTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreTutor);
				
				TableSchema.TableColumn colvarAlfabetaTutor = new TableSchema.TableColumn(schema);
				colvarAlfabetaTutor.ColumnName = "alfabeta_tutor";
				colvarAlfabetaTutor.DataType = DbType.AnsiString;
				colvarAlfabetaTutor.MaxLength = 1;
				colvarAlfabetaTutor.AutoIncrement = false;
				colvarAlfabetaTutor.IsNullable = true;
				colvarAlfabetaTutor.IsPrimaryKey = false;
				colvarAlfabetaTutor.IsForeignKey = false;
				colvarAlfabetaTutor.IsReadOnly = false;
				colvarAlfabetaTutor.DefaultSetting = @"";
				colvarAlfabetaTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlfabetaTutor);
				
				TableSchema.TableColumn colvarEstudiosTutor = new TableSchema.TableColumn(schema);
				colvarEstudiosTutor.ColumnName = "estudios_tutor";
				colvarEstudiosTutor.DataType = DbType.AnsiString;
				colvarEstudiosTutor.MaxLength = 1;
				colvarEstudiosTutor.AutoIncrement = false;
				colvarEstudiosTutor.IsNullable = true;
				colvarEstudiosTutor.IsPrimaryKey = false;
				colvarEstudiosTutor.IsForeignKey = false;
				colvarEstudiosTutor.IsReadOnly = false;
				colvarEstudiosTutor.DefaultSetting = @"";
				colvarEstudiosTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstudiosTutor);
				
				TableSchema.TableColumn colvarAnioMayorNivelTutor = new TableSchema.TableColumn(schema);
				colvarAnioMayorNivelTutor.ColumnName = "anio_mayor_nivel_tutor";
				colvarAnioMayorNivelTutor.DataType = DbType.Int32;
				colvarAnioMayorNivelTutor.MaxLength = 0;
				colvarAnioMayorNivelTutor.AutoIncrement = false;
				colvarAnioMayorNivelTutor.IsNullable = true;
				colvarAnioMayorNivelTutor.IsPrimaryKey = false;
				colvarAnioMayorNivelTutor.IsForeignKey = false;
				colvarAnioMayorNivelTutor.IsReadOnly = false;
				
						colvarAnioMayorNivelTutor.DefaultSetting = @"((0))";
				colvarAnioMayorNivelTutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnioMayorNivelTutor);
				
				TableSchema.TableColumn colvarFechaDiagnosticoEmbarazo = new TableSchema.TableColumn(schema);
				colvarFechaDiagnosticoEmbarazo.ColumnName = "fecha_diagnostico_embarazo";
				colvarFechaDiagnosticoEmbarazo.DataType = DbType.DateTime;
				colvarFechaDiagnosticoEmbarazo.MaxLength = 0;
				colvarFechaDiagnosticoEmbarazo.AutoIncrement = false;
				colvarFechaDiagnosticoEmbarazo.IsNullable = true;
				colvarFechaDiagnosticoEmbarazo.IsPrimaryKey = false;
				colvarFechaDiagnosticoEmbarazo.IsForeignKey = false;
				colvarFechaDiagnosticoEmbarazo.IsReadOnly = false;
				colvarFechaDiagnosticoEmbarazo.DefaultSetting = @"";
				colvarFechaDiagnosticoEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDiagnosticoEmbarazo);
				
				TableSchema.TableColumn colvarSemanasEmbarazo = new TableSchema.TableColumn(schema);
				colvarSemanasEmbarazo.ColumnName = "semanas_embarazo";
				colvarSemanasEmbarazo.DataType = DbType.Int32;
				colvarSemanasEmbarazo.MaxLength = 0;
				colvarSemanasEmbarazo.AutoIncrement = false;
				colvarSemanasEmbarazo.IsNullable = true;
				colvarSemanasEmbarazo.IsPrimaryKey = false;
				colvarSemanasEmbarazo.IsForeignKey = false;
				colvarSemanasEmbarazo.IsReadOnly = false;
				
						colvarSemanasEmbarazo.DefaultSetting = @"((0))";
				colvarSemanasEmbarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSemanasEmbarazo);
				
				TableSchema.TableColumn colvarFechaProbableParto = new TableSchema.TableColumn(schema);
				colvarFechaProbableParto.ColumnName = "fecha_probable_parto";
				colvarFechaProbableParto.DataType = DbType.DateTime;
				colvarFechaProbableParto.MaxLength = 0;
				colvarFechaProbableParto.AutoIncrement = false;
				colvarFechaProbableParto.IsNullable = true;
				colvarFechaProbableParto.IsPrimaryKey = false;
				colvarFechaProbableParto.IsForeignKey = false;
				colvarFechaProbableParto.IsReadOnly = false;
				colvarFechaProbableParto.DefaultSetting = @"";
				colvarFechaProbableParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaProbableParto);
				
				TableSchema.TableColumn colvarFechaEfectivaParto = new TableSchema.TableColumn(schema);
				colvarFechaEfectivaParto.ColumnName = "fecha_efectiva_parto";
				colvarFechaEfectivaParto.DataType = DbType.DateTime;
				colvarFechaEfectivaParto.MaxLength = 0;
				colvarFechaEfectivaParto.AutoIncrement = false;
				colvarFechaEfectivaParto.IsNullable = true;
				colvarFechaEfectivaParto.IsPrimaryKey = false;
				colvarFechaEfectivaParto.IsForeignKey = false;
				colvarFechaEfectivaParto.IsReadOnly = false;
				colvarFechaEfectivaParto.DefaultSetting = @"";
				colvarFechaEfectivaParto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEfectivaParto);
				
				TableSchema.TableColumn colvarCuieEa = new TableSchema.TableColumn(schema);
				colvarCuieEa.ColumnName = "cuie_ea";
				colvarCuieEa.DataType = DbType.AnsiString;
				colvarCuieEa.MaxLength = 10;
				colvarCuieEa.AutoIncrement = false;
				colvarCuieEa.IsNullable = true;
				colvarCuieEa.IsPrimaryKey = false;
				colvarCuieEa.IsForeignKey = false;
				colvarCuieEa.IsReadOnly = false;
				colvarCuieEa.DefaultSetting = @"";
				colvarCuieEa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuieEa);
				
				TableSchema.TableColumn colvarCuieAh = new TableSchema.TableColumn(schema);
				colvarCuieAh.ColumnName = "cuie_ah";
				colvarCuieAh.DataType = DbType.AnsiString;
				colvarCuieAh.MaxLength = 10;
				colvarCuieAh.AutoIncrement = false;
				colvarCuieAh.IsNullable = true;
				colvarCuieAh.IsPrimaryKey = false;
				colvarCuieAh.IsForeignKey = false;
				colvarCuieAh.IsReadOnly = false;
				colvarCuieAh.DefaultSetting = @"";
				colvarCuieAh.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuieAh);
				
				TableSchema.TableColumn colvarMenorConviveConAdulto = new TableSchema.TableColumn(schema);
				colvarMenorConviveConAdulto.ColumnName = "menor_convive_con_adulto";
				colvarMenorConviveConAdulto.DataType = DbType.AnsiString;
				colvarMenorConviveConAdulto.MaxLength = 1;
				colvarMenorConviveConAdulto.AutoIncrement = false;
				colvarMenorConviveConAdulto.IsNullable = true;
				colvarMenorConviveConAdulto.IsPrimaryKey = false;
				colvarMenorConviveConAdulto.IsForeignKey = false;
				colvarMenorConviveConAdulto.IsReadOnly = false;
				colvarMenorConviveConAdulto.DefaultSetting = @"";
				colvarMenorConviveConAdulto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMenorConviveConAdulto);
				
				TableSchema.TableColumn colvarCalle = new TableSchema.TableColumn(schema);
				colvarCalle.ColumnName = "calle";
				colvarCalle.DataType = DbType.AnsiString;
				colvarCalle.MaxLength = 40;
				colvarCalle.AutoIncrement = false;
				colvarCalle.IsNullable = true;
				colvarCalle.IsPrimaryKey = false;
				colvarCalle.IsForeignKey = false;
				colvarCalle.IsReadOnly = false;
				colvarCalle.DefaultSetting = @"";
				colvarCalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCalle);
				
				TableSchema.TableColumn colvarNumeroCalle = new TableSchema.TableColumn(schema);
				colvarNumeroCalle.ColumnName = "numero_calle";
				colvarNumeroCalle.DataType = DbType.AnsiString;
				colvarNumeroCalle.MaxLength = 5;
				colvarNumeroCalle.AutoIncrement = false;
				colvarNumeroCalle.IsNullable = true;
				colvarNumeroCalle.IsPrimaryKey = false;
				colvarNumeroCalle.IsForeignKey = false;
				colvarNumeroCalle.IsReadOnly = false;
				colvarNumeroCalle.DefaultSetting = @"";
				colvarNumeroCalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroCalle);
				
				TableSchema.TableColumn colvarPiso = new TableSchema.TableColumn(schema);
				colvarPiso.ColumnName = "piso";
				colvarPiso.DataType = DbType.AnsiString;
				colvarPiso.MaxLength = 2;
				colvarPiso.AutoIncrement = false;
				colvarPiso.IsNullable = true;
				colvarPiso.IsPrimaryKey = false;
				colvarPiso.IsForeignKey = false;
				colvarPiso.IsReadOnly = false;
				colvarPiso.DefaultSetting = @"";
				colvarPiso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPiso);
				
				TableSchema.TableColumn colvarDpto = new TableSchema.TableColumn(schema);
				colvarDpto.ColumnName = "dpto";
				colvarDpto.DataType = DbType.AnsiString;
				colvarDpto.MaxLength = 3;
				colvarDpto.AutoIncrement = false;
				colvarDpto.IsNullable = true;
				colvarDpto.IsPrimaryKey = false;
				colvarDpto.IsForeignKey = false;
				colvarDpto.IsReadOnly = false;
				colvarDpto.DefaultSetting = @"";
				colvarDpto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDpto);
				
				TableSchema.TableColumn colvarManzana = new TableSchema.TableColumn(schema);
				colvarManzana.ColumnName = "manzana";
				colvarManzana.DataType = DbType.AnsiString;
				colvarManzana.MaxLength = 30;
				colvarManzana.AutoIncrement = false;
				colvarManzana.IsNullable = true;
				colvarManzana.IsPrimaryKey = false;
				colvarManzana.IsForeignKey = false;
				colvarManzana.IsReadOnly = false;
				colvarManzana.DefaultSetting = @"";
				colvarManzana.ForeignKeyTableName = "";
				schema.Columns.Add(colvarManzana);
				
				TableSchema.TableColumn colvarEntreCalle1 = new TableSchema.TableColumn(schema);
				colvarEntreCalle1.ColumnName = "entre_calle_1";
				colvarEntreCalle1.DataType = DbType.AnsiString;
				colvarEntreCalle1.MaxLength = 40;
				colvarEntreCalle1.AutoIncrement = false;
				colvarEntreCalle1.IsNullable = true;
				colvarEntreCalle1.IsPrimaryKey = false;
				colvarEntreCalle1.IsForeignKey = false;
				colvarEntreCalle1.IsReadOnly = false;
				colvarEntreCalle1.DefaultSetting = @"";
				colvarEntreCalle1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEntreCalle1);
				
				TableSchema.TableColumn colvarEntreCalle2 = new TableSchema.TableColumn(schema);
				colvarEntreCalle2.ColumnName = "entre_calle_2";
				colvarEntreCalle2.DataType = DbType.AnsiString;
				colvarEntreCalle2.MaxLength = 40;
				colvarEntreCalle2.AutoIncrement = false;
				colvarEntreCalle2.IsNullable = true;
				colvarEntreCalle2.IsPrimaryKey = false;
				colvarEntreCalle2.IsForeignKey = false;
				colvarEntreCalle2.IsReadOnly = false;
				colvarEntreCalle2.DefaultSetting = @"";
				colvarEntreCalle2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEntreCalle2);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = 40;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarDepartamento = new TableSchema.TableColumn(schema);
				colvarDepartamento.ColumnName = "departamento";
				colvarDepartamento.DataType = DbType.AnsiString;
				colvarDepartamento.MaxLength = 40;
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
				colvarLocalidad.DataType = DbType.AnsiString;
				colvarLocalidad.MaxLength = 40;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarMunicipio = new TableSchema.TableColumn(schema);
				colvarMunicipio.ColumnName = "municipio";
				colvarMunicipio.DataType = DbType.AnsiString;
				colvarMunicipio.MaxLength = 40;
				colvarMunicipio.AutoIncrement = false;
				colvarMunicipio.IsNullable = true;
				colvarMunicipio.IsPrimaryKey = false;
				colvarMunicipio.IsForeignKey = false;
				colvarMunicipio.IsReadOnly = false;
				colvarMunicipio.DefaultSetting = @"";
				colvarMunicipio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMunicipio);
				
				TableSchema.TableColumn colvarBarrio = new TableSchema.TableColumn(schema);
				colvarBarrio.ColumnName = "barrio";
				colvarBarrio.DataType = DbType.AnsiString;
				colvarBarrio.MaxLength = 40;
				colvarBarrio.AutoIncrement = false;
				colvarBarrio.IsNullable = true;
				colvarBarrio.IsPrimaryKey = false;
				colvarBarrio.IsForeignKey = false;
				colvarBarrio.IsReadOnly = false;
				colvarBarrio.DefaultSetting = @"";
				colvarBarrio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBarrio);
				
				TableSchema.TableColumn colvarCodPos = new TableSchema.TableColumn(schema);
				colvarCodPos.ColumnName = "cod_pos";
				colvarCodPos.DataType = DbType.AnsiString;
				colvarCodPos.MaxLength = 11;
				colvarCodPos.AutoIncrement = false;
				colvarCodPos.IsNullable = true;
				colvarCodPos.IsPrimaryKey = false;
				colvarCodPos.IsForeignKey = false;
				colvarCodPos.IsReadOnly = false;
				colvarCodPos.DefaultSetting = @"";
				colvarCodPos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodPos);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 100;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarFechaInscripcion = new TableSchema.TableColumn(schema);
				colvarFechaInscripcion.ColumnName = "fecha_inscripcion";
				colvarFechaInscripcion.DataType = DbType.DateTime;
				colvarFechaInscripcion.MaxLength = 0;
				colvarFechaInscripcion.AutoIncrement = false;
				colvarFechaInscripcion.IsNullable = true;
				colvarFechaInscripcion.IsPrimaryKey = false;
				colvarFechaInscripcion.IsForeignKey = false;
				colvarFechaInscripcion.IsReadOnly = false;
				colvarFechaInscripcion.DefaultSetting = @"";
				colvarFechaInscripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaInscripcion);
				
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
				
				TableSchema.TableColumn colvarUsuarioCarga = new TableSchema.TableColumn(schema);
				colvarUsuarioCarga.ColumnName = "usuario_carga";
				colvarUsuarioCarga.DataType = DbType.AnsiString;
				colvarUsuarioCarga.MaxLength = 10;
				colvarUsuarioCarga.AutoIncrement = false;
				colvarUsuarioCarga.IsNullable = true;
				colvarUsuarioCarga.IsPrimaryKey = false;
				colvarUsuarioCarga.IsForeignKey = false;
				colvarUsuarioCarga.IsReadOnly = false;
				colvarUsuarioCarga.DefaultSetting = @"";
				colvarUsuarioCarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioCarga);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.AnsiString;
				colvarActivo.MaxLength = 1;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = true;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarTipoFicha = new TableSchema.TableColumn(schema);
				colvarTipoFicha.ColumnName = "tipo_ficha";
				colvarTipoFicha.DataType = DbType.Int32;
				colvarTipoFicha.MaxLength = 0;
				colvarTipoFicha.AutoIncrement = false;
				colvarTipoFicha.IsNullable = true;
				colvarTipoFicha.IsPrimaryKey = false;
				colvarTipoFicha.IsForeignKey = false;
				colvarTipoFicha.IsReadOnly = false;
				colvarTipoFicha.DefaultSetting = @"";
				colvarTipoFicha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoFicha);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "responsable";
				colvarResponsable.DataType = DbType.AnsiString;
				colvarResponsable.MaxLength = 50;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = true;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				TableSchema.TableColumn colvarFum = new TableSchema.TableColumn(schema);
				colvarFum.ColumnName = "fum";
				colvarFum.DataType = DbType.DateTime;
				colvarFum.MaxLength = 0;
				colvarFum.AutoIncrement = false;
				colvarFum.IsNullable = true;
				colvarFum.IsPrimaryKey = false;
				colvarFum.IsForeignKey = false;
				colvarFum.IsReadOnly = false;
				colvarFum.DefaultSetting = @"";
				colvarFum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFum);
				
				TableSchema.TableColumn colvarRcv = new TableSchema.TableColumn(schema);
				colvarRcv.ColumnName = "rcv";
				colvarRcv.DataType = DbType.AnsiString;
				colvarRcv.MaxLength = 50;
				colvarRcv.AutoIncrement = false;
				colvarRcv.IsNullable = true;
				colvarRcv.IsPrimaryKey = false;
				colvarRcv.IsForeignKey = false;
				colvarRcv.IsReadOnly = false;
				colvarRcv.DefaultSetting = @"";
				colvarRcv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRcv);
				
				TableSchema.TableColumn colvarDiscv = new TableSchema.TableColumn(schema);
				colvarDiscv.ColumnName = "discv";
				colvarDiscv.DataType = DbType.AnsiString;
				colvarDiscv.MaxLength = 50;
				colvarDiscv.AutoIncrement = false;
				colvarDiscv.IsNullable = true;
				colvarDiscv.IsPrimaryKey = false;
				colvarDiscv.IsForeignKey = false;
				colvarDiscv.IsReadOnly = false;
				colvarDiscv.DefaultSetting = @"";
				colvarDiscv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscv);
				
				TableSchema.TableColumn colvarDisca = new TableSchema.TableColumn(schema);
				colvarDisca.ColumnName = "disca";
				colvarDisca.DataType = DbType.AnsiString;
				colvarDisca.MaxLength = 50;
				colvarDisca.AutoIncrement = false;
				colvarDisca.IsNullable = true;
				colvarDisca.IsPrimaryKey = false;
				colvarDisca.IsForeignKey = false;
				colvarDisca.IsReadOnly = false;
				colvarDisca.DefaultSetting = @"";
				colvarDisca.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDisca);
				
				TableSchema.TableColumn colvarDiscmo = new TableSchema.TableColumn(schema);
				colvarDiscmo.ColumnName = "discmo";
				colvarDiscmo.DataType = DbType.AnsiString;
				colvarDiscmo.MaxLength = 50;
				colvarDiscmo.AutoIncrement = false;
				colvarDiscmo.IsNullable = true;
				colvarDiscmo.IsPrimaryKey = false;
				colvarDiscmo.IsForeignKey = false;
				colvarDiscmo.IsReadOnly = false;
				colvarDiscmo.DefaultSetting = @"";
				colvarDiscmo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscmo);
				
				TableSchema.TableColumn colvarDiscme = new TableSchema.TableColumn(schema);
				colvarDiscme.ColumnName = "discme";
				colvarDiscme.DataType = DbType.AnsiString;
				colvarDiscme.MaxLength = 50;
				colvarDiscme.AutoIncrement = false;
				colvarDiscme.IsNullable = true;
				colvarDiscme.IsPrimaryKey = false;
				colvarDiscme.IsForeignKey = false;
				colvarDiscme.IsReadOnly = false;
				colvarDiscme.DefaultSetting = @"";
				colvarDiscme.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscme);
				
				TableSchema.TableColumn colvarOtradisc = new TableSchema.TableColumn(schema);
				colvarOtradisc.ColumnName = "otradisc";
				colvarOtradisc.DataType = DbType.AnsiString;
				colvarOtradisc.MaxLength = 50;
				colvarOtradisc.AutoIncrement = false;
				colvarOtradisc.IsNullable = true;
				colvarOtradisc.IsPrimaryKey = false;
				colvarOtradisc.IsForeignKey = false;
				colvarOtradisc.IsReadOnly = false;
				colvarOtradisc.DefaultSetting = @"";
				colvarOtradisc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtradisc);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_beneficiarios",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdBeneficiarios")]
		[Bindable(true)]
		public int IdBeneficiarios 
		{
			get { return GetColumnValue<int>(Columns.IdBeneficiarios); }
			set { SetColumnValue(Columns.IdBeneficiarios, value); }
		}
		  
		[XmlAttribute("EstadoEnvio")]
		[Bindable(true)]
		public string EstadoEnvio 
		{
			get { return GetColumnValue<string>(Columns.EstadoEnvio); }
			set { SetColumnValue(Columns.EstadoEnvio, value); }
		}
		  
		[XmlAttribute("ClaveBeneficiario")]
		[Bindable(true)]
		public string ClaveBeneficiario 
		{
			get { return GetColumnValue<string>(Columns.ClaveBeneficiario); }
			set { SetColumnValue(Columns.ClaveBeneficiario, value); }
		}
		  
		[XmlAttribute("TipoTransaccion")]
		[Bindable(true)]
		public string TipoTransaccion 
		{
			get { return GetColumnValue<string>(Columns.TipoTransaccion); }
			set { SetColumnValue(Columns.TipoTransaccion, value); }
		}
		  
		[XmlAttribute("ApellidoBenef")]
		[Bindable(true)]
		public string ApellidoBenef 
		{
			get { return GetColumnValue<string>(Columns.ApellidoBenef); }
			set { SetColumnValue(Columns.ApellidoBenef, value); }
		}
		  
		[XmlAttribute("NombreBenef")]
		[Bindable(true)]
		public string NombreBenef 
		{
			get { return GetColumnValue<string>(Columns.NombreBenef); }
			set { SetColumnValue(Columns.NombreBenef, value); }
		}
		  
		[XmlAttribute("ClaseDocumentoBenef")]
		[Bindable(true)]
		public string ClaseDocumentoBenef 
		{
			get { return GetColumnValue<string>(Columns.ClaseDocumentoBenef); }
			set { SetColumnValue(Columns.ClaseDocumentoBenef, value); }
		}
		  
		[XmlAttribute("TipoDocumento")]
		[Bindable(true)]
		public string TipoDocumento 
		{
			get { return GetColumnValue<string>(Columns.TipoDocumento); }
			set { SetColumnValue(Columns.TipoDocumento, value); }
		}
		  
		[XmlAttribute("NumeroDoc")]
		[Bindable(true)]
		public string NumeroDoc 
		{
			get { return GetColumnValue<string>(Columns.NumeroDoc); }
			set { SetColumnValue(Columns.NumeroDoc, value); }
		}
		  
		[XmlAttribute("IdCategoria")]
		[Bindable(true)]
		public int IdCategoria 
		{
			get { return GetColumnValue<int>(Columns.IdCategoria); }
			set { SetColumnValue(Columns.IdCategoria, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("FechaNacimientoBenef")]
		[Bindable(true)]
		public DateTime? FechaNacimientoBenef 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimientoBenef); }
			set { SetColumnValue(Columns.FechaNacimientoBenef, value); }
		}
		  
		[XmlAttribute("ProvinciaNac")]
		[Bindable(true)]
		public string ProvinciaNac 
		{
			get { return GetColumnValue<string>(Columns.ProvinciaNac); }
			set { SetColumnValue(Columns.ProvinciaNac, value); }
		}
		  
		[XmlAttribute("LocalidadNac")]
		[Bindable(true)]
		public string LocalidadNac 
		{
			get { return GetColumnValue<string>(Columns.LocalidadNac); }
			set { SetColumnValue(Columns.LocalidadNac, value); }
		}
		  
		[XmlAttribute("PaisNac")]
		[Bindable(true)]
		public string PaisNac 
		{
			get { return GetColumnValue<string>(Columns.PaisNac); }
			set { SetColumnValue(Columns.PaisNac, value); }
		}
		  
		[XmlAttribute("Indigena")]
		[Bindable(true)]
		public string Indigena 
		{
			get { return GetColumnValue<string>(Columns.Indigena); }
			set { SetColumnValue(Columns.Indigena, value); }
		}
		  
		[XmlAttribute("IdTribu")]
		[Bindable(true)]
		public int IdTribu 
		{
			get { return GetColumnValue<int>(Columns.IdTribu); }
			set { SetColumnValue(Columns.IdTribu, value); }
		}
		  
		[XmlAttribute("IdLengua")]
		[Bindable(true)]
		public int IdLengua 
		{
			get { return GetColumnValue<int>(Columns.IdLengua); }
			set { SetColumnValue(Columns.IdLengua, value); }
		}
		  
		[XmlAttribute("Alfabeta")]
		[Bindable(true)]
		public string Alfabeta 
		{
			get { return GetColumnValue<string>(Columns.Alfabeta); }
			set { SetColumnValue(Columns.Alfabeta, value); }
		}
		  
		[XmlAttribute("Estudios")]
		[Bindable(true)]
		public string Estudios 
		{
			get { return GetColumnValue<string>(Columns.Estudios); }
			set { SetColumnValue(Columns.Estudios, value); }
		}
		  
		[XmlAttribute("AnioMayorNivel")]
		[Bindable(true)]
		public int? AnioMayorNivel 
		{
			get { return GetColumnValue<int?>(Columns.AnioMayorNivel); }
			set { SetColumnValue(Columns.AnioMayorNivel, value); }
		}
		  
		[XmlAttribute("TipoDocMadre")]
		[Bindable(true)]
		public string TipoDocMadre 
		{
			get { return GetColumnValue<string>(Columns.TipoDocMadre); }
			set { SetColumnValue(Columns.TipoDocMadre, value); }
		}
		  
		[XmlAttribute("NroDocMadre")]
		[Bindable(true)]
		public string NroDocMadre 
		{
			get { return GetColumnValue<string>(Columns.NroDocMadre); }
			set { SetColumnValue(Columns.NroDocMadre, value); }
		}
		  
		[XmlAttribute("ApellidoMadre")]
		[Bindable(true)]
		public string ApellidoMadre 
		{
			get { return GetColumnValue<string>(Columns.ApellidoMadre); }
			set { SetColumnValue(Columns.ApellidoMadre, value); }
		}
		  
		[XmlAttribute("NombreMadre")]
		[Bindable(true)]
		public string NombreMadre 
		{
			get { return GetColumnValue<string>(Columns.NombreMadre); }
			set { SetColumnValue(Columns.NombreMadre, value); }
		}
		  
		[XmlAttribute("AlfabetaMadre")]
		[Bindable(true)]
		public string AlfabetaMadre 
		{
			get { return GetColumnValue<string>(Columns.AlfabetaMadre); }
			set { SetColumnValue(Columns.AlfabetaMadre, value); }
		}
		  
		[XmlAttribute("EstudiosMadre")]
		[Bindable(true)]
		public string EstudiosMadre 
		{
			get { return GetColumnValue<string>(Columns.EstudiosMadre); }
			set { SetColumnValue(Columns.EstudiosMadre, value); }
		}
		  
		[XmlAttribute("AnioMayorNivelMadre")]
		[Bindable(true)]
		public int? AnioMayorNivelMadre 
		{
			get { return GetColumnValue<int?>(Columns.AnioMayorNivelMadre); }
			set { SetColumnValue(Columns.AnioMayorNivelMadre, value); }
		}
		  
		[XmlAttribute("TipoDocPadre")]
		[Bindable(true)]
		public string TipoDocPadre 
		{
			get { return GetColumnValue<string>(Columns.TipoDocPadre); }
			set { SetColumnValue(Columns.TipoDocPadre, value); }
		}
		  
		[XmlAttribute("NroDocPadre")]
		[Bindable(true)]
		public string NroDocPadre 
		{
			get { return GetColumnValue<string>(Columns.NroDocPadre); }
			set { SetColumnValue(Columns.NroDocPadre, value); }
		}
		  
		[XmlAttribute("ApellidoPadre")]
		[Bindable(true)]
		public string ApellidoPadre 
		{
			get { return GetColumnValue<string>(Columns.ApellidoPadre); }
			set { SetColumnValue(Columns.ApellidoPadre, value); }
		}
		  
		[XmlAttribute("NombrePadre")]
		[Bindable(true)]
		public string NombrePadre 
		{
			get { return GetColumnValue<string>(Columns.NombrePadre); }
			set { SetColumnValue(Columns.NombrePadre, value); }
		}
		  
		[XmlAttribute("AlfabetaPadre")]
		[Bindable(true)]
		public string AlfabetaPadre 
		{
			get { return GetColumnValue<string>(Columns.AlfabetaPadre); }
			set { SetColumnValue(Columns.AlfabetaPadre, value); }
		}
		  
		[XmlAttribute("EstudiosPadre")]
		[Bindable(true)]
		public string EstudiosPadre 
		{
			get { return GetColumnValue<string>(Columns.EstudiosPadre); }
			set { SetColumnValue(Columns.EstudiosPadre, value); }
		}
		  
		[XmlAttribute("AnioMayorNivelPadre")]
		[Bindable(true)]
		public int? AnioMayorNivelPadre 
		{
			get { return GetColumnValue<int?>(Columns.AnioMayorNivelPadre); }
			set { SetColumnValue(Columns.AnioMayorNivelPadre, value); }
		}
		  
		[XmlAttribute("TipoDocTutor")]
		[Bindable(true)]
		public string TipoDocTutor 
		{
			get { return GetColumnValue<string>(Columns.TipoDocTutor); }
			set { SetColumnValue(Columns.TipoDocTutor, value); }
		}
		  
		[XmlAttribute("NroDocTutor")]
		[Bindable(true)]
		public string NroDocTutor 
		{
			get { return GetColumnValue<string>(Columns.NroDocTutor); }
			set { SetColumnValue(Columns.NroDocTutor, value); }
		}
		  
		[XmlAttribute("ApellidoTutor")]
		[Bindable(true)]
		public string ApellidoTutor 
		{
			get { return GetColumnValue<string>(Columns.ApellidoTutor); }
			set { SetColumnValue(Columns.ApellidoTutor, value); }
		}
		  
		[XmlAttribute("NombreTutor")]
		[Bindable(true)]
		public string NombreTutor 
		{
			get { return GetColumnValue<string>(Columns.NombreTutor); }
			set { SetColumnValue(Columns.NombreTutor, value); }
		}
		  
		[XmlAttribute("AlfabetaTutor")]
		[Bindable(true)]
		public string AlfabetaTutor 
		{
			get { return GetColumnValue<string>(Columns.AlfabetaTutor); }
			set { SetColumnValue(Columns.AlfabetaTutor, value); }
		}
		  
		[XmlAttribute("EstudiosTutor")]
		[Bindable(true)]
		public string EstudiosTutor 
		{
			get { return GetColumnValue<string>(Columns.EstudiosTutor); }
			set { SetColumnValue(Columns.EstudiosTutor, value); }
		}
		  
		[XmlAttribute("AnioMayorNivelTutor")]
		[Bindable(true)]
		public int? AnioMayorNivelTutor 
		{
			get { return GetColumnValue<int?>(Columns.AnioMayorNivelTutor); }
			set { SetColumnValue(Columns.AnioMayorNivelTutor, value); }
		}
		  
		[XmlAttribute("FechaDiagnosticoEmbarazo")]
		[Bindable(true)]
		public DateTime? FechaDiagnosticoEmbarazo 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDiagnosticoEmbarazo); }
			set { SetColumnValue(Columns.FechaDiagnosticoEmbarazo, value); }
		}
		  
		[XmlAttribute("SemanasEmbarazo")]
		[Bindable(true)]
		public int? SemanasEmbarazo 
		{
			get { return GetColumnValue<int?>(Columns.SemanasEmbarazo); }
			set { SetColumnValue(Columns.SemanasEmbarazo, value); }
		}
		  
		[XmlAttribute("FechaProbableParto")]
		[Bindable(true)]
		public DateTime? FechaProbableParto 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaProbableParto); }
			set { SetColumnValue(Columns.FechaProbableParto, value); }
		}
		  
		[XmlAttribute("FechaEfectivaParto")]
		[Bindable(true)]
		public DateTime? FechaEfectivaParto 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEfectivaParto); }
			set { SetColumnValue(Columns.FechaEfectivaParto, value); }
		}
		  
		[XmlAttribute("CuieEa")]
		[Bindable(true)]
		public string CuieEa 
		{
			get { return GetColumnValue<string>(Columns.CuieEa); }
			set { SetColumnValue(Columns.CuieEa, value); }
		}
		  
		[XmlAttribute("CuieAh")]
		[Bindable(true)]
		public string CuieAh 
		{
			get { return GetColumnValue<string>(Columns.CuieAh); }
			set { SetColumnValue(Columns.CuieAh, value); }
		}
		  
		[XmlAttribute("MenorConviveConAdulto")]
		[Bindable(true)]
		public string MenorConviveConAdulto 
		{
			get { return GetColumnValue<string>(Columns.MenorConviveConAdulto); }
			set { SetColumnValue(Columns.MenorConviveConAdulto, value); }
		}
		  
		[XmlAttribute("Calle")]
		[Bindable(true)]
		public string Calle 
		{
			get { return GetColumnValue<string>(Columns.Calle); }
			set { SetColumnValue(Columns.Calle, value); }
		}
		  
		[XmlAttribute("NumeroCalle")]
		[Bindable(true)]
		public string NumeroCalle 
		{
			get { return GetColumnValue<string>(Columns.NumeroCalle); }
			set { SetColumnValue(Columns.NumeroCalle, value); }
		}
		  
		[XmlAttribute("Piso")]
		[Bindable(true)]
		public string Piso 
		{
			get { return GetColumnValue<string>(Columns.Piso); }
			set { SetColumnValue(Columns.Piso, value); }
		}
		  
		[XmlAttribute("Dpto")]
		[Bindable(true)]
		public string Dpto 
		{
			get { return GetColumnValue<string>(Columns.Dpto); }
			set { SetColumnValue(Columns.Dpto, value); }
		}
		  
		[XmlAttribute("Manzana")]
		[Bindable(true)]
		public string Manzana 
		{
			get { return GetColumnValue<string>(Columns.Manzana); }
			set { SetColumnValue(Columns.Manzana, value); }
		}
		  
		[XmlAttribute("EntreCalle1")]
		[Bindable(true)]
		public string EntreCalle1 
		{
			get { return GetColumnValue<string>(Columns.EntreCalle1); }
			set { SetColumnValue(Columns.EntreCalle1, value); }
		}
		  
		[XmlAttribute("EntreCalle2")]
		[Bindable(true)]
		public string EntreCalle2 
		{
			get { return GetColumnValue<string>(Columns.EntreCalle2); }
			set { SetColumnValue(Columns.EntreCalle2, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
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
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("Municipio")]
		[Bindable(true)]
		public string Municipio 
		{
			get { return GetColumnValue<string>(Columns.Municipio); }
			set { SetColumnValue(Columns.Municipio, value); }
		}
		  
		[XmlAttribute("Barrio")]
		[Bindable(true)]
		public string Barrio 
		{
			get { return GetColumnValue<string>(Columns.Barrio); }
			set { SetColumnValue(Columns.Barrio, value); }
		}
		  
		[XmlAttribute("CodPos")]
		[Bindable(true)]
		public string CodPos 
		{
			get { return GetColumnValue<string>(Columns.CodPos); }
			set { SetColumnValue(Columns.CodPos, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("FechaInscripcion")]
		[Bindable(true)]
		public DateTime? FechaInscripcion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaInscripcion); }
			set { SetColumnValue(Columns.FechaInscripcion, value); }
		}
		  
		[XmlAttribute("FechaCarga")]
		[Bindable(true)]
		public DateTime? FechaCarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaCarga); }
			set { SetColumnValue(Columns.FechaCarga, value); }
		}
		  
		[XmlAttribute("UsuarioCarga")]
		[Bindable(true)]
		public string UsuarioCarga 
		{
			get { return GetColumnValue<string>(Columns.UsuarioCarga); }
			set { SetColumnValue(Columns.UsuarioCarga, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public string Activo 
		{
			get { return GetColumnValue<string>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("TipoFicha")]
		[Bindable(true)]
		public int? TipoFicha 
		{
			get { return GetColumnValue<int?>(Columns.TipoFicha); }
			set { SetColumnValue(Columns.TipoFicha, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		  
		[XmlAttribute("Fum")]
		[Bindable(true)]
		public DateTime? Fum 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fum); }
			set { SetColumnValue(Columns.Fum, value); }
		}
		  
		[XmlAttribute("Rcv")]
		[Bindable(true)]
		public string Rcv 
		{
			get { return GetColumnValue<string>(Columns.Rcv); }
			set { SetColumnValue(Columns.Rcv, value); }
		}
		  
		[XmlAttribute("Discv")]
		[Bindable(true)]
		public string Discv 
		{
			get { return GetColumnValue<string>(Columns.Discv); }
			set { SetColumnValue(Columns.Discv, value); }
		}
		  
		[XmlAttribute("Disca")]
		[Bindable(true)]
		public string Disca 
		{
			get { return GetColumnValue<string>(Columns.Disca); }
			set { SetColumnValue(Columns.Disca, value); }
		}
		  
		[XmlAttribute("Discmo")]
		[Bindable(true)]
		public string Discmo 
		{
			get { return GetColumnValue<string>(Columns.Discmo); }
			set { SetColumnValue(Columns.Discmo, value); }
		}
		  
		[XmlAttribute("Discme")]
		[Bindable(true)]
		public string Discme 
		{
			get { return GetColumnValue<string>(Columns.Discme); }
			set { SetColumnValue(Columns.Discme, value); }
		}
		  
		[XmlAttribute("Otradisc")]
		[Bindable(true)]
		public string Otradisc 
		{
			get { return GetColumnValue<string>(Columns.Otradisc); }
			set { SetColumnValue(Columns.Otradisc, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varEstadoEnvio,string varClaveBeneficiario,string varTipoTransaccion,string varApellidoBenef,string varNombreBenef,string varClaseDocumentoBenef,string varTipoDocumento,string varNumeroDoc,int varIdCategoria,string varSexo,DateTime? varFechaNacimientoBenef,string varProvinciaNac,string varLocalidadNac,string varPaisNac,string varIndigena,int varIdTribu,int varIdLengua,string varAlfabeta,string varEstudios,int? varAnioMayorNivel,string varTipoDocMadre,string varNroDocMadre,string varApellidoMadre,string varNombreMadre,string varAlfabetaMadre,string varEstudiosMadre,int? varAnioMayorNivelMadre,string varTipoDocPadre,string varNroDocPadre,string varApellidoPadre,string varNombrePadre,string varAlfabetaPadre,string varEstudiosPadre,int? varAnioMayorNivelPadre,string varTipoDocTutor,string varNroDocTutor,string varApellidoTutor,string varNombreTutor,string varAlfabetaTutor,string varEstudiosTutor,int? varAnioMayorNivelTutor,DateTime? varFechaDiagnosticoEmbarazo,int? varSemanasEmbarazo,DateTime? varFechaProbableParto,DateTime? varFechaEfectivaParto,string varCuieEa,string varCuieAh,string varMenorConviveConAdulto,string varCalle,string varNumeroCalle,string varPiso,string varDpto,string varManzana,string varEntreCalle1,string varEntreCalle2,string varTelefono,string varDepartamento,string varLocalidad,string varMunicipio,string varBarrio,string varCodPos,string varObservaciones,DateTime? varFechaInscripcion,DateTime? varFechaCarga,string varUsuarioCarga,string varActivo,int? varTipoFicha,string varResponsable,DateTime? varFum,string varRcv,string varDiscv,string varDisca,string varDiscmo,string varDiscme,string varOtradisc)
		{
			PnBeneficiario item = new PnBeneficiario();
			
			item.EstadoEnvio = varEstadoEnvio;
			
			item.ClaveBeneficiario = varClaveBeneficiario;
			
			item.TipoTransaccion = varTipoTransaccion;
			
			item.ApellidoBenef = varApellidoBenef;
			
			item.NombreBenef = varNombreBenef;
			
			item.ClaseDocumentoBenef = varClaseDocumentoBenef;
			
			item.TipoDocumento = varTipoDocumento;
			
			item.NumeroDoc = varNumeroDoc;
			
			item.IdCategoria = varIdCategoria;
			
			item.Sexo = varSexo;
			
			item.FechaNacimientoBenef = varFechaNacimientoBenef;
			
			item.ProvinciaNac = varProvinciaNac;
			
			item.LocalidadNac = varLocalidadNac;
			
			item.PaisNac = varPaisNac;
			
			item.Indigena = varIndigena;
			
			item.IdTribu = varIdTribu;
			
			item.IdLengua = varIdLengua;
			
			item.Alfabeta = varAlfabeta;
			
			item.Estudios = varEstudios;
			
			item.AnioMayorNivel = varAnioMayorNivel;
			
			item.TipoDocMadre = varTipoDocMadre;
			
			item.NroDocMadre = varNroDocMadre;
			
			item.ApellidoMadre = varApellidoMadre;
			
			item.NombreMadre = varNombreMadre;
			
			item.AlfabetaMadre = varAlfabetaMadre;
			
			item.EstudiosMadre = varEstudiosMadre;
			
			item.AnioMayorNivelMadre = varAnioMayorNivelMadre;
			
			item.TipoDocPadre = varTipoDocPadre;
			
			item.NroDocPadre = varNroDocPadre;
			
			item.ApellidoPadre = varApellidoPadre;
			
			item.NombrePadre = varNombrePadre;
			
			item.AlfabetaPadre = varAlfabetaPadre;
			
			item.EstudiosPadre = varEstudiosPadre;
			
			item.AnioMayorNivelPadre = varAnioMayorNivelPadre;
			
			item.TipoDocTutor = varTipoDocTutor;
			
			item.NroDocTutor = varNroDocTutor;
			
			item.ApellidoTutor = varApellidoTutor;
			
			item.NombreTutor = varNombreTutor;
			
			item.AlfabetaTutor = varAlfabetaTutor;
			
			item.EstudiosTutor = varEstudiosTutor;
			
			item.AnioMayorNivelTutor = varAnioMayorNivelTutor;
			
			item.FechaDiagnosticoEmbarazo = varFechaDiagnosticoEmbarazo;
			
			item.SemanasEmbarazo = varSemanasEmbarazo;
			
			item.FechaProbableParto = varFechaProbableParto;
			
			item.FechaEfectivaParto = varFechaEfectivaParto;
			
			item.CuieEa = varCuieEa;
			
			item.CuieAh = varCuieAh;
			
			item.MenorConviveConAdulto = varMenorConviveConAdulto;
			
			item.Calle = varCalle;
			
			item.NumeroCalle = varNumeroCalle;
			
			item.Piso = varPiso;
			
			item.Dpto = varDpto;
			
			item.Manzana = varManzana;
			
			item.EntreCalle1 = varEntreCalle1;
			
			item.EntreCalle2 = varEntreCalle2;
			
			item.Telefono = varTelefono;
			
			item.Departamento = varDepartamento;
			
			item.Localidad = varLocalidad;
			
			item.Municipio = varMunicipio;
			
			item.Barrio = varBarrio;
			
			item.CodPos = varCodPos;
			
			item.Observaciones = varObservaciones;
			
			item.FechaInscripcion = varFechaInscripcion;
			
			item.FechaCarga = varFechaCarga;
			
			item.UsuarioCarga = varUsuarioCarga;
			
			item.Activo = varActivo;
			
			item.TipoFicha = varTipoFicha;
			
			item.Responsable = varResponsable;
			
			item.Fum = varFum;
			
			item.Rcv = varRcv;
			
			item.Discv = varDiscv;
			
			item.Disca = varDisca;
			
			item.Discmo = varDiscmo;
			
			item.Discme = varDiscme;
			
			item.Otradisc = varOtradisc;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdBeneficiarios,string varEstadoEnvio,string varClaveBeneficiario,string varTipoTransaccion,string varApellidoBenef,string varNombreBenef,string varClaseDocumentoBenef,string varTipoDocumento,string varNumeroDoc,int varIdCategoria,string varSexo,DateTime? varFechaNacimientoBenef,string varProvinciaNac,string varLocalidadNac,string varPaisNac,string varIndigena,int varIdTribu,int varIdLengua,string varAlfabeta,string varEstudios,int? varAnioMayorNivel,string varTipoDocMadre,string varNroDocMadre,string varApellidoMadre,string varNombreMadre,string varAlfabetaMadre,string varEstudiosMadre,int? varAnioMayorNivelMadre,string varTipoDocPadre,string varNroDocPadre,string varApellidoPadre,string varNombrePadre,string varAlfabetaPadre,string varEstudiosPadre,int? varAnioMayorNivelPadre,string varTipoDocTutor,string varNroDocTutor,string varApellidoTutor,string varNombreTutor,string varAlfabetaTutor,string varEstudiosTutor,int? varAnioMayorNivelTutor,DateTime? varFechaDiagnosticoEmbarazo,int? varSemanasEmbarazo,DateTime? varFechaProbableParto,DateTime? varFechaEfectivaParto,string varCuieEa,string varCuieAh,string varMenorConviveConAdulto,string varCalle,string varNumeroCalle,string varPiso,string varDpto,string varManzana,string varEntreCalle1,string varEntreCalle2,string varTelefono,string varDepartamento,string varLocalidad,string varMunicipio,string varBarrio,string varCodPos,string varObservaciones,DateTime? varFechaInscripcion,DateTime? varFechaCarga,string varUsuarioCarga,string varActivo,int? varTipoFicha,string varResponsable,DateTime? varFum,string varRcv,string varDiscv,string varDisca,string varDiscmo,string varDiscme,string varOtradisc)
		{
			PnBeneficiario item = new PnBeneficiario();
			
				item.IdBeneficiarios = varIdBeneficiarios;
			
				item.EstadoEnvio = varEstadoEnvio;
			
				item.ClaveBeneficiario = varClaveBeneficiario;
			
				item.TipoTransaccion = varTipoTransaccion;
			
				item.ApellidoBenef = varApellidoBenef;
			
				item.NombreBenef = varNombreBenef;
			
				item.ClaseDocumentoBenef = varClaseDocumentoBenef;
			
				item.TipoDocumento = varTipoDocumento;
			
				item.NumeroDoc = varNumeroDoc;
			
				item.IdCategoria = varIdCategoria;
			
				item.Sexo = varSexo;
			
				item.FechaNacimientoBenef = varFechaNacimientoBenef;
			
				item.ProvinciaNac = varProvinciaNac;
			
				item.LocalidadNac = varLocalidadNac;
			
				item.PaisNac = varPaisNac;
			
				item.Indigena = varIndigena;
			
				item.IdTribu = varIdTribu;
			
				item.IdLengua = varIdLengua;
			
				item.Alfabeta = varAlfabeta;
			
				item.Estudios = varEstudios;
			
				item.AnioMayorNivel = varAnioMayorNivel;
			
				item.TipoDocMadre = varTipoDocMadre;
			
				item.NroDocMadre = varNroDocMadre;
			
				item.ApellidoMadre = varApellidoMadre;
			
				item.NombreMadre = varNombreMadre;
			
				item.AlfabetaMadre = varAlfabetaMadre;
			
				item.EstudiosMadre = varEstudiosMadre;
			
				item.AnioMayorNivelMadre = varAnioMayorNivelMadre;
			
				item.TipoDocPadre = varTipoDocPadre;
			
				item.NroDocPadre = varNroDocPadre;
			
				item.ApellidoPadre = varApellidoPadre;
			
				item.NombrePadre = varNombrePadre;
			
				item.AlfabetaPadre = varAlfabetaPadre;
			
				item.EstudiosPadre = varEstudiosPadre;
			
				item.AnioMayorNivelPadre = varAnioMayorNivelPadre;
			
				item.TipoDocTutor = varTipoDocTutor;
			
				item.NroDocTutor = varNroDocTutor;
			
				item.ApellidoTutor = varApellidoTutor;
			
				item.NombreTutor = varNombreTutor;
			
				item.AlfabetaTutor = varAlfabetaTutor;
			
				item.EstudiosTutor = varEstudiosTutor;
			
				item.AnioMayorNivelTutor = varAnioMayorNivelTutor;
			
				item.FechaDiagnosticoEmbarazo = varFechaDiagnosticoEmbarazo;
			
				item.SemanasEmbarazo = varSemanasEmbarazo;
			
				item.FechaProbableParto = varFechaProbableParto;
			
				item.FechaEfectivaParto = varFechaEfectivaParto;
			
				item.CuieEa = varCuieEa;
			
				item.CuieAh = varCuieAh;
			
				item.MenorConviveConAdulto = varMenorConviveConAdulto;
			
				item.Calle = varCalle;
			
				item.NumeroCalle = varNumeroCalle;
			
				item.Piso = varPiso;
			
				item.Dpto = varDpto;
			
				item.Manzana = varManzana;
			
				item.EntreCalle1 = varEntreCalle1;
			
				item.EntreCalle2 = varEntreCalle2;
			
				item.Telefono = varTelefono;
			
				item.Departamento = varDepartamento;
			
				item.Localidad = varLocalidad;
			
				item.Municipio = varMunicipio;
			
				item.Barrio = varBarrio;
			
				item.CodPos = varCodPos;
			
				item.Observaciones = varObservaciones;
			
				item.FechaInscripcion = varFechaInscripcion;
			
				item.FechaCarga = varFechaCarga;
			
				item.UsuarioCarga = varUsuarioCarga;
			
				item.Activo = varActivo;
			
				item.TipoFicha = varTipoFicha;
			
				item.Responsable = varResponsable;
			
				item.Fum = varFum;
			
				item.Rcv = varRcv;
			
				item.Discv = varDiscv;
			
				item.Disca = varDisca;
			
				item.Discmo = varDiscmo;
			
				item.Discme = varDiscme;
			
				item.Otradisc = varOtradisc;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdBeneficiariosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoEnvioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaveBeneficiarioColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoTransaccionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoBenefColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreBenefColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ClaseDocumentoBenefColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocumentoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCategoriaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoBenefColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ProvinciaNacColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadNacColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PaisNacColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IndigenaColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTribuColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLenguaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn AlfabetaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioMayorNivelColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocMadreColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn NroDocMadreColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoMadreColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreMadreColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn AlfabetaMadreColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosMadreColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioMayorNivelMadreColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocPadreColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn NroDocPadreColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoPadreColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn NombrePadreColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn AlfabetaPadreColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosPadreColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioMayorNivelPadreColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocTutorColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn NroDocTutorColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoTutorColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreTutorColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn AlfabetaTutorColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn EstudiosTutorColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        public static TableSchema.TableColumn AnioMayorNivelTutorColumn
        {
            get { return Schema.Columns[41]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDiagnosticoEmbarazoColumn
        {
            get { return Schema.Columns[42]; }
        }
        
        
        
        public static TableSchema.TableColumn SemanasEmbarazoColumn
        {
            get { return Schema.Columns[43]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaProbablePartoColumn
        {
            get { return Schema.Columns[44]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEfectivaPartoColumn
        {
            get { return Schema.Columns[45]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieEaColumn
        {
            get { return Schema.Columns[46]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieAhColumn
        {
            get { return Schema.Columns[47]; }
        }
        
        
        
        public static TableSchema.TableColumn MenorConviveConAdultoColumn
        {
            get { return Schema.Columns[48]; }
        }
        
        
        
        public static TableSchema.TableColumn CalleColumn
        {
            get { return Schema.Columns[49]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroCalleColumn
        {
            get { return Schema.Columns[50]; }
        }
        
        
        
        public static TableSchema.TableColumn PisoColumn
        {
            get { return Schema.Columns[51]; }
        }
        
        
        
        public static TableSchema.TableColumn DptoColumn
        {
            get { return Schema.Columns[52]; }
        }
        
        
        
        public static TableSchema.TableColumn ManzanaColumn
        {
            get { return Schema.Columns[53]; }
        }
        
        
        
        public static TableSchema.TableColumn EntreCalle1Column
        {
            get { return Schema.Columns[54]; }
        }
        
        
        
        public static TableSchema.TableColumn EntreCalle2Column
        {
            get { return Schema.Columns[55]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[56]; }
        }
        
        
        
        public static TableSchema.TableColumn DepartamentoColumn
        {
            get { return Schema.Columns[57]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[58]; }
        }
        
        
        
        public static TableSchema.TableColumn MunicipioColumn
        {
            get { return Schema.Columns[59]; }
        }
        
        
        
        public static TableSchema.TableColumn BarrioColumn
        {
            get { return Schema.Columns[60]; }
        }
        
        
        
        public static TableSchema.TableColumn CodPosColumn
        {
            get { return Schema.Columns[61]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[62]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaInscripcionColumn
        {
            get { return Schema.Columns[63]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaCargaColumn
        {
            get { return Schema.Columns[64]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioCargaColumn
        {
            get { return Schema.Columns[65]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[66]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoFichaColumn
        {
            get { return Schema.Columns[67]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[68]; }
        }
        
        
        
        public static TableSchema.TableColumn FumColumn
        {
            get { return Schema.Columns[69]; }
        }
        
        
        
        public static TableSchema.TableColumn RcvColumn
        {
            get { return Schema.Columns[70]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscvColumn
        {
            get { return Schema.Columns[71]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscaColumn
        {
            get { return Schema.Columns[72]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscmoColumn
        {
            get { return Schema.Columns[73]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscmeColumn
        {
            get { return Schema.Columns[74]; }
        }
        
        
        
        public static TableSchema.TableColumn OtradiscColumn
        {
            get { return Schema.Columns[75]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdBeneficiarios = @"id_beneficiarios";
			 public static string EstadoEnvio = @"estado_envio";
			 public static string ClaveBeneficiario = @"clave_beneficiario";
			 public static string TipoTransaccion = @"tipo_transaccion";
			 public static string ApellidoBenef = @"apellido_benef";
			 public static string NombreBenef = @"nombre_benef";
			 public static string ClaseDocumentoBenef = @"clase_documento_benef";
			 public static string TipoDocumento = @"tipo_documento";
			 public static string NumeroDoc = @"numero_doc";
			 public static string IdCategoria = @"id_categoria";
			 public static string Sexo = @"sexo";
			 public static string FechaNacimientoBenef = @"fecha_nacimiento_benef";
			 public static string ProvinciaNac = @"provincia_nac";
			 public static string LocalidadNac = @"localidad_nac";
			 public static string PaisNac = @"pais_nac";
			 public static string Indigena = @"indigena";
			 public static string IdTribu = @"id_tribu";
			 public static string IdLengua = @"id_lengua";
			 public static string Alfabeta = @"alfabeta";
			 public static string Estudios = @"estudios";
			 public static string AnioMayorNivel = @"anio_mayor_nivel";
			 public static string TipoDocMadre = @"tipo_doc_madre";
			 public static string NroDocMadre = @"nro_doc_madre";
			 public static string ApellidoMadre = @"apellido_madre";
			 public static string NombreMadre = @"nombre_madre";
			 public static string AlfabetaMadre = @"alfabeta_madre";
			 public static string EstudiosMadre = @"estudios_madre";
			 public static string AnioMayorNivelMadre = @"anio_mayor_nivel_madre";
			 public static string TipoDocPadre = @"tipo_doc_padre";
			 public static string NroDocPadre = @"nro_doc_padre";
			 public static string ApellidoPadre = @"apellido_padre";
			 public static string NombrePadre = @"nombre_padre";
			 public static string AlfabetaPadre = @"alfabeta_padre";
			 public static string EstudiosPadre = @"estudios_padre";
			 public static string AnioMayorNivelPadre = @"anio_mayor_nivel_padre";
			 public static string TipoDocTutor = @"tipo_doc_tutor";
			 public static string NroDocTutor = @"nro_doc_tutor";
			 public static string ApellidoTutor = @"apellido_tutor";
			 public static string NombreTutor = @"nombre_tutor";
			 public static string AlfabetaTutor = @"alfabeta_tutor";
			 public static string EstudiosTutor = @"estudios_tutor";
			 public static string AnioMayorNivelTutor = @"anio_mayor_nivel_tutor";
			 public static string FechaDiagnosticoEmbarazo = @"fecha_diagnostico_embarazo";
			 public static string SemanasEmbarazo = @"semanas_embarazo";
			 public static string FechaProbableParto = @"fecha_probable_parto";
			 public static string FechaEfectivaParto = @"fecha_efectiva_parto";
			 public static string CuieEa = @"cuie_ea";
			 public static string CuieAh = @"cuie_ah";
			 public static string MenorConviveConAdulto = @"menor_convive_con_adulto";
			 public static string Calle = @"calle";
			 public static string NumeroCalle = @"numero_calle";
			 public static string Piso = @"piso";
			 public static string Dpto = @"dpto";
			 public static string Manzana = @"manzana";
			 public static string EntreCalle1 = @"entre_calle_1";
			 public static string EntreCalle2 = @"entre_calle_2";
			 public static string Telefono = @"telefono";
			 public static string Departamento = @"departamento";
			 public static string Localidad = @"localidad";
			 public static string Municipio = @"municipio";
			 public static string Barrio = @"barrio";
			 public static string CodPos = @"cod_pos";
			 public static string Observaciones = @"observaciones";
			 public static string FechaInscripcion = @"fecha_inscripcion";
			 public static string FechaCarga = @"fecha_carga";
			 public static string UsuarioCarga = @"usuario_carga";
			 public static string Activo = @"activo";
			 public static string TipoFicha = @"tipo_ficha";
			 public static string Responsable = @"responsable";
			 public static string Fum = @"fum";
			 public static string Rcv = @"rcv";
			 public static string Discv = @"discv";
			 public static string Disca = @"disca";
			 public static string Discmo = @"discmo";
			 public static string Discme = @"discme";
			 public static string Otradisc = @"otradisc";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
