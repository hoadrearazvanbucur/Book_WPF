using Backend.Model;
using Data_Acces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Repository
{
    public class BookRepository
    {
        private readonly string connectionString;
        private DataAcces db;

        public BookRepository(string dataBase)
        {
            db = new DataAcces();
            var builder = new ConfigurationBuilder().SetBasePath
            (@"D:\1_PROGRAMARE\C#\1_WPF\Initiere\Book\Backend").AddJsonFile("appsettings.json");
            var config = builder.Build();
            this.connectionString = config.GetConnectionString(dataBase);
        }

        public List<Book> getAll()
        {
            string sql = "select * from book";
            return db.LoadData<Book, dynamic>(sql, new { }, connectionString);
        }
        public void add(Book book)
        {
            string sql = "insert into book(title, author, genre, year) VALUES (@title, @author, @genre, @year)";
            db.SaveData(sql, new { book.Title, book.Author, book.Genre, book.Year }, connectionString);
        }
        public void delete(int id)
        {
            string sql = "delete from book where id=@id";
            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateTitle(int id, string newTitle)
        {
            string sql = "update book set title=@newTitle where id=@id";
            db.SaveData(sql, new { newTitle, id }, connectionString);
        }
        public void updateAuthor(int id, string newAuthor)
        {
            string sql = "update book set author=@newAuthor where id=@id";
            db.SaveData(sql, new { newAuthor, id }, connectionString);
        }
        public void updateGenre(int id, string newGenre)
        {
            string sql = "update book set genre=@newGenre where id=@id";
            db.SaveData(sql, new { newGenre, id }, connectionString);
        }
        public void updateYear(int id, int newYear)
        {
            string sql = "update book set year=@newYear where id=@id";
            db.SaveData(sql, new { newYear, id }, connectionString);
        }

        public Book getBookWithId(int id)
        {
            string sql = "select * from book where id=@id";
            return db.LoadData<Book, dynamic>(sql, new { id }, connectionString)[0];
        }
        public int getIdWithBook(string title, string author, string genre, int year)
        {
            string sql = "select id from book where title=@title and author=@author and genre=@genre and year=@year";
            return db.LoadData<int, dynamic>(sql, new { title, author, genre, year }, connectionString)[0];
        }
    }
}
