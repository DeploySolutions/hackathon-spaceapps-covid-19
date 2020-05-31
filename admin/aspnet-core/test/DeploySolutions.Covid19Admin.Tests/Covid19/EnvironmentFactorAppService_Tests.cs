using DeploySolutions.Covid19Admin.Covid19;
using DeploySolutions.Covid19Admin.Covid19.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DeploySolutions.Covid19Admin.Tests.Covid19
{
    public class EnvironmentFactorAppService_Tests : Covid19AdminTestBase
    {
        private readonly IEnvironmentFactorAppService _environmentFactorAppService;

        public EnvironmentFactorAppService_Tests()
        {
            _environmentFactorAppService = Resolve<IEnvironmentFactorAppService>();
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_All_Environment_Factors()
        {
            //Act
            var output = await _environmentFactorAppService.GetAll(new GetAllEnvironmentFactorsInput());

            //Assert
            output.Items.Count.ShouldBe(0);
        }
    }
}
