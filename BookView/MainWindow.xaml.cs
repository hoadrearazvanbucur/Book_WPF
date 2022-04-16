using Backend.Model;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookView
{
    public partial class MainWindow : Window
    {

        private List<Book> lista;
        private BookServices services;
        private Book book;

        public MainWindow()
        {
            InitializeComponent();
            this.lista = new List<Book>();
            this.services = new BookServices("Default");
            this.lista = this.services.lista();
            this.book = new Book("", "", "", -1);

            //tabel();
        }

        public void tabel()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    TextBlock a = new TextBlock();
                    RowDefinition row = new RowDefinition();

                    //Grid.SetRowSpan(GridView, Grid.GetRowSpan(PanelComenzi) + 1);
                    //Grid.SetColumnSpan(GridView, Grid.GetColumnSpan(PanelComenzi) + 1);

                    if (j == 1) a.Text = lista[i].Id.ToString();
                    if (j == 2) a.Text = lista[i].Title;
                    if (j == 3) a.Text = lista[i].Author;
                    if (j == 4) a.Text = lista[i].Genre;
                    if (j == 5) a.Text = lista[i].Year.ToString();

                    GridView.Children.Add(a);
                    GridView.RowDefinitions.Add(row);

                    //row.Height = new GridLength(50);

                    a.FontSize = 16;
                    a.FontFamily = new FontFamily("Arial");
                    a.TextAlignment = TextAlignment.Center;

                    Grid.SetColumn(a, j);
                    Grid.SetRow(a, i + 2);
                }
            }
        }


        //Adaugare
        private void StangaAdaugare_Click(object sender, RoutedEventArgs e)
        {
            if (LblAdaugare.Content.Equals("Autor") == true)
            {
                LblAdaugare.Content = "Titlul";
                TxtAdaugare.Text = this.book.Title;
            }
            else
            if (LblAdaugare.Content.Equals("Gen") == true)
            {
                LblAdaugare.Content = "Autor";
                TxtAdaugare.Text = this.book.Author;
            }
            else
            if (LblAdaugare.Content.Equals("An") == true)
            {
                LblAdaugare.Content = "Gen";
                TxtAdaugare.Text = this.book.Genre;
            }
        }
        private void DreaptaAdaugare_Click(object sender, RoutedEventArgs e)
        {
            if (LblAdaugare.Content.Equals("Titlul") == true)
            {
                LblAdaugare.Content = "Autor";
                TxtAdaugare.Text = this.book.Author;

            }
            else
            if (LblAdaugare.Content.Equals("Autor") == true)
            {
                LblAdaugare.Content = "Gen";
                TxtAdaugare.Text = this.book.Genre;

            }
            else
            if (LblAdaugare.Content.Equals("Gen") == true)
            {
                LblAdaugare.Content = "An";
                if(this.book.Year==-1)
                    TxtAdaugare.Text = "";
                else
                    TxtAdaugare.Text = this.book.Year.ToString();

            }
        }
        private void Adaugare_Click(object sender, RoutedEventArgs e)
        {
            if (this.book.Title.Equals("") == false && this.book.Author.Equals("") == false && this.book.Genre.Equals("") == false && this.book.Year!=-1)
            {
                try
                {
                    this.services.create(this.book);
                    this.book = new Book("", "", "", -1);
                    TxtAdaugare.Text = "";
                    MessageBox.Show("Adaugat cu succes!");
                }
                catch
                {
                    MessageBox.Show("Aceasta carte exista deja");
                }
            }
            else
            {
                MessageBox.Show("Nu ai completat toate casutele");
            }
        }
        private void TxtAdaugare_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblAdaugare.Content.Equals("Titlul") == true)
                this.book.Title = TxtAdaugare.Text;
            else
            if (LblAdaugare.Content.Equals("Autor") == true)
                this.book.Author = TxtAdaugare.Text;
            else
            if (LblAdaugare.Content.Equals("Gen") == true)
                this.book.Genre = TxtAdaugare.Text;
            else
            if (LblAdaugare.Content.Equals("An") == true && TxtAdaugare.Text != "")
                try
                {
                    this.book.Year = int.Parse(TxtAdaugare.Text);
                }
                catch
                {
                    MessageBox.Show("Introdu doar cifre");
                    TxtAdaugare.Text = "";
                }

        }
        private void ClearAdaugare_Click(object sender, RoutedEventArgs e)
        {
            this.book = new Book("", "", "", -1);
            TxtAdaugare.Text = "";
        }

        //Modificare
        private void StangaModifica_Click(object sender, RoutedEventArgs e)
        {
            if (LblModificare.Content.Equals("Autor") == true)
                LblModificare.Content = "Titlul";
            else
            if (LblModificare.Content.Equals("Gen") == true)
                LblModificare.Content = "Autor";
            else
            if (LblModificare.Content.Equals("An") == true)
                LblModificare.Content = "Gen";
        }
        private void DreaptaModifica_Click(object sender, RoutedEventArgs e)
        {
            if (LblModificare.Content.Equals("Titlul") == true)
                LblModificare.Content = "Autor";
            else
                 if (LblModificare.Content.Equals("Autor") == true)
                LblModificare.Content = "Gen";
            else
                 if (LblModificare.Content.Equals("Gen") == true)
                LblModificare.Content = "An";
        }
        private void Modificare_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TxtModificare_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Stergere
        private void Stergere_Click(object sender, RoutedEventArgs e)
        {
            if(TxtStergere.Text.Equals("")==false)
            {
                try
                {
                    this.services.delete(int.Parse(TxtStergere.Text));
                    TxtStergere.Text = "";
                    MessageBox.Show("Carte stearsa cu succes!");
                }
                catch
                {
                    MessageBox.Show("Aceasta carte nu exista");
                }
            }
            else
            {
                MessageBox.Show("Nu lasa casute necompletate");
            }
        }
        private void TxtStergere_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int nr = int.Parse(TxtStergere.Text);
            }
            catch
            {
                TxtStergere.Text = "";
                //MessageBox.Show("Introdu doar cifre");

            }
        }
    }
}
