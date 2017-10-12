using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software.BO
{
    public class ContextHelper
    {
        public static Habib_ChemicalsEntities GetContext()
        {
            if (HttpContext.Current.Items["context"] == null)
                HttpContext.Current.Items.Add("context", new Habib_ChemicalsEntities());
            return (Habib_ChemicalsEntities)HttpContext.Current.Items["context"];
        }
    }
}