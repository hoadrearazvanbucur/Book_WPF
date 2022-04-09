using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Backend.Model
{
    public class Book : IComparable<Book>
    {
        private string title, author, genre;
        private int id, year;

        public Book(int id,string title,string author,string genre,int year)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.year = year;
        }
        public Book(string title, string author, string genre, int year)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.year = year;
        }

        public override string ToString() => this.id + "," + this.title + "," + this.author + "," + this.genre + "," + this.year;
        public override bool Equals(object obj) => (obj as Book).ToString().Equals(this.ToString());
        public int CompareTo([AllowNull] Book other)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Title
        {
            get => this.title;
            set => this.title = value;
        }
        public string Author
        {
            get => this.author;
            set => this.author = value;
        }
        public string Genre
        {
            get => this.genre;
            set => this.genre = value;
        }
        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
    }
}
