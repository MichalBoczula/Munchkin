namespace Munchkin.Model.Character
{
    public interface IBaseAction
    {
        CardGameBase TakeCard();
        int RunAway();
        bool Fight();
        bool AskForHelp();
        bool ThrowOutCart(int whichOne, UserClass user);
        CardGameBase UseCardFromDeck();
        bool TakeAction();
    }
}