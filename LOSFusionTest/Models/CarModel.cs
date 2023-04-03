using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOSFusionTest.Models
{
    public class CarModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string UserId { get; set; }
        public DateTime Year { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}