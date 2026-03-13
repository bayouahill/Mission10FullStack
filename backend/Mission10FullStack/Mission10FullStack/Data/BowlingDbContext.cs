using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission10FullStack.Data;

public partial class BowlingDbContext : DbContext
{
    public BowlingDbContext()
    {
    }

    public BowlingDbContext(DbContextOptions<BowlingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bowler> Bowlers { get; set; }

    public virtual DbSet<BowlerScore> BowlerScores { get; set; }

    public virtual DbSet<MatchGame> MatchGames { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<TourneyMatch> TourneyMatches { get; set; }

    public virtual DbSet<ZtblBowlerRating> ZtblBowlerRatings { get; set; }

    public virtual DbSet<ZtblSkipLabel> ZtblSkipLabels { get; set; }

    public virtual DbSet<ZtblWeek> ZtblWeeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=BowlingLeague.sqlite");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BowlerScore>(entity =>
        {
            entity.Property(e => e.HandiCapScore).HasDefaultValue((short)0);
            entity.Property(e => e.RawScore).HasDefaultValue((short)0);

            entity.HasOne(d => d.Bowler).WithMany(p => p.BowlerScores).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MatchGame>(entity =>
        {
            entity.Property(e => e.WinningTeamId).HasDefaultValue(0);

            entity.HasOne(d => d.Match).WithMany(p => p.MatchGames).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TourneyMatch>(entity =>
        {
            entity.Property(e => e.EvenLaneTeamId).HasDefaultValue(0);
            entity.Property(e => e.OddLaneTeamId).HasDefaultValue(0);
            entity.Property(e => e.TourneyId).HasDefaultValue(0);
        });

        modelBuilder.Entity<ZtblSkipLabel>(entity =>
        {
            entity.Property(e => e.LabelCount).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
