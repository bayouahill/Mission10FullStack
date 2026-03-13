using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[Index("TeamId", Name = "TeamID", IsUnique = true)]
public partial class Team
{
    [Key]
    [Column("TeamID", TypeName = "INT")]
    public int TeamId { get; set; }

    [Column(TypeName = "nvarchar (50)")]
    public string TeamName { get; set; } = null!;

    [Column("CaptainID", TypeName = "INT")]
    public int? CaptainId { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();

    [InverseProperty("EvenLaneTeam")]
    public virtual ICollection<TourneyMatch> TourneyMatchEvenLaneTeams { get; set; } = new List<TourneyMatch>();

    [InverseProperty("OddLaneTeam")]
    public virtual ICollection<TourneyMatch> TourneyMatchOddLaneTeams { get; set; } = new List<TourneyMatch>();
}
