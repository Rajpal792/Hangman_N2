using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Hangman_N2.Resources;

namespace Hangman_N2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<Score_Table> All_Records;

        public TextView txtEd_Name;
        private Spinner Name_Spinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Sqlite_Connection Con = new Sqlite_Connection();
            All_Records = Con.ViewAll();

            Name_Spinner = FindViewById<Spinner>(Resource.Id.Name_Spinner);
            Hangman_N2.Resources.Adpter_Spiner da = new Resources.Adpter_Spiner(this, All_Records);

            Name_Spinner.Adapter = da;

            Name_Spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Name_Spinner_ItemSelected);

            txtEd_Name = FindViewById<TextView>(Resource.Id.txtEd_Name);

            Button btn_save = FindViewById<Button>(Resource.Id.btn_save);
            btn_save.Click += btn_save_Click;
        }

        private void Name_Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            // The Player Name and their score is collected from here 
            Hangman_Game_Activity.Id = this.All_Records.ElementAt(e.Position).Id;
          
            Hangman_Game_Activity.PlayerName = this.All_Records.ElementAt(e.Position).Name;
            Hangman_Game_Activity.score = this.All_Records.ElementAt(e.Position).Score;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txtEd_Name.Text.Length > 0)
            {
                // Set the new PlayerName to the text in the textfield
                Hangman_Game_Activity.PlayerName = txtEd_Name.Text.ToString();
                // Give them a score of 0 to begin with
                Hangman_Game_Activity.score = 0;
                var cc = new Sqlite_Connection();
                // Insert the Players name and score into the database
                cc.InsertNewPlayer(Hangman_Game_Activity.PlayerName, Hangman_Game_Activity.score);

                // And update the list
                All_Records = cc.ViewAll();


                var da = new Resources.Adpter_Spiner(this, All_Records);
                // And display the updated list on the spinner
                Name_Spinner.Adapter = da;
                Toast.MakeText(this, "Profile Name Saved ", ToastLength.Short).Show();
                StartActivity(typeof(Hangman_Game_Activity));

            }
            // Display a message if there is an empty textfield
            else
            {


                Toast.MakeText(this, "Please enter  your name", ToastLength.Short).Show();
            }

        }
    }
}
