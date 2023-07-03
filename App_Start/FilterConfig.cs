using System.Web;
using System.Web.Mvc;

namespace Swachh_Bharat_Abhiyan_Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}