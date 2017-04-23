using System;
using SQLite;
using Java.IO;
using Android.Runtime;

namespace MillageCalc 
{
	[Table("millage")]
	public class MillageRd
	{
		[AutoIncrement]
		[PrimaryKey]
		public int Id { get; set; }
		public float StartKm { get; set; }
		public float Fuel { get; set; }
		public float EndKm { get; set; }
        public float Millage { get; set; }

        public void ComputeMillage()
        {
            float traveledKm = EndKm - StartKm;
            float fuelInMl = Fuel * 1000;
            Millage = (traveledKm / fuelInMl) * 1000;

        }
    }	
}
