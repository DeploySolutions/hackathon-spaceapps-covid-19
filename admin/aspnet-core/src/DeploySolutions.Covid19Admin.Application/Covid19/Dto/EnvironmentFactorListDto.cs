using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeploySolutions.Covid19Admin.Covid19.Dto
{
    [AutoMapFrom(typeof(CovidCase))]
    public class EnvironmentFactorListDto : EntityDto, IHasCreationTime
    {
        public string Placename { get; set; }

        public string Indicator { get; set; }

        public string ValueRaw { get; set; }

        public string ValueDiscrete { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        public string LocationType { get; set; }

        public DateTime MeasurementRecordedDate { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
