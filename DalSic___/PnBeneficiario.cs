using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DalSic {
    public partial class PnBeneficiario {
        public int EdadActual {
            get {
                int edad = DateTime.Now.Year - this.FechaNacimientoBenef.Year;
                //Obtengo la fecha de cumpleaños de este año.
                DateTime nacimientoEsteAnio = this.FechaNacimientoBenef.AddYears(edad);
                //Le resto un año si la fecha actual es anterior al día de nacimiento.
                if (DateTime.Now.CompareTo(nacimientoEsteAnio) < 0) {
                    edad--;
                }
                return edad;
            }
        }
    }
}
