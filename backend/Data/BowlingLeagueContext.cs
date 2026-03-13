using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    public DbSet<Bowler> Bowlers => Set<Bowler>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<BowlerScore> BowlerScores => Set<BowlerScore>();
    public DbSet<MatchGame> MatchGames => Set<MatchGame>();
    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<TourneyMatch> TourneyMatches => Set<TourneyMatch>();
    public DbSet<BowlerRating> BowlerRatings => Set<BowlerRating>();
    public DbSet<SkipLabel> SkipLabels => Set<SkipLabel>();
    public DbSet<Week> Weeks => Set<Week>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>().HasKey(b => b.BowlerId);
        modelBuilder.Entity<Team>().HasKey(t => t.TeamId);
        modelBuilder.Entity<BowlerScore>().HasKey(bs => new { bs.MatchId, bs.GameNumber, bs.BowlerId });
        modelBuilder.Entity<MatchGame>().HasKey(mg => new { mg.MatchId, mg.GameNumber });
        modelBuilder.Entity<Tournament>().HasKey(t => t.TourneyId);
        modelBuilder.Entity<TourneyMatch>().HasKey(tm => tm.MatchId);
        modelBuilder.Entity<BowlerRating>().HasKey(br => br.BowlerRatingText);
        modelBuilder.Entity<SkipLabel>().HasKey(sl => sl.LabelCount);
        modelBuilder.Entity<Week>().HasKey(w => w.WeekStart);

        modelBuilder.Entity<Bowler>()
            .HasOne(b => b.Team)
            .WithMany(t => t.Bowlers)
            .HasForeignKey(b => b.TeamId);

        modelBuilder.Entity<BowlerScore>()
            .HasOne(bs => bs.Bowler)
            .WithMany(b => b.Scores)
            .HasForeignKey(bs => bs.BowlerId);

        modelBuilder.Entity<TourneyMatch>()
            .HasOne(tm => tm.OddLaneTeam)
            .WithMany()
            .HasForeignKey(tm => tm.OddLaneTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TourneyMatch>()
            .HasOne(tm => tm.EvenLaneTeam)
            .WithMany()
            .HasForeignKey(tm => tm.EvenLaneTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TourneyMatch>()
            .HasOne(tm => tm.Tournament)
            .WithMany(t => t.Matches)
            .HasForeignKey(tm => tm.TourneyId);

        modelBuilder.Entity<MatchGame>()
            .HasOne(mg => mg.Match)
            .WithMany(m => m.Games)
            .HasForeignKey(mg => mg.MatchId);
    }
}
