using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

public partial class Candidate
{
    [Key]
    [Column("candidate_id")]
    public int CandidateId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("phone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("location")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column("visa_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VisaStatus { get; set; }

    [Column("total_experience_yrs", TypeName = "decimal(4, 1)")]
    public decimal? TotalExperienceYrs { get; set; }

    [Column("primary_skills")]
    [StringLength(500)]
    [Unicode(false)]
    public string? PrimarySkills { get; set; }

    [Column("secondary_skills")]
    [StringLength(500)]
    [Unicode(false)]
    public string? SecondarySkills { get; set; }

    [Column("resume_path")]
    [StringLength(500)]
    [Unicode(false)]
    public string? ResumePath { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [InverseProperty("Candidate")]
    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    [InverseProperty("Candidate")]
    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    [ForeignKey("UserId")]
    [InverseProperty("Candidates")]
    public virtual User User { get; set; } = null!;
}
