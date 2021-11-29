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
    public class AlbumesViewModel : BaseViewModel
    {
        #region Services        
        private readonly AlbumService dataServiceAlbumes;
        private readonly ArtistaService dataServiceArtistas;
        #endregion Services

        #region Attributes

        private ObservableCollection<Album> albumes;

        #endregion Attributes

        #region Properties


        public ObservableCollection<Album> Albumes
        {
            get { return this.albumes; }
            set { SetValue(ref this.albumes, value); }
        }




        #endregion Properties

        #region Command

        public ICommand NeWAlbumCommand
        {
            get
            {
                return new Command(NeWAlbum);
            }
        }

        public ICommand LoadbumesCommand
        {
            get
            {
                return new Command(LoadAlbumes);
            }
        }
        #endregion

        #region Constructor
        public AlbumesViewModel()
        {
            this.dataServiceArtistas = new ArtistaService();
            this.dataServiceAlbumes = new AlbumService();

            this.CreateArtistas();


            this.LoadAlbumes();


        }
        #endregion Constructor



        #region Methods

        private void NeWAlbum()
        {
            Application.Current.MainPage.Navigation.PushAsync(new BookPage());

        }
        private void LoadAlbumes()
        {
            var albumesDB = this.dataServiceAlbumes.Get();
            this.Albumes = new ObservableCollection<Album>(albumesDB);

            Console.WriteLine("HOLA Cancelado");

        }
        
        private void CreateArtistas()
        {
            /*
            var artistas = new List<Artista>()
            {
                new Artista { Nombre = "Ricardo Arjona" },
                new Artista { Nombre = "Kalimba" },
                new Artista { Nombre = "Luis Miguel" }
            };

            this.dataServiceArtistas.CreateList(artistas);*/
        }
        #endregion Methods
    }

}
