using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable
{
    public string[] KeyNames;
    public TaskManager TaskMngr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact(GameObject origin)
    {
        Avatar player = origin.GetComponent<Avatar>();
        if (player.HeldItem && Array.Exists(KeyNames, verif => verif == player.HeldItem.name))
        {
            TaskMngr.CompletedSubTask();

            player.DropItem();
            Locked = true;
        }
    }
}
