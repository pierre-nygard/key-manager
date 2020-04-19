using KeyManager.Models;

namespace KeyManager
{
    interface IMainUpstart
    {
        IMainUpstart SetForUser(User user);
        IMainUpstart Run();
    }
}
