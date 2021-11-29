using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Entity_Framework_Core.Services;
using Entity_Framework_Core.Models;
using Entity_Framework_Core.DataContext;
using Entity_Framework_Core.Views;
using System;


namespace Entity_Framework_Core.ViewModels
{

    public class BooksFailsViewModel : BaseViewModel
    {
        #region Services        
        private readonly BookService dataServiceBooks;
        
        #endregion Services

        #region Attributes

        private ObservableCollection<Book> books;
        public INavigation Navigation { get; set; }
        #endregion Attributes

        #region Properties


        public ObservableCollection<Book> Books
        {
            get { return this.books; }
            set { SetValue(ref this.books, value); }
        }
        #endregion Properties

        #region Command

        public ICommand NeWBookCommand
        {
            get
            {
                return new Command(NeWBook);
            }
        }
        public ICommand EditBookCommand
        {
            get
            {
                return new Command<int>((BookID) =>
                {

                   Application.Current.MainPage.Navigation.PushAsync(new EditBookPage(BookID));
                });
            }
        }

        public ICommand LoadbookCommand
        {
            get
            {
                return new Command(LoadBooks);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command<int>(async (BookID) =>
                {
                    this.dataServiceBooks.Delete(BookID);
                    await Application.Current.MainPage.DisplayAlert("Eliminar ", "Se eliminó con exito", "OK");
                });
            }
        }

        #endregion

        #region Constructor
        public BooksFailsViewModel(INavigation navigation)
        {
          
            this.dataServiceBooks = new BookService();
            this.LoadBooks();
        }
        public BooksFailsViewModel()
        {

            this.dataServiceBooks = new BookService();
            this.LoadBooks();
        }
        #endregion Constructor



        #region Methods

        private void NeWBook()
        {
            Application.Current.MainPage.Navigation.PushAsync(new BookPage());

        }
        private void LoadBooks()
        {
            var booksDB = this.dataServiceBooks.Get();
            this.Books = new ObservableCollection<Book>(booksDB);
        }
        #endregion Methods
    }

}



