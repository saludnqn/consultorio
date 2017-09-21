using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DalSic
{
    public partial class ConConsultaDiagnostico
    {
        public override bool Equals(object obj)
        {
            ConConsultaDiagnostico oObject = obj as ConConsultaDiagnostico;
            return this.IdConsulta == oObject.IdConsulta && this.CODCIE10 == oObject.CODCIE10
                && this.Principal == oObject.Principal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
