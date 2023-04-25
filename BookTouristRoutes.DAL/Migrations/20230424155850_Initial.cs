using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookTouristRoutes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    BookedSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AvatarId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Images_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedAt", "URL", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(587), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1016.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(626) },
                    { 2, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(661), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/626.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(664) },
                    { 3, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(673), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/697.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(675) },
                    { 4, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(683), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1122.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(685) },
                    { 5, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(693), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/636.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(695) },
                    { 6, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(702), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/641.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(704) },
                    { 7, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(711), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/510.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(713) },
                    { 8, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(720), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/380.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(722) },
                    { 9, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(729), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/695.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(731) },
                    { 10, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(738), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/653.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(796) },
                    { 11, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(816), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/438.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(820) },
                    { 12, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(829), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/655.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(831) },
                    { 13, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(838), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/699.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(841) },
                    { 14, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(848), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1043.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(850) },
                    { 15, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(857), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1143.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(859) },
                    { 16, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(866), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/80.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(868) },
                    { 17, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(875), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/71.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(877) },
                    { 18, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(885), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/413.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(886) },
                    { 19, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(893), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/161.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(895) },
                    { 20, new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(903), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/305.jpg", new DateTime(2023, 4, 24, 18, 58, 50, 83, DateTimeKind.Local).AddTicks(905) },
                    { 21, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8201), "https://picsum.photos/640/480/?image=851", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8234) },
                    { 22, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8266), "https://picsum.photos/640/480/?image=238", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8268) },
                    { 23, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8278), "https://picsum.photos/640/480/?image=840", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8280) },
                    { 24, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8288), "https://picsum.photos/640/480/?image=182", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8290) },
                    { 25, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8298), "https://picsum.photos/640/480/?image=223", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8299) },
                    { 26, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8307), "https://picsum.photos/640/480/?image=443", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8309) },
                    { 27, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8317), "https://picsum.photos/640/480/?image=41", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8319) },
                    { 28, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8326), "https://picsum.photos/640/480/?image=786", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8328) },
                    { 29, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8361), "https://picsum.photos/640/480/?image=1020", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8363) },
                    { 30, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8372), "https://picsum.photos/640/480/?image=510", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8374) },
                    { 31, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8382), "https://picsum.photos/640/480/?image=927", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8384) },
                    { 32, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8392), "https://picsum.photos/640/480/?image=941", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8393) },
                    { 33, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8402), "https://picsum.photos/640/480/?image=350", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8404) },
                    { 34, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8412), "https://picsum.photos/640/480/?image=909", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8414) },
                    { 35, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8422), "https://picsum.photos/640/480/?image=380", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8424) },
                    { 36, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8432), "https://picsum.photos/640/480/?image=810", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8434) },
                    { 37, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8441), "https://picsum.photos/640/480/?image=504", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8443) },
                    { 38, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8451), "https://picsum.photos/640/480/?image=426", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8453) },
                    { 39, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8461), "https://picsum.photos/640/480/?image=464", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8463) },
                    { 40, new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8471), "https://picsum.photos/640/480/?image=311", new DateTime(2023, 4, 24, 18, 58, 50, 84, DateTimeKind.Local).AddTicks(8473) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 4, 24, 18, 58, 50, 107, DateTimeKind.Local).AddTicks(8328), "test@gmail.com", "testUser", "1gjlXYaBYtJKvOWQ5gcnSU70eqvCaTP7YBJwR4IMtdw=", 0, "KpzMF/6xb5yAFO98417gJXAepgxbeAsrMbVGesruEm0=", new DateTime(2023, 4, 24, 18, 58, 50, 107, DateTimeKind.Local).AddTicks(8328) },
                    { 1, 2, new DateTime(2023, 4, 24, 18, 58, 50, 87, DateTimeKind.Local).AddTicks(5579), "Joe_Ondricka@gmail.com", "Lew_Lang", "kiysWSRsiJOy08/bEn0dvPIpELVJFGoqBuFwMqScUyE=", 1, "FdziYMSwQvzwL2Y9aZ5aSJ3wjFTpu1P1vtd00SWGYvk=", new DateTime(2023, 4, 24, 18, 58, 50, 87, DateTimeKind.Local).AddTicks(5668) },
                    { 2, 8, new DateTime(2023, 4, 24, 18, 58, 50, 88, DateTimeKind.Local).AddTicks(5995), "Alessandra23@hotmail.com", "George.Thiel", "OydFzIXWLUxw4groNCsclFgMWXYbo/mYHQcUZ+XdLQ4=", 1, "dFpggXkWFHRdRhorkPnurAhW7ONJWYyZwU/Ov7FqpiI=", new DateTime(2023, 4, 24, 18, 58, 50, 88, DateTimeKind.Local).AddTicks(5999) },
                    { 3, 20, new DateTime(2023, 4, 24, 18, 58, 50, 89, DateTimeKind.Local).AddTicks(6246), "Michelle.Raynor88@yahoo.com", "Jodie_Donnelly", "wE5yVsalo0YVOPl2sLfjjPvEkPtaERm+UNssWWIuoT0=", 0, "gN8znBWmB/0LOm7TXqKuAXuTXRs7fGwKMduKd2vcwhw=", new DateTime(2023, 4, 24, 18, 58, 50, 89, DateTimeKind.Local).AddTicks(6250) },
                    { 4, 6, new DateTime(2023, 4, 24, 18, 58, 50, 90, DateTimeKind.Local).AddTicks(6496), "Flossie_Satterfield@gmail.com", "Precious24", "WGOlznb6Bx3ADz74WZlZ0tf24rAZD/AuAiErTc9T754=", 0, "yelXmZvqZI/lLz8XGGbNq56MSChrycYcZRkCAy5ip3k=", new DateTime(2023, 4, 24, 18, 58, 50, 90, DateTimeKind.Local).AddTicks(6501) },
                    { 5, 7, new DateTime(2023, 4, 24, 18, 58, 50, 91, DateTimeKind.Local).AddTicks(6592), "Daren.Ratke95@gmail.com", "Ryann33", "gBVnGWGO1KQrrmFuAF2v0+0CT0Sq4cxjzHN7OxX0suM=", 1, "42o5Bqr4XuzUJu9r0kvqBfDT+fD0ayb7vqqU5ljAbpw=", new DateTime(2023, 4, 24, 18, 58, 50, 91, DateTimeKind.Local).AddTicks(6596) },
                    { 6, 13, new DateTime(2023, 4, 24, 18, 58, 50, 92, DateTimeKind.Local).AddTicks(6690), "Giuseppe29@yahoo.com", "Jennifer.Rohan", "zLSfS0I1g0efY1vCfVmDzdca2771dFQsIOny8NjWYaA=", 1, "9N5M6NsycL3iGd7Y6neUXHJVlF2bg8posTw53DNrNjk=", new DateTime(2023, 4, 24, 18, 58, 50, 92, DateTimeKind.Local).AddTicks(6694) },
                    { 7, 3, new DateTime(2023, 4, 24, 18, 58, 50, 93, DateTimeKind.Local).AddTicks(6752), "Tracy11@gmail.com", "Mustafa41", "uxcqQXuuF4MEh27PsKDUblaexhVK5UZxnaR4UzgRFQs=", 0, "5vP/zTkb36wEcae6MsAsSDLjbpxBkvtlFI2vvxD6tM8=", new DateTime(2023, 4, 24, 18, 58, 50, 93, DateTimeKind.Local).AddTicks(6756) },
                    { 8, 8, new DateTime(2023, 4, 24, 18, 58, 50, 94, DateTimeKind.Local).AddTicks(6994), "Fernando19@hotmail.com", "Madison_Connelly39", "8Z9Ldhn1FMP+P/iyMyC9ZgoVMkF1fpt8yx22QoqjFPQ=", 0, "uOvuoWpVxWGDABdNlvt6ulQz/w51B5ea5GVIdFEII1E=", new DateTime(2023, 4, 24, 18, 58, 50, 94, DateTimeKind.Local).AddTicks(6999) },
                    { 9, 9, new DateTime(2023, 4, 24, 18, 58, 50, 95, DateTimeKind.Local).AddTicks(7163), "Isabelle.Muller43@yahoo.com", "Gavin.Sanford63", "PO8gcc9gKp5Ih55JCBh5+FgtukKHSxZZ6r4jN6cf8kA=", 0, "MSV1MZdfDiEJjqbjYGGWGCce6eWF4eSuHlrbZTU8mqY=", new DateTime(2023, 4, 24, 18, 58, 50, 95, DateTimeKind.Local).AddTicks(7166) },
                    { 10, 18, new DateTime(2023, 4, 24, 18, 58, 50, 96, DateTimeKind.Local).AddTicks(7194), "Naomie_Gulgowski33@hotmail.com", "Claudia_Sauer", "j5nmkPdARgSybN3E0QoRrDtGvnY5ulBtaPw+qgjpLMs=", 0, "A5n1+NSRe/WU7WlOUvTh76Il60gEXNXwZmo1LeeOBsw=", new DateTime(2023, 4, 24, 18, 58, 50, 96, DateTimeKind.Local).AddTicks(7196) },
                    { 11, 20, new DateTime(2023, 4, 24, 18, 58, 50, 97, DateTimeKind.Local).AddTicks(7370), "Leon_Considine92@gmail.com", "Dexter.Pfannerstill72", "t1+ij7nAaUklxqYPtQc3UdJ2kmUJqGPUOkjmChpOOAU=", 1, "ivHgEH3shGRNaYuoP55L6SGUlp5/bWcAR32+F8zzltU=", new DateTime(2023, 4, 24, 18, 58, 50, 97, DateTimeKind.Local).AddTicks(7373) },
                    { 12, 20, new DateTime(2023, 4, 24, 18, 58, 50, 98, DateTimeKind.Local).AddTicks(7518), "Desiree61@gmail.com", "Newton.Kertzmann94", "er31xbQB/O75TDweqF0J2IfhjYviyiSo232SwnOAqG4=", 0, "xcQQMTBd7f45usdVx2C9ZIAH7IRazLPPLChgh18T2Ig=", new DateTime(2023, 4, 24, 18, 58, 50, 98, DateTimeKind.Local).AddTicks(7522) },
                    { 13, 5, new DateTime(2023, 4, 24, 18, 58, 50, 99, DateTimeKind.Local).AddTicks(7626), "Tristian_Fay@gmail.com", "Brendon.Erdman", "cr5Dmdj3cGWR00HqMxgxPOe3LQF/rV9KcubPUbp9v2I=", 0, "sABhdwdjP23AceoP0HA2e6+LTqnbFoNIS/ADzIWIlFs=", new DateTime(2023, 4, 24, 18, 58, 50, 99, DateTimeKind.Local).AddTicks(7629) },
                    { 14, 7, new DateTime(2023, 4, 24, 18, 58, 50, 100, DateTimeKind.Local).AddTicks(7735), "Friedrich_Emard@gmail.com", "Patricia_Dietrich", "0l4AEd1QqTr8jIKpccIqvYNI850W3tPK2YIMcYxIwXM=", 1, "U8mDWz9hs7AIVEWMNMAVaGlC4q+K8WISdk2I/fVPjnM=", new DateTime(2023, 4, 24, 18, 58, 50, 100, DateTimeKind.Local).AddTicks(7738) },
                    { 15, 4, new DateTime(2023, 4, 24, 18, 58, 50, 101, DateTimeKind.Local).AddTicks(7769), "Candace10@yahoo.com", "Coty83", "ZIusQTS1JAnzWJcV2GWGwBuOyUw1JBzSMWkFEg/g+bE=", 1, "VD1NjHRN8GMMwvw7G7PT3bhSnIyYFStCN5xej863nz0=", new DateTime(2023, 4, 24, 18, 58, 50, 101, DateTimeKind.Local).AddTicks(7772) },
                    { 16, 8, new DateTime(2023, 4, 24, 18, 58, 50, 102, DateTimeKind.Local).AddTicks(7923), "Otho_Bruen@hotmail.com", "Leslie_Morissette", "oHHdX3FYD2Mklv38uJtsFG81Db8m5dAZgxjJSErOtvo=", 0, "v8G3DY1+W+O8ja/WzYpsCMCqKuRV88UrBFlU0LDaetE=", new DateTime(2023, 4, 24, 18, 58, 50, 102, DateTimeKind.Local).AddTicks(7926) },
                    { 17, 7, new DateTime(2023, 4, 24, 18, 58, 50, 103, DateTimeKind.Local).AddTicks(8034), "Cory.Pfannerstill41@yahoo.com", "Wallace42", "08r7R1odQBjhnn9lfTlK7czR0PAN4CUJ8ETM3pn28T4=", 1, "BkRft1oelFVomuXQHBCqaoeWZuyf6nwXIKZWxpRC3ao=", new DateTime(2023, 4, 24, 18, 58, 50, 103, DateTimeKind.Local).AddTicks(8037) },
                    { 18, 10, new DateTime(2023, 4, 24, 18, 58, 50, 104, DateTimeKind.Local).AddTicks(8073), "Cordell_Nolan@yahoo.com", "Sonny_Wuckert", "zwoG7UE3VHsW8KGESLp+5oVMF8gHzZlRTQW9OMASguY=", 1, "pmsAKuelCx30tWIYFMXwnyEVKDyqsBwzZb44rBm9zTI=", new DateTime(2023, 4, 24, 18, 58, 50, 104, DateTimeKind.Local).AddTicks(8076) },
                    { 19, 11, new DateTime(2023, 4, 24, 18, 58, 50, 105, DateTimeKind.Local).AddTicks(8281), "Pink.Runolfsdottir@gmail.com", "Orie_Blick", "vnJKwdR8wDO5z5G3f4nYcL+Jxq92FILlrVSNI0f7hd8=", 1, "UsYvdp+Ku3e4UU/1CebvK25d9gembp2tyQjG3e09njE=", new DateTime(2023, 4, 24, 18, 58, 50, 105, DateTimeKind.Local).AddTicks(8286) },
                    { 20, 19, new DateTime(2023, 4, 24, 18, 58, 50, 106, DateTimeKind.Local).AddTicks(8386), "Karli.Cole@gmail.com", "Antonietta.McDermott", "e6F5tVtsRLsoln8ABl42bQNWt5tUSKpRDsdqbJAWTkE=", 1, "sNlmx1bokn9TAa6FfNtdRX2MKCtYvUQM1FZg7i0FcUU=", new DateTime(2023, 4, 24, 18, 58, 50, 106, DateTimeKind.Local).AddTicks(8389) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarId",
                table: "Users",
                column: "AvatarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
