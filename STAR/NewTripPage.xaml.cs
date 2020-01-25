using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnConfirmedAsync(object sender, EventArgs args)
        {
            string temp = PickupDateSelector.Date.ToShortDateString();
            string message;
            message = "Pick up: " + CurrAddress.Text
                    + Environment.NewLine + Environment.NewLine
                    + "Drop off: " + DestAddress.Text
                    + Environment.NewLine + Environment.NewLine
                    + "Date: " + temp
                    + Environment.NewLine + Environment.NewLine
                    + "Return: " + ReturnAddress.Text
                    + Environment.NewLine + Environment.NewLine
                    + "Additional Instructions: " + Comments.Text;

            bool answer = await DisplayAlert("Verify Information:", message, "Confirm", "Cancel");
        }
    }
}