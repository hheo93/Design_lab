using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using STAR.Utilities;

namespace STAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTripPage : ContentPage
    {
        Dictionary<string, string> TableInfo = new Dictionary<string, string>();
        string ONLINE_SID;
        public NewTripPage(string O_SID)
        {
            InitializeComponent();
            ONLINE_SID = O_SID;
        }

        async void OnConfirmedAsync(object sender, EventArgs args)
        {
            string temp = PickupDateSelector.Date.ToShortDateString() + " - " + PickupTimeSelector.Time.ToString();
            string Rtemp = ReturnDatePicked.Date.ToShortDateString() + " - " + ReturnTimePicked.Time.ToString();
            string message;
            message = "Pick up: " + CurrAddress.Text
                    + Environment.NewLine + Environment.NewLine
                    + "Drop off: " + DestAddress.Text
                    + Environment.NewLine + Environment.NewLine
                    + "Date: " + temp
                    + Environment.NewLine + Environment.NewLine
                    + "Return: " + ReturnAddress.Text
                    + Environment.NewLine + Environment.NewLine
                    + "Additional Instructions: ";

            bool answer = await DisplayAlert("Verify Information:", message, "Confirm", "Cancel");

            if(answer)
            {
                string url = "?PAddress="+CurrAddress.Text+"&PTime="+temp+"&DAddress="+DestAddress.Text+"&RAddress="+ReturnAddress.Text+ "&RTime="+Rtemp+ "&PCA=no&Pay=ticket&comments="+Comments.Text+ "&STARID="+ONLINE_SID;
                var responseString = HTTPClientInstance.client.GetAsync("https://paratransitservices.azurewebsites.net/newtrip"+url);
                _ = Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}