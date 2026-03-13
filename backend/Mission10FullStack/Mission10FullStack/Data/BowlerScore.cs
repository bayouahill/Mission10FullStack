using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

[PrimaryKey("MatchId", "GameNumber", "BowlerId")]
[Table("Bowler_Scores")]
[Index("BowlerId", Name = "BowlerID")]
[Index("MatchId", "GameNumber", Name = "MatchGamesBowlerScores")]
public partial class BowlerScore
{
    [Key]
    [Column("MatchID", TypeName = "INT")]
    public int MatchId { get; set; }

    [Key]
    [Column(TypeName = "smallint")]
    public short GameNumber { get; set; }

    [Key]
    [Column("BowlerID", TypeName = "INT")]
    public int BowlerId { get; set; }

    [Column(TypeName = "smallint")]
    public short? RawScore { get; set; }

    [Column(TypeName = "smallint")]
    public short? HandiCapScore { get; set; }

    [Column(TypeName = "bit")]
    public bool WonGame { get; set; }

    [ForeignKey("BowlerId")]
    [InverseProperty("BowlerScores")]
    public virtual Bowler Bowler { get; set; } = null!;
}
