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
	/// Strongly-typed collection for the PnUsuario class.
	/// </summary>
    [Serializable]
	public partial class PnUsuarioCollection : ActiveList<PnUsuario, PnUsuarioCollection>
	{	   
		public PnUsuarioCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnUsuarioCollection</returns>
		public PnUsuarioCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnUsuario o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_usuarios table.
	/// </summary>
	[Serializable]
	public partial class PnUsuario : ActiveRecord<PnUsuario>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnUsuario()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnUsuario(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnUsuario(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnUsuario(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_usuarios", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdUsuario = new TableSchema.TableColumn(schema);
				colvarIdUsuario.ColumnName = "id_usuario";
				colvarIdUsuario.DataType = DbType.Int32;
				colvarIdUsuario.MaxLength = 0;
				colvarIdUsuario.AutoIncrement = true;
				colvarIdUsuario.IsNullable = false;
				colvarIdUsuario.IsPrimaryKey = true;
				colvarIdUsuario.IsForeignKey = false;
				colvarIdUsuario.IsReadOnly = false;
				colvarIdUsuario.DefaultSetting = @"";
				colvarIdUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdUsuario);
				
				TableSchema.TableColumn colvarLogin = new TableSchema.TableColumn(schema);
				colvarLogin.ColumnName = "login";
				colvarLogin.DataType = DbType.AnsiString;
				colvarLogin.MaxLength = 20;
				colvarLogin.AutoIncrement = false;
				colvarLogin.IsNullable = true;
				colvarLogin.IsPrimaryKey = false;
				colvarLogin.IsForeignKey = false;
				colvarLogin.IsReadOnly = false;
				colvarLogin.DefaultSetting = @"";
				colvarLogin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogin);
				
				TableSchema.TableColumn colvarPasswd = new TableSchema.TableColumn(schema);
				colvarPasswd.ColumnName = "passwd";
				colvarPasswd.DataType = DbType.AnsiString;
				colvarPasswd.MaxLength = 32;
				colvarPasswd.AutoIncrement = false;
				colvarPasswd.IsNullable = true;
				colvarPasswd.IsPrimaryKey = false;
				colvarPasswd.IsForeignKey = false;
				colvarPasswd.IsReadOnly = false;
				colvarPasswd.DefaultSetting = @"";
				colvarPasswd.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPasswd);
				
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
				
				TableSchema.TableColumn colvarDireccion = new TableSchema.TableColumn(schema);
				colvarDireccion.ColumnName = "direccion";
				colvarDireccion.DataType = DbType.AnsiString;
				colvarDireccion.MaxLength = -1;
				colvarDireccion.AutoIncrement = false;
				colvarDireccion.IsNullable = true;
				colvarDireccion.IsPrimaryKey = false;
				colvarDireccion.IsForeignKey = false;
				colvarDireccion.IsReadOnly = false;
				colvarDireccion.DefaultSetting = @"";
				colvarDireccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccion);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = -1;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarCelular = new TableSchema.TableColumn(schema);
				colvarCelular.ColumnName = "celular";
				colvarCelular.DataType = DbType.AnsiString;
				colvarCelular.MaxLength = -1;
				colvarCelular.AutoIncrement = false;
				colvarCelular.IsNullable = true;
				colvarCelular.IsPrimaryKey = false;
				colvarCelular.IsForeignKey = false;
				colvarCelular.IsReadOnly = false;
				colvarCelular.DefaultSetting = @"";
				colvarCelular.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCelular);
				
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
				
				TableSchema.TableColumn colvarFechaAlta = new TableSchema.TableColumn(schema);
				colvarFechaAlta.ColumnName = "fecha_alta";
				colvarFechaAlta.DataType = DbType.DateTime;
				colvarFechaAlta.MaxLength = 0;
				colvarFechaAlta.AutoIncrement = false;
				colvarFechaAlta.IsNullable = true;
				colvarFechaAlta.IsPrimaryKey = false;
				colvarFechaAlta.IsForeignKey = false;
				colvarFechaAlta.IsReadOnly = false;
				colvarFechaAlta.DefaultSetting = @"";
				colvarFechaAlta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAlta);
				
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
				
				TableSchema.TableColumn colvarPaginaInicio = new TableSchema.TableColumn(schema);
				colvarPaginaInicio.ColumnName = "pagina_inicio";
				colvarPaginaInicio.DataType = DbType.AnsiString;
				colvarPaginaInicio.MaxLength = 100;
				colvarPaginaInicio.AutoIncrement = false;
				colvarPaginaInicio.IsNullable = true;
				colvarPaginaInicio.IsPrimaryKey = false;
				colvarPaginaInicio.IsForeignKey = false;
				colvarPaginaInicio.IsReadOnly = false;
				colvarPaginaInicio.DefaultSetting = @"";
				colvarPaginaInicio.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaginaInicio);
				
				TableSchema.TableColumn colvarFirma1 = new TableSchema.TableColumn(schema);
				colvarFirma1.ColumnName = "firma1";
				colvarFirma1.DataType = DbType.AnsiString;
				colvarFirma1.MaxLength = 30;
				colvarFirma1.AutoIncrement = false;
				colvarFirma1.IsNullable = true;
				colvarFirma1.IsPrimaryKey = false;
				colvarFirma1.IsForeignKey = false;
				colvarFirma1.IsReadOnly = false;
				colvarFirma1.DefaultSetting = @"";
				colvarFirma1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFirma1);
				
				TableSchema.TableColumn colvarFirma2 = new TableSchema.TableColumn(schema);
				colvarFirma2.ColumnName = "firma2";
				colvarFirma2.DataType = DbType.AnsiString;
				colvarFirma2.MaxLength = 30;
				colvarFirma2.AutoIncrement = false;
				colvarFirma2.IsNullable = true;
				colvarFirma2.IsPrimaryKey = false;
				colvarFirma2.IsForeignKey = false;
				colvarFirma2.IsReadOnly = false;
				colvarFirma2.DefaultSetting = @"";
				colvarFirma2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFirma2);
				
				TableSchema.TableColumn colvarFirma3 = new TableSchema.TableColumn(schema);
				colvarFirma3.ColumnName = "firma3";
				colvarFirma3.DataType = DbType.AnsiString;
				colvarFirma3.MaxLength = 30;
				colvarFirma3.AutoIncrement = false;
				colvarFirma3.IsNullable = true;
				colvarFirma3.IsPrimaryKey = false;
				colvarFirma3.IsForeignKey = false;
				colvarFirma3.IsReadOnly = false;
				colvarFirma3.DefaultSetting = @"";
				colvarFirma3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFirma3);
				
				TableSchema.TableColumn colvarAcceso1 = new TableSchema.TableColumn(schema);
				colvarAcceso1.ColumnName = "acceso1";
				colvarAcceso1.DataType = DbType.AnsiString;
				colvarAcceso1.MaxLength = 100;
				colvarAcceso1.AutoIncrement = false;
				colvarAcceso1.IsNullable = true;
				colvarAcceso1.IsPrimaryKey = false;
				colvarAcceso1.IsForeignKey = false;
				colvarAcceso1.IsReadOnly = false;
				colvarAcceso1.DefaultSetting = @"";
				colvarAcceso1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso1);
				
				TableSchema.TableColumn colvarAcceso2 = new TableSchema.TableColumn(schema);
				colvarAcceso2.ColumnName = "acceso2";
				colvarAcceso2.DataType = DbType.AnsiString;
				colvarAcceso2.MaxLength = 100;
				colvarAcceso2.AutoIncrement = false;
				colvarAcceso2.IsNullable = true;
				colvarAcceso2.IsPrimaryKey = false;
				colvarAcceso2.IsForeignKey = false;
				colvarAcceso2.IsReadOnly = false;
				colvarAcceso2.DefaultSetting = @"";
				colvarAcceso2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso2);
				
				TableSchema.TableColumn colvarAcceso3 = new TableSchema.TableColumn(schema);
				colvarAcceso3.ColumnName = "acceso3";
				colvarAcceso3.DataType = DbType.AnsiString;
				colvarAcceso3.MaxLength = 100;
				colvarAcceso3.AutoIncrement = false;
				colvarAcceso3.IsNullable = true;
				colvarAcceso3.IsPrimaryKey = false;
				colvarAcceso3.IsForeignKey = false;
				colvarAcceso3.IsReadOnly = false;
				colvarAcceso3.DefaultSetting = @"";
				colvarAcceso3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso3);
				
				TableSchema.TableColumn colvarAcceso4 = new TableSchema.TableColumn(schema);
				colvarAcceso4.ColumnName = "acceso4";
				colvarAcceso4.DataType = DbType.AnsiString;
				colvarAcceso4.MaxLength = 100;
				colvarAcceso4.AutoIncrement = false;
				colvarAcceso4.IsNullable = true;
				colvarAcceso4.IsPrimaryKey = false;
				colvarAcceso4.IsForeignKey = false;
				colvarAcceso4.IsReadOnly = false;
				colvarAcceso4.DefaultSetting = @"";
				colvarAcceso4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso4);
				
				TableSchema.TableColumn colvarAcceso5 = new TableSchema.TableColumn(schema);
				colvarAcceso5.ColumnName = "acceso5";
				colvarAcceso5.DataType = DbType.AnsiString;
				colvarAcceso5.MaxLength = 100;
				colvarAcceso5.AutoIncrement = false;
				colvarAcceso5.IsNullable = true;
				colvarAcceso5.IsPrimaryKey = false;
				colvarAcceso5.IsForeignKey = false;
				colvarAcceso5.IsReadOnly = false;
				colvarAcceso5.DefaultSetting = @"";
				colvarAcceso5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso5);
				
				TableSchema.TableColumn colvarAcceso6 = new TableSchema.TableColumn(schema);
				colvarAcceso6.ColumnName = "acceso6";
				colvarAcceso6.DataType = DbType.AnsiString;
				colvarAcceso6.MaxLength = 100;
				colvarAcceso6.AutoIncrement = false;
				colvarAcceso6.IsNullable = true;
				colvarAcceso6.IsPrimaryKey = false;
				colvarAcceso6.IsForeignKey = false;
				colvarAcceso6.IsReadOnly = false;
				colvarAcceso6.DefaultSetting = @"";
				colvarAcceso6.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso6);
				
				TableSchema.TableColumn colvarAvisarOc = new TableSchema.TableColumn(schema);
				colvarAvisarOc.ColumnName = "avisar_oc";
				colvarAvisarOc.DataType = DbType.Int16;
				colvarAvisarOc.MaxLength = 0;
				colvarAvisarOc.AutoIncrement = false;
				colvarAvisarOc.IsNullable = true;
				colvarAvisarOc.IsPrimaryKey = false;
				colvarAvisarOc.IsForeignKey = false;
				colvarAvisarOc.IsReadOnly = false;
				colvarAvisarOc.DefaultSetting = @"";
				colvarAvisarOc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAvisarOc);
				
				TableSchema.TableColumn colvarIdLugarPedidoComida = new TableSchema.TableColumn(schema);
				colvarIdLugarPedidoComida.ColumnName = "id_lugar_pedido_comida";
				colvarIdLugarPedidoComida.DataType = DbType.Int16;
				colvarIdLugarPedidoComida.MaxLength = 0;
				colvarIdLugarPedidoComida.AutoIncrement = false;
				colvarIdLugarPedidoComida.IsNullable = true;
				colvarIdLugarPedidoComida.IsPrimaryKey = false;
				colvarIdLugarPedidoComida.IsForeignKey = false;
				colvarIdLugarPedidoComida.IsReadOnly = false;
				colvarIdLugarPedidoComida.DefaultSetting = @"";
				colvarIdLugarPedidoComida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLugarPedidoComida);
				
				TableSchema.TableColumn colvarAcceso7 = new TableSchema.TableColumn(schema);
				colvarAcceso7.ColumnName = "acceso7";
				colvarAcceso7.DataType = DbType.AnsiString;
				colvarAcceso7.MaxLength = 100;
				colvarAcceso7.AutoIncrement = false;
				colvarAcceso7.IsNullable = true;
				colvarAcceso7.IsPrimaryKey = false;
				colvarAcceso7.IsForeignKey = false;
				colvarAcceso7.IsReadOnly = false;
				colvarAcceso7.DefaultSetting = @"";
				colvarAcceso7.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso7);
				
				TableSchema.TableColumn colvarAcceso8 = new TableSchema.TableColumn(schema);
				colvarAcceso8.ColumnName = "acceso8";
				colvarAcceso8.DataType = DbType.AnsiString;
				colvarAcceso8.MaxLength = 100;
				colvarAcceso8.AutoIncrement = false;
				colvarAcceso8.IsNullable = true;
				colvarAcceso8.IsPrimaryKey = false;
				colvarAcceso8.IsForeignKey = false;
				colvarAcceso8.IsReadOnly = false;
				colvarAcceso8.DefaultSetting = @"";
				colvarAcceso8.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso8);
				
				TableSchema.TableColumn colvarAcceso9 = new TableSchema.TableColumn(schema);
				colvarAcceso9.ColumnName = "acceso9";
				colvarAcceso9.DataType = DbType.AnsiString;
				colvarAcceso9.MaxLength = 100;
				colvarAcceso9.AutoIncrement = false;
				colvarAcceso9.IsNullable = true;
				colvarAcceso9.IsPrimaryKey = false;
				colvarAcceso9.IsForeignKey = false;
				colvarAcceso9.IsReadOnly = false;
				colvarAcceso9.DefaultSetting = @"";
				colvarAcceso9.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso9);
				
				TableSchema.TableColumn colvarAcceso10 = new TableSchema.TableColumn(schema);
				colvarAcceso10.ColumnName = "acceso10";
				colvarAcceso10.DataType = DbType.AnsiString;
				colvarAcceso10.MaxLength = 100;
				colvarAcceso10.AutoIncrement = false;
				colvarAcceso10.IsNullable = true;
				colvarAcceso10.IsPrimaryKey = false;
				colvarAcceso10.IsForeignKey = false;
				colvarAcceso10.IsReadOnly = false;
				colvarAcceso10.DefaultSetting = @"";
				colvarAcceso10.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso10);
				
				TableSchema.TableColumn colvarAcceso11 = new TableSchema.TableColumn(schema);
				colvarAcceso11.ColumnName = "acceso11";
				colvarAcceso11.DataType = DbType.AnsiString;
				colvarAcceso11.MaxLength = 100;
				colvarAcceso11.AutoIncrement = false;
				colvarAcceso11.IsNullable = true;
				colvarAcceso11.IsPrimaryKey = false;
				colvarAcceso11.IsForeignKey = false;
				colvarAcceso11.IsReadOnly = false;
				colvarAcceso11.DefaultSetting = @"";
				colvarAcceso11.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso11);
				
				TableSchema.TableColumn colvarAcceso12 = new TableSchema.TableColumn(schema);
				colvarAcceso12.ColumnName = "acceso12";
				colvarAcceso12.DataType = DbType.AnsiString;
				colvarAcceso12.MaxLength = 100;
				colvarAcceso12.AutoIncrement = false;
				colvarAcceso12.IsNullable = true;
				colvarAcceso12.IsPrimaryKey = false;
				colvarAcceso12.IsForeignKey = false;
				colvarAcceso12.IsReadOnly = false;
				colvarAcceso12.DefaultSetting = @"";
				colvarAcceso12.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAcceso12);
				
				TableSchema.TableColumn colvarTipoLic = new TableSchema.TableColumn(schema);
				colvarTipoLic.ColumnName = "tipo_lic";
				colvarTipoLic.DataType = DbType.AnsiString;
				colvarTipoLic.MaxLength = -1;
				colvarTipoLic.AutoIncrement = false;
				colvarTipoLic.IsNullable = true;
				colvarTipoLic.IsPrimaryKey = false;
				colvarTipoLic.IsForeignKey = false;
				colvarTipoLic.IsReadOnly = false;
				colvarTipoLic.DefaultSetting = @"";
				colvarTipoLic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoLic);
				
				TableSchema.TableColumn colvarIniciales = new TableSchema.TableColumn(schema);
				colvarIniciales.ColumnName = "iniciales";
				colvarIniciales.DataType = DbType.AnsiString;
				colvarIniciales.MaxLength = -1;
				colvarIniciales.AutoIncrement = false;
				colvarIniciales.IsNullable = true;
				colvarIniciales.IsPrimaryKey = false;
				colvarIniciales.IsForeignKey = false;
				colvarIniciales.IsReadOnly = false;
				colvarIniciales.DefaultSetting = @"";
				colvarIniciales.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIniciales);
				
				TableSchema.TableColumn colvarPciaUbicacion = new TableSchema.TableColumn(schema);
				colvarPciaUbicacion.ColumnName = "pcia_ubicacion";
				colvarPciaUbicacion.DataType = DbType.Int16;
				colvarPciaUbicacion.MaxLength = 0;
				colvarPciaUbicacion.AutoIncrement = false;
				colvarPciaUbicacion.IsNullable = true;
				colvarPciaUbicacion.IsPrimaryKey = false;
				colvarPciaUbicacion.IsForeignKey = false;
				colvarPciaUbicacion.IsReadOnly = false;
				colvarPciaUbicacion.DefaultSetting = @"";
				colvarPciaUbicacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPciaUbicacion);
				
				TableSchema.TableColumn colvarNroTarjeta = new TableSchema.TableColumn(schema);
				colvarNroTarjeta.ColumnName = "nro_tarjeta";
				colvarNroTarjeta.DataType = DbType.AnsiString;
				colvarNroTarjeta.MaxLength = -1;
				colvarNroTarjeta.AutoIncrement = false;
				colvarNroTarjeta.IsNullable = true;
				colvarNroTarjeta.IsPrimaryKey = false;
				colvarNroTarjeta.IsForeignKey = false;
				colvarNroTarjeta.IsReadOnly = false;
				colvarNroTarjeta.DefaultSetting = @"";
				colvarNroTarjeta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroTarjeta);
				
				TableSchema.TableColumn colvarVersionTarjeta = new TableSchema.TableColumn(schema);
				colvarVersionTarjeta.ColumnName = "version_tarjeta";
				colvarVersionTarjeta.DataType = DbType.Int16;
				colvarVersionTarjeta.MaxLength = 0;
				colvarVersionTarjeta.AutoIncrement = false;
				colvarVersionTarjeta.IsNullable = true;
				colvarVersionTarjeta.IsPrimaryKey = false;
				colvarVersionTarjeta.IsForeignKey = false;
				colvarVersionTarjeta.IsReadOnly = false;
				
						colvarVersionTarjeta.DefaultSetting = @"((0))";
				colvarVersionTarjeta.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVersionTarjeta);
				
				TableSchema.TableColumn colvarVisible = new TableSchema.TableColumn(schema);
				colvarVisible.ColumnName = "visible";
				colvarVisible.DataType = DbType.Int16;
				colvarVisible.MaxLength = 0;
				colvarVisible.AutoIncrement = false;
				colvarVisible.IsNullable = true;
				colvarVisible.IsPrimaryKey = false;
				colvarVisible.IsForeignKey = false;
				colvarVisible.IsReadOnly = false;
				colvarVisible.DefaultSetting = @"";
				colvarVisible.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVisible);
				
				TableSchema.TableColumn colvarAccesoRemoto = new TableSchema.TableColumn(schema);
				colvarAccesoRemoto.ColumnName = "acceso_remoto";
				colvarAccesoRemoto.DataType = DbType.Int16;
				colvarAccesoRemoto.MaxLength = 0;
				colvarAccesoRemoto.AutoIncrement = false;
				colvarAccesoRemoto.IsNullable = true;
				colvarAccesoRemoto.IsPrimaryKey = false;
				colvarAccesoRemoto.IsForeignKey = false;
				colvarAccesoRemoto.IsReadOnly = false;
				
						colvarAccesoRemoto.DefaultSetting = @"((0))";
				colvarAccesoRemoto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccesoRemoto);
				
				TableSchema.TableColumn colvarFoto = new TableSchema.TableColumn(schema);
				colvarFoto.ColumnName = "foto";
				colvarFoto.DataType = DbType.Binary;
				colvarFoto.MaxLength = -1;
				colvarFoto.AutoIncrement = false;
				colvarFoto.IsNullable = true;
				colvarFoto.IsPrimaryKey = false;
				colvarFoto.IsForeignKey = false;
				colvarFoto.IsReadOnly = false;
				colvarFoto.DefaultSetting = @"";
				colvarFoto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFoto);
				
				TableSchema.TableColumn colvarHuella = new TableSchema.TableColumn(schema);
				colvarHuella.ColumnName = "huella";
				colvarHuella.DataType = DbType.Binary;
				colvarHuella.MaxLength = -1;
				colvarHuella.AutoIncrement = false;
				colvarHuella.IsNullable = true;
				colvarHuella.IsPrimaryKey = false;
				colvarHuella.IsForeignKey = false;
				colvarHuella.IsReadOnly = false;
				colvarHuella.DefaultSetting = @"";
				colvarHuella.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHuella);
				
				TableSchema.TableColumn colvarHuella1 = new TableSchema.TableColumn(schema);
				colvarHuella1.ColumnName = "huella1";
				colvarHuella1.DataType = DbType.Binary;
				colvarHuella1.MaxLength = -1;
				colvarHuella1.AutoIncrement = false;
				colvarHuella1.IsNullable = true;
				colvarHuella1.IsPrimaryKey = false;
				colvarHuella1.IsForeignKey = false;
				colvarHuella1.IsReadOnly = false;
				colvarHuella1.DefaultSetting = @"";
				colvarHuella1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHuella1);
				
				TableSchema.TableColumn colvarHuella2 = new TableSchema.TableColumn(schema);
				colvarHuella2.ColumnName = "huella2";
				colvarHuella2.DataType = DbType.Binary;
				colvarHuella2.MaxLength = -1;
				colvarHuella2.AutoIncrement = false;
				colvarHuella2.IsNullable = true;
				colvarHuella2.IsPrimaryKey = false;
				colvarHuella2.IsForeignKey = false;
				colvarHuella2.IsReadOnly = false;
				colvarHuella2.DefaultSetting = @"";
				colvarHuella2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHuella2);
				
				TableSchema.TableColumn colvarHuella3 = new TableSchema.TableColumn(schema);
				colvarHuella3.ColumnName = "huella3";
				colvarHuella3.DataType = DbType.Binary;
				colvarHuella3.MaxLength = -1;
				colvarHuella3.AutoIncrement = false;
				colvarHuella3.IsNullable = true;
				colvarHuella3.IsPrimaryKey = false;
				colvarHuella3.IsForeignKey = false;
				colvarHuella3.IsReadOnly = false;
				colvarHuella3.DefaultSetting = @"";
				colvarHuella3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHuella3);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_usuarios",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdUsuario")]
		[Bindable(true)]
		public int IdUsuario 
		{
			get { return GetColumnValue<int>(Columns.IdUsuario); }
			set { SetColumnValue(Columns.IdUsuario, value); }
		}
		  
		[XmlAttribute("Login")]
		[Bindable(true)]
		public string Login 
		{
			get { return GetColumnValue<string>(Columns.Login); }
			set { SetColumnValue(Columns.Login, value); }
		}
		  
		[XmlAttribute("Passwd")]
		[Bindable(true)]
		public string Passwd 
		{
			get { return GetColumnValue<string>(Columns.Passwd); }
			set { SetColumnValue(Columns.Passwd, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Direccion")]
		[Bindable(true)]
		public string Direccion 
		{
			get { return GetColumnValue<string>(Columns.Direccion); }
			set { SetColumnValue(Columns.Direccion, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("Celular")]
		[Bindable(true)]
		public string Celular 
		{
			get { return GetColumnValue<string>(Columns.Celular); }
			set { SetColumnValue(Columns.Celular, value); }
		}
		  
		[XmlAttribute("Mail")]
		[Bindable(true)]
		public string Mail 
		{
			get { return GetColumnValue<string>(Columns.Mail); }
			set { SetColumnValue(Columns.Mail, value); }
		}
		  
		[XmlAttribute("FechaAlta")]
		[Bindable(true)]
		public DateTime? FechaAlta 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaAlta); }
			set { SetColumnValue(Columns.FechaAlta, value); }
		}
		  
		[XmlAttribute("Comentarios")]
		[Bindable(true)]
		public string Comentarios 
		{
			get { return GetColumnValue<string>(Columns.Comentarios); }
			set { SetColumnValue(Columns.Comentarios, value); }
		}
		  
		[XmlAttribute("PaginaInicio")]
		[Bindable(true)]
		public string PaginaInicio 
		{
			get { return GetColumnValue<string>(Columns.PaginaInicio); }
			set { SetColumnValue(Columns.PaginaInicio, value); }
		}
		  
		[XmlAttribute("Firma1")]
		[Bindable(true)]
		public string Firma1 
		{
			get { return GetColumnValue<string>(Columns.Firma1); }
			set { SetColumnValue(Columns.Firma1, value); }
		}
		  
		[XmlAttribute("Firma2")]
		[Bindable(true)]
		public string Firma2 
		{
			get { return GetColumnValue<string>(Columns.Firma2); }
			set { SetColumnValue(Columns.Firma2, value); }
		}
		  
		[XmlAttribute("Firma3")]
		[Bindable(true)]
		public string Firma3 
		{
			get { return GetColumnValue<string>(Columns.Firma3); }
			set { SetColumnValue(Columns.Firma3, value); }
		}
		  
		[XmlAttribute("Acceso1")]
		[Bindable(true)]
		public string Acceso1 
		{
			get { return GetColumnValue<string>(Columns.Acceso1); }
			set { SetColumnValue(Columns.Acceso1, value); }
		}
		  
		[XmlAttribute("Acceso2")]
		[Bindable(true)]
		public string Acceso2 
		{
			get { return GetColumnValue<string>(Columns.Acceso2); }
			set { SetColumnValue(Columns.Acceso2, value); }
		}
		  
		[XmlAttribute("Acceso3")]
		[Bindable(true)]
		public string Acceso3 
		{
			get { return GetColumnValue<string>(Columns.Acceso3); }
			set { SetColumnValue(Columns.Acceso3, value); }
		}
		  
		[XmlAttribute("Acceso4")]
		[Bindable(true)]
		public string Acceso4 
		{
			get { return GetColumnValue<string>(Columns.Acceso4); }
			set { SetColumnValue(Columns.Acceso4, value); }
		}
		  
		[XmlAttribute("Acceso5")]
		[Bindable(true)]
		public string Acceso5 
		{
			get { return GetColumnValue<string>(Columns.Acceso5); }
			set { SetColumnValue(Columns.Acceso5, value); }
		}
		  
		[XmlAttribute("Acceso6")]
		[Bindable(true)]
		public string Acceso6 
		{
			get { return GetColumnValue<string>(Columns.Acceso6); }
			set { SetColumnValue(Columns.Acceso6, value); }
		}
		  
		[XmlAttribute("AvisarOc")]
		[Bindable(true)]
		public short? AvisarOc 
		{
			get { return GetColumnValue<short?>(Columns.AvisarOc); }
			set { SetColumnValue(Columns.AvisarOc, value); }
		}
		  
		[XmlAttribute("IdLugarPedidoComida")]
		[Bindable(true)]
		public short? IdLugarPedidoComida 
		{
			get { return GetColumnValue<short?>(Columns.IdLugarPedidoComida); }
			set { SetColumnValue(Columns.IdLugarPedidoComida, value); }
		}
		  
		[XmlAttribute("Acceso7")]
		[Bindable(true)]
		public string Acceso7 
		{
			get { return GetColumnValue<string>(Columns.Acceso7); }
			set { SetColumnValue(Columns.Acceso7, value); }
		}
		  
		[XmlAttribute("Acceso8")]
		[Bindable(true)]
		public string Acceso8 
		{
			get { return GetColumnValue<string>(Columns.Acceso8); }
			set { SetColumnValue(Columns.Acceso8, value); }
		}
		  
		[XmlAttribute("Acceso9")]
		[Bindable(true)]
		public string Acceso9 
		{
			get { return GetColumnValue<string>(Columns.Acceso9); }
			set { SetColumnValue(Columns.Acceso9, value); }
		}
		  
		[XmlAttribute("Acceso10")]
		[Bindable(true)]
		public string Acceso10 
		{
			get { return GetColumnValue<string>(Columns.Acceso10); }
			set { SetColumnValue(Columns.Acceso10, value); }
		}
		  
		[XmlAttribute("Acceso11")]
		[Bindable(true)]
		public string Acceso11 
		{
			get { return GetColumnValue<string>(Columns.Acceso11); }
			set { SetColumnValue(Columns.Acceso11, value); }
		}
		  
		[XmlAttribute("Acceso12")]
		[Bindable(true)]
		public string Acceso12 
		{
			get { return GetColumnValue<string>(Columns.Acceso12); }
			set { SetColumnValue(Columns.Acceso12, value); }
		}
		  
		[XmlAttribute("TipoLic")]
		[Bindable(true)]
		public string TipoLic 
		{
			get { return GetColumnValue<string>(Columns.TipoLic); }
			set { SetColumnValue(Columns.TipoLic, value); }
		}
		  
		[XmlAttribute("Iniciales")]
		[Bindable(true)]
		public string Iniciales 
		{
			get { return GetColumnValue<string>(Columns.Iniciales); }
			set { SetColumnValue(Columns.Iniciales, value); }
		}
		  
		[XmlAttribute("PciaUbicacion")]
		[Bindable(true)]
		public short? PciaUbicacion 
		{
			get { return GetColumnValue<short?>(Columns.PciaUbicacion); }
			set { SetColumnValue(Columns.PciaUbicacion, value); }
		}
		  
		[XmlAttribute("NroTarjeta")]
		[Bindable(true)]
		public string NroTarjeta 
		{
			get { return GetColumnValue<string>(Columns.NroTarjeta); }
			set { SetColumnValue(Columns.NroTarjeta, value); }
		}
		  
		[XmlAttribute("VersionTarjeta")]
		[Bindable(true)]
		public short? VersionTarjeta 
		{
			get { return GetColumnValue<short?>(Columns.VersionTarjeta); }
			set { SetColumnValue(Columns.VersionTarjeta, value); }
		}
		  
		[XmlAttribute("Visible")]
		[Bindable(true)]
		public short? Visible 
		{
			get { return GetColumnValue<short?>(Columns.Visible); }
			set { SetColumnValue(Columns.Visible, value); }
		}
		  
		[XmlAttribute("AccesoRemoto")]
		[Bindable(true)]
		public short? AccesoRemoto 
		{
			get { return GetColumnValue<short?>(Columns.AccesoRemoto); }
			set { SetColumnValue(Columns.AccesoRemoto, value); }
		}
		  
		[XmlAttribute("Foto")]
		[Bindable(true)]
		public byte[] Foto 
		{
			get { return GetColumnValue<byte[]>(Columns.Foto); }
			set { SetColumnValue(Columns.Foto, value); }
		}
		  
		[XmlAttribute("Huella")]
		[Bindable(true)]
		public byte[] Huella 
		{
			get { return GetColumnValue<byte[]>(Columns.Huella); }
			set { SetColumnValue(Columns.Huella, value); }
		}
		  
		[XmlAttribute("Huella1")]
		[Bindable(true)]
		public byte[] Huella1 
		{
			get { return GetColumnValue<byte[]>(Columns.Huella1); }
			set { SetColumnValue(Columns.Huella1, value); }
		}
		  
		[XmlAttribute("Huella2")]
		[Bindable(true)]
		public byte[] Huella2 
		{
			get { return GetColumnValue<byte[]>(Columns.Huella2); }
			set { SetColumnValue(Columns.Huella2, value); }
		}
		  
		[XmlAttribute("Huella3")]
		[Bindable(true)]
		public byte[] Huella3 
		{
			get { return GetColumnValue<byte[]>(Columns.Huella3); }
			set { SetColumnValue(Columns.Huella3, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalSic.PnGruposUsuarioCollection colPnGruposUsuarios;
		public DalSic.PnGruposUsuarioCollection PnGruposUsuarios
		{
			get
			{
				if(colPnGruposUsuarios == null)
				{
					colPnGruposUsuarios = new DalSic.PnGruposUsuarioCollection().Where(PnGruposUsuario.Columns.IdUsuario, IdUsuario).Load();
					colPnGruposUsuarios.ListChanged += new ListChangedEventHandler(colPnGruposUsuarios_ListChanged);
				}
				return colPnGruposUsuarios;			
			}
			set 
			{ 
					colPnGruposUsuarios = value; 
					colPnGruposUsuarios.ListChanged += new ListChangedEventHandler(colPnGruposUsuarios_ListChanged);
			}
		}
		
		void colPnGruposUsuarios_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnGruposUsuarios[e.NewIndex].IdUsuario = IdUsuario;
		    }
		}
				
		private DalSic.PnPermisosActualeCollection colPnPermisosActuales;
		public DalSic.PnPermisosActualeCollection PnPermisosActuales
		{
			get
			{
				if(colPnPermisosActuales == null)
				{
					colPnPermisosActuales = new DalSic.PnPermisosActualeCollection().Where(PnPermisosActuale.Columns.IdUsuario, IdUsuario).Load();
					colPnPermisosActuales.ListChanged += new ListChangedEventHandler(colPnPermisosActuales_ListChanged);
				}
				return colPnPermisosActuales;			
			}
			set 
			{ 
					colPnPermisosActuales = value; 
					colPnPermisosActuales.ListChanged += new ListChangedEventHandler(colPnPermisosActuales_ListChanged);
			}
		}
		
		void colPnPermisosActuales_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisosActuales[e.NewIndex].IdUsuario = IdUsuario;
		    }
		}
				
		private DalSic.PnPermisosSesionCollection colPnPermisosSesionRecords;
		public DalSic.PnPermisosSesionCollection PnPermisosSesionRecords
		{
			get
			{
				if(colPnPermisosSesionRecords == null)
				{
					colPnPermisosSesionRecords = new DalSic.PnPermisosSesionCollection().Where(PnPermisosSesion.Columns.IdUsuario, IdUsuario).Load();
					colPnPermisosSesionRecords.ListChanged += new ListChangedEventHandler(colPnPermisosSesionRecords_ListChanged);
				}
				return colPnPermisosSesionRecords;			
			}
			set 
			{ 
					colPnPermisosSesionRecords = value; 
					colPnPermisosSesionRecords.ListChanged += new ListChangedEventHandler(colPnPermisosSesionRecords_ListChanged);
			}
		}
		
		void colPnPermisosSesionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisosSesionRecords[e.NewIndex].IdUsuario = IdUsuario;
		    }
		}
				
		private DalSic.PnPermisosUsuarioCollection colPnPermisosUsuarios;
		public DalSic.PnPermisosUsuarioCollection PnPermisosUsuarios
		{
			get
			{
				if(colPnPermisosUsuarios == null)
				{
					colPnPermisosUsuarios = new DalSic.PnPermisosUsuarioCollection().Where(PnPermisosUsuario.Columns.IdUsuario, IdUsuario).Load();
					colPnPermisosUsuarios.ListChanged += new ListChangedEventHandler(colPnPermisosUsuarios_ListChanged);
				}
				return colPnPermisosUsuarios;			
			}
			set 
			{ 
					colPnPermisosUsuarios = value; 
					colPnPermisosUsuarios.ListChanged += new ListChangedEventHandler(colPnPermisosUsuarios_ListChanged);
			}
		}
		
		void colPnPermisosUsuarios_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colPnPermisosUsuarios[e.NewIndex].IdUsuario = IdUsuario;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varLogin,string varPasswd,string varNombre,string varApellido,string varDireccion,string varTelefono,string varCelular,string varMail,DateTime? varFechaAlta,string varComentarios,string varPaginaInicio,string varFirma1,string varFirma2,string varFirma3,string varAcceso1,string varAcceso2,string varAcceso3,string varAcceso4,string varAcceso5,string varAcceso6,short? varAvisarOc,short? varIdLugarPedidoComida,string varAcceso7,string varAcceso8,string varAcceso9,string varAcceso10,string varAcceso11,string varAcceso12,string varTipoLic,string varIniciales,short? varPciaUbicacion,string varNroTarjeta,short? varVersionTarjeta,short? varVisible,short? varAccesoRemoto,byte[] varFoto,byte[] varHuella,byte[] varHuella1,byte[] varHuella2,byte[] varHuella3)
		{
			PnUsuario item = new PnUsuario();
			
			item.Login = varLogin;
			
			item.Passwd = varPasswd;
			
			item.Nombre = varNombre;
			
			item.Apellido = varApellido;
			
			item.Direccion = varDireccion;
			
			item.Telefono = varTelefono;
			
			item.Celular = varCelular;
			
			item.Mail = varMail;
			
			item.FechaAlta = varFechaAlta;
			
			item.Comentarios = varComentarios;
			
			item.PaginaInicio = varPaginaInicio;
			
			item.Firma1 = varFirma1;
			
			item.Firma2 = varFirma2;
			
			item.Firma3 = varFirma3;
			
			item.Acceso1 = varAcceso1;
			
			item.Acceso2 = varAcceso2;
			
			item.Acceso3 = varAcceso3;
			
			item.Acceso4 = varAcceso4;
			
			item.Acceso5 = varAcceso5;
			
			item.Acceso6 = varAcceso6;
			
			item.AvisarOc = varAvisarOc;
			
			item.IdLugarPedidoComida = varIdLugarPedidoComida;
			
			item.Acceso7 = varAcceso7;
			
			item.Acceso8 = varAcceso8;
			
			item.Acceso9 = varAcceso9;
			
			item.Acceso10 = varAcceso10;
			
			item.Acceso11 = varAcceso11;
			
			item.Acceso12 = varAcceso12;
			
			item.TipoLic = varTipoLic;
			
			item.Iniciales = varIniciales;
			
			item.PciaUbicacion = varPciaUbicacion;
			
			item.NroTarjeta = varNroTarjeta;
			
			item.VersionTarjeta = varVersionTarjeta;
			
			item.Visible = varVisible;
			
			item.AccesoRemoto = varAccesoRemoto;
			
			item.Foto = varFoto;
			
			item.Huella = varHuella;
			
			item.Huella1 = varHuella1;
			
			item.Huella2 = varHuella2;
			
			item.Huella3 = varHuella3;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdUsuario,string varLogin,string varPasswd,string varNombre,string varApellido,string varDireccion,string varTelefono,string varCelular,string varMail,DateTime? varFechaAlta,string varComentarios,string varPaginaInicio,string varFirma1,string varFirma2,string varFirma3,string varAcceso1,string varAcceso2,string varAcceso3,string varAcceso4,string varAcceso5,string varAcceso6,short? varAvisarOc,short? varIdLugarPedidoComida,string varAcceso7,string varAcceso8,string varAcceso9,string varAcceso10,string varAcceso11,string varAcceso12,string varTipoLic,string varIniciales,short? varPciaUbicacion,string varNroTarjeta,short? varVersionTarjeta,short? varVisible,short? varAccesoRemoto,byte[] varFoto,byte[] varHuella,byte[] varHuella1,byte[] varHuella2,byte[] varHuella3)
		{
			PnUsuario item = new PnUsuario();
			
				item.IdUsuario = varIdUsuario;
			
				item.Login = varLogin;
			
				item.Passwd = varPasswd;
			
				item.Nombre = varNombre;
			
				item.Apellido = varApellido;
			
				item.Direccion = varDireccion;
			
				item.Telefono = varTelefono;
			
				item.Celular = varCelular;
			
				item.Mail = varMail;
			
				item.FechaAlta = varFechaAlta;
			
				item.Comentarios = varComentarios;
			
				item.PaginaInicio = varPaginaInicio;
			
				item.Firma1 = varFirma1;
			
				item.Firma2 = varFirma2;
			
				item.Firma3 = varFirma3;
			
				item.Acceso1 = varAcceso1;
			
				item.Acceso2 = varAcceso2;
			
				item.Acceso3 = varAcceso3;
			
				item.Acceso4 = varAcceso4;
			
				item.Acceso5 = varAcceso5;
			
				item.Acceso6 = varAcceso6;
			
				item.AvisarOc = varAvisarOc;
			
				item.IdLugarPedidoComida = varIdLugarPedidoComida;
			
				item.Acceso7 = varAcceso7;
			
				item.Acceso8 = varAcceso8;
			
				item.Acceso9 = varAcceso9;
			
				item.Acceso10 = varAcceso10;
			
				item.Acceso11 = varAcceso11;
			
				item.Acceso12 = varAcceso12;
			
				item.TipoLic = varTipoLic;
			
				item.Iniciales = varIniciales;
			
				item.PciaUbicacion = varPciaUbicacion;
			
				item.NroTarjeta = varNroTarjeta;
			
				item.VersionTarjeta = varVersionTarjeta;
			
				item.Visible = varVisible;
			
				item.AccesoRemoto = varAccesoRemoto;
			
				item.Foto = varFoto;
			
				item.Huella = varHuella;
			
				item.Huella1 = varHuella1;
			
				item.Huella2 = varHuella2;
			
				item.Huella3 = varHuella3;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdUsuarioColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn LoginColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CelularColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn MailColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAltaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentariosColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn PaginaInicioColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn Firma1Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn Firma2Column
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn Firma3Column
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso1Column
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso2Column
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso3Column
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso4Column
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso5Column
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso6Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn AvisarOcColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLugarPedidoComidaColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso7Column
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso8Column
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso9Column
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso10Column
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso11Column
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn Acceso12Column
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoLicColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn InicialesColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn PciaUbicacionColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn NroTarjetaColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn VersionTarjetaColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn VisibleColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        public static TableSchema.TableColumn AccesoRemotoColumn
        {
            get { return Schema.Columns[35]; }
        }
        
        
        
        public static TableSchema.TableColumn FotoColumn
        {
            get { return Schema.Columns[36]; }
        }
        
        
        
        public static TableSchema.TableColumn HuellaColumn
        {
            get { return Schema.Columns[37]; }
        }
        
        
        
        public static TableSchema.TableColumn Huella1Column
        {
            get { return Schema.Columns[38]; }
        }
        
        
        
        public static TableSchema.TableColumn Huella2Column
        {
            get { return Schema.Columns[39]; }
        }
        
        
        
        public static TableSchema.TableColumn Huella3Column
        {
            get { return Schema.Columns[40]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdUsuario = @"id_usuario";
			 public static string Login = @"login";
			 public static string Passwd = @"passwd";
			 public static string Nombre = @"nombre";
			 public static string Apellido = @"apellido";
			 public static string Direccion = @"direccion";
			 public static string Telefono = @"telefono";
			 public static string Celular = @"celular";
			 public static string Mail = @"mail";
			 public static string FechaAlta = @"fecha_alta";
			 public static string Comentarios = @"comentarios";
			 public static string PaginaInicio = @"pagina_inicio";
			 public static string Firma1 = @"firma1";
			 public static string Firma2 = @"firma2";
			 public static string Firma3 = @"firma3";
			 public static string Acceso1 = @"acceso1";
			 public static string Acceso2 = @"acceso2";
			 public static string Acceso3 = @"acceso3";
			 public static string Acceso4 = @"acceso4";
			 public static string Acceso5 = @"acceso5";
			 public static string Acceso6 = @"acceso6";
			 public static string AvisarOc = @"avisar_oc";
			 public static string IdLugarPedidoComida = @"id_lugar_pedido_comida";
			 public static string Acceso7 = @"acceso7";
			 public static string Acceso8 = @"acceso8";
			 public static string Acceso9 = @"acceso9";
			 public static string Acceso10 = @"acceso10";
			 public static string Acceso11 = @"acceso11";
			 public static string Acceso12 = @"acceso12";
			 public static string TipoLic = @"tipo_lic";
			 public static string Iniciales = @"iniciales";
			 public static string PciaUbicacion = @"pcia_ubicacion";
			 public static string NroTarjeta = @"nro_tarjeta";
			 public static string VersionTarjeta = @"version_tarjeta";
			 public static string Visible = @"visible";
			 public static string AccesoRemoto = @"acceso_remoto";
			 public static string Foto = @"foto";
			 public static string Huella = @"huella";
			 public static string Huella1 = @"huella1";
			 public static string Huella2 = @"huella2";
			 public static string Huella3 = @"huella3";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colPnGruposUsuarios != null)
                {
                    foreach (DalSic.PnGruposUsuario item in colPnGruposUsuarios)
                    {
                        if (item.IdUsuario != IdUsuario)
                        {
                            item.IdUsuario = IdUsuario;
                        }
                    }
               }
		
                if (colPnPermisosActuales != null)
                {
                    foreach (DalSic.PnPermisosActuale item in colPnPermisosActuales)
                    {
                        if (item.IdUsuario != IdUsuario)
                        {
                            item.IdUsuario = IdUsuario;
                        }
                    }
               }
		
                if (colPnPermisosSesionRecords != null)
                {
                    foreach (DalSic.PnPermisosSesion item in colPnPermisosSesionRecords)
                    {
                        if (item.IdUsuario != IdUsuario)
                        {
                            item.IdUsuario = IdUsuario;
                        }
                    }
               }
		
                if (colPnPermisosUsuarios != null)
                {
                    foreach (DalSic.PnPermisosUsuario item in colPnPermisosUsuarios)
                    {
                        if (item.IdUsuario != IdUsuario)
                        {
                            item.IdUsuario = IdUsuario;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colPnGruposUsuarios != null)
                {
                    colPnGruposUsuarios.SaveAll();
               }
		
                if (colPnPermisosActuales != null)
                {
                    colPnPermisosActuales.SaveAll();
               }
		
                if (colPnPermisosSesionRecords != null)
                {
                    colPnPermisosSesionRecords.SaveAll();
               }
		
                if (colPnPermisosUsuarios != null)
                {
                    colPnPermisosUsuarios.SaveAll();
               }
		}
        #endregion
	}
}
