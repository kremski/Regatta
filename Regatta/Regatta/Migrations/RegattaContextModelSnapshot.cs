using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Regatta.Models;
using System;

namespace Regatta.Migrations
{
	[DbContext(typeof(RegattaContext))]
    partial class RegattaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Regatta.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("TownOrCity");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Regatta.Models.Competitor", b =>
                {
                    b.Property<int>("CompetitorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgeGroup");

                    b.Property<int?>("ClubId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsRankingClasified");

                    b.Property<string>("LastName");

                    b.Property<string>("SailNumber");

                    b.HasKey("CompetitorId");

                    b.HasIndex("ClubId");

                    b.ToTable("Competitors");
                });

            modelBuilder.Entity("Regatta.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Group");

                    b.Property<int>("RaceNumber");

                    b.Property<int>("RaceType");

                    b.Property<int>("Round");

                    b.HasKey("RaceId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Regatta.Models.RacePoint", b =>
                {
                    b.Property<int>("RacePointId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCrossed");

                    b.Property<double>("Points");

                    b.Property<int>("RaceId");

                    b.Property<int>("RegattaCompetitorId");

                    b.HasKey("RacePointId");

                    b.HasIndex("RaceId");

                    b.HasIndex("RegattaCompetitorId");

                    b.ToTable("RacePoints");
                });

            modelBuilder.Entity("Regatta.Models.Regatta", b =>
                {
                    b.Property<int>("RegattaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Class");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("RegattaId");

                    b.ToTable("Regattas");
                });

            modelBuilder.Entity("Regatta.Models.RegattaCompetitor", b =>
                {
                    b.Property<int>("RegattaCompetitorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetitorId");

                    b.Property<int>("RegattaId");

                    b.HasKey("RegattaCompetitorId");

                    b.HasIndex("CompetitorId");

                    b.HasIndex("RegattaId");

                    b.ToTable("RegattaCompetitors");
                });

            modelBuilder.Entity("Regatta.Models.Competitor", b =>
                {
                    b.HasOne("Regatta.Models.Club", "Club")
                        .WithMany("ClubMembers")
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("Regatta.Models.RacePoint", b =>
                {
                    b.HasOne("Regatta.Models.Race", "Race")
                        .WithMany("RacePoints")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Regatta.Models.RegattaCompetitor", "RegattaCompetitor")
                        .WithMany("RacePoints")
                        .HasForeignKey("RegattaCompetitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Regatta.Models.RegattaCompetitor", b =>
                {
                    b.HasOne("Regatta.Models.Competitor", "Competitor")
                        .WithMany("RegattaCompetitors")
                        .HasForeignKey("CompetitorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Regatta.Models.Regatta", "Regatta")
                        .WithMany("RegattaCompetitors")
                        .HasForeignKey("RegattaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
