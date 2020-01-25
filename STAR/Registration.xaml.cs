using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STAR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        private string starID, FirstName, LastName, Email, HomeAddress;
        private int DoB;

        public Registration()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnRegisterClicked(object sender, EventArgs e)
        {
            starID = REG_STARID.Text;
            FirstName = REG_FIRSTNAME.Text;
            LastName = REG_LASTNAME.Text;
            Email = REG_EMAIL.Text;
            DoB = int.Parse(REG_DOB.Text);
            HomeAddress = REG_ADD.Text;

            string connectionString = "Data Source = beenotified.database.windows.net; Initial Catalog = ParatransitDB; Persist Security Info = True; User ID = BeeNotifiedTeam; Password = iCEN450!";

            string queryString = "INSERT INTO dbo.UserAccounts (STARID, FirstName, LastName, Email, DoB, HomeAddress) VALUES ('" + starID + "', '" + FirstName + "', '" + LastName + "','" + Email + "' , '" + DoB + "', '" + HomeAddress + "')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                // Open the connection in a try/catch block.
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    //Below displays a dialog pop-up window on the phone indicating success
                    await DisplayAlert("SUCCESS", "You successfully wrote to the database", "Ok");
                }
                catch (Exception ex)
                {
                    //If an error occurred, the error message will be displayed to the 
                    await DisplayAlert("Submission Error", ex.Message, "Ok");
                }
                finally
                {
                    connection.Close();
                }
                //Navigate back to LoginPage once account is created
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}