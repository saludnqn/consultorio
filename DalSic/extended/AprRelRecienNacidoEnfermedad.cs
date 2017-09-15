using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DalSic
{
    public partial class AprRelRecienNacidoEnfermedad
    {
        public override bool Equals(object obj)
        {
            AprRelRecienNacidoEnfermedad oObject = obj as AprRelRecienNacidoEnfermedad;
            return this.IdRecienNacido == oObject.IdRecienNacido && this.CODCIE10 == oObject.CODCIE10;
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
