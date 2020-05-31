using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeploySolutions.Covid19Admin.Covid19.Dto
{
    [AutoMapFrom(typeof(CovidCase))]
    public class CovidCaseListDto : EntityDto, IHasCreationTime
    {
        public string Placename { get; set; }

        public string CaseOutcome { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        public decimal PatientAge { get; set; }

        public string PatientGender { get; set; }

        public string LocationType { get; set; }

        public DateTime CaseRecordedDate { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
