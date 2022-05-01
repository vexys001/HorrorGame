using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string ContextMessage;

    public abstract void Interact(GameObject origin);
}
