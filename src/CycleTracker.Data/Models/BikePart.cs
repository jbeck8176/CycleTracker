﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CycleTracker.Data.Attributes;

namespace CycleTracker.Data.Models
{
    public class BikePart : CycleTrackerBase
    {
		public DateTime InstalledDate { get; set; }
		public int InstalledBikeMileage { get; set; }
		public DateTime ReplacedDate { get; set; }
		public int ReplacedBikeMileage { get; set; }
		public int AccruedMileage { get; set; }
	    public decimal PurchasePrice { get; set; }
	    public string PurchaseRetailer { get; set; }
		public long BikeId { get; set; }
	    public long PartId { get; set; }

		[Ignore]
		public virtual Part Part { get; set; }
	}
}
