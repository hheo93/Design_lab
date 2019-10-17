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
    public partial class NewTripPage : ContentPage
    {
        public NewTripPage()
        {
            InitializeComponent();
        }

        private void DatePicker_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}