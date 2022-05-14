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

    public void StartTasks()
    {
        _currentTask = TaskList[0];

        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        InteractbleManager.UnlockInteractables(_currentTask.ObjectsToUnlock);
    }

    public void CompletedCurrentTask()
    {
        //Lock Previous Items
        InteractbleManager.LockInteractables(_currentTask.ObjectsToUnlock);

        //Unlock future items
        _currentTaskNum++;

        _currentTask = TaskList[_currentTaskNum];

        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        InteractbleManager.UnlockInteractables(_currentTask.ObjectsToUnlock);
    }
}
