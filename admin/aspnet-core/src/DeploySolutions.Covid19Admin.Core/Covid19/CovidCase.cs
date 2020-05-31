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
    public class CovidCase : Entity,IHasCreationTime
    {
        public const int MaxTextLength = 256;


        [Required]
        [StringLength(MaxTextLength)]
        public string Placename { get; set; }

        [Required]
        [StringLength(MaxTextLength)]
        public string CaseOutcome { get; set; }

        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Long { get; set; }

        [StringLength(MaxTextLength)]
        public string PatientAge { get; set; }

        public string PatientGender { get; set; }

        [StringLength(MaxTextLength)]
        public string LocationType { get; set; }

        public DateTime CaseRecordedDate { get; set; }

        public DateTime CreationTime { get; set; }


        public CovidCase()
        {
            CreationTime = Clock.Now;
        }

        public CovidCase(string placename, string caseOutcome, decimal latitude, decimal longitude)
            : this()
        {
            Placename = placename;
            CaseOutcome = caseOutcome;
            Lat = latitude;
            Long = longitude;
        }
    }
}
