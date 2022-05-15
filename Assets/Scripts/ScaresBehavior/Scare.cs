using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scare : MonoBehaviour
{
    public bool StayActiveOnLoad;

    public abstract void ScarePlayer();
}
