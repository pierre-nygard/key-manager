using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManager
{
    interface IAuthService
    {
        User User { get; }
        IAuthService Run();
        bool AuthIsValid();
    }
}
