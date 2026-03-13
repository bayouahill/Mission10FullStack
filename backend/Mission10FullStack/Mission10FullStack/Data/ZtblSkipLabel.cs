using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[Table("ztblSkipLabels")]
public partial class ZtblSkipLabel
{
    [Key]
    [Column(TypeName = "INT")]
    public int LabelCount { get; set; }
}
