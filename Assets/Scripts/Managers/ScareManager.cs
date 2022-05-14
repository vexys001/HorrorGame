using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareManager : MonoBehaviour
{
    public Transform ScareHolder;

    private Dictionary<string, GameObject> ScareDicto;

    private void Awake()
    {
        ScareDicto = new Dictionary<string, GameObject>();

        for (int i = 0; i < ScareHolder.childCount; i++)
        {
            var go = ScareHolder.GetChild(i).gameObject;
            go.SetActive(false);
            ScareDicto.Add(ScareHolder.GetChild(i).name, go);
        }
    }

    public void UnlockScare(string[] nameList)
    {
        GameObject target;
        foreach (string name in nameList)
        {
            ScareDicto.TryGetValue(name, out target);

            target.SetActive(true);
        }
    }

    public void LockScare(string[] nameList)
    {
        GameObject target;
        foreach (string name in nameList)
        {
            ScareDicto.TryGetValue(name, out target);

            target.GetComponent<Interactable>().Lock();
        }
    }
}
