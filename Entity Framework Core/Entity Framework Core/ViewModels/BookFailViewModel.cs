using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using Entity_Framework_Core.Models;
using Entity_Framework_Core.Services;


namespace Entity_Framework_Core.ViewModels
{
   
    public class BookFailViewModel : BaseViewModel
    {
        #region Services

        private readonly BookService dataServiceBooks;
        #endregion

        #region Attributes
        private string titulo;
        private string author;
        private double precio;
        private bool disponible;
        private DateTime fecha;
        private int bookidparam;
        
        #endregion

        #region Properties
        public int ID
        {
            get { return bookidparam; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { SetValue(ref titulo, value); }
        }
        public bool Disponible
        {
            get { return disponible; }
            set { SetValue(ref disponible, value); }
        }
        public DateTime Fecha
        { 
            get { return fecha; }
            set { SetValue(ref fecha, value); }
        }
        public string Author
        {
            get { return author; }
            set { SetValue(ref author, value); }
        }

        public double Precio
        {
            get { return precio; }
            set { SetValue(ref precio, value); }
        }


        #endregion Properties

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newBook = new Book()
                    {
                        Titulo = this.Titulo,
                        Author = this.Author,
                        Precio = this.Precio,
                        Disponible = this.Disponible,
                        Fecha = this.Fecha,

                    };

                    var book = this.dataServiceBooks.GetByTitulo(newBook.Titulo);

                    if (book == null)
                    {
                        if (newBook != null)
                        {
                            if (this.dataServiceBooks.Create(newBook))
                            {
                                await Application.Current.MainPage.
                                DisplayAlert("Operación Exitosa",
                                             "creado correctamente en la base de datos", "Ok");

                                
                                this.Titulo = string.Empty;
                                this.Author= string.Empty;
                                this.Precio = 0;
                                this.Disponible = true;
                                
                                await Application.Current.MainPage.Navigation.PopAsync();

                            }

                            else
                                await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                                $"Error al crear Book en la base de datos",
                                                                                "Ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Validación",
                                                                              $"Título Repetido",
                                                                              "Ok");
                    }


                });
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newBook = new Book()
                    {
                        BookID =this.ID,
                        Titulo = this.Titulo,
                        Author = this.Author,
                        Precio = this.Precio,
                        Disponible = this.Disponible,
                        Fecha = this.Fecha,

                    };
                    if (newBook != null)
                    {
                         this.dataServiceBooks.Update(newBook, this.ID);


                        await Application.Current.MainPage.
                            DisplayAlert("Actualización Exitosa",
                                         "actualizado correctamente en la base de datos", "Ok");

                        this.Titulo = string.Empty;
                        this.Author = string.Empty;
                        this.Precio = 0;
                        this.Disponible = true;
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                });
            }
        }

        #endregion Commands

        #region Constructor
        public BookFailViewModel(int variable)
        {
            bookidparam = variable;
            this.dataServiceBooks = new BookService();
            this.LoadAlbumes();
        }
        public BookFailViewModel()
        {
            
            this.dataServiceBooks = new BookService();
        }
        #endregion Constructor

        #region Methods
        private void LoadAlbumes()
        {
            var databook = this.dataServiceBooks.GetByID(bookidparam);
            titulo = databook.Titulo;
            author = databook.Author;
            precio = databook.Precio;
            fecha = databook.Fecha;
            disponible = databook.Disponible;
        }
        #endregion
    }

}
