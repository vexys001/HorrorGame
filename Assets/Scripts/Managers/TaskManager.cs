using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public TaskScriptableObject[] TaskList;
    public UIManager UiManager;

    private TaskScriptableObject _currentTask;
    private int _currentTaskNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        _currentTask = TaskList[0];

        UiManager.ChangeTaskTXT(_currentTask.Message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompletedCurrentTask()
    {
        _currentTaskNum++;

        _currentTask = TaskList[_currentTaskNum];

        UiManager.ChangeTaskTXT(_currentTask.Message);
    }
}
