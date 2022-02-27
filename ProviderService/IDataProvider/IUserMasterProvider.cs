using BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProviderService.IDataProvider
{
    public interface IUserMasterProvider
    {
        AuthResModel Authentication(AuthModel login);
    }
}
