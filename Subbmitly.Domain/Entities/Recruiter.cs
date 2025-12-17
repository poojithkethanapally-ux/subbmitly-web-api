using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

public partial class Recruiter
{
    [Key]
    [Column("recruiter_id")]
    public int RecruiterId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("phone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("vendor_company")]
    [StringLength(200)]
    [Unicode(false)]
    public string? VendorCompany { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_by")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [InverseProperty("Recruiter")]
    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    [ForeignKey("UserId")]
    [InverseProperty("Recruiters")]
    public virtual User User { get; set; } = null!;
}
