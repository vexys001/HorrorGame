using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingManager : MonoBehaviour
{
    static SmokingManager instance;
    private GameObject _player;
    private GameObject _meter;
    private GameObject _taskMngr;

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

        _taskMngr = GameObject.Find("TaskManager");
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

    public void SetMeter(GameObject meter)
    {
        _meter = meter;
    }

    public void SetTaskManager(GameObject manager)
    {
        _taskMngr = manager;
    }


    public void StartNeedSmoke()
    {
        _player.GetComponent<Avatar>().enabled = false;
        _player.GetComponent<AvatarSmoking>().enabled = true;

        UIManager.Instance.ChangeTaskTXT("Smoke a cigarette");
        UIManager.Instance.ChangeInteractionTXT("Press 'Q' to smoke");
    }

    public void StartSmoking()
    {
        _meter.SetActive(true);

        UIManager.Instance.ChangeInteractionTXT(null);
    }

    public void StopSmoking()
    {
        _meter.SetActive(false);

        _taskMngr.GetComponent<TaskManager>().CompletedCurrentTask();

        _player.GetComponent<Avatar>().enabled = true;
        _player.GetComponent<AvatarSmoking>().enabled = false;
    }
}
