using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretteMeterUI : MonoBehaviour
{
    private void Awake()
    {
        SmokingManager.Instance.SetMeter(gameObject);
        gameObject.SetActive(false);
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
