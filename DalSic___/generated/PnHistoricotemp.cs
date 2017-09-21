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
	/// Strongly-typed collection for the PnHistoricotemp class.
	/// </summary>
    [Serializable]
	public partial class PnHistoricotempCollection : ActiveList<PnHistoricotemp, PnHistoricotempCollection>
	{	   
		public PnHistoricotempCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnHistoricotempCollection</returns>
		public PnHistoricotempCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnHistoricotemp o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_historicotemp table.
	/// </summary>
	[Serializable]
	public partial class PnHistoricotemp : ActiveRecord<PnHistoricotemp>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnHistoricotemp()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnHistoricotemp(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnHistoricotemp(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnHistoricotemp(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_historicotemp", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSmiafiliados = new TableSchema.TableColumn(schema);
				colvarIdSmiafiliados.ColumnName = "id_smiafiliados";
				colvarIdSmiafiliados.DataType = DbType.AnsiString;
				colvarIdSmiafiliados.MaxLength = 20;
				colvarIdSmiafiliados.AutoIncrement = false;
				colvarIdSmiafiliados.IsNullable = false;
				colvarIdSmiafiliados.IsPrimaryKey = true;
				colvarIdSmiafiliados.IsForeignKey = false;
				colvarIdSmiafiliados.IsReadOnly = false;
				colvarIdSmiafiliados.DefaultSetting = @"";
				colvarIdSmiafiliados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSmiafiliados);
				
				TableSchema.TableColumn colvarClavebeneficiario = new TableSchema.TableColumn(schema);
				colvarClavebeneficiario.ColumnName = "clavebeneficiario";
				colvarClavebeneficiario.DataType = DbType.AnsiString;
				colvarClavebeneficiario.MaxLength = 16;
				colvarClavebeneficiario.AutoIncrement = false;
				colvarClavebeneficiario.IsNullable = true;
				colvarClavebeneficiario.IsPrimaryKey = false;
				colvarClavebeneficiario.IsForeignKey = false;
				colvarClavebeneficiario.IsReadOnly = false;
				colvarClavebeneficiario.DefaultSetting = @"";
				colvarClavebeneficiario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClavebeneficiario);
				
				TableSchema.TableColumn colvarAfiapellido = new TableSchema.TableColumn(schema);
				colvarAfiapellido.ColumnName = "afiapellido";
				colvarAfiapellido.DataType = DbType.AnsiString;
				colvarAfiapellido.MaxLength = 40;
				colvarAfiapellido.AutoIncrement = false;
				colvarAfiapellido.IsNullable = true;
				colvarAfiapellido.IsPrimaryKey = false;
				colvarAfiapellido.IsForeignKey = false;
				colvarAfiapellido.IsReadOnly = false;
				colvarAfiapellido.DefaultSetting = @"";
				colvarAfiapellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfiapellido);
				
				TableSchema.TableColumn colvarAfinombre = new TableSchema.TableColumn(schema);
				colvarAfinombre.ColumnName = "afinombre";
				colvarAfinombre.DataType = DbType.AnsiString;
				colvarAfinombre.MaxLength = 40;
				colvarAfinombre.AutoIncrement = false;
				colvarAfinombre.IsNullable = true;
				colvarAfinombre.IsPrimaryKey = false;
				colvarAfinombre.IsForeignKey = false;
				colvarAfinombre.IsReadOnly = false;
				colvarAfinombre.DefaultSetting = @"";
				colvarAfinombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfinombre);
				
				TableSchema.TableColumn colvarAfitipodoc = new TableSchema.TableColumn(schema);
				colvarAfitipodoc.ColumnName = "afitipodoc";
				colvarAfitipodoc.DataType = DbType.AnsiString;
				colvarAfitipodoc.MaxLength = 5;
				colvarAfitipodoc.AutoIncrement = false;
				colvarAfitipodoc.IsNullable = true;
				colvarAfitipodoc.IsPrimaryKey = false;
				colvarAfitipodoc.IsForeignKey = false;
				colvarAfitipodoc.IsReadOnly = false;
				colvarAfitipodoc.DefaultSetting = @"";
				colvarAfitipodoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfitipodoc);
				
				TableSchema.TableColumn colvarAficlasedoc = new TableSchema.TableColumn(schema);
				colvarAficlasedoc.ColumnName = "aficlasedoc";
				colvarAficlasedoc.DataType = DbType.AnsiStringFixedLength;
				colvarAficlasedoc.MaxLength = 1;
				colvarAficlasedoc.AutoIncrement = false;
				colvarAficlasedoc.IsNullable = true;
				colvarAficlasedoc.IsPrimaryKey = false;
				colvarAficlasedoc.IsForeignKey = false;
				colvarAficlasedoc.IsReadOnly = false;
				colvarAficlasedoc.DefaultSetting = @"";
				colvarAficlasedoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAficlasedoc);
				
				TableSchema.TableColumn colvarAfidni = new TableSchema.TableColumn(schema);
				colvarAfidni.ColumnName = "afidni";
				colvarAfidni.DataType = DbType.AnsiString;
				colvarAfidni.MaxLength = 12;
				colvarAfidni.AutoIncrement = false;
				colvarAfidni.IsNullable = true;
				colvarAfidni.IsPrimaryKey = false;
				colvarAfidni.IsForeignKey = false;
				colvarAfidni.IsReadOnly = false;
				colvarAfidni.DefaultSetting = @"";
				colvarAfidni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidni);
				
				TableSchema.TableColumn colvarAfisexo = new TableSchema.TableColumn(schema);
				colvarAfisexo.ColumnName = "afisexo";
				colvarAfisexo.DataType = DbType.AnsiStringFixedLength;
				colvarAfisexo.MaxLength = 1;
				colvarAfisexo.AutoIncrement = false;
				colvarAfisexo.IsNullable = true;
				colvarAfisexo.IsPrimaryKey = false;
				colvarAfisexo.IsForeignKey = false;
				colvarAfisexo.IsReadOnly = false;
				colvarAfisexo.DefaultSetting = @"";
				colvarAfisexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfisexo);
				
				TableSchema.TableColumn colvarAfiprovincia = new TableSchema.TableColumn(schema);
				colvarAfiprovincia.ColumnName = "afiprovincia";
				colvarAfiprovincia.DataType = DbType.AnsiString;
				colvarAfiprovincia.MaxLength = 20;
				colvarAfiprovincia.AutoIncrement = false;
				colvarAfiprovincia.IsNullable = true;
				colvarAfiprovincia.IsPrimaryKey = false;
				colvarAfiprovincia.IsForeignKey = false;
				colvarAfiprovincia.IsReadOnly = false;
				colvarAfiprovincia.DefaultSetting = @"";
				colvarAfiprovincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfiprovincia);
				
				TableSchema.TableColumn colvarAfilocalidad = new TableSchema.TableColumn(schema);
				colvarAfilocalidad.ColumnName = "afilocalidad";
				colvarAfilocalidad.DataType = DbType.AnsiString;
				colvarAfilocalidad.MaxLength = 40;
				colvarAfilocalidad.AutoIncrement = false;
				colvarAfilocalidad.IsNullable = true;
				colvarAfilocalidad.IsPrimaryKey = false;
				colvarAfilocalidad.IsForeignKey = false;
				colvarAfilocalidad.IsReadOnly = false;
				colvarAfilocalidad.DefaultSetting = @"";
				colvarAfilocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfilocalidad);
				
				TableSchema.TableColumn colvarAfitipocategoria = new TableSchema.TableColumn(schema);
				colvarAfitipocategoria.ColumnName = "afitipocategoria";
				colvarAfitipocategoria.DataType = DbType.Int16;
				colvarAfitipocategoria.MaxLength = 0;
				colvarAfitipocategoria.AutoIncrement = false;
				colvarAfitipocategoria.IsNullable = true;
				colvarAfitipocategoria.IsPrimaryKey = false;
				colvarAfitipocategoria.IsForeignKey = false;
				colvarAfitipocategoria.IsReadOnly = false;
				colvarAfitipocategoria.DefaultSetting = @"";
				colvarAfitipocategoria.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfitipocategoria);
				
				TableSchema.TableColumn colvarAfifechanac = new TableSchema.TableColumn(schema);
				colvarAfifechanac.ColumnName = "afifechanac";
				colvarAfifechanac.DataType = DbType.DateTime;
				colvarAfifechanac.MaxLength = 0;
				colvarAfifechanac.AutoIncrement = false;
				colvarAfifechanac.IsNullable = true;
				colvarAfifechanac.IsPrimaryKey = false;
				colvarAfifechanac.IsForeignKey = false;
				colvarAfifechanac.IsReadOnly = false;
				colvarAfifechanac.DefaultSetting = @"";
				colvarAfifechanac.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfifechanac);
				
				TableSchema.TableColumn colvarAfideclaraindigena = new TableSchema.TableColumn(schema);
				colvarAfideclaraindigena.ColumnName = "afideclaraindigena";
				colvarAfideclaraindigena.DataType = DbType.AnsiStringFixedLength;
				colvarAfideclaraindigena.MaxLength = 1;
				colvarAfideclaraindigena.AutoIncrement = false;
				colvarAfideclaraindigena.IsNullable = true;
				colvarAfideclaraindigena.IsPrimaryKey = false;
				colvarAfideclaraindigena.IsForeignKey = false;
				colvarAfideclaraindigena.IsReadOnly = false;
				colvarAfideclaraindigena.DefaultSetting = @"";
				colvarAfideclaraindigena.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfideclaraindigena);
				
				TableSchema.TableColumn colvarAfiidLengua = new TableSchema.TableColumn(schema);
				colvarAfiidLengua.ColumnName = "afiid_lengua";
				colvarAfiidLengua.DataType = DbType.Int32;
				colvarAfiidLengua.MaxLength = 0;
				colvarAfiidLengua.AutoIncrement = false;
				colvarAfiidLengua.IsNullable = true;
				colvarAfiidLengua.IsPrimaryKey = false;
				colvarAfiidLengua.IsForeignKey = false;
				colvarAfiidLengua.IsReadOnly = false;
				colvarAfiidLengua.DefaultSetting = @"";
				colvarAfiidLengua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfiidLengua);
				
				TableSchema.TableColumn colvarAfiidTribu = new TableSchema.TableColumn(schema);
				colvarAfiidTribu.ColumnName = "afiid_tribu";
				colvarAfiidTribu.DataType = DbType.Int32;
				colvarAfiidTribu.MaxLength = 0;
				colvarAfiidTribu.AutoIncrement = false;
				colvarAfiidTribu.IsNullable = true;
				colvarAfiidTribu.IsPrimaryKey = false;
				colvarAfiidTribu.IsForeignKey = false;
				colvarAfiidTribu.IsReadOnly = false;
				colvarAfiidTribu.DefaultSetting = @"";
				colvarAfiidTribu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfiidTribu);
				
				TableSchema.TableColumn colvarMatipodocumento = new TableSchema.TableColumn(schema);
				colvarMatipodocumento.ColumnName = "matipodocumento";
				colvarMatipodocumento.DataType = DbType.AnsiString;
				colvarMatipodocumento.MaxLength = 5;
				colvarMatipodocumento.AutoIncrement = false;
				colvarMatipodocumento.IsNullable = true;
				colvarMatipodocumento.IsPrimaryKey = false;
				colvarMatipodocumento.IsForeignKey = false;
				colvarMatipodocumento.IsReadOnly = false;
				colvarMatipodocumento.DefaultSetting = @"";
				colvarMatipodocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMatipodocumento);
				
				TableSchema.TableColumn colvarManrodocumento = new TableSchema.TableColumn(schema);
				colvarManrodocumento.ColumnName = "manrodocumento";
				colvarManrodocumento.DataType = DbType.AnsiString;
				colvarManrodocumento.MaxLength = 12;
				colvarManrodocumento.AutoIncrement = false;
				colvarManrodocumento.IsNullable = true;
				colvarManrodocumento.IsPrimaryKey = false;
				colvarManrodocumento.IsForeignKey = false;
				colvarManrodocumento.IsReadOnly = false;
				colvarManrodocumento.DefaultSetting = @"";
				colvarManrodocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarManrodocumento);
				
				TableSchema.TableColumn colvarMaapellido = new TableSchema.TableColumn(schema);
				colvarMaapellido.ColumnName = "maapellido";
				colvarMaapellido.DataType = DbType.AnsiString;
				colvarMaapellido.MaxLength = 40;
				colvarMaapellido.AutoIncrement = false;
				colvarMaapellido.IsNullable = true;
				colvarMaapellido.IsPrimaryKey = false;
				colvarMaapellido.IsForeignKey = false;
				colvarMaapellido.IsReadOnly = false;
				colvarMaapellido.DefaultSetting = @"";
				colvarMaapellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaapellido);
				
				TableSchema.TableColumn colvarManombre = new TableSchema.TableColumn(schema);
				colvarManombre.ColumnName = "manombre";
				colvarManombre.DataType = DbType.AnsiString;
				colvarManombre.MaxLength = 40;
				colvarManombre.AutoIncrement = false;
				colvarManombre.IsNullable = true;
				colvarManombre.IsPrimaryKey = false;
				colvarManombre.IsForeignKey = false;
				colvarManombre.IsReadOnly = false;
				colvarManombre.DefaultSetting = @"";
				colvarManombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarManombre);
				
				TableSchema.TableColumn colvarPatipodocumento = new TableSchema.TableColumn(schema);
				colvarPatipodocumento.ColumnName = "patipodocumento";
				colvarPatipodocumento.DataType = DbType.AnsiString;
				colvarPatipodocumento.MaxLength = 5;
				colvarPatipodocumento.AutoIncrement = false;
				colvarPatipodocumento.IsNullable = true;
				colvarPatipodocumento.IsPrimaryKey = false;
				colvarPatipodocumento.IsForeignKey = false;
				colvarPatipodocumento.IsReadOnly = false;
				colvarPatipodocumento.DefaultSetting = @"";
				colvarPatipodocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPatipodocumento);
				
				TableSchema.TableColumn colvarPanrodocumento = new TableSchema.TableColumn(schema);
				colvarPanrodocumento.ColumnName = "panrodocumento";
				colvarPanrodocumento.DataType = DbType.AnsiString;
				colvarPanrodocumento.MaxLength = 12;
				colvarPanrodocumento.AutoIncrement = false;
				colvarPanrodocumento.IsNullable = true;
				colvarPanrodocumento.IsPrimaryKey = false;
				colvarPanrodocumento.IsForeignKey = false;
				colvarPanrodocumento.IsReadOnly = false;
				colvarPanrodocumento.DefaultSetting = @"";
				colvarPanrodocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPanrodocumento);
				
				TableSchema.TableColumn colvarPaapellido = new TableSchema.TableColumn(schema);
				colvarPaapellido.ColumnName = "paapellido";
				colvarPaapellido.DataType = DbType.AnsiString;
				colvarPaapellido.MaxLength = 40;
				colvarPaapellido.AutoIncrement = false;
				colvarPaapellido.IsNullable = true;
				colvarPaapellido.IsPrimaryKey = false;
				colvarPaapellido.IsForeignKey = false;
				colvarPaapellido.IsReadOnly = false;
				colvarPaapellido.DefaultSetting = @"";
				colvarPaapellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaapellido);
				
				TableSchema.TableColumn colvarPanombre = new TableSchema.TableColumn(schema);
				colvarPanombre.ColumnName = "panombre";
				colvarPanombre.DataType = DbType.AnsiString;
				colvarPanombre.MaxLength = 40;
				colvarPanombre.AutoIncrement = false;
				colvarPanombre.IsNullable = true;
				colvarPanombre.IsPrimaryKey = false;
				colvarPanombre.IsForeignKey = false;
				colvarPanombre.IsReadOnly = false;
				colvarPanombre.DefaultSetting = @"";
				colvarPanombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPanombre);
				
				TableSchema.TableColumn colvarOtrotipodocumento = new TableSchema.TableColumn(schema);
				colvarOtrotipodocumento.ColumnName = "otrotipodocumento";
				colvarOtrotipodocumento.DataType = DbType.AnsiString;
				colvarOtrotipodocumento.MaxLength = 5;
				colvarOtrotipodocumento.AutoIncrement = false;
				colvarOtrotipodocumento.IsNullable = true;
				colvarOtrotipodocumento.IsPrimaryKey = false;
				colvarOtrotipodocumento.IsForeignKey = false;
				colvarOtrotipodocumento.IsReadOnly = false;
				colvarOtrotipodocumento.DefaultSetting = @"";
				colvarOtrotipodocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrotipodocumento);
				
				TableSchema.TableColumn colvarOtronrodocumento = new TableSchema.TableColumn(schema);
				colvarOtronrodocumento.ColumnName = "otronrodocumento";
				colvarOtronrodocumento.DataType = DbType.AnsiString;
				colvarOtronrodocumento.MaxLength = 12;
				colvarOtronrodocumento.AutoIncrement = false;
				colvarOtronrodocumento.IsNullable = true;
				colvarOtronrodocumento.IsPrimaryKey = false;
				colvarOtronrodocumento.IsForeignKey = false;
				colvarOtronrodocumento.IsReadOnly = false;
				colvarOtronrodocumento.DefaultSetting = @"";
				colvarOtronrodocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtronrodocumento);
				
				TableSchema.TableColumn colvarOtroapellido = new TableSchema.TableColumn(schema);
				colvarOtroapellido.ColumnName = "otroapellido";
				colvarOtroapellido.DataType = DbType.AnsiString;
				colvarOtroapellido.MaxLength = 40;
				colvarOtroapellido.AutoIncrement = false;
				colvarOtroapellido.IsNullable = true;
				colvarOtroapellido.IsPrimaryKey = false;
				colvarOtroapellido.IsForeignKey = false;
				colvarOtroapellido.IsReadOnly = false;
				colvarOtroapellido.DefaultSetting = @"";
				colvarOtroapellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtroapellido);
				
				TableSchema.TableColumn colvarOtronombre = new TableSchema.TableColumn(schema);
				colvarOtronombre.ColumnName = "otronombre";
				colvarOtronombre.DataType = DbType.AnsiString;
				colvarOtronombre.MaxLength = 40;
				colvarOtronombre.AutoIncrement = false;
				colvarOtronombre.IsNullable = true;
				colvarOtronombre.IsPrimaryKey = false;
				colvarOtronombre.IsForeignKey = false;
				colvarOtronombre.IsReadOnly = false;
				colvarOtronombre.DefaultSetting = @"";
				colvarOtronombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtronombre);
				
				TableSchema.TableColumn colvarOtrotiporelacion = new TableSchema.TableColumn(schema);
				colvarOtrotiporelacion.ColumnName = "otrotiporelacion";
				colvarOtrotiporelacion.DataType = DbType.Int32;
				colvarOtrotiporelacion.MaxLength = 0;
				colvarOtrotiporelacion.AutoIncrement = false;
				colvarOtrotiporelacion.IsNullable = true;
				colvarOtrotiporelacion.IsPrimaryKey = false;
				colvarOtrotiporelacion.IsForeignKey = false;
				colvarOtrotiporelacion.IsReadOnly = false;
				colvarOtrotiporelacion.DefaultSetting = @"";
				colvarOtrotiporelacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtrotiporelacion);
				
				TableSchema.TableColumn colvarFechainscripcion = new TableSchema.TableColumn(schema);
				colvarFechainscripcion.ColumnName = "fechainscripcion";
				colvarFechainscripcion.DataType = DbType.DateTime;
				colvarFechainscripcion.MaxLength = 0;
				colvarFechainscripcion.AutoIncrement = false;
				colvarFechainscripcion.IsNullable = true;
				colvarFechainscripcion.IsPrimaryKey = false;
				colvarFechainscripcion.IsForeignKey = false;
				colvarFechainscripcion.IsReadOnly = false;
				colvarFechainscripcion.DefaultSetting = @"";
				colvarFechainscripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechainscripcion);
				
				TableSchema.TableColumn colvarFechaaltaefectiva = new TableSchema.TableColumn(schema);
				colvarFechaaltaefectiva.ColumnName = "fechaaltaefectiva";
				colvarFechaaltaefectiva.DataType = DbType.DateTime;
				colvarFechaaltaefectiva.MaxLength = 0;
				colvarFechaaltaefectiva.AutoIncrement = false;
				colvarFechaaltaefectiva.IsNullable = true;
				colvarFechaaltaefectiva.IsPrimaryKey = false;
				colvarFechaaltaefectiva.IsForeignKey = false;
				colvarFechaaltaefectiva.IsReadOnly = false;
				colvarFechaaltaefectiva.DefaultSetting = @"";
				colvarFechaaltaefectiva.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaaltaefectiva);
				
				TableSchema.TableColumn colvarFechadiagnosticoembarazo = new TableSchema.TableColumn(schema);
				colvarFechadiagnosticoembarazo.ColumnName = "fechadiagnosticoembarazo";
				colvarFechadiagnosticoembarazo.DataType = DbType.DateTime;
				colvarFechadiagnosticoembarazo.MaxLength = 0;
				colvarFechadiagnosticoembarazo.AutoIncrement = false;
				colvarFechadiagnosticoembarazo.IsNullable = true;
				colvarFechadiagnosticoembarazo.IsPrimaryKey = false;
				colvarFechadiagnosticoembarazo.IsForeignKey = false;
				colvarFechadiagnosticoembarazo.IsReadOnly = false;
				colvarFechadiagnosticoembarazo.DefaultSetting = @"";
				colvarFechadiagnosticoembarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechadiagnosticoembarazo);
				
				TableSchema.TableColumn colvarSemanasembarazo = new TableSchema.TableColumn(schema);
				colvarSemanasembarazo.ColumnName = "semanasembarazo";
				colvarSemanasembarazo.DataType = DbType.Int32;
				colvarSemanasembarazo.MaxLength = 0;
				colvarSemanasembarazo.AutoIncrement = false;
				colvarSemanasembarazo.IsNullable = true;
				colvarSemanasembarazo.IsPrimaryKey = false;
				colvarSemanasembarazo.IsForeignKey = false;
				colvarSemanasembarazo.IsReadOnly = false;
				colvarSemanasembarazo.DefaultSetting = @"";
				colvarSemanasembarazo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSemanasembarazo);
				
				TableSchema.TableColumn colvarFechaprobableparto = new TableSchema.TableColumn(schema);
				colvarFechaprobableparto.ColumnName = "fechaprobableparto";
				colvarFechaprobableparto.DataType = DbType.DateTime;
				colvarFechaprobableparto.MaxLength = 0;
				colvarFechaprobableparto.AutoIncrement = false;
				colvarFechaprobableparto.IsNullable = true;
				colvarFechaprobableparto.IsPrimaryKey = false;
				colvarFechaprobableparto.IsForeignKey = false;
				colvarFechaprobableparto.IsReadOnly = false;
				colvarFechaprobableparto.DefaultSetting = @"";
				colvarFechaprobableparto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaprobableparto);
				
				TableSchema.TableColumn colvarFechaefectivaparto = new TableSchema.TableColumn(schema);
				colvarFechaefectivaparto.ColumnName = "fechaefectivaparto";
				colvarFechaefectivaparto.DataType = DbType.DateTime;
				colvarFechaefectivaparto.MaxLength = 0;
				colvarFechaefectivaparto.AutoIncrement = false;
				colvarFechaefectivaparto.IsNullable = true;
				colvarFechaefectivaparto.IsPrimaryKey = false;
				colvarFechaefectivaparto.IsForeignKey = false;
				colvarFechaefectivaparto.IsReadOnly = false;
				colvarFechaefectivaparto.DefaultSetting = @"";
				colvarFechaefectivaparto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaefectivaparto);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.AnsiStringFixedLength;
				colvarActivo.MaxLength = 1;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = true;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarAccionpendienteconfirmar = new TableSchema.TableColumn(schema);
				colvarAccionpendienteconfirmar.ColumnName = "accionpendienteconfirmar";
				colvarAccionpendienteconfirmar.DataType = DbType.AnsiStringFixedLength;
				colvarAccionpendienteconfirmar.MaxLength = 1;
				colvarAccionpendienteconfirmar.AutoIncrement = false;
				colvarAccionpendienteconfirmar.IsNullable = true;
				colvarAccionpendienteconfirmar.IsPrimaryKey = false;
				colvarAccionpendienteconfirmar.IsForeignKey = false;
				colvarAccionpendienteconfirmar.IsReadOnly = false;
				colvarAccionpendienteconfirmar.DefaultSetting = @"";
				colvarAccionpendienteconfirmar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccionpendienteconfirmar);
				
				TableSchema.TableColumn colvarAfidomcalle = new TableSchema.TableColumn(schema);
				colvarAfidomcalle.ColumnName = "afidomcalle";
				colvarAfidomcalle.DataType = DbType.AnsiString;
				colvarAfidomcalle.MaxLength = 40;
				colvarAfidomcalle.AutoIncrement = false;
				colvarAfidomcalle.IsNullable = true;
				colvarAfidomcalle.IsPrimaryKey = false;
				colvarAfidomcalle.IsForeignKey = false;
				colvarAfidomcalle.IsReadOnly = false;
				colvarAfidomcalle.DefaultSetting = @"";
				colvarAfidomcalle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomcalle);
				
				TableSchema.TableColumn colvarAfidomnro = new TableSchema.TableColumn(schema);
				colvarAfidomnro.ColumnName = "afidomnro";
				colvarAfidomnro.DataType = DbType.AnsiString;
				colvarAfidomnro.MaxLength = 5;
				colvarAfidomnro.AutoIncrement = false;
				colvarAfidomnro.IsNullable = true;
				colvarAfidomnro.IsPrimaryKey = false;
				colvarAfidomnro.IsForeignKey = false;
				colvarAfidomnro.IsReadOnly = false;
				colvarAfidomnro.DefaultSetting = @"";
				colvarAfidomnro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomnro);
				
				TableSchema.TableColumn colvarAfidommanzana = new TableSchema.TableColumn(schema);
				colvarAfidommanzana.ColumnName = "afidommanzana";
				colvarAfidommanzana.DataType = DbType.AnsiString;
				colvarAfidommanzana.MaxLength = 3;
				colvarAfidommanzana.AutoIncrement = false;
				colvarAfidommanzana.IsNullable = true;
				colvarAfidommanzana.IsPrimaryKey = false;
				colvarAfidommanzana.IsForeignKey = false;
				colvarAfidommanzana.IsReadOnly = false;
				colvarAfidommanzana.DefaultSetting = @"";
				colvarAfidommanzana.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidommanzana);
				
				TableSchema.TableColumn colvarAfidompiso = new TableSchema.TableColumn(schema);
				colvarAfidompiso.ColumnName = "afidompiso";
				colvarAfidompiso.DataType = DbType.AnsiString;
				colvarAfidompiso.MaxLength = 2;
				colvarAfidompiso.AutoIncrement = false;
				colvarAfidompiso.IsNullable = true;
				colvarAfidompiso.IsPrimaryKey = false;
				colvarAfidompiso.IsForeignKey = false;
				colvarAfidompiso.IsReadOnly = false;
				colvarAfidompiso.DefaultSetting = @"";
				colvarAfidompiso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidompiso);
				
				TableSchema.TableColumn colvarAfidomdepto = new TableSchema.TableColumn(schema);
				colvarAfidomdepto.ColumnName = "afidomdepto";
				colvarAfidomdepto.DataType = DbType.AnsiString;
				colvarAfidomdepto.MaxLength = 3;
				colvarAfidomdepto.AutoIncrement = false;
				colvarAfidomdepto.IsNullable = true;
				colvarAfidomdepto.IsPrimaryKey = false;
				colvarAfidomdepto.IsForeignKey = false;
				colvarAfidomdepto.IsReadOnly = false;
				colvarAfidomdepto.DefaultSetting = @"";
				colvarAfidomdepto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomdepto);
				
				TableSchema.TableColumn colvarAfidomentrecalle1 = new TableSchema.TableColumn(schema);
				colvarAfidomentrecalle1.ColumnName = "afidomentrecalle1";
				colvarAfidomentrecalle1.DataType = DbType.AnsiString;
				colvarAfidomentrecalle1.MaxLength = 30;
				colvarAfidomentrecalle1.AutoIncrement = false;
				colvarAfidomentrecalle1.IsNullable = true;
				colvarAfidomentrecalle1.IsPrimaryKey = false;
				colvarAfidomentrecalle1.IsForeignKey = false;
				colvarAfidomentrecalle1.IsReadOnly = false;
				colvarAfidomentrecalle1.DefaultSetting = @"";
				colvarAfidomentrecalle1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomentrecalle1);
				
				TableSchema.TableColumn colvarAfidomentrecalle2 = new TableSchema.TableColumn(schema);
				colvarAfidomentrecalle2.ColumnName = "afidomentrecalle2";
				colvarAfidomentrecalle2.DataType = DbType.AnsiString;
				colvarAfidomentrecalle2.MaxLength = 30;
				colvarAfidomentrecalle2.AutoIncrement = false;
				colvarAfidomentrecalle2.IsNullable = true;
				colvarAfidomentrecalle2.IsPrimaryKey = false;
				colvarAfidomentrecalle2.IsForeignKey = false;
				colvarAfidomentrecalle2.IsReadOnly = false;
				colvarAfidomentrecalle2.DefaultSetting = @"";
				colvarAfidomentrecalle2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomentrecalle2);
				
				TableSchema.TableColumn colvarAfidombarrioparaje = new TableSchema.TableColumn(schema);
				colvarAfidombarrioparaje.ColumnName = "afidombarrioparaje";
				colvarAfidombarrioparaje.DataType = DbType.AnsiString;
				colvarAfidombarrioparaje.MaxLength = 40;
				colvarAfidombarrioparaje.AutoIncrement = false;
				colvarAfidombarrioparaje.IsNullable = true;
				colvarAfidombarrioparaje.IsPrimaryKey = false;
				colvarAfidombarrioparaje.IsForeignKey = false;
				colvarAfidombarrioparaje.IsReadOnly = false;
				colvarAfidombarrioparaje.DefaultSetting = @"";
				colvarAfidombarrioparaje.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidombarrioparaje);
				
				TableSchema.TableColumn colvarAfidommunicipio = new TableSchema.TableColumn(schema);
				colvarAfidommunicipio.ColumnName = "afidommunicipio";
				colvarAfidommunicipio.DataType = DbType.AnsiString;
				colvarAfidommunicipio.MaxLength = 40;
				colvarAfidommunicipio.AutoIncrement = false;
				colvarAfidommunicipio.IsNullable = true;
				colvarAfidommunicipio.IsPrimaryKey = false;
				colvarAfidommunicipio.IsForeignKey = false;
				colvarAfidommunicipio.IsReadOnly = false;
				colvarAfidommunicipio.DefaultSetting = @"";
				colvarAfidommunicipio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidommunicipio);
				
				TableSchema.TableColumn colvarAfidomdepartamento = new TableSchema.TableColumn(schema);
				colvarAfidomdepartamento.ColumnName = "afidomdepartamento";
				colvarAfidomdepartamento.DataType = DbType.AnsiString;
				colvarAfidomdepartamento.MaxLength = 40;
				colvarAfidomdepartamento.AutoIncrement = false;
				colvarAfidomdepartamento.IsNullable = true;
				colvarAfidomdepartamento.IsPrimaryKey = false;
				colvarAfidomdepartamento.IsForeignKey = false;
				colvarAfidomdepartamento.IsReadOnly = false;
				colvarAfidomdepartamento.DefaultSetting = @"";
				colvarAfidomdepartamento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomdepartamento);
				
				TableSchema.TableColumn colvarAfidomlocalidad = new TableSchema.TableColumn(schema);
				colvarAfidomlocalidad.ColumnName = "afidomlocalidad";
				colvarAfidomlocalidad.DataType = DbType.AnsiString;
				colvarAfidomlocalidad.MaxLength = 85;
				colvarAfidomlocalidad.AutoIncrement = false;
				colvarAfidomlocalidad.IsNullable = true;
				colvarAfidomlocalidad.IsPrimaryKey = false;
				colvarAfidomlocalidad.IsForeignKey = false;
				colvarAfidomlocalidad.IsReadOnly = false;
				colvarAfidomlocalidad.DefaultSetting = @"";
				colvarAfidomlocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomlocalidad);
				
				TableSchema.TableColumn colvarAfidomprovincia = new TableSchema.TableColumn(schema);
				colvarAfidomprovincia.ColumnName = "afidomprovincia";
				colvarAfidomprovincia.DataType = DbType.AnsiString;
				colvarAfidomprovincia.MaxLength = 2;
				colvarAfidomprovincia.AutoIncrement = false;
				colvarAfidomprovincia.IsNullable = true;
				colvarAfidomprovincia.IsPrimaryKey = false;
				colvarAfidomprovincia.IsForeignKey = false;
				colvarAfidomprovincia.IsReadOnly = false;
				colvarAfidomprovincia.DefaultSetting = @"";
				colvarAfidomprovincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomprovincia);
				
				TableSchema.TableColumn colvarAfidomcp = new TableSchema.TableColumn(schema);
				colvarAfidomcp.ColumnName = "afidomcp";
				colvarAfidomcp.DataType = DbType.AnsiString;
				colvarAfidomcp.MaxLength = 8;
				colvarAfidomcp.AutoIncrement = false;
				colvarAfidomcp.IsNullable = true;
				colvarAfidomcp.IsPrimaryKey = false;
				colvarAfidomcp.IsForeignKey = false;
				colvarAfidomcp.IsReadOnly = false;
				colvarAfidomcp.DefaultSetting = @"";
				colvarAfidomcp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfidomcp);
				
				TableSchema.TableColumn colvarAfitelefono = new TableSchema.TableColumn(schema);
				colvarAfitelefono.ColumnName = "afitelefono";
				colvarAfitelefono.DataType = DbType.AnsiString;
				colvarAfitelefono.MaxLength = 20;
				colvarAfitelefono.AutoIncrement = false;
				colvarAfitelefono.IsNullable = true;
				colvarAfitelefono.IsPrimaryKey = false;
				colvarAfitelefono.IsForeignKey = false;
				colvarAfitelefono.IsReadOnly = false;
				colvarAfitelefono.DefaultSetting = @"";
				colvarAfitelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfitelefono);
				
				TableSchema.TableColumn colvarLugaratencionhabitual = new TableSchema.TableColumn(schema);
				colvarLugaratencionhabitual.ColumnName = "lugaratencionhabitual";
				colvarLugaratencionhabitual.DataType = DbType.AnsiString;
				colvarLugaratencionhabitual.MaxLength = 80;
				colvarLugaratencionhabitual.AutoIncrement = false;
				colvarLugaratencionhabitual.IsNullable = true;
				colvarLugaratencionhabitual.IsPrimaryKey = false;
				colvarLugaratencionhabitual.IsForeignKey = false;
				colvarLugaratencionhabitual.IsReadOnly = false;
				colvarLugaratencionhabitual.DefaultSetting = @"";
				colvarLugaratencionhabitual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLugaratencionhabitual);
				
				TableSchema.TableColumn colvarDatosfechaenvio = new TableSchema.TableColumn(schema);
				colvarDatosfechaenvio.ColumnName = "datosfechaenvio";
				colvarDatosfechaenvio.DataType = DbType.DateTime;
				colvarDatosfechaenvio.MaxLength = 0;
				colvarDatosfechaenvio.AutoIncrement = false;
				colvarDatosfechaenvio.IsNullable = true;
				colvarDatosfechaenvio.IsPrimaryKey = false;
				colvarDatosfechaenvio.IsForeignKey = false;
				colvarDatosfechaenvio.IsReadOnly = false;
				colvarDatosfechaenvio.DefaultSetting = @"";
				colvarDatosfechaenvio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatosfechaenvio);
				
				TableSchema.TableColumn colvarFechaalta = new TableSchema.TableColumn(schema);
				colvarFechaalta.ColumnName = "fechaalta";
				colvarFechaalta.DataType = DbType.DateTime;
				colvarFechaalta.MaxLength = 0;
				colvarFechaalta.AutoIncrement = false;
				colvarFechaalta.IsNullable = true;
				colvarFechaalta.IsPrimaryKey = false;
				colvarFechaalta.IsForeignKey = false;
				colvarFechaalta.IsReadOnly = false;
				colvarFechaalta.DefaultSetting = @"";
				colvarFechaalta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaalta);
				
				TableSchema.TableColumn colvarPendienteenviar = new TableSchema.TableColumn(schema);
				colvarPendienteenviar.ColumnName = "pendienteenviar";
				colvarPendienteenviar.DataType = DbType.Int16;
				colvarPendienteenviar.MaxLength = 0;
				colvarPendienteenviar.AutoIncrement = false;
				colvarPendienteenviar.IsNullable = true;
				colvarPendienteenviar.IsPrimaryKey = false;
				colvarPendienteenviar.IsForeignKey = false;
				colvarPendienteenviar.IsReadOnly = false;
				colvarPendienteenviar.DefaultSetting = @"";
				colvarPendienteenviar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPendienteenviar);
				
				TableSchema.TableColumn colvarCodigoprovinciaaltadatos = new TableSchema.TableColumn(schema);
				colvarCodigoprovinciaaltadatos.ColumnName = "codigoprovinciaaltadatos";
				colvarCodigoprovinciaaltadatos.DataType = DbType.AnsiStringFixedLength;
				colvarCodigoprovinciaaltadatos.MaxLength = 2;
				colvarCodigoprovinciaaltadatos.AutoIncrement = false;
				colvarCodigoprovinciaaltadatos.IsNullable = true;
				colvarCodigoprovinciaaltadatos.IsPrimaryKey = false;
				colvarCodigoprovinciaaltadatos.IsForeignKey = false;
				colvarCodigoprovinciaaltadatos.IsReadOnly = false;
				colvarCodigoprovinciaaltadatos.DefaultSetting = @"";
				colvarCodigoprovinciaaltadatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoprovinciaaltadatos);
				
				TableSchema.TableColumn colvarCodigouadaltadatos = new TableSchema.TableColumn(schema);
				colvarCodigouadaltadatos.ColumnName = "codigouadaltadatos";
				colvarCodigouadaltadatos.DataType = DbType.AnsiString;
				colvarCodigouadaltadatos.MaxLength = 3;
				colvarCodigouadaltadatos.AutoIncrement = false;
				colvarCodigouadaltadatos.IsNullable = true;
				colvarCodigouadaltadatos.IsPrimaryKey = false;
				colvarCodigouadaltadatos.IsForeignKey = false;
				colvarCodigouadaltadatos.IsReadOnly = false;
				colvarCodigouadaltadatos.DefaultSetting = @"";
				colvarCodigouadaltadatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigouadaltadatos);
				
				TableSchema.TableColumn colvarCodigocialtadatos = new TableSchema.TableColumn(schema);
				colvarCodigocialtadatos.ColumnName = "codigocialtadatos";
				colvarCodigocialtadatos.DataType = DbType.AnsiString;
				colvarCodigocialtadatos.MaxLength = 5;
				colvarCodigocialtadatos.AutoIncrement = false;
				colvarCodigocialtadatos.IsNullable = true;
				colvarCodigocialtadatos.IsPrimaryKey = false;
				colvarCodigocialtadatos.IsForeignKey = false;
				colvarCodigocialtadatos.IsReadOnly = false;
				colvarCodigocialtadatos.DefaultSetting = @"";
				colvarCodigocialtadatos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigocialtadatos);
				
				TableSchema.TableColumn colvarMotivobaja = new TableSchema.TableColumn(schema);
				colvarMotivobaja.ColumnName = "motivobaja";
				colvarMotivobaja.DataType = DbType.Int16;
				colvarMotivobaja.MaxLength = 0;
				colvarMotivobaja.AutoIncrement = false;
				colvarMotivobaja.IsNullable = true;
				colvarMotivobaja.IsPrimaryKey = false;
				colvarMotivobaja.IsForeignKey = false;
				colvarMotivobaja.IsReadOnly = false;
				colvarMotivobaja.DefaultSetting = @"";
				colvarMotivobaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotivobaja);
				
				TableSchema.TableColumn colvarMensajebaja = new TableSchema.TableColumn(schema);
				colvarMensajebaja.ColumnName = "mensajebaja";
				colvarMensajebaja.DataType = DbType.AnsiString;
				colvarMensajebaja.MaxLength = 100;
				colvarMensajebaja.AutoIncrement = false;
				colvarMensajebaja.IsNullable = true;
				colvarMensajebaja.IsPrimaryKey = false;
				colvarMensajebaja.IsForeignKey = false;
				colvarMensajebaja.IsReadOnly = false;
				colvarMensajebaja.DefaultSetting = @"";
				colvarMensajebaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMensajebaja);
				
				TableSchema.TableColumn colvarIdProcesobajaautomatica = new TableSchema.TableColumn(schema);
				colvarIdProcesobajaautomatica.ColumnName = "id_procesobajaautomatica";
				colvarIdProcesobajaautomatica.DataType = DbType.Int32;
				colvarIdProcesobajaautomatica.MaxLength = 0;
				colvarIdProcesobajaautomatica.AutoIncrement = false;
				colvarIdProcesobajaautomatica.IsNullable = true;
				colvarIdProcesobajaautomatica.IsPrimaryKey = false;
				colvarIdProcesobajaautomatica.IsForeignKey = false;
				colvarIdProcesobajaautomatica.IsReadOnly = false;
				colvarIdProcesobajaautomatica.DefaultSetting = @"";
				colvarIdProcesobajaautomatica.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProcesobajaautomatica);
				
				TableSchema.TableColumn colvarPendienteenviaranacion = new TableSchema.TableColumn(schema);
				colvarPendienteenviaranacion.ColumnName = "pendienteenviaranacion";
				colvarPendienteenviaranacion.DataType = DbType.Int16;
				colvarPendienteenviaranacion.MaxLength = 0;
				colvarPendienteenviaranacion.AutoIncrement = false;
				colvarPendienteenviaranacion.IsNullable = true;
				colvarPendienteenviaranacion.IsPrimaryKey = false;
				colvarPendienteenviaranacion.IsForeignKey = false;
				colvarPendienteenviaranacion.IsReadOnly = false;
				colvarPendienteenviaranacion.DefaultSetting = @"";
				colvarPendienteenviaranacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPendienteenviaranacion);
				
				TableSchema.TableColumn colvarFechacarga = new TableSchema.TableColumn(schema);
				colvarFechacarga.ColumnName = "fechacarga";
				colvarFechacarga.DataType = DbType.DateTime;
				colvarFechacarga.MaxLength = 0;
				colvarFechacarga.AutoIncrement = false;
				colvarFechacarga.IsNullable = true;
				colvarFechacarga.IsPrimaryKey = false;
				colvarFechacarga.IsForeignKey = false;
				colvarFechacarga.IsReadOnly = false;
				colvarFechacarga.DefaultSetting = @"";
				colvarFechacarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechacarga);
				
				TableSchema.TableColumn colvarUsuariocarga = new TableSchema.TableColumn(schema);
				colvarUsuariocarga.ColumnName = "usuariocarga";
				colvarUsuariocarga.DataType = DbType.AnsiString;
				colvarUsuariocarga.MaxLength = 10;
				colvarUsuariocarga.AutoIncrement = false;
				colvarUsuariocarga.IsNullable = true;
				colvarUsuariocarga.IsPrimaryKey = false;
				colvarUsuariocarga.IsForeignKey = false;
				colvarUsuariocarga.IsReadOnly = false;
				colvarUsuariocarga.DefaultSetting = @"";
				colvarUsuariocarga.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuariocarga);
				
				TableSchema.TableColumn colvarMenorconvivecontutor = new TableSchema.TableColumn(schema);
				colvarMenorconvivecontutor.ColumnName = "menorconvivecontutor";
				colvarMenorconvivecontutor.DataType = DbType.AnsiStringFixedLength;
				colvarMenorconvivecontutor.MaxLength = 1;
				colvarMenorconvivecontutor.AutoIncrement = false;
				colvarMenorconvivecontutor.IsNullable = true;
				colvarMenorconvivecontutor.IsPrimaryKey = false;
				colvarMenorconvivecontutor.IsForeignKey = false;
				colvarMenorconvivecontutor.IsReadOnly = false;
				colvarMenorconvivecontutor.DefaultSetting = @"";
				colvarMenorconvivecontutor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMenorconvivecontutor);
				
				TableSchema.TableColumn colvarField1 = new TableSchema.TableColumn(schema);
				colvarField1.ColumnName = "field1";
				colvarField1.DataType = DbType.AnsiStringFixedLength;
				colvarField1.MaxLength = 1;
				colvarField1.AutoIncrement = false;
				colvarField1.IsNullable = true;
				colvarField1.IsPrimaryKey = false;
				colvarField1.IsForeignKey = false;
				colvarField1.IsReadOnly = false;
				colvarField1.DefaultSetting = @"";
				colvarField1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarField1);
				
				TableSchema.TableColumn colvarField2 = new TableSchema.TableColumn(schema);
				colvarField2.ColumnName = "field2";
				colvarField2.DataType = DbType.AnsiStringFixedLength;
				colvarField2.MaxLength = 1;
				colvarField2.AutoIncrement = false;
				colvarField2.IsNullable = true;
				colvarField2.IsPrimaryKey = false;
				colvarField2.IsForeignKey = false;
				colvarField2.IsReadOnly = false;
				colvarField2.DefaultSetting = @"";
				colvarField2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarField2);
				
				TableSchema.TableColumn colvarField3 = new TableSchema.TableColumn(schema);
				colvarField3.ColumnName = "field3";
				colvarField3.DataType = DbType.AnsiStringFixedLength;
				colvarField3.MaxLength = 1;
				colvarField3.AutoIncrement = false;
				colvarField3.IsNullable = true;
				colvarField3.IsPrimaryKey = false;
				colvarField3.IsForeignKey = false;
				colvarField3.IsReadOnly = false;
				colvarField3.DefaultSetting = @"";
				colvarField3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarField3);
				
				TableSchema.TableColumn colvarCuieefectorasignado = new TableSchema.TableColumn(schema);
				colvarCuieefectorasignado.ColumnName = "cuieefectorasignado";
				colvarCuieefectorasignado.DataType = DbType.AnsiString;
				colvarCuieefectorasignado.MaxLength = 6;
				colvarCuieefectorasignado.AutoIncrement = false;
				colvarCuieefectorasignado.IsNullable = true;
				colvarCuieefectorasignado.IsPrimaryKey = false;
				colvarCuieefectorasignado.IsForeignKey = false;
				colvarCuieefectorasignado.IsReadOnly = false;
				colvarCuieefectorasignado.DefaultSetting = @"";
				colvarCuieefectorasignado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuieefectorasignado);
				
				TableSchema.TableColumn colvarCuielugaratencionhabitual = new TableSchema.TableColumn(schema);
				colvarCuielugaratencionhabitual.ColumnName = "cuielugaratencionhabitual";
				colvarCuielugaratencionhabitual.DataType = DbType.AnsiString;
				colvarCuielugaratencionhabitual.MaxLength = 6;
				colvarCuielugaratencionhabitual.AutoIncrement = false;
				colvarCuielugaratencionhabitual.IsNullable = true;
				colvarCuielugaratencionhabitual.IsPrimaryKey = false;
				colvarCuielugaratencionhabitual.IsForeignKey = false;
				colvarCuielugaratencionhabitual.IsReadOnly = false;
				colvarCuielugaratencionhabitual.DefaultSetting = @"";
				colvarCuielugaratencionhabitual.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuielugaratencionhabitual);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "usuario";
				colvarUsuario.DataType = DbType.AnsiString;
				colvarUsuario.MaxLength = 20;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = true;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				TableSchema.TableColumn colvarField5 = new TableSchema.TableColumn(schema);
				colvarField5.ColumnName = "field5";
				colvarField5.DataType = DbType.AnsiString;
				colvarField5.MaxLength = 30;
				colvarField5.AutoIncrement = false;
				colvarField5.IsNullable = true;
				colvarField5.IsPrimaryKey = false;
				colvarField5.IsForeignKey = false;
				colvarField5.IsReadOnly = false;
				colvarField5.DefaultSetting = @"";
				colvarField5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarField5);
				
				TableSchema.TableColumn colvarClavebenefprovocobaja = new TableSchema.TableColumn(schema);
				colvarClavebenefprovocobaja.ColumnName = "clavebenefprovocobaja";
				colvarClavebenefprovocobaja.DataType = DbType.AnsiString;
				colvarClavebenefprovocobaja.MaxLength = 16;
				colvarClavebenefprovocobaja.AutoIncrement = false;
				colvarClavebenefprovocobaja.IsNullable = true;
				colvarClavebenefprovocobaja.IsPrimaryKey = false;
				colvarClavebenefprovocobaja.IsForeignKey = false;
				colvarClavebenefprovocobaja.IsReadOnly = false;
				colvarClavebenefprovocobaja.DefaultSetting = @"";
				colvarClavebenefprovocobaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClavebenefprovocobaja);
				
				TableSchema.TableColumn colvarUsuariocreacion = new TableSchema.TableColumn(schema);
				colvarUsuariocreacion.ColumnName = "usuariocreacion";
				colvarUsuariocreacion.DataType = DbType.AnsiString;
				colvarUsuariocreacion.MaxLength = 20;
				colvarUsuariocreacion.AutoIncrement = false;
				colvarUsuariocreacion.IsNullable = true;
				colvarUsuariocreacion.IsPrimaryKey = false;
				colvarUsuariocreacion.IsForeignKey = false;
				colvarUsuariocreacion.IsReadOnly = false;
				colvarUsuariocreacion.DefaultSetting = @"";
				colvarUsuariocreacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuariocreacion);
				
				TableSchema.TableColumn colvarField4 = new TableSchema.TableColumn(schema);
				colvarField4.ColumnName = "field4";
				colvarField4.DataType = DbType.AnsiString;
				colvarField4.MaxLength = 30;
				colvarField4.AutoIncrement = false;
				colvarField4.IsNullable = true;
				colvarField4.IsPrimaryKey = false;
				colvarField4.IsForeignKey = false;
				colvarField4.IsReadOnly = false;
				colvarField4.DefaultSetting = @"";
				colvarField4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarField4);
				
				TableSchema.TableColumn colvarPeriodo = new TableSchema.TableColumn(schema);
				colvarPeriodo.ColumnName = "periodo";
				colvarPeriodo.DataType = DbType.DateTime;
				colvarPeriodo.MaxLength = 0;
				colvarPeriodo.AutoIncrement = false;
				colvarPeriodo.IsNullable = false;
				colvarPeriodo.IsPrimaryKey = false;
				colvarPeriodo.IsForeignKey = false;
				colvarPeriodo.IsReadOnly = false;
				colvarPeriodo.DefaultSetting = @"";
				colvarPeriodo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPeriodo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_historicotemp",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSmiafiliados")]
		[Bindable(true)]
		public string IdSmiafiliados 
		{
			get { return GetColumnValue<string>(Columns.IdSmiafiliados); }
			set { SetColumnValue(Columns.IdSmiafiliados, value); }
		}
		  
		[XmlAttribute("Clavebeneficiario")]
		[Bindable(true)]
		public string Clavebeneficiario 
		{
			get { return GetColumnValue<string>(Columns.Clavebeneficiario); }
			set { SetColumnValue(Columns.Clavebeneficiario, value); }
		}
		  
		[XmlAttribute("Afiapellido")]
		[Bindable(true)]
		public string Afiapellido 
		{
			get { return GetColumnValue<string>(Columns.Afiapellido); }
			set { SetColumnValue(Columns.Afiapellido, value); }
		}
		  
		[XmlAttribute("Afinombre")]
		[Bindable(true)]
		public string Afinombre 
		{
			get { return GetColumnValue<string>(Columns.Afinombre); }
			set { SetColumnValue(Columns.Afinombre, value); }
		}
		  
		[XmlAttribute("Afitipodoc")]
		[Bindable(true)]
		public string Afitipodoc 
		{
			get { return GetColumnValue<string>(Columns.Afitipodoc); }
			set { SetColumnValue(Columns.Afitipodoc, value); }
		}
		  
		[XmlAttribute("Aficlasedoc")]
		[Bindable(true)]
		public string Aficlasedoc 
		{
			get { return GetColumnValue<string>(Columns.Aficlasedoc); }
			set { SetColumnValue(Columns.Aficlasedoc, value); }
		}
		  
		[XmlAttribute("Afidni")]
		[Bindable(true)]
		public string Afidni 
		{
			get { return GetColumnValue<string>(Columns.Afidni); }
			set { SetColumnValue(Columns.Afidni, value); }
		}
		  
		[XmlAttribute("Afisexo")]
		[Bindable(true)]
		public string Afisexo 
		{
			get { return GetColumnValue<string>(Columns.Afisexo); }
			set { SetColumnValue(Columns.Afisexo, value); }
		}
		  
		[XmlAttribute("Afiprovincia")]
		[Bindable(true)]
		public string Afiprovincia 
		{
			get { return GetColumnValue<string>(Columns.Afiprovincia); }
			set { SetColumnValue(Columns.Afiprovincia, value); }
		}
		  
		[XmlAttribute("Afilocalidad")]
		[Bindable(true)]
		public string Afilocalidad 
		{
			get { return GetColumnValue<string>(Columns.Afilocalidad); }
			set { SetColumnValue(Columns.Afilocalidad, value); }
		}
		  
		[XmlAttribute("Afitipocategoria")]
		[Bindable(true)]
		public short? Afitipocategoria 
		{
			get { return GetColumnValue<short?>(Columns.Afitipocategoria); }
			set { SetColumnValue(Columns.Afitipocategoria, value); }
		}
		  
		[XmlAttribute("Afifechanac")]
		[Bindable(true)]
		public DateTime? Afifechanac 
		{
			get { return GetColumnValue<DateTime?>(Columns.Afifechanac); }
			set { SetColumnValue(Columns.Afifechanac, value); }
		}
		  
		[XmlAttribute("Afideclaraindigena")]
		[Bindable(true)]
		public string Afideclaraindigena 
		{
			get { return GetColumnValue<string>(Columns.Afideclaraindigena); }
			set { SetColumnValue(Columns.Afideclaraindigena, value); }
		}
		  
		[XmlAttribute("AfiidLengua")]
		[Bindable(true)]
		public int? AfiidLengua 
		{
			get { return GetColumnValue<int?>(Columns.AfiidLengua); }
			set { SetColumnValue(Columns.AfiidLengua, value); }
		}
		  
		[XmlAttribute("AfiidTribu")]
		[Bindable(true)]
		public int? AfiidTribu 
		{
			get { return GetColumnValue<int?>(Columns.AfiidTribu); }
			set { SetColumnValue(Columns.AfiidTribu, value); }
		}
		  
		[XmlAttribute("Matipodocumento")]
		[Bindable(true)]
		public string Matipodocumento 
		{
			get { return GetColumnValue<string>(Columns.Matipodocumento); }
			set { SetColumnValue(Columns.Matipodocumento, value); }
		}
		  
		[XmlAttribute("Manrodocumento")]
		[Bindable(true)]
		public string Manrodocumento 
		{
			get { return GetColumnValue<string>(Columns.Manrodocumento); }
			set { SetColumnValue(Columns.Manrodocumento, value); }
		}
		  
		[XmlAttribute("Maapellido")]
		[Bindable(true)]
		public string Maapellido 
		{
			get { return GetColumnValue<string>(Columns.Maapellido); }
			set { SetColumnValue(Columns.Maapellido, value); }
		}
		  
		[XmlAttribute("Manombre")]
		[Bindable(true)]
		public string Manombre 
		{
			get { return GetColumnValue<string>(Columns.Manombre); }
			set { SetColumnValue(Columns.Manombre, value); }
		}
		  
		[XmlAttribute("Patipodocumento")]
		[Bindable(true)]
		public string Patipodocumento 
		{
			get { return GetColumnValue<string>(Columns.Patipodocumento); }
			set { SetColumnValue(Columns.Patipodocumento, value); }
		}
		  
		[XmlAttribute("Panrodocumento")]
		[Bindable(true)]
		public string Panrodocumento 
		{
			get { return GetColumnValue<string>(Columns.Panrodocumento); }
			set { SetColumnValue(Columns.Panrodocumento, value); }
		}
		  
		[XmlAttribute("Paapellido")]
		[Bindable(true)]
		public string Paapellido 
		{
			get { return GetColumnValue<string>(Columns.Paapellido); }
			set { SetColumnValue(Columns.Paapellido, value); }
		}
		  
		[XmlAttribute("Panombre")]
		[Bindable(true)]
		public string Panombre 
		{
			get { return GetColumnValue<string>(Columns.Panombre); }
			set { SetColumnValue(Columns.Panombre, value); }
		}
		  
		[XmlAttribute("Otrotipodocumento")]
		[Bindable(true)]
		public string Otrotipodocumento 
		{
			get { return GetColumnValue<string>(Columns.Otrotipodocumento); }
			set { SetColumnValue(Columns.Otrotipodocumento, value); }
		}
		  
		[XmlAttribute("Otronrodocumento")]
		[Bindable(true)]
		public string Otronrodocumento 
		{
			get { return GetColumnValue<string>(Columns.Otronrodocumento); }
			set { SetColumnValue(Columns.Otronrodocumento, value); }
		}
		  
		[XmlAttribute("Otroapellido")]
		[Bindable(true)]
		public string Otroapellido 
		{
			get { return GetColumnValue<string>(Columns.Otroapellido); }
			set { SetColumnValue(Columns.Otroapellido, value); }
		}
		  
		[XmlAttribute("Otronombre")]
		[Bindable(true)]
		public string Otronombre 
		{
			get { return GetColumnValue<string>(Columns.Otronombre); }
			set { SetColumnValue(Columns.Otronombre, value); }
		}
		  
		[XmlAttribute("Otrotiporelacion")]
		[Bindable(true)]
		public int? Otrotiporelacion 
		{
			get { return GetColumnValue<int?>(Columns.Otrotiporelacion); }
			set { SetColumnValue(Columns.Otrotiporelacion, value); }
		}
		  
		[XmlAttribute("Fechainscripcion")]
		[Bindable(true)]
		public DateTime? Fechainscripcion 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechainscripcion); }
			set { SetColumnValue(Columns.Fechainscripcion, value); }
		}
		  
		[XmlAttribute("Fechaaltaefectiva")]
		[Bindable(true)]
		public DateTime? Fechaaltaefectiva 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechaaltaefectiva); }
			set { SetColumnValue(Columns.Fechaaltaefectiva, value); }
		}
		  
		[XmlAttribute("Fechadiagnosticoembarazo")]
		[Bindable(true)]
		public DateTime? Fechadiagnosticoembarazo 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechadiagnosticoembarazo); }
			set { SetColumnValue(Columns.Fechadiagnosticoembarazo, value); }
		}
		  
		[XmlAttribute("Semanasembarazo")]
		[Bindable(true)]
		public int? Semanasembarazo 
		{
			get { return GetColumnValue<int?>(Columns.Semanasembarazo); }
			set { SetColumnValue(Columns.Semanasembarazo, value); }
		}
		  
		[XmlAttribute("Fechaprobableparto")]
		[Bindable(true)]
		public DateTime? Fechaprobableparto 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechaprobableparto); }
			set { SetColumnValue(Columns.Fechaprobableparto, value); }
		}
		  
		[XmlAttribute("Fechaefectivaparto")]
		[Bindable(true)]
		public DateTime? Fechaefectivaparto 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechaefectivaparto); }
			set { SetColumnValue(Columns.Fechaefectivaparto, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public string Activo 
		{
			get { return GetColumnValue<string>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("Accionpendienteconfirmar")]
		[Bindable(true)]
		public string Accionpendienteconfirmar 
		{
			get { return GetColumnValue<string>(Columns.Accionpendienteconfirmar); }
			set { SetColumnValue(Columns.Accionpendienteconfirmar, value); }
		}
		  
		[XmlAttribute("Afidomcalle")]
		[Bindable(true)]
		public string Afidomcalle 
		{
			get { return GetColumnValue<string>(Columns.Afidomcalle); }
			set { SetColumnValue(Columns.Afidomcalle, value); }
		}
		  
		[XmlAttribute("Afidomnro")]
		[Bindable(true)]
		public string Afidomnro 
		{
			get { return GetColumnValue<string>(Columns.Afidomnro); }
			set { SetColumnValue(Columns.Afidomnro, value); }
		}
		  
		[XmlAttribute("Afidommanzana")]
		[Bindable(true)]
		public string Afidommanzana 
		{
			get { return GetColumnValue<string>(Columns.Afidommanzana); }
			set { SetColumnValue(Columns.Afidommanzana, value); }
		}
		  
		[XmlAttribute("Afidompiso")]
		[Bindable(true)]
		public string Afidompiso 
		{
			get { return GetColumnValue<string>(Columns.Afidompiso); }
			set { SetColumnValue(Columns.Afidompiso, value); }
		}
		  
		[XmlAttribute("Afidomdepto")]
		[Bindable(true)]
		public string Afidomdepto 
		{
			get { return GetColumnValue<string>(Columns.Afidomdepto); }
			set { SetColumnValue(Columns.Afidomdepto, value); }
		}
		  
		[XmlAttribute("Afidomentrecalle1")]
		[Bindable(true)]
		public string Afidomentrecalle1 
		{
			get { return GetColumnValue<string>(Columns.Afidomentrecalle1); }
			set { SetColumnValue(Columns.Afidomentrecalle1, value); }
		}
		  
		[XmlAttribute("Afidomentrecalle2")]
		[Bindable(true)]
		public string Afidomentrecalle2 
		{
			get { return GetColumnValue<string>(Columns.Afidomentrecalle2); }
			set { SetColumnValue(Columns.Afidomentrecalle2, value); }
		}
		  
		[XmlAttribute("Afidombarrioparaje")]
		[Bindable(true)]
		public string Afidombarrioparaje 
		{
			get { return GetColumnValue<string>(Columns.Afidombarrioparaje); }
			set { SetColumnValue(Columns.Afidombarrioparaje, value); }
		}
		  
		[XmlAttribute("Afidommunicipio")]
		[Bindable(true)]
		public string Afidommunicipio 
		{
			get { return GetColumnValue<string>(Columns.Afidommunicipio); }
			set { SetColumnValue(Columns.Afidommunicipio, value); }
		}
		  
		[XmlAttribute("Afidomdepartamento")]
		[Bindable(true)]
		public string Afidomdepartamento 
		{
			get { return GetColumnValue<string>(Columns.Afidomdepartamento); }
			set { SetColumnValue(Columns.Afidomdepartamento, value); }
		}
		  
		[XmlAttribute("Afidomlocalidad")]
		[Bindable(true)]
		public string Afidomlocalidad 
		{
			get { return GetColumnValue<string>(Columns.Afidomlocalidad); }
			set { SetColumnValue(Columns.Afidomlocalidad, value); }
		}
		  
		[XmlAttribute("Afidomprovincia")]
		[Bindable(true)]
		public string Afidomprovincia 
		{
			get { return GetColumnValue<string>(Columns.Afidomprovincia); }
			set { SetColumnValue(Columns.Afidomprovincia, value); }
		}
		  
		[XmlAttribute("Afidomcp")]
		[Bindable(true)]
		public string Afidomcp 
		{
			get { return GetColumnValue<string>(Columns.Afidomcp); }
			set { SetColumnValue(Columns.Afidomcp, value); }
		}
		  
		[XmlAttribute("Afitelefono")]
		[Bindable(true)]
		public string Afitelefono 
		{
			get { return GetColumnValue<string>(Columns.Afitelefono); }
			set { SetColumnValue(Columns.Afitelefono, value); }
		}
		  
		[XmlAttribute("Lugaratencionhabitual")]
		[Bindable(true)]
		public string Lugaratencionhabitual 
		{
			get { return GetColumnValue<string>(Columns.Lugaratencionhabitual); }
			set { SetColumnValue(Columns.Lugaratencionhabitual, value); }
		}
		  
		[XmlAttribute("Datosfechaenvio")]
		[Bindable(true)]
		public DateTime? Datosfechaenvio 
		{
			get { return GetColumnValue<DateTime?>(Columns.Datosfechaenvio); }
			set { SetColumnValue(Columns.Datosfechaenvio, value); }
		}
		  
		[XmlAttribute("Fechaalta")]
		[Bindable(true)]
		public DateTime? Fechaalta 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechaalta); }
			set { SetColumnValue(Columns.Fechaalta, value); }
		}
		  
		[XmlAttribute("Pendienteenviar")]
		[Bindable(true)]
		public short? Pendienteenviar 
		{
			get { return GetColumnValue<short?>(Columns.Pendienteenviar); }
			set { SetColumnValue(Columns.Pendienteenviar, value); }
		}
		  
		[XmlAttribute("Codigoprovinciaaltadatos")]
		[Bindable(true)]
		public string Codigoprovinciaaltadatos 
		{
			get { return GetColumnValue<string>(Columns.Codigoprovinciaaltadatos); }
			set { SetColumnValue(Columns.Codigoprovinciaaltadatos, value); }
		}
		  
		[XmlAttribute("Codigouadaltadatos")]
		[Bindable(true)]
		public string Codigouadaltadatos 
		{
			get { return GetColumnValue<string>(Columns.Codigouadaltadatos); }
			set { SetColumnValue(Columns.Codigouadaltadatos, value); }
		}
		  
		[XmlAttribute("Codigocialtadatos")]
		[Bindable(true)]
		public string Codigocialtadatos 
		{
			get { return GetColumnValue<string>(Columns.Codigocialtadatos); }
			set { SetColumnValue(Columns.Codigocialtadatos, value); }
		}
		  
		[XmlAttribute("Motivobaja")]
		[Bindable(true)]
		public short? Motivobaja 
		{
			get { return GetColumnValue<short?>(Columns.Motivobaja); }
			set { SetColumnValue(Columns.Motivobaja, value); }
		}
		  
		[XmlAttribute("Mensajebaja")]
		[Bindable(true)]
		public string Mensajebaja 
		{
			get { return GetColumnValue<string>(Columns.Mensajebaja); }
			set { SetColumnValue(Columns.Mensajebaja, value); }
		}
		  
		[XmlAttribute("IdProcesobajaautomatica")]
		[Bindable(true)]
		public int? IdProcesobajaautomatica 
		{
			get { return GetColumnValue<int?>(Columns.IdProcesobajaautomatica); }
			set { SetColumnValue(Columns.IdProcesobajaautomatica, value); }
		}
		  
		[XmlAttribute("Pendienteenviaranacion")]
		[Bindable(true)]
		public short? Pendienteenviaranacion 
		{
			get { return GetColumnValue<short?>(Columns.Pendienteenviaranacion); }
			set { SetColumnValue(Columns.Pendienteenviaranacion, value); }
		}
		  
		[XmlAttribute("Fechacarga")]
		[Bindable(true)]
		public DateTime? Fechacarga 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fechacarga); }
			set { SetColumnValue(Columns.Fechacarga, value); }
		}
		  
		[XmlAttribute("Usuariocarga")]
		[Bindable(true)]
		public string Usuariocarga 
		{
			get { return GetColumnValue<string>(Columns.Usuariocarga); }
			set { SetColumnValue(Columns.Usuariocarga, value); }
		}
		  
		[XmlAttribute("Menorconvivecontutor")]
		[Bindable(true)]
		public string Menorconvivecontutor 
		{
			get { return GetColumnValue<string>(Columns.Menorconvivecontutor); }
			set { SetColumnValue(Columns.Menorconvivecontutor, value); }
		}
		  
		[XmlAttribute("Field1")]
		[Bindable(true)]
		public string Field1 
		{
			get { return GetColumnValue<string>(Columns.Field1); }
			set { SetColumnValue(Columns.Field1, value); }
		}
		  
		[XmlAttribute("Field2")]
		[Bindable(true)]
		public string Field2 
		{
			get { return GetColumnValue<string>(Columns.Field2); }
			set { SetColumnValue(Columns.Field2, value); }
		}
		  
		[XmlAttribute("Field3")]
		[Bindable(true)]
		public string Field3 
		{
			get { return GetColumnValue<string>(Columns.Field3); }
			set { SetColumnValue(Columns.Field3, value); }
		}
		  
		[XmlAttribute("Cuieefectorasignado")]
		[Bindable(true)]
		public string Cuieefectorasignado 
		{
			get { return GetColumnValue<string>(Columns.Cuieefectorasignado); }
			set { SetColumnValue(Columns.Cuieefectorasignado, value); }
		}
		  
		[XmlAttribute("Cuielugaratencionhabitual")]
		[Bindable(true)]
		public string Cuielugaratencionhabitual 
		{
			get { return GetColumnValue<string>(Columns.Cuielugaratencionhabitual); }
			set { SetColumnValue(Columns.Cuielugaratencionhabitual, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public string Usuario 
		{
			get { return GetColumnValue<string>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("Field5")]
		[Bindable(true)]
		public string Field5 
		{
			get { return GetColumnValue<string>(Columns.Field5); }
			set { SetColumnValue(Columns.Field5, value); }
		}
		  
		[XmlAttribute("Clavebenefprovocobaja")]
		[Bindable(true)]
		public string Clavebenefprovocobaja 
		{
			get { return GetColumnValue<string>(Columns.Clavebenefprovocobaja); }
			set { SetColumnValue(Columns.Clavebenefprovocobaja, value); }
		}
		  
		[XmlAttribute("Usuariocreacion")]
		[Bindable(true)]
		public string Usuariocreacion 
		{
			get { return GetColumnValue<string>(Columns.Usuariocreacion); }
			set { SetColumnValue(Columns.Usuariocreacion, value); }
		}
		  
		[XmlAttribute("Field4")]
		[Bindable(true)]
		public string Field4 
		{
			get { return GetColumnValue<string>(Columns.Field4); }
			set { SetColumnValue(Columns.Field4, value); }
		}
		  
		[XmlAttribute("Periodo")]
		[Bindable(true)]
		public DateTime Periodo 
		{
			get { return GetColumnValue<DateTime>(Columns.Periodo); }
			set { SetColumnValue(Columns.Periodo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varIdSmiafiliados,string varClavebeneficiario,string varAfiapellido,string varAfinombre,string varAfitipodoc,string varAficlasedoc,string varAfidni,string varAfisexo,string varAfiprovincia,string varAfilocalidad,short? varAfitipocategoria,DateTime? varAfifechanac,string varAfideclaraindigena,int? varAfiidLengua,int? varAfiidTribu,string varMatipodocumento,string varManrodocumento,string varMaapellido,string varManombre,string varPatipodocumento,string varPanrodocumento,string varPaapellido,string varPanombre,string varOtrotipodocumento,string varOtronrodocumento,string varOtroapellido,string varOtronombre,int? varOtrotiporelacion,DateTime? varFechainscripcion,DateTime? varFechaaltaefectiva,DateTime? varFechadiagnosticoembarazo,int? varSemanasembarazo,DateTime? varFechaprobableparto,DateTime? varFechaefectivaparto,string varActivo,string varAccionpendienteconfirmar,string varAfidomcalle,string varAfidomnro,string varAfidommanzana,string varAfidompiso,string varAfidomdepto,string varAfidomentrecalle1,string varAfidomentrecalle2,string varAfidombarrioparaje,string varAfidommunicipio,string varAfidomdepartamento,string varAfidomlocalidad,string varAfidomprovincia,string varAfidomcp,string varAfitelefono,string varLugaratencionhabitual,DateTime? varDatosfechaenvio,DateTime? varFechaalta,short? varPendienteenviar,string varCodigoprovinciaaltadatos,string varCodigouadaltadatos,string varCodigocialtadatos,short? varMotivobaja,string varMensajebaja,int? varIdProcesobajaautomatica,short? varPendienteenviaranacion,DateTime? varFechacarga,string varUsuariocarga,string varMenorconvivecontutor,string varField1,string varField2,string varField3,string varCuieefectorasignado,string varCuielugaratencionhabitual,string varUsuario,string varField5,string varClavebenefprovocobaja,string varUsuariocreacion,string varField4,DateTime varPeriodo)
		{
			PnHistoricotemp item = new PnHistoricotemp();
			
			item.IdSmiafiliados = varIdSmiafiliados;
			
			item.Clavebeneficiario = varClavebeneficiario;
			
			item.Afiapellido = varAfiapellido;
			
			item.Afinombre = varAfinombre;
			
			item.Afitipodoc = varAfitipodoc;
			
			item.Aficlasedoc = varAficlasedoc;
			
			item.Afidni = varAfidni;
			
			item.Afisexo = varAfisexo;
			
			item.Afiprovincia = varAfiprovincia;
			
			item.Afilocalidad = varAfilocalidad;
			
			item.Afitipocategoria = varAfitipocategoria;
			
			item.Afifechanac = varAfifechanac;
			
			item.Afideclaraindigena = varAfideclaraindigena;
			
			item.AfiidLengua = varAfiidLengua;
			
			item.AfiidTribu = varAfiidTribu;
			
			item.Matipodocumento = varMatipodocumento;
			
			item.Manrodocumento = varManrodocumento;
			
			item.Maapellido = varMaapellido;
			
			item.Manombre = varManombre;
			
			item.Patipodocumento = varPatipodocumento;
			
			item.Panrodocumento = varPanrodocumento;
			
			item.Paapellido = varPaapellido;
			
			item.Panombre = varPanombre;
			
			item.Otrotipodocumento = varOtrotipodocumento;
			
			item.Otronrodocumento = varOtronrodocumento;
			
			item.Otroapellido = varOtroapellido;
			
			item.Otronombre = varOtronombre;
			
			item.Otrotiporelacion = varOtrotiporelacion;
			
			item.Fechainscripcion = varFechainscripcion;
			
			item.Fechaaltaefectiva = varFechaaltaefectiva;
			
			item.Fechadiagnosticoembarazo = varFechadiagnosticoembarazo;
			
			item.Semanasembarazo = varSemanasembarazo;
			
			item.Fechaprobableparto = varFechaprobableparto;
			
			item.Fechaefectivaparto = varFechaefectivaparto;
			
			item.Activo = varActivo;
			
			item.Accionpendienteconfirmar = varAccionpendienteconfirmar;
			
			item.Afidomcalle = varAfidomcalle;
			
			item.Afidomnro = varAfidomnro;
			
			item.Afidommanzana = varAfidommanzana;
			
			item.Afidompiso = varAfidompiso;
			
			item.Afidomdepto = varAfidomdepto;
			
			item.Afidomentrecalle1 = varAfidomentrecalle1;
			
			item.Afidomentrecalle2 = varAfidomentrecalle2;
			
			item.Afidombarrioparaje = varAfidombarrioparaje;
			
			item.Afidommunicipio = varAfidommunicipio;
			
			item.Afidomdepartamento = varAfidomdepartamento;
			
			item.Afidomlocalidad = varAfidomlocalidad;
			
			item.Afidomprovincia = varAfidomprovincia;
			
			item.Afidomcp = varAfidomcp;
			
			item.Afitelefono = varAfitelefono;
			
			item.Lugaratencionhabitual = varLugaratencionhabitual;
			
			item.Datosfechaenvio = varDatosfechaenvio;
			
			item.Fechaalta = varFechaalta;
			
			item.Pendienteenviar = varPendienteenviar;
			
			item.Codigoprovinciaaltadatos = varCodigoprovinciaaltadatos;
			
			item.Codigouadaltadatos = varCodigouadaltadatos;
			
			item.Codigocialtadatos = varCodigocialtadatos;
			
			item.Motivobaja = varMotivobaja;
			
			item.Mensajebaja = varMensajebaja;
			
			item.IdProcesobajaautomatica = varIdProcesobajaautomatica;
			
			item.Pendienteenviaranacion = varPendienteenviaranacion;
			
			item.Fechacarga = varFechacarga;
			
			item.Usuariocarga = varUsuariocarga;
			
			item.Menorconvivecontutor = varMenorconvivecontutor;
			
			item.Field1 = varField1;
			
			item.Field2 = varField2;
			
			item.Field3 = varField3;
			
			item.Cuieefectorasignado = varCuieefectorasignado;
			
			item.Cuielugaratencionhabitual = varCuielugaratencionhabitual;
			
			item.Usuario = varUsuario;
			
			item.Field5 = varField5;
			
			item.Clavebenefprovocobaja = varClavebenefprovocobaja;
			
			item.Usuariocreacion = varUsuariocreacion;
			
			item.Field4 = varField4;
			
			item.Periodo = varPeriodo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varIdSmiafiliados,string varClavebeneficiario,string varAfiapellido,string varAfinombre,string varAfitipodoc,string varAficlasedoc,string varAfidni,string varAfisexo,string varAfiprovincia,string varAfilocalidad,short? varAfitipocategoria,DateTime? varAfifechanac,string varAfideclaraindigena,int? varAfiidLengua,int? varAfiidTribu,string varMatipodocumento,string varManrodocumento,string varMaapellido,string varManombre,string varPatipodocumento,string varPanrodocumento,string varPaapellido,string varPanombre,string varOtrotipodocumento,string varOtronrodocumento,string varOtroapellido,string varOtronombre,int? varOtrotiporelacion,DateTime? varFechainscripcion,DateTime? varFechaaltaefectiva,DateTime? varFechadiagnosticoembarazo,int? varSemanasembarazo,DateTime? varFechaprobableparto,DateTime? varFechaefectivaparto,string varActivo,string varAccionpendienteconfirmar,string varAfidomcalle,string varAfidomnro,string varAfidommanzana,string varAfidompiso,string varAfidomdepto,string varAfidomentrecalle1,string varAfidomentrecalle2,string varAfidombarrioparaje,string varAfidommunicipio,string varAfidomdepartamento,string varAfidomlocalidad,string varAfidomprovincia,string varAfidomcp,string varAfitelefono,string varLugaratencionhabitual,DateTime? varDatosfechaenvio,DateTime? varFechaalta,short? varPendienteenviar,string varCodigoprovinciaaltadatos,string varCodigouadaltadatos,string varCodigocialtadatos,short? varMotivobaja,string varMensajebaja,int? varIdProcesobajaautomatica,short? varPendienteenviaranacion,DateTime? varFechacarga,string varUsuariocarga,string varMenorconvivecontutor,string varField1,string varField2,string varField3,string varCuieefectorasignado,string varCuielugaratencionhabitual,string varUsuario,string varField5,string varClavebenefprovocobaja,string varUsuariocreacion,string varField4,DateTime varPeriodo)
		{
			PnHistoricotemp item = new PnHistoricotemp();
			
				item.IdSmiafiliados = varIdSmiafiliados;
			
				item.Clavebeneficiario = varClavebeneficiario;
			
				item.Afiapellido = varAfiapellido;
			
				item.Afinombre = varAfinombre;
			
				item.Afitipodoc = varAfitipodoc;
			
				item.Aficlasedoc = varAficlasedoc;
			
				item.Afidni = varAfidni;
			
				item.Afisexo = varAfisexo;
			
				item.Afiprovincia = varAfiprovincia;
			
				item.Afilocalidad = varAfilocalidad;
			
				item.Afitipocategoria = varAfitipocategoria;
			
				item.Afifechanac = varAfifechanac;
			
				item.Afideclaraindigena = varAfideclaraindigena;
			
				item.AfiidLengua = varAfiidLengua;
			
				item.AfiidTribu = varAfiidTribu;
			
				item.Matipodocumento = varMatipodocumento;
			
				item.Manrodocumento = varManrodocumento;
			
				item.Maapellido = varMaapellido;
			
				item.Manombre = varManombre;
			
				item.Patipodocumento = varPatipodocumento;
			
				item.Panrodocumento = varPanrodocumento;
			
				item.Paapellido = varPaapellido;
			
				item.Panombre = varPanombre;
			
				item.Otrotipodocumento = varOtrotipodocumento;
			
				item.Otronrodocumento = varOtronrodocumento;
			
				item.Otroapellido = varOtroapellido;
			
				item.Otronombre = varOtronombre;
			
				item.Otrotiporelacion = varOtrotiporelacion;
			
				item.Fechainscripcion = varFechainscripcion;
			
				item.Fechaaltaefectiva = varFechaaltaefectiva;
			
				item.Fechadiagnosticoembarazo = varFechadiagnosticoembarazo;
			
				item.Semanasembarazo = varSemanasembarazo;
			
				item.Fechaprobableparto = varFechaprobableparto;
			
				item.Fechaefectivaparto = varFechaefectivaparto;
			
				item.Activo = varActivo;
			
				item.Accionpendienteconfirmar = varAccionpendienteconfirmar;
			
				item.Afidomcalle = varAfidomcalle;
			
				item.Afidomnro = varAfidomnro;
			
				item.Afidommanzana = varAfidommanzana;
			
				item.Afidompiso = varAfidompiso;
			
				item.Afidomdepto = varAfidomdepto;
			
				item.Afidomentrecalle1 = varAfidomentrecalle1;
			
				item.Afidomentrecalle2 = varAfidomentrecalle2;
			
				item.Afidombarrioparaje = varAfidombarrioparaje;
			
				item.Afidommunicipio = varAfidommunicipio;
			
				item.Afidomdepartamento = varAfidomdepartamento;
			
				item.Afidomlocalidad = varAfidomlocalidad;
			
				item.Afidomprovincia = varAfidomprovincia;
			
				item.Afidomcp = varAfidomcp;
			
				item.Afitelefono = varAfitelefono;
			
				item.Lugaratencionhabitual = varLugaratencionhabitual;
			
				item.Datosfechaenvio = varDatosfechaenvio;
			
				item.Fechaalta = varFechaalta;
			
				item.Pendienteenviar = varPendienteenviar;
			
				item.Codigoprovinciaaltadatos = varCodigoprovinciaaltadatos;
			
				item.Codigouadaltadatos = varCodigouadaltadatos;
			
				item.Codigocialtadatos = varCodigocialtadatos;
			
				item.Motivobaja = varMotivobaja;
			
				item.Mensajebaja = varMensajebaja;
			
				item.IdProcesobajaautomatica = varIdProcesobajaautomatica;
			
				item.Pendienteenviaranacion = varPendienteenviaranacion;
			
				item.Fechacarga = varFechacarga;
			
				item.Usuariocarga = varUsuariocarga;
			
				item.Menorconvivecontutor = varMenorconvivecontutor;
			
				item.Field1 = varField1;
			
				item.Field2 = varField2;
			
				item.Field3 = varField3;
			
				item.Cuieefectorasignado = varCuieefectorasignado;
			
				item.Cuielugaratencionhabitual = varCuielugaratencionhabitual;
			
				item.Usuario = varUsuario;
			
				item.Field5 = varField5;
			
				item.Clavebenefprovocobaja = varClavebenefprovocobaja;
			
				item.Usuariocreacion = varUsuariocreacion;
			
				item.Field4 = varField4;
			
				item.Periodo = varPeriodo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSmiafiliadosColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClavebeneficiarioColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AfiapellidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AfinombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AfitipodocColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AficlasedocColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidniColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AfisexoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn AfiprovinciaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AfilocalidadColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn AfitipocategoriaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn AfifechanacColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AfideclaraindigenaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn AfiidLenguaColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AfiidTribuColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MatipodocumentoColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ManrodocumentoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn MaapellidoColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ManombreColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn PatipodocumentoColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn PanrodocumentoColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn PaapellidoColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn PanombreColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrotipodocumentoColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn OtronrodocumentoColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn OtroapellidoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn OtronombreColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn OtrotiporelacionColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn FechainscripcionColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaaltaefectivaColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn FechadiagnosticoembarazoColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn SemanasembarazoColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaprobablepartoColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaefectivapartoColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn AccionpendienteconfirmarColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomcalleColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomnroColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidommanzanaColumn
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidompisoColumn
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomdeptoColumn
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        public static TableSchema.TableColumn Afidomentrecalle1Column
        {
            get { return Schema.Columns[41]; }
        }
        
        
        
        public static TableSchema.TableColumn Afidomentrecalle2Column
        {
            get { return Schema.Columns[42]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidombarrioparajeColumn
        {
            get { return Schema.Columns[43]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidommunicipioColumn
        {
            get { return Schema.Columns[44]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomdepartamentoColumn
        {
            get { return Schema.Columns[45]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomlocalidadColumn
        {
            get { return Schema.Columns[46]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomprovinciaColumn
        {
            get { return Schema.Columns[47]; }
        }
        
        
        
        public static TableSchema.TableColumn AfidomcpColumn
        {
            get { return Schema.Columns[48]; }
        }
        
        
        
        public static TableSchema.TableColumn AfitelefonoColumn
        {
            get { return Schema.Columns[49]; }
        }
        
        
        
        public static TableSchema.TableColumn LugaratencionhabitualColumn
        {
            get { return Schema.Columns[50]; }
        }
        
        
        
        public static TableSchema.TableColumn DatosfechaenvioColumn
        {
            get { return Schema.Columns[51]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaaltaColumn
        {
            get { return Schema.Columns[52]; }
        }
        
        
        
        public static TableSchema.TableColumn PendienteenviarColumn
        {
            get { return Schema.Columns[53]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoprovinciaaltadatosColumn
        {
            get { return Schema.Columns[54]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigouadaltadatosColumn
        {
            get { return Schema.Columns[55]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigocialtadatosColumn
        {
            get { return Schema.Columns[56]; }
        }
        
        
        
        public static TableSchema.TableColumn MotivobajaColumn
        {
            get { return Schema.Columns[57]; }
        }
        
        
        
        public static TableSchema.TableColumn MensajebajaColumn
        {
            get { return Schema.Columns[58]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProcesobajaautomaticaColumn
        {
            get { return Schema.Columns[59]; }
        }
        
        
        
        public static TableSchema.TableColumn PendienteenviaranacionColumn
        {
            get { return Schema.Columns[60]; }
        }
        
        
        
        public static TableSchema.TableColumn FechacargaColumn
        {
            get { return Schema.Columns[61]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuariocargaColumn
        {
            get { return Schema.Columns[62]; }
        }
        
        
        
        public static TableSchema.TableColumn MenorconvivecontutorColumn
        {
            get { return Schema.Columns[63]; }
        }
        
        
        
        public static TableSchema.TableColumn Field1Column
        {
            get { return Schema.Columns[64]; }
        }
        
        
        
        public static TableSchema.TableColumn Field2Column
        {
            get { return Schema.Columns[65]; }
        }
        
        
        
        public static TableSchema.TableColumn Field3Column
        {
            get { return Schema.Columns[66]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieefectorasignadoColumn
        {
            get { return Schema.Columns[67]; }
        }
        
        
        
        public static TableSchema.TableColumn CuielugaratencionhabitualColumn
        {
            get { return Schema.Columns[68]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[69]; }
        }
        
        
        
        public static TableSchema.TableColumn Field5Column
        {
            get { return Schema.Columns[70]; }
        }
        
        
        
        public static TableSchema.TableColumn ClavebenefprovocobajaColumn
        {
            get { return Schema.Columns[71]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuariocreacionColumn
        {
            get { return Schema.Columns[72]; }
        }
        
        
        
        public static TableSchema.TableColumn Field4Column
        {
            get { return Schema.Columns[73]; }
        }
        
        
        
        public static TableSchema.TableColumn PeriodoColumn
        {
            get { return Schema.Columns[74]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSmiafiliados = @"id_smiafiliados";
			 public static string Clavebeneficiario = @"clavebeneficiario";
			 public static string Afiapellido = @"afiapellido";
			 public static string Afinombre = @"afinombre";
			 public static string Afitipodoc = @"afitipodoc";
			 public static string Aficlasedoc = @"aficlasedoc";
			 public static string Afidni = @"afidni";
			 public static string Afisexo = @"afisexo";
			 public static string Afiprovincia = @"afiprovincia";
			 public static string Afilocalidad = @"afilocalidad";
			 public static string Afitipocategoria = @"afitipocategoria";
			 public static string Afifechanac = @"afifechanac";
			 public static string Afideclaraindigena = @"afideclaraindigena";
			 public static string AfiidLengua = @"afiid_lengua";
			 public static string AfiidTribu = @"afiid_tribu";
			 public static string Matipodocumento = @"matipodocumento";
			 public static string Manrodocumento = @"manrodocumento";
			 public static string Maapellido = @"maapellido";
			 public static string Manombre = @"manombre";
			 public static string Patipodocumento = @"patipodocumento";
			 public static string Panrodocumento = @"panrodocumento";
			 public static string Paapellido = @"paapellido";
			 public static string Panombre = @"panombre";
			 public static string Otrotipodocumento = @"otrotipodocumento";
			 public static string Otronrodocumento = @"otronrodocumento";
			 public static string Otroapellido = @"otroapellido";
			 public static string Otronombre = @"otronombre";
			 public static string Otrotiporelacion = @"otrotiporelacion";
			 public static string Fechainscripcion = @"fechainscripcion";
			 public static string Fechaaltaefectiva = @"fechaaltaefectiva";
			 public static string Fechadiagnosticoembarazo = @"fechadiagnosticoembarazo";
			 public static string Semanasembarazo = @"semanasembarazo";
			 public static string Fechaprobableparto = @"fechaprobableparto";
			 public static string Fechaefectivaparto = @"fechaefectivaparto";
			 public static string Activo = @"activo";
			 public static string Accionpendienteconfirmar = @"accionpendienteconfirmar";
			 public static string Afidomcalle = @"afidomcalle";
			 public static string Afidomnro = @"afidomnro";
			 public static string Afidommanzana = @"afidommanzana";
			 public static string Afidompiso = @"afidompiso";
			 public static string Afidomdepto = @"afidomdepto";
			 public static string Afidomentrecalle1 = @"afidomentrecalle1";
			 public static string Afidomentrecalle2 = @"afidomentrecalle2";
			 public static string Afidombarrioparaje = @"afidombarrioparaje";
			 public static string Afidommunicipio = @"afidommunicipio";
			 public static string Afidomdepartamento = @"afidomdepartamento";
			 public static string Afidomlocalidad = @"afidomlocalidad";
			 public static string Afidomprovincia = @"afidomprovincia";
			 public static string Afidomcp = @"afidomcp";
			 public static string Afitelefono = @"afitelefono";
			 public static string Lugaratencionhabitual = @"lugaratencionhabitual";
			 public static string Datosfechaenvio = @"datosfechaenvio";
			 public static string Fechaalta = @"fechaalta";
			 public static string Pendienteenviar = @"pendienteenviar";
			 public static string Codigoprovinciaaltadatos = @"codigoprovinciaaltadatos";
			 public static string Codigouadaltadatos = @"codigouadaltadatos";
			 public static string Codigocialtadatos = @"codigocialtadatos";
			 public static string Motivobaja = @"motivobaja";
			 public static string Mensajebaja = @"mensajebaja";
			 public static string IdProcesobajaautomatica = @"id_procesobajaautomatica";
			 public static string Pendienteenviaranacion = @"pendienteenviaranacion";
			 public static string Fechacarga = @"fechacarga";
			 public static string Usuariocarga = @"usuariocarga";
			 public static string Menorconvivecontutor = @"menorconvivecontutor";
			 public static string Field1 = @"field1";
			 public static string Field2 = @"field2";
			 public static string Field3 = @"field3";
			 public static string Cuieefectorasignado = @"cuieefectorasignado";
			 public static string Cuielugaratencionhabitual = @"cuielugaratencionhabitual";
			 public static string Usuario = @"usuario";
			 public static string Field5 = @"field5";
			 public static string Clavebenefprovocobaja = @"clavebenefprovocobaja";
			 public static string Usuariocreacion = @"usuariocreacion";
			 public static string Field4 = @"field4";
			 public static string Periodo = @"periodo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
