namespace InteractionSystem
{
    public interface IInteractable
    {
        InteractIntroduction Introduction { get; }

        void Interact();
    }
}