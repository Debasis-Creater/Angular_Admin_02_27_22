using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel
{
   public class AuthModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
    }
    public class AuthResModel : ResponseModel
    {
        public string EncryptUserId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
  
    }
}
