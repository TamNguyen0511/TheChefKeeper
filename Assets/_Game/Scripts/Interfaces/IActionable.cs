using _Game.Scripts.Interfaces.InterfaceActors;

namespace _Game.Scripts.Interfaces
{
    public interface IActionable
    {
        public void Action(Interactor action);
        public void ActionCancel(Interactor action);
    }
}