using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable
{
    public string KeyName;

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
        if (player.HeldItem && player.HeldItem.name == KeyName)
        {
            Debug.Log("Used right item on lock");
            player.DropItem();
            Destroy(gameObject);
        }
    }
}
