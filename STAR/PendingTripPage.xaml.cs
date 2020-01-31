using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingTripPage : ContentPage
    {
        public PendingTripPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}