using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TaskScriptableObject", order = 1)]
public class TaskScriptableObject : ScriptableObject
{
    public string Message;
    public int numOfSteps;
    public string[] ObjectsToUnlock;
}
