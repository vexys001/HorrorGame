using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAppearance : Scare
{
    public Renderer Rendrr;
    public float Duration;

    // Start is called before the first frame update
    void Start()
    {
        Rendrr = GetComponent<Renderer>();
        Rendrr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ScarePlayer()
    {
        Rendrr.enabled = true;
        StartCoroutine("Disappear");
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(Duration);
        Rendrr.enabled = false;
    }
}
