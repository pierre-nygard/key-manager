using KeyManager.Models;

namespace KeyManager
{
    interface IMainService
    {
        IMainService SetForUser(User user);
        IMainService Run();
    }
}
