using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public TextMeshProUGUI InteractionText;
    public TextMeshProUGUI TaskText;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<UIManager>();
                go.name = "(Singleton) UIManager";
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
        InteractionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
        TaskText = GameObject.Find("TaskText").GetComponent<TextMeshProUGUI>();
    }

    public void ChangeInteractionTXT(string interactString)
    {
        if (interactString == null)
        {
            InteractionText.text = "";
        }
        else
        {
            InteractionText.text = "Press 'E' to " + interactString;
        }
    }

    public void ChangeTaskTXT(string taskString)
    {
        if (taskString == null)
        {
            TaskText.text = "";
        }
        else
        {
            TaskText.text = taskString;
        }
    }
}
