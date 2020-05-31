using DeploySolutions.Covid19Admin.Covid19.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeploySolutions.Covid19Admin.Web.Models.Covid19
{
    public class CovidCaseViewModel
    {
        public IReadOnlyList<CovidCaseListDto> CovidCases { get; }

        public CovidCaseViewModel(IReadOnlyList<CovidCaseListDto> cases)
        {
            CovidCases = cases;
        }

        public string GetTaskLabel(CovidCaseListDto covidCase)
        {
            return "label-default";
        }
    }
}
