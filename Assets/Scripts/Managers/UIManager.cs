using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI InteractionText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeInteractionTXT(string interactName)
    {
        if (interactName == null)
        {
            InteractionText.text = "";
        }
        else
        {
            InteractionText.text = "Press 'E' to pick up " + interactName;
        }
    }
}
