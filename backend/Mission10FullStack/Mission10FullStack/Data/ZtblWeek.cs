using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[Table("ztblWeeks")]
public partial class ZtblWeek
{
    [Key]
    [Column(TypeName = "date")]
    public DateOnly WeekStart { get; set; }

    [Column(TypeName = "date")]
    public DateOnly? WeekEnd { get; set; }
}
