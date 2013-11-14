using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication4.RESTApi.Models
{
    interface IActivityManager
    {
        List<Activity> GetActivties(int? page, int? count);
    }
}
