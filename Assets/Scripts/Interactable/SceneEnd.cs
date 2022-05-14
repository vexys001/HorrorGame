using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnd : Interactable
{
    [SerializeField] private string NextSceneName;
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
        GameManager.Instance.LoadNextScene(NextSceneName);
    }
}
