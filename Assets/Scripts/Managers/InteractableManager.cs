using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public Transform InteractableHolder;

    private Dictionary<string, GameObject> InteractableDicto;

    private void Awake()
    {
        InteractableDicto = new Dictionary<string, GameObject>();

        for (int i = 0; i < InteractableHolder.childCount; i++)
        {
            InteractableDicto.Add(InteractableHolder.GetChild(i).name, InteractableHolder.GetChild(i).gameObject);
        }
    }

    public void UnlockInteractables(string[] nameList)
    {
        GameObject target;
        foreach (string name in nameList)
        {
            InteractableDicto.TryGetValue(name, out target);

            target.GetComponent<Interactable>().Unlock();
        }
    }

    public void LockInteractables(string[] nameList)
    {
        GameObject target;
        foreach (string name in nameList)
        {
            InteractableDicto.TryGetValue(name, out target);

            target.GetComponent<Interactable>().Lock();
        }
    }
}
