using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SalesWebService.Models.Chart
{
	//DataContract for Serializing Data - required to serve in JSON format
	[DataContract]
	public class ChartViewModel
	{
		public ChartViewModel(int y, string label)
		{
			this.Y = y;
			this.label = label;
		}
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<int> Y = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string label = null;

	}
}
