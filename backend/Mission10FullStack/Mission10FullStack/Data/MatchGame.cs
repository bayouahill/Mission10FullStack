using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[PrimaryKey("MatchId", "GameNumber")]
[Table("Match_Games")]
[Index("WinningTeamId", Name = "Team1ID")]
[Index("MatchId", Name = "TourneyMatchesMatchGames")]
public partial class MatchGame
{
    [Key]
    [Column("MatchID", TypeName = "INT")]
    public int MatchId { get; set; }

    [Key]
    [Column(TypeName = "smallint")]
    public short GameNumber { get; set; }

    [Column("WinningTeamID", TypeName = "INT")]
    public int? WinningTeamId { get; set; }

    [ForeignKey("MatchId")]
    [InverseProperty("MatchGames")]
    public virtual TourneyMatch Match { get; set; } = null!;
}
