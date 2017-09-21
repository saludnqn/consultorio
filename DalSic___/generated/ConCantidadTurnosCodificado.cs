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
    /// Strongly-typed collection for the ConCantidadTurnosCodificado class.
    /// </summary>
    [Serializable]
    public partial class ConCantidadTurnosCodificadoCollection : ReadOnlyList<ConCantidadTurnosCodificado, ConCantidadTurnosCodificadoCollection>
    {        
        public ConCantidadTurnosCodificadoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the CON_CantidadTurnosCodificados view.
    /// </summary>
    [Serializable]
    public partial class ConCantidadTurnosCodificado : ReadOnlyRecord<ConCantidadTurnosCodificado>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("CON_CantidadTurnosCodificados", TableType.View, DataService.GetInstance("sicProvider"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
                colvarCantidad.ColumnName = "cantidad";
                colvarCantidad.DataType = DbType.Int32;
                colvarCantidad.MaxLength = 0;
                colvarCantidad.AutoIncrement = false;
                colvarCantidad.IsNullable = true;
                colvarCantidad.IsPrimaryKey = false;
                colvarCantidad.IsForeignKey = false;
                colvarCantidad.IsReadOnly = false;
                
                schema.Columns.Add(colvarCantidad);
                
                TableSchema.TableColumn colvarIdturno = new TableSchema.TableColumn(schema);
                colvarIdturno.ColumnName = "idturno";
                colvarIdturno.DataType = DbType.Int32;
                colvarIdturno.MaxLength = 0;
                colvarIdturno.AutoIncrement = false;
                colvarIdturno.IsNullable = false;
                colvarIdturno.IsPrimaryKey = false;
                colvarIdturno.IsForeignKey = false;
                colvarIdturno.IsReadOnly = false;
                
                schema.Columns.Add(colvarIdturno);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["sicProvider"].AddSchema("CON_CantidadTurnosCodificados",schema);
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
	    public ConCantidadTurnosCodificado()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ConCantidadTurnosCodificado(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ConCantidadTurnosCodificado(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ConCantidadTurnosCodificado(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Cantidad")]
        [Bindable(true)]
        public int? Cantidad 
	    {
		    get
		    {
			    return GetColumnValue<int?>("cantidad");
		    }
            set 
		    {
			    SetColumnValue("cantidad", value);
            }
        }
	      
        [XmlAttribute("Idturno")]
        [Bindable(true)]
        public int Idturno 
	    {
		    get
		    {
			    return GetColumnValue<int>("idturno");
		    }
            set 
		    {
			    SetColumnValue("idturno", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Cantidad = @"cantidad";
            
            public static string Idturno = @"idturno";
            
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
