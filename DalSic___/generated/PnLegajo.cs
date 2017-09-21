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
	/// Strongly-typed collection for the PnLegajo class.
	/// </summary>
    [Serializable]
	public partial class PnLegajoCollection : ActiveList<PnLegajo, PnLegajoCollection>
	{	   
		public PnLegajoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnLegajoCollection</returns>
		public PnLegajoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnLegajo o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_legajos table.
	/// </summary>
	[Serializable]
	public partial class PnLegajo : ActiveRecord<PnLegajo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnLegajo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnLegajo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnLegajo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnLegajo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_legajos", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLegajo = new TableSchema.TableColumn(schema);
				colvarIdLegajo.ColumnName = "id_legajo";
				colvarIdLegajo.DataType = DbType.Int32;
				colvarIdLegajo.MaxLength = 0;
				colvarIdLegajo.AutoIncrement = true;
				colvarIdLegajo.IsNullable = false;
				colvarIdLegajo.IsPrimaryKey = true;
				colvarIdLegajo.IsForeignKey = false;
				colvarIdLegajo.IsReadOnly = false;
				colvarIdLegajo.DefaultSetting = @"";
				colvarIdLegajo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLegajo);
				
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
				
				TableSchema.TableColumn colvarDni = new TableSchema.TableColumn(schema);
				colvarDni.ColumnName = "dni";
				colvarDni.DataType = DbType.AnsiString;
				colvarDni.MaxLength = -1;
				colvarDni.AutoIncrement = false;
				colvarDni.IsNullable = true;
				colvarDni.IsPrimaryKey = false;
				colvarDni.IsForeignKey = false;
				colvarDni.IsReadOnly = false;
				colvarDni.DefaultSetting = @"";
				colvarDni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDni);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fecha_nacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarLugarNacimiento = new TableSchema.TableColumn(schema);
				colvarLugarNacimiento.ColumnName = "lugar_nacimiento";
				colvarLugarNacimiento.DataType = DbType.AnsiString;
				colvarLugarNacimiento.MaxLength = -1;
				colvarLugarNacimiento.AutoIncrement = false;
				colvarLugarNacimiento.IsNullable = true;
				colvarLugarNacimiento.IsPrimaryKey = false;
				colvarLugarNacimiento.IsForeignKey = false;
				colvarLugarNacimiento.IsReadOnly = false;
				colvarLugarNacimiento.DefaultSetting = @"";
				colvarLugarNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLugarNacimiento);
				
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
				
				TableSchema.TableColumn colvarTelCelular = new TableSchema.TableColumn(schema);
				colvarTelCelular.ColumnName = "tel_celular";
				colvarTelCelular.DataType = DbType.AnsiString;
				colvarTelCelular.MaxLength = -1;
				colvarTelCelular.AutoIncrement = false;
				colvarTelCelular.IsNullable = true;
				colvarTelCelular.IsPrimaryKey = false;
				colvarTelCelular.IsForeignKey = false;
				colvarTelCelular.IsReadOnly = false;
				colvarTelCelular.DefaultSetting = @"";
				colvarTelCelular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelCelular);
				
				TableSchema.TableColumn colvarTelParticular = new TableSchema.TableColumn(schema);
				colvarTelParticular.ColumnName = "tel_particular";
				colvarTelParticular.DataType = DbType.AnsiString;
				colvarTelParticular.MaxLength = -1;
				colvarTelParticular.AutoIncrement = false;
				colvarTelParticular.IsNullable = true;
				colvarTelParticular.IsPrimaryKey = false;
				colvarTelParticular.IsForeignKey = false;
				colvarTelParticular.IsReadOnly = false;
				colvarTelParticular.DefaultSetting = @"";
				colvarTelParticular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelParticular);
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "localidad";
				colvarLocalidad.DataType = DbType.AnsiString;
				colvarLocalidad.MaxLength = -1;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarProvincia = new TableSchema.TableColumn(schema);
				colvarProvincia.ColumnName = "provincia";
				colvarProvincia.DataType = DbType.AnsiString;
				colvarProvincia.MaxLength = -1;
				colvarProvincia.AutoIncrement = false;
				colvarProvincia.IsNullable = true;
				colvarProvincia.IsPrimaryKey = false;
				colvarProvincia.IsForeignKey = false;
				colvarProvincia.IsReadOnly = false;
				colvarProvincia.DefaultSetting = @"";
				colvarProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProvincia);
				
				TableSchema.TableColumn colvarEmNombre = new TableSchema.TableColumn(schema);
				colvarEmNombre.ColumnName = "em_nombre";
				colvarEmNombre.DataType = DbType.AnsiString;
				colvarEmNombre.MaxLength = -1;
				colvarEmNombre.AutoIncrement = false;
				colvarEmNombre.IsNullable = true;
				colvarEmNombre.IsPrimaryKey = false;
				colvarEmNombre.IsForeignKey = false;
				colvarEmNombre.IsReadOnly = false;
				colvarEmNombre.DefaultSetting = @"";
				colvarEmNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmNombre);
				
				TableSchema.TableColumn colvarEmTelefono = new TableSchema.TableColumn(schema);
				colvarEmTelefono.ColumnName = "em_telefono";
				colvarEmTelefono.DataType = DbType.AnsiString;
				colvarEmTelefono.MaxLength = -1;
				colvarEmTelefono.AutoIncrement = false;
				colvarEmTelefono.IsNullable = true;
				colvarEmTelefono.IsPrimaryKey = false;
				colvarEmTelefono.IsForeignKey = false;
				colvarEmTelefono.IsReadOnly = false;
				colvarEmTelefono.DefaultSetting = @"";
				colvarEmTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmTelefono);
				
				TableSchema.TableColumn colvarEmDireccion = new TableSchema.TableColumn(schema);
				colvarEmDireccion.ColumnName = "em_direccion";
				colvarEmDireccion.DataType = DbType.AnsiString;
				colvarEmDireccion.MaxLength = -1;
				colvarEmDireccion.AutoIncrement = false;
				colvarEmDireccion.IsNullable = true;
				colvarEmDireccion.IsPrimaryKey = false;
				colvarEmDireccion.IsForeignKey = false;
				colvarEmDireccion.IsReadOnly = false;
				colvarEmDireccion.DefaultSetting = @"";
				colvarEmDireccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmDireccion);
				
				TableSchema.TableColumn colvarEmRelacion = new TableSchema.TableColumn(schema);
				colvarEmRelacion.ColumnName = "em_relacion";
				colvarEmRelacion.DataType = DbType.AnsiString;
				colvarEmRelacion.MaxLength = -1;
				colvarEmRelacion.AutoIncrement = false;
				colvarEmRelacion.IsNullable = true;
				colvarEmRelacion.IsPrimaryKey = false;
				colvarEmRelacion.IsForeignKey = false;
				colvarEmRelacion.IsReadOnly = false;
				colvarEmRelacion.DefaultSetting = @"";
				colvarEmRelacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmRelacion);
				
				TableSchema.TableColumn colvarComentarios = new TableSchema.TableColumn(schema);
				colvarComentarios.ColumnName = "comentarios";
				colvarComentarios.DataType = DbType.AnsiString;
				colvarComentarios.MaxLength = -1;
				colvarComentarios.AutoIncrement = false;
				colvarComentarios.IsNullable = true;
				colvarComentarios.IsPrimaryKey = false;
				colvarComentarios.IsForeignKey = false;
				colvarComentarios.IsReadOnly = false;
				colvarComentarios.DefaultSetting = @"";
				colvarComentarios.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentarios);
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = false;
				colvarIdUsuario.IsNullable = true;
				colvarIdUsuario.IsPrimaryKey = false;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarIdEvaluador = new TableSchema.TableColumn(schema);
				colvarIdEvaluador.ColumnName = "id_evaluador";
				colvarIdEvaluador.DataType = DbType.Int32;
				colvarIdEvaluador.MaxLength = 0;
				colvarIdEvaluador.AutoIncrement = false;
				colvarIdEvaluador.IsNullable = true;
				colvarIdEvaluador.IsPrimaryKey = false;
				colvarIdEvaluador.IsForeignKey = false;
				colvarIdEvaluador.IsReadOnly = false;
				colvarIdEvaluador.DefaultSetting = @"";
				colvarIdEvaluador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdEvaluador);
				
				TableSchema.TableColumn colvarFechaIngreso = new TableSchema.TableColumn(schema);
				colvarFechaIngreso.ColumnName = "fecha_ingreso";
				colvarFechaIngreso.DataType = DbType.DateTime;
				colvarFechaIngreso.MaxLength = 0;
				colvarFechaIngreso.AutoIncrement = false;
				colvarFechaIngreso.IsNullable = true;
				colvarFechaIngreso.IsPrimaryKey = false;
				colvarFechaIngreso.IsForeignKey = false;
				colvarFechaIngreso.IsReadOnly = false;
				colvarFechaIngreso.DefaultSetting = @"";
				colvarFechaIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaIngreso);
				
				TableSchema.TableColumn colvarCuil = new TableSchema.TableColumn(schema);
				colvarCuil.ColumnName = "cuil";
				colvarCuil.DataType = DbType.AnsiString;
				colvarCuil.MaxLength = -1;
				colvarCuil.AutoIncrement = false;
				colvarCuil.IsNullable = true;
				colvarCuil.IsPrimaryKey = false;
				colvarCuil.IsForeignKey = false;
				colvarCuil.IsReadOnly = false;
				colvarCuil.DefaultSetting = @"";
				colvarCuil.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuil);
				
				TableSchema.TableColumn colvarCajaAhorroPesosNro = new TableSchema.TableColumn(schema);
				colvarCajaAhorroPesosNro.ColumnName = "caja_ahorro_pesos_nro";
				colvarCajaAhorroPesosNro.DataType = DbType.AnsiString;
				colvarCajaAhorroPesosNro.MaxLength = -1;
				colvarCajaAhorroPesosNro.AutoIncrement = false;
				colvarCajaAhorroPesosNro.IsNullable = true;
				colvarCajaAhorroPesosNro.IsPrimaryKey = false;
				colvarCajaAhorroPesosNro.IsForeignKey = false;
				colvarCajaAhorroPesosNro.IsReadOnly = false;
				colvarCajaAhorroPesosNro.DefaultSetting = @"";
				colvarCajaAhorroPesosNro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCajaAhorroPesosNro);
				
				TableSchema.TableColumn colvarIdTarea = new TableSchema.TableColumn(schema);
				colvarIdTarea.ColumnName = "id_tarea";
				colvarIdTarea.DataType = DbType.Int32;
				colvarIdTarea.MaxLength = 0;
				colvarIdTarea.AutoIncrement = false;
				colvarIdTarea.IsNullable = true;
				colvarIdTarea.IsPrimaryKey = false;
				colvarIdTarea.IsForeignKey = false;
				colvarIdTarea.IsReadOnly = false;
				colvarIdTarea.DefaultSetting = @"";
				colvarIdTarea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTarea);
				
				TableSchema.TableColumn colvarIdCalificacion = new TableSchema.TableColumn(schema);
				colvarIdCalificacion.ColumnName = "id_calificacion";
				colvarIdCalificacion.DataType = DbType.Int32;
				colvarIdCalificacion.MaxLength = 0;
				colvarIdCalificacion.AutoIncrement = false;
				colvarIdCalificacion.IsNullable = true;
				colvarIdCalificacion.IsPrimaryKey = false;
				colvarIdCalificacion.IsForeignKey = false;
				colvarIdCalificacion.IsReadOnly = false;
				colvarIdCalificacion.DefaultSetting = @"";
				colvarIdCalificacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCalificacion);
				
				TableSchema.TableColumn colvarIdAfjp = new TableSchema.TableColumn(schema);
				colvarIdAfjp.ColumnName = "id_afjp";
				colvarIdAfjp.DataType = DbType.Int32;
				colvarIdAfjp.MaxLength = 0;
				colvarIdAfjp.AutoIncrement = false;
				colvarIdAfjp.IsNullable = true;
				colvarIdAfjp.IsPrimaryKey = false;
				colvarIdAfjp.IsForeignKey = false;
				colvarIdAfjp.IsReadOnly = false;
				colvarIdAfjp.DefaultSetting = @"";
				colvarIdAfjp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAfjp);
				
				TableSchema.TableColumn colvarIdbanco = new TableSchema.TableColumn(schema);
				colvarIdbanco.ColumnName = "idbanco";
				colvarIdbanco.DataType = DbType.Int32;
				colvarIdbanco.MaxLength = 0;
				colvarIdbanco.AutoIncrement = false;
				colvarIdbanco.IsNullable = true;
				colvarIdbanco.IsPrimaryKey = false;
				colvarIdbanco.IsForeignKey = false;
				colvarIdbanco.IsReadOnly = false;
				colvarIdbanco.DefaultSetting = @"";
				colvarIdbanco.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdbanco);
				
				TableSchema.TableColumn colvarTipoLiq = new TableSchema.TableColumn(schema);
				colvarTipoLiq.ColumnName = "tipo_liq";
				colvarTipoLiq.DataType = DbType.Int16;
				colvarTipoLiq.MaxLength = 0;
				colvarTipoLiq.AutoIncrement = false;
				colvarTipoLiq.IsNullable = true;
				colvarTipoLiq.IsPrimaryKey = false;
				colvarTipoLiq.IsForeignKey = false;
				colvarTipoLiq.IsReadOnly = false;
				colvarTipoLiq.DefaultSetting = @"";
				colvarTipoLiq.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoLiq);
				
				TableSchema.TableColumn colvarTipoJub = new TableSchema.TableColumn(schema);
				colvarTipoJub.ColumnName = "tipo_jub";
				colvarTipoJub.DataType = DbType.Int16;
				colvarTipoJub.MaxLength = 0;
				colvarTipoJub.AutoIncrement = false;
				colvarTipoJub.IsNullable = true;
				colvarTipoJub.IsPrimaryKey = false;
				colvarTipoJub.IsForeignKey = false;
				colvarTipoJub.IsReadOnly = false;
				colvarTipoJub.DefaultSetting = @"";
				colvarTipoJub.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoJub);
				
				TableSchema.TableColumn colvarFechaBaja = new TableSchema.TableColumn(schema);
				colvarFechaBaja.ColumnName = "fecha_baja";
				colvarFechaBaja.DataType = DbType.DateTime;
				colvarFechaBaja.MaxLength = 0;
				colvarFechaBaja.AutoIncrement = false;
				colvarFechaBaja.IsNullable = true;
				colvarFechaBaja.IsPrimaryKey = false;
				colvarFechaBaja.IsForeignKey = false;
				colvarFechaBaja.IsReadOnly = false;
				colvarFechaBaja.DefaultSetting = @"";
				colvarFechaBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaBaja);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Int16;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = true;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				colvarActivo.DefaultSetting = @"";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				TableSchema.TableColumn colvarHrEntra = new TableSchema.TableColumn(schema);
				colvarHrEntra.ColumnName = "hr_entra";
				colvarHrEntra.DataType = DbType.AnsiString;
				colvarHrEntra.MaxLength = 16;
				colvarHrEntra.AutoIncrement = false;
				colvarHrEntra.IsNullable = true;
				colvarHrEntra.IsPrimaryKey = false;
				colvarHrEntra.IsForeignKey = false;
				colvarHrEntra.IsReadOnly = false;
				colvarHrEntra.DefaultSetting = @"";
				colvarHrEntra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHrEntra);
				
				TableSchema.TableColumn colvarHrSale = new TableSchema.TableColumn(schema);
				colvarHrSale.ColumnName = "hr_sale";
				colvarHrSale.DataType = DbType.AnsiString;
				colvarHrSale.MaxLength = 16;
				colvarHrSale.AutoIncrement = false;
				colvarHrSale.IsNullable = true;
				colvarHrSale.IsPrimaryKey = false;
				colvarHrSale.IsForeignKey = false;
				colvarHrSale.IsReadOnly = false;
				colvarHrSale.DefaultSetting = @"";
				colvarHrSale.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHrSale);
				
				TableSchema.TableColumn colvarUbicacion = new TableSchema.TableColumn(schema);
				colvarUbicacion.ColumnName = "ubicacion";
				colvarUbicacion.DataType = DbType.Int16;
				colvarUbicacion.MaxLength = 0;
				colvarUbicacion.AutoIncrement = false;
				colvarUbicacion.IsNullable = true;
				colvarUbicacion.IsPrimaryKey = false;
				colvarUbicacion.IsForeignKey = false;
				colvarUbicacion.IsReadOnly = false;
				colvarUbicacion.DefaultSetting = @"";
				colvarUbicacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUbicacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_legajos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLegajo")]
		[Bindable(true)]
		public int IdLegajo 
		{
			get { return GetColumnValue<int>(Columns.IdLegajo); }
			set { SetColumnValue(Columns.IdLegajo, value); }
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
		  
		[XmlAttribute("Dni")]
		[Bindable(true)]
		public string Dni 
		{
			get { return GetColumnValue<string>(Columns.Dni); }
			set { SetColumnValue(Columns.Dni, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("LugarNacimiento")]
		[Bindable(true)]
		public string LugarNacimiento 
		{
			get { return GetColumnValue<string>(Columns.LugarNacimiento); }
			set { SetColumnValue(Columns.LugarNacimiento, value); }
		}
		  
		[XmlAttribute("Domicilio")]
		[Bindable(true)]
		public string Domicilio 
		{
			get { return GetColumnValue<string>(Columns.Domicilio); }
			set { SetColumnValue(Columns.Domicilio, value); }
		}
		  
		[XmlAttribute("TelCelular")]
		[Bindable(true)]
		public string TelCelular 
		{
			get { return GetColumnValue<string>(Columns.TelCelular); }
			set { SetColumnValue(Columns.TelCelular, value); }
		}
		  
		[XmlAttribute("TelParticular")]
		[Bindable(true)]
		public string TelParticular 
		{
			get { return GetColumnValue<string>(Columns.TelParticular); }
			set { SetColumnValue(Columns.TelParticular, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("Provincia")]
		[Bindable(true)]
		public string Provincia 
		{
			get { return GetColumnValue<string>(Columns.Provincia); }
			set { SetColumnValue(Columns.Provincia, value); }
		}
		  
		[XmlAttribute("EmNombre")]
		[Bindable(true)]
		public string EmNombre 
		{
			get { return GetColumnValue<string>(Columns.EmNombre); }
			set { SetColumnValue(Columns.EmNombre, value); }
		}
		  
		[XmlAttribute("EmTelefono")]
		[Bindable(true)]
		public string EmTelefono 
		{
			get { return GetColumnValue<string>(Columns.EmTelefono); }
			set { SetColumnValue(Columns.EmTelefono, value); }
		}
		  
		[XmlAttribute("EmDireccion")]
		[Bindable(true)]
		public string EmDireccion 
		{
			get { return GetColumnValue<string>(Columns.EmDireccion); }
			set { SetColumnValue(Columns.EmDireccion, value); }
		}
		  
		[XmlAttribute("EmRelacion")]
		[Bindable(true)]
		public string EmRelacion 
		{
			get { return GetColumnValue<string>(Columns.EmRelacion); }
			set { SetColumnValue(Columns.EmRelacion, value); }
		}
		  
		[XmlAttribute("Comentarios")]
		[Bindable(true)]
		public string Comentarios 
		{
			get { return GetColumnValue<string>(Columns.Comentarios); }
			set { SetColumnValue(Columns.Comentarios, value); }
		}
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int? IdUsuario 
		{
			get { return GetColumnValue<int?>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("IdEvaluador")]
		[Bindable(true)]
		public int? IdEvaluador 
		{
			get { return GetColumnValue<int?>(Columns.IdEvaluador); }
			set { SetColumnValue(Columns.IdEvaluador, value); }
		}
		  
		[XmlAttribute("FechaIngreso")]
		[Bindable(true)]
		public DateTime? FechaIngreso 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaIngreso); }
			set { SetColumnValue(Columns.FechaIngreso, value); }
		}
		  
		[XmlAttribute("Cuil")]
		[Bindable(true)]
		public string Cuil 
		{
			get { return GetColumnValue<string>(Columns.Cuil); }
			set { SetColumnValue(Columns.Cuil, value); }
		}
		  
		[XmlAttribute("CajaAhorroPesosNro")]
		[Bindable(true)]
		public string CajaAhorroPesosNro 
		{
			get { return GetColumnValue<string>(Columns.CajaAhorroPesosNro); }
			set { SetColumnValue(Columns.CajaAhorroPesosNro, value); }
		}
		  
		[XmlAttribute("IdTarea")]
		[Bindable(true)]
		public int? IdTarea 
		{
			get { return GetColumnValue<int?>(Columns.IdTarea); }
			set { SetColumnValue(Columns.IdTarea, value); }
		}
		  
		[XmlAttribute("IdCalificacion")]
		[Bindable(true)]
		public int? IdCalificacion 
		{
			get { return GetColumnValue<int?>(Columns.IdCalificacion); }
			set { SetColumnValue(Columns.IdCalificacion, value); }
		}
		  
		[XmlAttribute("IdAfjp")]
		[Bindable(true)]
		public int? IdAfjp 
		{
			get { return GetColumnValue<int?>(Columns.IdAfjp); }
			set { SetColumnValue(Columns.IdAfjp, value); }
		}
		  
		[XmlAttribute("Idbanco")]
		[Bindable(true)]
		public int? Idbanco 
		{
			get { return GetColumnValue<int?>(Columns.Idbanco); }
			set { SetColumnValue(Columns.Idbanco, value); }
		}
		  
		[XmlAttribute("TipoLiq")]
		[Bindable(true)]
		public short? TipoLiq 
		{
			get { return GetColumnValue<short?>(Columns.TipoLiq); }
			set { SetColumnValue(Columns.TipoLiq, value); }
		}
		  
		[XmlAttribute("TipoJub")]
		[Bindable(true)]
		public short? TipoJub 
		{
			get { return GetColumnValue<short?>(Columns.TipoJub); }
			set { SetColumnValue(Columns.TipoJub, value); }
		}
		  
		[XmlAttribute("FechaBaja")]
		[Bindable(true)]
		public DateTime? FechaBaja 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaBaja); }
			set { SetColumnValue(Columns.FechaBaja, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public short? Activo 
		{
			get { return GetColumnValue<short?>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		  
		[XmlAttribute("HrEntra")]
		[Bindable(true)]
		public string HrEntra 
		{
			get { return GetColumnValue<string>(Columns.HrEntra); }
			set { SetColumnValue(Columns.HrEntra, value); }
		}
		  
		[XmlAttribute("HrSale")]
		[Bindable(true)]
		public string HrSale 
		{
			get { return GetColumnValue<string>(Columns.HrSale); }
			set { SetColumnValue(Columns.HrSale, value); }
		}
		  
		[XmlAttribute("Ubicacion")]
		[Bindable(true)]
		public short? Ubicacion 
		{
			get { return GetColumnValue<short?>(Columns.Ubicacion); }
			set { SetColumnValue(Columns.Ubicacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varApellido,string varNombre,string varDni,DateTime? varFechaNacimiento,string varLugarNacimiento,string varDomicilio,string varTelCelular,string varTelParticular,string varLocalidad,string varProvincia,string varEmNombre,string varEmTelefono,string varEmDireccion,string varEmRelacion,string varComentarios,int? varIdUsuario,int? varIdEvaluador,DateTime? varFechaIngreso,string varCuil,string varCajaAhorroPesosNro,int? varIdTarea,int? varIdCalificacion,int? varIdAfjp,int? varIdbanco,short? varTipoLiq,short? varTipoJub,DateTime? varFechaBaja,short? varActivo,string varHrEntra,string varHrSale,short? varUbicacion)
		{
			PnLegajo item = new PnLegajo();
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.Dni = varDni;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.LugarNacimiento = varLugarNacimiento;
			
			item.Domicilio = varDomicilio;
			
			item.TelCelular = varTelCelular;
			
			item.TelParticular = varTelParticular;
			
			item.Localidad = varLocalidad;
			
			item.Provincia = varProvincia;
			
			item.EmNombre = varEmNombre;
			
			item.EmTelefono = varEmTelefono;
			
			item.EmDireccion = varEmDireccion;
			
			item.EmRelacion = varEmRelacion;
			
			item.Comentarios = varComentarios;
			
			item.IdUsuario = varIdUsuario;
			
			item.IdEvaluador = varIdEvaluador;
			
			item.FechaIngreso = varFechaIngreso;
			
			item.Cuil = varCuil;
			
			item.CajaAhorroPesosNro = varCajaAhorroPesosNro;
			
			item.IdTarea = varIdTarea;
			
			item.IdCalificacion = varIdCalificacion;
			
			item.IdAfjp = varIdAfjp;
			
			item.Idbanco = varIdbanco;
			
			item.TipoLiq = varTipoLiq;
			
			item.TipoJub = varTipoJub;
			
			item.FechaBaja = varFechaBaja;
			
			item.Activo = varActivo;
			
			item.HrEntra = varHrEntra;
			
			item.HrSale = varHrSale;
			
			item.Ubicacion = varUbicacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdLegajo,string varApellido,string varNombre,string varDni,DateTime? varFechaNacimiento,string varLugarNacimiento,string varDomicilio,string varTelCelular,string varTelParticular,string varLocalidad,string varProvincia,string varEmNombre,string varEmTelefono,string varEmDireccion,string varEmRelacion,string varComentarios,int? varIdUsuario,int? varIdEvaluador,DateTime? varFechaIngreso,string varCuil,string varCajaAhorroPesosNro,int? varIdTarea,int? varIdCalificacion,int? varIdAfjp,int? varIdbanco,short? varTipoLiq,short? varTipoJub,DateTime? varFechaBaja,short? varActivo,string varHrEntra,string varHrSale,short? varUbicacion)
		{
			PnLegajo item = new PnLegajo();
			
				item.IdLegajo = varIdLegajo;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.Dni = varDni;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.LugarNacimiento = varLugarNacimiento;
			
				item.Domicilio = varDomicilio;
			
				item.TelCelular = varTelCelular;
			
				item.TelParticular = varTelParticular;
			
				item.Localidad = varLocalidad;
			
				item.Provincia = varProvincia;
			
				item.EmNombre = varEmNombre;
			
				item.EmTelefono = varEmTelefono;
			
				item.EmDireccion = varEmDireccion;
			
				item.EmRelacion = varEmRelacion;
			
				item.Comentarios = varComentarios;
			
				item.IdUsuario = varIdUsuario;
			
				item.IdEvaluador = varIdEvaluador;
			
				item.FechaIngreso = varFechaIngreso;
			
				item.Cuil = varCuil;
			
				item.CajaAhorroPesosNro = varCajaAhorroPesosNro;
			
				item.IdTarea = varIdTarea;
			
				item.IdCalificacion = varIdCalificacion;
			
				item.IdAfjp = varIdAfjp;
			
				item.Idbanco = varIdbanco;
			
				item.TipoLiq = varTipoLiq;
			
				item.TipoJub = varTipoJub;
			
				item.FechaBaja = varFechaBaja;
			
				item.Activo = varActivo;
			
				item.HrEntra = varHrEntra;
			
				item.HrSale = varHrSale;
			
				item.Ubicacion = varUbicacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLegajoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DniColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn LugarNacimientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicilioColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TelCelularColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TelParticularColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ProvinciaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn EmNombreColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn EmTelefonoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn EmDireccionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn EmRelacionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentariosColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEvaluadorColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaIngresoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CuilColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CajaAhorroPesosNroColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTareaColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCalificacionColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn IdAfjpColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn IdbancoColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoLiqColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoJubColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaBajaColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn HrEntraColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn HrSaleColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn UbicacionColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLegajo = @"id_legajo";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string Dni = @"dni";
			 public static string FechaNacimiento = @"fecha_nacimiento";
			 public static string LugarNacimiento = @"lugar_nacimiento";
			 public static string Domicilio = @"domicilio";
			 public static string TelCelular = @"tel_celular";
			 public static string TelParticular = @"tel_particular";
			 public static string Localidad = @"localidad";
			 public static string Provincia = @"provincia";
			 public static string EmNombre = @"em_nombre";
			 public static string EmTelefono = @"em_telefono";
			 public static string EmDireccion = @"em_direccion";
			 public static string EmRelacion = @"em_relacion";
			 public static string Comentarios = @"comentarios";
			 public static string IdUsuario = @"id_usuario";
			 public static string IdEvaluador = @"id_evaluador";
			 public static string FechaIngreso = @"fecha_ingreso";
			 public static string Cuil = @"cuil";
			 public static string CajaAhorroPesosNro = @"caja_ahorro_pesos_nro";
			 public static string IdTarea = @"id_tarea";
			 public static string IdCalificacion = @"id_calificacion";
			 public static string IdAfjp = @"id_afjp";
			 public static string Idbanco = @"idbanco";
			 public static string TipoLiq = @"tipo_liq";
			 public static string TipoJub = @"tipo_jub";
			 public static string FechaBaja = @"fecha_baja";
			 public static string Activo = @"activo";
			 public static string HrEntra = @"hr_entra";
			 public static string HrSale = @"hr_sale";
			 public static string Ubicacion = @"ubicacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
