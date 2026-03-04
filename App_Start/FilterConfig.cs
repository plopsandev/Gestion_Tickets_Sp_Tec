using System.Web;
using System.Web.Mvc;

namespace Gestion_Tickets_Sp_Tec
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
