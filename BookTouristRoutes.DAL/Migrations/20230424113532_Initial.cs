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
                    { 1, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8650), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1100.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8689) },
                    { 2, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8724), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/719.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8727) },
                    { 3, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8736), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/481.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8738) },
                    { 4, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8746), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/646.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8747) },
                    { 5, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8755), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/458.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8757) },
                    { 6, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8764), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/487.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8765) },
                    { 7, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8774), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/498.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8776) },
                    { 8, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8783), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/749.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8785) },
                    { 9, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8793), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/347.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8794) },
                    { 10, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8801), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/261.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8803) },
                    { 11, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8810), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/770.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8812) },
                    { 12, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8820), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/378.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8822) },
                    { 13, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8829), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/301.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8831) },
                    { 14, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8839), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/565.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8840) },
                    { 15, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8848), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1117.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8850) },
                    { 16, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8857), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/4.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8859) },
                    { 17, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8866), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/961.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8868) },
                    { 18, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8875), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/300.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8876) },
                    { 19, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8884), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1108.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8886) },
                    { 20, new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8933), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/879.jpg", new DateTime(2023, 4, 24, 14, 35, 32, 838, DateTimeKind.Local).AddTicks(8935) },
                    { 21, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7362), "https://picsum.photos/640/480/?image=953", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7394) },
                    { 22, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7427), "https://picsum.photos/640/480/?image=891", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7430) },
                    { 23, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7440), "https://picsum.photos/640/480/?image=267", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7442) },
                    { 24, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7450), "https://picsum.photos/640/480/?image=862", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7452) },
                    { 25, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7462), "https://picsum.photos/640/480/?image=707", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7464) },
                    { 26, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7472), "https://picsum.photos/640/480/?image=683", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7474) },
                    { 27, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7509), "https://picsum.photos/640/480/?image=233", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7511) },
                    { 28, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7521), "https://picsum.photos/640/480/?image=77", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7522) },
                    { 29, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7530), "https://picsum.photos/640/480/?image=962", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7532) },
                    { 30, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7539), "https://picsum.photos/640/480/?image=444", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7541) },
                    { 31, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7549), "https://picsum.photos/640/480/?image=857", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7551) },
                    { 32, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7558), "https://picsum.photos/640/480/?image=35", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7560) },
                    { 33, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7568), "https://picsum.photos/640/480/?image=117", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7570) },
                    { 34, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7578), "https://picsum.photos/640/480/?image=196", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7579) },
                    { 35, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7587), "https://picsum.photos/640/480/?image=82", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7589) },
                    { 36, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7597), "https://picsum.photos/640/480/?image=450", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7599) },
                    { 37, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7607), "https://picsum.photos/640/480/?image=434", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7608) },
                    { 38, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7617), "https://picsum.photos/640/480/?image=880", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7619) },
                    { 39, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7627), "https://picsum.photos/640/480/?image=543", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7629) },
                    { 40, new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7637), "https://picsum.photos/640/480/?image=734", new DateTime(2023, 4, 24, 14, 35, 32, 840, DateTimeKind.Local).AddTicks(7639) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "CreatedAt", "Email", "Name", "Password", "Roles", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 4, 24, 14, 35, 32, 863, DateTimeKind.Local).AddTicks(9127), "test@gmail.com", "testUser", "UBUXfehO8LgYvC39FrIqs+YZ8pR8ihq0YlHVsSaWynU=", 0, "sTqHIXQYRnrX6ForbhKLtQcZicmwd5geyeGa5KpYYDs=", new DateTime(2023, 4, 24, 14, 35, 32, 863, DateTimeKind.Local).AddTicks(9127) },
                    { 1, 13, new DateTime(2023, 4, 24, 14, 35, 32, 843, DateTimeKind.Local).AddTicks(5874), "Hans.Runolfsdottir58@gmail.com", "Tina_Swift73", "2QCQK51QkT417kb3azxhb3e2I71J6S8xdgoy94L7dRw=", 0, "Ku/9M0VkaJrw7JT1QaoEpGYIkXNVhf6WTN82yXpBZ4Y=", new DateTime(2023, 4, 24, 14, 35, 32, 843, DateTimeKind.Local).AddTicks(5963) },
                    { 2, 8, new DateTime(2023, 4, 24, 14, 35, 32, 844, DateTimeKind.Local).AddTicks(6381), "Alexys1@hotmail.com", "Dena96", "xtkYempDuO8wrRZ6Irb9/JRo217LK+fr4zKe3YGsDJE=", 0, "z7re9nhK7zOtmDSvTB1yaRrmHi5i6Kap9ckaWGc4Pls=", new DateTime(2023, 4, 24, 14, 35, 32, 844, DateTimeKind.Local).AddTicks(6388) },
                    { 3, 8, new DateTime(2023, 4, 24, 14, 35, 32, 845, DateTimeKind.Local).AddTicks(6515), "Marina91@gmail.com", "Tevin.Nicolas76", "+F9oXT84dr7QrtByrMnjOkgNqJ39aem6i/C8YxO6WOg=", 1, "hBeLakt7IlF64lLit0r3w4XG96eUByoVR3I+f6b4aa4=", new DateTime(2023, 4, 24, 14, 35, 32, 845, DateTimeKind.Local).AddTicks(6518) },
                    { 4, 5, new DateTime(2023, 4, 24, 14, 35, 32, 846, DateTimeKind.Local).AddTicks(6620), "Clare.Langosh82@gmail.com", "Jerry79", "TH23dbTHfBxTlS6NPScXDsJ9t3XyBJpMGQziI2Yp4YU=", 0, "6CrncdT4YtEwoJhEjaEdAiqlonYBvq9OXNi4NaNNuBs=", new DateTime(2023, 4, 24, 14, 35, 32, 846, DateTimeKind.Local).AddTicks(6623) },
                    { 5, 1, new DateTime(2023, 4, 24, 14, 35, 32, 847, DateTimeKind.Local).AddTicks(6861), "Katelyn53@hotmail.com", "Floyd_Casper", "Hk/w6pdmMGsdVHhvoMX7obTtpiSbdRK9XUc8yvSkL3k=", 1, "H+7eWzRdPfNof5oHufqZPyg63Vz4uesNIuZnh98h6ts=", new DateTime(2023, 4, 24, 14, 35, 32, 847, DateTimeKind.Local).AddTicks(6867) },
                    { 6, 1, new DateTime(2023, 4, 24, 14, 35, 32, 848, DateTimeKind.Local).AddTicks(7215), "Maverick.Kris@gmail.com", "Rogers_Ruecker", "SLmuvljQS+Acwp+2BPihWFgllTAdQ2JNatabDh/jMLE=", 0, "pfS3PvdYYwqbMNYn/MkC1yUiDk9TP1HGmxnF+G4fG/I=", new DateTime(2023, 4, 24, 14, 35, 32, 848, DateTimeKind.Local).AddTicks(7220) },
                    { 7, 6, new DateTime(2023, 4, 24, 14, 35, 32, 849, DateTimeKind.Local).AddTicks(7272), "Tamara3@yahoo.com", "Wilma23", "gCjcv4w0aZD7qKb7OJkSH/nFLCntlfqNfoAmjCNuDRg=", 1, "4yJEkaU+iD9BG5V0DnVUFru2wefjjy41/yU6pKsuNV4=", new DateTime(2023, 4, 24, 14, 35, 32, 849, DateTimeKind.Local).AddTicks(7276) },
                    { 8, 16, new DateTime(2023, 4, 24, 14, 35, 32, 850, DateTimeKind.Local).AddTicks(7530), "Vivian.Heller47@yahoo.com", "Bud_Waters", "v1OhNMLY4B17ng+0zMAiEvf8MLQF0ZiSezRrfpL+UWQ=", 0, "8zocJaMSIdxUvUNUwb7nC7fpysTCm6GYVhdVmr7c2mQ=", new DateTime(2023, 4, 24, 14, 35, 32, 850, DateTimeKind.Local).AddTicks(7534) },
                    { 9, 11, new DateTime(2023, 4, 24, 14, 35, 32, 851, DateTimeKind.Local).AddTicks(7747), "Twila10@hotmail.com", "Davin64", "dXAW5HAb69+wJaIY59r1nLeTh8Zd5gXP32U7ZAIBj+c=", 1, "hSG5HX+qGtqMhNgjQiKJj4TY3DF1FjpH3FZX13Ab67A=", new DateTime(2023, 4, 24, 14, 35, 32, 851, DateTimeKind.Local).AddTicks(7751) },
                    { 10, 16, new DateTime(2023, 4, 24, 14, 35, 32, 852, DateTimeKind.Local).AddTicks(7743), "Moshe.Schowalter@gmail.com", "Vita.West64", "vwhlOwdYAg4+uVo+RifDAh3AgGReBn8b+/ZETM6Dtec=", 1, "+ObI/9cC5qEE+Gybz2p5yvCaTia6I6/feVQoRT8ubaI=", new DateTime(2023, 4, 24, 14, 35, 32, 852, DateTimeKind.Local).AddTicks(7747) },
                    { 11, 6, new DateTime(2023, 4, 24, 14, 35, 32, 853, DateTimeKind.Local).AddTicks(7831), "Brown.Graham@hotmail.com", "Tara_Ledner", "m6wnzvBVjmn94mLpCjA2b7GsfGZdHyJja/kivSKNW6s=", 1, "GTdvWext+9boWDpixu+PEwjnmU7wlUDayIQCC0kuPaU=", new DateTime(2023, 4, 24, 14, 35, 32, 853, DateTimeKind.Local).AddTicks(7834) },
                    { 12, 19, new DateTime(2023, 4, 24, 14, 35, 32, 854, DateTimeKind.Local).AddTicks(7965), "Malika65@yahoo.com", "Beverly.Gleason", "W7X3UfoCGr9XRZc+zWW9alOdrXvSt1gunbuaAOu1XIQ=", 0, "C/lkMRVHR2tITdSdihqg2UxYbhNBz0SlS+4ZymrsYAo=", new DateTime(2023, 4, 24, 14, 35, 32, 854, DateTimeKind.Local).AddTicks(7968) },
                    { 13, 9, new DateTime(2023, 4, 24, 14, 35, 32, 855, DateTimeKind.Local).AddTicks(8114), "Dennis27@yahoo.com", "Otho.Mosciski", "YHzm22ni0/QuOnPXJY7EL1OdoCcLkWdE8Cdt+/uyMMg=", 1, "rGz8h7fyCuMy9BLcblCr5S1jpW64WmQzi39kGWsx13k=", new DateTime(2023, 4, 24, 14, 35, 32, 855, DateTimeKind.Local).AddTicks(8118) },
                    { 14, 20, new DateTime(2023, 4, 24, 14, 35, 32, 856, DateTimeKind.Local).AddTicks(8285), "Else_Ferry51@hotmail.com", "Zora79", "hnNxZtfiloaI+E2k2ow8jSyZKjcDX8LEvLeg5X3cHaM=", 0, "2zQgni7pc4br5iI2cZ/MBLHq+W4AOZWzyE0AHPRCMq8=", new DateTime(2023, 4, 24, 14, 35, 32, 856, DateTimeKind.Local).AddTicks(8288) },
                    { 15, 13, new DateTime(2023, 4, 24, 14, 35, 32, 857, DateTimeKind.Local).AddTicks(8351), "Korey.Walsh63@hotmail.com", "Hillary99", "JbwgQRLAyJUIRARs59cIDNPB/U+ckZ2WwIrvTI6wVy8=", 0, "OjmJpCRwaxWEix1DbALwIqS6Azl8cydQ9rOW23greKU=", new DateTime(2023, 4, 24, 14, 35, 32, 857, DateTimeKind.Local).AddTicks(8354) },
                    { 16, 2, new DateTime(2023, 4, 24, 14, 35, 32, 858, DateTimeKind.Local).AddTicks(8634), "Pattie.Gleason26@yahoo.com", "Braxton77", "vx1B/dLZ+6ehv8qLRHVYomT7S8UvQQPs+wCb+XDLwaY=", 0, "OUe5RYJTBeYHSbzbldkRWdTSGoyfvYtCSjl8E/ybLL4=", new DateTime(2023, 4, 24, 14, 35, 32, 858, DateTimeKind.Local).AddTicks(8638) },
                    { 17, 15, new DateTime(2023, 4, 24, 14, 35, 32, 859, DateTimeKind.Local).AddTicks(8695), "Luther26@gmail.com", "Madelyn.Wiza73", "TcRq7kLmv/L11pWoyxGk6s7Abo+c+VKOjQvG+tdgxxI=", 0, "sKveKL3us0nBnTkpWR6L7NhWt7gLA61simm1HJjR1ss=", new DateTime(2023, 4, 24, 14, 35, 32, 859, DateTimeKind.Local).AddTicks(8698) },
                    { 18, 18, new DateTime(2023, 4, 24, 14, 35, 32, 860, DateTimeKind.Local).AddTicks(8850), "Berry83@yahoo.com", "Margret.Halvorson54", "NSj88WBODcINZTaUrITiXkrjjWrn3+buskXyg1qv+V0=", 0, "/90Sd5Fgq/Sxn0qcIjb6adfGouxOgW6eKXS2kYKGIJE=", new DateTime(2023, 4, 24, 14, 35, 32, 860, DateTimeKind.Local).AddTicks(8856) },
                    { 19, 13, new DateTime(2023, 4, 24, 14, 35, 32, 861, DateTimeKind.Local).AddTicks(8943), "Aniya2@hotmail.com", "Viviane56", "reDr6lm9OSxPE8KZ32k8WMt4HIJaHhoG9FT4u5oavPw=", 1, "uB4o9lwMfDiNffOennaBO3MZA2AVxqWXIC/BcX2o1FA=", new DateTime(2023, 4, 24, 14, 35, 32, 861, DateTimeKind.Local).AddTicks(8946) },
                    { 20, 20, new DateTime(2023, 4, 24, 14, 35, 32, 862, DateTimeKind.Local).AddTicks(9083), "Marjorie18@yahoo.com", "Cydney_Parker89", "z3MRfr8Pkd82J6dAX2J+jBbTHKM3kE2S3EI7Okcbbrs=", 0, "4EKjcb0LeJqiy3YOq2EvQQft4XjeemtcaSva6YtQLC8=", new DateTime(2023, 4, 24, 14, 35, 32, 862, DateTimeKind.Local).AddTicks(9086) }
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
