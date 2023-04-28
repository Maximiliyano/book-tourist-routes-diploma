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
                    { 1, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8094), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/618.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8135) },
                    { 2, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8173), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/187.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8176) },
                    { 3, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8186), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/751.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8188) },
                    { 4, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8197), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/84.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8199) },
                    { 5, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8207), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/305.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8209) },
                    { 6, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8216), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/749.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8218) },
                    { 7, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8265), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1186.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8267) },
                    { 8, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8276), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/585.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8278) },
                    { 9, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8285), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/240.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8287) },
                    { 10, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8295), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/998.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8297) },
                    { 11, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8305), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/206.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8307) },
                    { 12, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8314), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1154.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8316) },
                    { 13, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8323), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/927.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8325) },
                    { 14, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8332), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/894.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8334) },
                    { 15, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8341), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1082.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8343) },
                    { 16, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8350), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1212.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8352) },
                    { 17, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8360), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1126.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8362) },
                    { 18, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8368), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1171.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8370) },
                    { 19, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8377), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1164.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8379) },
                    { 20, new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8387), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/937.jpg", new DateTime(2023, 4, 28, 15, 58, 29, 317, DateTimeKind.Local).AddTicks(8388) },
                    { 21, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7203), "https://picsum.photos/640/480/?image=271", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7240) },
                    { 22, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7275), "https://picsum.photos/640/480/?image=224", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7278) },
                    { 23, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7287), "https://picsum.photos/640/480/?image=989", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7289) },
                    { 24, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7299), "https://picsum.photos/640/480/?image=999", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7301) },
                    { 25, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7309), "https://picsum.photos/640/480/?image=391", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7311) },
                    { 26, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7362), "https://picsum.photos/640/480/?image=397", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7364) },
                    { 27, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7374), "https://picsum.photos/640/480/?image=638", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7376) },
                    { 28, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7384), "https://picsum.photos/640/480/?image=290", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7386) },
                    { 29, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7394), "https://picsum.photos/640/480/?image=497", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7396) },
                    { 30, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7405), "https://picsum.photos/640/480/?image=280", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7406) },
                    { 31, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7415), "https://picsum.photos/640/480/?image=39", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7417) },
                    { 32, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7425), "https://picsum.photos/640/480/?image=335", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7426) },
                    { 33, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7435), "https://picsum.photos/640/480/?image=323", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7437) },
                    { 34, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7444), "https://picsum.photos/640/480/?image=289", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7446) },
                    { 35, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7453), "https://picsum.photos/640/480/?image=223", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7455) },
                    { 36, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7463), "https://picsum.photos/640/480/?image=259", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7465) },
                    { 37, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7473), "https://picsum.photos/640/480/?image=726", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7474) },
                    { 38, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7482), "https://picsum.photos/640/480/?image=616", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7484) },
                    { 39, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7492), "https://picsum.photos/640/480/?image=950", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7494) },
                    { 40, new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7502), "https://picsum.photos/640/480/?image=422", new DateTime(2023, 4, 28, 15, 58, 29, 319, DateTimeKind.Local).AddTicks(7504) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 4, 28, 15, 58, 29, 342, DateTimeKind.Local).AddTicks(8194), "test@gmail.com", "testUser", "HGU0aoEkyLsXkVAMunuaAgC9IlAt9ZX5i05BxfPwhx4=", 0, "4mYxRrqkL+jn5koJRSmemVdKJd9XsuLYURby0nmWgUw=", new DateTime(2023, 4, 28, 15, 58, 29, 342, DateTimeKind.Local).AddTicks(8194) },
                    { 1, 10, new DateTime(2023, 4, 28, 15, 58, 29, 322, DateTimeKind.Local).AddTicks(5490), "Giovanni.Harvey@hotmail.com", "Donato.Gottlieb61", "NyDoVvpfN0ZjJEdEaCDsEgWtakEnWB0NX0om4FkAkng=", 0, "Vv1lN1+FkIGYeoMCuudY8U+ciqCkitKsmxcb+c0aXh4=", new DateTime(2023, 4, 28, 15, 58, 29, 322, DateTimeKind.Local).AddTicks(5585) },
                    { 2, 10, new DateTime(2023, 4, 28, 15, 58, 29, 323, DateTimeKind.Local).AddTicks(6000), "Zena.Leffler65@yahoo.com", "Geovany.Kozey34", "m75Cn78W2EuTo2VcxBZOdo3EsOoxnZzBhhgpXVwmujA=", 0, "aTBCorWSgINAT9AxMuevMGp+lOelDFLLDZ2jwSvcw0c=", new DateTime(2023, 4, 28, 15, 58, 29, 323, DateTimeKind.Local).AddTicks(6006) },
                    { 3, 19, new DateTime(2023, 4, 28, 15, 58, 29, 324, DateTimeKind.Local).AddTicks(6223), "Joanny.Ondricka78@hotmail.com", "Destinee42", "4gCjzODKM3QTitybAH0e8IS/0wpBZccztvByhRZshEs=", 1, "lYVcokL0R9gVowCGERMlQ8a/1kxpnypIC0RETJdnIq0=", new DateTime(2023, 4, 28, 15, 58, 29, 324, DateTimeKind.Local).AddTicks(6228) },
                    { 4, 15, new DateTime(2023, 4, 28, 15, 58, 29, 325, DateTimeKind.Local).AddTicks(6433), "Allen_Okuneva@gmail.com", "Lempi.Oberbrunner67", "1Qc0Tu068NnVlDOtiJSuqGxrhXRyZelN0UbiCrd/b18=", 1, "fgpO7a094mY75ceOoEq3DeqXgNi/69cz4lStfVCHpFU=", new DateTime(2023, 4, 28, 15, 58, 29, 325, DateTimeKind.Local).AddTicks(6438) },
                    { 5, 12, new DateTime(2023, 4, 28, 15, 58, 29, 326, DateTimeKind.Local).AddTicks(6485), "Shaniya72@gmail.com", "Trenton_Blanda", "jPF8mqCH/DROuuQ5hMsTnI4jSf8PW7xz8ttWXtiuyOo=", 0, "q4psaw1LPl/IagWoEJrm/TCFmFtuPExYWXK13SLS2r8=", new DateTime(2023, 4, 28, 15, 58, 29, 326, DateTimeKind.Local).AddTicks(6490) },
                    { 6, 2, new DateTime(2023, 4, 28, 15, 58, 29, 327, DateTimeKind.Local).AddTicks(6533), "Emmanuel99@gmail.com", "Wilton54", "aG26X+BMjNG8y6ZvAGeIPMtN//Zj6llejpTjYKKiOsc=", 1, "lMObkZSLma21hU26MzhK6jKN0rx3LMxMr3CEIMeOWO4=", new DateTime(2023, 4, 28, 15, 58, 29, 327, DateTimeKind.Local).AddTicks(6536) },
                    { 7, 18, new DateTime(2023, 4, 28, 15, 58, 29, 328, DateTimeKind.Local).AddTicks(6638), "Krista28@yahoo.com", "Joannie.Ondricka14", "yWb2/ZzukMYIcxEqzaO+VyElmAQDOauCtgKfoG6Sr+0=", 1, "t+Vs8MfEq0D1RxPTxxYgxlstcyMDA6MsIw2Asra+r8c=", new DateTime(2023, 4, 28, 15, 58, 29, 328, DateTimeKind.Local).AddTicks(6642) },
                    { 8, 7, new DateTime(2023, 4, 28, 15, 58, 29, 329, DateTimeKind.Local).AddTicks(6828), "Reynold_Wisozk29@gmail.com", "Maye_Zieme41", "roO7M0r8/N8R+hQkeZbka52SRkbHfcke+npAumKJOmY=", 1, "bhR0aMSWPbbRhuaTkpucUliVzAYthv607SJ55BBobCc=", new DateTime(2023, 4, 28, 15, 58, 29, 329, DateTimeKind.Local).AddTicks(6831) },
                    { 9, 8, new DateTime(2023, 4, 28, 15, 58, 29, 330, DateTimeKind.Local).AddTicks(6958), "Dennis.Nitzsche@gmail.com", "Zackary_Heller", "OsLSXR8maFsKMJrKF1JZGZln6o+Rvp/Eip7T+36jdYw=", 0, "3J4KXVNT2yjYMrwZjwG062WVWJnPyLXKuq3U63rW0p4=", new DateTime(2023, 4, 28, 15, 58, 29, 330, DateTimeKind.Local).AddTicks(6962) },
                    { 10, 15, new DateTime(2023, 4, 28, 15, 58, 29, 331, DateTimeKind.Local).AddTicks(7023), "Carmelo.Mitchell@yahoo.com", "Alphonso70", "EzNq1fXnVVEu29LZ1kbas1Vt+UR/kmrGL/8qjKn3v3E=", 0, "NYsXIfn2qaP0n8xKdvt0gPfbV7+/F5JKf/EF/9KRzqg=", new DateTime(2023, 4, 28, 15, 58, 29, 331, DateTimeKind.Local).AddTicks(7027) },
                    { 11, 17, new DateTime(2023, 4, 28, 15, 58, 29, 332, DateTimeKind.Local).AddTicks(7111), "Agustin.Stoltenberg@gmail.com", "Eldridge.Schmeler46", "FSmV/SiWWN9h4qeM5u9UBH2p2kH1T5kQmRb561D7ggo=", 0, "4iqhMqCGIjA25wpV6ZEdLyP8T+yZ+7yzrnLcu2Au9QI=", new DateTime(2023, 4, 28, 15, 58, 29, 332, DateTimeKind.Local).AddTicks(7115) },
                    { 12, 11, new DateTime(2023, 4, 28, 15, 58, 29, 333, DateTimeKind.Local).AddTicks(7424), "Rafael64@gmail.com", "Soledad71", "qhlvVuQQS5IizL4zkvec6ul970lhUfdFgpSXK9HtI6Y=", 0, "m3da7akovqKCD2gDvNFzhnpVXhl2mYzwxT8T53a1eTM=", new DateTime(2023, 4, 28, 15, 58, 29, 333, DateTimeKind.Local).AddTicks(7431) },
                    { 13, 14, new DateTime(2023, 4, 28, 15, 58, 29, 334, DateTimeKind.Local).AddTicks(7546), "Federico90@gmail.com", "Charlotte.Blanda", "lnuX5RdNg0M44GBsniuDd8aw2TqbdHGj5MwZ1bLuG7M=", 1, "ACnlY71+1RwmfsCdl6bqtQcokwt41uUBZU/8FHY3WHU=", new DateTime(2023, 4, 28, 15, 58, 29, 334, DateTimeKind.Local).AddTicks(7550) },
                    { 14, 18, new DateTime(2023, 4, 28, 15, 58, 29, 335, DateTimeKind.Local).AddTicks(7733), "Javon71@hotmail.com", "Laury_Mraz", "1YlBtUbUXU91/66zQ6qSy7h6Se+PATm/YOPsd+IvjY8=", 0, "Bt9IqouA9M1ede1D31h2yqbfXDPrPzxrbj+yehz0Ypo=", new DateTime(2023, 4, 28, 15, 58, 29, 335, DateTimeKind.Local).AddTicks(7739) },
                    { 15, 1, new DateTime(2023, 4, 28, 15, 58, 29, 336, DateTimeKind.Local).AddTicks(7796), "Kristoffer77@hotmail.com", "Judah.Rowe74", "RWcvf0/y/WN1YFtgeBZs4OW1NAy61CWIMRRjDoLv/yE=", 1, "lheO7k2temW1jhs4bMHRHpW5lB2wujqp6SWCgEhxdv8=", new DateTime(2023, 4, 28, 15, 58, 29, 336, DateTimeKind.Local).AddTicks(7801) },
                    { 16, 10, new DateTime(2023, 4, 28, 15, 58, 29, 337, DateTimeKind.Local).AddTicks(7887), "Kyle36@yahoo.com", "Emilie.Lind", "b9nkAmz6jhApROMZlFmOTAe2C5lRh0I0vWxZsvTiI3s=", 0, "899PkkM+6k77fZAFS1CRZHWRnqa8GJEBuABUbaqOfpE=", new DateTime(2023, 4, 28, 15, 58, 29, 337, DateTimeKind.Local).AddTicks(7891) },
                    { 17, 18, new DateTime(2023, 4, 28, 15, 58, 29, 338, DateTimeKind.Local).AddTicks(8023), "Santiago.Cummerata75@yahoo.com", "Zelda.Kemmer", "eg98aQfKsWa7qRmnzgnAsR1QJxCpBPopXiDptLsCcrc=", 0, "mNPWv5B8fvMC1/Jgl6GjIIiWw6F9UPFMI16YB0d4/gI=", new DateTime(2023, 4, 28, 15, 58, 29, 338, DateTimeKind.Local).AddTicks(8026) },
                    { 18, 4, new DateTime(2023, 4, 28, 15, 58, 29, 339, DateTimeKind.Local).AddTicks(8052), "Daren51@yahoo.com", "Rae_Wunsch36", "dbE0VF7ExE5d0w8cpzrYXUdSeily60Oa96wZ17ENVPU=", 0, "EUmVBexaMXvYVN42a5+9+5zdJW075fkSF+7gTb+LMkQ=", new DateTime(2023, 4, 28, 15, 58, 29, 339, DateTimeKind.Local).AddTicks(8055) },
                    { 19, 18, new DateTime(2023, 4, 28, 15, 58, 29, 340, DateTimeKind.Local).AddTicks(8102), "Bartholome_Leuschke50@yahoo.com", "Mckayla.Rosenbaum60", "gOuMtxk6JbG4Q9CzdxmgGZZivI+2CN+7yasyk0K4/5w=", 1, "k9wT8Ke2r51hX+0HDFPTzjEDSTTbuyp+z3EGBMVXR8o=", new DateTime(2023, 4, 28, 15, 58, 29, 340, DateTimeKind.Local).AddTicks(8106) },
                    { 20, 10, new DateTime(2023, 4, 28, 15, 58, 29, 341, DateTimeKind.Local).AddTicks(8195), "Cordia41@yahoo.com", "Jovan90", "IO9gwWoxfQjKYklVa4Q8nZRZhfVAHVslsCx0L4rjxDo=", 0, "lJc+Pw1ZpEFeuDahzYEGXi+LrZ6UC2d+03PPSGbncg0=", new DateTime(2023, 4, 28, 15, 58, 29, 341, DateTimeKind.Local).AddTicks(8198) }
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
