using System;
using SQLite;

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
	}	
}
