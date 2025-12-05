using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

[Index("Email", Name = "UQ__Users__AB6E616422E8A1FC", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("full_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string FullName { get; set; } = null!;

    [Column("email")]
    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(500)]
    [Unicode(false)]
    public string? PasswordHash { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [InverseProperty("Recruiter")]
    public virtual ICollection<CandidateSubmission> CandidateSubmissions { get; set; } = new List<CandidateSubmission>();

    [InverseProperty("User")]
    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    [InverseProperty("User")]
    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
