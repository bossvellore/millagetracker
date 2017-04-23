using Android.App;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace MillageCalc.Droid
{
	[Activity(Label = "MillageCalc", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

        MillageDb millageDb;
        List<MillageRd> millages;
        ListView mlv;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
            

            millageDb = MillageDb.GetDB(DataConnection.GetConnection());
            millageDb.CreateTable();
            // Get our button from the layout resource,
            // and attach an event to it

            mlv = FindViewById<ListView>(Resource.Id.millageListView);
            mlv.ItemClick += Mlv_ItemClick;

        }

        private void Mlv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var addMillageIntent = new Intent(this, typeof(AddMillageActivity));
            addMillageIntent.PutExtra("Edit_Millage_Id", millages[e.Position].Id);
            StartActivity(addMillageIntent);
        }

        protected async override void OnResume()
		{
			base.OnResume();
            millages = await millageDb.GetListAsync();
            if (millages.Count > 0)
            {
                MillageListAdapter mlAdapter = new MillageListAdapter(this, millages);
                FindViewById<ListView>(Resource.Id.millageListView).Adapter = mlAdapter;
            }



        }
        
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu , menu);
			//var addMenuItem = menu.FindItem(Resource.Id.addMenuItem);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			//Toast.MakeText(this, "Action selected: " + item.TitleFormatted,ToastLength.Short).Show();
			if (item.TitleFormatted.ToString() == "Add")
			{
				var addMillageIntent = new Intent(this, typeof(AddMillageActivity));
				StartActivity(addMillageIntent);
			}

			return base.OnOptionsItemSelected(item);
		}
	}

}

