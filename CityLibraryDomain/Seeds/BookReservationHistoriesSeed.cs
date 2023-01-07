using CityLibraryInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryDomain.Seeds
{
    class BookReservationHistoriesSeed : IEntityTypeConfiguration<BookReservationHistories>
    {
        public void Configure(EntityTypeBuilder<BookReservationHistories> builder)
        {
            builder.HasData(
                 new BookReservationHistories
                 {
                     HistoryId = 1,
                     BookId = 1,
                     MemberId = "User3",
                     ReturnDate = DateTime.Now.AddDays(-40),
                     RecievedDate = DateTime.Now.AddDays(-20),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 2,
                     BookId = 2,
                     MemberId = "User3",
                     ReturnDate = DateTime.Now.AddDays(-12),
                     RecievedDate = DateTime.Now.AddDays(-3),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 3,
                     BookId = 5,
                     MemberId = "User1",
                     ReturnDate = DateTime.Now.AddDays(-22),
                     RecievedDate = DateTime.Now.AddDays(-13),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 4,
                     BookId = 5,
                     MemberId = "User2",
                     ReturnDate = DateTime.Now.AddDays(-120),
                     RecievedDate = DateTime.Now.AddDays(-100),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 5,
                     BookId = 5,
                     MemberId = "User6",
                     ReturnDate = DateTime.Now.AddDays(-47),
                     RecievedDate = DateTime.Now.AddDays(-40),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 6,
                     BookId = 7,
                     MemberId = "User7",
                     ReturnDate = DateTime.Now.AddDays(-37),
                     RecievedDate = DateTime.Now.AddDays(-30),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 7,
                     BookId = 7,
                     MemberId = "User9",
                     ReturnDate = DateTime.Now.AddDays(-27),
                     RecievedDate = DateTime.Now.AddDays(-20),
                     CreatedAt = DateTime.Now
                 },
                 new BookReservationHistories
                 {
                     HistoryId = 8,
                     BookId = 18,
                     MemberId = "User10",
                     ReturnDate = DateTime.Now.AddDays(-17),
                     RecievedDate = DateTime.Now.AddDays(-10),
                     CreatedAt = DateTime.Now
                 }
            );
        }
    }
}
