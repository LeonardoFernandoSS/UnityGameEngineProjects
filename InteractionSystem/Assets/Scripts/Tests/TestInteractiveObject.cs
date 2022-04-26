using UnityEngine;
using InteractionSystem;

public class TestInteractiveObject : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractIntroduction introduction;

    public InteractIntroduction Introduction { get => introduction; }

    public void Interact()
    {
        Debug.Log("Interacted");
    }
}
