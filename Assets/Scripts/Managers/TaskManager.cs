using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public TaskScriptableObject[] TaskList;

    [SerializeField] private TaskScriptableObject _currentTask;
    [SerializeField] private int _currentTaskNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCurrentTask(TaskScriptableObject nTask)
    {
        _currentTask = nTask;
    }

    void CompletedCurrentTask()
    {

    }
}
