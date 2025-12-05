using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

[Table("SubmissionStatusHistory")]
public partial class SubmissionStatusHistory
{
    [Key]
    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("submission_id")]
    public int SubmissionId { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("result")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Result { get; set; }

    [Column("comments", TypeName = "text")]
    public string? Comments { get; set; }

    [Column("updated_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [ForeignKey("SubmissionId")]
    [InverseProperty("SubmissionStatusHistories")]
    public virtual CandidateSubmission Submission { get; set; } = null!;
}
