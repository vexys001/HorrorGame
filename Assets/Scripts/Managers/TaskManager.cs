using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public TaskScriptableObject[] TaskList;
    public InteractableManager InteractbleManager;
    public ScareManager ScareMngr;

    private TaskScriptableObject _currentTask;
    private int _currentTaskNum = 0;
    private int _currentStepNum = 0;

    private void Start()
    {
        UIManager.Instance.ChangeTaskTXT(null);
        SmokingManager.Instance.SetTaskManager(gameObject);
    }

    public void StartTasks()
    {
        _currentTask = TaskList[0];

        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        InteractbleManager.UnlockInteractables(_currentTask.ObjectsToUnlock);

        ScareMngr.UnlockScare(_currentTask.ScaresToUnlock);
    }

    public void CompletedSubTask()
    {
        _currentStepNum++;
        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        if(_currentStepNum == _currentTask.numOfSteps)
        {
            CompletedCurrentTask();
        }
    }

    public void CompletedCurrentTask()
    {
        _currentStepNum = 0;
        //Lock Previous Items
        InteractbleManager.LockInteractables(_currentTask.ObjectsToUnlock);

        //Unlock future items
        _currentTaskNum++;

        _currentTask = TaskList[_currentTaskNum];

        UIManager.Instance.ChangeTaskTXT($"{_currentTask.Message} ({_currentStepNum} / {_currentTask.numOfSteps})");

        InteractbleManager.UnlockInteractables(_currentTask.ObjectsToUnlock);

        ScareMngr.UnlockScare(_currentTask.ScaresToUnlock);
    }
}
