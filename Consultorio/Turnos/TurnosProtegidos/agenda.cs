using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnosProtegidos
{
    public class agenda
    {
        public int cp { get; set; }
        public string profesional { get; set; }
        public string fecha { get; set; }
        public string consultorio { get; set; }
        public string rango { get; set; }
        public string hi { get; set; }
        public string hf { get; set; }
        public int idagenda { get; set; }
        public int idespecialidad { get; set; }
        public string especialidad { get; set; }
    }
}


// Ejemplo

//{
//"cp":1002001,
//"profesional":"CHAMAS DANIEL",
//"fecha":"4 sep 2013 0:00",
//"consultorio":"9 ",
//"rango":"M",
//"hi":"08:00:00",
//"hf":"10:00:00",
//"idagenda":186703,
//"idespecialidad":18,
//"especialidad":"CARDIOLOGIA"
//}