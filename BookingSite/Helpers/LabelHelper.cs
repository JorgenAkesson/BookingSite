using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Helpers
{
    public class LabelHelper
    {
        public static string Label(string text)
        {
            return String.Format("<Label>-{0}-</label> <br>", text);
        }
    }
}