using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subbmitly.Application.DTOs
{
    public class CreateSubmissionRequest
    {
        public int CandidateId { get; set; }
        public int RecruiterId { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime? SubmissionDate { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string? VendorName { get; set; }
        public string? VendorContactName { get; set; }
        public string? VendorContactEmail { get; set; }
        public string? VendorContactPhone { get; set; }

        public string? ImplementationPartner { get; set; }

        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? RequiredSkills { get; set; }

        public decimal? Rate { get; set; }

        public string? Location { get; set; }
        public string? CandidateLocation { get; set; }

        public string? EmploymentType { get; set; }
    }
}
