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
  public class Sqlite_Connection
    {
        private string data_base_path { get; set; }

        private SQLiteConnection db { get; set; }





        public Sqlite_Connection()
        {

            string data_base_path =
                Path.Combine(System.Environment.GetFolderPath
                    (System.Environment.SpecialFolder.Personal), "HangmanDB.sqlite");

            db = new SQLiteConnection(data_base_path);

            db.CreateTable<Score_Table>();
        }




        public List<Score_Table> ViewAll()
        {
            try
            {
                ;
                return db.Query<Score_Table>("select *  from Score_Table  ORDER BY Score DESC");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }







        public string UpdateScore(int id, string name, int score)
        {


            try
            {
                string data_base_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "HangmanDB.sqlite");
                var db = new SQLiteConnection(data_base_path);
                var item = new Score_Table();

                item.Id = id;
                item.Name = name;
                item.Score = score;

                db.Update(item);
                return "Record Updated...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }



        public string InsertNewPlayer(string name, int score)
        {


            try
            {
                string data_base_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "HangmanDB.sqlite");
                var db = new SQLiteConnection(data_base_path);
                var item = new Score_Table();
                item.Name = name;
                item.Score = score;

                db.Insert(item);
                return "You have been added to the database";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }


        public string DeletePlayer(int id)
        {

            try
            {
                string data_base_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "HangmanDB.sqlite");
                var db = new SQLiteConnection(data_base_path);
                var item = new Score_Table();
                item.Id = id;


                db.Delete(item);
                return "You have been added to the database";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }


        }

    }
}