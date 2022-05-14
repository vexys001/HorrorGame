using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public TaskScriptableObject[] TaskList;
    public InteractableManager InteractbleManager;

    private TaskScriptableObject _currentTask;
    private int _currentTaskNum = 0;
    private int _currentStepNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        _currentTask = TaskList[0];

        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        InteractbleManager.UnlockInteractables(_currentTask.ObjectsToUnlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompletedCurrentTask()
    {
        _currentTaskNum++;

        _currentTask = TaskList[_currentTaskNum];

        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        InteractbleManager.UnlockInteractables(_currentTask.ObjectsToUnlock);
    }
}
