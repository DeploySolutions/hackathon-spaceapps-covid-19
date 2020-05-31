using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DeploySolutions.Covid19Admin.Controllers;

namespace DeploySolutions.Covid19Admin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : Covid19AdminControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
