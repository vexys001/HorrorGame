using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string ContextMessage;
    public bool Locked = true;

    public abstract void Interact(GameObject origin);

    public void Unlock()
    {
        Locked = false;
    }

    public void Lock()
    {
        Locked = true;
    }
}
