using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

[Table("Interview")]
public partial class Interview
{
    [Key]
    [Column("interview_id")]
    public int InterviewId { get; set; }

    [Column("submission_id")]
    public int SubmissionId { get; set; }

    [Column("interview_round")]
    public int? InterviewRound { get; set; }

    [Column("interview_date", TypeName = "datetime")]
    public DateTime InterviewDate { get; set; }

    [Column("interviewer_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string? InterviewerName { get; set; }

    [Column("mode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Mode { get; set; }

    [Column("feedback", TypeName = "text")]
    public string? Feedback { get; set; }

    [Column("result")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Result { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [ForeignKey("SubmissionId")]
    [InverseProperty("Interviews")]
    public virtual Submission Submission { get; set; } = null!;
}
