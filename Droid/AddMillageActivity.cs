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

namespace MillageCalc.Droid
{
	[Activity(Label = "AddMillageActivity")]
	public class AddMillageActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.AddMillage);
			// Create your application here
			Button saveBtn = FindViewById<Button>(Resource.Id.saveBtn);
			saveBtn.Click += delegate {
				MillageRd mrd = new MillageRd();
				if (FindViewById<EditText>(Resource.Id.startKm).Text.Length > 0)
				{
					mrd.StartKm = float.Parse(FindViewById<EditText>(Resource.Id.startKm).Text);
				}
				mrd.EndKm = float.Parse(FindViewById<EditText>(Resource.Id.endKm).Text);
				mrd.Fuel = float.Parse(FindViewById<EditText>(Resource.Id.fuel).Text);
				MillageDb millageDb = MillageDb.GetDB(DataConnection.GetConnection());
				millageDb.SaveAsync(mrd);
				this.Finish();

			};
		}
	}
}
