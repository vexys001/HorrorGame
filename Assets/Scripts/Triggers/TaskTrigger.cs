using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    public TaskManager TaskMngr;

    private void OnTriggerEnter(Collider other)
    {
        TaskMngr.StartTasks();
        gameObject.SetActive(false);
    }
}
