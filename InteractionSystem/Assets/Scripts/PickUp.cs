using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;

public class PickUp : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        InteractionController.Instance.OnInitInteraction(this);
    }
}
