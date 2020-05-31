using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DeploySolutions.Covid19Admin.Covid19.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeploySolutions.Covid19Admin.Covid19
{
    public interface ICovidCaseAppService : IApplicationService
    {
        Task<ListResultDto<CovidCaseListDto>> GetAll(GetAllCovidCasesInput input);
    }
}
