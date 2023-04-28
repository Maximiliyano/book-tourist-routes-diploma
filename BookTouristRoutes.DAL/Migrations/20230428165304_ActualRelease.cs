using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookTouristRoutes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ActualRelease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

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
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
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
                    { 1, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4175), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/969.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4215) },
                    { 2, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4255), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/421.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4258) },
                    { 3, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4267), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1212.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4269) },
                    { 4, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4276), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/970.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4278) },
                    { 5, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4285), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/514.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4287) },
                    { 6, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4294), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/592.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4296) },
                    { 7, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4304), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/150.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4306) },
                    { 8, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4314), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/53.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4315) },
                    { 9, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4323), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/231.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4325) },
                    { 10, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4332), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/432.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4334) },
                    { 11, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4341), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/123.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4343) },
                    { 12, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4350), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1091.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4352) },
                    { 13, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4359), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/511.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4361) },
                    { 14, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4369), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/650.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4371) },
                    { 15, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4378), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/731.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4380) },
                    { 16, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4388), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/268.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4389) },
                    { 17, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4420), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/775.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4422) },
                    { 18, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4430), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/997.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4432) },
                    { 19, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4439), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/348.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4441) },
                    { 20, new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4448), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/414.jpg", new DateTime(2023, 4, 28, 19, 53, 4, 384, DateTimeKind.Local).AddTicks(4449) },
                    { 21, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1318), "https://picsum.photos/640/480/?image=175", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1352) },
                    { 22, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1387), "https://picsum.photos/640/480/?image=1045", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1390) },
                    { 23, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1400), "https://picsum.photos/640/480/?image=287", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1401) },
                    { 24, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1410), "https://picsum.photos/640/480/?image=505", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1412) },
                    { 25, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1421), "https://picsum.photos/640/480/?image=852", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1422) },
                    { 26, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1431), "https://picsum.photos/640/480/?image=422", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1432) },
                    { 27, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1441), "https://picsum.photos/640/480/?image=673", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1443) },
                    { 28, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1451), "https://picsum.photos/640/480/?image=714", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1453) },
                    { 29, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1461), "https://picsum.photos/640/480/?image=146", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1463) },
                    { 30, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1470), "https://picsum.photos/640/480/?image=825", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1472) },
                    { 31, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1480), "https://picsum.photos/640/480/?image=637", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1482) },
                    { 32, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1489), "https://picsum.photos/640/480/?image=1054", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1491) },
                    { 33, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1522), "https://picsum.photos/640/480/?image=1067", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1524) },
                    { 34, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1533), "https://picsum.photos/640/480/?image=757", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1535) },
                    { 35, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1543), "https://picsum.photos/640/480/?image=691", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1544) },
                    { 36, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1552), "https://picsum.photos/640/480/?image=88", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1554) },
                    { 37, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1562), "https://picsum.photos/640/480/?image=860", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1563) },
                    { 38, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1571), "https://picsum.photos/640/480/?image=466", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1572) },
                    { 39, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1580), "https://picsum.photos/640/480/?image=434", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1582) },
                    { 40, new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1590), "https://picsum.photos/640/480/?image=806", new DateTime(2023, 4, 28, 19, 53, 4, 386, DateTimeKind.Local).AddTicks(1592) }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "BookedSeats", "CreatedAt", "Description", "Destination", "EndDate", "Name", "Price", "Seats", "StartDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(6658), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "West Norrisfort", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(7161), "New Dewittport", 6428.207681824902841m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(7123), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(6658) },
                    { 2, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8432), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Kamronport", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8511), "South Carleton", 6350.130278032564198m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8506), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8432) },
                    { 3, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8564), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "West Daphneeview", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8636), "Schinnerhaven", 7893.261257630721301m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8632), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8564) },
                    { 4, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8681), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "West Christaville", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8720), "Whiteside", 2996.348276955336049m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8717), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8681) },
                    { 5, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8786), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Champlinville", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8822), "Dickinsonport", 9491.057778056975515m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8819), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8786) },
                    { 6, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8897), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "East Tia", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8933), "Greenside", 6915.330577551414061m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8930), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8897) },
                    { 7, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8966), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Susannaland", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9031), "Lake Jordyfurt", 7818.695210549994418m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9028), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(8966) },
                    { 8, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9064), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Lake Amandaland", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9104), "New Joannybury", 5907.85310705725576m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9102), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9064) },
                    { 9, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9165), "The Football Is Good For Training And Recreational Purposes", "North Velmafort", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9200), "New Meda", 4556.595666817335547m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9198), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9165) },
                    { 10, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9260), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "North Violet", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9295), "Aileenview", 2016.874100393373583m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9292), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9260) },
                    { 11, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9326), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "North Andres", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9384), "Port Thaddeus", 3551.343009605448661m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9381), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9326) },
                    { 12, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9414), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "New Chadd", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9452), "East Albaberg", 8649.687400840372402m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9449), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9414) },
                    { 13, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9505), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "East Tad", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9547), "South Reeceborough", 1017.901206423088624m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9544), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9505) },
                    { 14, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9602), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Lake Anibal", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9636), "Jenkinsstad", 8344.059756794519086m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9634), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9602) },
                    { 15, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9665), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "North Jewellbury", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9720), "West Clair", 622.3363714832445622m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9718), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9665) },
                    { 16, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9758), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Lizziehaven", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9793), "Ravenshire", 6912.137088725254759m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9790), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9758) },
                    { 17, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9862), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "South Zack", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9894), "Schoenburgh", 5232.953230482067012m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9892), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9862) },
                    { 18, 0, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9925), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Port Brody", new DateTime(2023, 5, 3, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9985), "Marcelletown", 484.3754505454085299m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9982), new DateTime(2023, 4, 28, 19, 53, 4, 410, DateTimeKind.Local).AddTicks(9925) },
                    { 19, 0, new DateTime(2023, 4, 28, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(15), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "East Delaneyshire", new DateTime(2023, 5, 3, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(76), "South Chayashire", 3056.715550647183754m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(73), new DateTime(2023, 4, 28, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(15) },
                    { 20, 0, new DateTime(2023, 4, 28, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(113), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Oberbrunnerside", new DateTime(2023, 5, 3, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(145), "South Orlando", 470.6161373239435693m, 1, new DateTime(2023, 4, 28, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(143), new DateTime(2023, 4, 28, 19, 53, 4, 411, DateTimeKind.Local).AddTicks(113) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 4, 28, 19, 53, 4, 409, DateTimeKind.Local).AddTicks(982), "test@gmail.com", "testUser", "/Atrz9u4h/IH8/FGNMgPxL74qw/N4gBg9nnJGCQUsRU=", 0, "B77btj8BvaWXoFQsYsCvKGJNMKr9suAy+nPBK4lxtaI=", new DateTime(2023, 4, 28, 19, 53, 4, 409, DateTimeKind.Local).AddTicks(982) },
                    { 1, 18, new DateTime(2023, 4, 28, 19, 53, 4, 388, DateTimeKind.Local).AddTicks(8478), "Freddie.Langosh8@hotmail.com", "Dolly.Cummerata30", "TvwNxtZg7Jqb/JeS93S/L1kgqaE5UQ0oo/ZQIEKzB0U=", 0, "QGRv9+fnS4jzJooSUwhAdlm3W4TdLSYVmXEDdv6c79o=", new DateTime(2023, 4, 28, 19, 53, 4, 388, DateTimeKind.Local).AddTicks(8567) },
                    { 2, 20, new DateTime(2023, 4, 28, 19, 53, 4, 389, DateTimeKind.Local).AddTicks(8929), "Carolina64@gmail.com", "Allie82", "olexg6eK41XV4VuS84BwPWJJpEblzdpKeqYvyh99dQY=", 0, "TgCmniITFsmW8e6B6wccJXUUVNVOGeDBjD60zkeY7KM=", new DateTime(2023, 4, 28, 19, 53, 4, 389, DateTimeKind.Local).AddTicks(8936) },
                    { 3, 14, new DateTime(2023, 4, 28, 19, 53, 4, 390, DateTimeKind.Local).AddTicks(9233), "Newell.Dach@gmail.com", "Abel10", "+iY55BAoYTAbH/FvI4bitXw2x4KWBkiGToy9r56VHe4=", 1, "xNachfFQsOIL2Mg2BOa/a0KSUJMeI5MOhR26et6Onjw=", new DateTime(2023, 4, 28, 19, 53, 4, 390, DateTimeKind.Local).AddTicks(9239) },
                    { 4, 12, new DateTime(2023, 4, 28, 19, 53, 4, 391, DateTimeKind.Local).AddTicks(9308), "Loren96@yahoo.com", "Lyric10", "sNT6m0jkQQ8YBRkc02fJzS6QZXSbYXdJEfLC8ZnNT6Q=", 0, "lvdN6HHTXpRJ7nSehTm/jy4mhaU4NALXhBvoZNA+0jA=", new DateTime(2023, 4, 28, 19, 53, 4, 391, DateTimeKind.Local).AddTicks(9311) },
                    { 5, 5, new DateTime(2023, 4, 28, 19, 53, 4, 392, DateTimeKind.Local).AddTicks(9421), "Juliana.Connelly69@gmail.com", "Jewel42", "969KHjEp93aczx/TqrvzN14XvAR/jms6sw0ue9T5kAs=", 1, "c3BgTDYWPPVZ2b2y4POW0qbTGZ+bW+FrITP94FBn/lQ=", new DateTime(2023, 4, 28, 19, 53, 4, 392, DateTimeKind.Local).AddTicks(9425) },
                    { 6, 6, new DateTime(2023, 4, 28, 19, 53, 4, 393, DateTimeKind.Local).AddTicks(9541), "Mckenzie_Johnston12@gmail.com", "Amiya_Bednar83", "Z++OKOGTtmpJeJGZcBaUqtuqpuRjtFap6DTK/yW2qe0=", 1, "hO/TcFesmbrJoB8M5nZT6SuRju/bTyzMTTlWerIk4g4=", new DateTime(2023, 4, 28, 19, 53, 4, 393, DateTimeKind.Local).AddTicks(9545) },
                    { 7, 5, new DateTime(2023, 4, 28, 19, 53, 4, 394, DateTimeKind.Local).AddTicks(9772), "Kaylin71@yahoo.com", "Anahi_Kihn", "mw4mVfywWBVzRLPonHFzuK7irhWBjFcSbQs5jqV1YoI=", 1, "CBnWCGM6ZZhoM7a6iFa+CsbqIoBwOheb+PGHBNoRnPo=", new DateTime(2023, 4, 28, 19, 53, 4, 394, DateTimeKind.Local).AddTicks(9778) },
                    { 8, 4, new DateTime(2023, 4, 28, 19, 53, 4, 395, DateTimeKind.Local).AddTicks(9917), "Braden_Crooks60@gmail.com", "Art_Wiegand24", "iscvI8XzGgbuRk7XQ/VtZcKTOS5Oiizu+lEPYVya8bY=", 1, "28AQIePYkUbvN3DC6tteFXEGLsnF5KWbzbEcEHjFWd8=", new DateTime(2023, 4, 28, 19, 53, 4, 395, DateTimeKind.Local).AddTicks(9921) },
                    { 9, 5, new DateTime(2023, 4, 28, 19, 53, 4, 397, DateTimeKind.Local).AddTicks(50), "Benton_Thiel64@gmail.com", "Lance20", "UoORWhB6+0NclyRW4iCJ2VMnQJYTZHUTrX1CSnB5Frs=", 1, "jjcZnlMQtsjpbVgxgyzMI74uTF7WiShY5RUi/PwaE3c=", new DateTime(2023, 4, 28, 19, 53, 4, 397, DateTimeKind.Local).AddTicks(54) },
                    { 10, 7, new DateTime(2023, 4, 28, 19, 53, 4, 398, DateTimeKind.Local).AddTicks(124), "Anibal_Kihn@yahoo.com", "Anna.Crist", "6DjgThOx8hdfdunZJthftEPTWhEgDKvT6uRFq7yFUSk=", 1, "vd+zF82USTYovXwfCX+Qx4MO8d4GX9JESERvynThri4=", new DateTime(2023, 4, 28, 19, 53, 4, 398, DateTimeKind.Local).AddTicks(128) },
                    { 11, 5, new DateTime(2023, 4, 28, 19, 53, 4, 399, DateTimeKind.Local).AddTicks(155), "Brady_Morissette@gmail.com", "Maximillia54", "8C4rMkmchXRRJeAfQEbGmNTCOKIJzfdwXK3d6oL9/tA=", 0, "gQ8b5YwT5v7f6k81ygYlrbnkZ+xOWqlZCgqOIUSCxjY=", new DateTime(2023, 4, 28, 19, 53, 4, 399, DateTimeKind.Local).AddTicks(159) },
                    { 12, 4, new DateTime(2023, 4, 28, 19, 53, 4, 400, DateTimeKind.Local).AddTicks(307), "Constantin.Marks73@gmail.com", "Della.Powlowski", "Dg3fkf6+4EJ9SqdPM0ZyjjqNLQ1iqf0JpGO2CN75xcg=", 0, "5p1ujs6PZbJr+ViJhBfXUtX7r7a5crJbKHiVVi4Ocd4=", new DateTime(2023, 4, 28, 19, 53, 4, 400, DateTimeKind.Local).AddTicks(311) },
                    { 13, 11, new DateTime(2023, 4, 28, 19, 53, 4, 401, DateTimeKind.Local).AddTicks(402), "Wiley_Borer19@hotmail.com", "Kenyon63", "DE6/dhsMlbb96hW9hGAc6m61p941ASjlDcFT3XoawSw=", 1, "auLfSssY/cUEJ/1458A4L+IiHN6W0YLq2GT3I5LAcp0=", new DateTime(2023, 4, 28, 19, 53, 4, 401, DateTimeKind.Local).AddTicks(406) },
                    { 14, 9, new DateTime(2023, 4, 28, 19, 53, 4, 402, DateTimeKind.Local).AddTicks(444), "Narciso39@yahoo.com", "Emilie.Block33", "ZapHgy2xilXrMF1A3cwW21uTlZVPcdZerWF1/kwcZ3Q=", 1, "Q1LO92cPsik+HoOEeSxeO/SKmj0hHUZCiHcdiAvchB4=", new DateTime(2023, 4, 28, 19, 53, 4, 402, DateTimeKind.Local).AddTicks(447) },
                    { 15, 20, new DateTime(2023, 4, 28, 19, 53, 4, 403, DateTimeKind.Local).AddTicks(563), "Rickie.Kling69@gmail.com", "Danny88", "kxXhYJeXRF15vAAfQU/VUqEsTrX18Y28al/B9UYtXg0=", 1, "zhh+lfFOYQ480+SXNRJYQBE/kNnH4ZYfJ1R6sFPPmhM=", new DateTime(2023, 4, 28, 19, 53, 4, 403, DateTimeKind.Local).AddTicks(567) },
                    { 16, 18, new DateTime(2023, 4, 28, 19, 53, 4, 404, DateTimeKind.Local).AddTicks(619), "Unique.Herzog@hotmail.com", "Murl30", "+c9eIH8SafqNdbzzQrN0Pkzpxk9FZhz/uYPEeTwZU+8=", 0, "9Eg2wrYhX/yqZHSPsmiY3GXRize9Lh7GUmTM2USFC7Y=", new DateTime(2023, 4, 28, 19, 53, 4, 404, DateTimeKind.Local).AddTicks(623) },
                    { 17, 18, new DateTime(2023, 4, 28, 19, 53, 4, 405, DateTimeKind.Local).AddTicks(666), "Arden94@yahoo.com", "Valentin_Jacobs", "og2wptUGl5n/9IOatJAzlrmGMUBKPg1IK5QSxVsGcYE=", 1, "jcbuloy4J07MHukq1wbpYIXULibJV813lDcCPFBSYJ0=", new DateTime(2023, 4, 28, 19, 53, 4, 405, DateTimeKind.Local).AddTicks(670) },
                    { 18, 12, new DateTime(2023, 4, 28, 19, 53, 4, 406, DateTimeKind.Local).AddTicks(819), "Judd4@yahoo.com", "Gertrude28", "8PEVtsQ19DmdWcWvXIsCtsqNcdfE/YcTLFDhIGRlo9o=", 1, "JbtAwOwnLxNHNTK/i9U1R5f2DK4TEnSa0J2YYeNfP/8=", new DateTime(2023, 4, 28, 19, 53, 4, 406, DateTimeKind.Local).AddTicks(823) },
                    { 19, 14, new DateTime(2023, 4, 28, 19, 53, 4, 407, DateTimeKind.Local).AddTicks(885), "Drew_Spencer@hotmail.com", "Euna50", "8LTAz32Smk4R0/vhzMpRAD814lVDl3ZTDTwBi9adwkY=", 0, "D/8lWogXPBy1nMfsscXi4Nq1bM/CbABbaYFSKEhc91A=", new DateTime(2023, 4, 28, 19, 53, 4, 407, DateTimeKind.Local).AddTicks(888) },
                    { 20, 16, new DateTime(2023, 4, 28, 19, 53, 4, 408, DateTimeKind.Local).AddTicks(966), "Murphy95@yahoo.com", "Penelope.Fay16", "5SH+qZCjPxl/+G8hymS1KNJ6904FCzF6K5Pw7bBPcsI=", 0, "jvpN/K5+UGmxNZzd/8bGk8yO7OHossBZY4BJz6jGcSI=", new DateTime(2023, 4, 28, 19, 53, 4, 408, DateTimeKind.Local).AddTicks(970) }
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
                name: "Bookings");

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
