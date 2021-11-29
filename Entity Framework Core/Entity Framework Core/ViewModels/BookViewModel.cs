using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Entity_Framework_Core.Services;
using Entity_Framework_Core.Models;
using System;

namespace Entity_Framework_Core.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        #region Services
        private readonly DBDataAccess<Book> dataServiceBooks;
        #endregion Services

        #region Attributes
        private string titulo;
        private string author;
        private double precio;
        private bool disponible;
        private DateTime fecha;

        #endregion

        #region Properties
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

        #region Constructor
        public BookViewModel()
        {
            dataServiceBooks = new DBDataAccess<Book>();
            //this.Create();
            //this.Anio = DateTime.Now.Year;
        }
        #endregion Constructor

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
                    
                    if (newBook != null)
                    {
                        if (dataServiceBooks.Create(newBook))
                        {
                            await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                            $"Albúm del artista:" +
                                                                            $"creado correctamente en la base de datos",
                                                                            "Ok");


                            Titulo = string.Empty;
                            Author = string.Empty;
                            Precio = 0;
                            // this.Anio = DateTime.Now.Year;
                        }

                        else
                            await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                            $"Error al crear el Albúm en la base de datos",
                                                                            "Ok");
                    }
                });
            }
        }


        #endregion Commands

        #region Methods


        #endregion Methods
    }

}
