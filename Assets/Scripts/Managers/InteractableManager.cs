using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public GameObject InteractableHolder;
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
        Transform target;
        foreach (string name in nameList)
        {
            Debug.Log($"Unlocking {name}");
            target = InteractableHolder.transform.Find(name);
            target.GetComponent<Interactable>().Unlock();
        }
    }
}
