using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hangman_N2.Resources;
using SQLite;

namespace Hangman_N2
{
    [Activity(Label = "View_All_Activity")]
    public class View_All_Activity : Activity
    {
        private Button btn_play_again;
        List<Score_Table> List_Max;
        public Sqlite_Connection MyCon;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.View_All_Score);
          btn_play_again = FindViewById<Button>(Resource.Id.btn_play_again);
           btn_play_again.Click += btn_play_again_Click;

           MyCon = new Sqlite_Connection();
           List_Max = MyCon.ViewAll();

           ListView List_View_All = FindViewById<ListView>(Resource.Id.List_View_All);
            List_View_All.Adapter = new Adpter_Spiner(this, List_Max);




        }

        private void btn_play_again_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}