using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityLibraryDomain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BookTitle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstPublishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditionNumber = table.Column<short>(type: "INTEGER", nullable: false),
                    EditionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TitleType = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverType = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableCount = table.Column<short>(type: "INTEGER", nullable: false),
                    ReservedCount = table.Column<short>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ActiveBookReservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MemberId = table.Column<string>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveBookReservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_ActiveBookReservations_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveBookReservations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReservationHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RecievedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MemberId = table.Column<string>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReservationHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_BookReservationHistory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReservationHistory_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberRoles_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "UserName");
                    table.ForeignKey(
                        name: "FK_MemberRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "AvailableCount", "BookTitle", "CoverType", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EditionDate", "EditionNumber", "FirstPublishDate", "LastUpdatedAt", "LastUpdatedBy", "ReservedCount", "TitleType" },
                values: new object[,]
                {
                    { 1, "Friedrich Engels", (short)3, "Ailenin, Devletin ve Özel Mülkiyetin Kökeni", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(730), null, null, null, new DateTime(1903, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(720), (short)4, new DateTime(1885, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(720), null, null, (short)1, 7 },
                    { 2, "Ahmet Ümit", (short)4, "Beyoğlu Rapsodisi", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(730), null, null, null, new DateTime(2018, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(730), (short)4, new DateTime(2004, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(730), null, null, (short)2, 1 },
                    { 3, "Ahmet Ümit", (short)3, "Beyoğlu Rapsodisi", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(740), null, null, null, new DateTime(2013, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(730), (short)3, new DateTime(2004, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(730), null, null, (short)0, 1 },
                    { 4, "George Brinton Thomas", (short)500, "Thomas' Calculus", 0, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), null, null, null, new DateTime(2018, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(740), (short)13, new DateTime(1953, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(740), null, null, (short)0, 2 },
                    { 5, "George Brinton Thomas", (short)50, "Thomas' Calculus", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), null, null, null, new DateTime(2018, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), (short)13, new DateTime(1953, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), null, null, (short)0, 2 },
                    { 6, "Karl Marx & Friedrich Engels", (short)3, "Die Heilige Familie", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), null, null, null, new DateTime(1845, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), (short)1, new DateTime(1845, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(750), null, null, (short)1, 7 },
                    { 7, "Karl Marx & Friedrich Engels", (short)300, "Die Heilige Familie", 0, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(760), null, null, null, new DateTime(1845, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(760), (short)1, new DateTime(1845, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(760), null, null, (short)0, 7 },
                    { 8, "Julio Cortazar", (short)6, "Oyunun Sonu", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(760), null, null, null, new DateTime(2020, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(760), (short)2, new DateTime(1956, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(760), null, null, (short)0, 1 },
                    { 9, "Marjin Haverbeke", (short)2, "Eloquent Javascript", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(770), null, null, null, new DateTime(2018, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(770), (short)3, new DateTime(2017, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(770), null, null, (short)0, 5 },
                    { 10, "Marjin Haverbeke", (short)450, "Eloquent Javascript", 0, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(780), null, null, null, new DateTime(2018, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(770), (short)3, new DateTime(2017, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(770), null, null, (short)0, 5 },
                    { 11, "Zülfü Livaneli", (short)4, "Bir Kedi, Bir Adam, Bir Ölüm", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(780), null, null, null, new DateTime(2001, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(780), (short)1, new DateTime(2001, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(780), null, null, (short)1, 1 },
                    { 12, "Georges Politzer", (short)9, "Principes élémentaires de Philosophie", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(790), null, null, null, new DateTime(1945, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(780), (short)1, new DateTime(1945, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(780), null, null, (short)0, 7 },
                    { 13, "Georges Politzer", (short)350, "Principes élémentaires de Philosophie", 0, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(790), null, null, null, new DateTime(1945, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(790), (short)1, new DateTime(1945, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(790), null, null, (short)0, 7 },
                    { 14, "Ferdinand Pierre Beer & Elwood Russell Johnston Jr.", (short)3, "Mechanics of Materials", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(800), null, null, null, new DateTime(1981, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(790), (short)1, new DateTime(1981, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(790), null, null, (short)0, 3 },
                    { 15, "Ferdinand Pierre Beer & Elwood Russell Johnston Jr.", (short)300, "Mechanics of Materials", 0, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(800), null, null, null, new DateTime(1981, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(800), (short)1, new DateTime(1981, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(800), null, null, (short)0, 3 },
                    { 16, "Zülfü Livaneli", (short)11, "Kardeşimin Hikayesi", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(810), null, null, null, new DateTime(2013, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(810), (short)1, new DateTime(2013, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(810), null, null, (short)0, 1 },
                    { 17, "Pierre Louÿs", (short)1, "La Femme et le Pantin", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(820), null, null, null, new DateTime(1898, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(810), (short)1, new DateTime(1898, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(810), null, null, (short)0, 1 },
                    { 18, "Stephen King", (short)4, "Sadist", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(820), null, null, null, new DateTime(1995, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(820), (short)2, new DateTime(1987, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(820), null, null, (short)1, 1 },
                    { 19, "Yaşar Nuri Öztürk", (short)2, "Allah ile Aldatmak", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(830), null, null, null, new DateTime(2014, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(820), (short)1, new DateTime(2014, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(820), null, null, (short)0, 6 },
                    { 20, "Herbert George Wells", (short)1, "The Invisible Man", 1, new DateTime(2022, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(830), null, null, null, new DateTime(1897, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(830), (short)1, new DateTime(1897, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(830), null, null, (short)0, 6 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "UserName", "Address", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FullName", "LastUpdatedAt", "LastUpdatedBy", "Password" },
                values: new object[,]
                {
                    { "Admin", "Admin's Address", new DateTime(1993, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5750), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5830), null, null, null, "Admin", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User1", "Orhan's Address", new DateTime(1993, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5830), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5830), null, null, null, "Orhan", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User10", "Clara's Address", new DateTime(1953, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5880), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5880), null, null, null, "Clara", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User2", "Kaya's Address", new DateTime(1983, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5840), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5840), null, null, null, "Kaya", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User3", "Kadriye's Address", new DateTime(2003, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5840), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5840), null, null, null, "Kadriye", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User4", "Zuşer's Address", new DateTime(1993, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5840), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5850), null, null, null, "Zuşer", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User5", "Devran's Address", new DateTime(2001, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5850), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5850), null, null, null, "Devran", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User6", "Viladimir's Address", new DateTime(1968, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5850), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5860), null, null, null, "Viladimir", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User7", "Fidel's Address", new DateTime(1934, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5860), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5870), null, null, null, "Fidel", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User8", "Hasan's Address", new DateTime(1963, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5870), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5870), null, null, null, "Hasan", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." },
                    { "User9", "Behice's Address", new DateTime(1963, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5870), new DateTime(2022, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(5870), null, null, null, "Behice", null, null, "$2a$11$PPGxji8hhRUWqeNzNk437.Gp3m.tNyRihy3hHjbVLz6jvpnb42Zr." }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "LastUpdatedAt", "LastUpdatedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(6880), null, null, null, null, null, "Admin" },
                    { 2, new DateTime(2023, 1, 8, 14, 31, 59, 827, DateTimeKind.Local).AddTicks(6880), null, null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "ActiveBookReservations",
                columns: new[] { "ReservationId", "BookId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "LastUpdatedAt", "LastUpdatedBy", "MemberId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 8, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9890), null, null, null, null, null, "User2", new DateTime(2023, 1, 4, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9830) },
                    { 2, 2, new DateTime(2023, 1, 8, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9930), null, null, null, null, null, "User2", new DateTime(2023, 1, 6, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9920) },
                    { 3, 2, new DateTime(2023, 1, 8, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9930), null, null, null, null, null, "User1", new DateTime(2023, 1, 2, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9930) },
                    { 4, 11, new DateTime(2023, 1, 8, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9930), null, null, null, null, null, "User5", new DateTime(2023, 1, 3, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9930) },
                    { 5, 6, new DateTime(2023, 1, 8, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9940), null, null, null, null, null, "User5", new DateTime(2023, 1, 3, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9940) },
                    { 6, 6, new DateTime(2023, 1, 8, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9940), null, null, null, null, null, "User4", new DateTime(2023, 1, 3, 14, 31, 59, 618, DateTimeKind.Local).AddTicks(9940) }
                });

            migrationBuilder.InsertData(
                table: "BookReservationHistory",
                columns: new[] { "HistoryId", "BookId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "LastUpdatedAt", "LastUpdatedBy", "MemberId", "RecievedDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600), null, null, null, null, null, "User3", new DateTime(2022, 12, 19, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600), new DateTime(2022, 11, 29, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(590) },
                    { 2, 2, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600), null, null, null, null, null, "User3", new DateTime(2023, 1, 5, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600), new DateTime(2022, 12, 27, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600) },
                    { 3, 5, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610), null, null, null, null, null, "User1", new DateTime(2022, 12, 26, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600), new DateTime(2022, 12, 17, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(600) },
                    { 4, 5, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610), null, null, null, null, null, "User2", new DateTime(2022, 9, 30, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610), new DateTime(2022, 9, 10, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610) },
                    { 5, 5, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610), null, null, null, null, null, "User6", new DateTime(2022, 11, 29, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610), new DateTime(2022, 11, 22, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(610) },
                    { 6, 7, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620), null, null, null, null, null, "User7", new DateTime(2022, 12, 9, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620), new DateTime(2022, 12, 2, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620) },
                    { 7, 7, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620), null, null, null, null, null, "User9", new DateTime(2022, 12, 19, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620), new DateTime(2022, 12, 12, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620) },
                    { 8, 18, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(630), null, null, null, null, null, "User10", new DateTime(2022, 12, 29, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(630), new DateTime(2022, 12, 22, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(620) }
                });

            migrationBuilder.InsertData(
                table: "MemberRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "LastUpdatedAt", "LastUpdatedBy", "MemberId", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1280), null, null, null, null, null, "Admin", 1 },
                    { 2, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1280), null, null, null, null, null, "Admin", 2 },
                    { 3, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1330), null, null, null, null, null, "User1", 2 },
                    { 4, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1330), null, null, null, null, null, "User2", 2 },
                    { 5, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1330), null, null, null, null, null, "User3", 2 },
                    { 6, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1340), null, null, null, null, null, "User4", 2 },
                    { 7, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1340), null, null, null, null, null, "User5", 2 },
                    { 8, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1340), null, null, null, null, null, "User6", 2 },
                    { 9, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1340), null, null, null, null, null, "User7", 2 },
                    { 10, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1340), null, null, null, null, null, "User8", 2 },
                    { 11, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1350), null, null, null, null, null, "User9", 2 },
                    { 12, new DateTime(2023, 1, 8, 14, 31, 59, 619, DateTimeKind.Local).AddTicks(1350), null, null, null, null, null, "User10", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveBookReservations_BookId",
                table: "ActiveBookReservations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveBookReservations_MemberId",
                table: "ActiveBookReservations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservationHistory_BookId",
                table: "BookReservationHistory",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservationHistory_MemberId",
                table: "BookReservationHistory",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_MemberId",
                table: "MemberRoles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_RoleId",
                table: "MemberRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveBookReservations");

            migrationBuilder.DropTable(
                name: "BookReservationHistory");

            migrationBuilder.DropTable(
                name: "MemberRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
