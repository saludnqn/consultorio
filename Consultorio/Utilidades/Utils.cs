using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Consultorio.Utilidades
{
    public static class Utils
    {
        public static ListItem getEmptyListItem()
        {
            return new ListItem("[SELECCIONE]", "");
        }
    }
}
