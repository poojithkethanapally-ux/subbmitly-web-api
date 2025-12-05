using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

public partial class Note
{
    [Key]
    [Column("note_id")]
    public int NoteId { get; set; }

    [Column("candidate_id")]
    public int CandidateId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("note_text", TypeName = "text")]
    public string NoteText { get; set; } = null!;

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [ForeignKey("CandidateId")]
    [InverseProperty("Notes")]
    public virtual Candidate Candidate { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Notes")]
    public virtual User User { get; set; } = null!;
}
