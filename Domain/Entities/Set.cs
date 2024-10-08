﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[PrimaryKey("Key", "Value")]
[Table("Set", Schema = "HangFire")]
[Index("Key", "Score", Name = "IX_HangFire_Set_Score")]
public partial class Set
{
    [Key]
    [StringLength(100)]
    public string Key { get; set; } = null!;

    public double Score { get; set; }

    [Key]
    [StringLength(256)]
    public string Value { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? ExpireAt { get; set; }
}
