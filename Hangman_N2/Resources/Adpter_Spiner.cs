using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman_N2.Resources
{
    public class Adpter_Spiner : BaseAdapter<Score_Table>
    {
        private readonly Activity context;
        private readonly List<Score_Table> Items;

        public Adpter_Spiner(Activity context, List<Score_Table> items)
        {
            this.Items = items;
            this.context = context;
        }



        public override int Count
        {
            get { return Items.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Score_Table this[int position]
        {
            get { return Items[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.Spiner_Layout, null, false);
            }

            // Set the txtRowName.Text which is in the listview_row layout to the Players Name
            TextView txtPlayerName = row.FindViewById<TextView>(Resource.Id.txtPlayerName);
            txtPlayerName.Text = Items[position].Name;

            // Set the txtRowName.Text in the  listview_row to the Players score
            TextView txtPlayerScore = row.FindViewById<TextView>(Resource.Id.txtPlayerScore);
            txtPlayerScore.Text = Items[position].Score.ToString();

            return row;


        }
    }
}