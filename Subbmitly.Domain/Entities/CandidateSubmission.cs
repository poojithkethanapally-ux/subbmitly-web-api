using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

[Table("CandidateSubmission")]
public partial class CandidateSubmission
{
    [Key]
    [Column("submission_id")]
    public int SubmissionId { get; set; }

    [Column("candidate_id")]
    public int CandidateId { get; set; }

    [Column("recruiter_id")]
    public int RecruiterId { get; set; }

    [Column("client_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string ClientName { get; set; } = null!;

    [Column("vendor_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string? VendorName { get; set; }

    [Column("job_title")]
    [StringLength(200)]
    [Unicode(false)]
    public string? JobTitle { get; set; }

    [Column("job_description", TypeName = "text")]
    public string? JobDescription { get; set; }

    [Column("required_skills")]
    [StringLength(500)]
    [Unicode(false)]
    public string? RequiredSkills { get; set; }

    [Column("rate", TypeName = "decimal(10, 2)")]
    public decimal? Rate { get; set; }

    [Column("location")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column("employment_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmploymentType { get; set; }

    [Column("submission_date", TypeName = "datetime")]
    public DateTime SubmissionDate { get; set; }

    [Column("current_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrentStatus { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [ForeignKey("CandidateId")]
    [InverseProperty("CandidateSubmissions")]
    public virtual Candidate Candidate { get; set; } = null!;

    [InverseProperty("Submission")]
    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    [ForeignKey("RecruiterId")]
    [InverseProperty("CandidateSubmissions")]
    public virtual User Recruiter { get; set; } = null!;

    [InverseProperty("Submission")]
    public virtual ICollection<SubmissionStatusHistory> SubmissionStatusHistories { get; set; } = new List<SubmissionStatusHistory>();
}
