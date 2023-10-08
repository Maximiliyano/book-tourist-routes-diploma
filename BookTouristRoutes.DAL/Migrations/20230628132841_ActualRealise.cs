using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookTouristRoutes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ActualRealise : Migration
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
                    WorldPart = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    BookedSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
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
                table: "Bookings",
                columns: new[] { "Id", "CreatedAt", "EndDate", "Price", "RouteId", "StartDate", "Status", "Uid", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 3225.915904965909121m, 19, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("8041dd45-326f-4fe5-be18-c722d62f6a12"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 14 },
                    { 2, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 3799.753441937802667m, 18, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("a3555525-b971-47df-8a3b-6249809427a4"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 12 },
                    { 3, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 5050.918459210723912m, 14, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("bdfeaba7-aed1-45b4-b562-8732d1560f79"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 6 },
                    { 4, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 2323.793203511773762m, 3, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("d50dae0d-5a72-41a8-a975-0b6462845f2c"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 10 },
                    { 5, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 1982.379046387579201m, 5, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("84a2e29e-bf3e-4e92-a974-88340edc8937"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 6 },
                    { 6, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 2902.155878840165749m, 19, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("ab4c3218-f24d-42a9-9683-455b446e6741"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 15 },
                    { 7, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 6138.300858937989697m, 16, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 2, new Guid("7e0805c2-3bec-470b-a3db-f000311ff435"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 18 },
                    { 8, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 5820.951864779312887m, 17, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("866b539f-77d4-45dd-adfb-3c8d0f25d449"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 19 },
                    { 9, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 1233.021896645464342m, 2, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("e22a777f-92ce-434e-b920-4b66a55fa4a3"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 19 },
                    { 10, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 649.7850207469502476m, 13, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("1908bf90-47b5-46aa-8724-0b164c45132b"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 20 },
                    { 11, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 2160.32909473557595m, 17, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 2, new Guid("a9e2b150-e8dd-4522-86ed-6e8699c321f6"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 4 },
                    { 12, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 3430.076648067857314m, 2, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("878cf889-02f3-4407-9c5e-045b07a52d95"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 13 },
                    { 13, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 6971.807092516425928m, 11, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("d515918a-0b83-4196-91fd-d84e3af6803e"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 11 },
                    { 14, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 911.6175251814768919m, 17, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("320b5aee-e60c-47fb-aae7-e8ca4b92db03"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 5 },
                    { 15, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 7331.156534602953469m, 5, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 2, new Guid("b1e5976e-0d36-4ce1-9f99-c2608a2ad277"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 16 },
                    { 16, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 7228.302937818320764m, 12, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("138d69b6-130b-4f05-8e47-67f64ec47499"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 19 },
                    { 17, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 4782.67658261789023m, 8, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("b1689f59-84e2-42f5-8ac3-0ab1abdbc6d9"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 13 },
                    { 18, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 6007.162513717786321m, 10, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 2, new Guid("66554133-c5e3-4530-b477-9f29626eeea7"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 11 },
                    { 19, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 2452.73886319413997m, 17, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("03ae72e9-f291-42d0-ab40-89869e02a42d"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 11 },
                    { 20, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 4112.386889067762535m, 3, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("5da4ed90-2a90-49ea-b8df-38252f48770a"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 16 },
                    { 21, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 8713.673775662692429m, 12, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("1e2608db-bf2e-4b03-bdbe-53cc70628349"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 20 },
                    { 22, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 9398.096710430251834m, 13, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("102ca7a5-fa33-4d95-9041-f6eb4d7f9ca6"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 21 },
                    { 23, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 3198.977245523866861m, 10, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("688c45a5-0a32-4d2b-80b0-5ecf77751e87"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 1 },
                    { 24, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 4276.365801087437452m, 8, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("8903076d-6110-4038-8626-38d64544b070"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 14 },
                    { 25, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 8276.876941032910594m, 3, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("b32e80ca-6b4d-44c0-9201-cbdeadd1c65f"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 8 },
                    { 26, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 6376.431125775665107m, 10, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("b38ebeee-8f65-4d46-834a-fc42745d11eb"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 9 },
                    { 27, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 1075.811228126120188m, 9, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("687f519b-a76a-45cc-bfb3-1eaefd241f9f"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 8 },
                    { 28, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 8566.381968355888489m, 17, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("4a8f958c-0691-4261-bc3f-366902751b03"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 2 },
                    { 29, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 4154.90910409504513m, 5, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 2, new Guid("2c8931d1-3ef5-4297-8eb8-285b2363a032"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 6 },
                    { 30, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 8045.343836010375454m, 5, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("7f6b4272-8d4b-48c7-8698-6eab45261550"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 2 },
                    { 31, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 7550.56281975194629m, 14, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("31dbbc8e-3288-47a9-95bb-c3398ada7241"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 14 },
                    { 32, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 948.748537444082374m, 9, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("8606e4e1-53c4-4846-a522-6b50efe6457a"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 9 },
                    { 33, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 2248.128823542460165m, 5, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("85d76f65-5cef-4b55-8d5b-759d7d064c1c"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 21 },
                    { 34, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 3990.072381205846132m, 5, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("beaf4a15-00bd-4545-b84e-6cbd9cbde540"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 9 },
                    { 35, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 7062.538153312834939m, 15, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("0f28a0da-04d6-482c-9e03-a594d130d74e"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 17 },
                    { 36, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 1394.704124927692138m, 4, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("cdf611ad-119c-4521-b185-28314f25586d"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 20 },
                    { 37, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 2819.586031732897525m, 3, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("69d1da99-2c1a-4c30-8e74-3fa0753cef69"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 19 },
                    { 38, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 6790.544715825960022m, 3, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 3, new Guid("a37b2ecd-0bbd-41fb-bccf-883dcc47b76d"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 1 },
                    { 39, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 3323.573358402863224m, 20, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 1, new Guid("d7d23d27-f94b-4985-a719-2b760a867187"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 10 },
                    { 40, new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2796), new DateTime(2023, 7, 4, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2893), 6856.641945542120005m, 16, new DateTime(2023, 7, 1, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2872), 0, new Guid("49a98f14-282e-4196-8021-c6285dbbd9b6"), new DateTime(2023, 6, 28, 16, 28, 41, 829, DateTimeKind.Local).AddTicks(2852), 14 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedAt", "URL", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/585.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 2, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/452.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 3, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1213.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 4, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/916.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 5, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/535.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 6, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/111.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 7, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/536.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 8, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/565.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 9, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/287.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 10, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1120.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 11, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/215.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 12, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/729.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 13, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/134.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 14, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/784.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 15, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1165.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 16, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/619.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 17, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1204.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 18, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/672.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 19, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/564.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 20, new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7298), "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/334.jpg", new DateTime(2023, 6, 28, 16, 28, 41, 802, DateTimeKind.Local).AddTicks(7366) },
                    { 21, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8666), "https://picsum.photos/640/480/?image=1029", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8693) },
                    { 22, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8726), "https://picsum.photos/640/480/?image=13", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8728) },
                    { 23, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8738), "https://picsum.photos/640/480/?image=643", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8740) },
                    { 24, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8748), "https://picsum.photos/640/480/?image=373", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8750) },
                    { 25, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8759), "https://picsum.photos/640/480/?image=967", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8761) },
                    { 26, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8770), "https://picsum.photos/640/480/?image=804", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8772) },
                    { 27, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8781), "https://picsum.photos/640/480/?image=972", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8782) },
                    { 28, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8790), "https://picsum.photos/640/480/?image=707", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8792) },
                    { 29, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8800), "https://picsum.photos/640/480/?image=605", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8801) },
                    { 30, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8809), "https://picsum.photos/640/480/?image=855", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8811) },
                    { 31, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8819), "https://picsum.photos/640/480/?image=552", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8821) },
                    { 32, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8828), "https://picsum.photos/640/480/?image=208", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8830) },
                    { 33, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8838), "https://picsum.photos/640/480/?image=688", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8840) },
                    { 34, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8873), "https://picsum.photos/640/480/?image=563", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8875) },
                    { 35, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8885), "https://picsum.photos/640/480/?image=647", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8887) },
                    { 36, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8896), "https://picsum.photos/640/480/?image=649", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8897) },
                    { 37, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8905), "https://picsum.photos/640/480/?image=792", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8907) },
                    { 38, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8916), "https://picsum.photos/640/480/?image=705", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8918) },
                    { 39, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8927), "https://picsum.photos/640/480/?image=937", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8929) },
                    { 40, new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8937), "https://picsum.photos/640/480/?image=568", new DateTime(2023, 6, 28, 16, 28, 41, 803, DateTimeKind.Local).AddTicks(8939) }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "BookedSeats", "CreatedAt", "Description", "Destination", "EndDate", "ImageId", "Name", "Price", "Seats", "StartDate", "UpdatedAt", "WorldPart" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(6085), "The Football Is Good For Training And Recreational Purposes", "West Wilhelmine", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "West Helenberg", 9119.424504872338381m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(6085), 1 },
                    { 2, 0, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8190), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "East Edd", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "East Madisynborough", 9354.652541659973998m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8190), 1 },
                    { 3, 2, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8452), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "North Kattieside", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "West Rogerfort", 8319.400532080707376m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8452), 4 },
                    { 4, 2, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8549), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "West Jessicaburgh", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Filomenaburgh", 160.9513386705315928m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8549), 0 },
                    { 5, 7, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8654), "The Football Is Good For Training And Recreational Purposes", "South Rosaleemouth", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Lake Natalia", 6535.338318359595865m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8654), 5 },
                    { 6, 5, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8781), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Muellerstad", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "West Misty", 8418.01678241167315m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8781), 0 },
                    { 7, 4, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8881), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "West Elainafurt", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Denesikfort", 8962.501200904915102m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8881), 5 },
                    { 8, 0, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8978), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Runolfssonville", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Murrayhaven", 7168.063588116524686m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(8978), 5 },
                    { 9, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9046), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Rempelville", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "North Staceyport", 1836.098609633795242m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9046), 1 },
                    { 10, 7, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9145), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Kathrynmouth", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Brandyland", 2222.898750037696609m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9145), 4 },
                    { 11, 0, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9236), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Schowalterport", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Tobyfort", 2865.749937736241962m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9236), 1 },
                    { 12, 2, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9322), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kutchton", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Nestorfurt", 9490.314123582540247m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9322), 5 },
                    { 13, 1, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9387), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "North Justinaview", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Alexishaven", 3774.662813063301499m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9387), 1 },
                    { 14, 6, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9481), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Hudsonmouth", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "South Damian", 5630.641859890502146m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9481), 6 },
                    { 15, 3, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9573), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Port Roman", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "East Jaymeburgh", 9742.674930471320914m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9573), 5 },
                    { 16, 3, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9677), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Lake Deven", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Tillmanton", 6069.087188977211695m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9677), 2 },
                    { 17, 5, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9749), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Lake Brenden", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "East Stevieville", 7608.580037655275755m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9749), 1 },
                    { 18, 0, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9844), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Shemarside", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Federicoshire", 7753.012657947235909m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9844), 4 },
                    { 19, 6, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9933), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Port Pattiemouth", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "East Sunnychester", 405.9615764706711661m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(9933), 4 },
                    { 20, 3, new DateTime(2023, 6, 28, 16, 28, 41, 828, DateTimeKind.Local).AddTicks(34), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Gorczanyville", new DateTime(2023, 7, 3, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5905), null, "Port Laron", 3689.840111755614112m, 8, new DateTime(2023, 6, 28, 16, 28, 41, 827, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 16, 28, 41, 828, DateTimeKind.Local).AddTicks(34), 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "CreatedAt", "Email", "Name", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 6, 28, 16, 28, 41, 826, DateTimeKind.Local).AddTicks(3215), "test@gmail.com", "testUser", "wDqQIBu4Z0QrV4tYF1pLUgU6igqsX0ZW1zBzv6QjSNE=", 0, "abErlRdw2M2TIU+QyS+EK6a8V6W9t8VaT5/Yzu8ZaJk=", new DateTime(2023, 6, 28, 16, 28, 41, 826, DateTimeKind.Local).AddTicks(3215) },
                    { 1, 13, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Christ.Bernhard42@yahoo.com", "Molly30", "4UMbOMGfgJF4C/lOBYKFDk2seyfadwGNr1J9iOsuKQA=", 0, "IjawwImTImk1JGiMwu4TpXO4YEWuVF8MGZXjdskEZb4=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 2, 17, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Stephanie_Mueller@gmail.com", "Izabella91", "KgdFyDAihQTe6jZNpsdcqt2Rw7iUa+dB7KoPkyB1jxI=", 1, "9G4mdfRrAsDXP6XN1u1TMS/dW6EZDMAV4/J/+YC9Nss=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 3, 2, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Margot_Brown17@gmail.com", "Maryse.Keebler", "JbCP8laayzG7jrnqvSyX+rIlLUd1IJYv32Qbb5Yc1jE=", 0, "YMJhqNeVGUrTAME9m32Bs6Oj4TDYKt57MjQi+BU117Y=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 4, 12, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Jordyn_Block@hotmail.com", "Carissa46", "Oed22MyEDrtLUCfGBU3KTpE8djcHIKW6DqYzI5iUchI=", 1, "gvh1l7mjW0jnCTG46hf2EJMbzOXckWtv8OXum68sVVg=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 5, 8, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Seth20@yahoo.com", "Adele62", "h58yE0gpv/LLIHmfuyx7JFfcFsQ84jHNbVr30FmpNWY=", 1, "5PeRq27Mkb8Yvc6BG06NMwYCj5E8st1yEqg+lOIa12U=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 6, 14, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Minnie15@yahoo.com", "Jerrell_Bradtke39", "E6TRFhMsFpAnTBoPS4o8LSk/ejAn49GMApL4ePiJiac=", 1, "b9l5tKBuQuL3Q1s271EWaJhDjBadmcz11Xn7ETUsoLM=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 7, 16, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Jaden.Connelly@gmail.com", "Dedrick.Veum2", "+1Rrvy+Q9NBcwW8YkGOUgscy7EZ3iBXpbIThEIxQM4Y=", 0, "inHp7bqsi7qxt3IejJy8IskOwXW62rZZewua7AIXk1w=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 8, 15, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Estell_Legros99@hotmail.com", "Roosevelt_Bradtke", "T2wrcbZiX//wgQEmUEMr+piYjhxZ2xyY30UYnz4LqJI=", 0, "lrdo4lnLjJBoEQiuxPMiz0bONnT85Rs1IPPR8Qztl2M=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 9, 12, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Ashleigh.DuBuque@gmail.com", "Bernita.Rau3", "vdQYh3ihUYVHxGIuByu6ckgnD3dMafW1FtNtY67Gyy0=", 0, "fnOLvn0zxwyaylw5zQiLAKLGyCfVJGnF/Xj1C56J/sI=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 10, 12, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Suzanne_Fritsch61@hotmail.com", "Haskell87", "yKV53IW9Fajab9Ynb/0jk6dH/0w+tbNF8w5N95pqh00=", 1, "FCAZKJnpIyOTacLkVjjt1GUd8pTPjAh2tSjna1LegGg=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 11, 3, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Britney3@hotmail.com", "Gladys_Mohr53", "duuvTyUR7LOPESd4+V2+0XHddmd2NZU1E4KaZEWeXRk=", 0, "tr8sUEcvQdA+Z2g//L/Pli/3NBs+M1cJu8okOnXXD9k=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 12, 16, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Eldred43@hotmail.com", "Reinhold.Funk", "H7HB/djmtlkvJlMc5EDfX0JCfqLk6qm/zoJpFByornI=", 1, "5lFbp2geXyzLIgpJHe/OFCj17BA80IUBcIZCwCzJ9u4=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 13, 14, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Helene22@hotmail.com", "Adelle59", "6gMGpzhUZ5P7zpGEQtD+Xs2AamXH/6k5A/seaKWXAuw=", 0, "RI8X61UNlSfgiFdQtMSkupoNFWxHrljQFdsHJ358Ht4=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 14, 8, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Rahul30@gmail.com", "Noel.Rodriguez", "BxoHVrmUOmZPqodF621wR1WKGH6vAEy6HZMo9ONWG7I=", 0, "t650A+fOZojFNG9TE7ap05l1GoIzYpR4L2oqN0Yx1AM=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 15, 9, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Terence17@yahoo.com", "Jaunita.Schulist11", "C7hbIJJ60Jbr05NXqfHiCxaXgv53ZhncNal7eCMtsvk=", 1, "Sa4LkKCG5/BLVqdM0ey9gq/E7sE/M7Draa6aAbX3UZw=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 16, 20, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Kaleb_Schroeder@yahoo.com", "Hoyt.White", "5VNiIiOrT3gscc0uzFBUj6v8C0qMwNTanFIKE9+S42o=", 0, "zEYpgxX/naPF3YWxHvTJvryeTVht5pLA41Fuz6zL/XY=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 17, 11, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Francisco87@gmail.com", "Pearline_Feil", "D+5fBiJKx269WwJuPLp4fLzeoIi8gs6L1NPZRx6Fusc=", 0, "4Lz6lh7ohCwdemOLCLi2mQfIkxuNWP/L8AbFfHNzsGo=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 18, 20, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Rae_Hammes45@hotmail.com", "Abdul.VonRueden", "CzLq0ykI34Fk0ZmXLIP/CSOTr26GOCyydrvQBlE+Q1Q=", 1, "w5gLn7qEUsqOVRBO1fugIRIdrQl1F+S5yd8YLJpo8EQ=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 19, 13, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Paxton.Collier67@yahoo.com", "Ernestine23", "0d1yUy6X176wQ1f9VdGMVuf8ctQj/0tuOqvWp9XCx+4=", 1, "ptUpPggOZSibPDPnmwX6Vv0L1wRfMduSY8BxdYjx85M=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) },
                    { 20, 7, new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9625), "Nestor_Jacobi@yahoo.com", "Elwyn_Kuhn", "2ykeEuVlHTovQmO9IBX8OzUMgC9HLTjdJ0YAPEPgc/E=", 1, "rPQ19CJlcAEp4rDSsaCnXwe1rNBwrGOke022N+GDK6E=", new DateTime(2023, 6, 28, 16, 28, 41, 804, DateTimeKind.Local).AddTicks(9656) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ImageId",
                table: "Routes",
                column: "ImageId");

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
