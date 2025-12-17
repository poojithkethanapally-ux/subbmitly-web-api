using System;

namespace Subbmitly.Application.DTOs
{
    public class SubmissionResponse
    {
        public int SubmissionId { get; set; }
        public int CandidateId { get; set; }
        public string? CandidateName { get; set; }
        public int RecruiterId { get; set; }
        public string? RecruiterName { get; set; }
        public string ClientName { get; set; } = null!;
        public string? VendorName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? RequiredSkills { get; set; }
        public decimal? Rate { get; set; }
        public string? Location { get; set; }
        public string? EmploymentType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string? CurrentStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}