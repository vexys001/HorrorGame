using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SmokingManager.Instance.StartNeedSmoke();
            gameObject.SetActive(false);
        }
    }
}
