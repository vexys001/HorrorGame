using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    private bool _on = false;
    private MeshRenderer _renderer; 

    public GameObject LinkedLight;
    public Material OnMaterial;
    public Material OffMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _on = false;
        LinkedLight.SetActive(false);
        _renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(GameObject origin)
    {
        if (_on)
        {
            _on = false;

            _renderer.material = OffMaterial;

            LinkedLight.SetActive(false);
        }
        else
        {
            _on = true;

            _renderer.material = OnMaterial;

            LinkedLight.SetActive(true);
        }
    }
}
