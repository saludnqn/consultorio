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
	/// Strongly-typed collection for the PnMensaje class.
	/// </summary>
    [Serializable]
	public partial class PnMensajeCollection : ActiveList<PnMensaje, PnMensajeCollection>
	{	   
		public PnMensajeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnMensajeCollection</returns>
		public PnMensajeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnMensaje o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_mensajes table.
	/// </summary>
	[Serializable]
	public partial class PnMensaje : ActiveRecord<PnMensaje>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnMensaje()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnMensaje(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnMensaje(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnMensaje(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_mensajes", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMensaje = new TableSchema.TableColumn(schema);
				colvarIdMensaje.ColumnName = "id_mensaje";
				colvarIdMensaje.DataType = DbType.Int32;
				colvarIdMensaje.MaxLength = 0;
				colvarIdMensaje.AutoIncrement = true;
				colvarIdMensaje.IsNullable = false;
				colvarIdMensaje.IsPrimaryKey = true;
				colvarIdMensaje.IsForeignKey = false;
				colvarIdMensaje.IsReadOnly = false;
				colvarIdMensaje.DefaultSetting = @"";
				colvarIdMensaje.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMensaje);
				
				TableSchema.TableColumn colvarTipo1 = new TableSchema.TableColumn(schema);
				colvarTipo1.ColumnName = "tipo1";
				colvarTipo1.DataType = DbType.AnsiString;
				colvarTipo1.MaxLength = -1;
				colvarTipo1.AutoIncrement = false;
				colvarTipo1.IsNullable = true;
				colvarTipo1.IsPrimaryKey = false;
				colvarTipo1.IsForeignKey = false;
				colvarTipo1.IsReadOnly = false;
				colvarTipo1.DefaultSetting = @"";
				colvarTipo1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo1);
				
				TableSchema.TableColumn colvarTipo2 = new TableSchema.TableColumn(schema);
				colvarTipo2.ColumnName = "tipo2";
				colvarTipo2.DataType = DbType.AnsiString;
				colvarTipo2.MaxLength = -1;
				colvarTipo2.AutoIncrement = false;
				colvarTipo2.IsNullable = true;
				colvarTipo2.IsPrimaryKey = false;
				colvarTipo2.IsForeignKey = false;
				colvarTipo2.IsReadOnly = false;
				colvarTipo2.DefaultSetting = @"";
				colvarTipo2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo2);
				
				TableSchema.TableColumn colvarNumero = new TableSchema.TableColumn(schema);
				colvarNumero.ColumnName = "numero";
				colvarNumero.DataType = DbType.Int32;
				colvarNumero.MaxLength = 0;
				colvarNumero.AutoIncrement = false;
				colvarNumero.IsNullable = true;
				colvarNumero.IsPrimaryKey = false;
				colvarNumero.IsForeignKey = false;
				colvarNumero.IsReadOnly = false;
				colvarNumero.DefaultSetting = @"";
				colvarNumero.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumero);
				
				TableSchema.TableColumn colvarUsuarioOrigen = new TableSchema.TableColumn(schema);
				colvarUsuarioOrigen.ColumnName = "usuario_origen";
				colvarUsuarioOrigen.DataType = DbType.AnsiString;
				colvarUsuarioOrigen.MaxLength = -1;
				colvarUsuarioOrigen.AutoIncrement = false;
				colvarUsuarioOrigen.IsNullable = true;
				colvarUsuarioOrigen.IsPrimaryKey = false;
				colvarUsuarioOrigen.IsForeignKey = false;
				colvarUsuarioOrigen.IsReadOnly = false;
				colvarUsuarioOrigen.DefaultSetting = @"";
				colvarUsuarioOrigen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioOrigen);
				
				TableSchema.TableColumn colvarComentario = new TableSchema.TableColumn(schema);
				colvarComentario.ColumnName = "comentario";
				colvarComentario.DataType = DbType.AnsiString;
				colvarComentario.MaxLength = -1;
				colvarComentario.AutoIncrement = false;
				colvarComentario.IsNullable = true;
				colvarComentario.IsPrimaryKey = false;
				colvarComentario.IsForeignKey = false;
				colvarComentario.IsReadOnly = false;
				colvarComentario.DefaultSetting = @"";
				colvarComentario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComentario);
				
				TableSchema.TableColumn colvarUsuarioDestino = new TableSchema.TableColumn(schema);
				colvarUsuarioDestino.ColumnName = "usuario_destino";
				colvarUsuarioDestino.DataType = DbType.AnsiString;
				colvarUsuarioDestino.MaxLength = -1;
				colvarUsuarioDestino.AutoIncrement = false;
				colvarUsuarioDestino.IsNullable = true;
				colvarUsuarioDestino.IsPrimaryKey = false;
				colvarUsuarioDestino.IsForeignKey = false;
				colvarUsuarioDestino.IsReadOnly = false;
				colvarUsuarioDestino.DefaultSetting = @"";
				colvarUsuarioDestino.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioDestino);
				
				TableSchema.TableColumn colvarFechaEntrega = new TableSchema.TableColumn(schema);
				colvarFechaEntrega.ColumnName = "fecha_entrega";
				colvarFechaEntrega.DataType = DbType.DateTime;
				colvarFechaEntrega.MaxLength = 0;
				colvarFechaEntrega.AutoIncrement = false;
				colvarFechaEntrega.IsNullable = true;
				colvarFechaEntrega.IsPrimaryKey = false;
				colvarFechaEntrega.IsForeignKey = false;
				colvarFechaEntrega.IsReadOnly = false;
				colvarFechaEntrega.DefaultSetting = @"";
				colvarFechaEntrega.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaEntrega);
				
				TableSchema.TableColumn colvarFechaRecibo = new TableSchema.TableColumn(schema);
				colvarFechaRecibo.ColumnName = "fecha_recibo";
				colvarFechaRecibo.DataType = DbType.DateTime;
				colvarFechaRecibo.MaxLength = 0;
				colvarFechaRecibo.AutoIncrement = false;
				colvarFechaRecibo.IsNullable = true;
				colvarFechaRecibo.IsPrimaryKey = false;
				colvarFechaRecibo.IsForeignKey = false;
				colvarFechaRecibo.IsReadOnly = false;
				colvarFechaRecibo.DefaultSetting = @"";
				colvarFechaRecibo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecibo);
				
				TableSchema.TableColumn colvarFechaVencimiento = new TableSchema.TableColumn(schema);
				colvarFechaVencimiento.ColumnName = "fecha_vencimiento";
				colvarFechaVencimiento.DataType = DbType.DateTime;
				colvarFechaVencimiento.MaxLength = 0;
				colvarFechaVencimiento.AutoIncrement = false;
				colvarFechaVencimiento.IsNullable = true;
				colvarFechaVencimiento.IsPrimaryKey = false;
				colvarFechaVencimiento.IsForeignKey = false;
				colvarFechaVencimiento.IsReadOnly = false;
				colvarFechaVencimiento.DefaultSetting = @"";
				colvarFechaVencimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaVencimiento);
				
				TableSchema.TableColumn colvarFechaTerminado = new TableSchema.TableColumn(schema);
				colvarFechaTerminado.ColumnName = "fecha_terminado";
				colvarFechaTerminado.DataType = DbType.DateTime;
				colvarFechaTerminado.MaxLength = 0;
				colvarFechaTerminado.AutoIncrement = false;
				colvarFechaTerminado.IsNullable = true;
				colvarFechaTerminado.IsPrimaryKey = false;
				colvarFechaTerminado.IsForeignKey = false;
				colvarFechaTerminado.IsReadOnly = false;
				colvarFechaTerminado.DefaultSetting = @"";
				colvarFechaTerminado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaTerminado);
				
				TableSchema.TableColumn colvarNroOrden = new TableSchema.TableColumn(schema);
				colvarNroOrden.ColumnName = "nro_orden";
				colvarNroOrden.DataType = DbType.Int32;
				colvarNroOrden.MaxLength = 0;
				colvarNroOrden.AutoIncrement = false;
				colvarNroOrden.IsNullable = true;
				colvarNroOrden.IsPrimaryKey = false;
				colvarNroOrden.IsForeignKey = false;
				colvarNroOrden.IsReadOnly = false;
				colvarNroOrden.DefaultSetting = @"";
				colvarNroOrden.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroOrden);
				
				TableSchema.TableColumn colvarRecibido = new TableSchema.TableColumn(schema);
				colvarRecibido.ColumnName = "recibido";
				colvarRecibido.DataType = DbType.AnsiString;
				colvarRecibido.MaxLength = 5;
				colvarRecibido.AutoIncrement = false;
				colvarRecibido.IsNullable = true;
				colvarRecibido.IsPrimaryKey = false;
				colvarRecibido.IsForeignKey = false;
				colvarRecibido.IsReadOnly = false;
				colvarRecibido.DefaultSetting = @"";
				colvarRecibido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecibido);
				
				TableSchema.TableColumn colvarTerminado = new TableSchema.TableColumn(schema);
				colvarTerminado.ColumnName = "terminado";
				colvarTerminado.DataType = DbType.AnsiString;
				colvarTerminado.MaxLength = 5;
				colvarTerminado.AutoIncrement = false;
				colvarTerminado.IsNullable = true;
				colvarTerminado.IsPrimaryKey = false;
				colvarTerminado.IsForeignKey = false;
				colvarTerminado.IsReadOnly = false;
				colvarTerminado.DefaultSetting = @"";
				colvarTerminado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTerminado);
				
				TableSchema.TableColumn colvarDesestimado = new TableSchema.TableColumn(schema);
				colvarDesestimado.ColumnName = "desestimado";
				colvarDesestimado.DataType = DbType.AnsiString;
				colvarDesestimado.MaxLength = 5;
				colvarDesestimado.AutoIncrement = false;
				colvarDesestimado.IsNullable = true;
				colvarDesestimado.IsPrimaryKey = false;
				colvarDesestimado.IsForeignKey = false;
				colvarDesestimado.IsReadOnly = false;
				colvarDesestimado.DefaultSetting = @"";
				colvarDesestimado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDesestimado);
				
				TableSchema.TableColumn colvarTitulo = new TableSchema.TableColumn(schema);
				colvarTitulo.ColumnName = "titulo";
				colvarTitulo.DataType = DbType.AnsiString;
				colvarTitulo.MaxLength = -1;
				colvarTitulo.AutoIncrement = false;
				colvarTitulo.IsNullable = true;
				colvarTitulo.IsPrimaryKey = false;
				colvarTitulo.IsForeignKey = false;
				colvarTitulo.IsReadOnly = false;
				colvarTitulo.DefaultSetting = @"";
				colvarTitulo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitulo);
				
				TableSchema.TableColumn colvarEstadoFinal = new TableSchema.TableColumn(schema);
				colvarEstadoFinal.ColumnName = "estado_final";
				colvarEstadoFinal.DataType = DbType.AnsiString;
				colvarEstadoFinal.MaxLength = -1;
				colvarEstadoFinal.AutoIncrement = false;
				colvarEstadoFinal.IsNullable = true;
				colvarEstadoFinal.IsPrimaryKey = false;
				colvarEstadoFinal.IsForeignKey = false;
				colvarEstadoFinal.IsReadOnly = false;
				colvarEstadoFinal.DefaultSetting = @"";
				colvarEstadoFinal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstadoFinal);
				
				TableSchema.TableColumn colvarUsuarioFinaliza = new TableSchema.TableColumn(schema);
				colvarUsuarioFinaliza.ColumnName = "usuario_finaliza";
				colvarUsuarioFinaliza.DataType = DbType.AnsiString;
				colvarUsuarioFinaliza.MaxLength = -1;
				colvarUsuarioFinaliza.AutoIncrement = false;
				colvarUsuarioFinaliza.IsNullable = true;
				colvarUsuarioFinaliza.IsPrimaryKey = false;
				colvarUsuarioFinaliza.IsForeignKey = false;
				colvarUsuarioFinaliza.IsReadOnly = false;
				colvarUsuarioFinaliza.DefaultSetting = @"";
				colvarUsuarioFinaliza.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuarioFinaliza);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_mensajes",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMensaje")]
		[Bindable(true)]
		public int IdMensaje 
		{
			get { return GetColumnValue<int>(Columns.IdMensaje); }
			set { SetColumnValue(Columns.IdMensaje, value); }
		}
		  
		[XmlAttribute("Tipo1")]
		[Bindable(true)]
		public string Tipo1 
		{
			get { return GetColumnValue<string>(Columns.Tipo1); }
			set { SetColumnValue(Columns.Tipo1, value); }
		}
		  
		[XmlAttribute("Tipo2")]
		[Bindable(true)]
		public string Tipo2 
		{
			get { return GetColumnValue<string>(Columns.Tipo2); }
			set { SetColumnValue(Columns.Tipo2, value); }
		}
		  
		[XmlAttribute("Numero")]
		[Bindable(true)]
		public int? Numero 
		{
			get { return GetColumnValue<int?>(Columns.Numero); }
			set { SetColumnValue(Columns.Numero, value); }
		}
		  
		[XmlAttribute("UsuarioOrigen")]
		[Bindable(true)]
		public string UsuarioOrigen 
		{
			get { return GetColumnValue<string>(Columns.UsuarioOrigen); }
			set { SetColumnValue(Columns.UsuarioOrigen, value); }
		}
		  
		[XmlAttribute("Comentario")]
		[Bindable(true)]
		public string Comentario 
		{
			get { return GetColumnValue<string>(Columns.Comentario); }
			set { SetColumnValue(Columns.Comentario, value); }
		}
		  
		[XmlAttribute("UsuarioDestino")]
		[Bindable(true)]
		public string UsuarioDestino 
		{
			get { return GetColumnValue<string>(Columns.UsuarioDestino); }
			set { SetColumnValue(Columns.UsuarioDestino, value); }
		}
		  
		[XmlAttribute("FechaEntrega")]
		[Bindable(true)]
		public DateTime? FechaEntrega 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaEntrega); }
			set { SetColumnValue(Columns.FechaEntrega, value); }
		}
		  
		[XmlAttribute("FechaRecibo")]
		[Bindable(true)]
		public DateTime? FechaRecibo 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRecibo); }
			set { SetColumnValue(Columns.FechaRecibo, value); }
		}
		  
		[XmlAttribute("FechaVencimiento")]
		[Bindable(true)]
		public DateTime? FechaVencimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaVencimiento); }
			set { SetColumnValue(Columns.FechaVencimiento, value); }
		}
		  
		[XmlAttribute("FechaTerminado")]
		[Bindable(true)]
		public DateTime? FechaTerminado 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaTerminado); }
			set { SetColumnValue(Columns.FechaTerminado, value); }
		}
		  
		[XmlAttribute("NroOrden")]
		[Bindable(true)]
		public int? NroOrden 
		{
			get { return GetColumnValue<int?>(Columns.NroOrden); }
			set { SetColumnValue(Columns.NroOrden, value); }
		}
		  
		[XmlAttribute("Recibido")]
		[Bindable(true)]
		public string Recibido 
		{
			get { return GetColumnValue<string>(Columns.Recibido); }
			set { SetColumnValue(Columns.Recibido, value); }
		}
		  
		[XmlAttribute("Terminado")]
		[Bindable(true)]
		public string Terminado 
		{
			get { return GetColumnValue<string>(Columns.Terminado); }
			set { SetColumnValue(Columns.Terminado, value); }
		}
		  
		[XmlAttribute("Desestimado")]
		[Bindable(true)]
		public string Desestimado 
		{
			get { return GetColumnValue<string>(Columns.Desestimado); }
			set { SetColumnValue(Columns.Desestimado, value); }
		}
		  
		[XmlAttribute("Titulo")]
		[Bindable(true)]
		public string Titulo 
		{
			get { return GetColumnValue<string>(Columns.Titulo); }
			set { SetColumnValue(Columns.Titulo, value); }
		}
		  
		[XmlAttribute("EstadoFinal")]
		[Bindable(true)]
		public string EstadoFinal 
		{
			get { return GetColumnValue<string>(Columns.EstadoFinal); }
			set { SetColumnValue(Columns.EstadoFinal, value); }
		}
		  
		[XmlAttribute("UsuarioFinaliza")]
		[Bindable(true)]
		public string UsuarioFinaliza 
		{
			get { return GetColumnValue<string>(Columns.UsuarioFinaliza); }
			set { SetColumnValue(Columns.UsuarioFinaliza, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTipo1,string varTipo2,int? varNumero,string varUsuarioOrigen,string varComentario,string varUsuarioDestino,DateTime? varFechaEntrega,DateTime? varFechaRecibo,DateTime? varFechaVencimiento,DateTime? varFechaTerminado,int? varNroOrden,string varRecibido,string varTerminado,string varDesestimado,string varTitulo,string varEstadoFinal,string varUsuarioFinaliza)
		{
			PnMensaje item = new PnMensaje();
			
			item.Tipo1 = varTipo1;
			
			item.Tipo2 = varTipo2;
			
			item.Numero = varNumero;
			
			item.UsuarioOrigen = varUsuarioOrigen;
			
			item.Comentario = varComentario;
			
			item.UsuarioDestino = varUsuarioDestino;
			
			item.FechaEntrega = varFechaEntrega;
			
			item.FechaRecibo = varFechaRecibo;
			
			item.FechaVencimiento = varFechaVencimiento;
			
			item.FechaTerminado = varFechaTerminado;
			
			item.NroOrden = varNroOrden;
			
			item.Recibido = varRecibido;
			
			item.Terminado = varTerminado;
			
			item.Desestimado = varDesestimado;
			
			item.Titulo = varTitulo;
			
			item.EstadoFinal = varEstadoFinal;
			
			item.UsuarioFinaliza = varUsuarioFinaliza;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMensaje,string varTipo1,string varTipo2,int? varNumero,string varUsuarioOrigen,string varComentario,string varUsuarioDestino,DateTime? varFechaEntrega,DateTime? varFechaRecibo,DateTime? varFechaVencimiento,DateTime? varFechaTerminado,int? varNroOrden,string varRecibido,string varTerminado,string varDesestimado,string varTitulo,string varEstadoFinal,string varUsuarioFinaliza)
		{
			PnMensaje item = new PnMensaje();
			
				item.IdMensaje = varIdMensaje;
			
				item.Tipo1 = varTipo1;
			
				item.Tipo2 = varTipo2;
			
				item.Numero = varNumero;
			
				item.UsuarioOrigen = varUsuarioOrigen;
			
				item.Comentario = varComentario;
			
				item.UsuarioDestino = varUsuarioDestino;
			
				item.FechaEntrega = varFechaEntrega;
			
				item.FechaRecibo = varFechaRecibo;
			
				item.FechaVencimiento = varFechaVencimiento;
			
				item.FechaTerminado = varFechaTerminado;
			
				item.NroOrden = varNroOrden;
			
				item.Recibido = varRecibido;
			
				item.Terminado = varTerminado;
			
				item.Desestimado = varDesestimado;
			
				item.Titulo = varTitulo;
			
				item.EstadoFinal = varEstadoFinal;
			
				item.UsuarioFinaliza = varUsuarioFinaliza;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMensajeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn Tipo1Column
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn Tipo2Column
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioOrigenColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ComentarioColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioDestinoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaEntregaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaReciboColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaVencimientoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaTerminadoColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NroOrdenColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn RecibidoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn TerminadoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DesestimadoColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn TituloColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoFinalColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioFinalizaColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMensaje = @"id_mensaje";
			 public static string Tipo1 = @"tipo1";
			 public static string Tipo2 = @"tipo2";
			 public static string Numero = @"numero";
			 public static string UsuarioOrigen = @"usuario_origen";
			 public static string Comentario = @"comentario";
			 public static string UsuarioDestino = @"usuario_destino";
			 public static string FechaEntrega = @"fecha_entrega";
			 public static string FechaRecibo = @"fecha_recibo";
			 public static string FechaVencimiento = @"fecha_vencimiento";
			 public static string FechaTerminado = @"fecha_terminado";
			 public static string NroOrden = @"nro_orden";
			 public static string Recibido = @"recibido";
			 public static string Terminado = @"terminado";
			 public static string Desestimado = @"desestimado";
			 public static string Titulo = @"titulo";
			 public static string EstadoFinal = @"estado_final";
			 public static string UsuarioFinaliza = @"usuario_finaliza";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
