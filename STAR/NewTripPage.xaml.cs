using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }

        async void OnConfirmedAsync(object sender, EventArgs args)
        {
            string temp = DatePicked.Date.ToShortDateString();
            string temp2 = TimePicked.Time.ToString();

            bool answer = await DisplayAlert("Verify Information:", "Pick Up: " + CurrAddress.Text
                                                                                + Environment.NewLine + Environment.NewLine
                                                                                + "Drop off: " + DestAddress.Text
                                                                                + Environment.NewLine + Environment.NewLine
                                                                                + "Date: " + temp
                                                                                + Environment.NewLine + Environment.NewLine
                                                                                + "Time: " + temp2, "Confirm", "Cancel");

        }

    }
}