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
	/// Strongly-typed collection for the PnMailEfeConv class.
	/// </summary>
    [Serializable]
	public partial class PnMailEfeConvCollection : ActiveList<PnMailEfeConv, PnMailEfeConvCollection>
	{	   
		public PnMailEfeConvCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PnMailEfeConvCollection</returns>
		public PnMailEfeConvCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PnMailEfeConv o = this[i];
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
	/// This is an ActiveRecord class which wraps the PN_mail_efe_conv table.
	/// </summary>
	[Serializable]
	public partial class PnMailEfeConv : ActiveRecord<PnMailEfeConv>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PnMailEfeConv()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PnMailEfeConv(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PnMailEfeConv(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PnMailEfeConv(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PN_mail_efe_conv", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdMailEfeConv = new TableSchema.TableColumn(schema);
				colvarIdMailEfeConv.ColumnName = "id_mail_efe_conv";
				colvarIdMailEfeConv.DataType = DbType.Int32;
				colvarIdMailEfeConv.MaxLength = 0;
				colvarIdMailEfeConv.AutoIncrement = true;
				colvarIdMailEfeConv.IsNullable = false;
				colvarIdMailEfeConv.IsPrimaryKey = true;
				colvarIdMailEfeConv.IsForeignKey = false;
				colvarIdMailEfeConv.IsReadOnly = false;
				colvarIdMailEfeConv.DefaultSetting = @"";
				colvarIdMailEfeConv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdMailEfeConv);
				
				TableSchema.TableColumn colvarCuie = new TableSchema.TableColumn(schema);
				colvarCuie.ColumnName = "cuie";
				colvarCuie.DataType = DbType.AnsiString;
				colvarCuie.MaxLength = 10;
				colvarCuie.AutoIncrement = false;
				colvarCuie.IsNullable = false;
				colvarCuie.IsPrimaryKey = false;
				colvarCuie.IsForeignKey = false;
				colvarCuie.IsReadOnly = false;
				colvarCuie.DefaultSetting = @"";
				colvarCuie.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuie);
				
				TableSchema.TableColumn colvarDescripcion = new TableSchema.TableColumn(schema);
				colvarDescripcion.ColumnName = "descripcion";
				colvarDescripcion.DataType = DbType.AnsiString;
				colvarDescripcion.MaxLength = -1;
				colvarDescripcion.AutoIncrement = false;
				colvarDescripcion.IsNullable = true;
				colvarDescripcion.IsPrimaryKey = false;
				colvarDescripcion.IsForeignKey = false;
				colvarDescripcion.IsReadOnly = false;
				colvarDescripcion.DefaultSetting = @"";
				colvarDescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcion);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("PN_mail_efe_conv",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdMailEfeConv")]
		[Bindable(true)]
		public int IdMailEfeConv 
		{
			get { return GetColumnValue<int>(Columns.IdMailEfeConv); }
			set { SetColumnValue(Columns.IdMailEfeConv, value); }
		}
		  
		[XmlAttribute("Cuie")]
		[Bindable(true)]
		public string Cuie 
		{
			get { return GetColumnValue<string>(Columns.Cuie); }
			set { SetColumnValue(Columns.Cuie, value); }
		}
		  
		[XmlAttribute("Descripcion")]
		[Bindable(true)]
		public string Descripcion 
		{
			get { return GetColumnValue<string>(Columns.Descripcion); }
			set { SetColumnValue(Columns.Descripcion, value); }
		}
		  
		[XmlAttribute("Mail")]
		[Bindable(true)]
		public string Mail 
		{
			get { return GetColumnValue<string>(Columns.Mail); }
			set { SetColumnValue(Columns.Mail, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCuie,string varDescripcion,string varMail)
		{
			PnMailEfeConv item = new PnMailEfeConv();
			
			item.Cuie = varCuie;
			
			item.Descripcion = varDescripcion;
			
			item.Mail = varMail;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdMailEfeConv,string varCuie,string varDescripcion,string varMail)
		{
			PnMailEfeConv item = new PnMailEfeConv();
			
				item.IdMailEfeConv = varIdMailEfeConv;
			
				item.Cuie = varCuie;
			
				item.Descripcion = varDescripcion;
			
				item.Mail = varMail;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdMailEfeConvColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CuieColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MailColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdMailEfeConv = @"id_mail_efe_conv";
			 public static string Cuie = @"cuie";
			 public static string Descripcion = @"descripcion";
			 public static string Mail = @"mail";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
