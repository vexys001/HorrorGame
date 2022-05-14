using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingManager : MonoBehaviour
{
    static SmokingManager instance;
    private Avatar _player;

    public static SmokingManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<SmokingManager>();
                go.name = "(Singleton) SmokingManager";
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetPlayer(Avatar player)
    {
        _player = player;
    }

    public void StartNeedSmoke()
    {
        Debug.Log("You need to smoke!!!");
        _player.enabled = false;
    }
}
