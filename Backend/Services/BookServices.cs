using Backend.Exceptions;
using Backend.Model;
using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services
{
    public class BookServices
    {
        private BookRepository control;

        public BookServices(string dataBase)
        {
            this.control = new BookRepository(dataBase);
        }

        public List<Book> lista()
        {
            return control.getAll();
        }
        public void create(Book book)
        {
            if (!this.exist(book.Title,book.Author,book.Genre,book.Year))
            {
                control.add(book);
            }
            else
            {
                throw new BookException("Aceasta carte exista");
            }
        }
        public void delete(int id)
        {
            if (this.exist(this.control.getBookWithId(id).Title, this.control.getBookWithId(id).Author, this.control.getBookWithId(id).Genre, this.control.getBookWithId(id).Year))
            {
                control.delete(id);
            }
            else
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }

        public void updateTitle(int id, string newTitle)
        {
            if (this.exist(this.control.getBookWithId(id).Title, this.control.getBookWithId(id).Author, this.control.getBookWithId(id).Genre, this.control.getBookWithId(id).Year))

            {
                control.updateTitle(id, newTitle);
            }
            else
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }
        public void updateAuthor(int id, string newAuthor)
        {
            if (this.exist(this.control.getBookWithId(id).Title, this.control.getBookWithId(id).Author, this.control.getBookWithId(id).Genre, this.control.getBookWithId(id).Year))

            {
                control.updateAuthor(id, newAuthor);
            }
            else
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }
        public void updateGenre(int id, string newGenre)
        {
            if (this.exist(this.control.getBookWithId(id).Title, this.control.getBookWithId(id).Author, this.control.getBookWithId(id).Genre, this.control.getBookWithId(id).Year))

            {
                control.updateGenre(id, newGenre);
            }
            else
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }
        public void updateYear(int id, int newYear)
        {
            if (this.exist(this.control.getBookWithId(id).Title, this.control.getBookWithId(id).Author, this.control.getBookWithId(id).Genre, this.control.getBookWithId(id).Year))

            {
                control.updateYear(id, newYear);
            }
            else
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }

        public Book getBookWithId(int id)
        {
            try
            {
                return this.control.getBookWithId(id);

            }catch
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }
        public int getIdWithBook(string title, string author, string genre, int year)
        {
            try
            {
                return this.control.getIdWithBook(title, author, genre, year);

            }
            catch
            {
                throw new BookException("Aceasta carte nu exista");
            }
        }

        public bool exist(string title, string author, string genre, int year)
        {
            foreach (Book book in this.lista())
                if (book.Title == title && book.Author==author && book.Genre==genre && book.Year==year)
                    return true;
            return false;
        }
        public bool existId(int id)
        {
            foreach (Book book in this.lista())
                if (book.Id == id)
                    return true;
            return false;
        }
    }
}
