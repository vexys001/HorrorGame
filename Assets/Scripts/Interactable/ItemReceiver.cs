using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : Interactable
{
    public Transform whereToPutItem;
    public string[] KeyNames;
    public TaskManager TaskMngr;

    public override void Interact(GameObject origin)
    {
        Avatar player = origin.GetComponent<Avatar>();
        if (player.HeldItem && Array.Exists(KeyNames, verif => verif == player.HeldItem.name))
        {
            TaskMngr.CompletedSubTask();

            GameObject obj = player.GiveItem();
            obj.transform.parent = whereToPutItem;

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
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
}
