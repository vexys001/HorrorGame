using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingManager : MonoBehaviour
{
    static SmokingManager instance;
    private GameObject _player;
    private GameObject _meter;

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

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

    public void SetMeter(GameObject meter)
    {
        _meter = meter;
    }

    public void StartNeedSmoke()
    {
        Debug.Log("You need to smoke!!!");
        _player.GetComponent<Avatar>().enabled = false;
        _player.GetComponent<AvatarSmoking>().enabled = true;
    }

    public void StartSmoking()
    {
        _meter.SetActive(true);
    }
}
