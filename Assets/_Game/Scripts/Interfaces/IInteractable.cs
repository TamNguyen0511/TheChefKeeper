using _Game.Scripts.Interfaces.InterfaceActors;

namespace _Game.Scripts.Interfaces
{
    public interface IInteractable
    {
        public string InteractionPrompt { get; }

        public bool Interact(Interactor interactor);
    }
}