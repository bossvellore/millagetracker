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
		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.AddMillage);
            MillageRd mrd;
            MillageDb millageDb = MillageDb.GetDB(DataConnection.GetConnection());
            int editMillageId = Intent.GetIntExtra("Edit_Millage_Id", 0);
            if( editMillageId > 0)
            {
                mrd = await millageDb.Find(editMillageId);
                FindViewById<EditText>(Resource.Id.startKm).Text = mrd.StartKm.ToString();
                FindViewById<EditText>(Resource.Id.endKm).Text = mrd.EndKm.ToString();
                FindViewById<EditText>(Resource.Id.fuel).Text = mrd.Fuel.ToString();
            }
            else
            {
                mrd = new MillageRd();
            }
            // Create your application here
            Button saveBtn = FindViewById<Button>(Resource.Id.saveBtn);

            saveBtn.Click += async delegate {
				
                if (FindViewById<EditText>(Resource.Id.startKm).Text == "")
				{
                    Toast.MakeText(this, "Please Enter Start Km..", ToastLength.Long).Show();
                    return;
				}
                mrd.StartKm = float.Parse(FindViewById<EditText>(Resource.Id.startKm).Text);
                if (FindViewById<EditText>(Resource.Id.endKm).Text.Length > 0)
                {
                    mrd.EndKm = float.Parse(FindViewById<EditText>(Resource.Id.endKm).Text);
                }
                if (FindViewById<EditText>(Resource.Id.fuel).Text.Length > 0)
                {
                    mrd.Fuel = float.Parse(FindViewById<EditText>(Resource.Id.fuel).Text);
                }
                try
                {
                    await millageDb.SaveAsync(mrd);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
				this.Finish();
			};
		}
	}
}
