using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[Table("Tourney_Matches")]
[Index("OddLaneTeamId", Name = "TourneyMatchesOdd")]
[Index("TourneyId", Name = "TourneyMatchesTourneyID")]
[Index("EvenLaneTeamId", Name = "Tourney_MatchesEven")]
public partial class TourneyMatch
{
    [Key]
    [Column("MatchID", TypeName = "INT")]
    public int MatchId { get; set; }

    [Column("TourneyID", TypeName = "INT")]
    public int? TourneyId { get; set; }

    [Column(TypeName = "nvarchar (5)")]
    public string? Lanes { get; set; }

    [Column("OddLaneTeamID", TypeName = "INT")]
    public int? OddLaneTeamId { get; set; }

    [Column("EvenLaneTeamID", TypeName = "INT")]
    public int? EvenLaneTeamId { get; set; }

    [ForeignKey("EvenLaneTeamId")]
    [InverseProperty("TourneyMatchEvenLaneTeams")]
    public virtual Team? EvenLaneTeam { get; set; }

    [InverseProperty("Match")]
    public virtual ICollection<MatchGame> MatchGames { get; set; } = new List<MatchGame>();

    [ForeignKey("OddLaneTeamId")]
    [InverseProperty("TourneyMatchOddLaneTeams")]
    public virtual Team? OddLaneTeam { get; set; }

    [ForeignKey("TourneyId")]
    [InverseProperty("TourneyMatches")]
    public virtual Tournament? Tourney { get; set; }
}
