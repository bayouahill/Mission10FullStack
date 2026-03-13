using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

public partial class Tournament
{
    [Key]
    [Column("TourneyID", TypeName = "INT")]
    public int TourneyId { get; set; }

    [Column(TypeName = "date")]
    public DateOnly? TourneyDate { get; set; }

    [Column(TypeName = "nvarchar (50)")]
    public string? TourneyLocation { get; set; }

    [InverseProperty("Tourney")]
    public virtual ICollection<TourneyMatch> TourneyMatches { get; set; } = new List<TourneyMatch>();
}
