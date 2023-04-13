using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp_Phone.Models
{
    public class Picture
    {
        public int id { get; }
        public string path { get; set; }
        //public int rank { get; set; }
        public int users_id { get; set; }
    }
}
