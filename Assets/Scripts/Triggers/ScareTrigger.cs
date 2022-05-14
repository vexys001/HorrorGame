using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTrigger : MonoBehaviour
{
    public Scare[] Scares;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enabling scare");

            foreach (Scare scare in Scares)
            {
                scare.ScarePlayer();
            }

            gameObject.SetActive(false);
        }
    }
}
