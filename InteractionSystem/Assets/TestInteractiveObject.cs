using UnityEngine;
using InteractionSystem;

public class TestInteractiveObject : InteractiveObject
{
    public override void Interact()
    {
        Debug.Log("Interacted");
    }
}
