using System;
using System.Collections.Generic;
using System.Text;

namespace SessionProvider.IProvider
{
    public interface ISessionProviderService
    {
        int UserId { get; set; }
        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string GetSessionId();
        void ClearSession();
        string GetIP();
    }
}
