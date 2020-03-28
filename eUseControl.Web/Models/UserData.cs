using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserData
    {
        //toate datele care utilizatorul le poate introduce despre el
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public URole Level { get; set; } 
        public string Country { get; set; }
    }
}