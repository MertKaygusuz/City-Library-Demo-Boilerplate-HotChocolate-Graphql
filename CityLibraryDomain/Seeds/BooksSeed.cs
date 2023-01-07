using CityLibraryInfrastructure.Entities;
using CityLibraryInfrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryDomain.Seeds
{
    class BooksSeed : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            var books = new Books[]
            {
                new Books
                {
                    BookId = 1,
                    BookTitle = "Ailenin, Devletin ve Özel Mülkiyetin Kökeni",
                    Author = "Friedrich Engels",
                    FirstPublishDate = DateTime.Now.AddYears(-138),
                    EditionNumber = 4,
                    EditionDate = DateTime.Now.AddYears(-120),
                    TitleType = BookTitleTypes.Philosophy,
                    CoverType = BookCoverTypes.HardCover,
                    AvailableCount = 3,
                    ReservedCount = 1,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                 new Books
                 {
                     BookId = 2,
                     BookTitle = "Beyoğlu Rapsodisi",
                     Author = "Ahmet Ümit",
                     FirstPublishDate = DateTime.Now.AddYears(-19),
                     EditionNumber = 4,
                     EditionDate = DateTime.Now.AddYears(-5),
                     TitleType = BookTitleTypes.Literature,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 4,
                     ReservedCount = 2,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                  {
                      BookId = 3,
                      BookTitle = "Beyoğlu Rapsodisi",
                      Author = "Ahmet Ümit",
                      FirstPublishDate = DateTime.Now.AddYears(-19),
                      EditionNumber = 3,
                      EditionDate = DateTime.Now.AddYears(-10),
                      TitleType = BookTitleTypes.Literature,
                      CoverType = BookCoverTypes.HardCover,
                      AvailableCount = 3,
                      ReservedCount = 0,
                      CreatedAt = DateTime.Now.AddYears(-1)
                  },
                 new Books
                  {
                      BookId = 4,
                      BookTitle = "Thomas' Calculus",
                      Author = "George Brinton Thomas",
                      FirstPublishDate = DateTime.Now.AddYears(-70),
                      EditionNumber = 13,
                      EditionDate = DateTime.Now.AddYears(-5),
                      TitleType = BookTitleTypes.Math,
                      CoverType = BookCoverTypes.SoftCover,
                      AvailableCount = 500,
                      ReservedCount = 0,
                      CreatedAt = DateTime.Now.AddYears(-1)
                  },
                 new Books
                  {
                      BookId = 5,
                      BookTitle = "Thomas' Calculus",
                      Author = "George Brinton Thomas",
                      FirstPublishDate = DateTime.Now.AddYears(-70),
                      EditionNumber = 13,
                      EditionDate = DateTime.Now.AddYears(-5),
                      TitleType = BookTitleTypes.Math,
                      CoverType = BookCoverTypes.HardCover,
                      AvailableCount = 50,
                      ReservedCount = 0,
                      CreatedAt = DateTime.Now.AddYears(-1)
                  },
                 new Books
                 {
                     BookId = 6,
                     BookTitle = "Die Heilige Familie",
                     Author = "Karl Marx & Friedrich Engels",
                     FirstPublishDate = DateTime.Now.AddYears(-178),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-178),
                     TitleType = BookTitleTypes.Philosophy,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 3,
                     ReservedCount = 1,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 7,
                     BookTitle = "Die Heilige Familie",
                     Author = "Karl Marx & Friedrich Engels",
                     FirstPublishDate = DateTime.Now.AddYears(-178),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-178),
                     TitleType = BookTitleTypes.Philosophy,
                     CoverType = BookCoverTypes.SoftCover,
                     AvailableCount = 300,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 8,
                     BookTitle = "Oyunun Sonu",
                     Author = "Julio Cortazar",
                     FirstPublishDate = DateTime.Now.AddYears(-67),
                     EditionNumber = 2,
                     EditionDate = DateTime.Now.AddYears(-3),
                     TitleType = BookTitleTypes.Literature,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 6,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 9,
                     BookTitle = "Eloquent Javascript",
                     Author = "Marjin Haverbeke",
                     FirstPublishDate = DateTime.Now.AddYears(-6),
                     EditionNumber = 3,
                     EditionDate = DateTime.Now.AddYears(-5),
                     TitleType = BookTitleTypes.Education,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 2,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 10,
                     BookTitle = "Eloquent Javascript",
                     Author = "Marjin Haverbeke",
                     FirstPublishDate = DateTime.Now.AddYears(-6),
                     EditionNumber = 3,
                     EditionDate = DateTime.Now.AddYears(-5),
                     TitleType = BookTitleTypes.Education,
                     CoverType = BookCoverTypes.SoftCover,
                     AvailableCount = 450,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 11,
                     BookTitle = "Bir Kedi, Bir Adam, Bir Ölüm",
                     Author = "Zülfü Livaneli",
                     FirstPublishDate = DateTime.Now.AddYears(-22),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-22),
                     TitleType = BookTitleTypes.Literature,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 4,
                     ReservedCount = 1,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 12,
                     BookTitle = "Principes élémentaires de Philosophie",
                     Author = "Georges Politzer",
                     FirstPublishDate = DateTime.Now.AddYears(-78),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-78),
                     TitleType = BookTitleTypes.Philosophy,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 9,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 13,
                     BookTitle = "Principes élémentaires de Philosophie",
                     Author = "Georges Politzer",
                     FirstPublishDate = DateTime.Now.AddYears(-78),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-78),
                     TitleType = BookTitleTypes.Philosophy,
                     CoverType = BookCoverTypes.SoftCover,
                     AvailableCount = 350,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 14,
                     BookTitle = "Mechanics of Materials",
                     Author = "Ferdinand Pierre Beer & Elwood Russell Johnston Jr.",
                     FirstPublishDate = DateTime.Now.AddYears(-42),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-42),
                     TitleType = BookTitleTypes.Science,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 3,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 15,
                     BookTitle = "Mechanics of Materials",
                     Author = "Ferdinand Pierre Beer & Elwood Russell Johnston Jr.",
                     FirstPublishDate = DateTime.Now.AddYears(-42),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-42),
                     TitleType = BookTitleTypes.Science,
                     CoverType = BookCoverTypes.SoftCover,
                     AvailableCount = 300,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 16,
                     BookTitle = "Kardeşimin Hikayesi",
                     Author = "Zülfü Livaneli",
                     FirstPublishDate = DateTime.Now.AddYears(-10),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-10),
                     TitleType = BookTitleTypes.Literature,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 11,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 17,
                     BookTitle = "La Femme et le Pantin",
                     Author = "Pierre Louÿs",
                     FirstPublishDate = DateTime.Now.AddYears(-125),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-125),
                     TitleType = BookTitleTypes.Literature,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 1,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 18,
                     BookTitle = "Sadist",
                     Author = "Stephen King",
                     FirstPublishDate = DateTime.Now.AddYears(-36),
                     EditionNumber = 2,
                     EditionDate = DateTime.Now.AddYears(-28),
                     TitleType = BookTitleTypes.Literature,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 4,
                     ReservedCount = 1,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 19,
                     BookTitle = "Allah ile Aldatmak",
                     Author = "Yaşar Nuri Öztürk",
                     FirstPublishDate = DateTime.Now.AddYears(-9),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-9),
                     TitleType = BookTitleTypes.Religious,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 2,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 },
                 new Books
                 {
                     BookId = 20,
                     BookTitle = "The Invisible Man",
                     Author = "Herbert George Wells",
                     FirstPublishDate = DateTime.Now.AddYears(-126),
                     EditionNumber = 1,
                     EditionDate = DateTime.Now.AddYears(-126),
                     TitleType = BookTitleTypes.Religious,
                     CoverType = BookCoverTypes.HardCover,
                     AvailableCount = 1,
                     ReservedCount = 0,
                     CreatedAt = DateTime.Now.AddYears(-1)
                 }
            };

            builder.HasData(books);
        }
    }
}
