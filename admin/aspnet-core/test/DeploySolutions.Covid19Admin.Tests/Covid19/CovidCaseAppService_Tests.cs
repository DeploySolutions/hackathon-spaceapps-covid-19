using DeploySolutions.Covid19Admin.Covid19;
using DeploySolutions.Covid19Admin.Covid19.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DeploySolutions.Covid19Admin.Tests.Covid19
{
    public class CovidCaseAppService_Tests : Covid19AdminTestBase
    {
        private readonly ICovidCaseAppService _covidCaseAppService;

        public CovidCaseAppService_Tests()
        {
            _covidCaseAppService = Resolve<ICovidCaseAppService>();
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_All_Covid_Cases()
        {
            //Act
            var output = await _covidCaseAppService.GetAll(new GetAllCovidCasesInput());

            //Assert
            output.Items.Count.ShouldBe(0);
        }
    }
}
