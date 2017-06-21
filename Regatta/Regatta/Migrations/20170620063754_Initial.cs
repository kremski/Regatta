using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Regatta.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Clubs",
				columns: table => new
				{
					ClubId = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Country = table.Column<string>(nullable: true),
					Name = table.Column<string>(nullable: true),
					TownOrCity = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Clubs", x => x.ClubId);
				});

			migrationBuilder.CreateTable(
				name: "Races",
				columns: table => new
				{
					RaceId = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Group = table.Column<string>(nullable: true),
					RaceNumber = table.Column<int>(nullable: false),
					RaceType = table.Column<int>(nullable: false),
					Round = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Races", x => x.RaceId);
				});

			migrationBuilder.CreateTable(
				name: "Regattas",
				columns: table => new
				{
					RegattaId = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Class = table.Column<string>(nullable: true),
					EndDate = table.Column<DateTime>(nullable: false),
					Name = table.Column<string>(nullable: true),
					Rating = table.Column<int>(nullable: false),
					StartDate = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Regattas", x => x.RegattaId);
				});

			migrationBuilder.CreateTable(
				name: "Competitors",
				columns: table => new
				{
					CompetitorId = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					AgeGroup = table.Column<int>(nullable: false),
					ClubId = table.Column<int>(nullable: true),
					FirstName = table.Column<string>(nullable: true),
					IsRankingClasified = table.Column<bool>(nullable: false),
					LastName = table.Column<string>(nullable: true),
					SailNumber = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Competitors", x => x.CompetitorId);
					table.ForeignKey(
						name: "FK_Competitors_Clubs_ClubId",
						column: x => x.ClubId,
						principalTable: "Clubs",
						principalColumn: "ClubId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "RegattaCompetitors",
				columns: table => new
				{
					RegattaCompetitorId = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					CompetitorId = table.Column<int>(nullable: false),
					RegattaId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RegattaCompetitors", x => x.RegattaCompetitorId);
					table.ForeignKey(
						name: "FK_RegattaCompetitors_Competitors_CompetitorId",
						column: x => x.CompetitorId,
						principalTable: "Competitors",
						principalColumn: "CompetitorId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RegattaCompetitors_Regattas_RegattaId",
						column: x => x.RegattaId,
						principalTable: "Regattas",
						principalColumn: "RegattaId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "RacePoints",
				columns: table => new
				{
					RacePointId = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					IsCrossed = table.Column<bool>(nullable: false),
					Points = table.Column<double>(nullable: false),
					RaceId = table.Column<int>(nullable: false),
					RegattaCompetitorId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RacePoints", x => x.RacePointId);
					table.ForeignKey(
						name: "FK_RacePoints_Races_RaceId",
						column: x => x.RaceId,
						principalTable: "Races",
						principalColumn: "RaceId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RacePoints_RegattaCompetitors_RegattaCompetitorId",
						column: x => x.RegattaCompetitorId,
						principalTable: "RegattaCompetitors",
						principalColumn: "RegattaCompetitorId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Competitors_ClubId",
				table: "Competitors",
				column: "ClubId");

			migrationBuilder.CreateIndex(
				name: "IX_RacePoints_RaceId",
				table: "RacePoints",
				column: "RaceId");

			migrationBuilder.CreateIndex(
				name: "IX_RacePoints_RegattaCompetitorId",
				table: "RacePoints",
				column: "RegattaCompetitorId");

			migrationBuilder.CreateIndex(
				name: "IX_RegattaCompetitors_CompetitorId",
				table: "RegattaCompetitors",
				column: "CompetitorId");

			migrationBuilder.CreateIndex(
				name: "IX_RegattaCompetitors_RegattaId",
				table: "RegattaCompetitors",
				column: "RegattaId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "RacePoints");

			migrationBuilder.DropTable(
				name: "Races");

			migrationBuilder.DropTable(
				name: "RegattaCompetitors");

			migrationBuilder.DropTable(
				name: "Competitors");

			migrationBuilder.DropTable(
				name: "Regattas");

			migrationBuilder.DropTable(
				name: "Clubs");
		}
	}
}
