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
        
        public NewTripPage()
        {
            InitializeComponent();
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
                    + "Additional Instructions: " + YesPCA.ToString();

            bool answer = await DisplayAlert("Verify Information:", message, "Confirm", "Cancel");

            if (answer)
            {
                TableInfo.Add("PUAddress", CurrAddress.Text);
                TableInfo.Add("PUTime", temp);
                TableInfo.Add("DOAddress", DestAddress.Text);
                TableInfo.Add("RAddress", ReturnAddress.Text);
                TableInfo.Add("RTime", ReturnDatePicked.Date.ToShortDateString());
                TableInfo.Add("PCA", YesPCA.ToString());
                TableInfo.Add("Payment", "Ticket");
                TableInfo.Add("Comments", Comments.Text);

                var content = new FormUrlEncodedContent(TableInfo);
                var response = await HTTPClientInstance.client.PostAsync("https://paratransitservices.azurewebsites.net/newtrip", content);
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
        }
    }
}