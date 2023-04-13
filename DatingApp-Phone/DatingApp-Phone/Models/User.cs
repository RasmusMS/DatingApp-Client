using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp_Phone.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public int phonenumber { get; set; }
        public string password { get; set; }
        public bool active_profile { get; set; }
        public string token { get; set; }
        public Gender genders { get; set; }
        public Country countries { get; set; }
        public Bio biography { get; set; }
        public List<Picture> pictures { get; set; }
        public List<Interest> interests { get; set; }
        public List<Lifestyle> lifestyles { get; set; }
    }
}
