using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManager
{
    interface IUserAuther
    {
        User User { get; }
        IUserAuther Run();
        bool AuthIsValid();
    }
}
