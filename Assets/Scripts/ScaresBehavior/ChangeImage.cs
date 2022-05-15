using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : Scare
{
    public Material _original;
    public Material _scary;

    // Start is called before the first frame update
    void Start()
    {
        _original = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ScarePlayer()
    {
        GetComponent<Renderer>().material = _scary;
    }
}
