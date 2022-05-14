using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : Interactable
{
    public override void Interact(GameObject origin)
    {
        origin.SendMessage("PickUpItem", gameObject);
    }
}
