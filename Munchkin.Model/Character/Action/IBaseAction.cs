using Munchkin.Model.Helper;
using Munchkin.Model.User;

namespace Munchkin.Model.Character
{
    public interface IBaseAction
    {
        bool ThrowOutCart(int whichOne, UserClass user);
        void CleanAfterTurn();
    }
}