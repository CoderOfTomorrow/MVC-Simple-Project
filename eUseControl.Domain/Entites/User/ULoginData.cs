using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.Domain.Entites.User
{
    public class ULoginData
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
