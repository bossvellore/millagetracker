using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Views;
using Android.Widget;

namespace MillageCalc.Droid
{
	public class MillageListAdapter : BaseAdapter<MillageRd>
	{
		MillageRd[] items;
		Activity context;
		public MillageListAdapter(Activity context, Task<List<MillageRd>> items) : base()
		{
			this.context = context;
			this.items = items.Result.ToArray();
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override MillageRd this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.MillageListItem, null);
			view.FindViewById<TextView>(Resource.Id.startKm).Text = items[position].StartKm.ToString();

			return view;
		}
	}
}
