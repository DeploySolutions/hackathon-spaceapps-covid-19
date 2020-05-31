using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DeploySolutions.Covid19Admin.Controllers;
using DeploySolutions.Covid19Admin.Covid19;
using System.Threading.Tasks;
using DeploySolutions.Covid19Admin.Covid19.Dto;
using DeploySolutions.Covid19Admin.Web.Models.Covid19;

namespace DeploySolutions.Covid19Admin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CovidCasesController : Covid19AdminControllerBase
    {
        private readonly ICovidCaseAppService _taskAppService;

        public CovidCasesController(ICovidCaseAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public async Task<ActionResult> Index(GetAllCovidCasesInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new CovidCaseViewModel(output.Items);
            return View(model);
        }
    }
}
