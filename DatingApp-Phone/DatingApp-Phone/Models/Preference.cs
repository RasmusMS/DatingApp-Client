using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp_Phone.Models
{
    public class Preference
    {
        public int Min_age { get; set; }
        public int Max_age { get; set; }
        public int Max_distance { get; set; }
        public string Prefered_sexuality { get; set; }
    }
}
