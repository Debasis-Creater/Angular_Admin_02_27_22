using Microsoft.AspNetCore.Http;
using SessionProvider.IProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SessionProvider.Provider
{
    public class SessionProviderService : ISessionProviderService
    {

        #region Variables        
        private string sessionKey = "MyDemoKey";
        private readonly IHttpContextAccessor _httpContextAccessor = null;
        private SessionModel SessionData { get; set; }
        #endregion

        public int UserId
        {
            get => GetSession().UserId;
            set
            {
                SessionData.UserId = value;
                SetSession();
            }
        }

        public string Username
        {
            get => GetSession().Username;
            set
            {
                SessionData.Username = value;
                SetSession();
            }

        }
        public string FirstName
        {
            get => GetSession().FirstName;
            set
            {
                SessionData.FirstName = value;
                SetSession();
            }

        }
        public string LastName
        {
            get => GetSession().LastName;
            set
            {
                SessionData.LastName = value;
                SetSession();
            }

        }

        public SessionProviderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SessionData = GetSession();
            if (SessionData == null)
            {
                SessionData = new SessionModel();
            }
        }


        public SessionModel GetSession()
        {
            var session = _httpContextAccessor.HttpContext.Session.Get(sessionKey);
            return (SessionModel)(session != null ? FromByteArray<SessionModel>(session) : new SessionModel());
        }
        public void SetSession()
        {
            _httpContextAccessor.HttpContext.Session.Set(sessionKey, ObjectToByteArray(SessionData));
        }

        public string GetSessionId()
        {
            return _httpContextAccessor.HttpContext.Session.Id.ToString();
        }

        public void ClearSession()
        {
            SessionData = new SessionModel();
            _httpContextAccessor.HttpContext.Session.Remove(sessionKey);
            _httpContextAccessor.HttpContext.Session.Clear();
        }
        public string GetIP()
        {
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        private static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        private static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
            {
                return default(T);
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
