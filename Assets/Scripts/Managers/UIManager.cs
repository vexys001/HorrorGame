using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI InteractionText;
    public TextMeshProUGUI TaskText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
