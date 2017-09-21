using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DalSic
{
    public partial class SysUsuario
    {
        //Propiedad que utilizaremos para saber si el usuario tiene o no habilitado
        //el acceso a una determinada pagina
        public bool IsPageEnabled(string pageName)
        {
            if (!pageName.StartsWith("~"))
                pageName = "~" + pageName;
            //bool result = false;
            System.Data.DataSet ds = SPs.UsrIsPerfilPageEnabled(pageName, this.SysPerfil.Nombre).GetDataSet();
            System.Data.DataView dv = new System.Data.DataView(ds.Tables[0]);
            //if (dv.Count > 0)
            //    result = true;
            return (dv.Count > 0);
        }

        public bool IsActionEnabled(string actionName)
        {
            System.Data.DataSet ds = SPs.UsrIsPerfilActionEnabled(actionName, this.SysPerfil.Nombre).GetDataSet();
            System.Data.DataView dv = new System.Data.DataView(ds.Tables[0]);
            return (dv.Count > 0);
        }

    }
}
