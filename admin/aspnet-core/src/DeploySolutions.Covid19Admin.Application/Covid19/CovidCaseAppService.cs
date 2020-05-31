using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DeploySolutions.Covid19Admin.Covid19.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeploySolutions.Covid19Admin.Covid19
{
    public class CovidCaseAppService : Covid19AdminAppServiceBase, ICovidCaseAppService
    {
        private readonly IRepository<CovidCase> _covidCaseRepository;

        public CovidCaseAppService(IRepository<CovidCase> covidCaseRepository)
        {
            _covidCaseRepository = covidCaseRepository;
        }

        public async Task<ListResultDto<CovidCaseListDto>> GetAll(GetAllCovidCasesInput input)
        {
            var cases = await _covidCaseRepository.GetAllListAsync();

            return new ListResultDto<CovidCaseListDto>(
                ObjectMapper.Map<List<CovidCaseListDto>>(cases)
            );
        }
    }
}
