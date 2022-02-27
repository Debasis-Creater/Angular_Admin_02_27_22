using BusinessModel;
using ProviderService.IDataProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using SessionProvider.IProvider;

namespace ProviderService.DataProvider
{
    public class UserMasterProvider : IUserMasterProvider
    {
        SqlConnection con;
        private readonly IConfiguration _config;
        private ISessionProviderService _sessionProvider;
        public UserMasterProvider(IConfiguration configuration, ISessionProviderService sessionProvider)
        {
            this._config = configuration;
            this._sessionProvider = sessionProvider;
        }
        public AuthResModel Authentication(AuthModel login)
        {
            AuthResModel resModel = new AuthResModel();
            using (con = new SqlConnection(_config.GetConnectionString("DBConnection")))
            {
                try
                {
                    if(con.State == ConnectionState.Open) { con.Close(); }
                    string query = "select * from UserMaster where Email=@email and password=@pass";
                    SqlDataAdapter sda = new SqlDataAdapter(query,con);
                    sda.SelectCommand.Parameters.AddWithValue("@email", login.Email);
                    sda.SelectCommand.Parameters.AddWithValue("@pass", login.UserPassword);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        resModel = (from DataRow dr in dt.Rows
                                    select new AuthResModel()
                                    {
                                        UserId = Convert.ToInt32(dr["UserId"]),
                                        Username = dr["UserName"].ToString(),
                                    }).FirstOrDefault();
                        resModel.IsSuccess = true;
                        _sessionProvider.UserId = resModel.UserId;
                        _sessionProvider.Username = resModel.Username;
                    }
                    else
                    {
                        resModel.IsSuccess = false;
                        resModel.Message = "Invalid UserName or Password";
                    }
                }
                catch (Exception ex)
                {

                    
                }
                finally
                {
                    con.Close();
                }
            }
            return resModel;
        }
    }
}
