using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DeploySolutions.Covid19Admin.Covid19.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeploySolutions.Covid19Admin.Covid19
{
    public class EnvironmentFactorAppService : Covid19AdminAppServiceBase, IEnvironmentFactorAppService
    {
        private readonly IRepository<EnvironmentFactor> _environmentFactorRepository;

        public EnvironmentFactorAppService(IRepository<EnvironmentFactor> environmentFactorRepository)
        {
            _environmentFactorRepository = environmentFactorRepository;
        }

        public async Task<ListResultDto<EnvironmentFactorListDto>> GetAll(GetAllEnvironmentFactorsInput input)
        {
            var cases = await _environmentFactorRepository.GetAllListAsync();

            return new ListResultDto<EnvironmentFactorListDto>(
                ObjectMapper.Map<List<EnvironmentFactorListDto>>(cases)
            );
        }
    }
}
