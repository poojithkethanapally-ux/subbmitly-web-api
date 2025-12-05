using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Subbmitly.Domain.Entities;

[Table("AuditLog")]
public partial class AuditLog
{
    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("user_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string? UserName { get; set; }

    [Column("action")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Action { get; set; }

    [Column("entity_name")]
    [StringLength(200)]
    [Unicode(false)]
    public string? EntityName { get; set; }

    [Column("entity_id")]
    public int? EntityId { get; set; }

    [Column("details", TypeName = "text")]
    public string? Details { get; set; }

    [Column("timestamp", TypeName = "datetime")]
    public DateTime Timestamp { get; set; }
}
