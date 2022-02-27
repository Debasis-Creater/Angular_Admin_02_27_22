using System;
using System.Collections.Generic;
using System.Text;

namespace SessionProvider
{
    [Serializable]

    public class SessionModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    }
}
