using System.Web;
using System.Web.Mvc;

namespace ThietBiNhaBep_23TH0004
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
