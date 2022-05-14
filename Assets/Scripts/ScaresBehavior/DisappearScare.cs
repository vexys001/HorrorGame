using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScare : Scare
{
    public override void ScarePlayer()
    {
        gameObject.SetActive(false);
    }
}
