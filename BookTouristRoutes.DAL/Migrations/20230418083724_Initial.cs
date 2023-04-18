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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
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
                    { 1, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(677), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/399.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(734) },
                    { 2, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(796), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1112.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(800) },
                    { 3, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(817), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/655.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(820) },
                    { 4, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(832), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/94.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(835) },
                    { 5, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(848), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/820.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(851) },
                    { 6, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(864), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/104.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(867) },
                    { 7, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(879), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1037.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(883) },
                    { 8, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(896), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/598.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(899) },
                    { 9, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(911), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1009.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(914) },
                    { 10, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(927), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/479.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(930) },
                    { 11, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(945), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/160.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(949) },
                    { 12, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(964), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/499.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(968) },
                    { 13, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1027), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/86.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1032) },
                    { 14, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1049), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/613.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1051) },
                    { 15, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1059), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/522.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1061) },
                    { 16, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1069), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/9.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1071) },
                    { 17, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1079), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1087.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1081) },
                    { 18, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1088), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/841.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1090) },
                    { 19, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1097), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/795.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1099) },
                    { 20, new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1106), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/354.jpg", new DateTime(2023, 4, 18, 11, 37, 24, 300, DateTimeKind.Local).AddTicks(1108) },
                    { 21, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4319), "https://picsum.photos/640/480/?image=415", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4347) },
                    { 22, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4381), "https://picsum.photos/640/480/?image=201", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4383) },
                    { 23, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4392), "https://picsum.photos/640/480/?image=176", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4394) },
                    { 24, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4403), "https://picsum.photos/640/480/?image=24", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4405) },
                    { 25, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4413), "https://picsum.photos/640/480/?image=684", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4415) },
                    { 26, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4423), "https://picsum.photos/640/480/?image=181", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4425) },
                    { 27, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4433), "https://picsum.photos/640/480/?image=679", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4435) },
                    { 28, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4443), "https://picsum.photos/640/480/?image=891", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4445) },
                    { 29, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4453), "https://picsum.photos/640/480/?image=895", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4454) },
                    { 30, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4464), "https://picsum.photos/640/480/?image=686", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4466) },
                    { 31, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4536), "https://picsum.photos/640/480/?image=685", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4538) },
                    { 32, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4547), "https://picsum.photos/640/480/?image=958", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4548) },
                    { 33, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4556), "https://picsum.photos/640/480/?image=899", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4558) },
                    { 34, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4566), "https://picsum.photos/640/480/?image=935", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4568) },
                    { 35, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4576), "https://picsum.photos/640/480/?image=40", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4578) },
                    { 36, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4585), "https://picsum.photos/640/480/?image=265", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4587) },
                    { 37, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4595), "https://picsum.photos/640/480/?image=1019", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4597) },
                    { 38, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4603), "https://picsum.photos/640/480/?image=848", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4605) },
                    { 39, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4614), "https://picsum.photos/640/480/?image=473", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4615) },
                    { 40, new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4623), "https://picsum.photos/640/480/?image=945", new DateTime(2023, 4, 18, 11, 37, 24, 301, DateTimeKind.Local).AddTicks(4625) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "CreatedAt", "Email", "Name", "Password", "Roles", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 4, 18, 11, 37, 24, 324, DateTimeKind.Local).AddTicks(6775), "test@gmail.com", "testUser", "e8B/x+na1GkPY8kCm/JNKqibp7EKrdrcV9FFYxCbV/w=", 0, "LVy644AXCVfgFxf2EOO8v4amunbCe2P9i13a/jeX2i8=", new DateTime(2023, 4, 18, 11, 37, 24, 324, DateTimeKind.Local).AddTicks(6775) },
                    { 1, 4, new DateTime(2023, 4, 18, 11, 37, 24, 304, DateTimeKind.Local).AddTicks(45), "Nicolas_Kohler3@hotmail.com", "Jamil_Wuckert80", "dplJYx2rPdm2EAStnDA3RPiX+gEHe41EU0BJ1teIGUE=", 1, "biK19lq7opJRPXer7pOBSWQyXDhUGbW4gFYTSybEbQQ=", new DateTime(2023, 4, 18, 11, 37, 24, 304, DateTimeKind.Local).AddTicks(124) },
                    { 2, 14, new DateTime(2023, 4, 18, 11, 37, 24, 305, DateTimeKind.Local).AddTicks(459), "Destinee_Keebler@yahoo.com", "Sim_Skiles31", "7Uhp2PM6tHpGKRt3TA9Og857W4yuBhAvozXFWlTjm+Q=", 1, "HSiXaGaR5sf7Q9+NR22T+BD4LYrFZz1EP+3VZ/YEAWs=", new DateTime(2023, 4, 18, 11, 37, 24, 305, DateTimeKind.Local).AddTicks(464) },
                    { 3, 13, new DateTime(2023, 4, 18, 11, 37, 24, 306, DateTimeKind.Local).AddTicks(568), "Moises87@yahoo.com", "Rosa_Hane58", "sFXJjd5uGFF+USBf7th5ZVN/VplajEQr1E7NbC5NrpA=", 1, "HGIA5vRYJJSCv0iYY8WxOVyQX53i5ODEOn49jlZTWqQ=", new DateTime(2023, 4, 18, 11, 37, 24, 306, DateTimeKind.Local).AddTicks(573) },
                    { 4, 11, new DateTime(2023, 4, 18, 11, 37, 24, 307, DateTimeKind.Local).AddTicks(757), "Lisa.Koelpin@hotmail.com", "Frederic.Weimann", "jw+lBnsgkJ9x3N/wwU77rwAgv0vstlTJquxygbGVHdY=", 0, "R4t7R36BjQ5J5oY/j9EXqekxAI+IjySd5Qsy6hpt4FU=", new DateTime(2023, 4, 18, 11, 37, 24, 307, DateTimeKind.Local).AddTicks(761) },
                    { 5, 4, new DateTime(2023, 4, 18, 11, 37, 24, 308, DateTimeKind.Local).AddTicks(1201), "Krystal.Koelpin@hotmail.com", "Grant65", "/44icPFLJJcJEswMC34olUorKZtXhWf6+5UokOpi0Yw=", 0, "EpEzoybN2XePQJlMB0tIxV3sIZjb8Abb4ekJX79Wb+U=", new DateTime(2023, 4, 18, 11, 37, 24, 308, DateTimeKind.Local).AddTicks(1205) },
                    { 6, 5, new DateTime(2023, 4, 18, 11, 37, 24, 309, DateTimeKind.Local).AddTicks(1310), "Adolfo_Kohler@yahoo.com", "Janae94", "9Bc5jT8VDzPdj0aoAKsxVOMNjbqPKcCr7/0dOM8FDcQ=", 1, "5aeaLOOlFDBzhCi3MlDUcWP7UpDv114c3lLUQsUrbuI=", new DateTime(2023, 4, 18, 11, 37, 24, 309, DateTimeKind.Local).AddTicks(1314) },
                    { 7, 2, new DateTime(2023, 4, 18, 11, 37, 24, 310, DateTimeKind.Local).AddTicks(1520), "Estelle.King@gmail.com", "Tyshawn_Littel73", "+OR2i5ood7fEt46leYdz7FYw7K1kkd8SV0igrt6+qpE=", 1, "R4qKslwOiM1HCTwZB9YTq0+S7IUES53M0GNomzHN0aw=", new DateTime(2023, 4, 18, 11, 37, 24, 310, DateTimeKind.Local).AddTicks(1523) },
                    { 8, 9, new DateTime(2023, 4, 18, 11, 37, 24, 311, DateTimeKind.Local).AddTicks(2051), "Johanna.Glover@hotmail.com", "Aliya_Gutmann39", "ByGlLtZID3Sf4iNzucQnEyojLJWJTJmuwuC8ldZaxtc=", 1, "tyRGlanU2bD3PaoNuFxP79516ug8ugE9AJzsRGWfL8E=", new DateTime(2023, 4, 18, 11, 37, 24, 311, DateTimeKind.Local).AddTicks(2062) },
                    { 9, 5, new DateTime(2023, 4, 18, 11, 37, 24, 312, DateTimeKind.Local).AddTicks(2580), "Ezequiel_Waters@hotmail.com", "Elvera_Hahn35", "8SXppq9pJV3pG5WxyvO12qMZrQF6GzCs25PFi6xVv7k=", 1, "iORhO2oAMIDi4WlMA/r1JBcPwL9YukNtZZPRXlpqfrI=", new DateTime(2023, 4, 18, 11, 37, 24, 312, DateTimeKind.Local).AddTicks(2590) },
                    { 10, 14, new DateTime(2023, 4, 18, 11, 37, 24, 313, DateTimeKind.Local).AddTicks(3116), "Miguel.Stehr49@yahoo.com", "Bethany_MacGyver22", "DQ0Vwwl454/HYBAUmWimFZNaXbiIEHq/XxMEwcfQPeA=", 0, "1p8E++j0vTW9YLw09c4tuthkzsHwQ9gGT4QAOww4DvE=", new DateTime(2023, 4, 18, 11, 37, 24, 313, DateTimeKind.Local).AddTicks(3126) },
                    { 11, 10, new DateTime(2023, 4, 18, 11, 37, 24, 314, DateTimeKind.Local).AddTicks(3517), "Annetta_Johns@gmail.com", "Chris.Schroeder", "B14NyLLM46btlrUFvqFQWjMrBFMydrqxnUILnkuMqoY=", 1, "xkhwgWDgIQzoB2dAnt31nQQHZdCMje7wVjXzhSgjN3c=", new DateTime(2023, 4, 18, 11, 37, 24, 314, DateTimeKind.Local).AddTicks(3527) },
                    { 12, 7, new DateTime(2023, 4, 18, 11, 37, 24, 315, DateTimeKind.Local).AddTicks(3958), "Jerod_Leffler@hotmail.com", "Ryan53", "MZxdZdv3WLKlMuL4sulg1WEwtEZuFOem9d+JfivZNHY=", 1, "ZQBAc3BXN9XEBZVHLzlOB6U4S7DHjaoJu5pqDLOBEuw=", new DateTime(2023, 4, 18, 11, 37, 24, 315, DateTimeKind.Local).AddTicks(3969) },
                    { 13, 13, new DateTime(2023, 4, 18, 11, 37, 24, 316, DateTimeKind.Local).AddTicks(4208), "Fanny.Renner@gmail.com", "Javonte.Corkery", "uc7/ZOiYoqJvA6EKjCQTPmtbaO1ZjDHbKPOO06LWbOY=", 0, "qhAVnhYg4D9MwnyXJWDNdkJoca7WhAnd8SoA6ZDDnDs=", new DateTime(2023, 4, 18, 11, 37, 24, 316, DateTimeKind.Local).AddTicks(4216) },
                    { 14, 20, new DateTime(2023, 4, 18, 11, 37, 24, 317, DateTimeKind.Local).AddTicks(4544), "Josiah.Langosh@yahoo.com", "Dixie_Douglas", "BPGIvedCG4nhNcTKLhq4xwm1C2YwUXHXlJPcoCLlgEM=", 1, "ieIUPPEKUMpDR7vjEKQAAYOPZN2qFlgIvGDl50/v5kY=", new DateTime(2023, 4, 18, 11, 37, 24, 317, DateTimeKind.Local).AddTicks(4550) },
                    { 15, 1, new DateTime(2023, 4, 18, 11, 37, 24, 318, DateTimeKind.Local).AddTicks(4879), "Jazmyne_Casper58@gmail.com", "Bertram_Schaden", "pouepvlzqIVk3rr9oRU/UcsMgTcy0LGBebMi6XUuJAY=", 0, "Kpeu5vmhzAT8mE7PzMVLo47ZQSAqY6HzmNRchreZNiw=", new DateTime(2023, 4, 18, 11, 37, 24, 318, DateTimeKind.Local).AddTicks(4883) },
                    { 16, 13, new DateTime(2023, 4, 18, 11, 37, 24, 319, DateTimeKind.Local).AddTicks(5170), "Aimee_Rohan@gmail.com", "Francesca_Hauck17", "0WxNw85uuh/uDtT3/xr/dmk1AtP6ogBs4g5CrcqGGNA=", 1, "qOeB3pDugQINMIeJjZYc735E0jdTf3do3pnNjDr0MTQ=", new DateTime(2023, 4, 18, 11, 37, 24, 319, DateTimeKind.Local).AddTicks(5174) },
                    { 17, 3, new DateTime(2023, 4, 18, 11, 37, 24, 320, DateTimeKind.Local).AddTicks(5625), "Linnea39@gmail.com", "Keagan_Gibson", "ZM+F/iBRe7bp0mYWELZArutmnianPOmFXcbkinCb8GI=", 0, "SOLh4u9RYqKI4il9Dlet3bHocZSGFv8s0l8HCDm4Kto=", new DateTime(2023, 4, 18, 11, 37, 24, 320, DateTimeKind.Local).AddTicks(5629) },
                    { 18, 12, new DateTime(2023, 4, 18, 11, 37, 24, 321, DateTimeKind.Local).AddTicks(5956), "Sammy23@hotmail.com", "Phyllis.Tromp86", "A8s0Ra/eevp+esy1g7fQHWrAf6/OAZxhJOAzJaJeQn4=", 1, "0ig6WItLPiVyHghUuuQ65REe9ROsHMQZ3tTzPw1yISM=", new DateTime(2023, 4, 18, 11, 37, 24, 321, DateTimeKind.Local).AddTicks(5960) },
                    { 19, 9, new DateTime(2023, 4, 18, 11, 37, 24, 322, DateTimeKind.Local).AddTicks(6248), "Kennedi.Purdy0@yahoo.com", "Enos81", "FVSCpOw77TYa9ktsS4zQfEgv8Zj7hUTzwVJ9nNV2nTA=", 0, "C667iP0QnPyeyEDWzRsfOKBUZEAH7F/Njg8A4UJSkMQ=", new DateTime(2023, 4, 18, 11, 37, 24, 322, DateTimeKind.Local).AddTicks(6251) },
                    { 20, 6, new DateTime(2023, 4, 18, 11, 37, 24, 323, DateTimeKind.Local).AddTicks(6569), "Mohamed.Cremin43@yahoo.com", "Nikko.Abernathy", "WOpzHRNXeHhqFg09dsLTOKzj17igZiemaCZeSU9uJmA=", 0, "NpUF7S2PREdniPp4Lcyh3RFys7SfiwCNT6UqFxb2zfY=", new DateTime(2023, 4, 18, 11, 37, 24, 323, DateTimeKind.Local).AddTicks(6572) }
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
