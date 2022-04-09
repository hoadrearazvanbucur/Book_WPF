using Backend.Exceptions;
using Backend.Model;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class BookTests
    {
        private readonly ITestOutputHelper outputHelper;
        private BookServices book;
        public BookTests(ITestOutputHelper output)
        {
            this.outputHelper = output;
            this.book = new BookServices("Test");
        }

        [Fact]
        public void adaugare_stergere()
        {
            this.book.create(new Book("titlul1", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte exista", Assert.Throws<BookException>(() => this.book.create(new Book("titlul1", "autor1", "gen1", 1))).Message);
            
            this.book.delete(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.delete(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1))).Message);
        }

        [Fact]
        public void update_Title()
        {
            this.book.create(new Book("titlul1", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte exista", Assert.Throws<BookException>(() => this.book.create(new Book("titlul1", "autor1", "gen1", 1))).Message);

            this.book.updateTitle(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), "titlul2");
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.updateTitle(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), "titlul2")).Message);

            this.book.delete(this.book.getIdWithBook("titlul2", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.delete(this.book.getIdWithBook("titlul2", "autor1", "gen1", 1))).Message);
        }

        [Fact]
        public void update_Author()
        {
            this.book.create(new Book("titlul1", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte exista", Assert.Throws<BookException>(() => this.book.create(new Book("titlul1", "autor1", "gen1", 1))).Message);

            this.book.updateAuthor(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), "autor2");
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.updateAuthor(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), "autor2")).Message);

            this.book.delete(this.book.getIdWithBook("titlul1", "autor2", "gen1", 1));
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.delete(this.book.getIdWithBook("titlul1", "autor2", "gen1", 1))).Message);
        }

        [Fact]
        public void update_Genre()
        {
            this.book.create(new Book("titlul1", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte exista", Assert.Throws<BookException>(() => this.book.create(new Book("titlul1", "autor1", "gen1", 1))).Message);

            this.book.updateGenre(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), "gen2");
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.updateGenre(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), "gen2")).Message);

            this.book.delete(this.book.getIdWithBook("titlul1", "autor1", "gen2", 1));
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.delete(this.book.getIdWithBook("titlul1", "autor1", "gen2", 1))).Message);
        }

        [Fact]
        public void update_Year()
        {
            this.book.create(new Book("titlul1", "autor1", "gen1", 1));
            Assert.Equal("Aceasta carte exista", Assert.Throws<BookException>(() => this.book.create(new Book("titlul1", "autor1", "gen1", 1))).Message);

            this.book.updateYear(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), 2);
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.updateYear(this.book.getIdWithBook("titlul1", "autor1", "gen1", 1), 2)).Message);

            this.book.delete(this.book.getIdWithBook("titlul1", "autor1", "gen1", 2));
            Assert.Equal("Aceasta carte nu exista", Assert.Throws<BookException>(() => this.book.delete(this.book.getIdWithBook("titlul1", "autor1", "gen1", 2))).Message);
        }
    }
}
