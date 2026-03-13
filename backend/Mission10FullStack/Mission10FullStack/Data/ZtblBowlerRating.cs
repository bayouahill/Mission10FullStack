using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[Table("ztblBowlerRatings")]
public partial class ZtblBowlerRating
{
    [Key]
    [Column(TypeName = "nvarchar (15)")]
    public string BowlerRating { get; set; } = null!;

    [Column(TypeName = "smallint")]
    public short? BowlerLowAvg { get; set; }

    [Column(TypeName = "smallint")]
    public short? BowlerHighAvg { get; set; }
}
