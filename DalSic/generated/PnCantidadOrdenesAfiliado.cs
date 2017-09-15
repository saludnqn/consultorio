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
namespace DalSic{
    /// <summary>
    /// Strongly-typed collection for the PnCantidadOrdenesAfiliado class.
    /// </summary>
    [Serializable]
    public partial class PnCantidadOrdenesAfiliadoCollection : ReadOnlyList<PnCantidadOrdenesAfiliado, PnCantidadOrdenesAfiliadoCollection>
    {        
        public PnCantidadOrdenesAfiliadoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the PN_CantidadOrdenesAfiliados view.
    /// </summary>
    [Serializable]
    public partial class PnCantidadOrdenesAfiliado : ReadOnlyRecord<PnCantidadOrdenesAfiliado>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("PN_CantidadOrdenesAfiliados", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarIdSmiafiliados = new TableSchema.TableColumn(schema);
                colvarIdSmiafiliados.ColumnName = "id_smiafiliados";
                colvarIdSmiafiliados.DataType = DbType.Int32;
                colvarIdSmiafiliados.MaxLength = 0;
                colvarIdSmiafiliados.AutoIncrement = false;
                colvarIdSmiafiliados.IsNullable = true;
                colvarIdSmiafiliados.IsPrimaryKey = false;
                colvarIdSmiafiliados.IsForeignKey = false;
                colvarIdSmiafiliados.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdSmiafiliados);
                
                TableSchema.TableColumn colvarCantidadOrdenes = new TableSchema.TableColumn(schema);
                colvarCantidadOrdenes.ColumnName = "cantidadOrdenes";
                colvarCantidadOrdenes.DataType = DbType.Int32;
                colvarCantidadOrdenes.MaxLength = 0;
                colvarCantidadOrdenes.AutoIncrement = false;
                colvarCantidadOrdenes.IsNullable = true;
                colvarCantidadOrdenes.IsPrimaryKey = false;
                colvarCantidadOrdenes.IsForeignKey = false;
                colvarCantidadOrdenes.IsReadOnly = false;
                
                schema.Columns.Add(colvarCantidadOrdenes);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("PN_CantidadOrdenesAfiliados",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public PnCantidadOrdenesAfiliado()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public PnCantidadOrdenesAfiliado(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public PnCantidadOrdenesAfiliado(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public PnCantidadOrdenesAfiliado(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("IdSmiafiliados")]
        [Bindable(true)]
        public int? IdSmiafiliados 
	    {
		    get
		    {
			    return GetColumnValue<int?>("id_smiafiliados");
		    }
            set 
		    {
			    SetColumnValue("id_smiafiliados", value);
            }
        }
	      
        [XmlAttribute("CantidadOrdenes")]
        [Bindable(true)]
        public int? CantidadOrdenes 
	    {
		    get
		    {
			    return GetColumnValue<int?>("cantidadOrdenes");
		    }
            set 
		    {
			    SetColumnValue("cantidadOrdenes", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string IdSmiafiliados = @"id_smiafiliados";
            
            public static string CantidadOrdenes = @"cantidadOrdenes";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
