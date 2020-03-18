using System;

namespace eUseControl.Domain.Entites.User
{
    public class ULoginData
    {
        public string Login     { get; set; }
        public string Password  { get; set; }
        public string UserIp    { get; set; }
        public DateTime UserLTime { get; set; }
    }
}
