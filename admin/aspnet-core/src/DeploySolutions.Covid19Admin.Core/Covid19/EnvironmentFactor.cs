using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeploySolutions.Covid19Admin.Covid19
{
    public class EnvironmentFactor : Entity,IHasCreationTime
    {
        public const int MaxTextLength = 256;


        [Required]
        [StringLength(MaxTextLength)]
        public string Placename { get; set; }

        [Required]
        [StringLength(MaxTextLength)]
        public string Indicator { get; set; }

        [Required]
        [StringLength(MaxTextLength)]
        public string ValueRaw { get; set; }

        [Required]
        [StringLength(MaxTextLength)]
        public string ValueDiscrete { get; set; }

        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Long { get; set; }


        [StringLength(MaxTextLength)]
        public string LocationType { get; set; }

        public DateTime MeasurementRecordedDate { get; set; }

        public DateTime CreationTime { get; set; }


        public EnvironmentFactor()
        {
            CreationTime = Clock.Now;
        }

        public EnvironmentFactor(string placename, string indicator, decimal latitude, decimal longitude)
            : this()
        {
            Placename = placename;
            Indicator = indicator;
            Lat = latitude;
            Long = longitude;
        }
    }
}
