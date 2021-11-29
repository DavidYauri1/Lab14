using Entity_Framework_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entity_Framework_Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookPage : ContentPage
    {
        public EditBookPage(int BookID)
        {
            int fff= BookID;
            InitializeComponent();
            this.BindingContext = new BookFailViewModel(fff);
            //this.BindingContext = new BookViewModel();
        }
    }
}