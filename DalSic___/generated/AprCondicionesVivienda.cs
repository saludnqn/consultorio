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
	/// Strongly-typed collection for the AprCondicionesVivienda class.
	/// </summary>
    [Serializable]
	public partial class AprCondicionesViviendaCollection : ActiveList<AprCondicionesVivienda, AprCondicionesViviendaCollection>
	{	   
		public AprCondicionesViviendaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AprCondicionesViviendaCollection</returns>
		public AprCondicionesViviendaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AprCondicionesVivienda o = this[i];
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
	/// This is an ActiveRecord class which wraps the APR_CondicionesVivienda table.
	/// </summary>
	[Serializable]
	public partial class AprCondicionesVivienda : ActiveRecord<AprCondicionesVivienda>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AprCondicionesVivienda()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AprCondicionesVivienda(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AprCondicionesVivienda(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AprCondicionesVivienda(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("APR_CondicionesVivienda", TableType.Table, DataService.GetInstance("sicProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCondicionesVivienda = new TableSchema.TableColumn(schema);
				colvarIdCondicionesVivienda.ColumnName = "idCondicionesVivienda";
				colvarIdCondicionesVivienda.DataType = DbType.Int32;
				colvarIdCondicionesVivienda.MaxLength = 0;
				colvarIdCondicionesVivienda.AutoIncrement = true;
				colvarIdCondicionesVivienda.IsNullable = false;
				colvarIdCondicionesVivienda.IsPrimaryKey = true;
				colvarIdCondicionesVivienda.IsForeignKey = false;
				colvarIdCondicionesVivienda.IsReadOnly = false;
				colvarIdCondicionesVivienda.DefaultSetting = @"";
				colvarIdCondicionesVivienda.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCondicionesVivienda);
				
				TableSchema.TableColumn colvarPisoTierra = new TableSchema.TableColumn(schema);
				colvarPisoTierra.ColumnName = "PisoTierra";
				colvarPisoTierra.DataType = DbType.Boolean;
				colvarPisoTierra.MaxLength = 0;
				colvarPisoTierra.AutoIncrement = false;
				colvarPisoTierra.IsNullable = true;
				colvarPisoTierra.IsPrimaryKey = false;
				colvarPisoTierra.IsForeignKey = false;
				colvarPisoTierra.IsReadOnly = false;
				colvarPisoTierra.DefaultSetting = @"";
				colvarPisoTierra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPisoTierra);
				
				TableSchema.TableColumn colvarPisoMaterial = new TableSchema.TableColumn(schema);
				colvarPisoMaterial.ColumnName = "PisoMaterial";
				colvarPisoMaterial.DataType = DbType.Boolean;
				colvarPisoMaterial.MaxLength = 0;
				colvarPisoMaterial.AutoIncrement = false;
				colvarPisoMaterial.IsNullable = true;
				colvarPisoMaterial.IsPrimaryKey = false;
				colvarPisoMaterial.IsForeignKey = false;
				colvarPisoMaterial.IsReadOnly = false;
				colvarPisoMaterial.DefaultSetting = @"";
				colvarPisoMaterial.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPisoMaterial);
				
				TableSchema.TableColumn colvarBRecoleccion = new TableSchema.TableColumn(schema);
				colvarBRecoleccion.ColumnName = "BRecoleccion";
				colvarBRecoleccion.DataType = DbType.Boolean;
				colvarBRecoleccion.MaxLength = 0;
				colvarBRecoleccion.AutoIncrement = false;
				colvarBRecoleccion.IsNullable = true;
				colvarBRecoleccion.IsPrimaryKey = false;
				colvarBRecoleccion.IsForeignKey = false;
				colvarBRecoleccion.IsReadOnly = false;
				colvarBRecoleccion.DefaultSetting = @"";
				colvarBRecoleccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBRecoleccion);
				
				TableSchema.TableColumn colvarBEntierran = new TableSchema.TableColumn(schema);
				colvarBEntierran.ColumnName = "BEntierran";
				colvarBEntierran.DataType = DbType.Boolean;
				colvarBEntierran.MaxLength = 0;
				colvarBEntierran.AutoIncrement = false;
				colvarBEntierran.IsNullable = true;
				colvarBEntierran.IsPrimaryKey = false;
				colvarBEntierran.IsForeignKey = false;
				colvarBEntierran.IsReadOnly = false;
				colvarBEntierran.DefaultSetting = @"";
				colvarBEntierran.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBEntierran);
				
				TableSchema.TableColumn colvarBQueman = new TableSchema.TableColumn(schema);
				colvarBQueman.ColumnName = "BQueman";
				colvarBQueman.DataType = DbType.Boolean;
				colvarBQueman.MaxLength = 0;
				colvarBQueman.AutoIncrement = false;
				colvarBQueman.IsNullable = true;
				colvarBQueman.IsPrimaryKey = false;
				colvarBQueman.IsForeignKey = false;
				colvarBQueman.IsReadOnly = false;
				colvarBQueman.DefaultSetting = @"";
				colvarBQueman.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBQueman);
				
				TableSchema.TableColumn colvarBOtra = new TableSchema.TableColumn(schema);
				colvarBOtra.ColumnName = "BOtra";
				colvarBOtra.DataType = DbType.Boolean;
				colvarBOtra.MaxLength = 0;
				colvarBOtra.AutoIncrement = false;
				colvarBOtra.IsNullable = true;
				colvarBOtra.IsPrimaryKey = false;
				colvarBOtra.IsForeignKey = false;
				colvarBOtra.IsReadOnly = false;
				colvarBOtra.DefaultSetting = @"";
				colvarBOtra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBOtra);
				
				TableSchema.TableColumn colvarFCGasNatural = new TableSchema.TableColumn(schema);
				colvarFCGasNatural.ColumnName = "FCGasNatural";
				colvarFCGasNatural.DataType = DbType.Boolean;
				colvarFCGasNatural.MaxLength = 0;
				colvarFCGasNatural.AutoIncrement = false;
				colvarFCGasNatural.IsNullable = true;
				colvarFCGasNatural.IsPrimaryKey = false;
				colvarFCGasNatural.IsForeignKey = false;
				colvarFCGasNatural.IsReadOnly = false;
				colvarFCGasNatural.DefaultSetting = @"";
				colvarFCGasNatural.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFCGasNatural);
				
				TableSchema.TableColumn colvarFCGarrafa = new TableSchema.TableColumn(schema);
				colvarFCGarrafa.ColumnName = "FCGarrafa";
				colvarFCGarrafa.DataType = DbType.Boolean;
				colvarFCGarrafa.MaxLength = 0;
				colvarFCGarrafa.AutoIncrement = false;
				colvarFCGarrafa.IsNullable = true;
				colvarFCGarrafa.IsPrimaryKey = false;
				colvarFCGarrafa.IsForeignKey = false;
				colvarFCGarrafa.IsReadOnly = false;
				colvarFCGarrafa.DefaultSetting = @"";
				colvarFCGarrafa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFCGarrafa);
				
				TableSchema.TableColumn colvarFCCarbon = new TableSchema.TableColumn(schema);
				colvarFCCarbon.ColumnName = "FCCarbon";
				colvarFCCarbon.DataType = DbType.Boolean;
				colvarFCCarbon.MaxLength = 0;
				colvarFCCarbon.AutoIncrement = false;
				colvarFCCarbon.IsNullable = true;
				colvarFCCarbon.IsPrimaryKey = false;
				colvarFCCarbon.IsForeignKey = false;
				colvarFCCarbon.IsReadOnly = false;
				colvarFCCarbon.DefaultSetting = @"";
				colvarFCCarbon.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFCCarbon);
				
				TableSchema.TableColumn colvarFCKerosen = new TableSchema.TableColumn(schema);
				colvarFCKerosen.ColumnName = "FCKerosen";
				colvarFCKerosen.DataType = DbType.Boolean;
				colvarFCKerosen.MaxLength = 0;
				colvarFCKerosen.AutoIncrement = false;
				colvarFCKerosen.IsNullable = true;
				colvarFCKerosen.IsPrimaryKey = false;
				colvarFCKerosen.IsForeignKey = false;
				colvarFCKerosen.IsReadOnly = false;
				colvarFCKerosen.DefaultSetting = @"";
				colvarFCKerosen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFCKerosen);
				
				TableSchema.TableColumn colvarFCElectricidad = new TableSchema.TableColumn(schema);
				colvarFCElectricidad.ColumnName = "FCElectricidad";
				colvarFCElectricidad.DataType = DbType.Boolean;
				colvarFCElectricidad.MaxLength = 0;
				colvarFCElectricidad.AutoIncrement = false;
				colvarFCElectricidad.IsNullable = true;
				colvarFCElectricidad.IsPrimaryKey = false;
				colvarFCElectricidad.IsForeignKey = false;
				colvarFCElectricidad.IsReadOnly = false;
				colvarFCElectricidad.DefaultSetting = @"";
				colvarFCElectricidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFCElectricidad);
				
				TableSchema.TableColumn colvarFCOtro = new TableSchema.TableColumn(schema);
				colvarFCOtro.ColumnName = "FCOtro";
				colvarFCOtro.DataType = DbType.Boolean;
				colvarFCOtro.MaxLength = 0;
				colvarFCOtro.AutoIncrement = false;
				colvarFCOtro.IsNullable = true;
				colvarFCOtro.IsPrimaryKey = false;
				colvarFCOtro.IsForeignKey = false;
				colvarFCOtro.IsReadOnly = false;
				colvarFCOtro.DefaultSetting = @"";
				colvarFCOtro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFCOtro);
				
				TableSchema.TableColumn colvarPCHumo = new TableSchema.TableColumn(schema);
				colvarPCHumo.ColumnName = "PCHumo";
				colvarPCHumo.DataType = DbType.Boolean;
				colvarPCHumo.MaxLength = 0;
				colvarPCHumo.AutoIncrement = false;
				colvarPCHumo.IsNullable = true;
				colvarPCHumo.IsPrimaryKey = false;
				colvarPCHumo.IsForeignKey = false;
				colvarPCHumo.IsReadOnly = false;
				colvarPCHumo.DefaultSetting = @"";
				colvarPCHumo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPCHumo);
				
				TableSchema.TableColumn colvarPCBasurales = new TableSchema.TableColumn(schema);
				colvarPCBasurales.ColumnName = "PCBasurales";
				colvarPCBasurales.DataType = DbType.Boolean;
				colvarPCBasurales.MaxLength = 0;
				colvarPCBasurales.AutoIncrement = false;
				colvarPCBasurales.IsNullable = true;
				colvarPCBasurales.IsPrimaryKey = false;
				colvarPCBasurales.IsForeignKey = false;
				colvarPCBasurales.IsReadOnly = false;
				colvarPCBasurales.DefaultSetting = @"";
				colvarPCBasurales.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPCBasurales);
				
				TableSchema.TableColumn colvarPCAgroquimicos = new TableSchema.TableColumn(schema);
				colvarPCAgroquimicos.ColumnName = "PCAgroquimicos";
				colvarPCAgroquimicos.DataType = DbType.Boolean;
				colvarPCAgroquimicos.MaxLength = 0;
				colvarPCAgroquimicos.AutoIncrement = false;
				colvarPCAgroquimicos.IsNullable = true;
				colvarPCAgroquimicos.IsPrimaryKey = false;
				colvarPCAgroquimicos.IsForeignKey = false;
				colvarPCAgroquimicos.IsReadOnly = false;
				colvarPCAgroquimicos.DefaultSetting = @"";
				colvarPCAgroquimicos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPCAgroquimicos);
				
				TableSchema.TableColumn colvarPCVectores = new TableSchema.TableColumn(schema);
				colvarPCVectores.ColumnName = "PCVectores";
				colvarPCVectores.DataType = DbType.Boolean;
				colvarPCVectores.MaxLength = 0;
				colvarPCVectores.AutoIncrement = false;
				colvarPCVectores.IsNullable = true;
				colvarPCVectores.IsPrimaryKey = false;
				colvarPCVectores.IsForeignKey = false;
				colvarPCVectores.IsReadOnly = false;
				colvarPCVectores.DefaultSetting = @"";
				colvarPCVectores.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPCVectores);
				
				TableSchema.TableColumn colvarPCTerrInundados = new TableSchema.TableColumn(schema);
				colvarPCTerrInundados.ColumnName = "PCTerrInundados";
				colvarPCTerrInundados.DataType = DbType.Boolean;
				colvarPCTerrInundados.MaxLength = 0;
				colvarPCTerrInundados.AutoIncrement = false;
				colvarPCTerrInundados.IsNullable = true;
				colvarPCTerrInundados.IsPrimaryKey = false;
				colvarPCTerrInundados.IsForeignKey = false;
				colvarPCTerrInundados.IsReadOnly = false;
				colvarPCTerrInundados.DefaultSetting = @"";
				colvarPCTerrInundados.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPCTerrInundados);
				
				TableSchema.TableColumn colvarPCPetroquimicos = new TableSchema.TableColumn(schema);
				colvarPCPetroquimicos.ColumnName = "PCPetroquimicos";
				colvarPCPetroquimicos.DataType = DbType.Boolean;
				colvarPCPetroquimicos.MaxLength = 0;
				colvarPCPetroquimicos.AutoIncrement = false;
				colvarPCPetroquimicos.IsNullable = true;
				colvarPCPetroquimicos.IsPrimaryKey = false;
				colvarPCPetroquimicos.IsForeignKey = false;
				colvarPCPetroquimicos.IsReadOnly = false;
				colvarPCPetroquimicos.DefaultSetting = @"";
				colvarPCPetroquimicos.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPCPetroquimicos);
				
				TableSchema.TableColumn colvarCRedAgua = new TableSchema.TableColumn(schema);
				colvarCRedAgua.ColumnName = "CRedAgua";
				colvarCRedAgua.DataType = DbType.Boolean;
				colvarCRedAgua.MaxLength = 0;
				colvarCRedAgua.AutoIncrement = false;
				colvarCRedAgua.IsNullable = true;
				colvarCRedAgua.IsPrimaryKey = false;
				colvarCRedAgua.IsForeignKey = false;
				colvarCRedAgua.IsReadOnly = false;
				colvarCRedAgua.DefaultSetting = @"";
				colvarCRedAgua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCRedAgua);
				
				TableSchema.TableColumn colvarCRedExcretas = new TableSchema.TableColumn(schema);
				colvarCRedExcretas.ColumnName = "CRedExcretas";
				colvarCRedExcretas.DataType = DbType.Boolean;
				colvarCRedExcretas.MaxLength = 0;
				colvarCRedExcretas.AutoIncrement = false;
				colvarCRedExcretas.IsNullable = true;
				colvarCRedExcretas.IsPrimaryKey = false;
				colvarCRedExcretas.IsForeignKey = false;
				colvarCRedExcretas.IsReadOnly = false;
				colvarCRedExcretas.DefaultSetting = @"";
				colvarCRedExcretas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCRedExcretas);
				
				TableSchema.TableColumn colvarNoCRedAgua = new TableSchema.TableColumn(schema);
				colvarNoCRedAgua.ColumnName = "NoCRedAgua";
				colvarNoCRedAgua.DataType = DbType.Boolean;
				colvarNoCRedAgua.MaxLength = 0;
				colvarNoCRedAgua.AutoIncrement = false;
				colvarNoCRedAgua.IsNullable = true;
				colvarNoCRedAgua.IsPrimaryKey = false;
				colvarNoCRedAgua.IsForeignKey = false;
				colvarNoCRedAgua.IsReadOnly = false;
				colvarNoCRedAgua.DefaultSetting = @"";
				colvarNoCRedAgua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNoCRedAgua);
				
				TableSchema.TableColumn colvarNoCRedExcretas = new TableSchema.TableColumn(schema);
				colvarNoCRedExcretas.ColumnName = "NoCRedExcretas";
				colvarNoCRedExcretas.DataType = DbType.Boolean;
				colvarNoCRedExcretas.MaxLength = 0;
				colvarNoCRedExcretas.AutoIncrement = false;
				colvarNoCRedExcretas.IsNullable = true;
				colvarNoCRedExcretas.IsPrimaryKey = false;
				colvarNoCRedExcretas.IsForeignKey = false;
				colvarNoCRedExcretas.IsReadOnly = false;
				colvarNoCRedExcretas.DefaultSetting = @"";
				colvarNoCRedExcretas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNoCRedExcretas);
				
				TableSchema.TableColumn colvarFHogarAgua = new TableSchema.TableColumn(schema);
				colvarFHogarAgua.ColumnName = "FHogarAgua";
				colvarFHogarAgua.DataType = DbType.Boolean;
				colvarFHogarAgua.MaxLength = 0;
				colvarFHogarAgua.AutoIncrement = false;
				colvarFHogarAgua.IsNullable = true;
				colvarFHogarAgua.IsPrimaryKey = false;
				colvarFHogarAgua.IsForeignKey = false;
				colvarFHogarAgua.IsReadOnly = false;
				colvarFHogarAgua.DefaultSetting = @"";
				colvarFHogarAgua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFHogarAgua);
				
				TableSchema.TableColumn colvarFHogarExcretas = new TableSchema.TableColumn(schema);
				colvarFHogarExcretas.ColumnName = "FHogarExcretas";
				colvarFHogarExcretas.DataType = DbType.Boolean;
				colvarFHogarExcretas.MaxLength = 0;
				colvarFHogarExcretas.AutoIncrement = false;
				colvarFHogarExcretas.IsNullable = true;
				colvarFHogarExcretas.IsPrimaryKey = false;
				colvarFHogarExcretas.IsForeignKey = false;
				colvarFHogarExcretas.IsReadOnly = false;
				colvarFHogarExcretas.DefaultSetting = @"";
				colvarFHogarExcretas.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFHogarExcretas);
				
				TableSchema.TableColumn colvarIdControlNiñoSano = new TableSchema.TableColumn(schema);
				colvarIdControlNiñoSano.ColumnName = "idControlNiñoSano";
				colvarIdControlNiñoSano.DataType = DbType.Int32;
				colvarIdControlNiñoSano.MaxLength = 0;
				colvarIdControlNiñoSano.AutoIncrement = false;
				colvarIdControlNiñoSano.IsNullable = true;
				colvarIdControlNiñoSano.IsPrimaryKey = false;
				colvarIdControlNiñoSano.IsForeignKey = true;
				colvarIdControlNiñoSano.IsReadOnly = false;
				colvarIdControlNiñoSano.DefaultSetting = @"";
				
					colvarIdControlNiñoSano.ForeignKeyTableName = "APR_ControlNiñoSano";
				schema.Columns.Add(colvarIdControlNiñoSano);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = false;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				colvarIdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPaciente);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["sicProvider"].AddSchema("APR_CondicionesVivienda",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCondicionesVivienda")]
		[Bindable(true)]
		public int IdCondicionesVivienda 
		{
			get { return GetColumnValue<int>(Columns.IdCondicionesVivienda); }
			set { SetColumnValue(Columns.IdCondicionesVivienda, value); }
		}
		  
		[XmlAttribute("PisoTierra")]
		[Bindable(true)]
		public bool? PisoTierra 
		{
			get { return GetColumnValue<bool?>(Columns.PisoTierra); }
			set { SetColumnValue(Columns.PisoTierra, value); }
		}
		  
		[XmlAttribute("PisoMaterial")]
		[Bindable(true)]
		public bool? PisoMaterial 
		{
			get { return GetColumnValue<bool?>(Columns.PisoMaterial); }
			set { SetColumnValue(Columns.PisoMaterial, value); }
		}
		  
		[XmlAttribute("BRecoleccion")]
		[Bindable(true)]
		public bool? BRecoleccion 
		{
			get { return GetColumnValue<bool?>(Columns.BRecoleccion); }
			set { SetColumnValue(Columns.BRecoleccion, value); }
		}
		  
		[XmlAttribute("BEntierran")]
		[Bindable(true)]
		public bool? BEntierran 
		{
			get { return GetColumnValue<bool?>(Columns.BEntierran); }
			set { SetColumnValue(Columns.BEntierran, value); }
		}
		  
		[XmlAttribute("BQueman")]
		[Bindable(true)]
		public bool? BQueman 
		{
			get { return GetColumnValue<bool?>(Columns.BQueman); }
			set { SetColumnValue(Columns.BQueman, value); }
		}
		  
		[XmlAttribute("BOtra")]
		[Bindable(true)]
		public bool? BOtra 
		{
			get { return GetColumnValue<bool?>(Columns.BOtra); }
			set { SetColumnValue(Columns.BOtra, value); }
		}
		  
		[XmlAttribute("FCGasNatural")]
		[Bindable(true)]
		public bool? FCGasNatural 
		{
			get { return GetColumnValue<bool?>(Columns.FCGasNatural); }
			set { SetColumnValue(Columns.FCGasNatural, value); }
		}
		  
		[XmlAttribute("FCGarrafa")]
		[Bindable(true)]
		public bool? FCGarrafa 
		{
			get { return GetColumnValue<bool?>(Columns.FCGarrafa); }
			set { SetColumnValue(Columns.FCGarrafa, value); }
		}
		  
		[XmlAttribute("FCCarbon")]
		[Bindable(true)]
		public bool? FCCarbon 
		{
			get { return GetColumnValue<bool?>(Columns.FCCarbon); }
			set { SetColumnValue(Columns.FCCarbon, value); }
		}
		  
		[XmlAttribute("FCKerosen")]
		[Bindable(true)]
		public bool? FCKerosen 
		{
			get { return GetColumnValue<bool?>(Columns.FCKerosen); }
			set { SetColumnValue(Columns.FCKerosen, value); }
		}
		  
		[XmlAttribute("FCElectricidad")]
		[Bindable(true)]
		public bool? FCElectricidad 
		{
			get { return GetColumnValue<bool?>(Columns.FCElectricidad); }
			set { SetColumnValue(Columns.FCElectricidad, value); }
		}
		  
		[XmlAttribute("FCOtro")]
		[Bindable(true)]
		public bool? FCOtro 
		{
			get { return GetColumnValue<bool?>(Columns.FCOtro); }
			set { SetColumnValue(Columns.FCOtro, value); }
		}
		  
		[XmlAttribute("PCHumo")]
		[Bindable(true)]
		public bool? PCHumo 
		{
			get { return GetColumnValue<bool?>(Columns.PCHumo); }
			set { SetColumnValue(Columns.PCHumo, value); }
		}
		  
		[XmlAttribute("PCBasurales")]
		[Bindable(true)]
		public bool? PCBasurales 
		{
			get { return GetColumnValue<bool?>(Columns.PCBasurales); }
			set { SetColumnValue(Columns.PCBasurales, value); }
		}
		  
		[XmlAttribute("PCAgroquimicos")]
		[Bindable(true)]
		public bool? PCAgroquimicos 
		{
			get { return GetColumnValue<bool?>(Columns.PCAgroquimicos); }
			set { SetColumnValue(Columns.PCAgroquimicos, value); }
		}
		  
		[XmlAttribute("PCVectores")]
		[Bindable(true)]
		public bool? PCVectores 
		{
			get { return GetColumnValue<bool?>(Columns.PCVectores); }
			set { SetColumnValue(Columns.PCVectores, value); }
		}
		  
		[XmlAttribute("PCTerrInundados")]
		[Bindable(true)]
		public bool? PCTerrInundados 
		{
			get { return GetColumnValue<bool?>(Columns.PCTerrInundados); }
			set { SetColumnValue(Columns.PCTerrInundados, value); }
		}
		  
		[XmlAttribute("PCPetroquimicos")]
		[Bindable(true)]
		public bool? PCPetroquimicos 
		{
			get { return GetColumnValue<bool?>(Columns.PCPetroquimicos); }
			set { SetColumnValue(Columns.PCPetroquimicos, value); }
		}
		  
		[XmlAttribute("CRedAgua")]
		[Bindable(true)]
		public bool? CRedAgua 
		{
			get { return GetColumnValue<bool?>(Columns.CRedAgua); }
			set { SetColumnValue(Columns.CRedAgua, value); }
		}
		  
		[XmlAttribute("CRedExcretas")]
		[Bindable(true)]
		public bool? CRedExcretas 
		{
			get { return GetColumnValue<bool?>(Columns.CRedExcretas); }
			set { SetColumnValue(Columns.CRedExcretas, value); }
		}
		  
		[XmlAttribute("NoCRedAgua")]
		[Bindable(true)]
		public bool? NoCRedAgua 
		{
			get { return GetColumnValue<bool?>(Columns.NoCRedAgua); }
			set { SetColumnValue(Columns.NoCRedAgua, value); }
		}
		  
		[XmlAttribute("NoCRedExcretas")]
		[Bindable(true)]
		public bool? NoCRedExcretas 
		{
			get { return GetColumnValue<bool?>(Columns.NoCRedExcretas); }
			set { SetColumnValue(Columns.NoCRedExcretas, value); }
		}
		  
		[XmlAttribute("FHogarAgua")]
		[Bindable(true)]
		public bool? FHogarAgua 
		{
			get { return GetColumnValue<bool?>(Columns.FHogarAgua); }
			set { SetColumnValue(Columns.FHogarAgua, value); }
		}
		  
		[XmlAttribute("FHogarExcretas")]
		[Bindable(true)]
		public bool? FHogarExcretas 
		{
			get { return GetColumnValue<bool?>(Columns.FHogarExcretas); }
			set { SetColumnValue(Columns.FHogarExcretas, value); }
		}
		  
		[XmlAttribute("IdControlNiñoSano")]
		[Bindable(true)]
		public int? IdControlNiñoSano 
		{
			get { return GetColumnValue<int?>(Columns.IdControlNiñoSano); }
			set { SetColumnValue(Columns.IdControlNiñoSano, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AprControlNiñoSano ActiveRecord object related to this AprCondicionesVivienda
		/// 
		/// </summary>
		public DalSic.AprControlNiñoSano AprControlNiñoSano
		{
			get { return DalSic.AprControlNiñoSano.FetchByID(this.IdControlNiñoSano); }
			set { SetColumnValue("idControlNiñoSano", value.IdControlNiñoSano); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(bool? varPisoTierra,bool? varPisoMaterial,bool? varBRecoleccion,bool? varBEntierran,bool? varBQueman,bool? varBOtra,bool? varFCGasNatural,bool? varFCGarrafa,bool? varFCCarbon,bool? varFCKerosen,bool? varFCElectricidad,bool? varFCOtro,bool? varPCHumo,bool? varPCBasurales,bool? varPCAgroquimicos,bool? varPCVectores,bool? varPCTerrInundados,bool? varPCPetroquimicos,bool? varCRedAgua,bool? varCRedExcretas,bool? varNoCRedAgua,bool? varNoCRedExcretas,bool? varFHogarAgua,bool? varFHogarExcretas,int? varIdControlNiñoSano,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdPaciente)
		{
			AprCondicionesVivienda item = new AprCondicionesVivienda();
			
			item.PisoTierra = varPisoTierra;
			
			item.PisoMaterial = varPisoMaterial;
			
			item.BRecoleccion = varBRecoleccion;
			
			item.BEntierran = varBEntierran;
			
			item.BQueman = varBQueman;
			
			item.BOtra = varBOtra;
			
			item.FCGasNatural = varFCGasNatural;
			
			item.FCGarrafa = varFCGarrafa;
			
			item.FCCarbon = varFCCarbon;
			
			item.FCKerosen = varFCKerosen;
			
			item.FCElectricidad = varFCElectricidad;
			
			item.FCOtro = varFCOtro;
			
			item.PCHumo = varPCHumo;
			
			item.PCBasurales = varPCBasurales;
			
			item.PCAgroquimicos = varPCAgroquimicos;
			
			item.PCVectores = varPCVectores;
			
			item.PCTerrInundados = varPCTerrInundados;
			
			item.PCPetroquimicos = varPCPetroquimicos;
			
			item.CRedAgua = varCRedAgua;
			
			item.CRedExcretas = varCRedExcretas;
			
			item.NoCRedAgua = varNoCRedAgua;
			
			item.NoCRedExcretas = varNoCRedExcretas;
			
			item.FHogarAgua = varFHogarAgua;
			
			item.FHogarExcretas = varFHogarExcretas;
			
			item.IdControlNiñoSano = varIdControlNiñoSano;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IdPaciente = varIdPaciente;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCondicionesVivienda,bool? varPisoTierra,bool? varPisoMaterial,bool? varBRecoleccion,bool? varBEntierran,bool? varBQueman,bool? varBOtra,bool? varFCGasNatural,bool? varFCGarrafa,bool? varFCCarbon,bool? varFCKerosen,bool? varFCElectricidad,bool? varFCOtro,bool? varPCHumo,bool? varPCBasurales,bool? varPCAgroquimicos,bool? varPCVectores,bool? varPCTerrInundados,bool? varPCPetroquimicos,bool? varCRedAgua,bool? varCRedExcretas,bool? varNoCRedAgua,bool? varNoCRedExcretas,bool? varFHogarAgua,bool? varFHogarExcretas,int? varIdControlNiñoSano,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiedOn,int? varIdPaciente)
		{
			AprCondicionesVivienda item = new AprCondicionesVivienda();
			
				item.IdCondicionesVivienda = varIdCondicionesVivienda;
			
				item.PisoTierra = varPisoTierra;
			
				item.PisoMaterial = varPisoMaterial;
			
				item.BRecoleccion = varBRecoleccion;
			
				item.BEntierran = varBEntierran;
			
				item.BQueman = varBQueman;
			
				item.BOtra = varBOtra;
			
				item.FCGasNatural = varFCGasNatural;
			
				item.FCGarrafa = varFCGarrafa;
			
				item.FCCarbon = varFCCarbon;
			
				item.FCKerosen = varFCKerosen;
			
				item.FCElectricidad = varFCElectricidad;
			
				item.FCOtro = varFCOtro;
			
				item.PCHumo = varPCHumo;
			
				item.PCBasurales = varPCBasurales;
			
				item.PCAgroquimicos = varPCAgroquimicos;
			
				item.PCVectores = varPCVectores;
			
				item.PCTerrInundados = varPCTerrInundados;
			
				item.PCPetroquimicos = varPCPetroquimicos;
			
				item.CRedAgua = varCRedAgua;
			
				item.CRedExcretas = varCRedExcretas;
			
				item.NoCRedAgua = varNoCRedAgua;
			
				item.NoCRedExcretas = varNoCRedExcretas;
			
				item.FHogarAgua = varFHogarAgua;
			
				item.FHogarExcretas = varFHogarExcretas;
			
				item.IdControlNiñoSano = varIdControlNiñoSano;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
				item.IdPaciente = varIdPaciente;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCondicionesViviendaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PisoTierraColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PisoMaterialColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BRecoleccionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn BEntierranColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn BQuemanColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn BOtraColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FCGasNaturalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FCGarrafaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn FCCarbonColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FCKerosenColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FCElectricidadColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FCOtroColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PCHumoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PCBasuralesColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn PCAgroquimicosColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn PCVectoresColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn PCTerrInundadosColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn PCPetroquimicosColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CRedAguaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CRedExcretasColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn NoCRedAguaColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn NoCRedExcretasColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn FHogarAguaColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn FHogarExcretasColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn IdControlNiñoSanoColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCondicionesVivienda = @"idCondicionesVivienda";
			 public static string PisoTierra = @"PisoTierra";
			 public static string PisoMaterial = @"PisoMaterial";
			 public static string BRecoleccion = @"BRecoleccion";
			 public static string BEntierran = @"BEntierran";
			 public static string BQueman = @"BQueman";
			 public static string BOtra = @"BOtra";
			 public static string FCGasNatural = @"FCGasNatural";
			 public static string FCGarrafa = @"FCGarrafa";
			 public static string FCCarbon = @"FCCarbon";
			 public static string FCKerosen = @"FCKerosen";
			 public static string FCElectricidad = @"FCElectricidad";
			 public static string FCOtro = @"FCOtro";
			 public static string PCHumo = @"PCHumo";
			 public static string PCBasurales = @"PCBasurales";
			 public static string PCAgroquimicos = @"PCAgroquimicos";
			 public static string PCVectores = @"PCVectores";
			 public static string PCTerrInundados = @"PCTerrInundados";
			 public static string PCPetroquimicos = @"PCPetroquimicos";
			 public static string CRedAgua = @"CRedAgua";
			 public static string CRedExcretas = @"CRedExcretas";
			 public static string NoCRedAgua = @"NoCRedAgua";
			 public static string NoCRedExcretas = @"NoCRedExcretas";
			 public static string FHogarAgua = @"FHogarAgua";
			 public static string FHogarExcretas = @"FHogarExcretas";
			 public static string IdControlNiñoSano = @"idControlNiñoSano";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IdPaciente = @"idPaciente";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
