using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public Transform InteractableHolder;

    public Dictionary<string, GameObject> InteractableDicto;

    private void Awake()
    {
        InteractableDicto = new Dictionary<string, GameObject>();

        for (int i = 0; i < InteractableHolder.childCount; i++)
        {
            InteractableDicto.Add(InteractableHolder.GetChild(i).name, InteractableHolder.GetChild(i).gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockInteractables(string[] nameList)
    {
        GameObject target;
        foreach (string name in nameList)
        {
            Debug.Log($"Unlocking {name}");
            InteractableDicto.TryGetValue(name, out target);
            target.GetComponent<Interactable>().Unlock();
        }
    }
}
