using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;
using STAR.Utilities;

namespace STAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrontPage : ContentPage
    {
        string Online_SID, Online_lastname;
        string Online_firstname;
        public FrontPage(string SID0, string lastname0)
        {
            InitializeComponent();
            
            Online_SID = SID0;              // Initialize StarID
            Online_lastname = lastname0;    // Initialize Lastname
            RetrieveAccount();              // Retrieve and display account info
        }

        public void RetrieveAccount()
        {
            string connectionString = "Data Source = beenotified.database.windows.net; Initial Catalog = ParatransitDB; Persist Security Info = True; User ID = BeeNotifiedTeam; Password = iCEN450!";
            string queryString = "SELECT STARID, FirstName, LastName FROM dbo.UserAccounts";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();  //Runs SQL Query
                                                                     //Process results.  Each iteration is a row of the table
                    while (reader.Read())
                    {
                        if ((Online_SID.Equals("" + reader[0], StringComparison.InvariantCultureIgnoreCase) == true) &&
                            (Online_lastname.Equals("" + reader[2], StringComparison.InvariantCultureIgnoreCase) == true))
                        {
                            Online_firstname = "" + reader[1];
                            break;
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    DisplayAlert("Submission Error", ex.Message, "Ok");
                }
            }
            Display_Name.Text = Online_firstname + " " + Online_lastname;
            Display_ID.Text = Online_SID;
        }

        async void OnNewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTripPage(Online_SID));
        }
        async void OnRepeatClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TripHistory());
        }
        async void OnPendingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PendingTripPage());
        }
        async void OnUpcomingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Upcoming());
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PendingTripPage());
        }
        async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
    }
}