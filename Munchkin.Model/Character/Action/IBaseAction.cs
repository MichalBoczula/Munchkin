namespace Munchkin.Model.Character
{
    public interface IBaseAction
    {
        CardGameBase TakeCard();
        int RunAway();
        bool Fight();
        bool AskForHelp();
        CardGameBase ThrowCard();
        CardGameBase UseCardFromDeck();
        bool TakeAction();
    }
}