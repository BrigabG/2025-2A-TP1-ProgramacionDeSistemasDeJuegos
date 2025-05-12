namespace Gameplay
{
    public interface IInteractable
    {
        void Interact(IInteractor target);
        string name { get; }
    }
}